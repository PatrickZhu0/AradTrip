using System;

namespace GameClient
{
	// Token: 0x02000661 RID: 1633
	public class ChijiScoreSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055DE RID: 21982 RVA: 0x001071E3 File Offset: 0x001055E3
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_uint32(buffer, ref pos, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.score);
			return true;
		}

		// Token: 0x040021F0 RID: 8688
		public uint occu;

		// Token: 0x040021F1 RID: 8689
		public uint score;
	}
}
