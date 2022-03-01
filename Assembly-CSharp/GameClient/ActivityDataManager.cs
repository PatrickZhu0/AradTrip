using System;
using System.Collections;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011A9 RID: 4521
	public class ActivityDataManager : DataManager<ActivityDataManager>
	{
		// Token: 0x17001A74 RID: 6772
		// (get) Token: 0x0600AD60 RID: 44384 RVA: 0x0025B6C3 File Offset: 0x00259AC3
		// (set) Token: 0x0600AD61 RID: 44385 RVA: 0x0025B6CB File Offset: 0x00259ACB
		public int AnniversaryPoint
		{
			get
			{
				return this.anniversaryPoint;
			}
			set
			{
				this.anniversaryPoint = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnAnniversaryPointChanged, null, null, null, null);
			}
		}

		// Token: 0x0600AD62 RID: 44386 RVA: 0x0025B6E7 File Offset: 0x00259AE7
		public ActivityTabInfo GetActivityTabInfo(int filterId)
		{
			if (this.mActivityTabTables.ContainsKey(filterId))
			{
				return this.mActivityTabTables[filterId];
			}
			return null;
		}

		// Token: 0x0600AD63 RID: 44387 RVA: 0x0025B708 File Offset: 0x00259B08
		public Dictionary<int, ActivityTabInfo> GetTabInfos()
		{
			return this.mActivityTabTables;
		}

		// Token: 0x0600AD64 RID: 44388 RVA: 0x0025B710 File Offset: 0x00259B10
		public int GetFilterIdByActivityId(int activityId)
		{
			int num = -1;
			foreach (KeyValuePair<int, ActivityTabInfo> keyValuePair in this.mActivityTabTables)
			{
				if (num == -1)
				{
					num = keyValuePair.Key;
				}
				ActivityTabInfo value = keyValuePair.Value;
				if (value != null)
				{
					for (int i = 0; i < value.actIds.Length; i++)
					{
						if ((ulong)value.actIds[i] == (ulong)((long)activityId))
						{
							return keyValuePair.Key;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600AD65 RID: 44389 RVA: 0x0025B7C4 File Offset: 0x00259BC4
		public OpActivityData GetLimitTimeActivityData(uint activityId)
		{
			if (this.mLimitTimeActivityDatas.ContainsKey(activityId))
			{
				return this.mLimitTimeActivityDatas[activityId];
			}
			return null;
		}

		// Token: 0x0600AD66 RID: 44390 RVA: 0x0025B7E5 File Offset: 0x00259BE5
		public OpActTask GetLimitTimeTaskData(uint taskId)
		{
			if (this.mLimitTimeTaskDatas.ContainsKey(taskId))
			{
				return this.mLimitTimeTaskDatas[taskId];
			}
			return null;
		}

		// Token: 0x0600AD67 RID: 44391 RVA: 0x0025B808 File Offset: 0x00259C08
		public string GetTaskDesByTaskId(uint taskId, uint activityId)
		{
			if (this.mLimitTimeActivityDatas.ContainsKey(activityId))
			{
				OpActivityData opActivityData = this.mLimitTimeActivityDatas[activityId];
				if (opActivityData == null)
				{
					return null;
				}
				string[] array = opActivityData.taskDesc.Split(new char[]
				{
					'|'
				});
				int i = 0;
				while (i < opActivityData.tasks.Length)
				{
					if (opActivityData.tasks[i].dataid == taskId)
					{
						if (i < array.Length)
						{
							return array[i];
						}
						return null;
					}
					else
					{
						i++;
					}
				}
			}
			return null;
		}

		// Token: 0x0600AD68 RID: 44392 RVA: 0x0025B88E File Offset: 0x00259C8E
		public List<MallItemInfo> GetGiftPackInfos(MallTypeTable.eMallType mallType)
		{
			if (this.mGiftPackDatas.ContainsKey((int)mallType))
			{
				return new List<MallItemInfo>(this.mGiftPackDatas[(int)mallType].Values);
			}
			return null;
		}

		// Token: 0x0600AD69 RID: 44393 RVA: 0x0025B8B9 File Offset: 0x00259CB9
		public bool IsContainGiftActivity(MallTypeTable.eMallType mallType, uint activityId)
		{
			return this.mGiftPackDatas.ContainsKey((int)mallType) && this.mGiftPackDatas[(int)mallType].ContainsKey(activityId);
		}

		// Token: 0x0600AD6A RID: 44394 RVA: 0x0025B8E0 File Offset: 0x00259CE0
		public ActivityInfo GetBossActivityData(uint activityId)
		{
			if (this.mBossActivityDatas.ContainsKey(activityId))
			{
				return this.mBossActivityDatas[activityId];
			}
			return null;
		}

		// Token: 0x0600AD6B RID: 44395 RVA: 0x0025B901 File Offset: 0x00259D01
		public SceneNotifyActiveTaskVar GetBossTaskData(uint taskId)
		{
			if (this.mBossTaskDatas.ContainsKey(taskId))
			{
				return this.mBossTaskDatas[taskId];
			}
			return null;
		}

		// Token: 0x0600AD6C RID: 44396 RVA: 0x0025B922 File Offset: 0x00259D22
		public SceneNotifyActiveTaskStatus GetBossTaskStatusData(uint taskId)
		{
			if (this.mBossTaskStatusDatas.ContainsKey(taskId))
			{
				return this.mBossTaskStatusDatas[taskId];
			}
			return null;
		}

		// Token: 0x0600AD6D RID: 44397 RVA: 0x0025B943 File Offset: 0x00259D43
		public WorldActivityMonsterRes GetBossKillMonsterData(uint activityId)
		{
			if (this.mBossKillMonsterDatas.ContainsKey(activityId))
			{
				return this.mBossKillMonsterDatas[activityId];
			}
			return null;
		}

		// Token: 0x0600AD6E RID: 44398 RVA: 0x0025B964 File Offset: 0x00259D64
		public MallItemInfo GetGiftPackData(MallTypeTable.eMallType mallType, uint mallItemId)
		{
			if (this.mGiftPackDatas.ContainsKey((int)mallType) && this.mGiftPackDatas[(int)mallType].ContainsKey(mallItemId))
			{
				return this.mGiftPackDatas[(int)mallType][mallItemId];
			}
			return null;
		}

		// Token: 0x0600AD6F RID: 44399 RVA: 0x0025B9A4 File Offset: 0x00259DA4
		public void BuyGift(uint mallItemTableID)
		{
			WorldMallBuy worldMallBuy = new WorldMallBuy();
			worldMallBuy.itemId = mallItemTableID;
			worldMallBuy.num = 1;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
			DataManager<WaitNetMessageManager>.GetInstance().Wait<WorldMallBuyRet>(delegate(WorldMallBuyRet ret)
			{
				if (ret.mallitemid == mallItemTableID)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnFashionTicketBuyFinished, null, null, null, null);
				}
			}, false, 15f, null);
		}

		// Token: 0x0600AD70 RID: 44400 RVA: 0x0025BA04 File Offset: 0x00259E04
		public override void Initialize()
		{
			this.Clear();
			this._BindNetMsg();
			this.monthSignInAwards.Clear();
			this.monthSignCollectAwards.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<MonthSignAward>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					MonthSignAward monthSignAward = keyValuePair.Value as MonthSignAward;
					if (monthSignAward != null)
					{
						Dictionary<int, MonthSignAward> dictionary = null;
						this.monthSignInAwards.TryGetValue(monthSignAward.Month, out dictionary);
						if (dictionary == null)
						{
							this.monthSignInAwards.Add(monthSignAward.Month, new Dictionary<int, MonthSignAward>());
							dictionary = this.monthSignInAwards[monthSignAward.Month];
						}
						if (dictionary != null)
						{
							if (!dictionary.ContainsKey(monthSignAward.Day))
							{
								dictionary.Add(monthSignAward.Day, monthSignAward);
							}
							else
							{
								dictionary[monthSignAward.Day] = monthSignAward;
							}
						}
					}
				}
			}
			Dictionary<int, object> table2 = Singleton<TableManager>.instance.GetTable<MonthSignCollectAward>();
			if (table2 != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair2 in table2)
				{
					MonthSignCollectAward monthSignCollectAward = keyValuePair2.Value as MonthSignCollectAward;
					if (monthSignCollectAward != null)
					{
						this.monthSignCollectAwards.SafeAdd(monthSignCollectAward.ID, monthSignCollectAward);
					}
				}
			}
			this.HasPopUpGetInspireBufFrame = false;
			this.NotPopUpRefreshBufMsgBox = false;
			this.InitLimiteBargainShowTable();
			this.InitWholeBargainDiscountTable();
			this.InitUltimateChallengeRewardTable();
		}

		// Token: 0x0600AD71 RID: 44401 RVA: 0x0025BB88 File Offset: 0x00259F88
		public override void Clear()
		{
			this._UnBindNetMsg();
			if (this.mLimitTimeActivityDatas != null)
			{
				this.mLimitTimeActivityDatas.Clear();
			}
			if (this.mLimitTimeTaskDatas != null)
			{
				this.mLimitTimeTaskDatas.Clear();
			}
			if (this.mBossActivityDatas != null)
			{
				this.mBossActivityDatas.Clear();
			}
			if (this.mBossTaskDatas != null)
			{
				this.mBossTaskDatas.Clear();
			}
			if (this.mBossKillMonsterDatas != null)
			{
				this.mBossKillMonsterDatas.Clear();
			}
			if (this.mGiftPackDatas != null)
			{
				this.mGiftPackDatas.Clear();
			}
			if (this.mBossTaskStatusDatas != null)
			{
				this.mBossTaskStatusDatas.Clear();
			}
			if (this.mActivityTabTables != null)
			{
				this.mActivityTabTables.Clear();
			}
			if (this.mLimitTimeActivityCounterResDic != null)
			{
				this.mLimitTimeActivityCounterResDic.Clear();
			}
			if (this.mBossActivityCounterResDic != null)
			{
				this.mBossActivityCounterResDic.Clear();
			}
			if (this.mDungeonCounterResDic != null)
			{
				this.mDungeonCounterResDic.Clear();
			}
			if (this.monthlySignInItemDatas != null)
			{
				this.monthlySignInItemDatas.Clear();
			}
			if (this.accumulativeSignInItemDatas != null)
			{
				this.accumulativeSignInItemDatas.Clear();
			}
			if (ActivityDataManager.mPreviewDict != null)
			{
				ActivityDataManager.mPreviewDict.Clear();
			}
			if (ActivityDataManager.mDiscountDataList != null)
			{
				ActivityDataManager.mDiscountDataList.Clear();
			}
			if (ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas != null)
			{
				ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas.Clear();
			}
			this.HasPopUpGetInspireBufFrame = false;
			this.NotPopUpRefreshBufMsgBox = false;
			ActivityDataManager.LimitTimeGroupBuyDiscount = 100U;
		}

		// Token: 0x0600AD72 RID: 44402 RVA: 0x0025BD0C File Offset: 0x0025A10C
		private void _BindNetMsg()
		{
			NetProcess.AddMsgHandler(507413U, new Action<MsgDATA>(this._OnSysncLimitTimeAccountNum));
			NetProcess.AddMsgHandler(607407U, new Action<MsgDATA>(this._OnSyncActivityTabsInfo));
			this._BindBossActivityMsg();
			this._BindLimitTimeActivityMsg();
			this._BindGiftPackActivityMsg();
			NetProcess.AddMsgHandler(501164U, new Action<MsgDATA>(this._OnSceneNewSignInQueryRet));
			NetProcess.AddMsgHandler(501162U, new Action<MsgDATA>(this._OnSceneNewSignRet));
			NetProcess.AddMsgHandler(501166U, new Action<MsgDATA>(this._OnSceneNewSignInCollectRet));
			NetProcess.AddMsgHandler(506836U, new Action<MsgDATA>(this._OnSceneDungeonZjslRefreshBuffRes));
			NetProcess.AddMsgHandler(506841U, new Action<MsgDATA>(this._SceneDungeonZjslClearGetAwardRes));
			NetProcess.AddMsgHandler(507415U, new Action<MsgDATA>(this._OnChallengeScoreRet));
			this.BindArborDayNetMessages();
			this.RegisterASWholeBargainNet();
			NetProcess.AddMsgHandler(600908U, new Action<MsgDATA>(this._OnWorldGetSysRecordRes));
			NetProcess.AddMsgHandler(501168U, new Action<MsgDATA>(this._OnSceneSecretCoinRes));
		}

		// Token: 0x0600AD73 RID: 44403 RVA: 0x0025BE14 File Offset: 0x0025A214
		private void _BindGiftPackActivityMsg()
		{
			NetProcess.AddMsgHandler(602804U, new Action<MsgDATA>(this._OnSyncLimitTimeGiftData));
			NetProcess.AddMsgHandler(602802U, new Action<MsgDATA>(this._OnGiftBuyRes));
			NetProcess.AddMsgHandler(602817U, new Action<MsgDATA>(this._OnSyncLimitTimeAct));
		}

		// Token: 0x0600AD74 RID: 44404 RVA: 0x0025BE64 File Offset: 0x0025A264
		private void _BindBossActivityMsg()
		{
			NetProcess.AddMsgHandler(501136U, new Action<MsgDATA>(this._OnSyncBossActivities));
			NetProcess.AddMsgHandler(501127U, new Action<MsgDATA>(this._OnRecvBossActivityTaskStateChange));
			NetProcess.AddMsgHandler(501128U, new Action<MsgDATA>(this._OnSyncBossActivityTaskData));
			NetProcess.AddMsgHandler(607405U, new Action<MsgDATA>(this._OnRecvBossActivityMonsterInfo));
			NetProcess.AddMsgHandler(602901U, new Action<MsgDATA>(this._OnRecvBossActivityStateChange));
		}

		// Token: 0x0600AD75 RID: 44405 RVA: 0x0025BEE0 File Offset: 0x0025A2E0
		private void _BindLimitTimeActivityMsg()
		{
			NetProcess.AddMsgHandler(501145U, new Action<MsgDATA>(this._OnSyncLimitTimeActivity));
			NetProcess.AddMsgHandler(501146U, new Action<MsgDATA>(this._OnSyncLimitTimeActivityTasks));
			NetProcess.AddMsgHandler(501147U, new Action<MsgDATA>(this._OnSyncLimitTimeActivityTaskChange));
			NetProcess.AddMsgHandler(501149U, new Action<MsgDATA>(this._OnSyncLimitTimeActivityStateChange));
		}

		// Token: 0x0600AD76 RID: 44406 RVA: 0x0025BF48 File Offset: 0x0025A348
		private void _UnBindNetMsg()
		{
			NetProcess.RemoveMsgHandler(501146U, new Action<MsgDATA>(this._OnSyncLimitTimeActivityTasks));
			NetProcess.RemoveMsgHandler(607407U, new Action<MsgDATA>(this._OnSyncActivityTabsInfo));
			this._UnBindBossActivityMsg();
			this._UnBindLimitTimeActivityMsg();
			this._UnBindGiftPackActivityMsg();
			NetProcess.RemoveMsgHandler(501164U, new Action<MsgDATA>(this._OnSceneNewSignInQueryRet));
			NetProcess.RemoveMsgHandler(501162U, new Action<MsgDATA>(this._OnSceneNewSignRet));
			NetProcess.RemoveMsgHandler(501166U, new Action<MsgDATA>(this._OnSceneNewSignInCollectRet));
			NetProcess.RemoveMsgHandler(506836U, new Action<MsgDATA>(this._OnSceneDungeonZjslRefreshBuffRes));
			NetProcess.RemoveMsgHandler(506841U, new Action<MsgDATA>(this._SceneDungeonZjslClearGetAwardRes));
			NetProcess.RemoveMsgHandler(507415U, new Action<MsgDATA>(this._OnChallengeScoreRet));
			this.UnBindArborDayNetMessages();
			this.UnRegisterASWholeBargainNet();
			NetProcess.RemoveMsgHandler(501168U, new Action<MsgDATA>(this._OnSceneSecretCoinRes));
		}

		// Token: 0x0600AD77 RID: 44407 RVA: 0x0025C03C File Offset: 0x0025A43C
		private void _UnBindGiftPackActivityMsg()
		{
			NetProcess.RemoveMsgHandler(602804U, new Action<MsgDATA>(this._OnSyncLimitTimeGiftData));
			NetProcess.RemoveMsgHandler(602802U, new Action<MsgDATA>(this._OnGiftBuyRes));
			NetProcess.RemoveMsgHandler(602817U, new Action<MsgDATA>(this._OnSyncLimitTimeAct));
		}

		// Token: 0x0600AD78 RID: 44408 RVA: 0x0025C08C File Offset: 0x0025A48C
		private void _UnBindLimitTimeActivityMsg()
		{
			NetProcess.RemoveMsgHandler(501145U, new Action<MsgDATA>(this._OnSyncLimitTimeActivity));
			NetProcess.RemoveMsgHandler(501147U, new Action<MsgDATA>(this._OnSyncLimitTimeActivityTaskChange));
			NetProcess.RemoveMsgHandler(501149U, new Action<MsgDATA>(this._OnSyncLimitTimeActivityStateChange));
			NetProcess.RemoveMsgHandler(507411U, new Action<MsgDATA>(this._OnSysncLimitTimeAccountNum));
		}

		// Token: 0x0600AD79 RID: 44409 RVA: 0x0025C0F4 File Offset: 0x0025A4F4
		private void _UnBindBossActivityMsg()
		{
			NetProcess.RemoveMsgHandler(501136U, new Action<MsgDATA>(this._OnSyncBossActivities));
			NetProcess.RemoveMsgHandler(501127U, new Action<MsgDATA>(this._OnRecvBossActivityTaskStateChange));
			NetProcess.RemoveMsgHandler(501128U, new Action<MsgDATA>(this._OnSyncBossActivityTaskData));
			NetProcess.RemoveMsgHandler(607405U, new Action<MsgDATA>(this._OnRecvBossActivityMonsterInfo));
			NetProcess.RemoveMsgHandler(602901U, new Action<MsgDATA>(this._OnRecvBossActivityStateChange));
		}

		// Token: 0x0600AD7A RID: 44410 RVA: 0x0025C170 File Offset: 0x0025A570
		private void _OnSyncActivityTabsInfo(MsgDATA data)
		{
			WorldActivityTabsInfoSync worldActivityTabsInfoSync = new WorldActivityTabsInfoSync();
			worldActivityTabsInfoSync.decode(data.bytes);
			if (worldActivityTabsInfoSync.tabsInfo != null)
			{
				for (int i = 0; i < worldActivityTabsInfoSync.tabsInfo.Length; i++)
				{
					if (this.mActivityTabTables.ContainsKey((int)worldActivityTabsInfoSync.tabsInfo[i].id))
					{
						this.mActivityTabTables.Remove((int)worldActivityTabsInfoSync.tabsInfo[i].id);
					}
					this.mActivityTabTables.Add((int)worldActivityTabsInfoSync.tabsInfo[i].id, worldActivityTabsInfoSync.tabsInfo[i]);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityTabsInfoUpdate, null, null, null, null);
			}
		}

		// Token: 0x0600AD7B RID: 44411 RVA: 0x0025C21C File Offset: 0x0025A61C
		public void RequestMallGiftData(MallTypeTable.eMallType mallType)
		{
			WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
			worldMallQueryItemReq.type = (byte)mallType;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
		}

		// Token: 0x0600AD7C RID: 44412 RVA: 0x0025C248 File Offset: 0x0025A648
		public void RequestMallGiftData()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MallTypeTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					MallTypeTable mallTypeTable = (MallTypeTable)keyValuePair.Value;
					if (mallTypeTable.IsForActivity == 1)
					{
						WorldMallQueryItemReq worldMallQueryItemReq = new WorldMallQueryItemReq();
						worldMallQueryItemReq.type = (byte)mallTypeTable.MallType;
						NetManager netManager = NetManager.Instance();
						netManager.SendCommand<WorldMallQueryItemReq>(ServerType.GATE_SERVER, worldMallQueryItemReq);
					}
				}
			}
		}

		// Token: 0x0600AD7D RID: 44413 RVA: 0x0025C2C8 File Offset: 0x0025A6C8
		private void _OnSyncLimitTimeGiftData(MsgDATA msg)
		{
			WorldMallQueryItemRet worldMallQueryItemRet = new WorldMallQueryItemRet();
			worldMallQueryItemRet.decode(msg.bytes);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<MallTypeTable>();
			bool flag = false;
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					MallTypeTable mallTypeTable = (MallTypeTable)keyValuePair.Value;
					if ((byte)mallTypeTable.MallType == worldMallQueryItemRet.type)
					{
						flag = true;
						break;
					}
				}
			}
			if (flag && worldMallQueryItemRet.items != null)
			{
				if (!this.mGiftPackDatas.ContainsKey((int)worldMallQueryItemRet.type))
				{
					this.mGiftPackDatas.Add((int)worldMallQueryItemRet.type, new Dictionary<uint, MallItemInfo>());
				}
				List<MallItemInfo> list = new List<MallItemInfo>(this.mGiftPackDatas[(int)worldMallQueryItemRet.type].Values);
				this.mGiftPackDatas[(int)worldMallQueryItemRet.type].Clear();
				for (int i = 0; i < worldMallQueryItemRet.items.Length; i++)
				{
					this.mGiftPackDatas[(int)worldMallQueryItemRet.type][worldMallQueryItemRet.items[i].id] = worldMallQueryItemRet.items[i];
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeMallDataChanged, worldMallQueryItemRet.type, null, null, null);
				if (worldMallQueryItemRet.type == 7)
				{
					for (int j = 0; j < worldMallQueryItemRet.items.Length; j++)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, worldMallQueryItemRet.items[j].id, null, null, null);
					}
					for (int k = 0; k < list.Count; k++)
					{
						if (!this.mGiftPackDatas[(int)worldMallQueryItemRet.type].ContainsKey(list[k].id))
						{
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, list[k].id, null, null, null);
						}
					}
				}
				else
				{
					uint num = this._GetActivityGiftPackActivityId((MallTypeTable.eMallType)worldMallQueryItemRet.type);
					if (num != 0U)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, num, null, null, null);
					}
				}
			}
		}

		// Token: 0x0600AD7E RID: 44414 RVA: 0x0025C508 File Offset: 0x0025A908
		private uint _GetActivityGiftPackActivityId(MallTypeTable.eMallType mallType)
		{
			foreach (OpActivityData opActivityData in this.mLimitTimeActivityDatas.Values)
			{
				if ((opActivityData.tmpType == 5000U && mallType == (MallTypeTable.eMallType)opActivityData.parm) || (opActivityData.tmpType == 5900U && mallType == (MallTypeTable.eMallType)opActivityData.parm))
				{
					return opActivityData.dataId;
				}
			}
			return 0U;
		}

		// Token: 0x0600AD7F RID: 44415 RVA: 0x0025C5AC File Offset: 0x0025A9AC
		public uint GetActivityVanityBonusActivityId()
		{
			return this._GetAdditionBuffActivityId(EadditionBuffType.XuKong);
		}

		// Token: 0x0600AD80 RID: 44416 RVA: 0x0025C5B5 File Offset: 0x0025A9B5
		public uint GetActivityChaosAdditionID()
		{
			return this._GetAdditionBuffActivityId(EadditionBuffType.HunDun);
		}

		// Token: 0x0600AD81 RID: 44417 RVA: 0x0025C5C0 File Offset: 0x0025A9C0
		private uint _GetAdditionBuffActivityId(EadditionBuffType eadditionBuffType)
		{
			foreach (OpActivityData opActivityData in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData.tmpType == 2800U && opActivityData.parm == (uint)eadditionBuffType)
				{
					return opActivityData.dataId;
				}
			}
			return 0U;
		}

		// Token: 0x0600AD82 RID: 44418 RVA: 0x0025C648 File Offset: 0x0025AA48
		public OpActivityData _GetBlackMarketMerchantOpActivityData()
		{
			foreach (OpActivityData opActivityData in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData.tmpType == 4000U)
				{
					if (opActivityData.state == 1)
					{
						return opActivityData;
					}
				}
			}
			return null;
		}

		// Token: 0x0600AD83 RID: 44419 RVA: 0x0025C6D4 File Offset: 0x0025AAD4
		public string GetActiveBubbleInfo(ActivityLimitTimeFactory.EActivityType eActivityType)
		{
			OpActivityData opActivityData = null;
			foreach (OpActivityData opActivityData2 in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData2.tmpType == (uint)eActivityType)
				{
					if (opActivityData2.state == 1)
					{
						opActivityData = opActivityData2;
						break;
					}
				}
			}
			string result = string.Empty;
			if (opActivityData != null)
			{
				int num = (int)(opActivityData.endTime - DataManager<TimeManager>.GetInstance().GetServerTime());
				int num2 = num / 86400;
				if (num2 <= 0)
				{
					num2 = 1;
				}
				if (num2 < 4)
				{
					if (eActivityType == ActivityLimitTimeFactory.EActivityType.OAT_MAGICALJOURENYACTIVITY)
					{
						result = TR.Value("activity_zillionaire_game_bubble_info", num2);
					}
					else if (eActivityType == ActivityLimitTimeFactory.EActivityType.OAT_GOBLIN_SHOP_ACT)
					{
						result = TR.Value("activity_goblin_shop_bubble_info", num2);
					}
				}
			}
			return result;
		}

		// Token: 0x0600AD84 RID: 44420 RVA: 0x0025C7D8 File Offset: 0x0025ABD8
		public bool CheckFashionSynthesisActivityIsOpen()
		{
			foreach (OpActivityData opActivityData in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData.tmpType == 5900U)
				{
					if (opActivityData.parm2.Length > 0)
					{
						if (opActivityData.parm2[0] == 4U)
						{
							if (opActivityData.state == 1)
							{
								if (opActivityData.parm3.Length <= 0)
								{
									return false;
								}
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600AD85 RID: 44421 RVA: 0x0025C8A0 File Offset: 0x0025ACA0
		public bool CheckDropToDoubleActivityIsOpen(int taskId, ref int discount)
		{
			bool result = false;
			OpActivityData opActivityData = null;
			foreach (OpActivityData opActivityData2 in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData2.tmpType == 6700U)
				{
					if (opActivityData2.state == 1)
					{
						opActivityData = opActivityData2;
					}
				}
			}
			if (opActivityData != null && opActivityData.tasks.Length > 0)
			{
				OpActTaskData opActTaskData = opActivityData.tasks[0];
				OpActTask limitTimeTaskData = this.GetLimitTimeTaskData(opActTaskData.dataid);
				if (limitTimeTaskData != null)
				{
					if (limitTimeTaskData.state != 1)
					{
						return result;
					}
					if (((IList)opActTaskData.variables).Contains((uint)taskId))
					{
						result = true;
						if (opActTaskData.variables2.Length > 0)
						{
							discount = (int)opActTaskData.variables2[0];
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600AD86 RID: 44422 RVA: 0x0025C9A0 File Offset: 0x0025ADA0
		private void _OnGiftBuyRes(MsgDATA msg)
		{
			WorldMallBuyRet worldMallBuyRet = new WorldMallBuyRet();
			worldMallBuyRet.decode(msg.bytes);
			MallItemInfo mallItemInfo = this._GetGiftPackById(worldMallBuyRet.mallitemid);
			if (mallItemInfo != null)
			{
				if (mallItemInfo.type == 7)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, mallItemInfo.id, null, null, null);
				}
				else
				{
					uint num = this._GetActivityGiftPackActivityId((MallTypeTable.eMallType)mallItemInfo.type);
					if (num != 0U)
					{
						LimitTimeActivityTaskUpdateData param = new LimitTimeActivityTaskUpdateData((int)num, (int)mallItemInfo.id);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskDataUpdate, param, null, null, null);
					}
				}
			}
		}

		// Token: 0x0600AD87 RID: 44423 RVA: 0x0025CA34 File Offset: 0x0025AE34
		private void _OnSyncLimitTimeAct(MsgDATA msg)
		{
			SyncWorldMallGiftPackActivityState stream = new SyncWorldMallGiftPackActivityState();
			stream.decode(msg.bytes);
		}

		// Token: 0x0600AD88 RID: 44424 RVA: 0x0025CA54 File Offset: 0x0025AE54
		private WorldMallQueryItemReq _ReadReqInfoFromTable(int tableId)
		{
			WorldMallQueryItemReq worldMallQueryItemReq = null;
			MallTypeTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallTypeTable>(tableId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				worldMallQueryItemReq = new WorldMallQueryItemReq();
				worldMallQueryItemReq.type = (byte)tableItem.MallType;
				FlatBufferArray<MallTypeTable.eMallSubType> mallSubType = tableItem.MallSubType;
				if (mallSubType != null && mallSubType.Count > 0)
				{
					worldMallQueryItemReq.subType = 0;
					if (mallSubType[0] == MallTypeTable.eMallSubType.MST_NONE)
					{
						worldMallQueryItemReq.subType = 0;
					}
				}
				worldMallQueryItemReq.occu = (byte)tableItem.ClassifyJob;
				worldMallQueryItemReq.moneyType = (byte)tableItem.MoneyID;
			}
			return worldMallQueryItemReq;
		}

		// Token: 0x0600AD89 RID: 44425 RVA: 0x0025CAE0 File Offset: 0x0025AEE0
		private MallItemInfo _GetGiftPackById(uint mallitemid)
		{
			foreach (Dictionary<uint, MallItemInfo> dictionary in this.mGiftPackDatas.Values)
			{
				if (dictionary.ContainsKey(mallitemid))
				{
					return dictionary[mallitemid];
				}
			}
			return null;
		}

		// Token: 0x0600AD8A RID: 44426 RVA: 0x0025CB58 File Offset: 0x0025AF58
		public int GetActiveIdFromType(ActivityLimitTimeFactory.EActivityType type)
		{
			foreach (KeyValuePair<uint, OpActivityData> keyValuePair in this.mLimitTimeActivityDatas)
			{
				if (keyValuePair.Value.tmpType == (uint)type)
				{
					Dictionary<uint, OpActivityData>.Enumerator enumerator;
					KeyValuePair<uint, OpActivityData> keyValuePair2 = enumerator.Current;
					return (int)keyValuePair2.Key;
				}
			}
			return 0;
		}

		// Token: 0x0600AD8B RID: 44427 RVA: 0x0025CBB0 File Offset: 0x0025AFB0
		public OpActivityData GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType type)
		{
			int activeIdFromType = this.GetActiveIdFromType(type);
			return this.GetLimitTimeActivityData((uint)activeIdFromType);
		}

		// Token: 0x0600AD8C RID: 44428 RVA: 0x0025CBD0 File Offset: 0x0025AFD0
		public List<uint> GetHaveRecivedTaskID(ActivityLimitTimeFactory.EActivityType type)
		{
			List<uint> list = new List<uint>();
			OpActivityData activeDataFromType = this.GetActiveDataFromType(type);
			if (type == ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY)
			{
				if (activeDataFromType != null && activeDataFromType.tasks != null)
				{
					for (int i = 0; i < activeDataFromType.tasks.Length; i++)
					{
						OpActTaskData opActTaskData = activeDataFromType.tasks[i];
						if (opActTaskData != null)
						{
							if (opActTaskData.variables2.Length <= 0 || opActTaskData.variables2[0] != 1U)
							{
								OpActTask limitTimeTaskData = this.GetLimitTimeTaskData(opActTaskData.dataid);
								if (limitTimeTaskData != null)
								{
									if (limitTimeTaskData.state != 0)
									{
										list.Add(opActTaskData.dataid);
									}
								}
							}
						}
					}
				}
			}
			else if (activeDataFromType != null && activeDataFromType.tasks != null)
			{
				for (int j = 0; j < activeDataFromType.tasks.Length; j++)
				{
					OpActTaskData opActTaskData2 = activeDataFromType.tasks[j];
					if (opActTaskData2 != null)
					{
						OpActTask limitTimeTaskData2 = this.GetLimitTimeTaskData(opActTaskData2.dataid);
						if (limitTimeTaskData2 != null)
						{
							if (limitTimeTaskData2.state != 0)
							{
								list.Add(opActTaskData2.dataid);
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600AD8D RID: 44429 RVA: 0x0025CD08 File Offset: 0x0025B108
		public bool GettAnniverTaskIsFinish(EAnniverBuffPrayType buffType)
		{
			bool result = false;
			OpActTaskData anniverFinishTaskData = this.GetAnniverFinishTaskData(ActivityLimitTimeFactory.EActivityType.OAT_SECOND_ANNIVERSARY_PRAY, buffType);
			if (anniverFinishTaskData != null)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600AD8E RID: 44430 RVA: 0x0025CD30 File Offset: 0x0025B130
		public bool IsLeftChallengeTimes(EAnniverBuffPrayType buffType, string counterKey)
		{
			bool result = false;
			OpActTaskData anniverFinishTaskData = this.GetAnniverFinishTaskData(ActivityLimitTimeFactory.EActivityType.OAT_SECOND_ANNIVERSARY_PRAY, buffType);
			if (anniverFinishTaskData != null)
			{
				int count = DataManager<CountDataManager>.GetInstance().GetCount(counterKey);
				if (anniverFinishTaskData.variables2 != null && anniverFinishTaskData.variables2.Length > 1)
				{
					int num = (int)anniverFinishTaskData.variables2[0];
					result = (count < num);
				}
			}
			return result;
		}

		// Token: 0x0600AD8F RID: 44431 RVA: 0x0025CD88 File Offset: 0x0025B188
		public int GetAnniverTaskValue(EAnniverBuffPrayType buffType)
		{
			uint result = 0U;
			OpActTaskData anniverFinishTaskData = this.GetAnniverFinishTaskData(ActivityLimitTimeFactory.EActivityType.OAT_SECOND_ANNIVERSARY_PRAY, buffType);
			if (anniverFinishTaskData != null && anniverFinishTaskData.variables2 != null)
			{
				if (anniverFinishTaskData.variables2.Length >= 2)
				{
					result = anniverFinishTaskData.variables2[1];
				}
				else if (anniverFinishTaskData.variables2.Length >= 1)
				{
					result = anniverFinishTaskData.variables2[0];
				}
			}
			return (int)result;
		}

		// Token: 0x0600AD90 RID: 44432 RVA: 0x0025CDEC File Offset: 0x0025B1EC
		private OpActTaskData GetAnniverFinishTaskData(ActivityLimitTimeFactory.EActivityType activityType, EAnniverBuffPrayType buffType)
		{
			OpActivityData activeDataFromType = this.GetActiveDataFromType(activityType);
			if (activeDataFromType != null && activeDataFromType.tasks != null)
			{
				for (int i = 0; i < activeDataFromType.tasks.Length; i++)
				{
					OpActTaskData opActTaskData = activeDataFromType.tasks[i];
					if (opActTaskData != null)
					{
						OpActTask limitTimeTaskData = this.GetLimitTimeTaskData(opActTaskData.dataid);
						if (limitTimeTaskData != null)
						{
							if (limitTimeTaskData.state == 2 && opActTaskData.completeNum == (uint)buffType)
							{
								return opActTaskData;
							}
						}
					}
				}
			}
			return null;
		}

		// Token: 0x0600AD91 RID: 44433 RVA: 0x0025CE74 File Offset: 0x0025B274
		public void RequestOnTakeActTask(uint activityDataId, uint taskDataId, ulong tempParam = 0UL)
		{
			TakeOpActTaskReq takeOpActTaskReq = new TakeOpActTaskReq();
			takeOpActTaskReq.activityDataId = activityDataId;
			takeOpActTaskReq.taskDataId = taskDataId;
			if (tempParam != 0UL)
			{
				takeOpActTaskReq.param = tempParam;
			}
			NetManager.Instance().SendCommand<TakeOpActTaskReq>(ServerType.GATE_SERVER, takeOpActTaskReq);
		}

		// Token: 0x0600AD92 RID: 44434 RVA: 0x0025CEB4 File Offset: 0x0025B2B4
		public void RequestActivityTaskInfo(uint activityDataId)
		{
			SceneOpActivityTaskInfoReq sceneOpActivityTaskInfoReq = new SceneOpActivityTaskInfoReq();
			sceneOpActivityTaskInfoReq.opActId = activityDataId;
			NetManager.Instance().SendCommand<SceneOpActivityTaskInfoReq>(ServerType.GATE_SERVER, sceneOpActivityTaskInfoReq);
		}

		// Token: 0x0600AD93 RID: 44435 RVA: 0x0025CEDC File Offset: 0x0025B2DC
		private void _OnSyncLimitTimeActivity(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityDatas syncOpActivityDatas = new SyncOpActivityDatas();
			syncOpActivityDatas.decode(msg.bytes, ref num);
			if (syncOpActivityDatas.datas == null)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < syncOpActivityDatas.datas.Length; i++)
			{
				if (syncOpActivityDatas.datas[i].tmpType == 17U && syncOpActivityDatas.datas[i].state == 1)
				{
					flag = true;
					break;
				}
			}
			for (int j = 0; j < syncOpActivityDatas.datas.Length; j++)
			{
				OpActivityData opActivityData = syncOpActivityDatas.datas[j];
				if (opActivityData != null && opActivityData.tmpType != 16U && opActivityData.tmpType != 1900U && opActivityData.tmpType != 5100U && opActivityData.tmpType != 3200U)
				{
					if (!flag || syncOpActivityDatas.datas[j].tmpType != 1000U)
					{
						this.mLimitTimeActivityDatas[syncOpActivityDatas.datas[j].dataId] = syncOpActivityDatas.datas[j];
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, syncOpActivityDatas.datas[j].dataId, null, null, null);
						for (int k = 0; k < opActivityData.tasks.Length; k++)
						{
							OpActTaskData opActTaskData = opActivityData.tasks[k];
							if (opActTaskData == null)
							{
								return;
							}
							if (opActTaskData.accountDailySubmitLimit > 0U)
							{
								DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)opActTaskData.dataid, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
							}
							if (opActTaskData.accountTotalSubmitLimit > 0U)
							{
								DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)opActTaskData.dataid, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
							}
							if (opActTaskData.accountWeeklySubmitLimit > 0U)
							{
								DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)opActTaskData.dataid, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AD94 RID: 44436 RVA: 0x0025D0D0 File Offset: 0x0025B4D0
		private void _OnSyncLimitTimeActivityTasks(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityTasks syncOpActivityTasks = new SyncOpActivityTasks();
			syncOpActivityTasks.decode(msg.bytes, ref num);
			if (syncOpActivityTasks.tasks != null && syncOpActivityTasks.tasks.Length > 0)
			{
				for (int i = 0; i < syncOpActivityTasks.tasks.Length; i++)
				{
					this.mLimitTimeTaskDatas[syncOpActivityTasks.tasks[i].dataId] = syncOpActivityTasks.tasks[i];
					LimitTimeActivityTaskUpdateData param = new LimitTimeActivityTaskUpdateData(this._GetLimitTimeActivityIdByTaskId(syncOpActivityTasks.tasks[i].dataId), (int)syncOpActivityTasks.tasks[i].dataId);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskDataUpdate, param, null, null, null);
				}
			}
		}

		// Token: 0x0600AD95 RID: 44437 RVA: 0x0025D180 File Offset: 0x0025B580
		private void _OnSyncLimitTimeActivityTaskChange(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityTaskChange syncOpActivityTaskChange = new SyncOpActivityTaskChange();
			syncOpActivityTaskChange.decode(msg.bytes, ref num);
			if (syncOpActivityTaskChange.tasks != null && syncOpActivityTaskChange.tasks.Length > 0)
			{
				for (int i = 0; i < syncOpActivityTaskChange.tasks.Length; i++)
				{
					OpActTask opActTask = syncOpActivityTaskChange.tasks[i];
					this.mLimitTimeTaskDatas[opActTask.dataId] = opActTask;
					LimitTimeActivityTaskUpdateData param = new LimitTimeActivityTaskUpdateData(this._GetLimitTimeActivityIdByTaskId(opActTask.dataId), (int)opActTask.dataId);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskDataUpdate, param, null, null, null);
				}
			}
		}

		// Token: 0x0600AD96 RID: 44438 RVA: 0x0025D220 File Offset: 0x0025B620
		private void _OnSyncLimitTimeActivityStateChange(MsgDATA msg)
		{
			int num = 0;
			SyncOpActivityStateChange syncOpActivityStateChange = new SyncOpActivityStateChange();
			syncOpActivityStateChange.decode(msg.bytes, ref num);
			if (syncOpActivityStateChange.data != null)
			{
				this.mLimitTimeActivityDatas[syncOpActivityStateChange.data.dataId] = syncOpActivityStateChange.data;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, syncOpActivityStateChange.data.dataId, null, null, null);
				if (this.mLimitTimeActivityDatas.ContainsKey(syncOpActivityStateChange.data.dataId) && syncOpActivityStateChange.data.state == 0)
				{
					this._RemoveLimitTimeTasksByActivityId(syncOpActivityStateChange.data.dataId);
					this.mLimitTimeActivityDatas.Remove(syncOpActivityStateChange.data.dataId);
				}
			}
		}

		// Token: 0x0600AD97 RID: 44439 RVA: 0x0025D2E0 File Offset: 0x0025B6E0
		private void _OnSysncLimitTimeAccountNum(MsgDATA msg)
		{
			int num = 0;
			SceneOpActivityGetCounterRes sceneOpActivityGetCounterRes = new SceneOpActivityGetCounterRes();
			sceneOpActivityGetCounterRes.decode(msg.bytes, ref num);
			if (sceneOpActivityGetCounterRes != null)
			{
				if (sceneOpActivityGetCounterRes.counterId == 1002U || sceneOpActivityGetCounterRes.counterId == 4002U || sceneOpActivityGetCounterRes.counterId == 2001U || sceneOpActivityGetCounterRes.counterId == 1001U || sceneOpActivityGetCounterRes.counterId == 2002U || sceneOpActivityGetCounterRes.counterId == 4008U || sceneOpActivityGetCounterRes.counterId == 1004U || sceneOpActivityGetCounterRes.counterId == 1005U || sceneOpActivityGetCounterRes.counterId == 2003U)
				{
					if (!this.mLimitTimeActivityCounterResDic.ContainsKey(sceneOpActivityGetCounterRes.opActId))
					{
						this.mLimitTimeActivityCounterResDic.Add(sceneOpActivityGetCounterRes.opActId, new AcivtityCounterRes(sceneOpActivityGetCounterRes.counterId, sceneOpActivityGetCounterRes.counterValue));
					}
					else
					{
						this.mLimitTimeActivityCounterResDic[sceneOpActivityGetCounterRes.opActId].CounterValue = sceneOpActivityGetCounterRes.counterValue;
					}
				}
				else if (sceneOpActivityGetCounterRes.counterId == 4003U || sceneOpActivityGetCounterRes.counterId == 4009U)
				{
					if (!this.mBossActivityCounterResDic.ContainsKey(sceneOpActivityGetCounterRes.opActId))
					{
						this.mBossActivityCounterResDic.Add(sceneOpActivityGetCounterRes.opActId, new AcivtityCounterRes(sceneOpActivityGetCounterRes.counterId, sceneOpActivityGetCounterRes.counterValue));
					}
					else
					{
						this.mBossActivityCounterResDic[sceneOpActivityGetCounterRes.opActId].CounterValue = sceneOpActivityGetCounterRes.counterValue;
					}
				}
				else if (sceneOpActivityGetCounterRes.counterId == 1003U)
				{
					if (!this.mDungeonCounterResDic.ContainsKey(sceneOpActivityGetCounterRes.opActId))
					{
						this.mDungeonCounterResDic.Add(sceneOpActivityGetCounterRes.opActId, new AcivtityCounterRes(sceneOpActivityGetCounterRes.counterId, sceneOpActivityGetCounterRes.counterValue));
					}
					else
					{
						this.mDungeonCounterResDic[sceneOpActivityGetCounterRes.opActId].CounterValue = sceneOpActivityGetCounterRes.counterValue;
					}
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, sceneOpActivityGetCounterRes.opActId, sceneOpActivityGetCounterRes.counterId, (int)sceneOpActivityGetCounterRes.counterValue, null);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, sceneOpActivityGetCounterRes.opActId, null, null, null);
				LimitTimeActivityTaskUpdateData param = new LimitTimeActivityTaskUpdateData(this._GetLimitTimeActivityIdByTaskId(sceneOpActivityGetCounterRes.opActId), (int)sceneOpActivityGetCounterRes.opActId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskDataUpdate, param, null, null, null);
			}
		}

		// Token: 0x0600AD98 RID: 44440 RVA: 0x0025D558 File Offset: 0x0025B958
		public void OnSceneOpActivityAcceptTaskReq(uint opActId, uint taskId)
		{
			SceneOpActivityAcceptTaskReq sceneOpActivityAcceptTaskReq = new SceneOpActivityAcceptTaskReq();
			sceneOpActivityAcceptTaskReq.opActId = opActId;
			sceneOpActivityAcceptTaskReq.taskId = taskId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneOpActivityAcceptTaskReq>(ServerType.GATE_SERVER, sceneOpActivityAcceptTaskReq);
			}
		}

		// Token: 0x0600AD99 RID: 44441 RVA: 0x0025D594 File Offset: 0x0025B994
		public void SendSceneOpActivityGetCounterReq(ActivityLimitTimeFactory.EActivityType eActivityType, ActivityLimitTimeFactory.EActivityCounterType eActivityCounterType)
		{
			SceneOpActivityGetCounterReq sceneOpActivityGetCounterReq = new SceneOpActivityGetCounterReq();
			sceneOpActivityGetCounterReq.opActId = (uint)DataManager<ActivityDataManager>.GetInstance().GetActiveIdFromType(eActivityType);
			sceneOpActivityGetCounterReq.counterId = (uint)eActivityCounterType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneOpActivityGetCounterReq>(ServerType.GATE_SERVER, sceneOpActivityGetCounterReq);
			}
		}

		// Token: 0x0600AD9A RID: 44442 RVA: 0x0025D5DC File Offset: 0x0025B9DC
		public void SendSceneOpActivityGetCounterReq(int dungeonSubType)
		{
			SceneOpActivityGetCounterReq sceneOpActivityGetCounterReq = new SceneOpActivityGetCounterReq();
			sceneOpActivityGetCounterReq.opActId = (uint)dungeonSubType;
			sceneOpActivityGetCounterReq.counterId = 1003U;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneOpActivityGetCounterReq>(ServerType.GATE_SERVER, sceneOpActivityGetCounterReq);
			}
		}

		// Token: 0x0600AD9B RID: 44443 RVA: 0x0025D61C File Offset: 0x0025BA1C
		public void SendSceneOpActivityGetCounterReq(int taskID, ActivityLimitTimeFactory.EActivityCounterType eActivityCounterType)
		{
			SceneOpActivityGetCounterReq sceneOpActivityGetCounterReq = new SceneOpActivityGetCounterReq();
			sceneOpActivityGetCounterReq.opActId = (uint)taskID;
			sceneOpActivityGetCounterReq.counterId = (uint)eActivityCounterType;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneOpActivityGetCounterReq>(ServerType.GATE_SERVER, sceneOpActivityGetCounterReq);
			}
		}

		// Token: 0x0600AD9C RID: 44444 RVA: 0x0025D658 File Offset: 0x0025BA58
		public uint GetActivityConunter(ActivityLimitTimeFactory.EActivityType eActivityType, ActivityLimitTimeFactory.EActivityCounterType eActivityCounterType)
		{
			uint result = 0U;
			AcivtityCounterRes acivtityCounterRes = null;
			int activeIdFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveIdFromType(eActivityType);
			if (eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OAT_SUMMER_WEEKLY_VACATION || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.QAT_SUMMER_DAILY_CHARGE || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_ACCEPT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_ONLINE_COUNT || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK)
			{
				if (this.mLimitTimeActivityCounterResDic.TryGetValue((uint)activeIdFromType, out acivtityCounterRes) && acivtityCounterRes.CounterId == (uint)eActivityCounterType)
				{
					result = acivtityCounterRes.CounterValue;
				}
			}
			else if ((eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ITEM_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_ACCOUNT_ONLINE_DAT_COUNT) && this.mBossActivityCounterResDic.TryGetValue((uint)activeIdFromType, out acivtityCounterRes) && acivtityCounterRes.CounterId == (uint)eActivityCounterType)
			{
				result = acivtityCounterRes.CounterValue;
			}
			return result;
		}

		// Token: 0x0600AD9D RID: 44445 RVA: 0x0025D72C File Offset: 0x0025BB2C
		public uint GetActivityConunter(int dungeonSubType)
		{
			uint result = 0U;
			AcivtityCounterRes acivtityCounterRes = null;
			if (this.mDungeonCounterResDic.TryGetValue((uint)dungeonSubType, out acivtityCounterRes) && acivtityCounterRes.CounterId == 1003U)
			{
				result = acivtityCounterRes.CounterValue;
			}
			return result;
		}

		// Token: 0x0600AD9E RID: 44446 RVA: 0x0025D768 File Offset: 0x0025BB68
		public uint GetActivityConunter(uint taskID, ActivityLimitTimeFactory.EActivityCounterType eActivityCounterType)
		{
			uint result = 0U;
			AcivtityCounterRes acivtityCounterRes = null;
			if (eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OAT_SUMMER_WEEKLY_VACATION || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.QAT_SUMMER_DAILY_CHARGE || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_MONEY_CONSUME_COUNT || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_ACCEPT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_ONLINE_COUNT || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK)
			{
				if (this.mLimitTimeActivityCounterResDic.TryGetValue(taskID, out acivtityCounterRes) && acivtityCounterRes.CounterId == (uint)eActivityCounterType)
				{
					result = acivtityCounterRes.CounterValue;
				}
			}
			else if ((eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ITEM_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK || eActivityCounterType == ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_ACCOUNT_ONLINE_DAT_COUNT) && this.mBossActivityCounterResDic.TryGetValue(taskID, out acivtityCounterRes) && acivtityCounterRes.CounterId == (uint)eActivityCounterType)
			{
				result = acivtityCounterRes.CounterValue;
			}
			return result;
		}

		// Token: 0x0600AD9F RID: 44447 RVA: 0x0025D848 File Offset: 0x0025BC48
		public bool IsShowFirstDiscountDes(uint mallItemId)
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
			if (activeDataFromType != null && activeDataFromType.state == 1)
			{
				bool flag = DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_NEW_SERVER_GIFT_DISCOUNT) > 0UL;
				if (flag)
				{
					return false;
				}
				if (activeDataFromType.parm2 != null)
				{
					uint[] parm = activeDataFromType.parm2;
					for (int i = 0; i < parm.Length; i++)
					{
						if (parm[i] == mallItemId)
						{
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600ADA0 RID: 44448 RVA: 0x0025D8C4 File Offset: 0x0025BCC4
		private void _RemoveLimitTimeTasksByActivityId(uint activityId)
		{
			if (this.mLimitTimeActivityDatas.ContainsKey(activityId))
			{
				for (int i = 0; i < this.mLimitTimeActivityDatas[activityId].tasks.Length; i++)
				{
					this.mLimitTimeTaskDatas.Remove(this.mLimitTimeActivityDatas[activityId].tasks[i].dataid);
				}
			}
		}

		// Token: 0x0600ADA1 RID: 44449 RVA: 0x0025D92C File Offset: 0x0025BD2C
		public int _GetLimitTimeActivityIdByTaskId(uint taskId)
		{
			List<uint> list = new List<uint>(this.mLimitTimeActivityDatas.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				OpActivityData opActivityData = this.mLimitTimeActivityDatas[list[i]];
				for (int j = 0; j < opActivityData.tasks.Length; j++)
				{
					if (opActivityData.tasks[j].dataid == taskId)
					{
						return (int)opActivityData.dataId;
					}
				}
			}
			return 0;
		}

		// Token: 0x0600ADA2 RID: 44450 RVA: 0x0025D9A8 File Offset: 0x0025BDA8
		public void SendSubmitBossExchangeTask(int taskId)
		{
			SceneActiveTaskSubmit sceneActiveTaskSubmit = new SceneActiveTaskSubmit();
			sceneActiveTaskSubmit.taskId = (uint)taskId;
			sceneActiveTaskSubmit.param1 = 0U;
			NetManager.Instance().SendCommand<SceneActiveTaskSubmit>(ServerType.GATE_SERVER, sceneActiveTaskSubmit);
		}

		// Token: 0x0600ADA3 RID: 44451 RVA: 0x0025D9D8 File Offset: 0x0025BDD8
		public void RequestBossKillData(int activityId)
		{
			WorldActivityMonsterReq worldActivityMonsterReq = new WorldActivityMonsterReq();
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>(activityId, string.Empty, string.Empty);
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
			worldActivityMonsterReq.activityId = (uint)activityId;
			NetManager.Instance().SendCommand<WorldActivityMonsterReq>(ServerType.GATE_SERVER, worldActivityMonsterReq);
		}

		// Token: 0x0600ADA4 RID: 44452 RVA: 0x0025DA70 File Offset: 0x0025BE70
		private void _OnSyncBossActivities(MsgDATA data)
		{
			SceneSyncClientActivities sceneSyncClientActivities = new SceneSyncClientActivities();
			sceneSyncClientActivities.decode(data.bytes);
			for (int i = 0; i < sceneSyncClientActivities.activities.Length; i++)
			{
				ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)sceneSyncClientActivities.activities[i].id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.ActivityType == ActiveMainTable.eActivityType.ExchangeActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.KillBossActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.QuestActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.SpecialExchangeActivity)
					{
						if (tableItem.ActivityType == ActiveMainTable.eActivityType.KillBossActivity)
						{
							this.RequestBossKillData((int)sceneSyncClientActivities.activities[i].id);
						}
						if (!this.mBossActivityDatas.ContainsKey(sceneSyncClientActivities.activities[i].id))
						{
							this.mBossActivityDatas.Add(sceneSyncClientActivities.activities[i].id, sceneSyncClientActivities.activities[i]);
							UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, sceneSyncClientActivities.activities[i].id, null, null, null);
						}
					}
				}
			}
		}

		// Token: 0x0600ADA5 RID: 44453 RVA: 0x0025DB88 File Offset: 0x0025BF88
		private void _OnRecvBossActivityMonsterInfo(MsgDATA data)
		{
			WorldActivityMonsterRes worldActivityMonsterRes = new WorldActivityMonsterRes();
			worldActivityMonsterRes.decode(data.bytes);
			if (worldActivityMonsterRes.monsters == null || worldActivityMonsterRes.monsters.Length <= 0)
			{
				return;
			}
			uint activityId = worldActivityMonsterRes.activityId;
			if (activityId > 0U)
			{
				this.mBossKillMonsterDatas[activityId] = worldActivityMonsterRes;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, activityId, null, null, null);
			}
		}

		// Token: 0x0600ADA6 RID: 44454 RVA: 0x0025DBF4 File Offset: 0x0025BFF4
		private void _OnRecvBossActivityTaskStateChange(MsgDATA data)
		{
			SceneNotifyActiveTaskStatus sceneNotifyActiveTaskStatus = new SceneNotifyActiveTaskStatus();
			sceneNotifyActiveTaskStatus.decode(data.bytes);
			this.mBossTaskStatusDatas[sceneNotifyActiveTaskStatus.taskId] = sceneNotifyActiveTaskStatus;
			LimitTimeActivityTaskUpdateData param = new LimitTimeActivityTaskUpdateData(this._GetBossExchangeActivityIdByTaskId((int)sceneNotifyActiveTaskStatus.taskId), (int)sceneNotifyActiveTaskStatus.taskId);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskDataUpdate, param, null, null, null);
		}

		// Token: 0x0600ADA7 RID: 44455 RVA: 0x0025DC50 File Offset: 0x0025C050
		private void _OnSyncBossActivityTaskData(MsgDATA data)
		{
			SceneNotifyActiveTaskVar sceneNotifyActiveTaskVar = new SceneNotifyActiveTaskVar();
			sceneNotifyActiveTaskVar.decode(data.bytes);
			this.mBossTaskDatas[sceneNotifyActiveTaskVar.taskId] = sceneNotifyActiveTaskVar;
			LimitTimeActivityTaskUpdateData param = new LimitTimeActivityTaskUpdateData(this._GetBossExchangeActivityIdByTaskId((int)sceneNotifyActiveTaskVar.taskId), (int)sceneNotifyActiveTaskVar.taskId);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeTaskDataUpdate, param, null, null, null);
		}

		// Token: 0x0600ADA8 RID: 44456 RVA: 0x0025DCAC File Offset: 0x0025C0AC
		private void _OnRecvBossActivityStateChange(MsgDATA data)
		{
			WorldNotifyClientActivity worldNotifyClientActivity = new WorldNotifyClientActivity();
			worldNotifyClientActivity.decode(data.bytes);
			ActiveMainTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActiveMainTable>((int)worldNotifyClientActivity.id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.ActivityType == ActiveMainTable.eActivityType.ExchangeActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.KillBossActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.QuestActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.SpecialExchangeActivity)
			{
				ActivityInfo value = new ActivityInfo
				{
					state = worldNotifyClientActivity.type,
					id = worldNotifyClientActivity.id,
					level = worldNotifyClientActivity.level,
					name = worldNotifyClientActivity.name,
					preTime = worldNotifyClientActivity.preTime,
					startTime = worldNotifyClientActivity.startTime,
					dueTime = worldNotifyClientActivity.dueTime
				};
				this.mBossActivityDatas[worldNotifyClientActivity.id] = value;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ActivityLimitTimeDataUpdate, worldNotifyClientActivity.id, null, null, null);
				if (worldNotifyClientActivity.type == 0)
				{
					this.mBossActivityDatas.Remove(worldNotifyClientActivity.id);
					if (tableItem.ActivityType == ActiveMainTable.eActivityType.ExchangeActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.QuestActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.QuestActivity || tableItem.ActivityType == ActiveMainTable.eActivityType.SpecialExchangeActivity)
					{
						this._RemoveBossExchangeTasksByActivityId(worldNotifyClientActivity.id);
					}
					else
					{
						this._RemoveBossKillTasksByActivityId(worldNotifyClientActivity.id);
					}
				}
			}
		}

		// Token: 0x0600ADA9 RID: 44457 RVA: 0x0025DE14 File Offset: 0x0025C214
		private void _RemoveBossExchangeTasksByActivityId(uint activityId)
		{
			List<uint> list = new List<uint>(this.mBossTaskDatas.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				if ((long)this._GetBossExchangeActivityIdByTaskId((int)list[i]) == (long)((ulong)activityId))
				{
					this.mBossTaskDatas.Remove(list[i]);
				}
			}
			List<uint> list2 = new List<uint>(this.mBossTaskStatusDatas.Keys);
			for (int j = 0; j < list2.Count; j++)
			{
				if ((long)this._GetBossExchangeActivityIdByTaskId((int)list2[j]) == (long)((ulong)activityId))
				{
					this.mBossTaskStatusDatas.Remove(list2[j]);
				}
			}
		}

		// Token: 0x0600ADAA RID: 44458 RVA: 0x0025DEC4 File Offset: 0x0025C2C4
		private void _RemoveBossKillTasksByActivityId(uint activityId)
		{
			List<uint> list = new List<uint>(this.mBossKillMonsterDatas.Keys);
			for (int i = 0; i < list.Count; i++)
			{
				if (this._GetBossKillActivityIdByTaskId(list[i]) == activityId)
				{
					this.mBossKillMonsterDatas.Remove(list[i]);
				}
			}
		}

		// Token: 0x0600ADAB RID: 44459 RVA: 0x0025DF20 File Offset: 0x0025C320
		private int _GetBossExchangeActivityIdByTaskId(int taskId)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActiveTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActiveTable activeTable = keyValuePair.Value as ActiveTable;
				if (activeTable.ID == taskId)
				{
					return activeTable.TemplateID;
				}
			}
			return 0;
		}

		// Token: 0x0600ADAC RID: 44460 RVA: 0x0025DF7C File Offset: 0x0025C37C
		private uint _GetBossKillActivityIdByTaskId(uint taskId)
		{
			foreach (KeyValuePair<uint, WorldActivityMonsterRes> keyValuePair in this.mBossKillMonsterDatas)
			{
				for (int i = 0; i < keyValuePair.Value.monsters.Length; i++)
				{
					if (taskId == keyValuePair.Value.monsters[i].id)
					{
						return keyValuePair.Key;
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600ADAD RID: 44461 RVA: 0x0025E01C File Offset: 0x0025C41C
		public void OnRequsetBossAccountData(BossExchangeTaskModel data)
		{
			if (data.AccountTotalSubmitLimit > 0)
			{
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq(data.Id, ActivityLimitTimeFactory.EActivityCounterType.OP_ITEM_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
			}
		}

		// Token: 0x0600ADAE RID: 44462 RVA: 0x0025E041 File Offset: 0x0025C441
		public void RegisterBossAccountData(ClientEventSystem.UIEventHandler eventHandler)
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, eventHandler);
		}

		// Token: 0x0600ADAF RID: 44463 RVA: 0x0025E053 File Offset: 0x0025C453
		public void UnRegisterBossAccountData(ClientEventSystem.UIEventHandler eventHandler)
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, eventHandler);
		}

		// Token: 0x0600ADB0 RID: 44464 RVA: 0x0025E068 File Offset: 0x0025C468
		private void InitUltimateChallengeRewardTable()
		{
			if (ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas == null)
			{
				ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas = new List<UltimateChallengeCustomsClearanceRewardItemData>();
			}
			ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<UltimateChallengeRewardTable>())
			{
				UltimateChallengeRewardTable ultimateChallengeRewardTable = keyValuePair.Value as UltimateChallengeRewardTable;
				if (ultimateChallengeRewardTable != null)
				{
					UltimateChallengeCustomsClearanceRewardItemData ultimateChallengeCustomsClearanceRewardItemData = new UltimateChallengeCustomsClearanceRewardItemData();
					ultimateChallengeCustomsClearanceRewardItemData.minDays = ultimateChallengeRewardTable.MinClearDays;
					ultimateChallengeCustomsClearanceRewardItemData.maxDays = ultimateChallengeRewardTable.MaxClearDays;
					ultimateChallengeCustomsClearanceRewardItemData.iconPath = ultimateChallengeRewardTable.Rreview;
					ultimateChallengeCustomsClearanceRewardItemData.rewardItems = CommonUtility.GetSplitDataModelListByTwoSplitChar(ultimateChallengeRewardTable.RewardItem, '|', '_');
					ActivityDataManager.ultimateChallengeCustomsClearanceRewardItemDatas.Add(ultimateChallengeCustomsClearanceRewardItemData);
				}
			}
		}

		// Token: 0x0600ADB1 RID: 44465 RVA: 0x0025E11E File Offset: 0x0025C51E
		public bool IsCustomsClearance()
		{
			return this.GetUltimateCurrentChallengeFloorCount() >= this.GetUltimateChallengeDungeonDailyOpenFloor();
		}

		// Token: 0x0600ADB2 RID: 44466 RVA: 0x0025E134 File Offset: 0x0025C534
		public int GetUltimateChallengeHPPercent()
		{
			int num = DataManager<CountDataManager>.GetInstance().GetCount("zjsl_player_hp");
			if (num == 0 || num > 100000)
			{
				num = 100000;
			}
			float num2 = (float)num / 1000f;
			if (num2 < 1f)
			{
				num2 = 1f;
			}
			return (int)num2;
		}

		// Token: 0x0600ADB3 RID: 44467 RVA: 0x0025E184 File Offset: 0x0025C584
		public int GetUltimateChallengeMPPercent()
		{
			int num = DataManager<CountDataManager>.GetInstance().GetCount("zjsl_player_mp");
			if (num == 0 || num > 1000)
			{
				num = 1000;
			}
			float num2 = (float)num / 10f;
			if (num2 < 1f)
			{
				num2 = 1f;
			}
			return (int)num2;
		}

		// Token: 0x0600ADB4 RID: 44468 RVA: 0x0025E1D4 File Offset: 0x0025C5D4
		public int GetUltimateCurrentChallengeFloorCount()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("zjsl_top_floor");
		}

		// Token: 0x0600ADB5 RID: 44469 RVA: 0x0025E1F4 File Offset: 0x0025C5F4
		public int GetUltimateChallengeMaxFloorRecord()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("zjsl_top_floor_total");
		}

		// Token: 0x0600ADB6 RID: 44470 RVA: 0x0025E214 File Offset: 0x0025C614
		public int GetUltimateChallengeLeftEnterCount()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("zjsl_dungeon_times");
			return this.GetUltimateChallengeMaxEnterCount() - count;
		}

		// Token: 0x0600ADB7 RID: 44471 RVA: 0x0025E239 File Offset: 0x0025C639
		public int GetUltimateChallengeMaxEnterCount()
		{
			return Utility.GetSystemValueFromTable(SystemValueTable.eType2.SVT_ZJSL_DUNGEON_TIMES_DAILY);
		}

		// Token: 0x0600ADB8 RID: 44472 RVA: 0x0025E248 File Offset: 0x0025C648
		public int GetUltimateChallengeLeftCount()
		{
			int count = DataManager<CountDataManager>.GetInstance().GetCount("zjsl_challenge_times");
			return this.GetUltimateChallengeMaxCount() - count;
		}

		// Token: 0x0600ADB9 RID: 44473 RVA: 0x0025E26D File Offset: 0x0025C66D
		public int GetUltimateChallengeMaxCount()
		{
			return 1;
		}

		// Token: 0x0600ADBA RID: 44474 RVA: 0x0025E270 File Offset: 0x0025C670
		public int GetUltimateChallengeDungeonBufID()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("zjsl_dungeon_buff");
		}

		// Token: 0x0600ADBB RID: 44475 RVA: 0x0025E28E File Offset: 0x0025C68E
		public int GetUltimateChallengeDungeonBufLv()
		{
			return 1;
		}

		// Token: 0x0600ADBC RID: 44476 RVA: 0x0025E294 File Offset: 0x0025C694
		public int GetUltimateChallengeInspireBufID()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("zjsl_inspire_buff");
		}

		// Token: 0x17001A75 RID: 6773
		// (get) Token: 0x0600ADBD RID: 44477 RVA: 0x0025E2B2 File Offset: 0x0025C6B2
		// (set) Token: 0x0600ADBE RID: 44478 RVA: 0x0025E2BA File Offset: 0x0025C6BA
		public bool HasPopUpGetInspireBufFrame { get; set; }

		// Token: 0x0600ADBF RID: 44479 RVA: 0x0025E2C3 File Offset: 0x0025C6C3
		public int GetUltimateChallengeInspireBufLv()
		{
			return 1;
		}

		// Token: 0x0600ADC0 RID: 44480 RVA: 0x0025E2C8 File Offset: 0x0025C6C8
		public int GetUltimateChallengeTodayStartFloor()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("zjsl_top_floor") + 1;
		}

		// Token: 0x0600ADC1 RID: 44481 RVA: 0x0025E2E8 File Offset: 0x0025C6E8
		public int GetUltimateChallengeDungeonBufBeginFloor()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("zjsl_dungeon_buff_floor");
		}

		// Token: 0x0600ADC2 RID: 44482 RVA: 0x0025E308 File Offset: 0x0025C708
		public int GetUltimateChallengeDungeonBufDurationFloor(int bufID)
		{
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<UltimateChallengeBuffTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					UltimateChallengeBuffTable ultimateChallengeBuffTable = keyValuePair.Value as UltimateChallengeBuffTable;
					if (ultimateChallengeBuffTable != null)
					{
						if (ultimateChallengeBuffTable.buffID == bufID)
						{
							return ultimateChallengeBuffTable.sustain;
						}
					}
				}
			}
			return 0;
		}

		// Token: 0x0600ADC3 RID: 44483 RVA: 0x0025E372 File Offset: 0x0025C772
		public int GetUltimateChallengeDungeonDailyOpenFloor()
		{
			return Utility.GetSystemValueFromTable(SystemValueTable.eType2.SVT_ZJSL_TOWER_FLOOR_OPEN_DAILY);
		}

		// Token: 0x17001A76 RID: 6774
		// (get) Token: 0x0600ADC4 RID: 44484 RVA: 0x0025E37E File Offset: 0x0025C77E
		// (set) Token: 0x0600ADC5 RID: 44485 RVA: 0x0025E386 File Offset: 0x0025C786
		public bool NotPopUpRefreshBufMsgBox { get; set; }

		// Token: 0x0600ADC6 RID: 44486 RVA: 0x0025E390 File Offset: 0x0025C790
		private void _OnSceneDungeonZjslRefreshBuffRes(MsgDATA msg)
		{
			SceneDungeonZjslRefreshBuffRes sceneDungeonZjslRefreshBuffRes = new SceneDungeonZjslRefreshBuffRes();
			sceneDungeonZjslRefreshBuffRes.decode(msg.bytes);
			if (sceneDungeonZjslRefreshBuffRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneDungeonZjslRefreshBuffRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("refresh_buf_success"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshDungeonBufSuccess, null, null, null, null);
		}

		// Token: 0x0600ADC7 RID: 44487 RVA: 0x0025E3F0 File Offset: 0x0025C7F0
		private void _SceneDungeonZjslClearGetAwardRes(MsgDATA msg)
		{
			SceneDungeonZjslClearGetAwardRes sceneDungeonZjslClearGetAwardRes = new SceneDungeonZjslClearGetAwardRes();
			sceneDungeonZjslClearGetAwardRes.decode(msg.bytes);
			if (sceneDungeonZjslClearGetAwardRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneDungeonZjslClearGetAwardRes.result, string.Empty);
				return;
			}
		}

		// Token: 0x0600ADC8 RID: 44488 RVA: 0x0025E42C File Offset: 0x0025C82C
		public void SendSceneDungeonZjslRefreshBuffReq(int dungeonID, bool useItem = true)
		{
			SceneDungeonZjslRefreshBuffReq sceneDungeonZjslRefreshBuffReq = new SceneDungeonZjslRefreshBuffReq();
			sceneDungeonZjslRefreshBuffReq.dungeonId = (uint)dungeonID;
			sceneDungeonZjslRefreshBuffReq.useItem = ((!useItem) ? 0U : 1U);
			NetManager.Instance().SendCommand<SceneDungeonZjslRefreshBuffReq>(ServerType.GATE_SERVER, sceneDungeonZjslRefreshBuffReq);
		}

		// Token: 0x0600ADC9 RID: 44489 RVA: 0x0025E466 File Offset: 0x0025C866
		public List<ActivityDataManager.MonthlySignInItemData> GetMonthlySignInItemDatas()
		{
			return this.monthlySignInItemDatas;
		}

		// Token: 0x0600ADCA RID: 44490 RVA: 0x0025E46E File Offset: 0x0025C86E
		public List<ActivityDataManager.AccumulativeSignInItemData> GetAccumulativeSignInItemDatas()
		{
			return this.accumulativeSignInItemDatas;
		}

		// Token: 0x0600ADCB RID: 44491 RVA: 0x0025E478 File Offset: 0x0025C878
		public string GetVipAddUpText(int month, int day)
		{
			if (this.monthSignInAwards == null)
			{
				return string.Empty;
			}
			if (!this.monthSignInAwards.ContainsKey(month))
			{
				return string.Empty;
			}
			Dictionary<int, MonthSignAward> dictionary = this.monthSignInAwards[month];
			if (dictionary == null)
			{
				return string.Empty;
			}
			if (!dictionary.ContainsKey(day))
			{
				return string.Empty;
			}
			MonthSignAward monthSignAward = dictionary[day];
			if (monthSignAward == null)
			{
				return string.Empty;
			}
			if (monthSignAward.VIPDouble > Utility.GetSystemValueFromTable(SystemValueTable.eType.SVT_VIPLEVEL_MAX))
			{
				return string.Empty;
			}
			return TR.Value("vip_double", monthSignAward.VIPDouble);
		}

		// Token: 0x0600ADCC RID: 44492 RVA: 0x0025E518 File Offset: 0x0025C918
		public AwardItemData GetAwardItemData(int month, int day)
		{
			if (this.monthSignInAwards == null)
			{
				return null;
			}
			if (!this.monthSignInAwards.ContainsKey(month))
			{
				return null;
			}
			Dictionary<int, MonthSignAward> dictionary = this.monthSignInAwards[month];
			if (dictionary == null)
			{
				return null;
			}
			if (!dictionary.ContainsKey(day))
			{
				return null;
			}
			MonthSignAward monthSignAward = dictionary[day];
			if (monthSignAward == null)
			{
				return null;
			}
			AwardItemData awardItemData = new AwardItemData();
			if (awardItemData == null)
			{
				return null;
			}
			awardItemData.ID = monthSignAward.ItemID;
			awardItemData.Num = monthSignAward.ItemNum;
			return awardItemData;
		}

		// Token: 0x0600ADCD RID: 44493 RVA: 0x0025E5A0 File Offset: 0x0025C9A0
		public int GetHasSignInCount()
		{
			int num = 0;
			if (this.monthlySignInItemDatas != null)
			{
				for (int i = 0; i < this.monthlySignInItemDatas.Count; i++)
				{
					ActivityDataManager.MonthlySignInItemData monthlySignInItemData = this.monthlySignInItemDatas[i];
					if (monthlySignInItemData != null)
					{
						if (monthlySignInItemData.signIned)
						{
							num++;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600ADCE RID: 44494 RVA: 0x0025E600 File Offset: 0x0025CA00
		public bool IsShowSignInRedPoint()
		{
			return DataManager<ActivityDataManager>.GetInstance().CanSignInToday() || DataManager<ActivityDataManager>.GetInstance().CanFillCheckWithFreeCount() || DataManager<ActivityDataManager>.GetInstance().CanGetSignCollectAward();
		}

		// Token: 0x0600ADCF RID: 44495 RVA: 0x0025E63C File Offset: 0x0025CA3C
		public bool CanSignInToday()
		{
			if (this.monthlySignInItemDatas == null)
			{
				return false;
			}
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			if (dateTime.Hour < 6)
			{
				dateTime = dateTime.AddDays(-1.0);
			}
			for (int i = 0; i < this.monthlySignInItemDatas.Count; i++)
			{
				ActivityDataManager.MonthlySignInItemData monthlySignInItemData = this.monthlySignInItemDatas[i];
				if (monthlySignInItemData != null)
				{
					if (monthlySignInItemData.day == dateTime.Day)
					{
						return !monthlySignInItemData.signIned;
					}
				}
			}
			return false;
		}

		// Token: 0x0600ADD0 RID: 44496 RVA: 0x0025E6D5 File Offset: 0x0025CAD5
		public int GetFillCheckCount()
		{
			if (this.monthlySignInCountInfo == null)
			{
				return 0;
			}
			return (int)(this.monthlySignInCountInfo.noFree + this.monthlySignInCountInfo.free + this.monthlySignInCountInfo.activite);
		}

		// Token: 0x0600ADD1 RID: 44497 RVA: 0x0025E708 File Offset: 0x0025CB08
		public bool CanFillCheckWithFreeCount()
		{
			if (this.monthlySignInCountInfo == null)
			{
				return false;
			}
			if (this.monthlySignInCountInfo.free + this.monthlySignInCountInfo.activite == 0)
			{
				return false;
			}
			if (this.monthlySignInItemDatas == null)
			{
				return false;
			}
			int num = 0;
			DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
			if (dateTime.Hour < 6)
			{
				dateTime = dateTime.AddDays(-1.0);
			}
			for (int i = 0; i < this.monthlySignInItemDatas.Count; i++)
			{
				ActivityDataManager.MonthlySignInItemData monthlySignInItemData = this.monthlySignInItemDatas[i];
				if (monthlySignInItemData != null)
				{
					if (monthlySignInItemData.day >= dateTime.Day)
					{
						break;
					}
					if (!monthlySignInItemData.signIned)
					{
						num++;
					}
				}
			}
			return num > 0;
		}

		// Token: 0x0600ADD2 RID: 44498 RVA: 0x0025E7DC File Offset: 0x0025CBDC
		public bool CanGetSignCollectAward()
		{
			if (this.accumulativeSignInItemDatas == null)
			{
				return false;
			}
			int hasSignInCount = DataManager<ActivityDataManager>.GetInstance().GetHasSignInCount();
			for (int i = 0; i < this.accumulativeSignInItemDatas.Count; i++)
			{
				ActivityDataManager.AccumulativeSignInItemData accumulativeSignInItemData = this.accumulativeSignInItemDatas[i];
				if (accumulativeSignInItemData != null)
				{
					if (hasSignInCount >= accumulativeSignInItemData.accumulativeDay && !accumulativeSignInItemData.hasGotAward)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600ADD3 RID: 44499 RVA: 0x0025E850 File Offset: 0x0025CC50
		public static int GetMonthDayNum(int year, int month)
		{
			return DateTime.DaysInMonth(year, month);
		}

		// Token: 0x0600ADD4 RID: 44500 RVA: 0x0025E866 File Offset: 0x0025CC66
		public ActivityDataManager.MonthlySignInCountInfo GetMonthlySignInCountInfo()
		{
			return this.monthlySignInCountInfo;
		}

		// Token: 0x0600ADD5 RID: 44501 RVA: 0x0025E870 File Offset: 0x0025CC70
		private void _OnSceneNewSignInQueryRet(MsgDATA msg)
		{
			SceneNewSignInQueryRet sceneNewSignInQueryRet = new SceneNewSignInQueryRet();
			sceneNewSignInQueryRet.decode(msg.bytes);
			if (this.monthlySignInCountInfo != null)
			{
				this.monthlySignInCountInfo.noFree = sceneNewSignInQueryRet.noFree;
				this.monthlySignInCountInfo.free = sceneNewSignInQueryRet.free;
				this.monthlySignInCountInfo.activite = sceneNewSignInQueryRet.activite;
				this.monthlySignInCountInfo.accumulatedActivite = sceneNewSignInQueryRet.activiteCount;
			}
			if (this.monthlySignInItemDatas != null)
			{
				this.monthlySignInItemDatas.Clear();
				DateTime dateTime = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
				if (dateTime.Hour < 6)
				{
					dateTime = dateTime.AddDays(-1.0);
				}
				int monthDayNum = ActivityDataManager.GetMonthDayNum(dateTime.Year, dateTime.Month);
				BitArray bitArray = new BitArray(BitConverter.GetBytes(sceneNewSignInQueryRet.signFlag));
				int num = 0;
				while (num < bitArray.Length && num < monthDayNum)
				{
					ActivityDataManager.MonthlySignInItemData monthlySignInItemData = new ActivityDataManager.MonthlySignInItemData();
					if (monthlySignInItemData != null)
					{
						monthlySignInItemData.day = num + 1;
						monthlySignInItemData.signIned = bitArray.Get(num + 1);
						monthlySignInItemData.awardItemData = this.GetAwardItemData(dateTime.Month, monthlySignInItemData.day);
					}
					this.monthlySignInItemDatas.Add(monthlySignInItemData);
					num++;
				}
			}
			if (this.accumulativeSignInItemDatas != null)
			{
				this.accumulativeSignInItemDatas.Clear();
				DateTime dateTime2 = Function.ConvertIntDateTime(DataManager<TimeManager>.GetInstance().GetServerDoubleTime());
				int monthDayNum2 = ActivityDataManager.GetMonthDayNum(dateTime2.Year, dateTime2.Month);
				BitArray bitArray2 = new BitArray(BitConverter.GetBytes(sceneNewSignInQueryRet.collectFlag));
				Dictionary<int, MonthSignCollectAward> dictionary = this.monthSignCollectAwards;
				if (dictionary != null)
				{
					foreach (KeyValuePair<int, MonthSignCollectAward> keyValuePair in dictionary)
					{
						MonthSignCollectAward value = keyValuePair.Value;
						if (value != null)
						{
							ActivityDataManager.AccumulativeSignInItemData accumulativeSignInItemData = new ActivityDataManager.AccumulativeSignInItemData();
							if (accumulativeSignInItemData != null)
							{
								accumulativeSignInItemData.accumulativeDay = value.ID;
								accumulativeSignInItemData.hasGotAward = bitArray2.Get(value.ID);
								accumulativeSignInItemData.awardItemData = new AwardItemData();
								if (accumulativeSignInItemData.awardItemData != null)
								{
									accumulativeSignInItemData.awardItemData.ID = value.ItemID;
									accumulativeSignInItemData.awardItemData.Num = value.ItemNum;
								}
							}
							this.accumulativeSignInItemDatas.Add(accumulativeSignInItemData);
						}
					}
				}
			}
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<SignFrame>(null, false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateMonthlySignInCountInfo, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateMonthlySignInItemInfo, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateAccumulativeSignInItemInfo, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnMonthlySignInRedPointReset, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.WelfActivityRedPoint, null, null, null, null);
		}

		// Token: 0x0600ADD6 RID: 44502 RVA: 0x0025EB38 File Offset: 0x0025CF38
		private void _OnSceneNewSignRet(MsgDATA msg)
		{
			SceneNewSignRet sceneNewSignRet = new SceneNewSignRet();
			sceneNewSignRet.decode(msg.bytes);
			if (sceneNewSignRet.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneNewSignRet.errorCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600ADD7 RID: 44503 RVA: 0x0025EB74 File Offset: 0x0025CF74
		private void _OnSceneNewSignInCollectRet(MsgDATA msg)
		{
			SceneNewSignInCollectRet sceneNewSignInCollectRet = new SceneNewSignInCollectRet();
			sceneNewSignInCollectRet.decode(msg.bytes);
			if (sceneNewSignInCollectRet.errorCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneNewSignInCollectRet.errorCode, string.Empty);
				return;
			}
		}

		// Token: 0x0600ADD8 RID: 44504 RVA: 0x0025EBB0 File Offset: 0x0025CFB0
		public void SendMonthlySignInQuery()
		{
			SceneNewSignInQuery cmd = new SceneNewSignInQuery();
			NetManager.Instance().SendCommand<SceneNewSignInQuery>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600ADD9 RID: 44505 RVA: 0x0025EBD0 File Offset: 0x0025CFD0
		public void SendMonthlySignIn(int day, bool isAll = false)
		{
			SceneNewSignIn sceneNewSignIn = new SceneNewSignIn();
			sceneNewSignIn.day = (byte)day;
			sceneNewSignIn.isAll = ((!isAll) ? 0 : 1);
			NetManager.Instance().SendCommand<SceneNewSignIn>(ServerType.GATE_SERVER, sceneNewSignIn);
		}

		// Token: 0x0600ADDA RID: 44506 RVA: 0x0025EC0C File Offset: 0x0025D00C
		public void SendGetAccumulativeSignInAward(int day)
		{
			SceneNewSignInCollect sceneNewSignInCollect = new SceneNewSignInCollect();
			sceneNewSignInCollect.day = (byte)day;
			NetManager.Instance().SendCommand<SceneNewSignInCollect>(ServerType.GATE_SERVER, sceneNewSignInCollect);
		}

		// Token: 0x0600ADDB RID: 44507 RVA: 0x0025EC34 File Offset: 0x0025D034
		public void RequestChallengeScore()
		{
			SceneChallengeScoreReq cmd = new SceneChallengeScoreReq();
			NetManager.Instance().SendCommand<SceneChallengeScoreReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600ADDC RID: 44508 RVA: 0x0025EC54 File Offset: 0x0025D054
		private void _OnChallengeScoreRet(MsgDATA msg)
		{
			SceneChallengeScoreRet sceneChallengeScoreRet = new SceneChallengeScoreRet();
			sceneChallengeScoreRet.decode(msg.bytes);
			DataManager<PlayerBaseData>.GetInstance().ChanllengeScore = (int)sceneChallengeScoreRet.score;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnUpdateIntegrationChallengeScore, null, null, null, null);
		}

		// Token: 0x0600ADDD RID: 44509 RVA: 0x0025EC96 File Offset: 0x0025D096
		private void BindArborDayNetMessages()
		{
			NetProcess.AddMsgHandler(501095U, new Action<MsgDATA>(this.OnReceiveSceneActivePlantRes));
			NetProcess.AddMsgHandler(501097U, new Action<MsgDATA>(this.OnReceiveSceneActivePlantAppraRes));
		}

		// Token: 0x0600ADDE RID: 44510 RVA: 0x0025ECC4 File Offset: 0x0025D0C4
		private void UnBindArborDayNetMessages()
		{
			NetProcess.RemoveMsgHandler(501095U, new Action<MsgDATA>(this.OnReceiveSceneActivePlantRes));
			NetProcess.RemoveMsgHandler(501097U, new Action<MsgDATA>(this.OnReceiveSceneActivePlantAppraRes));
		}

		// Token: 0x0600ADDF RID: 44511 RVA: 0x0025ECF4 File Offset: 0x0025D0F4
		public void OnSendSceneActivePlantReq()
		{
			SceneActivePlantReq cmd = new SceneActivePlantReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneActivePlantReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600ADE0 RID: 44512 RVA: 0x0025ED24 File Offset: 0x0025D124
		private void OnReceiveSceneActivePlantRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneActivePlantRes sceneActivePlantRes = new SceneActivePlantRes();
			sceneActivePlantRes.decode(msgData.bytes);
			if (sceneActivePlantRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneActivePlantRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600ADE1 RID: 44513 RVA: 0x0025ED68 File Offset: 0x0025D168
		public void OnSendSceneActivePlantAppraReq()
		{
			SceneActivePlantAppraReq cmd = new SceneActivePlantAppraReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneActivePlantAppraReq>(ServerType.GATE_SERVER, cmd);
			}
		}

		// Token: 0x0600ADE2 RID: 44514 RVA: 0x0025ED98 File Offset: 0x0025D198
		private void OnReceiveSceneActivePlantAppraRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneActivePlantAppraRes sceneActivePlantAppraRes = new SceneActivePlantAppraRes();
			sceneActivePlantAppraRes.decode(msgData.bytes);
			if (sceneActivePlantAppraRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneActivePlantAppraRes.retCode, string.Empty);
			}
		}

		// Token: 0x0600ADE3 RID: 44515 RVA: 0x0025EDDC File Offset: 0x0025D1DC
		public static List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel> GetLimitTimeGroupBuyPrevieDataList(ActivityDataManager.LimitTimeGroupBuyPreviewType type)
		{
			List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel> result = new List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>();
			if (ActivityDataManager.mPreviewDict == null)
			{
				return result;
			}
			if (ActivityDataManager.mPreviewDict.TryGetValue(type, out result))
			{
			}
			return result;
		}

		// Token: 0x0600ADE4 RID: 44516 RVA: 0x0025EE10 File Offset: 0x0025D210
		private void InitLimiteBargainShowTable()
		{
			if (ActivityDataManager.mPreviewDict == null)
			{
				ActivityDataManager.mPreviewDict = new Dictionary<ActivityDataManager.LimitTimeGroupBuyPreviewType, List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>>();
			}
			ActivityDataManager.mPreviewDict.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<LimiteBargainShowTable>())
			{
				LimiteBargainShowTable limiteBargainShowTable = keyValuePair.Value as LimiteBargainShowTable;
				if (limiteBargainShowTable != null)
				{
					if (!ActivityDataManager.mPreviewDict.ContainsKey((ActivityDataManager.LimitTimeGroupBuyPreviewType)limiteBargainShowTable.ShowType))
					{
						ActivityDataManager.mPreviewDict.Add((ActivityDataManager.LimitTimeGroupBuyPreviewType)limiteBargainShowTable.ShowType, new List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>());
					}
					ActivityDataManager.LimitTimeGroupBuyPreviewDataModel limitTimeGroupBuyPreviewDataModel = new ActivityDataManager.LimitTimeGroupBuyPreviewDataModel();
					limitTimeGroupBuyPreviewDataModel.type = (ActivityDataManager.LimitTimeGroupBuyPreviewType)limiteBargainShowTable.ShowType;
					limitTimeGroupBuyPreviewDataModel.itemId = limiteBargainShowTable.ShowItem;
					limitTimeGroupBuyPreviewDataModel.goblinCoin = limiteBargainShowTable.GoblinCoins;
					limitTimeGroupBuyPreviewDataModel.price = limiteBargainShowTable.Price;
					ActivityDataManager.mPreviewDict[(ActivityDataManager.LimitTimeGroupBuyPreviewType)limiteBargainShowTable.ShowType].Add(limitTimeGroupBuyPreviewDataModel);
				}
			}
		}

		// Token: 0x0600ADE5 RID: 44517 RVA: 0x0025EEF4 File Offset: 0x0025D2F4
		private void InitWholeBargainDiscountTable()
		{
			if (ActivityDataManager.mDiscountDataList == null)
			{
				ActivityDataManager.mDiscountDataList = new List<ActivityDataManager.LimitTimeGroupBuyDiscountData>();
			}
			ActivityDataManager.mDiscountDataList.Clear();
			foreach (KeyValuePair<int, object> keyValuePair in Singleton<TableManager>.GetInstance().GetTable<WholeBargainDiscountTable>())
			{
				WholeBargainDiscountTable wholeBargainDiscountTable = keyValuePair.Value as WholeBargainDiscountTable;
				if (wholeBargainDiscountTable != null)
				{
					ActivityDataManager.LimitTimeGroupBuyDiscountData limitTimeGroupBuyDiscountData = new ActivityDataManager.LimitTimeGroupBuyDiscountData();
					limitTimeGroupBuyDiscountData.joinNum = wholeBargainDiscountTable.JoinNum;
					limitTimeGroupBuyDiscountData.discount = wholeBargainDiscountTable.Discount;
					ActivityDataManager.mDiscountDataList.Add(limitTimeGroupBuyDiscountData);
				}
			}
		}

		// Token: 0x0600ADE6 RID: 44518 RVA: 0x0025EF89 File Offset: 0x0025D389
		private void RegisterASWholeBargainNet()
		{
			NetProcess.AddMsgHandler(707408U, new Action<MsgDATA>(this.OnReceiveGASWholeBargainRes));
			NetProcess.AddMsgHandler(707406U, new Action<MsgDATA>(this.OnReceiveGASWholeBargainDiscountSync));
		}

		// Token: 0x0600ADE7 RID: 44519 RVA: 0x0025EFB7 File Offset: 0x0025D3B7
		private void UnRegisterASWholeBargainNet()
		{
			NetProcess.RemoveMsgHandler(707408U, new Action<MsgDATA>(this.OnReceiveGASWholeBargainRes));
			NetProcess.RemoveMsgHandler(707406U, new Action<MsgDATA>(this.OnReceiveGASWholeBargainDiscountSync));
		}

		// Token: 0x0600ADE8 RID: 44520 RVA: 0x0025EFE8 File Offset: 0x0025D3E8
		private void OnReceiveGASWholeBargainRes(MsgDATA msg)
		{
			GASWholeBargainRes gaswholeBargainRes = new GASWholeBargainRes();
			gaswholeBargainRes.decode(msg.bytes);
			LimitTimeGroupBuyDataModel limitTimeGroupBuyDataModel = new LimitTimeGroupBuyDataModel();
			limitTimeGroupBuyDataModel.joinNum = (int)gaswholeBargainRes.joinNum;
			limitTimeGroupBuyDataModel.maxNum = (int)gaswholeBargainRes.maxNum;
			limitTimeGroupBuyDataModel.playerJoinNum = (int)gaswholeBargainRes.playerJoinNum;
			limitTimeGroupBuyDataModel.discount = (int)gaswholeBargainRes.discount;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnGASWholeBargainResSuccessed, limitTimeGroupBuyDataModel, null, null, null);
		}

		// Token: 0x0600ADE9 RID: 44521 RVA: 0x0025F050 File Offset: 0x0025D450
		private void OnReceiveGASWholeBargainDiscountSync(MsgDATA msg)
		{
			GASWholeBargainDiscountSync gaswholeBargainDiscountSync = new GASWholeBargainDiscountSync();
			gaswholeBargainDiscountSync.decode(msg.bytes);
			ActivityDataManager.LimitTimeGroupBuyDiscount = ((gaswholeBargainDiscountSync.discount != 0U) ? gaswholeBargainDiscountSync.discount : 100U);
		}

		// Token: 0x0600ADEA RID: 44522 RVA: 0x0025F08C File Offset: 0x0025D48C
		public void OnSendGASWholeBargainReq()
		{
			GASWholeBargainReq cmd = new GASWholeBargainReq();
			NetManager.Instance().SendCommand<GASWholeBargainReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600ADEB RID: 44523 RVA: 0x0025F0AC File Offset: 0x0025D4AC
		public bool CheckGroupPurchaseActivityIsOpen()
		{
			foreach (OpActivityData opActivityData in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData.tmpType == 50002U)
				{
					if (opActivityData.state == 1)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600ADEC RID: 44524 RVA: 0x0025F138 File Offset: 0x0025D538
		public bool CheckChampionshipActivityIsOpen()
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_CHAMPIOSHIPGIFTBAGACTIVITY);
			return activeDataFromType != null && activeDataFromType.state == 1;
		}

		// Token: 0x0600ADED RID: 44525 RVA: 0x0025F16C File Offset: 0x0025D56C
		public bool ChampionshipActivityIsShowRedPoint()
		{
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_CHAMPIOSHIPGIFTBAGACTIVITY);
			if (activeDataFromType != null)
			{
				for (int i = 0; i < activeDataFromType.tasks.Length; i++)
				{
					OpActTaskData opActTaskData = activeDataFromType.tasks[i];
					if (opActTaskData != null)
					{
						OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(opActTaskData.dataid);
						if (limitTimeTaskData != null)
						{
							if (limitTimeTaskData.state == 2)
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600ADEE RID: 44526 RVA: 0x0025F1E8 File Offset: 0x0025D5E8
		private void _OnWorldGetSysRecordRes(MsgDATA msg)
		{
			WorldGetSysRecordRes worldGetSysRecordRes = new WorldGetSysRecordRes();
			worldGetSysRecordRes.decode(msg.bytes);
			uint param = worldGetSysRecordRes.param;
			uint value = worldGetSysRecordRes.value;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnPullRecordsSuccessed, param, value, null, null);
		}

		// Token: 0x0600ADEF RID: 44527 RVA: 0x0025F234 File Offset: 0x0025D634
		public void OnSendWorldGetSysRecordReq(uint behavoir, uint roleid, uint itemId)
		{
			WorldGetSysRecordReq worldGetSysRecordReq = new WorldGetSysRecordReq();
			worldGetSysRecordReq.behavoir = behavoir;
			worldGetSysRecordReq.role = roleid;
			worldGetSysRecordReq.param = itemId;
			NetManager.Instance().SendCommand<WorldGetSysRecordReq>(ServerType.GATE_SERVER, worldGetSysRecordReq);
		}

		// Token: 0x0600ADF0 RID: 44528 RVA: 0x0025F26C File Offset: 0x0025D66C
		public void OnSendSceneSecretCoinReq()
		{
			SceneSecretCoinReq cmd = new SceneSecretCoinReq();
			NetManager.Instance().SendCommand<SceneSecretCoinReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600ADF1 RID: 44529 RVA: 0x0025F28C File Offset: 0x0025D68C
		private void _OnSceneSecretCoinRes(MsgDATA msg)
		{
			SceneSecretCoinRes sceneSecretCoinRes = new SceneSecretCoinRes();
			sceneSecretCoinRes.decode(msg.bytes);
			this.AnniversaryPoint = (int)sceneSecretCoinRes.coin;
		}

		// Token: 0x0600ADF2 RID: 44530 RVA: 0x0025F2B8 File Offset: 0x0025D6B8
		public bool CheckIsBuyAbyssBlackGoldMember()
		{
			foreach (OpActivityData opActivityData in this.mLimitTimeActivityDatas.Values)
			{
				if (opActivityData.tmpType == 600010U)
				{
					if (opActivityData.state == 1)
					{
						if (opActivityData.tasks != null)
						{
							if (opActivityData.tasks.Length > 0)
							{
								OpActTaskData opActTaskData = opActivityData.tasks[0];
								if (opActTaskData != null)
								{
									OpActTask limitTimeTaskData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeTaskData(opActTaskData.dataid);
									if (limitTimeTaskData != null)
									{
										if (limitTimeTaskData.state == 2)
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

		// Token: 0x04006116 RID: 24854
		private readonly Dictionary<uint, OpActivityData> mLimitTimeActivityDatas = new Dictionary<uint, OpActivityData>();

		// Token: 0x04006117 RID: 24855
		private readonly Dictionary<uint, OpActTask> mLimitTimeTaskDatas = new Dictionary<uint, OpActTask>();

		// Token: 0x04006118 RID: 24856
		private readonly Dictionary<uint, ActivityInfo> mBossActivityDatas = new Dictionary<uint, ActivityInfo>();

		// Token: 0x04006119 RID: 24857
		private readonly Dictionary<uint, SceneNotifyActiveTaskVar> mBossTaskDatas = new Dictionary<uint, SceneNotifyActiveTaskVar>();

		// Token: 0x0400611A RID: 24858
		private readonly Dictionary<uint, SceneNotifyActiveTaskStatus> mBossTaskStatusDatas = new Dictionary<uint, SceneNotifyActiveTaskStatus>();

		// Token: 0x0400611B RID: 24859
		private readonly Dictionary<uint, WorldActivityMonsterRes> mBossKillMonsterDatas = new Dictionary<uint, WorldActivityMonsterRes>();

		// Token: 0x0400611C RID: 24860
		private readonly Dictionary<int, Dictionary<uint, MallItemInfo>> mGiftPackDatas = new Dictionary<int, Dictionary<uint, MallItemInfo>>();

		// Token: 0x0400611D RID: 24861
		private readonly Dictionary<int, ActivityTabInfo> mActivityTabTables = new Dictionary<int, ActivityTabInfo>();

		// Token: 0x0400611E RID: 24862
		private readonly Dictionary<uint, AcivtityCounterRes> mLimitTimeActivityCounterResDic = new Dictionary<uint, AcivtityCounterRes>();

		// Token: 0x0400611F RID: 24863
		private readonly Dictionary<uint, AcivtityCounterRes> mBossActivityCounterResDic = new Dictionary<uint, AcivtityCounterRes>();

		// Token: 0x04006120 RID: 24864
		private readonly Dictionary<uint, AcivtityCounterRes> mDungeonCounterResDic = new Dictionary<uint, AcivtityCounterRes>();

		// Token: 0x04006121 RID: 24865
		private int anniversaryPoint;

		// Token: 0x04006122 RID: 24866
		public static uint LimitTimeGroupBuyDiscount = 100U;

		// Token: 0x04006123 RID: 24867
		public static List<UltimateChallengeCustomsClearanceRewardItemData> ultimateChallengeCustomsClearanceRewardItemDatas = new List<UltimateChallengeCustomsClearanceRewardItemData>();

		// Token: 0x04006126 RID: 24870
		private List<ActivityDataManager.MonthlySignInItemData> monthlySignInItemDatas = new List<ActivityDataManager.MonthlySignInItemData>();

		// Token: 0x04006127 RID: 24871
		private List<ActivityDataManager.AccumulativeSignInItemData> accumulativeSignInItemDatas = new List<ActivityDataManager.AccumulativeSignInItemData>();

		// Token: 0x04006128 RID: 24872
		private ActivityDataManager.MonthlySignInCountInfo monthlySignInCountInfo = new ActivityDataManager.MonthlySignInCountInfo();

		// Token: 0x04006129 RID: 24873
		public const int MONTH_SIGN_IN_CONFIG_ID = 9380;

		// Token: 0x0400612A RID: 24874
		private Dictionary<int, Dictionary<int, MonthSignAward>> monthSignInAwards = new Dictionary<int, Dictionary<int, MonthSignAward>>();

		// Token: 0x0400612B RID: 24875
		private Dictionary<int, MonthSignCollectAward> monthSignCollectAwards = new Dictionary<int, MonthSignCollectAward>();

		// Token: 0x0400612C RID: 24876
		public static Dictionary<ActivityDataManager.LimitTimeGroupBuyPreviewType, List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>> mPreviewDict = new Dictionary<ActivityDataManager.LimitTimeGroupBuyPreviewType, List<ActivityDataManager.LimitTimeGroupBuyPreviewDataModel>>();

		// Token: 0x0400612D RID: 24877
		public static List<ActivityDataManager.LimitTimeGroupBuyDiscountData> mDiscountDataList = new List<ActivityDataManager.LimitTimeGroupBuyDiscountData>();

		// Token: 0x020011AA RID: 4522
		public class UltimateChallengeFloorData
		{
			// Token: 0x0400612E RID: 24878
			public int floor;

			// Token: 0x0400612F RID: 24879
			public int tableID;
		}

		// Token: 0x020011AB RID: 4523
		public class MonthlySignInItemData
		{
			// Token: 0x04006130 RID: 24880
			public AwardItemData awardItemData = new AwardItemData();

			// Token: 0x04006131 RID: 24881
			public bool signIned;

			// Token: 0x04006132 RID: 24882
			public int day = 1;
		}

		// Token: 0x020011AC RID: 4524
		public class AccumulativeSignInItemData
		{
			// Token: 0x04006133 RID: 24883
			public AwardItemData awardItemData = new AwardItemData();

			// Token: 0x04006134 RID: 24884
			public bool hasGotAward;

			// Token: 0x04006135 RID: 24885
			public int accumulativeDay = 3;
		}

		// Token: 0x020011AD RID: 4525
		public class MonthlySignInCountInfo
		{
			// Token: 0x04006136 RID: 24886
			public byte noFree;

			// Token: 0x04006137 RID: 24887
			public byte free;

			// Token: 0x04006138 RID: 24888
			public byte activite;

			// Token: 0x04006139 RID: 24889
			public byte accumulatedActivite;
		}

		// Token: 0x020011AE RID: 4526
		public enum LimitTimeGroupBuyPreviewType
		{
			// Token: 0x0400613B RID: 24891
			None,
			// Token: 0x0400613C RID: 24892
			MayDay,
			// Token: 0x0400613D RID: 24893
			GoblinChamber,
			// Token: 0x0400613E RID: 24894
			GoblinChamberNew
		}

		// Token: 0x020011AF RID: 4527
		public class LimitTimeGroupBuyDiscountData
		{
			// Token: 0x0400613F RID: 24895
			public int joinNum;

			// Token: 0x04006140 RID: 24896
			public int discount;
		}

		// Token: 0x020011B0 RID: 4528
		public class LimitTimeGroupBuyPreviewDataModel
		{
			// Token: 0x04006141 RID: 24897
			public ActivityDataManager.LimitTimeGroupBuyPreviewType type;

			// Token: 0x04006142 RID: 24898
			public int itemId;

			// Token: 0x04006143 RID: 24899
			public int goblinCoin;

			// Token: 0x04006144 RID: 24900
			public int price;
		}
	}
}
