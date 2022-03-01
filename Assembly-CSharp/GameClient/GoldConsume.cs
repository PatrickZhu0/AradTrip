using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F5A RID: 3930
	internal class GoldConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098B1 RID: 39089 RVA: 0x001D59C3 File Offset: 0x001D3DC3
		public GoldConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.GoldChanged
			};
		}

		// Token: 0x060098B2 RID: 39090 RVA: 0x001D59DD File Offset: 0x001D3DDD
		public void OnChange()
		{
			base.cnt = DataManager<PlayerBaseData>.GetInstance().Gold;
		}

		// Token: 0x060098B3 RID: 39091 RVA: 0x001D59F0 File Offset: 0x001D3DF0
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.GOLD), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
