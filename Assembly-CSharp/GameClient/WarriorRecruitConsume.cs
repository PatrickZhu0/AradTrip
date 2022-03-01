using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F6E RID: 3950
	internal class WarriorRecruitConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098EC RID: 39148 RVA: 0x001D6330 File Offset: 0x001D4730
		public WarriorRecruitConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.AccountSpecialItemUpdate
			};
		}

		// Token: 0x060098ED RID: 39149 RVA: 0x001D634D File Offset: 0x001D474D
		public void OnChange()
		{
			base.cnt = DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_HIRE_COIN);
		}

		// Token: 0x060098EE RID: 39150 RVA: 0x001D6364 File Offset: 0x001D4764
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_HIRE_COIN), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
