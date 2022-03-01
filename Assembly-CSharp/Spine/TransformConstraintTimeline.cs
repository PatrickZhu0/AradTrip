using System;

namespace Spine
{
	// Token: 0x02004997 RID: 18839
	public class TransformConstraintTimeline : CurveTimeline
	{
		// Token: 0x0601B0EC RID: 110828 RVA: 0x00853EF6 File Offset: 0x008522F6
		public TransformConstraintTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 5];
		}

		// Token: 0x170022EF RID: 8943
		// (get) Token: 0x0601B0ED RID: 110829 RVA: 0x00853F0D File Offset: 0x0085230D
		// (set) Token: 0x0601B0EE RID: 110830 RVA: 0x00853F15 File Offset: 0x00852315
		public int TransformConstraintIndex
		{
			get
			{
				return this.transformConstraintIndex;
			}
			set
			{
				this.transformConstraintIndex = value;
			}
		}

		// Token: 0x170022F0 RID: 8944
		// (get) Token: 0x0601B0EF RID: 110831 RVA: 0x00853F1E File Offset: 0x0085231E
		// (set) Token: 0x0601B0F0 RID: 110832 RVA: 0x00853F26 File Offset: 0x00852326
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

		// Token: 0x170022F1 RID: 8945
		// (get) Token: 0x0601B0F1 RID: 110833 RVA: 0x00853F2F File Offset: 0x0085232F
		public override int PropertyId
		{
			get
			{
				return 167772160 + this.transformConstraintIndex;
			}
		}

		// Token: 0x0601B0F2 RID: 110834 RVA: 0x00853F3D File Offset: 0x0085233D
		public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix, float scaleMix, float shearMix)
		{
			frameIndex *= 5;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = rotateMix;
			this.frames[frameIndex + 2] = translateMix;
			this.frames[frameIndex + 3] = scaleMix;
			this.frames[frameIndex + 4] = shearMix;
		}

		// Token: 0x0601B0F3 RID: 110835 RVA: 0x00853F7C File Offset: 0x0085237C
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			TransformConstraint transformConstraint = skeleton.transformConstraints.Items[this.transformConstraintIndex];
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
				if (pose == MixPose.Setup)
				{
					TransformConstraintData data = transformConstraint.data;
					transformConstraint.rotateMix = data.rotateMix + (num2 - data.rotateMix) * alpha;
					transformConstraint.translateMix = data.translateMix + (num3 - data.translateMix) * alpha;
					transformConstraint.scaleMix = data.scaleMix + (num4 - data.scaleMix) * alpha;
					transformConstraint.shearMix = data.shearMix + (num5 - data.shearMix) * alpha;
				}
				else
				{
					transformConstraint.rotateMix += (num2 - transformConstraint.rotateMix) * alpha;
					transformConstraint.translateMix += (num3 - transformConstraint.translateMix) * alpha;
					transformConstraint.scaleMix += (num4 - transformConstraint.scaleMix) * alpha;
					transformConstraint.shearMix += (num5 - transformConstraint.shearMix) * alpha;
				}
				return;
			}
			TransformConstraintData data2 = transformConstraint.data;
			if (pose == MixPose.Setup)
			{
				transformConstraint.rotateMix = data2.rotateMix;
				transformConstraint.translateMix = data2.translateMix;
				transformConstraint.scaleMix = data2.scaleMix;
				transformConstraint.shearMix = data2.shearMix;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			transformConstraint.rotateMix += (data2.rotateMix - transformConstraint.rotateMix) * alpha;
			transformConstraint.translateMix += (data2.translateMix - transformConstraint.translateMix) * alpha;
			transformConstraint.scaleMix += (data2.scaleMix - transformConstraint.scaleMix) * alpha;
			transformConstraint.shearMix += (data2.shearMix - transformConstraint.shearMix) * alpha;
		}

		// Token: 0x04012E03 RID: 77315
		public const int ENTRIES = 5;

		// Token: 0x04012E04 RID: 77316
		private const int PREV_TIME = -5;

		// Token: 0x04012E05 RID: 77317
		private const int PREV_ROTATE = -4;

		// Token: 0x04012E06 RID: 77318
		private const int PREV_TRANSLATE = -3;

		// Token: 0x04012E07 RID: 77319
		private const int PREV_SCALE = -2;

		// Token: 0x04012E08 RID: 77320
		private const int PREV_SHEAR = -1;

		// Token: 0x04012E09 RID: 77321
		private const int ROTATE = 1;

		// Token: 0x04012E0A RID: 77322
		private const int TRANSLATE = 2;

		// Token: 0x04012E0B RID: 77323
		private const int SCALE = 3;

		// Token: 0x04012E0C RID: 77324
		private const int SHEAR = 4;

		// Token: 0x04012E0D RID: 77325
		internal int transformConstraintIndex;

		// Token: 0x04012E0E RID: 77326
		internal float[] frames;
	}
}
