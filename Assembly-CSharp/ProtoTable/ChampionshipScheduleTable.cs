using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000304 RID: 772
	public class ChampionshipScheduleTable : IFlatbufferObject
	{
		// Token: 0x170005A6 RID: 1446
		// (get) Token: 0x06001E65 RID: 7781 RVA: 0x00081EF4 File Offset: 0x000802F4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001E66 RID: 7782 RVA: 0x00081F01 File Offset: 0x00080301
		public static ChampionshipScheduleTable GetRootAsChampionshipScheduleTable(ByteBuffer _bb)
		{
			return ChampionshipScheduleTable.GetRootAsChampionshipScheduleTable(_bb, new ChampionshipScheduleTable());
		}

		// Token: 0x06001E67 RID: 7783 RVA: 0x00081F0E File Offset: 0x0008030E
		public static ChampionshipScheduleTable GetRootAsChampionshipScheduleTable(ByteBuffer _bb, ChampionshipScheduleTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001E68 RID: 7784 RVA: 0x00081F2A File Offset: 0x0008032A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001E69 RID: 7785 RVA: 0x00081F44 File Offset: 0x00080344
		public ChampionshipScheduleTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005A7 RID: 1447
		// (get) Token: 0x06001E6A RID: 7786 RVA: 0x00081F50 File Offset: 0x00080350
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1604964118 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005A8 RID: 1448
		// (get) Token: 0x06001E6B RID: 7787 RVA: 0x00081F9C File Offset: 0x0008039C
		public string ScheduleName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E6C RID: 7788 RVA: 0x00081FDE File Offset: 0x000803DE
		public ArraySegment<byte>? GetScheduleNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170005A9 RID: 1449
		// (get) Token: 0x06001E6D RID: 7789 RVA: 0x00081FEC File Offset: 0x000803EC
		public string ScheduleTitle
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E6E RID: 7790 RVA: 0x0008202E File Offset: 0x0008042E
		public ArraySegment<byte>? GetScheduleTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170005AA RID: 1450
		// (get) Token: 0x06001E6F RID: 7791 RVA: 0x0008203C File Offset: 0x0008043C
		public string SchedulePreTitle
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E70 RID: 7792 RVA: 0x0008207F File Offset: 0x0008047F
		public ArraySegment<byte>? GetSchedulePreTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170005AB RID: 1451
		// (get) Token: 0x06001E71 RID: 7793 RVA: 0x00082090 File Offset: 0x00080490
		public string ScheduleTabContent
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E72 RID: 7794 RVA: 0x000820D3 File Offset: 0x000804D3
		public ArraySegment<byte>? GetScheduleTabContentBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170005AC RID: 1452
		// (get) Token: 0x06001E73 RID: 7795 RVA: 0x000820E4 File Offset: 0x000804E4
		public ChampionshipScheduleTable.eScheduleType ScheduleType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (ChampionshipScheduleTable.eScheduleType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005AD RID: 1453
		// (get) Token: 0x06001E74 RID: 7796 RVA: 0x00082128 File Offset: 0x00080528
		public string ScheduleDescription
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E75 RID: 7797 RVA: 0x0008216B File Offset: 0x0008056B
		public ArraySegment<byte>? GetScheduleDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170005AE RID: 1454
		// (get) Token: 0x06001E76 RID: 7798 RVA: 0x0008217C File Offset: 0x0008057C
		public string ScheduleRule
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E77 RID: 7799 RVA: 0x000821BF File Offset: 0x000805BF
		public ArraySegment<byte>? GetScheduleRuleBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170005AF RID: 1455
		// (get) Token: 0x06001E78 RID: 7800 RVA: 0x000821D0 File Offset: 0x000805D0
		public string JoinCost
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E79 RID: 7801 RVA: 0x00082213 File Offset: 0x00080613
		public ArraySegment<byte>? GetJoinCostBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170005B0 RID: 1456
		// (get) Token: 0x06001E7A RID: 7802 RVA: 0x00082224 File Offset: 0x00080624
		public string ScheduleIconPath
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001E7B RID: 7803 RVA: 0x00082267 File Offset: 0x00080667
		public ArraySegment<byte>? GetScheduleIconPathBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x170005B1 RID: 1457
		// (get) Token: 0x06001E7C RID: 7804 RVA: 0x00082278 File Offset: 0x00080678
		public int BigRewardPreviewTableId
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1604964118 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005B2 RID: 1458
		// (get) Token: 0x06001E7D RID: 7805 RVA: 0x000822C4 File Offset: 0x000806C4
		public int CommonHelpId
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (1604964118 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001E7E RID: 7806 RVA: 0x00082310 File Offset: 0x00080710
		public static Offset<ChampionshipScheduleTable> CreateChampionshipScheduleTable(FlatBufferBuilder builder, int ID = 0, StringOffset ScheduleNameOffset = default(StringOffset), StringOffset ScheduleTitleOffset = default(StringOffset), StringOffset SchedulePreTitleOffset = default(StringOffset), StringOffset ScheduleTabContentOffset = default(StringOffset), ChampionshipScheduleTable.eScheduleType ScheduleType = ChampionshipScheduleTable.eScheduleType.None, StringOffset ScheduleDescriptionOffset = default(StringOffset), StringOffset ScheduleRuleOffset = default(StringOffset), StringOffset JoinCostOffset = default(StringOffset), StringOffset ScheduleIconPathOffset = default(StringOffset), int BigRewardPreviewTableId = 0, int CommonHelpId = 0)
		{
			builder.StartObject(12);
			ChampionshipScheduleTable.AddCommonHelpId(builder, CommonHelpId);
			ChampionshipScheduleTable.AddBigRewardPreviewTableId(builder, BigRewardPreviewTableId);
			ChampionshipScheduleTable.AddScheduleIconPath(builder, ScheduleIconPathOffset);
			ChampionshipScheduleTable.AddJoinCost(builder, JoinCostOffset);
			ChampionshipScheduleTable.AddScheduleRule(builder, ScheduleRuleOffset);
			ChampionshipScheduleTable.AddScheduleDescription(builder, ScheduleDescriptionOffset);
			ChampionshipScheduleTable.AddScheduleType(builder, ScheduleType);
			ChampionshipScheduleTable.AddScheduleTabContent(builder, ScheduleTabContentOffset);
			ChampionshipScheduleTable.AddSchedulePreTitle(builder, SchedulePreTitleOffset);
			ChampionshipScheduleTable.AddScheduleTitle(builder, ScheduleTitleOffset);
			ChampionshipScheduleTable.AddScheduleName(builder, ScheduleNameOffset);
			ChampionshipScheduleTable.AddID(builder, ID);
			return ChampionshipScheduleTable.EndChampionshipScheduleTable(builder);
		}

		// Token: 0x06001E7F RID: 7807 RVA: 0x00082388 File Offset: 0x00080788
		public static void StartChampionshipScheduleTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06001E80 RID: 7808 RVA: 0x00082392 File Offset: 0x00080792
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001E81 RID: 7809 RVA: 0x0008239D File Offset: 0x0008079D
		public static void AddScheduleName(FlatBufferBuilder builder, StringOffset ScheduleNameOffset)
		{
			builder.AddOffset(1, ScheduleNameOffset.Value, 0);
		}

		// Token: 0x06001E82 RID: 7810 RVA: 0x000823AE File Offset: 0x000807AE
		public static void AddScheduleTitle(FlatBufferBuilder builder, StringOffset ScheduleTitleOffset)
		{
			builder.AddOffset(2, ScheduleTitleOffset.Value, 0);
		}

		// Token: 0x06001E83 RID: 7811 RVA: 0x000823BF File Offset: 0x000807BF
		public static void AddSchedulePreTitle(FlatBufferBuilder builder, StringOffset SchedulePreTitleOffset)
		{
			builder.AddOffset(3, SchedulePreTitleOffset.Value, 0);
		}

		// Token: 0x06001E84 RID: 7812 RVA: 0x000823D0 File Offset: 0x000807D0
		public static void AddScheduleTabContent(FlatBufferBuilder builder, StringOffset ScheduleTabContentOffset)
		{
			builder.AddOffset(4, ScheduleTabContentOffset.Value, 0);
		}

		// Token: 0x06001E85 RID: 7813 RVA: 0x000823E1 File Offset: 0x000807E1
		public static void AddScheduleType(FlatBufferBuilder builder, ChampionshipScheduleTable.eScheduleType ScheduleType)
		{
			builder.AddInt(5, (int)ScheduleType, 0);
		}

		// Token: 0x06001E86 RID: 7814 RVA: 0x000823EC File Offset: 0x000807EC
		public static void AddScheduleDescription(FlatBufferBuilder builder, StringOffset ScheduleDescriptionOffset)
		{
			builder.AddOffset(6, ScheduleDescriptionOffset.Value, 0);
		}

		// Token: 0x06001E87 RID: 7815 RVA: 0x000823FD File Offset: 0x000807FD
		public static void AddScheduleRule(FlatBufferBuilder builder, StringOffset ScheduleRuleOffset)
		{
			builder.AddOffset(7, ScheduleRuleOffset.Value, 0);
		}

		// Token: 0x06001E88 RID: 7816 RVA: 0x0008240E File Offset: 0x0008080E
		public static void AddJoinCost(FlatBufferBuilder builder, StringOffset JoinCostOffset)
		{
			builder.AddOffset(8, JoinCostOffset.Value, 0);
		}

		// Token: 0x06001E89 RID: 7817 RVA: 0x0008241F File Offset: 0x0008081F
		public static void AddScheduleIconPath(FlatBufferBuilder builder, StringOffset ScheduleIconPathOffset)
		{
			builder.AddOffset(9, ScheduleIconPathOffset.Value, 0);
		}

		// Token: 0x06001E8A RID: 7818 RVA: 0x00082431 File Offset: 0x00080831
		public static void AddBigRewardPreviewTableId(FlatBufferBuilder builder, int BigRewardPreviewTableId)
		{
			builder.AddInt(10, BigRewardPreviewTableId, 0);
		}

		// Token: 0x06001E8B RID: 7819 RVA: 0x0008243D File Offset: 0x0008083D
		public static void AddCommonHelpId(FlatBufferBuilder builder, int CommonHelpId)
		{
			builder.AddInt(11, CommonHelpId, 0);
		}

		// Token: 0x06001E8C RID: 7820 RVA: 0x0008244C File Offset: 0x0008084C
		public static Offset<ChampionshipScheduleTable> EndChampionshipScheduleTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChampionshipScheduleTable>(value);
		}

		// Token: 0x06001E8D RID: 7821 RVA: 0x00082466 File Offset: 0x00080866
		public static void FinishChampionshipScheduleTableBuffer(FlatBufferBuilder builder, Offset<ChampionshipScheduleTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F31 RID: 3889
		private Table __p = new Table();

		// Token: 0x02000305 RID: 773
		public enum eScheduleType
		{
			// Token: 0x04000F33 RID: 3891
			None,
			// Token: 0x04000F34 RID: 3892
			SignUp,
			// Token: 0x04000F35 RID: 3893
			Sea_Select,
			// Token: 0x04000F36 RID: 3894
			ReSea_Select,
			// Token: 0x04000F37 RID: 3895
			SixtyFour_Select,
			// Token: 0x04000F38 RID: 3896
			Sixteen_Select,
			// Token: 0x04000F39 RID: 3897
			Eight_Select,
			// Token: 0x04000F3A RID: 3898
			Four_Select,
			// Token: 0x04000F3B RID: 3899
			Two_Select,
			// Token: 0x04000F3C RID: 3900
			One_Select
		}

		// Token: 0x02000306 RID: 774
		public enum eCrypt
		{
			// Token: 0x04000F3E RID: 3902
			code = 1604964118
		}
	}
}
