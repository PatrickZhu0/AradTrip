using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000298 RID: 664
	public class AdventureTeamTable : IFlatbufferObject
	{
		// Token: 0x17000364 RID: 868
		// (get) Token: 0x060017A4 RID: 6052 RVA: 0x00071EA8 File Offset: 0x000702A8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060017A5 RID: 6053 RVA: 0x00071EB5 File Offset: 0x000702B5
		public static AdventureTeamTable GetRootAsAdventureTeamTable(ByteBuffer _bb)
		{
			return AdventureTeamTable.GetRootAsAdventureTeamTable(_bb, new AdventureTeamTable());
		}

		// Token: 0x060017A6 RID: 6054 RVA: 0x00071EC2 File Offset: 0x000702C2
		public static AdventureTeamTable GetRootAsAdventureTeamTable(ByteBuffer _bb, AdventureTeamTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060017A7 RID: 6055 RVA: 0x00071EDE File Offset: 0x000702DE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060017A8 RID: 6056 RVA: 0x00071EF8 File Offset: 0x000702F8
		public AdventureTeamTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000365 RID: 869
		// (get) Token: 0x060017A9 RID: 6057 RVA: 0x00071F04 File Offset: 0x00070304
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (847890401 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000366 RID: 870
		// (get) Token: 0x060017AA RID: 6058 RVA: 0x00071F50 File Offset: 0x00070350
		public string Exp
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060017AB RID: 6059 RVA: 0x00071F92 File Offset: 0x00070392
		public ArraySegment<byte>? GetExpBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000367 RID: 871
		// (get) Token: 0x060017AC RID: 6060 RVA: 0x00071FA0 File Offset: 0x000703A0
		public int ClearDungeonExpAddition
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (847890401 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000368 RID: 872
		// (get) Token: 0x060017AD RID: 6061 RVA: 0x00071FEC File Offset: 0x000703EC
		public string ExpSource
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060017AE RID: 6062 RVA: 0x0007202F File Offset: 0x0007042F
		public ArraySegment<byte>? GetExpSourceBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000369 RID: 873
		// (get) Token: 0x060017AF RID: 6063 RVA: 0x00072040 File Offset: 0x00070440
		public string PropertyIncomeDesc
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060017B0 RID: 6064 RVA: 0x00072083 File Offset: 0x00070483
		public ArraySegment<byte>? GetPropertyIncomeDescBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x060017B1 RID: 6065 RVA: 0x00072092 File Offset: 0x00070492
		public static Offset<AdventureTeamTable> CreateAdventureTeamTable(FlatBufferBuilder builder, int ID = 0, StringOffset ExpOffset = default(StringOffset), int ClearDungeonExpAddition = 0, StringOffset ExpSourceOffset = default(StringOffset), StringOffset PropertyIncomeDescOffset = default(StringOffset))
		{
			builder.StartObject(5);
			AdventureTeamTable.AddPropertyIncomeDesc(builder, PropertyIncomeDescOffset);
			AdventureTeamTable.AddExpSource(builder, ExpSourceOffset);
			AdventureTeamTable.AddClearDungeonExpAddition(builder, ClearDungeonExpAddition);
			AdventureTeamTable.AddExp(builder, ExpOffset);
			AdventureTeamTable.AddID(builder, ID);
			return AdventureTeamTable.EndAdventureTeamTable(builder);
		}

		// Token: 0x060017B2 RID: 6066 RVA: 0x000720C6 File Offset: 0x000704C6
		public static void StartAdventureTeamTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060017B3 RID: 6067 RVA: 0x000720CF File Offset: 0x000704CF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060017B4 RID: 6068 RVA: 0x000720DA File Offset: 0x000704DA
		public static void AddExp(FlatBufferBuilder builder, StringOffset ExpOffset)
		{
			builder.AddOffset(1, ExpOffset.Value, 0);
		}

		// Token: 0x060017B5 RID: 6069 RVA: 0x000720EB File Offset: 0x000704EB
		public static void AddClearDungeonExpAddition(FlatBufferBuilder builder, int ClearDungeonExpAddition)
		{
			builder.AddInt(2, ClearDungeonExpAddition, 0);
		}

		// Token: 0x060017B6 RID: 6070 RVA: 0x000720F6 File Offset: 0x000704F6
		public static void AddExpSource(FlatBufferBuilder builder, StringOffset ExpSourceOffset)
		{
			builder.AddOffset(3, ExpSourceOffset.Value, 0);
		}

		// Token: 0x060017B7 RID: 6071 RVA: 0x00072107 File Offset: 0x00070507
		public static void AddPropertyIncomeDesc(FlatBufferBuilder builder, StringOffset PropertyIncomeDescOffset)
		{
			builder.AddOffset(4, PropertyIncomeDescOffset.Value, 0);
		}

		// Token: 0x060017B8 RID: 6072 RVA: 0x00072118 File Offset: 0x00070518
		public static Offset<AdventureTeamTable> EndAdventureTeamTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventureTeamTable>(value);
		}

		// Token: 0x060017B9 RID: 6073 RVA: 0x00072132 File Offset: 0x00070532
		public static void FinishAdventureTeamTableBuffer(FlatBufferBuilder builder, Offset<AdventureTeamTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DDC RID: 3548
		private Table __p = new Table();

		// Token: 0x02000299 RID: 665
		public enum eCrypt
		{
			// Token: 0x04000DDE RID: 3550
			code = 847890401
		}
	}
}
