using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000382 RID: 898
	public class DigMapTable : IFlatbufferObject
	{
		// Token: 0x17000866 RID: 2150
		// (get) Token: 0x0600265F RID: 9823 RVA: 0x00095460 File Offset: 0x00093860
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002660 RID: 9824 RVA: 0x0009546D File Offset: 0x0009386D
		public static DigMapTable GetRootAsDigMapTable(ByteBuffer _bb)
		{
			return DigMapTable.GetRootAsDigMapTable(_bb, new DigMapTable());
		}

		// Token: 0x06002661 RID: 9825 RVA: 0x0009547A File Offset: 0x0009387A
		public static DigMapTable GetRootAsDigMapTable(ByteBuffer _bb, DigMapTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002662 RID: 9826 RVA: 0x00095496 File Offset: 0x00093896
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002663 RID: 9827 RVA: 0x000954B0 File Offset: 0x000938B0
		public DigMapTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000867 RID: 2151
		// (get) Token: 0x06002664 RID: 9828 RVA: 0x000954BC File Offset: 0x000938BC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000868 RID: 2152
		// (get) Token: 0x06002665 RID: 9829 RVA: 0x00095508 File Offset: 0x00093908
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002666 RID: 9830 RVA: 0x0009554A File Offset: 0x0009394A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000869 RID: 2153
		// (get) Token: 0x06002667 RID: 9831 RVA: 0x00095558 File Offset: 0x00093958
		public int GoldDigMinNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700086A RID: 2154
		// (get) Token: 0x06002668 RID: 9832 RVA: 0x000955A4 File Offset: 0x000939A4
		public int GoldDigMaxNum
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700086B RID: 2155
		// (get) Token: 0x06002669 RID: 9833 RVA: 0x000955F0 File Offset: 0x000939F0
		public int GoldRefreshHour
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700086C RID: 2156
		// (get) Token: 0x0600266A RID: 9834 RVA: 0x0009563C File Offset: 0x00093A3C
		public int SilverDigMinNum
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700086D RID: 2157
		// (get) Token: 0x0600266B RID: 9835 RVA: 0x00095688 File Offset: 0x00093A88
		public int SilverDigMaxNum
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700086E RID: 2158
		// (get) Token: 0x0600266C RID: 9836 RVA: 0x000956D4 File Offset: 0x00093AD4
		public int SilverRefreshHour
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700086F RID: 2159
		// (get) Token: 0x0600266D RID: 9837 RVA: 0x00095720 File Offset: 0x00093B20
		public int DigMaxNum
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (2096015056 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000870 RID: 2160
		// (get) Token: 0x0600266E RID: 9838 RVA: 0x0009576C File Offset: 0x00093B6C
		public string MapResPath
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600266F RID: 9839 RVA: 0x000957AF File Offset: 0x00093BAF
		public ArraySegment<byte>? GetMapResPathBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000871 RID: 2161
		// (get) Token: 0x06002670 RID: 9840 RVA: 0x000957C0 File Offset: 0x00093BC0
		public string AtlasResPath
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002671 RID: 9841 RVA: 0x00095803 File Offset: 0x00093C03
		public ArraySegment<byte>? GetAtlasResPathBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x17000872 RID: 2162
		// (get) Token: 0x06002672 RID: 9842 RVA: 0x00095814 File Offset: 0x00093C14
		public string MapRouteResPath
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002673 RID: 9843 RVA: 0x00095857 File Offset: 0x00093C57
		public ArraySegment<byte>? GetMapRouteResPathBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x06002674 RID: 9844 RVA: 0x00095868 File Offset: 0x00093C68
		public static Offset<DigMapTable> CreateDigMapTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int GoldDigMinNum = 0, int GoldDigMaxNum = 0, int GoldRefreshHour = 0, int SilverDigMinNum = 0, int SilverDigMaxNum = 0, int SilverRefreshHour = 0, int DigMaxNum = 0, StringOffset MapResPathOffset = default(StringOffset), StringOffset AtlasResPathOffset = default(StringOffset), StringOffset MapRouteResPathOffset = default(StringOffset))
		{
			builder.StartObject(12);
			DigMapTable.AddMapRouteResPath(builder, MapRouteResPathOffset);
			DigMapTable.AddAtlasResPath(builder, AtlasResPathOffset);
			DigMapTable.AddMapResPath(builder, MapResPathOffset);
			DigMapTable.AddDigMaxNum(builder, DigMaxNum);
			DigMapTable.AddSilverRefreshHour(builder, SilverRefreshHour);
			DigMapTable.AddSilverDigMaxNum(builder, SilverDigMaxNum);
			DigMapTable.AddSilverDigMinNum(builder, SilverDigMinNum);
			DigMapTable.AddGoldRefreshHour(builder, GoldRefreshHour);
			DigMapTable.AddGoldDigMaxNum(builder, GoldDigMaxNum);
			DigMapTable.AddGoldDigMinNum(builder, GoldDigMinNum);
			DigMapTable.AddName(builder, NameOffset);
			DigMapTable.AddID(builder, ID);
			return DigMapTable.EndDigMapTable(builder);
		}

		// Token: 0x06002675 RID: 9845 RVA: 0x000958E0 File Offset: 0x00093CE0
		public static void StartDigMapTable(FlatBufferBuilder builder)
		{
			builder.StartObject(12);
		}

		// Token: 0x06002676 RID: 9846 RVA: 0x000958EA File Offset: 0x00093CEA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002677 RID: 9847 RVA: 0x000958F5 File Offset: 0x00093CF5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002678 RID: 9848 RVA: 0x00095906 File Offset: 0x00093D06
		public static void AddGoldDigMinNum(FlatBufferBuilder builder, int GoldDigMinNum)
		{
			builder.AddInt(2, GoldDigMinNum, 0);
		}

		// Token: 0x06002679 RID: 9849 RVA: 0x00095911 File Offset: 0x00093D11
		public static void AddGoldDigMaxNum(FlatBufferBuilder builder, int GoldDigMaxNum)
		{
			builder.AddInt(3, GoldDigMaxNum, 0);
		}

		// Token: 0x0600267A RID: 9850 RVA: 0x0009591C File Offset: 0x00093D1C
		public static void AddGoldRefreshHour(FlatBufferBuilder builder, int GoldRefreshHour)
		{
			builder.AddInt(4, GoldRefreshHour, 0);
		}

		// Token: 0x0600267B RID: 9851 RVA: 0x00095927 File Offset: 0x00093D27
		public static void AddSilverDigMinNum(FlatBufferBuilder builder, int SilverDigMinNum)
		{
			builder.AddInt(5, SilverDigMinNum, 0);
		}

		// Token: 0x0600267C RID: 9852 RVA: 0x00095932 File Offset: 0x00093D32
		public static void AddSilverDigMaxNum(FlatBufferBuilder builder, int SilverDigMaxNum)
		{
			builder.AddInt(6, SilverDigMaxNum, 0);
		}

		// Token: 0x0600267D RID: 9853 RVA: 0x0009593D File Offset: 0x00093D3D
		public static void AddSilverRefreshHour(FlatBufferBuilder builder, int SilverRefreshHour)
		{
			builder.AddInt(7, SilverRefreshHour, 0);
		}

		// Token: 0x0600267E RID: 9854 RVA: 0x00095948 File Offset: 0x00093D48
		public static void AddDigMaxNum(FlatBufferBuilder builder, int DigMaxNum)
		{
			builder.AddInt(8, DigMaxNum, 0);
		}

		// Token: 0x0600267F RID: 9855 RVA: 0x00095953 File Offset: 0x00093D53
		public static void AddMapResPath(FlatBufferBuilder builder, StringOffset MapResPathOffset)
		{
			builder.AddOffset(9, MapResPathOffset.Value, 0);
		}

		// Token: 0x06002680 RID: 9856 RVA: 0x00095965 File Offset: 0x00093D65
		public static void AddAtlasResPath(FlatBufferBuilder builder, StringOffset AtlasResPathOffset)
		{
			builder.AddOffset(10, AtlasResPathOffset.Value, 0);
		}

		// Token: 0x06002681 RID: 9857 RVA: 0x00095977 File Offset: 0x00093D77
		public static void AddMapRouteResPath(FlatBufferBuilder builder, StringOffset MapRouteResPathOffset)
		{
			builder.AddOffset(11, MapRouteResPathOffset.Value, 0);
		}

		// Token: 0x06002682 RID: 9858 RVA: 0x0009598C File Offset: 0x00093D8C
		public static Offset<DigMapTable> EndDigMapTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DigMapTable>(value);
		}

		// Token: 0x06002683 RID: 9859 RVA: 0x000959A6 File Offset: 0x00093DA6
		public static void FinishDigMapTableBuffer(FlatBufferBuilder builder, Offset<DigMapTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011A5 RID: 4517
		private Table __p = new Table();

		// Token: 0x02000383 RID: 899
		public enum eCrypt
		{
			// Token: 0x040011A7 RID: 4519
			code = 2096015056
		}
	}
}
