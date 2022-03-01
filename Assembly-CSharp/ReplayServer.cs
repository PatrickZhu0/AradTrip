using System;
using System.Collections.Generic;
using System.IO;
using GameClient;
using LibZip;
using Network;
using Protocol;
using UnityEngine;

// Token: 0x020046C8 RID: 18120
public class ReplayServer : Singleton<ReplayServer>
{
	// Token: 0x17002134 RID: 8500
	// (get) Token: 0x06019AF8 RID: 105208 RVA: 0x00818E49 File Offset: 0x00817249
	// (set) Token: 0x06019AF9 RID: 105209 RVA: 0x00818E51 File Offset: 0x00817251
	public SockAddr LiveShowServerAddr
	{
		get
		{
			return this.mLiveShowServerAddr;
		}
		set
		{
			this.mLiveShowServerAddr = value;
		}
	}

	// Token: 0x06019AFA RID: 105210 RVA: 0x00818E5A File Offset: 0x0081725A
	public bool IsLiveShow()
	{
		return this.mIsLiveShow;
	}

	// Token: 0x06019AFB RID: 105211 RVA: 0x00818E62 File Offset: 0x00817262
	public void SetLiveShow()
	{
		this.mIsLiveShow = true;
	}

	// Token: 0x06019AFC RID: 105212 RVA: 0x00818E6B File Offset: 0x0081726B
	public void ReadyToLiveShow()
	{
		if (FrameSync.instance != null)
		{
			FrameSync.instance.StartFrameSync((uint)ClientApplication.playerinfo.session, true);
		}
	}

	// Token: 0x06019AFD RID: 105213 RVA: 0x00818E90 File Offset: 0x00817290
	public void StartLiveShow()
	{
		Logger.LogForReplay("[REPLAY]StartReplay", new object[0]);
		this.isReplay = true;
		this.mIsLiveShow = true;
		this.timeAcc = 0;
		this.started = false;
		this.replaySource = ReplayPlayFrom.MONEY_REWARD;
		this.lastPlaying = true;
		this.pause = false;
	}

	// Token: 0x06019AFE RID: 105214 RVA: 0x00818EDE File Offset: 0x008172DE
	public void SetBattle(PVPBattle newBattle)
	{
		this.battle = newBattle;
		if (this.battle != null)
		{
			this.battle.isReplay = true;
		}
	}

