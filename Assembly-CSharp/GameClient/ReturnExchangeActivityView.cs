using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018AE RID: 6318
	public class ReturnExchangeActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F706 RID: 63238 RVA: 0x0042CD68 File Offset: 0x0042B168
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			if (model == null)
			{
				return;
			}
			this.mModel = model;
			this.mTextCoinCount.text = DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_ENERGY_COIN).ToString();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F707 RID: 63239 RVA: 0x0042CDCA File Offset: 0x0042B1CA
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F708 RID: 63240 RVA: 0x0042CDF0 File Offset: 0x0042B1F0
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mModel == null)
			{
				return;
			}
			this.mTextCoinCount.text = DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_COUNTER_ENERGY_COIN).ToString();
		}

		// Token: 0x040097E5 RID: 38885
		[SerializeField]
		private Text mTextFatigueCost;

		// Token: 0x040097E6 RID: 38886
		[SerializeField]
		private Text mTextCoinCount;

		// Token: 0x040097E7 RID: 38887
		private new ILimitTimeActivityModel mModel;
	}
}
