using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F70 RID: 3952
	internal class AnniversaryPointConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098F2 RID: 39154 RVA: 0x001D6407 File Offset: 0x001D4807
		public AnniversaryPointConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnAnniversaryPointChanged
			};
		}

		// Token: 0x060098F3 RID: 39155 RVA: 0x001D6424 File Offset: 0x001D4824
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_SECRET_SELL_COIN), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}

		// Token: 0x060098F4 RID: 39156 RVA: 0x001D645C File Offset: 0x001D485C
		public void OnChange()
		{
			base.cnt = (ulong)((long)DataManager<ActivityDataManager>.GetInstance().AnniversaryPoint);
		}
	}
}
