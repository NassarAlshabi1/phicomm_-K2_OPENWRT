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
public class ScreenshotMessageForm : Form
{
	private readonly string field_477;

	private readonly string field_478;

	private readonly string field_479;

	private readonly AmaanSshClient field_480;

	private ShellStream field_481;

	private string field_482 = string.Empty;

	private IContainer field_483;

	private Button field_484;

	private RichTextBox field_485;

	private GunaTextBox field_486;

	private Button field_487;

	public ScreenshotMessageForm()
	{
		method_495();
	}

	public ScreenshotMessageForm(string P_0, string P_1, string P_2, AmaanSshClient P_3)
	{
		method_495();
		field_477 = P_0;
		field_478 = P_1;
		field_479 = P_2;
		field_480 = P_3;
		field_481 = ((SshClient)P_3).CreateShellStream("ansi", 80u, 60u, 800u, 600u, 65536);
		field_482 = field_481.Expect(new Regex(":.[*>#]"), new TimeSpan(0, 0, 3), -1);
		((TextBoxBase)field_485).AppendText(field_482);
		field_481.DataReceived += method_488;
		((TextBoxBase)field_485).SelectionStart = ((Control)field_485).Text.Length;
		((TextBoxBase)field_485).ScrollToCaret();
	}

	public ScreenshotMessageForm(string P_0, string P_1, string P_2)
	{
		method_495();
		field_477 = P_0;
		field_478 = P_1;
		field_479 = P_2;
		if (field_480 == null)
		{
			field_480 = new AmaanSshClient(P_0, P_1, P_2);
			((BaseClient)field_480).ConnectionInfo.Timeout = TimeSpan.FromSeconds(5.0);
			((BaseClient)field_480).Connect();
			field_481 = ((SshClient)field_480).CreateShellStream("ansi", 80u, 60u, 800u, 600u, 65536);
			field_482 = field_481.Expect(new Regex(":.[*>#]"), new TimeSpan(0, 0, 3), -1);
			((TextBoxBase)field_485).AppendText(field_482);
			field_481.DataReceived += method_488;
			((TextBoxBase)field_485).SelectionStart = ((Control)field_485).Text.Length;
			((TextBoxBase)field_485).ScrollToCaret();
		}
		else
		{
			((BaseClient)field_480).Disconnect();
			((BaseClient)field_480).Dispose();
			field_480 = null;
		}
	}

