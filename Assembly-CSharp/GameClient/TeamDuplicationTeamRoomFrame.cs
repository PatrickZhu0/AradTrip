using System;

namespace GameClient
{
	// Token: 0x02001C33 RID: 7219
	public class TeamDuplicationTeamRoomFrame : ClientFrame
	{
		// Token: 0x06011B84 RID: 72580 RVA: 0x00531048 File Offset: 0x0052F448
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationTeamRoomFrame";
		}

		// Token: 0x06011B85 RID: 72581 RVA: 0x00531050 File Offset: 0x0052F450
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationTeamRoomView != null)
			{
				int teamId = (int)this.userData;
				this.mTeamDuplicationTeamRoomView.Init(teamId);
			}
		}

		// Token: 0x06011B86 RID: 72582 RVA: 0x0053108C File Offset: 0x0052F48C
		protected override void _bindExUI()
		{
			this.mTeamDuplicationTeamRoomView = this.mBind.GetCom<TeamDuplicationTeamRoomView>("TeamDuplicationTeamRoomView");
		}

		// Token: 0x06011B87 RID: 72583 RVA: 0x005310A4 File Offset: 0x0052F4A4
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationTeamRoomView = null;
		}

		// Token: 0x0400B8B1 RID: 47281
		private TeamDuplicationTeamRoomView mTeamDuplicationTeamRoomView;
	}
}
