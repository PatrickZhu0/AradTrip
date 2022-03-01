using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B14 RID: 19220
	public sealed class DTownDoor : Table
	{
		// Token: 0x0601BFDC RID: 114652 RVA: 0x0088E4FE File Offset: 0x0088C8FE
		public static DTownDoor GetRootAsDTownDoor(ByteBuffer _bb)
		{
			return DTownDoor.GetRootAsDTownDoor(_bb, new DTownDoor());
		}

		// Token: 0x0601BFDD RID: 114653 RVA: 0x0088E50B File Offset: 0x0088C90B
		public static DTownDoor GetRootAsDTownDoor(ByteBuffer _bb, DTownDoor obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BFDE RID: 114654 RVA: 0x0088E527 File Offset: 0x0088C927
		public DTownDoor __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700263F RID: 9791
		// (get) Token: 0x0601BFDF RID: 114655 RVA: 0x0088E538 File Offset: 0x0088C938
		public DRegionInfo Super
		{
			get
			{
				return this.GetSuper(new DRegionInfo());
			}
		}

		// Token: 0x0601BFE0 RID: 114656 RVA: 0x0088E548 File Offset: 0x0088C948
		public DRegionInfo GetSuper(DRegionInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17002640 RID: 9792
		// (get) Token: 0x0601BFE1 RID: 114657 RVA: 0x0088E584 File Offset: 0x0088C984
		public int SceneID
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002641 RID: 9793
		// (get) Token: 0x0601BFE2 RID: 114658 RVA: 0x0088E5B8 File Offset: 0x0088C9B8
		public int DoorID
		{
			get
			{
				int num = base.__offset(8);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002642 RID: 9794
		// (get) Token: 0x0601BFE3 RID: 114659 RVA: 0x0088E5EC File Offset: 0x0088C9EC
		public Vector3 BirthPos
		{
			get
			{
				return this.GetBirthPos(new Vector3());
			}
		}

		// Token: 0x0601BFE4 RID: 114660 RVA: 0x0088E5FC File Offset: 0x0088C9FC
		public Vector3 GetBirthPos(Vector3 obj)
		{
			int num = base.__offset(10);
			return (num == 0) ? null : obj.__init(num + this.bb_pos, this.bb);
		}

		// Token: 0x17002643 RID: 9795
		// (get) Token: 0x0601BFE5 RID: 114661 RVA: 0x0088E634 File Offset: 0x0088CA34
		public int TargetSceneID
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002644 RID: 9796
		// (get) Token: 0x0601BFE6 RID: 114662 RVA: 0x0088E66C File Offset: 0x0088CA6C
		public int TargetDoorID
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002645 RID: 9797
		// (get) Token: 0x0601BFE7 RID: 114663 RVA: 0x0088E6A4 File Offset: 0x0088CAA4
		public DoorTargetType DoorType
		{
			get
			{
				int num = base.__offset(16);
				return (DoorTargetType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x0601BFE8 RID: 114664 RVA: 0x0088E6D9 File Offset: 0x0088CAD9
		public static void StartDTownDoor(FlatBufferBuilder builder)
		{
			builder.StartObject(7);
		}

		// Token: 0x0601BFE9 RID: 114665 RVA: 0x0088E6E2 File Offset: 0x0088CAE2
		public static void AddSuper(FlatBufferBuilder builder, Offset<DRegionInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BFEA RID: 114666 RVA: 0x0088E6F3 File Offset: 0x0088CAF3
		public static void AddSceneID(FlatBufferBuilder builder, int SceneID)
		{
			builder.AddInt(1, SceneID, 0);
		}

		// Token: 0x0601BFEB RID: 114667 RVA: 0x0088E6FE File Offset: 0x0088CAFE
		public static void AddDoorID(FlatBufferBuilder builder, int DoorID)
		{
			builder.AddInt(2, DoorID, 0);
		}

		// Token: 0x0601BFEC RID: 114668 RVA: 0x0088E709 File Offset: 0x0088CB09
		public static void AddBirthPos(FlatBufferBuilder builder, Offset<Vector3> BirthPosOffset)
		{
			builder.AddStruct(3, BirthPosOffset.Value, 0);
		}

		// Token: 0x0601BFED RID: 114669 RVA: 0x0088E71A File Offset: 0x0088CB1A
		public static void AddTargetSceneID(FlatBufferBuilder builder, int TargetSceneID)
		{
			builder.AddInt(4, TargetSceneID, 0);
		}

		// Token: 0x0601BFEE RID: 114670 RVA: 0x0088E725 File Offset: 0x0088CB25
		public static void AddTargetDoorID(FlatBufferBuilder builder, int TargetDoorID)
		{
			builder.AddInt(5, TargetDoorID, 0);
		}

		// Token: 0x0601BFEF RID: 114671 RVA: 0x0088E730 File Offset: 0x0088CB30
		public static void AddDoorType(FlatBufferBuilder builder, DoorTargetType DoorType)
		{
			builder.AddSbyte(6, (sbyte)DoorType, 0);
		}

		// Token: 0x0601BFF0 RID: 114672 RVA: 0x0088E73C File Offset: 0x0088CB3C
		public static Offset<DTownDoor> EndDTownDoor(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DTownDoor>(value);
		}
	}
}
