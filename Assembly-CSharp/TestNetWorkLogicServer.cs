using System;
using System.IO;
using Network;
using UnityEngine;

// Token: 0x020001D3 RID: 467
public class TestNetWorkLogicServer
{
	// Token: 0x06000EF2 RID: 3826 RVA: 0x0004C8FC File Offset: 0x0004ACFC
	private void Start(string ip, ushort port, uint timeout)
	{
		Console.SetOut(new StreamWriter(Console.OpenStandardOutput())
		{
			AutoFlush = true
		});
		Console.Write("Start ip123123 =" + ip + "\n");
		NetworkSocket networkSocket = new NetworkSocket(ServerType.ADMIN_SERVER);
		networkSocket.ConnectToServer(ip, (int)port, (int)timeout);
	}

	// Token: 0x06000EF3 RID: 3827 RVA: 0x0004C948 File Offset: 0x0004AD48
	private void TestMath()
	{
		Vector3 normalized;
		normalized..ctor(1f, 1f, 1f);
		normalized = normalized.normalized;
		float num = Mathf.Cos(1f);
	}

	// Token: 0x06000EF4 RID: 3828 RVA: 0x0004C97E File Offset: 0x0004AD7E
	private void SetBuffer(IntPtr ptr, int len)
	{
	}
}
