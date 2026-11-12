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
public class TemplateForm : Form
{
	private string field_72;

	private IContainer field_73;

	private Button field_74;

	private GunaComboBox field_75;

	private Button field_76;

	private RadioButton field_77;

	private RadioButton field_78;

	private GunaTextBox field_79;

	public TemplateForm()
	{
		method_84();
	}

	public TemplateForm(string P_0, string[] P_1)
	{
		method_84();
		foreach (string text in P_1)
		{
			((ComboBox)field_75).Items.Add((object)text);
		}
		((Control)field_75).Text = P_0;
	}

	private void method_80(object P_0, EventArgs P_1)
	{
	}

	private void method_81(object P_0, EventArgs P_1)
	{
		((Control)field_79).Visible = true;
	}

	private void method_82(object P_0, EventArgs P_1)
	{
		((Control)field_79).Visible = false;
	}

	public string method_83()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		if ((int)((Form)this).ShowDialog() == 6)
		{
			if (field_77.Checked)
			{
				field_72 = ((Control)field_75).Text;
			}
			else
			{
				field_72 = ((Control)field_79).Text;
			}
		}
		else
		{
			field_72 = null;
		}
		return field_72;
	}

	protected override void Dispose(bool P_0)
	{
		if (P_0 && field_73 != null)
		{
			field_73.Dispose();
		}
		base.Dispose(P_0);
	}

	private void method_84()
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
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Expected Obj, but got Unknown
		//IL_0143: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Expected Obj, but got Unknown
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_020e: Expected Obj, but got Unknown
		//IL_029b: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a5: Expected Obj, but got Unknown
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_037c: Expected Obj, but got Unknown
		//IL_04b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04c3: Expected Obj, but got Unknown
		field_74 = new Button();
		field_75 = new GunaComboBox();
		field_76 = new Button();
		field_77 = new RadioButton();
		field_78 = new RadioButton();
		field_79 = new GunaTextBox();
		((Control)this).SuspendLayout();
		field_74.DialogResult = (DialogResult)6;
		((Control)field_74).Font = UiFonts.Create(10f, (FontStyle)1);
		((Control)field_74).Location = new Point(15, 81);
		((Control)field_74).Name = "Btn_save";
		((Control)field_74).Size = new Size(102, 31);
		((Control)field_74).TabIndex = 0;
		((Control)field_74).Text = "حفظ";
		((ButtonBase)field_74).UseVisualStyleBackColor = true;
		((Control)field_75).BackColor = Color.Transparent;
		field_75.BaseColor = Color.White;
		field_75.BorderColor = Color.Silver;
		field_75.BorderSize = 1;
		((ComboBox)field_75).DrawMode = (DrawMode)1;
		((ComboBox)field_75).DropDownStyle = (ComboBoxStyle)2;
		field_75.FocusedColor = Color.Empty;
		((Control)field_75).Font = UiFonts.Create(10f);
		((Control)field_75).ForeColor = Color.Black;
		((ListControl)field_75).FormattingEnabled = true;
		((Control)field_75).Location = new Point(12, 39);
		((Control)field_75).Name = "CBox_TemplateName";
		field_75.OnHoverItemBaseColor = Color.FromArgb(100, 88, 255);
		field_75.OnHoverItemForeColor = Color.White;
		field_75.Radius = 9;
		((Control)field_75).Size = new Size(246, 26);
		((Control)field_75).TabIndex = 15;
		field_76.DialogResult = (DialogResult)2;
		((Control)field_76).Font = UiFonts.Create(10f, (FontStyle)1);
		((Control)field_76).Location = new Point(152, 81);
		((Control)field_76).Name = "Btn_Cancel";
		((Control)field_76).Size = new Size(103, 31);
		((Control)field_76).TabIndex = 16;
		((Control)field_76).Text = "الغاء العمليه";
		((ButtonBase)field_76).UseVisualStyleBackColor = true;
		((Control)field_77).AutoSize = true;
		field_77.Checked = true;
		((Control)field_77).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_77).ForeColor = Color.Black;
		((Control)field_77).Location = new Point(15, 15);
		((Control)field_77).Name = "RB_current";
		((Control)field_77).RightToLeft = (RightToLeft)1;
		((Control)field_77).Size = new Size(94, 18);
		((Control)field_77).TabIndex = 52;
		field_77.TabStop = true;
		((Control)field_77).Tag = "";
		((Control)field_77).Text = "قالب سابق ";
		((ButtonBase)field_77).UseVisualStyleBackColor = true;
		field_77.CheckedChanged += method_82;
		((Control)field_78).AutoSize = true;
		((Control)field_78).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_78).ForeColor = Color.Black;
		((Control)field_78).Location = new Point(152, 15);
		((Control)field_78).Name = "RB_New";
		((Control)field_78).RightToLeft = (RightToLeft)1;
		((Control)field_78).Size = new Size(83, 18);
		((Control)field_78).TabIndex = 53;
		((Control)field_78).Tag = "";
		((Control)field_78).Text = "قالب جديد";
		((ButtonBase)field_78).UseVisualStyleBackColor = true;
		field_78.CheckedChanged += method_81;
		((Control)field_79).BackColor = Color.Transparent;
		field_79.BaseColor = Color.FloralWhite;
		field_79.BorderColor = Color.DimGray;
		field_79.BorderSize = 1;
		((Control)field_79).Cursor = Cursors.IBeam;
		field_79.FocusedBaseColor = SystemColors.Window;
		field_79.FocusedBorderColor = Color.FromArgb(100, 88, 255);
		field_79.FocusedForeColor = SystemColors.ControlText;
		((Control)field_79).Font = UiFonts.Create(9f, (FontStyle)1);
		((Control)field_79).ForeColor = Color.Black;
		((Control)field_79).Location = new Point(15, 39);
		((Control)field_79).Name = "TBox_TemplateName";
		field_79.PasswordChar = '\0';
		field_79.Radius = 9;
		((Control)field_79).RightToLeft = (RightToLeft)0;
		field_79.SelectedText = "";
		((Control)field_79).Size = new Size(243, 26);
		((Control)field_79).TabIndex = 54;
		field_79.TextAlign = (HorizontalAlignment)2;
		((Control)field_79).Visible = false;
		((ContainerControl)this).AutoScaleDimensions = new SizeF(6f, 13f);
		((ContainerControl)this).AutoScaleMode = (AutoScaleMode)1;
		((Form)this).ClientSize = new Size(270, 124);
		((Form)this).ControlBox = false;
		((Control)this).Controls.Add((Control)(object)field_79);
		((Control)this).Controls.Add((Control)(object)field_78);
		((Control)this).Controls.Add((Control)(object)field_77);
		((Control)this).Controls.Add((Control)(object)field_76);
		((Control)this).Controls.Add((Control)(object)field_75);
		((Control)this).Controls.Add((Control)(object)field_74);
		((Form)this).FormBorderStyle = (FormBorderStyle)3;
		((Control)this).Name = "DLG_SaveTemplate";
		((Control)this).RightToLeft = (RightToLeft)1;
		((Form)this).RightToLeftLayout = true;
		((Control)this).Text = "حفظ قالب الإعدادات";
		((Form)this).TopMost = true;
		((Form)this).Load += method_80;
		((Control)this).ResumeLayout(false);
		((Control)this).PerformLayout();
	}
}
}
