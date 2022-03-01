using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using Network;
using Protocol;
using ProtoTable;

// Token: 0x0200415D RID: 16733
public class BeDungeon : IDungeonManager, IDungeonStatistics, IDungeonEnumeratorManager
{
	// Token: 0x06016DE8 RID: 93672 RVA: 0x00708D10 File Offset: 0x00707110
	public BeDungeon(BattleType type, eDungeonMode mode, int dungeonID)
	{
		this.mMode = mode;
		this.mDungeonData = new DungeonDataManager(type, mode, dungeonID);
		this.mDungeonPlayers = new DungeonPlayerDataManager(type, mode, this);
		this.mSwitchCount = 0;
		this.mBossDamage = 0;
		this.bossID01 = 0U;
		this.bossID02 = 0U;
		this.bossDamage01 = 0;
		this.bossDamage02 = 0;
	}

	// Token: 0x17001F2C RID: 7980
	// (get) Token: 0x06016DE9 RID: 93673 RVA: 0x00708D91 File Offset: 0x00707191
	// (set) Token: 0x06016DEA RID: 93674 RVA: 0x00708D99 File Offset: 0x00707199
	public BaseBattle mBattle { get; set; }

	// Token: 0x06016DEB RID: 93675 RVA: 0x00708DA2 File Offset: 0x007071A2
	public DungeonPlayerDataManager GetDungeonPlayerDataManager()
	{
		return this.mDungeonPlayers;
	}

	// Token: 0x06016DEC RID: 93676 RVA: 0x00708DAA File Offset: 0x007071AA
	public IEnumerator AddEnumerator(IEnumerator iter, int priority = 2147483647)
	{
		if (this.mEnumertorManager != null)
		{
			return this.mEnumertorManager.AddEnumerator(iter, priority);
		}
		return null;
	}

	// Token: 0x06016DED RID: 93677 RVA: 0x00708DC6 File Offset: 0x007071C6
	public void RemoveEnumerator(IEnumerator iter)
	{
		if (this.mEnumertorManager != null)
		{
			this.mEnumertorManager.RemoveEnumerator(iter);
		}
	}

	// Token: 0x06016DEE RID: 93678 RVA: 0x00708DDF File Offset: 0x007071DF
	public void ClearAllEnumerators()
	{
		if (this.mEnumertorManager != null)
		{
			this.mEnumertorManager.ClearAllEnumerators();
		}
	}

	// Token: 0x06016DEF RID: 93679 RVA: 0x00708DF8 File Offset: 0x007071F8
	public BeScene CreateBeScene()
	{
		if (this.mBeScene != null)
		{
			this.mBeScene.ReloadScene(this.mDungeonData.CurrentScenePath());
		}
		else
		{
			this.mBeScene = BeScene.CreateScene(this.mDungeonData.CurrentScenePath());
			this.mBeScene.mBattle = this.mBattle;
			this.mBeScene.singleBloodBarCount = this.mDungeonData.table.SingleBarValue;
		}
		if (this.mBeScene != null)
		{
			this.mBeScene.TriggerEvent(BeEventSceneType.onCreate, null);
		}
		return this.mBeScene;
	}

	// Token: 0x06016DF0 RID: 93680 RVA: 0x00708E8C File Offset: 0x0070728C
	public void DestoryBeScene()
	{
		this.mSwitchCount = 0;
		this.ClearAllEnumerators();
		if (this.mDungeonData != null)
		{
			this.mDungeonData.Clear();
			this.mDungeonData = null;
		}
		if (this.mDungeonPlayers != null)
		{
			this.mDungeonPlayers.Clear();
			this.mDungeonPlayers = null;
		}
		if (this.mBeScene != null)
		{
			this.mBeScene.UnRegisterAll();
			this.mBeScene.Unload();
			this.mBeScene = null;
		}
	}

	// Token: 0x06016DF1 RID: 93681 RVA: 0x00708F08 File Offset: 0x00707308
	public BeScene GetBeScene()
	{
		return this.mBeScene;
	}

	// Token: 0x06016DF2 RID: 93682 RVA: 0x00708F10 File Offset: 0x00707310
	public GeSceneEx GetGeScene()
	{
		if (this.mBeScene != null)
		{
			return this.mBeScene.currentGeScene;
		}
		return null;
	}

	// Token: 0x06016DF3 RID: 93683 RVA: 0x00708F2A File Offset: 0x0070732A
	public DungeonDataManager GetDungeonDataManager()
	{
		return this.mDungeonData;
	}

