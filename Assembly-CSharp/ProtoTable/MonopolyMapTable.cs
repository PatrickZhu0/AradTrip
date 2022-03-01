using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000512 RID: 1298
	public class MonopolyMapTable : IFlatbufferObject
	{
		// Token: 0x170011AA RID: 4522
		// (get) Token: 0x0600428F RID: 17039 RVA: 0x000D8960 File Offset: 0x000D6D60
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004290 RID: 17040 RVA: 0x000D896D File Offset: 0x000D6D6D
		public static MonopolyMapTable GetRootAsMonopolyMapTable(ByteBuffer _bb)
		{
			return MonopolyMapTable.GetRootAsMonopolyMapTable(_bb, new MonopolyMapTable());
		}

		// Token: 0x06004291 RID: 17041 RVA: 0x000D897A File Offset: 0x000D6D7A
		public static MonopolyMapTable GetRootAsMonopolyMapTable(ByteBuffer _bb, MonopolyMapTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004292 RID: 17042 RVA: 0x000D8996 File Offset: 0x000D6D96
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004293 RID: 17043 RVA: 0x000D89B0 File Offset: 0x000D6DB0
		public MonopolyMapTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170011AB RID: 4523
		// (get) Token: 0x06004294 RID: 17044 RVA: 0x000D89BC File Offset: 0x000D6DBC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1195108091 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170011AC RID: 4524
		// (get) Token: 0x06004295 RID: 17045 RVA: 0x000D8A08 File Offset: 0x000D6E08
		public int turn
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1195108091 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06004296 RID: 17046 RVA: 0x000D8A54 File Offset: 0x000D6E54
		public int contentArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (1195108091 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170011AD RID: 4525
		// (get) Token: 0x06004297 RID: 17047 RVA: 0x000D8AA0 File Offset: 0x000D6EA0
		public int contentLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004298 RID: 17048 RVA: 0x000D8AD2 File Offset: 0x000D6ED2
		public ArraySegment<byte>? GetContentBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x170011AE RID: 4526
		// (get) Token: 0x06004299 RID: 17049 RVA: 0x000D8AE0 File Offset: 0x000D6EE0
		public FlatBufferArray<int> content
		{
			get
			{
				if (this.contentValue == null)
				{
					this.contentValue = new FlatBufferArray<int>(new Func<int, int>(this.contentArray), this.contentLength);
				}
				return this.contentValue;
			}
		}

		// Token: 0x0600429A RID: 17050 RVA: 0x000D8B10 File Offset: 0x000D6F10
		public static Offset<MonopolyMapTable> CreateMonopolyMapTable(FlatBufferBuilder builder, int ID = 0, int turn = 0, VectorOffset contentOffset = default(VectorOffset))
		{
			builder.StartObject(3);
			MonopolyMapTable.AddContent(builder, contentOffset);
			MonopolyMapTable.AddTurn(builder, turn);
			MonopolyMapTable.AddID(builder, ID);
			return MonopolyMapTable.EndMonopolyMapTable(builder);
		}

		// Token: 0x0600429B RID: 17051 RVA: 0x000D8B34 File Offset: 0x000D6F34
		public static void StartMonopolyMapTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0600429C RID: 17052 RVA: 0x000D8B3D File Offset: 0x000D6F3D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600429D RID: 17053 RVA: 0x000D8B48 File Offset: 0x000D6F48
		public static void AddTurn(FlatBufferBuilder builder, int turn)
		{
			builder.AddInt(1, turn, 0);
		}

		// Token: 0x0600429E RID: 17054 RVA: 0x000D8B53 File Offset: 0x000D6F53
		public static void AddContent(FlatBufferBuilder builder, VectorOffset contentOffset)
		{
			builder.AddOffset(2, contentOffset.Value, 0);
		}

		// Token: 0x0600429F RID: 17055 RVA: 0x000D8B64 File Offset: 0x000D6F64
		public static VectorOffset CreateContentVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060042A0 RID: 17056 RVA: 0x000D8BA1 File Offset: 0x000D6FA1
		public static void StartContentVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060042A1 RID: 17057 RVA: 0x000D8BAC File Offset: 0x000D6FAC
		public static Offset<MonopolyMapTable> EndMonopolyMapTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<MonopolyMapTable>(value);
		}

		// Token: 0x060042A2 RID: 17058 RVA: 0x000D8BC6 File Offset: 0x000D6FC6
		public static void FinishMonopolyMapTableBuffer(FlatBufferBuilder builder, Offset<MonopolyMapTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040018D5 RID: 6357
		private Table __p = new Table();

		// Token: 0x040018D6 RID: 6358
		private FlatBufferArray<int> contentValue;

		// Token: 0x02000513 RID: 1299
		public enum eCrypt
		{
			// Token: 0x040018D8 RID: 6360
			code = 1195108091
		}
	}
}
