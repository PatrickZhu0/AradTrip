using System;

namespace GameClient
{
	// Token: 0x02001CA4 RID: 7332
	public class TeamDuplicationFinalStageCardFrame : ClientFrame
	{
		// Token: 0x06011FE5 RID: 73701 RVA: 0x00542DCB File Offset: 0x005411CB
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Result/TeamDuplicationFinalStageCardFrame";
		}

		// Token: 0x06011FE6 RID: 73702 RVA: 0x00542DD2 File Offset: 0x005411D2
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFinalStageCardView != null)
			{
				this.mTeamDuplicationFinalStageCardView.Init();
			}
		}

		// Token: 0x06011FE7 RID: 73703 RVA: 0x00542DF6 File Offset: 0x005411F6
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFinalStageCardView = this.mBind.GetCom<TeamDuplicationFinalStageCardView>("TeamDuplicationFinalStageCardView");
		}

		// Token: 0x06011FE8 RID: 73704 RVA: 0x00542E0E File Offset: 0x0054120E
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFinalStageCardView = null;
		}

		// Token: 0x0400BB92 RID: 48018
		private TeamDuplicationFinalStageCardView mTeamDuplicationFinalStageCardView;
	}
}
