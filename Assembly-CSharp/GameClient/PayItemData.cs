using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001951 RID: 6481
	public class PayItemData
	{
		// Token: 0x0600FBF7 RID: 64503 RVA: 0x004522F7 File Offset: 0x004506F7
		public PayItemData()
		{
		}

		// Token: 0x0600FBF8 RID: 64504 RVA: 0x00452300 File Offset: 0x00450700
		public PayItemData(ChargeGoods good)
		{
			this.ID = (int)good.id;
			this.price = (int)good.money;
			this.desc = good.desc;
			this.itemID = good.itemId;
			this.itemNum = (int)good.num;
			this.firstBonusNum = (int)good.firstAddNum;
			this.bonusNum = (int)good.unfirstAddNum;
			this.icon = good.icon;
			this.hasFirstBonus = true;
			this.tags = good.tags;
			this.remainDays = (int)good.remainDays;
			this.limit = (int)good.remainTimes;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.itemID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.SubType == ItemTable.eSubType.MonthCard)
			{
				this.isMonthCard = true;
				this.itemContent = tableItem.Description;
			}
		}

		// Token: 0x0600FBF9 RID: 64505 RVA: 0x004523DF File Offset: 0x004507DF
		public bool HasMark()
		{
			return (this.tags & 2U) != 0U;
		}

		// Token: 0x04009DA3 RID: 40355
		public int ID;

		// Token: 0x04009DA4 RID: 40356
		public int price;

		// Token: 0x04009DA5 RID: 40357
		public string desc;

		// Token: 0x04009DA6 RID: 40358
		public uint itemID;

		// Token: 0x04009DA7 RID: 40359
		public int itemNum;

		// Token: 0x04009DA8 RID: 40360
		public int firstBonusNum;

		// Token: 0x04009DA9 RID: 40361
		public int bonusNum;

		// Token: 0x04009DAA RID: 40362
		public bool hasFirstBonus;

		// Token: 0x04009DAB RID: 40363
		public int remainDays;

		// Token: 0x04009DAC RID: 40364
		public int limit;

		// Token: 0x04009DAD RID: 40365
		public string icon;

		// Token: 0x04009DAE RID: 40366
		public uint tags;

		// Token: 0x04009DAF RID: 40367
		public bool isMonthCard;

		// Token: 0x04009DB0 RID: 40368
		public string itemContent;
	}
}
