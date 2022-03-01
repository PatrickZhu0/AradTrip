using System;
using System.Collections.Generic;

// Token: 0x020041E3 RID: 16867
public class DungeonStatistics
{
	// Token: 0x0601752F RID: 95535 RVA: 0x0072D413 File Offset: 0x0072B813
	public ulong GetSumDamage()
	{
		return this.mSumDamage;
	}

	// Token: 0x06017530 RID: 95536 RVA: 0x0072D41C File Offset: 0x0072B81C
	public void AddHurtData(int skillId, int hurtId, int damage)
	{
		if (damage >= 0)
		{
			this.mSumDamage += (ulong)((long)damage);
		}
		else
		{
			Logger.LogError("[战斗] 伤害数据为负数");
		}
		if (this.mMaxHurtDatas == null)
		{
			Logger.LogError("[战斗] 伤害数据为空");
			return;
		}
		if (this.mMaxHurtDatas.Count <= 0)
		{
			DungeonHurtData item = new DungeonHurtData(skillId, hurtId, damage);
			this.mMaxHurtDatas.Add(item);
			return;
		}
		DungeonHurtData dungeonHurtData = this.mMaxHurtDatas[0];
		if (dungeonHurtData == null)
		{
			Logger.LogError("[战斗] 保存数据为空");
			return;
		}
		if (damage > dungeonHurtData.damage)
		{
			DungeonHurtData maxHurtData = this.GetMaxHurtData();
			maxHurtData.skillId = skillId;
			maxHurtData.hurtId = hurtId;
			maxHurtData.damage = damage;
		}
	}

	// Token: 0x06017531 RID: 95537 RVA: 0x0072D4D4 File Offset: 0x0072B8D4
	public DungeonHurtData GetMaxHurtData()
	{
		if (this.mMaxHurtDatas == null || this.mMaxHurtDatas.Count <= 0)
		{
			return new DungeonHurtData();
		}
		int index = 0;
		int num = -1;
		for (int i = 0; i < this.mMaxHurtDatas.Count; i++)
		{
			if (this.mMaxHurtDatas[i] != null)
			{
				if (this.mMaxHurtDatas[i].damage > num)
				{
					num = this.mMaxHurtDatas[i].damage;
					index = i;
				}
			}
		}
		return this.mMaxHurtDatas[index];
	}

	// Token: 0x04010C2C RID: 68652
	public int areaFightTime;

	// Token: 0x04010C2D RID: 68653
	public int areaClearTime;

	// Token: 0x04010C2E RID: 68654
	public uint lastVisitFrame = uint.MaxValue;

	// Token: 0x04010C2F RID: 68655
	private List<DungeonHurtData> mMaxHurtDatas = new List<DungeonHurtData>();

	// Token: 0x04010C30 RID: 68656
	private ulong mSumDamage;
}
