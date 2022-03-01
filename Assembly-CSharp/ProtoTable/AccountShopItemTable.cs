using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000266 RID: 614
	public class AccountShopItemTable : IFlatbufferObject
	{
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06001407 RID: 5127 RVA: 0x00069D00 File Offset: 0x00068100
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001408 RID: 5128 RVA: 0x00069D0D File Offset: 0x0006810D
		public static AccountShopItemTable GetRootAsAccountShopItemTable(ByteBuffer _bb)
		{
			return AccountShopItemTable.GetRootAsAccountShopItemTable(_bb, new AccountShopItemTable());
		}

		// Token: 0x06001409 RID: 5129 RVA: 0x00069D1A File Offset: 0x0006811A
		public static AccountShopItemTable GetRootAsAccountShopItemTable(ByteBuffer _bb, AccountShopItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600140A RID: 5130 RVA: 0x00069D36 File Offset: 0x00068136
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600140B RID: 5131 RVA: 0x00069D50 File Offset: 0x00068150
		public AccountShopItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000244 RID: 580
		// (get) Token: 0x0600140C RID: 5132 RVA: 0x00069D5C File Offset: 0x0006815C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000245 RID: 581
		// (get) Token: 0x0600140D RID: 5133 RVA: 0x00069DA8 File Offset: 0x000681A8
		public string ShopItemName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600140E RID: 5134 RVA: 0x00069DEA File Offset: 0x000681EA
		public ArraySegment<byte>? GetShopItemNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000246 RID: 582
		// (get) Token: 0x0600140F RID: 5135 RVA: 0x00069DF8 File Offset: 0x000681F8
		public int ShopId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06001410 RID: 5136 RVA: 0x00069E44 File Offset: 0x00068244
		public int TabType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06001411 RID: 5137 RVA: 0x00069E90 File Offset: 0x00068290
		public int JobType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000249 RID: 585
		// (get) Token: 0x06001412 RID: 5138 RVA: 0x00069EDC File Offset: 0x000682DC
		public int ItemDatId
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700024A RID: 586
		// (get) Token: 0x06001413 RID: 5139 RVA: 0x00069F28 File Offset: 0x00068328
		public int ItemNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700024B RID: 587
		// (get) Token: 0x06001414 RID: 5140 RVA: 0x00069F74 File Offset: 0x00068374
		public string CostItems
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001415 RID: 5141 RVA: 0x00069FB7 File Offset: 0x000683B7
		public ArraySegment<byte>? GetCostItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x1700024C RID: 588
		// (get) Token: 0x06001416 RID: 5142 RVA: 0x00069FC8 File Offset: 0x000683C8
		public int TimeCalcType
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700024D RID: 589
		// (get) Token: 0x06001417 RID: 5143 RVA: 0x0006A014 File Offset: 0x00068414
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001418 RID: 5144 RVA: 0x0006A057 File Offset: 0x00068457
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700024E RID: 590
		// (get) Token: 0x06001419 RID: 5145 RVA: 0x0006A068 File Offset: 0x00068468
		public string EndTime
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600141A RID: 5146 RVA: 0x0006A0AB File Offset: 0x000684AB
		public ArraySegment<byte>? GetEndTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x1700024F RID: 591
		// (get) Token: 0x0600141B RID: 5147 RVA: 0x0006A0BC File Offset: 0x000684BC
		public int AccountRefreshType
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000250 RID: 592
		// (get) Token: 0x0600141C RID: 5148 RVA: 0x0006A108 File Offset: 0x00068508
		public string AccountRefreshTimePoint
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600141D RID: 5149 RVA: 0x0006A14B File Offset: 0x0006854B
		public ArraySegment<byte>? GetAccountRefreshTimePointBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000251 RID: 593
		// (get) Token: 0x0600141E RID: 5150 RVA: 0x0006A15C File Offset: 0x0006855C
		public int AccountLimitBuyType
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000252 RID: 594
		// (get) Token: 0x0600141F RID: 5151 RVA: 0x0006A1A8 File Offset: 0x000685A8
		public int AccountLimitBuyNum
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000253 RID: 595
		// (get) Token: 0x06001420 RID: 5152 RVA: 0x0006A1F4 File Offset: 0x000685F4
		public int RoleRefreshType
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000254 RID: 596
		// (get) Token: 0x06001421 RID: 5153 RVA: 0x0006A240 File Offset: 0x00068640
		public string RoleRefreshTimePoint
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001422 RID: 5154 RVA: 0x0006A283 File Offset: 0x00068683
		public ArraySegment<byte>? GetRoleRefreshTimePointBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000255 RID: 597
		// (get) Token: 0x06001423 RID: 5155 RVA: 0x0006A294 File Offset: 0x00068694
		public int RoleLimitBuyType
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000256 RID: 598
		// (get) Token: 0x06001424 RID: 5156 RVA: 0x0006A2E0 File Offset: 0x000686E0
		public int RoleLimitBuyNum
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000257 RID: 599
		// (get) Token: 0x06001425 RID: 5157 RVA: 0x0006A32C File Offset: 0x0006872C
		public int ExtensibleCondition
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000258 RID: 600
		// (get) Token: 0x06001426 RID: 5158 RVA: 0x0006A378 File Offset: 0x00068778
		public int NeedPreviewFunc
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000259 RID: 601
		// (get) Token: 0x06001427 RID: 5159 RVA: 0x0006A3C4 File Offset: 0x000687C4
		public int ShowLevelLimit
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700025A RID: 602
		// (get) Token: 0x06001428 RID: 5160 RVA: 0x0006A410 File Offset: 0x00068810
		public int Rank
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700025B RID: 603
		// (get) Token: 0x06001429 RID: 5161 RVA: 0x0006A45C File Offset: 0x0006885C
		public int BuyLimit
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? 0 : (736413346 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600142A RID: 5162 RVA: 0x0006A4A8 File Offset: 0x000688A8
		public static Offset<AccountShopItemTable> CreateAccountShopItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset ShopItemNameOffset = default(StringOffset), int ShopId = 0, int TabType = 0, int JobType = 0, int ItemDatId = 0, int ItemNum = 0, StringOffset CostItemsOffset = default(StringOffset), int TimeCalcType = 0, StringOffset StartTimeOffset = default(StringOffset), StringOffset EndTimeOffset = default(StringOffset), int AccountRefreshType = 0, StringOffset AccountRefreshTimePointOffset = default(StringOffset), int AccountLimitBuyType = 0, int AccountLimitBuyNum = 0, int RoleRefreshType = 0, StringOffset RoleRefreshTimePointOffset = default(StringOffset), int RoleLimitBuyType = 0, int RoleLimitBuyNum = 0, int ExtensibleCondition = 0, int NeedPreviewFunc = 0, int ShowLevelLimit = 0, int Rank = 0, int BuyLimit = 0)
		{
			builder.StartObject(24);
			AccountShopItemTable.AddBuyLimit(builder, BuyLimit);
			AccountShopItemTable.AddRank(builder, Rank);
			AccountShopItemTable.AddShowLevelLimit(builder, ShowLevelLimit);
			AccountShopItemTable.AddNeedPreviewFunc(builder, NeedPreviewFunc);
			AccountShopItemTable.AddExtensibleCondition(builder, ExtensibleCondition);
			AccountShopItemTable.AddRoleLimitBuyNum(builder, RoleLimitBuyNum);
			AccountShopItemTable.AddRoleLimitBuyType(builder, RoleLimitBuyType);
			AccountShopItemTable.AddRoleRefreshTimePoint(builder, RoleRefreshTimePointOffset);
			AccountShopItemTable.AddRoleRefreshType(builder, RoleRefreshType);
			AccountShopItemTable.AddAccountLimitBuyNum(builder, AccountLimitBuyNum);
			AccountShopItemTable.AddAccountLimitBuyType(builder, AccountLimitBuyType);
			AccountShopItemTable.AddAccountRefreshTimePoint(builder, AccountRefreshTimePointOffset);
			AccountShopItemTable.AddAccountRefreshType(builder, AccountRefreshType);
			AccountShopItemTable.AddEndTime(builder, EndTimeOffset);
			AccountShopItemTable.AddStartTime(builder, StartTimeOffset);
			AccountShopItemTable.AddTimeCalcType(builder, TimeCalcType);
			AccountShopItemTable.AddCostItems(builder, CostItemsOffset);
			AccountShopItemTable.AddItemNum(builder, ItemNum);
			AccountShopItemTable.AddItemDatId(builder, ItemDatId);
			AccountShopItemTable.AddJobType(builder, JobType);
			AccountShopItemTable.AddTabType(builder, TabType);
			AccountShopItemTable.AddShopId(builder, ShopId);
			AccountShopItemTable.AddShopItemName(builder, ShopItemNameOffset);
			AccountShopItemTable.AddID(builder, ID);
			return AccountShopItemTable.EndAccountShopItemTable(builder);
		}

		// Token: 0x0600142B RID: 5163 RVA: 0x0006A580 File Offset: 0x00068980
		public static void StartAccountShopItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(24);
		}

		// Token: 0x0600142C RID: 5164 RVA: 0x0006A58A File Offset: 0x0006898A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600142D RID: 5165 RVA: 0x0006A595 File Offset: 0x00068995
		public static void AddShopItemName(FlatBufferBuilder builder, StringOffset ShopItemNameOffset)
		{
			builder.AddOffset(1, ShopItemNameOffset.Value, 0);
		}

		// Token: 0x0600142E RID: 5166 RVA: 0x0006A5A6 File Offset: 0x000689A6
		public static void AddShopId(FlatBufferBuilder builder, int ShopId)
		{
			builder.AddInt(2, ShopId, 0);
		}

		// Token: 0x0600142F RID: 5167 RVA: 0x0006A5B1 File Offset: 0x000689B1
		public static void AddTabType(FlatBufferBuilder builder, int TabType)
		{
			builder.AddInt(3, TabType, 0);
		}

		// Token: 0x06001430 RID: 5168 RVA: 0x0006A5BC File Offset: 0x000689BC
		public static void AddJobType(FlatBufferBuilder builder, int JobType)
		{
			builder.AddInt(4, JobType, 0);
		}

		// Token: 0x06001431 RID: 5169 RVA: 0x0006A5C7 File Offset: 0x000689C7
		public static void AddItemDatId(FlatBufferBuilder builder, int ItemDatId)
		{
			builder.AddInt(5, ItemDatId, 0);
		}

		// Token: 0x06001432 RID: 5170 RVA: 0x0006A5D2 File Offset: 0x000689D2
		public static void AddItemNum(FlatBufferBuilder builder, int ItemNum)
		{
			builder.AddInt(6, ItemNum, 0);
		}

		// Token: 0x06001433 RID: 5171 RVA: 0x0006A5DD File Offset: 0x000689DD
		public static void AddCostItems(FlatBufferBuilder builder, StringOffset CostItemsOffset)
		{
			builder.AddOffset(7, CostItemsOffset.Value, 0);
		}

		// Token: 0x06001434 RID: 5172 RVA: 0x0006A5EE File Offset: 0x000689EE
		public static void AddTimeCalcType(FlatBufferBuilder builder, int TimeCalcType)
		{
			builder.AddInt(8, TimeCalcType, 0);
		}

		// Token: 0x06001435 RID: 5173 RVA: 0x0006A5F9 File Offset: 0x000689F9
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(9, StartTimeOffset.Value, 0);
		}

		// Token: 0x06001436 RID: 5174 RVA: 0x0006A60B File Offset: 0x00068A0B
		public static void AddEndTime(FlatBufferBuilder builder, StringOffset EndTimeOffset)
		{
			builder.AddOffset(10, EndTimeOffset.Value, 0);
		}

		// Token: 0x06001437 RID: 5175 RVA: 0x0006A61D File Offset: 0x00068A1D
		public static void AddAccountRefreshType(FlatBufferBuilder builder, int AccountRefreshType)
		{
			builder.AddInt(11, AccountRefreshType, 0);
		}

		// Token: 0x06001438 RID: 5176 RVA: 0x0006A629 File Offset: 0x00068A29
		public static void AddAccountRefreshTimePoint(FlatBufferBuilder builder, StringOffset AccountRefreshTimePointOffset)
		{
			builder.AddOffset(12, AccountRefreshTimePointOffset.Value, 0);
		}

		// Token: 0x06001439 RID: 5177 RVA: 0x0006A63B File Offset: 0x00068A3B
		public static void AddAccountLimitBuyType(FlatBufferBuilder builder, int AccountLimitBuyType)
		{
			builder.AddInt(13, AccountLimitBuyType, 0);
		}

		// Token: 0x0600143A RID: 5178 RVA: 0x0006A647 File Offset: 0x00068A47
		public static void AddAccountLimitBuyNum(FlatBufferBuilder builder, int AccountLimitBuyNum)
		{
			builder.AddInt(14, AccountLimitBuyNum, 0);
		}

		// Token: 0x0600143B RID: 5179 RVA: 0x0006A653 File Offset: 0x00068A53
		public static void AddRoleRefreshType(FlatBufferBuilder builder, int RoleRefreshType)
		{
			builder.AddInt(15, RoleRefreshType, 0);
		}

		// Token: 0x0600143C RID: 5180 RVA: 0x0006A65F File Offset: 0x00068A5F
		public static void AddRoleRefreshTimePoint(FlatBufferBuilder builder, StringOffset RoleRefreshTimePointOffset)
		{
			builder.AddOffset(16, RoleRefreshTimePointOffset.Value, 0);
		}

		// Token: 0x0600143D RID: 5181 RVA: 0x0006A671 File Offset: 0x00068A71
		public static void AddRoleLimitBuyType(FlatBufferBuilder builder, int RoleLimitBuyType)
		{
			builder.AddInt(17, RoleLimitBuyType, 0);
		}

		// Token: 0x0600143E RID: 5182 RVA: 0x0006A67D File Offset: 0x00068A7D
		public static void AddRoleLimitBuyNum(FlatBufferBuilder builder, int RoleLimitBuyNum)
		{
			builder.AddInt(18, RoleLimitBuyNum, 0);
		}

		// Token: 0x0600143F RID: 5183 RVA: 0x0006A689 File Offset: 0x00068A89
		public static void AddExtensibleCondition(FlatBufferBuilder builder, int ExtensibleCondition)
		{
			builder.AddInt(19, ExtensibleCondition, 0);
		}

		// Token: 0x06001440 RID: 5184 RVA: 0x0006A695 File Offset: 0x00068A95
		public static void AddNeedPreviewFunc(FlatBufferBuilder builder, int NeedPreviewFunc)
		{
			builder.AddInt(20, NeedPreviewFunc, 0);
		}

		// Token: 0x06001441 RID: 5185 RVA: 0x0006A6A1 File Offset: 0x00068AA1
		public static void AddShowLevelLimit(FlatBufferBuilder builder, int ShowLevelLimit)
		{
			builder.AddInt(21, ShowLevelLimit, 0);
		}

		// Token: 0x06001442 RID: 5186 RVA: 0x0006A6AD File Offset: 0x00068AAD
		public static void AddRank(FlatBufferBuilder builder, int Rank)
		{
			builder.AddInt(22, Rank, 0);
		}

		// Token: 0x06001443 RID: 5187 RVA: 0x0006A6B9 File Offset: 0x00068AB9
		public static void AddBuyLimit(FlatBufferBuilder builder, int BuyLimit)
		{
			builder.AddInt(23, BuyLimit, 0);
		}

		// Token: 0x06001444 RID: 5188 RVA: 0x0006A6C8 File Offset: 0x00068AC8
		public static Offset<AccountShopItemTable> EndAccountShopItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AccountShopItemTable>(value);
		}

		// Token: 0x06001445 RID: 5189 RVA: 0x0006A6E2 File Offset: 0x00068AE2
		public static void FinishAccountShopItemTableBuffer(FlatBufferBuilder builder, Offset<AccountShopItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000D5F RID: 3423
		private Table __p = new Table();

		// Token: 0x02000267 RID: 615
		public enum eCrypt
		{
			// Token: 0x04000D61 RID: 3425
			code = 736413346
		}
	}
}
