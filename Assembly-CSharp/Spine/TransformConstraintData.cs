using System;

namespace Spine
{
	// Token: 0x020049DF RID: 18911
	public class TransformConstraintData
	{
		// Token: 0x0601B467 RID: 111719 RVA: 0x00865460 File Offset: 0x00863860
		public TransformConstraintData(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		// Token: 0x17002404 RID: 9220
		// (get) Token: 0x0601B468 RID: 111720 RVA: 0x00865490 File Offset: 0x00863890
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17002405 RID: 9221
		// (get) Token: 0x0601B469 RID: 111721 RVA: 0x00865498 File Offset: 0x00863898
		// (set) Token: 0x0601B46A RID: 111722 RVA: 0x008654A0 File Offset: 0x008638A0
		public int Order
		{
			get
			{
				return this.order;
			}
			set
			{
				this.order = value;
			}
		}

		// Token: 0x17002406 RID: 9222
		// (get) Token: 0x0601B46B RID: 111723 RVA: 0x008654A9 File Offset: 0x008638A9
		public ExposedList<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x17002407 RID: 9223
		// (get) Token: 0x0601B46C RID: 111724 RVA: 0x008654B1 File Offset: 0x008638B1
		// (set) Token: 0x0601B46D RID: 111725 RVA: 0x008654B9 File Offset: 0x008638B9
		public BoneData Target
		{
			get
			{
				return this.target;
			}
			set
			{
				this.target = value;
			}
		}

		// Token: 0x17002408 RID: 9224
		// (get) Token: 0x0601B46E RID: 111726 RVA: 0x008654C2 File Offset: 0x008638C2
		// (set) Token: 0x0601B46F RID: 111727 RVA: 0x008654CA File Offset: 0x008638CA
		public float RotateMix
		{
			get
			{
				return this.rotateMix;
			}
			set
			{
				this.rotateMix = value;
			}
		}

		// Token: 0x17002409 RID: 9225
		// (get) Token: 0x0601B470 RID: 111728 RVA: 0x008654D3 File Offset: 0x008638D3
		// (set) Token: 0x0601B471 RID: 111729 RVA: 0x008654DB File Offset: 0x008638DB
		public float TranslateMix
		{
			get
			{
				return this.translateMix;
			}
			set
			{
				this.translateMix = value;
			}
		}

		// Token: 0x1700240A RID: 9226
		// (get) Token: 0x0601B472 RID: 111730 RVA: 0x008654E4 File Offset: 0x008638E4
		// (set) Token: 0x0601B473 RID: 111731 RVA: 0x008654EC File Offset: 0x008638EC
		public float ScaleMix
		{
			get
			{
				return this.scaleMix;
			}
			set
			{
				this.scaleMix = value;
			}
		}

		// Token: 0x1700240B RID: 9227
		// (get) Token: 0x0601B474 RID: 111732 RVA: 0x008654F5 File Offset: 0x008638F5
		// (set) Token: 0x0601B475 RID: 111733 RVA: 0x008654FD File Offset: 0x008638FD
		public float ShearMix
		{
			get
			{
				return this.shearMix;
			}
			set
			{
				this.shearMix = value;
			}
		}

		// Token: 0x1700240C RID: 9228
		// (get) Token: 0x0601B476 RID: 111734 RVA: 0x00865506 File Offset: 0x00863906
		// (set) Token: 0x0601B477 RID: 111735 RVA: 0x0086550E File Offset: 0x0086390E
		public float OffsetRotation
		{
			get
			{
				return this.offsetRotation;
			}
			set
			{
				this.offsetRotation = value;
			}
		}

		// Token: 0x1700240D RID: 9229
		// (get) Token: 0x0601B478 RID: 111736 RVA: 0x00865517 File Offset: 0x00863917
		// (set) Token: 0x0601B479 RID: 111737 RVA: 0x0086551F File Offset: 0x0086391F
		public float OffsetX
		{
			get
			{
				return this.offsetX;
			}
			set
			{
				this.offsetX = value;
			}
		}

		// Token: 0x1700240E RID: 9230
		// (get) Token: 0x0601B47A RID: 111738 RVA: 0x00865528 File Offset: 0x00863928
		// (set) Token: 0x0601B47B RID: 111739 RVA: 0x00865530 File Offset: 0x00863930
		public float OffsetY
		{
			get
			{
				return this.offsetY;
			}
			set
			{
				this.offsetY = value;
			}
		}

		// Token: 0x1700240F RID: 9231
		// (get) Token: 0x0601B47C RID: 111740 RVA: 0x00865539 File Offset: 0x00863939
		// (set) Token: 0x0601B47D RID: 111741 RVA: 0x00865541 File Offset: 0x00863941
		public float OffsetScaleX
		{
			get
			{
				return this.offsetScaleX;
			}
			set
			{
				this.offsetScaleX = value;
			}
		}

		// Token: 0x17002410 RID: 9232
		// (get) Token: 0x0601B47E RID: 111742 RVA: 0x0086554A File Offset: 0x0086394A
		// (set) Token: 0x0601B47F RID: 111743 RVA: 0x00865552 File Offset: 0x00863952
		public float OffsetScaleY
		{
			get
			{
				return this.offsetScaleY;
			}
			set
			{
				this.offsetScaleY = value;
			}
		}

		// Token: 0x17002411 RID: 9233
		// (get) Token: 0x0601B480 RID: 111744 RVA: 0x0086555B File Offset: 0x0086395B
		// (set) Token: 0x0601B481 RID: 111745 RVA: 0x00865563 File Offset: 0x00863963
		public float OffsetShearY
		{
			get
			{
				return this.offsetShearY;
			}
			set
			{
				this.offsetShearY = value;
			}
		}

		// Token: 0x17002412 RID: 9234
		// (get) Token: 0x0601B482 RID: 111746 RVA: 0x0086556C File Offset: 0x0086396C
		// (set) Token: 0x0601B483 RID: 111747 RVA: 0x00865574 File Offset: 0x00863974
		public bool Relative
		{
			get
			{
				return this.relative;
			}
			set
			{
				this.relative = value;
			}
		}

		// Token: 0x17002413 RID: 9235
		// (get) Token: 0x0601B484 RID: 111748 RVA: 0x0086557D File Offset: 0x0086397D
		// (set) Token: 0x0601B485 RID: 111749 RVA: 0x00865585 File Offset: 0x00863985
		public bool Local
		{
			get
			{
				return this.local;
			}
			set
			{
				this.local = value;
			}
		}

		// Token: 0x0601B486 RID: 111750 RVA: 0x0086558E File Offset: 0x0086398E
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x04012FF9 RID: 77817
		internal string name;

		// Token: 0x04012FFA RID: 77818
		internal int order;

		// Token: 0x04012FFB RID: 77819
		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		// Token: 0x04012FFC RID: 77820
		internal BoneData target;

		// Token: 0x04012FFD RID: 77821
		internal float rotateMix;

		// Token: 0x04012FFE RID: 77822
		internal float translateMix;

		// Token: 0x04012FFF RID: 77823
		internal float scaleMix;

		// Token: 0x04013000 RID: 77824
		internal float shearMix;

		// Token: 0x04013001 RID: 77825
		internal float offsetRotation;

		// Token: 0x04013002 RID: 77826
		internal float offsetX;

		// Token: 0x04013003 RID: 77827
		internal float offsetY;

		// Token: 0x04013004 RID: 77828
		internal float offsetScaleX;

		// Token: 0x04013005 RID: 77829
		internal float offsetScaleY;

		// Token: 0x04013006 RID: 77830
		internal float offsetShearY;

		// Token: 0x04013007 RID: 77831
		internal bool relative;

		// Token: 0x04013008 RID: 77832
		internal bool local;
	}
}
