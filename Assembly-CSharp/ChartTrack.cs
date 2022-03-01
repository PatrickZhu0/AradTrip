using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200013B RID: 315
public class ChartTrack
{
	// Token: 0x06000906 RID: 2310 RVA: 0x0002F990 File Offset: 0x0002DD90
	public ChartTrack(string InTag, Color InColor)
	{
		this.isVisiable = true;
		this.bAverageStep = true;
		this.samples = new List<float>(ChartTrack.DefaultSampling);
		this.tag = InTag;
		this.drawColor = InColor;
		this.MaxSampling = ChartTrack.DefaultSampling;
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x0002F9CF File Offset: 0x0002DDCF
	public ChartTrack(string InTag, Color InColor, float InMin, float InMax) : this(InTag, InColor)
	{
		this.SetFixedRange(true, InMin, InMax);
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x0002F9E3 File Offset: 0x0002DDE3
	public void AddSample(float InValue)
	{
		this.samples.Add(InValue);
		this.CollapseSamplings();
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x0002F9F7 File Offset: 0x0002DDF7
	private float CalcMax(float InMax)
	{
		return this.bFixedRange ? this.fixedMaxSampleValue : InMax;
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x0002FA10 File Offset: 0x0002DE10
	private float CalcMin(float InMin)
	{
		return this.bFixedRange ? this.fixedMinSampleValue : InMin;
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x0002FA2C File Offset: 0x0002DE2C
	private float CalcX(int InIndex)
	{
		if (this.bAverageStep)
		{
			return (float)(InIndex * Screen.width) * (1f - ChartTrack.Clip * 2f) / (float)this.maxSampling;
		}
		return (float)(InIndex * Screen.width) * (1f - ChartTrack.Clip * 2f) / (float)this.samples.Count;
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x0002FA8E File Offset: 0x0002DE8E
	private float CalcY(float InPercent)
	{
		return InPercent * (float)Screen.height * (1f - ChartTrack.Clip * 2f);
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x0002FAAA File Offset: 0x0002DEAA
	private void CollapseSamplings()
	{
		if (this.samples.Count > this.maxSampling)
		{
			this.samples.RemoveRange(0, this.samples.Count - this.maxSampling);
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x0002FAE0 File Offset: 0x0002DEE0
	public static void DrawLine(Vector2 InStart, Vector2 InEnd, Color InColor, float InWidth)
	{
		DrawingHandle.DrawLine(new Vector2(InStart.x + (float)Screen.width * ChartTrack.Clip, (float)Screen.height * (1f - ChartTrack.Clip) - InStart.y), new Vector2(InEnd.x + (float)Screen.width * ChartTrack.Clip, (float)Screen.height * (1f - ChartTrack.Clip) - InEnd.y), InColor, InWidth, true);
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x0002FB5B File Offset: 0x0002DF5B
	public void OnRender()
	{
		this.OnRender(this.minValue, this.maxValue);
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x0002FB70 File Offset: 0x0002DF70
	public void OnRender(float InMinValue, float InMaxValue)
	{
		float num = this.CalcMax(InMaxValue) - this.CalcMin(InMinValue);
		Vector2 inStart = default(Vector2);
		for (int i = 0; i < this.samples.Count; i++)
		{
			float num2 = this.samples[i] - this.CalcMin(InMinValue);
			float inPercent = num2 / num;
			if (i == 0)
			{
				inStart..ctor(this.CalcX(i), this.CalcY(inPercent));
			}
			else
			{
				Vector2 vector;
				vector..ctor(this.CalcX(i), this.CalcY(inPercent));
				ChartTrack.DrawLine(inStart, vector, this.drawColor, 1f);
				inStart = vector;
			}
		}
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x0002FC18 File Offset: 0x0002E018
	public void SetFixedRange(bool bInFixed, float InMin, float InMax)
	{
		this.bFixedRange = bInFixed;
		this.fixedMinSampleValue = InMin;
		this.fixedMaxSampleValue = InMax;
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x0002FC2F File Offset: 0x0002E02F
	public void SetSample(float InValue, int reverseIndex)
	{
		if (reverseIndex >= 0 && this.samples.Count - reverseIndex > 0)
		{
			this.samples[this.samples.Count - reverseIndex - 1] = InValue;
		}
	}

	// Token: 0x17000180 RID: 384
	// (get) Token: 0x06000913 RID: 2323 RVA: 0x0002FC66 File Offset: 0x0002E066
	// (set) Token: 0x06000914 RID: 2324 RVA: 0x0002FC6E File Offset: 0x0002E06E
	public Color drawColor { get; set; }

	// Token: 0x17000181 RID: 385
	// (get) Token: 0x06000915 RID: 2325 RVA: 0x0002FC77 File Offset: 0x0002E077
	// (set) Token: 0x06000916 RID: 2326 RVA: 0x0002FC7F File Offset: 0x0002E07F
	public float fixedMaxSampleValue { get; protected set; }

	// Token: 0x17000182 RID: 386
	// (get) Token: 0x06000917 RID: 2327 RVA: 0x0002FC88 File Offset: 0x0002E088
	// (set) Token: 0x06000918 RID: 2328 RVA: 0x0002FC90 File Offset: 0x0002E090
	public float fixedMinSampleValue { get; protected set; }

	// Token: 0x17000183 RID: 387
	// (get) Token: 0x06000919 RID: 2329 RVA: 0x0002FC99 File Offset: 0x0002E099
	public bool hasSamples
	{
		get
		{
			return this.samples.Count > 0;
		}
	}

	// Token: 0x17000184 RID: 388
	// (get) Token: 0x0600091A RID: 2330 RVA: 0x0002FCA9 File Offset: 0x0002E0A9
	public bool isFixedRange
	{
		get
		{
			return this.bFixedRange;
		}
	}

	// Token: 0x17000185 RID: 389
	// (get) Token: 0x0600091B RID: 2331 RVA: 0x0002FCB1 File Offset: 0x0002E0B1
	// (set) Token: 0x0600091C RID: 2332 RVA: 0x0002FCB9 File Offset: 0x0002E0B9
	public int maxSampling
	{
		get
		{
			return this.MaxSampling;
		}
		set
		{
			this.MaxSampling = value;
			this.CollapseSamplings();
		}
	}

	// Token: 0x17000186 RID: 390
	// (get) Token: 0x0600091D RID: 2333 RVA: 0x0002FCC8 File Offset: 0x0002E0C8
	public float maxValue
	{
		get
		{
			float num = float.MinValue;
			for (int i = 0; i < this.samples.Count; i++)
			{
				if (this.samples[i] > num)
				{
					num = this.samples[i];
				}
			}
			return num;
		}
	}

	// Token: 0x17000187 RID: 391
	// (get) Token: 0x0600091E RID: 2334 RVA: 0x0002FD18 File Offset: 0x0002E118
	public float minValue
	{
		get
		{
			float num = float.MaxValue;
			for (int i = 0; i < this.samples.Count; i++)
			{
				if (this.samples[i] < num)
				{
					num = this.samples[i];
				}
			}
			return num;
		}
	}

	// Token: 0x17000188 RID: 392
	// (get) Token: 0x0600091F RID: 2335 RVA: 0x0002FD67 File Offset: 0x0002E167
	// (set) Token: 0x06000920 RID: 2336 RVA: 0x0002FD6F File Offset: 0x0002E16F
	public List<float> samples { get; protected set; }

	// Token: 0x17000189 RID: 393
	// (get) Token: 0x06000921 RID: 2337 RVA: 0x0002FD78 File Offset: 0x0002E178
	// (set) Token: 0x06000922 RID: 2338 RVA: 0x0002FD80 File Offset: 0x0002E180
	public string tag { get; protected set; }

	// Token: 0x040006F2 RID: 1778
	private bool bAverageStep;

	// Token: 0x040006F3 RID: 1779
	private bool bFixedRange;

	// Token: 0x040006F4 RID: 1780
	public static readonly float Clip = 0.1f;

	// Token: 0x040006F5 RID: 1781
	public static readonly int DefaultSampling = 100;

	// Token: 0x040006F6 RID: 1782
	public bool isVisiable;

	// Token: 0x040006F7 RID: 1783
	protected int MaxSampling;
}
