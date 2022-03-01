using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000321 RID: 801
	public class ChiJiPointTable : IFlatbufferObject
	{
		// Token: 0x1700060F RID: 1551
		// (get) Token: 0x06001FCB RID: 8139 RVA: 0x00084E00 File Offset: 0x00083200
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001FCC RID: 8140 RVA: 0x00084E0D File Offset: 0x0008320D
		public static ChiJiPointTable GetRootAsChiJiPointTable(ByteBuffer _bb)
		{
			return ChiJiPointTable.GetRootAsChiJiPointTable(_bb, new ChiJiPointTable());
		}

		// Token: 0x06001FCD RID: 8141 RVA: 0x00084E1A File Offset: 0x0008321A
		public static ChiJiPointTable GetRootAsChiJiPointTable(ByteBuffer _bb, ChiJiPointTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001FCE RID: 8142 RVA: 0x00084E36 File Offset: 0x00083236
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001FCF RID: 8143 RVA: 0x00084E50 File Offset: 0x00083250
		public ChiJiPointTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000610 RID: 1552
		// (get) Token: 0x06001FD0 RID: 8144 RVA: 0x00084E5C File Offset: 0x0008325C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (863514243 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000611 RID: 1553
		// (get) Token: 0x06001FD1 RID: 8145 RVA: 0x00084EA8 File Offset: 0x000832A8
		public int Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (863514243 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001FD2 RID: 8146 RVA: 0x00084EF4 File Offset: 0x000832F4
		public int packIDsArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (863514243 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000612 RID: 1554
		// (get) Token: 0x06001FD3 RID: 8147 RVA: 0x00084F40 File Offset: 0x00083340
		public int packIDsLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06001FD4 RID: 8148 RVA: 0x00084F72 File Offset: 0x00083372
		public ArraySegment<byte>? GetPackIDsBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x17000613 RID: 1555
		// (get) Token: 0x06001FD5 RID: 8149 RVA: 0x00084F80 File Offset: 0x00083380
		public FlatBufferArray<int> packIDs
		{
			get
			{
				if (this.packIDsValue == null)
				{
					this.packIDsValue = new FlatBufferArray<int>(new Func<int, int>(this.packIDsArray), this.packIDsLength);
				}
				return this.packIDsValue;
			}
		}

		// Token: 0x06001FD6 RID: 8150 RVA: 0x00084FB0 File Offset: 0x000833B0
		public static Offset<ChiJiPointTable> CreateChiJiPointTable(FlatBufferBuilder builder, int ID = 0, int Name = 0, VectorOffset packIDsOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			ChiJiPointTable.AddPackIDs(builder, packIDsOffset);
			ChiJiPointTable.AddName(builder, Name);
			ChiJiPointTable.AddID(builder, ID);
			return ChiJiPointTable.EndChiJiPointTable(builder);
		}

		// Token: 0x06001FD7 RID: 8151 RVA: 0x00084FD4 File Offset: 0x000833D4
		public static void StartChiJiPointTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001FD8 RID: 8152 RVA: 0x00084FDD File Offset: 0x000833DD
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001FD9 RID: 8153 RVA: 0x00084FE8 File Offset: 0x000833E8
		public static void AddName(FlatBufferBuilder builder, int Name)
		{
			builder.AddInt(1, Name, 0);
		}

		// Token: 0x06001FDA RID: 8154 RVA: 0x00084FF3 File Offset: 0x000833F3
		public static void AddPackIDs(FlatBufferBuilder builder, VectorOffset packIDsOffset)
		{
			builder.AddOffset(2, packIDsOffset.Value, 0);
		}

		// Token: 0x06001FDB RID: 8155 RVA: 0x00085004 File Offset: 0x00083404
		public static VectorOffset CreatePackIDsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06001FDC RID: 8156 RVA: 0x00085041 File Offset: 0x00083441
		public static void StartPackIDsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06001FDD RID: 8157 RVA: 0x0008504C File Offset: 0x0008344C
		public static Offset<ChiJiPointTable> EndChiJiPointTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiPointTable>(value);
		}

		// Token: 0x06001FDE RID: 8158 RVA: 0x00085066 File Offset: 0x00083466
		public static void FinishChiJiPointTableBuffer(FlatBufferBuilder builder, Offset<ChiJiPointTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000F74 RID: 3956
		private Table __p = new Table();

		// Token: 0x04000F75 RID: 3957
		private FlatBufferArray<int> packIDsValue;

		// Token: 0x02000322 RID: 802
		public enum eCrypt
		{
			// Token: 0x04000F77 RID: 3959
			code = 863514243
		}
	}
}
