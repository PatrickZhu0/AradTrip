using System;

namespace GameClient
{
	// Token: 0x02001C48 RID: 7240
	public class TeamDuplicationGridMapFightBeginFrame : ClientFrame
	{
		// Token: 0x06011C89 RID: 72841 RVA: 0x00535383 File Offset: 0x00533783
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/TeamDuplication/Fight/GridMap/TeamDuplicationGridMapFightBeginFrame";
		}

		// Token: 0x06011C8A RID: 72842 RVA: 0x0053538A File Offset: 0x0053378A
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mTeamDuplicationGridMapFightBeginView != null)
			{
				this.mTeamDuplicationGridMapFightBeginView.Init();
			}
		}

		// Token: 0x06011C8B RID: 72843 RVA: 0x005353AE File Offset: 0x005337AE
		protected override void _bindExUI()
		{
			this.mTeamDuplicationGridMapFightBeginView = this.mBind.GetCom<TeamDuplicationGridMapFightBeginView>("TeamDuplicationGridMapFightBeginView");
		}

		// Token: 0x06011C8C RID: 72844 RVA: 0x005353C6 File Offset: 0x005337C6
		protected override void _unbindExUI()
		{
			this.mTeamDuplicationGridMapFightBeginView = null;
		}

		// Token: 0x0400B94C RID: 47436
		private TeamDuplicationGridMapFightBeginView mTeamDuplicationGridMapFightBeginView;
	}
}
