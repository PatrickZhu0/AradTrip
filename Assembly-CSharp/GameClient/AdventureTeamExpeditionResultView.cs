using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001417 RID: 5143
	public class AdventureTeamExpeditionResultView : MonoBehaviour
	{
		// Token: 0x0600C75D RID: 51037 RVA: 0x003035AF File Offset: 0x003019AF
		private void Awake()
		{
			this._InitView();
		}

		// Token: 0x0600C75E RID: 51038 RVA: 0x003035B7 File Offset: 0x003019B7
		private void OnDestroy()
		{
			if (this.mFinishMapModels != null)
			{
				this.mFinishMapModels.Clear();
			}
			this._ClearView();
		}

		// Token: 0x0600C75F RID: 51039 RVA: 0x003035D8 File Offset: 0x003019D8
		private void _InitView()
		{
			if (this.resultItemView != null)
			{
				if (!this.resultItemView.IsInitialised())
				{
					this.resultItemView.Initialize();
				}
				ComUIListScript comUIListScript = this.resultItemView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnResultItemBind));
				ComUIListScript comUIListScript2 = this.resultItemView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnResultItemVisiable));
				ComUIListScript comUIListScript3 = this.resultItemView;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnResultItemRecycle));
			}
		}

		// Token: 0x0600C760 RID: 51040 RVA: 0x00303688 File Offset: 0x00301A88
		private void _ClearView()
		{
			if (this.resultItemView != null)
			{
				ComUIListScript comUIListScript = this.resultItemView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnResultItemBind));
				ComUIListScript comUIListScript2 = this.resultItemView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnResultItemVisiable));
				ComUIListScript comUIListScript3 = this.resultItemView;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnResultItemRecycle));
				this.resultItemView.UnInitialize();
			}
		}

		// Token: 0x0600C761 RID: 51041 RVA: 0x00303726 File Offset: 0x00301B26
		private AdventureTeamExpeditionResultItem _OnResultItemBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<AdventureTeamExpeditionResultItem>();
		}

		// Token: 0x0600C762 RID: 51042 RVA: 0x0030373C File Offset: 0x00301B3C
		private void _OnResultItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.mFinishMapModels == null || this.mFinishMapModels.Count <= 0)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this.mFinishMapModels.Count)
			{
				return;
			}
			AdventureTeamExpeditionResultItem adventureTeamExpeditionResultItem = item.gameObjectBindScript as AdventureTeamExpeditionResultItem;
			if (adventureTeamExpeditionResultItem != null)
			{
				adventureTeamExpeditionResultItem.RefreshView(this.mFinishMapModels[index]);
			}
		}

		// Token: 0x0600C763 RID: 51043 RVA: 0x003037C0 File Offset: 0x00301BC0
		private void _OnResultItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionResultItem adventureTeamExpeditionResultItem = item.gameObjectBindScript as AdventureTeamExpeditionResultItem;
			if (adventureTeamExpeditionResultItem != null)
			{
				adventureTeamExpeditionResultItem.ClearView();
			}
		}

		// Token: 0x0600C764 RID: 51044 RVA: 0x003037F8 File Offset: 0x00301BF8
		private void _SetResultDescText(string mapCount)
		{
			this.resultDescText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_res", mapCount.ToString()));
		}

		// Token: 0x0600C765 RID: 51045 RVA: 0x00303815 File Offset: 0x00301C15
		private void _SetRewardItemIcon(string imgPath)
		{
			this.resultRewardItemIcon.SafeSetImage(imgPath, false);
		}

		// Token: 0x0600C766 RID: 51046 RVA: 0x00303824 File Offset: 0x00301C24
		private void _SetRewardItemCount(string itemCount)
		{
			this.resultRewardItemCountDescText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_reward_count", itemCount));
		}

		// Token: 0x0600C767 RID: 51047 RVA: 0x0030383C File Offset: 0x00301C3C
		public void InitView(List<ExpeditionMapModel> finishMapModels)
		{
			if (finishMapModels == null || finishMapModels.Count <= 0)
			{
				return;
			}
			this.mFinishMapModels = finishMapModels;
			this._SetResultDescText(finishMapModels.Count.ToString());
			this._SetRewardItemCount(DataManager<AdventureTeamDataManager>.GetInstance().GetExpeditionRewardItemTotalCount(finishMapModels, new Action<string>(this._SetRewardItemIcon)).ToString());
			if (this.resultItemView != null)
			{
				this.resultItemView.SetElementAmount(finishMapModels.Count);
			}
		}

		// Token: 0x0600C768 RID: 51048 RVA: 0x003038CA File Offset: 0x00301CCA
		public void RefreshView()
		{
		}

		// Token: 0x04007274 RID: 29300
		private List<ExpeditionMapModel> mFinishMapModels;

		// Token: 0x04007275 RID: 29301
		[SerializeField]
		private ComUIListScript resultItemView;

		// Token: 0x04007276 RID: 29302
		[SerializeField]
		private Text resultDescText;

		// Token: 0x04007277 RID: 29303
		[SerializeField]
		private Image resultRewardItemIcon;

		// Token: 0x04007278 RID: 29304
		[SerializeField]
		private Text resultRewardItemCountDescText;
	}
}
