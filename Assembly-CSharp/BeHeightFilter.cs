using System;

// Token: 0x0200418C RID: 16780
public class BeHeightFilter : IEntityFilter
{
	// Token: 0x06017063 RID: 94307 RVA: 0x007106CB File Offset: 0x0070EACB
	public BeHeightFilter(VInt height)
	{
		this._height = height;
	}

	// Token: 0x06017064 RID: 94308 RVA: 0x007106DA File Offset: 0x0070EADA
	public bool isFit(BeEntity target)
	{
		return false;
	}

	// Token: 0x06017065 RID: 94309 RVA: 0x007106DD File Offset: 0x0070EADD
	public bool isUseDefault()
	{
		return false;
	}

	// Token: 0x0401094A RID: 67914
	private VInt _height;
}
