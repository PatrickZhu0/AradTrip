using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B09 RID: 19209
	public sealed class Quaternion : Struct
	{
		// Token: 0x0601BF24 RID: 114468 RVA: 0x0088D1CF File Offset: 0x0088B5CF
		public Quaternion __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002609 RID: 9737
		// (get) Token: 0x0601BF25 RID: 114469 RVA: 0x0088D1E0 File Offset: 0x0088B5E0
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x1700260A RID: 9738
		// (get) Token: 0x0601BF26 RID: 114470 RVA: 0x0088D1F3 File Offset: 0x0088B5F3
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x1700260B RID: 9739
		// (get) Token: 0x0601BF27 RID: 114471 RVA: 0x0088D208 File Offset: 0x0088B608
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x1700260C RID: 9740
		// (get) Token: 0x0601BF28 RID: 114472 RVA: 0x0088D21D File Offset: 0x0088B61D
		public float W
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x0601BF29 RID: 114473 RVA: 0x0088D233 File Offset: 0x0088B633
		public static Offset<Quaternion> CreateQuaternion(FlatBufferBuilder builder, float X, float Y, float Z, float W)
		{
			builder.Prep(4, 16);
			builder.PutFloat(W);
			builder.PutFloat(Z);
			builder.PutFloat(Y);
			builder.PutFloat(X);
			return new Offset<Quaternion>(builder.Offset);
		}
	}
}
