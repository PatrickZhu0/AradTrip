using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F62 RID: 3938
	internal class CreditTicketConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098C9 RID: 39113 RVA: 0x001D5CA9 File Offset: 0x001D40A9
		public CreditTicketConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.CreditTicketOwnerBySelfChanged
			};
		}

		// Token: 0x060098CA RID: 39114 RVA: 0x001D5CC3 File Offset: 0x001D40C3
		public void OnChange()
		{
			base.cnt = (ulong)DataManager<PlayerBaseData>.GetInstance().CreditTicketOwnerBySelf;
		}

		// Token: 0x060098CB RID: 39115 RVA: 0x001D5CD8 File Offset: 0x001D40D8
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_CREDIT_POINT), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
