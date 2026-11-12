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
public class IpInstallerForm : Form
{
	public class IpValidator
	{
		public static bool method_86(TextBox P_0)
		{
			string text = ((Control)P_0).Text.Trim();
			if (string.IsNullOrEmpty(text))
			{
				return false;
			}
			try
			{
				IPAddress.Parse(text);
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
	}

	private string[] field_87 = new string[0];

	private string[] field_88 = new string[0];

	private string field_89 = "255.255.255.0";

	public const int field_90 = 161;

	public const int field_91 = 2;

	private IContainer field_92;

	private GunaCheckBox field_93;

	private GunaCheckBox field_94;

	private GunaCheckBox field_95;

	private GunaCheckBox field_96;

	private GunaCheckBox field_97;

	private GunaCheckBox field_98;

	private GunaCheckBox field_99;

	private GunaCheckBox field_100;

	private GunaCheckBox field_101;

	private GunaCheckBox field_102;

	private GunaCheckBox field_103;

	private GunaCheckBox field_104;

	private TextBox field_105;

	private GunaCheckBox field_106;

	private GunaCheckBox field_107;

	private TextBox field_108;

	private GunaGradientButton field_109;

	private GunaGradientButton field_110;

	private Panel field_111;

	private Label field_112;

	private Label field_113;

	private GunaComboBox field_114;

	private Label field_115;

	private GunaControlBox field_116;

	private Label field_117;

	public IpInstallerForm()
	{
		method_131();
	}

	[DllImport("User32.dll", EntryPoint = "ReleaseCapture")]
	public static extern bool method_118();

	[DllImport("User32.dll", EntryPoint = "SendMessage")]
	public static extern int method_119(IntPtr P_0, int P_1, int P_2, int P_3);

	private void method_120(object P_0, MouseEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		if ((int)P_1.Button == 1048576)
		{
			method_118();
			method_119(((Control)this).Handle, 161, 2, 0);
		}
	}

	private void method_121(object P_0, EventArgs P_1)
	{
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		field_87 = method_122(((Control)field_111).Controls);
		List<string> list = new List<string>();
		string[] array = field_87;
		for (int i = 0; i < array.Length; i++)
		{
			_ = array[i];
			list.Add("255.255.255.0");
		}
		field_88 = list.ToArray();
		if (method_127(((KeyValuePair<string, string>)((ComboBox)field_114).SelectedItem).Key, field_87, field_88))
		{
			MessageBox.Show("تم التثبيت");
		}
	}

	public string[] method_122(System.Windows.Forms.Control.ControlCollection P_0)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected Obj, but got Unknown
		List<string> list = new List<string>();
		foreach (Control item in (ArrangedElementCollection)P_0)
		{
			Control val = item;
			GunaCheckBox val2 = (GunaCheckBox)(object)((val is GunaCheckBox) ? val : null);
			if (val2 != null)
			{
				if (val2.Checked)
				{
					list.Add(((Control)val2).Text);
				}
			}
			else if (((ArrangedElementCollection)val.Controls).Count > 0)
			{
				list.AddRange(method_122(val.Controls));
			}
		}
		if (field_106.Checked)
		{
			if (IpValidator.method_86(field_105))
			{
				list.Add(((Control)field_105).Text);
			}
			else
			{
				field_106.Checked = false;
			}
		}
		if (field_107.Checked)
		{
			if (IpValidator.method_86(field_108))
			{
				list.Add(((Control)field_108).Text);
			}
			else
			{
				field_107.Checked = false;
			}
		}
		return list.ToArray();
	}

	private void method_123(object P_0, EventArgs P_1)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (method_124(((Control)field_114).Text, ((Control)field_115).Text))
		{
			MessageBox.Show("تم تعيين الايبي في المنفذ الى تلقائي");
		}
	}

	public static bool method_124(string P_0, string P_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		var enumerator = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ManagementObject val = (ManagementObject)enumerator.Current;
				if (!(((ManagementBaseObject)val)["Description"].ToString() == P_1))
				{
					continue;
				}
				try
				{
					ManagementBaseObject val2 = val.InvokeMethod("EnableDHCP", (ManagementBaseObject)null, (InvokeMethodOptions)null);
					if ((uint)val2.Properties["ReturnValue"].Value != 0)
					{
						method_125(string.Format("Failed to enable DHCP on adapter '{0}'. Error code: {1}", P_1, val2.Properties["ReturnValue"].Value));
						return false;
					}
					return true;
				}
				catch (Exception ex)
				{
					method_125("Error occurred while setting DHCP on adapter '" + P_1 + "': " + ex.Message);
					return false;
				}
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		method_125("Network adapter with description '" + P_1 + "' not found.");
		return false;
	}

