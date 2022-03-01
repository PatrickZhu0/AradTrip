using System;
using System.Collections.Generic;
using behaviac;
using GameClient;
using GamePool;

// Token: 0x020040E9 RID: 16617
public class LevelAgent : Agent
{
	// Token: 0x06016A3B RID: 92731 RVA: 0x006DAEE8 File Offset: 0x006D92E8
	public void _set_CommonIntVar(int value)
	{
		this.CommonIntVar = value;
	}

	// Token: 0x06016A3C RID: 92732 RVA: 0x006DAEF1 File Offset: 0x006D92F1
	public int _get_CommonIntVar()
	{
		return this.CommonIntVar;
	}

	// Token: 0x06016A3D RID: 92733 RVA: 0x006DAEF9 File Offset: 0x006D92F9
	public void Action_PlayBgm(string path)
	{
		if (this.mLevelMgr == null)
		{
			return;
		}
		if (this.mLevelMgr.baseBattle == null)
		{
			return;
		}
		this.mLevelMgr.baseBattle.PushBgm(path);
	}

	// Token: 0x06016A3E RID: 92734 RVA: 0x006DAF2A File Offset: 0x006D932A
	public void Action_ShowHeadText(string text, float durTime)
	{
		SystemNotifyManager.SysDungeonSkillTip(text, durTime, false);
	}

	// Token: 0x06016A3F RID: 92735 RVA: 0x006DAF35 File Offset: 0x006D9335
	public void Action_SetCountTime(int time)
	{
		if (this.mLevelMgr == null)
		{
			return;
		}
		this.mLevelMgr.CountTime = time * GlobalLogic.VALUE_1000;
	}

	// Token: 0x06016A40 RID: 92736 RVA: 0x006DAF55 File Offset: 0x006D9355
	public void Action_SetCounter(LevelCounterType typeId, int value)
	{
		this.mLevelMgr.SetCounter((int)typeId, value);
	}

	// Token: 0x06016A41 RID: 92737 RVA: 0x006DAF64 File Offset: 0x006D9364
	public void Action_AllPlayersAddBuffInfo(int buffInfoId, bool summonerFlag)
	{
		if (this.mLevelMgr == null)
		{
			return;
		}
		if (this.mLevelMgr.baseBattle == null)
		{
			return;
		}
		if (this.mLevelMgr.baseBattle.dungeonPlayerManager == null)
		{
			return;
		}
		List<BattlePlayer> allPlayers = this.mLevelMgr.baseBattle.dungeonPlayerManager.GetAllPlayers();
		for (int i = 0; i < allPlayers.Count; i++)
		{
			if (allPlayers[i].playerActor != null)
			{
				allPlayers[i].playerActor.buffController.TryAddBuff(buffInfoId, null, false, null, 0);
			}
		}
		if (summonerFlag && this.mLevelMgr.baseBattle != null && this.mLevelMgr.baseBattle.dungeonManager != null && this.mLevelMgr.baseBattle.dungeonManager.GetBeScene() != null)
		{
			List<BeActor> list = ListPool<BeActor>.Get();
			BeMagicGirlSummonMonsterFilter filter = new BeMagicGirlSummonMonsterFilter();
			this.mLevelMgr.baseBattle.dungeonManager.GetBeScene().GetFilterTarget(list, filter, true);
			for (int j = 0; j < list.Count; j++)
			{
				list[j].buffController.TryAddBuff(buffInfoId, null, false, null, 0);
			}
			ListPool<BeActor>.Release(list);
		}
	}

