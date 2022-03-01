using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005E7 RID: 1511
	public class TeamCopyBossTable : IFlatbufferObject
	{
		// Token: 0x1700160D RID: 5645
		// (get) Token: 0x06005004 RID: 20484 RVA: 0x000F7C04 File Offset: 0x000F6004
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005005 RID: 20485 RVA: 0x000F7C11 File Offset: 0x000F6011
		public static TeamCopyBossTable GetRootAsTeamCopyBossTable(ByteBuffer _bb)
		{
			return TeamCopyBossTable.GetRootAsTeamCopyBossTable(_bb, new TeamCopyBossTable());
		}

		// Token: 0x06005006 RID: 20486 RVA: 0x000F7C1E File Offset: 0x000F601E
		public static TeamCopyBossTable GetRootAsTeamCopyBossTable(ByteBuffer _bb, TeamCopyBossTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005007 RID: 20487 RVA: 0x000F7C3A File Offset: 0x000F603A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005008 RID: 20488 RVA: 0x000F7C54 File Offset: 0x000F6054
		public TeamCopyBossTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700160E RID: 5646
		// (get) Token: 0x06005009 RID: 20489 RVA: 0x000F7C60 File Offset: 0x000F6060
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1989788737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700160F RID: 5647
		// (get) Token: 0x0600500A RID: 20490 RVA: 0x000F7CAC File Offset: 0x000F60AC
		public int teamCopyID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1989788737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001610 RID: 5648
		// (get) Token: 0x0600500B RID: 20491 RVA: 0x000F7CF8 File Offset: 0x000F60F8
		public int teamGrade
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1989788737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001611 RID: 5649
		// (get) Token: 0x0600500C RID: 20492 RVA: 0x000F7D44 File Offset: 0x000F6144
		public int stage
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1989788737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001612 RID: 5650
		// (get) Token: 0x0600500D RID: 20493 RVA: 0x000F7D90 File Offset: 0x000F6190
		public int appearField
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1989788737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001613 RID: 5651
		// (get) Token: 0x0600500E RID: 20494 RVA: 0x000F7DDC File Offset: 0x000F61DC
		public int closeField
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1989788737 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600500F RID: 20495 RVA: 0x000F7E26 File Offset: 0x000F6226
		public static Offset<TeamCopyBossTable> CreateTeamCopyBossTable(FlatBufferBuilder builder, int ID = 0, int teamCopyID = 0, int teamGrade = 0, int stage = 0, int appearField = 0, int closeField = 0)
		{
			builder.StartObject(6);
			TeamCopyBossTable.AddCloseField(builder, closeField);
			TeamCopyBossTable.AddAppearField(builder, appearField);
			TeamCopyBossTable.AddStage(builder, stage);
			TeamCopyBossTable.AddTeamGrade(builder, teamGrade);
			TeamCopyBossTable.AddTeamCopyID(builder, teamCopyID);
			TeamCopyBossTable.AddID(builder, ID);
			return TeamCopyBossTable.EndTeamCopyBossTable(builder);
		}

		// Token: 0x06005010 RID: 20496 RVA: 0x000F7E62 File Offset: 0x000F6262
		public static void StartTeamCopyBossTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06005011 RID: 20497 RVA: 0x000F7E6B File Offset: 0x000F626B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005012 RID: 20498 RVA: 0x000F7E76 File Offset: 0x000F6276
		public static void AddTeamCopyID(FlatBufferBuilder builder, int teamCopyID)
		{
			builder.AddInt(1, teamCopyID, 0);
		}

		// Token: 0x06005013 RID: 20499 RVA: 0x000F7E81 File Offset: 0x000F6281
		public static void AddTeamGrade(FlatBufferBuilder builder, int teamGrade)
		{
			builder.AddInt(2, teamGrade, 0);
		}

		// Token: 0x06005014 RID: 20500 RVA: 0x000F7E8C File Offset: 0x000F628C
		public static void AddStage(FlatBufferBuilder builder, int stage)
		{
			builder.AddInt(3, stage, 0);
		}

		// Token: 0x06005015 RID: 20501 RVA: 0x000F7E97 File Offset: 0x000F6297
		public static void AddAppearField(FlatBufferBuilder builder, int appearField)
		{
			builder.AddInt(4, appearField, 0);
		}

		// Token: 0x06005016 RID: 20502 RVA: 0x000F7EA2 File Offset: 0x000F62A2
		public static void AddCloseField(FlatBufferBuilder builder, int closeField)
		{
			builder.AddInt(5, closeField, 0);
		}

		// Token: 0x06005017 RID: 20503 RVA: 0x000F7EB0 File Offset: 0x000F62B0
		public static Offset<TeamCopyBossTable> EndTeamCopyBossTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyBossTable>(value);
		}

		// Token: 0x06005018 RID: 20504 RVA: 0x000F7ECA File Offset: 0x000F62CA
		public static void FinishTeamCopyBossTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyBossTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DD8 RID: 7640
		private Table __p = new Table();

		// Token: 0x020005E8 RID: 1512
		public enum eCrypt
		{
			// Token: 0x04001DDA RID: 7642
			code = -1989788737
		}
	}
}
