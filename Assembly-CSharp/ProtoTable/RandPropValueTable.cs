using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200056F RID: 1391
	public class RandPropValueTable : IFlatbufferObject
	{
		// Token: 0x17001346 RID: 4934
		// (get) Token: 0x06004790 RID: 18320 RVA: 0x000E3D74 File Offset: 0x000E2174
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06004791 RID: 18321 RVA: 0x000E3D81 File Offset: 0x000E2181
		public static RandPropValueTable GetRootAsRandPropValueTable(ByteBuffer _bb)
		{
			return RandPropValueTable.GetRootAsRandPropValueTable(_bb, new RandPropValueTable());
		}

		// Token: 0x06004792 RID: 18322 RVA: 0x000E3D8E File Offset: 0x000E218E
		public static RandPropValueTable GetRootAsRandPropValueTable(ByteBuffer _bb, RandPropValueTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06004793 RID: 18323 RVA: 0x000E3DAA File Offset: 0x000E21AA
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06004794 RID: 18324 RVA: 0x000E3DC4 File Offset: 0x000E21C4
		public RandPropValueTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17001347 RID: 4935
		// (get) Token: 0x06004795 RID: 18325 RVA: 0x000E3DD0 File Offset: 0x000E21D0
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-727159751 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001348 RID: 4936
		// (get) Token: 0x06004796 RID: 18326 RVA: 0x000E3E1C File Offset: 0x000E221C
		public RandPropValueTable.eRandType RandType
		{
			get
			{
				int num = this.__p.__offset(6);
				return (RandPropValueTable.eRandType)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17001349 RID: 4937
		// (get) Token: 0x06004797 RID: 18327 RVA: 0x000E3E60 File Offset: 0x000E2260
		public RandPropValueTable.eColor Color
		{
			get
			{
				int num = this.__p.__offset(8);
				return (RandPropValueTable.eColor)((num == 0) ? 0 : this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700134A RID: 4938
		// (get) Token: 0x06004798 RID: 18328 RVA: 0x000E3EA4 File Offset: 0x000E22A4
		public int LevelMin
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-727159751 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700134B RID: 4939
		// (get) Token: 0x06004799 RID: 18329 RVA: 0x000E3EF0 File Offset: 0x000E22F0
		public int LevelMax
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-727159751 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600479A RID: 18330 RVA: 0x000E3F3C File Offset: 0x000E233C
		public int ValueArray(int j)
		{
			int num = this.__p.__offset(14);
			return (num == 0) ? 0 : (-727159751 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700134C RID: 4940
		// (get) Token: 0x0600479B RID: 18331 RVA: 0x000E3F8C File Offset: 0x000E238C
		public int ValueLength
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600479C RID: 18332 RVA: 0x000E3FBF File Offset: 0x000E23BF
		public ArraySegment<byte>? GetValueBytes()
		{
			return this.__p.__vector_as_arraysegment(14);
		}

		// Token: 0x1700134D RID: 4941
		// (get) Token: 0x0600479D RID: 18333 RVA: 0x000E3FCE File Offset: 0x000E23CE
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

		// Token: 0x0600479E RID: 18334 RVA: 0x000E4000 File Offset: 0x000E2400
		public int WeightArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-727159751 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x1700134E RID: 4942
		// (get) Token: 0x0600479F RID: 18335 RVA: 0x000E4050 File Offset: 0x000E2450
		public int WeightLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x060047A0 RID: 18336 RVA: 0x000E4083 File Offset: 0x000E2483
		public ArraySegment<byte>? GetWeightBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x1700134F RID: 4943
		// (get) Token: 0x060047A1 RID: 18337 RVA: 0x000E4092 File Offset: 0x000E2492
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

		// Token: 0x060047A2 RID: 18338 RVA: 0x000E40C4 File Offset: 0x000E24C4
		public static Offset<RandPropValueTable> CreateRandPropValueTable(FlatBufferBuilder builder, int ID = 0, RandPropValueTable.eRandType RandType = RandPropValueTable.eRandType.RandType_None, RandPropValueTable.eColor Color = RandPropValueTable.eColor.Color_None, int LevelMin = 0, int LevelMax = 0, VectorOffset ValueOffset = default(VectorOffset), VectorOffset WeightOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			RandPropValueTable.AddWeight(builder, WeightOffset);
			RandPropValueTable.AddValue(builder, ValueOffset);
			RandPropValueTable.AddLevelMax(builder, LevelMax);
			RandPropValueTable.AddLevelMin(builder, LevelMin);
			RandPropValueTable.AddColor(builder, Color);
			RandPropValueTable.AddRandType(builder, RandType);
			RandPropValueTable.AddID(builder, ID);
			return RandPropValueTable.EndRandPropValueTable(builder);
		}

		// Token: 0x060047A3 RID: 18339 RVA: 0x000E4113 File Offset: 0x000E2513
		public static void StartRandPropValueTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x060047A4 RID: 18340 RVA: 0x000E411C File Offset: 0x000E251C
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060047A5 RID: 18341 RVA: 0x000E4127 File Offset: 0x000E2527
		public static void AddRandType(FlatBufferBuilder builder, RandPropValueTable.eRandType RandType)
		{
			builder.AddInt(1, (int)RandType, 0);
		}

		// Token: 0x060047A6 RID: 18342 RVA: 0x000E4132 File Offset: 0x000E2532
		public static void AddColor(FlatBufferBuilder builder, RandPropValueTable.eColor Color)
		{
			builder.AddInt(2, (int)Color, 0);
		}

		// Token: 0x060047A7 RID: 18343 RVA: 0x000E413D File Offset: 0x000E253D
		public static void AddLevelMin(FlatBufferBuilder builder, int LevelMin)
		{
			builder.AddInt(3, LevelMin, 0);
		}

		// Token: 0x060047A8 RID: 18344 RVA: 0x000E4148 File Offset: 0x000E2548
		public static void AddLevelMax(FlatBufferBuilder builder, int LevelMax)
		{
			builder.AddInt(4, LevelMax, 0);
		}

		// Token: 0x060047A9 RID: 18345 RVA: 0x000E4153 File Offset: 0x000E2553
		public static void AddValue(FlatBufferBuilder builder, VectorOffset ValueOffset)
		{
			builder.AddOffset(5, ValueOffset.Value, 0);
		}

		// Token: 0x060047AA RID: 18346 RVA: 0x000E4164 File Offset: 0x000E2564
		public static VectorOffset CreateValueVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060047AB RID: 18347 RVA: 0x000E41A1 File Offset: 0x000E25A1
		public static void StartValueVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060047AC RID: 18348 RVA: 0x000E41AC File Offset: 0x000E25AC
		public static void AddWeight(FlatBufferBuilder builder, VectorOffset WeightOffset)
		{
			builder.AddOffset(6, WeightOffset.Value, 0);
		}

		// Token: 0x060047AD RID: 18349 RVA: 0x000E41C0 File Offset: 0x000E25C0
		public static VectorOffset CreateWeightVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x060047AE RID: 18350 RVA: 0x000E41FD File Offset: 0x000E25FD
		public static void StartWeightVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x060047AF RID: 18351 RVA: 0x000E4208 File Offset: 0x000E2608
		public static Offset<RandPropValueTable> EndRandPropValueTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<RandPropValueTable>(value);
		}

		// Token: 0x060047B0 RID: 18352 RVA: 0x000E4222 File Offset: 0x000E2622
		public static void FinishRandPropValueTableBuffer(FlatBufferBuilder builder, Offset<RandPropValueTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001A65 RID: 6757
		private Table __p = new Table();

		// Token: 0x04001A66 RID: 6758
		private FlatBufferArray<int> ValueValue;

		// Token: 0x04001A67 RID: 6759
		private FlatBufferArray<int> WeightValue;

		// Token: 0x02000570 RID: 1392
		public enum eRandType
		{
			// Token: 0x04001A69 RID: 6761
			RandType_None,
			// Token: 0x04001A6A RID: 6762
			STR,
			// Token: 0x04001A6B RID: 6763
			STA,
			// Token: 0x04001A6C RID: 6764
			INT,
			// Token: 0x04001A6D RID: 6765
			SPR,
			// Token: 0x04001A6E RID: 6766
			HPMAX,
			// Token: 0x04001A6F RID: 6767
			MPMAX,
			// Token: 0x04001A70 RID: 6768
			HPREC,
			// Token: 0x04001A71 RID: 6769
			MPREC,
			// Token: 0x04001A72 RID: 6770
			HIT,
			// Token: 0x04001A73 RID: 6771
			DEX,
			// Token: 0x04001A74 RID: 6772
			PHYCRT,
			// Token: 0x04001A75 RID: 6773
			MGCCRT,
			// Token: 0x04001A76 RID: 6774
			ATKSPD,
			// Token: 0x04001A77 RID: 6775
			RDYSPD,
			// Token: 0x04001A78 RID: 6776
			MOVSPD,
			// Token: 0x04001A79 RID: 6777
			JUMP,
			// Token: 0x04001A7A RID: 6778
			HITREC
		}

		// Token: 0x02000571 RID: 1393
		public enum eColor
		{
			// Token: 0x04001A7C RID: 6780
			Color_None,
			// Token: 0x04001A7D RID: 6781
			WHITE,
			// Token: 0x04001A7E RID: 6782
			BLUE,
			// Token: 0x04001A7F RID: 6783
			PURPLE,
			// Token: 0x04001A80 RID: 6784
			GREEN,
			// Token: 0x04001A81 RID: 6785
			PINK,
			// Token: 0x04001A82 RID: 6786
			YELLOW
		}

		// Token: 0x02000572 RID: 1394
		public enum eCrypt
		{
			// Token: 0x04001A84 RID: 6788
			code = -727159751
		}
	}
}
