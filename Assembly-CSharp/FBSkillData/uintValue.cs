using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B2D RID: 19245
	public sealed class uintValue : Table
	{
		// Token: 0x0601C221 RID: 115233 RVA: 0x0089327E File Offset: 0x0089167E
		public static uintValue GetRootAsuintValue(ByteBuffer _bb)
		{
			return uintValue.GetRootAsuintValue(_bb, new uintValue());
		}

		// Token: 0x0601C222 RID: 115234 RVA: 0x0089328B File Offset: 0x0089168B
		public static uintValue GetRootAsuintValue(ByteBuffer _bb, uintValue obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C223 RID: 115235 RVA: 0x008932A7 File Offset: 0x008916A7
		public uintValue __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x170026F4 RID: 9972
		// (get) Token: 0x0601C224 RID: 115236 RVA: 0x008932B8 File Offset: 0x008916B8
		public uint Value
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0U : this.bb.GetUint(num + this.bb_pos);
			}
		}

		// Token: 0x0601C225 RID: 115237 RVA: 0x008932EC File Offset: 0x008916EC
		public static Offset<uintValue> CreateuintValue(FlatBufferBuilder builder, uint value = 0U)
		{
			builder.StartObject(1);
			uintValue.AddValue(builder, value);
			return uintValue.EnduintValue(builder);
		}

		// Token: 0x0601C226 RID: 115238 RVA: 0x00893302 File Offset: 0x00891702
		public static void StartuintValue(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C227 RID: 115239 RVA: 0x0089330B File Offset: 0x0089170B
		public static void AddValue(FlatBufferBuilder builder, uint value)
		{
			builder.AddUint(0, value, 0U);
		}

		// Token: 0x0601C228 RID: 115240 RVA: 0x00893318 File Offset: 0x00891718
		public static Offset<uintValue> EnduintValue(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<uintValue>(value);
		}
	}
}
