using System;
using System.Collections;
using System.Collections.Generic;
using GameClient;
using Protocol;
using ProtoTable;
using UnityEngine;

// Token: 0x02004551 RID: 17745
[LoggerModel("Chapter")]
public class BattleMain
{
	// Token: 0x06018B43 RID: 101187 RVA: 0x007B8808 File Offset: 0x007B6C08
	private BattleMain(BattleType type)
	{
		BattleMain.mBattleType = type;
	}

	// Token: 0x17002022 RID: 8226
	// (get) Token: 0x06018B44 RID: 101188 RVA: 0x007B8816 File Offset: 0x007B6C16
	public FrameRandomImp FrameRandom
	{
		get
		{
			return this.mFrameRandom;
		}
	}

	// Token: 0x06018B45 RID: 101189 RVA: 0x007B881E File Offset: 0x007B6C1E
	public IBattle GetBattle()
	{
		return this.mBattle;
	}

	// Token: 0x06018B46 RID: 101190 RVA: 0x007B8826 File Offset: 0x007B6C26
	public IDungeonStatistics GetDungeonStatistics()
	{
		return this.mDungeonStatistics;
	}

	// Token: 0x06018B47 RID: 101191 RVA: 0x007B882E File Offset: 0x007B6C2E
	public IDungeonManager GetDungeonManager()
	{
		return this.mDungeonManager;
	}

	// Token: 0x06018B48 RID: 101192 RVA: 0x007B8836 File Offset: 0x007B6C36
	public IDungeonPlayerDataManager GetPlayerManager()
	{
		return this.mDungeonPlayers;
	}

	// Token: 0x17002023 RID: 8227
	// (get) Token: 0x06018B49 RID: 101193 RVA: 0x007B883E File Offset: 0x007B6C3E
	public static BattleMain instance
	{
		get
		{
			if (BattleMain.toDestroyBattle != null)
			{
			}
			return BattleMain.battleMain;
		}
	}

	// Token: 0x17002024 RID: 8228
	// (get) Token: 0x06018B4A RID: 101194 RVA: 0x007B884F File Offset: 0x007B6C4F
	public BeScene Main
	{
		get
		{
			if (this.mDungeonManager != null)
			{
				return this.mDungeonManager.GetBeScene();
			}
			return this.mMain;
		}
	}

	// Token: 0x17002025 RID: 8229
	// (get) Token: 0x06018B4B RID: 101195 RVA: 0x007B886E File Offset: 0x007B6C6E
	// (set) Token: 0x06018B4C RID: 101196 RVA: 0x007B8876 File Offset: 0x007B6C76
	public BattleState battleState
	{
		get
		{
			return this.mBattleState;
		}
		set
		{
			this.mBattleState = value;
		}
	}

	// Token: 0x17002026 RID: 8230
	// (get) Token: 0x06018B4D RID: 101197 RVA: 0x007B887F File Offset: 0x007B6C7F
	// (set) Token: 0x06018B4E RID: 101198 RVA: 0x007B8886 File Offset: 0x007B6C86
	public static BattleType battleType
	{
		get
		{
			return BattleMain.mBattleType;
		}
		set
		{
			BattleMain.mBattleType = value;
		}
	}

	// Token: 0x06018B4F RID: 101199 RVA: 0x007B888E File Offset: 0x007B6C8E
	public static bool IsLastNewbieGuideBattle()
	{
		return BattleMain.mBattleType == BattleType.NewbieGuide;
	}

	// Token: 0x06018B50 RID: 101200 RVA: 0x007B8898 File Offset: 0x007B6C98
	public static bool CheckLastBattleMode(BattleType type)
	{
		return BattleMain.mBattleType == type;
	}

	// Token: 0x17002027 RID: 8231
	// (get) Token: 0x06018B51 RID: 101201 RVA: 0x007B88A2 File Offset: 0x007B6CA2
	public static eDungeonMode mode
	{
		get
		{
			if (BattleMain.instance == null)
			{
				return eDungeonMode.None;
			}
			if (BattleMain.instance.mBattle != null)
			{
				return BattleMain.instance.mBattle.GetMode();
			}
			return eDungeonMode.None;
		}
	}

