using System;

namespace GameClient
{
	// Token: 0x02001C56 RID: 7254
	public class TeamDuplicationFightStagePanelFrame : ClientFrame
	{
		// Token: 0x06011CF3 RID: 72947 RVA: 0x0053635A File Offset: 0x0053475A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightStagePanelFrame";
		}

		// Token: 0x06011CF4 RID: 72948 RVA: 0x00536364 File Offset: 0x00534764
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightStagePanelView != null)
			{
				int fightStageId = (int)this.userData;
				this.mTeamDuplicationFightStagePanelView.Init(fightStageId);
			}
		}

		// Token: 0x06011CF5 RID: 72949 RVA: 0x005363A0 File Offset: 0x005347A0
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightStagePanelView = this.mBind.GetCom<TeamDuplicationFightStagePanelView>("TeamDuplicationFightStagePanelView");
		}

		// Token: 0x06011CF6 RID: 72950 RVA: 0x005363B8 File Offset: 0x005347B8
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightStagePanelView = null;
		}

		// Token: 0x0400B983 RID: 47491
		private TeamDuplicationFightStagePanelView mTeamDuplicationFightStagePanelView;
	}
}
