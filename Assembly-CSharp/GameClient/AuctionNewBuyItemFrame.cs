using System;

namespace GameClient
{
	// Token: 0x02001467 RID: 5223
	internal class AuctionNewBuyItemFrame : ClientFrame
	{
		// Token: 0x0600CA72 RID: 51826 RVA: 0x00318D2D File Offset: 0x0031712D
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AuctionNew/AuctionNewBuyItemFrame";
		}

		// Token: 0x0600CA73 RID: 51827 RVA: 0x00318D34 File Offset: 0x00317134
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			AuctionNewBuyItemDataModel buyItemDataModel = this.userData as AuctionNewBuyItemDataModel;
			if (this.mAuctionNewBuyItemView != null)
			{
				this.mAuctionNewBuyItemView.Init(buyItemDataModel);
			}
		}

		// Token: 0x0600CA74 RID: 51828 RVA: 0x00318D70 File Offset: 0x00317170
		protected sealed override void _OnCloseFrame()
		{
		}

		// Token: 0x0600CA75 RID: 51829 RVA: 0x00318D72 File Offset: 0x00317172
		protected override void _bindExUI()
		{
			this.mAuctionNewBuyItemView = this.mBind.GetCom<AuctionNewBuyItemView>("AuctionNewBuyItemView");
		}

		// Token: 0x0600CA76 RID: 51830 RVA: 0x00318D8A File Offset: 0x0031718A
		protected override void _unbindExUI()
		{
			this.mAuctionNewBuyItemView = null;
		}

		// Token: 0x04007593 RID: 30099
		private AuctionNewBuyItemView mAuctionNewBuyItemView;
	}
}
