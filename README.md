**English** | [中文](https://p3terx.com/archives/build-openwrt-with-github-actions.html)

# Actions-OpenWrt — Phicomm K2

[![OpenWrt Configuration Tests](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/actions/workflows/openwrt-tests.yml/badge.svg)](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/actions/workflows/openwrt-tests.yml)
[![LICENSE](https://img.shields.io/github/license/mashape/apistatus.svg?style=flat-square&label=LICENSE)](https://github.com/P3TERX/Actions-OpenWrt/blob/master/LICENSE)

Custom OpenWrt firmware for the **Phicomm K2 (MediaTek MT7620A)** router, built with GitHub Actions from the official OpenWrt source.

## 📥 Firmware Download

All builds are available on the [Releases](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases) page.

### Current build — v22.5 Mesh Node (Floor1)

| Item | Details |
| --- | --- |
| Device profile | Phicomm K2 **v22.5 and newer** |
| Target / SoC | ramips / MediaTek MT7620A @ 580 MHz |
| OpenWrt version | 24.10 (r29306-34fa4b1af5), Linux 6.6 |
| Mesh | batman-adv 2024.3 — **BATMAN_IV + BLA**, 802.11s + **WPA3-SAE** |
| Management IP | `10.0.0.245` (DHCP off — the MikroTik gateway serves the network) |
| File | `openwrt-ramips-mt7620-phicomm_k2-v22.5-squashfs-sysupgrade.bin` (6.56 MB / 6,882,092 bytes) |
| SHA256 | `0365d35603a76cc876c907e65c84311bb78ba3c56c70ead80d3a66256929817a` |

**Direct download:** [`openwrt-ramips-mt7620-phicomm_k2-v22.5-squashfs-sysupgrade.bin`](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases/download/2026.11.10-0914/openwrt-ramips-mt7620-phicomm_k2-v22.5-squashfs-sysupgrade.bin)

An `initramfs-kernel.bin` image is attached to the same release for a **temporary test boot** (nothing is written to flash).

Included packages: LuCI, `kmod-batman-adv`, `batctl`, `wpad-mesh-mbedtls`, `iw`.

On **first boot** the firmware automatically applies [`files/etc/uci-defaults/99-mesh-floor1`](files/etc/uci-defaults/99-mesh-floor1):

- radio0 → 802.11s mesh on **channel 1 / HT20**, mesh ID `M87986`, protected with WPA3-SAE
- `bat0` (BATMAN_IV + BLA) bridged into `br-lan` with STP enabled
- LAN IP `10.0.0.245/24`, DHCP server disabled (the MikroTik gateway is the DHCP server)

> 🔑 **First login — change the mesh key** (a placeholder ships in the image):
> ```sh
> uci set wireless.mesh0.key='YOUR_REAL_KEY'
> uci commit wireless && wifi
> ```

> ⚠️ **Hardware version warning:** this image is for K2 **v22.5 and newer** hardware. Flashing it on v22.4 or older hardware can **brick** the router (different flash layout). Check the version sticker on the bottom of the router before flashing.

### Previous build — v22.4-AMMAN (OpenWrt 23.05.0A)

| Item | Details |
| --- | --- |
| Device | Phicomm K2 (v22.4 and older) |
| Target / SoC | ramips / MediaTek MT7620 |
| OpenWrt Version | 23.05.0A, Linux 5.15.134 |
| Build | v22.4-AMMAN (build 011243) |
| File Size | 7.06 MB (7,406,413 bytes) |
| SHA256 | `25e35108910a9d98707af35e105dfc636346d66839e50318122c6d358373a2df` |

**Direct download:** [`openwrt-23.05.0A-ramips-mt7620-phicomm_k2-v22.4-AMMAN-_011243.bin`](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases/download/v22.4-AMMAN/openwrt-23.05.0A-ramips-mt7620-phicomm_k2-v22.4-AMMAN-_011243.bin)

The file is also stored in the [`firmware/`](firmware/) directory of this repository.

## ⚡ Installation

1. Download the firmware `.bin` file and verify its SHA256 checksum.
2. Coming from **stock firmware**: flash via the OEM upgrade page (do **not** keep settings).
   Coming from **OpenWrt**: `System → Backup / Flash Firmware` or `sysupgrade -v /tmp/<firmware-name>.bin` without keeping settings.
3. Prefer to test first? Boot the `initramfs` image once — it runs entirely from RAM.
4. After the reboot the router is mesh node **Floor1** — reach LuCI at `http://10.0.0.245` from the gateway side of the mesh.
5. Change the mesh key (see above), then join the 802.11s mesh from the MikroTik gateway with the same SAE key.

> ⚠️ **Warning:** Flashing the wrong firmware can brick your router. Make sure the device is the **Phicomm K2 (MT7620-based, ramips target)** and that the image matches your hardware version **before** flashing.

## ✅ Automated Tests (CI)

Every push to `main`, every pull request, and manual runs validate the Floor1 first-boot script and the build configuration **before** anything reaches a router:

| Layer | What it does | Tool |
| --- | --- | --- |
| 1. Shell syntax | the scripts parse as valid POSIX/bash shell | `sh -n` / `bash -n` |
| 2. Static analysis | catches bugs, quoting errors and bad practice | ShellCheck |
| 3. Configuration tests | BATMAN_IV + BLA, mesh ID `M87986`, WPA3-SAE, fixed channel 1/HT20, bat0↔br-lan bridging with STP, management IP, DHCP disabled, and all essential packages still present in `.config` | [`tests/static-checks.sh`](tests/static-checks.sh) |

Files involved:

- [`tests/static-checks.sh`](tests/static-checks.sh) — layer 3 test suite (~35 checks)
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
