using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000563 RID: 1379
	public class QuickBuyTable : IFlatbufferObject
	{
		// Token: 0x17001328 RID: 4904
		// (get) Token: 0x0600471C RID: 18204 RVA: 0x000E2ED4 File Offset: 0x000E12D4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600471D RID: 18205 RVA: 0x000E2EE1 File Offset: 0x000E12E1
		public static QuickBuyTable GetRootAsQuickBuyTable(ByteBuffer _bb)
		{
			return QuickBuyTable.GetRootAsQuickBuyTable(_bb, new QuickBuyTable());
		}

		// Token: 0x0600471E RID: 18206 RVA: 0x000E2EEE File Offset: 0x000E12EE
		public static QuickBuyTable GetRootAsQuickBuyTable(ByteBuffer _bb, QuickBuyTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600471F RID: 18207 RVA: 0x000E2F0A File Offset: 0x000E130A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004720 RID: 18208 RVA: 0x000E2F24 File Offset: 0x000E1324
		public QuickBuyTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001329 RID: 4905
		// (get) Token: 0x06004721 RID: 18209 RVA: 0x000E2F30 File Offset: 0x000E1330
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1474022939 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700132A RID: 4906
		// (get) Token: 0x06004722 RID: 18210 RVA: 0x000E2F7C File Offset: 0x000E137C
		public int CostItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1474022939 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700132B RID: 4907
		// (get) Token: 0x06004723 RID: 18211 RVA: 0x000E2FC8 File Offset: 0x000E13C8
		public int CostNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1474022939 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700132C RID: 4908
		// (get) Token: 0x06004724 RID: 18212 RVA: 0x000E3014 File Offset: 0x000E1414
		public int multiple
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1474022939 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004725 RID: 18213 RVA: 0x000E305E File Offset: 0x000E145E
		public static Offset<QuickBuyTable> CreateQuickBuyTable(FlatBufferBuilder builder, int ID = 0, int CostItemID = 0, int CostNum = 0, int multiple = 0)
		{
			builder.StartObject(4);
			QuickBuyTable.AddMultiple(builder, multiple);
			QuickBuyTable.AddCostNum(builder, CostNum);
			QuickBuyTable.AddCostItemID(builder, CostItemID);
			QuickBuyTable.AddID(builder, ID);
			return QuickBuyTable.EndQuickBuyTable(builder);
		}

		// Token: 0x06004726 RID: 18214 RVA: 0x000E308A File Offset: 0x000E148A
		public static void StartQuickBuyTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004727 RID: 18215 RVA: 0x000E3093 File Offset: 0x000E1493
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004728 RID: 18216 RVA: 0x000E309E File Offset: 0x000E149E
		public static void AddCostItemID(FlatBufferBuilder builder, int CostItemID)
		{
			builder.AddInt(1, CostItemID, 0);
		}

		// Token: 0x06004729 RID: 18217 RVA: 0x000E30A9 File Offset: 0x000E14A9
		public static void AddCostNum(FlatBufferBuilder builder, int CostNum)
		{
			builder.AddInt(2, CostNum, 0);
		}

		// Token: 0x0600472A RID: 18218 RVA: 0x000E30B4 File Offset: 0x000E14B4
		public static void AddMultiple(FlatBufferBuilder builder, int multiple)
		{
			builder.AddInt(3, multiple, 0);
		}

		// Token: 0x0600472B RID: 18219 RVA: 0x000E30C0 File Offset: 0x000E14C0
		public static Offset<QuickBuyTable> EndQuickBuyTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<QuickBuyTable>(value);
		}

		// Token: 0x0600472C RID: 18220 RVA: 0x000E30DA File Offset: 0x000E14DA
		public static void FinishQuickBuyTableBuffer(FlatBufferBuilder builder, Offset<QuickBuyTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A36 RID: 6710
		private Table __p = new Table();

		// Token: 0x02000564 RID: 1380
		public enum eCrypt
		{
			// Token: 0x04001A38 RID: 6712
			code = -1474022939
		}
	}
}
