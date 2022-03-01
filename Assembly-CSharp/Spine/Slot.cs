using System;

namespace Spine
{
	// Token: 0x020049DC RID: 18908
	public class Slot
	{
		// Token: 0x0601B41D RID: 111645 RVA: 0x0086436C File Offset: 0x0086276C
		public Slot(SlotData data, Bone bone)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data", "data cannot be null.");
			}
			if (bone == null)
			{
				throw new ArgumentNullException("bone", "bone cannot be null.");
			}
			this.data = data;
			this.bone = bone;
			this.SetToSetupPose();
		}

		// Token: 0x170023E1 RID: 9185
		// (get) Token: 0x0601B41E RID: 111646 RVA: 0x008643CA File Offset: 0x008627CA
		public SlotData Data
		{
			get
			{
				return this.data;
			}
		}

		// Token: 0x170023E2 RID: 9186
		// (get) Token: 0x0601B41F RID: 111647 RVA: 0x008643D2 File Offset: 0x008627D2
		public Bone Bone
		{
			get
			{
				return this.bone;
			}
		}

		// Token: 0x170023E3 RID: 9187
		// (get) Token: 0x0601B420 RID: 111648 RVA: 0x008643DA File Offset: 0x008627DA
		public Skeleton Skeleton
		{
			get
			{
				return this.bone.skeleton;
			}
		}

		// Token: 0x170023E4 RID: 9188
		// (get) Token: 0x0601B421 RID: 111649 RVA: 0x008643E7 File Offset: 0x008627E7
		// (set) Token: 0x0601B422 RID: 111650 RVA: 0x008643EF File Offset: 0x008627EF
		public float R
		{
			get
			{
				return this.r;
			}
			set
			{
				this.r = value;
			}
		}

		// Token: 0x170023E5 RID: 9189
		// (get) Token: 0x0601B423 RID: 111651 RVA: 0x008643F8 File Offset: 0x008627F8
		// (set) Token: 0x0601B424 RID: 111652 RVA: 0x00864400 File Offset: 0x00862800
		public float G
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x170023E6 RID: 9190
		// (get) Token: 0x0601B425 RID: 111653 RVA: 0x00864409 File Offset: 0x00862809
		// (set) Token: 0x0601B426 RID: 111654 RVA: 0x00864411 File Offset: 0x00862811
		public float B
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x170023E7 RID: 9191
		// (get) Token: 0x0601B427 RID: 111655 RVA: 0x0086441A File Offset: 0x0086281A
		// (set) Token: 0x0601B428 RID: 111656 RVA: 0x00864422 File Offset: 0x00862822
		public float A
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x170023E8 RID: 9192
		// (get) Token: 0x0601B429 RID: 111657 RVA: 0x0086442B File Offset: 0x0086282B
		// (set) Token: 0x0601B42A RID: 111658 RVA: 0x00864433 File Offset: 0x00862833
		public float R2
		{
			get
			{
				return this.r2;
			}
			set
			{
				this.r2 = value;
			}
		}

		// Token: 0x170023E9 RID: 9193
		// (get) Token: 0x0601B42B RID: 111659 RVA: 0x0086443C File Offset: 0x0086283C
		// (set) Token: 0x0601B42C RID: 111660 RVA: 0x00864444 File Offset: 0x00862844
		public float G2
		{
			get
			{
				return this.g2;
			}
			set
			{
				this.g2 = value;
			}
		}

		// Token: 0x170023EA RID: 9194
		// (get) Token: 0x0601B42D RID: 111661 RVA: 0x0086444D File Offset: 0x0086284D
		// (set) Token: 0x0601B42E RID: 111662 RVA: 0x00864455 File Offset: 0x00862855
		public float B2
		{
			get
			{
				return this.b2;
			}
			set
			{
				this.b2 = value;
			}
		}

		// Token: 0x170023EB RID: 9195
		// (get) Token: 0x0601B42F RID: 111663 RVA: 0x0086445E File Offset: 0x0086285E
		// (set) Token: 0x0601B430 RID: 111664 RVA: 0x0086446B File Offset: 0x0086286B
		public bool HasSecondColor
		{
			get
			{
				return this.data.hasSecondColor;
			}
			set
			{
				this.data.hasSecondColor = value;
			}
		}

		// Token: 0x170023EC RID: 9196
		// (get) Token: 0x0601B431 RID: 111665 RVA: 0x00864479 File Offset: 0x00862879
		// (set) Token: 0x0601B432 RID: 111666 RVA: 0x00864481 File Offset: 0x00862881
		public Attachment Attachment
		{
			get
			{
				return this.attachment;
			}
			set
			{
				if (this.attachment == value)
				{
					return;
				}
				this.attachment = value;
				this.attachmentTime = this.bone.skeleton.time;
				this.attachmentVertices.Clear(false);
			}
		}

		// Token: 0x170023ED RID: 9197
		// (get) Token: 0x0601B433 RID: 111667 RVA: 0x008644B9 File Offset: 0x008628B9
		// (set) Token: 0x0601B434 RID: 111668 RVA: 0x008644D2 File Offset: 0x008628D2
		public float AttachmentTime
		{
			get
			{
				return this.bone.skeleton.time - this.attachmentTime;
			}
			set
			{
				this.attachmentTime = this.bone.skeleton.time - value;
			}
		}

		// Token: 0x170023EE RID: 9198
		// (get) Token: 0x0601B435 RID: 111669 RVA: 0x008644EC File Offset: 0x008628EC
		// (set) Token: 0x0601B436 RID: 111670 RVA: 0x008644F4 File Offset: 0x008628F4
		public ExposedList<float> AttachmentVertices
		{
			get
			{
				return this.attachmentVertices;
			}
			set
			{
				this.attachmentVertices = value;
			}
		}

		// Token: 0x0601B437 RID: 111671 RVA: 0x00864500 File Offset: 0x00862900
		public void SetToSetupPose()
		{
			this.r = this.data.r;
			this.g = this.data.g;
			this.b = this.data.b;
			this.a = this.data.a;
			if (this.data.attachmentName == null)
			{
				this.Attachment = null;
			}
			else
			{
				this.attachment = null;
				this.Attachment = this.bone.skeleton.GetAttachment(this.data.index, this.data.attachmentName);
			}
		}

		// Token: 0x0601B438 RID: 111672 RVA: 0x008645A0 File Offset: 0x008629A0
		public override string ToString()
		{
			return this.data.name;
		}

		// Token: 0x04012FD8 RID: 77784
		internal SlotData data;

		// Token: 0x04012FD9 RID: 77785
		internal Bone bone;

		// Token: 0x04012FDA RID: 77786
		internal float r;

		// Token: 0x04012FDB RID: 77787
		internal float g;

		// Token: 0x04012FDC RID: 77788
		internal float b;

		// Token: 0x04012FDD RID: 77789
		internal float a;

		// Token: 0x04012FDE RID: 77790
		internal float r2;

		// Token: 0x04012FDF RID: 77791
		internal float g2;

		// Token: 0x04012FE0 RID: 77792
		internal float b2;

		// Token: 0x04012FE1 RID: 77793
		internal bool hasSecondColor;

		// Token: 0x04012FE2 RID: 77794
		internal Attachment attachment;

		// Token: 0x04012FE3 RID: 77795
		internal float attachmentTime;

		// Token: 0x04012FE4 RID: 77796
		internal ExposedList<float> attachmentVertices = new ExposedList<float>();
	}
}
