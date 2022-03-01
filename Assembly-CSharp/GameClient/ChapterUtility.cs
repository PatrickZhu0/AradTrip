using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using ActivityLimitTime;
using Battle;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200153D RID: 5437
	public class ChapterUtility
	{
		// Token: 0x0600D434 RID: 54324 RVA: 0x0034E64C File Offset: 0x0034CA4C
		public static BattleType GetBattleType(int id)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				switch (tableItem.SubType)
				{
				case DungeonTable.eSubType.S_NORMAL:
				case DungeonTable.eSubType.S_TEAM_BOSS:
					return BattleType.Dungeon;
				case DungeonTable.eSubType.S_YUANGU:
					return BattleType.YuanGu;
				case DungeonTable.eSubType.S_NIUTOUGUAI:
					return BattleType.Mou;
				case DungeonTable.eSubType.S_NANBUXIGU:
					return BattleType.North;
				case DungeonTable.eSubType.S_SIWANGZHITA:
					return BattleType.DeadTown;
				case DungeonTable.eSubType.S_NEWBIEGUIDE:
					return BattleType.NewbieGuide;
				case DungeonTable.eSubType.S_PK:
					return BattleType.MutiPlayer;
				case DungeonTable.eSubType.S_JINBI:
					return BattleType.GoldRush;
				case DungeonTable.eSubType.S_HELL:
					return BattleType.Hell;
				case DungeonTable.eSubType.S_GUILDPK:
					return BattleType.GuildPVP;
				case DungeonTable.eSubType.S_MONEYREWARDS_PVP:
					return BattleType.MoneyRewardsPVP;
				case DungeonTable.eSubType.S_WUDAOHUI:
					return BattleType.ChampionMatch;
				case DungeonTable.eSubType.S_COMBOTRAINING:
					return BattleType.TrainingSkillCombo;
				case DungeonTable.eSubType.S_GUILD_DUNGEON:
					return BattleType.GuildPVE;
				case DungeonTable.eSubType.S_FINALTEST_PVE:
					return BattleType.FinalTestBattle;
				case DungeonTable.eSubType.S_RAID_DUNGEON:
					return BattleType.RaidPVE;
				case DungeonTable.eSubType.S_TREASUREMAP:
					return BattleType.TreasureMap;
				case DungeonTable.eSubType.S_PLAYGAME:
					return BattleType.AnniversaryPVE_III;
				}
			}
			return BattleType.Dungeon;
		}

		// Token: 0x0600D435 RID: 54325 RVA: 0x0034E73C File Offset: 0x0034CB3C
		public static IList<int> PreconditionIDList(int dungeonID)
		{
			ChapterUtility.mDungeonID.dungeonID = dungeonID;
			int dungeonIDWithOutDiff = ChapterUtility.mDungeonID.dungeonIDWithOutDiff;
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonIDWithOutDiff, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.storyDungeonIDs;
			}
			Logger.LogError("Dungeon Table : no item with " + dungeonIDWithOutDiff);
			return new List<int>();
		}

		// Token: 0x0600D436 RID: 54326 RVA: 0x0034E79C File Offset: 0x0034CB9C
		public static bool GetDungeonMissionState(int dungeonID)
		{
			MissionManager.SingleMissionInfo missionInfoByDungeonID = DataManager<MissionManager>.GetInstance().GetMissionInfoByDungeonID(dungeonID);
			if (missionInfoByDungeonID != null)
			{
				TaskStatus status = (TaskStatus)missionInfoByDungeonID.status;
				if (status == TaskStatus.TASK_UNFINISH)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D437 RID: 54327 RVA: 0x0034E7D1 File Offset: 0x0034CBD1
		public static bool HasMissionByDungeonID(int dungeonID)
		{
			return ChapterUtility.GetMissionDungeonDiff(dungeonID) >= 0;
		}

		// Token: 0x0600D438 RID: 54328 RVA: 0x0034E7E0 File Offset: 0x0034CBE0
		public static int GetMissionDungeonDiff(int dungeonID)
		{
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			int dungeonTopHard = ChapterUtility.GetDungeonTopHard(dungeonID);
			for (int i = 0; i <= dungeonTopHard; i++)
			{
				dungeonID2.diffID = i;
				if (ChapterUtility.GetDungeonMissionState(dungeonID2.dungeonID))
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600D439 RID: 54329 RVA: 0x0034E828 File Offset: 0x0034CC28
		public static uint GetMissionIDByDungeonID(int dungoenID)
		{
			MissionManager.SingleMissionInfo missionInfoByDungeonID = DataManager<MissionManager>.GetInstance().GetMissionInfoByDungeonID(dungoenID);
			if (missionInfoByDungeonID != null)
			{
				return missionInfoByDungeonID.taskID;
			}
			return 0U;
		}

		// Token: 0x0600D43A RID: 54330 RVA: 0x0034E850 File Offset: 0x0034CC50
		public static string GetDungeonMissionInfo(int dungeonID)
		{
			MissionManager.SingleMissionInfo missionInfoByDungeonID = DataManager<MissionManager>.GetInstance().GetMissionInfoByDungeonID(dungeonID);
			return DataManager<MissionManager>.GetInstance().GetMissionName(missionInfoByDungeonID.taskID) + DataManager<MissionManager>.GetInstance().GetMissionNameAppendBystatus((int)missionInfoByDungeonID.status, missionInfoByDungeonID.missionItem.ID);
		}

		// Token: 0x0600D43B RID: 54331 RVA: 0x0034E89C File Offset: 0x0034CC9C
		public static int GetReadyDungeonID(int dungeonID, int hard = 0)
		{
			ChapterUtility.mDungeonID.dungeonID = dungeonID;
			int diffID = ChapterUtility.mDungeonID.diffID;
			int dungeonIDWithOutDiff = ChapterUtility.mDungeonID.dungeonIDWithOutDiff;
			int num = ChapterUtility.GetDungeonID2Enter(dungeonIDWithOutDiff);
			if (num < 0)
			{
				return -1;
			}
			if (num == dungeonIDWithOutDiff)
			{
				ChapterUtility.mDungeonID.dungeonID = dungeonID;
				ChapterUtility.mDungeonID.diffID = diffID;
				num = ChapterUtility.mDungeonID.dungeonID;
			}
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return num;
			}
			return -1;
		}

		// Token: 0x0600D43C RID: 54332 RVA: 0x0034E924 File Offset: 0x0034CD24
		public static int GetDungeonRealTopHard(int dungeonID)
		{
			ChapterUtility.mDungeonID.dungeonID = dungeonID;
			List<DungeonHardInfo> allHardInfo = DataManager<BattleDataManager>.GetInstance().ChapterInfo.allHardInfo;
			DungeonHardInfo dungeonHardInfo = allHardInfo.Find((DungeonHardInfo x) => x.id == ChapterUtility.mDungeonID.dungeonIDWithOutDiff);
			if (dungeonHardInfo != null)
			{
				return dungeonHardInfo.unlockedHardType;
			}
			return -1;
		}

		// Token: 0x0600D43D RID: 54333 RVA: 0x0034E980 File Offset: 0x0034CD80
		public static int GetDungeonTopHard(int dungeonID)
		{
			ChapterUtility.mDungeonID.dungeonID = dungeonID;
			for (int i = 3; i >= 0; i--)
			{
				ChapterUtility.mDungeonID.diffID = i;
				DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(ChapterUtility.mDungeonID.dungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x0600D43E RID: 54334 RVA: 0x0034E9E0 File Offset: 0x0034CDE0
		public static bool CanDungeonOpenAutoFight(int dungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			return tableItem != null && tableItem.OpenAutoFight > 0;
		}

		// Token: 0x0600D43F RID: 54335 RVA: 0x0034EA14 File Offset: 0x0034CE14
		public static string GetHardString(int diff)
		{
			diff %= 4;
			if (diff == 0)
			{
				return "普通";
			}
			if (diff == 1)
			{
				return "冒险";
			}
			if (diff == 2)
			{
				return "勇士";
			}
			if (diff == 3)
			{
				return "王者";
			}
			return string.Empty;
		}

		// Token: 0x0600D440 RID: 54336 RVA: 0x0034EA53 File Offset: 0x0034CE53
		public static string GetHardColorString(int diff)
		{
			diff %= 4;
			if (diff == 0)
			{
				return "#ffffff";
			}
			if (diff == 1)
			{
				return "#00bfff";
			}
			if (diff == 2)
			{
				return "#bf00ff";
			}
			if (diff == 3)
			{
				return "#ff00bf";
			}
			return "#ffffff";
		}

		// Token: 0x0600D441 RID: 54337 RVA: 0x0034EA94 File Offset: 0x0034CE94
		private static void _loadTeamDungeonIds()
		{
			if (ChapterUtility.mTeamDungeonIds != null)
			{
				return;
			}
			List<int> list = new List<int>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<TeamDungeonTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				TeamDungeonTable teamDungeonTable = keyValuePair.Value as TeamDungeonTable;
				if (teamDungeonTable != null && teamDungeonTable.DungeonID > 0)
				{
					list.Add(teamDungeonTable.DungeonID);
				}
			}
			ChapterUtility.mTeamDungeonIds = list.ToArray();
		}

		// Token: 0x0600D442 RID: 54338 RVA: 0x0034EB14 File Offset: 0x0034CF14
		public static bool IsTeamDungeonID(int dungeonID)
		{
			ChapterUtility._loadTeamDungeonIds();
			if (ChapterUtility.mTeamDungeonIds == null)
			{
				return false;
			}
			for (int i = 0; i < ChapterUtility.mTeamDungeonIds.Length; i++)
			{
				if (dungeonID == ChapterUtility.mTeamDungeonIds[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D443 RID: 54339 RVA: 0x0034EB5C File Offset: 0x0034CF5C
		private static void _loadPVEChapterIds()
		{
			if (ChapterUtility.mPVEChapterIds != null)
			{
				return;
			}
			List<int> list = new List<int>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChapterTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChapterTable chapterTable = keyValuePair.Value as ChapterTable;
				list.Add(chapterTable.ID);
			}
			ChapterUtility.mPVEChapterIds = list.ToArray();
		}

		// Token: 0x0600D444 RID: 54340 RVA: 0x0034EBCC File Offset: 0x0034CFCC
		public static bool IsPVEChapter(int chapterId)
		{
			ChapterUtility._loadPVEChapterIds();
			if (ChapterUtility.mPVEChapterIds == null)
			{
				return false;
			}
			for (int i = 0; i < ChapterUtility.mPVEChapterIds.Length; i++)
			{
				if (ChapterUtility.mPVEChapterIds[i] == chapterId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D445 RID: 54341 RVA: 0x0034EC14 File Offset: 0x0034D014
		public static int GetLastedDungeonIDByDiff(int diff)
		{
			if (diff >= 0 && diff < 4)
			{
				List<Battle.DungeonOpenInfo> openedList = DataManager<BattleDataManager>.GetInstance().ChapterInfo.openedList;
				for (int i = openedList.Count - 1; i >= 0; i--)
				{
					int id = openedList[i].id;
					DungeonID dungeonID = new DungeonID(id);
					if (ChapterUtility.IsPVEChapter(dungeonID.chapterID))
					{
						int dungeonRealTopHard = ChapterUtility.GetDungeonRealTopHard(id);
						if (dungeonRealTopHard >= diff)
						{
							dungeonID.diffID = diff;
							return dungeonID.dungeonID;
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x0600D446 RID: 54342 RVA: 0x0034EC9C File Offset: 0x0034D09C
		public static int GetDungeonID2Enter(int dungeonID)
		{
			IList<int> list = ChapterUtility.PreconditionIDList(dungeonID);
			List<Battle.DungeonOpenInfo> openedList = DataManager<BattleDataManager>.GetInstance().ChapterInfo.openedList;
			ChapterUtility.mSearchOp.id = dungeonID;
			int num = openedList.BinarySearch(ChapterUtility.mSearchOp);
			if (num >= 0)
			{
				if (list != null && list.Count > 0)
				{
					List<MissionManager.SingleMissionInfo> allTaskByType = DataManager<MissionManager>.GetInstance().GetAllTaskByType(MissionTable.eTaskType.TT_MAIN, null);
					if (allTaskByType != null && allTaskByType.Count > 0)
					{
						for (int i = 0; i < allTaskByType.Count; i++)
						{
							if (allTaskByType[i].status == 1)
							{
								MissionTable tableItem = Singleton<TableManager>.instance.GetTableItem<MissionTable>((int)allTaskByType[i].taskID, string.Empty, string.Empty);
								if (tableItem != null && tableItem.MapID != 0)
								{
									bool flag = false;
									for (int j = 0; j < list.Count; j++)
									{
										if (list[j] == tableItem.MapID)
										{
											flag = true;
											break;
										}
									}
									if (flag)
									{
										return tableItem.MapID;
									}
								}
							}
						}
					}
				}
				return dungeonID;
			}
			for (int k = list.Count - 1; k >= 0; k--)
			{
				int num2 = list[k];
				if (num2 > 0)
				{
					ChapterUtility.mSearchOp.id = num2;
					int num3 = openedList.BinarySearch(ChapterUtility.mSearchOp);
					if (num3 >= 0)
					{
						return num2;
					}
				}
			}
			return -1;
		}

		// Token: 0x0600D447 RID: 54343 RVA: 0x0034EE18 File Offset: 0x0034D218
		public static DungeonScore GetDungeonBestScore(int id)
		{
			DungeonInfo dungeonInfo = ChapterUtility._isInAllInfo(id);
			if (dungeonInfo != null)
			{
				return (DungeonScore)dungeonInfo.bestScore;
			}
			return DungeonScore.C;
		}

		// Token: 0x0600D448 RID: 54344 RVA: 0x0034EE3C File Offset: 0x0034D23C
		private static DungeonInfo _isInAllInfo(int dungeonID)
		{
			List<DungeonInfo> allInfo = DataManager<BattleDataManager>.GetInstance().ChapterInfo.allInfo;
			return allInfo.Find((DungeonInfo x) => x.id == dungeonID);
		}

		// Token: 0x0600D449 RID: 54345 RVA: 0x0034EE7C File Offset: 0x0034D27C
		private static Battle.DungeonOpenInfo _isOpen(int dungeonID)
		{
			ChapterUtility.mDungeonID.dungeonID = dungeonID;
			List<Battle.DungeonOpenInfo> openedList = DataManager<BattleDataManager>.GetInstance().ChapterInfo.openedList;
			return openedList.Find((Battle.DungeonOpenInfo x) => x.id == ChapterUtility.mDungeonID.dungeonIDWithOutDiff);
		}

		// Token: 0x0600D44A RID: 54346 RVA: 0x0034EECC File Offset: 0x0034D2CC
		public static bool IsCanComsumeFatigue(int dungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			return tableItem == null || tableItem.CostFatiguePerArea <= (int)DataManager<PlayerBaseData>.GetInstance().fatigue;
		}

		// Token: 0x0600D44B RID: 54347 RVA: 0x0034EF0D File Offset: 0x0034D30D
		public static bool OpenComsumeFatigueAddFrame(int dungeonID)
		{
			if (!ChapterUtility.IsCanComsumeFatigue(dungeonID))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<ComsumeFatigueAddFrame>(null, false);
				Singleton<ClientSystemManager>.instance.OpenFrame<ComsumeFatigueAddFrame>(FrameLayer.Middle, null, string.Empty);
				return true;
			}
			return false;
		}

		// Token: 0x0600D44C RID: 54348 RVA: 0x0034EF3C File Offset: 0x0034D33C
		public static bool GetDungeonCanEnter(int id, bool withTips = true, bool checkTicket = true, bool withTicketGetLink = true)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.MinLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
				{
					if (withTips)
					{
						SystemNotifyManager.SystemNotify(5007, new object[]
						{
							tableItem.MinLevel
						});
					}
					return false;
				}
				if (checkTicket && tableItem.TicketID > 0)
				{
					ItemTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ItemTable>(tableItem.TicketID, string.Empty, string.Empty);
					int num = tableItem.TicketNum;
					int num2 = 0;
					bool flag = false;
					int num3 = 0;
					if (tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL)
					{
						flag = DataManager<ActivityDataManager>.GetInstance().CheckIsBuyAbyssBlackGoldMember();
						if (flag)
						{
							SystemValueTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(707, string.Empty, string.Empty);
							if (tableItem3 != null)
							{
								num3 = tableItem3.Value;
							}
						}
					}
					if (tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY)
					{
						if (DataManager<ActivityDataManager>.GetInstance().GettAnniverTaskIsFinish(EAnniverBuffPrayType.HellTicketMinus) && DataManager<ActivityDataManager>.GetInstance().IsLeftChallengeTimes(EAnniverBuffPrayType.HellTicketMinus, CounterKeys.DUNGEON_HELL_TIMES))
						{
							num2 = DataManager<ActivityDataManager>.GetInstance().GetAnniverTaskValue(EAnniverBuffPrayType.HellTicketMinus);
						}
						DungeonID dungeonID = new DungeonID(tableItem.ID);
						if (dungeonID.dungeonIDWithOutDiff == 857000)
						{
							if (flag)
							{
								num = num * num3 / 100 - num2;
							}
							else
							{
								num -= num2;
							}
						}
						else
						{
							num -= num2;
						}
					}
					else if (tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL)
					{
						if (flag)
						{
							num = num * num3 / 100;
						}
					}
					else if (tableItem.SubType == DungeonTable.eSubType.S_YUANGU && DataManager<ActivityDataManager>.GetInstance().GettAnniverTaskIsFinish(EAnniverBuffPrayType.YuanGUTicketMinus) && DataManager<ActivityDataManager>.GetInstance().IsLeftChallengeTimes(EAnniverBuffPrayType.HellTicketMinus, CounterKeys.DUNGEON_YUANGU_TIMES))
					{
						num2 = DataManager<ActivityDataManager>.GetInstance().GetAnniverTaskValue(EAnniverBuffPrayType.YuanGUTicketMinus);
						num -= num2;
					}
					if (num < 0)
					{
						Logger.LogError(string.Format("消耗的深渊票数量小于0，周年祈福buff减少的票数为：{0}", num2));
					}
					if (tableItem2 != null)
					{
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem.TicketID, true);
						if (ownedItemCount < num)
						{
							if (withTips)
							{
								SystemNotifyManager.SystemNotify(5009, new object[]
								{
									tableItem2.Name,
									num
								});
								if (withTicketGetLink)
								{
									if (tableItem.SubType == DungeonTable.eSubType.S_YUANGU)
									{
										LimitTimeGiftDataManager giftDataManager = DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager;
										MallGiftPackActivateCond activateCond = MallGiftPackActivateCond.NO_ANCIENT_TICKET;
										if (ChapterUtility.<>f__mg$cache0 == null)
										{
											ChapterUtility.<>f__mg$cache0 = new Action(ChapterUtility._onOpenYuanGuLinkFrame);
										}
										giftDataManager.TryShowMallGift(activateCond, ChapterUtility.<>f__mg$cache0);
									}
									else if (tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL)
									{
										LimitTimeGiftDataManager giftDataManager2 = DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager;
										MallGiftPackActivateCond activateCond2 = MallGiftPackActivateCond.NO_HELL_TICKET;
										if (ChapterUtility.<>f__mg$cache1 == null)
										{
											ChapterUtility.<>f__mg$cache1 = new Action(ChapterUtility._onOpenHellLinkFrame);
										}
										giftDataManager2.TryShowMallGift(activateCond2, ChapterUtility.<>f__mg$cache1);
									}
									else if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY)
									{
										ChapterUtility.OpenWeekHellCostLinkFrame(tableItem.TicketID);
									}
								}
							}
							return false;
						}
					}
				}
			}
			if (ChapterUtility.GetDungeonState(id) == ComChapterDungeonUnit.eState.Locked)
			{
				if (withTips)
				{
					SystemNotifyManager.SystemNotify(1009, string.Empty);
				}
				return false;
			}
			return true;
		}

		// Token: 0x0600D44D RID: 54349 RVA: 0x0034F250 File Offset: 0x0034D650
		private static void OpenWeekHellCostLinkFrame(int itemId)
		{
			ItemComeLink.OnLink(itemId, 0, false, null, false, true, false, null, string.Empty);
		}

		// Token: 0x0600D44E RID: 54350 RVA: 0x0034F270 File Offset: 0x0034D670
		private static void _onOpenYuanGuLinkFrame()
		{
			ItemComeLink.OnLink(200000003, 0, false, null, false, true, false, null, string.Empty);
		}

		// Token: 0x0600D44F RID: 54351 RVA: 0x0034F294 File Offset: 0x0034D694
		private static void _onOpenHellLinkFrame()
		{
			ItemComeLink.OnLink(200000004, 0, false, null, false, true, false, null, string.Empty);
		}

		// Token: 0x0600D450 RID: 54352 RVA: 0x0034F2B8 File Offset: 0x0034D6B8
		public static ComChapterDungeonUnit.eState GetDungeonState(int id)
		{
			if (id > 0)
			{
				ChapterUtility.mDungeonID.dungeonID = id;
				int dungeonIDWithOutDiff = ChapterUtility.mDungeonID.dungeonIDWithOutDiff;
				int diffID = ChapterUtility.mDungeonID.diffID;
				bool flag = ChapterUtility.mDungeonID.prestoryID > 0;
				if (ChapterUtility._isInAllInfo(id) != null)
				{
					return (!flag) ? ComChapterDungeonUnit.eState.Passed : ComChapterDungeonUnit.eState.LockPassed;
				}
				if (ChapterUtility._isOpen(dungeonIDWithOutDiff) == null)
				{
					return ComChapterDungeonUnit.eState.Locked;
				}
				int dungeonRealTopHard = ChapterUtility.GetDungeonRealTopHard(dungeonIDWithOutDiff);
				if (diffID == 0 || dungeonRealTopHard >= diffID)
				{
					return ComChapterDungeonUnit.eState.Unlock;
				}
			}
			return ComChapterDungeonUnit.eState.Locked;
		}

		// Token: 0x0600D451 RID: 54353 RVA: 0x0034F340 File Offset: 0x0034D740
		public static bool IsHell(int dungeonID)
		{
			List<Battle.DungeonOpenInfo> openedList = DataManager<BattleDataManager>.GetInstance().ChapterInfo.openedList;
			ChapterUtility.mSearchOp.id = dungeonID;
			int num = openedList.BinarySearch(ChapterUtility.mSearchOp);
			return num >= 0 && openedList[num].isHell;
		}

		// Token: 0x0600D452 RID: 54354 RVA: 0x0034F38C File Offset: 0x0034D78C
		public static KeyValuePair<int, int> NextDungeonIDWithMission(int dungeonID)
		{
			ChapterUtility.mDungeonID.dungeonID = dungeonID;
			int diffID = ChapterUtility.mDungeonID.diffID;
			int dungeonIDWithOutDiff = ChapterUtility.mDungeonID.dungeonIDWithOutDiff;
			int dungeonIDWithOutPrestory = ChapterUtility.mDungeonID.dungeonIDWithOutPrestory;
			int num = -1;
			int value = -1;
			if (dungeonIDWithOutDiff != dungeonIDWithOutPrestory)
			{
				DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonIDWithOutPrestory, string.Empty, string.Empty);
				if (tableItem != null)
				{
					IList<int> storyDungeonIDs = tableItem.storyDungeonIDs;
					int num2 = storyDungeonIDs.IndexOf(dungeonIDWithOutDiff);
					int num3 = storyDungeonIDs.Count - 1;
					if (num3 >= 0 && num2 >= 0)
					{
						if (num2 == num3)
						{
							num = dungeonIDWithOutPrestory + diffID;
						}
						else
						{
							num = storyDungeonIDs[num2 + 1] + diffID;
						}
					}
					DungeonTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(num, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						value = tableItem2.storyTaskID;
					}
					else
					{
						Logger.LogErrorFormat("the nextID can't find in DugeonTable with ID {0}", new object[]
						{
							num
						});
					}
				}
			}
			return new KeyValuePair<int, int>(num, value);
		}

		// Token: 0x0600D453 RID: 54355 RVA: 0x0034F48C File Offset: 0x0034D88C
		public static ComChapterDungeonUnit.eMissionType GetMissionType(int missionID)
		{
			MissionTable tableItem = Singleton<TableManager>.instance.GetTableItem<MissionTable>(missionID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				MissionTable.eTaskType taskType = tableItem.TaskType;
				if (taskType != MissionTable.eTaskType.TT_MAIN)
				{
					if (taskType == MissionTable.eTaskType.TT_BRANCH)
					{
						return ComChapterDungeonUnit.eMissionType.Other;
					}
					if (taskType != MissionTable.eTaskType.TT_CHANGEJOB)
					{
						return ComChapterDungeonUnit.eMissionType.None;
					}
				}
				return ComChapterDungeonUnit.eMissionType.Main;
			}
			return ComChapterDungeonUnit.eMissionType.None;
		}

		// Token: 0x0600D454 RID: 54356 RVA: 0x0034F4E0 File Offset: 0x0034D8E0
		public static IClientFrame OpenChapterFrameByID(int dungeonID, GameObject root = null)
		{
			ChapterBaseFrame.sDungeonID = dungeonID;
			DungeonID dungeonID2 = new DungeonID(dungeonID);
			DungeonUIConfigTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonUIConfigTable>(dungeonID2.dungeonIDWithOutDiff, string.Empty, string.Empty);
			IClientFrame result = null;
			if (tableItem != null)
			{
				Type type = TypeTable.GetType(tableItem.ClassName);
				if (type != null)
				{
					result = Singleton<ClientSystemManager>.instance.OpenFrame(type, root, null, string.Empty, FrameLayer.Invalid);
				}
				else
				{
					Logger.LogErrorFormat("can't find {0}", new object[]
					{
						tableItem.ClassName
					});
				}
			}
			else
			{
				result = Singleton<ClientSystemManager>.instance.OpenFrame(typeof(ChapterNormalFrame), root, null, string.Empty, FrameLayer.Invalid);
			}
			ChapterUtility._enterChapterInfoStat(dungeonID);
			return result;
		}

		// Token: 0x0600D455 RID: 54357 RVA: 0x0034F58C File Offset: 0x0034D98C
		public static KeyValuePair<int, int> GetChapterRewardByChapterIdx(int chid)
		{
			List<MissionManager.SingleMissionInfo> list = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Mission, chid);
			if (list == null)
			{
				Logger.LogErrorFormat("[关卡宝箱] allMission == null, childindex = {0}", new object[]
				{
					chid
				});
				return default(KeyValuePair<int, int>);
			}
			int count = list.Count;
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].status == 5)
				{
					num++;
				}
			}
			return new KeyValuePair<int, int>(num, count);
		}

		// Token: 0x0600D456 RID: 54358 RVA: 0x0034F60C File Offset: 0x0034DA0C
		public static KeyValuePair<int, int> GetChapterRewardByChapterIdxNew(int chid)
		{
			List<MissionManager.SingleMissionInfo> list = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Mission, chid);
			int value = list.Count * 3;
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				MissionManager.SingleMissionInfo singleMissionInfo = list[i];
				uint taskID = singleMissionInfo.taskID;
				string missionValueByKey = DataManager<MissionManager>.GetInstance().GetMissionValueByKey(taskID, "score");
				string missionValueByKey2 = DataManager<MissionManager>.GetInstance().GetMissionValueByKey(taskID, "parameter");
				int num2 = -1;
				int num3 = -1;
				int.TryParse(missionValueByKey, out num2);
				int.TryParse(missionValueByKey2, out num3);
				if (num2 != 0)
				{
					switch (num2)
					{
					case 3:
						num++;
						break;
					case 4:
						num += 2;
						break;
					case 5:
						num += 3;
						break;
					}
				}
				else if (num3 == 1)
				{
					num += 3;
				}
			}
			return new KeyValuePair<int, int>(num, value);
		}

		// Token: 0x0600D457 RID: 54359 RVA: 0x0034F700 File Offset: 0x0034DB00
		public static int GetChapterCanGetByChapterIdx(int chid)
		{
			List<MissionManager.SingleMissionInfo> list = ChapterUtility.FilterMissionInfoByChapterIdx(MissionTable.eSubType.Dungeon_Mission, chid);
			if (list == null)
			{
				return 0;
			}
			int count = list.Count;
			int num = 0;
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].status == 2)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600D458 RID: 54360 RVA: 0x0034F754 File Offset: 0x0034DB54
		public static List<MissionManager.SingleMissionInfo> FilterMissionInfoByChapterIdx(MissionTable.eSubType subType, int chid)
		{
			if (chid <= 0)
			{
				return null;
			}
			List<MissionManager.SingleMissionInfo> allTaskByType = DataManager<MissionManager>.GetInstance().GetAllTaskByType(MissionTable.eTaskType.TT_ACHIEVEMENT, new MissionTable.eSubType[]
			{
				subType
			});
			if (allTaskByType != null && allTaskByType.Count <= 0)
			{
				Logger.LogErrorFormat("[关卡宝箱] 总章节奖励未配置,subType = {0}, chidx = {1}", new object[]
				{
					subType,
					chid
				});
			}
			allTaskByType.RemoveAll(delegate(MissionManager.SingleMissionInfo x)
			{
				int num = -1;
				return !int.TryParse(x.missionItem.MissionParam, out num) || num != chid;
			});
			return allTaskByType;
		}

		// Token: 0x0600D459 RID: 54361 RVA: 0x0034F7DF File Offset: 0x0034DBDF
		public static List<MissionManager.SingleMissionInfo> FilterMissionInfoByCurChapter(MissionTable.eSubType subType)
		{
			return ChapterUtility.FilterMissionInfoByChapterIdx(subType, ChapterSelectFrame.GetCurrentSelectChapter());
		}

		// Token: 0x0600D45A RID: 54362 RVA: 0x0034F7EC File Offset: 0x0034DBEC
		public static bool IsChapterCanGetChapterReward(int chid)
		{
			if (chid <= 0)
			{
				return false;
			}
			List<MissionManager.SingleMissionInfo> allTaskByType = DataManager<MissionManager>.GetInstance().GetAllTaskByType(MissionTable.eTaskType.TT_ACHIEVEMENT, new MissionTable.eSubType[]
			{
				MissionTable.eSubType.Dungeon_Chest,
				MissionTable.eSubType.Dungeon_Mission
			});
			allTaskByType.RemoveAll(delegate(MissionManager.SingleMissionInfo x)
			{
				int num = -1;
				return !int.TryParse(x.missionItem.MissionParam, out num) || num != chid || x.status != 2;
			});
			return allTaskByType.Count > 0;
		}

		// Token: 0x0600D45B RID: 54363 RVA: 0x0034F84C File Offset: 0x0034DC4C
		public static bool IsChapterOpen(int chapterID)
		{
			DungeonID dungeonID = new DungeonID(0);
			List<DungeonInfo> allInfo = DataManager<BattleDataManager>.GetInstance().ChapterInfo.allInfo;
			DungeonInfo dungeonInfo = allInfo.Find(delegate(DungeonInfo x)
			{
				dungeonID.dungeonID = x.id;
				return dungeonID.chapterID == chapterID;
			});
			if (dungeonInfo != null)
			{
				return true;
			}
			List<Battle.DungeonOpenInfo> openedList = DataManager<BattleDataManager>.GetInstance().ChapterInfo.openedList;
			return openedList.Find(delegate(Battle.DungeonOpenInfo x)
			{
				dungeonID.dungeonID = x.id;
				return dungeonID.chapterID == chapterID;
			}) != null;
		}

		// Token: 0x0600D45C RID: 54364 RVA: 0x0034F8CC File Offset: 0x0034DCCC
		public static bool IsChapterOpenBySceneID(int sceneID)
		{
			int num = ChapterUtility._getChapterIndexBySceneID(sceneID);
			if (num < 0)
			{
				return false;
			}
			int dungeonID2Enter = ChapterUtility.GetDungeonID2Enter(num);
			return ChapterUtility.GetDungeonCanEnter(dungeonID2Enter, false, false, true);
		}

		// Token: 0x0600D45D RID: 54365 RVA: 0x0034F8FC File Offset: 0x0034DCFC
		public static bool IsEliteChapterOpenBySceneId(int sceneID)
		{
			bool result = false;
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(sceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return result;
			}
			bool flag = false;
			for (int i = 0; i < tableItem.ChapterData.Count; i++)
			{
				DChapterData dchapterData = Singleton<AssetLoader>.instance.LoadRes(tableItem.ChapterData[i], typeof(DChapterData), true, 0U).obj as DChapterData;
				if (null == dchapterData)
				{
					return result;
				}
				for (int j = 0; j < dchapterData.chapterList.Length; j++)
				{
					int dungeonID = dchapterData.chapterList[j].dungeonID;
					if (TeamUtility.IsEliteDungeonID(dungeonID))
					{
						ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID);
						if (dungeonState != ComChapterDungeonUnit.eState.Locked)
						{
							result = true;
							flag = true;
							break;
						}
					}
				}
				if (flag)
				{
					break;
				}
			}
			return result;
		}

		// Token: 0x0600D45E RID: 54366 RVA: 0x0034F9E4 File Offset: 0x0034DDE4
		private static int _getChapterIndexBySceneID(int sceneID)
		{
			if (ChapterUtility.mCitySceneID2ChapterIdx.ContainsKey(sceneID))
			{
				return ChapterUtility.mCitySceneID2ChapterIdx[sceneID];
			}
			CitySceneTable tableItem = Singleton<TableManager>.instance.GetTableItem<CitySceneTable>(sceneID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			DChapterData dchapterData = Singleton<AssetLoader>.instance.LoadRes(tableItem.ChapterData[0], typeof(DChapterData), true, 0U).obj as DChapterData;
			if (null == dchapterData)
			{
				return -1;
			}
			if (dchapterData.chapterList.Length > 0)
			{
				DungeonID dungeonID = new DungeonID(dchapterData.chapterList[0].dungeonID);
				ChapterUtility.mCitySceneID2ChapterIdx.Add(sceneID, dungeonID.dungeonIDWithOutDiff);
				return dungeonID.dungeonIDWithOutDiff;
			}
			return -1;
		}

		// Token: 0x0600D45F RID: 54367 RVA: 0x0034FAA0 File Offset: 0x0034DEA0
		public static int[] GetAllChapterRewardChapters()
		{
			List<MissionManager.SingleMissionInfo> allTaskByType = DataManager<MissionManager>.GetInstance().GetAllTaskByType(MissionTable.eTaskType.TT_ACHIEVEMENT, new MissionTable.eSubType[]
			{
				MissionTable.eSubType.Dungeon_Chest
			});
			List<int> list = new List<int>();
			for (int i = 0; i < allTaskByType.Count; i++)
			{
				int item = -1;
				if (int.TryParse(allTaskByType[i].missionItem.MissionParam, out item))
				{
					list.Add(item);
				}
			}
			list.Sort();
			return list.ToArray();
		}

		// Token: 0x0600D460 RID: 54368 RVA: 0x0034FB14 File Offset: 0x0034DF14
		public static bool IsChapterCanGetChapterRewards()
		{
			int[] allChapterRewardChapters = ChapterUtility.GetAllChapterRewardChapters();
			for (int i = 0; i < allChapterRewardChapters.Length; i++)
			{
				if (ChapterUtility.IsChapterCanGetChapterReward(allChapterRewardChapters[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D461 RID: 54369 RVA: 0x0034FB4B File Offset: 0x0034DF4B
		private static void _enterChapterInfoStat(int id)
		{
			ChapterUtility.mDungeonID.dungeonID = id;
			Singleton<GameStatisticManager>.instance.DoStatLevelChoose(StatLevelChooseType.CHOOSE_LEVEL, ChapterSelectFrame.sSceneID, ChapterUtility.mDungeonID.dungeonID, ChapterUtility.mDungeonID.diffID, null);
		}

		// Token: 0x0600D462 RID: 54370 RVA: 0x0034FB80 File Offset: 0x0034DF80
		public static bool HellIsPass(int dungeonId)
		{
			ChapterUtility._updateDungeonHellSplit();
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY)
			{
				return ChapterUtility.GetDungeonState(dungeonId) == ComChapterDungeonUnit.eState.Passed;
			}
			return tableItem.SubType == DungeonTable.eSubType.S_HELL && ChapterUtility.GetDungeonState(ChapterUtility._getHellEnterId(dungeonId)) == ComChapterDungeonUnit.eState.Passed;
		}

		// Token: 0x0600D463 RID: 54371 RVA: 0x0034FBDC File Offset: 0x0034DFDC
		public static int GetOriginDungeonId(int dungeonId)
		{
			ChapterUtility._updateDungeonHellSplit();
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL)
			{
				return tableItem.ownerEntryId;
			}
			if (tableItem.SubType != DungeonTable.eSubType.S_HELL)
			{
				return dungeonId;
			}
			return ChapterUtility._getHellEnterId(dungeonId);
		}

		// Token: 0x0600D464 RID: 54372 RVA: 0x0034FC34 File Offset: 0x0034E034
		private static void _updateDungeonHellSplit()
		{
			if (ChapterUtility.mHellEnter != null)
			{
				return;
			}
			ChapterUtility.mHellEnter = new Dictionary<int, int>();
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<DungeonTable>();
			Dictionary<int, object>.KeyCollection.Enumerator enumerator = table.Keys.GetEnumerator();
			DungeonID dungeonID = new DungeonID(0);
			while (enumerator.MoveNext())
			{
				int key = enumerator.Current;
				DungeonTable dungeonTable = table[key] as DungeonTable;
				if (dungeonTable != null && dungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY && !ChapterUtility.mHellEnter.ContainsKey(dungeonTable.HellSplitLevel))
				{
					dungeonID.dungeonID = dungeonTable.ID;
					ChapterUtility.mHellEnter.Add(dungeonTable.HellSplitLevel, dungeonID.dungeonIDWithOutDiff);
				}
			}
		}

		// Token: 0x0600D465 RID: 54373 RVA: 0x0034FCEC File Offset: 0x0034E0EC
		private static int _getHellEnterId(int dungeonId)
		{
			DungeonID dungeonID = new DungeonID(dungeonId);
			int diffID = dungeonID.diffID;
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (!ChapterUtility.mHellEnter.ContainsKey(tableItem.HellSplitLevel))
			{
				return 0;
			}
			dungeonID.dungeonID = ChapterUtility.mHellEnter[tableItem.HellSplitLevel];
			dungeonID.diffID = diffID;
			return dungeonID.dungeonID;
		}

		// Token: 0x04007C83 RID: 31875
		public const int kDeadTowerTopLevel = 80;

		// Token: 0x04007C84 RID: 31876
		public const int kDeadTowerLevelSplit = 5;

		// Token: 0x04007C85 RID: 31877
		public const int kDeadTowerLevelCount = 16;

		// Token: 0x04007C86 RID: 31878
		private static DungeonID mDungeonID = new DungeonID(0);

		// Token: 0x04007C87 RID: 31879
		private static Battle.DungeonOpenInfo mSearchOp = new Battle.DungeonOpenInfo();

		// Token: 0x04007C88 RID: 31880
		private const int kMaxDiff = 4;

		// Token: 0x04007C89 RID: 31881
		private static int[] mTeamDungeonIds = null;

		// Token: 0x04007C8A RID: 31882
		private static int[] mPVEChapterIds = null;

		// Token: 0x04007C8B RID: 31883
		private static Dictionary<int, int> mCitySceneID2ChapterIdx = new Dictionary<int, int>();

		// Token: 0x04007C8C RID: 31884
		private static Dictionary<int, int> mHellEnter = null;

		// Token: 0x04007C8F RID: 31887
		[CompilerGenerated]
		private static Action <>f__mg$cache0;

		// Token: 0x04007C90 RID: 31888
		[CompilerGenerated]
		private static Action <>f__mg$cache1;
	}
}
