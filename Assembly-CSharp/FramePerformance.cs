using System;

// Token: 0x02004530 RID: 17712
public class FramePerformance
{
	// Token: 0x06018A78 RID: 100984 RVA: 0x007B1AE4 File Offset: 0x007AFEE4
	public void AddDelay(uint delay)
	{
		this.cmdNum += 1U;
		this.totalDelay += delay;
		this.maxDelay = ((delay <= this.maxDelay) ? this.maxDelay : delay);
		this.averageDelay = this.totalDelay / this.cmdNum;
		this.recentDelays[this.recentPos++] = delay;
		if (this.recentPos >= this.recentDelays.Length)
		{
			this.recentPos = 0;
		}
		this.recentDelay = this.GetRecentDelay();
	}

	// Token: 0x06018A79 RID: 100985 RVA: 0x007B1B80 File Offset: 0x007AFF80
	private uint GetRecentDelay()
	{
		uint num = 0U;
		uint num2 = 0U;
		for (int i = 0; i < this.recentDelays.Length; i++)
		{
			if (this.recentDelays[i] != 0U)
			{
				num += this.recentDelays[i];
			}
			num2 += 1U;
		}
		return (num2 <= 0U) ? 0U : (num / num2);
	}

	// Token: 0x04011C2F RID: 72751
	public uint totalDelay;

	// Token: 0x04011C30 RID: 72752
	public uint averageDelay;

	// Token: 0x04011C31 RID: 72753
	public uint maxDelay;

	// Token: 0x04011C32 RID: 72754
	public uint cmdNum;

	// Token: 0x04011C33 RID: 72755
	public uint recentDelay;

	// Token: 0x04011C34 RID: 72756
	protected uint[] recentDelays = new uint[10];

	// Token: 0x04011C35 RID: 72757
	protected int recentPos;
}
