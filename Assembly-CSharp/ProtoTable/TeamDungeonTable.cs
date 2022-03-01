using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005F8 RID: 1528
	public class TeamDungeonTable : IFlatbufferObject
	{
		// Token: 0x17001656 RID: 5718
		// (get) Token: 0x060050F1 RID: 20721 RVA: 0x000F9BDC File Offset: 0x000F7FDC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060050F2 RID: 20722 RVA: 0x000F9BE9 File Offset: 0x000F7FE9
		public static TeamDungeonTable GetRootAsTeamDungeonTable(ByteBuffer _bb)
		{
			return TeamDungeonTable.GetRootAsTeamDungeonTable(_bb, new TeamDungeonTable());
		}

		// Token: 0x060050F3 RID: 20723 RVA: 0x000F9BF6 File Offset: 0x000F7FF6
		public static TeamDungeonTable GetRootAsTeamDungeonTable(ByteBuffer _bb, TeamDungeonTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060050F4 RID: 20724 RVA: 0x000F9C12 File Offset: 0x000F8012
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060050F5 RID: 20725 RVA: 0x000F9C2C File Offset: 0x000F802C
		public TeamDungeonTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001657 RID: 5719
		// (get) Token: 0x060050F6 RID: 20726 RVA: 0x000F9C38 File Offset: 0x000F8038
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001658 RID: 5720
		// (get) Token: 0x060050F7 RID: 20727 RVA: 0x000F9C84 File Offset: 0x000F8084
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050F8 RID: 20728 RVA: 0x000F9CC6 File Offset: 0x000F80C6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001659 RID: 5721
		// (get) Token: 0x060050F9 RID: 20729 RVA: 0x000F9CD4 File Offset: 0x000F80D4
		public TeamDungeonTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (TeamDungeonTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700165A RID: 5722
		// (get) Token: 0x060050FA RID: 20730 RVA: 0x000F9D18 File Offset: 0x000F8118
		public int MenuID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700165B RID: 5723
		// (get) Token: 0x060050FB RID: 20731 RVA: 0x000F9D64 File Offset: 0x000F8164
		public int DungeonID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700165C RID: 5724
		// (get) Token: 0x060050FC RID: 20732 RVA: 0x000F9DB0 File Offset: 0x000F81B0
		public TeamDungeonTable.eMatchType MatchType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (TeamDungeonTable.eMatchType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700165D RID: 5725
		// (get) Token: 0x060050FD RID: 20733 RVA: 0x000F9DF4 File Offset: 0x000F81F4
		public int MinLevel
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700165E RID: 5726
		// (get) Token: 0x060050FE RID: 20734 RVA: 0x000F9E40 File Offset: 0x000F8240
		public int RecoLevel
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700165F RID: 5727
		// (get) Token: 0x060050FF RID: 20735 RVA: 0x000F9E8C File Offset: 0x000F828C
		public int MinPlayerNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001660 RID: 5728
		// (get) Token: 0x06005100 RID: 20736 RVA: 0x000F9ED8 File Offset: 0x000F82D8
		public int MaxPlayerNum
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001661 RID: 5729
		// (get) Token: 0x06005101 RID: 20737 RVA: 0x000F9F24 File Offset: 0x000F8324
		public int ShowIndependent
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001662 RID: 5730
		// (get) Token: 0x06005102 RID: 20738 RVA: 0x000F9F70 File Offset: 0x000F8370
		public int AutoKick
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1083265799 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005103 RID: 20739 RVA: 0x000F9FBC File Offset: 0x000F83BC
		public static Offset<TeamDungeonTable> CreateTeamDungeonTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), TeamDungeonTable.eType Type = TeamDungeonTable.eType.DUNGEON, int MenuID = 0, int DungeonID = 0, TeamDungeonTable.eMatchType MatchType = TeamDungeonTable.eMatchType.QUICK_MATCH, int MinLevel = 0, int RecoLevel = 0, int MinPlayerNum = 0, int MaxPlayerNum = 0, int ShowIndependent = 0, int AutoKick = 0)
		{
			builder.StartObject(12);
			TeamDungeonTable.AddAutoKick(builder, AutoKick);
			TeamDungeonTable.AddShowIndependent(builder, ShowIndependent);
			TeamDungeonTable.AddMaxPlayerNum(builder, MaxPlayerNum);
			TeamDungeonTable.AddMinPlayerNum(builder, MinPlayerNum);
			TeamDungeonTable.AddRecoLevel(builder, RecoLevel);
			TeamDungeonTable.AddMinLevel(builder, MinLevel);
			TeamDungeonTable.AddMatchType(builder, MatchType);
			TeamDungeonTable.AddDungeonID(builder, DungeonID);
			TeamDungeonTable.AddMenuID(builder, MenuID);
			TeamDungeonTable.AddType(builder, Type);
			TeamDungeonTable.AddName(builder, NameOffset);
			TeamDungeonTable.AddID(builder, ID);
			return TeamDungeonTable.EndTeamDungeonTable(builder);
		}

		// Token: 0x06005104 RID: 20740 RVA: 0x000FA034 File Offset: 0x000F8434
		public static void StartTeamDungeonTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06005105 RID: 20741 RVA: 0x000FA03E File Offset: 0x000F843E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005106 RID: 20742 RVA: 0x000FA049 File Offset: 0x000F8449
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06005107 RID: 20743 RVA: 0x000FA05A File Offset: 0x000F845A
		public static void AddType(FlatBufferBuilder builder, TeamDungeonTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06005108 RID: 20744 RVA: 0x000FA065 File Offset: 0x000F8465
		public static void AddMenuID(FlatBufferBuilder builder, int MenuID)
		{
			builder.AddInt(3, MenuID, 0);
		}

		// Token: 0x06005109 RID: 20745 RVA: 0x000FA070 File Offset: 0x000F8470
		public static void AddDungeonID(FlatBufferBuilder builder, int DungeonID)
		{
			builder.AddInt(4, DungeonID, 0);
		}

		// Token: 0x0600510A RID: 20746 RVA: 0x000FA07B File Offset: 0x000F847B
		public static void AddMatchType(FlatBufferBuilder builder, TeamDungeonTable.eMatchType MatchType)
		{
			builder.AddInt(5, (int)MatchType, 0);
		}

		// Token: 0x0600510B RID: 20747 RVA: 0x000FA086 File Offset: 0x000F8486
		public static void AddMinLevel(FlatBufferBuilder builder, int MinLevel)
		{
			builder.AddInt(6, MinLevel, 0);
		}

		// Token: 0x0600510C RID: 20748 RVA: 0x000FA091 File Offset: 0x000F8491
		public static void AddRecoLevel(FlatBufferBuilder builder, int RecoLevel)
		{
			builder.AddInt(7, RecoLevel, 0);
		}

		// Token: 0x0600510D RID: 20749 RVA: 0x000FA09C File Offset: 0x000F849C
		public static void AddMinPlayerNum(FlatBufferBuilder builder, int MinPlayerNum)
		{
			builder.AddInt(8, MinPlayerNum, 0);
		}

		// Token: 0x0600510E RID: 20750 RVA: 0x000FA0A7 File Offset: 0x000F84A7
		public static void AddMaxPlayerNum(FlatBufferBuilder builder, int MaxPlayerNum)
		{
			builder.AddInt(9, MaxPlayerNum, 0);
		}

		// Token: 0x0600510F RID: 20751 RVA: 0x000FA0B3 File Offset: 0x000F84B3
		public static void AddShowIndependent(FlatBufferBuilder builder, int ShowIndependent)
		{
			builder.AddInt(10, ShowIndependent, 0);
		}

		// Token: 0x06005110 RID: 20752 RVA: 0x000FA0BF File Offset: 0x000F84BF
		public static void AddAutoKick(FlatBufferBuilder builder, int AutoKick)
		{
			builder.AddInt(11, AutoKick, 0);
		}

		// Token: 0x06005111 RID: 20753 RVA: 0x000FA0CC File Offset: 0x000F84CC
		public static Offset<TeamDungeonTable> EndTeamDungeonTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamDungeonTable>(value);
		}

		// Token: 0x06005112 RID: 20754 RVA: 0x000FA0E6 File Offset: 0x000F84E6
		public static void FinishTeamDungeonTableBuffer(FlatBufferBuilder builder, Offset<TeamDungeonTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DF9 RID: 7673
		private Table __p = new Table();

		// Token: 0x020005F9 RID: 1529
		public enum eType
		{
			// Token: 0x04001DFB RID: 7675
			DUNGEON,
			// Token: 0x04001DFC RID: 7676
			MENU,
			// Token: 0x04001DFD RID: 7677
			CityMonster
		}

		// Token: 0x020005FA RID: 1530
		public enum eMatchType
		{
			// Token: 0x04001DFF RID: 7679
			QUICK_MATCH,
			// Token: 0x04001E00 RID: 7680
			QUICK_JOIN
		}

		// Token: 0x020005FB RID: 1531
		public enum eCrypt
		{
			// Token: 0x04001E02 RID: 7682
			code = 1083265799
		}
	}
}
