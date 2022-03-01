using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000397 RID: 919
	public class DungeonDailyDropTable : IFlatbufferObject
	{
		// Token: 0x170008EE RID: 2286
		// (get) Token: 0x060027FA RID: 10234 RVA: 0x00099080 File Offset: 0x00097480
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060027FB RID: 10235 RVA: 0x0009908D File Offset: 0x0009748D
		public static DungeonDailyDropTable GetRootAsDungeonDailyDropTable(ByteBuffer _bb)
		{
			return DungeonDailyDropTable.GetRootAsDungeonDailyDropTable(_bb, new DungeonDailyDropTable());
		}

		// Token: 0x060027FC RID: 10236 RVA: 0x0009909A File Offset: 0x0009749A
		public static DungeonDailyDropTable GetRootAsDungeonDailyDropTable(ByteBuffer _bb, DungeonDailyDropTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060027FD RID: 10237 RVA: 0x000990B6 File Offset: 0x000974B6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060027FE RID: 10238 RVA: 0x000990D0 File Offset: 0x000974D0
		public DungeonDailyDropTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008EF RID: 2287
		// (get) Token: 0x060027FF RID: 10239 RVA: 0x000990DC File Offset: 0x000974DC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (223055862 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06002800 RID: 10240 RVA: 0x00099128 File Offset: 0x00097528
		public int DailyLimit
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (223055862 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x06002801 RID: 10241 RVA: 0x00099174 File Offset: 0x00097574
		public string Items
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002802 RID: 10242 RVA: 0x000991B6 File Offset: 0x000975B6
		public ArraySegment<byte>? GetItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06002803 RID: 10243 RVA: 0x000991C4 File Offset: 0x000975C4
		public static Offset<DungeonDailyDropTable> CreateDungeonDailyDropTable(FlatBufferBuilder builder, int ID = 0, int DailyLimit = 0, StringOffset ItemsOffset = default(StringOffset))
		{
			builder.StartObject(3);
			DungeonDailyDropTable.AddItems(builder, ItemsOffset);
			DungeonDailyDropTable.AddDailyLimit(builder, DailyLimit);
			DungeonDailyDropTable.AddID(builder, ID);
			return DungeonDailyDropTable.EndDungeonDailyDropTable(builder);
		}

		// Token: 0x06002804 RID: 10244 RVA: 0x000991E8 File Offset: 0x000975E8
		public static void StartDungeonDailyDropTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002805 RID: 10245 RVA: 0x000991F1 File Offset: 0x000975F1
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002806 RID: 10246 RVA: 0x000991FC File Offset: 0x000975FC
		public static void AddDailyLimit(FlatBufferBuilder builder, int DailyLimit)
		{
			builder.AddInt(1, DailyLimit, 0);
		}

		// Token: 0x06002807 RID: 10247 RVA: 0x00099207 File Offset: 0x00097607
		public static void AddItems(FlatBufferBuilder builder, StringOffset ItemsOffset)
		{
			builder.AddOffset(2, ItemsOffset.Value, 0);
		}

		// Token: 0x06002808 RID: 10248 RVA: 0x00099218 File Offset: 0x00097618
		public static Offset<DungeonDailyDropTable> EndDungeonDailyDropTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonDailyDropTable>(value);
		}

		// Token: 0x06002809 RID: 10249 RVA: 0x00099232 File Offset: 0x00097632
		public static void FinishDungeonDailyDropTableBuffer(FlatBufferBuilder builder, Offset<DungeonDailyDropTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011D4 RID: 4564
		private Table __p = new Table();

		// Token: 0x02000398 RID: 920
		public enum eCrypt
		{
			// Token: 0x040011D6 RID: 4566
			code = 223055862
		}
	}
}
