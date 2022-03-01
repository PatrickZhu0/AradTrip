using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02000FC8 RID: 4040
	internal class UIEventRecvQueryPlayer : UIEvent
	{
		// Token: 0x06009AEA RID: 39658 RVA: 0x001DF332 File Offset: 0x001DD732
		public UIEventRecvQueryPlayer(PlayerWatchInfo info)
		{
			this.EventID = EUIEventID.OnRecvQueryPlayer;
			this._info = info;
		}

		// Token: 0x0400507E RID: 20606
		public PlayerWatchInfo _info;
	}
}
