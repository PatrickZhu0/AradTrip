using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F63 RID: 3939
	internal class ResurrectionCcurrencyComsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098CC RID: 39116 RVA: 0x001D5D10 File Offset: 0x001D4110
		public ResurrectionCcurrencyComsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.AliveCoinChanged
			};
		}

		// Token: 0x060098CD RID: 39117 RVA: 0x001D5D2A File Offset: 0x001D412A
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().AliveCoin;
		}

		// Token: 0x060098CE RID: 39118 RVA: 0x001D5D3C File Offset: 0x001D413C
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ResurrectionCcurrency), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
