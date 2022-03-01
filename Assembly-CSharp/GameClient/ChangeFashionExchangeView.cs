using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200187E RID: 6270
	public class ChangeFashionExchangeView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F59A RID: 62874 RVA: 0x004241DC File Offset: 0x004225DC
		public void setGetScoreCallBack(ChangeFashionExchangeView.GetScoreCallBack callBack)
		{
			this.mGetScoreCallBack = callBack;
		}

		// Token: 0x0600F59B RID: 62875 RVA: 0x004241E8 File Offset: 0x004225E8
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			base.Init(model, onItemClick);
			if (model == null)
			{
				return;
			}
			this.mModel = model;
			string[] array = model.CountParam.Split(new char[]
			{
				'|'
			});
			if (array.Length != 2)
			{
				this.mTextFatigueCost.CustomActive(false);
				this.mTextCoinCount.CustomActive(false);
			}
			else
			{
				this.mTextFatigueCost.CustomActive(true);
				this.mTextCoinCount.CustomActive(true);
				this.countKey = array[0];
				this.countCostKey = array[1];
			}
			if (this.countKey != null && this.countCostKey != null)
			{
				this.mTextCoinCount.SafeSetText(string.Format(TR.Value("activity_change_fashion_count"), DataManager<CountDataManager>.GetInstance().GetCount(this.countKey)));
				this.mTextFatigueCost.SafeSetText(string.Format(TR.Value("activity_change_fashion_cost"), DataManager<CountDataManager>.GetInstance().GetCount(this.countCostKey)));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			this.mGetScoreBtn.SafeAddOnClickListener(delegate
			{
				if (this.mGetScoreCallBack != null)
				{
					this.mGetScoreCallBack(this.mItemTableId);
				}
			});
		}

		// Token: 0x0600F59C RID: 62876 RVA: 0x00424318 File Offset: 0x00422718
		public override void Dispose()
		{
			base.Dispose();
			this.mGetScoreBtn.SafeRemoveAllListener();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x0600F59D RID: 62877 RVA: 0x00424348 File Offset: 0x00422748
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (this.mModel == null)
			{
				return;
			}
			if (this.countKey != null && this.countCostKey != null)
			{
				this.mTextCoinCount.SafeSetText(string.Format(TR.Value("activity_change_fashion_count"), DataManager<CountDataManager>.GetInstance().GetCount(this.countKey)));
				this.mTextFatigueCost.SafeSetText(string.Format(TR.Value("activity_change_fashion_cost"), DataManager<CountDataManager>.GetInstance().GetCount(this.countCostKey)));
			}
		}

		// Token: 0x040096A7 RID: 38567
		[SerializeField]
		private Text mTextFatigueCost;

		// Token: 0x040096A8 RID: 38568
		[SerializeField]
		private Text mTextCoinCount;

		// Token: 0x040096A9 RID: 38569
		[SerializeField]
		private Button mGetScoreBtn;

		// Token: 0x040096AA RID: 38570
		[SerializeField]
		private int mItemTableId;

		// Token: 0x040096AB RID: 38571
		private new ILimitTimeActivityModel mModel;

		// Token: 0x040096AC RID: 38572
		private string countKey;

		// Token: 0x040096AD RID: 38573
		private string countCostKey;

		// Token: 0x040096AE RID: 38574
		private ChangeFashionExchangeView.GetScoreCallBack mGetScoreCallBack;

		// Token: 0x0200187F RID: 6271
		// (Invoke) Token: 0x0600F5A0 RID: 62880
		public delegate void GetScoreCallBack(int id);
	}
}
