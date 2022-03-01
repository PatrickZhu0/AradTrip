using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004D1 RID: 1233
	public class LegendMainTable : IFlatbufferObject
	{
		// Token: 0x1700100E RID: 4110
		// (get) Token: 0x06003DDC RID: 15836 RVA: 0x000CD300 File Offset: 0x000CB700
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003DDD RID: 15837 RVA: 0x000CD30D File Offset: 0x000CB70D
		public static LegendMainTable GetRootAsLegendMainTable(ByteBuffer _bb)
		{
			return LegendMainTable.GetRootAsLegendMainTable(_bb, new LegendMainTable());
		}

		// Token: 0x06003DDE RID: 15838 RVA: 0x000CD31A File Offset: 0x000CB71A
		public static LegendMainTable GetRootAsLegendMainTable(ByteBuffer _bb, LegendMainTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003DDF RID: 15839 RVA: 0x000CD336 File Offset: 0x000CB736
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003DE0 RID: 15840 RVA: 0x000CD350 File Offset: 0x000CB750
		public LegendMainTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700100F RID: 4111
		// (get) Token: 0x06003DE1 RID: 15841 RVA: 0x000CD35C File Offset: 0x000CB75C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (89418144 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001010 RID: 4112
		// (get) Token: 0x06003DE2 RID: 15842 RVA: 0x000CD3A8 File Offset: 0x000CB7A8
		public int SortID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (89418144 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001011 RID: 4113
		// (get) Token: 0x06003DE3 RID: 15843 RVA: 0x000CD3F4 File Offset: 0x000CB7F4
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003DE4 RID: 15844 RVA: 0x000CD436 File Offset: 0x000CB836
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06003DE5 RID: 15845 RVA: 0x000CD444 File Offset: 0x000CB844
		public int LinkItemsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (89418144 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001012 RID: 4114
		// (get) Token: 0x06003DE6 RID: 15846 RVA: 0x000CD494 File Offset: 0x000CB894
		public int LinkItemsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003DE7 RID: 15847 RVA: 0x000CD4C7 File Offset: 0x000CB8C7
		public ArraySegment<byte>? GetLinkItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001013 RID: 4115
		// (get) Token: 0x06003DE8 RID: 15848 RVA: 0x000CD4D6 File Offset: 0x000CB8D6
		public FlatBufferArray<int> LinkItems
		{
			get
			{
				if (this.LinkItemsValue == null)
				{
					this.LinkItemsValue = new FlatBufferArray<int>(new Func<int, int>(this.LinkItemsArray), this.LinkItemsLength);
				}
				return this.LinkItemsValue;
			}
		}

		// Token: 0x17001014 RID: 4116
		// (get) Token: 0x06003DE9 RID: 15849 RVA: 0x000CD508 File Offset: 0x000CB908
		public int UnLockLevel
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (89418144 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003DEA RID: 15850 RVA: 0x000CD554 File Offset: 0x000CB954
		public string IconsArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17001015 RID: 4117
		// (get) Token: 0x06003DEB RID: 15851 RVA: 0x000CD59C File Offset: 0x000CB99C
		public int IconsLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17001016 RID: 4118
		// (get) Token: 0x06003DEC RID: 15852 RVA: 0x000CD5CF File Offset: 0x000CB9CF
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

		// Token: 0x06003DED RID: 15853 RVA: 0x000CD600 File Offset: 0x000CBA00
		public int missionIdsArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (89418144 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001017 RID: 4119
		// (get) Token: 0x06003DEE RID: 15854 RVA: 0x000CD650 File Offset: 0x000CBA50
		public int missionIdsLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003DEF RID: 15855 RVA: 0x000CD683 File Offset: 0x000CBA83
		public ArraySegment<byte>? GetMissionIdsBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17001018 RID: 4120
		// (get) Token: 0x06003DF0 RID: 15856 RVA: 0x000CD692 File Offset: 0x000CBA92
		public FlatBufferArray<int> missionIds
		{
			get
			{
				if (this.missionIdsValue == null)
				{
					this.missionIdsValue = new FlatBufferArray<int>(new Func<int, int>(this.missionIdsArray), this.missionIdsLength);
				}
				return this.missionIdsValue;
			}
		}

		// Token: 0x06003DF1 RID: 15857 RVA: 0x000CD6C4 File Offset: 0x000CBAC4
		public static Offset<LegendMainTable> CreateLegendMainTable(FlatBufferBuilder builder, int ID = 0, int SortID = 0, StringOffset DescOffset = default(StringOffset), VectorOffset LinkItemsOffset = default(VectorOffset), int UnLockLevel = 0, VectorOffset IconsOffset = default(VectorOffset), VectorOffset missionIdsOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			LegendMainTable.AddMissionIds(builder, missionIdsOffset);
			LegendMainTable.AddIcons(builder, IconsOffset);
			LegendMainTable.AddUnLockLevel(builder, UnLockLevel);
			LegendMainTable.AddLinkItems(builder, LinkItemsOffset);
			LegendMainTable.AddDesc(builder, DescOffset);
			LegendMainTable.AddSortID(builder, SortID);
			LegendMainTable.AddID(builder, ID);
			return LegendMainTable.EndLegendMainTable(builder);
		}

		// Token: 0x06003DF2 RID: 15858 RVA: 0x000CD713 File Offset: 0x000CBB13
		public static void StartLegendMainTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06003DF3 RID: 15859 RVA: 0x000CD71C File Offset: 0x000CBB1C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003DF4 RID: 15860 RVA: 0x000CD727 File Offset: 0x000CBB27
		public static void AddSortID(FlatBufferBuilder builder, int SortID)
		{
			builder.AddInt(1, SortID, 0);
		}

		// Token: 0x06003DF5 RID: 15861 RVA: 0x000CD732 File Offset: 0x000CBB32
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(2, DescOffset.Value, 0);
		}

		// Token: 0x06003DF6 RID: 15862 RVA: 0x000CD743 File Offset: 0x000CBB43
		public static void AddLinkItems(FlatBufferBuilder builder, VectorOffset LinkItemsOffset)
		{
			builder.AddOffset(3, LinkItemsOffset.Value, 0);
		}

		// Token: 0x06003DF7 RID: 15863 RVA: 0x000CD754 File Offset: 0x000CBB54
		public static VectorOffset CreateLinkItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003DF8 RID: 15864 RVA: 0x000CD791 File Offset: 0x000CBB91
		public static void StartLinkItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003DF9 RID: 15865 RVA: 0x000CD79C File Offset: 0x000CBB9C
		public static void AddUnLockLevel(FlatBufferBuilder builder, int UnLockLevel)
		{
			builder.AddInt(4, UnLockLevel, 0);
		}

		// Token: 0x06003DFA RID: 15866 RVA: 0x000CD7A7 File Offset: 0x000CBBA7
		public static void AddIcons(FlatBufferBuilder builder, VectorOffset IconsOffset)
		{
			builder.AddOffset(5, IconsOffset.Value, 0);
		}

		// Token: 0x06003DFB RID: 15867 RVA: 0x000CD7B8 File Offset: 0x000CBBB8
		public static VectorOffset CreateIconsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003DFC RID: 15868 RVA: 0x000CD7FE File Offset: 0x000CBBFE
		public static void StartIconsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003DFD RID: 15869 RVA: 0x000CD809 File Offset: 0x000CBC09
		public static void AddMissionIds(FlatBufferBuilder builder, VectorOffset missionIdsOffset)
		{
			builder.AddOffset(6, missionIdsOffset.Value, 0);
		}

		// Token: 0x06003DFE RID: 15870 RVA: 0x000CD81C File Offset: 0x000CBC1C
		public static VectorOffset CreateMissionIdsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003DFF RID: 15871 RVA: 0x000CD859 File Offset: 0x000CBC59
		public static void StartMissionIdsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003E00 RID: 15872 RVA: 0x000CD864 File Offset: 0x000CBC64
		public static Offset<LegendMainTable> EndLegendMainTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LegendMainTable>(value);
		}

		// Token: 0x06003E01 RID: 15873 RVA: 0x000CD87E File Offset: 0x000CBC7E
		public static void FinishLegendMainTableBuffer(FlatBufferBuilder builder, Offset<LegendMainTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017D9 RID: 6105
		private Table __p = new Table();

		// Token: 0x040017DA RID: 6106
		private FlatBufferArray<int> LinkItemsValue;

		// Token: 0x040017DB RID: 6107
		private FlatBufferArray<string> IconsValue;

		// Token: 0x040017DC RID: 6108
		private FlatBufferArray<int> missionIdsValue;

		// Token: 0x020004D2 RID: 1234
		public enum eCrypt
		{
			// Token: 0x040017DE RID: 6110
			code = 89418144
		}
	}
}
