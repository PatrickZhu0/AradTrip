using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001C35 RID: 7221
	public class TeamDuplicationTeamSettingFrame : ClientFrame
	{
		// Token: 0x06011B9C RID: 72604 RVA: 0x005316FC File Offset: 0x0052FAFC
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationTeamSettingFrame";
		}

		// Token: 0x06011B9D RID: 72605 RVA: 0x00531704 File Offset: 0x0052FB04
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationTeamSettingView != null)
			{
				TeamDuplicationTeamBuildDataModel teamDuplicationTeamBuildDataModel = this.userData as TeamDuplicationTeamBuildDataModel;
				TeamCopyTeamModel teamType = TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_CHALLENGE;
				uint teamDifficultyLevel = 0U;
				bool isResetEquipmentScore = false;
				int ownerEquipmentScore = 0;
				if (teamDuplicationTeamBuildDataModel != null)
				{
					teamType = (TeamCopyTeamModel)teamDuplicationTeamBuildDataModel.TeamModelType;
					teamDifficultyLevel = teamDuplicationTeamBuildDataModel.TeamDifficultyLevel;
					isResetEquipmentScore = teamDuplicationTeamBuildDataModel.IsResetEquipmentScore;
					ownerEquipmentScore = teamDuplicationTeamBuildDataModel.OwnerEquipmentScore;
				}
				this.mTeamDuplicationTeamSettingView.Init(teamType, teamDifficultyLevel, isResetEquipmentScore, ownerEquipmentScore);
			}
		}

		// Token: 0x06011B9E RID: 72606 RVA: 0x00531770 File Offset: 0x0052FB70
		protected override void _bindExUI()
		{
			this.mTeamDuplicationTeamSettingView = this.mBind.GetCom<TeamDuplicationTeamSettingView>("TeamDuplicationTeamSettingView");
		}

		// Token: 0x06011B9F RID: 72607 RVA: 0x00531788 File Offset: 0x0052FB88
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationTeamSettingView = null;
		}

		// Token: 0x0400B8BF RID: 47295
		private TeamDuplicationTeamSettingView mTeamDuplicationTeamSettingView;
	}
}
