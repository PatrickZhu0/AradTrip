using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200053D RID: 1341
	public class OneStrengEnhanceTicketTable : IFlatbufferObject
	{
		// Token: 0x17001271 RID: 4721
		// (get) Token: 0x060044EB RID: 17643 RVA: 0x000DE0A0 File Offset: 0x000DC4A0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060044EC RID: 17644 RVA: 0x000DE0AD File Offset: 0x000DC4AD
		public static OneStrengEnhanceTicketTable GetRootAsOneStrengEnhanceTicketTable(ByteBuffer _bb)
		{
			return OneStrengEnhanceTicketTable.GetRootAsOneStrengEnhanceTicketTable(_bb, new OneStrengEnhanceTicketTable());
		}

		// Token: 0x060044ED RID: 17645 RVA: 0x000DE0BA File Offset: 0x000DC4BA
		public static OneStrengEnhanceTicketTable GetRootAsOneStrengEnhanceTicketTable(ByteBuffer _bb, OneStrengEnhanceTicketTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060044EE RID: 17646 RVA: 0x000DE0D6 File Offset: 0x000DC4D6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060044EF RID: 17647 RVA: 0x000DE0F0 File Offset: 0x000DC4F0
		public OneStrengEnhanceTicketTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001272 RID: 4722
		// (get) Token: 0x060044F0 RID: 17648 RVA: 0x000DE0FC File Offset: 0x000DC4FC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1275521275 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001273 RID: 4723
		// (get) Token: 0x060044F1 RID: 17649 RVA: 0x000DE148 File Offset: 0x000DC548
		public int LvLimitBegin
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1275521275 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001274 RID: 4724
		// (get) Token: 0x060044F2 RID: 17650 RVA: 0x000DE194 File Offset: 0x000DC594
		public int LvLimitEnd
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1275521275 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001275 RID: 4725
		// (get) Token: 0x060044F3 RID: 17651 RVA: 0x000DE1E0 File Offset: 0x000DC5E0
		public int Probility
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1275521275 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001276 RID: 4726
		// (get) Token: 0x060044F4 RID: 17652 RVA: 0x000DE22C File Offset: 0x000DC62C
		public string desc
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060044F5 RID: 17653 RVA: 0x000DE26F File Offset: 0x000DC66F
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x060044F6 RID: 17654 RVA: 0x000DE27E File Offset: 0x000DC67E
		public static Offset<OneStrengEnhanceTicketTable> CreateOneStrengEnhanceTicketTable(FlatBufferBuilder builder, int ID = 0, int LvLimitBegin = 0, int LvLimitEnd = 0, int Probility = 0, StringOffset descOffset = default(StringOffset))
		{
			builder.StartObject(5);
			OneStrengEnhanceTicketTable.AddDesc(builder, descOffset);
			OneStrengEnhanceTicketTable.AddProbility(builder, Probility);
			OneStrengEnhanceTicketTable.AddLvLimitEnd(builder, LvLimitEnd);
			OneStrengEnhanceTicketTable.AddLvLimitBegin(builder, LvLimitBegin);
			OneStrengEnhanceTicketTable.AddID(builder, ID);
			return OneStrengEnhanceTicketTable.EndOneStrengEnhanceTicketTable(builder);
		}

		// Token: 0x060044F7 RID: 17655 RVA: 0x000DE2B2 File Offset: 0x000DC6B2
		public static void StartOneStrengEnhanceTicketTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060044F8 RID: 17656 RVA: 0x000DE2BB File Offset: 0x000DC6BB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060044F9 RID: 17657 RVA: 0x000DE2C6 File Offset: 0x000DC6C6
		public static void AddLvLimitBegin(FlatBufferBuilder builder, int LvLimitBegin)
		{
			builder.AddInt(1, LvLimitBegin, 0);
		}

		// Token: 0x060044FA RID: 17658 RVA: 0x000DE2D1 File Offset: 0x000DC6D1
		public static void AddLvLimitEnd(FlatBufferBuilder builder, int LvLimitEnd)
		{
			builder.AddInt(2, LvLimitEnd, 0);
		}

		// Token: 0x060044FB RID: 17659 RVA: 0x000DE2DC File Offset: 0x000DC6DC
		public static void AddProbility(FlatBufferBuilder builder, int Probility)
		{
			builder.AddInt(3, Probility, 0);
		}

		// Token: 0x060044FC RID: 17660 RVA: 0x000DE2E7 File Offset: 0x000DC6E7
		public static void AddDesc(FlatBufferBuilder builder, StringOffset descOffset)
		{
			builder.AddOffset(4, descOffset.Value, 0);
		}

		// Token: 0x060044FD RID: 17661 RVA: 0x000DE2F8 File Offset: 0x000DC6F8
		public static Offset<OneStrengEnhanceTicketTable> EndOneStrengEnhanceTicketTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<OneStrengEnhanceTicketTable>(value);
		}

		// Token: 0x060044FE RID: 17662 RVA: 0x000DE312 File Offset: 0x000DC712
		public static void FinishOneStrengEnhanceTicketTableBuffer(FlatBufferBuilder builder, Offset<OneStrengEnhanceTicketTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001993 RID: 6547
		private Table __p = new Table();

		// Token: 0x0200053E RID: 1342
		public enum eCrypt
		{
			// Token: 0x04001995 RID: 6549
			code = -1275521275
		}
	}
}
