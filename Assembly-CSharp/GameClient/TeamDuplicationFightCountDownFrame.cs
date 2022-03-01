using System;

namespace GameClient
{
	// Token: 0x02001C4A RID: 7242
	public class TeamDuplicationFightCountDownFrame : ClientFrame
	{
		// Token: 0x06011C95 RID: 72853 RVA: 0x005354EE File Offset: 0x005338EE
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightCountDownFrame";
		}

		// Token: 0x06011C96 RID: 72854 RVA: 0x005354F5 File Offset: 0x005338F5
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightCountDownView != null)
			{
				this.mTeamDuplicationFightCountDownView.Init();
			}
		}

		// Token: 0x06011C97 RID: 72855 RVA: 0x00535519 File Offset: 0x00533919
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightCountDownView = this.mBind.GetCom<TeamDuplicationFightCountDownView>("TeamDuplicationFightCountDownView");
		}

		// Token: 0x06011C98 RID: 72856 RVA: 0x00535531 File Offset: 0x00533931
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightCountDownView = null;
		}

		// Token: 0x0400B950 RID: 47440
		private TeamDuplicationFightCountDownView mTeamDuplicationFightCountDownView;
	}
}
