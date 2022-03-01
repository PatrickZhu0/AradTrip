using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002C6 RID: 710
	public class AuctionRecoveItemTable : IFlatbufferObject
	{
		// Token: 0x170003E4 RID: 996
		// (get) Token: 0x06001959 RID: 6489 RVA: 0x000757B4 File Offset: 0x00073BB4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600195A RID: 6490 RVA: 0x000757C1 File Offset: 0x00073BC1
		public static AuctionRecoveItemTable GetRootAsAuctionRecoveItemTable(ByteBuffer _bb)
		{
			return AuctionRecoveItemTable.GetRootAsAuctionRecoveItemTable(_bb, new AuctionRecoveItemTable());
		}

		// Token: 0x0600195B RID: 6491 RVA: 0x000757CE File Offset: 0x00073BCE
		public static AuctionRecoveItemTable GetRootAsAuctionRecoveItemTable(ByteBuffer _bb, AuctionRecoveItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600195C RID: 6492 RVA: 0x000757EA File Offset: 0x00073BEA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600195D RID: 6493 RVA: 0x00075804 File Offset: 0x00073C04
		public AuctionRecoveItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003E5 RID: 997
		// (get) Token: 0x0600195E RID: 6494 RVA: 0x00075810 File Offset: 0x00073C10
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-359186944 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003E6 RID: 998
		// (get) Token: 0x0600195F RID: 6495 RVA: 0x0007585C File Offset: 0x00073C5C
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001960 RID: 6496 RVA: 0x0007589E File Offset: 0x00073C9E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170003E7 RID: 999
		// (get) Token: 0x06001961 RID: 6497 RVA: 0x000758AC File Offset: 0x00073CAC
		public int SysRecoPriceRate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-359186944 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001962 RID: 6498 RVA: 0x000758F5 File Offset: 0x00073CF5
		public static Offset<AuctionRecoveItemTable> CreateAuctionRecoveItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int SysRecoPriceRate = 0)
		{
			builder.StartObject(3);
			AuctionRecoveItemTable.AddSysRecoPriceRate(builder, SysRecoPriceRate);
			AuctionRecoveItemTable.AddName(builder, NameOffset);
			AuctionRecoveItemTable.AddID(builder, ID);
			return AuctionRecoveItemTable.EndAuctionRecoveItemTable(builder);
		}

		// Token: 0x06001963 RID: 6499 RVA: 0x00075919 File Offset: 0x00073D19
		public static void StartAuctionRecoveItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001964 RID: 6500 RVA: 0x00075922 File Offset: 0x00073D22
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001965 RID: 6501 RVA: 0x0007592D File Offset: 0x00073D2D
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001966 RID: 6502 RVA: 0x0007593E File Offset: 0x00073D3E
		public static void AddSysRecoPriceRate(FlatBufferBuilder builder, int SysRecoPriceRate)
		{
			builder.AddInt(2, SysRecoPriceRate, 0);
		}

		// Token: 0x06001967 RID: 6503 RVA: 0x0007594C File Offset: 0x00073D4C
		public static Offset<AuctionRecoveItemTable> EndAuctionRecoveItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionRecoveItemTable>(value);
		}

		// Token: 0x06001968 RID: 6504 RVA: 0x00075966 File Offset: 0x00073D66
		public static void FinishAuctionRecoveItemTableBuffer(FlatBufferBuilder builder, Offset<AuctionRecoveItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E87 RID: 3719
		private Table __p = new Table();

		// Token: 0x020002C7 RID: 711
		public enum eCrypt
		{
			// Token: 0x04000E89 RID: 3721
			code = -359186944
		}
	}
}
