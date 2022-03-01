using System;

namespace GameClient
{
	// Token: 0x02000E41 RID: 3649
	public class WaitClientFrameOpen : WaitClientFrameState
	{
		// Token: 0x06009177 RID: 37239 RVA: 0x001AEE59 File Offset: 0x001AD259
		public WaitClientFrameOpen(Type type) : base(type, EFrameState.Open)
		{
		}

		// Token: 0x06009178 RID: 37240 RVA: 0x001AEE63 File Offset: 0x001AD263
		public WaitClientFrameOpen(IClientFrame frame) : base(frame, EFrameState.Open)
		{
		}
	}
}
