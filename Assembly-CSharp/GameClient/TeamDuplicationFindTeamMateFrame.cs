using System;

namespace GameClient
{
	// Token: 0x02001C25 RID: 7205
	public class TeamDuplicationFindTeamMateFrame : ClientFrame
	{
		// Token: 0x06011AC6 RID: 72390 RVA: 0x0052DD00 File Offset: 0x0052C100
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Build/TeamDuplicationFindTeamMateFrame";
		}

		// Token: 0x06011AC7 RID: 72391 RVA: 0x0052DD07 File Offset: 0x0052C107
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFindTeamMateView != null)
			{
				this.mTeamDuplicationFindTeamMateView.Init();
			}
		}

		// Token: 0x06011AC8 RID: 72392 RVA: 0x0052DD2B File Offset: 0x0052C12B
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFindTeamMateView = this.mBind.GetCom<TeamDuplicationFindTeamMateView>("TeamDuplicationFindTeamMateView");
		}

		// Token: 0x06011AC9 RID: 72393 RVA: 0x0052DD43 File Offset: 0x0052C143
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFindTeamMateView = null;
		}

		// Token: 0x0400B840 RID: 47168
		private TeamDuplicationFindTeamMateView mTeamDuplicationFindTeamMateView;
	}
}
