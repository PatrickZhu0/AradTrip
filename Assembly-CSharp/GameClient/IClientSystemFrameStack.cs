using System;

namespace GameClient
{
	// Token: 0x020010F3 RID: 4339
	public interface IClientSystemFrameStack
	{
		// Token: 0x0600A453 RID: 42067
		void Push2FrameStack(IClientFrameStackCmd cmd);

		// Token: 0x0600A454 RID: 42068
		void ClearFrameStack();
	}
}
