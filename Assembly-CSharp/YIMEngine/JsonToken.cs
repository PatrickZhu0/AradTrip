using System;

namespace YIMEngine
{
	// Token: 0x02004A84 RID: 19076
	public enum JsonToken
	{
		// Token: 0x04013452 RID: 78930
		None,
		// Token: 0x04013453 RID: 78931
		ObjectStart,
		// Token: 0x04013454 RID: 78932
		PropertyName,
		// Token: 0x04013455 RID: 78933
		ObjectEnd,
		// Token: 0x04013456 RID: 78934
		ArrayStart,
		// Token: 0x04013457 RID: 78935
		ArrayEnd,
		// Token: 0x04013458 RID: 78936
		Int,
		// Token: 0x04013459 RID: 78937
		Long,
		// Token: 0x0401345A RID: 78938
		Double,
		// Token: 0x0401345B RID: 78939
		String,
		// Token: 0x0401345C RID: 78940
		Boolean,
		// Token: 0x0401345D RID: 78941
		Null
	}
}
