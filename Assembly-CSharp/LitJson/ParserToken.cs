using System;

namespace LitJson
{
	// Token: 0x020046AF RID: 18095
	internal enum ParserToken
	{
		// Token: 0x0401244C RID: 74828
		None = 65536,
		// Token: 0x0401244D RID: 74829
		Number,
		// Token: 0x0401244E RID: 74830
		True,
		// Token: 0x0401244F RID: 74831
		False,
		// Token: 0x04012450 RID: 74832
		Null,
		// Token: 0x04012451 RID: 74833
		CharSeq,
		// Token: 0x04012452 RID: 74834
		Char,
		// Token: 0x04012453 RID: 74835
		Text,
		// Token: 0x04012454 RID: 74836
		Object,
		// Token: 0x04012455 RID: 74837
		ObjectPrime,
		// Token: 0x04012456 RID: 74838
		Pair,
		// Token: 0x04012457 RID: 74839
		PairRest,
		// Token: 0x04012458 RID: 74840
		Array,
		// Token: 0x04012459 RID: 74841
		ArrayPrime,
		// Token: 0x0401245A RID: 74842
		Value,
		// Token: 0x0401245B RID: 74843
		ValueRest,
		// Token: 0x0401245C RID: 74844
		String,
		// Token: 0x0401245D RID: 74845
		End,
		// Token: 0x0401245E RID: 74846
		Epsilon
	}
}
