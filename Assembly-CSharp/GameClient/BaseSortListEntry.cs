using System;

namespace GameClient
{
	// Token: 0x02000653 RID: 1619
	public class BaseSortListEntry
	{
		// Token: 0x060055C3 RID: 21955 RVA: 0x00106D00 File Offset: 0x00105100
		public virtual bool Decode(byte[] buffer, ref int pos)
		{
			BaseDLL.decode_uint16(buffer, ref pos, ref this.ranking);
			if (this.ranking == 0)
			{
				return false;
			}
			BaseDLL.decode_uint64(buffer, ref pos, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			return true;
		}

		// Token: 0x040021CB RID: 8651
		public ushort ranking;

		// Token: 0x040021CC RID: 8652
		public ulong id;

		// Token: 0x040021CD RID: 8653
		public string name;
	}
}
