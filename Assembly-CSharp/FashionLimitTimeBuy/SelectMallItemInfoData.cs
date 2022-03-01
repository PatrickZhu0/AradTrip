using System;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;

namespace FashionLimitTimeBuy
{
	// Token: 0x0200172A RID: 5930
	public class SelectMallItemInfoData
	{
		// Token: 0x0600E8E7 RID: 59623 RVA: 0x003DA879 File Offset: 0x003D8C79
		public SelectMallItemInfoData()
		{
			this.Reset();
		}

		// Token: 0x17001CBB RID: 7355
		// (get) Token: 0x0600E8E8 RID: 59624 RVA: 0x003DA888 File Offset: 0x003D8C88
		public int TotalPrice
		{
			get
			{
				if (this.selectItemInfos != null)
				{
					this.totalPrice = 0;
					for (int i = 0; i < this.selectItemInfos.Count; i++)
					{
						this.totalPrice += (int)this.selectItemInfos[i].discountprice;
					}
					return this.totalPrice;
				}
				return 0;
			}
		}

		// Token: 0x17001CBC RID: 7356
		// (get) Token: 0x0600E8E9 RID: 59625 RVA: 0x003DA8EC File Offset: 0x003D8CEC
		public float _Discount
		{
			get
			{
				if (this.selectItemInfos != null)
				{
					for (int i = 0; i < this.selectItemInfos.Count; i++)
					{
						this.Discount = this.selectItemInfos[i].discountRate * 1f / 10f;
						if (this.Discount != 0f)
						{
							return this.Discount;
						}
					}
				}
				return 0f;
			}
		}

		// Token: 0x17001CBD RID: 7357
		// (get) Token: 0x0600E8EA RID: 59626 RVA: 0x003DA964 File Offset: 0x003D8D64
		public int _FashionDiscountPrice
		{
			get
			{
				if (this.selectItemInfos != null)
				{
					for (int i = 0; i < this.selectItemInfos.Count; i++)
					{
						this.FashionDiscountPrice += (int)this.selectItemInfos[i].price;
					}
					return this.FashionDiscountPrice;
				}
				return 0;
			}
		}

		// Token: 0x17001CBE RID: 7358
		// (get) Token: 0x0600E8EB RID: 59627 RVA: 0x003DA9BE File Offset: 0x003D8DBE
		public ItemTable.eSubType MoneyType
		{
			get
			{
				if (this.selectItemInfos != null && this.selectItemInfos.Count > 0)
				{
					return (ItemTable.eSubType)this.selectItemInfos[0].moneytype;
				}
				return ItemTable.eSubType.ST_NONE;
			}
		}

		// Token: 0x17001CBF RID: 7359
		// (get) Token: 0x0600E8EC RID: 59628 RVA: 0x003DA9EF File Offset: 0x003D8DEF
		// (set) Token: 0x0600E8ED RID: 59629 RVA: 0x003DA9F7 File Offset: 0x003D8DF7
		public FashionMallMainIndex FashionTypeIndex
		{
			get
			{
				return this.fashionTypeIndex;
			}
			set
			{
				this.fashionTypeIndex = value;
			}
		}

		// Token: 0x17001CC0 RID: 7360
		// (get) Token: 0x0600E8EE RID: 59630 RVA: 0x003DAA00 File Offset: 0x003D8E00
		// (set) Token: 0x0600E8EF RID: 59631 RVA: 0x003DAA08 File Offset: 0x003D8E08
		public List<MallItemInfo> SelectItemInfos
		{
			get
			{
				return this.selectItemInfos;
			}
			set
			{
				this.selectItemInfos = value;
			}
		}

		// Token: 0x17001CC1 RID: 7361
		// (get) Token: 0x0600E8F0 RID: 59632 RVA: 0x003DAA11 File Offset: 0x003D8E11
		// (set) Token: 0x0600E8F1 RID: 59633 RVA: 0x003DAA19 File Offset: 0x003D8E19
		public List<MallItemInfo> AllTypeItemInfos
		{
			get
			{
				return this.allTypeItemInfos;
			}
			set
			{
				this.allTypeItemInfos = value;
			}
		}

		// Token: 0x17001CC2 RID: 7362
		// (get) Token: 0x0600E8F2 RID: 59634 RVA: 0x003DAA22 File Offset: 0x003D8E22
		public int multiple
		{
			get
			{
				if (this.selectItemInfos != null && this.selectItemInfos.Count > 0)
				{
					return (int)this.selectItemInfos[0].multiple;
				}
				return 0;
			}
		}

		// Token: 0x17001CC3 RID: 7363
		// (get) Token: 0x0600E8F3 RID: 59635 RVA: 0x003DAA53 File Offset: 0x003D8E53
		public uint multipleEndTime
		{
			get
			{
				if (this.selectItemInfos != null && this.selectItemInfos.Count > 0)
				{
					return this.selectItemInfos[0].multipleEndTime;
				}
				return 0U;
			}
		}

		// Token: 0x0600E8F4 RID: 59636 RVA: 0x003DAA84 File Offset: 0x003D8E84
		public void Reset()
		{
			this.totalPrice = 0;
			this.FashionDiscountPrice = 0;
			this.selectItemInfos = new List<MallItemInfo>();
			this.allTypeItemInfos = new List<MallItemInfo>();
		}

		// Token: 0x04008D47 RID: 36167
		private int totalPrice;

		// Token: 0x04008D48 RID: 36168
		private int FashionDiscountPrice;

		// Token: 0x04008D49 RID: 36169
		private float Discount;

		// Token: 0x04008D4A RID: 36170
		private int FashionDiscount;

		// Token: 0x04008D4B RID: 36171
		private ItemTable.eSubType moneyType;

		// Token: 0x04008D4C RID: 36172
		private FashionMallMainIndex fashionTypeIndex;

		// Token: 0x04008D4D RID: 36173
		private List<MallItemInfo> selectItemInfos;

		// Token: 0x04008D4E RID: 36174
		private List<MallItemInfo> allTypeItemInfos;
	}
}
