using System;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001412 RID: 5138
	public class AdventureTeamExpeditionOnekeyItem : MonoBehaviour
	{
		// Token: 0x0600C71A RID: 50970 RVA: 0x00301C04 File Offset: 0x00300004
		private void Awake()
		{
			this._InitView();
		}

		// Token: 0x0600C71B RID: 50971 RVA: 0x00301C0C File Offset: 0x0030000C
		private void OnDestroy()
		{
			this._ClearView();
		}

		// Token: 0x0600C71C RID: 50972 RVA: 0x00301C14 File Offset: 0x00300014
		private void _InitView()
		{
			if (this.roleInfoView != null)
			{
				if (!this.roleInfoView.IsInitialised())
				{
					this.roleInfoView.Initialize();
				}
				ComUIListScript comUIListScript = this.roleInfoView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnRoleInfoItemBind));
				ComUIListScript comUIListScript2 = this.roleInfoView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnRoleInfoItemVisiable));
			}
			if (this.rewardInfoView != null)
			{
				if (!this.rewardInfoView.IsInitialised())
				{
					this.rewardInfoView.Initialize();
				}
				ComUIListScript comUIListScript3 = this.rewardInfoView;
				comUIListScript3.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Combine(comUIListScript3.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnRewardItemBind));
				ComUIListScript comUIListScript4 = this.rewardInfoView;
				comUIListScript4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnRewardItemVisiable));
				ComUIListScript comUIListScript5 = this.rewardInfoView;
				comUIListScript5.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScript5.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnRewardItemUpdate));
				ComUIListScript comUIListScript6 = this.rewardInfoView;
				comUIListScript6.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript6.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnRewardItemRecycle));
			}
			if (this.roleInfoCanvasGroup)
			{
				this.roleInfoCanvasGroup.blocksRaycasts = false;
				this.roleInfoCanvasGroup.interactable = false;
			}
			if (this.rewardInfoCanvasGroup)
			{
				this.rewardInfoCanvasGroup.blocksRaycasts = false;
				this.rewardInfoCanvasGroup.interactable = false;
			}
		}

		// Token: 0x0600C71D RID: 50973 RVA: 0x00301DB4 File Offset: 0x003001B4
		private void _ClearView()
		{
			if (this.roleInfoView != null)
			{
				ComUIListScript comUIListScript = this.roleInfoView;
				comUIListScript.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnRoleInfoItemBind));
				ComUIListScript comUIListScript2 = this.roleInfoView;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnRoleInfoItemVisiable));
				this.roleInfoView.UnInitialize();
			}
			if (this.rewardInfoView != null)
			{
				ComUIListScript comUIListScript3 = this.rewardInfoView;
				comUIListScript3.onBindItem = (ComUIListScript.OnBindItemDelegate)Delegate.Remove(comUIListScript3.onBindItem, new ComUIListScript.OnBindItemDelegate(this._OnRewardItemBind));
				ComUIListScript comUIListScript4 = this.rewardInfoView;
				comUIListScript4.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript4.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this._OnRewardItemVisiable));
				ComUIListScript comUIListScript5 = this.rewardInfoView;
				comUIListScript5.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScript5.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this._OnRewardItemUpdate));
				ComUIListScript comUIListScript6 = this.rewardInfoView;
				comUIListScript6.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript6.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this._OnRewardItemRecycle));
				this.rewardInfoView.UnInitialize();
			}
			this.ClearView();
		}

		// Token: 0x0600C71E RID: 50974 RVA: 0x00301EE9 File Offset: 0x003002E9
		private AdventureTeamExpedtionResultRoleInfo _OnRoleInfoItemBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<AdventureTeamExpedtionResultRoleInfo>();
		}

		// Token: 0x0600C71F RID: 50975 RVA: 0x00301F00 File Offset: 0x00300300
		private void _OnRoleInfoItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.roleJobIds == null || this.roleJobIds.Length <= 0)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this.roleJobIds.Length)
			{
				return;
			}
			AdventureTeamExpedtionResultRoleInfo adventureTeamExpedtionResultRoleInfo = item.gameObjectBindScript as AdventureTeamExpedtionResultRoleInfo;
			if (adventureTeamExpedtionResultRoleInfo != null)
			{
				adventureTeamExpedtionResultRoleInfo.RefreshView(this.roleJobIds[index]);
			}
		}

		// Token: 0x0600C720 RID: 50976 RVA: 0x00301F77 File Offset: 0x00300377
		private AdventureTeamExpeditionOnekeyRewardItem _OnRewardItemBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<AdventureTeamExpeditionOnekeyRewardItem>();
		}

		// Token: 0x0600C721 RID: 50977 RVA: 0x00301F90 File Offset: 0x00300390
		private void _OnRewardItemVisiable(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.mapModel == null || this.mapModel.rewardList == null)
			{
				return;
			}
			int index = item.m_index;
			if (index < 0 || index >= this.mapModel.rewardList.Count)
			{
				return;
			}
			AdventureTeamExpeditionOnekeyRewardItem adventureTeamExpeditionOnekeyRewardItem = item.gameObjectBindScript as AdventureTeamExpeditionOnekeyRewardItem;
			if (adventureTeamExpeditionOnekeyRewardItem != null)
			{
				adventureTeamExpeditionOnekeyRewardItem.InitItemView(index, this.mapModel, this.mapModel.rewardList[index].rewardCondition);
				adventureTeamExpeditionOnekeyRewardItem.UpdateExpeditionMapBaseData();
				adventureTeamExpeditionOnekeyRewardItem.OnExpeditionRolesChanged();
			}
		}

		// Token: 0x0600C722 RID: 50978 RVA: 0x00302038 File Offset: 0x00300438
		private void _OnRewardItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionOnekeyRewardItem adventureTeamExpeditionOnekeyRewardItem = item.gameObjectBindScript as AdventureTeamExpeditionOnekeyRewardItem;
			if (adventureTeamExpeditionOnekeyRewardItem != null)
			{
				adventureTeamExpeditionOnekeyRewardItem.OnExpeditionTimeChanged();
			}
		}

		// Token: 0x0600C723 RID: 50979 RVA: 0x00302070 File Offset: 0x00300470
		private void _OnRewardItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AdventureTeamExpeditionOnekeyRewardItem adventureTeamExpeditionOnekeyRewardItem = item.gameObjectBindScript as AdventureTeamExpeditionOnekeyRewardItem;
			if (adventureTeamExpeditionOnekeyRewardItem != null)
			{
				adventureTeamExpeditionOnekeyRewardItem.OnItemRecycle();
			}
		}

		// Token: 0x0600C724 RID: 50980 RVA: 0x003020A8 File Offset: 0x003004A8
		private void _SetMapImg(string imgPath)
		{
			this.mapImg.SafeSetImage(imgPath, false);
		}

		// Token: 0x0600C725 RID: 50981 RVA: 0x003020B7 File Offset: 0x003004B7
		private void _SetMapName(string mapName)
		{
			this.mapNameText.SafeSetText(mapName);
		}

		// Token: 0x0600C726 RID: 50982 RVA: 0x003020C5 File Offset: 0x003004C5
		private void _SetMapLevel(string mapLevel)
		{
			this.mapLevelText.SafeSetText(TR.Value("adventure_team_expedition_dispatch_level", mapLevel));
		}

		// Token: 0x0600C727 RID: 50983 RVA: 0x003020E0 File Offset: 0x003004E0
		public void RefreshView(ExpeditionMapModel model)
		{
			if (model == null)
			{
				return;
			}
			this.mapModel = model;
			if (model.mapNetInfo != null && model.mapNetInfo.roles != null)
			{
				this.roleJobIds = new int[model.mapNetInfo.roles.Count];
				for (int i = 0; i < model.mapNetInfo.roles.Count; i++)
				{
					ExpeditionMemberInfo expeditionMemberInfo = model.mapNetInfo.roles[i];
					if (expeditionMemberInfo != null)
					{
						this.roleJobIds[i] = (int)expeditionMemberInfo.occu;
					}
				}
			}
			this._SetMapImg(model.mapImagePath);
			this._SetMapName(model.mapName);
			this._SetMapLevel(model.playerLevelLimit.ToString());
			if (this.roleInfoView != null && this.roleJobIds != null && this.roleJobIds.Length > 0)
			{
				this.roleInfoView.SetElementAmount(this.roleJobIds.Length);
			}
			if (this.rewardInfoView != null && model.rewardList != null && model.rewardList.Count > 0)
			{
				this.rewardInfoView.SetElementAmount(model.rewardList.Count);
			}
		}

		// Token: 0x0600C728 RID: 50984 RVA: 0x0030222C File Offset: 0x0030062C
		public void RefreshView()
		{
			if (this.rewardInfoView != null)
			{
				this.rewardInfoView.UpdateElement();
			}
		}

		// Token: 0x0600C729 RID: 50985 RVA: 0x0030224A File Offset: 0x0030064A
		public void ClearView()
		{
			this.mapModel = null;
			this.roleJobIds = null;
		}

		// Token: 0x0400724B RID: 29259
		private ExpeditionMapModel mapModel;

		// Token: 0x0400724C RID: 29260
		private int[] roleJobIds;

		// Token: 0x0400724D RID: 29261
		[SerializeField]
		private Image mapImg;

		// Token: 0x0400724E RID: 29262
		[SerializeField]
		private Text mapNameText;

		// Token: 0x0400724F RID: 29263
		[SerializeField]
		private Text mapLevelText;

		// Token: 0x04007250 RID: 29264
		[SerializeField]
		private ComUIListScript roleInfoView;

		// Token: 0x04007251 RID: 29265
		[SerializeField]
		private CanvasGroup roleInfoCanvasGroup;

		// Token: 0x04007252 RID: 29266
		[SerializeField]
		private ComUIListScript rewardInfoView;

		// Token: 0x04007253 RID: 29267
		[SerializeField]
		private CanvasGroup rewardInfoCanvasGroup;
	}
}
