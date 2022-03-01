using System;

namespace GameClient
{
	// Token: 0x02001C4E RID: 7246
	public class TeamDuplicationFightSceneLeaveTipFrame : ClientFrame
	{
		// Token: 0x06011CB3 RID: 72883 RVA: 0x00535895 File Offset: 0x00533C95
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightSceneLeaveTipFrame";
		}

		// Token: 0x06011CB4 RID: 72884 RVA: 0x0053589C File Offset: 0x00533C9C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightSceneLeaveTipView != null)
			{
				this.mTeamDuplicationFightSceneLeaveTipView.Init();
			}
		}

		// Token: 0x06011CB5 RID: 72885 RVA: 0x005358C0 File Offset: 0x00533CC0
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightSceneLeaveTipView = this.mBind.GetCom<TeamDuplicationFightSceneLeaveTipView>("TeamDuplicationFightSceneLeaveTipView");
		}

		// Token: 0x06011CB6 RID: 72886 RVA: 0x005358D8 File Offset: 0x00533CD8
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightSceneLeaveTipView = null;
		}

		// Token: 0x0400B95F RID: 47455
		private TeamDuplicationFightSceneLeaveTipView mTeamDuplicationFightSceneLeaveTipView;
	}
}