	// Token: 0x06018B52 RID: 101202 RVA: 0x007B88D0 File Offset: 0x007B6CD0
	public static BattleMain OpenBattle(BattleType type, eDungeonMode mode, int id, string sessionid)
	{
		if (BattleMain.battleMain != null)
		{
			BattleMain.toDestroyBattle = BattleMain.battleMain;
			BaseBattle baseBattle = BattleMain.toDestroyBattle.GetBattle() as BaseBattle;
			if (baseBattle != null && baseBattle.recordServer != null)
			{
				baseBattle.recordServer.EndRecord("openNewBattle");
			}
		}
		BattleMain.battleMain = new BattleMain(type);
		GeActorEx.ClearStatic();
		BaseBattle battle = BattleFactory.CreateBattle(type, mode, id);
		BattleMain.battleMain._initBattle(battle);
		if (!Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			BattleMain.battleMain._setStat(id);
		}
		return BattleMain.battleMain;
	}

	// Token: 0x06018B53 RID: 101203 RVA: 0x007B8968 File Offset: 0x007B6D68
	private void _setStat(int id)
	{
		RaceBuffInfo[] buffs = this.mDungeonPlayers.GetMainPlayer().playerInfo.buffs;
		List<int> list = new List<int>();
		for (int i = 0; i < buffs.Length; i++)
		{
			list.Add((int)buffs[i].id);
		}
		DungeonID dungeonID = new DungeonID(id);
		Singleton<GameStatisticManager>.instance.DoStatLevelChoose(StatLevelChooseType.ENTER_LEVEL, ChapterSelectFrame.sSceneID, dungeonID.dungeonID, dungeonID.diffID, list);
	}

	// Token: 0x06018B54 RID: 101204 RVA: 0x007B89D8 File Offset: 0x007B6DD8
	private void _initBattle(BaseBattle battle)
	{
		this.mBattle = battle;
		this.mDungeonPlayers = battle.dungeonPlayerManager;
		this.mDungeonManager = battle.dungeonManager;
		this.mDungeonStatistics = battle.dungeonStatistics;
		this.mDungeonPreloadAsset = battle.dungeonManager.GetDungeonDataManager();
		this.mDungeonAudio = battle;
		this.mFrameRandom = battle.FrameRandom;
	}

	// Token: 0x06018B55 RID: 101205 RVA: 0x007B8A34 File Offset: 0x007B6E34
	private void _uninitBattle()
	{
		this.mBattle = null;
		this.mDungeonPlayers = null;
		this.mDungeonManager = null;
		this.mDungeonStatistics = null;
		this.mDungeonPreloadAsset = null;
		this.mDungeonAudio = null;
		this.mMain = null;
	}

	// Token: 0x06018B56 RID: 101206 RVA: 0x007B8A67 File Offset: 0x007B6E67
	public static bool IsNeedRecordPVP(BattleType type)
	{
		return type == BattleType.MutiPlayer || type == BattleType.GuildPVP || type == BattleType.MoneyRewardsPVP || type == BattleType.ChijiPVP;
	}

	// Token: 0x06018B57 RID: 101207 RVA: 0x007B8A88 File Offset: 0x007B6E88
	public static bool IsModePvP(BattleType type)
	{
		return type == BattleType.MutiPlayer || type == BattleType.Training || type == BattleType.GuildPVP || type == BattleType.MoneyRewardsPVP || type == BattleType.PVP3V3Battle || type == BattleType.ScufflePVP || type == BattleType.ChijiPVP;
	}

	// Token: 0x06018B58 RID: 101208 RVA: 0x007B8AC0 File Offset: 0x007B6EC0
	public static bool IsModeChiji(BattleType type)
	{
		return type == BattleType.ChijiPVP;
	}

	// Token: 0x06018B59 RID: 101209 RVA: 0x007B8AC7 File Offset: 0x007B6EC7
	public static bool IsChiji()
	{
		return DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.ChiJi;
	}

	// Token: 0x06018B5A RID: 101210 RVA: 0x007B8AD6 File Offset: 0x007B6ED6
	public static bool IsFairDuel()
	{
		return DataManager<BattleDataManager>.GetInstance().PkRaceType == RaceType.PK_EQUAL_1V1;
	}

	// Token: 0x06018B5B RID: 101211 RVA: 0x007B8AE6 File Offset: 0x007B6EE6
	public static bool IsModePveTraining(BattleType type)
	{
		return type == BattleType.TrainingPVE;
	}

	// Token: 0x06018B5C RID: 101212 RVA: 0x007B8AED File Offset: 0x007B6EED
	public static bool IsModeMultiplayer(eDungeonMode mode)
	{
		return mode == eDungeonMode.SyncFrame;
	}

	// Token: 0x06018B5D RID: 101213 RVA: 0x007B8AF3 File Offset: 0x007B6EF3
	public static bool IsModeTrain(BattleType type)
	{
		return type == BattleType.Training || type == BattleType.TrainingPVE;
	}

