using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002CE RID: 718
	public class BeadConvertDropTable : IFlatbufferObject
	{
		// Token: 0x170003FD RID: 1021
		// (get) Token: 0x060019AE RID: 6574 RVA: 0x00076264 File Offset: 0x00074664
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060019AF RID: 6575 RVA: 0x00076271 File Offset: 0x00074671
		public static BeadConvertDropTable GetRootAsBeadConvertDropTable(ByteBuffer _bb)
		{
			return BeadConvertDropTable.GetRootAsBeadConvertDropTable(_bb, new BeadConvertDropTable());
		}

		// Token: 0x060019B0 RID: 6576 RVA: 0x0007627E File Offset: 0x0007467E
		public static BeadConvertDropTable GetRootAsBeadConvertDropTable(ByteBuffer _bb, BeadConvertDropTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060019B1 RID: 6577 RVA: 0x0007629A File Offset: 0x0007469A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060019B2 RID: 6578 RVA: 0x000762B4 File Offset: 0x000746B4
		public BeadConvertDropTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003FE RID: 1022
		// (get) Token: 0x060019B3 RID: 6579 RVA: 0x000762C0 File Offset: 0x000746C0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (514040138 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003FF RID: 1023
		// (get) Token: 0x060019B4 RID: 6580 RVA: 0x0007630C File Offset: 0x0007470C
		public int DropPackID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (514040138 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000400 RID: 1024
		// (get) Token: 0x060019B5 RID: 6581 RVA: 0x00076358 File Offset: 0x00074758
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (514040138 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000401 RID: 1025
		// (get) Token: 0x060019B6 RID: 6582 RVA: 0x000763A4 File Offset: 0x000747A4
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (514040138 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000402 RID: 1026
		// (get) Token: 0x060019B7 RID: 6583 RVA: 0x000763F0 File Offset: 0x000747F0
		public int ItemName
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (514040138 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000403 RID: 1027
		// (get) Token: 0x060019B8 RID: 6584 RVA: 0x0007643C File Offset: 0x0007483C
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (514040138 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000404 RID: 1028
		// (get) Token: 0x060019B9 RID: 6585 RVA: 0x00076488 File Offset: 0x00074888
		public string Text
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060019BA RID: 6586 RVA: 0x000764CB File Offset: 0x000748CB
		public ArraySegment<byte>? GetTextBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x060019BB RID: 6587 RVA: 0x000764DC File Offset: 0x000748DC
		public static Offset<BeadConvertDropTable> CreateBeadConvertDropTable(FlatBufferBuilder builder, int ID = 0, int DropPackID = 0, int ItemID = 0, int ItemNum = 0, int ItemName = 0, int Weight = 0, StringOffset TextOffset = default(StringOffset))
		{
			builder.StartObject(7);
			BeadConvertDropTable.AddText(builder, TextOffset);
			BeadConvertDropTable.AddWeight(builder, Weight);
			BeadConvertDropTable.AddItemName(builder, ItemName);
			BeadConvertDropTable.AddItemNum(builder, ItemNum);
			BeadConvertDropTable.AddItemID(builder, ItemID);
			BeadConvertDropTable.AddDropPackID(builder, DropPackID);
			BeadConvertDropTable.AddID(builder, ID);
			return BeadConvertDropTable.EndBeadConvertDropTable(builder);
		}

		// Token: 0x060019BC RID: 6588 RVA: 0x0007652B File Offset: 0x0007492B
		public static void StartBeadConvertDropTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060019BD RID: 6589 RVA: 0x00076534 File Offset: 0x00074934
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060019BE RID: 6590 RVA: 0x0007653F File Offset: 0x0007493F
		public static void AddDropPackID(FlatBufferBuilder builder, int DropPackID)
		{
			builder.AddInt(1, DropPackID, 0);
		}

		// Token: 0x060019BF RID: 6591 RVA: 0x0007654A File Offset: 0x0007494A
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(2, ItemID, 0);
		}

		// Token: 0x060019C0 RID: 6592 RVA: 0x00076555 File Offset: 0x00074955
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(3, ItemNum, 0);
		}

		// Token: 0x060019C1 RID: 6593 RVA: 0x00076560 File Offset: 0x00074960
		public static void AddItemName(FlatBufferBuilder builder, int ItemName)
		{
			builder.AddInt(4, ItemName, 0);
		}

		// Token: 0x060019C2 RID: 6594 RVA: 0x0007656B File Offset: 0x0007496B
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(5, Weight, 0);
		}

		// Token: 0x060019C3 RID: 6595 RVA: 0x00076576 File Offset: 0x00074976
		public static void AddText(FlatBufferBuilder builder, StringOffset TextOffset)
		{
			builder.AddOffset(6, TextOffset.Value, 0);
		}

		// Token: 0x060019C4 RID: 6596 RVA: 0x00076588 File Offset: 0x00074988
		public static Offset<BeadConvertDropTable> EndBeadConvertDropTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BeadConvertDropTable>(value);
		}

		// Token: 0x060019C5 RID: 6597 RVA: 0x000765A2 File Offset: 0x000749A2
		public static void FinishBeadConvertDropTableBuffer(FlatBufferBuilder builder, Offset<BeadConvertDropTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E93 RID: 3731
		private Table __p = new Table();

		// Token: 0x020002CF RID: 719
		public enum eCrypt
		{
			// Token: 0x04000E95 RID: 3733
			code = 514040138
		}
	}
}
