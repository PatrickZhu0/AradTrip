using System;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001507 RID: 5383
	public class ChampionshipMainView : MonoBehaviour
	{
		// Token: 0x0600D0FA RID: 53498 RVA: 0x00339278 File Offset: 0x00337678
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600D0FB RID: 53499 RVA: 0x00339280 File Offset: 0x00337680
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600D0FC RID: 53500 RVA: 0x00339290 File Offset: 0x00337690
		private void BindUiEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedLoadingFinish, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneChangeLoadingFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveChampionshipNotEnterFightSceneMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipNotEnterFightSceneMessage));
		}

		// Token: 0x0600D0FD RID: 53501 RVA: 0x0033930C File Offset: 0x0033770C
		private void UnBindUiEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipSelfStatusMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipStatusMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedLoadingFinish, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneChangeLoadingFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveChampionshipNotEnterFightSceneMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveChampionshipNotEnterFightSceneMessage));
		}

		// Token: 0x0600D0FE RID: 53502 RVA: 0x00339385 File Offset: 0x00337785
		private void ClearData()
		{
			this._scheduleTable = null;
			this._scheduleId = 0;
			this._isChampionshipScheduleInScoreTime = false;
			this._isKickOffFromChampionshipScoreSchedule = false;
		}

		// Token: 0x0600D0FF RID: 53503 RVA: 0x003393A3 File Offset: 0x003377A3
		public void InitView()
		{
			this.UpdateView();
		}

		// Token: 0x0600D100 RID: 53504 RVA: 0x003393AB File Offset: 0x003377AB
		private void UpdateView()
		{
			this._isChampionshipScheduleInScoreTime = false;
			this.InitData();
			if (this._scheduleTable == null)
			{
				return;
			}
			this._isChampionshipScheduleInScoreTime = ChampionshipUtility.IsInChampionshipScheduleScoreTime(this._scheduleTable);
			this.UpdateScheduleControl();
			this.UpdateCommonControl();
			this.UpdateButtonControl();
		}

		// Token: 0x0600D101 RID: 53505 RVA: 0x003393E9 File Offset: 0x003377E9
		private void InitData()
		{
			this._scheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
			this._scheduleTable = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(this._scheduleId, string.Empty, string.Empty);
		}

		// Token: 0x0600D102 RID: 53506 RVA: 0x0033941B File Offset: 0x0033781B
		private void UpdateScheduleControl()
		{
			if (this.scheduleControl != null)
			{
				this.scheduleControl.InitControl(this._scheduleTable);
			}
		}

		// Token: 0x0600D103 RID: 53507 RVA: 0x0033943F File Offset: 0x0033783F
		private void UpdateCommonControl()
		{
			if (this.commonControl != null)
			{
				this.commonControl.InitControl(this._scheduleTable);
			}
		}

		// Token: 0x0600D104 RID: 53508 RVA: 0x00339463 File Offset: 0x00337863
		private void UpdateCommonCountDownTimeContent()
		{
			if (this.commonControl != null)
			{
				this.commonControl.UpdateCountDownTimeContent();
			}
		}

		// Token: 0x0600D105 RID: 53509 RVA: 0x00339481 File Offset: 0x00337881
		private void UpdateButtonControl()
		{
			if (this.buttonControl != null)
			{
				this.buttonControl.InitControl(this._scheduleTable);
			}
		}

		// Token: 0x0600D106 RID: 53510 RVA: 0x003394A8 File Offset: 0x003378A8
		private void OnReceiveChampionshipStatusMessage(UIEvent uiEvent)
		{
			if (!DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime)
			{
				this._isKickOffFromChampionshipScoreSchedule = false;
				if (this._isChampionshipScheduleInScoreTime)
				{
				}
				this.UpdateMainViewByUnOpenChampionship();
				return;
			}
			if (this._scheduleId == DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId)
			{
				this.UpdateCommonCountDownTimeContent();
			}
			else
			{
				this.UpdateView();
			}
		}

		// Token: 0x0600D107 RID: 53511 RVA: 0x00339503 File Offset: 0x00337903
		private void OnReceiveSceneChangeLoadingFinish(UIEvent uiEvent)
		{
			if (!DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime)
			{
				this._isKickOffFromChampionshipScoreSchedule = false;
				this.UpdateMainViewByUnOpenChampionship();
				return;
			}
			if (this.commonControl != null)
			{
				this.commonControl.UpdatePlayerGroupContent();
			}
		}

		// Token: 0x0600D108 RID: 53512 RVA: 0x00339540 File Offset: 0x00337940
		private void UpdateMainViewByUnOpenChampionship()
		{
			if (this.commonControl != null)
			{
				this.commonControl.ResetTitleTipRoot();
			}
			if (this.scheduleControl != null)
			{
				this.scheduleControl.ResetMainScheduleControl();
			}
			CommonUtility.OnShowCommonMsgBoxWithMiddleButton(TR.Value("Championship_Is_Not_Open_In_Current_Time"), new Action(this.OnBackFromChampionshipScene), TR.Value("Championship_Return_Town_Label"));
		}

		// Token: 0x0600D109 RID: 53513 RVA: 0x003395AA File Offset: 0x003379AA
		private void OnBackFromChampionshipScene()
		{
			ChampionshipUtility.SwitchToBirthCitySceneInClientSystemTown(false);
		}

		// Token: 0x0600D10A RID: 53514 RVA: 0x003395B4 File Offset: 0x003379B4
		private void OnReceiveChampionshipNotEnterFightSceneMessage(UIEvent uiEvent)
		{
			string msgContent = TR.Value("Championship_Fight_Not_Enter_Fight");
			if (this._scheduleTable != null && (this._scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.SixtyFour_Select || this._scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.Sixteen_Select))
			{
				msgContent = TR.Value("Championship_Fight_Not_Enter_Fight_With_Add_Score");
			}
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x04007A5F RID: 31327
		private int _scheduleId;

		// Token: 0x04007A60 RID: 31328
		private ChampionshipScheduleTable _scheduleTable;

		// Token: 0x04007A61 RID: 31329
		private bool _isChampionshipScheduleInScoreTime;

		// Token: 0x04007A62 RID: 31330
		private bool _isKickOffFromChampionshipScoreSchedule;

		// Token: 0x04007A63 RID: 31331
		[Space(10f)]
		[Header("Schedule")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipMainScheduleControl scheduleControl;

		// Token: 0x04007A64 RID: 31332
		[Space(10f)]
		[Header("ButtonControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipMainButtonControl buttonControl;

		// Token: 0x04007A65 RID: 31333
		[Space(10f)]
		[Header("CommonControl")]
		[Space(10f)]
		[SerializeField]
		private ChampionshipMainCommonControl commonControl;
	}
}
