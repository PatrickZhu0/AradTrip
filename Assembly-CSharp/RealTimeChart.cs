using System;
using UnityEngine;

// Token: 0x0200015B RID: 347
public class RealTimeChart : MonoSingleton<RealTimeChart>
{
	// Token: 0x06000A02 RID: 2562 RVA: 0x00034A5C File Offset: 0x00032E5C
	public void AddSample(string InTag, float InValue)
	{
		ChartTrack chartTrack = this.FindTrack(InTag);
		if (chartTrack != null)
		{
			chartTrack.AddSample(InValue);
		}
		else
		{
			object[] inParameters = new object[]
			{
				InTag
			};
			DebugHelper.Assert(false, "no valid track with tag {0}", inParameters);
		}
	}

	// Token: 0x06000A03 RID: 2563 RVA: 0x00034A9C File Offset: 0x00032E9C
	public ChartTrack AddTrack(string InTag, Color InColor)
	{
		ChartTrack chartTrack = this.FindTrack(InTag);
		if (chartTrack == null)
		{
			chartTrack = new ChartTrack(InTag, InColor);
			this.Tracks.Add(chartTrack);
			return chartTrack;
		}
		chartTrack.drawColor = InColor;
		return chartTrack;
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x00034AD8 File Offset: 0x00032ED8
	public ChartTrack AddTrack(string InTag, Color InColor, bool bFixedRange, float InMin, float InMax)
	{
		ChartTrack chartTrack = this.FindTrack(InTag);
		if (chartTrack == null)
		{
			chartTrack = new ChartTrack(InTag, InColor, InMin, InMax);
			this.Tracks.Add(chartTrack);
		}
		else
		{
			chartTrack.drawColor = InColor;
		}
		chartTrack.SetFixedRange(bFixedRange, InMin, InMax);
		return chartTrack;
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x00034B24 File Offset: 0x00032F24
	protected void DrawBase()
	{
		ChartTrack.DrawLine(new Vector2(0f, 0f), new Vector2(0f, (float)Screen.height * (1f - ChartTrack.Clip * 2f)), Color.white, 2f);
		ChartTrack.DrawLine(new Vector2(0f, 0f), new Vector2((float)Screen.width * (1f - ChartTrack.Clip * 2f), 0f), Color.white, 2f);
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x00034BB4 File Offset: 0x00032FB4
	protected void DrawTracks()
	{
		float num = float.MaxValue;
		float num2 = float.MinValue;
		bool flag = false;
		for (int i = 0; i < this.Tracks.Count; i++)
		{
			if (this.Tracks[i].hasSamples)
			{
				flag = true;
				float num3;
				float num4;
				if (!this.Tracks[i].isFixedRange)
				{
					num3 = this.Tracks[i].minValue;
					num4 = this.Tracks[i].maxValue;
				}
				else
				{
					num3 = this.Tracks[i].fixedMinSampleValue;
					num4 = this.Tracks[i].fixedMaxSampleValue;
				}
				if (num3 < num)
				{
					num = num3;
				}
				if (num4 > num2)
				{
					num2 = num4;
				}
			}
		}
		if (flag)
		{
			for (int j = 0; j < this.Tracks.Count; j++)
			{
				if (this.Tracks[j].hasSamples && this.Tracks[j].isVisiable)
				{
					this.Tracks[j].OnRender(num, num2);
				}
			}
		}
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x00034CF8 File Offset: 0x000330F8
	public ChartTrack FindTrack(string InTag)
	{
		for (int i = 0; i < this.Tracks.Count; i++)
		{
			if (this.Tracks[i].tag == InTag)
			{
				return this.Tracks[i];
			}
		}
		return null;
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x00034D4B File Offset: 0x0003314B
	public override void Init()
	{
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x00034D4D File Offset: 0x0003314D
	private void OnGUI()
	{
		if (this.bVisible)
		{
			this.DrawBase();
			this.DrawTracks();
		}
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x00034D68 File Offset: 0x00033168
	public void RemoveTrack(string InTag)
	{
		for (int i = 0; i < this.Tracks.Count; i++)
		{
			if (this.Tracks[i].tag == InTag)
			{
				this.Tracks.RemoveAt(i);
				break;
			}
		}
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x00034DBE File Offset: 0x000331BE
	public void RemoveTrack(ChartTrack InTrack)
	{
		if (InTrack != null)
		{
			this.RemoveTrack(InTrack.tag);
		}
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x00034DD4 File Offset: 0x000331D4
	public void SetSample(string InTag, float InValue, int reverseIndex)
	{
		ChartTrack chartTrack = this.FindTrack(InTag);
		if (chartTrack != null)
		{
			chartTrack.SetSample(InValue, reverseIndex);
		}
		else
		{
			object[] inParameters = new object[]
			{
				InTag
			};
			DebugHelper.Assert(false, "no valid track with tag {0}", inParameters);
		}
	}

	// Token: 0x17000191 RID: 401
	// (get) Token: 0x06000A0D RID: 2573 RVA: 0x00034E13 File Offset: 0x00033213
	// (set) Token: 0x06000A0E RID: 2574 RVA: 0x00034E1B File Offset: 0x0003321B
	public bool isVisible
	{
		get
		{
			return this.bVisible;
		}
		set
		{
			this.bVisible = value;
		}
	}

	// Token: 0x04000776 RID: 1910
	public bool bVisible;

	// Token: 0x04000777 RID: 1911
	private Random RandomSupport = new Random();

	// Token: 0x04000778 RID: 1912
	private ListView<ChartTrack> Tracks = new ListView<ChartTrack>();
}
