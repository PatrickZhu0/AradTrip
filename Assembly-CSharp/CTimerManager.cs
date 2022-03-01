using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000233 RID: 563
public class CTimerManager : Singleton<CTimerManager>
{
	// Token: 0x060012B8 RID: 4792 RVA: 0x000641FA File Offset: 0x000625FA
	public int AddTimer(int time, int loop, CTimer.OnTimeUpHandler onTimeUpHandler)
	{
		return this.AddTimer(time, loop, onTimeUpHandler, false);
	}

	// Token: 0x060012B9 RID: 4793 RVA: 0x00064206 File Offset: 0x00062606
	public int AddTimer(int time, int loop, CTimer.OnTimeUpHandler onTimeUpHandler, bool useFrameSync)
	{
		this.m_timerSequence++;
		this.m_timers[useFrameSync ? 1 : 0].Add(new CTimer(time, loop, onTimeUpHandler, this.m_timerSequence));
		return this.m_timerSequence;
	}

	// Token: 0x060012BA RID: 4794 RVA: 0x00064244 File Offset: 0x00062644
	public int GetLeftTime(int sequence)
	{
		CTimer timer = this.GetTimer(sequence);
		if (timer != null)
		{
			return timer.GetLeftTime() / 1000;
		}
		return -1;
	}

	// Token: 0x060012BB RID: 4795 RVA: 0x00064270 File Offset: 0x00062670
	public CTimer GetTimer(int sequence)
	{
		for (int i = 0; i < this.m_timers.Length; i++)
		{
			List<CTimer> list = this.m_timers[i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].IsSequenceMatched(sequence))
				{
					return list[j];
				}
			}
		}
		return null;
	}

	// Token: 0x060012BC RID: 4796 RVA: 0x000642D4 File Offset: 0x000626D4
	public int GetTimerCurrent(int sequence)
	{
		CTimer timer = this.GetTimer(sequence);
		if (timer != null)
		{
			return timer.CurrentTime;
		}
		return -1;
	}

	// Token: 0x060012BD RID: 4797 RVA: 0x000642F8 File Offset: 0x000626F8
	public override void Init()
	{
		this.m_timers = new List<CTimer>[Enum.GetValues(typeof(CTimerManager.enTimerType)).Length];
		for (int i = 0; i < this.m_timers.Length; i++)
		{
			this.m_timers[i] = new List<CTimer>();
		}
		this.m_timerSequence = 0;
	}

	// Token: 0x060012BE RID: 4798 RVA: 0x00064354 File Offset: 0x00062754
	public void PauseTimer(int sequence)
	{
		CTimer timer = this.GetTimer(sequence);
		if (timer != null)
		{
			timer.Pause();
		}
	}

	// Token: 0x060012BF RID: 4799 RVA: 0x00064378 File Offset: 0x00062778
	public void RemoveAllTimer()
	{
		for (int i = 0; i < this.m_timers.Length; i++)
		{
			this.m_timers[i].Clear();
		}
	}

	// Token: 0x060012C0 RID: 4800 RVA: 0x000643AB File Offset: 0x000627AB
	public void RemoveAllTimer(bool useFrameSync)
	{
		this.m_timers[useFrameSync ? 1 : 0].Clear();
	}

	// Token: 0x060012C1 RID: 4801 RVA: 0x000643C6 File Offset: 0x000627C6
	public void RemoveTimer(CTimer.OnTimeUpHandler onTimeUpHandler)
	{
		this.RemoveTimer(onTimeUpHandler, false);
	}

	// Token: 0x060012C2 RID: 4802 RVA: 0x000643D0 File Offset: 0x000627D0
	public void RemoveTimer(int sequence)
	{
		for (int i = 0; i < this.m_timers.Length; i++)
		{
			List<CTimer> list = this.m_timers[i];
			for (int j = 0; j < list.Count; j++)
			{
				if (list[j].IsSequenceMatched(sequence))
				{
					list[j].Finish();
					return;
				}
			}
		}
	}

	// Token: 0x060012C3 RID: 4803 RVA: 0x00064438 File Offset: 0x00062838
	public void RemoveTimer(CTimer.OnTimeUpHandler onTimeUpHandler, bool useFrameSync)
	{
		List<CTimer> list = this.m_timers[useFrameSync ? 1 : 0];
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i].IsDelegateMatched(onTimeUpHandler))
			{
				list[i].Finish();
			}
		}
	}

	// Token: 0x060012C4 RID: 4804 RVA: 0x0006448F File Offset: 0x0006288F
	public void RemoveTimerSafely(ref int sequence)
	{
		if (sequence != 0)
		{
			this.RemoveTimer(sequence);
			sequence = 0;
		}
	}

	// Token: 0x060012C5 RID: 4805 RVA: 0x000644A4 File Offset: 0x000628A4
	public void ResetTimer(int sequence)
	{
		CTimer timer = this.GetTimer(sequence);
		if (timer != null)
		{
			timer.Reset();
		}
	}

	// Token: 0x060012C6 RID: 4806 RVA: 0x000644C8 File Offset: 0x000628C8
	public void ResetTimerTotalTime(int sequence, int totalTime)
	{
		CTimer timer = this.GetTimer(sequence);
		if (timer != null)
		{
			timer.ResetTotalTime(totalTime);
		}
	}

	// Token: 0x060012C7 RID: 4807 RVA: 0x000644EC File Offset: 0x000628EC
	public void ResumeTimer(int sequence)
	{
		CTimer timer = this.GetTimer(sequence);
		if (timer != null)
		{
			timer.Resume();
		}
	}

	// Token: 0x060012C8 RID: 4808 RVA: 0x0006450D File Offset: 0x0006290D
	public void Update()
	{
		this.UpdateTimer((int)(Time.deltaTime * 1000f), CTimerManager.enTimerType.Normal);
	}

	// Token: 0x060012C9 RID: 4809 RVA: 0x00064522 File Offset: 0x00062922
	public void UpdateLogic(int delta)
	{
		this.UpdateTimer(delta, CTimerManager.enTimerType.FrameSync);
	}

	// Token: 0x060012CA RID: 4810 RVA: 0x0006452C File Offset: 0x0006292C
	private void UpdateTimer(int delta, CTimerManager.enTimerType timerType)
	{
		List<CTimer> list = this.m_timers[(int)timerType];
		int i = 0;
		while (i < list.Count)
		{
			if (list[i].IsFinished())
			{
				list.RemoveAt(i);
			}
			else
			{
				list[i].Update(delta);
				i++;
			}
		}
	}

	// Token: 0x04000C68 RID: 3176
	private List<CTimer>[] m_timers;

	// Token: 0x04000C69 RID: 3177
	private int m_timerSequence;

	// Token: 0x02000234 RID: 564
	private enum enTimerType
	{
		// Token: 0x04000C6B RID: 3179
		Normal,
		// Token: 0x04000C6C RID: 3180
		FrameSync
	}
}
