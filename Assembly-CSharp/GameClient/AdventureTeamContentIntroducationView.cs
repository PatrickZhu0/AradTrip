using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001420 RID: 5152
	public class AdventureTeamContentIntroducationView : AdventureTeamContentBaseView
	{
		// Token: 0x0600C7A1 RID: 51105 RVA: 0x00304B03 File Offset: 0x00302F03
		public override void InitData()
		{
			if (this.incomeControl != null)
			{
				this.incomeControl.TryInitBaseInfoView();
			}
			this._TryRefreshView();
		}

		// Token: 0x0600C7A2 RID: 51106 RVA: 0x00304B27 File Offset: 0x00302F27
		public override void OnEnableView()
		{
			this._TryRefreshView();
		}

		// Token: 0x0600C7A3 RID: 51107 RVA: 0x00304B30 File Offset: 0x00302F30
		private void _TryRefreshView()
		{
			DataManager<AdventureTeamDataManager>.GetInstance().ReqAdventureTeamExtraInfo();
			DataManager<AdventureTeamDataManager>.GetInstance().ReqBlessCrystalInfo();
			int[] totalBaseJobTabIds = DataManager<AdventureTeamDataManager>.GetInstance().GetTotalBaseJobTabIds();
			DataManager<AdventureTeamDataManager>.GetInstance().ReqOwnJobInfo(totalBaseJobTabIds);
			DataManager<AdventureTeamDataManager>.GetInstance().OnAdventureTeamLevelChangedFlag = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAdventureTeamBaseInfoFrameOpen, null, null, null, null);
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.AdventureTeam);
		}

		// Token: 0x040072A7 RID: 29351
		[Space(10f)]
		[Header("LevelIncome")]
		[SerializeField]
		private AdventureTeamContentLevelIncomeControl incomeControl;
	}
}
