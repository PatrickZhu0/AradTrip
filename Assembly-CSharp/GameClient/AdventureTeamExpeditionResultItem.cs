using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001416 RID: 5142
	public class AdventureTeamExpeditionResultItem : MonoBehaviour
	{
		// Token: 0x0600C750 RID: 51024 RVA: 0x00303120 File Offset: 0x00301520
		private void Awake()
		{
			this._InitView();
		}

		// Token: 0x0600C751 RID: 51025 RVA: 0x00303128 File Offset: 0x00301528
		private void OnDestroy()
		{
			this._ClearView();
		}

		// Token: 0x0600C752 RID: 51026 RVA: 0x00303130 File Offset: 0x00301530
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
			if (this.roleInfoCanvasGroup)
			{
				this.roleInfoCanvasGroup.blocksRaycasts = false;
				this.roleInfoCanvasGroup.interactable = false;
			}
		}

		// Token: 0x0600C753 RID: 51027 RVA: 0x003031E0 File Offset: 0x003015E0
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
			ComItemManager.Destroy(this.awardItem);
			this.awardItem = null;
			this.ClearView();
		}

		// Token: 0x0600C754 RID: 51028 RVA: 0x0030326F File Offset: 0x0030166F
		private AdventureTeamExpedtionResultRoleInfo _OnRoleInfoItemBind(GameObject go)
		{
			if (go == null)
			{
				return null;
			}
			return go.GetComponent<AdventureTeamExpedtionResultRoleInfo>();
		}

		// Token: 0x0600C755 RID: 51029 RVA: 0x00303288 File Offset: 0x00301688
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

		// Token: 0x0600C756 RID: 51030 RVA: 0x003032FF File Offset: 0x003016FF
		private void _SetMapImg(string imgPath)
		{
			this.mapImg.SafeSetImage(imgPath, false);
		}

		// Token: 0x0600C757 RID: 51031 RVA: 0x0030330E File Offset: 0x0030170E
		private void _SetMapName(string mapName)
		{
			this.mapNameText.SafeSetText(mapName);
		}

		// Token: 0x0600C758 RID: 51032 RVA: 0x0030331C File Offset: 0x0030171C
		private void _SetMapLevel(string mapLevel)
		{
			this.mapLevelText.SafeSetText(TR.Value("adventure_team_expedition_dispatch_level", mapLevel));
		}

		// Token: 0x0600C759 RID: 51033 RVA: 0x00303334 File Offset: 0x00301734
		private void _SetAwardItem(int itemTableId, int itemTotalCount)
		{
			if (this.awardItem == null)
			{
				this.awardItem = ComItemManager.Create(this.awardItemRoot);
			}
			if (this.awardItem != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemTableId, 100, 0);
				this.awardItem.SetCountFormatter((ComItem var) => TR.Value("adventure_team_expeidtion_dispatch_reward_count", itemTotalCount.ToString()));
				ComItem comItem = this.awardItem;
				ItemData item = itemData;
				if (AdventureTeamExpeditionResultItem.<>f__mg$cache0 == null)
				{
					AdventureTeamExpeditionResultItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, AdventureTeamExpeditionResultItem.<>f__mg$cache0);
			}
		}

		// Token: 0x0600C75A RID: 51034 RVA: 0x003033CC File Offset: 0x003017CC
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
			if (model.rewardList != null && model.rewardList.Count > 0)
			{
				ExpeditionReward expeditionReward = model.rewardList[0];
				if (!string.IsNullOrEmpty(expeditionReward.rewards))
				{
					string[] array = expeditionReward.rewards.Split(new char[]
					{
						':'
					});
					int itemTableId;
					if (array != null && array.Length == 2 && int.TryParse(array[0], out itemTableId))
					{
						int expeditionRewardItemTotalCount = DataManager<AdventureTeamDataManager>.GetInstance().GetExpeditionRewardItemTotalCount(new List<ExpeditionMapModel>
						{
							this.mapModel
						}, null);
						this._SetAwardItem(itemTableId, expeditionRewardItemTotalCount);
					}
				}
			}
			if (this.roleInfoView != null && this.roleJobIds != null && this.roleJobIds.Length > 0)
			{
				this.roleInfoView.SetElementAmount(this.roleJobIds.Length);
			}
		}

		// Token: 0x0600C75B RID: 51035 RVA: 0x00303572 File Offset: 0x00301972
		public void ClearView()
		{
			this.mapModel = null;
			this.roleJobIds = null;
		}

		// Token: 0x0400726A RID: 29290
		private ExpeditionMapModel mapModel;

		// Token: 0x0400726B RID: 29291
		private int[] roleJobIds;

		// Token: 0x0400726C RID: 29292
		private ComItem awardItem;

		// Token: 0x0400726D RID: 29293
		[SerializeField]
		private Image mapImg;

		// Token: 0x0400726E RID: 29294
		[SerializeField]
		private Text mapNameText;

		// Token: 0x0400726F RID: 29295
		[SerializeField]
		private Text mapLevelText;

		// Token: 0x04007270 RID: 29296
		[SerializeField]
		private ComUIListScript roleInfoView;

		// Token: 0x04007271 RID: 29297
		[SerializeField]
		private CanvasGroup roleInfoCanvasGroup;

		// Token: 0x04007272 RID: 29298
		[SerializeField]
		private GameObject awardItemRoot;

		// Token: 0x04007273 RID: 29299
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
