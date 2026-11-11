#!/bin/sh
# shellcheck disable=SC2016
# =============================================================
# Floor1 first-boot configuration tests (CI layer 3)
#
# What is tested:
#   1. files/etc/uci-defaults/99-floor1-firstboot
#      The first-boot script baked INSIDE the firmware image:
#      802.11s mesh on 5GHz (ch44/VHT80, WPA3-SAE, M87986),
#      BATMAN_V + BLA + DAT + multicast mode, open Aden-Net
#      APs on both radios with client isolation, management
#      IP 10.0.0.8/16 (gw 10.0.0.1), DHCP off, STP bridge,
#      scheduled reboot every 6 hours.
#
#   2. .config
#      The firmware build seed - catches accidental removal
#      of essential packages (batman-adv, wpad-mesh, LuCI...).
#
# Layers 1 & 2 (syntax check + ShellCheck) are executed by:
#   .github/workflows/openwrt-tests.yml
#
# Usage: run from the repository root:  ./tests/static-checks.sh
# =============================================================

set -eu

SCRIPT="files/etc/uci-defaults/99-floor1-firstboot"
CONFIG=".config"

PASS_COUNT=0

pass() {
    PASS_COUNT=$((PASS_COUNT + 1))
    printf 'PASS: %s\n' "$*"
}

fail() {
    printf 'FAIL: %s\n' "$*"
    echo "================================"
    echo "STATIC CONFIGURATION TESTS FAILED"
    echo "================================"
    exit 1
}

# expect <file> <description> <grep args...>
expect() {
    _file="$1"; _desc="$2"; shift 2
    if grep -q "$@" "$_file"; then
        pass "$_desc"
    else
        fail "$_desc"
    fi
}

# forbid <file> <description> <grep args...>
forbid() {
    _file="$1"; _desc="$2"; shift 2
    if grep -q "$@" "$_file"; then
        fail "$_desc"
    else
        pass "$_desc"
    fi
}

echo "Starting Floor1 configuration tests..."
echo

[ -f "$SCRIPT" ] || fail "first-boot script not found: $SCRIPT"
[ -f "$CONFIG" ] || fail "build config not found: $CONFIG"

echo "--- first-boot script: $SCRIPT ---"

# --- basic sanity --------------------------------------------------
expect "$SCRIPT" "POSIX shell header (#!/bin/sh)" -E '^#! */bin/sh$'
expect "$SCRIPT" "script ends with 'exit 0' (uci-defaults contract)" -E '^exit 0'

# --- node identity ---------------------------------------------------
expect "$SCRIPT" "node name is Floor1" -F 'NODE_NAME="Floor1"'
expect "$SCRIPT" "management IP is 10.0.0.8" -F 'NODE_IP="10.0.0.8"'
expect "$SCRIPT" "netmask is 255.255.0.0 (/16)" -F 'NODE_MASK="255.255.0.0"'
expect "$SCRIPT" "default gateway is 10.0.0.1" -F 'GATEWAY_IP="10.0.0.1"'
expect "$SCRIPT" "DNS is 10.0.0.1" -F 'DNS_IP="10.0.0.1"'
expect "$SCRIPT" "hostname set from NODE_NAME" -F 'system.@system[0].hostname="$NODE_NAME"'

# --- BATMAN-adv core ---------------------------------------------------
expect "$SCRIPT" "bat0 uses proto 'batadv'" -F "uci set network.bat0.proto='batadv'"
expect "$SCRIPT" "routing algorithm is BATMAN_V" -F "uci set network.bat0.routing_algo='BATMAN_V'"
expect "$SCRIPT" "BLA bridge loop avoidance enabled" -F "uci set network.bat0.bridge_loop_avoidance='1'"
expect "$SCRIPT" "distributed ARP table enabled" -F "uci set network.bat0.distributed_arp_table='1'"
expect "$SCRIPT" "multicast mode enabled" -F "uci set network.bat0.multicast_mode='1'"
expect "$SCRIPT" "gateway mode off (no gateway announcement)" -F "uci set network.bat0.gw_mode='off'"

# --- mesh hard-interface wired into bat0 -------------------------------
expect "$SCRIPT" "batmesh is a batadv_hardif" -F "uci set network.batmesh.proto='batadv_hardif'"
expect "$SCRIPT" "batmesh master is bat0" -F "uci set network.batmesh.master='bat0'"
expect "$SCRIPT" "batmesh MTU 2304 (802.11s headroom)" -F "uci set network.batmesh.mtu='2304'"

