using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004F2 RID: 1266
	public class MallShopMultiITable : IFlatbufferObject
	{
		// Token: 0x17001117 RID: 4375
		// (get) Token: 0x060040D2 RID: 16594 RVA: 0x000D4768 File Offset: 0x000D2B68
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060040D3 RID: 16595 RVA: 0x000D4775 File Offset: 0x000D2B75
		public static MallShopMultiITable GetRootAsMallShopMultiITable(ByteBuffer _bb)
		{
			return MallShopMultiITable.GetRootAsMallShopMultiITable(_bb, new MallShopMultiITable());
		}

		// Token: 0x060040D4 RID: 16596 RVA: 0x000D4782 File Offset: 0x000D2B82
		public static MallShopMultiITable GetRootAsMallShopMultiITable(ByteBuffer _bb, MallShopMultiITable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060040D5 RID: 16597 RVA: 0x000D479E File Offset: 0x000D2B9E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060040D6 RID: 16598 RVA: 0x000D47B8 File Offset: 0x000D2BB8
		public MallShopMultiITable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001118 RID: 4376
		// (get) Token: 0x060040D7 RID: 16599 RVA: 0x000D47C4 File Offset: 0x000D2BC4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1291395942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001119 RID: 4377
		// (get) Token: 0x060040D8 RID: 16600 RVA: 0x000D4810 File Offset: 0x000D2C10
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040D9 RID: 16601 RVA: 0x000D4852 File Offset: 0x000D2C52
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700111A RID: 4378
		// (get) Token: 0x060040DA RID: 16602 RVA: 0x000D4860 File Offset: 0x000D2C60
		public string EndTime
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040DB RID: 16603 RVA: 0x000D48A2 File Offset: 0x000D2CA2
		public ArraySegment<byte>? GetEndTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700111B RID: 4379
		// (get) Token: 0x060040DC RID: 16604 RVA: 0x000D48B0 File Offset: 0x000D2CB0
		public string Malls
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060040DD RID: 16605 RVA: 0x000D48F3 File Offset: 0x000D2CF3
		public ArraySegment<byte>? GetMallsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700111C RID: 4380
		// (get) Token: 0x060040DE RID: 16606 RVA: 0x000D4904 File Offset: 0x000D2D04
		public int Multiple
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1291395942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060040DF RID: 16607 RVA: 0x000D494E File Offset: 0x000D2D4E
		public static Offset<MallShopMultiITable> CreateMallShopMultiITable(FlatBufferBuilder builder, int ID = 0, StringOffset StartTimeOffset = default(StringOffset), StringOffset EndTimeOffset = default(StringOffset), StringOffset MallsOffset = default(StringOffset), int Multiple = 0)
		{
			builder.StartObject(5);
			MallShopMultiITable.AddMultiple(builder, Multiple);
			MallShopMultiITable.AddMalls(builder, MallsOffset);
			MallShopMultiITable.AddEndTime(builder, EndTimeOffset);
			MallShopMultiITable.AddStartTime(builder, StartTimeOffset);
			MallShopMultiITable.AddID(builder, ID);
			return MallShopMultiITable.EndMallShopMultiITable(builder);
		}

		// Token: 0x060040E0 RID: 16608 RVA: 0x000D4982 File Offset: 0x000D2D82
		public static void StartMallShopMultiITable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060040E1 RID: 16609 RVA: 0x000D498B File Offset: 0x000D2D8B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060040E2 RID: 16610 RVA: 0x000D4996 File Offset: 0x000D2D96
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(1, StartTimeOffset.Value, 0);
		}

		// Token: 0x060040E3 RID: 16611 RVA: 0x000D49A7 File Offset: 0x000D2DA7
		public static void AddEndTime(FlatBufferBuilder builder, StringOffset EndTimeOffset)
		{
			builder.AddOffset(2, EndTimeOffset.Value, 0);
		}

		// Token: 0x060040E4 RID: 16612 RVA: 0x000D49B8 File Offset: 0x000D2DB8
		public static void AddMalls(FlatBufferBuilder builder, StringOffset MallsOffset)
		{
			builder.AddOffset(3, MallsOffset.Value, 0);
		}

		// Token: 0x060040E5 RID: 16613 RVA: 0x000D49C9 File Offset: 0x000D2DC9
		public static void AddMultiple(FlatBufferBuilder builder, int Multiple)
		{
			builder.AddInt(4, Multiple, 0);
		}

		// Token: 0x060040E6 RID: 16614 RVA: 0x000D49D4 File Offset: 0x000D2DD4
		public static Offset<MallShopMultiITable> EndMallShopMultiITable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MallShopMultiITable>(value);
		}

		// Token: 0x060040E7 RID: 16615 RVA: 0x000D49EE File Offset: 0x000D2DEE
		public static void FinishMallShopMultiITableBuffer(FlatBufferBuilder builder, Offset<MallShopMultiITable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001837 RID: 6199
		private Table __p = new Table();

		// Token: 0x020004F3 RID: 1267
		public enum eCrypt
		{
			// Token: 0x04001839 RID: 6201
			code = -1291395942
		}
	}
}
