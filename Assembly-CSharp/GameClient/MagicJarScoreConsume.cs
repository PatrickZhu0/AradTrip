using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F5E RID: 3934
	internal class MagicJarScoreConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098BD RID: 39101 RVA: 0x001D5B51 File Offset: 0x001D3F51
		public MagicJarScoreConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.MagicJarScoreChanged
			};
		}

		// Token: 0x060098BE RID: 39102 RVA: 0x001D5B6B File Offset: 0x001D3F6B
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().MagicJarScore;
		}

		// Token: 0x060098BF RID: 39103 RVA: 0x001D5B80 File Offset: 0x001D3F80
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.MagicJarPoint), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
