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
public class UpgradePackagesForm : Form
{
	[Serializable]
	[CompilerGenerated]
	private sealed class nested_497
	{
		public static readonly nested_497 field_498 = new nested_497();

		public static Func<string, bool> field_499;

		public static Func<string, bool> field_500;

		public static Func<string, bool> field_501;

		public static Func<string, bool> field_502;

		public static Func<string, bool> field_503;

		public static Func<string, bool> field_504;

		public static Func<string, bool> field_505;

		public static Func<string, bool> field_506;

		internal bool method_507(string P_0)
		{
			return P_0.StartsWith("luci-i18n-base-ar", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_508(string P_0)
		{
			return P_0.StartsWith("lldpd", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_509(string P_0)
		{
			return P_0.StartsWith("luci-theme-bootstrap", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_510(string P_0)
		{
			return P_0.StartsWith("luci-app-watchcat", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_511(string P_0)
		{
			return P_0.StartsWith("luci-i18n-base-ar", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_512(string P_0)
		{
			return P_0.StartsWith("lldpd", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_513(string P_0)
		{
			return P_0.StartsWith("luci-theme-bootstrap", StringComparison.OrdinalIgnoreCase);
		}

		internal bool method_514(string P_0)
		{
			return P_0.StartsWith("luci-app-watchcat", StringComparison.OrdinalIgnoreCase);
		}
	}

	private readonly string field_515;

	private readonly string field_516;

	private readonly string field_517;

	private readonly string field_518;

	private readonly bool field_519;

	private readonly List<string> field_520;

	private AmaanSshClient field_521;

	private ShellStream field_522;

	private string field_523 = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

	private string field_524 = "bin";

	private string field_525 = string.Empty;

	private IContainer field_526;

	private GunaGroupBox field_527;

	private GunaButton field_528;

	private GunaTextBox field_529;

	private Label field_530;

	private Label field_531;

	private Button field_532;

	private GunaGroupBox field_533;

	private GunaButton field_534;

	private GunaProgressBar field_535;

	private GunaButton field_536;

	private GunaButton field_537;

	private GunaButton field_538;

	private Label field_539;

	public Label field_540;

	private RichTextBox field_541;

	private GunaGroupBox field_542;

	private GunaProgressBar field_543;

	private Label field_544;

	private Label field_545;

	private Label field_546;

	private GunaTextBox field_547;

	private GunaTextBox field_548;

	private GunaTextBox field_549;

	private GunaSwitch field_550;

	private Label field_551;

	public UpgradePackagesForm()
	{
		method_568();
		field_519 = true;
		((Control)field_533).Visible = false;
		((Control)field_542).Visible = true;
		((Control)field_527).Location = new Point(12, 95);
		field_515 = ((Control)field_547).Text;
		field_516 = ((Control)field_549).Text;
		field_517 = ((Control)field_548).Text;
	}

	public UpgradePackagesForm(string P_0, List<string> P_1, string P_2, string P_3, string P_4, AmaanSshClient P_5)
	{
		//IL_01e6: Unknown result type (might be due to invalid IL or missing references)
		method_568();
		try
		{
			field_515 = P_2;
			field_516 = P_3;
			field_517 = P_4;
			field_521 = P_5;
			field_518 = P_0;
			field_520 = P_1;
			((Control)field_539).Text = P_0;
			((Control)field_538).Enabled = !P_1.Any((string text) => text.StartsWith("luci-i18n-base-ar", StringComparison.OrdinalIgnoreCase));
			((Control)field_536).Enabled = !P_1.Any((string text) => text.StartsWith("lldpd", StringComparison.OrdinalIgnoreCase));
			((Control)field_537).Enabled = !P_1.Any((string text) => text.StartsWith("luci-theme-bootstrap", StringComparison.OrdinalIgnoreCase));
			((Control)field_534).Enabled = !P_1.Any((string text) => text.StartsWith("luci-app-watchcat", StringComparison.OrdinalIgnoreCase));
			field_522 = ((SshClient)P_5).CreateShellStream("ansi", 80u, 60u, 800u, 600u, 65536);
			field_525 = field_522.Expect(new Regex(":.[*>#]"), new TimeSpan(0, 0, 3), -1);
			((TextBoxBase)field_541).AppendText(field_525);
			field_522.DataReceived += method_552;
			((TextBoxBase)field_541).SelectionStart = ((Control)field_541).Text.Length;
			((TextBoxBase)field_541).ScrollToCaret();
		}
		catch (Exception ex)
		{
			MessageBox.Show("خطأ.\n" + ex.Message);
		}
	}

	public UpgradePackagesForm(string P_0, List<string> P_1, string P_2, string P_3, string P_4)
	{
		//IL_0245: Unknown result type (might be due to invalid IL or missing references)
		method_568();
		try
		{
			field_515 = P_2;
			field_516 = P_3;
			field_517 = P_4;
			field_518 = P_0;
			field_520 = P_1;
			((Control)field_539).Text = P_0;
			if (field_521 == null)
			{
				field_521 = new AmaanSshClient(P_2, P_3, P_4);
				((BaseClient)field_521).ConnectionInfo.Timeout = TimeSpan.FromSeconds(5.0);
				((BaseClient)field_521).Connect();
				((Control)field_538).Enabled = !P_1.Any((string text) => text.StartsWith("luci-i18n-base-ar", StringComparison.OrdinalIgnoreCase));
				((Control)field_536).Enabled = !P_1.Any((string text) => text.StartsWith("lldpd", StringComparison.OrdinalIgnoreCase));
				((Control)field_537).Enabled = !P_1.Any((string text) => text.StartsWith("luci-theme-bootstrap", StringComparison.OrdinalIgnoreCase));
				((Control)field_534).Enabled = !P_1.Any((string text) => text.StartsWith("luci-app-watchcat", StringComparison.OrdinalIgnoreCase));
				field_522 = ((SshClient)field_521).CreateShellStream("ansi", 80u, 60u, 800u, 600u, 65536);
				field_525 = field_522.Expect(new Regex(":.[*>#]"), new TimeSpan(0, 0, 3), -1);
				((TextBoxBase)field_541).AppendText(field_525);
				field_522.DataReceived += method_552;
				((TextBoxBase)field_541).SelectionStart = ((Control)field_541).Text.Length;
				((TextBoxBase)field_541).ScrollToCaret();
			}
			else
			{
				((BaseClient)field_521).Disconnect();
				((BaseClient)field_521).Dispose();
				field_521 = null;
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show("خطأ.\n" + ex.Message);
		}
	}

	private void method_552(object P_0, ShellDataEventArgs P_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		field_525 = field_522.Read();
		((Control)this).Invoke((Delegate)(MethodInvoker)(() =>
		{
			method_553(field_525);
		}));
	}

	private void method_553(string P_0)
	{
		((TextBoxBase)field_541).AppendText(P_0);
		((TextBoxBase)field_541).SelectionStart = ((Control)field_541).Text.Length;
		((TextBoxBase)field_541).ScrollToCaret();
	}

	private static string method_554(Stream P_0)
	{
		return new StreamReader(P_0).ReadToEnd();
	}

	private void method_555(object P_0, EventArgs P_1)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected Obj, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		MachineRegistryStore class_1634 = new MachineRegistryStore("LastFolder");
		string text = class_1634.method_472();
		if (string.IsNullOrEmpty(text))
		{
			text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
		}
		OpenFileDialog val = new OpenFileDialog
		{
			InitialDirectory = text,
			Filter = "Bin Files (*.bin)|*.bin",
			Multiselect = false
		};
		if ((int)((CommonDialog)val).ShowDialog() == 1)
		{
			((Control)field_529).Text = ((FileDialog)val).FileName;
			class_1634.method_471(Path.GetDirectoryName(((FileDialog)val).FileName));
		}
		else
		{
			MessageBox.Show("خطأ في اختيار الملف.");
		}
	}

	private void method_556(object P_0, EventArgs P_1)
	{
		//IL_021d: Expected Obj, but got Unknown
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected Obj, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Expected Obj, but got Unknown
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Expected Obj, but got Unknown
		//IL_0282: Unknown result type (might be due to invalid IL or missing references)
		//IL_029d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0205: Unknown result type (might be due to invalid IL or missing references)
		string text = field_515;
		string text2 = field_516;
		string text3 = field_517;
		string text4 = "";
		try
		{
			if (field_519 && field_521 == null)
			{
				text = ((Control)field_547).Text;
				text2 = ((Control)field_549).Text;
				text3 = ((Control)field_548).Text;
				field_521 = new AmaanSshClient(text, text2, text3);
				((BaseClient)field_521).ConnectionInfo.Timeout = TimeSpan.FromSeconds(5.0);
				((BaseClient)field_521).Connect();
				field_522 = ((SshClient)field_521).CreateShellStream("ansi", 80u, 60u, 800u, 600u, 65536);
				field_525 = field_522.Expect(new Regex(":.[*>#]"), new TimeSpan(0, 0, 3), -1);
				((TextBoxBase)field_541).AppendText(field_525);
				field_522.DataReceived += method_552;
				((TextBoxBase)field_541).SelectionStart = ((Control)field_541).Text.Length;
				((TextBoxBase)field_541).ScrollToCaret();
			}
			if (File.Exists(((Control)field_529).Text))
			{
				string text5 = "/tmp/upgrade.bin";
				method_559("جاري الرفع");
				new AmaanScpClient(text, text2, text3).method_41(((Control)field_529).Text, text5);
				method_558("تم الرفع");
				Thread.Sleep(2000);
				method_557("");
				method_559("جاري التحديث");
				text4 = ((!field_550.Checked) ? ("sysupgrade -v  -n " + text5) : ("sysupgrade -F  -n " + text5));
				field_522.Write("service wpad stop\n");
				field_522.Write(text4 + "\n");
				Thread.Sleep(1000);
				method_558("تم فصل الاتصال .. يرجى الانتضار حتى ينتهي الجهاز من التحديث");
				field_521 = null;
			}
			else
			{
				MessageBox.Show("يرجى اختيار الملف أولا ...");
			}
			((Stream)(object)field_522).Flush();
		}
		catch (SshPassPhraseNullOrEmptyException ex)
		{
			SshPassPhraseNullOrEmptyException ex2 = ex;
			MessageBox.Show("حدث خطأ في احد الاستعلامات.\n" + ((Exception)(object)ex2).Message);
		}
		catch (SshAuthenticationException ex3)
		{
			SshAuthenticationException ex4 = ex3;
			MessageBox.Show("خطأ في اسم المستخدم او كلمة المرور.\n" + ((Exception)(object)ex4).Message);
		}
		catch (SshConnectionException ex5)
		{
			SshConnectionException ex6 = ex5;
			MessageBox.Show("غير قادر على الاتصال.. تحقق من البيانات.\n" + ((Exception)(object)ex6).Message);
		}
		catch (SshException ex7)
		{
			SshException ex8 = ex7;
			MessageBox.Show("حدث خطأ.\n" + ((Exception)(object)ex8).Message);
		}
		catch (Exception ex9)
		{
			MessageBox.Show("خطأ.\n" + ex9.Message);
			((BaseClient)field_521).Disconnect();
			((BaseClient)field_521).Dispose();
			field_521 = null;
		}
		((Stream)(object)field_522).Flush();
	}

	private void method_557(string P_0)
	{
		((Control)field_540).Text = P_0;
		((Control)field_540).BackColor = Color.Empty;
	}

	private void method_558(string P_0)
	{
		((Control)field_540).Text = P_0;
		((Control)field_540).BackColor = Color.Lime;
	}

	private void method_559(string P_0)
	{
		((Control)field_540).Text = P_0;
		((Control)field_540).BackColor = Color.Yellow;
	}

	private void method_560(string P_0)
	{
		((Control)field_540).Text = P_0;
		((Control)field_540).BackColor = Color.Red;
	}

	private void method_561(object P_0, EventArgs P_1)
	{
		AmaanScpClient class_1634 = new AmaanScpClient(field_515, field_516, field_517);
		string[] array = new string[3]
		{
			"1.ipk",
			"2.ipk",
			"3.ipk"
		};
		for (int i = 0; i < array.Length; i++)
		{
			string text = Path.Combine(field_523, field_524, array[i]);
			if (File.Exists(text))
			{
				string text2 = "/tmp/" + array[i];
				method_559("جاري الرفع");
				class_1634.method_41(text, text2);
				method_558("تم الرفع");
				method_557("");
				method_559("جاري التثبيت");
				string text3 = "opkg install " + text2;
				field_522.WriteLine(text3);
				Thread.Sleep(2000);
			}
		}
		method_558("تمت العمليه");
		((Stream)(object)field_522).Flush();
	}

	private void method_562(object P_0, EventArgs P_1)
	{
		AmaanScpClient class_1634 = new AmaanScpClient(field_515, field_516, field_517);
		string[] array = new string[2]
		{
			"4.ipk",
			"5.ipk"
		};
		for (int i = 0; i < array.Length; i++)
		{
			string text = Path.Combine(field_523, field_524, array[i]);
			if (File.Exists(text))
			{
				string text2 = "/tmp/" + array[i];
				method_559("جاري الرفع");
				class_1634.method_41(text, text2);
				method_558("تم الرفع");
				method_557("");
				method_559("جاري التثبيت");
				string text3 = "opkg install " + text2;
				field_522.Write(text3 + "\n");
				Thread.Sleep(2000);
			}
		}
		field_522.WriteLine("uci del watchcat.@watchcat[0].pinghosts");
		field_522.WriteLine("uci set watchcat.@watchcat[0].mode='periodic_reboot'");
		method_558("تمت العمليه");
		((Stream)(object)field_522).Flush();
	}

	private void method_563(object P_0, EventArgs P_1)
	{
		AmaanScpClient class_1634 = new AmaanScpClient(field_515, field_516, field_517);
		string[] array = new string[1] { "7.ipk" };
		for (int i = 0; i < array.Length; i++)
		{
			string text = Path.Combine(field_523, field_524, array[i]);
			if (File.Exists(text))
			{
				string text2 = "/tmp/" + array[i];
				method_559("جاري الرفع");
				class_1634.method_41(text, text2);
				method_558("تم الرفع");
				method_557("");
				method_559("جاري التثبيت");
				string text3 = "opkg install " + text2;
				field_522.Write(text3 + "\n");
				Thread.Sleep(2000);
				field_522.Write("uci set luci.main.lang='ar'\n");
			}
		}
		method_558("تمت العمليه");
		((Stream)(object)field_522).Flush();
	}

	private void method_564(object P_0, EventArgs P_1)
	{
		AmaanScpClient class_1634 = new AmaanScpClient(field_515, field_516, field_517);
		string[] array = new string[3]
		{
			"9.ipk",
			"10.ipk",
			"11.ipk"
		};
		for (int i = 0; i < array.Length; i++)
		{
			string text = Path.Combine(field_523, field_524, array[i]);
			if (File.Exists(text))
			{
				string text2 = "/tmp/" + array[i];
				method_559("جاري الرفع");
				class_1634.method_41(text, text2);
				method_558("تم الرفع");
				method_557("");
				method_559("جاري التثبيت");
				string text3 = "opkg install " + text2;
				field_522.Write(text3 + "\n");
				Thread.Sleep(2000);
				field_522.Write("uci set luci.themes.Bootstrap=/luci-static/bootstrap'\n");
				field_522.Write("uci set luci.main.mediaurlbase=/luci-static/bootstrap\n");
				field_522.Write("uci commit luci'\n");
			}
		}
		method_558("تمت العمليه");
		((Stream)(object)field_522).Flush();
	}

	private void method_565(object P_0, EventArgs P_1)
	{
		string text = field_518;
		if (text == null)
		{
			return;
		}
		if (!(text == "mips_24kc"))
		{
			if (!(text == "mipsel_24kc"))
			{
				if (!(text == "arm_cortex-a15_neon-vfpv4"))
				{
					if (text == "mips_mips32")
					{
						field_524 = "bin\\4\\";
					}
				}
				else
				{
					field_524 = "bin\\3\\";
				}
			}
			else
			{
				field_524 = "bin\\2\\";
			}
		}
		else
		{
			field_524 = "bin\\1\\";
		}
	}

	private void method_566(object P_0, FormClosedEventArgs P_1)
	{
		try
		{
			((BaseClient)field_521).Disconnect();
			((BaseClient)field_521).Dispose();
			field_521 = null;
		}
		catch
		{
		}
	}

	private void method_567(object P_0, EventArgs P_1)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (field_550.Checked)
		{
			MessageBox.Show("هذا الخيار يلغي حماية فحص توافق التحديث\n في حال قمت بالتحديث بسوفت خاطئ فقد يتوقف الجهاز عن العمل نهائيا..", "تحذير هام جدا ...");
		}
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && field_526 != null)
		{
			field_526.Dispose();
		}
		base.Dispose(P_0);
	}

	private void method_568()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected Obj, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected Obj, but got Unknown
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Expected Obj, but got Unknown
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Expected Obj, but got Unknown
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected Obj, but got Unknown
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Expected Obj, but got Unknown
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Expected Obj, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Expected Obj, but got Unknown
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Expected Obj, but got Unknown
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Expected Obj, but got Unknown
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Expected Obj, but got Unknown
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected Obj, but got Unknown
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Expected Obj, but got Unknown
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Expected Obj, but got Unknown
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Expected Obj, but got Unknown
		//IL_00e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Expected Obj, but got Unknown
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Expected Obj, but got Unknown
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Expected Obj, but got Unknown
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected Obj, but got Unknown
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected Obj, but got Unknown
		//IL_02fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0364: Unknown result type (might be due to invalid IL or missing references)
		//IL_036e: Expected Obj, but got Unknown
		//IL_03a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_040d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0417: Expected Obj, but got Unknown
		//IL_051a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0524: Expected Obj, but got Unknown
		//IL_06ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d8: Expected Obj, but got Unknown
		//IL_0774: Unknown result type (might be due to invalid IL or missing references)
		//IL_077e: Expected Obj, but got Unknown
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09d3: Expected Obj, but got Unknown
		//IL_0b62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b6c: Expected Obj, but got Unknown
		//IL_0cf8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d02: Expected Obj, but got Unknown
		//IL_0f3d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0f47: Expected Obj, but got Unknown
		//IL_1086: Unknown result type (might be due to invalid IL or missing references)
		//IL_1090: Expected Obj, but got Unknown
		//IL_10c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_10e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1177: Unknown result type (might be due to invalid IL or missing references)
		//IL_1360: Unknown result type (might be due to invalid IL or missing references)
		//IL_136a: Expected Obj, but got Unknown
		//IL_139b: Unknown result type (might be due to invalid IL or missing references)
		//IL_140f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1419: Expected Obj, but got Unknown
		//IL_144a: Unknown result type (might be due to invalid IL or missing references)
		//IL_14be: Unknown result type (might be due to invalid IL or missing references)
		//IL_14c8: Expected Obj, but got Unknown
		//IL_14f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_1677: Unknown result type (might be due to invalid IL or missing references)
		//IL_1681: Expected Obj, but got Unknown
		//IL_1796: Unknown result type (might be due to invalid IL or missing references)
		//IL_17a0: Expected Obj, but got Unknown
		//IL_18a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_18ac: Expected Obj, but got Unknown
		//IL_1a14: Unknown result type (might be due to invalid IL or missing references)
		//IL_1a1e: Expected Obj, but got Unknown
		//IL_1a4c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b82: Unknown result type (might be due to invalid IL or missing references)
		//IL_1b8c: Expected Obj, but got Unknown
		field_527 = new GunaGroupBox();
		field_539 = new Label();
		field_531 = new Label();
		field_532 = new Button();
		field_528 = new GunaButton();
		field_529 = new GunaTextBox();
		field_530 = new Label();
		field_533 = new GunaGroupBox();
		field_537 = new GunaButton();
		field_538 = new GunaButton();
		field_534 = new GunaButton();
		field_535 = new GunaProgressBar();
		field_536 = new GunaButton();
		field_540 = new Label();
		field_541 = new RichTextBox();
		field_542 = new GunaGroupBox();
		field_544 = new Label();
		field_545 = new Label();
		field_546 = new Label();
		field_543 = new GunaProgressBar();
		field_547 = new GunaTextBox();
		field_548 = new GunaTextBox();
		field_549 = new GunaTextBox();
		field_550 = new GunaSwitch();
		field_551 = new Label();
		((Control)field_527).SuspendLayout();
		((Control)field_533).SuspendLayout();
		((Control)field_542).SuspendLayout();
		((Control)this).SuspendLayout();
		((Control)field_527).BackColor = Color.Transparent;
		field_527.BaseColor = Color.White;
		field_527.BorderColor = Color.Black;
		((Control)field_527).Controls.Add((Control)(object)field_550);
		((Control)field_527).Controls.Add((Control)(object)field_551);
		((Control)field_527).Controls.Add((Control)(object)field_539);
		((Control)field_527).Controls.Add((Control)(object)field_531);
		((Control)field_527).Controls.Add((Control)(object)field_532);
		((Control)field_527).Controls.Add((Control)(object)field_528);
		((Control)field_527).Controls.Add((Control)(object)field_529);
		((Control)field_527).Controls.Add((Control)(object)field_530);
		((Control)field_527).ForeColor = Color.White;
		field_527.LineColor = Color.Black;
		((Control)field_527).Location = new Point(12, 12);
		((Control)field_527).Name = "GB_UpdateSoft";
		((Control)field_527).RightToLeft = (RightToLeft)1;
		((Control)field_527).Size = new Size(528, 162);
		((Control)field_527).TabIndex = 0;
		((Control)field_527).Text = "تحديث النظام";
		field_527.TextLocation = new Point(450, 8);
		((Control)field_539).Font = UiFonts.Create(8f);
		((Control)field_539).ForeColor = Color.White;
		((Control)field_539).Location = new Point(6, 1);
		((Control)field_539).Margin = new Padding(2, 0, 2, 0);
		((Control)field_539).Name = "Lbl_arch";
		((Control)field_539).Size = new Size(104, 26);
		((Control)field_539).TabIndex = 49;
		((Control)field_539).Text = "-";
		field_539.TextAlign = (ContentAlignment)64;
		((Control)field_531).Font = UiFonts.Create(8f);
		((Control)field_531).ForeColor = Color.FromArgb(192, 0, 0);
		((Control)field_531).Location = new Point(-1, 33);
		((Control)field_531).Margin = new Padding(2, 0, 2, 0);
		((Control)field_531).Name = "label1";
		((Control)field_531).Size = new Size(526, 41);
		((Control)field_531).TabIndex = 48;
		((Control)field_531).Text = "تنبيه :\r\nيرجى التأكد من تحديث الملف المناسب للجهاز وعدم اطفاء الجهاز أثناء التحديث حتى لايموت الجهاز اثناء العمليه.";
		field_531.TextAlign = (ContentAlignment)16;
		((Control)field_532).Font = UiFonts.Create(9f);
		((Control)field_532).ForeColor = Color.Black;
		((Control)field_532).Location = new Point(6, 77);
		((Control)field_532).Name = "Btn_BrowseFile";
		((Control)field_532).Size = new Size(71, 26);
		((Control)field_532).TabIndex = 5;
		((Control)field_532).Text = "اختيار ملف";
		((ButtonBase)field_532).UseVisualStyleBackColor = true;
		((Control)field_532).Click += method_555;
		field_528.AnimationHoverSpeed = 0.07f;
		field_528.AnimationSpeed = 0.03f;
		((Control)field_528).BackColor = Color.Transparent;
		field_528.BaseColor = Color.Red;
		field_528.BorderColor = Color.Black;
		field_528.DialogResult = (DialogResult)0;
		field_528.FocusedColor = Color.Empty;
		((Control)field_528).Font = UiFonts.Create(14f, (FontStyle)1);
		((Control)field_528).ForeColor = Color.White;
		field_528.Image = (Image)(object)ImageCache.method_577();
		field_528.ImageAlign = (HorizontalAlignment)2;
		field_528.ImageSize = new Size(20, 20);
		((Control)field_528).Location = new Point(141, 114);
		((Control)field_528).Name = "Btn_StartUpdate";
		field_528.OnHoverBaseColor = Color.Red;
		field_528.OnHoverBorderColor = Color.Black;
		field_528.OnHoverForeColor = Color.White;
		field_528.OnHoverImage = null;
		field_528.OnPressedColor = Color.Black;
		field_528.Radius = 8;
		((Control)field_528).Size = new Size(340, 34);
		((Control)field_528).TabIndex = 6;
		((Control)field_528).Text = "تحديث";
		field_528.TextAlign = (HorizontalAlignment)2;
		((Control)field_528).Click += method_556;
		((Control)field_529).BackColor = Color.Transparent;
		field_529.BaseColor = Color.MintCream;
		field_529.BorderColor = Color.DimGray;
		field_529.BorderSize = 1;
		((Control)field_529).Cursor = Cursors.IBeam;
		field_529.FocusedBaseColor = Color.White;
		field_529.FocusedBorderColor = Color.FromArgb(100, 88, 255);
		field_529.FocusedForeColor = SystemColors.ControlText;
		((Control)field_529).Font = UiFonts.Create(9f);
		((Control)field_529).ForeColor = Color.Black;
		((Control)field_529).Location = new Point(80, 77);
		((Control)field_529).Name = "textBoxFilePath";
		field_529.PasswordChar = '\0';
		field_529.Radius = 9;
		((Control)field_529).RightToLeft = (RightToLeft)0;
		field_529.SelectedText = "";
		((Control)field_529).Size = new Size(401, 26);
		((Control)field_529).TabIndex = 4;
		((Control)field_530).Font = UiFonts.Create(8f);
		((Control)field_530).ForeColor = Color.Black;
		((Control)field_530).Location = new Point(477, 77);
		((Control)field_530).Margin = new Padding(2, 0, 2, 0);
		((Control)field_530).Name = "label10";
		((Control)field_530).Size = new Size(49, 26);
		((Control)field_530).TabIndex = 45;
		((Control)field_530).Text = "ملف التحديث";
		field_530.TextAlign = (ContentAlignment)16;
		((Control)field_533).BackColor = Color.Transparent;
		field_533.BaseColor = Color.White;
		field_533.BorderColor = Color.Gainsboro;
		((Control)field_533).Controls.Add((Control)(object)field_537);
		((Control)field_533).Controls.Add((Control)(object)field_538);
		((Control)field_533).Controls.Add((Control)(object)field_534);
		((Control)field_533).Controls.Add((Control)(object)field_535);
		((Control)field_533).Controls.Add((Control)(object)field_536);
		((Control)field_533).ForeColor = Color.White;
		field_533.LineColor = Color.Black;
		((Control)field_533).Location = new Point(12, 180);
		((Control)field_533).Name = "GB_AddPkg";
		((Control)field_533).RightToLeft = (RightToLeft)1;
		((Control)field_533).Size = new Size(528, 90);
		((Control)field_533).TabIndex = 1;
		((Control)field_533).Text = "تركيب اظافات";
		field_533.TextLocation = new Point(450, 8);
		field_537.AnimationHoverSpeed = 0.07f;
		field_537.AnimationSpeed = 0.03f;
		((Control)field_537).BackColor = Color.Transparent;
		field_537.BaseColor = Color.Black;
		field_537.BorderColor = Color.Black;
		field_537.DialogResult = (DialogResult)0;
		((Control)field_537).Enabled = false;
		field_537.FocusedColor = Color.Empty;
		((Control)field_537).Font = UiFonts.Create(9f);
		((Control)field_537).ForeColor = Color.White;
		field_537.Image = (Image)(object)ImageCache.method_597();
		field_537.ImageAlign = (HorizontalAlignment)2;
		field_537.ImageSize = new Size(20, 20);
		((Control)field_537).Location = new Point(141, 39);
		((Control)field_537).Name = "Btn_Theme";
		field_537.OnHoverBaseColor = Color.Red;
		field_537.OnHoverBorderColor = Color.Black;
		field_537.OnHoverForeColor = Color.White;
		field_537.OnHoverImage = null;
		field_537.OnPressedColor = Color.Black;
		field_537.Radius = 8;
		((Control)field_537).Size = new Size(123, 37);
		((Control)field_537).TabIndex = 50;
		((Control)field_537).Text = "الثيم الافتراضي";
		field_537.TextAlign = (HorizontalAlignment)2;
		((Control)field_537).Click += method_564;
		field_538.AnimationHoverSpeed = 0.07f;
		field_538.AnimationSpeed = 0.03f;
		((Control)field_538).BackColor = Color.Transparent;
		field_538.BaseColor = Color.Black;
		field_538.BorderColor = Color.Black;
		field_538.DialogResult = (DialogResult)0;
		field_538.FocusedColor = Color.Empty;
		((Control)field_538).Font = UiFonts.Create(9f);
		((Control)field_538).ForeColor = Color.White;
		field_538.Image = (Image)(object)ImageCache.method_597();
		field_538.ImageAlign = (HorizontalAlignment)2;
		field_538.ImageSize = new Size(20, 20);
		((Control)field_538).Location = new Point(17, 39);
		((Control)field_538).Name = "Btn_Arabic";
		field_538.OnHoverBaseColor = Color.Red;
		field_538.OnHoverBorderColor = Color.Black;
		field_538.OnHoverForeColor = Color.White;
		field_538.OnHoverImage = null;
		field_538.OnPressedColor = Color.Black;
		field_538.Radius = 8;
		((Control)field_538).Size = new Size(118, 37);
		((Control)field_538).TabIndex = 49;
		((Control)field_538).Text = "تعريب";
		field_538.TextAlign = (HorizontalAlignment)2;
		((Control)field_538).Click += method_563;
		field_534.AnimationHoverSpeed = 0.07f;
		field_534.AnimationSpeed = 0.03f;
		((Control)field_534).BackColor = Color.Transparent;
		field_534.BaseColor = Color.Black;
		field_534.BorderColor = Color.Black;
		field_534.DialogResult = (DialogResult)0;
		field_534.FocusedColor = Color.Empty;
		((Control)field_534).Font = UiFonts.Create(9f);
		((Control)field_534).ForeColor = Color.White;
		field_534.Image = (Image)(object)ImageCache.method_597();
		field_534.ImageAlign = (HorizontalAlignment)2;
		field_534.ImageSize = new Size(20, 20);
		((Control)field_534).Location = new Point(270, 39);
		((Control)field_534).Name = "Btn_wc";
		field_534.OnHoverBaseColor = Color.Red;
		field_534.OnHoverBorderColor = Color.Black;
		field_534.OnHoverForeColor = Color.White;
		field_534.OnHoverImage = null;
		field_534.OnPressedColor = Color.Black;
		field_534.Radius = 8;
		((Control)field_534).Size = new Size(123, 37);
		((Control)field_534).TabIndex = 48;
		((Control)field_534).Text = "اظافة الواتش كات";
		field_534.TextAlign = (HorizontalAlignment)2;
		((Control)field_534).Click += method_562;
		field_535.BorderColor = Color.Black;
		field_535.ColorStyle = (ColorStyle)0;
		field_535.IdleColor = Color.Gainsboro;
		((Control)field_535).Location = new Point(155, 146);
		((Control)field_535).Name = "gunaProgressBar2";
		field_535.ProgressMaxColor = Color.FromArgb(100, 88, 255);
		field_535.ProgressMinColor = Color.FromArgb(100, 88, 255);
		((Control)field_535).Size = new Size(214, 10);
		((Control)field_535).TabIndex = 47;
		field_536.AnimationHoverSpeed = 0.07f;
		field_536.AnimationSpeed = 0.03f;
		((Control)field_536).BackColor = Color.Transparent;
		field_536.BaseColor = Color.Black;
		field_536.BorderColor = Color.Black;
		field_536.DialogResult = (DialogResult)0;
		field_536.FocusedColor = Color.Empty;
		((Control)field_536).Font = UiFonts.Create(9f);
		((Control)field_536).ForeColor = Color.White;
		field_536.Image = (Image)(object)ImageCache.method_597();
		field_536.ImageAlign = (HorizontalAlignment)2;
		field_536.ImageSize = new Size(20, 20);
		((Control)field_536).Location = new Point(399, 39);
		((Control)field_536).Name = "Btn_lldp";
		field_536.OnHoverBaseColor = Color.Red;
		field_536.OnHoverBorderColor = Color.Black;
		field_536.OnHoverForeColor = Color.White;
		field_536.OnHoverImage = null;
		field_536.OnPressedColor = Color.Black;
		field_536.Radius = 8;
		((Control)field_536).Size = new Size(123, 37);
		((Control)field_536).TabIndex = 44;
		((Control)field_536).Text = "اظافة النيبورز";
		field_536.TextAlign = (HorizontalAlignment)2;
		((Control)field_536).Click += method_561;
		((Control)field_540).Anchor = (AnchorStyles)6;
		((Control)field_540).BackColor = SystemColors.Control;
		((Control)field_540).Font = UiFonts.Create(9f);
		((Control)field_540).ForeColor = Color.Black;
		((Control)field_540).Location = new Point(0, 276);
		((Control)field_540).Margin = new Padding(2, 0, 2, 0);
		((Control)field_540).Name = "infLBL_STATUS";
		((Control)field_540).Padding = new Padding(5);
		((Control)field_540).Size = new Size(552, 24);
		((Control)field_540).TabIndex = 48;
		((Control)field_540).Text = "--------------------------------------";
		field_540.TextAlign = (ContentAlignment)32;
		((Control)field_541).Anchor = (AnchorStyles)14;
		((Control)field_541).BackColor = Color.Black;
		((Control)field_541).ForeColor = Color.Yellow;
		((Control)field_541).Location = new Point(-7, 302);
		((Control)field_541).Margin = new Padding(2);
		((Control)field_541).Name = "richTextBoxAns";
		((Control)field_541).RightToLeft = (RightToLeft)0;
		((Control)field_541).Size = new Size(559, 145);
		((Control)field_541).TabIndex = 49;
		((Control)field_541).Text = "";
		((Control)field_542).BackColor = Color.Transparent;
		field_542.BaseColor = Color.White;
		field_542.BorderColor = Color.Gainsboro;
		((Control)field_542).Controls.Add((Control)(object)field_544);
		((Control)field_542).Controls.Add((Control)(object)field_545);
		((Control)field_542).Controls.Add((Control)(object)field_546);
		((Control)field_542).Controls.Add((Control)(object)field_543);
		((Control)field_542).Controls.Add((Control)(object)field_547);
		((Control)field_542).Controls.Add((Control)(object)field_548);
		((Control)field_542).Controls.Add((Control)(object)field_549);
		((Control)field_542).ForeColor = Color.White;
		field_542.LineColor = Color.Black;
		((Control)field_542).Location = new Point(12, 12);
		((Control)field_542).Name = "GB_ConnParameters";
		((Control)field_542).RightToLeft = (RightToLeft)1;
		((Control)field_542).Size = new Size(528, 74);
		((Control)field_542).TabIndex = 51;
		((Control)field_542).Text = "بيانات الاتصال";
		field_542.TextLocation = new Point(450, 8);
		((Control)field_542).Visible = false;
		((Control)field_544).AutoSize = true;
		((Control)field_544).Font = UiFonts.Create(8f);
		((Control)field_544).ForeColor = Color.Black;
		((Control)field_544).Location = new Point(135, 47);
		((Control)field_544).Margin = new Padding(2, 0, 2, 0);
		((Control)field_544).Name = "label4";
		((Control)field_544).Size = new Size(60, 13);
		((Control)field_544).TabIndex = 53;
		((Control)field_544).Text = "كلمة المرور";
		field_544.TextAlign = (ContentAlignment)16;
		((Control)field_545).AutoSize = true;
		((Control)field_545).Font = UiFonts.Create(8f);
		((Control)field_545).ForeColor = Color.Black;
		((Control)field_545).Location = new Point(294, 47);
		((Control)field_545).Margin = new Padding(2, 0, 2, 0);
		((Control)field_545).Name = "label3";
		((Control)field_545).Size = new Size(51, 13);
		((Control)field_545).TabIndex = 52;
		((Control)field_545).Text = "المستخدم";
		field_545.TextAlign = (ContentAlignment)16;
		((Control)field_546).AutoSize = true;
		((Control)field_546).Font = UiFonts.Create(8f);
		((Control)field_546).ForeColor = Color.Black;
		((Control)field_546).Location = new Point(481, 47);
		((Control)field_546).Margin = new Padding(2, 0, 2, 0);
		((Control)field_546).Name = "label2";
		((Control)field_546).Size = new Size(34, 13);
		((Control)field_546).TabIndex = 51;
		((Control)field_546).Text = "الايبي";
		field_546.TextAlign = (ContentAlignment)16;
		field_543.BorderColor = Color.Black;
		field_543.ColorStyle = (ColorStyle)0;
		field_543.IdleColor = Color.Gainsboro;
		((Control)field_543).Location = new Point(155, 146);
		((Control)field_543).Name = "gunaProgressBar1";
		field_543.ProgressMaxColor = Color.FromArgb(100, 88, 255);
		field_543.ProgressMinColor = Color.FromArgb(100, 88, 255);
		((Control)field_543).Size = new Size(214, 10);
		((Control)field_543).TabIndex = 47;
		field_547.BaseColor = Color.White;
		field_547.BorderColor = Color.Silver;
		((Control)field_547).Cursor = Cursors.IBeam;
		field_547.FocusedBaseColor = Color.White;
		field_547.FocusedBorderColor = Color.FromArgb(100, 88, 255);
		field_547.FocusedForeColor = SystemColors.ControlText;
		((Control)field_547).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_547).ForeColor = Color.Black;
		((Control)field_547).Location = new Point(352, 40);
		((Control)field_547).Name = "textBoxIP";
		field_547.PasswordChar = '\0';
		((Control)field_547).RightToLeft = (RightToLeft)0;
		field_547.SelectedText = "";
		((Control)field_547).Size = new Size(124, 26);
		((Control)field_547).TabIndex = 1;
		((Control)field_547).Text = "192.168.1.1";
		field_547.TextAlign = (HorizontalAlignment)2;
		field_548.BaseColor = Color.White;
		field_548.BorderColor = Color.Silver;
		((Control)field_548).Cursor = Cursors.IBeam;
		field_548.FocusedBaseColor = Color.White;
		field_548.FocusedBorderColor = Color.FromArgb(100, 88, 255);
		field_548.FocusedForeColor = SystemColors.ControlText;
		((Control)field_548).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_548).ForeColor = Color.Black;
		((Control)field_548).Location = new Point(29, 40);
		((Control)field_548).Name = "textBoxPwd";
		field_548.PasswordChar = '\0';
		((Control)field_548).RightToLeft = (RightToLeft)0;
		field_548.SelectedText = "";
		((Control)field_548).Size = new Size(101, 26);
		((Control)field_548).TabIndex = 3;
		field_548.TextAlign = (HorizontalAlignment)2;
		field_549.BaseColor = Color.White;
		field_549.BorderColor = Color.Silver;
		((Control)field_549).Cursor = Cursors.IBeam;
		field_549.FocusedBaseColor = Color.White;
		field_549.FocusedBorderColor = Color.FromArgb(100, 88, 255);
		field_549.FocusedForeColor = SystemColors.ControlText;
		((Control)field_549).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_549).ForeColor = Color.Black;
		((Control)field_549).Location = new Point(200, 40);
		((Control)field_549).Name = "textBoxUsn";
		field_549.PasswordChar = '\0';
		field_549.SelectedText = "";
		((Control)field_549).Size = new Size(89, 26);
		((Control)field_549).TabIndex = 2;
		((Control)field_549).Text = "root";
		field_549.TextAlign = (HorizontalAlignment)2;
		((Control)field_550).Anchor = (AnchorStyles)9;
		field_550.BaseColor = SystemColors.Control;
		field_550.CheckedOffColor = Color.DarkGray;
		field_550.CheckedOnColor = Color.FromArgb(192, 0, 0);
		field_550.FillColor = Color.White;
		((Control)field_550).Location = new Point(97, 122);
		((Control)field_550).Name = "cb_ForceUpdate";
		((Control)field_550).Size = new Size(28, 20);
		((Control)field_550).TabIndex = 80;
		field_550.CheckedChanged += method_567;
		((Control)field_551).Anchor = (AnchorStyles)10;
		((Control)field_551).AutoSize = true;
		((Control)field_551).Font = UiFonts.Create(9f);
		((Control)field_551).ForeColor = Color.Maroon;
		((Control)field_551).Location = new Point(20, 124);
		((Control)field_551).Margin = new Padding(2, 0, 2, 0);
		((Control)field_551).Name = "label5";
		((Control)field_551).RightToLeft = (RightToLeft)0;
		((Control)field_551).Size = new Size(72, 15);
		((Control)field_551).TabIndex = 79;
		((Control)field_551).Text = "تحديث اجباري";
		field_551.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.DarkRed;
		((Form)this).ClientSize = new Size(552, 448);
		((Control)this).Controls.Add((Control)(object)field_542);
		((Control)this).Controls.Add((Control)(object)field_540);
		((Control)this).Controls.Add((Control)(object)field_533);
		((Control)this).Controls.Add((Control)(object)field_527);
		((Control)this).Controls.Add((Control)(object)field_541);
		((Control)this).Name = "UploadPKG";
		((Control)this).RightToLeft = (RightToLeft)1;
		((Form)this).RightToLeftLayout = true;
		((Form)this).ShowIcon = false;
		((Form)this).StartPosition = (FormStartPosition)1;
		((Control)this).Text = "التحديث والاظافات";
		((Form)this).TopMost = true;
		((Form)this).FormClosed += method_566;
		((Form)this).Load += method_565;
		((Control)field_527).ResumeLayout(false);
		((Control)field_527).PerformLayout();
		((Control)field_533).ResumeLayout(false);
		((Control)field_542).ResumeLayout(false);
		((Control)field_542).PerformLayout();
		((Control)this).ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_569()
	{
		method_553(field_525);
	}
}
}
