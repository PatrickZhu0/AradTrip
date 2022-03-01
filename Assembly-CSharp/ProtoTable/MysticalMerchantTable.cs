using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000522 RID: 1314
	public class MysticalMerchantTable : IFlatbufferObject
	{
		// Token: 0x170011F7 RID: 4599
		// (get) Token: 0x06004379 RID: 17273 RVA: 0x000DAA2C File Offset: 0x000D8E2C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600437A RID: 17274 RVA: 0x000DAA39 File Offset: 0x000D8E39
		public static MysticalMerchantTable GetRootAsMysticalMerchantTable(ByteBuffer _bb)
		{
			return MysticalMerchantTable.GetRootAsMysticalMerchantTable(_bb, new MysticalMerchantTable());
		}

		// Token: 0x0600437B RID: 17275 RVA: 0x000DAA46 File Offset: 0x000D8E46
		public static MysticalMerchantTable GetRootAsMysticalMerchantTable(ByteBuffer _bb, MysticalMerchantTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600437C RID: 17276 RVA: 0x000DAA62 File Offset: 0x000D8E62
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600437D RID: 17277 RVA: 0x000DAA7C File Offset: 0x000D8E7C
		public MysticalMerchantTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011F8 RID: 4600
		// (get) Token: 0x0600437E RID: 17278 RVA: 0x000DAA88 File Offset: 0x000D8E88
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1035970500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011F9 RID: 4601
		// (get) Token: 0x0600437F RID: 17279 RVA: 0x000DAAD4 File Offset: 0x000D8ED4
		public int ShopId
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1035970500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011FA RID: 4602
		// (get) Token: 0x06004380 RID: 17280 RVA: 0x000DAB20 File Offset: 0x000D8F20
		public int Weight
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1035970500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011FB RID: 4603
		// (get) Token: 0x06004381 RID: 17281 RVA: 0x000DAB6C File Offset: 0x000D8F6C
		public int ShopNpcID
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1035970500 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004382 RID: 17282 RVA: 0x000DABB6 File Offset: 0x000D8FB6
		public static Offset<MysticalMerchantTable> CreateMysticalMerchantTable(FlatBufferBuilder builder, int ID = 0, int ShopId = 0, int Weight = 0, int ShopNpcID = 0)
		{
			builder.StartObject(4);
			MysticalMerchantTable.AddShopNpcID(builder, ShopNpcID);
			MysticalMerchantTable.AddWeight(builder, Weight);
			MysticalMerchantTable.AddShopId(builder, ShopId);
			MysticalMerchantTable.AddID(builder, ID);
			return MysticalMerchantTable.EndMysticalMerchantTable(builder);
		}

		// Token: 0x06004383 RID: 17283 RVA: 0x000DABE2 File Offset: 0x000D8FE2
		public static void StartMysticalMerchantTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004384 RID: 17284 RVA: 0x000DABEB File Offset: 0x000D8FEB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004385 RID: 17285 RVA: 0x000DABF6 File Offset: 0x000D8FF6
		public static void AddShopId(FlatBufferBuilder builder, int ShopId)
		{
			builder.AddInt(1, ShopId, 0);
		}

		// Token: 0x06004386 RID: 17286 RVA: 0x000DAC01 File Offset: 0x000D9001
		public static void AddWeight(FlatBufferBuilder builder, int Weight)
		{
			builder.AddInt(2, Weight, 0);
		}

		// Token: 0x06004387 RID: 17287 RVA: 0x000DAC0C File Offset: 0x000D900C
		public static void AddShopNpcID(FlatBufferBuilder builder, int ShopNpcID)
		{
			builder.AddInt(3, ShopNpcID, 0);
		}

		// Token: 0x06004388 RID: 17288 RVA: 0x000DAC18 File Offset: 0x000D9018
		public static Offset<MysticalMerchantTable> EndMysticalMerchantTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MysticalMerchantTable>(value);
		}

		// Token: 0x06004389 RID: 17289 RVA: 0x000DAC32 File Offset: 0x000D9032
		public static void FinishMysticalMerchantTableBuffer(FlatBufferBuilder builder, Offset<MysticalMerchantTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018F0 RID: 6384
		private Table __p = new Table();

		// Token: 0x02000523 RID: 1315
		public enum eCrypt
		{
			// Token: 0x040018F2 RID: 6386
			code = -1035970500
		}
	}
}
