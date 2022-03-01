using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000627 RID: 1575
	public class WholeBargainDiscountTable : IFlatbufferObject
	{
		// Token: 0x17001810 RID: 6160
		// (get) Token: 0x06005571 RID: 21873 RVA: 0x00105360 File Offset: 0x00103760
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06005572 RID: 21874 RVA: 0x0010536D File Offset: 0x0010376D
		public static WholeBargainDiscountTable GetRootAsWholeBargainDiscountTable(ByteBuffer _bb)
		{
			return WholeBargainDiscountTable.GetRootAsWholeBargainDiscountTable(_bb, new WholeBargainDiscountTable());
		}

		// Token: 0x06005573 RID: 21875 RVA: 0x0010537A File Offset: 0x0010377A
		public static WholeBargainDiscountTable GetRootAsWholeBargainDiscountTable(ByteBuffer _bb, WholeBargainDiscountTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06005574 RID: 21876 RVA: 0x00105396 File Offset: 0x00103796
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06005575 RID: 21877 RVA: 0x001053B0 File Offset: 0x001037B0
		public WholeBargainDiscountTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001811 RID: 6161
		// (get) Token: 0x06005576 RID: 21878 RVA: 0x001053BC File Offset: 0x001037BC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-16543686 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001812 RID: 6162
		// (get) Token: 0x06005577 RID: 21879 RVA: 0x00105408 File Offset: 0x00103808
		public int JoinNum
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-16543686 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001813 RID: 6163
		// (get) Token: 0x06005578 RID: 21880 RVA: 0x00105454 File Offset: 0x00103854
		public int Discount
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-16543686 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06005579 RID: 21881 RVA: 0x0010549D File Offset: 0x0010389D
		public static Offset<WholeBargainDiscountTable> CreateWholeBargainDiscountTable(FlatBufferBuilder builder, int ID = 0, int JoinNum = 0, int Discount = 0)
		{
			builder.StartObject(3);
			WholeBargainDiscountTable.AddDiscount(builder, Discount);
			WholeBargainDiscountTable.AddJoinNum(builder, JoinNum);
			WholeBargainDiscountTable.AddID(builder, ID);
			return WholeBargainDiscountTable.EndWholeBargainDiscountTable(builder);
		}

		// Token: 0x0600557A RID: 21882 RVA: 0x001054C1 File Offset: 0x001038C1
		public static void StartWholeBargainDiscountTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0600557B RID: 21883 RVA: 0x001054CA File Offset: 0x001038CA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600557C RID: 21884 RVA: 0x001054D5 File Offset: 0x001038D5
		public static void AddJoinNum(FlatBufferBuilder builder, int JoinNum)
		{
			builder.AddInt(1, JoinNum, 0);
		}

		// Token: 0x0600557D RID: 21885 RVA: 0x001054E0 File Offset: 0x001038E0
		public static void AddDiscount(FlatBufferBuilder builder, int Discount)
		{
			builder.AddInt(2, Discount, 0);
		}

		// Token: 0x0600557E RID: 21886 RVA: 0x001054EC File Offset: 0x001038EC
		public static Offset<WholeBargainDiscountTable> EndWholeBargainDiscountTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<WholeBargainDiscountTable>(value);
		}

		// Token: 0x0600557F RID: 21887 RVA: 0x00105506 File Offset: 0x00103906
		public static void FinishWholeBargainDiscountTableBuffer(FlatBufferBuilder builder, Offset<WholeBargainDiscountTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001EBB RID: 7867
		private Table __p = new Table();

		// Token: 0x02000628 RID: 1576
		public enum eCrypt
		{
			// Token: 0x04001EBD RID: 7869
			code = -16543686
		}
	}
}
