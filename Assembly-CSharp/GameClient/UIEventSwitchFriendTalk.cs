using System;

namespace GameClient
{
	// Token: 0x02000FC6 RID: 4038
	internal class UIEventSwitchFriendTalk : UIEvent
	{
		// Token: 0x06009AE8 RID: 39656 RVA: 0x001DF2FE File Offset: 0x001DD6FE
		public UIEventSwitchFriendTalk(ulong uid)
		{
			this.EventID = EUIEventID.OnShowFriendChat;
			this.m_uid = uid;
		}

		// Token: 0x0400507C RID: 20604
		public ulong m_uid;
	}
}
