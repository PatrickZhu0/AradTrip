using System;
using System.Runtime.InteropServices;
using LimitTimeGift;
using Protocol;

namespace GameClient
{
	// Token: 0x02001CF1 RID: 7409
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct LimitTimeGiftPackDetailModel
	{
		// Token: 0x0601232B RID: 74539 RVA: 0x0054DE84 File Offset: 0x0054C284
		public LimitTimeGiftPackDetailModel(MallItemInfo msgData)
		{
			this = default(LimitTimeGiftPackDetailModel);
			this.Id = msgData.id;
			this.Name = msgData.giftName;
			this.ItemId = (int)msgData.itemid;
			this.ItemNum = (int)msgData.itemnum;
			this.mRewards = msgData.giftItems;
			this.GiftType = (MallGoodsType)msgData.gift;
			this.GiftPrice = Utility.GetMallRealPrice(msgData);
			this.PriceType = (LimitTimeGiftPriceType)msgData.moneytype;
			this.LimitTotalNum = (int)msgData.limittotalnum;
			this.RemainingTimeSec = msgData.endtime - DataManager<TimeManager>.GetInstance().GetServerTime();
			if (msgData.gift == 1 || msgData.gift == 7)
			{
				this.LimitPurchaseNum = (int)msgData.limitnum;
			}
			else
			{
				this.LimitPurchaseNum = (int)msgData.limittotalnum;
			}
			this.LimitType = (ELimitiTimeGiftDataLimitType)msgData.limit;
			this.GiftEndTime = msgData.endtime;
			this.GiftStartTime = msgData.starttime;
			this.LimitNum = (uint)msgData.limitnum;
			this.buyGotInfos = msgData.buyGotInfos;
			this.Limit = msgData.limit;
			this.DiscountCouponId = msgData.discountCouponId;
			this.AccountLimitBuyNum = msgData.accountLimitBuyNum;
			this.AccountRestBuyNum = msgData.accountRestBuyNum;
			this.AccountRefreshType = (uint)msgData.accountRefreshType;
		}

		// Token: 0x17001EC5 RID: 7877
		// (get) Token: 0x0601232C RID: 74540 RVA: 0x0054DFC8 File Offset: 0x0054C3C8
		// (set) Token: 0x0601232D RID: 74541 RVA: 0x0054DFD0 File Offset: 0x0054C3D0
		public uint Id { get; private set; }

		// Token: 0x17001EC6 RID: 7878
		// (get) Token: 0x0601232E RID: 74542 RVA: 0x0054DFD9 File Offset: 0x0054C3D9
		// (set) Token: 0x0601232F RID: 74543 RVA: 0x0054DFE1 File Offset: 0x0054C3E1
		public int ItemId { get; private set; }

		// Token: 0x17001EC7 RID: 7879
		// (get) Token: 0x06012330 RID: 74544 RVA: 0x0054DFEA File Offset: 0x0054C3EA
		// (set) Token: 0x06012331 RID: 74545 RVA: 0x0054DFF2 File Offset: 0x0054C3F2
		public int ItemNum { get; private set; }

		// Token: 0x17001EC8 RID: 7880
		// (get) Token: 0x06012332 RID: 74546 RVA: 0x0054DFFB File Offset: 0x0054C3FB
		// (set) Token: 0x06012333 RID: 74547 RVA: 0x0054E003 File Offset: 0x0054C403
		public string Name { get; private set; }

		// Token: 0x17001EC9 RID: 7881
		// (get) Token: 0x06012334 RID: 74548 RVA: 0x0054E00C File Offset: 0x0054C40C
		// (set) Token: 0x06012335 RID: 74549 RVA: 0x0054E014 File Offset: 0x0054C414
		public ItemReward[] mRewards { get; private set; }

		// Token: 0x17001ECA RID: 7882
		// (get) Token: 0x06012336 RID: 74550 RVA: 0x0054E01D File Offset: 0x0054C41D
		// (set) Token: 0x06012337 RID: 74551 RVA: 0x0054E025 File Offset: 0x0054C425
		public MallGoodsType GiftType { get; private set; }

		// Token: 0x17001ECB RID: 7883
		// (get) Token: 0x06012338 RID: 74552 RVA: 0x0054E02E File Offset: 0x0054C42E
		// (set) Token: 0x06012339 RID: 74553 RVA: 0x0054E036 File Offset: 0x0054C436
		public int GiftPrice { get; private set; }

		// Token: 0x17001ECC RID: 7884
		// (get) Token: 0x0601233A RID: 74554 RVA: 0x0054E03F File Offset: 0x0054C43F
		// (set) Token: 0x0601233B RID: 74555 RVA: 0x0054E047 File Offset: 0x0054C447
		public LimitTimeGiftPriceType PriceType { get; private set; }

		// Token: 0x17001ECD RID: 7885
		// (get) Token: 0x0601233C RID: 74556 RVA: 0x0054E050 File Offset: 0x0054C450
		// (set) Token: 0x0601233D RID: 74557 RVA: 0x0054E058 File Offset: 0x0054C458
		public int LimitTotalNum { get; private set; }

		// Token: 0x17001ECE RID: 7886
		// (get) Token: 0x0601233E RID: 74558 RVA: 0x0054E061 File Offset: 0x0054C461
		public bool NeedTimeCountDown
		{
			get
			{
				return this.GiftIntraDay == LimitTimeGiftIntraDay.IntraDay;
			}
		}

		// Token: 0x17001ECF RID: 7887
		// (get) Token: 0x0601233F RID: 74559 RVA: 0x0054E076 File Offset: 0x0054C476
		// (set) Token: 0x06012340 RID: 74560 RVA: 0x0054E07E File Offset: 0x0054C47E
		public MallBuyGotInfo[] buyGotInfos { get; private set; }

		// Token: 0x17001ED0 RID: 7888
		// (get) Token: 0x06012341 RID: 74561 RVA: 0x0054E087 File Offset: 0x0054C487
		public LimitTimeGiftIntraDay GiftIntraDay
		{
			get
			{
				if (this.GiftState == LimitTimeGiftState.SoldOut)
				{
					return LimitTimeGiftIntraDay.None;
				}
				return (this.RemainingTimeSec <= 86400U) ? LimitTimeGiftIntraDay.IntraDay : LimitTimeGiftIntraDay.MoreThanOneDay;
			}
		}

		// Token: 0x17001ED1 RID: 7889
		// (get) Token: 0x06012342 RID: 74562 RVA: 0x0054E0AE File Offset: 0x0054C4AE
		public LimitTimeGiftState GiftState
		{
			get
			{
				return (this.LimitPurchaseNum <= 0 && this.LimitType != ELimitiTimeGiftDataLimitType.None) ? LimitTimeGiftState.SoldOut : LimitTimeGiftState.OnSale;
			}
		}

		// Token: 0x17001ED2 RID: 7890
		// (get) Token: 0x06012343 RID: 74563 RVA: 0x0054E0CE File Offset: 0x0054C4CE
		// (set) Token: 0x06012344 RID: 74564 RVA: 0x0054E0D6 File Offset: 0x0054C4D6
		public uint RemainingTimeSec { get; private set; }

		// Token: 0x17001ED3 RID: 7891
		// (get) Token: 0x06012345 RID: 74565 RVA: 0x0054E0DF File Offset: 0x0054C4DF
		// (set) Token: 0x06012346 RID: 74566 RVA: 0x0054E0E7 File Offset: 0x0054C4E7
		public int LimitPurchaseNum { get; private set; }

		// Token: 0x17001ED4 RID: 7892
		// (get) Token: 0x06012347 RID: 74567 RVA: 0x0054E0F0 File Offset: 0x0054C4F0
		// (set) Token: 0x06012348 RID: 74568 RVA: 0x0054E0F8 File Offset: 0x0054C4F8
		public ELimitiTimeGiftDataLimitType LimitType { get; private set; }

		// Token: 0x17001ED5 RID: 7893
		// (get) Token: 0x06012349 RID: 74569 RVA: 0x0054E101 File Offset: 0x0054C501
		// (set) Token: 0x0601234A RID: 74570 RVA: 0x0054E109 File Offset: 0x0054C509
		public uint GiftEndTime { get; private set; }

		// Token: 0x17001ED6 RID: 7894
		// (get) Token: 0x0601234B RID: 74571 RVA: 0x0054E112 File Offset: 0x0054C512
		// (set) Token: 0x0601234C RID: 74572 RVA: 0x0054E11A File Offset: 0x0054C51A
		public uint GiftStartTime { get; private set; }

		// Token: 0x17001ED7 RID: 7895
		// (get) Token: 0x0601234D RID: 74573 RVA: 0x0054E123 File Offset: 0x0054C523
		// (set) Token: 0x0601234E RID: 74574 RVA: 0x0054E12B File Offset: 0x0054C52B
		public uint LimitNum { get; private set; }

		// Token: 0x17001ED8 RID: 7896
		// (get) Token: 0x0601234F RID: 74575 RVA: 0x0054E134 File Offset: 0x0054C534
		// (set) Token: 0x06012350 RID: 74576 RVA: 0x0054E13C File Offset: 0x0054C53C
		public byte Limit { get; private set; }

		// Token: 0x17001ED9 RID: 7897
		// (get) Token: 0x06012351 RID: 74577 RVA: 0x0054E145 File Offset: 0x0054C545
		// (set) Token: 0x06012352 RID: 74578 RVA: 0x0054E14D File Offset: 0x0054C54D
		public uint DiscountCouponId { get; private set; }

		// Token: 0x17001EDA RID: 7898
		// (get) Token: 0x06012353 RID: 74579 RVA: 0x0054E156 File Offset: 0x0054C556
		// (set) Token: 0x06012354 RID: 74580 RVA: 0x0054E15E File Offset: 0x0054C55E
		public uint AccountLimitBuyNum { get; private set; }

		// Token: 0x17001EDB RID: 7899
		// (get) Token: 0x06012355 RID: 74581 RVA: 0x0054E167 File Offset: 0x0054C567
		// (set) Token: 0x06012356 RID: 74582 RVA: 0x0054E16F File Offset: 0x0054C56F
		public uint AccountRestBuyNum { get; private set; }

		// Token: 0x17001EDC RID: 7900
		// (get) Token: 0x06012357 RID: 74583 RVA: 0x0054E178 File Offset: 0x0054C578
		// (set) Token: 0x06012358 RID: 74584 RVA: 0x0054E180 File Offset: 0x0054C580
		public uint AccountRefreshType { get; private set; }
	}
}
