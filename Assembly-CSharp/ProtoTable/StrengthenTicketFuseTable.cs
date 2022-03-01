using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005D3 RID: 1491
	public class StrengthenTicketFuseTable : IFlatbufferObject
	{
		// Token: 0x170015C2 RID: 5570
		// (get) Token: 0x06004F13 RID: 20243 RVA: 0x000F5B44 File Offset: 0x000F3F44
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004F14 RID: 20244 RVA: 0x000F5B51 File Offset: 0x000F3F51
		public static StrengthenTicketFuseTable GetRootAsStrengthenTicketFuseTable(ByteBuffer _bb)
		{
			return StrengthenTicketFuseTable.GetRootAsStrengthenTicketFuseTable(_bb, new StrengthenTicketFuseTable());
		}

		// Token: 0x06004F15 RID: 20245 RVA: 0x000F5B5E File Offset: 0x000F3F5E
		public static StrengthenTicketFuseTable GetRootAsStrengthenTicketFuseTable(ByteBuffer _bb, StrengthenTicketFuseTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004F16 RID: 20246 RVA: 0x000F5B7A File Offset: 0x000F3F7A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004F17 RID: 20247 RVA: 0x000F5B94 File Offset: 0x000F3F94
		public StrengthenTicketFuseTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015C3 RID: 5571
		// (get) Token: 0x06004F18 RID: 20248 RVA: 0x000F5BA0 File Offset: 0x000F3FA0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1204053141 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015C4 RID: 5572
		// (get) Token: 0x06004F19 RID: 20249 RVA: 0x000F5BEC File Offset: 0x000F3FEC
		public int StrengthenLv
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1204053141 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015C5 RID: 5573
		// (get) Token: 0x06004F1A RID: 20250 RVA: 0x000F5C38 File Offset: 0x000F4038
		public int FixM
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1204053141 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004F1B RID: 20251 RVA: 0x000F5C81 File Offset: 0x000F4081
		public static Offset<StrengthenTicketFuseTable> CreateStrengthenTicketFuseTable(FlatBufferBuilder builder, int ID = 0, int StrengthenLv = 0, int FixM = 0)
		{
			builder.StartObject(3);
			StrengthenTicketFuseTable.AddFixM(builder, FixM);
			StrengthenTicketFuseTable.AddStrengthenLv(builder, StrengthenLv);
			StrengthenTicketFuseTable.AddID(builder, ID);
			return StrengthenTicketFuseTable.EndStrengthenTicketFuseTable(builder);
		}

		// Token: 0x06004F1C RID: 20252 RVA: 0x000F5CA5 File Offset: 0x000F40A5
		public static void StartStrengthenTicketFuseTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06004F1D RID: 20253 RVA: 0x000F5CAE File Offset: 0x000F40AE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004F1E RID: 20254 RVA: 0x000F5CB9 File Offset: 0x000F40B9
		public static void AddStrengthenLv(FlatBufferBuilder builder, int StrengthenLv)
		{
			builder.AddInt(1, StrengthenLv, 0);
		}

		// Token: 0x06004F1F RID: 20255 RVA: 0x000F5CC4 File Offset: 0x000F40C4
		public static void AddFixM(FlatBufferBuilder builder, int FixM)
		{
			builder.AddInt(2, FixM, 0);
		}

		// Token: 0x06004F20 RID: 20256 RVA: 0x000F5CD0 File Offset: 0x000F40D0
		public static Offset<StrengthenTicketFuseTable> EndStrengthenTicketFuseTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<StrengthenTicketFuseTable>(value);
		}

		// Token: 0x06004F21 RID: 20257 RVA: 0x000F5CEA File Offset: 0x000F40EA
		public static void FinishStrengthenTicketFuseTableBuffer(FlatBufferBuilder builder, Offset<StrengthenTicketFuseTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BDE RID: 7134
		private Table __p = new Table();

		// Token: 0x020005D4 RID: 1492
		public enum eCrypt
		{
			// Token: 0x04001BE0 RID: 7136
			code = 1204053141
		}
	}
}