	// Token: 0x06019AFF RID: 105215 RVA: 0x00818F00 File Offset: 0x00817300
	public ReplayErrorCode StartReplay(string filename = null, ReplayPlayFrom from = ReplayPlayFrom.VIDEO_FRAME, bool isEditMode = false, bool isOpenMark = false, bool isReplayMode = false)
	{
		if (DataManager<TeamDataManager>.GetInstance().HasTeam())
		{
			return ReplayErrorCode.HAS_TEAM;
		}
		string arg = string.Empty;
		if (!isEditMode)
		{
			if (filename == null || !this.HasReplay(filename))
			{
				if (Global.Settings.pvpDefaultSesstionID == null || Global.Settings.pvpDefaultSesstionID.Length <= 1)
				{
					return ReplayErrorCode.FILE_NOT_FOUND;
				}
				filename = Global.Settings.pvpDefaultSesstionID;
			}
			Logger.LogForReplay("[REPLAY]StartReplay", new object[0]);
			this.isReplay = true;
			this.timeAcc = 0;
			this.started = false;
			if (from >= ReplayPlayFrom.VIDEO_FRAME)
			{
				this.lastPlaying = true;
				this.replaySource = from;
			}
			this.pause = false;
			Logger.LogForReplay("[REPLAY]StartReplay - CreateData", new object[0]);
			ClientApplication.playerinfo.session = Convert.ToUInt64(filename);
			this.CreateData(filename);
		}
		else
		{
			if (filename == null || !File.Exists(filename))
			{
				return ReplayErrorCode.FILE_NOT_FOUND;
			}
			string fileName = Path.GetFileName(filename);
			arg = Path.GetDirectoryName(filename);
			this.isReplay = true;
			this.timeAcc = 0;
			this.started = false;
			if (from >= ReplayPlayFrom.VIDEO_FRAME)
			{
				this.lastPlaying = true;
				this.replaySource = from;
			}
			this.pause = false;
			Logger.LogForReplay("[REPLAY]StartReplay - CreateData", new object[0]);
			ClientApplication.playerinfo.session = Convert.ToUInt64(fileName);
			this.recordData = new RecordData();
			this.recordData.DeSerialiaction(filename);
		}
		if (!this.CheckVersion(this.recordData.clientVersion))
		{
			return ReplayErrorCode.VERSION_NOT_MATCH;
		}
		Logger.LogForReplay("[REPLAY]StartReplay - init", new object[0]);
		this.SetRacePlayers(this.recordData.replayFile.header.players);
		if (this.recordData.replayFile.header.raceType == 5 || this.recordData.replayFile.header.raceType == 6)
		{
			BattleMain.OpenBattle(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, this.recordData.pvpDungeonID, this.recordData.sessionID);
		}
		else if (this.recordData.replayFile.header.raceType == 7)
		{
			BattleMain.OpenBattle(BattleType.ScufflePVP, eDungeonMode.SyncFrame, this.recordData.pvpDungeonID, this.recordData.sessionID);
		}
		else if (this.recordData.replayFile.header.raceType == 2)
		{
			BattleMain.OpenBattle(BattleType.GuildPVP, eDungeonMode.SyncFrame, this.recordData.pvpDungeonID, this.recordData.sessionID);
		}
		else if (this.recordData.replayFile.header.raceType == 3 || this.recordData.replayFile.header.raceType == 4)
		{
			BattleMain.OpenBattle(BattleType.MoneyRewardsPVP, eDungeonMode.LocalFrame, this.recordData.pvpDungeonID, this.recordData.sessionID);
		}
		else
		{
			BattleMain.OpenBattle(BattleType.MutiPlayer, eDungeonMode.SyncFrame, this.recordData.pvpDungeonID, this.recordData.sessionID);
		}
		Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
		this.battle = (BattleMain.instance.GetBattle() as PVPBattle);
		if (this.battle != null)
		{
			this.battle.isReplay = true;
		}
		BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
		if (baseBattle != null)
		{
			baseBattle.PkRaceType = (int)this.recordData.replayFile.header.raceType;
			baseBattle.SetBattleFlag(this.recordData.replayFile.header.battleFlag);
		}
		if (this.recordData.replayFile.header.raceType == 5 || this.recordData.replayFile.header.raceType == 6)
		{
			Singleton<RecordServer>.GetInstance().StartRecord(BattleType.PVP3V3Battle, eDungeonMode.SyncFrame, "123456789", true, false, isOpenMark, isReplayMode);
		}
		else if (this.recordData.replayFile.header.raceType == 7)
		{
			Singleton<RecordServer>.GetInstance().StartRecord(BattleType.ScufflePVP, eDungeonMode.SyncFrame, "123456789", true, false, isOpenMark, isReplayMode);
		}
		else
		{
			Singleton<RecordServer>.GetInstance().StartRecord(BattleType.MutiPlayer, eDungeonMode.SyncFrame, "123456789", true, false, isOpenMark, isReplayMode);
		}
		if (isReplayMode)
		{
			Singleton<RecordServer>.GetInstance().SetMarkFile(string.Format("{0}/{1}.mark", arg, ClientApplication.playerinfo.session));
		}
		return ReplayErrorCode.SUCCEED;
	}

