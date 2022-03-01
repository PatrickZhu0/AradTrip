using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020005DC RID: 1500
	public class SwitchClientFunctionTable : IFlatbufferObject
	{
		// Token: 0x170015E6 RID: 5606
		// (get) Token: 0x06004F86 RID: 20358 RVA: 0x000F6B34 File Offset: 0x000F4F34
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004F87 RID: 20359 RVA: 0x000F6B41 File Offset: 0x000F4F41
		public static SwitchClientFunctionTable GetRootAsSwitchClientFunctionTable(ByteBuffer _bb)
		{
			return SwitchClientFunctionTable.GetRootAsSwitchClientFunctionTable(_bb, new SwitchClientFunctionTable());
		}

		// Token: 0x06004F88 RID: 20360 RVA: 0x000F6B4E File Offset: 0x000F4F4E
		public static SwitchClientFunctionTable GetRootAsSwitchClientFunctionTable(ByteBuffer _bb, SwitchClientFunctionTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004F89 RID: 20361 RVA: 0x000F6B6A File Offset: 0x000F4F6A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004F8A RID: 20362 RVA: 0x000F6B84 File Offset: 0x000F4F84
		public SwitchClientFunctionTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170015E7 RID: 5607
		// (get) Token: 0x06004F8B RID: 20363 RVA: 0x000F6B90 File Offset: 0x000F4F90
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1559718353 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015E8 RID: 5608
		// (get) Token: 0x06004F8C RID: 20364 RVA: 0x000F6BDC File Offset: 0x000F4FDC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F8D RID: 20365 RVA: 0x000F6C1E File Offset: 0x000F501E
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170015E9 RID: 5609
		// (get) Token: 0x06004F8E RID: 20366 RVA: 0x000F6C2C File Offset: 0x000F502C
		public bool Open
		{
			get
			{
				int num = this.__p.__offset(8);
				return num != 0 && 0 != this.__p.bb.Get(num + this.__p.bb_pos);
			}
		}

		// Token: 0x170015EA RID: 5610
		// (get) Token: 0x06004F8F RID: 20367 RVA: 0x000F6C78 File Offset: 0x000F5078
		public string DescA
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F90 RID: 20368 RVA: 0x000F6CBB File Offset: 0x000F50BB
		public ArraySegment<byte>? GetDescABytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x170015EB RID: 5611
		// (get) Token: 0x06004F91 RID: 20369 RVA: 0x000F6CCC File Offset: 0x000F50CC
		public int ValueA
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1559718353 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015EC RID: 5612
		// (get) Token: 0x06004F92 RID: 20370 RVA: 0x000F6D18 File Offset: 0x000F5118
		public string DescB
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F93 RID: 20371 RVA: 0x000F6D5B File Offset: 0x000F515B
		public ArraySegment<byte>? GetDescBBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170015ED RID: 5613
		// (get) Token: 0x06004F94 RID: 20372 RVA: 0x000F6D6C File Offset: 0x000F516C
		public int ValueB
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1559718353 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015EE RID: 5614
		// (get) Token: 0x06004F95 RID: 20373 RVA: 0x000F6DB8 File Offset: 0x000F51B8
		public string DescC
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F96 RID: 20374 RVA: 0x000F6DFB File Offset: 0x000F51FB
		public ArraySegment<byte>? GetDescCBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x170015EF RID: 5615
		// (get) Token: 0x06004F97 RID: 20375 RVA: 0x000F6E0C File Offset: 0x000F520C
		public int ValueC
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1559718353 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170015F0 RID: 5616
		// (get) Token: 0x06004F98 RID: 20376 RVA: 0x000F6E58 File Offset: 0x000F5258
		public string DescD
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F99 RID: 20377 RVA: 0x000F6E9B File Offset: 0x000F529B
		public ArraySegment<byte>? GetDescDBytes()
		{
			return this.__p.__vector_as_arraysegment(22);
		}

		// Token: 0x06004F9A RID: 20378 RVA: 0x000F6EAC File Offset: 0x000F52AC
		public int ValueDArray(int j)
		{
			int num = this.__p.__offset(24);
			return (num == 0) ? 0 : (-1559718353 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170015F1 RID: 5617
		// (get) Token: 0x06004F9B RID: 20379 RVA: 0x000F6EFC File Offset: 0x000F52FC
		public int ValueDLength
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004F9C RID: 20380 RVA: 0x000F6F2F File Offset: 0x000F532F
		public ArraySegment<byte>? GetValueDBytes()
		{
			return this.__p.__vector_as_arraysegment(24);
		}

		// Token: 0x170015F2 RID: 5618
		// (get) Token: 0x06004F9D RID: 20381 RVA: 0x000F6F3E File Offset: 0x000F533E
		public FlatBufferArray<int> ValueD
		{
			get
			{
				if (this.ValueDValue == null)
				{
					this.ValueDValue = new FlatBufferArray<int>(new Func<int, int>(this.ValueDArray), this.ValueDLength);
				}
				return this.ValueDValue;
			}
		}

		// Token: 0x170015F3 RID: 5619
		// (get) Token: 0x06004F9E RID: 20382 RVA: 0x000F6F70 File Offset: 0x000F5370
		public string DescE
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06004F9F RID: 20383 RVA: 0x000F6FB3 File Offset: 0x000F53B3
		public ArraySegment<byte>? GetDescEBytes()
		{
			return this.__p.__vector_as_arraysegment(26);
		}

		// Token: 0x170015F4 RID: 5620
		// (get) Token: 0x06004FA0 RID: 20384 RVA: 0x000F6FC4 File Offset: 0x000F53C4
		public int ValueE
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? 0 : (-1559718353 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004FA1 RID: 20385 RVA: 0x000F7010 File Offset: 0x000F5410
		public static Offset<SwitchClientFunctionTable> CreateSwitchClientFunctionTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), bool Open = false, StringOffset DescAOffset = default(StringOffset), int ValueA = 0, StringOffset DescBOffset = default(StringOffset), int ValueB = 0, StringOffset DescCOffset = default(StringOffset), int ValueC = 0, StringOffset DescDOffset = default(StringOffset), VectorOffset ValueDOffset = default(VectorOffset), StringOffset DescEOffset = default(StringOffset), int ValueE = 0)
		{
			builder.StartObject(13);
			SwitchClientFunctionTable.AddValueE(builder, ValueE);
			SwitchClientFunctionTable.AddDescE(builder, DescEOffset);
			SwitchClientFunctionTable.AddValueD(builder, ValueDOffset);
			SwitchClientFunctionTable.AddDescD(builder, DescDOffset);
			SwitchClientFunctionTable.AddValueC(builder, ValueC);
			SwitchClientFunctionTable.AddDescC(builder, DescCOffset);
			SwitchClientFunctionTable.AddValueB(builder, ValueB);
			SwitchClientFunctionTable.AddDescB(builder, DescBOffset);
			SwitchClientFunctionTable.AddValueA(builder, ValueA);
			SwitchClientFunctionTable.AddDescA(builder, DescAOffset);
			SwitchClientFunctionTable.AddName(builder, NameOffset);
			SwitchClientFunctionTable.AddID(builder, ID);
			SwitchClientFunctionTable.AddOpen(builder, Open);
			return SwitchClientFunctionTable.EndSwitchClientFunctionTable(builder);
		}

		// Token: 0x06004FA2 RID: 20386 RVA: 0x000F7090 File Offset: 0x000F5490
		public static void StartSwitchClientFunctionTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x06004FA3 RID: 20387 RVA: 0x000F709A File Offset: 0x000F549A
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004FA4 RID: 20388 RVA: 0x000F70A5 File Offset: 0x000F54A5
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06004FA5 RID: 20389 RVA: 0x000F70B6 File Offset: 0x000F54B6
		public static void AddOpen(FlatBufferBuilder builder, bool Open)
		{
			builder.AddBool(2, Open, false);
		}

		// Token: 0x06004FA6 RID: 20390 RVA: 0x000F70C1 File Offset: 0x000F54C1
		public static void AddDescA(FlatBufferBuilder builder, StringOffset DescAOffset)
		{
			builder.AddOffset(3, DescAOffset.Value, 0);
		}

		// Token: 0x06004FA7 RID: 20391 RVA: 0x000F70D2 File Offset: 0x000F54D2
		public static void AddValueA(FlatBufferBuilder builder, int ValueA)
		{
			builder.AddInt(4, ValueA, 0);
		}

		// Token: 0x06004FA8 RID: 20392 RVA: 0x000F70DD File Offset: 0x000F54DD
		public static void AddDescB(FlatBufferBuilder builder, StringOffset DescBOffset)
		{
			builder.AddOffset(5, DescBOffset.Value, 0);
		}

		// Token: 0x06004FA9 RID: 20393 RVA: 0x000F70EE File Offset: 0x000F54EE
		public static void AddValueB(FlatBufferBuilder builder, int ValueB)
		{
			builder.AddInt(6, ValueB, 0);
		}

		// Token: 0x06004FAA RID: 20394 RVA: 0x000F70F9 File Offset: 0x000F54F9
		public static void AddDescC(FlatBufferBuilder builder, StringOffset DescCOffset)
		{
			builder.AddOffset(7, DescCOffset.Value, 0);
		}

		// Token: 0x06004FAB RID: 20395 RVA: 0x000F710A File Offset: 0x000F550A
		public static void AddValueC(FlatBufferBuilder builder, int ValueC)
		{
			builder.AddInt(8, ValueC, 0);
		}

		// Token: 0x06004FAC RID: 20396 RVA: 0x000F7115 File Offset: 0x000F5515
		public static void AddDescD(FlatBufferBuilder builder, StringOffset DescDOffset)
		{
			builder.AddOffset(9, DescDOffset.Value, 0);
		}

		// Token: 0x06004FAD RID: 20397 RVA: 0x000F7127 File Offset: 0x000F5527
		public static void AddValueD(FlatBufferBuilder builder, VectorOffset ValueDOffset)
		{
			builder.AddOffset(10, ValueDOffset.Value, 0);
		}

		// Token: 0x06004FAE RID: 20398 RVA: 0x000F713C File Offset: 0x000F553C
		public static VectorOffset CreateValueDVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004FAF RID: 20399 RVA: 0x000F7179 File Offset: 0x000F5579
		public static void StartValueDVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06004FB0 RID: 20400 RVA: 0x000F7184 File Offset: 0x000F5584
		public static void AddDescE(FlatBufferBuilder builder, StringOffset DescEOffset)
		{
			builder.AddOffset(11, DescEOffset.Value, 0);
		}

		// Token: 0x06004FB1 RID: 20401 RVA: 0x000F7196 File Offset: 0x000F5596
		public static void AddValueE(FlatBufferBuilder builder, int ValueE)
		{
			builder.AddInt(12, ValueE, 0);
		}

		// Token: 0x06004FB2 RID: 20402 RVA: 0x000F71A4 File Offset: 0x000F55A4
		public static Offset<SwitchClientFunctionTable> EndSwitchClientFunctionTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<SwitchClientFunctionTable>(value);
		}

		// Token: 0x06004FB3 RID: 20403 RVA: 0x000F71BE File Offset: 0x000F55BE
		public static void FinishSwitchClientFunctionTableBuffer(FlatBufferBuilder builder, Offset<SwitchClientFunctionTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001BF0 RID: 7152
		private Table __p = new Table();

		// Token: 0x04001BF1 RID: 7153
		private FlatBufferArray<int> ValueDValue;

		// Token: 0x020005DD RID: 1501
		public enum eCrypt
		{
			// Token: 0x04001BF3 RID: 7155
			code = -1559718353
		}
	}
}