	private static void method_125(string P_0)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		MessageBox.Show(P_0);
	}

	public static bool method_126(string P_0, string P_1)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		var enumerator = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ManagementObject val = (ManagementObject)enumerator.Current;
				if (((ManagementBaseObject)val)["Description"].ToString() == P_1)
				{
					try
					{
						ManagementBaseObject methodParameters = val.GetMethodParameters("SetDNSServerSearchOrder");
						methodParameters["DNSServerSearchOrder"] = null;
						val.InvokeMethod("EnableDHCP", (ManagementBaseObject)null, (InvokeMethodOptions)null);
						val.InvokeMethod("SetDNSServerSearchOrder", methodParameters, (InvokeMethodOptions)null);
					}
					catch
					{
						MessageBox.Show("غير قادر على تحول المنفذ الى تلقائي");
						return false;
					}
				}
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		return false;
	}

	public static bool method_127(string P_0, string[] P_1, string[] P_2)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected Obj, but got Unknown
		var enumerator = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ManagementObject val = (ManagementObject)enumerator.Current;
				if (!((ManagementBaseObject)val)["Description"].Equals(P_0))
				{
					continue;
				}
				try
				{
					try
					{
						method_124("", P_0);
					}
					catch
					{
					}
					ManagementBaseObject methodParameters = val.GetMethodParameters("EnableStatic");
					methodParameters["IPAddress"] = P_1;
					methodParameters["SubnetMask"] = P_2;
					ManagementBaseObject val2 = val.InvokeMethod("EnableStatic", methodParameters, (InvokeMethodOptions)null);
					if ((uint)val2.Properties["ReturnValue"].Value != 0)
					{
						method_125(string.Format("Failed to set static IP address on adapter '{0}'. Error code: {1}", P_0, val2.Properties["ReturnValue"].Value));
						return false;
					}
					return true;
				}
				catch (Exception ex)
				{
					method_125("Error occurred while setting IP address on adapter '" + P_0 + "': " + ex.Message);
					return false;
				}
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		method_125("Network adapter with description '" + P_0 + "' not found.");
		return false;
	}

	public static bool method_128(string P_0, string[] P_1, string[] P_2)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		var enumerator = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ManagementObject val = (ManagementObject)enumerator.Current;
				if (((ManagementBaseObject)val)["Description"].Equals(P_0))
				{
					MessageBox.Show("ok");
					try
					{
						val.InvokeMethod("EnableDHCP", (object[])null);
						ManagementBaseObject methodParameters = val.GetMethodParameters("EnableStatic");
						methodParameters["IPAddress"] = P_1;
						methodParameters["SubnetMask"] = P_2;
						val.InvokeMethod("EnableStatic", methodParameters, (InvokeMethodOptions)null);
						return true;
					}
					catch
					{
						MessageBox.Show("غير قادر على التثبيت");
						return false;
					}
				}
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		return false;
	}

	private void method_129(object P_0, EventArgs P_1)
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected Obj, but got Unknown
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
		foreach (NetworkInterface networkInterface in allNetworkInterfaces)
		{
			if (!networkInterface.Description.Contains("Virtual") && !networkInterface.Description.Contains("TAP") && !networkInterface.Description.Contains("Bluetooth") && networkInterface.NetworkInterfaceType != NetworkInterfaceType.Loopback)
			{
				dictionary.Add(networkInterface.Description, networkInterface.Name);
			}
		}
		((ComboBox)field_114).DataSource = (object)new BindingSource((object)dictionary, (string)null);
		((ListControl)field_114).DisplayMember = "Value";
		((ListControl)field_114).ValueMember = "Key";
		if (((ComboBox)field_114).Items.Count > 0)
		{
			((ListControl)field_114).SelectedIndex = 0;
		}
	}

	private void method_130(object P_0, EventArgs P_1)
	{
		((Control)field_115).Text = ((KeyValuePair<string, string>)((ComboBox)field_114).SelectedItem).Key;
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && field_92 != null)
		{
			field_92.Dispose();
		}
		base.Dispose(P_0);
	}

	private void method_131()
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
		//IL_0187: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Obj, but got Unknown
		//IL_0257: Unknown result type (might be due to invalid IL or missing references)
		//IL_0261: Expected Obj, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_032e: Expected Obj, but got Unknown
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fe: Expected Obj, but got Unknown
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d2: Expected Obj, but got Unknown
		//IL_0598: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a2: Expected Obj, but got Unknown
		//IL_0664: Unknown result type (might be due to invalid IL or missing references)
		//IL_066e: Expected Obj, but got Unknown
		//IL_0738: Unknown result type (might be due to invalid IL or missing references)
		//IL_0742: Expected Obj, but got Unknown
		//IL_0808: Unknown result type (might be due to invalid IL or missing references)
		//IL_0812: Expected Obj, but got Unknown
		//IL_08d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_08e3: Expected Obj, but got Unknown
		//IL_09aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b4: Expected Obj, but got Unknown
		//IL_0a7a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a84: Expected Obj, but got Unknown
		//IL_0afb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b05: Expected Obj, but got Unknown
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bc3: Expected Obj, but got Unknown
		//IL_0c6e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c78: Expected Obj, but got Unknown
		//IL_0cdf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ce9: Expected Obj, but got Unknown
		//IL_0dd9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0de3: Expected Obj, but got Unknown
		//IL_0fbd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0fc7: Expected Obj, but got Unknown
		//IL_1238: Unknown result type (might be due to invalid IL or missing references)
		//IL_1242: Expected Obj, but got Unknown
		//IL_12ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_12b6: Expected Obj, but got Unknown
		//IL_12d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1350: Unknown result type (might be due to invalid IL or missing references)
		//IL_135a: Expected Obj, but got Unknown
		//IL_1386: Unknown result type (might be due to invalid IL or missing references)
		//IL_13ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f8: Expected Obj, but got Unknown
		//IL_1479: Unknown result type (might be due to invalid IL or missing references)
		//IL_1483: Expected Obj, but got Unknown
		//IL_1551: Unknown result type (might be due to invalid IL or missing references)
		//IL_155b: Expected Obj, but got Unknown
		//IL_1589: Unknown result type (might be due to invalid IL or missing references)
		//IL_16dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_16e7: Expected Obj, but got Unknown
		//IL_1705: Unknown result type (might be due to invalid IL or missing references)
		//IL_18c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_18d3: Expected Obj, but got Unknown
		field_93 = new GunaCheckBox();
		field_94 = new GunaCheckBox();
		field_95 = new GunaCheckBox();
		field_96 = new GunaCheckBox();
		field_97 = new GunaCheckBox();
		field_98 = new GunaCheckBox();
		field_99 = new GunaCheckBox();
		field_100 = new GunaCheckBox();
		field_101 = new GunaCheckBox();
		field_102 = new GunaCheckBox();
		field_103 = new GunaCheckBox();
		field_104 = new GunaCheckBox();
		field_105 = new TextBox();
		field_106 = new GunaCheckBox();
		field_107 = new GunaCheckBox();
		field_108 = new TextBox();
		field_109 = new GunaGradientButton();
		field_110 = new GunaGradientButton();
		field_111 = new Panel();
		field_112 = new Label();
		field_113 = new Label();
		field_114 = new GunaComboBox();
		field_115 = new Label();
		field_116 = new GunaControlBox();
		field_117 = new Label();
		((Control)field_111).SuspendLayout();
		((Control)this).SuspendLayout();
		field_93.BaseColor = Color.Transparent;
		field_93.Checked = true;
		field_93.CheckedOffColor = Color.Gray;
		field_93.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_93.FillColor = Color.White;
		((Control)field_93).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_93).Location = new Point(158, 7);
		((Control)field_93).Name = "cb_5GName";
		((Control)field_93).RightToLeft = (RightToLeft)1;
		((Control)field_93).Size = new Size(122, 23);
		((Control)field_93).TabIndex = 34;
		((Control)field_93).Text = "192.168.1.222";
		field_94.BaseColor = Color.Transparent;
		field_94.Checked = true;
		field_94.CheckedOffColor = Color.Gray;
		field_94.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_94.FillColor = Color.White;
		((Control)field_94).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_94).Location = new Point(7, 36);
		((Control)field_94).Name = "gunaCheckBox1";
		((Control)field_94).RightToLeft = (RightToLeft)1;
		((Control)field_94).Size = new Size(122, 23);
		((Control)field_94).TabIndex = 35;
		((Control)field_94).Text = "192.168.2.222";
		field_95.BaseColor = Color.Transparent;
		field_95.Checked = true;
		field_95.CheckedOffColor = Color.Gray;
		field_95.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_95.FillColor = Color.White;
		((Control)field_95).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_95).Location = new Point(7, 65);
		((Control)field_95).Name = "gunaCheckBox2";
		((Control)field_95).RightToLeft = (RightToLeft)1;
		((Control)field_95).Size = new Size(130, 23);
		((Control)field_95).TabIndex = 36;
		((Control)field_95).Text = "192.168.10.222";
		field_96.BaseColor = Color.Transparent;
		field_96.Checked = true;
		field_96.CheckedOffColor = Color.Gray;
		field_96.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_96.FillColor = Color.White;
		((Control)field_96).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_96).Location = new Point(158, 65);
		((Control)field_96).Name = "gunaCheckBox3";
		((Control)field_96).RightToLeft = (RightToLeft)1;
		((Control)field_96).Size = new Size(130, 23);
		((Control)field_96).TabIndex = 37;
		((Control)field_96).Text = "192.168.17.222";
		field_97.BaseColor = Color.Transparent;
		field_97.Checked = true;
		field_97.CheckedOffColor = Color.Gray;
		field_97.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_97.FillColor = Color.White;
		((Control)field_97).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_97).Location = new Point(7, 94);
		((Control)field_97).Name = "gunaCheckBox4";
		((Control)field_97).RightToLeft = (RightToLeft)1;
		((Control)field_97).Size = new Size(130, 23);
		((Control)field_97).TabIndex = 38;
		((Control)field_97).Text = "192.168.30.222";
		field_98.BaseColor = Color.Transparent;
		field_98.Checked = true;
		field_98.CheckedOffColor = Color.Gray;
		field_98.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_98.FillColor = Color.White;
		((Control)field_98).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_98).Location = new Point(7, 7);
		((Control)field_98).Name = "gunaCheckBox5";
		((Control)field_98).RightToLeft = (RightToLeft)1;
		((Control)field_98).Size = new Size(122, 23);
		((Control)field_98).TabIndex = 39;
		((Control)field_98).Text = "192.168.0.222";
		field_99.BaseColor = Color.Transparent;
		field_99.Checked = true;
		field_99.CheckedOffColor = Color.Gray;
		field_99.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_99.FillColor = Color.White;
		((Control)field_99).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_99).Location = new Point(158, 94);
		((Control)field_99).Name = "gunaCheckBox6";
		((Control)field_99).RightToLeft = (RightToLeft)1;
		((Control)field_99).Size = new Size(130, 23);
		((Control)field_99).TabIndex = 40;
		((Control)field_99).Text = "192.168.33.222";
		field_100.BaseColor = Color.Transparent;
		field_100.Checked = true;
		field_100.CheckedOffColor = Color.Gray;
		field_100.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_100.FillColor = Color.White;
		((Control)field_100).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_100).Location = new Point(7, 123);
		((Control)field_100).Name = "gunaCheckBox7";
		((Control)field_100).RightToLeft = (RightToLeft)1;
		((Control)field_100).Size = new Size(130, 23);
		((Control)field_100).TabIndex = 41;
		((Control)field_100).Text = "192.168.77.222";
		field_101.BaseColor = Color.Transparent;
		field_101.Checked = true;
		field_101.CheckedOffColor = Color.Gray;
		field_101.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_101.FillColor = Color.White;
		((Control)field_101).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_101).Location = new Point(158, 36);
		((Control)field_101).Name = "gunaCheckBox8";
		((Control)field_101).RightToLeft = (RightToLeft)1;
		((Control)field_101).Size = new Size(122, 23);
		((Control)field_101).TabIndex = 42;
		((Control)field_101).Text = "192.168.6.222";
		field_102.BaseColor = Color.Transparent;
		field_102.Checked = true;
		field_102.CheckedOffColor = Color.Gray;
		field_102.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_102.FillColor = Color.White;
		((Control)field_102).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_102).Location = new Point(158, 123);
		((Control)field_102).Name = "gunaCheckBox9";
		((Control)field_102).RightToLeft = (RightToLeft)1;
		((Control)field_102).Size = new Size(123, 20);
		((Control)field_102).TabIndex = 43;
		((Control)field_102).Text = "192.168.100.222";
		field_103.BaseColor = Color.Transparent;
		field_103.Checked = true;
		field_103.CheckedOffColor = Color.Gray;
		field_103.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_103.FillColor = Color.White;
		((Control)field_103).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_103).Location = new Point(7, 149);
		((Control)field_103).Name = "gunaCheckBox10";
		((Control)field_103).RightToLeft = (RightToLeft)1;
		((Control)field_103).Size = new Size(98, 23);
		((Control)field_103).TabIndex = 44;
		((Control)field_103).Text = "10.0.0.222";
		field_104.BaseColor = Color.Transparent;
		field_104.Checked = true;
		field_104.CheckedOffColor = Color.Gray;
		field_104.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_104.FillColor = Color.White;
		((Control)field_104).Font = UiFonts.Create(9f, (FontStyle)1, (GraphicsUnit)3, (byte)0);
		((Control)field_104).Location = new Point(158, 149);
		((Control)field_104).Name = "gunaCheckBox11";
		((Control)field_104).RightToLeft = (RightToLeft)1;
		((Control)field_104).Size = new Size(114, 23);
		((Control)field_104).TabIndex = 45;
		((Control)field_104).Text = "172.16.0.222";
		((Control)field_105).Font = UiFonts.Create(10f);
		((Control)field_105).Location = new Point(22, 311);
		((Control)field_105).Name = "TB1";
		((Control)field_105).RightToLeft = (RightToLeft)0;
		((Control)field_105).Size = new Size(109, 24);
		((Control)field_105).TabIndex = 47;
		field_105.TextAlign = (HorizontalAlignment)2;
		field_106.BaseColor = Color.Transparent;
		field_106.CheckedOffColor = Color.Gray;
		field_106.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_106.FillColor = Color.White;
		((Control)field_106).Font = UiFonts.Create(11f);
		((Control)field_106).Location = new Point(132, 313);
		((Control)field_106).Name = "CB_other1";
		((Control)field_106).RightToLeft = (RightToLeft)1;
		((Control)field_106).Size = new Size(20, 20);
		((Control)field_106).TabIndex = 48;
		field_107.BaseColor = Color.Transparent;
		field_107.CheckedOffColor = Color.Gray;
		field_107.CheckedOnColor = Color.FromArgb(64, 0, 0);
		field_107.FillColor = Color.White;
		((Control)field_107).Font = UiFonts.Create(11f);
		((Control)field_107).Location = new Point(283, 313);
		((Control)field_107).Name = "CB_other2";
		((Control)field_107).RightToLeft = (RightToLeft)1;
		((Control)field_107).Size = new Size(20, 20);
		((Control)field_107).TabIndex = 50;
		((Control)field_108).Font = UiFonts.Create(10f);
		((Control)field_108).Location = new Point(173, 311);
		((Control)field_108).Name = "TB2";
		((Control)field_108).RightToLeft = (RightToLeft)0;
		((Control)field_108).Size = new Size(110, 24);
		((Control)field_108).TabIndex = 49;
		field_108.TextAlign = (HorizontalAlignment)2;
		field_109.AnimationHoverSpeed = 0.07f;
		field_109.AnimationSpeed = 0.03f;
		((Control)field_109).BackColor = Color.Transparent;
		field_109.BaseColor1 = Color.Blue;
		field_109.BaseColor2 = Color.Navy;
		field_109.BorderColor = Color.Black;
		field_109.DialogResult = (DialogResult)0;
		field_109.FocusedColor = Color.Empty;
		((Control)field_109).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_109).ForeColor = Color.White;
		field_109.Image = (Image)(object)ImageCache.method_605();
		field_109.ImageAlign = (HorizontalAlignment)2;
		field_109.ImageOffsetX = -5;
		field_109.ImageSize = new Size(15, 15);
		((Control)field_109).Location = new Point(10, 348);
		((Control)field_109).Name = "BtnIsIPConnected";
		field_109.OnHoverBaseColor1 = Color.Black;
		field_109.OnHoverBaseColor2 = Color.FromArgb(64, 64, 64);
		field_109.OnHoverBorderColor = Color.Black;
		field_109.OnHoverForeColor = Color.White;
		field_109.OnHoverImage = null;
		field_109.OnPressedColor = Color.Black;
		field_109.Radius = 5;
		((Control)field_109).Size = new Size(142, 28);
		((Control)field_109).TabIndex = 51;
		((Control)field_109).Text = "تثبيت";
		field_109.TextAlign = (HorizontalAlignment)2;
		field_109.TextOffsetX = -5;
		((Control)field_109).Click += method_121;
		field_110.AnimationHoverSpeed = 0.07f;
		field_110.AnimationSpeed = 0.03f;
		((Control)field_110).BackColor = Color.Transparent;
		field_110.BaseColor1 = Color.FromArgb(0, 192, 0);
		field_110.BaseColor2 = Color.DarkGreen;
		field_110.BorderColor = Color.Black;
		field_110.DialogResult = (DialogResult)0;
		field_110.FocusedColor = Color.Empty;
		((Control)field_110).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_110).ForeColor = Color.White;
		field_110.Image = (Image)(object)ImageCache.method_605();
		field_110.ImageAlign = (HorizontalAlignment)2;
		field_110.ImageOffsetX = -5;
		field_110.ImageSize = new Size(15, 15);
		((Control)field_110).Location = new Point(181, 348);
		((Control)field_110).Name = "gunaGradientButton1";
		field_110.OnHoverBaseColor1 = Color.Black;
		field_110.OnHoverBaseColor2 = Color.FromArgb(64, 64, 64);
		field_110.OnHoverBorderColor = Color.Black;
		field_110.OnHoverForeColor = Color.White;
		field_110.OnHoverImage = null;
		field_110.OnPressedColor = Color.Black;
		field_110.Radius = 5;
		((Control)field_110).Size = new Size(129, 28);
		((Control)field_110).TabIndex = 52;
		((Control)field_110).Text = "تلقائي";
		field_110.TextAlign = (HorizontalAlignment)2;
		field_110.TextOffsetX = -5;
		((Control)field_110).Click += method_123;
		((Control)field_111).BackColor = Color.WhiteSmoke;
		((Control)field_111).Controls.Add((Control)(object)field_94);
		((Control)field_111).Controls.Add((Control)(object)field_93);
		((Control)field_111).Controls.Add((Control)(object)field_95);
		((Control)field_111).Controls.Add((Control)(object)field_96);
		((Control)field_111).Controls.Add((Control)(object)field_97);
		((Control)field_111).Controls.Add((Control)(object)field_98);
		((Control)field_111).Controls.Add((Control)(object)field_99);
		((Control)field_111).Controls.Add((Control)(object)field_104);
		((Control)field_111).Controls.Add((Control)(object)field_100);
		((Control)field_111).Controls.Add((Control)(object)field_103);
		((Control)field_111).Controls.Add((Control)(object)field_101);
		((Control)field_111).Controls.Add((Control)(object)field_102);
		((Control)field_111).Font = UiFonts.Create(8f);
		((Control)field_111).Location = new Point(10, 128);
		((Control)field_111).Name = "panel1";
		((Control)field_111).Size = new Size(300, 179);
		((Control)field_111).TabIndex = 53;
		((Control)field_112).AutoSize = true;
		((Control)field_112).Font = UiFonts.Create(9f);
		((Control)field_112).Location = new Point(11, 110);
		((Control)field_112).Margin = new Padding(2, 0, 2, 0);
		((Control)field_112).Name = "label10";
		((Control)field_112).Size = new Size(161, 15);
		((Control)field_112).TabIndex = 54;
		((Control)field_112).Text = "قم بتحديد الرنجات المراد تثبيتها :";
		field_112.TextAlign = (ContentAlignment)64;
		((Control)field_113).BackColor = Color.Black;
		((Control)field_113).Font = UiFonts.Create(8.5f, (FontStyle)1);
		((Control)field_113).ForeColor = Color.White;
		((Control)field_113).Location = new Point(0, 6);
		((Control)field_113).Margin = new Padding(2, 0, 2, 0);
		((Control)field_113).Name = "label1";
		((Control)field_113).Size = new Size(288, 19);
		((Control)field_113).TabIndex = 55;
		((Control)field_113).Text = "يجب تشغيل البرنامج كمسئول حتى يستطيع تثبيت الايبيهات";
		field_113.TextAlign = (ContentAlignment)16;
		((Control)field_113).MouseDown += method_120;
		((Control)field_114).Anchor = (AnchorStyles)10;
		((Control)field_114).BackColor = Color.Transparent;
		field_114.BaseColor = Color.Yellow;
		field_114.BorderColor = Color.Silver;
		field_114.BorderSize = 1;
		((ComboBox)field_114).DrawMode = (DrawMode)1;
		((ComboBox)field_114).DropDownStyle = (ComboBoxStyle)2;
		field_114.FocusedColor = Color.Empty;
		((Control)field_114).Font = UiFonts.Create(10f);
		((Control)field_114).ForeColor = Color.Black;
		((ListControl)field_114).FormattingEnabled = true;
		((Control)field_114).Location = new Point(10, 53);
		((Control)field_114).Name = "comboBox_interfaces";
		field_114.OnHoverItemBaseColor = Color.FromArgb(100, 88, 255);
		field_114.OnHoverItemForeColor = Color.White;
		field_114.Radius = 9;
		((Control)field_114).Size = new Size(302, 26);
		((Control)field_114).TabIndex = 56;
		((ComboBox)field_114).SelectedIndexChanged += method_130;
		((Control)field_115).Anchor = (AnchorStyles)13;
		((Control)field_115).Font = UiFonts.Create(9f);
		((Control)field_115).ForeColor = Color.Gray;
		((Control)field_115).Location = new Point(11, 82);
		((Control)field_115).Margin = new Padding(2, 0, 2, 0);
		((Control)field_115).Name = "Lbl_interfaceDesc";
		((Control)field_115).Size = new Size(301, 19);
		((Control)field_115).TabIndex = 57;
		((Control)field_115).Text = "-";
		field_115.TextAlign = (ContentAlignment)32;
		((Control)field_116).Anchor = (AnchorStyles)9;
		field_116.AnimationHoverSpeed = 0.07f;
		field_116.AnimationSpeed = 0.03f;
		((Control)field_116).BackColor = Color.Red;
		field_116.IconColor = Color.White;
		field_116.IconSize = 15f;
		((Control)field_116).Location = new Point(293, 3);
		((Control)field_116).Name = "gunaControlBox1";
		field_116.OnHoverBackColor = Color.FromArgb(103, 58, 183);
		field_116.OnHoverIconColor = Color.White;
		field_116.OnPressedColor = Color.Black;
		((Control)field_116).Size = new Size(25, 25);
		((Control)field_116).TabIndex = 58;
		((Control)field_117).AutoSize = true;
		((Control)field_117).Font = UiFonts.Create(9f);
		((Control)field_117).Location = new Point(11, 35);
		((Control)field_117).Margin = new Padding(2, 0, 2, 0);
		((Control)field_117).Name = "label2";
		((Control)field_117).Size = new Size(121, 15);
		((Control)field_117).TabIndex = 59;
		((Control)field_117).Text = "قم بإختيار منفذ الشبكه :";
		field_117.TextAlign = (ContentAlignment)64;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.White;
		((Form)this).ClientSize = new Size(322, 388);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)field_117);
		((Control)this).Controls.Add((Control)(object)field_116);
		((Control)this).Controls.Add((Control)(object)field_115);
		((Control)this).Controls.Add((Control)(object)field_114);
		((Control)this).Controls.Add((Control)(object)field_113);
		((Control)this).Controls.Add((Control)(object)field_112);
		((Control)this).Controls.Add((Control)(object)field_111);
		((Control)this).Controls.Add((Control)(object)field_110);
		((Control)this).Controls.Add((Control)(object)field_109);
		((Control)this).Controls.Add((Control)(object)field_107);
		((Control)this).Controls.Add((Control)(object)field_108);
		((Control)this).Controls.Add((Control)(object)field_106);
		((Control)this).Controls.Add((Control)(object)field_105);
		((Form)this).FormBorderStyle = (FormBorderStyle)0;
		((Control)this).Name = "EtherStaticIP";
		((Control)this).RightToLeft = (RightToLeft)1;
		((Form)this).RightToLeftLayout = true;
		((Form)this).StartPosition = (FormStartPosition)4;
		((Control)this).Text = "تثبيت ايبيهات بمنفذ الكمبيوتر";
		((Form)this).Load += method_129;
		((Control)this).MouseDown += method_120;
		((Control)field_111).ResumeLayout(false);
		((Control)field_111).PerformLayout();
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
}
