using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using GameClient;
using Protocol;

// Token: 0x02004584 RID: 17796
public class LogicServer
{
	// Token: 0x06018D57 RID: 101719 RVA: 0x007C3344 File Offset: 0x007C1744
	public LogicServer()
	{
		LogicServer.sm_Root = this;
		this.bufferCache = new byte[65535];
		LogicServer.rootLogic = this;
		this.frameQueue = new Queue<IFrameCommand>();
		this.keyFrameRate = 1U;
		this.isGetStartFrame = false;
	}

	// Token: 0x06018D58 RID: 101720 RVA: 0x007C33D9 File Offset: 0x007C17D9
	public uint GetCurFrame()
	{
		return this.curFrame;
	}

	// Token: 0x06018D59 RID: 101721 RVA: 0x007C33E1 File Offset: 0x007C17E1
	public uint GetLastFrame()
	{
		return this.lastFrame;
	}

	// Token: 0x06018D5A RID: 101722 RVA: 0x007C33E9 File Offset: 0x007C17E9
	public uint GetLastRandNum()
	{
		return this.lastRandNum;
	}

	// Token: 0x06018D5B RID: 101723 RVA: 0x007C33F1 File Offset: 0x007C17F1
	public void Close()
	{
		this.isClosed = true;
	}

	// Token: 0x06018D5C RID: 101724 RVA: 0x007C33FA File Offset: 0x007C17FA
	public bool isBattleClosed()
	{
		return this.isClosed;
	}

	// Token: 0x06018D5D RID: 101725 RVA: 0x007C3402 File Offset: 0x007C1802
	public ulong GetSession()
	{
		return this.session;
	}

	// Token: 0x17002079 RID: 8313
	// (get) Token: 0x06018D5E RID: 101726 RVA: 0x007C340A File Offset: 0x007C180A
	// (set) Token: 0x06018D5F RID: 101727 RVA: 0x007C3412 File Offset: 0x007C1812
	public bool isFire
	{
		get
		{
			return this.mIsFire;
		}
		set
		{
			this.mIsFire = value;
		}
	}

	// Token: 0x1700207A RID: 8314
	// (get) Token: 0x06018D60 RID: 101728 RVA: 0x007C341B File Offset: 0x007C181B
	public RecordServer recordServer
	{
		get
		{
			return this.record;
		}
	}

	// Token: 0x06018D61 RID: 101729 RVA: 0x007C3423 File Offset: 0x007C1823
	public BaseBattle GetBattle()
	{
		return this.battle;
	}

	// Token: 0x1700207B RID: 8315
	// (get) Token: 0x06018D62 RID: 101730 RVA: 0x007C342B File Offset: 0x007C182B
	public int queueCount
	{
		get
		{
			return this.frameQueue.Count;
		}
	}

	// Token: 0x06018D63 RID: 101731 RVA: 0x007C3438 File Offset: 0x007C1838
	private void Init()
	{
		this.bRun = false;
		this.timeAcc = 0;
		this.curFrame = 0U;
		this.serverSeed = 0U;
		this.frameSpeed = 1U;
		this.svrFrameLater = 0U;
		this.isGetStartFrame = false;
		this.isFire = true;
		this.bufferCache = new byte[65535];
		this.frameQueue = new Queue<IFrameCommand>();
		LogicServer.logicUpdateStep = 32U;
		LogicServer.logicFrameStep = 2U;
		LogicServer.logicFrameStepDelta = 0;
		this.bCanForceUpdateEnd = false;
		this.bIsEnd = false;
	}

	// Token: 0x06018D64 RID: 101732 RVA: 0x007C34BC File Offset: 0x007C18BC
	public void OnRelayGameStart(uint randomseed)
	{
		this.timeAcc = 0;
		this.curFrame = 2U;
		this.battle.FrameRandom.callFrame = this.curFrame;
		this.serverSeed = randomseed;
		this.record.RecordProcessPlayerInfo(this.battle.dungeonPlayerManager);
		if (this.record.IsReplayRecord(false) && this.battle.dungeonManager != null && this.battle.dungeonManager.GetDungeonDataManager() != null && this.battle.dungeonManager.GetDungeonDataManager().id != null)
		{
			this.record.RecordStartTime(randomseed);
			int dungeonID = this.battle.dungeonManager.GetDungeonDataManager().id.dungeonID;
			this.record.RecordDungeonID(dungeonID);
			this.record.RecordSequence(this.currentEndFrame);
		}
	}

	// Token: 0x06018D65 RID: 101733
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void OnServerCheckSum(ulong session, uint frame, uint callnum);

	// Token: 0x06018D66 RID: 101734
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void LogConsole(LogicServer.LogicServerLogType type, string message);

	// Token: 0x06018D67 RID: 101735
	[MethodImpl(MethodImplOptions.InternalCall)]
	public static extern void OnReportRaceEnd(ulong session, byte[] raceend, int len);

