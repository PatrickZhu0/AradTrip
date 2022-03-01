using System;

// Token: 0x02000F90 RID: 3984
internal class StateBarData
{
	// Token: 0x06009A1D RID: 39453 RVA: 0x001DA995 File Offset: 0x001D8D95
	public StateBarData(int id, string text, int duration, CStateBar.eBarColor color, bool reverse)
	{
		this.id = id;
		this.text = text;
		this.duration = duration;
		this.reverse = reverse;
		this.color = color;
		this.time = duration;
	}

	// Token: 0x04004F6B RID: 20331
	public int id;

	// Token: 0x04004F6C RID: 20332
	public string text;

	// Token: 0x04004F6D RID: 20333
	public int time;

	// Token: 0x04004F6E RID: 20334
	public int duration;

	// Token: 0x04004F6F RID: 20335
	public bool reverse;

	// Token: 0x04004F70 RID: 20336
	public CStateBar.eBarColor color;
}
