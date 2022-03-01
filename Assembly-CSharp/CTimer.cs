using System;

// Token: 0x02000231 RID: 561
public class CTimer
{
	// Token: 0x060012A7 RID: 4775 RVA: 0x00064098 File Offset: 0x00062498
	public CTimer(int time, int loop, CTimer.OnTimeUpHandler timeUpHandler, int sequence)
	{
		if (loop == 0)
		{
			loop = -1;
		}
		this.m_totalTime = time;
		this.m_loop = loop;
		this.m_timeUpHandler = timeUpHandler;
		this.m_sequence = sequence;
		this.m_currentTime = 0;
		this.m_isRunning = true;
		this.m_isFinished = false;
	}

	// Token: 0x060012A8 RID: 4776 RVA: 0x000640ED File Offset: 0x000624ED
	public void Finish()
	{
		this.m_isFinished = true;
	}

	// Token: 0x060012A9 RID: 4777 RVA: 0x000640F6 File Offset: 0x000624F6
	public int GetLeftTime()
	{
		return this.m_totalTime - this.m_currentTime;
	}

	// Token: 0x060012AA RID: 4778 RVA: 0x00064105 File Offset: 0x00062505
	public bool IsDelegateMatched(CTimer.OnTimeUpHandler timeUpHandler)
	{
		return this.m_timeUpHandler == timeUpHandler;
	}

	// Token: 0x060012AB RID: 4779 RVA: 0x00064113 File Offset: 0x00062513
	public bool IsFinished()
	{
		return this.m_isFinished;
	}

	// Token: 0x060012AC RID: 4780 RVA: 0x0006411B File Offset: 0x0006251B
	public bool IsSequenceMatched(int sequence)
	{
		return this.m_sequence == sequence;
	}

	// Token: 0x060012AD RID: 4781 RVA: 0x00064126 File Offset: 0x00062526
	public void Pause()
	{
		this.m_isRunning = false;
	}

	// Token: 0x060012AE RID: 4782 RVA: 0x0006412F File Offset: 0x0006252F
	public void Reset()
	{
		this.m_currentTime = 0;
	}

	// Token: 0x060012AF RID: 4783 RVA: 0x00064138 File Offset: 0x00062538
	public void ResetTotalTime(int totalTime)
	{
		if (this.m_totalTime != totalTime)
		{
			this.m_currentTime = 0;
			this.m_totalTime = totalTime;
		}
	}

	// Token: 0x060012B0 RID: 4784 RVA: 0x00064154 File Offset: 0x00062554
	public void Resume()
	{
		this.m_isRunning = true;
	}

	// Token: 0x060012B1 RID: 4785 RVA: 0x00064160 File Offset: 0x00062560
	public void Update(int deltaTime)
	{
		if (!this.m_isFinished && this.m_isRunning)
		{
			if (this.m_loop == 0)
			{
				this.m_isFinished = true;
			}
			else
			{
				this.m_currentTime += deltaTime;
				if (this.m_currentTime >= this.m_totalTime)
				{
					if (this.m_timeUpHandler != null)
					{
						this.m_timeUpHandler(this.m_sequence);
					}
					this.m_currentTime = 0;
					this.m_loop--;
				}
			}
		}
	}

	// Token: 0x1700021B RID: 539
	// (get) Token: 0x060012B2 RID: 4786 RVA: 0x000641EA File Offset: 0x000625EA
	public int CurrentTime
	{
		get
		{
			return this.m_currentTime;
		}
	}

	// Token: 0x04000C61 RID: 3169
	private int m_currentTime;

	// Token: 0x04000C62 RID: 3170
	private bool m_isFinished;

	// Token: 0x04000C63 RID: 3171
	private bool m_isRunning;

	// Token: 0x04000C64 RID: 3172
	private int m_loop = 1;

	// Token: 0x04000C65 RID: 3173
	private int m_sequence;

	// Token: 0x04000C66 RID: 3174
	private CTimer.OnTimeUpHandler m_timeUpHandler;

	// Token: 0x04000C67 RID: 3175
	private int m_totalTime;

	// Token: 0x02000232 RID: 562
	// (Invoke) Token: 0x060012B4 RID: 4788
	public delegate void OnTimeUpHandler(int timerSequence);
}
