using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CA9 RID: 7337
	public class TeamDuplicationMiddleStageRewardView : MonoBehaviour
	{
		// Token: 0x0601201C RID: 73756 RVA: 0x00543730 File Offset: 0x00541B30
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0601201D RID: 73757 RVA: 0x00543738 File Offset: 0x00541B38
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
			base.StopAllCoroutines();
		}

		// Token: 0x0601201E RID: 73758 RVA: 0x0054374C File Offset: 0x00541B4C
		private void BindUiEvents()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(new OnCountDownTimeCallback(this.OnCloseFrame));
			}
		}

		// Token: 0x0601201F RID: 73759 RVA: 0x00543776 File Offset: 0x00541B76
		private void UnBindUiEvents()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(null);
			}
		}

		// Token: 0x06012020 RID: 73760 RVA: 0x00543795 File Offset: 0x00541B95
		private void ClearData()
		{
			this._stageId = 0;
			this._isIn65LevelTeamDuplication = false;
			this._countDownTime = 0f;
			this._fightStageMiddleRewardDataModelList = null;
			this._isShowCountDownTimeFinished = false;
		}

		// Token: 0x06012021 RID: 73761 RVA: 0x005437BE File Offset: 0x00541BBE
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x06012022 RID: 73762 RVA: 0x005437C6 File Offset: 0x00541BC6
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x06012023 RID: 73763 RVA: 0x005437CE File Offset: 0x00541BCE
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageRewardNotify));
		}

		// Token: 0x06012024 RID: 73764 RVA: 0x005437EB File Offset: 0x00541BEB
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageRewardNotify));
		}

		// Token: 0x06012025 RID: 73765 RVA: 0x00543808 File Offset: 0x00541C08
		public void Init(int stageId, bool isIn65LevelTeamDuplication = false, TC2PassType passType = TC2PassType.TC_2_PASS_TYPE_COMMON)
		{
			this._stageId = stageId;
			this._isIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
			this._passType = passType;
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetFightStageRewardDataModelList();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTargetFlopReq(this._stageId);
			this._countDownTime = (float)DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageRewardTime;
			if (this._stageId <= 0)
			{
				this._stageId = 1;
			}
			if (this._countDownTime <= 0f)
			{
				this._countDownTime = 3f;
			}
			this.InitView();
		}

		// Token: 0x06012026 RID: 73766 RVA: 0x00543889 File Offset: 0x00541C89
		private void InitView()
		{
			this.InitFightStageRewardCommonLabel();
			this.InitStageRewardItem();
			this.UpdateStageRewardCountDownTime(this._countDownTime);
			this.SetCloseFrameCountDownController();
		}

		// Token: 0x06012027 RID: 73767 RVA: 0x005438AC File Offset: 0x00541CAC
		private void SetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.EndTime = DataManager<TimeManager>.GetInstance().GetServerTime() + (uint)(this._countDownTime + (float)this._closeFrameIntervalTime);
			this.closeCountDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06012028 RID: 73768 RVA: 0x005438FB File Offset: 0x00541CFB
		private void ResetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.ResetCountDownTimeController();
		}

		// Token: 0x06012029 RID: 73769 RVA: 0x0054391C File Offset: 0x00541D1C
		private void InitFightStageRewardCommonLabel()
		{
			if (this.fightStageLabel == null)
			{
				return;
			}
			if (this._isIn65LevelTeamDuplication)
			{
				string text = TR.Value("team_duplication_team_name_with_65_level_in_Reward");
				if (this._passType == TC2PassType.TC_2_PASS_TYPE_ENHANCE)
				{
					text = TR.Value("team_duplication_team_name_with_65_level_strong_pass_in_Reward");
				}
				this.fightStageLabel.text = text;
			}
			else
			{
				string teamDuplicationStageDescription = TeamDuplicationUtility.GetTeamDuplicationStageDescription(this._stageId);
				if (!string.IsNullOrEmpty(teamDuplicationStageDescription))
				{
					this.fightStageLabel.text = teamDuplicationStageDescription;
				}
			}
		}

		// Token: 0x0601202A RID: 73770 RVA: 0x0054399C File Offset: 0x00541D9C
		private void InitStageRewardItem()
		{
			if (this.middleStageRewardItemList == null)
			{
				return;
			}
			for (int i = 0; i < this.middleStageRewardItemList.Count; i++)
			{
				TeamDuplicationMiddleStageRewardItem teamDuplicationMiddleStageRewardItem = this.middleStageRewardItemList[i];
				if (teamDuplicationMiddleStageRewardItem != null)
				{
					teamDuplicationMiddleStageRewardItem.Init(this._stageId);
				}
			}
		}

		// Token: 0x0601202B RID: 73771 RVA: 0x005439F6 File Offset: 0x00541DF6
		private void Update()
		{
			this.OnShowCountDownTimeUpdate();
		}

		// Token: 0x0601202C RID: 73772 RVA: 0x00543A00 File Offset: 0x00541E00
		private void OnShowCountDownTimeUpdate()
		{
			if (this._isShowCountDownTimeFinished)
			{
				return;
			}
			this._countDownTime -= Time.deltaTime;
			if (this._countDownTime <= -1f)
			{
				this._isShowCountDownTimeFinished = true;
				this.ResetCountDownTimeImage();
				this.StartMiddleStageRewardAction();
			}
			else
			{
				this.UpdateStageRewardCountDownTime(this._countDownTime + 1f);
			}
		}

		// Token: 0x0601202D RID: 73773 RVA: 0x00543A68 File Offset: 0x00541E68
		private void UpdateStageRewardCountDownTime(float countDownTime)
		{
			this.ResetCountDownTimeImage();
			int num = (int)countDownTime;
			if (num >= 5)
			{
				CommonUtility.UpdateImageVisible(this.countDownTimeFiveImage, true);
			}
			else if (num == 4)
			{
				CommonUtility.UpdateImageVisible(this.countDownTimeFourImage, true);
			}
			else if (num == 3)
			{
				CommonUtility.UpdateImageVisible(this.countDownTimeThreeImage, true);
			}
			else if (num == 2)
			{
				CommonUtility.UpdateImageVisible(this.countDownTimeSecondImage, true);
			}
			else if (num == 1)
			{
				CommonUtility.UpdateImageVisible(this.countDownTimeFirstImage, true);
			}
			else
			{
				CommonUtility.UpdateImageVisible(this.countDownTimeZeroImage, true);
			}
		}

		// Token: 0x0601202E RID: 73774 RVA: 0x00543B02 File Offset: 0x00541F02
		private void StartMiddleStageRewardAction()
		{
			this._rewardIndex = 0;
			base.InvokeRepeating("OnShowMiddleStageRewardAction", 0f, this._refreshInterval);
		}

		// Token: 0x0601202F RID: 73775 RVA: 0x00543B24 File Offset: 0x00541F24
		private void OnShowMiddleStageRewardAction()
		{
			if (this._fightStageMiddleRewardDataModelList == null || this._fightStageMiddleRewardDataModelList.Count <= 0 || this.middleStageRewardItemList == null || this.middleStageRewardItemList.Count <= 0)
			{
				this.CancelFinalStageRewardAction();
				return;
			}
			if (this._rewardIndex < 0 || this._rewardIndex >= this._fightStageMiddleRewardDataModelList.Count || this._rewardIndex >= this.middleStageRewardItemList.Count)
			{
				this.CancelFinalStageRewardAction();
				return;
			}
			TeamDuplicationFightStageRewardDataModel teamDuplicationFightStageRewardDataModel = this._fightStageMiddleRewardDataModelList[this._rewardIndex];
			if (teamDuplicationFightStageRewardDataModel != null)
			{
				for (int i = 0; i < this.middleStageRewardItemList.Count; i++)
				{
					TeamDuplicationMiddleStageRewardItem teamDuplicationMiddleStageRewardItem = this.middleStageRewardItemList[i];
					if (!(teamDuplicationMiddleStageRewardItem == null))
					{
						if (teamDuplicationMiddleStageRewardItem.GetRewardItemIndex() == teamDuplicationFightStageRewardDataModel.RewardIndex)
						{
							if (!teamDuplicationMiddleStageRewardItem.GetRewardItemInitState())
							{
								teamDuplicationMiddleStageRewardItem.UpdateRewardItem(teamDuplicationFightStageRewardDataModel);
							}
						}
					}
				}
			}
			this._rewardIndex++;
		}

		// Token: 0x06012030 RID: 73776 RVA: 0x00543C3C File Offset: 0x0054203C
		private void CancelFinalStageRewardAction()
		{
			base.CancelInvoke("OnShowMiddleStageRewardAction");
			this.DisappearMiddleStageUnRewardCardList();
			base.StartCoroutine(this.CloseFrameByIntervalTime());
		}

		// Token: 0x06012031 RID: 73777 RVA: 0x00543C5C File Offset: 0x0054205C
		private void DisappearMiddleStageUnRewardCardList()
		{
			if (this.middleStageRewardItemList != null)
			{
				for (int i = 0; i < this.middleStageRewardItemList.Count; i++)
				{
					TeamDuplicationMiddleStageRewardItem teamDuplicationMiddleStageRewardItem = this.middleStageRewardItemList[i];
					if (!(teamDuplicationMiddleStageRewardItem == null))
					{
						if (!teamDuplicationMiddleStageRewardItem.GetRewardItemInitState())
						{
							CommonUtility.UpdateGameObjectVisible(teamDuplicationMiddleStageRewardItem.gameObject, false);
						}
					}
				}
			}
		}

		// Token: 0x06012032 RID: 73778 RVA: 0x00543CCC File Offset: 0x005420CC
		private void OnReceiveTeamDuplicationFightStageRewardNotify(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num != this._stageId)
			{
				return;
			}
			this._fightStageMiddleRewardDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageRewardDataModelList;
		}

		// Token: 0x06012033 RID: 73779 RVA: 0x00543D14 File Offset: 0x00542114
		private void UpdateFightStageRewardItemList()
		{
			if (this._fightStageMiddleRewardDataModelList == null || this._fightStageMiddleRewardDataModelList.Count <= 0)
			{
				base.StartCoroutine(this.CloseFrameByIntervalTime());
				return;
			}
			for (int i = 0; i < this._fightStageMiddleRewardDataModelList.Count; i++)
			{
				TeamDuplicationFightStageRewardDataModel teamDuplicationFightStageRewardDataModel = this._fightStageMiddleRewardDataModelList[i];
				if (teamDuplicationFightStageRewardDataModel != null)
				{
					for (int j = 0; j < this.middleStageRewardItemList.Count; j++)
					{
						TeamDuplicationMiddleStageRewardItem teamDuplicationMiddleStageRewardItem = this.middleStageRewardItemList[j];
						if (!(teamDuplicationMiddleStageRewardItem == null))
						{
							if (teamDuplicationMiddleStageRewardItem.GetRewardItemIndex() == teamDuplicationFightStageRewardDataModel.RewardIndex)
							{
								if (!teamDuplicationMiddleStageRewardItem.GetRewardItemInitState())
								{
									teamDuplicationMiddleStageRewardItem.UpdateRewardItem(teamDuplicationFightStageRewardDataModel);
								}
							}
						}
					}
				}
			}
			if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationPlayerNumberInCaptain != this._fightStageMiddleRewardDataModelList.Count)
			{
				for (int k = 0; k < this.middleStageRewardItemList.Count; k++)
				{
					TeamDuplicationMiddleStageRewardItem teamDuplicationMiddleStageRewardItem2 = this.middleStageRewardItemList[k];
					if (!(teamDuplicationMiddleStageRewardItem2 == null))
					{
						if (!teamDuplicationMiddleStageRewardItem2.GetRewardItemInitState())
						{
							CommonUtility.UpdateGameObjectVisible(teamDuplicationMiddleStageRewardItem2.gameObject, false);
						}
					}
				}
			}
			base.StartCoroutine(this.CloseFrameByIntervalTime());
		}

		// Token: 0x06012034 RID: 73780 RVA: 0x00543E6C File Offset: 0x0054226C
		private IEnumerator CloseFrameByIntervalTime()
		{
			yield return new WaitForSeconds(this._rewardShowIntervalTime);
			this.OnCloseFrame();
			yield break;
		}

		// Token: 0x06012035 RID: 73781 RVA: 0x00543E88 File Offset: 0x00542288
		private void ResetCountDownTimeImage()
		{
			CommonUtility.UpdateImageVisible(this.countDownTimeZeroImage, false);
			CommonUtility.UpdateImageVisible(this.countDownTimeFirstImage, false);
			CommonUtility.UpdateImageVisible(this.countDownTimeSecondImage, false);
			CommonUtility.UpdateImageVisible(this.countDownTimeThreeImage, false);
			CommonUtility.UpdateImageVisible(this.countDownTimeFourImage, false);
			CommonUtility.UpdateImageVisible(this.countDownTimeFiveImage, false);
		}

		// Token: 0x06012036 RID: 73782 RVA: 0x00543EDD File Offset: 0x005422DD
		private void OnCloseFrame()
		{
			this.ResetCloseFrameCountDownController();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationMiddleStageRewardCloseMessage, this._stageId, null, null, null);
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetFightStageRewardDataModelList();
			DataManager<ItemTipManager>.GetInstance().CloseAll();
			TeamDuplicationUtility.OnCloseTeamDuplicationMiddleStageRewardFrame();
		}

		// Token: 0x0400BBAE RID: 48046
		private int _stageId;

		// Token: 0x0400BBAF RID: 48047
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400BBB0 RID: 48048
		private TC2PassType _passType;

		// Token: 0x0400BBB1 RID: 48049
		private float _countDownTime;

		// Token: 0x0400BBB2 RID: 48050
		private bool _isShowCountDownTimeFinished;

		// Token: 0x0400BBB3 RID: 48051
		private int _rewardIndex;

		// Token: 0x0400BBB4 RID: 48052
		private float _refreshInterval = 0.2f;

		// Token: 0x0400BBB5 RID: 48053
		private int _closeFrameIntervalTime = 7;

		// Token: 0x0400BBB6 RID: 48054
		private float _rewardShowIntervalTime = 2.5f;

		// Token: 0x0400BBB7 RID: 48055
		private List<TeamDuplicationFightStageRewardDataModel> _fightStageMiddleRewardDataModelList;

		// Token: 0x0400BBB8 RID: 48056
		[Space(15f)]
		[Header("Text")]
		[Space(10f)]
		[SerializeField]
		private Text fightStageLabel;

		// Token: 0x0400BBB9 RID: 48057
		[Space(15f)]
		[Header("CountDownTimeImage")]
		[Space(5f)]
		[SerializeField]
		private Image countDownTimeFiveImage;

		// Token: 0x0400BBBA RID: 48058
		[SerializeField]
		private Image countDownTimeFourImage;

		// Token: 0x0400BBBB RID: 48059
		[SerializeField]
		private Image countDownTimeThreeImage;

		// Token: 0x0400BBBC RID: 48060
		[SerializeField]
		private Image countDownTimeSecondImage;

		// Token: 0x0400BBBD RID: 48061
		[SerializeField]
		private Image countDownTimeFirstImage;

		// Token: 0x0400BBBE RID: 48062
		[SerializeField]
		private Image countDownTimeZeroImage;

		// Token: 0x0400BBBF RID: 48063
		[Space(15f)]
		[Header("CloseCountDownTimeController")]
		[Space(5f)]
		[SerializeField]
		private CountDownTimeController closeCountDownTimeController;

		// Token: 0x0400BBC0 RID: 48064
		[Space(15f)]
		[Header("RewardItem")]
		[Space(10f)]
		[SerializeField]
		private List<TeamDuplicationMiddleStageRewardItem> middleStageRewardItemList = new List<TeamDuplicationMiddleStageRewardItem>();
	}
}
