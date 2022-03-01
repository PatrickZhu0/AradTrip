using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003B1 RID: 945
	public class DungeonTimesTable : IFlatbufferObject
	{
		// Token: 0x170009A5 RID: 2469
		// (get) Token: 0x06002A23 RID: 10787 RVA: 0x0009E55C File Offset: 0x0009C95C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002A24 RID: 10788 RVA: 0x0009E569 File Offset: 0x0009C969
		public static DungeonTimesTable GetRootAsDungeonTimesTable(ByteBuffer _bb)
		{
			return DungeonTimesTable.GetRootAsDungeonTimesTable(_bb, new DungeonTimesTable());
		}

		// Token: 0x06002A25 RID: 10789 RVA: 0x0009E576 File Offset: 0x0009C976
		public static DungeonTimesTable GetRootAsDungeonTimesTable(ByteBuffer _bb, DungeonTimesTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002A26 RID: 10790 RVA: 0x0009E592 File Offset: 0x0009C992
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002A27 RID: 10791 RVA: 0x0009E5AC File Offset: 0x0009C9AC
		public DungeonTimesTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170009A6 RID: 2470
		// (get) Token: 0x06002A28 RID: 10792 RVA: 0x0009E5B8 File Offset: 0x0009C9B8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009A7 RID: 2471
		// (get) Token: 0x06002A29 RID: 10793 RVA: 0x0009E604 File Offset: 0x0009CA04
		public int BaseTimes
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009A8 RID: 2472
		// (get) Token: 0x06002A2A RID: 10794 RVA: 0x0009E650 File Offset: 0x0009CA50
		public int BaseBuyTimes
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009A9 RID: 2473
		// (get) Token: 0x06002A2B RID: 10795 RVA: 0x0009E69C File Offset: 0x0009CA9C
		public int BuyTimesVipPrivilege
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009AA RID: 2474
		// (get) Token: 0x06002A2C RID: 10796 RVA: 0x0009E6E8 File Offset: 0x0009CAE8
		public int BuyTimesCostItemID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002A2D RID: 10797 RVA: 0x0009E734 File Offset: 0x0009CB34
		public int BuyTimesCostArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170009AB RID: 2475
		// (get) Token: 0x06002A2E RID: 10798 RVA: 0x0009E784 File Offset: 0x0009CB84
		public int BuyTimesCostLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002A2F RID: 10799 RVA: 0x0009E7B7 File Offset: 0x0009CBB7
		public ArraySegment<byte>? GetBuyTimesCostBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170009AC RID: 2476
		// (get) Token: 0x06002A30 RID: 10800 RVA: 0x0009E7C6 File Offset: 0x0009CBC6
		public FlatBufferArray<int> BuyTimesCost
		{
			get
			{
				if (this.BuyTimesCostValue == null)
				{
					this.BuyTimesCostValue = new FlatBufferArray<int>(new Func<int, int>(this.BuyTimesCostArray), this.BuyTimesCostLength);
				}
				return this.BuyTimesCostValue;
			}
		}

		// Token: 0x170009AD RID: 2477
		// (get) Token: 0x06002A31 RID: 10801 RVA: 0x0009E7F8 File Offset: 0x0009CBF8
		public string UsedTimesCounter
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A32 RID: 10802 RVA: 0x0009E83B File Offset: 0x0009CC3B
		public ArraySegment<byte>? GetUsedTimesCounterBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170009AE RID: 2478
		// (get) Token: 0x06002A33 RID: 10803 RVA: 0x0009E84C File Offset: 0x0009CC4C
		public string BuyTimesCounter
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A34 RID: 10804 RVA: 0x0009E88F File Offset: 0x0009CC8F
		public ArraySegment<byte>? GetBuyTimesCounterBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170009AF RID: 2479
		// (get) Token: 0x06002A35 RID: 10805 RVA: 0x0009E8A0 File Offset: 0x0009CCA0
		public string WeekUsedTimesCounter
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002A36 RID: 10806 RVA: 0x0009E8E3 File Offset: 0x0009CCE3
		public ArraySegment<byte>? GetWeekUsedTimesCounterBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170009B0 RID: 2480
		// (get) Token: 0x06002A37 RID: 10807 RVA: 0x0009E8F4 File Offset: 0x0009CCF4
		public int WeekTimesLimit
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170009B1 RID: 2481
		// (get) Token: 0x06002A38 RID: 10808 RVA: 0x0009E940 File Offset: 0x0009CD40
		public int AccountDailyTimesLimit
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (23225696 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002A39 RID: 10809 RVA: 0x0009E98C File Offset: 0x0009CD8C
		public static Offset<DungeonTimesTable> CreateDungeonTimesTable(FlatBufferBuilder builder, int ID = 0, int BaseTimes = 0, int BaseBuyTimes = 0, int BuyTimesVipPrivilege = 0, int BuyTimesCostItemID = 0, VectorOffset BuyTimesCostOffset = default(VectorOffset), StringOffset UsedTimesCounterOffset = default(StringOffset), StringOffset BuyTimesCounterOffset = default(StringOffset), StringOffset WeekUsedTimesCounterOffset = default(StringOffset), int WeekTimesLimit = 0, int AccountDailyTimesLimit = 0)
		{
			builder.StartObject(11);
			DungeonTimesTable.AddAccountDailyTimesLimit(builder, AccountDailyTimesLimit);
			DungeonTimesTable.AddWeekTimesLimit(builder, WeekTimesLimit);
			DungeonTimesTable.AddWeekUsedTimesCounter(builder, WeekUsedTimesCounterOffset);
			DungeonTimesTable.AddBuyTimesCounter(builder, BuyTimesCounterOffset);
			DungeonTimesTable.AddUsedTimesCounter(builder, UsedTimesCounterOffset);
			DungeonTimesTable.AddBuyTimesCost(builder, BuyTimesCostOffset);
			DungeonTimesTable.AddBuyTimesCostItemID(builder, BuyTimesCostItemID);
			DungeonTimesTable.AddBuyTimesVipPrivilege(builder, BuyTimesVipPrivilege);
			DungeonTimesTable.AddBaseBuyTimes(builder, BaseBuyTimes);
			DungeonTimesTable.AddBaseTimes(builder, BaseTimes);
			DungeonTimesTable.AddID(builder, ID);
			return DungeonTimesTable.EndDungeonTimesTable(builder);
		}

		// Token: 0x06002A3A RID: 10810 RVA: 0x0009E9FC File Offset: 0x0009CDFC
		public static void StartDungeonTimesTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06002A3B RID: 10811 RVA: 0x0009EA06 File Offset: 0x0009CE06
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002A3C RID: 10812 RVA: 0x0009EA11 File Offset: 0x0009CE11
		public static void AddBaseTimes(FlatBufferBuilder builder, int BaseTimes)
		{
			builder.AddInt(1, BaseTimes, 0);
		}

		// Token: 0x06002A3D RID: 10813 RVA: 0x0009EA1C File Offset: 0x0009CE1C
		public static void AddBaseBuyTimes(FlatBufferBuilder builder, int BaseBuyTimes)
		{
			builder.AddInt(2, BaseBuyTimes, 0);
		}

		// Token: 0x06002A3E RID: 10814 RVA: 0x0009EA27 File Offset: 0x0009CE27
		public static void AddBuyTimesVipPrivilege(FlatBufferBuilder builder, int BuyTimesVipPrivilege)
		{
			builder.AddInt(3, BuyTimesVipPrivilege, 0);
		}

		// Token: 0x06002A3F RID: 10815 RVA: 0x0009EA32 File Offset: 0x0009CE32
		public static void AddBuyTimesCostItemID(FlatBufferBuilder builder, int BuyTimesCostItemID)
		{
			builder.AddInt(4, BuyTimesCostItemID, 0);
		}

		// Token: 0x06002A40 RID: 10816 RVA: 0x0009EA3D File Offset: 0x0009CE3D
		public static void AddBuyTimesCost(FlatBufferBuilder builder, VectorOffset BuyTimesCostOffset)
		{
			builder.AddOffset(5, BuyTimesCostOffset.Value, 0);
		}

		// Token: 0x06002A41 RID: 10817 RVA: 0x0009EA50 File Offset: 0x0009CE50
		public static VectorOffset CreateBuyTimesCostVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002A42 RID: 10818 RVA: 0x0009EA8D File Offset: 0x0009CE8D
		public static void StartBuyTimesCostVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002A43 RID: 10819 RVA: 0x0009EA98 File Offset: 0x0009CE98
		public static void AddUsedTimesCounter(FlatBufferBuilder builder, StringOffset UsedTimesCounterOffset)
		{
			builder.AddOffset(6, UsedTimesCounterOffset.Value, 0);
		}

		// Token: 0x06002A44 RID: 10820 RVA: 0x0009EAA9 File Offset: 0x0009CEA9
		public static void AddBuyTimesCounter(FlatBufferBuilder builder, StringOffset BuyTimesCounterOffset)
		{
			builder.AddOffset(7, BuyTimesCounterOffset.Value, 0);
		}

		// Token: 0x06002A45 RID: 10821 RVA: 0x0009EABA File Offset: 0x0009CEBA
		public static void AddWeekUsedTimesCounter(FlatBufferBuilder builder, StringOffset WeekUsedTimesCounterOffset)
		{
			builder.AddOffset(8, WeekUsedTimesCounterOffset.Value, 0);
		}

		// Token: 0x06002A46 RID: 10822 RVA: 0x0009EACB File Offset: 0x0009CECB
		public static void AddWeekTimesLimit(FlatBufferBuilder builder, int WeekTimesLimit)
		{
			builder.AddInt(9, WeekTimesLimit, 0);
		}

		// Token: 0x06002A47 RID: 10823 RVA: 0x0009EAD7 File Offset: 0x0009CED7
		public static void AddAccountDailyTimesLimit(FlatBufferBuilder builder, int AccountDailyTimesLimit)
		{
			builder.AddInt(10, AccountDailyTimesLimit, 0);
		}

		// Token: 0x06002A48 RID: 10824 RVA: 0x0009EAE4 File Offset: 0x0009CEE4
		public static Offset<DungeonTimesTable> EndDungeonTimesTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DungeonTimesTable>(value);
		}

		// Token: 0x06002A49 RID: 10825 RVA: 0x0009EAFE File Offset: 0x0009CEFE
		public static void FinishDungeonTimesTableBuffer(FlatBufferBuilder builder, Offset<DungeonTimesTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001249 RID: 4681
		private Table __p = new Table();

		// Token: 0x0400124A RID: 4682
		private FlatBufferArray<int> BuyTimesCostValue;

		// Token: 0x020003B2 RID: 946
		public enum eCrypt
		{
			// Token: 0x0400124C RID: 4684
			code = 23225696
		}
	}
}
