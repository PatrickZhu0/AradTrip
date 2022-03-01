using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B11 RID: 19217
	public sealed class DDestructibleInfo : Table
	{
		// Token: 0x0601BFA3 RID: 114595 RVA: 0x0088DF06 File Offset: 0x0088C306
		public static DDestructibleInfo GetRootAsDDestructibleInfo(ByteBuffer _bb)
		{
			return DDestructibleInfo.GetRootAsDDestructibleInfo(_bb, new DDestructibleInfo());
		}

		// Token: 0x0601BFA4 RID: 114596 RVA: 0x0088DF13 File Offset: 0x0088C313
		public static DDestructibleInfo GetRootAsDDestructibleInfo(ByteBuffer _bb, DDestructibleInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BFA5 RID: 114597 RVA: 0x0088DF2F File Offset: 0x0088C32F
		public DDestructibleInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700262F RID: 9775
		// (get) Token: 0x0601BFA6 RID: 114598 RVA: 0x0088DF40 File Offset: 0x0088C340
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BFA7 RID: 114599 RVA: 0x0088DF50 File Offset: 0x0088C350
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17002630 RID: 9776
		// (get) Token: 0x0601BFA8 RID: 114600 RVA: 0x0088DF8B File Offset: 0x0088C38B
		public Quaternion Rotation
		{
			get
			{
				return this.GetRotation(new Quaternion());
			}
		}

		// Token: 0x0601BFA9 RID: 114601 RVA: 0x0088DF98 File Offset: 0x0088C398
		public Quaternion GetRotation(Quaternion obj)
		{
			int num = base.__offset(6);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002631 RID: 9777
		// (get) Token: 0x0601BFAA RID: 114602 RVA: 0x0088DFD0 File Offset: 0x0088C3D0
		public int Level
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002632 RID: 9778
		// (get) Token: 0x0601BFAB RID: 114603 RVA: 0x0088E004 File Offset: 0x0088C404
		public int FlushGroupID
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601BFAC RID: 114604 RVA: 0x0088E039 File Offset: 0x0088C439
		public static void StartDDestructibleInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x0601BFAD RID: 114605 RVA: 0x0088E042 File Offset: 0x0088C442
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BFAE RID: 114606 RVA: 0x0088E053 File Offset: 0x0088C453
		public static void AddRotation(FlatBufferBuilder builder, Offset<Quaternion> rotationOffset)
		{
			builder.AddStruct(1, rotationOffset.Value, 0);
		}

		// Token: 0x0601BFAF RID: 114607 RVA: 0x0088E064 File Offset: 0x0088C464
		public static void AddLevel(FlatBufferBuilder builder, int level)
		{
			builder.AddInt(2, level, 0);
		}

		// Token: 0x0601BFB0 RID: 114608 RVA: 0x0088E06F File Offset: 0x0088C46F
		public static void AddFlushGroupID(FlatBufferBuilder builder, int flushGroupID)
		{
			builder.AddInt(3, flushGroupID, 0);
		}

		// Token: 0x0601BFB1 RID: 114609 RVA: 0x0088E07C File Offset: 0x0088C47C
		public static Offset<DDestructibleInfo> EndDDestructibleInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DDestructibleInfo>(value);
		}
	}
}
