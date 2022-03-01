using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003E1 RID: 993
	public class EquipHandbookAttachedTable : IFlatbufferObject
	{
		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x06002D55 RID: 11605 RVA: 0x000A643C File Offset: 0x000A483C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002D56 RID: 11606 RVA: 0x000A6449 File Offset: 0x000A4849
		public static EquipHandbookAttachedTable GetRootAsEquipHandbookAttachedTable(ByteBuffer _bb)
		{
			return EquipHandbookAttachedTable.GetRootAsEquipHandbookAttachedTable(_bb, new EquipHandbookAttachedTable());
		}

		// Token: 0x06002D57 RID: 11607 RVA: 0x000A6456 File Offset: 0x000A4856
		public static EquipHandbookAttachedTable GetRootAsEquipHandbookAttachedTable(ByteBuffer _bb, EquipHandbookAttachedTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002D58 RID: 11608 RVA: 0x000A6472 File Offset: 0x000A4872
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002D59 RID: 11609 RVA: 0x000A648C File Offset: 0x000A488C
		public EquipHandbookAttachedTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x06002D5A RID: 11610 RVA: 0x000A6498 File Offset: 0x000A4898
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1032178942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x06002D5B RID: 11611 RVA: 0x000A64E4 File Offset: 0x000A48E4
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002D5C RID: 11612 RVA: 0x000A6526 File Offset: 0x000A4926
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06002D5D RID: 11613 RVA: 0x000A6534 File Offset: 0x000A4934
		public int BaseOccopationLimitArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-1032178942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x06002D5E RID: 11614 RVA: 0x000A6580 File Offset: 0x000A4980
		public int BaseOccopationLimitLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D5F RID: 11615 RVA: 0x000A65B2 File Offset: 0x000A49B2
		public ArraySegment<byte>? GetBaseOccopationLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x06002D60 RID: 11616 RVA: 0x000A65C0 File Offset: 0x000A49C0
		public FlatBufferArray<int> BaseOccopationLimit
		{
			get
			{
				if (this.BaseOccopationLimitValue == null)
				{
					this.BaseOccopationLimitValue = new FlatBufferArray<int>(new Func<int, int>(this.BaseOccopationLimitArray), this.BaseOccopationLimitLength);
				}
				return this.BaseOccopationLimitValue;
			}
		}

		// Token: 0x06002D61 RID: 11617 RVA: 0x000A65F0 File Offset: 0x000A49F0
		public int OccopationLimitArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (-1032178942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x06002D62 RID: 11618 RVA: 0x000A6640 File Offset: 0x000A4A40
		public int OccopationLimitLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D63 RID: 11619 RVA: 0x000A6673 File Offset: 0x000A4A73
		public ArraySegment<byte>? GetOccopationLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x06002D64 RID: 11620 RVA: 0x000A6682 File Offset: 0x000A4A82
		public FlatBufferArray<int> OccopationLimit
		{
			get
			{
				if (this.OccopationLimitValue == null)
				{
					this.OccopationLimitValue = new FlatBufferArray<int>(new Func<int, int>(this.OccopationLimitArray), this.OccopationLimitLength);
				}
				return this.OccopationLimitValue;
			}
		}

		// Token: 0x06002D65 RID: 11621 RVA: 0x000A66B4 File Offset: 0x000A4AB4
		public int EquipHandbookSourceIDsArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (-1032178942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x06002D66 RID: 11622 RVA: 0x000A6704 File Offset: 0x000A4B04
		public int EquipHandbookSourceIDsLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D67 RID: 11623 RVA: 0x000A6737 File Offset: 0x000A4B37
		public ArraySegment<byte>? GetEquipHandbookSourceIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x06002D68 RID: 11624 RVA: 0x000A6746 File Offset: 0x000A4B46
		public FlatBufferArray<int> EquipHandbookSourceIDs
		{
			get
			{
				if (this.EquipHandbookSourceIDsValue == null)
				{
					this.EquipHandbookSourceIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipHandbookSourceIDsArray), this.EquipHandbookSourceIDsLength);
				}
				return this.EquipHandbookSourceIDsValue;
			}
		}

		// Token: 0x06002D69 RID: 11625 RVA: 0x000A6778 File Offset: 0x000A4B78
		public int EquipHandbookCommentIDsArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-1032178942 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x06002D6A RID: 11626 RVA: 0x000A67C8 File Offset: 0x000A4BC8
		public int EquipHandbookCommentIDsLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D6B RID: 11627 RVA: 0x000A67FB File Offset: 0x000A4BFB
		public ArraySegment<byte>? GetEquipHandbookCommentIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x06002D6C RID: 11628 RVA: 0x000A680A File Offset: 0x000A4C0A
		public FlatBufferArray<int> EquipHandbookCommentIDs
		{
			get
			{
				if (this.EquipHandbookCommentIDsValue == null)
				{
					this.EquipHandbookCommentIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.EquipHandbookCommentIDsArray), this.EquipHandbookCommentIDsLength);
				}
				return this.EquipHandbookCommentIDsValue;
			}
		}

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x06002D6D RID: 11629 RVA: 0x000A683C File Offset: 0x000A4C3C
		public int EquipSourceEntrance
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1032178942 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002D6E RID: 11630 RVA: 0x000A6888 File Offset: 0x000A4C88
		public static Offset<EquipHandbookAttachedTable> CreateEquipHandbookAttachedTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset BaseOccopationLimitOffset = default(VectorOffset), VectorOffset OccopationLimitOffset = default(VectorOffset), VectorOffset EquipHandbookSourceIDsOffset = default(VectorOffset), VectorOffset EquipHandbookCommentIDsOffset = default(VectorOffset), int EquipSourceEntrance = 0)
		{
			builder.StartObject(7);
			EquipHandbookAttachedTable.AddEquipSourceEntrance(builder, EquipSourceEntrance);
			EquipHandbookAttachedTable.AddEquipHandbookCommentIDs(builder, EquipHandbookCommentIDsOffset);
			EquipHandbookAttachedTable.AddEquipHandbookSourceIDs(builder, EquipHandbookSourceIDsOffset);
			EquipHandbookAttachedTable.AddOccopationLimit(builder, OccopationLimitOffset);
			EquipHandbookAttachedTable.AddBaseOccopationLimit(builder, BaseOccopationLimitOffset);
			EquipHandbookAttachedTable.AddName(builder, NameOffset);
			EquipHandbookAttachedTable.AddID(builder, ID);
			return EquipHandbookAttachedTable.EndEquipHandbookAttachedTable(builder);
		}

		// Token: 0x06002D6F RID: 11631 RVA: 0x000A68D7 File Offset: 0x000A4CD7
		public static void StartEquipHandbookAttachedTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002D70 RID: 11632 RVA: 0x000A68E0 File Offset: 0x000A4CE0
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002D71 RID: 11633 RVA: 0x000A68EB File Offset: 0x000A4CEB
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002D72 RID: 11634 RVA: 0x000A68FC File Offset: 0x000A4CFC
		public static void AddBaseOccopationLimit(FlatBufferBuilder builder, VectorOffset BaseOccopationLimitOffset)
		{
			builder.AddOffset(2, BaseOccopationLimitOffset.Value, 0);
		}

		// Token: 0x06002D73 RID: 11635 RVA: 0x000A6910 File Offset: 0x000A4D10
		public static VectorOffset CreateBaseOccopationLimitVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D74 RID: 11636 RVA: 0x000A694D File Offset: 0x000A4D4D
		public static void StartBaseOccopationLimitVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D75 RID: 11637 RVA: 0x000A6958 File Offset: 0x000A4D58
		public static void AddOccopationLimit(FlatBufferBuilder builder, VectorOffset OccopationLimitOffset)
		{
			builder.AddOffset(3, OccopationLimitOffset.Value, 0);
		}

		// Token: 0x06002D76 RID: 11638 RVA: 0x000A696C File Offset: 0x000A4D6C
		public static VectorOffset CreateOccopationLimitVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D77 RID: 11639 RVA: 0x000A69A9 File Offset: 0x000A4DA9
		public static void StartOccopationLimitVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D78 RID: 11640 RVA: 0x000A69B4 File Offset: 0x000A4DB4
		public static void AddEquipHandbookSourceIDs(FlatBufferBuilder builder, VectorOffset EquipHandbookSourceIDsOffset)
		{
			builder.AddOffset(4, EquipHandbookSourceIDsOffset.Value, 0);
		}

		// Token: 0x06002D79 RID: 11641 RVA: 0x000A69C8 File Offset: 0x000A4DC8
		public static VectorOffset CreateEquipHandbookSourceIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D7A RID: 11642 RVA: 0x000A6A05 File Offset: 0x000A4E05
		public static void StartEquipHandbookSourceIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D7B RID: 11643 RVA: 0x000A6A10 File Offset: 0x000A4E10
		public static void AddEquipHandbookCommentIDs(FlatBufferBuilder builder, VectorOffset EquipHandbookCommentIDsOffset)
		{
			builder.AddOffset(5, EquipHandbookCommentIDsOffset.Value, 0);
		}

		// Token: 0x06002D7C RID: 11644 RVA: 0x000A6A24 File Offset: 0x000A4E24
		public static VectorOffset CreateEquipHandbookCommentIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D7D RID: 11645 RVA: 0x000A6A61 File Offset: 0x000A4E61
		public static void StartEquipHandbookCommentIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D7E RID: 11646 RVA: 0x000A6A6C File Offset: 0x000A4E6C
		public static void AddEquipSourceEntrance(FlatBufferBuilder builder, int EquipSourceEntrance)
		{
			builder.AddInt(6, EquipSourceEntrance, 0);
		}

		// Token: 0x06002D7F RID: 11647 RVA: 0x000A6A78 File Offset: 0x000A4E78
		public static Offset<EquipHandbookAttachedTable> EndEquipHandbookAttachedTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipHandbookAttachedTable>(value);
		}

		// Token: 0x06002D80 RID: 11648 RVA: 0x000A6A92 File Offset: 0x000A4E92
		public static void FinishEquipHandbookAttachedTableBuffer(FlatBufferBuilder builder, Offset<EquipHandbookAttachedTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400133B RID: 4923
		private Table __p = new Table();

		// Token: 0x0400133C RID: 4924
		private FlatBufferArray<int> BaseOccopationLimitValue;

		// Token: 0x0400133D RID: 4925
		private FlatBufferArray<int> OccopationLimitValue;

		// Token: 0x0400133E RID: 4926
		private FlatBufferArray<int> EquipHandbookSourceIDsValue;

		// Token: 0x0400133F RID: 4927
		private FlatBufferArray<int> EquipHandbookCommentIDsValue;

		// Token: 0x020003E2 RID: 994
		public enum eCrypt
		{
			// Token: 0x04001341 RID: 4929
			code = -1032178942
		}
	}
}
