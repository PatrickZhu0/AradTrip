using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003C9 RID: 969
	public class EqualItemTable : IFlatbufferObject
	{
		// Token: 0x17000A25 RID: 2597
		// (get) Token: 0x06002B8D RID: 11149 RVA: 0x000A1E68 File Offset: 0x000A0268
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002B8E RID: 11150 RVA: 0x000A1E75 File Offset: 0x000A0275
		public static EqualItemTable GetRootAsEqualItemTable(ByteBuffer _bb)
		{
			return EqualItemTable.GetRootAsEqualItemTable(_bb, new EqualItemTable());
		}

		// Token: 0x06002B8F RID: 11151 RVA: 0x000A1E82 File Offset: 0x000A0282
		public static EqualItemTable GetRootAsEqualItemTable(ByteBuffer _bb, EqualItemTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002B90 RID: 11152 RVA: 0x000A1E9E File Offset: 0x000A029E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002B91 RID: 11153 RVA: 0x000A1EB8 File Offset: 0x000A02B8
		public EqualItemTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000A26 RID: 2598
		// (get) Token: 0x06002B92 RID: 11154 RVA: 0x000A1EC4 File Offset: 0x000A02C4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1619482179 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002B93 RID: 11155 RVA: 0x000A1F10 File Offset: 0x000A0310
		public int EqualItemIDsArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? 0 : (1619482179 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000A27 RID: 2599
		// (get) Token: 0x06002B94 RID: 11156 RVA: 0x000A1F5C File Offset: 0x000A035C
		public int EqualItemIDsLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002B95 RID: 11157 RVA: 0x000A1F8E File Offset: 0x000A038E
		public ArraySegment<byte>? GetEqualItemIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000A28 RID: 2600
		// (get) Token: 0x06002B96 RID: 11158 RVA: 0x000A1F9C File Offset: 0x000A039C
		public FlatBufferArray<int> EqualItemIDs
		{
			get
			{
				if (this.EqualItemIDsValue == null)
				{
					this.EqualItemIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.EqualItemIDsArray), this.EqualItemIDsLength);
				}
				return this.EqualItemIDsValue;
			}
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x000A1FCC File Offset: 0x000A03CC
		public static Offset<EqualItemTable> CreateEqualItemTable(FlatBufferBuilder builder, int ID = 0, VectorOffset EqualItemIDsOffset = default(VectorOffset))
		{
			builder.StartObject(2);
			EqualItemTable.AddEqualItemIDs(builder, EqualItemIDsOffset);
			EqualItemTable.AddID(builder, ID);
			return EqualItemTable.EndEqualItemTable(builder);
		}

		// Token: 0x06002B98 RID: 11160 RVA: 0x000A1FE9 File Offset: 0x000A03E9
		public static void StartEqualItemTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06002B99 RID: 11161 RVA: 0x000A1FF2 File Offset: 0x000A03F2
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002B9A RID: 11162 RVA: 0x000A1FFD File Offset: 0x000A03FD
		public static void AddEqualItemIDs(FlatBufferBuilder builder, VectorOffset EqualItemIDsOffset)
		{
			builder.AddOffset(1, EqualItemIDsOffset.Value, 0);
		}

		// Token: 0x06002B9B RID: 11163 RVA: 0x000A2010 File Offset: 0x000A0410
		public static VectorOffset CreateEqualItemIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002B9C RID: 11164 RVA: 0x000A204D File Offset: 0x000A044D
		public static void StartEqualItemIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002B9D RID: 11165 RVA: 0x000A2058 File Offset: 0x000A0458
		public static Offset<EqualItemTable> EndEqualItemTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EqualItemTable>(value);
		}

		// Token: 0x06002B9E RID: 11166 RVA: 0x000A2072 File Offset: 0x000A0472
		public static void FinishEqualItemTableBuffer(FlatBufferBuilder builder, Offset<EqualItemTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040012A2 RID: 4770
		private Table __p = new Table();

		// Token: 0x040012A3 RID: 4771
		private FlatBufferArray<int> EqualItemIDsValue;

		// Token: 0x020003CA RID: 970
		public enum eCrypt
		{
			// Token: 0x040012A5 RID: 4773
			code = 1619482179
		}
	}
}
