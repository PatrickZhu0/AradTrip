using System;
using System.Collections.Generic;

// Token: 0x020041F6 RID: 16886
public interface IDungeonPlayerDataManager
{
	// Token: 0x0601759F RID: 95647
	List<BattlePlayer> GetAllPlayers();

	// Token: 0x060175A0 RID: 95648
	BattlePlayer GetPlayerBySeat(byte seat = 0);

	// Token: 0x060175A1 RID: 95649
	BattlePlayer GetPlayerByRoleID(ulong roleId = 0UL);

	// Token: 0x060175A2 RID: 95650
	BattlePlayer GetMainPlayer();

	// Token: 0x060175A3 RID: 95651
	BattlePlayer GetFirstAlivePlayer();

	// Token: 0x060175A4 RID: 95652
	bool IsPlayerDead(byte seat);

	// Token: 0x060175A5 RID: 95653
	bool IsPlayerDeadByBattlePlayer(BattlePlayer player);

	// Token: 0x060175A6 RID: 95654
	bool IsAllPlayerDead();

	// Token: 0x060175A7 RID: 95655
	void SendMainPlayerLoadRate(int rate);

	// Token: 0x060175A8 RID: 95656
	string GetMainPlayerLoadInfo();

	// Token: 0x060175A9 RID: 95657
	void SetMainPlayerLoadInfo(string info);

	// Token: 0x060175AA RID: 95658
	byte GetPlayerLoadRate(byte seat);

	// Token: 0x060175AB RID: 95659
	BattlePlayer.eDungeonPlayerTeamType GetPlayerTeamType(byte seat);

	// Token: 0x060175AC RID: 95660
	int GetPlayerCount();

	// Token: 0x060175AD RID: 95661
	int GetSeatCount();

	// Token: 0x060175AE RID: 95662
	bool IsTeamPlayerAllFighted(BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175AF RID: 95663
	bool IsTeamPlayerAllDead(BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175B0 RID: 95664
	byte GetCurrentTeamFightingPlayerSeat(BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175B1 RID: 95665
	BattlePlayer GetCurrentTeamFightingPlayer(BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175B2 RID: 95666
	void SetPlayerVoteFightState(byte seat, bool isFight);

	// Token: 0x060175B3 RID: 95667
	BattlePlayer GetTargetPlayer(byte seat);

	// Token: 0x060175B4 RID: 95668
	bool IsKillEnemyMatchPlayer(byte seat);

	// Token: 0x060175B5 RID: 95669
	bool GetTeamNotVotePlayers(List<BattlePlayer> notVotePlayers, BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175B6 RID: 95670
	bool GetTeamVotePlayers(List<BattlePlayer> notVotePlayers, BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175B7 RID: 95671
	int GetTeamPlayerCount(BattlePlayer.eDungeonPlayerTeamType type);

	// Token: 0x060175B8 RID: 95672
	int GetMainPlayerTeamPlayerCount();
}
