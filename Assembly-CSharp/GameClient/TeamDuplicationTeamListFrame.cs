using System;

namespace GameClient
{
	// Token: 0x02001C2F RID: 7215
	public class TeamDuplicationTeamListFrame : ClientFrame
	{
		// Token: 0x06011B39 RID: 72505 RVA: 0x0052F95F File Offset: 0x0052DD5F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationTeamListFrame";
		}

		// Token: 0x06011B3A RID: 72506 RVA: 0x0052F966 File Offset: 0x0052DD66
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationTeamListView != null)
			{
				this.mTeamDuplicationTeamListView.Init();
			}
		}

		// Token: 0x06011B3B RID: 72507 RVA: 0x0052F98A File Offset: 0x0052DD8A
		protected override void _OnCloseFrame()
		{
			base._OnOpenFrame();
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamRequestJoinInEndTimeDic();
		}

		// Token: 0x06011B3C RID: 72508 RVA: 0x0052F99C File Offset: 0x0052DD9C
		protected override void _bindExUI()
		{
			this.mTeamDuplicationTeamListView = this.mBind.GetCom<TeamDuplicationTeamListView>("TeamDuplicationTeamListView");
		}

		// Token: 0x06011B3D RID: 72509 RVA: 0x0052F9B4 File Offset: 0x0052DDB4
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationTeamListView = null;
		}

		// Token: 0x0400B881 RID: 47233
		private TeamDuplicationTeamListView mTeamDuplicationTeamListView;
	}
}
