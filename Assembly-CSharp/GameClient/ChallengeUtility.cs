using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001202 RID: 4610
	public static class ChallengeUtility
	{
		// Token: 0x0600B14D RID: 45389 RVA: 0x00272B69 File Offset: 0x00270F69
		public static void OnOpenChallengeDungeonRewardFrame(ChallengeDungeonRewardDataModel rewardDataModel)
		{
			ChallengeUtility.OnCloseChallengeDungeonRewardFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeDungeonRewardFrame>(FrameLayer.Middle, rewardDataModel, string.Empty);
		}

		// Token: 0x0600B14E RID: 45390 RVA: 0x00272B82 File Offset: 0x00270F82
		public static void OnCloseChallengeDungeonRewardFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChallengeDungeonRewardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChallengeDungeonRewardFrame>(null, false);
			}
		}

		// Token: 0x0600B14F RID: 45391 RVA: 0x00272BA0 File Offset: 0x00270FA0
		public static void OnOpenTeamListFrame()
		{
			if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team))
			{
				FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(30, string.Empty, string.Empty);
				if (tableItem != null)
				{
					SystemNotifyManager.SystemNotify(tableItem.CommDescID, string.Empty);
				}
				return;
			}
			ChallengeUtility.OnCloseTeamListFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<TeamListFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B150 RID: 45392 RVA: 0x00272BFE File Offset: 0x00270FFE
		public static void OnCloseTeamListFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TeamListFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TeamListFrame>(null, false);
			}
		}

		// Token: 0x0600B151 RID: 45393 RVA: 0x00272C1C File Offset: 0x0027101C
		public static void OnOpenChallengeDropDetailFrame(int dungeonId)
		{
			ChallengeUtility.OnCloseChallengeDropDetailFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeDropDetailFrame>(FrameLayer.Middle, dungeonId, string.Empty);
		}

		// Token: 0x0600B152 RID: 45394 RVA: 0x00272C3A File Offset: 0x0027103A
		public static void OnCloseChallengeDropDetailFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChallengeDropDetailFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChallengeDropDetailFrame>(null, false);
			}
		}

		// Token: 0x0600B153 RID: 45395 RVA: 0x00272C58 File Offset: 0x00271058
		public static void OnCloseChallengeModelFrame()
		{
		}

		// Token: 0x0600B154 RID: 45396 RVA: 0x00272C5A File Offset: 0x0027105A
		public static void OnCloseChallengeMapFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChallengeMapFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChallengeMapFrame>(null, false);
			}
		}

		// Token: 0x0600B155 RID: 45397 RVA: 0x00272C78 File Offset: 0x00271078
		public static DungeonModelTable GetChallengeDungeonModelTableByModelType(DungeonModelTable.eType modelType)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<DungeonModelTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					DungeonModelTable dungeonModelTable = keyValuePair.Value as DungeonModelTable;
					if (dungeonModelTable != null && dungeonModelTable.Type == modelType)
					{
						return dungeonModelTable;
					}
				}
			}
			return Singleton<TableManager>.GetInstance().GetTableItem<DungeonModelTable>(1, string.Empty, string.Empty);
		}

		// Token: 0x0600B156 RID: 45398 RVA: 0x00272CF0 File Offset: 0x002710F0
		public static int GetChallengeDungeonMapIdByModelType(DungeonModelTable.eType modelType)
		{
			DungeonModelTable challengeDungeonModelTableByModelType = ChallengeUtility.GetChallengeDungeonModelTableByModelType(modelType);
			if (challengeDungeonModelTableByModelType != null)
			{
				return challengeDungeonModelTableByModelType.mapID;
			}
			return 0;
		}

		// Token: 0x0600B157 RID: 45399 RVA: 0x00272D14 File Offset: 0x00271114
		public static int GetChallengeDungeonLockLevelByModelType(DungeonModelTable.eType modelType)
		{
			DungeonModelTable challengeDungeonModelTableByModelType = ChallengeUtility.GetChallengeDungeonModelTableByModelType(modelType);
			if (challengeDungeonModelTableByModelType != null)
			{
				return challengeDungeonModelTableByModelType.Level;
			}
			return 0;
		}

		// Token: 0x0600B158 RID: 45400 RVA: 0x00272D38 File Offset: 0x00271138
		public static void OnOpenClientFrameStackCmd(int dungeonId, DungeonTable dungeonTable)
		{
			if (dungeonTable == null)
			{
				return;
			}
			DungeonModelTable.eType modelType = DungeonModelTable.eType.DeepModel;
			if (dungeonTable.SubType == DungeonTable.eSubType.S_YUANGU)
			{
				modelType = DungeonModelTable.eType.AncientModel;
			}
			else if (dungeonTable.SubType == DungeonTable.eSubType.S_WEEK_HELL || dungeonTable.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY || dungeonTable.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER)
			{
				modelType = DungeonModelTable.eType.WeekHellModel;
			}
			DungeonID dungeonID = new DungeonID(dungeonId);
			int dungeonIDWithOutDiff = dungeonID.dungeonIDWithOutDiff;
			ChallengeMapParamDataModel data = new ChallengeMapParamDataModel
			{
				ModelType = modelType,
				BaseDungeonId = dungeonIDWithOutDiff,
				DetailDungeonId = dungeonId
			};
			Singleton<ClientSystemManager>.instance.Push2FrameStack(new OpenClientFrameStackCmd(typeof(ChallengeMapFrame), data));
		}

		// Token: 0x0600B159 RID: 45401 RVA: 0x00272DD4 File Offset: 0x002711D4
		public static void OnOpenChallengeMapFrame(DungeonModelTable.eType modelType, int baseDungeonId, int detailDungeonId = 0)
		{
			if (modelType == DungeonModelTable.eType.Type_None)
			{
				modelType = DungeonModelTable.eType.DeepModel;
			}
			ChallengeUtility.OnCloseChallengeMapFrame();
			ChallengeUtility.OnCloseChallengeChapterFrame();
			int challengeDungeonMapIdByModelType = ChallengeUtility.GetChallengeDungeonMapIdByModelType(modelType);
			ChallengeMapParamDataModel userData = new ChallengeMapParamDataModel
			{
				ModelType = modelType,
				BaseDungeonId = baseDungeonId,
				DetailDungeonId = detailDungeonId
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeMapFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B15A RID: 45402 RVA: 0x00272E2A File Offset: 0x0027122A
		public static void OnCloseChallengeChapterFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChallengeChapterFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChallengeChapterFrame>(null, false);
			}
		}

		// Token: 0x0600B15B RID: 45403 RVA: 0x00272E48 File Offset: 0x00271248
		public static void OnOpenChallengeChapterFrame(DungeonModelTable.eType modelType, int baseChapterId, int selectedChapterId, List<int> chapterIdList = null)
		{
			ChallengeUtility.OnCloseChallengeChapterFrame();
			if (DungeonUtility.IsLimitTimeHellDungeon(baseChapterId) || DungeonUtility.IsWeekHellEntryDungeon(baseChapterId))
			{
				chapterIdList = null;
			}
			ChallengeChapterParamDataModel userData = new ChallengeChapterParamDataModel
			{
				ModelType = modelType,
				BaseChapterId = baseChapterId,
				SelectedChapterId = selectedChapterId,
				ChapterIdList = chapterIdList
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChallengeChapterFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B15C RID: 45404 RVA: 0x00272EA9 File Offset: 0x002712A9
		public static string GetColorString(string color, string name)
		{
			return string.Format("<color={0}>{1}</color>", color, name);
		}

		// Token: 0x0600B15D RID: 45405 RVA: 0x00272EB7 File Offset: 0x002712B7
		public static int GetExpRate(int levelId)
		{
			if (levelId == 0)
			{
				return 0;
			}
			if (levelId == 1)
			{
				return 10;
			}
			if (levelId == 2)
			{
				return 20;
			}
			if (levelId == 3)
			{
				return 50;
			}
			return 0;
		}

		// Token: 0x0600B15E RID: 45406 RVA: 0x00272EE0 File Offset: 0x002712E0
		public static int GetDropRate(int levelId)
		{
			if (levelId == 0)
			{
				return 0;
			}
			if (levelId == 1)
			{
				return 5;
			}
			if (levelId == 2)
			{
				return 10;
			}
			if (levelId == 3)
			{
				return 20;
			}
			return 0;
		}

		// Token: 0x0600B15F RID: 45407 RVA: 0x00272F08 File Offset: 0x00271308
		public static int GetOnlyKingHardLevelDropRate()
		{
			return 200;
		}

		// Token: 0x0600B160 RID: 45408 RVA: 0x00272F10 File Offset: 0x00271310
		public static string GetLevelName(int levelId)
		{
			if (levelId == 0)
			{
				return TR.Value("challenge_chapter_level_normal");
			}
			if (levelId == 1)
			{
				return TR.Value("challenge_chapter_level_adventure");
			}
			if (levelId == 2)
			{
				return TR.Value("challenge_chapter_level_warrior");
			}
			if (levelId == 3)
			{
				return TR.Value("challenge_chapter_level_king");
			}
			return TR.Value("challenge_chapter_level_normal");
		}

		// Token: 0x0600B161 RID: 45409 RVA: 0x00272F70 File Offset: 0x00271370
		public static string GetPreLevelName(int levelId)
		{
			if (levelId <= 1)
			{
				return TR.Value("challenge_chapter_level_normal");
			}
			if (levelId == 2)
			{
				return TR.Value("challenge_chapter_level_adventure");
			}
			if (levelId == 3)
			{
				return TR.Value("challenge_chapter_level_warrior");
			}
			return TR.Value("challenge_chapter_level_normal");
		}

		// Token: 0x0600B162 RID: 45410 RVA: 0x00272FC0 File Offset: 0x002713C0
		public static bool IsDungeonLock(int dungeonId)
		{
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonId);
			if (dungeonState == ComChapterDungeonUnit.eState.Locked)
			{
				return true;
			}
			if (dungeonState == ComChapterDungeonUnit.eState.Unlock)
			{
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
				if (tableItem != null && (int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.MinLevel)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B163 RID: 45411 RVA: 0x00273018 File Offset: 0x00271418
		public static List<ActivityDungeonSub> GetDailyUnitActivitySubs(int dungeonId)
		{
			ActivityDungeonTab tabByDungeonIDDefaultFirst = DataManager<ActivityDungeonDataManager>.GetInstance().GetTabByDungeonIDDefaultFirst(ActivityDungeonTable.eActivityType.Daily, dungeonId);
			if (tabByDungeonIDDefaultFirst != null)
			{
				return tabByDungeonIDDefaultFirst.subs;
			}
			return null;
		}

		// Token: 0x0600B164 RID: 45412 RVA: 0x00273040 File Offset: 0x00271440
		public static ActivityDungeonSub GetDungeonSubDataByDungeonId(int dungeonId, List<ActivityDungeonSub> activityDungeonSubList)
		{
			if (activityDungeonSubList == null || activityDungeonSubList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < activityDungeonSubList.Count; i++)
			{
				ActivityDungeonSub activityDungeonSub = activityDungeonSubList[i];
				if (activityDungeonSub != null)
				{
					if (activityDungeonSub.dungeonId == dungeonId)
					{
						return activityDungeonSub;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B165 RID: 45413 RVA: 0x0027309A File Offset: 0x0027149A
		public static void SortChapterIdListByLevel(List<int> chapterIdList)
		{
			if (chapterIdList == null || chapterIdList.Count <= 1)
			{
				return;
			}
			chapterIdList.Sort(delegate(int x, int y)
			{
				DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(x, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return -1;
				}
				DungeonTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(y, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return 1;
				}
				return tableItem.Level.CompareTo(tableItem2.Level);
			});
		}

		// Token: 0x0600B166 RID: 45414 RVA: 0x002730D2 File Offset: 0x002714D2
		public static void UpdateButtonState(Button button, UIGray gray, bool flag)
		{
			if (button != null)
			{
				button.interactable = flag;
			}
			if (gray != null)
			{
				gray.enabled = !flag;
			}
		}

		// Token: 0x0600B167 RID: 45415 RVA: 0x00273100 File Offset: 0x00271500
		public static int FloatToInt(float f)
		{
			int result;
			if (f > 0f)
			{
				result = (int)(f * 10f + 5f) / 10;
			}
			else if (f < 0f)
			{
				result = (int)(f * 10f - 5f) / 10;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600B168 RID: 45416 RVA: 0x00273158 File Offset: 0x00271558
		public static string GetDropDetailTitleName(ChallengeDropDetailType dropDetailType)
		{
			if (dropDetailType == ChallengeDropDetailType.RecommendItem)
			{
				return TR.Value("challenge_chapter_drop_recommend_item");
			}
			if (dropDetailType == ChallengeDropDetailType.BestItem)
			{
				return TR.Value("challenge_chapter_drop_best_item");
			}
			if (dropDetailType != ChallengeDropDetailType.OtherDropItem)
			{
				return TR.Value("challenge_chapter_drop_recommend_item");
			}
			return TR.Value("challenge_chapter_drop_other_drop_item");
		}

		// Token: 0x0600B169 RID: 45417 RVA: 0x002731AC File Offset: 0x002715AC
		public static bool IsItemValid(int itemId)
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty) != null;
		}

		// Token: 0x0600B16A RID: 45418 RVA: 0x002731D8 File Offset: 0x002715D8
		public static bool IsRecommendItemByProfession(int itemId, int jobTableId, int baseJobTableId)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.Occu.Count > 0)
			{
				for (int i = 0; i < tableItem.Occu.Count; i++)
				{
					if (tableItem.Occu[i] == 0)
					{
						return true;
					}
					if (tableItem.Occu[i] == jobTableId || tableItem.Occu[i] == baseJobTableId)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600B16B RID: 45419 RVA: 0x0027326C File Offset: 0x0027166C
		public static int GetPlayerBaseJobTableId()
		{
			int jobTableID = DataManager<PlayerBaseData>.GetInstance().JobTableID;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(jobTableID, string.Empty, string.Empty);
			if (tableItem != null && tableItem.JobType == 1)
			{
				return tableItem.prejob;
			}
			return jobTableID;
		}

		// Token: 0x0600B16C RID: 45420 RVA: 0x002732B4 File Offset: 0x002716B4
		public static void OnShowWeekHellPreTaskUnReceivedTip(int dungeonId)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("activity_week_hell_pre_task_unreceived"),
				IsShowNotify = false,
				LeftButtonText = TR.Value("activity_week_hell_pre_task_not_received"),
				RightButtonText = TR.Value("activity_week_hell_pre_task_yes_received"),
				OnRightButtonClickCallBack = delegate()
				{
					ChallengeUtility.OnReceiveWeekHellPreTask(dungeonId);
				}
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B16D RID: 45421 RVA: 0x00273328 File Offset: 0x00271728
		public static void OnReceiveWeekHellPreTask(int dungeonId)
		{
			ChallengeUtility.OnCloseChallengeMapFrame();
			int weekHellPreTaskId = DungeonUtility.GetWeekHellPreTaskId(dungeonId);
			if (weekHellPreTaskId <= 0)
			{
				Logger.LogErrorFormat("PreTaskId is not more than zero and weekHellDungeonId is {0}", new object[]
				{
					dungeonId
				});
				return;
			}
			DataManager<MissionManager>.GetInstance().AutoTraceTask(weekHellPreTaskId, null, null, false);
		}

		// Token: 0x0600B16E RID: 45422 RVA: 0x00273370 File Offset: 0x00271770
		public static ActivityDungeonTable GetActivityDungeonTableByDungeonId(int dungeonId)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ActivityDungeonTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ActivityDungeonTable activityDungeonTable = keyValuePair.Value as ActivityDungeonTable;
				if (activityDungeonTable != null && activityDungeonTable.DungeonID == dungeonId)
				{
					return activityDungeonTable;
				}
			}
			return null;
		}

		// Token: 0x0600B16F RID: 45423 RVA: 0x002733CA File Offset: 0x002717CA
		public static bool IsChallengeChapterCanSlider(ActivityDungeonSub activityDungeonSub)
		{
			return activityDungeonSub != null && !DungeonUtility.IsLimitTimeHellDungeon(activityDungeonSub.dungeonId) && !DungeonUtility.IsWeekHellEntryDungeon(activityDungeonSub.dungeonId) && activityDungeonSub.state == eActivityDungeonState.Start;
		}

		// Token: 0x0600B170 RID: 45424 RVA: 0x00273408 File Offset: 0x00271808
		public static List<int> GetDungeonModelCostDataList(DungeonModelTable.eType modelType)
		{
			List<int> result = null;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<DungeonModelTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					DungeonModelTable dungeonModelTable = keyValuePair.Value as DungeonModelTable;
					if (dungeonModelTable != null)
					{
						if (modelType == dungeonModelTable.Type)
						{
							FlatBufferArray<int> costItem = dungeonModelTable.CostItem;
							if (costItem != null)
							{
								result = costItem.ToList<int>();
							}
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B171 RID: 45425 RVA: 0x0027348C File Offset: 0x0027188C
		public static bool GetDungeonModelShowSpriteFlag(DungeonModelTable.eType modelType)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<DungeonModelTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					DungeonModelTable dungeonModelTable = keyValuePair.Value as DungeonModelTable;
					if (dungeonModelTable != null)
					{
						if (modelType == dungeonModelTable.Type)
						{
							return dungeonModelTable.IsShowSpriteConsume == 1;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B172 RID: 45426 RVA: 0x00273500 File Offset: 0x00271900
		public static DungeonModelTable GetDungeonModelTableOfTeamDuplication(bool isNormalTeamDuplication)
		{
			int id = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationDungeonModelIdWithNormalLevel;
			if (!isNormalTeamDuplication)
			{
				id = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationDungeonModelIdWith65Level;
			}
			return Singleton<TableManager>.GetInstance().GetTableItem<DungeonModelTable>(id, string.Empty, string.Empty);
		}
	}
}
