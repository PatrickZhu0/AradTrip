using System;

namespace GameClient
{
	// Token: 0x0200065E RID: 1630
	public class AchievementScoreSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055D9 RID: 21977 RVA: 0x00107115 File Offset: 0x00105515
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_int8(buffer, ref pos, ref this.occu);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.score);
			return true;
		}

		// Token: 0x040021EA RID: 8682
		public byte occu;

		// Token: 0x040021EB RID: 8683
		public uint score;
	}
}
