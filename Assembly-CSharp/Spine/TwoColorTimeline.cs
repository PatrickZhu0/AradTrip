using System;

namespace Spine
{
	// Token: 0x02004991 RID: 18833
	public class TwoColorTimeline : CurveTimeline
	{
		// Token: 0x0601B0B4 RID: 110772 RVA: 0x00852F5C File Offset: 0x0085135C
		public TwoColorTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 8];
		}

		// Token: 0x170022D7 RID: 8919
		// (get) Token: 0x0601B0B5 RID: 110773 RVA: 0x00852F73 File Offset: 0x00851373
		// (set) Token: 0x0601B0B6 RID: 110774 RVA: 0x00852F7B File Offset: 0x0085137B
		public int SlotIndex
		{
			get
			{
				return this.slotIndex;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentOutOfRangeException("index must be >= 0.");
				}
				this.slotIndex = value;
			}
		}

		// Token: 0x170022D8 RID: 8920
		// (get) Token: 0x0601B0B7 RID: 110775 RVA: 0x00852F96 File Offset: 0x00851396
		public float[] Frames
		{
			get
			{
				return this.frames;
			}
		}

		// Token: 0x170022D9 RID: 8921
		// (get) Token: 0x0601B0B8 RID: 110776 RVA: 0x00852F9E File Offset: 0x0085139E
		public override int PropertyId
		{
			get
			{
				return 234881024 + this.slotIndex;
			}
		}

		// Token: 0x0601B0B9 RID: 110777 RVA: 0x00852FAC File Offset: 0x008513AC
		public void SetFrame(int frameIndex, float time, float r, float g, float b, float a, float r2, float g2, float b2)
		{
			frameIndex *= 8;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = r;
			this.frames[frameIndex + 2] = g;
			this.frames[frameIndex + 3] = b;
			this.frames[frameIndex + 4] = a;
			this.frames[frameIndex + 5] = r2;
			this.frames[frameIndex + 6] = g2;
			this.frames[frameIndex + 7] = b2;
		}

		// Token: 0x0601B0BA RID: 110778 RVA: 0x0085301C File Offset: 0x0085141C
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			Slot slot = skeleton.slots.Items[this.slotIndex];
			float[] array = this.frames;
			if (time >= array[0])
			{
				float num2;
				float num3;
				float num4;
				float num5;
				float num6;
				float num7;
				float num8;
				if (time >= array[array.Length - 8])
				{
					int num = array.Length;
					num2 = array[num + -7];
					num3 = array[num + -6];
					num4 = array[num + -5];
					num5 = array[num + -4];
					num6 = array[num + -3];
					num7 = array[num + -2];
					num8 = array[num + -1];
				}
				else
				{
					int num9 = Animation.BinarySearch(array, time, 8);
					num2 = array[num9 + -7];
					num3 = array[num9 + -6];
					num4 = array[num9 + -5];
					num5 = array[num9 + -4];
					num6 = array[num9 + -3];
					num7 = array[num9 + -2];
					num8 = array[num9 + -1];
					float num10 = array[num9];
					float curvePercent = base.GetCurvePercent(num9 / 8 - 1, 1f - (time - num10) / (array[num9 + -8] - num10));
					num2 += (array[num9 + 1] - num2) * curvePercent;
					num3 += (array[num9 + 2] - num3) * curvePercent;
					num4 += (array[num9 + 3] - num4) * curvePercent;
					num5 += (array[num9 + 4] - num5) * curvePercent;
					num6 += (array[num9 + 5] - num6) * curvePercent;
					num7 += (array[num9 + 6] - num7) * curvePercent;
					num8 += (array[num9 + 7] - num8) * curvePercent;
				}
				if (alpha == 1f)
				{
					slot.r = num2;
					slot.g = num3;
					slot.b = num4;
					slot.a = num5;
					slot.r2 = num6;
					slot.g2 = num7;
					slot.b2 = num8;
				}
				else
				{
					float r;
					float g;
					float b;
					float a;
					float r2;
					float g2;
					float b2;
					if (pose == MixPose.Setup)
					{
						r = slot.data.r;
						g = slot.data.g;
						b = slot.data.b;
						a = slot.data.a;
						r2 = slot.data.r2;
						g2 = slot.data.g2;
						b2 = slot.data.b2;
					}
					else
					{
						r = slot.r;
						g = slot.g;
						b = slot.b;
						a = slot.a;
						r2 = slot.r2;
						g2 = slot.g2;
						b2 = slot.b2;
					}
					slot.r = r + (num2 - r) * alpha;
					slot.g = g + (num3 - g) * alpha;
					slot.b = b + (num4 - b) * alpha;
					slot.a = a + (num5 - a) * alpha;
					slot.r2 = r2 + (num6 - r2) * alpha;
					slot.g2 = g2 + (num7 - g2) * alpha;
					slot.b2 = b2 + (num8 - b2) * alpha;
				}
				return;
			}
			SlotData data = slot.data;
			if (pose == MixPose.Setup)
			{
				slot.r = data.r;
				slot.g = data.g;
				slot.b = data.b;
				slot.a = data.a;
				slot.r2 = data.r2;
				slot.g2 = data.g2;
				slot.b2 = data.b2;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			slot.r += (slot.r - data.r) * alpha;
			slot.g += (slot.g - data.g) * alpha;
			slot.b += (slot.b - data.b) * alpha;
			slot.a += (slot.a - data.a) * alpha;
			slot.r2 += (slot.r2 - data.r2) * alpha;
			slot.g2 += (slot.g2 - data.g2) * alpha;
			slot.b2 += (slot.b2 - data.b2) * alpha;
		}

		// Token: 0x04012DDE RID: 77278
		public const int ENTRIES = 8;

		// Token: 0x04012DDF RID: 77279
		protected const int PREV_TIME = -8;

		// Token: 0x04012DE0 RID: 77280
		protected const int PREV_R = -7;

		// Token: 0x04012DE1 RID: 77281
		protected const int PREV_G = -6;

		// Token: 0x04012DE2 RID: 77282
		protected const int PREV_B = -5;

		// Token: 0x04012DE3 RID: 77283
		protected const int PREV_A = -4;

		// Token: 0x04012DE4 RID: 77284
		protected const int PREV_R2 = -3;

		// Token: 0x04012DE5 RID: 77285
		protected const int PREV_G2 = -2;

		// Token: 0x04012DE6 RID: 77286
		protected const int PREV_B2 = -1;

		// Token: 0x04012DE7 RID: 77287
		protected const int R = 1;

		// Token: 0x04012DE8 RID: 77288
		protected const int G = 2;

		// Token: 0x04012DE9 RID: 77289
		protected const int B = 3;

		// Token: 0x04012DEA RID: 77290
		protected const int A = 4;

		// Token: 0x04012DEB RID: 77291
		protected const int R2 = 5;

		// Token: 0x04012DEC RID: 77292
		protected const int G2 = 6;

		// Token: 0x04012DED RID: 77293
		protected const int B2 = 7;

		// Token: 0x04012DEE RID: 77294
		internal int slotIndex;

		// Token: 0x04012DEF RID: 77295
		internal float[] frames;
	}
}
