using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004FA RID: 1274
	public class MasterSysGiftTable : IFlatbufferObject
	{
		// Token: 0x1700112A RID: 4394
		// (get) Token: 0x0600410F RID: 16655 RVA: 0x000D4F94 File Offset: 0x000D3394
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004110 RID: 16656 RVA: 0x000D4FA1 File Offset: 0x000D33A1
		public static MasterSysGiftTable GetRootAsMasterSysGiftTable(ByteBuffer _bb)
		{
			return MasterSysGiftTable.GetRootAsMasterSysGiftTable(_bb, new MasterSysGiftTable());
		}

		// Token: 0x06004111 RID: 16657 RVA: 0x000D4FAE File Offset: 0x000D33AE
		public static MasterSysGiftTable GetRootAsMasterSysGiftTable(ByteBuffer _bb, MasterSysGiftTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004112 RID: 16658 RVA: 0x000D4FCA File Offset: 0x000D33CA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004113 RID: 16659 RVA: 0x000D4FE4 File Offset: 0x000D33E4
		public MasterSysGiftTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700112B RID: 4395
		// (get) Token: 0x06004114 RID: 16660 RVA: 0x000D4FF0 File Offset: 0x000D33F0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (387393975 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700112C RID: 4396
		// (get) Token: 0x06004115 RID: 16661 RVA: 0x000D503C File Offset: 0x000D343C
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (387393975 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700112D RID: 4397
		// (get) Token: 0x06004116 RID: 16662 RVA: 0x000D5088 File Offset: 0x000D3488
		public int Param
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (387393975 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700112E RID: 4398
		// (get) Token: 0x06004117 RID: 16663 RVA: 0x000D50D4 File Offset: 0x000D34D4
		public int GiftId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (387393975 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700112F RID: 4399
		// (get) Token: 0x06004118 RID: 16664 RVA: 0x000D5120 File Offset: 0x000D3520
		public string CounterKey
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004119 RID: 16665 RVA: 0x000D5163 File Offset: 0x000D3563
		public ArraySegment<byte>? GetCounterKeyBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001130 RID: 4400
		// (get) Token: 0x0600411A RID: 16666 RVA: 0x000D5174 File Offset: 0x000D3574
		public int Rate
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (387393975 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001131 RID: 4401
		// (get) Token: 0x0600411B RID: 16667 RVA: 0x000D51C0 File Offset: 0x000D35C0
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600411C RID: 16668 RVA: 0x000D5203 File Offset: 0x000D3603
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x0600411D RID: 16669 RVA: 0x000D5214 File Offset: 0x000D3614
		public static Offset<MasterSysGiftTable> CreateMasterSysGiftTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Param = 0, int GiftId = 0, StringOffset CounterKeyOffset = default(StringOffset), int Rate = 0, StringOffset DescOffset = default(StringOffset))
		{
			builder.StartObject(7);
			MasterSysGiftTable.AddDesc(builder, DescOffset);
			MasterSysGiftTable.AddRate(builder, Rate);
			MasterSysGiftTable.AddCounterKey(builder, CounterKeyOffset);
			MasterSysGiftTable.AddGiftId(builder, GiftId);
			MasterSysGiftTable.AddParam(builder, Param);
			MasterSysGiftTable.AddType(builder, Type);
			MasterSysGiftTable.AddID(builder, ID);
			return MasterSysGiftTable.EndMasterSysGiftTable(builder);
		}

		// Token: 0x0600411E RID: 16670 RVA: 0x000D5263 File Offset: 0x000D3663
		public static void StartMasterSysGiftTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600411F RID: 16671 RVA: 0x000D526C File Offset: 0x000D366C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004120 RID: 16672 RVA: 0x000D5277 File Offset: 0x000D3677
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x06004121 RID: 16673 RVA: 0x000D5282 File Offset: 0x000D3682
		public static void AddParam(FlatBufferBuilder builder, int Param)
		{
			builder.AddInt(2, Param, 0);
		}

		// Token: 0x06004122 RID: 16674 RVA: 0x000D528D File Offset: 0x000D368D
		public static void AddGiftId(FlatBufferBuilder builder, int GiftId)
		{
			builder.AddInt(3, GiftId, 0);
		}

		// Token: 0x06004123 RID: 16675 RVA: 0x000D5298 File Offset: 0x000D3698
		public static void AddCounterKey(FlatBufferBuilder builder, StringOffset CounterKeyOffset)
		{
			builder.AddOffset(4, CounterKeyOffset.Value, 0);
		}

		// Token: 0x06004124 RID: 16676 RVA: 0x000D52A9 File Offset: 0x000D36A9
		public static void AddRate(FlatBufferBuilder builder, int Rate)
		{
			builder.AddInt(5, Rate, 0);
		}

		// Token: 0x06004125 RID: 16677 RVA: 0x000D52B4 File Offset: 0x000D36B4
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(6, DescOffset.Value, 0);
		}

		// Token: 0x06004126 RID: 16678 RVA: 0x000D52C8 File Offset: 0x000D36C8
		public static Offset<MasterSysGiftTable> EndMasterSysGiftTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MasterSysGiftTable>(value);
		}

		// Token: 0x06004127 RID: 16679 RVA: 0x000D52E2 File Offset: 0x000D36E2
		public static void FinishMasterSysGiftTableBuffer(FlatBufferBuilder builder, Offset<MasterSysGiftTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400186A RID: 6250
		private Table __p = new Table();

		// Token: 0x020004FB RID: 1275
		public enum eCrypt
		{
			// Token: 0x0400186C RID: 6252
			code = 387393975
		}
	}
}
