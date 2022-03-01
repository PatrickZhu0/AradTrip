using System;

namespace LitJson
{
	// Token: 0x020046A7 RID: 18087
	public enum JsonToken
	{
		// Token: 0x040123EC RID: 74732
		None,
		// Token: 0x040123ED RID: 74733
		ObjectStart,
		// Token: 0x040123EE RID: 74734
		PropertyName,
		// Token: 0x040123EF RID: 74735
		ObjectEnd,
		// Token: 0x040123F0 RID: 74736
		ArrayStart,
		// Token: 0x040123F1 RID: 74737
		ArrayEnd,
		// Token: 0x040123F2 RID: 74738
		Int,
		// Token: 0x040123F3 RID: 74739
		Long,
		// Token: 0x040123F4 RID: 74740
		Double,
		// Token: 0x040123F5 RID: 74741
		String,
		// Token: 0x040123F6 RID: 74742
		Boolean,
		// Token: 0x040123F7 RID: 74743
		Null
	}
}
