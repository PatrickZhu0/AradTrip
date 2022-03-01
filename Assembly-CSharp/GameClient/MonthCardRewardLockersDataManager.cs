using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001945 RID: 6469
	public class MonthCardRewardLockersDataManager : DataManager<MonthCardRewardLockersDataManager>
	{
		// Token: 0x17001D0C RID: 7436
		// (get) Token: 0x0600FB89 RID: 64393 RVA: 0x0044F380 File Offset: 0x0044D780
		public uint UniformExpriedLastTime
		{
			get
			{
				return this.m_UniformExpiredLastTime;
			}
		}

		// Token: 0x17001D0D RID: 7437
		// (get) Token: 0x0600FB8A RID: 64394 RVA: 0x0044F388 File Offset: 0x0044D788
		// (set) Token: 0x0600FB8B RID: 64395 RVA: 0x0044F390 File Offset: 0x0044D790
		public bool RedPointFlag
		{
			get
			{
				return this.m_RedPointFlag;
			}
			set
			{
				if (this.m_RedPointFlag != value)
				{
					this.m_RedPointFlag = value;
					this.RefreshRedPoint();
				}
			}
		}

		// Token: 0x17001D0E RID: 7438
		// (get) Token: 0x0600FB8C RID: 64396 RVA: 0x0044F3AB File Offset: 0x0044D7AB
		public int MonthCardRewardLockersGridCount
		{
			get
			{
				return this.m_MonthCardRewardLockersGridCount;
			}
		}

		// Token: 0x0600FB8D RID: 64397 RVA: 0x0044F3B3 File Offset: 0x0044D7B3
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

		// Token: 0x0600FB8E RID: 64398 RVA: 0x0044F3D4 File Offset: 0x0044D7D4
		public sealed override void Clear()
		{
			this._UnBindNetEvent();
			this._ClearLocalData();
			this.m_IsInited = false;
		}

		// Token: 0x0600FB8F RID: 64399 RVA: 0x0044F3EC File Offset: 0x0044D7EC
		private void _ReleaseRewardItems()
		{
			if (this.m_RewardLocalItemList != null)
			{
				for (int i = 0; i < this.m_RewardLocalItemList.Count; i++)
				{
					MonthCardRewardLockersItem monthCardRewardLockersItem = this.m_RewardLocalItemList[i];
					if (monthCardRewardLockersItem != null)
					{
						monthCardRewardLockersItem.Clear();
					}
				}
				this.m_RewardLocalItemList.Clear();
			}
		}

		// Token: 0x0600FB90 RID: 64400 RVA: 0x0044F44C File Offset: 0x0044D84C
		private void _InitLocalData()
		{
			this.m_RewardLocalItemList = new List<MonthCardRewardLockersItem>();
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(573, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.m_MonthCardRewardLockersGridCount = tableItem.Value;
			}
			SystemValueTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(576, string.Empty, string.Empty);
			if (tableItem2 != null)
			{
				this.m_RedPointUpdateHour = tableItem2.Value;
			}
			SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(611, string.Empty, string.Empty);
			if (tableItem3 != null)
			{
				this.m_ExpiredTimeMinute = tableItem3.Value;
			}
			this.isLastLockersEmpty = this.IsMonthCardRewardLockersEmpty();
		}

		// Token: 0x0600FB91 RID: 64401 RVA: 0x0044F4F4 File Offset: 0x0044D8F4
		private void _ClearLocalData()
		{
			this._ReleaseRewardItems();
			this.m_ServerItemArray = null;
			this.m_UniformExpiredLastTime = 0U;
			this.isRedPointShow = false;
			this.isLastExpiredTimeOut = false;
			this.isLastExpiredTimeLessThan24H = false;
			this.hasActivityNotifiedLogin = false;
			this.isLastLockersEmpty = false;
			this.m_RedPointUpdateHour = 6;
			this.m_RedPointFlag = true;
		}

		// Token: 0x0600FB92 RID: 64402 RVA: 0x0044F548 File Offset: 0x0044D948
		private void _BindNetEvent()
		{
			NetProcess.AddMsgHandler(501051U, new Action<MsgDATA>(this._OnSceneItemDepositRes));
			NetProcess.AddMsgHandler(501053U, new Action<MsgDATA>(this._OnSceneItemDepositGetRes));
			NetProcess.AddMsgHandler(501059U, new Action<MsgDATA>(this._OnSceneItemDepositExpire));
		}

		// Token: 0x0600FB93 RID: 64403 RVA: 0x0044F598 File Offset: 0x0044D998
		private void _UnBindNetEvent()
		{
			NetProcess.RemoveMsgHandler(501051U, new Action<MsgDATA>(this._OnSceneItemDepositRes));
			NetProcess.RemoveMsgHandler(501053U, new Action<MsgDATA>(this._OnSceneItemDepositGetRes));
			NetProcess.RemoveMsgHandler(501059U, new Action<MsgDATA>(this._OnSceneItemDepositExpire));
		}

		// Token: 0x0600FB94 RID: 64404 RVA: 0x0044F5E8 File Offset: 0x0044D9E8
		private void _OnSceneItemDepositRes(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			SceneItemDepositRes sceneItemDepositRes = new SceneItemDepositRes();
			sceneItemDepositRes.decode(msg.bytes);
			depositItem[] depositItemList = sceneItemDepositRes.depositItemList;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			if (sceneItemDepositRes.expireTime > 0U)
			{
				this.m_UniformExpiredLastTime = sceneItemDepositRes.expireTime - serverTime;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthCardRewardCDUpdate, null, null, null, null);
			}
			else
			{
				this.m_UniformExpiredLastTime = 0U;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthCardRewardCDUpdate, null, null, null, null);
			}
			if (this.m_RewardLocalItemList == null)
			{
				this.m_RewardLocalItemList = new List<MonthCardRewardLockersItem>();
			}
			if (depositItemList != null && depositItemList.Length > 0)
			{
				this.m_ServerItemArray = depositItemList;
				if (this.m_RewardLocalItemList != null)
				{
					this.m_RewardLocalItemList.RemoveAll(new Predicate<MonthCardRewardLockersItem>(this._FindItemGuidInServerItem));
				}
				foreach (depositItem depositItem in depositItemList)
				{
					if (depositItem != null)
					{
						MonthCardRewardLockersItem monthCardRewardLockersItem = this._GetMonthCardRewardLockersItemByGUID(depositItem.guid);
						if (monthCardRewardLockersItem == null)
						{
							monthCardRewardLockersItem = new MonthCardRewardLockersItem(depositItem);
							if (this.m_RewardLocalItemList != null)
							{
								this.m_RewardLocalItemList.Add(monthCardRewardLockersItem);
							}
						}
						else
						{
							monthCardRewardLockersItem.UpdateItem(depositItem);
						}
					}
				}
				if (this.m_RewardLocalItemList != null)
				{
					this.m_RewardLocalItemList.Sort((MonthCardRewardLockersItem x, MonthCardRewardLockersItem y) => x.CompareTo(y));
				}
			}
			else
			{
				this._ReleaseRewardItems();
			}
			if (this.IsMonthCardRewardLockersEmpty() != this.isLastLockersEmpty)
			{
				this.RefreshRedPoint();
				this.isLastLockersEmpty = this.IsMonthCardRewardLockersEmpty();
			}
			this._UpdateActivityNotice();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthCardRewardUpdate, null, null, null, null);
		}

		// Token: 0x0600FB95 RID: 64405 RVA: 0x0044F7A4 File Offset: 0x0044DBA4
		private MonthCardRewardLockersItem _GetMonthCardRewardLockersItemByGUID(ulong itemGUID)
		{
			if (this.m_RewardLocalItemList == null || this.m_RewardLocalItemList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < this.m_RewardLocalItemList.Count; i++)
			{
				MonthCardRewardLockersItem monthCardRewardLockersItem = this.m_RewardLocalItemList[i];
				if (monthCardRewardLockersItem != null && monthCardRewardLockersItem.itemdata != null)
				{
					if (monthCardRewardLockersItem.itemdata.GUID == itemGUID)
					{
						return monthCardRewardLockersItem;
					}
				}
			}
			return null;
		}

		// Token: 0x0600FB96 RID: 64406 RVA: 0x0044F824 File Offset: 0x0044DC24
		private bool _FindItemGuidInServerItem(MonthCardRewardLockersItem localItem)
		{
			bool flag = false;
			if (localItem == null)
			{
				return flag;
			}
			if (this.m_ServerItemArray == null || this.m_ServerItemArray.Length <= 0)
			{
				return flag;
			}
			for (int i = 0; i < this.m_ServerItemArray.Length; i++)
			{
				depositItem depositItem = this.m_ServerItemArray[i];
				if (depositItem != null)
				{
					if (localItem.GetItemGUID() == depositItem.guid)
					{
						flag = true;
						break;
					}
				}
			}
			return !flag;
		}

		// Token: 0x0600FB97 RID: 64407 RVA: 0x0044F8A0 File Offset: 0x0044DCA0
		private void _OnSceneItemDepositGetRes(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			SceneItemDepositGetRes sceneItemDepositGetRes = new SceneItemDepositGetRes();
			sceneItemDepositGetRes.decode(msg.bytes);
			if (sceneItemDepositGetRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneItemDepositGetRes.retCode, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthCardRewardAccquired, null, null, null, null);
			}
		}

		// Token: 0x0600FB98 RID: 64408 RVA: 0x0044F8FC File Offset: 0x0044DCFC
		private void _OnSceneItemDepositExpire(MsgDATA msg)
		{
			if (msg == null)
			{
				return;
			}
			SceneItemDepositExpire sceneItemDepositExpire = new SceneItemDepositExpire();
			sceneItemDepositExpire.decode(msg.bytes);
			if (sceneItemDepositExpire.oddExpireTime == 0U)
			{
				this.isLastExpiredTimeOut = true;
				this.m_RedPointFlag = true;
				this.isLastExpiredTimeLessThan24H = false;
			}
			else if ((ulong)sceneItemDepositExpire.oddExpireTime == (ulong)((long)(this.m_ExpiredTimeMinute * 60)))
			{
				this.isLastExpiredTimeLessThan24H = true;
			}
			this._OnUpdateActivityNotice();
		}

		// Token: 0x0600FB99 RID: 64409 RVA: 0x0044F96A File Offset: 0x0044DD6A
		private void _UpdateActivityNotice()
		{
			if (this.m_UniformExpiredLastTime > 0U && (ulong)this.m_UniformExpiredLastTime <= (ulong)((long)(this.m_ExpiredTimeMinute * 60)))
			{
				this.isLastExpiredTimeLessThan24H = true;
			}
			else
			{
				this.isLastExpiredTimeLessThan24H = false;
			}
			this._OnUpdateActivityNotice();
		}

		// Token: 0x0600FB9A RID: 64410 RVA: 0x0044F9A8 File Offset: 0x0044DDA8
		private void _OnUpdateActivityNotice()
		{
			if (!this._CheckLocalItemHasHighestGrade())
			{
				return;
			}
			NotifyInfo a_info = new NotifyInfo
			{
				type = 9U
			};
			if (this.isLastExpiredTimeLessThan24H)
			{
				if (!this.hasActivityNotifiedLogin)
				{
					DataManager<ActivityNoticeDataManager>.GetInstance().AddActivityNotice(a_info);
					DataManager<DeadLineReminderDataManager>.GetInstance().AddActivityNotice(a_info);
					this.hasActivityNotifiedLogin = true;
				}
			}
			else
			{
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(a_info);
				DataManager<DeadLineReminderDataManager>.GetInstance().DeleteActivityNotice(a_info);
			}
		}

		// Token: 0x0600FB9B RID: 64411 RVA: 0x0044FA24 File Offset: 0x0044DE24
		private bool _CheckLocalItemHasHighestGrade()
		{
			if (this.m_RewardLocalItemList == null || this.m_RewardLocalItemList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < this.m_RewardLocalItemList.Count; i++)
			{
				MonthCardRewardLockersItem monthCardRewardLockersItem = this.m_RewardLocalItemList[i];
				if (monthCardRewardLockersItem != null && monthCardRewardLockersItem.isHignestGradeItem)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600FB9C RID: 64412 RVA: 0x0044FA8C File Offset: 0x0044DE8C
		public List<MonthCardRewardLockersItem> GetMonthCardRewardLockersItems()
		{
			return this.m_RewardLocalItemList;
		}

		// Token: 0x0600FB9D RID: 64413 RVA: 0x0044FA94 File Offset: 0x0044DE94
		public bool IsMonthCardRewardLockersEmpty()
		{
			return this.m_RewardLocalItemList == null || this.m_RewardLocalItemList.Count <= 0;
		}

		// Token: 0x0600FB9E RID: 64414 RVA: 0x0044FAB8 File Offset: 0x0044DEB8
		public bool IsNewItemQualityAbleToEnterLockers(ItemTable.eColor color)
		{
			if (this.m_RewardLocalItemList == null || this.m_RewardLocalItemList.Count <= 0)
			{
				return true;
			}
			int rewardLockersItemLowestQuality = (int)this.GetRewardLockersItemLowestQuality();
			return (color > (ItemTable.eColor)rewardLockersItemLowestQuality && this.m_RewardLocalItemList.Count >= this.m_MonthCardRewardLockersGridCount) || this.m_RewardLocalItemList.Count < this.m_MonthCardRewardLockersGridCount;
		}

		// Token: 0x0600FB9F RID: 64415 RVA: 0x0044FB24 File Offset: 0x0044DF24
		public ItemTable.eColor GetRewardLockersItemLowestQuality()
		{
			if (this.m_RewardLocalItemList == null || this.m_RewardLocalItemList.Count <= 0)
			{
				return ItemTable.eColor.CL_NONE;
			}
			int count = this.m_RewardLocalItemList.Count;
			ItemData itemdata = this.m_RewardLocalItemList[count - 1].itemdata;
			if (itemdata == null)
			{
				return ItemTable.eColor.CL_NONE;
			}
			return itemdata.Quality;
		}

		// Token: 0x0600FBA0 RID: 64416 RVA: 0x0044FB80 File Offset: 0x0044DF80
		public void ReqMonthCardRewardLockersItems()
		{
			SceneItemDepositReq cmd = new SceneItemDepositReq();
			MonoSingleton<NetManager>.instance.SendCommand<SceneItemDepositReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600FBA1 RID: 64417 RVA: 0x0044FBA0 File Offset: 0x0044DFA0
		public void ReqGetMonthCardRewardLockersItems()
		{
			if (this.m_RewardLocalItemList == null || this.m_RewardLocalItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.m_RewardLocalItemList.Count; i++)
			{
				MonthCardRewardLockersItem monthCardRewardLockersItem = this.m_RewardLocalItemList[i];
				if (monthCardRewardLockersItem != null && monthCardRewardLockersItem.itemdata != null)
				{
					this.ReqGetMonthCardRewardLockertItem(monthCardRewardLockersItem.itemdata.GUID);
				}
			}
		}

		// Token: 0x0600FBA2 RID: 64418 RVA: 0x0044FC1C File Offset: 0x0044E01C
		public void ReqGetMonthCardRewardLockertItem(ulong itemGUID)
		{
			SceneItemDepositGetReq sceneItemDepositGetReq = new SceneItemDepositGetReq();
			sceneItemDepositGetReq.guid = itemGUID;
			MonoSingleton<NetManager>.instance.SendCommand<SceneItemDepositGetReq>(ServerType.GATE_SERVER, sceneItemDepositGetReq);
		}

		// Token: 0x0600FBA3 RID: 64419 RVA: 0x0044FC44 File Offset: 0x0044E044
		public bool HasRedPointFirstShowedToday()
		{
			int tempTimeStamp = this.GetTempTimeStamp();
			int refreshTimeStamp = this.GetRefreshTimeStamp();
			return tempTimeStamp >= refreshTimeStamp;
		}

		// Token: 0x0600FBA4 RID: 64420 RVA: 0x0044FC6C File Offset: 0x0044E06C
		public bool IsRedPointShow()
		{
			this.isRedPointShow = false;
			bool flag = this.HasRedPointFirstShowedToday();
			if (this.m_RedPointFlag && !flag && this.m_RewardLocalItemList != null && this.m_RewardLocalItemList.Count > 0)
			{
				this.isRedPointShow = true;
			}
			else if (this.m_RedPointFlag && this.HasNewRewardAndLastExpriedTimeOut())
			{
				this.isRedPointShow = true;
			}
			else if (this.HasRewardToAccquire())
			{
				this.isRedPointShow = true;
			}
			return this.isRedPointShow;
		}

		// Token: 0x0600FBA5 RID: 64421 RVA: 0x0044FCFA File Offset: 0x0044E0FA
		public bool HasNewRewardAndLastExpriedTimeOut()
		{
			return this.isLastExpiredTimeOut && this.m_RewardLocalItemList != null && this.m_RewardLocalItemList.Count > 0;
		}

		// Token: 0x0600FBA6 RID: 64422 RVA: 0x0044FD26 File Offset: 0x0044E126
		public bool HasRewardToAccquire()
		{
			return Singleton<PayManager>.GetInstance().HasMonthCardEnabled() && this.m_RewardLocalItemList != null && this.m_RewardLocalItemList.Count > 0;
		}

		// Token: 0x0600FBA7 RID: 64423 RVA: 0x0044FD56 File Offset: 0x0044E156
		public void ResetRedPoint()
		{
			if (this.RedPointFlag && this.isRedPointShow)
			{
				this.SaveCurrTimeStamp();
				this.RedPointFlag = false;
			}
		}

		// Token: 0x0600FBA8 RID: 64424 RVA: 0x0044FD7B File Offset: 0x0044E17B
		public void RefreshRedPoint()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthCardRewardRedPointReset, null, null, null, null);
		}

		// Token: 0x0600FBA9 RID: 64425 RVA: 0x0044FD90 File Offset: 0x0044E190
		private int GetTempTimeStamp()
		{
			return Singleton<PlayerPrefsManager>.GetInstance().GetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.MonthCardRewardRedPointUpdateTime, new object[0]);
		}

		// Token: 0x0600FBAA RID: 64426 RVA: 0x0044FDA4 File Offset: 0x0044E1A4
		private void SaveCurrTimeStamp()
		{
			int currTimeStamp = this.GetCurrTimeStamp();
			Singleton<PlayerPrefsManager>.GetInstance().SetTypeKeyIntValue(PlayerPrefsManager.PlayerPrefsKeyType.MonthCardRewardRedPointUpdateTime, currTimeStamp, new object[0]);
		}

		// Token: 0x0600FBAB RID: 64427 RVA: 0x0044FDCC File Offset: 0x0044E1CC
		private int GetCurrTimeStamp()
		{
			return (int)DataManager<TimeManager>.GetInstance().GetServerTime();
		}

		// Token: 0x0600FBAC RID: 64428 RVA: 0x0044FDE8 File Offset: 0x0044E1E8
		private int GetCurrTimeHour()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime).Hour;
		}

		// Token: 0x0600FBAD RID: 64429 RVA: 0x0044FE10 File Offset: 0x0044E210
		private DateTime GetCurrDateTime()
		{
			double serverDoubleTime = DataManager<TimeManager>.GetInstance().GetServerDoubleTime();
			return Function.ConvertIntDateTime(serverDoubleTime);
		}

		// Token: 0x0600FBAE RID: 64430 RVA: 0x0044FE30 File Offset: 0x0044E230
		private int GetRefreshTimeStamp()
		{
			int currTimeHour = this.GetCurrTimeHour();
			DateTime currDateTime = this.GetCurrDateTime();
			DateTime time;
			if (this.m_RedPointUpdateHour >= currTimeHour)
			{
				time = Function.GetYesterdayGivenHourTime(this.m_RedPointUpdateHour);
			}
			else
			{
				time = Function.GetTodayGivenHourTime(this.m_RedPointUpdateHour);
			}
			return Convert.ToInt32(Function.ConvertDateTimeInt(time));
		}

		// Token: 0x0600FBAF RID: 64431 RVA: 0x0044FE84 File Offset: 0x0044E284
		public static bool IsHighestGradeItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			bool flag = false;
			bool flag2 = false;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemData.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				flag2 = (tableItem.IsTreas == 1);
				if (tableItem.Type == ItemTable.eType.EQUIP)
				{
					flag = DataManager<EquipHandbookDataManager>.GetInstance().IsHighestGradeItem(itemData.TableID);
				}
			}
			return itemData.IsTreasure || flag2 || flag;
		}

		// Token: 0x04009D32 RID: 40242
		public const int FULI_ACTIVITY_TYPE_ID = 9380;

		// Token: 0x04009D33 RID: 40243
		public const int FULI_ACTIVITY_TEMPLATE_TABLE_ID = 6000;

		// Token: 0x04009D34 RID: 40244
		private bool m_IsInited;

		// Token: 0x04009D35 RID: 40245
		private List<MonthCardRewardLockersItem> m_RewardLocalItemList;

		// Token: 0x04009D36 RID: 40246
		private depositItem[] m_ServerItemArray;

		// Token: 0x04009D37 RID: 40247
		private uint m_UniformExpiredLastTime;

		// Token: 0x04009D38 RID: 40248
		private bool m_RedPointFlag = true;

		// Token: 0x04009D39 RID: 40249
		private bool isRedPointShow;

		// Token: 0x04009D3A RID: 40250
		private bool isLastExpiredTimeOut;

		// Token: 0x04009D3B RID: 40251
		private bool isLastExpiredTimeLessThan24H;

		// Token: 0x04009D3C RID: 40252
		private bool hasActivityNotifiedLogin;

		// Token: 0x04009D3D RID: 40253
		private int m_ExpiredTimeMinute = 1440;

		// Token: 0x04009D3E RID: 40254
		private bool isLastLockersEmpty;

		// Token: 0x04009D3F RID: 40255
		private int m_RedPointUpdateHour = 6;

		// Token: 0x04009D40 RID: 40256
		private int m_MonthCardRewardLockersGridCount = 30;
	}
}
