using System;

namespace Spine
{
	// Token: 0x020049B6 RID: 18870
	public class PathAttachment : VertexAttachment
	{
		// Token: 0x0601B1F6 RID: 111094 RVA: 0x00857A81 File Offset: 0x00855E81
		public PathAttachment(string name) : base(name)
		{
		}

		// Token: 0x17002331 RID: 9009
		// (get) Token: 0x0601B1F7 RID: 111095 RVA: 0x00857A8A File Offset: 0x00855E8A
		// (set) Token: 0x0601B1F8 RID: 111096 RVA: 0x00857A92 File Offset: 0x00855E92
		public float[] Lengths
		{
			get
			{
				return this.lengths;
			}
			set
			{
				this.lengths = value;
			}
		}

		// Token: 0x17002332 RID: 9010
		// (get) Token: 0x0601B1F9 RID: 111097 RVA: 0x00857A9B File Offset: 0x00855E9B
		// (set) Token: 0x0601B1FA RID: 111098 RVA: 0x00857AA3 File Offset: 0x00855EA3
		public bool Closed
		{
			get
			{
				return this.closed;
			}
			set
			{
				this.closed = value;
			}
		}

		// Token: 0x17002333 RID: 9011
		// (get) Token: 0x0601B1FB RID: 111099 RVA: 0x00857AAC File Offset: 0x00855EAC
		// (set) Token: 0x0601B1FC RID: 111100 RVA: 0x00857AB4 File Offset: 0x00855EB4
		public bool ConstantSpeed
		{
			get
			{
				return this.constantSpeed;
			}
			set
			{
				this.constantSpeed = value;
			}
		}

		// Token: 0x04012EC0 RID: 77504
		internal float[] lengths;

		// Token: 0x04012EC1 RID: 77505
		internal bool closed;

		// Token: 0x04012EC2 RID: 77506
		internal bool constantSpeed;
	}
}
