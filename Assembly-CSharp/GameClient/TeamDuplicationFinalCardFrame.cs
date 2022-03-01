using System;

namespace GameClient
{
	// Token: 0x02001C7E RID: 7294
	public class TeamDuplicationFinalCardFrame : ClientFrame
	{
		// Token: 0x06011E4C RID: 73292 RVA: 0x0053C371 File Offset: 0x0053A771
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/GridMap/Result/TeamDuplicationFinalCardFrame";
		}

		// Token: 0x06011E4D RID: 73293 RVA: 0x0053C378 File Offset: 0x0053A778
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFinalCardView != null)
			{
				this.mTeamDuplicationFinalCardView.Init();
			}
		}

		// Token: 0x06011E4E RID: 73294 RVA: 0x0053C39C File Offset: 0x0053A79C
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFinalCardView = this.mBind.GetCom<TeamDuplicationFinalCardView>("TeamDuplicationFinalCardView");
		}

		// Token: 0x06011E4F RID: 73295 RVA: 0x0053C3B4 File Offset: 0x0053A7B4
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFinalCardView = null;
		}

		// Token: 0x0400BA79 RID: 47737
		private TeamDuplicationFinalCardView mTeamDuplicationFinalCardView;
	}
}
