using System;

namespace GameClient
{
	// Token: 0x02001C4C RID: 7244
	public class TeamDuplicationFightPreSettingFrame : ClientFrame
	{
		// Token: 0x06011CA1 RID: 72865 RVA: 0x00535652 File Offset: 0x00533A52
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightPreSettingFrame";
		}

		// Token: 0x06011CA2 RID: 72866 RVA: 0x00535659 File Offset: 0x00533A59
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightPreSettingView != null)
			{
				this.mTeamDuplicationFightPreSettingView.Init();
			}
		}

		// Token: 0x06011CA3 RID: 72867 RVA: 0x0053567D File Offset: 0x00533A7D
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightPreSettingView = this.mBind.GetCom<TeamDuplicationFightPreSettingView>("TeamDuplicationFightPreSettingView");
		}

		// Token: 0x06011CA4 RID: 72868 RVA: 0x00535695 File Offset: 0x00533A95
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightPreSettingView = null;
		}

		// Token: 0x0400B959 RID: 47449
		private TeamDuplicationFightPreSettingView mTeamDuplicationFightPreSettingView;
	}
}
