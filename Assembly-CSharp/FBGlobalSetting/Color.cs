using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000122 RID: 290
	public sealed class Color : Struct
	{
		// Token: 0x060006C2 RID: 1730 RVA: 0x00027FB6 File Offset: 0x000263B6
		public Color __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17000098 RID: 152
		// (get) Token: 0x060006C3 RID: 1731 RVA: 0x00027FC7 File Offset: 0x000263C7
		public float A
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17000099 RID: 153
		// (get) Token: 0x060006C4 RID: 1732 RVA: 0x00027FDA File Offset: 0x000263DA
		public float B
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x1700009A RID: 154
		// (get) Token: 0x060006C5 RID: 1733 RVA: 0x00027FEF File Offset: 0x000263EF
		public float G
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x1700009B RID: 155
		// (get) Token: 0x060006C6 RID: 1734 RVA: 0x00028004 File Offset: 0x00026404
		public float R
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x060006C7 RID: 1735 RVA: 0x0002801A File Offset: 0x0002641A
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
