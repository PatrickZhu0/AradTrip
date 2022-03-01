using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F65 RID: 3941
	internal class DuelcoinConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098D2 RID: 39122 RVA: 0x001D5DD5 File Offset: 0x001D41D5
		public DuelcoinConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.PkCoinChanged
			};
		}

		// Token: 0x060098D3 RID: 39123 RVA: 0x001D5DF2 File Offset: 0x001D41F2
		public void OnChange()
		{
			base.cnt = (ulong)DataManager<PlayerBaseData>.GetInstance().uiPkCoin;
		}

		// Token: 0x060098D4 RID: 39124 RVA: 0x001D5E08 File Offset: 0x001D4208
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.DUEL_COIN), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
