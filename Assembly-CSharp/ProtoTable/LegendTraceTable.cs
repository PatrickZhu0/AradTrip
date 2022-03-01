using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004D3 RID: 1235
	public class LegendTraceTable : IFlatbufferObject
	{
		// Token: 0x17001019 RID: 4121
		// (get) Token: 0x06003E03 RID: 15875 RVA: 0x000CD8A0 File Offset: 0x000CBCA0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003E04 RID: 15876 RVA: 0x000CD8AD File Offset: 0x000CBCAD
		public static LegendTraceTable GetRootAsLegendTraceTable(ByteBuffer _bb)
		{
			return LegendTraceTable.GetRootAsLegendTraceTable(_bb, new LegendTraceTable());
		}

		// Token: 0x06003E05 RID: 15877 RVA: 0x000CD8BA File Offset: 0x000CBCBA
		public static LegendTraceTable GetRootAsLegendTraceTable(ByteBuffer _bb, LegendTraceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003E06 RID: 15878 RVA: 0x000CD8D6 File Offset: 0x000CBCD6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003E07 RID: 15879 RVA: 0x000CD8F0 File Offset: 0x000CBCF0
		public LegendTraceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700101A RID: 4122
		// (get) Token: 0x06003E08 RID: 15880 RVA: 0x000CD8FC File Offset: 0x000CBCFC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1734328602 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700101B RID: 4123
		// (get) Token: 0x06003E09 RID: 15881 RVA: 0x000CD948 File Offset: 0x000CBD48
		public string Title
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003E0A RID: 15882 RVA: 0x000CD98A File Offset: 0x000CBD8A
		public ArraySegment<byte>? GetTitleBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06003E0B RID: 15883 RVA: 0x000CD998 File Offset: 0x000CBD98
		public int ItemIdsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1734328602 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700101C RID: 4124
		// (get) Token: 0x06003E0C RID: 15884 RVA: 0x000CD9E4 File Offset: 0x000CBDE4
		public int ItemIdsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003E0D RID: 15885 RVA: 0x000CDA16 File Offset: 0x000CBE16
		public ArraySegment<byte>? GetItemIdsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700101D RID: 4125
		// (get) Token: 0x06003E0E RID: 15886 RVA: 0x000CDA24 File Offset: 0x000CBE24
		public FlatBufferArray<int> ItemIds
		{
			get
			{
				if (this.ItemIdsValue == null)
				{
					this.ItemIdsValue = new FlatBufferArray<int>(new Func<int, int>(this.ItemIdsArray), this.ItemIdsLength);
				}
				return this.ItemIdsValue;
			}
		}

		// Token: 0x06003E0F RID: 15887 RVA: 0x000CDA54 File Offset: 0x000CBE54
		public int ItemCountsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1734328602 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700101E RID: 4126
		// (get) Token: 0x06003E10 RID: 15888 RVA: 0x000CDAA4 File Offset: 0x000CBEA4
		public int ItemCountsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003E11 RID: 15889 RVA: 0x000CDAD7 File Offset: 0x000CBED7
		public ArraySegment<byte>? GetItemCountsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x1700101F RID: 4127
		// (get) Token: 0x06003E12 RID: 15890 RVA: 0x000CDAE6 File Offset: 0x000CBEE6
		public FlatBufferArray<int> ItemCounts
		{
			get
			{
				if (this.ItemCountsValue == null)
				{
					this.ItemCountsValue = new FlatBufferArray<int>(new Func<int, int>(this.ItemCountsArray), this.ItemCountsLength);
				}
				return this.ItemCountsValue;
			}
		}

		// Token: 0x06003E13 RID: 15891 RVA: 0x000CDB18 File Offset: 0x000CBF18
		public string IconsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001020 RID: 4128
		// (get) Token: 0x06003E14 RID: 15892 RVA: 0x000CDB60 File Offset: 0x000CBF60
		public int IconsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001021 RID: 4129
		// (get) Token: 0x06003E15 RID: 15893 RVA: 0x000CDB93 File Offset: 0x000CBF93
		public FlatBufferArray<string> Icons
		{
			get
			{
				if (this.IconsValue == null)
				{
					this.IconsValue = new FlatBufferArray<string>(new Func<int, string>(this.IconsArray), this.IconsLength);
				}
				return this.IconsValue;
			}
		}

		// Token: 0x06003E16 RID: 15894 RVA: 0x000CDBC4 File Offset: 0x000CBFC4
		public string ActionDescArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001022 RID: 4130
		// (get) Token: 0x06003E17 RID: 15895 RVA: 0x000CDC0C File Offset: 0x000CC00C
		public int ActionDescLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001023 RID: 4131
		// (get) Token: 0x06003E18 RID: 15896 RVA: 0x000CDC3F File Offset: 0x000CC03F
		public FlatBufferArray<string> ActionDesc
		{
			get
			{
				if (this.ActionDescValue == null)
				{
					this.ActionDescValue = new FlatBufferArray<string>(new Func<int, string>(this.ActionDescArray), this.ActionDescLength);
				}
				return this.ActionDescValue;
			}
		}

		// Token: 0x17001024 RID: 4132
		// (get) Token: 0x06003E19 RID: 15897 RVA: 0x000CDC70 File Offset: 0x000CC070
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003E1A RID: 15898 RVA: 0x000CDCB3 File Offset: 0x000CC0B3
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001025 RID: 4133
		// (get) Token: 0x06003E1B RID: 15899 RVA: 0x000CDCC4 File Offset: 0x000CC0C4
		public string KeyValueDesc
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003E1C RID: 15900 RVA: 0x000CDD07 File Offset: 0x000CC107
		public ArraySegment<byte>? GetKeyValueDescBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17001026 RID: 4134
		// (get) Token: 0x06003E1D RID: 15901 RVA: 0x000CDD18 File Offset: 0x000CC118
		public int LinkMissionID
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1734328602 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001027 RID: 4135
		// (get) Token: 0x06003E1E RID: 15902 RVA: 0x000CDD64 File Offset: 0x000CC164
		public int IsShowNumber
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1734328602 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003E1F RID: 15903 RVA: 0x000CDDB0 File Offset: 0x000CC1B0
		public static Offset<LegendTraceTable> CreateLegendTraceTable(FlatBufferBuilder builder, int ID = 0, StringOffset TitleOffset = default(StringOffset), VectorOffset ItemIdsOffset = default(VectorOffset), VectorOffset ItemCountsOffset = default(VectorOffset), VectorOffset IconsOffset = default(VectorOffset), VectorOffset ActionDescOffset = default(VectorOffset), StringOffset LinkInfoOffset = default(StringOffset), StringOffset KeyValueDescOffset = default(StringOffset), int LinkMissionID = 0, int IsShowNumber = 0)
		{
			builder.StartObject(10);
			LegendTraceTable.AddIsShowNumber(builder, IsShowNumber);
			LegendTraceTable.AddLinkMissionID(builder, LinkMissionID);
			LegendTraceTable.AddKeyValueDesc(builder, KeyValueDescOffset);
			LegendTraceTable.AddLinkInfo(builder, LinkInfoOffset);
			LegendTraceTable.AddActionDesc(builder, ActionDescOffset);
			LegendTraceTable.AddIcons(builder, IconsOffset);
			LegendTraceTable.AddItemCounts(builder, ItemCountsOffset);
			LegendTraceTable.AddItemIds(builder, ItemIdsOffset);
			LegendTraceTable.AddTitle(builder, TitleOffset);
			LegendTraceTable.AddID(builder, ID);
			return LegendTraceTable.EndLegendTraceTable(builder);
		}

		// Token: 0x06003E20 RID: 15904 RVA: 0x000CDE18 File Offset: 0x000CC218
		public static void StartLegendTraceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(10);
		}

		// Token: 0x06003E21 RID: 15905 RVA: 0x000CDE22 File Offset: 0x000CC222
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003E22 RID: 15906 RVA: 0x000CDE2D File Offset: 0x000CC22D
		public static void AddTitle(FlatBufferBuilder builder, StringOffset TitleOffset)
		{
			builder.AddOffset(1, TitleOffset.Value, 0);
		}

		// Token: 0x06003E23 RID: 15907 RVA: 0x000CDE3E File Offset: 0x000CC23E
		public static void AddItemIds(FlatBufferBuilder builder, VectorOffset ItemIdsOffset)
		{
			builder.AddOffset(2, ItemIdsOffset.Value, 0);
		}

		// Token: 0x06003E24 RID: 15908 RVA: 0x000CDE50 File Offset: 0x000CC250
		public static VectorOffset CreateItemIdsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003E25 RID: 15909 RVA: 0x000CDE8D File Offset: 0x000CC28D
		public static void StartItemIdsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003E26 RID: 15910 RVA: 0x000CDE98 File Offset: 0x000CC298
		public static void AddItemCounts(FlatBufferBuilder builder, VectorOffset ItemCountsOffset)
		{
			builder.AddOffset(3, ItemCountsOffset.Value, 0);
		}

		// Token: 0x06003E27 RID: 15911 RVA: 0x000CDEAC File Offset: 0x000CC2AC
		public static VectorOffset CreateItemCountsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003E28 RID: 15912 RVA: 0x000CDEE9 File Offset: 0x000CC2E9
		public static void StartItemCountsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003E29 RID: 15913 RVA: 0x000CDEF4 File Offset: 0x000CC2F4
		public static void AddIcons(FlatBufferBuilder builder, VectorOffset IconsOffset)
		{
			builder.AddOffset(4, IconsOffset.Value, 0);
		}

		// Token: 0x06003E2A RID: 15914 RVA: 0x000CDF08 File Offset: 0x000CC308
		public static VectorOffset CreateIconsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003E2B RID: 15915 RVA: 0x000CDF4E File Offset: 0x000CC34E
		public static void StartIconsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003E2C RID: 15916 RVA: 0x000CDF59 File Offset: 0x000CC359
		public static void AddActionDesc(FlatBufferBuilder builder, VectorOffset ActionDescOffset)
		{
			builder.AddOffset(5, ActionDescOffset.Value, 0);
		}

		// Token: 0x06003E2D RID: 15917 RVA: 0x000CDF6C File Offset: 0x000CC36C
		public static VectorOffset CreateActionDescVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003E2E RID: 15918 RVA: 0x000CDFB2 File Offset: 0x000CC3B2
		public static void StartActionDescVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003E2F RID: 15919 RVA: 0x000CDFBD File Offset: 0x000CC3BD
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(6, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06003E30 RID: 15920 RVA: 0x000CDFCE File Offset: 0x000CC3CE
		public static void AddKeyValueDesc(FlatBufferBuilder builder, StringOffset KeyValueDescOffset)
		{
			builder.AddOffset(7, KeyValueDescOffset.Value, 0);
		}

		// Token: 0x06003E31 RID: 15921 RVA: 0x000CDFDF File Offset: 0x000CC3DF
		public static void AddLinkMissionID(FlatBufferBuilder builder, int LinkMissionID)
		{
			builder.AddInt(8, LinkMissionID, 0);
		}

		// Token: 0x06003E32 RID: 15922 RVA: 0x000CDFEA File Offset: 0x000CC3EA
		public static void AddIsShowNumber(FlatBufferBuilder builder, int IsShowNumber)
		{
			builder.AddInt(9, IsShowNumber, 0);
		}

		// Token: 0x06003E33 RID: 15923 RVA: 0x000CDFF8 File Offset: 0x000CC3F8
		public static Offset<LegendTraceTable> EndLegendTraceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LegendTraceTable>(value);
		}

		// Token: 0x06003E34 RID: 15924 RVA: 0x000CE012 File Offset: 0x000CC412
		public static void FinishLegendTraceTableBuffer(FlatBufferBuilder builder, Offset<LegendTraceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017DF RID: 6111
		private Table __p = new Table();

		// Token: 0x040017E0 RID: 6112
		private FlatBufferArray<int> ItemIdsValue;

		// Token: 0x040017E1 RID: 6113
		private FlatBufferArray<int> ItemCountsValue;

		// Token: 0x040017E2 RID: 6114
		private FlatBufferArray<string> IconsValue;

		// Token: 0x040017E3 RID: 6115
		private FlatBufferArray<string> ActionDescValue;

		// Token: 0x020004D4 RID: 1236
		public enum eCrypt
		{
			// Token: 0x040017E5 RID: 6117
			code = -1734328602
		}
	}
}
