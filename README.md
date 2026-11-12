**English** | [中文](https://p3terx.com/archives/build-openwrt-with-github-actions.html)

# Actions-OpenWrt — Phicomm K2

[![OpenWrt Configuration Tests](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/actions/workflows/openwrt-tests.yml/badge.svg)](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/actions/workflows/openwrt-tests.yml)
[![LICENSE](https://img.shields.io/github/license/mashape/apistatus.svg?style=flat-square&label=LICENSE)](https://github.com/P3TERX/Actions-OpenWrt/blob/master/LICENSE)

Custom OpenWrt firmware for the **Phicomm K2 (MediaTek MT7620A)** router, built with GitHub Actions from the official OpenWrt source.

## 📥 Firmware Download

All builds are available on the [Releases](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases) page.

### Current build — v22.4 Mesh Node (Floor1) — OpenWrt 23.05.6, BATMAN_V

| Item | Details |
| --- | --- |
| Device profile | Phicomm K2 **v22.4 and older** |
| Target / SoC | ramips / MediaTek MT7620A @ 580 MHz |
| OpenWrt version | **23.05.6** — built from the official `v23.05.6` release tag (release commit `761ee326`, feeds pinned to the exact release commits), Linux 5.15.189 |
| Mesh | batman-adv 2023.1 — **BATMAN_V + BLA + DAT + multicast**, 802.11s on **5GHz channel 44 / VHT80**, WPA3-SAE, mesh ID `M87986` |
| Client APs | `✨ADEN-NET✨-5G` (5GHz) + `✨ADEN-NET✨-4G` (2.4GHz, ch6/HT20) — open, client isolation, 802.11k/v |
| Management IP | `10.0.0.8/16`, gateway `10.0.0.1` (DHCP off — the MikroTik gateway serves the network) |
| Extras | STP on `br-lan`, scheduled reboot every 6 hours, hostname `Floor1` |
| File | `openwrt-ramips-mt7620-phicomm_k2-v22.4-squashfs-sysupgrade.bin` (6.00 MB / 6,292,301 bytes) |
| SHA256 | `db6e11137d95aa97e7953b84d6aa04922216397044007301d92f714ad9194f9a` |

**Direct download:** [`openwrt-ramips-mt7620-phicomm_k2-v22.4-squashfs-sysupgrade.bin`](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases/download/v22.4-ow23.05.6-2026.11.12-0756/openwrt-ramips-mt7620-phicomm_k2-v22.4-squashfs-sysupgrade.bin)

An `initramfs-kernel.bin` image is attached to the same release for a **temporary test boot** (nothing is written to flash).

Included packages: LuCI, `kmod-batman-adv` 2023.1 (BATMAN_V/BLA/DAT/MCAST), `batctl-default`, `wpad-mesh-mbedtls`, `iw`, `kmod-mt76x2` (5GHz radio), `kmod-rt2800-soc` (2.4GHz radio).

On **first boot** the firmware automatically applies [`files/etc/uci-defaults/99-floor1-firstboot`](files/etc/uci-defaults/99-floor1-firstboot) (based on the owner's `firstboot-phicomm-k2.sh`):

- 5GHz radio → 802.11s mesh backhaul on **channel 44 / VHT80**, mesh ID `M87986`, WPA3-SAE (PMF required)
- both radios also serve open client APs `✨ADEN-NET✨-5G` / `✨ADEN-NET✨-4G` (2.4GHz on ch6/HT20) with client isolation; the stock `OpenWrt` APs are removed
- `bat0` (BATMAN_V + BLA + DAT + multicast mode) bridged into `br-lan` with STP enabled
- LAN IP `10.0.0.8/16`, default gateway and DNS `10.0.0.1`, DHCP server disabled (the MikroTik gateway is the DHCP server)
- Scheduled reboot every 6 hours (cron)

> 🔑 **Security — read before deploying:**
> - The mesh key is baked into this **public** repository and image. Change it after first login:
>   ```sh
>   uci set wireless.wifinet2.key='YOUR_REAL_KEY'
>   uci commit wireless && wifi
>   ```
> - **BATMAN_V must match on every mesh node**, including the MikroTik gateway — nodes running BATMAN_IV will not peer with it.
> - The client APs are intentionally open (`encryption none`) with client isolation — anyone in range can associate.

> ⚠️ **Hardware version warning:** this image is for K2 **v22.4 and older** hardware (flash layout `IMAGE_SIZE 7872k`). Flashing it on **v22.5 or newer** hardware can **brick** the router. Check the version sticker on the bottom of the router before flashing — the matching image for v22.5+ hardware is in the next section.

> ℹ️ **Two nodes in the same mesh:** this image and the v22.5 image below both default to management IP `10.0.0.8` (the first-boot script marks it *CHANGE PER DEVICE*). If both routers run at the same time, change the IP on one of them after first boot: `uci set network.lan.ipaddr='10.0.0.9' && uci commit network`.

> ℹ️ **About the version label:** a git-based build of the `v23.05.6` tag labels itself `r24232-539228933c` — that is `scripts/getver.sh` behaviour for tag checkouts (`r24232` is the 23.05.6 revision number). The build was verified to use the exact release commit `761ee326` and the release-pinned feeds.

### Also available — v22.5 Mesh Node (Floor1) — OpenWrt 24.10, BATMAN_V

For K2 **v22.5 and newer** hardware: release [`2026.11.12-0441`](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases/tag/2026.11.12-0441) — the identical Floor1 mesh configuration (BATMAN_V, 802.11s on 5GHz ch44/VHT80 with WPA3-SAE, Aden-Net APs, `10.0.0.8/16`) built on OpenWrt 24.10 (Linux 6.6, batman-adv 2024.3, `r29306-34fa4b1af5`). File `openwrt-ramips-mt7620-phicomm_k2-v22.5-squashfs-sysupgrade.bin` (6,882,092 bytes), SHA256 `32d5b6d1853cb75a1734751e75736ffd8a2813e644037a1e3be373bbdd1e1828`. Both builds speak the same batman-adv compat level and will mesh with each other and with the MikroTik gateway.

### Superseded builds

- [`2026.11.10-0914`](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases/tag/2026.11.10-0914) — v22.5, BATMAN_IV mesh on 2.4GHz, no client APs, management IP `10.0.0.245`. Replaced by the v22.5 build above.
- `v22.4-AMMAN` — OpenWrt 23.05.0A for K2 **v22.4 and older**, no mesh (sha256 `25e35108910a9d98707af35e105dfc636346d66839e50318122c6d358373a2df`). The release was removed automatically by the keep-3-releases policy; the firmware file is preserved in the [`firmware/`](firmware/) directory.

## ⚡ Installation

1. Download the firmware `.bin` file and verify its SHA256 checksum.
2. Coming from **stock firmware**: flash via the OEM upgrade page (do **not** keep settings).
   Coming from **OpenWrt**: `System → Backup / Flash Firmware` or `sysupgrade -v /tmp/<firmware-name>.bin` without keeping settings.
3. Prefer to test first? Boot the `initramfs` image once — it runs entirely from RAM.
4. After the reboot the router is mesh node **Floor1** — reach LuCI at `http://10.0.0.8` from the gateway side of the mesh.
5. Change the mesh key (see above), then join the 802.11s mesh from the MikroTik gateway with the same SAE key.

> ⚠️ **Warning:** Flashing the wrong firmware can brick your router. Make sure the device is the **Phicomm K2 (MT7620-based, ramips target)** and that the image matches your hardware version **before** flashing.

## ✅ Automated Tests (CI)

Every push to `main`, every pull request, and manual runs validate the Floor1 first-boot script and the build configuration **before** anything reaches a router:

| Layer | What it does | Tool |
| --- | --- | --- |
| 1. Shell syntax | the scripts parse as valid POSIX/bash shell | `sh -n` / `bash -n` |
| 2. Static analysis | catches bugs, quoting errors and bad practice | ShellCheck |
| 3. Configuration tests | BATMAN_V + BLA/DAT/multicast, mesh ID `M87986` on 5GHz ch44/VHT80, WPA3-SAE, both Aden-Net APs, bat0↔br-lan bridging with STP, management IP/gateway, DHCP disabled, cron reboot, and all essential packages still present in `.config` | [`tests/static-checks.sh`](tests/static-checks.sh) |

Files involved:

- [`tests/static-checks.sh`](tests/static-checks.sh) — layer 3 test suite (91 checks)
- [`.github/workflows/openwrt-tests.yml`](.github/workflows/openwrt-tests.yml) — the CI pipeline

These are **static** tests: they prove the configuration is internally consistent, not that the mesh actually forwards traffic. Real mesh connectivity between floors is verified on the hardware itself (`batctl p`, `batctl n`, ping through `bat0`).

## Usage

- Click the [Use this template](https://github.com/P3TERX/Actions-OpenWrt/generate) button to create a new repository.
- Generate `.config` files using the OpenWrt source code (official source is configured in the workflow file).
- Push `.config` file to the GitHub repository.
- Select `OpenWrt Builder` on the Actions page.
- Click the `Run workflow` button.
- When the build is complete, the firmware is attached to a new [Release](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases).

## Tips

- It may take a long time to create a `.config` file and build the OpenWrt firmware. Thus, before creating a repository to build your own firmware, you may check out if others have already built it to meet your needs by simply [searching `Actions-Openwrt` in GitHub](https://github.com/search?q=Actions-openwrt).
- Add some meta info of your built firmware (such as firmware architecture and installed packages) to your repository introduction — this will save others' time.

## Credits

- [Microsoft Azure](https://azure.microsoft.com)
- [GitHub Actions](https://github.com/features/actions)
- [OpenWrt](https://github.com/openwrt/openwrt)
- [P3TERX/Actions-OpenWrt](https://github.com/P3TERX/Actions-OpenWrt)
- [koalaman/shellcheck](https://github.com/koalaman/shellcheck)
- [softprops/action-gh-release](https://github.com/softprops/action-gh-release)
- [Mattraks/delete-workflow-runs](https://github.com/Mattraks/delete-workflow-runs)
- [dev-drprasad/delete-older-releases](https://github.com/dev-drprasad/delete-older-releases)
- [peter-evans/repository-dispatch](https://github.com/peter-evans/repository-dispatch)

## License

[MIT](https://github.com/P3TERX/Actions-OpenWrt/blob/main/LICENSE) © [**P3TERX**](https://p3terx.com)
