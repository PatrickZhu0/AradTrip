using System;

// Token: 0x02004186 RID: 16774
public interface IEntityFilter
{
	// Token: 0x06017051 RID: 94289
	bool isUseDefault();

	// Token: 0x06017052 RID: 94290
	bool isFit(BeEntity target);
}
