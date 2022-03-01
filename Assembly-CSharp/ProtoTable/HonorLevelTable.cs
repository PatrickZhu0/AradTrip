using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000492 RID: 1170
	public class HonorLevelTable : IFlatbufferObject
	{
		// Token: 0x17000E65 RID: 3685
		// (get) Token: 0x060038F9 RID: 14585 RVA: 0x000C15E0 File Offset: 0x000BF9E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060038FA RID: 14586 RVA: 0x000C15ED File Offset: 0x000BF9ED
		public static HonorLevelTable GetRootAsHonorLevelTable(ByteBuffer _bb)
		{
			return HonorLevelTable.GetRootAsHonorLevelTable(_bb, new HonorLevelTable());
		}

		// Token: 0x060038FB RID: 14587 RVA: 0x000C15FA File Offset: 0x000BF9FA
		public static HonorLevelTable GetRootAsHonorLevelTable(ByteBuffer _bb, HonorLevelTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060038FC RID: 14588 RVA: 0x000C1616 File Offset: 0x000BFA16
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060038FD RID: 14589 RVA: 0x000C1630 File Offset: 0x000BFA30
		public HonorLevelTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E66 RID: 3686
		// (get) Token: 0x060038FE RID: 14590 RVA: 0x000C163C File Offset: 0x000BFA3C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E67 RID: 3687
		// (get) Token: 0x060038FF RID: 14591 RVA: 0x000C1688 File Offset: 0x000BFA88
		public string name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003900 RID: 14592 RVA: 0x000C16CA File Offset: 0x000BFACA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000E68 RID: 3688
		// (get) Token: 0x06003901 RID: 14593 RVA: 0x000C16D8 File Offset: 0x000BFAD8
		public int HonorLvlGrade
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E69 RID: 3689
		// (get) Token: 0x06003902 RID: 14594 RVA: 0x000C1724 File Offset: 0x000BFB24
		public int NeedExp
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E6A RID: 3690
		// (get) Token: 0x06003903 RID: 14595 RVA: 0x000C1770 File Offset: 0x000BFB70
		public int WeekAddLimit
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003904 RID: 14596 RVA: 0x000C17BC File Offset: 0x000BFBBC
		public string ShopDiscountArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000E6B RID: 3691
		// (get) Token: 0x06003905 RID: 14597 RVA: 0x000C1804 File Offset: 0x000BFC04
		public int ShopDiscountLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000E6C RID: 3692
		// (get) Token: 0x06003906 RID: 14598 RVA: 0x000C1837 File Offset: 0x000BFC37
		public FlatBufferArray<string> ShopDiscount
		{
			get
			{
				if (this.ShopDiscountValue == null)
				{
					this.ShopDiscountValue = new FlatBufferArray<string>(new Func<int, string>(this.ShopDiscountArray), this.ShopDiscountLength);
				}
				return this.ShopDiscountValue;
			}
		}

		// Token: 0x17000E6D RID: 3693
		// (get) Token: 0x06003907 RID: 14599 RVA: 0x000C1868 File Offset: 0x000BFC68
		public int LvlNeedRankRate
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E6E RID: 3694
		// (get) Token: 0x06003908 RID: 14600 RVA: 0x000C18B4 File Offset: 0x000BFCB4
		public int RankLeastNum
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E6F RID: 3695
		// (get) Token: 0x06003909 RID: 14601 RVA: 0x000C1900 File Offset: 0x000BFD00
		public int Title
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E70 RID: 3696
		// (get) Token: 0x0600390A RID: 14602 RVA: 0x000C194C File Offset: 0x000BFD4C
		public int TitleDueTime
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1857185564 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E71 RID: 3697
		// (get) Token: 0x0600390B RID: 14603 RVA: 0x000C1998 File Offset: 0x000BFD98
		public string TitleFlag
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600390C RID: 14604 RVA: 0x000C19DB File Offset: 0x000BFDDB
		public ArraySegment<byte>? GetTitleFlagBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000E72 RID: 3698
		// (get) Token: 0x0600390D RID: 14605 RVA: 0x000C19EC File Offset: 0x000BFDEC
		public string UnlockItem
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600390E RID: 14606 RVA: 0x000C1A2F File Offset: 0x000BFE2F
		public ArraySegment<byte>? GetUnlockItemBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x0600390F RID: 14607 RVA: 0x000C1A40 File Offset: 0x000BFE40
		public static Offset<HonorLevelTable> CreateHonorLevelTable(FlatBufferBuilder builder, int ID = 0, StringOffset nameOffset = default(StringOffset), int HonorLvlGrade = 0, int NeedExp = 0, int WeekAddLimit = 0, VectorOffset ShopDiscountOffset = default(VectorOffset), int LvlNeedRankRate = 0, int RankLeastNum = 0, int Title = 0, int TitleDueTime = 0, StringOffset TitleFlagOffset = default(StringOffset), StringOffset UnlockItemOffset = default(StringOffset))
		{
			builder.StartObject(12);
			HonorLevelTable.AddUnlockItem(builder, UnlockItemOffset);
			HonorLevelTable.AddTitleFlag(builder, TitleFlagOffset);
			HonorLevelTable.AddTitleDueTime(builder, TitleDueTime);
			HonorLevelTable.AddTitle(builder, Title);
			HonorLevelTable.AddRankLeastNum(builder, RankLeastNum);
			HonorLevelTable.AddLvlNeedRankRate(builder, LvlNeedRankRate);
			HonorLevelTable.AddShopDiscount(builder, ShopDiscountOffset);
			HonorLevelTable.AddWeekAddLimit(builder, WeekAddLimit);
			HonorLevelTable.AddNeedExp(builder, NeedExp);
			HonorLevelTable.AddHonorLvlGrade(builder, HonorLvlGrade);
			HonorLevelTable.AddName(builder, nameOffset);
			HonorLevelTable.AddID(builder, ID);
			return HonorLevelTable.EndHonorLevelTable(builder);
		}

		// Token: 0x06003910 RID: 14608 RVA: 0x000C1AB8 File Offset: 0x000BFEB8
		public static void StartHonorLevelTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06003911 RID: 14609 RVA: 0x000C1AC2 File Offset: 0x000BFEC2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003912 RID: 14610 RVA: 0x000C1ACD File Offset: 0x000BFECD
		public static void AddName(FlatBufferBuilder builder, StringOffset nameOffset)
		{
			builder.AddOffset(1, nameOffset.Value, 0);
		}

		// Token: 0x06003913 RID: 14611 RVA: 0x000C1ADE File Offset: 0x000BFEDE
		public static void AddHonorLvlGrade(FlatBufferBuilder builder, int HonorLvlGrade)
		{
			builder.AddInt(2, HonorLvlGrade, 0);
		}

		// Token: 0x06003914 RID: 14612 RVA: 0x000C1AE9 File Offset: 0x000BFEE9
		public static void AddNeedExp(FlatBufferBuilder builder, int NeedExp)
		{
			builder.AddInt(3, NeedExp, 0);
		}

		// Token: 0x06003915 RID: 14613 RVA: 0x000C1AF4 File Offset: 0x000BFEF4
		public static void AddWeekAddLimit(FlatBufferBuilder builder, int WeekAddLimit)
		{
			builder.AddInt(4, WeekAddLimit, 0);
		}

		// Token: 0x06003916 RID: 14614 RVA: 0x000C1AFF File Offset: 0x000BFEFF
		public static void AddShopDiscount(FlatBufferBuilder builder, VectorOffset ShopDiscountOffset)
		{
			builder.AddOffset(5, ShopDiscountOffset.Value, 0);
		}

		// Token: 0x06003917 RID: 14615 RVA: 0x000C1B10 File Offset: 0x000BFF10
		public static VectorOffset CreateShopDiscountVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003918 RID: 14616 RVA: 0x000C1B56 File Offset: 0x000BFF56
		public static void StartShopDiscountVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003919 RID: 14617 RVA: 0x000C1B61 File Offset: 0x000BFF61
		public static void AddLvlNeedRankRate(FlatBufferBuilder builder, int LvlNeedRankRate)
		{
			builder.AddInt(6, LvlNeedRankRate, 0);
		}

		// Token: 0x0600391A RID: 14618 RVA: 0x000C1B6C File Offset: 0x000BFF6C
		public static void AddRankLeastNum(FlatBufferBuilder builder, int RankLeastNum)
		{
			builder.AddInt(7, RankLeastNum, 0);
		}

		// Token: 0x0600391B RID: 14619 RVA: 0x000C1B77 File Offset: 0x000BFF77
		public static void AddTitle(FlatBufferBuilder builder, int Title)
		{
			builder.AddInt(8, Title, 0);
		}

		// Token: 0x0600391C RID: 14620 RVA: 0x000C1B82 File Offset: 0x000BFF82
		public static void AddTitleDueTime(FlatBufferBuilder builder, int TitleDueTime)
		{
			builder.AddInt(9, TitleDueTime, 0);
		}

		// Token: 0x0600391D RID: 14621 RVA: 0x000C1B8E File Offset: 0x000BFF8E
		public static void AddTitleFlag(FlatBufferBuilder builder, StringOffset TitleFlagOffset)
		{
			builder.AddOffset(10, TitleFlagOffset.Value, 0);
		}

		// Token: 0x0600391E RID: 14622 RVA: 0x000C1BA0 File Offset: 0x000BFFA0
		public static void AddUnlockItem(FlatBufferBuilder builder, StringOffset UnlockItemOffset)
		{
			builder.AddOffset(11, UnlockItemOffset.Value, 0);
		}

		// Token: 0x0600391F RID: 14623 RVA: 0x000C1BB4 File Offset: 0x000BFFB4
		public static Offset<HonorLevelTable> EndHonorLevelTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<HonorLevelTable>(value);
		}

		// Token: 0x06003920 RID: 14624 RVA: 0x000C1BCE File Offset: 0x000BFFCE
		public static void FinishHonorLevelTableBuffer(FlatBufferBuilder builder, Offset<HonorLevelTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001618 RID: 5656
		private Table __p = new Table();

		// Token: 0x04001619 RID: 5657
		private FlatBufferArray<string> ShopDiscountValue;

		// Token: 0x02000493 RID: 1171
		public enum eCrypt
		{
			// Token: 0x0400161B RID: 5659
			code = -1857185564
		}
	}
}
