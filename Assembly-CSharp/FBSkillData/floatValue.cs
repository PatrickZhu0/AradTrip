using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B2A RID: 19242
	public sealed class floatValue : Table
	{
		// Token: 0x0601C206 RID: 115206 RVA: 0x0089303E File Offset: 0x0089143E
		public static floatValue GetRootAsfloatValue(ByteBuffer _bb)
		{
			return floatValue.GetRootAsfloatValue(_bb, new floatValue());
		}

		// Token: 0x0601C207 RID: 115207 RVA: 0x0089304B File Offset: 0x0089144B
		public static floatValue GetRootAsfloatValue(ByteBuffer _bb, floatValue obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C208 RID: 115208 RVA: 0x00893067 File Offset: 0x00891467
		public floatValue __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F1 RID: 9969
		// (get) Token: 0x0601C209 RID: 115209 RVA: 0x00893078 File Offset: 0x00891478
		public float Value
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x0601C20A RID: 115210 RVA: 0x008930B0 File Offset: 0x008914B0
		public static Offset<floatValue> CreatefloatValue(FlatBufferBuilder builder, float value = 0f)
		{
			builder.StartObject(1);
			floatValue.AddValue(builder, value);
			return floatValue.EndfloatValue(builder);
		}

		// Token: 0x0601C20B RID: 115211 RVA: 0x008930C6 File Offset: 0x008914C6
		public static void StartfloatValue(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C20C RID: 115212 RVA: 0x008930CF File Offset: 0x008914CF
		public static void AddValue(FlatBufferBuilder builder, float value)
		{
			builder.AddFloat(0, value, 0.0);
		}

		// Token: 0x0601C20D RID: 115213 RVA: 0x008930E4 File Offset: 0x008914E4
		public static Offset<floatValue> EndfloatValue(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<floatValue>(value);
		}
	}
}
