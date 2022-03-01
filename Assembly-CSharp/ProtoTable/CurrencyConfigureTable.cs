using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000365 RID: 869
	public class CurrencyConfigureTable : IFlatbufferObject
	{
		// Token: 0x170007FF RID: 2047
		// (get) Token: 0x06002527 RID: 9511 RVA: 0x00092850 File Offset: 0x00090C50
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002528 RID: 9512 RVA: 0x0009285D File Offset: 0x00090C5D
		public static CurrencyConfigureTable GetRootAsCurrencyConfigureTable(ByteBuffer _bb)
		{
			return CurrencyConfigureTable.GetRootAsCurrencyConfigureTable(_bb, new CurrencyConfigureTable());
		}

		// Token: 0x06002529 RID: 9513 RVA: 0x0009286A File Offset: 0x00090C6A
		public static CurrencyConfigureTable GetRootAsCurrencyConfigureTable(ByteBuffer _bb, CurrencyConfigureTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600252A RID: 9514 RVA: 0x00092886 File Offset: 0x00090C86
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600252B RID: 9515 RVA: 0x000928A0 File Offset: 0x00090CA0
		public CurrencyConfigureTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000800 RID: 2048
		// (get) Token: 0x0600252C RID: 9516 RVA: 0x000928AC File Offset: 0x00090CAC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1624557565 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000801 RID: 2049
		// (get) Token: 0x0600252D RID: 9517 RVA: 0x000928F8 File Offset: 0x00090CF8
		public string Des
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600252E RID: 9518 RVA: 0x0009293A File Offset: 0x00090D3A
		public ArraySegment<byte>? GetDesBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000802 RID: 2050
		// (get) Token: 0x0600252F RID: 9519 RVA: 0x00092948 File Offset: 0x00090D48
		public CurrencyConfigureTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (CurrencyConfigureTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000803 RID: 2051
		// (get) Token: 0x06002530 RID: 9520 RVA: 0x0009298C File Offset: 0x00090D8C
		public int CostItemID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1624557565 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000804 RID: 2052
		// (get) Token: 0x06002531 RID: 9521 RVA: 0x000929D8 File Offset: 0x00090DD8
		public int Num
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1624557565 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002532 RID: 9522 RVA: 0x00092A22 File Offset: 0x00090E22
		public static Offset<CurrencyConfigureTable> CreateCurrencyConfigureTable(FlatBufferBuilder builder, int ID = 0, StringOffset DesOffset = default(StringOffset), CurrencyConfigureTable.eType Type = CurrencyConfigureTable.eType.CCT_NONE, int CostItemID = 0, int Num = 0)
		{
			builder.StartObject(5);
			CurrencyConfigureTable.AddNum(builder, Num);
			CurrencyConfigureTable.AddCostItemID(builder, CostItemID);
			CurrencyConfigureTable.AddType(builder, Type);
			CurrencyConfigureTable.AddDes(builder, DesOffset);
			CurrencyConfigureTable.AddID(builder, ID);
			return CurrencyConfigureTable.EndCurrencyConfigureTable(builder);
		}

		// Token: 0x06002533 RID: 9523 RVA: 0x00092A56 File Offset: 0x00090E56
		public static void StartCurrencyConfigureTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06002534 RID: 9524 RVA: 0x00092A5F File Offset: 0x00090E5F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002535 RID: 9525 RVA: 0x00092A6A File Offset: 0x00090E6A
		public static void AddDes(FlatBufferBuilder builder, StringOffset DesOffset)
		{
			builder.AddOffset(1, DesOffset.Value, 0);
		}

		// Token: 0x06002536 RID: 9526 RVA: 0x00092A7B File Offset: 0x00090E7B
		public static void AddType(FlatBufferBuilder builder, CurrencyConfigureTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06002537 RID: 9527 RVA: 0x00092A86 File Offset: 0x00090E86
		public static void AddCostItemID(FlatBufferBuilder builder, int CostItemID)
		{
			builder.AddInt(3, CostItemID, 0);
		}

		// Token: 0x06002538 RID: 9528 RVA: 0x00092A91 File Offset: 0x00090E91
		public static void AddNum(FlatBufferBuilder builder, int Num)
		{
			builder.AddInt(4, Num, 0);
		}

		// Token: 0x06002539 RID: 9529 RVA: 0x00092A9C File Offset: 0x00090E9C
		public static Offset<CurrencyConfigureTable> EndCurrencyConfigureTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<CurrencyConfigureTable>(value);
		}

		// Token: 0x0600253A RID: 9530 RVA: 0x00092AB6 File Offset: 0x00090EB6
		public static void FinishCurrencyConfigureTableBuffer(FlatBufferBuilder builder, Offset<CurrencyConfigureTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001141 RID: 4417
		private Table __p = new Table();

		// Token: 0x02000366 RID: 870
		public enum eType
		{
			// Token: 0x04001143 RID: 4419
			CCT_NONE,
			// Token: 0x04001144 RID: 4420
			CCT_AUCTION_REFRESH
		}

		// Token: 0x02000367 RID: 871
		public enum eCrypt
		{
			// Token: 0x04001146 RID: 4422
			code = 1624557565
		}
	}
}
