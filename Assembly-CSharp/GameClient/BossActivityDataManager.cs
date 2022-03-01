using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011C4 RID: 4548
	public class BossActivityDataManager
	{
		// Token: 0x0600AED5 RID: 44757 RVA: 0x00262F42 File Offset: 0x00261342
		public void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
		}

		// Token: 0x0600AED6 RID: 44758 RVA: 0x00262F50 File Offset: 0x00261350
		public void Clear()
		{
			this._UnBindNetMsg();
			if (this.ActivityDic != null)
			{
				this.ActivityDic.Clear();
			}
			if (this.BossExchangeID != null)
			{
				this.BossExchangeID.Clear();
			}
			if (this.ChildActivityStatus != null)
			{
				this.ChildActivityStatus.Clear();
			}
			if (this.ChildActivityCount != null)
			{
				this.ChildActivityCount.Clear();
			}
			this.CanUpdateTime = false;
			if (this.killBossDataList != null)
			{
				this.killBossDataList.Clear();
			}
			this.BossExchangeIsOpen = false;
			this.BossKillIsOpen = false;
			this.BossActivityBtIconPath = string.Empty;
			this.BossActivityBtIconName = string.Empty;
		}

		// Token: 0x0600AED7 RID: 44759 RVA: 0x00262FFC File Offset: 0x002613FC
		public bool IsHasTaskFinished()
		{
			foreach (int num in this.ChildActivityStatus.Values)
			{
				if (num == 2)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AED8 RID: 44760 RVA: 0x00263068 File Offset: 0x00261468
		private void initTaskIDList()
		{
			this.BossExchangeID.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActiveTable activeTable = keyValuePair.Value as ActiveTable;
				if (activeTable.TemplateID == this.ExchangeActivityID)
				{
					this.BossExchangeID.Add(activeTable.ID);
				}
			}
		}

		// Token: 0x0600AED9 RID: 44761 RVA: 0x002630DC File Offset: 0x002614DC
		private void _BindNetMsg()
		{
			NetProcess.AddMsgHandler(501136U, new Action<MsgDATA>(this.OnRecvWorldSyncClientActivitiesNormal));
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			NetProcess.AddMsgHandler(501128U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskVar));
			NetProcess.AddMsgHandler(607405U, new Action<MsgDATA>(this.OnRecvActivityMonsterInfo));
			NetProcess.AddMsgHandler(602901U, new Action<MsgDATA>(this.OnRecvWorldNotifyClientActivity));
		}

		// Token: 0x0600AEDA RID: 44762 RVA: 0x00263158 File Offset: 0x00261558
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(501136U, new Action<MsgDATA>(this.OnRecvWorldSyncClientActivitiesNormal));
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskStatus));
			NetProcess.RemoveMsgHandler(501128U, new Action<MsgDATA>(this.OnRecvSceneNotifyActiveTaskVar));
			NetProcess.RemoveMsgHandler(607405U, new Action<MsgDATA>(this.OnRecvActivityMonsterInfo));
			NetProcess.RemoveMsgHandler(602901U, new Action<MsgDATA>(this.OnRecvWorldNotifyClientActivity));
		}

		// Token: 0x0600AEDB RID: 44763 RVA: 0x002631D4 File Offset: 0x002615D4
		public string GetActivityTime(int id)
		{
			if (this.ActivityDic == null || !this.ActivityDic.ContainsKey(id))
			{
				return string.Empty;
			}
			return this.GetDate((int)this.ActivityDic[id].startTime, (int)this.ActivityDic[id].dueTime);
		}

		// Token: 0x0600AEDC RID: 44764 RVA: 0x0026322C File Offset: 0x0026162C
		private bool TimeEffect(int time)
		{
			return this.TimeSpanToDateTime((long)time).ToString().Split(new char[]
			{
				' '
			})[0].Split(new char[]
			{
				'/'
			}).Length > 2;
		}

		// Token: 0x0600AEDD RID: 44765 RVA: 0x0026327C File Offset: 0x0026167C
		public string GetDate(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("yyyy年MM月dd日") + "到" + dateTime3.ToString("yyyy年MM月dd日");
		}

		// Token: 0x0600AEDE RID: 44766 RVA: 0x002632D8 File Offset: 0x002616D8
		public string GetDateTime(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("yyyy年MM月dd日HH:mm") + "到" + dateTime3.ToString("yyyy年MM月dd日HH:mm");
		}

		// Token: 0x0600AEDF RID: 44767 RVA: 0x00263334 File Offset: 0x00261734
		public string GetTime(int startTime, int endTime)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
			DateTime dateTime2 = dateTime.AddSeconds((double)startTime);
			DateTime dateTime3 = dateTime.AddSeconds((double)endTime);
			return dateTime2.ToString("HH:mm") + "-" + dateTime3.ToString("HH:mm");
		}

		// Token: 0x0600AEE0 RID: 44768 RVA: 0x00263390 File Offset: 0x00261790
		public DateTime TimeSpanToDateTime(long span)
		{
			DateTime minValue = DateTime.MinValue;
			return TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0)).AddSeconds((double)span);
		}

		// Token: 0x0600AEE1 RID: 44769 RVA: 0x002633CC File Offset: 0x002617CC
		public void SendBossKillData()
		{
			WorldActivityMonsterReq worldActivityMonsterReq = new WorldActivityMonsterReq();
			if (this.KillBossActivityID == 0)
			{
				return;
			}
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(this.KillBossActivityID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			string[] array = tableItem.BossId.Split(new char[]
			{
				','
			});
			uint[] array2 = new uint[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				uint num = 0U;
				uint.TryParse(array[i], out num);
				array2[i] = num;
			}
			worldActivityMonsterReq.ids = array2;
			this.killBossDataList.Clear();
			NetManager.Instance().SendCommand<WorldActivityMonsterReq>(ServerType.GATE_SERVER, worldActivityMonsterReq);
		}

		// Token: 0x0600AEE2 RID: 44770 RVA: 0x0026347C File Offset: 0x0026187C
		private void OnRecvWorldSyncClientActivitiesNormal(MsgDATA data)
		{
			SceneSyncClientActivities sceneSyncClientActivities = new SceneSyncClientActivities();
			sceneSyncClientActivities.decode(data.bytes);
			for (int i = 0; i < sceneSyncClientActivities.activities.Length; i++)
			{
				ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)sceneSyncClientActivities.activities[i].id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.ActivityType != ActiveMainTable.eActivityType.None)
					{
						if (tableItem.ActivityType == ActiveMainTable.eActivityType.ExchangeActivity)
						{
							if (tableItem.TownBtText != string.Empty && tableItem.TownBtText != null)
							{
								this.BossActivityBtIconName = tableItem.TownBtText;
							}
							if (tableItem.TownBtIconPath != string.Empty && tableItem.TownBtIconPath != null)
							{
								this.BossActivityBtIconPath = tableItem.TownBtIconPath;
							}
							this.BossExchangeIsOpen = true;
							this.ExchangeActivityID = (int)sceneSyncClientActivities.activities[i].id;
							if (this.ActivityDic.ContainsKey(this.ExchangeActivityID))
							{
								this.ActivityDic[this.ExchangeActivityID] = sceneSyncClientActivities.activities[i];
							}
							else
							{
								this.ActivityDic.Add(this.ExchangeActivityID, sceneSyncClientActivities.activities[i]);
							}
						}
						if (tableItem.ActivityType == ActiveMainTable.eActivityType.KillBossActivity)
						{
							if (tableItem.TownBtText != string.Empty && tableItem.TownBtText != null)
							{
								this.BossActivityBtIconName = tableItem.TownBtText;
							}
							if (tableItem.TownBtIconPath != string.Empty && tableItem.TownBtIconPath != null)
							{
								this.BossActivityBtIconPath = tableItem.TownBtIconPath;
							}
							this.BossKillIsOpen = true;
							this.KillBossActivityID = (int)sceneSyncClientActivities.activities[i].id;
							this.ActivityDic[this.KillBossActivityID] = sceneSyncClientActivities.activities[i];
						}
						this.initTaskIDList();
					}
				}
			}
		}

		// Token: 0x0600AEE3 RID: 44771 RVA: 0x0026365C File Offset: 0x00261A5C
		private void OnRecvSceneNotifyActiveTaskStatus(MsgDATA data)
		{
			SceneNotifyActiveTaskStatus sceneNotifyActiveTaskStatus = new SceneNotifyActiveTaskStatus();
			sceneNotifyActiveTaskStatus.decode(data.bytes);
			for (int i = 0; i < this.BossExchangeID.Count; i++)
			{
				if ((ulong)sceneNotifyActiveTaskStatus.taskId == (ulong)((long)this.BossExchangeID[i]))
				{
					this.ChildActivityStatus[(int)sceneNotifyActiveTaskStatus.taskId] = (int)sceneNotifyActiveTaskStatus.status;
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BossExchangeUpdate, null, null, null, null);
		}

		// Token: 0x0600AEE4 RID: 44772 RVA: 0x002636DC File Offset: 0x00261ADC
		private void OnRecvSceneNotifyActiveTaskVar(MsgDATA data)
		{
			SceneNotifyActiveTaskVar sceneNotifyActiveTaskVar = new SceneNotifyActiveTaskVar();
			sceneNotifyActiveTaskVar.decode(data.bytes);
			this.ChildActivityCount[(int)sceneNotifyActiveTaskVar.taskId] = sceneNotifyActiveTaskVar.val;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BossExchangeUpdate, null, null, null, null);
		}

		// Token: 0x0600AEE5 RID: 44773 RVA: 0x00263728 File Offset: 0x00261B28
		private void OnRecvActivityMonsterInfo(MsgDATA data)
		{
			WorldActivityMonsterRes worldActivityMonsterRes = new WorldActivityMonsterRes();
			worldActivityMonsterRes.decode(data.bytes);
			this.killBossDataList.Clear();
			for (int i = 0; i < worldActivityMonsterRes.monsters.Length; i++)
			{
				BossActivityDataManager.KillBossData killBossData = new BossActivityDataManager.KillBossData();
				killBossData.mName = worldActivityMonsterRes.monsters[i].name;
				killBossData.mActivity = worldActivityMonsterRes.monsters[i].activity;
				killBossData.mId = worldActivityMonsterRes.monsters[i].id;
				killBossData.mRemainNum = worldActivityMonsterRes.monsters[i].remainNum;
				killBossData.mNextRollStartTime = worldActivityMonsterRes.monsters[i].nextRollStartTime;
				killBossData.mStartTime = (int)worldActivityMonsterRes.monsters[i].startTime;
				killBossData.mEndTime = (int)worldActivityMonsterRes.monsters[i].endTime;
				killBossData.mMonsterType = (int)worldActivityMonsterRes.monsters[i].pointType;
				for (int j = 0; j < worldActivityMonsterRes.monsters[i].drops.Length; j++)
				{
					killBossData.mDrops.Add(worldActivityMonsterRes.monsters[i].drops[j]);
				}
				this.killBossDataList.Add(killBossData);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BossKillActivityExist, null, null, null, null);
			this.CanUpdateTime = true;
		}

		// Token: 0x0600AEE6 RID: 44774 RVA: 0x0026386C File Offset: 0x00261C6C
		private void OnRecvWorldNotifyClientActivity(MsgDATA data)
		{
			WorldNotifyClientActivity worldNotifyClientActivity = new WorldNotifyClientActivity();
			worldNotifyClientActivity.decode(data.bytes);
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)worldNotifyClientActivity.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.ActivityType == ActiveMainTable.eActivityType.ExchangeActivity)
			{
				ActivityInfo activityInfo = new ActivityInfo();
				activityInfo.state = worldNotifyClientActivity.type;
				activityInfo.id = worldNotifyClientActivity.id;
				activityInfo.level = worldNotifyClientActivity.level;
				activityInfo.name = worldNotifyClientActivity.name;
				activityInfo.preTime = worldNotifyClientActivity.preTime;
				activityInfo.startTime = worldNotifyClientActivity.startTime;
				activityInfo.dueTime = worldNotifyClientActivity.dueTime;
				if (worldNotifyClientActivity.type == 0)
				{
					this.BossExchangeIsOpen = false;
					if (this.ActivityDic.ContainsKey((int)worldNotifyClientActivity.id))
					{
						this.ActivityDic.Remove((int)worldNotifyClientActivity.id);
					}
				}
				else
				{
					this.BossExchangeIsOpen = true;
					if (tableItem.TownBtText != string.Empty && tableItem.TownBtText != null)
					{
						this.BossActivityBtIconName = tableItem.TownBtText;
					}
					if (tableItem.TownBtIconPath != string.Empty && tableItem.TownBtIconPath != null)
					{
						this.BossActivityBtIconPath = tableItem.TownBtIconPath;
					}
					this.ExchangeActivityID = (int)activityInfo.id;
					this.initTaskIDList();
					this.ActivityDic.Add((int)worldNotifyClientActivity.id, activityInfo);
				}
			}
			if (tableItem.ActivityType == ActiveMainTable.eActivityType.KillBossActivity)
			{
				ActivityInfo activityInfo2 = new ActivityInfo();
				activityInfo2.state = worldNotifyClientActivity.type;
				activityInfo2.id = worldNotifyClientActivity.id;
				activityInfo2.level = worldNotifyClientActivity.level;
				activityInfo2.name = worldNotifyClientActivity.name;
				activityInfo2.preTime = worldNotifyClientActivity.preTime;
				activityInfo2.startTime = worldNotifyClientActivity.startTime;
				activityInfo2.dueTime = worldNotifyClientActivity.dueTime;
				if (worldNotifyClientActivity.type == 0)
				{
					this.BossKillIsOpen = false;
					if (this.ActivityDic.ContainsKey((int)worldNotifyClientActivity.id))
					{
						this.ActivityDic.Remove((int)worldNotifyClientActivity.id);
					}
				}
				else
				{
					this.BossKillIsOpen = true;
					if (tableItem.TownBtText != string.Empty && tableItem.TownBtText != null)
					{
						this.BossActivityBtIconName = tableItem.TownBtText;
					}
					if (tableItem.TownBtIconPath != string.Empty && tableItem.TownBtIconPath != null)
					{
						this.BossActivityBtIconPath = tableItem.TownBtIconPath;
					}
					this.KillBossActivityID = (int)activityInfo2.id;
					this.ActivityDic.Add((int)worldNotifyClientActivity.id, activityInfo2);
				}
			}
			if (this.BossExchangeIsOpen || this.BossKillIsOpen)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateBossActivityState, 1, null, null, null);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateBossActivityState, 0, null, null, null);
			}
		}

		// Token: 0x040061AF RID: 25007
		public List<int> BossExchangeID = new List<int>();

		// Token: 0x040061B0 RID: 25008
		public Dictionary<int, ActivityInfo> ActivityDic = new Dictionary<int, ActivityInfo>();

		// Token: 0x040061B1 RID: 25009
		public Dictionary<int, string> ChildActivityCount = new Dictionary<int, string>();

		// Token: 0x040061B2 RID: 25010
		public Dictionary<int, int> ChildActivityStatus = new Dictionary<int, int>();

		// Token: 0x040061B3 RID: 25011
		public List<BossActivityDataManager.KillBossData> killBossDataList = new List<BossActivityDataManager.KillBossData>();

		// Token: 0x040061B4 RID: 25012
		public bool HaveBossActivity;

		// Token: 0x040061B5 RID: 25013
		public bool CanUpdateTime;

		// Token: 0x040061B6 RID: 25014
		public bool BossExchangeIsOpen;

		// Token: 0x040061B7 RID: 25015
		public bool BossKillIsOpen;

		// Token: 0x040061B8 RID: 25016
		public int ExchangeActivityID = -1;

		// Token: 0x040061B9 RID: 25017
		public int KillBossActivityID = -1;

		// Token: 0x040061BA RID: 25018
		public string BossActivityBtIconPath = string.Empty;

		// Token: 0x040061BB RID: 25019
		public string BossActivityBtIconName = string.Empty;

		// Token: 0x020011C5 RID: 4549
		public class KillBossData
		{
			// Token: 0x040061BC RID: 25020
			public string mName;

			// Token: 0x040061BD RID: 25021
			public byte mActivity;

			// Token: 0x040061BE RID: 25022
			public uint mId;

			// Token: 0x040061BF RID: 25023
			public uint mRemainNum;

			// Token: 0x040061C0 RID: 25024
			public uint mNextRollStartTime;

			// Token: 0x040061C1 RID: 25025
			public int mStartTime;

			// Token: 0x040061C2 RID: 25026
			public int mEndTime;

			// Token: 0x040061C3 RID: 25027
			public int mMonsterType;

			// Token: 0x040061C4 RID: 25028
			public List<DropItem> mDrops = new List<DropItem>();
		}
	}
}
