using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000263 RID: 611
	public class AccountCounterTable : IFlatbufferObject
	{
		// Token: 0x1700023E RID: 574
		// (get) Token: 0x060013F4 RID: 5108 RVA: 0x00069AD0 File Offset: 0x00067ED0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060013F5 RID: 5109 RVA: 0x00069ADD File Offset: 0x00067EDD
		public static AccountCounterTable GetRootAsAccountCounterTable(ByteBuffer _bb)
		{
			return AccountCounterTable.GetRootAsAccountCounterTable(_bb, new AccountCounterTable());
		}

		// Token: 0x060013F6 RID: 5110 RVA: 0x00069AEA File Offset: 0x00067EEA
		public static AccountCounterTable GetRootAsAccountCounterTable(ByteBuffer _bb, AccountCounterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060013F7 RID: 5111 RVA: 0x00069B06 File Offset: 0x00067F06
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060013F8 RID: 5112 RVA: 0x00069B20 File Offset: 0x00067F20
		public AccountCounterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700023F RID: 575
		// (get) Token: 0x060013F9 RID: 5113 RVA: 0x00069B2C File Offset: 0x00067F2C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (44849655 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000240 RID: 576
		// (get) Token: 0x060013FA RID: 5114 RVA: 0x00069B78 File Offset: 0x00067F78
		public AccountCounterTable.eAccountCounterType AccountCounterType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (AccountCounterTable.eAccountCounterType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000241 RID: 577
		// (get) Token: 0x060013FB RID: 5115 RVA: 0x00069BBC File Offset: 0x00067FBC
		public int RefreshType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (44849655 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000242 RID: 578
		// (get) Token: 0x060013FC RID: 5116 RVA: 0x00069C08 File Offset: 0x00068008
		public string RefreshTimePoint
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060013FD RID: 5117 RVA: 0x00069C4B File Offset: 0x0006804B
		public ArraySegment<byte>? GetRefreshTimePointBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x060013FE RID: 5118 RVA: 0x00069C5A File Offset: 0x0006805A
		public static Offset<AccountCounterTable> CreateAccountCounterTable(FlatBufferBuilder builder, int ID = 0, AccountCounterTable.eAccountCounterType AccountCounterType = AccountCounterTable.eAccountCounterType.ACC_COUNTER_INVALID, int RefreshType = 0, StringOffset RefreshTimePointOffset = default(StringOffset))
		{
			builder.StartObject(4);
			AccountCounterTable.AddRefreshTimePoint(builder, RefreshTimePointOffset);
			AccountCounterTable.AddRefreshType(builder, RefreshType);
			AccountCounterTable.AddAccountCounterType(builder, AccountCounterType);
			AccountCounterTable.AddID(builder, ID);
			return AccountCounterTable.EndAccountCounterTable(builder);
		}

		// Token: 0x060013FF RID: 5119 RVA: 0x00069C86 File Offset: 0x00068086
		public static void StartAccountCounterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001400 RID: 5120 RVA: 0x00069C8F File Offset: 0x0006808F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001401 RID: 5121 RVA: 0x00069C9A File Offset: 0x0006809A
		public static void AddAccountCounterType(FlatBufferBuilder builder, AccountCounterTable.eAccountCounterType AccountCounterType)
		{
			builder.AddInt(1, (int)AccountCounterType, 0);
		}

		// Token: 0x06001402 RID: 5122 RVA: 0x00069CA5 File Offset: 0x000680A5
		public static void AddRefreshType(FlatBufferBuilder builder, int RefreshType)
		{
			builder.AddInt(2, RefreshType, 0);
		}

		// Token: 0x06001403 RID: 5123 RVA: 0x00069CB0 File Offset: 0x000680B0
		public static void AddRefreshTimePoint(FlatBufferBuilder builder, StringOffset RefreshTimePointOffset)
		{
			builder.AddOffset(3, RefreshTimePointOffset.Value, 0);
		}

		// Token: 0x06001404 RID: 5124 RVA: 0x00069CC4 File Offset: 0x000680C4
		public static Offset<AccountCounterTable> EndAccountCounterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AccountCounterTable>(value);
		}

		// Token: 0x06001405 RID: 5125 RVA: 0x00069CDE File Offset: 0x000680DE
		public static void FinishAccountCounterTableBuffer(FlatBufferBuilder builder, Offset<AccountCounterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D53 RID: 3411
		private Table __p = new Table();

		// Token: 0x02000264 RID: 612
		public enum eAccountCounterType
		{
			// Token: 0x04000D55 RID: 3413
			ACC_COUNTER_INVALID,
			// Token: 0x04000D56 RID: 3414
			ACC_COUNTER_BLESS_CRYSTAL,
			// Token: 0x04000D57 RID: 3415
			ACC_COUNTER_BLESS_CRYSTAL_EXP,
			// Token: 0x04000D58 RID: 3416
			ACC_COUNTER_INHERIT_BLESS,
			// Token: 0x04000D59 RID: 3417
			ACC_COUNTER_INHERIT_BLESS_EXP,
			// Token: 0x04000D5A RID: 3418
			ACC_COUNTER_BOUNTY = 6,
			// Token: 0x04000D5B RID: 3419
			ACC_GUILD_REDPACKET_DAILY_MAX,
			// Token: 0x04000D5C RID: 3420
			ACC_COUNTER_LOGIC_WEEK_REFRESH = 100
		}

		// Token: 0x02000265 RID: 613
		public enum eCrypt
		{
			// Token: 0x04000D5E RID: 3422
			code = 44849655
		}
	}
}
