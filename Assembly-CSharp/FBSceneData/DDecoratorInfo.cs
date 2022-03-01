using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B10 RID: 19216
	public sealed class DDecoratorInfo : Table
	{
		// Token: 0x0601BF94 RID: 114580 RVA: 0x0088DD9A File Offset: 0x0088C19A
		public static DDecoratorInfo GetRootAsDDecoratorInfo(ByteBuffer _bb)
		{
			return DDecoratorInfo.GetRootAsDDecoratorInfo(_bb, new DDecoratorInfo());
		}

		// Token: 0x0601BF95 RID: 114581 RVA: 0x0088DDA7 File Offset: 0x0088C1A7
		public static DDecoratorInfo GetRootAsDDecoratorInfo(ByteBuffer _bb, DDecoratorInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF96 RID: 114582 RVA: 0x0088DDC3 File Offset: 0x0088C1C3
		public DDecoratorInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700262C RID: 9772
		// (get) Token: 0x0601BF97 RID: 114583 RVA: 0x0088DDD4 File Offset: 0x0088C1D4
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BF98 RID: 114584 RVA: 0x0088DDE4 File Offset: 0x0088C1E4
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x1700262D RID: 9773
		// (get) Token: 0x0601BF99 RID: 114585 RVA: 0x0088DE1F File Offset: 0x0088C21F
		public Vector3 LocalScale
		{
			get
			{
				return this.GetLocalScale(new Vector3());
			}
		}

		// Token: 0x0601BF9A RID: 114586 RVA: 0x0088DE2C File Offset: 0x0088C22C
		public Vector3 GetLocalScale(Vector3 obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x1700262E RID: 9774
		// (get) Token: 0x0601BF9B RID: 114587 RVA: 0x0088DE61 File Offset: 0x0088C261
		public Quaternion Rotation
		{
			get
			{
				return this.GetRotation(new Quaternion());
			}
		}

		// Token: 0x0601BF9C RID: 114588 RVA: 0x0088DE70 File Offset: 0x0088C270
		public Quaternion GetRotation(Quaternion obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601BF9D RID: 114589 RVA: 0x0088DEA5 File Offset: 0x0088C2A5
		public static void StartDDecoratorInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x0601BF9E RID: 114590 RVA: 0x0088DEAE File Offset: 0x0088C2AE
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BF9F RID: 114591 RVA: 0x0088DEBF File Offset: 0x0088C2BF
		public static void AddLocalScale(FlatBufferBuilder builder, Offset<Vector3> localScaleOffset)
		{
			builder.AddStruct(1, localScaleOffset.Value, 0);
		}

		// Token: 0x0601BFA0 RID: 114592 RVA: 0x0088DED0 File Offset: 0x0088C2D0
		public static void AddRotation(FlatBufferBuilder builder, Offset<Quaternion> rotationOffset)
		{
			builder.AddStruct(2, rotationOffset.Value, 0);
		}

		// Token: 0x0601BFA1 RID: 114593 RVA: 0x0088DEE4 File Offset: 0x0088C2E4
		public static Offset<DDecoratorInfo> EndDDecoratorInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DDecoratorInfo>(value);
		}
	}
}