	// Token: 0x06016DF4 RID: 93684 RVA: 0x00708F34 File Offset: 0x00707334
	public void StartFight(bool isFinishFight = false)
	{
		if (this.mBattle != null && this.mBattle.recordServer != null && this.mBattle.recordServer.IsProcessRecord())
		{
			this.mBattle.recordServer.MarkInt(142055316U, new int[]
			{
				this.GetDungeonDataManager().id.dungeonID
			});
		}
		if (this.mBeScene != null)
		{
			if (!isFinishFight)
			{
				this.mBeScene.state = BeSceneState.onReady;
				this.mBeScene.OnReady();
			}
			else
			{
				this.mBeScene.state = BeSceneState.onFinish;
			}
		}
	}

	// Token: 0x06016DF5 RID: 93685 RVA: 0x00708FD8 File Offset: 0x007073D8
	public void DoGraphicBackToFront()
	{
	}

	// Token: 0x06016DF6 RID: 93686 RVA: 0x00708FDC File Offset: 0x007073DC
	public void FinishFight()
	{
		this.mDungeonData.FinishUpdateFrameData();
		Singleton<ClientReconnectManager>.instance.canReconnectRelay = false;
		FrameSync.instance.SetDungeonMode(eDungeonMode.LocalFrame);
		if (Singleton<ReplayServer>.GetInstance().IsLiveShow() && MonoSingleton<NetManager>.instance != null)
		{
			MonoSingleton<NetManager>.instance.Disconnect(ServerType.RELAY_SERVER);
		}
		if (this.mBattle != null && this.mBattle.recordServer != null && this.mBattle.recordServer.IsProcessRecord())
		{
			this.mBattle.recordServer.Mark(107374182U);
		}
		if (this.mBeScene != null)
		{
			this.mBeScene.state = BeSceneState.onFinish;
		}
		if (this.mBattle != null && this.mBattle.recordServer != null)
		{
			this.mBattle.recordServer.EndRecordProcess();
		}
	}

	// Token: 0x06016DF7 RID: 93687 RVA: 0x007090BB File Offset: 0x007074BB
	public bool IsFinishFight()
	{
		return this.mBeScene == null || BeSceneState.onFinish == this.mBeScene.state;
	}

	// Token: 0x06016DF8 RID: 93688 RVA: 0x007090D8 File Offset: 0x007074D8
	public void PauseFight(bool pauseAnimation = true, string tag = "", bool force = false)
	{
		if (string.IsNullOrEmpty(this.mPrePauseBeSceneTag) || force)
		{
			this.mPrePauseBeSceneTag = tag;
		}
		if (this.mBeScene != null && Singleton<ReplayServer>.GetInstance().IsLiveShow() && this.mBeScene.state != BeSceneState.onFinish)
		{
			this.mBeScene.Pause(pauseAnimation);
			this.mBeScene.PauseLogic();
		}
		else if (this.mBeScene != null && (this.mMode != eDungeonMode.SyncFrame || Singleton<ReplayServer>.GetInstance().IsReplay()) && this.mBeScene.state != BeSceneState.onFinish)
		{
			RacePuaseFrame racePuaseFrame = FrameCommandFactory.CreateCommand(15U) as RacePuaseFrame;
			racePuaseFrame.isPauseLogic = true;
			FrameSync.instance.FireFrameCommand(racePuaseFrame, false);
			this.mBeScene.Pause(pauseAnimation);
		}
	}

	// Token: 0x06016DF9 RID: 93689 RVA: 0x007091AC File Offset: 0x007075AC
	public void ResumeFight(bool pauseAnimation = true, string tag = "", bool force = false)
	{
		if (tag == this.mPrePauseBeSceneTag || force)
		{
			this.mPrePauseBeSceneTag = string.Empty;
			if (this.mBeScene != null && Singleton<ReplayServer>.GetInstance().IsLiveShow() && this.mBeScene.state == BeSceneState.onPause)
			{
				this.mBeScene.Resume(pauseAnimation);
				this.mBeScene.ResumeLogic();
			}
			else if (this.mBeScene != null && (this.mMode != eDungeonMode.SyncFrame || Singleton<ReplayServer>.GetInstance().IsReplay()) && this.mBeScene.state == BeSceneState.onPause)
			{
				RacePuaseFrame racePuaseFrame = FrameCommandFactory.CreateCommand(15U) as RacePuaseFrame;
				racePuaseFrame.isPauseLogic = false;
				FrameSync.instance.FireFrameCommand(racePuaseFrame, false);
				this.mBeScene.Resume(pauseAnimation);
			}
		}
	}

