using System;

namespace GameClient
{
	// Token: 0x02000656 RID: 1622
	public class SeasonSortListEntry : LevelSortListEntry
	{
		// Token: 0x060055C9 RID: 21961 RVA: 0x00106DEB File Offset: 0x001051EB
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_uint32(buffer, ref pos, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.seasonStar);
			return true;
		}

		// Token: 0x040021D2 RID: 8658
		public uint seasonLevel;

		// Token: 0x040021D3 RID: 8659
		public uint seasonStar;
	}
}
