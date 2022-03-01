using System;

namespace GameClient
{
	// Token: 0x02000658 RID: 1624
	public class GuildLevelSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055CD RID: 21965 RVA: 0x00106E98 File Offset: 0x00105298
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos, ref array[i]);
			}
			this.leader = StringHelper.BytesToString(array);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.memberCount);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.level);
			return true;
		}

		// Token: 0x040021D6 RID: 8662
		public string leader;

		// Token: 0x040021D7 RID: 8663
		public uint memberCount;

		// Token: 0x040021D8 RID: 8664
		public uint level;
	}
}
