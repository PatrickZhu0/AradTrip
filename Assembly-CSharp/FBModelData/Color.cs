using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D5A RID: 3418
	public sealed class Color : Struct
	{
		// Token: 0x06008AC9 RID: 35529 RVA: 0x001989EC File Offset: 0x00196DEC
		public Color __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17001870 RID: 6256
		// (get) Token: 0x06008ACA RID: 35530 RVA: 0x001989FD File Offset: 0x00196DFD
		public float A
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17001871 RID: 6257
		// (get) Token: 0x06008ACB RID: 35531 RVA: 0x00198A10 File Offset: 0x00196E10
		public float B
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17001872 RID: 6258
		// (get) Token: 0x06008ACC RID: 35532 RVA: 0x00198A25 File Offset: 0x00196E25
		public float G
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x17001873 RID: 6259
		// (get) Token: 0x06008ACD RID: 35533 RVA: 0x00198A3A File Offset: 0x00196E3A
		public float R
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x06008ACE RID: 35534 RVA: 0x00198A50 File Offset: 0x00196E50
		public static Offset<Color> CreateColor(FlatBufferBuilder builder, float A, float B, float G, float R)
		{
			builder.Prep(4, 16);
			builder.PutFloat(R);
			builder.PutFloat(G);
			builder.PutFloat(B);
			builder.PutFloat(A);
			return new Offset<Color>(builder.Offset);
		}
	}
}
