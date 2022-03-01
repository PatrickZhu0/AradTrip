using System;

namespace GameClient
{
	// Token: 0x02001C31 RID: 7217
	public class TeamDuplicationTeamPermissionFrame : ClientFrame
	{
		// Token: 0x06011B62 RID: 72546 RVA: 0x005307D4 File Offset: 0x0052EBD4
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationTeamPermissionFrame";
		}

		// Token: 0x06011B63 RID: 72547 RVA: 0x005307DC File Offset: 0x0052EBDC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationTeamPermissionView != null)
			{
				TeamDuplicationPermissionDataModel permissionDataModel = this.userData as TeamDuplicationPermissionDataModel;
				this.mTeamDuplicationTeamPermissionView.Init(permissionDataModel);
			}
		}

		// Token: 0x06011B64 RID: 72548 RVA: 0x00530818 File Offset: 0x0052EC18
		protected override void _bindExUI()
		{
			this.mTeamDuplicationTeamPermissionView = this.mBind.GetCom<TeamDuplicationTeamPermissionView>("TeamDuplicationTeamPermissionView");
		}

		// Token: 0x06011B65 RID: 72549 RVA: 0x00530830 File Offset: 0x0052EC30
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationTeamPermissionView = null;
		}

		// Token: 0x0400B89D RID: 47261
		private TeamDuplicationTeamPermissionView mTeamDuplicationTeamPermissionView;
	}
}
