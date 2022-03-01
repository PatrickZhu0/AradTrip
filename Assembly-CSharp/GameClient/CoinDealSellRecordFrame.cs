using System;

namespace GameClient
{
	// Token: 0x0200158A RID: 5514
	public class CoinDealSellRecordFrame : ClientFrame
	{
		// Token: 0x0600D7D4 RID: 55252 RVA: 0x0035F08F File Offset: 0x0035D48F
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CoinDeal/Deal/CoinDealSellRecordFrame";
		}

		// Token: 0x0600D7D5 RID: 55253 RVA: 0x0035F096 File Offset: 0x0035D496
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mCoinDealSellRecordView != null)
			{
				this.mCoinDealSellRecordView.InitView();
			}
		}

		// Token: 0x0600D7D6 RID: 55254 RVA: 0x0035F0BA File Offset: 0x0035D4BA
		protected override void _OnCloseFrame()
		{
			DataManager<CoinDealDataManager>.GetInstance().ResetCoinDealSubmitOrderDataModelWithSell();
		}

		// Token: 0x0600D7D7 RID: 55255 RVA: 0x0035F0C6 File Offset: 0x0035D4C6
		protected override void _bindExUI()
		{
			this.mCoinDealSellRecordView = this.mBind.GetCom<CoinDealSellRecordView>("CoinDealSellRecordView");
		}

		// Token: 0x0600D7D8 RID: 55256 RVA: 0x0035F0DE File Offset: 0x0035D4DE
		protected override void _unbindExUI()
		{
			this.mCoinDealSellRecordView = null;
		}

		// Token: 0x04007EAE RID: 32430
		private CoinDealSellRecordView mCoinDealSellRecordView;
	}
}
