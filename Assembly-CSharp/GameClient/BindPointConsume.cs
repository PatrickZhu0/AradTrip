using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F61 RID: 3937
	internal class BindPointConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098C6 RID: 39110 RVA: 0x001D5C45 File Offset: 0x001D4045
		public BindPointConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.BindTicketChanged
			};
		}

		// Token: 0x060098C7 RID: 39111 RVA: 0x001D5C5F File Offset: 0x001D405F
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().BindTicket;
		}

		// Token: 0x060098C8 RID: 39112 RVA: 0x001D5C74 File Offset: 0x001D4074
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
