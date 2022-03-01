using System;

namespace GameClient
{
	// Token: 0x0200140C RID: 5132
	public class AdventureTeamExpeditionCharacterSelectFrame : ClientFrame
	{
		// Token: 0x0600C6DE RID: 50910 RVA: 0x00300C2C File Offset: 0x002FF02C
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventureTeam/AdventureTeamExpeditionCharacterSelectFrame";
		}

		// Token: 0x0600C6DF RID: 50911 RVA: 0x00300C33 File Offset: 0x002FF033
		protected override void _OnOpenFrame()
		{
			if (this.mAdventureTeamExpeditionCharacterSelectView != null)
			{
				this.mAdventureTeamExpeditionCharacterSelectView.InitData();
			}
		}

		// Token: 0x0600C6E0 RID: 50912 RVA: 0x00300C51 File Offset: 0x002FF051
		protected override void _OnCloseFrame()
		{
			if (this.mAdventureTeamExpeditionCharacterSelectView != null)
			{
				this.mAdventureTeamExpeditionCharacterSelectView.Clear();
			}
		}

		// Token: 0x0600C6E1 RID: 50913 RVA: 0x00300C6F File Offset: 0x002FF06F
		protected override void _bindExUI()
		{
			this.mAdventureTeamExpeditionCharacterSelectView = this.mBind.GetCom<AdventureTeamExpeditionCharacterSelectView>("AdventureTeamCharacterSelectView");
		}

		// Token: 0x0600C6E2 RID: 50914 RVA: 0x00300C87 File Offset: 0x002FF087
		protected override void _unbindExUI()
		{
			this.mAdventureTeamExpeditionCharacterSelectView = null;
		}

		// Token: 0x0400721D RID: 29213
		private AdventureTeamExpeditionCharacterSelectView mAdventureTeamExpeditionCharacterSelectView;
	}
}
