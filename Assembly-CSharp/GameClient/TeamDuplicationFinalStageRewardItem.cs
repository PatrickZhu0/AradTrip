using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C94 RID: 7316
	public class TeamDuplicationFinalStageRewardItem : MonoBehaviour
	{
		// Token: 0x06011F07 RID: 73479 RVA: 0x0053EDA3 File Offset: 0x0053D1A3
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011F08 RID: 73480 RVA: 0x0053EDAB File Offset: 0x0053D1AB
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011F09 RID: 73481 RVA: 0x0053EDB9 File Offset: 0x0053D1B9
		private void BindUiEvents()
		{
		}

		// Token: 0x06011F0A RID: 73482 RVA: 0x0053EDBB File Offset: 0x0053D1BB
		private void UnBindUiEvents()
		{
		}

		// Token: 0x06011F0B RID: 73483 RVA: 0x0053EDBD File Offset: 0x0053D1BD
		private void ClearData()
		{
			this._finalStageRewardDataModel = null;
			this._commonNewItem = null;
		}

		// Token: 0x06011F0C RID: 73484 RVA: 0x0053EDCD File Offset: 0x0053D1CD
		public void Init(int stageId)
		{
			this.ClearData();
		}

		// Token: 0x06011F0D RID: 73485 RVA: 0x0053EDD5 File Offset: 0x0053D1D5
		public void UpdateRewardItem(TeamDuplicationFightStageRewardDataModel finalStageRewardDataModel)
		{
			this._finalStageRewardDataModel = finalStageRewardDataModel;
			if (this._finalStageRewardDataModel == null)
			{
				return;
			}
			this.ShowRewardItemView();
		}

		// Token: 0x06011F0E RID: 73486 RVA: 0x0053EDF0 File Offset: 0x0053D1F0
		private void ShowRewardItemView()
		{
			this.ShowRewardItemPlayerName();
			this.UpdateRewardItem();
			this.ShowRewardLimit();
		}

		// Token: 0x06011F0F RID: 73487 RVA: 0x0053EE04 File Offset: 0x0053D204
		private void ShowRewardItemPlayerName()
		{
			if (this.playerNameLabel == null)
			{
				return;
			}
			this.playerNameLabel.text = this._finalStageRewardDataModel.PlayerName;
			if (!CommonUtility.IsSelfPlayerByPlayerGuid(this._finalStageRewardDataModel.PlayerGuid))
			{
				this.playerNameLabel.color = Color.white;
			}
		}

		// Token: 0x06011F10 RID: 73488 RVA: 0x0053EE60 File Offset: 0x0053D260
		private void UpdateRewardItem()
		{
			if (this._finalStageRewardDataModel.IsLimit != TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_NULL)
			{
				CommonUtility.UpdateGameObjectVisible(this.rewardItemRoot, false);
				return;
			}
			if (this._finalStageRewardDataModel.IsGoldReward && this.rewardItemBgImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.rewardItemBgImage, this.goldRewardItemBgPath, true);
			}
			CommonUtility.UpdateGameObjectVisible(this.rewardItemRoot, true);
			if (this._finalStageRewardDataModel.RewardId <= 0)
			{
				return;
			}
			CommonNewItemDataModel dataModel = new CommonNewItemDataModel
			{
				ItemId = this._finalStageRewardDataModel.RewardId,
				ItemCount = this._finalStageRewardDataModel.RewardNum
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
				this._commonNewItem.SetItemCountFontSize(26);
				this._commonNewItem.SetItemLevelFontSize(26);
			}
		}

		// Token: 0x06011F11 RID: 73489 RVA: 0x0053EF84 File Offset: 0x0053D384
		private void ShowRewardLimit()
		{
			if (this._finalStageRewardDataModel.IsLimit == TeamCopyFlopLimit.TEAM_COPY_FLOP_LIMIT_NULL)
			{
				CommonUtility.UpdateGameObjectVisible(this.rewardLimitRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.rewardLimitRoot, true);
			if (this.rewardLimitText == null)
			{
				return;
			}
			string stageLimitDescriptionByLimitType = TeamDuplicationUtility.GetStageLimitDescriptionByLimitType(this._finalStageRewardDataModel.IsLimit);
			this.rewardLimitText.text = stageLimitDescriptionByLimitType;
		}

		// Token: 0x0400BAF7 RID: 47863
		private string goldRewardItemBgPath = "UI/Image/Background/UI_Tuanben_Fanpai_Jinpai.png:UI_Tuanben_Fanpai_Jinpai";

		// Token: 0x0400BAF8 RID: 47864
		private bool _isInitRewardItem;

		// Token: 0x0400BAF9 RID: 47865
		private TeamDuplicationFightStageRewardDataModel _finalStageRewardDataModel;

		// Token: 0x0400BAFA RID: 47866
		private CommonNewItem _commonNewItem;

		// Token: 0x0400BAFB RID: 47867
		[Space(10f)]
		[Header("RewardItemBg")]
		[Space(10f)]
		[SerializeField]
		private Image rewardItemBgImage;

		// Token: 0x0400BAFC RID: 47868
		[Space(10f)]
		[Header("rewardItem")]
		[Space(10f)]
		[SerializeField]
		private Text playerNameLabel;

		// Token: 0x0400BAFD RID: 47869
		[SerializeField]
		private GameObject rewardItemRoot;

		// Token: 0x0400BAFE RID: 47870
		[Space(25f)]
		[Header("RewardLimit")]
		[Space(10f)]
		[SerializeField]
		private GameObject rewardLimitRoot;

		// Token: 0x0400BAFF RID: 47871
		[SerializeField]
		private Text rewardLimitText;
	}
}
