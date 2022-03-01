using System;

namespace YIMEngine
{
	// Token: 0x02004A8C RID: 19084
	internal enum ParserToken
	{
		// Token: 0x040134B2 RID: 79026
		None = 65536,
		// Token: 0x040134B3 RID: 79027
		Number,
		// Token: 0x040134B4 RID: 79028
		True,
		// Token: 0x040134B5 RID: 79029
		False,
		// Token: 0x040134B6 RID: 79030
		Null,
		// Token: 0x040134B7 RID: 79031
		CharSeq,
		// Token: 0x040134B8 RID: 79032
		Char,
		// Token: 0x040134B9 RID: 79033
		Text,
		// Token: 0x040134BA RID: 79034
		Object,
		// Token: 0x040134BB RID: 79035
		ObjectPrime,
		// Token: 0x040134BC RID: 79036
		Pair,
		// Token: 0x040134BD RID: 79037
		PairRest,
		// Token: 0x040134BE RID: 79038
		Array,
		// Token: 0x040134BF RID: 79039
		ArrayPrime,
		// Token: 0x040134C0 RID: 79040
		Value,
		// Token: 0x040134C1 RID: 79041
		ValueRest,
		// Token: 0x040134C2 RID: 79042
		String,
		// Token: 0x040134C3 RID: 79043
		End,
		// Token: 0x040134C4 RID: 79044
		Epsilon
	}
}
