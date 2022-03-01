using System;

namespace GameClient
{
	// Token: 0x02001C5C RID: 7260
	public class TeamDuplicationFightStartVoteFrame : ClientFrame
	{
		// Token: 0x06011D48 RID: 73032 RVA: 0x00537AB3 File Offset: 0x00535EB3
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/Vote/TeamDuplicationFightStartVoteFrame";
		}

		// Token: 0x06011D49 RID: 73033 RVA: 0x00537ABA File Offset: 0x00535EBA
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightStartVoteView != null)
			{
				this.mTeamDuplicationFightStartVoteView.Init();
			}
		}

		// Token: 0x06011D4A RID: 73034 RVA: 0x00537ADE File Offset: 0x00535EDE
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightStartVoteView = this.mBind.GetCom<TeamDuplicationFightStartVoteView>("TeamDuplicationFightStartVoteView");
		}

		// Token: 0x06011D4B RID: 73035 RVA: 0x00537AF6 File Offset: 0x00535EF6
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightStartVoteView = null;
		}

		// Token: 0x0400B9B5 RID: 47541
		private TeamDuplicationFightStartVoteView mTeamDuplicationFightStartVoteView;
	}
}
