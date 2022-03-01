using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000569 RID: 1385
	public class RandPropNumTable : IFlatbufferObject
	{
		// Token: 0x1700133B RID: 4923
		// (get) Token: 0x06004764 RID: 18276 RVA: 0x000E380C File Offset: 0x000E1C0C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004765 RID: 18277 RVA: 0x000E3819 File Offset: 0x000E1C19
		public static RandPropNumTable GetRootAsRandPropNumTable(ByteBuffer _bb)
		{
			return RandPropNumTable.GetRootAsRandPropNumTable(_bb, new RandPropNumTable());
		}

		// Token: 0x06004766 RID: 18278 RVA: 0x000E3826 File Offset: 0x000E1C26
		public static RandPropNumTable GetRootAsRandPropNumTable(ByteBuffer _bb, RandPropNumTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004767 RID: 18279 RVA: 0x000E3842 File Offset: 0x000E1C42
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004768 RID: 18280 RVA: 0x000E385C File Offset: 0x000E1C5C
		public RandPropNumTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700133C RID: 4924
		// (get) Token: 0x06004769 RID: 18281 RVA: 0x000E3868 File Offset: 0x000E1C68
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (339145848 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700133D RID: 4925
		// (get) Token: 0x0600476A RID: 18282 RVA: 0x000E38B4 File Offset: 0x000E1CB4
		public RandPropNumTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(6);
				return (RandPropNumTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600476B RID: 18283 RVA: 0x000E38F8 File Offset: 0x000E1CF8
		public int ValueArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? 0 : (339145848 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700133E RID: 4926
		// (get) Token: 0x0600476C RID: 18284 RVA: 0x000E3944 File Offset: 0x000E1D44
		public int ValueLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600476D RID: 18285 RVA: 0x000E3976 File Offset: 0x000E1D76
		public ArraySegment<byte>? GetValueBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x1700133F RID: 4927
		// (get) Token: 0x0600476E RID: 18286 RVA: 0x000E3984 File Offset: 0x000E1D84
		public FlatBufferArray<int> Value
		{
			get
			{
				if (this.ValueValue == null)
				{
					this.ValueValue = new FlatBufferArray<int>(new Func<int, int>(this.ValueArray), this.ValueLength);
				}
				return this.ValueValue;
			}
		}

		// Token: 0x0600476F RID: 18287 RVA: 0x000E39B4 File Offset: 0x000E1DB4
		public int WeightArray(int j)
		{
			int num = this.__p.__offset(10);
			return (num == 0) ? 0 : (339145848 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17001340 RID: 4928
		// (get) Token: 0x06004770 RID: 18288 RVA: 0x000E3A04 File Offset: 0x000E1E04
		public int WeightLength
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06004771 RID: 18289 RVA: 0x000E3A37 File Offset: 0x000E1E37
		public ArraySegment<byte>? GetWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17001341 RID: 4929
		// (get) Token: 0x06004772 RID: 18290 RVA: 0x000E3A46 File Offset: 0x000E1E46
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

		// Token: 0x06004773 RID: 18291 RVA: 0x000E3A76 File Offset: 0x000E1E76
		public static Offset<RandPropNumTable> CreateRandPropNumTable(FlatBufferBuilder builder, int ID = 0, RandPropNumTable.eColor Color = RandPropNumTable.eColor.Color_None, VectorOffset ValueOffset = default(VectorOffset), VectorOffset WeightOffset = default(VectorOffset))
		{
			builder.StartObject(4);
			RandPropNumTable.AddWeight(builder, WeightOffset);
			RandPropNumTable.AddValue(builder, ValueOffset);
			RandPropNumTable.AddColor(builder, Color);
			RandPropNumTable.AddID(builder, ID);
			return RandPropNumTable.EndRandPropNumTable(builder);
		}

		// Token: 0x06004774 RID: 18292 RVA: 0x000E3AA2 File Offset: 0x000E1EA2
		public static void StartRandPropNumTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06004775 RID: 18293 RVA: 0x000E3AAB File Offset: 0x000E1EAB
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06004776 RID: 18294 RVA: 0x000E3AB6 File Offset: 0x000E1EB6
		public static void AddColor(FlatBufferBuilder builder, RandPropNumTable.eColor Color)
		{
			builder.AddInt(1, (int)Color, 0);
		}

		// Token: 0x06004777 RID: 18295 RVA: 0x000E3AC1 File Offset: 0x000E1EC1
		public static void AddValue(FlatBufferBuilder builder, VectorOffset ValueOffset)
		{
			builder.AddOffset(2, ValueOffset.Value, 0);
		}

		// Token: 0x06004778 RID: 18296 RVA: 0x000E3AD4 File Offset: 0x000E1ED4
		public static VectorOffset CreateValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06004779 RID: 18297 RVA: 0x000E3B11 File Offset: 0x000E1F11
		public static void StartValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600477A RID: 18298 RVA: 0x000E3B1C File Offset: 0x000E1F1C
		public static void AddWeight(FlatBufferBuilder builder, VectorOffset WeightOffset)
		{
			builder.AddOffset(3, WeightOffset.Value, 0);
		}

		// Token: 0x0600477B RID: 18299 RVA: 0x000E3B30 File Offset: 0x000E1F30
		public static VectorOffset CreateWeightVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x0600477C RID: 18300 RVA: 0x000E3B6D File Offset: 0x000E1F6D
		public static void StartWeightVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0600477D RID: 18301 RVA: 0x000E3B78 File Offset: 0x000E1F78
		public static Offset<RandPropNumTable> EndRandPropNumTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RandPropNumTable>(value);
		}

		// Token: 0x0600477E RID: 18302 RVA: 0x000E3B92 File Offset: 0x000E1F92
		public static void FinishRandPropNumTableBuffer(FlatBufferBuilder builder, Offset<RandPropNumTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A42 RID: 6722
		private Table __p = new Table();

		// Token: 0x04001A43 RID: 6723
		private FlatBufferArray<int> ValueValue;

		// Token: 0x04001A44 RID: 6724
		private FlatBufferArray<int> WeightValue;

		// Token: 0x0200056A RID: 1386
		public enum eColor
		{
			// Token: 0x04001A46 RID: 6726
			Color_None,
			// Token: 0x04001A47 RID: 6727
			WHITE,
			// Token: 0x04001A48 RID: 6728
			BLUE,
			// Token: 0x04001A49 RID: 6729
			PURPLE,
			// Token: 0x04001A4A RID: 6730
			GREEN,
			// Token: 0x04001A4B RID: 6731
			PINK,
			// Token: 0x04001A4C RID: 6732
			YELLOW
		}

		// Token: 0x0200056B RID: 1387
		public enum eCrypt
		{
			// Token: 0x04001A4E RID: 6734
			code = 339145848
		}
	}
}
