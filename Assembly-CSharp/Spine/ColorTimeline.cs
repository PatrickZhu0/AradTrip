using System;

namespace Spine
{
	// Token: 0x02004990 RID: 18832
	public class ColorTimeline : CurveTimeline
	{
		// Token: 0x0601B0AC RID: 110764 RVA: 0x00852C42 File Offset: 0x00851042
		public ColorTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 5];
		}

		// Token: 0x170022D4 RID: 8916
		// (get) Token: 0x0601B0AD RID: 110765 RVA: 0x00852C59 File Offset: 0x00851059
		// (set) Token: 0x0601B0AE RID: 110766 RVA: 0x00852C61 File Offset: 0x00851061
		public int SlotIndex
		{
			get
			{
				return this.slotIndex;
			}
			set
			{
				this.slotIndex = value;
			}
		}

		// Token: 0x170022D5 RID: 8917
		// (get) Token: 0x0601B0AF RID: 110767 RVA: 0x00852C6A File Offset: 0x0085106A
		// (set) Token: 0x0601B0B0 RID: 110768 RVA: 0x00852C72 File Offset: 0x00851072
		public float[] Frames
		{
			get
			{
				return this.frames;
			}
			set
			{
				this.frames = value;
			}
		}

		// Token: 0x170022D6 RID: 8918
		// (get) Token: 0x0601B0B1 RID: 110769 RVA: 0x00852C7B File Offset: 0x0085107B
		public override int PropertyId
		{
			get
			{
				return 83886080 + this.slotIndex;
			}
		}

		// Token: 0x0601B0B2 RID: 110770 RVA: 0x00852C89 File Offset: 0x00851089
		public void SetFrame(int frameIndex, float time, float r, float g, float b, float a)
		{
			frameIndex *= 5;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = r;
			this.frames[frameIndex + 2] = g;
			this.frames[frameIndex + 3] = b;
			this.frames[frameIndex + 4] = a;
		}

		// Token: 0x0601B0B3 RID: 110771 RVA: 0x00852CC8 File Offset: 0x008510C8
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
				if (time >= array[array.Length - 5])
				{
					int num = array.Length;
					num2 = array[num + -4];
					num3 = array[num + -3];
					num4 = array[num + -2];
					num5 = array[num + -1];
				}
				else
				{
					int num6 = Animation.BinarySearch(array, time, 5);
					num2 = array[num6 + -4];
					num3 = array[num6 + -3];
					num4 = array[num6 + -2];
					num5 = array[num6 + -1];
					float num7 = array[num6];
					float curvePercent = base.GetCurvePercent(num6 / 5 - 1, 1f - (time - num7) / (array[num6 + -5] - num7));
					num2 += (array[num6 + 1] - num2) * curvePercent;
					num3 += (array[num6 + 2] - num3) * curvePercent;
					num4 += (array[num6 + 3] - num4) * curvePercent;
					num5 += (array[num6 + 4] - num5) * curvePercent;
				}
				if (alpha == 1f)
				{
					slot.r = num2;
					slot.g = num3;
					slot.b = num4;
					slot.a = num5;
				}
				else
				{
					float r;
					float g;
					float b;
					float a;
					if (pose == MixPose.Setup)
					{
						r = slot.data.r;
						g = slot.data.g;
						b = slot.data.b;
						a = slot.data.a;
					}
					else
					{
						r = slot.r;
						g = slot.g;
						b = slot.b;
						a = slot.a;
					}
					slot.r = r + (num2 - r) * alpha;
					slot.g = g + (num3 - g) * alpha;
					slot.b = b + (num4 - b) * alpha;
					slot.a = a + (num5 - a) * alpha;
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
		}

		// Token: 0x04012DD2 RID: 77266
		public const int ENTRIES = 5;

		// Token: 0x04012DD3 RID: 77267
		protected const int PREV_TIME = -5;

		// Token: 0x04012DD4 RID: 77268
		protected const int PREV_R = -4;

		// Token: 0x04012DD5 RID: 77269
		protected const int PREV_G = -3;

		// Token: 0x04012DD6 RID: 77270
		protected const int PREV_B = -2;

		// Token: 0x04012DD7 RID: 77271
		protected const int PREV_A = -1;

		// Token: 0x04012DD8 RID: 77272
		protected const int R = 1;

		// Token: 0x04012DD9 RID: 77273
		protected const int G = 2;

		// Token: 0x04012DDA RID: 77274
		protected const int B = 3;

		// Token: 0x04012DDB RID: 77275
		protected const int A = 4;

		// Token: 0x04012DDC RID: 77276
		internal int slotIndex;

		// Token: 0x04012DDD RID: 77277
		internal float[] frames;
	}
}