	// Token: 0x06019B00 RID: 105216 RVA: 0x00819350 File Offset: 0x00817750
	public ReplayErrorCode StartPVEReplay(string filename = null, ReplayPlayFrom from = ReplayPlayFrom.VIDEO_FRAME, bool isOpenMark = false, bool isReplayMode = false)
	{
		if (filename == null)
		{
			return ReplayErrorCode.FILE_NOT_FOUND;
		}
		this.isReplay = true;
		this.timeAcc = 0;
		this.started = false;
		if (from >= ReplayPlayFrom.VIDEO_FRAME)
		{
			this.lastPlaying = true;
			this.replaySource = from;
		}
		this.pause = false;
		Logger.LogForReplay("[REPLAY]StartReplay - CreateData", new object[0]);
		this.recordData = new RecordData();
		this.recordData.DeSerialiaction(filename);
		DataManager<BattleDataManager>.GetInstance().ClearBatlte();
		DataManager<BattleDataManager>.GetInstance().ConvertDungeonBattleInfo(this.recordData.dungeonInfo);
		DataManager<BattleDataManager>.GetInstance().PlayerInfo = this.recordData.dungeonInfo.players;
		ClientApplication.racePlayerInfo = this.recordData.dungeonInfo.players;
		for (int i = 0; i < ClientApplication.racePlayerInfo.Length; i++)
		{
			RacePlayerInfo racePlayerInfo = ClientApplication.racePlayerInfo[i];
			if (racePlayerInfo.accid == ClientApplication.playerinfo.accid)
			{
				ClientApplication.playerinfo.seat = racePlayerInfo.seat;
			}
		}
		ClientApplication.playerinfo.session = this.recordData.dungeonInfo.session;
		ClientApplication.relayServer.ip = this.recordData.dungeonInfo.addr.ip;
		ClientApplication.relayServer.port = this.recordData.dungeonInfo.addr.port;
		ClientApplication.playerinfo.accid = this.recordData.dungeonInfo.players[0].accid;
		eDungeonMode mode;
		if (this.recordData.dungeonInfo.session == 0UL)
		{
			mode = eDungeonMode.LocalFrame;
		}
		else
		{
			mode = eDungeonMode.SyncFrame;
		}
		BattleType battleType = ChapterUtility.GetBattleType((int)this.recordData.dungeonInfo.dungeonId);
		BattleMain.OpenBattle(battleType, eDungeonMode.RecordFrame, (int)this.recordData.dungeonInfo.dungeonId, string.Empty);
		BaseBattle baseBattle = BattleMain.instance.GetBattle() as BaseBattle;
		baseBattle.recordServer.sessionID = this.recordData.dungeonInfo.session.ToString();
		baseBattle.recordServer.StartRecord(battleType, mode, this.recordData.dungeonInfo.session.ToString(), true, true, isOpenMark, isReplayMode);
		if (isReplayMode)
		{
			string directoryName = Path.GetDirectoryName(filename);
			baseBattle.recordServer.SetMarkFile(string.Format("{0}/{1}.mark", directoryName, ClientApplication.playerinfo.session));
		}
		baseBattle.SetBattleFlag(this.recordData.dungeonInfo.battleFlag);
		baseBattle.SetDungeonClearInfo(this.recordData.dungeonInfo.clearedDungeonIds);
		RaidBattle raidBattle = baseBattle as RaidBattle;
		if (raidBattle != null)
		{
			for (int j = 0; j < this.recordData.dungeonInfo.clearedDungeonIds.Length; j++)
			{
				raidBattle.DungeonDestroyNotify((int)this.recordData.dungeonInfo.clearedDungeonIds[j]);
			}
		}
		GuildPVEBattle guildPVEBattle = baseBattle as GuildPVEBattle;
		if (guildPVEBattle != null && this.recordData.dungeonInfo.guildDungeonInfo != null)
		{
			guildPVEBattle.SetBossInfo(this.recordData.dungeonInfo.guildDungeonInfo.bossOddBlood, this.recordData.dungeonInfo.guildDungeonInfo.bossTotalBlood);
			guildPVEBattle.SetBuffInfo(this.recordData.dungeonInfo.guildDungeonInfo.buffVec);
		}
		FinalTestBattle finalTestBattle = baseBattle as FinalTestBattle;
		if (finalTestBattle != null && this.recordData.dungeonInfo.zjslDungeonInfo != null)
		{
			finalTestBattle.SetBossInfo(this.recordData.dungeonInfo.zjslDungeonInfo.boss1ID, this.recordData.dungeonInfo.zjslDungeonInfo.boss1RemainHp, this.recordData.dungeonInfo.zjslDungeonInfo.boss2ID, this.recordData.dungeonInfo.zjslDungeonInfo.boss2RemainHp);
			finalTestBattle.SetBuffInfo(this.recordData.dungeonInfo.zjslDungeonInfo.buffVec);
		}
		Singleton<ClientSystemManager>.GetInstance().SwitchSystem<ClientSystemBattle>(null, null, false);
		return ReplayErrorCode.SUCCEED;
	}

	// Token: 0x06019B01 RID: 105217 RVA: 0x00819755 File Offset: 0x00817B55
	public bool CheckVersion(uint replayVersion)
	{
		return Singleton<VersionManager>.GetInstance().ServerVersion() == replayVersion;
	}

	// Token: 0x06019B02 RID: 105218 RVA: 0x00819764 File Offset: 0x00817B64
	public void SetLastPlaying(bool flag)
	{
		this.lastPlaying = flag;
	}

	// Token: 0x06019B03 RID: 105219 RVA: 0x0081976D File Offset: 0x00817B6D
	public bool IsLastPlaying()
	{
		return this.lastPlaying;
	}

