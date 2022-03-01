using System;
using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using Battle;
using ManualMD5;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010BF RID: 4287
	public class DungeonUtility
	{
		// Token: 0x0600A1F0 RID: 41456 RVA: 0x0020FF79 File Offset: 0x0020E379
		private static bool _hasGotVipRight()
		{
			return DungeonUtility.GetVipRebornSumCount() > 0;
		}

		// Token: 0x0600A1F1 RID: 41457 RVA: 0x0020FF84 File Offset: 0x0020E384
		public static int GetVipRebornSumCount()
		{
			float curVipLevelPrivilegeData = Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.FREE_REVIVE);
			if (curVipLevelPrivilegeData <= 0f)
			{
				return 0;
			}
			return (int)curVipLevelPrivilegeData;
		}

		// Token: 0x0600A1F2 RID: 41458 RVA: 0x0020FFA8 File Offset: 0x0020E3A8
		public static int GetVipRebornLeftCount()
		{
			int vipRebornSumCount = DungeonUtility.GetVipRebornSumCount();
			if (vipRebornSumCount > 0)
			{
				return vipRebornSumCount - DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_VIP_FREEREBORN_USENUM);
			}
			return -1;
		}

		// Token: 0x0600A1F3 RID: 41459 RVA: 0x0020FFD5 File Offset: 0x0020E3D5
		private static bool _isRebornLimit(int dungeonID)
		{
			return false;
		}

		// Token: 0x0600A1F4 RID: 41460 RVA: 0x0020FFD8 File Offset: 0x0020E3D8
		private static bool _isVipFreeReborn()
		{
			return DungeonUtility.GetVipRebornLeftCount() > 0;
		}

		// Token: 0x0600A1F5 RID: 41461 RVA: 0x0020FFE4 File Offset: 0x0020E3E4
		public static DungeonUtility.eDungeonRebornType GetDungeonRebornType(int dungeonID, bool isRebornSelf)
		{
			if (BattleMain.instance == null)
			{
				return DungeonUtility.eDungeonRebornType.None;
			}
			DungeonUtility.eDungeonRebornType result;
			if (DungeonUtility._isRebornLimit(dungeonID))
			{
				result = DungeonUtility.eDungeonRebornType.NoCount2Reborn;
			}
			else if (DungeonUtility._isVipFreeReborn() && isRebornSelf)
			{
				result = DungeonUtility.eDungeonRebornType.VipFreeReborn;
			}
			else
			{
				BattlePlayer localPlayer = BattleMain.instance.GetLocalPlayer(0UL);
				if (localPlayer.CanUseItem(DungeonItem.eType.RebornCoin, 1))
				{
					result = DungeonUtility.eDungeonRebornType.NormalReborn;
				}
				else if (Utility.CanQuickBuyItem(ItemTable.eSubType.ResurrectionCcurrency))
				{
					result = DungeonUtility.eDungeonRebornType.QuickBuyReborn;
				}
				else
				{
					result = DungeonUtility.eDungeonRebornType.NoCostItem2Reborn;
				}
			}
			return result;
		}

		// Token: 0x0600A1F6 RID: 41462 RVA: 0x00210064 File Offset: 0x0020E464
		public static bool CanReborn(int dungeonID, bool isRebornSelf)
		{
			if (BattleMain.instance == null)
			{
				return false;
			}
			if (BattleMain.instance.GetDungeonManager() != null && BattleMain.instance.GetDungeonManager().IsFinishFight())
			{
				return false;
			}
			DungeonUtility.eDungeonRebornType dungeonRebornType = DungeonUtility.GetDungeonRebornType(dungeonID, isRebornSelf);
			return dungeonRebornType != DungeonUtility.eDungeonRebornType.None && dungeonRebornType != DungeonUtility.eDungeonRebornType.NoCount2Reborn && dungeonRebornType != DungeonUtility.eDungeonRebornType.NoCostItem2Reborn;
		}

		// Token: 0x0600A1F7 RID: 41463 RVA: 0x002100C8 File Offset: 0x0020E4C8
		private static void _rebornCommand(byte who, byte target)
		{
			if (!BattleMain.IsModeMultiplayer(BattleMain.mode))
			{
				RebornFrameCommand rebornFrameCommand = new RebornFrameCommand();
				rebornFrameCommand.seat = who;
				rebornFrameCommand.targetSeat = target;
				FrameSync.instance.FireFrameCommand(rebornFrameCommand, false);
			}
		}

		// Token: 0x0600A1F8 RID: 41464 RVA: 0x00210104 File Offset: 0x0020E504
		private static uint _getRebornReciveID(byte seat)
		{
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(seat);
			if (playerBySeat != null)
			{
				return (uint)((int)(seat * 100) + playerBySeat.statistics.data.deadCount);
			}
			return FrameSync.instance.curFrame * 10U + (uint)seat;
		}

		// Token: 0x0600A1F9 RID: 41465 RVA: 0x0021014D File Offset: 0x0020E54D
		public static bool IsDungeonFinish()
		{
			return BattleMain.instance == null || BattleMain.instance.GetDungeonManager() == null || BattleMain.instance.GetDungeonManager().IsFinishFight();
		}

		// Token: 0x0600A1FA RID: 41466 RVA: 0x0021017C File Offset: 0x0020E57C
		public static IEnumerator Reborn(byte who, byte target, uint cnt, bool isVip = false)
		{
			SceneDungeonReviveReq req = new SceneDungeonReviveReq();
			SceneDungeonReviveRes res = new SceneDungeonReviveRes();
			MessageEvents events = new MessageEvents();
			BattlePlayer whopay = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(who);
			BattlePlayer player = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(target);
			if (player == null || whopay == null)
			{
				yield break;
			}
			req.reviveCoinNum = cnt;
			req.targetId = player.playerInfo.roleId;
			req.reviveId = DungeonUtility._getRebornReciveID(target);
			if (DungeonUtility.IsDungeonFinish())
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonFinishRebornFail, null, null, null, null);
				yield break;
			}
			ServerType serverType = ServerType.GATE_SERVER;
			MessageEvents msgEvents = events;
			SceneDungeonReviveReq req2 = req;
			SceneDungeonReviveRes res2 = res;
			bool isShowWaitFrame = true;
			float timeout = 3.5f;
			if (DungeonUtility.<>f__mg$cache0 == null)
			{
				DungeonUtility.<>f__mg$cache0 = new CanSendCallBack(DungeonUtility.IsDungeonFinish);
			}
			yield return MessageUtility.WaitWithResend<SceneDungeonReviveReq, SceneDungeonReviveRes>(serverType, msgEvents, req2, res2, isShowWaitFrame, timeout, DungeonUtility.<>f__mg$cache0);
			if (events.IsAllMessageReceived())
			{
				if (res.result == 0U)
				{
					if (!isVip)
					{
						whopay.UseItem(DungeonItem.eType.RebornCoin, (ushort)cnt);
					}
					DungeonUtility._rebornCommand(who, target);
				}
				else
				{
					SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRebornFail, target, null, null, null);
				}
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRebornFail, target, null, null, null);
			}
			yield break;
		}

		// Token: 0x0600A1FB RID: 41467 RVA: 0x002101AC File Offset: 0x0020E5AC
		public static IEnumerator QuickBuyReborn(byte who, byte target, int id)
		{
			QuickBuyFrame quickBuyFrame = QuickBuyFrame.Open(QuickBuyFrame.eQuickBuyType.FullScreen);
			quickBuyFrame.SetQuickBuyItem(id, 1);
			quickBuyFrame.SetRebornPlayerSeat(target);
			yield return Yielders.EndOfFrame;
			while (!QuickBuyFrame.IsOpen(QuickBuyFrame.eQuickBuyType.FullScreen))
			{
				yield return Yielders.EndOfFrame;
			}
			while (quickBuyFrame.state == QuickBuyFrame.eState.None)
			{
				yield return Yielders.EndOfFrame;
			}
			if (quickBuyFrame.state == QuickBuyFrame.eState.Success)
			{
				if (DungeonUtility.IsDungeonFinish())
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonFinishRebornFail, null, null, null, null);
					yield break;
				}
				MessageEvents events = new MessageEvents();
				SceneQuickBuyReq req = new SceneQuickBuyReq();
				SceneQuickBuyRes res = new SceneQuickBuyRes();
				BattlePlayer targetPlayer = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(target);
				req.type = 0;
				req.param1 = targetPlayer.playerInfo.roleId;
				req.param2 = (ulong)DungeonUtility._getRebornReciveID(target);
				ServerType serverType = ServerType.GATE_SERVER;
				MessageEvents msgEvents = events;
				SceneQuickBuyReq req2 = req;
				SceneQuickBuyRes res2 = res;
				bool isShowWaitFrame = true;
				float timeout = 3.5f;
				if (DungeonUtility.<>f__mg$cache1 == null)
				{
					DungeonUtility.<>f__mg$cache1 = new CanSendCallBack(DungeonUtility.IsDungeonFinish);
				}
				yield return MessageUtility.WaitWithResend<SceneQuickBuyReq, SceneQuickBuyRes>(serverType, msgEvents, req2, res2, isShowWaitFrame, timeout, DungeonUtility.<>f__mg$cache1);
				if (events.IsAllMessageReceived())
				{
					if (res.result != 0U)
					{
						SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRebornFail, target, null, null, null);
					}
					else
					{
						DungeonUtility._rebornCommand(who, target);
					}
				}
				else
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRebornFail, target, null, null, null);
				}
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.DungeonRebornFail, target, null, null, null);
			}
			yield break;
		}

		// Token: 0x0600A1FC RID: 41468 RVA: 0x002101D8 File Offset: 0x0020E5D8
		public static void StartRebornProcess(byte who, byte target, int dungeonID)
		{
			bool isRebornSelf = who == target;
			DungeonUtility.eDungeonRebornType dungeonRebornType = DungeonUtility.GetDungeonRebornType(dungeonID, isRebornSelf);
			if (dungeonRebornType != DungeonUtility.eDungeonRebornType.NormalReborn)
			{
				if (dungeonRebornType != DungeonUtility.eDungeonRebornType.VipFreeReborn)
				{
					if (dungeonRebornType == DungeonUtility.eDungeonRebornType.QuickBuyReborn)
					{
						int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ResurrectionCcurrency);
						Coroutine rebornCoroutine = MonoSingleton<GameFrameWork>.instance.StartCoroutine(DungeonUtility.QuickBuyReborn(who, target, moneyIDByType));
						QuickBuyFrame quickBuyFrame = Singleton<ClientSystemManager>.instance.GetFrame(QuickBuyFrame._getFrameName(QuickBuyFrame.eQuickBuyType.FullScreen)) as QuickBuyFrame;
						if (quickBuyFrame != null)
						{
							quickBuyFrame.SetRebornCoroutine(rebornCoroutine);
						}
					}
				}
				else
				{
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(DungeonUtility.Reborn(who, target, 1U, true));
				}
			}
			else
			{
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(DungeonUtility.Reborn(who, target, 1U, false));
			}
		}

		// Token: 0x0600A1FD RID: 41469 RVA: 0x0021028C File Offset: 0x0020E68C
		private static uint _getBattleEncryptKey()
		{
			uint key = DataManager<BattleDataManager>.GetInstance().BattleInfo.key1;
			uint key2 = DataManager<BattleDataManager>.GetInstance().BattleInfo.key2;
			uint key3 = DataManager<BattleDataManager>.GetInstance().BattleInfo.key3;
			uint key4 = DataManager<BattleDataManager>.GetInstance().BattleInfo.key4;
			return ((key & key4) ^ (key3 | key4 << 16)) | key2;
		}

		// Token: 0x0600A1FE RID: 41470 RVA: 0x002102E8 File Offset: 0x0020E6E8
		public static byte[] GetBattleEncryptMD5(string msg)
		{
			string s = string.Format("{0}###{1}", msg, DungeonUtility._getBattleEncryptKey());
			byte[] bytes = Encoding.UTF8.GetBytes(s);
			if (bytes == null || bytes.Length <= 0)
			{
				return new byte[16];
			}
			DungeonUtility.mManualMD5.ValueAsByte = bytes;
			byte[] fingerBytes = DungeonUtility.mManualMD5.FingerBytes;
			if (fingerBytes == null)
			{
				return new byte[16];
			}
			return fingerBytes;
		}

		// Token: 0x0600A1FF RID: 41471 RVA: 0x00210354 File Offset: 0x0020E754
		public static byte[] GetMD5(string str)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(str);
			return DungeonUtility.GetMD5(bytes);
		}

		// Token: 0x0600A200 RID: 41472 RVA: 0x00210373 File Offset: 0x0020E773
		public static string GetMD5Str(byte[] bytes)
		{
			DungeonUtility.mManualMD5.ValueAsByte = bytes;
			return DungeonUtility.mManualMD5.FingerPrint;
		}

		// Token: 0x0600A201 RID: 41473 RVA: 0x0021038C File Offset: 0x0020E78C
		public static byte[] GetMD5(byte[] bytes)
		{
			if (bytes == null)
			{
				return new byte[16];
			}
			DungeonUtility.mManualMD5.ValueAsByte = bytes;
			byte[] fingerBytes = DungeonUtility.mManualMD5.FingerBytes;
			if (fingerBytes == null)
			{
				return new byte[16];
			}
			return fingerBytes;
		}

		// Token: 0x0600A202 RID: 41474 RVA: 0x002103CC File Offset: 0x0020E7CC
		private static string _getFilePath(string path)
		{
			return Path.Combine("RawData", Path.ChangeExtension(path + "_bytes", ".bytes")).ToLower();
		}

		// Token: 0x0600A203 RID: 41475 RVA: 0x002103F4 File Offset: 0x0020E7F4
		public static ISceneData LoadSceneData(string path)
		{
			return Singleton<AssetLoader>.instance.LoadRes(path, typeof(DSceneData), true, 0U).obj as DSceneData;
		}

		// Token: 0x0600A204 RID: 41476 RVA: 0x00210428 File Offset: 0x0020E828
		public static IDungeonData LoadDungeonData(string path)
		{
			return Singleton<AssetLoader>.instance.LoadRes(path, typeof(DDungeonData), true, 0U).obj as DDungeonData;
		}

		// Token: 0x0600A205 RID: 41477 RVA: 0x0021045A File Offset: 0x0020E85A
		public static string GetSceneTransportExtraDataPath(string path)
		{
			return path.Replace("Scene/", "Data/ExTransportData/");
		}

		// Token: 0x0600A206 RID: 41478 RVA: 0x0021046C File Offset: 0x0020E86C
		public static ITransportDoorExtraData LoadSceneTransportExtraData(string path)
		{
			path = DungeonUtility.GetSceneTransportExtraDataPath(path);
			return Singleton<AssetLoader>.instance.LoadRes(path, typeof(DTransportDoorExtraData), true, 0U).obj as DTransportDoorExtraData;
		}

		// Token: 0x0600A207 RID: 41479 RVA: 0x002104A8 File Offset: 0x0020E8A8
		public static ISceneRegionInfoData CreateSceneRegionInfoData(int id, Vector3 pos)
		{
			return new DRegionInfo
			{
				resid = id,
				position = pos
			};
		}

		// Token: 0x0600A208 RID: 41480 RVA: 0x002104CC File Offset: 0x0020E8CC
		public static int GetDungeonDailyBaseTimes(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			DungeonTimesTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)tableItem.SubType, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			int num = tableItem2.BaseTimes;
			if (tableItem.SubType == DungeonTable.eSubType.S_DEVILDDOM && DataManager<ActivityDataManager>.GetInstance().GettAnniverTaskIsFinish(EAnniverBuffPrayType.XuKongChallengeNumAdd))
			{
				num += DataManager<ActivityDataManager>.GetInstance().GetAnniverTaskValue(EAnniverBuffPrayType.XuKongChallengeNumAdd);
			}
			return num;
		}

		// Token: 0x0600A209 RID: 41481 RVA: 0x00210550 File Offset: 0x0020E950
		public static int GetDungeonDailyMaxTimes(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			DungeonTimesTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)tableItem.SubType, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			int num = tableItem2.BaseTimes;
			num += DataManager<CountDataManager>.GetInstance().GetCount(tableItem2.BuyTimesCounter);
			if (tableItem.SubType == DungeonTable.eSubType.S_DEVILDDOM && DataManager<ActivityDataManager>.GetInstance().GettAnniverTaskIsFinish(EAnniverBuffPrayType.XuKongChallengeNumAdd))
			{
				num += DataManager<ActivityDataManager>.GetInstance().GetAnniverTaskValue(EAnniverBuffPrayType.XuKongChallengeNumAdd);
			}
			return num;
		}

		// Token: 0x0600A20A RID: 41482 RVA: 0x002105E4 File Offset: 0x0020E9E4
		public static int GetDungeonDailyFinishedTimes(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			DungeonTimesTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)tableItem.SubType, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			return DataManager<CountDataManager>.GetInstance().GetCount(tableItem2.UsedTimesCounter);
		}

		// Token: 0x0600A20B RID: 41483 RVA: 0x00210644 File Offset: 0x0020EA44
		public static int GetDungeonDailyLeftTimes(int dungeonId)
		{
			int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(dungeonId);
			if (dungeonDailyMaxTimes <= 0)
			{
				return 0;
			}
			int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(dungeonId);
			int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0600A20C RID: 41484 RVA: 0x00210678 File Offset: 0x0020EA78
		public static int GetDungeonWeekLeftTimes(int dungeonId)
		{
			int dungeonWeekMaxTimes = DungeonUtility.GetDungeonWeekMaxTimes(dungeonId);
			if (dungeonWeekMaxTimes <= 0)
			{
				return 0;
			}
			int dungeonWeekFinishedTimes = DungeonUtility.GetDungeonWeekFinishedTimes(dungeonId);
			int num = dungeonWeekMaxTimes - dungeonWeekFinishedTimes;
			if (num <= 0)
			{
				return 0;
			}
			return num;
		}

		// Token: 0x0600A20D RID: 41485 RVA: 0x002106AC File Offset: 0x0020EAAC
		public static int GetDungeonWeekFinishedTimes(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			DungeonTimesTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)tableItem.SubType, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			return DataManager<CountDataManager>.GetInstance().GetCount(tableItem2.WeekUsedTimesCounter);
		}

		// Token: 0x0600A20E RID: 41486 RVA: 0x0021070C File Offset: 0x0020EB0C
		public static int GetDungeonWeekMaxTimes(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			DungeonTimesTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)tableItem.SubType, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return 0;
			}
			int weekTimesLimit = tableItem2.WeekTimesLimit;
			return weekTimesLimit + DataManager<CountDataManager>.GetInstance().GetCount(tableItem2.BuyTimesCounter);
		}

		// Token: 0x0600A20F RID: 41487 RVA: 0x00210778 File Offset: 0x0020EB78
		public static string GetDungeonRebornNumber(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "0";
			}
			if (tableItem.RebornCount < 0)
			{
				return "10000";
			}
			return tableItem.RebornCount.ToString();
		}

		// Token: 0x0600A210 RID: 41488 RVA: 0x002107D0 File Offset: 0x0020EBD0
		public static string GetDungeonRebornValue(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return "0";
			}
			if (tableItem.RebornCount < 0)
			{
				return "不限";
			}
			return tableItem.RebornCount.ToString();
		}

		// Token: 0x0600A211 RID: 41489 RVA: 0x00210828 File Offset: 0x0020EC28
		public static int GetDungeonResistMagicValueById(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			return tableItem.ResistMagic;
		}

		// Token: 0x0600A212 RID: 41490 RVA: 0x0021085C File Offset: 0x0020EC5C
		public static bool IsShowDungeonResistMagicValueTip(int dungeonId, ref string content)
		{
			bool flag = false;
			int dungeonResistMagicValueById = DungeonUtility.GetDungeonResistMagicValueById(dungeonId);
			if (dungeonResistMagicValueById <= 0)
			{
				flag = false;
			}
			else if (!DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				int dungeonMainPlayerResistMagicValue = DungeonUtility.GetDungeonMainPlayerResistMagicValue();
				if (dungeonResistMagicValueById > dungeonMainPlayerResistMagicValue)
				{
					content = TR.Value("resist_magic_owner_not_enough_tip");
					string magicValueNotEnoughEffectStr = DungeonUtility.GetMagicValueNotEnoughEffectStr(dungeonMainPlayerResistMagicValue, dungeonResistMagicValueById);
					content += string.Format(TR.Value("resist_magic_owner_not_enough_value"), magicValueNotEnoughEffectStr);
					content += TR.Value("resist_magic_level_enter");
					flag = true;
				}
			}
			else
			{
				Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
				if (myTeam != null)
				{
					content = TR.Value("resist_magic_team_member_not_enough_tip");
					for (int i = 0; i < myTeam.members.Length; i++)
					{
						TeamMember teamMember = myTeam.members[i];
						if (teamMember != null && teamMember.id > 0UL)
						{
							int resistMagicValue = (int)teamMember.resistMagicValue;
							if (dungeonResistMagicValueById > resistMagicValue)
							{
								flag = true;
								string magicValueNotEnoughEffectStr2 = DungeonUtility.GetMagicValueNotEnoughEffectStr(resistMagicValue, dungeonResistMagicValueById);
								content += string.Format(TR.Value("resist_magic_team_member_not_enough_value"), teamMember.name, magicValueNotEnoughEffectStr2);
							}
						}
					}
					if (!flag)
					{
						content = string.Empty;
					}
					else
					{
						content += TR.Value("resist_magic_level_enter");
					}
				}
			}
			return flag;
		}

		// Token: 0x0600A213 RID: 41491 RVA: 0x002109AC File Offset: 0x0020EDAC
		public static string GetMagicValueNotEnoughEffectStr(int ownerResistMagicValue, int dungeonResistMagicValue)
		{
			float num = ((float)ownerResistMagicValue / (float)dungeonResistMagicValue - 1f) * 100f;
			int num2 = (int)num;
			if (num2 > 20)
			{
				num2 = 20;
			}
			else if (num2 < -70)
			{
				num2 = -70;
			}
			return string.Format("{0}%", num2);
		}

		// Token: 0x0600A214 RID: 41492 RVA: 0x002109FC File Offset: 0x0020EDFC
		public static void ShowResistMagicValueTips(int dungeonResistMagicValue)
		{
			Team myTeam = DataManager<TeamDataManager>.GetInstance().GetMyTeam();
			if (myTeam == null)
			{
				return;
			}
			for (int i = 0; i < myTeam.members.Length; i++)
			{
				TeamMember teamMember = myTeam.members[i];
				if (teamMember != null && teamMember.id > 0UL)
				{
					uint resistMagicValue = myTeam.members[i].resistMagicValue;
					if ((long)dungeonResistMagicValue > (long)((ulong)resistMagicValue))
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("resist_magic_less_tip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
				}
			}
		}

		// Token: 0x0600A215 RID: 41493 RVA: 0x00210A7E File Offset: 0x0020EE7E
		public static int GetDungeonMainPlayerResistMagicValue()
		{
			if (DataManager<PlayerBaseData>.GetInstance() == null)
			{
				return 0;
			}
			if (DataManager<PlayerBaseData>.GetInstance().ResistMagicValue <= 0)
			{
				return 0;
			}
			return DataManager<PlayerBaseData>.GetInstance().ResistMagicValue;
		}

		// Token: 0x0600A216 RID: 41494 RVA: 0x00210AA8 File Offset: 0x0020EEA8
		public static int GetDungeonRebornCount(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return -1;
			}
			return tableItem.RebornCount;
		}

		// Token: 0x0600A217 RID: 41495 RVA: 0x00210ADC File Offset: 0x0020EEDC
		public static bool IsLimitTimeHellDungeon(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			return tableItem != null && (tableItem.Type == DungeonTable.eType.L_ACTIVITY && (tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME_HELL || tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL));
		}

		// Token: 0x0600A218 RID: 41496 RVA: 0x00210B30 File Offset: 0x0020EF30
		public static bool IsLimitTimeFreeHellDungeon(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			return tableItem != null && (tableItem.Type == DungeonTable.eType.L_ACTIVITY && tableItem.SubType == DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL);
		}

		// Token: 0x0600A219 RID: 41497 RVA: 0x00210B78 File Offset: 0x0020EF78
		public static bool IsWeekHellDungeon(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL;
		}

		// Token: 0x0600A21A RID: 41498 RVA: 0x00210BB4 File Offset: 0x0020EFB4
		public static bool IsWeekHellPreDungeon(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER;
		}

		// Token: 0x0600A21B RID: 41499 RVA: 0x00210BF0 File Offset: 0x0020EFF0
		public static bool IsWeekHellEntryDungeon(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY;
		}

		// Token: 0x0600A21C RID: 41500 RVA: 0x00210C2C File Offset: 0x0020F02C
		public static bool IsWeekHellTeamDungeon(int teamDungeonId)
		{
			TeamDungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<TeamDungeonTable>(teamDungeonId, string.Empty, string.Empty);
			return tableItem != null && tableItem.DungeonID > 0 && DungeonUtility.IsWeekHellEntryDungeon(tableItem.DungeonID);
		}

		// Token: 0x0600A21D RID: 41501 RVA: 0x00210C70 File Offset: 0x0020F070
		public static WeekHellPreTaskState GetWeekHellPreTaskState(int dungeonId)
		{
			int weekHellPreTaskId = DungeonUtility.GetWeekHellPreTaskId(dungeonId);
			if (weekHellPreTaskId <= 0)
			{
				return WeekHellPreTaskState.None;
			}
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)weekHellPreTaskId, out singleMissionInfo);
			if (singleMissionInfo == null)
			{
				return WeekHellPreTaskState.IsFinished;
			}
			byte status = singleMissionInfo.status;
			if (status == 0)
			{
				return WeekHellPreTaskState.UnReceived;
			}
			if (status != 1 && status != 3)
			{
				return WeekHellPreTaskState.IsFinished;
			}
			return WeekHellPreTaskState.IsProcessing;
		}

		// Token: 0x0600A21E RID: 41502 RVA: 0x00210CD0 File Offset: 0x0020F0D0
		public static int GetWeekHellPreTaskId(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return 0;
			}
			if (tableItem.PreTaskID <= 0)
			{
				return 0;
			}
			return tableItem.PreTaskID;
		}

		// Token: 0x0600A21F RID: 41503 RVA: 0x00210D10 File Offset: 0x0020F110
		public static int GetWeekHellPreTaskDungeonId(int dungeonId)
		{
			int weekHellPreTaskId = DungeonUtility.GetWeekHellPreTaskId(dungeonId);
			if (weekHellPreTaskId <= 0)
			{
				return dungeonId;
			}
			MissionTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MissionTable>(weekHellPreTaskId, string.Empty, string.Empty);
			if (tableItem == null || tableItem.MapID <= 0)
			{
				return dungeonId;
			}
			return tableItem.MapID;
		}

		// Token: 0x0600A220 RID: 41504 RVA: 0x00210D60 File Offset: 0x0020F160
		public static bool IsWeekHellDungeonCanAgain(int dungeonId)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_PER)
			{
				bool flag = DungeonUtility.IsDungeonStoryTaskFinished(tableItem.storyTaskID);
				return !flag;
			}
			if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL)
			{
				int ownerEntryId = tableItem.ownerEntryId;
				return DungeonUtility.GetDungeonWeekLeftTimes(ownerEntryId) > 0 && DungeonUtility.GetDungeonDailyLeftTimes(ownerEntryId) > 0;
			}
			return tableItem.SubType != DungeonTable.eSubType.S_WEEK_HELL_ENTRY || (DungeonUtility.GetDungeonWeekLeftTimes(dungeonId) > 0 && DungeonUtility.GetDungeonDailyLeftTimes(dungeonId) > 0);
		}

		// Token: 0x0600A221 RID: 41505 RVA: 0x00210E0C File Offset: 0x0020F20C
		public static bool IsDungeonStoryTaskFinished(int storyTaskId)
		{
			MissionManager.SingleMissionInfo singleMissionInfo = null;
			DataManager<MissionManager>.GetInstance().taskGroup.TryGetValue((uint)storyTaskId, out singleMissionInfo);
			if (singleMissionInfo == null)
			{
				return true;
			}
			byte status = singleMissionInfo.status;
			return status != 0 && (status != 1 && status != 3);
		}

		// Token: 0x0600A222 RID: 41506 RVA: 0x00210E5C File Offset: 0x0020F25C
		public static DungeonModelTable.eType GetDugeonModleTypeById(int dungeonID)
		{
			DungeonModelTable.eType result = DungeonModelTable.eType.Type_None;
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.SubType == DungeonTable.eSubType.S_HELL_ENTRY || tableItem.SubType == DungeonTable.eSubType.S_HELL)
				{
					result = DungeonModelTable.eType.DeepModel;
				}
				else if (tableItem.SubType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY)
				{
					result = DungeonModelTable.eType.WeekHellModel;
				}
				else if (tableItem.SubType == DungeonTable.eSubType.S_DEVILDDOM)
				{
					result = DungeonModelTable.eType.Type_None;
				}
				else if (tableItem.SubType == DungeonTable.eSubType.S_YUANGU)
				{
					result = DungeonModelTable.eType.AncientModel;
				}
			}
			return result;
		}

		// Token: 0x0600A223 RID: 41507 RVA: 0x00210EE0 File Offset: 0x0020F2E0
		public static DungeonModelTable.eType GetDugeonModleTypeById(DungeonTable.eSubType subType)
		{
			DungeonModelTable.eType result = DungeonModelTable.eType.Type_None;
			if (subType == DungeonTable.eSubType.S_HELL_ENTRY || subType == DungeonTable.eSubType.S_HELL)
			{
				result = DungeonModelTable.eType.DeepModel;
			}
			else if (subType == DungeonTable.eSubType.S_WEEK_HELL_ENTRY)
			{
				result = DungeonModelTable.eType.WeekHellModel;
			}
			else if (subType == DungeonTable.eSubType.S_DEVILDDOM)
			{
				result = DungeonModelTable.eType.Type_None;
			}
			else if (subType == DungeonTable.eSubType.S_YUANGU)
			{
				result = DungeonModelTable.eType.AncientModel;
			}
			return result;
		}

		// Token: 0x04005A50 RID: 23120
		private static MD5 mManualMD5 = new MD5();

		// Token: 0x04005A51 RID: 23121
		[CompilerGenerated]
		private static CanSendCallBack <>f__mg$cache0;

		// Token: 0x04005A52 RID: 23122
		[CompilerGenerated]
		private static CanSendCallBack <>f__mg$cache1;

		// Token: 0x020010C0 RID: 4288
		public enum eDungeonRebornType
		{
			// Token: 0x04005A54 RID: 23124
			None,
			// Token: 0x04005A55 RID: 23125
			VipFreeReborn,
			// Token: 0x04005A56 RID: 23126
			NormalReborn,
			// Token: 0x04005A57 RID: 23127
			QuickBuyReborn,
			// Token: 0x04005A58 RID: 23128
			NoCostItem2Reborn,
			// Token: 0x04005A59 RID: 23129
			NoCount2Reborn
		}
	}
}
