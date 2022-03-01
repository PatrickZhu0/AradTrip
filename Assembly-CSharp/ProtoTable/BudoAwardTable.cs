using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002E6 RID: 742
	public class BudoAwardTable : IFlatbufferObject
	{
		// Token: 0x1700047D RID: 1149
		// (get) Token: 0x06001B40 RID: 6976 RVA: 0x00079AF4 File Offset: 0x00077EF4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001B41 RID: 6977 RVA: 0x00079B01 File Offset: 0x00077F01
		public static BudoAwardTable GetRootAsBudoAwardTable(ByteBuffer _bb)
		{
			return BudoAwardTable.GetRootAsBudoAwardTable(_bb, new BudoAwardTable());
		}

		// Token: 0x06001B42 RID: 6978 RVA: 0x00079B0E File Offset: 0x00077F0E
		public static BudoAwardTable GetRootAsBudoAwardTable(ByteBuffer _bb, BudoAwardTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001B43 RID: 6979 RVA: 0x00079B2A File Offset: 0x00077F2A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001B44 RID: 6980 RVA: 0x00079B44 File Offset: 0x00077F44
		public BudoAwardTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700047E RID: 1150
		// (get) Token: 0x06001B45 RID: 6981 RVA: 0x00079B50 File Offset: 0x00077F50
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (41054139 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700047F RID: 1151
		// (get) Token: 0x06001B46 RID: 6982 RVA: 0x00079B9C File Offset: 0x00077F9C
		public int Times
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (41054139 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000480 RID: 1152
		// (get) Token: 0x06001B47 RID: 6983 RVA: 0x00079BE8 File Offset: 0x00077FE8
		public int MaxTimes
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (41054139 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001B48 RID: 6984 RVA: 0x00079C34 File Offset: 0x00078034
		public int JarTypeArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (41054139 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000481 RID: 1153
		// (get) Token: 0x06001B49 RID: 6985 RVA: 0x00079C84 File Offset: 0x00078084
		public int JarTypeLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001B4A RID: 6986 RVA: 0x00079CB7 File Offset: 0x000780B7
		public ArraySegment<byte>? GetJarTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000482 RID: 1154
		// (get) Token: 0x06001B4B RID: 6987 RVA: 0x00079CC6 File Offset: 0x000780C6
		public FlatBufferArray<int> JarType
		{
			get
			{
				if (this.JarTypeValue == null)
				{
					this.JarTypeValue = new FlatBufferArray<int>(new Func<int, int>(this.JarTypeArray), this.JarTypeLength);
				}
				return this.JarTypeValue;
			}
		}

		// Token: 0x17000483 RID: 1155
		// (get) Token: 0x06001B4C RID: 6988 RVA: 0x00079CF8 File Offset: 0x000780F8
		public string desc
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B4D RID: 6989 RVA: 0x00079D3B File Offset: 0x0007813B
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000484 RID: 1156
		// (get) Token: 0x06001B4E RID: 6990 RVA: 0x00079D4C File Offset: 0x0007814C
		public string wins
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B4F RID: 6991 RVA: 0x00079D8F File Offset: 0x0007818F
		public ArraySegment<byte>? GetWinsBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000485 RID: 1157
		// (get) Token: 0x06001B50 RID: 6992 RVA: 0x00079DA0 File Offset: 0x000781A0
		public string news
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B51 RID: 6993 RVA: 0x00079DE3 File Offset: 0x000781E3
		public ArraySegment<byte>? GetNewsBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000486 RID: 1158
		// (get) Token: 0x06001B52 RID: 6994 RVA: 0x00079DF4 File Offset: 0x000781F4
		public string idles
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B53 RID: 6995 RVA: 0x00079E37 File Offset: 0x00078237
		public ArraySegment<byte>? GetIdlesBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000487 RID: 1159
		// (get) Token: 0x06001B54 RID: 6996 RVA: 0x00079E48 File Offset: 0x00078248
		public string GetPreview
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B55 RID: 6997 RVA: 0x00079E8B File Offset: 0x0007828B
		public ArraySegment<byte>? GetGetPreviewBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06001B56 RID: 6998 RVA: 0x00079E9C File Offset: 0x0007829C
		public static Offset<BudoAwardTable> CreateBudoAwardTable(FlatBufferBuilder builder, int ID = 0, int Times = 0, int MaxTimes = 0, VectorOffset JarTypeOffset = default(VectorOffset), StringOffset descOffset = default(StringOffset), StringOffset winsOffset = default(StringOffset), StringOffset newsOffset = default(StringOffset), StringOffset idlesOffset = default(StringOffset), StringOffset GetPreviewOffset = default(StringOffset))
		{
			builder.StartObject(9);
			BudoAwardTable.AddGetPreview(builder, GetPreviewOffset);
			BudoAwardTable.AddIdles(builder, idlesOffset);
			BudoAwardTable.AddNews(builder, newsOffset);
			BudoAwardTable.AddWins(builder, winsOffset);
			BudoAwardTable.AddDesc(builder, descOffset);
			BudoAwardTable.AddJarType(builder, JarTypeOffset);
			BudoAwardTable.AddMaxTimes(builder, MaxTimes);
			BudoAwardTable.AddTimes(builder, Times);
			BudoAwardTable.AddID(builder, ID);
			return BudoAwardTable.EndBudoAwardTable(builder);
		}

		// Token: 0x06001B57 RID: 6999 RVA: 0x00079EFC File Offset: 0x000782FC
		public static void StartBudoAwardTable(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x06001B58 RID: 7000 RVA: 0x00079F06 File Offset: 0x00078306
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001B59 RID: 7001 RVA: 0x00079F11 File Offset: 0x00078311
		public static void AddTimes(FlatBufferBuilder builder, int Times)
		{
			builder.AddInt(1, Times, 0);
		}

		// Token: 0x06001B5A RID: 7002 RVA: 0x00079F1C File Offset: 0x0007831C
		public static void AddMaxTimes(FlatBufferBuilder builder, int MaxTimes)
		{
			builder.AddInt(2, MaxTimes, 0);
		}

		// Token: 0x06001B5B RID: 7003 RVA: 0x00079F27 File Offset: 0x00078327
		public static void AddJarType(FlatBufferBuilder builder, VectorOffset JarTypeOffset)
		{
			builder.AddOffset(3, JarTypeOffset.Value, 0);
		}

		// Token: 0x06001B5C RID: 7004 RVA: 0x00079F38 File Offset: 0x00078338
		public static VectorOffset CreateJarTypeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001B5D RID: 7005 RVA: 0x00079F75 File Offset: 0x00078375
		public static void StartJarTypeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001B5E RID: 7006 RVA: 0x00079F80 File Offset: 0x00078380
		public static void AddDesc(FlatBufferBuilder builder, StringOffset descOffset)
		{
			builder.AddOffset(4, descOffset.Value, 0);
		}

		// Token: 0x06001B5F RID: 7007 RVA: 0x00079F91 File Offset: 0x00078391
		public static void AddWins(FlatBufferBuilder builder, StringOffset winsOffset)
		{
			builder.AddOffset(5, winsOffset.Value, 0);
		}

		// Token: 0x06001B60 RID: 7008 RVA: 0x00079FA2 File Offset: 0x000783A2
		public static void AddNews(FlatBufferBuilder builder, StringOffset newsOffset)
		{
			builder.AddOffset(6, newsOffset.Value, 0);
		}

		// Token: 0x06001B61 RID: 7009 RVA: 0x00079FB3 File Offset: 0x000783B3
		public static void AddIdles(FlatBufferBuilder builder, StringOffset idlesOffset)
		{
			builder.AddOffset(7, idlesOffset.Value, 0);
		}

		// Token: 0x06001B62 RID: 7010 RVA: 0x00079FC4 File Offset: 0x000783C4
		public static void AddGetPreview(FlatBufferBuilder builder, StringOffset GetPreviewOffset)
		{
			builder.AddOffset(8, GetPreviewOffset.Value, 0);
		}

		// Token: 0x06001B63 RID: 7011 RVA: 0x00079FD8 File Offset: 0x000783D8
		public static Offset<BudoAwardTable> EndBudoAwardTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BudoAwardTable>(value);
		}

		// Token: 0x06001B64 RID: 7012 RVA: 0x00079FF2 File Offset: 0x000783F2
		public static void FinishBudoAwardTableBuffer(FlatBufferBuilder builder, Offset<BudoAwardTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EC0 RID: 3776
		private Table __p = new Table();

		// Token: 0x04000EC1 RID: 3777
		private FlatBufferArray<int> JarTypeValue;

		// Token: 0x020002E7 RID: 743
		public enum eCrypt
		{
			// Token: 0x04000EC3 RID: 3779
			code = 41054139
		}
	}
}
