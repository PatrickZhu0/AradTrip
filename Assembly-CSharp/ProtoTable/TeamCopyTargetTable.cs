using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005F4 RID: 1524
	public class TeamCopyTargetTable : IFlatbufferObject
	{
		// Token: 0x17001646 RID: 5702
		// (get) Token: 0x060050BC RID: 20668 RVA: 0x000F94C0 File Offset: 0x000F78C0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060050BD RID: 20669 RVA: 0x000F94CD File Offset: 0x000F78CD
		public static TeamCopyTargetTable GetRootAsTeamCopyTargetTable(ByteBuffer _bb)
		{
			return TeamCopyTargetTable.GetRootAsTeamCopyTargetTable(_bb, new TeamCopyTargetTable());
		}

		// Token: 0x060050BE RID: 20670 RVA: 0x000F94DA File Offset: 0x000F78DA
		public static TeamCopyTargetTable GetRootAsTeamCopyTargetTable(ByteBuffer _bb, TeamCopyTargetTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060050BF RID: 20671 RVA: 0x000F94F6 File Offset: 0x000F78F6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060050C0 RID: 20672 RVA: 0x000F9510 File Offset: 0x000F7910
		public TeamCopyTargetTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001647 RID: 5703
		// (get) Token: 0x060050C1 RID: 20673 RVA: 0x000F951C File Offset: 0x000F791C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001648 RID: 5704
		// (get) Token: 0x060050C2 RID: 20674 RVA: 0x000F9568 File Offset: 0x000F7968
		public int TeamCopyId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001649 RID: 5705
		// (get) Token: 0x060050C3 RID: 20675 RVA: 0x000F95B4 File Offset: 0x000F79B4
		public int TeamGrade
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700164A RID: 5706
		// (get) Token: 0x060050C4 RID: 20676 RVA: 0x000F9600 File Offset: 0x000F7A00
		public int Stage
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700164B RID: 5707
		// (get) Token: 0x060050C5 RID: 20677 RVA: 0x000F964C File Offset: 0x000F7A4C
		public int TargetDifficulty
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700164C RID: 5708
		// (get) Token: 0x060050C6 RID: 20678 RVA: 0x000F9698 File Offset: 0x000F7A98
		public int TargetType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060050C7 RID: 20679 RVA: 0x000F96E4 File Offset: 0x000F7AE4
		public string FeildIdArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700164D RID: 5709
		// (get) Token: 0x060050C8 RID: 20680 RVA: 0x000F972C File Offset: 0x000F7B2C
		public int FeildIdLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700164E RID: 5710
		// (get) Token: 0x060050C9 RID: 20681 RVA: 0x000F975F File Offset: 0x000F7B5F
		public FlatBufferArray<string> FeildId
		{
			get
			{
				if (this.FeildIdValue == null)
				{
					this.FeildIdValue = new FlatBufferArray<string>(new Func<int, string>(this.FeildIdArray), this.FeildIdLength);
				}
				return this.FeildIdValue;
			}
		}

		// Token: 0x1700164F RID: 5711
		// (get) Token: 0x060050CA RID: 20682 RVA: 0x000F9790 File Offset: 0x000F7B90
		public int NextTarget
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-941830157 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001650 RID: 5712
		// (get) Token: 0x060050CB RID: 20683 RVA: 0x000F97DC File Offset: 0x000F7BDC
		public string Description
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050CC RID: 20684 RVA: 0x000F981F File Offset: 0x000F7C1F
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17001651 RID: 5713
		// (get) Token: 0x060050CD RID: 20685 RVA: 0x000F9830 File Offset: 0x000F7C30
		public string SubDescription
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050CE RID: 20686 RVA: 0x000F9873 File Offset: 0x000F7C73
		public ArraySegment<byte>? GetSubDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x060050CF RID: 20687 RVA: 0x000F9884 File Offset: 0x000F7C84
		public static Offset<TeamCopyTargetTable> CreateTeamCopyTargetTable(FlatBufferBuilder builder, int ID = 0, int TeamCopyId = 0, int TeamGrade = 0, int Stage = 0, int TargetDifficulty = 0, int TargetType = 0, VectorOffset FeildIdOffset = default(VectorOffset), int NextTarget = 0, StringOffset DescriptionOffset = default(StringOffset), StringOffset SubDescriptionOffset = default(StringOffset))
		{
			builder.StartObject(10);
			TeamCopyTargetTable.AddSubDescription(builder, SubDescriptionOffset);
			TeamCopyTargetTable.AddDescription(builder, DescriptionOffset);
			TeamCopyTargetTable.AddNextTarget(builder, NextTarget);
			TeamCopyTargetTable.AddFeildId(builder, FeildIdOffset);
			TeamCopyTargetTable.AddTargetType(builder, TargetType);
			TeamCopyTargetTable.AddTargetDifficulty(builder, TargetDifficulty);
			TeamCopyTargetTable.AddStage(builder, Stage);
			TeamCopyTargetTable.AddTeamGrade(builder, TeamGrade);
			TeamCopyTargetTable.AddTeamCopyId(builder, TeamCopyId);
			TeamCopyTargetTable.AddID(builder, ID);
			return TeamCopyTargetTable.EndTeamCopyTargetTable(builder);
		}

		// Token: 0x060050D0 RID: 20688 RVA: 0x000F98EC File Offset: 0x000F7CEC
		public static void StartTeamCopyTargetTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x060050D1 RID: 20689 RVA: 0x000F98F6 File Offset: 0x000F7CF6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060050D2 RID: 20690 RVA: 0x000F9901 File Offset: 0x000F7D01
		public static void AddTeamCopyId(FlatBufferBuilder builder, int TeamCopyId)
		{
			builder.AddInt(1, TeamCopyId, 0);
		}

		// Token: 0x060050D3 RID: 20691 RVA: 0x000F990C File Offset: 0x000F7D0C
		public static void AddTeamGrade(FlatBufferBuilder builder, int TeamGrade)
		{
			builder.AddInt(2, TeamGrade, 0);
		}

		// Token: 0x060050D4 RID: 20692 RVA: 0x000F9917 File Offset: 0x000F7D17
		public static void AddStage(FlatBufferBuilder builder, int Stage)
		{
			builder.AddInt(3, Stage, 0);
		}

		// Token: 0x060050D5 RID: 20693 RVA: 0x000F9922 File Offset: 0x000F7D22
		public static void AddTargetDifficulty(FlatBufferBuilder builder, int TargetDifficulty)
		{
			builder.AddInt(4, TargetDifficulty, 0);
		}

		// Token: 0x060050D6 RID: 20694 RVA: 0x000F992D File Offset: 0x000F7D2D
		public static void AddTargetType(FlatBufferBuilder builder, int TargetType)
		{
			builder.AddInt(5, TargetType, 0);
		}

		// Token: 0x060050D7 RID: 20695 RVA: 0x000F9938 File Offset: 0x000F7D38
		public static void AddFeildId(FlatBufferBuilder builder, VectorOffset FeildIdOffset)
		{
			builder.AddOffset(6, FeildIdOffset.Value, 0);
		}

		// Token: 0x060050D8 RID: 20696 RVA: 0x000F994C File Offset: 0x000F7D4C
		public static VectorOffset CreateFeildIdVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x060050D9 RID: 20697 RVA: 0x000F9992 File Offset: 0x000F7D92
		public static void StartFeildIdVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060050DA RID: 20698 RVA: 0x000F999D File Offset: 0x000F7D9D
		public static void AddNextTarget(FlatBufferBuilder builder, int NextTarget)
		{
			builder.AddInt(7, NextTarget, 0);
		}

		// Token: 0x060050DB RID: 20699 RVA: 0x000F99A8 File Offset: 0x000F7DA8
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(8, DescriptionOffset.Value, 0);
		}

		// Token: 0x060050DC RID: 20700 RVA: 0x000F99B9 File Offset: 0x000F7DB9
		public static void AddSubDescription(FlatBufferBuilder builder, StringOffset SubDescriptionOffset)
		{
			builder.AddOffset(9, SubDescriptionOffset.Value, 0);
		}

		// Token: 0x060050DD RID: 20701 RVA: 0x000F99CC File Offset: 0x000F7DCC
		public static Offset<TeamCopyTargetTable> EndTeamCopyTargetTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyTargetTable>(value);
		}

		// Token: 0x060050DE RID: 20702 RVA: 0x000F99E6 File Offset: 0x000F7DE6
		public static void FinishTeamCopyTargetTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyTargetTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DF2 RID: 7666
		private Table __p = new Table();

		// Token: 0x04001DF3 RID: 7667
		private FlatBufferArray<string> FeildIdValue;

		// Token: 0x020005F5 RID: 1525
		public enum eCrypt
		{
			// Token: 0x04001DF5 RID: 7669
			code = -941830157
		}
	}
}
