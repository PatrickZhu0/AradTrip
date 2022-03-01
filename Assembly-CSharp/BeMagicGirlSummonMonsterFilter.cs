using System;

// Token: 0x02004190 RID: 16784
public class BeMagicGirlSummonMonsterFilter : IEntityFilter
{
	// Token: 0x06017071 RID: 94321 RVA: 0x00710968 File Offset: 0x0070ED68
	public bool isFit(BeEntity target)
	{
		return !target.IsDead() && (this.ownerPId <= 0 || target.GetPID() == this.ownerPId) && target.IsSummonMonster();
	}

	// Token: 0x06017072 RID: 94322 RVA: 0x007109A4 File Offset: 0x0070EDA4
	public bool isUseDefault()
	{
		return true;
	}

	// Token: 0x04010953 RID: 67923
	private int ownerPId = -1;
}
