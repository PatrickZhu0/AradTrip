using System;

namespace GameClient
{
	// Token: 0x02001C54 RID: 7252
	public class TeamDuplicationFightStageEndDescriptionFrame : ClientFrame
	{
		// Token: 0x06011CE6 RID: 72934 RVA: 0x00536136 File Offset: 0x00534536
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightStageEndDescriptionFrame";
		}

		// Token: 0x06011CE7 RID: 72935 RVA: 0x00536140 File Offset: 0x00534540
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightStageEndDescriptionView != null)
			{
				TeamDuplicationFightStageDescriptionDataModel teamDuplicationFightStageDescriptionDataModel = this.userData as TeamDuplicationFightStageDescriptionDataModel;
				if (teamDuplicationFightStageDescriptionDataModel != null)
				{
					this.mTeamDuplicationFightStageEndDescriptionView.Init(teamDuplicationFightStageDescriptionDataModel.StageId, teamDuplicationFightStageDescriptionDataModel.IsIn65LevelTeamDuplication, teamDuplicationFightStageDescriptionDataModel.PassTypeIn65LevelTeamDuplication);
				}
			}
		}

		// Token: 0x06011CE8 RID: 72936 RVA: 0x00536193 File Offset: 0x00534593
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightStageEndDescriptionView = this.mBind.GetCom<TeamDuplicationFightStageEndDescriptionView>("TeamDuplicationFightStageEndDescriptionView");
		}

		// Token: 0x06011CE9 RID: 72937 RVA: 0x005361AB File Offset: 0x005345AB
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightStageEndDescriptionView = null;
		}

		// Token: 0x0400B975 RID: 47477
		private TeamDuplicationFightStageEndDescriptionView mTeamDuplicationFightStageEndDescriptionView;
	}
}
