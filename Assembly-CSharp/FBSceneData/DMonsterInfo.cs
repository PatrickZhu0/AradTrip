using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B0E RID: 19214
	public sealed class DMonsterInfo : Table
	{
		// Token: 0x0601BF6C RID: 114540 RVA: 0x0088D916 File Offset: 0x0088BD16
		public static DMonsterInfo GetRootAsDMonsterInfo(ByteBuffer _bb)
		{
			return DMonsterInfo.GetRootAsDMonsterInfo(_bb, new DMonsterInfo());
		}

		// Token: 0x0601BF6D RID: 114541 RVA: 0x0088D923 File Offset: 0x0088BD23
		public static DMonsterInfo GetRootAsDMonsterInfo(ByteBuffer _bb, DMonsterInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF6E RID: 114542 RVA: 0x0088D93F File Offset: 0x0088BD3F
		public DMonsterInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x17002621 RID: 9761
		// (get) Token: 0x0601BF6F RID: 114543 RVA: 0x0088D950 File Offset: 0x0088BD50
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BF70 RID: 114544 RVA: 0x0088D960 File Offset: 0x0088BD60
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17002622 RID: 9762
		// (get) Token: 0x0601BF71 RID: 114545 RVA: 0x0088D99C File Offset: 0x0088BD9C
		public MonsterSwapType SwapType
		{
			get
			{
				int num = base.__offset(6);
				return (MonsterSwapType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x17002623 RID: 9763
		// (get) Token: 0x0601BF72 RID: 114546 RVA: 0x0088D9D0 File Offset: 0x0088BDD0
		public FaceType FaceType
		{
			get
			{
				int num = base.__offset(8);
				return (FaceType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x17002624 RID: 9764
		// (get) Token: 0x0601BF73 RID: 114547 RVA: 0x0088DA04 File Offset: 0x0088BE04
		public int SwapNum
		{
			get
			{
				int num = base.__offset(10);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002625 RID: 9765
		// (get) Token: 0x0601BF74 RID: 114548 RVA: 0x0088DA3C File Offset: 0x0088BE3C
		public int SwapDelay
		{
			get
			{
				int num = base.__offset(12);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002626 RID: 9766
		// (get) Token: 0x0601BF75 RID: 114549 RVA: 0x0088DA74 File Offset: 0x0088BE74
		public int FlushGroupID
		{
			get
			{
				int num = base.__offset(14);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x17002627 RID: 9767
		// (get) Token: 0x0601BF76 RID: 114550 RVA: 0x0088DAAC File Offset: 0x0088BEAC
		public FlowRegionType FlowRegionType
		{
			get
			{
				int num = base.__offset(16);
				return (FlowRegionType)((num == 0) ? 0 : this.bb.GetSbyte(num + this.bb_pos));
			}
		}

		// Token: 0x17002628 RID: 9768
		// (get) Token: 0x0601BF77 RID: 114551 RVA: 0x0088DAE1 File Offset: 0x0088BEE1
		public DRegionInfo RegionInfo
		{
			get
			{
				return this.GetRegionInfo(new DRegionInfo());
			}
		}

		// Token: 0x0601BF78 RID: 114552 RVA: 0x0088DAF0 File Offset: 0x0088BEF0
		public DRegionInfo GetRegionInfo(DRegionInfo obj)
		{
			int num = base.__offset(18);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x17002629 RID: 9769
		// (get) Token: 0x0601BF79 RID: 114553 RVA: 0x0088DB2C File Offset: 0x0088BF2C
		public DDestructibleInfo DestructInfo
		{
			get
			{
				return this.GetDestructInfo(new DDestructibleInfo());
			}
		}

		// Token: 0x0601BF7A RID: 114554 RVA: 0x0088DB3C File Offset: 0x0088BF3C
		public DDestructibleInfo GetDestructInfo(DDestructibleInfo obj)
		{
			int num = base.__offset(20);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x0601BF7B RID: 114555 RVA: 0x0088DB78 File Offset: 0x0088BF78
		public static Offset<DMonsterInfo> CreateDMonsterInfo(FlatBufferBuilder builder, Offset<DEntityInfo> super = default(Offset<DEntityInfo>), MonsterSwapType swapType = MonsterSwapType.POINT_SWAP, FaceType faceType = FaceType.Right, int swapNum = 0, int swapDelay = 0, int flushGroupID = 0, FlowRegionType flowRegionType = FlowRegionType.None, Offset<DRegionInfo> regionInfo = default(Offset<DRegionInfo>), Offset<DDestructibleInfo> destructInfo = default(Offset<DDestructibleInfo>))
		{
			builder.StartObject(9);
			DMonsterInfo.AddDestructInfo(builder, destructInfo);
			DMonsterInfo.AddRegionInfo(builder, regionInfo);
			DMonsterInfo.AddFlushGroupID(builder, flushGroupID);
			DMonsterInfo.AddSwapDelay(builder, swapDelay);
			DMonsterInfo.AddSwapNum(builder, swapNum);
			DMonsterInfo.AddSuper(builder, super);
			DMonsterInfo.AddFlowRegionType(builder, flowRegionType);
			DMonsterInfo.AddFaceType(builder, faceType);
			DMonsterInfo.AddSwapType(builder, swapType);
			return DMonsterInfo.EndDMonsterInfo(builder);
		}

		// Token: 0x0601BF7C RID: 114556 RVA: 0x0088DBD8 File Offset: 0x0088BFD8
		public static void StartDMonsterInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(9);
		}

		// Token: 0x0601BF7D RID: 114557 RVA: 0x0088DBE2 File Offset: 0x0088BFE2
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BF7E RID: 114558 RVA: 0x0088DBF3 File Offset: 0x0088BFF3
		public static void AddSwapType(FlatBufferBuilder builder, MonsterSwapType swapType)
		{
			builder.AddSbyte(1, (sbyte)swapType, 0);
		}

		// Token: 0x0601BF7F RID: 114559 RVA: 0x0088DBFE File Offset: 0x0088BFFE
		public static void AddFaceType(FlatBufferBuilder builder, FaceType faceType)
		{
			builder.AddSbyte(2, (sbyte)faceType, 0);
		}

		// Token: 0x0601BF80 RID: 114560 RVA: 0x0088DC09 File Offset: 0x0088C009
		public static void AddSwapNum(FlatBufferBuilder builder, int swapNum)
		{
			builder.AddInt(3, swapNum, 0);
		}

		// Token: 0x0601BF81 RID: 114561 RVA: 0x0088DC14 File Offset: 0x0088C014
		public static void AddSwapDelay(FlatBufferBuilder builder, int swapDelay)
		{
			builder.AddInt(4, swapDelay, 0);
		}

		// Token: 0x0601BF82 RID: 114562 RVA: 0x0088DC1F File Offset: 0x0088C01F
		public static void AddFlushGroupID(FlatBufferBuilder builder, int flushGroupID)
		{
			builder.AddInt(5, flushGroupID, 0);
		}

		// Token: 0x0601BF83 RID: 114563 RVA: 0x0088DC2A File Offset: 0x0088C02A
		public static void AddFlowRegionType(FlatBufferBuilder builder, FlowRegionType flowRegionType)
		{
			builder.AddSbyte(6, (sbyte)flowRegionType, 0);
		}

		// Token: 0x0601BF84 RID: 114564 RVA: 0x0088DC35 File Offset: 0x0088C035
		public static void AddRegionInfo(FlatBufferBuilder builder, Offset<DRegionInfo> regionInfoOffset)
		{
			builder.AddOffset(7, regionInfoOffset.Value, 0);
		}

		// Token: 0x0601BF85 RID: 114565 RVA: 0x0088DC46 File Offset: 0x0088C046
		public static void AddDestructInfo(FlatBufferBuilder builder, Offset<DDestructibleInfo> destructInfoOffset)
		{
			builder.AddOffset(8, destructInfoOffset.Value, 0);
		}

		// Token: 0x0601BF86 RID: 114566 RVA: 0x0088DC58 File Offset: 0x0088C058
		public static Offset<DMonsterInfo> EndDMonsterInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DMonsterInfo>(value);
		}
	}
}
