using System;

namespace GameClient
{
	// Token: 0x02000F6D RID: 3949
	internal class PassBlessConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098E9 RID: 39145 RVA: 0x001D62F9 File Offset: 0x001D46F9
		public PassBlessConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnAdventureTeamBountyCountChanged
			};
		}

		// Token: 0x060098EA RID: 39146 RVA: 0x001D6316 File Offset: 0x001D4716
		public void OnChange()
		{
			base.cnt = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamPassBlessCount();
		}

		// Token: 0x060098EB RID: 39147 RVA: 0x001D6328 File Offset: 0x001D4728
		public void OnAdd()
		{
			AdventureTeamInformationFrame.OpenTabFrame(AdventureTeamMainTabType.PassingBless);
		}
	}
}
