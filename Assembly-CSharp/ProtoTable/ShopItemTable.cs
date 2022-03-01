using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005AC RID: 1452
	public class ShopItemTable : IFlatbufferObject
	{
		// Token: 0x1700146F RID: 5231
		// (get) Token: 0x06004B2A RID: 19242 RVA: 0x000EBFA4 File Offset: 0x000EA3A4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004B2B RID: 19243 RVA: 0x000EBFB1 File Offset: 0x000EA3B1
		public static ShopItemTable GetRootAsShopItemTable(ByteBuffer _bb)
		{
			return ShopItemTable.GetRootAsShopItemTable(_bb, new ShopItemTable());
		}

		// Token: 0x06004B2C RID: 19244 RVA: 0x000EBFBE File Offset: 0x000EA3BE
		public static ShopItemTable GetRootAsShopItemTable(ByteBuffer _bb, ShopItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004B2D RID: 19245 RVA: 0x000EBFDA File Offset: 0x000EA3DA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004B2E RID: 19246 RVA: 0x000EBFF4 File Offset: 0x000EA3F4
		public ShopItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001470 RID: 5232
		// (get) Token: 0x06004B2F RID: 19247 RVA: 0x000EC000 File Offset: 0x000EA400
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001471 RID: 5233
		// (get) Token: 0x06004B30 RID: 19248 RVA: 0x000EC04C File Offset: 0x000EA44C
		public string CommodityName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B31 RID: 19249 RVA: 0x000EC08E File Offset: 0x000EA48E
		public ArraySegment<byte>? GetCommodityNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001472 RID: 5234
		// (get) Token: 0x06004B32 RID: 19250 RVA: 0x000EC09C File Offset: 0x000EA49C
		public int ShopID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001473 RID: 5235
		// (get) Token: 0x06004B33 RID: 19251 RVA: 0x000EC0E8 File Offset: 0x000EA4E8
		public int UseEqualItem
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001474 RID: 5236
		// (get) Token: 0x06004B34 RID: 19252 RVA: 0x000EC134 File Offset: 0x000EA534
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001475 RID: 5237
		// (get) Token: 0x06004B35 RID: 19253 RVA: 0x000EC180 File Offset: 0x000EA580
		public int SortID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001476 RID: 5238
		// (get) Token: 0x06004B36 RID: 19254 RVA: 0x000EC1CC File Offset: 0x000EA5CC
		public ShopItemTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ShopItemTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001477 RID: 5239
		// (get) Token: 0x06004B37 RID: 19255 RVA: 0x000EC210 File Offset: 0x000EA610
		public int CostItemID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001478 RID: 5240
		// (get) Token: 0x06004B38 RID: 19256 RVA: 0x000EC25C File Offset: 0x000EA65C
		public int CostNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001479 RID: 5241
		// (get) Token: 0x06004B39 RID: 19257 RVA: 0x000EC2A8 File Offset: 0x000EA6A8
		public string OtherCostItems
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B3A RID: 19258 RVA: 0x000EC2EB File Offset: 0x000EA6EB
		public ArraySegment<byte>? GetOtherCostItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x1700147A RID: 5242
		// (get) Token: 0x06004B3B RID: 19259 RVA: 0x000EC2FC File Offset: 0x000EA6FC
		public int VIP
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700147B RID: 5243
		// (get) Token: 0x06004B3C RID: 19260 RVA: 0x000EC348 File Offset: 0x000EA748
		public int VIPLimite
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700147C RID: 5244
		// (get) Token: 0x06004B3D RID: 19261 RVA: 0x000EC394 File Offset: 0x000EA794
		public int NumLimite
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700147D RID: 5245
		// (get) Token: 0x06004B3E RID: 19262 RVA: 0x000EC3E0 File Offset: 0x000EA7E0
		public int LimiteOnce
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700147E RID: 5246
		// (get) Token: 0x06004B3F RID: 19263 RVA: 0x000EC42C File Offset: 0x000EA82C
		public int GroupNum
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700147F RID: 5247
		// (get) Token: 0x06004B40 RID: 19264 RVA: 0x000EC478 File Offset: 0x000EA878
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001480 RID: 5248
		// (get) Token: 0x06004B41 RID: 19265 RVA: 0x000EC4C4 File Offset: 0x000EA8C4
		public int ExLimite
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001481 RID: 5249
		// (get) Token: 0x06004B42 RID: 19266 RVA: 0x000EC510 File Offset: 0x000EA910
		public int ExValue
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001482 RID: 5250
		// (get) Token: 0x06004B43 RID: 19267 RVA: 0x000EC55C File Offset: 0x000EA95C
		public string OldChangeNewItemID
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B44 RID: 19268 RVA: 0x000EC59F File Offset: 0x000EA99F
		public ArraySegment<byte>? GetOldChangeNewItemIDBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x17001483 RID: 5251
		// (get) Token: 0x06004B45 RID: 19269 RVA: 0x000EC5B0 File Offset: 0x000EA9B0
		public string PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B46 RID: 19270 RVA: 0x000EC5F3 File Offset: 0x000EA9F3
		public ArraySegment<byte>? GetPlayerLevelLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x17001484 RID: 5252
		// (get) Token: 0x06004B47 RID: 19271 RVA: 0x000EC604 File Offset: 0x000EAA04
		public string VipLevelLimit
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B48 RID: 19272 RVA: 0x000EC647 File Offset: 0x000EAA47
		public ArraySegment<byte>? GetVipLevelLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(44);
		}

		// Token: 0x17001485 RID: 5253
		// (get) Token: 0x06004B49 RID: 19273 RVA: 0x000EC658 File Offset: 0x000EAA58
		public string DungeonHardLimit
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B4A RID: 19274 RVA: 0x000EC69B File Offset: 0x000EAA9B
		public ArraySegment<byte>? GetDungeonHardLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(46);
		}

		// Token: 0x17001486 RID: 5254
		// (get) Token: 0x06004B4B RID: 19275 RVA: 0x000EC6AC File Offset: 0x000EAAAC
		public string DungeonSubTypeLimit
		{
			get
			{
				int num = this.__p.__offset(48);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B4C RID: 19276 RVA: 0x000EC6EF File Offset: 0x000EAAEF
		public ArraySegment<byte>? GetDungeonSubTypeLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(48);
		}

		// Token: 0x17001487 RID: 5255
		// (get) Token: 0x06004B4D RID: 19277 RVA: 0x000EC700 File Offset: 0x000EAB00
		public string DungeonIdLimit
		{
			get
			{
				int num = this.__p.__offset(50);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B4E RID: 19278 RVA: 0x000EC743 File Offset: 0x000EAB43
		public ArraySegment<byte>? GetDungeonIdLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(50);
		}

		// Token: 0x17001488 RID: 5256
		// (get) Token: 0x06004B4F RID: 19279 RVA: 0x000EC754 File Offset: 0x000EAB54
		public string DiscountRate
		{
			get
			{
				int num = this.__p.__offset(52);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B50 RID: 19280 RVA: 0x000EC797 File Offset: 0x000EAB97
		public ArraySegment<byte>? GetDiscountRateBytes()
		{
			return this.__p.__vector_as_arraysegment(52);
		}

		// Token: 0x17001489 RID: 5257
		// (get) Token: 0x06004B51 RID: 19281 RVA: 0x000EC7A8 File Offset: 0x000EABA8
		public string DiscountRateWeight
		{
			get
			{
				int num = this.__p.__offset(54);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B52 RID: 19282 RVA: 0x000EC7EB File Offset: 0x000EABEB
		public ArraySegment<byte>? GetDiscountRateWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(54);
		}

		// Token: 0x1700148A RID: 5258
		// (get) Token: 0x06004B53 RID: 19283 RVA: 0x000EC7FC File Offset: 0x000EABFC
		public int MallGoodID
		{
			get
			{
				int num = this.__p.__offset(56);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700148B RID: 5259
		// (get) Token: 0x06004B54 RID: 19284 RVA: 0x000EC848 File Offset: 0x000EAC48
		public int AttFit
		{
			get
			{
				int num = this.__p.__offset(58);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700148C RID: 5260
		// (get) Token: 0x06004B55 RID: 19285 RVA: 0x000EC894 File Offset: 0x000EAC94
		public int ShowLevelLimit
		{
			get
			{
				int num = this.__p.__offset(60);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700148D RID: 5261
		// (get) Token: 0x06004B56 RID: 19286 RVA: 0x000EC8E0 File Offset: 0x000EACE0
		public int BuyLimit
		{
			get
			{
				int num = this.__p.__offset(62);
				return (num == 0) ? 0 : (-1236346225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004B57 RID: 19287 RVA: 0x000EC92C File Offset: 0x000EAD2C
		public static Offset<ShopItemTable> CreateShopItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset CommodityNameOffset = default(StringOffset), int ShopID = 0, int UseEqualItem = 0, int ItemID = 0, int SortID = 0, ShopItemTable.eSubType SubType = ShopItemTable.eSubType.ST_NONE, int CostItemID = 0, int CostNum = 0, StringOffset OtherCostItemsOffset = default(StringOffset), int VIP = 0, int VIPLimite = 0, int NumLimite = 0, int LimiteOnce = 0, int GroupNum = 0, int Weight = 0, int ExLimite = 0, int ExValue = 0, StringOffset OldChangeNewItemIDOffset = default(StringOffset), StringOffset PlayerLevelLimitOffset = default(StringOffset), StringOffset VipLevelLimitOffset = default(StringOffset), StringOffset DungeonHardLimitOffset = default(StringOffset), StringOffset DungeonSubTypeLimitOffset = default(StringOffset), StringOffset DungeonIdLimitOffset = default(StringOffset), StringOffset DiscountRateOffset = default(StringOffset), StringOffset DiscountRateWeightOffset = default(StringOffset), int MallGoodID = 0, int AttFit = 0, int ShowLevelLimit = 0, int BuyLimit = 0)
		{
			builder.StartObject(30);
			ShopItemTable.AddBuyLimit(builder, BuyLimit);
			ShopItemTable.AddShowLevelLimit(builder, ShowLevelLimit);
			ShopItemTable.AddAttFit(builder, AttFit);
			ShopItemTable.AddMallGoodID(builder, MallGoodID);
			ShopItemTable.AddDiscountRateWeight(builder, DiscountRateWeightOffset);
			ShopItemTable.AddDiscountRate(builder, DiscountRateOffset);
			ShopItemTable.AddDungeonIdLimit(builder, DungeonIdLimitOffset);
			ShopItemTable.AddDungeonSubTypeLimit(builder, DungeonSubTypeLimitOffset);
			ShopItemTable.AddDungeonHardLimit(builder, DungeonHardLimitOffset);
			ShopItemTable.AddVipLevelLimit(builder, VipLevelLimitOffset);
			ShopItemTable.AddPlayerLevelLimit(builder, PlayerLevelLimitOffset);
			ShopItemTable.AddOldChangeNewItemID(builder, OldChangeNewItemIDOffset);
			ShopItemTable.AddExValue(builder, ExValue);
			ShopItemTable.AddExLimite(builder, ExLimite);
			ShopItemTable.AddWeight(builder, Weight);
			ShopItemTable.AddGroupNum(builder, GroupNum);
			ShopItemTable.AddLimiteOnce(builder, LimiteOnce);
			ShopItemTable.AddNumLimite(builder, NumLimite);
			ShopItemTable.AddVIPLimite(builder, VIPLimite);
			ShopItemTable.AddVIP(builder, VIP);
			ShopItemTable.AddOtherCostItems(builder, OtherCostItemsOffset);
			ShopItemTable.AddCostNum(builder, CostNum);
			ShopItemTable.AddCostItemID(builder, CostItemID);
			ShopItemTable.AddSubType(builder, SubType);
			ShopItemTable.AddSortID(builder, SortID);
			ShopItemTable.AddItemID(builder, ItemID);
			ShopItemTable.AddUseEqualItem(builder, UseEqualItem);
			ShopItemTable.AddShopID(builder, ShopID);
			ShopItemTable.AddCommodityName(builder, CommodityNameOffset);
			ShopItemTable.AddID(builder, ID);
			return ShopItemTable.EndShopItemTable(builder);
		}

		// Token: 0x06004B58 RID: 19288 RVA: 0x000ECA34 File Offset: 0x000EAE34
		public static void StartShopItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(30);
		}

		// Token: 0x06004B59 RID: 19289 RVA: 0x000ECA3E File Offset: 0x000EAE3E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004B5A RID: 19290 RVA: 0x000ECA49 File Offset: 0x000EAE49
		public static void AddCommodityName(FlatBufferBuilder builder, StringOffset CommodityNameOffset)
		{
			builder.AddOffset(1, CommodityNameOffset.Value, 0);
		}

		// Token: 0x06004B5B RID: 19291 RVA: 0x000ECA5A File Offset: 0x000EAE5A
		public static void AddShopID(FlatBufferBuilder builder, int ShopID)
		{
			builder.AddInt(2, ShopID, 0);
		}

		// Token: 0x06004B5C RID: 19292 RVA: 0x000ECA65 File Offset: 0x000EAE65
		public static void AddUseEqualItem(FlatBufferBuilder builder, int UseEqualItem)
		{
			builder.AddInt(3, UseEqualItem, 0);
		}

		// Token: 0x06004B5D RID: 19293 RVA: 0x000ECA70 File Offset: 0x000EAE70
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(4, ItemID, 0);
		}

		// Token: 0x06004B5E RID: 19294 RVA: 0x000ECA7B File Offset: 0x000EAE7B
		public static void AddSortID(FlatBufferBuilder builder, int SortID)
		{
			builder.AddInt(5, SortID, 0);
		}

		// Token: 0x06004B5F RID: 19295 RVA: 0x000ECA86 File Offset: 0x000EAE86
		public static void AddSubType(FlatBufferBuilder builder, ShopItemTable.eSubType SubType)
		{
			builder.AddInt(6, (int)SubType, 0);
		}

		// Token: 0x06004B60 RID: 19296 RVA: 0x000ECA91 File Offset: 0x000EAE91
		public static void AddCostItemID(FlatBufferBuilder builder, int CostItemID)
		{
			builder.AddInt(7, CostItemID, 0);
		}

		// Token: 0x06004B61 RID: 19297 RVA: 0x000ECA9C File Offset: 0x000EAE9C
		public static void AddCostNum(FlatBufferBuilder builder, int CostNum)
		{
			builder.AddInt(8, CostNum, 0);
		}

		// Token: 0x06004B62 RID: 19298 RVA: 0x000ECAA7 File Offset: 0x000EAEA7
		public static void AddOtherCostItems(FlatBufferBuilder builder, StringOffset OtherCostItemsOffset)
		{
			builder.AddOffset(9, OtherCostItemsOffset.Value, 0);
		}

		// Token: 0x06004B63 RID: 19299 RVA: 0x000ECAB9 File Offset: 0x000EAEB9
		public static void AddVIP(FlatBufferBuilder builder, int VIP)
		{
			builder.AddInt(10, VIP, 0);
		}

		// Token: 0x06004B64 RID: 19300 RVA: 0x000ECAC5 File Offset: 0x000EAEC5
		public static void AddVIPLimite(FlatBufferBuilder builder, int VIPLimite)
		{
			builder.AddInt(11, VIPLimite, 0);
		}

		// Token: 0x06004B65 RID: 19301 RVA: 0x000ECAD1 File Offset: 0x000EAED1
		public static void AddNumLimite(FlatBufferBuilder builder, int NumLimite)
		{
			builder.AddInt(12, NumLimite, 0);
		}

		// Token: 0x06004B66 RID: 19302 RVA: 0x000ECADD File Offset: 0x000EAEDD
		public static void AddLimiteOnce(FlatBufferBuilder builder, int LimiteOnce)
		{
			builder.AddInt(13, LimiteOnce, 0);
		}

		// Token: 0x06004B67 RID: 19303 RVA: 0x000ECAE9 File Offset: 0x000EAEE9
		public static void AddGroupNum(FlatBufferBuilder builder, int GroupNum)
		{
			builder.AddInt(14, GroupNum, 0);
		}

		// Token: 0x06004B68 RID: 19304 RVA: 0x000ECAF5 File Offset: 0x000EAEF5
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(15, Weight, 0);
		}

		// Token: 0x06004B69 RID: 19305 RVA: 0x000ECB01 File Offset: 0x000EAF01
		public static void AddExLimite(FlatBufferBuilder builder, int ExLimite)
		{
			builder.AddInt(16, ExLimite, 0);
		}

		// Token: 0x06004B6A RID: 19306 RVA: 0x000ECB0D File Offset: 0x000EAF0D
		public static void AddExValue(FlatBufferBuilder builder, int ExValue)
		{
			builder.AddInt(17, ExValue, 0);
		}

		// Token: 0x06004B6B RID: 19307 RVA: 0x000ECB19 File Offset: 0x000EAF19
		public static void AddOldChangeNewItemID(FlatBufferBuilder builder, StringOffset OldChangeNewItemIDOffset)
		{
			builder.AddOffset(18, OldChangeNewItemIDOffset.Value, 0);
		}

		// Token: 0x06004B6C RID: 19308 RVA: 0x000ECB2B File Offset: 0x000EAF2B
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, StringOffset PlayerLevelLimitOffset)
		{
			builder.AddOffset(19, PlayerLevelLimitOffset.Value, 0);
		}

		// Token: 0x06004B6D RID: 19309 RVA: 0x000ECB3D File Offset: 0x000EAF3D
		public static void AddVipLevelLimit(FlatBufferBuilder builder, StringOffset VipLevelLimitOffset)
		{
			builder.AddOffset(20, VipLevelLimitOffset.Value, 0);
		}

		// Token: 0x06004B6E RID: 19310 RVA: 0x000ECB4F File Offset: 0x000EAF4F
		public static void AddDungeonHardLimit(FlatBufferBuilder builder, StringOffset DungeonHardLimitOffset)
		{
			builder.AddOffset(21, DungeonHardLimitOffset.Value, 0);
		}

		// Token: 0x06004B6F RID: 19311 RVA: 0x000ECB61 File Offset: 0x000EAF61
		public static void AddDungeonSubTypeLimit(FlatBufferBuilder builder, StringOffset DungeonSubTypeLimitOffset)
		{
			builder.AddOffset(22, DungeonSubTypeLimitOffset.Value, 0);
		}

		// Token: 0x06004B70 RID: 19312 RVA: 0x000ECB73 File Offset: 0x000EAF73
		public static void AddDungeonIdLimit(FlatBufferBuilder builder, StringOffset DungeonIdLimitOffset)
		{
			builder.AddOffset(23, DungeonIdLimitOffset.Value, 0);
		}

		// Token: 0x06004B71 RID: 19313 RVA: 0x000ECB85 File Offset: 0x000EAF85
		public static void AddDiscountRate(FlatBufferBuilder builder, StringOffset DiscountRateOffset)
		{
			builder.AddOffset(24, DiscountRateOffset.Value, 0);
		}

		// Token: 0x06004B72 RID: 19314 RVA: 0x000ECB97 File Offset: 0x000EAF97
		public static void AddDiscountRateWeight(FlatBufferBuilder builder, StringOffset DiscountRateWeightOffset)
		{
			builder.AddOffset(25, DiscountRateWeightOffset.Value, 0);
		}

		// Token: 0x06004B73 RID: 19315 RVA: 0x000ECBA9 File Offset: 0x000EAFA9
		public static void AddMallGoodID(FlatBufferBuilder builder, int MallGoodID)
		{
			builder.AddInt(26, MallGoodID, 0);
		}

		// Token: 0x06004B74 RID: 19316 RVA: 0x000ECBB5 File Offset: 0x000EAFB5
		public static void AddAttFit(FlatBufferBuilder builder, int AttFit)
		{
			builder.AddInt(27, AttFit, 0);
		}

		// Token: 0x06004B75 RID: 19317 RVA: 0x000ECBC1 File Offset: 0x000EAFC1
		public static void AddShowLevelLimit(FlatBufferBuilder builder, int ShowLevelLimit)
		{
			builder.AddInt(28, ShowLevelLimit, 0);
		}

		// Token: 0x06004B76 RID: 19318 RVA: 0x000ECBCD File Offset: 0x000EAFCD
		public static void AddBuyLimit(FlatBufferBuilder builder, int BuyLimit)
		{
			builder.AddInt(29, BuyLimit, 0);
		}

		// Token: 0x06004B77 RID: 19319 RVA: 0x000ECBDC File Offset: 0x000EAFDC
		public static Offset<ShopItemTable> EndShopItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ShopItemTable>(value);
		}

		// Token: 0x06004B78 RID: 19320 RVA: 0x000ECBF6 File Offset: 0x000EAFF6
		public static void FinishShopItemTableBuffer(FlatBufferBuilder builder, Offset<ShopItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B14 RID: 6932
		private Table __p = new Table();

		// Token: 0x020005AD RID: 1453
		public enum eSubType
		{
			// Token: 0x04001B16 RID: 6934
			ST_NONE,
			// Token: 0x04001B17 RID: 6935
			ST_MATERIAL,
			// Token: 0x04001B18 RID: 6936
			ST_WEAPON,
			// Token: 0x04001B19 RID: 6937
			ST_ARMOR,
			// Token: 0x04001B1A RID: 6938
			ST_JEWELRY,
			// Token: 0x04001B1B RID: 6939
			ST_COST,
			// Token: 0x04001B1C RID: 6940
			ST_VALUABLE,
			// Token: 0x04001B1D RID: 6941
			ST_RETINUE,
			// Token: 0x04001B1E RID: 6942
			ST_TITLE,
			// Token: 0x04001B1F RID: 6943
			ST_ENERGY,
			// Token: 0x04001B20 RID: 6944
			ST_FASHION,
			// Token: 0x04001B21 RID: 6945
			ST_ORDINARY,
			// Token: 0x04001B22 RID: 6946
			ST_DAILY,
			// Token: 0x04001B23 RID: 6947
			ST_GOODS,
			// Token: 0x04001B24 RID: 6948
			ST_EQUIP
		}

		// Token: 0x020005AE RID: 1454
		public enum eCrypt
		{
			// Token: 0x04001B26 RID: 6950
			code = -1236346225
		}
	}
}
