using System;

namespace GameClient
{
	// Token: 0x0200158C RID: 5516
	public class CoinDealRecordDetailFrame : ClientFrame
	{
		// Token: 0x0600D7E5 RID: 55269 RVA: 0x0035F3D3 File Offset: 0x0035D7D3
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CoinDeal/Record/CoinDealRecordDetailFrame";
		}

		// Token: 0x0600D7E6 RID: 55270 RVA: 0x0035F3DA File Offset: 0x0035D7DA
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			if (this.mCoinDealRecordDetailView != null)
			{
				this.mCoinDealRecordDetailView.InitView();
			}
		}

		// Token: 0x0600D7E7 RID: 55271 RVA: 0x0035F3FE File Offset: 0x0035D7FE
		protected override void _OnCloseFrame()
		{
			DataManager<CoinDealDataManager>.GetInstance().ResetCoinDealRecordDetailDataModelList();
		}

		// Token: 0x0600D7E8 RID: 55272 RVA: 0x0035F40A File Offset: 0x0035D80A
		protected override void _bindExUI()
		{
			this.mCoinDealRecordDetailView = this.mBind.GetCom<CoinDealRecordDetailView>("CoinDealRecordDetailView");
		}

		// Token: 0x0600D7E9 RID: 55273 RVA: 0x0035F422 File Offset: 0x0035D822
		protected override void _unbindExUI()
		{
			this.mCoinDealRecordDetailView = null;
		}

		// Token: 0x04007EBB RID: 32443
		private CoinDealRecordDetailView mCoinDealRecordDetailView;
	}
}