# --- bridge ----------------------------------------------------------
expect "$SCRIPT" "STP enabled on br-lan" -F ".stp='1'"
expect "$SCRIPT" "IGMP snooping disabled" -F ".igmp_snooping='0'"
expect "$SCRIPT" "bat0 bridged into br-lan" -F "uci add_list network.\"\$BRIDGE_SECTION\".ports='bat0'"
expect "$SCRIPT" "bat0 removed before re-add (idempotent)" -F "uci -q del_list network.\"\$BRIDGE_SECTION\".ports='bat0'"
expect "$SCRIPT" "LAN switch port eth0.1 kept in bridge" -F "uci add_list network.\"\$BRIDGE_SECTION\".ports='eth0.1'"

# --- radios -----------------------------------------------------------
expect "$SCRIPT" "mesh channel is 44" -F 'MESH_CHANNEL="44"'
expect "$SCRIPT" "mesh htmode is VHT80" -F 'MESH_HTMODE="VHT80"'
expect "$SCRIPT" "5GHz radio uses mesh channel/htmode" -F '.channel="$MESH_CHANNEL"'
expect "$SCRIPT" "5GHz radio uses mesh htmode variable" -F '.htmode="$MESH_HTMODE"'
expect "$SCRIPT" "2.4GHz AP radio fixed channel 6" -F ".channel='6'"
expect "$SCRIPT" "2.4GHz radio HT20" -F ".htmode='HT20'"
expect "$SCRIPT" "country US (ch44 VHT80 allowed)" -F ".country='US'"

# --- dynamic detection (first-boot safe) --------------------------------
expect "$SCRIPT" "radios detected dynamically (wifi config runs before uci-defaults)" -F 'config_foreach detect_radios wifi-device'
expect "$SCRIPT" "br-lan section detected dynamically" -F 'config_foreach find_bridge device'

# --- stock AP removal ----------------------------------------------------
expect "$SCRIPT" "stock default_radio0 AP removed" -F 'uci -q delete wireless.default_radio0'
expect "$SCRIPT" "stock default_radio1 AP removed" -F 'uci -q delete wireless.default_radio1'

# --- 5GHz AP -----------------------------------------------------------
expect "$SCRIPT" "5GHz AP SSID" -F 'SSID_5G="✨ADEN-NET✨-5G"'
expect "$SCRIPT" "5GHz AP SSID assigned" -F '.ssid="$SSID_5G"'
expect "$SCRIPT" "5GHz AP attached to lan" -F ".network='lan'"
expect "$SCRIPT" "5GHz AP DTIM 10" -F ".dtim_period='10'"

# --- 2.4GHz AP ---------------------------------------------------------
expect "$SCRIPT" "2.4GHz AP SSID" -F 'SSID_2G="✨ADEN-NET✨-4G"'
expect "$SCRIPT" "2.4GHz AP SSID assigned" -F '.ssid="$SSID_2G"'
expect "$SCRIPT" "2.4GHz AP DTIM 20" -F ".dtim_period='20'"

# --- AP tuning/hardening (both bands) ------------------------------------
expect "$SCRIPT" "APs open by design (encryption none)" -F ".encryption='none'"
expect "$SCRIPT" "client isolation on APs" -F ".isolate='1'"
expect "$SCRIPT" "802.11k enabled on APs" -F ".ieee80211k='1'"
expect "$SCRIPT" "802.11v enabled on APs" -F ".ieee80211v='1'"
expect "$SCRIPT" "BSS transition enabled on APs" -F ".bss_transition='1'"
expect "$SCRIPT" "multicast to unicast on APs" -F ".multicast_to_unicast='1'"

# --- 802.11s mesh interface ------------------------------------------------
expect "$SCRIPT" "mesh section is 802.11s 'mesh' mode" -F ".mode='mesh'"
expect "$SCRIPT" "mesh ID is M87986" -F 'MESH_ID="M87986"'
expect "$SCRIPT" "mesh ID assigned to iface" -F '.mesh_id="$MESH_ID"'
expect "$SCRIPT" "mesh protected with WPA3-SAE" -F ".encryption='sae'"
expect "$SCRIPT" "mesh key set" -F 'MESH_KEY="11223344"'
expect "$SCRIPT" "mesh key assigned to iface" -F '.key="$MESH_KEY"'
expect "$SCRIPT" "PMF required on mesh (802.11w=2)" -F ".ieee80211w='2'"
expect "$SCRIPT" "SAE PWE mode 2 (both methods)" -F ".sae_pwe='2'"
expect "$SCRIPT" "802.11s forwarding off (batman-adv does the routing)" -F ".mesh_fwding='0'"
expect "$SCRIPT" "mesh iface attached to batmesh hardif" -F ".network='batmesh'"

