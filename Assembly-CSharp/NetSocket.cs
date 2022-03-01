using System;

// Token: 0x020001B9 RID: 441
internal class NetSocket
{
	// Token: 0x06000E2B RID: 3627 RVA: 0x000491BF File Offset: 0x000475BF
	public bool Connect(string addr, int port, int MaxtimeOut, NetSocket.NetWorkStatusCallback cb = null)
	{
		return true;
	}

	// Token: 0x020001BA RID: 442
	// (Invoke) Token: 0x06000E2D RID: 3629
	public delegate void NetWorkStatusCallback(bool isDone, string errInfo);

	// Token: 0x020001BB RID: 443
	// (Invoke) Token: 0x06000E31 RID: 3633
	public delegate void NetWorkReceiveCallback(bool isDone, int bytesRead, string errInfo);
}
