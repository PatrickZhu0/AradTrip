using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200046F RID: 1135
	public class GuildDungeonLvlTable : IFlatbufferObject
	{
		// Token: 0x17000DA1 RID: 3489
		// (get) Token: 0x06003688 RID: 13960 RVA: 0x000BBA28 File Offset: 0x000B9E28
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003689 RID: 13961 RVA: 0x000BBA35 File Offset: 0x000B9E35
		public static GuildDungeonLvlTable GetRootAsGuildDungeonLvlTable(ByteBuffer _bb)
		{
			return GuildDungeonLvlTable.GetRootAsGuildDungeonLvlTable(_bb, new GuildDungeonLvlTable());
		}

		// Token: 0x0600368A RID: 13962 RVA: 0x000BBA42 File Offset: 0x000B9E42
		public static GuildDungeonLvlTable GetRootAsGuildDungeonLvlTable(ByteBuffer _bb, GuildDungeonLvlTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600368B RID: 13963 RVA: 0x000BBA5E File Offset: 0x000B9E5E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600368C RID: 13964 RVA: 0x000BBA78 File Offset: 0x000B9E78
		public GuildDungeonLvlTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000DA2 RID: 3490
		// (get) Token: 0x0600368D RID: 13965 RVA: 0x000BBA84 File Offset: 0x000B9E84
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA3 RID: 3491
		// (get) Token: 0x0600368E RID: 13966 RVA: 0x000BBAD0 File Offset: 0x000B9ED0
		public int dungeonType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA4 RID: 3492
		// (get) Token: 0x0600368F RID: 13967 RVA: 0x000BBB1C File Offset: 0x000B9F1C
		public int dungeonLvl
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA5 RID: 3493
		// (get) Token: 0x06003690 RID: 13968 RVA: 0x000BBB68 File Offset: 0x000B9F68
		public int DungeonId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA6 RID: 3494
		// (get) Token: 0x06003691 RID: 13969 RVA: 0x000BBBB4 File Offset: 0x000B9FB4
		public int bossId
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA7 RID: 3495
		// (get) Token: 0x06003692 RID: 13970 RVA: 0x000BBC00 File Offset: 0x000BA000
		public string bossBlood
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003693 RID: 13971 RVA: 0x000BBC43 File Offset: 0x000BA043
		public ArraySegment<byte>? GetBossBloodBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000DA8 RID: 3496
		// (get) Token: 0x06003694 RID: 13972 RVA: 0x000BBC54 File Offset: 0x000BA054
		public int rewardType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DA9 RID: 3497
		// (get) Token: 0x06003695 RID: 13973 RVA: 0x000BBCA0 File Offset: 0x000BA0A0
		public string dungeonName
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003696 RID: 13974 RVA: 0x000BBCE3 File Offset: 0x000BA0E3
		public ArraySegment<byte>? GetDungeonNameBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000DAA RID: 3498
		// (get) Token: 0x06003697 RID: 13975 RVA: 0x000BBCF4 File Offset: 0x000BA0F4
		public int dropBuff
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DAB RID: 3499
		// (get) Token: 0x06003698 RID: 13976 RVA: 0x000BBD40 File Offset: 0x000BA140
		public string iconPath
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003699 RID: 13977 RVA: 0x000BBD83 File Offset: 0x000BA183
		public ArraySegment<byte>? GetIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000DAC RID: 3500
		// (get) Token: 0x0600369A RID: 13978 RVA: 0x000BBD94 File Offset: 0x000BA194
		public int oneStarDamage
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DAD RID: 3501
		// (get) Token: 0x0600369B RID: 13979 RVA: 0x000BBDE0 File Offset: 0x000BA1E0
		public int twoStarDamage
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DAE RID: 3502
		// (get) Token: 0x0600369C RID: 13980 RVA: 0x000BBE2C File Offset: 0x000BA22C
		public int threeStarDamage
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-2111160045 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000DAF RID: 3503
		// (get) Token: 0x0600369D RID: 13981 RVA: 0x000BBE78 File Offset: 0x000BA278
		public string playingDesc
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600369E RID: 13982 RVA: 0x000BBEBB File Offset: 0x000BA2BB
		public ArraySegment<byte>? GetPlayingDescBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000DB0 RID: 3504
		// (get) Token: 0x0600369F RID: 13983 RVA: 0x000BBECC File Offset: 0x000BA2CC
		public string weaknessDesc
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060036A0 RID: 13984 RVA: 0x000BBF0F File Offset: 0x000BA30F
		public ArraySegment<byte>? GetWeaknessDescBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000DB1 RID: 3505
		// (get) Token: 0x060036A1 RID: 13985 RVA: 0x000BBF20 File Offset: 0x000BA320
		public string recommendDesc
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060036A2 RID: 13986 RVA: 0x000BBF63 File Offset: 0x000BA363
		public ArraySegment<byte>? GetRecommendDescBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17000DB2 RID: 3506
		// (get) Token: 0x060036A3 RID: 13987 RVA: 0x000BBF74 File Offset: 0x000BA374
		public string miniIconPath
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060036A4 RID: 13988 RVA: 0x000BBFB7 File Offset: 0x000BA3B7
		public ArraySegment<byte>? GetMiniIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x060036A5 RID: 13989 RVA: 0x000BBFC8 File Offset: 0x000BA3C8
		public static Offset<GuildDungeonLvlTable> CreateGuildDungeonLvlTable(FlatBufferBuilder builder, int ID = 0, int dungeonType = 0, int dungeonLvl = 0, int DungeonId = 0, int bossId = 0, StringOffset bossBloodOffset = default(StringOffset), int rewardType = 0, StringOffset dungeonNameOffset = default(StringOffset), int dropBuff = 0, StringOffset iconPathOffset = default(StringOffset), int oneStarDamage = 0, int twoStarDamage = 0, int threeStarDamage = 0, StringOffset playingDescOffset = default(StringOffset), StringOffset weaknessDescOffset = default(StringOffset), StringOffset recommendDescOffset = default(StringOffset), StringOffset miniIconPathOffset = default(StringOffset))
		{
			builder.StartObject(17);
			GuildDungeonLvlTable.AddMiniIconPath(builder, miniIconPathOffset);
			GuildDungeonLvlTable.AddRecommendDesc(builder, recommendDescOffset);
			GuildDungeonLvlTable.AddWeaknessDesc(builder, weaknessDescOffset);
			GuildDungeonLvlTable.AddPlayingDesc(builder, playingDescOffset);
			GuildDungeonLvlTable.AddThreeStarDamage(builder, threeStarDamage);
			GuildDungeonLvlTable.AddTwoStarDamage(builder, twoStarDamage);
			GuildDungeonLvlTable.AddOneStarDamage(builder, oneStarDamage);
			GuildDungeonLvlTable.AddIconPath(builder, iconPathOffset);
			GuildDungeonLvlTable.AddDropBuff(builder, dropBuff);
			GuildDungeonLvlTable.AddDungeonName(builder, dungeonNameOffset);
			GuildDungeonLvlTable.AddRewardType(builder, rewardType);
			GuildDungeonLvlTable.AddBossBlood(builder, bossBloodOffset);
			GuildDungeonLvlTable.AddBossId(builder, bossId);
			GuildDungeonLvlTable.AddDungeonId(builder, DungeonId);
			GuildDungeonLvlTable.AddDungeonLvl(builder, dungeonLvl);
			GuildDungeonLvlTable.AddDungeonType(builder, dungeonType);
			GuildDungeonLvlTable.AddID(builder, ID);
			return GuildDungeonLvlTable.EndGuildDungeonLvlTable(builder);
		}

		// Token: 0x060036A6 RID: 13990 RVA: 0x000BC068 File Offset: 0x000BA468
		public static void StartGuildDungeonLvlTable(FlatBufferBuilder builder)
		{
			builder.StartObject(17);
		}

		// Token: 0x060036A7 RID: 13991 RVA: 0x000BC072 File Offset: 0x000BA472
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060036A8 RID: 13992 RVA: 0x000BC07D File Offset: 0x000BA47D
		public static void AddDungeonType(FlatBufferBuilder builder, int dungeonType)
		{
			builder.AddInt(1, dungeonType, 0);
		}

		// Token: 0x060036A9 RID: 13993 RVA: 0x000BC088 File Offset: 0x000BA488
		public static void AddDungeonLvl(FlatBufferBuilder builder, int dungeonLvl)
		{
			builder.AddInt(2, dungeonLvl, 0);
		}

		// Token: 0x060036AA RID: 13994 RVA: 0x000BC093 File Offset: 0x000BA493
		public static void AddDungeonId(FlatBufferBuilder builder, int DungeonId)
		{
			builder.AddInt(3, DungeonId, 0);
		}

		// Token: 0x060036AB RID: 13995 RVA: 0x000BC09E File Offset: 0x000BA49E
		public static void AddBossId(FlatBufferBuilder builder, int bossId)
		{
			builder.AddInt(4, bossId, 0);
		}

		// Token: 0x060036AC RID: 13996 RVA: 0x000BC0A9 File Offset: 0x000BA4A9
		public static void AddBossBlood(FlatBufferBuilder builder, StringOffset bossBloodOffset)
		{
			builder.AddOffset(5, bossBloodOffset.Value, 0);
		}

		// Token: 0x060036AD RID: 13997 RVA: 0x000BC0BA File Offset: 0x000BA4BA
		public static void AddRewardType(FlatBufferBuilder builder, int rewardType)
		{
			builder.AddInt(6, rewardType, 0);
		}

		// Token: 0x060036AE RID: 13998 RVA: 0x000BC0C5 File Offset: 0x000BA4C5
		public static void AddDungeonName(FlatBufferBuilder builder, StringOffset dungeonNameOffset)
		{
			builder.AddOffset(7, dungeonNameOffset.Value, 0);
		}

		// Token: 0x060036AF RID: 13999 RVA: 0x000BC0D6 File Offset: 0x000BA4D6
		public static void AddDropBuff(FlatBufferBuilder builder, int dropBuff)
		{
			builder.AddInt(8, dropBuff, 0);
		}

		// Token: 0x060036B0 RID: 14000 RVA: 0x000BC0E1 File Offset: 0x000BA4E1
		public static void AddIconPath(FlatBufferBuilder builder, StringOffset iconPathOffset)
		{
			builder.AddOffset(9, iconPathOffset.Value, 0);
		}

		// Token: 0x060036B1 RID: 14001 RVA: 0x000BC0F3 File Offset: 0x000BA4F3
		public static void AddOneStarDamage(FlatBufferBuilder builder, int oneStarDamage)
		{
			builder.AddInt(10, oneStarDamage, 0);
		}

		// Token: 0x060036B2 RID: 14002 RVA: 0x000BC0FF File Offset: 0x000BA4FF
		public static void AddTwoStarDamage(FlatBufferBuilder builder, int twoStarDamage)
		{
			builder.AddInt(11, twoStarDamage, 0);
		}

		// Token: 0x060036B3 RID: 14003 RVA: 0x000BC10B File Offset: 0x000BA50B
		public static void AddThreeStarDamage(FlatBufferBuilder builder, int threeStarDamage)
		{
			builder.AddInt(12, threeStarDamage, 0);
		}

		// Token: 0x060036B4 RID: 14004 RVA: 0x000BC117 File Offset: 0x000BA517
		public static void AddPlayingDesc(FlatBufferBuilder builder, StringOffset playingDescOffset)
		{
			builder.AddOffset(13, playingDescOffset.Value, 0);
		}

		// Token: 0x060036B5 RID: 14005 RVA: 0x000BC129 File Offset: 0x000BA529
		public static void AddWeaknessDesc(FlatBufferBuilder builder, StringOffset weaknessDescOffset)
		{
			builder.AddOffset(14, weaknessDescOffset.Value, 0);
		}

		// Token: 0x060036B6 RID: 14006 RVA: 0x000BC13B File Offset: 0x000BA53B
		public static void AddRecommendDesc(FlatBufferBuilder builder, StringOffset recommendDescOffset)
		{
			builder.AddOffset(15, recommendDescOffset.Value, 0);
		}

		// Token: 0x060036B7 RID: 14007 RVA: 0x000BC14D File Offset: 0x000BA54D
		public static void AddMiniIconPath(FlatBufferBuilder builder, StringOffset miniIconPathOffset)
		{
			builder.AddOffset(16, miniIconPathOffset.Value, 0);
		}

		// Token: 0x060036B8 RID: 14008 RVA: 0x000BC160 File Offset: 0x000BA560
		public static Offset<GuildDungeonLvlTable> EndGuildDungeonLvlTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GuildDungeonLvlTable>(value);
		}

		// Token: 0x060036B9 RID: 14009 RVA: 0x000BC17A File Offset: 0x000BA57A
		public static void FinishGuildDungeonLvlTableBuffer(FlatBufferBuilder builder, Offset<GuildDungeonLvlTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040015BC RID: 5564
		private Table __p = new Table();

		// Token: 0x02000470 RID: 1136
		public enum eCrypt
		{
			// Token: 0x040015BE RID: 5566
			code = -2111160045
		}
	}
}
