using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004E7 RID: 1255
	public class MainlandTable : IFlatbufferObject
	{
		// Token: 0x170010C5 RID: 4293
		// (get) Token: 0x06003FEE RID: 16366 RVA: 0x000D25A0 File Offset: 0x000D09A0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003FEF RID: 16367 RVA: 0x000D25AD File Offset: 0x000D09AD
		public static MainlandTable GetRootAsMainlandTable(ByteBuffer _bb)
		{
			return MainlandTable.GetRootAsMainlandTable(_bb, new MainlandTable());
		}

		// Token: 0x06003FF0 RID: 16368 RVA: 0x000D25BA File Offset: 0x000D09BA
		public static MainlandTable GetRootAsMainlandTable(ByteBuffer _bb, MainlandTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003FF1 RID: 16369 RVA: 0x000D25D6 File Offset: 0x000D09D6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003FF2 RID: 16370 RVA: 0x000D25F0 File Offset: 0x000D09F0
		public MainlandTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170010C6 RID: 4294
		// (get) Token: 0x06003FF3 RID: 16371 RVA: 0x000D25FC File Offset: 0x000D09FC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-981910982 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x06003FF4 RID: 16372 RVA: 0x000D2648 File Offset: 0x000D0A48
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003FF5 RID: 16373 RVA: 0x000D268A File Offset: 0x000D0A8A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06003FF6 RID: 16374 RVA: 0x000D2698 File Offset: 0x000D0A98
		public int AreaIDsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (-981910982 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x06003FF7 RID: 16375 RVA: 0x000D26E4 File Offset: 0x000D0AE4
		public int AreaIDsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06003FF8 RID: 16376 RVA: 0x000D2716 File Offset: 0x000D0B16
		public ArraySegment<byte>? GetAreaIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x06003FF9 RID: 16377 RVA: 0x000D2724 File Offset: 0x000D0B24
		public FlatBufferArray<int> AreaIDs
		{
			get
			{
				if (this.AreaIDsValue == null)
				{
					this.AreaIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.AreaIDsArray), this.AreaIDsLength);
				}
				return this.AreaIDsValue;
			}
		}

		// Token: 0x06003FFA RID: 16378 RVA: 0x000D2754 File Offset: 0x000D0B54
		public static Offset<MainlandTable> CreateMainlandTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), VectorOffset AreaIDsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			MainlandTable.AddAreaIDs(builder, AreaIDsOffset);
			MainlandTable.AddName(builder, NameOffset);
			MainlandTable.AddID(builder, ID);
			return MainlandTable.EndMainlandTable(builder);
		}

		// Token: 0x06003FFB RID: 16379 RVA: 0x000D2778 File Offset: 0x000D0B78
		public static void StartMainlandTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06003FFC RID: 16380 RVA: 0x000D2781 File Offset: 0x000D0B81
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003FFD RID: 16381 RVA: 0x000D278C File Offset: 0x000D0B8C
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06003FFE RID: 16382 RVA: 0x000D279D File Offset: 0x000D0B9D
		public static void AddAreaIDs(FlatBufferBuilder builder, VectorOffset AreaIDsOffset)
		{
			builder.AddOffset(2, AreaIDsOffset.Value, 0);
		}

		// Token: 0x06003FFF RID: 16383 RVA: 0x000D27B0 File Offset: 0x000D0BB0
		public static VectorOffset CreateAreaIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004000 RID: 16384 RVA: 0x000D27ED File Offset: 0x000D0BED
		public static void StartAreaIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004001 RID: 16385 RVA: 0x000D27F8 File Offset: 0x000D0BF8
		public static Offset<MainlandTable> EndMainlandTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MainlandTable>(value);
		}

		// Token: 0x06004002 RID: 16386 RVA: 0x000D2812 File Offset: 0x000D0C12
		public static void FinishMainlandTableBuffer(FlatBufferBuilder builder, Offset<MainlandTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001819 RID: 6169
		private Table __p = new Table();

		// Token: 0x0400181A RID: 6170
		private FlatBufferArray<int> AreaIDsValue;

		// Token: 0x020004E8 RID: 1256
		public enum eCrypt
		{
			// Token: 0x0400181C RID: 6172
			code = -981910982
		}
	}
}
