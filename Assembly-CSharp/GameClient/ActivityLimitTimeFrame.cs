using System;
using System.Collections.Generic;
using ActivityLimitTime;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018C0 RID: 6336
	public class ActivityLimitTimeFrame : ClientFrame
	{
		// Token: 0x0600F767 RID: 63335 RVA: 0x0042F31C File Offset: 0x0042D71C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeFrame";
		}

		// Token: 0x0600F768 RID: 63336 RVA: 0x0042F324 File Offset: 0x0042D724
		public void CheckSelectActivity()
		{
			this.tabParent.CustomActive(true);
			if (this.mSelectActivityLtTab != null && this.mSummerWatermelonTab != null)
			{
				if (this.mSelectActivityLtTab != null)
				{
					this.mSelectActivityLtTab.SetSelected(true);
				}
				this.mSummerWatermelonTab.SetSelected(false);
			}
		}

		// Token: 0x0600F769 RID: 63337 RVA: 0x0042F378 File Offset: 0x0042D778
		public void ShowSummerWatermelon()
		{
			if (this.frame != null)
			{
				this.frame.CustomActive(true);
				this.frame.transform.SetSiblingIndex(0);
				this.tabParent.CustomActive(false);
				if (this.mSummerWatermelonTab != null)
				{
					this.mSummerWatermelonTab.SetSelected(true);
					if (this.mSelectActivityLtTab != null)
					{
						this.mSelectActivityLtTab.SetSelected(false);
					}
				}
			}
		}

		// Token: 0x0600F76A RID: 63338 RVA: 0x0042F3F0 File Offset: 0x0042D7F0
		protected override void _bindExUI()
		{
			this.tabParent = this.mBind.GetGameObject("TabParent");
			this.tabGroup = this.mBind.GetCom<ToggleGroup>("TabGroup");
			this.noteParent = this.mBind.GetGameObject("NoteParent");
			this.detailParent = this.mBind.GetGameObject("DetailParent");
			this.detailScrollRect = this.mBind.GetCom<ScrollRect>("TaskDetailScroll");
			this.noteInfoGo = this.mBind.GetGameObject("NoteInfo");
			this.mFashionDiscount = this.mBind.GetGameObject("FashionDiscount");
			this.mFashionGoBuy = this.mBind.GetCom<Button>("FashionGoBuy");
			this.mFashionGoBuy.onClick.RemoveAllListeners();
			this.mFashionGoBuy.onClick.AddListener(new UnityAction(this.OnFashionGoBuy));
			this.mFashionDiscountRoot = this.mBind.GetGameObject("FashionDiscountRoot");
			this.mLevelFightRoot = this.mBind.GetGameObject("LevelFightRoot");
			this.mLevelFightShowRoot = this.mBind.GetGameObject("LevelFightShowRoot");
			this.mConsumeLottery = this.mBind.GetGameObject("ConsumeLottery");
			this.mFashionEndTime = this.mBind.GetCom<Text>("FashionEndTime");
			this.mLabel = this.mBind.GetGameObject("label");
			this.mCommonRoot = this.mBind.GetGameObject("CommonRoot");
			this.mNewFrameRoot = this.mBind.GetGameObject("NewFrameRoot");
		}

		// Token: 0x0600F76B RID: 63339 RVA: 0x0042F58C File Offset: 0x0042D98C
		protected override void _unbindExUI()
		{
			this.tabParent = null;
			this.tabGroup = null;
			this.noteParent = null;
			this.detailParent = null;
			this.detailScrollRect = null;
			this.noteInfoGo = null;
			this.mFashionDiscount = null;
			this.mFashionGoBuy = null;
			this.mFashionDiscountRoot = null;
			this.mLevelFightRoot = null;
			this.mLevelFightShowRoot = null;
			this.mConsumeLottery = null;
			this.mFashionEndTime = null;
			this.mLabel = null;
			this.mCommonRoot = null;
			this.mNewFrameRoot = null;
		}

		// Token: 0x0600F76C RID: 63340 RVA: 0x0042F60C File Offset: 0x0042DA0C
		protected override void _OnOpenFrame()
		{
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncActivityDataListener(new Action(this.RefreshAllActivities));
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncTaskDataListener(new Action(this.RefreshAllTasks));
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncTaskDataChangeListener(new Action(this.OnTaskChange));
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncActStateChangeListener(new Action<ActivityLimitTimeData>(this.OnActivityChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnGiftPackChange));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshActivityLimitTimeBtn, new ClientEventSystem.UIEventHandler(this.RefreshFrame));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RanklistUpdated, new ClientEventSystem.UIEventHandler(this._OnRanklistUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			MonoSingleton<ActivityItemObjectManager>.instance.InitPrefabPool(this.frame);
			this.haveInit = false;
			this.haveInitToggle = false;
			this.InitData();
			this.CreateAllActivity();
			this.ShowNoteInfoByTabNull();
		}

		// Token: 0x0600F76D RID: 63341 RVA: 0x0042F724 File Offset: 0x0042DB24
		private void InitData()
		{
			this.fashionDiscount2Open = false;
			this.levelFightOpen = false;
			this.levelFightShowOpen = false;
			this.mLevelFightTime = null;
			this.mRankListRoot = null;
			this.mMyGrade = null;
			this.fashionDiscount2ID = -1;
			this.levelFightEndTime = 0;
			this.haveInitFashionDiscount2 = false;
			this.haveInitlevelFight = false;
			this.haveInitlevelFightShow = false;
			this.haveInitConsumeLottery = false;
			if (this.ranklistAwardList != null)
			{
				this.ranklistAwardList.Clear();
			}
		}

		// Token: 0x0600F76E RID: 63342 RVA: 0x0042F79C File Offset: 0x0042DB9C
		protected override void _OnCloseFrame()
		{
			ActivityLimitTimeManager limitTimeManager = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager;
			if (limitTimeManager != null)
			{
				limitTimeManager.RemoveAllSyncActivityDataListener();
				limitTimeManager.RemoveAllSyncTaskDataListener();
				limitTimeManager.RemoveSyncTaskDataChangeListener(new Action(this.OnTaskChange));
				limitTimeManager.RemoveAllSyncActStateChangeListener();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshActivityLimitTimeBtn, new ClientEventSystem.UIEventHandler(this.RefreshFrame));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RanklistUpdated, new ClientEventSystem.UIEventHandler(this._OnRanklistUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeTaskUpdate, new ClientEventSystem.UIEventHandler(this.OnGiftPackChange));
			this.UnInitPrefabs();
			MonoSingleton<ActivityItemObjectManager>.instance.ReleasePrefabPool();
			this.haveInit = false;
			this.haveInitToggle = false;
			this.mSelectActivityLtTab = null;
			this.ClearData();
		}

		// Token: 0x0600F76F RID: 63343 RVA: 0x0042F878 File Offset: 0x0042DC78
		private void ClearData()
		{
			this.fashionDiscount2Open = false;
			this.levelFightOpen = false;
			this.levelFightShowOpen = false;
			this.mLevelFightTime = null;
			this.mRankListRoot = null;
			this.mMyGrade = null;
			this.fashionDiscount2ID = -1;
			this.levelFightEndTime = 0;
			this.haveInitFashionDiscount2 = false;
			this.haveInitlevelFight = false;
			this.haveInitlevelFightShow = false;
			this.haveInitConsumeLottery = false;
			this.ranklistAwardList.Clear();
			this.setLotteryTextHandler = null;
			this.setCoinTextHandler = null;
			this.setFatigueCoinHandler = null;
			this.setFatigueTicketHanlder = null;
			this.CommonActivityObjDict.Clear();
			this.ReservationUpgradeItemDic.Clear();
			this.CoinExchangeItemDic.Clear();
			this.FatiguelLossBuffItemDic.Clear();
			this.ConsumeLotteryItemDic.Clear();
			this.fatigueBurningGo = null;
		}

		// Token: 0x0600F770 RID: 63344 RVA: 0x0042F940 File Offset: 0x0042DD40
		private void CreateAllActivity()
		{
			List<ActivityLimitTimeData> activityLimitTimeDataList = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeDataList;
			if (activityLimitTimeDataList != null)
			{
				this.activityTabList = new List<ActivityLTTab>();
				for (int i = 0; i < activityLimitTimeDataList.Count; i++)
				{
					ActivityLimitTimeData activityLimitTimeData = activityLimitTimeDataList[i];
					if (activityLimitTimeData.ActivityState == ActivityState.Start)
					{
						if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_BIND_PHONE)
						{
							if (activityLimitTimeData.ActivityType != OpActivityTmpType.OAT_GAMBING)
							{
								if (activityLimitTimeData.activityDetailDataList != null)
								{
									for (int j = 0; j < activityLimitTimeData.activityDetailDataList.Count; j++)
									{
										string[] array = activityLimitTimeData.activityDetailDataList[j].ActivityTaskDesc.Split(new char[]
										{
											'|'
										});
										if (j < array.Length)
										{
											activityLimitTimeData.activityDetailDataList[j].ActivityTaskDesc = array[j];
										}
									}
								}
								ActivityLTTab activityLTTab = new ActivityLTTab();
								if (activityLimitTimeDataList[i].DataId == 1090U)
								{
									this.mSummerWatermelonTab = activityLTTab;
									activityLTTab.Init(null, this, activityLimitTimeDataList[i]);
									activityLTTab.GetGoSelf().CustomActive(false);
								}
								else
								{
									activityLTTab.Init(this.tabParent, this, activityLimitTimeDataList[i]);
									if (!this.haveInitToggle)
									{
										this.haveInitToggle = true;
										activityLTTab.SetSelected(true);
									}
								}
								this.activityTabList.Add(activityLTTab);
								if (activityLimitTimeDataList[i].ActivityType != OpActivityTmpType.OAT_BUY_FASHION && activityLimitTimeDataList[i].ActivityType != OpActivityTmpType.OAT_MALL_DISCOUNT_FOR_NEW_SERVER && activityLimitTimeDataList[i].ActivityType != OpActivityTmpType.OAT_LEVEL_FIGHTING_FOR_NEW_SERVER && activityLimitTimeDataList[i].ActivityType != OpActivityTmpType.OAT_LEVEL_SHOW_FOR_NEW_SERVER)
								{
									this.InitializeViewAtFirst(activityLTTab, activityLimitTimeDataList[i]);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F771 RID: 63345 RVA: 0x0042FB10 File Offset: 0x0042DF10
		private void InitializeViewAtFirst(ActivityLTTab activityTab, ActivityLimitTimeData activityData)
		{
			if (activityData.activityDetailDataList == null)
			{
				return;
			}
			for (int i = 0; i < activityData.activityDetailDataList.Count; i++)
			{
				string[] array = activityData.activityDetailDataList[i].ActivityTaskDesc.Split(new char[]
				{
					'|'
				});
				if (i < array.Length)
				{
					activityData.activityDetailDataList[i].ActivityTaskDesc = array[i];
				}
			}
			if (!this.haveInit)
			{
				this.haveInit = true;
				this.activityLTNote = new ActivityLTNote();
				this.activityLTNote.Init(this.noteParent, this, activityData);
				if (activityData.activityDetailDataList == null)
				{
					return;
				}
				this.activityLTDetailList = new List<ActivityLTDetailContent>();
				for (int j = 0; j < activityData.activityDetailDataList.Count; j++)
				{
					ActivityLTDetailContent activityLTDetailContent = new ActivityLTDetailContent();
					activityLTDetailContent.Init(this.detailParent, this, activityData.activityDetailDataList[j], activityData.ActivityType);
					this.activityLTDetailList.Add(activityLTDetailContent);
				}
			}
		}

		// Token: 0x0600F772 RID: 63346 RVA: 0x0042FC1C File Offset: 0x0042E01C
		private void ShowNoteInfoByTabNull()
		{
			bool bActive = this.CheckIsActivityNull();
			if (this.noteInfoGo)
			{
				this.noteInfoGo.CustomActive(bActive);
			}
		}

		// Token: 0x0600F773 RID: 63347 RVA: 0x0042FC4C File Offset: 0x0042E04C
		private bool CheckIsActivityNull()
		{
			return this.activityTabList == null || this.activityTabList.Count == 0;
		}

		// Token: 0x0600F774 RID: 63348 RVA: 0x0042FC70 File Offset: 0x0042E070
		private void OnFashionFrameChanged(UIEvent uiEvent)
		{
			bool isOpen = (bool)uiEvent.Param1;
			int endTime = (int)uiEvent.Param2;
			this.FashionFrameChange(isOpen, endTime);
		}

		// Token: 0x0600F775 RID: 63349 RVA: 0x0042FC9D File Offset: 0x0042E09D
		public void FashionFrameChange(bool IsOpen, int EndTime)
		{
			this.mFashionEndTime.CustomActive(IsOpen);
			this.mFashionDiscount.CustomActive(IsOpen);
			if (IsOpen)
			{
				this.LastTime = (float)EndTime;
			}
		}

		// Token: 0x0600F776 RID: 63350 RVA: 0x0042FCC5 File Offset: 0x0042E0C5
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600F777 RID: 63351 RVA: 0x0042FCC8 File Offset: 0x0042E0C8
		protected override void _OnUpdate(float _LastTime)
		{
			this.curTime = Time.time;
			if (this.curTime - this.lastTime >= 1f)
			{
				this.SetFashionEndTime();
				this.SetLevelFightTime();
				this.SetFatigueBurningTime();
				this.lastTime = this.curTime;
			}
			this.curTimeRanklist = Time.time;
			if (this.curTime - this.lastTime >= 60f)
			{
				this.UpdateMyGrade();
			}
		}

		// Token: 0x0600F778 RID: 63352 RVA: 0x0042FD40 File Offset: 0x0042E140
		private void SetFashionEndTime()
		{
			int num = (int)this.LastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime();
			int num2 = num / 60 / 60;
			int num3 = num / 60 % 60;
			int num4 = num % 60;
			string arg = string.Empty;
			string arg2 = string.Empty;
			string arg3 = string.Empty;
			if (num2 != 0)
			{
				arg = string.Format("{0}小时", num2);
			}
			if (num3 != 0 || num2 != 0)
			{
				arg2 = string.Format("{0}分", num3);
			}
			if (num4 != 0 || num3 != 0 || num2 != 0)
			{
				arg3 = string.Format("{0}秒", num4);
			}
			this.mFashionEndTime.text = string.Format("剩余时间：{0}{1}{2}", arg, arg2, arg3);
		}

		// Token: 0x0600F779 RID: 63353 RVA: 0x0042FE00 File Offset: 0x0042E200
		private void SetLevelFightTime()
		{
			if (this.levelFightOpen)
			{
				if (this.levelFightEndTime == 0)
				{
					return;
				}
				this.mLevelFightTime.text = Function.SetShowTime(this.levelFightEndTime) + "后排名锁定";
				if (Function.SetShowTime(this.levelFightEndTime) == "0秒")
				{
					SystemNotifyManager.SysNotifyFloatingEffect("活动更新啦", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.ReOpenActivityLimittimeFrame();
				}
			}
		}

		// Token: 0x0600F77A RID: 63354 RVA: 0x0042FE7C File Offset: 0x0042E27C
		private void SetFatigueBurningTime()
		{
			if (this.ordinaryBurningIsOpen && this.ordinaryTime != null)
			{
				if (this.ordinaryLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0)
				{
					this.ordinaryTime.text = Function.GetLastsTimeStr((double)(this.ordinaryLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime()));
					this.ordinaryTime.CustomActive(true);
				}
				else
				{
					this.ordinaryTime.CustomActive(false);
				}
			}
			if (this.advancedBurningIsOpen && this.advancedTime != null)
			{
				if (this.advancedLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0)
				{
					this.advancedTime.text = Function.GetLastsTimeStr((double)(this.advancedLastTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime()));
					this.advancedTime.CustomActive(true);
				}
				else
				{
					this.ordinaryTime.CustomActive(false);
				}
			}
		}

		// Token: 0x0600F77B RID: 63355 RVA: 0x0042FF6D File Offset: 0x0042E36D
		private void setFatigueBurningOrdinaryTime(int tempTime)
		{
			this.ordinaryTime.text = Function.GetLastsTimeStr((double)tempTime);
		}

		// Token: 0x0600F77C RID: 63356 RVA: 0x0042FF81 File Offset: 0x0042E381
		private void setFatigueBurningAdvancedTime(int tempTime)
		{
			this.advancedTime.text = Function.GetLastsTimeStr((double)tempTime);
		}

		// Token: 0x0600F77D RID: 63357 RVA: 0x0042FF95 File Offset: 0x0042E395
		private void UpdateMyGrade()
		{
			if (this.levelFightOpen)
			{
				this._RequestRanklist(100);
			}
		}

		// Token: 0x0600F77E RID: 63358 RVA: 0x0042FFAC File Offset: 0x0042E3AC
		private bool CheckHasRedPointShow()
		{
			if (this.CheckIsActivityNull())
			{
				return false;
			}
			for (int i = 0; i < this.activityTabList.Count; i++)
			{
				if (this.activityTabList[i].IsRedPointShow())
				{
					i = this.activityTabList.Count;
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600F77F RID: 63359 RVA: 0x00430007 File Offset: 0x0042E407
		private void RefreshAllActivities()
		{
			this.UnInitPrefabs();
			this.CreateAllActivity();
			this.ShowNoteInfoByTabNull();
		}

		// Token: 0x0600F780 RID: 63360 RVA: 0x0043001B File Offset: 0x0042E41B
		private void RefreshAllTasks()
		{
		}

		// Token: 0x0600F781 RID: 63361 RVA: 0x0043001D File Offset: 0x0042E41D
		private void OnTaskChange()
		{
			this.RefreshViewOnTasksChanged();
		}

		// Token: 0x0600F782 RID: 63362 RVA: 0x00430025 File Offset: 0x0042E425
		private void OnGiftPackChange(UIEvent uiEvent)
		{
			this.RefreshViewOnTasksChanged();
		}

		// Token: 0x0600F783 RID: 63363 RVA: 0x0043002D File Offset: 0x0042E42D
		private void OnActivityChange(ActivityLimitTimeData changedActData)
		{
			this.RefreshViewOnActivityChange(changedActData);
			this.ShowNoteInfoByTabNull();
		}

		// Token: 0x0600F784 RID: 63364 RVA: 0x0043003C File Offset: 0x0042E43C
		private void UnInitPrefabs()
		{
			if (this.activityTabList != null)
			{
				for (int i = 0; i < this.activityTabList.Count; i++)
				{
					this.activityTabList[i].Destory();
				}
			}
			if (this.activityLTDetailList != null)
			{
				for (int j = 0; j < this.activityLTDetailList.Count; j++)
				{
					this.activityLTDetailList[j].Destory();
				}
			}
			if (this.activityLTNote != null)
			{
				this.activityLTNote.Destory();
			}
			this.activityTabList = null;
			this.activityLTNote = null;
			this.activityLTDetailList = null;
		}

		// Token: 0x0600F785 RID: 63365 RVA: 0x004300E4 File Offset: 0x0042E4E4
		private void OnFashionGoBuy()
		{
			MallNewFrameParamData mallNewFrameParamData = new MallNewFrameParamData();
			mallNewFrameParamData.MallNewType = MallNewType.FashionMall;
			this.frameMgr.OpenFrame<MallNewFrame>(FrameLayer.Middle, mallNewFrameParamData, string.Empty);
		}

		// Token: 0x0600F786 RID: 63366 RVA: 0x00430114 File Offset: 0x0042E514
		public void ResetViewOnTabSelected(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			if (currSelectedTab.GetCurrActivityId() != 1090U)
			{
				this.mSelectActivityLtTab = currSelectedTab;
			}
			if (this.activityLTNote != null)
			{
				this.activityLTNote.RefreshView(currSelectedTab.GetCurrActivityData());
			}
			this.UpdateCommonRootShow(ActivityType);
			this.fashionDiscount2Open = false;
			this.levelFightShowOpen = false;
			this.levelFightOpen = false;
			this.mLevelFightRoot.CustomActive(false);
			this.mLevelFightShowRoot.CustomActive(false);
			this.mFashionDiscountRoot.CustomActive(false);
			this.noteParent.CustomActive(false);
			this.detailParent.CustomActive(false);
			this.mConsumeLottery.CustomActive(false);
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			switch (ActivityType)
			{
			case OpActivityTmpType.OAT_MALL_DISCOUNT_FOR_NEW_SERVER:
				this.mFashionDiscountRoot.CustomActive(true);
				if (!this.haveInitFashionDiscount2)
				{
					this.CreateFashionDiscountFrame(ActivityType, currSelectedTab);
					this.haveInitFashionDiscount2 = true;
				}
				break;
			case OpActivityTmpType.OAT_LEVEL_FIGHTING_FOR_NEW_SERVER:
				this.levelFightOpen = true;
				this.mLevelFightRoot.CustomActive(true);
				if (!this.haveInitlevelFight)
				{
					this.CreateLevelFighting(ActivityType, currSelectedTab);
					this.haveInitlevelFight = true;
				}
				break;
			case OpActivityTmpType.OAT_LEVEL_SHOW_FOR_NEW_SERVER:
				this.levelFightShowOpen = true;
				this.mLevelFightShowRoot.CustomActive(true);
				if (!this.haveInitlevelFightShow)
				{
					this.CreateLevelFightingShow(ActivityType, currSelectedTab);
					this.haveInitlevelFightShow = true;
				}
				break;
			default:
				if (ActivityType != OpActivityTmpType.OAT_BUY_FASHION)
				{
					if (ActivityType != OpActivityTmpType.OAT_DUNGEON_DROP_ACTIVITY && ActivityType != OpActivityTmpType.OAT_DUNGEON_EXP_ADDITION && ActivityType != OpActivityTmpType.OAT_PVP_PK_COIN)
					{
						if (ActivityType != OpActivityTmpType.OAT_APPOINTMENT_OCCU)
						{
							if (ActivityType != OpActivityTmpType.OAT_HELL_TICKET_FOR_DRAW_PRIZE)
							{
								if (ActivityType != OpActivityTmpType.OAT_FATIGUE_FOR_BUFF)
								{
									if (ActivityType != OpActivityTmpType.OAT_FATIGUE_FOR_TOKEN_COIN)
									{
										if (ActivityType != OpActivityTmpType.OAT_FATIGUE_BURNING)
										{
											if (ActivityType != OpActivityTmpType.OAT_DAILY_REWARD && ActivityType != OpActivityTmpType.OAT_LIMIT_TIME_GIFT_PACK)
											{
												this.FashionFrameChange(false, activityEndTime);
												this.noteParent.CustomActive(true);
												this.detailParent.CustomActive(true);
												Dictionary<uint, List<ActivityLimitTimeDetailData>> activityLimitTimeTasksDic = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeTasksDic;
												if (activityLimitTimeTasksDic == null)
												{
													return;
												}
												uint currActivityId = currSelectedTab.GetCurrActivityId();
												OpActivityTmpType activityType = currSelectedTab.GetCurrActivityData().ActivityType;
												if (activityLimitTimeTasksDic.ContainsKey(currActivityId) && this.activityLTDetailList != null)
												{
													for (int i = 0; i < this.activityLTDetailList.Count; i++)
													{
														this.activityLTDetailList[i].Destory();
													}
													this.activityLTDetailList.Clear();
													List<ActivityLimitTimeDetailData> list = activityLimitTimeTasksDic[currActivityId];
													for (int j = 0; j < list.Count; j++)
													{
														ActivityLTDetailContent activityLTDetailContent = new ActivityLTDetailContent();
														activityLTDetailContent.Init(this.detailParent, this, list[j], activityType);
														this.activityLTDetailList.Add(activityLTDetailContent);
													}
												}
											}
										}
										else
										{
											this.CreateFatigueBurning(ActivityType, currSelectedTab);
										}
									}
									else
									{
										this.CreateCoinExchange(ActivityType, currSelectedTab);
									}
								}
								else
								{
									this.CreatFatigueLossBuff(ActivityType, currSelectedTab);
								}
							}
							else
							{
								this.mConsumeLottery.CustomActive(true);
								if (!this.haveInitConsumeLottery)
								{
									this.CreateConsumeLottery(ActivityType, currSelectedTab);
									this.haveInitConsumeLottery = true;
								}
							}
						}
						else
						{
							this.CreateReservationUpgrade(ActivityType, currSelectedTab);
						}
					}
					else
					{
						this.CreatDungeonDropType(ActivityType, currSelectedTab);
					}
				}
				else
				{
					this.FashionFrameChange(true, activityEndTime);
				}
				break;
			}
		}

		// Token: 0x0600F787 RID: 63367 RVA: 0x00430460 File Offset: 0x0042E860
		private void CreateFashionDiscountFrame(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeTasksDic == null)
			{
				return;
			}
			uint currActivityId = currSelectedTab.GetCurrActivityId();
			this.fashionDiscount2ID = (int)currActivityId;
			OpActivityTmpType activityType = currSelectedTab.GetCurrActivityData().ActivityType;
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/FashionDiscount2", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.mFashionDiscountRoot, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Button com = component.GetCom<Button>("GoBuy");
			if (com == null)
			{
				Logger.LogErrorFormat("can not find GoBuy in mBind", new object[0]);
			}
			else
			{
				com.onClick.RemoveAllListeners();
				com.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
					{
						MallNewType = MallNewType.FashionMall
					}, string.Empty);
				});
			}
			Text com2 = component.GetCom<Text>("SellTime");
			if (com2 != null)
			{
				this.fashionDiscount2Open = true;
			}
			if (activityStartTime != 0 && activityEndTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				if (com2 != null)
				{
					com2.text = "活动时间：" + dateTime;
				}
			}
		}

		// Token: 0x0600F788 RID: 63368 RVA: 0x004305C8 File Offset: 0x0042E9C8
		private void CreateLevelFighting(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			Dictionary<uint, List<ActivityLimitTimeDetailData>> activityLimitTimeTasksDic = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeTasksDic;
			if (activityLimitTimeTasksDic == null)
			{
				return;
			}
			uint currActivityId = currSelectedTab.GetCurrActivityId();
			this.fashionDiscount2ID = (int)currActivityId;
			OpActivityTmpType activityType = currSelectedTab.GetCurrActivityData().ActivityType;
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			List<ActivityLimitTimeDetailData> list = activityLimitTimeTasksDic[currActivityId];
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/LevelFightMode", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.mLevelFightRoot, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityRule");
			if (com != null)
			{
				com.text = currActivityData.ActivityRole;
			}
			Text com2 = component.GetCom<Text>("ActivityTime");
			Button com3 = component.GetCom<Button>("GoRankList");
			if (com3 != null)
			{
				com3.onClick.RemoveAllListeners();
				com3.onClick.AddListener(delegate()
				{
					if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RanklistFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<RanklistFrame>(FrameLayer.Middle, null, string.Empty);
					}
				});
			}
			GameObject gameObject2 = component.GetGameObject("AwardPeopleText");
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(false);
			}
			this.levelFightEndTime = (int)currActivityData.ActivityEndTime;
			this.mLevelFightTime = component.GetCom<Text>("LastTime");
			if (this.mLevelFightTime != null)
			{
				this.levelFightOpen = true;
			}
			GameObject gameObject3 = component.GetGameObject("AwardItemRoot");
			if (gameObject3 == null)
			{
				return;
			}
			this.mMyGrade = null;
			this.mMyGrade = component.GetCom<Text>("MyGrade");
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string date = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDate(activityStartTime, activityEndTime);
				if (com2 != null)
				{
					com2.text = "活动时间：" + date;
				}
			}
			this._RequestRanklist(100);
			for (int i = 0; i < list.Count; i++)
			{
				string path = "UIFlatten/Prefabs/OperateActivity/LimitTime/LevelFightItem";
				GameObject gameObject4 = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
				if (gameObject4 == null)
				{
					Logger.LogErrorFormat("预制体路径不正确无法获得LevelFightItem的prefab", new object[0]);
				}
				else
				{
					Utility.AttachTo(gameObject4, gameObject3, false);
					List<ActivityLimitTimeAward> awardDataList = list[i].awardDataList;
					this.CreateLevelFightItem(gameObject4, awardDataList, list[i].ActivityTaskDesc);
				}
			}
		}

		// Token: 0x0600F789 RID: 63369 RVA: 0x00430854 File Offset: 0x0042EC54
		private void CreateLevelFightItem(GameObject fightItem, List<ActivityLimitTimeAward> awardDataList, string rank)
		{
			ComCommonBind component = fightItem.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("Item0");
			if (gameObject != null)
			{
				gameObject.CustomActive(false);
			}
			GameObject gameObject2 = component.GetGameObject("Item1");
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(false);
			}
			GameObject gameObject3 = component.GetGameObject("Item2");
			if (gameObject3 != null)
			{
				gameObject3.CustomActive(false);
			}
			GameObject gameObject4 = component.GetGameObject("Item3");
			if (gameObject4 != null)
			{
				gameObject4.CustomActive(false);
			}
			GameObject gameObject5 = component.GetGameObject("Item4");
			if (gameObject5 != null)
			{
				gameObject5.CustomActive(false);
			}
			GameObject[] array = new GameObject[]
			{
				gameObject,
				gameObject2,
				gameObject3,
				gameObject4,
				gameObject5
			};
			for (int i = 0; i < awardDataList.Count; i++)
			{
				if (i >= array.Length)
				{
					return;
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)awardDataList[i].Id, 100, 0);
				if (itemData == null)
				{
					Logger.LogErrorFormat("ItemData is null", new object[0]);
				}
				else
				{
					array[i].CustomActive(true);
					itemData.Count = awardDataList[i].Num;
					ComItem comItem = array[i].GetComponentInChildren<ComItem>();
					if (comItem == null)
					{
						comItem = base.CreateComItem(array[i]);
					}
					int result = (int)awardDataList[i].Id;
					comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
					{
						this.OnShowTips(result);
					});
				}
			}
			Text com = component.GetCom<Text>("Name");
			if (com != null)
			{
				com.CustomActive(false);
			}
			Text com2 = component.GetCom<Text>("Grade");
			if (com2 != null)
			{
				com2.text = rank;
			}
		}

		// Token: 0x0600F78A RID: 63370 RVA: 0x00430A50 File Offset: 0x0042EE50
		private void OnShowTips(int result)
		{
			ItemData a_item = ItemDataManager.CreateItemDataFromTable(result, 100, 0);
			DataManager<ItemTipManager>.GetInstance().ShowTip(a_item, null, 4, true, false, true);
		}

		// Token: 0x0600F78B RID: 63371 RVA: 0x00430A78 File Offset: 0x0042EE78
		private void CreateLevelFightingShow(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			Dictionary<uint, List<ActivityLimitTimeDetailData>> activityLimitTimeTasksDic = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeTasksDic;
			if (activityLimitTimeTasksDic == null)
			{
				return;
			}
			uint currActivityId = currSelectedTab.GetCurrActivityId();
			this.fashionDiscount2ID = (int)currActivityId;
			OpActivityTmpType activityType = currSelectedTab.GetCurrActivityData().ActivityType;
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			List<ActivityLimitTimeDetailData> list = activityLimitTimeTasksDic[currActivityId];
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/LevelFightMode", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.mLevelFightShowRoot, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityRule");
			if (com != null)
			{
				com.text = currActivityData.ActivityRole;
			}
			Button com2 = component.GetCom<Button>("GoRankList");
			com2.CustomActive(false);
			this.levelFightEndTime = (int)currActivityData.ActivityEndTime;
			this.mLevelFightTime = component.GetCom<Text>("LastTime");
			if (this.mLevelFightTime != null)
			{
				this.mLevelFightTime.text = "前" + list.Count + "名奖励已通过邮件发放";
			}
			this.mRankListRoot = component.GetGameObject("AwardItemRoot");
			if (this.mRankListRoot == null)
			{
				return;
			}
			GameObject gameObject2 = component.GetGameObject("AwardPeopleText");
			if (gameObject2 != null)
			{
				gameObject2.CustomActive(true);
			}
			this.mMyGrade = null;
			this.mMyGrade = component.GetCom<Text>("MyGrade");
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string date = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDate(activityStartTime, activityEndTime);
				Text com3 = component.GetCom<Text>("ActivityTime");
				if (com3 != null)
				{
					com3.text = "活动时间：" + date;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				List<ActivityLimitTimeAward> awardDataList = list[i].awardDataList;
				this.ranklistAwardList.Add(awardDataList);
			}
			if (list.Count < 100)
			{
				this._RequestRanklist(list.Count);
			}
			else
			{
				this._RequestRanklist(100);
			}
		}

		// Token: 0x0600F78C RID: 63372 RVA: 0x00430CC4 File Offset: 0x0042F0C4
		private void CreatDungeonDropType(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			if (ActivityType == OpActivityTmpType.OAT_DUNGEON_DROP_ACTIVITY)
			{
				if (!this.CreateCommonActivityObj(ActivityType, "UIFlatten/Prefabs/OperateActivity/LimitTime/DungeonDropType"))
				{
				}
			}
			else if (!this.CreateCommonActivityObj(ActivityType, "UIFlatten/Prefabs/OperateActivity/LimitTime/DungeonDropType"))
			{
				return;
			}
			GameObject activityObj = this.GetActivityObj(ActivityType);
			if (activityObj == null)
			{
				return;
			}
			activityObj.name = ActivityType.ToString();
			ComCommonBind component = activityObj.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityTime");
			Text com2 = component.GetCom<Text>("ActivityRule");
			GameObject gameObject = component.GetGameObject("Content");
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				com.text = dateTime;
			}
			com2.text = currActivityData.ActivityRole;
			this.CreatDungeonDropTypeItem(gameObject, currActivityData);
		}

		// Token: 0x0600F78D RID: 63373 RVA: 0x00430DC4 File Offset: 0x0042F1C4
		private void CreatDungeonDropTypeItem(GameObject root, ActivityLimitTimeData activityLimittimeData)
		{
			ComCommonBind[] componentsInChildren = root.GetComponentsInChildren<ComCommonBind>();
			if (componentsInChildren.Length > 0)
			{
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					Object.Destroy(componentsInChildren[i].gameObject);
				}
			}
			for (int j = 0; j < activityLimittimeData.activityDetailDataList.Count; j++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData = activityLimittimeData.activityDetailDataList[j];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/DungeonDropTypeItem", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				Utility.AttachTo(gameObject, root, false);
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Text com = component.GetCom<Text>("Name");
				Text com2 = component.GetCom<Text>("Des");
				Button com3 = component.GetCom<Button>("ChallengeBtn");
				List<GameObject> list = new List<GameObject>();
				list.Add(component.GetGameObject("root0"));
				list.Add(component.GetGameObject("root1"));
				list.Add(component.GetGameObject("root2"));
				list.Add(component.GetGameObject("root3"));
				list.Add(component.GetGameObject("root4"));
				list.Add(component.GetGameObject("root5"));
				for (int k = 0; k < activityLimitTimeDetailData.awardDataList.Count; k++)
				{
					if (k < list.Count)
					{
						ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)activityLimitTimeDetailData.awardDataList[k].Id, 100, 0);
						if (ItemDetailData == null)
						{
							Logger.LogErrorFormat("ItemData is null", new object[0]);
							return;
						}
						ItemDetailData.Count = activityLimitTimeDetailData.awardDataList[k].Num;
						list[k].CustomActive(true);
						ComItem comItem = base.CreateComItem(list[k]);
						comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
						{
							DataManager<ItemTipManager>.GetInstance().ShowTip(ItemDetailData, null, 4, true, false, true);
						});
					}
				}
				if (activityLimitTimeDetailData.ParamNums.Count <= 0)
				{
					return;
				}
				int id = activityLimitTimeDetailData.ParamNums[0];
				AcquiredMethodTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AcquiredMethodTable>(id, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				string mLinkInfo = tableItem.LinkInfo;
				com.text = tableItem.Name;
				com2.text = activityLimitTimeDetailData.ActivityTaskDesc;
				com3.onClick.RemoveAllListeners();
				com3.onClick.AddListener(delegate()
				{
					DataManager<ActiveManager>.GetInstance().OnClickLinkInfo(mLinkInfo, null, false);
				});
			}
		}

		// Token: 0x0600F78E RID: 63374 RVA: 0x00431074 File Offset: 0x0042F474
		private void CreateCoinExchange(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			if (!this.CreateCommonActivityObj(ActivityType, "UIFlatten/Prefabs/OperateActivity/LimitTime/CoinExchange"))
			{
				return;
			}
			GameObject activityObj = this.GetActivityObj(ActivityType);
			if (activityObj == null)
			{
				return;
			}
			ComCommonBind component = activityObj.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityTime");
			Text com2 = component.GetCom<Text>("ActivityRule");
			Text mCoinNum = component.GetCom<Text>("CoinNum");
			GameObject gameObject = component.GetGameObject("Content");
			Text mFatigueNum = component.GetCom<Text>("FatigueNum");
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				com.text = dateTime;
			}
			com2.text = currActivityData.ActivityRole;
			this.setFatigueCoinHandler = delegate(string str)
			{
				if (mCoinNum)
				{
					mCoinNum.text = str;
				}
			};
			string text = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM).ToString();
			mCoinNum.text = text;
			this.setFatigueTicketHanlder = delegate(string str)
			{
				if (mFatigueNum)
				{
					mFatigueNum.text = str;
				}
			};
			string text2 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_FATIGUE_TICKET_NUM).ToString();
			mFatigueNum.text = text2;
			this.CreateCoinExchangeItem(gameObject, currActivityData);
		}

		// Token: 0x0600F78F RID: 63375 RVA: 0x004311E8 File Offset: 0x0042F5E8
		private void CreateCoinExchangeItem(GameObject root, ActivityLimitTimeData activityLimittimeData)
		{
			for (int i = 0; i < activityLimittimeData.activityDetailDataList.Count; i++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData = activityLimittimeData.activityDetailDataList[i];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/CoinExchangeItem", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				Utility.AttachTo(gameObject, root, false);
				if (!this.CoinExchangeItemDic.ContainsKey(activityLimitTimeDetailData.DataId))
				{
					this.CoinExchangeItemDic[activityLimitTimeDetailData.DataId] = gameObject;
				}
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				uint activityId = activityLimittimeData.DataId;
				uint ordinaryTaskId = activityLimitTimeDetailData.DataId;
				Button com = component.GetCom<Button>("ReceiveBtn");
				com.onClick.AddListener(delegate()
				{
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, ordinaryTaskId);
				});
				Button com2 = component.GetCom<Button>("ReceivedBtnBlue");
				com2.onClick.AddListener(delegate()
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("activity_cannot_exchange_tips"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				});
				GameObject gameObject2 = component.GetGameObject("ReceiveBtnGray");
				Text com3 = component.GetCom<Text>("CoinCount");
				List<GameObject> list = new List<GameObject>();
				list.Add(component.GetGameObject("root0"));
				list.Add(component.GetGameObject("root1"));
				list.Add(component.GetGameObject("root2"));
				list.Add(component.GetGameObject("root3"));
				list.Add(component.GetGameObject("root4"));
				for (int j = 0; j < activityLimitTimeDetailData.awardDataList.Count; j++)
				{
					if (j < 5)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)activityLimitTimeDetailData.awardDataList[j].Id, 100, 0);
						if (itemData == null)
						{
							Logger.LogErrorFormat("ItemData is null", new object[0]);
							return;
						}
						itemData.Count = activityLimitTimeDetailData.awardDataList[j].Num;
						list[j].CustomActive(true);
						ComItem comItem = base.CreateComItem(list[j]);
						int result = (int)activityLimitTimeDetailData.awardDataList[j].Id;
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
			}
			this.UpdateCoinExchangeData(activityLimittimeData);
		}

		// Token: 0x0600F790 RID: 63376 RVA: 0x00431464 File Offset: 0x0042F864
		private void UpdateCoinExchangeData(ActivityLimitTimeData activityData)
		{
			for (int i = 0; i < activityData.activityDetailDataList.Count; i++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData = activityData.activityDetailDataList[i];
				if (this.CoinExchangeItemDic.ContainsKey(activityLimitTimeDetailData.DataId))
				{
					GameObject gameObject = this.CoinExchangeItemDic[activityLimitTimeDetailData.DataId];
					ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
					if (component == null)
					{
						return;
					}
					Text com = component.GetCom<Text>("DoneText");
					Button com2 = component.GetCom<Button>("ReceiveBtn");
					Button com3 = component.GetCom<Button>("ReceivedBtnBlue");
					GameObject gameObject2 = component.GetGameObject("ReceiveBtnGray");
					Text com4 = component.GetCom<Text>("CoinCount");
					Text mCoinNum = component.GetCom<Text>("CoinNum");
					if (activityLimitTimeDetailData.ActivityDetailState == ActivityTaskState.Over)
					{
						com.text = string.Format("{0}/{1}", 0, activityLimitTimeDetailData.TotalNum);
					}
					else
					{
						com.text = string.Format("{0}/{1}", activityLimitTimeDetailData.DoneNum, activityLimitTimeDetailData.TotalNum);
					}
					int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM);
					List<int> paramNumList = activityLimitTimeDetailData.ParamNums;
					if (paramNumList.Count != 0)
					{
						com4.text = string.Format("/{0}", paramNumList[0]);
						mCoinNum.text = string.Format("{0}", count);
						if (count < paramNumList[0])
						{
							mCoinNum.color = Color.red;
						}
						else
						{
							mCoinNum.color = Color.green;
						}
						this.setFatigueCoinHandler = (ActivityLimitTimeFrame.SetFatigueCoin)Delegate.Combine(this.setFatigueCoinHandler, new ActivityLimitTimeFrame.SetFatigueCoin(delegate(string str)
						{
							if (mCoinNum)
							{
								mCoinNum.text = str;
							}
							if (DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM) < paramNumList[0])
							{
								mCoinNum.color = Color.red;
							}
							else
							{
								mCoinNum.color = Color.green;
							}
						}));
						com2.CustomActive(false);
						com3.CustomActive(false);
						gameObject2.CustomActive(false);
						ActivityTaskState activityDetailState = activityLimitTimeDetailData.ActivityDetailState;
						if (activityDetailState != ActivityTaskState.Finished)
						{
							if (activityDetailState != ActivityTaskState.UnFinish)
							{
								if (activityDetailState == ActivityTaskState.Over)
								{
									gameObject2.CustomActive(true);
								}
							}
							else
							{
								com3.CustomActive(true);
							}
						}
						else
						{
							com2.CustomActive(true);
						}
					}
				}
			}
		}

		// Token: 0x0600F791 RID: 63377 RVA: 0x004316C8 File Offset: 0x0042FAC8
		private void CreateReservationUpgrade(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			if (!this.CreateCommonActivityObj(ActivityType, "UIFlatten/Prefabs/OperateActivity/LimitTime/ReservationUpgrade"))
			{
				return;
			}
			GameObject activityObj = this.GetActivityObj(ActivityType);
			if (activityObj == null)
			{
				return;
			}
			ComCommonBind component = activityObj.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityTime");
			Text com2 = component.GetCom<Text>("ActivityRule");
			Text mCoinNum = component.GetCom<Text>("CoinNum");
			Button com3 = component.GetCom<Button>("goShop");
			com3.onClick.RemoveAllListeners();
			com3.onClick.AddListener(delegate()
			{
				ShopFrame.OpenLinkFrame("12|0|1");
			});
			GameObject gameObject = component.GetGameObject("Content");
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				com.text = dateTime;
			}
			com2.text = currActivityData.ActivityRole;
			this.setCoinTextHandler = delegate(string str)
			{
				if (mCoinNum)
				{
					mCoinNum.text = str;
				}
			};
			string text = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_COIN_NUM).ToString();
			mCoinNum.text = text;
			this.CreateReservationItem(gameObject, currActivityData);
		}

		// Token: 0x0600F792 RID: 63378 RVA: 0x0043182C File Offset: 0x0042FC2C
		private void CreateReservationItem(GameObject root, ActivityLimitTimeData activityLimittimeData)
		{
			for (int i = 0; i < activityLimittimeData.activityDetailDataList.Count; i++)
			{
				ActivityLimitTimeDetailData currActivityData = activityLimittimeData.activityDetailDataList[i];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/ReservationUpgradeItem", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				Utility.AttachTo(gameObject, root, false);
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Text com = component.GetCom<Text>("DescText");
				Text com2 = component.GetCom<Text>("DoneText");
				Button com3 = component.GetCom<Button>("ReceiveBtn");
				if (com3)
				{
					com3.onClick.RemoveAllListeners();
					com3.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityLimittimeData.DataId, currActivityData.DataId);
					});
				}
				GameObject gameObject2 = component.GetGameObject("ReceiveBtnGo");
				GameObject gameObject3 = component.GetGameObject("ReceivedImgGo");
				GameObject gameObject4 = component.GetGameObject("UnDoneImgGo");
				GameObject gameObject5 = component.GetGameObject("UnAppointmentRole");
				List<GameObject> list = new List<GameObject>();
				list.Add(component.GetGameObject("root0"));
				list.Add(component.GetGameObject("root1"));
				list.Add(component.GetGameObject("root2"));
				list.Add(component.GetGameObject("root3"));
				list.Add(component.GetGameObject("root4"));
				if (DataManager<PlayerBaseData>.GetInstance().appointmentOccu == 1)
				{
					if (currActivityData.ActivityDetailState == ActivityTaskState.Over)
					{
						com2.text = string.Format("<color=#00FF56FF>{0}</color>/{1}", currActivityData.TotalNum, currActivityData.TotalNum);
						gameObject2.CustomActive(false);
						gameObject4.CustomActive(false);
						gameObject5.CustomActive(false);
						gameObject3.CustomActive(true);
					}
					else if (currActivityData.ActivityDetailState == ActivityTaskState.Finished)
					{
						com2.text = string.Format("<color=#00FF56FF>{0}</color>/{1}", currActivityData.TotalNum, currActivityData.TotalNum);
						gameObject4.CustomActive(false);
						gameObject3.CustomActive(false);
						gameObject5.CustomActive(false);
						gameObject2.CustomActive(true);
					}
					else
					{
						com2.text = string.Format("<color=#AE0000FF>{0}</color>/{1}", currActivityData.DoneNum, currActivityData.TotalNum);
						gameObject4.CustomActive(true);
						gameObject3.CustomActive(false);
						gameObject5.CustomActive(false);
						gameObject2.CustomActive(false);
					}
				}
				else if (currActivityData.ActivityDetailState == ActivityTaskState.Over)
				{
					com2.text = string.Format("{0}/{1}", currActivityData.TotalNum, currActivityData.TotalNum);
					gameObject2.CustomActive(false);
					gameObject4.CustomActive(false);
					gameObject5.CustomActive(true);
					gameObject3.CustomActive(false);
				}
				else if (currActivityData.ActivityDetailState == ActivityTaskState.Finished)
				{
					com2.text = string.Format("{0}/{1}", currActivityData.TotalNum, currActivityData.TotalNum);
					gameObject4.CustomActive(false);
					gameObject3.CustomActive(false);
					gameObject5.CustomActive(true);
					gameObject2.CustomActive(false);
				}
				else
				{
					com2.text = string.Format("{0}/{1}", currActivityData.DoneNum, currActivityData.TotalNum);
					gameObject4.CustomActive(false);
					gameObject3.CustomActive(false);
					gameObject5.CustomActive(true);
					gameObject2.CustomActive(false);
				}
				com.text = currActivityData.ActivityTaskDesc;
				for (int j = 0; j < currActivityData.awardDataList.Count; j++)
				{
					if (j < list.Count)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)currActivityData.awardDataList[j].Id, 100, 0);
						if (itemData == null)
						{
							Logger.LogErrorFormat("ItemData is null", new object[0]);
							return;
						}
						itemData.Count = currActivityData.awardDataList[j].Num;
						list[j].CustomActive(true);
						ComItem comItem = base.CreateComItem(list[j]);
						int result = (int)currActivityData.awardDataList[j].Id;
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
				this.ReservationUpgradeItemDic.Add(currActivityData.DataId, gameObject);
			}
			for (int k = 0; k < activityLimittimeData.activityDetailDataList.Count; k++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData = activityLimittimeData.activityDetailDataList[k];
				if (activityLimitTimeDetailData.ActivityDetailState == ActivityTaskState.Over)
				{
					GameObject gameObject6 = this.ReservationUpgradeItemDic[activityLimitTimeDetailData.DataId];
					if (gameObject6 != null)
					{
						gameObject6.transform.SetAsLastSibling();
					}
				}
			}
			if (DataManager<PlayerBaseData>.GetInstance().appointmentOccu != 1)
			{
				GameObject gameObject7 = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/CreatAppoinmentRoleRoot", true, 0U);
				if (gameObject7 == null)
				{
					return;
				}
				Utility.AttachTo(gameObject7, root, false);
				ComCommonBind component2 = gameObject7.GetComponent<ComCommonBind>();
				if (component2 == null)
				{
					return;
				}
				Button com4 = component2.GetCom<Button>("CreatRole");
				com4.onClick.RemoveAllListeners();
				com4.onClick.AddListener(delegate()
				{
					RoleSwitchReq cmd = new RoleSwitchReq();
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<RoleSwitchReq>(ServerType.GATE_SERVER, cmd);
					ClientSystemLogin.mSwitchRole = true;
					Singleton<SDKVoiceManager>.GetInstance().LeaveVoiceSDK(false);
				});
			}
		}

		// Token: 0x0600F793 RID: 63379 RVA: 0x00431E40 File Offset: 0x00430240
		private void CreatFatigueLossBuff(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			if (!this.CreateCommonActivityObj(ActivityType, "UIFlatten/Prefabs/OperateActivity/LimitTime/FatigueLossBuff"))
			{
				return;
			}
			GameObject activityObj = this.GetActivityObj(ActivityType);
			if (activityObj == null)
			{
				return;
			}
			ComCommonBind component = activityObj.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityTime");
			Text com2 = component.GetCom<Text>("ActivityRule");
			GameObject gameObject = component.GetGameObject("Content");
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				com.text = dateTime;
			}
			com2.text = currActivityData.ActivityRole;
			this.CreatFatigueLossBuffItem(gameObject, currActivityData);
		}

		// Token: 0x0600F794 RID: 63380 RVA: 0x00431F0C File Offset: 0x0043030C
		private void CreatFatigueLossBuffItem(GameObject root, ActivityLimitTimeData activityLimittimeData)
		{
			for (int i = 0; i < activityLimittimeData.activityDetailDataList.Count; i++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData = activityLimittimeData.activityDetailDataList[i];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/FatigueLossBuffItem", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				Utility.AttachTo(gameObject, root, false);
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Text com = component.GetCom<Text>("DescText");
				Text com2 = component.GetCom<Text>("DoneText");
				Image com3 = component.GetCom<Image>("Icon");
				Text com4 = component.GetCom<Text>("bonusDes");
				GameObject gameObject2 = component.GetGameObject("ReceivedImgGo");
				GameObject gameObject3 = component.GetGameObject("UnDoneImgGo");
				GameObject gameObject4 = component.GetGameObject("ToReplace");
				com.text = activityLimitTimeDetailData.ActivityTaskDesc;
				if (activityLimitTimeDetailData.ActivityDetailState == ActivityTaskState.Over)
				{
					com2.text = string.Format("{0}/{1}", activityLimitTimeDetailData.TotalNum, activityLimitTimeDetailData.TotalNum);
					gameObject2.CustomActive(false);
					gameObject3.CustomActive(false);
					gameObject4.CustomActive(true);
				}
				else if (activityLimitTimeDetailData.ActivityDetailState == ActivityTaskState.Finished)
				{
					com2.text = string.Format("{0}/{1}", activityLimitTimeDetailData.TotalNum, activityLimitTimeDetailData.TotalNum);
					gameObject2.CustomActive(true);
					gameObject3.CustomActive(false);
					gameObject4.CustomActive(false);
				}
				else
				{
					com2.text = string.Format("{0}/{1}", activityLimitTimeDetailData.DoneNum, activityLimitTimeDetailData.TotalNum);
					gameObject3.CustomActive(true);
					gameObject2.CustomActive(false);
					gameObject4.CustomActive(false);
				}
				OpActivityTaskTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<OpActivityTaskTable>((int)activityLimitTimeDetailData.DataId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				int id = 0;
				int.TryParse(tableItem.TaskVar.ToString(), out id);
				BuffTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<BuffTable>(id, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				ETCImageLoader.LoadSprite(ref com3, tableItem2.Icon, true);
				com4.text = tableItem2.Name;
				this.FatiguelLossBuffItemDic.Add(activityLimitTimeDetailData.DataId, gameObject);
			}
			for (int j = 0; j < activityLimittimeData.activityDetailDataList.Count; j++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData2 = activityLimittimeData.activityDetailDataList[j];
				if (activityLimitTimeDetailData2.ActivityDetailState == ActivityTaskState.Over)
				{
					GameObject gameObject5 = this.FatiguelLossBuffItemDic[activityLimitTimeDetailData2.DataId];
					if (gameObject5 != null)
					{
						gameObject5.transform.SetAsLastSibling();
					}
				}
			}
		}

		// Token: 0x0600F795 RID: 63381 RVA: 0x004321B8 File Offset: 0x004305B8
		private void CreateFatigueBurning(OpActivityTmpType activityType, ActivityLTTab currSelectedTab)
		{
			if (currSelectedTab.GetCurrActivityData() != null && currSelectedTab != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.OnSceneOpActivityTaskInfoReq(currSelectedTab.GetCurrActivityData().DataId);
			}
			if (!this.CreateCommonActivityObj(activityType, "UIFlatten/Prefabs/OperateActivity/LimitTime/FatigueBurning"))
			{
				return;
			}
			GameObject activityObj = this.GetActivityObj(activityType);
			this.fatigueBurningGo = activityObj;
			if (activityObj == null)
			{
				return;
			}
			ComCommonBind component = activityObj.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			if (currActivityData == null)
			{
				return;
			}
			if (currActivityData.activityDetailDataList == null)
			{
				return;
			}
			if (currActivityData.activityDetailDataList.Count < 2)
			{
				return;
			}
			uint activityId = currActivityData.DataId;
			uint ordinaryTaskId = currActivityData.activityDetailDataList[0].DataId;
			uint advancedTaskId = currActivityData.activityDetailDataList[1].DataId;
			Text com = component.GetCom<Text>("activityTime");
			Text com2 = component.GetCom<Text>("activityRule");
			Text com3 = component.GetCom<Text>("ordinaryTime");
			SetButtonGrayCD mOrdinaryCD = component.GetCom<SetButtonGrayCD>("ordinaryCD");
			this.ordinaryTime = com3;
			Text com4 = component.GetCom<Text>("ordinaryGold");
			Image com5 = component.GetCom<Image>("ordinaryGoldIcon");
			List<int> paramNums = currActivityData.activityDetailDataList[0].ParamNums;
			int id = paramNums[0];
			ItemTable ordinaryItemTabledata = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id, string.Empty, string.Empty);
			if (paramNums.Count > 1)
			{
				com4.text = paramNums[1].ToString();
				if (ordinaryItemTabledata != null)
				{
					ETCImageLoader.LoadSprite(ref com5, ordinaryItemTabledata.Icon, true);
				}
			}
			int ordinaryItemCount = paramNums[1];
			string ordinaryItemName = ordinaryItemTabledata.Name;
			Button com6 = component.GetCom<Button>("ordinaryOpen");
			com6.onClick.RemoveAllListeners();
			com6.onClick.AddListener(delegate()
			{
				if (this.advancedActivityOpen)
				{
					SystemNotifyManager.SystemNotify(9054, string.Empty);
				}
				else
				{
					string msgContent = string.Format(TR.Value("activity_fatigue_burning_buy_text"), ordinaryItemCount, ordinaryItemName);
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
						costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ordinaryItemTabledata.SubType);
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						costInfo.nCount = ordinaryItemCount;
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, ordinaryTaskId);
							mOrdinaryCD.StartGrayCD();
						}, "common_money_cost", null);
					}, null, 0f, false);
				}
			});
			Button com7 = component.GetCom<Button>("ordinaryFreeze");
			com7.onClick.RemoveAllListeners();
			com7.onClick.AddListener(delegate()
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, ordinaryTaskId);
				mOrdinaryCD.StartGrayCD();
			});
			Button com8 = component.GetCom<Button>("ordinaryThaw");
			com8.onClick.RemoveAllListeners();
			com8.onClick.AddListener(delegate()
			{
				if (this.advancedActivityOpen)
				{
					SystemNotifyManager.SystemNotify(9054, string.Empty);
				}
				else
				{
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, ordinaryTaskId);
					mOrdinaryCD.StartGrayCD();
				}
			});
			Text com9 = component.GetCom<Text>("advancedTime");
			SetButtonGrayCD mAdvancedCD = component.GetCom<SetButtonGrayCD>("advancedCD");
			this.advancedTime = com9;
			Text com10 = component.GetCom<Text>("advancedGold");
			Image com11 = component.GetCom<Image>("advancedGoldIcon");
			List<int> paramNums2 = currActivityData.activityDetailDataList[1].ParamNums;
			int id2 = paramNums2[0];
			ItemTable advancedItemTabledata = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(id2, string.Empty, string.Empty);
			if (paramNums2.Count > 1)
			{
				com10.text = paramNums2[1].ToString();
				if (advancedItemTabledata != null)
				{
					ETCImageLoader.LoadSprite(ref com11, advancedItemTabledata.Icon, true);
				}
			}
			int advancedItemCount = paramNums2[1];
			string advancedItemName = advancedItemTabledata.Name;
			Button com12 = component.GetCom<Button>("advancedOpen");
			com12.onClick.RemoveAllListeners();
			com12.onClick.AddListener(delegate()
			{
				if (this.ordinaryActivityOpen)
				{
					SystemNotifyManager.SystemNotify(9054, string.Empty);
				}
				else
				{
					string msgContent = string.Format(TR.Value("activity_fatigue_burning_buy_text"), advancedItemCount, advancedItemName);
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
						costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(advancedItemTabledata.SubType);
						DataManager<ItemTipManager>.GetInstance().CloseAll();
						costInfo.nCount = advancedItemCount;
						DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
						{
							DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, advancedTaskId);
							mAdvancedCD.StartGrayCD();
						}, "common_money_cost", null);
					}, null, 0f, false);
				}
			});
			Button com13 = component.GetCom<Button>("advancedFreeze");
			com13.onClick.RemoveAllListeners();
			com13.onClick.AddListener(delegate()
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, advancedTaskId);
				mAdvancedCD.StartGrayCD();
			});
			Button com14 = component.GetCom<Button>("advancedThaw");
			com14.onClick.RemoveAllListeners();
			com14.onClick.AddListener(delegate()
			{
				if (this.ordinaryActivityOpen)
				{
					SystemNotifyManager.SystemNotify(9054, string.Empty);
				}
				else
				{
					DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, advancedTaskId);
					mAdvancedCD.StartGrayCD();
				}
			});
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				com.text = dateTime;
			}
			com2.text = currActivityData.ActivityRole;
			this.updateFatigueBurningData(currActivityData);
		}

		// Token: 0x0600F796 RID: 63382 RVA: 0x004325FC File Offset: 0x004309FC
		private void updateFatigueBurningData(ActivityLimitTimeData activityData)
		{
			ComCommonBind component = this.fatigueBurningGo.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.ordinaryActivityOpen = false;
			this.advancedActivityOpen = false;
			GameObject gameObject = component.GetGameObject("ordinaryPrice");
			Text com = component.GetCom<Text>("ordinaryTime");
			Button com2 = component.GetCom<Button>("ordinaryOpen");
			Button com3 = component.GetCom<Button>("ordinaryFreeze");
			Button com4 = component.GetCom<Button>("ordinaryThaw");
			GameObject gameObject2 = component.GetGameObject("advancedPrice");
			Text com5 = component.GetCom<Text>("advancedTime");
			Button com6 = component.GetCom<Button>("advancedOpen");
			Button com7 = component.GetCom<Button>("advancedFreeze");
			Button com8 = component.GetCom<Button>("advancedThaw");
			ActivityLimitTimeDetailData activityLimitTimeDetailData = activityData.activityDetailDataList[0];
			com2.CustomActive(false);
			com3.CustomActive(false);
			com4.CustomActive(false);
			gameObject.CustomActive(false);
			com.CustomActive(false);
			this.ordinaryBurningIsOpen = false;
			switch (activityLimitTimeDetailData.ActivityDetailState)
			{
			case ActivityTaskState.Init:
			case ActivityTaskState.UnFinish:
				gameObject.CustomActive(true);
				com2.CustomActive(true);
				break;
			case ActivityTaskState.Finished:
				com3.CustomActive(true);
				com.CustomActive(true);
				this.ordinaryBurningIsOpen = true;
				this.ordinaryActivityOpen = true;
				this.ordinaryLastTime = activityLimitTimeDetailData.DoneNum;
				break;
			case ActivityTaskState.Failed:
				this.setFatigueBurningOrdinaryTime(activityLimitTimeDetailData.DoneNum);
				com4.CustomActive(true);
				com.CustomActive(true);
				break;
			}
			ActivityLimitTimeDetailData activityLimitTimeDetailData2 = activityData.activityDetailDataList[1];
			com6.CustomActive(false);
			com7.CustomActive(false);
			com8.CustomActive(false);
			gameObject2.CustomActive(false);
			com5.CustomActive(false);
			this.advancedBurningIsOpen = false;
			switch (activityLimitTimeDetailData2.ActivityDetailState)
			{
			case ActivityTaskState.Init:
			case ActivityTaskState.UnFinish:
				gameObject2.CustomActive(true);
				com6.CustomActive(true);
				break;
			case ActivityTaskState.Finished:
				com7.CustomActive(true);
				com5.CustomActive(true);
				this.advancedBurningIsOpen = true;
				this.advancedActivityOpen = true;
				this.advancedLastTime = activityLimitTimeDetailData2.DoneNum;
				break;
			case ActivityTaskState.Failed:
				com8.CustomActive(true);
				com5.CustomActive(true);
				this.setFatigueBurningAdvancedTime(activityLimitTimeDetailData2.DoneNum);
				break;
			}
		}

		// Token: 0x0600F797 RID: 63383 RVA: 0x0043283C File Offset: 0x00430C3C
		private void CreateConsumeLottery(OpActivityTmpType ActivityType, ActivityLTTab currSelectedTab)
		{
			Dictionary<uint, List<ActivityLimitTimeDetailData>> activityLimitTimeTasksDic = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeTasksDic;
			if (activityLimitTimeTasksDic == null)
			{
				return;
			}
			uint currActivityId = currSelectedTab.GetCurrActivityId();
			this.fashionDiscount2ID = (int)currActivityId;
			OpActivityTmpType activityType = currSelectedTab.GetCurrActivityData().ActivityType;
			ActivityLimitTimeData currActivityData = currSelectedTab.GetCurrActivityData();
			List<ActivityLimitTimeDetailData> list = activityLimitTimeTasksDic[currActivityId];
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/ConsumeLottry", true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.mConsumeLottery, false);
			ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			Text com = component.GetCom<Text>("ActivityTime");
			Text com2 = component.GetCom<Text>("ActivityRule");
			Text mLotteryTime = component.GetCom<Text>("LotteryTime");
			Button com3 = component.GetCom<Button>("ViewAwards");
			Button com4 = component.GetCom<Button>("Lottery");
			GameObject gameObject2 = component.GetGameObject("Content");
			int activityEndTime = (int)currActivityData.ActivityEndTime;
			int activityStartTime = (int)currActivityData.ActivityStartTime;
			if (activityEndTime != 0 && activityStartTime != 0)
			{
				string dateTime = DataManager<ActivityLimitTimeCombineManager>.GetInstance().BossDataManager.GetDateTime(activityStartTime, activityEndTime);
				com.text = dateTime;
			}
			com2.text = currActivityData.ActivityRole;
			com3.onClick.RemoveAllListeners();
			com3.onClick.AddListener(delegate()
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.ViewAwards(10002);
			});
			com4.onClick.RemoveAllListeners();
			com4.onClick.AddListener(delegate()
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.lottery(10002);
			});
			mLotteryTime.text = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME).ToString();
			this.setLotteryTextHandler = delegate(string str)
			{
				if (mLotteryTime)
				{
					mLotteryTime.text = str;
				}
			};
			this.CreateLotteryItem(gameObject2, currActivityData);
		}

		// Token: 0x0600F798 RID: 63384 RVA: 0x00432A2C File Offset: 0x00430E2C
		private void CreateLotteryItem(GameObject root, ActivityLimitTimeData activityLimittimeData)
		{
			for (int i = 0; i < activityLimittimeData.activityDetailDataList.Count; i++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData = activityLimittimeData.activityDetailDataList[i];
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/OperateActivity/LimitTime/ConsumeLottryItem", true, 0U);
				if (gameObject == null)
				{
					return;
				}
				Utility.AttachTo(gameObject, root, false);
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Text com = component.GetCom<Text>("DescText");
				Text com2 = component.GetCom<Text>("DoneText");
				GameObject gameObject2 = component.GetGameObject("AwardParent");
				Button com3 = component.GetCom<Button>("ReceiveBtn");
				if (com3)
				{
					com3.onClick.RemoveAllListeners();
				}
				GameObject gameObject3 = component.GetGameObject("ReceiveBtnGo");
				GameObject gameObject4 = component.GetGameObject("ReceivedImgGo");
				GameObject gameObject5 = component.GetGameObject("UnDoneImgGo");
				List<GameObject> list = new List<GameObject>();
				list.Add(component.GetGameObject("root0"));
				list.Add(component.GetGameObject("root1"));
				list.Add(component.GetGameObject("root2"));
				list.Add(component.GetGameObject("root3"));
				list.Add(component.GetGameObject("root4"));
				if (activityLimitTimeDetailData.ActivityDetailState == ActivityTaskState.Over)
				{
					com2.text = string.Format("{0}/{1}", activityLimitTimeDetailData.TotalNum, activityLimitTimeDetailData.TotalNum);
					gameObject4.CustomActive(true);
				}
				else
				{
					com2.text = string.Format("{0}/{1}", activityLimitTimeDetailData.DoneNum, activityLimitTimeDetailData.TotalNum);
					gameObject5.CustomActive(true);
				}
				com.text = activityLimitTimeDetailData.ActivityTaskDesc;
				for (int j = 0; j < activityLimitTimeDetailData.awardDataList.Count; j++)
				{
					if (j < 5)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)activityLimitTimeDetailData.awardDataList[j].Id, 100, 0);
						if (itemData == null)
						{
							Logger.LogErrorFormat("ItemData is null", new object[0]);
							return;
						}
						itemData.Count = activityLimitTimeDetailData.awardDataList[j].Num;
						list[j].CustomActive(true);
						ComItem comItem = base.CreateComItem(list[j]);
						int result = (int)activityLimitTimeDetailData.awardDataList[j].Id;
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
				this.ConsumeLotteryItemDic.Add(activityLimitTimeDetailData.DataId, gameObject);
			}
			for (int k = 0; k < activityLimittimeData.activityDetailDataList.Count; k++)
			{
				ActivityLimitTimeDetailData activityLimitTimeDetailData2 = activityLimittimeData.activityDetailDataList[k];
				if (activityLimitTimeDetailData2.ActivityDetailState == ActivityTaskState.Over)
				{
					GameObject gameObject6 = this.ConsumeLotteryItemDic[activityLimitTimeDetailData2.DataId];
					if (gameObject6 != null)
					{
						gameObject6.transform.SetAsLastSibling();
					}
				}
			}
		}

		// Token: 0x0600F799 RID: 63385 RVA: 0x00432D3C File Offset: 0x0043113C
		private bool CreateCommonActivityObj(OpActivityTmpType ActivityType, string path)
		{
			GameObject gameObject = null;
			if (this.CommonActivityObjDict.TryGetValue(ActivityType, out gameObject))
			{
				return false;
			}
			gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
			if (gameObject == null)
			{
				Logger.LogErrorFormat("prefab path is error:{0}", new object[]
				{
					path
				});
				return false;
			}
			Utility.AttachTo(gameObject, this.mCommonRoot, false);
			if (gameObject != null)
			{
				this.CommonActivityObjDict.Add(ActivityType, gameObject);
			}
			return true;
		}

		// Token: 0x0600F79A RID: 63386 RVA: 0x00432DBC File Offset: 0x004311BC
		private GameObject GetActivityObj(OpActivityTmpType ActivityTyp)
		{
			GameObject result = null;
			this.CommonActivityObjDict.TryGetValue(ActivityTyp, out result);
			return result;
		}

		// Token: 0x0600F79B RID: 63387 RVA: 0x00432DDC File Offset: 0x004311DC
		private void UpdateCommonRootShow(OpActivityTmpType ActivityType)
		{
			foreach (KeyValuePair<OpActivityTmpType, GameObject> keyValuePair in this.CommonActivityObjDict)
			{
				OpActivityTmpType key = keyValuePair.Key;
				Dictionary<OpActivityTmpType, GameObject>.Enumerator enumerator;
				KeyValuePair<OpActivityTmpType, GameObject> keyValuePair2 = enumerator.Current;
				GameObject value = keyValuePair2.Value;
				if (!(value == null))
				{
					value.CustomActive(key == ActivityType);
				}
			}
		}

		// Token: 0x0600F79C RID: 63388 RVA: 0x00432E44 File Offset: 0x00431244
		private void _RequestRanklist(int count)
		{
			WorldSortListReq worldSortListReq = new WorldSortListReq();
			worldSortListReq.type = 5;
			worldSortListReq.start = 0;
			worldSortListReq.num = (ushort)count;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldSortListReq>(ServerType.GATE_SERVER, worldSortListReq);
			DataManager<WaitNetMessageManager>.GetInstance().Wait(602602U, delegate(MsgDATA msgRet)
			{
				if (msgRet == null)
				{
					return;
				}
				int num = 0;
				BaseSortList param = SortListDecoder.Decode(msgRet.bytes, ref num, msgRet.bytes.Length, false);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RanklistUpdated, param, null, null, null);
			}, true, 15f, null);
		}

		// Token: 0x0600F79D RID: 63389 RVA: 0x00432EB0 File Offset: 0x004312B0
		public void RefreshViewOnTasksChanged()
		{
			Dictionary<uint, List<ActivityLimitTimeDetailData>> activityLimitTimeTasksDic = DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.activityLimitTimeTasksDic;
			if (activityLimitTimeTasksDic == null)
			{
				return;
			}
			if (this.activityTabList != null)
			{
				for (int i = 0; i < this.activityTabList.Count; i++)
				{
					uint currActivityId = this.activityTabList[i].GetCurrActivityId();
					if (activityLimitTimeTasksDic.ContainsKey(currActivityId))
					{
						List<ActivityLimitTimeDetailData> detailDataList = activityLimitTimeTasksDic[currActivityId];
						this.activityTabList[i].UpdateRedPoint(detailDataList);
					}
				}
			}
			ActivityLTTab selectedActTab = this.GetSelectedActTab();
			if (selectedActTab == null)
			{
				Logger.LogError("no tap is selected!");
				return;
			}
			uint currActivityId2 = selectedActTab.GetCurrActivityId();
			OpActivityTmpType activityType = selectedActTab.GetCurrActivityData().ActivityType;
			if (activityLimitTimeTasksDic.ContainsKey(currActivityId2))
			{
				List<ActivityLimitTimeDetailData> list = activityLimitTimeTasksDic[currActivityId2];
				for (int j = 0; j < list.Count; j++)
				{
					uint dataId = list[j].DataId;
					ActivityLimitTimeDetailData data = list[j];
					if (this.activityLTDetailList != null)
					{
						for (int k = 0; k < this.activityLTDetailList.Count; k++)
						{
							uint currDetailDataId = this.activityLTDetailList[k].GetCurrDetailDataId();
							if (currDetailDataId == dataId)
							{
								this.activityLTDetailList[k].RefreshView(data, activityType);
							}
						}
					}
				}
			}
			if (activityType == OpActivityTmpType.OAT_FATIGUE_BURNING)
			{
				ActivityLimitTimeData currActivityData = selectedActTab.GetCurrActivityData();
				this.updateFatigueBurningData(currActivityData);
			}
			if (activityType == OpActivityTmpType.OAT_FATIGUE_FOR_TOKEN_COIN)
			{
				ActivityLimitTimeData currActivityData2 = selectedActTab.GetCurrActivityData();
				this.UpdateCoinExchangeData(currActivityData2);
			}
			if (activityType != OpActivityTmpType.OAT_FATIGUE_FOR_TOKEN_COIN && activityType != OpActivityTmpType.OAT_DAILY_REWARD && activityType != OpActivityTmpType.OAT_LIMIT_TIME_GIFT_PACK)
			{
			}
			if (activityType == OpActivityTmpType.OAT_APPOINTMENT_OCCU && activityLimitTimeTasksDic.ContainsKey(currActivityId2))
			{
				List<ActivityLimitTimeDetailData> list2 = activityLimitTimeTasksDic[currActivityId2];
				for (int l = 0; l < list2.Count; l++)
				{
					uint dataId2 = list2[l].DataId;
					if (this.ReservationUpgradeItemDic.ContainsKey(dataId2))
					{
						GameObject gameObject = this.ReservationUpgradeItemDic[dataId2];
						ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
						if (!(component == null))
						{
							GameObject gameObject2 = component.GetGameObject("ReceiveBtnGo");
							GameObject gameObject3 = component.GetGameObject("ReceivedImgGo");
							GameObject gameObject4 = component.GetGameObject("UnDoneImgGo");
							GameObject gameObject5 = component.GetGameObject("UnAppointmentRole");
							if (DataManager<PlayerBaseData>.GetInstance().appointmentOccu == 1)
							{
								if (list2[l].ActivityDetailState == ActivityTaskState.Over)
								{
									gameObject2.CustomActive(false);
									gameObject4.CustomActive(false);
									gameObject5.CustomActive(false);
									gameObject3.CustomActive(true);
									gameObject.transform.SetAsLastSibling();
								}
								else if (list2[l].ActivityDetailState == ActivityTaskState.Finished)
								{
									gameObject4.CustomActive(false);
									gameObject3.CustomActive(false);
									gameObject5.CustomActive(false);
									gameObject2.CustomActive(true);
								}
								else
								{
									gameObject4.CustomActive(true);
									gameObject3.CustomActive(false);
									gameObject5.CustomActive(false);
									gameObject2.CustomActive(false);
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600F79E RID: 63390 RVA: 0x004331EC File Offset: 0x004315EC
		public void RefreshViewOnActivityChange(ActivityLimitTimeData changedActData)
		{
			if (this.activityTabList != null && changedActData != null)
			{
				for (int i = 0; i < this.activityTabList.Count; i++)
				{
					ActivityLTTab activityLTTab = this.activityTabList[i];
					if (activityLTTab.GetCurrActivityId() == changedActData.DataId)
					{
						if (activityLTTab.BeSelected())
						{
							if (changedActData.ActivityState != ActivityState.Start)
							{
								this.activityTabList[i].Destory();
								if (i + 1 <= this.activityTabList.Count - 1)
								{
									this.activityTabList[i + 1].SetSelected(true);
									this.activityTabList.RemoveAt(i);
									break;
								}
								if (i - 1 >= 0)
								{
									this.activityTabList[i - 1].SetSelected(true);
									this.activityTabList.RemoveAt(i);
									break;
								}
								this.activityTabList.RemoveAt(i);
								if (this.activityLTDetailList != null)
								{
									for (int j = 0; j < this.activityLTDetailList.Count; j++)
									{
										this.activityLTDetailList[j].Destory();
									}
									this.activityLTDetailList.Clear();
								}
								if (this.activityLTNote != null)
								{
									this.activityLTNote.Destory();
								}
							}
							else
							{
								this.activityTabList[i].RefreshView(changedActData);
							}
							if (this.activityTabList.Count == 0)
							{
							}
						}
						else if (activityLTTab.GetCurrActivityData().ActivityState != ActivityState.Start)
						{
							this.activityTabList[i].Destory();
							this.activityTabList.RemoveAt(i);
						}
						else
						{
							this.activityTabList[i].RefreshView(changedActData);
						}
					}
				}
			}
			if (this.activityLTNote != null)
			{
				ActivityLTTab selectedActTab = this.GetSelectedActTab();
				if (selectedActTab == null)
				{
					return;
				}
				this.activityLTNote.RefreshView(selectedActTab.GetCurrActivityData());
			}
		}

		// Token: 0x0600F79F RID: 63391 RVA: 0x004333D4 File Offset: 0x004317D4
		private void RefreshFrame(UIEvent uiEvent)
		{
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.HaveActivity)
			{
			}
		}

		// Token: 0x0600F7A0 RID: 63392 RVA: 0x004333F0 File Offset: 0x004317F0
		private void OnCountValueChanged(UIEvent uiEvent)
		{
			string lotteryText = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_TIME).ToString();
			if (this.setLotteryTextHandler != null)
			{
				this.setLotteryTextHandler(lotteryText);
				this.RefreshViewOnTasksChanged();
			}
			string coinText = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_COIN_NUM).ToString();
			if (this.setCoinTextHandler != null)
			{
				this.setCoinTextHandler(coinText);
			}
			string fatigueCoinText = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_FATIGUE_COIN_NUM).ToString();
			if (this.setFatigueCoinHandler != null)
			{
				this.setFatigueCoinHandler(fatigueCoinText);
			}
			string fatigueCoinText2 = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_ACTIVITY_FATIGUE_TICKET_NUM).ToString();
			if (this.setFatigueTicketHanlder != null)
			{
				this.setFatigueTicketHanlder(fatigueCoinText2);
			}
		}

		// Token: 0x0600F7A1 RID: 63393 RVA: 0x004334E0 File Offset: 0x004318E0
		private void _OnRanklistUpdate(UIEvent a_event)
		{
			BaseSortList baseSortList = a_event.Param1 as BaseSortList;
			if (baseSortList == null)
			{
				return;
			}
			if (this.mMyGrade != null && baseSortList.selfEntry != null)
			{
				if (baseSortList.selfEntry.ranking != 0)
				{
					this.mMyGrade.text = "我的排名:第" + baseSortList.selfEntry.ranking + "名";
				}
				else
				{
					this.mMyGrade.text = "我的排名:未上榜";
				}
			}
			if (!this.levelFightShowOpen)
			{
				return;
			}
			string path = "UIFlatten/Prefabs/OperateActivity/LimitTime/LevelFightShowItem";
			for (int i = 0; i < baseSortList.entries.Count; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
				if (gameObject == null)
				{
					return;
				}
				Utility.AttachTo(gameObject, this.mRankListRoot, false);
				if (i >= this.ranklistAwardList.Count)
				{
					return;
				}
				ComCommonBind component = gameObject.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				GameObject gameObject2 = component.GetGameObject("One");
				GameObject gameObject3 = component.GetGameObject("Two");
				GameObject gameObject4 = component.GetGameObject("Three");
				GameObject gameObject5 = component.GetGameObject("Item0");
				gameObject5.CustomActive(false);
				GameObject gameObject6 = component.GetGameObject("Item1");
				gameObject6.CustomActive(false);
				GameObject gameObject7 = component.GetGameObject("Item2");
				gameObject7.CustomActive(false);
				GameObject gameObject8 = component.GetGameObject("Item3");
				gameObject8.CustomActive(false);
				GameObject gameObject9 = component.GetGameObject("Item4");
				gameObject9.CustomActive(false);
				Text com = component.GetCom<Text>("Name");
				Text com2 = component.GetCom<Text>("Grade");
				GameObject[] array = new GameObject[]
				{
					gameObject5,
					gameObject6,
					gameObject7,
					gameObject8,
					gameObject9
				};
				for (int j = 0; j < this.ranklistAwardList[i].Count; j++)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.ranklistAwardList[i][j].Id, 100, 0);
					if (itemData == null)
					{
						Logger.LogErrorFormat("ItemData is null", new object[0]);
					}
					else
					{
						array[j].CustomActive(true);
						itemData.Count = this.ranklistAwardList[i][j].Num;
						ComItem comItem = array[j].GetComponentInChildren<ComItem>();
						if (comItem == null)
						{
							comItem = base.CreateComItem(array[j]);
						}
						int result = (int)this.ranklistAwardList[i][j].Id;
						comItem.Setup(itemData, delegate(GameObject Obj, ItemData sitem)
						{
							this.OnShowTips(result);
						});
					}
				}
				com.CustomActive(true);
				com.text = baseSortList.entries[i].name;
				gameObject2.CustomActive(false);
				gameObject3.CustomActive(false);
				gameObject4.CustomActive(false);
				com2.CustomActive(true);
				if (baseSortList.entries[i].ranking == 1)
				{
					gameObject2.CustomActive(true);
					com2.CustomActive(false);
				}
				if (baseSortList.entries[i].ranking == 2)
				{
					gameObject3.CustomActive(true);
					com2.CustomActive(false);
				}
				if (baseSortList.entries[i].ranking == 3)
				{
					gameObject4.CustomActive(true);
					com2.CustomActive(false);
				}
				if (com2.gameObject.activeSelf)
				{
					com2.text = "第" + baseSortList.entries[i].ranking + "名";
				}
			}
		}

		// Token: 0x0600F7A2 RID: 63394 RVA: 0x004338A8 File Offset: 0x00431CA8
		public ActivityLTTab GetSelectedActTab()
		{
			if (this.activityTabList != null)
			{
				for (int i = 0; i < this.activityTabList.Count; i++)
				{
					ActivityLTTab activityLTTab = this.activityTabList[i];
					if (activityLTTab.BeSelected())
					{
						return activityLTTab;
					}
				}
			}
			return null;
		}

		// Token: 0x0600F7A3 RID: 63395 RVA: 0x004338F7 File Offset: 0x00431CF7
		public ToggleGroup GetCurrToggleGroup()
		{
			return this.tabGroup;
		}

		// Token: 0x0600F7A4 RID: 63396 RVA: 0x004338FF File Offset: 0x00431CFF
		public ScrollRect GetTaskParentScrollRect()
		{
			return this.detailScrollRect;
		}

		// Token: 0x0600F7A5 RID: 63397 RVA: 0x00433907 File Offset: 0x00431D07
		public void SetTaskParentScrollRectEnable(bool enable)
		{
			if (this.detailScrollRect)
			{
				this.detailScrollRect.vertical = enable;
			}
		}

		// Token: 0x040098A1 RID: 39073
		public ActivityLimitTimeFrame.SetLotteryText setLotteryTextHandler;

		// Token: 0x040098A2 RID: 39074
		public ActivityLimitTimeFrame.SetCoinText setCoinTextHandler;

		// Token: 0x040098A3 RID: 39075
		public ActivityLimitTimeFrame.SetFatigueCoin setFatigueCoinHandler;

		// Token: 0x040098A4 RID: 39076
		public ActivityLimitTimeFrame.SetFatigueTicket setFatigueTicketHanlder;

		// Token: 0x040098A5 RID: 39077
		private const string FashionDiscountPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/FashionDiscount2";

		// Token: 0x040098A6 RID: 39078
		private const string LevelFightPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/LevelFightMode";

		// Token: 0x040098A7 RID: 39079
		private const string LevelFightShowPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/LevelFightMode";

		// Token: 0x040098A8 RID: 39080
		private const string ConsumeLotteryPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ConsumeLottry";

		// Token: 0x040098A9 RID: 39081
		private const string ConsumeLotteryItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ConsumeLottryItem";

		// Token: 0x040098AA RID: 39082
		private const string ReservationUpgradePath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ReservationUpgrade";

		// Token: 0x040098AB RID: 39083
		private const string ReservationUpgradeItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ReservationUpgradeItem";

		// Token: 0x040098AC RID: 39084
		private const string CreatAppoinmentRoleRootPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/CreatAppoinmentRoleRoot";

		// Token: 0x040098AD RID: 39085
		private const string FatigueLossBuffPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/FatigueLossBuff";

		// Token: 0x040098AE RID: 39086
		private const string FatigueLossBuffItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/FatigueLossBuffItem";

		// Token: 0x040098AF RID: 39087
		private const string FatigueBurningPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/FatigueBurning";

		// Token: 0x040098B0 RID: 39088
		private const string CoinExchangePath = "UIFlatten/Prefabs/OperateActivity/LimitTime/CoinExchange";

		// Token: 0x040098B1 RID: 39089
		private const string CoinExchangeItenPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/CoinExchangeItem";

		// Token: 0x040098B2 RID: 39090
		private const string DungeonDropTypePath = "UIFlatten/Prefabs/OperateActivity/LimitTime/DungeonDropType";

		// Token: 0x040098B3 RID: 39091
		private const string DungeonDropTypeItemPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/DungeonDropTypeItem";

		// Token: 0x040098B4 RID: 39092
		private List<ActivityLTTab> activityTabList;

		// Token: 0x040098B5 RID: 39093
		private ActivityLTNote activityLTNote;

		// Token: 0x040098B6 RID: 39094
		private List<ActivityLTDetailContent> activityLTDetailList;

		// Token: 0x040098B7 RID: 39095
		private Dictionary<OpActivityTmpType, GameObject> CommonActivityObjDict = new Dictionary<OpActivityTmpType, GameObject>();

		// Token: 0x040098B8 RID: 39096
		private Dictionary<uint, GameObject> ReservationUpgradeItemDic = new Dictionary<uint, GameObject>();

		// Token: 0x040098B9 RID: 39097
		private Dictionary<uint, GameObject> CoinExchangeItemDic = new Dictionary<uint, GameObject>();

		// Token: 0x040098BA RID: 39098
		private Dictionary<uint, GameObject> FatiguelLossBuffItemDic = new Dictionary<uint, GameObject>();

		// Token: 0x040098BB RID: 39099
		private Dictionary<uint, GameObject> ConsumeLotteryItemDic = new Dictionary<uint, GameObject>();

		// Token: 0x040098BC RID: 39100
		private GameObject tabParent;

		// Token: 0x040098BD RID: 39101
		private ToggleGroup tabGroup;

		// Token: 0x040098BE RID: 39102
		private GameObject noteParent;

		// Token: 0x040098BF RID: 39103
		private GameObject detailParent;

		// Token: 0x040098C0 RID: 39104
		private ScrollRect detailScrollRect;

		// Token: 0x040098C1 RID: 39105
		private GameObject noteInfoGo;

		// Token: 0x040098C2 RID: 39106
		private GameObject mFashionDiscount;

		// Token: 0x040098C3 RID: 39107
		private Button mFashionGoBuy;

		// Token: 0x040098C4 RID: 39108
		private Text mFashionEndTime;

		// Token: 0x040098C5 RID: 39109
		private GameObject mLabel;

		// Token: 0x040098C6 RID: 39110
		private GameObject mFashionDiscountRoot;

		// Token: 0x040098C7 RID: 39111
		private GameObject mLevelFightRoot;

		// Token: 0x040098C8 RID: 39112
		private GameObject mLevelFightShowRoot;

		// Token: 0x040098C9 RID: 39113
		private GameObject mConsumeLottery;

		// Token: 0x040098CA RID: 39114
		private GameObject mCommonRoot;

		// Token: 0x040098CB RID: 39115
		private GameObject mNewFrameRoot;

		// Token: 0x040098CC RID: 39116
		private float lastTime;

		// Token: 0x040098CD RID: 39117
		private float curTime = 1f;

		// Token: 0x040098CE RID: 39118
		private float lastTimeRanklist;

		// Token: 0x040098CF RID: 39119
		private float curTimeRanklist;

		// Token: 0x040098D0 RID: 39120
		private float LastTime = Time.time;

		// Token: 0x040098D1 RID: 39121
		private bool haveInit;

		// Token: 0x040098D2 RID: 39122
		private bool haveInitToggle;

		// Token: 0x040098D3 RID: 39123
		private bool fashionDiscount2Open;

		// Token: 0x040098D4 RID: 39124
		private bool levelFightOpen;

		// Token: 0x040098D5 RID: 39125
		private bool levelFightShowOpen;

		// Token: 0x040098D6 RID: 39126
		private Text mLevelFightTime;

		// Token: 0x040098D7 RID: 39127
		private GameObject mRankListRoot;

		// Token: 0x040098D8 RID: 39128
		private Text mMyGrade;

		// Token: 0x040098D9 RID: 39129
		private int fashionDiscount2ID = -1;

		// Token: 0x040098DA RID: 39130
		private int levelFightEndTime;

		// Token: 0x040098DB RID: 39131
		private bool haveInitFashionDiscount2;

		// Token: 0x040098DC RID: 39132
		private bool haveInitlevelFight;

		// Token: 0x040098DD RID: 39133
		private bool haveInitlevelFightShow;

		// Token: 0x040098DE RID: 39134
		private bool haveInitConsumeLottery;

		// Token: 0x040098DF RID: 39135
		private GameObject fatigueBurningGo;

		// Token: 0x040098E0 RID: 39136
		private int ordinaryLastTime = -1;

		// Token: 0x040098E1 RID: 39137
		private int advancedLastTime = -1;

		// Token: 0x040098E2 RID: 39138
		private bool ordinaryBurningIsOpen;

		// Token: 0x040098E3 RID: 39139
		private bool advancedBurningIsOpen;

		// Token: 0x040098E4 RID: 39140
		private Text ordinaryTime;

		// Token: 0x040098E5 RID: 39141
		private Text advancedTime;

		// Token: 0x040098E6 RID: 39142
		private List<List<ActivityLimitTimeAward>> ranklistAwardList = new List<List<ActivityLimitTimeAward>>();

		// Token: 0x040098E7 RID: 39143
		private bool ordinaryActivityOpen;

		// Token: 0x040098E8 RID: 39144
		private bool advancedActivityOpen;

		// Token: 0x040098E9 RID: 39145
		private const string prefabPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeFrame";

		// Token: 0x040098EA RID: 39146
		private ActivityLTTab mSelectActivityLtTab;

		// Token: 0x040098EB RID: 39147
		private ActivityLTTab mSummerWatermelonTab;

		// Token: 0x020018C1 RID: 6337
		// (Invoke) Token: 0x0600F7AF RID: 63407
		public delegate void SetLotteryText(string lotteryText);

		// Token: 0x020018C2 RID: 6338
		// (Invoke) Token: 0x0600F7B3 RID: 63411
		public delegate void SetCoinText(string coinText);

		// Token: 0x020018C3 RID: 6339
		// (Invoke) Token: 0x0600F7B7 RID: 63415
		public delegate void SetFatigueCoin(string fatigueCoinText);

		// Token: 0x020018C4 RID: 6340
		// (Invoke) Token: 0x0600F7BB RID: 63419
		public delegate void SetFatigueTicket(string fatigueCoinText);
	}
}