	// Token: 0x06018D68 RID: 101736 RVA: 0x007C35A0 File Offset: 0x007C19A0
	public static void ReportRaceEndToLogicServer(RelaySvrDungeonRaceEndReq raceend)
	{
		for (int i = 0; i < raceend.raceEndInfo.infoes.Length; i++)
		{
			DungeonPlayerRaceEndInfo dungeonPlayerRaceEndInfo = raceend.raceEndInfo.infoes[i];
			for (int j = 0; j < dungeonPlayerRaceEndInfo.md5.Length; j++)
			{
				dungeonPlayerRaceEndInfo.md5[j] = 0;
			}
		}
		string empty = string.Empty;
		string text = string.Format("sessionid : {0} dungeonId : {1} usedTime : {2}", raceend.raceEndInfo.sessionId, raceend.raceEndInfo.dungeonId, raceend.raceEndInfo.usedTime);
		string text2 = string.Empty;
		for (int k = 0; k < raceend.raceEndInfo.infoes.Length; k++)
		{
			DungeonPlayerRaceEndInfo dungeonPlayerRaceEndInfo2 = raceend.raceEndInfo.infoes[k];
			text2 += string.Format("<roleId : {0} pos : {1} score : {2} hitCount : {3} bossDamage : {4} bossId1 : {5} bossRemainHP1 : {6} bossId2 : {7} bossRemainHP2 : {8}>", new object[]
			{
				dungeonPlayerRaceEndInfo2.roleId,
				dungeonPlayerRaceEndInfo2.pos,
				dungeonPlayerRaceEndInfo2.score,
				dungeonPlayerRaceEndInfo2.beHitCount,
				dungeonPlayerRaceEndInfo2.bossDamage,
				dungeonPlayerRaceEndInfo2.boss1ID,
				dungeonPlayerRaceEndInfo2.boss1RemainHp,
				dungeonPlayerRaceEndInfo2.boss2ID,
				dungeonPlayerRaceEndInfo2.boss2RemainHp
			});
		}
		Logger.LogErrorFormat("[ReportRaceEndToLogicServer] {0} {1} ", new object[]
		{
			text,
			text2
		});
		for (int l = 0; l < raceend.raceEndInfo.infoes.Length; l++)
		{
			DungeonPlayerRaceEndInfo dungeonPlayerRaceEndInfo3 = raceend.raceEndInfo.infoes[l];
			for (int m = 0; m < dungeonPlayerRaceEndInfo3.md5.Length; m++)
			{
				dungeonPlayerRaceEndInfo3.md5[m] = 0;
			}
		}
		int len = 0;
		raceend.encode(LogicServer.raceEndBuffer, ref len);
		LogicServer.OnReportRaceEnd(raceend.raceEndInfo.sessionId, LogicServer.raceEndBuffer, len);
	}

	// Token: 0x06018D69 RID: 101737 RVA: 0x007C37B4 File Offset: 0x007C1BB4
	public static void ReportPkRaceEndToLogicServer(RelaySvrEndGameReq raceEnd)
	{
		PkRaceEndInfo end = raceEnd.end;
		string empty = string.Empty;
		string text = string.Format("sessionid : {0} replayScore : {1}", end.gamesessionId, end.replayScore);
		string text2 = string.Empty;
		for (int i = 0; i < end.infoes.Length; i++)
		{
			PkPlayerRaceEndInfo pkPlayerRaceEndInfo = end.infoes[i];
			text2 += string.Format("<roleId : {0} pos : {1} remainHp : {2} remainMp : {3} result : {4} damagePercent : {5}>", new object[]
			{
				pkPlayerRaceEndInfo.roleId,
				pkPlayerRaceEndInfo.pos,
				pkPlayerRaceEndInfo.remainHp,
				pkPlayerRaceEndInfo.remainMp,
				pkPlayerRaceEndInfo.result,
				pkPlayerRaceEndInfo.damagePercent
			});
		}
		Logger.LogErrorFormat("[ReportPkRaceEndToLogicServer] {0} {1} ", new object[]
		{
			text,
			text2
		});
		int len = 0;
		raceEnd.encode(LogicServer.raceEndBuffer, ref len);
		LogicServer.OnReportRaceEnd(raceEnd.end.gamesessionId, LogicServer.raceEndBuffer, len);
	}

	// Token: 0x06018D6A RID: 101738 RVA: 0x007C38D0 File Offset: 0x007C1CD0
	public static LogicServer NewGameLogic()
	{
		LogicServer logicServer = new LogicServer();
		logicServer.Init();
		LogicServer.rootLogic = logicServer;
		return logicServer;
	}

