using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CBB RID: 7355
	public class TopUpPushView : MonoBehaviour
	{
		// Token: 0x060120B4 RID: 73908 RVA: 0x0054743C File Offset: 0x0054583C
		private void Awake()
		{
			this.InitItemUIListScript();
			if (this.mCloseBtn)
			{
				this.mCloseBtn.onClick.RemoveAllListeners();
				this.mCloseBtn.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<TopUpPushFrame>(null, false);
				});
			}
		}

		// Token: 0x060120B5 RID: 73909 RVA: 0x0054749C File Offset: 0x0054589C
		private void OnDestroy()
		{
			this.UnItemUIListScript();
			this.mTopUpPushDataModel = null;
			this.mOnBuyClick = null;
		}

		// Token: 0x060120B6 RID: 73910 RVA: 0x005474B4 File Offset: 0x005458B4
		public void InitView(TopUpPushDataModel topUpPushDataModel, OnBuyClick callBack)
		{
			if (topUpPushDataModel == null)
			{
				return;
			}
			this.mTopUpPushDataModel = topUpPushDataModel;
			this.mOnBuyClick = callBack;
			this.SetSimpleTimer();
			this.SetElementAmount(this.mTopUpPushDataModel.mItems.Count);
			this.mUpArrowGo.CustomActive(this.mTopUpPushDataModel.mItems.Count > 3);
		}

		// Token: 0x060120B7 RID: 73911 RVA: 0x00547510 File Offset: 0x00545910
		private void SetSimpleTimer()
		{
			int countdown = (int)(this.mTopUpPushDataModel.validTimesTamp - DataManager<TimeManager>.GetInstance().GetServerTime());
			if (this.mSimpleTimer)
			{
				this.mSimpleTimer.SetCountdown(countdown);
				this.mSimpleTimer.StartTimer();
			}
		}

		// Token: 0x060120B8 RID: 73912 RVA: 0x0054755B File Offset: 0x0054595B
		private void SetElementAmount(int Count)
		{
			this.mItemUIListScript.SetElementAmount(Count);
		}

		// Token: 0x060120B9 RID: 73913 RVA: 0x00547569 File Offset: 0x00545969
		public void RefreshItems(TopUpPushDataModel topUpPushDataModel)
		{
			this.mTopUpPushDataModel = topUpPushDataModel;
			this.SetElementAmount(this.mTopUpPushDataModel.mItems.Count);
		}

		// Token: 0x060120BA RID: 73914 RVA: 0x00547588 File Offset: 0x00545988
		private void InitItemUIListScript()
		{
			this.mItemUIListScript.Initialize();
			ComUIListScript comUIListScript = this.mItemUIListScript;
			comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
			ComUIListScript comUIListScript2 = this.mItemUIListScript;
			comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
		}

		// Token: 0x060120BB RID: 73915 RVA: 0x005475F0 File Offset: 0x005459F0
		private void UnItemUIListScript()
		{
			if (this.mItemUIListScript)
			{
				ComUIListScript comUIListScript = this.mItemUIListScript;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mItemUIListScript;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
				this.mItemUIListScript = null;
			}
		}

		// Token: 0x060120BC RID: 73916 RVA: 0x00547662 File Offset: 0x00545A62
		private TopUpPushItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<TopUpPushItem>();
		}

		// Token: 0x060120BD RID: 73917 RVA: 0x0054766C File Offset: 0x00545A6C
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			TopUpPushItem topUpPushItem = item.gameObjectBindScript as TopUpPushItem;
			if (topUpPushItem != null && item.m_index >= 0 && item.m_index < this.mTopUpPushDataModel.mItems.Count)
			{
				topUpPushItem.OnItemVisiable(this.mTopUpPushDataModel.mItems[item.m_index], this.mOnBuyClick);
			}
		}

		// Token: 0x0400BC26 RID: 48166
		[SerializeField]
		private SimpleTimer mSimpleTimer;

		// Token: 0x0400BC27 RID: 48167
		[SerializeField]
		private Button mCloseBtn;

		// Token: 0x0400BC28 RID: 48168
		[SerializeField]
		private ComUIListScript mItemUIListScript;

		// Token: 0x0400BC29 RID: 48169
		[SerializeField]
		private GameObject mUpArrowGo;

		// Token: 0x0400BC2A RID: 48170
		private TopUpPushDataModel mTopUpPushDataModel;

		// Token: 0x0400BC2B RID: 48171
		private OnBuyClick mOnBuyClick;
	}
}
