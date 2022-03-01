using System;

// Token: 0x02004191 RID: 16785
public class BeAbilityEnable : IEntityFilter
{
	// Token: 0x06017074 RID: 94324 RVA: 0x007109B8 File Offset: 0x0070EDB8
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		return beActor != null && beActor.stateController != null && this.abType > -1 && this.abType < 53 && beActor.stateController.HasAbility((BeAbilityType)this.abType);
	}

	// Token: 0x06017075 RID: 94325 RVA: 0x00710A0B File Offset: 0x0070EE0B
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x04010954 RID: 67924
	public int abType = -1;
}
