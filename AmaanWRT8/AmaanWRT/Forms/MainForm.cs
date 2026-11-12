using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using Guna.UI.WinForms;
using MndpTray.Protocol;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace AmaanWRT
{
public class MainForm : Form
{
        [CompilerGenerated]
        private static class nested_149
        {
                public static CallSite<Func<CallSite, object, JObject>> field_150;
        }

        [Serializable]
        [CompilerGenerated]
        private sealed class nested_151
        {
                public static readonly nested_151 field_152 = new nested_151();

                public static Func<string, bool> field_153;

                public static Func<string, bool> field_154;

                public static Func<char, bool> field_155;

                public static Func<RadioButton, bool> field_156;

                internal bool method_157(string P_0)
                {
                        return P_0.StartsWith("lldpd", StringComparison.OrdinalIgnoreCase);
                }

                internal bool method_158(string P_0)
                {
                        return P_0.StartsWith("luci-app-watchcat", StringComparison.OrdinalIgnoreCase);
                }

                internal bool method_159(char P_0)
                {
                        return P_0 == '.';
                }

                internal bool method_160(RadioButton P_0)
                {
                        return P_0.Checked;
                }
        }

        [CompilerGenerated]
        private sealed class nested_161
        {
                public GunaGradientButton field_162;

                public Color field_163;

                public Color field_164;

                public Label field_165;

                internal void method_166()
                {
                        field_162.BaseColor1 = field_163;
                        field_162.BaseColor2 = field_164;
                }

                internal void method_167()
                {
                        ((Control)field_165).BackColor = field_163;
                }
        }

        [CompilerGenerated]
        private static class nested_168
        {
                public static CallSite<Func<CallSite, object, JObject>> field_169;

                public static CallSite<Func<CallSite, object, JObject>> field_170;
        }

        private string field_171;

        private string field_172;

        private string field_173;

        public const int field_174 = 161;

        public const int field_175 = 2;

        public bool field_176 = true;

        public bool field_177;

        public bool field_178;

        public bool field_179;

        public string field_180 = "AMAAN_SOFT";

        public bool field_181 = true;

        public string field_182 = "";

        public string field_183 = "";

        public string field_184 = "";

        public string field_185 = "";

        public string field_186 = "";

        public bool field_187;

        public string field_188 = "";

        public string field_189 = "";

        public string field_190 = "";

        public JObject field_191;

        public JObject field_192;

        public List<string> field_193;

        private string field_194 = "Settings";

        private readonly string[] field_195 = new string[9]
        {
                "rm /www/luci-static/openwrt2020/GalanoGrotesqueW00-Regular.woff2",
                "sed -i 's/--base-font-size:16px/--base-font-size:14px/g' /www/luci-static/openwrt2020/cascade.css",
                "sed -i 's/linear-gradient(#333,#222)/linear-gradient(#330000,#500)/g' /www/luci-static/bootstrap/cascade.css",
                "sed -i 's/mainmenu li.selected > a{color:var(--secondary-bright-color)/mainmenu li.selected > a{font-weight:700;font-size:1.05em;background:#fff;color:var(--main-bright-color);display:inline-block;line-height:1.5em;border-radius:1em;cursor:pointer;white-space:nowrap;margin:.125em;padding:0em 0.5em 0em 0.5em;;/g' /www/luci-static/openwrt2020/cascade.css",
                "sed -i 's/.*/Amaan telecom /g' /var/sysinfo/model",
                "awk '/<span>/{flag=1; print \"<span>الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )<\\/span>\"; next} /<ul/{flag=0} !flag' /usr/share/ucode/luci/template/themes/bootstrap/footer.ut > output.html && mv output.html /usr/share/ucode/luci/template/themes/bootstrap/footer.ut",
                "awk '/<p/{flag=1; print \"<p class=\\\"luci\\\">الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a</p><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )\"; next} /</{flag=0} !flag' /usr/share/ucode/luci/template/themes/openwrt2020/footer.ut > output.html && mv output.html /usr/share/ucode/luci/template/themes/openwrt2020/footer.ut",
                "awk '/<footer>/{flag=1; print \"<footer>الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )<\\/footer>\"; next} /<ul/{flag=0} !flag' /usr/lib/lua/luci/view/themes/bootstrap/footer.htm > output.html && mv output.html /usr/share/ucode/luci/template/themes/bootstrap/footer.ut",
                "awk '/<p/{flag=1; print \"<p class=\\\"luci\\\">الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a</p><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )\"; next} /</{flag=0} !flag' /usr/lib/lua/luci/view/themes/openwrt2020/footer.htm > output.html && mv output.html /usr/lib/lua/luci/view/themes/openwrt2020/footer.htm"
        };

        private readonly string[] field_196 = new string[9]
        {
                "rm /www/luci-static/openwrt2020/GalanoGrotesqueW00-Regular.woff2",
                "sed -i 's/--base-font-size:16px/--base-font-size:14px/g' /www/luci-static/openwrt2020/cascade.css",
                "sed -i 's/linear-gradient(#333,#222)/linear-gradient(#330000,#500)/g' /www/luci-static/bootstrap/cascade.css",
                "sed -i 's/mainmenu li.selected > a{color:var(--secondary-bright-color)/mainmenu li.selected > a{font-weight:700;font-size:1.05em;background:#fff;color:var(--main-bright-color);display:inline-block;line-height:1.5em;border-radius:1em;cursor:pointer;white-space:nowrap;margin:.125em;padding:0em 0.5em 0em 0.5em;;/g' /www/luci-static/openwrt2020/cascade.css",
                "sed -i 's/.*/Amaan telecom /g' /var/sysinfo/model",
                "awk '/<span>/{flag=1; print \"<span>الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )<\\/span>\"; next} /<ul/{flag=0} !flag' /usr/share/ucode/luci/template/themes/bootstrap/footer.ut > output.html && mv output.html /usr/share/ucode/luci/template/themes/bootstrap/footer.ut",
                "awk '/<p/{flag=1; print \"<p class=\\\"luci\\\">الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a</p><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )\"; next} /</{flag=0} !flag' /usr/share/ucode/luci/template/themes/openwrt2020/footer.ut > output.html && mv output.html /usr/share/ucode/luci/template/themes/openwrt2020/footer.ut",
                "awk '/<footer>/{flag=1; print \"<footer>الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )<\\/footer>\"; next} /<ul/{flag=0} !flag' /usr/lib/lua/luci/view/themes/bootstrap/footer.htm > output.html && mv output.html /usr/share/ucode/luci/template/themes/bootstrap/footer.ut",
                "awk '/<p/{flag=1; print \"<p class=\\\"luci\\\">الجهاز مبرمج بكل فخر ببرنامج أمان ورت ❤️ بواسطة <a href=\\\"https://fb.com/amaantelcom\\\">أمان تيليكوم للخدمات التقنية</a</p><br>اليمن, صنعاء, الدائري جوار الجامعة الجديده<br>( 733996612 - 770555622 )\"; next} /</{flag=0} !flag' /usr/lib/lua/luci/view/themes/openwrt2020/footer.htm > output.html && mv output.html /usr/lib/lua/luci/view/themes/openwrt2020/footer.htm"
        };

        public AmaanSshClient field_197;

        public AmaanScpClient field_198;

        private static Thread field_199;

        private IContainer field_200;

        private GunaControlBox field_201;

        private GunaCircleButton field_202;

        private GunaGradientButton field_203;

        private GunaGroupBox field_204;

        private GunaSeparator field_205;

        private GunaTextBox field_206;

        private GunaWinCircleProgressIndicator field_207;

        private GunaPanel field_208;

        private GunaTextBox field_209;

        private GunaTextBox field_210;

        private GunaGradientButton field_211;

        private GunaGradientButton field_212;

        private GunaLabel field_213;

        private RadioButton field_214;

        private RadioButton field_215;

        private RadioButton field_216;

        private RadioButton field_217;

        private RadioButton field_218;

        private RadioButton field_219;

        private RadioButton field_220;

        private RadioButton field_221;

        private RadioButton field_222;

        private RadioButton field_223;

        private RadioButton field_224;

        private RadioButton field_225;

        private RadioButton field_226;

        private RadioButton field_227;

        private RadioButton field_228;

        private GunaButton field_229;

        private PictureBox field_230;

        private GunaElipsePanel field_231;

        private GunaPanel field_232;

        private GunaLabel field_233;

        private Label field_234;

        private Label field_235;

        private Label field_236;

        private Label field_237;

        private Label field_238;

        private Label field_239;

        private Label field_240;

        private Label field_241;

        private Label field_242;

        private Label field_243;

        private Label field_244;

        private Label field_245;

        private Label field_246;

        private Label field_247;

        private Label field_248;

        private GunaTextBox field_249;

        private GunaButton field_250;

        private GroupBox field_251;

        private Label field_252;

        private Label field_253;

        private GunaTextBox field_254;

        private GunaCheckBox field_255;

        private GroupBox field_256;

        private Label field_257;

        private Label field_258;

        private Label field_259;

        private Label field_260;

        private Label field_261;

        private Label field_262;

        private Label field_263;

        private GunaTextBox field_264;

        private GunaTextBox field_265;

        private GunaTextBox field_266;

        private GunaTextBox field_267;

        private GunaCircleButton field_268;

        private GunaCircleButton field_269;

        private GunaTextBox field_270;

        private GunaTextBox field_271;

        private GunaComboBox field_272;

        private Panel field_273;

        private LinkLabel field_274;

        private Label field_275;

        public Label field_276;

        private GunaCircleButton field_277;

        private GunaControlBox field_278;

        private GunaContextMenuStrip field_279;

        private ToolStripMenuItem field_280;

        private ToolStripMenuItem field_281;

        private ToolStripMenuItem field_282;

        private GunaButton field_283;

        private ToolTip field_284;

        private GunaCircleButton field_285;

        private GunaCircleButton field_286;

        private GunaCircleButton field_287;

        private Label field_288;

        private Label field_289;

        private GunaCheckBox field_290;

        private ToolStripMenuItem field_291;

        private GroupBox field_292;

        private GunaCheckBox field_293;

        private GunaCheckBox field_294;

        private GunaCheckBox field_295;

        private GunaCheckBox field_296;

        private GunaCheckBox field_297;

        private GunaCheckBox field_298;

        private Label field_299;

        private Label field_300;

        private Label field_301;

        private Label field_302;

        private System.Windows.Forms.Timer field_303;

        private Label field_304;

        private GunaImageRadioButton field_305;

        private GunaImageRadioButton field_306;

        private GunaSwitch field_307;

        private Label field_308;

        private Label field_309;

        private GunaCheckBox field_310;

        private GunaComboBox field_311;

        private Label field_312;

        private GroupBox field_313;

        private Label field_314;

        private GunaComboBox field_315;

        private GunaTextBox field_316;

        private Label field_317;

        private Label field_318;

        private GunaSwitch field_319;

        private GunaSwitch field_320;

        private Label field_321;

        private GunaSwitch field_322;

        private Label field_323;

        private GunaElipsePanel field_324;

        private GunaSwitch field_325;

        private Label field_326;

        private RadioButton field_327;

        private ToolStripMenuItem field_328;

        private GunaCircleButton field_329;

        private GunaCheckBox field_330;

        private GunaCircleButton field_331;

        private GunaContextMenuStrip field_332;

        private GunaTextBox field_333;

        private Label field_334;

        private Label field_335;

        private Label field_336;

        private ToolStripMenuItem field_337;

        public MainForm()
        {
                //IL_025b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0265: Expected Obj, but got Unknown
                method_421();
                ((Control)field_207).Location = new Point(257, 170);
                ((Control)field_207).Size = new Size(166, 166);
                ((ToolStripItem)field_280).Visible = false;
                Dictionary<string, string> dictionary = new Dictionary<string, string>
                {
                        {
                                "HT20",
                                "N-20"
                        },
                        {
                                "HT40",
                                "N-40"
                        },
                        {
                                "VHT20",
                                "AC-20"
                        },
                        {
                                "VHT40",
                                "AC-40"
                        },
                        {
                                "VHT80",
                                "AC-80"
                        }
                };
                ((ComboBox)field_311).DataSource = (object)new BindingSource((object)dictionary, (string)null);
                ((ListControl)field_311).DisplayMember = "Value";
                ((ListControl)field_311).ValueMember = "Key";
        }

        [DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
        public static extern bool method_338();

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int method_339(IntPtr P_0, int P_1, int P_2, int P_3);

        private void method_340(object P_0, MouseEventArgs P_1)
        {
                //IL_0001: Unknown result type (might be due to invalid IL or missing references)
                //IL_000b: Invalid comparison between Unknown and I4
                if ((int)P_1.Button == 1048576)
                {
                        method_338();
                        method_339(((Control)this).Handle, 161, 2, 0);
                }
        }

        private void method_341(object P_0, EventArgs P_1)
        {
                //IL_067f: Unknown result type (might be due to invalid IL or missing references)
                //IL_083f: Expected Obj, but got Unknown
                //IL_0850: Unknown result type (might be due to invalid IL or missing references)
                //IL_085d: Expected Obj, but got Unknown
                //IL_086e: Unknown result type (might be due to invalid IL or missing references)
                //IL_087b: Expected Obj, but got Unknown
                //IL_088c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0899: Expected Obj, but got Unknown
                //IL_08aa: Unknown result type (might be due to invalid IL or missing references)
                //IL_08c5: Unknown result type (might be due to invalid IL or missing references)
                //IL_027d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0767: Unknown result type (might be due to invalid IL or missing references)
                //IL_076e: Expected Obj, but got Unknown
                //IL_0774: Unknown result type (might be due to invalid IL or missing references)
                field_171 = ((Control)field_206).Text;
                field_172 = ((Control)field_210).Text;
                field_173 = ((Control)field_209).Text;
                try
                {
                        ((Control)field_207).Visible = true;
                        if (field_197 == null)
                        {
                                field_197 = new AmaanSshClient(field_171, field_172, field_173);
                                ((BaseClient)field_197).ConnectionInfo.Timeout = TimeSpan.FromSeconds(5.0);
                                ((BaseClient)field_197).Connect();
                                ((Control)field_229).Text = "قطع الاتصال";
                                string text = method_363("DISTRIB_RELEASE", " /etc/openwrt_release");
                                if (!text.Contains("SNAPSHOT") && !text.Contains("Chaos Calmer"))
                                {
                                        try
                                        {
                                                if (int.Parse(text.Substring(0, 2)) < 20)
                                                {
                                                        throw new Exception("عذرا ..\n يبدو ان اصدار نظام الجهاز قديم وغير مدعوم\n اصدار النظام:" + text);
                                                }
                                        }
                                        catch
                                        {
                                        }
                                }
                                ((Control)field_204).Enabled = false;
                                ((Control)field_232).Enabled = true;
                                field_229.BaseColor = Color.Green;
                                field_180 = method_357(field_204);
                                field_182 = "";
                                field_183 = "";
                                field_187 = false;
                                field_182 = method_350("2g");
                                field_183 = method_350("5g");
                                if (field_182 == "0")
                                {
                                        field_182 = method_350("2g");
                                }
                                if (field_182 == "0")
                                {
                                        field_182 = "radio0";
                                }
                                field_186 = method_351();
                                field_184 = method_372(field_182);
                                field_185 = method_372(field_183);
                                field_191 = (dynamic)field_197.method_69<object>("call system board");
                                field_193 = field_197.method_53();
                                if (field_176)
                                {
                                        ((Control)field_270).Visible = true;
                                        ((Control)field_258).Visible = true;
                                        if (method_360("wireless.wm.encryption") != "sae")
                                        {
                                                MessageBox.Show("السوفت ليس سوفت امان.. حدد موديل الجهاز");
                                        }
                                }
                                if (field_181)
                                {
                                        ((Control)field_254).Text = method_360("wireless." + field_185 + ".ssid");
                                }
                                ((Control)field_249).Text = method_360("wireless." + field_184 + ".ssid");
                                if (field_181 && !method_380(method_360("wireless.wm.disabled")))
                                {
                                        field_190 = method_360("wireless.wm.mode");
                                        if (!string.IsNullOrEmpty(field_190))
                                        {
                                                string text2 = field_190;
                                                if (text2 != null)
                                                {
                                                        if (!(text2 == "ap"))
                                                        {
                                                                if (!(text2 == "sta"))
                                                                {
                                                                        if (text2 == "mesh")
                                                                        {
                                                                                field_320.Checked = true;
                                                                                ((Control)field_271).Text = method_360("wireless.wm.mesh_id");
                                                                                ((Control)field_270).Text = method_360("wireless.wm.key");
                                                                        }
                                                                }
                                                                else
                                                                {
                                                                        field_322.Checked = true;
                                                                        ((Control)field_271).Text = method_360("wireless.wm.ssid");
                                                                        ((Control)field_270).Text = method_360("wireless.wm.key");
                                                                }
                                                        }
                                                        else
                                                        {
                                                                field_325.Checked = true;
                                                                ((Control)field_271).Text = method_360("wireless.wm.ssid");
                                                                ((Control)field_270).Text = method_360("wireless.wm.key");
                                                        }
                                                }
                                        }
                                }
                                string text3 = method_360("network.bv.ports");
                                ((Control)field_267).Text = (string.IsNullOrWhiteSpace(text3) ? "1" : Regex.Replace(text3, "[^\\d]", ""));
                                if (field_181)
                                {
                                        method_355((ComboBox)(object)field_272, method_352());
                                }
                                method_355((ComboBox)(object)field_315, method_353());
                                if (field_181)
                                {
                                        ((Control)field_272).Text = method_360("wireless." + field_183 + ".channel");
                                }
                                ((Control)field_315).Text = method_360("wireless." + field_182 + ".channel");
                                if (field_181)
                                {
                                        ((ListControl)field_311).SelectedValue = method_360("wireless." + field_183 + ".htmode");
                                }
                                if (field_181)
                                {
                                        field_319.Checked = method_380(method_360("wireless." + field_185 + ".disabled"));
                                }
                                if (field_181 && field_176)
                                {
                                        ((Control)field_270).Visible = true;
                                }
                                if (field_181 && field_176)
                                {
                                        ((Control)field_258).Visible = true;
                                }
                                try
                                {
                                        ((Control)field_266).Text = method_360("network.lan.ipaddr");
                                        ((Control)field_264).Text = method_360("system.@system[0].hostname");
                                        ((Control)field_248).Text = ((object)field_191["board_name"])?.ToString();
                                        ((Control)field_238).Text = ((object)field_191["system"])?.ToString().Replace("ver ", "").Replace("rev ", "");
                                        ((Control)field_288).Text = field_197.method_48("uname -r");
                                        ((Control)field_234).Text = method_363("DISTRIB_ARCH", " /etc/openwrt_release");
                                        ((Control)field_247).Text = method_363("DISTRIB_RELEASE", " /etc/openwrt_release");
                                        ((Control)field_236).Text = field_197.method_48("awk '/^MemTotal:/ {total=$2} /^MemAvailable:/ {used=total-$2; printf \" %.0fM/%.0fM (%.2f%)\", used/1024,total/1024, used*100/total}' /proc/meminfo");
                                        ((Control)field_237).Text = field_197.method_48("df -h / | awk 'NR==2{total=$2; used=$3; gsub(/%/,\"\", used); printf \"%s/%s (%s)\", used,total,$5}'");
                                }
                                catch (Exception ex)
                                {
                                        MessageBox.Show("خطأ.\n" + ex.Message);
                                }
                                ((Control)field_243).Visible = field_193.Any((string text4) => text4.StartsWith("lldpd", StringComparison.OrdinalIgnoreCase));
                                ((Control)field_242).Visible = field_193.Any((string text4) => text4.StartsWith("luci-app-watchcat", StringComparison.OrdinalIgnoreCase));
                                if (method_366("wpad-wolfssl") || method_366("wpad-openssl") || method_366("wpad-mbedtls") || method_366("wpad-mesh-openssl") || method_366("wpad-mesh-wolfssl"))
                                {
                                        ((Control)field_241).Visible = true;
                                }
                                else
                                {
                                        ((Control)field_241).Visible = false;
                                }
                                string[] array = new IniConfigFile().method_141();
                                if (array != null)
                                {
                                        string[] array2 = array;
                                        for (int num = 0; num < array2.Length; num++)
                                        {
                                                ToolStripMenuItem val = new ToolStripMenuItem(array2[num]);
                                                ((ToolStripItem)val).Padding = new Padding(0, 0, 0, 0);
                                                ((ToolStripItem)val).Click += method_383;
                                                ((ToolStrip)field_332).Items.Add((ToolStripItem)(object)val);
                                        }
                                }
                                Application.DoEvents();
                                Thread.Sleep(200);
                        }
                        else
                        {
                                if (field_197 != null)
                                {
                                        ((BaseClient)field_197).Disconnect();
                                        ((BaseClient)field_197).Dispose();
                                        field_197 = null;
                                }
                                ((Control)field_229).Text = "اتصال";
                                ((Control)field_204).Enabled = true;
                                ((Control)field_232).Enabled = false;
                                field_229.BaseColor = Color.Blue;
                        }
                        ((Control)field_207).Visible = false;
                        field_255.Checked = true;
                }
                catch (SshPassPhraseNullOrEmptyException ex2)
                {
                        SshPassPhraseNullOrEmptyException ex3 = ex2;
                        MessageBox.Show("حدث خطأ في احد الاستعلامات.\n" + ((Exception)(object)ex3).Message);
                }
                catch (SshAuthenticationException ex4)
                {
                        SshAuthenticationException ex5 = ex4;
                        MessageBox.Show("خطأ في اسم المستخدم او كلمة المرور.\n" + ((Exception)(object)ex5).Message);
                }
                catch (SshConnectionException ex6)
                {
                        SshConnectionException ex7 = ex6;
                        MessageBox.Show("غير قادر على الاتصال.. تحقق من البيانات.\n" + ((Exception)(object)ex7).Message);
                }
                catch (SshException ex8)
                {
                        SshException ex9 = ex8;
                        MessageBox.Show("حدث خطأ.\n" + ((Exception)(object)ex9).Message);
                }
                catch (Exception ex10)
                {
                        MessageBox.Show("خطأ.\n" + ex10.Message);
                        if (field_197 != null)
                        {
                                ((BaseClient)field_197).Disconnect();
                                ((BaseClient)field_197).Dispose();
                                field_197 = null;
                        }
                        ((Control)field_229).Text = "اتصال";
                        ((Control)field_204).Enabled = true;
                        ((Control)field_232).Enabled = false;
                        field_229.BaseColor = Color.Blue;
                }
                ((Control)field_207).Visible = false;
        }

        private void method_342(object P_0, EventArgs P_1)
        {
                ((Control)field_207).Visible = true;
                method_369("...جاري البرمجه");
                if (field_176)
                {
                        method_359("uci set wireless." + field_185 + ".ssid='" + ((Control)field_254).Text + "'");
                        method_359("uci set wireless." + field_184 + ".ssid='" + ((Control)field_249).Text + "'");
                        if (field_319.Checked)
                        {
                                method_359("uci set wireless." + field_185 + ".disabled='0'");
                        }
                        else
                        {
                                method_359("uci set wireless." + field_185 + ".disabled='1'");
                        }
                        if (field_325.Checked && field_322.Checked && field_320.Checked)
                        {
                                string text = field_188;
                                if (text != null)
                                {
                                        if (!(text == "AP_wds"))
                                        {
                                                if (!(text == "CL_wds"))
                                                {
                                                        if (text == "MESH")
                                                        {
                                                                method_359("uci set wireless.wm.mode='mesh'");
                                                                method_359("uci set wireless.wm.mesh_id='" + ((Control)field_271).Text + "'");
                                                                method_359("uci set wireless.wm.mesh_fwding='1'");
                                                                method_359("uci set wireless.wm.mesh_rssi_threshold='0'");
                                                                method_359("uci set wireless.wm.network='lan'");
                                                                if (((Control)field_270).Text.Length > 7 && ((Control)field_241).Visible)
                                                                {
                                                                        method_359("uci set wireless.wm.encryption='sae'");
                                                                        method_359("uci set wireless.wm.key='" + ((Control)field_270).Text + "'");
                                                                }
                                                                else
                                                                {
                                                                        method_359("uci set wireless.wm.encryption='none'");
                                                                        method_361("wireless.wm.key");
                                                                }
                                                        }
                                                }
                                                else
                                                {
                                                        method_359("uci set wireless.wm.mode='sta'");
                                                        method_359("uci set wireless.wm.ssid='" + ((Control)field_271).Text + "'");
                                                        method_359("uci set wireless.wm.wds='1'");
                                                        if (((Control)field_270).Text.Length > 7)
                                                        {
                                                                method_359("uci set wireless.wm.encryption='psk2'");
                                                                method_359("uci set wireless.wm.key='" + ((Control)field_270).Text + "'");
                                                        }
                                                        else
                                                        {
                                                                method_359("uci set wireless.wm.encryption='none'");
                                                                method_361("wireless.wm.key");
                                                        }
                                                }
                                        }
                                        else
                                        {
                                                method_359("uci set wireless.wm.mode='ap'");
                                                method_359("uci set wireless.wm.ssid='" + ((Control)field_271).Text + "'");
                                                method_359("uci set wireless.wm.wds='1'");
                                                if (((Control)field_270).Text.Length > 7)
                                                {
                                                        method_359("uci set wireless.wm.encryption='psk2'");
                                                        method_359("uci set wireless.wm.key='" + ((Control)field_270).Text + "'");
                                                }
                                                else
                                                {
                                                        method_359("uci set wireless.wm.encryption='none'");
                                                        method_361("wireless.wm.key");
                                                }
                                        }
                                }
                        }
                        method_361("network.bv.ports");
                        method_361("network.vl");
                        if (Convert.ToInt32(method_379(((Control)field_267).Text)) > 1)
                        {
                                method_369("برمجة الفيلان");
                                method_359("uci set network.vl=device");
                                method_359("uci set network.vl.type='8021q'");
                                method_359("uci set network.vl.ifname='br-lan'");
                                method_359("uci set network.vl.ipv6='0'");
                                method_359("uci set network.vl.multicast='0'");
                                method_359("uci set network.vl.vid='" + ((Control)field_267).Text + "'");
                                method_359("uci set network.vl.name='br-lan." + ((Control)field_267).Text + "'");
                                method_359("uci add_list network.bv.ports='br-lan." + ((Control)field_267).Text + "'");
                                method_359("uci set wireless." + field_184 + ".network='vlan'");
                                if (field_181)
                                {
                                        method_359("uci set wireless." + field_185 + ".network='vlan'");
                                }
                        }
                        else
                        {
                                method_359("uci set wireless." + field_184 + ".network='lan'");
                                if (field_181)
                                {
                                        method_359("uci set wireless." + field_185 + ".network='lan'");
                                }
                        }
                        method_359("uci set wireless." + field_183 + ".cell_density='0'");
                        method_359("uci set wireless." + field_182 + ".cell_density='0'");
                }
                else
                {
                        method_343();
                }
                method_369("استكمال الإعدادات النهائيه");
                method_359("uci set network.lan.ipaddr='" + ((Control)field_266).Text + "'");
                method_359("luci.main.mediaurlbase='/luci-static/bootstrap'");
                method_359("uci set system.@system[0].hostname='" + ((Control)field_264).Text + "'");
                method_359("uci set network.lan.hostname='amaan" + method_379(((Control)field_267).Text) + ".lan'");
                method_359("uci set system.@system[0].description='Amaan Telecom, Sanaa, Ring road (770555622-733996612)'");
                method_359("uci set system.@system[0].zonename='Asia/Aden'");
                method_359("uci set system.@system[0].timezone='<+03>-3'");
                method_359("uci set network.lan.delegate='0'");
                method_359("uci set network.vlan.delegate='0'");
                if (!string.IsNullOrEmpty(((Control)field_265).Text))
                {
                        method_358("echo -e \"" + ((Control)field_265).Text + "\\n" + ((Control)field_265).Text + "\" | passwd");
                }
                method_358("uci -q commit");
                string[] array = field_196;
                foreach (string text2 in array)
                {
                        method_358(text2);
                }
                method_358("reboot");
                ((Control)field_207).Visible = false;
                method_368("تم تعديل البرمجه واعادة تشغيل الجهاز");
                if (field_197 != null)
                {
                        ((BaseClient)field_197).Disconnect();
                        ((BaseClient)field_197).Dispose();
                        field_197 = null;
                }
                ((Control)field_229).Text = "اتصال";
                ((Control)field_204).Enabled = true;
                ((Control)field_232).Enabled = false;
        }

        private void method_343()
        {
                if (field_295.Checked)
                {
                        method_369("ايقاف DHCP4");
                        method_361("dhcp.lan.ra");
                        method_361("dhcp.lan.ra_flags");
                        method_362("dhcp.lan.ignore", "1");
                        method_361("dhcp.odhcpd");
                        method_359("uci set dhcp.lan.dynamicdhcp='0'");
                        method_358("if /etc/init.d/odhcpd enabled; then /etc/init.d/odhcpd disable; /etc/init.d/odhcpd stop; fi");
                        method_359("service odhcpd disable");
                }
                if (field_296.Checked)
                {
                        method_369("ايقاف DHCP6");
                        method_361("network.lan.ip6assign");
                        method_359("uci set network.lan.ipv6='0'");
                        method_361("dhcp.lan.dhcpv6");
                }
                Thread.Sleep(500);
                if (field_294.Checked)
                {
                        method_369("تعطيل IPv6");
                        method_359("uci set network.@device[0].ipv6='0'");
                        method_361("network.globals.ula_prefix");
                }
                method_369("حذف الاعدادات الافتراضيه");
                method_361("network.wan");
                method_361("network.wan6");
                method_361("system.ntp.enabled");
                method_361("system.ntp.enable_server");
                method_361("system.@system[0].log_proto='udp'");
                method_361("system.@system[0].conloglevel='8'");
                method_361("system.@system[0].cronloglevel='5'");
                if (field_298.Checked)
                {
                        method_369("تعطيل النات");
                        method_358("if /etc/init.d/dnsmasq enabled; then /etc/init.d/dnsmasq disable; /etc/init.d/dnsmasq stop; fi");
                        method_359("service dnsmasq disable");
                }
                if (field_297.Checked)
                {
                        method_369("تعطيل الفايروول");
                        method_361("dhcp.lan.ra_slaac");
                        method_361("firewall.@zone[0]");
                        method_361("firewall.@zone[1]");
                        method_358("if /etc/init.d/firewall enabled; then /etc/init.d/firewall disable; /etc/init.d/firewall stop; fi");
                        method_359("for j in $(seq 0 20); do uci delete firewall.@rule[0]; done");
                        method_359("service firewall disable");
                        Thread.Sleep(3000);
                }
                method_359("service log disable");
                if (field_181)
                {
                        method_369("برمجة تردد 5");
                        method_359("uci set wireless." + field_183 + ".htmode='" + ((KeyValuePair<string, string>)((ComboBox)field_311).SelectedItem).Key + "'");
                        method_359("uci set wireless." + field_183 + ".channel='" + ((Control)field_272).Text + "'");
                        method_359("uci set wireless." + field_183 + ".mu_beamformer=1");
                        method_359("uci set wireless." + field_183 + ".country='PA'");
                        method_359("uci set wireless." + field_183 + ".disabled='0'");
                        method_359("uci set wireless." + field_185 + ".mode='ap'");
                        method_359("uci set wireless." + field_185 + ".ssid='" + ((Control)field_254).Text + "'");
                        method_359("uci set wireless." + field_185 + ".encryption='none'");
                        method_359("uci set wireless." + field_185 + ".isolate=1");
                        method_359("uci set wireless." + field_185 + ".disabled='0'");
                }
                method_369("برمجة تردد 2");
                method_359("uci set wireless." + field_182 + ".country='US'");
                method_359("uci set wireless." + field_182 + ".htmode='HT20'");
                if (field_187)
                {
                        method_359("uci set wireless." + field_182 + ".band='2g'");
                }
                method_359("uci set wireless." + field_182 + ".channel='" + ((Control)field_315).Text + "'");
                method_359("uci set wireless." + field_182 + ".mu_beamformer='1'");
                method_359("uci set wireless." + field_182 + ".disabled='0'");
                method_359("uci set wireless." + field_184 + ".mode='ap'");
                method_359("uci set wireless." + field_184 + ".ssid='" + ((Control)field_249).Text + "'");
                method_359("uci set wireless." + field_184 + ".encryption='none'");
                method_359("uci set wireless." + field_184 + ".isolate='1'");
                method_359("uci set wireless." + field_184 + ".disabled='0'");
                string text = field_188;
                if (text != null)
                {
                        if (!(text == "AP_wds"))
                        {
                                if (!(text == "CL_wds"))
                                {
                                        if (text == "MESH")
                                        {
                                                method_369("برمجة الميش");
                                                method_359("uci set wireless.wm=wifi-iface");
                                                method_359("uci set wireless.wm.device='" + field_183 + "'");
                                                method_359("uci set wireless.wm.mode='mesh'");
                                                method_359("uci set wireless.wm.mesh_id='" + ((Control)field_271).Text + "'");
                                                method_359("uci set wireless.wm.mesh_fwding='1'");
                                                method_359("uci set wireless.wm.mesh_rssi_threshold='0'");
                                                method_359("uci set wireless.wm.network='lan'");
                                                if (((Control)field_270).Text.Length > 7 && ((Control)field_241).Visible)
                                                {
                                                        method_359("uci set wireless.wm.encryption='sae'");
                                                        method_359("uci set wireless.wm.key='" + ((Control)field_270).Text + "'");
                                                }
                                                else
                                                {
                                                        method_359("uci set wireless.wm.encryption='none'");
                                                        method_361("wireless.wm.key");
                                                }
                                        }
                                }
                                else
                                {
                                        method_369("برمجة الاستقبال");
                                        method_359("uci set wireless.wm=wifi-iface");
                                        method_359("uci set wireless.wm.device='" + field_183 + "'");
                                        method_359("uci set wireless.wm.mode='sta'");
                                        method_359("uci set wireless.wm.ssid='" + ((Control)field_271).Text + "'");
                                        method_359("uci set wireless.wm.wds='1'");
                                        method_359("uci set wireless.wm.network='lan'");
                                        if (((Control)field_270).Text.Length > 7)
                                        {
                                                method_359("uci set wireless.wm.encryption='psk2'");
                                                method_359("uci set wireless.wm.key='" + ((Control)field_270).Text + "'");
                                        }
                                        else
                                        {
                                                method_359("uci set wireless.wm.encryption='none'");
                                                method_361("wireless.wm.key");
                                        }
                                }
                        }
                        else
                        {
                                method_369("برمجة الارسال");
                                method_359("uci set wireless.wm=wifi-iface");
                                method_359("uci set wireless.wm.device='" + field_183 + "'");
                                method_359("uci set wireless.wm.mode='ap'");
                                method_359("uci set wireless.wm.ssid='" + ((Control)field_271).Text + "'");
                                method_359("uci set wireless.wm.wds='1'");
                                method_359("uci set wireless.wm.network='lan'");
                                if (((Control)field_270).Text.Length > 7)
                                {
                                        method_359("uci set wireless.wm.encryption='psk2'");
                                        method_359("uci set wireless.wm.key='" + ((Control)field_270).Text + "'");
                                }
                                else
                                {
                                        method_359("uci set wireless.wm.encryption='none'");
                                        method_361("wireless.wm.key");
                                }
                        }
                }
                if (field_293.Checked)
                {
                        method_369("اضافة منفذ وان للسويتش");
                        text = field_180;
                        if (text != null)
                        {
                                switch (Fnv1aHash.method_647(text))
                                {
                                case 351179688u:
                                        if (text == "K2")
                                        {
                                                method_359("uci set network.@switch_vlan[0].ports = '6t 3 2 1 0 4'");
                                                method_359("uci set network.@switch_vlan[0].vid='1'");
                                        }
                                        break;
                                case 3952275304u:
                                        if (text == "K2P")
                                        {
                                                method_359("uci del network.@device[0].ports");
                                                method_359("uci add_list network.@device[0].ports='lan1'");
                                                method_359("uci add_list network.@device[0].ports='lan2'");
                                                method_359("uci add_list network.@device[0].ports='lan3'");
                                                method_359("uci add_list network.@device[0].ports='lan4'");
                                                method_359("uci add_list network.@device[0].ports='wan'");
                                        }
                                        break;
                                case 300962980u:
                                        if (text == "KT6")
                                        {
                                                method_359("uci del network.cfg030f15.ports");
                                                method_359("uci add_list network.cfg030f15.ports='lan1'");
                                                method_359("uci add_list network.cfg030f15.ports='lan2'");
                                                method_359("uci add_list network.cfg030f15.ports='lan3'");
                                                method_359("uci add_list network.cfg030f15.ports='wan'");
                                        }
                                        break;
                                case 2608307689u:
                                        if (text == "KT412")
                                        {
                                                method_361("network.@switch_vlan[1]");
                                                method_359("uci set network.@switch_vlan[0].ports='0t 5 4 3 2 1'");
                                                method_361("network.@device[1]");
                                        }
                                        break;
                                case 1000404743u:
                                        if (text == "KT708")
                                        {
                                                method_361("network.@device[0].ports");
                                                method_359("uci add_list network.@device[0].ports='lan1'");
                                                method_359("uci add_list network.@device[0].ports='lan2'");
                                                method_359("uci add_list network.@device[0].ports='lan3'");
                                                method_359("uci add_list network.@device[0].ports='lan4'");
                                                method_359("uci add_list network.@device[0].ports='wan'");
                                        }
                                        break;
                                case 799073315u:
                                        if (text == "KT704")
                                        {
                                                method_361("network.@device[0].ports");
                                                method_359("uci add_list network.@device[0].ports='lan1'");
                                                method_359("uci add_list network.@device[0].ports='lan2'");
                                                method_359("uci add_list network.@device[0].ports='lan3'");
                                                method_359("uci add_list network.@device[0].ports='lan4'");
                                                method_359("uci add_list network.@device[0].ports='wan'");
                                        }
                                        break;
                                case 3797809473u:
                                        if (text == "KT10000")
                                        {
                                        }
                                        break;
                                case 1229256432u:
                                        if (text == "CPE210")
                                        {
                                        }
                                        break;
                                case 3679230091u:
                                        if (text == "CPE220")
                                        {
                                        }
                                        break;
                                case 2918088588u:
                                        if (text == "N2XW")
                                        {
                                        }
                                        break;
                                case 3354306682u:
                                        if (text == "N2XM")
                                        {
                                        }
                                        break;
                                case 2232733743u:
                                        if (text == "WA350")
                                        {
                                        }
                                        break;
                                case 2212950944u:
                                        if (text == "N1")
                                        {
                                        }
                                        break;
                                case 3993744721u:
                                        if (text == "GENERIC_DUAL")
                                        {
                                        }
                                        break;
                                case 150214512u:
                                        if (text == "GENERIC_2G")
                                        {
                                        }
                                        break;
                                }
                        }
                }
                if (field_330.Checked)
                {
                        method_369("ضبط الاعدادات الخاصه");
                        text = field_180;
                        if (text != null)
                        {
                                switch (Fnv1aHash.method_647(text))
                                {
                                case 351179688u:
                                        if (text == "K2")
                                        {
                                                method_359("uci set wireless." + field_184 + ".txpower='25'");
                                        }
                                        break;
                                case 3952275304u:
                                        if (text == "K2P")
                                        {
                                        }
                                        break;
                                case 300962980u:
                                        if (text == "KT6")
                                        {
                                        }
                                        break;
                                case 2608307689u:
                                        if (text == "KT412")
                                        {
                                                method_359("uci set network.@switch_vlan[0].vid='1'");
                                                method_359("uci set network.@switch[0].enable_vlan='0'");
                                                if (field_293.Checked)
                                                {
                                                        method_359("uci set network.@switch_vlan[0].ports='0 5 4 3 2 1'");
                                                }
                                                else
                                                {
                                                        method_359("uci set network.@switch_vlan[0].ports='0 5 4 3 2'");
                                                }
                                                method_361("network.@device[0].ports");
                                                method_359("uci add_list network.@device[0].ports='eth0'");
                                        }
                                        break;
                                case 1000404743u:
                                        if (text == "KT708")
                                        {
                                        }
                                        break;
                                case 799073315u:
                                        if (text == "KT704")
                                        {
                                                method_359("uci set wireless." + field_183 + ".macaddr='random'");
                                                method_359("uci set wireless." + field_182 + ".macaddr='random'");
                                        }
                                        break;
                                case 3797809473u:
                                        if (text == "KT10000")
                                        {
                                                method_361("network.@switch_vlan[1]");
                                                method_359("uci set network.@switch_vlan[0].vid='1'");
                                                method_359("uci set network.@switch[0].enable_vlan='0'");
                                                method_359("uci set network.@switch_vlan[0].ports='0 5 4 3 2 1'");
                                                method_361("network.@device[1]");
                                                method_361("network.@device[0].ports");
                                                method_359("uci add network device # =cfg0a0f15");
                                                method_359("uci set network.@device[-1].name='phy0-ap0'");
                                                method_359("uci set network.@device[-1].macaddr='" + method_412() + "'");
                                                method_359("uci add_list network.@device[0].ports='eth0'");
                                                method_359("uci add_list network.@device[0].ports='eth1'");
                                                method_359("uci set wireless." + field_183 + ".macaddr='random'");
                                                method_359("uci set wireless." + field_182 + ".macaddr='random'");
                                        }
                                        break;
                                case 1229256432u:
                                        if (text == "CPE210")
                                        {
                                        }
                                        break;
                                case 3679230091u:
                                        if (text == "CPE220")
                                        {
                                        }
                                        break;
                                case 2918088588u:
                                        if (text == "N2XW")
                                        {
                                        }
                                        break;
                                case 3354306682u:
                                        if (text == "N2XM")
                                        {
                                        }
                                        break;
                                case 2232733743u:
                                        if (text == "WA350")
                                        {
                                        }
                                        break;
                                case 2212950944u:
                                        if (text == "N1")
                                        {
                                        }
                                        break;
                                case 3993744721u:
                                        if (text == "GENERIC_DUAL")
                                        {
                                        }
                                        break;
                                case 150214512u:
                                        if (text == "GENERIC_2G")
                                        {
                                        }
                                        break;
                                }
                        }
                }
                method_359("uci commit");
                if (field_181)
                {
                        if (field_319.Checked)
                        {
                                method_362("wireless." + field_185 + ".disabled", "0");
                                method_362("wireless." + field_183 + ".cell_density", "0");
                        }
                        else
                        {
                                method_362("wireless." + field_185 + ".disabled", "1");
                        }
                }
                if (field_176)
                {
                        if (field_320.Checked)
                        {
                                method_362("wireless.wm.disabled", "0");
                                method_362("wireless." + field_183 + ".cell_density", "0");
                        }
                        else
                        {
                                method_362("wireless.wm.disabled", "1");
                        }
                }
                if (!field_197.method_58("network", "bv"))
                {
                        method_359("uci set network.bv=device");
                        method_359("uci set network.bv.type='bridge'");
                        method_359("uci set network.bv.name='br-vlan'");
                        method_359("uci set network.bv.ipv6='0'");
                }
                if (!field_197.method_58("network", "vlan"))
                {
                        method_359("uci set network.vlan=interface");
                        method_359("uci set network.vlan.proto='none'");
                        method_359("uci set network.vlan.device='br-vlan'");
                }
                method_359("uci del network.bv.ports");
                method_359("uci del network.vl");
                if (Convert.ToInt32(method_379(((Control)field_267).Text)) > 1)
                {
                        method_369("ضبط الفيلان");
                        method_359("uci set network.vl.type='8021q'");
                        method_359("uci set network.vl.ifname='br-lan'");
                        method_359("uci set network.vl.vid='" + ((Control)field_267).Text + "'");
                        method_359("uci set network.vl.name='br-lan." + ((Control)field_267).Text + "'");
                        method_359("uci add_list network.bv.ports='br-lan." + ((Control)field_267).Text + "'");
                        method_359("uci set wireless." + field_184 + ".network='vlan'");
                        if (field_181)
                        {
                                method_359("uci set wireless." + field_185 + ".network='vlan'");
                        }
                }
                else
                {
                        method_359("uci set wireless." + field_184 + ".network='lan'");
                        if (field_181)
                        {
                                method_359("uci set wireless." + field_185 + ".network='lan'");
                        }
                }
                method_359("uci set wireless." + field_183 + ".cell_density='0'");
                method_359("uci set wireless." + field_182 + ".cell_density='0'");
        }

        private void method_344(object P_0, EventArgs P_1)
        {
                if (field_181 && field_255.Checked && !string.IsNullOrEmpty(((Control)field_249).Text))
                {
                        ((Control)field_254).Text = ((Control)field_249).Text + "-5G";
                }
        }

        private void method_345(object P_0, EventArgs P_1)
        {
                string text = ((Control)field_267).Text;
                if (text == "0" || text == "1")
                {
                        ((Control)field_334).Visible = true;
                }
                else
                {
                        ((Control)field_334).Visible = false;
                }
                if (!field_290.Checked || string.IsNullOrEmpty(text))
                {
                        return;
                }
                Regex regex = new Regex("\\b(?!5g|2g)([1-3]?\\d{1,3}|[1-9]\\d{4,})\\b");
                if (field_310.Checked && int.Parse(text) > 100)
                {
                        ((Control)field_264).Text = string.Format("{0}-{1}", field_180, int.Parse(text) - 100);
                        string text2 = regex.Replace(((Control)field_249).Text, (int.Parse(text) - 100).ToString());
                        ((Control)field_249).Text = text2;
                }
                else
                {
                        ((Control)field_264).Text = field_180 + "-" + text;
                        Regex.Replace(((Control)field_249).Text, "\\d{4,}\\d", text);
                        Regex.Replace(((Control)field_249).Text, "[0-9]", text);
                        string text3 = regex.Replace(((Control)field_249).Text, text);
                        ((Control)field_249).Text = text3;
                }
                string text4 = ((Control)field_266).Text;
                try
                {
                        int num = text4.LastIndexOf('.');
                        if (num != -1 && num < text4.Length - 1)
                        {
                                string text5 = text4.Substring(0, num + 1) + text;
                                ((Control)field_266).Text = text5;
                                return;
                        }
                        throw new FormatException();
                }
                catch (FormatException)
                {
                }
                catch (Exception)
                {
                }
        }

        private void method_346(object P_0, KeyPressEventArgs P_1)
        {
                if (P_1.KeyChar != '\b')
                {
                        if (!char.IsDigit(P_1.KeyChar))
                        {
                                P_1.Handled = true;
                        }
                        if (!P_1.Handled && (!int.TryParse(((Control)field_267).Text + P_1.KeyChar, out var result) || result < 1 || result > 4000))
                        {
                                P_1.Handled = true;
                        }
                }
        }

        private void method_347(object P_0, KeyPressEventArgs P_1)
        {
                if (!char.IsDigit(P_1.KeyChar) && P_1.KeyChar != '.' && P_1.KeyChar != '\b')
                {
                        P_1.Handled = true;
                }
                if (!P_1.Handled && P_1.KeyChar == '.' && ((Control)field_266).Text.Count((char c) => c == '.') >= 3)
                {
                        P_1.Handled = true;
                }
        }

        public string method_348(string P_0)
        {
                //IL_0036: Unknown result type (might be due to invalid IL or missing references)
                try
                {
                        SshCommand val = ((SshClient)field_197).RunCommand(P_0);
                        if (val.ExitStatus == 0)
                        {
                                return val.Result.Trim();
                        }
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Error :" + ex.Message);
                }
                return "0";
        }

        public string method_349(string P_0, string P_1)
        {
                //IL_006b: Unknown result type (might be due to invalid IL or missing references)
                if (!string.IsNullOrEmpty(P_1))
                {
                        return "";
                }
                try
                {
                        SshCommand val = ((SshClient)field_197).RunCommand(P_1);
                        if (val.ExitStatus == 0)
                        {
                                string text = val.Result.Trim();
                                return text.Substring(text.LastIndexOf(P_0)).Replace(P_0, "").Replace("'", "");
                        }
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Error :" + ex.Message);
                }
                return "0";
        }

        public string method_350(string P_0)
        {
                //IL_0243: Unknown result type (might be due to invalid IL or missing references)
                string text = method_354();
                try
                {
                        if (P_0 == "2g")
                        {
                                if (method_348("uci get wireless.radio0.band") == P_0)
                                {
                                        return "radio0";
                                }
                                if (method_348("uci get wireless.radio1.band") == P_0)
                                {
                                        return "radio1";
                                }
                                if (method_348("uci get wireless.5G.band") == P_0)
                                {
                                        return "5G";
                                }
                                if (method_348("uci get wireless.2G.band") == P_0)
                                {
                                        return "2G";
                                }
                                if (method_348("uci get wireless.@wifi-device[0].band") == P_0)
                                {
                                        return "@wifi-device[0]";
                                }
                                if (method_348("uci get wireless.@wifi-device[1].band") == P_0)
                                {
                                        return "@wifi-device[1]";
                                }
                        }
                        if (P_0 == "5g")
                        {
                                string text2 = "";
                                if (method_348("uci get wireless.radio0.band") == P_0)
                                {
                                        text2 = "radio0";
                                }
                                else if (method_348("uci get wireless.radio1.band") == P_0)
                                {
                                        text2 = "radio1";
                                }
                                else if (method_348("uci get wireless.5G.band") == P_0)
                                {
                                        text2 = "5G";
                                }
                                else if (method_348("uci get wireless.2G.band") == P_0)
                                {
                                        text2 = "2G";
                                }
                                else if (method_348("uci get wireless.@wifi-device[0].band") == P_0)
                                {
                                        text2 = "@wifi-device[0]";
                                }
                                else if (method_348("uci get wireless.@wifi-device[1].band") == P_0)
                                {
                                        text2 = "@wifi-device[1]";
                                }
                                if (!string.IsNullOrEmpty(text2))
                                {
                                        if (field_182 != "0")
                                        {
                                                return text2;
                                        }
                                        field_187 = true;
                                        if (text == "0")
                                        {
                                                if (text2 == "radio0")
                                                {
                                                        return "radio1";
                                                }
                                                if (text2 == "@wifi-device[0]")
                                                {
                                                        return "@wifi-device[1]";
                                                }
                                        }
                                        if (text == "1")
                                        {
                                                if (text2 == "radio1")
                                                {
                                                        return "radio0";
                                                }
                                                if (text2 == "@wifi-device[1]")
                                                {
                                                        return "@wifi-device[0]";
                                                }
                                        }
                                        return text2;
                                }
                        }
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Error :" + ex.Message);
                }
                if (P_0 == "2g" && !string.IsNullOrEmpty(field_183))
                {
                        string result = "0";
                        if (text == "0")
                        {
                                string text3 = field_183;
                                if (text3 != null)
                                {
                                        if (!(text3 == "radio0"))
                                        {
                                                if (!(text3 == "radio1"))
                                                {
                                                        if (!(text3 == "@wifi-device[0]"))
                                                        {
                                                                if (text3 == "@wifi-device[1]")
                                                                {
                                                                        result = "@wifi-device[0]";
                                                                }
                                                        }
                                                        else
                                                        {
                                                                result = "@wifi-device[1]";
                                                        }
                                                }
                                                else
                                                {
                                                        result = "radio0";
                                                }
                                        }
                                        else
                                        {
                                                result = "radio1";
                                        }
                                }
                                return result;
                        }
                }
                return "0";
        }

        public string method_351()
        {
                //IL_003d: Unknown result type (might be due to invalid IL or missing references)
                try
                {
                        if (field_197.method_48("iw dev phy0-ap0 info | awk -F'[()]' '/channel/ {print $2}'").StartsWith("5"))
                        {
                                return "phy0";
                        }
                        return "phy1";
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Error :" + ex.Message);
                }
                return "phy1";
        }

        public string method_352()
        {
                string text = method_348("iw phy phy0 channels");
                if (text.Contains("5180"))
                {
                        return text;
                }
                return method_348("iw phy phy1 channels");
        }

        public string method_353()
        {
                string text = method_348("iw phy phy0 channels");
                if (text.Contains("2412"))
                {
                        return text;
                }
                return method_348("iw phy phy1 channels");
        }

        public string method_354()
        {
                if (method_348("iw phy phy0 channels").Contains("2412"))
                {
                        return "0";
                }
                return "1";
        }

        public static void method_355(ComboBox P_0, string P_1)
        {
                MatchCollection matchCollection = new Regex("\\[(.*?)\\]").Matches(P_1);
                P_0.Items.Clear();
                P_0.Items.Add((object)"auto");
                foreach (Match item in matchCollection)
                {
                        string value = item.Groups[1].Value;
                        P_0.Items.Add((object)value);
                }
        }

        private void method_356(object P_0, LinkLabelLinkClickedEventArgs P_1)
        {
                Process.Start(new ProcessStartInfo("https://www.facebook.com/AmaanTelcom"));
        }

        private string method_357(GunaGroupBox P_0)
        {
                return ((Control)((IEnumerable)((Control)P_0).Controls).OfType<RadioButton>().SingleOrDefault((RadioButton val) => val.Checked)).Tag.ToString();
        }

        private void method_358(string P_0)
        {
                field_197.method_52(P_0);
        }

        private void method_359(string P_0)
        {
                field_197.method_52(P_0);
        }

        private string method_360(string P_0)
        {
                return field_197.method_47(P_0);
        }

        private void method_361(string P_0)
        {
                field_197.method_64(P_0);
        }

        private void method_362(string P_0, string P_1)
        {
                field_197.method_51(P_0, P_1);
        }

        private string method_363(string P_0, string P_1)
        {
                if (field_197 != null)
                {
                        return field_197.method_49(P_0, P_1);
                }
                return "";
        }

        private bool method_364(string P_0, string P_1)
        {
                if (field_197.method_59("Section"))
                {
                        return Convert.ToBoolean(Convert.ToInt32(field_197.method_47(P_0 + "." + P_1)));
                }
                return false;
        }

        private bool method_365(string P_0)
        {
                return field_197.method_47(P_0) == "1";
        }

        private bool method_366(string P_0)
        {
                if (string.IsNullOrEmpty(field_197.method_48("opkg list-installed|grep -i " + P_0)))
                {
                        return false;
                }
                return true;
        }

        private void method_367(string P_0)
        {
                ((Control)field_276).Text = P_0;
                ((Control)field_276).BackColor = Color.Empty;
        }

        private void method_368(string P_0)
        {
                ((Control)field_276).Text = P_0;
                ((Control)field_276).BackColor = Color.Lime;
        }

        private void method_369(string P_0)
        {
                ((Control)field_276).Text = P_0;
                ((Control)field_276).BackColor = Color.Yellow;
        }

        private void method_370(string P_0)
        {
                ((Control)field_276).Text = P_0;
                ((Control)field_276).BackColor = Color.Red;
        }

        public string method_371(string P_0, string P_1)
        {
                string result = null;
                try
                {
                        JToken val = ((JToken)JObject.Parse(P_0)).SelectToken(P_1);
                        if (val != null)
                        {
                                result = ((object)val).ToString();
                        }
                }
                catch (JsonException)
                {
                        return "0";
                }
                return result;
        }

        private string method_372(string P_0)
        {
                //IL_005c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0038: Unknown result type (might be due to invalid IL or missing references)
                string text = "cat /etc/config/wireless";
                SshCommand val = ((SshClient)field_197).RunCommand(text);
                if (val.ExitStatus == 0)
                {
                        string text2 = field_197.method_70(val.Result, P_0);
                        if (text2 != null)
                        {
                                return text2;
                        }
                        MessageBox.Show("No Wi-Fi Interface found with the specified device.");
                        return "";
                }
                MessageBox.Show("Command execution failed. Exit code: " + val.ExitStatus);
                return "";
        }

        private void method_373(object P_0, EventArgs P_1)
        {
                //IL_0001: Unknown result type (might be due to invalid IL or missing references)
                if (((RadioButton)P_0).Checked)
                {
                        field_181 = true;
                        field_176 = true;
                        ((Control)field_254).Visible = true;
                        ((Control)field_253).Visible = true;
                        ((Control)field_255).Visible = true;
                        ((Control)field_319).Visible = true;
                        ((Control)field_256).Visible = true;
                        ((Control)field_292).Enabled = false;
                        ((Control)field_229).Text = "اتصال سوفت أمان";
                }
        }

        private void method_374(object P_0, EventArgs P_1)
        {
                //IL_0001: Unknown result type (might be due to invalid IL or missing references)
                //IL_0007: Expected Obj, but got Unknown
                RadioButton val = (RadioButton)P_0;
                if (val.Checked)
                {
                        field_181 = false;
                        field_176 = false;
                        ((Control)field_254).Visible = false;
                        ((Control)field_253).Visible = false;
                        field_255.Checked = false;
                        field_319.Checked = false;
                        ((Control)field_255).Visible = false;
                        ((Control)field_319).Visible = false;
                        ((Control)field_256).Visible = false;
                        ((Control)field_292).Enabled = true;
                        ((Control)field_229).Text = string.Format("{0} اتصال", ((Control)val).Tag);
                }
        }

        private void method_375(object P_0, EventArgs P_1)
        {
                //IL_0001: Unknown result type (might be due to invalid IL or missing references)
                //IL_0007: Expected Obj, but got Unknown
                RadioButton val = (RadioButton)P_0;
                if (val.Checked)
                {
                        field_181 = true;
                        field_176 = false;
                        ((Control)field_254).Visible = true;
                        ((Control)field_253).Visible = true;
                        ((Control)field_255).Visible = true;
                        ((Control)field_319).Visible = true;
                        ((Control)field_256).Visible = true;
                        ((Control)field_292).Enabled = true;
                        ((Control)field_229).Text = string.Format("{0} اتصال", ((Control)val).Tag);
                }
        }

        private void method_376(object P_0, EventArgs P_1)
        {
                ((Control)new UpgradePackagesForm()).Show();
        }

        private void method_377(object P_0, EventArgs P_1)
        {
                GunaButton val = field_283;
                Point location = ((Control)val).Location;
                int num = 0;
                int num2 = location.Y + ((Control)val).Height;
                ((ToolStripDropDown)field_279).Show((Control)(object)val, num, num2);
        }

        public static string method_379(string P_0)
        {
                if (string.IsNullOrEmpty(P_0))
                {
                        return "1";
                }
                return P_0;
        }

        public static bool method_380(object P_0)
        {
                P_0 = (P_0 ?? "").ToString().Trim().ToUpper();
                string text = (string)P_0;
                if (text != null)
                {
                        uint num = Fnv1aHash.method_647(text);
                        if (num <= 2166136261u)
                        {
                                if (num <= 890022063)
                                {
                                        if (num != 873244444)
                                        {
                                                if (num == 890022063 && text == "0")
                                                {
                                                        goto IL_017e;
                                                }
                                        }
                                        else if (text == "1")
                                        {
                                                goto IL_017c;
                                        }
                                }
                                else if (num != 1105628090)
                                {
                                        if (num != 1343949093)
                                        {
                                                if (num == 2166136261u && text != null && text.Length == 0)
                                                {
                                                        return false;
                                                }
                                        }
                                        else if (text == "TRUE")
                                        {
                                                goto IL_017c;
                                        }
                                }
                                else if (text == "NO")
                                {
                                        goto IL_017e;
                                }
                        }
                        else if (num <= 3406561745u)
                        {
                                if (num != 2471879920u)
                                {
                                        if (num != 3272340793u)
                                        {
                                                if (num == 3406561745u && text == "N")
                                                {
                                                        goto IL_017e;
                                                }
                                        }
                                        else if (text == "F")
                                        {
                                                goto IL_017e;
                                        }
                                }
                                else if (text == "YES")
                                {
                                        goto IL_017c;
                                }
                        }
                        else if (num != 3507227459u)
                        {
                                if (num != 3691781268u)
                                {
                                        if (num == 3998840952u && text == "FALSE")
                                        {
                                                goto IL_017e;
                                        }
                                }
                                else if (text == "Y")
                                {
                                        goto IL_017c;
                                }
                        }
                        else if (text == "T")
                        {
                                goto IL_017c;
                        }
                        if (double.TryParse((string)P_0, out var _))
                        {
                                return false;
                        }
                        return true;
                }
                return false;
                IL_017e:
                return true;
                IL_017c:
                return false;
        }

        public static bool method_381(object P_0)
        {
                P_0 = (P_0 ?? "").ToString().Trim().ToUpper();
                string text = (string)P_0;
                if (text != null)
                {
                        uint num = Fnv1aHash.method_647(text);
                        if (num <= 2471879920u)
                        {
                                if (num <= 1343949093)
                                {
                                        if (num != 1105628090)
                                        {
                                                if (num == 1343949093 && text == "TRUE")
                                                {
                                                        goto IL_013c;
                                                }
                                        }
                                        else if (text == "NO")
                                        {
                                                goto IL_013e;
                                        }
                                }
                                else if (num != 2166136261u)
                                {
                                        if (num == 2471879920u && text == "YES")
                                        {
                                                goto IL_013c;
                                        }
                                }
                                else if (text != null && text.Length == 0)
                                {
                                        return false;
                                }
                        }
                        else if (num <= 3406561745u)
                        {
                                if (num != 3272340793u)
                                {
                                        if (num == 3406561745u && text == "N")
                                        {
                                                goto IL_013e;
                                        }
                                }
                                else if (text == "F")
                                {
                                        goto IL_013e;
                                }
                        }
                        else if (num != 3507227459u)
                        {
                                if (num != 3691781268u)
                                {
                                        if (num == 3998840952u && text == "FALSE")
                                        {
                                                goto IL_013e;
                                        }
                                }
                                else if (text == "Y")
                                {
                                        goto IL_013c;
                                }
                        }
                        else if (text == "T")
                        {
                                goto IL_013c;
                        }
                        if (double.TryParse((string)P_0, out var _))
                        {
                                return true;
                        }
                        return false;
                }
                return false;
                IL_013c:
                return true;
                IL_013e:
                return false;
        }

        private string method_382()
        {
                //IL_0000: Unknown result type (might be due to invalid IL or missing references)
                //IL_0006: Expected Obj, but got Unknown
                //IL_0026: Unknown result type (might be due to invalid IL or missing references)
                //IL_002b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0036: Unknown result type (might be due to invalid IL or missing references)
                //IL_003e: Expected Obj, but got Unknown
                //IL_003e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0043: Unknown result type (might be due to invalid IL or missing references)
                //IL_004f: Expected Obj, but got Unknown
                //IL_004f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0054: Unknown result type (might be due to invalid IL or missing references)
                //IL_005f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0067: Expected Obj, but got Unknown
                //IL_0067: Unknown result type (might be due to invalid IL or missing references)
                //IL_006c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0077: Unknown result type (might be due to invalid IL or missing references)
                //IL_0080: Expected Obj, but got Unknown
                //IL_0130: Unknown result type (might be due to invalid IL or missing references)
                //IL_0136: Invalid comparison between Unknown and I4
                Form val = new Form();
                try
                {
                        ((Control)val).RightToLeft = (RightToLeft)1;
                        val.RightToLeftLayout = true;
                        val.StartPosition = (FormStartPosition)1;
                        ((Control)val).Text = "اسم القالب الجديد";
                        Label val2 = new Label
                        {
                                Text = "أدخل اسم القسم الجديد:",
                                AutoSize = true
                        };
                        TextBox val3 = new TextBox
                        {
                                Width = 200
                        };
                        Button val4 = new Button
                        {
                                Text = "موافق",
                                DialogResult = (DialogResult)1
                        };
                        Button val5 = new Button
                        {
                                Text = "إلغاء",
                                DialogResult = (DialogResult)2
                        };
                        ((Control)val).Controls.Add((Control)(object)val2);
                        ((Control)val).Controls.Add((Control)(object)val3);
                        ((Control)val).Controls.Add((Control)(object)val4);
                        ((Control)val).Controls.Add((Control)(object)val5);
                        ((Control)val2).Location = new Point(10, 10);
                        ((Control)val3).Location = new Point(10, ((Control)val2).Bottom + 10);
                        ((Control)val4).Location = new Point(((Control)val).Width - ((Control)val4).Width - 10, ((Control)val).Height - ((Control)val4).Height - 10);
                        ((Control)val5).Location = new Point(((Control)val4).Left - ((Control)val5).Width - 10, ((Control)val).Height - ((Control)val5).Height - 10);
                        if ((int)val.ShowDialog() == 1)
                        {
                                return ((Control)val3).Text;
                        }
                }
                finally
                {
                        ((IDisposable)val)?.Dispose();
                }
                return null;
        }

        private void method_383(object P_0, EventArgs P_1)
        {
                //IL_0001: Unknown result type (might be due to invalid IL or missing references)
                //IL_0007: Expected Obj, but got Unknown
                ToolStripMenuItem val = (ToolStripMenuItem)P_0;
                field_194 = ((ToolStripItem)val).Text;
                field_269.PerformClick();
        }

        private void method_384(object P_0, EventArgs P_1)
        {
                //IL_02eb: Unknown result type (might be due to invalid IL or missing references)
                IniConfigFile class_1634 = new IniConfigFile();
                try
                {
                        TemplateForm obj = new TemplateForm(field_194, class_1634.method_141());
                        try
                        {
                                string text = obj.method_83();
                                if (text != null)
                                {
                                        field_194 = text;
                                }
                        }
                        finally
                        {
                                ((IDisposable)obj)?.Dispose();
                        }
                }
                catch
                {
                }
                class_1634.method_136(field_194, "ssid_2g", ((Control)field_249).Text);
                class_1634.method_136(field_194, "ssid_5g", ((Control)field_254).Text);
                class_1634.method_136(field_194, "vlan", ((Control)field_267).Text);
                class_1634.method_136(field_194, "ip", ((Control)field_266).Text);
                class_1634.method_136(field_194, "meshID", ((Control)field_271).Text);
                class_1634.method_136(field_194, "meshKey", ((Control)field_270).Text);
                class_1634.method_136(field_194, "passwrd", ((Control)field_265).Text);
                class_1634.method_136(field_194, "enable_mesh", field_320.Checked.ToString());
                class_1634.method_136(field_194, "enable_5g", field_319.Checked.ToString());
                class_1634.method_136(field_194, "5G_Channel", ((Control)field_272).Text);
                class_1634.method_136(field_194, "5G_Channel_Width", ((Control)field_311).Text);
                class_1634.method_136(field_194, "auto_numbering", field_290.Checked.ToString());
                class_1634.method_136(field_194, "vlan100", field_310.Checked.ToString());
                class_1634.method_136(field_194, "wan", field_293.Checked.ToString());
                class_1634.method_136(field_194, "fix", field_330.Checked.ToString());
                class_1634.method_136(field_194, "DisFirewall", field_297.Checked.ToString());
                class_1634.method_136(field_194, "DisNat", field_298.Checked.ToString());
                class_1634.method_136(field_194, "DisIPv6", field_294.Checked.ToString());
                class_1634.method_136(field_194, "DisDHCPv4", field_295.Checked.ToString());
                class_1634.method_136(field_194, "DisDHCPv6", field_296.Checked.ToString());
                class_1634.method_136(field_194, "DisDHCPv6", field_296.Checked.ToString());
                MessageBox.Show("تم الحفظ");
        }

        private void method_385(object P_0, EventArgs P_1)
        {
                IniConfigFile class_1634 = new IniConfigFile();
                ((Control)field_249).Text = class_1634.method_137(field_194, "ssid_2g");
                ((Control)field_254).Text = class_1634.method_137(field_194, "ssid_5g");
                ((Control)field_267).Text = class_1634.method_137(field_194, "vlan");
                ((Control)field_266).Text = class_1634.method_137(field_194, "ip");
                ((Control)field_271).Text = class_1634.method_137(field_194, "meshID");
                ((Control)field_270).Text = class_1634.method_137(field_194, "meshKey");
                ((Control)field_265).Text = class_1634.method_137(field_194, "passwrd");
                field_320.Checked = method_381(class_1634.method_137(field_194, "enable_mesh"));
                field_319.Checked = method_381(class_1634.method_137(field_194, "enable_5g"));
                ((Control)field_272).Text = class_1634.method_137(field_194, "5G_Channel");
                ((Control)field_311).Text = class_1634.method_137(field_194, "5G_Channel_Width");
                field_290.Checked = method_381(class_1634.method_137(field_194, "auto_numbering"));
                field_310.Checked = method_381(class_1634.method_137(field_194, "vlan100"));
                field_293.Checked = method_381(class_1634.method_137(field_194, "wan"));
                field_330.Checked = method_381(class_1634.method_137(field_194, "fix"));
                field_297.Checked = method_381(class_1634.method_137(field_194, "DisFirewall"));
                field_298.Checked = method_381(class_1634.method_137(field_194, "DisNat"));
                field_294.Checked = method_381(class_1634.method_137(field_194, "DisIPv6"));
                field_295.Checked = method_381(class_1634.method_137(field_194, "DisDHCPv4"));
                field_296.Checked = method_381(class_1634.method_137(field_194, "DisDHCPv6"));
        }

        private void method_386(object P_0, EventArgs P_1)
        {
                ((Control)new UpgradePackagesForm(method_363("DISTRIB_ARCH", " /etc/openwrt_release"), field_193, field_171, field_172, field_173)).Show();
        }

        private void method_387(object P_0, EventArgs P_1)
        {
                //IL_0028: Unknown result type (might be due to invalid IL or missing references)
                //IL_002d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0038: Unknown result type (might be due to invalid IL or missing references)
                //IL_0043: Unknown result type (might be due to invalid IL or missing references)
                //IL_0055: Expected Obj, but got Unknown
                //IL_0056: Unknown result type (might be due to invalid IL or missing references)
                //IL_005c: Invalid comparison between Unknown and I4
                //IL_00ad: Unknown result type (might be due to invalid IL or missing references)
                //IL_00b4: Expected Obj, but got Unknown
                string text = method_360("system.@system[0].hostname") + "_" + DateTime.Now.ToString("dd-MM-yyyy_hh-mm");
                try
                {
                        SaveFileDialog val = new SaveFileDialog
                        {
                                Filter = "Tar GZ Archive (*.tar.gz)|*.tar.gz",
                                Title = "حفظ نسخه من البرمجه",
                                FileName = text + "_AmaanWRT.tar.gz"
                        };
                        if ((int)((CommonDialog)val).ShowDialog() != 1)
                        {
                                return;
                        }
                        method_369("جاري عمل النسخه الاحتياطيه");
                        string text2 = "/tmp/openwrt_backup.tar.gz";
                        string fileName = ((FileDialog)val).FileName;
                        string text3 = "sysupgrade -b " + text2;
                        if (((SshClient)field_197).RunCommand(text3).ExitStatus == 0)
                        {
                                ScpClient val2 = new ScpClient(field_171, field_172, field_173);
                                try
                                {
                                        ((BaseClient)val2).Connect();
                                        using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
                                        {
                                                val2.Download(text2, (Stream)fileStream);
                                        }
                                        ((BaseClient)val2).Disconnect();
                                }
                                finally
                                {
                                        ((IDisposable)val2)?.Dispose();
                                }
                                method_368("تم حفظ النسخه الاحتياطيه بنجاح");
                        }
                        else
                        {
                                method_370("فشل حفظ النسخه الاحتياطيه");
                        }
                }
                catch (Exception ex)
                {
                        method_370("حدث خطأ اثناء انشاء النسخه!!" + ex.ToString());
                }
        }

        private void method_388(object P_0, EventArgs P_1)
        {
                //IL_0000: Unknown result type (might be due to invalid IL or missing references)
                //IL_0006: Expected Obj, but got Unknown
                //IL_001d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0023: Invalid comparison between Unknown and I4
                //IL_004c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0052: Invalid comparison between Unknown and I4
                //IL_00fa: Unknown result type (might be due to invalid IL or missing references)
                OpenFileDialog val = new OpenFileDialog();
                ((FileDialog)val).Filter = "Tar GZ Archive (*.tar.gz)|*.tar.gz";
                ((FileDialog)val).Title = "حدد ملف النسخه الاحتياطيه";
                if ((int)((CommonDialog)val).ShowDialog() != 1)
                {
                        return;
                }
                string fileName = ((FileDialog)val).FileName;
                if ((int)MessageBox.Show("لقد اخترت الملف : \n " + ((FileDialog)val).FileName + ". \n هل تريد متابعى العمليه؟", "تأكيد الإستعاده من باكب محدد", (MessageBoxButtons)4, (MessageBoxIcon)32) != 6)
                {
                        return;
                }
                if (File.Exists(fileName))
                {
                        string text = "/tmp/backup.tar.gz";
                        method_369("جاري الرفع");
                        AmaanScpClient class_1634 = new AmaanScpClient(field_171, field_172, field_173);
                        try
                        {
                                ((BaseClient)class_1634).Connect();
                                class_1634.method_41(fileName, text);
                                method_369("جاري الرفع");
                                class_1634.method_41(fileName, text);
                                method_369("جاري الإستعاده");
                                string text2 = "sysupgrade -r " + text;
                                method_358(text2);
                                method_358("reboot");
                                ((BaseClient)class_1634).Disconnect();
                        }
                        finally
                        {
                                ((IDisposable)class_1634)?.Dispose();
                        }
                        method_368("تم عملية الاستعادة وإعادة التشغيل");
                }
                else
                {
                        MessageBox.Show("حدث خطأ اثناء محاولة الإستعادة\n يمكنك الإستعاده بشكل يدوي");
                }
        }

        private void method_389(object P_0, EventArgs P_1)
        {
                //IL_000b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0011: Invalid comparison between Unknown and I4
                if ((int)MessageBox.Show("هل انت متأكد من اعادة ضبط المصنع للجهاز؟", "تأكيد الفورمات", (MessageBoxButtons)4) == 6)
                {
                        method_369("جاري اعادة ضبط المصنع");
                        method_359("echo - e 'y\n' | firstboot && reboot");
                        method_368(" سيتم اعادة التشغيل.. تمت العمليه بنجاح");
                        if (field_197 != null)
                        {
                                ((BaseClient)field_197).Disconnect();
                                ((BaseClient)field_197).Dispose();
                                field_197 = null;
                        }
                        ((Control)field_229).Text = "اتصال";
                        ((Control)field_232).Enabled = false;
                        ((Control)field_217).Enabled = true;
                        ((Control)field_226).Enabled = true;
                }
        }

        private void method_390(object P_0, EventArgs P_1)
        {
                ((Control)new ScreenshotMessageForm(field_171, field_172, field_173)).Show();
        }

        private static void method_391(object P_0, MndpListener.DeviceDiscoveredEventArgs P_1)
        {
                //IL_000b: Unknown result type (might be due to invalid IL or missing references)
                MessageBox.Show(((object)P_1.Message).ToString());
        }

        private void method_392(object P_0, EventArgs P_1)
        {
        }

        private void method_393(object P_0, EventArgs P_1)
        {
                if (!field_307.Checked)
                {
                        method_396(field_203, field_304, Color.Black, Color.DimGray);
                        field_303.Enabled = false;
                }
                else
                {
                        field_303.Enabled = true;
                }
        }

        private void method_394(object P_0, EventArgs P_1)
        {
                if (!string.IsNullOrEmpty(((Control)field_206).Text) && field_307.Checked && (field_199 == null || !field_199.IsAlive))
                {
                        field_199 = new Thread(() =>
                        {
                                method_395(((Control)field_206).Text, field_203, field_304);
                        });
                        field_199.Start();
                }
        }

        private static void method_395(string P_0, GunaGradientButton P_1, Label P_2)
        {
                Ping ping = new Ping();
                try
                {
                        if (ping.Send(P_0).Status == IPStatus.Success)
                        {
                                method_396(P_1, P_2, Color.Lime, Color.Green);
                        }
                        else
                        {
                                method_396(P_1, P_2, Color.Maroon, Color.Red);
                        }
                }
                catch (Exception)
                {
                        method_396(P_1, P_2, Color.Black, Color.DimGray);
                }
        }

        private static void method_396(GunaGradientButton P_0, Label P_1, Color P_2, Color P_3)
        {
                try
                {
                        if (P_0 != null && P_1 != null)
                        {
                                ((Control)P_0).BeginInvoke((Delegate)(Action)(() =>
                                {
                                        P_0.BaseColor1 = P_2;
                                        P_0.BaseColor2 = P_3;
                                }));
                                ((Control)P_1).BeginInvoke((Delegate)(Action)(() =>
                                {
                                        ((Control)P_1).BackColor = P_2;
                                }));
                        }
                }
                catch
                {
                        field_199.Abort();
                }
        }

        private void method_397(object P_0, FormClosingEventArgs P_1)
        {
                field_307.Checked = false;
                field_303.Enabled = false;
                field_199.Abort();
        }

        private void method_398(object P_0, EventArgs P_1)
        {
                method_369("جاري الرفع");
                new AmaanScpClient(((Control)field_206).Text, ((Control)field_210).Text, ((Control)field_209).Text).method_41("luci-theme-argon.ipk", "/tmp");
                method_368("تم الرفع");
                method_367("");
        }

        private void method_399(object P_0, EventArgs P_1)
        {
                //IL_0038: Unknown result type (might be due to invalid IL or missing references)
                string[] array = new string[3]
                {
                        "cat /etc/openwrt_release | grep DISTRIB_ID",
                        "cat /proc/cpuinfo | grep 'model name'",
                        "df -h"
                };
                foreach (string text in array)
                {
                        MessageBox.Show(((SshClient)field_197).CreateCommand(text).Execute());
                }
        }

        public string method_400(string P_0, string P_1)
        {
                //IL_003c: Unknown result type (might be due to invalid IL or missing references)
                try
                {
                        string text = "grep -oP '(?<=" + P_1 + " = ).*' " + P_0;
                        return ((SshClient)field_197).CreateCommand(text).Result.Trim();
                }
                catch (Exception ex)
                {
                        MessageBox.Show("Error occurred while retrieving config value: " + ex.Message);
                        return null;
                }
        }

        private void method_401(object P_0, EventArgs P_1)
        {
                string text = "";
                string text2 = field_197.method_46("network", "lan", "hostname");
                text += "\n\n_________________________________________ \n";
                text = text + "GetOptionValue('network.lan.hostname')\n " + text2;
                string text3 = field_197.method_49("DISTRIB_TARGET", "/etc/openwrt_release");
                text += "\n\n_________________________________________ \n";
                text = text + "GrepOptionValue('DISTRIB_TARGET', '/etc/openwrt_release')\n " + text3;
                field_197.method_50("network", "lan", "hostname", "test SetOptionValue");
                text += "\n\n_________________________________________ \n";
                text += "SetOptionValue(network.lan.hostname='test SetOptionValue')\n";
                List<string> list = field_197.method_53();
                text += "\n\n_________________________________________ \n";
                text += "ListPackages: \n";
                foreach (string item in list)
                {
                        text = text + item + ", ";
                }
                string text4 = field_197.method_46("network", "lan", "hostname");
                text += "\n\n_________________________________________ \n";
                text = text + "GetOptionValue('network.lan.hostname')\n " + text4;
                Dictionary<string, string> dictionary = field_197.method_54("network", "lan");
                text += "\n\n_________________________________________ \n";
                text += "ListOptions('network', 'lan') \n";
                foreach (KeyValuePair<string, string> item2 in dictionary)
                {
                        text = text + "ListOptions: " + item2.Key + ": " + item2.Value + " \n";
                }
                field_197.method_56("network", "TestSection");
                text += "\n\n_________________________________________ \n";
                text += "AddSection('network', 'TestSection') \n";
                List<string> list2 = field_197.method_55("network");
                text += "\n\n_________________________________________ \n";
                text += "ListSections('network'):";
                foreach (string item3 in list2)
                {
                        text = text + "\n " + item3 + ", ";
                }
                field_197.method_57("network", "TestSection");
                text += "\n\n_________________________________________ \n";
                text += "DeleteSection('network', 'TestSection') \n";
                bool flag = field_197.method_58("network", "TestSection");
                text += "\n\n_________________________________________ \n";
                text += string.Format("SectionExists('network', 'TestSection') result= {0}", flag);
                field_197.method_56("network", "TestSec2");
                text += "\n\n_________________________________________ \n";
                text += "AddSection('network', 'TestSec2') \n";
                field_197.method_60("network", "TestSec2", "newSection");
                text += "\n\n_________________________________________ \n";
                text += "RenameSection('network', 'TestSec2', 'newSection') \n";
                bool flag2 = field_197.method_58("network", "newSection");
                text += "\n\n_________________________________________ \n";
                text += string.Format("SectionExists('network', 'newSection') result= {0}", flag2);
                field_197.method_61("network", "lan", "opt");
                text += "\n\n_________________________________________ \n";
                text += "AddOption('network', 'lan', 'opt') \n";
                bool flag3 = field_197.method_58("network", "lan.opt");
                text += "\n\n_________________________________________ \n";
                text += string.Format("Test for option exist \n SectionExists('network', 'lan.opt') result= {0}", flag3);
                field_197.method_62("network", "lan", "opt", "newOpt");
                text += "\n\n_________________________________________ \n";
                text += "\n RenameOption('network', 'lan', 'opt', 'newOpt') \n";
                bool flag4 = field_197.method_58("network", "lan.newOpt");
                text += "\n\n_________________________________________ \n";
                text += string.Format("Test for option exist \n SectionExists('network', 'lan.newOpt') result= {0}", flag4);
                field_197.method_63("network", "lan", "newOpt");
                text += "\n\n_________________________________________ \n";
                text += "DeleteOption('network', 'lan', 'opt', 'newOpt') \n";
                string text5 = "";
                dynamic val = field_197.method_69<object>("call system board");
                text += "\n\n_________________________________________ \n";
                text += "ExecuteUbusCommand<dynamic>('call system board') \n";
                try
                {
                        text += (object)(JObject)val;
                        text5 = ((object)(JObject)val)?.ToString();
                }
                catch (Exception ex)
                {
                        text = text + "ExecuteUbusCommand error \n " + ex.ToString();
                }
                text += "\n\n_________________________________________ \n";
                text = text + method_371(text5, "release.description") + ",   " + method_371(text5, "system");
                string text6 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "output.txt");
                File.WriteAllText(text6, text);
                Process.Start(text6);
        }

        private void method_402(object P_0, EventArgs P_1)
        {
                if (field_265.PasswordChar == '\0')
                {
                        field_265.PasswordChar = '●';
                        field_209.PasswordChar = '●';
                        field_305.Checked = false;
                        field_306.Checked = false;
                }
                else
                {
                        field_265.PasswordChar = '\0';
                        field_209.PasswordChar = '\0';
                        field_305.Checked = true;
                        field_306.Checked = true;
                }
        }

        private void method_403(object P_0, EventArgs P_1)
        {
                Process.Start("CMD.exe", "/C ping -t " + ((Control)field_206).Text);
        }

        private void method_404(object P_0, EventArgs P_1)
        {
                ((Control)field_308).ForeColor = Color.Red;
        }

        private void method_405(object P_0, EventArgs P_1)
        {
                ((Control)field_308).ForeColor = Color.DimGray;
        }

        private void method_406(object P_0, EventArgs P_1)
        {
                ((Control)new AboutForm()).Show();
        }

        private void method_407(object P_0, EventArgs P_1)
        {
                ((Form)this).Close();
        }

        private void method_408(object P_0, EventArgs P_1)
        {
                if (field_290.Checked)
                {
                        ((Control)field_310).Visible = true;
                }
                else
                {
                        ((Control)field_310).Visible = false;
                }
        }

        private void method_409(object P_0, EventArgs P_1)
        {
                //IL_0001: Unknown result type (might be due to invalid IL or missing references)
                //IL_0007: Expected Obj, but got Unknown
                GunaSwitch val = (GunaSwitch)P_0;
                string name = ((Control)val).Name;
                if (name == null)
                {
                        return;
                }
                if (!(name == "cb_WDS_AP_Enable"))
                {
                        if (!(name == "cb_WDS_Client_Enable"))
                        {
                                if (!(name == "cb_Mesh_Enable") || !val.Checked)
                                {
                                        return;
                                }
                                field_325.Checked = false;
                                field_322.Checked = false;
                                ((Control)field_259).Text = "اسم مجموعة الميش";
                                field_188 = "MESH";
                                if (((Control)field_241).Visible)
                                {
                                        field_189 = "sae";
                                        ((Control)field_270).Enabled = true;
                                        if (string.IsNullOrEmpty(((Control)field_270).Text))
                                        {
                                                ((Control)field_336).Visible = true;
                                        }
                                        ((Control)field_336).Text = "مفتوح (بدون رمز)";
                                }
                                else
                                {
                                        field_189 = "";
                                        ((Control)field_270).Text = "";
                                        ((Control)field_270).Enabled = false;
                                        if (string.IsNullOrEmpty(((Control)field_270).Text))
                                        {
                                                ((Control)field_336).Visible = true;
                                        }
                                        ((Control)field_336).Text = "لايدعم الحمايه برمز";
                                }
                                field_284.SetToolTip((Control)(object)field_271, "اسم مجموعة الميش\r\nالاجهزه المرتبطه بخاصية الميش يجب ان تكون كلها مبرمجه بنفس اسم الميش وكلمة المرور\r\nوواحد من الاجهزه يتم توصيله بسلك والبقيه سترتبط تلقائيا ببعضها مع الجهاز الرئيسي\r\nالمسافه بين كل جهاز وآخر يجب ان لاتزيد عن 200 متر");
                        }
                        else if (val.Checked)
                        {
                                field_320.Checked = false;
                                field_325.Checked = false;
                                ((Control)field_259).Text = "اسم شبكة المرسل";
                                ((Control)field_270).Visible = true;
                                ((Control)field_258).Visible = true;
                                field_188 = "CL_wds";
                                field_189 = "psk2";
                                ((Control)field_270).Enabled = true;
                                if (string.IsNullOrEmpty(((Control)field_270).Text))
                                {
                                        ((Control)field_336).Text = "مفتوح (بدون رمز)";
                                }
                                field_284.SetToolTip((Control)(object)field_271, "اسم المرسله التي سيرتبط منها الجهاز - يجب ان يكون الأسم مطابقا تماما");
                        }
                }
                else if (val.Checked)
                {
                        field_320.Checked = false;
                        field_322.Checked = false;
                        ((Control)field_259).Text = "اسم شبكة المرسل";
                        ((Control)field_270).Visible = true;
                        ((Control)field_258).Visible = true;
                        field_188 = "AP_wds";
                        field_189 = "psk2";
                        ((Control)field_270).Enabled = true;
                        if (string.IsNullOrEmpty(((Control)field_270).Text))
                        {
                                ((Control)field_336).Text = "مفتوح (بدون رمز)";
                        }
                        field_284.SetToolTip((Control)(object)field_271, " اسم شبكة الإرسال\r\nيفضل البرمجه بإسم قصير يدل على اسم شبكتك واضافة رقم الأكسس \r\nمثلا اذا كان اسم الأكسس AmaanTelecom-6 فيمكن تسمية شبكة الارسال am6 ليسهل حفظ الإسم عند برمجة المستقبلات\r\n");
                }
        }

        private void method_410(object P_0, EventArgs P_1)
        {
        }

        public static string method_411(string P_0)
        {
                StringBuilder stringBuilder = new StringBuilder(P_0);
                stringBuilder.Replace(newValue: new Random().Next(65536, 1048576).ToString("X4"), oldValue: "A6:D6");
                return stringBuilder.ToString();
        }

        public static string method_412()
        {
                byte[] array = new byte[6];
                new Random().NextBytes(array);
                array[0] |= 2;
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < array.Length; i++)
                {
                        stringBuilder.Append(array[i].ToString("X2"));
                        if (i < array.Length - 1)
                        {
                                stringBuilder.Append(":");
                        }
                }
                return stringBuilder.ToString();
        }

        private void method_413(object P_0, EventArgs P_1)
        {
                ((Control)new IpInstallerForm()).Show();
        }

        private void method_414(object P_0, EventArgs P_1)
        {
        }

        private void method_415(object P_0, EventArgs P_1)
        {
                ((Control)field_206).Text = "192.168.1.1";
                ((Control)field_209).Text = "";
        }

        private void method_416(object P_0, EventArgs P_1)
        {
                field_307.Checked = false;
                field_303.Enabled = false;
                field_199.Abort();
        }

        private void method_417(object P_0, EventArgs P_1)
        {
                ((Control)field_206).Text = ((Control)field_266).Text;
                ((Control)field_209).Text = ((Control)field_265).Text;
        }

        private void method_418(object P_0, EventArgs P_1)
        {
                GunaCircleButton val = field_331;
                int num = ((Control)val).Location.X + ((Control)val).Width;
                int num2 = 0;
                ((ToolStripDropDown)field_332).Show((Control)(object)val, num, num2);
        }

        private void method_419(object P_0, EventArgs P_1)
        {
                if (string.IsNullOrEmpty(((Control)field_270).Text))
                {
                        ((Control)field_336).Text = "مفتوح (بدون رمز)";
                }
                else if (((Control)field_270).Text.Length > 7)
                {
                        ((Control)field_336).Visible = false;
                        ((Control)field_270).ForeColor = Color.Black;
                        field_270.FocusedForeColor = Color.Black;
                }
                else
                {
                        ((Control)field_336).Visible = true;
                        ((Control)field_336).Text = "خطأ 8 احرف على الأقل";
                        ((Control)field_270).ForeColor = Color.Red;
                        field_270.FocusedForeColor = Color.Red;
                }
        }

        private void method_420(object P_0, EventArgs P_1)
        {
                if (((Control)field_316).Text.Length > 7)
                {
                        ((Control)field_335).Visible = false;
                }
                else
                {
                        ((Control)field_335).Visible = true;
                }
        }

        protected override void Dispose(bool P_0)
        {
                if (P_0 && field_200 != null)
                {
                        field_200.Dispose();
                }
                base.Dispose(P_0);
        }

        private void method_421()
        {
                //IL_001c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0026: Expected Obj, but got Unknown
                //IL_0027: Unknown result type (might be due to invalid IL or missing references)
                //IL_0031: Expected Obj, but got Unknown
                //IL_0032: Unknown result type (might be due to invalid IL or missing references)
                //IL_003c: Expected Obj, but got Unknown
                //IL_003d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0047: Expected Obj, but got Unknown
                //IL_0048: Unknown result type (might be due to invalid IL or missing references)
                //IL_0052: Expected Obj, but got Unknown
                //IL_0053: Unknown result type (might be due to invalid IL or missing references)
                //IL_005d: Expected Obj, but got Unknown
                //IL_005e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0068: Expected Obj, but got Unknown
                //IL_0069: Unknown result type (might be due to invalid IL or missing references)
                //IL_0073: Expected Obj, but got Unknown
                //IL_0074: Unknown result type (might be due to invalid IL or missing references)
                //IL_007e: Expected Obj, but got Unknown
                //IL_007f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0089: Expected Obj, but got Unknown
                //IL_008a: Unknown result type (might be due to invalid IL or missing references)
                //IL_0094: Expected Obj, but got Unknown
                //IL_0095: Unknown result type (might be due to invalid IL or missing references)
                //IL_009f: Expected Obj, but got Unknown
                //IL_00a0: Unknown result type (might be due to invalid IL or missing references)
                //IL_00aa: Expected Obj, but got Unknown
                //IL_00ab: Unknown result type (might be due to invalid IL or missing references)
                //IL_00b5: Expected Obj, but got Unknown
                //IL_00b6: Unknown result type (might be due to invalid IL or missing references)
                //IL_00c0: Expected Obj, but got Unknown
                //IL_00c1: Unknown result type (might be due to invalid IL or missing references)
                //IL_00cb: Expected Obj, but got Unknown
                //IL_00cc: Unknown result type (might be due to invalid IL or missing references)
                //IL_00d6: Expected Obj, but got Unknown
                //IL_00d7: Unknown result type (might be due to invalid IL or missing references)
                //IL_00e1: Expected Obj, but got Unknown
                //IL_00e2: Unknown result type (might be due to invalid IL or missing references)
                //IL_00ec: Expected Obj, but got Unknown
                //IL_00ed: Unknown result type (might be due to invalid IL or missing references)
                //IL_00f7: Expected Obj, but got Unknown
                //IL_00f8: Unknown result type (might be due to invalid IL or missing references)
                //IL_0102: Expected Obj, but got Unknown
                //IL_0103: Unknown result type (might be due to invalid IL or missing references)
                //IL_010d: Expected Obj, but got Unknown
                //IL_010e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0118: Expected Obj, but got Unknown
                //IL_0119: Unknown result type (might be due to invalid IL or missing references)
                //IL_0123: Expected Obj, but got Unknown
                //IL_0124: Unknown result type (might be due to invalid IL or missing references)
                //IL_012e: Expected Obj, but got Unknown
                //IL_012f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0139: Expected Obj, but got Unknown
                //IL_013a: Unknown result type (might be due to invalid IL or missing references)
                //IL_0144: Expected Obj, but got Unknown
                //IL_0145: Unknown result type (might be due to invalid IL or missing references)
                //IL_014f: Expected Obj, but got Unknown
                //IL_0150: Unknown result type (might be due to invalid IL or missing references)
                //IL_015a: Expected Obj, but got Unknown
                //IL_015b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0165: Expected Obj, but got Unknown
                //IL_0166: Unknown result type (might be due to invalid IL or missing references)
                //IL_0170: Expected Obj, but got Unknown
                //IL_0171: Unknown result type (might be due to invalid IL or missing references)
                //IL_017b: Expected Obj, but got Unknown
                //IL_017c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0186: Expected Obj, but got Unknown
                //IL_0187: Unknown result type (might be due to invalid IL or missing references)
                //IL_0191: Expected Obj, but got Unknown
                //IL_0192: Unknown result type (might be due to invalid IL or missing references)
                //IL_019c: Expected Obj, but got Unknown
                //IL_019d: Unknown result type (might be due to invalid IL or missing references)
                //IL_01a7: Expected Obj, but got Unknown
                //IL_01a8: Unknown result type (might be due to invalid IL or missing references)
                //IL_01b2: Expected Obj, but got Unknown
                //IL_01b3: Unknown result type (might be due to invalid IL or missing references)
                //IL_01bd: Expected Obj, but got Unknown
                //IL_01be: Unknown result type (might be due to invalid IL or missing references)
                //IL_01c8: Expected Obj, but got Unknown
                //IL_01c9: Unknown result type (might be due to invalid IL or missing references)
                //IL_01d3: Expected Obj, but got Unknown
                //IL_01d4: Unknown result type (might be due to invalid IL or missing references)
                //IL_01de: Expected Obj, but got Unknown
                //IL_01df: Unknown result type (might be due to invalid IL or missing references)
                //IL_01e9: Expected Obj, but got Unknown
                //IL_01ea: Unknown result type (might be due to invalid IL or missing references)
                //IL_01f4: Expected Obj, but got Unknown
                //IL_01f5: Unknown result type (might be due to invalid IL or missing references)
                //IL_01ff: Expected Obj, but got Unknown
                //IL_0200: Unknown result type (might be due to invalid IL or missing references)
                //IL_020a: Expected Obj, but got Unknown
                //IL_020b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0215: Expected Obj, but got Unknown
                //IL_0216: Unknown result type (might be due to invalid IL or missing references)
                //IL_0220: Expected Obj, but got Unknown
                //IL_0221: Unknown result type (might be due to invalid IL or missing references)
                //IL_022b: Expected Obj, but got Unknown
                //IL_022c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0236: Expected Obj, but got Unknown
                //IL_0237: Unknown result type (might be due to invalid IL or missing references)
                //IL_0241: Expected Obj, but got Unknown
                //IL_0242: Unknown result type (might be due to invalid IL or missing references)
                //IL_024c: Expected Obj, but got Unknown
                //IL_024d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0257: Expected Obj, but got Unknown
                //IL_0258: Unknown result type (might be due to invalid IL or missing references)
                //IL_0262: Expected Obj, but got Unknown
                //IL_0263: Unknown result type (might be due to invalid IL or missing references)
                //IL_026d: Expected Obj, but got Unknown
                //IL_026e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0278: Expected Obj, but got Unknown
                //IL_0279: Unknown result type (might be due to invalid IL or missing references)
                //IL_0283: Expected Obj, but got Unknown
                //IL_0284: Unknown result type (might be due to invalid IL or missing references)
                //IL_028e: Expected Obj, but got Unknown
                //IL_028f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0299: Expected Obj, but got Unknown
                //IL_029a: Unknown result type (might be due to invalid IL or missing references)
                //IL_02a4: Expected Obj, but got Unknown
                //IL_02a5: Unknown result type (might be due to invalid IL or missing references)
                //IL_02af: Expected Obj, but got Unknown
                //IL_02b0: Unknown result type (might be due to invalid IL or missing references)
                //IL_02ba: Expected Obj, but got Unknown
                //IL_02bb: Unknown result type (might be due to invalid IL or missing references)
                //IL_02c5: Expected Obj, but got Unknown
                //IL_02c6: Unknown result type (might be due to invalid IL or missing references)
                //IL_02d0: Expected Obj, but got Unknown
                //IL_02d1: Unknown result type (might be due to invalid IL or missing references)
                //IL_02db: Expected Obj, but got Unknown
                //IL_02dc: Unknown result type (might be due to invalid IL or missing references)
                //IL_02e6: Expected Obj, but got Unknown
                //IL_02e7: Unknown result type (might be due to invalid IL or missing references)
                //IL_02f1: Expected Obj, but got Unknown
                //IL_02f2: Unknown result type (might be due to invalid IL or missing references)
                //IL_02fc: Expected Obj, but got Unknown
                //IL_02fd: Unknown result type (might be due to invalid IL or missing references)
                //IL_0307: Expected Obj, but got Unknown
                //IL_0308: Unknown result type (might be due to invalid IL or missing references)
                //IL_0312: Expected Obj, but got Unknown
                //IL_0313: Unknown result type (might be due to invalid IL or missing references)
                //IL_031d: Expected Obj, but got Unknown
                //IL_031e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0328: Expected Obj, but got Unknown
                //IL_0329: Unknown result type (might be due to invalid IL or missing references)
                //IL_0333: Expected Obj, but got Unknown
                //IL_0334: Unknown result type (might be due to invalid IL or missing references)
                //IL_033e: Expected Obj, but got Unknown
                //IL_033f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0349: Expected Obj, but got Unknown
                //IL_034a: Unknown result type (might be due to invalid IL or missing references)
                //IL_0354: Expected Obj, but got Unknown
                //IL_0355: Unknown result type (might be due to invalid IL or missing references)
                //IL_035f: Expected Obj, but got Unknown
                //IL_0360: Unknown result type (might be due to invalid IL or missing references)
                //IL_036a: Expected Obj, but got Unknown
                //IL_036b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0375: Expected Obj, but got Unknown
                //IL_0376: Unknown result type (might be due to invalid IL or missing references)
                //IL_0380: Expected Obj, but got Unknown
                //IL_0381: Unknown result type (might be due to invalid IL or missing references)
                //IL_038b: Expected Obj, but got Unknown
                //IL_038c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0396: Expected Obj, but got Unknown
                //IL_0397: Unknown result type (might be due to invalid IL or missing references)
                //IL_03a1: Expected Obj, but got Unknown
                //IL_03a2: Unknown result type (might be due to invalid IL or missing references)
                //IL_03ac: Expected Obj, but got Unknown
                //IL_03ad: Unknown result type (might be due to invalid IL or missing references)
                //IL_03b7: Expected Obj, but got Unknown
                //IL_03b8: Unknown result type (might be due to invalid IL or missing references)
                //IL_03c2: Expected Obj, but got Unknown
                //IL_03c3: Unknown result type (might be due to invalid IL or missing references)
                //IL_03cd: Expected Obj, but got Unknown
                //IL_03ce: Unknown result type (might be due to invalid IL or missing references)
                //IL_03d8: Expected Obj, but got Unknown
                //IL_03d9: Unknown result type (might be due to invalid IL or missing references)
                //IL_03e3: Expected Obj, but got Unknown
                //IL_03e4: Unknown result type (might be due to invalid IL or missing references)
                //IL_03ee: Expected Obj, but got Unknown
                //IL_03ef: Unknown result type (might be due to invalid IL or missing references)
                //IL_03f9: Expected Obj, but got Unknown
                //IL_03fa: Unknown result type (might be due to invalid IL or missing references)
                //IL_0404: Expected Obj, but got Unknown
                //IL_0405: Unknown result type (might be due to invalid IL or missing references)
                //IL_040f: Expected Obj, but got Unknown
                //IL_0410: Unknown result type (might be due to invalid IL or missing references)
                //IL_041a: Expected Obj, but got Unknown
                //IL_041b: Unknown result type (might be due to invalid IL or missing references)
                //IL_0425: Expected Obj, but got Unknown
                //IL_0426: Unknown result type (might be due to invalid IL or missing references)
                //IL_0430: Expected Obj, but got Unknown
                //IL_0431: Unknown result type (might be due to invalid IL or missing references)
                //IL_043b: Expected Obj, but got Unknown
                //IL_043c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0446: Expected Obj, but got Unknown
                //IL_0447: Unknown result type (might be due to invalid IL or missing references)
                //IL_0451: Expected Obj, but got Unknown
                //IL_0452: Unknown result type (might be due to invalid IL or missing references)
                //IL_045c: Expected Obj, but got Unknown
                //IL_045d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0467: Expected Obj, but got Unknown
                //IL_0468: Unknown result type (might be due to invalid IL or missing references)
                //IL_0472: Expected Obj, but got Unknown
                //IL_0473: Unknown result type (might be due to invalid IL or missing references)
                //IL_047d: Expected Obj, but got Unknown
                //IL_047e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0488: Expected Obj, but got Unknown
                //IL_0489: Unknown result type (might be due to invalid IL or missing references)
                //IL_0493: Expected Obj, but got Unknown
                //IL_0494: Unknown result type (might be due to invalid IL or missing references)
                //IL_049e: Expected Obj, but got Unknown
                //IL_049f: Unknown result type (might be due to invalid IL or missing references)
                //IL_04a9: Expected Obj, but got Unknown
                //IL_04aa: Unknown result type (might be due to invalid IL or missing references)
                //IL_04b4: Expected Obj, but got Unknown
                //IL_04b5: Unknown result type (might be due to invalid IL or missing references)
                //IL_04bf: Expected Obj, but got Unknown
                //IL_04c0: Unknown result type (might be due to invalid IL or missing references)
                //IL_04ca: Expected Obj, but got Unknown
                //IL_04cb: Unknown result type (might be due to invalid IL or missing references)
                //IL_04d5: Expected Obj, but got Unknown
                //IL_04d6: Unknown result type (might be due to invalid IL or missing references)
                //IL_04e0: Expected Obj, but got Unknown
                //IL_04e1: Unknown result type (might be due to invalid IL or missing references)
                //IL_04eb: Expected Obj, but got Unknown
                //IL_04ec: Unknown result type (might be due to invalid IL or missing references)
                //IL_04f6: Expected Obj, but got Unknown
                //IL_04f7: Unknown result type (might be due to invalid IL or missing references)
                //IL_0501: Expected Obj, but got Unknown
                //IL_0502: Unknown result type (might be due to invalid IL or missing references)
                //IL_050c: Expected Obj, but got Unknown
                //IL_050d: Unknown result type (might be due to invalid IL or missing references)
                //IL_0517: Expected Obj, but got Unknown
                //IL_0518: Unknown result type (might be due to invalid IL or missing references)
                //IL_0522: Expected Obj, but got Unknown
                //IL_0523: Unknown result type (might be due to invalid IL or missing references)
                //IL_052d: Expected Obj, but got Unknown
                //IL_052e: Unknown result type (might be due to invalid IL or missing references)
                //IL_0538: Expected Obj, but got Unknown
                //IL_0539: Unknown result type (might be due to invalid IL or missing references)
                //IL_0543: Expected Obj, but got Unknown
                //IL_0544: Unknown result type (might be due to invalid IL or missing references)
                //IL_054e: Expected Obj, but got Unknown
                //IL_054f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0559: Expected Obj, but got Unknown
                //IL_055a: Unknown result type (might be due to invalid IL or missing references)
                //IL_0564: Expected Obj, but got Unknown
                //IL_0565: Unknown result type (might be due to invalid IL or missing references)
                //IL_056f: Expected Obj, but got Unknown
                //IL_0576: Unknown result type (might be due to invalid IL or missing references)
                //IL_0580: Expected Obj, but got Unknown
                //IL_0581: Unknown result type (might be due to invalid IL or missing references)
                //IL_058b: Expected Obj, but got Unknown
                //IL_058c: Unknown result type (might be due to invalid IL or missing references)
                //IL_0596: Expected Obj, but got Unknown
                //IL_059d: Unknown result type (might be due to invalid IL or missing references)
                //IL_05a7: Expected Obj, but got Unknown
                //IL_05a8: Unknown result type (might be due to invalid IL or missing references)
                //IL_05b2: Expected Obj, but got Unknown
                //IL_05b3: Unknown result type (might be due to invalid IL or missing references)
                //IL_05bd: Expected Obj, but got Unknown
                //IL_05be: Unknown result type (might be due to invalid IL or missing references)
                //IL_05c8: Expected Obj, but got Unknown
                //IL_05c9: Unknown result type (might be due to invalid IL or missing references)
                //IL_05d3: Expected Obj, but got Unknown
                //IL_05d4: Unknown result type (might be due to invalid IL or missing references)
                //IL_05de: Expected Obj, but got Unknown
                //IL_05df: Unknown result type (might be due to invalid IL or missing references)
                //IL_05e9: Expected Obj, but got Unknown
                //IL_05ea: Unknown result type (might be due to invalid IL or missing references)
                //IL_05f4: Expected Obj, but got Unknown
                //IL_05f5: Unknown result type (might be due to invalid IL or missing references)
                //IL_05ff: Expected Obj, but got Unknown
                //IL_0600: Unknown result type (might be due to invalid IL or missing references)
                //IL_060a: Expected Obj, but got Unknown
                //IL_09e6: Unknown result type (might be due to invalid IL or missing references)
                //IL_09f0: Expected Obj, but got Unknown
                //IL_0aa4: Unknown result type (might be due to invalid IL or missing references)
                //IL_0aae: Expected Obj, but got Unknown
                //IL_0b65: Unknown result type (might be due to invalid IL or missing references)
                //IL_0b6f: Expected Obj, but got Unknown
                //IL_0c23: Unknown result type (might be due to invalid IL or missing references)
                //IL_0c2d: Expected Obj, but got Unknown
                //IL_0cf0: Unknown result type (might be due to invalid IL or missing references)
                //IL_0cfa: Expected Obj, but got Unknown
                //IL_0dbe: Unknown result type (might be due to invalid IL or missing references)
                //IL_0dc8: Expected Obj, but got Unknown
                //IL_0e7f: Unknown result type (might be due to invalid IL or missing references)
                //IL_0e89: Expected Obj, but got Unknown
                //IL_0f41: Unknown result type (might be due to invalid IL or missing references)
                //IL_0f4b: Expected Obj, but got Unknown
                //IL_1005: Unknown result type (might be due to invalid IL or missing references)
                //IL_100f: Expected Obj, but got Unknown
                //IL_10c9: Unknown result type (might be due to invalid IL or missing references)
                //IL_10d3: Expected Obj, but got Unknown
                //IL_1196: Unknown result type (might be due to invalid IL or missing references)
                //IL_11a0: Expected Obj, but got Unknown
                //IL_1254: Unknown result type (might be due to invalid IL or missing references)
                //IL_125e: Expected Obj, but got Unknown
                //IL_1315: Unknown result type (might be due to invalid IL or missing references)
                //IL_131f: Expected Obj, but got Unknown
                //IL_13d6: Unknown result type (might be due to invalid IL or missing references)
                //IL_13e0: Expected Obj, but got Unknown
                //IL_14a0: Unknown result type (might be due to invalid IL or missing references)
                //IL_14aa: Expected Obj, but got Unknown
                //IL_155e: Unknown result type (might be due to invalid IL or missing references)
                //IL_1568: Expected Obj, but got Unknown
                //IL_175f: Unknown result type (might be due to invalid IL or missing references)
                //IL_1769: Expected Obj, but got Unknown
                //IL_1a8b: Unknown result type (might be due to invalid IL or missing references)
                //IL_1a95: Expected Obj, but got Unknown
                //IL_1ac2: Unknown result type (might be due to invalid IL or missing references)
                //IL_1baf: Unknown result type (might be due to invalid IL or missing references)
                //IL_1bb9: Expected Obj, but got Unknown
                //IL_1d66: Unknown result type (might be due to invalid IL or missing references)
                //IL_1d70: Expected Obj, but got Unknown
                //IL_1ef3: Unknown result type (might be due to invalid IL or missing references)
                //IL_1efd: Expected Obj, but got Unknown
                //IL_2045: Unknown result type (might be due to invalid IL or missing references)
                //IL_204f: Expected Obj, but got Unknown
                //IL_2121: Unknown result type (might be due to invalid IL or missing references)
                //IL_212b: Expected Obj, but got Unknown
                //IL_2248: Unknown result type (might be due to invalid IL or missing references)
                //IL_2252: Expected Obj, but got Unknown
                //IL_250e: Unknown result type (might be due to invalid IL or missing references)
                //IL_2518: Expected Obj, but got Unknown
                //IL_2549: Unknown result type (might be due to invalid IL or missing references)
                //IL_25d9: Unknown result type (might be due to invalid IL or missing references)
                //IL_25e3: Expected Obj, but got Unknown
                //IL_2614: Unknown result type (might be due to invalid IL or missing references)
                //IL_268a: Unknown result type (might be due to invalid IL or missing references)
                //IL_2694: Expected Obj, but got Unknown
                //IL_26c5: Unknown result type (might be due to invalid IL or missing references)
                //IL_2755: Unknown result type (might be due to invalid IL or missing references)
                //IL_275f: Expected Obj, but got Unknown
                //IL_2790: Unknown result type (might be due to invalid IL or missing references)
                //IL_2806: Unknown result type (might be due to invalid IL or missing references)
                //IL_2810: Expected Obj, but got Unknown
                //IL_2841: Unknown result type (might be due to invalid IL or missing references)
                //IL_28c6: Unknown result type (might be due to invalid IL or missing references)
                //IL_28d0: Expected Obj, but got Unknown
                //IL_2901: Unknown result type (might be due to invalid IL or missing references)
                //IL_2986: Unknown result type (might be due to invalid IL or missing references)
                //IL_2990: Expected Obj, but got Unknown
                //IL_29c1: Unknown result type (might be due to invalid IL or missing references)
                //IL_2a45: Unknown result type (might be due to invalid IL or missing references)
                //IL_2a4f: Expected Obj, but got Unknown
                //IL_2a80: Unknown result type (might be due to invalid IL or missing references)
                //IL_2b01: Unknown result type (might be due to invalid IL or missing references)
                //IL_2b0b: Expected Obj, but got Unknown
                //IL_2b3c: Unknown result type (might be due to invalid IL or missing references)
                //IL_2bbd: Unknown result type (might be due to invalid IL or missing references)
                //IL_2bc7: Expected Obj, but got Unknown
                //IL_2bf5: Unknown result type (might be due to invalid IL or missing references)
                //IL_2c82: Unknown result type (might be due to invalid IL or missing references)
                //IL_2c8c: Expected Obj, but got Unknown
                //IL_2cba: Unknown result type (might be due to invalid IL or missing references)
                //IL_2d47: Unknown result type (might be due to invalid IL or missing references)
                //IL_2d51: Expected Obj, but got Unknown
                //IL_2d7f: Unknown result type (might be due to invalid IL or missing references)
                //IL_2e0c: Unknown result type (might be due to invalid IL or missing references)
                //IL_2e16: Expected Obj, but got Unknown
                //IL_2e47: Unknown result type (might be due to invalid IL or missing references)
                //IL_2ec8: Unknown result type (might be due to invalid IL or missing references)
                //IL_2ed2: Expected Obj, but got Unknown
                //IL_2f03: Unknown result type (might be due to invalid IL or missing references)
                //IL_2f84: Unknown result type (might be due to invalid IL or missing references)
                //IL_2f8e: Expected Obj, but got Unknown
                //IL_2fbf: Unknown result type (might be due to invalid IL or missing references)
                //IL_3035: Unknown result type (might be due to invalid IL or missing references)
                //IL_303f: Expected Obj, but got Unknown
                //IL_3070: Unknown result type (might be due to invalid IL or missing references)
                //IL_30f5: Unknown result type (might be due to invalid IL or missing references)
                //IL_30ff: Expected Obj, but got Unknown
                //IL_3130: Unknown result type (might be due to invalid IL or missing references)
                //IL_33d8: Unknown result type (might be due to invalid IL or missing references)
                //IL_33e2: Expected Obj, but got Unknown
                //IL_357a: Unknown result type (might be due to invalid IL or missing references)
                //IL_3584: Expected Obj, but got Unknown
                //IL_36ec: Unknown result type (might be due to invalid IL or missing references)
                //IL_36f6: Expected Obj, but got Unknown
                //IL_38e6: Unknown result type (might be due to invalid IL or missing references)
                //IL_38f0: Expected Obj, but got Unknown
                //IL_3911: Unknown result type (might be due to invalid IL or missing references)
                //IL_3a29: Unknown result type (might be due to invalid IL or missing references)
                //IL_3a33: Expected Obj, but got Unknown
                //IL_3a54: Unknown result type (might be due to invalid IL or missing references)
                //IL_3ac9: Unknown result type (might be due to invalid IL or missing references)
                //IL_3ad3: Expected Obj, but got Unknown
                //IL_3af1: Unknown result type (might be due to invalid IL or missing references)
                //IL_3bdf: Unknown result type (might be due to invalid IL or missing references)
                //IL_3be9: Expected Obj, but got Unknown
                //IL_3ccb: Unknown result type (might be due to invalid IL or missing references)
                //IL_3cd5: Expected Obj, but got Unknown
                //IL_3d6b: Unknown result type (might be due to invalid IL or missing references)
                //IL_3d75: Expected Obj, but got Unknown
                //IL_3e41: Unknown result type (might be due to invalid IL or missing references)
                //IL_3e4b: Expected Obj, but got Unknown
                //IL_3ee1: Unknown result type (might be due to invalid IL or missing references)
                //IL_3eeb: Expected Obj, but got Unknown
                //IL_3fc3: Unknown result type (might be due to invalid IL or missing references)
                //IL_3fcd: Expected Obj, but got Unknown
                //IL_3fee: Unknown result type (might be due to invalid IL or missing references)
                //IL_40df: Unknown result type (might be due to invalid IL or missing references)
                //IL_40e9: Expected Obj, but got Unknown
                //IL_41c9: Unknown result type (might be due to invalid IL or missing references)
                //IL_41d3: Expected Obj, but got Unknown
                //IL_420b: Unknown result type (might be due to invalid IL or missing references)
                //IL_431f: Unknown result type (might be due to invalid IL or missing references)
                //IL_4329: Expected Obj, but got Unknown
                //IL_43d1: Unknown result type (might be due to invalid IL or missing references)
                //IL_43db: Expected Obj, but got Unknown
                //IL_4408: Unknown result type (might be due to invalid IL or missing references)
                //IL_44ed: Unknown result type (might be due to invalid IL or missing references)
                //IL_44f7: Expected Obj, but got Unknown
                //IL_46b8: Unknown result type (might be due to invalid IL or missing references)
                //IL_46c2: Expected Obj, but got Unknown
                //IL_47af: Unknown result type (might be due to invalid IL or missing references)
                //IL_47b9: Expected Obj, but got Unknown
                //IL_47da: Unknown result type (might be due to invalid IL or missing references)
                //IL_485c: Unknown result type (might be due to invalid IL or missing references)
                //IL_4866: Expected Obj, but got Unknown
                //IL_4887: Unknown result type (might be due to invalid IL or missing references)
                //IL_494c: Unknown result type (might be due to invalid IL or missing references)
                //IL_4956: Expected Obj, but got Unknown
                //IL_4a81: Unknown result type (might be due to invalid IL or missing references)
                //IL_4a8b: Expected Obj, but got Unknown
                //IL_4c26: Unknown result type (might be due to invalid IL or missing references)
                //IL_4c30: Expected Obj, but got Unknown
                //IL_4dcb: Unknown result type (might be due to invalid IL or missing references)
                //IL_4dd5: Expected Obj, but got Unknown
                //IL_5052: Unknown result type (might be due to invalid IL or missing references)
                //IL_505c: Expected Obj, but got Unknown
                //IL_51d0: Unknown result type (might be due to invalid IL or missing references)
                //IL_51da: Expected Obj, but got Unknown
                //IL_520b: Unknown result type (might be due to invalid IL or missing references)
                //IL_542b: Unknown result type (might be due to invalid IL or missing references)
                //IL_5435: Expected Obj, but got Unknown
                //IL_5465: Unknown result type (might be due to invalid IL or missing references)
                //IL_554a: Unknown result type (might be due to invalid IL or missing references)
                //IL_5554: Expected Obj, but got Unknown
                //IL_567a: Unknown result type (might be due to invalid IL or missing references)
                //IL_5684: Expected Obj, but got Unknown
                //IL_56b5: Unknown result type (might be due to invalid IL or missing references)
                //IL_5742: Unknown result type (might be due to invalid IL or missing references)
                //IL_574c: Expected Obj, but got Unknown
                //IL_577d: Unknown result type (might be due to invalid IL or missing references)
                //IL_5862: Unknown result type (might be due to invalid IL or missing references)
                //IL_586c: Expected Obj, but got Unknown
                //IL_59bc: Unknown result type (might be due to invalid IL or missing references)
                //IL_59c6: Expected Obj, but got Unknown
                //IL_5b43: Unknown result type (might be due to invalid IL or missing references)
                //IL_5b4d: Expected Obj, but got Unknown
                //IL_5c2d: Unknown result type (might be due to invalid IL or missing references)
                //IL_5c37: Expected Obj, but got Unknown
                //IL_5c58: Unknown result type (might be due to invalid IL or missing references)
                //IL_5cda: Unknown result type (might be due to invalid IL or missing references)
                //IL_5ce4: Expected Obj, but got Unknown
                //IL_5d02: Unknown result type (might be due to invalid IL or missing references)
                //IL_5d84: Unknown result type (might be due to invalid IL or missing references)
                //IL_5d8e: Expected Obj, but got Unknown
                //IL_5daf: Unknown result type (might be due to invalid IL or missing references)
                //IL_5e9b: Unknown result type (might be due to invalid IL or missing references)
                //IL_5ea5: Expected Obj, but got Unknown
                //IL_603d: Unknown result type (might be due to invalid IL or missing references)
                //IL_6047: Expected Obj, but got Unknown
                //IL_6206: Unknown result type (might be due to invalid IL or missing references)
                //IL_6210: Expected Obj, but got Unknown
                //IL_62d3: Unknown result type (might be due to invalid IL or missing references)
                //IL_62dd: Expected Obj, but got Unknown
                //IL_636e: Unknown result type (might be due to invalid IL or missing references)
                //IL_6378: Expected Obj, but got Unknown
                //IL_63a9: Unknown result type (might be due to invalid IL or missing references)
                //IL_6561: Unknown result type (might be due to invalid IL or missing references)
                //IL_656b: Expected Obj, but got Unknown
                //IL_6656: Unknown result type (might be due to invalid IL or missing references)
                //IL_6660: Expected Obj, but got Unknown
                //IL_6691: Unknown result type (might be due to invalid IL or missing references)
                //IL_6722: Unknown result type (might be due to invalid IL or missing references)
                //IL_672c: Expected Obj, but got Unknown
                //IL_675a: Unknown result type (might be due to invalid IL or missing references)
                //IL_6854: Unknown result type (might be due to invalid IL or missing references)
                //IL_685e: Expected Obj, but got Unknown
                //IL_69bd: Unknown result type (might be due to invalid IL or missing references)
                //IL_69c7: Expected Obj, but got Unknown
                //IL_6b7e: Unknown result type (might be due to invalid IL or missing references)
                //IL_6b88: Expected Obj, but got Unknown
                //IL_6d37: Unknown result type (might be due to invalid IL or missing references)
                //IL_6d41: Expected Obj, but got Unknown
                //IL_6e3c: Unknown result type (might be due to invalid IL or missing references)
                //IL_6e46: Expected Obj, but got Unknown
                //IL_6f26: Unknown result type (might be due to invalid IL or missing references)
                //IL_6f30: Expected Obj, but got Unknown
                //IL_701c: Unknown result type (might be due to invalid IL or missing references)
                //IL_7026: Expected Obj, but got Unknown
                //IL_70fc: Unknown result type (might be due to invalid IL or missing references)
                //IL_7106: Expected Obj, but got Unknown
                //IL_71d9: Unknown result type (might be due to invalid IL or missing references)
                //IL_71e3: Expected Obj, but got Unknown
                //IL_72b6: Unknown result type (might be due to invalid IL or missing references)
                //IL_72c0: Expected Obj, but got Unknown
                //IL_7396: Unknown result type (might be due to invalid IL or missing references)
                //IL_73a0: Expected Obj, but got Unknown
                //IL_74b4: Unknown result type (might be due to invalid IL or missing references)
                //IL_74be: Expected Obj, but got Unknown
                //IL_75d2: Unknown result type (might be due to invalid IL or missing references)
                //IL_75dc: Expected Obj, but got Unknown
                //IL_7653: Unknown result type (might be due to invalid IL or missing references)
                //IL_765d: Expected Obj, but got Unknown
                //IL_7771: Unknown result type (might be due to invalid IL or missing references)
                //IL_777b: Expected Obj, but got Unknown
                //IL_77ab: Unknown result type (might be due to invalid IL or missing references)
                //IL_7830: Unknown result type (might be due to invalid IL or missing references)
                //IL_783a: Expected Obj, but got Unknown
                //IL_786a: Unknown result type (might be due to invalid IL or missing references)
                //IL_7905: Unknown result type (might be due to invalid IL or missing references)
                //IL_790f: Expected Obj, but got Unknown
                //IL_793f: Unknown result type (might be due to invalid IL or missing references)
                //IL_79da: Unknown result type (might be due to invalid IL or missing references)
                //IL_79e4: Expected Obj, but got Unknown
                //IL_7a11: Unknown result type (might be due to invalid IL or missing references)
                //IL_7a32: Unknown result type (might be due to invalid IL or missing references)
                //IL_7aa6: Unknown result type (might be due to invalid IL or missing references)
                //IL_7ab0: Expected Obj, but got Unknown
                //IL_7b6a: Unknown result type (might be due to invalid IL or missing references)
                //IL_7b74: Expected Obj, but got Unknown
                //IL_7ba4: Unknown result type (might be due to invalid IL or missing references)
                //IL_7e5f: Unknown result type (might be due to invalid IL or missing references)
                //IL_7e69: Expected Obj, but got Unknown
                //IL_7ee8: Unknown result type (might be due to invalid IL or missing references)
                //IL_7ef2: Expected Obj, but got Unknown
                //IL_824c: Unknown result type (might be due to invalid IL or missing references)
                //IL_8256: Expected Obj, but got Unknown
                //IL_835d: Unknown result type (might be due to invalid IL or missing references)
                //IL_8367: Expected Obj, but got Unknown
                //IL_8398: Unknown result type (might be due to invalid IL or missing references)
                //IL_8474: Unknown result type (might be due to invalid IL or missing references)
                //IL_847e: Expected Obj, but got Unknown
                //IL_84b5: Unknown result type (might be due to invalid IL or missing references)
                //IL_852d: Unknown result type (might be due to invalid IL or missing references)
                //IL_8537: Expected Obj, but got Unknown
                //IL_86b3: Unknown result type (might be due to invalid IL or missing references)
                //IL_86bd: Expected Obj, but got Unknown
                //IL_87c5: Unknown result type (might be due to invalid IL or missing references)
                //IL_87cf: Expected Obj, but got Unknown
                //IL_88bb: Unknown result type (might be due to invalid IL or missing references)
                //IL_88c5: Expected Obj, but got Unknown
                //IL_89fd: Unknown result type (might be due to invalid IL or missing references)
                //IL_8a07: Expected Obj, but got Unknown
                //IL_8a35: Unknown result type (might be due to invalid IL or missing references)
                //IL_8aad: Unknown result type (might be due to invalid IL or missing references)
                //IL_8ab7: Expected Obj, but got Unknown
                //IL_8ae5: Unknown result type (might be due to invalid IL or missing references)
                //IL_8b4e: Unknown result type (might be due to invalid IL or missing references)
                //IL_8b58: Expected Obj, but got Unknown
                //IL_8d0c: Unknown result type (might be due to invalid IL or missing references)
                //IL_8d16: Expected Obj, but got Unknown
                //IL_8d49: Unknown result type (might be due to invalid IL or missing references)
                //IL_8d53: Expected Obj, but got Unknown
                //IL_8d6d: Unknown result type (might be due to invalid IL or missing references)
                //IL_8d77: Expected Obj, but got Unknown
                field_200 = new Container();
                ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof(MainForm));
                field_201 = new GunaControlBox();
                field_204 = new GunaGroupBox();
                field_327 = new RadioButton();
                field_214 = new RadioButton();
                field_215 = new RadioButton();
                field_216 = new RadioButton();
                field_217 = new RadioButton();
                field_218 = new RadioButton();
                field_219 = new RadioButton();
                field_220 = new RadioButton();
                field_221 = new RadioButton();
                field_222 = new RadioButton();
                field_223 = new RadioButton();
                field_224 = new RadioButton();
                field_225 = new RadioButton();
                field_226 = new RadioButton();
                field_227 = new RadioButton();
                field_228 = new RadioButton();
                field_205 = new GunaSeparator();
                field_206 = new GunaTextBox();
                field_207 = new GunaWinCircleProgressIndicator();
                field_208 = new GunaPanel();
                field_306 = new GunaImageRadioButton();
                field_304 = new Label();
                field_211 = new GunaGradientButton();
                field_212 = new GunaGradientButton();
                field_203 = new GunaGradientButton();
                field_213 = new GunaLabel();
                field_209 = new GunaTextBox();
                field_210 = new GunaTextBox();
                field_231 = new GunaElipsePanel();
                field_288 = new Label();
                field_289 = new Label();
                field_234 = new Label();
                field_235 = new Label();
                field_236 = new Label();
                field_237 = new Label();
                field_238 = new Label();
                field_239 = new Label();
                field_240 = new Label();
                field_241 = new Label();
                field_242 = new Label();
                field_243 = new Label();
                field_244 = new Label();
                field_245 = new Label();
                field_246 = new Label();
                field_247 = new Label();
                field_248 = new Label();
                field_232 = new GunaPanel();
                field_331 = new GunaCircleButton();
                field_329 = new GunaCircleButton();
                field_310 = new GunaCheckBox();
                field_324 = new GunaElipsePanel();
                field_262 = new Label();
                field_305 = new GunaImageRadioButton();
                field_261 = new Label();
                field_260 = new Label();
                field_267 = new GunaTextBox();
                field_266 = new GunaTextBox();
                field_264 = new GunaTextBox();
                field_263 = new Label();
                field_265 = new GunaTextBox();
                field_334 = new Label();
                field_313 = new GroupBox();
                field_314 = new Label();
                field_315 = new GunaComboBox();
                field_316 = new GunaTextBox();
                field_317 = new Label();
                field_318 = new Label();
                field_290 = new GunaCheckBox();
                field_268 = new GunaCircleButton();
                field_287 = new GunaCircleButton();
                field_286 = new GunaCircleButton();
                field_256 = new GroupBox();
                field_325 = new GunaSwitch();
                field_326 = new Label();
                field_320 = new GunaSwitch();
                field_322 = new GunaSwitch();
                field_323 = new Label();
                field_311 = new GunaComboBox();
                field_312 = new Label();
                field_299 = new Label();
                field_272 = new GunaComboBox();
                field_270 = new GunaTextBox();
                field_271 = new GunaTextBox();
                field_257 = new Label();
                field_258 = new Label();
                field_259 = new Label();
                field_285 = new GunaCircleButton();
                field_269 = new GunaCircleButton();
                field_251 = new GroupBox();
                field_255 = new GunaCheckBox();
                field_253 = new Label();
                field_319 = new GunaSwitch();
                field_254 = new GunaTextBox();
                field_321 = new Label();
                field_252 = new Label();
                field_249 = new GunaTextBox();
                field_250 = new GunaButton();
                field_202 = new GunaCircleButton();
                field_292 = new GroupBox();
                field_330 = new GunaCheckBox();
                field_293 = new GunaCheckBox();
                field_294 = new GunaCheckBox();
                field_295 = new GunaCheckBox();
                field_296 = new GunaCheckBox();
                field_297 = new GunaCheckBox();
                field_298 = new GunaCheckBox();
                field_277 = new GunaCircleButton();
                field_233 = new GunaLabel();
                field_273 = new Panel();
                field_300 = new Label();
                field_301 = new Label();
                field_302 = new Label();
                field_276 = new Label();
                field_274 = new LinkLabel();
                field_275 = new Label();
                field_278 = new GunaControlBox();
                field_279 = new GunaContextMenuStrip();
                field_291 = new ToolStripMenuItem();
                field_328 = new ToolStripMenuItem();
                field_280 = new ToolStripMenuItem();
                field_281 = new ToolStripMenuItem();
                field_282 = new ToolStripMenuItem();
                field_284 = new ToolTip(field_200);
                field_307 = new GunaSwitch();
                field_333 = new GunaTextBox();
                field_303 = new System.Windows.Forms.Timer(field_200);
                field_308 = new Label();
                field_309 = new Label();
                field_332 = new GunaContextMenuStrip();
                field_283 = new GunaButton();
                field_230 = new PictureBox();
                field_229 = new GunaButton();
                field_336 = new Label();
                field_335 = new Label();
                field_337 = new ToolStripMenuItem();
                ((Control)field_204).SuspendLayout();
                ((Control)field_208).SuspendLayout();
                ((Control)field_231).SuspendLayout();
                ((Control)field_232).SuspendLayout();
                ((Control)field_324).SuspendLayout();
                ((Control)field_313).SuspendLayout();
                ((Control)field_256).SuspendLayout();
                ((Control)field_251).SuspendLayout();
                ((Control)field_292).SuspendLayout();
                ((Control)field_273).SuspendLayout();
                ((Control)field_279).SuspendLayout();
                ((ISupportInitialize)field_230).BeginInit();
                ((Control)this).SuspendLayout();
                ((Control)field_201).Anchor = (AnchorStyles)9;
                field_201.AnimationHoverSpeed = 0.07f;
                field_201.AnimationSpeed = 0.03f;
                ((Control)field_201).BackColor = Color.Red;
                field_201.IconColor = Color.White;
                field_201.IconSize = 15f;
                ((Control)field_201).Location = new Point(6, 3);
                ((Control)field_201).Name = "gunaControlBox1";
                field_201.OnHoverBackColor = Color.FromArgb(103, 58, 183);
                field_201.OnHoverIconColor = Color.White;
                field_201.OnPressedColor = Color.Black;
                ((Control)field_201).Size = new Size(25, 25);
                ((Control)field_201).TabIndex = 1;
                ((Control)field_201).Click += method_416;
                ((Control)field_204).BackColor = Color.Transparent;
                field_204.BaseColor = Color.White;
                field_204.BorderColor = Color.Transparent;
                ((Control)field_204).Controls.Add((Control)(object)field_327);
                ((Control)field_204).Controls.Add((Control)(object)field_214);
                ((Control)field_204).Controls.Add((Control)(object)field_215);
                ((Control)field_204).Controls.Add((Control)(object)field_216);
                ((Control)field_204).Controls.Add((Control)(object)field_217);
                ((Control)field_204).Controls.Add((Control)(object)field_218);
                ((Control)field_204).Controls.Add((Control)(object)field_219);
                ((Control)field_204).Controls.Add((Control)(object)field_220);
                ((Control)field_204).Controls.Add((Control)(object)field_221);
                ((Control)field_204).Controls.Add((Control)(object)field_222);
                ((Control)field_204).Controls.Add((Control)(object)field_223);
                ((Control)field_204).Controls.Add((Control)(object)field_224);
                ((Control)field_204).Controls.Add((Control)(object)field_225);
                ((Control)field_204).Controls.Add((Control)(object)field_226);
                ((Control)field_204).Controls.Add((Control)(object)field_227);
                ((Control)field_204).Controls.Add((Control)(object)field_228);
                ((Control)field_204).ForeColor = Color.White;
                field_204.LineColor = Color.FromArgb(64, 64, 64);
                field_204.LineRight = 3;
                field_204.LineTop = 25;
                ((Control)field_204).Location = new Point(0, 110);
                ((Control)field_204).Name = "GB_SOFT";
                ((Control)field_204).RightToLeft = (RightToLeft)1;
                ((Control)field_204).Size = new Size(221, 232);
                ((Control)field_204).TabIndex = 4;
                ((Control)field_204).Text = "نوع سوفت الأوبن ورت";
                field_204.TextLocation = new Point(100, 5);
                ((Control)field_327).AutoSize = true;
                ((Control)field_327).Font = UiFonts.Create(8.5f);
                ((Control)field_327).ForeColor = Color.Black;
                ((Control)field_327).Location = new Point(9, 118);
                ((Control)field_327).Name = "RB_Soft_KT10000";
                ((Control)field_327).Size = new Size(97, 16);
                ((Control)field_327).TabIndex = 60;
                ((Control)field_327).Tag = "KT10000";
                ((Control)field_327).Text = "كي تي  KT10000";
                ((ButtonBase)field_327).UseVisualStyleBackColor = true;
                field_327.CheckedChanged += method_375;
                ((Control)field_214).AutoSize = true;
                ((Control)field_214).Font = UiFonts.Create(8.5f);
                ((Control)field_214).ForeColor = Color.Black;
                ((Control)field_214).Location = new Point(122, 179);
                ((Control)field_214).Name = "radioButton1";
                ((Control)field_214).Size = new Size(79, 16);
                ((Control)field_214).TabIndex = 59;
                ((Control)field_214).Tag = "N1";
                ((Control)field_214).Text = "كومفاست N1";
                ((ButtonBase)field_214).UseVisualStyleBackColor = true;
                field_214.CheckedChanged += method_374;
                ((Control)field_215).AutoSize = true;
                ((Control)field_215).Font = UiFonts.Create(8.5f);
                ((Control)field_215).ForeColor = Color.Black;
                ((Control)field_215).Location = new Point(114, 118);
                ((Control)field_215).Name = "RB_Soft_KT704";
                ((Control)field_215).Size = new Size(87, 16);
                ((Control)field_215).TabIndex = 58;
                ((Control)field_215).Tag = "KT704";
                ((Control)field_215).Text = "كي تي  KT704";
                ((ButtonBase)field_215).UseVisualStyleBackColor = true;
                field_215.CheckedChanged += method_375;
                ((Control)field_216).AutoSize = true;
                ((Control)field_216).Font = UiFonts.Create(8.5f);
                ((Control)field_216).ForeColor = Color.Black;
                ((Control)field_216).Location = new Point(7, 179);
                ((Control)field_216).Name = "RB_Soft_WA350";
                ((Control)field_216).Size = new Size(99, 16);
                ((Control)field_216).TabIndex = 57;
                ((Control)field_216).Tag = "WA350";
                ((Control)field_216).Text = "كومفاست WA350";
                ((ButtonBase)field_216).UseVisualStyleBackColor = true;
                field_216.CheckedChanged += method_375;
                ((Control)field_217).AutoSize = true;
                field_217.Checked = true;
                ((Control)field_217).Font = UiFonts.Create(8f, (FontStyle)1);
                ((Control)field_217).ForeColor = Color.Maroon;
                ((Control)field_217).Location = new Point(29, 36);
                ((Control)field_217).Name = "RB_Amaan";
                ((Control)field_217).Size = new Size(172, 17);
                ((Control)field_217).TabIndex = 45;
                field_217.TabStop = true;
                ((Control)field_217).Tag = "AMAAN_SOFT";
                ((Control)field_217).Text = "~~ جهاز مبرمج بسوفت أمان ~~";
                ((ButtonBase)field_217).UseVisualStyleBackColor = true;
                field_217.CheckedChanged += method_373;
                ((Control)field_218).AutoSize = true;
                ((Control)field_218).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_218).ForeColor = Color.Maroon;
                ((Control)field_218).Location = new Point(23, 198);
                ((Control)field_218).Name = "RB_Soft_OTHER_DUAL";
                ((Control)field_218).Size = new Size(83, 19);
                ((Control)field_218).TabIndex = 56;
                ((Control)field_218).Tag = "GENERIC_DUAL";
                ((Control)field_218).Text = "اخرى ترددين";
                ((ButtonBase)field_218).UseVisualStyleBackColor = true;
                field_218.CheckedChanged += method_375;
                ((Control)field_219).AutoSize = true;
                ((Control)field_219).Font = UiFonts.Create(8.5f);
                ((Control)field_219).ForeColor = Color.Black;
                ((Control)field_219).Location = new Point(31, 159);
                ((Control)field_219).Name = "M2XW";
                ((Control)field_219).Size = new Size(75, 16);
                ((Control)field_219).TabIndex = 53;
                ((Control)field_219).Tag = "M2XW";
                ((Control)field_219).Text = "نانو  M2-XW";
                ((ButtonBase)field_219).UseVisualStyleBackColor = true;
                field_219.CheckedChanged += method_374;
                ((Control)field_220).AutoSize = true;
                ((Control)field_220).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_220).ForeColor = Color.Maroon;
                ((Control)field_220).Location = new Point(130, 198);
                ((Control)field_220).Name = "RB_Soft_OTHER";
                ((Control)field_220).Size = new Size(71, 19);
                ((Control)field_220).TabIndex = 55;
                ((Control)field_220).Tag = "GENERIC_2G";
                ((Control)field_220).Text = "اخرى تردد";
                ((ButtonBase)field_220).UseVisualStyleBackColor = true;
                field_220.CheckedChanged += method_374;
                ((Control)field_221).AutoSize = true;
                ((Control)field_221).Font = UiFonts.Create(8.5f);
                ((Control)field_221).ForeColor = Color.Black;
                ((Control)field_221).Location = new Point(128, 159);
                ((Control)field_221).Name = "RB_Soft_M2XM";
                ((Control)field_221).Size = new Size(73, 16);
                ((Control)field_221).TabIndex = 52;
                ((Control)field_221).Tag = "M2XM";
                ((Control)field_221).Text = "نانو  M2-XM";
                ((ButtonBase)field_221).UseVisualStyleBackColor = true;
                field_221.CheckedChanged += method_374;
                ((Control)field_222).AutoSize = true;
                ((Control)field_222).Font = UiFonts.Create(8.5f);
                ((Control)field_222).ForeColor = Color.Black;
                ((Control)field_222).Location = new Point(133, 59);
                ((Control)field_222).Name = "RB_Soft_K2P";
                ((Control)field_222).RightToLeft = (RightToLeft)1;
                ((Control)field_222).Size = new Size(68, 16);
                ((Control)field_222).TabIndex = 51;
                ((Control)field_222).Tag = "K2P";
                ((Control)field_222).Text = "فايكوم K2P";
                ((ButtonBase)field_222).UseVisualStyleBackColor = true;
                field_222.CheckedChanged += method_375;
                ((Control)field_223).AutoSize = true;
                ((Control)field_223).Font = UiFonts.Create(8.5f);
                ((Control)field_223).ForeColor = Color.Black;
                ((Control)field_223).Location = new Point(115, 78);
                ((Control)field_223).Name = "RB_Soft_K6";
                ((Control)field_223).Size = new Size(86, 16);
                ((Control)field_223).TabIndex = 54;
                ((Control)field_223).Tag = "KT6";
                ((Control)field_223).Text = "فايكوم لنك KT6";
                ((ButtonBase)field_223).UseVisualStyleBackColor = true;
                field_223.CheckedChanged += method_375;
                ((Control)field_224).AutoSize = true;
                ((Control)field_224).Font = UiFonts.Create(8.5f);
                ((Control)field_224).ForeColor = Color.Black;
                ((Control)field_224).Location = new Point(19, 139);
                ((Control)field_224).Name = "RB_Soft_CPE210";
                ((Control)field_224).Size = new Size(87, 16);
                ((Control)field_224).TabIndex = 50;
                ((Control)field_224).Tag = "CPE210";
                ((Control)field_224).Text = "تبلينك CPE210";
                ((ButtonBase)field_224).UseVisualStyleBackColor = true;
                field_224.CheckedChanged += method_374;
                ((Control)field_225).AutoSize = true;
                ((Control)field_225).Font = UiFonts.Create(8.5f);
                ((Control)field_225).ForeColor = Color.Black;
                ((Control)field_225).Location = new Point(114, 139);
                ((Control)field_225).Name = "RB_Soft_CPE220";
                ((Control)field_225).Size = new Size(87, 16);
                ((Control)field_225).TabIndex = 49;
                ((Control)field_225).Tag = "CPE220";
                ((Control)field_225).Text = "تبلينك CPE220";
                ((ButtonBase)field_225).UseVisualStyleBackColor = true;
                field_225.CheckedChanged += method_374;
                ((Control)field_226).AutoSize = true;
                ((Control)field_226).Font = UiFonts.Create(8.5f);
                ((Control)field_226).ForeColor = Color.Black;
                ((Control)field_226).Location = new Point(44, 59);
                ((Control)field_226).Name = "RB_Soft_K2";
                ((Control)field_226).RightToLeft = (RightToLeft)1;
                ((Control)field_226).Size = new Size(62, 16);
                ((Control)field_226).TabIndex = 46;
                ((Control)field_226).Tag = "K2";
                ((Control)field_226).Text = "فايكوم K2";
                ((ButtonBase)field_226).UseVisualStyleBackColor = true;
                field_226.CheckedChanged += method_375;
                ((Control)field_227).AutoSize = true;
                ((Control)field_227).Font = UiFonts.Create(8.5f);
                ((Control)field_227).ForeColor = Color.Black;
                ((Control)field_227).Location = new Point(19, 98);
                ((Control)field_227).Name = "RB_Soft_KT708";
                ((Control)field_227).Size = new Size(87, 16);
                ((Control)field_227).TabIndex = 48;
                ((Control)field_227).Tag = "KT708";
                ((Control)field_227).Text = "كي تي  KT708";
                ((ButtonBase)field_227).UseVisualStyleBackColor = true;
                field_227.CheckedChanged += method_375;
                ((Control)field_228).AutoSize = true;
                ((Control)field_228).Font = UiFonts.Create(8.5f);
                ((Control)field_228).ForeColor = Color.Black;
                ((Control)field_228).Location = new Point(114, 98);
                ((Control)field_228).Name = "RB_Soft_KT412";
                ((Control)field_228).Size = new Size(87, 16);
                ((Control)field_228).TabIndex = 47;
                ((Control)field_228).Tag = "KT412";
                ((Control)field_228).Text = "كي تي  KT412";
                ((ButtonBase)field_228).UseVisualStyleBackColor = true;
                field_228.CheckedChanged += method_375;
                field_205.LineColor = Color.Silver;
                ((Control)field_205).Location = new Point(240, 86);
                ((Control)field_205).Name = "gunaSeparator1";
                ((Control)field_205).Size = new Size(200, 10);
                ((Control)field_205).TabIndex = 21;
                field_206.AutoCompleteCustomSource.AddRange(new string[11]
                {
                        "192.168.1.1",
                        "192.168.0.1",
                        "192.168.2.1",
                        "192.168.10.1",
                        "192.168.17.1",
                        "192.168.30.1",
                        "192.168.70.1",
                        "192.168.100.1",
                        "10.0.0.",
                        "10.10.10.",
                        ""
                });
                field_206.AutoCompleteMode = (AutoCompleteMode)3;
                field_206.AutoCompleteSource = (AutoCompleteSource)64;
                field_206.BaseColor = Color.White;
                field_206.BorderColor = Color.Silver;
                ((Control)field_206).Cursor = Cursors.IBeam;
                field_206.FocusedBaseColor = Color.White;
                field_206.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_206.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_206).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_206).ForeColor = Color.Black;
                ((Control)field_206).Location = new Point(14, 9);
                ((Control)field_206).Name = "textBoxIP";
                field_206.PasswordChar = '\0';
                field_206.SelectedText = "";
                ((Control)field_206).Size = new Size(124, 26);
                ((Control)field_206).TabIndex = 1;
                ((Control)field_206).Text = "192.168.1.1";
                field_206.TextAlign = (HorizontalAlignment)2;
                ((Control)field_207).BackColor = Color.Transparent;
                field_207.BackgroundImageLayout = (ImageLayout)0;
                ((Control)field_207).Location = new Point(540, 5);
                ((Control)field_207).Name = "gunaWinCircleProgressIndicator1";
                field_207.ProgressColor = Color.Red;
                ((Control)field_207).Size = new Size(26, 27);
                ((Control)field_207).TabIndex = 25;
                ((Control)field_207).Visible = false;
                ((Control)field_208).Anchor = (AnchorStyles)9;
                ((Control)field_208).BackColor = Color.Red;
                ((Control)field_208).Controls.Add((Control)(object)field_306);
                ((Control)field_208).Controls.Add((Control)(object)field_304);
                ((Control)field_208).Controls.Add((Control)(object)field_204);
                ((Control)field_208).Controls.Add((Control)(object)field_211);
                ((Control)field_208).Controls.Add((Control)(object)field_212);
                ((Control)field_208).Controls.Add((Control)(object)field_203);
                ((Control)field_208).Controls.Add((Control)(object)field_213);
                ((Control)field_208).Controls.Add((Control)(object)field_209);
                ((Control)field_208).Controls.Add((Control)(object)field_210);
                ((Control)field_208).Controls.Add((Control)(object)field_206);
                ((Control)field_208).ForeColor = Color.White;
                ((Control)field_208).Location = new Point(715, 84);
                ((Control)field_208).Name = "gunaPanel1";
                ((Control)field_208).Size = new Size(221, 345);
                ((Control)field_208).TabIndex = 26;
                ((Control)field_306).BackColor = Color.White;
                field_306.ImageCheckedOff = (Image)(object)ImageCache.method_598();
                field_306.ImageCheckedOn = (Image)(object)ImageCache.method_589();
                field_306.ImageSize = new Size(16, 16);
                ((Control)field_306).Location = new Point(16, 79);
                ((Control)field_306).Name = "GIRB_ShowPassL";
                ((Control)field_306).Size = new Size(17, 19);
                ((Control)field_306).TabIndex = 71;
                ((Control)field_306).Click += method_402;
                ((Control)field_304).BackColor = Color.Brown;
                ((Control)field_304).Font = UiFonts.Create(9f);
                ((Control)field_304).ForeColor = Color.Maroon;
                ((Control)field_304).Location = new Point(4, 9);
                ((Control)field_304).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_304).Name = "LblIsIPConnected";
                ((Control)field_304).RightToLeft = (RightToLeft)0;
                ((Control)field_304).Size = new Size(10, 26);
                ((Control)field_304).TabIndex = 70;
                field_304.TextAlign = (ContentAlignment)64;
                ((Control)field_304).Click += method_415;
                field_211.AnimationHoverSpeed = 0.07f;
                field_211.AnimationSpeed = 0.03f;
                field_211.BaseColor1 = Color.FromArgb(64, 64, 64);
                field_211.BaseColor2 = Color.Black;
                field_211.BorderColor = Color.Black;
                field_211.DialogResult = (DialogResult)0;
                field_211.FocusedColor = Color.Empty;
                ((Control)field_211).Font = UiFonts.Create(9f);
                ((Control)field_211).ForeColor = Color.White;
                field_211.Image = (Image)(object)ImageCache.method_591();
                field_211.ImageAlign = (HorizontalAlignment)1;
                field_211.ImageOffsetX = -5;
                field_211.ImageSize = new Size(15, 15);
                ((Control)field_211).Location = new Point(136, 75);
                ((Control)field_211).Name = "gunaGradientButton3";
                field_211.OnHoverBaseColor1 = Color.Black;
                field_211.OnHoverBaseColor2 = Color.FromArgb(64, 64, 64);
                field_211.OnHoverBorderColor = Color.Black;
                field_211.OnHoverForeColor = Color.White;
                field_211.OnHoverImage = null;
                field_211.OnPressedColor = Color.Black;
                ((Control)field_211).Size = new Size(85, 26);
                ((Control)field_211).TabIndex = 31;
                ((Control)field_211).Text = "كلمة المرور";
                field_211.TextOffsetX = -6;
                ((Control)field_211).Click += method_417;
                field_212.AnimationHoverSpeed = 0.07f;
                field_212.AnimationSpeed = 0.03f;
                field_212.BaseColor1 = Color.FromArgb(64, 64, 64);
                field_212.BaseColor2 = Color.Black;
                field_212.BorderColor = Color.Black;
                field_212.DialogResult = (DialogResult)0;
                field_212.FocusedColor = Color.Empty;
                ((Control)field_212).Font = UiFonts.Create(9f);
                ((Control)field_212).ForeColor = Color.White;
                field_212.Image = (Image)(object)ImageCache.method_604();
                field_212.ImageAlign = (HorizontalAlignment)1;
                field_212.ImageOffsetX = -5;
                field_212.ImageSize = new Size(15, 15);
                ((Control)field_212).Location = new Point(136, 41);
                ((Control)field_212).Name = "gunaGradientButton2";
                field_212.OnHoverBaseColor1 = Color.Black;
                field_212.OnHoverBaseColor2 = Color.FromArgb(64, 64, 64);
                field_212.OnHoverBorderColor = Color.Black;
                field_212.OnHoverForeColor = Color.White;
                field_212.OnHoverImage = null;
                field_212.OnPressedColor = Color.Black;
                ((Control)field_212).Size = new Size(85, 26);
                ((Control)field_212).TabIndex = 30;
                ((Control)field_212).Text = "المستخدم";
                field_203.AnimationHoverSpeed = 0.07f;
                field_203.AnimationSpeed = 0.03f;
                field_203.BaseColor1 = Color.Black;
                field_203.BaseColor2 = Color.Black;
                field_203.BorderColor = Color.Black;
                field_203.DialogResult = (DialogResult)0;
                field_203.FocusedColor = Color.Empty;
                ((Control)field_203).Font = UiFonts.Create(9f);
                ((Control)field_203).ForeColor = Color.White;
                field_203.Image = (Image)(object)ImageCache.method_605();
                field_203.ImageAlign = (HorizontalAlignment)1;
                field_203.ImageOffsetX = -5;
                field_203.ImageSize = new Size(15, 15);
                ((Control)field_203).Location = new Point(136, 9);
                ((Control)field_203).Name = "BtnIsIPConnected";
                field_203.OnHoverBaseColor1 = Color.Black;
                field_203.OnHoverBaseColor2 = Color.FromArgb(64, 64, 64);
                field_203.OnHoverBorderColor = Color.Black;
                field_203.OnHoverForeColor = Color.White;
                field_203.OnHoverImage = null;
                field_203.OnPressedColor = Color.Black;
                ((Control)field_203).Size = new Size(85, 26);
                ((Control)field_203).TabIndex = 11;
                ((Control)field_203).Text = "ايبي الجهاز";
                field_203.TextOffsetX = -5;
                ((Control)field_203).Click += method_394;
                ((Control)field_213).AutoSize = true;
                ((Control)field_213).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_213).Location = new Point(148, 14);
                ((Control)field_213).Name = "gunaLabel1";
                ((Control)field_213).Size = new Size(59, 15);
                ((Control)field_213).TabIndex = 29;
                ((Control)field_213).Text = "ايبي الجهاز";
                field_209.BaseColor = Color.White;
                field_209.BorderColor = Color.Silver;
                ((Control)field_209).Cursor = Cursors.IBeam;
                field_209.FocusedBaseColor = Color.White;
                field_209.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_209.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_209).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_209).ForeColor = Color.Black;
                ((Control)field_209).Location = new Point(14, 75);
                ((Control)field_209).Name = "textBoxPwd";
                field_209.PasswordChar = '●';
                field_209.SelectedText = "";
                ((Control)field_209).Size = new Size(124, 26);
                ((Control)field_209).TabIndex = 3;
                field_209.TextAlign = (HorizontalAlignment)2;
                field_209.TextOffsetX = 12;
                field_284.SetToolTip((Control)(object)field_209, "ادخل كلمة مرور الاعدادات الافتراضي فارغ");
                field_210.BaseColor = Color.White;
                field_210.BorderColor = Color.Silver;
                ((Control)field_210).Cursor = Cursors.IBeam;
                field_210.FocusedBaseColor = Color.White;
                field_210.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_210.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_210).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_210).ForeColor = Color.Black;
                ((Control)field_210).Location = new Point(14, 41);
                ((Control)field_210).Name = "textBoxUsn";
                field_210.PasswordChar = '\0';
                field_210.SelectedText = "";
                ((Control)field_210).Size = new Size(124, 26);
                ((Control)field_210).TabIndex = 2;
                ((Control)field_210).Text = "root";
                field_210.TextAlign = (HorizontalAlignment)2;
                ((Control)field_231).BackColor = Color.Transparent;
                field_231.BaseColor = Color.FromArgb(64, 64, 64);
                ((Control)field_231).Controls.Add((Control)(object)field_288);
                ((Control)field_231).Controls.Add((Control)(object)field_289);
                ((Control)field_231).Controls.Add((Control)(object)field_234);
                ((Control)field_231).Controls.Add((Control)(object)field_235);
                ((Control)field_231).Controls.Add((Control)(object)field_236);
                ((Control)field_231).Controls.Add((Control)(object)field_205);
                ((Control)field_231).Controls.Add((Control)(object)field_237);
                ((Control)field_231).Controls.Add((Control)(object)field_238);
                ((Control)field_231).Controls.Add((Control)(object)field_239);
                ((Control)field_231).Controls.Add((Control)(object)field_240);
                ((Control)field_231).Controls.Add((Control)(object)field_241);
                ((Control)field_231).Controls.Add((Control)(object)field_242);
                ((Control)field_231).Controls.Add((Control)(object)field_243);
                ((Control)field_231).Controls.Add((Control)(object)field_244);
                ((Control)field_231).Controls.Add((Control)(object)field_245);
                ((Control)field_231).Controls.Add((Control)(object)field_246);
                ((Control)field_231).Controls.Add((Control)(object)field_247);
                ((Control)field_231).Controls.Add((Control)(object)field_248);
                ((Control)field_231).Location = new Point(2, 35);
                ((Control)field_231).Name = "gunaElipsePanel1";
                field_231.Radius = 22;
                ((Control)field_231).RightToLeft = (RightToLeft)1;
                ((Control)field_231).Size = new Size(698, 99);
                ((Control)field_231).TabIndex = 61;
                ((Control)field_288).Anchor = (AnchorStyles)9;
                ((Control)field_288).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_288).ForeColor = Color.White;
                ((Control)field_288).Location = new Point(455, 50);
                ((Control)field_288).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_288).Name = "infLBL_Krnl";
                ((Control)field_288).RightToLeft = (RightToLeft)0;
                ((Control)field_288).Size = new Size(148, 20);
                ((Control)field_288).TabIndex = 57;
                ((Control)field_288).Text = "-";
                field_288.TextAlign = (ContentAlignment)64;
                ((Control)field_289).Anchor = (AnchorStyles)9;
                ((Control)field_289).AutoSize = true;
                ((Control)field_289).Font = UiFonts.Create(9f);
                ((Control)field_289).ForeColor = Color.White;
                ((Control)field_289).Location = new Point(604, 53);
                ((Control)field_289).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_289).Name = "label3";
                ((Control)field_289).Size = new Size(74, 14);
                ((Control)field_289).TabIndex = 56;
                ((Control)field_289).Text = "اصدار الكيرنل:";
                field_289.TextAlign = (ContentAlignment)64;
                ((Control)field_234).Anchor = (AnchorStyles)9;
                ((Control)field_234).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_234).ForeColor = Color.White;
                ((Control)field_234).Location = new Point(452, 68);
                ((Control)field_234).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_234).Name = "infLBL_ARCH";
                ((Control)field_234).RightToLeft = (RightToLeft)0;
                ((Control)field_234).Size = new Size(151, 20);
                ((Control)field_234).TabIndex = 55;
                ((Control)field_234).Text = "-";
                field_234.TextAlign = (ContentAlignment)64;
                ((Control)field_235).Anchor = (AnchorStyles)9;
                ((Control)field_235).AutoSize = true;
                ((Control)field_235).Font = UiFonts.Create(9f);
                ((Control)field_235).ForeColor = Color.White;
                ((Control)field_235).Location = new Point(604, 71);
                ((Control)field_235).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_235).Name = "label22";
                ((Control)field_235).Size = new Size(55, 14);
                ((Control)field_235).TabIndex = 54;
                ((Control)field_235).Text = "المعماريه:";
                field_235.TextAlign = (ContentAlignment)64;
                ((Control)field_236).Anchor = (AnchorStyles)9;
                ((Control)field_236).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_236).ForeColor = Color.White;
                ((Control)field_236).Location = new Point(240, 58);
                ((Control)field_236).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_236).Name = "infLBL_RAM";
                ((Control)field_236).RightToLeft = (RightToLeft)0;
                ((Control)field_236).Size = new Size(133, 20);
                ((Control)field_236).TabIndex = 52;
                ((Control)field_236).Text = "-";
                field_236.TextAlign = (ContentAlignment)64;
                ((Control)field_237).Anchor = (AnchorStyles)9;
                ((Control)field_237).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_237).ForeColor = Color.White;
                ((Control)field_237).Location = new Point(240, 38);
                ((Control)field_237).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_237).Name = "infLBL_MEMORY";
                ((Control)field_237).RightToLeft = (RightToLeft)0;
                ((Control)field_237).Size = new Size(133, 20);
                ((Control)field_237).TabIndex = 51;
                ((Control)field_237).Text = "-";
                field_237.TextAlign = (ContentAlignment)64;
                ((Control)field_238).Anchor = (AnchorStyles)9;
                ((Control)field_238).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_238).ForeColor = Color.White;
                ((Control)field_238).Location = new Point(134, 15);
                ((Control)field_238).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_238).Name = "infLBL_CPU";
                ((Control)field_238).Size = new Size(238, 20);
                ((Control)field_238).TabIndex = 50;
                ((Control)field_238).Text = "-";
                field_238.TextAlign = (ContentAlignment)16;
                ((Control)field_239).Anchor = (AnchorStyles)9;
                ((Control)field_239).AutoSize = true;
                ((Control)field_239).Font = UiFonts.Create(9f);
                ((Control)field_239).ForeColor = Color.White;
                ((Control)field_239).Location = new Point(369, 41);
                ((Control)field_239).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_239).Name = "label26";
                ((Control)field_239).Size = new Size(72, 14);
                ((Control)field_239).TabIndex = 47;
                ((Control)field_239).Text = "حجم الذاكره:";
                field_239.TextAlign = (ContentAlignment)64;
                ((Control)field_240).Anchor = (AnchorStyles)9;
                ((Control)field_240).AutoSize = true;
                ((Control)field_240).Font = UiFonts.Create(9f);
                ((Control)field_240).ForeColor = Color.White;
                ((Control)field_240).Location = new Point(369, 61);
                ((Control)field_240).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_240).Name = "label25";
                ((Control)field_240).Size = new Size(60, 14);
                ((Control)field_240).TabIndex = 46;
                ((Control)field_240).Text = "حجم الرام:";
                field_240.TextAlign = (ContentAlignment)64;
                ((Control)field_241).Anchor = (AnchorStyles)9;
                ((Control)field_241).AutoSize = true;
                ((Control)field_241).Font = UiFonts.Create(8.5f);
                ((Control)field_241).ForeColor = Color.Yellow;
                ((Control)field_241).Location = new Point(75, 33);
                ((Control)field_241).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_241).Name = "infLBL_Is_ProtectedMesh";
                ((Control)field_241).Size = new Size(110, 12);
                ((Control)field_241).TabIndex = 45;
                ((Control)field_241).Text = " ✅ يدعم الميش بباسورد";
                field_241.TextAlign = (ContentAlignment)64;
                ((Control)field_241).Visible = false;
                ((Control)field_242).Anchor = (AnchorStyles)9;
                ((Control)field_242).AutoSize = true;
                ((Control)field_242).Font = UiFonts.Create(8.5f);
                ((Control)field_242).ForeColor = Color.Yellow;
                ((Control)field_242).Location = new Point(93, 46);
                ((Control)field_242).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_242).Name = "infLBL_Is_WCAT";
                ((Control)field_242).Size = new Size(92, 12);
                ((Control)field_242).TabIndex = 44;
                ((Control)field_242).Text = " ✅ يدعم الواتش كات";
                field_242.TextAlign = (ContentAlignment)64;
                ((Control)field_242).Visible = false;
                ((Control)field_243).Anchor = (AnchorStyles)9;
                ((Control)field_243).AutoSize = true;
                ((Control)field_243).Font = UiFonts.Create(8.5f);
                ((Control)field_243).ForeColor = Color.Yellow;
                ((Control)field_243).Location = new Point(64, 58);
                ((Control)field_243).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_243).Name = "infLBL_Is_LLDP";
                ((Control)field_243).Size = new Size(121, 12);
                ((Control)field_243).TabIndex = 42;
                ((Control)field_243).Text = " ✅ يدعم الظهور في النيبورز";
                field_243.TextAlign = (ContentAlignment)64;
                ((Control)field_243).Visible = false;
                ((Control)field_244).Anchor = (AnchorStyles)9;
                ((Control)field_244).AutoSize = true;
                ((Control)field_244).Font = UiFonts.Create(9f);
                ((Control)field_244).ForeColor = Color.White;
                ((Control)field_244).Location = new Point(604, 36);
                ((Control)field_244).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_244).Name = "label21";
                ((Control)field_244).Size = new Size(70, 14);
                ((Control)field_244).TabIndex = 41;
                ((Control)field_244).Text = "اصدار النظام:";
                field_244.TextAlign = (ContentAlignment)64;
                ((Control)field_245).Anchor = (AnchorStyles)9;
                ((Control)field_245).AutoSize = true;
                ((Control)field_245).Font = UiFonts.Create(9f);
                ((Control)field_245).ForeColor = Color.White;
                ((Control)field_245).Location = new Point(369, 18);
                ((Control)field_245).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_245).Name = "label19";
                ((Control)field_245).Size = new Size(64, 14);
                ((Control)field_245).TabIndex = 40;
                ((Control)field_245).Text = "نوع المعالج:";
                field_245.TextAlign = (ContentAlignment)64;
                ((Control)field_246).Anchor = (AnchorStyles)9;
                ((Control)field_246).AutoSize = true;
                ((Control)field_246).Font = UiFonts.Create(9f);
                ((Control)field_246).ForeColor = Color.White;
                ((Control)field_246).Location = new Point(604, 16);
                ((Control)field_246).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_246).Name = "label18";
                ((Control)field_246).Size = new Size(67, 14);
                ((Control)field_246).TabIndex = 39;
                ((Control)field_246).Text = "اسم الجهاز:";
                field_246.TextAlign = (ContentAlignment)64;
                ((Control)field_247).Anchor = (AnchorStyles)9;
                ((Control)field_247).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_247).ForeColor = Color.White;
                ((Control)field_247).Location = new Point(444, 33);
                ((Control)field_247).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_247).Name = "infLBL_Ver";
                ((Control)field_247).RightToLeft = (RightToLeft)0;
                ((Control)field_247).Size = new Size(159, 20);
                ((Control)field_247).TabIndex = 49;
                ((Control)field_247).Text = "-";
                field_247.TextAlign = (ContentAlignment)64;
                ((Control)field_248).Anchor = (AnchorStyles)9;
                ((Control)field_248).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_248).ForeColor = Color.White;
                ((Control)field_248).Location = new Point(387, 15);
                ((Control)field_248).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_248).Name = "infLBL_NAME";
                ((Control)field_248).Size = new Size(216, 20);
                ((Control)field_248).TabIndex = 48;
                ((Control)field_248).Text = "-";
                field_248.TextAlign = (ContentAlignment)16;
                ((Control)field_232).Controls.Add((Control)(object)field_331);
                ((Control)field_232).Controls.Add((Control)(object)field_329);
                ((Control)field_232).Controls.Add((Control)(object)field_310);
                ((Control)field_232).Controls.Add((Control)(object)field_324);
                ((Control)field_232).Controls.Add((Control)(object)field_313);
                ((Control)field_232).Controls.Add((Control)(object)field_290);
                ((Control)field_232).Controls.Add((Control)(object)field_268);
                ((Control)field_232).Controls.Add((Control)(object)field_287);
                ((Control)field_232).Controls.Add((Control)(object)field_286);
                ((Control)field_232).Controls.Add((Control)(object)field_256);
                ((Control)field_232).Controls.Add((Control)(object)field_285);
                ((Control)field_232).Controls.Add((Control)(object)field_269);
                ((Control)field_232).Controls.Add((Control)(object)field_251);
                ((Control)field_232).Controls.Add((Control)(object)field_250);
                ((Control)field_232).Controls.Add((Control)(object)field_202);
                ((Control)field_232).Controls.Add((Control)(object)field_292);
                ((Control)field_232).Enabled = false;
                ((Control)field_232).Location = new Point(2, 140);
                ((Control)field_232).Name = "GB_MAIN";
                ((Control)field_232).Size = new Size(698, 365);
                ((Control)field_232).TabIndex = 62;
                ((Control)field_331).Anchor = (AnchorStyles)6;
                field_331.AnimationHoverSpeed = 0.07f;
                field_331.AnimationSpeed = 0.03f;
                ((Control)field_331).BackColor = Color.Transparent;
                ((Control)field_331).BackgroundImageLayout = (ImageLayout)2;
                field_331.BaseColor = Color.OrangeRed;
                field_331.BorderColor = Color.Black;
                field_331.DialogResult = (DialogResult)0;
                field_331.FocusedColor = Color.Empty;
                ((Control)field_331).Font = UiFonts.Create(9f);
                ((Control)field_331).ForeColor = Color.White;
                field_331.Image = (Image)(object)ImageCache.method_601();
                field_331.ImageSize = new Size(21, 21);
                ((Control)field_331).Location = new Point(11, 329);
                ((Control)field_331).Name = "buttonListSettings";
                field_331.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_331.OnHoverBorderColor = Color.Black;
                field_331.OnHoverForeColor = Color.White;
                field_331.OnHoverImage = null;
                field_331.OnPressedColor = Color.Black;
                ((Control)field_331).Size = new Size(21, 21);
                ((Control)field_331).TabIndex = 74;
                field_284.SetToolTip((Control)(object)field_331, "قائمة النماذج المحفوظه");
                ((Control)field_331).Click += method_418;
                ((Control)field_329).Anchor = (AnchorStyles)6;
                field_329.AnimationHoverSpeed = 0.07f;
                field_329.AnimationSpeed = 0.03f;
                ((Control)field_329).BackColor = Color.Transparent;
                ((Control)field_329).BackgroundImageLayout = (ImageLayout)2;
                field_329.BaseColor = Color.MidnightBlue;
                field_329.BorderColor = Color.Black;
                field_329.DialogResult = (DialogResult)0;
                field_329.FocusedColor = Color.Empty;
                ((Control)field_329).Font = UiFonts.Create(9f);
                ((Control)field_329).ForeColor = Color.White;
                field_329.Image = (Image)(object)ImageCache.method_580();
                field_329.ImageSize = new Size(35, 35);
                ((Control)field_329).Location = new Point(149, 306);
                ((Control)field_329).Name = "buttonRestoreBackup";
                field_329.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_329.OnHoverBorderColor = Color.Black;
                field_329.OnHoverForeColor = Color.White;
                field_329.OnHoverImage = null;
                field_329.OnPressedColor = Color.Black;
                ((Control)field_329).Size = new Size(40, 40);
                ((Control)field_329).TabIndex = 73;
                field_284.SetToolTip((Control)(object)field_329, "استعادة البرمجه من نسخه احتياطيه محفوظه في الكمبيوتر");
                ((Control)field_329).Click += method_388;
                ((Control)field_310).Anchor = (AnchorStyles)9;
                field_310.BaseColor = Color.Transparent;
                field_310.CheckedOffColor = Color.Gray;
                field_310.CheckedOnColor = Color.FromArgb(64, 0, 0);
                field_310.FillColor = Color.White;
                ((Control)field_310).Font = UiFonts.Create(8f);
                ((Control)field_310).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_310).Location = new Point(187, 178);
                ((Control)field_310).Name = "cb_AutoNumberingV100";
                ((Control)field_310).RightToLeft = (RightToLeft)1;
                ((Control)field_310).Size = new Size(146, 20);
                ((Control)field_310).TabIndex = 70;
                ((Control)field_310).Text = "الفيلان يبدأ من 100 وأعلى";
                ((Control)field_324).BackColor = Color.Transparent;
                field_324.BaseColor = Color.Transparent;
                ((Control)field_324).Controls.Add((Control)(object)field_262);
                ((Control)field_324).Controls.Add((Control)(object)field_305);
                ((Control)field_324).Controls.Add((Control)(object)field_261);
                ((Control)field_324).Controls.Add((Control)(object)field_260);
                ((Control)field_324).Controls.Add((Control)(object)field_267);
                ((Control)field_324).Controls.Add((Control)(object)field_266);
                ((Control)field_324).Controls.Add((Control)(object)field_264);
                ((Control)field_324).Controls.Add((Control)(object)field_263);
                ((Control)field_324).Controls.Add((Control)(object)field_265);
                ((Control)field_324).Controls.Add((Control)(object)field_334);
                ((Control)field_324).Location = new Point(7, 198);
                ((Control)field_324).Name = "gunaElipsePanel2";
                field_324.Radius = 11;
                ((Control)field_324).Size = new Size(683, 51);
                ((Control)field_324).TabIndex = 72;
                ((Control)field_262).AutoSize = true;
                ((Control)field_262).Font = UiFonts.Create(10f, (FontStyle)1);
                ((Control)field_262).Location = new Point(498, 15);
                ((Control)field_262).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_262).Name = "label9";
                ((Control)field_262).Size = new Size(44, 19);
                ((Control)field_262).TabIndex = 41;
                ((Control)field_262).Text = "الايبي";
                field_262.TextAlign = (ContentAlignment)64;
                ((Control)field_305).BackColor = Color.MintCream;
                field_305.ImageCheckedOff = (Image)(object)ImageCache.method_598();
                field_305.ImageCheckedOn = (Image)(object)ImageCache.method_589();
                field_305.ImageSize = new Size(16, 16);
                ((Control)field_305).Location = new Point(179, 15);
                ((Control)field_305).Name = "GIRB_ShowPass";
                ((Control)field_305).Size = new Size(17, 19);
                ((Control)field_305).TabIndex = 70;
                ((Control)field_305).Click += method_402;
                ((Control)field_261).AutoSize = true;
                ((Control)field_261).Font = UiFonts.Create(10f, (FontStyle)1);
                ((Control)field_261).Location = new Point(605, 15);
                ((Control)field_261).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_261).Name = "lbl_vid";
                ((Control)field_261).Size = new Size(72, 19);
                ((Control)field_261).TabIndex = 42;
                ((Control)field_261).Text = "رقم الفيلان";
                field_261.TextAlign = (ContentAlignment)64;
                ((Control)field_260).AutoSize = true;
                ((Control)field_260).Font = UiFonts.Create(10f, (FontStyle)1);
                ((Control)field_260).Location = new Point(102, 15);
                ((Control)field_260).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_260).Name = "label11";
                ((Control)field_260).Size = new Size(71, 19);
                ((Control)field_260).TabIndex = 43;
                ((Control)field_260).Text = "اسم الجهاز";
                field_260.TextAlign = (ContentAlignment)64;
                ((Control)field_267).BackColor = Color.Transparent;
                field_267.BaseColor = Color.MintCream;
                field_267.BorderColor = Color.DimGray;
                field_267.BorderSize = 1;
                ((Control)field_267).Cursor = Cursors.IBeam;
                field_267.FocusedBaseColor = Color.White;
                field_267.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_267.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_267).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_267).ForeColor = Color.Black;
                ((Control)field_267).Location = new Point(546, 9);
                ((Control)field_267).Name = "textBoxN_VLAN";
                field_267.PasswordChar = '\0';
                field_267.Radius = 9;
                ((Control)field_267).RightToLeft = (RightToLeft)0;
                field_267.SelectedText = "";
                ((Control)field_267).Size = new Size(59, 30);
                ((Control)field_267).TabIndex = 8;
                ((Control)field_267).Text = "1";
                field_267.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_267, "رقم الفيلان من 2 الى 4000 \r\n( يجب ان يكون الفيلان مضاف بشبكتك )\r\nالرقم 0 صفر او 1 واحد يعني ان الاكسس سيتم برمجته بدون فيلان ");
                ((Control)field_267).TextChanged += method_345;
                ((Control)field_267).KeyPress += method_346;
                ((Control)field_266).BackColor = Color.Transparent;
                field_266.BaseColor = Color.MintCream;
                field_266.BorderColor = Color.DimGray;
                field_266.BorderSize = 1;
                ((Control)field_266).Cursor = Cursors.IBeam;
                field_266.FocusedBaseColor = Color.White;
                field_266.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_266.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_266).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_266).ForeColor = Color.Black;
                ((Control)field_266).Location = new Point(383, 9);
                ((Control)field_266).Name = "textBoxN_IP";
                field_266.PasswordChar = '\0';
                field_266.Radius = 9;
                ((Control)field_266).RightToLeft = (RightToLeft)0;
                field_266.SelectedText = "";
                ((Control)field_266).Size = new Size(114, 30);
                ((Control)field_266).TabIndex = 9;
                ((Control)field_266).Text = "192.168.1.1";
                field_266.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_266, "الايبي الجديد للجهاز");
                ((Control)field_266).KeyPress += method_347;
                ((Control)field_264).BackColor = Color.Transparent;
                field_264.BaseColor = Color.MintCream;
                field_264.BorderColor = Color.DimGray;
                field_264.BorderSize = 1;
                ((Control)field_264).Cursor = Cursors.IBeam;
                field_264.FocusedBaseColor = Color.White;
                field_264.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_264.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_264).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_264).ForeColor = Color.Black;
                ((Control)field_264).Location = new Point(7, 9);
                ((Control)field_264).Name = "textBoxN_HN";
                field_264.PasswordChar = '\0';
                field_264.Radius = 9;
                ((Control)field_264).RightToLeft = (RightToLeft)0;
                field_264.SelectedText = "";
                ((Control)field_264).Size = new Size(93, 30);
                ((Control)field_264).TabIndex = 11;
                ((Control)field_264).Text = "AMAAN";
                field_264.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_264, "الاسم الذي يظهر في النيبورز");
                ((Control)field_263).AutoSize = true;
                ((Control)field_263).Font = UiFonts.Create(10f, (FontStyle)1);
                ((Control)field_263).Location = new Point(303, 15);
                ((Control)field_263).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_263).Name = "label2";
                ((Control)field_263).Size = new Size(75, 19);
                ((Control)field_263).TabIndex = 55;
                ((Control)field_263).Text = "كلمة المرور";
                field_263.TextAlign = (ContentAlignment)64;
                field_265.AutoCompleteMode = (AutoCompleteMode)3;
                ((Control)field_265).BackColor = Color.Transparent;
                field_265.BaseColor = Color.MintCream;
                field_265.BorderColor = Color.DimGray;
                field_265.BorderSize = 1;
                ((Control)field_265).Cursor = Cursors.IBeam;
                field_265.FocusedBaseColor = Color.White;
                field_265.FocusedBorderColor = Color.Red;
                field_265.FocusedForeColor = Color.Navy;
                ((Control)field_265).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_265).ForeColor = Color.Black;
                ((Control)field_265).Location = new Point(177, 9);
                ((Control)field_265).Name = "textBoxN_Pass";
                field_265.PasswordChar = '●';
                field_265.Radius = 9;
                field_265.SelectedText = "";
                ((Control)field_265).Size = new Size(124, 30);
                ((Control)field_265).TabIndex = 15;
                field_265.TextAlign = (HorizontalAlignment)2;
                field_265.TextOffsetX = 12;
                field_284.SetToolTip((Control)(object)field_265, "كلمة المرور الخاصه بالإعدادات");
                ((Control)field_334).AutoSize = true;
                ((Control)field_334).BackColor = Color.Transparent;
                ((Control)field_334).Font = UiFonts.Create(8f);
                ((Control)field_334).ForeColor = Color.FromArgb(0, 0, 192);
                ((Control)field_334).Location = new Point(611, 35);
                ((Control)field_334).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_334).Name = "lbl_WO_vlan";
                ((Control)field_334).Size = new Size(57, 13);
                ((Control)field_334).TabIndex = 71;
                ((Control)field_334).Text = "بدون فيلان";
                field_334.TextAlign = (ContentAlignment)64;
                ((Control)field_334).Visible = false;
                ((Control)field_313).Anchor = (AnchorStyles)6;
                ((Control)field_313).BackColor = Color.AliceBlue;
                ((Control)field_313).Controls.Add((Control)(object)field_314);
                ((Control)field_313).Controls.Add((Control)(object)field_315);
                ((Control)field_313).Controls.Add((Control)(object)field_316);
                ((Control)field_313).Controls.Add((Control)(object)field_317);
                ((Control)field_313).Controls.Add((Control)(object)field_318);
                ((Control)field_313).Controls.Add((Control)(object)field_335);
                ((Control)field_313).Font = UiFonts.Create(9f);
                ((Control)field_313).ForeColor = Color.Blue;
                ((Control)field_313).Location = new Point(7, 3);
                ((Control)field_313).Name = "groupBox2";
                ((Control)field_313).RightToLeft = (RightToLeft)1;
                ((Control)field_313).Size = new Size(173, 87);
                ((Control)field_313).TabIndex = 71;
                field_313.TabStop = false;
                ((Control)field_313).Text = "اعدادات";
                ((Control)field_314).Anchor = (AnchorStyles)10;
                ((Control)field_314).AutoSize = true;
                ((Control)field_314).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_314).ForeColor = Color.Blue;
                ((Control)field_314).Location = new Point(101, -1);
                ((Control)field_314).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_314).Name = "label17";
                ((Control)field_314).RightToLeft = (RightToLeft)0;
                ((Control)field_314).Size = new Size(23, 15);
                ((Control)field_314).TabIndex = 73;
                ((Control)field_314).Text = "2G";
                field_314.TextAlign = (ContentAlignment)64;
                ((Control)field_315).Anchor = (AnchorStyles)10;
                ((Control)field_315).BackColor = Color.Transparent;
                field_315.BaseColor = Color.White;
                field_315.BorderColor = Color.Silver;
                field_315.BorderSize = 1;
                ((ComboBox)field_315).DrawMode = (DrawMode)1;
                ((ComboBox)field_315).DropDownStyle = (ComboBoxStyle)2;
                field_315.FocusedColor = Color.Empty;
                ((Control)field_315).Font = UiFonts.Create(10f);
                ((Control)field_315).ForeColor = Color.Black;
                ((ComboBox)field_315).Items.AddRange(new object[11]
                {
                        "auto",
                        "1",
                        "2",
                        "3",
                        "4",
                        "5",
                        "6",
                        "7",
                        "8",
                        "9",
                        "11"
                });
                ((Control)field_315).Location = new Point(52, 18);
                ((Control)field_315).Name = "comboBox2G_channel";
                field_315.OnHoverItemBaseColor = Color.FromArgb(100, 88, 255);
                field_315.OnHoverItemForeColor = Color.White;
                field_315.Radius = 9;
                ((Control)field_315).Size = new Size(77, 26);
                ((Control)field_315).TabIndex = 14;
                field_284.SetToolTip((Control)(object)field_315, "قناة التردد 2");
                ((Control)field_316).Anchor = (AnchorStyles)10;
                ((Control)field_316).BackColor = Color.Transparent;
                field_316.BaseColor = Color.MintCream;
                field_316.BorderColor = Color.DimGray;
                field_316.BorderSize = 1;
                ((Control)field_316).Cursor = Cursors.IBeam;
                ((Control)field_316).Enabled = false;
                field_316.FocusedBaseColor = Color.White;
                field_316.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_316.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_316).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_316).ForeColor = Color.Black;
                ((Control)field_316).Location = new Point(26, 51);
                ((Control)field_316).Name = "gunaTextBox1";
                field_316.PasswordChar = '\0';
                field_316.Radius = 9;
                ((Control)field_316).RightToLeft = (RightToLeft)0;
                field_316.SelectedText = "";
                ((Control)field_316).Size = new Size(105, 26);
                ((Control)field_316).TabIndex = 13;
                field_316.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_316, "كلمة مرور البث بالتردد 2 في حال اردتها شبكه محميه");
                ((Control)field_316).TextChanged += method_420;
                ((Control)field_317).Anchor = (AnchorStyles)10;
                ((Control)field_317).AutoSize = true;
                ((Control)field_317).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_317).Location = new Point(134, 24);
                ((Control)field_317).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_317).Name = "label24";
                ((Control)field_317).Size = new Size(33, 15);
                ((Control)field_317).TabIndex = 30;
                ((Control)field_317).Text = "القناة";
                field_317.TextAlign = (ContentAlignment)64;
                ((Control)field_318).Anchor = (AnchorStyles)10;
                ((Control)field_318).AutoSize = true;
                ((Control)field_318).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_318).Location = new Point(137, 57);
                ((Control)field_318).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_318).Name = "label27";
                ((Control)field_318).Size = new Size(30, 15);
                ((Control)field_318).TabIndex = 27;
                ((Control)field_318).Text = "الرمز";
                field_318.TextAlign = (ContentAlignment)64;
                ((Control)field_290).Anchor = (AnchorStyles)9;
                field_290.BaseColor = Color.Transparent;
                field_290.Checked = true;
                field_290.CheckedOffColor = Color.Gray;
                field_290.CheckedOnColor = Color.FromArgb(64, 0, 0);
                field_290.FillColor = Color.White;
                ((Control)field_290).Font = UiFonts.Create(8f);
                ((Control)field_290).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_290).Location = new Point(339, 178);
                ((Control)field_290).Name = "cb_AutoNumbering";
                ((Control)field_290).RightToLeft = (RightToLeft)1;
                ((Control)field_290).Size = new Size(197, 20);
                ((Control)field_290).TabIndex = 60;
                ((Control)field_290).Text = "تعديل تلقائي للرقم بحسب رقم الفيلان";
                field_290.CheckedChanged += method_408;
                ((Control)field_268).Anchor = (AnchorStyles)6;
                field_268.AnimationHoverSpeed = 0.07f;
                field_268.AnimationSpeed = 0.03f;
                ((Control)field_268).BackColor = Color.Transparent;
                ((Control)field_268).BackgroundImageLayout = (ImageLayout)2;
                field_268.BaseColor = Color.Maroon;
                field_268.BorderColor = Color.Black;
                field_268.DialogResult = (DialogResult)0;
                field_268.FocusedColor = Color.Empty;
                ((Control)field_268).Font = UiFonts.Create(9f);
                ((Control)field_268).ForeColor = Color.White;
                field_268.Image = (Image)(object)ImageCache.method_587();
                field_268.ImageSize = new Size(33, 33);
                ((Control)field_268).Location = new Point(283, 301);
                ((Control)field_268).Name = "button2";
                field_268.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_268.OnHoverBorderColor = Color.Black;
                field_268.OnHoverForeColor = Color.White;
                field_268.OnHoverImage = null;
                field_268.OnPressedColor = Color.Black;
                ((Control)field_268).Size = new Size(50, 50);
                ((Control)field_268).TabIndex = 51;
                field_284.SetToolTip((Control)(object)field_268, "تحديث الجهاز وتركيب اضافات");
                ((Control)field_268).Click += method_386;
                ((Control)field_287).Anchor = (AnchorStyles)6;
                field_287.AnimationHoverSpeed = 0.07f;
                field_287.AnimationSpeed = 0.03f;
                ((Control)field_287).BackColor = Color.Transparent;
                ((Control)field_287).BackgroundImageLayout = (ImageLayout)2;
                field_287.BaseColor = Color.Black;
                field_287.BorderColor = Color.Black;
                field_287.DialogResult = (DialogResult)0;
                field_287.FocusedColor = Color.Empty;
                ((Control)field_287).Font = UiFonts.Create(9f);
                ((Control)field_287).ForeColor = Color.White;
                field_287.Image = (Image)(object)ImageCache.method_603();
                field_287.ImageSize = new Size(33, 33);
                ((Control)field_287).Location = new Point(238, 306);
                ((Control)field_287).Name = "buttonTerminal";
                field_287.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_287.OnHoverBorderColor = Color.Black;
                field_287.OnHoverForeColor = Color.White;
                field_287.OnHoverImage = null;
                field_287.OnPressedColor = Color.Black;
                ((Control)field_287).Size = new Size(40, 40);
                ((Control)field_287).TabIndex = 59;
                field_284.SetToolTip((Control)(object)field_287, "موجه أوامر الراوتر (تيرمنال)");
                ((Control)field_287).Click += method_390;
                ((Control)field_286).Anchor = (AnchorStyles)6;
                field_286.AnimationHoverSpeed = 0.07f;
                field_286.AnimationSpeed = 0.03f;
                ((Control)field_286).BackColor = Color.Transparent;
                ((Control)field_286).BackgroundImageLayout = (ImageLayout)2;
                field_286.BaseColor = Color.Red;
                field_286.BorderColor = Color.Black;
                field_286.DialogResult = (DialogResult)0;
                field_286.FocusedColor = Color.Empty;
                ((Control)field_286).Font = UiFonts.Create(9f);
                ((Control)field_286).ForeColor = Color.White;
                field_286.Image = (Image)(object)ImageCache.method_595();
                field_286.ImageSize = new Size(30, 30);
                ((Control)field_286).Location = new Point(193, 306);
                ((Control)field_286).Name = "buttonFactoryReset";
                field_286.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_286.OnHoverBorderColor = Color.Black;
                field_286.OnHoverForeColor = Color.White;
                field_286.OnHoverImage = null;
                field_286.OnPressedColor = Color.Black;
                ((Control)field_286).Size = new Size(40, 40);
                ((Control)field_286).TabIndex = 58;
                field_284.SetToolTip((Control)(object)field_286, "استعادة ضبط المصنع للجهاز");
                ((Control)field_286).Click += method_389;
                ((Control)field_256).Anchor = (AnchorStyles)6;
                ((Control)field_256).BackColor = Color.Linen;
                ((Control)field_256).Controls.Add((Control)(object)field_270);
                ((Control)field_256).Controls.Add((Control)(object)field_336);
                ((Control)field_256).Controls.Add((Control)(object)field_325);
                ((Control)field_256).Controls.Add((Control)(object)field_326);
                ((Control)field_256).Controls.Add((Control)(object)field_320);
                ((Control)field_256).Controls.Add((Control)(object)field_322);
                ((Control)field_256).Controls.Add((Control)(object)field_323);
                ((Control)field_256).Controls.Add((Control)(object)field_311);
                ((Control)field_256).Controls.Add((Control)(object)field_312);
                ((Control)field_256).Controls.Add((Control)(object)field_299);
                ((Control)field_256).Controls.Add((Control)(object)field_272);
                ((Control)field_256).Controls.Add((Control)(object)field_271);
                ((Control)field_256).Controls.Add((Control)(object)field_257);
                ((Control)field_256).Controls.Add((Control)(object)field_258);
                ((Control)field_256).Controls.Add((Control)(object)field_259);
                ((Control)field_256).Font = UiFonts.Create(9f);
                ((Control)field_256).ForeColor = Color.Maroon;
                ((Control)field_256).Location = new Point(186, 3);
                ((Control)field_256).Name = "GB_Set5G";
                ((Control)field_256).RightToLeft = (RightToLeft)1;
                ((Control)field_256).Size = new Size(504, 87);
                ((Control)field_256).TabIndex = 44;
                field_256.TabStop = false;
                ((Control)field_256).Text = "اعدادات         - الربط اللاسلكي ( MESH & WDS )";
                ((Control)field_325).Anchor = (AnchorStyles)9;
                field_325.BaseColor = SystemColors.Control;
                field_325.CheckedOffColor = Color.DarkGray;
                field_325.CheckedOnColor = Color.FromArgb(192, 0, 0);
                field_325.FillColor = Color.White;
                ((Control)field_325).Location = new Point(469, 21);
                ((Control)field_325).Name = "cb_WDS_AP_Enable";
                ((Control)field_325).Size = new Size(28, 20);
                ((Control)field_325).TabIndex = 78;
                field_284.SetToolTip((Control)(object)field_325, "برمجة التردد 5 ارسال للإستقبال منه لاسلكيا بأكسس آخر\r\n");
                field_325.CheckedChanged += method_409;
                ((Control)field_326).Anchor = (AnchorStyles)10;
                ((Control)field_326).AutoSize = true;
                ((Control)field_326).Font = UiFonts.Create(9f);
                ((Control)field_326).ForeColor = Color.Maroon;
                ((Control)field_326).Location = new Point(411, 24);
                ((Control)field_326).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_326).Name = "label1";
                ((Control)field_326).RightToLeft = (RightToLeft)0;
                ((Control)field_326).Size = new Size(59, 15);
                ((Control)field_326).TabIndex = 77;
                ((Control)field_326).Text = "wds ارسال";
                field_326.TextAlign = (ContentAlignment)64;
                ((Control)field_320).Anchor = (AnchorStyles)9;
                field_320.BaseColor = SystemColors.Control;
                field_320.CheckedOffColor = Color.DarkGray;
                field_320.CheckedOnColor = Color.FromArgb(192, 0, 0);
                field_320.FillColor = Color.White;
                ((Control)field_320).Location = new Point(274, 21);
                ((Control)field_320).Name = "cb_Mesh_Enable";
                ((Control)field_320).Size = new Size(28, 20);
                ((Control)field_320).TabIndex = 74;
                field_284.SetToolTip((Control)(object)field_320, "برمجة التردد 5 بطريقة ربط الميش\r\nهذه الخاصيه عباره عن مجموعة اجهزه مبرمجه بنفس اسم الميش ونفس القناه\r\n وتترابط فيما بينها لاسلكيا ويجب ان يكون احد الأجهزه فقط متصل بواسطة سلك من الشبكة.\r\n");
                field_320.CheckedChanged += method_409;
                ((Control)field_322).Anchor = (AnchorStyles)9;
                field_322.BaseColor = SystemColors.Control;
                field_322.CheckedOffColor = Color.DarkGray;
                field_322.CheckedOnColor = Color.FromArgb(192, 0, 0);
                field_322.FillColor = Color.White;
                ((Control)field_322).Location = new Point(377, 21);
                ((Control)field_322).Name = "cb_WDS_Client_Enable";
                ((Control)field_322).Size = new Size(28, 20);
                ((Control)field_322).TabIndex = 72;
                field_284.SetToolTip((Control)(object)field_322, "برمجة التردد 5 استقبال لاسلكي من انتينه او اكسس مبرمج ارسال\r\n");
                field_322.CheckedChanged += method_409;
                ((Control)field_323).Anchor = (AnchorStyles)10;
                ((Control)field_323).AutoSize = true;
                ((Control)field_323).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_323).ForeColor = Color.Maroon;
                ((Control)field_323).Location = new Point(432, -1);
                ((Control)field_323).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_323).Name = "label15";
                ((Control)field_323).RightToLeft = (RightToLeft)0;
                ((Control)field_323).Size = new Size(23, 15);
                ((Control)field_323).TabIndex = 73;
                ((Control)field_323).Text = "5G";
                field_323.TextAlign = (ContentAlignment)64;
                ((Control)field_311).Anchor = (AnchorStyles)10;
                ((Control)field_311).BackColor = Color.Transparent;
                field_311.BaseColor = Color.White;
                field_311.BorderColor = Color.Silver;
                field_311.BorderSize = 1;
                ((ComboBox)field_311).DrawMode = (DrawMode)1;
                ((ComboBox)field_311).DropDownStyle = (ComboBoxStyle)2;
                field_311.FocusedColor = Color.Empty;
                ((Control)field_311).Font = UiFonts.Create(10f);
                ((Control)field_311).ForeColor = Color.Black;
                ((ListControl)field_311).FormattingEnabled = true;
                ((ComboBox)field_311).Items.AddRange(new object[3]
                {
                        "20",
                        "40",
                        "80"
                });
                ((Control)field_311).Location = new Point(7, 18);
                ((Control)field_311).Name = "comboBoxN_channelWidth";
                field_311.OnHoverItemBaseColor = Color.FromArgb(100, 88, 255);
                field_311.OnHoverItemForeColor = Color.White;
                field_311.Radius = 9;
                ((Control)field_311).Size = new Size(85, 26);
                ((Control)field_311).TabIndex = 72;
                field_284.SetToolTip((Control)(object)field_311, "عرض القناه بالتردد 5");
                ((ComboBox)field_311).SelectedIndexChanged += method_414;
                ((Control)field_312).Anchor = (AnchorStyles)10;
                ((Control)field_312).AutoSize = true;
                ((Control)field_312).Enabled = false;
                ((Control)field_312).Font = UiFonts.Create(9f);
                ((Control)field_312).ForeColor = Color.Maroon;
                ((Control)field_312).Location = new Point(308, 24);
                ((Control)field_312).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_312).Name = "label13";
                ((Control)field_312).RightToLeft = (RightToLeft)0;
                ((Control)field_312).Size = new Size(69, 15);
                ((Control)field_312).TabIndex = 71;
                ((Control)field_312).Text = "wds استقبال";
                field_312.TextAlign = (ContentAlignment)64;
                ((Control)field_299).Anchor = (AnchorStyles)10;
                ((Control)field_299).AutoSize = true;
                ((Control)field_299).Font = UiFonts.Create(9f);
                ((Control)field_299).ForeColor = Color.Maroon;
                ((Control)field_299).Location = new Point(237, 24);
                ((Control)field_299).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_299).Name = "label4";
                ((Control)field_299).RightToLeft = (RightToLeft)0;
                ((Control)field_299).Size = new Size(32, 15);
                ((Control)field_299).TabIndex = 69;
                ((Control)field_299).Text = "ميش";
                field_299.TextAlign = (ContentAlignment)64;
                ((Control)field_272).Anchor = (AnchorStyles)10;
                ((Control)field_272).BackColor = Color.Transparent;
                field_272.BaseColor = Color.White;
                field_272.BorderColor = Color.Silver;
                field_272.BorderSize = 1;
                ((ComboBox)field_272).DrawMode = (DrawMode)1;
                ((ComboBox)field_272).DropDownStyle = (ComboBoxStyle)2;
                field_272.FocusedColor = Color.Empty;
                ((Control)field_272).Font = UiFonts.Create(10f);
                ((Control)field_272).ForeColor = Color.Black;
                ((ListControl)field_272).FormattingEnabled = true;
                ((Control)field_272).Location = new Point(97, 19);
                ((Control)field_272).Name = "comboBoxN_channel";
                field_272.OnHoverItemBaseColor = Color.FromArgb(100, 88, 255);
                field_272.OnHoverItemForeColor = Color.White;
                field_272.Radius = 9;
                ((Control)field_272).Size = new Size(79, 26);
                ((Control)field_272).TabIndex = 14;
                field_284.SetToolTip((Control)(object)field_272, "القناه التي سيتم استخدامها تردد 5 بشكل عام\r\nملاحظة : في برمجة الارسال والاستقبال والميش يجب ان تكون كل اجهزة المجموعه مبرمجه بنفس القناه");
                ((Control)field_270).Anchor = (AnchorStyles)10;
                ((Control)field_270).BackColor = Color.Transparent;
                field_270.BaseColor = Color.MintCream;
                field_270.BorderColor = Color.DimGray;
                field_270.BorderSize = 1;
                ((Control)field_270).Cursor = Cursors.IBeam;
                field_270.FocusedBaseColor = Color.White;
                field_270.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_270.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_270).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_270).ForeColor = Color.Black;
                ((Control)field_270).Location = new Point(7, 51);
                ((Control)field_270).Name = "textBoxN_MeshP";
                field_270.PasswordChar = '\0';
                field_270.Radius = 9;
                ((Control)field_270).RightToLeft = (RightToLeft)0;
                field_270.SelectedText = "";
                ((Control)field_270).Size = new Size(105, 26);
                ((Control)field_270).TabIndex = 13;
                field_270.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_270, "كلمة مرور الربط\r\nفي حال كانت البرمجه ميش والجهاز لايدعم الارتباط المحمي اجعل كلمة المرور فارغه ليتم البرمجه بدون كلمة مرور");
                ((Control)field_270).TextChanged += method_419;
                ((Control)field_271).Anchor = (AnchorStyles)10;
                field_271.AutoCompleteMode = (AutoCompleteMode)3;
                field_271.AutoCompleteSource = (AutoCompleteSource)2;
                ((Control)field_271).BackColor = Color.Transparent;
                field_271.BaseColor = Color.FloralWhite;
                field_271.BorderColor = Color.DimGray;
                field_271.BorderSize = 1;
                ((Control)field_271).Cursor = Cursors.IBeam;
                field_271.FocusedBaseColor = SystemColors.Window;
                field_271.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_271.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_271).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_271).ForeColor = Color.Black;
                ((Control)field_271).Location = new Point(158, 51);
                ((Control)field_271).Name = "textBoxN_MeshN";
                field_271.PasswordChar = '\0';
                field_271.Radius = 9;
                ((Control)field_271).RightToLeft = (RightToLeft)0;
                field_271.SelectedText = "";
                ((Control)field_271).Size = new Size(231, 26);
                ((Control)field_271).TabIndex = 12;
                ((Control)field_271).Text = "AP5";
                field_284.SetToolTip((Control)(object)field_271, "اسم شبكة الإرسال\r\nيفضل البرمجه بإسم قصير يدل على اسم شبكتك واضافة رقم الأكسس \r\nمثلا اذا كان اسم الأكسس AmaanTelecom-6 فيمكن تسمية شبكة الارسال am6 ليسهل حفظ الإسم عند برمجة المستقبلات\r\n");
                ((Control)field_257).Anchor = (AnchorStyles)10;
                ((Control)field_257).AutoSize = true;
                ((Control)field_257).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_257).Location = new Point(181, 24);
                ((Control)field_257).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_257).Name = "label14";
                ((Control)field_257).Size = new Size(33, 15);
                ((Control)field_257).TabIndex = 30;
                ((Control)field_257).Text = "القناة";
                field_257.TextAlign = (ContentAlignment)64;
                ((Control)field_258).Anchor = (AnchorStyles)10;
                ((Control)field_258).AutoSize = true;
                ((Control)field_258).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_258).Location = new Point(124, 57);
                ((Control)field_258).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_258).Name = "LBL_MESH_P";
                ((Control)field_258).Size = new Size(30, 15);
                ((Control)field_258).TabIndex = 27;
                ((Control)field_258).Text = "الرمز";
                field_258.TextAlign = (ContentAlignment)64;
                ((Control)field_259).Anchor = (AnchorStyles)10;
                ((Control)field_259).AutoSize = true;
                ((Control)field_259).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_259).Location = new Point(394, 57);
                ((Control)field_259).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_259).Name = "label12";
                ((Control)field_259).Size = new Size(105, 15);
                ((Control)field_259).TabIndex = 25;
                ((Control)field_259).Text = "اسم مجموعة الميش";
                field_259.TextAlign = (ContentAlignment)64;
                ((Control)field_285).Anchor = (AnchorStyles)6;
                field_285.AnimationHoverSpeed = 0.07f;
                field_285.AnimationSpeed = 0.03f;
                ((Control)field_285).BackColor = Color.Transparent;
                ((Control)field_285).BackgroundImageLayout = (ImageLayout)2;
                field_285.BaseColor = Color.DimGray;
                field_285.BorderColor = Color.Black;
                field_285.DialogResult = (DialogResult)0;
                field_285.FocusedColor = Color.Empty;
                ((Control)field_285).Font = UiFonts.Create(9f);
                ((Control)field_285).ForeColor = Color.White;
                field_285.Image = (Image)(object)ImageCache.method_582();
                field_285.ImageSize = new Size(35, 35);
                ((Control)field_285).Location = new Point(104, 306);
                ((Control)field_285).Name = "buttonMakeBackup";
                field_285.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_285.OnHoverBorderColor = Color.Black;
                field_285.OnHoverForeColor = Color.White;
                field_285.OnHoverImage = null;
                field_285.OnPressedColor = Color.Black;
                ((Control)field_285).Size = new Size(40, 40);
                ((Control)field_285).TabIndex = 57;
                field_284.SetToolTip((Control)(object)field_285, "حفظ نسخه احتياطيه للبرمجه الحاليه للرجوع لها وقت الحاجه");
                ((Control)field_285).Click += method_387;
                ((Control)field_269).Anchor = (AnchorStyles)6;
                field_269.AnimationHoverSpeed = 0.07f;
                field_269.AnimationSpeed = 0.03f;
                ((Control)field_269).BackColor = Color.Transparent;
                ((Control)field_269).BackgroundImageLayout = (ImageLayout)2;
                field_269.BaseColor = Color.Olive;
                field_269.BorderColor = Color.Black;
                field_269.DialogResult = (DialogResult)0;
                field_269.FocusedColor = Color.Empty;
                ((Control)field_269).Font = UiFonts.Create(9f);
                ((Control)field_269).ForeColor = Color.White;
                field_269.Image = (Image)(object)ImageCache.method_590();
                field_269.ImageSize = new Size(33, 33);
                ((Control)field_269).Location = new Point(14, 306);
                ((Control)field_269).Name = "buttonSettingImp";
                field_269.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_269.OnHoverBorderColor = Color.Black;
                field_269.OnHoverForeColor = Color.White;
                field_269.OnHoverImage = null;
                field_269.OnPressedColor = Color.Black;
                ((Control)field_269).Size = new Size(40, 40);
                ((Control)field_269).TabIndex = 50;
                field_284.SetToolTip((Control)(object)field_269, "تعبئة الحقول من نموذج محفوظ سابقا ..");
                ((Control)field_269).Click += method_385;
                ((Control)field_251).BackColor = Color.White;
                ((Control)field_251).Controls.Add((Control)(object)field_255);
                ((Control)field_251).Controls.Add((Control)(object)field_253);
                ((Control)field_251).Controls.Add((Control)(object)field_319);
                ((Control)field_251).Controls.Add((Control)(object)field_254);
                ((Control)field_251).Controls.Add((Control)(object)field_321);
                ((Control)field_251).Controls.Add((Control)(object)field_252);
                ((Control)field_251).Controls.Add((Control)(object)field_249);
                ((Control)field_251).Font = UiFonts.Create(10f, (FontStyle)1);
                ((Control)field_251).Location = new Point(7, 96);
                ((Control)field_251).Name = "groupBox1";
                ((Control)field_251).RightToLeft = (RightToLeft)1;
                ((Control)field_251).Size = new Size(683, 82);
                ((Control)field_251).TabIndex = 30;
                field_251.TabStop = false;
                ((Control)field_251).Text = "اسم الشبكه";
                field_255.BaseColor = Color.Transparent;
                field_255.CheckedOffColor = Color.Gray;
                field_255.CheckedOnColor = Color.FromArgb(64, 0, 0);
                field_255.FillColor = Color.White;
                ((Control)field_255).Font = UiFonts.Create(9f);
                ((Control)field_255).Location = new Point(300, 28);
                ((Control)field_255).Name = "cb_5GName";
                ((Control)field_255).RightToLeft = (RightToLeft)1;
                ((Control)field_255).Size = new Size(85, 20);
                ((Control)field_255).TabIndex = 33;
                ((Control)field_255).Text = "اسم مشابه";
                ((Control)field_253).Anchor = (AnchorStyles)9;
                ((Control)field_253).BackColor = Color.Maroon;
                ((Control)field_253).Font = UiFonts.Create(9.75f);
                ((Control)field_253).ForeColor = Color.White;
                ((Control)field_253).Location = new Point(612, 20);
                ((Control)field_253).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_253).Name = "label5G";
                ((Control)field_253).RightToLeft = (RightToLeft)0;
                ((Control)field_253).Size = new Size(59, 34);
                ((Control)field_253).TabIndex = 30;
                ((Control)field_253).Text = "5G";
                field_253.TextAlign = (ContentAlignment)32;
                ((Control)field_319).Anchor = (AnchorStyles)9;
                field_319.BaseColor = SystemColors.Control;
                field_319.Checked = true;
                field_319.CheckedOffColor = Color.DarkGray;
                field_319.CheckedOnColor = Color.FromArgb(192, 0, 0);
                field_319.FillColor = Color.White;
                ((Control)field_319).Location = new Point(642, 56);
                ((Control)field_319).Name = "cb_5G_Enable";
                ((Control)field_319).Size = new Size(28, 20);
                ((Control)field_319).TabIndex = 76;
                field_284.SetToolTip((Control)(object)field_319, "تفعيل البث للمستخدمين بالتردد 5");
                ((Control)field_254).BackColor = Color.Transparent;
                field_254.BaseColor = Color.Linen;
                field_254.BorderColor = Color.Maroon;
                field_254.BorderSize = 1;
                ((Control)field_254).Cursor = Cursors.IBeam;
                field_254.FocusedBaseColor = Color.White;
                field_254.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_254.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_254).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_254).ForeColor = Color.Black;
                ((Control)field_254).Location = new Point(393, 20);
                ((Control)field_254).Name = "textBoxN_SSID5";
                field_254.PasswordChar = '\0';
                field_254.Radius = 11;
                ((Control)field_254).RightToLeft = (RightToLeft)0;
                field_254.SelectedText = "";
                ((Control)field_254).Size = new Size(227, 34);
                ((Control)field_254).TabIndex = 7;
                ((Control)field_254).Text = "AMAAN-2";
                field_254.TextOffsetX = 11;
                field_284.SetToolTip((Control)(object)field_254, "اسم الشبكة بتردد 5 جيجا");
                ((Control)field_321).Anchor = (AnchorStyles)10;
                ((Control)field_321).AutoSize = true;
                ((Control)field_321).Font = UiFonts.Create(9f);
                ((Control)field_321).ForeColor = Color.Maroon;
                ((Control)field_321).Location = new Point(576, 59);
                ((Control)field_321).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_321).Name = "label20";
                ((Control)field_321).RightToLeft = (RightToLeft)0;
                ((Control)field_321).Size = new Size(61, 15);
                ((Control)field_321).TabIndex = 75;
                ((Control)field_321).Text = "تفعيل البث";
                field_321.TextAlign = (ContentAlignment)64;
                ((Control)field_252).Anchor = (AnchorStyles)9;
                ((Control)field_252).BackColor = Color.Navy;
                ((Control)field_252).Font = UiFonts.Create(9.75f);
                ((Control)field_252).ForeColor = Color.White;
                ((Control)field_252).Location = new Point(13, 20);
                ((Control)field_252).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_252).Name = "label7";
                ((Control)field_252).RightToLeft = (RightToLeft)0;
                ((Control)field_252).Size = new Size(59, 34);
                ((Control)field_252).TabIndex = 19;
                ((Control)field_252).Text = "2G";
                field_252.TextAlign = (ContentAlignment)32;
                ((Control)field_249).BackColor = Color.Transparent;
                field_249.BaseColor = Color.WhiteSmoke;
                field_249.BorderColor = Color.Navy;
                field_249.BorderSize = 1;
                ((Control)field_249).Cursor = Cursors.IBeam;
                field_249.FocusedBaseColor = Color.White;
                field_249.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_249.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_249).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_249).ForeColor = Color.Black;
                ((Control)field_249).Location = new Point(62, 20);
                ((Control)field_249).Name = "textBoxN_SSID2";
                field_249.PasswordChar = '\0';
                field_249.Radius = 11;
                ((Control)field_249).RightToLeft = (RightToLeft)0;
                field_249.SelectedText = "";
                ((Control)field_249).Size = new Size(224, 34);
                ((Control)field_249).TabIndex = 6;
                ((Control)field_249).Text = "AMAAN-{2}";
                field_249.TextOffsetX = 11;
                field_284.SetToolTip((Control)(object)field_249, "اسم الشبكة بتردد 2.4 جيجا");
                ((Control)field_249).TextChanged += method_344;
                ((Control)field_250).Anchor = (AnchorStyles)6;
                field_250.AnimationHoverSpeed = 0.07f;
                field_250.AnimationSpeed = 0.03f;
                ((Control)field_250).BackColor = Color.Transparent;
                field_250.BaseColor = Color.Red;
                field_250.BorderColor = Color.Black;
                field_250.DialogResult = (DialogResult)0;
                field_250.FocusedColor = Color.Empty;
                ((Control)field_250).Font = UiFonts.Create(14f, (FontStyle)1);
                ((Control)field_250).ForeColor = Color.White;
                field_250.Image = (Image)(object)ImageCache.method_585();
                field_250.ImageSize = new Size(30, 30);
                ((Control)field_250).Location = new Point(339, 307);
                ((Control)field_250).Name = "buttonSend";
                field_250.OnHoverBaseColor = Color.Red;
                field_250.OnHoverBorderColor = Color.Black;
                field_250.OnHoverForeColor = Color.White;
                field_250.OnHoverImage = null;
                field_250.OnPressedColor = Color.Black;
                field_250.Radius = 8;
                ((Control)field_250).Size = new Size(350, 40);
                ((Control)field_250).TabIndex = 15;
                ((Control)field_250).Text = "حفظ الاعدادت في الجهاز";
                field_250.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_250, "حفظ البرمجه بشكل نهائي في الجهاز");
                ((Control)field_250).Click += method_342;
                ((Control)field_202).Anchor = (AnchorStyles)6;
                field_202.AnimationHoverSpeed = 0.07f;
                field_202.AnimationSpeed = 0.03f;
                ((Control)field_202).BackColor = Color.Transparent;
                ((Control)field_202).BackgroundImageLayout = (ImageLayout)2;
                field_202.BaseColor = Color.DarkGreen;
                field_202.BorderColor = Color.Black;
                field_202.DialogResult = (DialogResult)0;
                field_202.FocusedColor = Color.Empty;
                ((Control)field_202).Font = UiFonts.Create(9f);
                ((Control)field_202).ForeColor = Color.White;
                field_202.Image = (Image)(object)ImageCache.method_596();
                field_202.ImageSize = new Size(30, 30);
                ((Control)field_202).Location = new Point(59, 306);
                ((Control)field_202).Name = "buttonSettingReg";
                field_202.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_202.OnHoverBorderColor = Color.Black;
                field_202.OnHoverForeColor = Color.White;
                field_202.OnHoverImage = null;
                field_202.OnPressedColor = Color.Black;
                ((Control)field_202).Size = new Size(40, 40);
                ((Control)field_202).TabIndex = 19;
                field_284.SetToolTip((Control)(object)field_202, "حفظ نموذج البيانات المدخله في الحقول لإستخدامها لاحقا ..");
                ((Control)field_202).Click += method_384;
                ((Control)field_292).Controls.Add((Control)(object)field_330);
                ((Control)field_292).Controls.Add((Control)(object)field_293);
                ((Control)field_292).Controls.Add((Control)(object)field_294);
                ((Control)field_292).Controls.Add((Control)(object)field_295);
                ((Control)field_292).Controls.Add((Control)(object)field_296);
                ((Control)field_292).Controls.Add((Control)(object)field_297);
                ((Control)field_292).Controls.Add((Control)(object)field_298);
                ((Control)field_292).Font = UiFonts.Create(8f, (FontStyle)1);
                ((Control)field_292).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_292).Location = new Point(7, 255);
                ((Control)field_292).Name = "GB_ExtraSettings";
                ((Control)field_292).RightToLeft = (RightToLeft)1;
                ((Control)field_292).Size = new Size(683, 40);
                ((Control)field_292).TabIndex = 67;
                field_292.TabStop = false;
                ((Control)field_292).Text = "اعدادات خاصه";
                ((Control)field_292).Enter += method_410;
                field_330.BaseColor = Color.Transparent;
                field_330.Checked = true;
                field_330.CheckedOffColor = Color.Gray;
                field_330.CheckedOnColor = Color.Firebrick;
                field_330.FillColor = Color.White;
                ((Control)field_330).Font = UiFonts.Create(8.5f);
                ((Control)field_330).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_330).Location = new Point(448, 14);
                ((Control)field_330).Name = "cb_Ext_Fix";
                ((Control)field_330).RightToLeft = (RightToLeft)1;
                ((Control)field_330).Size = new Size(124, 20);
                ((Control)field_330).TabIndex = 67;
                ((Control)field_330).Text = "اصلاحات خاصه بالجهاز";
                field_284.SetToolTip((Control)(object)field_330, "برمجة اعدادات اضافيه خاصه بحسب موديل الجهاز لتحسين عمله مثل تعديل الماكات ونعديل السويتش وغيره");
                field_293.BaseColor = Color.Transparent;
                field_293.CheckedOffColor = Color.Gray;
                field_293.CheckedOnColor = Color.Firebrick;
                field_293.FillColor = Color.White;
                ((Control)field_293).Font = UiFonts.Create(8.5f);
                ((Control)field_293).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_293).Location = new Point(573, 14);
                ((Control)field_293).Name = "cb_Ext_Add_WAN";
                ((Control)field_293).RightToLeft = (RightToLeft)1;
                ((Control)field_293).Size = new Size(102, 20);
                ((Control)field_293).TabIndex = 65;
                ((Control)field_293).Text = "wan تشغيل منفذ";
                field_284.SetToolTip((Control)(object)field_293, "تفعيل منفذ وان ليعمل مع باقي المنافذ");
                field_294.BaseColor = Color.Transparent;
                field_294.Checked = true;
                field_294.CheckedOffColor = Color.Gray;
                field_294.CheckedOnColor = Color.Firebrick;
                field_294.FillColor = Color.White;
                ((Control)field_294).Font = UiFonts.Create(8.5f);
                ((Control)field_294).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_294).Location = new Point(200, 14);
                ((Control)field_294).Name = "cb_Ext_DisIPv6";
                ((Control)field_294).RightToLeft = (RightToLeft)1;
                ((Control)field_294).Size = new Size(75, 20);
                ((Control)field_294).TabIndex = 66;
                ((Control)field_294).Text = "ايقاف IPv6 ";
                field_295.BaseColor = Color.Transparent;
                field_295.Checked = true;
                field_295.CheckedOffColor = Color.Gray;
                field_295.CheckedOnColor = Color.Firebrick;
                field_295.FillColor = Color.White;
                ((Control)field_295).Font = UiFonts.Create(8.5f);
                ((Control)field_295).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_295).Location = new Point(104, 14);
                ((Control)field_295).Name = "cb_Ext_DisDHCPv4";
                ((Control)field_295).RightToLeft = (RightToLeft)1;
                ((Control)field_295).Size = new Size(96, 20);
                ((Control)field_295).TabIndex = 61;
                ((Control)field_295).Text = "تعطيل DHCP 4";
                field_296.BaseColor = Color.Transparent;
                field_296.Checked = true;
                field_296.CheckedOffColor = Color.Gray;
                field_296.CheckedOnColor = Color.Firebrick;
                field_296.FillColor = Color.White;
                ((Control)field_296).Font = UiFonts.Create(8.5f);
                ((Control)field_296).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_296).Location = new Point(9, 14);
                ((Control)field_296).Name = "cb_Ext_DisDHCPv6";
                ((Control)field_296).RightToLeft = (RightToLeft)1;
                ((Control)field_296).Size = new Size(96, 20);
                ((Control)field_296).TabIndex = 62;
                ((Control)field_296).Text = "تعطيل DHCP 6";
                field_297.BaseColor = Color.Transparent;
                field_297.Checked = true;
                field_297.CheckedOffColor = Color.Gray;
                field_297.CheckedOnColor = Color.Firebrick;
                field_297.FillColor = Color.White;
                ((Control)field_297).Font = UiFonts.Create(8.5f);
                ((Control)field_297).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_297).Location = new Point(354, 14);
                ((Control)field_297).Name = "cb_Ext_DisFirewall";
                ((Control)field_297).RightToLeft = (RightToLeft)1;
                ((Control)field_297).Size = new Size(98, 20);
                ((Control)field_297).TabIndex = 64;
                ((Control)field_297).Text = "تعطيل الفايروول";
                field_298.BaseColor = Color.Transparent;
                field_298.Checked = true;
                field_298.CheckedOffColor = Color.Gray;
                field_298.CheckedOnColor = Color.Firebrick;
                field_298.FillColor = Color.White;
                ((Control)field_298).Font = UiFonts.Create(8.5f);
                ((Control)field_298).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_298).Location = new Point(277, 14);
                ((Control)field_298).Name = "cb_Ext_DisNat";
                ((Control)field_298).RightToLeft = (RightToLeft)1;
                ((Control)field_298).Size = new Size(78, 20);
                ((Control)field_298).TabIndex = 63;
                ((Control)field_298).Text = "ايقاف النات";
                ((Control)field_277).Anchor = (AnchorStyles)6;
                field_277.AnimationHoverSpeed = 0.07f;
                field_277.AnimationSpeed = 0.03f;
                ((Control)field_277).BackColor = Color.Transparent;
                ((Control)field_277).BackgroundImageLayout = (ImageLayout)2;
                field_277.BaseColor = Color.FromArgb(64, 64, 64);
                field_277.BorderColor = Color.Black;
                field_277.DialogResult = (DialogResult)0;
                field_277.FocusedColor = Color.Empty;
                ((Control)field_277).Font = UiFonts.Create(9f);
                ((Control)field_277).ForeColor = Color.White;
                field_277.Image = null;
                field_277.ImageSize = new Size(33, 33);
                ((Control)field_277).Location = new Point(511, 5);
                ((Control)field_277).Name = "gunaCircleButton1";
                field_277.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_277.OnHoverBorderColor = Color.Black;
                field_277.OnHoverForeColor = Color.White;
                field_277.OnHoverImage = null;
                field_277.OnPressedColor = Color.Black;
                ((Control)field_277).Size = new Size(23, 23);
                ((Control)field_277).TabIndex = 56;
                ((Control)field_277).Visible = false;
                ((Control)field_277).Click += method_401;
                ((Control)field_233).AutoSize = true;
                ((Control)field_233).Font = UiFonts.Create(15f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
                ((Control)field_233).ForeColor = Color.Red;
                ((Control)field_233).Location = new Point(324, 3);
                ((Control)field_233).Name = "gunaLabel2";
                ((Control)field_233).Size = new Size(152, 28);
                ((Control)field_233).TabIndex = 63;
                ((Control)field_233).Text = "AmaanWRT v8.1.1";
                ((Control)field_233).MouseDown += method_340;
                ((Control)field_273).Anchor = (AnchorStyles)14;
                ((Control)field_273).Controls.Add((Control)(object)field_300);
                ((Control)field_273).Controls.Add((Control)(object)field_301);
                ((Control)field_273).Controls.Add((Control)(object)field_302);
                ((Control)field_273).Controls.Add((Control)(object)field_276);
                ((Control)field_273).Controls.Add((Control)(object)field_274);
                ((Control)field_273).Controls.Add((Control)(object)field_275);
                ((Control)field_273).Location = new Point(2, 504);
                ((Control)field_273).Name = "panel1";
                ((Control)field_273).Size = new Size(934, 25);
                ((Control)field_273).TabIndex = 64;
                ((Control)field_300).Anchor = (AnchorStyles)10;
                ((Control)field_300).AutoSize = true;
                ((Control)field_300).BackColor = Color.Transparent;
                ((Control)field_300).Font = UiFonts.Create(8f);
                ((Control)field_300).ForeColor = Color.Black;
                ((Control)field_300).Location = new Point(624, 7);
                ((Control)field_300).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_300).Name = "label8";
                ((Control)field_300).Size = new Size(11, 13);
                ((Control)field_300).TabIndex = 37;
                ((Control)field_300).Text = "-";
                field_300.TextAlign = (ContentAlignment)32;
                ((Control)field_301).Anchor = (AnchorStyles)10;
                ((Control)field_301).BackColor = Color.Transparent;
                ((Control)field_301).Font = UiFonts.Create(8f);
                ((Control)field_301).ForeColor = Color.Black;
                ((Control)field_301).Location = new Point(564, 4);
                ((Control)field_301).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_301).Name = "label6";
                ((Control)field_301).Size = new Size(62, 19);
                ((Control)field_301).TabIndex = 36;
                ((Control)field_301).Text = "777638900";
                field_301.TextAlign = (ContentAlignment)32;
                field_284.SetToolTip((Control)(object)field_301, "المهندس منير الشريف");
                ((Control)field_302).Anchor = (AnchorStyles)10;
                ((Control)field_302).BackColor = Color.Transparent;
                ((Control)field_302).Font = UiFonts.Create(8f);
                ((Control)field_302).ForeColor = Color.Black;
                ((Control)field_302).Location = new Point(636, 4);
                ((Control)field_302).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_302).Name = "label5";
                ((Control)field_302).Size = new Size(62, 19);
                ((Control)field_302).TabIndex = 35;
                ((Control)field_302).Text = "733996612";
                field_302.TextAlign = (ContentAlignment)32;
                field_284.SetToolTip((Control)(object)field_302, "المهندس جنيد باوزير (واتساب)");
                ((Control)field_276).Anchor = (AnchorStyles)14;
                ((Control)field_276).BackColor = SystemColors.Control;
                ((Control)field_276).Font = UiFonts.Create(9f);
                ((Control)field_276).ForeColor = Color.Black;
                ((Control)field_276).Location = new Point(116, 1);
                ((Control)field_276).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_276).Name = "infLBL_STATUS";
                ((Control)field_276).Padding = new Padding(5);
                ((Control)field_276).Size = new Size(430, 24);
                ((Control)field_276).TabIndex = 34;
                ((Control)field_276).Text = "--------------------------------------";
                field_276.TextAlign = (ContentAlignment)32;
                ((Control)field_274).Anchor = (AnchorStyles)6;
                ((Control)field_274).AutoSize = true;
                ((Control)field_274).Font = UiFonts.Create(10f, (FontStyle)1);
                ((Control)field_274).Location = new Point(3, 3);
                ((Control)field_274).Name = "linkLabel1";
                ((Control)field_274).RightToLeft = (RightToLeft)0;
                ((Control)field_274).Size = new Size(118, 17);
                ((Control)field_274).TabIndex = 33;
                field_274.TabStop = true;
                ((Control)field_274).Text = "@AmaanTelcom";
                ((Label)field_274).TextAlign = (ContentAlignment)4;
                field_284.SetToolTip((Control)(object)field_274, "تابع صفحتنا على الفيسبوك ليصلك كل جديد");
                ((Control)field_275).Anchor = (AnchorStyles)10;
                ((Control)field_275).BackColor = Color.Transparent;
                ((Control)field_275).Font = UiFonts.Create(8f);
                ((Control)field_275).ForeColor = Color.Black;
                ((Control)field_275).Location = new Point(692, 4);
                ((Control)field_275).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_275).Name = "label16";
                ((Control)field_275).RightToLeft = (RightToLeft)1;
                ((Control)field_275).Size = new Size(238, 19);
                ((Control)field_275).TabIndex = 32;
                ((Control)field_275).Text = "صنعاء, الدائري, جوار جامعة صنعاء الجديده   هاتف :";
                field_275.TextAlign = (ContentAlignment)16;
                ((Control)field_278).Anchor = (AnchorStyles)9;
                field_278.AnimationHoverSpeed = 0.07f;
                field_278.AnimationSpeed = 0.03f;
                ((Control)field_278).BackColor = Color.FromArgb(0, 0, 192);
                field_278.ControlBoxType = (FormControlBoxType)0;
                field_278.IconColor = Color.White;
                field_278.IconSize = 15f;
                ((Control)field_278).Location = new Point(37, 3);
                ((Control)field_278).Name = "gunaControlBox2";
                field_278.OnHoverBackColor = Color.FromArgb(103, 58, 183);
                field_278.OnHoverIconColor = Color.White;
                field_278.OnPressedColor = Color.Black;
                ((Control)field_278).Size = new Size(25, 25);
                ((Control)field_278).TabIndex = 65;
                ((ToolStrip)field_279).Items.AddRange(new ToolStripItem[6]
                {
                        (ToolStripItem)field_291,
                        (ToolStripItem)field_328,
                        (ToolStripItem)field_280,
                        (ToolStripItem)field_337,
                        (ToolStripItem)field_281,
                        (ToolStripItem)field_282
                });
                ((Control)field_279).Name = "gunaContextMenuStrip1";
                field_279.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
                field_279.RenderStyle.BorderColor = Color.Gainsboro;
                field_279.RenderStyle.ColorTable = null;
                ((ToolStripProfessionalRenderer)field_279.RenderStyle).RoundedEdges = true;
                field_279.RenderStyle.SelectionArrowColor = Color.White;
                field_279.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
                field_279.RenderStyle.SelectionForeColor = Color.White;
                field_279.RenderStyle.SeparatorColor = Color.Gainsboro;
                field_279.RenderStyle.TextRenderingHint = (DrawingTextRenderingHint)5;
                ((Control)field_279).Size = new Size(242, 148);
                ((ToolStripItem)field_291).BackColor = Color.FromArgb(192, 0, 0);
                ((ToolStripItem)field_291).Font = UiFonts.Create(11f, (FontStyle)1);
                ((ToolStripItem)field_291).ForeColor = Color.Yellow;
                ((ToolStripItem)field_291).Name = "tsmi_DirectUpgrade";
                ((ToolStripItem)field_291).Size = new Size(241, 24);
                ((ToolStripItem)field_291).Text = "تحديث سوفت بدون اتصال";
                ((ToolStripItem)field_291).Click += method_376;
                ((ToolStripItem)field_328).BackColor = Color.Blue;
                ((ToolStripItem)field_328).Font = UiFonts.Create(10f, (FontStyle)1);
                ((ToolStripItem)field_328).ForeColor = Color.White;
                ((ToolStripItem)field_328).Name = "tsmi_staticIP";
                ((ToolStripItem)field_328).Size = new Size(241, 24);
                ((ToolStripItem)field_328).Text = "تثبيت ايبيهات";
                ((ToolStripItem)field_328).Click += method_413;
                ((ToolStripItem)field_280).Name = "tsmi_activate";
                ((ToolStripItem)field_280).Size = new Size(241, 24);
                ((ToolStripItem)field_280).Text = "تفعيل البرنامج";
                ((ToolStripItem)field_281).Name = "tsmi_Contact";
                ((ToolStripItem)field_281).Size = new Size(241, 24);
                ((ToolStripItem)field_281).Text = "التواصل مع مكتب أمان تيليكوم";
                ((ToolStripItem)field_281).Click += method_406;
                ((ToolStripItem)field_282).Name = "tsmi_Exit";
                ((ToolStripItem)field_282).Size = new Size(241, 24);
                ((ToolStripItem)field_282).Text = "خروج";
                ((ToolStripItem)field_282).Click += method_407;
                field_284.AutomaticDelay = 200;
                field_284.AutoPopDelay = 4000;
                field_284.BackColor = Color.Maroon;
                field_284.ForeColor = Color.White;
                field_284.InitialDelay = 200;
                field_284.IsBalloon = true;
                field_284.ReshowDelay = 40;
                field_284.ShowAlways = true;
                field_284.StripAmpersands = true;
                field_284.UseAnimation = false;
                field_307.BaseColor = SystemColors.Control;
                field_307.Checked = true;
                field_307.CheckedOffColor = Color.DarkGray;
                field_307.CheckedOnColor = Color.FromArgb(0, 192, 0);
                field_307.FillColor = Color.White;
                ((Control)field_307).Location = new Point(615, 9);
                ((Control)field_307).Name = "Gsw_PingEnable";
                ((Control)field_307).Size = new Size(28, 20);
                ((Control)field_307).TabIndex = 68;
                field_284.SetToolTip((Control)(object)field_307, "تفعيل مؤشر البنج ( اتصال الجهاز ) التلقائي .. في حال كان الجهاز متصل سيتم اضهار اللون الاخضر حول مربع الأيبي في اليمين");
                field_307.CheckedChanged += method_393;
                ((Control)field_333).Anchor = (AnchorStyles)10;
                ((Control)field_333).BackColor = Color.Transparent;
                field_333.BaseColor = Color.PaleGoldenrod;
                field_333.BorderColor = Color.FromArgb(224, 224, 224);
                field_333.BorderSize = 1;
                ((Control)field_333).Cursor = Cursors.IBeam;
                ((Control)field_333).Enabled = false;
                field_333.FocusedBaseColor = Color.White;
                field_333.FocusedBorderColor = Color.FromArgb(100, 88, 255);
                field_333.FocusedForeColor = SystemColors.ControlText;
                ((Control)field_333).Font = UiFonts.Create(8.5f);
                ((Control)field_333).ForeColor = Color.Black;
                ((Control)field_333).Location = new Point(121, 5);
                ((Control)field_333).Name = "Lbl_Lic_back";
                field_333.PasswordChar = '\0';
                field_333.Radius = 9;
                field_333.ReadOnly = true;
                ((Control)field_333).RightToLeft = (RightToLeft)0;
                field_333.SelectedText = "";
                ((Control)field_333).Size = new Size(114, 23);
                ((Control)field_333).TabIndex = 74;
                field_333.TextAlign = (HorizontalAlignment)2;
                field_284.SetToolTip((Control)(object)field_333, "كلمة مرور الميش");
                field_303.Enabled = true;
                field_303.Interval = 3000;
                field_303.Tick += method_394;
                ((Control)field_308).AutoSize = true;
                ((Control)field_308).Font = UiFonts.Create(9f, (FontStyle)1);
                ((Control)field_308).ForeColor = Color.DimGray;
                ((Control)field_308).Location = new Point(644, 11);
                ((Control)field_308).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_308).Name = "LblPing";
                ((Control)field_308).RightToLeft = (RightToLeft)0;
                ((Control)field_308).Size = new Size(31, 15);
                ((Control)field_308).TabIndex = 70;
                ((Control)field_308).Tag = "اضغط هنا اذا اردت فتح نافذة البنج للايبي المحدد";
                ((Control)field_308).Text = "Ping";
                field_308.TextAlign = (ContentAlignment)64;
                ((Control)field_308).Click += method_403;
                ((Control)field_308).MouseLeave += method_405;
                ((Control)field_308).MouseHover += method_404;
                ((Control)field_309).BackColor = Color.PaleGoldenrod;
                ((Control)field_309).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
                ((Control)field_309).ForeColor = Color.FromArgb(64, 64, 64);
                ((Control)field_309).Location = new Point(129, 9);
                ((Control)field_309).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_309).Name = "Lbl_Lic";
                ((Control)field_309).Size = new Size(99, 14);
                ((Control)field_309).TabIndex = 71;
                ((Control)field_309).Text = "نسخه كامله";
                field_309.TextAlign = (ContentAlignment)32;
                ((ToolStrip)field_332).BackColor = Color.PaleGoldenrod;
                ((Control)field_332).Font = UiFonts.Create(8f);
                ((Control)field_332).Name = "gunaContextMenuStrip1";
                field_332.RenderStyle.ArrowColor = Color.FromArgb(151, 143, 255);
                field_332.RenderStyle.BorderColor = Color.Gainsboro;
                field_332.RenderStyle.ColorTable = null;
                ((ToolStripProfessionalRenderer)field_332.RenderStyle).RoundedEdges = true;
                field_332.RenderStyle.SelectionArrowColor = Color.White;
                field_332.RenderStyle.SelectionBackColor = Color.FromArgb(100, 88, 255);
                field_332.RenderStyle.SelectionForeColor = Color.White;
                field_332.RenderStyle.SeparatorColor = Color.Gainsboro;
                field_332.RenderStyle.TextRenderingHint = (DrawingTextRenderingHint)5;
                ((ToolStripDropDownMenu)field_332).ShowImageMargin = false;
                ((Control)field_332).Size = new Size(36, 4);
                field_283.AnimationHoverSpeed = 0.07f;
                field_283.AnimationSpeed = 0.03f;
                field_283.BaseColor = Color.FromArgb(192, 0, 0);
                field_283.BorderColor = Color.Black;
                ((Control)field_283).ContextMenuStrip = (ContextMenuStrip)(object)field_279;
                field_283.DialogResult = (DialogResult)0;
                field_283.FocusedColor = Color.Empty;
                ((Control)field_283).Font = UiFonts.Create(9f);
                ((Control)field_283).ForeColor = Color.White;
                field_283.Image = (Image)(object)ImageCache.method_593();
                field_283.ImageSize = new Size(20, 20);
                ((Control)field_283).Location = new Point(67, 3);
                ((Control)field_283).Name = "gunaButton1";
                field_283.OnHoverBaseColor = Color.FromArgb(151, 143, 255);
                field_283.OnHoverBorderColor = Color.Black;
                field_283.OnHoverForeColor = Color.White;
                field_283.OnHoverImage = null;
                field_283.OnPressedColor = Color.Black;
                ((Control)field_283).Size = new Size(40, 25);
                ((Control)field_283).TabIndex = 67;
                ((Control)field_283).Click += method_377;
                ((Control)field_230).Anchor = (AnchorStyles)9;
                field_230.Image = (Image)componentResourceManager.GetObject("pictureBox1.Image");
                ((Control)field_230).Location = new Point(703, 1);
                ((Control)field_230).Name = "pictureBox1";
                ((Control)field_230).Size = new Size(233, 77);
                field_230.SizeMode = (PictureBoxSizeMode)1;
                field_230.TabIndex = 28;
                field_230.TabStop = false;
                ((Control)field_229).Anchor = (AnchorStyles)9;
                field_229.AnimationHoverSpeed = 0.07f;
                field_229.AnimationSpeed = 0.03f;
                ((Control)field_229).BackColor = Color.Transparent;
                field_229.BaseColor = Color.Blue;
                field_229.BorderColor = Color.Black;
                field_229.DialogResult = (DialogResult)0;
                field_229.FocusedColor = Color.Empty;
                ((Control)field_229).Font = UiFonts.Create(14f, (FontStyle)1);
                ((Control)field_229).ForeColor = Color.White;
                field_229.Image = (Image)(object)ImageCache.method_592();
                field_229.ImageAlign = (HorizontalAlignment)2;
                field_229.ImageSize = new Size(20, 20);
                ((Control)field_229).Location = new Point(715, 447);
                ((Control)field_229).Name = "buttonConnect";
                field_229.OnHoverBaseColor = Color.Red;
                field_229.OnHoverBorderColor = Color.Black;
                field_229.OnHoverForeColor = Color.White;
                field_229.OnHoverImage = null;
                field_229.OnPressedColor = Color.Black;
                field_229.Radius = 8;
                ((Control)field_229).Size = new Size(209, 40);
                ((Control)field_229).TabIndex = 5;
                ((Control)field_229).Text = "اتصال سوفت أمان";
                field_229.TextAlign = (HorizontalAlignment)2;
                ((Control)field_229).Click += method_341;
                ((Control)field_336).BackColor = Color.Transparent;
                ((Control)field_336).Font = UiFonts.Create(8f);
                ((Control)field_336).ForeColor = Color.Black;
                ((Control)field_336).Location = new Point(14, 75);
                ((Control)field_336).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_336).Name = "lbl_WO_5g_pass";
                ((Control)field_336).Size = new Size(95, 12);
                ((Control)field_336).TabIndex = 79;
                ((Control)field_336).Text = "مفتوح (بدون رمز)";
                field_336.TextAlign = (ContentAlignment)32;
                ((Control)field_335).BackColor = Color.Transparent;
                ((Control)field_335).Font = UiFonts.Create(8f);
                ((Control)field_335).ForeColor = Color.Black;
                ((Control)field_335).Location = new Point(31, 76);
                ((Control)field_335).Margin = new Padding(2, 0, 2, 0);
                ((Control)field_335).Name = "lbl_WO_2g_pass";
                ((Control)field_335).Size = new Size(95, 10);
                ((Control)field_335).TabIndex = 80;
                ((Control)field_335).Text = "مفتوح (بدون رمز)";
                field_335.TextAlign = (ContentAlignment)32;
                ((ToolStripItem)field_337).Font = UiFonts.Create(9f, (FontStyle)1);
                ((ToolStripItem)field_337).ForeColor = Color.FromArgb(192, 0, 0);
                ((ToolStripItem)field_337).Name = "tsmi_updates";
                ((ToolStripItem)field_337).Size = new Size(241, 24);
                ((ToolStripItem)field_337).Text = "التحقق من التحديثات";
                ((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
                ((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
                ((Control)this).BackColor = Color.White;
                ((Form)this).ClientSize = new Size(936, 529);
                ((Form)this).ControlBox = false;
                ((Control)this).Controls.Add((Control)(object)field_309);
                ((Control)this).Controls.Add((Control)(object)field_308);
                ((Control)this).Controls.Add((Control)(object)field_307);
                ((Control)this).Controls.Add((Control)(object)field_283);
                ((Control)this).Controls.Add((Control)(object)field_278);
                ((Control)this).Controls.Add((Control)(object)field_273);
                ((Control)this).Controls.Add((Control)(object)field_277);
                ((Control)this).Controls.Add((Control)(object)field_233);
                ((Control)this).Controls.Add((Control)(object)field_207);
                ((Control)this).Controls.Add((Control)(object)field_231);
                ((Control)this).Controls.Add((Control)(object)field_230);
                ((Control)this).Controls.Add((Control)(object)field_229);
                ((Control)this).Controls.Add((Control)(object)field_208);
                ((Control)this).Controls.Add((Control)(object)field_201);
                ((Control)this).Controls.Add((Control)(object)field_232);
                ((Control)this).Controls.Add((Control)(object)field_333);
                ((Form)this).FormBorderStyle = (FormBorderStyle)0;
                ((Form)this).Icon = (Icon)componentResourceManager.GetObject("$this.Icon");
                ((Control)this).Name = "Main";
                ((Form)this).RightToLeftLayout = true;
                ((Form)this).SizeGripStyle = (SizeGripStyle)2;
                ((Form)this).StartPosition = (FormStartPosition)1;
                ((Control)this).Text = "أمان ورت";
                ((Form)this).FormClosing += method_397;
                ((Form)this).Load += method_392;
                ((Control)this).MouseDown += method_340;
                ((Control)field_204).ResumeLayout(false);
                ((Control)field_204).PerformLayout();
                ((Control)field_208).ResumeLayout(false);
                ((Control)field_208).PerformLayout();
                ((Control)field_231).ResumeLayout(false);
                ((Control)field_231).PerformLayout();
                ((Control)field_232).ResumeLayout(false);
                ((Control)field_232).PerformLayout();
                ((Control)field_324).ResumeLayout(false);
                ((Control)field_324).PerformLayout();
                ((Control)field_313).ResumeLayout(false);
                ((Control)field_313).PerformLayout();
                ((Control)field_256).ResumeLayout(false);
                ((Control)field_256).PerformLayout();
                ((Control)field_251).ResumeLayout(false);
                ((Control)field_251).PerformLayout();
                ((Control)field_292).ResumeLayout(false);
                ((Control)field_292).PerformLayout();
                ((Control)field_273).ResumeLayout(false);
                ((Control)field_273).PerformLayout();
                ((Control)field_279).ResumeLayout(false);
                ((ISupportInitialize)field_230).EndInit();
                ((Control)this).ResumeLayout(false);
                ((Control)this).PerformLayout();
        }

        [CompilerGenerated]
        private void method_422()
        {
                method_395(((Control)field_206).Text, field_203, field_304);
        }
}
}
