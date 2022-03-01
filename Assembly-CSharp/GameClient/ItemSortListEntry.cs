using System;

namespace GameClient
{
	// Token: 0x0200065B RID: 1627
	public class ItemSortListEntry : BaseSortListEntry
	{
		// Token: 0x060055D3 RID: 21971 RVA: 0x00106FAC File Offset: 0x001053AC
		public override bool Decode(byte[] buffer, ref int pos)
		{
			if (!base.Decode(buffer, ref pos))
			{
				return false;
			}
			ushort num = 0;
			BaseDLL.decode_uint64(buffer, ref pos, ref this.ownerId);
			BaseDLL.decode_uint16(buffer, ref pos, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos, ref array[i]);
			}
			this.ownerName = StringHelper.BytesToString(array);
			BaseDLL.decode_uint16(buffer, ref pos, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.strengthen);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos, ref this.itemId);
			BaseDLL.decode_int8(buffer, ref pos, ref this.equipType);
			BaseDLL.decode_int8(buffer, ref pos, ref this.growthAttr);
			return true;
		}

		// Token: 0x040021DB RID: 8667
		public ulong ownerId;

		// Token: 0x040021DC RID: 8668
		public string ownerName;

		// Token: 0x040021DD RID: 8669
		public ushort level;

		// Token: 0x040021DE RID: 8670
		public uint strengthen;

		// Token: 0x040021DF RID: 8671
		public uint score;

		// Token: 0x040021E0 RID: 8672
		public uint itemId;

		// Token: 0x040021E1 RID: 8673
		public byte equipType;

		// Token: 0x040021E2 RID: 8674
		public byte growthAttr;
	}
}
