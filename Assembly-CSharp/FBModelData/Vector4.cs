using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D5C RID: 3420
	public sealed class Vector4 : Struct
	{
		// Token: 0x06008AD6 RID: 35542 RVA: 0x00198B0C File Offset: 0x00196F0C
		public Vector4 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17001877 RID: 6263
		// (get) Token: 0x06008AD7 RID: 35543 RVA: 0x00198B1D File Offset: 0x00196F1D
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17001878 RID: 6264
		// (get) Token: 0x06008AD8 RID: 35544 RVA: 0x00198B30 File Offset: 0x00196F30
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17001879 RID: 6265
		// (get) Token: 0x06008AD9 RID: 35545 RVA: 0x00198B45 File Offset: 0x00196F45
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x1700187A RID: 6266
		// (get) Token: 0x06008ADA RID: 35546 RVA: 0x00198B5A File Offset: 0x00196F5A
		public float W
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x06008ADB RID: 35547 RVA: 0x00198B70 File Offset: 0x00196F70
		public static Offset<Vector4> CreateVector4(FlatBufferBuilder builder, float X, float Y, float Z, float W)
		{
			builder.Prep(4, 16);
			builder.PutFloat(W);
			builder.PutFloat(Z);
			builder.PutFloat(Y);
			builder.PutFloat(X);
			return new Offset<Vector4>(builder.Offset);
		}
	}
}
