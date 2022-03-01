using System;
using System.Collections.Generic;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C5D RID: 7261
	public class TeamDuplicationFightStartVoteView : MonoBehaviour
	{
		// Token: 0x06011D4D RID: 73037 RVA: 0x00537B0E File Offset: 0x00535F0E
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011D4E RID: 73038 RVA: 0x00537B16 File Offset: 0x00535F16
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011D4F RID: 73039 RVA: 0x00537B24 File Offset: 0x00535F24
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

		// Token: 0x06011D50 RID: 73040 RVA: 0x00537C68 File Offset: 0x00536068
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

		// Token: 0x06011D51 RID: 73041 RVA: 0x00537D4A File Offset: 0x0053614A
		private void ClearData()
		{
			this._captainDataModelList = null;
			this._countDownTotalTime = 0f;
			this._countDownLeftTime = 0f;
			this._isAlreadyAgree = false;
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011D52 RID: 73042 RVA: 0x00537D77 File Offset: 0x00536177
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStartVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStartVoteAgreeMessage));
		}

		// Token: 0x06011D53 RID: 73043 RVA: 0x00537D94 File Offset: 0x00536194
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStartVoteAgreeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStartVoteAgreeMessage));
		}

		// Token: 0x06011D54 RID: 73044 RVA: 0x00537DB1 File Offset: 0x005361B1
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011D55 RID: 73045 RVA: 0x00537DC0 File Offset: 0x005361C0
		private void InitData()
		{
			this._countDownTotalTime = (float)DataManager<TeamDuplicationDataManager>.GetInstance().StartBattleVoteIntervalTime;
			this._countDownLeftTime = (float)((long)DataManager<TeamDuplicationDataManager>.GetInstance().StartBattleVoteEndTime - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()));
			if (this._countDownTotalTime <= 0f)
			{
				this._countDownTotalTime = 15f;
			}
			if (this._countDownLeftTime < 0f || this._countDownLeftTime > this._countDownTotalTime)
			{
				this._countDownLeftTime = this._countDownTotalTime;
			}
			this._isAlreadyAgree = TeamDuplicationUtility.IsPlayerAlreadyAgreeFightStartVote(DataManager<PlayerBaseData>.GetInstance().RoleID);
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
		}

		// Token: 0x06011D56 RID: 73046 RVA: 0x00537E64 File Offset: 0x00536264
		private void InitView()
		{
			this.InitTitle();
			this.UpdateCaptainItemList();
			this.UpdateSliderValue(this._countDownLeftTime, this._countDownTotalTime);
			this.UpdateVoteViewByPlayerAgree(this._isAlreadyAgree);
			this.SetCloseFrameCountDownController();
		}

		// Token: 0x06011D57 RID: 73047 RVA: 0x00537E98 File Offset: 0x00536298
		private void SetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.EndTime = DataManager<TimeManager>.GetInstance().GetServerTime() + (uint)(this._countDownTotalTime + (float)this._closeFrameIntervalTime);
			this.closeCountDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06011D58 RID: 73048 RVA: 0x00537EE7 File Offset: 0x005362E7
		private void ResetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.ResetCountDownTimeController();
		}

		// Token: 0x06011D59 RID: 73049 RVA: 0x00537F08 File Offset: 0x00536308
		private void InitTitle()
		{
			if (this.titleLabel == null)
			{
				return;
			}
			if (this._isIn65LevelTeamDuplication)
			{
				this.titleLabel.text = TR.Value("team_duplication_team_name_with_65_level");
			}
			else if (TeamDuplicationUtility.IsTeamDuplicationTeamDifficultyHardLevel())
			{
				this.titleLabel.text = TR.Value("team_duplication_hard_level_format");
			}
			else
			{
				this.titleLabel.text = TR.Value("team_duplication_normal_Level_format");
			}
		}

		// Token: 0x06011D5A RID: 73050 RVA: 0x00537F85 File Offset: 0x00536385
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

		// Token: 0x06011D5B RID: 73051 RVA: 0x00537FC4 File Offset: 0x005363C4
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

		// Token: 0x06011D5C RID: 73052 RVA: 0x00538050 File Offset: 0x00536450
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
				component.Init(teamDuplicationCaptainDataModel, TeamDuplicationFightVoteType.FightStartVote);
			}
		}

		// Token: 0x06011D5D RID: 73053 RVA: 0x005380E4 File Offset: 0x005364E4
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

		// Token: 0x06011D5E RID: 73054 RVA: 0x0053812C File Offset: 0x0053652C
		private void Update()
		{
			this._countDownLeftTime -= Time.deltaTime;
			if (this._countDownLeftTime < 0f)
			{
				this._countDownLeftTime = 0f;
			}
			this.UpdateSliderValue(this._countDownLeftTime, this._countDownTotalTime);
		}

		// Token: 0x06011D5F RID: 73055 RVA: 0x00538178 File Offset: 0x00536578
		private void OnReceiveTeamDuplicationFightStartVoteAgreeMessage(UIEvent uiEvent)
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
			this.UpdateVoteViewByPlayerAgree(true);
		}

		// Token: 0x06011D60 RID: 73056 RVA: 0x005381BB File Offset: 0x005365BB
		private void UpdateVoteViewByPlayerAgree(bool flag)
		{
			CommonUtility.UpdateGameObjectVisible(this.waitingRoot, flag);
			CommonUtility.UpdateGameObjectVisible(this.buttonRoot, !flag);
		}

		// Token: 0x06011D61 RID: 73057 RVA: 0x005381D8 File Offset: 0x005365D8
		private void OnRefuseButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartBattleVote(false);
		}

		// Token: 0x06011D62 RID: 73058 RVA: 0x005381E5 File Offset: 0x005365E5
		private void OnAgreeButtonClick()
		{
			if (TeamDuplicationUtility.IsTeamDuplicationInBuildScene())
			{
				this.ForwardFightSceneAndAgreeFight();
			}
			else
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartBattleVote(true);
			}
		}

		// Token: 0x06011D63 RID: 73059 RVA: 0x00538207 File Offset: 0x00536607
		private void ForwardFightSceneAndAgreeFight()
		{
			this.OnCloseFrame();
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsInStartBattleVotingTime)
			{
				TeamDuplicationUtility.SwitchTeamDuplicationToFightSceneByAgreeBattle();
			}
		}

		// Token: 0x06011D64 RID: 73060 RVA: 0x00538223 File Offset: 0x00536623
		private void OnCloseButtonClick()
		{
			this.OnCloseFrame();
		}

		// Token: 0x06011D65 RID: 73061 RVA: 0x0053822B File Offset: 0x0053662B
		private void OnCloseFrame()
		{
			this.ResetCloseFrameCountDownController();
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStartVoteFrame();
		}

		// Token: 0x0400B9B6 RID: 47542
		private float _countDownTotalTime;

		// Token: 0x0400B9B7 RID: 47543
		private float _countDownLeftTime;

		// Token: 0x0400B9B8 RID: 47544
		private int _closeFrameIntervalTime = 3;

		// Token: 0x0400B9B9 RID: 47545
		private bool _isAlreadyAgree;

		// Token: 0x0400B9BA RID: 47546
		private List<TeamDuplicationCaptainDataModel> _captainDataModelList;

		// Token: 0x0400B9BB RID: 47547
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B9BC RID: 47548
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B9BD RID: 47549
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B9BE RID: 47550
		[Space(15f)]
		[Header("ComUIListScript")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx captainItemList;

		// Token: 0x0400B9BF RID: 47551
		[Space(15f)]
		[Header("Slider")]
		[Space(10f)]
		[SerializeField]
		private GameObject sliderRoot;

		// Token: 0x0400B9C0 RID: 47552
		[SerializeField]
		private Slider timeSlider;

		// Token: 0x0400B9C1 RID: 47553
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private GameObject buttonRoot;

		// Token: 0x0400B9C2 RID: 47554
		[SerializeField]
		private ComButtonWithCd refuseButton;

		// Token: 0x0400B9C3 RID: 47555
		[SerializeField]
		private ComButtonWithCd agreeButton;

		// Token: 0x0400B9C4 RID: 47556
		[SerializeField]
		private GameObject waitingRoot;

		// Token: 0x0400B9C5 RID: 47557
		[Space(15f)]
		[Header("CountDownTimeFrame")]
		[Space(10f)]
		[SerializeField]
		private CountDownTimeController closeCountDownTimeController;
	}
}
