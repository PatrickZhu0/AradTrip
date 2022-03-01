using System;

namespace Protocol
{
	// Token: 0x02000B71 RID: 2929
	public interface IGetMsgID
	{
		// Token: 0x06007C94 RID: 31892
		uint GetMsgID();

		// Token: 0x06007C95 RID: 31893
		uint GetSequence();

		// Token: 0x06007C96 RID: 31894
		void SetSequence(uint sequence);
	}
}
