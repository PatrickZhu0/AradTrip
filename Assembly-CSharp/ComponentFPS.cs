using System;
using UnityEngine;

// Token: 0x02000069 RID: 105
public class ComponentFPS : MonoSingleton<ComponentFPS>
{
	// Token: 0x06000247 RID: 583 RVA: 0x00012195 File Offset: 0x00010595
	private void Start()
	{
		Object.DontDestroyOnLoad(base.gameObject);
	}

	// Token: 0x06000248 RID: 584 RVA: 0x000121A2 File Offset: 0x000105A2
	private void Update()
	{
		this.UpdateFPS();
	}

	// Token: 0x06000249 RID: 585 RVA: 0x000121AC File Offset: 0x000105AC
	private void UpdateFPS()
	{
		this.timeleft -= Time.deltaTime;
		this.accum += Time.timeScale / Time.deltaTime;
		this.frames += 1f;
		if ((double)this.timeleft <= 0.0)
		{
			this.fps = this.accum / this.frames;
			this.timeleft = 1f;
			this.accum = 0f;
			this.frames = 0f;
			this.frameCount++;
			this.fpsSum += (int)this.fps;
			if (this.frameCount >= this.watchFrames)
			{
				this.averageFrame = (int)((float)this.fpsSum / (float)this.frameCount);
				this.frameCount = 0;
				this.fpsSum = 0;
			}
		}
	}

	// Token: 0x0600024A RID: 586 RVA: 0x00012295 File Offset: 0x00010695
	public int GetFPS()
	{
		return (int)this.fps;
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0001229E File Offset: 0x0001069E
	public int GetLastAverageFPS()
	{
		return this.averageFrame;
	}

	// Token: 0x0400023D RID: 573
	public int watchFrames = 10;

	// Token: 0x0400023E RID: 574
	public int averageFrame = 30;

	// Token: 0x0400023F RID: 575
	public int lowFrameTown = 10;

	// Token: 0x04000240 RID: 576
	public int lowFrameBattle = 10;

	// Token: 0x04000241 RID: 577
	public int frameCount;

	// Token: 0x04000242 RID: 578
	public int fpsSum;

	// Token: 0x04000243 RID: 579
	private float updateInterval = 1f;

	// Token: 0x04000244 RID: 580
	private float accum;

	// Token: 0x04000245 RID: 581
	private float frames;

	// Token: 0x04000246 RID: 582
	private float timeleft;

	// Token: 0x04000247 RID: 583
	private float fps;

	// Token: 0x04000248 RID: 584
	private string FPSAAA;

	// Token: 0x04000249 RID: 585
	[Range(0f, 150f)]
	public int MaxFPS;
}
