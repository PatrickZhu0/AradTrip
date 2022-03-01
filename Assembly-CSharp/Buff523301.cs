using System;
using System.Collections.Generic;

// Token: 0x0200422A RID: 16938
public class Buff523301 : BeBuff
{
	// Token: 0x0601772F RID: 96047 RVA: 0x0073476C File Offset: 0x00732B6C
	public Buff523301(int bi, int buffLevel, int buffDuration, int attack = 0) : base(bi, buffLevel, buffDuration, attack, true)
	{
		this.points[0] = new VInt3(-4.2f, 5.2f, 0f);
		this.points[1] = new VInt3(-2.8f, 5.2f, 0f);
		this.points[2] = new VInt3(--0f, 5.2f, 0f);
		this.points[3] = new VInt3(-2.8f, 5.2f, 0f);
		this.points[4] = new VInt3(4.2f, 5.2f, 0f);
		this.percents[0] = new VFactor(70L, 100L);
		this.percents[1] = new VFactor(60L, 100L);
		this.percents[2] = new VFactor(50L, 100L);
	}

	// Token: 0x06017730 RID: 96048 RVA: 0x007348C1 File Offset: 0x00732CC1
	public override void OnInit()
	{
		this.summonID = TableManager.GetValueFromUnionCell(this.buffData.ValueA[0], this.level, true);
	}

	// Token: 0x06017731 RID: 96049 RVA: 0x007348EB File Offset: 0x00732CEB
	public override void OnStart()
	{
		base.owner.RegisterEvent(BeEventType.onHPChange, delegate(object[] args)
		{
			if (!base.owner.IsDead())
			{
				VFactor hprate = base.owner.GetEntityData().GetHPRate();
				for (int i = 0; i < 3; i++)
				{
					if (hprate < this.percents[i] && !this.flags[i])
					{
						this.flags[i] = true;
						this.DoSummon(i);
					}
				}
			}
		});
	}

	// Token: 0x06017732 RID: 96050 RVA: 0x00734908 File Offset: 0x00732D08
	private void DoSummon(int index)
	{
		List<int> list = new List<int>();
		if (index == 0)
		{
			list.Add(2);
		}
		else if (index == 1)
		{
			list.Add(1);
			list.Add(3);
		}
		else if (index == 2)
		{
			list.Add(0);
			list.Add(2);
			list.Add(4);
		}
		for (int i = 0; i < list.Count; i++)
		{
			int num = base.owner.GetEntityData().level;
			int monsterID = this.summonID + num * GlobalLogic.VALUE_100;
			BeUtility.AdjustMonsterDifficulty(ref base.owner.GetEntityData().monsterID, ref monsterID);
			base.owner.CurrentBeScene.SummonMonster(monsterID, this.points[list[i]], base.owner.GetCamp(), base.owner, false, 0, true, 0, false, false);
		}
	}

	// Token: 0x04010D5C RID: 68956
	private VInt3[] points = new VInt3[5];

	// Token: 0x04010D5D RID: 68957
	private bool[] flags = new bool[3];

	// Token: 0x04010D5E RID: 68958
	private VFactor[] percents = new VFactor[3];

	// Token: 0x04010D5F RID: 68959
	private int summonID = 1920011;
}
