using System;

namespace Spine
{
	// Token: 0x02004998 RID: 18840
	public class PathConstraintPositionTimeline : CurveTimeline
	{
		// Token: 0x0601B0F4 RID: 110836 RVA: 0x0085421F File Offset: 0x0085261F
		public PathConstraintPositionTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 2];
		}

		// Token: 0x170022F2 RID: 8946
		// (get) Token: 0x0601B0F5 RID: 110837 RVA: 0x00854236 File Offset: 0x00852636
		public override int PropertyId
		{
			get
			{
				return 184549376 + this.pathConstraintIndex;
			}
		}

		// Token: 0x170022F3 RID: 8947
		// (get) Token: 0x0601B0F6 RID: 110838 RVA: 0x00854244 File Offset: 0x00852644
		// (set) Token: 0x0601B0F7 RID: 110839 RVA: 0x0085424C File Offset: 0x0085264C
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

		// Token: 0x170022F4 RID: 8948
		// (get) Token: 0x0601B0F8 RID: 110840 RVA: 0x00854255 File Offset: 0x00852655
		// (set) Token: 0x0601B0F9 RID: 110841 RVA: 0x0085425D File Offset: 0x0085265D
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

		// Token: 0x0601B0FA RID: 110842 RVA: 0x00854266 File Offset: 0x00852666
		public void SetFrame(int frameIndex, float time, float value)
		{
			frameIndex *= 2;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = value;
		}

		// Token: 0x0601B0FB RID: 110843 RVA: 0x00854284 File Offset: 0x00852684
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			PathConstraint pathConstraint = skeleton.pathConstraints.Items[this.pathConstraintIndex];
			float[] array = this.frames;
			if (time >= array[0])
			{
				float num;
				if (time >= array[array.Length - 2])
				{
					num = array[array.Length + -1];
				}
				else
				{
					int num2 = Animation.BinarySearch(array, time, 2);
					num = array[num2 + -1];
					float num3 = array[num2];
					float curvePercent = base.GetCurvePercent(num2 / 2 - 1, 1f - (time - num3) / (array[num2 + -2] - num3));
					num += (array[num2 + 1] - num) * curvePercent;
				}
				if (pose == MixPose.Setup)
				{
					pathConstraint.position = pathConstraint.data.position + (num - pathConstraint.data.position) * alpha;
				}
				else
				{
					pathConstraint.position += (num - pathConstraint.position) * alpha;
				}
				return;
			}
			if (pose == MixPose.Setup)
			{
				pathConstraint.position = pathConstraint.data.position;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			pathConstraint.position += (pathConstraint.data.position - pathConstraint.position) * alpha;
		}

		// Token: 0x04012E0F RID: 77327
		public const int ENTRIES = 2;

		// Token: 0x04012E10 RID: 77328
		protected const int PREV_TIME = -2;

		// Token: 0x04012E11 RID: 77329
		protected const int PREV_VALUE = -1;

		// Token: 0x04012E12 RID: 77330
		protected const int VALUE = 1;

		// Token: 0x04012E13 RID: 77331
		internal int pathConstraintIndex;

		// Token: 0x04012E14 RID: 77332
		internal float[] frames;
	}
}
