using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace LimitTimeGift
{
	// Token: 0x02001731 RID: 5937
	public class LimitTimeGiftData : IComparable<LimitTimeGiftData>
	{
		// Token: 0x0600E958 RID: 59736 RVA: 0x003DCABC File Offset: 0x003DAEBC
		public LimitTimeGiftData()
		{
			this.Reset();
		}

		// Token: 0x17001CC7 RID: 7367
		// (get) Token: 0x0600E959 RID: 59737 RVA: 0x003DCACA File Offset: 0x003DAECA
		// (set) Token: 0x0600E95A RID: 59738 RVA: 0x003DCAD2 File Offset: 0x003DAED2
		public uint GiftId
		{
			get
			{
				return this.giftId;
			}
			set
			{
				this.giftId = value;
			}
		}

		// Token: 0x17001CC8 RID: 7368
		// (get) Token: 0x0600E95B RID: 59739 RVA: 0x003DCADB File Offset: 0x003DAEDB
		// (set) Token: 0x0600E95C RID: 59740 RVA: 0x003DCAE3 File Offset: 0x003DAEE3
		public string GiftName
		{
			get
			{
				return this.giftName;
			}
			set
			{
				this.giftName = value;
			}
		}

		// Token: 0x17001CC9 RID: 7369
		// (get) Token: 0x0600E95D RID: 59741 RVA: 0x003DCAEC File Offset: 0x003DAEEC
		// (set) Token: 0x0600E95E RID: 59742 RVA: 0x003DCAF4 File Offset: 0x003DAEF4
		public int LimitPurchaseNum
		{
			get
			{
				return this.limitPurchaseNum;
			}
			set
			{
				this.limitPurchaseNum = value;
			}
		}

		// Token: 0x17001CCA RID: 7370
		// (get) Token: 0x0600E95F RID: 59743 RVA: 0x003DCAFD File Offset: 0x003DAEFD
		// (set) Token: 0x0600E960 RID: 59744 RVA: 0x003DCB05 File Offset: 0x003DAF05
		public int LimitNum
		{
			get
			{
				return this.limitNum;
			}
			set
			{
				this.limitNum = value;
			}
		}

		// Token: 0x17001CCB RID: 7371
		// (get) Token: 0x0600E961 RID: 59745 RVA: 0x003DCB0E File Offset: 0x003DAF0E
		// (set) Token: 0x0600E962 RID: 59746 RVA: 0x003DCB16 File Offset: 0x003DAF16
		public int LimitTotalNum
		{
			get
			{
				return this.limitTotalNum;
			}
			set
			{
				this.limitTotalNum = value;
			}
		}

		// Token: 0x17001CCC RID: 7372
		// (get) Token: 0x0600E963 RID: 59747 RVA: 0x003DCB1F File Offset: 0x003DAF1F
		// (set) Token: 0x0600E964 RID: 59748 RVA: 0x003DCB27 File Offset: 0x003DAF27
		public int LimitLastNum
		{
			get
			{
				return this.limitLastNum;
			}
			set
			{
				this.limitLastNum = value;
			}
		}

		// Token: 0x17001CCD RID: 7373
		// (get) Token: 0x0600E965 RID: 59749 RVA: 0x003DCB30 File Offset: 0x003DAF30
		// (set) Token: 0x0600E966 RID: 59750 RVA: 0x003DCB38 File Offset: 0x003DAF38
		public List<LimitTimeGiftAwardData> GiftAwards
		{
			get
			{
				return this.giftAwards;
			}
			set
			{
				this.giftAwards = value;
			}
		}

		// Token: 0x17001CCE RID: 7374
		// (get) Token: 0x0600E967 RID: 59751 RVA: 0x003DCB41 File Offset: 0x003DAF41
		// (set) Token: 0x0600E968 RID: 59752 RVA: 0x003DCB49 File Offset: 0x003DAF49
		public uint RemainingTimeSec
		{
			get
			{
				return this.remainingTimeSec;
			}
			set
			{
				this.remainingTimeSec = value;
			}
		}

		// Token: 0x17001CCF RID: 7375
		// (get) Token: 0x0600E969 RID: 59753 RVA: 0x003DCB52 File Offset: 0x003DAF52
		// (set) Token: 0x0600E96A RID: 59754 RVA: 0x003DCB5A File Offset: 0x003DAF5A
		public int GiftPrice
		{
			get
			{
				return this.giftPrice;
			}
			set
			{
				this.giftPrice = value;
			}
		}

		// Token: 0x17001CD0 RID: 7376
		// (get) Token: 0x0600E96B RID: 59755 RVA: 0x003DCB63 File Offset: 0x003DAF63
		// (set) Token: 0x0600E96C RID: 59756 RVA: 0x003DCB6B File Offset: 0x003DAF6B
		public ELimitiTimeGiftDataLimitType LimitType
		{
			get
			{
				return this.limitType;
			}
			set
			{
				this.limitType = value;
			}
		}

		// Token: 0x17001CD1 RID: 7377
		// (get) Token: 0x0600E96D RID: 59757 RVA: 0x003DCB74 File Offset: 0x003DAF74
		// (set) Token: 0x0600E96E RID: 59758 RVA: 0x003DCB7C File Offset: 0x003DAF7C
		public MallGoodsType GiftType
		{
			get
			{
				return this.giftType;
			}
			set
			{
				this.giftType = value;
			}
		}

		// Token: 0x17001CD2 RID: 7378
		// (get) Token: 0x0600E96F RID: 59759 RVA: 0x003DCB85 File Offset: 0x003DAF85
		// (set) Token: 0x0600E970 RID: 59760 RVA: 0x003DCB8D File Offset: 0x003DAF8D
		public LimitTimeGiftPriceType PriceType
		{
			get
			{
				return this.priceType;
			}
			set
			{
				this.priceType = value;
			}
		}

		// Token: 0x17001CD3 RID: 7379
		// (get) Token: 0x0600E971 RID: 59761 RVA: 0x003DCB96 File Offset: 0x003DAF96
		// (set) Token: 0x0600E972 RID: 59762 RVA: 0x003DCB9E File Offset: 0x003DAF9E
		public string GiftIconPath
		{
			get
			{
				return this.giftIconPath;
			}
			set
			{
				this.giftIconPath = value;
			}
		}

		// Token: 0x17001CD4 RID: 7380
		// (get) Token: 0x0600E973 RID: 59763 RVA: 0x003DCBA7 File Offset: 0x003DAFA7
		// (set) Token: 0x0600E974 RID: 59764 RVA: 0x003DCBAF File Offset: 0x003DAFAF
		public uint GiftStartTime
		{
			get
			{
				return this.giftStartTime;
			}
			set
			{
				this.giftStartTime = value;
			}
		}

		// Token: 0x17001CD5 RID: 7381
		// (get) Token: 0x0600E975 RID: 59765 RVA: 0x003DCBB8 File Offset: 0x003DAFB8
		// (set) Token: 0x0600E976 RID: 59766 RVA: 0x003DCBC0 File Offset: 0x003DAFC0
		public uint GiftEndTime
		{
			get
			{
				return this.giftEndTime;
			}
			set
			{
				this.giftEndTime = value;
			}
		}

		// Token: 0x17001CD6 RID: 7382
		// (get) Token: 0x0600E977 RID: 59767 RVA: 0x003DCBC9 File Offset: 0x003DAFC9
		public LimitTimeGiftState GiftState
		{
			get
			{
				return (this.limitPurchaseNum <= 0 && this.limitType != ELimitiTimeGiftDataLimitType.None) ? LimitTimeGiftState.SoldOut : LimitTimeGiftState.OnSale;
			}
		}

		// Token: 0x17001CD7 RID: 7383
		// (get) Token: 0x0600E978 RID: 59768 RVA: 0x003DCBE9 File Offset: 0x003DAFE9
		public LimitTimeGiftIntraDay GiftIntraDay
		{
			get
			{
				if (this.GiftState == LimitTimeGiftState.SoldOut)
				{
					return LimitTimeGiftIntraDay.None;
				}
				return (this.remainingTimeSec <= 86400U) ? LimitTimeGiftIntraDay.IntraDay : LimitTimeGiftIntraDay.MoreThanOneDay;
			}
		}

		// Token: 0x17001CD8 RID: 7384
		// (get) Token: 0x0600E979 RID: 59769 RVA: 0x003DCC10 File Offset: 0x003DB010
		// (set) Token: 0x0600E97A RID: 59770 RVA: 0x003DCC18 File Offset: 0x003DB018
		public string GiftDesc { get; set; }

		// Token: 0x17001CD9 RID: 7385
		// (get) Token: 0x0600E97B RID: 59771 RVA: 0x003DCC21 File Offset: 0x003DB021
		public bool NeedTimeCountDown
		{
			get
			{
				return this.GiftIntraDay == LimitTimeGiftIntraDay.IntraDay;
			}
		}

		// Token: 0x0600E97C RID: 59772 RVA: 0x003DCC36 File Offset: 0x003DB036
		public string GiftStartTimeToCN()
		{
			if (this.giftStartTime != 0U)
			{
				return this.TransTimeStampToStr(this.giftStartTime);
			}
			return string.Empty;
		}

		// Token: 0x0600E97D RID: 59773 RVA: 0x003DCC55 File Offset: 0x003DB055
		public string GiftEndTimeToCN()
		{
			if (this.giftEndTime != 0U)
			{
				return this.TransTimeStampToStr(this.giftEndTime);
			}
			return string.Empty;
		}

		// Token: 0x17001CDA RID: 7386
		// (get) Token: 0x0600E97E RID: 59774 RVA: 0x003DCC74 File Offset: 0x003DB074
		// (set) Token: 0x0600E97F RID: 59775 RVA: 0x003DCC7C File Offset: 0x003DB07C
		public List<LimitTimeGiftData> ThreeToOneGifts
		{
			get
			{
				return this.threeToOneGifts;
			}
			set
			{
				this.threeToOneGifts = value;
			}
		}

		// Token: 0x0600E980 RID: 59776 RVA: 0x003DCC88 File Offset: 0x003DB088
		public void Reset()
		{
			this.giftId = uint.MaxValue;
			this.giftName = string.Empty;
			this.limitPurchaseNum = 0;
			this.giftAwards = null;
			this.threeToOneGifts = null;
			this.remainingTimeSec = 0U;
			this.giftPrice = 0;
			this.limitType = ELimitiTimeGiftDataLimitType.None;
			this.priceType = LimitTimeGiftPriceType.Point;
			this.giftType = MallGoodsType.INVALID;
			this.giftIconPath = string.Empty;
			this.giftStartTime = 0U;
			this.giftEndTime = 0U;
		}

		// Token: 0x0600E981 RID: 59777 RVA: 0x003DCCFC File Offset: 0x003DB0FC
		private string ReadGiftDescFromTable(uint giftId)
		{
			string result = "勇士，强化时金币不足？我们为您准备了特价强化礼包，限时限量促销！";
			MallGiftPackTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallGiftPackTable>((int)giftId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.giftDesc;
			}
			return result;
		}

		// Token: 0x0600E982 RID: 59778 RVA: 0x003DCD34 File Offset: 0x003DB134
		private string TransTimeFormat(int second)
		{
			string text = string.Empty;
			if (second > 86400)
			{
				text = (second / 86400).ToString();
				return text + "天";
			}
			int num = second / 3600;
			int num2 = second % 3600 / 60;
			int num3 = second % 60;
			if (num < 10)
			{
				text = text + "0" + num.ToString();
			}
			else
			{
				text += num.ToString();
			}
			text += ":";
			if (num2 < 10)
			{
				text = text + "0" + num2.ToString();
			}
			else
			{
				text += num2.ToString();
			}
			text += ":";
			if (num3 < 10)
			{
				text = text + "0" + num3.ToString();
			}
			else
			{
				text += num3.ToString();
			}
			return text;
		}

		// Token: 0x0600E983 RID: 59779 RVA: 0x003DCE58 File Offset: 0x003DB258
		private string TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日", dateTime.Month, dateTime.Day);
		}

		// Token: 0x0600E984 RID: 59780 RVA: 0x003DCEA9 File Offset: 0x003DB2A9
		public int CompareTo(LimitTimeGiftData obj)
		{
			return this.remainingTimeSec.CompareTo(obj.remainingTimeSec);
		}

		// Token: 0x04008D75 RID: 36213
		public MallItemInfo mallItemInfoData;

		// Token: 0x04008D76 RID: 36214
		private uint giftId;

		// Token: 0x04008D77 RID: 36215
		private string giftName;

		// Token: 0x04008D78 RID: 36216
		private int limitPurchaseNum;

		// Token: 0x04008D79 RID: 36217
		private int limitNum;

		// Token: 0x04008D7A RID: 36218
		private int limitTotalNum;

		// Token: 0x04008D7B RID: 36219
		private int limitLastNum;

		// Token: 0x04008D7C RID: 36220
		private List<LimitTimeGiftAwardData> giftAwards;

		// Token: 0x04008D7D RID: 36221
		private uint remainingTimeSec;

		// Token: 0x04008D7E RID: 36222
		private int giftPrice;

		// Token: 0x04008D7F RID: 36223
		private ELimitiTimeGiftDataLimitType limitType;

		// Token: 0x04008D80 RID: 36224
		private MallGoodsType giftType;

		// Token: 0x04008D81 RID: 36225
		private LimitTimeGiftPriceType priceType;

		// Token: 0x04008D82 RID: 36226
		private string giftIconPath;

		// Token: 0x04008D83 RID: 36227
		private uint giftStartTime;

		// Token: 0x04008D84 RID: 36228
		private uint giftEndTime;

		// Token: 0x04008D86 RID: 36230
		private List<LimitTimeGiftData> threeToOneGifts;
	}
}
