using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005F2 RID: 1522
	public class TeamCopyStageTable : IFlatbufferObject
	{
		// Token: 0x17001640 RID: 5696
		// (get) Token: 0x060050A4 RID: 20644 RVA: 0x000F9208 File Offset: 0x000F7608
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060050A5 RID: 20645 RVA: 0x000F9215 File Offset: 0x000F7615
		public static TeamCopyStageTable GetRootAsTeamCopyStageTable(ByteBuffer _bb)
		{
			return TeamCopyStageTable.GetRootAsTeamCopyStageTable(_bb, new TeamCopyStageTable());
		}

		// Token: 0x060050A6 RID: 20646 RVA: 0x000F9222 File Offset: 0x000F7622
		public static TeamCopyStageTable GetRootAsTeamCopyStageTable(ByteBuffer _bb, TeamCopyStageTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060050A7 RID: 20647 RVA: 0x000F923E File Offset: 0x000F763E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060050A8 RID: 20648 RVA: 0x000F9258 File Offset: 0x000F7658
		public TeamCopyStageTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001641 RID: 5697
		// (get) Token: 0x060050A9 RID: 20649 RVA: 0x000F9264 File Offset: 0x000F7664
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (297913306 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001642 RID: 5698
		// (get) Token: 0x060050AA RID: 20650 RVA: 0x000F92B0 File Offset: 0x000F76B0
		public string Description
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050AB RID: 20651 RVA: 0x000F92F2 File Offset: 0x000F76F2
		public ArraySegment<byte>? GetDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001643 RID: 5699
		// (get) Token: 0x060050AC RID: 20652 RVA: 0x000F9300 File Offset: 0x000F7700
		public string StageImagePath
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050AD RID: 20653 RVA: 0x000F9342 File Offset: 0x000F7742
		public ArraySegment<byte>? GetStageImagePathBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001644 RID: 5700
		// (get) Token: 0x060050AE RID: 20654 RVA: 0x000F9350 File Offset: 0x000F7750
		public string NormalBackgroundPath
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050AF RID: 20655 RVA: 0x000F9393 File Offset: 0x000F7793
		public ArraySegment<byte>? GetNormalBackgroundPathBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001645 RID: 5701
		// (get) Token: 0x060050B0 RID: 20656 RVA: 0x000F93A4 File Offset: 0x000F77A4
		public string ExtraBackgroundPath
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060050B1 RID: 20657 RVA: 0x000F93E7 File Offset: 0x000F77E7
		public ArraySegment<byte>? GetExtraBackgroundPathBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x060050B2 RID: 20658 RVA: 0x000F93F6 File Offset: 0x000F77F6
		public static Offset<TeamCopyStageTable> CreateTeamCopyStageTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescriptionOffset = default(StringOffset), StringOffset StageImagePathOffset = default(StringOffset), StringOffset NormalBackgroundPathOffset = default(StringOffset), StringOffset ExtraBackgroundPathOffset = default(StringOffset))
		{
			builder.StartObject(5);
			TeamCopyStageTable.AddExtraBackgroundPath(builder, ExtraBackgroundPathOffset);
			TeamCopyStageTable.AddNormalBackgroundPath(builder, NormalBackgroundPathOffset);
			TeamCopyStageTable.AddStageImagePath(builder, StageImagePathOffset);
			TeamCopyStageTable.AddDescription(builder, DescriptionOffset);
			TeamCopyStageTable.AddID(builder, ID);
			return TeamCopyStageTable.EndTeamCopyStageTable(builder);
		}

		// Token: 0x060050B3 RID: 20659 RVA: 0x000F942A File Offset: 0x000F782A
		public static void StartTeamCopyStageTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060050B4 RID: 20660 RVA: 0x000F9433 File Offset: 0x000F7833
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060050B5 RID: 20661 RVA: 0x000F943E File Offset: 0x000F783E
		public static void AddDescription(FlatBufferBuilder builder, StringOffset DescriptionOffset)
		{
			builder.AddOffset(1, DescriptionOffset.Value, 0);
		}

		// Token: 0x060050B6 RID: 20662 RVA: 0x000F944F File Offset: 0x000F784F
		public static void AddStageImagePath(FlatBufferBuilder builder, StringOffset StageImagePathOffset)
		{
			builder.AddOffset(2, StageImagePathOffset.Value, 0);
		}

		// Token: 0x060050B7 RID: 20663 RVA: 0x000F9460 File Offset: 0x000F7860
		public static void AddNormalBackgroundPath(FlatBufferBuilder builder, StringOffset NormalBackgroundPathOffset)
		{
			builder.AddOffset(3, NormalBackgroundPathOffset.Value, 0);
		}

		// Token: 0x060050B8 RID: 20664 RVA: 0x000F9471 File Offset: 0x000F7871
		public static void AddExtraBackgroundPath(FlatBufferBuilder builder, StringOffset ExtraBackgroundPathOffset)
		{
			builder.AddOffset(4, ExtraBackgroundPathOffset.Value, 0);
		}

		// Token: 0x060050B9 RID: 20665 RVA: 0x000F9484 File Offset: 0x000F7884
		public static Offset<TeamCopyStageTable> EndTeamCopyStageTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyStageTable>(value);
		}

		// Token: 0x060050BA RID: 20666 RVA: 0x000F949E File Offset: 0x000F789E
		public static void FinishTeamCopyStageTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyStageTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DEF RID: 7663
		private Table __p = new Table();

		// Token: 0x020005F3 RID: 1523
		public enum eCrypt
		{
			// Token: 0x04001DF1 RID: 7665
			code = 297913306
		}
	}
}
