using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005D7 RID: 1495
	public class StrengthenTicketTable : IFlatbufferObject
	{
		// Token: 0x170015D4 RID: 5588
		// (get) Token: 0x06004F4A RID: 20298 RVA: 0x000F6300 File Offset: 0x000F4700
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004F4B RID: 20299 RVA: 0x000F630D File Offset: 0x000F470D
		public static StrengthenTicketTable GetRootAsStrengthenTicketTable(ByteBuffer _bb)
		{
			return StrengthenTicketTable.GetRootAsStrengthenTicketTable(_bb, new StrengthenTicketTable());
		}

		// Token: 0x06004F4C RID: 20300 RVA: 0x000F631A File Offset: 0x000F471A
		public static StrengthenTicketTable GetRootAsStrengthenTicketTable(ByteBuffer _bb, StrengthenTicketTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004F4D RID: 20301 RVA: 0x000F6336 File Offset: 0x000F4736
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004F4E RID: 20302 RVA: 0x000F6350 File Offset: 0x000F4750
		public StrengthenTicketTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015D5 RID: 5589
		// (get) Token: 0x06004F4F RID: 20303 RVA: 0x000F635C File Offset: 0x000F475C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1657223812 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D6 RID: 5590
		// (get) Token: 0x06004F50 RID: 20304 RVA: 0x000F63A8 File Offset: 0x000F47A8
		public int Probility
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1657223812 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D7 RID: 5591
		// (get) Token: 0x06004F51 RID: 20305 RVA: 0x000F63F4 File Offset: 0x000F47F4
		public int Level
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1657223812 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015D8 RID: 5592
		// (get) Token: 0x06004F52 RID: 20306 RVA: 0x000F6440 File Offset: 0x000F4840
		public string desc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F53 RID: 20307 RVA: 0x000F6483 File Offset: 0x000F4883
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170015D9 RID: 5593
		// (get) Token: 0x06004F54 RID: 20308 RVA: 0x000F6494 File Offset: 0x000F4894
		public int Compound
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1657223812 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015DA RID: 5594
		// (get) Token: 0x06004F55 RID: 20309 RVA: 0x000F64E0 File Offset: 0x000F48E0
		public int FuseValue
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1657223812 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004F56 RID: 20310 RVA: 0x000F652A File Offset: 0x000F492A
		public static Offset<StrengthenTicketTable> CreateStrengthenTicketTable(FlatBufferBuilder builder, int ID = 0, int Probility = 0, int Level = 0, StringOffset descOffset = default(StringOffset), int Compound = 0, int FuseValue = 0)
		{
			builder.StartObject(6);
			StrengthenTicketTable.AddFuseValue(builder, FuseValue);
			StrengthenTicketTable.AddCompound(builder, Compound);
			StrengthenTicketTable.AddDesc(builder, descOffset);
			StrengthenTicketTable.AddLevel(builder, Level);
			StrengthenTicketTable.AddProbility(builder, Probility);
			StrengthenTicketTable.AddID(builder, ID);
			return StrengthenTicketTable.EndStrengthenTicketTable(builder);
		}

		// Token: 0x06004F57 RID: 20311 RVA: 0x000F6566 File Offset: 0x000F4966
		public static void StartStrengthenTicketTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06004F58 RID: 20312 RVA: 0x000F656F File Offset: 0x000F496F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004F59 RID: 20313 RVA: 0x000F657A File Offset: 0x000F497A
		public static void AddProbility(FlatBufferBuilder builder, int Probility)
		{
			builder.AddInt(1, Probility, 0);
		}

		// Token: 0x06004F5A RID: 20314 RVA: 0x000F6585 File Offset: 0x000F4985
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(2, Level, 0);
		}

		// Token: 0x06004F5B RID: 20315 RVA: 0x000F6590 File Offset: 0x000F4990
		public static void AddDesc(FlatBufferBuilder builder, StringOffset descOffset)
		{
			builder.AddOffset(3, descOffset.Value, 0);
		}

		// Token: 0x06004F5C RID: 20316 RVA: 0x000F65A1 File Offset: 0x000F49A1
		public static void AddCompound(FlatBufferBuilder builder, int Compound)
		{
			builder.AddInt(4, Compound, 0);
		}

		// Token: 0x06004F5D RID: 20317 RVA: 0x000F65AC File Offset: 0x000F49AC
		public static void AddFuseValue(FlatBufferBuilder builder, int FuseValue)
		{
			builder.AddInt(5, FuseValue, 0);
		}

		// Token: 0x06004F5E RID: 20318 RVA: 0x000F65B8 File Offset: 0x000F49B8
		public static Offset<StrengthenTicketTable> EndStrengthenTicketTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<StrengthenTicketTable>(value);
		}

		// Token: 0x06004F5F RID: 20319 RVA: 0x000F65D2 File Offset: 0x000F49D2
		public static void FinishStrengthenTicketTableBuffer(FlatBufferBuilder builder, Offset<StrengthenTicketTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BE5 RID: 7141
		private Table __p = new Table();

		// Token: 0x020005D8 RID: 1496
		public enum eCrypt
		{
			// Token: 0x04001BE7 RID: 7143
			code = 1657223812
		}
	}
}
