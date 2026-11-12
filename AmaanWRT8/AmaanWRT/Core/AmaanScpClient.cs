using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Common;

namespace AmaanWRT
{
public class AmaanScpClient : ScpClient
{
	private readonly string field_38;

	private readonly string field_39;

	private readonly string field_40;

	public AmaanScpClient(ConnectionInfo P_0)
		: base(P_0)
	{
	}

	public AmaanScpClient(string P_0, string P_1, string P_2)
		: base(P_0, P_1, P_2)
	{
		field_38 = P_0;
		field_39 = P_1;
		field_40 = P_2;
	}

	internal void method_41(string P_0, string P_1)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Expected Obj, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Expected Obj, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected Obj, but got Unknown
		//IL_005f: Expected Obj, but got Unknown
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		PasswordAuthenticationMethod val = new PasswordAuthenticationMethod(field_39, field_40);
		KeyboardInteractiveAuthenticationMethod val2 = new KeyboardInteractiveAuthenticationMethod(field_39);
		AmaanScpClient class_1634 = new AmaanScpClient(new ConnectionInfo(field_38, field_39, new AuthenticationMethod[2]
		{
			(AuthenticationMethod)val,
			(AuthenticationMethod)val2
		}));
		try
		{
			try
			{
				((BaseClient)class_1634).Connect();
				FileInfo fileInfo = new FileInfo(P_0);
				((ScpClient)class_1634).Upload(fileInfo, P_1);
			}
			catch (SshOperationTimeoutException ex)
			{
				MessageBox.Show(((object)ex).ToString());
			}
			catch (SocketException ex2)
			{
				MessageBox.Show(ex2.ToString());
			}
			catch (Exception ex3)
			{
				MessageBox.Show(ex3.ToString());
			}
			finally
			{
				((BaseClient)class_1634).Disconnect();
			}
		}
		finally
		{
			((IDisposable)class_1634)?.Dispose();
		}
	}
}
}
