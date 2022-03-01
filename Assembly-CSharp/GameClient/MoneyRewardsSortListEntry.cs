using System;

namespace GameClient
{
	// Token: 0x0200065C RID: 1628
	public class MoneyRewardsSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055D5 RID: 21973 RVA: 0x00107074 File Offset: 0x00105474
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_int8(buffer, ref pos, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.maxScore);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.time);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.score);
			return true;
		}

		// Token: 0x040021E3 RID: 8675
		public byte occu;

		// Token: 0x040021E4 RID: 8676
		public ushort level;

		// Token: 0x040021E5 RID: 8677
		public uint maxScore;

		// Token: 0x040021E6 RID: 8678
		public uint time;

		// Token: 0x040021E7 RID: 8679
		public uint score;
	}
}
