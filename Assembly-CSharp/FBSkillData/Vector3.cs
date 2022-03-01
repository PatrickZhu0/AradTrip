using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B19 RID: 19225
	public sealed class Vector3 : Struct
	{
		// Token: 0x0601C097 RID: 114839 RVA: 0x008904AE File Offset: 0x0088E8AE
		public Vector3 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002670 RID: 9840
		// (get) Token: 0x0601C098 RID: 114840 RVA: 0x008904BF File Offset: 0x0088E8BF
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17002671 RID: 9841
		// (get) Token: 0x0601C099 RID: 114841 RVA: 0x008904D2 File Offset: 0x0088E8D2
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17002672 RID: 9842
		// (get) Token: 0x0601C09A RID: 114842 RVA: 0x008904E7 File Offset: 0x0088E8E7
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x0601C09B RID: 114843 RVA: 0x008904FC File Offset: 0x0088E8FC
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
