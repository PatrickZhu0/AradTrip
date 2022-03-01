using System;

// Token: 0x02004192 RID: 16786
public class BeAllEnemyMonsterFilter : IEntityFilter
{
	// Token: 0x06017077 RID: 94327 RVA: 0x00710A20 File Offset: 0x0070EE20
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		return beActor != null && beActor.IsMonster() && beActor.m_iCamp != 0 && beActor.GetEntityData() != null && (this.containSkillMonster || beActor.GetEntityData().type != 8);
	}

	// Token: 0x06017078 RID: 94328 RVA: 0x00710A82 File Offset: 0x0070EE82
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x04010955 RID: 67925
	public bool containSkillMonster = true;
}
