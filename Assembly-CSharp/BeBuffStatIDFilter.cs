using System;

// Token: 0x02004188 RID: 16776
public class BeBuffStatIDFilter : IEntityFilter
{
	// Token: 0x06017057 RID: 94295 RVA: 0x00710592 File Offset: 0x0070E992
	public bool isFit(BeEntity monster)
	{
		return this.statId != -2 && monster != null && monster.stateController != null && monster.stateController.HasBuffState((BeBuffStateType)this.statId);
	}

	// Token: 0x06017058 RID: 94296 RVA: 0x007105CD File Offset: 0x0070E9CD
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x04010946 RID: 67910
	public int statId = -2;
}
