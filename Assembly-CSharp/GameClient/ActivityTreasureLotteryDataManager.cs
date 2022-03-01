using System;
using System.Collections.Generic;
using DataModel;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011C2 RID: 4546
	public class ActivityTreasureLotteryDataManager : DataManager<ActivityTreasureLotteryDataManager>, IActivityTreasureLotteryDataMananger
	{
		// Token: 0x0600AEB1 RID: 44721 RVA: 0x002620C6 File Offset: 0x002604C6
		public string GetRemainTime()
		{
			return Function.GetLastsTimeStr(this.mTime - DataManager<TimeManager>.GetInstance().GetServerTime());
		}

		// Token: 0x0600AEB2 RID: 44722 RVA: 0x002620E0 File Offset: 0x002604E0
		public ETreasureLotterState GetState()
		{
			if ((this._state == ETreasureLotterState.Open || this._state == ETreasureLotterState.Prepare) && DataManager<PlayerBaseData>.GetInstance().Level < this.mUnlockLevel)
			{
				return ETreasureLotterState.Close;
			}
			return this._state;
		}

		// Token: 0x0600AEB3 RID: 44723 RVA: 0x00262117 File Offset: 0x00260517
		public IActivityTreasureLotteryDrawModel DequeueDrawLottery()
		{
			if (this._drawLotteryQueue == null || this._drawLotteryQueue.Count <= 0)
			{
				return null;
			}
			return this._drawLotteryQueue.Dequeue();
		}

		// Token: 0x0600AEB4 RID: 44724 RVA: 0x00262142 File Offset: 0x00260542
		public int GetDrawLotteryCount()
		{
			return this._drawLotteryQueue.Count;
		}

		// Token: 0x0600AEB5 RID: 44725 RVA: 0x00262150 File Offset: 0x00260550
		public T GetModel<T>(int id) where T : IActivityTreasureLotteryModelBase
		{
			if (typeof(T) == typeof(IActivityTreasureLotteryModel))
			{
				return (T)((object)this.GetActivityModel(id));
			}
			if (typeof(T) == typeof(IActivityTreasureLotteryMyLotteryModel))
			{
				return (T)((object)this.GetMyLotteryModel(id));
			}
			if (typeof(T) == typeof(IActivityTreasureLotteryHistoryModel))
			{
				return (T)((object)this.GetHistoryModel(id));
			}
			return default(T);
		}

		// Token: 0x0600AEB6 RID: 44726 RVA: 0x002621D8 File Offset: 0x002605D8
		public bool IsHadData()
		{
			return this.mActivityModelList != null && this.mActivityModelList.Count > 0;
		}

		// Token: 0x0600AEB7 RID: 44727 RVA: 0x002621F8 File Offset: 0x002605F8
		public int GetItemIdByLotteryId(int lotteryId)
		{
			if (this.mActivityModelList == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mActivityModelList.Count; i++)
			{
				if ((ulong)this.mActivityModelList[i].LotteryId == (ulong)((long)lotteryId))
				{
					return this.mActivityModelList[i].ItemId;
				}
			}
			return 0;
		}

		// Token: 0x0600AEB8 RID: 44728 RVA: 0x0026225C File Offset: 0x0026065C
		public int GetModelIndexByLotteryId<T>(int lotteryId)
		{
			if (typeof(T) == typeof(IActivityTreasureLotteryModel))
			{
				return this.GetActivityModelIndexByLotteryId(lotteryId);
			}
			if (typeof(T) == typeof(IActivityTreasureLotteryMyLotteryModel))
			{
				return this.GetMyLotteryModelIndexByLotteryId(lotteryId);
			}
			if (typeof(T) == typeof(IActivityTreasureLotteryHistoryModel))
			{
				return this.GetHistoryModelIndexByLotteryId(lotteryId);
			}
			return 0;
		}

		// Token: 0x0600AEB9 RID: 44729 RVA: 0x002622D0 File Offset: 0x002606D0
		public int GetModelAmount<T>()
		{
			if (typeof(T) == typeof(IActivityTreasureLotteryModel))
			{
				return this.GetActivityModelAmount();
			}
			if (typeof(T) == typeof(IActivityTreasureLotteryMyLotteryModel))
			{
				return this.GetMyLotteryModelAmount();
			}
			if (typeof(T) == typeof(IActivityTreasureLotteryHistoryModel))
			{
				return this.GetHistoryModelAmount();
			}
			return 0;
		}

		// Token: 0x0600AEBA RID: 44730 RVA: 0x00262340 File Offset: 0x00260740
		public void BuyLottery(int id, uint buyCount, bool isBuyAll)
		{
			if (id < 0 || this.mActivityModelList == null || id >= this.mActivityModelList.Count)
			{
				Logger.LogError("mActivityModelList is null");
				return;
			}
			PayingGambleReq cmd = new PayingGambleReq
			{
				gambingItemId = this.mActivityModelList[id].LotteryId,
				groupId = this.mActivityModelList[id].GroupId,
				investCopies = buyCount,
				bBuyAll = ((!isBuyAll) ? 0 : 1)
			};
			NetManager.Instance().SendCommand<PayingGambleReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AEBB RID: 44731 RVA: 0x002623DC File Offset: 0x002607DC
		public void GetLotteryItemList(bool isImmediately = false)
		{
			if (this.GetState() == ETreasureLotterState.Close)
			{
				return;
			}
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(381, string.Empty, string.Empty).Value;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (!isImmediately && (ulong)(serverTime - this.mLastRequestTime[0]) < (ulong)((long)value))
			{
				return;
			}
			this.mLastRequestTime[0] = serverTime;
			GambingItemQueryReq cmd = new GambingItemQueryReq();
			NetManager.Instance().SendCommand<GambingItemQueryReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AEBC RID: 44732 RVA: 0x00262454 File Offset: 0x00260854
		public void GetMyLotteryItemList(bool isImmediately = false)
		{
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(381, string.Empty, string.Empty).Value;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (this.mLastRequestTime == null || 1 >= this.mLastRequestTime.Length)
			{
				return;
			}
			if (!isImmediately && (ulong)(serverTime - this.mLastRequestTime[1]) < (ulong)((long)value))
			{
				return;
			}
			this.mLastRequestTime[1] = serverTime;
			GambingMineQueryReq cmd = new GambingMineQueryReq();
			NetManager.Instance().SendCommand<GambingMineQueryReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600AEBD RID: 44733 RVA: 0x002624DC File Offset: 0x002608DC
		public void GetHistroyItemList(bool isImmediately = false)
		{
			int value = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(381, string.Empty, string.Empty).Value;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (this.mLastRequestTime == null || 2 >= this.mLastRequestTime.Length)
			{
				return;
			}
			if (isImmediately || (ulong)(serverTime - this.mLastRequestTime[2]) >= (ulong)((long)value))
			{
				this.mLastRequestTime[2] = serverTime;
				GambingRecordQueryReq cmd = new GambingRecordQueryReq();
				NetManager.Instance().SendCommand<GambingRecordQueryReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600AEBE RID: 44734 RVA: 0x00262564 File Offset: 0x00260964
		public override void Initialize()
		{
			this.mLastRequestTime = new uint[3];
			NetProcess.AddMsgHandler(707902U, new Action<MsgDATA>(this.OnBuyLotteryResp));
			NetProcess.AddMsgHandler(707904U, new Action<MsgDATA>(this.OnGetLotteryItemList));
			NetProcess.AddMsgHandler(707906U, new Action<MsgDATA>(this.OnGetMyLotteryInfo));
			NetProcess.AddMsgHandler(707908U, new Action<MsgDATA>(this.OnGetHistory));
			NetProcess.AddMsgHandler(707909U, new Action<MsgDATA>(this.OnSyncDrawLotteryResp));
			NetProcess.AddMsgHandler(501145U, new Action<MsgDATA>(this.OnSyncActivities));
			NetProcess.AddMsgHandler(501149U, new Action<MsgDATA>(this.OnSyncActivityStateChange));
		}

		// Token: 0x0600AEBF RID: 44735 RVA: 0x00262618 File Offset: 0x00260A18
		public override void Clear()
		{
			this._state = ETreasureLotterState.Close;
			this.mTime = 0U;
			this.mLastRequestTime = null;
			this.mUnlockLevel = ushort.MaxValue;
			this.mActivityModelList.Clear();
			this.mMyLotteryModelList.Clear();
			this.mHistroyModelList.Clear();
			this._drawLotteryQueue.Clear();
			NetProcess.RemoveMsgHandler(707902U, new Action<MsgDATA>(this.OnBuyLotteryResp));
			NetProcess.RemoveMsgHandler(707904U, new Action<MsgDATA>(this.OnGetLotteryItemList));
			NetProcess.RemoveMsgHandler(707906U, new Action<MsgDATA>(this.OnGetMyLotteryInfo));
			NetProcess.RemoveMsgHandler(707908U, new Action<MsgDATA>(this.OnGetHistory));
			NetProcess.RemoveMsgHandler(707909U, new Action<MsgDATA>(this.OnSyncDrawLotteryResp));
			NetProcess.RemoveMsgHandler(501145U, new Action<MsgDATA>(this.OnSyncActivities));
			NetProcess.RemoveMsgHandler(501149U, new Action<MsgDATA>(this.OnSyncActivityStateChange));
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
		}

		// Token: 0x0600AEC0 RID: 44736 RVA: 0x00262731 File Offset: 0x00260B31
		private IActivityTreasureLotteryModel GetActivityModel(int id)
		{
			if (id < 0 || this.mActivityModelList == null || id >= this.mActivityModelList.Count)
			{
				return null;
			}
			return this.mActivityModelList[id];
		}

		// Token: 0x0600AEC1 RID: 44737 RVA: 0x00262764 File Offset: 0x00260B64
		private IActivityTreasureLotteryMyLotteryModel GetMyLotteryModel(int id)
		{
			if (id < 0 || this.mMyLotteryModelList == null || id >= this.mMyLotteryModelList.Count)
			{
				return null;
			}
			return this.mMyLotteryModelList[id];
		}

		// Token: 0x0600AEC2 RID: 44738 RVA: 0x00262797 File Offset: 0x00260B97
		private IActivityTreasureLotteryHistoryModel GetHistoryModel(int id)
		{
			if (id < 0 || this.mHistroyModelList == null || id >= this.mHistroyModelList.Count)
			{
				return null;
			}
			return this.mHistroyModelList[id];
		}

		// Token: 0x0600AEC3 RID: 44739 RVA: 0x002627CC File Offset: 0x00260BCC
		private void OnSyncActivities(MsgDATA data)
		{
			SyncOpActivityDatas syncOpActivityDatas = new SyncOpActivityDatas();
			syncOpActivityDatas.decode(data.bytes);
			for (int i = 0; i < syncOpActivityDatas.datas.Length; i++)
			{
				if (syncOpActivityDatas.datas[i].tmpType == 1900U)
				{
					this.InitData(syncOpActivityDatas.datas[i].state, syncOpActivityDatas.datas[i].startTime, syncOpActivityDatas.datas[i].endTime, syncOpActivityDatas.datas[i].playerLevelLimit);
					break;
				}
			}
		}

		// Token: 0x0600AEC4 RID: 44740 RVA: 0x0026285C File Offset: 0x00260C5C
		private void InitData(byte state, uint startTime, uint endTime, ushort unlockLevel)
		{
			this._state = (ETreasureLotterState)state;
			this.mUnlockLevel = unlockLevel;
			ETreasureLotterState state2 = this._state;
			if (state2 != ETreasureLotterState.Prepare)
			{
				if (state2 == ETreasureLotterState.Open)
				{
					this.mTime = endTime;
				}
			}
			else
			{
				this.mTime = startTime;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotteryStatusChange, null, null, null, null);
			if (this.mUnlockLevel > DataManager<PlayerBaseData>.GetInstance().Level)
			{
				PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
				instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
				PlayerBaseData instance2 = DataManager<PlayerBaseData>.GetInstance();
				instance2.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Combine(instance2.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			}
		}

		// Token: 0x0600AEC5 RID: 44741 RVA: 0x00262920 File Offset: 0x00260D20
		private void OnLevelChanged(int iPreLv, int iCurLv)
		{
			if (iCurLv >= (int)this.mUnlockLevel)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotteryStatusChange, null, null, null, null);
				PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
				instance.onLevelChanged = (PlayerBaseData.OnLevelChanged)Delegate.Remove(instance.onLevelChanged, new PlayerBaseData.OnLevelChanged(this.OnLevelChanged));
			}
		}

		// Token: 0x0600AEC6 RID: 44742 RVA: 0x00262974 File Offset: 0x00260D74
		private void OnSyncActivityStateChange(MsgDATA data)
		{
			SyncOpActivityStateChange syncOpActivityStateChange = new SyncOpActivityStateChange();
			syncOpActivityStateChange.decode(data.bytes);
			if (syncOpActivityStateChange.data.tmpType == 1900U)
			{
				this.InitData(syncOpActivityStateChange.data.state, syncOpActivityStateChange.data.startTime, syncOpActivityStateChange.data.endTime, syncOpActivityStateChange.data.playerLevelLimit);
			}
		}

		// Token: 0x0600AEC7 RID: 44743 RVA: 0x002629DC File Offset: 0x00260DDC
		private void OnBuyLotteryResp(MsgDATA data)
		{
			int num = 0;
			PayingGambleRes payingGambleRes = new PayingGambleRes();
			payingGambleRes.decode(data.bytes, ref num);
			if (payingGambleRes.retCode == 0U && payingGambleRes.itemInfo != null)
			{
				this.UpdateLotteryItem(payingGambleRes.itemInfo);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotteryBuyResp, payingGambleRes, null, null, null);
		}

		// Token: 0x0600AEC8 RID: 44744 RVA: 0x00262A34 File Offset: 0x00260E34
		private void UpdateLotteryItem(GambingItemInfo item)
		{
			if (this.mActivityModelList == null)
			{
				return;
			}
			for (int i = 0; i < this.mActivityModelList.Count; i++)
			{
				if (this.mActivityModelList[i].LotteryId == item.gambingItemId)
				{
					this.mActivityModelList[i] = new ActivityTreasureLotteryModel(item);
					this.mActivityModelList.Sort(new Comparison<ActivityTreasureLotteryModel>(this.CompareActivityModel));
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotterySyncActivity, null, null, null, null);
					break;
				}
			}
		}

		// Token: 0x0600AEC9 RID: 44745 RVA: 0x00262AC8 File Offset: 0x00260EC8
		private void OnGetLotteryItemList(MsgDATA data)
		{
			int num = 0;
			GambingItemQueryRes gambingItemQueryRes = new GambingItemQueryRes();
			gambingItemQueryRes.decode(data.bytes, ref num);
			if (this.mActivityModelList == null)
			{
				this.mActivityModelList = new List<ActivityTreasureLotteryModel>(8);
			}
			this.mActivityModelList.Clear();
			for (int i = 0; i < gambingItemQueryRes.gambingItems.Length; i++)
			{
				this.mActivityModelList.Add(new ActivityTreasureLotteryModel(gambingItemQueryRes.gambingItems[i]));
			}
			this.mActivityModelList.Sort(new Comparison<ActivityTreasureLotteryModel>(this.CompareActivityModel));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotterySyncActivity, null, null, null, null);
		}

		// Token: 0x0600AECA RID: 44746 RVA: 0x00262B68 File Offset: 0x00260F68
		private void OnGetMyLotteryInfo(MsgDATA data)
		{
			int num = 0;
			GambingMineQueryRes gambingMineQueryRes = new GambingMineQueryRes();
			gambingMineQueryRes.decode(data.bytes, ref num);
			if (this.mMyLotteryModelList == null)
			{
				this.mMyLotteryModelList = new List<ActivityTreasureLotteryMyLotteryModel>(8);
			}
			this.mMyLotteryModelList.Clear();
			for (int i = 0; i < gambingMineQueryRes.mineGambingInfo.Length; i++)
			{
				this.mMyLotteryModelList.Add(new ActivityTreasureLotteryMyLotteryModel(gambingMineQueryRes.mineGambingInfo[i]));
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotterySyncMyLottery, null, null, null, null);
		}

		// Token: 0x0600AECB RID: 44747 RVA: 0x00262BF4 File Offset: 0x00260FF4
		private void OnGetHistory(MsgDATA data)
		{
			int num = 0;
			GambingRecordQueryRes gambingRecordQueryRes = new GambingRecordQueryRes();
			gambingRecordQueryRes.decode(data.bytes, ref num);
			if (this.mHistroyModelList == null)
			{
				this.mHistroyModelList = new List<ActivityTreasureLotteryHistoryModel>(8);
			}
			this.mHistroyModelList.Clear();
			for (int i = 0; i < gambingRecordQueryRes.gambingRecordDatas.Length; i++)
			{
				this.mHistroyModelList.Add(new ActivityTreasureLotteryHistoryModel(gambingRecordQueryRes.gambingRecordDatas[i]));
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotterySyncHistory, null, null, null, null);
		}

		// Token: 0x0600AECC RID: 44748 RVA: 0x00262C80 File Offset: 0x00261080
		private void OnSyncDrawLotteryResp(MsgDATA data)
		{
			GambingLotterySync gambingLotterySync = new GambingLotterySync();
			gambingLotterySync.decode(data.bytes);
			if (this._drawLotteryQueue == null)
			{
				this._drawLotteryQueue = new Queue<ActivityTreasureLotteryDrawModel>(8);
			}
			this._drawLotteryQueue.Enqueue(new ActivityTreasureLotteryDrawModel(gambingLotterySync.gainersGambingInfo, gambingLotterySync.participantsGambingInfo));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TreasureLotterySyncDraw, null, null, null, null);
		}

		// Token: 0x0600AECD RID: 44749 RVA: 0x00262CE5 File Offset: 0x002610E5
		private int GetActivityModelAmount()
		{
			return (this.mActivityModelList != null) ? this.mActivityModelList.Count : 0;
		}

		// Token: 0x0600AECE RID: 44750 RVA: 0x00262D03 File Offset: 0x00261103
		private int GetMyLotteryModelAmount()
		{
			return (this.mMyLotteryModelList != null) ? this.mMyLotteryModelList.Count : 0;
		}

		// Token: 0x0600AECF RID: 44751 RVA: 0x00262D21 File Offset: 0x00261121
		private int GetHistoryModelAmount()
		{
			return (this.mHistroyModelList != null) ? this.mHistroyModelList.Count : 0;
		}

		// Token: 0x0600AED0 RID: 44752 RVA: 0x00262D40 File Offset: 0x00261140
		private int GetActivityModelIndexByLotteryId(int lotteryId)
		{
			if (this.mActivityModelList == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mActivityModelList.Count; i++)
			{
				if ((ulong)this.mActivityModelList[i].LotteryId == (ulong)((long)lotteryId))
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600AED1 RID: 44753 RVA: 0x00262D94 File Offset: 0x00261194
		private int GetMyLotteryModelIndexByLotteryId(int lotteryId)
		{
			if (this.mMyLotteryModelList == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mMyLotteryModelList.Count; i++)
			{
				if ((ulong)this.mMyLotteryModelList[i].LotteryId == (ulong)((long)lotteryId))
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600AED2 RID: 44754 RVA: 0x00262DE8 File Offset: 0x002611E8
		private int GetHistoryModelIndexByLotteryId(int lotteryId)
		{
			if (this.mHistroyModelList == null)
			{
				return 0;
			}
			for (int i = 0; i < this.mHistroyModelList.Count; i++)
			{
				if ((ulong)this.mHistroyModelList[i].LotteryId == (ulong)((long)lotteryId))
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600AED3 RID: 44755 RVA: 0x00262E3C File Offset: 0x0026123C
		private int CompareActivityModel(ActivityTreasureLotteryModel a, ActivityTreasureLotteryModel b)
		{
			if (a == null || b == null)
			{
				Logger.LogError("Param is null");
				return 0;
			}
			if (a.State != b.State)
			{
				if (a.State == GambingItemStatus.GIS_SOLD_OUE || a.State == GambingItemStatus.GIS_LOTTERY)
				{
					return 1;
				}
				if (b.State == GambingItemStatus.GIS_SOLD_OUE || b.State == GambingItemStatus.GIS_LOTTERY)
				{
					return -1;
				}
			}
			if (a.SortId < b.SortId)
			{
				return -1;
			}
			return (a.SortId <= b.SortId) ? 0 : 1;
		}

		// Token: 0x040061A1 RID: 24993
		private const int DEFAULT_LIST_CAPCITY = 8;

		// Token: 0x040061A2 RID: 24994
		private List<ActivityTreasureLotteryModel> mActivityModelList = new List<ActivityTreasureLotteryModel>(8);

		// Token: 0x040061A3 RID: 24995
		private List<ActivityTreasureLotteryMyLotteryModel> mMyLotteryModelList = new List<ActivityTreasureLotteryMyLotteryModel>(8);

		// Token: 0x040061A4 RID: 24996
		private List<ActivityTreasureLotteryHistoryModel> mHistroyModelList = new List<ActivityTreasureLotteryHistoryModel>(8);

		// Token: 0x040061A5 RID: 24997
		private Queue<ActivityTreasureLotteryDrawModel> _drawLotteryQueue = new Queue<ActivityTreasureLotteryDrawModel>(8);

		// Token: 0x040061A6 RID: 24998
		private ETreasureLotterState _state;

		// Token: 0x040061A7 RID: 24999
		private uint mTime;

		// Token: 0x040061A8 RID: 25000
		private uint[] mLastRequestTime;

		// Token: 0x040061A9 RID: 25001
		private ushort mUnlockLevel = ushort.MaxValue;

		// Token: 0x020011C3 RID: 4547
		private enum EDataType
		{
			// Token: 0x040061AB RID: 25003
			Activity,
			// Token: 0x040061AC RID: 25004
			MyLottery,
			// Token: 0x040061AD RID: 25005
			History,
			// Token: 0x040061AE RID: 25006
			Count
		}
	}
}