# --- LAN / management -------------------------------------------------------
expect "$SCRIPT" "LAN static on br-lan" -F ".proto='static'"
expect "$SCRIPT" "LAN device br-lan" -F ".device='br-lan'"
expect "$SCRIPT" "LAN IP from NODE_IP" -F '.ipaddr="$NODE_IP"'
expect "$SCRIPT" "LAN netmask from NODE_MASK" -F '.netmask="$NODE_MASK"'
expect "$SCRIPT" "default gateway set" -F '.gateway="$GATEWAY_IP"'
expect "$SCRIPT" "DNS set" -F '.dns="$DNS_IP"'
expect "$SCRIPT" "IPv6 off on lan" -F ".ipv6='0'"
expect "$SCRIPT" "IPv6 delegation off" -F ".delegate='0'"

# --- DHCP server disabled (MikroTik gateway is the DHCP server) ---------------
expect "$SCRIPT" "DHCP server disabled" -F "uci set dhcp.lan.ignore='1'"
expect "$SCRIPT" "Router Advertisements disabled" -F "dhcp.lan.ra='disabled'"
expect "$SCRIPT" "DHCPv6 disabled" -F "dhcp.lan.dhcpv6='disabled'"
expect "$SCRIPT" "NDP disabled" -F "dhcp.lan.ndp='disabled'"
expect "$SCRIPT" "odhcpd service disabled" -F "/etc/init.d/odhcpd disable"

# --- commits -----------------------------------------------------------------
for _cfg in network wireless dhcp system; do
    expect "$SCRIPT" "uci commit $_cfg" -F "uci commit $_cfg"
done

# --- scheduled reboot -----------------------------------------------------------
expect "$SCRIPT" "reboot every 6 hours scheduled" -F '0 */6 * * * /sbin/reboot'
expect "$SCRIPT" "cron service enabled" -F "/etc/init.d/cron enable"

# --- forbidden patterns ------------------------------------------------------------
forbid "$SCRIPT" "channel must never be 'auto' (breaks 802.11s)" -F "channel='auto'"
forbid "$SCRIPT" "BATMAN_IV must not be used (BATMAN_V network)" -F "routing_algo='BATMAN_IV'"
forbid "$SCRIPT" "uci-defaults must not restart network (services not up yet)" -E '/etc/init\.d/network restart'
forbid "$SCRIPT" "uci-defaults must not reload wireless (services not up yet)" -E 'wifi reload'
forbid "$SCRIPT" "mesh encryption must never be 'none'" -F "MESH_SECTION\".encryption='none'"

echo
echo "--- firmware build config: $CONFIG ---"

expect "$CONFIG" "target device is Phicomm K2 v22.5 (ramips/mt7620)" -F "CONFIG_TARGET_ramips_mt7620_DEVICE_phicomm_k2-v22.5=y"
expect "$CONFIG" "kmod-batman-adv selected" -F "CONFIG_PACKAGE_kmod-batman-adv=y"
expect "$CONFIG" "BATMAN_V compiled in" -F "CONFIG_BATMAN_ADV_BATMAN_V=y"
expect "$CONFIG" "BLA compiled in" -F "CONFIG_BATMAN_ADV_BLA=y"
expect "$CONFIG" "DAT compiled in" -F "CONFIG_BATMAN_ADV_DAT=y"
expect "$CONFIG" "multicast optimization compiled in" -F "CONFIG_BATMAN_ADV_MCAST=y"
expect "$CONFIG" "batctl selected" -F "CONFIG_PACKAGE_batctl-default=y"
expect "$CONFIG" "wpad-mesh-mbedtls selected (SAE for 802.11s)" -F "CONFIG_PACKAGE_wpad-mesh-mbedtls=y"
expect "$CONFIG" "iw selected" -F "CONFIG_PACKAGE_iw=y"
expect "$CONFIG" "LuCI selected" -F "CONFIG_PACKAGE_luci=y"

# wpad-basic has no SAE support - it must never replace wpad-mesh
forbid "$CONFIG" "wpad-basic must not replace wpad-mesh (no SAE)" -E '^CONFIG_PACKAGE_wpad-basic(-mbedtls)?=y'

echo
echo "NOTE: the mesh key is committed to this repository. If the repository is"
echo "      public anyone can read it and join the mesh - consider changing the"
echo "      key on the device after first boot:"
echo "        uci set wireless.wifinet2.key='NEW_KEY'; uci commit wireless; wifi"
echo
echo "NOTE: BATMAN_V must be enabled on ALL mesh nodes, including the MikroTik"
echo "      gateway, otherwise the nodes will not see each other."
echo
echo "================================"
echo "ALL $PASS_COUNT STATIC TESTS PASSED"
echo "================================"
