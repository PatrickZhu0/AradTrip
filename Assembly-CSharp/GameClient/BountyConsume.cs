using System;

namespace GameClient
{
	// Token: 0x02000F6C RID: 3948
	internal class BountyConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098E6 RID: 39142 RVA: 0x001D6286 File Offset: 0x001D4686
		public BountyConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnAdventureTeamBountyCountChanged
			};
		}

		// Token: 0x060098E7 RID: 39143 RVA: 0x001D62A3 File Offset: 0x001D46A3
		public void OnChange()
		{
			base.cnt = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamBountyCount();
		}

		// Token: 0x060098E8 RID: 39144 RVA: 0x001D62B8 File Offset: 0x001D46B8
		public void OnAdd()
		{
			BountyModle bountyModel = DataManager<AdventureTeamDataManager>.GetInstance().BountyModel;
			if (bountyModel == null)
			{
				return;
			}
			ItemComeLink.OnLink((int)bountyModel.itemTableId, 0, false, new ComLinkFrame.OnClick(base.OnCloseLinkFrame), false, true, false, null, string.Empty);
		}
	}
}
