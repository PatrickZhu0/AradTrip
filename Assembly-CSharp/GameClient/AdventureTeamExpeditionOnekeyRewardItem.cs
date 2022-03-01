using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001413 RID: 5139
	public class AdventureTeamExpeditionOnekeyRewardItem : MonoBehaviour
	{
		// Token: 0x0600C72B RID: 50987 RVA: 0x00302278 File Offset: 0x00300678
		private void Awake()
		{
			this._InitTR();
			this._ClearData();
		}

		// Token: 0x0600C72C RID: 50988 RVA: 0x00302286 File Offset: 0x00300686
		private void OnDestroy()
		{
			this._ClearTR();
			this._ClearData();
		}

		// Token: 0x0600C72D RID: 50989 RVA: 0x00302294 File Offset: 0x00300694
		private void _InitTR()
		{
			this.tr_expedition_base_reward = TR.Value("adventure_team_expedition_base_reward_text");
			this.tr_expedition_extra_reward = TR.Value("adventure_team_expedition_extra_reward_text");
		}

		// Token: 0x0600C72E RID: 50990 RVA: 0x003022B6 File Offset: 0x003006B6
		private void _ClearTR()
		{
			this.tr_expedition_base_reward = string.Empty;
			this.tr_expedition_extra_reward = string.Empty;
		}

		// Token: 0x0600C72F RID: 50991 RVA: 0x003022D0 File Offset: 0x003006D0
		public void InitItemView(int index, ExpeditionMapModel mapInfo, ExpeditionRewardCondition Condition)
		{
			this.tempIndex = index;
			this.tempInfo = mapInfo;
			this.tempCondition = mapInfo.rewardList[index].rewardCondition;
		}

		// Token: 0x0600C730 RID: 50992 RVA: 0x00302308 File Offset: 0x00300708
		public void UpdateExpeditionMapBaseData()
		{
			int id = 600002535;
			int num = 0;
			if (!string.IsNullOrEmpty(this.tempInfo.rewardList[this.tempIndex].rewards))
			{
				string[] array = this.tempInfo.rewardList[this.tempIndex].rewards.Split(new char[]
				{
					':'
				});
				if (array.Length != 0)
				{
					int.TryParse(array[0], out id);
					int.TryParse(array[1], out num);
				}
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (this.mRewardIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.mRewardIcon, tableItem.Icon, true);
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
				this.mRewardText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_reward_count", num.ToString()));
			}
		}

		// Token: 0x0600C731 RID: 50993 RVA: 0x00302454 File Offset: 0x00300854
		public void OnExpeditionTimeChanged()
		{
			if (this.tempInfo == null || this.tempInfo.mapNetInfo == null)
			{
				return;
			}
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
			long num2 = (long)num * (long)((ulong)this.tempInfo.mapNetInfo.durationOfExpedition);
			if (this.mRewardText)
			{
				this.mRewardText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_reward_count", num2.ToString()));
			}
		}

		// Token: 0x0600C732 RID: 50994 RVA: 0x00302534 File Offset: 0x00300934
		public void OnExpeditionRolesChanged()
		{
			if (this.tempInfo == null || this.tempInfo.mapNetInfo == null)
			{
				return;
			}
			List<ExpeditionMemberInfo> roles = this.tempInfo.mapNetInfo.roles;
			if (roles == null)
			{
				return;
			}
			int rolesNum = this.tempInfo.rewardList[this.tempIndex].rolesNum;
			string text = DataManager<AdventureTeamDataManager>.GetInstance().TryGetExpeditionMapRewardConition((int)this.tempCondition);
			int rewardNum = 0;
			if (!string.IsNullOrEmpty(this.tempInfo.rewardList[this.tempIndex].rewards))
			{
				string[] array = this.tempInfo.rewardList[this.tempIndex].rewards.Split(new char[]
				{
					':'
				});
				if (array.Length != 0)
				{
					int.TryParse(array[1], out rewardNum);
				}
			}
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
				int reach = roles.Count;
				flag = this._UpdateRewardText(reach, rolesNum, rewardNum);
				break;
			}
			case ExpeditionRewardCondition.REQUIRE_ANY_SAME_BASE_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().IsAnySameBaseOccu(list.ToArray());
				flag = this._UpdateRewardText(reach, rolesNum, rewardNum);
				break;
			}
			case ExpeditionRewardCondition.REQUIRE_ANY_DIFF_BASE_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().IsAnyDiffBaseOccu(list.ToArray());
				flag = this._UpdateRewardText(reach, rolesNum, rewardNum);
				break;
			}
			case ExpeditionRewardCondition.REQUIRE_ANY_DIFF_CHANGED_OCCU:
			{
				int reach = DataManager<AdventureTeamDataManager>.GetInstance().IsAnyDiffChangedOccu(list.ToArray());
				flag = this._UpdateRewardText(reach, rolesNum, rewardNum);
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

		// Token: 0x0600C733 RID: 50995 RVA: 0x0030272E File Offset: 0x00300B2E
		public void OnItemRecycle()
		{
			this._ClearData();
		}

		// Token: 0x0600C734 RID: 50996 RVA: 0x00302738 File Offset: 0x00300B38
		private bool _UpdateRewardText(int reach, int total, int rewardNum)
		{
			if (reach >= total)
			{
				if (this.mRewardText)
				{
					this.mRewardText.color = Color.yellow;
					this.mRewardText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_reward_count", rewardNum.ToString()));
				}
				if (this.mTitleText)
				{
					this.mTitleText.color = Color.yellow;
				}
				return true;
			}
			if (this.mRewardText)
			{
				this.mRewardText.color = Color.white;
				this.mRewardText.SafeSetText(TR.Value("adventure_team_expeidtion_dispatch_reward_count", rewardNum.ToString()));
			}
			if (this.mTitleText)
			{
				this.mTitleText.color = Color.white;
			}
			return false;
		}

		// Token: 0x0600C735 RID: 50997 RVA: 0x00302813 File Offset: 0x00300C13
		private void _ClearData()
		{
			this.tempCondition = ExpeditionRewardCondition.REQUIRE_ANY_OCCU;
			this.tempIndex = 0;
			this.tempInfo = null;
		}

		// Token: 0x04007254 RID: 29268
		[SerializeField]
		private GameObject mRichObj;

		// Token: 0x04007255 RID: 29269
		[SerializeField]
		private Text mTitleText;

		// Token: 0x04007256 RID: 29270
		[SerializeField]
		private Image mRewardIcon;

		// Token: 0x04007257 RID: 29271
		[SerializeField]
		private Text mRewardText;

		// Token: 0x04007258 RID: 29272
		private ExpeditionMapModel tempInfo;

		// Token: 0x04007259 RID: 29273
		private int tempIndex;

		// Token: 0x0400725A RID: 29274
		private ExpeditionRewardCondition tempCondition;

		// Token: 0x0400725B RID: 29275
		private string tr_expedition_base_reward = string.Empty;

		// Token: 0x0400725C RID: 29276
		private string tr_expedition_extra_reward = string.Empty;
	}
}
