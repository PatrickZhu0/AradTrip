using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005E9 RID: 1513
	public class TeamCopyFieldTable : IFlatbufferObject
	{
		// Token: 0x17001614 RID: 5652
		// (get) Token: 0x0600501A RID: 20506 RVA: 0x000F7EEC File Offset: 0x000F62EC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600501B RID: 20507 RVA: 0x000F7EF9 File Offset: 0x000F62F9
		public static TeamCopyFieldTable GetRootAsTeamCopyFieldTable(ByteBuffer _bb)
		{
			return TeamCopyFieldTable.GetRootAsTeamCopyFieldTable(_bb, new TeamCopyFieldTable());
		}

		// Token: 0x0600501C RID: 20508 RVA: 0x000F7F06 File Offset: 0x000F6306
		public static TeamCopyFieldTable GetRootAsTeamCopyFieldTable(ByteBuffer _bb, TeamCopyFieldTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600501D RID: 20509 RVA: 0x000F7F22 File Offset: 0x000F6322
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600501E RID: 20510 RVA: 0x000F7F3C File Offset: 0x000F633C
		public TeamCopyFieldTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001615 RID: 5653
		// (get) Token: 0x0600501F RID: 20511 RVA: 0x000F7F48 File Offset: 0x000F6348
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001616 RID: 5654
		// (get) Token: 0x06005020 RID: 20512 RVA: 0x000F7F94 File Offset: 0x000F6394
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005021 RID: 20513 RVA: 0x000F7FD6 File Offset: 0x000F63D6
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001617 RID: 5655
		// (get) Token: 0x06005022 RID: 20514 RVA: 0x000F7FE4 File Offset: 0x000F63E4
		public int TeamGrade
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001618 RID: 5656
		// (get) Token: 0x06005023 RID: 20515 RVA: 0x000F8030 File Offset: 0x000F6430
		public string StrongholdDesc
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005024 RID: 20516 RVA: 0x000F8073 File Offset: 0x000F6473
		public ArraySegment<byte>? GetStrongholdDescBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001619 RID: 5657
		// (get) Token: 0x06005025 RID: 20517 RVA: 0x000F8084 File Offset: 0x000F6484
		public int DungeonId
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700161A RID: 5658
		// (get) Token: 0x06005026 RID: 20518 RVA: 0x000F80D0 File Offset: 0x000F64D0
		public TeamCopyFieldTable.ePresentedType PresentedType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (TeamCopyFieldTable.ePresentedType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700161B RID: 5659
		// (get) Token: 0x06005027 RID: 20519 RVA: 0x000F8114 File Offset: 0x000F6514
		public int DefeatCond
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700161C RID: 5660
		// (get) Token: 0x06005028 RID: 20520 RVA: 0x000F8160 File Offset: 0x000F6560
		public int RebornTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005029 RID: 20521 RVA: 0x000F81AC File Offset: 0x000F65AC
		public int UnlockedCondArray(int j)
		{
			int num = this.__p.__offset(20);
			return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700161D RID: 5661
		// (get) Token: 0x0600502A RID: 20522 RVA: 0x000F81FC File Offset: 0x000F65FC
		public int UnlockedCondLength
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600502B RID: 20523 RVA: 0x000F822F File Offset: 0x000F662F
		public ArraySegment<byte>? GetUnlockedCondBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x1700161E RID: 5662
		// (get) Token: 0x0600502C RID: 20524 RVA: 0x000F823E File Offset: 0x000F663E
		public FlatBufferArray<int> UnlockedCond
		{
			get
			{
				if (this.UnlockedCondValue == null)
				{
					this.UnlockedCondValue = new FlatBufferArray<int>(new Func<int, int>(this.UnlockedCondArray), this.UnlockedCondLength);
				}
				return this.UnlockedCondValue;
			}
		}

		// Token: 0x1700161F RID: 5663
		// (get) Token: 0x0600502D RID: 20525 RVA: 0x000F8270 File Offset: 0x000F6670
		public int appearStatus
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600502E RID: 20526 RVA: 0x000F82BC File Offset: 0x000F66BC
		public string UpdateFieldStatusArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001620 RID: 5664
		// (get) Token: 0x0600502F RID: 20527 RVA: 0x000F8304 File Offset: 0x000F6704
		public int UpdateFieldStatusLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001621 RID: 5665
		// (get) Token: 0x06005030 RID: 20528 RVA: 0x000F8337 File Offset: 0x000F6737
		public FlatBufferArray<string> UpdateFieldStatus
		{
			get
			{
				if (this.UpdateFieldStatusValue == null)
				{
					this.UpdateFieldStatusValue = new FlatBufferArray<string>(new Func<int, string>(this.UpdateFieldStatusArray), this.UpdateFieldStatusLength);
				}
				return this.UpdateFieldStatusValue;
			}
		}

		// Token: 0x17001622 RID: 5666
		// (get) Token: 0x06005031 RID: 20529 RVA: 0x000F8368 File Offset: 0x000F6768
		public int PreFieldPointId
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001623 RID: 5667
		// (get) Token: 0x06005032 RID: 20530 RVA: 0x000F83B4 File Offset: 0x000F67B4
		public int PositionIndex
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001624 RID: 5668
		// (get) Token: 0x06005033 RID: 20531 RVA: 0x000F8400 File Offset: 0x000F6800
		public int UnLockTip
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (666151196 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001625 RID: 5669
		// (get) Token: 0x06005034 RID: 20532 RVA: 0x000F844C File Offset: 0x000F684C
		public string NormalIconPath
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005035 RID: 20533 RVA: 0x000F848F File Offset: 0x000F688F
		public ArraySegment<byte>? GetNormalIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17001626 RID: 5670
		// (get) Token: 0x06005036 RID: 20534 RVA: 0x000F84A0 File Offset: 0x000F68A0
		public string SelectedIconPath
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005037 RID: 20535 RVA: 0x000F84E3 File Offset: 0x000F68E3
		public ArraySegment<byte>? GetSelectedIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17001627 RID: 5671
		// (get) Token: 0x06005038 RID: 20536 RVA: 0x000F84F4 File Offset: 0x000F68F4
		public string BossSecondStageNormalIconPath
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005039 RID: 20537 RVA: 0x000F8537 File Offset: 0x000F6937
		public ArraySegment<byte>? GetBossSecondStageNormalIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17001628 RID: 5672
		// (get) Token: 0x0600503A RID: 20538 RVA: 0x000F8548 File Offset: 0x000F6948
		public string BossSecondStageSelectedIconPath
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600503B RID: 20539 RVA: 0x000F858B File Offset: 0x000F698B
		public ArraySegment<byte>? GetBossSecondStageSelectedIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x17001629 RID: 5673
		// (get) Token: 0x0600503C RID: 20540 RVA: 0x000F859C File Offset: 0x000F699C
		public string BossThirdStageNormalIconPath
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600503D RID: 20541 RVA: 0x000F85DF File Offset: 0x000F69DF
		public ArraySegment<byte>? GetBossThirdStageNormalIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(40);
		}

		// Token: 0x1700162A RID: 5674
		// (get) Token: 0x0600503E RID: 20542 RVA: 0x000F85F0 File Offset: 0x000F69F0
		public string BossThirdStageSelectedIconPath
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600503F RID: 20543 RVA: 0x000F8633 File Offset: 0x000F6A33
		public ArraySegment<byte>? GetBossThirdStageSelectedIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(42);
		}

		// Token: 0x06005040 RID: 20544 RVA: 0x000F8644 File Offset: 0x000F6A44
		public static Offset<TeamCopyFieldTable> CreateTeamCopyFieldTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int TeamGrade = 0, StringOffset StrongholdDescOffset = default(StringOffset), int DungeonId = 0, TeamCopyFieldTable.ePresentedType PresentedType = TeamCopyFieldTable.ePresentedType.PresentedType_None, int DefeatCond = 0, int RebornTime = 0, VectorOffset UnlockedCondOffset = default(VectorOffset), int appearStatus = 0, VectorOffset UpdateFieldStatusOffset = default(VectorOffset), int PreFieldPointId = 0, int PositionIndex = 0, int UnLockTip = 0, StringOffset NormalIconPathOffset = default(StringOffset), StringOffset SelectedIconPathOffset = default(StringOffset), StringOffset BossSecondStageNormalIconPathOffset = default(StringOffset), StringOffset BossSecondStageSelectedIconPathOffset = default(StringOffset), StringOffset BossThirdStageNormalIconPathOffset = default(StringOffset), StringOffset BossThirdStageSelectedIconPathOffset = default(StringOffset))
		{
			builder.StartObject(20);
			TeamCopyFieldTable.AddBossThirdStageSelectedIconPath(builder, BossThirdStageSelectedIconPathOffset);
			TeamCopyFieldTable.AddBossThirdStageNormalIconPath(builder, BossThirdStageNormalIconPathOffset);
			TeamCopyFieldTable.AddBossSecondStageSelectedIconPath(builder, BossSecondStageSelectedIconPathOffset);
			TeamCopyFieldTable.AddBossSecondStageNormalIconPath(builder, BossSecondStageNormalIconPathOffset);
			TeamCopyFieldTable.AddSelectedIconPath(builder, SelectedIconPathOffset);
			TeamCopyFieldTable.AddNormalIconPath(builder, NormalIconPathOffset);
			TeamCopyFieldTable.AddUnLockTip(builder, UnLockTip);
			TeamCopyFieldTable.AddPositionIndex(builder, PositionIndex);
			TeamCopyFieldTable.AddPreFieldPointId(builder, PreFieldPointId);
			TeamCopyFieldTable.AddUpdateFieldStatus(builder, UpdateFieldStatusOffset);
			TeamCopyFieldTable.AddAppearStatus(builder, appearStatus);
			TeamCopyFieldTable.AddUnlockedCond(builder, UnlockedCondOffset);
			TeamCopyFieldTable.AddRebornTime(builder, RebornTime);
			TeamCopyFieldTable.AddDefeatCond(builder, DefeatCond);
			TeamCopyFieldTable.AddPresentedType(builder, PresentedType);
			TeamCopyFieldTable.AddDungeonId(builder, DungeonId);
			TeamCopyFieldTable.AddStrongholdDesc(builder, StrongholdDescOffset);
			TeamCopyFieldTable.AddTeamGrade(builder, TeamGrade);
			TeamCopyFieldTable.AddName(builder, NameOffset);
			TeamCopyFieldTable.AddID(builder, ID);
			return TeamCopyFieldTable.EndTeamCopyFieldTable(builder);
		}

		// Token: 0x06005041 RID: 20545 RVA: 0x000F86FC File Offset: 0x000F6AFC
		public static void StartTeamCopyFieldTable(FlatBufferBuilder builder)
		{
			builder.StartObject(20);
		}

		// Token: 0x06005042 RID: 20546 RVA: 0x000F8706 File Offset: 0x000F6B06
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06005043 RID: 20547 RVA: 0x000F8711 File Offset: 0x000F6B11
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06005044 RID: 20548 RVA: 0x000F8722 File Offset: 0x000F6B22
		public static void AddTeamGrade(FlatBufferBuilder builder, int TeamGrade)
		{
			builder.AddInt(2, TeamGrade, 0);
		}

		// Token: 0x06005045 RID: 20549 RVA: 0x000F872D File Offset: 0x000F6B2D
		public static void AddStrongholdDesc(FlatBufferBuilder builder, StringOffset StrongholdDescOffset)
		{
			builder.AddOffset(3, StrongholdDescOffset.Value, 0);
		}

		// Token: 0x06005046 RID: 20550 RVA: 0x000F873E File Offset: 0x000F6B3E
		public static void AddDungeonId(FlatBufferBuilder builder, int DungeonId)
		{
			builder.AddInt(4, DungeonId, 0);
		}

		// Token: 0x06005047 RID: 20551 RVA: 0x000F8749 File Offset: 0x000F6B49
		public static void AddPresentedType(FlatBufferBuilder builder, TeamCopyFieldTable.ePresentedType PresentedType)
		{
			builder.AddInt(5, (int)PresentedType, 0);
		}

		// Token: 0x06005048 RID: 20552 RVA: 0x000F8754 File Offset: 0x000F6B54
		public static void AddDefeatCond(FlatBufferBuilder builder, int DefeatCond)
		{
			builder.AddInt(6, DefeatCond, 0);
		}

		// Token: 0x06005049 RID: 20553 RVA: 0x000F875F File Offset: 0x000F6B5F
		public static void AddRebornTime(FlatBufferBuilder builder, int RebornTime)
		{
			builder.AddInt(7, RebornTime, 0);
		}

		// Token: 0x0600504A RID: 20554 RVA: 0x000F876A File Offset: 0x000F6B6A
		public static void AddUnlockedCond(FlatBufferBuilder builder, VectorOffset UnlockedCondOffset)
		{
			builder.AddOffset(8, UnlockedCondOffset.Value, 0);
		}

		// Token: 0x0600504B RID: 20555 RVA: 0x000F877C File Offset: 0x000F6B7C
		public static VectorOffset CreateUnlockedCondVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600504C RID: 20556 RVA: 0x000F87B9 File Offset: 0x000F6BB9
		public static void StartUnlockedCondVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600504D RID: 20557 RVA: 0x000F87C4 File Offset: 0x000F6BC4
		public static void AddAppearStatus(FlatBufferBuilder builder, int appearStatus)
		{
			builder.AddInt(9, appearStatus, 0);
		}

		// Token: 0x0600504E RID: 20558 RVA: 0x000F87D0 File Offset: 0x000F6BD0
		public static void AddUpdateFieldStatus(FlatBufferBuilder builder, VectorOffset UpdateFieldStatusOffset)
		{
			builder.AddOffset(10, UpdateFieldStatusOffset.Value, 0);
		}

		// Token: 0x0600504F RID: 20559 RVA: 0x000F87E4 File Offset: 0x000F6BE4
		public static VectorOffset CreateUpdateFieldStatusVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06005050 RID: 20560 RVA: 0x000F882A File Offset: 0x000F6C2A
		public static void StartUpdateFieldStatusVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06005051 RID: 20561 RVA: 0x000F8835 File Offset: 0x000F6C35
		public static void AddPreFieldPointId(FlatBufferBuilder builder, int PreFieldPointId)
		{
			builder.AddInt(11, PreFieldPointId, 0);
		}

		// Token: 0x06005052 RID: 20562 RVA: 0x000F8841 File Offset: 0x000F6C41
		public static void AddPositionIndex(FlatBufferBuilder builder, int PositionIndex)
		{
			builder.AddInt(12, PositionIndex, 0);
		}

		// Token: 0x06005053 RID: 20563 RVA: 0x000F884D File Offset: 0x000F6C4D
		public static void AddUnLockTip(FlatBufferBuilder builder, int UnLockTip)
		{
			builder.AddInt(13, UnLockTip, 0);
		}

		// Token: 0x06005054 RID: 20564 RVA: 0x000F8859 File Offset: 0x000F6C59
		public static void AddNormalIconPath(FlatBufferBuilder builder, StringOffset NormalIconPathOffset)
		{
			builder.AddOffset(14, NormalIconPathOffset.Value, 0);
		}

		// Token: 0x06005055 RID: 20565 RVA: 0x000F886B File Offset: 0x000F6C6B
		public static void AddSelectedIconPath(FlatBufferBuilder builder, StringOffset SelectedIconPathOffset)
		{
			builder.AddOffset(15, SelectedIconPathOffset.Value, 0);
		}

		// Token: 0x06005056 RID: 20566 RVA: 0x000F887D File Offset: 0x000F6C7D
		public static void AddBossSecondStageNormalIconPath(FlatBufferBuilder builder, StringOffset BossSecondStageNormalIconPathOffset)
		{
			builder.AddOffset(16, BossSecondStageNormalIconPathOffset.Value, 0);
		}

		// Token: 0x06005057 RID: 20567 RVA: 0x000F888F File Offset: 0x000F6C8F
		public static void AddBossSecondStageSelectedIconPath(FlatBufferBuilder builder, StringOffset BossSecondStageSelectedIconPathOffset)
		{
			builder.AddOffset(17, BossSecondStageSelectedIconPathOffset.Value, 0);
		}

		// Token: 0x06005058 RID: 20568 RVA: 0x000F88A1 File Offset: 0x000F6CA1
		public static void AddBossThirdStageNormalIconPath(FlatBufferBuilder builder, StringOffset BossThirdStageNormalIconPathOffset)
		{
			builder.AddOffset(18, BossThirdStageNormalIconPathOffset.Value, 0);
		}

		// Token: 0x06005059 RID: 20569 RVA: 0x000F88B3 File Offset: 0x000F6CB3
		public static void AddBossThirdStageSelectedIconPath(FlatBufferBuilder builder, StringOffset BossThirdStageSelectedIconPathOffset)
		{
			builder.AddOffset(19, BossThirdStageSelectedIconPathOffset.Value, 0);
		}

		// Token: 0x0600505A RID: 20570 RVA: 0x000F88C8 File Offset: 0x000F6CC8
		public static Offset<TeamCopyFieldTable> EndTeamCopyFieldTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyFieldTable>(value);
		}

		// Token: 0x0600505B RID: 20571 RVA: 0x000F88E2 File Offset: 0x000F6CE2
		public static void FinishTeamCopyFieldTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyFieldTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DDB RID: 7643
		private Table __p = new Table();

		// Token: 0x04001DDC RID: 7644
		private FlatBufferArray<int> UnlockedCondValue;

		// Token: 0x04001DDD RID: 7645
		private FlatBufferArray<string> UpdateFieldStatusValue;

		// Token: 0x020005EA RID: 1514
		public enum ePresentedType
		{
			// Token: 0x04001DDF RID: 7647
			PresentedType_None,
			// Token: 0x04001DE0 RID: 7648
			BeginAppear,
			// Token: 0x04001DE1 RID: 7649
			UnlockByPreFightPoint,
			// Token: 0x04001DE2 RID: 7650
			BossFightPoint,
			// Token: 0x04001DE3 RID: 7651
			BossRelationFightPoint
		}

		// Token: 0x020005EB RID: 1515
		public enum eCrypt
		{
			// Token: 0x04001DE5 RID: 7653
			code = 666151196
		}
	}
}
