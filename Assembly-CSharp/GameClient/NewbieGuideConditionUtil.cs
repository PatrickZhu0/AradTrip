using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001066 RID: 4198
	public class NewbieGuideConditionUtil
	{
		// Token: 0x06009D8F RID: 40335 RVA: 0x001F0844 File Offset: 0x001EEC44
		private static bool _checkArgsLimit(int count, params int[] args)
		{
			if (args == null)
			{
				Logger.LogError("args is nil");
				return false;
			}
			return args.Length >= count;
		}

		// Token: 0x06009D90 RID: 40336 RVA: 0x001F0864 File Offset: 0x001EEC64
		public static bool CheckCondition(NewbieGuideTable.eNewbieGuideTask taskId, UIEvent uiEvent, NewbieConditionData data, eNewbieGuideCondition type, ref List<object> NeedSaveParamList, params int[] LimitArgs)
		{
			switch (type)
			{
			case eNewbieGuideCondition.Level:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					ushort level = DataManager<PlayerBaseData>.GetInstance().Level;
					return LimitArgs[0] <= (int)level;
				}
				break;
			case eNewbieGuideCondition.MaxLevel:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					ushort level2 = DataManager<PlayerBaseData>.GetInstance().Level;
					return (int)level2 <= LimitArgs[0];
				}
				break;
			case eNewbieGuideCondition.SceneLogin:
				return Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemLogin;
			case eNewbieGuideCondition.SceneTown:
				return Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemTown && !Singleton<ClientSystemManager>.instance.bIsInPkWaitingRoom;
			case eNewbieGuideCondition.ScenePkWaitingRoom:
				return Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemTown && Singleton<ClientSystemManager>.instance.bIsInPkWaitingRoom;
			case eNewbieGuideCondition.SceneBattle:
				return Singleton<ClientSystemManager>.instance.CurrentSystem is ClientSystemBattle;
			case eNewbieGuideCondition.BattleInitFinished:
				if (BattleMain.instance != null)
				{
					IDungeonManager dungeonManager = BattleMain.instance.GetDungeonManager();
					if (dungeonManager != null)
					{
						BeScene beScene = dungeonManager.GetBeScene();
						if (beScene != null && beScene.state == BeSceneState.onFight)
						{
							return true;
						}
					}
				}
				break;
			case eNewbieGuideCondition.ClientSystemTownFrameOpen:
				return Singleton<ClientSystemManager>.instance.IsFrameOpen<ClientSystemTownFrame>(null);
			case eNewbieGuideCondition.ChapterChooseFrameOpen:
				return Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterSelectFrame>(null);
			case eNewbieGuideCondition.QuickEquipFrameOpen:
				return Singleton<ClientSystemManager>.instance.IsFrameOpen<EquipmentChangedFrame>(null);
			case eNewbieGuideCondition.SpecificEvent:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					return LimitArgs[0] == (int)uiEvent.EventID;
				}
				break;
			case eNewbieGuideCondition.MainFrameMutex:
			{
				ClientSystemTownFrame clientSystemTownFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(ClientSystemTownFrame)) as ClientSystemTownFrame;
				if (clientSystemTownFrame != null)
				{
					if (!clientSystemTownFrame.IsHidden())
					{
						if (Singleton<ClientSystemManager>.GetInstance().IsMainPrefabTop())
						{
							return true;
						}
					}
				}
				break;
			}
			case eNewbieGuideCondition.EquipmentInPackage:
			{
				List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
				if (itemsByPackageType != null && itemsByPackageType.Count > 0 && NeedSaveParamList != null)
				{
					List<ItemData> list = new List<ItemData>();
					for (int i = 0; i < itemsByPackageType.Count; i++)
					{
						ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType[i]);
						if (item != null)
						{
							if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= item.LevelLimit)
							{
								if (taskId != NewbieGuideTable.eNewbieGuideTask.ForgeGuide || item.EquipWearSlotType == EEquipWearSlotType.EquipWeapon)
								{
									if (item.IsOccupationFit())
									{
										if (item.Quality >= ItemTable.eColor.BLUE)
										{
											list.Add(item);
										}
									}
								}
							}
						}
					}
					for (int j = 0; j < list.Count; j++)
					{
						for (int k = j + 1; k < list.Count; k++)
						{
							if (list[k].Quality > list[j].Quality)
							{
								ItemData value = list[j];
								list[j] = list[k];
								list[k] = value;
							}
						}
					}
					if (list.Count > 0)
					{
						NeedSaveParamList.Add(list[0].GUID);
						return true;
					}
				}
				break;
			}
			case eNewbieGuideCondition.AchievementFinished:
			{
				List<MissionManager.SingleMissionInfo> taskByType = DataManager<MissionManager>.GetInstance().GetTaskByType(MissionTable.eTaskType.TT_ACHIEVEMENT, TaskStatus.TASK_FINISHED, false);
				if (taskByType != null && taskByType.Count > 0 && NeedSaveParamList != null)
				{
					NeedSaveParamList.Add(taskByType[0].taskID);
					return true;
				}
				break;
			}
			case eNewbieGuideCondition.SignInFinished:
			{
				ActiveManager.ActiveData activeData = DataManager<ActiveManager>.GetInstance().GetActiveData(3000);
				if (activeData != null && NeedSaveParamList != null)
				{
					if (activeData.akChildItems != null && activeData.akChildItems.Count > 0)
					{
						for (int l = 0; l < activeData.akChildItems.Count; l++)
						{
							if (activeData.akChildItems[l].status == 2)
							{
								NeedSaveParamList.Add(activeData.akChildItems[l].ID);
								return true;
							}
						}
					}
				}
				break;
			}
			case eNewbieGuideCondition.BranchMissionAccept:
			{
				List<MissionManager.SingleMissionInfo> taskByType2 = DataManager<MissionManager>.GetInstance().GetTaskByType(MissionTable.eTaskType.TT_BRANCH, TaskStatus.TASK_INIT, false);
				if (taskByType2 != null && taskByType2.Count > 0 && NeedSaveParamList != null)
				{
					NeedSaveParamList.Add(taskByType2[0].taskID);
					return true;
				}
				break;
			}
			case eNewbieGuideCondition.DailyMissionFinished:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					int num = LimitArgs[0];
					List<MissionManager.SingleMissionInfo> taskByType3 = DataManager<MissionManager>.GetInstance().GetTaskByType(MissionTable.eTaskType.TT_DIALY, TaskStatus.TASK_FINISHED, false);
					if (taskByType3 != null && taskByType3.Count > 0)
					{
						for (int m = 0; m < taskByType3.Count; m++)
						{
							if (taskByType3[m].missionItem.SubType == MissionTable.eSubType.Daily_Task)
							{
								if (taskByType3[m].missionItem.ID == num)
								{
									return true;
								}
							}
						}
					}
				}
				break;
			case eNewbieGuideCondition.DungeonID:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					int dungeonId = DataManager<BattleDataManager>.GetInstance().BattleInfo.dungeonId;
					return LimitArgs[0] == dungeonId;
				}
				break;
			case eNewbieGuideCondition.DungeonAreaID:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					IDungeonManager dungeonManager2 = BattleMain.instance.GetDungeonManager();
					int num2 = dungeonManager2.GetDungeonDataManager().CurrentAreaID();
					return num2 == LimitArgs[0];
				}
				break;
			case eNewbieGuideCondition.DungeonStartTime:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					int num3 = BattleMain.instance.GetDungeonStatistics().AllFightTime(false);
					return num3 >= LimitArgs[0];
				}
				break;
			case eNewbieGuideCondition.ChangeEquipmentExist:
			{
				List<ulong> itemsByPackageType2 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
				if (itemsByPackageType2 != null && itemsByPackageType2.Count > 0 && NeedSaveParamList != null)
				{
					for (int n = 0; n < 102; n++)
					{
						if (n == 1)
						{
							ulong wearEquipBySlotType = DataManager<ItemDataManager>.GetInstance().GetWearEquipBySlotType((EEquipWearSlotType)n);
							if (wearEquipBySlotType == 0UL)
							{
								break;
							}
							bool flag = false;
							for (int num4 = 0; num4 < itemsByPackageType2.Count; num4++)
							{
								ItemData item2 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType2[num4]);
								if (item2 != null)
								{
									if (item2.EquipWearSlotType == (EEquipWearSlotType)n)
									{
										if (item2.IsOccupationFit())
										{
											if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= item2.LevelLimit)
											{
												if (item2.IsBetterThanEquip())
												{
													if (item2.Quality >= ItemTable.eColor.PURPLE)
													{
														NeedSaveParamList.Add(item2.GUID);
														NeedSaveParamList.Add(wearEquipBySlotType);
														flag = true;
														break;
													}
												}
											}
										}
									}
								}
							}
							if (flag)
							{
								return true;
							}
						}
					}
				}
				break;
			}
			case eNewbieGuideCondition.LearnBufferSkill:
				if (NeedSaveParamList != null)
				{
					List<Skill> curSkillList = DataManager<SkillDataManager>.GetInstance().GetCurSkillList(false, SkillSystemSourceType.None);
					for (int num5 = 0; num5 < curSkillList.Count; num5++)
					{
						SkillTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SkillTable>((int)curSkillList[num5].id, string.Empty, string.Empty);
						if (tableItem != null && tableItem.IsBuff == 1)
						{
							NeedSaveParamList.Add((int)curSkillList[num5].id);
							return true;
						}
					}
				}
				break;
			case eNewbieGuideCondition.IsDungeon:
				if (BattleMain.instance != null && BattleMain.battleType == BattleType.Dungeon)
				{
					return true;
				}
				break;
			case eNewbieGuideCondition.NewbieGuideID:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					NewbieGuideTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<NewbieGuideTable>(LimitArgs[0], string.Empty, string.Empty);
					if (tableItem2 == null || tableItem2.IsOpen == 0)
					{
						return false;
					}
					if (tableItem2.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_FORCE && tableItem2.Order <= DataManager<PlayerBaseData>.GetInstance().NewbieGuideCurSaveOrder)
					{
						return true;
					}
					if (tableItem2.NewbieGuideType == NewbieGuideTable.eNewbieGuideType.NGT_WEAK)
					{
						for (int num6 = 0; num6 < DataManager<PlayerBaseData>.GetInstance().NewbieGuideWeakGuideList.Count; num6++)
						{
							if (DataManager<PlayerBaseData>.GetInstance().NewbieGuideWeakGuideList[num6] == LimitArgs[0])
							{
								return true;
							}
						}
						return false;
					}
				}
				break;
			case eNewbieGuideCondition.AddNewMissionID:
				if (uiEvent.EventID == EUIEventID.AddNewMission)
				{
					if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs) && LimitArgs[0] == (int)uiEvent.Param1)
					{
						return true;
					}
				}
				break;
			case eNewbieGuideCondition.FinishedMissionID:
				if (uiEvent.EventID == EUIEventID.MissionRewardFrameClose || uiEvent.EventID == EUIEventID.LevelChanged)
				{
					if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs) && LimitArgs[0] == DataManager<PlayerBaseData>.GetInstance().GuideFinishMission)
					{
						return true;
					}
				}
				break;
			case eNewbieGuideCondition.ChangedJob:
			{
				JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(DataManager<PlayerBaseData>.GetInstance().JobTableID, string.Empty, string.Empty);
				if (tableItem3 != null)
				{
					if (tableItem3.JobType == 1)
					{
						return true;
					}
				}
				break;
			}
			case eNewbieGuideCondition.FinishTalkDialog:
				if (uiEvent.EventID == EUIEventID.FinishTalkDialog)
				{
					if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs) && LimitArgs[0] == (int)uiEvent.Param1)
					{
						return true;
					}
				}
				break;
			case eNewbieGuideCondition.HaveWhiteEquipment:
				return Singleton<NewbieGuideManager>.GetInstance().IsHavingWhiteGuide();
			case eNewbieGuideCondition.MagicBoxGuide:
			{
				List<ulong> itemsByPackageType3 = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Consumable);
				if (itemsByPackageType3 != null && itemsByPackageType3.Count > 0 && NeedSaveParamList != null)
				{
					List<ItemData> list2 = new List<ItemData>();
					for (int num7 = 0; num7 < itemsByPackageType3.Count; num7++)
					{
						ItemData item3 = DataManager<ItemDataManager>.GetInstance().GetItem(itemsByPackageType3[num7]);
						if (item3 != null)
						{
							if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= item3.LevelLimit)
							{
								if (item3.SubType == 55)
								{
									NeedSaveParamList.Add(item3.GUID);
									break;
								}
							}
						}
					}
					return true;
				}
				break;
			}
			case eNewbieGuideCondition.SceneID:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					int areaId = DataManager<BattleDataManager>.GetInstance().BattleInfo.areaId;
					return LimitArgs[0] == areaId;
				}
				break;
			case eNewbieGuideCondition.OnMission:
				if (NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					return DataManager<MissionManager>.GetInstance().IsAcceptMission((uint)LimitArgs[0]);
				}
				break;
			case eNewbieGuideCondition.ChapterChooseFrameOpenHaveParameter:
				if (!NewbieGuideConditionUtil._checkArgsLimit(1, LimitArgs))
				{
					return false;
				}
				if (Singleton<ClientSystemManager>.instance.IsFrameOpen<ChapterSelectFrame>(null))
				{
					ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
					return chapterSelectFrame != null && chapterSelectFrame._GetChapterIndex() == LimitArgs[0];
				}
				return false;
			case eNewbieGuideCondition.UserDefine:
				if (data != null && data.mComditionFunc != null)
				{
					return data.mComditionFunc();
				}
				break;
			}
			return false;
		}
	}
}