	// Token: 0x17001F2D RID: 7981
	// (get) Token: 0x06016DFA RID: 93690 RVA: 0x00709285 File Offset: 0x00707685
	public bool IsInFade
	{
		get
		{
			return this.bInFade;
		}
	}

	// Token: 0x06016DFB RID: 93691 RVA: 0x00709290 File Offset: 0x00707690
	public void OpenFade(DungeonFadeCallback fadein, DungeonFadeCallback load, DungeonFadeCallback fadeout, uint intime, uint outtime)
	{
		if (fadein != null)
		{
			fadein();
			fadein = null;
		}
		this.bInFade = true;
		this.mSum = 0U;
		this.mLoadcb = load;
		this.mFadeoutcb = fadeout;
		this.mFadein = intime;
		this.mFadeout = outtime;
		MonoSingleton<GameFrameWork>.instance.OpenFadeFrame(delegate
		{
		}, null, () => false, intime / 1000f, outtime / 1000f);
	}

	// Token: 0x06016DFC RID: 93692 RVA: 0x00709334 File Offset: 0x00707734
	private void _updateFadeIter(int delta)
	{
		if (this.bInFade)
		{
			uint num = this.mFadein + this.mFadeout;
			bool flag = false;
			if (this.mSum < num)
			{
				if (!flag && this.mSum >= this.mFadein && this.mLoadcb != null)
				{
					this.mLoadcb();
					this.mLoadcb = null;
				}
			}
			else
			{
				if (this.mFadeoutcb != null)
				{
					this.mFadeoutcb();
					this.mFadeoutcb = null;
				}
				this.bInFade = false;
			}
			this.mSum += (uint)delta;
		}
	}

	// Token: 0x06016DFD RID: 93693 RVA: 0x007093D8 File Offset: 0x007077D8
	public void Update(int delta)
	{
		this.mDelta = delta;
		if (this.mBattle != null && this.mBattle.recordServer != null)
		{
			this.mBattle.recordServer.BeginUpdate();
		}
		this._updateFadeIter(delta);
		if (this.mBeScene != null)
		{
			this.mBeScene.Update(delta);
		}
		if (this.mEnumertorManager != null)
		{
			this.mEnumertorManager.UpdateEnumerators();
		}
		this.mBattle.FrameUpdate(delta);
		if (this.mDungeonData != null)
		{
			this.mDungeonData.Update(delta);
		}
		this._dungeonTimeStatistics(delta);
		if (this.mBattle != null && this.mBattle.recordServer != null)
		{
			this.mBattle.recordServer.EndUpdate();
		}
	}

	// Token: 0x06016DFE RID: 93694 RVA: 0x007094A0 File Offset: 0x007078A0
	public void UpdateGraphic(int delta)
	{
		if (this.mBeScene != null)
		{
			this.mBeScene.UpdateGraphic(delta);
		}
	}

	// Token: 0x06016DFF RID: 93695 RVA: 0x007094BC File Offset: 0x007078BC
	private void _dungeonTimeStatistics(int delta)
	{
		if (this.mBeScene != null && !this.mBeScene.IsBossDead())
		{
			DungeonStatistics dungeonStatistics = this.mDungeonData.CurrentDungeonStatistics();
			if (dungeonStatistics != null)
			{
				switch (this.mBeScene.state)
				{
				case BeSceneState.onCreate:
				case BeSceneState.onReady:
				case BeSceneState.onFight:
				case BeSceneState.onBulletTime:
					dungeonStatistics.areaFightTime += delta;
					if (dungeonStatistics.lastVisitFrame == 4294967295U)
					{
						dungeonStatistics.lastVisitFrame = FrameSync.instance.curFrame;
					}
					break;
				case BeSceneState.onClear:
					dungeonStatistics.areaClearTime += delta;
					break;
				}
			}
		}
	}

	// Token: 0x06016E00 RID: 93696 RVA: 0x00709580 File Offset: 0x00707980
	public ulong GetAllHurtDamage()
	{
		ulong num = 0UL;
		List<DungeonStatistics> list = this.mDungeonData.AllDungeonStatistics();
		for (int i = 0; i < list.Count; i++)
		{
			num += list[i].GetSumDamage();
		}
		return num;
	}

