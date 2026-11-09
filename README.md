**English** | [中文](https://p3terx.com/archives/build-openwrt-with-github-actions.html)

# Actions-OpenWrt

[![LICENSE](https://img.shields.io/github/license/mashape/apistatus.svg?style=flat-square&label=LICENSE)](https://github.com/P3TERX/Actions-OpenWrt/blob/master/LICENSE)
![GitHub Stars](https://img.shields.io/github/stars/P3TERX/Actions-OpenWrt.svg?style=flat-square&label=Stars&logo=github)
![GitHub Forks](https://img.shields.io/github/forks/P3TERX/Actions-OpenWrt.svg?style=flat-square&label=Forks&logo=github)

A template for building OpenWrt with GitHub Actions

## 📥 Firmware Download

Ready-to-flash OpenWrt firmware for the **Phicomm K2 (MT7620)** router — AMMAN edition:

| Item | Details |
| --- | --- |
| Device | Phicomm K2 |
| Target / SoC | ramips / MediaTek MT7620 |
| OpenWrt Version | 23.05.0A |
| Kernel | Linux 5.15.134 |
| Build | v22.4-AMMAN (build 011243) |
| File Size | 7.06 MB (7,406,413 bytes) |
| SHA256 | `25e35108910a9d98707af35e105dfc636346d66839e50318122c6d358373a2df` |

**Direct download:**

[`openwrt-23.05.0A-ramips-mt7620-phicomm_k2-v22.4-AMMAN-_011243.bin`](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases/download/v22.4-AMMAN/openwrt-23.05.0A-ramips-mt7620-phicomm_k2-v22.4-AMMAN-_011243.bin)

The file is also stored in the [`firmware/`](firmware/) directory of this repository. All releases are available on the [Releases](https://github.com/NassarAlshabi1/phicomm_-K2_OPENWRT/releases) page.

## ⚡ Installation

1. Download the firmware `.bin` file from the link above.
2. Verify the SHA256 checksum after downloading (see table above).
3. Flash it via LuCI: `System → Backup / Flash Firmware → Upload firmware...`
   - When coming from stock firmware, do **not** keep settings.
4. Or flash via SSH/CLI: `sysupgrade -v /tmp/<firmware-name>.bin`
5. Wait for the router to reboot into OpenWrt.

> ⚠️ **Warning:** Flashing the wrong firmware can brick your router. Make sure your device is the **Phicomm K2 (MT7620-based, ramips target)** before flashing.

## Usage

- Click the [Use this template](https://github.com/P3TERX/Actions-OpenWrt/generate) button to create a new repository.
- Generate `.config` files using [Lean's OpenWrt](https://github.com/coolsnowwolf/lede) source code. ( You can change it through environment variables in the workflow file. )
- Push `.config` file to the GitHub repository.
- Select `Build OpenWrt` on the Actions page.
- Click the `Run workflow` button.
- When the build is complete, click the `Artifacts` button in the upper right corner of the Actions page to download the binaries.

## Tips

- It may take a long time to create a `.config` file and build the OpenWrt firmware. Thus, before create repository to build your own firmware, you may check out if others have already built it which meet your needs by simply [search `Actions-Openwrt` in GitHub](https://github.com/search?q=Actions-openwrt).
- Add some meta info of your built firmware (such as firmware architecture and installed packages) to your repository introduction, this will save others' time.

## Credits

- [Microsoft Azure](https://azure.microsoft.com)
- [GitHub Actions](https://github.com/features/actions)
- [OpenWrt](https://github.com/openwrt/openwrt)
- [coolsnowwolf/lede](https://github.com/coolsnowwolf/lede)
- [Mikubill/transfer](https://github.com/Mikubill/transfer)
- [softprops/action-gh-release](https://github.com/softprops/action-gh-release)
- [Mattraks/delete-workflow-runs](https://github.com/Mattraks/delete-workflow-runs)
- [dev-drprasad/delete-older-releases](https://github.com/dev-drprasad/delete-older-releases)
- [peter-evans/repository-dispatch](https://github.com/peter-evans/repository-dispatch)

## License

[MIT](https://github.com/P3TERX/Actions-OpenWrt/blob/main/LICENSE) © [**P3TERX**](https://p3terx.com)
