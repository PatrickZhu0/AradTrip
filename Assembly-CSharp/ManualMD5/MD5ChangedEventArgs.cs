using System;

namespace ManualMD5
{
	// Token: 0x02000154 RID: 340
	public class MD5ChangedEventArgs : EventArgs
	{
		// Token: 0x060009C9 RID: 2505 RVA: 0x000335D0 File Offset: 0x000319D0
		public MD5ChangedEventArgs(byte[] data, string HashedValue)
		{
			byte[] array = new byte[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				array[i] = data[i];
			}
			this.FingerPrint = HashedValue;
		}

		// Token: 0x060009CA RID: 2506 RVA: 0x00033610 File Offset: 0x00031A10
		public MD5ChangedEventArgs(string data, string HashedValue)
		{
			byte[] array = new byte[data.Length];
			for (int i = 0; i < data.Length; i++)
			{
				array[i] = (byte)data[i];
			}
			this.FingerPrint = HashedValue;
		}

		// Token: 0x04000752 RID: 1874
		public readonly byte[] NewData;

		// Token: 0x04000753 RID: 1875
		public readonly string FingerPrint;
	}
}
