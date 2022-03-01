using System;

namespace GameClient
{
	// Token: 0x02001C29 RID: 7209
	public class TeamDuplicationRequesterListFrame : ClientFrame
	{
		// Token: 0x06011AF2 RID: 72434 RVA: 0x0052E6B8 File Offset: 0x0052CAB8
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationRequesterListFrame";
		}

		// Token: 0x06011AF3 RID: 72435 RVA: 0x0052E6BF File Offset: 0x0052CABF
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationRequesterListView != null)
			{
				this.mTeamDuplicationRequesterListView.Init();
			}
		}

		// Token: 0x06011AF4 RID: 72436 RVA: 0x0052E6E3 File Offset: 0x0052CAE3
		protected override void _bindExUI()
		{
			this.mTeamDuplicationRequesterListView = this.mBind.GetCom<TeamDuplicationRequesterListView>("TeamDuplicationRequesterListView");
		}

		// Token: 0x06011AF5 RID: 72437 RVA: 0x0052E6FB File Offset: 0x0052CAFB
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationRequesterListView = null;
		}

		// Token: 0x0400B853 RID: 47187
		private TeamDuplicationRequesterListView mTeamDuplicationRequesterListView;
	}
}
