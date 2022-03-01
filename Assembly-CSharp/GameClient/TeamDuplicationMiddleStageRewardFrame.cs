using System;

namespace GameClient
{
	// Token: 0x02001CA8 RID: 7336
	public class TeamDuplicationMiddleStageRewardFrame : ClientFrame
	{
		// Token: 0x06012017 RID: 73751 RVA: 0x00543684 File Offset: 0x00541A84
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Result/TeamDuplicationMiddleStageRewardFrame";
		}

		// Token: 0x06012018 RID: 73752 RVA: 0x0054368C File Offset: 0x00541A8C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationMiddleStageRewardView != null)
			{
				TeamDuplicationFightStageDescriptionDataModel teamDuplicationFightStageDescriptionDataModel = this.userData as TeamDuplicationFightStageDescriptionDataModel;
				if (teamDuplicationFightStageDescriptionDataModel != null)
				{
					this.mTeamDuplicationMiddleStageRewardView.Init(teamDuplicationFightStageDescriptionDataModel.StageId, teamDuplicationFightStageDescriptionDataModel.IsIn65LevelTeamDuplication, teamDuplicationFightStageDescriptionDataModel.PassTypeIn65LevelTeamDuplication);
				}
			}
		}

		// Token: 0x06012019 RID: 73753 RVA: 0x005436DF File Offset: 0x00541ADF
		protected override void _bindExUI()
		{
			this.mTeamDuplicationMiddleStageRewardView = this.mBind.GetCom<TeamDuplicationMiddleStageRewardView>("TeamDuplicationMiddleStageRewardView");
		}

		// Token: 0x0601201A RID: 73754 RVA: 0x005436F7 File Offset: 0x00541AF7
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationMiddleStageRewardView = null;
		}

		// Token: 0x0400BBAD RID: 48045
		private TeamDuplicationMiddleStageRewardView mTeamDuplicationMiddleStageRewardView;
	}
}
