using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014BE RID: 5310
	public class ChallengeChapterRewardControl : MonoBehaviour
	{
		// Token: 0x0600CDE3 RID: 52707 RVA: 0x0032B957 File Offset: 0x00329D57
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CDE4 RID: 52708 RVA: 0x0032B95F File Offset: 0x00329D5F
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CDE5 RID: 52709 RVA: 0x0032B96D File Offset: 0x00329D6D
		private void BindEvents()
		{
			if (this.rewardButton != null)
			{
				this.rewardButton.onClick.RemoveAllListeners();
				this.rewardButton.onClick.AddListener(new UnityAction(this.OnRewardButtonClick));
			}
		}

		// Token: 0x0600CDE6 RID: 52710 RVA: 0x0032B9AC File Offset: 0x00329DAC
		private void UnBindEvents()
		{
			if (this.rewardButton != null)
			{
				this.rewardButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CDE7 RID: 52711 RVA: 0x0032B9D0 File Offset: 0x00329DD0
		private void OnChallengeDungeonRewardUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._dungeonId != num)
			{
				return;
			}
			this._rewardDataModel = DataManager<ChallengeDataManager>.GetInstance().GetChallengeDungeonRewardDataByDungeonId(this._dungeonId);
			if (this._rewardDataModel == null)
			{
				return;
			}
			this.UpdateRewardControl();
		}

		// Token: 0x0600CDE8 RID: 52712 RVA: 0x0032BA30 File Offset: 0x00329E30
		private void ClearData()
		{
			this._dungeonId = 0;
			this._rewardDataModel = null;
		}

		// Token: 0x0600CDE9 RID: 52713 RVA: 0x0032BA40 File Offset: 0x00329E40
		public void InitRewardControl(int dungeonId)
		{
			this._dungeonId = dungeonId;
			this._rewardDataModel = DataManager<ChallengeDataManager>.GetInstance().GetChallengeDungeonRewardDataByDungeonId(dungeonId);
			if (this._rewardDataModel == null)
			{
				base.gameObject.CustomActive(false);
				return;
			}
			if (this.rewardTitleLabel != null)
			{
				this.rewardTitleLabel.text = TR.Value("challenge_pass_number_label");
			}
			base.gameObject.CustomActive(true);
			this.UpdateRewardControl();
		}

		// Token: 0x0600CDEA RID: 52714 RVA: 0x0032BAB8 File Offset: 0x00329EB8
		private void UpdateRewardControl()
		{
			if (this.rewardValueLabel != null)
			{
				this.rewardValueLabel.text = string.Format(TR.Value("challenge_pass_number_value"), this._rewardDataModel.ChallengeNumber, this._rewardDataModel.TotalNumber);
			}
			bool bActive = this._rewardDataModel.ChallengeNumber >= this._rewardDataModel.TotalNumber;
			if (this.rewardEffect != null)
			{
				this.rewardEffect.CustomActive(bActive);
			}
		}

		// Token: 0x0600CDEB RID: 52715 RVA: 0x0032BB49 File Offset: 0x00329F49
		private void OnRewardButtonClick()
		{
			if (this._rewardDataModel == null)
			{
				Logger.LogErrorFormat("RewardDataModel is null", new object[0]);
				return;
			}
			ChallengeUtility.OnOpenChallengeDungeonRewardFrame(this._rewardDataModel);
		}

		// Token: 0x04007837 RID: 30775
		private int _dungeonId;

		// Token: 0x04007838 RID: 30776
		private ChallengeDungeonRewardDataModel _rewardDataModel;

		// Token: 0x04007839 RID: 30777
		[SerializeField]
		private Text rewardTitleLabel;

		// Token: 0x0400783A RID: 30778
		[SerializeField]
		private Text rewardValueLabel;

		// Token: 0x0400783B RID: 30779
		[SerializeField]
		private GameObject rewardEffect;

		// Token: 0x0400783C RID: 30780
		[SerializeField]
		private Button rewardButton;
	}
}
