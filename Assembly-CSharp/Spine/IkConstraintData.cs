using System;
using System.Collections.Generic;

namespace Spine
{
	// Token: 0x020049C5 RID: 18885
	public class IkConstraintData
	{
		// Token: 0x0601B2FE RID: 111358 RVA: 0x0085A7D4 File Offset: 0x00858BD4
		public IkConstraintData(string name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name", "name cannot be null.");
			}
			this.name = name;
		}

		// Token: 0x1700238D RID: 9101
		// (get) Token: 0x0601B2FF RID: 111359 RVA: 0x0085A821 File Offset: 0x00858C21
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x1700238E RID: 9102
		// (get) Token: 0x0601B300 RID: 111360 RVA: 0x0085A829 File Offset: 0x00858C29
		// (set) Token: 0x0601B301 RID: 111361 RVA: 0x0085A831 File Offset: 0x00858C31
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

		// Token: 0x1700238F RID: 9103
		// (get) Token: 0x0601B302 RID: 111362 RVA: 0x0085A83A File Offset: 0x00858C3A
		public List<BoneData> Bones
		{
			get
			{
				return this.bones;
			}
		}

		// Token: 0x17002390 RID: 9104
		// (get) Token: 0x0601B303 RID: 111363 RVA: 0x0085A842 File Offset: 0x00858C42
		// (set) Token: 0x0601B304 RID: 111364 RVA: 0x0085A84A File Offset: 0x00858C4A
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

		// Token: 0x17002391 RID: 9105
		// (get) Token: 0x0601B305 RID: 111365 RVA: 0x0085A853 File Offset: 0x00858C53
		// (set) Token: 0x0601B306 RID: 111366 RVA: 0x0085A85B File Offset: 0x00858C5B
		public int BendDirection
		{
			get
			{
				return this.bendDirection;
			}
			set
			{
				this.bendDirection = value;
			}
		}

		// Token: 0x17002392 RID: 9106
		// (get) Token: 0x0601B307 RID: 111367 RVA: 0x0085A864 File Offset: 0x00858C64
		// (set) Token: 0x0601B308 RID: 111368 RVA: 0x0085A86C File Offset: 0x00858C6C
		public float Mix
		{
			get
			{
				return this.mix;
			}
			set
			{
				this.mix = value;
			}
		}

		// Token: 0x0601B309 RID: 111369 RVA: 0x0085A875 File Offset: 0x00858C75
		public override string ToString()
		{
			return this.name;
		}

		// Token: 0x04012F32 RID: 77618
		internal string name;

		// Token: 0x04012F33 RID: 77619
		internal int order;

		// Token: 0x04012F34 RID: 77620
		internal List<BoneData> bones = new List<BoneData>();

		// Token: 0x04012F35 RID: 77621
		internal BoneData target;

		// Token: 0x04012F36 RID: 77622
		internal int bendDirection = 1;

		// Token: 0x04012F37 RID: 77623
		internal float mix = 1f;
	}
}
