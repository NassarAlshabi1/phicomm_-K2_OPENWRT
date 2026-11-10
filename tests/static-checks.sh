#!/bin/sh
# =============================================================
# Floor1 mesh configuration tests (CI layer 3)
#
# What is tested:
#   1. files/etc/uci-defaults/99-mesh-floor1
#      The first-boot script that ships INSIDE the firmware
#      image: BATMAN_IV + BLA, 802.11s + WPA3-SAE, fixed
#      channel, bat0 bridged to br-lan with STP, DHCP off.
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

SCRIPT="files/etc/uci-defaults/99-mesh-floor1"
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

# --- basic sanity -------------------------------------------------
# uci-defaults scripts are sourced by /etc/init.d/boot on first boot
expect "$SCRIPT" "POSIX shell header (#!/bin/sh)" -E '^#! */bin/sh$'
# on success the script is deleted after first boot; a missing exit 0
# would make it rerun on every boot
expect "$SCRIPT" "script ends with 'exit 0' (uci-defaults contract)" -E '^exit 0'

# --- BATMAN-adv ---------------------------------------------------
expect "$SCRIPT" "bat0 uses proto 'batadv'" -F "uci set network.bat0.proto='batadv'"
expect "$SCRIPT" "routing algorithm is BATMAN_IV (matches MikroTik gateway)" -F "uci set network.bat0.routing_algo='BATMAN_IV'"
expect "$SCRIPT" "BLA bridge loop avoidance enabled" -F "uci set network.bat0.bridge_loop_avoidance='1'"

# --- mesh identity & security -------------------------------------
expect "$SCRIPT" "MESH_ID is M87986" -F 'MESH_ID="M87986"'
expect "$SCRIPT" "mesh0 is an 802.11s 'mesh' interface" -F "uci set wireless.mesh0.mode='mesh'"
expect "$SCRIPT" "mesh encryption is WPA3-SAE" -F "uci set wireless.mesh0.encryption='sae'"
expect "$SCRIPT" "mesh key variable is defined" -F 'MESH_KEY='

# --- radio: fixed channel is mandatory for 802.11s ----------------
expect "$SCRIPT" "fixed channel 1" -F ".channel='1'"
expect "$SCRIPT" "HT20 mode on 2.4 GHz" -F ".htmode='HT20'"

# --- mesh hard-interface wired into bat0 ---------------------------
expect "$SCRIPT" "nwi_mesh0 is a batadv_hardif" -F "uci set network.nwi_mesh0.proto='batadv_hardif'"
expect "$SCRIPT" "nwi_mesh0 master is bat0" -F "uci set network.nwi_mesh0.master='bat0'"
expect "$SCRIPT" "mesh MTU 2304 (batman-adv headroom)" -F ".mtu='2304'"

# --- bridging & management ------------------------------------------
expect "$SCRIPT" "bat0 bridged into br-lan" -F "uci add_list network.@device[0].ports='bat0'"
expect "$SCRIPT" "STP enabled on br-lan" -F ".stp='1'"
expect "$SCRIPT" "management IP is 10.0.0.245" -F 'MGMT_IP="10.0.0.245"'
expect "$SCRIPT" "LAN netmask 255.255.255.0" -F ".netmask='255.255.255.0'"

# --- this node is not a DHCP server ---------------------------------
expect "$SCRIPT" "DHCP server disabled (dhcp.lan.ignore=1)" -F "uci set dhcp.lan.ignore='1'"

# --- no stray default AP on the mesh radio --------------------------
expect "$SCRIPT" "default_radio0 AP removed (radio dedicated to mesh)" -F "delete wireless.default_radio0"

# --- every touched config must be committed -------------------------
expect "$SCRIPT" "uci commit wireless" -F "uci commit wireless"
expect "$SCRIPT" "uci commit network" -F "uci commit network"
expect "$SCRIPT" "uci commit dhcp" -F "uci commit dhcp"

# --- forbidden patterns ----------------------------------------------
forbid "$SCRIPT" "channel must never be 'auto' (breaks 802.11s)" -F "channel='auto'"
forbid "$SCRIPT" "mesh encryption must never be 'none'" -F ".encryption='none'"
forbid "$SCRIPT" "must not reload/restart dnsmasq or odhcpd (disabled here)" -E '/etc/init\.d/(dnsmasq|odhcpd) (reload|restart)'

echo
echo "--- firmware build config: $CONFIG ---"

expect "$CONFIG" "target device is Phicomm K2 v22.5 (ramips/mt7620)" -F "CONFIG_TARGET_ramips_mt7620_DEVICE_phicomm_k2-v22.5=y"
expect "$CONFIG" "kmod-batman-adv selected" -F "CONFIG_PACKAGE_kmod-batman-adv=y"
expect "$CONFIG" "batctl selected" -F "CONFIG_PACKAGE_batctl-default=y"
expect "$CONFIG" "wpad-mesh-mbedtls selected (WPA3-SAE for 802.11s)" -F "CONFIG_PACKAGE_wpad-mesh-mbedtls=y"
expect "$CONFIG" "iw selected" -F "CONFIG_PACKAGE_iw=y"
expect "$CONFIG" "LuCI selected" -F "CONFIG_PACKAGE_luci=y"
expect "$CONFIG" "BLA compiled into batman-adv" -F "CONFIG_BATMAN_ADV_BLA=y"
expect "$CONFIG" "BATMAN_V stays disabled (BATMAN_IV network)" -F "# CONFIG_BATMAN_ADV_BATMAN_V is not set"

# wpad-basic has no SAE support - it must never replace wpad-mesh
forbid "$CONFIG" "wpad-basic must not replace wpad-mesh (no SAE)" -E '^CONFIG_PACKAGE_wpad-basic(-mbedtls)?=y'

echo
if grep -q 'MESH_KEY="CHANGE_MESH_PASSWORD"' "$SCRIPT"; then
    echo "WARNING: mesh key is still the placeholder CHANGE_MESH_PASSWORD."
    echo "         Expected in the committed script - set the real key after"
    echo "         first login:"
    echo "           uci set wireless.mesh0.key='YOUR_REAL_KEY'; uci commit wireless; wifi"
else
    echo "NOTE: a real mesh key seems to be committed - remember that anyone"
    echo "      with access to this repository can read it."
fi

echo
echo "================================"
echo "ALL $PASS_COUNT STATIC TESTS PASSED"
echo "================================"
