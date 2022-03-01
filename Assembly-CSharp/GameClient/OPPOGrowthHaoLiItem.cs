using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013A2 RID: 5026
	public class OPPOGrowthHaoLiItem : MonoBehaviour
	{
		// Token: 0x0600C329 RID: 49961 RVA: 0x002E963C File Offset: 0x002E7A3C
		private void Awake()
		{
			if (this.mRewardItemUIList != null)
			{
				this.mRewardItemUIList.Initialize();
				ComUIListScript comUIListScript = this.mRewardItemUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mRewardItemUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
		}

		// Token: 0x0600C32A RID: 49962 RVA: 0x002E96B4 File Offset: 0x002E7AB4
		public void OnItemVisiable(ActiveManager.ActivityData activityData, OnOPPOGrowthHaoLiItemClick onOPPOGrowthHaoLiItemClick)
		{
			if (activityData == null)
			{
				return;
			}
			this.mOnOPPOGrowthHaoLiItemClick = onOPPOGrowthHaoLiItemClick;
			if (this.mReceiveCondition != null)
			{
				this.mReceiveCondition.text = activityData.activeItem.Desc;
			}
			this.SetSlider(activityData);
			this.CreatRewardItem(activityData);
			this.UpdateStatus(activityData);
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(delegate()
				{
					if (this.mOnOPPOGrowthHaoLiItemClick != null)
					{
						this.mOnOPPOGrowthHaoLiItemClick(activityData.ID);
					}
				});
			}
		}

		// Token: 0x0600C32B RID: 49963 RVA: 0x002E9778 File Offset: 0x002E7B78
		private void SetSlider(ActiveManager.ActivityData activityData)
		{
			if (activityData == null)
			{
				return;
			}
			int num = 0;
			for (int i = 0; i < activityData.akActivityValues.Count; i++)
			{
				if (activityData.akActivityValues[i].key == "num")
				{
					int.TryParse(activityData.akActivityValues[i].value, out num);
				}
			}
			if (this.mSlider != null)
			{
				this.mSlider.value = Mathf.Clamp01((float)num * 1f / (float)activityData.activeItem.Param1);
			}
			if (this.mSliderText != null)
			{
				this.mSliderText.text = string.Format("{0}/{1}", num, activityData.activeItem.Param1);
			}
		}

		// Token: 0x0600C32C RID: 49964 RVA: 0x002E9858 File Offset: 0x002E7C58
		private void CreatRewardItem(ActiveManager.ActivityData activityData)
		{
			if (activityData == null)
			{
				return;
			}
			this.mRewardItemList = DataManager<ActiveManager>.GetInstance().GetActiveAwards(activityData.ID);
			if (this.mRewardItemUIList != null)
			{
				this.mRewardItemUIList.SetElementAmount(this.mRewardItemList.Count);
			}
		}

		// Token: 0x0600C32D RID: 49965 RVA: 0x002E98AC File Offset: 0x002E7CAC
		private void UpdateStatus(ActiveManager.ActivityData activityData)
		{
			if (activityData == null)
			{
				return;
			}
			if (activityData.status == 1 || activityData.status == 0)
			{
				this.SetReceiveGray(true);
				this.SetReceiveBtn(true);
				this.SetReceivedRoot(false);
			}
			else if (activityData.status == 2)
			{
				this.SetReceiveGray(false);
				this.SetReceiveBtn(true);
				this.SetReceivedRoot(false);
			}
			else if (activityData.status == 5 || activityData.status == 4)
			{
				this.SetReceiveBtn(false);
				this.SetReceivedRoot(true);
			}
		}

		// Token: 0x0600C32E RID: 49966 RVA: 0x002E993D File Offset: 0x002E7D3D
		private void SetReceiveGray(bool isFlag)
		{
			if (this.mReceiveGray != null)
			{
				this.mReceiveGray.enabled = isFlag;
			}
		}

		// Token: 0x0600C32F RID: 49967 RVA: 0x002E995C File Offset: 0x002E7D5C
		private void SetReceiveBtn(bool isFlag)
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.gameObject.CustomActive(isFlag);
			}
		}

		// Token: 0x0600C330 RID: 49968 RVA: 0x002E9980 File Offset: 0x002E7D80
		private void SetReceivedRoot(bool isFlag)
		{
			if (this.mReceivedRoot != null)
			{
				this.mReceivedRoot.CustomActive(isFlag);
			}
		}

		// Token: 0x0600C331 RID: 49969 RVA: 0x002E999F File Offset: 0x002E7D9F
		private OPPOGrowthHaoLiRewardItem OnBindItemDelegate(GameObject itemObject)
		{
			return itemObject.GetComponent<OPPOGrowthHaoLiRewardItem>();
		}

		// Token: 0x0600C332 RID: 49970 RVA: 0x002E99A8 File Offset: 0x002E7DA8
		private void OnItemVisiableDelegate(ComUIListElementScript item)
		{
			OPPOGrowthHaoLiRewardItem oppogrowthHaoLiRewardItem = item.gameObjectBindScript as OPPOGrowthHaoLiRewardItem;
			if (oppogrowthHaoLiRewardItem != null && item.m_index >= 0 && item.m_index < this.mRewardItemList.Count)
			{
				oppogrowthHaoLiRewardItem.OnItemVisiable(this.mRewardItemList[item.m_index]);
			}
		}

		// Token: 0x0600C333 RID: 49971 RVA: 0x002E9A08 File Offset: 0x002E7E08
		private void OnDestroy()
		{
			if (this.mRewardItemUIList != null)
			{
				ComUIListScript comUIListScript = this.mRewardItemUIList;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this.OnBindItemDelegate));
				ComUIListScript comUIListScript2 = this.mRewardItemUIList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisiableDelegate));
			}
			this.mOnOPPOGrowthHaoLiItemClick = null;
			this.mRewardItemList.Clear();
		}

		// Token: 0x04006E7E RID: 28286
		[SerializeField]
		private ComUIListScript mRewardItemUIList;

		// Token: 0x04006E7F RID: 28287
		[SerializeField]
		private Text mReceiveCondition;

		// Token: 0x04006E80 RID: 28288
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04006E81 RID: 28289
		[SerializeField]
		private UIGray mReceiveGray;

		// Token: 0x04006E82 RID: 28290
		[SerializeField]
		private GameObject mReceivedRoot;

		// Token: 0x04006E83 RID: 28291
		[SerializeField]
		private Slider mSlider;

		// Token: 0x04006E84 RID: 28292
		[SerializeField]
		private Text mSliderText;

		// Token: 0x04006E85 RID: 28293
		private OnOPPOGrowthHaoLiItemClick mOnOPPOGrowthHaoLiItemClick;

		// Token: 0x04006E86 RID: 28294
		private List<AwardItemData> mRewardItemList = new List<AwardItemData>();
	}
}
