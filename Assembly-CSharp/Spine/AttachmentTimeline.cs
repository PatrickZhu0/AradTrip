using System;

namespace Spine
{
	// Token: 0x02004992 RID: 18834
	public class AttachmentTimeline : Timeline
	{
		// Token: 0x0601B0BB RID: 110779 RVA: 0x0085341E File Offset: 0x0085181E
		public AttachmentTimeline(int frameCount)
		{
			this.frames = new float[frameCount];
			this.attachmentNames = new string[frameCount];
		}

		// Token: 0x170022DA RID: 8922
		// (get) Token: 0x0601B0BC RID: 110780 RVA: 0x0085343E File Offset: 0x0085183E
		// (set) Token: 0x0601B0BD RID: 110781 RVA: 0x00853446 File Offset: 0x00851846
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

		// Token: 0x170022DB RID: 8923
		// (get) Token: 0x0601B0BE RID: 110782 RVA: 0x0085344F File Offset: 0x0085184F
		// (set) Token: 0x0601B0BF RID: 110783 RVA: 0x00853457 File Offset: 0x00851857
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

		// Token: 0x170022DC RID: 8924
		// (get) Token: 0x0601B0C0 RID: 110784 RVA: 0x00853460 File Offset: 0x00851860
		// (set) Token: 0x0601B0C1 RID: 110785 RVA: 0x00853468 File Offset: 0x00851868
		public string[] AttachmentNames
		{
			get
			{
				return this.attachmentNames;
			}
			set
			{
				this.attachmentNames = value;
			}
		}

		// Token: 0x170022DD RID: 8925
		// (get) Token: 0x0601B0C2 RID: 110786 RVA: 0x00853471 File Offset: 0x00851871
		public int FrameCount
		{
			get
			{
				return this.frames.Length;
			}
		}

		// Token: 0x170022DE RID: 8926
		// (get) Token: 0x0601B0C3 RID: 110787 RVA: 0x0085347B File Offset: 0x0085187B
		public int PropertyId
		{
			get
			{
				return 67108864 + this.slotIndex;
			}
		}

		// Token: 0x0601B0C4 RID: 110788 RVA: 0x00853489 File Offset: 0x00851889
		public void SetFrame(int frameIndex, float time, string attachmentName)
		{
			this.frames[frameIndex] = time;
			this.attachmentNames[frameIndex] = attachmentName;
		}

		// Token: 0x0601B0C5 RID: 110789 RVA: 0x008534A0 File Offset: 0x008518A0
		public void Apply(Skeleton skeleton, float lastTime, float time, ExposedList<Event> firedEvents, float alpha, MixPose pose, MixDirection direction)
		{
			Slot slot = skeleton.slots.Items[this.slotIndex];
			string text;
			if (direction == MixDirection.Out && pose == MixPose.Setup)
			{
				text = slot.data.attachmentName;
				slot.Attachment = ((text != null) ? skeleton.GetAttachment(this.slotIndex, text) : null);
				return;
			}
			float[] array = this.frames;
			if (time < array[0])
			{
				if (pose == MixPose.Setup)
				{
					text = slot.data.attachmentName;
					slot.Attachment = ((text != null) ? skeleton.GetAttachment(this.slotIndex, text) : null);
				}
				return;
			}
			int num;
			if (time >= array[array.Length - 1])
			{
				num = array.Length - 1;
			}
			else
			{
				num = Animation.BinarySearch(array, time, 1) - 1;
			}
			text = this.attachmentNames[num];
			slot.Attachment = ((text != null) ? skeleton.GetAttachment(this.slotIndex, text) : null);
		}

		// Token: 0x04012DF0 RID: 77296
		internal int slotIndex;

		// Token: 0x04012DF1 RID: 77297
		internal float[] frames;

		// Token: 0x04012DF2 RID: 77298
		internal string[] attachmentNames;
	}
}
