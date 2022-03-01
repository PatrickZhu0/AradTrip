using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003DF RID: 991
	public class EquipForgeTable : IFlatbufferObject
	{
		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x06002D2E RID: 11566 RVA: 0x000A5E98 File Offset: 0x000A4298
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002D2F RID: 11567 RVA: 0x000A5EA5 File Offset: 0x000A42A5
		public static EquipForgeTable GetRootAsEquipForgeTable(ByteBuffer _bb)
		{
			return EquipForgeTable.GetRootAsEquipForgeTable(_bb, new EquipForgeTable());
		}

		// Token: 0x06002D30 RID: 11568 RVA: 0x000A5EB2 File Offset: 0x000A42B2
		public static EquipForgeTable GetRootAsEquipForgeTable(ByteBuffer _bb, EquipForgeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002D31 RID: 11569 RVA: 0x000A5ECE File Offset: 0x000A42CE
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002D32 RID: 11570 RVA: 0x000A5EE8 File Offset: 0x000A42E8
		public EquipForgeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x06002D33 RID: 11571 RVA: 0x000A5EF4 File Offset: 0x000A42F4
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-27132729 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002D34 RID: 11572 RVA: 0x000A5F40 File Offset: 0x000A4340
		public string MaterialArray(int j)
		{
			int num = this.__p.__offset(6);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x06002D35 RID: 11573 RVA: 0x000A5F88 File Offset: 0x000A4388
		public int MaterialLength
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x06002D36 RID: 11574 RVA: 0x000A5FBA File Offset: 0x000A43BA
		public FlatBufferArray<string> Material
		{
			get
			{
				if (this.MaterialValue == null)
				{
					this.MaterialValue = new FlatBufferArray<string>(new Func<int, string>(this.MaterialArray), this.MaterialLength);
				}
				return this.MaterialValue;
			}
		}

		// Token: 0x06002D37 RID: 11575 RVA: 0x000A5FEC File Offset: 0x000A43EC
		public string PriceArray(int j)
		{
			int num = this.__p.__offset(8);
			return (num == 0) ? string.Empty : this.__p.__string(this.__p.__vector(num) + j * 4);
		}

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x06002D38 RID: 11576 RVA: 0x000A6034 File Offset: 0x000A4434
		public int PriceLength
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x06002D39 RID: 11577 RVA: 0x000A6066 File Offset: 0x000A4466
		public FlatBufferArray<string> Price
		{
			get
			{
				if (this.PriceValue == null)
				{
					this.PriceValue = new FlatBufferArray<string>(new Func<int, string>(this.PriceArray), this.PriceLength);
				}
				return this.PriceValue;
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x06002D3A RID: 11578 RVA: 0x000A6098 File Offset: 0x000A4498
		public string MainTypeName
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002D3B RID: 11579 RVA: 0x000A60DB File Offset: 0x000A44DB
		public ArraySegment<byte>? GetMainTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06002D3C RID: 11580 RVA: 0x000A60EC File Offset: 0x000A44EC
		public string SubTypeName
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002D3D RID: 11581 RVA: 0x000A612F File Offset: 0x000A452F
		public ArraySegment<byte>? GetSubTypeNameBytes()
		{
			return this.__p.__vector_as_arraysegment(12);
		}

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06002D3E RID: 11582 RVA: 0x000A6140 File Offset: 0x000A4540
		public int RecommendLevel
		{
			get
			{
				int num = this.__p.__offset(14);
				return (num == 0) ? 0 : (-27132729 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002D3F RID: 11583 RVA: 0x000A618C File Offset: 0x000A458C
		public int RecommendJobsArray(int j)
		{
			int num = this.__p.__offset(16);
			return (num == 0) ? 0 : (-27132729 ^ this.__p.bb.GetInt(this.__p.__vector(num) + j * 4));
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06002D40 RID: 11584 RVA: 0x000A61DC File Offset: 0x000A45DC
		public int RecommendJobsLength
		{
			get
			{
				int num = this.__p.__offset(16);
				return (num == 0) ? 0 : this.__p.__vector_len(num);
			}
		}

		// Token: 0x06002D41 RID: 11585 RVA: 0x000A620F File Offset: 0x000A460F
		public ArraySegment<byte>? GetRecommendJobsBytes()
		{
			return this.__p.__vector_as_arraysegment(16);
		}

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06002D42 RID: 11586 RVA: 0x000A621E File Offset: 0x000A461E
		public FlatBufferArray<int> RecommendJobs
		{
			get
			{
				if (this.RecommendJobsValue == null)
				{
					this.RecommendJobsValue = new FlatBufferArray<int>(new Func<int, int>(this.RecommendJobsArray), this.RecommendJobsLength);
				}
				return this.RecommendJobsValue;
			}
		}

		// Token: 0x06002D43 RID: 11587 RVA: 0x000A6250 File Offset: 0x000A4650
		public static Offset<EquipForgeTable> CreateEquipForgeTable(FlatBufferBuilder builder, int ID = 0, VectorOffset MaterialOffset = default(VectorOffset), VectorOffset PriceOffset = default(VectorOffset), StringOffset MainTypeNameOffset = default(StringOffset), StringOffset SubTypeNameOffset = default(StringOffset), int RecommendLevel = 0, VectorOffset RecommendJobsOffset = default(VectorOffset))
		{
			builder.StartObject(7);
			EquipForgeTable.AddRecommendJobs(builder, RecommendJobsOffset);
			EquipForgeTable.AddRecommendLevel(builder, RecommendLevel);
			EquipForgeTable.AddSubTypeName(builder, SubTypeNameOffset);
			EquipForgeTable.AddMainTypeName(builder, MainTypeNameOffset);
			EquipForgeTable.AddPrice(builder, PriceOffset);
			EquipForgeTable.AddMaterial(builder, MaterialOffset);
			EquipForgeTable.AddID(builder, ID);
			return EquipForgeTable.EndEquipForgeTable(builder);
		}

		// Token: 0x06002D44 RID: 11588 RVA: 0x000A629F File Offset: 0x000A469F
		public static void StartEquipForgeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x06002D45 RID: 11589 RVA: 0x000A62A8 File Offset: 0x000A46A8
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002D46 RID: 11590 RVA: 0x000A62B3 File Offset: 0x000A46B3
		public static void AddMaterial(FlatBufferBuilder builder, VectorOffset MaterialOffset)
		{
			builder.AddOffset(1, MaterialOffset.Value, 0);
		}

		// Token: 0x06002D47 RID: 11591 RVA: 0x000A62C4 File Offset: 0x000A46C4
		public static VectorOffset CreateMaterialVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D48 RID: 11592 RVA: 0x000A630A File Offset: 0x000A470A
		public static void StartMaterialVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D49 RID: 11593 RVA: 0x000A6315 File Offset: 0x000A4715
		public static void AddPrice(FlatBufferBuilder builder, VectorOffset PriceOffset)
		{
			builder.AddOffset(2, PriceOffset.Value, 0);
		}

		// Token: 0x06002D4A RID: 11594 RVA: 0x000A6328 File Offset: 0x000A4728
		public static VectorOffset CreatePriceVector(FlatBufferBuilder builder, StringOffset[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D4B RID: 11595 RVA: 0x000A636E File Offset: 0x000A476E
		public static void StartPriceVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D4C RID: 11596 RVA: 0x000A6379 File Offset: 0x000A4779
		public static void AddMainTypeName(FlatBufferBuilder builder, StringOffset MainTypeNameOffset)
		{
			builder.AddOffset(3, MainTypeNameOffset.Value, 0);
		}

		// Token: 0x06002D4D RID: 11597 RVA: 0x000A638A File Offset: 0x000A478A
		public static void AddSubTypeName(FlatBufferBuilder builder, StringOffset SubTypeNameOffset)
		{
			builder.AddOffset(4, SubTypeNameOffset.Value, 0);
		}

		// Token: 0x06002D4E RID: 11598 RVA: 0x000A639B File Offset: 0x000A479B
		public static void AddRecommendLevel(FlatBufferBuilder builder, int RecommendLevel)
		{
			builder.AddInt(5, RecommendLevel, 0);
		}

		// Token: 0x06002D4F RID: 11599 RVA: 0x000A63A6 File Offset: 0x000A47A6
		public static void AddRecommendJobs(FlatBufferBuilder builder, VectorOffset RecommendJobsOffset)
		{
			builder.AddOffset(6, RecommendJobsOffset.Value, 0);
		}

		// Token: 0x06002D50 RID: 11600 RVA: 0x000A63B8 File Offset: 0x000A47B8
		public static VectorOffset CreateRecommendJobsVector(FlatBufferBuilder builder, int[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddInt(data[i]);
			}
			return builder.EndVector();
		}

		// Token: 0x06002D51 RID: 11601 RVA: 0x000A63F5 File Offset: 0x000A47F5
		public static void StartRecommendJobsVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x06002D52 RID: 11602 RVA: 0x000A6400 File Offset: 0x000A4800
		public static Offset<EquipForgeTable> EndEquipForgeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipForgeTable>(value);
		}

		// Token: 0x06002D53 RID: 11603 RVA: 0x000A641A File Offset: 0x000A481A
		public static void FinishEquipForgeTableBuffer(FlatBufferBuilder builder, Offset<EquipForgeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001335 RID: 4917
		private Table __p = new Table();

		// Token: 0x04001336 RID: 4918
		private FlatBufferArray<string> MaterialValue;

		// Token: 0x04001337 RID: 4919
		private FlatBufferArray<string> PriceValue;

		// Token: 0x04001338 RID: 4920
		private FlatBufferArray<int> RecommendJobsValue;

		// Token: 0x020003E0 RID: 992
		public enum eCrypt
		{
			// Token: 0x0400133A RID: 4922
			code = -27132729
		}
	}
}
