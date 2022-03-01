using System;
using System.Runtime.InteropServices;

// Token: 0x020001D7 RID: 471
public class UdpDLL
{
	// Token: 0x06000F0A RID: 3850
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern IntPtr avalon_udpconnector_initialize(byte[] logFileName);

	// Token: 0x06000F0B RID: 3851
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern int avalon_udpconnector_connect(IntPtr network, byte[] ip, ushort port, uint uid, uint timeout);

	// Token: 0x06000F0C RID: 3852
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern int avalon_udpconnector_senddata(IntPtr network, byte[] buff, uint buffSize, byte reliable);

	// Token: 0x06000F0D RID: 3853
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern int avalon_udpconnector_checkdata(IntPtr network, byte[] data, ref uint dataLength);

	// Token: 0x06000F0E RID: 3854
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern int avalon_udpconnector_disconnect(IntPtr network, uint uid);

	// Token: 0x06000F0F RID: 3855
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern int avalon_udpconnector_deinitialize(IntPtr network);

	// Token: 0x06000F10 RID: 3856
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern int avalon_udpconnector_ping(IntPtr network);

	// Token: 0x06000F11 RID: 3857
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern void avalon_udpconnector_save_log(byte[] logFileName);

	// Token: 0x06000F12 RID: 3858
	[DllImport("enet", CallingConvention = CallingConvention.Cdecl)]
	public static extern void avalon_udpconnector_open_log(byte[] logFileName);

	// Token: 0x04000A59 RID: 2649
	private const string udpDLL = "enet";
}
