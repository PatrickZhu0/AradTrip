using System;
using System.Collections.Generic;
using GameClient;
using LimitTimeGift;
using Protocol;
using ProtoTable;

namespace ActivityLimitTime
{
	// Token: 0x020011B1 RID: 4529
	public sealed class ActivityLimitTimeCombineManager : DataManager<ActivityLimitTimeCombineManager>
	{
		// Token: 0x17001A77 RID: 6775
		// (get) Token: 0x0600ADFB RID: 44539 RVA: 0x0025F459 File Offset: 0x0025D859
		// (set) Token: 0x0600ADFC RID: 44540 RVA: 0x0025F461 File Offset: 0x0025D861
		public BossActivityDataManager BossDataManager { get; private set; }

		// Token: 0x17001A78 RID: 6776
		// (get) Token: 0x0600ADFD RID: 44541 RVA: 0x0025F46A File Offset: 0x0025D86A
		// (set) Token: 0x0600ADFE RID: 44542 RVA: 0x0025F472 File Offset: 0x0025D872
		public LimitTimeGiftDataManager GiftDataManager { get; private set; }

		// Token: 0x17001A79 RID: 6777
		// (get) Token: 0x0600ADFF RID: 44543 RVA: 0x0025F47B File Offset: 0x0025D87B
		// (set) Token: 0x0600AE00 RID: 44544 RVA: 0x0025F483 File Offset: 0x0025D883
		public ActivityLimitTimeManager LimitTimeManager { get; private set; }

