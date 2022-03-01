using System;
using Protocol;

// Token: 0x020041F8 RID: 16888
public interface IDungeonStatistics
{
	// Token: 0x060175BB RID: 95675
	int RebornCountScore();

	// Token: 0x060175BC RID: 95676
	int HitCountScore();

	// Token: 0x060175BD RID: 95677
	int AllFightTimeScore(bool withClear);

	// Token: 0x060175BE RID: 95678
	int FinalScore();

	// Token: 0x060175BF RID: 95679
	DungeonScore FinalDungeonScore();

	// Token: 0x060175C0 RID: 95680
	int FightTimeSplit(int level);

	// Token: 0x060175C1 RID: 95681
	int AllDeadCount();

	// Token: 0x060175C2 RID: 95682
	int AllRebornCount();

	// Token: 0x060175C3 RID: 95683
	int AllHitCount();

	// Token: 0x060175C4 RID: 95684
	int RebornCount(byte seat);

	// Token: 0x060175C5 RID: 95685
	int DeadCount(byte seat);

	// Token: 0x060175C6 RID: 95686
	int HitCount(byte seat);

	// Token: 0x060175C7 RID: 95687
	int ItemUseCount(byte seat, int id);

	// Token: 0x060175C8 RID: 95688
	int SkillUseCount(byte seat, int id);

	// Token: 0x060175C9 RID: 95689
	int AllFightTime(bool withClear);

	// Token: 0x060175CA RID: 95690
	int CurrentFightTime(bool withClear);

	// Token: 0x060175CB RID: 95691
	int LastFightTimeWithCount(bool withClear, int count);

	// Token: 0x060175CC RID: 95692
	DungeonHurtData GetCurrentMaxHurtData();

	// Token: 0x060175CD RID: 95693
	DungeonHurtData GetAllMaxHurtData();

	// Token: 0x060175CE RID: 95694
	ulong GetAllHurtDamage();

	// Token: 0x060175CF RID: 95695
	uint GetAllMaxHurtDamage();

	// Token: 0x060175D0 RID: 95696
	uint GetAllMaxHurtSkillID();

	// Token: 0x060175D1 RID: 95697
	uint GetAllMaxHurtID();

	// Token: 0x060175D2 RID: 95698
	uint GetBossDamage(byte seat);

	// Token: 0x060175D3 RID: 95699
	uint GetTotalBossDamage();

	// Token: 0x060175D4 RID: 95700
	void AddHurtData(int skillId, int hurtId, int damage);

	// Token: 0x060175D5 RID: 95701
	void AddBossHurtData(int attakcerId, int damage, int monsterID);

	// Token: 0x060175D6 RID: 95702
	int GetMatchPlayerVoteTimeLeft();

	// Token: 0x060175D7 RID: 95703
	void SetMatchPlayerVoteTimeLeft(int leftTime);
}
