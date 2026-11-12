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
[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class ImageCache
{
	private static ResourceManager field_570;

	private static CultureInfo field_571;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager prop_606
	{
		get
		{
			if (field_570 == null)
			{
				field_570 = new ResourceManager("\u00a0.‥", typeof(ImageCache).Assembly);
			}
			return field_570;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo prop_607
	{
		get
		{
			return field_571;
		}
		set
		{
			field_571 = value;
		}
	}

	internal ImageCache()
	{
	}

	[SpecialName]
	internal static Bitmap method_575()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("address-book-24", field_571);
	}

	[SpecialName]
	internal static Bitmap method_576()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("AmaanWRT", field_571);
	}

	[SpecialName]
	internal static Bitmap method_577()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("arrow-96-24", field_571);
	}

	[SpecialName]
	internal static Bitmap method_578()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("backup", field_571);
	}

	[SpecialName]
	internal static Bitmap method_579()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("Backup_restore", field_571);
	}

	[SpecialName]
	internal static Bitmap method_580()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("Backup_restore2", field_571);
	}

	[SpecialName]
	internal static Bitmap method_581()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("Backup_save", field_571);
	}

	[SpecialName]
	internal static Bitmap method_582()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("Backup_save2", field_571);
	}

	[SpecialName]
	internal static Bitmap method_583()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("book", field_571);
	}

	[SpecialName]
	internal static Bitmap method_584()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("browser-24", field_571);
	}

	[SpecialName]
	internal static Bitmap method_585()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("config", field_571);
	}

	[SpecialName]
	internal static Bitmap method_586()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("export", field_571);
	}

	[SpecialName]
	internal static Bitmap method_587()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("flash", field_571);
	}

	[SpecialName]
	internal static Bitmap method_588()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("footer", field_571);
	}

	[SpecialName]
	internal static Bitmap method_589()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("hide_pass", field_571);
	}

	[SpecialName]
	internal static Bitmap method_590()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("import", field_571);
	}

	[SpecialName]
	internal static Bitmap method_591()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("key-24", field_571);
	}

	[SpecialName]
	internal static Bitmap method_592()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("link-32", field_571);
	}

	[SpecialName]
	internal static Bitmap method_593()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("menu", field_571);
	}

	[SpecialName]
	internal static Bitmap method_594()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("openBook", field_571);
	}

	[SpecialName]
	internal static Bitmap method_595()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("reset", field_571);
	}

	[SpecialName]
	internal static Bitmap method_596()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("save", field_571);
	}

	[SpecialName]
	internal static Bitmap method_597()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("services-24", field_571);
	}

	[SpecialName]
	internal static Bitmap method_598()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("show-pass", field_571);
	}

	[SpecialName]
	internal static Bitmap method_599()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("ShowContext", field_571);
	}

	[SpecialName]
	internal static Bitmap method_600()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("ShowContext1", field_571);
	}

	[SpecialName]
	internal static Bitmap method_601()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("ShowContext3", field_571);
	}

	[SpecialName]
	internal static Bitmap method_602()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("template", field_571);
	}

	[SpecialName]
	internal static Bitmap method_603()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("terminal", field_571);
	}

	[SpecialName]
	internal static Bitmap method_604()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("user-24", field_571);
	}

	[SpecialName]
	internal static Bitmap method_605()
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Expected Obj, but got Unknown
		return (Bitmap)prop_606.GetObject("wired-network-24", field_571);
	}
}
}
