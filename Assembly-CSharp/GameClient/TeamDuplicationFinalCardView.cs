using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C7F RID: 7295
	public class TeamDuplicationFinalCardView : MonoBehaviour
	{
		// Token: 0x06011E51 RID: 73297 RVA: 0x0053C411 File Offset: 0x0053A811
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011E52 RID: 73298 RVA: 0x0053C419 File Offset: 0x0053A819
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
			base.StopAllCoroutines();
		}

		// Token: 0x06011E53 RID: 73299 RVA: 0x0053C430 File Offset: 0x0053A830
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

		// Token: 0x06011E54 RID: 73300 RVA: 0x0053C4A2 File Offset: 0x0053A8A2
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

		// Token: 0x06011E55 RID: 73301 RVA: 0x0053C4E2 File Offset: 0x0053A8E2
		private void ClearData()
		{
			this._stageId = 0;
			this._finalStageRewardDataModelList = null;
			this._isReceiveRewardData = false;
			this._isNeedShowRewardItem = false;
			this._rewardCoverEffectRootIndex = 3;
			this._rewardCoverEffectCurInterval = 0;
		}

		// Token: 0x06011E56 RID: 73302 RVA: 0x0053C50E File Offset: 0x0053A90E
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x06011E57 RID: 73303 RVA: 0x0053C516 File Offset: 0x0053A916
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x06011E58 RID: 73304 RVA: 0x0053C51E File Offset: 0x0053A91E
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageRewardNotify));
		}

		// Token: 0x06011E59 RID: 73305 RVA: 0x0053C53B File Offset: 0x0053A93B
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageRewardNotify, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageRewardNotify));
		}

		// Token: 0x06011E5A RID: 73306 RVA: 0x0053C558 File Offset: 0x0053A958
		public void Init()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyReceiveFinalReward = true;
			this._stageId = 3;
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetFightStageRewardDataModelList();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTargetFlopReq(this._stageId);
			this._closeFrameIntervalTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFinalStageRewardTime;
			this._rewardCoverEffectRootIndex = 3;
			this._rewardCoverEffectCurInterval = 0;
			this.InitView();
		}

		// Token: 0x06011E5B RID: 73307 RVA: 0x0053C5B5 File Offset: 0x0053A9B5
		private void InitView()
		{
			this.SetCloseFrameCountDownController();
			this.LoadMiddleEffect();
		}

		// Token: 0x06011E5C RID: 73308 RVA: 0x0053C5C3 File Offset: 0x0053A9C3
		private void LoadMiddleEffect()
		{
			CommonUtility.LoadGameObjectWithPath(this.middleEffectRoot, this.middleEffectPath);
		}

		// Token: 0x06011E5D RID: 73309 RVA: 0x0053C5D7 File Offset: 0x0053A9D7
		private void Update()
		{
			this.OnShowRewardItemCoverEffectUpdate();
			this.OnShowFinalStageRewardActionUpdate();
			this.OnShowCloseButtonUpdate();
		}

		// Token: 0x06011E5E RID: 73310 RVA: 0x0053C5EC File Offset: 0x0053A9EC
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

		// Token: 0x06011E5F RID: 73311 RVA: 0x0053C650 File Offset: 0x0053AA50
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

		// Token: 0x06011E60 RID: 73312 RVA: 0x0053C68C File Offset: 0x0053AA8C
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

		// Token: 0x06011E61 RID: 73313 RVA: 0x0053C6E8 File Offset: 0x0053AAE8
		private void OnLoadRewardCoverEffectByIndex(int coverEffectRootIndex)
		{
			this.OnLoadOneCoverEffect(coverEffectRootIndex);
			int effectRootIndex = coverEffectRootIndex + 3;
			this.OnLoadOneCoverEffect(effectRootIndex);
		}

		// Token: 0x06011E62 RID: 73314 RVA: 0x0053C70C File Offset: 0x0053AB0C
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

		// Token: 0x06011E63 RID: 73315 RVA: 0x0053C770 File Offset: 0x0053AB70
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

		// Token: 0x06011E64 RID: 73316 RVA: 0x0053C7D7 File Offset: 0x0053ABD7
		private void StartFinalStageRewardAction()
		{
			this._rewardIndex = 0;
			base.InvokeRepeating("OnShowFinalStageRewardAction", 0f, this._refreshInterval);
		}

		// Token: 0x06011E65 RID: 73317 RVA: 0x0053C7F8 File Offset: 0x0053ABF8
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

		// Token: 0x06011E66 RID: 73318 RVA: 0x0053C8C2 File Offset: 0x0053ACC2
		private void CancelFinalStageRewardAction()
		{
			base.CancelInvoke("OnShowFinalStageRewardAction");
			this.SetCloseButtonAction();
			this.DisappearFinalStageUnRewardCardList();
		}

		// Token: 0x06011E67 RID: 73319 RVA: 0x0053C8DC File Offset: 0x0053ACDC
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

		// Token: 0x06011E68 RID: 73320 RVA: 0x0053C937 File Offset: 0x0053AD37
		private void SetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.EndTime = DataManager<TimeManager>.GetInstance().GetServerTime() + this._closeFrameIntervalTime;
			this.closeCountDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06011E69 RID: 73321 RVA: 0x0053C972 File Offset: 0x0053AD72
		private void ResetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.ResetCountDownTimeController();
		}

		// Token: 0x06011E6A RID: 73322 RVA: 0x0053C991 File Offset: 0x0053AD91
		private void SetCloseButtonAction()
		{
			this._curShowCloseButtonLeftTime = this.showCloseButtonIntervalTime;
		}

		// Token: 0x06011E6B RID: 73323 RVA: 0x0053C99F File Offset: 0x0053AD9F
		private void ShowCloseButton()
		{
			CommonUtility.UpdateButtonVisible(this.closeButton, true);
		}

		// Token: 0x06011E6C RID: 73324 RVA: 0x0053C9AD File Offset: 0x0053ADAD
		private void OnCloseFrame()
		{
			this.ResetCloseFrameCountDownController();
			this.CancelFinalStageRewardAction();
			TeamDuplicationUtility.OnCloseTeamDuplicationFinalCardFrame();
		}

		// Token: 0x0400BA7A RID: 47738
		private string middleEffectPath = "Effects/Scene_effects/EffectUI/chouka/EffUI_chouka_tuanben_zhankai_zhong";

		// Token: 0x0400BA7B RID: 47739
		private int _stageId;

		// Token: 0x0400BA7C RID: 47740
		private uint _closeFrameIntervalTime;

		// Token: 0x0400BA7D RID: 47741
		private float _refreshInterval = 0.2f;

		// Token: 0x0400BA7E RID: 47742
		private int _rewardIndex;

		// Token: 0x0400BA7F RID: 47743
		private float _curShowCloseButtonLeftTime;

		// Token: 0x0400BA80 RID: 47744
		private bool _isReceiveRewardData;

		// Token: 0x0400BA81 RID: 47745
		private bool _isNeedShowRewardItem;

		// Token: 0x0400BA82 RID: 47746
		private List<TeamDuplicationFightStageRewardDataModel> _finalStageRewardDataModelList;

		// Token: 0x0400BA83 RID: 47747
		private const int RewardCoverEffectTimeInterval = 1;

		// Token: 0x0400BA84 RID: 47748
		private int _rewardCoverEffectCurInterval;

		// Token: 0x0400BA85 RID: 47749
		private int _rewardCoverEffectRootIndex = 3;

		// Token: 0x0400BA86 RID: 47750
		private const int RewardCoverEffectNumberPerLine = 3;

		// Token: 0x0400BA87 RID: 47751
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private float waitActionTime = 1.3f;

		// Token: 0x0400BA88 RID: 47752
		[SerializeField]
		private float showCloseButtonIntervalTime = 5f;

		// Token: 0x0400BA89 RID: 47753
		[SerializeField]
		private CountDownTimeController closeCountDownTimeController;

		// Token: 0x0400BA8A RID: 47754
		[Space(15f)]
		[Header("StageCard")]
		[Space(10f)]
		[SerializeField]
		private List<TeamDuplicationFinalStageCardItem> finalStageCardItemList = new List<TeamDuplicationFinalStageCardItem>();

		// Token: 0x0400BA8B RID: 47755
		[Space(15f)]
		[Header("StageCardMiddleEffect")]
		[Space(10f)]
		[SerializeField]
		private GameObject middleEffectRoot;

		// Token: 0x0400BA8C RID: 47756
		[Space(15f)]
		[Header("CloseButton")]
		[Space(15f)]
		[SerializeField]
		private Button closeButton;
	}
}
