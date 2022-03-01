using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000482 RID: 1154
	public class GuildSkillTable : IFlatbufferObject
	{
		// Token: 0x17000E01 RID: 3585
		// (get) Token: 0x060037CA RID: 14282 RVA: 0x000BE818 File Offset: 0x000BCC18
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060037CB RID: 14283 RVA: 0x000BE825 File Offset: 0x000BCC25
		public static GuildSkillTable GetRootAsGuildSkillTable(ByteBuffer _bb)
		{
			return GuildSkillTable.GetRootAsGuildSkillTable(_bb, new GuildSkillTable());
		}

		// Token: 0x060037CC RID: 14284 RVA: 0x000BE832 File Offset: 0x000BCC32
		public static GuildSkillTable GetRootAsGuildSkillTable(ByteBuffer _bb, GuildSkillTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060037CD RID: 14285 RVA: 0x000BE84E File Offset: 0x000BCC4E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060037CE RID: 14286 RVA: 0x000BE868 File Offset: 0x000BCC68
		public GuildSkillTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E02 RID: 3586
		// (get) Token: 0x060037CF RID: 14287 RVA: 0x000BE874 File Offset: 0x000BCC74
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1186932208 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E03 RID: 3587
		// (get) Token: 0x060037D0 RID: 14288 RVA: 0x000BE8C0 File Offset: 0x000BCCC0
		public int SkillID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1186932208 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E04 RID: 3588
		// (get) Token: 0x060037D1 RID: 14289 RVA: 0x000BE90C File Offset: 0x000BCD0C
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060037D2 RID: 14290 RVA: 0x000BE94E File Offset: 0x000BCD4E
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000E05 RID: 3589
		// (get) Token: 0x060037D3 RID: 14291 RVA: 0x000BE95C File Offset: 0x000BCD5C
		public int SkillLevel
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1186932208 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E06 RID: 3590
		// (get) Token: 0x060037D4 RID: 14292 RVA: 0x000BE9A8 File Offset: 0x000BCDA8
		public int NeedBattleLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1186932208 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E07 RID: 3591
		// (get) Token: 0x060037D5 RID: 14293 RVA: 0x000BE9F4 File Offset: 0x000BCDF4
		public int ContriCost
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1186932208 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E08 RID: 3592
		// (get) Token: 0x060037D6 RID: 14294 RVA: 0x000BEA40 File Offset: 0x000BCE40
		public int GoldCost
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1186932208 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060037D7 RID: 14295 RVA: 0x000BEA8C File Offset: 0x000BCE8C
		public static Offset<GuildSkillTable> CreateGuildSkillTable(FlatBufferBuilder builder, int ID = 0, int SkillID = 0, StringOffset DescOffset = default(StringOffset), int SkillLevel = 0, int NeedBattleLevel = 0, int ContriCost = 0, int GoldCost = 0)
		{
			builder.StartObject(7);
			GuildSkillTable.AddGoldCost(builder, GoldCost);
			GuildSkillTable.AddContriCost(builder, ContriCost);
			GuildSkillTable.AddNeedBattleLevel(builder, NeedBattleLevel);
			GuildSkillTable.AddSkillLevel(builder, SkillLevel);
			GuildSkillTable.AddDesc(builder, DescOffset);
			GuildSkillTable.AddSkillID(builder, SkillID);
			GuildSkillTable.AddID(builder, ID);
			return GuildSkillTable.EndGuildSkillTable(builder);
		}

		// Token: 0x060037D8 RID: 14296 RVA: 0x000BEADB File Offset: 0x000BCEDB
		public static void StartGuildSkillTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060037D9 RID: 14297 RVA: 0x000BEAE4 File Offset: 0x000BCEE4
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060037DA RID: 14298 RVA: 0x000BEAEF File Offset: 0x000BCEEF
		public static void AddSkillID(FlatBufferBuilder builder, int SkillID)
		{
			builder.AddInt(1, SkillID, 0);
		}

		// Token: 0x060037DB RID: 14299 RVA: 0x000BEAFA File Offset: 0x000BCEFA
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x060037DC RID: 14300 RVA: 0x000BEB0B File Offset: 0x000BCF0B
		public static void AddSkillLevel(FlatBufferBuilder builder, int SkillLevel)
		{
			builder.AddInt(3, SkillLevel, 0);
		}

		// Token: 0x060037DD RID: 14301 RVA: 0x000BEB16 File Offset: 0x000BCF16
		public static void AddNeedBattleLevel(FlatBufferBuilder builder, int NeedBattleLevel)
		{
			builder.AddInt(4, NeedBattleLevel, 0);
		}

		// Token: 0x060037DE RID: 14302 RVA: 0x000BEB21 File Offset: 0x000BCF21
		public static void AddContriCost(FlatBufferBuilder builder, int ContriCost)
		{
			builder.AddInt(5, ContriCost, 0);
		}

		// Token: 0x060037DF RID: 14303 RVA: 0x000BEB2C File Offset: 0x000BCF2C
		public static void AddGoldCost(FlatBufferBuilder builder, int GoldCost)
		{
			builder.AddInt(6, GoldCost, 0);
		}

		// Token: 0x060037E0 RID: 14304 RVA: 0x000BEB38 File Offset: 0x000BCF38
		public static Offset<GuildSkillTable> EndGuildSkillTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildSkillTable>(value);
		}

		// Token: 0x060037E1 RID: 14305 RVA: 0x000BEB52 File Offset: 0x000BCF52
		public static void FinishGuildSkillTableBuffer(FlatBufferBuilder builder, Offset<GuildSkillTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015EC RID: 5612
		private Table __p = new Table();

		// Token: 0x02000483 RID: 1155
		public enum eCrypt
		{
			// Token: 0x040015EE RID: 5614
			code = -1186932208
		}
	}
}
