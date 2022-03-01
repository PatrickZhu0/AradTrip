using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000260 RID: 608
	public class UnionCell : IFlatbufferObject
	{
		// Token: 0x060013B8 RID: 5048 RVA: 0x00069248 File Offset: 0x00067648
		public static UnionCell Default()
		{
			if (UnionCell.def == null)
			{
				FlatBufferBuilder flatBufferBuilder = new FlatBufferBuilder(64);
				flatBufferBuilder.Finish(UnionCell.CreateUnionCell(flatBufferBuilder, UnionCellType.union_helper, default(Offset<EveryValue>), 0, 0, 0).Value);
				UnionCell.def = UnionCell.GetRootAsUnionCell(new ByteBuffer(flatBufferBuilder.SizedByteArray()));
			}
			return UnionCell.def;
		}

		// Token: 0x1700022B RID: 555
		// (get) Token: 0x060013B9 RID: 5049 RVA: 0x000692A2 File Offset: 0x000676A2
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060013BA RID: 5050 RVA: 0x000692AF File Offset: 0x000676AF
		public static UnionCell GetRootAsUnionCell(ByteBuffer _bb)
		{
			return UnionCell.GetRootAsUnionCell(_bb, new UnionCell());
		}

		// Token: 0x060013BB RID: 5051 RVA: 0x000692BC File Offset: 0x000676BC
		public static UnionCell GetRootAsUnionCell(ByteBuffer _bb, UnionCell obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060013BC RID: 5052 RVA: 0x000692D8 File Offset: 0x000676D8
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060013BD RID: 5053 RVA: 0x000692F2 File Offset: 0x000676F2
		public UnionCell __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700022C RID: 556
		// (get) Token: 0x060013BE RID: 5054 RVA: 0x00069300 File Offset: 0x00067700
		public UnionCellType valueType
		{
			get
			{
				int num = this.__p.__offset(4);
				return (UnionCellType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700022D RID: 557
		// (get) Token: 0x060013BF RID: 5055 RVA: 0x00069344 File Offset: 0x00067744
		public EveryValue eValues
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? null : new EveryValue().__assign(this.__p.__indirect(num + this.__p.bb_pos), this.__p.bb);
			}
		}

		// Token: 0x1700022E RID: 558
		// (get) Token: 0x060013C0 RID: 5056 RVA: 0x00069398 File Offset: 0x00067798
		public int fixValue
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos);
			}
		}

		// Token: 0x1700022F RID: 559
		// (get) Token: 0x060013C1 RID: 5057 RVA: 0x000693DC File Offset: 0x000677DC
		public int fixInitValue
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000230 RID: 560
		// (get) Token: 0x060013C2 RID: 5058 RVA: 0x00069420 File Offset: 0x00067820
		public int fixLevelGrow
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060013C3 RID: 5059 RVA: 0x00069464 File Offset: 0x00067864
		public static Offset<UnionCell> CreateUnionCell(FlatBufferBuilder builder, UnionCellType valueType = UnionCellType.union_helper, Offset<EveryValue> eValuesOffset = default(Offset<EveryValue>), int fixValue = 0, int fixInitValue = 0, int fixLevelGrow = 0)
		{
			builder.StartObject(5);
			UnionCell.AddFixLevelGrow(builder, fixLevelGrow);
			UnionCell.AddFixInitValue(builder, fixInitValue);
			UnionCell.AddFixValue(builder, fixValue);
			UnionCell.AddEValues(builder, eValuesOffset);
			UnionCell.AddValueType(builder, valueType);
			return UnionCell.EndUnionCell(builder);
		}

		// Token: 0x060013C4 RID: 5060 RVA: 0x00069498 File Offset: 0x00067898
		public static void StartUnionCell(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060013C5 RID: 5061 RVA: 0x000694A1 File Offset: 0x000678A1
		public static void AddValueType(FlatBufferBuilder builder, UnionCellType valueType)
		{
			builder.AddInt(0, (int)valueType, 0);
		}

		// Token: 0x060013C6 RID: 5062 RVA: 0x000694AC File Offset: 0x000678AC
		public static void AddEValues(FlatBufferBuilder builder, Offset<EveryValue> eValuesOffset)
		{
			builder.AddOffset(1, eValuesOffset.Value, 0);
		}

		// Token: 0x060013C7 RID: 5063 RVA: 0x000694BD File Offset: 0x000678BD
		public static void AddFixValue(FlatBufferBuilder builder, int fixValue)
		{
			builder.AddInt(2, fixValue, 0);
		}

		// Token: 0x060013C8 RID: 5064 RVA: 0x000694C8 File Offset: 0x000678C8
		public static void AddFixInitValue(FlatBufferBuilder builder, int fixInitValue)
		{
			builder.AddInt(3, fixInitValue, 0);
		}

		// Token: 0x060013C9 RID: 5065 RVA: 0x000694D3 File Offset: 0x000678D3
		public static void AddFixLevelGrow(FlatBufferBuilder builder, int fixLevelGrow)
		{
			builder.AddInt(4, fixLevelGrow, 0);
		}

		// Token: 0x060013CA RID: 5066 RVA: 0x000694E0 File Offset: 0x000678E0
		public static Offset<UnionCell> EndUnionCell(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<UnionCell>(value);
		}

		// Token: 0x04000D4D RID: 3405
		private static UnionCell def;

		// Token: 0x04000D4E RID: 3406
		private Table __p = new Table();
	}
}
