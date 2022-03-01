using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000514 RID: 1300
	public class MonopolyRandomTable : IFlatbufferObject
	{
		// Token: 0x170011AF RID: 4527
		// (get) Token: 0x060042A4 RID: 17060 RVA: 0x000D8BE8 File Offset: 0x000D6FE8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060042A5 RID: 17061 RVA: 0x000D8BF5 File Offset: 0x000D6FF5
		public static MonopolyRandomTable GetRootAsMonopolyRandomTable(ByteBuffer _bb)
		{
			return MonopolyRandomTable.GetRootAsMonopolyRandomTable(_bb, new MonopolyRandomTable());
		}

		// Token: 0x060042A6 RID: 17062 RVA: 0x000D8C02 File Offset: 0x000D7002
		public static MonopolyRandomTable GetRootAsMonopolyRandomTable(ByteBuffer _bb, MonopolyRandomTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060042A7 RID: 17063 RVA: 0x000D8C1E File Offset: 0x000D701E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060042A8 RID: 17064 RVA: 0x000D8C38 File Offset: 0x000D7038
		public MonopolyRandomTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011B0 RID: 4528
		// (get) Token: 0x060042A9 RID: 17065 RVA: 0x000D8C44 File Offset: 0x000D7044
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (212854060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011B1 RID: 4529
		// (get) Token: 0x060042AA RID: 17066 RVA: 0x000D8C90 File Offset: 0x000D7090
		public int gridType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (212854060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011B2 RID: 4530
		// (get) Token: 0x060042AB RID: 17067 RVA: 0x000D8CDC File Offset: 0x000D70DC
		public int type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (212854060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011B3 RID: 4531
		// (get) Token: 0x060042AC RID: 17068 RVA: 0x000D8D28 File Offset: 0x000D7128
		public string param
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060042AD RID: 17069 RVA: 0x000D8D6B File Offset: 0x000D716B
		public ArraySegment<byte>? GetParamBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170011B4 RID: 4532
		// (get) Token: 0x060042AE RID: 17070 RVA: 0x000D8D7C File Offset: 0x000D717C
		public string num
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060042AF RID: 17071 RVA: 0x000D8DBF File Offset: 0x000D71BF
		public ArraySegment<byte>? GetNumBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170011B5 RID: 4533
		// (get) Token: 0x060042B0 RID: 17072 RVA: 0x000D8DD0 File Offset: 0x000D71D0
		public int weight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (212854060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011B6 RID: 4534
		// (get) Token: 0x060042B1 RID: 17073 RVA: 0x000D8E1C File Offset: 0x000D721C
		public int randomType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (212854060 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011B7 RID: 4535
		// (get) Token: 0x060042B2 RID: 17074 RVA: 0x000D8E68 File Offset: 0x000D7268
		public string image
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060042B3 RID: 17075 RVA: 0x000D8EAB File Offset: 0x000D72AB
		public ArraySegment<byte>? GetImageBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170011B8 RID: 4536
		// (get) Token: 0x060042B4 RID: 17076 RVA: 0x000D8EBC File Offset: 0x000D72BC
		public string title
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060042B5 RID: 17077 RVA: 0x000D8EFF File Offset: 0x000D72FF
		public ArraySegment<byte>? GetTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170011B9 RID: 4537
		// (get) Token: 0x060042B6 RID: 17078 RVA: 0x000D8F10 File Offset: 0x000D7310
		public string describe
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060042B7 RID: 17079 RVA: 0x000D8F53 File Offset: 0x000D7353
		public ArraySegment<byte>? GetDescribeBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x060042B8 RID: 17080 RVA: 0x000D8F64 File Offset: 0x000D7364
		public static Offset<MonopolyRandomTable> CreateMonopolyRandomTable(FlatBufferBuilder builder, int ID = 0, int gridType = 0, int type = 0, StringOffset paramOffset = default(StringOffset), StringOffset numOffset = default(StringOffset), int weight = 0, int randomType = 0, StringOffset imageOffset = default(StringOffset), StringOffset titleOffset = default(StringOffset), StringOffset describeOffset = default(StringOffset))
		{
			builder.StartObject(10);
			MonopolyRandomTable.AddDescribe(builder, describeOffset);
			MonopolyRandomTable.AddTitle(builder, titleOffset);
			MonopolyRandomTable.AddImage(builder, imageOffset);
			MonopolyRandomTable.AddRandomType(builder, randomType);
			MonopolyRandomTable.AddWeight(builder, weight);
			MonopolyRandomTable.AddNum(builder, numOffset);
			MonopolyRandomTable.AddParam(builder, paramOffset);
			MonopolyRandomTable.AddType(builder, type);
			MonopolyRandomTable.AddGridType(builder, gridType);
			MonopolyRandomTable.AddID(builder, ID);
			return MonopolyRandomTable.EndMonopolyRandomTable(builder);
		}

		// Token: 0x060042B9 RID: 17081 RVA: 0x000D8FCC File Offset: 0x000D73CC
		public static void StartMonopolyRandomTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x060042BA RID: 17082 RVA: 0x000D8FD6 File Offset: 0x000D73D6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060042BB RID: 17083 RVA: 0x000D8FE1 File Offset: 0x000D73E1
		public static void AddGridType(FlatBufferBuilder builder, int gridType)
		{
			builder.AddInt(1, gridType, 0);
		}

		// Token: 0x060042BC RID: 17084 RVA: 0x000D8FEC File Offset: 0x000D73EC
		public static void AddType(FlatBufferBuilder builder, int type)
		{
			builder.AddInt(2, type, 0);
		}

		// Token: 0x060042BD RID: 17085 RVA: 0x000D8FF7 File Offset: 0x000D73F7
		public static void AddParam(FlatBufferBuilder builder, StringOffset paramOffset)
		{
			builder.AddOffset(3, paramOffset.Value, 0);
		}

		// Token: 0x060042BE RID: 17086 RVA: 0x000D9008 File Offset: 0x000D7408
		public static void AddNum(FlatBufferBuilder builder, StringOffset numOffset)
		{
			builder.AddOffset(4, numOffset.Value, 0);
		}

		// Token: 0x060042BF RID: 17087 RVA: 0x000D9019 File Offset: 0x000D7419
		public static void AddWeight(FlatBufferBuilder builder, int weight)
		{
			builder.AddInt(5, weight, 0);
		}

		// Token: 0x060042C0 RID: 17088 RVA: 0x000D9024 File Offset: 0x000D7424
		public static void AddRandomType(FlatBufferBuilder builder, int randomType)
		{
			builder.AddInt(6, randomType, 0);
		}

		// Token: 0x060042C1 RID: 17089 RVA: 0x000D902F File Offset: 0x000D742F
		public static void AddImage(FlatBufferBuilder builder, StringOffset imageOffset)
		{
			builder.AddOffset(7, imageOffset.Value, 0);
		}

		// Token: 0x060042C2 RID: 17090 RVA: 0x000D9040 File Offset: 0x000D7440
		public static void AddTitle(FlatBufferBuilder builder, StringOffset titleOffset)
		{
			builder.AddOffset(8, titleOffset.Value, 0);
		}

		// Token: 0x060042C3 RID: 17091 RVA: 0x000D9051 File Offset: 0x000D7451
		public static void AddDescribe(FlatBufferBuilder builder, StringOffset describeOffset)
		{
			builder.AddOffset(9, describeOffset.Value, 0);
		}

		// Token: 0x060042C4 RID: 17092 RVA: 0x000D9064 File Offset: 0x000D7464
		public static Offset<MonopolyRandomTable> EndMonopolyRandomTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonopolyRandomTable>(value);
		}

		// Token: 0x060042C5 RID: 17093 RVA: 0x000D907E File Offset: 0x000D747E
		public static void FinishMonopolyRandomTableBuffer(FlatBufferBuilder builder, Offset<MonopolyRandomTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018D9 RID: 6361
		private Table __p = new Table();

		// Token: 0x02000515 RID: 1301
		public enum eCrypt
		{
			// Token: 0x040018DB RID: 6363
			code = 212854060
		}
	}
}
