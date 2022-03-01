using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000318 RID: 792
	public class ChiJiGiftPackTable : IFlatbufferObject
	{
		// Token: 0x170005EE RID: 1518
		// (get) Token: 0x06001F58 RID: 8024 RVA: 0x00083E64 File Offset: 0x00082264
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001F59 RID: 8025 RVA: 0x00083E71 File Offset: 0x00082271
		public static ChiJiGiftPackTable GetRootAsChiJiGiftPackTable(ByteBuffer _bb)
		{
			return ChiJiGiftPackTable.GetRootAsChiJiGiftPackTable(_bb, new ChiJiGiftPackTable());
		}

		// Token: 0x06001F5A RID: 8026 RVA: 0x00083E7E File Offset: 0x0008227E
		public static ChiJiGiftPackTable GetRootAsChiJiGiftPackTable(ByteBuffer _bb, ChiJiGiftPackTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001F5B RID: 8027 RVA: 0x00083E9A File Offset: 0x0008229A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001F5C RID: 8028 RVA: 0x00083EB4 File Offset: 0x000822B4
		public ChiJiGiftPackTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170005EF RID: 1519
		// (get) Token: 0x06001F5D RID: 8029 RVA: 0x00083EC0 File Offset: 0x000822C0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-829597410 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005F0 RID: 1520
		// (get) Token: 0x06001F5E RID: 8030 RVA: 0x00083F0C File Offset: 0x0008230C
		public ChiJiGiftPackTable.eFilterType FilterType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (ChiJiGiftPackTable.eFilterType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170005F1 RID: 1521
		// (get) Token: 0x06001F5F RID: 8031 RVA: 0x00083F50 File Offset: 0x00082350
		public int FilterCount
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-829597410 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001F60 RID: 8032 RVA: 0x00083F9C File Offset: 0x0008239C
		public int ItemsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-829597410 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170005F2 RID: 1522
		// (get) Token: 0x06001F61 RID: 8033 RVA: 0x00083FEC File Offset: 0x000823EC
		public int ItemsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001F62 RID: 8034 RVA: 0x0008401F File Offset: 0x0008241F
		public ArraySegment<byte>? GetItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170005F3 RID: 1523
		// (get) Token: 0x06001F63 RID: 8035 RVA: 0x0008402E File Offset: 0x0008242E
		public FlatBufferArray<int> Items
		{
			get
			{
				if (this.ItemsValue == null)
				{
					this.ItemsValue = new FlatBufferArray<int>(new Func<int, int>(this.ItemsArray), this.ItemsLength);
				}
				return this.ItemsValue;
			}
		}

		// Token: 0x170005F4 RID: 1524
		// (get) Token: 0x06001F64 RID: 8036 RVA: 0x00084060 File Offset: 0x00082460
		public int UIType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-829597410 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001F65 RID: 8037 RVA: 0x000840AA File Offset: 0x000824AA
		public static Offset<ChiJiGiftPackTable> CreateChiJiGiftPackTable(FlatBufferBuilder builder, int ID = 0, ChiJiGiftPackTable.eFilterType FilterType = ChiJiGiftPackTable.eFilterType.None, int FilterCount = 0, VectorOffset ItemsOffset = default(VectorOffset), int UIType = 0)
		{
			builder.StartObject(5);
			ChiJiGiftPackTable.AddUIType(builder, UIType);
			ChiJiGiftPackTable.AddItems(builder, ItemsOffset);
			ChiJiGiftPackTable.AddFilterCount(builder, FilterCount);
			ChiJiGiftPackTable.AddFilterType(builder, FilterType);
			ChiJiGiftPackTable.AddID(builder, ID);
			return ChiJiGiftPackTable.EndChiJiGiftPackTable(builder);
		}

		// Token: 0x06001F66 RID: 8038 RVA: 0x000840DE File Offset: 0x000824DE
		public static void StartChiJiGiftPackTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06001F67 RID: 8039 RVA: 0x000840E7 File Offset: 0x000824E7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001F68 RID: 8040 RVA: 0x000840F2 File Offset: 0x000824F2
		public static void AddFilterType(FlatBufferBuilder builder, ChiJiGiftPackTable.eFilterType FilterType)
		{
			builder.AddInt(1, (int)FilterType, 0);
		}

		// Token: 0x06001F69 RID: 8041 RVA: 0x000840FD File Offset: 0x000824FD
		public static void AddFilterCount(FlatBufferBuilder builder, int FilterCount)
		{
			builder.AddInt(2, FilterCount, 0);
		}

		// Token: 0x06001F6A RID: 8042 RVA: 0x00084108 File Offset: 0x00082508
		public static void AddItems(FlatBufferBuilder builder, VectorOffset ItemsOffset)
		{
			builder.AddOffset(3, ItemsOffset.Value, 0);
		}

		// Token: 0x06001F6B RID: 8043 RVA: 0x0008411C File Offset: 0x0008251C
		public static VectorOffset CreateItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001F6C RID: 8044 RVA: 0x00084159 File Offset: 0x00082559
		public static void StartItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001F6D RID: 8045 RVA: 0x00084164 File Offset: 0x00082564
		public static void AddUIType(FlatBufferBuilder builder, int UIType)
		{
			builder.AddInt(4, UIType, 0);
		}

		// Token: 0x06001F6E RID: 8046 RVA: 0x00084170 File Offset: 0x00082570
		public static Offset<ChiJiGiftPackTable> EndChiJiGiftPackTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiGiftPackTable>(value);
		}

		// Token: 0x06001F6F RID: 8047 RVA: 0x0008418A File Offset: 0x0008258A
		public static void FinishChiJiGiftPackTableBuffer(FlatBufferBuilder builder, Offset<ChiJiGiftPackTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F5C RID: 3932
		private Table __p = new Table();

		// Token: 0x04000F5D RID: 3933
		private FlatBufferArray<int> ItemsValue;

		// Token: 0x02000319 RID: 793
		public enum eFilterType
		{
			// Token: 0x04000F5F RID: 3935
			None,
			// Token: 0x04000F60 RID: 3936
			Job,
			// Token: 0x04000F61 RID: 3937
			Random,
			// Token: 0x04000F62 RID: 3938
			Custom,
			// Token: 0x04000F63 RID: 3939
			CustomWithJob,
			// Token: 0x04000F64 RID: 3940
			ChiJiEquip
		}

		// Token: 0x0200031A RID: 794
		public enum eCrypt
		{
			// Token: 0x04000F66 RID: 3942
			code = -829597410
		}
	}
}
