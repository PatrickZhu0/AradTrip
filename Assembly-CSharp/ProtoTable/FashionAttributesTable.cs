using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000428 RID: 1064
	public class FashionAttributesTable : IFlatbufferObject
	{
		// Token: 0x17000C5D RID: 3165
		// (get) Token: 0x060032A9 RID: 12969 RVA: 0x000B2D74 File Offset: 0x000B1174
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060032AA RID: 12970 RVA: 0x000B2D81 File Offset: 0x000B1181
		public static FashionAttributesTable GetRootAsFashionAttributesTable(ByteBuffer _bb)
		{
			return FashionAttributesTable.GetRootAsFashionAttributesTable(_bb, new FashionAttributesTable());
		}

		// Token: 0x060032AB RID: 12971 RVA: 0x000B2D8E File Offset: 0x000B118E
		public static FashionAttributesTable GetRootAsFashionAttributesTable(ByteBuffer _bb, FashionAttributesTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060032AC RID: 12972 RVA: 0x000B2DAA File Offset: 0x000B11AA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060032AD RID: 12973 RVA: 0x000B2DC4 File Offset: 0x000B11C4
		public FashionAttributesTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C5E RID: 3166
		// (get) Token: 0x060032AE RID: 12974 RVA: 0x000B2DD0 File Offset: 0x000B11D0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1878141935 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060032AF RID: 12975 RVA: 0x000B2E1C File Offset: 0x000B121C
		public int PropTypeArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (-1878141935 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C5F RID: 3167
		// (get) Token: 0x060032B0 RID: 12976 RVA: 0x000B2E68 File Offset: 0x000B1268
		public int PropTypeLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060032B1 RID: 12977 RVA: 0x000B2E9A File Offset: 0x000B129A
		public ArraySegment<byte>? GetPropTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000C60 RID: 3168
		// (get) Token: 0x060032B2 RID: 12978 RVA: 0x000B2EA8 File Offset: 0x000B12A8
		public FlatBufferArray<int> PropType
		{
			get
			{
				if (this.PropTypeValue == null)
				{
					this.PropTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.PropTypeArray), this.PropTypeLength);
				}
				return this.PropTypeValue;
			}
		}

		// Token: 0x060032B3 RID: 12979 RVA: 0x000B2ED8 File Offset: 0x000B12D8
		public int PropValueArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1878141935 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C61 RID: 3169
		// (get) Token: 0x060032B4 RID: 12980 RVA: 0x000B2F24 File Offset: 0x000B1324
		public int PropValueLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060032B5 RID: 12981 RVA: 0x000B2F56 File Offset: 0x000B1356
		public ArraySegment<byte>? GetPropValueBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000C62 RID: 3170
		// (get) Token: 0x060032B6 RID: 12982 RVA: 0x000B2F64 File Offset: 0x000B1364
		public FlatBufferArray<int> PropValue
		{
			get
			{
				if (this.PropValueValue == null)
				{
					this.PropValueValue = new FlatBufferArray<int>(new Func<int, int>(this.PropValueArray), this.PropValueLength);
				}
				return this.PropValueValue;
			}
		}

		// Token: 0x060032B7 RID: 12983 RVA: 0x000B2F94 File Offset: 0x000B1394
		public int BuffIDArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1878141935 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C63 RID: 3171
		// (get) Token: 0x060032B8 RID: 12984 RVA: 0x000B2FE4 File Offset: 0x000B13E4
		public int BuffIDLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060032B9 RID: 12985 RVA: 0x000B3017 File Offset: 0x000B1417
		public ArraySegment<byte>? GetBuffIDBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000C64 RID: 3172
		// (get) Token: 0x060032BA RID: 12986 RVA: 0x000B3026 File Offset: 0x000B1426
		public FlatBufferArray<int> BuffID
		{
			get
			{
				if (this.BuffIDValue == null)
				{
					this.BuffIDValue = new FlatBufferArray<int>(new Func<int, int>(this.BuffIDArray), this.BuffIDLength);
				}
				return this.BuffIDValue;
			}
		}

		// Token: 0x060032BB RID: 12987 RVA: 0x000B3056 File Offset: 0x000B1456
		public static Offset<FashionAttributesTable> CreateFashionAttributesTable(FlatBufferBuilder builder, int ID = 0, VectorOffset PropTypeOffset = default(VectorOffset), VectorOffset PropValueOffset = default(VectorOffset), VectorOffset BuffIDOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			FashionAttributesTable.AddBuffID(builder, BuffIDOffset);
			FashionAttributesTable.AddPropValue(builder, PropValueOffset);
			FashionAttributesTable.AddPropType(builder, PropTypeOffset);
			FashionAttributesTable.AddID(builder, ID);
			return FashionAttributesTable.EndFashionAttributesTable(builder);
		}

		// Token: 0x060032BC RID: 12988 RVA: 0x000B3082 File Offset: 0x000B1482
		public static void StartFashionAttributesTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060032BD RID: 12989 RVA: 0x000B308B File Offset: 0x000B148B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060032BE RID: 12990 RVA: 0x000B3096 File Offset: 0x000B1496
		public static void AddPropType(FlatBufferBuilder builder, VectorOffset PropTypeOffset)
		{
			builder.AddOffset(1, PropTypeOffset.Value, 0);
		}

		// Token: 0x060032BF RID: 12991 RVA: 0x000B30A8 File Offset: 0x000B14A8
		public static VectorOffset CreatePropTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060032C0 RID: 12992 RVA: 0x000B30E5 File Offset: 0x000B14E5
		public static void StartPropTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060032C1 RID: 12993 RVA: 0x000B30F0 File Offset: 0x000B14F0
		public static void AddPropValue(FlatBufferBuilder builder, VectorOffset PropValueOffset)
		{
			builder.AddOffset(2, PropValueOffset.Value, 0);
		}

		// Token: 0x060032C2 RID: 12994 RVA: 0x000B3104 File Offset: 0x000B1504
		public static VectorOffset CreatePropValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060032C3 RID: 12995 RVA: 0x000B3141 File Offset: 0x000B1541
		public static void StartPropValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060032C4 RID: 12996 RVA: 0x000B314C File Offset: 0x000B154C
		public static void AddBuffID(FlatBufferBuilder builder, VectorOffset BuffIDOffset)
		{
			builder.AddOffset(3, BuffIDOffset.Value, 0);
		}

		// Token: 0x060032C5 RID: 12997 RVA: 0x000B3160 File Offset: 0x000B1560
		public static VectorOffset CreateBuffIDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060032C6 RID: 12998 RVA: 0x000B319D File Offset: 0x000B159D
		public static void StartBuffIDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060032C7 RID: 12999 RVA: 0x000B31A8 File Offset: 0x000B15A8
		public static Offset<FashionAttributesTable> EndFashionAttributesTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionAttributesTable>(value);
		}

		// Token: 0x060032C8 RID: 13000 RVA: 0x000B31C2 File Offset: 0x000B15C2
		public static void FinishFashionAttributesTableBuffer(FlatBufferBuilder builder, Offset<FashionAttributesTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014D0 RID: 5328
		private Table __p = new Table();

		// Token: 0x040014D1 RID: 5329
		private FlatBufferArray<int> PropTypeValue;

		// Token: 0x040014D2 RID: 5330
		private FlatBufferArray<int> PropValueValue;

		// Token: 0x040014D3 RID: 5331
		private FlatBufferArray<int> BuffIDValue;

		// Token: 0x02000429 RID: 1065
		public enum eCrypt
		{
			// Token: 0x040014D5 RID: 5333
			code = -1878141935
		}
	}
}
