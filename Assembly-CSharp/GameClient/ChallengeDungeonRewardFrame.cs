using System;

namespace GameClient
{
	// Token: 0x020014C0 RID: 5312
	public class ChallengeDungeonRewardFrame : ClientFrame
	{
		// Token: 0x0600CDF6 RID: 52726 RVA: 0x0032BD4E File Offset: 0x0032A14E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Challenge/ChallengeDungeonRewardFrame";
		}

		// Token: 0x0600CDF7 RID: 52727 RVA: 0x0032BD58 File Offset: 0x0032A158
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			ChallengeDungeonRewardDataModel rewardDataModel = null;
			if (this.userData != null)
			{
				rewardDataModel = (this.userData as ChallengeDungeonRewardDataModel);
			}
			if (this.mChallengeDungeonRewardView != null)
			{
				this.mChallengeDungeonRewardView.InitRewardView(rewardDataModel);
			}
		}

		// Token: 0x0600CDF8 RID: 52728 RVA: 0x0032BDA1 File Offset: 0x0032A1A1
		protected override void _bindExUI()
		{
			this.mChallengeDungeonRewardView = this.mBind.GetCom<ChallengeDungeonRewardView>("ChallengeDungeonRewardView");
		}

		// Token: 0x0600CDF9 RID: 52729 RVA: 0x0032BDB9 File Offset: 0x0032A1B9
		protected override void _unbindExUI()
		{
			this.mChallengeDungeonRewardView = null;
		}

		// Token: 0x04007842 RID: 30786
		private ChallengeDungeonRewardView mChallengeDungeonRewardView;
	}
}
