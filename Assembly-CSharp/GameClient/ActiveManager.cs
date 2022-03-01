using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using GamePool;
using Network;
using Parser;
using Protocol;
using ProtoTable;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02004536 RID: 17718
	public class ActiveManager : DataManager<ActiveManager>
	{
		// Token: 0x17002018 RID: 8216
		// (get) Token: 0x06018AAE RID: 101038 RVA: 0x007B34B4 File Offset: 0x007B18B4
		// (set) Token: 0x06018AAF RID: 101039 RVA: 0x007B34BC File Offset: 0x007B18BC
		public bool WelfareTABEnergyRedPointFlag
		{
			get
			{
				return this.welfareTABEnergyRedPointFlag;
			}
			set
			{
				this.welfareTABEnergyRedPointFlag = value;
			}
		}

		// Token: 0x17002019 RID: 8217
		// (get) Token: 0x06018AB0 RID: 101040 RVA: 0x007B34C5 File Offset: 0x007B18C5
		// (set) Token: 0x06018AB1 RID: 101041 RVA: 0x007B34CD File Offset: 0x007B18CD
		public bool WelfareTABRewardRedPointFlag
		{
			get
			{
				return this.welfareTABRewardRedPointFlag;
			}
			set
			{
				this.welfareTABRewardRedPointFlag = value;
			}
		}

		// Token: 0x1700201A RID: 8218
		// (get) Token: 0x06018AB2 RID: 101042 RVA: 0x007B34D6 File Offset: 0x007B18D6
		public Dictionary<int, ActiveManager.ActiveData> ActiveDictionary
		{
			get
			{
				return this.m_akActiveDictionary;
			}
		}

		// Token: 0x06018AB3 RID: 101043 RVA: 0x007B34E0 File Offset: 0x007B18E0
		private void _LoadTemplate2IdLists()
		{
			if (this.m_akTemplate2idList.Count == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ActiveTable activeTable = keyValuePair.Value as ActiveTable;
					ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(activeTable.TemplateID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						List<ActiveTable> list = null;
						if (!this.m_akTemplate2idList.TryGetValue(activeTable.TemplateID, out list))
						{
							list = new List<ActiveTable>();
							this.m_akTemplate2idList.Add(activeTable.TemplateID, list);
						}
						list.Add(activeTable);
					}
				}
			}
		}

		// Token: 0x06018AB4 RID: 101044 RVA: 0x007B3595 File Offset: 0x007B1995
		public List<ActiveMainTable> GetType2Templates(int iConfigID)
		{
			if (this.m_akType2Templates.ContainsKey(iConfigID))
			{
				return this.m_akType2Templates[iConfigID];
			}
			return null;
		}

		// Token: 0x06018AB5 RID: 101045 RVA: 0x007B35B8 File Offset: 0x007B19B8
		private void _LoadActiveType2Templates()
		{
			this.m_akType2Templates.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveMainTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActiveMainTable activeMainTable = keyValuePair.Value as ActiveMainTable;
				if (activeMainTable != null)
				{
					List<ActiveMainTable> list = null;
					if (!this.m_akType2Templates.TryGetValue(activeMainTable.ActiveTypeID, out list))
					{
						list = new List<ActiveMainTable>();
						this.m_akType2Templates.Add(activeMainTable.ActiveTypeID, list);
					}
					list.Add(activeMainTable);
				}
			}
		}

		// Token: 0x06018AB6 RID: 101046 RVA: 0x007B364C File Offset: 0x007B1A4C
		private void _LoadMainKeyValues()
		{
			List<CounterInfo> countInfos = DataManager<CountDataManager>.GetInstance().GetCountInfos();
			if (countInfos != null)
			{
				for (int i = 0; i < countInfos.Count; i++)
				{
					this.OnCountChanged(countInfos[i]);
				}
			}
		}

		// Token: 0x06018AB7 RID: 101047 RVA: 0x007B368E File Offset: 0x007B1A8E
		public void RemoveOneActiveData(int activityTemplateId)
		{
			if (this.m_akActiveDictionary == null || this.m_akActiveDictionary.Count <= 0)
			{
				return;
			}
			this.m_akActiveDictionary.Remove(activityTemplateId);
		}

		// Token: 0x06018AB8 RID: 101048 RVA: 0x007B36BC File Offset: 0x007B1ABC
		public void AddOneActiveData(int activityTemplateId)
		{
			if (this.m_akActiveDictionary == null)
			{
				return;
			}
			if (this.m_akActiveDictionary.ContainsKey(activityTemplateId))
			{
				return;
			}
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(activityTemplateId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ActiveManager.ActiveData activeData = new ActiveManager.ActiveData();
				activeData.iActiveID = activityTemplateId;
				activeData.mainItem = tableItem;
				activeData.iActiveSortID = tableItem.SortID;
				activeData.mainInfo = new ActivityInfo();
				activeData.mainInfo.state = 0;
				activeData.akChildItems.Clear();
				this.m_akActiveDictionary.Add(activityTemplateId, activeData);
			}
		}

		// Token: 0x06018AB9 RID: 101049 RVA: 0x007B3754 File Offset: 0x007B1B54
		private void _LoadTableActiveData()
		{
			if (this.m_akActiveDictionary.Count == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					ActiveTable activeTable = keyValuePair.Value as ActiveTable;
					if (activeTable.TemplateID / 1000 == 7)
					{
						ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(activeTable.TemplateID, string.Empty, string.Empty);
						if (tableItem != null)
						{
							ActiveManager.ActiveData activeData = null;
							if (!this.m_akActiveDictionary.TryGetValue(activeTable.TemplateID, out activeData))
							{
								activeData = new ActiveManager.ActiveData();
								activeData.iActiveID = activeTable.TemplateID;
								activeData.mainItem = tableItem;
								activeData.iActiveSortID = tableItem.SortID;
								activeData.mainInfo = new ActivityInfo();
								activeData.mainInfo.state = 0;
								activeData.akChildItems.Clear();
								this.m_akActiveDictionary.Add(activeTable.TemplateID, activeData);
							}
							this._LoadActivityDataFromTable(activeData, activeTable.TemplateID);
							this._LoadKey2Prefab(activeData, activeTable.TemplateID);
							this._LoadKey2Content(activeData, activeTable.TemplateID);
						}
						else
						{
							Logger.LogErrorFormat("ProtoTable.ActiveTable ID = {0} It's TemplateID = {1} which mapped ActiveMainTable is wrong !", new object[]
							{
								activeTable.ID,
								activeTable.TemplateID
							});
						}
					}
				}
			}
		}

		// Token: 0x06018ABA RID: 101050 RVA: 0x007B38BC File Offset: 0x007B1CBC
		public override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.ActiveManager;
		}

		// Token: 0x06018ABB RID: 101051 RVA: 0x007B38BF File Offset: 0x007B1CBF
		public override void Initialize()
		{
			this.RegisterNetHandler();
			this._LoadTemplate2IdLists();
			this._LoadActiveType2Templates();
			this._LoadTableActiveData();
			this._LoadMainKeyValues();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x06018ABC RID: 101052 RVA: 0x007B38FA File Offset: 0x007B1CFA
		public override void OnEnterSystem()
		{
			this.m_akActiveFrameConfigs.Clear();
		}

		// Token: 0x06018ABD RID: 101053 RVA: 0x007B3907 File Offset: 0x007B1D07
		public override void OnExitSystem()
		{
			this.m_akActiveFrameConfigs.Clear();
		}

		// Token: 0x06018ABE RID: 101054 RVA: 0x007B3914 File Offset: 0x007B1D14
		public override void Clear()
		{
			this.UnRegisterNetHandler();
			this.welfareTABRewardRedPointFlag = false;
			this.welfareTABEnergyRedPointFlag = false;
			this.bInited = false;
			this.m_akActivitiesDic.Clear();
			this.m_akActiveFrameConfigs.Clear();
			this.m_akActiveDictionary.Clear();
			this.m_akRedPointMap.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
		}

		// Token: 0x06018ABF RID: 101055 RVA: 0x007B3984 File Offset: 0x007B1D84
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(501128U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskVar));
			NetProcess.AddMsgHandler(501129U, new Action<MsgDATA>(this.OnRecvSceneSyncActiveTaskListNormal));
			NetProcess.AddMsgHandler(602901U, new Action<MsgDATA>(this.OnRecvWorldNotifyClientActivity));
			NetProcess.AddMsgHandler(501136U, new Action<MsgDATA>(this.OnRecvWorldSyncClientActivitiesNormal));
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			NetProcess.AddMsgHandler(501137U, new Action<MsgDATA>(this.OnRecvSceneActiveRestTimeRet));
		}

		// Token: 0x06018AC0 RID: 101056 RVA: 0x007B3A18 File Offset: 0x007B1E18
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(501128U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskVar));
			NetProcess.RemoveMsgHandler(501129U, new Action<MsgDATA>(this.OnRecvSceneSyncActiveTaskListNormal));
			NetProcess.RemoveMsgHandler(602901U, new Action<MsgDATA>(this.OnRecvWorldNotifyClientActivity));
			NetProcess.RemoveMsgHandler(501136U, new Action<MsgDATA>(this.OnRecvWorldSyncClientActivitiesNormal));
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			NetProcess.RemoveMsgHandler(501137U, new Action<MsgDATA>(this.OnRecvSceneActiveRestTimeRet));
		}

		// Token: 0x06018AC1 RID: 101057 RVA: 0x007B3AAC File Offset: 0x007B1EAC
		private void _OnCountValueChanged(UIEvent a_event)
		{
			CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(a_event.Param1 as string);
			if (countInfo != null)
			{
				this.OnCountChanged(countInfo);
			}
		}

		// Token: 0x06018AC2 RID: 101058 RVA: 0x007B3ADC File Offset: 0x007B1EDC
		private void OnCountChanged(CounterInfo info)
		{
			if (!string.IsNullOrEmpty(info.name))
			{
				string[] keyValues = info.name.Split(new char[]
				{
					'_'
				});
				if (keyValues.Length == 2)
				{
					int key = 0;
					if (int.TryParse(keyValues[0], out key) && !string.IsNullOrEmpty(keyValues[1]) && this.ActiveDictionary.ContainsKey(key))
					{
						ActiveManager.ActiveData activeData = this.ActiveDictionary[key];
						if (activeData != null)
						{
							ActiveManager.ActiveMainKeyValue activeMainKeyValue = activeData.mainKeyValue.Find((ActiveManager.ActiveMainKeyValue x) => x.key == keyValues[1]);
							if (activeMainKeyValue == null)
							{
								activeMainKeyValue = new ActiveManager.ActiveMainKeyValue();
								activeMainKeyValue.key = keyValues[1];
								activeData.mainKeyValue.Add(activeMainKeyValue);
							}
							activeMainKeyValue.value = info.value.ToString();
							ActiveManager.ActiveMainUpdateKey activeMainUpdateKey = activeData.updateMainKeys.Find((ActiveManager.ActiveMainUpdateKey x) => x.key == keyValues[1]);
							if (activeMainUpdateKey != null)
							{
								activeMainUpdateKey.fRecievedTime = DataManager<TimeManager>.GetInstance().GetServerTime();
								activeMainUpdateKey.value = info.value.ToString();
							}
							if (this.onUpdateMainActivity != null)
							{
								this.onUpdateMainActivity(activeData);
							}
						}
					}
				}
			}
		}

		// Token: 0x06018AC3 RID: 101059 RVA: 0x007B3C2C File Offset: 0x007B202C
		private void OnRecvSceneNotifyActiveTaskVar(MsgDATA data)
		{
			SceneNotifyActiveTaskVar kRecv = new SceneNotifyActiveTaskVar();
			kRecv.decode(data.bytes);
			int iKey = (int)kRecv.taskId;
			ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(iKey, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ActiveManager.ActiveData activeData = null;
				if (this.m_akActiveDictionary.TryGetValue(tableItem.TemplateID, out activeData))
				{
					ActiveManager.ActivityData activityData = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.ID == iKey);
					if (activityData != null)
					{
						TaskPair taskPair = activityData.akActivityValues.Find((TaskPair x) => x.key == kRecv.key);
						if (taskPair != null)
						{
							taskPair.value = kRecv.val;
						}
						else
						{
							TaskPair taskPair2 = new TaskPair();
							taskPair2.key = kRecv.key;
							taskPair2.value = kRecv.val;
							activityData.akActivityValues.Add(taskPair2);
						}
						if (this.onActivityUpdate != null)
						{
							this.onActivityUpdate(activityData, ActiveManager.ActivityUpdateType.AUT_KEY_CHANGED);
						}
						if (activityData.activeItem.ReplaceID.Count > 0)
						{
							for (int i = 0; i < activityData.activeItem.ReplaceID.Count; i++)
							{
								int curReplaceID = activityData.activeItem.ReplaceID[i];
								ActiveManager.ActivityData activityData2 = activeData.akChildItems.Find((ActiveManager.ActivityData x) => curReplaceID == x.ID);
								if (activityData2 != null)
								{
									TaskPair taskPair3 = activityData2.akActivityValues.Find((TaskPair x) => x.key == kRecv.key);
									if (taskPair3 != null)
									{
										taskPair3.value = kRecv.val;
									}
									else
									{
										TaskPair taskPair4 = new TaskPair();
										taskPair4.key = kRecv.key;
										taskPair4.value = kRecv.val;
										activityData2.akActivityValues.Add(taskPair4);
									}
									if (this.onActivityUpdate != null)
									{
										this.onActivityUpdate(activityData2, ActiveManager.ActivityUpdateType.AUT_KEY_CHANGED);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06018AC4 RID: 101060 RVA: 0x007B3E5C File Offset: 0x007B225C
		public override void OnBindEnterGameMsg()
		{
			EnterGameBinding enterGameBinding = new EnterGameBinding();
			enterGameBinding.id = 501129U;
			try
			{
				enterGameBinding.method = new Action<MsgDATA>(this.OnRecvSceneSyncActiveTaskList);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("错误!! 绑定消息{0}(ID:{1})到方法", new object[]
				{
					Singleton<ProtocolHelper>.instance.GetName(enterGameBinding.id),
					enterGameBinding.id
				});
			}
			this.m_arrEnterGameBindings.Add(enterGameBinding);
		}

		// Token: 0x06018AC5 RID: 101061 RVA: 0x007B3EE4 File Offset: 0x007B22E4
		private void OnRecvSceneSyncActiveTaskList(MsgDATA data)
		{
			this.bInited = true;
			this.OnRecvSceneSyncActiveTaskListNormal(data);
		}

		// Token: 0x06018AC6 RID: 101062 RVA: 0x007B3EF4 File Offset: 0x007B22F4
		private void OnRecvSceneSyncActiveTaskListNormal(MsgDATA data)
		{
			if (!this.bInited)
			{
				return;
			}
			SceneSyncActiveTaskList sceneSyncActiveTaskList = new SceneSyncActiveTaskList();
			sceneSyncActiveTaskList.decode(data.bytes);
			for (int i = 0; i < sceneSyncActiveTaskList.tasks.Length; i++)
			{
				MissionInfo current = sceneSyncActiveTaskList.tasks[i];
				ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>((int)current.taskID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ActiveManager.ActiveData activeData = null;
					if (this.m_akActiveDictionary.TryGetValue(tableItem.TemplateID, out activeData))
					{
						ActiveManager.ActivityData activityData = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.ID == (int)current.taskID);
						if (activityData != null)
						{
							activityData.status = current.status;
							activityData.akActivityValues.Clear();
							for (int j = 0; j < current.akMissionPairs.Length; j++)
							{
								TaskPair taskPair = new TaskPair();
								taskPair.key = current.akMissionPairs[j].key;
								taskPair.value = current.akMissionPairs[j].value;
								activityData.akActivityValues.Add(taskPair);
							}
							if (this.onActivityUpdate != null)
							{
								this.onActivityUpdate(activityData, ActiveManager.ActivityUpdateType.AUT_CREATE);
							}
							if (activityData.activeItem.ReplaceID.Count > 0)
							{
								for (int k = 0; k < activityData.activeItem.ReplaceID.Count; k++)
								{
									int curReplaceID = activityData.activeItem.ReplaceID[k];
									ActiveManager.ActivityData activityData2 = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.ID == curReplaceID);
									if (activityData2 != null)
									{
										activityData2.status = current.status;
										activityData2.akActivityValues.Clear();
										for (int l = 0; l < current.akMissionPairs.Length; l++)
										{
											TaskPair taskPair2 = new TaskPair();
											taskPair2.key = current.akMissionPairs[l].key;
											taskPair2.value = current.akMissionPairs[l].value;
											activityData2.akActivityValues.Add(taskPair2);
										}
										if (this.onActivityUpdate != null)
										{
											this.onActivityUpdate(activityData2, ActiveManager.ActivityUpdateType.AUT_CREATE);
										}
									}
								}
							}
						}
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPayResultNotify, "10", null, null, null);
		}

		// Token: 0x06018AC7 RID: 101063 RVA: 0x007B418C File Offset: 0x007B258C
		private void OnRecvWorldNotifyClientActivity(MsgDATA data)
		{
			WorldNotifyClientActivity worldNotifyClientActivity = new WorldNotifyClientActivity();
			worldNotifyClientActivity.decode(data.bytes);
			if (worldNotifyClientActivity.type == 0)
			{
				int id = (int)worldNotifyClientActivity.id;
				if (this.m_akActiveDictionary.ContainsKey(id))
				{
					ActiveManager.ActiveData activeData = this.m_akActiveDictionary[id];
					activeData.mainInfo.state = 0;
					if (this.onRemoveMainActivity != null)
					{
						this.onRemoveMainActivity(activeData);
					}
				}
				if (this.allActivities.ContainsKey(id))
				{
					ActivityInfo activityInfo = this.allActivities[id];
					activityInfo.state = 0;
				}
			}
			else if (worldNotifyClientActivity.type == 1 || worldNotifyClientActivity.type == 2)
			{
				int id2 = (int)worldNotifyClientActivity.id;
				if (!this.m_akActiveDictionary.ContainsKey(id2))
				{
					this._OnAddActivety(new ActivityInfo
					{
						id = worldNotifyClientActivity.id,
						level = worldNotifyClientActivity.level,
						name = worldNotifyClientActivity.name,
						startTime = worldNotifyClientActivity.startTime,
						state = worldNotifyClientActivity.type,
						dueTime = worldNotifyClientActivity.dueTime
					});
				}
				else
				{
					ActiveManager.ActiveData activeData2 = this.m_akActiveDictionary[id2];
					activeData2.mainInfo = new ActivityInfo
					{
						id = worldNotifyClientActivity.id,
						level = worldNotifyClientActivity.level,
						name = worldNotifyClientActivity.name,
						startTime = worldNotifyClientActivity.startTime,
						state = worldNotifyClientActivity.type,
						dueTime = worldNotifyClientActivity.dueTime
					};
					if (this.onUpdateMainActivity != null)
					{
						this.onUpdateMainActivity(activeData2);
					}
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityUpdate, worldNotifyClientActivity.id, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityUpdateByActivityName, worldNotifyClientActivity.name, null, null, null);
		}

		// Token: 0x1700201B RID: 8219
		// (get) Token: 0x06018AC8 RID: 101064 RVA: 0x007B4376 File Offset: 0x007B2776
		// (set) Token: 0x06018AC9 RID: 101065 RVA: 0x007B437E File Offset: 0x007B277E
		public int BudoActive
		{
			get
			{
				return this.iBudoActive;
			}
			set
			{
				this.iBudoActive = value;
			}
		}

		// Token: 0x06018ACA RID: 101066 RVA: 0x007B4388 File Offset: 0x007B2788
		public bool IsBudoActive(int iID)
		{
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(200, string.Empty, string.Empty);
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(201, string.Empty, string.Empty);
			return tableItem != null && tableItem2 != null && tableItem.Value <= iID && iID <= tableItem2.Value;
		}

		// Token: 0x06018ACB RID: 101067 RVA: 0x007B43F4 File Offset: 0x007B27F4
		private void _OnAddActivety(ActivityInfo current)
		{
			if (!this.m_akActivitiesDic.ContainsKey((int)current.id))
			{
				this.m_akActivitiesDic.Add((int)current.id, current);
			}
			else
			{
				this.m_akActivitiesDic[(int)current.id] = current;
			}
			if (this.IsBudoActive((int)current.id))
			{
				this.BudoActive = (int)current.id;
			}
			int id = (int)current.id;
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (this.m_akTemplate2idList.ContainsKey(id))
				{
					ActiveManager.ActiveData activeData = null;
					this.m_akActiveDictionary.Remove(id);
					if (!this.m_akActiveDictionary.TryGetValue(id, out activeData))
					{
						activeData = new ActiveManager.ActiveData();
						activeData.iActiveID = id;
						activeData.mainItem = tableItem;
						activeData.iActiveSortID = tableItem.SortID;
						activeData.akChildItems.Clear();
						activeData.mainInfo = current;
						activeData.mainKeyValue.Clear();
						ActiveManager.ActiveMainKeyValue activeMainKeyValue = new ActiveManager.ActiveMainKeyValue();
						activeMainKeyValue.key = "ActiveName";
						activeMainKeyValue.value = tableItem.Name;
						activeData.mainKeyValue.Add(activeMainKeyValue);
						DateTime dateTime = Function.ConvertIntDateTime(activeData.mainInfo.startTime);
						activeMainKeyValue = new ActiveManager.ActiveMainKeyValue();
						activeMainKeyValue.key = "ActiveTime";
						activeMainKeyValue.value = dateTime.ToString(TR.Value("activity_normal_data_format"), DateTimeFormatInfo.InvariantInfo);
						ActiveManager.ActiveMainKeyValue activeMainKeyValue2 = activeMainKeyValue;
						activeMainKeyValue2.value += "~";
						dateTime = Function.ConvertIntDateTime(activeData.mainInfo.dueTime);
						ActiveManager.ActiveMainKeyValue activeMainKeyValue3 = activeMainKeyValue;
						activeMainKeyValue3.value += dateTime.ToString(TR.Value("activity_normal_data_format"), DateTimeFormatInfo.InvariantInfo);
						activeData.mainKeyValue.Add(activeMainKeyValue);
						activeMainKeyValue = new ActiveManager.ActiveMainKeyValue();
						activeMainKeyValue.key = "ActiveDesc";
						activeMainKeyValue.value = tableItem.PurDesc;
						activeData.mainKeyValue.Add(activeMainKeyValue);
						activeData.updateMainKeys.Clear();
						if (!string.IsNullOrEmpty(activeData.mainItem.UpdateMainKeys))
						{
							string[] array = activeData.mainItem.UpdateMainKeys.Split(new char[]
							{
								'\r',
								'\n'
							});
							for (int i = 0; i < array.Length; i++)
							{
								if (!string.IsNullOrEmpty(array[i]))
								{
									Match match = ActiveManager.ActiveMainUpdateKey.s_regex.Match(array[i]);
									if (!string.IsNullOrEmpty(match.Groups[0].Value))
									{
										ActiveManager.ActiveMainUpdateKey activeMainUpdateKey = new ActiveManager.ActiveMainUpdateKey();
										activeMainUpdateKey.key = match.Groups[1].Value;
										activeMainUpdateKey.iDefValue = int.Parse(match.Groups[2].Value);
										activeMainUpdateKey.content = match.Groups[3].Value;
										activeMainUpdateKey.fRecievedTime = DataManager<TimeManager>.GetInstance().GetServerTime();
										activeData.updateMainKeys.Add(activeMainUpdateKey);
										CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(current.id + "_" + activeMainUpdateKey.key);
										if (countInfo != null)
										{
											activeMainUpdateKey.iDefValue = (int)countInfo.value;
										}
										activeMainUpdateKey.value = activeMainUpdateKey.iDefValue.ToString();
									}
								}
							}
						}
						this.m_akActiveDictionary.Add(id, activeData);
					}
					this._LoadKey2Prefab(activeData, id);
					this._LoadActivityDataFromTable(activeData, id);
					this._LoadKey2Content(activeData, id);
					if (this.onAddMainActivity != null)
					{
						this.onAddMainActivity(activeData);
					}
				}
			}
		}

		// Token: 0x06018ACC RID: 101068 RVA: 0x007B4788 File Offset: 0x007B2B88
		private void _LoadActivityDataFromTable(ActiveManager.ActiveData activeData, int iTemplateID)
		{
			if (activeData != null && this.m_akTemplate2idList.ContainsKey(iTemplateID))
			{
				ActiveManager.<_LoadActivityDataFromTable>c__AnonStorey5 <_LoadActivityDataFromTable>c__AnonStorey = new ActiveManager.<_LoadActivityDataFromTable>c__AnonStorey5();
				<_LoadActivityDataFromTable>c__AnonStorey.activityids = this.m_akTemplate2idList[iTemplateID];
				int j;
				for (j = 0; j < <_LoadActivityDataFromTable>c__AnonStorey.activityids.Count; j++)
				{
					ActiveManager.ActivityData activityData = new ActiveManager.ActivityData();
					activityData.ID = <_LoadActivityDataFromTable>c__AnonStorey.activityids[j].ID;
					activityData.activeItem = <_LoadActivityDataFromTable>c__AnonStorey.activityids[j];
					if (activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.ID == <_LoadActivityDataFromTable>c__AnonStorey.activityids[j].ID) == null)
					{
						activeData.akChildItems.Add(activityData);
					}
				}
				return;
			}
			Logger.LogErrorFormat("_LoadActivtyDataFromTable error occued !", new object[0]);
		}

		// Token: 0x06018ACD RID: 101069 RVA: 0x007B487C File Offset: 0x007B2C7C
		private void _LoadKey2Prefab(ActiveManager.ActiveData activeData, int iTemplateID)
		{
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(iTemplateID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				activeData.prefabs = null;
				Regex regex = new Regex("<key=(\\w+) parent=([A-Za-z0-9/]+) local=([A-Za-z0-9/]+)>", RegexOptions.Singleline);
				if (!string.IsNullOrEmpty(tableItem.prefabDesc))
				{
					IEnumerator enumerator = regex.Matches(tableItem.prefabDesc).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Match match = (Match)obj;
							if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value))
							{
								if (activeData.prefabs == null)
								{
									activeData.prefabs = new Dictionary<string, ActiveManager.ActivityPrefab>();
									activeData.prefabs.Clear();
								}
								ActiveManager.ActivityPrefab activityPrefab = new ActiveManager.ActivityPrefab();
								activityPrefab.key = match.Groups[1].Value;
								activityPrefab.parent = match.Groups[2].Value;
								activityPrefab.local = match.Groups[3].Value;
								if (!activeData.prefabs.ContainsKey(activityPrefab.key))
								{
									activeData.prefabs.Add(activityPrefab.key, activityPrefab);
								}
							}
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
			}
		}

		// Token: 0x06018ACE RID: 101070 RVA: 0x007B49E0 File Offset: 0x007B2DE0
		private void _LoadKey2Content(ActiveManager.ActiveData activeData, int iTemplateID)
		{
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(iTemplateID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				Regex regex = new Regex("<Key=(\\w+) Name=([A-Za-z0-9/]+) Type=(\\w+) Show=([0-9,]+) Value=(.*)>", RegexOptions.Singleline);
				string[] array = tableItem.PrefabStatusDesc.Split(new char[]
				{
					'\r',
					'\n'
				});
				for (int i = 0; i < array.Length; i++)
				{
					if (!string.IsNullOrEmpty(array[i]))
					{
						Match match = regex.Match(array[i]);
						if (!string.IsNullOrEmpty(match.Groups[0].Value))
						{
							if (activeData.values == null)
							{
								activeData.values = new Dictionary<string, List<ActiveManager.ControlData>>();
								activeData.values.Clear();
							}
							string value = match.Groups[1].Value;
							string value2 = match.Groups[2].Value;
							string value3 = match.Groups[3].Value;
							string value4 = match.Groups[4].Value;
							string value5 = match.Groups[5].Value;
							List<ActiveManager.ControlData> list = null;
							if (!activeData.values.TryGetValue(value, out list))
							{
								list = new List<ActiveManager.ControlData>();
								activeData.values.Add(value, list);
							}
							ActiveManager.ControlData controlData = new ActiveManager.ControlData();
							controlData.Analysis(value2, value3, value4, value5);
							list.Add(controlData);
						}
					}
				}
			}
		}

		// Token: 0x06018ACF RID: 101071 RVA: 0x007B4B4C File Offset: 0x007B2F4C
		private void OnRecvWorldSyncClientActivitiesNormal(MsgDATA data)
		{
			SceneSyncClientActivities sceneSyncClientActivities = new SceneSyncClientActivities();
			sceneSyncClientActivities.decode(data.bytes);
			for (int i = 0; i < sceneSyncClientActivities.activities.Length; i++)
			{
				this._OnAddActivety(sceneSyncClientActivities.activities[i]);
				if (sceneSyncClientActivities.activities[i] != null)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityUpdate, sceneSyncClientActivities.activities[i].id, null, null, null);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityUpdateByActivityName, sceneSyncClientActivities.activities[i].name, null, null, null);
				}
			}
		}

		// Token: 0x06018AD0 RID: 101072 RVA: 0x007B4BE4 File Offset: 0x007B2FE4
		private void OnRecvSceneNotifyActiveTaskStatus(MsgDATA data)
		{
			SceneNotifyActiveTaskStatus sceneNotifyActiveTaskStatus = new SceneNotifyActiveTaskStatus();
			sceneNotifyActiveTaskStatus.decode(data.bytes);
			int key = (int)sceneNotifyActiveTaskStatus.taskId;
			ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(key, string.Empty, string.Empty);
			if (tableItem != null && this.m_akActiveDictionary.ContainsKey(tableItem.TemplateID))
			{
				ActiveManager.ActiveData activeData = this.m_akActiveDictionary[tableItem.TemplateID];
				ActiveManager.ActivityData activityData = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.ID == key);
				if (activityData != null)
				{
					activityData.status = sceneNotifyActiveTaskStatus.status;
					if (this.onActivityUpdate != null)
					{
						this.onActivityUpdate(activityData, ActiveManager.ActivityUpdateType.AUT_STATUS_CHANGED);
					}
					if (activityData.activeItem.ReplaceID.Count > 0)
					{
						for (int i = 0; i < activityData.activeItem.ReplaceID.Count; i++)
						{
							int curReplaceID = activityData.activeItem.ReplaceID[i];
							ActiveManager.ActivityData activityData2 = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.ID == curReplaceID);
							if (activityData2 != null)
							{
								activityData2.status = sceneNotifyActiveTaskStatus.status;
								if (this.onActivityUpdate != null)
								{
									this.onActivityUpdate(activityData2, ActiveManager.ActivityUpdateType.AUT_STATUS_CHANGED);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06018AD1 RID: 101073 RVA: 0x007B4D4C File Offset: 0x007B314C
		public void SendSevenDayTimeReq()
		{
			SceneActiveRestTimeReq cmd = new SceneActiveRestTimeReq();
			NetManager.Instance().SendCommand<SceneActiveRestTimeReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x06018AD2 RID: 101074 RVA: 0x007B4D6C File Offset: 0x007B316C
		private void OnRecvSceneActiveRestTimeRet(MsgDATA msgData)
		{
			SceneActiveRestTimeRet sceneActiveRestTimeRet = new SceneActiveRestTimeRet();
			sceneActiveRestTimeRet.decode(msgData.bytes);
			double recvTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (this.onSevenDayTimeChanged != null)
			{
				this.onSevenDayTimeChanged(sceneActiveRestTimeRet.time1, sceneActiveRestTimeRet.time2, sceneActiveRestTimeRet.time3, recvTime);
			}
		}

		// Token: 0x06018AD3 RID: 101075 RVA: 0x007B4DC4 File Offset: 0x007B31C4
		public void SendSubmitActivity(int iChildID, uint iParam = 0U)
		{
			SceneActiveTaskSubmit sceneActiveTaskSubmit = new SceneActiveTaskSubmit();
			sceneActiveTaskSubmit.taskId = (uint)iChildID;
			sceneActiveTaskSubmit.param1 = iParam;
			NetManager.Instance().SendCommand<SceneActiveTaskSubmit>(ServerType.GATE_SERVER, sceneActiveTaskSubmit);
		}

		// Token: 0x06018AD4 RID: 101076 RVA: 0x007B4DF2 File Offset: 0x007B31F2
		private int _SortActivities(ActiveManager.ActivityData left, ActiveManager.ActivityData right)
		{
			return left.activeItem.ID - right.activeItem.ID;
		}

		// Token: 0x06018AD5 RID: 101077 RVA: 0x007B4E0C File Offset: 0x007B320C
		public void SendSceneActiveTaskSubmitRp(int iTemplateID, bool bOnce = true)
		{
			List<uint> list = new List<uint>();
			if (this.ActiveDictionary.ContainsKey(iTemplateID))
			{
				ActiveManager.ActiveData activeData = this.ActiveDictionary[iTemplateID];
				if (activeData != null)
				{
					int val = 0;
					for (int i = 0; i < activeData.akChildItems.Count; i++)
					{
						if (activeData.akChildItems[i].status == 5)
						{
							val = Math.Max(val, activeData.akChildItems[i].ID);
						}
					}
					List<ActiveManager.ActivityData> list2 = new List<ActiveManager.ActivityData>();
					list2.InsertRange(0, activeData.akChildItems);
					list2.RemoveAll((ActiveManager.ActivityData x) => x.status == 5);
					list2.Sort(new Comparison<ActiveManager.ActivityData>(this._SortActivities));
					list.Clear();
					int num = this.GetTemplateValue(iTemplateID, "SIRp", 0);
					if (bOnce && num > 1)
					{
						num = 1;
					}
					int num2 = 0;
					while (num2 < list2.Count && num2 < num)
					{
						list.Add((uint)list2[num2].ID);
						num2++;
					}
				}
			}
			if (list.Count > 0)
			{
				SceneActiveTaskSubmitRp sceneActiveTaskSubmitRp = new SceneActiveTaskSubmitRp();
				sceneActiveTaskSubmitRp.taskId = list.ToArray();
				NetManager.Instance().SendCommand<SceneActiveTaskSubmitRp>(ServerType.GATE_SERVER, sceneActiveTaskSubmitRp);
			}
		}

		// Token: 0x1700201C RID: 8220
		// (get) Token: 0x06018AD6 RID: 101078 RVA: 0x007B4F6A File Offset: 0x007B336A
		public Dictionary<int, ActivityInfo> allActivities
		{
			get
			{
				return this.m_akActivitiesDic;
			}
		}

		// Token: 0x06018AD7 RID: 101079 RVA: 0x007B4F72 File Offset: 0x007B3372
		public ActiveManager.ActiveFrameConfig PopAcitveFrameConfig()
		{
			if (this.m_akActiveFrameConfigs.Count > 0)
			{
				return this.m_akActiveFrameConfigs.Dequeue();
			}
			return null;
		}

		// Token: 0x06018AD8 RID: 101080 RVA: 0x007B4F94 File Offset: 0x007B3394
		public void OpenActiveFrame(int iConfigID, int iLinkTemplateID = 0)
		{
			bool flag = false;
			string prefabpath = string.Empty;
			if (this.m_akType2Templates.ContainsKey(iConfigID))
			{
				List<ActiveMainTable> list = this.m_akType2Templates[iConfigID];
				if (list != null && list.Count > 0)
				{
					for (int i = 0; i < list.Count; i++)
					{
						if (this.ActiveDictionary.ContainsKey(list[i].ID))
						{
							prefabpath = list[i].ActiveFrame;
							flag = true;
							break;
						}
					}
				}
			}
			if (flag)
			{
				ActiveManager.ActiveFrameConfig activeFrameConfig = new ActiveManager.ActiveFrameConfig();
				activeFrameConfig.iConfigID = iConfigID;
				activeFrameConfig.prefabpath = prefabpath;
				activeFrameConfig.templates = this.GetType2Templates(iConfigID);
				activeFrameConfig.iLinkTemplateID = iLinkTemplateID;
				this.m_akActiveFrameConfigs.Enqueue(activeFrameConfig);
				string text = "ActiveChargeFrame" + iConfigID;
				Singleton<ClientSystemManager>.GetInstance().CloseFrame(text);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActiveChargeFrame>(FrameLayer.Middle, activeFrameConfig, text);
			}
		}

		// Token: 0x06018AD9 RID: 101081 RVA: 0x007B5090 File Offset: 0x007B3490
		public int GetTemplateUpdateValue(int iTemplateID, string key, int iDefaultValue = 0)
		{
			int result = iDefaultValue;
			ActiveManager.ActiveData activeData = null;
			if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.TryGetValue(iTemplateID, out activeData))
			{
				ActiveManager.ActiveMainUpdateKey activeMainUpdateKey = activeData.updateMainKeys.Find((ActiveManager.ActiveMainUpdateKey x) => x.key == key);
				if (activeMainUpdateKey == null || int.TryParse(activeMainUpdateKey.value, out result))
				{
				}
			}
			return result;
		}

		// Token: 0x06018ADA RID: 101082 RVA: 0x007B50F8 File Offset: 0x007B34F8
		public int GetTemplateValue(int iTemplateID, string key, int iDefaultValue = 0)
		{
			int result = iDefaultValue;
			ActiveManager.ActiveData activeData = null;
			if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.TryGetValue(iTemplateID, out activeData))
			{
				ActiveManager.ActiveMainKeyValue activeMainKeyValue = activeData.mainKeyValue.Find((ActiveManager.ActiveMainKeyValue x) => x.key == key);
				if (activeMainKeyValue != null)
				{
					int.TryParse(activeMainKeyValue.value, out result);
				}
				else
				{
					CounterInfo countInfo = DataManager<CountDataManager>.GetInstance().GetCountInfo(iTemplateID + "_" + key);
					if (countInfo != null)
					{
						result = (int)countInfo.value;
					}
				}
			}
			return result;
		}

		// Token: 0x06018ADB RID: 101083 RVA: 0x007B5190 File Offset: 0x007B3590
		public ActiveManager.ActiveData GetActiveData(int iTemplateID)
		{
			ActiveManager.ActiveData result = null;
			if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.TryGetValue(iTemplateID, out result))
			{
			}
			return result;
		}

		// Token: 0x06018ADC RID: 101084 RVA: 0x007B51B8 File Offset: 0x007B35B8
		public ActivityInfo GetActivityInfo(string activityName)
		{
			ActivityInfo result = null;
			foreach (KeyValuePair<int, ActivityInfo> keyValuePair in this.allActivities)
			{
				ActivityInfo value = keyValuePair.Value;
				if (value != null)
				{
					if (!(value.name != activityName))
					{
						if (value.state == 1)
						{
							result = value;
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x06018ADD RID: 101085 RVA: 0x007B5230 File Offset: 0x007B3630
		public ActiveManager.ActivityData GetChildActiveData(int iActiveID)
		{
			ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(iActiveID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ActiveManager.ActiveData activeData = null;
				if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.TryGetValue(tableItem.TemplateID, out activeData))
				{
					return activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.activeItem.ID == iActiveID);
				}
			}
			return null;
		}

		// Token: 0x06018ADE RID: 101086 RVA: 0x007B52A4 File Offset: 0x007B36A4
		public int GetActiveItemValue(int iActiveID, string key, int iDefaultValue = 0)
		{
			int num = iDefaultValue;
			ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(iActiveID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ActiveManager.ActiveData activeData = null;
				if (DataManager<ActiveManager>.GetInstance().ActiveDictionary.TryGetValue(tableItem.TemplateID, out activeData))
				{
					ActiveManager.ActivityData activityData = activeData.akChildItems.Find((ActiveManager.ActivityData x) => x.activeItem.ID == iActiveID);
					if (activityData != null)
					{
						TaskPair taskPair = activityData.akActivityValues.Find((TaskPair x) => x.key == key);
						if (taskPair == null || int.TryParse(taskPair.value, out num))
						{
						}
					}
				}
			}
			if (iActiveID == 8101 && key == "vip" && DataManager<PlayerBaseData>.GetInstance().VipLevel > num)
			{
				num = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			}
			return num;
		}

		// Token: 0x06018ADF RID: 101087 RVA: 0x007B539C File Offset: 0x007B379C
		private void _OnLinkNext(List<string> nextLinks)
		{
			if (nextLinks != null && nextLinks.Count > 0)
			{
				string link = nextLinks[0];
				nextLinks.RemoveAt(0);
				this.OnClickLinkInfo(link, nextLinks, false);
			}
		}

		// Token: 0x06018AE0 RID: 101088 RVA: 0x007B53D3 File Offset: 0x007B37D3
		public static void CloseFrameByName(string name)
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame(name);
		}

		// Token: 0x06018AE1 RID: 101089 RVA: 0x007B53E0 File Offset: 0x007B37E0
		public static void OnTeamListClicked(string param)
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(30, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SystemNotify(1300031, string.Empty);
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x06018AE2 RID: 101090 RVA: 0x007B5444 File Offset: 0x007B3844
		public void OnClickLinkInfo(string link, List<string> nextLinks = null, bool isEliteDungeon = false)
		{
			try
			{
				IClientSystem currentSystem = Singleton<ClientSystemManager>.GetInstance().GetCurrentSystem();
				if (currentSystem != null && currentSystem is ClientSystemGameBattle)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("chiji_scence_jump_smithshopframe_tips"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<GuildMyMainFrame>(null))
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.GuildCloseMainFrame, null, null, null, null);
					}
					if (!string.IsNullOrEmpty(link))
					{
						if (nextLinks == null)
						{
							string[] array = link.Split(new char[]
							{
								'\r',
								'\n'
							});
							if (array != null)
							{
								List<string> list = array.ToList<string>();
								if (list != null)
								{
									list.RemoveAll((string x) => string.IsNullOrEmpty(x));
									if (list.Count > 0)
									{
										string link2 = list[0];
										list.RemoveAt(0);
										this.OnClickLinkInfo(link2, list, isEliteDungeon);
									}
								}
							}
						}
						else
						{
							Regex regex = new Regex("<type=mapid value=(\\d+)>");
							if (regex != null)
							{
								Match match = regex.Match(link);
								if (match != null)
								{
									if (match.Groups != null)
									{
										if (match.Groups.Count > 0)
										{
											if (!string.IsNullOrEmpty(match.Groups[0].Value))
											{
												if (match.Groups.Count > 1)
												{
													DungeonParser.OnClickLink(int.Parse(match.Groups[1].Value), null);
												}
											}
											else
											{
												regex = new Regex("<type=sceneid value=([0-9\\|]+)>");
												if (regex != null)
												{
													match = regex.Match(link);
													if (match != null)
													{
														if (match.Groups != null)
														{
															if (match.Groups.Count > 0)
															{
																if (!string.IsNullOrEmpty(match.Groups[0].Value))
																{
																	ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
																	if (clientSystemTown == null)
																	{
																		clientSystemTown = (Singleton<ClientSystemManager>.GetInstance().TargetSystem as ClientSystemTown);
																		if (clientSystemTown == null)
																		{
																			return;
																		}
																	}
																	if (clientSystemTown.MainPlayer != null)
																	{
																		int num = 0;
																		List<int> list2 = ListPool<int>.Get();
																		if (list2 != null)
																		{
																			if (match.Groups.Count > 1)
																			{
																				string[] array2 = match.Groups[1].Value.Split(new char[]
																				{
																					'|'
																				});
																				if (array2 != null)
																				{
																					for (int i = 0; i < array2.Length; i++)
																					{
																						if (int.TryParse(array2[i], out num))
																						{
																							list2.Add(num);
																						}
																					}
																					num = -1;
																					for (int j = 0; j < list2.Count; j++)
																					{
																						if (isEliteDungeon)
																						{
																							if (ChapterUtility.IsEliteChapterOpenBySceneId(list2[j]))
																							{
																								num = list2[j];
																								break;
																							}
																						}
																						else if (ChapterUtility.IsChapterOpenBySceneID(list2[j]))
																						{
																							num = list2[j];
																							break;
																						}
																					}
																					ListPool<int>.Release(list2);
																					if (num != -1)
																					{
																						SceneJump sceneJump = new SceneJump();
																						if (sceneJump != null)
																						{
																							sceneJump.onLinkOk = delegate()
																							{
																								this._OnLinkNext(nextLinks);
																							};
																							if (clientSystemTown.MainPlayer != null)
																							{
																								BeTownPlayerMain.CommandStopAutoMove();
																								BeTownPlayerMain.OnMoveStateChanged.AddListener(new UnityAction<BeTownPlayerMain.EMoveState, BeTownPlayerMain.EMoveState>(sceneJump.OnMoveStateChanged));
																								BeTownPlayerMain.OnAutoMoveSuccess.AddListener(new UnityAction(sceneJump.OnMoveSuccess));
																								BeTownPlayerMain.OnAutoMoveFail.AddListener(new UnityAction(sceneJump.OnAutoMoveFail));
																								clientSystemTown.MainPlayer.CommandMoveToScene(num);
																							}
																						}
																					}
																					else if (isEliteDungeon)
																					{
																						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("IntegrationChallenge_JYdungeonCannotChanllengeTip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
																					}
																					else
																					{
																						SystemNotifyManager.SysNotifyFloatingEffect("章节未解锁", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
																					}
																				}
																			}
																		}
																	}
																}
																else
																{
																	regex = new Regex("<type=sceneJump id=(\\d+) doorid=(\\d+)>");
																	if (regex != null)
																	{
																		match = regex.Match(link);
																		if (match != null)
																		{
																			if (match.Groups != null)
																			{
																				if (match.Groups.Count > 0)
																				{
																					if (!string.IsNullOrEmpty(match.Groups[0].Value))
																					{
																						ClientSystemTown clientSystemTown2 = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
																						if (clientSystemTown2 != null)
																						{
																							if (match.Groups.Count > 1)
																							{
																								int targetSceneId = int.Parse(match.Groups[1].Value);
																								if (match.Groups.Count > 2)
																								{
																									int targetDoorId = int.Parse(match.Groups[2].Value);
																									clientSystemTown2.SwitchToTargetScene(targetSceneId, targetDoorId, delegate
																									{
																										this._OnLinkNext(nextLinks);
																									});
																								}
																							}
																						}
																					}
																					else
																					{
																						regex = new Regex("<type=framename param=([\\-0-9A-Za-z|]+) value=(.+)>");
																						if (regex != null)
																						{
																							match = regex.Match(link);
																							if (match != null)
																							{
																								if (match.Groups != null)
																								{
																									if (match.Groups.Count > 0)
																									{
																										if (!string.IsNullOrEmpty(match.Groups[0].Value))
																										{
																											if (match.Groups.Count > 1)
																											{
																												string value = match.Groups[1].Value;
																												Assembly executingAssembly = Assembly.GetExecutingAssembly();
																												if (match.Groups.Count > 2)
																												{
																													Type type = executingAssembly.GetType(match.Groups[2].Value);
																													if (type != null)
																													{
																														MethodInfo method = type.GetMethod("OpenLinkFrame");
																														if (method != null)
																														{
																															Singleton<ClientSystemManager>.GetInstance().CloseFrameByType(type, true);
																															method.Invoke(null, new object[]
																															{
																																value
																															});
																														}
																													}
																												}
																											}
																										}
																										else
																										{
																											regex = new Regex("<type=framename value=(.+)>");
																											if (regex != null)
																											{
																												match = regex.Match(link);
																												if (match != null)
																												{
																													if (match.Groups != null)
																													{
																														if (match.Groups.Count > 0)
																														{
																															if (!string.IsNullOrEmpty(match.Groups[0].Value))
																															{
																																Assembly executingAssembly2 = Assembly.GetExecutingAssembly();
																																if (match.Groups.Count > 1)
																																{
																																	Type type2 = executingAssembly2.GetType(match.Groups[1].Value);
																																	if (type2 != null)
																																	{
																																		Singleton<ClientSystemManager>.GetInstance().CloseFrameByType(type2, true);
																																		if (type2 == typeof(AuctionFrame) || type2 == typeof(AuctionNewFrame))
																																		{
																																			AuctionNewFrame.OpenLinkFrame(string.Empty);
																																		}
																																		else
																																		{
																																			Singleton<ClientSystemManager>.GetInstance().OpenFrame(type2, FrameLayer.Middle, null, string.Empty);
																																		}
																																	}
																																	else
																																	{
																																		Logger.LogErrorFormat("can't find GetExecutingAssembly:{0}", new object[]
																																		{
																																			match.Groups[0].Value
																																		});
																																	}
																																}
																															}
																															else
																															{
																																regex = new Regex("<type=funtionname param=([\\-0-9A-Za-z|]+) space=([0-9a-zA-Z\\.]+) name=([a-zA-Z\\_][0-9a-zA-Z\\_]*)>");
																																if (regex != null)
																																{
																																	match = regex.Match(link);
																																	if (match != null)
																																	{
																																		if (match.Groups != null)
																																		{
																																			if (match.Success)
																																			{
																																				Assembly executingAssembly3 = Assembly.GetExecutingAssembly();
																																				if (match.Groups.Count > 2)
																																				{
																																					Type type3 = executingAssembly3.GetType(match.Groups[2].Value);
																																					if (type3 != null)
																																					{
																																						if (match.Groups.Count > 3)
																																						{
																																							MethodInfo method2 = type3.GetMethod(match.Groups[3].Value);
																																							if (method2 == null)
																																							{
																																								Logger.LogErrorFormat("can not find funtion with name = {0} assembly = {1}!!!", new object[]
																																								{
																																									match.Groups[3].Value,
																																									match.Groups[2].Value
																																								});
																																								Logger.LogErrorFormat("linkinfo error : {0}", new object[]
																																								{
																																									link
																																								});
																																							}
																																							else
																																							{
																																								try
																																								{
																																									method2.Invoke(null, new object[]
																																									{
																																										match.Groups[1].Value
																																									});
																																								}
																																								catch (Exception ex)
																																								{
																																									Logger.LogErrorFormat("linkinfo error : {0}", new object[]
																																									{
																																										link
																																									});
																																									Logger.LogErrorFormat("linkinfo error : {0}", new object[]
																																									{
																																										ex.ToString()
																																									});
																																								}
																																							}
																																						}
																																					}
																																					else
																																					{
																																						Logger.LogErrorFormat("can't find GetExecutingAssembly:{0}", new object[]
																																						{
																																							match.Groups[2].Value
																																						});
																																					}
																																				}
																																			}
																																			else
																																			{
																																				regex = new Regex("<type=npcframe npcid=(\\d+) param=([0-9A-Za-z|]*)>");
																																				if (regex != null)
																																				{
																																					match = regex.Match(link);
																																					if (match != null)
																																					{
																																						if (match.Groups != null)
																																						{
																																							if (match.Groups.Count > 0)
																																							{
																																								if (!string.IsNullOrEmpty(match.Groups[0].Value))
																																								{
																																									if (match.Groups.Count > 1)
																																									{
																																										int iNpcID = int.Parse(match.Groups[1].Value);
																																										NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcID, string.Empty, string.Empty);
																																										if (tableItem != null)
																																										{
																																											NpcParser.OnClickLink(iNpcID, delegate()
																																											{
																																												TaskNpcAccess.OnClickFunctionNpc(iNpcID, 0UL, match.Groups[2].Value);
																																											});
																																										}
																																									}
																																								}
																																								else
																																								{
																																									regex = new Regex("<type=attackcitymonster>");
																																									if (regex != null)
																																									{
																																										match = regex.Match(link);
																																										if (match != null)
																																										{
																																											if (match.Groups != null)
																																											{
																																												if (match.Groups.Count > 0)
																																												{
																																													if (!string.IsNullOrEmpty(match.Groups[0].Value))
																																													{
																																														DataManager<AttackCityMonsterDataManager>.GetInstance().EnterFindPathProcessByActivityDuplication();
																																													}
																																												}
																																											}
																																										}
																																									}
																																								}
																																							}
																																						}
																																					}
																																				}
																																			}
																																		}
																																	}
																																}
																															}
																														}
																													}
																												}
																											}
																										}
																									}
																								}
																							}
																						}
																					}
																				}
																			}
																		}
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			catch (Exception ex2)
			{
				Logger.LogErrorFormat("GameClient.ActiveManager.OnClickLinkInfo,catch Exception:Exception = {0}", new object[]
				{
					ex2.ToString()
				});
				string text = string.Empty;
				if (nextLinks != null)
				{
					foreach (string str in nextLinks)
					{
						text += str;
						text += ",";
					}
				}
				Logger.LogErrorFormat("GameClient.ActiveManager.OnClickLinkInfo,catch Exception:Params = {0}|{1}|{2}", new object[]
				{
					link,
					text,
					isEliteDungeon
				});
			}
		}

		// Token: 0x06018AE3 RID: 101091 RVA: 0x007B610C File Offset: 0x007B450C
		public bool CheckCondition(ActiveManager.ActivityData childData)
		{
			if (string.IsNullOrEmpty(childData.activeItem.Param0))
			{
				Logger.LogErrorFormat("CheckCondition Error!", new object[0]);
				return false;
			}
			string[] array = childData.activeItem.Param0.Split(new char[]
			{
				','
			});
			for (int i = 0; i < array.Length; i++)
			{
				string[] array2 = array[i].Split(new char[]
				{
					'_'
				});
				int num = 0;
				int num2 = 0;
				if (array2.Length != 2 || !int.TryParse(array2[0], out num) || !int.TryParse(array2[1], out num2))
				{
					Logger.LogErrorFormat("CheckCondition Error!", new object[0]);
				}
				else
				{
					int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true);
					if (num2 > 0 && ownedItemCount < num2)
					{
						ItemComeLink.OnLink(num, num2 - ownedItemCount, true, null, true, false, false, null, string.Empty);
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06018AE4 RID: 101092 RVA: 0x007B6200 File Offset: 0x007B4600
		public bool _CheckCanJumpGo(IList<int> datas, bool bNeedMsg)
		{
			if (datas == null || datas.Count != 2)
			{
				return true;
			}
			if (datas[0] < 0)
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(datas[1], string.Empty, string.Empty);
				if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
				{
					if (bNeedMsg)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("active_jump_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					return false;
				}
				return true;
			}
			else
			{
				if (datas[0] != 1)
				{
					return true;
				}
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level < datas[1])
				{
					if (bNeedMsg)
					{
						SystemNotifyManager.SysNotifyTextAnimation(TR.Value("active_jump_need_lv", datas[1]), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
					return false;
				}
				return true;
			}
		}

		// Token: 0x06018AE5 RID: 101093 RVA: 0x007B62D4 File Offset: 0x007B46D4
		public void OnClickActivity(ActiveManager.ActiveData activityData, OnClickActive onClick, ActiveManager.ActivityData childData)
		{
			if (activityData == null || onClick == null)
			{
				Logger.LogError("ActiveData is null or missing script OnClickActive!");
				return;
			}
			if (onClick.m_eOnClickActiveType <= OnClickActive.OnClickActiveType.OCAT_INVALID || onClick.m_eOnClickActiveType >= OnClickActive.OnClickActiveType.OCAT_COUNT)
			{
				Logger.LogError("onClick.m_eOnClickActiveType is Invalid!");
				return;
			}
			if (onClick.m_eNodeType == OnClickActive.NodeType.NT_ROOT)
			{
				if (onClick.m_eOnClickActiveType == OnClickActive.OnClickActiveType.OCAT_GO)
				{
					Regex regex = new Regex("<type=(\\w+) id=(\\d+)>");
					Match match = regex.Match(activityData.mainItem.FunctionParse);
					if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value) && match.Groups[1].Value == "dungen")
					{
						int iDungenID = 0;
						if (int.TryParse(match.Groups[2].Value, out iDungenID))
						{
							DungeonParser.OnClickLink(iDungenID, null);
						}
					}
				}
				else if (onClick.m_eOnClickActiveType != OnClickActive.OnClickActiveType.OCAT_ACQUIRED)
				{
					if (onClick.m_eOnClickActiveType == OnClickActive.OnClickActiveType.OCAT_EVENT)
					{
						if (onClick.m_eEventType == OnClickActive.EventType.EventType_OpenSignFrame)
						{
							if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<SignFrame>(null))
							{
								Singleton<ClientSystemManager>.GetInstance().CloseFrame<SignFrame>(null, false);
							}
							Singleton<ClientSystemManager>.GetInstance().OpenFrame<SignFrame>(FrameLayer.Middle, null, string.Empty);
						}
						else if (onClick.m_eEventType != OnClickActive.EventType.EventType_OpenSeventDayAwardFrame)
						{
							if (onClick.m_eEventType == OnClickActive.EventType.EventType_PerfectAcquireAward)
							{
								ActiveAwardRequiredFrame.Open(new ActiveAwardRequiredFrameData
								{
									activityData = childData,
									eEventType = onClick.m_eEventType
								});
							}
							else if (onClick.m_eEventType == OnClickActive.EventType.EventType_NormalAcquireAward)
							{
								ActiveAwardRequiredFrame.Open(new ActiveAwardRequiredFrameData
								{
									activityData = childData,
									eEventType = onClick.m_eEventType
								});
							}
							else if (onClick.m_eEventType == OnClickActive.EventType.EventType_Pl_Normal_AcquireAward)
							{
								if (childData.status == 2)
								{
									int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(childData.ID, "lc", 0);
									int itemId = 0;
									SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(232, string.Empty, string.Empty);
									if (tableItem != null)
									{
										itemId = tableItem.Value;
									}
									int minValue = int.MinValue;
									PlAcquireConfirmFrame.Open(new PlAcquireConfirmFrameData
									{
										count = activeItemValue,
										itemId = itemId,
										iValue = minValue,
										activityData = childData,
										bPerfect = false
									});
								}
							}
							else if (onClick.m_eEventType == OnClickActive.EventType.EventType_Pl_Perfect_AcquireAward)
							{
								if (childData.status == 2)
								{
									int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(childData.ID, "hc", 0);
									int itemId2 = 0;
									SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(233, string.Empty, string.Empty);
									if (tableItem2 != null)
									{
										itemId2 = tableItem2.Value;
									}
									int iValue = -2147418112;
									PlAcquireConfirmFrame.Open(new PlAcquireConfirmFrameData
									{
										count = activeItemValue2,
										itemId = itemId2,
										iValue = iValue,
										activityData = childData,
										bPerfect = true
									});
								}
							}
							else if (onClick.m_eEventType == OnClickActive.EventType.EventType_Diamond_BeVip)
							{
								ActiveChargeFrame.CloseMe();
								VipFrame vipFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, null, string.Empty) as VipFrame;
								if (vipFrame != null)
								{
									vipFrame.OpenPayTab();
								}
							}
						}
					}
				}
			}
			else if (onClick.m_eNodeType == OnClickActive.NodeType.NT_CHILD && childData != null && onClick.m_eBindStatus == (OnClickActive.BindStatus)childData.status)
			{
				if (onClick.m_eBindStatus == OnClickActive.BindStatus.BS_FINISH)
				{
					if (onClick.m_eAttachParamsType == OnClickActive.AttachParamsType.APT_NONE)
					{
						this.SendSubmitActivity(childData.ID, 0U);
					}
					else if (onClick.m_eAttachParamsType == OnClickActive.AttachParamsType.APT_CHECK_CONDITION)
					{
						if (this.CheckCondition(childData))
						{
							this.SendSubmitActivity(childData.ID, 0U);
						}
					}
					else
					{
						this.SendSubmitActivity(childData.ID, 0U);
					}
				}
				else if ((onClick.m_eBindStatus == OnClickActive.BindStatus.BS_UNFINISH || onClick.m_eBindStatus == OnClickActive.BindStatus.BS_INIT) && this._CheckCanJumpGo(childData.activeItem.LinkLimit, true))
				{
					this.OnClickLinkInfo(childData.activeItem.LinkInfo, null, false);
				}
			}
		}

		// Token: 0x06018AE6 RID: 101094 RVA: 0x007B66DC File Offset: 0x007B4ADC
		public void SignalRedPoint(ActiveManager.ActivityData data)
		{
			if (!this.m_akRedPointMap.ContainsKey(data.activeItem.ID))
			{
				this.m_akRedPointMap.Add(data.activeItem.ID, 0);
				if (this.onActivityUpdate != null)
				{
					this.onActivityUpdate(data, ActiveManager.ActivityUpdateType.AUT_RED_CHANGED);
				}
			}
		}

		// Token: 0x06018AE7 RID: 101095 RVA: 0x007B6734 File Offset: 0x007B4B34
		public bool CheckHasFinishedChildItem(ActiveManager.ActiveData activityData, List<string> keys)
		{
			if (activityData != null)
			{
				for (int i = 0; i < activityData.akChildItems.Count; i++)
				{
					if (keys != null && keys.Contains(activityData.akChildItems[i].activeItem.PrefabKey))
					{
						if (this.CheckChildRedPass(activityData.akChildItems[i]))
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x06018AE8 RID: 101096 RVA: 0x007B67AC File Offset: 0x007B4BAC
		public bool CheckChildRedPass(ActiveManager.ActivityData data)
		{
			if (data == null)
			{
				return false;
			}
			if (data.activeItem.DoesWorkToRedPoint != 1)
			{
				return false;
			}
			if (data.status != 2)
			{
				return false;
			}
			if (data.activeItem.IsWorkWithFullLevel == 0 && DataManager<PlayerBaseData>.GetInstance().IsLevelFull)
			{
				return false;
			}
			if (data.activeItem.RedPointWorkMode == 0)
			{
				return true;
			}
			if (data.activeItem.RedPointWorkMode == 1)
			{
				if (this.m_akRedPointMap.ContainsKey(data.activeItem.ID))
				{
					return false;
				}
				if (!this.HasRedPointFirstShowedToday(data.activeItem.TemplateID))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06018AE9 RID: 101097 RVA: 0x007B685C File Offset: 0x007B4C5C
		public bool HasRedPointFirstShowedToday(int activityId)
		{
			int tempTimeStamp = this.GetTempTimeStamp(activityId);
			int refreshTimeStamp = this.GetRefreshTimeStamp();
			return tempTimeStamp >= refreshTimeStamp;
		}

		// Token: 0x06018AEA RID: 101098 RVA: 0x007B6884 File Offset: 0x007B4C84
		public void SaveCurrTimeStamp(int activityId)
		{
			int serverTime = (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.LimitTimeActivityTabRedPoint, serverTime, new object[]
			{
				string.Format("activityId{0}", activityId)
			});
		}

		// Token: 0x06018AEB RID: 101099 RVA: 0x007B68C2 File Offset: 0x007B4CC2
		private int GetTempTimeStamp(int activityId)
		{
			return Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.LimitTimeActivityTabRedPoint, new object[]
			{
				string.Format("activityId{0}", activityId)
			});
		}

		// Token: 0x06018AEC RID: 101100 RVA: 0x007B68EC File Offset: 0x007B4CEC
		private int GetRefreshTimeStamp()
		{
			int currTimeHour = this.GetCurrTimeHour();
			DateTime currDateTime = this.GetCurrDateTime();
			DateTime time;
			if (this.iRedPointUpdateHour >= currTimeHour)
			{
				time = Function.GetYesterdayGivenHourTime(this.iRedPointUpdateHour);
			}
			else
			{
				time = Function.GetTodayGivenHourTime(this.iRedPointUpdateHour);
			}
			return Convert.ToInt32(Function.ConvertDateTimeInt(time));
		}

		// Token: 0x06018AED RID: 101101 RVA: 0x007B6940 File Offset: 0x007B4D40
		private int GetCurrTimeHour()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime).Hour;
		}

		// Token: 0x06018AEE RID: 101102 RVA: 0x007B6968 File Offset: 0x007B4D68
		private DateTime GetCurrDateTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime);
		}

		// Token: 0x06018AEF RID: 101103 RVA: 0x007B6988 File Offset: 0x007B4D88
		public List<AwardItemData> GetActiveAwards(int iActiveId)
		{
			ActiveTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveTable>(iActiveId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			List<AwardItemData> list = new List<AwardItemData>();
			Regex regex = new Regex("<KeyNum=(\\w+) KeyId=(\\w+) KeySize=(\\w+)>", RegexOptions.Singleline);
			bool flag = false;
			if (!string.IsNullOrEmpty(tableItem.DanymicAwards))
			{
				flag = true;
				Match match = regex.Match(tableItem.DanymicAwards);
				if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value))
				{
					int activeItemValue = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(tableItem.ID, match.Groups[3].Value, 0);
					for (int i = 0; i < activeItemValue; i++)
					{
						int activeItemValue2 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(tableItem.ID, match.Groups[2].Value + (i + 1).ToString(), 0);
						if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(activeItemValue2, string.Empty, string.Empty) != null)
						{
							int activeItemValue3 = DataManager<ActiveManager>.GetInstance().GetActiveItemValue(tableItem.ID, match.Groups[1].Value + (i + 1).ToString(), 0);
							if (activeItemValue3 > 0)
							{
								list.Add(new AwardItemData
								{
									ID = activeItemValue2,
									Num = activeItemValue3
								});
							}
						}
					}
				}
				else
				{
					Logger.LogErrorFormat("MATCH ERROR WITH DanymicAwards ActiveID is {0}", new object[]
					{
						tableItem.ID
					});
				}
			}
			if (!flag && !string.IsNullOrEmpty(tableItem.Awards))
			{
				string[] array = tableItem.Awards.Split(new char[]
				{
					','
				});
				for (int j = 0; j < array.Length; j++)
				{
					if (!string.IsNullOrEmpty(array[j]))
					{
						string[] array2 = array[j].Split(new char[]
						{
							'_'
						});
						if (array2.Length == 2)
						{
							int id = int.Parse(array2[0]);
							int num = int.Parse(array2[1]);
							ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
							if (tableItem2 != null && num > 0)
							{
								list.Add(new AwardItemData
								{
									ID = id,
									Num = num
								});
							}
						}
						else if (array2.Length == 4)
						{
							int id2 = int.Parse(array2[0]);
							int num2 = int.Parse(array2[1]);
							int equipType = int.Parse(array2[2]);
							int strengthenLevel = int.Parse(array2[3]);
							ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id2, string.Empty, string.Empty);
							if (tableItem3 != null && num2 > 0)
							{
								list.Add(new AwardItemData
								{
									ID = id2,
									Num = num2,
									EquipType = equipType,
									StrengthenLevel = strengthenLevel
								});
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x04011C66 RID: 72806
		public ActiveManager.OnActivityUpdate onActivityUpdate;

		// Token: 0x04011C67 RID: 72807
		public ActiveManager.OnAddMainActivity onAddMainActivity;

		// Token: 0x04011C68 RID: 72808
		public ActiveManager.OnUpdateMainActivity onUpdateMainActivity;

		// Token: 0x04011C69 RID: 72809
		public ActiveManager.OnRemoveMainActivity onRemoveMainActivity;

		// Token: 0x04011C6A RID: 72810
		private bool bInited;

		// Token: 0x04011C6B RID: 72811
		public static int[] activityId = new int[]
		{
			8100,
			8200
		};

		// Token: 0x04011C6C RID: 72812
		private bool welfareTABEnergyRedPointFlag;

		// Token: 0x04011C6D RID: 72813
		private bool welfareTABRewardRedPointFlag;

		// Token: 0x04011C6E RID: 72814
		private Dictionary<int, ActiveManager.ActiveData> m_akActiveDictionary = new Dictionary<int, ActiveManager.ActiveData>();

		// Token: 0x04011C6F RID: 72815
		public Dictionary<int, List<ActiveTable>> m_akTemplate2idList = new Dictionary<int, List<ActiveTable>>();

		// Token: 0x04011C70 RID: 72816
		private Dictionary<int, List<ActiveMainTable>> m_akType2Templates = new Dictionary<int, List<ActiveMainTable>>();

		// Token: 0x04011C71 RID: 72817
		private int iBudoActive;

		// Token: 0x04011C72 RID: 72818
		public ActiveManager.OnSevenDayTimeChanged onSevenDayTimeChanged;

		// Token: 0x04011C73 RID: 72819
		private Dictionary<int, ActivityInfo> m_akActivitiesDic = new Dictionary<int, ActivityInfo>();

		// Token: 0x04011C74 RID: 72820
		private Queue<ActiveManager.ActiveFrameConfig> m_akActiveFrameConfigs = new Queue<ActiveManager.ActiveFrameConfig>();

		// Token: 0x04011C75 RID: 72821
		private int iRedPointUpdateHour = 6;

		// Token: 0x04011C76 RID: 72822
		private Dictionary<int, int> m_akRedPointMap = new Dictionary<int, int>();

		// Token: 0x02004537 RID: 17719
		public enum ActivityUpdateType
		{
			// Token: 0x04011C7A RID: 72826
			AUT_CREATE,
			// Token: 0x04011C7B RID: 72827
			AUT_KEY_CHANGED,
			// Token: 0x04011C7C RID: 72828
			AUT_STATUS_CHANGED,
			// Token: 0x04011C7D RID: 72829
			AUT_RED_CHANGED
		}

		// Token: 0x02004538 RID: 17720
		// (Invoke) Token: 0x06018AF4 RID: 101108
		public delegate void OnActivityUpdate(ActiveManager.ActivityData data, ActiveManager.ActivityUpdateType EActivityUpdateType);

		// Token: 0x02004539 RID: 17721
		// (Invoke) Token: 0x06018AF8 RID: 101112
		public delegate void OnAddMainActivity(ActiveManager.ActiveData data);

		// Token: 0x0200453A RID: 17722
		// (Invoke) Token: 0x06018AFC RID: 101116
		public delegate void OnUpdateMainActivity(ActiveManager.ActiveData data);

		// Token: 0x0200453B RID: 17723
		// (Invoke) Token: 0x06018B00 RID: 101120
		public delegate void OnRemoveMainActivity(ActiveManager.ActiveData data);

		// Token: 0x0200453C RID: 17724
		public class VarBinder
		{
			// Token: 0x06018B04 RID: 101124 RVA: 0x007B6CEE File Offset: 0x007B50EE
			public bool AnalysisOK()
			{
				return this.m_bResult;
			}

			// Token: 0x06018B05 RID: 101125 RVA: 0x007B6CF8 File Offset: 0x007B50F8
			public bool Analysis()
			{
				if (this.m_bAnalysis)
				{
					return this.m_bResult;
				}
				this.m_bAnalysis = true;
				this.m_bResult = false;
				try
				{
					IEnumerator enumerator = ActiveManager.VarBinder.ms_condition_match.Matches(this.analyString).GetEnumerator();
					try
					{
						while (enumerator.MoveNext())
						{
							object obj = enumerator.Current;
							Match match = (Match)obj;
							if (match != null && !string.IsNullOrEmpty(match.Groups[0].Value))
							{
								this.m_kKey = match.Groups[1].Value;
								this.m_iDefaultValue = int.Parse(match.Groups[2].Value);
								this.m_eGameObjectType = (ActiveManager.VarBinder.GameObjectType)int.Parse(match.Groups[3].Value);
								this.m_eCompareType = (ActiveManager.VarBinder.CompareType)int.Parse(match.Groups[4].Value);
								this.m_iCompareValue = int.Parse(match.Groups[5].Value);
								this.m_eOpType = (ActiveManager.VarBinder.OpType)int.Parse(match.Groups[6].Value);
							}
						}
					}
					finally
					{
						IDisposable disposable;
						if ((disposable = (enumerator as IDisposable)) != null)
						{
							disposable.Dispose();
						}
					}
				}
				catch (Exception ex)
				{
					Logger.LogError(ex.ToString());
					return false;
				}
				this.m_bResult = true;
				return true;
			}

			// Token: 0x04011C7E RID: 72830
			public static Regex ms_condition_match = new Regex("<varName=(\\w+) default=(\\d+) do=<got=(\\d+) ct=(\\d+) cpv=(\\w+) op=(\\d+)>>", RegexOptions.Singleline);

			// Token: 0x04011C7F RID: 72831
			public string analyString = "<varName=nice default=100 do=<got=1 ct=1 cpv=10 op=0>>";

			// Token: 0x04011C80 RID: 72832
			public string m_kKey;

			// Token: 0x04011C81 RID: 72833
			public int m_iDefaultValue;

			// Token: 0x04011C82 RID: 72834
			public ActiveManager.VarBinder.GameObjectType m_eGameObjectType;

			// Token: 0x04011C83 RID: 72835
			public ActiveManager.VarBinder.CompareType m_eCompareType;

			// Token: 0x04011C84 RID: 72836
			public int m_iCompareValue;

			// Token: 0x04011C85 RID: 72837
			public ActiveManager.VarBinder.OpType m_eOpType;

			// Token: 0x04011C86 RID: 72838
			private bool m_bResult;

			// Token: 0x04011C87 RID: 72839
			private bool m_bAnalysis;

			// Token: 0x0200453D RID: 17725
			public enum CompareType
			{
				// Token: 0x04011C89 RID: 72841
				CT_GREAT,
				// Token: 0x04011C8A RID: 72842
				CT_LESS,
				// Token: 0x04011C8B RID: 72843
				CT_EQUAL,
				// Token: 0x04011C8C RID: 72844
				CT_GREAT_EQUAL,
				// Token: 0x04011C8D RID: 72845
				CT_LESS_EQUAL
			}

			// Token: 0x0200453E RID: 17726
			public enum GameObjectType
			{
				// Token: 0x04011C8F RID: 72847
				GOT_TRANSFORM,
				// Token: 0x04011C90 RID: 72848
				GOT_TEXT,
				// Token: 0x04011C91 RID: 72849
				GOT_IMAGE,
				// Token: 0x04011C92 RID: 72850
				GOT_BUTTON
			}

			// Token: 0x0200453F RID: 17727
			public enum OpType
			{
				// Token: 0x04011C94 RID: 72852
				OT_SHOW,
				// Token: 0x04011C95 RID: 72853
				OT_GRAY,
				// Token: 0x04011C96 RID: 72854
				OT_ENABLE,
				// Token: 0x04011C97 RID: 72855
				OT_TEXT,
				// Token: 0x04011C98 RID: 72856
				OT_IMAGE,
				// Token: 0x04011C99 RID: 72857
				OT_COLOR
			}
		}

		// Token: 0x02004540 RID: 17728
		public class ControlData
		{
			// Token: 0x06018B07 RID: 101127 RVA: 0x007B6E9F File Offset: 0x007B529F
			public ControlData()
			{
				this.valueDic = null;
				this.name = null;
				this.eType = ActiveManager.ControlData.ControlDataType.CDT_INVALID;
				this.shows = null;
				this.statusValues = null;
			}

			// Token: 0x1700201D RID: 8221
			// (get) Token: 0x06018B08 RID: 101128 RVA: 0x007B6ECA File Offset: 0x007B52CA
			public ActiveManager.ControlData.ControlDataType Type
			{
				get
				{
					return this.eType;
				}
			}

			// Token: 0x1700201E RID: 8222
			// (get) Token: 0x06018B09 RID: 101129 RVA: 0x007B6ED2 File Offset: 0x007B52D2
			public string Name
			{
				get
				{
					return this.name;
				}
			}

			// Token: 0x06018B0A RID: 101130 RVA: 0x007B6EDA File Offset: 0x007B52DA
			public bool NeedShow(int iStatus)
			{
				return this.shows != null && this.shows.Contains(iStatus);
			}

			// Token: 0x06018B0B RID: 101131 RVA: 0x007B6EF8 File Offset: 0x007B52F8
			public ActiveManager.ControlData.StatusValue GetStatusValue(int iStatus)
			{
				if (this.statusValues != null)
				{
					return this.statusValues.Find((ActiveManager.ControlData.StatusValue x) => x.iStatus == iStatus);
				}
				return null;
			}

			// Token: 0x06018B0C RID: 101132 RVA: 0x007B6F38 File Offset: 0x007B5338
			public void Analysis(string name, string type, string show, string statusvalue)
			{
				this.name = name;
				this.eType = ActiveManager.ControlData.ControlDataType.CDT_INVALID;
				if (type != null)
				{
					if (!(type == "Text"))
					{
						if (!(type == "Button"))
						{
							if (!(type == "Image"))
							{
								if (type == "GameObject")
								{
									this.eType = ActiveManager.ControlData.ControlDataType.CDT_GAMEOBJECT;
								}
							}
							else
							{
								this.eType = ActiveManager.ControlData.ControlDataType.CDT_IMAGE;
							}
						}
						else
						{
							this.eType = ActiveManager.ControlData.ControlDataType.CDT_BUTTON;
						}
					}
					else
					{
						this.eType = ActiveManager.ControlData.ControlDataType.CDT_TEXT;
					}
				}
				this.shows = new List<int>();
				string[] array = show.Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					int item = 0;
					if (!string.IsNullOrEmpty(array[i]) && int.TryParse(array[i], out item))
					{
						this.shows.Add(item);
					}
				}
				this.statusValues = new List<ActiveManager.ControlData.StatusValue>();
				if (!string.IsNullOrEmpty(statusvalue))
				{
					string[] array2 = statusvalue.Split(new char[]
					{
						'|'
					});
					for (int j = 0; j < array2.Length; j++)
					{
						if (!string.IsNullOrEmpty(array2[j]))
						{
							Match match = ActiveManager.ControlData.ms_kStatusValue.Match(array2[j]);
							int iStatus = 0;
							if (!string.IsNullOrEmpty(match.Groups[0].Value) && int.TryParse(match.Groups[1].Value, out iStatus))
							{
								ActiveManager.ControlData.StatusValue statusValue = new ActiveManager.ControlData.StatusValue();
								statusValue.iStatus = iStatus;
								statusValue.value = match.Groups[2].Value;
								this.statusValues.Add(statusValue);
							}
						}
					}
				}
			}

			// Token: 0x04011C9A RID: 72858
			private static Regex ms_kStatusValue = new Regex("<Status=(\\d+) Value=(.+)>", RegexOptions.Singleline);

			// Token: 0x04011C9B RID: 72859
			private Dictionary<int, string> valueDic;

			// Token: 0x04011C9C RID: 72860
			private string name;

			// Token: 0x04011C9D RID: 72861
			private ActiveManager.ControlData.ControlDataType eType;

			// Token: 0x04011C9E RID: 72862
			private List<int> shows;

			// Token: 0x04011C9F RID: 72863
			private List<ActiveManager.ControlData.StatusValue> statusValues;

			// Token: 0x02004541 RID: 17729
			public enum ControlDataType
			{
				// Token: 0x04011CA1 RID: 72865
				CDT_INVALID = -1,
				// Token: 0x04011CA2 RID: 72866
				CDT_IMAGE,
				// Token: 0x04011CA3 RID: 72867
				CDT_BUTTON,
				// Token: 0x04011CA4 RID: 72868
				CDT_TEXT,
				// Token: 0x04011CA5 RID: 72869
				CDT_GAMEOBJECT,
				// Token: 0x04011CA6 RID: 72870
				CDT_COUNT
			}

			// Token: 0x02004542 RID: 17730
			public class StatusValue
			{
				// Token: 0x04011CA7 RID: 72871
				public int iStatus;

				// Token: 0x04011CA8 RID: 72872
				public string value;
			}
		}

		// Token: 0x02004543 RID: 17731
		public class ActivityPrefab
		{
			// Token: 0x04011CA9 RID: 72873
			public string parent;

			// Token: 0x04011CAA RID: 72874
			public string local;

			// Token: 0x04011CAB RID: 72875
			public string key;
		}

		// Token: 0x02004544 RID: 17732
		public class ActivityData
		{
			// Token: 0x06018B10 RID: 101136 RVA: 0x007B7137 File Offset: 0x007B5537
			public ActivityData()
			{
				this.ID = 0;
				this.activeItem = null;
				this.akActivityValues = new List<TaskPair>();
				this.akActivityValues.Clear();
				this.status = 0;
			}

			// Token: 0x06018B11 RID: 101137 RVA: 0x007B716C File Offset: 0x007B556C
			public Dictionary<uint, int> GetAwards()
			{
				Dictionary<uint, int> dictionary = new Dictionary<uint, int>();
				if (this.activeItem.Awards.Length > 1)
				{
					string[] array = this.activeItem.Awards.Split(new char[]
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
								int key = int.Parse(array2[0]);
								int value = int.Parse(array2[1]);
								dictionary.Add((uint)key, value);
							}
						}
					}
				}
				return dictionary;
			}

			// Token: 0x04011CAC RID: 72876
			public int ID;

			// Token: 0x04011CAD RID: 72877
			public ActiveTable activeItem;

			// Token: 0x04011CAE RID: 72878
			public List<TaskPair> akActivityValues;

			// Token: 0x04011CAF RID: 72879
			public byte status;
		}

		// Token: 0x02004545 RID: 17733
		public class ActiveData
		{
			// Token: 0x06018B12 RID: 101138 RVA: 0x007B7210 File Offset: 0x007B5610
			public ActiveData()
			{
				this.iActiveID = 0;
				this.mainItem = null;
				this.iActiveSortID = 0;
				this.akChildItems = new List<ActiveManager.ActivityData>();
				this.akChildItems.Clear();
				this.mainInfo = null;
				this.mainKeyValue = new List<ActiveManager.ActiveMainKeyValue>();
				this.mainKeyValue.Clear();
				this.updateMainKeys = new List<ActiveManager.ActiveMainUpdateKey>();
				this.updateMainKeys.Clear();
				this.values = null;
				this.prefabs = null;
			}

			// Token: 0x04011CB0 RID: 72880
			public int iActiveID;

			// Token: 0x04011CB1 RID: 72881
			public ActiveMainTable mainItem;

			// Token: 0x04011CB2 RID: 72882
			public int iActiveSortID;

			// Token: 0x04011CB3 RID: 72883
			public List<ActiveManager.ActivityData> akChildItems;

			// Token: 0x04011CB4 RID: 72884
			public ActivityInfo mainInfo;

			// Token: 0x04011CB5 RID: 72885
			public List<ActiveManager.ActiveMainKeyValue> mainKeyValue;

			// Token: 0x04011CB6 RID: 72886
			public List<ActiveManager.ActiveMainUpdateKey> updateMainKeys;

			// Token: 0x04011CB7 RID: 72887
			public Dictionary<string, List<ActiveManager.ControlData>> values;

			// Token: 0x04011CB8 RID: 72888
			public Dictionary<string, ActiveManager.ActivityPrefab> prefabs;
		}

		// Token: 0x02004546 RID: 17734
		public class ActiveMainKeyValue
		{
			// Token: 0x04011CB9 RID: 72889
			public string key;

			// Token: 0x04011CBA RID: 72890
			public string value;
		}

		// Token: 0x02004547 RID: 17735
		public class ActiveMainUpdateKey
		{
			// Token: 0x04011CBB RID: 72891
			public static Regex s_regex = new Regex("<key=(\\w+) default=(\\d+) value=(.+)>", RegexOptions.Singleline);

			// Token: 0x04011CBC RID: 72892
			public string key;

			// Token: 0x04011CBD RID: 72893
			public int iDefValue;

			// Token: 0x04011CBE RID: 72894
			public string content;

			// Token: 0x04011CBF RID: 72895
			public string value = "0";

			// Token: 0x04011CC0 RID: 72896
			public double fRecievedTime;
		}

		// Token: 0x02004548 RID: 17736
		// (Invoke) Token: 0x06018B17 RID: 101143
		public delegate void OnSevenDayTimeChanged(uint time1, uint time2, uint time3, double recvTime);

		// Token: 0x02004549 RID: 17737
		public class ActiveFrameConfig
		{
			// Token: 0x04011CC1 RID: 72897
			public int iConfigID;

			// Token: 0x04011CC2 RID: 72898
			public string prefabpath;

			// Token: 0x04011CC3 RID: 72899
			public List<ActiveMainTable> templates = new List<ActiveMainTable>();

			// Token: 0x04011CC4 RID: 72900
			public int iLinkTemplateID;
		}

		// Token: 0x0200454A RID: 17738
		private enum ActiveIDType
		{
			// Token: 0x04011CC6 RID: 72902
			AIDT_MinotaurParadise = 1000,
			// Token: 0x04011CC7 RID: 72903
			AIDT_Nanbuxigu
		}
	}
}
