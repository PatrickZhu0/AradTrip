using System;

namespace GameClient
{
	// Token: 0x02001C5A RID: 7258
	public class TeamDuplicationFightEndVoteFrame : ClientFrame
	{
		// Token: 0x06011D28 RID: 73000 RVA: 0x00537255 File Offset: 0x00535655
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/Vote/TeamDuplicationFightEndVoteFrame";
		}

		// Token: 0x06011D29 RID: 73001 RVA: 0x0053725C File Offset: 0x0053565C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightEndVoteView != null)
			{
				this.mTeamDuplicationFightEndVoteView.Init();
			}
		}

		// Token: 0x06011D2A RID: 73002 RVA: 0x00537280 File Offset: 0x00535680
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightEndVoteView = this.mBind.GetCom<TeamDuplicationFightEndVoteView>("TeamDuplicationFightEndVoteView");
		}

		// Token: 0x06011D2B RID: 73003 RVA: 0x00537298 File Offset: 0x00535698
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightEndVoteView = null;
		}

		// Token: 0x0400B9A0 RID: 47520
		private TeamDuplicationFightEndVoteView mTeamDuplicationFightEndVoteView;
	}
}
