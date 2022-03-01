using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001216 RID: 4630
	public static class ChampionshipUtility
	{
		// Token: 0x0600B1C3 RID: 45507 RVA: 0x00274F4C File Offset: 0x0027334C
		public static void OnCloseChampionshipEntranceFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipEntranceFrame>(null, false);
		}

		// Token: 0x0600B1C4 RID: 45508 RVA: 0x00274F5A File Offset: 0x0027335A
		public static void OnOpenChampionshipEntranceFrame()
		{
			ChampionshipUtility.OnCloseChampionshipEntranceFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipEntranceFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B1C5 RID: 45509 RVA: 0x00274F73 File Offset: 0x00273373
		public static void OnCloseChampionshipBigRewardPreviewFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipBigRewardPreviewFrame>(null, false);
		}

		// Token: 0x0600B1C6 RID: 45510 RVA: 0x00274F81 File Offset: 0x00273381
		public static void OnOpenChampionshipBigRewardPreviewFrame(int bigRewardScheduleId)
		{
			ChampionshipUtility.OnCloseChampionshipBigRewardPreviewFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipBigRewardPreviewFrame>(FrameLayer.Middle, bigRewardScheduleId, string.Empty);
		}

		// Token: 0x0600B1C7 RID: 45511 RVA: 0x00274F9F File Offset: 0x0027339F
		public static void OnCloseChampionshipMainFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipMainFrame>(null, false);
		}

		// Token: 0x0600B1C8 RID: 45512 RVA: 0x00274FAD File Offset: 0x002733AD
		public static void OnOpenChampionshipMainFrame()
		{
			ChampionshipUtility.OnCloseChampionshipMainFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipMainFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B1C9 RID: 45513 RVA: 0x00274FC6 File Offset: 0x002733C6
		public static void OnCloseChampionshipScoreRankFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipScoreRankFrame>(null, false);
		}

		// Token: 0x0600B1CA RID: 45514 RVA: 0x00274FD4 File Offset: 0x002733D4
		public static void OnOpenChampionshipScoreRankFrame(int scheduleId, bool isShowInClientSystemTown = false)
		{
			ChampionshipUtility.OnCloseChampionshipScoreRankFrame();
			ChampionshipScoreScheduleDataModel userData = new ChampionshipScoreScheduleDataModel
			{
				ScheduleId = scheduleId,
				IsShowInClientSystemTown = isShowInClientSystemTown
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipScoreRankFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B1CB RID: 45515 RVA: 0x0027500E File Offset: 0x0027340E
		public static void OnCloseChampionshipScoreFightRecordFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipScoreFightRecordFrame>(null, false);
		}

		// Token: 0x0600B1CC RID: 45516 RVA: 0x0027501C File Offset: 0x0027341C
		public static void OnOpenChampionshipScoreFightRecordFrame()
		{
			ChampionshipUtility.OnCloseChampionshipScoreFightRecordFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipScoreFightRecordFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B1CD RID: 45517 RVA: 0x00275035 File Offset: 0x00273435
		public static void OnCloseChampionshipSeaReliveFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipSeaReliveFrame>(null, false);
		}

		// Token: 0x0600B1CE RID: 45518 RVA: 0x00275043 File Offset: 0x00273443
		public static void OnOpenChampionshipSeaReliveFrame()
		{
			ChampionshipUtility.OnCloseChampionshipSeaReliveFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipSeaReliveFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B1CF RID: 45519 RVA: 0x0027505C File Offset: 0x0027345C
		public static void OnCloseChampionshipGuessFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipGuessFrame>(null, false);
		}

		// Token: 0x0600B1D0 RID: 45520 RVA: 0x0027506A File Offset: 0x0027346A
		public static void OnOpenChampionshipGuessFrame()
		{
			ChampionshipUtility.OnCloseChampionshipGuessFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipGuessFrame>(FrameLayer.Middle, null, string.Empty);
			DataManager<ChampionshipDataManager>.GetInstance().IsShowGuessBetRedPoint = false;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveChampionshipUpdateGuessBetRedPointMessage, null, null, null, null);
		}

		// Token: 0x0600B1D1 RID: 45521 RVA: 0x002750A1 File Offset: 0x002734A1
		public static bool IsChampionshipGuessFrameOpen()
		{
			return Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChampionshipGuessFrame>(null);
		}

		// Token: 0x0600B1D2 RID: 45522 RVA: 0x002750B6 File Offset: 0x002734B6
		public static void OnCloseChampionshipGuessBetFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipGuessBetFrame>(null, false);
		}

		// Token: 0x0600B1D3 RID: 45523 RVA: 0x002750C4 File Offset: 0x002734C4
		public static void OnOpenChampionshipGuessBetFrame(uint guessProjectId, ulong guessOptionId)
		{
			ChampionshipUtility.OnCloseChampionshipGuessBetFrame();
			ChampionshipGuessBetDataModel championshipGuessBetDataModel = new ChampionshipGuessBetDataModel();
			championshipGuessBetDataModel.ProjectId = guessProjectId;
			championshipGuessBetDataModel.GuessOptionId = guessOptionId;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipGuessBetFrame>(FrameLayer.Middle, championshipGuessBetDataModel, string.Empty);
		}

		// Token: 0x0600B1D4 RID: 45524 RVA: 0x002750FC File Offset: 0x002734FC
		public static void OnCloseChampionshipGuessRecordFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipGuessRecordFrame>(null, false);
		}

		// Token: 0x0600B1D5 RID: 45525 RVA: 0x0027510A File Offset: 0x0027350A
		public static void OnOpenChampionshipGuessRecordFrame()
		{
			ChampionshipUtility.OnCloseChampionshipGuessRecordFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipGuessRecordFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B1D6 RID: 45526 RVA: 0x00275123 File Offset: 0x00273523
		public static void OnCloseChampionshipFightRaceFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChampionshipFightRaceFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipFightRaceFrame>(null, false);
			}
		}

		// Token: 0x0600B1D7 RID: 45527 RVA: 0x00275141 File Offset: 0x00273541
		public static void OnOpenChampionshipFightRaceFrame(int scheduleId)
		{
			ChampionshipUtility.OnCloseChampionshipFightRaceFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipFightRaceFrame>(FrameLayer.Middle, scheduleId, string.Empty);
		}

		// Token: 0x0600B1D8 RID: 45528 RVA: 0x0027515F File Offset: 0x0027355F
		public static void OnCloseChampionshipFightDetailFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChampionshipFightDetailFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChampionshipFightDetailFrame>(null, false);
			}
		}

		// Token: 0x0600B1D9 RID: 45529 RVA: 0x0027517D File Offset: 0x0027357D
		public static void OnOpenChampionshipFightDetailFrame(int fightRaceId)
		{
			ChampionshipUtility.OnCloseChampionshipFightDetailFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChampionshipFightDetailFrame>(FrameLayer.Middle, fightRaceId, string.Empty);
		}

		// Token: 0x0600B1DA RID: 45530 RVA: 0x0027519B File Offset: 0x0027359B
		private static void OnCloseFrameByLeaveChampionshipScene()
		{
			ChampionshipUtility.OnCloseChampionshipScoreFightRecordFrame();
			ChampionshipUtility.OnCloseChampionshipScoreRankFrame();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PkMenuFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkMenuFrame>(null, false);
			}
		}

		// Token: 0x0600B1DB RID: 45531 RVA: 0x002751C3 File Offset: 0x002735C3
		public static void SwitchToBirthCitySceneInClientSystemTown(bool isKickOffFromChampionshipScore = false)
		{
			ChampionshipUtility.OnCloseFrameByLeaveChampionshipScene();
			CommonUtility.SwitchToBirthCitySceneInClientSystemTown(null);
		}

		// Token: 0x0600B1DC RID: 45532 RVA: 0x002751D0 File Offset: 0x002735D0
		public static void OnOpenFrameByKickOffFromChampionScene()
		{
			int isShowChampionshipScoreScheduleId = DataManager<ChampionshipDataManager>.GetInstance().IsShowChampionshipScoreScheduleId;
			if (isShowChampionshipScoreScheduleId <= 0)
			{
				return;
			}
			ChampionshipUtility.OnOpenChampionshipScoreRankFrame(isShowChampionshipScoreScheduleId, true);
			DataManager<ChampionshipDataManager>.GetInstance().IsShowChampionshipScoreScheduleId = 0;
		}

		// Token: 0x0600B1DD RID: 45533 RVA: 0x00275204 File Offset: 0x00273604
		public static void OnOpenChampionshipGuessShop()
		{
			int shopId = 37;
			DataManager<AccountShopDataManager>.GetInstance().OpenAccountShop(shopId, 0, 0, -1);
		}

		// Token: 0x0600B1DE RID: 45534 RVA: 0x00275224 File Offset: 0x00273624
		public static List<ChampionshipScoreFightRecordDataModel> GetChampionshipAllScoreFightRecordList()
		{
			return DataManager<ChampionshipDataManager>.GetInstance().ScoreFightRecordDataModelList;
		}

		// Token: 0x0600B1DF RID: 45535 RVA: 0x00275240 File Offset: 0x00273640
		public static List<ChampionshipScoreFightRecordDataModel> GetChampionshipSelfScoreFightRecordList()
		{
			List<ChampionshipScoreFightRecordDataModel> scoreFightRecordDataModelList = DataManager<ChampionshipDataManager>.GetInstance().ScoreFightRecordDataModelList;
			List<ChampionshipScoreFightRecordDataModel> list = new List<ChampionshipScoreFightRecordDataModel>();
			for (int i = 0; i < scoreFightRecordDataModelList.Count; i++)
			{
				ChampionshipScoreFightRecordDataModel championshipScoreFightRecordDataModel = scoreFightRecordDataModelList[i];
				if (championshipScoreFightRecordDataModel != null)
				{
					if (championshipScoreFightRecordDataModel.IsSelfFightRecord)
					{
						list.Add(championshipScoreFightRecordDataModel);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B1E0 RID: 45536 RVA: 0x002752A0 File Offset: 0x002736A0
		public static void UpdateChampionshipStatus(ChampionStatusInfo championshipStatusInfo, uint selfStatus, out int championshipScheduleId, out bool isChampionshipScheduleOpenInTime, out bool isChampionshipScheduleOpenToPlayer, out bool isChampionshipScheduleAlreadySignUp, out bool isChampionshipScheduleSelfAlreadyAdvance)
		{
			championshipScheduleId = 0;
			isChampionshipScheduleOpenInTime = false;
			isChampionshipScheduleOpenToPlayer = false;
			isChampionshipScheduleAlreadySignUp = false;
			isChampionshipScheduleSelfAlreadyAdvance = false;
			if (championshipStatusInfo == null)
			{
				return;
			}
			ChampionStatus status = (ChampionStatus)championshipStatusInfo.status;
			if (status == ChampionStatus.CS_ENROLL)
			{
				championshipScheduleId = 1;
				isChampionshipScheduleOpenInTime = true;
				isChampionshipScheduleOpenToPlayer = true;
				if (selfStatus > (uint)status)
				{
					isChampionshipScheduleAlreadySignUp = true;
				}
				else
				{
					isChampionshipScheduleAlreadySignUp = false;
				}
				return;
			}
			switch (status)
			{
			case ChampionStatus.CS_SEA_SELECT_PRE:
				break;
			case ChampionStatus.CS_RE_SEA_SELECT_PRE:
				goto IL_EC;
			case ChampionStatus.CS_64_SELECT_PRE:
				goto IL_F4;
			case ChampionStatus.CS_16_SELECT_PRE:
				goto IL_FC;
			case ChampionStatus.CS_8_SELECT_PRE:
				goto IL_104;
			case ChampionStatus.CS_4_SELECT_PRE:
				goto IL_10C;
			case ChampionStatus.CS_2_SELECT_PRE:
				goto IL_114;
			case ChampionStatus.CS_1_SELECT_PRE:
				goto IL_11C;
			default:
				switch (status)
				{
				case ChampionStatus.CS_SEA_SELECT_PREPARE:
					break;
				case ChampionStatus.CS_RE_SEA_SELECT_PREPARE:
					goto IL_EC;
				case ChampionStatus.CS_64_SELECT_PREPARE:
					goto IL_F4;
				case ChampionStatus.CS_16_SELECT_PREPARE:
					goto IL_FC;
				case ChampionStatus.CS_8_SELECT_PREPARE:
					goto IL_104;
				case ChampionStatus.CS_4_SELECT_PREPARE:
					goto IL_10C;
				case ChampionStatus.CS_2_SELECT_PREPARE:
					goto IL_114;
				case ChampionStatus.CS_1_SELECT_PREPARE:
					goto IL_11C;
				default:
					switch (status)
					{
					case ChampionStatus.CS_SEA_SELECT_BATTLE:
						break;
					case ChampionStatus.CS_RE_SEA_SELECT_BATTLE:
						goto IL_EC;
					case ChampionStatus.CS_64_SELECT_BATTLE:
						goto IL_F4;
					case ChampionStatus.CS_16_SELECT_BATTLE:
						goto IL_FC;
					case ChampionStatus.CS_8_SELECT_BATTLE:
						goto IL_104;
					case ChampionStatus.CS_4_SELECT_BATTLE:
						goto IL_10C;
					case ChampionStatus.CS_2_SELECT_BATTLE:
						goto IL_114;
					case ChampionStatus.CS_1_SELECT_BATTLE:
						goto IL_11C;
					default:
						goto IL_133;
					}
					break;
				}
				break;
			case ChampionStatus.CS_END_SHOW:
				championshipScheduleId = 9;
				goto IL_133;
			}
			championshipScheduleId = 2;
			goto IL_133;
			IL_EC:
			championshipScheduleId = 3;
			goto IL_133;
			IL_F4:
			championshipScheduleId = 4;
			goto IL_133;
			IL_FC:
			championshipScheduleId = 5;
			goto IL_133;
			IL_104:
			championshipScheduleId = 6;
			goto IL_133;
			IL_10C:
			championshipScheduleId = 7;
			goto IL_133;
			IL_114:
			championshipScheduleId = 8;
			goto IL_133;
			IL_11C:
			championshipScheduleId = 9;
			IL_133:
			if (status == ChampionStatus.CS_END_SHOW)
			{
				isChampionshipScheduleOpenInTime = false;
				isChampionshipScheduleOpenToPlayer = false;
				isChampionshipScheduleSelfAlreadyAdvance = false;
				return;
			}
			isChampionshipScheduleOpenInTime = true;
			if (status >= ChampionStatus.CS_PRE_BEGIN && status <= ChampionStatus.CS_PRE_END)
			{
				isChampionshipScheduleOpenInTime = false;
			}
			isChampionshipScheduleSelfAlreadyAdvance = false;
			int championStatusLogicValue = ChampionshipUtility.GetChampionStatusLogicValue(status);
			int championStatusLogicValue2 = ChampionshipUtility.GetChampionStatusLogicValue((ChampionStatus)selfStatus);
			if (championStatusLogicValue2 > championStatusLogicValue)
			{
				isChampionshipScheduleSelfAlreadyAdvance = true;
			}
			isChampionshipScheduleOpenToPlayer = false;
			if ((status == ChampionStatus.CS_SEA_SELECT_PREPARE || status == ChampionStatus.CS_SEA_SELECT_BATTLE) && selfStatus == 1U)
			{
				isChampionshipScheduleOpenToPlayer = true;
				return;
			}
			if (championStatusLogicValue2 >= championStatusLogicValue)
			{
				isChampionshipScheduleOpenToPlayer = true;
				return;
			}
		}

		// Token: 0x0600B1E1 RID: 45537 RVA: 0x00275454 File Offset: 0x00273854
		public static int GetChampionStatusLogicValue(ChampionStatus status)
		{
			int result = 0;
			if (status >= ChampionStatus.CS_PREPARE_BEGIN && status <= ChampionStatus.CS_PREPARE_END)
			{
				result = status - ChampionStatus.CS_PREPARE_BEGIN;
			}
			else if (status >= ChampionStatus.CS_BATTLE_BEGIN && status <= ChampionStatus.CS_BATTLE_END)
			{
				result = status - ChampionStatus.CS_BATTLE_BEGIN;
			}
			else if (status >= ChampionStatus.CS_PRE_BEGIN && status <= ChampionStatus.CS_PRE_END)
			{
				result = status - ChampionStatus.CS_PRE_BEGIN;
			}
			return result;
		}

		// Token: 0x0600B1E2 RID: 45538 RVA: 0x002754B0 File Offset: 0x002738B0
		public static bool IsInChampionshipSchedulePreStatus()
		{
			if (DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo == null)
			{
				return false;
			}
			ChampionStatus status = (ChampionStatus)DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo.status;
			return status >= ChampionStatus.CS_PRE_BEGIN && status <= ChampionStatus.CS_PRE_END;
		}

		// Token: 0x0600B1E3 RID: 45539 RVA: 0x002754F4 File Offset: 0x002738F4
		public static bool IsInChampionshipSchedulePrepareStatus()
		{
			ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
			if (championshipStatusInfo == null)
			{
				return false;
			}
			ChampionStatus status = (ChampionStatus)championshipStatusInfo.status;
			return status >= ChampionStatus.CS_PREPARE_BEGIN && status <= ChampionStatus.CS_PREPARE_END;
		}

		// Token: 0x0600B1E4 RID: 45540 RVA: 0x00275530 File Offset: 0x00273930
		public static bool IsInChampionshipScheduleFightStatus()
		{
			ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
			if (championshipStatusInfo == null)
			{
				return false;
			}
			ChampionStatus status = (ChampionStatus)championshipStatusInfo.status;
			return status >= ChampionStatus.CS_BATTLE_BEGIN && status <= ChampionStatus.CS_BATTLE_END;
		}

		// Token: 0x0600B1E5 RID: 45541 RVA: 0x0027556C File Offset: 0x0027396C
		public static bool IsInChampionshipEndShow()
		{
			ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
			if (championshipStatusInfo == null)
			{
				return false;
			}
			ChampionStatus status = (ChampionStatus)championshipStatusInfo.status;
			return status == ChampionStatus.CS_END_SHOW;
		}

		// Token: 0x0600B1E6 RID: 45542 RVA: 0x002755A0 File Offset: 0x002739A0
		public static uint GetChampionshipScheduleEndTimeStamp()
		{
			ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
			if (championshipStatusInfo == null)
			{
				return 0U;
			}
			return championshipStatusInfo.endTime;
		}

		// Token: 0x0600B1E7 RID: 45543 RVA: 0x002755C6 File Offset: 0x002739C6
		public static bool IsInChampionshipScheduleScoreTime(ChampionshipScheduleTable scheduleTable)
		{
			return scheduleTable != null && (scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.ReSea_Select || scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.SixtyFour_Select || scheduleTable.ScheduleType == ChampionshipScheduleTable.eScheduleType.Sixteen_Select);
		}

		// Token: 0x0600B1E8 RID: 45544 RVA: 0x002755F8 File Offset: 0x002739F8
		public static int GetSceneIdByChampionshipScheduleId(int scheduleId)
		{
			if (scheduleId == 2)
			{
				return 8001;
			}
			if (scheduleId == 3)
			{
				return 8002;
			}
			if (scheduleId == 4)
			{
				return 8003;
			}
			if (scheduleId == 5)
			{
				return 8004;
			}
			if (scheduleId == 6)
			{
				return 8005;
			}
			if (scheduleId == 7)
			{
				return 8006;
			}
			if (scheduleId == 8)
			{
				return 8007;
			}
			if (scheduleId == 9)
			{
				return 8008;
			}
			return 8001;
		}

		// Token: 0x0600B1E9 RID: 45545 RVA: 0x00275674 File Offset: 0x00273A74
		public static bool IsChampionshipAlreadyFailedInSeaSelectSchedule()
		{
			ChampionshipSelfSeaFightResultDataModel selfSeaFightResultDataModel = DataManager<ChampionshipDataManager>.GetInstance().SelfSeaFightResultDataModel;
			return selfSeaFightResultDataModel != null && selfSeaFightResultDataModel.LoseNumber > 0 && (selfSeaFightResultDataModel.LoseNumber != 1 || selfSeaFightResultDataModel.ReliveStatus != ChampionshipReliveStatus.AlreadyRelive);
		}

		// Token: 0x0600B1EA RID: 45546 RVA: 0x002756C0 File Offset: 0x00273AC0
		public static ChampionshipScoreRankDataModel GetSelfScoreRankDataModel()
		{
			return new ChampionshipScoreRankDataModel
			{
				PlayerGuid = DataManager<PlayerBaseData>.GetInstance().RoleID,
				Name = DataManager<PlayerBaseData>.GetInstance().Name,
				Score = 0U,
				RankIndex = 0,
				ServerName = ClientApplication.adminServer.name
			};
		}

		// Token: 0x0600B1EB RID: 45547 RVA: 0x00275714 File Offset: 0x00273B14
		public static ChampionshipTopPlayerDataModel GetTop16PlayerDataModel(ChampionTop16Player top16Player)
		{
			if (top16Player == null)
			{
				return null;
			}
			return new ChampionshipTopPlayerDataModel
			{
				PlayerGuid = top16Player.roleID,
				Position = top16Player.pos,
				Name = top16Player.name,
				ProfessionId = (uint)top16Player.occu,
				PlayerAvatar = top16Player.avatar,
				ServerName = top16Player.server,
				ZoneId = top16Player.zoneID
			};
		}

		// Token: 0x0600B1EC RID: 45548 RVA: 0x00275784 File Offset: 0x00273B84
		public static ChampionshipScoreRankDataModel GetScoreRankDataModel(RankRole rankRole)
		{
			if (rankRole == null)
			{
				return null;
			}
			return new ChampionshipScoreRankDataModel
			{
				PlayerGuid = rankRole.roleID,
				Name = rankRole.name,
				Score = rankRole.score,
				ServerName = rankRole.server
			};
		}

		// Token: 0x0600B1ED RID: 45549 RVA: 0x002757D0 File Offset: 0x00273BD0
		public static ChampionshipScoreFightRecordDataModel GetScoreFightRecordDataModel(ScoreBattleRecord scoreBattleRecord)
		{
			if (scoreBattleRecord == null)
			{
				return null;
			}
			ChampionshipScoreFightRecordDataModel championshipScoreFightRecordDataModel = new ChampionshipScoreFightRecordDataModel();
			championshipScoreFightRecordDataModel.FirstPlayerGuid = scoreBattleRecord.roleIDA;
			championshipScoreFightRecordDataModel.FirstPlayerName = scoreBattleRecord.nameA;
			championshipScoreFightRecordDataModel.SecondPlayerGuid = scoreBattleRecord.roleIDB;
			championshipScoreFightRecordDataModel.SecondPlayerName = scoreBattleRecord.nameB;
			if (scoreBattleRecord.roleIDB == 0UL)
			{
				championshipScoreFightRecordDataModel.IsNullTurnFlag = true;
			}
			else
			{
				championshipScoreFightRecordDataModel.IsNullTurnFlag = false;
			}
			championshipScoreFightRecordDataModel.IsWin = (scoreBattleRecord.result == 1);
			if (CommonUtility.IsSelfPlayerByPlayerGuid(scoreBattleRecord.roleIDA) || CommonUtility.IsSelfPlayerByPlayerGuid(scoreBattleRecord.roleIDB))
			{
				championshipScoreFightRecordDataModel.IsSelfFightRecord = true;
			}
			else
			{
				championshipScoreFightRecordDataModel.IsSelfFightRecord = false;
			}
			return championshipScoreFightRecordDataModel;
		}

		// Token: 0x0600B1EE RID: 45550 RVA: 0x00275888 File Offset: 0x00273C88
		public static ChampionshipKnockoutPlayerDataModel CreateKnockOutPlayerDataModel(KnockoutPlayer knockoutPlayer)
		{
			if (knockoutPlayer == null)
			{
				return null;
			}
			return new ChampionshipKnockoutPlayerDataModel
			{
				Guid = knockoutPlayer.roleID,
				Name = knockoutPlayer.name,
				ProfessionId = (uint)knockoutPlayer.occu,
				Server = knockoutPlayer.server,
				Score = knockoutPlayer.score
			};
		}

		// Token: 0x0600B1EF RID: 45551 RVA: 0x002758E0 File Offset: 0x00273CE0
		public static ChampionshipFightDetailRecordDataModel CreateFightDetailRecordDataModel(ChampionBattleRecord battleRecord)
		{
			if (battleRecord == null)
			{
				return null;
			}
			return new ChampionshipFightDetailRecordDataModel
			{
				FightOrder = battleRecord.order,
				RaceId = battleRecord.raceID,
				WinnerGuid = battleRecord.winner,
				IsEndFlag = (battleRecord.isEnd == 1),
				IsStartFlag = true
			};
		}

		// Token: 0x0600B1F0 RID: 45552 RVA: 0x00275940 File Offset: 0x00273D40
		public static ChampionshipFightDetailRecordDataModel CreateFightDetailRecordDataModelByIndex(int index)
		{
			return new ChampionshipFightDetailRecordDataModel
			{
				FightOrder = (uint)index,
				IsStartFlag = false
			};
		}

		// Token: 0x0600B1F1 RID: 45553 RVA: 0x00275964 File Offset: 0x00273D64
		public static ChampionshipTopPlayerDataModel CreateTopPlayerDataModelByTopPlayerDataModel(ChampionshipTopPlayerDataModel defaultTopPlayerDataModel)
		{
			if (defaultTopPlayerDataModel == null)
			{
				return null;
			}
			return new ChampionshipTopPlayerDataModel
			{
				PlayerGuid = defaultTopPlayerDataModel.PlayerGuid,
				Position = defaultTopPlayerDataModel.Position,
				Name = defaultTopPlayerDataModel.Name,
				ProfessionId = defaultTopPlayerDataModel.ProfessionId,
				PlayerAvatar = defaultTopPlayerDataModel.PlayerAvatar,
				ServerName = defaultTopPlayerDataModel.ServerName,
				ZoneId = defaultTopPlayerDataModel.ZoneId
			};
		}

		// Token: 0x0600B1F2 RID: 45554 RVA: 0x002759D8 File Offset: 0x00273DD8
		public static ChampionshipTopPlayerDataModel GetTopPlayerDataModelByPlayerGuid(ulong playerGuid)
		{
			Dictionary<ulong, ChampionshipTopPlayerDataModel> topPlayerDataModelDic = DataManager<ChampionshipDataManager>.GetInstance().TopPlayerDataModelDic;
			if (topPlayerDataModelDic == null || topPlayerDataModelDic.Count <= 0)
			{
				return null;
			}
			if (!topPlayerDataModelDic.ContainsKey(playerGuid))
			{
				return null;
			}
			return topPlayerDataModelDic[playerGuid];
		}

		// Token: 0x0600B1F3 RID: 45555 RVA: 0x00275A1C File Offset: 0x00273E1C
		public static string GetTopPlayerNameByPlayerGuid(ulong playerGuid)
		{
			ChampionshipTopPlayerDataModel topPlayerDataModelByPlayerGuid = ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(playerGuid);
			if (topPlayerDataModelByPlayerGuid == null)
			{
				return string.Empty;
			}
			return topPlayerDataModelByPlayerGuid.Name;
		}

		// Token: 0x0600B1F4 RID: 45556 RVA: 0x00275A44 File Offset: 0x00273E44
		public static ChampionshipFightRaceDataModel GetFightRaceDataModelByFightRaceId(int fightRaceId)
		{
			Dictionary<int, ChampionshipFightRaceDataModel> totalFightRaceDataModelDictionary = DataManager<ChampionshipDataManager>.GetInstance().TotalFightRaceDataModelDictionary;
			if (totalFightRaceDataModelDictionary == null || totalFightRaceDataModelDictionary.Count <= 0)
			{
				return null;
			}
			if (totalFightRaceDataModelDictionary.ContainsKey(fightRaceId))
			{
				return totalFightRaceDataModelDictionary[fightRaceId];
			}
			return null;
		}

		// Token: 0x0600B1F5 RID: 45557 RVA: 0x00275A88 File Offset: 0x00273E88
		public static ChampionshipFightRaceDataModel GetFinalFightRaceDataModel()
		{
			return ChampionshipUtility.GetFightRaceDataModelByFightRaceId(1);
		}

		// Token: 0x0600B1F6 RID: 45558 RVA: 0x00275AA0 File Offset: 0x00273EA0
		public static ChampionshipTopPlayerDataModel GetFinalWinnerDataModel()
		{
			ChampionshipFightRaceDataModel finalFightRaceDataModel = ChampionshipUtility.GetFinalFightRaceDataModel();
			if (finalFightRaceDataModel == null)
			{
				return null;
			}
			ulong playerGuid = finalFightRaceDataModel.FirstPlayerGuid;
			if (finalFightRaceDataModel.FirstPlayerScore < finalFightRaceDataModel.SecondPlayerScore)
			{
				playerGuid = finalFightRaceDataModel.SecondPlayerGuid;
			}
			return ChampionshipUtility.GetTopPlayerDataModelByPlayerGuid(playerGuid);
		}

		// Token: 0x0600B1F7 RID: 45559 RVA: 0x00275AE4 File Offset: 0x00273EE4
		public static List<ChampionshipFightRaceDataModel> GetLeftFightRaceDataModelList(ChampionshipScheduleTable.eScheduleType scheduleType)
		{
			Dictionary<int, ChampionshipFightRaceDataModel> totalFightRaceDataModelDictionary = DataManager<ChampionshipDataManager>.GetInstance().TotalFightRaceDataModelDictionary;
			if (totalFightRaceDataModelDictionary == null || totalFightRaceDataModelDictionary.Count <= 0)
			{
				return null;
			}
			List<ChampionshipFightRaceDataModel> list = new List<ChampionshipFightRaceDataModel>();
			if (scheduleType == ChampionshipScheduleTable.eScheduleType.Eight_Select)
			{
				int key = 8;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
				key = 9;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
				key = 10;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
				key = 11;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
			}
			else if (scheduleType == ChampionshipScheduleTable.eScheduleType.Four_Select)
			{
				int key2 = 4;
				if (totalFightRaceDataModelDictionary.ContainsKey(key2))
				{
					list.Add(totalFightRaceDataModelDictionary[key2]);
				}
				key2 = 5;
				if (totalFightRaceDataModelDictionary.ContainsKey(key2))
				{
					list.Add(totalFightRaceDataModelDictionary[key2]);
				}
			}
			else if (scheduleType == ChampionshipScheduleTable.eScheduleType.Two_Select)
			{
				int key3 = 2;
				if (totalFightRaceDataModelDictionary.ContainsKey(key3))
				{
					list.Add(totalFightRaceDataModelDictionary[key3]);
				}
			}
			return list;
		}

		// Token: 0x0600B1F8 RID: 45560 RVA: 0x00275BFC File Offset: 0x00273FFC
		public static List<ChampionshipFightRaceDataModel> GetRightFightRaceDataModelList(ChampionshipScheduleTable.eScheduleType scheduleType)
		{
			Dictionary<int, ChampionshipFightRaceDataModel> totalFightRaceDataModelDictionary = DataManager<ChampionshipDataManager>.GetInstance().TotalFightRaceDataModelDictionary;
			List<ChampionshipFightRaceDataModel> list = new List<ChampionshipFightRaceDataModel>();
			if (scheduleType == ChampionshipScheduleTable.eScheduleType.Eight_Select)
			{
				int key = 12;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
				key = 13;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
				key = 14;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
				key = 15;
				if (totalFightRaceDataModelDictionary.ContainsKey(key))
				{
					list.Add(totalFightRaceDataModelDictionary[key]);
				}
			}
			else if (scheduleType == ChampionshipScheduleTable.eScheduleType.Four_Select)
			{
				int key2 = 6;
				if (totalFightRaceDataModelDictionary.ContainsKey(key2))
				{
					list.Add(totalFightRaceDataModelDictionary[key2]);
				}
				key2 = 7;
				if (totalFightRaceDataModelDictionary.ContainsKey(key2))
				{
					list.Add(totalFightRaceDataModelDictionary[key2]);
				}
			}
			else if (scheduleType == ChampionshipScheduleTable.eScheduleType.Two_Select)
			{
				int key3 = 3;
				if (totalFightRaceDataModelDictionary.ContainsKey(key3))
				{
					list.Add(totalFightRaceDataModelDictionary[key3]);
				}
			}
			return list;
		}

		// Token: 0x0600B1F9 RID: 45561 RVA: 0x00275D00 File Offset: 0x00274100
		public static void UpdateChampionshipFightRaceDataModel(ChampionshipFightRaceDataModel fightRaceDataModel, ChampionGroup championGroup)
		{
			if (fightRaceDataModel == null || championGroup == null)
			{
				return;
			}
			fightRaceDataModel.FightGroupId = (int)championGroup.groupID;
			fightRaceDataModel.FirstPlayerGuid = championGroup.roleA;
			fightRaceDataModel.SecondPlayerGuid = championGroup.roleB;
			fightRaceDataModel.FirstPlayerScore = championGroup.scoreA;
			fightRaceDataModel.SecondPlayerScore = championGroup.scoreB;
			if (championGroup.status == 2)
			{
				fightRaceDataModel.FightStatus = ChampionshipFightStatus.AlreadyFinished;
			}
			else if (championGroup.status == 1)
			{
				fightRaceDataModel.FightStatus = ChampionshipFightStatus.BeFighting;
			}
			else
			{
				fightRaceDataModel.FightStatus = ChampionshipFightStatus.NotStart;
			}
		}

		// Token: 0x0600B1FA RID: 45562 RVA: 0x00275D90 File Offset: 0x00274190
		public static bool IsSelfPlayerCanWatchFightRace()
		{
			ulong roleID = DataManager<PlayerBaseData>.GetInstance().RoleID;
			if (DataManager<ChampionshipDataManager>.GetInstance().TopPlayerDataModelDic == null || !DataManager<ChampionshipDataManager>.GetInstance().TopPlayerDataModelDic.ContainsKey(roleID))
			{
				return true;
			}
			if (ChampionshipUtility.IsInChampionshipEndShow())
			{
				return true;
			}
			if (ChampionshipUtility.IsInChampionshipSchedulePreStatus())
			{
				return true;
			}
			ChampionshipFightStatus championshipFightStatus = ChampionshipFightStatus.None;
			return !ChampionshipUtility.IsSelfPlayerInCurrentFightRaceSchedule(out championshipFightStatus) || (!ChampionshipUtility.IsInChampionshipSchedulePrepareStatus() && championshipFightStatus == ChampionshipFightStatus.AlreadyFinished);
		}

		// Token: 0x0600B1FB RID: 45563 RVA: 0x00275E10 File Offset: 0x00274210
		private static bool IsSelfPlayerInCurrentFightRaceSchedule(out ChampionshipFightStatus fightStatus)
		{
			fightStatus = ChampionshipFightStatus.None;
			ulong roleID = DataManager<PlayerBaseData>.GetInstance().RoleID;
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.ScheduleType == ChampionshipScheduleTable.eScheduleType.One_Select)
			{
				ChampionshipFightRaceDataModel finalFightRaceDataModel = ChampionshipUtility.GetFinalFightRaceDataModel();
				if (finalFightRaceDataModel != null && (finalFightRaceDataModel.FirstPlayerGuid == roleID || finalFightRaceDataModel.SecondPlayerGuid == roleID))
				{
					fightStatus = finalFightRaceDataModel.FightStatus;
					return true;
				}
			}
			List<ChampionshipFightRaceDataModel> leftFightRaceDataModelList = ChampionshipUtility.GetLeftFightRaceDataModelList(tableItem.ScheduleType);
			if (leftFightRaceDataModelList != null)
			{
				for (int i = 0; i < leftFightRaceDataModelList.Count; i++)
				{
					ChampionshipFightRaceDataModel championshipFightRaceDataModel = leftFightRaceDataModelList[i];
					if (championshipFightRaceDataModel != null)
					{
						if (championshipFightRaceDataModel.FirstPlayerGuid == roleID || championshipFightRaceDataModel.SecondPlayerGuid == roleID)
						{
							fightStatus = championshipFightRaceDataModel.FightStatus;
							return true;
						}
					}
				}
			}
			List<ChampionshipFightRaceDataModel> rightFightRaceDataModelList = ChampionshipUtility.GetRightFightRaceDataModelList(tableItem.ScheduleType);
			if (rightFightRaceDataModelList != null)
			{
				for (int j = 0; j < rightFightRaceDataModelList.Count; j++)
				{
					ChampionshipFightRaceDataModel championshipFightRaceDataModel2 = rightFightRaceDataModelList[j];
					if (championshipFightRaceDataModel2 != null)
					{
						if (championshipFightRaceDataModel2.FirstPlayerGuid == roleID || championshipFightRaceDataModel2.SecondPlayerGuid == roleID)
						{
							fightStatus = championshipFightRaceDataModel2.FightStatus;
							return true;
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B1FC RID: 45564 RVA: 0x00275F64 File Offset: 0x00274364
		public static ChampionshipGuessProjectDataModel GetChampionshipGuessProjectDataModelByProjectType(GambleType projectType, int scheduleId = 0)
		{
			Dictionary<uint, ChampionshipGuessProjectDataModel> guessProjectDataModelDictionary = DataManager<ChampionshipDataManager>.GetInstance().GuessProjectDataModelDictionary;
			if (guessProjectDataModelDictionary == null)
			{
				return null;
			}
			foreach (KeyValuePair<uint, ChampionshipGuessProjectDataModel> keyValuePair in guessProjectDataModelDictionary)
			{
				ChampionshipGuessProjectDataModel value = keyValuePair.Value;
				if (value != null)
				{
					if (projectType == GambleType.GT_1V1)
					{
						if (value.ProjectType == projectType && value.ScheduleId == scheduleId)
						{
							return value;
						}
					}
					else if (value.ProjectType == projectType)
					{
						return value;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B1FD RID: 45565 RVA: 0x00275FEC File Offset: 0x002743EC
		public static ChampionshipGuessProjectDataModel GetChampionshipGuessProjectDataModelByProjectId(uint projectId)
		{
			Dictionary<uint, ChampionshipGuessProjectDataModel> guessProjectDataModelDictionary = DataManager<ChampionshipDataManager>.GetInstance().GuessProjectDataModelDictionary;
			if (guessProjectDataModelDictionary == null)
			{
				return null;
			}
			if (!guessProjectDataModelDictionary.ContainsKey(projectId))
			{
				return null;
			}
			return guessProjectDataModelDictionary[projectId];
		}

		// Token: 0x0600B1FE RID: 45566 RVA: 0x00276024 File Offset: 0x00274424
		public static ChampionshipGuessProjectDataModel CreateGuessProjectDataModelByGambleInfo(GambleInfo info)
		{
			if (info == null)
			{
				return null;
			}
			ChampionshipGuessProjectDataModel championshipGuessProjectDataModel = new ChampionshipGuessProjectDataModel();
			championshipGuessProjectDataModel.ProjectId = info.id;
			championshipGuessProjectDataModel.ProjectType = (GambleType)info.type;
			championshipGuessProjectDataModel.ProjectParam = info.param;
			if (championshipGuessProjectDataModel.ProjectType == GambleType.GT_1V1)
			{
				ulong param = info.param;
				int scheduleIdByRaceId = ChampionshipUtility.GetScheduleIdByRaceId(param);
				championshipGuessProjectDataModel.ScheduleId = scheduleIdByRaceId;
				championshipGuessProjectDataModel.FightRaceId = (int)param;
			}
			championshipGuessProjectDataModel.StartTime = info.startTime;
			championshipGuessProjectDataModel.EndTime = info.endTime;
			championshipGuessProjectDataModel.GuessOptionDataModelDictionary.Clear();
			championshipGuessProjectDataModel.GuessOptionIdList.Clear();
			if (info.options != null && info.options.Length > 0)
			{
				for (int i = 0; i < info.options.Length; i++)
				{
					GambleOption gambleOption = info.options[i];
					if (gambleOption != null)
					{
						ulong option = gambleOption.option;
						championshipGuessProjectDataModel.GuessOptionIdList.Add(option);
						ChampionshipGuessOptionDataModel value = ChampionshipUtility.CreateGuessOptionDataModel(gambleOption);
						championshipGuessProjectDataModel.GuessOptionDataModelDictionary[option] = value;
					}
				}
			}
			return championshipGuessProjectDataModel;
		}

		// Token: 0x0600B1FF RID: 45567 RVA: 0x00276134 File Offset: 0x00274534
		public static void UpdateGuessProjectDataModel(ChampionshipGuessProjectDataModel guessProjectDataModel, GambleInfo info)
		{
			if (guessProjectDataModel == null || guessProjectDataModel.GuessOptionDataModelDictionary == null || guessProjectDataModel.GuessOptionDataModelDictionary.Count <= 0)
			{
				return;
			}
			if (info == null || info.options == null || info.options.Length <= 0)
			{
				return;
			}
			foreach (GambleOption gambleOption in info.options)
			{
				if (gambleOption != null)
				{
					ulong option = gambleOption.option;
					if (guessProjectDataModel.GuessOptionDataModelDictionary.ContainsKey(option))
					{
						ChampionshipGuessOptionDataModel championshipGuessOptionDataModel = guessProjectDataModel.GuessOptionDataModelDictionary[option];
						if (championshipGuessOptionDataModel != null)
						{
							ChampionshipUtility.UpdateGuessOptionDataModel(championshipGuessOptionDataModel, gambleOption);
						}
					}
				}
			}
		}

		// Token: 0x0600B200 RID: 45568 RVA: 0x002761F0 File Offset: 0x002745F0
		public static ChampionshipGuessOptionDataModel CreateGuessOptionDataModel(GambleOption option)
		{
			if (option == null)
			{
				return null;
			}
			return new ChampionshipGuessOptionDataModel
			{
				OptionId = option.option,
				GuessNumber = option.num,
				Odds = option.odds
			};
		}

		// Token: 0x0600B201 RID: 45569 RVA: 0x00276230 File Offset: 0x00274630
		public static void UpdateGuessOptionDataModel(ChampionshipGuessOptionDataModel guessOptionDataModel, GambleOption option)
		{
			if (guessOptionDataModel == null || option == null)
			{
				return;
			}
			guessOptionDataModel.GuessNumber = option.num;
			guessOptionDataModel.Odds = option.odds;
		}

		// Token: 0x0600B202 RID: 45570 RVA: 0x00276258 File Offset: 0x00274658
		public static void UpdateGuessOptionDataModelByBetFinished(uint guessProjectId, ulong guessOptionId, ulong number)
		{
			Dictionary<uint, ChampionshipGuessProjectDataModel> guessProjectDataModelDictionary = DataManager<ChampionshipDataManager>.GetInstance().GuessProjectDataModelDictionary;
			if (guessProjectDataModelDictionary == null || guessProjectDataModelDictionary.Count <= 0)
			{
				return;
			}
			if (!guessProjectDataModelDictionary.ContainsKey(guessProjectId))
			{
				return;
			}
			ChampionshipGuessProjectDataModel championshipGuessProjectDataModel = guessProjectDataModelDictionary[guessProjectId];
			if (championshipGuessProjectDataModel.GuessOptionDataModelDictionary == null || championshipGuessProjectDataModel.GuessOptionDataModelDictionary.Count <= 0)
			{
				return;
			}
			if (!championshipGuessProjectDataModel.GuessOptionDataModelDictionary.ContainsKey(guessOptionId))
			{
				return;
			}
			ChampionshipGuessOptionDataModel championshipGuessOptionDataModel = championshipGuessProjectDataModel.GuessOptionDataModelDictionary[guessOptionId];
			if (championshipGuessOptionDataModel == null)
			{
				return;
			}
			championshipGuessOptionDataModel.GuessNumber += number;
		}

		// Token: 0x0600B203 RID: 45571 RVA: 0x002762EC File Offset: 0x002746EC
		public static List<int> GetGuessBetTabList()
		{
			List<int> list = new List<int>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChampionshipGuessBetTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChampionshipGuessBetTable championshipGuessBetTable = keyValuePair.Value as ChampionshipGuessBetTable;
				if (championshipGuessBetTable != null && championshipGuessBetTable.BetValue > 0)
				{
					list.Add(championshipGuessBetTable.BetValue);
				}
			}
			return list;
		}

		// Token: 0x0600B204 RID: 45572 RVA: 0x0027635C File Offset: 0x0027475C
		public static ChampionshipGuessRecordDataModel CreateChampionshipGuessRecordDataModel(GambleRecord gambleRecord)
		{
			if (gambleRecord == null)
			{
				return null;
			}
			ChampionshipGuessRecordDataModel championshipGuessRecordDataModel = new ChampionshipGuessRecordDataModel();
			championshipGuessRecordDataModel.ProjectId = gambleRecord.id;
			championshipGuessRecordDataModel.ProjectOptionId = gambleRecord.option;
			championshipGuessRecordDataModel.BetTime = gambleRecord.time;
			championshipGuessRecordDataModel.GuessResult = gambleRecord.result;
			championshipGuessRecordDataModel.GuessReward = gambleRecord.reward;
			championshipGuessRecordDataModel.GuessResultType = ChampionshipGuessResultType.UnOpen;
			if (gambleRecord.result > 0UL)
			{
				if (gambleRecord.reward > 0UL)
				{
					championshipGuessRecordDataModel.GuessResultType = ChampionshipGuessResultType.BingGo;
				}
				else
				{
					championshipGuessRecordDataModel.GuessResultType = ChampionshipGuessResultType.UnBingGo;
				}
			}
			championshipGuessRecordDataModel.BetNumber = gambleRecord.num;
			return championshipGuessRecordDataModel;
		}

		// Token: 0x0600B205 RID: 45573 RVA: 0x002763F4 File Offset: 0x002747F4
		public static List<ChampionshipGuessRecordDataModel> GetGuessRecordDataModelListByGuessResultType(ChampionshipGuessResultType guessResultType)
		{
			List<ChampionshipGuessRecordDataModel> guessRecordDataModelList = DataManager<ChampionshipDataManager>.GetInstance().GuessRecordDataModelList;
			if (guessRecordDataModelList == null || guessRecordDataModelList.Count <= 0)
			{
				return null;
			}
			List<ChampionshipGuessRecordDataModel> list = new List<ChampionshipGuessRecordDataModel>();
			for (int i = 0; i < guessRecordDataModelList.Count; i++)
			{
				ChampionshipGuessRecordDataModel championshipGuessRecordDataModel = guessRecordDataModelList[i];
				if (championshipGuessRecordDataModel != null)
				{
					if (championshipGuessRecordDataModel.GuessResultType == guessResultType)
					{
						list.Add(championshipGuessRecordDataModel);
					}
				}
			}
			return list;
		}

		// Token: 0x0600B206 RID: 45574 RVA: 0x00276464 File Offset: 0x00274864
		public static void UpdateGuessRecordDataModel(ChampionshipGuessRecordDataModel guessRecordDataModel)
		{
			if (guessRecordDataModel == null || guessRecordDataModel.ProjectId <= 0U || guessRecordDataModel.ProjectOptionId <= 0UL)
			{
				return;
			}
			if (guessRecordDataModel.IsAlreadyUpdate)
			{
				return;
			}
			ChampionshipGuessProjectDataModel championshipGuessProjectDataModelByProjectId = ChampionshipUtility.GetChampionshipGuessProjectDataModelByProjectId(guessRecordDataModel.ProjectId);
			if (championshipGuessProjectDataModelByProjectId == null)
			{
				return;
			}
			GambleType projectType = championshipGuessProjectDataModelByProjectId.ProjectType;
			string championshipGuessCostItemNameStr = DataManager<ChampionshipDataManager>.GetInstance().GetChampionshipGuessCostItemNameStr();
			if (projectType == GambleType.GT_CHAMPION)
			{
				guessRecordDataModel.GuessRecordTitleStr = TR.Value("Championship_Guess_Record_First_Winner_Title_Format");
				string timeFormatByMonthDayHourMinute = TimeUtility.GetTimeFormatByMonthDayHourMinute(guessRecordDataModel.BetTime);
				string topPlayerNameByPlayerGuid = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(guessRecordDataModel.ProjectOptionId);
				string guessRecordContentStr = TR.Value("Championship_Guess_Record_First_Winner_Content_Normal_Format", timeFormatByMonthDayHourMinute, topPlayerNameByPlayerGuid, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				string guessRecordResultStr = TR.Value("Championship_Guess_Record_UnOpen_Content_Text");
				if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.BingGo)
				{
					string topPlayerNameByPlayerGuid2 = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(guessRecordDataModel.GuessResult);
					guessRecordResultStr = TR.Value("Championship_Guess_Record_First_Winner_Result_Normal_Format", topPlayerNameByPlayerGuid2);
				}
				else if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.UnBingGo)
				{
					string topPlayerNameByPlayerGuid3 = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(guessRecordDataModel.GuessResult);
					guessRecordResultStr = TR.Value("Championship_Guess_Record_First_Winner_Result_UnBingGo_Format", topPlayerNameByPlayerGuid3);
					guessRecordContentStr = TR.Value("Championship_Guess_Record_First_Winner_Content_UnBingGo_Format", timeFormatByMonthDayHourMinute, topPlayerNameByPlayerGuid, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				}
				guessRecordDataModel.GuessRecordResultStr = guessRecordResultStr;
				guessRecordDataModel.GuessRecordContentStr = guessRecordContentStr;
			}
			else if (projectType == GambleType.GT_1V1)
			{
				string empty = string.Empty;
				string empty2 = string.Empty;
				ChampionshipUtility.GetChampionshipFightRaceTwoPlayerName(championshipGuessProjectDataModelByProjectId, out empty, out empty2);
				string guessRecordTitleStr = TR.Value("Championship_Guess_Record_Fight_Winner_Title_Normal_Format", empty, empty2);
				bool flag = ChampionshipUtility.IsFirstPlayerInFightGroup(championshipGuessProjectDataModelByProjectId, guessRecordDataModel.ProjectOptionId);
				string timeFormatByMonthDayHourMinute2 = TimeUtility.GetTimeFormatByMonthDayHourMinute(guessRecordDataModel.BetTime);
				string topPlayerNameByPlayerGuid4 = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(guessRecordDataModel.ProjectOptionId);
				string format = TR.Value("Championship_Guess_Record_Fight_Winner_Content_First_Winner_Normal_Format");
				if (!flag)
				{
					format = TR.Value("Championship_Guess_Record_Fight_Winner_Content_Second_Winner_Normal_Format");
				}
				string guessRecordContentStr2 = string.Format(format, new object[]
				{
					timeFormatByMonthDayHourMinute2,
					topPlayerNameByPlayerGuid4,
					guessRecordDataModel.BetNumber.ToString(),
					championshipGuessCostItemNameStr
				});
				string guessRecordResultStr2 = TR.Value("Championship_Guess_Record_UnOpen_Content_Text");
				if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.BingGo)
				{
					string topPlayerNameByPlayerGuid5 = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(guessRecordDataModel.GuessResult);
					if (flag)
					{
						guessRecordResultStr2 = TR.Value("Championship_Guess_Record_Fight_Winner_Result_First_Winner_Format", topPlayerNameByPlayerGuid5);
					}
					else
					{
						guessRecordResultStr2 = TR.Value("Championship_Guess_Record_Fight_Winner_Result_Second_Winner_Format", topPlayerNameByPlayerGuid5);
					}
				}
				else if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.UnBingGo)
				{
					string topPlayerNameByPlayerGuid6 = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(guessRecordDataModel.GuessResult);
					guessRecordResultStr2 = TR.Value("Championship_Guess_Record_Fight_Winner_Result_UnBingGo_Format", topPlayerNameByPlayerGuid6);
					guessRecordTitleStr = TR.Value("Championship_Guess_Record_Fight_Winner_Title_UnBingGo_Format", empty, empty2);
					guessRecordContentStr2 = TR.Value("Championship_Guess_Record_Fight_Winner_Content_UnBingGo_Format", timeFormatByMonthDayHourMinute2, topPlayerNameByPlayerGuid4, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				}
				guessRecordDataModel.GuessRecordTitleStr = guessRecordTitleStr;
				guessRecordDataModel.GuessRecordContentStr = guessRecordContentStr2;
				guessRecordDataModel.GuessRecordResultStr = guessRecordResultStr2;
			}
			else if (projectType == GambleType.GT_BATTLE_COUNT)
			{
				guessRecordDataModel.GuessRecordTitleStr = TR.Value("Championship_Guess_Record_Fight_Race_Number_Title_Format");
				string timeFormatByMonthDayHourMinute3 = TimeUtility.GetTimeFormatByMonthDayHourMinute(guessRecordDataModel.BetTime);
				string championshipGuessFightRaceNumberStr = ChampionshipUtility.GetChampionshipGuessFightRaceNumberStr(guessRecordDataModel.ProjectOptionId);
				string guessRecordContentStr3 = TR.Value("Championship_Guess_Record_Fight_Race_Number_Content_Normal_Format", timeFormatByMonthDayHourMinute3, championshipGuessFightRaceNumberStr, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				string championshipGuessFightRaceNumberStr2 = ChampionshipUtility.GetChampionshipGuessFightRaceNumberStr(guessRecordDataModel.GuessResult);
				string guessRecordResultStr3 = TR.Value("Championship_Guess_Record_UnOpen_Content_Text");
				if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.BingGo)
				{
					guessRecordResultStr3 = TR.Value("Championship_Guess_Record_Fight_Race_Number_Result_Normal_Format", championshipGuessFightRaceNumberStr2);
				}
				else if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.UnBingGo)
				{
					guessRecordResultStr3 = TR.Value("Championship_Guess_Record_Fight_Race_Number_Result_UnBingGo_Format", championshipGuessFightRaceNumberStr2);
					guessRecordContentStr3 = TR.Value("Championship_Guess_Record_Fight_Race_Number_Content_UnBingGo_Format", timeFormatByMonthDayHourMinute3, championshipGuessFightRaceNumberStr, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				}
				guessRecordDataModel.GuessRecordResultStr = guessRecordResultStr3;
				guessRecordDataModel.GuessRecordContentStr = guessRecordContentStr3;
			}
			else if (projectType == GambleType.GT_CHAMPION_BATTLE_SCORE)
			{
				guessRecordDataModel.GuessRecordTitleStr = TR.Value("Championship_Guess_Record_Total_Score_Title_Format");
				string timeFormatByMonthDayHourMinute4 = TimeUtility.GetTimeFormatByMonthDayHourMinute(guessRecordDataModel.BetTime);
				string championshipGuessFinalScoreStr = ChampionshipUtility.GetChampionshipGuessFinalScoreStr(guessRecordDataModel.ProjectOptionId);
				string guessRecordContentStr4 = TR.Value("Championship_Guess_Record_Total_Score_Content_Normal_Format", timeFormatByMonthDayHourMinute4, championshipGuessFinalScoreStr, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				string championshipGuessFinalScoreStr2 = ChampionshipUtility.GetChampionshipGuessFinalScoreStr(guessRecordDataModel.GuessResult);
				string guessRecordResultStr4 = TR.Value("Championship_Guess_Record_UnOpen_Content_Text");
				if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.BingGo)
				{
					guessRecordResultStr4 = TR.Value("Championship_Guess_Record_Total_Score_Result_Normal_Format", championshipGuessFinalScoreStr2);
				}
				else if (guessRecordDataModel.GuessResultType == ChampionshipGuessResultType.UnBingGo)
				{
					guessRecordResultStr4 = TR.Value("Championship_Guess_Record_Total_Score_Result_UnBingGo_Format", championshipGuessFinalScoreStr2);
					guessRecordContentStr4 = TR.Value("Championship_Guess_Record_Total_Score_Content_UnBingGo_Format", timeFormatByMonthDayHourMinute4, championshipGuessFinalScoreStr, guessRecordDataModel.BetNumber.ToString(), championshipGuessCostItemNameStr);
				}
				guessRecordDataModel.GuessRecordResultStr = guessRecordResultStr4;
				guessRecordDataModel.GuessRecordContentStr = guessRecordContentStr4;
			}
			guessRecordDataModel.IsAlreadyUpdate = true;
		}

		// Token: 0x0600B207 RID: 45575 RVA: 0x002768D4 File Offset: 0x00274CD4
		public static void GetChampionshipFightRaceTwoPlayerName(ChampionshipGuessProjectDataModel guessProjectDataModel, out string firstPlayerName, out string secondPlayerName)
		{
			firstPlayerName = string.Empty;
			secondPlayerName = string.Empty;
			if (guessProjectDataModel == null)
			{
				return;
			}
			if (guessProjectDataModel.GuessOptionIdList == null || guessProjectDataModel.GuessOptionIdList.Count != 2)
			{
				return;
			}
			ulong playerGuid = guessProjectDataModel.GuessOptionIdList[0];
			ulong playerGuid2 = guessProjectDataModel.GuessOptionIdList[1];
			firstPlayerName = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(playerGuid);
			secondPlayerName = ChampionshipUtility.GetTopPlayerNameByPlayerGuid(playerGuid2);
		}

		// Token: 0x0600B208 RID: 45576 RVA: 0x0027693D File Offset: 0x00274D3D
		public static bool IsFirstPlayerInFightGroup(ChampionshipGuessProjectDataModel guessProjectDataModel, ulong optionId)
		{
			return guessProjectDataModel == null || guessProjectDataModel.GuessOptionIdList == null || guessProjectDataModel.GuessOptionIdList.Count != 2 || guessProjectDataModel.GuessOptionIdList[0] == optionId;
		}

		// Token: 0x0600B209 RID: 45577 RVA: 0x00276978 File Offset: 0x00274D78
		public static string GetChampionshipGuessFightRaceNumberStr(ulong optionId)
		{
			if (DataManager<ChampionshipDataManager>.GetInstance().GuessOptionNameDictionary.ContainsKey(optionId))
			{
				return DataManager<ChampionshipDataManager>.GetInstance().GuessOptionNameDictionary[optionId];
			}
			ulong num = optionId / 100UL;
			ulong num2 = optionId % 100UL;
			string text = TR.Value("Championship_Guess_Bet_Fight_Race_Number_Format", num, num2);
			DataManager<ChampionshipDataManager>.GetInstance().GuessOptionNameDictionary[optionId] = text;
			return text;
		}

		// Token: 0x0600B20A RID: 45578 RVA: 0x002769E0 File Offset: 0x00274DE0
		public static string GetChampionshipGuessFinalScoreStr(ulong optionId)
		{
			if (DataManager<ChampionshipDataManager>.GetInstance().GuessOptionNameDictionary.ContainsKey(optionId))
			{
				return DataManager<ChampionshipDataManager>.GetInstance().GuessOptionNameDictionary[optionId];
			}
			ulong num = optionId / 10UL;
			ulong num2 = optionId % 10UL;
			string text = TR.Value("Championship_Guess_Bet_Fight_Score_Format", num, num2);
			DataManager<ChampionshipDataManager>.GetInstance().GuessOptionNameDictionary[optionId] = text;
			return text;
		}

		// Token: 0x0600B20B RID: 45579 RVA: 0x00276A48 File Offset: 0x00274E48
		public static bool IsGuessProjectStillInBetTime(ChampionshipGuessProjectDataModel guessProjectDataModel)
		{
			if (guessProjectDataModel == null)
			{
				return false;
			}
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			return serverTime >= guessProjectDataModel.StartTime && serverTime <= guessProjectDataModel.EndTime;
		}

		// Token: 0x0600B20C RID: 45580 RVA: 0x00276A88 File Offset: 0x00274E88
		private static int GetScheduleIdByRaceId(ulong raceId)
		{
			if (raceId >= 8UL && raceId <= 15UL)
			{
				return 6;
			}
			if (raceId >= 4UL && raceId <= 7UL)
			{
				return 7;
			}
			if (raceId >= 2UL && raceId <= 3UL)
			{
				return 8;
			}
			if (raceId == 1UL)
			{
				return 9;
			}
			return 0;
		}

		// Token: 0x0600B20D RID: 45581 RVA: 0x00276AD8 File Offset: 0x00274ED8
		public static bool IsInChampionshipScene()
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return false;
			}
			CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(clientSystemTown.CurrentSceneID, string.Empty, string.Empty);
			return tableItem != null && (tableItem.SceneType == CitySceneTable.eSceneType.CHAMPIONSHIP && tableItem.SceneSubType == CitySceneTable.eSceneSubType.ChampionshipEntry);
		}

		// Token: 0x0600B20E RID: 45582 RVA: 0x00276B3D File Offset: 0x00274F3D
		public static bool IsChampionshipTopPlayerNotExist()
		{
			return DataManager<ChampionshipDataManager>.GetInstance().TopPlayerDataModelDic == null || DataManager<ChampionshipDataManager>.GetInstance().TopPlayerDataModelDic.Count <= 0;
		}

		// Token: 0x0600B20F RID: 45583 RVA: 0x00276B66 File Offset: 0x00274F66
		public static bool IsChampionshipFightRaceNotExist()
		{
			return DataManager<ChampionshipDataManager>.GetInstance().TotalFightRaceDataModelDictionary == null || DataManager<ChampionshipDataManager>.GetInstance().TotalFightRaceDataModelDictionary.Count <= 0;
		}

		// Token: 0x0600B210 RID: 45584 RVA: 0x00276B90 File Offset: 0x00274F90
		public static ChampionTimeTable GetChampionshipSignUpTime()
		{
			ChampionTimeTable result = null;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChampionTimeTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChampionTimeTable championTimeTable = keyValuePair.Value as ChampionTimeTable;
				if (championTimeTable != null)
				{
					ChampionStatus status = (ChampionStatus)championTimeTable.Status;
					if (status == ChampionStatus.CS_ENROLL)
					{
						result = championTimeTable;
					}
					if (status == ChampionStatus.CS_END_SHOW)
					{
						DateTime dateTime = Function.GetDateTime(championTimeTable.EndTime, "yyyy-MM-dd HH:mm:ss");
						int timeStamp = Function.GetTimeStamp(dateTime);
						if ((ulong)DataManager<TimeManager>.GetInstance().GetServerTime() < (ulong)((long)timeStamp))
						{
							break;
						}
					}
				}
			}
			return result;
		}

		// Token: 0x0600B211 RID: 45585 RVA: 0x00276C34 File Offset: 0x00275034
		public static bool IsChampionshipCanGuess()
		{
			int championshipScheduleId = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId;
			ChampionshipScheduleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(championshipScheduleId, string.Empty, string.Empty);
			return tableItem != null && (tableItem.ScheduleType >= ChampionshipScheduleTable.eScheduleType.Eight_Select && tableItem.ScheduleType <= ChampionshipScheduleTable.eScheduleType.One_Select);
		}

		// Token: 0x0600B212 RID: 45586 RVA: 0x00276C88 File Offset: 0x00275088
		public static List<ComControlData> GetComControlDataInGuessRecord()
		{
			return new List<ComControlData>
			{
				new ComControlData
				{
					Id = 1,
					Name = TR.Value("Championship_Guess_Record_Tab_All_Text"),
					IsSelected = true
				},
				new ComControlData
				{
					Id = 2,
					Name = TR.Value("Championship_Guess_Record_Tab_UnOpen_Text"),
					IsSelected = false
				},
				new ComControlData
				{
					Id = 3,
					Name = TR.Value("Championship_Guess_Record_Tab_BingGo_Text"),
					IsSelected = false
				}
			};
		}

		// Token: 0x0600B213 RID: 45587 RVA: 0x00276D20 File Offset: 0x00275120
		public static List<ComControlDataEx> GetComControlDataExInGuessType(int selectedId)
		{
			List<ComControlDataEx> list = new List<ComControlDataEx>();
			list.Add(new ComControlDataEx
			{
				Id = 1,
				Name = TR.Value("Championship_Guess_First_Guess_Title"),
				IsSelected = false
			});
			list.Add(new ComControlDataEx
			{
				Id = 2,
				Name = TR.Value("Championship_Guess_Single_Game_Guess_Title"),
				IsSelected = false
			});
			list.Add(new ComControlDataEx
			{
				Id = 3,
				Name = TR.Value("Championship_Guess_Funny_Guess_Title"),
				IsSelected = false
			});
			bool flag = false;
			for (int i = 0; i < list.Count; i++)
			{
				ComControlDataEx comControlDataEx = list[i];
				if (comControlDataEx != null)
				{
					if (comControlDataEx.Id == selectedId)
					{
						comControlDataEx.IsSelected = true;
						flag = true;
						break;
					}
				}
			}
			if (!flag && list.Count >= 1)
			{
				ComControlDataEx comControlDataEx2 = list[0];
				if (comControlDataEx2 != null)
				{
					comControlDataEx2.IsSelected = true;
				}
			}
			return list;
		}

		// Token: 0x0600B214 RID: 45588 RVA: 0x00276E34 File Offset: 0x00275234
		public static List<ComControlDataEx> GetComControlDataExInTopScheduleTable(ref int scheduleId)
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChampionshipScheduleTable>();
			if (table == null || table.Count <= 0)
			{
				return null;
			}
			List<ComControlDataEx> list = new List<ComControlDataEx>();
			bool flag = false;
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChampionshipScheduleTable championshipScheduleTable = keyValuePair.Value as ChampionshipScheduleTable;
				if (championshipScheduleTable != null)
				{
					if (championshipScheduleTable.ScheduleType >= ChampionshipScheduleTable.eScheduleType.Eight_Select && championshipScheduleTable.ScheduleType <= ChampionshipScheduleTable.eScheduleType.One_Select)
					{
						ComControlDataEx comControlDataEx = new ComControlDataEx();
						comControlDataEx.Id = championshipScheduleTable.ID;
						comControlDataEx.Name = championshipScheduleTable.ScheduleTabContent;
						if (comControlDataEx.Id == scheduleId)
						{
							flag = true;
							comControlDataEx.IsSelected = true;
						}
						else
						{
							comControlDataEx.IsSelected = false;
						}
						list.Add(comControlDataEx);
					}
				}
			}
			list.Sort((ComControlDataEx x, ComControlDataEx y) => x.Id.CompareTo(y.Id));
			if (!flag && list.Count > 0)
			{
				ComControlDataEx comControlDataEx2 = list[0];
				if (comControlDataEx2 != null)
				{
					comControlDataEx2.IsSelected = true;
					scheduleId = comControlDataEx2.Id;
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				ComControlDataEx comControlDataEx3 = list[i];
				if (comControlDataEx3 != null)
				{
					if (comControlDataEx3.Id <= scheduleId)
					{
						comControlDataEx3.IsToggleDisabled = false;
					}
					else
					{
						comControlDataEx3.IsToggleDisabled = true;
					}
				}
			}
			return list;
		}

		// Token: 0x0600B215 RID: 45589 RVA: 0x00276FC0 File Offset: 0x002753C0
		public static ChampionshipReliveStatus GetChampionshipReliveStatus()
		{
			ChampionshipSelfSeaFightResultDataModel selfSeaFightResultDataModel = DataManager<ChampionshipDataManager>.GetInstance().SelfSeaFightResultDataModel;
			if (selfSeaFightResultDataModel == null)
			{
				return ChampionshipReliveStatus.NotNeedRelive;
			}
			return selfSeaFightResultDataModel.ReliveStatus;
		}

		// Token: 0x0600B216 RID: 45590 RVA: 0x00276FE8 File Offset: 0x002753E8
		public static List<CommonSplitDataModel> GetSplitDataModelList(int bigRewardScheduleId)
		{
			if (bigRewardScheduleId <= 0)
			{
				return null;
			}
			ChampionBigRewardPreviewTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ChampionBigRewardPreviewTable>(bigRewardScheduleId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			if (tableItem.ItemReward == null || tableItem.ItemReward.Count <= 0)
			{
				return null;
			}
			List<string> list = tableItem.ItemReward.ToList<string>();
			List<CommonSplitDataModel> list2 = new List<CommonSplitDataModel>();
			for (int i = 0; i < list.Count; i++)
			{
				string splitStr = list[i];
				CommonSplitDataModel splitDataModelByOneSplitChar = CommonUtility.GetSplitDataModelByOneSplitChar(splitStr, '_');
				if (splitDataModelByOneSplitChar != null)
				{
					list2.Add(splitDataModelByOneSplitChar);
				}
			}
			return list2;
		}

		// Token: 0x0600B217 RID: 45591 RVA: 0x0027708C File Offset: 0x0027548C
		public static List<ComControlData> GetComControlDataInBigRewardPreviewTable()
		{
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<ChampionBigRewardPreviewTable>();
			if (table == null || table.Count <= 0)
			{
				return null;
			}
			List<ChampionBigRewardPreviewTable> list = new List<ChampionBigRewardPreviewTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				ChampionBigRewardPreviewTable championBigRewardPreviewTable = keyValuePair.Value as ChampionBigRewardPreviewTable;
				if (championBigRewardPreviewTable != null)
				{
					if (championBigRewardPreviewTable.IsShowFlag != 0)
					{
						list.Add(championBigRewardPreviewTable);
					}
				}
			}
			if (list.Count <= 0)
			{
				return null;
			}
			list.Sort((ChampionBigRewardPreviewTable x, ChampionBigRewardPreviewTable y) => x.SortId.CompareTo(y.SortId));
			List<ComControlData> list2 = new List<ComControlData>();
			for (int i = 0; i < list.Count; i++)
			{
				ChampionBigRewardPreviewTable championBigRewardPreviewTable2 = list[i];
				if (championBigRewardPreviewTable2 != null)
				{
					list2.Add(new ComControlData
					{
						Name = championBigRewardPreviewTable2.ScheduleName,
						Id = championBigRewardPreviewTable2.ID,
						IsSelected = false
					});
				}
			}
			return list2;
		}

		// Token: 0x0600B218 RID: 45592 RVA: 0x002771B0 File Offset: 0x002755B0
		public static string GetChampionshipScheduleTimeStr()
		{
			ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
			if (championshipStatusInfo == null)
			{
				return string.Empty;
			}
			uint timeStamp = championshipStatusInfo.prepareStartTime;
			uint timeStamp2 = championshipStatusInfo.battleEndTime;
			if (championshipStatusInfo.status == 1U)
			{
				timeStamp = championshipStatusInfo.startTime;
				timeStamp2 = championshipStatusInfo.endTime;
			}
			string timeFormatByCommonMonthDayHourMinute = TimeUtility.GetTimeFormatByCommonMonthDayHourMinute(timeStamp);
			string timeFormatByCommonMonthDayHourMinute2 = TimeUtility.GetTimeFormatByCommonMonthDayHourMinute(timeStamp2);
			return TR.Value("Championship_Schedule_Last_Time_Format", timeFormatByCommonMonthDayHourMinute, timeFormatByCommonMonthDayHourMinute2);
		}

		// Token: 0x0600B219 RID: 45593 RVA: 0x0027721C File Offset: 0x0027561C
		public static string GetChampionshipFightStartTimeByIndex(uint index)
		{
			ChampionStatusInfo championshipStatusInfo = DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo;
			if (championshipStatusInfo == null)
			{
				return string.Empty;
			}
			uint timeStamp = championshipStatusInfo.battleStartTime + (index - 1U) * 360U;
			return TimeUtility.GetTimeFormatByHourMinute(timeStamp);
		}

		// Token: 0x0600B21A RID: 45594 RVA: 0x0027725C File Offset: 0x0027565C
		public static string GetChampionshipFightRaceStr(int fightRaceIndex)
		{
			string arg = TR.Value("Championship_Fight_Against_Race_One");
			if (fightRaceIndex == 2)
			{
				arg = TR.Value("Championship_Fight_Against_Race_Two");
			}
			else if (fightRaceIndex == 3)
			{
				arg = TR.Value("Championship_Fight_Against_Race_Three");
			}
			else if (fightRaceIndex == 4)
			{
				arg = TR.Value("Championship_Fight_Against_Race_Four");
			}
			else if (fightRaceIndex == 5)
			{
				arg = TR.Value("Championship_Fight_Against_Race_Five");
			}
			return TR.Value("Championship_Fight_Against_Race_Format", arg);
		}

		// Token: 0x0600B21B RID: 45595 RVA: 0x002772D8 File Offset: 0x002756D8
		public static bool IsShowChampionshipBubble()
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId, string.Empty, string.Empty) != null && DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenInTime && DataManager<ChampionshipDataManager>.GetInstance().IsChampionshipScheduleOpenToPlayer && DataManager<ChampionshipDataManager>.GetInstance().ChampionshipStatusInfo != null;
		}

		// Token: 0x0600B21C RID: 45596 RVA: 0x00277340 File Offset: 0x00275740
		public static bool IsFightKnockOutScheduleFinish()
		{
			List<ChampionshipKnockoutPlayerDataModel> knockoutPlayerDataModelList = DataManager<ChampionshipDataManager>.GetInstance().KnockoutPlayerDataModelList;
			if (knockoutPlayerDataModelList == null || knockoutPlayerDataModelList.Count < 2)
			{
				return false;
			}
			ChampionshipKnockoutPlayerDataModel championshipKnockoutPlayerDataModel = knockoutPlayerDataModelList[0];
			ChampionshipKnockoutPlayerDataModel championshipKnockoutPlayerDataModel2 = knockoutPlayerDataModelList[1];
			return championshipKnockoutPlayerDataModel.Score >= 3U || championshipKnockoutPlayerDataModel2.Score >= 3U;
		}

		// Token: 0x0600B21D RID: 45597 RVA: 0x0027739C File Offset: 0x0027579C
		public static bool IsChampionshipStart()
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<ChampionshipScheduleTable>(DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScheduleId, string.Empty, string.Empty) != null;
		}

		// Token: 0x0600B21E RID: 45598 RVA: 0x002773D4 File Offset: 0x002757D4
		public static string GetBetRateValueStr(uint betRateValue)
		{
			float num = betRateValue / 100f;
			return string.Format("{0:N2}", num);
		}
	}
}
