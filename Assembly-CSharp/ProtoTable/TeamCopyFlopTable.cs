using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005EC RID: 1516
	public class TeamCopyFlopTable : IFlatbufferObject
	{
		// Token: 0x1700162B RID: 5675
		// (get) Token: 0x0600505D RID: 20573 RVA: 0x000F8904 File Offset: 0x000F6D04
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600505E RID: 20574 RVA: 0x000F8911 File Offset: 0x000F6D11
		public static TeamCopyFlopTable GetRootAsTeamCopyFlopTable(ByteBuffer _bb)
		{
			return TeamCopyFlopTable.GetRootAsTeamCopyFlopTable(_bb, new TeamCopyFlopTable());
		}

		// Token: 0x0600505F RID: 20575 RVA: 0x000F891E File Offset: 0x000F6D1E
		public static TeamCopyFlopTable GetRootAsTeamCopyFlopTable(ByteBuffer _bb, TeamCopyFlopTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005060 RID: 20576 RVA: 0x000F893A File Offset: 0x000F6D3A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005061 RID: 20577 RVA: 0x000F8954 File Offset: 0x000F6D54
		public TeamCopyFlopTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700162C RID: 5676
		// (get) Token: 0x06005062 RID: 20578 RVA: 0x000F8960 File Offset: 0x000F6D60
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700162D RID: 5677
		// (get) Token: 0x06005063 RID: 20579 RVA: 0x000F89AC File Offset: 0x000F6DAC
		public int TeamCopyID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700162E RID: 5678
		// (get) Token: 0x06005064 RID: 20580 RVA: 0x000F89F8 File Offset: 0x000F6DF8
		public int TeamGrade
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700162F RID: 5679
		// (get) Token: 0x06005065 RID: 20581 RVA: 0x000F8A44 File Offset: 0x000F6E44
		public int Stage
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001630 RID: 5680
		// (get) Token: 0x06005066 RID: 20582 RVA: 0x000F8A90 File Offset: 0x000F6E90
		public int Param
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001631 RID: 5681
		// (get) Token: 0x06005067 RID: 20583 RVA: 0x000F8ADC File Offset: 0x000F6EDC
		public int TypeStage
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001632 RID: 5682
		// (get) Token: 0x06005068 RID: 20584 RVA: 0x000F8B28 File Offset: 0x000F6F28
		public int DropId
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1981605017 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005069 RID: 20585 RVA: 0x000F8B74 File Offset: 0x000F6F74
		public static Offset<TeamCopyFlopTable> CreateTeamCopyFlopTable(FlatBufferBuilder builder, int ID = 0, int TeamCopyID = 0, int TeamGrade = 0, int Stage = 0, int Param = 0, int TypeStage = 0, int DropId = 0)
		{
			builder.StartObject(7);
			TeamCopyFlopTable.AddDropId(builder, DropId);
			TeamCopyFlopTable.AddTypeStage(builder, TypeStage);
			TeamCopyFlopTable.AddParam(builder, Param);
			TeamCopyFlopTable.AddStage(builder, Stage);
			TeamCopyFlopTable.AddTeamGrade(builder, TeamGrade);
			TeamCopyFlopTable.AddTeamCopyID(builder, TeamCopyID);
			TeamCopyFlopTable.AddID(builder, ID);
			return TeamCopyFlopTable.EndTeamCopyFlopTable(builder);
		}

		// Token: 0x0600506A RID: 20586 RVA: 0x000F8BC3 File Offset: 0x000F6FC3
		public static void StartTeamCopyFlopTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0600506B RID: 20587 RVA: 0x000F8BCC File Offset: 0x000F6FCC
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600506C RID: 20588 RVA: 0x000F8BD7 File Offset: 0x000F6FD7
		public static void AddTeamCopyID(FlatBufferBuilder builder, int TeamCopyID)
		{
			builder.AddInt(1, TeamCopyID, 0);
		}

		// Token: 0x0600506D RID: 20589 RVA: 0x000F8BE2 File Offset: 0x000F6FE2
		public static void AddTeamGrade(FlatBufferBuilder builder, int TeamGrade)
		{
			builder.AddInt(2, TeamGrade, 0);
		}

		// Token: 0x0600506E RID: 20590 RVA: 0x000F8BED File Offset: 0x000F6FED
		public static void AddStage(FlatBufferBuilder builder, int Stage)
		{
			builder.AddInt(3, Stage, 0);
		}

		// Token: 0x0600506F RID: 20591 RVA: 0x000F8BF8 File Offset: 0x000F6FF8
		public static void AddParam(FlatBufferBuilder builder, int Param)
		{
			builder.AddInt(4, Param, 0);
		}

		// Token: 0x06005070 RID: 20592 RVA: 0x000F8C03 File Offset: 0x000F7003
		public static void AddTypeStage(FlatBufferBuilder builder, int TypeStage)
		{
			builder.AddInt(5, TypeStage, 0);
		}

		// Token: 0x06005071 RID: 20593 RVA: 0x000F8C0E File Offset: 0x000F700E
		public static void AddDropId(FlatBufferBuilder builder, int DropId)
		{
			builder.AddInt(6, DropId, 0);
		}

		// Token: 0x06005072 RID: 20594 RVA: 0x000F8C1C File Offset: 0x000F701C
		public static Offset<TeamCopyFlopTable> EndTeamCopyFlopTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyFlopTable>(value);
		}

		// Token: 0x06005073 RID: 20595 RVA: 0x000F8C36 File Offset: 0x000F7036
		public static void FinishTeamCopyFlopTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyFlopTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DE6 RID: 7654
		private Table __p = new Table();

		// Token: 0x020005ED RID: 1517
		public enum eCrypt
		{
			// Token: 0x04001DE8 RID: 7656
			code = -1981605017
		}
	}
}
