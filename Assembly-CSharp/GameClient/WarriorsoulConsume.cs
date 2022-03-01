using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02000F64 RID: 3940
	internal class WarriorsoulConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098CF RID: 39119 RVA: 0x001D5D71 File Offset: 0x001D4171
		public WarriorsoulConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.WarriorSoulChanged
			};
		}

		// Token: 0x060098D0 RID: 39120 RVA: 0x001D5D8B File Offset: 0x001D418B
		public void OnChange()
		{
			base.cnt = (ulong)DataManager<PlayerBaseData>.GetInstance().WarriorSoul;
		}

		// Token: 0x060098D1 RID: 39121 RVA: 0x001D5DA0 File Offset: 0x001D41A0
		public void OnAdd()
		{
			ItemComeLink.OnLink(DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.WARRIOR_SOUL), 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
