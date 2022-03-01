using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x0200135A RID: 4954
	public class CardExchangeData
	{
		// Token: 0x0600C014 RID: 49172 RVA: 0x002D3C74 File Offset: 0x002D2074
		public void RefreshState()
		{
			if (this.costCardList != null)
			{
				this.state = 1;
				for (int i = 0; i < this.costCardList.Count; i++)
				{
					ItemSimpleData itemSimpleData = this.costCardList[i];
					if (itemSimpleData != null)
					{
						MonpolyCard monpolyCard = DataManager<ZillionaireGameDataManager>.GetInstance().monpolyCardList.Find((MonpolyCard x) => (ulong)x.id == (ulong)((long)itemSimpleData.ItemID));
						if (monpolyCard == null)
						{
							this.state = 1;
							break;
						}
						if ((ulong)monpolyCard.num < (ulong)((long)itemSimpleData.Count))
						{
							this.state = 1;
							break;
						}
						this.state = 2;
					}
				}
			}
		}

		// Token: 0x04006C79 RID: 27769
		public int tableId;

		// Token: 0x04006C7A RID: 27770
		public int limitCount;

		// Token: 0x04006C7B RID: 27771
		public int type;

		// Token: 0x04006C7C RID: 27772
		public int state;

		// Token: 0x04006C7D RID: 27773
		public List<ItemSimpleData> costCardList;

		// Token: 0x04006C7E RID: 27774
		public ItemSimpleData reward;
	}
}
