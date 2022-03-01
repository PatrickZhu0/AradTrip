using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D5D RID: 3421
	public sealed class DModelPartChunk : Table
	{
		// Token: 0x06008ADD RID: 35549 RVA: 0x00198BAB File Offset: 0x00196FAB
		public static DModelPartChunk GetRootAsDModelPartChunk(ByteBuffer _bb)
		{
			return DModelPartChunk.GetRootAsDModelPartChunk(_bb, new DModelPartChunk());
		}

		// Token: 0x06008ADE RID: 35550 RVA: 0x00198BB8 File Offset: 0x00196FB8
		public static DModelPartChunk GetRootAsDModelPartChunk(ByteBuffer _bb, DModelPartChunk obj)
		{
			return obj.__init(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06008ADF RID: 35551 RVA: 0x00198BD4 File Offset: 0x00196FD4
		public DModelPartChunk __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x1700187B RID: 6267
		// (get) Token: 0x06008AE0 RID: 35552 RVA: 0x00198BE8 File Offset: 0x00196FE8
		public string PartAsset
		{
			get
			{
				int num = base.__offset(4);
				return (num == 0) ? null : base.__string(num + this.bb_pos);
			}
		}

		// Token: 0x1700187C RID: 6268
		// (get) Token: 0x06008AE1 RID: 35553 RVA: 0x00198C18 File Offset: 0x00197018
		public int PartChannel
		{
			get
			{
				int num = base.__offset(6);
				return (num == 0) ? 0 : this.bb.GetInt(num + this.bb_pos);
			}
		}

		// Token: 0x06008AE2 RID: 35554 RVA: 0x00198C4C File Offset: 0x0019704C
		public static Offset<DModelPartChunk> CreateDModelPartChunk(FlatBufferBuilder builder, StringOffset partAsset = default(StringOffset), int partChannel = 0)
		{
			builder.StartObject(2);
			DModelPartChunk.AddPartChannel(builder, partChannel);
			DModelPartChunk.AddPartAsset(builder, partAsset);
			return DModelPartChunk.EndDModelPartChunk(builder);
		}

		// Token: 0x06008AE3 RID: 35555 RVA: 0x00198C69 File Offset: 0x00197069
		public static void StartDModelPartChunk(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06008AE4 RID: 35556 RVA: 0x00198C72 File Offset: 0x00197072
		public static void AddPartAsset(FlatBufferBuilder builder, StringOffset partAssetOffset)
		{
			builder.AddOffset(0, partAssetOffset.Value, 0);
		}

		// Token: 0x06008AE5 RID: 35557 RVA: 0x00198C83 File Offset: 0x00197083
		public static void AddPartChannel(FlatBufferBuilder builder, int partChannel)
		{
			builder.AddInt(1, partChannel, 0);
		}

		// Token: 0x06008AE6 RID: 35558 RVA: 0x00198C90 File Offset: 0x00197090
		public static Offset<DModelPartChunk> EndDModelPartChunk(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DModelPartChunk>(value);
		}
	}
}
