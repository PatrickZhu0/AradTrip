using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001656 RID: 5718
	internal class GuildStoreConfirmFrameData
	{
		// Token: 0x040085CD RID: 34253
		public string title;

		// Token: 0x040085CE RID: 34254
		public int iMax;

		// Token: 0x040085CF RID: 34255
		public int iCurCount;

		// Token: 0x040085D0 RID: 34256
		public UnityAction<int> onOk;
	}
}
