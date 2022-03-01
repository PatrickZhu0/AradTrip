using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005F6 RID: 1526
	public class TeamCopyValueTable : IFlatbufferObject
	{
		// Token: 0x17001652 RID: 5714
		// (get) Token: 0x060050E0 RID: 20704 RVA: 0x000F9A08 File Offset: 0x000F7E08
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060050E1 RID: 20705 RVA: 0x000F9A15 File Offset: 0x000F7E15
		public static TeamCopyValueTable GetRootAsTeamCopyValueTable(ByteBuffer _bb)
		{
			return TeamCopyValueTable.GetRootAsTeamCopyValueTable(_bb, new TeamCopyValueTable());
		}

		// Token: 0x060050E2 RID: 20706 RVA: 0x000F9A22 File Offset: 0x000F7E22
		public static TeamCopyValueTable GetRootAsTeamCopyValueTable(ByteBuffer _bb, TeamCopyValueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060050E3 RID: 20707 RVA: 0x000F9A3E File Offset: 0x000F7E3E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060050E4 RID: 20708 RVA: 0x000F9A58 File Offset: 0x000F7E58
		public TeamCopyValueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001653 RID: 5715
		// (get) Token: 0x060050E5 RID: 20709 RVA: 0x000F9A64 File Offset: 0x000F7E64
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (695857601 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001654 RID: 5716
		// (get) Token: 0x060050E6 RID: 20710 RVA: 0x000F9AB0 File Offset: 0x000F7EB0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050E7 RID: 20711 RVA: 0x000F9AF2 File Offset: 0x000F7EF2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001655 RID: 5717
		// (get) Token: 0x060050E8 RID: 20712 RVA: 0x000F9B00 File Offset: 0x000F7F00
		public int Value
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (695857601 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060050E9 RID: 20713 RVA: 0x000F9B49 File Offset: 0x000F7F49
		public static Offset<TeamCopyValueTable> CreateTeamCopyValueTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Value = 0)
		{
			builder.StartObject(3);
			TeamCopyValueTable.AddValue(builder, Value);
			TeamCopyValueTable.AddName(builder, NameOffset);
			TeamCopyValueTable.AddID(builder, ID);
			return TeamCopyValueTable.EndTeamCopyValueTable(builder);
		}

		// Token: 0x060050EA RID: 20714 RVA: 0x000F9B6D File Offset: 0x000F7F6D
		public static void StartTeamCopyValueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x060050EB RID: 20715 RVA: 0x000F9B76 File Offset: 0x000F7F76
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060050EC RID: 20716 RVA: 0x000F9B81 File Offset: 0x000F7F81
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x060050ED RID: 20717 RVA: 0x000F9B92 File Offset: 0x000F7F92
		public static void AddValue(FlatBufferBuilder builder, int Value)
		{
			builder.AddInt(2, Value, 0);
		}

		// Token: 0x060050EE RID: 20718 RVA: 0x000F9BA0 File Offset: 0x000F7FA0
		public static Offset<TeamCopyValueTable> EndTeamCopyValueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyValueTable>(value);
		}

		// Token: 0x060050EF RID: 20719 RVA: 0x000F9BBA File Offset: 0x000F7FBA
		public static void FinishTeamCopyValueTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyValueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DF6 RID: 7670
		private Table __p = new Table();

		// Token: 0x020005F7 RID: 1527
		public enum eCrypt
		{
			// Token: 0x04001DF8 RID: 7672
			code = 695857601
		}
	}
}
