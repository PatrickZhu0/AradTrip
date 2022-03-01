using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CA5 RID: 7333
	public class TeamDuplicationFinalStageCardView : MonoBehaviour
	{
		// Token: 0x06011FEA RID: 73706 RVA: 0x00542E69 File Offset: 0x00541269
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011FEB RID: 73707 RVA: 0x00542E71 File Offset: 0x00541271
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
			base.StopAllCoroutines();
		}

		// Token: 0x06011FEC RID: 73708 RVA: 0x00542E88 File Offset: 0x00541288
		private void BindUiEvents()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(new OnCountDownTimeCallback(this.OnCloseFrame));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x06011FED RID: 73709 RVA: 0x00542EFA File Offset: 0x005412FA
		private void UnBindUiEvents()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(null);
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011FEE RID: 73710 RVA: 0x00542F3A File Offset: 0x0054133A
		private void ClearData()
		{
			this._stageId = 0;
			this._finalStageRewardDataModelList = null;
			this._isReceiveRewardData = false;
			this._isNeedShowRewardItem = false;
			this._rewardCoverEffectRootIndex = 4;
			this._rewardCoverEffectCurInterval = 0;
		}

		// Token: 0x06011FEF RID: 73711 RVA: 0x00542F66 File Offset: 0x00541366
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x06011FF0 RID: 73712 RVA: 0x00542F6E File Offset: 0x0054136E
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x06011FF1 RID: 73713 RVA: 0x00542F76 File Offset: 0x00541376
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageRewardNotify));
		}

		// Token: 0x06011FF2 RID: 73714 RVA: 0x00542F93 File Offset: 0x00541393
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageRewardNotify));
		}

		// Token: 0x06011FF3 RID: 73715 RVA: 0x00542FB0 File Offset: 0x005413B0
		public void Init()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyReceiveFinalReward = true;
			this._stageId = 3;
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetFightStageRewardDataModelList();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTargetFlopReq(this._stageId);
			this._closeFrameIntervalTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFinalStageRewardTime;
			this._rewardCoverEffectRootIndex = 4;
			this._rewardCoverEffectCurInterval = 0;
			this.InitView();
		}

		// Token: 0x06011FF4 RID: 73716 RVA: 0x0054300D File Offset: 0x0054140D
		private void InitView()
		{
			this.SetCloseFrameCountDownController();
			this.LoadMiddleEffect();
		}

		// Token: 0x06011FF5 RID: 73717 RVA: 0x0054301B File Offset: 0x0054141B
		private void LoadMiddleEffect()
		{
			CommonUtility.LoadGameObjectWithPath(this.middleEffectRoot, this.middleEffectPath);
		}

		// Token: 0x06011FF6 RID: 73718 RVA: 0x0054302F File Offset: 0x0054142F
		private void Update()
		{
			this.OnShowRewardItemCoverEffectUpdate();
			this.OnShowFinalStageRewardActionUpdate();
			this.OnShowCloseButtonUpdate();
		}

		// Token: 0x06011FF7 RID: 73719 RVA: 0x00543044 File Offset: 0x00541444
		private void OnShowFinalStageRewardActionUpdate()
		{
			if (this.waitActionTime <= 0f)
			{
				return;
			}
			this.waitActionTime -= Time.deltaTime;
			if (this.waitActionTime <= 0f)
			{
				if (this._isReceiveRewardData)
				{
					this._isNeedShowRewardItem = false;
					this.StartFinalStageRewardAction();
				}
				else
				{
					this._isNeedShowRewardItem = true;
				}
			}
		}

		// Token: 0x06011FF8 RID: 73720 RVA: 0x005430A8 File Offset: 0x005414A8
		private void OnShowCloseButtonUpdate()
		{
			if (this._curShowCloseButtonLeftTime <= 0f)
			{
				return;
			}
			this._curShowCloseButtonLeftTime -= Time.deltaTime;
			if (this._curShowCloseButtonLeftTime <= 0f)
			{
				this.ShowCloseButton();
			}
		}

		// Token: 0x06011FF9 RID: 73721 RVA: 0x005430E4 File Offset: 0x005414E4
		private void OnShowRewardItemCoverEffectUpdate()
		{
			if (this._rewardCoverEffectRootIndex <= 0)
			{
				return;
			}
			if (this._rewardCoverEffectCurInterval < 1)
			{
				this._rewardCoverEffectCurInterval++;
			}
			else
			{
				this.OnLoadRewardCoverEffectByIndex(this._rewardCoverEffectRootIndex);
				this._rewardCoverEffectCurInterval = 0;
				this._rewardCoverEffectRootIndex--;
			}
		}

		// Token: 0x06011FFA RID: 73722 RVA: 0x00543140 File Offset: 0x00541540
		private void OnLoadRewardCoverEffectByIndex(int coverEffectRootIndex)
		{
			this.OnLoadOneCoverEffect(coverEffectRootIndex);
			int effectRootIndex = coverEffectRootIndex + 4;
			this.OnLoadOneCoverEffect(effectRootIndex);
			int effectRootIndex2 = coverEffectRootIndex + 8;
			this.OnLoadOneCoverEffect(effectRootIndex2);
		}

		// Token: 0x06011FFB RID: 73723 RVA: 0x0054316C File Offset: 0x0054156C
		private void OnLoadOneCoverEffect(int effectRootIndex)
		{
			if (this.finalStageCardItemList == null || this.finalStageCardItemList.Count <= 0)
			{
				return;
			}
			if (effectRootIndex >= 1 && effectRootIndex <= this.finalStageCardItemList.Count)
			{
				TeamDuplicationFinalStageCardItem teamDuplicationFinalStageCardItem = this.finalStageCardItemList[effectRootIndex - 1];
				if (teamDuplicationFinalStageCardItem != null)
				{
					teamDuplicationFinalStageCardItem.LoadStageCardCoverEffect();
				}
			}
		}

		// Token: 0x06011FFC RID: 73724 RVA: 0x005431D0 File Offset: 0x005415D0
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
			this._finalStageRewardDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageRewardDataModelList;
			this._isReceiveRewardData = true;
			if (this._isNeedShowRewardItem)
			{
				this._isNeedShowRewardItem = false;
				this.StartFinalStageRewardAction();
			}
		}

		// Token: 0x06011FFD RID: 73725 RVA: 0x00543237 File Offset: 0x00541637
		private void StartFinalStageRewardAction()
		{
			this._rewardIndex = 0;
			base.InvokeRepeating("OnShowFinalStageRewardAction", 0f, this._refreshInterval);
		}

		// Token: 0x06011FFE RID: 73726 RVA: 0x00543258 File Offset: 0x00541658
		private void OnShowFinalStageRewardAction()
		{
			if (this._finalStageRewardDataModelList == null || this._finalStageRewardDataModelList.Count <= 0 || this.finalStageCardItemList == null || this.finalStageCardItemList.Count <= 0)
			{
				this.CancelFinalStageRewardAction();
				return;
			}
			if (this._rewardIndex >= this._finalStageRewardDataModelList.Count || this._rewardIndex >= this.finalStageCardItemList.Count)
			{
				this.CancelFinalStageRewardAction();
				return;
			}
			TeamDuplicationFightStageRewardDataModel teamDuplicationFightStageRewardDataModel = this._finalStageRewardDataModelList[this._rewardIndex];
			TeamDuplicationFinalStageCardItem teamDuplicationFinalStageCardItem = this.finalStageCardItemList[this._rewardIndex];
			if (teamDuplicationFightStageRewardDataModel != null && teamDuplicationFinalStageCardItem != null)
			{
				teamDuplicationFinalStageCardItem.Init(teamDuplicationFightStageRewardDataModel);
			}
			this._rewardIndex++;
		}

		// Token: 0x06011FFF RID: 73727 RVA: 0x00543322 File Offset: 0x00541722
		private void CancelFinalStageRewardAction()
		{
			base.CancelInvoke("OnShowFinalStageRewardAction");
			this.SetCloseButtonAction();
			this.DisappearFinalStageUnRewardCardList();
		}

		// Token: 0x06012000 RID: 73728 RVA: 0x0054333C File Offset: 0x0054173C
		private void DisappearFinalStageUnRewardCardList()
		{
			for (int i = 0; i < this.finalStageCardItemList.Count; i++)
			{
				TeamDuplicationFinalStageCardItem teamDuplicationFinalStageCardItem = this.finalStageCardItemList[i];
				if (teamDuplicationFinalStageCardItem != null && teamDuplicationFinalStageCardItem.GetFightStageRewardDataModel() == null)
				{
					CommonUtility.UpdateGameObjectVisible(teamDuplicationFinalStageCardItem.gameObject, false);
				}
			}
		}

		// Token: 0x06012001 RID: 73729 RVA: 0x00543397 File Offset: 0x00541797
		private void SetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.EndTime = DataManager<TimeManager>.GetInstance().GetServerTime() + this._closeFrameIntervalTime;
			this.closeCountDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06012002 RID: 73730 RVA: 0x005433D2 File Offset: 0x005417D2
		private void ResetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.ResetCountDownTimeController();
		}

		// Token: 0x06012003 RID: 73731 RVA: 0x005433F1 File Offset: 0x005417F1
		private void SetCloseButtonAction()
		{
			this._curShowCloseButtonLeftTime = this.showCloseButtonIntervalTime;
		}

		// Token: 0x06012004 RID: 73732 RVA: 0x005433FF File Offset: 0x005417FF
		private void ShowCloseButton()
		{
			CommonUtility.UpdateButtonVisible(this.closeButton, true);
		}

		// Token: 0x06012005 RID: 73733 RVA: 0x0054340D File Offset: 0x0054180D
		private void OnCloseFrame()
		{
			this.ResetCloseFrameCountDownController();
			this.CancelFinalStageRewardAction();
			TeamDuplicationUtility.OnCloseTeamDuplicationFinalStageCardFrame();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightStageEndShowFinishMessage, null, null, null, null);
		}

		// Token: 0x0400BB93 RID: 48019
		private string middleEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_zhankai_zhong";

		// Token: 0x0400BB94 RID: 48020
		private int _stageId;

		// Token: 0x0400BB95 RID: 48021
		private uint _closeFrameIntervalTime;

		// Token: 0x0400BB96 RID: 48022
		private float _refreshInterval = 0.2f;

		// Token: 0x0400BB97 RID: 48023
		private int _rewardIndex;

		// Token: 0x0400BB98 RID: 48024
		private float _curShowCloseButtonLeftTime;

		// Token: 0x0400BB99 RID: 48025
		private bool _isReceiveRewardData;

		// Token: 0x0400BB9A RID: 48026
		private bool _isNeedShowRewardItem;

		// Token: 0x0400BB9B RID: 48027
		private List<TeamDuplicationFightStageRewardDataModel> _finalStageRewardDataModelList;

		// Token: 0x0400BB9C RID: 48028
		private const int RewardCoverEffectTimeInterval = 1;

		// Token: 0x0400BB9D RID: 48029
		private int _rewardCoverEffectCurInterval;

		// Token: 0x0400BB9E RID: 48030
		private int _rewardCoverEffectRootIndex = 4;

		// Token: 0x0400BB9F RID: 48031
		private const int RewardCoverEffectNumberPerLine = 4;

		// Token: 0x0400BBA0 RID: 48032
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private float waitActionTime = 1.3f;

		// Token: 0x0400BBA1 RID: 48033
		[SerializeField]
		private float showCloseButtonIntervalTime = 5f;

		// Token: 0x0400BBA2 RID: 48034
		[SerializeField]
		private CountDownTimeController closeCountDownTimeController;

		// Token: 0x0400BBA3 RID: 48035
		[Space(15f)]
		[Header("StageCard")]
		[Space(10f)]
		[SerializeField]
		private List<TeamDuplicationFinalStageCardItem> finalStageCardItemList = new List<TeamDuplicationFinalStageCardItem>();

		// Token: 0x0400BBA4 RID: 48036
		[Space(15f)]
		[Header("StageCardMiddleEffect")]
		[Space(10f)]
		[SerializeField]
		private GameObject middleEffectRoot;

		// Token: 0x0400BBA5 RID: 48037
		[Space(15f)]
		[Header("CloseButton")]
		[Space(15f)]
		[SerializeField]
		private Button closeButton;
	}
}
