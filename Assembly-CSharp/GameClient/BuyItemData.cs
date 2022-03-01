using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001448 RID: 5192
	internal struct BuyItemData
	{
		// Token: 0x0600C961 RID: 51553 RVA: 0x0030FAE8 File Offset: 0x0030DEE8
		public void SetItemDataByAuction(AuctionBaseInfo aucbaseinfo)
		{
			this.guid = aucbaseinfo.guid;
			this.ItemTypeID = (int)aucbaseinfo.itemTypeId;
			this.MoneyTypeID = DataManager<ItemDataManager>.GetInstance().GetMoneyTypeID(aucbaseinfo.pricetype);
			this.num = (int)aucbaseinfo.num;
			this.TotalPrice = (long)((ulong)aucbaseinfo.price);
			this.SinglePrice = ((this.num == 0) ? 1L : (this.TotalPrice / (long)this.num));
			this.StrengthLevel = (int)aucbaseinfo.strengthed;
			this.EquipType = aucbaseinfo.equipType;
			this.EnhanceType = aucbaseinfo.enhanceType;
			this.EnhanceNum = (int)aucbaseinfo.enhanceNum;
			this.buyplace = BuyPlace.Auction;
			this.PublicEndTime = aucbaseinfo.publicEndTime;
			this.IsTreasure = aucbaseinfo.isTreas;
			this.IsAgainOnSale = aucbaseinfo.isAgainOnsale;
		}

		// Token: 0x04007444 RID: 29764
		public ulong guid;

		// Token: 0x04007445 RID: 29765
		public int ItemTypeID;

		// Token: 0x04007446 RID: 29766
		public int MoneyTypeID;

		// Token: 0x04007447 RID: 29767
		public int num;

		// Token: 0x04007448 RID: 29768
		public long TotalPrice;

		// Token: 0x04007449 RID: 29769
		public long SinglePrice;

		// Token: 0x0400744A RID: 29770
		public int StrengthLevel;

		// Token: 0x0400744B RID: 29771
		public byte EquipType;

		// Token: 0x0400744C RID: 29772
		public byte EnhanceType;

		// Token: 0x0400744D RID: 29773
		public int EnhanceNum;

		// Token: 0x0400744E RID: 29774
		private BuyPlace buyplace;

		// Token: 0x0400744F RID: 29775
		public uint PublicEndTime;

		// Token: 0x04007450 RID: 29776
		public byte IsTreasure;

		// Token: 0x04007451 RID: 29777
		public byte IsAgainOnSale;
	}
}
