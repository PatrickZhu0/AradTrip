using System;

// Token: 0x02000118 RID: 280
public class CompressHelper
{
	// Token: 0x0600062E RID: 1582 RVA: 0x000259B0 File Offset: 0x00023DB0
	public static byte[] Compress(byte[] data, int length)
	{
		long num = (long)CompressHelper.buffer.Length;
		Snappy.Compress(data, (long)length, CompressHelper.buffer, ref num);
		byte[] array = new byte[num];
		int num2 = 0;
		while ((long)num2 < num)
		{
			array[num2] = CompressHelper.buffer[num2];
			num2++;
		}
		return array;
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x000259FC File Offset: 0x00023DFC
	public static byte[] Uncompress(byte[] data, int length)
	{
		long num = (long)CompressHelper.buffer.Length;
		uint num2 = Snappy.Uncompress(data, (long)length, CompressHelper.buffer, ref num);
		if (num2 != 0U)
		{
			Logger.LogError("uncompress failed, reason:" + num2);
			return null;
		}
		byte[] array = new byte[num];
		int num3 = 0;
		while ((long)num3 < num)
		{
			array[num3] = CompressHelper.buffer[num3];
			num3++;
		}
		return array;
	}

	// Token: 0x04000513 RID: 1299
	private static byte[] buffer = new byte[1048576];
}
