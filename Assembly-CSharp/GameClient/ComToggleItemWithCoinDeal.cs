using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200157C RID: 5500
	public class ComToggleItemWithCoinDeal : ComToggleItem
	{
		// Token: 0x0600D6DA RID: 55002 RVA: 0x0035AE97 File Offset: 0x00359297
		protected override void ResetData()
		{
			base.ResetData();
			this._isShowRedPoint = false;
		}

		// Token: 0x0600D6DB RID: 55003 RVA: 0x0035AEA6 File Offset: 0x003592A6
		protected override void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveCoinDealUpdateRedPointMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealUpdateRedPointMessage));
		}

		// Token: 0x0600D6DC RID: 55004 RVA: 0x0035AEC3 File Offset: 0x003592C3
		protected override void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveCoinDealUpdateRedPointMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveCoinDealUpdateRedPointMessage));
		}

		// Token: 0x0600D6DD RID: 55005 RVA: 0x0035AEE0 File Offset: 0x003592E0
		public override void InitItem(ComControlData comToggleData, OnComToggleClick onComToggleClick = null)
		{
			base.InitItem(comToggleData, onComToggleClick);
			ComControlDataWithCoinDeal comControlDataWithCoinDeal = comToggleData as ComControlDataWithCoinDeal;
			if (comControlDataWithCoinDeal != null)
			{
				this._isShowRedPoint = comControlDataWithCoinDeal.IsShowRedPoint;
			}
			this.UpdateRedPoint();
		}

		// Token: 0x0600D6DE RID: 55006 RVA: 0x0035AF14 File Offset: 0x00359314
		private void UpdateRedPoint()
		{
			if (!this._isShowRedPoint)
			{
				return;
			}
			if (this.redPoint == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.redPoint, DataManager<CoinDealDataManager>.GetInstance().IsCoinDealShowRedPoint);
		}

		// Token: 0x0600D6DF RID: 55007 RVA: 0x0035AF49 File Offset: 0x00359349
		private void OnReceiveCoinDealUpdateRedPointMessage(UIEvent uiEvent)
		{
			this.UpdateRedPoint();
		}

		// Token: 0x04007E2B RID: 32299
		private bool _isShowRedPoint;

		// Token: 0x04007E2C RID: 32300
		[SerializeField]
		private GameObject redPoint;
	}
}
