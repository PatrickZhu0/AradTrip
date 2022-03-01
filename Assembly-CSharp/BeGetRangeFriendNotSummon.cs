using System;

// Token: 0x02004193 RID: 16787
public class BeGetRangeFriendNotSummon : IEntityFilter
{
	// Token: 0x0601707A RID: 94330 RVA: 0x00710A90 File Offset: 0x0070EE90
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		return beActor != null && !beActor.IsSummonMonster();
	}

	// Token: 0x0601707B RID: 94331 RVA: 0x00710ABA File Offset: 0x0070EEBA
	public bool isUseDefault()
	{
		return true;
	}
}
