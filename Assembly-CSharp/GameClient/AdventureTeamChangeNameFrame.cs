using System;

namespace GameClient
{
	// Token: 0x020013FE RID: 5118
	public class AdventureTeamChangeNameFrame : ClientFrame
	{
		// Token: 0x0600C647 RID: 50759 RVA: 0x002FDB0A File Offset: 0x002FBF0A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AdventureTeam/AdventureTeamChangeNameFrame";
		}

		// Token: 0x0600C648 RID: 50760 RVA: 0x002FDB14 File Offset: 0x002FBF14
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				Logger.LogError("AdventureTeamChangeNameFrame out param data is null");
				return;
			}
			AdventureTeamRenameModel adventureTeamRenameModel = this.userData as AdventureTeamRenameModel;
			if (adventureTeamRenameModel == null)
			{
				Logger.LogError("AdventureTeamChangeNameFrame renameModel is null");
				return;
			}
			if (this.mAdventureTeamChangeNameView != null)
			{
				this.mAdventureTeamChangeNameView.InitData(adventureTeamRenameModel);
			}
		}

		// Token: 0x0600C649 RID: 50761 RVA: 0x002FDB71 File Offset: 0x002FBF71
		protected override void _OnCloseFrame()
		{
			if (this.mAdventureTeamChangeNameView != null)
			{
				this.mAdventureTeamChangeNameView.Clear();
			}
		}

		// Token: 0x0600C64A RID: 50762 RVA: 0x002FDB8F File Offset: 0x002FBF8F
		protected override void _bindExUI()
		{
			this.mAdventureTeamChangeNameView = this.mBind.GetCom<AdventureTeamChangeNameView>("AdventureTeamChangeNameView");
		}

		// Token: 0x0600C64B RID: 50763 RVA: 0x002FDBA7 File Offset: 0x002FBFA7
		protected override void _unbindExUI()
		{
			this.mAdventureTeamChangeNameView = null;
		}

		// Token: 0x040071BE RID: 29118
		private AdventureTeamChangeNameView mAdventureTeamChangeNameView;
	}
}
