using System;

namespace Spine
{
	// Token: 0x0200498B RID: 18827
	public abstract class CurveTimeline : Timeline
	{
		// Token: 0x0601B08D RID: 110733 RVA: 0x008520BD File Offset: 0x008504BD
		public CurveTimeline(int frameCount)
		{
			if (frameCount <= 0)
			{
				throw new ArgumentException("frameCount must be > 0: " + frameCount, "frameCount");
			}
			this.curves = new float[(frameCount - 1) * 19];
		}

		// Token: 0x170022CA RID: 8906
		// (get) Token: 0x0601B08E RID: 110734 RVA: 0x008520F8 File Offset: 0x008504F8
		public int FrameCount
		{
			get
			{
				return this.curves.Length / 19 + 1;
			}
		}

		// Token: 0x0601B08F RID: 110735
		public abstract void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction);

		// Token: 0x170022CB RID: 8907
		// (get) Token: 0x0601B090 RID: 110736
		public abstract int PropertyId { get; }

		// Token: 0x0601B091 RID: 110737 RVA: 0x00852107 File Offset: 0x00850507
		public void SetLinear(int frameIndex)
		{
			this.curves[frameIndex * 19] = 0f;
		}

		// Token: 0x0601B092 RID: 110738 RVA: 0x00852119 File Offset: 0x00850519
		public void SetStepped(int frameIndex)
		{
			this.curves[frameIndex * 19] = 1f;
		}

		// Token: 0x0601B093 RID: 110739 RVA: 0x0085212C File Offset: 0x0085052C
		public void SetCurve(int frameIndex, float cx1, float cy1, float cx2, float cy2)
		{
			float num = (-cx1 * 2f + cx2) * 0.03f;
			float num2 = (-cy1 * 2f + cy2) * 0.03f;
			float num3 = ((cx1 - cx2) * 3f + 1f) * 0.006f;
			float num4 = ((cy1 - cy2) * 3f + 1f) * 0.006f;
			float num5 = num * 2f + num3;
			float num6 = num2 * 2f + num4;
			float num7 = cx1 * 0.3f + num + num3 * 0.16666667f;
			float num8 = cy1 * 0.3f + num2 + num4 * 0.16666667f;
			int i = frameIndex * 19;
			float[] array = this.curves;
			array[i++] = 2f;
			float num9 = num7;
			float num10 = num8;
			int num11 = i + 19 - 1;
			while (i < num11)
			{
				array[i] = num9;
				array[i + 1] = num10;
				num7 += num5;
				num8 += num6;
				num5 += num3;
				num6 += num4;
				num9 += num7;
				num10 += num8;
				i += 2;
			}
		}

		// Token: 0x0601B094 RID: 110740 RVA: 0x00852244 File Offset: 0x00850644
		public float GetCurvePercent(int frameIndex, float percent)
		{
			percent = MathUtils.Clamp(percent, 0f, 1f);
			float[] array = this.curves;
			int i = frameIndex * 19;
			float num = array[i];
			if (num == 0f)
			{
				return percent;
			}
			if (num == 1f)
			{
				return 0f;
			}
			i++;
			float num2 = 0f;
			int num3 = i;
			int num4 = i + 19 - 1;
			while (i < num4)
			{
				num2 = array[i];
				if (num2 >= percent)
				{
					float num5;
					float num6;
					if (i == num3)
					{
						num5 = 0f;
						num6 = 0f;
					}
					else
					{
						num5 = array[i - 2];
						num6 = array[i - 1];
					}
					return num6 + (array[i + 1] - num6) * (percent - num5) / (num2 - num5);
				}
				i += 2;
			}
			float num7 = array[i - 1];
			return num7 + (1f - num7) * (percent - num2) / (1f - num2);
		}

		// Token: 0x0601B095 RID: 110741 RVA: 0x0085231F File Offset: 0x0085071F
		public float GetCurveType(int frameIndex)
		{
			return this.curves[frameIndex * 19];
		}

		// Token: 0x04012DBF RID: 77247
		protected const float LINEAR = 0f;

		// Token: 0x04012DC0 RID: 77248
		protected const float STEPPED = 1f;

		// Token: 0x04012DC1 RID: 77249
		protected const float BEZIER = 2f;

		// Token: 0x04012DC2 RID: 77250
		protected const int BEZIER_SIZE = 19;

		// Token: 0x04012DC3 RID: 77251
		internal float[] curves;
	}
}
