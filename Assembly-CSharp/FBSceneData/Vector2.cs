using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B07 RID: 19207
	public sealed class Vector2 : Struct
	{
		// Token: 0x0601BF19 RID: 114457 RVA: 0x0088D0EA File Offset: 0x0088B4EA
		public Vector2 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002604 RID: 9732
		// (get) Token: 0x0601BF1A RID: 114458 RVA: 0x0088D0FB File Offset: 0x0088B4FB
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17002605 RID: 9733
		// (get) Token: 0x0601BF1B RID: 114459 RVA: 0x0088D10E File Offset: 0x0088B50E
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x0601BF1C RID: 114460 RVA: 0x0088D123 File Offset: 0x0088B523
		public static Offset<Vector2> CreateVector2(FlatBufferBuilder builder, float X, float Y)
		{
			builder.Prep(4, 8);
			builder.PutFloat(Y);
			builder.PutFloat(X);
			return new Offset<Vector2>(builder.Offset);
		}
	}
}
