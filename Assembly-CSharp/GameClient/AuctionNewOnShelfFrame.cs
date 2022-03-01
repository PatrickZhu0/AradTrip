using System;

namespace GameClient
{
	// Token: 0x0200148C RID: 5260
	internal class AuctionNewOnShelfFrame : ClientFrame
	{
		// Token: 0x0600CBE4 RID: 52196 RVA: 0x0031F6E0 File Offset: 0x0031DAE0
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AuctionNew/AuctionNewOnShelfFrame";
		}

		// Token: 0x0600CBE5 RID: 52197 RVA: 0x0031F6E8 File Offset: 0x0031DAE8
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			AuctionNewOnShelfItemData auctionNewOnShelfItemData = null;
			if (this.userData != null)
			{
				auctionNewOnShelfItemData = (this.userData as AuctionNewOnShelfItemData);
			}
			if (this.mAuctionNewOnShelfView != null)
			{
				this.mAuctionNewOnShelfView.InitView(auctionNewOnShelfItemData);
			}
		}

		// Token: 0x0600CBE6 RID: 52198 RVA: 0x0031F731 File Offset: 0x0031DB31
		protected sealed override void _OnCloseFrame()
		{
			DataManager<AuctionNewDataManager>.GetInstance().ResetAuctionNewOnShelfData();
		}

		// Token: 0x0600CBE7 RID: 52199 RVA: 0x0031F73D File Offset: 0x0031DB3D
		protected override void _bindExUI()
		{
			this.mAuctionNewOnShelfView = this.mBind.GetCom<AuctionNewOnShelfView>("AuctionNewOnShelfView");
		}

		// Token: 0x0600CBE8 RID: 52200 RVA: 0x0031F755 File Offset: 0x0031DB55
		protected override void _unbindExUI()
		{
			this.mAuctionNewOnShelfView = null;
		}

		// Token: 0x0400767A RID: 30330
		private AuctionNewOnShelfView mAuctionNewOnShelfView;
	}
}
