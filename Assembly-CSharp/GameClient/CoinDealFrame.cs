using System;

namespace GameClient
{
	// Token: 0x02001577 RID: 5495
	public class CoinDealFrame : ClientFrame
	{
		// Token: 0x0600D6A8 RID: 54952 RVA: 0x0035A04A File Offset: 0x0035844A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CoinDeal/CoinDealFrame";
		}

		// Token: 0x0600D6A9 RID: 54953 RVA: 0x0035A051 File Offset: 0x00358451
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mCoinDealView != null)
			{
				this.mCoinDealView.InitView();
			}
		}

		// Token: 0x0600D6AA RID: 54954 RVA: 0x0035A075 File Offset: 0x00358475
		protected override void _OnCloseFrame()
		{
			DataManager<CoinDealDataManager>.GetInstance().ResetCoinDealDataModel();
			DataManager<CoinDealDataManager>.GetInstance().ResetCoinDealOrderPageRefreshTimeInterval();
		}

		// Token: 0x0600D6AB RID: 54955 RVA: 0x0035A08B File Offset: 0x0035848B
		protected override void _bindExUI()
		{
			this.mCoinDealView = this.mBind.GetCom<CoinDealView>("CoinDealView");
		}

		// Token: 0x0600D6AC RID: 54956 RVA: 0x0035A0A3 File Offset: 0x003584A3
		protected override void _unbindExUI()
		{
			this.mCoinDealView = null;
		}

		// Token: 0x04007DFD RID: 32253
		private CoinDealView mCoinDealView;
	}
}
