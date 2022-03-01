using System;

namespace GameClient
{
	// Token: 0x02000F6B RID: 3947
	internal class BlessCrystalConsume : BaseConsum, ICommonConsume
	{
		// Token: 0x060098E3 RID: 39139 RVA: 0x001D624F File Offset: 0x001D464F
		public BlessCrystalConsume(ClientFrameBinder comFrameBinder) : base(comFrameBinder)
		{
			this.mEvents = new EUIEventID[]
			{
				EUIEventID.OnAdventureTeamBlessCrystalCountChanged
			};
		}

		// Token: 0x060098E4 RID: 39140 RVA: 0x001D626C File Offset: 0x001D466C
		public void OnChange()
		{
			base.cnt = DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamBlessCrystalCount();
		}

		// Token: 0x060098E5 RID: 39141 RVA: 0x001D627E File Offset: 0x001D467E
		public void OnAdd()
		{
			AdventureTeamInformationFrame.OpenTabFrame(AdventureTeamMainTabType.BaseInformation);
		}
	}
}
