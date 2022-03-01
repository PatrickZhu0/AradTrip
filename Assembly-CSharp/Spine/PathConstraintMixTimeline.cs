using System;

namespace Spine
{
	// Token: 0x0200499A RID: 18842
	public class PathConstraintMixTimeline : CurveTimeline
	{
		// Token: 0x0601B0FF RID: 110847 RVA: 0x008544D4 File Offset: 0x008528D4
		public PathConstraintMixTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 3];
		}

		// Token: 0x170022F6 RID: 8950
		// (get) Token: 0x0601B100 RID: 110848 RVA: 0x008544EB File Offset: 0x008528EB
		// (set) Token: 0x0601B101 RID: 110849 RVA: 0x008544F3 File Offset: 0x008528F3
		public int PathConstraintIndex
		{
			get
			{
				return this.pathConstraintIndex;
			}
			set
			{
				this.pathConstraintIndex = value;
			}
		}

		// Token: 0x170022F7 RID: 8951
		// (get) Token: 0x0601B102 RID: 110850 RVA: 0x008544FC File Offset: 0x008528FC
		// (set) Token: 0x0601B103 RID: 110851 RVA: 0x00854504 File Offset: 0x00852904
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

		// Token: 0x170022F8 RID: 8952
		// (get) Token: 0x0601B104 RID: 110852 RVA: 0x0085450D File Offset: 0x0085290D
		public override int PropertyId
		{
			get
			{
				return 218103808 + this.pathConstraintIndex;
			}
		}

		// Token: 0x0601B105 RID: 110853 RVA: 0x0085451B File Offset: 0x0085291B
		public void SetFrame(int frameIndex, float time, float rotateMix, float translateMix)
		{
			frameIndex *= 3;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = rotateMix;
			this.frames[frameIndex + 2] = translateMix;
		}

		// Token: 0x0601B106 RID: 110854 RVA: 0x00854544 File Offset: 0x00852944
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			PathConstraint pathConstraint = skeleton.pathConstraints.Items[this.pathConstraintIndex];
			float[] array = this.frames;
			if (time >= array[0])
			{
				float num;
				float num2;
				if (time >= array[array.Length - 3])
				{
					num = array[array.Length + -2];
					num2 = array[array.Length + -1];
				}
				else
				{
					int num3 = Animation.BinarySearch(array, time, 3);
					num = array[num3 + -2];
					num2 = array[num3 + -1];
					float num4 = array[num3];
					float curvePercent = base.GetCurvePercent(num3 / 3 - 1, 1f - (time - num4) / (array[num3 + -3] - num4));
					num += (array[num3 + 1] - num) * curvePercent;
					num2 += (array[num3 + 2] - num2) * curvePercent;
				}
				if (pose == MixPose.Setup)
				{
					pathConstraint.rotateMix = pathConstraint.data.rotateMix + (num - pathConstraint.data.rotateMix) * alpha;
					pathConstraint.translateMix = pathConstraint.data.translateMix + (num2 - pathConstraint.data.translateMix) * alpha;
				}
				else
				{
					pathConstraint.rotateMix += (num - pathConstraint.rotateMix) * alpha;
					pathConstraint.translateMix += (num2 - pathConstraint.translateMix) * alpha;
				}
				return;
			}
			if (pose == MixPose.Setup)
			{
				pathConstraint.rotateMix = pathConstraint.data.rotateMix;
				pathConstraint.translateMix = pathConstraint.data.translateMix;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			pathConstraint.rotateMix += (pathConstraint.data.rotateMix - pathConstraint.rotateMix) * alpha;
			pathConstraint.translateMix += (pathConstraint.data.translateMix - pathConstraint.translateMix) * alpha;
		}

		// Token: 0x04012E15 RID: 77333
		public const int ENTRIES = 3;

		// Token: 0x04012E16 RID: 77334
		private const int PREV_TIME = -3;

		// Token: 0x04012E17 RID: 77335
		private const int PREV_ROTATE = -2;

		// Token: 0x04012E18 RID: 77336
		private const int PREV_TRANSLATE = -1;

		// Token: 0x04012E19 RID: 77337
		private const int ROTATE = 1;

		// Token: 0x04012E1A RID: 77338
		private const int TRANSLATE = 2;

		// Token: 0x04012E1B RID: 77339
		internal int pathConstraintIndex;

		// Token: 0x04012E1C RID: 77340
		internal float[] frames;
	}
}
