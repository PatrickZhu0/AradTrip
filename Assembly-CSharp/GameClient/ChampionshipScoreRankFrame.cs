using System;

namespace GameClient
{
	// Token: 0x02001514 RID: 5396
	public class ChampionshipScoreRankFrame : ClientFrame
	{
		// Token: 0x0600D198 RID: 53656 RVA: 0x0033B37A File Offset: 0x0033977A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Championship/Main/Score/ChampionshipScoreRankFrame";
		}

		// Token: 0x0600D199 RID: 53657 RVA: 0x0033B384 File Offset: 0x00339784
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			ChampionshipScoreScheduleDataModel championshipScoreScheduleDataModel = this.userData as ChampionshipScoreScheduleDataModel;
			int scheduleId = 0;
			bool isShowInClientSystemTown = false;
			if (championshipScoreScheduleDataModel != null)
			{
				scheduleId = championshipScoreScheduleDataModel.ScheduleId;
				isShowInClientSystemTown = championshipScoreScheduleDataModel.IsShowInClientSystemTown;
			}
			if (this.mChampionshipScoreRankView != null)
			{
				this.mChampionshipScoreRankView.InitView(scheduleId, isShowInClientSystemTown);
			}
		}

		// Token: 0x0600D19A RID: 53658 RVA: 0x0033B3D9 File Offset: 0x003397D9
		protected override void _OnCloseFrame()
		{
			DataManager<ChampionshipDataManager>.GetInstance().ResetGroupScoreRankDataModel();
		}

		// Token: 0x0600D19B RID: 53659 RVA: 0x0033B3E5 File Offset: 0x003397E5
		protected override void _bindExUI()
		{
			this.mChampionshipScoreRankView = this.mBind.GetCom<ChampionshipScoreRankView>("ChampionshipScoreRankView");
		}

		// Token: 0x0600D19C RID: 53660 RVA: 0x0033B3FD File Offset: 0x003397FD
		protected override void _unbindExUI()
		{
			this.mChampionshipScoreRankView = null;
		}

		// Token: 0x04007AA5 RID: 31397
		private ChampionshipScoreRankView mChampionshipScoreRankView;
	}
}
