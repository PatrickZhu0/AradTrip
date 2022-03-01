using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B20 RID: 19232
	public sealed class ShockInfo : Struct
	{
		// Token: 0x0601C10E RID: 114958 RVA: 0x00891222 File Offset: 0x0088F622
		public ShockInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002697 RID: 9879
		// (get) Token: 0x0601C10F RID: 114959 RVA: 0x00891233 File Offset: 0x0088F633
		public float ShockTime
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos);
			}
		}

		// Token: 0x17002698 RID: 9880
		// (get) Token: 0x0601C110 RID: 114960 RVA: 0x00891246 File Offset: 0x0088F646
		public float ShockSpeed
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 4);
			}
		}

		// Token: 0x17002699 RID: 9881
		// (get) Token: 0x0601C111 RID: 114961 RVA: 0x0089125B File Offset: 0x0088F65B
		public float ShockRangeX
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 8);
			}
		}

		// Token: 0x1700269A RID: 9882
		// (get) Token: 0x0601C112 RID: 114962 RVA: 0x00891270 File Offset: 0x0088F670
		public float ShockRangeY
		{
			get
			{
				return this.bb.GetFloat(this.bb_pos + 12);
			}
		}

		// Token: 0x0601C113 RID: 114963 RVA: 0x00891286 File Offset: 0x0088F686
		public static Offset<ShockInfo> CreateShockInfo(FlatBufferBuilder builder, float ShockTime, float ShockSpeed, float ShockRangeX, float ShockRangeY)
		{
			builder.Prep(4, 16);
			builder.PutFloat(ShockRangeY);
			builder.PutFloat(ShockRangeX);
			builder.PutFloat(ShockSpeed);
			builder.PutFloat(ShockTime);
			return new Offset<ShockInfo>(builder.Offset);
		}
	}
}
