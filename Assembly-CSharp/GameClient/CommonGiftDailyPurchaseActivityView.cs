using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001884 RID: 6276
	public class CommonGiftDailyPurchaseActivityView : MonoBehaviour, IGiftPackActivityView
	{
		// Token: 0x0600F5C0 RID: 62912 RVA: 0x00424EC2 File Offset: 0x004232C2
		private void Awake()
		{
			this.InitUIListScription();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F5C1 RID: 62913 RVA: 0x00424EE5 File Offset: 0x004232E5
		private void OnDestroy()
		{
			this.Close();
			this.UnInitUIListScription();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F5C2 RID: 62914 RVA: 0x00424F10 File Offset: 0x00423310
		public void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mActivityTimer.SafeSetText(string.Format("{0}~{1}", Function.GetDateTimeHaveMonthToSecond((int)this.mModel.StartTime), Function.GetDateTimeHaveMonthToSecond((int)model.EndTime)));
		}

		// Token: 0x0600F5C3 RID: 62915 RVA: 0x00424F73 File Offset: 0x00423373
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			this.mModel = model;
			this.OnSetElementAmount(this.mModel);
		}

		// Token: 0x0600F5C4 RID: 62916 RVA: 0x00424F88 File Offset: 0x00423388
		public void Close()
		{
			this.mOnItemClick = null;
		}

		// Token: 0x0600F5C5 RID: 62917 RVA: 0x00424F94 File Offset: 0x00423394
		private void InitUIListScription()
		{
			if (this.mItemUIListScript != null)
			{
				this.mItemUIListScript.Initialize();
				ComUIListScript comUIListScript = this.mItemUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mItemUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600F5C6 RID: 62918 RVA: 0x0042500C File Offset: 0x0042340C
		private void UnInitUIListScription()
		{
			if (this.mItemUIListScript != null)
			{
				ComUIListScript comUIListScript = this.mItemUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mItemUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600F5C7 RID: 62919 RVA: 0x00425078 File Offset: 0x00423478
		private CommonGiftDailyPurchaseActivityItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<CommonGiftDailyPurchaseActivityItem>();
		}

		// Token: 0x0600F5C8 RID: 62920 RVA: 0x00425080 File Offset: 0x00423480
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			CommonGiftDailyPurchaseActivityItem commonGiftDailyPurchaseActivityItem = item.gameObjectBindScript as CommonGiftDailyPurchaseActivityItem;
			if (commonGiftDailyPurchaseActivityItem != null && item.m_index >= 0 && item.m_index < this.mModel.DetailDatas.Count)
			{
				commonGiftDailyPurchaseActivityItem.OnItemVisiable(this.mModel.DetailDatas[item.m_index], item.m_index, this.mOnItemClick);
			}
		}

		// Token: 0x0600F5C9 RID: 62921 RVA: 0x004250F4 File Offset: 0x004234F4
		private void OnSetElementAmount(LimitTimeGiftPackModel model)
		{
			if (this.mItemUIListScript != null)
			{
				this.mItemUIListScript.SetElementAmount(model.DetailDatas.Count);
			}
		}

		// Token: 0x0600F5CA RID: 62922 RVA: 0x00425120 File Offset: 0x00423520
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			bool flag = false;
			for (int i = 0; i < this.mModel.DetailDatas.Count; i++)
			{
				if (num == this.mModel.DetailDatas[i].Id)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				this.OnSetElementAmount(this.mModel);
			}
		}

		// Token: 0x040096BF RID: 38591
		[SerializeField]
		private Text mActivityTimer;

		// Token: 0x040096C0 RID: 38592
		[SerializeField]
		private ComUIListScript mItemUIListScript;

		// Token: 0x040096C1 RID: 38593
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040096C2 RID: 38594
		private LimitTimeGiftPackModel mModel;
	}
}
