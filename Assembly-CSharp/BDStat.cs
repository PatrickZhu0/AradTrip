using System;

// Token: 0x0200414D RID: 16717
public class BDStat
{
	// Token: 0x06016D34 RID: 93492 RVA: 0x00705CB5 File Offset: 0x007040B5
	public BDStat()
	{
		this.stat = BDStat.State.READY;
	}

	// Token: 0x06016D35 RID: 93493 RVA: 0x00705CC4 File Offset: 0x007040C4
	public BDStat.State GetState()
	{
		return this.stat;
	}

	// Token: 0x06016D36 RID: 93494 RVA: 0x00705CCC File Offset: 0x007040CC
	public bool IsReady()
	{
		return this.stat == BDStat.State.READY;
	}

	// Token: 0x06016D37 RID: 93495 RVA: 0x00705CD7 File Offset: 0x007040D7
	public bool IsRunning()
	{
		return this.stat == BDStat.State.RUNNING;
	}

	// Token: 0x06016D38 RID: 93496 RVA: 0x00705CE2 File Offset: 0x007040E2
	public bool IsDead()
	{
		return this.stat == BDStat.State.DEAD;
	}

	// Token: 0x06016D39 RID: 93497 RVA: 0x00705CED File Offset: 0x007040ED
	public void SetReady()
	{
		this.stat = BDStat.State.READY;
	}

	// Token: 0x06016D3A RID: 93498 RVA: 0x00705CF6 File Offset: 0x007040F6
	public void SetRunning()
	{
		this.stat = BDStat.State.RUNNING;
	}

	// Token: 0x06016D3B RID: 93499 RVA: 0x00705CFF File Offset: 0x007040FF
	public void SetDead()
	{
		this.stat = BDStat.State.DEAD;
	}

	// Token: 0x06016D3C RID: 93500 RVA: 0x00705D08 File Offset: 0x00704108
	public void Reset()
	{
		this.stat = BDStat.State.READY;
	}

	// Token: 0x040104E1 RID: 66785
	private BDStat.State stat;

	// Token: 0x0200414E RID: 16718
	public enum State
	{
		// Token: 0x040104E3 RID: 66787
		READY,
		// Token: 0x040104E4 RID: 66788
		RUNNING,
		// Token: 0x040104E5 RID: 66789
		DEAD
	}
}
