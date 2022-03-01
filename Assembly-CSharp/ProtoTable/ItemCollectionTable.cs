using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004B0 RID: 1200
	public class ItemCollectionTable : IFlatbufferObject
	{
		// Token: 0x17000EDB RID: 3803
		// (get) Token: 0x06003A8E RID: 14990 RVA: 0x000C4CB0 File Offset: 0x000C30B0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003A8F RID: 14991 RVA: 0x000C4CBD File Offset: 0x000C30BD
		public static ItemCollectionTable GetRootAsItemCollectionTable(ByteBuffer _bb)
		{
			return ItemCollectionTable.GetRootAsItemCollectionTable(_bb, new ItemCollectionTable());
		}

		// Token: 0x06003A90 RID: 14992 RVA: 0x000C4CCA File Offset: 0x000C30CA
		public static ItemCollectionTable GetRootAsItemCollectionTable(ByteBuffer _bb, ItemCollectionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003A91 RID: 14993 RVA: 0x000C4CE6 File Offset: 0x000C30E6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003A92 RID: 14994 RVA: 0x000C4D00 File Offset: 0x000C3100
		public ItemCollectionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EDC RID: 3804
		// (get) Token: 0x06003A93 RID: 14995 RVA: 0x000C4D0C File Offset: 0x000C310C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1978091175 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EDD RID: 3805
		// (get) Token: 0x06003A94 RID: 14996 RVA: 0x000C4D58 File Offset: 0x000C3158
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A95 RID: 14997 RVA: 0x000C4D9A File Offset: 0x000C319A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000EDE RID: 3806
		// (get) Token: 0x06003A96 RID: 14998 RVA: 0x000C4DA8 File Offset: 0x000C31A8
		public string Icon
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A97 RID: 14999 RVA: 0x000C4DEA File Offset: 0x000C31EA
		public ArraySegment<byte>? GetIconBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000EDF RID: 3807
		// (get) Token: 0x06003A98 RID: 15000 RVA: 0x000C4DF8 File Offset: 0x000C31F8
		public string Level
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A99 RID: 15001 RVA: 0x000C4E3B File Offset: 0x000C323B
		public ArraySegment<byte>? GetLevelBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06003A9A RID: 15002 RVA: 0x000C4E4C File Offset: 0x000C324C
		public int ColorArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1978091175 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000EE0 RID: 3808
		// (get) Token: 0x06003A9B RID: 15003 RVA: 0x000C4E9C File Offset: 0x000C329C
		public int ColorLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003A9C RID: 15004 RVA: 0x000C4ECF File Offset: 0x000C32CF
		public ArraySegment<byte>? GetColorBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000EE1 RID: 3809
		// (get) Token: 0x06003A9D RID: 15005 RVA: 0x000C4EDE File Offset: 0x000C32DE
		public FlatBufferArray<int> Color
		{
			get
			{
				if (this.ColorValue == null)
				{
					this.ColorValue = new FlatBufferArray<int>(new Func<int, int>(this.ColorArray), this.ColorLength);
				}
				return this.ColorValue;
			}
		}

		// Token: 0x17000EE2 RID: 3810
		// (get) Token: 0x06003A9E RID: 15006 RVA: 0x000C4F10 File Offset: 0x000C3310
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1978091175 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EE3 RID: 3811
		// (get) Token: 0x06003A9F RID: 15007 RVA: 0x000C4F5C File Offset: 0x000C335C
		public ItemCollectionTable.eTipsType TipsType
		{
			get
			{
				int num = this.__p.__offset(16);
				return (ItemCollectionTable.eTipsType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EE4 RID: 3812
		// (get) Token: 0x06003AA0 RID: 15008 RVA: 0x000C4FA0 File Offset: 0x000C33A0
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : (-1978091175 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EE5 RID: 3813
		// (get) Token: 0x06003AA1 RID: 15009 RVA: 0x000C4FEC File Offset: 0x000C33EC
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003AA2 RID: 15010 RVA: 0x000C502F File Offset: 0x000C342F
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x06003AA3 RID: 15011 RVA: 0x000C5040 File Offset: 0x000C3440
		public UnionCell TipsContentArray(int j)
		{
			int num = this.__p.__offset(22);
			return (num == 0) ? UnionCell.Default() : new UnionCell().__assign(this.__p.__indirect(this.__p.__vector(num) + j * 4), this.__p.bb);
		}

		// Token: 0x17000EE6 RID: 3814
		// (get) Token: 0x06003AA4 RID: 15012 RVA: 0x000C509C File Offset: 0x000C349C
		public int TipsContentLength
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000EE7 RID: 3815
		// (get) Token: 0x06003AA5 RID: 15013 RVA: 0x000C50CF File Offset: 0x000C34CF
		public FlatBufferArray<UnionCell> TipsContent
		{
			get
			{
				if (this.TipsContentValue == null)
				{
					this.TipsContentValue = new FlatBufferArray<UnionCell>(new Func<int, UnionCell>(this.TipsContentArray), this.TipsContentLength);
				}
				return this.TipsContentValue;
			}
		}

		// Token: 0x06003AA6 RID: 15014 RVA: 0x000C5100 File Offset: 0x000C3500
		public string ItemsArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000EE8 RID: 3816
		// (get) Token: 0x06003AA7 RID: 15015 RVA: 0x000C5148 File Offset: 0x000C3548
		public int ItemsLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000EE9 RID: 3817
		// (get) Token: 0x06003AA8 RID: 15016 RVA: 0x000C517B File Offset: 0x000C357B
		public FlatBufferArray<string> Items
		{
			get
			{
				if (this.ItemsValue == null)
				{
					this.ItemsValue = new FlatBufferArray<string>(new Func<int, string>(this.ItemsArray), this.ItemsLength);
				}
				return this.ItemsValue;
			}
		}

		// Token: 0x06003AA9 RID: 15017 RVA: 0x000C51AC File Offset: 0x000C35AC
		public static Offset<ItemCollectionTable> CreateItemCollectionTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset IconOffset = default(StringOffset), StringOffset LevelOffset = default(StringOffset), VectorOffset ColorOffset = default(VectorOffset), int Color2 = 0, ItemCollectionTable.eTipsType TipsType = ItemCollectionTable.eTipsType.TipsType_None, int ItemID = 0, StringOffset DescOffset = default(StringOffset), VectorOffset TipsContentOffset = default(VectorOffset), VectorOffset ItemsOffset = default(VectorOffset))
		{
			builder.StartObject(11);
			ItemCollectionTable.AddItems(builder, ItemsOffset);
			ItemCollectionTable.AddTipsContent(builder, TipsContentOffset);
			ItemCollectionTable.AddDesc(builder, DescOffset);
			ItemCollectionTable.AddItemID(builder, ItemID);
			ItemCollectionTable.AddTipsType(builder, TipsType);
			ItemCollectionTable.AddColor2(builder, Color2);
			ItemCollectionTable.AddColor(builder, ColorOffset);
			ItemCollectionTable.AddLevel(builder, LevelOffset);
			ItemCollectionTable.AddIcon(builder, IconOffset);
			ItemCollectionTable.AddName(builder, NameOffset);
			ItemCollectionTable.AddID(builder, ID);
			return ItemCollectionTable.EndItemCollectionTable(builder);
		}

		// Token: 0x06003AAA RID: 15018 RVA: 0x000C521C File Offset: 0x000C361C
		public static void StartItemCollectionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06003AAB RID: 15019 RVA: 0x000C5226 File Offset: 0x000C3626
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003AAC RID: 15020 RVA: 0x000C5231 File Offset: 0x000C3631
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003AAD RID: 15021 RVA: 0x000C5242 File Offset: 0x000C3642
		public static void AddIcon(FlatBufferBuilder builder, StringOffset IconOffset)
		{
			builder.AddOffset(2, IconOffset.Value, 0);
		}

		// Token: 0x06003AAE RID: 15022 RVA: 0x000C5253 File Offset: 0x000C3653
		public static void AddLevel(FlatBufferBuilder builder, StringOffset LevelOffset)
		{
			builder.AddOffset(3, LevelOffset.Value, 0);
		}

		// Token: 0x06003AAF RID: 15023 RVA: 0x000C5264 File Offset: 0x000C3664
		public static void AddColor(FlatBufferBuilder builder, VectorOffset ColorOffset)
		{
			builder.AddOffset(4, ColorOffset.Value, 0);
		}

		// Token: 0x06003AB0 RID: 15024 RVA: 0x000C5278 File Offset: 0x000C3678
		public static VectorOffset CreateColorVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003AB1 RID: 15025 RVA: 0x000C52B5 File Offset: 0x000C36B5
		public static void StartColorVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003AB2 RID: 15026 RVA: 0x000C52C0 File Offset: 0x000C36C0
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(5, Color2, 0);
		}

		// Token: 0x06003AB3 RID: 15027 RVA: 0x000C52CB File Offset: 0x000C36CB
		public static void AddTipsType(FlatBufferBuilder builder, ItemCollectionTable.eTipsType TipsType)
		{
			builder.AddInt(6, (int)TipsType, 0);
		}

		// Token: 0x06003AB4 RID: 15028 RVA: 0x000C52D6 File Offset: 0x000C36D6
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(7, ItemID, 0);
		}

		// Token: 0x06003AB5 RID: 15029 RVA: 0x000C52E1 File Offset: 0x000C36E1
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(8, DescOffset.Value, 0);
		}

		// Token: 0x06003AB6 RID: 15030 RVA: 0x000C52F2 File Offset: 0x000C36F2
		public static void AddTipsContent(FlatBufferBuilder builder, VectorOffset TipsContentOffset)
		{
			builder.AddOffset(9, TipsContentOffset.Value, 0);
		}

		// Token: 0x06003AB7 RID: 15031 RVA: 0x000C5304 File Offset: 0x000C3704
		public static VectorOffset CreateTipsContentVector(FlatBufferBuilder builder, Offset<UnionCell>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003AB8 RID: 15032 RVA: 0x000C534A File Offset: 0x000C374A
		public static void StartTipsContentVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003AB9 RID: 15033 RVA: 0x000C5355 File Offset: 0x000C3755
		public static void AddItems(FlatBufferBuilder builder, VectorOffset ItemsOffset)
		{
			builder.AddOffset(10, ItemsOffset.Value, 0);
		}

		// Token: 0x06003ABA RID: 15034 RVA: 0x000C5368 File Offset: 0x000C3768
		public static VectorOffset CreateItemsVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003ABB RID: 15035 RVA: 0x000C53AE File Offset: 0x000C37AE
		public static void StartItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003ABC RID: 15036 RVA: 0x000C53BC File Offset: 0x000C37BC
		public static Offset<ItemCollectionTable> EndItemCollectionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ItemCollectionTable>(value);
		}

		// Token: 0x06003ABD RID: 15037 RVA: 0x000C53D6 File Offset: 0x000C37D6
		public static void FinishItemCollectionTableBuffer(FlatBufferBuilder builder, Offset<ItemCollectionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001677 RID: 5751
		private Table __p = new Table();

		// Token: 0x04001678 RID: 5752
		private FlatBufferArray<int> ColorValue;

		// Token: 0x04001679 RID: 5753
		private FlatBufferArray<UnionCell> TipsContentValue;

		// Token: 0x0400167A RID: 5754
		private FlatBufferArray<string> ItemsValue;

		// Token: 0x020004B1 RID: 1201
		public enum eTipsType
		{
			// Token: 0x0400167C RID: 5756
			TipsType_None,
			// Token: 0x0400167D RID: 5757
			SINGLE,
			// Token: 0x0400167E RID: 5758
			COLLECTION
		}

		// Token: 0x020004B2 RID: 1202
		public enum eCrypt
		{
			// Token: 0x04001680 RID: 5760
			code = -1978091175
		}
	}
}
