using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000430 RID: 1072
	public class FashionComposeSkyTable : IFlatbufferObject
	{
		// Token: 0x17000C74 RID: 3188
		// (get) Token: 0x06003300 RID: 13056 RVA: 0x000B385C File Offset: 0x000B1C5C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003301 RID: 13057 RVA: 0x000B3869 File Offset: 0x000B1C69
		public static FashionComposeSkyTable GetRootAsFashionComposeSkyTable(ByteBuffer _bb)
		{
			return FashionComposeSkyTable.GetRootAsFashionComposeSkyTable(_bb, new FashionComposeSkyTable());
		}

		// Token: 0x06003302 RID: 13058 RVA: 0x000B3876 File Offset: 0x000B1C76
		public static FashionComposeSkyTable GetRootAsFashionComposeSkyTable(ByteBuffer _bb, FashionComposeSkyTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003303 RID: 13059 RVA: 0x000B3892 File Offset: 0x000B1C92
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003304 RID: 13060 RVA: 0x000B38AC File Offset: 0x000B1CAC
		public FashionComposeSkyTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000C75 RID: 3189
		// (get) Token: 0x06003305 RID: 13061 RVA: 0x000B38B8 File Offset: 0x000B1CB8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C76 RID: 3190
		// (get) Token: 0x06003306 RID: 13062 RVA: 0x000B3904 File Offset: 0x000B1D04
		public int Index
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C77 RID: 3191
		// (get) Token: 0x06003307 RID: 13063 RVA: 0x000B3950 File Offset: 0x000B1D50
		public int SuitID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C78 RID: 3192
		// (get) Token: 0x06003308 RID: 13064 RVA: 0x000B399C File Offset: 0x000B1D9C
		public int Occu
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C79 RID: 3193
		// (get) Token: 0x06003309 RID: 13065 RVA: 0x000B39E8 File Offset: 0x000B1DE8
		public int Part
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C7A RID: 3194
		// (get) Token: 0x0600330A RID: 13066 RVA: 0x000B3A34 File Offset: 0x000B1E34
		public int Type
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C7B RID: 3195
		// (get) Token: 0x0600330B RID: 13067 RVA: 0x000B3A80 File Offset: 0x000B1E80
		public int BaseWeight
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x0600330C RID: 13068 RVA: 0x000B3ACC File Offset: 0x000B1ECC
		public int FixRandRangeArray(int j)
		{
			int num = this.__p.__offset(18);
			return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000C7C RID: 3196
		// (get) Token: 0x0600330D RID: 13069 RVA: 0x000B3B1C File Offset: 0x000B1F1C
		public int FixRandRangeLength
		{
			get
			{
				int num = this.__p.__offset(18);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x0600330E RID: 13070 RVA: 0x000B3B4F File Offset: 0x000B1F4F
		public ArraySegment<byte>? GetFixRandRangeBytes()
		{
			return this.__p.__vector_as_arraysegment(18);
		}

		// Token: 0x17000C7D RID: 3197
		// (get) Token: 0x0600330F RID: 13071 RVA: 0x000B3B5E File Offset: 0x000B1F5E
		public FlatBufferArray<int> FixRandRange
		{
			get
			{
				if (this.FixRandRangeValue == null)
				{
					this.FixRandRangeValue = new FlatBufferArray<int>(new Func<int, int>(this.FixRandRangeArray), this.FixRandRangeLength);
				}
				return this.FixRandRangeValue;
			}
		}

		// Token: 0x17000C7E RID: 3198
		// (get) Token: 0x06003310 RID: 13072 RVA: 0x000B3B90 File Offset: 0x000B1F90
		public int HitMin
		{
			get
			{
				int num = this.__p.__offset(20);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C7F RID: 3199
		// (get) Token: 0x06003311 RID: 13073 RVA: 0x000B3BDC File Offset: 0x000B1FDC
		public int MaxWeight
		{
			get
			{
				int num = this.__p.__offset(22);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C80 RID: 3200
		// (get) Token: 0x06003312 RID: 13074 RVA: 0x000B3C28 File Offset: 0x000B2028
		public int HitWeight
		{
			get
			{
				int num = this.__p.__offset(24);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C81 RID: 3201
		// (get) Token: 0x06003313 RID: 13075 RVA: 0x000B3C74 File Offset: 0x000B2074
		public int IsShow
		{
			get
			{
				int num = this.__p.__offset(26);
				return (num == 0) ? 0 : (-1437044493 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000C82 RID: 3202
		// (get) Token: 0x06003314 RID: 13076 RVA: 0x000B3CC0 File Offset: 0x000B20C0
		public string SuitName
		{
			get
			{
				int num = this.__p.__offset(28);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003315 RID: 13077 RVA: 0x000B3D03 File Offset: 0x000B2103
		public ArraySegment<byte>? GetSuitNameBytes()
		{
			return this.__p.__vector_as_arraysegment(28);
		}

		// Token: 0x06003316 RID: 13078 RVA: 0x000B3D14 File Offset: 0x000B2114
		public static Offset<FashionComposeSkyTable> CreateFashionComposeSkyTable(FlatBufferBuilder builder, int ID = 0, int Index = 0, int SuitID = 0, int Occu = 0, int Part = 0, int Type = 0, int BaseWeight = 0, VectorOffset FixRandRangeOffset = default(VectorOffset), int HitMin = 0, int MaxWeight = 0, int HitWeight = 0, int IsShow = 0, StringOffset SuitNameOffset = default(StringOffset))
		{
			builder.StartObject(13);
			FashionComposeSkyTable.AddSuitName(builder, SuitNameOffset);
			FashionComposeSkyTable.AddIsShow(builder, IsShow);
			FashionComposeSkyTable.AddHitWeight(builder, HitWeight);
			FashionComposeSkyTable.AddMaxWeight(builder, MaxWeight);
			FashionComposeSkyTable.AddHitMin(builder, HitMin);
			FashionComposeSkyTable.AddFixRandRange(builder, FixRandRangeOffset);
			FashionComposeSkyTable.AddBaseWeight(builder, BaseWeight);
			FashionComposeSkyTable.AddType(builder, Type);
			FashionComposeSkyTable.AddPart(builder, Part);
			FashionComposeSkyTable.AddOccu(builder, Occu);
			FashionComposeSkyTable.AddSuitID(builder, SuitID);
			FashionComposeSkyTable.AddIndex(builder, Index);
			FashionComposeSkyTable.AddID(builder, ID);
			return FashionComposeSkyTable.EndFashionComposeSkyTable(builder);
		}

		// Token: 0x06003317 RID: 13079 RVA: 0x000B3D94 File Offset: 0x000B2194
		public static void StartFashionComposeSkyTable(FlatBufferBuilder builder)
		{
			builder.StartObject(13);
		}

		// Token: 0x06003318 RID: 13080 RVA: 0x000B3D9E File Offset: 0x000B219E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003319 RID: 13081 RVA: 0x000B3DA9 File Offset: 0x000B21A9
		public static void AddIndex(FlatBufferBuilder builder, int Index)
		{
			builder.AddInt(1, Index, 0);
		}

		// Token: 0x0600331A RID: 13082 RVA: 0x000B3DB4 File Offset: 0x000B21B4
		public static void AddSuitID(FlatBufferBuilder builder, int SuitID)
		{
			builder.AddInt(2, SuitID, 0);
		}

		// Token: 0x0600331B RID: 13083 RVA: 0x000B3DBF File Offset: 0x000B21BF
		public static void AddOccu(FlatBufferBuilder builder, int Occu)
		{
			builder.AddInt(3, Occu, 0);
		}

		// Token: 0x0600331C RID: 13084 RVA: 0x000B3DCA File Offset: 0x000B21CA
		public static void AddPart(FlatBufferBuilder builder, int Part)
		{
			builder.AddInt(4, Part, 0);
		}

		// Token: 0x0600331D RID: 13085 RVA: 0x000B3DD5 File Offset: 0x000B21D5
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(5, Type, 0);
		}

		// Token: 0x0600331E RID: 13086 RVA: 0x000B3DE0 File Offset: 0x000B21E0
		public static void AddBaseWeight(FlatBufferBuilder builder, int BaseWeight)
		{
			builder.AddInt(6, BaseWeight, 0);
		}

		// Token: 0x0600331F RID: 13087 RVA: 0x000B3DEB File Offset: 0x000B21EB
		public static void AddFixRandRange(FlatBufferBuilder builder, VectorOffset FixRandRangeOffset)
		{
			builder.AddOffset(7, FixRandRangeOffset.Value, 0);
		}

		// Token: 0x06003320 RID: 13088 RVA: 0x000B3DFC File Offset: 0x000B21FC
		public static VectorOffset CreateFixRandRangeVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06003321 RID: 13089 RVA: 0x000B3E39 File Offset: 0x000B2239
		public static void StartFixRandRangeVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06003322 RID: 13090 RVA: 0x000B3E44 File Offset: 0x000B2244
		public static void AddHitMin(FlatBufferBuilder builder, int HitMin)
		{
			builder.AddInt(8, HitMin, 0);
		}

		// Token: 0x06003323 RID: 13091 RVA: 0x000B3E4F File Offset: 0x000B224F
		public static void AddMaxWeight(FlatBufferBuilder builder, int MaxWeight)
		{
			builder.AddInt(9, MaxWeight, 0);
		}

		// Token: 0x06003324 RID: 13092 RVA: 0x000B3E5B File Offset: 0x000B225B
		public static void AddHitWeight(FlatBufferBuilder builder, int HitWeight)
		{
			builder.AddInt(10, HitWeight, 0);
		}

		// Token: 0x06003325 RID: 13093 RVA: 0x000B3E67 File Offset: 0x000B2267
		public static void AddIsShow(FlatBufferBuilder builder, int IsShow)
		{
			builder.AddInt(11, IsShow, 0);
		}

		// Token: 0x06003326 RID: 13094 RVA: 0x000B3E73 File Offset: 0x000B2273
		public static void AddSuitName(FlatBufferBuilder builder, StringOffset SuitNameOffset)
		{
			builder.AddOffset(12, SuitNameOffset.Value, 0);
		}

		// Token: 0x06003327 RID: 13095 RVA: 0x000B3E88 File Offset: 0x000B2288
		public static Offset<FashionComposeSkyTable> EndFashionComposeSkyTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FashionComposeSkyTable>(value);
		}

		// Token: 0x06003328 RID: 13096 RVA: 0x000B3EA2 File Offset: 0x000B22A2
		public static void FinishFashionComposeSkyTableBuffer(FlatBufferBuilder builder, Offset<FashionComposeSkyTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040014DF RID: 5343
		private Table __p = new Table();

		// Token: 0x040014E0 RID: 5344
		private FlatBufferArray<int> FixRandRangeValue;

		// Token: 0x02000431 RID: 1073
		public enum eCrypt
		{
			// Token: 0x040014E2 RID: 5346
			code = -1437044493
		}
	}
}
