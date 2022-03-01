using System;

// Token: 0x02001295 RID: 4757
public interface ISourceInfo
{
	// Token: 0x0600B732 RID: 46898
	eItemSourceType GetType();

	// Token: 0x0600B733 RID: 46899
	int GetNameIndex();

	// Token: 0x0600B734 RID: 46900
	int GetParmIndex();

	// Token: 0x0600B735 RID: 46901
	int GetData();

	// Token: 0x0600B736 RID: 46902
	int GetOpenFunctionID();
}
