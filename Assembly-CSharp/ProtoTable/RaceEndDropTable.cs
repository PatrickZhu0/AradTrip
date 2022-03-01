using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000565 RID: 1381
	public class RaceEndDropTable : IFlatbufferObject
	{
		// Token: 0x1700132D RID: 4909
		// (get) Token: 0x0600472E RID: 18222 RVA: 0x000E30FC File Offset: 0x000E14FC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600472F RID: 18223 RVA: 0x000E3109 File Offset: 0x000E1509
		public static RaceEndDropTable GetRootAsRaceEndDropTable(ByteBuffer _bb)
		{
			return RaceEndDropTable.GetRootAsRaceEndDropTable(_bb, new RaceEndDropTable());
		}

		// Token: 0x06004730 RID: 18224 RVA: 0x000E3116 File Offset: 0x000E1516
		public static RaceEndDropTable GetRootAsRaceEndDropTable(ByteBuffer _bb, RaceEndDropTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004731 RID: 18225 RVA: 0x000E3132 File Offset: 0x000E1532
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004732 RID: 18226 RVA: 0x000E314C File Offset: 0x000E154C
		public RaceEndDropTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700132E RID: 4910
		// (get) Token: 0x06004733 RID: 18227 RVA: 0x000E3158 File Offset: 0x000E1558
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2027005669 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700132F RID: 4911
		// (get) Token: 0x06004734 RID: 18228 RVA: 0x000E31A4 File Offset: 0x000E15A4
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (2027005669 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001330 RID: 4912
		// (get) Token: 0x06004735 RID: 18229 RVA: 0x000E31F0 File Offset: 0x000E15F0
		public int LevelRange
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2027005669 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001331 RID: 4913
		// (get) Token: 0x06004736 RID: 18230 RVA: 0x000E323C File Offset: 0x000E163C
		public string DropSets
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004737 RID: 18231 RVA: 0x000E327F File Offset: 0x000E167F
		public ArraySegment<byte>? GetDropSetsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06004738 RID: 18232 RVA: 0x000E328E File Offset: 0x000E168E
		public static Offset<RaceEndDropTable> CreateRaceEndDropTable(FlatBufferBuilder builder, int ID = 0, int DungeonID = 0, int LevelRange = 0, StringOffset DropSetsOffset = default(StringOffset))
		{
			builder.StartObject(4);
			RaceEndDropTable.AddDropSets(builder, DropSetsOffset);
			RaceEndDropTable.AddLevelRange(builder, LevelRange);
			RaceEndDropTable.AddDungeonID(builder, DungeonID);
			RaceEndDropTable.AddID(builder, ID);
			return RaceEndDropTable.EndRaceEndDropTable(builder);
		}

		// Token: 0x06004739 RID: 18233 RVA: 0x000E32BA File Offset: 0x000E16BA
		public static void StartRaceEndDropTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0600473A RID: 18234 RVA: 0x000E32C3 File Offset: 0x000E16C3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600473B RID: 18235 RVA: 0x000E32CE File Offset: 0x000E16CE
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(1, DungeonID, 0);
		}

		// Token: 0x0600473C RID: 18236 RVA: 0x000E32D9 File Offset: 0x000E16D9
		public static void AddLevelRange(FlatBufferBuilder builder, int LevelRange)
		{
			builder.AddInt(2, LevelRange, 0);
		}

		// Token: 0x0600473D RID: 18237 RVA: 0x000E32E4 File Offset: 0x000E16E4
		public static void AddDropSets(FlatBufferBuilder builder, StringOffset DropSetsOffset)
		{
			builder.AddOffset(3, DropSetsOffset.Value, 0);
		}

		// Token: 0x0600473E RID: 18238 RVA: 0x000E32F8 File Offset: 0x000E16F8
		public static Offset<RaceEndDropTable> EndRaceEndDropTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RaceEndDropTable>(value);
		}

		// Token: 0x0600473F RID: 18239 RVA: 0x000E3312 File Offset: 0x000E1712
		public static void FinishRaceEndDropTableBuffer(FlatBufferBuilder builder, Offset<RaceEndDropTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A39 RID: 6713
		private Table __p = new Table();

		// Token: 0x02000566 RID: 1382
		public enum eCrypt
		{
			// Token: 0x04001A3B RID: 6715
			code = 2027005669
		}
	}
}