	// Token: 0x06018B5E RID: 101214 RVA: 0x007B8B04 File Offset: 0x007B6F04
	public static bool IsTeamMode(BattleType type, eDungeonMode mode)
	{
		return !BattleMain.IsModePvP(type) && BattleMain.IsModeMultiplayer(mode);
	}

	// Token: 0x06018B5F RID: 101215 RVA: 0x007B8B1A File Offset: 0x007B6F1A
	public static bool IsModePVP3V3(BattleType type)
	{
		return type == BattleType.PVP3V3Battle;
	}

	// Token: 0x06018B60 RID: 101216 RVA: 0x007B8B21 File Offset: 0x007B6F21
	public static bool IsModeTeamDuplication(BattleType type)
	{
		return type == BattleType.RaidPVE;
	}

	// Token: 0x06018B61 RID: 101217 RVA: 0x007B8B28 File Offset: 0x007B6F28
	public static bool IsCanAccompany(BattleType type)
	{
		return type != BattleType.MutiPlayer && type != BattleType.GuildPVP && type != BattleType.Training && type != BattleType.PVP3V3Battle && type != BattleType.MoneyRewardsPVP && type != BattleType.ScufflePVP && type != BattleType.ChijiPVP;
	}

	// Token: 0x06018B62 RID: 101218 RVA: 0x007B8B63 File Offset: 0x007B6F63
	public static bool IsProtectFloat(BattleType type)
	{
		return type == BattleType.MutiPlayer || type == BattleType.GuildPVP || type == BattleType.Training || type == BattleType.PVP3V3Battle || type == BattleType.MoneyRewardsPVP || type == BattleType.ScufflePVP || type == BattleType.ChijiPVP;
	}

	// Token: 0x06018B63 RID: 101219 RVA: 0x007B8B9B File Offset: 0x007B6F9B
	public static bool IsProtectGround(BattleType type)
	{
		return type == BattleType.MutiPlayer || type == BattleType.GuildPVP || type == BattleType.Training || type == BattleType.PVP3V3Battle || type == BattleType.MoneyRewardsPVP || type == BattleType.ScufflePVP || type == BattleType.ChijiPVP;
	}

	// Token: 0x06018B64 RID: 101220 RVA: 0x007B8BD3 File Offset: 0x007B6FD3
	public static bool IsProtectStand(BattleType type)
	{
		return type == BattleType.MutiPlayer || type == BattleType.GuildPVP || type == BattleType.Training || type == BattleType.PVP3V3Battle || type == BattleType.MoneyRewardsPVP || type == BattleType.ScufflePVP || type == BattleType.ChijiPVP;
	}

	// Token: 0x06018B65 RID: 101221 RVA: 0x007B8C0B File Offset: 0x007B700B
	public static bool IsShowPing(BattleType type)
	{
		return type == BattleType.MutiPlayer || type == BattleType.GuildPVP || type == BattleType.Training || type == BattleType.PVP3V3Battle || type == BattleType.MoneyRewardsPVP || type == BattleType.ScufflePVP;
	}

	// Token: 0x06018B66 RID: 101222 RVA: 0x007B8C3B File Offset: 0x007B703B
	public static void CloseBattle(bool needEndRecord = true)
	{
		if (BattleMain.toDestroyBattle != null)
		{
			BattleMain.toDestroyBattle._unload(needEndRecord);
			BattleMain.toDestroyBattle = null;
		}
		else if (BattleMain.battleMain != null)
		{
			BattleMain.battleMain._unload(true);
			BattleMain.battleMain = null;
		}
	}

	// Token: 0x06018B67 RID: 101223 RVA: 0x007B8C78 File Offset: 0x007B7078
	public BattlePlayer GetLocalPlayer(ulong id = 0UL)
	{
		if (this.mDungeonPlayers != null)
		{
			return this.mDungeonPlayers.GetMainPlayer();
		}
		return null;
	}

	// Token: 0x06018B68 RID: 101224 RVA: 0x007B8C94 File Offset: 0x007B7094
	public BattlePlayer GetLocalTargetPlayer()
	{
		if (this.mDungeonPlayers != null)
		{
			List<BattlePlayer> allPlayers = this.mDungeonPlayers.GetAllPlayers();
			BattlePlayer mainPlayer = this.mDungeonPlayers.GetMainPlayer();
			for (int i = 0; i < allPlayers.Count; i++)
			{
				if (allPlayers[i] != mainPlayer)
				{
					return allPlayers[i];
				}
			}
		}
		return null;
	}

