using System;
using FlatBuffers;

namespace FBSkillData
{
	// Token: 0x02004B3F RID: 19263
	public sealed class FBSkillDataCollection : Table
	{
		// Token: 0x0601C4A9 RID: 115881 RVA: 0x008989BE File Offset: 0x00896DBE
		public static FBSkillDataCollection GetRootAsFBSkillDataCollection(ByteBuffer _bb)
		{
			return FBSkillDataCollection.GetRootAsFBSkillDataCollection(_bb, new FBSkillDataCollection());
		}

		// Token: 0x0601C4AA RID: 115882 RVA: 0x008989CB File Offset: 0x00896DCB
		public static FBSkillDataCollection GetRootAsFBSkillDataCollection(ByteBuffer _bb, FBSkillDataCollection obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601C4AB RID: 115883 RVA: 0x008989E7 File Offset: 0x00896DE7
		public static bool FBSkillDataCollectionBufferHasIdentifier(ByteBuffer _bb)
		{
			return Table.__has_identifier(_bb, "SKIL");
		}

		// Token: 0x0601C4AC RID: 115884 RVA: 0x008989F4 File Offset: 0x00896DF4
		public FBSkillDataCollection __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x0601C4AD RID: 115885 RVA: 0x00898A05 File Offset: 0x00896E05
		public FBSkillDataTable GetCollection(int j)
		{
			return this.GetCollection(new FBSkillDataTable(), j);
		}

		// Token: 0x0601C4AE RID: 115886 RVA: 0x00898A14 File Offset: 0x00896E14
		public FBSkillDataTable GetCollection(FBSkillDataTable obj, int j)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(base.__vector(num) + j * 4), this.bb);
		}

		// Token: 0x170027CA RID: 10186
		// (get) Token: 0x0601C4AF RID: 115887 RVA: 0x00898A54 File Offset: 0x00896E54
		public int CollectionLength
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? 0 : base.__vector_len(num);
			}
		}

		// Token: 0x0601C4B0 RID: 115888 RVA: 0x00898A7C File Offset: 0x00896E7C
		public static Offset<FBSkillDataCollection> CreateFBSkillDataCollection(FlatBufferBuilder builder, VectorOffset collection = default(VectorOffset))
		{
			builder.StartObject(1);
			FBSkillDataCollection.AddCollection(builder, collection);
			return FBSkillDataCollection.EndFBSkillDataCollection(builder);
		}

		// Token: 0x0601C4B1 RID: 115889 RVA: 0x00898A92 File Offset: 0x00896E92
		public static void StartFBSkillDataCollection(FlatBufferBuilder builder)
		{
			builder.StartObject(1);
		}

		// Token: 0x0601C4B2 RID: 115890 RVA: 0x00898A9B File Offset: 0x00896E9B
		public static void AddCollection(FlatBufferBuilder builder, VectorOffset collectionOffset)
		{
			builder.AddOffset(0, collectionOffset.Value, 0);
		}

		// Token: 0x0601C4B3 RID: 115891 RVA: 0x00898AAC File Offset: 0x00896EAC
		public static VectorOffset CreateCollectionVector(FlatBufferBuilder builder, Offset<FBSkillDataTable>[] data)
		{
			builder.StartVector(4, data.Length, 4);
			for (int i = data.Length - 1; i >= 0; i--)
			{
				builder.AddOffset(data[i].Value);
			}
			return builder.EndVector();
		}

		// Token: 0x0601C4B4 RID: 115892 RVA: 0x00898AF2 File Offset: 0x00896EF2
		public static void StartCollectionVector(FlatBufferBuilder builder, int numElems)
		{
			builder.StartVector(4, numElems, 4);
		}

		// Token: 0x0601C4B5 RID: 115893 RVA: 0x00898B00 File Offset: 0x00896F00
		public static Offset<FBSkillDataCollection> EndFBSkillDataCollection(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<FBSkillDataCollection>(value);
		}

		// Token: 0x0601C4B6 RID: 115894 RVA: 0x00898B1A File Offset: 0x00896F1A
		public static void FinishFBSkillDataCollectionBuffer(FlatBufferBuilder builder, Offset<FBSkillDataCollection> offset)
		{
			builder.Finish(offset.Value, "SKIL");
		}
	}
}
