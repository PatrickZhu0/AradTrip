using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000449 RID: 1097
	public class GiftPackTable : IFlatbufferObject
	{
		// Token: 0x17000CFC RID: 3324
		// (get) Token: 0x0600346F RID: 13423 RVA: 0x000B7018 File Offset: 0x000B5418
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003470 RID: 13424 RVA: 0x000B7025 File Offset: 0x000B5425
		public static GiftPackTable GetRootAsGiftPackTable(ByteBuffer _bb)
		{
			return GiftPackTable.GetRootAsGiftPackTable(_bb, new GiftPackTable());
		}

		// Token: 0x06003471 RID: 13425 RVA: 0x000B7032 File Offset: 0x000B5432
		public static GiftPackTable GetRootAsGiftPackTable(ByteBuffer _bb, GiftPackTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003472 RID: 13426 RVA: 0x000B704E File Offset: 0x000B544E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003473 RID: 13427 RVA: 0x000B7068 File Offset: 0x000B5468
		public GiftPackTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000CFD RID: 3325
		// (get) Token: 0x06003474 RID: 13428 RVA: 0x000B7074 File Offset: 0x000B5474
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-783545605 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CFE RID: 3326
		// (get) Token: 0x06003475 RID: 13429 RVA: 0x000B70C0 File Offset: 0x000B54C0
		public GiftPackTable.eFilterType FilterType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (GiftPackTable.eFilterType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000CFF RID: 3327
		// (get) Token: 0x06003476 RID: 13430 RVA: 0x000B7104 File Offset: 0x000B5504
		public int FilterCount
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-783545605 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003477 RID: 13431 RVA: 0x000B7150 File Offset: 0x000B5550
		public int ItemsArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-783545605 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000D00 RID: 3328
		// (get) Token: 0x06003478 RID: 13432 RVA: 0x000B71A0 File Offset: 0x000B55A0
		public int ItemsLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003479 RID: 13433 RVA: 0x000B71D3 File Offset: 0x000B55D3
		public ArraySegment<byte>? GetItemsBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000D01 RID: 3329
		// (get) Token: 0x0600347A RID: 13434 RVA: 0x000B71E2 File Offset: 0x000B55E2
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

		// Token: 0x17000D02 RID: 3330
		// (get) Token: 0x0600347B RID: 13435 RVA: 0x000B7214 File Offset: 0x000B5614
		public int UIType
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-783545605 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000D03 RID: 3331
		// (get) Token: 0x0600347C RID: 13436 RVA: 0x000B7260 File Offset: 0x000B5660
		public GiftPackTable.eShowAvatarModelType ShowAvatarModelType
		{
			get
			{
				int num = this.__p.__offset(14);
				return (GiftPackTable.eShowAvatarModelType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600347D RID: 13437 RVA: 0x000B72A4 File Offset: 0x000B56A4
		public static Offset<GiftPackTable> CreateGiftPackTable(FlatBufferBuilder builder, int ID = 0, GiftPackTable.eFilterType FilterType = GiftPackTable.eFilterType.None, int FilterCount = 0, VectorOffset ItemsOffset = default(VectorOffset), int UIType = 0, GiftPackTable.eShowAvatarModelType ShowAvatarModelType = GiftPackTable.eShowAvatarModelType.None)
		{
			builder.StartObject(6);
			GiftPackTable.AddShowAvatarModelType(builder, ShowAvatarModelType);
			GiftPackTable.AddUIType(builder, UIType);
			GiftPackTable.AddItems(builder, ItemsOffset);
			GiftPackTable.AddFilterCount(builder, FilterCount);
			GiftPackTable.AddFilterType(builder, FilterType);
			GiftPackTable.AddID(builder, ID);
			return GiftPackTable.EndGiftPackTable(builder);
		}

		// Token: 0x0600347E RID: 13438 RVA: 0x000B72E0 File Offset: 0x000B56E0
		public static void StartGiftPackTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0600347F RID: 13439 RVA: 0x000B72E9 File Offset: 0x000B56E9
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003480 RID: 13440 RVA: 0x000B72F4 File Offset: 0x000B56F4
		public static void AddFilterType(FlatBufferBuilder builder, GiftPackTable.eFilterType FilterType)
		{
			builder.AddInt(1, (int)FilterType, 0);
		}

		// Token: 0x06003481 RID: 13441 RVA: 0x000B72FF File Offset: 0x000B56FF
		public static void AddFilterCount(FlatBufferBuilder builder, int FilterCount)
		{
			builder.AddInt(2, FilterCount, 0);
		}

		// Token: 0x06003482 RID: 13442 RVA: 0x000B730A File Offset: 0x000B570A
		public static void AddItems(FlatBufferBuilder builder, VectorOffset ItemsOffset)
		{
			builder.AddOffset(3, ItemsOffset.Value, 0);
		}

		// Token: 0x06003483 RID: 13443 RVA: 0x000B731C File Offset: 0x000B571C
		public static VectorOffset CreateItemsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003484 RID: 13444 RVA: 0x000B7359 File Offset: 0x000B5759
		public static void StartItemsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003485 RID: 13445 RVA: 0x000B7364 File Offset: 0x000B5764
		public static void AddUIType(FlatBufferBuilder builder, int UIType)
		{
			builder.AddInt(4, UIType, 0);
		}

		// Token: 0x06003486 RID: 13446 RVA: 0x000B736F File Offset: 0x000B576F
		public static void AddShowAvatarModelType(FlatBufferBuilder builder, GiftPackTable.eShowAvatarModelType ShowAvatarModelType)
		{
			builder.AddInt(5, (int)ShowAvatarModelType, 0);
		}

		// Token: 0x06003487 RID: 13447 RVA: 0x000B737C File Offset: 0x000B577C
		public static Offset<GiftPackTable> EndGiftPackTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<GiftPackTable>(value);
		}

		// Token: 0x06003488 RID: 13448 RVA: 0x000B7396 File Offset: 0x000B5796
		public static void FinishGiftPackTableBuffer(FlatBufferBuilder builder, Offset<GiftPackTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001561 RID: 5473
		private Table __p = new Table();

		// Token: 0x04001562 RID: 5474
		private FlatBufferArray<int> ItemsValue;

		// Token: 0x0200044A RID: 1098
		public enum eFilterType
		{
			// Token: 0x04001564 RID: 5476
			None,
			// Token: 0x04001565 RID: 5477
			Job,
			// Token: 0x04001566 RID: 5478
			Random,
			// Token: 0x04001567 RID: 5479
			Custom,
			// Token: 0x04001568 RID: 5480
			CustomWithJob
		}

		// Token: 0x0200044B RID: 1099
		public enum eShowAvatarModelType
		{
			// Token: 0x0400156A RID: 5482
			None,
			// Token: 0x0400156B RID: 5483
			Single,
			// Token: 0x0400156C RID: 5484
			Complete,
			// Token: 0x0400156D RID: 5485
			Enumeration,
			// Token: 0x0400156E RID: 5486
			Combination,
			// Token: 0x0400156F RID: 5487
			Matching,
			// Token: 0x04001570 RID: 5488
			CompleteEnumeration
		}

		// Token: 0x0200044C RID: 1100
		public enum eCrypt
		{
			// Token: 0x04001572 RID: 5490
			code = -783545605
		}
	}
}
