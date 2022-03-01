using System;
using System.Collections.Generic;
using GamePool;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001233 RID: 4659
	public class DailyTodoDataManager : DataManager<DailyTodoDataManager>
	{
		// Token: 0x17001AC6 RID: 6854
		// (get) Token: 0x0600B309 RID: 45833 RVA: 0x0027C84B File Offset: 0x0027AC4B
		public bool BFuncOpen
		{
			get
			{
				return DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_DAILY_TODO) && Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.DailyTodo);
			}
		}

		// Token: 0x0600B30A RID: 45834 RVA: 0x0027C86B File Offset: 0x0027AC6B
		public sealed override void Initialize()
		{
			if (this.m_IsInited)
			{
				return;
			}
			this._BindNetEvent();
			this._InitLocalData();
			this.m_IsInited = true;
		}

		// Token: 0x0600B30B RID: 45835 RVA: 0x0027C88C File Offset: 0x0027AC8C
		public sealed override void Clear()
		{
			this._ClearData();
			this._UnBindNetEvent();
		}

		// Token: 0x0600B30C RID: 45836 RVA: 0x0027C89C File Offset: 0x0027AC9C
		private void _InitLocalData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<DailyTodoTable>();
			DailyTodoModel dailyTodoModel = null;
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					DailyTodoTable dailyTodoTable = keyValuePair.Value as DailyTodoTable;
					if (dailyTodoTable != null)
					{
						if (dailyTodoTable.Type == DailyTodoTable.eType.TP_ACTIVITY)
						{
							dailyTodoModel = new DailyTodoActivity();
							this._InitBaseDailyTodo(dailyTodoModel, dailyTodoTable);
							DailyTodoActivity dailyTodoActivity = dailyTodoModel as DailyTodoActivity;
							if (dailyTodoActivity != null)
							{
								this._InitDailyTodoActivity(dailyTodoActivity, dailyTodoTable);
								if (this.m_ActivityDailyTodoList != null)
								{
									this.m_ActivityDailyTodoList.Add(dailyTodoActivity);
								}
							}
						}
						else if (dailyTodoTable.Type == DailyTodoTable.eType.TP_FUNCTION)
						{
							dailyTodoModel = new DailyTodoFunction();
							this._InitBaseDailyTodo(dailyTodoModel, dailyTodoTable);
							DailyTodoFunction dailyTodoFunction = dailyTodoModel as DailyTodoFunction;
							if (dailyTodoFunction != null)
							{
								this._InitDailyTodoFunction(dailyTodoFunction, dailyTodoTable);
								if (this.m_FunctionDailyTodoList != null)
								{
									this.m_FunctionDailyTodoList.Add(dailyTodoFunction);
								}
							}
						}
						if (this.m_DailyTodoTotalDic != null)
						{
							this.m_DailyTodoTotalDic[(int)dailyTodoModel.subType] = dailyTodoModel;
						}
					}
				}
				this.m_ActivityDailyTodoList.Sort((DailyTodoActivity x, DailyTodoActivity y) => x.CompareTo(y));
				this.m_FunctionDailyTodoList.Sort((DailyTodoFunction x, DailyTodoFunction y) => x.CompareTo(y));
			}
		}

		// Token: 0x0600B30D RID: 45837 RVA: 0x0027C9FC File Offset: 0x0027ADFC
		private void _ClearData()
		{
			if (this.m_ActivityDailyTodoList != null)
			{
				for (int i = 0; i < this.m_ActivityDailyTodoList.Count; i++)
				{
					DailyTodoActivity dailyTodoActivity = this.m_ActivityDailyTodoList[i];
					if (dailyTodoActivity != null)
					{
						dailyTodoActivity.Clear();
					}
				}
				this.m_ActivityDailyTodoList.Clear();
			}
			if (this.m_FunctionDailyTodoList != null)
			{
				for (int j = 0; j < this.m_FunctionDailyTodoList.Count; j++)
				{
					DailyTodoFunction dailyTodoFunction = this.m_FunctionDailyTodoList[j];
					if (dailyTodoFunction != null)
					{
						dailyTodoFunction.Clear();
					}
				}
				this.m_FunctionDailyTodoList.Clear();
			}
			if (this.m_DailyTodoTotalDic != null)
			{
				this.m_DailyTodoTotalDic.Clear();
			}
			if (this.m_TempShowActivityDailyTodoList != null)
			{
				this.m_TempShowActivityDailyTodoList.Clear();
			}
			if (this.m_TempShowFunctionDailyTodoList != null)
			{
				this.m_TempShowFunctionDailyTodoList.Clear();
			}
			this.m_IsInited = false;
		}

		// Token: 0x0600B30E RID: 45838 RVA: 0x0027CAF4 File Offset: 0x0027AEF4
		private void _InitBaseDailyTodo(DailyTodoModel model, DailyTodoTable table)
		{
			if (model == null || table == null)
			{
				return;
			}
			model.tableId = table.ID;
			model.name = table.Name;
			model.backgroundImgPath = table.BackgroundPath;
			model.linkinfo = table.LinkInfo;
			model.subType = table.SubType;
			model.isTodayOpenedHandler = new Func<DailyTodoTable.eSubType, bool>(this._IsTodayOpened);
			string openWeekDay = table.OpenWeekDay;
			if (!string.IsNullOrEmpty(openWeekDay) && model.openWeeks != null)
			{
				string[] array = openWeekDay.Split(new char[]
				{
					'|'
				});
				if (array != null)
				{
					for (int i = 0; i < array.Length; i++)
					{
						int num = 0;
						if (int.TryParse(array[i], out num))
						{
							if (num != 0)
							{
								model.openWeeks.Add(num);
							}
						}
					}
				}
			}
			string openDayTime = table.OpenDayTime;
			if (!string.IsNullOrEmpty(openDayTime))
			{
				string[] array2 = openDayTime.Split(new char[]
				{
					'-'
				});
				if (array2 != null && array2.Length == 2)
				{
					string text = array2[0];
					string text2 = array2[1];
					if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
					{
						int[] array3 = Function.TransferTimeSplitByColon(text);
						if (array3 != null && array3.Length >= 2)
						{
							model.openTimes.startTimeHour = array3[0];
							model.openTimes.startTimeMinute = array3[1];
						}
						int[] array4 = Function.TransferTimeSplitByColon(text2);
						if (array4 != null && array4.Length >= 2)
						{
							model.openTimes.endTimeHour = array4[0];
							model.openTimes.endTimeMinute = array4[1];
						}
					}
				}
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(596, string.Empty, string.Empty);
			if (tableItem != null)
			{
				model.refreshHour = tableItem.Value;
			}
		}

		// Token: 0x0600B30F RID: 45839 RVA: 0x0027CCCC File Offset: 0x0027B0CC
		private void _InitDailyTodoActivity(DailyTodoActivity model, DailyTodoTable table)
		{
			if (model == null || table == null)
			{
				return;
			}
			model.activityDungeonId = table.ActivityDungeonID;
			model.gotoHandler = new Action<DailyTodoActivity>(this._OnGoActivityDailyTodo);
			model.timeDesc = TR.Value(this.tr_daily_todo_activity_time_Key, table.OpenDayTime);
			this._UpdateDailyTodoActivity(model);
		}

		// Token: 0x0600B310 RID: 45840 RVA: 0x0027CD24 File Offset: 0x0027B124
		private void _UpdateDailyTodoActivity(DailyTodoActivity model)
		{
			if (model == null)
			{
				return;
			}
			ActivityDungeonSub subByActivityDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByActivityDungeonID(model.activityDungeonId);
			if (subByActivityDungeonID == null)
			{
				return;
			}
			model.startTimestamp = Convert.ToInt32(Function.GetTodayGivenHourAndMinuteTimestamp(model.openTimes.startTimeHour, model.openTimes.startTimeMinute));
			model.endTimestamp = Convert.ToInt32(Function.GetTodayGivenHourAndMinuteTimestamp(model.openTimes.endTimeHour, model.openTimes.endTimeMinute));
			if (subByActivityDungeonID.drops != null && model.rewardItemIds != null)
			{
				model.rewardItemIds.Clear();
				for (int i = 0; i < subByActivityDungeonID.drops.Count; i++)
				{
					model.rewardItemIds.Add(subByActivityDungeonID.drops[i]);
				}
			}
			if (subByActivityDungeonID.activityInfo != null)
			{
				eActivityDungeonState eActivityDungeonState = subByActivityDungeonID.activityInfo.state;
				if (subByActivityDungeonID.dungeonId == 55)
				{
					eActivityDungeonState = ActivityDungeonFrame.Get3v3CrossDungeonActivityState();
				}
				else if (subByActivityDungeonID.dungeonId == 56)
				{
					eActivityDungeonState = ActivityDungeonFrame.GetGuildDungeonActivityState();
				}
				else if (subByActivityDungeonID.dungeonId == 20)
				{
					eActivityDungeonState = ActivityDungeonFrame.GetGuildBattleActivityState();
				}
				else if (subByActivityDungeonID.dungeonId == 58)
				{
					eActivityDungeonState = ActivityDungeonFrame.GetGuildCrossBattleActivityState();
				}
				else if (subByActivityDungeonID.dungeonId == 60)
				{
					eActivityDungeonState = ActivityDungeonFrame.Get2v2CrossDungeonActivityState();
				}
				if (eActivityDungeonState == eActivityDungeonState.None && model.endTimestamp <= Function.GetCurrTimeStamp())
				{
					eActivityDungeonState = eActivityDungeonState.End;
				}
				model.activityDungeonState = eActivityDungeonState;
			}
		}

		// Token: 0x0600B311 RID: 45841 RVA: 0x0027CE9C File Offset: 0x0027B29C
		private bool _IsTodayOpened(DailyTodoTable.eSubType subType)
		{
			switch (subType)
			{
			case DailyTodoTable.eSubType.DTSTP_DIALY_TASK:
				return this.IsDailyTaskTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_MAIN_DUNGEON:
				return this.IsMainDungeonTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_SHENYUAN_DUNGEON:
				return this.IsDeepDungeonTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_YUANGU_DUNGEON:
				return this.IsAncientDungeonTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_CITY_MONSTER_DUNGEON:
				return this.IsCityMonstorTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_XUKONG_DUNGEON:
				return this.IsVanityFractureTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_HUNDUN_DUNGEON:
				return this.IsWeekHellDungeonTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_GROUP_DUNGEON:
				return this.IsTeamGroupDungeonOpened();
			case DailyTodoTable.eSubType.DTSTP_ALD_BUDO:
				return this.IsAldBudoTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_REWARD_BUDO:
				return this.IsMoneyRewardBudoTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_3V3_PK:
				return this.IsPk3v3CrossTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_GUILD_BATTLE:
				return this.IsGuildBattleTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_CROSS_SERVER_GUILD_BATTLE:
				return this.IsCrossGuildBattleTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_GUILD_DUNGEON:
				return this.IsGuildDungeonTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_2v2_SCORE_WAR:
				return this.IsPk2v2ScoreWarTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_CHIJI_WAR:
				return this.IsChiJiWarTodayOpened();
			case DailyTodoTable.eSubType.DTSTP_GROPU_HARD_DUNGEON:
				return this.IsTeamHardGroupDungeonOpened();
			case DailyTodoTable.eSubType.DTSTP_GROUP_DUNGEON_TWO:
				return this.IsGroupDungeonTwoOpended();
			}
			return false;
		}

		// Token: 0x0600B312 RID: 45842 RVA: 0x0027CF84 File Offset: 0x0027B384
		private void _OnGoActivityDailyTodo(DailyTodoActivity model)
		{
			if (model == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(model.linkinfo))
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(model.linkinfo, null, false);
			}
			else
			{
				ActivityDungeonSub subByActivityDungeonID = DataManager<ActivityDungeonDataManager>.GetInstance().GetSubByActivityDungeonID(model.activityDungeonId);
				if (subByActivityDungeonID == null || subByActivityDungeonID.table == null)
				{
					return;
				}
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(subByActivityDungeonID.table.GoLinkInfo, null, false);
			}
			DailyTodoFrame.CloseFrame();
		}

		// Token: 0x0600B313 RID: 45843 RVA: 0x0027D000 File Offset: 0x0027B400
		private ActivityDungeonSub _GetActivityDungeonSubByDungeonId(int activityDungeonId)
		{
			ActivityDungeonSub result = null;
			List<ActivityDungeonTab> tabByActivityType = DataManager<ActivityDungeonDataManager>.GetInstance().GetTabByActivityType(ActivityDungeonTable.eActivityType.TimeLimit);
			if (tabByActivityType != null)
			{
				for (int i = 0; i < tabByActivityType.Count; i++)
				{
					ActivityDungeonTab activityDungeonTab = tabByActivityType[i];
					if (activityDungeonTab != null && activityDungeonTab.subs != null)
					{
						for (int j = 0; j < activityDungeonTab.subs.Count; j++)
						{
							ActivityDungeonSub activityDungeonSub = activityDungeonTab.subs[j];
							if (activityDungeonSub != null)
							{
								if (activityDungeonSub.id == activityDungeonId)
								{
									result = activityDungeonSub;
									break;
								}
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B314 RID: 45844 RVA: 0x0027D0A8 File Offset: 0x0027B4A8
		private void _InitDailyTodoFunction(DailyTodoFunction model, DailyTodoTable table)
		{
			if (model == null || table == null)
			{
				return;
			}
			model.recommendType = table.RecommendNumType;
			model.dayRecommendTotalCount = table.DayRecommendNum;
			model.characterDesc = table.FuncCharacter;
			this._UpdateDailyTodoFuncDayRecommendMax(model, table.DayRecommendNum);
			if (model.RecommendState == DailyTodoFuncState.None)
			{
				model.RecommendState = DailyTodoFuncState.Start;
			}
			model.gotoHandler = new Action<DailyTodoFunction>(this._OnGoFunctionDailyTodo);
		}

		// Token: 0x0600B315 RID: 45845 RVA: 0x0027D118 File Offset: 0x0027B518
		private void _UpdateDailyTodoFunction(DailyTodoInfo info)
		{
			if (info == null)
			{
				return;
			}
			if (this.m_FunctionDailyTodoList == null || this.m_FunctionDailyTodoList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.m_FunctionDailyTodoList.Count; i++)
			{
				DailyTodoFunction dailyTodoFunction = this.m_FunctionDailyTodoList[i];
				if (dailyTodoFunction != null)
				{
					if ((long)dailyTodoFunction.tableId == (long)((ulong)info.dataId))
					{
						this._UpdateDailyTodoFuncDayRecommendMax(dailyTodoFunction, (int)info.dayProgMax);
						bool flag = info.weekProgress < info.weekProgMax;
						bool flag2 = info.dayProgress < info.dayProgMax;
						if (flag && flag2)
						{
							dailyTodoFunction.RecommendState = DailyTodoFuncState.Start;
						}
						else
						{
							dailyTodoFunction.RecommendState = DailyTodoFuncState.Finishing;
						}
						if (!flag)
						{
							dailyTodoFunction.WeekRecommendFinishTimestamp = Function.GetCurrTimeStamp();
						}
						else
						{
							dailyTodoFunction.WeekRecommendFinishTimestamp = 0;
						}
					}
				}
			}
		}

		// Token: 0x0600B316 RID: 45846 RVA: 0x0027D210 File Offset: 0x0027B610
		private void _UpdateDailyTodoFuncDayRecommendMax(DailyTodoFunction model, int dayRecommedCount)
		{
			if (model == null)
			{
				return;
			}
			model.dayRecommendTotalCount = dayRecommedCount;
			if (model.recommendType == DailyTodoTable.eRecommendNumType.RT_NUMBER)
			{
				model.dayRecommendDesc = TR.Value(this.tr_daily_todo_recommend_num_Key, dayRecommedCount.ToString());
			}
			else if (model.recommendType == DailyTodoTable.eRecommendNumType.RT_ACTIVE)
			{
				model.dayRecommendDesc = TR.Value(this.tr_daily_todo_recommend_active_Key, dayRecommedCount.ToString());
			}
		}

		// Token: 0x0600B317 RID: 45847 RVA: 0x0027D284 File Offset: 0x0027B684
		private bool _CheckTodayTimeWillOpen(DailyTodoModel model)
		{
			if (model == null)
			{
				return false;
			}
			int num = Function.GetTodayWeek();
			if (num == 0)
			{
				num = 7;
			}
			return model.openWeeks == null || model.openWeeks.Count <= 0 || model.openWeeks.Contains(num);
		}

		// Token: 0x0600B318 RID: 45848 RVA: 0x0027D2D8 File Offset: 0x0027B6D8
		private bool _CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType subType)
		{
			return this.m_DailyTodoTotalDic != null && this.m_DailyTodoTotalDic.ContainsKey((int)subType) && this._CheckTodayTimeWillOpen(this.m_DailyTodoTotalDic[(int)subType]);
		}

		// Token: 0x0600B319 RID: 45849 RVA: 0x0027D31C File Offset: 0x0027B71C
		private bool _CheckFunctionRecommendFinish(DailyTodoTable.eSubType subType)
		{
			if (this.m_FunctionDailyTodoList == null || this.m_FunctionDailyTodoList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this.m_FunctionDailyTodoList.Count; i++)
			{
				DailyTodoFunction dailyTodoFunction = this.m_FunctionDailyTodoList[i];
				if (dailyTodoFunction != null)
				{
					if (dailyTodoFunction.subType == subType)
					{
						return dailyTodoFunction.RecommendState == DailyTodoFuncState.End;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B31A RID: 45850 RVA: 0x0027D394 File Offset: 0x0027B794
		private void _OnGoFunctionDailyTodo(DailyTodoFunction model)
		{
			if (model == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(model.linkinfo))
			{
				DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(model.linkinfo, null, false);
			}
			else
			{
				switch (model.subType)
				{
				case DailyTodoTable.eSubType.DTSTP_MAIN_DUNGEON:
				{
					int mainTask = DataManager<MissionManager>.GetInstance().GetMainTask(0);
					DataManager<MissionManager>.GetInstance().AutoTraceTask(mainTask, null, null, false);
					break;
				}
				case DailyTodoTable.eSubType.DTSTP_CITY_MONSTER_DUNGEON:
					DataManager<AttackCityMonsterDataManager>.GetInstance().EnterFindPathProcessByActivityDuplication();
					break;
				case DailyTodoTable.eSubType.DTSTP_XUKONG_DUNGEON:
					Utility.PathfindingYiJieMap();
					break;
				}
			}
			DailyTodoFrame.CloseFrame();
		}

		// Token: 0x0600B31B RID: 45851 RVA: 0x0027D450 File Offset: 0x0027B850
		private void _BindNetEvent()
		{
			NetProcess.AddMsgHandler(609302U, new Action<MsgDATA>(this._OnWorldGetPlayerDailyTodosRes));
		}

		// Token: 0x0600B31C RID: 45852 RVA: 0x0027D468 File Offset: 0x0027B868
		private void _UnBindNetEvent()
		{
			NetProcess.RemoveMsgHandler(609302U, new Action<MsgDATA>(this._OnWorldGetPlayerDailyTodosRes));
		}

		// Token: 0x0600B31D RID: 45853 RVA: 0x0027D480 File Offset: 0x0027B880
		private void _OnWorldGetPlayerDailyTodosRes(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			WorldGetPlayerDailyTodosRes worldGetPlayerDailyTodosRes = new WorldGetPlayerDailyTodosRes();
			worldGetPlayerDailyTodosRes.decode(msg.bytes);
			DailyTodoInfo[] dailyTodos = worldGetPlayerDailyTodosRes.dailyTodos;
			if (dailyTodos == null || dailyTodos.Length <= 0)
			{
				return;
			}
			foreach (DailyTodoInfo dailyTodoInfo in dailyTodos)
			{
				if (dailyTodoInfo != null)
				{
					this._UpdateDailyTodoFunction(dailyTodoInfo);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnDailyTodoFuncStateUpdate, null, null, null, null);
		}

		// Token: 0x0600B31E RID: 45854 RVA: 0x0027D4FC File Offset: 0x0027B8FC
		public List<DailyTodoActivity> GetShowDailyTodoActivityList()
		{
			if (this.m_TempShowActivityDailyTodoList != null)
			{
				this.m_TempShowActivityDailyTodoList.Clear();
			}
			if (this.m_ActivityDailyTodoList == null)
			{
				return this.m_TempShowActivityDailyTodoList;
			}
			for (int i = 0; i < this.m_ActivityDailyTodoList.Count; i++)
			{
				DailyTodoActivity dailyTodoActivity = this.m_ActivityDailyTodoList[i];
				if (dailyTodoActivity != null)
				{
					if (dailyTodoActivity.isTodayOpenedHandler != null && dailyTodoActivity.isTodayOpenedHandler(dailyTodoActivity.subType))
					{
						this.m_TempShowActivityDailyTodoList.Add(dailyTodoActivity);
					}
				}
			}
			return this.m_TempShowActivityDailyTodoList;
		}

		// Token: 0x0600B31F RID: 45855 RVA: 0x0027D598 File Offset: 0x0027B998
		public List<DailyTodoFunction> GetShowDailyTodoFunctionListByCount(int needCount = 3)
		{
			if (this.m_TempShowFunctionDailyTodoList != null)
			{
				this.m_TempShowFunctionDailyTodoList.Clear();
			}
			if (this.m_FunctionDailyTodoList == null || this.m_FunctionDailyTodoList.Count <= 0)
			{
				return this.m_TempShowFunctionDailyTodoList;
			}
			for (int i = 0; i < this.m_FunctionDailyTodoList.Count; i++)
			{
				DailyTodoFunction dailyTodoFunction = this.m_FunctionDailyTodoList[i];
				if (dailyTodoFunction != null)
				{
					if (dailyTodoFunction.isTodayOpenedHandler != null && dailyTodoFunction.isTodayOpenedHandler(dailyTodoFunction.subType))
					{
						if (needCount <= this.m_TempShowFunctionDailyTodoList.Count)
						{
							return this.m_TempShowFunctionDailyTodoList;
						}
						this.m_TempShowFunctionDailyTodoList.Add(dailyTodoFunction);
					}
				}
			}
			int count = this.m_TempShowFunctionDailyTodoList.Count;
			int num = needCount - count;
			if (num > 0)
			{
				List<DailyTodoFunction> list = ListPool<DailyTodoFunction>.Get();
				for (int j = this.m_FunctionDailyTodoList.Count - 1; j >= 0; j--)
				{
					DailyTodoFunction dailyTodoFunction2 = this.m_FunctionDailyTodoList[j];
					if (dailyTodoFunction2 != null)
					{
						if (dailyTodoFunction2.isTodayOpenedHandler != null && !dailyTodoFunction2.isTodayOpenedHandler(dailyTodoFunction2.subType) && dailyTodoFunction2.RecommendState == DailyTodoFuncState.End && dailyTodoFunction2.IsWeekRecommendShow)
						{
							list.Add(dailyTodoFunction2);
						}
					}
				}
				list.Sort((DailyTodoFunction x, DailyTodoFunction y) => -x.NearlyRecommendEndTimeStamp.CompareTo(y.NearlyRecommendEndTimeStamp));
				if (num > list.Count)
				{
					return this.m_TempShowFunctionDailyTodoList;
				}
				for (int k = 0; k < num; k++)
				{
					this.m_TempShowFunctionDailyTodoList.Add(list[k]);
				}
				this.m_TempShowFunctionDailyTodoList.Sort((DailyTodoFunction x, DailyTodoFunction y) => x.CompareTo(y));
				ListPool<DailyTodoFunction>.Release(list);
			}
			return this.m_TempShowFunctionDailyTodoList;
		}

		// Token: 0x0600B320 RID: 45856 RVA: 0x0027D78F File Offset: 0x0027BB8F
		public void ClearTempShowDailyTodoData()
		{
			if (this.m_TempShowActivityDailyTodoList != null)
			{
				this.m_TempShowActivityDailyTodoList.Clear();
			}
			if (this.m_TempShowFunctionDailyTodoList != null)
			{
				this.m_TempShowFunctionDailyTodoList.Clear();
			}
		}

		// Token: 0x0600B321 RID: 45857 RVA: 0x0027D7C0 File Offset: 0x0027BBC0
		public void ReqDailyTodoFunctionState()
		{
			WorldGetPlayerDailyTodosReq cmd = new WorldGetPlayerDailyTodosReq();
			MonoSingleton<NetManager>.instance.SendCommand<WorldGetPlayerDailyTodosReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600B322 RID: 45858 RVA: 0x0027D7E0 File Offset: 0x0027BBE0
		public void UpdateDailyTodoActivityList()
		{
			if (this.m_ActivityDailyTodoList == null || this.m_ActivityDailyTodoList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.m_ActivityDailyTodoList.Count; i++)
			{
				this._UpdateDailyTodoActivity(this.m_ActivityDailyTodoList[i]);
			}
		}

		// Token: 0x0600B323 RID: 45859 RVA: 0x0027D838 File Offset: 0x0027BC38
		public bool IsAldBudoTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Duel) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_ALD_BUDO);
		}

		// Token: 0x0600B324 RID: 45860 RVA: 0x0027D857 File Offset: 0x0027BC57
		public bool IsAldBudoOpened()
		{
			return this.IsAldBudoTodayOpened() && DataManager<BudoManager>.GetInstance().IsOpen;
		}

		// Token: 0x0600B325 RID: 45861 RVA: 0x0027D878 File Offset: 0x0027BC78
		public bool IsPk3v3CrossTodayOpened()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(450, string.Empty, string.Empty);
			return (tableItem == null || (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.Value) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_3V3_PK);
		}

		// Token: 0x0600B326 RID: 45862 RVA: 0x0027D8CC File Offset: 0x0027BCCC
		public bool IsPk3v3CrossOpened()
		{
			return this.IsPk3v3CrossTodayOpened() && DataManager<Pk3v3CrossDataManager>.GetInstance().IsIDOpened((ulong)ClientApplication.playerinfo.accid);
		}

		// Token: 0x0600B327 RID: 45863 RVA: 0x0027D8F8 File Offset: 0x0027BCF8
		public bool IsMoneyRewardBudoTodayOpened()
		{
			return DataManager<MoneyRewardsDataManager>.GetInstance().isLevelFit && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_REWARD_BUDO);
		}

		// Token: 0x0600B328 RID: 45864 RVA: 0x0027D91B File Offset: 0x0027BD1B
		public bool IsMoneyRewardBudoOpened()
		{
			return this.IsMoneyRewardBudoTodayOpened() && DataManager<MoneyRewardsDataManager>.GetInstance().isOpen;
		}

		// Token: 0x0600B329 RID: 45865 RVA: 0x0027D93C File Offset: 0x0027BD3C
		public bool IsGuildBattleTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Guild) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_GUILD_BATTLE);
		}

		// Token: 0x0600B32A RID: 45866 RVA: 0x0027D95C File Offset: 0x0027BD5C
		public bool IsGuildBattleOpened()
		{
			return this.IsGuildBattleTodayOpened() && DataManager<GuildDataManager>.GetInstance().myGuild != null;
		}

		// Token: 0x0600B32B RID: 45867 RVA: 0x0027D97D File Offset: 0x0027BD7D
		public bool IsCrossGuildBattleTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Guild) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_CROSS_SERVER_GUILD_BATTLE);
		}

		// Token: 0x0600B32C RID: 45868 RVA: 0x0027D99D File Offset: 0x0027BD9D
		public bool IsCrossGuildBattleOpened()
		{
			return this.IsCrossGuildBattleTodayOpened() && DataManager<GuildDataManager>.GetInstance().myGuild != null;
		}

		// Token: 0x0600B32D RID: 45869 RVA: 0x0027D9BE File Offset: 0x0027BDBE
		public bool IsGuildDungeonTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Guild) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_GUILD_DUNGEON);
		}

		// Token: 0x0600B32E RID: 45870 RVA: 0x0027D9DE File Offset: 0x0027BDDE
		public bool IsGuildDungeonOpened()
		{
			return this.IsGuildDungeonTodayOpened() && DataManager<GuildDataManager>.GetInstance().myGuild != null;
		}

		// Token: 0x0600B32F RID: 45871 RVA: 0x0027DA00 File Offset: 0x0027BE00
		public bool IsPk2v2ScoreWarTodayOpened()
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(638, string.Empty, string.Empty);
			return (tableItem == null || (int)DataManager<PlayerBaseData>.GetInstance().Level >= tableItem.Value) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_2v2_SCORE_WAR);
		}

		// Token: 0x0600B330 RID: 45872 RVA: 0x0027DA54 File Offset: 0x0027BE54
		public bool IsPk2v2ScoreWarOpened()
		{
			return this.IsPk2v2ScoreWarTodayOpened() && DataManager<Pk2v2CrossDataManager>.GetInstance().IsIDOpened((ulong)ClientApplication.playerinfo.accid);
		}

		// Token: 0x0600B331 RID: 45873 RVA: 0x0027DA80 File Offset: 0x0027BE80
		public bool IsChiJiWarTodayOpened()
		{
			return (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<ChijiDataManager>.GetInstance().GetChijiOpenLevel() && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_CHIJI_WAR);
		}

		// Token: 0x0600B332 RID: 45874 RVA: 0x0027DAAD File Offset: 0x0027BEAD
		public bool IsChiJiWarOpened()
		{
			return this.IsChiJiWarTodayOpened() && DataManager<ChijiDataManager>.GetInstance().MainFrameChijiButtonIsShow();
		}

		// Token: 0x0600B333 RID: 45875 RVA: 0x0027DACE File Offset: 0x0027BECE
		public bool IsTeamGroupDungeonOpened()
		{
			return ChallengeUtility.GetChallengeDungeonLockLevelByModelType(DungeonModelTable.eType.TeamDuplicationModel) <= (int)DataManager<PlayerBaseData>.GetInstance().Level && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_GROUP_DUNGEON);
		}

		// Token: 0x0600B334 RID: 45876 RVA: 0x0027DAF6 File Offset: 0x0027BEF6
		public bool IsTeamHardGroupDungeonOpened()
		{
			return ChallengeUtility.GetChallengeDungeonLockLevelByModelType(DungeonModelTable.eType.TeamDuplicationModel) <= (int)DataManager<PlayerBaseData>.GetInstance().Level && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_GROPU_HARD_DUNGEON);
		}

		// Token: 0x0600B335 RID: 45877 RVA: 0x0027DB1F File Offset: 0x0027BF1F
		public bool IsGroupDungeonTwoOpended()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.TeamCopyTwo) && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_GROUP_DUNGEON_TWO) && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_GROUP_DUNGEON_TWO);
		}

		// Token: 0x0600B336 RID: 45878 RVA: 0x0027DB4E File Offset: 0x0027BF4E
		public bool IsDailyTaskTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.DailyTask) && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_DIALY_TASK);
		}

		// Token: 0x0600B337 RID: 45879 RVA: 0x0027DB6D File Offset: 0x0027BF6D
		public bool IsMainDungeonTodayOpened()
		{
			return !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_MAIN_DUNGEON);
		}

		// Token: 0x0600B338 RID: 45880 RVA: 0x0027DB7E File Offset: 0x0027BF7E
		public bool IsCityMonstorTodayOpened()
		{
			return 25 <= DataManager<PlayerBaseData>.GetInstance().Level && this._CheckTodayTimeWillOpenBySubType(DailyTodoTable.eSubType.DTSTP_CITY_MONSTER_DUNGEON) && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_CITY_MONSTER_DUNGEON);
		}

		// Token: 0x0600B339 RID: 45881 RVA: 0x0027DBB0 File Offset: 0x0027BFB0
		public bool IsDeepDungeonTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.DeepDungeon) && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_SHENYUAN_DUNGEON);
		}

		// Token: 0x0600B33A RID: 45882 RVA: 0x0027DBCF File Offset: 0x0027BFCF
		public bool IsAncientDungeonTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.AncientDungeon) && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_YUANGU_DUNGEON);
		}

		// Token: 0x0600B33B RID: 45883 RVA: 0x0027DBEE File Offset: 0x0027BFEE
		public bool IsWeekHellDungeonTodayOpened()
		{
			return ChallengeUtility.GetChallengeDungeonLockLevelByModelType(DungeonModelTable.eType.WeekHellModel) <= (int)DataManager<PlayerBaseData>.GetInstance().Level && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_HUNDUN_DUNGEON);
		}

		// Token: 0x0600B33C RID: 45884 RVA: 0x0027DC16 File Offset: 0x0027C016
		public bool IsVanityFractureTodayOpened()
		{
			return Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.VanityFracture) && !this._CheckFunctionRecommendFinish(DailyTodoTable.eSubType.DTSTP_XUKONG_DUNGEON);
		}

		// Token: 0x040064FA RID: 25850
		private bool m_IsInited;

		// Token: 0x040064FB RID: 25851
		private Dictionary<int, DailyTodoModel> m_DailyTodoTotalDic = new Dictionary<int, DailyTodoModel>();

		// Token: 0x040064FC RID: 25852
		private List<DailyTodoActivity> m_ActivityDailyTodoList = new List<DailyTodoActivity>();

		// Token: 0x040064FD RID: 25853
		private List<DailyTodoFunction> m_FunctionDailyTodoList = new List<DailyTodoFunction>();

		// Token: 0x040064FE RID: 25854
		private List<DailyTodoActivity> m_TempShowActivityDailyTodoList = new List<DailyTodoActivity>();

		// Token: 0x040064FF RID: 25855
		private List<DailyTodoFunction> m_TempShowFunctionDailyTodoList = new List<DailyTodoFunction>();

		// Token: 0x04006500 RID: 25856
		private string tr_daily_todo_activity_time_Key = "daily_todo_activity_time_format";

		// Token: 0x04006501 RID: 25857
		private string tr_daily_todo_recommend_num_Key = "daily_todo_recommend_num_format";

		// Token: 0x04006502 RID: 25858
		private string tr_daily_todo_recommend_active_Key = "daily_todo_recommend_active_format";
	}
}
