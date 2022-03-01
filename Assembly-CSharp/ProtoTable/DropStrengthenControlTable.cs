using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200038F RID: 911
	public class DropStrengthenControlTable : IFlatbufferObject
	{
		// Token: 0x170008CA RID: 2250
		// (get) Token: 0x0600278B RID: 10123 RVA: 0x000980F4 File Offset: 0x000964F4
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600278C RID: 10124 RVA: 0x00098101 File Offset: 0x00096501
		public static DropStrengthenControlTable GetRootAsDropStrengthenControlTable(ByteBuffer _bb)
		{
			return DropStrengthenControlTable.GetRootAsDropStrengthenControlTable(_bb, new DropStrengthenControlTable());
		}

		// Token: 0x0600278D RID: 10125 RVA: 0x0009810E File Offset: 0x0009650E
		public static DropStrengthenControlTable GetRootAsDropStrengthenControlTable(ByteBuffer _bb, DropStrengthenControlTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600278E RID: 10126 RVA: 0x0009812A File Offset: 0x0009652A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600278F RID: 10127 RVA: 0x00098144 File Offset: 0x00096544
		public DropStrengthenControlTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008CB RID: 2251
		// (get) Token: 0x06002790 RID: 10128 RVA: 0x00098150 File Offset: 0x00096550
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (903271090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008CC RID: 2252
		// (get) Token: 0x06002791 RID: 10129 RVA: 0x0009819C File Offset: 0x0009659C
		public int Lv
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (903271090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008CD RID: 2253
		// (get) Token: 0x06002792 RID: 10130 RVA: 0x000981E8 File Offset: 0x000965E8
		public int Color
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (903271090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008CE RID: 2254
		// (get) Token: 0x06002793 RID: 10131 RVA: 0x00098234 File Offset: 0x00096634
		public int Color2
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (903271090 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002794 RID: 10132 RVA: 0x00098280 File Offset: 0x00096680
		public int StrengthenArray(int j)
		{
			int num = this.__p.__offset(12);
			return (num == 0) ? 0 : (903271090 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008CF RID: 2255
		// (get) Token: 0x06002795 RID: 10133 RVA: 0x000982D0 File Offset: 0x000966D0
		public int StrengthenLength
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002796 RID: 10134 RVA: 0x00098303 File Offset: 0x00096703
		public ArraySegment<byte>? GetStrengthenBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x170008D0 RID: 2256
		// (get) Token: 0x06002797 RID: 10135 RVA: 0x00098312 File Offset: 0x00096712
		public FlatBufferArray<int> Strengthen
		{
			get
			{
				if (this.StrengthenValue == null)
				{
					this.StrengthenValue = new FlatBufferArray<int>(new Func<int, int>(this.StrengthenArray), this.StrengthenLength);
				}
				return this.StrengthenValue;
			}
		}

		// Token: 0x06002798 RID: 10136 RVA: 0x00098344 File Offset: 0x00096744
		public int WeightArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (903271090 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x06002799 RID: 10137 RVA: 0x00098394 File Offset: 0x00096794
		public int WeightLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600279A RID: 10138 RVA: 0x000983C7 File Offset: 0x000967C7
		public ArraySegment<byte>? GetWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x0600279B RID: 10139 RVA: 0x000983D6 File Offset: 0x000967D6
		public FlatBufferArray<int> Weight
		{
			get
			{
				if (this.WeightValue == null)
				{
					this.WeightValue = new FlatBufferArray<int>(new Func<int, int>(this.WeightArray), this.WeightLength);
				}
				return this.WeightValue;
			}
		}

		// Token: 0x0600279C RID: 10140 RVA: 0x00098406 File Offset: 0x00096806
		public static Offset<DropStrengthenControlTable> CreateDropStrengthenControlTable(FlatBufferBuilder builder, int ID = 0, int Lv = 0, int Color = 0, int Color2 = 0, VectorOffset StrengthenOffset = default(VectorOffset), VectorOffset WeightOffset = default(VectorOffset))
		{
			builder.StartObject(6);
			DropStrengthenControlTable.AddWeight(builder, WeightOffset);
			DropStrengthenControlTable.AddStrengthen(builder, StrengthenOffset);
			DropStrengthenControlTable.AddColor2(builder, Color2);
			DropStrengthenControlTable.AddColor(builder, Color);
			DropStrengthenControlTable.AddLv(builder, Lv);
			DropStrengthenControlTable.AddID(builder, ID);
			return DropStrengthenControlTable.EndDropStrengthenControlTable(builder);
		}

		// Token: 0x0600279D RID: 10141 RVA: 0x00098442 File Offset: 0x00096842
		public static void StartDropStrengthenControlTable(FlatBufferBuilder builder)
		{
			builder.StartObject(6);
		}

		// Token: 0x0600279E RID: 10142 RVA: 0x0009844B File Offset: 0x0009684B
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600279F RID: 10143 RVA: 0x00098456 File Offset: 0x00096856
		public static void AddLv(FlatBufferBuilder builder, int Lv)
		{
			builder.AddInt(1, Lv, 0);
		}

		// Token: 0x060027A0 RID: 10144 RVA: 0x00098461 File Offset: 0x00096861
		public static void AddColor(FlatBufferBuilder builder, int Color)
		{
			builder.AddInt(2, Color, 0);
		}

		// Token: 0x060027A1 RID: 10145 RVA: 0x0009846C File Offset: 0x0009686C
		public static void AddColor2(FlatBufferBuilder builder, int Color2)
		{
			builder.AddInt(3, Color2, 0);
		}

		// Token: 0x060027A2 RID: 10146 RVA: 0x00098477 File Offset: 0x00096877
		public static void AddStrengthen(FlatBufferBuilder builder, VectorOffset StrengthenOffset)
		{
			builder.AddOffset(4, StrengthenOffset.Value, 0);
		}

		// Token: 0x060027A3 RID: 10147 RVA: 0x00098488 File Offset: 0x00096888
		public static VectorOffset CreateStrengthenVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060027A4 RID: 10148 RVA: 0x000984C5 File Offset: 0x000968C5
		public static void StartStrengthenVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060027A5 RID: 10149 RVA: 0x000984D0 File Offset: 0x000968D0
		public static void AddWeight(FlatBufferBuilder builder, VectorOffset WeightOffset)
		{
			builder.AddOffset(5, WeightOffset.Value, 0);
		}

		// Token: 0x060027A6 RID: 10150 RVA: 0x000984E4 File Offset: 0x000968E4
		public static VectorOffset CreateWeightVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060027A7 RID: 10151 RVA: 0x00098521 File Offset: 0x00096921
		public static void StartWeightVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060027A8 RID: 10152 RVA: 0x0009852C File Offset: 0x0009692C
		public static Offset<DropStrengthenControlTable> EndDropStrengthenControlTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DropStrengthenControlTable>(value);
		}

		// Token: 0x060027A9 RID: 10153 RVA: 0x00098546 File Offset: 0x00096946
		public static void FinishDropStrengthenControlTableBuffer(FlatBufferBuilder builder, Offset<DropStrengthenControlTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011C6 RID: 4550
		private Table __p = new Table();

		// Token: 0x040011C7 RID: 4551
		private FlatBufferArray<int> StrengthenValue;

		// Token: 0x040011C8 RID: 4552
		private FlatBufferArray<int> WeightValue;

		// Token: 0x02000390 RID: 912
		public enum eCrypt
		{
			// Token: 0x040011CA RID: 4554
			code = 903271090
		}
	}
}
