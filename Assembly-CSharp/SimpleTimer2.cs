using System;

// Token: 0x0200015F RID: 351
public class SimpleTimer2
{
	// Token: 0x06000A1F RID: 2591 RVA: 0x000356E5 File Offset: 0x00033AE5
	public void StartTimer()
	{
		this.timeAcc = 0;
		this.seconds = 0;
		this.run = true;
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x000356FC File Offset: 0x00033AFC
	public void SetCountdown(int cd)
	{
		this.countdown = cd;
	}

	// Token: 0x17000192 RID: 402
	// (get) Token: 0x06000A21 RID: 2593 RVA: 0x00035705 File Offset: 0x00033B05
	public int Second
	{
		get
		{
			return this.seconds;
		}
	}

	// Token: 0x17000193 RID: 403
	// (get) Token: 0x06000A22 RID: 2594 RVA: 0x0003570D File Offset: 0x00033B0D
	public int CountDown
	{
		get
		{
			return this.countdown;
		}
	}

	// Token: 0x06000A23 RID: 2595 RVA: 0x00035715 File Offset: 0x00033B15
	public void Reset()
	{
		this.seconds = 0;
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x0003571E File Offset: 0x00033B1E
	public void StopTimer()
	{
		this.run = false;
		this.secondCallBack = null;
		this.timeupCallBack = null;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x00035735 File Offset: 0x00033B35
	public bool IsCount()
	{
		return this.run;
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x00035740 File Offset: 0x00033B40
	public void UpdateTimer(int delta)
	{
		if (!this.run)
		{
			return;
		}
		this.timeAcc += delta;
		if (this.timeAcc >= 1000)
		{
			this.timeAcc -= 1000;
			this.seconds++;
			if (this.secondCallBack != null)
			{
				this.secondCallBack(this.seconds);
			}
			if (this.IsTimeUp())
			{
				if (this.timeupCallBack != null)
				{
					this.timeupCallBack();
				}
				this.StopTimer();
			}
		}
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x000357DA File Offset: 0x00033BDA
	public bool IsTimeUp()
	{
		return this.countdown > 0 && this.seconds >= this.countdown;
	}

	// Token: 0x0400078F RID: 1935
	private int timeAcc;

	// Token: 0x04000790 RID: 1936
	private bool run;

	// Token: 0x04000791 RID: 1937
	private int seconds;

	// Token: 0x04000792 RID: 1938
	private int countdown;

	// Token: 0x04000793 RID: 1939
	public SimpleTimer2.SecondCallBack secondCallBack;

	// Token: 0x04000794 RID: 1940
	public SimpleTimer2.TimeUpCallBack timeupCallBack;

	// Token: 0x04000795 RID: 1941
	private const int INTERVAL = 1000;

	// Token: 0x02000160 RID: 352
	// (Invoke) Token: 0x06000A29 RID: 2601
	public delegate void SecondCallBack(int second);

	// Token: 0x02000161 RID: 353
	// (Invoke) Token: 0x06000A2D RID: 2605
	public delegate void TimeUpCallBack();
}