	// Token: 0x06018B69 RID: 101225 RVA: 0x007B8CF1 File Offset: 0x007B70F1
	private void _unload(bool needEndRecord = true)
	{
		if (this.mBattle != null)
		{
			this.mBattle.End(needEndRecord);
		}
		this._uninitBattle();
	}

	// Token: 0x06018B6A RID: 101226 RVA: 0x007B8D10 File Offset: 0x007B7110
	public IEnumerator Start(IASyncOperation op)
	{
		this.battleState = BattleState.Start;
		op.SetProgress(0f);
		if (this.mBattle != null)
		{
			yield return this.mBattle.Start(op);
		}
		yield break;
	}

	// Token: 0x06018B6B RID: 101227 RVA: 0x007B8D32 File Offset: 0x007B7132
	public void WaitForResult()
	{
		this.battleState = BattleState.WaitResult;
		if (this.mDungeonAudio != null)
		{
			this.mDungeonAudio.ClearBgm();
		}
	}

	// Token: 0x06018B6C RID: 101228 RVA: 0x007B8D51 File Offset: 0x007B7151
	public void End()
	{
		this.battleState = BattleState.End;
		if (Singleton<ReplayServer>.GetInstance().IsReplay())
		{
			Singleton<ReplayServer>.GetInstance().EndReplay(true, "BattleMainEnd");
		}
	}

	// Token: 0x06018B6D RID: 101229 RVA: 0x007B8D7C File Offset: 0x007B717C
	public void Update()
	{
		int delta = (int)(Time.deltaTime * (float)GlobalLogic.VALUE_1000);
		FrameSync.instance.UpdateFrame();
		if (this.mBattle != null)
		{
			this.mBattle.Update(delta);
		}
	}

	// Token: 0x06018B6E RID: 101230 RVA: 0x007B8DB8 File Offset: 0x007B71B8
	public static bool IsChijiNeedReplaceHurtId(int hurtId, BattleType type)
	{
		if (type != BattleType.ChijiPVP)
		{
			return false;
		}
		if (BattleMain.m_ChijiEffectMapTableDic == null)
		{
			BattleMain.m_ChijiEffectMapTableDic = Singleton<TableManager>.instance.GetTable<ChijiEffectMapTable>();
		}
		return BattleMain.m_ChijiEffectMapTableDic.ContainsKey(hurtId);
	}

	// Token: 0x06018B6F RID: 101231 RVA: 0x007B8DF0 File Offset: 0x007B71F0
	public static bool IsChijiNeedReplaceSkillId(int skillId, BattleType type)
	{
		if (type != BattleType.ChijiPVP)
		{
			return false;
		}
		if (BattleMain.m_ChijiSkillMapTableDic == null)
		{
			BattleMain.m_ChijiSkillMapTableDic = Singleton<TableManager>.instance.GetTable<ChijiSkillMapTable>();
		}
		return BattleMain.m_ChijiSkillMapTableDic.ContainsKey(skillId);
	}

	// Token: 0x04011CFA RID: 72954
	protected IDungeonPlayerDataManager mDungeonPlayers;

	// Token: 0x04011CFB RID: 72955
	protected IDungeonManager mDungeonManager;

	// Token: 0x04011CFC RID: 72956
	protected IDungeonStatistics mDungeonStatistics;

	// Token: 0x04011CFD RID: 72957
	protected IDungeonPreloadAssets mDungeonPreloadAsset;

	// Token: 0x04011CFE RID: 72958
	protected IBattle mBattle;

	// Token: 0x04011CFF RID: 72959
	protected IDungeonAudio mDungeonAudio;

	// Token: 0x04011D00 RID: 72960
	protected FrameRandomImp mFrameRandom;

	// Token: 0x04011D01 RID: 72961
	protected uint mBattleFlag;

	// Token: 0x04011D02 RID: 72962
	protected BeScene mMain;

	// Token: 0x04011D03 RID: 72963
	protected BattleState mBattleState;

	// Token: 0x04011D04 RID: 72964
	protected static BattleType mBattleType;

	// Token: 0x04011D05 RID: 72965
	protected static BattleMain toDestroyBattle;

	// Token: 0x04011D06 RID: 72966
	protected static BattleMain battleMain;

	// Token: 0x04011D07 RID: 72967
	protected static Dictionary<int, object> m_ChijiEffectMapTableDic;

	// Token: 0x04011D08 RID: 72968
	protected static Dictionary<int, object> m_ChijiSkillMapTableDic;
}
