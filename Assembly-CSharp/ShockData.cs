using System;

// Token: 0x02000D7B RID: 3451
[Serializable]
public struct ShockData
{
	// Token: 0x06008BFC RID: 35836 RVA: 0x0019DB16 File Offset: 0x0019BF16
	public ShockData(float time, float speed, float xrange, float yrange, int mode = 0)
	{
		this.time = time;
		this.xrange = xrange;
		this.yrange = yrange;
		this.mode = mode;
		this.speed = speed;
	}

	// Token: 0x0400452A RID: 17706
	public float time;

	// Token: 0x0400452B RID: 17707
	public float xrange;

	// Token: 0x0400452C RID: 17708
	public float yrange;

	// Token: 0x0400452D RID: 17709
	public int mode;

	// Token: 0x0400452E RID: 17710
	public float speed;
}
