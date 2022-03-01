using System;

namespace Spine
{
	// Token: 0x020049CC RID: 18892
	public class PathConstraintData
	{
		// Token: 0x0601B342 RID: 111426 RVA: 0x0085C4BA File Offset: 0x0085A8BA
		public PathConstraintData(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		// Token: 0x170023A0 RID: 9120
		// (get) Token: 0x0601B343 RID: 111427 RVA: 0x0085C4EA File Offset: 0x0085A8EA
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x170023A1 RID: 9121
		// (get) Token: 0x0601B344 RID: 111428 RVA: 0x0085C4F2 File Offset: 0x0085A8F2
		// (set) Token: 0x0601B345 RID: 111429 RVA: 0x0085C4FA File Offset: 0x0085A8FA
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

		// Token: 0x170023A2 RID: 9122
		// (get) Token: 0x0601B346 RID: 111430 RVA: 0x0085C503 File Offset: 0x0085A903
		public ExposedList<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x170023A3 RID: 9123
		// (get) Token: 0x0601B347 RID: 111431 RVA: 0x0085C50B File Offset: 0x0085A90B
		// (set) Token: 0x0601B348 RID: 111432 RVA: 0x0085C513 File Offset: 0x0085A913
		public SlotData Target
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

		// Token: 0x170023A4 RID: 9124
		// (get) Token: 0x0601B349 RID: 111433 RVA: 0x0085C51C File Offset: 0x0085A91C
		// (set) Token: 0x0601B34A RID: 111434 RVA: 0x0085C524 File Offset: 0x0085A924
		public PositionMode PositionMode
		{
			get
			{
				return this.positionMode;
			}
			set
			{
				this.positionMode = value;
			}
		}

		// Token: 0x170023A5 RID: 9125
		// (get) Token: 0x0601B34B RID: 111435 RVA: 0x0085C52D File Offset: 0x0085A92D
		// (set) Token: 0x0601B34C RID: 111436 RVA: 0x0085C535 File Offset: 0x0085A935
		public SpacingMode SpacingMode
		{
			get
			{
				return this.spacingMode;
			}
			set
			{
				this.spacingMode = value;
			}
		}

		// Token: 0x170023A6 RID: 9126
		// (get) Token: 0x0601B34D RID: 111437 RVA: 0x0085C53E File Offset: 0x0085A93E
		// (set) Token: 0x0601B34E RID: 111438 RVA: 0x0085C546 File Offset: 0x0085A946
		public RotateMode RotateMode
		{
			get
			{
				return this.rotateMode;
			}
			set
			{
				this.rotateMode = value;
			}
		}

		// Token: 0x170023A7 RID: 9127
		// (get) Token: 0x0601B34F RID: 111439 RVA: 0x0085C54F File Offset: 0x0085A94F
		// (set) Token: 0x0601B350 RID: 111440 RVA: 0x0085C557 File Offset: 0x0085A957
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

		// Token: 0x170023A8 RID: 9128
		// (get) Token: 0x0601B351 RID: 111441 RVA: 0x0085C560 File Offset: 0x0085A960
		// (set) Token: 0x0601B352 RID: 111442 RVA: 0x0085C568 File Offset: 0x0085A968
		public float Position
		{
			get
			{
				return this.position;
			}
			set
			{
				this.position = value;
			}
		}

		// Token: 0x170023A9 RID: 9129
		// (get) Token: 0x0601B353 RID: 111443 RVA: 0x0085C571 File Offset: 0x0085A971
		// (set) Token: 0x0601B354 RID: 111444 RVA: 0x0085C579 File Offset: 0x0085A979
		public float Spacing
		{
			get
			{
				return this.spacing;
			}
			set
			{
				this.spacing = value;
			}
		}

		// Token: 0x170023AA RID: 9130
		// (get) Token: 0x0601B355 RID: 111445 RVA: 0x0085C582 File Offset: 0x0085A982
		// (set) Token: 0x0601B356 RID: 111446 RVA: 0x0085C58A File Offset: 0x0085A98A
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

		// Token: 0x170023AB RID: 9131
		// (get) Token: 0x0601B357 RID: 111447 RVA: 0x0085C593 File Offset: 0x0085A993
		// (set) Token: 0x0601B358 RID: 111448 RVA: 0x0085C59B File Offset: 0x0085A99B
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

		// Token: 0x0601B359 RID: 111449 RVA: 0x0085C5A4 File Offset: 0x0085A9A4
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x04012F6B RID: 77675
		internal string name;

		// Token: 0x04012F6C RID: 77676
		internal int order;

		// Token: 0x04012F6D RID: 77677
		internal ExposedList<BoneData> bones = new ExposedList<BoneData>();

		// Token: 0x04012F6E RID: 77678
		internal SlotData target;

		// Token: 0x04012F6F RID: 77679
		internal PositionMode positionMode;

		// Token: 0x04012F70 RID: 77680
		internal SpacingMode spacingMode;

		// Token: 0x04012F71 RID: 77681
		internal RotateMode rotateMode;

		// Token: 0x04012F72 RID: 77682
		internal float offsetRotation;

		// Token: 0x04012F73 RID: 77683
		internal float position;

		// Token: 0x04012F74 RID: 77684
		internal float spacing;

		// Token: 0x04012F75 RID: 77685
		internal float rotateMix;

		// Token: 0x04012F76 RID: 77686
		internal float translateMix;
	}
}