		// Token: 0x17001A7A RID: 6778
		// (get) Token: 0x0600AE01 RID: 44545 RVA: 0x0025F48C File Offset: 0x0025D88C
		// (set) Token: 0x0600AE02 RID: 44546 RVA: 0x0025F494 File Offset: 0x0025D894
		public bool IsCheckedLimitGift
		{
			private get
			{
				return this.mIsCheckedLimitGift;
			}
			set
			{
				bool flag = this.mIsCheckedLimitGift;
				this.mIsCheckedLimitGift = value;
				if (flag != this.mIsCheckedLimitGift)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnLimitTimeGiftChecked, null, null, null, null);
				}
			}
		}

		// Token: 0x17001A7B RID: 6779
		// (get) Token: 0x0600AE03 RID: 44547 RVA: 0x0025F4CE File Offset: 0x0025D8CE
		// (set) Token: 0x0600AE04 RID: 44548 RVA: 0x0025F4D8 File Offset: 0x0025D8D8
		public bool IsCheckedLimitTimeMallGift
		{
			get
			{
				return this.mIsCheckedLimitTimeMallGift;
			}
			set
			{
				bool flag = this.mIsCheckedLimitTimeMallGift;
				this.mIsCheckedLimitTimeMallGift = value;
				if (flag != this.mIsCheckedLimitTimeMallGift)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskUpdate, null, null, null, null);
				}
			}
		}

		// Token: 0x0600AE05 RID: 44549 RVA: 0x0025F512 File Offset: 0x0025D912
		public override EEnterGameOrder GetOrder()
		{
			return base.GetOrder();
		}

		// Token: 0x0600AE06 RID: 44550 RVA: 0x0025F51A File Offset: 0x0025D91A
		public bool IsHaveActivity()
		{
			return this.IsHaveFestival() || this.IsHaveLimitGift() || this.IsHaveLimitTime();
		}

		// Token: 0x0600AE07 RID: 44551 RVA: 0x0025F53C File Offset: 0x0025D93C
		public bool IsHaveFestival()
		{
			if (!Utility.IsUnLockFunc(64))
			{
				return false;
			}
			if (this.BossDataManager.ActivityDic.Count <= 0)
			{
				List<ActivityLimitTimeData> activityLimitTimeDataList = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeDataList;
				if (activityLimitTimeDataList != null && activityLimitTimeDataList.Count > 0)
				{
					for (int i = 0; i < activityLimitTimeDataList.Count; i++)
					{
						ActivityLimitTimeData activityLimitTimeData = activityLimitTimeDataList[i];
						if (activityLimitTimeData.ActivityState == ActivityState.Start && activityLimitTimeData.DataId == 1090U)
						{
							return true;
						}
					}
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600AE08 RID: 44552 RVA: 0x0025F5D4 File Offset: 0x0025D9D4
		public bool IsHaveLimitGift()
		{
			int id = 13;
			int num = 8;
			SwitchClientFunctionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SwitchClientFunctionTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.ValueA;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < num)
			{
				return false;
			}
			List<LimitTimeGiftData> giftsDataInMall = this.GiftDataManager.GetGiftsDataInMall();
			for (int i = 0; i < giftsDataInMall.Count; i++)
			{
				if (giftsDataInMall[i].GiftId != 79001U && giftsDataInMall[i].GiftId != 79000U)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600AE09 RID: 44553 RVA: 0x0025F674 File Offset: 0x0025DA74
		public bool IsHaveLimitTime()
		{
			List<ActivityLimitTimeData> activityLimitTimeDataList = this.LimitTimeManager.activityLimitTimeDataList;
			if (!Utility.IsUnLockFunc(63))
			{
				return false;
			}
			if (activityLimitTimeDataList != null && activityLimitTimeDataList.Count > 0)
			{
				for (int i = 0; i < activityLimitTimeDataList.Count; i++)
				{
					ActivityLimitTimeData activityLimitTimeData = activityLimitTimeDataList[i];
					if (activityLimitTimeData.ActivityState == ActivityState.Start)
					{
						if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_BIND_PHONE)
						{
							if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_GAMBING)
							{
								if (activityLimitTimeData.DataId != 1090U)
								{
									return true;
								}
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600AE0A RID: 44554 RVA: 0x0025F717 File Offset: 0x0025DB17
		public string GetFestivalActivityName()
		{
			return this.BossDataManager.BossActivityBtIconName;
		}

		// Token: 0x0600AE0B RID: 44555 RVA: 0x0025F724 File Offset: 0x0025DB24
		public string GetGiftActivityName()
		{
			return TR.Value("activity_tab_limit_time_gift");
		}

		// Token: 0x0600AE0C RID: 44556 RVA: 0x0025F730 File Offset: 0x0025DB30
		public string GetLimitTimeActivityName()
		{
			return TR.Value("activity_tab_limit_time");
		}

		// Token: 0x0600AE0D RID: 44557 RVA: 0x0025F73C File Offset: 0x0025DB3C
		public bool IsNeedRedPoint()
		{
			return this.IsFestivalNeedRedPoint() || this.IsLimitTimeNeedRedPoint() || this.IsGiftNeedRedPoint();
		}

		// Token: 0x0600AE0E RID: 44558 RVA: 0x0025F760 File Offset: 0x0025DB60
		public bool IsFestivalNeedRedPoint()
		{
			List<ActivityLimitTimeData> activityLimitTimeDataList = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeDataList;
			if (activityLimitTimeDataList != null && activityLimitTimeDataList.Count > 0)
			{
				for (int i = 0; i < activityLimitTimeDataList.Count; i++)
				{
					ActivityLimitTimeData activityLimitTimeData = activityLimitTimeDataList[i];
					if (activityLimitTimeData.ActivityState == ActivityState.Start && activityLimitTimeData.DataId == 1090U)
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
			return this.BossDataManager.IsHasTaskFinished();
		}

		// Token: 0x0600AE0F RID: 44559 RVA: 0x0025F82F File Offset: 0x0025DC2F
		public bool IsLimitTimeNeedRedPoint()
		{
			return this.LimitTimeManager.CheckHasTaskWaitToReceive() || !this.IsCheckedLimitTimeMallGift;
		}

		// Token: 0x0600AE10 RID: 44560 RVA: 0x0025F84D File Offset: 0x0025DC4D
		public bool IsGiftNeedRedPoint()
		{
			return Singleton<LimitTimeBuyActivityManager>.GetInstance().mIsHaveOtherGift && !this.IsCheckedLimitGift;
		}

		// Token: 0x0600AE11 RID: 44561 RVA: 0x0025F86C File Offset: 0x0025DC6C
		public override void Initialize()
		{
			this.Clear();
			this.BossDataManager = new BossActivityDataManager();
			this.BossDataManager.Initialize();
			this.GiftDataManager = new LimitTimeGiftDataManager();
			this.GiftDataManager.Initialize();
			this.LimitTimeManager = new ActivityLimitTimeManager();
			this.LimitTimeManager.Initialize();
			this.IsCheckedLimitGift = false;
			this.IsCheckedLimitTimeMallGift = true;
		}

		// Token: 0x0600AE12 RID: 44562 RVA: 0x0025F8D0 File Offset: 0x0025DCD0
		public override void Clear()
		{
			if (this.BossDataManager != null)
			{
				this.BossDataManager.Clear();
			}
			if (this.GiftDataManager != null)
			{
				this.GiftDataManager.Clear();
			}
			if (this.LimitTimeManager != null)
			{
				this.LimitTimeManager.Clear();
			}
			this.BossDataManager = null;
			this.GiftDataManager = null;
			this.LimitTimeManager = null;
			this.IsCheckedLimitGift = false;
		}

		// Token: 0x0600AE13 RID: 44563 RVA: 0x0025F93B File Offset: 0x0025DD3B
		public void OnUpdate(float timeElapsed)
		{
			if (this.LimitTimeManager != null)
			{
				this.LimitTimeManager.OnUpdate(timeElapsed);
			}
		}

		// Token: 0x04006148 RID: 24904
		public const uint SUMMER_WATERMELON_ID = 1090U;

		// Token: 0x04006149 RID: 24905
		public const int SUMMER_GIFT_ID = 79000;

		// Token: 0x0400614A RID: 24906
		public const int SUMMER_DRINK_ID = 79001;

		// Token: 0x0400614B RID: 24907
		private bool mIsCheckedLimitGift;

		// Token: 0x0400614C RID: 24908
		private bool mIsCheckedLimitTimeMallGift;
	}
}
