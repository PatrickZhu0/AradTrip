using System;

namespace Spine
{
	// Token: 0x0200498F RID: 18831
	public class ShearTimeline : TranslateTimeline
	{
		// Token: 0x0601B0A9 RID: 110761 RVA: 0x00852A7A File Offset: 0x00850E7A
		public ShearTimeline(int frameCount) : base(frameCount)
		{
		}

		// Token: 0x170022D3 RID: 8915
		// (get) Token: 0x0601B0AA RID: 110762 RVA: 0x00852A83 File Offset: 0x00850E83
		public override int PropertyId
		{
			get
			{
				return 50331648 + this.boneIndex;
			}
		}

		// Token: 0x0601B0AB RID: 110763 RVA: 0x00852A94 File Offset: 0x00850E94
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			Bone bone = skeleton.bones.Items[this.boneIndex];
			float[] frames = this.frames;
			if (time >= frames[0])
			{
				float num;
				float num2;
				if (time >= frames[frames.Length - 3])
				{
					num = frames[frames.Length + -2];
					num2 = frames[frames.Length + -1];
				}
				else
				{
					int num3 = Animation.BinarySearch(frames, time, 3);
					num = frames[num3 + -2];
					num2 = frames[num3 + -1];
					float num4 = frames[num3];
					float curvePercent = base.GetCurvePercent(num3 / 3 - 1, 1f - (time - num4) / (frames[num3 + -3] - num4));
					num += (frames[num3 + 1] - num) * curvePercent;
					num2 += (frames[num3 + 2] - num2) * curvePercent;
				}
				if (pose == MixPose.Setup)
				{
					bone.shearX = bone.data.shearX + num * alpha;
					bone.shearY = bone.data.shearY + num2 * alpha;
				}
				else
				{
					bone.shearX += (bone.data.shearX + num - bone.shearX) * alpha;
					bone.shearY += (bone.data.shearY + num2 - bone.shearY) * alpha;
				}
				return;
			}
			if (pose == MixPose.Setup)
			{
				bone.shearX = bone.data.shearX;
				bone.shearY = bone.data.shearY;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			bone.shearX += (bone.data.shearX - bone.shearX) * alpha;
			bone.shearY += (bone.data.shearY - bone.shearY) * alpha;
		}
	}
}
