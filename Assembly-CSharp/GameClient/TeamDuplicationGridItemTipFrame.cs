using System;

namespace GameClient
{
	// Token: 0x02001C82 RID: 7298
	public class TeamDuplicationGridItemTipFrame : ClientFrame
	{
		// Token: 0x06011E7B RID: 73339 RVA: 0x0053CB5E File Offset: 0x0053AF5E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/GridMap/TipFrame/TeamDuplicationGridItemTipFrame";
		}

		// Token: 0x06011E7C RID: 73340 RVA: 0x0053CB68 File Offset: 0x0053AF68
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			TeamDuplicationGridItemTipDataModel gridItemTipDataModel = this.userData as TeamDuplicationGridItemTipDataModel;
			if (this.mTeamDuplicationGridItemTipView != null)
			{
				this.mTeamDuplicationGridItemTipView.Init(gridItemTipDataModel);
			}
		}

		// Token: 0x06011E7D RID: 73341 RVA: 0x0053CBA4 File Offset: 0x0053AFA4
		protected override void _bindExUI()
		{
			this.mTeamDuplicationGridItemTipView = this.mBind.GetCom<TeamDuplicationGridItemTipView>("TeamDuplicationGridItemTipView");
		}

		// Token: 0x06011E7E RID: 73342 RVA: 0x0053CBBC File Offset: 0x0053AFBC
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationGridItemTipView = null;
		}

		// Token: 0x0400BA93 RID: 47763
		private TeamDuplicationGridItemTipView mTeamDuplicationGridItemTipView;
	}
}
