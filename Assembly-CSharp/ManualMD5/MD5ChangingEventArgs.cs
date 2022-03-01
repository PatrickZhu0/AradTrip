using System;

namespace ManualMD5
{
	// Token: 0x02000153 RID: 339
	public class MD5ChangingEventArgs : EventArgs
	{
		// Token: 0x060009C7 RID: 2503 RVA: 0x00033554 File Offset: 0x00031954
		public MD5ChangingEventArgs(byte[] data)
		{
			byte[] array = new byte[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				array[i] = data[i];
			}
		}

		// Token: 0x060009C8 RID: 2504 RVA: 0x0003358C File Offset: 0x0003198C
		public MD5ChangingEventArgs(string data)
		{
			byte[] array = new byte[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				array[i] = (byte)data[i];
			}
		}

		// Token: 0x04000751 RID: 1873
		public readonly byte[] NewData;
	}
}
