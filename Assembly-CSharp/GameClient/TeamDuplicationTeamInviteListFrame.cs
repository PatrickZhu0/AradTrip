using System;

namespace GameClient
{
	// Token: 0x02001C2D RID: 7213
	public class TeamDuplicationTeamInviteListFrame : ClientFrame
	{
		// Token: 0x06011B23 RID: 72483 RVA: 0x0052F460 File Offset: 0x0052D860
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationTeamInviteListFrame";
		}

		// Token: 0x06011B24 RID: 72484 RVA: 0x0052F467 File Offset: 0x0052D867
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationTeamInviteListView != null)
			{
				this.mTeamDuplicationTeamInviteListView.Init();
			}
		}

		// Token: 0x06011B25 RID: 72485 RVA: 0x0052F48B File Offset: 0x0052D88B
		protected override void _bindExUI()
		{
			this.mTeamDuplicationTeamInviteListView = this.mBind.GetCom<TeamDuplicationTeamInviteListView>("TeamDuplicationTeamInviteListView");
		}

		// Token: 0x06011B26 RID: 72486 RVA: 0x0052F4A3 File Offset: 0x0052D8A3
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationTeamInviteListView = null;
		}

		// Token: 0x0400B87A RID: 47226
		private TeamDuplicationTeamInviteListView mTeamDuplicationTeamInviteListView;
	}
}
