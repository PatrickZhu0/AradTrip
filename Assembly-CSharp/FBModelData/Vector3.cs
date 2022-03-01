using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D5B RID: 3419
	public sealed class Vector3 : Struct
	{
		// Token: 0x06008AD0 RID: 35536 RVA: 0x00198A8B File Offset: 0x00196E8B
		public Vector3 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17001874 RID: 6260
		// (get) Token: 0x06008AD1 RID: 35537 RVA: 0x00198A9C File Offset: 0x00196E9C
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17001875 RID: 6261
		// (get) Token: 0x06008AD2 RID: 35538 RVA: 0x00198AAF File Offset: 0x00196EAF
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17001876 RID: 6262
		// (get) Token: 0x06008AD3 RID: 35539 RVA: 0x00198AC4 File Offset: 0x00196EC4
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x06008AD4 RID: 35540 RVA: 0x00198AD9 File Offset: 0x00196ED9
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
