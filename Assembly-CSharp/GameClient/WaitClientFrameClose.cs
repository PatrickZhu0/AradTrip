using System;

namespace GameClient
{
	// Token: 0x02000E42 RID: 3650
	public class WaitClientFrameClose : WaitClientFrameState
	{
		// Token: 0x06009179 RID: 37241 RVA: 0x001AEE6D File Offset: 0x001AD26D
		public WaitClientFrameClose(Type type) : base(type, EFrameState.Close)
		{
		}

		// Token: 0x0600917A RID: 37242 RVA: 0x001AEE77 File Offset: 0x001AD277
		public WaitClientFrameClose(IClientFrame frame) : base(frame, EFrameState.Close)
		{
		}
	}
}
