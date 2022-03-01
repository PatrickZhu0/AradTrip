using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B0D RID: 19213
	public sealed class DNPCInfo : Table
	{
		// Token: 0x0601BF5A RID: 114522 RVA: 0x0088D756 File Offset: 0x0088BB56
		public static DNPCInfo GetRootAsDNPCInfo(ByteBuffer _bb)
		{
			return DNPCInfo.GetRootAsDNPCInfo(_bb, new DNPCInfo());
		}

		// Token: 0x0601BF5B RID: 114523 RVA: 0x0088D763 File Offset: 0x0088BB63
		public static DNPCInfo GetRootAsDNPCInfo(ByteBuffer _bb, DNPCInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF5C RID: 114524 RVA: 0x0088D77F File Offset: 0x0088BB7F
		public DNPCInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700261D RID: 9757
		// (get) Token: 0x0601BF5D RID: 114525 RVA: 0x0088D790 File Offset: 0x0088BB90
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BF5E RID: 114526 RVA: 0x0088D7A0 File Offset: 0x0088BBA0
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x1700261E RID: 9758
		// (get) Token: 0x0601BF5F RID: 114527 RVA: 0x0088D7DB File Offset: 0x0088BBDB
		public Quaternion Rotation
		{
			get
			{
				return this.GetRotation(new Quaternion());
			}
		}

		// Token: 0x0601BF60 RID: 114528 RVA: 0x0088D7E8 File Offset: 0x0088BBE8
		public Quaternion GetRotation(Quaternion obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700261F RID: 9759
		// (get) Token: 0x0601BF61 RID: 114529 RVA: 0x0088D81D File Offset: 0x0088BC1D
		public Vector2 MinFindRange
		{
			get
			{
				return this.GetMinFindRange(new Vector2());
			}
		}

		// Token: 0x0601BF62 RID: 114530 RVA: 0x0088D82C File Offset: 0x0088BC2C
		public Vector2 GetMinFindRange(Vector2 obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002620 RID: 9760
		// (get) Token: 0x0601BF63 RID: 114531 RVA: 0x0088D861 File Offset: 0x0088BC61
		public Vector2 MaxFindRange
		{
			get
			{
				return this.GetMaxFindRange(new Vector2());
			}
		}

		// Token: 0x0601BF64 RID: 114532 RVA: 0x0088D870 File Offset: 0x0088BC70
		public Vector2 GetMaxFindRange(Vector2 obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601BF65 RID: 114533 RVA: 0x0088D8A6 File Offset: 0x0088BCA6
		public static void StartDNPCInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601BF66 RID: 114534 RVA: 0x0088D8AF File Offset: 0x0088BCAF
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BF67 RID: 114535 RVA: 0x0088D8C0 File Offset: 0x0088BCC0
		public static void AddRotation(FlatBufferBuilder builder, Offset<Quaternion> rotationOffset)
		{
			builder.AddStruct(1, rotationOffset.Value, 0);
		}

		// Token: 0x0601BF68 RID: 114536 RVA: 0x0088D8D1 File Offset: 0x0088BCD1
		public static void AddMinFindRange(FlatBufferBuilder builder, Offset<Vector2> minFindRangeOffset)
		{
			builder.AddStruct(2, minFindRangeOffset.Value, 0);
		}

		// Token: 0x0601BF69 RID: 114537 RVA: 0x0088D8E2 File Offset: 0x0088BCE2
		public static void AddMaxFindRange(FlatBufferBuilder builder, Offset<Vector2> maxFindRangeOffset)
		{
			builder.AddStruct(3, maxFindRangeOffset.Value, 0);
		}

		// Token: 0x0601BF6A RID: 114538 RVA: 0x0088D8F4 File Offset: 0x0088BCF4
		public static Offset<DNPCInfo> EndDNPCInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DNPCInfo>(value);
		}
	}
}
