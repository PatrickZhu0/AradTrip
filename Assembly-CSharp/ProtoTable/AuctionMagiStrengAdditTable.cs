using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002B8 RID: 696
	public class AuctionMagiStrengAdditTable : IFlatbufferObject
	{
		// Token: 0x170003B0 RID: 944
		// (get) Token: 0x060018AE RID: 6318 RVA: 0x00073FC4 File Offset: 0x000723C4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060018AF RID: 6319 RVA: 0x00073FD1 File Offset: 0x000723D1
		public static AuctionMagiStrengAdditTable GetRootAsAuctionMagiStrengAdditTable(ByteBuffer _bb)
		{
			return AuctionMagiStrengAdditTable.GetRootAsAuctionMagiStrengAdditTable(_bb, new AuctionMagiStrengAdditTable());
		}

		// Token: 0x060018B0 RID: 6320 RVA: 0x00073FDE File Offset: 0x000723DE
		public static AuctionMagiStrengAdditTable GetRootAsAuctionMagiStrengAdditTable(ByteBuffer _bb, AuctionMagiStrengAdditTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060018B1 RID: 6321 RVA: 0x00073FFA File Offset: 0x000723FA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060018B2 RID: 6322 RVA: 0x00074014 File Offset: 0x00072414
		public AuctionMagiStrengAdditTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003B1 RID: 945
		// (get) Token: 0x060018B3 RID: 6323 RVA: 0x00074020 File Offset: 0x00072420
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1342041522 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003B2 RID: 946
		// (get) Token: 0x060018B4 RID: 6324 RVA: 0x0007406C File Offset: 0x0007246C
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1342041522 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003B3 RID: 947
		// (get) Token: 0x060018B5 RID: 6325 RVA: 0x000740B8 File Offset: 0x000724B8
		public int StrengthenLv
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1342041522 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003B4 RID: 948
		// (get) Token: 0x060018B6 RID: 6326 RVA: 0x00074104 File Offset: 0x00072504
		public int Color
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1342041522 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003B5 RID: 949
		// (get) Token: 0x060018B7 RID: 6327 RVA: 0x00074150 File Offset: 0x00072550
		public int StrengthenAddition
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1342041522 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060018B8 RID: 6328 RVA: 0x0007419A File Offset: 0x0007259A
		public static Offset<AuctionMagiStrengAdditTable> CreateAuctionMagiStrengAdditTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int StrengthenLv = 0, int Color = 0, int StrengthenAddition = 0)
		{
			builder.StartObject(5);
			AuctionMagiStrengAdditTable.AddStrengthenAddition(builder, StrengthenAddition);
			AuctionMagiStrengAdditTable.AddColor(builder, Color);
			AuctionMagiStrengAdditTable.AddStrengthenLv(builder, StrengthenLv);
			AuctionMagiStrengAdditTable.AddType(builder, Type);
			AuctionMagiStrengAdditTable.AddID(builder, ID);
			return AuctionMagiStrengAdditTable.EndAuctionMagiStrengAdditTable(builder);
		}

		// Token: 0x060018B9 RID: 6329 RVA: 0x000741CE File Offset: 0x000725CE
		public static void StartAuctionMagiStrengAdditTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060018BA RID: 6330 RVA: 0x000741D7 File Offset: 0x000725D7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060018BB RID: 6331 RVA: 0x000741E2 File Offset: 0x000725E2
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060018BC RID: 6332 RVA: 0x000741ED File Offset: 0x000725ED
		public static void AddStrengthenLv(FlatBufferBuilder builder, int StrengthenLv)
		{
			builder.AddInt(2, StrengthenLv, 0);
		}

		// Token: 0x060018BD RID: 6333 RVA: 0x000741F8 File Offset: 0x000725F8
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(3, Color, 0);
		}

		// Token: 0x060018BE RID: 6334 RVA: 0x00074203 File Offset: 0x00072603
		public static void AddStrengthenAddition(FlatBufferBuilder builder, int StrengthenAddition)
		{
			builder.AddInt(4, StrengthenAddition, 0);
		}

		// Token: 0x060018BF RID: 6335 RVA: 0x00074210 File Offset: 0x00072610
		public static Offset<AuctionMagiStrengAdditTable> EndAuctionMagiStrengAdditTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionMagiStrengAdditTable>(value);
		}

		// Token: 0x060018C0 RID: 6336 RVA: 0x0007422A File Offset: 0x0007262A
		public static void FinishAuctionMagiStrengAdditTableBuffer(FlatBufferBuilder builder, Offset<AuctionMagiStrengAdditTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E56 RID: 3670
		private Table __p = new Table();

		// Token: 0x020002B9 RID: 697
		public enum eCrypt
		{
			// Token: 0x04000E58 RID: 3672
			code = 1342041522
		}
	}
}
