using System;
using System.Collections.Generic;
using System.Diagnostics;
using FashionLimitTimeBuy;
using GameClient;
using Network;
using Protocol;

namespace ActivityLimitTime
{
	// Token: 0x020011BC RID: 4540
	public class ActivityLimitTimeManager
	{
		// Token: 0x17001A92 RID: 6802
		// (get) Token: 0x0600AE47 RID: 44615 RVA: 0x0025FBCD File Offset: 0x0025DFCD
		public ActivityLimitTimeData BindPhoneOtherData
		{
			get
			{
				return this.bindPhoneOtherData;
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600AE48 RID: 44616 RVA: 0x0025FBD8 File Offset: 0x0025DFD8
		// (remove) Token: 0x0600AE49 RID: 44617 RVA: 0x0025FC10 File Offset: 0x0025E010
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action ServerSyncActivityDataListener;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x0600AE4A RID: 44618 RVA: 0x0025FC48 File Offset: 0x0025E048
		// (remove) Token: 0x0600AE4B RID: 44619 RVA: 0x0025FC80 File Offset: 0x0025E080
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action ServerSyncTaskDataListener;

		// Token: 0x14000005 RID: 5
		// (add) Token: 0x0600AE4C RID: 44620 RVA: 0x0025FCB8 File Offset: 0x0025E0B8
		// (remove) Token: 0x0600AE4D RID: 44621 RVA: 0x0025FCF0 File Offset: 0x0025E0F0
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action ServerSyncTaskDataChangeListener;

		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600AE4E RID: 44622 RVA: 0x0025FD28 File Offset: 0x0025E128
		// (remove) Token: 0x0600AE4F RID: 44623 RVA: 0x0025FD60 File Offset: 0x0025E160
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event Action<ActivityLimitTimeData> ServerSyncActivityStateChangeListener;

		// Token: 0x0600AE50 RID: 44624 RVA: 0x0025FD98 File Offset: 0x0025E198
		public void Initialize()
		{
			this.Clear();
			this.activityLimitTimeDataList = new List<ActivityLimitTimeData>();
			this.activityLimitTimeTasksDic = new Dictionary<uint, List<ActivityLimitTimeDetailData>>();
			this.activitiesTasksDic = new Dictionary<uint, ActivityLimitTimeDetailData>();
			NetProcess.AddMsgHandler(501145U, new Action<MsgDATA>(this.OnSyncLimitTimeActivity));
			NetProcess.AddMsgHandler(501146U, new Action<MsgDATA>(this.OnSyncActivityTasks));
			NetProcess.AddMsgHandler(501147U, new Action<MsgDATA>(this.OnSyncActivityTaskChange));
			NetProcess.AddMsgHandler(501149U, new Action<MsgDATA>(this.OnSyncActivityStateChange));
		}

		// Token: 0x0600AE51 RID: 44625 RVA: 0x0025FE24 File Offset: 0x0025E224
		public void Clear()
		{
			this.activityLimitTimeDataList = null;
			this.activityLimitTimeTasksDic = null;
			this.activitiesTasksDic = null;
			this.bindPhoneOtherData = null;
			NetProcess.RemoveMsgHandler(501145U, new Action<MsgDATA>(this.OnSyncLimitTimeActivity));
			NetProcess.RemoveMsgHandler(501146U, new Action<MsgDATA>(this.OnSyncActivityTasks));
			NetProcess.RemoveMsgHandler(501147U, new Action<MsgDATA>(this.OnSyncActivityTaskChange));
			NetProcess.RemoveMsgHandler(501149U, new Action<MsgDATA>(this.OnSyncActivityStateChange));
			this.fatigueBurnType = 0;
		}

		// Token: 0x17001A93 RID: 6803
		// (get) Token: 0x0600AE52 RID: 44626 RVA: 0x0025FEAC File Offset: 0x0025E2AC
		private int fatigueValue
		{
			get
			{
				int result = 0;
				if (int.TryParse(TR.Value("fatigue_combustion_value"), out result))
				{
					return result;
				}
				return 0;
			}
		}

		// Token: 0x0600AE53 RID: 44627 RVA: 0x0025FED4 File Offset: 0x0025E2D4
		public void FindFatigueCombustionActivityIsOpen(ref bool isFlag, ref ActivityLimitTimeData data)
		{
			for (int i = 0; i < this.activityLimitTimeDataList.Count; i++)
			{
				ActivityLimitTimeData activityLimitTimeData = this.activityLimitTimeDataList[i];
				if (activityLimitTimeData.ActivityType == OpActivityTmpType.OAT_FATIGUE_BURNING)
				{
					if (activityLimitTimeData.ActivityState == ActivityState.Start)
					{
						if ((int)DataManager<PlayerBaseData>.GetInstance().fatigue > this.fatigueValue)
						{
							for (int j = 0; j < activityLimitTimeData.activityDetailDataList.Count; j++)
							{
								ActivityLimitTimeDetailData activityLimitTimeDetailData = activityLimitTimeData.activityDetailDataList[j];
								if (activityLimitTimeDetailData.ActivityDetailState != ActivityTaskState.Init && activityLimitTimeDetailData.ActivityDetailState != ActivityTaskState.UnFinish)
								{
									isFlag = true;
									data = this.activityLimitTimeDataList[i];
									return;
								}
							}
						}
					}
				}
			}
			isFlag = false;
			data = null;
		}

		// Token: 0x0600AE54 RID: 44628 RVA: 0x0025FFA8 File Offset: 0x0025E3A8
		public bool CheckHasTaskWaitToReceive()
		{
			for (int i = 0; i < this.activityLimitTimeDataList.Count; i++)
			{
				ActivityLimitTimeData activityLimitTimeData = this.activityLimitTimeDataList[i];
				if (activityLimitTimeData.ActivityState == ActivityState.Start)
				{
					if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_BIND_PHONE)
					{
						if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_GAMBING)
						{
							if (activityLimitTimeData.DataId != 1090U)
							{
								if (activityLimitTimeData.activityDetailDataList != null && activityLimitTimeData.activityDetailDataList.Count > 0)
								{
									for (int j = 0; j < activityLimitTimeData.activityDetailDataList.Count; j++)
									{
										if (activityLimitTimeData.activityDetailDataList[j].ActivityDetailState == ActivityTaskState.Finished || (activityLimitTimeData.ActivityType == OpActivityTmpType.OAT_HELL_TICKET_FOR_DRAW_PRIZE && DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME) > 0))
										{
											return true;
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600AE55 RID: 44629 RVA: 0x002600A4 File Offset: 0x0025E4A4
		private void OnSyncLimitTimeActivity(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityDatas syncOpActivityDatas = new SyncOpActivityDatas();
			syncOpActivityDatas.decode(msg.bytes, ref num);
			this.ActivityNetData2LocalData(syncOpActivityDatas);
			if (this.ServerSyncActivityDataListener != null)
			{
				this.ServerSyncActivityDataListener();
			}
			this.HaveActivity = false;
			if (syncOpActivityDatas.datas == null)
			{
				return;
			}
			for (int i = 0; i < syncOpActivityDatas.datas.Length; i++)
			{
				OpActivityData opActivityData = syncOpActivityDatas.datas[i];
				if (opActivityData == null)
				{
					return;
				}
				if (opActivityData.tmpType != 16U)
				{
					if (opActivityData.tmpType != 1900U)
					{
						if (opActivityData.state == 1)
						{
							this.HaveActivity = true;
							break;
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshActivityLimitTimeBtn, null, null, null, null);
		}

		// Token: 0x0600AE56 RID: 44630 RVA: 0x00260174 File Offset: 0x0025E574
		private void ActivityNetData2LocalData(SyncOpActivityDatas netDatas)
		{
			if (netDatas != null)
			{
				bool flag = false;
				bool flag2 = false;
				this.HaveFashionDiscountActivity = false;
				for (int i = 0; i < netDatas.datas.Length; i++)
				{
					if (netDatas.datas[i].tmpType == 17U && netDatas.datas[i].state == 1)
					{
						flag = true;
					}
					if (netDatas.datas[i].tmpType == 1000U && netDatas.datas[i].state == 1)
					{
						flag2 = true;
						this.HaveFashionDiscountActivity = true;
					}
				}
				for (int j = 0; j < netDatas.datas.Length; j++)
				{
					if (!flag || !flag2 || netDatas.datas[j].tmpType != 1000U)
					{
						OpActivityData opActivityData = netDatas.datas[j];
						ActivityLimitTimeData activityLimitTimeData = new ActivityLimitTimeData();
						activityLimitTimeData.DataId = opActivityData.dataId;
						activityLimitTimeData.ActivityState = (ActivityState)opActivityData.state;
						activityLimitTimeData.ActivityType = (OpActivityTmpType)opActivityData.tmpType;
						activityLimitTimeData.ActivityTabName = opActivityData.name;
						activityLimitTimeData.LogoDesc = opActivityData.logoDesc;
						activityLimitTimeData.ActivityTabTag = (ActivityTabTag)opActivityData.tag;
						activityLimitTimeData.ActivityStartTime = opActivityData.startTime;
						activityLimitTimeData.ActivityEndTime = opActivityData.endTime;
						activityLimitTimeData.ActivityTimePre = opActivityData.desc;
						activityLimitTimeData.ActivityRole = opActivityData.ruleDesc;
						activityLimitTimeData.ActivityTaskDesc = opActivityData.taskDesc;
						activityLimitTimeData.Description = opActivityData.desc;
						if (opActivityData.tasks != null && opActivityData.tasks.Length > 0)
						{
							if (opActivityData.tmpType == 1002U)
							{
								for (int k = 0; k < opActivityData.tasks.Length; k++)
								{
									for (int l = 0; l < opActivityData.tasks.Length - 1; l++)
									{
										if (opActivityData.tasks[l].completeNum > opActivityData.tasks[l + 1].completeNum)
										{
											OpActTaskData opActTaskData = opActivityData.tasks[l];
											opActivityData.tasks[l] = opActivityData.tasks[l + 1];
											opActivityData.tasks[l + 1] = opActTaskData;
										}
									}
								}
							}
							for (int m = 0; m < opActivityData.tasks.Length; m++)
							{
								ActivityLimitTimeDetailData activityLimitTimeDetailData = this.ActivityTaskNetData2LocalData(activityLimitTimeData.ActivityTaskDesc, opActivityData.tasks[m]);
								if (activityLimitTimeDetailData != null)
								{
									activityLimitTimeData.activityDetailDataList.Add(activityLimitTimeDetailData);
								}
							}
						}
						if (activityLimitTimeData.ActivityType == OpActivityTmpType.OAT_BIND_PHONE)
						{
							this.bindPhoneOtherData = activityLimitTimeData;
						}
						this.activityLimitTimeDataList.Add(activityLimitTimeData);
					}
				}
				this.AllTasksDataDicToActivityDataList();
				this.AllActivitiesDataToDicByActId();
			}
		}

		// Token: 0x0600AE57 RID: 44631 RVA: 0x0026043B File Offset: 0x0025E83B
		public void ReOpenActivityLimittimeFrame()
		{
			this.needOpen = true;
		}

		// Token: 0x0600AE58 RID: 44632 RVA: 0x00260444 File Offset: 0x0025E844
		public void OnUpdate(float timeElapsed)
		{
			if (this.needOpen)
			{
				this.TimeIntrval += timeElapsed;
				if (this.TimeIntrval > 0.5f)
				{
					this.needOpen = false;
					this.TimeIntrval = 0f;
				}
			}
		}

		// Token: 0x0600AE59 RID: 44633 RVA: 0x00260484 File Offset: 0x0025E884
		private void ActivityTaskNetDataToLocal(ref ActivityLimitTimeDetailData localTaskData, string taskDesc, OpActTaskData data)
		{
			if (localTaskData != null && data != null)
			{
				localTaskData.DataId = data.dataid;
				localTaskData.ActivityTaskDesc = taskDesc;
				localTaskData.DoneNum = 0;
				localTaskData.TotalNum = (int)data.completeNum;
				if (data.variables != null)
				{
					localTaskData.ParamNums = new List<int>();
					for (int i = 0; i < data.variables.Length; i++)
					{
						localTaskData.ParamNums.Add((int)data.variables[i]);
					}
				}
				localTaskData.ActivityDetailState = ActivityTaskState.Init;
				if (data.rewards != null && data.rewards.Length > 0)
				{
					localTaskData.awardDataList = new List<ActivityLimitTimeAward>();
					for (int j = 0; j < data.rewards.Length; j++)
					{
						ActivityLimitTimeAward item = new ActivityLimitTimeAward();
						this.ActTaskAwardNetDataToLocal(ref item, data.rewards[j]);
						localTaskData.awardDataList.Add(item);
					}
				}
			}
		}

		// Token: 0x0600AE5A RID: 44634 RVA: 0x00260575 File Offset: 0x0025E975
		private void ActTaskAwardNetDataToLocal(ref ActivityLimitTimeAward localAward, OpTaskReward netData)
		{
			if (localAward != null && netData != null)
			{
				localAward.Id = netData.id;
				localAward.Num = (int)netData.num;
				localAward.Strenth = netData.strenth;
			}
		}

		// Token: 0x0600AE5B RID: 44635 RVA: 0x002605AC File Offset: 0x0025E9AC
		private ActivityLimitTimeDetailData ActivityTaskNetData2LocalData(string taskDesc, OpActTaskData data)
		{
			ActivityLimitTimeDetailData activityLimitTimeDetailData = new ActivityLimitTimeDetailData();
			if (activityLimitTimeDetailData != null && data != null)
			{
				activityLimitTimeDetailData.DataId = data.dataid;
				activityLimitTimeDetailData.ActivityTaskDesc = taskDesc;
				activityLimitTimeDetailData.DoneNum = 0;
				activityLimitTimeDetailData.TotalNum = (int)data.completeNum;
				if (data.variables != null)
				{
					activityLimitTimeDetailData.ParamNums = new List<int>();
					for (int i = 0; i < data.variables.Length; i++)
					{
						activityLimitTimeDetailData.ParamNums.Add((int)data.variables[i]);
					}
				}
				activityLimitTimeDetailData.ActivityDetailState = ActivityTaskState.Init;
				if (data.rewards != null && data.rewards.Length > 0)
				{
					activityLimitTimeDetailData.awardDataList = new List<ActivityLimitTimeAward>();
					for (int j = 0; j < data.rewards.Length; j++)
					{
						ActivityLimitTimeAward activityLimitTimeAward = this.ActivityTaskAwardNet2Local(data.rewards[j]);
						if (activityLimitTimeAward != null)
						{
							activityLimitTimeDetailData.awardDataList.Add(activityLimitTimeAward);
						}
					}
				}
				return activityLimitTimeDetailData;
			}
			return null;
		}

		// Token: 0x0600AE5C RID: 44636 RVA: 0x0026069C File Offset: 0x0025EA9C
		private ActivityLimitTimeAward ActivityTaskAwardNet2Local(OpTaskReward netData)
		{
			ActivityLimitTimeAward activityLimitTimeAward = new ActivityLimitTimeAward();
			if (activityLimitTimeAward != null && netData != null)
			{
				activityLimitTimeAward.Id = netData.id;
				activityLimitTimeAward.Num = (int)netData.num;
				return activityLimitTimeAward;
			}
			return null;
		}

		// Token: 0x0600AE5D RID: 44637 RVA: 0x002606D8 File Offset: 0x0025EAD8
		private void OnSyncActivityTasks(MsgDATA data)
		{
			int num = 0;
			SyncOpActivityTasks syncOpActivityTasks = new SyncOpActivityTasks();
			syncOpActivityTasks.decode(data.bytes, ref num);
			this.ActivityTasksNet2Local(syncOpActivityTasks);
			if (this.ServerSyncTaskDataListener != null)
			{
				this.ServerSyncTaskDataListener();
			}
		}

		// Token: 0x0600AE5E RID: 44638 RVA: 0x00260718 File Offset: 0x0025EB18
		private void ActivityTasksNet2Local(SyncOpActivityTasks taskDatas)
		{
			if (taskDatas != null)
			{
				OpActTask[] tasks = taskDatas.tasks;
				if (tasks == null)
				{
					return;
				}
				if (tasks.Length > 0)
				{
					this.activityLTDetailList = new List<ActivityLimitTimeDetailData>();
					for (int i = 0; i < tasks.Length; i++)
					{
						ActivityLimitTimeDetailData activityLimitTimeDetailData = new ActivityLimitTimeDetailData();
						activityLimitTimeDetailData.DataId = tasks[i].dataId;
						activityLimitTimeDetailData.DoneNum = (int)tasks[i].curNum;
						activityLimitTimeDetailData.ActivityDetailState = (ActivityTaskState)tasks[i].state;
						this.activityLTDetailList.Add(activityLimitTimeDetailData);
						if (this.activitiesTasksDic != null)
						{
							uint dataId = activityLimitTimeDetailData.DataId;
							if (this.activitiesTasksDic.ContainsKey(dataId))
							{
								this.activitiesTasksDic.Remove(dataId);
							}
							this.activitiesTasksDic.Add(dataId, activityLimitTimeDetailData);
						}
					}
					this.AllTasksDataDicToActivityDataList();
					this.AllActivitiesDataToDicByActId();
				}
			}
		}

		// Token: 0x0600AE5F RID: 44639 RVA: 0x002607E8 File Offset: 0x0025EBE8
		private void OnSyncActivityTaskChange(MsgDATA data)
		{
			int num = 0;
			SyncOpActivityTaskChange syncOpActivityTaskChange = new SyncOpActivityTaskChange();
			syncOpActivityTaskChange.decode(data.bytes, ref num);
			this.ActivityTasksNet2Local(syncOpActivityTaskChange);
			if (this.ServerSyncTaskDataChangeListener != null)
			{
				this.ServerSyncTaskDataChangeListener();
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskUpdate, null, null, null, null);
		}

		// Token: 0x0600AE60 RID: 44640 RVA: 0x0026083C File Offset: 0x0025EC3C
		private void ActivityTasksNet2Local(SyncOpActivityTaskChange taskDatas)
		{
			if (taskDatas != null)
			{
				OpActTask[] tasks = taskDatas.tasks;
				if (tasks == null)
				{
					return;
				}
				if (tasks.Length > 0)
				{
					this.activityLTDetailList = new List<ActivityLimitTimeDetailData>();
					for (int i = 0; i < tasks.Length; i++)
					{
						ActivityLimitTimeDetailData activityLimitTimeDetailData = new ActivityLimitTimeDetailData();
						activityLimitTimeDetailData.DataId = tasks[i].dataId;
						activityLimitTimeDetailData.DoneNum = (int)tasks[i].curNum;
						activityLimitTimeDetailData.ActivityDetailState = (ActivityTaskState)tasks[i].state;
						this.activityLTDetailList.Add(activityLimitTimeDetailData);
						if (this.activitiesTasksDic != null)
						{
							uint dataId = activityLimitTimeDetailData.DataId;
							if (this.activitiesTasksDic.ContainsKey(dataId))
							{
								this.activitiesTasksDic.Remove(dataId);
							}
							this.activitiesTasksDic.Add(dataId, activityLimitTimeDetailData);
						}
					}
					this.AllTasksDataDicToActivityDataList();
					this.AllActivitiesDataToDicByActId();
				}
			}
		}

		// Token: 0x0600AE61 RID: 44641 RVA: 0x0026090C File Offset: 0x0025ED0C
		private void AllTasksDataDicToActivityDataList()
		{
			if (this.activityLimitTimeDataList == null)
			{
				return;
			}
			if (this.activitiesTasksDic == null)
			{
				return;
			}
			for (int i = 0; i < this.activityLimitTimeDataList.Count; i++)
			{
				List<ActivityLimitTimeDetailData> activityDetailDataList = this.activityLimitTimeDataList[i].activityDetailDataList;
				if (activityDetailDataList != null)
				{
					for (int j = 0; j < activityDetailDataList.Count; j++)
					{
						uint dataId = activityDetailDataList[j].DataId;
						if (this.activitiesTasksDic.ContainsKey(dataId))
						{
							this.activityLimitTimeDataList[i].activityDetailDataList[j].DoneNum = this.activitiesTasksDic[dataId].DoneNum;
							this.activityLimitTimeDataList[i].activityDetailDataList[j].ActivityDetailState = this.activitiesTasksDic[dataId].ActivityDetailState;
						}
					}
					if (this.activityLimitTimeDataList[i].ActivityType == OpActivityTmpType.OAT_BIND_PHONE)
					{
						this.bindPhoneOtherData = this.activityLimitTimeDataList[i];
					}
				}
			}
		}

		// Token: 0x0600AE62 RID: 44642 RVA: 0x00260A20 File Offset: 0x0025EE20
		private void AllActivitiesDataToDicByActId()
		{
			if (this.activityLimitTimeTasksDic == null)
			{
				return;
			}
			if (this.activityLimitTimeDataList != null)
			{
				for (int i = 0; i < this.activityLimitTimeDataList.Count; i++)
				{
					if (this.activityLimitTimeDataList[i].activityDetailDataList != null)
					{
						uint dataId = this.activityLimitTimeDataList[i].DataId;
						List<ActivityLimitTimeDetailData> activityDetailDataList = this.activityLimitTimeDataList[i].activityDetailDataList;
						if (this.activityLimitTimeTasksDic.ContainsKey(dataId))
						{
							this.activityLimitTimeTasksDic.Remove(dataId);
						}
						this.activityLimitTimeTasksDic.Add(dataId, activityDetailDataList);
					}
				}
			}
		}

		// Token: 0x0600AE63 RID: 44643 RVA: 0x00260AC8 File Offset: 0x0025EEC8
		private void OnSyncActivityStateChange(MsgDATA data)
		{
			int num = 0;
			SyncOpActivityStateChange syncOpActivityStateChange = new SyncOpActivityStateChange();
			syncOpActivityStateChange.decode(data.bytes, ref num);
			if (syncOpActivityStateChange.data.dataId == 1000U && syncOpActivityStateChange.data.state == 0 && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<FashionLimitTimeBuyFrame>(null) && DataManager<FashionLimitTimeBuyManager>.GetInstance().haveFashionDiscount)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("时装打折活动已结束", delegate
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<FashionLimitTimeBuyFrame>(null, false);
				}, string.Empty, false);
			}
			this.ActivityStateNet2Local(syncOpActivityStateChange);
			this.HaveActivity = false;
			if (this.activityLimitTimeDataList == null)
			{
				return;
			}
			for (int i = 0; i < this.activityLimitTimeDataList.Count; i++)
			{
				ActivityLimitTimeData activityLimitTimeData = this.activityLimitTimeDataList[i];
				if (activityLimitTimeData == null)
				{
					return;
				}
				if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_BIND_PHONE)
				{
					if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_GAMBING)
					{
						if (this.activityLimitTimeDataList[i].ActivityState == ActivityState.Start)
						{
							this.HaveActivity = true;
							break;
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshActivityLimitTimeBtn, null, null, null, null);
		}

		// Token: 0x0600AE64 RID: 44644 RVA: 0x00260C04 File Offset: 0x0025F004
		private void ActivityStateNet2Local(SyncOpActivityStateChange actStateChange)
		{
			if (actStateChange == null)
			{
				return;
			}
			if (actStateChange.data == null)
			{
				return;
			}
			if (this.activityLimitTimeDataList != null)
			{
				int count = this.activityLimitTimeDataList.Count;
				if (count > 0)
				{
					int i = 0;
					while (i < this.activityLimitTimeDataList.Count)
					{
						ActivityLimitTimeData activityLimitTimeData = this.activityLimitTimeDataList[i];
						if (activityLimitTimeData.DataId == actStateChange.data.dataId)
						{
							this.activityLimitTimeDataList[i] = this.SyncNetActDataToLocalActData(actStateChange.data);
							ActivityLimitTimeData activityLimitTimeData2 = this.activityLimitTimeDataList[i];
							if (activityLimitTimeData2 == null)
							{
								return;
							}
							if (this.ServerSyncActivityStateChangeListener != null)
							{
								this.ServerSyncActivityStateChangeListener(activityLimitTimeData2);
							}
							if (activityLimitTimeData2.ActivityType == OpActivityTmpType.OAT_BIND_PHONE)
							{
								if (activityLimitTimeData2.ActivityState == ActivityState.End)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SDKBindPhoneFinished, false, null, null, null);
								}
								else if (activityLimitTimeData2.ActivityState == ActivityState.Start)
								{
									UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SDKBindPhoneFinished, true, null, null, null);
								}
							}
							break;
						}
						else
						{
							i++;
						}
					}
				}
				this.AllTasksDataDicToActivityDataList();
				this.AllActivitiesDataToDicByActId();
			}
		}

		// Token: 0x0600AE65 RID: 44645 RVA: 0x00260D34 File Offset: 0x0025F134
		private ActivityLimitTimeData SyncNetActDataToLocalActData(OpActivityData opData)
		{
			if (opData == null)
			{
				return null;
			}
			ActivityLimitTimeData activityLimitTimeData = new ActivityLimitTimeData
			{
				DataId = opData.dataId,
				ActivityState = (ActivityState)opData.state,
				ActivityType = (OpActivityTmpType)opData.tmpType,
				ActivityTabName = opData.name,
				ActivityTabTag = (ActivityTabTag)opData.tag,
				ActivityStartTime = opData.startTime,
				ActivityEndTime = opData.endTime,
				ActivityTimePre = opData.desc,
				LogoDesc = opData.logoDesc,
				ActivityRole = opData.ruleDesc,
				ActivityTaskDesc = opData.taskDesc,
				Description = opData.desc
			};
			string[] array = activityLimitTimeData.ActivityTaskDesc.Split(new char[]
			{
				'|'
			});
			if (opData.tasks != null && opData.tasks.Length > 0)
			{
				activityLimitTimeData.activityDetailDataList = new List<ActivityLimitTimeDetailData>();
				for (int i = 0; i < opData.tasks.Length; i++)
				{
					if (array.Length == opData.tasks.Length)
					{
						ActivityLimitTimeDetailData activityLimitTimeDetailData = this.ActivityTaskNetData2LocalData(array[i], opData.tasks[i]);
						if (activityLimitTimeDetailData != null)
						{
							activityLimitTimeData.activityDetailDataList.Add(activityLimitTimeDetailData);
						}
					}
					else
					{
						ActivityLimitTimeDetailData activityLimitTimeDetailData2 = this.ActivityTaskNetData2LocalData(activityLimitTimeData.ActivityTaskDesc, opData.tasks[i]);
						if (activityLimitTimeDetailData2 != null)
						{
							activityLimitTimeData.activityDetailDataList.Add(activityLimitTimeDetailData2);
						}
					}
				}
			}
			if (activityLimitTimeData.ActivityType == OpActivityTmpType.OAT_BIND_PHONE)
			{
				this.bindPhoneOtherData = activityLimitTimeData;
			}
			return activityLimitTimeData;
		}

		// Token: 0x0600AE66 RID: 44646 RVA: 0x00260EB0 File Offset: 0x0025F2B0
		public void RequestOnTakeActTask(uint activityDataId, uint taskDataId)
		{
			TakeOpActTaskReq takeOpActTaskReq = new TakeOpActTaskReq();
			takeOpActTaskReq.activityDataId = activityDataId;
			takeOpActTaskReq.taskDataId = taskDataId;
			NetManager.Instance().SendCommand<TakeOpActTaskReq>(ServerType.GATE_SERVER, takeOpActTaskReq);
		}

		// Token: 0x0600AE67 RID: 44647 RVA: 0x00260EE0 File Offset: 0x0025F2E0
		public void OnSceneOpActivityTaskInfoReq(uint activityDataId)
		{
			SceneOpActivityTaskInfoReq sceneOpActivityTaskInfoReq = new SceneOpActivityTaskInfoReq();
			sceneOpActivityTaskInfoReq.opActId = activityDataId;
			NetManager.Instance().SendCommand<SceneOpActivityTaskInfoReq>(ServerType.GATE_SERVER, sceneOpActivityTaskInfoReq);
		}

		// Token: 0x0600AE68 RID: 44648 RVA: 0x00260F07 File Offset: 0x0025F307
		public void AddSyncActivityDataListener(Action handler)
		{
			this.RemoveAllSyncActivityDataListener();
			if (this.ServerSyncActivityDataListener == null)
			{
				this.ServerSyncActivityDataListener += handler;
			}
		}

		// Token: 0x0600AE69 RID: 44649 RVA: 0x00260F24 File Offset: 0x0025F324
		public void RemoveAllSyncActivityDataListener()
		{
			if (this.ServerSyncActivityDataListener != null)
			{
				Delegate[] invocationList = this.ServerSyncActivityDataListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.ServerSyncActivityDataListener -= (invocationList[i] as Action);
					}
				}
			}
		}

		// Token: 0x0600AE6A RID: 44650 RVA: 0x00260F72 File Offset: 0x0025F372
		public void AddSyncTaskDataListener(Action handler)
		{
			this.RemoveAllSyncTaskDataListener();
			if (this.ServerSyncTaskDataListener == null)
			{
				this.ServerSyncTaskDataListener += handler;
			}
		}

		// Token: 0x0600AE6B RID: 44651 RVA: 0x00260F8C File Offset: 0x0025F38C
		public void RemoveAllSyncTaskDataListener()
		{
			if (this.ServerSyncTaskDataListener != null)
			{
				Delegate[] invocationList = this.ServerSyncTaskDataListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.ServerSyncTaskDataListener -= (invocationList[i] as Action);
					}
				}
			}
		}

		// Token: 0x0600AE6C RID: 44652 RVA: 0x00260FDA File Offset: 0x0025F3DA
		public void AddSyncTaskDataChangeListener(Action handler)
		{
			this.ServerSyncTaskDataChangeListener += handler;
		}

		// Token: 0x0600AE6D RID: 44653 RVA: 0x00260FE3 File Offset: 0x0025F3E3
		public void RemoveSyncTaskDataChangeListener(Action handler)
		{
			if (this.ServerSyncTaskDataChangeListener != null && handler != null)
			{
				this.ServerSyncTaskDataChangeListener -= handler;
			}
		}

		// Token: 0x0600AE6E RID: 44654 RVA: 0x00261000 File Offset: 0x0025F400
		public void RemoveAllSyncTaskDataChangeListener()
		{
			if (this.ServerSyncTaskDataChangeListener != null)
			{
				Delegate[] invocationList = this.ServerSyncTaskDataChangeListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.ServerSyncTaskDataChangeListener -= (invocationList[i] as Action);
					}
				}
			}
		}

		// Token: 0x0600AE6F RID: 44655 RVA: 0x0026104E File Offset: 0x0025F44E
		public void AddSyncActStateChangeListener(Action<ActivityLimitTimeData> handler)
		{
			this.RemoveAllSyncActStateChangeListener();
			if (this.ServerSyncActivityStateChangeListener == null)
			{
				this.ServerSyncActivityStateChangeListener += handler;
			}
		}

		// Token: 0x0600AE70 RID: 44656 RVA: 0x00261068 File Offset: 0x0025F468
		public void RemoveAllSyncActStateChangeListener()
		{
			if (this.ServerSyncActivityStateChangeListener != null)
			{
				Delegate[] invocationList = this.ServerSyncActivityStateChangeListener.GetInvocationList();
				if (invocationList != null)
				{
					int num = invocationList.Length;
					for (int i = 0; i < num; i++)
					{
						this.ServerSyncActivityStateChangeListener -= (invocationList[i] as Action<ActivityLimitTimeData>);
					}
				}
			}
		}

		// Token: 0x0600AE71 RID: 44657 RVA: 0x002610B6 File Offset: 0x0025F4B6
		public void ViewAwards(int id)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<RewardShow>(FrameLayer.Middle, id, string.Empty);
		}

