using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B29 RID: 19241
	public sealed class boolValue : Table
	{
		// Token: 0x0601C1FD RID: 115197 RVA: 0x00892F7E File Offset: 0x0089137E
		public static boolValue GetRootAsboolValue(ByteBuffer _bb)
		{
			return boolValue.GetRootAsboolValue(_bb, new boolValue());
		}

		// Token: 0x0601C1FE RID: 115198 RVA: 0x00892F8B File Offset: 0x0089138B
		public static boolValue GetRootAsboolValue(ByteBuffer _bb, boolValue obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C1FF RID: 115199 RVA: 0x00892FA7 File Offset: 0x008913A7
		public boolValue __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F0 RID: 9968
		// (get) Token: 0x0601C200 RID: 115200 RVA: 0x00892FB8 File Offset: 0x008913B8
		public bool Value
		{
			get
			{
				int num = base.__offset(4);
				return num != 0 && 0 != this.bb.Get(num + this.bb_pos);
			}
		}

		// Token: 0x0601C201 RID: 115201 RVA: 0x00892FF2 File Offset: 0x008913F2
		public static Offset<boolValue> CreateboolValue(FlatBufferBuilder builder, bool value = false)
		{
			builder.StartObject(1);
			boolValue.AddValue(builder, value);
			return boolValue.EndboolValue(builder);
		}

		// Token: 0x0601C202 RID: 115202 RVA: 0x00893008 File Offset: 0x00891408
		public static void StartboolValue(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C203 RID: 115203 RVA: 0x00893011 File Offset: 0x00891411
		public static void AddValue(FlatBufferBuilder builder, bool value)
		{
			builder.AddBool(0, value, false);
		}

		// Token: 0x0601C204 RID: 115204 RVA: 0x0089301C File Offset: 0x0089141C
		public static Offset<boolValue> EndboolValue(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<boolValue>(value);
		}
	}
}
