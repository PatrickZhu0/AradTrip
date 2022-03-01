using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002CC RID: 716
	public class BeadConvertCostTable : IFlatbufferObject
	{
		// Token: 0x170003F3 RID: 1011
		// (get) Token: 0x06001992 RID: 6546 RVA: 0x00075E50 File Offset: 0x00074250
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001993 RID: 6547 RVA: 0x00075E5D File Offset: 0x0007425D
		public static BeadConvertCostTable GetRootAsBeadConvertCostTable(ByteBuffer _bb)
		{
			return BeadConvertCostTable.GetRootAsBeadConvertCostTable(_bb, new BeadConvertCostTable());
		}

		// Token: 0x06001994 RID: 6548 RVA: 0x00075E6A File Offset: 0x0007426A
		public static BeadConvertCostTable GetRootAsBeadConvertCostTable(ByteBuffer _bb, BeadConvertCostTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001995 RID: 6549 RVA: 0x00075E86 File Offset: 0x00074286
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001996 RID: 6550 RVA: 0x00075EA0 File Offset: 0x000742A0
		public BeadConvertCostTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003F4 RID: 1012
		// (get) Token: 0x06001997 RID: 6551 RVA: 0x00075EAC File Offset: 0x000742AC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F5 RID: 1013
		// (get) Token: 0x06001998 RID: 6552 RVA: 0x00075EF8 File Offset: 0x000742F8
		public int Colour
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F6 RID: 1014
		// (get) Token: 0x06001999 RID: 6553 RVA: 0x00075F44 File Offset: 0x00074344
		public int MoneyCostId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F7 RID: 1015
		// (get) Token: 0x0600199A RID: 6554 RVA: 0x00075F90 File Offset: 0x00074390
		public int MoneyCostNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F8 RID: 1016
		// (get) Token: 0x0600199B RID: 6555 RVA: 0x00075FDC File Offset: 0x000743DC
		public int BeadCost
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003F9 RID: 1017
		// (get) Token: 0x0600199C RID: 6556 RVA: 0x00076028 File Offset: 0x00074428
		public int BeadCostNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003FA RID: 1018
		// (get) Token: 0x0600199D RID: 6557 RVA: 0x00076074 File Offset: 0x00074474
		public int DropId
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003FB RID: 1019
		// (get) Token: 0x0600199E RID: 6558 RVA: 0x000760C0 File Offset: 0x000744C0
		public int BindDropId
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003FC RID: 1020
		// (get) Token: 0x0600199F RID: 6559 RVA: 0x0007610C File Offset: 0x0007450C
		public int ProduceBeadPreview
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (494545148 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060019A0 RID: 6560 RVA: 0x00076158 File Offset: 0x00074558
		public static Offset<BeadConvertCostTable> CreateBeadConvertCostTable(FlatBufferBuilder builder, int ID = 0, int Colour = 0, int MoneyCostId = 0, int MoneyCostNum = 0, int BeadCost = 0, int BeadCostNum = 0, int DropId = 0, int BindDropId = 0, int ProduceBeadPreview = 0)
		{
			builder.StartObject(9);
			BeadConvertCostTable.AddProduceBeadPreview(builder, ProduceBeadPreview);
			BeadConvertCostTable.AddBindDropId(builder, BindDropId);
			BeadConvertCostTable.AddDropId(builder, DropId);
			BeadConvertCostTable.AddBeadCostNum(builder, BeadCostNum);
			BeadConvertCostTable.AddBeadCost(builder, BeadCost);
			BeadConvertCostTable.AddMoneyCostNum(builder, MoneyCostNum);
			BeadConvertCostTable.AddMoneyCostId(builder, MoneyCostId);
			BeadConvertCostTable.AddColour(builder, Colour);
			BeadConvertCostTable.AddID(builder, ID);
			return BeadConvertCostTable.EndBeadConvertCostTable(builder);
		}

		// Token: 0x060019A1 RID: 6561 RVA: 0x000761B8 File Offset: 0x000745B8
		public static void StartBeadConvertCostTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x060019A2 RID: 6562 RVA: 0x000761C2 File Offset: 0x000745C2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060019A3 RID: 6563 RVA: 0x000761CD File Offset: 0x000745CD
		public static void AddColour(FlatBufferBuilder builder, int Colour)
		{
			builder.AddInt(1, Colour, 0);
		}

		// Token: 0x060019A4 RID: 6564 RVA: 0x000761D8 File Offset: 0x000745D8
		public static void AddMoneyCostId(FlatBufferBuilder builder, int MoneyCostId)
		{
			builder.AddInt(2, MoneyCostId, 0);
		}

		// Token: 0x060019A5 RID: 6565 RVA: 0x000761E3 File Offset: 0x000745E3
		public static void AddMoneyCostNum(FlatBufferBuilder builder, int MoneyCostNum)
		{
			builder.AddInt(3, MoneyCostNum, 0);
		}

		// Token: 0x060019A6 RID: 6566 RVA: 0x000761EE File Offset: 0x000745EE
		public static void AddBeadCost(FlatBufferBuilder builder, int BeadCost)
		{
			builder.AddInt(4, BeadCost, 0);
		}

		// Token: 0x060019A7 RID: 6567 RVA: 0x000761F9 File Offset: 0x000745F9
		public static void AddBeadCostNum(FlatBufferBuilder builder, int BeadCostNum)
		{
			builder.AddInt(5, BeadCostNum, 0);
		}

		// Token: 0x060019A8 RID: 6568 RVA: 0x00076204 File Offset: 0x00074604
		public static void AddDropId(FlatBufferBuilder builder, int DropId)
		{
			builder.AddInt(6, DropId, 0);
		}

		// Token: 0x060019A9 RID: 6569 RVA: 0x0007620F File Offset: 0x0007460F
		public static void AddBindDropId(FlatBufferBuilder builder, int BindDropId)
		{
			builder.AddInt(7, BindDropId, 0);
		}

		// Token: 0x060019AA RID: 6570 RVA: 0x0007621A File Offset: 0x0007461A
		public static void AddProduceBeadPreview(FlatBufferBuilder builder, int ProduceBeadPreview)
		{
			builder.AddInt(8, ProduceBeadPreview, 0);
		}

		// Token: 0x060019AB RID: 6571 RVA: 0x00076228 File Offset: 0x00074628
		public static Offset<BeadConvertCostTable> EndBeadConvertCostTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BeadConvertCostTable>(value);
		}

		// Token: 0x060019AC RID: 6572 RVA: 0x00076242 File Offset: 0x00074642
		public static void FinishBeadConvertCostTableBuffer(FlatBufferBuilder builder, Offset<BeadConvertCostTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E90 RID: 3728
		private Table __p = new Table();

		// Token: 0x020002CD RID: 717
		public enum eCrypt
		{
			// Token: 0x04000E92 RID: 3730
			code = 494545148
		}
	}
}
