using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B2B RID: 19243
	public sealed class intValue : Table
	{
		// Token: 0x0601C20F RID: 115215 RVA: 0x00893106 File Offset: 0x00891506
		public static intValue GetRootAsintValue(ByteBuffer _bb)
		{
			return intValue.GetRootAsintValue(_bb, new intValue());
		}

		// Token: 0x0601C210 RID: 115216 RVA: 0x00893113 File Offset: 0x00891513
		public static intValue GetRootAsintValue(ByteBuffer _bb, intValue obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C211 RID: 115217 RVA: 0x0089312F File Offset: 0x0089152F
		public intValue __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F2 RID: 9970
		// (get) Token: 0x0601C212 RID: 115218 RVA: 0x00893140 File Offset: 0x00891540
		public int Value
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601C213 RID: 115219 RVA: 0x00893174 File Offset: 0x00891574
		public static Offset<intValue> CreateintValue(FlatBufferBuilder builder, int value = 0)
		{
			builder.StartObject(1);
			intValue.AddValue(builder, value);
			return intValue.EndintValue(builder);
		}

		// Token: 0x0601C214 RID: 115220 RVA: 0x0089318A File Offset: 0x0089158A
		public static void StartintValue(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C215 RID: 115221 RVA: 0x00893193 File Offset: 0x00891593
		public static void AddValue(FlatBufferBuilder builder, int value)
		{
			builder.AddInt(0, value, 0);
		}

		// Token: 0x0601C216 RID: 115222 RVA: 0x008931A0 File Offset: 0x008915A0
		public static Offset<intValue> EndintValue(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<intValue>(value);
		}
	}
}
