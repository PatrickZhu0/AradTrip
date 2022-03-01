using System;

namespace Spine
{
	// Token: 0x0200498D RID: 18829
	public class TranslateTimeline : CurveTimeline
	{
		// Token: 0x0601B09E RID: 110750 RVA: 0x008525BA File Offset: 0x008509BA
		public TranslateTimeline(int frameCount) : base(frameCount)
		{
			this.frames = new float[frameCount * 3];
		}

		// Token: 0x170022CF RID: 8911
		// (get) Token: 0x0601B09F RID: 110751 RVA: 0x008525D1 File Offset: 0x008509D1
		// (set) Token: 0x0601B0A0 RID: 110752 RVA: 0x008525D9 File Offset: 0x008509D9
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

		// Token: 0x170022D0 RID: 8912
		// (get) Token: 0x0601B0A1 RID: 110753 RVA: 0x008525E2 File Offset: 0x008509E2
		// (set) Token: 0x0601B0A2 RID: 110754 RVA: 0x008525EA File Offset: 0x008509EA
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

		// Token: 0x170022D1 RID: 8913
		// (get) Token: 0x0601B0A3 RID: 110755 RVA: 0x008525F3 File Offset: 0x008509F3
		public override int PropertyId
		{
			get
			{
				return 16777216 + this.boneIndex;
			}
		}

		// Token: 0x0601B0A4 RID: 110756 RVA: 0x00852601 File Offset: 0x00850A01
		public void SetFrame(int frameIndex, float time, float x, float y)
		{
			frameIndex *= 3;
			this.frames[frameIndex] = time;
			this.frames[frameIndex + 1] = x;
			this.frames[frameIndex + 2] = y;
		}

		// Token: 0x0601B0A5 RID: 110757 RVA: 0x00852628 File Offset: 0x00850A28
		public override void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			Bone bone = skeleton.bones.Items[this.boneIndex];
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
					bone.x = bone.data.x + num * alpha;
					bone.y = bone.data.y + num2 * alpha;
				}
				else
				{
					bone.x += (bone.data.x + num - bone.x) * alpha;
					bone.y += (bone.data.y + num2 - bone.y) * alpha;
				}
				return;
			}
			if (pose == MixPose.Setup)
			{
				bone.x = bone.data.x;
				bone.y = bone.data.y;
				return;
			}
			if (pose != MixPose.Current)
			{
				return;
			}
			bone.x += (bone.data.x - bone.x) * alpha;
			bone.y += (bone.data.y - bone.y) * alpha;
		}

		// Token: 0x04012DCA RID: 77258
		public const int ENTRIES = 3;

		// Token: 0x04012DCB RID: 77259
		protected const int PREV_TIME = -3;

		// Token: 0x04012DCC RID: 77260
		protected const int PREV_X = -2;

		// Token: 0x04012DCD RID: 77261
		protected const int PREV_Y = -1;

		// Token: 0x04012DCE RID: 77262
		protected const int X = 1;

		// Token: 0x04012DCF RID: 77263
		protected const int Y = 2;

		// Token: 0x04012DD0 RID: 77264
		internal int boneIndex;

		// Token: 0x04012DD1 RID: 77265
		internal float[] frames;
	}
}
