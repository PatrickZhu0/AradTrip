using System;
using FlatBuffers;

namespace FBTransportDoorExtraData
{
	// Token: 0x02004B43 RID: 19267
	public sealed class Vector3 : Struct
	{
		// Token: 0x0601C4C8 RID: 115912 RVA: 0x0089AE14 File Offset: 0x00899214
		public Vector3 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170027CD RID: 10189
		// (get) Token: 0x0601C4C9 RID: 115913 RVA: 0x0089AE25 File Offset: 0x00899225
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x170027CE RID: 10190
		// (get) Token: 0x0601C4CA RID: 115914 RVA: 0x0089AE38 File Offset: 0x00899238
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x170027CF RID: 10191
		// (get) Token: 0x0601C4CB RID: 115915 RVA: 0x0089AE4D File Offset: 0x0089924D
		public float Z
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x0601C4CC RID: 115916 RVA: 0x0089AE62 File Offset: 0x00899262
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
