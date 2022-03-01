using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C93 RID: 7315
	public class TeamDuplicationFinalStageCardItem : MonoBehaviour
	{
		// Token: 0x06011EFC RID: 73468 RVA: 0x0053EB6C File Offset: 0x0053CF6C
		private void Awake()
		{
		}

		// Token: 0x06011EFD RID: 73469 RVA: 0x0053EB6E File Offset: 0x0053CF6E
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011EFE RID: 73470 RVA: 0x0053EB76 File Offset: 0x0053CF76
		private void ClearData()
		{
			this._finalStageRewardDataModel = null;
			this._finalStageRewardItem = null;
		}

		// Token: 0x06011EFF RID: 73471 RVA: 0x0053EB86 File Offset: 0x0053CF86
		public void LoadStageCardCoverEffect()
		{
			if (this.rewardItemCoverEffectRoot == null)
			{
				return;
			}
			CommonUtility.LoadGameObjectWithPath(this.rewardItemCoverEffectRoot, this.rewardItemCoverEffectPath);
		}

		// Token: 0x06011F00 RID: 73472 RVA: 0x0053EBAC File Offset: 0x0053CFAC
		public void Init(TeamDuplicationFightStageRewardDataModel fightStageRewardDataModel)
		{
			this._finalStageRewardDataModel = fightStageRewardDataModel;
			this.ShowRewardItemView();
		}

		// Token: 0x06011F01 RID: 73473 RVA: 0x0053EBBC File Offset: 0x0053CFBC
		private void ShowRewardItemView()
		{
			if (this._finalStageRewardDataModel.IsLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_NULL && this._finalStageRewardDataModel.IsGoldReward)
			{
				CommonUtility.SetGameObjectLoadPath(this.rewardItemActionRoot, this.goldCardActionPath);
				CommonUtility.SetGameObjectLoadPath(this.rewardItemEffectRoot, this.goldCardEffectPath);
			}
			else
			{
				CommonUtility.SetGameObjectLoadPath(this.rewardItemActionRoot, this.normalCardActionPath);
				CommonUtility.SetGameObjectLoadPath(this.rewardItemEffectRoot, this.normalCardEffectPath);
			}
			CommonUtility.SetGameObjectLoadPath(this.ownerRewardItemEffectRoot, this.specialCardEffectPath);
			CommonUtility.SetGameObjectLoadPath(this.rewardItemRoot, this.rewardItemViewPath);
			CommonUtility.UpdateGameObjectVisible(this.rewardItemCover, false);
			if (this._finalStageRewardItem == null)
			{
				this._finalStageRewardItem = this.LoadFinalStageRewardItem(this.rewardItemRoot);
			}
			if (this._finalStageRewardItem != null)
			{
				this._finalStageRewardItem.UpdateRewardItem(this._finalStageRewardDataModel);
			}
			CommonUtility.UpdateGameObjectVisible(this.rewardItemRoot, false);
			this._isBeginRewardAction = true;
			this._rewardItemActionDuringTime = 0.5f;
			CommonUtility.LoadGameObject(this.rewardItemActionRoot);
			CommonUtility.LoadGameObject(this.rewardItemEffectRoot);
		}

		// Token: 0x06011F02 RID: 73474 RVA: 0x0053ECDC File Offset: 0x0053D0DC
		private TeamDuplicationFinalStageRewardItem LoadFinalStageRewardItem(GameObject contentRoot)
		{
			GameObject gameObject = CommonUtility.LoadGameObject(contentRoot);
			if (gameObject == null)
			{
				return null;
			}
			return gameObject.GetComponent<TeamDuplicationFinalStageRewardItem>();
		}

		// Token: 0x06011F03 RID: 73475 RVA: 0x0053ED06 File Offset: 0x0053D106
		public TeamDuplicationFightStageRewardDataModel GetFightStageRewardDataModel()
		{
			return this._finalStageRewardDataModel;
		}

		// Token: 0x06011F04 RID: 73476 RVA: 0x0053ED0E File Offset: 0x0053D10E
		private void Update()
		{
			if (!this._isBeginRewardAction)
			{
				return;
			}
			this._rewardItemActionDuringTime -= Time.deltaTime;
			if (this._rewardItemActionDuringTime <= 0f)
			{
				this.ShowRewardItemByEffectPlayFinish();
			}
		}

		// Token: 0x06011F05 RID: 73477 RVA: 0x0053ED44 File Offset: 0x0053D144
		private void ShowRewardItemByEffectPlayFinish()
		{
			CommonUtility.UpdateGameObjectVisible(this.rewardItemRoot, true);
			this._isBeginRewardAction = false;
			if (this._finalStageRewardDataModel.IsLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_NULL && this._finalStageRewardDataModel.IsGoldReward)
			{
				CommonUtility.LoadGameObject(this.ownerRewardItemEffectRoot);
			}
		}

		// Token: 0x0400BAE6 RID: 47846
		private string rewardItemCoverEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_zhankai";

		// Token: 0x0400BAE7 RID: 47847
		private string goldCardActionPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_jinpai";

		// Token: 0x0400BAE8 RID: 47848
		private string goldCardEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_guangxiao_jinpai";

		// Token: 0x0400BAE9 RID: 47849
		private string normalCardActionPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben";

		// Token: 0x0400BAEA RID: 47850
		private string normalCardEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_guangxiao";

		// Token: 0x0400BAEB RID: 47851
		private string specialCardEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_ziji";

		// Token: 0x0400BAEC RID: 47852
		private string rewardItemViewPath = "UIFlatten/Prefabs/TeamDuplication/View/TeamDuplicationFightStageRewardItemView";

		// Token: 0x0400BAED RID: 47853
		private TeamDuplicationFightStageRewardDataModel _finalStageRewardDataModel;

		// Token: 0x0400BAEE RID: 47854
		private TeamDuplicationFinalStageRewardItem _finalStageRewardItem;

		// Token: 0x0400BAEF RID: 47855
		private bool _isBeginRewardAction;

		// Token: 0x0400BAF0 RID: 47856
		private float _rewardItemActionDuringTime;

		// Token: 0x0400BAF1 RID: 47857
		[Space(10f)]
		[Header("cardButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardItemCover;

		// Token: 0x0400BAF2 RID: 47858
		[SerializeField]
		private GameObject rewardItemCoverEffectRoot;

		// Token: 0x0400BAF3 RID: 47859
		[SerializeField]
		private GameObject rewardItemActionRoot;

		// Token: 0x0400BAF4 RID: 47860
		[SerializeField]
		private GameObject rewardItemEffectRoot;

		// Token: 0x0400BAF5 RID: 47861
		[Space(10f)]
		[Header("OwnerCardGameObject")]
		[Space(10f)]
		[SerializeField]
		private GameObject ownerRewardItemEffectRoot;

		// Token: 0x0400BAF6 RID: 47862
		[Space(10f)]
		[Header("rewardItemRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardItemRoot;
	}
}
