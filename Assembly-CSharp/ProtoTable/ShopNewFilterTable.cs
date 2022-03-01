using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005B1 RID: 1457
	public class ShopNewFilterTable : IFlatbufferObject
	{
		// Token: 0x17001494 RID: 5268
		// (get) Token: 0x06004B92 RID: 19346 RVA: 0x000ECF10 File Offset: 0x000EB310
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004B93 RID: 19347 RVA: 0x000ECF1D File Offset: 0x000EB31D
		public static ShopNewFilterTable GetRootAsShopNewFilterTable(ByteBuffer _bb)
		{
			return ShopNewFilterTable.GetRootAsShopNewFilterTable(_bb, new ShopNewFilterTable());
		}

		// Token: 0x06004B94 RID: 19348 RVA: 0x000ECF2A File Offset: 0x000EB32A
		public static ShopNewFilterTable GetRootAsShopNewFilterTable(ByteBuffer _bb, ShopNewFilterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004B95 RID: 19349 RVA: 0x000ECF46 File Offset: 0x000EB346
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004B96 RID: 19350 RVA: 0x000ECF60 File Offset: 0x000EB360
		public ShopNewFilterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001495 RID: 5269
		// (get) Token: 0x06004B97 RID: 19351 RVA: 0x000ECF6C File Offset: 0x000EB36C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1835018306 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001496 RID: 5270
		// (get) Token: 0x06004B98 RID: 19352 RVA: 0x000ECFB8 File Offset: 0x000EB3B8
		public int FilterItemType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1835018306 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001497 RID: 5271
		// (get) Token: 0x06004B99 RID: 19353 RVA: 0x000ED004 File Offset: 0x000EB404
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B9A RID: 19354 RVA: 0x000ED046 File Offset: 0x000EB446
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001498 RID: 5272
		// (get) Token: 0x06004B9B RID: 19355 RVA: 0x000ED054 File Offset: 0x000EB454
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1835018306 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004B9C RID: 19356 RVA: 0x000ED0A0 File Offset: 0x000EB4A0
		public int ParameterArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (1835018306 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001499 RID: 5273
		// (get) Token: 0x06004B9D RID: 19357 RVA: 0x000ED0F0 File Offset: 0x000EB4F0
		public int ParameterLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004B9E RID: 19358 RVA: 0x000ED123 File Offset: 0x000EB523
		public ArraySegment<byte>? GetParameterBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700149A RID: 5274
		// (get) Token: 0x06004B9F RID: 19359 RVA: 0x000ED132 File Offset: 0x000EB532
		public FlatBufferArray<int> Parameter
		{
			get
			{
				if (this.ParameterValue == null)
				{
					this.ParameterValue = new FlatBufferArray<int>(new Func<int, int>(this.ParameterArray), this.ParameterLength);
				}
				return this.ParameterValue;
			}
		}

		// Token: 0x06004BA0 RID: 19360 RVA: 0x000ED162 File Offset: 0x000EB562
		public static Offset<ShopNewFilterTable> CreateShopNewFilterTable(FlatBufferBuilder builder, int ID = 0, int FilterItemType = 0, StringOffset NameOffset = default(StringOffset), int Sort = 0, VectorOffset ParameterOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			ShopNewFilterTable.AddParameter(builder, ParameterOffset);
			ShopNewFilterTable.AddSort(builder, Sort);
			ShopNewFilterTable.AddName(builder, NameOffset);
			ShopNewFilterTable.AddFilterItemType(builder, FilterItemType);
			ShopNewFilterTable.AddID(builder, ID);
			return ShopNewFilterTable.EndShopNewFilterTable(builder);
		}

		// Token: 0x06004BA1 RID: 19361 RVA: 0x000ED196 File Offset: 0x000EB596
		public static void StartShopNewFilterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004BA2 RID: 19362 RVA: 0x000ED19F File Offset: 0x000EB59F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004BA3 RID: 19363 RVA: 0x000ED1AA File Offset: 0x000EB5AA
		public static void AddFilterItemType(FlatBufferBuilder builder, int FilterItemType)
		{
			builder.AddInt(1, FilterItemType, 0);
		}

		// Token: 0x06004BA4 RID: 19364 RVA: 0x000ED1B5 File Offset: 0x000EB5B5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x06004BA5 RID: 19365 RVA: 0x000ED1C6 File Offset: 0x000EB5C6
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(3, Sort, 0);
		}

		// Token: 0x06004BA6 RID: 19366 RVA: 0x000ED1D1 File Offset: 0x000EB5D1
		public static void AddParameter(FlatBufferBuilder builder, VectorOffset ParameterOffset)
		{
			builder.AddOffset(4, ParameterOffset.Value, 0);
		}

		// Token: 0x06004BA7 RID: 19367 RVA: 0x000ED1E4 File Offset: 0x000EB5E4
		public static VectorOffset CreateParameterVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004BA8 RID: 19368 RVA: 0x000ED221 File Offset: 0x000EB621
		public static void StartParameterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004BA9 RID: 19369 RVA: 0x000ED22C File Offset: 0x000EB62C
		public static Offset<ShopNewFilterTable> EndShopNewFilterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ShopNewFilterTable>(value);
		}

		// Token: 0x06004BAA RID: 19370 RVA: 0x000ED246 File Offset: 0x000EB646
		public static void FinishShopNewFilterTableBuffer(FlatBufferBuilder builder, Offset<ShopNewFilterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B2B RID: 6955
		private Table __p = new Table();

		// Token: 0x04001B2C RID: 6956
		private FlatBufferArray<int> ParameterValue;

		// Token: 0x020005B2 RID: 1458
		public enum eCrypt
		{
			// Token: 0x04001B2E RID: 6958
			code = 1835018306
		}
	}
}
