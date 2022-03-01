using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000387 RID: 903
	public class DropItemTable : IFlatbufferObject
	{
		// Token: 0x1700088A RID: 2186
		// (get) Token: 0x060026C6 RID: 9926 RVA: 0x00096348 File Offset: 0x00094748
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060026C7 RID: 9927 RVA: 0x00096355 File Offset: 0x00094755
		public static DropItemTable GetRootAsDropItemTable(ByteBuffer _bb)
		{
			return DropItemTable.GetRootAsDropItemTable(_bb, new DropItemTable());
		}

		// Token: 0x060026C8 RID: 9928 RVA: 0x00096362 File Offset: 0x00094762
		public static DropItemTable GetRootAsDropItemTable(ByteBuffer _bb, DropItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060026C9 RID: 9929 RVA: 0x0009637E File Offset: 0x0009477E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060026CA RID: 9930 RVA: 0x00096398 File Offset: 0x00094798
		public DropItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700088B RID: 2187
		// (get) Token: 0x060026CB RID: 9931 RVA: 0x000963A4 File Offset: 0x000947A4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700088C RID: 2188
		// (get) Token: 0x060026CC RID: 9932 RVA: 0x000963F0 File Offset: 0x000947F0
		public int GroupID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060026CD RID: 9933 RVA: 0x0009643C File Offset: 0x0009483C
		public int ChooseNumSetArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700088D RID: 2189
		// (get) Token: 0x060026CE RID: 9934 RVA: 0x00096488 File Offset: 0x00094888
		public int ChooseNumSetLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060026CF RID: 9935 RVA: 0x000964BA File Offset: 0x000948BA
		public ArraySegment<byte>? GetChooseNumSetBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700088E RID: 2190
		// (get) Token: 0x060026D0 RID: 9936 RVA: 0x000964C8 File Offset: 0x000948C8
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

		// Token: 0x060026D1 RID: 9937 RVA: 0x000964F8 File Offset: 0x000948F8
		public int NumProbSetArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x060026D2 RID: 9938 RVA: 0x00096548 File Offset: 0x00094948
		public int NumProbSetLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060026D3 RID: 9939 RVA: 0x0009657B File Offset: 0x0009497B
		public ArraySegment<byte>? GetNumProbSetBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x060026D4 RID: 9940 RVA: 0x0009658A File Offset: 0x0009498A
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

		// Token: 0x17000891 RID: 2193
		// (get) Token: 0x060026D5 RID: 9941 RVA: 0x000965BC File Offset: 0x000949BC
		public int DataType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000892 RID: 2194
		// (get) Token: 0x060026D6 RID: 9942 RVA: 0x00096608 File Offset: 0x00094A08
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000893 RID: 2195
		// (get) Token: 0x060026D7 RID: 9943 RVA: 0x00096654 File Offset: 0x00094A54
		public int ItemProb
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060026D8 RID: 9944 RVA: 0x000966A0 File Offset: 0x00094AA0
		public int ItemNumArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000894 RID: 2196
		// (get) Token: 0x060026D9 RID: 9945 RVA: 0x000966F0 File Offset: 0x00094AF0
		public int ItemNumLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060026DA RID: 9946 RVA: 0x00096723 File Offset: 0x00094B23
		public ArraySegment<byte>? GetItemNumBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000895 RID: 2197
		// (get) Token: 0x060026DB RID: 9947 RVA: 0x00096732 File Offset: 0x00094B32
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

		// Token: 0x17000896 RID: 2198
		// (get) Token: 0x060026DC RID: 9948 RVA: 0x00096764 File Offset: 0x00094B64
		public int IsRareControl
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x060026DD RID: 9949 RVA: 0x000967B0 File Offset: 0x00094BB0
		public int TaskID
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060026DE RID: 9950 RVA: 0x000967FC File Offset: 0x00094BFC
		public int OccuAdditionArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x060026DF RID: 9951 RVA: 0x0009684C File Offset: 0x00094C4C
		public int OccuAdditionLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060026E0 RID: 9952 RVA: 0x0009687F File Offset: 0x00094C7F
		public ArraySegment<byte>? GetOccuAdditionBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x060026E1 RID: 9953 RVA: 0x0009688E File Offset: 0x00094C8E
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

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x060026E2 RID: 9954 RVA: 0x000968C0 File Offset: 0x00094CC0
		public int AdditionProb
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x060026E3 RID: 9955 RVA: 0x0009690C File Offset: 0x00094D0C
		public int DropItemType
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x060026E4 RID: 9956 RVA: 0x00096958 File Offset: 0x00094D58
		public int DropNotice
		{
			get
			{
				int num = this.__p.__offset(30);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x060026E5 RID: 9957 RVA: 0x000969A4 File Offset: 0x00094DA4
		public string Text
		{
			get
			{
				int num = this.__p.__offset(32);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026E6 RID: 9958 RVA: 0x000969E7 File Offset: 0x00094DE7
		public ArraySegment<byte>? GetTextBytes()
		{
			return this.__p.__vector_as_arraysegment(32);
		}

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x060026E7 RID: 9959 RVA: 0x000969F8 File Offset: 0x00094DF8
		public int ActivityID
		{
			get
			{
				int num = this.__p.__offset(34);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x060026E8 RID: 9960 RVA: 0x00096A44 File Offset: 0x00094E44
		public string Mark
		{
			get
			{
				int num = this.__p.__offset(36);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026E9 RID: 9961 RVA: 0x00096A87 File Offset: 0x00094E87
		public ArraySegment<byte>? GetMarkBytes()
		{
			return this.__p.__vector_as_arraysegment(36);
		}

		// Token: 0x170008A0 RID: 2208
		// (get) Token: 0x060026EA RID: 9962 RVA: 0x00096A98 File Offset: 0x00094E98
		public string Vip
		{
			get
			{
				int num = this.__p.__offset(38);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060026EB RID: 9963 RVA: 0x00096ADB File Offset: 0x00094EDB
		public ArraySegment<byte>? GetVipBytes()
		{
			return this.__p.__vector_as_arraysegment(38);
		}

		// Token: 0x170008A1 RID: 2209
		// (get) Token: 0x060026EC RID: 9964 RVA: 0x00096AEC File Offset: 0x00094EEC
		public int VipDropLimitId
		{
			get
			{
				int num = this.__p.__offset(40);
				return (num == 0) ? 0 : (-1086889122 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060026ED RID: 9965 RVA: 0x00096B38 File Offset: 0x00094F38
		public static Offset<DropItemTable> CreateDropItemTable(FlatBufferBuilder builder, int ID = 0, int GroupID = 0, VectorOffset ChooseNumSetOffset = default(VectorOffset), VectorOffset NumProbSetOffset = default(VectorOffset), int DataType = 0, int ItemID = 0, int ItemProb = 0, VectorOffset ItemNumOffset = default(VectorOffset), int IsRareControl = 0, int TaskID = 0, VectorOffset OccuAdditionOffset = default(VectorOffset), int AdditionProb = 0, int DropItemType = 0, int DropNotice = 0, StringOffset TextOffset = default(StringOffset), int ActivityID = 0, StringOffset MarkOffset = default(StringOffset), StringOffset VipOffset = default(StringOffset), int VipDropLimitId = 0)
		{
			builder.StartObject(19);
			DropItemTable.AddVipDropLimitId(builder, VipDropLimitId);
			DropItemTable.AddVip(builder, VipOffset);
			DropItemTable.AddMark(builder, MarkOffset);
			DropItemTable.AddActivityID(builder, ActivityID);
			DropItemTable.AddText(builder, TextOffset);
			DropItemTable.AddDropNotice(builder, DropNotice);
			DropItemTable.AddDropItemType(builder, DropItemType);
			DropItemTable.AddAdditionProb(builder, AdditionProb);
			DropItemTable.AddOccuAddition(builder, OccuAdditionOffset);
			DropItemTable.AddTaskID(builder, TaskID);
			DropItemTable.AddIsRareControl(builder, IsRareControl);
			DropItemTable.AddItemNum(builder, ItemNumOffset);
			DropItemTable.AddItemProb(builder, ItemProb);
			DropItemTable.AddItemID(builder, ItemID);
			DropItemTable.AddDataType(builder, DataType);
			DropItemTable.AddNumProbSet(builder, NumProbSetOffset);
			DropItemTable.AddChooseNumSet(builder, ChooseNumSetOffset);
			DropItemTable.AddGroupID(builder, GroupID);
			DropItemTable.AddID(builder, ID);
			return DropItemTable.EndDropItemTable(builder);
		}

		// Token: 0x060026EE RID: 9966 RVA: 0x00096BE8 File Offset: 0x00094FE8
		public static void StartDropItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(19);
		}

		// Token: 0x060026EF RID: 9967 RVA: 0x00096BF2 File Offset: 0x00094FF2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060026F0 RID: 9968 RVA: 0x00096BFD File Offset: 0x00094FFD
		public static void AddGroupID(FlatBufferBuilder builder, int GroupID)
		{
			builder.AddInt(1, GroupID, 0);
		}

		// Token: 0x060026F1 RID: 9969 RVA: 0x00096C08 File Offset: 0x00095008
		public static void AddChooseNumSet(FlatBufferBuilder builder, VectorOffset ChooseNumSetOffset)
		{
			builder.AddOffset(2, ChooseNumSetOffset.Value, 0);
		}

		// Token: 0x060026F2 RID: 9970 RVA: 0x00096C1C File Offset: 0x0009501C
		public static VectorOffset CreateChooseNumSetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060026F3 RID: 9971 RVA: 0x00096C59 File Offset: 0x00095059
		public static void StartChooseNumSetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060026F4 RID: 9972 RVA: 0x00096C64 File Offset: 0x00095064
		public static void AddNumProbSet(FlatBufferBuilder builder, VectorOffset NumProbSetOffset)
		{
			builder.AddOffset(3, NumProbSetOffset.Value, 0);
		}

		// Token: 0x060026F5 RID: 9973 RVA: 0x00096C78 File Offset: 0x00095078
		public static VectorOffset CreateNumProbSetVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060026F6 RID: 9974 RVA: 0x00096CB5 File Offset: 0x000950B5
		public static void StartNumProbSetVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060026F7 RID: 9975 RVA: 0x00096CC0 File Offset: 0x000950C0
		public static void AddDataType(FlatBufferBuilder builder, int DataType)
		{
			builder.AddInt(4, DataType, 0);
		}

		// Token: 0x060026F8 RID: 9976 RVA: 0x00096CCB File Offset: 0x000950CB
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(5, ItemID, 0);
		}

		// Token: 0x060026F9 RID: 9977 RVA: 0x00096CD6 File Offset: 0x000950D6
		public static void AddItemProb(FlatBufferBuilder builder, int ItemProb)
		{
			builder.AddInt(6, ItemProb, 0);
		}

		// Token: 0x060026FA RID: 9978 RVA: 0x00096CE1 File Offset: 0x000950E1
		public static void AddItemNum(FlatBufferBuilder builder, VectorOffset ItemNumOffset)
		{
			builder.AddOffset(7, ItemNumOffset.Value, 0);
		}

		// Token: 0x060026FB RID: 9979 RVA: 0x00096CF4 File Offset: 0x000950F4
		public static VectorOffset CreateItemNumVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060026FC RID: 9980 RVA: 0x00096D31 File Offset: 0x00095131
		public static void StartItemNumVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060026FD RID: 9981 RVA: 0x00096D3C File Offset: 0x0009513C
		public static void AddIsRareControl(FlatBufferBuilder builder, int IsRareControl)
		{
			builder.AddInt(8, IsRareControl, 0);
		}

		// Token: 0x060026FE RID: 9982 RVA: 0x00096D47 File Offset: 0x00095147
		public static void AddTaskID(FlatBufferBuilder builder, int TaskID)
		{
			builder.AddInt(9, TaskID, 0);
		}

		// Token: 0x060026FF RID: 9983 RVA: 0x00096D53 File Offset: 0x00095153
		public static void AddOccuAddition(FlatBufferBuilder builder, VectorOffset OccuAdditionOffset)
		{
			builder.AddOffset(10, OccuAdditionOffset.Value, 0);
		}

		// Token: 0x06002700 RID: 9984 RVA: 0x00096D68 File Offset: 0x00095168
		public static VectorOffset CreateOccuAdditionVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002701 RID: 9985 RVA: 0x00096DA5 File Offset: 0x000951A5
		public static void StartOccuAdditionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002702 RID: 9986 RVA: 0x00096DB0 File Offset: 0x000951B0
		public static void AddAdditionProb(FlatBufferBuilder builder, int AdditionProb)
		{
			builder.AddInt(11, AdditionProb, 0);
		}

		// Token: 0x06002703 RID: 9987 RVA: 0x00096DBC File Offset: 0x000951BC
		public static void AddDropItemType(FlatBufferBuilder builder, int DropItemType)
		{
			builder.AddInt(12, DropItemType, 0);
		}

		// Token: 0x06002704 RID: 9988 RVA: 0x00096DC8 File Offset: 0x000951C8
		public static void AddDropNotice(FlatBufferBuilder builder, int DropNotice)
		{
			builder.AddInt(13, DropNotice, 0);
		}

		// Token: 0x06002705 RID: 9989 RVA: 0x00096DD4 File Offset: 0x000951D4
		public static void AddText(FlatBufferBuilder builder, StringOffset TextOffset)
		{
			builder.AddOffset(14, TextOffset.Value, 0);
		}

		// Token: 0x06002706 RID: 9990 RVA: 0x00096DE6 File Offset: 0x000951E6
		public static void AddActivityID(FlatBufferBuilder builder, int ActivityID)
		{
			builder.AddInt(15, ActivityID, 0);
		}

		// Token: 0x06002707 RID: 9991 RVA: 0x00096DF2 File Offset: 0x000951F2
		public static void AddMark(FlatBufferBuilder builder, StringOffset MarkOffset)
		{
			builder.AddOffset(16, MarkOffset.Value, 0);
		}

		// Token: 0x06002708 RID: 9992 RVA: 0x00096E04 File Offset: 0x00095204
		public static void AddVip(FlatBufferBuilder builder, StringOffset VipOffset)
		{
			builder.AddOffset(17, VipOffset.Value, 0);
		}

		// Token: 0x06002709 RID: 9993 RVA: 0x00096E16 File Offset: 0x00095216
		public static void AddVipDropLimitId(FlatBufferBuilder builder, int VipDropLimitId)
		{
			builder.AddInt(18, VipDropLimitId, 0);
		}

		// Token: 0x0600270A RID: 9994 RVA: 0x00096E24 File Offset: 0x00095224
		public static Offset<DropItemTable> EndDropItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DropItemTable>(value);
		}

		// Token: 0x0600270B RID: 9995 RVA: 0x00096E3E File Offset: 0x0009523E
		public static void FinishDropItemTableBuffer(FlatBufferBuilder builder, Offset<DropItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011B0 RID: 4528
		private Table __p = new Table();

		// Token: 0x040011B1 RID: 4529
		private FlatBufferArray<int> ChooseNumSetValue;

		// Token: 0x040011B2 RID: 4530
		private FlatBufferArray<int> NumProbSetValue;

		// Token: 0x040011B3 RID: 4531
		private FlatBufferArray<int> ItemNumValue;

		// Token: 0x040011B4 RID: 4532
		private FlatBufferArray<int> OccuAdditionValue;

		// Token: 0x02000388 RID: 904
		public enum eCrypt
		{
			// Token: 0x040011B6 RID: 4534
			code = -1086889122
		}
	}
}
