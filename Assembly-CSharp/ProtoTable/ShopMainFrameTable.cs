using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005AF RID: 1455
	public class ShopMainFrameTable : IFlatbufferObject
	{
		// Token: 0x1700148E RID: 5262
		// (get) Token: 0x06004B7A RID: 19322 RVA: 0x000ECC18 File Offset: 0x000EB018
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004B7B RID: 19323 RVA: 0x000ECC25 File Offset: 0x000EB025
		public static ShopMainFrameTable GetRootAsShopMainFrameTable(ByteBuffer _bb)
		{
			return ShopMainFrameTable.GetRootAsShopMainFrameTable(_bb, new ShopMainFrameTable());
		}

		// Token: 0x06004B7C RID: 19324 RVA: 0x000ECC32 File Offset: 0x000EB032
		public static ShopMainFrameTable GetRootAsShopMainFrameTable(ByteBuffer _bb, ShopMainFrameTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004B7D RID: 19325 RVA: 0x000ECC4E File Offset: 0x000EB04E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004B7E RID: 19326 RVA: 0x000ECC68 File Offset: 0x000EB068
		public ShopMainFrameTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700148F RID: 5263
		// (get) Token: 0x06004B7F RID: 19327 RVA: 0x000ECC74 File Offset: 0x000EB074
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1299368992 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001490 RID: 5264
		// (get) Token: 0x06004B80 RID: 19328 RVA: 0x000ECCC0 File Offset: 0x000EB0C0
		public string ShopName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004B81 RID: 19329 RVA: 0x000ECD02 File Offset: 0x000EB102
		public ArraySegment<byte>? GetShopNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17001491 RID: 5265
		// (get) Token: 0x06004B82 RID: 19330 RVA: 0x000ECD10 File Offset: 0x000EB110
		public int HelpID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1299368992 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004B83 RID: 19331 RVA: 0x000ECD5C File Offset: 0x000EB15C
		public int ChildrenArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1299368992 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001492 RID: 5266
		// (get) Token: 0x06004B84 RID: 19332 RVA: 0x000ECDAC File Offset: 0x000EB1AC
		public int ChildrenLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004B85 RID: 19333 RVA: 0x000ECDDF File Offset: 0x000EB1DF
		public ArraySegment<byte>? GetChildrenBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001493 RID: 5267
		// (get) Token: 0x06004B86 RID: 19334 RVA: 0x000ECDEE File Offset: 0x000EB1EE
		public FlatBufferArray<int> Children
		{
			get
			{
				if (this.ChildrenValue == null)
				{
					this.ChildrenValue = new FlatBufferArray<int>(new Func<int, int>(this.ChildrenArray), this.ChildrenLength);
				}
				return this.ChildrenValue;
			}
		}

		// Token: 0x06004B87 RID: 19335 RVA: 0x000ECE1E File Offset: 0x000EB21E
		public static Offset<ShopMainFrameTable> CreateShopMainFrameTable(FlatBufferBuilder builder, int ID = 0, StringOffset ShopNameOffset = default(StringOffset), int HelpID = 0, VectorOffset ChildrenOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			ShopMainFrameTable.AddChildren(builder, ChildrenOffset);
			ShopMainFrameTable.AddHelpID(builder, HelpID);
			ShopMainFrameTable.AddShopName(builder, ShopNameOffset);
			ShopMainFrameTable.AddID(builder, ID);
			return ShopMainFrameTable.EndShopMainFrameTable(builder);
		}

		// Token: 0x06004B88 RID: 19336 RVA: 0x000ECE4A File Offset: 0x000EB24A
		public static void StartShopMainFrameTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004B89 RID: 19337 RVA: 0x000ECE53 File Offset: 0x000EB253
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004B8A RID: 19338 RVA: 0x000ECE5E File Offset: 0x000EB25E
		public static void AddShopName(FlatBufferBuilder builder, StringOffset ShopNameOffset)
		{
			builder.AddOffset(1, ShopNameOffset.Value, 0);
		}

		// Token: 0x06004B8B RID: 19339 RVA: 0x000ECE6F File Offset: 0x000EB26F
		public static void AddHelpID(FlatBufferBuilder builder, int HelpID)
		{
			builder.AddInt(2, HelpID, 0);
		}

		// Token: 0x06004B8C RID: 19340 RVA: 0x000ECE7A File Offset: 0x000EB27A
		public static void AddChildren(FlatBufferBuilder builder, VectorOffset ChildrenOffset)
		{
			builder.AddOffset(3, ChildrenOffset.Value, 0);
		}

		// Token: 0x06004B8D RID: 19341 RVA: 0x000ECE8C File Offset: 0x000EB28C
		public static VectorOffset CreateChildrenVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004B8E RID: 19342 RVA: 0x000ECEC9 File Offset: 0x000EB2C9
		public static void StartChildrenVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004B8F RID: 19343 RVA: 0x000ECED4 File Offset: 0x000EB2D4
		public static Offset<ShopMainFrameTable> EndShopMainFrameTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ShopMainFrameTable>(value);
		}

		// Token: 0x06004B90 RID: 19344 RVA: 0x000ECEEE File Offset: 0x000EB2EE
		public static void FinishShopMainFrameTableBuffer(FlatBufferBuilder builder, Offset<ShopMainFrameTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001B27 RID: 6951
		private Table __p = new Table();

		// Token: 0x04001B28 RID: 6952
		private FlatBufferArray<int> ChildrenValue;

		// Token: 0x020005B0 RID: 1456
		public enum eCrypt
		{
			// Token: 0x04001B2A RID: 6954
			code = -1299368992
		}
	}
}
