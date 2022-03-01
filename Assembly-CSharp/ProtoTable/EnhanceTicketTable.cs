using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003C1 RID: 961
	public class EnhanceTicketTable : IFlatbufferObject
	{
		// Token: 0x17000A0E RID: 2574
		// (get) Token: 0x06002B43 RID: 11075 RVA: 0x000A1484 File Offset: 0x0009F884
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002B44 RID: 11076 RVA: 0x000A1491 File Offset: 0x0009F891
		public static EnhanceTicketTable GetRootAsEnhanceTicketTable(ByteBuffer _bb)
		{
			return EnhanceTicketTable.GetRootAsEnhanceTicketTable(_bb, new EnhanceTicketTable());
		}

		// Token: 0x06002B45 RID: 11077 RVA: 0x000A149E File Offset: 0x0009F89E
		public static EnhanceTicketTable GetRootAsEnhanceTicketTable(ByteBuffer _bb, EnhanceTicketTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002B46 RID: 11078 RVA: 0x000A14BA File Offset: 0x0009F8BA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002B47 RID: 11079 RVA: 0x000A14D4 File Offset: 0x0009F8D4
		public EnhanceTicketTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A0F RID: 2575
		// (get) Token: 0x06002B48 RID: 11080 RVA: 0x000A14E0 File Offset: 0x0009F8E0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1440573236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A10 RID: 2576
		// (get) Token: 0x06002B49 RID: 11081 RVA: 0x000A152C File Offset: 0x0009F92C
		public int Probility
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1440573236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A11 RID: 2577
		// (get) Token: 0x06002B4A RID: 11082 RVA: 0x000A1578 File Offset: 0x0009F978
		public int Level
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1440573236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A12 RID: 2578
		// (get) Token: 0x06002B4B RID: 11083 RVA: 0x000A15C4 File Offset: 0x0009F9C4
		public string desc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002B4C RID: 11084 RVA: 0x000A1607 File Offset: 0x0009FA07
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000A13 RID: 2579
		// (get) Token: 0x06002B4D RID: 11085 RVA: 0x000A1618 File Offset: 0x0009FA18
		public int Compound
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1440573236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000A14 RID: 2580
		// (get) Token: 0x06002B4E RID: 11086 RVA: 0x000A1664 File Offset: 0x0009FA64
		public int FuseValue
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1440573236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002B4F RID: 11087 RVA: 0x000A16AE File Offset: 0x0009FAAE
		public static Offset<EnhanceTicketTable> CreateEnhanceTicketTable(FlatBufferBuilder builder, int ID = 0, int Probility = 0, int Level = 0, StringOffset descOffset = default(StringOffset), int Compound = 0, int FuseValue = 0)
		{
			builder.StartObject(6);
			EnhanceTicketTable.AddFuseValue(builder, FuseValue);
			EnhanceTicketTable.AddCompound(builder, Compound);
			EnhanceTicketTable.AddDesc(builder, descOffset);
			EnhanceTicketTable.AddLevel(builder, Level);
			EnhanceTicketTable.AddProbility(builder, Probility);
			EnhanceTicketTable.AddID(builder, ID);
			return EnhanceTicketTable.EndEnhanceTicketTable(builder);
		}

		// Token: 0x06002B50 RID: 11088 RVA: 0x000A16EA File Offset: 0x0009FAEA
		public static void StartEnhanceTicketTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06002B51 RID: 11089 RVA: 0x000A16F3 File Offset: 0x0009FAF3
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002B52 RID: 11090 RVA: 0x000A16FE File Offset: 0x0009FAFE
		public static void AddProbility(FlatBufferBuilder builder, int Probility)
		{
			builder.AddInt(1, Probility, 0);
		}

		// Token: 0x06002B53 RID: 11091 RVA: 0x000A1709 File Offset: 0x0009FB09
		public static void AddLevel(FlatBufferBuilder builder, int Level)
		{
			builder.AddInt(2, Level, 0);
		}

		// Token: 0x06002B54 RID: 11092 RVA: 0x000A1714 File Offset: 0x0009FB14
		public static void AddDesc(FlatBufferBuilder builder, StringOffset descOffset)
		{
			builder.AddOffset(3, descOffset.Value, 0);
		}

		// Token: 0x06002B55 RID: 11093 RVA: 0x000A1725 File Offset: 0x0009FB25
		public static void AddCompound(FlatBufferBuilder builder, int Compound)
		{
			builder.AddInt(4, Compound, 0);
		}

		// Token: 0x06002B56 RID: 11094 RVA: 0x000A1730 File Offset: 0x0009FB30
		public static void AddFuseValue(FlatBufferBuilder builder, int FuseValue)
		{
			builder.AddInt(5, FuseValue, 0);
		}

		// Token: 0x06002B57 RID: 11095 RVA: 0x000A173C File Offset: 0x0009FB3C
		public static Offset<EnhanceTicketTable> EndEnhanceTicketTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EnhanceTicketTable>(value);
		}

		// Token: 0x06002B58 RID: 11096 RVA: 0x000A1756 File Offset: 0x0009FB56
		public static void FinishEnhanceTicketTableBuffer(FlatBufferBuilder builder, Offset<EnhanceTicketTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001284 RID: 4740
		private Table __p = new Table();

		// Token: 0x020003C2 RID: 962
		public enum eCrypt
		{
			// Token: 0x04001286 RID: 4742
			code = -1440573236
		}
	}
}
