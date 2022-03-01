using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000542 RID: 1346
	public class OpActivityTaskTable : IFlatbufferObject
	{
		// Token: 0x1700129B RID: 4763
		// (get) Token: 0x06004568 RID: 17768 RVA: 0x000DF2C4 File Offset: 0x000DD6C4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004569 RID: 17769 RVA: 0x000DF2D1 File Offset: 0x000DD6D1
		public static OpActivityTaskTable GetRootAsOpActivityTaskTable(ByteBuffer _bb)
		{
			return OpActivityTaskTable.GetRootAsOpActivityTaskTable(_bb, new OpActivityTaskTable());
		}

		// Token: 0x0600456A RID: 17770 RVA: 0x000DF2DE File Offset: 0x000DD6DE
		public static OpActivityTaskTable GetRootAsOpActivityTaskTable(ByteBuffer _bb, OpActivityTaskTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600456B RID: 17771 RVA: 0x000DF2FA File Offset: 0x000DD6FA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600456C RID: 17772 RVA: 0x000DF314 File Offset: 0x000DD714
		public OpActivityTaskTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700129C RID: 4764
		// (get) Token: 0x0600456D RID: 17773 RVA: 0x000DF320 File Offset: 0x000DD720
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700129D RID: 4765
		// (get) Token: 0x0600456E RID: 17774 RVA: 0x000DF36C File Offset: 0x000DD76C
		public int OpActivityID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700129E RID: 4766
		// (get) Token: 0x0600456F RID: 17775 RVA: 0x000DF3B8 File Offset: 0x000DD7B8
		public int OpActivityType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700129F RID: 4767
		// (get) Token: 0x06004570 RID: 17776 RVA: 0x000DF404 File Offset: 0x000DD804
		public int PreTaskId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012A0 RID: 4768
		// (get) Token: 0x06004571 RID: 17777 RVA: 0x000DF450 File Offset: 0x000DD850
		public int NextTaskId
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012A1 RID: 4769
		// (get) Token: 0x06004572 RID: 17778 RVA: 0x000DF49C File Offset: 0x000DD89C
		public string CompleteCount
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004573 RID: 17779 RVA: 0x000DF4DF File Offset: 0x000DD8DF
		public ArraySegment<byte>? GetCompleteCountBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170012A2 RID: 4770
		// (get) Token: 0x06004574 RID: 17780 RVA: 0x000DF4F0 File Offset: 0x000DD8F0
		public string TaskReward
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004575 RID: 17781 RVA: 0x000DF533 File Offset: 0x000DD933
		public ArraySegment<byte>? GetTaskRewardBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x170012A3 RID: 4771
		// (get) Token: 0x06004576 RID: 17782 RVA: 0x000DF544 File Offset: 0x000DD944
		public string TaskDescription
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004577 RID: 17783 RVA: 0x000DF587 File Offset: 0x000DD987
		public ArraySegment<byte>? GetTaskDescriptionBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170012A4 RID: 4772
		// (get) Token: 0x06004578 RID: 17784 RVA: 0x000DF598 File Offset: 0x000DD998
		public string TaskVar
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004579 RID: 17785 RVA: 0x000DF5DB File Offset: 0x000DD9DB
		public ArraySegment<byte>? GetTaskVarBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x170012A5 RID: 4773
		// (get) Token: 0x0600457A RID: 17786 RVA: 0x000DF5EC File Offset: 0x000DD9EC
		public string TaskVar2
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600457B RID: 17787 RVA: 0x000DF62F File Offset: 0x000DDA2F
		public ArraySegment<byte>? GetTaskVar2Bytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x170012A6 RID: 4774
		// (get) Token: 0x0600457C RID: 17788 RVA: 0x000DF640 File Offset: 0x000DDA40
		public string ConsumeScore
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600457D RID: 17789 RVA: 0x000DF683 File Offset: 0x000DDA83
		public ArraySegment<byte>? GetConsumeScoreBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170012A7 RID: 4775
		// (get) Token: 0x0600457E RID: 17790 RVA: 0x000DF694 File Offset: 0x000DDA94
		public string Name
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600457F RID: 17791 RVA: 0x000DF6D7 File Offset: 0x000DDAD7
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170012A8 RID: 4776
		// (get) Token: 0x06004580 RID: 17792 RVA: 0x000DF6E8 File Offset: 0x000DDAE8
		public string TaskVarProgressName
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004581 RID: 17793 RVA: 0x000DF72B File Offset: 0x000DDB2B
		public ArraySegment<byte>? GetTaskVarProgressNameBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x170012A9 RID: 4777
		// (get) Token: 0x06004582 RID: 17794 RVA: 0x000DF73C File Offset: 0x000DDB3C
		public int PlayerLevelLimit
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012AA RID: 4778
		// (get) Token: 0x06004583 RID: 17795 RVA: 0x000DF788 File Offset: 0x000DDB88
		public int AccountDailySubmitLimit
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012AB RID: 4779
		// (get) Token: 0x06004584 RID: 17796 RVA: 0x000DF7D4 File Offset: 0x000DDBD4
		public int AccountTotalSubmitLimit
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012AC RID: 4780
		// (get) Token: 0x06004585 RID: 17797 RVA: 0x000DF820 File Offset: 0x000DDC20
		public int ResetType
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012AD RID: 4781
		// (get) Token: 0x06004586 RID: 17798 RVA: 0x000DF86C File Offset: 0x000DDC6C
		public int CantAccept
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012AE RID: 4782
		// (get) Token: 0x06004587 RID: 17799 RVA: 0x000DF8B8 File Offset: 0x000DDCB8
		public int EventType
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012AF RID: 4783
		// (get) Token: 0x06004588 RID: 17800 RVA: 0x000DF904 File Offset: 0x000DDD04
		public int SubEventType
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012B0 RID: 4784
		// (get) Token: 0x06004589 RID: 17801 RVA: 0x000DF950 File Offset: 0x000DDD50
		public int AccountWeeklySubmitLimit
		{
			get
			{
				int num = this.__p.__offset(44);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170012B1 RID: 4785
		// (get) Token: 0x0600458A RID: 17802 RVA: 0x000DF99C File Offset: 0x000DDD9C
		public int AccountTask
		{
			get
			{
				int num = this.__p.__offset(46);
				return (num == 0) ? 0 : (-1204541283 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600458B RID: 17803 RVA: 0x000DF9E8 File Offset: 0x000DDDE8
		public static Offset<OpActivityTaskTable> CreateOpActivityTaskTable(FlatBufferBuilder builder, int ID = 0, int OpActivityID = 0, int OpActivityType = 0, int PreTaskId = 0, int NextTaskId = 0, StringOffset CompleteCountOffset = default(StringOffset), StringOffset TaskRewardOffset = default(StringOffset), StringOffset TaskDescriptionOffset = default(StringOffset), StringOffset TaskVarOffset = default(StringOffset), StringOffset TaskVar2Offset = default(StringOffset), StringOffset ConsumeScoreOffset = default(StringOffset), StringOffset NameOffset = default(StringOffset), StringOffset TaskVarProgressNameOffset = default(StringOffset), int PlayerLevelLimit = 0, int AccountDailySubmitLimit = 0, int AccountTotalSubmitLimit = 0, int ResetType = 0, int CantAccept = 0, int EventType = 0, int SubEventType = 0, int AccountWeeklySubmitLimit = 0, int AccountTask = 0)
		{
			builder.StartObject(22);
			OpActivityTaskTable.AddAccountTask(builder, AccountTask);
			OpActivityTaskTable.AddAccountWeeklySubmitLimit(builder, AccountWeeklySubmitLimit);
			OpActivityTaskTable.AddSubEventType(builder, SubEventType);
			OpActivityTaskTable.AddEventType(builder, EventType);
			OpActivityTaskTable.AddCantAccept(builder, CantAccept);
			OpActivityTaskTable.AddResetType(builder, ResetType);
			OpActivityTaskTable.AddAccountTotalSubmitLimit(builder, AccountTotalSubmitLimit);
			OpActivityTaskTable.AddAccountDailySubmitLimit(builder, AccountDailySubmitLimit);
			OpActivityTaskTable.AddPlayerLevelLimit(builder, PlayerLevelLimit);
			OpActivityTaskTable.AddTaskVarProgressName(builder, TaskVarProgressNameOffset);
			OpActivityTaskTable.AddName(builder, NameOffset);
			OpActivityTaskTable.AddConsumeScore(builder, ConsumeScoreOffset);
			OpActivityTaskTable.AddTaskVar2(builder, TaskVar2Offset);
			OpActivityTaskTable.AddTaskVar(builder, TaskVarOffset);
			OpActivityTaskTable.AddTaskDescription(builder, TaskDescriptionOffset);
			OpActivityTaskTable.AddTaskReward(builder, TaskRewardOffset);
			OpActivityTaskTable.AddCompleteCount(builder, CompleteCountOffset);
			OpActivityTaskTable.AddNextTaskId(builder, NextTaskId);
			OpActivityTaskTable.AddPreTaskId(builder, PreTaskId);
			OpActivityTaskTable.AddOpActivityType(builder, OpActivityType);
			OpActivityTaskTable.AddOpActivityID(builder, OpActivityID);
			OpActivityTaskTable.AddID(builder, ID);
			return OpActivityTaskTable.EndOpActivityTaskTable(builder);
		}

		// Token: 0x0600458C RID: 17804 RVA: 0x000DFAB0 File Offset: 0x000DDEB0
		public static void StartOpActivityTaskTable(FlatBufferBuilder builder)
		{
			builder.StartObject(22);
		}

		// Token: 0x0600458D RID: 17805 RVA: 0x000DFABA File Offset: 0x000DDEBA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600458E RID: 17806 RVA: 0x000DFAC5 File Offset: 0x000DDEC5
		public static void AddOpActivityID(FlatBufferBuilder builder, int OpActivityID)
		{
			builder.AddInt(1, OpActivityID, 0);
		}

		// Token: 0x0600458F RID: 17807 RVA: 0x000DFAD0 File Offset: 0x000DDED0
		public static void AddOpActivityType(FlatBufferBuilder builder, int OpActivityType)
		{
			builder.AddInt(2, OpActivityType, 0);
		}

		// Token: 0x06004590 RID: 17808 RVA: 0x000DFADB File Offset: 0x000DDEDB
		public static void AddPreTaskId(FlatBufferBuilder builder, int PreTaskId)
		{
			builder.AddInt(3, PreTaskId, 0);
		}

		// Token: 0x06004591 RID: 17809 RVA: 0x000DFAE6 File Offset: 0x000DDEE6
		public static void AddNextTaskId(FlatBufferBuilder builder, int NextTaskId)
		{
			builder.AddInt(4, NextTaskId, 0);
		}

		// Token: 0x06004592 RID: 17810 RVA: 0x000DFAF1 File Offset: 0x000DDEF1
		public static void AddCompleteCount(FlatBufferBuilder builder, StringOffset CompleteCountOffset)
		{
			builder.AddOffset(5, CompleteCountOffset.Value, 0);
		}

		// Token: 0x06004593 RID: 17811 RVA: 0x000DFB02 File Offset: 0x000DDF02
		public static void AddTaskReward(FlatBufferBuilder builder, StringOffset TaskRewardOffset)
		{
			builder.AddOffset(6, TaskRewardOffset.Value, 0);
		}

		// Token: 0x06004594 RID: 17812 RVA: 0x000DFB13 File Offset: 0x000DDF13
		public static void AddTaskDescription(FlatBufferBuilder builder, StringOffset TaskDescriptionOffset)
		{
			builder.AddOffset(7, TaskDescriptionOffset.Value, 0);
		}

		// Token: 0x06004595 RID: 17813 RVA: 0x000DFB24 File Offset: 0x000DDF24
		public static void AddTaskVar(FlatBufferBuilder builder, StringOffset TaskVarOffset)
		{
			builder.AddOffset(8, TaskVarOffset.Value, 0);
		}

		// Token: 0x06004596 RID: 17814 RVA: 0x000DFB35 File Offset: 0x000DDF35
		public static void AddTaskVar2(FlatBufferBuilder builder, StringOffset TaskVar2Offset)
		{
			builder.AddOffset(9, TaskVar2Offset.Value, 0);
		}

		// Token: 0x06004597 RID: 17815 RVA: 0x000DFB47 File Offset: 0x000DDF47
		public static void AddConsumeScore(FlatBufferBuilder builder, StringOffset ConsumeScoreOffset)
		{
			builder.AddOffset(10, ConsumeScoreOffset.Value, 0);
		}

		// Token: 0x06004598 RID: 17816 RVA: 0x000DFB59 File Offset: 0x000DDF59
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(11, NameOffset.Value, 0);
		}

		// Token: 0x06004599 RID: 17817 RVA: 0x000DFB6B File Offset: 0x000DDF6B
		public static void AddTaskVarProgressName(FlatBufferBuilder builder, StringOffset TaskVarProgressNameOffset)
		{
			builder.AddOffset(12, TaskVarProgressNameOffset.Value, 0);
		}

		// Token: 0x0600459A RID: 17818 RVA: 0x000DFB7D File Offset: 0x000DDF7D
		public static void AddPlayerLevelLimit(FlatBufferBuilder builder, int PlayerLevelLimit)
		{
			builder.AddInt(13, PlayerLevelLimit, 0);
		}

		// Token: 0x0600459B RID: 17819 RVA: 0x000DFB89 File Offset: 0x000DDF89
		public static void AddAccountDailySubmitLimit(FlatBufferBuilder builder, int AccountDailySubmitLimit)
		{
			builder.AddInt(14, AccountDailySubmitLimit, 0);
		}

		// Token: 0x0600459C RID: 17820 RVA: 0x000DFB95 File Offset: 0x000DDF95
		public static void AddAccountTotalSubmitLimit(FlatBufferBuilder builder, int AccountTotalSubmitLimit)
		{
			builder.AddInt(15, AccountTotalSubmitLimit, 0);
		}

		// Token: 0x0600459D RID: 17821 RVA: 0x000DFBA1 File Offset: 0x000DDFA1
		public static void AddResetType(FlatBufferBuilder builder, int ResetType)
		{
			builder.AddInt(16, ResetType, 0);
		}

		// Token: 0x0600459E RID: 17822 RVA: 0x000DFBAD File Offset: 0x000DDFAD
		public static void AddCantAccept(FlatBufferBuilder builder, int CantAccept)
		{
			builder.AddInt(17, CantAccept, 0);
		}

		// Token: 0x0600459F RID: 17823 RVA: 0x000DFBB9 File Offset: 0x000DDFB9
		public static void AddEventType(FlatBufferBuilder builder, int EventType)
		{
			builder.AddInt(18, EventType, 0);
		}

		// Token: 0x060045A0 RID: 17824 RVA: 0x000DFBC5 File Offset: 0x000DDFC5
		public static void AddSubEventType(FlatBufferBuilder builder, int SubEventType)
		{
			builder.AddInt(19, SubEventType, 0);
		}

		// Token: 0x060045A1 RID: 17825 RVA: 0x000DFBD1 File Offset: 0x000DDFD1
		public static void AddAccountWeeklySubmitLimit(FlatBufferBuilder builder, int AccountWeeklySubmitLimit)
		{
			builder.AddInt(20, AccountWeeklySubmitLimit, 0);
		}

		// Token: 0x060045A2 RID: 17826 RVA: 0x000DFBDD File Offset: 0x000DDFDD
		public static void AddAccountTask(FlatBufferBuilder builder, int AccountTask)
		{
			builder.AddInt(21, AccountTask, 0);
		}

		// Token: 0x060045A3 RID: 17827 RVA: 0x000DFBEC File Offset: 0x000DDFEC
		public static Offset<OpActivityTaskTable> EndOpActivityTaskTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<OpActivityTaskTable>(value);
		}

		// Token: 0x060045A4 RID: 17828 RVA: 0x000DFC06 File Offset: 0x000DE006
		public static void FinishOpActivityTaskTableBuffer(FlatBufferBuilder builder, Offset<OpActivityTaskTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040019EA RID: 6634
		private Table __p = new Table();

		// Token: 0x02000543 RID: 1347
		public enum eCrypt
		{
			// Token: 0x040019EC RID: 6636
			code = -1204541283
		}
	}
}
