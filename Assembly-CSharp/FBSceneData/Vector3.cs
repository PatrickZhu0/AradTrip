using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B08 RID: 19208
	public sealed class Vector3 : Struct
	{
		// Token: 0x0601BF1E RID: 114462 RVA: 0x0088D14E File Offset: 0x0088B54E
		public Vector3 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002606 RID: 9734
		// (get) Token: 0x0601BF1F RID: 114463 RVA: 0x0088D15F File Offset: 0x0088B55F
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17002607 RID: 9735
		// (get) Token: 0x0601BF20 RID: 114464 RVA: 0x0088D172 File Offset: 0x0088B572
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17002608 RID: 9736
		// (get) Token: 0x0601BF21 RID: 114465 RVA: 0x0088D187 File Offset: 0x0088B587
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x0601BF22 RID: 114466 RVA: 0x0088D19C File Offset: 0x0088B59C
		public static Offset<Vector3> CreateVector3(FlatBufferBuilder builder, float X, float Y, float Z)
		{
			builder.Prep(4, 12);
			builder.PutFloat(Z);
			builder.PutFloat(Y);
			builder.PutFloat(X);
			return new Offset<Vector3>(builder.Offset);
		}
	}
}
