using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B12 RID: 19218
	public sealed class DRegionInfo : Table
	{
		// Token: 0x0601BFB3 RID: 114611 RVA: 0x0088E09E File Offset: 0x0088C49E
		public static DRegionInfo GetRootAsDRegionInfo(ByteBuffer _bb)
		{
			return DRegionInfo.GetRootAsDRegionInfo(_bb, new DRegionInfo());
		}

		// Token: 0x0601BFB4 RID: 114612 RVA: 0x0088E0AB File Offset: 0x0088C4AB
		public static DRegionInfo GetRootAsDRegionInfo(ByteBuffer _bb, DRegionInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BFB5 RID: 114613 RVA: 0x0088E0C7 File Offset: 0x0088C4C7
		public DRegionInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002633 RID: 9779
		// (get) Token: 0x0601BFB6 RID: 114614 RVA: 0x0088E0D8 File Offset: 0x0088C4D8
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BFB7 RID: 114615 RVA: 0x0088E0E8 File Offset: 0x0088C4E8
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17002634 RID: 9780
		// (get) Token: 0x0601BFB8 RID: 114616 RVA: 0x0088E124 File Offset: 0x0088C524
		public RegionType Regiontype
		{
			get
			{
				int num = base.__offset(6);
				return (RegionType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x17002635 RID: 9781
		// (get) Token: 0x0601BFB9 RID: 114617 RVA: 0x0088E158 File Offset: 0x0088C558
		public Vector2 Rect
		{
			get
			{
				return this.GetRect(new Vector2());
			}
		}

		// Token: 0x0601BFBA RID: 114618 RVA: 0x0088E168 File Offset: 0x0088C568
		public Vector2 GetRect(Vector2 obj)
		{
			int num = base.__offset(8);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002636 RID: 9782
		// (get) Token: 0x0601BFBB RID: 114619 RVA: 0x0088E1A0 File Offset: 0x0088C5A0
		public float Radius
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 1f : this.bb.GetFloat(num + this.bb_pos);
			}
		}

		// Token: 0x17002637 RID: 9783
		// (get) Token: 0x0601BFBC RID: 114620 RVA: 0x0088E1D9 File Offset: 0x0088C5D9
		public Quaternion Rotation
		{
			get
			{
				return this.GetRotation(new Quaternion());
			}
		}

		// Token: 0x0601BFBD RID: 114621 RVA: 0x0088E1E8 File Offset: 0x0088C5E8
		public Quaternion GetRotation(Quaternion obj)
		{
			int num = base.__offset(12);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x0601BFBE RID: 114622 RVA: 0x0088E21E File Offset: 0x0088C61E
		public static void StartDRegionInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x0601BFBF RID: 114623 RVA: 0x0088E227 File Offset: 0x0088C627
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BFC0 RID: 114624 RVA: 0x0088E238 File Offset: 0x0088C638
		public static void AddRegiontype(FlatBufferBuilder builder, RegionType regiontype)
		{
			builder.AddSbyte(1, (sbyte)regiontype, 0);
		}

		// Token: 0x0601BFC1 RID: 114625 RVA: 0x0088E243 File Offset: 0x0088C643
		public static void AddRect(FlatBufferBuilder builder, Offset<Vector2> rectOffset)
		{
			builder.AddStruct(2, rectOffset.Value, 0);
		}

		// Token: 0x0601BFC2 RID: 114626 RVA: 0x0088E254 File Offset: 0x0088C654
		public static void AddRadius(FlatBufferBuilder builder, float radius)
		{
			builder.AddFloat(3, radius, 1.0);
		}

		// Token: 0x0601BFC3 RID: 114627 RVA: 0x0088E267 File Offset: 0x0088C667
		public static void AddRotation(FlatBufferBuilder builder, Offset<Quaternion> rotationOffset)
		{
			builder.AddStruct(4, rotationOffset.Value, 0);
		}

		// Token: 0x0601BFC4 RID: 114628 RVA: 0x0088E278 File Offset: 0x0088C678
		public static Offset<DRegionInfo> EndDRegionInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DRegionInfo>(value);
		}
	}
}
