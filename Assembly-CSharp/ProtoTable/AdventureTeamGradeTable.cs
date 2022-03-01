using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000295 RID: 661
	public class AdventureTeamGradeTable : IFlatbufferObject
	{
		// Token: 0x1700035B RID: 859
		// (get) Token: 0x06001786 RID: 6022 RVA: 0x00071AD0 File Offset: 0x0006FED0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001787 RID: 6023 RVA: 0x00071ADD File Offset: 0x0006FEDD
		public static AdventureTeamGradeTable GetRootAsAdventureTeamGradeTable(ByteBuffer _bb)
		{
			return AdventureTeamGradeTable.GetRootAsAdventureTeamGradeTable(_bb, new AdventureTeamGradeTable());
		}

		// Token: 0x06001788 RID: 6024 RVA: 0x00071AEA File Offset: 0x0006FEEA
		public static AdventureTeamGradeTable GetRootAsAdventureTeamGradeTable(ByteBuffer _bb, AdventureTeamGradeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001789 RID: 6025 RVA: 0x00071B06 File Offset: 0x0006FF06
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600178A RID: 6026 RVA: 0x00071B20 File Offset: 0x0006FF20
		public AdventureTeamGradeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700035C RID: 860
		// (get) Token: 0x0600178B RID: 6027 RVA: 0x00071B2C File Offset: 0x0006FF2C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-204914404 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700035D RID: 861
		// (get) Token: 0x0600178C RID: 6028 RVA: 0x00071B78 File Offset: 0x0006FF78
		public string AdventureTeamGrade
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600178D RID: 6029 RVA: 0x00071BBA File Offset: 0x0006FFBA
		public ArraySegment<byte>? GetAdventureTeamGradeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700035E RID: 862
		// (get) Token: 0x0600178E RID: 6030 RVA: 0x00071BC8 File Offset: 0x0006FFC8
		public string RoleValueTotalScore
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600178F RID: 6031 RVA: 0x00071C0A File Offset: 0x0007000A
		public ArraySegment<byte>? GetRoleValueTotalScoreBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700035F RID: 863
		// (get) Token: 0x06001790 RID: 6032 RVA: 0x00071C18 File Offset: 0x00070018
		public int SingleServerRanking
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-204914404 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000360 RID: 864
		// (get) Token: 0x06001791 RID: 6033 RVA: 0x00071C64 File Offset: 0x00070064
		public int CanJoinSortList
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-204914404 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000361 RID: 865
		// (get) Token: 0x06001792 RID: 6034 RVA: 0x00071CB0 File Offset: 0x000700B0
		public string OptionalTasks
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001793 RID: 6035 RVA: 0x00071CF3 File Offset: 0x000700F3
		public ArraySegment<byte>? GetOptionalTasksBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000362 RID: 866
		// (get) Token: 0x06001794 RID: 6036 RVA: 0x00071D04 File Offset: 0x00070104
		public string NameColor
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001795 RID: 6037 RVA: 0x00071D47 File Offset: 0x00070147
		public ArraySegment<byte>? GetNameColorBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000363 RID: 867
		// (get) Token: 0x06001796 RID: 6038 RVA: 0x00071D58 File Offset: 0x00070158
		public AdventureTeamGradeTable.eGradeEnum GradeEnum
		{
			get
			{
				int num = this.__p.__offset(18);
				return (AdventureTeamGradeTable.eGradeEnum)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001797 RID: 6039 RVA: 0x00071D9C File Offset: 0x0007019C
		public static Offset<AdventureTeamGradeTable> CreateAdventureTeamGradeTable(FlatBufferBuilder builder, int ID = 0, StringOffset AdventureTeamGradeOffset = default(StringOffset), StringOffset RoleValueTotalScoreOffset = default(StringOffset), int SingleServerRanking = 0, int CanJoinSortList = 0, StringOffset OptionalTasksOffset = default(StringOffset), StringOffset NameColorOffset = default(StringOffset), AdventureTeamGradeTable.eGradeEnum GradeEnum = AdventureTeamGradeTable.eGradeEnum.GradeEnum_None)
		{
			builder.StartObject(8);
			AdventureTeamGradeTable.AddGradeEnum(builder, GradeEnum);
			AdventureTeamGradeTable.AddNameColor(builder, NameColorOffset);
			AdventureTeamGradeTable.AddOptionalTasks(builder, OptionalTasksOffset);
			AdventureTeamGradeTable.AddCanJoinSortList(builder, CanJoinSortList);
			AdventureTeamGradeTable.AddSingleServerRanking(builder, SingleServerRanking);
			AdventureTeamGradeTable.AddRoleValueTotalScore(builder, RoleValueTotalScoreOffset);
			AdventureTeamGradeTable.AddAdventureTeamGrade(builder, AdventureTeamGradeOffset);
			AdventureTeamGradeTable.AddID(builder, ID);
			return AdventureTeamGradeTable.EndAdventureTeamGradeTable(builder);
		}

		// Token: 0x06001798 RID: 6040 RVA: 0x00071DF3 File Offset: 0x000701F3
		public static void StartAdventureTeamGradeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06001799 RID: 6041 RVA: 0x00071DFC File Offset: 0x000701FC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600179A RID: 6042 RVA: 0x00071E07 File Offset: 0x00070207
		public static void AddAdventureTeamGrade(FlatBufferBuilder builder, StringOffset AdventureTeamGradeOffset)
		{
			builder.AddOffset(1, AdventureTeamGradeOffset.Value, 0);
		}

		// Token: 0x0600179B RID: 6043 RVA: 0x00071E18 File Offset: 0x00070218
		public static void AddRoleValueTotalScore(FlatBufferBuilder builder, StringOffset RoleValueTotalScoreOffset)
		{
			builder.AddOffset(2, RoleValueTotalScoreOffset.Value, 0);
		}

		// Token: 0x0600179C RID: 6044 RVA: 0x00071E29 File Offset: 0x00070229
		public static void AddSingleServerRanking(FlatBufferBuilder builder, int SingleServerRanking)
		{
			builder.AddInt(3, SingleServerRanking, 0);
		}

		// Token: 0x0600179D RID: 6045 RVA: 0x00071E34 File Offset: 0x00070234
		public static void AddCanJoinSortList(FlatBufferBuilder builder, int CanJoinSortList)
		{
			builder.AddInt(4, CanJoinSortList, 0);
		}

		// Token: 0x0600179E RID: 6046 RVA: 0x00071E3F File Offset: 0x0007023F
		public static void AddOptionalTasks(FlatBufferBuilder builder, StringOffset OptionalTasksOffset)
		{
			builder.AddOffset(5, OptionalTasksOffset.Value, 0);
		}

		// Token: 0x0600179F RID: 6047 RVA: 0x00071E50 File Offset: 0x00070250
		public static void AddNameColor(FlatBufferBuilder builder, StringOffset NameColorOffset)
		{
			builder.AddOffset(6, NameColorOffset.Value, 0);
		}

		// Token: 0x060017A0 RID: 6048 RVA: 0x00071E61 File Offset: 0x00070261
		public static void AddGradeEnum(FlatBufferBuilder builder, AdventureTeamGradeTable.eGradeEnum GradeEnum)
		{
			builder.AddInt(7, (int)GradeEnum, 0);
		}

		// Token: 0x060017A1 RID: 6049 RVA: 0x00071E6C File Offset: 0x0007026C
		public static Offset<AdventureTeamGradeTable> EndAdventureTeamGradeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AdventureTeamGradeTable>(value);
		}

		// Token: 0x060017A2 RID: 6050 RVA: 0x00071E86 File Offset: 0x00070286
		public static void FinishAdventureTeamGradeTableBuffer(FlatBufferBuilder builder, Offset<AdventureTeamGradeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DD1 RID: 3537
		private Table __p = new Table();

		// Token: 0x02000296 RID: 662
		public enum eGradeEnum
		{
			// Token: 0x04000DD3 RID: 3539
			GradeEnum_None,
			// Token: 0x04000DD4 RID: 3540
			C,
			// Token: 0x04000DD5 RID: 3541
			B,
			// Token: 0x04000DD6 RID: 3542
			A,
			// Token: 0x04000DD7 RID: 3543
			S,
			// Token: 0x04000DD8 RID: 3544
			SS,
			// Token: 0x04000DD9 RID: 3545
			SSS
		}

		// Token: 0x02000297 RID: 663
		public enum eCrypt
		{
			// Token: 0x04000DDB RID: 3547
			code = -204914404
		}
	}
}
