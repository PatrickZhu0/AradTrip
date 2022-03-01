using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002FF RID: 767
	public class ChampionTimeTable : IFlatbufferObject
	{
		// Token: 0x17000599 RID: 1433
		// (get) Token: 0x06001E34 RID: 7732 RVA: 0x00081920 File Offset: 0x0007FD20
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001E35 RID: 7733 RVA: 0x0008192D File Offset: 0x0007FD2D
		public static ChampionTimeTable GetRootAsChampionTimeTable(ByteBuffer _bb)
		{
			return ChampionTimeTable.GetRootAsChampionTimeTable(_bb, new ChampionTimeTable());
		}

		// Token: 0x06001E36 RID: 7734 RVA: 0x0008193A File Offset: 0x0007FD3A
		public static ChampionTimeTable GetRootAsChampionTimeTable(ByteBuffer _bb, ChampionTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001E37 RID: 7735 RVA: 0x00081956 File Offset: 0x0007FD56
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001E38 RID: 7736 RVA: 0x00081970 File Offset: 0x0007FD70
		public ChampionTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700059A RID: 1434
		// (get) Token: 0x06001E39 RID: 7737 RVA: 0x0008197C File Offset: 0x0007FD7C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1972274580 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700059B RID: 1435
		// (get) Token: 0x06001E3A RID: 7738 RVA: 0x000819C8 File Offset: 0x0007FDC8
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E3B RID: 7739 RVA: 0x00081A0A File Offset: 0x0007FE0A
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700059C RID: 1436
		// (get) Token: 0x06001E3C RID: 7740 RVA: 0x00081A18 File Offset: 0x0007FE18
		public ChampionTimeTable.eStatus Status
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ChampionTimeTable.eStatus)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700059D RID: 1437
		// (get) Token: 0x06001E3D RID: 7741 RVA: 0x00081A5C File Offset: 0x0007FE5C
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E3E RID: 7742 RVA: 0x00081A9F File Offset: 0x0007FE9F
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700059E RID: 1438
		// (get) Token: 0x06001E3F RID: 7743 RVA: 0x00081AB0 File Offset: 0x0007FEB0
		public string EndTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E40 RID: 7744 RVA: 0x00081AF3 File Offset: 0x0007FEF3
		public ArraySegment<byte>? GetEndTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700059F RID: 1439
		// (get) Token: 0x06001E41 RID: 7745 RVA: 0x00081B04 File Offset: 0x0007FF04
		public string PreStartTime
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E42 RID: 7746 RVA: 0x00081B47 File Offset: 0x0007FF47
		public ArraySegment<byte>? GetPreStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170005A0 RID: 1440
		// (get) Token: 0x06001E43 RID: 7747 RVA: 0x00081B58 File Offset: 0x0007FF58
		public string PrepareStartTime
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E44 RID: 7748 RVA: 0x00081B9B File Offset: 0x0007FF9B
		public ArraySegment<byte>? GetPrepareStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170005A1 RID: 1441
		// (get) Token: 0x06001E45 RID: 7749 RVA: 0x00081BAC File Offset: 0x0007FFAC
		public string BattleStartTime
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E46 RID: 7750 RVA: 0x00081BEF File Offset: 0x0007FFEF
		public ArraySegment<byte>? GetBattleStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170005A2 RID: 1442
		// (get) Token: 0x06001E47 RID: 7751 RVA: 0x00081C00 File Offset: 0x00080000
		public string BattleEndTime
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E48 RID: 7752 RVA: 0x00081C43 File Offset: 0x00080043
		public ArraySegment<byte>? GetBattleEndTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06001E49 RID: 7753 RVA: 0x00081C54 File Offset: 0x00080054
		public static Offset<ChampionTimeTable> CreateChampionTimeTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), ChampionTimeTable.eStatus Status = ChampionTimeTable.eStatus.CLT_INIT, StringOffset StartTimeOffset = default(StringOffset), StringOffset EndTimeOffset = default(StringOffset), StringOffset PreStartTimeOffset = default(StringOffset), StringOffset PrepareStartTimeOffset = default(StringOffset), StringOffset BattleStartTimeOffset = default(StringOffset), StringOffset BattleEndTimeOffset = default(StringOffset))
		{
			builder.StartObject(9);
			ChampionTimeTable.AddBattleEndTime(builder, BattleEndTimeOffset);
			ChampionTimeTable.AddBattleStartTime(builder, BattleStartTimeOffset);
			ChampionTimeTable.AddPrepareStartTime(builder, PrepareStartTimeOffset);
			ChampionTimeTable.AddPreStartTime(builder, PreStartTimeOffset);
			ChampionTimeTable.AddEndTime(builder, EndTimeOffset);
			ChampionTimeTable.AddStartTime(builder, StartTimeOffset);
			ChampionTimeTable.AddStatus(builder, Status);
			ChampionTimeTable.AddDesc(builder, DescOffset);
			ChampionTimeTable.AddID(builder, ID);
			return ChampionTimeTable.EndChampionTimeTable(builder);
		}

		// Token: 0x06001E4A RID: 7754 RVA: 0x00081CB4 File Offset: 0x000800B4
		public static void StartChampionTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06001E4B RID: 7755 RVA: 0x00081CBE File Offset: 0x000800BE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001E4C RID: 7756 RVA: 0x00081CC9 File Offset: 0x000800C9
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x06001E4D RID: 7757 RVA: 0x00081CDA File Offset: 0x000800DA
		public static void AddStatus(FlatBufferBuilder builder, ChampionTimeTable.eStatus Status)
		{
			builder.AddInt(2, (int)Status, 0);
		}

		// Token: 0x06001E4E RID: 7758 RVA: 0x00081CE5 File Offset: 0x000800E5
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(3, StartTimeOffset.Value, 0);
		}

		// Token: 0x06001E4F RID: 7759 RVA: 0x00081CF6 File Offset: 0x000800F6
		public static void AddEndTime(FlatBufferBuilder builder, StringOffset EndTimeOffset)
		{
			builder.AddOffset(4, EndTimeOffset.Value, 0);
		}

		// Token: 0x06001E50 RID: 7760 RVA: 0x00081D07 File Offset: 0x00080107
		public static void AddPreStartTime(FlatBufferBuilder builder, StringOffset PreStartTimeOffset)
		{
			builder.AddOffset(5, PreStartTimeOffset.Value, 0);
		}

		// Token: 0x06001E51 RID: 7761 RVA: 0x00081D18 File Offset: 0x00080118
		public static void AddPrepareStartTime(FlatBufferBuilder builder, StringOffset PrepareStartTimeOffset)
		{
			builder.AddOffset(6, PrepareStartTimeOffset.Value, 0);
		}

		// Token: 0x06001E52 RID: 7762 RVA: 0x00081D29 File Offset: 0x00080129
		public static void AddBattleStartTime(FlatBufferBuilder builder, StringOffset BattleStartTimeOffset)
		{
			builder.AddOffset(7, BattleStartTimeOffset.Value, 0);
		}

		// Token: 0x06001E53 RID: 7763 RVA: 0x00081D3A File Offset: 0x0008013A
		public static void AddBattleEndTime(FlatBufferBuilder builder, StringOffset BattleEndTimeOffset)
		{
			builder.AddOffset(8, BattleEndTimeOffset.Value, 0);
		}

		// Token: 0x06001E54 RID: 7764 RVA: 0x00081D4C File Offset: 0x0008014C
		public static Offset<ChampionTimeTable> EndChampionTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionTimeTable>(value);
		}

		// Token: 0x06001E55 RID: 7765 RVA: 0x00081D66 File Offset: 0x00080166
		public static void FinishChampionTimeTableBuffer(FlatBufferBuilder builder, Offset<ChampionTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F20 RID: 3872
		private Table __p = new Table();

		// Token: 0x02000300 RID: 768
		public enum eStatus
		{
			// Token: 0x04000F22 RID: 3874
			CLT_INIT,
			// Token: 0x04000F23 RID: 3875
			CLT_ENROLL,
			// Token: 0x04000F24 RID: 3876
			CLT_SEA,
			// Token: 0x04000F25 RID: 3877
			CLT_RE_SEA,
			// Token: 0x04000F26 RID: 3878
			CLT_64,
			// Token: 0x04000F27 RID: 3879
			CLT_16,
			// Token: 0x04000F28 RID: 3880
			CLT_8,
			// Token: 0x04000F29 RID: 3881
			CLT_4,
			// Token: 0x04000F2A RID: 3882
			CLT_HALF_FINAL,
			// Token: 0x04000F2B RID: 3883
			CLT_FINAL
		}

		// Token: 0x02000301 RID: 769
		public enum eCrypt
		{
			// Token: 0x04000F2D RID: 3885
			code = 1972274580
		}
	}
}
