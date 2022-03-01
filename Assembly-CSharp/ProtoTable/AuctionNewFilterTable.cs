using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002BC RID: 700
	public class AuctionNewFilterTable : IFlatbufferObject
	{
		// Token: 0x170003BC RID: 956
		// (get) Token: 0x060018D6 RID: 6358 RVA: 0x000744D4 File Offset: 0x000728D4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060018D7 RID: 6359 RVA: 0x000744E1 File Offset: 0x000728E1
		public static AuctionNewFilterTable GetRootAsAuctionNewFilterTable(ByteBuffer _bb)
		{
			return AuctionNewFilterTable.GetRootAsAuctionNewFilterTable(_bb, new AuctionNewFilterTable());
		}

		// Token: 0x060018D8 RID: 6360 RVA: 0x000744EE File Offset: 0x000728EE
		public static AuctionNewFilterTable GetRootAsAuctionNewFilterTable(ByteBuffer _bb, AuctionNewFilterTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060018D9 RID: 6361 RVA: 0x0007450A File Offset: 0x0007290A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060018DA RID: 6362 RVA: 0x00074524 File Offset: 0x00072924
		public AuctionNewFilterTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003BD RID: 957
		// (get) Token: 0x060018DB RID: 6363 RVA: 0x00074530 File Offset: 0x00072930
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (787285637 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003BE RID: 958
		// (get) Token: 0x060018DC RID: 6364 RVA: 0x0007457C File Offset: 0x0007297C
		public int FilterItemType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (787285637 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003BF RID: 959
		// (get) Token: 0x060018DD RID: 6365 RVA: 0x000745C8 File Offset: 0x000729C8
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x060018DE RID: 6366 RVA: 0x0007460A File Offset: 0x00072A0A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170003C0 RID: 960
		// (get) Token: 0x060018DF RID: 6367 RVA: 0x00074618 File Offset: 0x00072A18
		public int Sort
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (787285637 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060018E0 RID: 6368 RVA: 0x00074664 File Offset: 0x00072A64
		public int ParameterArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (787285637 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170003C1 RID: 961
		// (get) Token: 0x060018E1 RID: 6369 RVA: 0x000746B4 File Offset: 0x00072AB4
		public int ParameterLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060018E2 RID: 6370 RVA: 0x000746E7 File Offset: 0x00072AE7
		public ArraySegment<byte>? GetParameterBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170003C2 RID: 962
		// (get) Token: 0x060018E3 RID: 6371 RVA: 0x000746F6 File Offset: 0x00072AF6
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

		// Token: 0x060018E4 RID: 6372 RVA: 0x00074726 File Offset: 0x00072B26
		public static Offset<AuctionNewFilterTable> CreateAuctionNewFilterTable(FlatBufferBuilder builder, int ID = 0, int FilterItemType = 0, StringOffset NameOffset = default(StringOffset), int Sort = 0, VectorOffset ParameterOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			AuctionNewFilterTable.AddParameter(builder, ParameterOffset);
			AuctionNewFilterTable.AddSort(builder, Sort);
			AuctionNewFilterTable.AddName(builder, NameOffset);
			AuctionNewFilterTable.AddFilterItemType(builder, FilterItemType);
			AuctionNewFilterTable.AddID(builder, ID);
			return AuctionNewFilterTable.EndAuctionNewFilterTable(builder);
		}

		// Token: 0x060018E5 RID: 6373 RVA: 0x0007475A File Offset: 0x00072B5A
		public static void StartAuctionNewFilterTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060018E6 RID: 6374 RVA: 0x00074763 File Offset: 0x00072B63
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060018E7 RID: 6375 RVA: 0x0007476E File Offset: 0x00072B6E
		public static void AddFilterItemType(FlatBufferBuilder builder, int FilterItemType)
		{
			builder.AddInt(1, FilterItemType, 0);
		}

		// Token: 0x060018E8 RID: 6376 RVA: 0x00074779 File Offset: 0x00072B79
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x060018E9 RID: 6377 RVA: 0x0007478A File Offset: 0x00072B8A
		public static void AddSort(FlatBufferBuilder builder, int Sort)
		{
			builder.AddInt(3, Sort, 0);
		}

		// Token: 0x060018EA RID: 6378 RVA: 0x00074795 File Offset: 0x00072B95
		public static void AddParameter(FlatBufferBuilder builder, VectorOffset ParameterOffset)
		{
			builder.AddOffset(4, ParameterOffset.Value, 0);
		}

		// Token: 0x060018EB RID: 6379 RVA: 0x000747A8 File Offset: 0x00072BA8
		public static VectorOffset CreateParameterVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060018EC RID: 6380 RVA: 0x000747E5 File Offset: 0x00072BE5
		public static void StartParameterVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060018ED RID: 6381 RVA: 0x000747F0 File Offset: 0x00072BF0
		public static Offset<AuctionNewFilterTable> EndAuctionNewFilterTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionNewFilterTable>(value);
		}

		// Token: 0x060018EE RID: 6382 RVA: 0x0007480A File Offset: 0x00072C0A
		public static void FinishAuctionNewFilterTableBuffer(FlatBufferBuilder builder, Offset<AuctionNewFilterTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E5C RID: 3676
		private Table __p = new Table();

		// Token: 0x04000E5D RID: 3677
		private FlatBufferArray<int> ParameterValue;

		// Token: 0x020002BD RID: 701
		public enum eCrypt
		{
			// Token: 0x04000E5F RID: 3679
			code = 787285637
		}
	}
}
