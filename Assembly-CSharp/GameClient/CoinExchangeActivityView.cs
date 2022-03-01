using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001882 RID: 6274
	public class CoinExchangeActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F5B1 RID: 62897 RVA: 0x00424AFC File Offset: 0x00422EFC
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			if (model == null)
			{
				return;
			}
			this.mModel = model;
			this.mTextCoinCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_fatigue_coin"), DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", model.Id, CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM))));
			this.mTextFatigueCost.SafeSetText(string.Format(TR.Value("activity_coin_exchange_fatigue_cost"), DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", model.Id, CounterKeys.COUNTER_ACTIVITY_FATIGUE_TICKET_NUM))));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F5B2 RID: 62898 RVA: 0x00424BC0 File Offset: 0x00422FC0
		public override void Dispose()
		{
			base.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F5B3 RID: 62899 RVA: 0x00424BE4 File Offset: 0x00422FE4
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mModel == null)
			{
				return;
			}
			this.mTextCoinCount.SafeSetText(string.Format(TR.Value("activity_coin_exchange_fatigue_coin"), DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", this.mModel.Id, CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM))));
			this.mTextFatigueCost.SafeSetText(string.Format(TR.Value("activity_coin_exchange_fatigue_cost"), DataManager<CountDataManager>.GetInstance().GetCount(string.Format("{0}{1}", this.mModel.Id, CounterKeys.COUNTER_ACTIVITY_FATIGUE_TICKET_NUM))));
		}

		// Token: 0x040096B8 RID: 38584
		[SerializeField]
		private Text mTextFatigueCost;

		// Token: 0x040096B9 RID: 38585
		[SerializeField]
		private Text mTextCoinCount;

		// Token: 0x040096BA RID: 38586
		private new ILimitTimeActivityModel mModel;
	}
}
