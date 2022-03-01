using System;

namespace GameClient
{
	// Token: 0x02000FD5 RID: 4053
	internal class GlobalEventSystem : ClientEventSystem
	{
		// Token: 0x06009B12 RID: 39698 RVA: 0x001DFACF File Offset: 0x001DDECF
		public static GlobalEventSystem GetInstance()
		{
			return GlobalEventSystem.ms_instance;
		}

		// Token: 0x0400549F RID: 21663
		public static GlobalEventSystem ms_instance = new GlobalEventSystem();
	}
}
