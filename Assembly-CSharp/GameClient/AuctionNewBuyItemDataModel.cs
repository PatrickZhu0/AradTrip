using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020011EF RID: 4591
	public class AuctionNewBuyItemDataModel
	{
		// Token: 0x0600B0D6 RID: 45270 RVA: 0x0026FE08 File Offset: 0x0026E208
		public void SetBuyItemDataModel(AuctionBaseInfo auctionBaseInfo)
		{
			this.Guid = auctionBaseInfo.guid;
			this.ItemTypeId = (int)auctionBaseInfo.itemTypeId;
			this.MoneyTypeId = DataManager<ItemDataManager>.GetInstance().GetMoneyTypeID(auctionBaseInfo.pricetype);
			this.Number = (int)auctionBaseInfo.num;
			this.TotalPrice = (long)((ulong)auctionBaseInfo.price);
			this.SinglePrice = ((this.Number <= 0) ? this.TotalPrice : (this.TotalPrice / (long)this.Number));
			this.StrengthLevel = (int)auctionBaseInfo.strengthed;
			this.EquipType = auctionBaseInfo.equipType;
			this.EnhanceType = auctionBaseInfo.enhanceType;
			this.EnhanceNum = (int)auctionBaseInfo.enhanceNum;
			this.PublicEndTime = auctionBaseInfo.publicEndTime;
			this.IsTreasure = auctionBaseInfo.isTreas;
			this.IsAgainOnSale = auctionBaseInfo.isAgainOnsale;
			this.ItemTradeNumber = auctionBaseInfo.itemTransNum;
		}

		// Token: 0x040062DA RID: 25306
		public ulong Guid;

		// Token: 0x040062DB RID: 25307
		public int ItemTypeId;

		// Token: 0x040062DC RID: 25308
		public int MoneyTypeId;

		// Token: 0x040062DD RID: 25309
		public int Number;

		// Token: 0x040062DE RID: 25310
		public long TotalPrice;

		// Token: 0x040062DF RID: 25311
		public long SinglePrice;

		// Token: 0x040062E0 RID: 25312
		public int StrengthLevel;

		// Token: 0x040062E1 RID: 25313
		public byte EquipType;

		// Token: 0x040062E2 RID: 25314
		public byte EnhanceType;

		// Token: 0x040062E3 RID: 25315
		public int EnhanceNum;

		// Token: 0x040062E4 RID: 25316
		public uint PublicEndTime;

		// Token: 0x040062E5 RID: 25317
		public byte IsTreasure;

		// Token: 0x040062E6 RID: 25318
		public byte IsAgainOnSale;

		// Token: 0x040062E7 RID: 25319
		public uint ItemTradeNumber;
	}
}
