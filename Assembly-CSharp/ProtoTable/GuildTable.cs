using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000487 RID: 1159
	public class GuildTable : IFlatbufferObject
	{
		// Token: 0x17000E11 RID: 3601
		// (get) Token: 0x060037FB RID: 14331 RVA: 0x000BEEC0 File Offset: 0x000BD2C0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060037FC RID: 14332 RVA: 0x000BEECD File Offset: 0x000BD2CD
		public static GuildTable GetRootAsGuildTable(ByteBuffer _bb)
		{
			return GuildTable.GetRootAsGuildTable(_bb, new GuildTable());
		}

		// Token: 0x060037FD RID: 14333 RVA: 0x000BEEDA File Offset: 0x000BD2DA
		public static GuildTable GetRootAsGuildTable(ByteBuffer _bb, GuildTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060037FE RID: 14334 RVA: 0x000BEEF6 File Offset: 0x000BD2F6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060037FF RID: 14335 RVA: 0x000BEF10 File Offset: 0x000BD310
		public GuildTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E12 RID: 3602
		// (get) Token: 0x06003800 RID: 14336 RVA: 0x000BEF1C File Offset: 0x000BD31C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E13 RID: 3603
		// (get) Token: 0x06003801 RID: 14337 RVA: 0x000BEF68 File Offset: 0x000BD368
		public int MemberNum
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E14 RID: 3604
		// (get) Token: 0x06003802 RID: 14338 RVA: 0x000BEFB4 File Offset: 0x000BD3B4
		public int ShopLevel
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E15 RID: 3605
		// (get) Token: 0x06003803 RID: 14339 RVA: 0x000BF000 File Offset: 0x000BD400
		public int TableLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E16 RID: 3606
		// (get) Token: 0x06003804 RID: 14340 RVA: 0x000BF04C File Offset: 0x000BD44C
		public int DungeonLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E17 RID: 3607
		// (get) Token: 0x06003805 RID: 14341 RVA: 0x000BF098 File Offset: 0x000BD498
		public int StatueLevel
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E18 RID: 3608
		// (get) Token: 0x06003806 RID: 14342 RVA: 0x000BF0E4 File Offset: 0x000BD4E4
		public int BattleLevel
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E19 RID: 3609
		// (get) Token: 0x06003807 RID: 14343 RVA: 0x000BF130 File Offset: 0x000BD530
		public int WelfareLevel
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E1A RID: 3610
		// (get) Token: 0x06003808 RID: 14344 RVA: 0x000BF17C File Offset: 0x000BD57C
		public int HonourLevel
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E1B RID: 3611
		// (get) Token: 0x06003809 RID: 14345 RVA: 0x000BF1C8 File Offset: 0x000BD5C8
		public int FeteLevel
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1737620587 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600380A RID: 14346 RVA: 0x000BF214 File Offset: 0x000BD614
		public static Offset<GuildTable> CreateGuildTable(FlatBufferBuilder builder, int ID = 0, int MemberNum = 0, int ShopLevel = 0, int TableLevel = 0, int DungeonLevel = 0, int StatueLevel = 0, int BattleLevel = 0, int WelfareLevel = 0, int HonourLevel = 0, int FeteLevel = 0)
		{
			builder.StartObject(10);
			GuildTable.AddFeteLevel(builder, FeteLevel);
			GuildTable.AddHonourLevel(builder, HonourLevel);
			GuildTable.AddWelfareLevel(builder, WelfareLevel);
			GuildTable.AddBattleLevel(builder, BattleLevel);
			GuildTable.AddStatueLevel(builder, StatueLevel);
			GuildTable.AddDungeonLevel(builder, DungeonLevel);
			GuildTable.AddTableLevel(builder, TableLevel);
			GuildTable.AddShopLevel(builder, ShopLevel);
			GuildTable.AddMemberNum(builder, MemberNum);
			GuildTable.AddID(builder, ID);
			return GuildTable.EndGuildTable(builder);
		}

		// Token: 0x0600380B RID: 14347 RVA: 0x000BF27C File Offset: 0x000BD67C
		public static void StartGuildTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x0600380C RID: 14348 RVA: 0x000BF286 File Offset: 0x000BD686
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600380D RID: 14349 RVA: 0x000BF291 File Offset: 0x000BD691
		public static void AddMemberNum(FlatBufferBuilder builder, int MemberNum)
		{
			builder.AddInt(1, MemberNum, 0);
		}

		// Token: 0x0600380E RID: 14350 RVA: 0x000BF29C File Offset: 0x000BD69C
		public static void AddShopLevel(FlatBufferBuilder builder, int ShopLevel)
		{
			builder.AddInt(2, ShopLevel, 0);
		}

		// Token: 0x0600380F RID: 14351 RVA: 0x000BF2A7 File Offset: 0x000BD6A7
		public static void AddTableLevel(FlatBufferBuilder builder, int TableLevel)
		{
			builder.AddInt(3, TableLevel, 0);
		}

		// Token: 0x06003810 RID: 14352 RVA: 0x000BF2B2 File Offset: 0x000BD6B2
		public static void AddDungeonLevel(FlatBufferBuilder builder, int DungeonLevel)
		{
			builder.AddInt(4, DungeonLevel, 0);
		}

		// Token: 0x06003811 RID: 14353 RVA: 0x000BF2BD File Offset: 0x000BD6BD
		public static void AddStatueLevel(FlatBufferBuilder builder, int StatueLevel)
		{
			builder.AddInt(5, StatueLevel, 0);
		}

		// Token: 0x06003812 RID: 14354 RVA: 0x000BF2C8 File Offset: 0x000BD6C8
		public static void AddBattleLevel(FlatBufferBuilder builder, int BattleLevel)
		{
			builder.AddInt(6, BattleLevel, 0);
		}

		// Token: 0x06003813 RID: 14355 RVA: 0x000BF2D3 File Offset: 0x000BD6D3
		public static void AddWelfareLevel(FlatBufferBuilder builder, int WelfareLevel)
		{
			builder.AddInt(7, WelfareLevel, 0);
		}

		// Token: 0x06003814 RID: 14356 RVA: 0x000BF2DE File Offset: 0x000BD6DE
		public static void AddHonourLevel(FlatBufferBuilder builder, int HonourLevel)
		{
			builder.AddInt(8, HonourLevel, 0);
		}

		// Token: 0x06003815 RID: 14357 RVA: 0x000BF2E9 File Offset: 0x000BD6E9
		public static void AddFeteLevel(FlatBufferBuilder builder, int FeteLevel)
		{
			builder.AddInt(9, FeteLevel, 0);
		}

		// Token: 0x06003816 RID: 14358 RVA: 0x000BF2F8 File Offset: 0x000BD6F8
		public static Offset<GuildTable> EndGuildTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildTable>(value);
		}

		// Token: 0x06003817 RID: 14359 RVA: 0x000BF312 File Offset: 0x000BD712
		public static void FinishGuildTableBuffer(FlatBufferBuilder builder, Offset<GuildTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015F6 RID: 5622
		private Table __p = new Table();

		// Token: 0x02000488 RID: 1160
		public enum eCrypt
		{
			// Token: 0x040015F8 RID: 5624
			code = -1737620587
		}
	}
}
