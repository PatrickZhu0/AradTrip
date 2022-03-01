using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005F0 RID: 1520
	public class TeamCopyGridParamTable : IFlatbufferObject
	{
		// Token: 0x1700163A RID: 5690
		// (get) Token: 0x0600508D RID: 20621 RVA: 0x000F8F5C File Offset: 0x000F735C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600508E RID: 20622 RVA: 0x000F8F69 File Offset: 0x000F7369
		public static TeamCopyGridParamTable GetRootAsTeamCopyGridParamTable(ByteBuffer _bb)
		{
			return TeamCopyGridParamTable.GetRootAsTeamCopyGridParamTable(_bb, new TeamCopyGridParamTable());
		}

		// Token: 0x0600508F RID: 20623 RVA: 0x000F8F76 File Offset: 0x000F7376
		public static TeamCopyGridParamTable GetRootAsTeamCopyGridParamTable(ByteBuffer _bb, TeamCopyGridParamTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005090 RID: 20624 RVA: 0x000F8F92 File Offset: 0x000F7392
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005091 RID: 20625 RVA: 0x000F8FAC File Offset: 0x000F73AC
		public TeamCopyGridParamTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700163B RID: 5691
		// (get) Token: 0x06005092 RID: 20626 RVA: 0x000F8FB8 File Offset: 0x000F73B8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-2137261043 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700163C RID: 5692
		// (get) Token: 0x06005093 RID: 20627 RVA: 0x000F9004 File Offset: 0x000F7404
		public int GridType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-2137261043 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700163D RID: 5693
		// (get) Token: 0x06005094 RID: 20628 RVA: 0x000F9050 File Offset: 0x000F7450
		public string Param
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005095 RID: 20629 RVA: 0x000F9092 File Offset: 0x000F7492
		public ArraySegment<byte>? GetParamBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700163E RID: 5694
		// (get) Token: 0x06005096 RID: 20630 RVA: 0x000F90A0 File Offset: 0x000F74A0
		public string Param2
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005097 RID: 20631 RVA: 0x000F90E3 File Offset: 0x000F74E3
		public ArraySegment<byte>? GetParam2Bytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700163F RID: 5695
		// (get) Token: 0x06005098 RID: 20632 RVA: 0x000F90F4 File Offset: 0x000F74F4
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06005099 RID: 20633 RVA: 0x000F9137 File Offset: 0x000F7537
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x0600509A RID: 20634 RVA: 0x000F9146 File Offset: 0x000F7546
		public static Offset<TeamCopyGridParamTable> CreateTeamCopyGridParamTable(FlatBufferBuilder builder, int ID = 0, int GridType = 0, StringOffset ParamOffset = default(StringOffset), StringOffset Param2Offset = default(StringOffset), StringOffset DescOffset = default(StringOffset))
		{
			builder.StartObject(5);
			TeamCopyGridParamTable.AddDesc(builder, DescOffset);
			TeamCopyGridParamTable.AddParam2(builder, Param2Offset);
			TeamCopyGridParamTable.AddParam(builder, ParamOffset);
			TeamCopyGridParamTable.AddGridType(builder, GridType);
			TeamCopyGridParamTable.AddID(builder, ID);
			return TeamCopyGridParamTable.EndTeamCopyGridParamTable(builder);
		}

		// Token: 0x0600509B RID: 20635 RVA: 0x000F917A File Offset: 0x000F757A
		public static void StartTeamCopyGridParamTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0600509C RID: 20636 RVA: 0x000F9183 File Offset: 0x000F7583
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600509D RID: 20637 RVA: 0x000F918E File Offset: 0x000F758E
		public static void AddGridType(FlatBufferBuilder builder, int GridType)
		{
			builder.AddInt(1, GridType, 0);
		}

		// Token: 0x0600509E RID: 20638 RVA: 0x000F9199 File Offset: 0x000F7599
		public static void AddParam(FlatBufferBuilder builder, StringOffset ParamOffset)
		{
			builder.AddOffset(2, ParamOffset.Value, 0);
		}

		// Token: 0x0600509F RID: 20639 RVA: 0x000F91AA File Offset: 0x000F75AA
		public static void AddParam2(FlatBufferBuilder builder, StringOffset Param2Offset)
		{
			builder.AddOffset(3, Param2Offset.Value, 0);
		}

		// Token: 0x060050A0 RID: 20640 RVA: 0x000F91BB File Offset: 0x000F75BB
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(4, DescOffset.Value, 0);
		}

		// Token: 0x060050A1 RID: 20641 RVA: 0x000F91CC File Offset: 0x000F75CC
		public static Offset<TeamCopyGridParamTable> EndTeamCopyGridParamTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<TeamCopyGridParamTable>(value);
		}

		// Token: 0x060050A2 RID: 20642 RVA: 0x000F91E6 File Offset: 0x000F75E6
		public static void FinishTeamCopyGridParamTableBuffer(FlatBufferBuilder builder, Offset<TeamCopyGridParamTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001DEC RID: 7660
		private Table __p = new Table();

		// Token: 0x020005F1 RID: 1521
		public enum eCrypt
		{
			// Token: 0x04001DEE RID: 7662
			code = -2137261043
		}
	}
}
