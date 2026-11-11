#!/bin/bash
#
# https://github.com/P3TERX/Actions-OpenWrt
# File name: diy-part1.sh
# Description: OpenWrt DIY script part 1 (Before Update feeds)
#
# Copyright (c) 2019-2024 P3TERX <https://p3terx.com>
#
# This is free software, licensed under the MIT License.
# See /LICENSE for more information.
#

# No custom feed sources are needed for this build:
# the official OpenWrt v23.05.6 feeds (routing feed provides
# kmod-batman-adv and batctl, core provides wpad-mesh-mbedtls)
# are already pinned to the exact 23.05.6 release commits.
