using System;

namespace Spine
{
	// Token: 0x020049DD RID: 18909
	public class SlotData
	{
		// Token: 0x0601B439 RID: 111673 RVA: 0x008645B0 File Offset: 0x008629B0
		public SlotData(int index, string name, BoneData boneData)
		{
			if (index < 0)
			{
				throw new ArgumentException("index must be >= 0.", "index");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			if (boneData == null)
			{
				throw new ArgumentNullException("boneData", "boneData cannot be null.");
			}
			this.index = index;
			this.name = name;
			this.boneData = boneData;
		}

		// Token: 0x170023EF RID: 9199
		// (get) Token: 0x0601B43A RID: 111674 RVA: 0x00864647 File Offset: 0x00862A47
		public int Index
		{
			get
			{
				return this.index;
			}
		}

		// Token: 0x170023F0 RID: 9200
		// (get) Token: 0x0601B43B RID: 111675 RVA: 0x0086464F File Offset: 0x00862A4F
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170023F1 RID: 9201
		// (get) Token: 0x0601B43C RID: 111676 RVA: 0x00864657 File Offset: 0x00862A57
		public BoneData BoneData
		{
			get
			{
				return this.boneData;
			}
		}

		// Token: 0x170023F2 RID: 9202
		// (get) Token: 0x0601B43D RID: 111677 RVA: 0x0086465F File Offset: 0x00862A5F
		// (set) Token: 0x0601B43E RID: 111678 RVA: 0x00864667 File Offset: 0x00862A67
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

		// Token: 0x170023F3 RID: 9203
		// (get) Token: 0x0601B43F RID: 111679 RVA: 0x00864670 File Offset: 0x00862A70
		// (set) Token: 0x0601B440 RID: 111680 RVA: 0x00864678 File Offset: 0x00862A78
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

		// Token: 0x170023F4 RID: 9204
		// (get) Token: 0x0601B441 RID: 111681 RVA: 0x00864681 File Offset: 0x00862A81
		// (set) Token: 0x0601B442 RID: 111682 RVA: 0x00864689 File Offset: 0x00862A89
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

		// Token: 0x170023F5 RID: 9205
		// (get) Token: 0x0601B443 RID: 111683 RVA: 0x00864692 File Offset: 0x00862A92
		// (set) Token: 0x0601B444 RID: 111684 RVA: 0x0086469A File Offset: 0x00862A9A
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

		// Token: 0x170023F6 RID: 9206
		// (get) Token: 0x0601B445 RID: 111685 RVA: 0x008646A3 File Offset: 0x00862AA3
		// (set) Token: 0x0601B446 RID: 111686 RVA: 0x008646AB File Offset: 0x00862AAB
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

		// Token: 0x170023F7 RID: 9207
		// (get) Token: 0x0601B447 RID: 111687 RVA: 0x008646B4 File Offset: 0x00862AB4
		// (set) Token: 0x0601B448 RID: 111688 RVA: 0x008646BC File Offset: 0x00862ABC
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

		// Token: 0x170023F8 RID: 9208
		// (get) Token: 0x0601B449 RID: 111689 RVA: 0x008646C5 File Offset: 0x00862AC5
		// (set) Token: 0x0601B44A RID: 111690 RVA: 0x008646CD File Offset: 0x00862ACD
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

		// Token: 0x170023F9 RID: 9209
		// (get) Token: 0x0601B44B RID: 111691 RVA: 0x008646D6 File Offset: 0x00862AD6
		// (set) Token: 0x0601B44C RID: 111692 RVA: 0x008646DE File Offset: 0x00862ADE
		public bool HasSecondColor
		{
			get
			{
				return this.hasSecondColor;
			}
			set
			{
				this.hasSecondColor = value;
			}
		}

		// Token: 0x170023FA RID: 9210
		// (get) Token: 0x0601B44D RID: 111693 RVA: 0x008646E7 File Offset: 0x00862AE7
		// (set) Token: 0x0601B44E RID: 111694 RVA: 0x008646EF File Offset: 0x00862AEF
		public string AttachmentName
		{
			get
			{
				return this.attachmentName;
			}
			set
			{
				this.attachmentName = value;
			}
		}

		// Token: 0x170023FB RID: 9211
		// (get) Token: 0x0601B44F RID: 111695 RVA: 0x008646F8 File Offset: 0x00862AF8
		// (set) Token: 0x0601B450 RID: 111696 RVA: 0x00864700 File Offset: 0x00862B00
		public BlendMode BlendMode
		{
			get
			{
				return this.blendMode;
			}
			set
			{
				this.blendMode = value;
			}
		}

		// Token: 0x0601B451 RID: 111697 RVA: 0x00864709 File Offset: 0x00862B09
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x04012FE5 RID: 77797
		internal int index;

		// Token: 0x04012FE6 RID: 77798
		internal string name;

		// Token: 0x04012FE7 RID: 77799
		internal BoneData boneData;

		// Token: 0x04012FE8 RID: 77800
		internal float r = 1f;

		// Token: 0x04012FE9 RID: 77801
		internal float g = 1f;

		// Token: 0x04012FEA RID: 77802
		internal float b = 1f;

		// Token: 0x04012FEB RID: 77803
		internal float a = 1f;

		// Token: 0x04012FEC RID: 77804
		internal float r2;

		// Token: 0x04012FED RID: 77805
		internal float g2;

		// Token: 0x04012FEE RID: 77806
		internal float b2;

		// Token: 0x04012FEF RID: 77807
		internal bool hasSecondColor;

		// Token: 0x04012FF0 RID: 77808
		internal string attachmentName;

		// Token: 0x04012FF1 RID: 77809
		internal BlendMode blendMode;
	}
}
