using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001883 RID: 6275
	public class CommonGiftAccountPurchaseActivityView : MonoBehaviour, IGiftPackActivityView
	{
		// Token: 0x0600F5B5 RID: 62901 RVA: 0x00424C95 File Offset: 0x00423095
		private void Awake()
		{
			this.InitUIListScription();
		}

		// Token: 0x0600F5B6 RID: 62902 RVA: 0x00424C9D File Offset: 0x0042309D
		private void OnDestroy()
		{
			this.Close();
			this.UnInitUIListScription();
		}

		// Token: 0x0600F5B7 RID: 62903 RVA: 0x00424CAC File Offset: 0x004230AC
		public void Init(LimitTimeGiftPackModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mOnItemClick = onItemClick;
			this.mActivityTimer.SafeSetText(string.Format("{0}~{1}", Function._TransTimeStampToStr(this.mModel.StartTime), Function._TransTimeStampToStr(model.EndTime)));
		}

		// Token: 0x0600F5B8 RID: 62904 RVA: 0x00424D0F File Offset: 0x0042310F
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			this.mModel = model;
			this.OnSetElementAmount(this.mModel);
		}

		// Token: 0x0600F5B9 RID: 62905 RVA: 0x00424D24 File Offset: 0x00423124
		public void Close()
		{
			this.mOnItemClick = null;
		}

		// Token: 0x0600F5BA RID: 62906 RVA: 0x00424D30 File Offset: 0x00423130
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

		// Token: 0x0600F5BB RID: 62907 RVA: 0x00424DA8 File Offset: 0x004231A8
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

		// Token: 0x0600F5BC RID: 62908 RVA: 0x00424E14 File Offset: 0x00423214
		private CommonGiftAccountPurchaseActivityItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<CommonGiftAccountPurchaseActivityItem>();
		}

		// Token: 0x0600F5BD RID: 62909 RVA: 0x00424E1C File Offset: 0x0042321C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			CommonGiftAccountPurchaseActivityItem commonGiftAccountPurchaseActivityItem = item.gameObjectBindScript as CommonGiftAccountPurchaseActivityItem;
			if (commonGiftAccountPurchaseActivityItem != null && item.m_index >= 0 && item.m_index < this.mModel.DetailDatas.Count)
			{
				commonGiftAccountPurchaseActivityItem.OnItemVisiable(this.mModel.DetailDatas[item.m_index], item.m_index, this.mOnItemClick);
			}
		}

		// Token: 0x0600F5BE RID: 62910 RVA: 0x00424E90 File Offset: 0x00423290
		private void OnSetElementAmount(LimitTimeGiftPackModel model)
		{
			if (this.mItemUIListScript != null)
			{
				this.mItemUIListScript.SetElementAmount(model.DetailDatas.Count);
			}
		}

		// Token: 0x040096BB RID: 38587
		[SerializeField]
		private Text mActivityTimer;

		// Token: 0x040096BC RID: 38588
		[SerializeField]
		private ComUIListScript mItemUIListScript;

		// Token: 0x040096BD RID: 38589
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040096BE RID: 38590
		private LimitTimeGiftPackModel mModel;
	}
}
