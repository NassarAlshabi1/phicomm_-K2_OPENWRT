using System;
using System.Management;
using Microsoft.Win32;

namespace AmaanWRT
{
public class MachineRegistryStore
{
	private readonly string field_468 = "SOFTWARE\\" + method_476();

	private readonly string field_469;

	public MachineRegistryStore(string P_0)
	{
		field_469 = P_0;
	}

	public MachineRegistryStore()
	{
		field_469 = "MyValue";
	}

	public static void method_470()
	{
	}

	public void method_471(string P_0)
	{
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(field_468);
			registryKey.SetValue(field_469, P_0);
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error setting registry value: " + ex.Message);
		}
	}

	public string method_472()
	{
		string result = string.Empty;
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(field_468);
			if (registryKey != null)
			{
				result = registryKey.GetValue(field_469)?.ToString();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error getting registry value: " + ex.Message);
		}
		return result;
	}

	public DateTime method_473()
	{
		return DateTime.Today;
	}

	public string method_474()
	{
		string result = string.Empty;
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(field_468);
			if (registryKey != null)
			{
				result = registryKey.GetValue(field_469)?.ToString();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error getting registry value: " + ex.Message);
		}
		return result;
	}

	public DateTime method_475()
	{
		DateTime result = DateTime.Today;
		try
		{
			using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(field_468);
			if (registryKey != null && DateTime.TryParse(registryKey.GetValue(field_469)?.ToString(), out result))
			{
				return result;
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error getting registry value: " + ex.Message);
		}
		return result;
	}

	private static string method_476()
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		string result = string.Empty;
		try
		{
			var enumerator = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard").Get().GetEnumerator();
			try
			{
				if (enumerator.MoveNext())
				{
					result = ((ManagementBaseObject)(ManagementObject)enumerator.Current)["SerialNumber"].ToString();
				}
			}
			finally
			{
				((IDisposable)enumerator)?.Dispose();
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Error: " + ex.Message);
		}
		return result;
	}
}
}
