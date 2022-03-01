using System;

namespace GameClient
{
	// Token: 0x02004511 RID: 17681
	public interface IOnExecCommand
	{
		// Token: 0x06018982 RID: 100738
		void BeforeExecFrameCommand(byte seat, IFrameCommand cmd);

		// Token: 0x06018983 RID: 100739
		void AfterExecFrameCommand(byte seat, IFrameCommand cmd);
	}
}
