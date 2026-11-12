using System;
using System.ComponentModel;
using System.Net;
using System.Windows.Forms;
using Guna.UI.WinForms;

namespace AmaanWRT
{
public class CustomGunaTextBox : GunaTextBox
{
	private IPAddress field_143;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public IPAddress prop_148
	{
		get
		{
			return field_143;
		}
		set
		{
			field_143 = value;
			((Control)this).Text = field_143?.ToString();
		}
	}

	protected override void OnKeyPress(KeyPressEventArgs P_0)
	{
		if (!method_146(P_0.KeyChar))
		{
			P_0.Handled = true;
		}
		else
		{
			base.OnKeyPress(P_0);
		}
	}

	protected override void OnValidating(CancelEventArgs P_0)
	{
		if (!method_147(((Control)this).Text))
		{
			P_0.Cancel = true;
			((GunaTextBox)this).SelectAll();
		}
		base.OnValidating(P_0);
	}

	protected override void OnTextChanged(EventArgs P_0)
	{
		if (!base.DesignMode)
		{
			IPAddress address;
			if (string.IsNullOrEmpty(((Control)this).Text))
			{
				field_143 = null;
			}
			else if (!IPAddress.TryParse(((Control)this).Text, out address))
			{
				((GunaTextBox)this).SelectAll();
			}
			else
			{
				field_143 = address;
			}
			base.OnTextChanged(P_0);
		}
	}

	private static bool method_146(char P_0)
	{
		if (!char.IsDigit(P_0) && P_0 != '.')
		{
			return P_0 == '\b';
		}
		return true;
	}

	private static bool method_147(string P_0)
	{
		IPAddress address;
		return IPAddress.TryParse(P_0, out address);
	}
}
}
