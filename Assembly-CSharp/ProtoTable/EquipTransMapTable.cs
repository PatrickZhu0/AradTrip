using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000417 RID: 1047
	public class EquipTransMapTable : IFlatbufferObject
	{
		// Token: 0x17000C23 RID: 3107
		// (get) Token: 0x060031E9 RID: 12777 RVA: 0x000B13C0 File Offset: 0x000AF7C0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060031EA RID: 12778 RVA: 0x000B13CD File Offset: 0x000AF7CD
		public static EquipTransMapTable GetRootAsEquipTransMapTable(ByteBuffer _bb)
		{
			return EquipTransMapTable.GetRootAsEquipTransMapTable(_bb, new EquipTransMapTable());
		}

		// Token: 0x060031EB RID: 12779 RVA: 0x000B13DA File Offset: 0x000AF7DA
		public static EquipTransMapTable GetRootAsEquipTransMapTable(ByteBuffer _bb, EquipTransMapTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060031EC RID: 12780 RVA: 0x000B13F6 File Offset: 0x000AF7F6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060031ED RID: 12781 RVA: 0x000B1410 File Offset: 0x000AF810
		public EquipTransMapTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C24 RID: 3108
		// (get) Token: 0x060031EE RID: 12782 RVA: 0x000B141C File Offset: 0x000AF81C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1117574320 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C25 RID: 3109
		// (get) Token: 0x060031EF RID: 12783 RVA: 0x000B1468 File Offset: 0x000AF868
		public int ItemId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1117574320 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060031F0 RID: 12784 RVA: 0x000B14B4 File Offset: 0x000AF8B4
		public int LevelArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1117574320 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C26 RID: 3110
		// (get) Token: 0x060031F1 RID: 12785 RVA: 0x000B1500 File Offset: 0x000AF900
		public int LevelLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060031F2 RID: 12786 RVA: 0x000B1532 File Offset: 0x000AF932
		public ArraySegment<byte>? GetLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000C27 RID: 3111
		// (get) Token: 0x060031F3 RID: 12787 RVA: 0x000B1540 File Offset: 0x000AF940
		public FlatBufferArray<int> Level
		{
			get
			{
				if (this.LevelValue == null)
				{
					this.LevelValue = new FlatBufferArray<int>(new Func<int, int>(this.LevelArray), this.LevelLength);
				}
				return this.LevelValue;
			}
		}

		// Token: 0x060031F4 RID: 12788 RVA: 0x000B1570 File Offset: 0x000AF970
		public int SubTypesArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1117574320 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C28 RID: 3112
		// (get) Token: 0x060031F5 RID: 12789 RVA: 0x000B15C0 File Offset: 0x000AF9C0
		public int SubTypesLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060031F6 RID: 12790 RVA: 0x000B15F3 File Offset: 0x000AF9F3
		public ArraySegment<byte>? GetSubTypesBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000C29 RID: 3113
		// (get) Token: 0x060031F7 RID: 12791 RVA: 0x000B1602 File Offset: 0x000AFA02
		public FlatBufferArray<int> SubTypes
		{
			get
			{
				if (this.SubTypesValue == null)
				{
					this.SubTypesValue = new FlatBufferArray<int>(new Func<int, int>(this.SubTypesArray), this.SubTypesLength);
				}
				return this.SubTypesValue;
			}
		}

		// Token: 0x060031F8 RID: 12792 RVA: 0x000B1632 File Offset: 0x000AFA32
		public static Offset<EquipTransMapTable> CreateEquipTransMapTable(FlatBufferBuilder builder, int ID = 0, int ItemId = 0, VectorOffset LevelOffset = default(VectorOffset), VectorOffset SubTypesOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			EquipTransMapTable.AddSubTypes(builder, SubTypesOffset);
			EquipTransMapTable.AddLevel(builder, LevelOffset);
			EquipTransMapTable.AddItemId(builder, ItemId);
			EquipTransMapTable.AddID(builder, ID);
			return EquipTransMapTable.EndEquipTransMapTable(builder);
		}

		// Token: 0x060031F9 RID: 12793 RVA: 0x000B165E File Offset: 0x000AFA5E
		public static void StartEquipTransMapTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x060031FA RID: 12794 RVA: 0x000B1667 File Offset: 0x000AFA67
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060031FB RID: 12795 RVA: 0x000B1672 File Offset: 0x000AFA72
		public static void AddItemId(FlatBufferBuilder builder, int ItemId)
		{
			builder.AddInt(1, ItemId, 0);
		}

		// Token: 0x060031FC RID: 12796 RVA: 0x000B167D File Offset: 0x000AFA7D
		public static void AddLevel(FlatBufferBuilder builder, VectorOffset LevelOffset)
		{
			builder.AddOffset(2, LevelOffset.Value, 0);
		}

		// Token: 0x060031FD RID: 12797 RVA: 0x000B1690 File Offset: 0x000AFA90
		public static VectorOffset CreateLevelVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060031FE RID: 12798 RVA: 0x000B16CD File Offset: 0x000AFACD
		public static void StartLevelVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060031FF RID: 12799 RVA: 0x000B16D8 File Offset: 0x000AFAD8
		public static void AddSubTypes(FlatBufferBuilder builder, VectorOffset SubTypesOffset)
		{
			builder.AddOffset(3, SubTypesOffset.Value, 0);
		}

		// Token: 0x06003200 RID: 12800 RVA: 0x000B16EC File Offset: 0x000AFAEC
		public static VectorOffset CreateSubTypesVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003201 RID: 12801 RVA: 0x000B1729 File Offset: 0x000AFB29
		public static void StartSubTypesVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003202 RID: 12802 RVA: 0x000B1734 File Offset: 0x000AFB34
		public static Offset<EquipTransMapTable> EndEquipTransMapTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipTransMapTable>(value);
		}

		// Token: 0x06003203 RID: 12803 RVA: 0x000B174E File Offset: 0x000AFB4E
		public static void FinishEquipTransMapTableBuffer(FlatBufferBuilder builder, Offset<EquipTransMapTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400146D RID: 5229
		private Table __p = new Table();

		// Token: 0x0400146E RID: 5230
		private FlatBufferArray<int> LevelValue;

		// Token: 0x0400146F RID: 5231
		private FlatBufferArray<int> SubTypesValue;

		// Token: 0x02000418 RID: 1048
		public enum eCrypt
		{
			// Token: 0x04001471 RID: 5233
			code = -1117574320
		}
	}
}
