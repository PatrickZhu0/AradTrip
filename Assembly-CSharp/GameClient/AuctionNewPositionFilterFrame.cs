using System;

namespace GameClient
{
	// Token: 0x02001476 RID: 5238
	public class AuctionNewPositionFilterFrame : ClientFrame
	{
		// Token: 0x0600CB2E RID: 52014 RVA: 0x0031C867 File Offset: 0x0031AC67
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AuctionNew/AuctionNewPositionFilterFrame";
		}

		// Token: 0x0600CB2F RID: 52015 RVA: 0x0031C870 File Offset: 0x0031AC70
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			int filterType = (int)this.userData;
			if (this.mAuctionNewPositionFilterView != null)
			{
				this.mAuctionNewPositionFilterView.Init(filterType);
			}
		}

		// Token: 0x0600CB30 RID: 52016 RVA: 0x0031C8AC File Offset: 0x0031ACAC
		protected override void _bindExUI()
		{
			this.mAuctionNewPositionFilterView = this.mBind.GetCom<AuctionNewPositionFilterView>("AuctionNewPositionFilterView");
		}

		// Token: 0x0600CB31 RID: 52017 RVA: 0x0031C8C4 File Offset: 0x0031ACC4
		protected override void _unbindExUI()
		{
			this.mAuctionNewPositionFilterView = null;
		}

		// Token: 0x0400760A RID: 30218
		private AuctionNewPositionFilterView mAuctionNewPositionFilterView;
	}
}
