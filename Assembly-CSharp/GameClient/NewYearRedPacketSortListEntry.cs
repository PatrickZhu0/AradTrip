using System;

namespace GameClient
{
	// Token: 0x0200065D RID: 1629
	public class NewYearRedPacketSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055D7 RID: 21975 RVA: 0x001070DF File Offset: 0x001054DF
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_int8(buffer, ref pos, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.redPacketNum);
			return true;
		}

		// Token: 0x040021E8 RID: 8680
		public byte occu;

		// Token: 0x040021E9 RID: 8681
		public uint redPacketNum;
	}
}
