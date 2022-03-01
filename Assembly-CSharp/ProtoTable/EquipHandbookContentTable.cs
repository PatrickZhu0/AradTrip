using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003EA RID: 1002
	public class EquipHandbookContentTable : IFlatbufferObject
	{
		// Token: 0x17000AE4 RID: 2788
		// (get) Token: 0x06002DC1 RID: 11713 RVA: 0x000A7344 File Offset: 0x000A5744
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002DC2 RID: 11714 RVA: 0x000A7351 File Offset: 0x000A5751
		public static EquipHandbookContentTable GetRootAsEquipHandbookContentTable(ByteBuffer _bb)
		{
			return EquipHandbookContentTable.GetRootAsEquipHandbookContentTable(_bb, new EquipHandbookContentTable());
		}

		// Token: 0x06002DC3 RID: 11715 RVA: 0x000A735E File Offset: 0x000A575E
		public static EquipHandbookContentTable GetRootAsEquipHandbookContentTable(ByteBuffer _bb, EquipHandbookContentTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002DC4 RID: 11716 RVA: 0x000A737A File Offset: 0x000A577A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002DC5 RID: 11717 RVA: 0x000A7394 File Offset: 0x000A5794
		public EquipHandbookContentTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AE5 RID: 2789
		// (get) Token: 0x06002DC6 RID: 11718 RVA: 0x000A73A0 File Offset: 0x000A57A0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-230642203 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AE6 RID: 2790
		// (get) Token: 0x06002DC7 RID: 11719 RVA: 0x000A73EC File Offset: 0x000A57EC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002DC8 RID: 11720 RVA: 0x000A742E File Offset: 0x000A582E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000AE7 RID: 2791
		// (get) Token: 0x06002DC9 RID: 11721 RVA: 0x000A743C File Offset: 0x000A583C
		public int SortOrder
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-230642203 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AE8 RID: 2792
		// (get) Token: 0x06002DCA RID: 11722 RVA: 0x000A7488 File Offset: 0x000A5888
		public EquipHandbookContentTable.eType Type
		{
			get
			{
				int num = this.__p.__offset(10);
				return (EquipHandbookContentTable.eType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AE9 RID: 2793
		// (get) Token: 0x06002DCB RID: 11723 RVA: 0x000A74CC File Offset: 0x000A58CC
		public bool IsDefaultTab
		{
			get
			{
				int num = this.__p.__offset(12);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000AEA RID: 2794
		// (get) Token: 0x06002DCC RID: 11724 RVA: 0x000A7518 File Offset: 0x000A5918
		public bool IsShowEquipScore
		{
			get
			{
				int num = this.__p.__offset(14);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000AEB RID: 2795
		// (get) Token: 0x06002DCD RID: 11725 RVA: 0x000A7564 File Offset: 0x000A5964
		public bool IsFilterWithLevel
		{
			get
			{
				int num = this.__p.__offset(16);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x17000AEC RID: 2796
		// (get) Token: 0x06002DCE RID: 11726 RVA: 0x000A75B0 File Offset: 0x000A59B0
		public bool IsFilterWithEquipScore
		{
			get
			{
				int num = this.__p.__offset(18);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002DCF RID: 11727 RVA: 0x000A75FC File Offset: 0x000A59FC
		public static Offset<EquipHandbookContentTable> CreateEquipHandbookContentTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int SortOrder = 0, EquipHandbookContentTable.eType Type = EquipHandbookContentTable.eType.Collect, bool IsDefaultTab = false, bool IsShowEquipScore = false, bool IsFilterWithLevel = false, bool IsFilterWithEquipScore = false)
		{
			builder.StartObject(8);
			EquipHandbookContentTable.AddType(builder, Type);
			EquipHandbookContentTable.AddSortOrder(builder, SortOrder);
			EquipHandbookContentTable.AddName(builder, NameOffset);
			EquipHandbookContentTable.AddID(builder, ID);
			EquipHandbookContentTable.AddIsFilterWithEquipScore(builder, IsFilterWithEquipScore);
			EquipHandbookContentTable.AddIsFilterWithLevel(builder, IsFilterWithLevel);
			EquipHandbookContentTable.AddIsShowEquipScore(builder, IsShowEquipScore);
			EquipHandbookContentTable.AddIsDefaultTab(builder, IsDefaultTab);
			return EquipHandbookContentTable.EndEquipHandbookContentTable(builder);
		}

		// Token: 0x06002DD0 RID: 11728 RVA: 0x000A7653 File Offset: 0x000A5A53
		public static void StartEquipHandbookContentTable(FlatBufferBuilder builder)
		{
			builder.StartObject(8);
		}

		// Token: 0x06002DD1 RID: 11729 RVA: 0x000A765C File Offset: 0x000A5A5C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002DD2 RID: 11730 RVA: 0x000A7667 File Offset: 0x000A5A67
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002DD3 RID: 11731 RVA: 0x000A7678 File Offset: 0x000A5A78
		public static void AddSortOrder(FlatBufferBuilder builder, int SortOrder)
		{
			builder.AddInt(2, SortOrder, 0);
		}

		// Token: 0x06002DD4 RID: 11732 RVA: 0x000A7683 File Offset: 0x000A5A83
		public static void AddType(FlatBufferBuilder builder, EquipHandbookContentTable.eType Type)
		{
			builder.AddInt(3, (int)Type, 0);
		}

		// Token: 0x06002DD5 RID: 11733 RVA: 0x000A768E File Offset: 0x000A5A8E
		public static void AddIsDefaultTab(FlatBufferBuilder builder, bool IsDefaultTab)
		{
			builder.AddBool(4, IsDefaultTab, false);
		}

		// Token: 0x06002DD6 RID: 11734 RVA: 0x000A7699 File Offset: 0x000A5A99
		public static void AddIsShowEquipScore(FlatBufferBuilder builder, bool IsShowEquipScore)
		{
			builder.AddBool(5, IsShowEquipScore, false);
		}

		// Token: 0x06002DD7 RID: 11735 RVA: 0x000A76A4 File Offset: 0x000A5AA4
		public static void AddIsFilterWithLevel(FlatBufferBuilder builder, bool IsFilterWithLevel)
		{
			builder.AddBool(6, IsFilterWithLevel, false);
		}

		// Token: 0x06002DD8 RID: 11736 RVA: 0x000A76AF File Offset: 0x000A5AAF
		public static void AddIsFilterWithEquipScore(FlatBufferBuilder builder, bool IsFilterWithEquipScore)
		{
			builder.AddBool(7, IsFilterWithEquipScore, false);
		}

		// Token: 0x06002DD9 RID: 11737 RVA: 0x000A76BC File Offset: 0x000A5ABC
		public static Offset<EquipHandbookContentTable> EndEquipHandbookContentTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipHandbookContentTable>(value);
		}

		// Token: 0x06002DDA RID: 11738 RVA: 0x000A76D6 File Offset: 0x000A5AD6
		public static void FinishEquipHandbookContentTableBuffer(FlatBufferBuilder builder, Offset<EquipHandbookContentTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001355 RID: 4949
		private Table __p = new Table();

		// Token: 0x020003EB RID: 1003
		public enum eType
		{
			// Token: 0x04001357 RID: 4951
			Collect,
			// Token: 0x04001358 RID: 4952
			Single
		}

		// Token: 0x020003EC RID: 1004
		public enum eCrypt
		{
			// Token: 0x0400135A RID: 4954
			code = -230642203
		}
	}
}
