using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000282 RID: 642
	public class ActivityMonsterTable : IFlatbufferObject
	{
		// Token: 0x17000302 RID: 770
		// (get) Token: 0x06001656 RID: 5718 RVA: 0x0006F18C File Offset: 0x0006D58C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001657 RID: 5719 RVA: 0x0006F199 File Offset: 0x0006D599
		public static ActivityMonsterTable GetRootAsActivityMonsterTable(ByteBuffer _bb)
		{
			return ActivityMonsterTable.GetRootAsActivityMonsterTable(_bb, new ActivityMonsterTable());
		}

		// Token: 0x06001658 RID: 5720 RVA: 0x0006F1A6 File Offset: 0x0006D5A6
		public static ActivityMonsterTable GetRootAsActivityMonsterTable(ByteBuffer _bb, ActivityMonsterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001659 RID: 5721 RVA: 0x0006F1C2 File Offset: 0x0006D5C2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600165A RID: 5722 RVA: 0x0006F1DC File Offset: 0x0006D5DC
		public ActivityMonsterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000303 RID: 771
		// (get) Token: 0x0600165B RID: 5723 RVA: 0x0006F1E8 File Offset: 0x0006D5E8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000304 RID: 772
		// (get) Token: 0x0600165C RID: 5724 RVA: 0x0006F234 File Offset: 0x0006D634
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600165D RID: 5725 RVA: 0x0006F276 File Offset: 0x0006D676
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000305 RID: 773
		// (get) Token: 0x0600165E RID: 5726 RVA: 0x0006F284 File Offset: 0x0006D684
		public string StartDate
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600165F RID: 5727 RVA: 0x0006F2C6 File Offset: 0x0006D6C6
		public ArraySegment<byte>? GetStartDateBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000306 RID: 774
		// (get) Token: 0x06001660 RID: 5728 RVA: 0x0006F2D4 File Offset: 0x0006D6D4
		public string EndDate
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001661 RID: 5729 RVA: 0x0006F317 File Offset: 0x0006D717
		public ArraySegment<byte>? GetEndDateBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000307 RID: 775
		// (get) Token: 0x06001662 RID: 5730 RVA: 0x0006F328 File Offset: 0x0006D728
		public string StartTime
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001663 RID: 5731 RVA: 0x0006F36B File Offset: 0x0006D76B
		public ArraySegment<byte>? GetStartTimeBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000308 RID: 776
		// (get) Token: 0x06001664 RID: 5732 RVA: 0x0006F37C File Offset: 0x0006D77C
		public int PerRollMonsterNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000309 RID: 777
		// (get) Token: 0x06001665 RID: 5733 RVA: 0x0006F3C8 File Offset: 0x0006D7C8
		public int PerRollDurningSec
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700030A RID: 778
		// (get) Token: 0x06001666 RID: 5734 RVA: 0x0006F414 File Offset: 0x0006D814
		public int PointType
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700030B RID: 779
		// (get) Token: 0x06001667 RID: 5735 RVA: 0x0006F460 File Offset: 0x0006D860
		public int GroupID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700030C RID: 780
		// (get) Token: 0x06001668 RID: 5736 RVA: 0x0006F4AC File Offset: 0x0006D8AC
		public int Prob
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001669 RID: 5737 RVA: 0x0006F4F8 File Offset: 0x0006D8F8
		public string DropIDsArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x1700030D RID: 781
		// (get) Token: 0x0600166A RID: 5738 RVA: 0x0006F540 File Offset: 0x0006D940
		public int DropIDsLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x1700030E RID: 782
		// (get) Token: 0x0600166B RID: 5739 RVA: 0x0006F573 File Offset: 0x0006D973
		public FlatBufferArray<string> DropIDs
		{
			get
			{
				if (this.DropIDsValue == null)
				{
					this.DropIDsValue = new FlatBufferArray<string>(new Func<int, string>(this.DropIDsArray), this.DropIDsLength);
				}
				return this.DropIDsValue;
			}
		}

		// Token: 0x1700030F RID: 783
		// (get) Token: 0x0600166C RID: 5740 RVA: 0x0006F5A4 File Offset: 0x0006D9A4
		public string DropItems
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600166D RID: 5741 RVA: 0x0006F5E7 File Offset: 0x0006D9E7
		public ArraySegment<byte>? GetDropItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x0600166E RID: 5742 RVA: 0x0006F5F8 File Offset: 0x0006D9F8
		public int StartNoticeArray(int j)
		{
			int num = this.__p.__offset(28);
			return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000310 RID: 784
		// (get) Token: 0x0600166F RID: 5743 RVA: 0x0006F648 File Offset: 0x0006DA48
		public int StartNoticeLength
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001670 RID: 5744 RVA: 0x0006F67B File Offset: 0x0006DA7B
		public ArraySegment<byte>? GetStartNoticeBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x17000311 RID: 785
		// (get) Token: 0x06001671 RID: 5745 RVA: 0x0006F68A File Offset: 0x0006DA8A
		public FlatBufferArray<int> StartNotice
		{
			get
			{
				if (this.StartNoticeValue == null)
				{
					this.StartNoticeValue = new FlatBufferArray<int>(new Func<int, int>(this.StartNoticeArray), this.StartNoticeLength);
				}
				return this.StartNoticeValue;
			}
		}

		// Token: 0x06001672 RID: 5746 RVA: 0x0006F6BC File Offset: 0x0006DABC
		public int KillNoticeArray(int j)
		{
			int num = this.__p.__offset(30);
			return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000312 RID: 786
		// (get) Token: 0x06001673 RID: 5747 RVA: 0x0006F70C File Offset: 0x0006DB0C
		public int KillNoticeLength
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001674 RID: 5748 RVA: 0x0006F73F File Offset: 0x0006DB3F
		public ArraySegment<byte>? GetKillNoticeBytes()
		{
			return this.__p.__vector_as_arraysegment(30);
		}

		// Token: 0x17000313 RID: 787
		// (get) Token: 0x06001675 RID: 5749 RVA: 0x0006F74E File Offset: 0x0006DB4E
		public FlatBufferArray<int> KillNotice
		{
			get
			{
				if (this.KillNoticeValue == null)
				{
					this.KillNoticeValue = new FlatBufferArray<int>(new Func<int, int>(this.KillNoticeArray), this.KillNoticeLength);
				}
				return this.KillNoticeValue;
			}
		}

		// Token: 0x06001676 RID: 5750 RVA: 0x0006F780 File Offset: 0x0006DB80
		public int ClearNoticeArray(int j)
		{
			int num = this.__p.__offset(32);
			return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000314 RID: 788
		// (get) Token: 0x06001677 RID: 5751 RVA: 0x0006F7D0 File Offset: 0x0006DBD0
		public int ClearNoticeLength
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001678 RID: 5752 RVA: 0x0006F803 File Offset: 0x0006DC03
		public ArraySegment<byte>? GetClearNoticeBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x06001679 RID: 5753 RVA: 0x0006F812 File Offset: 0x0006DC12
		public FlatBufferArray<int> ClearNotice
		{
			get
			{
				if (this.ClearNoticeValue == null)
				{
					this.ClearNoticeValue = new FlatBufferArray<int>(new Func<int, int>(this.ClearNoticeArray), this.ClearNoticeLength);
				}
				return this.ClearNoticeValue;
			}
		}

		// Token: 0x0600167A RID: 5754 RVA: 0x0006F844 File Offset: 0x0006DC44
		public int OverNoticeArray(int j)
		{
			int num = this.__p.__offset(34);
			return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x0600167B RID: 5755 RVA: 0x0006F894 File Offset: 0x0006DC94
		public int OverNoticeLength
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600167C RID: 5756 RVA: 0x0006F8C7 File Offset: 0x0006DCC7
		public ArraySegment<byte>? GetOverNoticeBytes()
		{
			return this.__p.__vector_as_arraysegment(34);
		}

		// Token: 0x17000317 RID: 791
		// (get) Token: 0x0600167D RID: 5757 RVA: 0x0006F8D6 File Offset: 0x0006DCD6
		public FlatBufferArray<int> OverNotice
		{
			get
			{
				if (this.OverNoticeValue == null)
				{
					this.OverNoticeValue = new FlatBufferArray<int>(new Func<int, int>(this.OverNoticeArray), this.OverNoticeLength);
				}
				return this.OverNoticeValue;
			}
		}

		// Token: 0x0600167E RID: 5758 RVA: 0x0006F908 File Offset: 0x0006DD08
		public int NeedDungeonLevelArray(int j)
		{
			int num = this.__p.__offset(36);
			return (num == 0) ? 0 : (322105103 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000318 RID: 792
		// (get) Token: 0x0600167F RID: 5759 RVA: 0x0006F958 File Offset: 0x0006DD58
		public int NeedDungeonLevelLength
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001680 RID: 5760 RVA: 0x0006F98B File Offset: 0x0006DD8B
		public ArraySegment<byte>? GetNeedDungeonLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x17000319 RID: 793
		// (get) Token: 0x06001681 RID: 5761 RVA: 0x0006F99A File Offset: 0x0006DD9A
		public FlatBufferArray<int> NeedDungeonLevel
		{
			get
			{
				if (this.NeedDungeonLevelValue == null)
				{
					this.NeedDungeonLevelValue = new FlatBufferArray<int>(new Func<int, int>(this.NeedDungeonLevelArray), this.NeedDungeonLevelLength);
				}
				return this.NeedDungeonLevelValue;
			}
		}

		// Token: 0x06001682 RID: 5762 RVA: 0x0006F9CC File Offset: 0x0006DDCC
		public static Offset<ActivityMonsterTable> CreateActivityMonsterTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset StartDateOffset = default(StringOffset), StringOffset EndDateOffset = default(StringOffset), StringOffset StartTimeOffset = default(StringOffset), int PerRollMonsterNum = 0, int PerRollDurningSec = 0, int PointType = 0, int GroupID = 0, int Prob = 0, VectorOffset DropIDsOffset = default(VectorOffset), StringOffset DropItemsOffset = default(StringOffset), VectorOffset StartNoticeOffset = default(VectorOffset), VectorOffset KillNoticeOffset = default(VectorOffset), VectorOffset ClearNoticeOffset = default(VectorOffset), VectorOffset OverNoticeOffset = default(VectorOffset), VectorOffset NeedDungeonLevelOffset = default(VectorOffset))
		{
			builder.StartObject(17);
			ActivityMonsterTable.AddNeedDungeonLevel(builder, NeedDungeonLevelOffset);
			ActivityMonsterTable.AddOverNotice(builder, OverNoticeOffset);
			ActivityMonsterTable.AddClearNotice(builder, ClearNoticeOffset);
			ActivityMonsterTable.AddKillNotice(builder, KillNoticeOffset);
			ActivityMonsterTable.AddStartNotice(builder, StartNoticeOffset);
			ActivityMonsterTable.AddDropItems(builder, DropItemsOffset);
			ActivityMonsterTable.AddDropIDs(builder, DropIDsOffset);
			ActivityMonsterTable.AddProb(builder, Prob);
			ActivityMonsterTable.AddGroupID(builder, GroupID);
			ActivityMonsterTable.AddPointType(builder, PointType);
			ActivityMonsterTable.AddPerRollDurningSec(builder, PerRollDurningSec);
			ActivityMonsterTable.AddPerRollMonsterNum(builder, PerRollMonsterNum);
			ActivityMonsterTable.AddStartTime(builder, StartTimeOffset);
			ActivityMonsterTable.AddEndDate(builder, EndDateOffset);
			ActivityMonsterTable.AddStartDate(builder, StartDateOffset);
			ActivityMonsterTable.AddName(builder, NameOffset);
			ActivityMonsterTable.AddID(builder, ID);
			return ActivityMonsterTable.EndActivityMonsterTable(builder);
		}

		// Token: 0x06001683 RID: 5763 RVA: 0x0006FA6C File Offset: 0x0006DE6C
		public static void StartActivityMonsterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(17);
		}

		// Token: 0x06001684 RID: 5764 RVA: 0x0006FA76 File Offset: 0x0006DE76
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001685 RID: 5765 RVA: 0x0006FA81 File Offset: 0x0006DE81
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001686 RID: 5766 RVA: 0x0006FA92 File Offset: 0x0006DE92
		public static void AddStartDate(FlatBufferBuilder builder, StringOffset StartDateOffset)
		{
			builder.AddOffset(2, StartDateOffset.Value, 0);
		}

		// Token: 0x06001687 RID: 5767 RVA: 0x0006FAA3 File Offset: 0x0006DEA3
		public static void AddEndDate(FlatBufferBuilder builder, StringOffset EndDateOffset)
		{
			builder.AddOffset(3, EndDateOffset.Value, 0);
		}

		// Token: 0x06001688 RID: 5768 RVA: 0x0006FAB4 File Offset: 0x0006DEB4
		public static void AddStartTime(FlatBufferBuilder builder, StringOffset StartTimeOffset)
		{
			builder.AddOffset(4, StartTimeOffset.Value, 0);
		}

		// Token: 0x06001689 RID: 5769 RVA: 0x0006FAC5 File Offset: 0x0006DEC5
		public static void AddPerRollMonsterNum(FlatBufferBuilder builder, int PerRollMonsterNum)
		{
			builder.AddInt(5, PerRollMonsterNum, 0);
		}

		// Token: 0x0600168A RID: 5770 RVA: 0x0006FAD0 File Offset: 0x0006DED0
		public static void AddPerRollDurningSec(FlatBufferBuilder builder, int PerRollDurningSec)
		{
			builder.AddInt(6, PerRollDurningSec, 0);
		}

		// Token: 0x0600168B RID: 5771 RVA: 0x0006FADB File Offset: 0x0006DEDB
		public static void AddPointType(FlatBufferBuilder builder, int PointType)
		{
			builder.AddInt(7, PointType, 0);
		}

		// Token: 0x0600168C RID: 5772 RVA: 0x0006FAE6 File Offset: 0x0006DEE6
		public static void AddGroupID(FlatBufferBuilder builder, int GroupID)
		{
			builder.AddInt(8, GroupID, 0);
		}

		// Token: 0x0600168D RID: 5773 RVA: 0x0006FAF1 File Offset: 0x0006DEF1
		public static void AddProb(FlatBufferBuilder builder, int Prob)
		{
			builder.AddInt(9, Prob, 0);
		}

		// Token: 0x0600168E RID: 5774 RVA: 0x0006FAFD File Offset: 0x0006DEFD
		public static void AddDropIDs(FlatBufferBuilder builder, VectorOffset DropIDsOffset)
		{
			builder.AddOffset(10, DropIDsOffset.Value, 0);
		}

		// Token: 0x0600168F RID: 5775 RVA: 0x0006FB10 File Offset: 0x0006DF10
		public static VectorOffset CreateDropIDsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06001690 RID: 5776 RVA: 0x0006FB56 File Offset: 0x0006DF56
		public static void StartDropIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001691 RID: 5777 RVA: 0x0006FB61 File Offset: 0x0006DF61
		public static void AddDropItems(FlatBufferBuilder builder, StringOffset DropItemsOffset)
		{
			builder.AddOffset(11, DropItemsOffset.Value, 0);
		}

		// Token: 0x06001692 RID: 5778 RVA: 0x0006FB73 File Offset: 0x0006DF73
		public static void AddStartNotice(FlatBufferBuilder builder, VectorOffset StartNoticeOffset)
		{
			builder.AddOffset(12, StartNoticeOffset.Value, 0);
		}

		// Token: 0x06001693 RID: 5779 RVA: 0x0006FB88 File Offset: 0x0006DF88
		public static VectorOffset CreateStartNoticeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001694 RID: 5780 RVA: 0x0006FBC5 File Offset: 0x0006DFC5
		public static void StartStartNoticeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001695 RID: 5781 RVA: 0x0006FBD0 File Offset: 0x0006DFD0
		public static void AddKillNotice(FlatBufferBuilder builder, VectorOffset KillNoticeOffset)
		{
			builder.AddOffset(13, KillNoticeOffset.Value, 0);
		}

		// Token: 0x06001696 RID: 5782 RVA: 0x0006FBE4 File Offset: 0x0006DFE4
		public static VectorOffset CreateKillNoticeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001697 RID: 5783 RVA: 0x0006FC21 File Offset: 0x0006E021
		public static void StartKillNoticeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001698 RID: 5784 RVA: 0x0006FC2C File Offset: 0x0006E02C
		public static void AddClearNotice(FlatBufferBuilder builder, VectorOffset ClearNoticeOffset)
		{
			builder.AddOffset(14, ClearNoticeOffset.Value, 0);
		}

		// Token: 0x06001699 RID: 5785 RVA: 0x0006FC40 File Offset: 0x0006E040
		public static VectorOffset CreateClearNoticeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600169A RID: 5786 RVA: 0x0006FC7D File Offset: 0x0006E07D
		public static void StartClearNoticeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600169B RID: 5787 RVA: 0x0006FC88 File Offset: 0x0006E088
		public static void AddOverNotice(FlatBufferBuilder builder, VectorOffset OverNoticeOffset)
		{
			builder.AddOffset(15, OverNoticeOffset.Value, 0);
		}

		// Token: 0x0600169C RID: 5788 RVA: 0x0006FC9C File Offset: 0x0006E09C
		public static VectorOffset CreateOverNoticeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600169D RID: 5789 RVA: 0x0006FCD9 File Offset: 0x0006E0D9
		public static void StartOverNoticeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600169E RID: 5790 RVA: 0x0006FCE4 File Offset: 0x0006E0E4
		public static void AddNeedDungeonLevel(FlatBufferBuilder builder, VectorOffset NeedDungeonLevelOffset)
		{
			builder.AddOffset(16, NeedDungeonLevelOffset.Value, 0);
		}

		// Token: 0x0600169F RID: 5791 RVA: 0x0006FCF8 File Offset: 0x0006E0F8
		public static VectorOffset CreateNeedDungeonLevelVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060016A0 RID: 5792 RVA: 0x0006FD35 File Offset: 0x0006E135
		public static void StartNeedDungeonLevelVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060016A1 RID: 5793 RVA: 0x0006FD40 File Offset: 0x0006E140
		public static Offset<ActivityMonsterTable> EndActivityMonsterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ActivityMonsterTable>(value);
		}

		// Token: 0x060016A2 RID: 5794 RVA: 0x0006FD5A File Offset: 0x0006E15A
		public static void FinishActivityMonsterTableBuffer(FlatBufferBuilder builder, Offset<ActivityMonsterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DA9 RID: 3497
		private Table __p = new Table();

		// Token: 0x04000DAA RID: 3498
		private FlatBufferArray<string> DropIDsValue;

		// Token: 0x04000DAB RID: 3499
		private FlatBufferArray<int> StartNoticeValue;

		// Token: 0x04000DAC RID: 3500
		private FlatBufferArray<int> KillNoticeValue;

		// Token: 0x04000DAD RID: 3501
		private FlatBufferArray<int> ClearNoticeValue;

		// Token: 0x04000DAE RID: 3502
		private FlatBufferArray<int> OverNoticeValue;

		// Token: 0x04000DAF RID: 3503
		private FlatBufferArray<int> NeedDungeonLevelValue;

		// Token: 0x02000283 RID: 643
		public enum eCrypt
		{
			// Token: 0x04000DB1 RID: 3505
			code = 322105103
		}
	}
}
