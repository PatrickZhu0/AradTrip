using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000580 RID: 1408
	public class ReplacejewelsTable : IFlatbufferObject
	{
		// Token: 0x1700138A RID: 5002
		// (get) Token: 0x06004856 RID: 18518 RVA: 0x000E5A24 File Offset: 0x000E3E24
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004857 RID: 18519 RVA: 0x000E5A31 File Offset: 0x000E3E31
		public static ReplacejewelsTable GetRootAsReplacejewelsTable(ByteBuffer _bb)
		{
			return ReplacejewelsTable.GetRootAsReplacejewelsTable(_bb, new ReplacejewelsTable());
		}

		// Token: 0x06004858 RID: 18520 RVA: 0x000E5A3E File Offset: 0x000E3E3E
		public static ReplacejewelsTable GetRootAsReplacejewelsTable(ByteBuffer _bb, ReplacejewelsTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004859 RID: 18521 RVA: 0x000E5A5A File Offset: 0x000E3E5A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600485A RID: 18522 RVA: 0x000E5A74 File Offset: 0x000E3E74
		public ReplacejewelsTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700138B RID: 5003
		// (get) Token: 0x0600485B RID: 18523 RVA: 0x000E5A80 File Offset: 0x000E3E80
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700138C RID: 5004
		// (get) Token: 0x0600485C RID: 18524 RVA: 0x000E5ACC File Offset: 0x000E3ECC
		public int Colour
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700138D RID: 5005
		// (get) Token: 0x0600485D RID: 18525 RVA: 0x000E5B18 File Offset: 0x000E3F18
		public int Grades
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700138E RID: 5006
		// (get) Token: 0x0600485E RID: 18526 RVA: 0x000E5B64 File Offset: 0x000E3F64
		public int BeadType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700138F RID: 5007
		// (get) Token: 0x0600485F RID: 18527 RVA: 0x000E5BB0 File Offset: 0x000E3FB0
		public int CostItem
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001390 RID: 5008
		// (get) Token: 0x06004860 RID: 18528 RVA: 0x000E5BFC File Offset: 0x000E3FFC
		public int CostNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001391 RID: 5009
		// (get) Token: 0x06004861 RID: 18529 RVA: 0x000E5C48 File Offset: 0x000E4048
		public int ReplaceNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1471005552 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004862 RID: 18530 RVA: 0x000E5C94 File Offset: 0x000E4094
		public static Offset<ReplacejewelsTable> CreateReplacejewelsTable(FlatBufferBuilder builder, int ID = 0, int Colour = 0, int Grades = 0, int BeadType = 0, int CostItem = 0, int CostNum = 0, int ReplaceNum = 0)
		{
			builder.StartObject(7);
			ReplacejewelsTable.AddReplaceNum(builder, ReplaceNum);
			ReplacejewelsTable.AddCostNum(builder, CostNum);
			ReplacejewelsTable.AddCostItem(builder, CostItem);
			ReplacejewelsTable.AddBeadType(builder, BeadType);
			ReplacejewelsTable.AddGrades(builder, Grades);
			ReplacejewelsTable.AddColour(builder, Colour);
			ReplacejewelsTable.AddID(builder, ID);
			return ReplacejewelsTable.EndReplacejewelsTable(builder);
		}

		// Token: 0x06004863 RID: 18531 RVA: 0x000E5CE3 File Offset: 0x000E40E3
		public static void StartReplacejewelsTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06004864 RID: 18532 RVA: 0x000E5CEC File Offset: 0x000E40EC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004865 RID: 18533 RVA: 0x000E5CF7 File Offset: 0x000E40F7
		public static void AddColour(FlatBufferBuilder builder, int Colour)
		{
			builder.AddInt(1, Colour, 0);
		}

		// Token: 0x06004866 RID: 18534 RVA: 0x000E5D02 File Offset: 0x000E4102
		public static void AddGrades(FlatBufferBuilder builder, int Grades)
		{
			builder.AddInt(2, Grades, 0);
		}

		// Token: 0x06004867 RID: 18535 RVA: 0x000E5D0D File Offset: 0x000E410D
		public static void AddBeadType(FlatBufferBuilder builder, int BeadType)
		{
			builder.AddInt(3, BeadType, 0);
		}

		// Token: 0x06004868 RID: 18536 RVA: 0x000E5D18 File Offset: 0x000E4118
		public static void AddCostItem(FlatBufferBuilder builder, int CostItem)
		{
			builder.AddInt(4, CostItem, 0);
		}

		// Token: 0x06004869 RID: 18537 RVA: 0x000E5D23 File Offset: 0x000E4123
		public static void AddCostNum(FlatBufferBuilder builder, int CostNum)
		{
			builder.AddInt(5, CostNum, 0);
		}

		// Token: 0x0600486A RID: 18538 RVA: 0x000E5D2E File Offset: 0x000E412E
		public static void AddReplaceNum(FlatBufferBuilder builder, int ReplaceNum)
		{
			builder.AddInt(6, ReplaceNum, 0);
		}

		// Token: 0x0600486B RID: 18539 RVA: 0x000E5D3C File Offset: 0x000E413C
		public static Offset<ReplacejewelsTable> EndReplacejewelsTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ReplacejewelsTable>(value);
		}

		// Token: 0x0600486C RID: 18540 RVA: 0x000E5D56 File Offset: 0x000E4156
		public static void FinishReplacejewelsTableBuffer(FlatBufferBuilder builder, Offset<ReplacejewelsTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001AA3 RID: 6819
		private Table __p = new Table();

		// Token: 0x02000581 RID: 1409
		public enum eCrypt
		{
			// Token: 0x04001AA5 RID: 6821
			code = 1471005552
		}
	}
}
