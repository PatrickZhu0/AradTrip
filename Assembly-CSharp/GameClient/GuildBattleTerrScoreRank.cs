using System;

namespace GameClient
{
	// Token: 0x0200065A RID: 1626
	public class GuildBattleTerrScoreRank : BaseSortListEntry
	{
		// Token: 0x060055D1 RID: 21969 RVA: 0x00106F81 File Offset: 0x00105381
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_uint32(buffer, ref pos, ref this.score);
			return true;
		}

		// Token: 0x040021DA RID: 8666
		public uint score;
	}
}
