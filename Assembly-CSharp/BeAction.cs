using System;

// Token: 0x02004209 RID: 16905
public class BeAction
{
	// Token: 0x06017687 RID: 95879 RVA: 0x0073198F File Offset: 0x0072FD8F
	public void Start()
	{
		this.timeAcc = 0;
		this.running = true;
		this.delayed = false;
		this.OnStart();
	}

	// Token: 0x06017688 RID: 95880 RVA: 0x007319AC File Offset: 0x0072FDAC
	public void Update(int deltaTime)
	{
		if (!this.running)
		{
			return;
		}
		this.OnTick(deltaTime);
		this.timeAcc += deltaTime;
		if (this.delay > 0 && !this.delayed)
		{
			if (this.timeAcc > this.delay)
			{
				this.delayed = true;
				this.timeAcc -= this.delay;
				return;
			}
			return;
		}
		else
		{
			if (this.timeAcc > this.duration)
			{
				this.timeAcc = this.duration;
			}
			VFactor process = new VFactor((long)this.timeAcc, (long)this.duration);
			if (this.duration == 0)
			{
				Logger.LogErrorFormat("BeAction dutation is {1},this may raise DivideByZeroException", new object[]
				{
					this.duration
				});
				this.Stop();
				return;
			}
			this.OnUpdate(process);
			if (this.timeAcc >= this.duration)
			{
				this.Stop();
				if (this.finishCallback != null)
				{
					this.finishCallback();
				}
			}
			return;
		}
	}

	// Token: 0x06017689 RID: 95881 RVA: 0x00731AB4 File Offset: 0x0072FEB4
	public void Stop()
	{
		this.running = false;
	}

	// Token: 0x0601768A RID: 95882 RVA: 0x00731ABD File Offset: 0x0072FEBD
	public bool IsRunning()
	{
		return this.running;
	}

	// Token: 0x0601768B RID: 95883 RVA: 0x00731AC5 File Offset: 0x0072FEC5
	public void Pause()
	{
		this.pause = true;
	}

	// Token: 0x0601768C RID: 95884 RVA: 0x00731ACE File Offset: 0x0072FECE
	public void Resume()
	{
		this.pause = false;
	}

	// Token: 0x0601768D RID: 95885 RVA: 0x00731AD7 File Offset: 0x0072FED7
	public bool IsPause()
	{
		return this.pause;
	}

	// Token: 0x0601768E RID: 95886 RVA: 0x00731ADF File Offset: 0x0072FEDF
	public void SetFinishCallback(BeAction.Del callback)
	{
		this.finishCallback = callback;
	}

	// Token: 0x0601768F RID: 95887 RVA: 0x00731AE8 File Offset: 0x0072FEE8
	public virtual void OnUpdate(VFactor process)
	{
	}

	// Token: 0x06017690 RID: 95888 RVA: 0x00731AEA File Offset: 0x0072FEEA
	public virtual void OnTick(int deltaTime)
	{
	}

	// Token: 0x06017691 RID: 95889 RVA: 0x00731AEC File Offset: 0x0072FEEC
	public virtual void OnStart()
	{
	}

	// Token: 0x04010CF3 RID: 68851
	public BeActionManager manager;

	// Token: 0x04010CF4 RID: 68852
	protected BeEntity target;

	// Token: 0x04010CF5 RID: 68853
	protected int delay;

	// Token: 0x04010CF6 RID: 68854
	protected int duration;

	// Token: 0x04010CF7 RID: 68855
	protected bool pause;

	// Token: 0x04010CF8 RID: 68856
	protected BeAction.Del finishCallback;

	// Token: 0x04010CF9 RID: 68857
	protected bool running;

	// Token: 0x04010CFA RID: 68858
	protected int timeAcc;

	// Token: 0x04010CFB RID: 68859
	protected bool delayed;

	// Token: 0x0200420A RID: 16906
	// (Invoke) Token: 0x06017693 RID: 95891
	public delegate void Del();
}