		// Token: 0x0600AE72 RID: 44658 RVA: 0x002610CF File Offset: 0x0025F4CF
		public void lottery(int id)
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TurnTable>(FrameLayer.Middle, id, string.Empty);
		}

		// Token: 0x0600AE73 RID: 44659 RVA: 0x002610E8 File Offset: 0x0025F4E8
		public ActivityTaskState getTaskState(int taskID)
		{
			ActivityLimitTimeDetailData activityLimitTimeDetailData = new ActivityLimitTimeDetailData();
			this.activitiesTasksDic.TryGetValue((uint)taskID, out activityLimitTimeDetailData);
			return activityLimitTimeDetailData.ActivityDetailState;
		}

		// Token: 0x0600AE74 RID: 44660 RVA: 0x00261110 File Offset: 0x0025F510
		public uint DateTimeToUnix()
		{
			DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			return (uint)(DateTime.Now - d).TotalSeconds;
		}

		// Token: 0x04006187 RID: 24967
		public List<ActivityLimitTimeData> activityLimitTimeDataList;

		// Token: 0x04006188 RID: 24968
		public Dictionary<uint, List<ActivityLimitTimeDetailData>> activityLimitTimeTasksDic;

		// Token: 0x04006189 RID: 24969
		public bool HaveActivity;

		// Token: 0x0400618A RID: 24970
		private ActivityLimitTimeData bindPhoneOtherData;

		// Token: 0x0400618B RID: 24971
		public int fatigueBurnType;

		// Token: 0x0400618C RID: 24972
		private Dictionary<uint, ActivityLimitTimeDetailData> activitiesTasksDic;

		// Token: 0x0400618D RID: 24973
		private List<ActivityLimitTimeDetailData> activityLTDetailList;

		// Token: 0x04006192 RID: 24978
		public bool HaveFashionDiscountActivity;

		// Token: 0x04006193 RID: 24979
		private bool needOpen;

		// Token: 0x04006194 RID: 24980
		private float TimeIntrval;
	}
}
