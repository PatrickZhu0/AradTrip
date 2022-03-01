using System;

namespace Protocol
{
	// Token: 0x02000B70 RID: 2928
	public interface IProtocolStream
	{
		// Token: 0x06007C92 RID: 31890
		void encode(byte[] buffer, ref int pos);

		// Token: 0x06007C93 RID: 31891
		void decode(byte[] buffer, ref int pos);
	}
}
