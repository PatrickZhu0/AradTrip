using System;

namespace GameClient
{
	// Token: 0x02000FC5 RID: 4037
	internal class UIEventPrivateChat : UIEvent
	{
		// Token: 0x06009AE7 RID: 39655 RVA: 0x001DF2D7 File Offset: 0x001DD6D7
		public UIEventPrivateChat(RelationData data, bool recvChat)
		{
			base.Initialize();
			this.EventID = EUIEventID.OnPrivateChat;
			this.m_data = data;
			this.m_recvChat = recvChat;
		}

		// Token: 0x0400507A RID: 20602
		public bool m_recvChat;

		// Token: 0x0400507B RID: 20603
		public RelationData m_data;
	}
}
