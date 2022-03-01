using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F5B RID: 3931
	internal class BindGoldConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098B4 RID: 39092 RVA: 0x001D5A25 File Offset: 0x001D3E25
		public BindGoldConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.BindGoldChanged
			};
		}

		// Token: 0x060098B5 RID: 39093 RVA: 0x001D5A3F File Offset: 0x001D3E3F
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().BindGold;
		}

		// Token: 0x060098B6 RID: 39094 RVA: 0x001D5A54 File Offset: 0x001D3E54
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindGOLD), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
