using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001418 RID: 5144
	public class AdventureTeamExpeditionRewardItem : MonoBehaviour
	{
		// Token: 0x0600C76A RID: 51050 RVA: 0x003038EA File Offset: 0x00301CEA
		private void Awake()
		{
			this._InitTR();
			this.ClearData();
		}

		// Token: 0x0600C76B RID: 51051 RVA: 0x003038F8 File Offset: 0x00301CF8
		private void OnDestroy()
		{
			this._ClearTR();
			this.ClearData();
			if (this._rewardComItem)
			{
				ComItemManager.Destroy(this._rewardComItem);
				this._rewardComItem = null;
			}
		}

		// Token: 0x0600C76C RID: 51052 RVA: 0x00303928 File Offset: 0x00301D28
		private void _InitTR()
		{
			this.tr_expedition_base_reward = TR.Value("adventure_team_expedition_base_reward_text");
			this.tr_expedition_extra_reward = TR.Value("adventure_team_expedition_extra_reward_text");
		}

		// Token: 0x0600C76D RID: 51053 RVA: 0x0030394A File Offset: 0x00301D4A
		private void _ClearTR()
		{
			this.tr_expedition_base_reward = string.Empty;
			this.tr_expedition_extra_reward = string.Empty;
		}

		// Token: 0x0600C76E RID: 51054 RVA: 0x00303964 File Offset: 0x00301D64
		public void InitItemView(int index, ExpeditionMapModel mapInfo, ExpeditionRewardCondition Condition)
		{
			this.tempIndex = index;
			this.tempInfo = mapInfo;
			this.tempCondition = mapInfo.rewardList[index].rewardCondition;
		}

		// Token: 0x0600C76F RID: 51055 RVA: 0x0030399C File Offset: 0x00301D9C
		public void UpdateExpeditionMapBaseDate()
		{
			int num2 = 600002535;
			int num = 0;
			if (!string.IsNullOrEmpty(this.tempInfo.rewardList[this.tempIndex].rewards))
			{
				string[] array = this.tempInfo.rewardList[this.tempIndex].rewards.Split(new char[]
				{
					':'
				});
				if (array.Length != 0)
				{
					int.TryParse(array[0], out num2);
					int.TryParse(array[1], out num);
				}
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num2, string.Empty, string.Empty);
			if (this.mItemRoot && tableItem != null)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(num2, 100, 0);
				if (!this._rewardComItem)
				{
					this._rewardComItem = ComItemManager.Create(this.mItemRoot);
				}
				if (itemData != null)
				{
					this._rewardComItem.Setup(itemData, delegate(GameObject var1, ItemData var2)
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(var2, null, 4, true, false, true);
					});
				}
				this._rewardComItem.SetCountFormatter(delegate(ComItem var)
				{
					if (num <= 0)
					{
						return string.Empty;
					}
					return num.ToString();
				});
				this._rewardComItem.CustomActive(true);
			}
			if (this.mTitleText)
			{
				if (this.tempIndex == 0)
				{
					this.mTitleText.text = this.tr_expedition_base_reward;
				}
				else
				{
					this.mTitleText.text = string.Format(this.tr_expedition_extra_reward, this.tempIndex);
				}
			}
			if (this.mRewardText)
			{
				string format = DataManager<AdventureTeamDataManager>.GetInstance().TryGetExpeditionMapRewardConition((int)this.tempCondition);
				this.mRewardText.text = string.Format(format, 0, this.tempInfo.rewardList[this.tempIndex].rolesNum);
			}
		}

		// Token: 0x0600C770 RID: 51056 RVA: 0x00303B94 File Offset: 0x00301F94
		public void OnExpeditionTimeChanged()
		{
			uint mutiple = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.durationOfExpedition;
			int num = 0;
			if (!string.IsNullOrEmpty(this.tempInfo.rewardList[this.tempIndex].rewards))
			{
				string[] array = this.tempInfo.rewardList[this.tempIndex].rewards.Split(new char[]
				{
					':'
				});
				if (array.Length != 0)
				{
					int.TryParse(array[1], out num);
				}
			}
			if (this._rewardComItem)
			{
				this._rewardComItem.SetCountFormatter(delegate(ComItem var)
				{
					if (num <= 0)
					{
						return string.Empty;
					}
					return ((long)num * (long)((ulong)mutiple)).ToString();
				});
			}
		}

		// Token: 0x0600C771 RID: 51057 RVA: 0x00303C58 File Offset: 0x00302058
		public void OnExpeditionRolesChanged()
		{
			List<ExpeditionMemberInfo> roles = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles;
			if (roles == null)
			{
				return;
			}
			int rolesNum = this.tempInfo.rewardList[this.tempIndex].rolesNum;
			string condition = DataManager<AdventureTeamDataManager>.GetInstance().TryGetExpeditionMapRewardConition((int)this.tempCondition);
			List<int> list = new List<int>();
			bool flag = false;
			for (int i = 0; i < roles.Count; i++)
			{
				if (roles[i] != null)
				{
					list.Add((int)roles[i].occu);
				}
			}
			switch (this.tempCondition)
			{
			case ExpeditionRewardCondition.REQUIRE_ANY_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().ExpeditionMapNetInfo.roles.Count;
				flag = this.UpdateRewardText(reach, rolesNum, condition);
				break;
			}
			case ExpeditionRewardCondition.REQUIRE_ANY_SAME_BASE_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().IsAnySameBaseOccu(list.ToArray());
				flag = this.UpdateRewardText(reach, rolesNum, condition);
				break;
			}
			case ExpeditionRewardCondition.REQUIRE_ANY_DIFF_BASE_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().IsAnyDiffBaseOccu(list.ToArray());
				flag = this.UpdateRewardText(reach, rolesNum, condition);
				break;
			}
			case ExpeditionRewardCondition.REQUIRE_ANY_DIFF_CHANGED_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().IsAnyDiffChangedOccu(list.ToArray());
				flag = this.UpdateRewardText(reach, rolesNum, condition);
				break;
			}
			}
			if (flag)
			{
				this.mRichObj.SetActive(true);
			}
			else
			{
				this.mRichObj.SetActive(false);
			}
		}

		// Token: 0x0600C772 RID: 51058 RVA: 0x00303DD4 File Offset: 0x003021D4
		private bool UpdateRewardText(int reach, int total, string condition)
		{
			if (reach >= total)
			{
				this.mRewardText.color = Color.yellow;
				this.mRewardText.text = string.Format(condition, reach, total);
				return true;
			}
			this.mRewardText.color = Color.white;
			this.mRewardText.text = string.Format(condition, reach, total);
			return false;
		}

		// Token: 0x0600C773 RID: 51059 RVA: 0x00303E45 File Offset: 0x00302245
		public bool IsReach()
		{
			return this.mRewardText.color == Color.yellow;
		}

		// Token: 0x0600C774 RID: 51060 RVA: 0x00303E5C File Offset: 0x0030225C
		public void OnItemRecycle()
		{
			this.ClearData();
		}

		// Token: 0x0600C775 RID: 51061 RVA: 0x00303E64 File Offset: 0x00302264
		private void ClearData()
		{
			this.tempCondition = ExpeditionRewardCondition.REQUIRE_ANY_OCCU;
			this.tempIndex = 0;
			this.tempInfo = null;
		}

		// Token: 0x04007279 RID: 29305
		[SerializeField]
		private GameObject mRichObj;

		// Token: 0x0400727A RID: 29306
		[SerializeField]
		private Text mTitleText;

		// Token: 0x0400727B RID: 29307
		[SerializeField]
		private Text mRewardText;

		// Token: 0x0400727C RID: 29308
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x0400727D RID: 29309
		[SerializeField]
		private ExpeditionMapModel tempInfo;

		// Token: 0x0400727E RID: 29310
		[SerializeField]
		private int tempIndex;

		// Token: 0x0400727F RID: 29311
		[SerializeField]
		private ExpeditionRewardCondition tempCondition;

		// Token: 0x04007280 RID: 29312
		private string tr_expedition_base_reward = string.Empty;

		// Token: 0x04007281 RID: 29313
		private string tr_expedition_extra_reward = string.Empty;

		// Token: 0x04007282 RID: 29314
		private ComItem _rewardComItem;
	}
}