	// Token: 0x06018D6B RID: 101739 RVA: 0x007C38F0 File Offset: 0x007C1CF0
	public static void LogicServerInit()
	{
		try
		{
			Singleton<TableManager>.CreateInstance(false);
			Singleton<TableManager>.GetInstance().LogicServerInit();
			DataManager<EquipMasterDataManager>.GetInstance().Initialize();
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.ToString() + "\n");
		}
	}

	// Token: 0x06018D6C RID: 101740 RVA: 0x007C3948 File Offset: 0x007C1D48
	public static void DumpMemory()
	{
		string text = string.Format("dump-{0}", DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"));
	}

	// Token: 0x06018D6D RID: 101741 RVA: 0x007C3974 File Offset: 0x007C1D74
	public void StartPVE(ulong s, IntPtr buff, int bufflen)
	{
		GC.Collect();
		this.CopyBufferCache(buff, bufflen);
		this.session = s;
		SceneDungeonStartRes sceneDungeonStartRes = new SceneDungeonStartRes();
		sceneDungeonStartRes.decode(this.bufferCache);
		DataManager<BattleDataManager>.GetInstance().ClearBatlte();
		DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleInfo(sceneDungeonStartRes);
		this._setRacePlayers(sceneDungeonStartRes.players);
		this._setRaceRelayServer(sceneDungeonStartRes.session, sceneDungeonStartRes.addr);
		eDungeonMode mode;
		if (sceneDungeonStartRes.session == 0UL)
		{
			mode = eDungeonMode.LocalFrame;
		}
		else
		{
			mode = eDungeonMode.SyncFrame;
		}
		this.session = sceneDungeonStartRes.session;
		BattleType battleType = ChapterUtility.GetBattleType((int)sceneDungeonStartRes.dungeonId);
		this.battle = BattleFactory.CreateBattle(battleType, mode, (int)sceneDungeonStartRes.dungeonId);
		this.battle.SetBattleFlag(sceneDungeonStartRes.battleFlag);
		this.record = this.battle.recordServer;
		this.record.sessionID = sceneDungeonStartRes.session.ToString();
		this.battle.recordServer.StartRecord(battleType, mode, sceneDungeonStartRes.session.ToString(), true, false, true, false);
		this.record.SetLogicServer(this);
		this.battle.SetDungeonClearInfo(sceneDungeonStartRes.clearedDungeonIds);
		RaidBattle raidBattle = this.battle as RaidBattle;
		if (raidBattle != null)
		{
			for (int i = 0; i < sceneDungeonStartRes.clearedDungeonIds.Length; i++)
			{
				raidBattle.DungeonDestroyNotify((int)sceneDungeonStartRes.clearedDungeonIds[i]);
			}
		}
		GuildPVEBattle guildPVEBattle = this.battle as GuildPVEBattle;
		if (guildPVEBattle != null && sceneDungeonStartRes.guildDungeonInfo != null)
		{
			guildPVEBattle.SetBossInfo(sceneDungeonStartRes.guildDungeonInfo.bossOddBlood, sceneDungeonStartRes.guildDungeonInfo.bossTotalBlood);
			guildPVEBattle.SetBuffInfo(sceneDungeonStartRes.guildDungeonInfo.buffVec);
		}
		else
		{
			FinalTestBattle finalTestBattle = this.battle as FinalTestBattle;
			if (finalTestBattle != null && sceneDungeonStartRes.zjslDungeonInfo != null)
			{
				finalTestBattle.SetBossInfo(sceneDungeonStartRes.zjslDungeonInfo.boss1ID, sceneDungeonStartRes.zjslDungeonInfo.boss1RemainHp, sceneDungeonStartRes.zjslDungeonInfo.boss2ID, sceneDungeonStartRes.zjslDungeonInfo.boss2RemainHp);
				finalTestBattle.SetBuffInfo(sceneDungeonStartRes.zjslDungeonInfo.buffVec);
			}
			else
			{
				PVEBattle pvebattle = this.battle as PVEBattle;
				if (pvebattle != null && sceneDungeonStartRes.hellAutoClose == 1)
				{
					pvebattle.OpenHellClose();
				}
			}
		}
		this.battle.StartLogicServer(this);
		this.record.RecordDungeonID((int)sceneDungeonStartRes.dungeonId);
		this.record.RecordDungoenInfo(sceneDungeonStartRes);
	}

	// Token: 0x06018D6E RID: 101742 RVA: 0x007C3BEC File Offset: 0x007C1FEC
	public void StartPVE(ulong s, byte[] buff)
	{
		GC.Collect();
		this.bufferCache = buff;
		this.session = s;
		SceneDungeonStartRes sceneDungeonStartRes = new SceneDungeonStartRes();
		sceneDungeonStartRes.decode(this.bufferCache);
		DataManager<BattleDataManager>.GetInstance().ClearBatlte();
		DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleInfo(sceneDungeonStartRes);
		this._setRacePlayers(sceneDungeonStartRes.players);
		this._setRaceRelayServer(sceneDungeonStartRes.session, sceneDungeonStartRes.addr);
		eDungeonMode mode;
		if (sceneDungeonStartRes.session == 0UL)
		{
			mode = eDungeonMode.LocalFrame;
		}
		else
		{
			mode = eDungeonMode.SyncFrame;
		}
		this.session = sceneDungeonStartRes.session;
		BattleType battleType = ChapterUtility.GetBattleType((int)sceneDungeonStartRes.dungeonId);
		this.battle = BattleFactory.CreateBattle(battleType, mode, (int)sceneDungeonStartRes.dungeonId);
		this.battle.SetBattleFlag(sceneDungeonStartRes.battleFlag);
		this.record = this.battle.recordServer;
		this.record.sessionID = sceneDungeonStartRes.session.ToString();
		this.battle.recordServer.StartRecord(battleType, mode, sceneDungeonStartRes.session.ToString(), true, false, true, false);
		this.record.SetLogicServer(this);
		this.battle.SetDungeonClearInfo(sceneDungeonStartRes.clearedDungeonIds);
		RaidBattle raidBattle = this.battle as RaidBattle;
		if (raidBattle != null)
		{
			for (int i = 0; i < sceneDungeonStartRes.clearedDungeonIds.Length; i++)
			{
				raidBattle.DungeonDestroyNotify((int)sceneDungeonStartRes.clearedDungeonIds[i]);
			}
		}
		GuildPVEBattle guildPVEBattle = this.battle as GuildPVEBattle;
		if (guildPVEBattle != null && sceneDungeonStartRes.guildDungeonInfo != null)
		{
			guildPVEBattle.SetBossInfo(sceneDungeonStartRes.guildDungeonInfo.bossOddBlood, sceneDungeonStartRes.guildDungeonInfo.bossTotalBlood);
			guildPVEBattle.SetBuffInfo(sceneDungeonStartRes.guildDungeonInfo.buffVec);
		}
		else
		{
			FinalTestBattle finalTestBattle = this.battle as FinalTestBattle;
			if (finalTestBattle != null && sceneDungeonStartRes.zjslDungeonInfo != null)
			{
				finalTestBattle.SetBossInfo(sceneDungeonStartRes.zjslDungeonInfo.boss1ID, sceneDungeonStartRes.zjslDungeonInfo.boss1RemainHp, sceneDungeonStartRes.zjslDungeonInfo.boss2ID, sceneDungeonStartRes.zjslDungeonInfo.boss2RemainHp);
				finalTestBattle.SetBuffInfo(sceneDungeonStartRes.zjslDungeonInfo.buffVec);
			}
			else
			{
				PVEBattle pvebattle = this.battle as PVEBattle;
				if (pvebattle != null && sceneDungeonStartRes.hellAutoClose == 1)
				{
					pvebattle.OpenHellClose();
				}
			}
		}
		this.battle.StartLogicServer(this);
		this.record.RecordDungeonID((int)sceneDungeonStartRes.dungeonId);
		this.record.RecordDungoenInfo(sceneDungeonStartRes);
	}

	// Token: 0x06018D6F RID: 101743 RVA: 0x007C3E60 File Offset: 0x007C2260
	public void StartPVP(ulong s, IntPtr buff, int bufflen)
	{
		GC.Collect();
		this.Init();
		this.CopyBufferCache(buff, bufflen);
		this.session = s;
		WorldNotifyRaceStart worldNotifyRaceStart = new WorldNotifyRaceStart();
		worldNotifyRaceStart.decode(this.bufferCache);
		this._setRacePlayers(worldNotifyRaceStart.players);
		this._setRaceRelayServer(worldNotifyRaceStart.sessionId, worldNotifyRaceStart.addr);
		if (worldNotifyRaceStart.raceType == 2)
		{
			this.battle = BattleFactory.CreateBattle(BattleType.GuildPVP, eDungeonMode.SyncFrame, (int)worldNotifyRaceStart.dungeonId);
			this.record = this.battle.recordServer;
			this.record.sessionID = worldNotifyRaceStart.sessionId.ToString();
			this.battle.recordServer.StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, worldNotifyRaceStart.sessionId.ToString(), true, false, true, false);
			this.record.SetLogicServer(this);
			this.battle.recordServer.RecordPlayerInfo(worldNotifyRaceStart);
			this.battle.StartLogicServer(this);
		}
		else if (worldNotifyRaceStart.raceType == 3 || worldNotifyRaceStart.raceType == 4)
		{
			this.battle = BattleFactory.CreateBattle(BattleType.MoneyRewardsPVP, eDungeonMode.SyncFrame, (int)worldNotifyRaceStart.dungeonId);
			this.record = this.battle.recordServer;
			this.record.sessionID = worldNotifyRaceStart.sessionId.ToString();
			this.battle.recordServer.StartRecord(BattleType.MoneyRewardsPVP, eDungeonMode.SyncFrame, worldNotifyRaceStart.sessionId.ToString(), true, false, true, false);
			this.record.SetLogicServer(this);
			this.battle.recordServer.RecordPlayerInfo(worldNotifyRaceStart);
			this.battle.StartLogicServer(this);
		}
		else if (worldNotifyRaceStart.raceType == 5 || worldNotifyRaceStart.raceType == 6)
		{
			this.battle = BattleFactory.CreateBattle(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, (int)worldNotifyRaceStart.dungeonId);
			this.record = this.battle.recordServer;
			this.record.sessionID = worldNotifyRaceStart.sessionId.ToString();
			this.battle.recordServer.StartRecord(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, worldNotifyRaceStart.sessionId.ToString(), true, false, true, false);
			this.record.SetLogicServer(this);
			this.battle.recordServer.RecordPlayerInfo(worldNotifyRaceStart);
			this.battle.StartLogicServer(this);
		}
		else if (worldNotifyRaceStart.raceType == 7 || worldNotifyRaceStart.raceType == 11)
		{
			this.battle = BattleFactory.CreateBattle(BattleType.ScufflePVP, eDungeonMode.SyncFrame, (int)worldNotifyRaceStart.dungeonId);
			this.record = this.battle.recordServer;
			this.record.sessionID = worldNotifyRaceStart.sessionId.ToString();
			this.battle.recordServer.StartRecord(BattleType.ScufflePVP, eDungeonMode.SyncFrame, worldNotifyRaceStart.sessionId.ToString(), true, false, true, false);
			this.record.SetLogicServer(this);
			this.battle.recordServer.RecordPlayerInfo(worldNotifyRaceStart);
			this.battle.StartLogicServer(this);
		}
		else if (worldNotifyRaceStart.raceType == 8)
		{
			this.battle = BattleFactory.CreateBattle(BattleType.ChijiPVP, eDungeonMode.SyncFrame, (int)worldNotifyRaceStart.dungeonId);
			this.record = this.battle.recordServer;
			this.record.sessionID = worldNotifyRaceStart.sessionId.ToString();
			this.battle.recordServer.StartRecord(BattleType.ChijiPVP, eDungeonMode.SyncFrame, worldNotifyRaceStart.sessionId.ToString(), true, false, true, false);
			this.record.SetLogicServer(this);
			this.battle.recordServer.RecordPlayerInfo(worldNotifyRaceStart);
			this.battle.StartLogicServer(this);
		}
		else
		{
			this.battle = BattleFactory.CreateBattle(BattleType.MutiPlayer, eDungeonMode.SyncFrame, (int)worldNotifyRaceStart.dungeonId);
			this.record = this.battle.recordServer;
			this.record.sessionID = worldNotifyRaceStart.sessionId.ToString();
			this.battle.recordServer.StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, worldNotifyRaceStart.sessionId.ToString(), true, false, true, false);
			this.record.SetLogicServer(this);
			this.battle.recordServer.RecordPlayerInfo(worldNotifyRaceStart);
			this.battle.StartLogicServer(this);
		}
		if (this.battle != null)
		{
			this.battle.PkRaceType = (int)worldNotifyRaceStart.raceType;
			this.battle.SetBattleFlag(worldNotifyRaceStart.battleFlag);
		}
	}

	// Token: 0x06018D70 RID: 101744 RVA: 0x007C42C8 File Offset: 0x007C26C8
	public void StartPVPRecord(IntPtr buff, int bufflen)
	{
		try
		{
			GC.Collect();
			this.Init();
			this.bCanForceUpdateEnd = true;
			this.CopyBufferCache(buff, bufflen);
			ReplayFile replayFile = new ReplayFile();
			int num = 0;
			replayFile.decode(this.bufferCache, ref num);
			if (replayFile.header.raceType == 0)
			{
				this.session = replayFile.header.sessionId;
				this._setRacePlayers(replayFile.header.players);
				this._setRaceRelayServer(replayFile.header.sessionId, new SockAddr());
				if (replayFile.header.raceType == 2)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.GuildPVP, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.record.SetLogicServer(this);
					this.battle.StartLogicServer(this);
				}
				else if (replayFile.header.raceType == 3 || replayFile.header.raceType == 4)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.MoneyRewardsPVP, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.MoneyRewardsPVP, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.record.SetLogicServer(this);
					this.battle.StartLogicServer(this);
				}
				else if (replayFile.header.raceType == 5 || replayFile.header.raceType == 6)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.record.SetLogicServer(this);
					this.battle.StartLogicServer(this);
				}
				else if (replayFile.header.raceType == 7 || replayFile.header.raceType == 11)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.ScufflePVP, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.ScufflePVP, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.record.SetLogicServer(this);
					this.battle.StartLogicServer(this);
				}
				else if (replayFile.header.raceType == 8)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.ChijiPVP, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.ChijiPVP, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.record.SetLogicServer(this);
					this.battle.StartLogicServer(this);
				}
				else
				{
					this.battle = BattleFactory.CreateBattle(BattleType.MutiPlayer, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.record.SetLogicServer(this);
					this.battle.StartLogicServer(this);
				}
				if (this.battle != null)
				{
					this.battle.PkRaceType = (int)replayFile.header.raceType;
				}
			}
			else
			{
				SceneDungeonStartRes sceneDungeonStartRes = new SceneDungeonStartRes();
				sceneDungeonStartRes.decode(this.bufferCache, ref num);
				DataManager<BattleDataManager>.GetInstance().ClearBatlte();
				DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleInfo(sceneDungeonStartRes);
				eDungeonMode mode;
				if (sceneDungeonStartRes.session == 0UL)
				{
					mode = eDungeonMode.LocalFrame;
				}
				else
				{
					mode = eDungeonMode.SyncFrame;
				}
				this.session = sceneDungeonStartRes.session;
				BattleType battleType = ChapterUtility.GetBattleType((int)sceneDungeonStartRes.dungeonId);
				this._setRacePlayers(sceneDungeonStartRes.players);
				this._setRaceRelayServer(sceneDungeonStartRes.session, sceneDungeonStartRes.addr);
				this.battle = BattleFactory.CreateBattle(battleType, mode, (int)sceneDungeonStartRes.dungeonId);
				this.record = this.battle.recordServer;
				this.record.isLogicServerSaveRecordInTheEnd = true;
				this.record.sessionID = sceneDungeonStartRes.session.ToString();
				this.battle.SetBattleFlag(sceneDungeonStartRes.battleFlag);
				this.record = this.battle.recordServer;
				this.record.sessionID = sceneDungeonStartRes.session.ToString();
				this.battle.recordServer.StartRecord(battleType, mode, sceneDungeonStartRes.session.ToString(), true, false, true, false);
				this.record.SetLogicServer(this);
				this.battle.SetDungeonClearInfo(sceneDungeonStartRes.clearedDungeonIds);
				RaidBattle raidBattle = this.battle as RaidBattle;
				if (raidBattle != null)
				{
					for (int i = 0; i < sceneDungeonStartRes.clearedDungeonIds.Length; i++)
					{
						raidBattle.DungeonDestroyNotify((int)sceneDungeonStartRes.clearedDungeonIds[i]);
					}
				}
				GuildPVEBattle guildPVEBattle = this.battle as GuildPVEBattle;
				if (guildPVEBattle != null && sceneDungeonStartRes.guildDungeonInfo != null)
				{
					guildPVEBattle.SetBossInfo(sceneDungeonStartRes.guildDungeonInfo.bossOddBlood, sceneDungeonStartRes.guildDungeonInfo.bossTotalBlood);
					guildPVEBattle.SetBuffInfo(sceneDungeonStartRes.guildDungeonInfo.buffVec);
				}
				else
				{
					FinalTestBattle finalTestBattle = this.battle as FinalTestBattle;
					if (finalTestBattle != null && sceneDungeonStartRes.zjslDungeonInfo != null)
					{
						finalTestBattle.SetBossInfo(sceneDungeonStartRes.zjslDungeonInfo.boss1ID, sceneDungeonStartRes.zjslDungeonInfo.boss1RemainHp, sceneDungeonStartRes.zjslDungeonInfo.boss2ID, sceneDungeonStartRes.zjslDungeonInfo.boss2RemainHp);
						finalTestBattle.SetBuffInfo(sceneDungeonStartRes.zjslDungeonInfo.buffVec);
					}
					else
					{
						PVEBattle pvebattle = this.battle as PVEBattle;
						if (pvebattle != null && sceneDungeonStartRes.hellAutoClose == 1)
						{
							pvebattle.OpenHellClose();
						}
					}
				}
				this.battle.SetBattleFlag(sceneDungeonStartRes.battleFlag);
				this.battle.StartLogicServer(this);
				this.record.RecordDungeonID((int)sceneDungeonStartRes.dungeonId);
				this.record.RecordDungoenInfo(sceneDungeonStartRes);
			}
			this._PushFrameCommand(replayFile.frames);
			if (replayFile.header.raceType == 0)
			{
				Logger.LogErrorFormat(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Start PVP Mode!!", new object[0]);
			}
			else
			{
				Logger.LogErrorFormat(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Start PVE Mode!!", new object[0]);
			}
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.ToString() + "\n");
		}
	}

	// Token: 0x06018D71 RID: 101745 RVA: 0x007C4B4C File Offset: 0x007C2F4C
	public void StartPVPRecord(byte[] buff)
	{
		try
		{
			this.Init();
			this.bufferCache = buff;
			this.bCanForceUpdateEnd = true;
			ReplayFile replayFile = new ReplayFile();
			int num = 0;
			replayFile.decode(this.bufferCache, ref num);
			if (replayFile.header.raceType == 0)
			{
				this.session = replayFile.header.sessionId;
				this._setRacePlayers(replayFile.header.players);
				this._setRaceRelayServer(replayFile.header.sessionId, new SockAddr());
				if (replayFile.header.raceType == 2)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.GuildPVP, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.battle.StartLogicServer(this);
				}
				else if (replayFile.header.raceType == 8)
				{
					this.battle = BattleFactory.CreateBattle(BattleType.ChijiPVP, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.ChijiPVP, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.battle.StartLogicServer(this);
				}
				else
				{
					this.battle = BattleFactory.CreateBattle(BattleType.MutiPlayer, eDungeonMode.SyncFrame, (int)replayFile.header.pkDungeonId);
					this.record = this.battle.recordServer;
					this.record.isLogicServerSaveRecordInTheEnd = true;
					this.record.sessionID = replayFile.header.sessionId.ToString();
					this.battle.SetBattleFlag(replayFile.header.battleFlag);
					this.battle.recordServer.StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, replayFile.header.sessionId.ToString(), true, false, true, false);
					this.battle.StartLogicServer(this);
				}
			}
			else
			{
				SceneDungeonStartRes sceneDungeonStartRes = new SceneDungeonStartRes();
				sceneDungeonStartRes.decode(this.bufferCache, ref num);
				DataManager<BattleDataManager>.GetInstance().ClearBatlte();
				DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleInfo(sceneDungeonStartRes);
				this._setRacePlayers(sceneDungeonStartRes.players);
				this._setRaceRelayServer(sceneDungeonStartRes.session, sceneDungeonStartRes.addr);
				eDungeonMode mode;
				if (sceneDungeonStartRes.session == 0UL)
				{
					mode = eDungeonMode.LocalFrame;
				}
				else
				{
					mode = eDungeonMode.SyncFrame;
				}
				this.session = sceneDungeonStartRes.session;
				BattleType battleType = ChapterUtility.GetBattleType((int)sceneDungeonStartRes.dungeonId);
				this.battle = BattleFactory.CreateBattle(battleType, mode, (int)sceneDungeonStartRes.dungeonId);
				this.record = this.battle.recordServer;
				this.record.isLogicServerSaveRecordInTheEnd = true;
				this.record.sessionID = sceneDungeonStartRes.session.ToString();
				this.battle.SetBattleFlag(sceneDungeonStartRes.battleFlag);
				this.battle.recordServer.StartRecord(battleType, mode, sceneDungeonStartRes.session.ToString(), true, false, true, false);
				this.battle.StartLogicServer(this);
			}
			this._PushFrameCommand(replayFile.frames);
			if (replayFile.header.raceType == 0)
			{
				Logger.LogErrorFormat(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Start PVP Mode!!", new object[0]);
			}
			else
			{
				Logger.LogErrorFormat(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Start PVE Mode!!", new object[0]);
			}
		}
		catch (Exception ex)
		{
			Logger.LogError(ex.ToString() + "\n");
		}
	}

	// Token: 0x06018D72 RID: 101746 RVA: 0x007C4F74 File Offset: 0x007C3374
	public void Update(int delta)
	{
		try
		{
			if (this.isEnd())
			{
				this.EndBattle();
			}
			else if (this.currentEndFrame >= LogicServer.logicFrameStep)
			{
				int num = (int)LogicServer.logicUpdateStep;
				this.timeAcc = delta;
				if (this.battle == null || this.battle.recordServer != null)
				{
				}
				while (this.timeAcc >= num)
				{
					if (!this.bCanForceUpdateEnd && this.curFrame > this.currentEndFrame - LogicServer.logicFrameStep + 1U)
					{
						break;
					}
					this.timeAcc -= num;
					this.curFrame += LogicServer.logicFrameStep;
					if (this.battle == null || this.battle.recordServer != null)
					{
					}
					this.UpdateSendChecksum();
					if (this.m_logicFinishType == -1 && this.battle != null)
					{
						if (this.battle.dungeonManager != null)
						{
							this.m_logicFinishType = ((!this.battle.dungeonManager.IsFinishFight()) ? -1 : 1);
						}
						else
						{
							this.m_logicFinishType = 2;
						}
					}
					this.UpdateReplayFrame(num);
				}
				if (this.frameQueue.Count <= 0 && this.bCanForceUpdateEnd)
				{
					this.timeEndOut += delta;
					if (this.timeEndOut > this.timeEndOutMS)
					{
						this.battle.dungeonManager.FinishFight();
						this.Close();
					}
				}
			}
		}
		catch (Exception ex)
		{
			try
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("LogicServer Save Error Session {0} Begin -- type {1}", this.session, this.m_logicFinishType));
				BeUtility.SaveBattleRecord(this.GetBattle());
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("LogicServer Save Error Session {0} End -- type {1}", this.session, this.m_logicFinishType));
			}
			catch (Exception ex2)
			{
				LogicServer.LogConsole(LogicServer.LogicServerLogType.Error, string.Format("LogicServer Save Session {0} Failed reason {1}", this.session, ex2.ToString()));
			}
			finally
			{
				Logger.LogError(ex.ToString() + " session:" + this.session.ToString() + "\n");
			}
		}
	}

	// Token: 0x06018D73 RID: 101747 RVA: 0x007C5204 File Offset: 0x007C3604
	public bool isEnd()
	{
		if (this.battle == null)
		{
			return true;
		}
		if (this.battle.dungeonManager == null)
		{
			return true;
		}
		bool flag = this.battle.dungeonManager.IsFinishFight();
		if (flag && this.isClosed)
		{
			this.EndBattle();
		}
		return flag && this.isClosed;
	}

	// Token: 0x06018D74 RID: 101748 RVA: 0x007C5267 File Offset: 0x007C3667
	public bool isFightFinish()
	{
		return this.battle == null || this.battle.dungeonManager == null || this.battle.dungeonManager.IsFinishFight();
	}

	// Token: 0x06018D75 RID: 101749 RVA: 0x007C5298 File Offset: 0x007C3698
	public void PushFrameCommand(IntPtr buff, int bufflen)
	{
		this.CopyBufferCache(buff, bufflen);
		RelaySvrFrameDataNotify relaySvrFrameDataNotify = new RelaySvrFrameDataNotify();
		relaySvrFrameDataNotify.decode(this.bufferCache);
		this._PushFrameCommand(relaySvrFrameDataNotify.frames);
		this._recordRelayFileFrame(relaySvrFrameDataNotify);
	}

	// Token: 0x06018D76 RID: 101750 RVA: 0x007C52D4 File Offset: 0x007C36D4
	private void _recordRelayFileFrame(RelaySvrFrameDataNotify ntf)
	{
		if (ntf == null)
		{
			return;
		}
		if (ntf.frames == null)
		{
			return;
		}
		if (this.record == null)
		{
			return;
		}
		if (!this.record.IsReplayRecord(false))
		{
			return;
		}
		this.mCacheFrame.Clear();
		for (int i = 0; i < ntf.frames.Length; i++)
		{
			if (ntf.frames[i].data != null && ntf.frames[i].data.Length > 0)
			{
				this.mCacheFrame.Add(ntf.frames[i]);
			}
		}
		if (this.mCacheFrame.Count > 0)
		{
			ntf.frames = this.mCacheFrame.ToArray();
			this.record.RecordServerFrames(ntf.frames);
		}
		this.mCacheFrame.Clear();
	}

	// Token: 0x06018D77 RID: 101751 RVA: 0x007C53B0 File Offset: 0x007C37B0
	protected void _PushFrameCommand(Frame[] frames)
	{
		if (this.record != null && this.record.IsProcessRecord())
		{
			foreach (Frame frame in frames)
			{
				for (int j = 0; j < frame.data.Length; j++)
				{
					_fighterInput fighterInput = frame.data[j];
					byte seat = fighterInput.seat;
					_inputData input = fighterInput.input;
					IFrameCommand frameCommand = FrameCommandFactory.CreateCommand(input.data1);
					if (frameCommand != null)
					{
						FrameCommandID data = (FrameCommandID)input.data1;
						if (data != FrameCommandID.NetQuality)
						{
							frameCommand.SetValue(frame.sequence, seat, input);
						}
					}
				}
			}
		}
		this._pushNetCommand(frames);
	}

	// Token: 0x06018D78 RID: 101752 RVA: 0x007C5468 File Offset: 0x007C3868
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

	// Token: 0x06018D79 RID: 101753 RVA: 0x007C54CB File Offset: 0x007C38CB
	private void _setRaceRelayServer(ulong session, SockAddr addr)
	{
		ClientApplication.playerinfo.session = session;
		ClientApplication.relayServer.ip = addr.ip;
		ClientApplication.relayServer.port = addr.port;
	}

	// Token: 0x06018D7A RID: 101754 RVA: 0x007C54F8 File Offset: 0x007C38F8
	public uint GetSvrFrame()
	{
		return this.currentEndFrame;
	}

	// Token: 0x06018D7B RID: 101755 RVA: 0x007C5500 File Offset: 0x007C3900
	private void SetSvrFrame(uint svrNum)
	{
		svrNum >>= 1;
		svrNum <<= 1;
		this.currentEndFrame = svrNum;
	}

	// Token: 0x06018D7C RID: 101756 RVA: 0x007C5513 File Offset: 0x007C3913
	private void CopyBufferCache(IntPtr buff, int bufflen)
	{
		this.bufferCache = new byte[bufflen];
		Marshal.Copy(buff, this.bufferCache, 0, bufflen);
	}

	// Token: 0x06018D7D RID: 101757 RVA: 0x007C5530 File Offset: 0x007C3930
	private void _pushNetCommand(Frame[] frames)
	{
		foreach (Frame frame in frames)
		{
			this.SetSvrFrame(frame.sequence);
			for (int j = 0; j < frame.data.Length; j++)
			{
				_fighterInput fighterInput = frame.data[j];
				byte seat = fighterInput.seat;
				_inputData input = fighterInput.input;
				IFrameCommand frameCommand = FrameCommandFactory.CreateCommand(input.data1);
				if (frameCommand == null)
				{
					Logger.LogErrorFormat("Seat{0} Data Id {1}FrameCommand is Null!! \n", new object[]
					{
						seat,
						input.data1
					});
				}
				else
				{
					frameCommand.SetValue(frame.sequence, seat, input);
					BaseFrameCommand baseFrameCommand = frameCommand as BaseFrameCommand;
					if (baseFrameCommand != null)
					{
						baseFrameCommand.sendTime = input.sendTime;
					}
					FrameCommandID id = frameCommand.GetID();
					if (!this.isGetStartFrame && id == FrameCommandID.GameStart)
					{
						this.isGetStartFrame = true;
						this.ClearCmdQueue();
					}
					if (id == FrameCommandID.RaceEnd)
					{
						this.bCanForceUpdateEnd = true;
					}
					this.frameQueue.Enqueue(frameCommand);
					if (this.record != null && this.record.IsProcessRecord())
					{
						this.record.RecordProcess2("T[{0}][CMD]PUSH CMD:{1} FrameSequence:{2}", new object[]
						{
							DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:ms"),
							frameCommand.GetString(),
							frame.sequence
						});
					}
				}
			}
		}
	}

	// Token: 0x06018D7E RID: 101758 RVA: 0x007C56A9 File Offset: 0x007C3AA9
	private void ClearCmdQueue()
	{
		while (this.frameQueue.Count > 0)
		{
			this.frameQueue.Dequeue();
		}
	}

	// Token: 0x06018D7F RID: 101759 RVA: 0x007C56D0 File Offset: 0x007C3AD0
	private void UpdateReplayFrame(int delta)
	{
		while (this.frameQueue.Count > 0)
		{
			IFrameCommand frameCommand = this.frameQueue.Peek();
			uint num = (frameCommand.GetFrame() + this.svrFrameLater) * this.keyFrameRate;
			if (num > this.curFrame)
			{
				break;
			}
			IFrameCommand frameCommand2 = this.frameQueue.Dequeue();
			if (frameCommand2 != null)
			{
				BaseFrameCommand baseFrameCommand = frameCommand2 as BaseFrameCommand;
				baseFrameCommand.battle = this.battle;
				if (this.battle != null && this.battle.recordServer != null)
				{
					this.battle.recordServer.MarkString(142055431U, new string[]
					{
						frameCommand2.GetString()
					});
				}
				frameCommand2.ExecCommand();
			}
			if (this.frameQueue.Count <= 0)
			{
				this.timeEndOut = 0;
			}
		}
		if (this.battle.dungeonManager != null)
		{
			this.battle.dungeonManager.Update(delta);
		}
	}

	// Token: 0x06018D80 RID: 101760 RVA: 0x007C57C8 File Offset: 0x007C3BC8
	private void SendChecksum()
	{
		if (this.battle.HasFlag(BattleFlagType.UseOldCheatSync))
		{
			if (this.isEnd())
			{
				return;
			}
		}
		else if (this.isFightFinish())
		{
			return;
		}
		LogicServer.OnServerCheckSum(this.session, this.curFrame, this.battle.FrameRandom.callNum);
	}

	// Token: 0x06018D81 RID: 101761 RVA: 0x007C582C File Offset: 0x007C3C2C
	private void UpdateSendChecksum()
	{
		this.battle.FrameRandom.callFrame = this.curFrame;
		this.lastFrame = this.curFrame;
		this.lastRandNum = this.battle.FrameRandom.callNum;
		if (this.curFrame > 0U)
		{
			this.SendChecksum();
		}
	}

	// Token: 0x06018D82 RID: 101762 RVA: 0x007C5884 File Offset: 0x007C3C84
	public void SyncLastCheckSum()
	{
		Logger.LogErrorFormat("[SyncLastCheckSum] sessionid: {0} {1} {2}", new object[]
		{
			this.session,
			this.lastFrame,
			this.lastRandNum
		});
		LogicServer.OnServerCheckSum(this.session, this.lastFrame, this.lastRandNum);
	}

	// Token: 0x06018D83 RID: 101763 RVA: 0x007C58E4 File Offset: 0x007C3CE4
	private void EndBattle()
	{
		try
		{
			if (!this.bIsEnd)
			{
				this.bIsEnd = true;
				this.battle.End(true);
			}
		}
		catch (Exception ex)
		{
			Logger.LogErrorFormat(ex.ToString() + "\n", new object[0]);
		}
	}

	// Token: 0x06018D84 RID: 101764 RVA: 0x007C5948 File Offset: 0x007C3D48
	public void GiveUpVerify()
	{
		if (!this.isEnd())
		{
			this.battle.dungeonManager.FinishFight();
			this.Close();
		}
		this.EndBattle();
	}

	// Token: 0x06018D85 RID: 101765 RVA: 0x007C5971 File Offset: 0x007C3D71
	public void SaveRecord()
	{
		this.record.LogicServerSaveRecordAndReplay();
	}

	// Token: 0x06018D86 RID: 101766 RVA: 0x007C597E File Offset: 0x007C3D7E
	public bool HaveFrameInQueue()
	{
		return this.frameQueue.Count > 0;
	}

	// Token: 0x04011E31 RID: 73265
	private bool bRun;

	// Token: 0x04011E32 RID: 73266
	private int timeAcc;

	// Token: 0x04011E33 RID: 73267
	private int timeEndOut;

	// Token: 0x04011E34 RID: 73268
	private int timeEndOutMS = 20000;

	// Token: 0x04011E35 RID: 73269
	private uint curFrame;

	// Token: 0x04011E36 RID: 73270
	private uint keyFrameRate = 1U;

	// Token: 0x04011E37 RID: 73271
	private uint serverSeed;

	// Token: 0x04011E38 RID: 73272
	private uint frameSpeed = 1U;

	// Token: 0x04011E39 RID: 73273
	private uint svrFrameLater;

	// Token: 0x04011E3A RID: 73274
	private bool isGetStartFrame;

	// Token: 0x04011E3B RID: 73275
	private bool isClosed;

	// Token: 0x04011E3C RID: 73276
	private RecordServer record;

	// Token: 0x04011E3D RID: 73277
	private int m_logicFinishType = -1;

	// Token: 0x04011E3E RID: 73278
	private ulong session;

	// Token: 0x04011E3F RID: 73279
	private uint lastFrame;

	// Token: 0x04011E40 RID: 73280
	private uint lastRandNum;

	// Token: 0x04011E41 RID: 73281
	public static LogicServer sm_Root;

	// Token: 0x04011E42 RID: 73282
	private bool mIsFire = true;

	// Token: 0x04011E43 RID: 73283
	private BaseBattle battle;

	// Token: 0x04011E44 RID: 73284
	private static uint logicUpdateStep = 32U;

	// Token: 0x04011E45 RID: 73285
	private static uint logicFrameStep = 2U;

	// Token: 0x04011E46 RID: 73286
	private static int logicFrameStepDelta = 0;

	// Token: 0x04011E47 RID: 73287
	public static LogicServer rootLogic;

	// Token: 0x04011E48 RID: 73288
	protected Queue<IFrameCommand> frameQueue = new Queue<IFrameCommand>();

	// Token: 0x04011E49 RID: 73289
	private byte[] bufferCache = new byte[65535];

	// Token: 0x04011E4A RID: 73290
	private static byte[] raceEndBuffer = new byte[65536];

	// Token: 0x04011E4B RID: 73291
	private bool bCanForceUpdateEnd;

	// Token: 0x04011E4C RID: 73292
	private bool bIsEnd;

	// Token: 0x04011E4D RID: 73293
	private List<Frame> mCacheFrame = new List<Frame>();

	// Token: 0x04011E4E RID: 73294
	private uint currentEndFrame;

	// Token: 0x02004585 RID: 17797
	public enum LogicServerLogType
	{
		// Token: 0x04011E50 RID: 73296
		Debug,
		// Token: 0x04011E51 RID: 73297
		Info,
		// Token: 0x04011E52 RID: 73298
		Warning,
		// Token: 0x04011E53 RID: 73299
		Error
	}
}
