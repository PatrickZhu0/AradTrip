using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000484 RID: 1156
	public class GuildStatueTable : IFlatbufferObject
	{
		// Token: 0x17000E09 RID: 3593
		// (get) Token: 0x060037E3 RID: 14307 RVA: 0x000BEB74 File Offset: 0x000BCF74
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060037E4 RID: 14308 RVA: 0x000BEB81 File Offset: 0x000BCF81
		public static GuildStatueTable GetRootAsGuildStatueTable(ByteBuffer _bb)
		{
			return GuildStatueTable.GetRootAsGuildStatueTable(_bb, new GuildStatueTable());
		}

		// Token: 0x060037E5 RID: 14309 RVA: 0x000BEB8E File Offset: 0x000BCF8E
		public static GuildStatueTable GetRootAsGuildStatueTable(ByteBuffer _bb, GuildStatueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060037E6 RID: 14310 RVA: 0x000BEBAA File Offset: 0x000BCFAA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060037E7 RID: 14311 RVA: 0x000BEBC4 File Offset: 0x000BCFC4
		public GuildStatueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000E0A RID: 3594
		// (get) Token: 0x060037E8 RID: 14312 RVA: 0x000BEBD0 File Offset: 0x000BCFD0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (140612475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E0B RID: 3595
		// (get) Token: 0x060037E9 RID: 14313 RVA: 0x000BEC1C File Offset: 0x000BD01C
		public GuildStatueTable.eWorship Worship
		{
			get
			{
				int num = this.__p.__offset(6);
				return (GuildStatueTable.eWorship)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E0C RID: 3596
		// (get) Token: 0x060037EA RID: 14314 RVA: 0x000BEC60 File Offset: 0x000BD060
		public int CostItemID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (140612475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E0D RID: 3597
		// (get) Token: 0x060037EB RID: 14315 RVA: 0x000BECAC File Offset: 0x000BD0AC
		public int CostItemCount
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (140612475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E0E RID: 3598
		// (get) Token: 0x060037EC RID: 14316 RVA: 0x000BECF8 File Offset: 0x000BD0F8
		public int GetItemID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (140612475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E0F RID: 3599
		// (get) Token: 0x060037ED RID: 14317 RVA: 0x000BED44 File Offset: 0x000BD144
		public int GetItemCount
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (140612475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000E10 RID: 3600
		// (get) Token: 0x060037EE RID: 14318 RVA: 0x000BED90 File Offset: 0x000BD190
		public int GetBuffID
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (140612475 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060037EF RID: 14319 RVA: 0x000BEDDC File Offset: 0x000BD1DC
		public static Offset<GuildStatueTable> CreateGuildStatueTable(FlatBufferBuilder builder, int ID = 0, GuildStatueTable.eWorship Worship = GuildStatueTable.eWorship.Normal, int CostItemID = 0, int CostItemCount = 0, int GetItemID = 0, int GetItemCount = 0, int GetBuffID = 0)
		{
			builder.StartObject(7);
			GuildStatueTable.AddGetBuffID(builder, GetBuffID);
			GuildStatueTable.AddGetItemCount(builder, GetItemCount);
			GuildStatueTable.AddGetItemID(builder, GetItemID);
			GuildStatueTable.AddCostItemCount(builder, CostItemCount);
			GuildStatueTable.AddCostItemID(builder, CostItemID);
			GuildStatueTable.AddWorship(builder, Worship);
			GuildStatueTable.AddID(builder, ID);
			return GuildStatueTable.EndGuildStatueTable(builder);
		}

		// Token: 0x060037F0 RID: 14320 RVA: 0x000BEE2B File Offset: 0x000BD22B
		public static void StartGuildStatueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060037F1 RID: 14321 RVA: 0x000BEE34 File Offset: 0x000BD234
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060037F2 RID: 14322 RVA: 0x000BEE3F File Offset: 0x000BD23F
		public static void AddWorship(FlatBufferBuilder builder, GuildStatueTable.eWorship Worship)
		{
			builder.AddInt(1, (int)Worship, 0);
		}

		// Token: 0x060037F3 RID: 14323 RVA: 0x000BEE4A File Offset: 0x000BD24A
		public static void AddCostItemID(FlatBufferBuilder builder, int CostItemID)
		{
			builder.AddInt(2, CostItemID, 0);
		}

		// Token: 0x060037F4 RID: 14324 RVA: 0x000BEE55 File Offset: 0x000BD255
		public static void AddCostItemCount(FlatBufferBuilder builder, int CostItemCount)
		{
			builder.AddInt(3, CostItemCount, 0);
		}

		// Token: 0x060037F5 RID: 14325 RVA: 0x000BEE60 File Offset: 0x000BD260
		public static void AddGetItemID(FlatBufferBuilder builder, int GetItemID)
		{
			builder.AddInt(4, GetItemID, 0);
		}

		// Token: 0x060037F6 RID: 14326 RVA: 0x000BEE6B File Offset: 0x000BD26B
		public static void AddGetItemCount(FlatBufferBuilder builder, int GetItemCount)
		{
			builder.AddInt(5, GetItemCount, 0);
		}

		// Token: 0x060037F7 RID: 14327 RVA: 0x000BEE76 File Offset: 0x000BD276
		public static void AddGetBuffID(FlatBufferBuilder builder, int GetBuffID)
		{
			builder.AddInt(6, GetBuffID, 0);
		}

		// Token: 0x060037F8 RID: 14328 RVA: 0x000BEE84 File Offset: 0x000BD284
		public static Offset<GuildStatueTable> EndGuildStatueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildStatueTable>(value);
		}

		// Token: 0x060037F9 RID: 14329 RVA: 0x000BEE9E File Offset: 0x000BD29E
		public static void FinishGuildStatueTableBuffer(FlatBufferBuilder builder, Offset<GuildStatueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015EF RID: 5615
		private Table __p = new Table();

		// Token: 0x02000485 RID: 1157
		public enum eWorship
		{
			// Token: 0x040015F1 RID: 5617
			Normal,
			// Token: 0x040015F2 RID: 5618
			Middle,
			// Token: 0x040015F3 RID: 5619
			High
		}

		// Token: 0x02000486 RID: 1158
		public enum eCrypt
		{
			// Token: 0x040015F5 RID: 5621
			code = 140612475
		}
	}
}
