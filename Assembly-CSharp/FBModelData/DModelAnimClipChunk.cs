using System;
using FlatBuffers;

namespace FBModelData
{
	// Token: 0x02000D60 RID: 3424
	public sealed class DModelAnimClipChunk : Struct
	{
		// Token: 0x06008AFE RID: 35582 RVA: 0x00198EC6 File Offset: 0x001972C6
		public DModelAnimClipChunk __init(int _i, ByteBuffer _bb)
		{
			this.bb_pos = _i;
			this.bb = _bb;
			return this;
		}

		// Token: 0x06008AFF RID: 35583 RVA: 0x00198ED7 File Offset: 0x001972D7
		public static Offset<DModelAnimClipChunk> CreateDModelAnimClipChunk(FlatBufferBuilder builder)
		{
			builder.Prep(1, 0);
			return new Offset<DModelAnimClipChunk>(builder.Offset);
		}
	}
}