	private void method_488(object P_0, ShellDataEventArgs P_1)
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected Obj, but got Unknown
		field_482 = field_481.Read();
		((Control)this).Invoke((Delegate)(MethodInvoker)(() =>
		{
			method_489(field_482);
		}));
	}

	private void method_489(string P_0)
	{
		((TextBoxBase)field_485).AppendText(P_0);
	}

	private void method_490(object P_0, EventArgs P_1)
	{
	}

	private void method_491(object P_0, EventArgs P_1)
	{
		field_481.Write(((Control)field_486).Text + "\n");
		((Stream)(object)field_481).Flush();
	}

	private void method_492(object P_0, EventArgs P_1)
	{
		((TextBoxBase)field_485).Clear();
	}

	private void method_493(object P_0, KeyEventArgs P_1)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		if ((int)P_1.KeyCode == 13)
		{
			field_481.Write(((Control)field_486).Text + "\n");
			((Stream)(object)field_481).Flush();
			P_1.Handled = true;
		}
	}

	private void method_494(object P_0, EventArgs P_1)
	{
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && field_483 != null)
		{
			field_483.Dispose();
		}
		base.Dispose(P_0);
	}

	private void method_495()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected Obj, but got Unknown
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected Obj, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected Obj, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected Obj, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected Obj, but got Unknown
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Unknown result type (might be due to invalid IL or missing references)
		//IL_014c: Expected Obj, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_0276: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Expected Obj, but got Unknown
		//IL_031a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0324: Expected Obj, but got Unknown
		//IL_0361: Unknown result type (might be due to invalid IL or missing references)
		//IL_036b: Expected Obj, but got Unknown
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		field_484 = new Button();
		field_485 = new RichTextBox();
		field_486 = new GunaTextBox();
		field_487 = new Button();
		((Control)this).SuspendLayout();
		((Control)field_484).Anchor = (AnchorStyles)9;
		((Control)field_484).BackColor = Color.Black;
		((ButtonBase)field_484).FlatStyle = (FlatStyle)0;
		((Control)field_484).Font = new Font("Tahoma", 10f);
		((Control)field_484).ForeColor = Color.White;
		((Control)field_484).Location = new Point(453, 11);
		((Control)field_484).Margin = new Padding(2);
		((Control)field_484).Name = "button1";
		((Control)field_484).Size = new Size(63, 30);
		((Control)field_484).TabIndex = 14;
		((Control)field_484).Text = "ارسال";
		((ButtonBase)field_484).UseVisualStyleBackColor = false;
		((Control)field_484).Click += method_491;
		((Control)field_485).Anchor = (AnchorStyles)15;
		((Control)field_485).BackColor = Color.FromArgb(0, 0, 64);
		((Control)field_485).Font = new Font("Tahoma", 10f);
		((Control)field_485).ForeColor = Color.White;
		((Control)field_485).Location = new Point(11, 49);
		((Control)field_485).Margin = new Padding(2);
		((Control)field_485).Name = "richTextBoxAns";
		((Control)field_485).RightToLeft = (RightToLeft)0;
		((Control)field_485).Size = new Size(601, 358);
		((Control)field_485).TabIndex = 13;
		((Control)field_485).Text = "";
		((Control)field_486).Anchor = (AnchorStyles)13;
		((Control)field_486).BackColor = Color.Transparent;
		field_486.BaseColor = Color.MintCream;
		field_486.BorderColor = Color.DimGray;
		field_486.BorderSize = 1;
		((Control)field_486).Cursor = Cursors.IBeam;
		field_486.FocusedBaseColor = Color.White;
		field_486.FocusedBorderColor = Color.FromArgb(100, 88, 255);
		field_486.FocusedForeColor = SystemColors.ControlText;
		((Control)field_486).Font = new Font("Segoe UI", 11f);
		((Control)field_486).ForeColor = Color.Black;
		((Control)field_486).Location = new Point(12, 11);
		((Control)field_486).Name = "textBoxCommand";
		field_486.PasswordChar = '\0';
		field_486.Radius = 9;
		((Control)field_486).RightToLeft = (RightToLeft)0;
		field_486.SelectedText = "";
		((Control)field_486).Size = new Size(436, 30);
		((Control)field_486).TabIndex = 44;
		((Control)field_486).KeyDown += method_493;
		((Control)field_487).Anchor = (AnchorStyles)9;
		((Control)field_487).BackColor = Color.FromArgb(0, 0, 64);
		((ButtonBase)field_487).FlatStyle = (FlatStyle)0;
		((Control)field_487).Font = new Font("Tahoma", 7f);
		((Control)field_487).ForeColor = Color.White;
		((Control)field_487).Location = new Point(534, 11);
		((Control)field_487).Margin = new Padding(2);
		((Control)field_487).Name = "button2";
		((Control)field_487).Size = new Size(78, 30);
		((Control)field_487).TabIndex = 45;
		((Control)field_487).Text = "مسج الشاشه";
		((ButtonBase)field_487).UseVisualStyleBackColor = false;
		((Control)field_487).Click += method_492;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Control)this).BackColor = Color.FromArgb(64, 64, 64);
		((Form)this).ClientSize = new Size(623, 418);
		((Control)this).Controls.Add((Control)(object)field_487);
		((Control)this).Controls.Add((Control)(object)field_486);
		((Control)this).Controls.Add((Control)(object)field_484);
		((Control)this).Controls.Add((Control)(object)field_485);
		((Control)this).Name = "Terminal";
		((Form)this).ShowIcon = false;
		((Control)this).Text = "Terminal";
		((Form)this).Load += method_494;
		((Control)this).ResumeLayout(false);
	}

	[CompilerGenerated]
	private void method_496()
	{
		method_489(field_482);
	}
}
}
