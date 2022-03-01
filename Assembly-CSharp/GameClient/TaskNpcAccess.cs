using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004625 RID: 17957
	public class TaskNpcAccess
	{
		// Token: 0x060193C1 RID: 103361 RVA: 0x007FB991 File Offset: 0x007F9D91
		public static void RemoveMissionListener(int iNpcID, int iMissionID)
		{
		}

		// Token: 0x060193C2 RID: 103362 RVA: 0x007FB994 File Offset: 0x007F9D94
		public static void AddMissionListener(uint iTaskID)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			if (!DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue(iTaskID, out singleMissionInfo))
			{
				return;
			}
			MissionTable tableItem = Singleton<TableManager>.instance.GetTableItem<MissionTable>((int)singleMissionInfo.taskID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int num = 0;
			if (singleMissionInfo.status == 0)
			{
				if (tableItem.AcceptType == MissionTable.eAcceptType.ACT_NPC)
				{
					num = tableItem.MissionTakeNpc;
				}
			}
			else if (singleMissionInfo.status == 2 && tableItem.FinishType == MissionTable.eFinishType.FINISH_TYPE_NPC)
			{
				num = tableItem.MissionFinishNpc;
			}
			if (Singleton<TableManager>.instance.GetTableItem<NpcTable>(num, string.Empty, string.Empty) == null)
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				clientSystemTown.AddMissionListenerForNpc(num, (int)iTaskID);
			}
		}

		// Token: 0x060193C3 RID: 103363 RVA: 0x007FBA6C File Offset: 0x007F9E6C
		public static void AddDialogListener(int iNpcID)
		{
			if (Singleton<ClientSystemManager>.GetInstance().CurrentSystem is ClientSystemTown)
			{
				ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
				clientSystemTown.AddDialogListener(iNpcID);
			}
		}

		// Token: 0x060193C4 RID: 103364 RVA: 0x007FBAA4 File Offset: 0x007F9EA4
		public static void OnClickFunctionNpc(int iNpcID, ulong guid = 0UL, string strParam = "")
		{
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcID, string.Empty, string.Empty);
			if (tableItem == null || tableItem.Function == NpcTable.eFunction.none)
			{
				return;
			}
			if (tableItem.OpenLevel > (int)DataManager<PlayerBaseData>.GetInstance().Level)
			{
				TalkTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(tableItem.FunctionIntParam2, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					DataManager<MissionManager>.GetInstance().CloseAllDialog();
					DataManager<MissionManager>.GetInstance().CreateDialogFrame(tableItem.FunctionIntParam2, 0, null);
				}
				return;
			}
			if (tableItem.Function == NpcTable.eFunction.production)
			{
				TaskNpcAccess.DoErrorHint(iNpcID);
			}
			else if (tableItem.Function == NpcTable.eFunction.shopping)
			{
				if (tableItem.FunctionIntParam.Count == 1)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ShopNewFrame>(null, false);
					if (string.IsNullOrEmpty(strParam))
					{
						bool flag = false;
						for (int i = 0; i < TaskNpcAccess.iExchangeMallNPCID.Length; i++)
						{
							if (TaskNpcAccess.iExchangeMallNPCID[i] == tableItem.ID)
							{
								flag = true;
							}
						}
						if (flag)
						{
							DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(24, tableItem.FunctionIntParam[0], 0, iNpcID);
						}
						else
						{
							DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(tableItem.FunctionIntParam[0], 0, 0, iNpcID);
						}
					}
					else
					{
						string[] array = strParam.Split(new char[]
						{
							'|'
						});
						if (array.Length == 3)
						{
							int shopId = tableItem.FunctionIntParam[0];
							int num = int.Parse(array[1]);
							int shopItemType = int.Parse(array[2]);
							DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(shopId, 0, shopItemType, iNpcID);
						}
						else
						{
							DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(tableItem.FunctionIntParam[0], 0, 0, iNpcID);
						}
					}
				}
			}
			else if (tableItem.Function == NpcTable.eFunction.strengthen)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.enchanting)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<SmithShopNewFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SmithShopNewFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.store)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<StorageGroupFrame>(null, false);
				ItemGroupData itemGroupData = new ItemGroupData();
				itemGroupData.isPackage = false;
				itemGroupData.ePackageType = EPackageType.Equip;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<StorageGroupFrame>(FrameLayer.Middle, itemGroupData, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.mail)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MailNewFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<MailNewFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.Townstatue)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<TownStatueTalkFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<TownStatueTalkFrame>(FrameLayer.Middle, (byte)tableItem.SubType, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.guildGuardStatue)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GuildGuardStatueTalkFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<GuildGuardStatueTalkFrame>(FrameLayer.Middle, (byte)tableItem.SubType, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.guildDungeonActivityChest)
			{
				DataManager<GuildDataManager>.GetInstance().TryGetGuildDungeonActivityChestAward();
			}
			else if (tableItem.Function == NpcTable.eFunction.TAPGraduation)
			{
				List<RelationData> relation = DataManager<RelationDataManager>.GetInstance().GetRelation(5);
				List<RelationData> relation2 = DataManager<RelationDataManager>.GetInstance().GetRelation(4);
				if (relation.Count + relation2.Count > 0)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<TAPSubmitGraduationFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else
				{
					TaskNpcAccess.openNormalTalk(tableItem);
				}
			}
			else if (tableItem.Function == NpcTable.eFunction.RandomTreasure)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<RandomTreasureFrame>(null, false);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<RandomTreasureFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.BlackMarketMerchan)
			{
				if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.BlackMarket))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<BlackMarketMerchantTalkFrame>(FrameLayer.Middle, null, string.Empty);
					return;
				}
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<BlackMarketMerchantFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<BlackMarketMerchantFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<BlackMarketMerchantFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.Chiji)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChijiNpcDialogFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChijiNpcDialogFrame>(null, false);
				}
				ChijiNpcData chijiNpcData = new ChijiNpcData();
				chijiNpcData.npcTableId = iNpcID;
				chijiNpcData.guid = guid;
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChijiNpcDialogFrame>(FrameLayer.Middle, chijiNpcData, string.Empty);
			}
			else if (tableItem.Function == NpcTable.eFunction.AnniersaryParty)
			{
				if (DataManager<PlayerBaseData>.GetInstance().Level >= 20)
				{
					ChapterSelectFrame.SetSceneID(6038);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChapterSelectFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AnniversaryPartyTalkFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<AnniversaryPartyTalkFrame>(FrameLayer.Middle, iNpcID, string.Empty);
				}
			}
			else if (tableItem.Function == NpcTable.eFunction.SendDoor)
			{
				int functionUnlockLevel = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.SendDoor);
				if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= functionUnlockLevel)
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<MiyaSendDoorFrame>(null, false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MiyaSendDoorFrame>(FrameLayer.Middle, null, string.Empty);
				}
				else
				{
					FunctionUnLock tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(98, string.Empty, string.Empty);
					if (tableItem3 != null)
					{
						SystemNotifyManager.SystemNotify(tableItem3.CommDescID, string.Empty);
					}
				}
			}
			else
			{
				TaskNpcAccess.DoErrorHint(iNpcID);
			}
		}

		// Token: 0x060193C5 RID: 103365 RVA: 0x007FC018 File Offset: 0x007FA418
		private static void openNormalTalk(NpcTable npcItem)
		{
			int num = int.Parse(npcItem.NpcTalk);
			TalkTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TalkTable>(num, string.Empty, string.Empty);
			if (tableItem != null)
			{
				TaskDialogFrame.OnDialogOver callback = new TaskDialogFrame.OnDialogOver().AddListener(delegate
				{
					ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
					if (clientSystemTown != null)
					{
						clientSystemTown.PlayNpcSound(npcItem.ID, NpcVoiceComponent.SoundEffectType.SET_End);
					}
				});
				DataManager<MissionManager>.GetInstance().CreateDialogFrame(num, 0, callback);
			}
		}

		// Token: 0x060193C6 RID: 103366 RVA: 0x007FC084 File Offset: 0x007FA484
		public static void OnClickNpc(BeTownNPCData townData)
		{
			if (townData == null)
			{
				return;
			}
			if (!TaskNpcAccess.CanClick())
			{
				return;
			}
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(townData.NpcID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.Function == NpcTable.eFunction.store)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<StorageGroupFrame>(null))
				{
					ItemGroupData itemGroupData = new ItemGroupData();
					itemGroupData.isPackage = false;
					itemGroupData.ePackageType = EPackageType.Equip;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<StorageGroupFrame>(FrameLayer.Middle, itemGroupData, string.Empty);
				}
			}
			else if (tableItem.Function == NpcTable.eFunction.mail)
			{
				if (!Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MailNewFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<MailNewFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}
			else if (tableItem.Function == NpcTable.eFunction.guildDungeonActivityChest)
			{
				DataManager<GuildDataManager>.GetInstance().TryGetGuildDungeonActivityChestAward();
			}
		}

		// Token: 0x060193C7 RID: 103367 RVA: 0x007FC15C File Offset: 0x007FA55C
		public static void DoErrorHint(int iNpcID)
		{
			NpcTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(iNpcID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				Logger.LogErrorFormat("[npc]请做 [{0} 系统] 的程序员在此加入功能接口! npcname = [{1}] id = {2}", new object[]
				{
					Utility.GetNpcFunctionName(iNpcID),
					tableItem.NpcName,
					tableItem.ID
				});
			}
		}

		// Token: 0x060193C8 RID: 103368 RVA: 0x007FC1B5 File Offset: 0x007FA5B5
		private static bool CanClick()
		{
			if (TaskNpcAccess.ms_fLastClickTime + TaskNpcAccess.ms_clickInterval < Time.time)
			{
				TaskNpcAccess.ms_fLastClickTime = Time.time;
				return true;
			}
			return false;
		}

		// Token: 0x060193C9 RID: 103369 RVA: 0x007FC1DC File Offset: 0x007FA5DC
		public static void OnClickFightPlayer(BeFighterData beFighterData, CitySceneTable.eSceneType sceneType, Transform transform)
		{
			if (!TaskNpcAccess.CanClick())
			{
				return;
			}
			if (beFighterData == null)
			{
				return;
			}
			if (beFighterData.GUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			if (sceneType == CitySceneTable.eSceneType.BATTLE)
			{
				if (!DataManager<ChijiDataManager>.GetInstance().IsReadyPk)
				{
					SystemNotifyManager.SysNotifyTextAnimation("你未开启挑战,请点击挑战按钮", CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage < ChiJiTimeTable.eBattleStage.BS_START_PK)
				{
					SystemNotifyManager.SysNotifyTextAnimation("PK尚未开始,无法开启挑战", CommonTipsDesc.eShowMode.SI_UNIQUE);
					return;
				}
				ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
				if (clientSystemGameBattle != null)
				{
					Vector3 vector = Vector3.zero;
					vector = beFighterData.MoveData.Position - clientSystemGameBattle.MainPlayer.ActorData.MoveData.Position;
					vector.y = 0f;
					float num = Mathf.Sqrt(vector.sqrMagnitude);
					if (num > 5.4f)
					{
						SystemNotifyManager.SysNotifyTextAnimation("超出攻击范围", CommonTipsDesc.eShowMode.SI_UNIQUE);
						return;
					}
				}
				List<ulong> otherDeadPlayers = DataManager<ChijiDataManager>.GetInstance().OtherDeadPlayers;
				for (int i = 0; i < otherDeadPlayers.Count; i++)
				{
					if (otherDeadPlayers[i] == beFighterData.GUID)
					{
						SystemNotifyManager.SysNotifyTextAnimation("玩家已被淘汰，不可挑战", CommonTipsDesc.eShowMode.SI_UNIQUE);
						break;
					}
				}
				if (clientSystemGameBattle != null && clientSystemGameBattle.MainPlayer != null)
				{
					DataManager<ChijiDataManager>.GetInstance().SendBattlePkSomeOneReq(beFighterData.GUID, clientSystemGameBattle.MainPlayer.GetPKDungeonID());
				}
			}
			else
			{
				if (DataManager<ChijiDataManager>.GetInstance().IsMatching)
				{
					SystemNotifyManager.SystemNotify(4200006, string.Empty);
					return;
				}
				TaskNpcAccess._AddChijiFunctionMenu(beFighterData, transform, null);
			}
		}

		// Token: 0x060193CA RID: 103370 RVA: 0x007FC364 File Offset: 0x007FA764
		public static void OnClickTownPlayer(BeTownPlayerData beTownPlayerData, Transform transform)
		{
			if (!TaskNpcAccess.CanClick())
			{
				return;
			}
			if (beTownPlayerData == null)
			{
				return;
			}
			if (beTownPlayerData.GUID == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown != null)
			{
				TaskNpcAccess._AddNormalFunctionMenu(beTownPlayerData, transform, clientSystemTown);
			}
		}

		// Token: 0x060193CB RID: 103371 RVA: 0x007FC3B8 File Offset: 0x007FA7B8
		private static void _AddNormalFunctionMenu(BeTownPlayerData beTownPlayerData, Transform transform, ClientSystemTown systemTown)
		{
			MenuData menuData = new MenuData();
			menuData.kWorldPos = transform.position;
			menuData.name = beTownPlayerData.Name;
			menuData.items = new List<MenuItem>();
			menuData.level = (int)beTownPlayerData.RoleLv;
			menuData.vip = beTownPlayerData.vip;
			menuData.guildName = beTownPlayerData.GuildName;
			menuData.pkLevel = beTownPlayerData.pkRank;
			menuData.jobID = beTownPlayerData.JobID;
			menuData.ZoneID = beTownPlayerData.ZoneID;
			menuData.adventureTeamName = beTownPlayerData.AdventureTeamName;
			menuData.WearedTitleInfo = beTownPlayerData.WearedTitleInfo;
			menuData.guildLv = beTownPlayerData.GuildEmblemLv;
			ulong guid = beTownPlayerData.GUID;
			RelationData relationData = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(guid);
			bool flag = relationData != null && relationData.IsFriend();
			menuData.items.Add(new MenuItem
			{
				name = "查看信息",
				callback = delegate()
				{
					DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(guid, 0U, 0U);
				}
			});
			menuData.items.Add(new MenuItem
			{
				name = "私密聊天",
				callback = delegate()
				{
					RelationData relationData = relationData;
					if (relationData == null)
					{
						relationData = new RelationData();
						relationData.level = (ushort)menuData.level;
						relationData.uid = guid;
						relationData.name = menuData.name;
						relationData.occu = (byte)menuData.jobID;
						relationData.vipLv = (byte)menuData.vip;
					}
					DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(relationData);
				}
			});
			if (!flag)
			{
				menuData.items.Add(new MenuItem
				{
					name = "添加好友",
					callback = delegate()
					{
						int num = 0;
						FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							num = tableItem2.FinishLevel;
						}
						object[] args = new object[]
						{
							num
						};
						if ((int)DataManager<PlayerBaseData>.GetInstance().Level < num)
						{
							SystemNotifyManager.SystemNotify(1237, args);
							return;
						}
						if (menuData.level < num)
						{
							SystemNotifyManager.SystemNotify(1236, args);
							return;
						}
						DataManager<RelationDataManager>.GetInstance().AddFriendByID(guid);
					}
				});
			}
			else
			{
				menuData.items.Add(new MenuItem
				{
					name = "删除好友",
					callback = delegate()
					{
						DataManager<RelationDataManager>.GetInstance().DelFriend(guid);
					}
				});
			}
			menuData.items.Add(new MenuItem
			{
				name = "邀请组队",
				callback = delegate()
				{
					DataManager<TeamDataManager>.GetInstance().TeamInviteOtherPlayer(guid);
				}
			});
			menuData.items.Add(new MenuItem
			{
				name = "申请入队",
				callback = delegate()
				{
					DataManager<TeamDataManager>.GetInstance().JoinOtherPlayerTeam(guid);
				}
			});
			if (!menuData.HasGuild() && DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				menuData.items.Add(new MenuItem
				{
					name = "邀请入会",
					callback = delegate()
					{
						DataManager<GuildDataManager>.GetInstance().InviteJoinGuild(guid);
					}
				});
			}
			RelationData rd = relationData;
			if (rd == null)
			{
				rd = new RelationData();
				rd.level = (ushort)menuData.level;
				rd.uid = guid;
				rd.name = menuData.name;
				rd.occu = (byte)menuData.jobID;
				rd.vipLv = (byte)menuData.vip;
			}
			if (RelationMenuFram._CheckGetPupil(rd))
			{
				menuData.items.Add(new MenuItem
				{
					name = "收为弟子",
					callback = delegate()
					{
						RelationMenuFram._OnAskForPupil(rd);
					}
				});
			}
			if (RelationMenuFram._CheckGetTeacher(rd))
			{
				menuData.items.Add(new MenuItem
				{
					name = "拜师",
					callback = delegate()
					{
						RelationMenuFram._OnAskForTeacher(rd);
						DataManager<TAPDataManager>.GetInstance().AddQueryInfo(rd.uid);
					}
				});
			}
			if (rd.type == 4 || rd.type == 5)
			{
				menuData.items.Add(new MenuItem
				{
					name = "解除师徒",
					callback = delegate()
					{
						RelationMenuFram._OnFireTeacher(rd);
					}
				});
			}
			menuData.items.Add(new MenuItem
			{
				name = "加入黑名单",
				callback = delegate()
				{
					string msgContent = string.Format("是否加入黑名单?", new object[0]);
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						DataManager<RelationDataManager>.GetInstance().AddBlackList(beTownPlayerData.GUID);
					}, delegate()
					{
					}, 0f, false);
				}
			});
			bool flag2 = true;
			if (menuData.ZoneID != DataManager<PlayerBaseData>.GetInstance().ZoneID)
			{
				flag2 = false;
			}
			if (systemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(systemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossGuildBattle)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
				{
					return;
				}
				if (DataManager<Pk2v2CrossDataManager>.GetInstance().CheckPk2v2CrossScence())
				{
					return;
				}
				if (Pk3v3DataManager.HasInPk3v3Room())
				{
					return;
				}
				ActorShowMenu.Open(menuData);
			}
		}

		// Token: 0x060193CC RID: 103372 RVA: 0x007FC900 File Offset: 0x007FAD00
		private static void _AddChijiFunctionMenu(BeFighterData beTownPlayerData, Transform transform, ClientSystemTown systemTown)
		{
			MenuData menuData = new MenuData();
			menuData.kWorldPos = transform.position;
			menuData.name = beTownPlayerData.Name;
			menuData.items = new List<MenuItem>();
			menuData.level = (int)beTownPlayerData.RoleLv;
			menuData.vip = beTownPlayerData.vip;
			menuData.guildName = beTownPlayerData.GuildName;
			menuData.pkLevel = beTownPlayerData.pkRank;
			menuData.jobID = beTownPlayerData.JobID;
			menuData.ZoneID = beTownPlayerData.ZoneID;
			menuData.adventureTeamName = beTownPlayerData.AdventureTeamName;
			menuData.WearedTitleInfo = beTownPlayerData.WearedTitleInfo;
			menuData.guildLv = beTownPlayerData.GuildEmblemLv;
			ulong guid = beTownPlayerData.GUID;
			RelationData relationData = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(guid);
			bool flag = relationData != null && relationData.IsFriend();
			menuData.items.Add(new MenuItem
			{
				name = "查看信息",
				callback = delegate()
				{
					DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(guid, 0U, 0U);
				}
			});
			menuData.items.Add(new MenuItem
			{
				name = "私密聊天",
				callback = delegate()
				{
					RelationData relationData = relationData;
					if (relationData == null)
					{
						relationData = new RelationData();
						relationData.level = (ushort)menuData.level;
						relationData.uid = guid;
						relationData.name = menuData.name;
						relationData.occu = (byte)menuData.jobID;
						relationData.vipLv = (byte)menuData.vip;
					}
					DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(relationData);
				}
			});
			if (!flag)
			{
				menuData.items.Add(new MenuItem
				{
					name = "添加好友",
					callback = delegate()
					{
						int num = 0;
						FunctionUnLock tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							num = tableItem2.FinishLevel;
						}
						object[] args = new object[]
						{
							num
						};
						if ((int)DataManager<PlayerBaseData>.GetInstance().Level < num)
						{
							SystemNotifyManager.SystemNotify(1237, args);
							return;
						}
						if (menuData.level < num)
						{
							SystemNotifyManager.SystemNotify(1236, args);
							return;
						}
						DataManager<RelationDataManager>.GetInstance().AddFriendByID(guid);
					}
				});
			}
			else
			{
				menuData.items.Add(new MenuItem
				{
					name = "删除好友",
					callback = delegate()
					{
						DataManager<RelationDataManager>.GetInstance().DelFriend(guid);
					}
				});
			}
			if (!menuData.HasGuild() && DataManager<GuildDataManager>.GetInstance().myGuild != null)
			{
				menuData.items.Add(new MenuItem
				{
					name = "邀请入会",
					callback = delegate()
					{
						DataManager<GuildDataManager>.GetInstance().InviteJoinGuild(guid);
					}
				});
			}
			RelationData rd = relationData;
			if (rd == null)
			{
				rd = new RelationData();
				rd.level = (ushort)menuData.level;
				rd.uid = guid;
				rd.name = menuData.name;
				rd.occu = (byte)menuData.jobID;
				rd.vipLv = (byte)menuData.vip;
			}
			if (RelationMenuFram._CheckGetPupil(rd))
			{
				menuData.items.Add(new MenuItem
				{
					name = "收为弟子",
					callback = delegate()
					{
						RelationMenuFram._OnAskForPupil(rd);
					}
				});
			}
			if (RelationMenuFram._CheckGetTeacher(rd))
			{
				menuData.items.Add(new MenuItem
				{
					name = "拜师",
					callback = delegate()
					{
						RelationMenuFram._OnAskForTeacher(rd);
						DataManager<TAPDataManager>.GetInstance().AddQueryInfo(rd.uid);
					}
				});
			}
			if (rd.type == 4 || rd.type == 5)
			{
				menuData.items.Add(new MenuItem
				{
					name = "解除师徒",
					callback = delegate()
					{
						RelationMenuFram._OnFireTeacher(rd);
					}
				});
			}
			menuData.items.Add(new MenuItem
			{
				name = "加入黑名单",
				callback = delegate()
				{
					string msgContent = string.Format("是否加入黑名单?", new object[0]);
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						DataManager<RelationDataManager>.GetInstance().AddBlackList(beTownPlayerData.GUID);
					}, delegate()
					{
					}, 0f, false);
				}
			});
			bool flag2 = true;
			if (menuData.ZoneID != DataManager<PlayerBaseData>.GetInstance().ZoneID)
			{
				flag2 = false;
			}
			if (systemTown != null)
			{
				CitySceneTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CitySceneTable>(systemTown.CurrentSceneID, string.Empty, string.Empty);
				if (tableItem != null && DataManager<GuildDataManager>.GetInstance().GetGuildBattleType() == GuildBattleType.GBT_CROSS && tableItem.SceneSubType == CitySceneTable.eSceneSubType.CrossGuildBattle)
				{
					flag2 = false;
				}
			}
			if (flag2)
			{
				if (DataManager<Pk3v3CrossDataManager>.GetInstance().CheckPk3v3CrossScence())
				{
					return;
				}
				if (DataManager<Pk2v2CrossDataManager>.GetInstance().CheckPk2v2CrossScence())
				{
					return;
				}
				if (Pk3v3DataManager.HasInPk3v3Room())
				{
					return;
				}
				ActorShowMenu.Open(menuData);
			}
		}

		// Token: 0x060193CD RID: 103373 RVA: 0x007FCDDD File Offset: 0x007FB1DD
		public static void OnClickBlank()
		{
			if (!TaskNpcAccess.CanClick())
			{
				return;
			}
			ActorShowMenu.CloseMenu();
		}

		// Token: 0x060193CE RID: 103374 RVA: 0x007FCDF0 File Offset: 0x007FB1F0
		public static Vector3 WordToScenePoint(Vector3 wordPosition)
		{
			CanvasScaler component = GameObject.Find("UIRoot").transform.Find("UI2DRoot").GetComponent<CanvasScaler>();
			float x = component.referenceResolution.x;
			float y = component.referenceResolution.y;
			float num = (float)Screen.width / component.referenceResolution.x * (1f - component.matchWidthOrHeight) + (float)Screen.height / component.referenceResolution.y * component.matchWidthOrHeight;
			Vector2 vector = RectTransformUtility.WorldToScreenPoint(Camera.main, wordPosition);
			return new Vector3(vector.x / num, vector.y / num, 0f);
		}

		// Token: 0x0401218A RID: 74122
		private static int[] iExchangeMallNPCID = new int[]
		{
			2019,
			2029,
			2073,
			2023
		};

		// Token: 0x0401218B RID: 74123
		private static float ms_fLastClickTime = 0f;

		// Token: 0x0401218C RID: 74124
		private static float ms_clickInterval = 0.5f;
	}
}
