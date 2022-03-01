using System;

namespace GameClient
{
	// Token: 0x02000E0E RID: 3598
	public class AuctionNewMsgBoxOkCancelFrame : ClientFrame
	{
		// Token: 0x0600901D RID: 36893 RVA: 0x001AA58A File Offset: 0x001A898A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/AuctionNewMsgBoxOkCancelFrame";
		}

		// Token: 0x0600901E RID: 36894 RVA: 0x001AA594 File Offset: 0x001A8994
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			CommonMsgBoxOkCancelNewParamData paramData = this.userData as CommonMsgBoxOkCancelNewParamData;
			if (this.mAuctionNewMsgBoxOkCancelView != null)
			{
				this.mAuctionNewMsgBoxOkCancelView.InitData(paramData);
			}
		}

		// Token: 0x0600901F RID: 36895 RVA: 0x001AA5D0 File Offset: 0x001A89D0
		protected override void _bindExUI()
		{
			this.mAuctionNewMsgBoxOkCancelView = this.mBind.GetCom<AuctionNewMsgBoxOkCancelView>("AuctionNewMsgBoxOkCancelView");
		}

		// Token: 0x06009020 RID: 36896 RVA: 0x001AA5E8 File Offset: 0x001A89E8
		protected override void _unbindExUI()
		{
			this.mAuctionNewMsgBoxOkCancelView = null;
		}

		// Token: 0x0400479B RID: 18331
		private AuctionNewMsgBoxOkCancelView mAuctionNewMsgBoxOkCancelView;
	}
}
