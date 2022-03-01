using System;
using FlatBuffers;

namespace FBGlobalSetting
{
	// Token: 0x02000127 RID: 295
	public sealed class ShockData : Struct
	{
		// Token: 0x060006E9 RID: 1769 RVA: 0x00028676 File Offset: 0x00026A76
		public ShockData __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x060006EA RID: 1770 RVA: 0x00028687 File Offset: 0x00026A87
		public float Time
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x060006EB RID: 1771 RVA: 0x0002869A File Offset: 0x00026A9A
		public float Speed
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x170000AA RID: 170
		// (get) Token: 0x060006EC RID: 1772 RVA: 0x000286AF File Offset: 0x00026AAF
		public float Xrange
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x170000AB RID: 171
		// (get) Token: 0x060006ED RID: 1773 RVA: 0x000286C4 File Offset: 0x00026AC4
		public float Yrange
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x170000AC RID: 172
		// (get) Token: 0x060006EE RID: 1774 RVA: 0x000286DA File Offset: 0x00026ADA
		public int Mode
		{
			get
			{
				return this.bb.GetInt(this.bb_pos + 16);
			}
		}

		// Token: 0x060006EF RID: 1775 RVA: 0x000286F0 File Offset: 0x00026AF0
		public static Offset<ShockData> CreateShockData(FlatBufferBuilder builder, float Time, float Speed, float Xrange, float Yrange, int Mode)
		{
			builder.Prep(4, 20);
			builder.PutInt(Mode);
			builder.PutFloat(Yrange);
			builder.PutFloat(Xrange);
			builder.PutFloat(Speed);
			builder.PutFloat(Time);
			return new Offset<ShockData>(builder.Offset);
		}
	}
}
