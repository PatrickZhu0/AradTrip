using System;

namespace GameClient
{
	// Token: 0x02000FD4 RID: 4052
	internal class UIEventSystem : ClientEventSystem
	{
		// Token: 0x06009B0F RID: 39695 RVA: 0x001DFAB4 File Offset: 0x001DDEB4
		public static UIEventSystem GetInstance()
		{
			return UIEventSystem.ms_instance;
		}

		// Token: 0x0400549E RID: 21662
		public static UIEventSystem ms_instance = new UIEventSystem();
	}
}
