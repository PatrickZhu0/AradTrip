using System;

namespace GameClient
{
	// Token: 0x02000655 RID: 1621
	public class DeathTowerSortListEntry : LevelSortListEntry
	{
		// Token: 0x060055C7 RID: 21959 RVA: 0x00106DB5 File Offset: 0x001051B5
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_uint32(buffer, ref pos, ref this.layer);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.usedTime);
			return true;
		}

		// Token: 0x040021D0 RID: 8656
		public uint layer;

		// Token: 0x040021D1 RID: 8657
		public uint usedTime;
	}
}
