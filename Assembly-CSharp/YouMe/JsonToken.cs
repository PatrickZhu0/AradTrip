using System;

namespace YouMe
{
	// Token: 0x02004AD3 RID: 19155
	public enum JsonToken
	{
		// Token: 0x04013618 RID: 79384
		None,
		// Token: 0x04013619 RID: 79385
		ObjectStart,
		// Token: 0x0401361A RID: 79386
		PropertyName,
		// Token: 0x0401361B RID: 79387
		ObjectEnd,
		// Token: 0x0401361C RID: 79388
		ArrayStart,
		// Token: 0x0401361D RID: 79389
		ArrayEnd,
		// Token: 0x0401361E RID: 79390
		Int,
		// Token: 0x0401361F RID: 79391
		Long,
		// Token: 0x04013620 RID: 79392
		Double,
		// Token: 0x04013621 RID: 79393
		String,
		// Token: 0x04013622 RID: 79394
		Boolean,
		// Token: 0x04013623 RID: 79395
		Null
	}
}
