using System;

namespace GameClient
{
	// Token: 0x020014C3 RID: 5315
	public class ChallengeDropDetailFrame : ClientFrame
	{
		// Token: 0x0600CE0F RID: 52751 RVA: 0x0032C42F File Offset: 0x0032A82F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Challenge/ChallengeDropDetailFrame";
		}

		// Token: 0x0600CE10 RID: 52752 RVA: 0x0032C438 File Offset: 0x0032A838
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mChallengeDropDetailView != null)
			{
				int dungeonId = (int)this.userData;
				this.mChallengeDropDetailView.InitView(dungeonId);
			}
		}

		// Token: 0x0600CE11 RID: 52753 RVA: 0x0032C474 File Offset: 0x0032A874
		protected override void _bindExUI()
		{
			this.mChallengeDropDetailView = this.mBind.GetCom<ChallengeDropDetailView>("ChallengeDropDetailView");
		}

		// Token: 0x0600CE12 RID: 52754 RVA: 0x0032C48C File Offset: 0x0032A88C
		protected override void _unbindExUI()
		{
			this.mChallengeDropDetailView = null;
		}

		// Token: 0x04007851 RID: 30801
		private ChallengeDropDetailView mChallengeDropDetailView;
	}
}
