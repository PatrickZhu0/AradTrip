using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C5B RID: 7259
	public class TeamDuplicationFightEndVoteView : MonoBehaviour
	{
		// Token: 0x06011D2D RID: 73005 RVA: 0x005372B0 File Offset: 0x005356B0
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011D2E RID: 73006 RVA: 0x005372B8 File Offset: 0x005356B8
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011D2F RID: 73007 RVA: 0x005372C8 File Offset: 0x005356C8
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.refuseButton != null)
			{
				this.refuseButton.ResetButtonListener();
				this.refuseButton.SetButtonListener(new Action(this.OnRefuseButtonClick));
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.ResetButtonListener();
				this.agreeButton.SetButtonListener(new Action(this.OnAgreeButtonClick));
			}
			if (this.captainItemList != null)
			{
				this.captainItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.captainItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.captainItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(new OnCountDownTimeCallback(this.OnCloseFrame));
			}
		}

		// Token: 0x06011D30 RID: 73008 RVA: 0x0053740C File Offset: 0x0053580C
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.refuseButton != null)
			{
				this.refuseButton.ResetButtonListener();
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.ResetButtonListener();
			}
			if (this.captainItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.captainItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.captainItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(null);
			}
		}

		// Token: 0x06011D31 RID: 73009 RVA: 0x005374EE File Offset: 0x005358EE
		private void ClearData()
		{
			this._captainDataModelList = null;
			this._countDownTotalTime = 0f;
			this._countDownLeftTime = 0f;
			this._refuseIntervalTime = 0f;
			this._isAlreadyVote = false;
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011D32 RID: 73010 RVA: 0x00537526 File Offset: 0x00535926
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteAgreeMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteRefuseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteRefuseMessage));
		}

		// Token: 0x06011D33 RID: 73011 RVA: 0x0053755E File Offset: 0x0053595E
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteAgreeMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteRefuseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteRefuseMessage));
		}

		// Token: 0x06011D34 RID: 73012 RVA: 0x00537596 File Offset: 0x00535996
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011D35 RID: 73013 RVA: 0x005375A4 File Offset: 0x005359A4
		private void InitData()
		{
			this._countDownTotalTime = (float)DataManager<TeamDuplicationDataManager>.GetInstance().FightEndVoteIntervalTime;
			this._countDownLeftTime = (float)((long)DataManager<TeamDuplicationDataManager>.GetInstance().FightEndVoteEndTime - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()));
			if (this._countDownTotalTime <= 0f)
			{
				this._countDownTotalTime = 15f;
			}
			if (this._countDownLeftTime < 0f || this._countDownLeftTime > this._countDownTotalTime)
			{
				this._countDownLeftTime = this._countDownTotalTime;
			}
			this._refuseLeftTime = (int)this._countDownLeftTime;
			this._refuseIntervalTime = 0f;
			bool flag = TeamDuplicationUtility.IsPlayerAlreadyAgreeFightEndVote(DataManager<PlayerBaseData>.GetInstance().RoleID);
			bool flag2 = TeamDuplicationUtility.IsPlayerAlreadyRefuseFightEndVote(DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (flag || flag2)
			{
				this._isAlreadyVote = true;
			}
			else
			{
				this._isAlreadyVote = false;
			}
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
		}

		// Token: 0x06011D36 RID: 73014 RVA: 0x0053768A File Offset: 0x00535A8A
		private void InitView()
		{
			this.InitTitle();
			this.UpdateCaptainItemList();
			this.UpdateSliderValue(this._countDownLeftTime, this._countDownTotalTime);
			this.UpdateRefuseLeftTimeLabel();
			this.UpdateVoteViewByPlayerVote(this._isAlreadyVote);
			this.SetCloseFrameCountDownController();
		}

		// Token: 0x06011D37 RID: 73015 RVA: 0x005376C4 File Offset: 0x00535AC4
		private void SetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.EndTime = DataManager<TimeManager>.GetInstance().GetServerTime() + (uint)(this._countDownLeftTime + (float)this._closeFrameIntervalTime);
			this.closeCountDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06011D38 RID: 73016 RVA: 0x00537713 File Offset: 0x00535B13
		private void ResetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.ResetCountDownTimeController();
		}

		// Token: 0x06011D39 RID: 73017 RVA: 0x00537734 File Offset: 0x00535B34
		private void InitTitle()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("team_duplication_fight_end_confirm_title");
			}
			if (this.fightEndVoteDescriptionLabel != null)
			{
				this.fightEndVoteDescriptionLabel.text = TR.Value("team_duplication_fight_end_vote_description");
			}
		}

		// Token: 0x06011D3A RID: 73018 RVA: 0x0053778D File Offset: 0x00535B8D
		private void UpdateSliderValue(float leftTime, float totalTime)
		{
			if (leftTime < 0f)
			{
				leftTime = 0f;
			}
			if (leftTime > totalTime)
			{
				leftTime = totalTime;
			}
			if (this.timeSlider != null)
			{
				this.timeSlider.value = leftTime / totalTime;
			}
		}

		// Token: 0x06011D3B RID: 73019 RVA: 0x005377CC File Offset: 0x00535BCC
		private void UpdateCaptainItemList()
		{
			this._captainDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationCaptainDataModelList();
			if (this.captainItemList != null)
			{
				if (this._captainDataModelList == null || this._captainDataModelList.Count <= 0)
				{
					this.captainItemList.SetElementAmount(0);
				}
				else
				{
					int elementAmount = this._captainDataModelList.Count;
					if (this._isIn65LevelTeamDuplication)
					{
						elementAmount = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumberWith65Level;
					}
					this.captainItemList.SetElementAmount(elementAmount);
				}
			}
		}

		// Token: 0x06011D3C RID: 73020 RVA: 0x00537858 File Offset: 0x00535C58
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.captainItemList == null)
			{
				return;
			}
			if (this._captainDataModelList == null || this._captainDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._captainDataModelList.Count)
			{
				return;
			}
			TeamDuplicationFightVoteItem component = item.GetComponent<TeamDuplicationFightVoteItem>();
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = this._captainDataModelList[item.m_index];
			if (component != null && teamDuplicationCaptainDataModel != null)
			{
				component.Init(teamDuplicationCaptainDataModel, TeamDuplicationFightVoteType.FightEndVote);
			}
		}

		// Token: 0x06011D3D RID: 73021 RVA: 0x005378EC File Offset: 0x00535CEC
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.captainItemList == null)
			{
				return;
			}
			TeamDuplicationFightVoteItem component = item.GetComponent<TeamDuplicationFightVoteItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x06011D3E RID: 73022 RVA: 0x00537934 File Offset: 0x00535D34
		private void Update()
		{
			this._countDownLeftTime -= Time.deltaTime;
			if (this._countDownLeftTime < 0f)
			{
				this._countDownLeftTime = 0f;
			}
			this.UpdateSliderValue(this._countDownLeftTime, this._countDownTotalTime);
			this._refuseIntervalTime += Time.deltaTime;
			if (this._refuseIntervalTime >= 1f)
			{
				this._refuseIntervalTime = 0f;
				this._refuseLeftTime--;
				if (this._refuseLeftTime <= 0)
				{
					this._refuseLeftTime = 0;
				}
				this.UpdateRefuseLeftTimeLabel();
			}
		}

		// Token: 0x06011D3F RID: 73023 RVA: 0x005379D4 File Offset: 0x00535DD4
		private void UpdateRefuseLeftTimeLabel()
		{
		}

		// Token: 0x06011D40 RID: 73024 RVA: 0x005379D8 File Offset: 0x00535DD8
		private void OnReceiveTeamDuplicationFightEndVoteAgreeMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			this.UpdateVoteViewByPlayerVote(true);
		}

		// Token: 0x06011D41 RID: 73025 RVA: 0x00537A1C File Offset: 0x00535E1C
		private void OnReceiveTeamDuplicationFightEndVoteRefuseMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ulong num = (ulong)uiEvent.Param1;
			if (num != DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			this.UpdateVoteViewByPlayerVote(true);
		}

		// Token: 0x06011D42 RID: 73026 RVA: 0x00537A5F File Offset: 0x00535E5F
		private void UpdateVoteViewByPlayerVote(bool flag)
		{
			CommonUtility.UpdateGameObjectVisible(this.waitingRoot, flag);
			CommonUtility.UpdateGameObjectVisible(this.buttonRoot, !flag);
		}

		// Token: 0x06011D43 RID: 73027 RVA: 0x00537A7C File Offset: 0x00535E7C
		private void OnRefuseButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyForceEndVoteReq(false);
		}

		// Token: 0x06011D44 RID: 73028 RVA: 0x00537A89 File Offset: 0x00535E89
		private void OnAgreeButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyForceEndVoteReq(true);
		}

		// Token: 0x06011D45 RID: 73029 RVA: 0x00537A96 File Offset: 0x00535E96
		private void OnCloseButtonClick()
		{
			this.OnCloseFrame();
		}

		// Token: 0x06011D46 RID: 73030 RVA: 0x00537A9E File Offset: 0x00535E9E
		private void OnCloseFrame()
		{
			this.ResetCloseFrameCountDownController();
			TeamDuplicationUtility.OnCloseTeamDuplicationFightEndVoteFrame();
		}

		// Token: 0x0400B9A1 RID: 47521
		private float _countDownTotalTime;

		// Token: 0x0400B9A2 RID: 47522
		private float _countDownLeftTime;

		// Token: 0x0400B9A3 RID: 47523
		private float _refuseIntervalTime;

		// Token: 0x0400B9A4 RID: 47524
		private int _refuseLeftTime;

		// Token: 0x0400B9A5 RID: 47525
		private int _closeFrameIntervalTime = 3;

		// Token: 0x0400B9A6 RID: 47526
		private bool _isAlreadyVote;

		// Token: 0x0400B9A7 RID: 47527
		private List<TeamDuplicationCaptainDataModel> _captainDataModelList;

		// Token: 0x0400B9A8 RID: 47528
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B9A9 RID: 47529
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B9AA RID: 47530
		[SerializeField]
		private Text fightEndVoteDescriptionLabel;

		// Token: 0x0400B9AB RID: 47531
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B9AC RID: 47532
		[Space(15f)]
		[Header("ComUIListScript")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx captainItemList;

		// Token: 0x0400B9AD RID: 47533
		[Space(15f)]
		[Header("Slider")]
		[Space(10f)]
		[SerializeField]
		private GameObject sliderRoot;

		// Token: 0x0400B9AE RID: 47534
		[SerializeField]
		private Slider timeSlider;

		// Token: 0x0400B9AF RID: 47535
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private GameObject buttonRoot;

		// Token: 0x0400B9B0 RID: 47536
		[SerializeField]
		private ComButtonWithCd refuseButton;

		// Token: 0x0400B9B1 RID: 47537
		[SerializeField]
		private ComButtonWithCd agreeButton;

		// Token: 0x0400B9B2 RID: 47538
		[SerializeField]
		private GameObject waitingRoot;

		// Token: 0x0400B9B3 RID: 47539
		[SerializeField]
		private Text refuseLeftTimeText;

		// Token: 0x0400B9B4 RID: 47540
		[Space(15f)]
		[Header("CountDownTimeFrame")]
		[Space(10f)]
		[SerializeField]
		private CountDownTimeController closeCountDownTimeController;
	}
}
