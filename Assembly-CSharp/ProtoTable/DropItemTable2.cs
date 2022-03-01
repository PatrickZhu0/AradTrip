using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000389 RID: 905
	public class DropItemTable2 : IFlatbufferObject
	{
		// Token: 0x170008A2 RID: 2210
		// (get) Token: 0x0600270D RID: 9997 RVA: 0x00096E60 File Offset: 0x00095260
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600270E RID: 9998 RVA: 0x00096E6D File Offset: 0x0009526D
		public static DropItemTable2 GetRootAsDropItemTable2(ByteBuffer _bb)
		{
			return DropItemTable2.GetRootAsDropItemTable2(_bb, new DropItemTable2());
		}

		// Token: 0x0600270F RID: 9999 RVA: 0x00096E7A File Offset: 0x0009527A
		public static DropItemTable2 GetRootAsDropItemTable2(ByteBuffer _bb, DropItemTable2 obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002710 RID: 10000 RVA: 0x00096E96 File Offset: 0x00095296
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002711 RID: 10001 RVA: 0x00096EB0 File Offset: 0x000952B0
		public DropItemTable2 __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008A3 RID: 2211
		// (get) Token: 0x06002712 RID: 10002 RVA: 0x00096EBC File Offset: 0x000952BC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008A4 RID: 2212
		// (get) Token: 0x06002713 RID: 10003 RVA: 0x00096F08 File Offset: 0x00095308
		public int GroupID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002714 RID: 10004 RVA: 0x00096F54 File Offset: 0x00095354
		public int ChooseNumSetArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008A5 RID: 2213
		// (get) Token: 0x06002715 RID: 10005 RVA: 0x00096FA0 File Offset: 0x000953A0
		public int ChooseNumSetLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002716 RID: 10006 RVA: 0x00096FD2 File Offset: 0x000953D2
		public ArraySegment<byte>? GetChooseNumSetBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170008A6 RID: 2214
		// (get) Token: 0x06002717 RID: 10007 RVA: 0x00096FE0 File Offset: 0x000953E0
		public FlatBufferArray<int> ChooseNumSet
		{
			get
			{
				if (this.ChooseNumSetValue == null)
				{
					this.ChooseNumSetValue = new FlatBufferArray<int>(new Func<int, int>(this.ChooseNumSetArray), this.ChooseNumSetLength);
				}
				return this.ChooseNumSetValue;
			}
		}

		// Token: 0x06002718 RID: 10008 RVA: 0x00097010 File Offset: 0x00095410
		public int NumProbSetArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008A7 RID: 2215
		// (get) Token: 0x06002719 RID: 10009 RVA: 0x00097060 File Offset: 0x00095460
		public int NumProbSetLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600271A RID: 10010 RVA: 0x00097093 File Offset: 0x00095493
		public ArraySegment<byte>? GetNumProbSetBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170008A8 RID: 2216
		// (get) Token: 0x0600271B RID: 10011 RVA: 0x000970A2 File Offset: 0x000954A2
		public FlatBufferArray<int> NumProbSet
		{
			get
			{
				if (this.NumProbSetValue == null)
				{
					this.NumProbSetValue = new FlatBufferArray<int>(new Func<int, int>(this.NumProbSetArray), this.NumProbSetLength);
				}
				return this.NumProbSetValue;
			}
		}

		// Token: 0x170008A9 RID: 2217
		// (get) Token: 0x0600271C RID: 10012 RVA: 0x000970D4 File Offset: 0x000954D4
		public int DataType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008AA RID: 2218
		// (get) Token: 0x0600271D RID: 10013 RVA: 0x00097120 File Offset: 0x00095520
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008AB RID: 2219
		// (get) Token: 0x0600271E RID: 10014 RVA: 0x0009716C File Offset: 0x0009556C
		public int ItemProb
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600271F RID: 10015 RVA: 0x000971B8 File Offset: 0x000955B8
		public int ItemNumArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008AC RID: 2220
		// (get) Token: 0x06002720 RID: 10016 RVA: 0x00097208 File Offset: 0x00095608
		public int ItemNumLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002721 RID: 10017 RVA: 0x0009723B File Offset: 0x0009563B
		public ArraySegment<byte>? GetItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170008AD RID: 2221
		// (get) Token: 0x06002722 RID: 10018 RVA: 0x0009724A File Offset: 0x0009564A
		public FlatBufferArray<int> ItemNum
		{
			get
			{
				if (this.ItemNumValue == null)
				{
					this.ItemNumValue = new FlatBufferArray<int>(new Func<int, int>(this.ItemNumArray), this.ItemNumLength);
				}
				return this.ItemNumValue;
			}
		}

		// Token: 0x170008AE RID: 2222
		// (get) Token: 0x06002723 RID: 10019 RVA: 0x0009727C File Offset: 0x0009567C
		public int IsRareControl
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008AF RID: 2223
		// (get) Token: 0x06002724 RID: 10020 RVA: 0x000972C8 File Offset: 0x000956C8
		public int TaskID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002725 RID: 10021 RVA: 0x00097314 File Offset: 0x00095714
		public int OccuAdditionArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008B0 RID: 2224
		// (get) Token: 0x06002726 RID: 10022 RVA: 0x00097364 File Offset: 0x00095764
		public int OccuAdditionLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002727 RID: 10023 RVA: 0x00097397 File Offset: 0x00095797
		public ArraySegment<byte>? GetOccuAdditionBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170008B1 RID: 2225
		// (get) Token: 0x06002728 RID: 10024 RVA: 0x000973A6 File Offset: 0x000957A6
		public FlatBufferArray<int> OccuAddition
		{
			get
			{
				if (this.OccuAdditionValue == null)
				{
					this.OccuAdditionValue = new FlatBufferArray<int>(new Func<int, int>(this.OccuAdditionArray), this.OccuAdditionLength);
				}
				return this.OccuAdditionValue;
			}
		}

		// Token: 0x170008B2 RID: 2226
		// (get) Token: 0x06002729 RID: 10025 RVA: 0x000973D8 File Offset: 0x000957D8
		public int AdditionProb
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008B3 RID: 2227
		// (get) Token: 0x0600272A RID: 10026 RVA: 0x00097424 File Offset: 0x00095824
		public int DropItemType
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008B4 RID: 2228
		// (get) Token: 0x0600272B RID: 10027 RVA: 0x00097470 File Offset: 0x00095870
		public int DropNotice
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008B5 RID: 2229
		// (get) Token: 0x0600272C RID: 10028 RVA: 0x000974BC File Offset: 0x000958BC
		public string Text
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600272D RID: 10029 RVA: 0x000974FF File Offset: 0x000958FF
		public ArraySegment<byte>? GetTextBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x170008B6 RID: 2230
		// (get) Token: 0x0600272E RID: 10030 RVA: 0x00097510 File Offset: 0x00095910
		public int ActivityID
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008B7 RID: 2231
		// (get) Token: 0x0600272F RID: 10031 RVA: 0x0009755C File Offset: 0x0009595C
		public string Mark
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002730 RID: 10032 RVA: 0x0009759F File Offset: 0x0009599F
		public ArraySegment<byte>? GetMarkBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x170008B8 RID: 2232
		// (get) Token: 0x06002731 RID: 10033 RVA: 0x000975B0 File Offset: 0x000959B0
		public string Vip
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002732 RID: 10034 RVA: 0x000975F3 File Offset: 0x000959F3
		public ArraySegment<byte>? GetVipBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170008B9 RID: 2233
		// (get) Token: 0x06002733 RID: 10035 RVA: 0x00097604 File Offset: 0x00095A04
		public int VipDropLimitId
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008BA RID: 2234
		// (get) Token: 0x06002734 RID: 10036 RVA: 0x00097650 File Offset: 0x00095A50
		public int MonthCard
		{
			get
			{
				int num = this.__p.__offset(42);
				return (num == 0) ? 0 : (845765760 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002735 RID: 10037 RVA: 0x0009769C File Offset: 0x00095A9C
		public static Offset<DropItemTable2> CreateDropItemTable2(FlatBufferBuilder builder, int ID = 0, int GroupID = 0, VectorOffset ChooseNumSetOffset = default(VectorOffset), VectorOffset NumProbSetOffset = default(VectorOffset), int DataType = 0, int ItemID = 0, int ItemProb = 0, VectorOffset ItemNumOffset = default(VectorOffset), int IsRareControl = 0, int TaskID = 0, VectorOffset OccuAdditionOffset = default(VectorOffset), int AdditionProb = 0, int DropItemType = 0, int DropNotice = 0, StringOffset TextOffset = default(StringOffset), int ActivityID = 0, StringOffset MarkOffset = default(StringOffset), StringOffset VipOffset = default(StringOffset), int VipDropLimitId = 0, int MonthCard = 0)
		{
			builder.StartObject(20);
			DropItemTable2.AddMonthCard(builder, MonthCard);
			DropItemTable2.AddVipDropLimitId(builder, VipDropLimitId);
			DropItemTable2.AddVip(builder, VipOffset);
			DropItemTable2.AddMark(builder, MarkOffset);
			DropItemTable2.AddActivityID(builder, ActivityID);
			DropItemTable2.AddText(builder, TextOffset);
			DropItemTable2.AddDropNotice(builder, DropNotice);
			DropItemTable2.AddDropItemType(builder, DropItemType);
			DropItemTable2.AddAdditionProb(builder, AdditionProb);
			DropItemTable2.AddOccuAddition(builder, OccuAdditionOffset);
			DropItemTable2.AddTaskID(builder, TaskID);
			DropItemTable2.AddIsRareControl(builder, IsRareControl);
			DropItemTable2.AddItemNum(builder, ItemNumOffset);
			DropItemTable2.AddItemProb(builder, ItemProb);
			DropItemTable2.AddItemID(builder, ItemID);
			DropItemTable2.AddDataType(builder, DataType);
			DropItemTable2.AddNumProbSet(builder, NumProbSetOffset);
			DropItemTable2.AddChooseNumSet(builder, ChooseNumSetOffset);
			DropItemTable2.AddGroupID(builder, GroupID);
			DropItemTable2.AddID(builder, ID);
			return DropItemTable2.EndDropItemTable2(builder);
		}

		// Token: 0x06002736 RID: 10038 RVA: 0x00097754 File Offset: 0x00095B54
		public static void StartDropItemTable2(FlatBufferBuilder builder)
		{
			builder.StartObject(20);
		}

		// Token: 0x06002737 RID: 10039 RVA: 0x0009775E File Offset: 0x00095B5E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002738 RID: 10040 RVA: 0x00097769 File Offset: 0x00095B69
		public static void AddGroupID(FlatBufferBuilder builder, int GroupID)
		{
			builder.AddInt(1, GroupID, 0);
		}

		// Token: 0x06002739 RID: 10041 RVA: 0x00097774 File Offset: 0x00095B74
		public static void AddChooseNumSet(FlatBufferBuilder builder, VectorOffset ChooseNumSetOffset)
		{
			builder.AddOffset(2, ChooseNumSetOffset.Value, 0);
		}

		// Token: 0x0600273A RID: 10042 RVA: 0x00097788 File Offset: 0x00095B88
		public static VectorOffset CreateChooseNumSetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600273B RID: 10043 RVA: 0x000977C5 File Offset: 0x00095BC5
		public static void StartChooseNumSetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600273C RID: 10044 RVA: 0x000977D0 File Offset: 0x00095BD0
		public static void AddNumProbSet(FlatBufferBuilder builder, VectorOffset NumProbSetOffset)
		{
			builder.AddOffset(3, NumProbSetOffset.Value, 0);
		}

		// Token: 0x0600273D RID: 10045 RVA: 0x000977E4 File Offset: 0x00095BE4
		public static VectorOffset CreateNumProbSetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600273E RID: 10046 RVA: 0x00097821 File Offset: 0x00095C21
		public static void StartNumProbSetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600273F RID: 10047 RVA: 0x0009782C File Offset: 0x00095C2C
		public static void AddDataType(FlatBufferBuilder builder, int DataType)
		{
			builder.AddInt(4, DataType, 0);
		}

		// Token: 0x06002740 RID: 10048 RVA: 0x00097837 File Offset: 0x00095C37
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(5, ItemID, 0);
		}

		// Token: 0x06002741 RID: 10049 RVA: 0x00097842 File Offset: 0x00095C42
		public static void AddItemProb(FlatBufferBuilder builder, int ItemProb)
		{
			builder.AddInt(6, ItemProb, 0);
		}

		// Token: 0x06002742 RID: 10050 RVA: 0x0009784D File Offset: 0x00095C4D
		public static void AddItemNum(FlatBufferBuilder builder, VectorOffset ItemNumOffset)
		{
			builder.AddOffset(7, ItemNumOffset.Value, 0);
		}

		// Token: 0x06002743 RID: 10051 RVA: 0x00097860 File Offset: 0x00095C60
		public static VectorOffset CreateItemNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002744 RID: 10052 RVA: 0x0009789D File Offset: 0x00095C9D
		public static void StartItemNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002745 RID: 10053 RVA: 0x000978A8 File Offset: 0x00095CA8
		public static void AddIsRareControl(FlatBufferBuilder builder, int IsRareControl)
		{
			builder.AddInt(8, IsRareControl, 0);
		}

		// Token: 0x06002746 RID: 10054 RVA: 0x000978B3 File Offset: 0x00095CB3
		public static void AddTaskID(FlatBufferBuilder builder, int TaskID)
		{
			builder.AddInt(9, TaskID, 0);
		}

		// Token: 0x06002747 RID: 10055 RVA: 0x000978BF File Offset: 0x00095CBF
		public static void AddOccuAddition(FlatBufferBuilder builder, VectorOffset OccuAdditionOffset)
		{
			builder.AddOffset(10, OccuAdditionOffset.Value, 0);
		}

		// Token: 0x06002748 RID: 10056 RVA: 0x000978D4 File Offset: 0x00095CD4
		public static VectorOffset CreateOccuAdditionVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002749 RID: 10057 RVA: 0x00097911 File Offset: 0x00095D11
		public static void StartOccuAdditionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600274A RID: 10058 RVA: 0x0009791C File Offset: 0x00095D1C
		public static void AddAdditionProb(FlatBufferBuilder builder, int AdditionProb)
		{
			builder.AddInt(11, AdditionProb, 0);
		}

		// Token: 0x0600274B RID: 10059 RVA: 0x00097928 File Offset: 0x00095D28
		public static void AddDropItemType(FlatBufferBuilder builder, int DropItemType)
		{
			builder.AddInt(12, DropItemType, 0);
		}

		// Token: 0x0600274C RID: 10060 RVA: 0x00097934 File Offset: 0x00095D34
		public static void AddDropNotice(FlatBufferBuilder builder, int DropNotice)
		{
			builder.AddInt(13, DropNotice, 0);
		}

		// Token: 0x0600274D RID: 10061 RVA: 0x00097940 File Offset: 0x00095D40
		public static void AddText(FlatBufferBuilder builder, StringOffset TextOffset)
		{
			builder.AddOffset(14, TextOffset.Value, 0);
		}

		// Token: 0x0600274E RID: 10062 RVA: 0x00097952 File Offset: 0x00095D52
		public static void AddActivityID(FlatBufferBuilder builder, int ActivityID)
		{
			builder.AddInt(15, ActivityID, 0);
		}

		// Token: 0x0600274F RID: 10063 RVA: 0x0009795E File Offset: 0x00095D5E
		public static void AddMark(FlatBufferBuilder builder, StringOffset MarkOffset)
		{
			builder.AddOffset(16, MarkOffset.Value, 0);
		}

		// Token: 0x06002750 RID: 10064 RVA: 0x00097970 File Offset: 0x00095D70
		public static void AddVip(FlatBufferBuilder builder, StringOffset VipOffset)
		{
			builder.AddOffset(17, VipOffset.Value, 0);
		}

		// Token: 0x06002751 RID: 10065 RVA: 0x00097982 File Offset: 0x00095D82
		public static void AddVipDropLimitId(FlatBufferBuilder builder, int VipDropLimitId)
		{
			builder.AddInt(18, VipDropLimitId, 0);
		}

		// Token: 0x06002752 RID: 10066 RVA: 0x0009798E File Offset: 0x00095D8E
		public static void AddMonthCard(FlatBufferBuilder builder, int MonthCard)
		{
			builder.AddInt(19, MonthCard, 0);
		}

		// Token: 0x06002753 RID: 10067 RVA: 0x0009799C File Offset: 0x00095D9C
		public static Offset<DropItemTable2> EndDropItemTable2(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DropItemTable2>(value);
		}

		// Token: 0x06002754 RID: 10068 RVA: 0x000979B6 File Offset: 0x00095DB6
		public static void FinishDropItemTable2Buffer(FlatBufferBuilder builder, Offset<DropItemTable2> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011B7 RID: 4535
		private Table __p = new Table();

		// Token: 0x040011B8 RID: 4536
		private FlatBufferArray<int> ChooseNumSetValue;

		// Token: 0x040011B9 RID: 4537
		private FlatBufferArray<int> NumProbSetValue;

		// Token: 0x040011BA RID: 4538
		private FlatBufferArray<int> ItemNumValue;

		// Token: 0x040011BB RID: 4539
		private FlatBufferArray<int> OccuAdditionValue;

		// Token: 0x0200038A RID: 906
		public enum eCrypt
		{
			// Token: 0x040011BD RID: 4541
			code = 845765760
		}
	}
}
