using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D65 RID: 3429
	public sealed class DBlockChunk : Table
	{
		// Token: 0x06008B3A RID: 35642 RVA: 0x001994BA File Offset: 0x001978BA
		public static DBlockChunk GetRootAsDBlockChunk(ByteBuffer _bb)
		{
			return DBlockChunk.GetRootAsDBlockChunk(_bb, new DBlockChunk());
		}

		// Token: 0x06008B3B RID: 35643 RVA: 0x001994C7 File Offset: 0x001978C7
		public static DBlockChunk GetRootAsDBlockChunk(ByteBuffer _bb, DBlockChunk obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008B3C RID: 35644 RVA: 0x001994E3 File Offset: 0x001978E3
		public DBlockChunk __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700188A RID: 6282
		// (get) Token: 0x06008B3D RID: 35645 RVA: 0x001994F4 File Offset: 0x001978F4
		public int GridWidth
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x1700188B RID: 6283
		// (get) Token: 0x06008B3E RID: 35646 RVA: 0x00199528 File Offset: 0x00197928
		public int GridHeight
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x06008B3F RID: 35647 RVA: 0x0019955C File Offset: 0x0019795C
		public byte GetGridBlockData(int j)
		{
			int num = base.__offset(8);
			return (num == 0) ? 0 : this.bb.Get(base.__vector(num) + j);
		}

		// Token: 0x1700188C RID: 6284
		// (get) Token: 0x06008B40 RID: 35648 RVA: 0x00199594 File Offset: 0x00197994
		public int GridBlockDataLength
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x1700188D RID: 6285
		// (get) Token: 0x06008B41 RID: 35649 RVA: 0x001995BC File Offset: 0x001979BC
		public Vector3 BoundingBoxMin
		{
			get
			{
				return this.GetBoundingBoxMin(new Vector3());
			}
		}

		// Token: 0x06008B42 RID: 35650 RVA: 0x001995CC File Offset: 0x001979CC
		public Vector3 GetBoundingBoxMin(Vector3 obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700188E RID: 6286
		// (get) Token: 0x06008B43 RID: 35651 RVA: 0x00199602 File Offset: 0x00197A02
		public Vector3 BoundingBoxMax
		{
			get
			{
				return this.GetBoundingBoxMax(new Vector3());
			}
		}

		// Token: 0x06008B44 RID: 35652 RVA: 0x00199610 File Offset: 0x00197A10
		public Vector3 GetBoundingBoxMax(Vector3 obj)
		{
			int num = base.__offset(12);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x06008B45 RID: 35653 RVA: 0x00199646 File Offset: 0x00197A46
		public static void StartDBlockChunk(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x06008B46 RID: 35654 RVA: 0x0019964F File Offset: 0x00197A4F
		public static void AddGridWidth(FlatBufferBuilder builder, int gridWidth)
		{
			builder.AddInt(0, gridWidth, 0);
		}

		// Token: 0x06008B47 RID: 35655 RVA: 0x0019965A File Offset: 0x00197A5A
		public static void AddGridHeight(FlatBufferBuilder builder, int gridHeight)
		{
			builder.AddInt(1, gridHeight, 0);
		}

		// Token: 0x06008B48 RID: 35656 RVA: 0x00199665 File Offset: 0x00197A65
		public static void AddGridBlockData(FlatBufferBuilder builder, VectorOffset gridBlockDataOffset)
		{
			builder.AddOffset(2, gridBlockDataOffset.Value, 0);
		}

		// Token: 0x06008B49 RID: 35657 RVA: 0x00199678 File Offset: 0x00197A78
		public static VectorOffset CreateGridBlockDataVector(FlatBufferBuilder builder, byte[] data)
		{
			builder.StartVector(1, data.Length, 1);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddByte(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06008B4A RID: 35658 RVA: 0x001996B5 File Offset: 0x00197AB5
		public static void StartGridBlockDataVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(1, numElems, 1);
		}

		// Token: 0x06008B4B RID: 35659 RVA: 0x001996C0 File Offset: 0x00197AC0
		public static void AddBoundingBoxMin(FlatBufferBuilder builder, Offset<Vector3> boundingBoxMinOffset)
		{
			builder.AddStruct(3, boundingBoxMinOffset.Value, 0);
		}

		// Token: 0x06008B4C RID: 35660 RVA: 0x001996D1 File Offset: 0x00197AD1
		public static void AddBoundingBoxMax(FlatBufferBuilder builder, Offset<Vector3> boundingBoxMaxOffset)
		{
			builder.AddStruct(4, boundingBoxMaxOffset.Value, 0);
		}

		// Token: 0x06008B4D RID: 35661 RVA: 0x001996E4 File Offset: 0x00197AE4
		public static Offset<DBlockChunk> EndDBlockChunk(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DBlockChunk>(value);
		}
	}
}
