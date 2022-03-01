using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000469 RID: 1129
	public class GuildBuildingTable : IFlatbufferObject
	{
		// Token: 0x17000D89 RID: 3465
		// (get) Token: 0x0600363F RID: 13887 RVA: 0x000BB038 File Offset: 0x000B9438
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003640 RID: 13888 RVA: 0x000BB045 File Offset: 0x000B9445
		public static GuildBuildingTable GetRootAsGuildBuildingTable(ByteBuffer _bb)
		{
			return GuildBuildingTable.GetRootAsGuildBuildingTable(_bb, new GuildBuildingTable());
		}

		// Token: 0x06003641 RID: 13889 RVA: 0x000BB052 File Offset: 0x000B9452
		public static GuildBuildingTable GetRootAsGuildBuildingTable(ByteBuffer _bb, GuildBuildingTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003642 RID: 13890 RVA: 0x000BB06E File Offset: 0x000B946E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003643 RID: 13891 RVA: 0x000BB088 File Offset: 0x000B9488
		public GuildBuildingTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000D8A RID: 3466
		// (get) Token: 0x06003644 RID: 13892 RVA: 0x000BB094 File Offset: 0x000B9494
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D8B RID: 3467
		// (get) Token: 0x06003645 RID: 13893 RVA: 0x000BB0E0 File Offset: 0x000B94E0
		public int MainCost
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D8C RID: 3468
		// (get) Token: 0x06003646 RID: 13894 RVA: 0x000BB12C File Offset: 0x000B952C
		public int ShopCost
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D8D RID: 3469
		// (get) Token: 0x06003647 RID: 13895 RVA: 0x000BB178 File Offset: 0x000B9578
		public int TableCost
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D8E RID: 3470
		// (get) Token: 0x06003648 RID: 13896 RVA: 0x000BB1C4 File Offset: 0x000B95C4
		public int DungeonCost
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D8F RID: 3471
		// (get) Token: 0x06003649 RID: 13897 RVA: 0x000BB210 File Offset: 0x000B9610
		public int StatueCost
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D90 RID: 3472
		// (get) Token: 0x0600364A RID: 13898 RVA: 0x000BB25C File Offset: 0x000B965C
		public int BattleCost
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D91 RID: 3473
		// (get) Token: 0x0600364B RID: 13899 RVA: 0x000BB2A8 File Offset: 0x000B96A8
		public int WelfareCost
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D92 RID: 3474
		// (get) Token: 0x0600364C RID: 13900 RVA: 0x000BB2F4 File Offset: 0x000B96F4
		public int HonourCost
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D93 RID: 3475
		// (get) Token: 0x0600364D RID: 13901 RVA: 0x000BB340 File Offset: 0x000B9740
		public int FeteCost
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D94 RID: 3476
		// (get) Token: 0x0600364E RID: 13902 RVA: 0x000BB38C File Offset: 0x000B978C
		public int ShopId
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D95 RID: 3477
		// (get) Token: 0x0600364F RID: 13903 RVA: 0x000BB3D8 File Offset: 0x000B97D8
		public int WelfareGiftId
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (200448191 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003650 RID: 13904 RVA: 0x000BB424 File Offset: 0x000B9824
		public static Offset<GuildBuildingTable> CreateGuildBuildingTable(FlatBufferBuilder builder, int ID = 0, int MainCost = 0, int ShopCost = 0, int TableCost = 0, int DungeonCost = 0, int StatueCost = 0, int BattleCost = 0, int WelfareCost = 0, int HonourCost = 0, int FeteCost = 0, int ShopId = 0, int WelfareGiftId = 0)
		{
			builder.StartObject(12);
			GuildBuildingTable.AddWelfareGiftId(builder, WelfareGiftId);
			GuildBuildingTable.AddShopId(builder, ShopId);
			GuildBuildingTable.AddFeteCost(builder, FeteCost);
			GuildBuildingTable.AddHonourCost(builder, HonourCost);
			GuildBuildingTable.AddWelfareCost(builder, WelfareCost);
			GuildBuildingTable.AddBattleCost(builder, BattleCost);
			GuildBuildingTable.AddStatueCost(builder, StatueCost);
			GuildBuildingTable.AddDungeonCost(builder, DungeonCost);
			GuildBuildingTable.AddTableCost(builder, TableCost);
			GuildBuildingTable.AddShopCost(builder, ShopCost);
			GuildBuildingTable.AddMainCost(builder, MainCost);
			GuildBuildingTable.AddID(builder, ID);
			return GuildBuildingTable.EndGuildBuildingTable(builder);
		}

		// Token: 0x06003651 RID: 13905 RVA: 0x000BB49C File Offset: 0x000B989C
		public static void StartGuildBuildingTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06003652 RID: 13906 RVA: 0x000BB4A6 File Offset: 0x000B98A6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003653 RID: 13907 RVA: 0x000BB4B1 File Offset: 0x000B98B1
		public static void AddMainCost(FlatBufferBuilder builder, int MainCost)
		{
			builder.AddInt(1, MainCost, 0);
		}

		// Token: 0x06003654 RID: 13908 RVA: 0x000BB4BC File Offset: 0x000B98BC
		public static void AddShopCost(FlatBufferBuilder builder, int ShopCost)
		{
			builder.AddInt(2, ShopCost, 0);
		}

		// Token: 0x06003655 RID: 13909 RVA: 0x000BB4C7 File Offset: 0x000B98C7
		public static void AddTableCost(FlatBufferBuilder builder, int TableCost)
		{
			builder.AddInt(3, TableCost, 0);
		}

		// Token: 0x06003656 RID: 13910 RVA: 0x000BB4D2 File Offset: 0x000B98D2
		public static void AddDungeonCost(FlatBufferBuilder builder, int DungeonCost)
		{
			builder.AddInt(4, DungeonCost, 0);
		}

		// Token: 0x06003657 RID: 13911 RVA: 0x000BB4DD File Offset: 0x000B98DD
		public static void AddStatueCost(FlatBufferBuilder builder, int StatueCost)
		{
			builder.AddInt(5, StatueCost, 0);
		}

		// Token: 0x06003658 RID: 13912 RVA: 0x000BB4E8 File Offset: 0x000B98E8
		public static void AddBattleCost(FlatBufferBuilder builder, int BattleCost)
		{
			builder.AddInt(6, BattleCost, 0);
		}

		// Token: 0x06003659 RID: 13913 RVA: 0x000BB4F3 File Offset: 0x000B98F3
		public static void AddWelfareCost(FlatBufferBuilder builder, int WelfareCost)
		{
			builder.AddInt(7, WelfareCost, 0);
		}

		// Token: 0x0600365A RID: 13914 RVA: 0x000BB4FE File Offset: 0x000B98FE
		public static void AddHonourCost(FlatBufferBuilder builder, int HonourCost)
		{
			builder.AddInt(8, HonourCost, 0);
		}

		// Token: 0x0600365B RID: 13915 RVA: 0x000BB509 File Offset: 0x000B9909
		public static void AddFeteCost(FlatBufferBuilder builder, int FeteCost)
		{
			builder.AddInt(9, FeteCost, 0);
		}

		// Token: 0x0600365C RID: 13916 RVA: 0x000BB515 File Offset: 0x000B9915
		public static void AddShopId(FlatBufferBuilder builder, int ShopId)
		{
			builder.AddInt(10, ShopId, 0);
		}

		// Token: 0x0600365D RID: 13917 RVA: 0x000BB521 File Offset: 0x000B9921
		public static void AddWelfareGiftId(FlatBufferBuilder builder, int WelfareGiftId)
		{
			builder.AddInt(11, WelfareGiftId, 0);
		}

		// Token: 0x0600365E RID: 13918 RVA: 0x000BB530 File Offset: 0x000B9930
		public static Offset<GuildBuildingTable> EndGuildBuildingTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildBuildingTable>(value);
		}

		// Token: 0x0600365F RID: 13919 RVA: 0x000BB54A File Offset: 0x000B994A
		public static void FinishGuildBuildingTableBuffer(FlatBufferBuilder builder, Offset<GuildBuildingTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015B3 RID: 5555
		private Table __p = new Table();

		// Token: 0x0200046A RID: 1130
		public enum eCrypt
		{
			// Token: 0x040015B5 RID: 5557
			code = 200448191
		}
	}
}
