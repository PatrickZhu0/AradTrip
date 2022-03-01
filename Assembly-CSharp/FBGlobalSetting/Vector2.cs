using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000123 RID: 291
	public sealed class Vector2 : Struct
	{
		// Token: 0x060006C9 RID: 1737 RVA: 0x00028055 File Offset: 0x00026455
		public Vector2 __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700009C RID: 156
		// (get) Token: 0x060006CA RID: 1738 RVA: 0x00028066 File Offset: 0x00026466
		public float X
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x1700009D RID: 157
		// (get) Token: 0x060006CB RID: 1739 RVA: 0x00028079 File Offset: 0x00026479
		public float Y
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x060006CC RID: 1740 RVA: 0x0002808E File Offset: 0x0002648E
		public static Offset<Vector2> CreateVector2(FlatBufferBuilder builder, float X, float Y)
		{
			builder.Prep(4, 8);
			builder.PutFloat(Y);
			builder.PutFloat(X);
			return new Offset<Vector2>(builder.Offset);
		}
	}
}
