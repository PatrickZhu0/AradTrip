using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B0A RID: 19210
	public sealed class Color : Struct
	{
		// Token: 0x0601BF2B RID: 114475 RVA: 0x0088D26E File Offset: 0x0088B66E
		public Color __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700260D RID: 9741
		// (get) Token: 0x0601BF2C RID: 114476 RVA: 0x0088D27F File Offset: 0x0088B67F
		public float R
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x1700260E RID: 9742
		// (get) Token: 0x0601BF2D RID: 114477 RVA: 0x0088D292 File Offset: 0x0088B692
		public float G
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x1700260F RID: 9743
		// (get) Token: 0x0601BF2E RID: 114478 RVA: 0x0088D2A7 File Offset: 0x0088B6A7
		public float B
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x17002610 RID: 9744
		// (get) Token: 0x0601BF2F RID: 114479 RVA: 0x0088D2BC File Offset: 0x0088B6BC
		public float A
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x0601BF30 RID: 114480 RVA: 0x0088D2D2 File Offset: 0x0088B6D2
		public static Offset<Color> CreateColor(FlatBufferBuilder builder, float R, float G, float B, float A)
		{
			builder.Prep(4, 16);
			builder.PutFloat(A);
			builder.PutFloat(B);
			builder.PutFloat(G);
			builder.PutFloat(R);
			return new Offset<Color>(builder.Offset);
		}
	}
}
