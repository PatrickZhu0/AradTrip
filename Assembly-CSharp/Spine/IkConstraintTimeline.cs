using System;

namespace Spine
{
	// Token: 0x02004996 RID: 18838
	public class IkConstraintTimeline : CurveTimeline
	{
		// Token: 0x0601B0E4 RID: 110820 RVA: 0x00853C84 File Offset: 0x00852084
		public IkConstraintTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 3];
		}

		// Token: 0x170022EC RID: 8940
		// (get) Token: 0x0601B0E5 RID: 110821 RVA: 0x00853C9B File Offset: 0x0085209B
		// (set) Token: 0x0601B0E6 RID: 110822 RVA: 0x00853CA3 File Offset: 0x008520A3
		public int IkConstraintIndex
		{
			get
			{
				return this.ikConstraintIndex;
			}
			set
			{
				this.ikConstraintIndex = value;
			}
		}

		// Token: 0x170022ED RID: 8941
		// (get) Token: 0x0601B0E7 RID: 110823 RVA: 0x00853CAC File Offset: 0x008520AC
		// (set) Token: 0x0601B0E8 RID: 110824 RVA: 0x00853CB4 File Offset: 0x008520B4
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

		// Token: 0x170022EE RID: 8942
		// (get) Token: 0x0601B0E9 RID: 110825 RVA: 0x00853CBD File Offset: 0x008520BD
		public override int PropertyId
		{
			get
			{
				return 150994944 + this.ikConstraintIndex;
			}
		}

		// Token: 0x0601B0EA RID: 110826 RVA: 0x00853CCB File Offset: 0x008520CB
		public void SetFrame(int frameIndex, float time, float mix, int bendDirection)
		{
			frameIndex *= 3;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = mix;
			this.frames[frameIndex + 2] = (float)bendDirection;
		}

		// Token: 0x0601B0EB RID: 110827 RVA: 0x00853CF4 File Offset: 0x008520F4
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			IkConstraint ikConstraint = skeleton.ikConstraints.Items[this.ikConstraintIndex];
			float[] array = this.frames;
			if (time < array[0])
			{
				if (pose == MixPose.Setup)
				{
					ikConstraint.mix = ikConstraint.data.mix;
					ikConstraint.bendDirection = ikConstraint.data.bendDirection;
					return;
				}
				if (pose != MixPose.Current)
				{
					return;
				}
				ikConstraint.mix += (ikConstraint.data.mix - ikConstraint.mix) * alpha;
				ikConstraint.bendDirection = ikConstraint.data.bendDirection;
				return;
			}
			else
			{
				if (time >= array[array.Length - 3])
				{
					if (pose == MixPose.Setup)
					{
						ikConstraint.mix = ikConstraint.data.mix + (array[array.Length + -2] - ikConstraint.data.mix) * alpha;
						ikConstraint.bendDirection = ((direction != MixDirection.Out) ? ((int)array[array.Length + -1]) : ikConstraint.data.bendDirection);
					}
					else
					{
						ikConstraint.mix += (array[array.Length + -2] - ikConstraint.mix) * alpha;
						if (direction == MixDirection.In)
						{
							ikConstraint.bendDirection = (int)array[array.Length + -1];
						}
					}
					return;
				}
				int num = Animation.BinarySearch(array, time, 3);
				float num2 = array[num + -2];
				float num3 = array[num];
				float curvePercent = base.GetCurvePercent(num / 3 - 1, 1f - (time - num3) / (array[num + -3] - num3));
				if (pose == MixPose.Setup)
				{
					ikConstraint.mix = ikConstraint.data.mix + (num2 + (array[num + 1] - num2) * curvePercent - ikConstraint.data.mix) * alpha;
					ikConstraint.bendDirection = ((direction != MixDirection.Out) ? ((int)array[num + -1]) : ikConstraint.data.bendDirection);
				}
				else
				{
					ikConstraint.mix += (num2 + (array[num + 1] - num2) * curvePercent - ikConstraint.mix) * alpha;
					if (direction == MixDirection.In)
					{
						ikConstraint.bendDirection = (int)array[num + -1];
					}
				}
				return;
			}
		}

		// Token: 0x04012DFB RID: 77307
		public const int ENTRIES = 3;

		// Token: 0x04012DFC RID: 77308
		private const int PREV_TIME = -3;

		// Token: 0x04012DFD RID: 77309
		private const int PREV_MIX = -2;

		// Token: 0x04012DFE RID: 77310
		private const int PREV_BEND_DIRECTION = -1;

		// Token: 0x04012DFF RID: 77311
		private const int MIX = 1;

		// Token: 0x04012E00 RID: 77312
		private const int BEND_DIRECTION = 2;

		// Token: 0x04012E01 RID: 77313
		internal int ikConstraintIndex;

		// Token: 0x04012E02 RID: 77314
		internal float[] frames;
	}
}
