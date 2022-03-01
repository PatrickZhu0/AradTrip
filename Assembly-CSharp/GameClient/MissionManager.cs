using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Battle;
using GameClient.TaskTrace;
using GamePool;
using Network;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004589 RID: 17801
	public class MissionManager : DataManager<MissionManager>
	{
		// Token: 0x1700207C RID: 8316
		// (get) Token: 0x06018D8E RID: 101774 RVA: 0x007C5AC9 File Offset: 0x007C3EC9
		public Dictionary<uint, MissionManager.SingleMissionInfo> taskGroup
		{
			get
			{
				return this.taskSet;
			}
		}

		// Token: 0x06018D8F RID: 101775 RVA: 0x007C5AD4 File Offset: 0x007C3ED4
		public MissionManager.SingleMissionInfo GetMissionInfo(uint missionID)
		{
			if (this.taskGroup != null)
			{
				MissionManager.SingleMissionInfo result = null;
				if (this.taskGroup.TryGetValue(missionID, out result))
				{
					return result;
				}
			}
			return null;
		}

		// Token: 0x1700207D RID: 8317
		// (get) Token: 0x06018D90 RID: 101776 RVA: 0x007C5B04 File Offset: 0x007C3F04
		public Dictionary<uint, uint> CachedAutoAcceptTask
		{
			get
			{
				return this.cachedAutoAcceptTask;
			}
		}

		// Token: 0x1700207E RID: 8318
		// (get) Token: 0x06018D91 RID: 101777 RVA: 0x007C5B0C File Offset: 0x007C3F0C
		// (set) Token: 0x06018D92 RID: 101778 RVA: 0x007C5B14 File Offset: 0x007C3F14
		public bool dungenStart { get; set; }

		// Token: 0x06018D93 RID: 101779 RVA: 0x007C5B20 File Offset: 0x007C3F20
		public int getSortIDUseType(MissionTable.eTaskType type)
		{
			int result;
			switch (type)
			{
			case MissionTable.eTaskType.TT_CHANGEJOB:
				result = 150;
				break;
			case MissionTable.eTaskType.TT_AWAKEN:
				result = 200;
				break;
			case MissionTable.eTaskType.TT_CYCLE:
				result = 75;
				break;
			default:
				if (type != MissionTable.eTaskType.TT_MAIN)
				{
					if (type != MissionTable.eTaskType.TT_BRANCH)
					{
						result = 0;
					}
					else
					{
						result = 50;
					}
				}
				else
				{
					result = 100;
				}
				break;
			}
			return result;
		}

		// Token: 0x06018D94 RID: 101780 RVA: 0x007C5B8C File Offset: 0x007C3F8C
		public override void OnEnterSystem()
		{
		}

		// Token: 0x06018D95 RID: 101781 RVA: 0x007C5B90 File Offset: 0x007C3F90
		public override void OnExitSystem()
		{
			while (this.dialogIds.Count > 0)
			{
				this.dialogIds.Dequeue();
			}
			this.dialogFrames.Clear();
			this.cachedAutoAcceptTask.Clear();
			this.iLockedMissionID = 0;
		}

		// Token: 0x06018D96 RID: 101782 RVA: 0x007C5BDC File Offset: 0x007C3FDC
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.MissionManager;
		}

		// Token: 0x06018D97 RID: 101783 RVA: 0x007C5BE0 File Offset: 0x007C3FE0
		public bool HasRedPoint()
		{
			List<InstituteTable> jobInstituteData = Singleton<TableManager>.instance.GetJobInstituteData(DataManager<PlayerBaseData>.GetInstance().JobTableID);
			for (int i = 0; i < jobInstituteData.Count; i++)
			{
				if (this.GetState(jobInstituteData[i]) == 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06018D98 RID: 101784 RVA: 0x007C5C30 File Offset: 0x007C4030
		public int GetState(InstituteTable data)
		{
			if (data.LevelLimit > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				return 3;
			}
			List<Battle.DungeonOpenInfo> openedList = DataManager<BattleDataManager>.GetInstance().ChapterInfo.openedList;
			if (openedList.Find((Battle.DungeonOpenInfo x) => x.id == data.DungeonID) == null)
			{
				return 2;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(data.MissionID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				MissionManager.SingleMissionInfo missionInfo = this.GetMissionInfo((uint)tableItem.ID);
				if (missionInfo != null && missionInfo.status != 5)
				{
					return 0;
				}
			}
			return 1;
		}

		// Token: 0x06018D99 RID: 101785 RVA: 0x007C5CDC File Offset: 0x007C40DC
		public IClientFrame CreateDialogFrame(int dialogID, int iCurTaskId, TaskDialogFrame.OnDialogOver callback = null)
		{
			if (!this.dialogFrames.ContainsKey(dialogID))
			{
				this.dialogIds.Enqueue(dialogID);
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TaskDialogFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<TaskDialogFrame>(null, false);
				}
				IClientFrame result = Singleton<ClientSystemManager>.GetInstance().OpenFrame<TaskDialogFrame>(FrameLayer.Middle, null, string.Empty);
				UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
				idleUIEvent.EventParams.taskData.taskID = iCurTaskId;
				idleUIEvent.EventID = EUIEventID.Dlg2TaskId;
				UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
				if (callback != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(new UIEventDialogCallBack(callback));
				}
				return result;
			}
			return null;
		}

		// Token: 0x06018D9A RID: 101786 RVA: 0x007C5D80 File Offset: 0x007C4180
		public void CloseAllDialog()
		{
			while (this.dialogIds.Count > 0)
			{
				this.dialogIds.Dequeue();
			}
			List<int> list = new List<int>(this.dialogFrames.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				TaskDialogFrame taskDialogFrame;
				if (this.dialogFrames.TryGetValue(list[i], out taskDialogFrame))
				{
					this.dialogFrames.Remove(list[i]);
					taskDialogFrame.OnClose();
				}
			}
			this.dialogFrames.Clear();
		}

		// Token: 0x06018D9B RID: 101787 RVA: 0x007C5E14 File Offset: 0x007C4214
		public int AddKeyDlg2Frame(TaskDialogFrame clientFrame)
		{
			if (this.dialogIds.Count > 0 && clientFrame != null)
			{
				this.dialogFrames.Add(this.dialogIds.Peek(), clientFrame);
				return this.dialogIds.Dequeue();
			}
			return 0;
		}

		// Token: 0x06018D9C RID: 101788 RVA: 0x007C5E54 File Offset: 0x007C4254
		public TaskDialogFrame GetDlgFrameByName(string dlgName)
		{
			List<int> list = this.dialogFrames.Keys.ToList<int>();
			List<TaskDialogFrame> list2 = this.dialogFrames.Values.ToList<TaskDialogFrame>();
			for (int i = 0; i < list.Count; i++)
			{
				if (list2[i] != null && list2[i].GetName() == dlgName)
				{
					return list2[i];
				}
			}
			return null;
		}

		// Token: 0x06018D9D RID: 101789 RVA: 0x007C5EC6 File Offset: 0x007C42C6
		public void RemoveDlgFrame(int key)
		{
			if (this.dialogFrames.ContainsKey(key))
			{
				this.dialogFrames.Remove(key);
			}
		}

		// Token: 0x06018D9E RID: 101790 RVA: 0x007C5EE8 File Offset: 0x007C42E8
		public override void Initialize()
		{
			this.RegisterNetHandler();
			this._InitLevel2MissionItems();
			this._InitMissionScore();
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemBegin.AddListener(new UnityAction(this.OnSceneLoadBegin));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadEnd));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onMissionScoreChanged = (PlayerBaseData.OnMissionScoreChanged)Delegate.Combine(instance2.onMissionScoreChanged, new PlayerBaseData.OnMissionScoreChanged(this.OnMissionScoreChanged));
		}

		// Token: 0x06018D9F RID: 101791 RVA: 0x007C5F8C File Offset: 0x007C438C
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(501123U, new Action<MsgDATA>(this.OnRecvDailyTaskList));
			NetProcess.AddMsgHandler(501125U, new Action<MsgDATA>(this.OnRecvAchievementTaskList));
			NetProcess.AddMsgHandler(501106U, new Action<MsgDATA>(this.OnRecvTaskList));
			NetProcess.AddMsgHandler(501107U, new Action<MsgDATA>(this.OnRecvNotifyNewTask));
			NetProcess.AddMsgHandler(501108U, new Action<MsgDATA>(this.OnRecvNotifyDeleteTask));
			NetProcess.AddMsgHandler(501109U, new Action<MsgDATA>(this.OnRecvNotifyTaskStatus));
			NetProcess.AddMsgHandler(501110U, new Action<MsgDATA>(this.OnRecvNotifyTaskVar));
			NetProcess.AddMsgHandler(501114U, new Action<MsgDATA>(this.OnRecvLegendTaskList));
			NetProcess.AddMsgHandler(501116U, new Action<MsgDATA>(this.OnReceiveTaskSync));
			NetProcess.AddMsgHandler(501140U, new Action<MsgDATA>(this.OnReceiveSceneDailyScoreRewardRes));
		}

		// Token: 0x06018DA0 RID: 101792 RVA: 0x007C6078 File Offset: 0x007C4478
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(501123U, new Action<MsgDATA>(this.OnRecvDailyTaskList));
			NetProcess.RemoveMsgHandler(501125U, new Action<MsgDATA>(this.OnRecvAchievementTaskList));
			NetProcess.RemoveMsgHandler(501106U, new Action<MsgDATA>(this.OnRecvTaskList));
			NetProcess.RemoveMsgHandler(501107U, new Action<MsgDATA>(this.OnRecvNotifyNewTask));
			NetProcess.RemoveMsgHandler(501108U, new Action<MsgDATA>(this.OnRecvNotifyDeleteTask));
			NetProcess.RemoveMsgHandler(501109U, new Action<MsgDATA>(this.OnRecvNotifyTaskStatus));
			NetProcess.RemoveMsgHandler(501110U, new Action<MsgDATA>(this.OnRecvNotifyTaskVar));
			NetProcess.RemoveMsgHandler(501114U, new Action<MsgDATA>(this.OnRecvLegendTaskList));
			NetProcess.RemoveMsgHandler(501116U, new Action<MsgDATA>(this.OnReceiveTaskSync));
			NetProcess.RemoveMsgHandler(501140U, new Action<MsgDATA>(this.OnReceiveSceneDailyScoreRewardRes));
		}

		// Token: 0x06018DA1 RID: 101793 RVA: 0x007C6161 File Offset: 0x007C4561
		public MissionManager.SingleMissionInfo GetMission(uint iTaskID)
		{
			if (this.taskGroup.ContainsKey(iTaskID))
			{
				return this.taskGroup[iTaskID];
			}
			return null;
		}

		// Token: 0x06018DA2 RID: 101794 RVA: 0x007C6182 File Offset: 0x007C4582
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			this._CheckLevelFitDailyMission();
		}

		// Token: 0x06018DA3 RID: 101795 RVA: 0x007C618A File Offset: 0x007C458A
		private void OnMissionScoreChanged(int iValue)
		{
			this.Score = iValue;
		}

		// Token: 0x06018DA4 RID: 101796 RVA: 0x007C6193 File Offset: 0x007C4593
		public void AddSystemInvoke()
		{
			this.RemoveSystemInvoke();
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemBegin.AddListener(new UnityAction(this.OnSceneLoadBegin));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.AddListener(new UnityAction(this.OnSceneLoadEnd));
		}

		// Token: 0x06018DA5 RID: 101797 RVA: 0x007C61D1 File Offset: 0x007C45D1
		public void RemoveSystemInvoke()
		{
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemBegin.RemoveListener(new UnityAction(this.OnSceneLoadBegin));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveListener(new UnityAction(this.OnSceneLoadEnd));
		}

		// Token: 0x1700207F RID: 8319
		// (get) Token: 0x06018DA6 RID: 101798 RVA: 0x007C6209 File Offset: 0x007C4609
		// (set) Token: 0x06018DA7 RID: 101799 RVA: 0x007C6211 File Offset: 0x007C4611
		public int FunctionTraceID
		{
			get
			{
				return this.m_iFunctionTraceId;
			}
			set
			{
				this.m_iFunctionTraceId = value;
			}
		}

		// Token: 0x06018DA8 RID: 101800 RVA: 0x007C621C File Offset: 0x007C461C
		public void AutoTraceTask(int iSelectedID, UnityAction onSuccessed = null, UnityAction onFailed = null, bool bForceSubmit = false)
		{
			MissionTable mission = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iSelectedID, string.Empty, string.Empty);
			if (mission != null)
			{
				Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FIND_ROAD, iSelectedID);
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				if (DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)mission.ID, out singleMissionInfo))
				{
					if (singleMissionInfo.status == 0)
					{
						DataManager<MissionManager>.GetInstance().OnExecuteAcceptTask(mission.ID, true, onSuccessed, onFailed, bForceSubmit);
						return;
					}
					if (singleMissionInfo.status == 1)
					{
						if (mission.SubType == MissionTable.eSubType.SummerNpc)
						{
							DataManager<AttackCityMonsterDataManager>.GetInstance().EnterFindPathProcessByMissionContent(singleMissionInfo.taskContents, onSuccessed, onFailed);
						}
						else if (mission.TaskFinishType == MissionTable.eTaskFinishType.TFT_ACCESS_SHOP)
						{
							NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(mission.SeekingTarget, string.Empty, string.Empty);
							if (tableItem != null && tableItem.Function == NpcTable.eFunction.shopping)
							{
								NpcParser.OnClickLink(tableItem.ID, mission.ID, false, onSuccessed, onFailed);
								return;
							}
						}
						else if (mission.TaskFinishType == MissionTable.eTaskFinishType.TFT_SUBMIT_ITEM)
						{
							NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(mission.SeekingTarget, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								if (!bForceSubmit)
								{
									NpcParser.OnClickLink(tableItem2.ID, mission.ID, false, delegate()
									{
										Singleton<ClientSystemManager>.instance.OpenFrame<SubmitItemDlg>(FrameLayer.High, mission.ID, string.Empty);
									}, onFailed);
								}
								else
								{
									Singleton<ClientSystemManager>.instance.OpenFrame<SubmitItemDlg>(FrameLayer.High, mission.ID, string.Empty);
								}
								return;
							}
						}
						else
						{
							if (mission.TaskFinishType == MissionTable.eTaskFinishType.TFT_LINKS)
							{
								if (!string.IsNullOrEmpty(mission.LinkInfo))
								{
									if (onSuccessed != null)
									{
										onSuccessed.Invoke();
									}
									DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(mission.LinkInfo, null, false);
								}
								return;
							}
							DataManager<MissionManager>.GetInstance().OnExecuteDungenTrace(mission.ID, onSuccessed, onFailed);
							return;
						}
					}
					else if (singleMissionInfo.status == 2)
					{
						DataManager<MissionManager>.GetInstance().OnExecuteSubmitTask(mission.ID, onSuccessed, onFailed, bForceSubmit);
						return;
					}
				}
			}
			if (onFailed != null)
			{
				onFailed.Invoke();
			}
		}

		// Token: 0x06018DA9 RID: 101801 RVA: 0x007C6474 File Offset: 0x007C4874
		public void AcceptChangeJobMissions(int iJobID)
		{
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
				if (tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB)
				{
					int num = int.Parse(tableItem.MissionParam);
					if (num == iJobID)
					{
						MissionManager.SingleMissionInfo singleMissionInfo = null;
						Dictionary<uint, MissionManager.SingleMissionInfo> taskGroup = this.taskGroup;
						KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
						if (taskGroup.TryGetValue(keyValuePair2.Key, out singleMissionInfo))
						{
							this.sendCmdAcceptTask((uint)tableItem.ID, (TaskSubmitType)tableItem.AcceptType, (uint)tableItem.MissionTakeNpc);
						}
					}
				}
			}
		}

		// Token: 0x06018DAA RID: 101802 RVA: 0x007C6534 File Offset: 0x007C4934
		public void AcceptAwakeMissions(int iJobID)
		{
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
				if (tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN)
				{
					if (tableItem.JobID == iJobID || tableItem.JobID == 0)
					{
						MissionManager.SingleMissionInfo singleMissionInfo = null;
						Dictionary<uint, MissionManager.SingleMissionInfo> taskGroup = this.taskGroup;
						KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
						if (taskGroup.TryGetValue(keyValuePair2.Key, out singleMissionInfo))
						{
							this.sendCmdAcceptTask((uint)tableItem.ID, (TaskSubmitType)tableItem.AcceptType, (uint)tableItem.MissionTakeNpc);
						}
					}
				}
			}
		}

		// Token: 0x06018DAB RID: 101803 RVA: 0x007C65F8 File Offset: 0x007C49F8
		public bool IsChangeJobMainMission(int iTaskId)
		{
			if (iTaskId != 2271)
			{
				return false;
			}
			if (this.taskGroup == null || this.taskGroup.Count <= 0)
			{
				return false;
			}
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			return this.taskGroup.TryGetValue((uint)iTaskId, out singleMissionInfo) && singleMissionInfo.status > 0;
		}

		// Token: 0x06018DAC RID: 101804 RVA: 0x007C6658 File Offset: 0x007C4A58
		public bool HasAcceptedChangeJobMainMission()
		{
			if (this.taskGroup == null || this.taskGroup.Count <= 0)
			{
				return false;
			}
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.ID == 2271)
					{
						MissionManager.SingleMissionInfo singleMissionInfo = null;
						if (!this.taskGroup.TryGetValue((uint)tableItem.ID, out singleMissionInfo))
						{
							return false;
						}
						if (singleMissionInfo.status != 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018DAD RID: 101805 RVA: 0x007C6710 File Offset: 0x007C4B10
		public bool HasAcceptedChangeJobMission()
		{
			if (this.taskGroup == null || this.taskGroup.Count <= 0)
			{
				return true;
			}
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
				if (tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB)
				{
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					Dictionary<uint, MissionManager.SingleMissionInfo> taskGroup = this.taskGroup;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					if (taskGroup.TryGetValue(keyValuePair2.Key, out singleMissionInfo))
					{
						if (singleMissionInfo.status != 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018DAE RID: 101806 RVA: 0x007C67CC File Offset: 0x007C4BCC
		public bool HasAcceptedAwakeMission()
		{
			if (this.taskGroup == null || this.taskGroup.Count <= 0)
			{
				return true;
			}
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				TableManager instance = Singleton<TableManager>.GetInstance();
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
				if (tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN)
				{
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					Dictionary<uint, MissionManager.SingleMissionInfo> taskGroup = this.taskGroup;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					if (taskGroup.TryGetValue(keyValuePair2.Key, out singleMissionInfo))
					{
						if (singleMissionInfo.status != 0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018DAF RID: 101807 RVA: 0x007C6888 File Offset: 0x007C4C88
		public bool IsFinishingAwakeMission(int iTaskId)
		{
			if (this.taskGroup == null || this.taskGroup.Count <= 0)
			{
				return false;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskId, string.Empty, string.Empty);
			return tableItem != null && tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN && tableItem.AfterID <= 0;
		}

		// Token: 0x06018DB0 RID: 101808 RVA: 0x007C68F0 File Offset: 0x007C4CF0
		public void OnSceneLoadEnd()
		{
			this.bLoadingScene = false;
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown)
			{
				this._TryOpenFunctionFrame();
				foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
				{
					TaskNpcAccess.AddMissionListener(keyValuePair.Key);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementComplete, null, null, null, null);
		}

		// Token: 0x06018DB1 RID: 101809 RVA: 0x007C6964 File Offset: 0x007C4D64
		public bool TryOpenTaskGuideInBattle()
		{
			DungeonID dungeonID = new DungeonID(DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId);
			return this._TryOpenTaskGuideFrame(this.GetMainTask(dungeonID.dungeonIDWithOutDiff), dungeonID.dungeonID, true);
		}

		// Token: 0x06018DB2 RID: 101810 RVA: 0x007C699F File Offset: 0x007C4D9F
		public void OnSceneLoadBegin()
		{
			this.bLoadingScene = true;
		}

		// Token: 0x06018DB3 RID: 101811 RVA: 0x007C69A8 File Offset: 0x007C4DA8
		public void Update()
		{
			if (!this.bLoadingScene)
			{
				this._UpdateExecuteNetMsg();
			}
		}

		// Token: 0x06018DB4 RID: 101812 RVA: 0x007C69BC File Offset: 0x007C4DBC
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			this.mListCnt = 0;
			this.taskSet.Clear();
			this.m_akDiffTasks.Clear();
			this.CloseAllDialog();
			this.cachedAutoAcceptTask.Clear();
			this.dungenStart = false;
			this.m_akCachedNetMsg.Clear();
			this.m_akType2MissionItems.Clear();
			this.iLockedMissionID = 0;
			this.dicLegendNotifies.Clear();
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemBegin.RemoveListener(new UnityAction(this.OnSceneLoadBegin));
			Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveListener(new UnityAction(this.OnSceneLoadEnd));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
			instance2.onMissionScoreChanged = (PlayerBaseData.OnMissionScoreChanged)Delegate.Remove(instance2.onMissionScoreChanged, new PlayerBaseData.OnMissionScoreChanged(this.OnMissionScoreChanged));
			this.m_akMissionScoreDatas.Clear();
			this.m_iScore = 0;
			this.m_akAcquiredChestIDs.Clear();
		}

		// Token: 0x06018DB5 RID: 101813 RVA: 0x007C6ACC File Offset: 0x007C4ECC
		public void OnExecuteAcceptTask(int iTaskID, bool bNeedDialog = true, UnityAction onSuccessed = null, UnityAction onFailed = null, bool bForceSubmit = false)
		{
			MissionTable missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (missionItem == null)
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return;
			}
			if (this.taskGroup.ContainsKey((uint)iTaskID))
			{
				MissionManager.SingleMissionInfo singleMissionInfo = this.taskGroup[(uint)iTaskID];
				if (singleMissionInfo == null || singleMissionInfo.status != 0)
				{
					if (onFailed != null)
					{
						onFailed.Invoke();
					}
					return;
				}
			}
			if (missionItem.AcceptType != MissionTable.eAcceptType.ACT_NPC || bForceSubmit)
			{
				TalkTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(missionItem.BefTaskDlgID, string.Empty, string.Empty);
				if (!bNeedDialog || tableItem == null)
				{
					this.sendCmdAcceptTask((uint)iTaskID, (TaskSubmitType)missionItem.AcceptType, (uint)missionItem.MissionFinishNpc);
				}
				else
				{
					if (bForceSubmit)
					{
						ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
						if (clientSystemTown != null)
						{
							clientSystemTown.PlayNpcSound(missionItem.MissionTakeNpc, NpcVoiceComponent.SoundEffectType.SET_Start);
						}
					}
					TaskDialogFrame.OnDialogOver callback = null;
					if (bForceSubmit)
					{
						callback = new TaskDialogFrame.OnDialogOver().AddListener(delegate
						{
							ClientSystemTown clientSystemTown2 = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
							if (clientSystemTown2 != null)
							{
								clientSystemTown2.PlayNpcSound(missionItem.MissionTakeNpc, NpcVoiceComponent.SoundEffectType.SET_End);
							}
						});
					}
					this.CloseAllDialog();
					this.CreateDialogFrame(missionItem.BefTaskDlgID, iTaskID, callback);
				}
				if (onSuccessed != null)
				{
					onSuccessed.Invoke();
				}
				return;
			}
			NpcTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(missionItem.MissionTakeNpc, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				NpcParser.OnClickLink(missionItem.MissionTakeNpc, iTaskID, bNeedDialog, onSuccessed, onFailed);
				return;
			}
			Logger.LogErrorFormat("npcId is wrong whick taskID = {0},npcID = {1}", new object[]
			{
				iTaskID,
				missionItem.MissionTakeNpc
			});
			if (onFailed != null)
			{
				onFailed.Invoke();
			}
		}

		// Token: 0x06018DB6 RID: 101814 RVA: 0x007C6CAC File Offset: 0x007C50AC
		public void OnExecuteInMissionDialog(uint iTaskID)
		{
			if (Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iTaskID, string.Empty, string.Empty) == null)
			{
				return;
			}
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (!this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo))
			{
				return;
			}
			if (singleMissionInfo.status != 1)
			{
				return;
			}
			int num = 0;
			if (Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(num, string.Empty, string.Empty) == null)
			{
				return;
			}
			this.CloseAllDialog();
			this.CreateDialogFrame(num, (int)iTaskID, null);
		}

		// Token: 0x06018DB7 RID: 101815 RVA: 0x007C6D28 File Offset: 0x007C5128
		public bool OnExecuteSubmitTask(int iSelectedID, UnityAction onSuccessed = null, UnityAction onFailed = null, bool bForceSubmit = false)
		{
			MissionTable missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iSelectedID, string.Empty, string.Empty);
			if (missionItem == null)
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return false;
			}
			MissionManager.SingleMissionInfo singleMissionInfo;
			if (!this.taskGroup.TryGetValue((uint)iSelectedID, out singleMissionInfo))
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return false;
			}
			if (singleMissionInfo.status != 2)
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return false;
			}
			if (missionItem.FinishType != MissionTable.eFinishType.FINISH_TYPE_NPC || bForceSubmit)
			{
				if (Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(missionItem.AftTaskDlgID, string.Empty, string.Empty) == null)
				{
					this.OpenAwardFrame((uint)iSelectedID);
					if (onSuccessed != null)
					{
						onSuccessed.Invoke();
					}
					return false;
				}
				TaskDialogFrame.OnDialogOver callback = null;
				if (bForceSubmit)
				{
					ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
					if (clientSystemTown != null)
					{
						clientSystemTown.PlayNpcSound(missionItem.MissionFinishNpc, NpcVoiceComponent.SoundEffectType.SET_Start);
					}
					callback = new TaskDialogFrame.OnDialogOver().AddListener(delegate
					{
						ClientSystemTown clientSystemTown2 = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
						if (clientSystemTown2 != null)
						{
							clientSystemTown2.PlayNpcSound(missionItem.MissionFinishNpc, NpcVoiceComponent.SoundEffectType.SET_End);
						}
					});
				}
				this.CloseAllDialog();
				this.CreateDialogFrame(missionItem.AftTaskDlgID, iSelectedID, callback);
				if (onSuccessed != null)
				{
					onSuccessed.Invoke();
				}
				return false;
			}
			else
			{
				NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(missionItem.MissionFinishNpc, string.Empty, string.Empty);
				if (tableItem != null)
				{
					NpcParser.OnClickLink(missionItem.MissionFinishNpc, missionItem.ID, true, onSuccessed, onFailed);
					return true;
				}
				Logger.LogErrorFormat("[Mission] [id = {0}] [npcID = {1}] npcId is wrong!", new object[]
				{
					missionItem.ID,
					missionItem.MissionFinishNpc
				});
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return false;
			}
		}

		// Token: 0x06018DB8 RID: 101816 RVA: 0x007C6EFC File Offset: 0x007C52FC
		public void OnExecuteDungenTrace(int iTaskID, UnityAction onSuccessed = null, UnityAction onFailed = null)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				if (onFailed != null)
				{
					onFailed.Invoke();
				}
				return;
			}
			DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(tableItem.MapID, string.Empty, string.Empty);
			if (tableItem2 != null && clientSystemTown != null && clientSystemTown.MainPlayer != null)
			{
				BeTownPlayerMain.CommandStopAutoMove();
				DungenTrace dungenTrace = new DungenTrace();
				dungenTrace.iTaskID = iTaskID;
				dungenTrace.iDungenID = tableItem.MapID;
				dungenTrace.onSucceed = onSuccessed;
				dungenTrace.onFailed = onFailed;
				BeTownPlayerMain.OnMoveStateChanged.AddListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(dungenTrace.OnMoveStateChanged));
				BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(dungenTrace.OnMoveSuccess));
				BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(dungenTrace.OnAutoMoveFail));
				clientSystemTown.MainPlayer.CommandMoveToDungeon(tableItem.MapID);
				return;
			}
			if (onFailed != null)
			{
				onFailed.Invoke();
			}
		}

		// Token: 0x06018DB9 RID: 101817 RVA: 0x007C7000 File Offset: 0x007C5400
		public void OnTaskChanged()
		{
			if (this.missionChangedDelegate != null)
			{
				this.missionChangedDelegate();
			}
		}

		// Token: 0x06018DBA RID: 101818 RVA: 0x007C7018 File Offset: 0x007C5418
		public void OnAddNewMission(uint taskID)
		{
			if (this.onAddNewMission != null)
			{
				this.onAddNewMission(taskID);
			}
			this._TryOpenFunctionFrame();
			this._TryOpenTaskGuideFrame((int)taskID, 0, false);
			TaskNpcAccess.AddMissionListener(taskID);
		}

		// Token: 0x06018DBB RID: 101819 RVA: 0x007C7047 File Offset: 0x007C5447
		public void OnDeleteMission(uint taskID)
		{
			if (this.onDeleteMission != null)
			{
				this.onDeleteMission(taskID);
			}
			this._TryOpenFunctionFrame();
		}

		// Token: 0x06018DBC RID: 101820 RVA: 0x007C7068 File Offset: 0x007C5468
		public void OpenAwardFrame(uint taskID)
		{
			List<AwardItemData> missionAwards = this.GetMissionAwards((int)taskID, -1);
			if (missionAwards != null)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TaskAward>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<TaskAward>(null, false);
				}
				TaskAward.TaskAwardData taskAwardData = new TaskAward.TaskAwardData();
				taskAwardData.iID = (int)taskID;
				taskAwardData.awards = missionAwards;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TaskAward>(FrameLayer.Top, taskAwardData, string.Empty);
			}
		}

		// Token: 0x06018DBD RID: 101821 RVA: 0x007C70C6 File Offset: 0x007C54C6
		public bool CanOpenDlgFrame()
		{
			return !(Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemBattle) || !this.dungenStart;
		}

		// Token: 0x06018DBE RID: 101822 RVA: 0x007C70E8 File Offset: 0x007C54E8
		public void OnSyncMission(uint taskID)
		{
			if (this.onSyncMission != null)
			{
				this.onSyncMission(taskID);
			}
		}

		// Token: 0x06018DBF RID: 101823 RVA: 0x007C7101 File Offset: 0x007C5501
		public void OnUpdateMission(uint taskID)
		{
			if (this.onUpdateMission != null)
			{
				this.onUpdateMission(taskID);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MissionUpdated, taskID, null, null, null);
			this._TryOpenFunctionFrame();
		}

		// Token: 0x06018DC0 RID: 101824 RVA: 0x007C7138 File Offset: 0x007C5538
		private void _CachedNetMsg(uint msgID, MsgDATA msgData)
		{
			this.m_akCachedNetMsg.Enqueue(new MissionManager.CachedMsg(msgID, msgData));
		}

		// Token: 0x06018DC1 RID: 101825 RVA: 0x007C714C File Offset: 0x007C554C
		public int GetAchievementMissionStatusCount(int iStatus)
		{
			int num = 0;
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if ((int)keyValuePair.Value.status == iStatus)
				{
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					if (Utility.IsAchievementMissionNormal(keyValuePair2.Key))
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06018DC2 RID: 101826 RVA: 0x007C71B0 File Offset: 0x007C55B0
		public int GetTitleMissionStatusCount(int iStatus)
		{
			int num = 0;
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if ((int)keyValuePair.Value.status == iStatus)
				{
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					MissionTable missionItem = keyValuePair2.Value.missionItem;
					if (missionItem != null)
					{
						if (missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06018DC3 RID: 101827 RVA: 0x007C7234 File Offset: 0x007C5634
		public int GetMainMissionStatusCount(int iStatus)
		{
			int num = 0;
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if ((int)keyValuePair.Value.status == iStatus)
				{
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					MissionTable missionItem = keyValuePair2.Value.missionItem;
					if (missionItem != null)
					{
						if (missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH || missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x06018DC4 RID: 101828 RVA: 0x007C72D0 File Offset: 0x007C56D0
		public int GetDailyNormalMissionStatusCount(int iStatus)
		{
			int num = 0;
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if ((int)keyValuePair.Value.status == iStatus)
				{
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					if (Utility.IsDailyNormal(keyValuePair2.Key))
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x06018DC5 RID: 101829 RVA: 0x007C7334 File Offset: 0x007C5734
		public bool IsAcceptMission(uint iTaskID)
		{
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				Dictionary<uint, MissionManager.SingleMissionInfo> taskGroup = this.taskGroup;
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				if (taskGroup.TryGetValue(keyValuePair.Key, out singleMissionInfo))
				{
					if (singleMissionInfo.taskID == iTaskID)
					{
						if (singleMissionInfo.status <= 1)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018DC6 RID: 101830 RVA: 0x007C73AC File Offset: 0x007C57AC
		private void _UpdateExecuteNetMsg()
		{
			if (this.bLoadingScene)
			{
				return;
			}
			while (this.m_akCachedNetMsg.Count > 0)
			{
				MissionManager.CachedMsg cachedMsg = this.m_akCachedNetMsg.Dequeue();
				if (cachedMsg.id == 501106U)
				{
					this.OnRecvTaskListCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501107U)
				{
					this.OnRecvNotifyNewTaskCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501108U)
				{
					this.OnRecvNotifyDeleteTaskCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501109U)
				{
					this.OnRecvNotifyTaskStatusCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501110U)
				{
					this.OnRecvNotifyTaskVarCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501123U)
				{
					this.OnRecvDailyTaskListCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501125U)
				{
					this.OnRecvAchievementTaskListCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501114U)
				{
					this.OnRecvLegendTaskListCached(cachedMsg.msgData);
				}
				else if (cachedMsg.id == 501116U)
				{
					this.OnReceivedSceneTaskSyncCached(cachedMsg.msgData);
				}
			}
		}

		// Token: 0x06018DC7 RID: 101831 RVA: 0x007C750C File Offset: 0x007C590C
		private void _ClearAllDailyTask()
		{
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			List<uint> list = new List<uint>();
			list.Clear();
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				if (Utility.IsDailyMission(keyValuePair.Key))
				{
					List<uint> list2 = list;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				if (this.taskGroup.ContainsKey(list[i]))
				{
					singleMissionInfo = this.taskGroup[list[i]];
				}
				this.taskGroup.Remove(list[i]);
				if (this.onDeleteMissionValue != null && singleMissionInfo != null)
				{
					this.onDeleteMissionValue(singleMissionInfo);
				}
				if (this.onDeleteMission != null)
				{
					this.onDeleteMission(list[i]);
				}
			}
		}

		// Token: 0x06018DC8 RID: 101832 RVA: 0x007C760C File Offset: 0x007C5A0C
		private void _OnDailyAddOrUpdate(ref SceneDailyTaskList ret, uint[] arrayRemoveKeys)
		{
			for (int i = 0; i < ret.tasks.Length; i++)
			{
				MissionInfo missionInfo = ret.tasks[i];
				int num = Array.BinarySearch<uint>(arrayRemoveKeys, missionInfo.taskID);
				if (num >= 0 && num < arrayRemoveKeys.Length)
				{
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					if (this.taskGroup.TryGetValue(missionInfo.taskID, out singleMissionInfo))
					{
						singleMissionInfo.taskID = missionInfo.taskID;
						singleMissionInfo.status = missionInfo.status;
						singleMissionInfo.finTime = missionInfo.finTime;
						singleMissionInfo.submitCount = missionInfo.submitCount;
						singleMissionInfo.taskContents.Clear();
						Dictionary<string, string> taskContents = singleMissionInfo.taskContents;
						for (int j = 0; j < missionInfo.akMissionPairs.Length; j++)
						{
							MissionPair missionPair = missionInfo.akMissionPairs[j];
							if (taskContents.ContainsKey(missionPair.key))
							{
								taskContents.Remove(missionPair.key);
							}
							taskContents.Add(missionPair.key, missionPair.value);
						}
						if (this.onUpdateMission != null)
						{
							this.onUpdateMission(missionInfo.taskID);
						}
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MissionUpdated, missionInfo.taskID, null, null, null);
					}
				}
				else
				{
					MissionManager.SingleMissionInfo singleMissionInfo2 = new MissionManager.SingleMissionInfo();
					singleMissionInfo2.taskID = missionInfo.taskID;
					singleMissionInfo2.status = missionInfo.status;
					singleMissionInfo2.finTime = missionInfo.finTime;
					singleMissionInfo2.submitCount = missionInfo.submitCount;
					singleMissionInfo2.taskContents.Clear();
					singleMissionInfo2.missionItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
					Dictionary<string, string> taskContents2 = singleMissionInfo2.taskContents;
					for (int k = 0; k < missionInfo.akMissionPairs.Length; k++)
					{
						MissionPair missionPair2 = missionInfo.akMissionPairs[k];
						if (taskContents2.ContainsKey(missionPair2.key))
						{
							taskContents2.Remove(missionPair2.key);
						}
						taskContents2.Add(missionPair2.key, missionPair2.value);
					}
					if (this.taskGroup.ContainsKey(missionInfo.taskID))
					{
						this.taskGroup.Remove(missionInfo.taskID);
						Logger.LogErrorFormat("current.taskID = {0}", new object[]
						{
							missionInfo.taskID
						});
					}
					this.taskGroup.Add(missionInfo.taskID, singleMissionInfo2);
					this._OnAddDiffTask(singleMissionInfo2);
					if (this.onAddNewMission != null)
					{
						this.onAddNewMission(missionInfo.taskID);
					}
				}
			}
		}

		// Token: 0x06018DC9 RID: 101833 RVA: 0x007C78A4 File Offset: 0x007C5CA4
		private void _OnDailyDelete(ref SceneDailyTaskList ret, uint[] arrayRemoveKeys)
		{
			MissionInfo missionInfo = new MissionInfo();
			missionInfo.taskID = 0U;
			MissionManager.DailyComparser comparer = new MissionManager.DailyComparser();
			for (int i = 0; i < arrayRemoveKeys.Length; i++)
			{
				missionInfo.taskID = arrayRemoveKeys[i];
				int num = Array.BinarySearch<MissionInfo>(ret.tasks, missionInfo, comparer);
				if (num < 0 || num >= ret.tasks.Length)
				{
					this._OnRemoveDiffTask((int)missionInfo.taskID, (int)missionInfo.taskID);
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					if (this.taskGroup.ContainsKey(arrayRemoveKeys[i]))
					{
						singleMissionInfo = this.taskGroup[arrayRemoveKeys[i]];
					}
					this.taskGroup.Remove(arrayRemoveKeys[i]);
					if (this.onDeleteMissionValue != null && singleMissionInfo != null)
					{
						this.onDeleteMissionValue(singleMissionInfo);
					}
					if (this.onDeleteMission != null)
					{
						this.onDeleteMission(arrayRemoveKeys[i]);
					}
				}
			}
		}

		// Token: 0x06018DCA RID: 101834 RVA: 0x007C7988 File Offset: 0x007C5D88
		private void OnRecvDailyTaskListCached(MsgDATA msg)
		{
			SceneDailyTaskList sceneDailyTaskList = new SceneDailyTaskList();
			sceneDailyTaskList.decode(msg.bytes);
			if (sceneDailyTaskList.tasks == null || sceneDailyTaskList.tasks.Length <= 0)
			{
				this._ClearAllDailyTask();
				return;
			}
			Array.Sort<MissionInfo>(sceneDailyTaskList.tasks, new Comparison<MissionInfo>(this.sortMissionInfoCmp.Compare));
			List<uint> list = new List<uint>();
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if (Utility.IsDailyMission(keyValuePair.Key))
				{
					List<uint> list2 = list;
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			uint[] array = list.ToArray();
			Array.Sort<uint>(array);
			this._OnDailyAddOrUpdate(ref sceneDailyTaskList, array);
			this._OnDailyDelete(ref sceneDailyTaskList, array);
		}

		// Token: 0x06018DCB RID: 101835 RVA: 0x007C7A58 File Offset: 0x007C5E58
		private void OnRecvDailyTaskList(MsgDATA msg)
		{
			this._CachedNetMsg(501123U, msg);
		}

		// Token: 0x06018DCC RID: 101836 RVA: 0x007C7A68 File Offset: 0x007C5E68
		private void _ClearAllAchievementTask()
		{
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			List<uint> list = new List<uint>();
			list.Clear();
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				if (Utility.IsAchievementMission(keyValuePair.Key))
				{
					List<uint> list2 = list;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				if (this.taskGroup.ContainsKey(list[i]))
				{
					singleMissionInfo = this.taskGroup[list[i]];
				}
				this.taskGroup.Remove(list[i]);
				if (this.onDeleteMissionValue != null && singleMissionInfo != null)
				{
					this.onDeleteMissionValue(singleMissionInfo);
				}
				if (this.onDeleteMission != null)
				{
					this.onDeleteMission(list[i]);
				}
			}
		}

		// Token: 0x06018DCD RID: 101837 RVA: 0x007C7B68 File Offset: 0x007C5F68
		private void _OnAchievementAddOrUpdate(ref SceneAchievementTaskList ret, uint[] arrayRemoveKeys)
		{
			for (int i = 0; i < ret.tasks.Length; i++)
			{
				MissionInfo missionInfo = ret.tasks[i];
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int num = Array.BinarySearch<uint>(arrayRemoveKeys, missionInfo.taskID);
					if (num >= 0 && num < arrayRemoveKeys.Length)
					{
						MissionManager.SingleMissionInfo singleMissionInfo = null;
						if (this.taskGroup.TryGetValue(missionInfo.taskID, out singleMissionInfo))
						{
							singleMissionInfo.taskID = missionInfo.taskID;
							singleMissionInfo.status = missionInfo.status;
							singleMissionInfo.finTime = missionInfo.finTime;
							singleMissionInfo.submitCount = missionInfo.submitCount;
							singleMissionInfo.taskContents.Clear();
							Dictionary<string, string> taskContents = singleMissionInfo.taskContents;
							for (int j = 0; j < missionInfo.akMissionPairs.Length; j++)
							{
								MissionPair missionPair = missionInfo.akMissionPairs[j];
								if (taskContents.ContainsKey(missionPair.key))
								{
									taskContents.Remove(missionPair.key);
								}
								taskContents.Add(missionPair.key, missionPair.value);
							}
							if (this.onUpdateMission != null)
							{
								this.onUpdateMission(missionInfo.taskID);
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MissionUpdated, missionInfo.taskID, null, null, null);
						}
					}
					else
					{
						MissionManager.SingleMissionInfo singleMissionInfo2 = new MissionManager.SingleMissionInfo();
						singleMissionInfo2.taskID = missionInfo.taskID;
						singleMissionInfo2.status = missionInfo.status;
						singleMissionInfo2.finTime = missionInfo.finTime;
						singleMissionInfo2.submitCount = missionInfo.submitCount;
						singleMissionInfo2.taskContents.Clear();
						singleMissionInfo2.missionItem = tableItem;
						Dictionary<string, string> taskContents2 = singleMissionInfo2.taskContents;
						for (int k = 0; k < missionInfo.akMissionPairs.Length; k++)
						{
							MissionPair missionPair2 = missionInfo.akMissionPairs[k];
							if (taskContents2.ContainsKey(missionPair2.key))
							{
								taskContents2.Remove(missionPair2.key);
							}
							taskContents2.Add(missionPair2.key, missionPair2.value);
						}
						if (!this.taskGroup.ContainsKey(missionInfo.taskID))
						{
							this.taskGroup.Add(missionInfo.taskID, singleMissionInfo2);
						}
						this._OnAddDiffTask(singleMissionInfo2);
						if (this.onAddNewMission != null)
						{
							this.onAddNewMission(missionInfo.taskID);
						}
					}
					DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.Institute);
				}
			}
		}

		// Token: 0x06018DCE RID: 101838 RVA: 0x007C7DF0 File Offset: 0x007C61F0
		private void _OnAchievementDelete(ref SceneAchievementTaskList ret, uint[] arrayRemoveKeys)
		{
			MissionInfo missionInfo = new MissionInfo();
			missionInfo.taskID = 0U;
			MissionManager.DailyComparser comparer = new MissionManager.DailyComparser();
			for (int i = 0; i < arrayRemoveKeys.Length; i++)
			{
				missionInfo.taskID = arrayRemoveKeys[i];
				int num = Array.BinarySearch<MissionInfo>(ret.tasks, missionInfo, comparer);
				if (num < 0 || num >= ret.tasks.Length)
				{
					this._OnRemoveDiffTask((int)missionInfo.taskID, (int)missionInfo.taskID);
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					if (this.taskGroup.ContainsKey(arrayRemoveKeys[i]))
					{
						singleMissionInfo = this.taskGroup[arrayRemoveKeys[i]];
					}
					this.taskGroup.Remove(arrayRemoveKeys[i]);
					if (this.onDeleteMissionValue != null && singleMissionInfo != null)
					{
						this.onDeleteMissionValue(singleMissionInfo);
					}
					if (this.onDeleteMission != null)
					{
						this.onDeleteMission(arrayRemoveKeys[i]);
					}
				}
			}
		}

		// Token: 0x06018DCF RID: 101839 RVA: 0x007C7ED4 File Offset: 0x007C62D4
		private void OnRecvAchievementTaskListCached(MsgDATA msg)
		{
			SceneAchievementTaskList sceneAchievementTaskList = new SceneAchievementTaskList();
			sceneAchievementTaskList.decode(msg.bytes);
			if (sceneAchievementTaskList.tasks == null || sceneAchievementTaskList.tasks.Length <= 0)
			{
				this._ClearAllAchievementTask();
				return;
			}
			Array.Sort<MissionInfo>(sceneAchievementTaskList.tasks, new Comparison<MissionInfo>(this.sortMissionInfoCmp.Compare));
			List<uint> list = new List<uint>();
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if (Utility.IsAchievementMission(keyValuePair.Key))
				{
					List<uint> list2 = list;
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			uint[] array = list.ToArray();
			Array.Sort<uint>(array);
			this._OnAchievementAddOrUpdate(ref sceneAchievementTaskList, array);
			this._OnAchievementDelete(ref sceneAchievementTaskList, array);
		}

		// Token: 0x06018DD0 RID: 101840 RVA: 0x007C7FA4 File Offset: 0x007C63A4
		private void OnRecvAchievementTaskList(MsgDATA msg)
		{
			this._CachedNetMsg(501125U, msg);
		}

		// Token: 0x06018DD1 RID: 101841 RVA: 0x007C7FB4 File Offset: 0x007C63B4
		private void _ClearAllLegendTask()
		{
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			List<uint> list = new List<uint>();
			list.Clear();
			while (enumerator.MoveNext())
			{
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				if (Utility.IsLegendMission(keyValuePair.Key))
				{
					List<uint> list2 = list;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = null;
				if (this.taskGroup.ContainsKey(list[i]))
				{
					singleMissionInfo = this.taskGroup[list[i]];
				}
				this.taskGroup.Remove(list[i]);
				if (this.onDeleteMissionValue != null && singleMissionInfo != null)
				{
					this.onDeleteMissionValue(singleMissionInfo);
				}
				if (this.onDeleteMission != null)
				{
					this.onDeleteMission(list[i]);
				}
			}
		}

		// Token: 0x06018DD2 RID: 101842 RVA: 0x007C80B4 File Offset: 0x007C64B4
		private void _OnLegendAddOrUpdate(ref SceneLegendTaskListRes ret, uint[] arrayRemoveKeys)
		{
			for (int i = 0; i < ret.tasks.Length; i++)
			{
				MissionInfo missionInfo = ret.tasks[i];
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					int num = Array.BinarySearch<uint>(arrayRemoveKeys, missionInfo.taskID);
					if (num >= 0 && num < arrayRemoveKeys.Length)
					{
						MissionManager.SingleMissionInfo singleMissionInfo = null;
						if (this.taskGroup.TryGetValue(missionInfo.taskID, out singleMissionInfo))
						{
							singleMissionInfo.taskID = missionInfo.taskID;
							singleMissionInfo.status = missionInfo.status;
							singleMissionInfo.finTime = missionInfo.finTime;
							singleMissionInfo.submitCount = missionInfo.submitCount;
							singleMissionInfo.taskContents.Clear();
							Dictionary<string, string> taskContents = singleMissionInfo.taskContents;
							for (int j = 0; j < missionInfo.akMissionPairs.Length; j++)
							{
								MissionPair missionPair = missionInfo.akMissionPairs[j];
								if (taskContents.ContainsKey(missionPair.key))
								{
									taskContents.Remove(missionPair.key);
								}
								taskContents.Add(missionPair.key, missionPair.value);
							}
							if (this.onUpdateMission != null)
							{
								this.onUpdateMission(missionInfo.taskID);
							}
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MissionUpdated, missionInfo.taskID, null, null, null);
						}
					}
					else
					{
						MissionManager.SingleMissionInfo singleMissionInfo2 = new MissionManager.SingleMissionInfo();
						singleMissionInfo2.taskID = missionInfo.taskID;
						singleMissionInfo2.status = missionInfo.status;
						singleMissionInfo2.finTime = missionInfo.finTime;
						singleMissionInfo2.submitCount = missionInfo.submitCount;
						singleMissionInfo2.taskContents.Clear();
						singleMissionInfo2.missionItem = tableItem;
						Dictionary<string, string> taskContents2 = singleMissionInfo2.taskContents;
						for (int k = 0; k < missionInfo.akMissionPairs.Length; k++)
						{
							MissionPair missionPair2 = missionInfo.akMissionPairs[k];
							if (taskContents2.ContainsKey(missionPair2.key))
							{
								taskContents2.Remove(missionPair2.key);
							}
							taskContents2.Add(missionPair2.key, missionPair2.value);
						}
						this.taskGroup.Add(missionInfo.taskID, singleMissionInfo2);
						this._OnAddDiffTask(singleMissionInfo2);
						if (this.onAddNewMission != null)
						{
							this.onAddNewMission(missionInfo.taskID);
						}
					}
				}
			}
		}

		// Token: 0x06018DD3 RID: 101843 RVA: 0x007C8318 File Offset: 0x007C6718
		private void _OnLegendDelete(ref SceneLegendTaskListRes ret, uint[] arrayRemoveKeys)
		{
			MissionInfo missionInfo = new MissionInfo();
			missionInfo.taskID = 0U;
			MissionManager.DailyComparser comparer = new MissionManager.DailyComparser();
			for (int i = 0; i < arrayRemoveKeys.Length; i++)
			{
				missionInfo.taskID = arrayRemoveKeys[i];
				int num = Array.BinarySearch<MissionInfo>(ret.tasks, missionInfo, comparer);
				if (num < 0 || num >= ret.tasks.Length)
				{
					this._OnRemoveDiffTask((int)missionInfo.taskID, (int)missionInfo.taskID);
					MissionManager.SingleMissionInfo singleMissionInfo = null;
					if (this.taskGroup.ContainsKey(arrayRemoveKeys[i]))
					{
						singleMissionInfo = this.taskGroup[arrayRemoveKeys[i]];
					}
					this.taskGroup.Remove(arrayRemoveKeys[i]);
					if (this.onDeleteMissionValue != null && singleMissionInfo != null)
					{
						this.onDeleteMissionValue(singleMissionInfo);
					}
					if (this.onDeleteMission != null)
					{
						this.onDeleteMission(arrayRemoveKeys[i]);
					}
				}
			}
		}

		// Token: 0x06018DD4 RID: 101844 RVA: 0x007C83FC File Offset: 0x007C67FC
		private void OnReceivedSceneTaskSyncCached(MsgDATA msg)
		{
			SceneResetTaskSync sceneResetTaskSync = new SceneResetTaskSync();
			sceneResetTaskSync.decode(msg.bytes);
			if (sceneResetTaskSync.taskInfo == null)
			{
				return;
			}
			MissionInfo taskInfo = sceneResetTaskSync.taskInfo;
			if (Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)taskInfo.taskID, string.Empty, string.Empty) == null)
			{
				return;
			}
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (this.taskGroup.TryGetValue(taskInfo.taskID, out singleMissionInfo))
			{
				singleMissionInfo.taskID = taskInfo.taskID;
				singleMissionInfo.status = taskInfo.status;
				singleMissionInfo.finTime = taskInfo.finTime;
				singleMissionInfo.submitCount = taskInfo.submitCount;
				singleMissionInfo.taskContents.Clear();
				Dictionary<string, string> taskContents = singleMissionInfo.taskContents;
				for (int i = 0; i < taskInfo.akMissionPairs.Length; i++)
				{
					MissionPair missionPair = taskInfo.akMissionPairs[i];
					if (taskContents.ContainsKey(missionPair.key))
					{
						taskContents.Remove(missionPair.key);
					}
					taskContents.Add(missionPair.key, missionPair.value);
				}
			}
			else
			{
				singleMissionInfo = new MissionManager.SingleMissionInfo();
				singleMissionInfo.taskID = taskInfo.taskID;
				singleMissionInfo.status = taskInfo.status;
				singleMissionInfo.finTime = taskInfo.finTime;
				singleMissionInfo.submitCount = taskInfo.submitCount;
				singleMissionInfo.taskContents.Clear();
				Dictionary<string, string> taskContents2 = singleMissionInfo.taskContents;
				for (int j = 0; j < taskInfo.akMissionPairs.Length; j++)
				{
					MissionPair missionPair2 = taskInfo.akMissionPairs[j];
					if (taskContents2.ContainsKey(missionPair2.key))
					{
						taskContents2.Remove(missionPair2.key);
					}
					taskContents2.Add(missionPair2.key, missionPair2.value);
				}
				this.taskGroup.Add(taskInfo.taskID, singleMissionInfo);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MissionSync, taskInfo.taskID, null, null, null);
			this.OnSyncMission(taskInfo.taskID);
		}

		// Token: 0x06018DD5 RID: 101845 RVA: 0x007C85F4 File Offset: 0x007C69F4
		private void OnRecvLegendTaskListCached(MsgDATA msg)
		{
			SceneLegendTaskListRes sceneLegendTaskListRes = new SceneLegendTaskListRes();
			sceneLegendTaskListRes.decode(msg.bytes);
			if (sceneLegendTaskListRes.tasks == null || sceneLegendTaskListRes.tasks.Length <= 0)
			{
				this._ClearAllLegendTask();
				return;
			}
			Array.Sort<MissionInfo>(sceneLegendTaskListRes.tasks, new Comparison<MissionInfo>(this.sortMissionInfoCmp.Compare));
			List<uint> list = new List<uint>();
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				if (Utility.IsLegendMission(keyValuePair.Key))
				{
					List<uint> list2 = list;
					Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
					list2.Add(keyValuePair2.Key);
				}
			}
			uint[] array = list.ToArray();
			Array.Sort<uint>(array);
			this._OnLegendAddOrUpdate(ref sceneLegendTaskListRes, array);
			this._OnLegendDelete(ref sceneLegendTaskListRes, array);
		}

		// Token: 0x06018DD6 RID: 101846 RVA: 0x007C86C4 File Offset: 0x007C6AC4
		private void OnRecvLegendTaskList(MsgDATA msg)
		{
			this._CachedNetMsg(501114U, msg);
		}

		// Token: 0x06018DD7 RID: 101847 RVA: 0x007C86D4 File Offset: 0x007C6AD4
		private void _OnAddDiffTask(MissionManager.SingleMissionInfo value)
		{
			if (value != null && value.missionItem != null)
			{
				List<MissionManager.SingleMissionInfo> list = null;
				if (!this.m_akDiffTasks.TryGetValue(value.missionItem.TaskType, out list))
				{
					list = new List<MissionManager.SingleMissionInfo>();
					this.m_akDiffTasks.Add(value.missionItem.TaskType, list);
				}
				list.Add(value);
			}
		}

		// Token: 0x06018DD8 RID: 101848 RVA: 0x007C8735 File Offset: 0x007C6B35
		public List<MissionManager.SingleMissionInfo> GetDiffTask(MissionTable.eTaskType eType)
		{
			if (this.m_akDiffTasks.ContainsKey(eType) && this.m_akDiffTasks[eType].Count > 0)
			{
				return this.m_akDiffTasks[eType];
			}
			return null;
		}

		// Token: 0x06018DD9 RID: 101849 RVA: 0x007C8770 File Offset: 0x007C6B70
		public List<MissionManager.SingleMissionInfo> GetParticularDiffTask(MissionTable.eTaskType eType)
		{
			if (eType != MissionTable.eTaskType.TT_DIALY)
			{
				return this.GetDiffTask(eType);
			}
			List<MissionManager.SingleMissionInfo> diffTask = this.GetDiffTask(eType);
			if (diffTask != null)
			{
				diffTask.RemoveAll((MissionManager.SingleMissionInfo x) => x.missionItem.SubType != MissionTable.eSubType.Daily_Task);
			}
			return diffTask;
		}

		// Token: 0x06018DDA RID: 101850 RVA: 0x007C87C0 File Offset: 0x007C6BC0
		private void _OnRemoveDiffTask(int iTaskID, int iTableID)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				List<MissionManager.SingleMissionInfo> list = null;
				if (this.m_akDiffTasks.TryGetValue(tableItem.TaskType, out list))
				{
					if (tableItem.TaskType == MissionTable.eTaskType.TT_DIALY)
					{
					}
					list.RemoveAll((MissionManager.SingleMissionInfo x) => (ulong)x.taskID == (ulong)((long)iTaskID));
				}
			}
		}

		// Token: 0x06018DDB RID: 101851 RVA: 0x007C8834 File Offset: 0x007C6C34
		public void OnRecvTaskListCached(MsgDATA msg)
		{
			SceneTaskListRet sceneTaskListRet = new SceneTaskListRet();
			sceneTaskListRet.decode(msg.bytes);
			for (int i = 0; i < sceneTaskListRet.tasks.Length; i++)
			{
				MissionInfo missionInfo = sceneTaskListRet.tasks[i];
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)missionInfo.taskID, string.Empty, string.Empty);
				if (tableItem == null)
				{
					Logger.LogErrorFormat("taskInfo.taskID = {0} can not find in MissionTable!", new object[]
					{
						missionInfo.taskID
					});
				}
				else
				{
					MissionManager.SingleMissionInfo singleMissionInfo;
					if (this.taskSet.TryGetValue(missionInfo.taskID, out singleMissionInfo))
					{
						singleMissionInfo.status = missionInfo.status;
						singleMissionInfo.finTime = missionInfo.finTime;
						singleMissionInfo.submitCount = missionInfo.submitCount;
						for (int j = 0; j < missionInfo.akMissionPairs.Length; j++)
						{
							if (singleMissionInfo.taskContents.ContainsKey(missionInfo.akMissionPairs[j].key))
							{
								singleMissionInfo.taskContents.Remove(missionInfo.akMissionPairs[j].key);
							}
							singleMissionInfo.taskContents.Add(missionInfo.akMissionPairs[j].key, missionInfo.akMissionPairs[j].value);
						}
					}
					else
					{
						singleMissionInfo = new MissionManager.SingleMissionInfo();
						singleMissionInfo.taskID = missionInfo.taskID;
						singleMissionInfo.status = missionInfo.status;
						singleMissionInfo.finTime = missionInfo.finTime;
						singleMissionInfo.submitCount = missionInfo.submitCount;
						singleMissionInfo.missionItem = tableItem;
						for (int k = 0; k < missionInfo.akMissionPairs.Length; k++)
						{
							singleMissionInfo.taskContents.Add(missionInfo.akMissionPairs[k].key, missionInfo.akMissionPairs[k].value);
						}
						this.taskSet.Add(singleMissionInfo.taskID, singleMissionInfo);
					}
					this._OnAddDiffTask(singleMissionInfo);
					this._TryAcceptAutoTask(singleMissionInfo.taskID, false);
					TaskNpcAccess.AddMissionListener(singleMissionInfo.taskID);
					this._TryOpenTaskGuideFrame((int)singleMissionInfo.taskID, 0, false);
					this._OnAddTypeMission(singleMissionInfo, false);
				}
			}
			this._SortAllTypeMission();
			this._TryOpenFunctionFrame();
			this.OnTaskChanged();
		}

		// Token: 0x06018DDC RID: 101852 RVA: 0x007C8A65 File Offset: 0x007C6E65
		private void OnRecvTaskList(MsgDATA msg)
		{
			this._CachedNetMsg(501106U, msg);
		}

		// Token: 0x06018DDD RID: 101853 RVA: 0x007C8A74 File Offset: 0x007C6E74
		public void OnRecvNotifyNewTaskCached(MsgDATA msg)
		{
			SceneNotifyNewTaskRet sceneNotifyNewTaskRet = new SceneNotifyNewTaskRet();
			sceneNotifyNewTaskRet.decode(msg.bytes);
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)sceneNotifyNewTaskRet.taskInfo.taskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("OnRecvNotifyNewTaskCached taskid = {0} can not find in MissionTable!", new object[]
				{
					sceneNotifyNewTaskRet.taskInfo.taskID
				});
				return;
			}
			MissionManager.SingleMissionInfo singleMissionInfo;
			if (this.taskSet.TryGetValue(sceneNotifyNewTaskRet.taskInfo.taskID, out singleMissionInfo))
			{
				singleMissionInfo.taskID = sceneNotifyNewTaskRet.taskInfo.taskID;
				singleMissionInfo.status = sceneNotifyNewTaskRet.taskInfo.status;
				singleMissionInfo.finTime = sceneNotifyNewTaskRet.taskInfo.finTime;
				singleMissionInfo.submitCount = sceneNotifyNewTaskRet.taskInfo.submitCount;
				singleMissionInfo.taskContents.Clear();
			}
			else
			{
				singleMissionInfo = new MissionManager.SingleMissionInfo();
				singleMissionInfo.taskID = sceneNotifyNewTaskRet.taskInfo.taskID;
				singleMissionInfo.status = sceneNotifyNewTaskRet.taskInfo.status;
				singleMissionInfo.finTime = sceneNotifyNewTaskRet.taskInfo.finTime;
				singleMissionInfo.submitCount = sceneNotifyNewTaskRet.taskInfo.submitCount;
				singleMissionInfo.missionItem = tableItem;
				this.taskSet.Add(singleMissionInfo.taskID, singleMissionInfo);
			}
			this._OnAddDiffTask(singleMissionInfo);
			for (int i = 0; i < sceneNotifyNewTaskRet.taskInfo.akMissionPairs.Length; i++)
			{
				singleMissionInfo.taskContents.Add(sceneNotifyNewTaskRet.taskInfo.akMissionPairs[i].key, sceneNotifyNewTaskRet.taskInfo.akMissionPairs[i].value);
			}
			if (singleMissionInfo.status == 0)
			{
				this._TryAcceptAutoTask(singleMissionInfo.taskID, false);
			}
			else if (singleMissionInfo.status == 1)
			{
				if (!this.CanOpenDlgFrame())
				{
					uint num = 0U;
					MissionManager.SingleMissionInfo singleMissionInfo2 = null;
					if (this.taskGroup.TryGetValue(singleMissionInfo.taskID, out singleMissionInfo2) && !this.cachedAutoAcceptTask.TryGetValue(singleMissionInfo.taskID, out num))
					{
						this.cachedAutoAcceptTask.Add(singleMissionInfo.taskID, (uint)singleMissionInfo.status);
					}
				}
				else
				{
					this.CreateTaskDlgFrame((int)singleMissionInfo.taskID, MissionManager.TaskDlgType.TDT_MIDDLE);
				}
			}
			else if (singleMissionInfo.status == 2)
			{
				if (!this.CanOpenDlgFrame())
				{
					uint num2 = 0U;
					MissionManager.SingleMissionInfo singleMissionInfo3 = null;
					if (this.taskGroup.TryGetValue(singleMissionInfo.taskID, out singleMissionInfo3) && !this.cachedAutoAcceptTask.TryGetValue(singleMissionInfo.taskID, out num2))
					{
						this.cachedAutoAcceptTask.Add(singleMissionInfo.taskID, (uint)singleMissionInfo.status + 9527U);
					}
				}
				else
				{
					this.CreateTaskDlgFrame((int)singleMissionInfo.taskID, MissionManager.TaskDlgType.TDT_BEGIN);
				}
			}
			this._OnAddTypeMission(singleMissionInfo, true);
			this.OnAddNewMission(singleMissionInfo.taskID);
		}

		// Token: 0x06018DDE RID: 101854 RVA: 0x007C8D2D File Offset: 0x007C712D
		private void OnRecvNotifyNewTask(MsgDATA msg)
		{
			this._CachedNetMsg(501107U, msg);
		}

		// Token: 0x06018DDF RID: 101855 RVA: 0x007C8D3C File Offset: 0x007C713C
		public void OnRecvNotifyDeleteTaskCached(MsgDATA msg)
		{
			SceneNotifyDeleteTaskRet sceneNotifyDeleteTaskRet = new SceneNotifyDeleteTaskRet();
			sceneNotifyDeleteTaskRet.decode(msg.bytes);
			this._TryUnbindNpcForMission(sceneNotifyDeleteTaskRet.taskID, 2);
			MissionManager.SingleMissionInfo singleMissionInfo;
			if (this.taskSet.TryGetValue(sceneNotifyDeleteTaskRet.taskID, out singleMissionInfo))
			{
				this.taskSet.Remove(sceneNotifyDeleteTaskRet.taskID);
			}
			if (this.onDeleteMissionValue != null && singleMissionInfo != null)
			{
				this.onDeleteMissionValue(singleMissionInfo);
			}
			this._OnRemoveTypeMission((int)sceneNotifyDeleteTaskRet.taskID);
			this._OnRemoveDiffTask((int)sceneNotifyDeleteTaskRet.taskID, (int)sceneNotifyDeleteTaskRet.taskID);
			this.OnDeleteMission(sceneNotifyDeleteTaskRet.taskID);
		}

		// Token: 0x06018DE0 RID: 101856 RVA: 0x007C8DD9 File Offset: 0x007C71D9
		private void OnRecvNotifyDeleteTask(MsgDATA msg)
		{
			this._CachedNetMsg(501108U, msg);
		}

		// Token: 0x06018DE1 RID: 101857 RVA: 0x007C8DE8 File Offset: 0x007C71E8
		public void OnRecvNotifyTaskStatusCached(MsgDATA msg)
		{
			SceneNotifyTaskStatusRet sceneNotifyTaskStatusRet = new SceneNotifyTaskStatusRet();
			sceneNotifyTaskStatusRet.decode(msg.bytes);
			MissionManager.SingleMissionInfo singleMissionInfo;
			if (this.taskSet.TryGetValue(sceneNotifyTaskStatusRet.taskID, out singleMissionInfo) && singleMissionInfo.status != sceneNotifyTaskStatusRet.status)
			{
				this._TryUnbindNpcForMission(singleMissionInfo.taskID, (int)singleMissionInfo.status);
				if (sceneNotifyTaskStatusRet.status == 0)
				{
					singleMissionInfo.taskContents.Clear();
					Utility.OnPopupTaskChangedMsg("你放弃了任务", (int)sceneNotifyTaskStatusRet.taskID);
				}
				else if (sceneNotifyTaskStatusRet.status == 2)
				{
					if (this.taskGroup.ContainsKey(sceneNotifyTaskStatusRet.taskID))
					{
						MissionManager.SingleMissionInfo singleMissionInfo2 = this.taskGroup[sceneNotifyTaskStatusRet.taskID];
						if (singleMissionInfo2 != null && singleMissionInfo2.missionItem != null && singleMissionInfo2.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && singleMissionInfo2.missionItem.SubType == MissionTable.eSubType.Daily_Null && singleMissionInfo2.status != sceneNotifyTaskStatusRet.status)
						{
							this._PushAchievementItems(singleMissionInfo2.missionItem.ID);
							if (!this.bLoadingScene)
							{
								UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementComplete, null, null, null, null);
							}
						}
					}
					if (!this.CanOpenDlgFrame())
					{
						uint num = 0U;
						MissionManager.SingleMissionInfo singleMissionInfo3 = null;
						if (this.taskGroup.TryGetValue(sceneNotifyTaskStatusRet.taskID, out singleMissionInfo3) && !this.cachedAutoAcceptTask.TryGetValue(sceneNotifyTaskStatusRet.taskID, out num))
						{
							this.cachedAutoAcceptTask.Add(sceneNotifyTaskStatusRet.taskID, (uint)sceneNotifyTaskStatusRet.status);
						}
					}
					else
					{
						this.CreateTaskDlgFrame((int)sceneNotifyTaskStatusRet.taskID, MissionManager.TaskDlgType.TDT_END);
					}
				}
				else if (sceneNotifyTaskStatusRet.status == 5)
				{
					if (!Utility.IsLegendMission(sceneNotifyTaskStatusRet.taskID) || singleMissionInfo == null || singleMissionInfo.missionItem == null || !string.IsNullOrEmpty(singleMissionInfo.missionItem.LinkInfo))
					{
					}
					if (this.taskGroup.ContainsKey(sceneNotifyTaskStatusRet.taskID))
					{
						MissionManager.SingleMissionInfo singleMissionInfo4 = this.taskGroup[sceneNotifyTaskStatusRet.taskID];
						if (singleMissionInfo4 != null && singleMissionInfo4.missionItem != null && singleMissionInfo4.missionItem.TaskType == MissionTable.eTaskType.TT_ACHIEVEMENT && singleMissionInfo4.missionItem.SubType == MissionTable.eSubType.Daily_Null && singleMissionInfo4.status != sceneNotifyTaskStatusRet.status)
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementOver, singleMissionInfo4.missionItem.ID, null, null, null);
						}
					}
				}
				singleMissionInfo.status = sceneNotifyTaskStatusRet.status;
				singleMissionInfo.finTime = sceneNotifyTaskStatusRet.finTime;
				TaskNpcAccess.AddMissionListener(singleMissionInfo.taskID);
			}
			this.OnUpdateMission(sceneNotifyTaskStatusRet.taskID);
		}

		// Token: 0x06018DE2 RID: 101858 RVA: 0x007C9086 File Offset: 0x007C7486
		private void OnRecvNotifyTaskStatus(MsgDATA msg)
		{
			this._CachedNetMsg(501109U, msg);
		}

		// Token: 0x06018DE3 RID: 101859 RVA: 0x007C9094 File Offset: 0x007C7494
		public void OnRecvNotifyTaskVarCached(MsgDATA msg)
		{
			SceneNotifyTaskVarRet sceneNotifyTaskVarRet = new SceneNotifyTaskVarRet();
			sceneNotifyTaskVarRet.decode(msg.bytes);
			MissionManager.SingleMissionInfo singleMissionInfo;
			if (this.taskSet.TryGetValue(sceneNotifyTaskVarRet.taskID, out singleMissionInfo))
			{
				if (singleMissionInfo.taskContents.ContainsKey(sceneNotifyTaskVarRet.key))
				{
					singleMissionInfo.taskContents.Remove(sceneNotifyTaskVarRet.key);
				}
				singleMissionInfo.taskContents.Add(sceneNotifyTaskVarRet.key, sceneNotifyTaskVarRet.value);
			}
			this.OnUpdateMission(sceneNotifyTaskVarRet.taskID);
		}

		// Token: 0x06018DE4 RID: 101860 RVA: 0x007C9116 File Offset: 0x007C7516
		private void OnRecvNotifyTaskVar(MsgDATA msg)
		{
			this._CachedNetMsg(501110U, msg);
		}

		// Token: 0x06018DE5 RID: 101861 RVA: 0x007C9124 File Offset: 0x007C7524
		private void OnReceiveTaskSync(MsgDATA msg)
		{
			this._CachedNetMsg(501116U, msg);
		}

		// Token: 0x06018DE6 RID: 101862 RVA: 0x007C9134 File Offset: 0x007C7534
		public void sendCmdAcceptTask(uint iTaskID, TaskSubmitType eSubmitType, uint iNpcID)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo) && singleMissionInfo.status == 0)
			{
				SceneAcceptTaskReq sceneAcceptTaskReq = new SceneAcceptTaskReq();
				sceneAcceptTaskReq.taskID = iTaskID;
				sceneAcceptTaskReq.npcID = iNpcID;
				sceneAcceptTaskReq.acceptType = (byte)eSubmitType;
				NetManager.Instance().SendCommand<SceneAcceptTaskReq>(ServerType.GATE_SERVER, sceneAcceptTaskReq);
				Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_ACCEPT, (int)iTaskID);
			}
			Utility.OnPopupTaskChangedMsg("你接受了任务", (int)iTaskID);
		}

		// Token: 0x06018DE7 RID: 101863 RVA: 0x007C91A4 File Offset: 0x007C75A4
		public void sendCmdSubmitTask(uint iTaskID, TaskSubmitType eSubmitType, uint iNpcID)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo) && singleMissionInfo.status == 2)
			{
				if (Utility.IsDailyMission(iTaskID))
				{
					SceneSubmitDailyTask sceneSubmitDailyTask = new SceneSubmitDailyTask();
					sceneSubmitDailyTask.taskId = iTaskID;
					NetManager.Instance().SendCommand<SceneSubmitDailyTask>(ServerType.GATE_SERVER, sceneSubmitDailyTask);
					Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, (int)iTaskID);
				}
				else if (Utility.IsAchievementMission(iTaskID))
				{
					SceneSubmitAchievementTask sceneSubmitAchievementTask = new SceneSubmitAchievementTask();
					sceneSubmitAchievementTask.taskId = iTaskID;
					NetManager.Instance().SendCommand<SceneSubmitAchievementTask>(ServerType.GATE_SERVER, sceneSubmitAchievementTask);
					Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, (int)iTaskID);
				}
				else if (Utility.IsAccountAchievementMission(iTaskID) || Utility.IsAdventureTeamAccountWeeklyMission(iTaskID))
				{
					WorldSubmitAccountTask worldSubmitAccountTask = new WorldSubmitAccountTask();
					worldSubmitAccountTask.taskId = iTaskID;
					NetManager.Instance().SendCommand<WorldSubmitAccountTask>(ServerType.GATE_SERVER, worldSubmitAccountTask);
					Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, (int)iTaskID);
				}
				else if (Utility.IsLegendMission(iTaskID))
				{
					SceneSubmitLegendTask sceneSubmitLegendTask = new SceneSubmitLegendTask();
					sceneSubmitLegendTask.taskId = iTaskID;
					NetManager.Instance().SendCommand<SceneSubmitLegendTask>(ServerType.GATE_SERVER, sceneSubmitLegendTask);
					Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, (int)iTaskID);
				}
				else
				{
					SceneSubmitTaskReq sceneSubmitTaskReq = new SceneSubmitTaskReq();
					sceneSubmitTaskReq.taskID = iTaskID;
					sceneSubmitTaskReq.npcID = iNpcID;
					sceneSubmitTaskReq.submitType = (byte)eSubmitType;
					NetManager.Instance().SendCommand<SceneSubmitTaskReq>(ServerType.GATE_SERVER, sceneSubmitTaskReq);
					Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, (int)iTaskID);
				}
			}
		}

		// Token: 0x06018DE8 RID: 101864 RVA: 0x007C92F4 File Offset: 0x007C76F4
		public void sendUnFinishTask(uint iTaskID, TaskSubmitType eSubmitType, uint iNpcID)
		{
			SceneSubmitTaskReq sceneSubmitTaskReq = new SceneSubmitTaskReq();
			sceneSubmitTaskReq.taskID = iTaskID;
			sceneSubmitTaskReq.npcID = iNpcID;
			sceneSubmitTaskReq.submitType = (byte)eSubmitType;
			NetManager.Instance().SendCommand<SceneSubmitTaskReq>(ServerType.GATE_SERVER, sceneSubmitTaskReq);
			Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, (int)iTaskID);
		}

		// Token: 0x06018DE9 RID: 101865 RVA: 0x007C9338 File Offset: 0x007C7738
		public void sendCmdAbandomTask(uint iTaskID)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo) && singleMissionInfo.status != 2)
			{
				SceneAbandonTaskReq sceneAbandonTaskReq = new SceneAbandonTaskReq();
				sceneAbandonTaskReq.taskID = iTaskID;
				NetManager.Instance().SendCommand<SceneAbandonTaskReq>(ServerType.GATE_SERVER, sceneAbandonTaskReq);
			}
		}

		// Token: 0x06018DEA RID: 101866 RVA: 0x007C9380 File Offset: 0x007C7780
		public void sendCmdRefreshTask(uint iTaskID = 0U)
		{
			SceneRefreshCycleTask cmd = new SceneRefreshCycleTask();
			NetManager.Instance().SendCommand<SceneRefreshCycleTask>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06018DEB RID: 101867 RVA: 0x007C93A0 File Offset: 0x007C77A0
		public string GetMissionValueByKey(uint taskId, string key)
		{
			string result = "0";
			MissionManager.SingleMissionInfo singleMissionInfo;
			string result2;
			if (this.taskSet.TryGetValue(taskId, out singleMissionInfo) && singleMissionInfo.taskContents.TryGetValue(key, out result2))
			{
				return result2;
			}
			return result;
		}

		// Token: 0x06018DEC RID: 101868 RVA: 0x007C93DC File Offset: 0x007C77DC
		public List<AwardItemData> GetMissionOccuAwards(string desc, int targetOccu)
		{
			List<AwardItemData> ret = new List<AwardItemData>();
			if (targetOccu == -1)
			{
				targetOccu = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			}
			string[] array = desc.Split(new char[]
			{
				','
			});
			Array.ForEach<string>(array, delegate(string x)
			{
				if (string.IsNullOrEmpty(x))
				{
					return;
				}
				string[] array2 = x.Split(new char[]
				{
					'_'
				});
				int num = 0;
				int id = 0;
				int num2 = 0;
				int equipType = 0;
				int strengthenLevel = 0;
				if (array2.Length == 3)
				{
					int.TryParse(array2[0], out num);
					int.TryParse(array2[1], out id);
					int.TryParse(array2[2], out num2);
				}
				else if (array2.Length == 5)
				{
					int.TryParse(array2[0], out num);
					int.TryParse(array2[1], out id);
					int.TryParse(array2[2], out num2);
					int.TryParse(array2[3], out equipType);
					int.TryParse(array2[4], out strengthenLevel);
				}
				if (num2 <= 0)
				{
					return;
				}
				if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty) == null)
				{
					return;
				}
				if (Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(num, string.Empty, string.Empty) == null)
				{
					return;
				}
				if (targetOccu != num)
				{
					return;
				}
				ret.Add(new AwardItemData
				{
					ID = id,
					Num = num2,
					EquipType = equipType,
					StrengthenLevel = strengthenLevel
				});
			});
			return ret;
		}

		// Token: 0x06018DED RID: 101869 RVA: 0x007C9448 File Offset: 0x007C7848
		public int GetFinalTitleMission(int iTaskID)
		{
			int result = -1;
			for (MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty); tableItem != null; tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(tableItem.AfterID, string.Empty, string.Empty))
			{
				result = tableItem.ID;
			}
			return result;
		}

		// Token: 0x06018DEE RID: 101870 RVA: 0x007C949C File Offset: 0x007C789C
		public static MissionManager.ParseObject Parse(string constent, MissionManager.OnTokenize onToken)
		{
			MissionManager.ParseObject parseObject = new MissionManager.ParseObject();
			List<object> list = ListPool<object>.Get();
			for (int i = 0; i < 2; i++)
			{
				Regex regex = MissionManager.m_akRegexs[i];
				MatchCollection matchCollection = regex.Matches(constent);
				for (int j = 0; j < matchCollection.Count; j++)
				{
					if (matchCollection[j].Success)
					{
						list.Add(new MissionManager.MaterialMatchInfo
						{
							match = matchCollection[j],
							eMaterialRegexType = (MissionManager.MaterialRegexType)i
						});
					}
				}
			}
			list.Sort((object x, object y) => (x as MissionManager.MaterialMatchInfo).match.Index - (y as MissionManager.MaterialMatchInfo).match.Index);
			if (list.Count > 0)
			{
				StringBuilder stringBuilder = StringBuilderCache.Acquire(256);
				MyExtensionMethods.Clear(stringBuilder);
				int num = 0;
				for (int k = 0; k < list.Count; k++)
				{
					MissionManager.MaterialMatchInfo materialMatchInfo = list[k] as MissionManager.MaterialMatchInfo;
					Match match = materialMatchInfo.match;
					stringBuilder.Append(constent.Substring(num, match.Index - num));
					if (onToken != null)
					{
						MissionManager.TokenObject tokenObject = onToken(materialMatchInfo);
						if (tokenObject != null)
						{
							stringBuilder.Append(tokenObject.tokenedValue);
							tokenObject.eMaterialRegexType = materialMatchInfo.eMaterialRegexType;
							parseObject.tokens.Add(tokenObject);
						}
					}
					num = match.Index + match.Length;
				}
				stringBuilder.Append(constent.Substring(num, constent.Length - num));
				parseObject.content = stringBuilder.ToString();
				StringBuilderCache.Release(stringBuilder);
			}
			ListPool<object>.Release(list);
			return parseObject;
		}

		// Token: 0x06018DEF RID: 101871 RVA: 0x007C9648 File Offset: 0x007C7A48
		public static MissionManager.TokenObject _TokenMaterials(int iTaskID, ItemData itemData, MissionManager.MaterialMatchInfo matchInfo)
		{
			MissionManager.TokenObject tokenObject = new MissionManager.TokenObject();
			MissionManager.MaterialRegexType eMaterialRegexType = matchInfo.eMaterialRegexType;
			if (eMaterialRegexType != MissionManager.MaterialRegexType.MRT_KEY)
			{
				if (eMaterialRegexType == MissionManager.MaterialRegexType.MRT_KEY_VALUE)
				{
					string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)iTaskID, matchInfo.match.Groups[1].Value);
					bool flag = false;
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						flag = (tableItem.Type == ItemTable.eType.INCOME);
					}
					int num = 0;
					int.TryParse(missionValueByKey, out num);
					int num2 = 0;
					int.TryParse(matchInfo.match.Groups[2].Value, out num2);
					bool flag2 = false;
					MissionManager.SingleMissionInfo mission = DataManager<MissionManager>.GetInstance().GetMission((uint)iTaskID);
					if (mission != null && mission.status == 5)
					{
						num = num2;
						flag2 = true;
					}
					num = IntMath.Min(num, num2);
					if (!flag)
					{
						tokenObject.tokenedValue = string.Format("{0}/{1}", num, num2);
					}
					else
					{
						tokenObject.tokenedValue = string.Format("{0}", num2);
					}
					tokenObject.param0 = num;
					tokenObject.param1 = num2;
					tokenObject.param2 = flag2;
				}
			}
			else
			{
				tokenObject.tokenedValue = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)iTaskID, matchInfo.match.Groups[1].Value);
			}
			return tokenObject;
		}

		// Token: 0x06018DF0 RID: 101872 RVA: 0x007C97C4 File Offset: 0x007C7BC4
		public List<ItemData> GetMissionMaterials(int iTaskID)
		{
			List<ItemData> list = new List<ItemData>();
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				for (int i = 0; i < tableItem.MissionMaterials.Count; i++)
				{
					string[] array = tableItem.MissionMaterials[i].Split(new char[]
					{
						'_'
					});
					int tableId = 0;
					int num = 0;
					if (array.Length == 2 && int.TryParse(array[0], out tableId) && int.TryParse(array[1], out num) && num > 0)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(tableId, 100, 0);
						if (itemData != null)
						{
							itemData.Count = num;
							list.Add(itemData);
						}
					}
				}
			}
			return list;
		}

		// Token: 0x06018DF1 RID: 101873 RVA: 0x007C9888 File Offset: 0x007C7C88
		public List<AwardItemData> GetMissionAwards(int iTaskID, int occu = -1)
		{
			List<AwardItemData> list = new List<AwardItemData>();
			list.Clear();
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			string text = null;
			if (tableItem != null)
			{
				RewardAdapterTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<RewardAdapterTable>(tableItem.RewardAdapter, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey((uint)iTaskID, "DAILYLEVEL");
					int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
					if (int.TryParse(missionValueByKey, out level))
					{
						Type type = tableItem2.GetType();
						PropertyInfo property = type.GetProperty("Level" + missionValueByKey);
						if (property != null)
						{
							text = (property.GetValue(tableItem2, null) as string);
						}
					}
				}
				else
				{
					text = tableItem.Award;
				}
				if (!string.IsNullOrEmpty(text))
				{
					string[] array = text.Split(new char[]
					{
						','
					});
					for (int i = 0; i < array.Length; i++)
					{
						if (!string.IsNullOrEmpty(array[i]))
						{
							string[] array2 = array[i].Split(new char[]
							{
								'_'
							});
							if (array2.Length == 2)
							{
								AwardItemData awardItemData = new AwardItemData();
								if (int.TryParse(array2[0], out awardItemData.ID) && int.TryParse(array2[1], out awardItemData.Num))
								{
									list.Add(awardItemData);
								}
							}
							else if (array2.Length == 4)
							{
								AwardItemData awardItemData2 = new AwardItemData();
								if (int.TryParse(array2[0], out awardItemData2.ID) && int.TryParse(array2[1], out awardItemData2.Num) && int.TryParse(array2[2], out awardItemData2.EquipType) && int.TryParse(array2[3], out awardItemData2.StrengthenLevel))
								{
									list.Add(awardItemData2);
								}
							}
						}
					}
				}
				list.AddRange(this.GetMissionOccuAwards(tableItem.OccuAward, occu));
			}
			return list;
		}

		// Token: 0x06018DF2 RID: 101874 RVA: 0x007C9A74 File Offset: 0x007C7E74
		public string GetMissionNameAppendBystatus(int status, int iTaskID = 0)
		{
			string result = string.Empty;
			switch (status)
			{
			case 0:
				result = TR.Value("mission_status_desc_init");
				break;
			case 1:
				result = TR.Value("mission_status_desc_unfinished");
				break;
			case 2:
				result = TR.Value("mission_status_desc_finished");
				break;
			default:
				result = string.Empty;
				break;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem != null && !this.IsLevelFit(iTaskID) && tableItem.TaskType == MissionTable.eTaskType.TT_TITLE)
			{
				result = TR.Value("mission_status_desc_condition");
			}
			return result;
		}

		// Token: 0x06018DF3 RID: 101875 RVA: 0x007C9B1C File Offset: 0x007C7F1C
		public bool IsLevelFit(int iTaskID)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			return tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.MinPlayerLv;
		}

		// Token: 0x06018DF4 RID: 101876 RVA: 0x007C9B5C File Offset: 0x007C7F5C
		public string GetMissionName(uint iTaskID)
		{
			string result = string.Empty;
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>((int)iTaskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				MissionTable.eTaskType taskType = tableItem.TaskType;
				string text = "F0C906";
				if (taskType == MissionTable.eTaskType.TT_MAIN)
				{
					text = "F0C906";
				}
				else if (taskType == MissionTable.eTaskType.TT_ACTIVITY)
				{
					text = "B0B0AF";
				}
				else if (taskType == MissionTable.eTaskType.TT_EXTENTION)
				{
					text = "FB3231";
				}
				else if (taskType == MissionTable.eTaskType.TT_SYSTEM)
				{
					text = "F0C906";
				}
				string text2 = text;
				if (tableItem.TaskType == MissionTable.eTaskType.TT_CYCLE)
				{
					if (this.taskGroup.ContainsKey(iTaskID))
					{
						MissionManager.SingleMissionInfo singleMissionInfo = this.taskGroup[iTaskID];
						int num = singleMissionInfo.GetIntValue("cycle_task_count");
						SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(15, string.Empty, string.Empty);
						int num2 = 0;
						if (tableItem2 != null)
						{
							num2 = tableItem2.Value;
						}
						num = (int)IntMath.Clamp((long)num, 0L, (long)num2);
						string text3 = num + "/" + num2;
						result = string.Format("<color=#{0}>{1}(<color=#{2}>{3}</color>)</color>", new object[]
						{
							text,
							tableItem.TaskName,
							text2,
							text3
						});
					}
				}
				else
				{
					result = string.Format("<color=#{0}>{1}</color>", text, tableItem.TaskName);
				}
			}
			return result;
		}

		// Token: 0x06018DF5 RID: 101877 RVA: 0x007C9CB0 File Offset: 0x007C80B0
		public MissionManager.SingleMissionInfo GetMissionInfoByDungeonID(int dungeonID)
		{
			foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
			{
				MissionManager.SingleMissionInfo value = keyValuePair.Value;
				if ((value.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || value.missionItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB) && value.status >= 0 && value.status <= 3 && value.missionItem.MapID == dungeonID)
				{
					return value;
				}
			}
			return null;
		}

		// Token: 0x06018DF6 RID: 101878 RVA: 0x007C9D38 File Offset: 0x007C8138
		public TaskStatus GetMissionStatus(uint iTaskID)
		{
			TaskStatus result = TaskStatus.TASK_FAILED;
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo))
			{
				if (singleMissionInfo.status >= 0 && singleMissionInfo.status <= 3)
				{
					return (TaskStatus)singleMissionInfo.status;
				}
				Logger.LogError("GetMissionStatus status value is out of enum");
			}
			return result;
		}

		// Token: 0x06018DF7 RID: 101879 RVA: 0x007C9D88 File Offset: 0x007C8188
		private void _TryUnbindNpcForMission(uint iTaskID, int status)
		{
			MissionTable tableItem = Singleton<TableManager>.instance.GetTableItem<MissionTable>((int)iTaskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int id = 0;
			if (status == 0)
			{
				if (tableItem.AcceptType == MissionTable.eAcceptType.ACT_NPC)
				{
					id = tableItem.MissionTakeNpc;
				}
			}
			else if (status == 2 && tableItem.FinishType == MissionTable.eFinishType.FINISH_TYPE_NPC)
			{
				id = tableItem.MissionFinishNpc;
			}
			NpcTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<NpcTable>(id, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			TaskNpcAccess.RemoveMissionListener(tableItem2.ID, (int)iTaskID);
			TaskNpcAccess.AddDialogListener(tableItem2.ID);
		}

		// Token: 0x06018DF8 RID: 101880 RVA: 0x007C9E20 File Offset: 0x007C8220
		private void _TryAcceptAutoTask(uint iTaskID, bool bTriggerImmediately = false)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (!this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo))
			{
				return;
			}
			if (singleMissionInfo.status == 0)
			{
				IClientSystem currentSystem = Singleton<ClientSystemManager>.GetInstance().CurrentSystem;
				MissionTable tableItem = Singleton<TableManager>.instance.GetTableItem<MissionTable>((int)singleMissionInfo.taskID, string.Empty, string.Empty);
				if (tableItem != null && tableItem.AcceptType == MissionTable.eAcceptType.ACT_AUTO && currentSystem != null)
				{
					if (!this.CanOpenDlgFrame() && !bTriggerImmediately)
					{
						uint num = 0U;
						MissionManager.SingleMissionInfo singleMissionInfo2 = null;
						if (this.taskGroup.TryGetValue(iTaskID, out singleMissionInfo2) && !this.cachedAutoAcceptTask.TryGetValue(iTaskID, out num))
						{
							this.cachedAutoAcceptTask.Add(iTaskID, (uint)singleMissionInfo2.status);
						}
					}
					else
					{
						this.CreateTaskDlgFrame((int)singleMissionInfo.taskID, MissionManager.TaskDlgType.TDT_BEGIN);
					}
				}
			}
		}

		// Token: 0x06018DF9 RID: 101881 RVA: 0x007C9EEC File Offset: 0x007C82EC
		public void TriggerDungenBegin()
		{
			this.dungenStart = true;
		}

		// Token: 0x06018DFA RID: 101882 RVA: 0x007C9EF8 File Offset: 0x007C82F8
		public void TriggerDungenEnd()
		{
			this.iLockedMissionID = 0;
			Dictionary<uint, uint> dictionary = DataManager<MissionManager>.GetInstance().CachedAutoAcceptTask;
			foreach (KeyValuePair<uint, uint> keyValuePair in dictionary)
			{
				if (keyValuePair.Value == 0U)
				{
					Dictionary<uint, uint>.Enumerator enumerator;
					KeyValuePair<uint, uint> keyValuePair2 = enumerator.Current;
					this._TryAcceptAutoTask(keyValuePair2.Key, true);
				}
				else
				{
					Dictionary<uint, uint>.Enumerator enumerator;
					KeyValuePair<uint, uint> keyValuePair3 = enumerator.Current;
					if (keyValuePair3.Value == 2U)
					{
						KeyValuePair<uint, uint> keyValuePair4 = enumerator.Current;
						this.CreateTaskDlgFrame((int)keyValuePair4.Key, MissionManager.TaskDlgType.TDT_END);
					}
					else
					{
						KeyValuePair<uint, uint> keyValuePair5 = enumerator.Current;
						if (keyValuePair5.Value == 9529U)
						{
							KeyValuePair<uint, uint> keyValuePair6 = enumerator.Current;
							this.CreateTaskDlgFrame((int)keyValuePair6.Key, MissionManager.TaskDlgType.TDT_BEGIN);
						}
					}
				}
			}
			dictionary.Clear();
			this.dungenStart = false;
		}

		// Token: 0x06018DFB RID: 101883 RVA: 0x007C9FD0 File Offset: 0x007C83D0
		public List<MissionManager.SingleMissionInfo> GetAllTaskByType(MissionTable.eTaskType type, MissionTable.eSubType[] subTypes = null)
		{
			List<MissionManager.SingleMissionInfo> list = null;
			List<MissionManager.SingleMissionInfo> list2 = new List<MissionManager.SingleMissionInfo>();
			if (this.m_akDiffTasks.ContainsKey(type))
			{
				list = this.m_akDiffTasks[type];
			}
			else if (type == MissionTable.eTaskType.TT_ACHIEVEMENT)
			{
				Logger.LogError("[关卡宝箱], 获取任务类型，[查章节宝箱界面问题]，m_akDiffTasks doesn`t contain MissionTable.eTaskType.TT_ACHIEVEMENT");
			}
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (subTypes == null)
					{
						list2.Add(list[i]);
					}
					else
					{
						for (int j = 0; j < subTypes.Length; j++)
						{
							if (subTypes[j] == list[i].missionItem.SubType)
							{
								list2.Add(list[i]);
								break;
							}
						}
					}
				}
			}
			if (subTypes != null && subTypes.Length > 0 && subTypes[0] == MissionTable.eSubType.Dungeon_Chest && list2.Count <= 0)
			{
				if (list == null)
				{
					Logger.LogErrorFormat("[关卡宝箱]，reList.Count = 0, list == null", new object[0]);
				}
				else
				{
					Logger.LogErrorFormat("[关卡宝箱]，reList.Count = 0, list.Count = {0}", new object[]
					{
						list.Count
					});
				}
			}
			return list2;
		}

		// Token: 0x06018DFC RID: 101884 RVA: 0x007CA0EC File Offset: 0x007C84EC
		public List<MissionManager.SingleMissionInfo> GetTaskByType(MissionTable.eTaskType eType, TaskStatus eStatus = TaskStatus.TASK_INIT, bool bInverse = false)
		{
			if (!this.m_akDiffTasks.ContainsKey(eType) || this.m_akDiffTasks[eType].Count <= 0)
			{
				return null;
			}
			List<MissionManager.SingleMissionInfo> list = this.m_akDiffTasks[eType];
			List<MissionManager.SingleMissionInfo> list2 = null;
			for (int i = 0; i < list.Count; i++)
			{
				if ((!bInverse && (TaskStatus)list[i].status == eStatus) || (bInverse && (TaskStatus)list[i].status != eStatus))
				{
					if (list2 == null)
					{
						list2 = new List<MissionManager.SingleMissionInfo>();
					}
					list2.Add(list[i]);
				}
			}
			return list2;
		}

		// Token: 0x06018DFD RID: 101885 RVA: 0x007CA194 File Offset: 0x007C8594
		public int GetMainTask(int iChapterID = 0)
		{
			int result = 0;
			if (this.taskGroup != null)
			{
				Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TableManager instance = Singleton<TableManager>.GetInstance();
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
					MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
					if (tableItem != null && (tableItem.TaskType == MissionTable.eTaskType.TT_MAIN || tableItem.TaskType == MissionTable.eTaskType.TT_CYCLE || tableItem.TaskType == MissionTable.eTaskType.TT_BRANCH || tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB || tableItem.TaskType == MissionTable.eTaskType.TT_TITLE))
					{
						if (iChapterID == 0)
						{
							result = tableItem.ID;
							break;
						}
						if (iChapterID / 10 == tableItem.MapID / 10)
						{
							result = tableItem.ID;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06018DFE RID: 101886 RVA: 0x007CA264 File Offset: 0x007C8664
		public int GetMainTaskMainMission(int iChapterID = 0)
		{
			int result = 0;
			if (this.taskGroup != null)
			{
				foreach (KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair in this.taskGroup)
				{
					if (keyValuePair.Value != null)
					{
						Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator;
						KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair2 = enumerator.Current;
						if (keyValuePair2.Value.status == 2)
						{
							TableManager instance = Singleton<TableManager>.GetInstance();
							KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair3 = enumerator.Current;
							MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair3.Key, string.Empty, string.Empty);
							if (tableItem != null && (tableItem.TaskType == MissionTable.eTaskType.TT_MAIN || tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB))
							{
								if (iChapterID == 0)
								{
									result = tableItem.ID;
									break;
								}
								if (iChapterID / 10 == tableItem.MapID / 10)
								{
									result = tableItem.ID;
									break;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06018DFF RID: 101887 RVA: 0x007CA344 File Offset: 0x007C8744
		public bool IsMainTaskDungeon(int dungeonID)
		{
			if (this.taskGroup != null)
			{
				Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
				while (enumerator.MoveNext())
				{
					TableManager instance = Singleton<TableManager>.GetInstance();
					KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
					MissionTable tableItem = instance.GetTableItem<MissionTable>((int)keyValuePair.Key, string.Empty, string.Empty);
					if (tableItem != null && (tableItem.TaskType == MissionTable.eTaskType.TT_MAIN || tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB) && tableItem.MapID == dungeonID)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x06018E00 RID: 101888 RVA: 0x007CA3CA File Offset: 0x007C87CA
		private int compareLevelItems(MissionManager.MissionLevelItems left, MissionManager.MissionLevelItems right)
		{
			return left.iLevel - right.iLevel;
		}

		// Token: 0x06018E01 RID: 101889 RVA: 0x007CA3DC File Offset: 0x007C87DC
		private void _InitLevel2MissionItems()
		{
			this.m_akMissionItems.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MissionTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					MissionTable missionTable = keyValuePair.Value as MissionTable;
					if (missionTable != null && missionTable.MissionOnOff == 1)
					{
						bool flag = false;
						for (int i = 0; i < this.m_akMissionItems.Count; i++)
						{
							if (this.m_akMissionItems[i].iLevel == missionTable.MinPlayerLv)
							{
								this.m_akMissionItems[i].akMissionItems.Add(missionTable);
								flag = true;
								break;
							}
						}
						if (!flag)
						{
							MissionManager.MissionLevelItems missionLevelItems = new MissionManager.MissionLevelItems();
							missionLevelItems.iLevel = missionTable.MinPlayerLv;
							missionLevelItems.akMissionItems = new List<MissionTable>();
							this.m_akMissionItems.Add(missionLevelItems);
							missionLevelItems.akMissionItems.Add(missionTable);
						}
					}
				}
			}
			this.m_akMissionItems.Sort(new Comparison<MissionManager.MissionLevelItems>(this.compareLevelItems));
			for (int j = 0; j < this.m_akMissionItems.Count; j++)
			{
				List<MissionTable> akMissionItems = this.m_akMissionItems[j].akMissionItems;
				if (akMissionItems != null)
				{
					akMissionItems.Sort(delegate(MissionTable x, MissionTable y)
					{
						int num = this._GetTaskTypeOrder(x.TaskType);
						int num2 = this._GetTaskTypeOrder(y.TaskType);
						int num3 = this._GetSubTypeOrder(x.SubType);
						int num4 = this._GetSubTypeOrder(y.SubType);
						if (num != num2)
						{
							return num - num2;
						}
						if (num3 != num4)
						{
							return num3 - num4;
						}
						return x.ID - y.ID;
					});
				}
			}
		}

		// Token: 0x06018E02 RID: 101890 RVA: 0x007CA54A File Offset: 0x007C894A
		private int _GetTaskTypeOrder(MissionTable.eTaskType eTask)
		{
			if (eTask == MissionTable.eTaskType.TT_CHANGEJOB)
			{
				return 6;
			}
			if (eTask == MissionTable.eTaskType.TT_MAIN)
			{
				return 1;
			}
			if (eTask == MissionTable.eTaskType.TT_BRANCH)
			{
				return 2;
			}
			if (eTask == MissionTable.eTaskType.TT_BRANCH)
			{
				return 3;
			}
			return 100;
		}

		// Token: 0x06018E03 RID: 101891 RVA: 0x007CA572 File Offset: 0x007C8972
		private int _GetSubTypeOrder(MissionTable.eSubType eSub)
		{
			if (eSub == MissionTable.eSubType.NewbieGuide_Mission)
			{
				return 10;
			}
			return 100;
		}

		// Token: 0x17002080 RID: 8320
		// (get) Token: 0x06018E04 RID: 101892 RVA: 0x007CA581 File Offset: 0x007C8981
		public List<MissionTable> UnOpenDailyMissions
		{
			get
			{
				return this.m_akUnOpenDailyMissions;
			}
		}

		// Token: 0x06018E05 RID: 101893 RVA: 0x007CA58C File Offset: 0x007C898C
		private void _CheckLevelFitDailyMission()
		{
			this.m_akUnOpenDailyMissions.Clear();
			int level = (int)DataManager<PlayerBaseData>.GetInstance().Level;
			for (int i = 0; i < this.m_akMissionItems.Count; i++)
			{
				if (this.m_akMissionItems[i].iLevel > level)
				{
					List<MissionTable> akMissionItems = this.m_akMissionItems[i].akMissionItems;
					for (int j = 0; j < akMissionItems.Count; j++)
					{
						MissionTable missionTable = akMissionItems[j];
						if (missionTable != null && missionTable.TaskType == MissionTable.eTaskType.TT_DIALY && missionTable.SubType == MissionTable.eSubType.Daily_Task)
						{
							this.m_akUnOpenDailyMissions.Add(missionTable);
						}
					}
				}
			}
			this.m_akUnOpenDailyMissions.Sort((MissionTable x, MissionTable y) => x.MinPlayerLv - y.MinPlayerLv);
			if (this.onUnOpenDailyMissionChanged != null)
			{
				this.onUnOpenDailyMissionChanged();
			}
		}

		// Token: 0x17002081 RID: 8321
		// (get) Token: 0x06018E06 RID: 101894 RVA: 0x007CA689 File Offset: 0x007C8A89
		public List<MissionManager.MissionScoreData> MissionScoreDatas
		{
			get
			{
				return this.m_akMissionScoreDatas;
			}
		}

		// Token: 0x06018E07 RID: 101895 RVA: 0x007CA694 File Offset: 0x007C8A94
		private void _InitMissionScore()
		{
			if (this.m_akMissionScoreDatas.Count > 0)
			{
				return;
			}
			this.m_akMissionScoreDatas.Clear();
			this.m_iMaxScore = 200;
			List<object> list = Singleton<TableManager>.GetInstance().GetTable<MissionScoreTable>().Values.ToList<object>();
			list.Sort((object x, object y) => (x as MissionScoreTable).Score - (y as MissionScoreTable).Score);
			for (int i = 0; i < list.Count; i++)
			{
				MissionScoreTable missionScoreTable = list[i] as MissionScoreTable;
				if (missionScoreTable != null && missionScoreTable.TotalScore > 0)
				{
					MissionManager.MissionScoreData missionScoreData = new MissionManager.MissionScoreData();
					missionScoreData.missionScoreItem = missionScoreTable;
					missionScoreData.fPostion = (float)missionScoreData.missionScoreItem.Score * 1f / (float)missionScoreData.missionScoreItem.TotalScore;
					missionScoreData.awards.Clear();
					this.m_iMaxScore = missionScoreData.missionScoreItem.TotalScore;
					if (missionScoreData.missionScoreItem.Awards.Count > 0)
					{
						for (int j = 0; j < missionScoreData.missionScoreItem.Awards.Count; j++)
						{
							if (!string.IsNullOrEmpty(missionScoreData.missionScoreItem.Awards[j]))
							{
								string[] array = missionScoreData.missionScoreItem.Awards[j].Split(new char[]
								{
									'_'
								});
								int id = 0;
								int num = 0;
								if (array.Length == 2 && int.TryParse(array[0], out id) && int.TryParse(array[1], out num))
								{
									ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
									if (tableItem != null && num > 0)
									{
										AwardItemData awardItemData = new AwardItemData();
										awardItemData.ID = id;
										awardItemData.Num = num;
										missionScoreData.awards.Add(awardItemData);
									}
								}
							}
						}
					}
					this.m_akMissionScoreDatas.Add(missionScoreData);
				}
			}
		}

		// Token: 0x17002082 RID: 8322
		// (get) Token: 0x06018E08 RID: 101896 RVA: 0x007CA889 File Offset: 0x007C8C89
		// (set) Token: 0x06018E09 RID: 101897 RVA: 0x007CA891 File Offset: 0x007C8C91
		public int Score
		{
			get
			{
				return this.m_iScore;
			}
			set
			{
				this.m_iScore = value;
				if (this.onDailyScoreChanged != null)
				{
					this.onDailyScoreChanged(this.m_iScore);
				}
			}
		}

		// Token: 0x17002083 RID: 8323
		// (get) Token: 0x06018E0A RID: 101898 RVA: 0x007CA8B6 File Offset: 0x007C8CB6
		public int MaxScore
		{
			get
			{
				return this.m_iMaxScore;
			}
		}

		// Token: 0x17002084 RID: 8324
		// (get) Token: 0x06018E0B RID: 101899 RVA: 0x007CA8BE File Offset: 0x007C8CBE
		// (set) Token: 0x06018E0C RID: 101900 RVA: 0x007CA8C6 File Offset: 0x007C8CC6
		public List<LegendNotifyData> DicLegendNotifies
		{
			get
			{
				return this.dicLegendNotifies;
			}
			private set
			{
				this.dicLegendNotifies = value;
			}
		}

		// Token: 0x06018E0D RID: 101901 RVA: 0x007CA8D0 File Offset: 0x007C8CD0
		public void ClearLegendNotifies()
		{
			for (int i = 0; i < DataManager<MissionManager>.GetInstance().DicLegendNotifies.Count; i++)
			{
				DataManager<MissionManager>.GetInstance().DicLegendNotifies[i].bNotify = false;
			}
		}

		// Token: 0x17002085 RID: 8325
		// (get) Token: 0x06018E0E RID: 101902 RVA: 0x007CA913 File Offset: 0x007C8D13
		// (set) Token: 0x06018E0F RID: 101903 RVA: 0x007CA91B File Offset: 0x007C8D1B
		public List<int> AcquiredChestIDs
		{
			get
			{
				return this.m_akAcquiredChestIDs;
			}
			set
			{
				this.m_akAcquiredChestIDs = value;
				if (this.onChestIdsChanged != null)
				{
					this.onChestIdsChanged();
				}
			}
		}

		// Token: 0x06018E10 RID: 101904 RVA: 0x007CA93C File Offset: 0x007C8D3C
		public void SetDailyMaskProperty(DailyTaskMaskProperty property)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MissionScoreTable>();
			List<int> list = new List<int>();
			uint num = 0U;
			while ((ulong)num < (ulong)((long)table.Count))
			{
				int num2 = (int)(num + 1U);
				if (property.CheckMask((uint)num2))
				{
					MissionScoreTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionScoreTable>(num2, string.Empty, string.Empty);
					if (tableItem != null)
					{
						list.Add(num2);
					}
				}
				num += 1U;
			}
			this.AcquiredChestIDs = list;
		}

		// Token: 0x06018E11 RID: 101905 RVA: 0x007CA9B0 File Offset: 0x007C8DB0
		public void SendAcquireAwards(int id)
		{
			SceneDailyScoreRewardReq sceneDailyScoreRewardReq = new SceneDailyScoreRewardReq();
			sceneDailyScoreRewardReq.boxId = (byte)id;
			NetManager.Instance().SendCommand<SceneDailyScoreRewardReq>(ServerType.GATE_SERVER, sceneDailyScoreRewardReq);
		}

		// Token: 0x06018E12 RID: 101906 RVA: 0x007CA9D8 File Offset: 0x007C8DD8
		private void OnReceiveSceneDailyScoreRewardRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneDailyScoreRewardRes sceneDailyScoreRewardRes = new SceneDailyScoreRewardRes();
			sceneDailyScoreRewardRes.decode(msgData.bytes);
			if (sceneDailyScoreRewardRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneDailyScoreRewardRes.result, string.Empty);
			}
		}

		// Token: 0x06018E13 RID: 101907 RVA: 0x007CAA1C File Offset: 0x007C8E1C
		public int GetNextLevelMission(int iLevel)
		{
			for (int i = 0; i < this.m_akMissionItems.Count; i++)
			{
				if (this.m_akMissionItems[i].iLevel > iLevel)
				{
					for (int j = 0; j < this.m_akMissionItems[i].akMissionItems.Count; j++)
					{
						if (this.m_akMissionItems[i].akMissionItems[j].TaskType == MissionTable.eTaskType.TT_MAIN)
						{
							return this.m_akMissionItems[i].iLevel;
						}
					}
				}
			}
			return iLevel;
		}

		// Token: 0x06018E14 RID: 101908 RVA: 0x007CAAB8 File Offset: 0x007C8EB8
		public MissionTable GetNextMissionItem(int iLevel)
		{
			for (int i = 0; i < this.m_akMissionItems.Count; i++)
			{
				if (this.m_akMissionItems[i].iLevel > iLevel)
				{
					for (int j = 0; j < this.m_akMissionItems[i].akMissionItems.Count; j++)
					{
						if (this.m_akMissionItems[i].akMissionItems[j].TaskType == MissionTable.eTaskType.TT_MAIN && this.m_akMissionItems[i].akMissionItems.Count > 0)
						{
							return this.m_akMissionItems[i].akMissionItems[0];
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06018E15 RID: 101909 RVA: 0x007CAB78 File Offset: 0x007C8F78
		public bool HasLevelUpMission(int iLevel, MissionTable.eTaskType eTaskType)
		{
			if (this.m_akMissionItems != null && this.m_akMissionItems.Count > 0)
			{
				List<MissionManager.MissionLevelItems> list = this.m_akMissionItems.FindAll((MissionManager.MissionLevelItems x) => x.iLevel > iLevel);
				for (int i = 0; i < list.Count; i++)
				{
					for (int j = 0; j < list[i].akMissionItems.Count; j++)
					{
						if (list[i].akMissionItems[j].TaskType == eTaskType)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018E16 RID: 101910 RVA: 0x007CAC20 File Offset: 0x007C9020
		private int _CmpMissionTypeSort(MissionManager.SingleMissionInfo x, MissionManager.SingleMissionInfo y)
		{
			if (x.missionItem.MinPlayerLv != y.missionItem.MinPlayerLv)
			{
				return x.missionItem.MinPlayerLv - y.missionItem.MinPlayerLv;
			}
			return x.missionItem.ID - y.missionItem.ID;
		}

		// Token: 0x06018E17 RID: 101911 RVA: 0x007CAC78 File Offset: 0x007C9078
		private void _OnAddTypeMission(MissionManager.SingleMissionInfo missionInfo, bool bNeedSort)
		{
			if (missionInfo != null)
			{
				List<MissionManager.SingleMissionInfo> list = null;
				if (!this.m_akType2MissionItems.TryGetValue(missionInfo.missionItem.TaskType, out list))
				{
					list = new List<MissionManager.SingleMissionInfo>();
					this.m_akType2MissionItems.Add(missionInfo.missionItem.TaskType, list);
				}
				list.RemoveAll((MissionManager.SingleMissionInfo x) => x.missionItem.ID == missionInfo.missionItem.ID);
				list.Add(missionInfo);
				if (bNeedSort)
				{
					list.Sort(new Comparison<MissionManager.SingleMissionInfo>(this._CmpMissionTypeSort));
				}
			}
		}

		// Token: 0x06018E18 RID: 101912 RVA: 0x007CAD1C File Offset: 0x007C911C
		private void _SortAllTypeMission()
		{
			foreach (KeyValuePair<MissionTable.eTaskType, List<MissionManager.SingleMissionInfo>> keyValuePair in this.m_akType2MissionItems)
			{
				keyValuePair.Value.Sort(new Comparison<MissionManager.SingleMissionInfo>(this._CmpMissionTypeSort));
			}
		}

		// Token: 0x06018E19 RID: 101913 RVA: 0x007CAD68 File Offset: 0x007C9168
		private void _OnRemoveTypeMission(int iTaskID)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				List<MissionManager.SingleMissionInfo> list = null;
				if (this.m_akType2MissionItems.TryGetValue(tableItem.TaskType, out list))
				{
					list.RemoveAll((MissionManager.SingleMissionInfo x) => x.missionItem.ID == iTaskID);
				}
			}
		}

		// Token: 0x06018E1A RID: 101914 RVA: 0x007CADD0 File Offset: 0x007C91D0
		public List<int> GetMissionDungenTraceList()
		{
			List<int> list = new List<int>();
			if (!this.dungenStart)
			{
				return list;
			}
			List<uint> list2 = this.taskGroup.Keys.ToList<uint>();
			List<MissionManager.SingleMissionInfo> list3 = this.taskGroup.Values.ToList<MissionManager.SingleMissionInfo>();
			for (int i = 0; i < list2.Count; i++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = list3[i];
				if (this.IsLevelFit(singleMissionInfo.missionItem.ID))
				{
					if (singleMissionInfo != null && singleMissionInfo.missionItem != null)
					{
						if (singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_MAIN || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_BRANCH || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_CYCLE || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_AWAKEN || singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_TITLE)
						{
							if (singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_CHANGEJOB || singleMissionInfo.status == 1 || singleMissionInfo.status == 2)
							{
								if (DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId / 10 == singleMissionInfo.missionItem.MapID / 10 && DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId >= singleMissionInfo.missionItem.MapID)
								{
									list.Add((int)list2[i]);
								}
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x17002086 RID: 8326
		// (get) Token: 0x06018E1B RID: 101915 RVA: 0x007CAF63 File Offset: 0x007C9363
		public int ListCnt
		{
			get
			{
				return this.mListCnt;
			}
		}

		// Token: 0x17002087 RID: 8327
		// (get) Token: 0x06018E1C RID: 101916 RVA: 0x007CAF6B File Offset: 0x007C936B
		public int[] TraceList
		{
			get
			{
				return this.mList;
			}
		}

		// Token: 0x06018E1D RID: 101917 RVA: 0x007CAF74 File Offset: 0x007C9374
		public int[] GetTraceTaskList()
		{
			this.mListCnt = 0;
			if (this.mList != null)
			{
				for (int i = 0; i < this.mList.Length; i++)
				{
					this.mList[i] = 0;
				}
			}
			MissionManager.SingleMissionInfo[] array = new MissionManager.SingleMissionInfo[this.taskGroup.Count];
			int num = 0;
			Dictionary<uint, MissionManager.SingleMissionInfo>.Enumerator enumerator = this.taskGroup.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MissionManager.SingleMissionInfo[] array2 = array;
				int num2 = num++;
				KeyValuePair<uint, MissionManager.SingleMissionInfo> keyValuePair = enumerator.Current;
				array2[num2] = keyValuePair.Value;
			}
			int num3 = num;
			int[] aiStatus = new int[]
			{
				2,
				1,
				0,
				3,
				4,
				5
			};
			int[] aiMissionType = new int[]
			{
				4,
				-1,
				3,
				5,
				6,
				7,
				8,
				0,
				-2,
				1,
				1,
				2
			};
			for (int j = 0; j < num3; j++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = array[j];
				if (singleMissionInfo == null || singleMissionInfo.missionItem == null)
				{
					array[j] = array[num3 - 1];
					array[num3 - 1] = null;
					j--;
					num3--;
				}
				else if (!this.IsLevelFit(singleMissionInfo.missionItem.ID))
				{
					array[j] = array[num3 - 1];
					array[num3 - 1] = null;
					j--;
					num3--;
				}
				else if (singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_MAIN && singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_CYCLE && singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_BRANCH && singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_CHANGEJOB && singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_TITLE && singleMissionInfo.missionItem.TaskType != MissionTable.eTaskType.TT_AWAKEN)
				{
					array[j] = array[num3 - 1];
					array[num3 - 1] = null;
					j--;
					num3--;
				}
				else if (singleMissionInfo.missionItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB && singleMissionInfo.status == 0)
				{
					array[j] = array[num3 - 1];
					array[num3 - 1] = null;
					j--;
					num3--;
				}
			}
			Array.Sort<MissionManager.SingleMissionInfo>(array, delegate(MissionManager.SingleMissionInfo l, MissionManager.SingleMissionInfo r)
			{
				if (l == null && r == null)
				{
					return 0;
				}
				if (null == l != (null == r))
				{
					return (l == null) ? 1 : -1;
				}
				if (l.missionItem.TaskType != r.missionItem.TaskType)
				{
					return aiMissionType[(int)l.missionItem.TaskType] - aiMissionType[(int)r.missionItem.TaskType];
				}
				if (l.missionItem.SubType != r.missionItem.SubType)
				{
					if (l.missionItem.SubType == MissionTable.eSubType.NewbieGuide_Mission)
					{
						return -1;
					}
					if (r.missionItem.SubType == MissionTable.eSubType.NewbieGuide_Mission)
					{
						return 1;
					}
				}
				if (l.status != r.status)
				{
					return aiStatus[(int)l.status] - aiStatus[(int)r.status];
				}
				return r.missionItem.MinPlayerLv - l.missionItem.MinPlayerLv;
			});
			int num4 = 0;
			while (num4 < array.Length && num4 < num3 && num4 < this.mList.Length)
			{
				if (this.mListCnt < this.mList.Length)
				{
					this.mList[this.mListCnt++] = (int)array[num4].taskID;
				}
				num4++;
			}
			if (this._HasFinishedCurrentAll(MissionTable.eTaskType.TT_MAIN))
			{
				if (this._HasFinishedCurLevelAndHasNextLv(MissionTable.eTaskType.TT_MAIN))
				{
					if (this.mListCnt < this.mList.Length)
					{
						this.mList[this.mListCnt++] = 0;
					}
					else
					{
						this.mList[this.mListCnt - 1] = 0;
					}
				}
				else if (this.mListCnt < this.mList.Length)
				{
					this.mList[this.mListCnt++] = 2;
				}
				else
				{
					this.mList[this.mListCnt - 1] = 2;
				}
				int num5 = this.mList[this.mListCnt - 1];
				for (int k = this.mListCnt - 1; k > 0; k--)
				{
					this.mList[k] = this.mList[k - 1];
				}
				this.mList[0] = num5;
			}
			List<MissionManager.SingleMissionInfo> list = new List<MissionManager.SingleMissionInfo>();
			if (list != null)
			{
				for (int n = 0; n < this.mList.Length; n++)
				{
					list.Add(DataManager<MissionManager>.GetInstance().GetMission((uint)this.mList[n]));
				}
				MainMissionList.SortBranchTasks(ref list);
				for (int m = 0; m < list.Count; m++)
				{
					MissionManager.SingleMissionInfo singleMissionInfo2 = list[m];
					if (singleMissionInfo2 != null)
					{
						this.mList[m] = (int)singleMissionInfo2.taskID;
					}
				}
			}
			return this.mList;
		}

		// Token: 0x06018E1E RID: 101918 RVA: 0x007CB38C File Offset: 0x007C978C
		private bool _HasFinishedCurLevelAndHasNextLv(MissionTable.eTaskType eType)
		{
			return this._HasFinishedCurrentAll(eType) && this.HasLevelUpMission((int)DataManager<PlayerBaseData>.GetInstance().Level, eType);
		}

		// Token: 0x06018E1F RID: 101919 RVA: 0x007CB3B5 File Offset: 0x007C97B5
		private bool _HasFinishedCurrentAll(MissionTable.eTaskType eType)
		{
			return !this.m_akType2MissionItems.ContainsKey(eType) || this.m_akType2MissionItems[eType].Count <= 0;
		}

		// Token: 0x06018E20 RID: 101920 RVA: 0x007CB3E4 File Offset: 0x007C97E4
		private bool _HasFinshedAll(MissionTable.eTaskType eType)
		{
			return (!this.m_akType2MissionItems.ContainsKey(eType) || this.m_akType2MissionItems[eType].Count <= 0) && !this.HasLevelUpMission((int)DataManager<PlayerBaseData>.GetInstance().Level, eType);
		}

		// Token: 0x06018E21 RID: 101921 RVA: 0x007CB434 File Offset: 0x007C9834
		private void _TryOpenFunctionFrame()
		{
			if (!this.bLoadingScene && ClientSystem.IsTargetSystem<ClientSystemTown>())
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				if (clientSystemTown != null)
				{
					CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
					if (tableItem == null)
					{
						return;
					}
					if (tableItem.SceneType == CitySceneTable.eSceneType.PK_PREPARE)
					{
						if (Singleton<ClientSystemManager>.instance.IsFrameOpen<FunctionFrame>(null))
						{
							Singleton<ClientSystemManager>.instance.CloseFrame<FunctionFrame>(null, false);
						}
						return;
					}
					if (!Singleton<ClientSystemManager>.instance.IsFrameOpen<FunctionFrame>(null))
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SwitchToMission, null, null, null, null);
					}
					UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
					idleUIEvent.EventID = EUIEventID.FunctionFrameUpdate;
					UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
				}
			}
		}

		// Token: 0x17002088 RID: 8328
		// (get) Token: 0x06018E22 RID: 101922 RVA: 0x007CB4FC File Offset: 0x007C98FC
		public int LockedMissionID
		{
			get
			{
				return this.iLockedMissionID;
			}
		}

		// Token: 0x06018E23 RID: 101923 RVA: 0x007CB504 File Offset: 0x007C9904
		private bool _TryOpenTaskGuideFrame(int taskID, int chapterID = 0, bool bCreateNPC = false)
		{
			bool result = false;
			if (!this.bLoadingScene && ClientSystem.IsTargetSystem<ClientSystemBattle>())
			{
				MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(taskID, string.Empty, string.Empty);
				if (!BattleMain.IsModeTrain(BattleMain.battleType) && !BattleMain.IsModeMultiplayer(BattleMain.mode) && tableItem != null && chapterID >= tableItem.MapID && (tableItem.TaskType == MissionTable.eTaskType.TT_MAIN || tableItem.TaskType == MissionTable.eTaskType.TT_CYCLE || tableItem.TaskType == MissionTable.eTaskType.TT_BRANCH || tableItem.TaskType == MissionTable.eTaskType.TT_CHANGEJOB || tableItem.TaskType == MissionTable.eTaskType.TT_AWAKEN || tableItem.TaskType == MissionTable.eTaskType.TT_TITLE))
				{
					MissionDungenFrame.Open();
					this.iLockedMissionID = taskID;
					if (tableItem.TaskLevelType == MissionTable.eTaskLevelType.NPC_PROTECT)
					{
						PVEBattle pvebattle = BattleMain.instance.GetBattle() as PVEBattle;
						if (pvebattle != null)
						{
							try
							{
								int num = Convert.ToInt32(tableItem.MissionParam);
								if (num <= 0)
								{
									Logger.LogErrorFormat("npcid:{0}", new object[]
									{
										num
									});
								}
								else if (bCreateNPC)
								{
									pvebattle.CreateNPC(num);
								}
							}
							catch (Exception ex)
							{
								Logger.LogErrorFormat("error:{0}", new object[]
								{
									ex.ToString()
								});
							}
						}
					}
					TalkTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(tableItem.InTaskDlgID, string.Empty, string.Empty);
					if (this.taskGroup.ContainsKey((uint)taskID))
					{
						MissionManager.SingleMissionInfo singleMissionInfo = this.taskGroup[(uint)taskID];
						if (singleMissionInfo != null && singleMissionInfo.status == 1 && tableItem2 != null && this.dungenStart && DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId / 10 == tableItem.MapID / 10 && DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId >= tableItem.MapID)
						{
							result = true;
							if (!BattleMain.IsModePvP(BattleMain.battleType) && BattleMain.instance.Main != null)
							{
								BattleMain.instance.GetDungeonManager().PauseFight(false, "mission", false);
							}
							this.CreateDialogFrame(tableItem2.ID, taskID, new TaskDialogFrame.OnDialogOver().AddListener(delegate
							{
								ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemBattle;
								clientSystemBattle.ShowTraceAnimation();
								if (!BattleMain.IsModePvP(BattleMain.battleType) && BattleMain.instance.Main != null)
								{
									BattleMain.instance.GetDungeonManager().ResumeFight(false, "mission", false);
								}
							}));
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06018E24 RID: 101924 RVA: 0x007CB764 File Offset: 0x007C9B64
		private void CreateTaskDlgFrame(int iTaskID, MissionManager.TaskDlgType eTaskDlgType)
		{
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(iTaskID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (eTaskDlgType == MissionManager.TaskDlgType.TDT_BEGIN || eTaskDlgType == MissionManager.TaskDlgType.TDT_MIDDLE)
				{
					TalkTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<TalkTable>(tableItem.BefTaskDlgID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						this.CloseAllDialog();
						this.CreateDialogFrame(tableItem.BefTaskDlgID, iTaskID, null);
					}
				}
				else if (eTaskDlgType == MissionManager.TaskDlgType.TDT_END && tableItem.FinishType == MissionTable.eFinishType.FINISH_TYPE_AUTO)
				{
					TalkTable tableItem3 = Singleton<TableManager>.instance.GetTableItem<TalkTable>(tableItem.AftTaskDlgID, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						this.CloseAllDialog();
						this.CreateDialogFrame(tableItem.AftTaskDlgID, iTaskID, null);
					}
				}
			}
		}

		// Token: 0x06018E25 RID: 101925 RVA: 0x007CB827 File Offset: 0x007C9C27
		private void _PushAchievementItems(int iId)
		{
			if (this._PopAchievementItems.Count < 3)
			{
				this._PopAchievementItems.Add(iId);
			}
			else
			{
				this._PopAchievementItems.RemoveAt(0);
				this._PopAchievementItems.Add(iId);
			}
		}

		// Token: 0x06018E26 RID: 101926 RVA: 0x007CB864 File Offset: 0x007C9C64
		public int PopAchievementItem()
		{
			if (this._PopAchievementItems.Count > 0)
			{
				int result = this._PopAchievementItems[0];
				this._PopAchievementItems.RemoveAt(0);
				return result;
			}
			return 0;
		}

		// Token: 0x06018E27 RID: 101927 RVA: 0x007CB89E File Offset: 0x007C9C9E
		public bool HasAchievementItem()
		{
			return this._PopAchievementItems.Count > 0;
		}

		// Token: 0x06018E28 RID: 101928 RVA: 0x007CB8AE File Offset: 0x007C9CAE
		public void PushTestAchievementItems(int iId)
		{
			this._PushAchievementItems(iId);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAchievementComplete, null, null, null, null);
		}

		// Token: 0x06018E29 RID: 101929 RVA: 0x007CB8CA File Offset: 0x007C9CCA
		public static void CommandOpen(object argv)
		{
			DataManager<MissionManager>.GetInstance().PushTestAchievementItems(3251);
		}

		// Token: 0x06018E2A RID: 101930 RVA: 0x007CB8DC File Offset: 0x007C9CDC
		public void FinishAccountTaskReq(int ID)
		{
			WorldSubmitAccountTask worldSubmitAccountTask = new WorldSubmitAccountTask();
			worldSubmitAccountTask.taskId = (uint)ID;
			NetManager.Instance().SendCommand<WorldSubmitAccountTask>(ServerType.GATE_SERVER, worldSubmitAccountTask);
			Singleton<GameStatisticManager>.GetInstance().DoStatTask(StatTaskType.TASK_FINISH, ID);
		}

		// Token: 0x04011E59 RID: 73305
		private bool bLoadingScene;

		// Token: 0x04011E5A RID: 73306
		private Queue<MissionManager.CachedMsg> m_akCachedNetMsg = new Queue<MissionManager.CachedMsg>();

		// Token: 0x04011E5B RID: 73307
		private Dictionary<uint, MissionManager.SingleMissionInfo> taskSet = new Dictionary<uint, MissionManager.SingleMissionInfo>();

		// Token: 0x04011E5C RID: 73308
		private Dictionary<MissionTable.eTaskType, List<MissionManager.SingleMissionInfo>> m_akDiffTasks = new Dictionary<MissionTable.eTaskType, List<MissionManager.SingleMissionInfo>>();

		// Token: 0x04011E5D RID: 73309
		private Dictionary<int, TaskDialogFrame> dialogFrames = new Dictionary<int, TaskDialogFrame>();

		// Token: 0x04011E5E RID: 73310
		private Queue<int> dialogIds = new Queue<int>();

		// Token: 0x04011E5F RID: 73311
		private Dictionary<uint, uint> cachedAutoAcceptTask = new Dictionary<uint, uint>();

		// Token: 0x04011E61 RID: 73313
		private int m_iFunctionTraceId = -1;

		// Token: 0x04011E62 RID: 73314
		public MissionManager.OnMissionChanged missionChangedDelegate;

		// Token: 0x04011E63 RID: 73315
		public MissionManager.DelegateAddNewMission onAddNewMission;

		// Token: 0x04011E64 RID: 73316
		public MissionManager.DelegateDeleteMission onDeleteMission;

		// Token: 0x04011E65 RID: 73317
		public MissionManager.OnDeleteMissionValue onDeleteMissionValue;

		// Token: 0x04011E66 RID: 73318
		public MissionManager.DelegateSyncMission onSyncMission;

		// Token: 0x04011E67 RID: 73319
		public MissionManager.DelegateUpdateMission onUpdateMission;

		// Token: 0x04011E68 RID: 73320
		private bool bTaskDirty;

		// Token: 0x04011E69 RID: 73321
		private MissionManager.SortMissionInfo sortMissionInfoCmp = new MissionManager.SortMissionInfo();

		// Token: 0x04011E6A RID: 73322
		private static Regex[] m_akRegexs = new Regex[]
		{
			new Regex("<key=([a-zA-Z0-9]+)/>"),
			new Regex("<key=([a-zA-Z0-9]+)/([0-9]+)/>")
		};

		// Token: 0x04011E6B RID: 73323
		private List<MissionManager.MissionLevelItems> m_akMissionItems = new List<MissionManager.MissionLevelItems>();

		// Token: 0x04011E6C RID: 73324
		private List<MissionTable> m_akUnOpenDailyMissions = new List<MissionTable>();

		// Token: 0x04011E6D RID: 73325
		public MissionManager.OnUnOpenDailyMissionChanged onUnOpenDailyMissionChanged;

		// Token: 0x04011E6E RID: 73326
		private List<MissionManager.MissionScoreData> m_akMissionScoreDatas = new List<MissionManager.MissionScoreData>();

		// Token: 0x04011E6F RID: 73327
		public MissionManager.OnDailyScoreChanged onDailyScoreChanged;

		// Token: 0x04011E70 RID: 73328
		private int m_iScore;

		// Token: 0x04011E71 RID: 73329
		private int m_iMaxScore;

		// Token: 0x04011E72 RID: 73330
		private List<LegendNotifyData> dicLegendNotifies = new List<LegendNotifyData>();

		// Token: 0x04011E73 RID: 73331
		private List<int> m_akAcquiredChestIDs = new List<int>();

		// Token: 0x04011E74 RID: 73332
		public MissionManager.OnChestIdsChanged onChestIdsChanged;

		// Token: 0x04011E75 RID: 73333
		private Dictionary<MissionTable.eTaskType, List<MissionManager.SingleMissionInfo>> m_akType2MissionItems = new Dictionary<MissionTable.eTaskType, List<MissionManager.SingleMissionInfo>>();

		// Token: 0x04011E76 RID: 73334
		private int[] mList = new int[6];

		// Token: 0x04011E77 RID: 73335
		private int mListCnt;

		// Token: 0x04011E78 RID: 73336
		private int iLockedMissionID;

		// Token: 0x04011E79 RID: 73337
		private List<int> _PopAchievementItems = new List<int>(8);

		// Token: 0x04011E7A RID: 73338
		private const int _MaxItems = 3;

		// Token: 0x0200458A RID: 17802
		public class CachedMsg
		{
			// Token: 0x06018E32 RID: 101938 RVA: 0x007CBA4F File Offset: 0x007C9E4F
			public CachedMsg(uint id, MsgDATA msgData)
			{
				this.id = id;
				this.msgData = msgData;
			}

			// Token: 0x04011E80 RID: 73344
			public uint id;

			// Token: 0x04011E81 RID: 73345
			public MsgDATA msgData;
		}

		// Token: 0x0200458B RID: 17803
		public class SingleMissionInfo : IComparable<MissionManager.SingleMissionInfo>
		{
			// Token: 0x06018E33 RID: 101939 RVA: 0x007CBA68 File Offset: 0x007C9E68
			public SingleMissionInfo()
			{
				this.taskID = 0U;
				this.status = 0;
				this.taskContents.Clear();
				this.missionItem = null;
				this.finTime = 0U;
				this.submitCount = 0;
			}

			// Token: 0x06018E34 RID: 101940 RVA: 0x007CBAB4 File Offset: 0x007C9EB4
			public string GetKeyValue(string key)
			{
				if (this.taskContents.ContainsKey(key))
				{
					return this.taskContents[key];
				}
				return string.Empty;
			}

			// Token: 0x06018E35 RID: 101941 RVA: 0x007CBADC File Offset: 0x007C9EDC
			public int GetIntValue(string key)
			{
				int result = 0;
				if (this.taskContents.ContainsKey(key) && !int.TryParse(this.taskContents[key], out result))
				{
					Logger.LogErrorFormat("attempt to convert non-int string 2 int type", new object[0]);
				}
				return result;
			}

			// Token: 0x06018E36 RID: 101942 RVA: 0x007CBB28 File Offset: 0x007C9F28
			public int CompareTo(MissionManager.SingleMissionInfo other)
			{
				if (this.status != other.status)
				{
					return MissionManager.SingleMissionInfo._sortOrder[(int)this.status] - MissionManager.SingleMissionInfo._sortOrder[(int)other.status];
				}
				int num = (int)this.taskID;
				int num2 = (int)other.taskID;
				return num - num2;
			}

			// Token: 0x06018E37 RID: 101943 RVA: 0x007CBB74 File Offset: 0x007C9F74
			public int LegendCompareTo(MissionManager.SingleMissionInfo other)
			{
				if (this.status != other.status)
				{
					return MissionManager.SingleMissionInfo._LegendSortOrder[(int)this.status] - MissionManager.SingleMissionInfo._LegendSortOrder[(int)other.status];
				}
				if (this.missionItem.SortID != other.missionItem.SortID)
				{
					return this.missionItem.SortID - other.missionItem.SortID;
				}
				int num = (int)this.taskID;
				int num2 = (int)other.taskID;
				return num - num2;
			}

			// Token: 0x04011E82 RID: 73346
			public uint taskID;

			// Token: 0x04011E83 RID: 73347
			public byte status;

			// Token: 0x04011E84 RID: 73348
			public Dictionary<string, string> taskContents = new Dictionary<string, string>();

			// Token: 0x04011E85 RID: 73349
			public MissionTable missionItem;

			// Token: 0x04011E86 RID: 73350
			public uint finTime;

			// Token: 0x04011E87 RID: 73351
			public byte submitCount;

			// Token: 0x04011E88 RID: 73352
			private static int[] _sortOrder = new int[]
			{
				2,
				3,
				1,
				4,
				0,
				5
			};

			// Token: 0x04011E89 RID: 73353
			private static int[] _LegendSortOrder = new int[]
			{
				4,
				2,
				1,
				3,
				0,
				5
			};
		}

		// Token: 0x0200458C RID: 17804
		public class OnTriggerLoginEnd
		{
			// Token: 0x06018E39 RID: 101945 RVA: 0x007CBC1E File Offset: 0x007CA01E
			public OnTriggerLoginEnd(MessageEvents msgEvent)
			{
				this.msgEvent = msgEvent;
			}

			// Token: 0x06018E3A RID: 101946 RVA: 0x007CBC2D File Offset: 0x007CA02D
			public void OnTrigger()
			{
				Singleton<ClientSystemManager>.GetInstance().OnSwitchSystemFinished.RemoveListener(new UnityAction(this.OnTrigger));
			}

			// Token: 0x04011E8A RID: 73354
			private MessageEvents msgEvent;
		}

		// Token: 0x0200458D RID: 17805
		// (Invoke) Token: 0x06018E3C RID: 101948
		public delegate void OnMissionChanged();

		// Token: 0x0200458E RID: 17806
		// (Invoke) Token: 0x06018E40 RID: 101952
		public delegate void DelegateAddNewMission(uint taskID);

		// Token: 0x0200458F RID: 17807
		// (Invoke) Token: 0x06018E44 RID: 101956
		public delegate void DelegateDeleteMission(uint taskID);

		// Token: 0x02004590 RID: 17808
		// (Invoke) Token: 0x06018E48 RID: 101960
		public delegate void OnDeleteMissionValue(MissionManager.SingleMissionInfo value);

		// Token: 0x02004591 RID: 17809
		// (Invoke) Token: 0x06018E4C RID: 101964
		public delegate void DelegateSyncMission(uint taskID);

		// Token: 0x02004592 RID: 17810
		// (Invoke) Token: 0x06018E50 RID: 101968
		public delegate void DelegateUpdateMission(uint taskID);

		// Token: 0x02004593 RID: 17811
		public class DailyComparser : IComparer<MissionInfo>
		{
			// Token: 0x06018E54 RID: 101972 RVA: 0x007CBC52 File Offset: 0x007CA052
			public int Compare(MissionInfo x, MissionInfo y)
			{
				if (x.taskID == y.taskID)
				{
					return 0;
				}
				if (x.taskID < y.taskID)
				{
					return -1;
				}
				return 1;
			}
		}

		// Token: 0x02004594 RID: 17812
		private class SortMissionInfo : IComparer<MissionInfo>
		{
			// Token: 0x06018E56 RID: 101974 RVA: 0x007CBC83 File Offset: 0x007CA083
			public int Compare(MissionInfo x, MissionInfo y)
			{
				if (x.taskID < y.taskID)
				{
					return -1;
				}
				if (x.taskID > y.taskID)
				{
					return 1;
				}
				return 0;
			}
		}

		// Token: 0x02004595 RID: 17813
		public enum MaterialRegexType
		{
			// Token: 0x04011E8C RID: 73356
			MRT_KEY,
			// Token: 0x04011E8D RID: 73357
			MRT_KEY_VALUE,
			// Token: 0x04011E8E RID: 73358
			MRT_COUNT
		}

		// Token: 0x02004596 RID: 17814
		public class MaterialMatchInfo
		{
			// Token: 0x04011E8F RID: 73359
			public Match match;

			// Token: 0x04011E90 RID: 73360
			public MissionManager.MaterialRegexType eMaterialRegexType;
		}

		// Token: 0x02004597 RID: 17815
		// (Invoke) Token: 0x06018E59 RID: 101977
		public delegate MissionManager.TokenObject OnTokenize(MissionManager.MaterialMatchInfo matchInfo);

		// Token: 0x02004598 RID: 17816
		public class TokenObject
		{
			// Token: 0x04011E91 RID: 73361
			public MissionManager.MaterialRegexType eMaterialRegexType;

			// Token: 0x04011E92 RID: 73362
			public string tokenedValue;

			// Token: 0x04011E93 RID: 73363
			public object param0;

			// Token: 0x04011E94 RID: 73364
			public object param1;

			// Token: 0x04011E95 RID: 73365
			public object param2;
		}

		// Token: 0x02004599 RID: 17817
		public class ParseObject
		{
			// Token: 0x04011E96 RID: 73366
			public string content;

			// Token: 0x04011E97 RID: 73367
			public List<MissionManager.TokenObject> tokens = new List<MissionManager.TokenObject>();
		}

		// Token: 0x0200459A RID: 17818
		public class MissionLevelItems
		{
			// Token: 0x04011E98 RID: 73368
			public int iLevel;

			// Token: 0x04011E99 RID: 73369
			public List<MissionTable> akMissionItems;
		}

		// Token: 0x0200459B RID: 17819
		// (Invoke) Token: 0x06018E60 RID: 101984
		public delegate void OnUnOpenDailyMissionChanged();

		// Token: 0x0200459C RID: 17820
		public class MissionScoreData
		{
			// Token: 0x06018E64 RID: 101988 RVA: 0x007CBCEA File Offset: 0x007CA0EA
			public void GetIcon(ref Image image)
			{
				if (!this.bOpen)
				{
					ETCImageLoader.LoadSprite(ref image, this.missionScoreItem.UnOpenedChestBoxIcon, true);
					return;
				}
				ETCImageLoader.LoadSprite(ref image, this.missionScoreItem.OpenedChestBoxIcon, true);
			}

			// Token: 0x04011E9A RID: 73370
			public MissionScoreTable missionScoreItem;

			// Token: 0x04011E9B RID: 73371
			public float fPostion;

			// Token: 0x04011E9C RID: 73372
			public bool bOpen;

			// Token: 0x04011E9D RID: 73373
			public List<AwardItemData> awards = new List<AwardItemData>();
		}

		// Token: 0x0200459D RID: 17821
		// (Invoke) Token: 0x06018E66 RID: 101990
		public delegate void OnDailyScoreChanged(int score);

		// Token: 0x0200459E RID: 17822
		// (Invoke) Token: 0x06018E6A RID: 101994
		public delegate void OnChestIdsChanged();

		// Token: 0x0200459F RID: 17823
		private enum TaskDlgType
		{
			// Token: 0x04011E9F RID: 73375
			TDT_BEGIN,
			// Token: 0x04011EA0 RID: 73376
			TDT_MIDDLE,
			// Token: 0x04011EA1 RID: 73377
			TDT_END
		}
	}
}
