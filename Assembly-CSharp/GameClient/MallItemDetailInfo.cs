using System;

namespace GameClient
{
	// Token: 0x02001798 RID: 6040
	public struct MallItemDetailInfo
	{
		// Token: 0x0600EE63 RID: 61027 RVA: 0x003FFE1C File Offset: 0x003FE21C
		public void Cleardata()
		{
			this.id = 0U;
			this.itemId = 0U;
			this.num = 0;
			this.price = 0U;
			this.discountPrice = 0U;
			this.moneytype = 0;
			this.WearSlot = EFashionWearSlotType.Invalid;
			this.BelongSuit = false;
			this.MallTableIndex = -1;
		}

		// Token: 0x040091BF RID: 37311
		public uint id;

		// Token: 0x040091C0 RID: 37312
		public uint itemId;

		// Token: 0x040091C1 RID: 37313
		public ushort num;

		// Token: 0x040091C2 RID: 37314
		public uint price;

		// Token: 0x040091C3 RID: 37315
		public uint discountPrice;

		// Token: 0x040091C4 RID: 37316
		public byte moneytype;

		// Token: 0x040091C5 RID: 37317
		public EFashionWearSlotType WearSlot;

		// Token: 0x040091C6 RID: 37318
		public bool BelongSuit;

		// Token: 0x040091C7 RID: 37319
		public bool isLimit;

		// Token: 0x040091C8 RID: 37320
		public int leftNum;

		// Token: 0x040091C9 RID: 37321
		public int MallTableIndex;
	}
}
