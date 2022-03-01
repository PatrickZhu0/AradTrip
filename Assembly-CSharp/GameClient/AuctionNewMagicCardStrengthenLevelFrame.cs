using System;

namespace GameClient
{
	// Token: 0x02001486 RID: 5254
	public class AuctionNewMagicCardStrengthenLevelFrame : ClientFrame
	{
		// Token: 0x0600CBBD RID: 52157 RVA: 0x0031EDE5 File Offset: 0x0031D1E5
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AuctionNew/AuctionNewMagicCardStrengthenLevelFrame";
		}

		// Token: 0x0600CBBE RID: 52158 RVA: 0x0031EDEC File Offset: 0x0031D1EC
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			AuctionNewMagicCardDataModel dataModel = null;
			if (this.userData != null)
			{
				dataModel = (this.userData as AuctionNewMagicCardDataModel);
			}
			if (this.mAuctionNewMagicCardStrengthenLevelView != null)
			{
				this.mAuctionNewMagicCardStrengthenLevelView.Init(dataModel);
			}
		}

		// Token: 0x0600CBBF RID: 52159 RVA: 0x0031EE35 File Offset: 0x0031D235
		protected override void _bindExUI()
		{
			this.mAuctionNewMagicCardStrengthenLevelView = this.mBind.GetCom<AuctionNewMagicCardStrengthenLevelView>("AuctionNewMagicCardStrengthenLevelView");
		}

		// Token: 0x0600CBC0 RID: 52160 RVA: 0x0031EE4D File Offset: 0x0031D24D
		protected override void _unbindExUI()
		{
			this.mAuctionNewMagicCardStrengthenLevelView = null;
		}

		// Token: 0x0400765F RID: 30303
		private AuctionNewMagicCardStrengthenLevelView mAuctionNewMagicCardStrengthenLevelView;
	}
}
