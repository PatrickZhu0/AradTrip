using System;

namespace GameClient
{
	// Token: 0x020010EF RID: 4335
	public interface IClientFrameStackCmd
	{
		// Token: 0x0600A44A RID: 42058
		eClientFrameStackCmd CmdType();

		// Token: 0x0600A44B RID: 42059
		bool Do();
	}
}
