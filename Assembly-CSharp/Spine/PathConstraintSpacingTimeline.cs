using System;

namespace Spine
{
	// Token: 0x02004999 RID: 18841
	public class PathConstraintSpacingTimeline : PathConstraintPositionTimeline
	{
		// Token: 0x0601B0FC RID: 110844 RVA: 0x008543A0 File Offset: 0x008527A0
		public PathConstraintSpacingTimeline(int frameCount) : base(frameCount)
		{
		}

		// Token: 0x170022F5 RID: 8949
		// (get) Token: 0x0601B0FD RID: 110845 RVA: 0x008543A9 File Offset: 0x008527A9
		public override int PropertyId
		{
			get
			{
				return 201326592 + this.pathConstraintIndex;
			}
		}

		// Token: 0x0601B0FE RID: 110846 RVA: 0x008543B8 File Offset: 0x008527B8
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			PathConstraint pathConstraint = skeleton.pathConstraints.Items[this.pathConstraintIndex];
			float[] frames = this.frames;
			if (time >= frames[0])
			{
				float num;
				if (time >= frames[frames.Length - 2])
				{
					num = frames[frames.Length + -1];
				}
				else
				{
					int num2 = Animation.BinarySearch(frames, time, 2);
					num = frames[num2 + -1];
					float num3 = frames[num2];
					float curvePercent = base.GetCurvePercent(num2 / 2 - 1, 1f - (time - num3) / (frames[num2 + -2] - num3));
					num += (frames[num2 + 1] - num) * curvePercent;
				}
				if (pose == MixPose.Setup)
				{
					pathConstraint.spacing = pathConstraint.data.spacing + (num - pathConstraint.data.spacing) * alpha;
				}
				else
				{
					pathConstraint.spacing += (num - pathConstraint.spacing) * alpha;
				}
				return;
			}
			if (pose == MixPose.Setup)
			{
				pathConstraint.spacing = pathConstraint.data.spacing;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			pathConstraint.spacing += (pathConstraint.data.spacing - pathConstraint.spacing) * alpha;
		}
	}
}
