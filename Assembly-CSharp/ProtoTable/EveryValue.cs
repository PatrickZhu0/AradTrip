using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200025F RID: 607
	public class EveryValue : IFlatbufferObject
	{
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x060013A8 RID: 5032 RVA: 0x0006908A File Offset: 0x0006748A
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00069097 File Offset: 0x00067497
		public static EveryValue GetRootAsEveryValue(ByteBuffer _bb)
		{
			return EveryValue.GetRootAsEveryValue(_bb, new EveryValue());
		}

		// Token: 0x060013AA RID: 5034 RVA: 0x000690A4 File Offset: 0x000674A4
		public static EveryValue GetRootAsEveryValue(ByteBuffer _bb, EveryValue obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060013AB RID: 5035 RVA: 0x000690C0 File Offset: 0x000674C0
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060013AC RID: 5036 RVA: 0x000690DA File Offset: 0x000674DA
		public EveryValue __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x060013AD RID: 5037 RVA: 0x000690E8 File Offset: 0x000674E8
		public int everyValuesArray(int j)
		{
			int num = this.__p.__offset(4);
			return (num == 0) ? 0 : this.__p.bb.GetInt(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000229 RID: 553
		// (get) Token: 0x060013AE RID: 5038 RVA: 0x00069130 File Offset: 0x00067530
		public int everyValuesLength
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060013AF RID: 5039 RVA: 0x00069162 File Offset: 0x00067562
		public ArraySegment<byte>? GetEveryValuesBytes()
		{
			return this.__p.__vector_as_arraysegment(4);
		}

		// Token: 0x1700022A RID: 554
		// (get) Token: 0x060013B0 RID: 5040 RVA: 0x00069170 File Offset: 0x00067570
		public FlatBufferArray<int> everyValues
		{
			get
			{
				if (this.everyValuesValue == null)
				{
					this.everyValuesValue = new FlatBufferArray<int>(new Func<int, int>(this.everyValuesArray), this.everyValuesLength);
				}
				return this.everyValuesValue;
			}
		}

		// Token: 0x060013B1 RID: 5041 RVA: 0x000691A0 File Offset: 0x000675A0
		public static Offset<EveryValue> CreateEveryValue(FlatBufferBuilder builder, VectorOffset everyValuesOffset = default(VectorOffset))
		{
			builder.StartObject(1);
			EveryValue.AddEveryValues(builder, everyValuesOffset);
			return EveryValue.EndEveryValue(builder);
		}

		// Token: 0x060013B2 RID: 5042 RVA: 0x000691B6 File Offset: 0x000675B6
		public static void StartEveryValue(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x060013B3 RID: 5043 RVA: 0x000691BF File Offset: 0x000675BF
		public static void AddEveryValues(FlatBufferBuilder builder, VectorOffset everyValuesOffset)
		{
			builder.AddOffset(0, everyValuesOffset.Value, 0);
		}

		// Token: 0x060013B4 RID: 5044 RVA: 0x000691D0 File Offset: 0x000675D0
		public static VectorOffset CreateEveryValuesVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060013B5 RID: 5045 RVA: 0x0006920D File Offset: 0x0006760D
		public static void StartEveryValuesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060013B6 RID: 5046 RVA: 0x00069218 File Offset: 0x00067618
		public static Offset<EveryValue> EndEveryValue(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EveryValue>(value);
		}

		// Token: 0x04000D4B RID: 3403
		private Table __p = new Table();

		// Token: 0x04000D4C RID: 3404
		private FlatBufferArray<int> everyValuesValue;
	}
}
