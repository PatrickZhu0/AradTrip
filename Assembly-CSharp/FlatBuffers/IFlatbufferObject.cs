using System;

namespace FlatBuffers
{
	// Token: 0x02004B48 RID: 19272
	public interface IFlatbufferObject
	{
		// Token: 0x0601C51D RID: 115997
		void __init(int _i, ByteBuffer _bb);

		// Token: 0x170027D7 RID: 10199
		// (get) Token: 0x0601C51E RID: 115998
		ByteBuffer ByteBuffer { get; }
	}
}
