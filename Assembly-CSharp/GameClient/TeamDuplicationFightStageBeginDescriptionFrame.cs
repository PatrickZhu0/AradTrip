using System;

namespace GameClient
{
	// Token: 0x02001C52 RID: 7250
	public class TeamDuplicationFightStageBeginDescriptionFrame : ClientFrame
	{
		// Token: 0x06011CDB RID: 72923 RVA: 0x00535F91 File Offset: 0x00534391
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightStageBeginDescriptionFrame";
		}

		// Token: 0x06011CDC RID: 72924 RVA: 0x00535F98 File Offset: 0x00534398
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightStageBeginDescriptionView != null)
			{
				TeamDuplicationFightStageDescriptionDataModel teamDuplicationFightStageDescriptionDataModel = this.userData as TeamDuplicationFightStageDescriptionDataModel;
				if (teamDuplicationFightStageDescriptionDataModel != null)
				{
					this.mTeamDuplicationFightStageBeginDescriptionView.Init(teamDuplicationFightStageDescriptionDataModel.StageId, true);
				}
			}
		}

		// Token: 0x06011CDD RID: 72925 RVA: 0x00535FE0 File Offset: 0x005343E0
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightStageBeginDescriptionView = this.mBind.GetCom<TeamDuplicationFightStageBeginDescriptionView>("TeamDuplicationFightStageBeginDescriptionView");
		}

		// Token: 0x06011CDE RID: 72926 RVA: 0x00535FF8 File Offset: 0x005343F8
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightStageBeginDescriptionView = null;
		}

		// Token: 0x0400B96D RID: 47469
		private TeamDuplicationFightStageBeginDescriptionView mTeamDuplicationFightStageBeginDescriptionView;
	}
}
