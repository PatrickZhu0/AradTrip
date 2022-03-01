using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000327 RID: 807
	public class ChiJiShopItemTable : IFlatbufferObject
	{
		// Token: 0x1700061B RID: 1563
		// (get) Token: 0x06002000 RID: 8192 RVA: 0x000853D4 File Offset: 0x000837D4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002001 RID: 8193 RVA: 0x000853E1 File Offset: 0x000837E1
		public static ChiJiShopItemTable GetRootAsChiJiShopItemTable(ByteBuffer _bb)
		{
			return ChiJiShopItemTable.GetRootAsChiJiShopItemTable(_bb, new ChiJiShopItemTable());
		}

		// Token: 0x06002002 RID: 8194 RVA: 0x000853EE File Offset: 0x000837EE
		public static ChiJiShopItemTable GetRootAsChiJiShopItemTable(ByteBuffer _bb, ChiJiShopItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002003 RID: 8195 RVA: 0x0008540A File Offset: 0x0008380A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002004 RID: 8196 RVA: 0x00085424 File Offset: 0x00083824
		public ChiJiShopItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700061C RID: 1564
		// (get) Token: 0x06002005 RID: 8197 RVA: 0x00085430 File Offset: 0x00083830
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700061D RID: 1565
		// (get) Token: 0x06002006 RID: 8198 RVA: 0x0008547C File Offset: 0x0008387C
		public string CommodityName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002007 RID: 8199 RVA: 0x000854BE File Offset: 0x000838BE
		public ArraySegment<byte>? GetCommodityNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700061E RID: 1566
		// (get) Token: 0x06002008 RID: 8200 RVA: 0x000854CC File Offset: 0x000838CC
		public int ShopID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700061F RID: 1567
		// (get) Token: 0x06002009 RID: 8201 RVA: 0x00085518 File Offset: 0x00083918
		public int UseEqualItem
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000620 RID: 1568
		// (get) Token: 0x0600200A RID: 8202 RVA: 0x00085564 File Offset: 0x00083964
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000621 RID: 1569
		// (get) Token: 0x0600200B RID: 8203 RVA: 0x000855B0 File Offset: 0x000839B0
		public int SortID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000622 RID: 1570
		// (get) Token: 0x0600200C RID: 8204 RVA: 0x000855FC File Offset: 0x000839FC
		public ChiJiShopItemTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ChiJiShopItemTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000623 RID: 1571
		// (get) Token: 0x0600200D RID: 8205 RVA: 0x00085640 File Offset: 0x00083A40
		public int CostItemID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000624 RID: 1572
		// (get) Token: 0x0600200E RID: 8206 RVA: 0x0008568C File Offset: 0x00083A8C
		public int CostNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000625 RID: 1573
		// (get) Token: 0x0600200F RID: 8207 RVA: 0x000856D8 File Offset: 0x00083AD8
		public string OtherCostItems
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002010 RID: 8208 RVA: 0x0008571B File Offset: 0x00083B1B
		public ArraySegment<byte>? GetOtherCostItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000626 RID: 1574
		// (get) Token: 0x06002011 RID: 8209 RVA: 0x0008572C File Offset: 0x00083B2C
		public int VIP
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000627 RID: 1575
		// (get) Token: 0x06002012 RID: 8210 RVA: 0x00085778 File Offset: 0x00083B78
		public int VIPLimite
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000628 RID: 1576
		// (get) Token: 0x06002013 RID: 8211 RVA: 0x000857C4 File Offset: 0x00083BC4
		public int NumLimite
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000629 RID: 1577
		// (get) Token: 0x06002014 RID: 8212 RVA: 0x00085810 File Offset: 0x00083C10
		public int LimiteOnce
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700062A RID: 1578
		// (get) Token: 0x06002015 RID: 8213 RVA: 0x0008585C File Offset: 0x00083C5C
		public int GroupNum
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700062B RID: 1579
		// (get) Token: 0x06002016 RID: 8214 RVA: 0x000858A8 File Offset: 0x00083CA8
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700062C RID: 1580
		// (get) Token: 0x06002017 RID: 8215 RVA: 0x000858F4 File Offset: 0x00083CF4
		public int ExLimite
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700062D RID: 1581
		// (get) Token: 0x06002018 RID: 8216 RVA: 0x00085940 File Offset: 0x00083D40
		public int ExValue
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700062E RID: 1582
		// (get) Token: 0x06002019 RID: 8217 RVA: 0x0008598C File Offset: 0x00083D8C
		public string OldChangeNewItemID
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600201A RID: 8218 RVA: 0x000859CF File Offset: 0x00083DCF
		public ArraySegment<byte>? GetOldChangeNewItemIDBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x1700062F RID: 1583
		// (get) Token: 0x0600201B RID: 8219 RVA: 0x000859E0 File Offset: 0x00083DE0
		public string PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600201C RID: 8220 RVA: 0x00085A23 File Offset: 0x00083E23
		public ArraySegment<byte>? GetPlayerLevelLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17000630 RID: 1584
		// (get) Token: 0x0600201D RID: 8221 RVA: 0x00085A34 File Offset: 0x00083E34
		public string VipLevelLimit
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600201E RID: 8222 RVA: 0x00085A77 File Offset: 0x00083E77
		public ArraySegment<byte>? GetVipLevelLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17000631 RID: 1585
		// (get) Token: 0x0600201F RID: 8223 RVA: 0x00085A88 File Offset: 0x00083E88
		public string DungeonHardLimit
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002020 RID: 8224 RVA: 0x00085ACB File Offset: 0x00083ECB
		public ArraySegment<byte>? GetDungeonHardLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17000632 RID: 1586
		// (get) Token: 0x06002021 RID: 8225 RVA: 0x00085ADC File Offset: 0x00083EDC
		public string DungeonSubTypeLimit
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x00085B1F File Offset: 0x00083F1F
		public ArraySegment<byte>? GetDungeonSubTypeLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x17000633 RID: 1587
		// (get) Token: 0x06002023 RID: 8227 RVA: 0x00085B30 File Offset: 0x00083F30
		public string DungeonIdLimit
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002024 RID: 8228 RVA: 0x00085B73 File Offset: 0x00083F73
		public ArraySegment<byte>? GetDungeonIdLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17000634 RID: 1588
		// (get) Token: 0x06002025 RID: 8229 RVA: 0x00085B84 File Offset: 0x00083F84
		public string DiscountRate
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002026 RID: 8230 RVA: 0x00085BC7 File Offset: 0x00083FC7
		public ArraySegment<byte>? GetDiscountRateBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17000635 RID: 1589
		// (get) Token: 0x06002027 RID: 8231 RVA: 0x00085BD8 File Offset: 0x00083FD8
		public string DiscountRateWeight
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002028 RID: 8232 RVA: 0x00085C1B File Offset: 0x0008401B
		public ArraySegment<byte>? GetDiscountRateWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x17000636 RID: 1590
		// (get) Token: 0x06002029 RID: 8233 RVA: 0x00085C2C File Offset: 0x0008402C
		public int MallGoodID
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000637 RID: 1591
		// (get) Token: 0x0600202A RID: 8234 RVA: 0x00085C78 File Offset: 0x00084078
		public int AttFit
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x0600202B RID: 8235 RVA: 0x00085CC4 File Offset: 0x000840C4
		public int ShowLevelLimit
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600202C RID: 8236 RVA: 0x00085D10 File Offset: 0x00084110
		public int BuyLimit
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (2000239930 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600202D RID: 8237 RVA: 0x00085D5C File Offset: 0x0008415C
		public static Offset<ChiJiShopItemTable> CreateChiJiShopItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset CommodityNameOffset = default(StringOffset), int ShopID = 0, int UseEqualItem = 0, int ItemID = 0, int SortID = 0, ChiJiShopItemTable.eSubType SubType = ChiJiShopItemTable.eSubType.ST_NONE, int CostItemID = 0, int CostNum = 0, StringOffset OtherCostItemsOffset = default(StringOffset), int VIP = 0, int VIPLimite = 0, int NumLimite = 0, int LimiteOnce = 0, int GroupNum = 0, int Weight = 0, int ExLimite = 0, int ExValue = 0, StringOffset OldChangeNewItemIDOffset = default(StringOffset), StringOffset PlayerLevelLimitOffset = default(StringOffset), StringOffset VipLevelLimitOffset = default(StringOffset), StringOffset DungeonHardLimitOffset = default(StringOffset), StringOffset DungeonSubTypeLimitOffset = default(StringOffset), StringOffset DungeonIdLimitOffset = default(StringOffset), StringOffset DiscountRateOffset = default(StringOffset), StringOffset DiscountRateWeightOffset = default(StringOffset), int MallGoodID = 0, int AttFit = 0, int ShowLevelLimit = 0, int BuyLimit = 0)
		{
			builder.StartObject(30);
			ChiJiShopItemTable.AddBuyLimit(builder, BuyLimit);
			ChiJiShopItemTable.AddShowLevelLimit(builder, ShowLevelLimit);
			ChiJiShopItemTable.AddAttFit(builder, AttFit);
			ChiJiShopItemTable.AddMallGoodID(builder, MallGoodID);
			ChiJiShopItemTable.AddDiscountRateWeight(builder, DiscountRateWeightOffset);
			ChiJiShopItemTable.AddDiscountRate(builder, DiscountRateOffset);
			ChiJiShopItemTable.AddDungeonIdLimit(builder, DungeonIdLimitOffset);
			ChiJiShopItemTable.AddDungeonSubTypeLimit(builder, DungeonSubTypeLimitOffset);
			ChiJiShopItemTable.AddDungeonHardLimit(builder, DungeonHardLimitOffset);
			ChiJiShopItemTable.AddVipLevelLimit(builder, VipLevelLimitOffset);
			ChiJiShopItemTable.AddPlayerLevelLimit(builder, PlayerLevelLimitOffset);
			ChiJiShopItemTable.AddOldChangeNewItemID(builder, OldChangeNewItemIDOffset);
			ChiJiShopItemTable.AddExValue(builder, ExValue);
			ChiJiShopItemTable.AddExLimite(builder, ExLimite);
			ChiJiShopItemTable.AddWeight(builder, Weight);
			ChiJiShopItemTable.AddGroupNum(builder, GroupNum);
			ChiJiShopItemTable.AddLimiteOnce(builder, LimiteOnce);
			ChiJiShopItemTable.AddNumLimite(builder, NumLimite);
			ChiJiShopItemTable.AddVIPLimite(builder, VIPLimite);
			ChiJiShopItemTable.AddVIP(builder, VIP);
			ChiJiShopItemTable.AddOtherCostItems(builder, OtherCostItemsOffset);
			ChiJiShopItemTable.AddCostNum(builder, CostNum);
			ChiJiShopItemTable.AddCostItemID(builder, CostItemID);
			ChiJiShopItemTable.AddSubType(builder, SubType);
			ChiJiShopItemTable.AddSortID(builder, SortID);
			ChiJiShopItemTable.AddItemID(builder, ItemID);
			ChiJiShopItemTable.AddUseEqualItem(builder, UseEqualItem);
			ChiJiShopItemTable.AddShopID(builder, ShopID);
			ChiJiShopItemTable.AddCommodityName(builder, CommodityNameOffset);
			ChiJiShopItemTable.AddID(builder, ID);
			return ChiJiShopItemTable.EndChiJiShopItemTable(builder);
		}

		// Token: 0x0600202E RID: 8238 RVA: 0x00085E64 File Offset: 0x00084264
		public static void StartChiJiShopItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(30);
		}

		// Token: 0x0600202F RID: 8239 RVA: 0x00085E6E File Offset: 0x0008426E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002030 RID: 8240 RVA: 0x00085E79 File Offset: 0x00084279
		public static void AddCommodityName(FlatBufferBuilder builder, StringOffset CommodityNameOffset)
		{
			builder.AddOffset(1, CommodityNameOffset.Value, 0);
		}

		// Token: 0x06002031 RID: 8241 RVA: 0x00085E8A File Offset: 0x0008428A
		public static void AddShopID(FlatBufferBuilder builder, int ShopID)
		{
			builder.AddInt(2, ShopID, 0);
		}

		// Token: 0x06002032 RID: 8242 RVA: 0x00085E95 File Offset: 0x00084295
		public static void AddUseEqualItem(FlatBufferBuilder builder, int UseEqualItem)
		{
			builder.AddInt(3, UseEqualItem, 0);
		}

		// Token: 0x06002033 RID: 8243 RVA: 0x00085EA0 File Offset: 0x000842A0
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(4, ItemID, 0);
		}

		// Token: 0x06002034 RID: 8244 RVA: 0x00085EAB File Offset: 0x000842AB
		public static void AddSortID(FlatBufferBuilder builder, int SortID)
		{
			builder.AddInt(5, SortID, 0);
		}

		// Token: 0x06002035 RID: 8245 RVA: 0x00085EB6 File Offset: 0x000842B6
		public static void AddSubType(FlatBufferBuilder builder, ChiJiShopItemTable.eSubType SubType)
		{
			builder.AddInt(6, (int)SubType, 0);
		}

		// Token: 0x06002036 RID: 8246 RVA: 0x00085EC1 File Offset: 0x000842C1
		public static void AddCostItemID(FlatBufferBuilder builder, int CostItemID)
		{
			builder.AddInt(7, CostItemID, 0);
		}

		// Token: 0x06002037 RID: 8247 RVA: 0x00085ECC File Offset: 0x000842CC
		public static void AddCostNum(FlatBufferBuilder builder, int CostNum)
		{
			builder.AddInt(8, CostNum, 0);
		}

		// Token: 0x06002038 RID: 8248 RVA: 0x00085ED7 File Offset: 0x000842D7
		public static void AddOtherCostItems(FlatBufferBuilder builder, StringOffset OtherCostItemsOffset)
		{
			builder.AddOffset(9, OtherCostItemsOffset.Value, 0);
		}

		// Token: 0x06002039 RID: 8249 RVA: 0x00085EE9 File Offset: 0x000842E9
		public static void AddVIP(FlatBufferBuilder builder, int VIP)
		{
			builder.AddInt(10, VIP, 0);
		}

		// Token: 0x0600203A RID: 8250 RVA: 0x00085EF5 File Offset: 0x000842F5
		public static void AddVIPLimite(FlatBufferBuilder builder, int VIPLimite)
		{
			builder.AddInt(11, VIPLimite, 0);
		}

		// Token: 0x0600203B RID: 8251 RVA: 0x00085F01 File Offset: 0x00084301
		public static void AddNumLimite(FlatBufferBuilder builder, int NumLimite)
		{
			builder.AddInt(12, NumLimite, 0);
		}

		// Token: 0x0600203C RID: 8252 RVA: 0x00085F0D File Offset: 0x0008430D
		public static void AddLimiteOnce(FlatBufferBuilder builder, int LimiteOnce)
		{
			builder.AddInt(13, LimiteOnce, 0);
		}

		// Token: 0x0600203D RID: 8253 RVA: 0x00085F19 File Offset: 0x00084319
		public static void AddGroupNum(FlatBufferBuilder builder, int GroupNum)
		{
			builder.AddInt(14, GroupNum, 0);
		}

		// Token: 0x0600203E RID: 8254 RVA: 0x00085F25 File Offset: 0x00084325
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(15, Weight, 0);
		}

		// Token: 0x0600203F RID: 8255 RVA: 0x00085F31 File Offset: 0x00084331
		public static void AddExLimite(FlatBufferBuilder builder, int ExLimite)
		{
			builder.AddInt(16, ExLimite, 0);
		}

		// Token: 0x06002040 RID: 8256 RVA: 0x00085F3D File Offset: 0x0008433D
		public static void AddExValue(FlatBufferBuilder builder, int ExValue)
		{
			builder.AddInt(17, ExValue, 0);
		}

		// Token: 0x06002041 RID: 8257 RVA: 0x00085F49 File Offset: 0x00084349
		public static void AddOldChangeNewItemID(FlatBufferBuilder builder, StringOffset OldChangeNewItemIDOffset)
		{
			builder.AddOffset(18, OldChangeNewItemIDOffset.Value, 0);
		}

		// Token: 0x06002042 RID: 8258 RVA: 0x00085F5B File Offset: 0x0008435B
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, StringOffset PlayerLevelLimitOffset)
		{
			builder.AddOffset(19, PlayerLevelLimitOffset.Value, 0);
		}

		// Token: 0x06002043 RID: 8259 RVA: 0x00085F6D File Offset: 0x0008436D
		public static void AddVipLevelLimit(FlatBufferBuilder builder, StringOffset VipLevelLimitOffset)
		{
			builder.AddOffset(20, VipLevelLimitOffset.Value, 0);
		}

		// Token: 0x06002044 RID: 8260 RVA: 0x00085F7F File Offset: 0x0008437F
		public static void AddDungeonHardLimit(FlatBufferBuilder builder, StringOffset DungeonHardLimitOffset)
		{
			builder.AddOffset(21, DungeonHardLimitOffset.Value, 0);
		}

		// Token: 0x06002045 RID: 8261 RVA: 0x00085F91 File Offset: 0x00084391
		public static void AddDungeonSubTypeLimit(FlatBufferBuilder builder, StringOffset DungeonSubTypeLimitOffset)
		{
			builder.AddOffset(22, DungeonSubTypeLimitOffset.Value, 0);
		}

		// Token: 0x06002046 RID: 8262 RVA: 0x00085FA3 File Offset: 0x000843A3
		public static void AddDungeonIdLimit(FlatBufferBuilder builder, StringOffset DungeonIdLimitOffset)
		{
			builder.AddOffset(23, DungeonIdLimitOffset.Value, 0);
		}

		// Token: 0x06002047 RID: 8263 RVA: 0x00085FB5 File Offset: 0x000843B5
		public static void AddDiscountRate(FlatBufferBuilder builder, StringOffset DiscountRateOffset)
		{
			builder.AddOffset(24, DiscountRateOffset.Value, 0);
		}

		// Token: 0x06002048 RID: 8264 RVA: 0x00085FC7 File Offset: 0x000843C7
		public static void AddDiscountRateWeight(FlatBufferBuilder builder, StringOffset DiscountRateWeightOffset)
		{
			builder.AddOffset(25, DiscountRateWeightOffset.Value, 0);
		}

		// Token: 0x06002049 RID: 8265 RVA: 0x00085FD9 File Offset: 0x000843D9
		public static void AddMallGoodID(FlatBufferBuilder builder, int MallGoodID)
		{
			builder.AddInt(26, MallGoodID, 0);
		}

		// Token: 0x0600204A RID: 8266 RVA: 0x00085FE5 File Offset: 0x000843E5
		public static void AddAttFit(FlatBufferBuilder builder, int AttFit)
		{
			builder.AddInt(27, AttFit, 0);
		}

		// Token: 0x0600204B RID: 8267 RVA: 0x00085FF1 File Offset: 0x000843F1
		public static void AddShowLevelLimit(FlatBufferBuilder builder, int ShowLevelLimit)
		{
			builder.AddInt(28, ShowLevelLimit, 0);
		}

		// Token: 0x0600204C RID: 8268 RVA: 0x00085FFD File Offset: 0x000843FD
		public static void AddBuyLimit(FlatBufferBuilder builder, int BuyLimit)
		{
			builder.AddInt(29, BuyLimit, 0);
		}

		// Token: 0x0600204D RID: 8269 RVA: 0x0008600C File Offset: 0x0008440C
		public static Offset<ChiJiShopItemTable> EndChiJiShopItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiShopItemTable>(value);
		}

		// Token: 0x0600204E RID: 8270 RVA: 0x00086026 File Offset: 0x00084426
		public static void FinishChiJiShopItemTableBuffer(FlatBufferBuilder builder, Offset<ChiJiShopItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F7E RID: 3966
		private Table __p = new Table();

		// Token: 0x02000328 RID: 808
		public enum eSubType
		{
			// Token: 0x04000F80 RID: 3968
			ST_NONE,
			// Token: 0x04000F81 RID: 3969
			ST_MATERIAL,
			// Token: 0x04000F82 RID: 3970
			ST_WEAPON,
			// Token: 0x04000F83 RID: 3971
			ST_ARMOR,
			// Token: 0x04000F84 RID: 3972
			ST_JEWELRY,
			// Token: 0x04000F85 RID: 3973
			ST_COST,
			// Token: 0x04000F86 RID: 3974
			ST_VALUABLE,
			// Token: 0x04000F87 RID: 3975
			ST_RETINUE,
			// Token: 0x04000F88 RID: 3976
			ST_TITLE,
			// Token: 0x04000F89 RID: 3977
			ST_ENERGY,
			// Token: 0x04000F8A RID: 3978
			ST_FASHION,
			// Token: 0x04000F8B RID: 3979
			ST_ORDINARY,
			// Token: 0x04000F8C RID: 3980
			ST_DAILY,
			// Token: 0x04000F8D RID: 3981
			ST_GOODS,
			// Token: 0x04000F8E RID: 3982
			ST_EQUIP
		}

		// Token: 0x02000329 RID: 809
		public enum eCrypt
		{
			// Token: 0x04000F90 RID: 3984
			code = 2000239930
		}
	}
}
