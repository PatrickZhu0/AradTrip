using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001279 RID: 4729
	public class HonorSystemDataManager : DataManager<HonorSystemDataManager>
	{
		// Token: 0x0600B5EF RID: 46575 RVA: 0x00290435 File Offset: 0x0028E835
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600B5F0 RID: 46576 RVA: 0x0029043D File Offset: 0x0028E83D
		public override void Clear()
		{
			this.UnBindNetEvents();
			this.ClearData();
		}

		// Token: 0x0600B5F1 RID: 46577 RVA: 0x0029044B File Offset: 0x0028E84B
		private void ClearData()
		{
			this.ResetPlayerHistoryHonorInfo();
			this.HonorSystemInfoReqTimes = 0UL;
			this.LastHonorSystemInfo = null;
			this.IsShowRedPointFlag = false;
			this.FinishTimeStamp = 0U;
			this.IsAlreadyUseProtectCard = false;
			this.ChiJiHonorExpMaxValue = 0;
			this.PkHonorExpMaxValue = 0;
		}

		// Token: 0x0600B5F2 RID: 46578 RVA: 0x00290488 File Offset: 0x0028E888
		private void ResetPlayerHistoryHonorInfo()
		{
			this.PlayerHonorExp = 0U;
			this.PlayerHonorLevel = 0U;
			this.PlayerLastWeekRank = 0U;
			this.PlayerHistoryRank = 0U;
			this.PlayerHighestHonorLevel = 0U;
			if (this.PlayerHistoryHonorInfoList != null && this.PlayerHistoryHonorInfoList.Count > 0)
			{
				for (int i = 0; i < this.PlayerHistoryHonorInfoList.Count; i++)
				{
					PlayerHistoryHonorInfo playerHistoryHonorInfo = this.PlayerHistoryHonorInfoList[i];
					if (playerHistoryHonorInfo != null && playerHistoryHonorInfo.PvpNumberStatisticsList != null)
					{
						playerHistoryHonorInfo.PvpNumberStatisticsList.Clear();
					}
				}
				this.PlayerHistoryHonorInfoList.Clear();
			}
			this.HonorPlayerDictionary.Clear();
		}

		// Token: 0x0600B5F3 RID: 46579 RVA: 0x0029052F File Offset: 0x0028E92F
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(509902U, new Action<MsgDATA>(this.OnReceiveSceneHonorRes));
			NetProcess.AddMsgHandler(509903U, new Action<MsgDATA>(this.OnReceiveSceneHonorRedPoint));
		}

		// Token: 0x0600B5F4 RID: 46580 RVA: 0x0029055D File Offset: 0x0028E95D
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(509902U, new Action<MsgDATA>(this.OnReceiveSceneHonorRes));
			NetProcess.RemoveMsgHandler(509903U, new Action<MsgDATA>(this.OnReceiveSceneHonorRedPoint));
		}

		// Token: 0x0600B5F5 RID: 46581 RVA: 0x0029058C File Offset: 0x0028E98C
		public void OnSendSceneHonorReq()
		{
			SceneHonorReq cmd = new SceneHonorReq();
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneHonorReq>(ServerType.GATE_SERVER, cmd);
			}
			this.HonorSystemInfoReqTimes += 1UL;
		}

		// Token: 0x0600B5F6 RID: 46582 RVA: 0x002905CC File Offset: 0x0028E9CC
		private void OnReceiveSceneHonorRes(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			this.ResetPlayerHistoryHonorInfo();
			SceneHonorRes sceneHonorRes = new SceneHonorRes();
			sceneHonorRes.decode(msgData.bytes);
			this.PlayerHonorLevel = sceneHonorRes.honorLvl;
			this.PlayerHonorExp = sceneHonorRes.honorExp;
			this.PlayerLastWeekRank = sceneHonorRes.lastWeekRank;
			this.PlayerHistoryRank = sceneHonorRes.historyRank;
			this.PlayerHighestHonorLevel = sceneHonorRes.highestHonorLvl;
			this.FinishTimeStamp = sceneHonorRes.rankTime;
			this.IsAlreadyUseProtectCard = (sceneHonorRes.isUseCard == 1U);
			if (this.HonorSystemInfoReqTimes == 0UL)
			{
				this.LastHonorSystemInfo = sceneHonorRes.historyHonorInfoList;
				return;
			}
			int todayTimeInWeekDay = TimeUtility.GetTodayTimeInWeekDay();
			int yesterdayTimeInWeekDay = TimeUtility.GetYesterdayTimeInWeekDay();
			PlayerHistoryHonorInfo playerHistoryHonorInfo = HonorSystemUtility.CreatePlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE.HONOR_DATE_TYPE_TODAY);
			PlayerHistoryHonorInfo playerHistoryHonorInfo2 = HonorSystemUtility.CreatePlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE.HONOR_DATE_TYPE_YESTERDAY);
			PlayerHistoryHonorInfo playerHistoryHonorInfo3 = HonorSystemUtility.CreatePlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE.HONOR_DATE_TYPE_TOTAL);
			PlayerHistoryHonorInfo playerHistoryHonorInfo4 = HonorSystemUtility.CreatePlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE.HONOR_DATE_TYPE_THIS_WEEK);
			PlayerHistoryHonorInfo playerHistoryHonorInfo5 = HonorSystemUtility.CreatePlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE.HONOR_DATE_TYPE_LAST_WEEK);
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<HonorPlayerTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					HonorPlayerTable honorPlayerTable = keyValuePair.Value as HonorPlayerTable;
					if (honorPlayerTable != null)
					{
						if (honorPlayerTable.Sort != 0)
						{
							if (HonorSystemUtility.IsPvpShowInWeekDay(todayTimeInWeekDay, honorPlayerTable))
							{
								HonorSystemUtility.AddPvpNumberStatisticsInPlayerHistoryHonorInfo(playerHistoryHonorInfo, honorPlayerTable);
							}
							if (HonorSystemUtility.IsPvpShowInWeekDay(yesterdayTimeInWeekDay, honorPlayerTable))
							{
								HonorSystemUtility.AddPvpNumberStatisticsInPlayerHistoryHonorInfo(playerHistoryHonorInfo2, honorPlayerTable);
							}
							HonorSystemUtility.AddPvpNumberStatisticsInPlayerHistoryHonorInfo(playerHistoryHonorInfo3, honorPlayerTable);
							HonorSystemUtility.AddPvpNumberStatisticsInPlayerHistoryHonorInfo(playerHistoryHonorInfo4, honorPlayerTable);
							HonorSystemUtility.AddPvpNumberStatisticsInPlayerHistoryHonorInfo(playerHistoryHonorInfo5, honorPlayerTable);
						}
					}
				}
			}
			if (sceneHonorRes.historyHonorInfoList != null && sceneHonorRes.historyHonorInfoList.Length > 0)
			{
				for (int i = 0; i < sceneHonorRes.historyHonorInfoList.Length; i++)
				{
					HistoryHonorInfo historyHonorInfo = sceneHonorRes.historyHonorInfoList[i];
					if (historyHonorInfo != null)
					{
						switch (historyHonorInfo.dateType)
						{
						case 1U:
							HonorSystemUtility.UpdatePlayerHistoryInfo(playerHistoryHonorInfo3, historyHonorInfo);
							break;
						case 2U:
							HonorSystemUtility.UpdatePlayerHistoryInfo(playerHistoryHonorInfo, historyHonorInfo);
							break;
						case 3U:
							HonorSystemUtility.UpdatePlayerHistoryInfo(playerHistoryHonorInfo2, historyHonorInfo);
							break;
						case 4U:
							HonorSystemUtility.UpdatePlayerHistoryInfo(playerHistoryHonorInfo4, historyHonorInfo);
							break;
						case 5U:
							HonorSystemUtility.UpdatePlayerHistoryInfo(playerHistoryHonorInfo5, historyHonorInfo);
							break;
						}
					}
				}
			}
			HistoryHonorInfo historyHonorInfo2 = null;
			if (this.LastHonorSystemInfo != null && this.LastHonorSystemInfo.Length > 0)
			{
				for (int j = 0; j < this.LastHonorSystemInfo.Length; j++)
				{
					HistoryHonorInfo historyHonorInfo3 = this.LastHonorSystemInfo[j];
					if (historyHonorInfo3 != null)
					{
						if (historyHonorInfo3.dateType == 1U)
						{
							historyHonorInfo2 = historyHonorInfo3;
							break;
						}
					}
				}
			}
			HonorSystemUtility.UpdatePlayerNewFlagInHistoryInfo(playerHistoryHonorInfo3, historyHonorInfo2);
			if (this.PlayerHistoryHonorInfoList == null)
			{
				this.PlayerHistoryHonorInfoList = new List<PlayerHistoryHonorInfo>();
			}
			this.PlayerHistoryHonorInfoList.Clear();
			this.PlayerHistoryHonorInfoList.Add(playerHistoryHonorInfo);
			this.PlayerHistoryHonorInfoList.Add(playerHistoryHonorInfo2);
			this.PlayerHistoryHonorInfoList.Add(playerHistoryHonorInfo3);
			this.PlayerHistoryHonorInfoList.Add(playerHistoryHonorInfo4);
			this.PlayerHistoryHonorInfoList.Add(playerHistoryHonorInfo5);
			for (int k = 0; k < this.PlayerHistoryHonorInfoList.Count; k++)
			{
				PlayerHistoryHonorInfo playerHistoryHonorInfo6 = this.PlayerHistoryHonorInfoList[k];
				if (playerHistoryHonorInfo6 != null)
				{
					if (playerHistoryHonorInfo6.PvpNumberStatisticsList != null && playerHistoryHonorInfo6.PvpNumberStatisticsList.Count > 1)
					{
						playerHistoryHonorInfo6.PvpNumberStatisticsList.Sort((PvpNumberStatistics x, PvpNumberStatistics y) => x.PvpSort.CompareTo(y.PvpSort));
					}
				}
			}
			this.LastHonorSystemInfo = sceneHonorRes.historyHonorInfoList;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveHonorSystemResMessage, null, null, null, null);
		}

		// Token: 0x0600B5F7 RID: 46583 RVA: 0x00290988 File Offset: 0x0028ED88
		private void OnReceiveSceneHonorRedPoint(MsgDATA msgData)
		{
			if (msgData == null)
			{
				return;
			}
			SceneHonorRedPoint stream = new SceneHonorRedPoint();
			stream.decode(msgData.bytes);
			this.IsShowRedPointFlag = true;
			HonorSystemUtility.SendHonorSystemRedPointUpdateMessage();
		}

		// Token: 0x0600B5F8 RID: 46584 RVA: 0x002909BC File Offset: 0x0028EDBC
		public HonorPlayerTable GetHonorPlayerTable(int honorPvpType)
		{
			if (!this.HonorPlayerDictionary.ContainsKey(honorPvpType))
			{
				HonorPlayerTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<HonorPlayerTable>(honorPvpType, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.HonorPlayerDictionary[honorPvpType] = tableItem;
				}
			}
			HonorPlayerTable result = null;
			this.HonorPlayerDictionary.TryGetValue(honorPvpType, out result);
			return result;
		}

		// Token: 0x040066D4 RID: 26324
		public const int HonorSystemUnLockLevel = 30;

		// Token: 0x040066D5 RID: 26325
		public const int DefaultHonorSystemLevel = 1000;

		// Token: 0x040066D6 RID: 26326
		public const int NormalHonorProtectCardId = 330000252;

		// Token: 0x040066D7 RID: 26327
		public const int HighHonorProtectCardId = 330000253;

		// Token: 0x040066D8 RID: 26328
		public const EPackageType ProtectCardItemPackageType = EPackageType.Material;

		// Token: 0x040066D9 RID: 26329
		public uint PlayerHonorLevel;

		// Token: 0x040066DA RID: 26330
		public uint PlayerHonorExp;

		// Token: 0x040066DB RID: 26331
		public uint PlayerLastWeekRank;

		// Token: 0x040066DC RID: 26332
		public uint PlayerHistoryRank;

		// Token: 0x040066DD RID: 26333
		public uint PlayerHighestHonorLevel;

		// Token: 0x040066DE RID: 26334
		public uint FinishTimeStamp;

		// Token: 0x040066DF RID: 26335
		public bool IsAlreadyUseProtectCard;

		// Token: 0x040066E0 RID: 26336
		public List<PlayerHistoryHonorInfo> PlayerHistoryHonorInfoList = new List<PlayerHistoryHonorInfo>();

		// Token: 0x040066E1 RID: 26337
		public Dictionary<int, HonorPlayerTable> HonorPlayerDictionary = new Dictionary<int, HonorPlayerTable>();

		// Token: 0x040066E2 RID: 26338
		public int HonorHistoryActivityNumber = 4;

		// Token: 0x040066E3 RID: 26339
		public ulong HonorSystemInfoReqTimes;

		// Token: 0x040066E4 RID: 26340
		public HistoryHonorInfo[] LastHonorSystemInfo;

		// Token: 0x040066E5 RID: 26341
		public bool IsShowRedPointFlag;

		// Token: 0x040066E6 RID: 26342
		public int PkHonorExpMaxValue;

		// Token: 0x040066E7 RID: 26343
		public string PkHonorExpCounterStr = "pk_season_1v1_honor";

		// Token: 0x040066E8 RID: 26344
		public int ChiJiHonorExpMaxValue;

		// Token: 0x040066E9 RID: 26345
		public string ChiJiHonorExpCounterStr = "chi_ji_honor";
	}
}
