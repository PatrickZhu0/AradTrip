using System;

namespace GameClient
{
	// Token: 0x02001C50 RID: 7248
	public class TeamDuplicationFightSettingDifficultyFrame : ClientFrame
	{
		// Token: 0x06011CC4 RID: 72900 RVA: 0x00535A7F File Offset: 0x00533E7F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/TeamDuplicationFightSettingDifficultyFrame";
		}

		// Token: 0x06011CC5 RID: 72901 RVA: 0x00535A86 File Offset: 0x00533E86
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationFightSettingDifficultyView != null)
			{
				this.mTeamDuplicationFightSettingDifficultyView.Init();
			}
		}

		// Token: 0x06011CC6 RID: 72902 RVA: 0x00535AAA File Offset: 0x00533EAA
		protected override void _bindExUI()
		{
			this.mTeamDuplicationFightSettingDifficultyView = this.mBind.GetCom<TeamDuplicationFightSettingDifficultyView>("TeamDuplicationFightSettingDifficultyView");
		}

		// Token: 0x06011CC7 RID: 72903 RVA: 0x00535AC2 File Offset: 0x00533EC2
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationFightSettingDifficultyView = null;
		}

		// Token: 0x0400B965 RID: 47461
		private TeamDuplicationFightSettingDifficultyView mTeamDuplicationFightSettingDifficultyView;
	}
}
