using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002FA RID: 762
	public class ChampionGambleTable : IFlatbufferObject
	{
		// Token: 0x17000588 RID: 1416
		// (get) Token: 0x06001DFE RID: 7678 RVA: 0x000811F0 File Offset: 0x0007F5F0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001DFF RID: 7679 RVA: 0x000811FD File Offset: 0x0007F5FD
		public static ChampionGambleTable GetRootAsChampionGambleTable(ByteBuffer _bb)
		{
			return ChampionGambleTable.GetRootAsChampionGambleTable(_bb, new ChampionGambleTable());
		}

		// Token: 0x06001E00 RID: 7680 RVA: 0x0008120A File Offset: 0x0007F60A
		public static ChampionGambleTable GetRootAsChampionGambleTable(ByteBuffer _bb, ChampionGambleTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001E01 RID: 7681 RVA: 0x00081226 File Offset: 0x0007F626
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001E02 RID: 7682 RVA: 0x00081240 File Offset: 0x0007F640
		public ChampionGambleTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000589 RID: 1417
		// (get) Token: 0x06001E03 RID: 7683 RVA: 0x0008124C File Offset: 0x0007F64C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-311181755 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700058A RID: 1418
		// (get) Token: 0x06001E04 RID: 7684 RVA: 0x00081298 File Offset: 0x0007F698
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E05 RID: 7685 RVA: 0x000812DA File Offset: 0x0007F6DA
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700058B RID: 1419
		// (get) Token: 0x06001E06 RID: 7686 RVA: 0x000812E8 File Offset: 0x0007F6E8
		public ChampionGambleTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ChampionGambleTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700058C RID: 1420
		// (get) Token: 0x06001E07 RID: 7687 RVA: 0x0008132C File Offset: 0x0007F72C
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E08 RID: 7688 RVA: 0x0008136F File Offset: 0x0007F76F
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700058D RID: 1421
		// (get) Token: 0x06001E09 RID: 7689 RVA: 0x00081380 File Offset: 0x0007F780
		public string EndTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E0A RID: 7690 RVA: 0x000813C3 File Offset: 0x0007F7C3
		public ArraySegment<byte>? GetEndTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x06001E0B RID: 7691 RVA: 0x000813D4 File Offset: 0x0007F7D4
		public int state
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-311181755 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x06001E0C RID: 7692 RVA: 0x00081420 File Offset: 0x0007F820
		public int groupStart
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-311181755 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06001E0D RID: 7693 RVA: 0x0008146C File Offset: 0x0007F86C
		public int groupEnd
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-311181755 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001E0E RID: 7694 RVA: 0x000814B8 File Offset: 0x0007F8B8
		public static Offset<ChampionGambleTable> CreateChampionGambleTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset), ChampionGambleTable.eType Type = ChampionGambleTable.eType.Type_None, StringOffset StartTimeOffset = default(StringOffset), StringOffset EndTimeOffset = default(StringOffset), int state = 0, int groupStart = 0, int groupEnd = 0)
		{
			builder.StartObject(8);
			ChampionGambleTable.AddGroupEnd(builder, groupEnd);
			ChampionGambleTable.AddGroupStart(builder, groupStart);
			ChampionGambleTable.AddState(builder, state);
			ChampionGambleTable.AddEndTime(builder, EndTimeOffset);
			ChampionGambleTable.AddStartTime(builder, StartTimeOffset);
			ChampionGambleTable.AddType(builder, Type);
			ChampionGambleTable.AddDesc(builder, DescOffset);
			ChampionGambleTable.AddID(builder, ID);
			return ChampionGambleTable.EndChampionGambleTable(builder);
		}

		// Token: 0x06001E0F RID: 7695 RVA: 0x0008150F File Offset: 0x0007F90F
		public static void StartChampionGambleTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06001E10 RID: 7696 RVA: 0x00081518 File Offset: 0x0007F918
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001E11 RID: 7697 RVA: 0x00081523 File Offset: 0x0007F923
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x06001E12 RID: 7698 RVA: 0x00081534 File Offset: 0x0007F934
		public static void AddType(FlatBufferBuilder builder, ChampionGambleTable.eType Type)
		{
			builder.AddInt(2, (int)Type, 0);
		}

		// Token: 0x06001E13 RID: 7699 RVA: 0x0008153F File Offset: 0x0007F93F
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(3, StartTimeOffset.Value, 0);
		}

		// Token: 0x06001E14 RID: 7700 RVA: 0x00081550 File Offset: 0x0007F950
		public static void AddEndTime(FlatBufferBuilder builder, StringOffset EndTimeOffset)
		{
			builder.AddOffset(4, EndTimeOffset.Value, 0);
		}

		// Token: 0x06001E15 RID: 7701 RVA: 0x00081561 File Offset: 0x0007F961
		public static void AddState(FlatBufferBuilder builder, int state)
		{
			builder.AddInt(5, state, 0);
		}

		// Token: 0x06001E16 RID: 7702 RVA: 0x0008156C File Offset: 0x0007F96C
		public static void AddGroupStart(FlatBufferBuilder builder, int groupStart)
		{
			builder.AddInt(6, groupStart, 0);
		}

		// Token: 0x06001E17 RID: 7703 RVA: 0x00081577 File Offset: 0x0007F977
		public static void AddGroupEnd(FlatBufferBuilder builder, int groupEnd)
		{
			builder.AddInt(7, groupEnd, 0);
		}

		// Token: 0x06001E18 RID: 7704 RVA: 0x00081584 File Offset: 0x0007F984
		public static Offset<ChampionGambleTable> EndChampionGambleTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionGambleTable>(value);
		}

		// Token: 0x06001E19 RID: 7705 RVA: 0x0008159E File Offset: 0x0007F99E
		public static void FinishChampionGambleTableBuffer(FlatBufferBuilder builder, Offset<ChampionGambleTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F14 RID: 3860
		private Table __p = new Table();

		// Token: 0x020002FB RID: 763
		public enum eType
		{
			// Token: 0x04000F16 RID: 3862
			Type_None,
			// Token: 0x04000F17 RID: 3863
			GT_CHAMPION,
			// Token: 0x04000F18 RID: 3864
			GT_1V1,
			// Token: 0x04000F19 RID: 3865
			GT_BATTLE_COUNT,
			// Token: 0x04000F1A RID: 3866
			GT_CHAMPION_BATTLE_SCORE
		}

		// Token: 0x020002FC RID: 764
		public enum eCrypt
		{
			// Token: 0x04000F1C RID: 3868
			code = -311181755
		}
	}
}
