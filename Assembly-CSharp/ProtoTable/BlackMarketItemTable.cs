using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002E2 RID: 738
	public class BlackMarketItemTable : IFlatbufferObject
	{
		// Token: 0x1700046B RID: 1131
		// (get) Token: 0x06001B03 RID: 6915 RVA: 0x00079324 File Offset: 0x00077724
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001B04 RID: 6916 RVA: 0x00079331 File Offset: 0x00077731
		public static BlackMarketItemTable GetRootAsBlackMarketItemTable(ByteBuffer _bb)
		{
			return BlackMarketItemTable.GetRootAsBlackMarketItemTable(_bb, new BlackMarketItemTable());
		}

		// Token: 0x06001B05 RID: 6917 RVA: 0x0007933E File Offset: 0x0007773E
		public static BlackMarketItemTable GetRootAsBlackMarketItemTable(ByteBuffer _bb, BlackMarketItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001B06 RID: 6918 RVA: 0x0007935A File Offset: 0x0007775A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001B07 RID: 6919 RVA: 0x00079374 File Offset: 0x00077774
		public BlackMarketItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700046C RID: 1132
		// (get) Token: 0x06001B08 RID: 6920 RVA: 0x00079380 File Offset: 0x00077780
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1589758824 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700046D RID: 1133
		// (get) Token: 0x06001B09 RID: 6921 RVA: 0x000793CC File Offset: 0x000777CC
		public string buyType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B0A RID: 6922 RVA: 0x0007940E File Offset: 0x0007780E
		public ArraySegment<byte>? GetBuyTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x1700046E RID: 1134
		// (get) Token: 0x06001B0B RID: 6923 RVA: 0x0007941C File Offset: 0x0007781C
		public int groupId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1589758824 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700046F RID: 1135
		// (get) Token: 0x06001B0C RID: 6924 RVA: 0x00079468 File Offset: 0x00077868
		public int itemId
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1589758824 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000470 RID: 1136
		// (get) Token: 0x06001B0D RID: 6925 RVA: 0x000794B4 File Offset: 0x000778B4
		public int recomPrice
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1589758824 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000471 RID: 1137
		// (get) Token: 0x06001B0E RID: 6926 RVA: 0x00079500 File Offset: 0x00077900
		public string lowerPrice
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B0F RID: 6927 RVA: 0x00079543 File Offset: 0x00077943
		public ArraySegment<byte>? GetLowerPriceBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000472 RID: 1138
		// (get) Token: 0x06001B10 RID: 6928 RVA: 0x00079554 File Offset: 0x00077954
		public string lowerPriceWt
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B11 RID: 6929 RVA: 0x00079597 File Offset: 0x00077997
		public ArraySegment<byte>? GetLowerPriceWtBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000473 RID: 1139
		// (get) Token: 0x06001B12 RID: 6930 RVA: 0x000795A8 File Offset: 0x000779A8
		public string upperPrice
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B13 RID: 6931 RVA: 0x000795EB File Offset: 0x000779EB
		public ArraySegment<byte>? GetUpperPriceBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000474 RID: 1140
		// (get) Token: 0x06001B14 RID: 6932 RVA: 0x000795FC File Offset: 0x000779FC
		public string upperPriceWt
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B15 RID: 6933 RVA: 0x0007963F File Offset: 0x00077A3F
		public ArraySegment<byte>? GetUpperPriceWtBytes()
		{
			return this.__p.__vector_as_arraysegment(20);
		}

		// Token: 0x17000475 RID: 1141
		// (get) Token: 0x06001B16 RID: 6934 RVA: 0x00079650 File Offset: 0x00077A50
		public string subBuyType
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001B17 RID: 6935 RVA: 0x00079693 File Offset: 0x00077A93
		public ArraySegment<byte>? GetSubBuyTypeBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x17000476 RID: 1142
		// (get) Token: 0x06001B18 RID: 6936 RVA: 0x000796A4 File Offset: 0x00077AA4
		public int fixUplimit
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (1589758824 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001B19 RID: 6937 RVA: 0x000796F0 File Offset: 0x00077AF0
		public static Offset<BlackMarketItemTable> CreateBlackMarketItemTable(FlatBufferBuilder builder, int ID = 0, StringOffset buyTypeOffset = default(StringOffset), int groupId = 0, int itemId = 0, int recomPrice = 0, StringOffset lowerPriceOffset = default(StringOffset), StringOffset lowerPriceWtOffset = default(StringOffset), StringOffset upperPriceOffset = default(StringOffset), StringOffset upperPriceWtOffset = default(StringOffset), StringOffset subBuyTypeOffset = default(StringOffset), int fixUplimit = 0)
		{
			builder.StartObject(11);
			BlackMarketItemTable.AddFixUplimit(builder, fixUplimit);
			BlackMarketItemTable.AddSubBuyType(builder, subBuyTypeOffset);
			BlackMarketItemTable.AddUpperPriceWt(builder, upperPriceWtOffset);
			BlackMarketItemTable.AddUpperPrice(builder, upperPriceOffset);
			BlackMarketItemTable.AddLowerPriceWt(builder, lowerPriceWtOffset);
			BlackMarketItemTable.AddLowerPrice(builder, lowerPriceOffset);
			BlackMarketItemTable.AddRecomPrice(builder, recomPrice);
			BlackMarketItemTable.AddItemId(builder, itemId);
			BlackMarketItemTable.AddGroupId(builder, groupId);
			BlackMarketItemTable.AddBuyType(builder, buyTypeOffset);
			BlackMarketItemTable.AddID(builder, ID);
			return BlackMarketItemTable.EndBlackMarketItemTable(builder);
		}

		// Token: 0x06001B1A RID: 6938 RVA: 0x00079760 File Offset: 0x00077B60
		public static void StartBlackMarketItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(11);
		}

		// Token: 0x06001B1B RID: 6939 RVA: 0x0007976A File Offset: 0x00077B6A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001B1C RID: 6940 RVA: 0x00079775 File Offset: 0x00077B75
		public static void AddBuyType(FlatBufferBuilder builder, StringOffset buyTypeOffset)
		{
			builder.AddOffset(1, buyTypeOffset.Value, 0);
		}

		// Token: 0x06001B1D RID: 6941 RVA: 0x00079786 File Offset: 0x00077B86
		public static void AddGroupId(FlatBufferBuilder builder, int groupId)
		{
			builder.AddInt(2, groupId, 0);
		}

		// Token: 0x06001B1E RID: 6942 RVA: 0x00079791 File Offset: 0x00077B91
		public static void AddItemId(FlatBufferBuilder builder, int itemId)
		{
			builder.AddInt(3, itemId, 0);
		}

		// Token: 0x06001B1F RID: 6943 RVA: 0x0007979C File Offset: 0x00077B9C
		public static void AddRecomPrice(FlatBufferBuilder builder, int recomPrice)
		{
			builder.AddInt(4, recomPrice, 0);
		}

		// Token: 0x06001B20 RID: 6944 RVA: 0x000797A7 File Offset: 0x00077BA7
		public static void AddLowerPrice(FlatBufferBuilder builder, StringOffset lowerPriceOffset)
		{
			builder.AddOffset(5, lowerPriceOffset.Value, 0);
		}

		// Token: 0x06001B21 RID: 6945 RVA: 0x000797B8 File Offset: 0x00077BB8
		public static void AddLowerPriceWt(FlatBufferBuilder builder, StringOffset lowerPriceWtOffset)
		{
			builder.AddOffset(6, lowerPriceWtOffset.Value, 0);
		}

		// Token: 0x06001B22 RID: 6946 RVA: 0x000797C9 File Offset: 0x00077BC9
		public static void AddUpperPrice(FlatBufferBuilder builder, StringOffset upperPriceOffset)
		{
			builder.AddOffset(7, upperPriceOffset.Value, 0);
		}

		// Token: 0x06001B23 RID: 6947 RVA: 0x000797DA File Offset: 0x00077BDA
		public static void AddUpperPriceWt(FlatBufferBuilder builder, StringOffset upperPriceWtOffset)
		{
			builder.AddOffset(8, upperPriceWtOffset.Value, 0);
		}

		// Token: 0x06001B24 RID: 6948 RVA: 0x000797EB File Offset: 0x00077BEB
		public static void AddSubBuyType(FlatBufferBuilder builder, StringOffset subBuyTypeOffset)
		{
			builder.AddOffset(9, subBuyTypeOffset.Value, 0);
		}

		// Token: 0x06001B25 RID: 6949 RVA: 0x000797FD File Offset: 0x00077BFD
		public static void AddFixUplimit(FlatBufferBuilder builder, int fixUplimit)
		{
			builder.AddInt(10, fixUplimit, 0);
		}

		// Token: 0x06001B26 RID: 6950 RVA: 0x0007980C File Offset: 0x00077C0C
		public static Offset<BlackMarketItemTable> EndBlackMarketItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<BlackMarketItemTable>(value);
		}

		// Token: 0x06001B27 RID: 6951 RVA: 0x00079826 File Offset: 0x00077C26
		public static void FinishBlackMarketItemTableBuffer(FlatBufferBuilder builder, Offset<BlackMarketItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000EBA RID: 3770
		private Table __p = new Table();

		// Token: 0x020002E3 RID: 739
		public enum eCrypt
		{
			// Token: 0x04000EBC RID: 3772
			code = 1589758824
		}
	}
}