	// Token: 0x06016A42 RID: 92738 RVA: 0x006DB0AC File Offset: 0x006D94AC
	public void Action_SummonMonster(int summonId, List<float> summonPos, int level)
	{
		if (this.mLevelMgr == null)
		{
			return;
		}
		BeScene beScene = this.mLevelMgr.GetBeScene();
		if (beScene == null)
		{
			return;
		}
		VInt3 zero = VInt3.zero;
		zero.x = IntMath.Float2Int(summonPos[0], GlobalLogic.VALUE_1000) * GlobalLogic.VALUE_10;
		zero.y = IntMath.Float2Int(summonPos[1], GlobalLogic.VALUE_1000) * GlobalLogic.VALUE_10;
		zero.z = IntMath.Float2Int(summonPos[2], GlobalLogic.VALUE_1000) * GlobalLogic.VALUE_10;
		beScene.SummonMonster(summonId + level * 100, zero, 1, null, false, 0, true, 0, false, false);
	}

	// Token: 0x06016A43 RID: 92739 RVA: 0x006DB14E File Offset: 0x006D954E
	public bool Condition_CheckCountTime(int time)
	{
		return this.mLevelMgr != null && this.mLevelMgr.CountTime > time * GlobalLogic.VALUE_1000;
	}

	// Token: 0x06016A44 RID: 92740 RVA: 0x006DB177 File Offset: 0x006D9577
	public int Condition_RoomRunningTime()
	{
		if (this.mLevelMgr == null)
		{
			return 0;
		}
		return this.mLevelMgr.RoomRunningTime / GlobalLogic.VALUE_1000;
	}

	// Token: 0x06016A45 RID: 92741 RVA: 0x006DB197 File Offset: 0x006D9597
	public bool Condition_CheckCounter(LevelCounterType counterType, int value)
	{
		return this.mLevelMgr != null && this.mLevelMgr.baseBattle != null && this.mLevelMgr.GetCounter((int)counterType) == value;
	}

	// Token: 0x06016A46 RID: 92742 RVA: 0x006DB1CC File Offset: 0x006D95CC
	public bool Condition_Random(int rate)
	{
		return this.mLevelMgr != null && this.mLevelMgr.baseBattle != null && this.mLevelMgr.baseBattle.FrameRandom.InRange(0, 1000) <= rate;
	}

	// Token: 0x06016A47 RID: 92743 RVA: 0x006DB21C File Offset: 0x006D961C
	public bool Condition_IsInRoom(int areaid)
	{
		if (this.mLevelMgr == null || this.mLevelMgr.baseBattle == null || this.mLevelMgr.baseBattle.dungeonManager == null || this.mLevelMgr.baseBattle.dungeonManager.GetDungeonDataManager() == null)
		{
			return false;
		}
		int indexByAreaId = this.mLevelMgr.baseBattle.dungeonManager.GetDungeonDataManager().GetIndexByAreaId();
		return indexByAreaId == areaid;
	}

	// Token: 0x06016A48 RID: 92744 RVA: 0x006DB294 File Offset: 0x006D9694
	public bool Condition_HaveMonster(int monsterId)
	{
		if (this.mLevelMgr == null || this.mLevelMgr.baseBattle == null || this.mLevelMgr.baseBattle.dungeonManager == null || this.mLevelMgr.baseBattle.dungeonManager.GetBeScene() == null)
		{
			return false;
		}
		List<BeActor> list = ListPool<BeActor>.Get();
		this.mLevelMgr.baseBattle.dungeonManager.GetBeScene().FindActorById2(list, monsterId, false);
		if (list.Count > 0)
		{
			ListPool<BeActor>.Release(list);
			return true;
		}
		ListPool<BeActor>.Release(list);
		return false;
	}

	// Token: 0x06016A49 RID: 92745 RVA: 0x006DB32C File Offset: 0x006D972C
	public void Tick()
	{
		this.btexec();
	}

	// Token: 0x06016A4A RID: 92746 RVA: 0x006DB335 File Offset: 0x006D9735
	public void SetLevelMgr(LevelManager levelMgr)
	{
		this.mLevelMgr = levelMgr;
	}

	// Token: 0x040101DA RID: 66010
	private int CommonIntVar;

	// Token: 0x040101DB RID: 66011
	private LevelManager mLevelMgr;
}
