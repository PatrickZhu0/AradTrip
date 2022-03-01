using System;

namespace YouMe
{
	// Token: 0x02004ADB RID: 19163
	internal enum ParserToken
	{
		// Token: 0x04013678 RID: 79480
		None = 65536,
		// Token: 0x04013679 RID: 79481
		Number,
		// Token: 0x0401367A RID: 79482
		True,
		// Token: 0x0401367B RID: 79483
		False,
		// Token: 0x0401367C RID: 79484
		Null,
		// Token: 0x0401367D RID: 79485
		CharSeq,
		// Token: 0x0401367E RID: 79486
		Char,
		// Token: 0x0401367F RID: 79487
		Text,
		// Token: 0x04013680 RID: 79488
		Object,
		// Token: 0x04013681 RID: 79489
		ObjectPrime,
		// Token: 0x04013682 RID: 79490
		Pair,
		// Token: 0x04013683 RID: 79491
		PairRest,
		// Token: 0x04013684 RID: 79492
		Array,
		// Token: 0x04013685 RID: 79493
		ArrayPrime,
		// Token: 0x04013686 RID: 79494
		Value,
		// Token: 0x04013687 RID: 79495
		ValueRest,
		// Token: 0x04013688 RID: 79496
		String,
		// Token: 0x04013689 RID: 79497
		End,
		// Token: 0x0401368A RID: 79498
		Epsilon
	}
}
