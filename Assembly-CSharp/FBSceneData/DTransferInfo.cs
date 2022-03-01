using System;
using FlatBuffers;

namespace FBSceneData
{
	// Token: 0x02004B0F RID: 19215
	public sealed class DTransferInfo : Table
	{
		// Token: 0x0601BF88 RID: 114568 RVA: 0x0088DC7A File Offset: 0x0088C07A
		public static DTransferInfo GetRootAsDTransferInfo(ByteBuffer _bb)
		{
			return DTransferInfo.GetRootAsDTransferInfo(_bb, new DTransferInfo());
		}

		// Token: 0x0601BF89 RID: 114569 RVA: 0x0088DC87 File Offset: 0x0088C087
		public static DTransferInfo GetRootAsDTransferInfo(ByteBuffer _bb, DTransferInfo obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0601BF8A RID: 114570 RVA: 0x0088DCA3 File Offset: 0x0088C0A3
		public DTransferInfo __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700262A RID: 9770
		// (get) Token: 0x0601BF8B RID: 114571 RVA: 0x0088DCB4 File Offset: 0x0088C0B4
		public DEntityInfo Super
		{
			get
			{
				return this.GetSuper(new DEntityInfo());
			}
		}

		// Token: 0x0601BF8C RID: 114572 RVA: 0x0088DCC4 File Offset: 0x0088C0C4
		public DEntityInfo GetSuper(DEntityInfo obj)
		{
			int num = base.__offset(4);
			return (num == 0) ? null : obj.__init(base.__indirect(num + this.bb_pos), this.bb);
		}

		// Token: 0x1700262B RID: 9771
		// (get) Token: 0x0601BF8D RID: 114573 RVA: 0x0088DD00 File Offset: 0x0088C100
		public int RegionId
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x0601BF8E RID: 114574 RVA: 0x0088DD34 File Offset: 0x0088C134
		public static Offset<DTransferInfo> CreateDTransferInfo(FlatBufferBuilder builder, Offset<DEntityInfo> super = default(Offset<DEntityInfo>), int regionId = 0)
		{
			builder.StartObject(2);
			DTransferInfo.AddRegionId(builder, regionId);
			DTransferInfo.AddSuper(builder, super);
			return DTransferInfo.EndDTransferInfo(builder);
		}

		// Token: 0x0601BF8F RID: 114575 RVA: 0x0088DD51 File Offset: 0x0088C151
		public static void StartDTransferInfo(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x0601BF90 RID: 114576 RVA: 0x0088DD5A File Offset: 0x0088C15A
		public static void AddSuper(FlatBufferBuilder builder, Offset<DEntityInfo> superOffset)
		{
			builder.AddOffset(0, superOffset.Value, 0);
		}

		// Token: 0x0601BF91 RID: 114577 RVA: 0x0088DD6B File Offset: 0x0088C16B
		public static void AddRegionId(FlatBufferBuilder builder, int regionId)
		{
			builder.AddInt(1, regionId, 0);
		}

		// Token: 0x0601BF92 RID: 114578 RVA: 0x0088DD78 File Offset: 0x0088C178
		public static Offset<DTransferInfo> EndDTransferInfo(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DTransferInfo>(value);
		}
	}
}
