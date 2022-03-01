using System;

namespace GameClient
{
	// Token: 0x0200149D RID: 5277
	public class AuctionNewSellRecordFrame : ClientFrame
	{
		// Token: 0x0600CC9F RID: 52383 RVA: 0x00324020 File Offset: 0x00322420
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/AuctionNew/AuctionNewSellRecordFrame";
		}

		// Token: 0x0600CCA0 RID: 52384 RVA: 0x00324027 File Offset: 0x00322427
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mAuctionNewSellRecordView != null)
			{
				this.mAuctionNewSellRecordView.InitView();
			}
		}

		// Token: 0x0600CCA1 RID: 52385 RVA: 0x0032404B File Offset: 0x0032244B
		protected override void _bindExUI()
		{
			this.mAuctionNewSellRecordView = this.mBind.GetCom<AuctionNewSellRecordView>("AuctionNewSellRecordView");
		}

		// Token: 0x0600CCA2 RID: 52386 RVA: 0x00324063 File Offset: 0x00322463
		protected override void _unbindExUI()
		{
			this.mAuctionNewSellRecordView = null;
		}

		// Token: 0x04007721 RID: 30497
		private AuctionNewSellRecordView mAuctionNewSellRecordView;
	}
}
