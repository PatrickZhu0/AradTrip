using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F6F RID: 3951
	internal class FantasyTripConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098EF RID: 39151 RVA: 0x001D639C File Offset: 0x001D479C
		public FantasyTripConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnZillionaireGameInfoChanged
			};
		}

		// Token: 0x060098F0 RID: 39152 RVA: 0x001D63BC File Offset: 0x001D47BC
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_FANTASY_COIN), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}

		// Token: 0x060098F1 RID: 39153 RVA: 0x001D63F4 File Offset: 0x001D47F4
		public void OnChange()
		{
			base.cnt = (ulong)((long)DataManager<ZillionaireGameDataManager>.GetInstance().CoinCount);
		}
	}
}
