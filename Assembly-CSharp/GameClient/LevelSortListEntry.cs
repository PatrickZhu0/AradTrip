using System;

namespace GameClient
{
	// Token: 0x02000654 RID: 1620
	public class LevelSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055C5 RID: 21957 RVA: 0x00106D7F File Offset: 0x0010517F
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			BaseDLL.decode_int8(buffer, ref pos, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos, ref this.level);
			return true;
		}

		// Token: 0x040021CE RID: 8654
		public byte occu;

		// Token: 0x040021CF RID: 8655
		public ushort level;
	}
}
