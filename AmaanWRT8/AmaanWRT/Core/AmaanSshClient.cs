using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Renci.SshNet;

namespace AmaanWRT
{
public class AmaanSshClient : SshClient
{
	private readonly string field_43;

	private readonly string field_44;

	private readonly string field_45;

	public AmaanSshClient(string P_0, string P_1, string P_2)
		: base(P_0, P_1, P_2)
	{
		field_43 = P_0;
		field_44 = P_1;
		field_45 = P_2;
	}

	public string method_46(string P_0, string P_1, string P_2)
	{
		string text = ((SshClient)this).CreateCommand("uci get " + P_0 + "." + P_1 + "." + P_2).Execute();
		return method_65(text);
	}

	public string method_47(string P_0)
	{
		string text = ((SshClient)this).CreateCommand("uci get " + P_0).Execute();
		return method_65(text);
	}

	public string method_48(string P_0)
	{
		string text = ((SshClient)this).CreateCommand(P_0).Execute();
		return method_65(text);
	}

	public string method_49(string P_0, string P_1)
	{
		string text = ((SshClient)this).CreateCommand("cat " + P_1 + " | grep " + P_0).Execute();
		string text2 = method_65(text).Replace("'", "");
		int num = text2.IndexOf('=') + 1;
		if (num != -1 && num < text2.Length)
		{
			text2 = text2.Substring(num).Trim();
		}
		return text2;
	}

	public void method_50(string P_0, string P_1, string P_2, string P_3)
	{
		((SshClient)this).CreateCommand("uci set " + P_0 + "." + P_1 + "." + P_2 + "='" + P_3 + "'").Execute();
	}

	public void method_51(string P_0, string P_1)
	{
		((SshClient)this).CreateCommand("uci set " + P_0 + "='" + P_1 + "'").Execute();
	}

	public void method_52(string P_0)
	{
		((SshClient)this).CreateCommand(P_0).Execute();
	}

	public List<string> method_53()
	{
		string text = ((SshClient)this).CreateCommand("opkg list").Execute();
		return method_66(text);
	}

	public Dictionary<string, string> method_54(string P_0, string P_1)
	{
		string text = ((SshClient)this).CreateCommand("uci show " + P_0 + "." + P_1).Execute();
		return method_67(text);
	}

	public List<string> method_55(string P_0)
	{
		string text = ((SshClient)this).CreateCommand("uci show " + P_0).Execute();
		return method_68(text);
	}

	public void method_56(string P_0, string P_1)
	{
		((SshClient)this).CreateCommand("uci add " + P_0 + " " + P_1).Execute();
	}

	public void method_57(string P_0, string P_1)
	{
		((SshClient)this).CreateCommand("uci delete " + P_0 + "." + P_1).Execute();
	}

	public bool method_58(string P_0, string P_1)
	{
		SshCommand val = ((SshClient)this).CreateCommand("uci -q get " + P_0 + "." + P_1);
		val.Execute();
		return val.ExitStatus == 0;
	}

	public bool method_59(string P_0)
	{
		SshCommand val = ((SshClient)this).CreateCommand("uci -q get " + P_0);
		val.Execute();
		return val.ExitStatus == 0;
	}

	public void method_60(string P_0, string P_1, string P_2)
	{
		((SshClient)this).CreateCommand("uci rename " + P_0 + "." + P_1 + "=" + P_0 + "." + P_2).Execute();
	}

	public void method_61(string P_0, string P_1, string P_2)
	{
		((SshClient)this).CreateCommand("uci add " + P_0 + " " + P_1 + " " + P_2).Execute();
	}

	public void method_62(string P_0, string P_1, string P_2, string P_3)
	{
		((SshClient)this).CreateCommand("uci rename " + P_0 + "." + P_1 + "." + P_2 + "=" + P_0 + "." + P_1 + "." + P_3).Execute();
	}

	public void method_63(string P_0, string P_1, string P_2)
	{
		((SshClient)this).CreateCommand("uci delete " + P_0 + "." + P_1 + "." + P_2).Execute();
	}

	public void method_64(string P_0)
	{
		((SshClient)this).CreateCommand("uci delete " + P_0).Execute();
		((SshClient)this).CreateCommand("uci commit").Execute();
	}

	private string method_65(string P_0)
	{
		return P_0.Trim();
	}

	private List<string> method_66(string P_0)
	{
		List<string> list = new List<string>();
		string[] array = P_0.Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(new char[1] { '.' });
			if (array2.Length >= 2)
			{
				string item = array2[0];
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	private Dictionary<string, string> method_67(string P_0)
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		string[] array = P_0.Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(new char[1] { '=' }, 2);
			if (array2.Length == 2)
			{
				string key = array2[0].Trim();
				string value = array2[1].Trim();
				dictionary[key] = value;
			}
		}
		return dictionary;
	}

	private List<string> method_68(string P_0)
	{
		List<string> list = new List<string>();
		string[] array = P_0.Split(new char[2] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
		for (int i = 0; i < array.Length; i++)
		{
			string[] array2 = array[i].Split(new char[1] { '.' });
			if (array2.Length >= 2)
			{
				string item = array2[1];
				if (!list.Contains(item))
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	public AboutForm method_69<AboutForm>(string P_0)
	{
		return JsonConvert.DeserializeObject<AboutForm>(((SshClient)this).RunCommand("ubus " + P_0).Result);
	}

	internal string method_70(string P_0, string P_1)
	{
		string[] array = P_0.Split(new string[1] { "config wifi-iface" }, StringSplitOptions.RemoveEmptyEntries);
		foreach (string text in array)
		{
			if (!text.Contains("option mode 'mesh'") && text.Contains("option device '" + P_1 + "'") && text.Contains("option mode 'ap'"))
			{
				Match match = Regex.Match(text, "'([^']+)'");
				if (match.Success)
				{
					return match.Groups[1].Value;
				}
			}
		}
		return null;
	}

	private bool method_71(string P_0)
	{
		string pattern = "option\\s+mode\\s+'mesh'";
		return Regex.IsMatch(P_0, pattern);
	}
}
}
