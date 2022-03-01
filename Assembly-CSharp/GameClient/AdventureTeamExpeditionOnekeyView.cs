using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001414 RID: 5140
	public class AdventureTeamExpeditionOnekeyView : MonoBehaviour
	{
		// Token: 0x0600C737 RID: 50999 RVA: 0x00302832 File Offset: 0x00300C32
		private void Awake()
		{
			this._InitView();
		}

		// Token: 0x0600C738 RID: 51000 RVA: 0x0030283A File Offset: 0x00300C3A
		private void OnDestroy()
		{
			this._ClearView();
		}

		// Token: 0x0600C739 RID: 51001 RVA: 0x00302844 File Offset: 0x00300C44
		private void _InitView()
		{
			if (this.mapInfoView != null)
			{
				if (!this.mapInfoView.IsInitialised())
				{
					this.mapInfoView.Initialize();
				}
				ComUIListScript comUIListScript = this.mapInfoView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnMapItemBind));
				ComUIListScript comUIListScript2 = this.mapInfoView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnMapItemVisiable));
				ComUIListScript comUIListScript3 = this.mapInfoView;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnMapItemUpdate));
				ComUIListScript comUIListScript4 = this.mapInfoView;
				comUIListScript4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnMapItemRecycle));
			}
			if (this.mapTimeToggleView != null)
			{
				if (!this.mapTimeToggleView.IsInitialised())
				{
					this.mapTimeToggleView.Initialize();
				}
				ComUIListScript comUIListScript5 = this.mapTimeToggleView;
				comUIListScript5.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript5.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnMapTimeToggleBind));
				ComUIListScript comUIListScript6 = this.mapTimeToggleView;
				comUIListScript6.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript6.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnMapTimeToggleVisiable));
				ComUIListScript comUIListScript7 = this.mapTimeToggleView;
				comUIListScript7.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript7.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnMapTimeToggleRecycle));
			}
		}

		// Token: 0x0600C73A RID: 51002 RVA: 0x003029BC File Offset: 0x00300DBC
		private void _ClearView()
		{
			if (this.mapInfoView != null)
			{
				ComUIListScript comUIListScript = this.mapInfoView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnMapItemBind));
				ComUIListScript comUIListScript2 = this.mapInfoView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnMapItemVisiable));
				ComUIListScript comUIListScript3 = this.mapInfoView;
				comUIListScript3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnMapItemUpdate));
				ComUIListScript comUIListScript4 = this.mapInfoView;
				comUIListScript4.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript4.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnMapItemRecycle));
				this.mapInfoView.UnInitialize();
			}
			if (this.mapTimeToggleView != null)
			{
				ComUIListScript comUIListScript5 = this.mapTimeToggleView;
				comUIListScript5.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript5.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnMapTimeToggleBind));
				ComUIListScript comUIListScript6 = this.mapTimeToggleView;
				comUIListScript6.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript6.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnMapTimeToggleVisiable));
				ComUIListScript comUIListScript7 = this.mapTimeToggleView;
				comUIListScript7.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript7.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnMapTimeToggleRecycle));
				this.mapTimeToggleView.UnInitialize();
			}
			if (this.mReadyMapModels != null)
			{
				this.mReadyMapModels.Clear();
			}
			if (this.mReadyMapTimeList != null)
			{
				this.mReadyMapTimeList.Clear();
			}
		}

		// Token: 0x0600C73B RID: 51003 RVA: 0x00302B3E File Offset: 0x00300F3E
		private AdventureTeamExpeditionOnekeyItem _OnMapItemBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<AdventureTeamExpeditionOnekeyItem>();
		}

		// Token: 0x0600C73C RID: 51004 RVA: 0x00302B54 File Offset: 0x00300F54
		private void _OnMapItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.mReadyMapModels == null || this.mReadyMapModels.Count <= 0)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this.mReadyMapModels.Count)
			{
				return;
			}
			AdventureTeamExpeditionOnekeyItem adventureTeamExpeditionOnekeyItem = item.gameObjectBindScript as AdventureTeamExpeditionOnekeyItem;
			if (adventureTeamExpeditionOnekeyItem != null)
			{
				adventureTeamExpeditionOnekeyItem.RefreshView(this.mReadyMapModels[index]);
			}
		}

		// Token: 0x0600C73D RID: 51005 RVA: 0x00302BD8 File Offset: 0x00300FD8
		private void _OnMapItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionOnekeyItem adventureTeamExpeditionOnekeyItem = item.gameObjectBindScript as AdventureTeamExpeditionOnekeyItem;
			if (adventureTeamExpeditionOnekeyItem != null)
			{
				adventureTeamExpeditionOnekeyItem.RefreshView();
			}
		}

		// Token: 0x0600C73E RID: 51006 RVA: 0x00302C10 File Offset: 0x00301010
		private void _OnMapItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionOnekeyItem adventureTeamExpeditionOnekeyItem = item.gameObjectBindScript as AdventureTeamExpeditionOnekeyItem;
			if (adventureTeamExpeditionOnekeyItem != null)
			{
				adventureTeamExpeditionOnekeyItem.ClearView();
			}
		}

		// Token: 0x0600C73F RID: 51007 RVA: 0x00302C48 File Offset: 0x00301048
		private AdventureTeamExpeditionTimeToggle _OnMapTimeToggleBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<AdventureTeamExpeditionTimeToggle>();
		}

		// Token: 0x0600C740 RID: 51008 RVA: 0x00302C60 File Offset: 0x00301060
		private void _OnMapTimeToggleVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.mReadyMapTimeList == null || this.mReadyMapTimeList.Count <= 0)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this.mReadyMapTimeList.Count)
			{
				return;
			}
			AdventureTeamExpeditionTimeToggle adventureTeamExpeditionTimeToggle = item.gameObjectBindScript as AdventureTeamExpeditionTimeToggle;
			if (adventureTeamExpeditionTimeToggle != null)
			{
				adventureTeamExpeditionTimeToggle.InitItemView(this.mReadyMapTimeList[index], true, true);
				if ((uint)this.mReadyMapTimeList[index] == this.mLastMaxLevelMapModelDurationTime)
				{
					adventureTeamExpeditionTimeToggle.ChangeToggleState(true);
				}
				else
				{
					adventureTeamExpeditionTimeToggle.ChangeToggleState(false);
				}
				adventureTeamExpeditionTimeToggle.UpdateItemInfo();
			}
		}

		// Token: 0x0600C741 RID: 51009 RVA: 0x00302D14 File Offset: 0x00301114
		private void _OnMapTimeToggleRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionTimeToggle adventureTeamExpeditionTimeToggle = item.gameObjectBindScript as AdventureTeamExpeditionTimeToggle;
			if (adventureTeamExpeditionTimeToggle != null)
			{
				adventureTeamExpeditionTimeToggle.OnItemRecycle();
			}
		}

		// Token: 0x0600C742 RID: 51010 RVA: 0x00302D4C File Offset: 0x0030114C
		private void _SetResultDescText(string mapCount)
		{
			this.resultDescText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_ready", mapCount.ToString()));
		}

		// Token: 0x0600C743 RID: 51011 RVA: 0x00302D69 File Offset: 0x00301169
		private void _SetRewardItemIcon(string imgPath)
		{
			this.resultRewardItemIcon.SafeSetImage(imgPath, false);
		}

		// Token: 0x0600C744 RID: 51012 RVA: 0x00302D78 File Offset: 0x00301178
		private void _SetRewardItemCount(string itemCount)
		{
			this.resultRewardItemCountDescText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_reward_count", itemCount));
		}

		// Token: 0x0600C745 RID: 51013 RVA: 0x00302D90 File Offset: 0x00301190
		private void _SetRewardInfo(bool bSetItemIcon)
		{
			if (this.mReadyMapModels == null || this.mReadyMapModels.Count <= 0)
			{
				return;
			}
			int expeditionRewardItemTotalCount;
			if (bSetItemIcon)
			{
				expeditionRewardItemTotalCount = DataManager<AdventureTeamDataManager>.GetInstance().GetExpeditionRewardItemTotalCount(this.mReadyMapModels, new Action<string>(this._SetRewardItemIcon));
			}
			else
			{
				expeditionRewardItemTotalCount = DataManager<AdventureTeamDataManager>.GetInstance().GetExpeditionRewardItemTotalCount(this.mReadyMapModels, null);
			}
			this._SetRewardItemCount(expeditionRewardItemTotalCount.ToString());
		}

		// Token: 0x0600C746 RID: 51014 RVA: 0x00302E0C File Offset: 0x0030120C
		public void InitView(List<ExpeditionMapModel> readyMapModels)
		{
			if (readyMapModels == null || readyMapModels.Count <= 0)
			{
				return;
			}
			this.mReadyMapModels = readyMapModels;
			this.mReadyMapTimeList = DataManager<AdventureTeamDataManager>.GetInstance().GetExpeditionTimeList(readyMapModels[0]);
			this.mLastMaxLevelMapModelDurationTime = DataManager<AdventureTeamDataManager>.GetInstance().GetLastExpeditionMaxMapDurationTime(this.mReadyMapModels);
			this._SetResultDescText(readyMapModels.Count.ToString());
			this._SetRewardInfo(true);
			if (this.mapInfoView != null)
			{
				this.mapInfoView.SetElementAmount(readyMapModels.Count);
			}
			if (this.mapTimeToggleView != null && this.mReadyMapTimeList != null)
			{
				this.mapTimeToggleView.SetElementAmount(this.mReadyMapTimeList.Count);
			}
		}

		// Token: 0x0600C747 RID: 51015 RVA: 0x00302ED5 File Offset: 0x003012D5
		public void RefreshView()
		{
			if (this.mapInfoView != null)
			{
				this.mapInfoView.UpdateElement();
			}
			this._SetRewardInfo(false);
		}

		// Token: 0x0400725D RID: 29277
		private List<ExpeditionMapModel> mReadyMapModels;

		// Token: 0x0400725E RID: 29278
		private List<byte> mReadyMapTimeList;

		// Token: 0x0400725F RID: 29279
		private uint mLastMaxLevelMapModelDurationTime;

		// Token: 0x04007260 RID: 29280
		[SerializeField]
		private ComUIListScript mapInfoView;

		// Token: 0x04007261 RID: 29281
		[SerializeField]
		private ComUIListScript mapTimeToggleView;

		// Token: 0x04007262 RID: 29282
		[SerializeField]
		private ToggleGroup mapTimeToggleGroup;

		// Token: 0x04007263 RID: 29283
		[SerializeField]
		private Text resultDescText;

		// Token: 0x04007264 RID: 29284
		[SerializeField]
		private Image resultRewardItemIcon;

		// Token: 0x04007265 RID: 29285
		[SerializeField]
		private Text resultRewardItemCountDescText;
	}
}
