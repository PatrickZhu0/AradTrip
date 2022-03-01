using System;

namespace GameClient
{
	// Token: 0x02001588 RID: 5512
	public class CoinDealBuyRecordFrame : ClientFrame
	{
		// Token: 0x0600D7C3 RID: 55235 RVA: 0x0035EDAB File Offset: 0x0035D1AB
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CoinDeal/Deal/CoinDealBuyRecordFrame";
		}

		// Token: 0x0600D7C4 RID: 55236 RVA: 0x0035EDB2 File Offset: 0x0035D1B2
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mCoinDealBuyRecordView != null)
			{
				this.mCoinDealBuyRecordView.InitView();
			}
		}

		// Token: 0x0600D7C5 RID: 55237 RVA: 0x0035EDD6 File Offset: 0x0035D1D6
		protected override void _OnCloseFrame()
		{
			DataManager<CoinDealDataManager>.GetInstance().ResetCoinDealSubmitOrderDataModelWithBuy();
		}

		// Token: 0x0600D7C6 RID: 55238 RVA: 0x0035EDE2 File Offset: 0x0035D1E2
		protected override void _bindExUI()
		{
			this.mCoinDealBuyRecordView = this.mBind.GetCom<CoinDealBuyRecordView>("CoinDealBuyRecordView");
		}

		// Token: 0x0600D7C7 RID: 55239 RVA: 0x0035EDFA File Offset: 0x0035D1FA
		protected override void _unbindExUI()
		{
			this.mCoinDealBuyRecordView = null;
		}

		// Token: 0x04007EA3 RID: 32419
		private CoinDealBuyRecordView mCoinDealBuyRecordView;
	}
}
