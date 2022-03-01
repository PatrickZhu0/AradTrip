using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200188E RID: 6286
	public sealed class FashionSyntheticActivityView : MonoBehaviour, IDisposable, IGiftPackActivityView
	{
		// Token: 0x0600F5F7 RID: 62967 RVA: 0x00425BB0 File Offset: 0x00423FB0
		private void Awake()
		{
			this.InitUIListScription();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F5F8 RID: 62968 RVA: 0x00425BD3 File Offset: 0x00423FD3
		private void OnDestroy()
		{
			this.UnInitUIListScription();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F5F9 RID: 62969 RVA: 0x00425BF8 File Offset: 0x00423FF8
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

		// Token: 0x0600F5FA RID: 62970 RVA: 0x00425C70 File Offset: 0x00424070
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

		// Token: 0x0600F5FB RID: 62971 RVA: 0x00425CDC File Offset: 0x004240DC
		private FashionSyntheticActivityItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<FashionSyntheticActivityItem>();
		}

		// Token: 0x0600F5FC RID: 62972 RVA: 0x00425CE4 File Offset: 0x004240E4
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			FashionSyntheticActivityItem fashionSyntheticActivityItem = item.gameObjectBindScript as FashionSyntheticActivityItem;
			if (fashionSyntheticActivityItem != null && item.m_index >= 0 && item.m_index < this.mModel.DetailDatas.Count)
			{
				fashionSyntheticActivityItem.OnItemVisiable(this.mModel.DetailDatas[item.m_index], item.m_index, this.mOnItemClick);
			}
		}

		// Token: 0x0600F5FD RID: 62973 RVA: 0x00425D58 File Offset: 0x00424158
		private void OnSetElementAmount(LimitTimeGiftPackModel model)
		{
			if (this.mItemUIListScript != null)
			{
				this.mItemUIListScript.SetElementAmount(model.DetailDatas.Count);
			}
		}

		// Token: 0x0600F5FE RID: 62974 RVA: 0x00425D84 File Offset: 0x00424184
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
			this.mBtnGo.SafeRemoveAllListener();
			this.mBtnGo.SafeAddOnClickListener(new UnityAction(this.OnGoBtnClick));
			this.OnSetElementAmount(this.mModel);
		}

		// Token: 0x0600F5FF RID: 62975 RVA: 0x00425E18 File Offset: 0x00424218
		private void OnGoBtnClick()
		{
			FashionMergeNewFrame.OpenLinkFrame(string.Format("1|0|{0}|{1}|{2}", (int)DataManager<FashionMergeManager>.GetInstance().FashionType, (int)DataManager<FashionMergeManager>.GetInstance().FashionPart, 0));
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LimitTimeActivityFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
			}
		}

		// Token: 0x0600F600 RID: 62976 RVA: 0x00425E74 File Offset: 0x00424274
		public void UpdateData(LimitTimeGiftPackModel model)
		{
			this.mModel = model;
			this.OnSetElementAmount(this.mModel);
		}

		// Token: 0x0600F601 RID: 62977 RVA: 0x00425E8C File Offset: 0x0042428C
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

		// Token: 0x0600F602 RID: 62978 RVA: 0x00425F23 File Offset: 0x00424323
		public void Dispose()
		{
			this.mOnItemClick = null;
		}

		// Token: 0x0600F603 RID: 62979 RVA: 0x00425F2C File Offset: 0x0042432C
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x040096D8 RID: 38616
		[SerializeField]
		private Text mActivityTimer;

		// Token: 0x040096D9 RID: 38617
		[SerializeField]
		private ComUIListScript mItemUIListScript;

		// Token: 0x040096DA RID: 38618
		[SerializeField]
		private Button mBtnGo;

		// Token: 0x040096DB RID: 38619
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x040096DC RID: 38620
		private LimitTimeGiftPackModel mModel;
	}
}
