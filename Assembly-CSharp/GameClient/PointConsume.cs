using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F60 RID: 3936
	internal class PointConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098C3 RID: 39107 RVA: 0x001D5BE3 File Offset: 0x001D3FE3
		public PointConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.TicketChanged
			};
		}

		// Token: 0x060098C4 RID: 39108 RVA: 0x001D5BFD File Offset: 0x001D3FFD
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().Ticket;
		}

		// Token: 0x060098C5 RID: 39109 RVA: 0x001D5C10 File Offset: 0x001D4010
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
