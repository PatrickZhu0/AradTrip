using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001062 RID: 4194
	[LoggerModel("NewbieGuide")]
	public class NewbieGuideManager : Singleton<NewbieGuideManager>
	{
		// Token: 0x06009D47 RID: 40263 RVA: 0x001EEC57 File Offset: 0x001ED057
		public void Load()
		{
			this._loadEnv();
			this._loadEvent();
		}

		// Token: 0x06009D48 RID: 40264 RVA: 0x001EEC65 File Offset: 0x001ED065
		public void Unload()
		{
			this._unloadEnv();
			this._unloadEvent();
			this._clearData();
		}

		// Token: 0x06009D49 RID: 40265 RVA: 0x001EEC79 File Offset: 0x001ED079
		public void Reset()
		{
			this._unloadEvent();
			this._loadEvent();
			this._clearData();
		}

		// Token: 0x06009D4A RID: 40266 RVA: 0x001EEC8D File Offset: 0x001ED08D
		private void _loadEnv()
		{
			this.mNewbieGuideManagerObject = Utility.FindGameObject("NewbieGuideManager", false);
			if (this.mNewbieGuideManagerObject == null)
			{
				this.mNewbieGuideManagerObject = new GameObject("NewbieGuideManager");
				Object.DontDestroyOnLoad(this.mNewbieGuideManagerObject);
			}
		}

		// Token: 0x06009D4B RID: 40267 RVA: 0x001EECCC File Offset: 0x001ED0CC
		private void _unloadEnv()
		{
			if (this.mNewbieGuideManagerObject != null)
			{
				Object.Destroy(this.mNewbieGuideManagerObject);
				this.mNewbieGuideManagerObject = null;
			}
		}

		// Token: 0x06009D4C RID: 40268 RVA: 0x001EECF4 File Offset: 0x001ED0F4
		private void _clearData()
		{
			this.bStartGuide = false;
			this.fGuideStateIntrval = 0f;
			this.mState = eNewbieGuideState.None;
			if (this.mGuideControl != null)
			{
				this.mGuideControl.ClearData();
			}
			if (this.mForceGuideUnits != null)
			{
				this.mForceGuideUnits.Clear();
			}
			if (this.mWeakGuideUnits != null)
			{
				this.mWeakGuideUnits.Clear();
			}
			if (this.mAloneGuideUnits != null)
			{
				this.mAloneGuideUnits.Clear();
			}
			if (this.mFinishDialogGuideUnits != null)
			{
				this.mFinishDialogGuideUnits.Clear();
			}
			if (this.mAcceptMissionGuideUnits != null)
			{
				this.mAcceptMissionGuideUnits.Clear();
			}
			if (this.mFinishMissionGuideUnits != null)
			{
				this.mFinishMissionGuideUnits.Clear();
			}
			if (this.mReceiveMissionRewardGuideUnits != null)
			{
				this.mReceiveMissionRewardGuideUnits.Clear();
			}
		}

		// Token: 0x06009D4D RID: 40269 RVA: 0x001EEDD0 File Offset: 0x001ED1D0
		private void _loadEvent()
		{
			this._rigsterEventHanble(EUIEventID.InitNewbieGuideBootData, new ClientEventSystem.UIEventHandler(this.OnInitGuideBootData));
			this._rigsterEventHanble(EUIEventID.InitializeTownSystem, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.SystemLoadingCompelete, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.SystemChanged, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.SceneChangedFinish, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.BattleInitFinished, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.DungeonOnFight, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.FrameClose, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.FadeInOver, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.CheckAllNewbieGuide, new ClientEventSystem.UIEventHandler(this.CheckAll));
			this._rigsterEventHanble(EUIEventID.FinishTalkDialog, new ClientEventSystem.UIEventHandler(this.OnCheckFinishTalkDialogGuide));
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnCheckAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Combine(instance2.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnCheckFinishMission));
			this._rigsterEventHanble(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.OnCheckAcceptMissionReward));
			this._rigsterEventHanble(EUIEventID.GuankaFrameOpen, new ClientEventSystem.UIEventHandler(this.OnCheckGunakaGuide));
			this._rigsterEventHanble(EUIEventID.DungeonRewardFrameOpen, new ClientEventSystem.UIEventHandler(this.OnCheckDungeonRewardGuide));
			this._rigsterEventHanble(EUIEventID.DungeonRewardFrameClose, new ClientEventSystem.UIEventHandler(this.OnCheckReturnToTownGuide));
			this._rigsterEventHanble(EUIEventID.ChangeJobFinishFrameOpen, new ClientEventSystem.UIEventHandler(this.OnCheckChangeJobSkillGuide));
			this._rigsterEventHanble(EUIEventID.ChangeJobSelectFrameOpen, new ClientEventSystem.UIEventHandler(this.OnCheckChangeJobSelectGuide));
			this._rigsterEventHanble(EUIEventID.TaskDialogFrameOpen, new ClientEventSystem.UIEventHandler(this.CheckPauseState));
			this._rigsterEventHanble(EUIEventID.FrameClose, new ClientEventSystem.UIEventHandler(this.CheckPauseState));
			for (int i = 0; i < this.bindEventDataList.Count; i++)
			{
				NewbieGuideManager.EventBindData eventBindData = this.bindEventDataList[i];
				GlobalEventSystem.GetInstance().RegisterEventHandler(eventBindData.eventid, eventBindData.eventHandler);
			}
		}

		// Token: 0x06009D4E RID: 40270 RVA: 0x001EF02C File Offset: 0x001ED42C
		private void _unloadEvent()
		{
			for (int i = 0; i < this.bindEventDataList.Count; i++)
			{
				NewbieGuideManager.EventBindData eventBindData = this.bindEventDataList[i];
				GlobalEventSystem.GetInstance().UnRegisterEventHandler(eventBindData.eventid, eventBindData.eventHandler);
			}
			this.bindEventDataList.Clear();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnCheckAddNewMission));
			MissionManager instance2 = DataManager<MissionManager>.GetInstance();
			instance2.onDeleteMission = (MissionManager.DelegateDeleteMission)Delegate.Remove(instance2.onDeleteMission, new MissionManager.DelegateDeleteMission(this.OnCheckFinishMission));
		}

		// Token: 0x06009D4F RID: 40271 RVA: 0x001EF0D1 File Offset: 0x001ED4D1
		private void _rigsterEventHanble(EUIEventID id, ClientEventSystem.UIEventHandler eventHandler)
		{
			this.bindEventDataList.Add(new NewbieGuideManager.EventBindData(id, eventHandler));
		}

		// Token: 0x06009D50 RID: 40272 RVA: 0x001EF0E8 File Offset: 0x001ED4E8
		private void _loadGuide()
		{
			List<int> newbieGuideOrderList = Singleton<TableManager>.GetInstance().GetNewbieGuideOrderList();
			if (newbieGuideOrderList == null)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("新手引导表格获取引导顺序为空", null, string.Empty, false);
				return;
			}
			for (int i = 0; i < newbieGuideOrderList.Count; i++)
			{
				this._loadOne(newbieGuideOrderList[i]);
			}
		}

		// Token: 0x06009D51 RID: 40273 RVA: 0x001EF13C File Offset: 0x001ED53C
		private void _loadOne(int taskID)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(taskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.CheckHasGuided(tableItem))
			{
				return;
			}
			NewbieGuideDataUnit data = Singleton<NewbieGuideDataManager>.instance.GetData(tableItem, (NewbieGuideTable.eNewbieGuideTask)taskID);
			if (data == null)
			{
				return;
			}
			data.manager = this;
			data.guideType = tableItem.NewbieGuideType;
			if (tableItem.GuideSubType == NewbieGuideTable.eGuideSubType.GST_ALONE)
			{
				this.mAloneGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
			else if (tableItem.GuideSubType == NewbieGuideTable.eGuideSubType.GST_FINISH_TALK_DIALOG)
			{
				this.mFinishDialogGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
			else if (tableItem.GuideSubType == NewbieGuideTable.eGuideSubType.GST_ACCEPT_MISSION)
			{
				this.mAcceptMissionGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
			else if (tableItem.GuideSubType == NewbieGuideTable.eGuideSubType.GST_FINISH_MISSION)
			{
				this.mFinishMissionGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
			else if (tableItem.GuideSubType == NewbieGuideTable.eGuideSubType.GST_RECEIVE_MISSION_AWARD)
			{
				this.mReceiveMissionRewardGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
			else if (tableItem.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				this.mForceGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
			else
			{
				this.mWeakGuideUnits.Add((NewbieGuideTable.eNewbieGuideTask)taskID, data);
			}
		}

		// Token: 0x06009D52 RID: 40274 RVA: 0x001EF25B File Offset: 0x001ED65B
		private void OnInitGuideBootData(UIEvent uiEvent)
		{
			this._clearData();
			this._loadGuide();
			this.CheckAll(uiEvent);
		}

		// Token: 0x06009D53 RID: 40275 RVA: 0x001EF270 File Offset: 0x001ED670
		private void CheckAll(UIEvent uiEvent)
		{
			if (!this.CheckAllGuideCondition(uiEvent))
			{
				return;
			}
			if (this.TryForceGuide(uiEvent))
			{
				return;
			}
			this.TryWeakGuide(uiEvent);
		}

		// Token: 0x06009D54 RID: 40276 RVA: 0x001EF294 File Offset: 0x001ED694
		private void OnCheckFinishTalkDialogGuide(UIEvent uiEvent)
		{
			if (!this.CheckAllGuideCondition(uiEvent))
			{
				return;
			}
			this.TryFinishTalkDialogGuide(uiEvent);
		}

		// Token: 0x06009D55 RID: 40277 RVA: 0x001EF2AC File Offset: 0x001ED6AC
		private void OnCheckAddNewMission(uint iTaskID)
		{
			if (iTaskID == 2352U)
			{
			}
			if (!DataManager<MissionManager>.GetInstance().IsAcceptMission(iTaskID))
			{
				return;
			}
			UIEvent uievent = new UIEvent();
			uievent.EventID = EUIEventID.AddNewMission;
			uievent.Param1 = (int)iTaskID;
			if (!this.CheckAllGuideCondition(uievent))
			{
				return;
			}
			this.TryAddNewMissionGuide(uievent);
		}

		// Token: 0x06009D56 RID: 40278 RVA: 0x001EF30C File Offset: 0x001ED70C
		private void OnCheckFinishMission(uint iTaskID)
		{
			this.OnCheckAcceptMissionReward(new UIEvent
			{
				EventID = EUIEventID.MissionRewardFrameClose,
				Param1 = (int)iTaskID
			});
		}

		// Token: 0x06009D57 RID: 40279 RVA: 0x001EF33D File Offset: 0x001ED73D
		private void OnCheckAcceptMissionReward(UIEvent uiEvent)
		{
			if (!this.CheckAllGuideCondition(uiEvent))
			{
				return;
			}
			if (uiEvent.EventID == EUIEventID.MissionRewardFrameClose)
			{
				DataManager<PlayerBaseData>.GetInstance().GuideFinishMission = (int)uiEvent.Param1;
			}
			this.TryReceiveMissionRewardGuide(uiEvent);
		}

		// Token: 0x06009D58 RID: 40280 RVA: 0x001EF37C File Offset: 0x001ED77C
		private void OnCheckGunakaGuide(UIEvent uiEvent)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(3, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.TryAloneGuide(tableItem, uiEvent);
			}
			NewbieGuideTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(59, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.TryAloneGuide(tableItem2, uiEvent);
			}
			NewbieGuideTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(61, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.TryAloneGuide(tableItem3, uiEvent);
			}
		}

		// Token: 0x06009D59 RID: 40281 RVA: 0x001EF3FC File Offset: 0x001ED7FC
		private void OnCheckDungeonRewardGuide(UIEvent uiEvent)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(5, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.TryAloneGuide(tableItem, uiEvent);
		}

		// Token: 0x06009D5A RID: 40282 RVA: 0x001EF430 File Offset: 0x001ED830
		private void OnCheckReturnToTownGuide(UIEvent uiEvent)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(6, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.TryAloneGuide(tableItem, uiEvent);
		}

		// Token: 0x06009D5B RID: 40283 RVA: 0x001EF464 File Offset: 0x001ED864
		private void OnCheckDrugGuide(UIEvent uiEvent)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(13, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.TryAloneGuide(tableItem, uiEvent);
		}

		// Token: 0x06009D5C RID: 40284 RVA: 0x001EF498 File Offset: 0x001ED898
		private void OnCheckChangeJobSkillGuide(UIEvent uiEvent)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(46, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.TryAloneGuide(tableItem, uiEvent);
		}

		// Token: 0x06009D5D RID: 40285 RVA: 0x001EF4CC File Offset: 0x001ED8CC
		private void OnCheckChangeJobSelectGuide(UIEvent uiEvent)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(40, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.TryAloneGuide(tableItem, uiEvent);
		}

		// Token: 0x06009D5E RID: 40286 RVA: 0x001EF500 File Offset: 0x001ED900
		private void CheckPauseState(UIEvent uiEvent)
		{
			if (this.mState < eNewbieGuideState.Guiding)
			{
				return;
			}
			if (uiEvent.EventID == EUIEventID.TaskDialogFrameOpen)
			{
				this.SetPauseState(true);
			}
			else if (uiEvent.EventID == EUIEventID.FrameClose && uiEvent.Param1 as string == "TaskDialogFrame")
			{
				this.SetPauseState(false);
			}
		}

		// Token: 0x06009D5F RID: 40287 RVA: 0x001EF568 File Offset: 0x001ED968
		private bool CheckAllGuideCondition(UIEvent uiEvent)
		{
			if (!this._CheckBaseCondition(uiEvent))
			{
				return false;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
					if (clientSystemTownFrame == null)
					{
						return false;
					}
					if (tableItem.SceneType != CitySceneTable.eSceneType.PK_PREPARE && clientSystemTownFrame.GetState() > EFrameState.Open)
					{
						if (uiEvent.EventID == EUIEventID.FrameClose)
						{
							string a = uiEvent.Param1 as string;
							if (a != "TaskDialogFrame")
							{
								return false;
							}
						}
						else if (uiEvent.EventID != EUIEventID.MissionRewardFrameClose && uiEvent.EventID != EUIEventID.FinishTalkDialog)
						{
							return false;
						}
					}
				}
			}
			if (uiEvent.EventID == EUIEventID.FrameClose)
			{
				string a2 = uiEvent.Param1 as string;
				if (a2 == string.Empty || a2 == "WaitNetMessageFrame" || a2 == "FadingFrame")
				{
					return false;
				}
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<LevelUpNotify>(null))
			{
				return false;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChapterSelectFrame>(null) && this.GetNextGuide(NewbieGuideTable.eNewbieGuideType.NGT_FORCE) != NewbieGuideTable.eNewbieGuideTask.GuanKaGuide)
			{
				return false;
			}
			if (this.mState == eNewbieGuideState.Wait)
			{
				if (this.mGuideControl == null)
				{
					this.SetGuideState(eNewbieGuideState.None);
				}
				else if (this.mGuideControl.curState == ComNewbieGuideControl.ControlState.Finish)
				{
					this.SetGuideState(eNewbieGuideState.None);
				}
				else
				{
					NewbieGuideTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)this.mGuideControl.GuideTaskID, string.Empty, string.Empty);
					if (tableItem2 == null)
					{
						this.SetGuideState(eNewbieGuideState.None);
						return false;
					}
					if (this.CheckHasGuided(tableItem2))
					{
						this.ManagerFinishGuide(this.mGuideControl.GuideTaskID);
						return false;
					}
					if (this.mGuideControl.GetCurGuideCom() == null)
					{
						this.ManagerFinishGuide(this.mGuideControl.GuideTaskID);
						return false;
					}
					return this.CanGuide(tableItem2, tableItem2.NewbieGuideType, uiEvent) && this.DoGuide(tableItem2);
				}
			}
			else if (this.mState == eNewbieGuideState.Guiding)
			{
				this.CheckCurCoverGuide(uiEvent);
				if (uiEvent.EventID == EUIEventID.SystemChanged && this.mGuideControl != null && this.mGuideControl.curState != ComNewbieGuideControl.ControlState.Finish)
				{
					this.SetGuideState(eNewbieGuideState.None);
					return true;
				}
				return false;
			}
			return true;
		}

		// Token: 0x06009D60 RID: 40288 RVA: 0x001EF804 File Offset: 0x001EDC04
		private bool _CheckBaseCondition(UIEvent uiEvent)
		{
			if (!Global.Settings.isGuide)
			{
				return false;
			}
			if (DataManager<PlayerBaseData>.GetInstance().IsFlyUpState)
			{
				return false;
			}
			RoleInfo selectRoleBaseInfoByLogin = ClientApplication.playerinfo.GetSelectRoleBaseInfoByLogin();
			if (selectRoleBaseInfoByLogin != null && (selectRoleBaseInfoByLogin.playerLabelInfo.noviceGuideChooseFlag == 2 || Singleton<NewbieGuideDataManager>.GetInstance().GetRoleNewbieguideState((int)selectRoleBaseInfoByLogin.roleId) == NoviceGuideChooseFlag.NGCF_PASS))
			{
				return false;
			}
			if (this.mNewbieGuideManagerObject == null)
			{
				return false;
			}
			if (!DataManager<PlayerBaseData>.GetInstance().bInitializeTownSystem)
			{
				return false;
			}
			if (BattleMain.IsModePvP(BattleMain.battleType) || BattleMain.IsModeMultiplayer(BattleMain.mode))
			{
				return false;
			}
			if (this.IsGuiding())
			{
				return false;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TaskDialogFrame>(null))
			{
				if (uiEvent.EventID == EUIEventID.FrameClose)
				{
					string a = uiEvent.Param1 as string;
					if (a != "TaskDialogFrame")
					{
						return false;
					}
				}
				else if (uiEvent.EventID != EUIEventID.MissionRewardFrameClose && uiEvent.EventID != EUIEventID.FinishTalkDialog)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06009D61 RID: 40289 RVA: 0x001EF928 File Offset: 0x001EDD28
		private bool TryForceGuide(UIEvent uiEvent)
		{
			IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter = this.mForceGuideUnits.Keys.GetEnumerator();
			return this.FindGuide(iter, uiEvent);
		}

		// Token: 0x06009D62 RID: 40290 RVA: 0x001EF954 File Offset: 0x001EDD54
		private bool TryWeakGuide(UIEvent uiEvent)
		{
			IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter = this.mWeakGuideUnits.Keys.GetEnumerator();
			return this.FindGuide(iter, uiEvent);
		}

		// Token: 0x06009D63 RID: 40291 RVA: 0x001EF980 File Offset: 0x001EDD80
		private bool TryFinishTalkDialogGuide(UIEvent uiEvent)
		{
			IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter = this.mFinishDialogGuideUnits.Keys.GetEnumerator();
			return this.FindGuide(iter, uiEvent);
		}

		// Token: 0x06009D64 RID: 40292 RVA: 0x001EF9AC File Offset: 0x001EDDAC
		private bool TryAddNewMissionGuide(UIEvent uiEvent)
		{
			IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter = this.mAcceptMissionGuideUnits.Keys.GetEnumerator();
			return this.FindGuide(iter, uiEvent);
		}

		// Token: 0x06009D65 RID: 40293 RVA: 0x001EF9D8 File Offset: 0x001EDDD8
		private bool TryFinishMissionGuide(UIEvent uiEvent)
		{
			IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter = this.mFinishMissionGuideUnits.Keys.GetEnumerator();
			return this.FindGuide(iter, uiEvent);
		}

		// Token: 0x06009D66 RID: 40294 RVA: 0x001EFA04 File Offset: 0x001EDE04
		private bool TryReceiveMissionRewardGuide(UIEvent uiEvent)
		{
			IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter = this.mReceiveMissionRewardGuideUnits.Keys.GetEnumerator();
			return this.FindGuide(iter, uiEvent);
		}

		// Token: 0x06009D67 RID: 40295 RVA: 0x001EFA2F File Offset: 0x001EDE2F
		private bool TryAloneGuide(NewbieGuideTable tabledata, UIEvent uiEvent)
		{
			if (this.CheckHasGuided(tabledata))
			{
				return false;
			}
			if (!this._CheckBaseCondition(uiEvent))
			{
				return false;
			}
			if (this.CanGuide(tabledata, tabledata.NewbieGuideType, uiEvent))
			{
				this.DoGuide(tabledata);
			}
			return false;
		}

		// Token: 0x06009D68 RID: 40296 RVA: 0x001EFA6C File Offset: 0x001EDE6C
		private bool FindGuide(IEnumerator<NewbieGuideTable.eNewbieGuideTask> iter, UIEvent uiEvent)
		{
			while (iter.MoveNext())
			{
				NewbieGuideTable.eNewbieGuideTask id = iter.Current;
				NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (!this.CheckHasGuided(tableItem))
					{
						if (this.CanGuide(tableItem, tableItem.NewbieGuideType, uiEvent))
						{
							return this.DoGuide(tableItem);
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06009D69 RID: 40297 RVA: 0x001EFAE0 File Offset: 0x001EDEE0
		private bool CanGuide(NewbieGuideTable tabledata, NewbieGuideTable.eNewbieGuideType eGuideType, UIEvent uiEvent)
		{
			NewbieGuideDataUnit unit = this.GetUnit(tabledata);
			return unit != null && unit.guideType == eGuideType && unit.CheckAllCondition(uiEvent);
		}

		// Token: 0x06009D6A RID: 40298 RVA: 0x001EFB14 File Offset: 0x001EDF14
		private bool DoGuide(NewbieGuideTable tabledata)
		{
			NewbieGuideDataUnit unit = this.GetUnit(tabledata);
			if (unit == null)
			{
				return false;
			}
			Singleton<ClientSystemManager>.instance.CloseFrame<TeamListFrame>(null, false);
			if (tabledata.ID != 3 && tabledata.ID != 8)
			{
				BeTownPlayerMain.CommandStopAutoMove();
			}
			if (tabledata.ID == 16)
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame != null)
				{
					clientSystemTownFrame.ExtendTopRightBtn();
				}
			}
			this.SetGuideState(eNewbieGuideState.Guiding);
			this.bStartGuide = true;
			this.fGuideStateIntrval = 0f;
			if (tabledata.CloseFrames)
			{
				Singleton<ClientSystemManager>.instance.ForceClearFrame(string.Empty);
			}
			this._deleteCurGuideControl();
			this._AddCurGuideControl((NewbieGuideTable.eNewbieGuideTask)tabledata.ID, unit);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CurGuideStart, (NewbieGuideTable.eNewbieGuideTask)tabledata.ID, null, null, null);
			return true;
		}

		// Token: 0x06009D6B RID: 40299 RVA: 0x001EFBF4 File Offset: 0x001EDFF4
		private void _AddCurGuideControl(NewbieGuideTable.eNewbieGuideTask task, NewbieGuideDataUnit unit)
		{
			ComNewbieGuideControl comNewbieGuideControl;
			if (unit.guideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				comNewbieGuideControl = this.mNewbieGuideManagerObject.AddComponent<ComNewbieGuideControl>();
			}
			else
			{
				comNewbieGuideControl = this.mNewbieGuideManagerObject.AddComponent<ComNewbieGuideWeakControl>();
			}
			comNewbieGuideControl.guideManager = this;
			comNewbieGuideControl.GuideTaskID = task;
			comNewbieGuideControl.SetUnit(unit);
			this.mGuideControl = comNewbieGuideControl;
		}

		// Token: 0x06009D6C RID: 40300 RVA: 0x001EFC48 File Offset: 0x001EE048
		private void _deleteCurGuideControl()
		{
			if (null != this.mGuideControl)
			{
				this.mGuideControl.FinishCurGuideControl();
				Object.Destroy(this.mGuideControl);
				this.mGuideControl = null;
			}
		}

		// Token: 0x06009D6D RID: 40301 RVA: 0x001EFC78 File Offset: 0x001EE078
		private void CheckCurCoverGuide(UIEvent uiEvent)
		{
			if (this.mGuideControl == null)
			{
				return;
			}
			NewbieGuideDataUnit controlUnit = this.mGuideControl.GetControlUnit();
			if (controlUnit == null || controlUnit.newbieComList == null)
			{
				return;
			}
			int currentIndex = this.mGuideControl.currentIndex;
			if (currentIndex < 0 || currentIndex >= controlUnit.newbieComList.Count)
			{
				return;
			}
			if (controlUnit.newbieComList[currentIndex].ComType != NewbieGuideComType.COVER)
			{
				return;
			}
			if (controlUnit.newbieComList[currentIndex].args == null || controlUnit.newbieComList[currentIndex].args.Length < 1)
			{
				return;
			}
			if ((EUIEventID)controlUnit.newbieComList[currentIndex].args[0] != uiEvent.EventID)
			{
				return;
			}
			this.mGuideControl.ControlComplete();
		}

		// Token: 0x06009D6E RID: 40302 RVA: 0x001EFD54 File Offset: 0x001EE154
		public void ManagerFinishGuide(NewbieGuideTable.eNewbieGuideTask task)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)task, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.RemoveUnit(tableItem);
			this._deleteCurGuideControl();
			if (!this.CheckHasGuided(tableItem))
			{
				this.SendSaveBoot(task);
			}
			this.bStartGuide = false;
			this.fGuideStateIntrval = 0f;
			this.SetGuideState(eNewbieGuideState.None);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CurGuideFinish, task, null, null, null);
		}

		// Token: 0x06009D6F RID: 40303 RVA: 0x001EFDD0 File Offset: 0x001EE1D0
		private bool CheckHasGuided(NewbieGuideTable tabledata)
		{
			if (tabledata.IsOpen == 0)
			{
				return true;
			}
			if (tabledata.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				if (tabledata.Order <= DataManager<PlayerBaseData>.GetInstance().NewbieGuideCurSaveOrder)
				{
					return true;
				}
			}
			else
			{
				for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().NewbieGuideWeakGuideList.Count; i++)
				{
					if (DataManager<PlayerBaseData>.GetInstance().NewbieGuideWeakGuideList[i] == tabledata.ID)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06009D70 RID: 40304 RVA: 0x001EFE50 File Offset: 0x001EE250
		public void SendSaveBoot(NewbieGuideTable.eNewbieGuideTask task)
		{
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)task, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			NetManager netManager = NetManager.Instance();
			if (tableItem.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				netManager.SendCommand<SceneNotifyNewBoot>(ServerType.GATE_SERVER, new SceneNotifyNewBoot
				{
					id = (uint)task
				});
			}
			else
			{
				netManager.SendCommand<SceneNotifyBootFlag>(ServerType.GATE_SERVER, new SceneNotifyBootFlag
				{
					id = (uint)task
				});
			}
		}

		// Token: 0x06009D71 RID: 40305 RVA: 0x001EFEBD File Offset: 0x001EE2BD
		public void OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x06009D72 RID: 40306 RVA: 0x001EFEBF File Offset: 0x001EE2BF
		public void SetGuideState(eNewbieGuideState estate)
		{
			this.mState = estate;
		}

		// Token: 0x06009D73 RID: 40307 RVA: 0x001EFEC8 File Offset: 0x001EE2C8
		private void SetPauseState(bool bPause)
		{
			if (this.mGuideControl == null)
			{
				return;
			}
			if (this.GetCurGuideType() == NewbieGuideComType.TALK_DIALOG)
			{
				return;
			}
			ComNewbieGuideBase curGuideCom = this.mGuideControl.GetCurGuideCom();
			if (curGuideCom == null)
			{
				return;
			}
			if (bPause)
			{
				curGuideCom.SetShow(false);
			}
			else
			{
				curGuideCom.SetShow(true);
			}
		}

		// Token: 0x06009D74 RID: 40308 RVA: 0x001EFF26 File Offset: 0x001EE326
		public bool IsGuidingControl()
		{
			return !(this.mGuideControl == null) && this.mState == eNewbieGuideState.Guiding;
		}

		// Token: 0x06009D75 RID: 40309 RVA: 0x001EFF44 File Offset: 0x001EE344
		public bool IsHavingWhiteGuide()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			if (itemsByPackageType == null)
			{
				Logger.LogErrorFormat("itemids is null", new object[0]);
				return false;
			}
			for (int i = 0; i < itemsByPackageType.Count; i++)
			{
				if (this.IsWhiteItem(itemsByPackageType[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009D76 RID: 40310 RVA: 0x001EFFA4 File Offset: 0x001EE3A4
		private bool IsWhiteItem(ulong id)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(id);
			return item != null && item.Quality == ItemTable.eColor.WHITE;
		}

		// Token: 0x06009D77 RID: 40311 RVA: 0x001EFFD4 File Offset: 0x001EE3D4
		public bool IsGuiding()
		{
			return !(this.mGuideControl == null) && !(this.mGuideControl.GetCurGuideCom() == null) && this.mState == eNewbieGuideState.Guiding;
		}

		// Token: 0x06009D78 RID: 40312 RVA: 0x001F000C File Offset: 0x001EE40C
		public bool IsGuidingTask(NewbieGuideTable.eNewbieGuideTask eTask)
		{
			return !(this.mGuideControl == null) && this.mGuideControl.GuideTaskID == eTask && !(this.mGuideControl.GetCurGuideCom() == null);
		}

		// Token: 0x06009D79 RID: 40313 RVA: 0x001F0058 File Offset: 0x001EE458
		public bool IsGuidingTaskByCondition(eNewbieGuideCondition eCondition)
		{
			if (this.mGuideControl == null)
			{
				return false;
			}
			if (this.mState < eNewbieGuideState.Guiding)
			{
				return false;
			}
			if (this.mGuideControl.GuideTaskID <= NewbieGuideTable.eNewbieGuideTask.None)
			{
				return false;
			}
			NewbieGuideDataUnit controlUnit = this.mGuideControl.GetControlUnit();
			if (controlUnit == null)
			{
				return false;
			}
			if (controlUnit.newbieConditionList == null || controlUnit.newbieConditionList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < controlUnit.newbieConditionList.Count; i++)
			{
				if (controlUnit.newbieConditionList[i].condition == eCondition)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06009D7A RID: 40314 RVA: 0x001F0104 File Offset: 0x001EE504
		public NewbieGuideTable.eNewbieGuideTask GetNextGuide(NewbieGuideTable.eNewbieGuideType eGuideType = NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
		{
			List<int> newbieGuideOrderList = Singleton<TableManager>.GetInstance().GetNewbieGuideOrderList();
			if (newbieGuideOrderList == null || newbieGuideOrderList.Count <= 0)
			{
				return NewbieGuideTable.eNewbieGuideTask.None;
			}
			if (eGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				bool flag = false;
				for (int i = 0; i < newbieGuideOrderList.Count; i++)
				{
					NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(newbieGuideOrderList[i], string.Empty, string.Empty);
					if (tableItem != null)
					{
						if (tableItem.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
						{
							if (newbieGuideOrderList[i] == DataManager<PlayerBaseData>.GetInstance().NewbieGuideSaveBoot)
							{
								for (int j = i + 1; j < newbieGuideOrderList.Count; j++)
								{
									NewbieGuideTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(newbieGuideOrderList[j], string.Empty, string.Empty);
									if (tableItem2 != null && tableItem2.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
									{
										return (NewbieGuideTable.eNewbieGuideTask)newbieGuideOrderList[j];
									}
								}
								return NewbieGuideTable.eNewbieGuideTask.None;
							}
						}
					}
				}
				if (!flag)
				{
					return (NewbieGuideTable.eNewbieGuideTask)newbieGuideOrderList[0];
				}
			}
			else
			{
				for (int k = 0; k < newbieGuideOrderList.Count; k++)
				{
					NewbieGuideTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(newbieGuideOrderList[k], string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						if (tableItem3.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_WEAK)
						{
							bool flag2 = false;
							for (int l = 0; l < DataManager<PlayerBaseData>.GetInstance().NewbieGuideWeakGuideList.Count; l++)
							{
								if (newbieGuideOrderList[k] == DataManager<PlayerBaseData>.GetInstance().NewbieGuideWeakGuideList[l])
								{
									flag2 = true;
									break;
								}
							}
							if (!flag2)
							{
								return (NewbieGuideTable.eNewbieGuideTask)newbieGuideOrderList[k];
							}
						}
					}
				}
			}
			return NewbieGuideTable.eNewbieGuideTask.None;
		}

		// Token: 0x06009D7B RID: 40315 RVA: 0x001F02CC File Offset: 0x001EE6CC
		public void ManagerWait()
		{
			this.SetGuideState(eNewbieGuideState.Wait);
		}

		// Token: 0x06009D7C RID: 40316 RVA: 0x001F02D5 File Offset: 0x001EE6D5
		public void ManagerException()
		{
			this.SetGuideState(eNewbieGuideState.Exception);
			if (this.mGuideControl == null)
			{
				this.SetGuideState(eNewbieGuideState.None);
			}
			else
			{
				this.ManagerFinishGuide(this.mGuideControl.GuideTaskID);
			}
		}

		// Token: 0x06009D7D RID: 40317 RVA: 0x001F030C File Offset: 0x001EE70C
		public NewbieGuideTable.eNewbieGuideTask GetCurTaskID()
		{
			if (this.mGuideControl == null)
			{
				return NewbieGuideTable.eNewbieGuideTask.None;
			}
			return this.mGuideControl.GuideTaskID;
		}

		// Token: 0x06009D7E RID: 40318 RVA: 0x001F032C File Offset: 0x001EE72C
		public void DoGuideByEditor(NewbieGuideTable tabledata)
		{
			this._loadEnv();
			NewbieGuideDataUnit data = Singleton<NewbieGuideDataManager>.instance.GetData(tabledata, (NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			if (data == null)
			{
				Logger.LogErrorFormat("无法创建引导---[NewbieGuideDataUnit unit]创建失败:{0}", new object[]
				{
					(NewbieGuideTable.eNewbieGuideTask)tabledata.ID
				});
				return;
			}
			data.manager = this;
			Singleton<ClientSystemManager>.instance.CloseFrame<TeamListFrame>(null, false);
			if (tabledata.ID != 3 && tabledata.ID != 8)
			{
				BeTownPlayerMain.CommandStopAutoMove();
			}
			this.SetGuideState(eNewbieGuideState.Guiding);
			if (tabledata.CloseFrames)
			{
				Singleton<ClientSystemManager>.instance.ForceClearFrame(string.Empty);
			}
			this._deleteCurGuideControl();
			this._AddCurGuideControl((NewbieGuideTable.eNewbieGuideTask)tabledata.ID, data);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.CurGuideStart, (NewbieGuideTable.eNewbieGuideTask)tabledata.ID, null, null, null);
		}

		// Token: 0x06009D7F RID: 40319 RVA: 0x001F03F8 File Offset: 0x001EE7F8
		private void RemoveUnit(NewbieGuideTable tabledata)
		{
			if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_ALONE)
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetAloneUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mAloneGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_FINISH_TALK_DIALOG)
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetFinishDialogUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mFinishDialogGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_ACCEPT_MISSION)
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetAcceptMissionUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mAcceptMissionGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_FINISH_MISSION)
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetFinishMissionUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mFinishMissionGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_RECEIVE_MISSION_AWARD)
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetReceiveMissionAwardUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mReceiveMissionRewardGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
			else if (tabledata.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetForceUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mForceGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
			else
			{
				NewbieGuideDataUnit newbieGuideDataUnit = this.GetWeakUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				if (newbieGuideDataUnit != null)
				{
					this.mWeakGuideUnits.Remove((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
				}
			}
		}

		// Token: 0x06009D80 RID: 40320 RVA: 0x001F0570 File Offset: 0x001EE970
		public NewbieGuideDataUnit GetUnit(NewbieGuideTable tabledata)
		{
			NewbieGuideDataUnit result;
			if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_ALONE)
			{
				result = this.GetAloneUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_FINISH_TALK_DIALOG)
			{
				result = this.GetFinishDialogUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_ACCEPT_MISSION)
			{
				result = this.GetAcceptMissionUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_FINISH_MISSION)
			{
				result = this.GetFinishMissionUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			else if (tabledata.GuideSubType == NewbieGuideTable.eGuideSubType.GST_RECEIVE_MISSION_AWARD)
			{
				result = this.GetReceiveMissionAwardUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			else if (tabledata.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE)
			{
				result = this.GetForceUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			else
			{
				result = this.GetWeakUnit((NewbieGuideTable.eNewbieGuideTask)tabledata.ID);
			}
			return result;
		}

		// Token: 0x06009D81 RID: 40321 RVA: 0x001F0641 File Offset: 0x001EEA41
		private NewbieGuideDataUnit GetForceUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mForceGuideUnits.ContainsKey(task))
			{
				return this.mForceGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D82 RID: 40322 RVA: 0x001F0662 File Offset: 0x001EEA62
		private NewbieGuideDataUnit GetWeakUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mWeakGuideUnits.ContainsKey(task))
			{
				return this.mWeakGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D83 RID: 40323 RVA: 0x001F0683 File Offset: 0x001EEA83
		private NewbieGuideDataUnit GetAloneUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mAloneGuideUnits.ContainsKey(task))
			{
				return this.mAloneGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D84 RID: 40324 RVA: 0x001F06A4 File Offset: 0x001EEAA4
		private NewbieGuideDataUnit GetFinishDialogUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mFinishDialogGuideUnits.ContainsKey(task))
			{
				return this.mFinishDialogGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D85 RID: 40325 RVA: 0x001F06C5 File Offset: 0x001EEAC5
		private NewbieGuideDataUnit GetAcceptMissionUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mAcceptMissionGuideUnits.ContainsKey(task))
			{
				return this.mAcceptMissionGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D86 RID: 40326 RVA: 0x001F06E6 File Offset: 0x001EEAE6
		private NewbieGuideDataUnit GetFinishMissionUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mFinishMissionGuideUnits.ContainsKey(task))
			{
				return this.mFinishMissionGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D87 RID: 40327 RVA: 0x001F0707 File Offset: 0x001EEB07
		private NewbieGuideDataUnit GetReceiveMissionAwardUnit(NewbieGuideTable.eNewbieGuideTask task)
		{
			if (this.mReceiveMissionRewardGuideUnits.ContainsKey(task))
			{
				return this.mReceiveMissionRewardGuideUnits[task];
			}
			return null;
		}

		// Token: 0x06009D88 RID: 40328 RVA: 0x001F0728 File Offset: 0x001EEB28
		public NewbieGuideComType GetCurGuideType()
		{
			if (this.GetCurTaskID() == NewbieGuideTable.eNewbieGuideTask.None)
			{
				return NewbieGuideComType.USER_DEFINE;
			}
			NewbieGuideTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>((int)this.GetCurTaskID(), string.Empty, string.Empty);
			if (tableItem == null)
			{
				return NewbieGuideComType.USER_DEFINE;
			}
			NewbieGuideDataUnit unit = this.GetUnit(tableItem);
			if (unit == null)
			{
				return NewbieGuideComType.USER_DEFINE;
			}
			if (unit.newbieComList == null || unit.newbieComList.Count <= 0 || unit.savePoint < 0 || unit.savePoint >= unit.newbieComList.Count)
			{
				return NewbieGuideComType.USER_DEFINE;
			}
			return unit.newbieComList[unit.savePoint].ComType;
		}

		// Token: 0x06009D89 RID: 40329 RVA: 0x001F07CC File Offset: 0x001EEBCC
		public void CleanWeakGuide()
		{
			if (this.mNewbieGuideManagerObject != null)
			{
				ComNewbieGuideWeakControl component = this.mNewbieGuideManagerObject.GetComponent<ComNewbieGuideWeakControl>();
				if (component != null)
				{
					component.FinishCurGuideControl();
					this.SetGuideState(eNewbieGuideState.None);
				}
			}
		}

		// Token: 0x06009D8A RID: 40330 RVA: 0x001F080F File Offset: 0x001EEC0F
		public void Save()
		{
		}

		// Token: 0x04005651 RID: 22097
		private const string kNewbieGuideManagerTag = "NewbieGuideManager";

		// Token: 0x04005652 RID: 22098
		private GameObject mNewbieGuideManagerObject;

		// Token: 0x04005653 RID: 22099
		private eNewbieGuideState mState;

		// Token: 0x04005654 RID: 22100
		public ComNewbieGuideControl mGuideControl;

		// Token: 0x04005655 RID: 22101
		private bool bStartGuide;

		// Token: 0x04005656 RID: 22102
		private float fGuideStateIntrval;

		// Token: 0x04005657 RID: 22103
		private List<NewbieGuideManager.EventBindData> bindEventDataList = new List<NewbieGuideManager.EventBindData>();

		// Token: 0x04005658 RID: 22104
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mForceGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x04005659 RID: 22105
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mWeakGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x0400565A RID: 22106
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mAloneGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x0400565B RID: 22107
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mFinishDialogGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x0400565C RID: 22108
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mAcceptMissionGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x0400565D RID: 22109
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mFinishMissionGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x0400565E RID: 22110
		private Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit> mReceiveMissionRewardGuideUnits = new Dictionary<NewbieGuideTable.eNewbieGuideTask, NewbieGuideDataUnit>();

		// Token: 0x02001063 RID: 4195
		private struct EventBindData
		{
			// Token: 0x06009D8B RID: 40331 RVA: 0x001F0811 File Offset: 0x001EEC11
			public EventBindData(EUIEventID id, ClientEventSystem.UIEventHandler eventHandler)
			{
				this.eventid = id;
				this.eventHandler = eventHandler;
			}

			// Token: 0x0400565F RID: 22111
			public EUIEventID eventid;

			// Token: 0x04005660 RID: 22112
			public ClientEventSystem.UIEventHandler eventHandler;
		}
	}
}
