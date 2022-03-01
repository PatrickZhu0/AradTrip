using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005FC RID: 1532
	public class TeamDuplicationSetTable : IFlatbufferObject
	{
		// Token: 0x17001663 RID: 5731
		// (get) Token: 0x06005114 RID: 20756 RVA: 0x000FA108 File Offset: 0x000F8508
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005115 RID: 20757 RVA: 0x000FA115 File Offset: 0x000F8515
		public static TeamDuplicationSetTable GetRootAsTeamDuplicationSetTable(ByteBuffer _bb)
		{
			return TeamDuplicationSetTable.GetRootAsTeamDuplicationSetTable(_bb, new TeamDuplicationSetTable());
		}

		// Token: 0x06005116 RID: 20758 RVA: 0x000FA122 File Offset: 0x000F8522
		public static TeamDuplicationSetTable GetRootAsTeamDuplicationSetTable(ByteBuffer _bb, TeamDuplicationSetTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005117 RID: 20759 RVA: 0x000FA13E File Offset: 0x000F853E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005118 RID: 20760 RVA: 0x000FA158 File Offset: 0x000F8558
		public TeamDuplicationSetTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001664 RID: 5732
		// (get) Token: 0x06005119 RID: 20761 RVA: 0x000FA164 File Offset: 0x000F8564
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-86472745 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001665 RID: 5733
		// (get) Token: 0x0600511A RID: 20762 RVA: 0x000FA1B0 File Offset: 0x000F85B0
		public int TeamType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-86472745 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001666 RID: 5734
		// (get) Token: 0x0600511B RID: 20763 RVA: 0x000FA1FC File Offset: 0x000F85FC
		public int Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-86472745 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001667 RID: 5735
		// (get) Token: 0x0600511C RID: 20764 RVA: 0x000FA248 File Offset: 0x000F8648
		public int Number
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-86472745 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001668 RID: 5736
		// (get) Token: 0x0600511D RID: 20765 RVA: 0x000FA294 File Offset: 0x000F8694
		public int TeamRelation
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-86472745 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600511E RID: 20766 RVA: 0x000FA2DE File Offset: 0x000F86DE
		public static Offset<TeamDuplicationSetTable> CreateTeamDuplicationSetTable(FlatBufferBuilder builder, int ID = 0, int TeamType = 0, int Type = 0, int Number = 0, int TeamRelation = 0)
		{
			builder.StartObject(5);
			TeamDuplicationSetTable.AddTeamRelation(builder, TeamRelation);
			TeamDuplicationSetTable.AddNumber(builder, Number);
			TeamDuplicationSetTable.AddType(builder, Type);
			TeamDuplicationSetTable.AddTeamType(builder, TeamType);
			TeamDuplicationSetTable.AddID(builder, ID);
			return TeamDuplicationSetTable.EndTeamDuplicationSetTable(builder);
		}

		// Token: 0x0600511F RID: 20767 RVA: 0x000FA312 File Offset: 0x000F8712
		public static void StartTeamDuplicationSetTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06005120 RID: 20768 RVA: 0x000FA31B File Offset: 0x000F871B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005121 RID: 20769 RVA: 0x000FA326 File Offset: 0x000F8726
		public static void AddTeamType(FlatBufferBuilder builder, int TeamType)
		{
			builder.AddInt(1, TeamType, 0);
		}

		// Token: 0x06005122 RID: 20770 RVA: 0x000FA331 File Offset: 0x000F8731
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(2, Type, 0);
		}

		// Token: 0x06005123 RID: 20771 RVA: 0x000FA33C File Offset: 0x000F873C
		public static void AddNumber(FlatBufferBuilder builder, int Number)
		{
			builder.AddInt(3, Number, 0);
		}

		// Token: 0x06005124 RID: 20772 RVA: 0x000FA347 File Offset: 0x000F8747
		public static void AddTeamRelation(FlatBufferBuilder builder, int TeamRelation)
		{
			builder.AddInt(4, TeamRelation, 0);
		}

		// Token: 0x06005125 RID: 20773 RVA: 0x000FA354 File Offset: 0x000F8754
		public static Offset<TeamDuplicationSetTable> EndTeamDuplicationSetTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamDuplicationSetTable>(value);
		}

		// Token: 0x06005126 RID: 20774 RVA: 0x000FA36E File Offset: 0x000F876E
		public static void FinishTeamDuplicationSetTableBuffer(FlatBufferBuilder builder, Offset<TeamDuplicationSetTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001E03 RID: 7683
		private Table __p = new Table();

		// Token: 0x020005FD RID: 1533
		public enum eCrypt
		{
			// Token: 0x04001E05 RID: 7685
			code = -86472745
		}
	}
}
