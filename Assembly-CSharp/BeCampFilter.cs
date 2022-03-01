using System;

// Token: 0x0200418D RID: 16781
public class BeCampFilter : IEntityFilter
{
	// Token: 0x06017066 RID: 94310 RVA: 0x007106E0 File Offset: 0x0070EAE0
	public BeCampFilter(int camp)
	{
		this._camp = camp;
	}

	// Token: 0x06017067 RID: 94311 RVA: 0x007106EF File Offset: 0x0070EAEF
	public bool isFit(BeEntity target)
	{
		return target.GetCamp() == this._camp;
	}

	// Token: 0x06017068 RID: 94312 RVA: 0x007106FF File Offset: 0x0070EAFF
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x0401094B RID: 67915
	private int _camp;
}