	// Token: 0x06019B04 RID: 105220 RVA: 0x00819778 File Offset: 0x00817B78
	public void Start()
	{
		this.started = true;
		Logger.LogForReplay("[REPLAY]StartReplay - start", new object[0]);
		if (!this.IsLiveShow())
		{
			FrameSync.instance.StartFrameSync(this.recordData.startTime, true);
		}
		Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkLoadingFrame>(null, false);
		if (!this.IsLiveShow())
		{
			FrameSync.instance.PushNetCommand(this.recordData.replayFile.frames);
		}
		if (this.battle != null)
		{
			this.battle.StartCountDown(true);
		}
		BattleMain.instance.Main.RegisterEvent(BeEventSceneType.onStartPK, delegate(object[] args)
		{
			if (this.pkTimer == null)
			{
				this.pkTimer = BattleMain.instance.Main.pkTimer;
			}
		});
	}

	// Token: 0x06019B05 RID: 105221 RVA: 0x00819823 File Offset: 0x00817C23
	public void Clear()
	{
		this.EndReplay(false, "ReplayServer Clear");
	}

	// Token: 0x06019B06 RID: 105222 RVA: 0x00819834 File Offset: 0x00817C34
	public void EndReplay(bool openFrame = true, string reason = "")
	{
		if (!openFrame && this.mDelayResultFrameHandle.IsValid())
		{
			ClientSystemBattle clientSystemBattle = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
			if (clientSystemBattle != null)
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PkReplayResultFrame>(null, false);
			}
			this.mDelayResultFrameHandle.SetRemove(true);
		}
		if (!this.isReplay)
		{
			return;
		}
		if (this.battle != null)
		{
			this.battle._stopRobotAI();
		}
		if (this.IsLiveShow() && MonoSingleton<NetManager>.instance != null)
		{
			MonoSingleton<NetManager>.instance.Disconnect(ServerType.RELAY_SERVER);
		}
		Logger.LogForReplay("[REPLAY]EndReplay", new object[0]);
		this.isReplay = false;
		this.recordData = null;
		this.started = false;
		if (this.IsLiveShow())
		{
			Singleton<RecordServer>.GetInstance().EndLiveShowRecord();
		}
		else
		{
			Singleton<RecordServer>.GetInstance().EndRecord("EndReplay reason " + reason);
		}
		Time.timeScale = 1f;
		this.scaleTimeIndex = 0;
		ClientSystemBattle clientSystemBattle2 = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
		if (clientSystemBattle2 != null)
		{
			clientSystemBattle2.SetReplayVisible(false);
		}
		if (openFrame && !this.mDelayResultFrameHandle.IsValid())
		{
			this.mDelayResultFrameHandle = Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(5000, delegate
			{
				ClientSystemBattle clientSystemBattle3 = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemBattle;
				if (clientSystemBattle3 != null)
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PkReplayResultFrame>(FrameLayer.Middle, null, string.Empty);
				}
			}, 0, 0, false);
		}
		this.mIsInPersueMode = false;
		this.mIsLiveShow = false;
		this.mLiveShowServerAddr = null;
	}

	// Token: 0x17002135 RID: 8501
	// (get) Token: 0x06019B07 RID: 105223 RVA: 0x008199B4 File Offset: 0x00817DB4
	public bool isInPersueMode
	{
		get
		{
			return this.mIsInPersueMode;
		}
	}

	// Token: 0x06019B08 RID: 105224 RVA: 0x008199BC File Offset: 0x00817DBC
	public void StartPersue()
	{
		this.mIsInPersueMode = true;
	}

	// Token: 0x06019B09 RID: 105225 RVA: 0x008199C8 File Offset: 0x00817DC8
	private void _UpdateLiveShow(int delta)
	{
		bool flag = false;
		FrameSync.instance.UpdateLiveShowFrame(this.mIsInPersueMode, ref flag);
		if (this.mIsInPersueMode != flag)
		{
			this.mIsInPersueMode = flag;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.onLiveShowPursueModeChange, null, null, null, null);
		}
	}

	// Token: 0x06019B0A RID: 105226 RVA: 0x00819A10 File Offset: 0x00817E10
	public void Update(int delta)
	{
		if (!this.started || this.pause)
		{
			return;
		}
		if (this.IsLiveShow())
		{
			this._UpdateLiveShow(delta);
			return;
		}
		if (this.recordData == null)
		{
			return;
		}
		if (this.IsDurationEnd())
		{
			string reason = string.Empty;
			if (this.pkTimer != null)
			{
				reason = string.Format("ReplayServer update {0} -{1}", this.pkTimer.GetPassTime(), this.recordData.duration + 10);
			}
			else
			{
				reason = "pkTimer is Null";
			}
			this.Stop(true, reason);
		}
		int frameMs = (int)FrameSync.instance.frameMs;
		this.timeAcc += delta;
		while (this.timeAcc >= frameMs)
		{
			this.timeAcc -= frameMs;
			if (this.recordData == null)
			{
				break;
			}
			FrameSync.instance.curFrame += Global.Settings.logicFrameStep;
			FrameSync.instance.UpdateReplayFrame(frameMs);
		}
		FrameSync.instance.UpdateReplayFrameGraphic((int)(Time.deltaTime * 1000f));
	}

	// Token: 0x06019B0B RID: 105227 RVA: 0x00819B3A File Offset: 0x00817F3A
	public bool IsDurationEnd()
	{
		return this.pkTimer != null && this.pkTimer.GetPassTime() >= this.recordData.duration + 10;
	}

	// Token: 0x06019B0C RID: 105228 RVA: 0x00819B6D File Offset: 0x00817F6D
	public bool IsReplay()
	{
		return this.isReplay;
	}

	// Token: 0x06019B0D RID: 105229 RVA: 0x00819B75 File Offset: 0x00817F75
	private void CreateData(string filename)
	{
		this.recordData = new RecordData();
		this.recordData.DeSerialiaction(RecordData.GenPath(filename));
	}

	// Token: 0x06019B0E RID: 105230 RVA: 0x00819B94 File Offset: 0x00817F94
	private void SetRacePlayers(RacePlayerInfo[] players)
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

	// Token: 0x06019B0F RID: 105231 RVA: 0x00819BF7 File Offset: 0x00817FF7
	public void Pause()
	{
		if (!this.started || this.pause)
		{
			return;
		}
		this.pause = true;
		BattleMain.instance.GetDungeonManager().PauseFight(true, string.Empty, false);
	}

	// Token: 0x06019B10 RID: 105232 RVA: 0x00819C2D File Offset: 0x0081802D
	public void Resume()
	{
		if (!this.started || !this.pause)
		{
			return;
		}
		this.pause = false;
		BattleMain.instance.GetDungeonManager().ResumeFight(true, string.Empty, false);
	}

	// Token: 0x06019B11 RID: 105233 RVA: 0x00819C63 File Offset: 0x00818063
	public void ScaleTime()
	{
		this.scaleTimeIndex++;
		this.scaleTimeIndex %= this.scaleFactors.Length;
		Time.timeScale = (float)this.scaleFactors[this.scaleTimeIndex];
	}

	// Token: 0x17002136 RID: 8502
	// (get) Token: 0x06019B12 RID: 105234 RVA: 0x00819C9B File Offset: 0x0081809B
	public int timeScaler
	{
		get
		{
			return this.scaleFactors[this.scaleTimeIndex];
		}
	}

	// Token: 0x06019B13 RID: 105235 RVA: 0x00819CAA File Offset: 0x008180AA
	public void Stop(bool openFrame = false, string reason = "")
	{
		this.EndReplay(openFrame, "Stop reason " + reason);
	}

	// Token: 0x06019B14 RID: 105236 RVA: 0x00819CC0 File Offset: 0x008180C0
	public bool HasRecord()
	{
		bool result = false;
		string text = RecordData.GenFileName(null);
		string filePath = RecordData.GenPath(text);
		string[] array = text.Split(new char[]
		{
			'_'
		});
		if (CFileManager.IsFileExist(filePath) && array.Length == 3 && array[1] == Singleton<VersionManager>.GetInstance().ServerVersion().ToString())
		{
			result = true;
		}
		return result;
	}

	// Token: 0x06019B15 RID: 105237 RVA: 0x00819D2C File Offset: 0x0081812C
	public void SwitchWatchPlayer(bool left)
	{
		IDungeonManager dungeonManager = BattleMain.instance.GetDungeonManager();
		IDungeonPlayerDataManager playerManager = BattleMain.instance.GetPlayerManager();
		List<BattlePlayer> allPlayers = playerManager.GetAllPlayers();
		PVP3V3Battle pvp3V3Battle = BattleMain.instance.GetBattle() as PVP3V3Battle;
		if (pvp3V3Battle != null)
		{
			BattlePlayer currentTeamFightingPlayer = playerManager.GetCurrentTeamFightingPlayer((!left) ? BattlePlayer.eDungeonPlayerTeamType.eTeamBlue : BattlePlayer.eDungeonPlayerTeamType.eTeamRed);
			if (currentTeamFightingPlayer != null)
			{
				currentTeamFightingPlayer.playerActor.isLocalActor = true;
				dungeonManager.GetGeScene().AttachCameraTo(currentTeamFightingPlayer.playerActor.m_pkGeActor);
			}
		}
		else
		{
			BattlePlayer battlePlayer = (!left) ? allPlayers[1] : allPlayers[0];
			BattlePlayer battlePlayer2 = (!left) ? allPlayers[0] : allPlayers[1];
			if (battlePlayer != null && battlePlayer2 != null)
			{
				battlePlayer.playerActor.isLocalActor = true;
				battlePlayer2.playerActor.isLocalActor = false;
				dungeonManager.GetGeScene().AttachCameraTo(battlePlayer.playerActor.m_pkGeActor);
			}
		}
	}

	// Token: 0x06019B16 RID: 105238 RVA: 0x00819E26 File Offset: 0x00818226
	public bool HasReplay(string filename)
	{
		return FileUtil.HasFile(RecordData.GenPath(filename));
	}

	// Token: 0x06019B17 RID: 105239 RVA: 0x00819E34 File Offset: 0x00818234
	public ReplayErrorCode CompressRecord(string fileName)
	{
		if (fileName == null || !this.HasReplay(fileName))
		{
			return ReplayErrorCode.FILE_NOT_FOUND;
		}
		string rootPath = RecordData.GetRootPath();
		if (!Directory.Exists(rootPath))
		{
			Logger.LogErrorFormat("[UpLoadRecord] rootPath is NotExist {0}", new object[]
			{
				rootPath
			});
			return ReplayErrorCode.FILE_NOT_FOUND;
		}
		string path = string.Format("{0}_{1}_{2}_pvp_upload.zip", Global.Settings.sdkChannel, ClientApplication.adminServer.id, fileName);
		string text = Path.Combine(rootPath, path);
		if (File.Exists(text))
		{
			return ReplayErrorCode.SUCCEED;
		}
		string[] files = Directory.GetFiles(rootPath);
		string value = string.Format("s{0}", fileName);
		List<string> list = new List<string>();
		list.Add(Path.Combine(rootPath, fileName));
		for (int i = 0; i < files.Length; i++)
		{
			string extension = Path.GetExtension(files[i]);
			if (extension.CompareTo(".txt") == 0)
			{
				string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(files[i]);
				if (fileNameWithoutExtension.Contains(value))
				{
					list.Add(files[i]);
				}
			}
		}
		if (!File.Exists(text))
		{
			try
			{
				if (!LibZipFileReader.CompressFiles(text, list.ToArray()))
				{
					Logger.LogErrorFormat("[UpLoadRecord] CompressFiles fail {0}", new object[]
					{
						text
					});
					return ReplayErrorCode.COMPRESS_ERROR;
				}
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[UpLoadRecord Exception] CompressFiles fail {0}", new object[]
				{
					ex.Message
				});
				return ReplayErrorCode.COMPRESS_ERROR;
			}
			return ReplayErrorCode.SUCCEED;
		}
		return ReplayErrorCode.SUCCEED;
	}

	// Token: 0x040124DF RID: 74975
	public RecordData recordData;

	// Token: 0x040124E0 RID: 74976
	private bool isReplay;

	// Token: 0x040124E1 RID: 74977
	private int timeAcc;

	// Token: 0x040124E2 RID: 74978
	private bool started;

	// Token: 0x040124E3 RID: 74979
	private bool lastPlaying;

	// Token: 0x040124E4 RID: 74980
	private bool pause;

	// Token: 0x040124E5 RID: 74981
	private PVPBattle battle;

	// Token: 0x040124E6 RID: 74982
	private SimpleTimer pkTimer;

	// Token: 0x040124E7 RID: 74983
	public ReplayPlayFrom replaySource;

	// Token: 0x040124E8 RID: 74984
	private bool mIsLiveShow;

	// Token: 0x040124E9 RID: 74985
	private SockAddr mLiveShowServerAddr;

	// Token: 0x040124EA RID: 74986
	private DelayCallUnitHandle mDelayResultFrameHandle;

	// Token: 0x040124EB RID: 74987
	private bool mIsInPersueMode;

	// Token: 0x040124EC RID: 74988
	private int scaleTimeIndex;

	// Token: 0x040124ED RID: 74989
	private int[] scaleFactors = new int[]
	{
		1,
		2,
		4,
		8
	};
}
