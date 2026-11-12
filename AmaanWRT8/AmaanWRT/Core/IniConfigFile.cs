using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace AmaanWRT
{
internal class IniConfigFile
{
	private string field_133;

	[DllImport("kernel32", EntryPoint = "WritePrivateProfileString")]
	private static extern long method_134(string P_0, string P_1, string P_2, string P_3);

	[DllImport("kernel32", EntryPoint = "GetPrivateProfileString")]
	private static extern int method_135(string P_0, string P_1, string P_2, StringBuilder P_3, int P_4, string P_5);

	public IniConfigFile(string P_0)
	{
		field_133 = P_0;
	}

	public IniConfigFile()
	{
		string text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "AmaanWRT", "config.ini");
		field_133 = text;
	}

	public void method_136(string P_0, string P_1, string P_2)
	{
		string directoryName = Path.GetDirectoryName(field_133);
		if (!Directory.Exists(directoryName))
		{
			Directory.CreateDirectory(directoryName);
		}
		method_134(P_0, P_1, P_2, field_133);
	}

	public string method_137(string P_0, string P_1)
	{
		try
		{
			string directoryName = Path.GetDirectoryName(field_133);
			if (!Directory.Exists(directoryName))
			{
				string text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");
				Directory.CreateDirectory(directoryName);
				if (File.Exists(text))
				{
					File.Copy(text, field_133, overwrite: true);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(255);
			method_135(P_0, P_1, "", stringBuilder, 255, field_133);
			return stringBuilder.ToString();
		}
		catch
		{
			return "0";
		}
	}

	[SpecialName]
	public string method_138()
	{
		return field_133;
	}

	[SpecialName]
	public void method_139(string P_0)
	{
		field_133 = P_0;
	}

	[DllImport("kernel32", EntryPoint = "GetPrivateProfileSectionNames")]
	private static extern uint method_140(IntPtr P_0, uint P_1, string P_2);

	public string[] method_141()
	{
		uint num = 32767u;
		IntPtr intPtr = Marshal.AllocCoTaskMem((int)num);
		uint num2 = method_140(intPtr, num, field_133);
		if (num2 == 0)
		{
			return null;
		}
		string text = Marshal.PtrToStringAnsi(intPtr, (int)num2).ToString();
		Marshal.FreeCoTaskMem(intPtr);
		return text.Substring(0, text.Length - 1).Split(new char[1]);
	}
}
}