	// Token: 0x06016E01 RID: 93697 RVA: 0x007095C4 File Offset: 0x007079C4
	public uint GetAllMaxHurtDamage()
	{
		DungeonHurtData allMaxHurtData = this.GetAllMaxHurtData();
		if (allMaxHurtData == null || allMaxHurtData.damage < 0)
		{
			return 0U;
		}
		return (uint)allMaxHurtData.damage;
	}

	// Token: 0x06016E02 RID: 93698 RVA: 0x007095F4 File Offset: 0x007079F4
	public uint GetAllMaxHurtSkillID()
	{
		DungeonHurtData allMaxHurtData = this.GetAllMaxHurtData();
		if (allMaxHurtData == null)
		{
			return 0U;
		}
		return (uint)allMaxHurtData.skillId;
	}

	// Token: 0x06016E03 RID: 93699 RVA: 0x00709618 File Offset: 0x00707A18
	public uint GetAllMaxHurtID()
	{
		DungeonHurtData allMaxHurtData = this.GetAllMaxHurtData();
		if (allMaxHurtData == null)
		{
			return 0U;
		}
		return (uint)allMaxHurtData.hurtId;
	}

	// Token: 0x06016E04 RID: 93700 RVA: 0x0070963C File Offset: 0x00707A3C
	public DungeonHurtData GetAllMaxHurtData()
	{
		List<DungeonStatistics> list = this.mDungeonData.AllDungeonStatistics();
		int num = -1;
		DungeonHurtData result = null;
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] != null)
			{
				DungeonHurtData maxHurtData = list[i].GetMaxHurtData();
				if (num < maxHurtData.damage)
				{
					num = maxHurtData.damage;
					result = maxHurtData;
				}
			}
		}
		return result;
	}

	// Token: 0x06016E05 RID: 93701 RVA: 0x007096AC File Offset: 0x00707AAC
	public DungeonHurtData GetCurrentMaxHurtData()
	{
		if (this.mBeScene == null)
		{
			return new DungeonHurtData();
		}
		DungeonStatistics dungeonStatistics = this.mDungeonData.CurrentDungeonStatistics();
		if (dungeonStatistics == null)
		{
			return new DungeonHurtData();
		}
		return dungeonStatistics.GetMaxHurtData();
	}

	// Token: 0x06016E06 RID: 93702 RVA: 0x007096E8 File Offset: 0x00707AE8
	public void AddHurtData(int skillId, int hurtId, int damage)
	{
		if (this.mBeScene == null)
		{
			return;
		}
		DungeonStatistics dungeonStatistics = this.mDungeonData.CurrentDungeonStatistics();
		if (dungeonStatistics == null)
		{
			return;
		}
		dungeonStatistics.AddHurtData(skillId, hurtId, damage);
	}

	// Token: 0x06016E07 RID: 93703 RVA: 0x00709720 File Offset: 0x00707B20
	public void AddBossHurtData(int pid, int damage, int monsterID)
	{
		this.mBossDamage += damage;
		this.AddBossDamage((uint)monsterID, (uint)damage, damage);
		List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i] != null && allPlayers[i].playerActor != null && allPlayers[i].playerActor.GetPID() == pid)
			{
				allPlayers[i].statistics.data.BossDamage += damage;
				return;
			}
		}
		if (this.mBeScene != null)
		{
			BeEntity entityByPID = this.mBeScene.GetEntityByPID(pid);
			if (entityByPID != null && entityByPID.GetEntityData() != null)
			{
				return;
			}
		}
	}

	// Token: 0x06016E08 RID: 93704 RVA: 0x007097E4 File Offset: 0x00707BE4
	private void AddBossDamage(uint monsterID, uint uDamage, int iDamage)
	{
		if (this.bossID01 == monsterID)
		{
			this.bossDamage01 += iDamage;
		}
		else if (this.bossID02 == monsterID)
		{
			this.bossDamage02 += iDamage;
		}
	}

	// Token: 0x06016E09 RID: 93705 RVA: 0x00709820 File Offset: 0x00707C20
	public uint GetBossDamage(byte seat)
	{
		List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i] != null && allPlayers[i].GetPlayerSeat() == seat)
			{
				return (uint)allPlayers[i].statistics.data.BossDamage;
			}
		}
		Logger.LogErrorFormat("GetBossDamage 找不到座位的玩家seat {0}", new object[]
		{
			seat
		});
		return 0U;
	}

	// Token: 0x06016E0A RID: 93706 RVA: 0x0070989F File Offset: 0x00707C9F
	public uint GetTotalBossDamage()
	{
		return (uint)this.mBossDamage;
	}

	// Token: 0x06016E0B RID: 93707 RVA: 0x007098A8 File Offset: 0x00707CA8
	public int AllDeadCount()
	{
		int num = 0;
		List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			num += allPlayers[i].statistics.data.deadCount;
		}
		return num;
	}

	// Token: 0x06016E0C RID: 93708 RVA: 0x007098F4 File Offset: 0x00707CF4
	public int AllRebornCount()
	{
		List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
		int num = 0;
		for (int i = 0; i < allPlayers.Count; i++)
		{
			num += allPlayers[i].statistics.data.rebornCount;
		}
		return num;
	}

	// Token: 0x06016E0D RID: 93709 RVA: 0x00709940 File Offset: 0x00707D40
	public int AllHitCount()
	{
		int num = 0;
		List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			num += allPlayers[i].statistics.data.beHitCount;
		}
		return num;
	}

	// Token: 0x06016E0E RID: 93710 RVA: 0x0070998C File Offset: 0x00707D8C
	public int RebornCount(byte seat)
	{
		BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(seat);
		return playerBySeat.statistics.data.rebornCount;
	}

	// Token: 0x06016E0F RID: 93711 RVA: 0x007099B8 File Offset: 0x00707DB8
	public int DeadCount(byte seat)
	{
		BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(seat);
		return playerBySeat.statistics.data.deadCount;
	}

	// Token: 0x06016E10 RID: 93712 RVA: 0x007099E4 File Offset: 0x00707DE4
	public int HitCount(byte seat)
	{
		BattlePlayer playerBySeat = this.mDungeonPlayers.GetPlayerBySeat(seat);
		return playerBySeat.statistics.data.beHitCount;
	}

	// Token: 0x06016E11 RID: 93713 RVA: 0x00709A0E File Offset: 0x00707E0E
	public int ItemUseCount(byte seat, int id)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06016E12 RID: 93714 RVA: 0x00709A15 File Offset: 0x00707E15
	public int SkillUseCount(byte seat, int id)
	{
		throw new NotImplementedException();
	}

	// Token: 0x06016E13 RID: 93715 RVA: 0x00709A1C File Offset: 0x00707E1C
	public int AllFightTime(bool withClear)
	{
		return this.mDungeonData.AllFightTime(withClear);
	}

	// Token: 0x06016E14 RID: 93716 RVA: 0x00709A2A File Offset: 0x00707E2A
	public int CurrentFightTime(bool withClear)
	{
		return this.mDungeonData.CurrentFightTime(withClear);
	}

	// Token: 0x06016E15 RID: 93717 RVA: 0x00709A38 File Offset: 0x00707E38
	public int LastFightTimeWithCount(bool withClear, int count)
	{
		return this.mDungeonData.LastFightTimeWithCount(withClear, count);
	}

	// Token: 0x06016E16 RID: 93718 RVA: 0x00709A48 File Offset: 0x00707E48
	private int _score(UnionCell split, int max, int score)
	{
		for (int i = 1; i <= max; i++)
		{
			int valueFromUnionCell = TableManager.GetValueFromUnionCell(split, i, true);
			if (score >= valueFromUnionCell)
			{
				return i - 1;
			}
		}
		return max - 1;
	}

	// Token: 0x06016E17 RID: 93719 RVA: 0x00709A80 File Offset: 0x00707E80
	public int RebornCountScore()
	{
		UnionCell rebornSplitArg = this.mDungeonData.table.RebornSplitArg;
		int score = this.AllRebornCount();
		return this._score(rebornSplitArg, rebornSplitArg.eValues.everyValues.Count, score);
	}

	// Token: 0x06016E18 RID: 93720 RVA: 0x00709AC0 File Offset: 0x00707EC0
	public int HitCountScore()
	{
		UnionCell hitSplitArg = this.mDungeonData.table.HitSplitArg;
		int score = this.AllHitCount();
		return this._score(hitSplitArg, hitSplitArg.eValues.everyValues.Count, score);
	}

	// Token: 0x06016E19 RID: 93721 RVA: 0x00709B00 File Offset: 0x00707F00
	public int AllFightTimeScore(bool withClear)
	{
		UnionCell timeSplitArg = this.mDungeonData.table.TimeSplitArg;
		int score = this.AllFightTime(withClear) / 1000;
		return this._score(timeSplitArg, timeSplitArg.eValues.everyValues.Count, score);
	}

	// Token: 0x06016E1A RID: 93722 RVA: 0x00709B44 File Offset: 0x00707F44
	public int FinalScore()
	{
		return this.HitCountScore() + this.AllFightTimeScore(true) + this.RebornCountScore();
	}

	// Token: 0x06016E1B RID: 93723 RVA: 0x00709B5C File Offset: 0x00707F5C
	public DungeonScore FinalDungeonScore()
	{
		if (this.mDungeonPlayers.IsAllPlayerDead() && !this.mBeScene.IsBossDead())
		{
			return DungeonScore.C;
		}
		int score = this.FinalScore();
		return this.GetDungeonScoreByValue(score);
	}

	// Token: 0x06016E1C RID: 93724 RVA: 0x00709B9C File Offset: 0x00707F9C
	public DungeonScore FinalDungeonScore_New()
	{
		if (this.mDungeonPlayers.IsAllPlayerDead() && this.mBeScene.IsBossScene && !this.mBeScene._isAllBossDead())
		{
			return DungeonScore.C;
		}
		int score = this.FinalScore();
		return this.GetDungeonScoreByValue(score);
	}

	// Token: 0x06016E1D RID: 93725 RVA: 0x00709BEC File Offset: 0x00707FEC
	private DungeonScore GetDungeonScoreByValue(int score)
	{
		DungeonScore result;
		if (score >= 3)
		{
			result = DungeonScore.SSS;
		}
		else if (score >= 2)
		{
			result = DungeonScore.SS;
		}
		else if (score >= 1)
		{
			result = DungeonScore.S;
		}
		else
		{
			result = DungeonScore.A;
		}
		return result;
	}

	// Token: 0x06016E1E RID: 93726 RVA: 0x00709C28 File Offset: 0x00708028
	public int FightTimeSplit(int level)
	{
		UnionCell timeSplitArg = this.mDungeonData.table.TimeSplitArg;
		return TableManager.GetValueFromUnionCell(timeSplitArg, level, true);
	}

	// Token: 0x06016E1F RID: 93727 RVA: 0x00709C4E File Offset: 0x0070804E
	public void SetMatchPlayerVoteTimeLeft(int leftTime)
	{
		this.mMatchPKLeftVoteTime = leftTime;
	}

	// Token: 0x06016E20 RID: 93728 RVA: 0x00709C57 File Offset: 0x00708057
	public int GetMatchPlayerVoteTimeLeft()
	{
		return this.mMatchPKLeftVoteTime;
	}

	// Token: 0x040105B5 RID: 66997
	protected DungeonDataManager mDungeonData;

	// Token: 0x040105B6 RID: 66998
	protected DungeonPlayerDataManager mDungeonPlayers;

	// Token: 0x040105B7 RID: 66999
	protected BeScene mBeScene;

	// Token: 0x040105B8 RID: 67000
	protected eDungeonMode mMode;

	// Token: 0x040105B9 RID: 67001
	private const int kSwitchLimit = 5;

	// Token: 0x040105BA RID: 67002
	protected int mSwitchCount;

	// Token: 0x040105BB RID: 67003
	protected BeSceneState mPreBeSceneState;

	// Token: 0x040105BC RID: 67004
	protected string mPrePauseBeSceneTag = string.Empty;

	// Token: 0x040105BD RID: 67005
	private int mDelta;

	// Token: 0x040105BE RID: 67006
	protected int mMatchPKLeftVoteTime;

	// Token: 0x040105BF RID: 67007
	private int mBossDamage;

	// Token: 0x040105C0 RID: 67008
	public uint bossID01;

	// Token: 0x040105C1 RID: 67009
	public uint bossID02;

	// Token: 0x040105C2 RID: 67010
	public int bossDamage01;

	// Token: 0x040105C3 RID: 67011
	public int bossDamage02;

	// Token: 0x040105C4 RID: 67012
	private IEnumeratorManager mEnumertorManager = new EnumeratorProcessManager();

	// Token: 0x040105C5 RID: 67013
	private List<List<IEnumerator>> mStackEnumerators = new List<List<IEnumerator>>();

	// Token: 0x040105C7 RID: 67015
	private bool bInFade;

	// Token: 0x040105C8 RID: 67016
	private uint mSum;

	// Token: 0x040105C9 RID: 67017
	private DungeonFadeCallback mLoadcb;

	// Token: 0x040105CA RID: 67018
	private DungeonFadeCallback mFadeoutcb;

	// Token: 0x040105CB RID: 67019
	private uint mFadein;

	// Token: 0x040105CC RID: 67020
	private uint mFadeout;
}
