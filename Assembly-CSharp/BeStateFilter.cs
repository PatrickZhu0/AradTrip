using System;

// Token: 0x0200418A RID: 16778
public class BeStateFilter : IEntityFilter
{
	// Token: 0x0601705D RID: 94301 RVA: 0x00710646 File Offset: 0x0070EA46
	public BeStateFilter(BeBuffStateType type)
	{
		this.stateType = type;
	}

	// Token: 0x0601705E RID: 94302 RVA: 0x00710658 File Offset: 0x0070EA58
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		return beActor != null && beActor.stateController.HasBuffState(this.stateType);
	}

	// Token: 0x0601705F RID: 94303 RVA: 0x00710685 File Offset: 0x0070EA85
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x04010948 RID: 67912
	private BeBuffStateType stateType;
}
