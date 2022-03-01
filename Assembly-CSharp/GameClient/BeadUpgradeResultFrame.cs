using System;

namespace GameClient
{
	// Token: 0x02001AD1 RID: 6865
	internal class BeadUpgradeResultFrame : ClientFrame
	{
		// Token: 0x06010D9C RID: 69020 RVA: 0x004CE275 File Offset: 0x004CC675
		protected sealed override void _bindExUI()
		{
			this.mBeadUpgradeResultView = this.mBind.GetCom<BeadUpgradeResultView>("BeadUpgradeResultView");
		}

		// Token: 0x06010D9D RID: 69021 RVA: 0x004CE28D File Offset: 0x004CC68D
		protected sealed override void _unbindExUI()
		{
			this.mBeadUpgradeResultView = null;
		}

		// Token: 0x06010D9E RID: 69022 RVA: 0x004CE296 File Offset: 0x004CC696
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SmithShop/BeadUpgradeResultFrame/BeadUpgradeResultFrame";
		}

		// Token: 0x06010D9F RID: 69023 RVA: 0x004CE29D File Offset: 0x004CC69D
		protected sealed override void _OnOpenFrame()
		{
			this.mData = (BeadUpgradeResultData)this.userData;
			if (this.mData != null)
			{
				this.mBeadUpgradeResultView.InitView(this, this.mData);
			}
		}

		// Token: 0x06010DA0 RID: 69024 RVA: 0x004CE2CD File Offset: 0x004CC6CD
		protected sealed override void _OnCloseFrame()
		{
			this.mData = null;
		}

		// Token: 0x0400ACE8 RID: 44264
		private BeadUpgradeResultView mBeadUpgradeResultView;

		// Token: 0x0400ACE9 RID: 44265
		private BeadUpgradeResultData mData;
	}
}
