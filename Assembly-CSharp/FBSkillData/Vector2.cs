using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B18 RID: 19224
	public sealed class Vector2 : Struct
	{
		// Token: 0x0601C092 RID: 114834 RVA: 0x0089044A File Offset: 0x0088E84A
		public Vector2 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700266E RID: 9838
		// (get) Token: 0x0601C093 RID: 114835 RVA: 0x0089045B File Offset: 0x0088E85B
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x1700266F RID: 9839
		// (get) Token: 0x0601C094 RID: 114836 RVA: 0x0089046E File Offset: 0x0088E86E
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x0601C095 RID: 114837 RVA: 0x00890483 File Offset: 0x0088E883
		public static Offset<Vector2> CreateVector2(FlatBufferBuilder builder, float X, float Y)
		{
			builder.Prep(4, 8);
			builder.PutFloat(Y);
			builder.PutFloat(X);
			return new Offset<Vector2>(builder.Offset);
		}
	}
}
