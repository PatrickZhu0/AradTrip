using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200036C RID: 876
	public class DailyTodoTable : IFlatbufferObject
	{
		// Token: 0x1700080D RID: 2061
		// (get) Token: 0x06002557 RID: 9559 RVA: 0x00092E40 File Offset: 0x00091240
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002558 RID: 9560 RVA: 0x00092E4D File Offset: 0x0009124D
		public static DailyTodoTable GetRootAsDailyTodoTable(ByteBuffer _bb)
		{
			return DailyTodoTable.GetRootAsDailyTodoTable(_bb, new DailyTodoTable());
		}

		// Token: 0x06002559 RID: 9561 RVA: 0x00092E5A File Offset: 0x0009125A
		public static DailyTodoTable GetRootAsDailyTodoTable(ByteBuffer _bb, DailyTodoTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600255A RID: 9562 RVA: 0x00092E76 File Offset: 0x00091276
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600255B RID: 9563 RVA: 0x00092E90 File Offset: 0x00091290
		public DailyTodoTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700080E RID: 2062
		// (get) Token: 0x0600255C RID: 9564 RVA: 0x00092E9C File Offset: 0x0009129C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1201138377 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700080F RID: 2063
		// (get) Token: 0x0600255D RID: 9565 RVA: 0x00092EE8 File Offset: 0x000912E8
		public DailyTodoTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (DailyTodoTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000810 RID: 2064
		// (get) Token: 0x0600255E RID: 9566 RVA: 0x00092F2C File Offset: 0x0009132C
		public DailyTodoTable.eSubType SubType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (DailyTodoTable.eSubType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000811 RID: 2065
		// (get) Token: 0x0600255F RID: 9567 RVA: 0x00092F70 File Offset: 0x00091370
		public string DungeonSubType
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002560 RID: 9568 RVA: 0x00092FB3 File Offset: 0x000913B3
		public ArraySegment<byte>? GetDungeonSubTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000812 RID: 2066
		// (get) Token: 0x06002561 RID: 9569 RVA: 0x00092FC4 File Offset: 0x000913C4
		public int ActivityDungeonID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1201138377 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000813 RID: 2067
		// (get) Token: 0x06002562 RID: 9570 RVA: 0x00093010 File Offset: 0x00091410
		public string Name
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002563 RID: 9571 RVA: 0x00093053 File Offset: 0x00091453
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000814 RID: 2068
		// (get) Token: 0x06002564 RID: 9572 RVA: 0x00093064 File Offset: 0x00091464
		public string OpenWeekDay
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002565 RID: 9573 RVA: 0x000930A7 File Offset: 0x000914A7
		public ArraySegment<byte>? GetOpenWeekDayBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000815 RID: 2069
		// (get) Token: 0x06002566 RID: 9574 RVA: 0x000930B8 File Offset: 0x000914B8
		public string OpenDayTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002567 RID: 9575 RVA: 0x000930FB File Offset: 0x000914FB
		public ArraySegment<byte>? GetOpenDayTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000816 RID: 2070
		// (get) Token: 0x06002568 RID: 9576 RVA: 0x0009310C File Offset: 0x0009150C
		public int DayRecommendNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1201138377 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000817 RID: 2071
		// (get) Token: 0x06002569 RID: 9577 RVA: 0x00093158 File Offset: 0x00091558
		public int WeekRecommendDayNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1201138377 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000818 RID: 2072
		// (get) Token: 0x0600256A RID: 9578 RVA: 0x000931A4 File Offset: 0x000915A4
		public int RefreshWeek
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1201138377 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000819 RID: 2073
		// (get) Token: 0x0600256B RID: 9579 RVA: 0x000931F0 File Offset: 0x000915F0
		public DailyTodoTable.eRecommendNumType RecommendNumType
		{
			get
			{
				int num = this.__p.__offset(26);
				return (DailyTodoTable.eRecommendNumType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700081A RID: 2074
		// (get) Token: 0x0600256C RID: 9580 RVA: 0x00093234 File Offset: 0x00091634
		public string FuncCharacter
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600256D RID: 9581 RVA: 0x00093277 File Offset: 0x00091677
		public ArraySegment<byte>? GetFuncCharacterBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x1700081B RID: 2075
		// (get) Token: 0x0600256E RID: 9582 RVA: 0x00093288 File Offset: 0x00091688
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600256F RID: 9583 RVA: 0x000932CB File Offset: 0x000916CB
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x1700081C RID: 2076
		// (get) Token: 0x06002570 RID: 9584 RVA: 0x000932DC File Offset: 0x000916DC
		public string BackgroundPath
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002571 RID: 9585 RVA: 0x0009331F File Offset: 0x0009171F
		public ArraySegment<byte>? GetBackgroundPathBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x06002572 RID: 9586 RVA: 0x00093330 File Offset: 0x00091730
		public static Offset<DailyTodoTable> CreateDailyTodoTable(FlatBufferBuilder builder, int ID = 0, DailyTodoTable.eType Type = DailyTodoTable.eType.TP_NONE, DailyTodoTable.eSubType SubType = DailyTodoTable.eSubType.DTSTP_NONE, StringOffset DungeonSubTypeOffset = default(StringOffset), int ActivityDungeonID = 0, StringOffset NameOffset = default(StringOffset), StringOffset OpenWeekDayOffset = default(StringOffset), StringOffset OpenDayTimeOffset = default(StringOffset), int DayRecommendNum = 0, int WeekRecommendDayNum = 0, int RefreshWeek = 0, DailyTodoTable.eRecommendNumType RecommendNumType = DailyTodoTable.eRecommendNumType.RT_NONE, StringOffset FuncCharacterOffset = default(StringOffset), StringOffset LinkInfoOffset = default(StringOffset), StringOffset BackgroundPathOffset = default(StringOffset))
		{
			builder.StartObject(15);
			DailyTodoTable.AddBackgroundPath(builder, BackgroundPathOffset);
			DailyTodoTable.AddLinkInfo(builder, LinkInfoOffset);
			DailyTodoTable.AddFuncCharacter(builder, FuncCharacterOffset);
			DailyTodoTable.AddRecommendNumType(builder, RecommendNumType);
			DailyTodoTable.AddRefreshWeek(builder, RefreshWeek);
			DailyTodoTable.AddWeekRecommendDayNum(builder, WeekRecommendDayNum);
			DailyTodoTable.AddDayRecommendNum(builder, DayRecommendNum);
			DailyTodoTable.AddOpenDayTime(builder, OpenDayTimeOffset);
			DailyTodoTable.AddOpenWeekDay(builder, OpenWeekDayOffset);
			DailyTodoTable.AddName(builder, NameOffset);
			DailyTodoTable.AddActivityDungeonID(builder, ActivityDungeonID);
			DailyTodoTable.AddDungeonSubType(builder, DungeonSubTypeOffset);
			DailyTodoTable.AddSubType(builder, SubType);
			DailyTodoTable.AddType(builder, Type);
			DailyTodoTable.AddID(builder, ID);
			return DailyTodoTable.EndDailyTodoTable(builder);
		}

		// Token: 0x06002573 RID: 9587 RVA: 0x000933C0 File Offset: 0x000917C0
		public static void StartDailyTodoTable(FlatBufferBuilder builder)
		{
			builder.StartObject(15);
		}

		// Token: 0x06002574 RID: 9588 RVA: 0x000933CA File Offset: 0x000917CA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002575 RID: 9589 RVA: 0x000933D5 File Offset: 0x000917D5
		public static void AddType(FlatBufferBuilder builder, DailyTodoTable.eType Type)
		{
			builder.AddInt(1, (int)Type, 0);
		}

		// Token: 0x06002576 RID: 9590 RVA: 0x000933E0 File Offset: 0x000917E0
		public static void AddSubType(FlatBufferBuilder builder, DailyTodoTable.eSubType SubType)
		{
			builder.AddInt(2, (int)SubType, 0);
		}

		// Token: 0x06002577 RID: 9591 RVA: 0x000933EB File Offset: 0x000917EB
		public static void AddDungeonSubType(FlatBufferBuilder builder, StringOffset DungeonSubTypeOffset)
		{
			builder.AddOffset(3, DungeonSubTypeOffset.Value, 0);
		}

		// Token: 0x06002578 RID: 9592 RVA: 0x000933FC File Offset: 0x000917FC
		public static void AddActivityDungeonID(FlatBufferBuilder builder, int ActivityDungeonID)
		{
			builder.AddInt(4, ActivityDungeonID, 0);
		}

		// Token: 0x06002579 RID: 9593 RVA: 0x00093407 File Offset: 0x00091807
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(5, NameOffset.Value, 0);
		}

		// Token: 0x0600257A RID: 9594 RVA: 0x00093418 File Offset: 0x00091818
		public static void AddOpenWeekDay(FlatBufferBuilder builder, StringOffset OpenWeekDayOffset)
		{
			builder.AddOffset(6, OpenWeekDayOffset.Value, 0);
		}

		// Token: 0x0600257B RID: 9595 RVA: 0x00093429 File Offset: 0x00091829
		public static void AddOpenDayTime(FlatBufferBuilder builder, StringOffset OpenDayTimeOffset)
		{
			builder.AddOffset(7, OpenDayTimeOffset.Value, 0);
		}

		// Token: 0x0600257C RID: 9596 RVA: 0x0009343A File Offset: 0x0009183A
		public static void AddDayRecommendNum(FlatBufferBuilder builder, int DayRecommendNum)
		{
			builder.AddInt(8, DayRecommendNum, 0);
		}

		// Token: 0x0600257D RID: 9597 RVA: 0x00093445 File Offset: 0x00091845
		public static void AddWeekRecommendDayNum(FlatBufferBuilder builder, int WeekRecommendDayNum)
		{
			builder.AddInt(9, WeekRecommendDayNum, 0);
		}

		// Token: 0x0600257E RID: 9598 RVA: 0x00093451 File Offset: 0x00091851
		public static void AddRefreshWeek(FlatBufferBuilder builder, int RefreshWeek)
		{
			builder.AddInt(10, RefreshWeek, 0);
		}

		// Token: 0x0600257F RID: 9599 RVA: 0x0009345D File Offset: 0x0009185D
		public static void AddRecommendNumType(FlatBufferBuilder builder, DailyTodoTable.eRecommendNumType RecommendNumType)
		{
			builder.AddInt(11, (int)RecommendNumType, 0);
		}

		// Token: 0x06002580 RID: 9600 RVA: 0x00093469 File Offset: 0x00091869
		public static void AddFuncCharacter(FlatBufferBuilder builder, StringOffset FuncCharacterOffset)
		{
			builder.AddOffset(12, FuncCharacterOffset.Value, 0);
		}

		// Token: 0x06002581 RID: 9601 RVA: 0x0009347B File Offset: 0x0009187B
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(13, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06002582 RID: 9602 RVA: 0x0009348D File Offset: 0x0009188D
		public static void AddBackgroundPath(FlatBufferBuilder builder, StringOffset BackgroundPathOffset)
		{
			builder.AddOffset(14, BackgroundPathOffset.Value, 0);
		}

		// Token: 0x06002583 RID: 9603 RVA: 0x000934A0 File Offset: 0x000918A0
		public static Offset<DailyTodoTable> EndDailyTodoTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DailyTodoTable>(value);
		}

		// Token: 0x06002584 RID: 9604 RVA: 0x000934BA File Offset: 0x000918BA
		public static void FinishDailyTodoTableBuffer(FlatBufferBuilder builder, Offset<DailyTodoTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001156 RID: 4438
		private Table __p = new Table();

		// Token: 0x0200036D RID: 877
		public enum eType
		{
			// Token: 0x04001158 RID: 4440
			TP_NONE,
			// Token: 0x04001159 RID: 4441
			TP_ACTIVITY,
			// Token: 0x0400115A RID: 4442
			TP_FUNCTION
		}

		// Token: 0x0200036E RID: 878
		public enum eSubType
		{
			// Token: 0x0400115C RID: 4444
			DTSTP_NONE,
			// Token: 0x0400115D RID: 4445
			DTSTP_DIALY_TASK,
			// Token: 0x0400115E RID: 4446
			DTSTP_MAIN_DUNGEON,
			// Token: 0x0400115F RID: 4447
			DTSTP_SHENYUAN_DUNGEON,
			// Token: 0x04001160 RID: 4448
			DTSTP_YUANGU_DUNGEON,
			// Token: 0x04001161 RID: 4449
			DTSTP_CITY_MONSTER_DUNGEON,
			// Token: 0x04001162 RID: 4450
			DTSTP_XUKONG_DUNGEON,
			// Token: 0x04001163 RID: 4451
			DTSTP_HUNDUN_DUNGEON,
			// Token: 0x04001164 RID: 4452
			DTSTP_GROUP_DUNGEON,
			// Token: 0x04001165 RID: 4453
			DTSTP_ALD_BUDO,
			// Token: 0x04001166 RID: 4454
			DTSTP_REWARD_BUDO,
			// Token: 0x04001167 RID: 4455
			DTSTP_3V3_PK,
			// Token: 0x04001168 RID: 4456
			DTSTP_GUILD_BATTLE,
			// Token: 0x04001169 RID: 4457
			DTSTP_CROSS_SERVER_GUILD_BATTLE,
			// Token: 0x0400116A RID: 4458
			DTSTP_GUILD_DUNGEON,
			// Token: 0x0400116B RID: 4459
			DTSTP_2v2_SCORE_WAR,
			// Token: 0x0400116C RID: 4460
			DTSTP_CHIJI_WAR,
			// Token: 0x0400116D RID: 4461
			DTSTP_GROPU_HARD_DUNGEON = 18,
			// Token: 0x0400116E RID: 4462
			DTSTP_GROUP_DUNGEON_TWO
		}

		// Token: 0x0200036F RID: 879
		public enum eRecommendNumType
		{
			// Token: 0x04001170 RID: 4464
			RT_NONE,
			// Token: 0x04001171 RID: 4465
			RT_ACTIVE,
			// Token: 0x04001172 RID: 4466
			RT_NUMBER
		}

		// Token: 0x02000370 RID: 880
		public enum eCrypt
		{
			// Token: 0x04001174 RID: 4468
			code = -1201138377
		}
	}
}
