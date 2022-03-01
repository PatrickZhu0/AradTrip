using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005EE RID: 1518
	public class TeamCopyGridMonsterTable : IFlatbufferObject
	{
		// Token: 0x17001633 RID: 5683
		// (get) Token: 0x06005075 RID: 20597 RVA: 0x000F8C58 File Offset: 0x000F7058
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005076 RID: 20598 RVA: 0x000F8C65 File Offset: 0x000F7065
		public static TeamCopyGridMonsterTable GetRootAsTeamCopyGridMonsterTable(ByteBuffer _bb)
		{
			return TeamCopyGridMonsterTable.GetRootAsTeamCopyGridMonsterTable(_bb, new TeamCopyGridMonsterTable());
		}

		// Token: 0x06005077 RID: 20599 RVA: 0x000F8C72 File Offset: 0x000F7072
		public static TeamCopyGridMonsterTable GetRootAsTeamCopyGridMonsterTable(ByteBuffer _bb, TeamCopyGridMonsterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005078 RID: 20600 RVA: 0x000F8C8E File Offset: 0x000F708E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005079 RID: 20601 RVA: 0x000F8CA8 File Offset: 0x000F70A8
		public TeamCopyGridMonsterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001634 RID: 5684
		// (get) Token: 0x0600507A RID: 20602 RVA: 0x000F8CB4 File Offset: 0x000F70B4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1871140102 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001635 RID: 5685
		// (get) Token: 0x0600507B RID: 20603 RVA: 0x000F8D00 File Offset: 0x000F7100
		public int monsterType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1871140102 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001636 RID: 5686
		// (get) Token: 0x0600507C RID: 20604 RVA: 0x000F8D4C File Offset: 0x000F714C
		public int bornPos
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1871140102 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001637 RID: 5687
		// (get) Token: 0x0600507D RID: 20605 RVA: 0x000F8D98 File Offset: 0x000F7198
		public int moveCd
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1871140102 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001638 RID: 5688
		// (get) Token: 0x0600507E RID: 20606 RVA: 0x000F8DE4 File Offset: 0x000F71E4
		public string attackPath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600507F RID: 20607 RVA: 0x000F8E27 File Offset: 0x000F7227
		public ArraySegment<byte>? GetAttackPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17001639 RID: 5689
		// (get) Token: 0x06005080 RID: 20608 RVA: 0x000F8E38 File Offset: 0x000F7238
		public string MonsterName
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005081 RID: 20609 RVA: 0x000F8E7B File Offset: 0x000F727B
		public ArraySegment<byte>? GetMonsterNameBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x06005082 RID: 20610 RVA: 0x000F8E8A File Offset: 0x000F728A
		public static Offset<TeamCopyGridMonsterTable> CreateTeamCopyGridMonsterTable(FlatBufferBuilder builder, int ID = 0, int monsterType = 0, int bornPos = 0, int moveCd = 0, StringOffset attackPathOffset = default(StringOffset), StringOffset MonsterNameOffset = default(StringOffset))
		{
			builder.StartObject(6);
			TeamCopyGridMonsterTable.AddMonsterName(builder, MonsterNameOffset);
			TeamCopyGridMonsterTable.AddAttackPath(builder, attackPathOffset);
			TeamCopyGridMonsterTable.AddMoveCd(builder, moveCd);
			TeamCopyGridMonsterTable.AddBornPos(builder, bornPos);
			TeamCopyGridMonsterTable.AddMonsterType(builder, monsterType);
			TeamCopyGridMonsterTable.AddID(builder, ID);
			return TeamCopyGridMonsterTable.EndTeamCopyGridMonsterTable(builder);
		}

		// Token: 0x06005083 RID: 20611 RVA: 0x000F8EC6 File Offset: 0x000F72C6
		public static void StartTeamCopyGridMonsterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06005084 RID: 20612 RVA: 0x000F8ECF File Offset: 0x000F72CF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005085 RID: 20613 RVA: 0x000F8EDA File Offset: 0x000F72DA
		public static void AddMonsterType(FlatBufferBuilder builder, int monsterType)
		{
			builder.AddInt(1, monsterType, 0);
		}

		// Token: 0x06005086 RID: 20614 RVA: 0x000F8EE5 File Offset: 0x000F72E5
		public static void AddBornPos(FlatBufferBuilder builder, int bornPos)
		{
			builder.AddInt(2, bornPos, 0);
		}

		// Token: 0x06005087 RID: 20615 RVA: 0x000F8EF0 File Offset: 0x000F72F0
		public static void AddMoveCd(FlatBufferBuilder builder, int moveCd)
		{
			builder.AddInt(3, moveCd, 0);
		}

		// Token: 0x06005088 RID: 20616 RVA: 0x000F8EFB File Offset: 0x000F72FB
		public static void AddAttackPath(FlatBufferBuilder builder, StringOffset attackPathOffset)
		{
			builder.AddOffset(4, attackPathOffset.Value, 0);
		}

		// Token: 0x06005089 RID: 20617 RVA: 0x000F8F0C File Offset: 0x000F730C
		public static void AddMonsterName(FlatBufferBuilder builder, StringOffset MonsterNameOffset)
		{
			builder.AddOffset(5, MonsterNameOffset.Value, 0);
		}

		// Token: 0x0600508A RID: 20618 RVA: 0x000F8F20 File Offset: 0x000F7320
		public static Offset<TeamCopyGridMonsterTable> EndTeamCopyGridMonsterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyGridMonsterTable>(value);
		}

		// Token: 0x0600508B RID: 20619 RVA: 0x000F8F3A File Offset: 0x000F733A
		public static void FinishTeamCopyGridMonsterTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyGridMonsterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DE9 RID: 7657
		private Table __p = new Table();

		// Token: 0x020005EF RID: 1519
		public enum eCrypt
		{
			// Token: 0x04001DEB RID: 7659
			code = -1871140102
		}
	}
}
