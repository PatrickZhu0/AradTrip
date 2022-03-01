using System;

// Token: 0x0200418B RID: 16779
public class BeMechanismFilter : IEntityFilter
{
	// Token: 0x06017060 RID: 94304 RVA: 0x00710688 File Offset: 0x0070EA88
	public BeMechanismFilter(int id)
	{
		this.mechanismIndex = id;
	}

	// Token: 0x06017061 RID: 94305 RVA: 0x00710698 File Offset: 0x0070EA98
	public bool isFit(BeEntity target)
	{
		BeActor beActor = target as BeActor;
		if (beActor == null)
		{
			return false;
		}
		BeMechanism mechanismByIndex = beActor.GetMechanismByIndex(this.mechanismIndex);
		return mechanismByIndex != null;
	}

	// Token: 0x06017062 RID: 94306 RVA: 0x007106C8 File Offset: 0x0070EAC8
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x04010949 RID: 67913
	private int mechanismIndex;
}
