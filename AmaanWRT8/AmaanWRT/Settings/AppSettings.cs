using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace AmaanWRT
{
[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.4.0.0")]
internal sealed class AppSettings : ApplicationSettingsBase
{
	private static AppSettings field_609 = (AppSettings)(object)SettingsBase.Synchronized((SettingsBase)(object)new AppSettings());

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_633
	{
		get
		{
			return (string)((SettingsBase)this)["ssid_2g"];
		}
		set
		{
			((SettingsBase)this)["ssid_2g"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_634
	{
		get
		{
			return (string)((SettingsBase)this)["ssid_5g"];
		}
		set
		{
			((SettingsBase)this)["ssid_5g"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_635
	{
		get
		{
			return (string)((SettingsBase)this)["meshID"];
		}
		set
		{
			((SettingsBase)this)["meshID"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_636
	{
		get
		{
			return (string)((SettingsBase)this)["meshKey"];
		}
		set
		{
			((SettingsBase)this)["meshKey"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_637
	{
		get
		{
			return (string)((SettingsBase)this)["ip"];
		}
		set
		{
			((SettingsBase)this)["ip"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_638
	{
		get
		{
			return (string)((SettingsBase)this)["vlan"];
		}
		set
		{
			((SettingsBase)this)["vlan"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_639
	{
		get
		{
			return (string)((SettingsBase)this)["passwrd"];
		}
		set
		{
			((SettingsBase)this)["passwrd"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool prop_640
	{
		get
		{
			return (bool)((SettingsBase)this)["enable_mesh"];
		}
		set
		{
			((SettingsBase)this)["enable_mesh"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("False")]
	public bool prop_641
	{
		get
		{
			return (bool)((SettingsBase)this)["enable_5g"];
		}
		set
		{
			((SettingsBase)this)["enable_5g"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_642
	{
		get
		{
			return (string)((SettingsBase)this)["meshChannel"];
		}
		set
		{
			((SettingsBase)this)["meshChannel"] = value;
		}
	}

	[UserScopedSetting]
	[DebuggerNonUserCode]
	[DefaultSettingValue("")]
	public string prop_643
	{
		get
		{
			return (string)((SettingsBase)this)["FolderLocation"];
		}
		set
		{
			((SettingsBase)this)["FolderLocation"] = value;
		}
	}

	[SpecialName]
	public static AppSettings method_610()
	{
		return field_609;
	}
}
}
