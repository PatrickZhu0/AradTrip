using System;

namespace GameClient
{
	// Token: 0x02001455 RID: 5205
	public class AuctionOnSaleItemDate : IComparable<AuctionOnSaleItemDate>
	{
		// Token: 0x0600C9FF RID: 51711 RVA: 0x003163F4 File Offset: 0x003147F4
		public AuctionOnSaleItemDate(ulong guid, uint price, byte pricetype, uint itemScore, uint dueTime, uint num, uint itemTypeId, uint strengthed, bool isTreasure)
		{
			this.guid = guid;
			this.price = price;
			this.pricetype = pricetype;
			this.itemScore = itemScore;
			this.dueTime = dueTime;
			this.num = num;
			this.itemTypeId = itemTypeId;
			this.strengthed = strengthed;
			this.isTreasure = isTreasure;
		}

		// Token: 0x0600CA00 RID: 51712 RVA: 0x0031644C File Offset: 0x0031484C
		public int CompareTo(AuctionOnSaleItemDate other)
		{
			return (int)(this.price - other.price);
		}

		// Token: 0x04007509 RID: 29961
		public ulong guid;

		// Token: 0x0400750A RID: 29962
		public uint price;

		// Token: 0x0400750B RID: 29963
		public byte pricetype;

		// Token: 0x0400750C RID: 29964
		public uint itemScore;

		// Token: 0x0400750D RID: 29965
		public uint dueTime;

		// Token: 0x0400750E RID: 29966
		public uint num;

		// Token: 0x0400750F RID: 29967
		public uint itemTypeId;

		// Token: 0x04007510 RID: 29968
		public uint strengthed;

		// Token: 0x04007511 RID: 29969
		public bool isTreasure;
	}
}
