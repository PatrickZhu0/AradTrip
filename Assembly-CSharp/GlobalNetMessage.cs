using System;
using System.Collections;
using System.Collections.Generic;
using AdsPush;
using Battle;
using GameClient;
using Network;
using Protocol;
using ProtoTable;

// Token: 0x020010CF RID: 4303
[LoggerModel("GlobalNotify")]
public class GlobalNetMessage : GameBindSystem
{
	// Token: 0x170019A2 RID: 6562
	// (get) Token: 0x0600A2B4 RID: 41652 RVA: 0x0021358D File Offset: 0x0021198D
	public static GlobalNetMessage instance
	{
		get
		{
			if (GlobalNetMessage.mInstance == null)
			{
				GlobalNetMessage.mInstance = new GlobalNetMessage();
			}
			return GlobalNetMessage.mInstance;
		}
	}

	// Token: 0x0600A2B5 RID: 41653 RVA: 0x002135A8 File Offset: 0x002119A8
	public void Load()
	{
		if (GlobalNetMessage.mInstance != null)
		{
			GlobalNetMessage.mInstance.InitBindSystem(null);
		}
	}

	// Token: 0x0600A2B6 RID: 41654 RVA: 0x002135BF File Offset: 0x002119BF
	public void Unload()
	{
		if (GlobalNetMessage.mInstance != null)
		{
			GlobalNetMessage.mInstance.ExistBindSystem();
			GlobalNetMessage.mInstance = null;
		}
	}

	// Token: 0x0600A2B7 RID: 41655 RVA: 0x002135DC File Offset: 0x002119DC
	[ProtocolHandle(typeof(SceneNotifyRemoveBuff))]
	private void _onSceneNotifyRemoveBuff(SceneNotifyRemoveBuff rep)
	{
		List<Battle.DungeonBuff> buffList = DataManager<PlayerBaseData>.GetInstance().buffList;
		List<Battle.DungeonBuff> removedBuffList = DataManager<PlayerBaseData>.GetInstance().removedBuffList;
		int num = buffList.RemoveAll((Battle.DungeonBuff buff) => (long)buff.id == (long)((ulong)rep.buffId));
		if (num > 0)
		{
		}
		int num2 = removedBuffList.RemoveAll((Battle.DungeonBuff buff) => (long)buff.id == (long)((ulong)rep.buffId));
		if (num2 > 0)
		{
		}
		UIEventSystem.GetInstance().SendUIEvent(EUIEventID.BuffRemoved, (int)rep.buffId, null, null, null);
	}

	// Token: 0x0600A2B8 RID: 41656 RVA: 0x00213664 File Offset: 0x00211A64
	[ProtocolHandle(typeof(SceneDungeonChestNotify))]
	private void _onSceneDungeonChestNotify(SceneDungeonChestNotify res)
	{
		DataManager<BattleDataManager>.GetInstance().chestInfo.count = res.payChestCost;
		DataManager<BattleDataManager>.GetInstance().chestInfo.itemId = res.payChestCostItemId;
	}

	// Token: 0x0600A2B9 RID: 41657 RVA: 0x00213690 File Offset: 0x00211A90
	[ProtocolHandle(typeof(SysNotify))]
	private void _onSysNotify(SysNotify rep)
	{
		SystemNotifyManager.SysNotifyFromServer(rep);
	}

	// Token: 0x0600A2BA RID: 41658 RVA: 0x00213698 File Offset: 0x00211A98
	[ProtocolHandle(typeof(SysAnnouncement))]
	private void _onAnnouncement(SysAnnouncement rep)
	{
		DataManager<AnnouncementManager>.GetInstance().AnnounceFromServer(rep);
	}

