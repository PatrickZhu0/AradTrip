using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004B3 RID: 1203
	public class ItemConfigTable : IFlatbufferObject
	{
		// Token: 0x17000EEA RID: 3818
		// (get) Token: 0x06003ABF RID: 15039 RVA: 0x000C53F8 File Offset: 0x000C37F8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003AC0 RID: 15040 RVA: 0x000C5405 File Offset: 0x000C3805
		public static ItemConfigTable GetRootAsItemConfigTable(ByteBuffer _bb)
		{
			return ItemConfigTable.GetRootAsItemConfigTable(_bb, new ItemConfigTable());
		}

		// Token: 0x06003AC1 RID: 15041 RVA: 0x000C5412 File Offset: 0x000C3812
		public static ItemConfigTable GetRootAsItemConfigTable(ByteBuffer _bb, ItemConfigTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003AC2 RID: 15042 RVA: 0x000C542E File Offset: 0x000C382E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003AC3 RID: 15043 RVA: 0x000C5448 File Offset: 0x000C3848
		public ItemConfigTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EEB RID: 3819
		// (get) Token: 0x06003AC4 RID: 15044 RVA: 0x000C5454 File Offset: 0x000C3854
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-193024343 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EEC RID: 3820
		// (get) Token: 0x06003AC5 RID: 15045 RVA: 0x000C54A0 File Offset: 0x000C38A0
		public int ItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-193024343 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EED RID: 3821
		// (get) Token: 0x06003AC6 RID: 15046 RVA: 0x000C54EC File Offset: 0x000C38EC
		public ItemConfigTable.eItemType ItemType
		{
			get
			{
				int num = this.__p.__offset(8);
				return (ItemConfigTable.eItemType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003AC7 RID: 15047 RVA: 0x000C5530 File Offset: 0x000C3930
		public string UseItemEffectArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000EEE RID: 3822
		// (get) Token: 0x06003AC8 RID: 15048 RVA: 0x000C5578 File Offset: 0x000C3978
		public int UseItemEffectLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000EEF RID: 3823
		// (get) Token: 0x06003AC9 RID: 15049 RVA: 0x000C55AB File Offset: 0x000C39AB
		public FlatBufferArray<string> UseItemEffect
		{
			get
			{
				if (this.UseItemEffectValue == null)
				{
					this.UseItemEffectValue = new FlatBufferArray<string>(new Func<int, string>(this.UseItemEffectArray), this.UseItemEffectLength);
				}
				return this.UseItemEffectValue;
			}
		}

		// Token: 0x17000EF0 RID: 3824
		// (get) Token: 0x06003ACA RID: 15050 RVA: 0x000C55DC File Offset: 0x000C39DC
		public int InvalidTipsID
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-193024343 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EF1 RID: 3825
		// (get) Token: 0x06003ACB RID: 15051 RVA: 0x000C5628 File Offset: 0x000C3A28
		public int DefualtUsePriority
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-193024343 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003ACC RID: 15052 RVA: 0x000C5672 File Offset: 0x000C3A72
		public static Offset<ItemConfigTable> CreateItemConfigTable(FlatBufferBuilder builder, int ID = 0, int ItemID = 0, ItemConfigTable.eItemType ItemType = ItemConfigTable.eItemType.ItemType_None, VectorOffset UseItemEffectOffset = default(VectorOffset), int InvalidTipsID = 0, int DefualtUsePriority = 0)
		{
			builder.StartObject(6);
			ItemConfigTable.AddDefualtUsePriority(builder, DefualtUsePriority);
			ItemConfigTable.AddInvalidTipsID(builder, InvalidTipsID);
			ItemConfigTable.AddUseItemEffect(builder, UseItemEffectOffset);
			ItemConfigTable.AddItemType(builder, ItemType);
			ItemConfigTable.AddItemID(builder, ItemID);
			ItemConfigTable.AddID(builder, ID);
			return ItemConfigTable.EndItemConfigTable(builder);
		}

		// Token: 0x06003ACD RID: 15053 RVA: 0x000C56AE File Offset: 0x000C3AAE
		public static void StartItemConfigTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x06003ACE RID: 15054 RVA: 0x000C56B7 File Offset: 0x000C3AB7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003ACF RID: 15055 RVA: 0x000C56C2 File Offset: 0x000C3AC2
		public static void AddItemID(FlatBufferBuilder builder, int ItemID)
		{
			builder.AddInt(1, ItemID, 0);
		}

		// Token: 0x06003AD0 RID: 15056 RVA: 0x000C56CD File Offset: 0x000C3ACD
		public static void AddItemType(FlatBufferBuilder builder, ItemConfigTable.eItemType ItemType)
		{
			builder.AddInt(2, (int)ItemType, 0);
		}

		// Token: 0x06003AD1 RID: 15057 RVA: 0x000C56D8 File Offset: 0x000C3AD8
		public static void AddUseItemEffect(FlatBufferBuilder builder, VectorOffset UseItemEffectOffset)
		{
			builder.AddOffset(3, UseItemEffectOffset.Value, 0);
		}

		// Token: 0x06003AD2 RID: 15058 RVA: 0x000C56EC File Offset: 0x000C3AEC
		public static VectorOffset CreateUseItemEffectVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06003AD3 RID: 15059 RVA: 0x000C5732 File Offset: 0x000C3B32
		public static void StartUseItemEffectVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003AD4 RID: 15060 RVA: 0x000C573D File Offset: 0x000C3B3D
		public static void AddInvalidTipsID(FlatBufferBuilder builder, int InvalidTipsID)
		{
			builder.AddInt(4, InvalidTipsID, 0);
		}

		// Token: 0x06003AD5 RID: 15061 RVA: 0x000C5748 File Offset: 0x000C3B48
		public static void AddDefualtUsePriority(FlatBufferBuilder builder, int DefualtUsePriority)
		{
			builder.AddInt(5, DefualtUsePriority, 0);
		}

		// Token: 0x06003AD6 RID: 15062 RVA: 0x000C5754 File Offset: 0x000C3B54
		public static Offset<ItemConfigTable> EndItemConfigTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ItemConfigTable>(value);
		}

		// Token: 0x06003AD7 RID: 15063 RVA: 0x000C576E File Offset: 0x000C3B6E
		public static void FinishItemConfigTableBuffer(FlatBufferBuilder builder, Offset<ItemConfigTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001681 RID: 5761
		private Table __p = new Table();

		// Token: 0x04001682 RID: 5762
		private FlatBufferArray<string> UseItemEffectValue;

		// Token: 0x020004B4 RID: 1204
		public enum eItemType
		{
			// Token: 0x04001684 RID: 5764
			ItemType_None,
			// Token: 0x04001685 RID: 5765
			BattleDrugHP,
			// Token: 0x04001686 RID: 5766
			BattleDrugMP,
			// Token: 0x04001687 RID: 5767
			BattleDrugHPMP,
			// Token: 0x04001688 RID: 5768
			BattleConsume,
			// Token: 0x04001689 RID: 5769
			BattleCoin
		}

		// Token: 0x020004B5 RID: 1205
		public enum eCrypt
		{
			// Token: 0x0400168B RID: 5771
			code = -193024343
		}
	}
}
