using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F5D RID: 3933
	internal class GoldJarScoreConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098BA RID: 39098 RVA: 0x001D5AED File Offset: 0x001D3EED
		public GoldJarScoreConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.GoldJarScoreChanged
			};
		}

		// Token: 0x060098BB RID: 39099 RVA: 0x001D5B07 File Offset: 0x001D3F07
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().GoldJarScore;
		}

		// Token: 0x060098BC RID: 39100 RVA: 0x001D5B1C File Offset: 0x001D3F1C
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GoldJarPoint), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
