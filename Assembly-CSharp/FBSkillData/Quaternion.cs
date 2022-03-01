using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B1A RID: 19226
	public sealed class Quaternion : Struct
	{
		// Token: 0x0601C09D RID: 114845 RVA: 0x0089052F File Offset: 0x0088E92F
		public Quaternion __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002673 RID: 9843
		// (get) Token: 0x0601C09E RID: 114846 RVA: 0x00890540 File Offset: 0x0088E940
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17002674 RID: 9844
		// (get) Token: 0x0601C09F RID: 114847 RVA: 0x00890553 File Offset: 0x0088E953
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17002675 RID: 9845
		// (get) Token: 0x0601C0A0 RID: 114848 RVA: 0x00890568 File Offset: 0x0088E968
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x17002676 RID: 9846
		// (get) Token: 0x0601C0A1 RID: 114849 RVA: 0x0089057D File Offset: 0x0088E97D
		public float W
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x0601C0A2 RID: 114850 RVA: 0x00890593 File Offset: 0x0088E993
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
