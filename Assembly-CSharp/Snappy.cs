using System;
using System.Runtime.InteropServices;

// Token: 0x02000119 RID: 281
public class Snappy
{
	// Token: 0x06000632 RID: 1586
	[DllImport("snappy", CallingConvention = CallingConvention.Cdecl, EntryPoint = "snappy_compress")]
	public static extern uint Compress(byte[] input, long inputLength, byte[] compressed, ref long compressedLength);

	// Token: 0x06000633 RID: 1587
	[DllImport("snappy", CallingConvention = CallingConvention.Cdecl, EntryPoint = "snappy_uncompress")]
	public static extern uint Uncompress(byte[] compressed, long compressedLength, byte[] uncompressed, ref long uncompressedLength);

	// Token: 0x04000514 RID: 1300
	private const string dllName = "snappy";
}
