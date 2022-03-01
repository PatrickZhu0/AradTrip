using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000567 RID: 1383
	public class RandBaseTable : IFlatbufferObject
	{
		// Token: 0x17001332 RID: 4914
		// (get) Token: 0x06004741 RID: 18241 RVA: 0x000E3334 File Offset: 0x000E1734
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004742 RID: 18242 RVA: 0x000E3341 File Offset: 0x000E1741
		public static RandBaseTable GetRootAsRandBaseTable(ByteBuffer _bb)
		{
			return RandBaseTable.GetRootAsRandBaseTable(_bb, new RandBaseTable());
		}

		// Token: 0x06004743 RID: 18243 RVA: 0x000E334E File Offset: 0x000E174E
		public static RandBaseTable GetRootAsRandBaseTable(ByteBuffer _bb, RandBaseTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004744 RID: 18244 RVA: 0x000E336A File Offset: 0x000E176A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004745 RID: 18245 RVA: 0x000E3384 File Offset: 0x000E1784
		public RandBaseTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001333 RID: 4915
		// (get) Token: 0x06004746 RID: 18246 RVA: 0x000E3390 File Offset: 0x000E1790
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (991702902 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001334 RID: 4916
		// (get) Token: 0x06004747 RID: 18247 RVA: 0x000E33DC File Offset: 0x000E17DC
		public int BaseRatio
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (991702902 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004748 RID: 18248 RVA: 0x000E3428 File Offset: 0x000E1828
		public int QLPArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (991702902 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001335 RID: 4917
		// (get) Token: 0x06004749 RID: 18249 RVA: 0x000E3474 File Offset: 0x000E1874
		public int QLPLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600474A RID: 18250 RVA: 0x000E34A6 File Offset: 0x000E18A6
		public ArraySegment<byte>? GetQLPBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17001336 RID: 4918
		// (get) Token: 0x0600474B RID: 18251 RVA: 0x000E34B4 File Offset: 0x000E18B4
		public FlatBufferArray<int> QLP
		{
			get
			{
				if (this.QLPValue == null)
				{
					this.QLPValue = new FlatBufferArray<int>(new Func<int, int>(this.QLPArray), this.QLPLength);
				}
				return this.QLPValue;
			}
		}

		// Token: 0x0600474C RID: 18252 RVA: 0x000E34E4 File Offset: 0x000E18E4
		public int QLOMinArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (991702902 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001337 RID: 4919
		// (get) Token: 0x0600474D RID: 18253 RVA: 0x000E3534 File Offset: 0x000E1934
		public int QLOMinLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600474E RID: 18254 RVA: 0x000E3567 File Offset: 0x000E1967
		public ArraySegment<byte>? GetQLOMinBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001338 RID: 4920
		// (get) Token: 0x0600474F RID: 18255 RVA: 0x000E3576 File Offset: 0x000E1976
		public FlatBufferArray<int> QLOMin
		{
			get
			{
				if (this.QLOMinValue == null)
				{
					this.QLOMinValue = new FlatBufferArray<int>(new Func<int, int>(this.QLOMinArray), this.QLOMinLength);
				}
				return this.QLOMinValue;
			}
		}

		// Token: 0x06004750 RID: 18256 RVA: 0x000E35A8 File Offset: 0x000E19A8
		public int QLOMaxArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (991702902 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001339 RID: 4921
		// (get) Token: 0x06004751 RID: 18257 RVA: 0x000E35F8 File Offset: 0x000E19F8
		public int QLOMaxLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004752 RID: 18258 RVA: 0x000E362B File Offset: 0x000E1A2B
		public ArraySegment<byte>? GetQLOMaxBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x1700133A RID: 4922
		// (get) Token: 0x06004753 RID: 18259 RVA: 0x000E363A File Offset: 0x000E1A3A
		public FlatBufferArray<int> QLOMax
		{
			get
			{
				if (this.QLOMaxValue == null)
				{
					this.QLOMaxValue = new FlatBufferArray<int>(new Func<int, int>(this.QLOMaxArray), this.QLOMaxLength);
				}
				return this.QLOMaxValue;
			}
		}

		// Token: 0x06004754 RID: 18260 RVA: 0x000E366A File Offset: 0x000E1A6A
		public static Offset<RandBaseTable> CreateRandBaseTable(FlatBufferBuilder builder, int ID = 0, int BaseRatio = 0, VectorOffset QLPOffset = default(VectorOffset), VectorOffset QLOMinOffset = default(VectorOffset), VectorOffset QLOMaxOffset = default(VectorOffset))
		{
			builder.StartObject(5);
			RandBaseTable.AddQLOMax(builder, QLOMaxOffset);
			RandBaseTable.AddQLOMin(builder, QLOMinOffset);
			RandBaseTable.AddQLP(builder, QLPOffset);
			RandBaseTable.AddBaseRatio(builder, BaseRatio);
			RandBaseTable.AddID(builder, ID);
			return RandBaseTable.EndRandBaseTable(builder);
		}

		// Token: 0x06004755 RID: 18261 RVA: 0x000E369E File Offset: 0x000E1A9E
		public static void StartRandBaseTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06004756 RID: 18262 RVA: 0x000E36A7 File Offset: 0x000E1AA7
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004757 RID: 18263 RVA: 0x000E36B2 File Offset: 0x000E1AB2
		public static void AddBaseRatio(FlatBufferBuilder builder, int BaseRatio)
		{
			builder.AddInt(1, BaseRatio, 0);
		}

		// Token: 0x06004758 RID: 18264 RVA: 0x000E36BD File Offset: 0x000E1ABD
		public static void AddQLP(FlatBufferBuilder builder, VectorOffset QLPOffset)
		{
			builder.AddOffset(2, QLPOffset.Value, 0);
		}

		// Token: 0x06004759 RID: 18265 RVA: 0x000E36D0 File Offset: 0x000E1AD0
		public static VectorOffset CreateQLPVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600475A RID: 18266 RVA: 0x000E370D File Offset: 0x000E1B0D
		public static void StartQLPVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600475B RID: 18267 RVA: 0x000E3718 File Offset: 0x000E1B18
		public static void AddQLOMin(FlatBufferBuilder builder, VectorOffset QLOMinOffset)
		{
			builder.AddOffset(3, QLOMinOffset.Value, 0);
		}

		// Token: 0x0600475C RID: 18268 RVA: 0x000E372C File Offset: 0x000E1B2C
		public static VectorOffset CreateQLOMinVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600475D RID: 18269 RVA: 0x000E3769 File Offset: 0x000E1B69
		public static void StartQLOMinVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600475E RID: 18270 RVA: 0x000E3774 File Offset: 0x000E1B74
		public static void AddQLOMax(FlatBufferBuilder builder, VectorOffset QLOMaxOffset)
		{
			builder.AddOffset(4, QLOMaxOffset.Value, 0);
		}

		// Token: 0x0600475F RID: 18271 RVA: 0x000E3788 File Offset: 0x000E1B88
		public static VectorOffset CreateQLOMaxVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004760 RID: 18272 RVA: 0x000E37C5 File Offset: 0x000E1BC5
		public static void StartQLOMaxVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004761 RID: 18273 RVA: 0x000E37D0 File Offset: 0x000E1BD0
		public static Offset<RandBaseTable> EndRandBaseTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RandBaseTable>(value);
		}

		// Token: 0x06004762 RID: 18274 RVA: 0x000E37EA File Offset: 0x000E1BEA
		public static void FinishRandBaseTableBuffer(FlatBufferBuilder builder, Offset<RandBaseTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A3C RID: 6716
		private Table __p = new Table();

		// Token: 0x04001A3D RID: 6717
		private FlatBufferArray<int> QLPValue;

		// Token: 0x04001A3E RID: 6718
		private FlatBufferArray<int> QLOMinValue;

		// Token: 0x04001A3F RID: 6719
		private FlatBufferArray<int> QLOMaxValue;

		// Token: 0x02000568 RID: 1384
		public enum eCrypt
		{
			// Token: 0x04001A41 RID: 6721
			code = 991702902
		}
	}
}