	// Token: 0x0600A2BB RID: 41659 RVA: 0x002136A8 File Offset: 0x00211AA8
	[ProtocolHandle(typeof(SceneSyncFuncUnlock))]
	private void _onNewFuncUnlock(SceneSyncFuncUnlock rep)
	{
		FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)rep.funcId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (!tableItem.IsOpen)
		{
			return;
		}
		if (tableItem.BindType == FunctionUnLock.eBindType.BT_AccBind)
		{
			return;
		}
		if (tableItem.Type == FunctionUnLock.eType.Area)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewAreaUnlock, tableItem.AreaID, null, null, null);
		}
		else if (tableItem.Type == FunctionUnLock.eType.Func)
		{
			if (tableItem.bPlayAnim == 1)
			{
				if (!DataManager<PlayerBaseData>.GetInstance().IsFlyUpState)
				{
					if (!DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains((int)rep.funcId))
					{
						DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Add((int)rep.funcId);
					}
					if (tableItem.FuncType == FunctionUnLock.eFuncType.AdventurePassSeason)
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, true, null, null, null);
					}
				}
			}
			else
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockNotPlayFuncList.Add((int)rep.funcId);
				if (tableItem.FuncType == FunctionUnLock.eFuncType.AdventurePassSeason)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.UpdateAventurePassButtonRedPoint, true, null, null, null);
				}
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewFuncUnlock, rep.funcId, tableItem.FuncType, null, null);
		}
	}

	// Token: 0x0600A2BC RID: 41660 RVA: 0x00213800 File Offset: 0x00211C00
	[ProtocolHandle(typeof(WorldSyncFuncUnlock))]
	private void _OnAccountFuncUnlock(WorldSyncFuncUnlock res)
	{
		if (res == null)
		{
			return;
		}
		FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>((int)res.funcId, string.Empty, string.Empty);
		if (tableItem == null)
		{
			return;
		}
		if (!tableItem.IsOpen)
		{
			return;
		}
		if (tableItem.BindType == FunctionUnLock.eBindType.BT_RoleBind)
		{
			return;
		}
		if (tableItem.Type == FunctionUnLock.eType.Func)
		{
			if (tableItem.bPlayAnim == 1 && !DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Contains((int)res.funcId))
			{
				DataManager<PlayerBaseData>.GetInstance().NewUnlockFuncList.Add((int)res.funcId);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewAccountFuncUnlock, res.funcId, null, null, null);
		}
	}

	// Token: 0x0600A2BD RID: 41661 RVA: 0x002138B4 File Offset: 0x00211CB4
	[ProtocolHandle(typeof(SceneSyncFlyUpStatus))]
	private void _OnSyncFlyUpStatus(SceneSyncFlyUpStatus rep)
	{
		if (rep == null)
		{
			return;
		}
		if (rep.status == 0)
		{
			if (DataManager<PlayerBaseData>.GetInstance().IsFlyUpState)
			{
				Singleton<NewbieGuideManager>.GetInstance().SendSaveBoot(NewbieGuideTable.eNewbieGuideTask.AncientGuide);
			}
		}
		else
		{
			DataManager<PlayerBaseData>.GetInstance().IsFlyUpState = true;
			Singleton<NewbieGuideManager>.GetInstance().ManagerFinishGuide(Singleton<NewbieGuideManager>.GetInstance().GetCurTaskID());
		}
	}

	// Token: 0x0600A2BE RID: 41662 RVA: 0x00213914 File Offset: 0x00211D14
	private void _setRacePlayers(RacePlayerInfo[] players)
	{
		DataManager<BattleDataManager>.GetInstance().PlayerInfo = players;
		ClientApplication.racePlayerInfo = players;
		for (int i = 0; i < ClientApplication.racePlayerInfo.Length; i++)
		{
			RacePlayerInfo racePlayerInfo = ClientApplication.racePlayerInfo[i];
			if (racePlayerInfo.accid == ClientApplication.playerinfo.accid)
			{
				ClientApplication.playerinfo.seat = racePlayerInfo.seat;
			}
		}
	}

	// Token: 0x0600A2BF RID: 41663 RVA: 0x00213977 File Offset: 0x00211D77
	private void _setRaceRelayServer(ulong session, SockAddr addr)
	{
		ClientApplication.playerinfo.session = session;
		ClientApplication.relayServer.ip = addr.ip;
		ClientApplication.relayServer.port = addr.port;
	}

	// Token: 0x0600A2C0 RID: 41664 RVA: 0x002139A4 File Offset: 0x00211DA4
	[ProtocolHandle(typeof(SceneDungeonStartRes))]
	private void _onSceneDungeonStartRes(SceneDungeonStartRes rep)
	{
		IClientSystem currentSystem = Singleton<ClientSystemManager>.instance.CurrentSystem;
		if (currentSystem == null || currentSystem.IsSystem<ClientSystemBattle>())
		{
		}
		if (rep.result == 0U)
		{
			DataManager<BattleDataManager>.GetInstance().PkRaceType = RaceType.Dungeon;
			DataManager<BattleDataManager>.GetInstance().ClearBatlte();
			DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleInfo(rep);
			DataManager<BattleDataManager>.GetInstance().originExp = DataManager<PlayerBaseData>.GetInstance().Exp;
			Global.Settings.canUseAutoFight = (rep.openAutoBattle > 0);
			if (rep.openAutoBattle == 2)
			{
				Global.Settings.canUseAutoFightFirstPass = true;
			}
			else
			{
				Global.Settings.canUseAutoFightFirstPass = false;
			}
			if (rep.session == 0UL)
			{
				rep.session = 151248698618683818UL;
			}
			this._setRacePlayers(rep.players);
			this._setRaceRelayServer(rep.session, rep.addr);
			eDungeonMode mode;
			if (rep.addr.port == 0)
			{
				mode = eDungeonMode.LocalFrame;
			}
			else
			{
				mode = eDungeonMode.SyncFrame;
			}
			BattleType battleType = ChapterUtility.GetBattleType((int)rep.dungeonId);
			BattleMain battleMain = BattleMain.OpenBattle(battleType, mode, (int)rep.dungeonId, rep.session.ToString());
			bool isRecordProcess = rep.isRecordLog != 0;
			bool isRecordReplay = rep.isRecordReplay != 0;
			Singleton<RecordServer>.GetInstance().StartRecord(battleType, mode, rep.session.ToString(), isRecordProcess, isRecordReplay, true, false);
			Singleton<RecordServer>.GetInstance().RecordDungoenInfo(rep);
			string buglyVerIdInfo = string.Format("{0}_{1}", rep.dungeonId, rep.session);
			if (Singleton<PluginManager>.GetInstance() != null)
			{
				Singleton<PluginManager>.GetInstance().SetBuglyVerIdInfo(buglyVerIdInfo);
			}
			if (battleMain != null)
			{
				BaseBattle baseBattle = battleMain.GetBattle() as BaseBattle;
				if (baseBattle != null)
				{
					baseBattle.SetBattleFlag(rep.battleFlag);
					baseBattle.SetDungeonClearInfo(rep.clearedDungeonIds);
					RaidBattle raidBattle = baseBattle as RaidBattle;
					if (raidBattle != null)
					{
						for (int i = 0; i < rep.clearedDungeonIds.Length; i++)
						{
							raidBattle.DungeonDestroyNotify((int)rep.clearedDungeonIds[i]);
						}
					}
				}
				GuildPVEBattle guildPVEBattle = battleMain.GetBattle() as GuildPVEBattle;
				if (guildPVEBattle != null)
				{
					if (rep.guildDungeonInfo != null)
					{
						guildPVEBattle.SetBossInfo(rep.guildDungeonInfo.bossOddBlood, rep.guildDungeonInfo.bossTotalBlood);
						guildPVEBattle.SetBuffInfo(rep.guildDungeonInfo.buffVec);
					}
					else
					{
						Logger.LogErrorFormat("[PVE] GuildPveBattle sessionid {0} is Null", new object[]
						{
							rep.session
						});
					}
				}
				else
				{
					FinalTestBattle finalTestBattle = battleMain.GetBattle() as FinalTestBattle;
					if (finalTestBattle != null && rep.zjslDungeonInfo != null)
					{
						finalTestBattle.SetBossInfo(rep.zjslDungeonInfo.boss1ID, rep.zjslDungeonInfo.boss1RemainHp, rep.zjslDungeonInfo.boss2ID, rep.zjslDungeonInfo.boss2RemainHp);
						finalTestBattle.SetBuffInfo(rep.zjslDungeonInfo.buffVec);
					}
					else
					{
						PVEBattle pvebattle = battleMain.GetBattle() as PVEBattle;
						if (pvebattle != null && rep.hellAutoClose == 1)
						{
							pvebattle.OpenHellClose();
						}
					}
				}
			}
			Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, true);
		}
		else if (rep.result != 901001U && rep.result != 900028U)
		{
			SystemNotifyManager.SystemNotify((int)rep.result, string.Empty);
		}
	}

	// Token: 0x0600A2C1 RID: 41665 RVA: 0x00213D0C File Offset: 0x0021210C
	private IEnumerator _startBattle(eDungeonMode mode, SockAddr addr, ulong session, GlobalNetMessage.ConnnectRelayCallback cb)
	{
		if (mode == eDungeonMode.SyncFrame)
		{
			ClientApplication.playerinfo.session = session;
			ClientApplication.relayServer.ip = addr.ip;
			ClientApplication.relayServer.port = addr.port;
			WaitServerConnected waitConnect = new WaitServerConnected(ServerType.RELAY_SERVER, ClientApplication.relayServer.ip, ClientApplication.relayServer.port, ClientApplication.playerinfo.accid, 4f, 3, 1f);
			yield return waitConnect;
			if (waitConnect.GetResult() == WaitServerConnected.eResult.Success)
			{
				Singleton<ClientReconnectManager>.instance.canReconnectRelay = true;
				if (cb != null)
				{
					cb();
				}
			}
		}
		else if (cb != null)
		{
			cb();
		}
		yield break;
	}

	// Token: 0x0600A2C2 RID: 41666 RVA: 0x00213D40 File Offset: 0x00212140
	[ProtocolHandle(typeof(GateNotifyKickoff))]
	private void _onGateNotifyKickoff(GateNotifyKickoff res)
	{
		Singleton<ClientReconnectManager>.instance.canRelogin = false;
		Singleton<ClientReconnectManager>.instance.canReconnectGate = false;
		if (BattleMain.instance != null && res.errorCode == 8932U)
		{
			Singleton<RecordServer>.GetInstance().MarkRecordFileNeedUpload();
		}
		Singleton<ClientSystemManager>.instance.QuitToLoginSystem((int)res.errorCode);
	}

	// Token: 0x0600A2C3 RID: 41667 RVA: 0x00213D98 File Offset: 0x00212198
	[ProtocolHandle(typeof(WorldNotifyRaceStart))]
	private void _onPkRaceStart(WorldNotifyRaceStart rep)
	{
		if (rep.raceType == 1 || rep.raceType == 2 || rep.raceType == 4 || rep.raceType == 3 || rep.raceType == 5 || rep.raceType == 6 || rep.raceType == 7 || rep.raceType == 11 || rep.raceType == 8 || rep.raceType == 9 || rep.raceType == 13)
		{
			bool isRecordProcess = rep.isRecordLog != 0;
			bool isRecordReplay = rep.isRecordReplay != 0;
			isRecordProcess = false;
			isRecordReplay = true;
			Singleton<RecordServer>.GetInstance().StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, rep.sessionId.ToString(), isRecordProcess, isRecordReplay, true, false);
			Singleton<RecordServer>.GetInstance().RecordPlayerInfo(rep);
			if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
			{
				Singleton<ReplayServer>.GetInstance().StartLiveShow();
			}
			this._setRacePlayers(rep.players);
			if (Singleton<ReplayServer>.GetInstance() != null && Singleton<ReplayServer>.GetInstance().IsLiveShow())
			{
				if (Singleton<ReplayServer>.GetInstance().LiveShowServerAddr == null)
				{
					Logger.LogErrorFormat("no available live show address", new object[0]);
					Singleton<RecordServer>.GetInstance().EndRecord("Address Error");
					Singleton<ReplayServer>.GetInstance().EndReplay(true, string.Empty);
					return;
				}
				this._setRaceRelayServer(rep.sessionId, Singleton<ReplayServer>.GetInstance().LiveShowServerAddr);
			}
			else
			{
				this._setRaceRelayServer(rep.sessionId, rep.addr);
			}
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.PKMatched, rep.raceType, null, null, null);
			try
			{
				DataManager<BattleDataManager>.GetInstance().PkRaceType = (RaceType)rep.raceType;
			}
			catch (Exception ex)
			{
			}
			if (rep.raceType == 2)
			{
				BattleMain.OpenBattle(BattleType.GuildPVP, eDungeonMode.SyncFrame, (int)rep.dungeonId, rep.sessionId.ToString());
			}
			else if (rep.raceType == 3 || rep.raceType == 4)
			{
				BattleMain.OpenBattle(BattleType.MoneyRewardsPVP, eDungeonMode.LocalFrame, (int)rep.dungeonId, rep.sessionId.ToString());
			}
			else if (rep.raceType == 5 || rep.raceType == 6 || rep.raceType == 7 || rep.raceType == 11)
			{
				if (rep.raceType == 6)
				{
					DataManager<Pk3v3CrossDataManager>.GetInstance().bMatching = false;
					WorldNotifyRaceStart worldNotifyRaceStart = new WorldNotifyRaceStart();
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._PK3v3CrossMatchOK(rep));
					return;
				}
				if (rep.raceType == 11)
				{
					DataManager<Pk2v2CrossDataManager>.GetInstance().bMatching = false;
					WorldNotifyRaceStart worldNotifyRaceStart2 = new WorldNotifyRaceStart();
					MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._PK2v2CrossMatchOK(rep));
					return;
				}
				if (rep.raceType == 7)
				{
					BattleMain.OpenBattle(BattleType.ScufflePVP, eDungeonMode.SyncFrame, (int)rep.dungeonId, rep.sessionId.ToString());
				}
				else
				{
					BattleMain.OpenBattle(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, (int)rep.dungeonId, rep.sessionId.ToString());
				}
			}
			else if (rep.raceType == 8)
			{
				DataManager<ChijiDataManager>.GetInstance().BattleDungeonId = rep.dungeonId;
				DataManager<ChijiDataManager>.GetInstance().BattleRaceType = rep.raceType;
				DataManager<ChijiDataManager>.GetInstance().SessionId = rep.sessionId;
				DataManager<ChijiDataManager>.GetInstance().IsReadyPk = false;
				DataManager<ChijiDataManager>.GetInstance().BattleFlag = rep.battleFlag;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChijiPkReady, null, null, null, null);
			}
			else
			{
				BattleMain.OpenBattle(BattleType.MutiPlayer, eDungeonMode.SyncFrame, (int)rep.dungeonId, rep.sessionId.ToString());
			}
			if (rep.raceType != 8)
			{
				BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
				if (baseBattle != null)
				{
					baseBattle.PkRaceType = (int)rep.raceType;
					baseBattle.SetBattleFlag(rep.battleFlag);
				}
				if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
				{
					Singleton<ReplayServer>.GetInstance().SetBattle(BattleMain.instance.GetBattle() as PVPBattle);
				}
				Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
			}
		}
	}

	// Token: 0x0600A2C4 RID: 41668 RVA: 0x002141C8 File Offset: 0x002125C8
	public IEnumerator _PK3v3CrossMatchOK(WorldNotifyRaceStart rep)
	{
		Singleton<DeviceVibrateManager>.GetInstance().TriggerDeviceVibrateByType(VibrateSwitchType.Pk3v3);
		Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk3v3CrossMatchOKFrame>(FrameLayer.Middle, null, string.Empty);
		yield return Yielders.GetWaitForSeconds(3f);
		BattleMain.OpenBattle(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, (int)rep.dungeonId, rep.sessionId.ToString());
		BaseBattle battle = BattleMain.instance.GetBattle() as BaseBattle;
		if (battle != null)
		{
			battle.PkRaceType = (int)rep.raceType;
			battle.SetBattleFlag(rep.battleFlag);
		}
		if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
		{
			Singleton<ReplayServer>.GetInstance().SetBattle(BattleMain.instance.GetBattle() as PVPBattle);
		}
		Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
		yield return 0;
		yield break;
	}

	// Token: 0x0600A2C5 RID: 41669 RVA: 0x002141E4 File Offset: 0x002125E4
	public IEnumerator _PK2v2CrossMatchOK(WorldNotifyRaceStart rep)
	{
		Singleton<ClientSystemManager>.GetInstance().OpenFrame<Pk2v2CrossMatchOKFrame>(FrameLayer.Middle, null, string.Empty);
		yield return Yielders.GetWaitForSeconds(3f);
		BattleMain.OpenBattle(BattleType.ScufflePVP, eDungeonMode.SyncFrame, (int)rep.dungeonId, rep.sessionId.ToString());
		BaseBattle battle = BattleMain.instance.GetBattle() as BaseBattle;
		if (battle != null)
		{
			battle.PkRaceType = (int)rep.raceType;
			battle.SetBattleFlag(rep.battleFlag);
		}
		if (Singleton<ReplayServer>.GetInstance().IsLiveShow())
		{
			Singleton<ReplayServer>.GetInstance().SetBattle(BattleMain.instance.GetBattle() as PVPBattle);
		}
		Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
		yield return 0;
		yield break;
	}

	// Token: 0x0600A2C6 RID: 41670 RVA: 0x00214200 File Offset: 0x00212600
	[ProtocolHandle(typeof(WorldNotifyNewMail))]
	private void _onWorldNotifyNewMail(WorldNotifyNewMail rep)
	{
		if (rep.info.type == 2)
		{
			DataManager<PlayerBaseData>.GetInstance().mails.mailList.Insert(0, rep.info);
			DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyNum();
			DataManager<PlayerBaseData>.GetInstance().mails.UnreadNum++;
		}
		else
		{
			DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Insert(0, rep.info);
			DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyRewardNum();
			DataManager<PlayerBaseData>.GetInstance().mails.UnreadRewardNum++;
		}
	}

	// Token: 0x0600A2C7 RID: 41671 RVA: 0x002142A8 File Offset: 0x002126A8
	[MessageHandle(506703U, false, 0)]
	private void _OnInitPkDataStatistics(MsgDATA msg)
	{
		if (msg == null)
		{
			Logger.LogError("_OnInitPkDataStatistics ==>> msg is nil");
			return;
		}
		int num = 0;
		Dictionary<byte, PkStatistic> dictionary = PkStatisticDecoder.DecodeSyncPkStatisticInfoMsg(msg.bytes, ref num, msg.bytes.Length);
		if (dictionary == null)
		{
			return;
		}
		DataManager<PlayerBaseData>.GetInstance().PkStatisticsData.Clear();
		DataManager<PlayerBaseData>.GetInstance().PkStatisticsData = dictionary;
	}

	// Token: 0x0600A2C8 RID: 41672 RVA: 0x00214300 File Offset: 0x00212700
	[MessageHandle(506704U, false, 0)]
	private void _OnUpdatePkDataStatistics(MsgDATA msg)
	{
		if (msg == null)
		{
			Logger.LogError("_OnUpdatePkDataStatistics ==>> msg is nil");
			return;
		}
		int num = 0;
		byte key = 0;
		BaseDLL.decode_int8(msg.bytes, ref num, ref key);
		PkStatistic pkStatistic = null;
		if (!DataManager<PlayerBaseData>.GetInstance().PkStatisticsData.TryGetValue(key, out pkStatistic))
		{
		}
		if (pkStatistic == null)
		{
			pkStatistic = new PkStatistic();
		}
		PkStatisticDecoder.DecodeSyncPkStatisticPropertyMsg(ref pkStatistic, msg.bytes, ref num, msg.bytes.Length);
		if (!DataManager<PlayerBaseData>.GetInstance().PkStatisticsData.ContainsKey(key))
		{
			DataManager<PlayerBaseData>.GetInstance().PkStatisticsData.Add(key, pkStatistic);
		}
		else
		{
			for (int i = 0; i < pkStatistic.dirtyFields.Count; i++)
			{
				PkStatisticProperty pkStatisticProperty = (PkStatisticProperty)pkStatistic.dirtyFields[i];
				if (pkStatisticProperty == PkStatisticProperty.PKIA_CUR_WIN_STEAK)
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.PkCurWinSteak, null, null, null, null);
				}
			}
		}
	}

	// Token: 0x0600A2C9 RID: 41673 RVA: 0x002143E3 File Offset: 0x002127E3
	[ProtocolHandle(typeof(RoleSwitchRes))]
	private void _onSwitchRoleRes(RoleSwitchRes rep)
	{
		Singleton<ClientSystemManager>.GetInstance()._QuitToSelectRoleImpl();
	}

	// Token: 0x0600A2CA RID: 41674 RVA: 0x002143F0 File Offset: 0x002127F0
	[MessageHandle(300321U, false, 0)]
	private void OnGateSendLoginPushInfo(MsgDATA msg)
	{
		GateSendLoginPushInfo gateSendLoginPushInfo = new GateSendLoginPushInfo();
		gateSendLoginPushInfo.decode(msg.bytes);
		if (gateSendLoginPushInfo == null)
		{
			Singleton<LoginPushManager>.GetInstance().ClearPushList();
			return;
		}
		List<LoginPushManager.LoginPushData> list = new List<LoginPushManager.LoginPushData>();
		list.Clear();
		for (int i = 0; i < gateSendLoginPushInfo.infos.Length; i++)
		{
			LoginPushManager.LoginPushData item = new LoginPushManager.LoginPushData
			{
				name = gateSendLoginPushInfo.infos[i].name,
				iconPath = gateSendLoginPushInfo.infos[i].iconPath,
				linkInfo = gateSendLoginPushInfo.infos[i].linkInfo,
				loadingIconPath = gateSendLoginPushInfo.infos[i].loadingIconPath,
				sortNum = gateSendLoginPushInfo.infos[i].sortNum,
				unlockLevel = gateSendLoginPushInfo.infos[i].unlockLevel,
				startTime = (int)gateSendLoginPushInfo.infos[i].startTime,
				endTime = (int)gateSendLoginPushInfo.infos[i].endTime,
				needTime = (gateSendLoginPushInfo.infos[i].isShowTime != 0),
				IsSetNative = (int)gateSendLoginPushInfo.infos[i].isSetNative
			};
			list.Add(item);
		}
		Singleton<LoginPushManager>.GetInstance().SetLoginPushList(list);
	}

	// Token: 0x0600A2CB RID: 41675 RVA: 0x00214535 File Offset: 0x00212935
	[ProtocolHandle(typeof(RelaySvrObserveRes))]
	private void _onRelaySvrObserveRes(RelaySvrObserveRes res)
	{
		if (res == null)
		{
			return;
		}
		if (res.result != 0U)
		{
			SystemNotifyManager.SystemNotify((int)res.result, string.Empty);
			return;
		}
		Singleton<ReplayServer>.GetInstance().SetLiveShow();
	}

	// Token: 0x0600A2CC RID: 41676 RVA: 0x00214564 File Offset: 0x00212964
	[MessageHandle(300301U, false, 0)]
	private void OnGateSendRoleInfo(MsgDATA msg)
	{
		if (!ClientSystemLogin.mSwitchRole)
		{
			return;
		}
		GateSendRoleInfo gateSendRoleInfo = new GateSendRoleInfo();
		gateSendRoleInfo.decode(msg.bytes);
		foreach (RoleInfo roleInfo in gateSendRoleInfo.roles)
		{
		}
		ClientApplication.playerinfo.apponintmentOccus = gateSendRoleInfo.appointmentOccus;
		ClientApplication.playerinfo.appointmentRoleNum = gateSendRoleInfo.appointmentRoleNum;
		ClientApplication.playerinfo.roleinfo = gateSendRoleInfo.roles;
		ClientApplication.playerinfo.baseRoleFieldNum = gateSendRoleInfo.baseRoleField;
		ClientApplication.playerinfo.extendRoleFieldNum = gateSendRoleInfo.extensibleRoleField;
		ClientApplication.playerinfo.unLockedExtendRoleFieldNum = gateSendRoleInfo.unlockedExtensibleRoleField;
		Singleton<ServerListManager>.instance.SaveUserData(gateSendRoleInfo.roles);
	}

	// Token: 0x0600A2CD RID: 41677 RVA: 0x00214620 File Offset: 0x00212A20
	[MessageHandle(308601U, false, 0)]
	private void OnSyncAdventureTeamInfo(MsgDATA msg)
	{
		if (msg == null)
		{
			return;
		}
		AdventureTeamInfoSync adventureTeamInfoSync = new AdventureTeamInfoSync();
		adventureTeamInfoSync.decode(msg.bytes);
		ClientApplication.playerinfo.adventureTeamInfo = adventureTeamInfoSync.info;
	}

	// Token: 0x04005ABF RID: 23231
	private static GlobalNetMessage mInstance;

	// Token: 0x020010D0 RID: 4304
	// (Invoke) Token: 0x0600A2CF RID: 41679
	public delegate void ConnnectRelayCallback();
}
