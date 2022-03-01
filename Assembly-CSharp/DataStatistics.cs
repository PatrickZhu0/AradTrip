using System;

// Token: 0x02004642 RID: 17986
public class DataStatistics
{
	// Token: 0x06019455 RID: 103509 RVA: 0x008000B0 File Offset: 0x007FE4B0
	public void Init()
	{
		for (int i = 0; i < this.pingNums.Length; i++)
		{
			this.pingNums[i] = 0;
		}
		for (int j = 0; j < this.fpsNums.Length; j++)
		{
			this.fpsNums[j] = 0;
		}
	}

	// Token: 0x06019456 RID: 103510 RVA: 0x00800104 File Offset: 0x007FE504
	public void CollectPingStatistic(int ping)
	{
		if (ping <= 60)
		{
			this.pingNums[0]++;
		}
		else if (ping <= 100)
		{
			this.pingNums[1]++;
		}
		else if (ping <= 200)
		{
			this.pingNums[2]++;
		}
		else
		{
			this.pingNums[3]++;
		}
	}

	// Token: 0x06019457 RID: 103511 RVA: 0x00800180 File Offset: 0x007FE580
	public void CollectFpsStatistic(int fps)
	{
		if (fps >= 26)
		{
			this.fpsNums[0]++;
		}
		else if (fps >= 21)
		{
			this.fpsNums[1]++;
		}
		else if (fps > 0)
		{
			this.fpsNums[2]++;
		}
	}

	// Token: 0x04012256 RID: 74326
	public int[] pingNums = new int[4];

	// Token: 0x04012257 RID: 74327
	public int[] fpsNums = new int[3];
}
