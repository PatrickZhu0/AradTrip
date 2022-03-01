using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C95 RID: 7317
	public class TeamDuplicationMiddleStageRewardItem : MonoBehaviour
	{
		// Token: 0x06011F13 RID: 73491 RVA: 0x0053F007 File Offset: 0x0053D407
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011F14 RID: 73492 RVA: 0x0053F00F File Offset: 0x0053D40F
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011F15 RID: 73493 RVA: 0x0053F01D File Offset: 0x0053D41D
		private void BindUiEvents()
		{
		}

		// Token: 0x06011F16 RID: 73494 RVA: 0x0053F01F File Offset: 0x0053D41F
		private void UnBindUiEvents()
		{
		}

		// Token: 0x06011F17 RID: 73495 RVA: 0x0053F021 File Offset: 0x0053D421
		private void ClearData()
		{
			this._fightStageRewardDataModel = null;
			this._commonNewItem = null;
			this._stageId = 0;
			this._isInitRewardItem = false;
			this._isBeginRewardAction = false;
			this._rewardItemActionDuringTime = 0f;
		}

		// Token: 0x06011F18 RID: 73496 RVA: 0x0053F051 File Offset: 0x0053D451
		public void Init(int stageId)
		{
			this.ClearData();
			this._stageId = stageId;
			CommonUtility.UpdateGameObjectVisible(this.rewardItemGameObject, false);
		}

		// Token: 0x06011F19 RID: 73497 RVA: 0x0053F06C File Offset: 0x0053D46C
		public void UpdateRewardItem(TeamDuplicationFightStageRewardDataModel fightStageRewardDataModel)
		{
			this._fightStageRewardDataModel = fightStageRewardDataModel;
			if (this._fightStageRewardDataModel == null)
			{
				return;
			}
			this._isInitRewardItem = true;
			CommonUtility.UpdateGameObjectVisible(this.itemCover, false);
			this.ShowRewardItemPlayerName();
			this.ShowRewardItemView();
			this.ShowRewardLimit();
			CommonUtility.UpdateGameObjectVisible(this.rewardItemGameObject, false);
			this._isBeginRewardAction = true;
			this._rewardItemActionDuringTime = 0.5f;
			CommonUtility.LoadGameObjectWithPath(this.rewardActionRoot, this.rewardItemActionPath);
			CommonUtility.LoadGameObjectWithPath(this.rewardEffectRoot, this.rewardItemEffectPath);
		}

		// Token: 0x06011F1A RID: 73498 RVA: 0x0053F0F4 File Offset: 0x0053D4F4
		private void ShowRewardItemPlayerName()
		{
			if (this.playerNameLabel != null)
			{
				this.playerNameLabel.text = this._fightStageRewardDataModel.PlayerName;
				if (!CommonUtility.IsSelfPlayerByPlayerGuid(this._fightStageRewardDataModel.PlayerGuid))
				{
					this.playerNameLabel.color = Color.white;
				}
			}
		}

		// Token: 0x06011F1B RID: 73499 RVA: 0x0053F150 File Offset: 0x0053D550
		private void ShowRewardItemView()
		{
			if (this._fightStageRewardDataModel.RewardId <= 0)
			{
				return;
			}
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = this._fightStageRewardDataModel.RewardId,
				ItemCount = this._fightStageRewardDataModel.RewardNum
			};
			if (this.rewardItemRoot != null)
			{
				this._commonNewItem = this.rewardItemRoot.GetComponentInChildren<CommonNewItem>();
				if (this._commonNewItem == null)
				{
					this._commonNewItem = CommonUtility.CreateCommonNewItem(this.rewardItemRoot);
				}
			}
			if (this._commonNewItem != null)
			{
				this._commonNewItem.InitItem(dataModel);
				this._commonNewItem.SetItemCountFontSize(28);
			}
		}

		// Token: 0x06011F1C RID: 73500 RVA: 0x0053F208 File Offset: 0x0053D608
		private void ShowRewardLimit()
		{
			if (this._fightStageRewardDataModel.IsLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_NULL)
			{
				CommonUtility.UpdateGameObjectVisible(this.rewardLimitRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.rewardLimitRoot, true);
			if (this.rewardLimitText == null)
			{
				return;
			}
			string stageLimitDescriptionByLimitType = TeamDuplicationUtility.GetStageLimitDescriptionByLimitType(this._fightStageRewardDataModel.IsLimit);
			this.rewardLimitText.text = stageLimitDescriptionByLimitType;
		}

		// Token: 0x06011F1D RID: 73501 RVA: 0x0053F26D File Offset: 0x0053D66D
		public int GetRewardItemIndex()
		{
			return this.itemIndex;
		}

		// Token: 0x06011F1E RID: 73502 RVA: 0x0053F275 File Offset: 0x0053D675
		public bool GetRewardItemInitState()
		{
			return this._isInitRewardItem;
		}

		// Token: 0x06011F1F RID: 73503 RVA: 0x0053F280 File Offset: 0x0053D680
		private void Update()
		{
			if (!this._isBeginRewardAction)
			{
				return;
			}
			this._rewardItemActionDuringTime -= Time.deltaTime;
			if (this._rewardItemActionDuringTime <= 0f)
			{
				CommonUtility.UpdateGameObjectVisible(this.rewardItemGameObject, true);
				this._isBeginRewardAction = false;
			}
		}

		// Token: 0x0400BB00 RID: 47872
		private string rewardItemActionPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben";

		// Token: 0x0400BB01 RID: 47873
		private string rewardItemEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_guangxiao";

		// Token: 0x0400BB02 RID: 47874
		private int _stageId;

		// Token: 0x0400BB03 RID: 47875
		private bool _isInitRewardItem;

		// Token: 0x0400BB04 RID: 47876
		private TeamDuplicationFightStageRewardDataModel _fightStageRewardDataModel;

		// Token: 0x0400BB05 RID: 47877
		private CommonNewItem _commonNewItem;

		// Token: 0x0400BB06 RID: 47878
		private bool _isBeginRewardAction;

		// Token: 0x0400BB07 RID: 47879
		private float _rewardItemActionDuringTime;

		// Token: 0x0400BB08 RID: 47880
		[Space(10f)]
		[Header("Index")]
		[Space(10f)]
		[SerializeField]
		private int itemIndex;

		// Token: 0x0400BB09 RID: 47881
		[Space(10f)]
		[Header("ItemCover")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemCover;

		// Token: 0x0400BB0A RID: 47882
		[Space(10f)]
		[Header("rewardItem")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardItemGameObject;

		// Token: 0x0400BB0B RID: 47883
		[SerializeField]
		private Text playerNameLabel;

		// Token: 0x0400BB0C RID: 47884
		[SerializeField]
		private GameObject rewardItemRoot;

		// Token: 0x0400BB0D RID: 47885
		[Space(25f)]
		[Header("RewardLimit")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardLimitRoot;

		// Token: 0x0400BB0E RID: 47886
		[SerializeField]
		private Text rewardLimitText;

		// Token: 0x0400BB0F RID: 47887
		[Space(25f)]
		[Header("RewardAction")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardActionRoot;

		// Token: 0x0400BB10 RID: 47888
		[SerializeField]
		private GameObject rewardEffectRoot;
	}
}
