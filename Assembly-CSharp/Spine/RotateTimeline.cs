using System;

namespace Spine
{
	// Token: 0x0200498C RID: 18828
	public class RotateTimeline : CurveTimeline
	{
		// Token: 0x0601B096 RID: 110742 RVA: 0x0085232C File Offset: 0x0085072C
		public RotateTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount << 1];
		}

		// Token: 0x170022CC RID: 8908
		// (get) Token: 0x0601B097 RID: 110743 RVA: 0x00852343 File Offset: 0x00850743
		// (set) Token: 0x0601B098 RID: 110744 RVA: 0x0085234B File Offset: 0x0085074B
		public int BoneIndex
		{
			get
			{
				return this.boneIndex;
			}
			set
			{
				this.boneIndex = value;
			}
		}

		// Token: 0x170022CD RID: 8909
		// (get) Token: 0x0601B099 RID: 110745 RVA: 0x00852354 File Offset: 0x00850754
		// (set) Token: 0x0601B09A RID: 110746 RVA: 0x0085235C File Offset: 0x0085075C
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

		// Token: 0x170022CE RID: 8910
		// (get) Token: 0x0601B09B RID: 110747 RVA: 0x00852365 File Offset: 0x00850765
		public override int PropertyId
		{
			get
			{
				return this.boneIndex;
			}
		}

		// Token: 0x0601B09C RID: 110748 RVA: 0x0085236D File Offset: 0x0085076D
		public void SetFrame(int frameIndex, float time, float degrees)
		{
			frameIndex <<= 1;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = degrees;
		}

		// Token: 0x0601B09D RID: 110749 RVA: 0x00852388 File Offset: 0x00850788
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			Bone bone = skeleton.bones.Items[this.boneIndex];
			float[] array = this.frames;
			if (time < array[0])
			{
				if (pose == MixPose.Setup)
				{
					bone.rotation = bone.data.rotation;
					return;
				}
				if (pose != MixPose.Current)
				{
					return;
				}
				float num = bone.data.rotation - bone.rotation;
				num -= (float)((16384 - (int)(16384.499999999996 - (double)(num / 360f))) * 360);
				bone.rotation += num * alpha;
				return;
			}
			else
			{
				if (time >= array[array.Length - 2])
				{
					if (pose == MixPose.Setup)
					{
						bone.rotation = bone.data.rotation + array[array.Length + -1] * alpha;
					}
					else
					{
						float num2 = bone.data.rotation + array[array.Length + -1] - bone.rotation;
						num2 -= (float)((16384 - (int)(16384.499999999996 - (double)(num2 / 360f))) * 360);
						bone.rotation += num2 * alpha;
					}
					return;
				}
				int num3 = Animation.BinarySearch(array, time, 2);
				float num4 = array[num3 + -1];
				float num5 = array[num3];
				float curvePercent = base.GetCurvePercent((num3 >> 1) - 1, 1f - (time - num5) / (array[num3 + -2] - num5));
				float num6 = array[num3 + 1] - num4;
				num6 -= (float)((16384 - (int)(16384.499999999996 - (double)(num6 / 360f))) * 360);
				num6 = num4 + num6 * curvePercent;
				if (pose == MixPose.Setup)
				{
					num6 -= (float)((16384 - (int)(16384.499999999996 - (double)(num6 / 360f))) * 360);
					bone.rotation = bone.data.rotation + num6 * alpha;
				}
				else
				{
					num6 = bone.data.rotation + num6 - bone.rotation;
					num6 -= (float)((16384 - (int)(16384.499999999996 - (double)(num6 / 360f))) * 360);
					bone.rotation += num6 * alpha;
				}
				return;
			}
		}

		// Token: 0x04012DC4 RID: 77252
		public const int ENTRIES = 2;

		// Token: 0x04012DC5 RID: 77253
		internal const int PREV_TIME = -2;

		// Token: 0x04012DC6 RID: 77254
		internal const int PREV_ROTATION = -1;

		// Token: 0x04012DC7 RID: 77255
		internal const int ROTATION = 1;

		// Token: 0x04012DC8 RID: 77256
		internal int boneIndex;

		// Token: 0x04012DC9 RID: 77257
		internal float[] frames;
	}
}
