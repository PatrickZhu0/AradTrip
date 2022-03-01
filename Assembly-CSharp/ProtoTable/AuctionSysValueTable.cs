using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002C8 RID: 712
	public class AuctionSysValueTable : IFlatbufferObject
	{
		// Token: 0x170003E8 RID: 1000
		// (get) Token: 0x0600196A RID: 6506 RVA: 0x00075988 File Offset: 0x00073D88
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600196B RID: 6507 RVA: 0x00075995 File Offset: 0x00073D95
		public static AuctionSysValueTable GetRootAsAuctionSysValueTable(ByteBuffer _bb)
		{
			return AuctionSysValueTable.GetRootAsAuctionSysValueTable(_bb, new AuctionSysValueTable());
		}

		// Token: 0x0600196C RID: 6508 RVA: 0x000759A2 File Offset: 0x00073DA2
		public static AuctionSysValueTable GetRootAsAuctionSysValueTable(ByteBuffer _bb, AuctionSysValueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600196D RID: 6509 RVA: 0x000759BE File Offset: 0x00073DBE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600196E RID: 6510 RVA: 0x000759D8 File Offset: 0x00073DD8
		public AuctionSysValueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003E9 RID: 1001
		// (get) Token: 0x0600196F RID: 6511 RVA: 0x000759E4 File Offset: 0x00073DE4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1847538387 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003EA RID: 1002
		// (get) Token: 0x06001970 RID: 6512 RVA: 0x00075A30 File Offset: 0x00073E30
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001971 RID: 6513 RVA: 0x00075A72 File Offset: 0x00073E72
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170003EB RID: 1003
		// (get) Token: 0x06001972 RID: 6514 RVA: 0x00075A80 File Offset: 0x00073E80
		public int Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1847538387 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003EC RID: 1004
		// (get) Token: 0x06001973 RID: 6515 RVA: 0x00075ACC File Offset: 0x00073ECC
		public int Value
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1847538387 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001974 RID: 6516 RVA: 0x00075B16 File Offset: 0x00073F16
		public static Offset<AuctionSysValueTable> CreateAuctionSysValueTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int Type = 0, int Value = 0)
		{
			builder.StartObject(4);
			AuctionSysValueTable.AddValue(builder, Value);
			AuctionSysValueTable.AddType(builder, Type);
			AuctionSysValueTable.AddName(builder, NameOffset);
			AuctionSysValueTable.AddID(builder, ID);
			return AuctionSysValueTable.EndAuctionSysValueTable(builder);
		}

		// Token: 0x06001975 RID: 6517 RVA: 0x00075B42 File Offset: 0x00073F42
		public static void StartAuctionSysValueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06001976 RID: 6518 RVA: 0x00075B4B File Offset: 0x00073F4B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001977 RID: 6519 RVA: 0x00075B56 File Offset: 0x00073F56
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001978 RID: 6520 RVA: 0x00075B67 File Offset: 0x00073F67
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(2, Type, 0);
		}

		// Token: 0x06001979 RID: 6521 RVA: 0x00075B72 File Offset: 0x00073F72
		public static void AddValue(FlatBufferBuilder builder, int Value)
		{
			builder.AddInt(3, Value, 0);
		}

		// Token: 0x0600197A RID: 6522 RVA: 0x00075B80 File Offset: 0x00073F80
		public static Offset<AuctionSysValueTable> EndAuctionSysValueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionSysValueTable>(value);
		}

		// Token: 0x0600197B RID: 6523 RVA: 0x00075B9A File Offset: 0x00073F9A
		public static void FinishAuctionSysValueTableBuffer(FlatBufferBuilder builder, Offset<AuctionSysValueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E8A RID: 3722
		private Table __p = new Table();

		// Token: 0x020002C9 RID: 713
		public enum eCrypt
		{
			// Token: 0x04000E8C RID: 3724
			code = 1847538387
		}
	}
}
