using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000124 RID: 292
	public sealed class Vector3 : Struct
	{
		// Token: 0x060006CE RID: 1742 RVA: 0x000280B9 File Offset: 0x000264B9
		public Vector3 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700009E RID: 158
		// (get) Token: 0x060006CF RID: 1743 RVA: 0x000280CA File Offset: 0x000264CA
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x1700009F RID: 159
		// (get) Token: 0x060006D0 RID: 1744 RVA: 0x000280DD File Offset: 0x000264DD
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x060006D1 RID: 1745 RVA: 0x000280F2 File Offset: 0x000264F2
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x060006D2 RID: 1746 RVA: 0x00028107 File Offset: 0x00026507
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
