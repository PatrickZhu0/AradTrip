using System;

namespace GameClient
{
	// Token: 0x02000FC7 RID: 4039
	internal class UIEventRecvPrivateChat : UIEvent
	{
		// Token: 0x06009AE9 RID: 39657 RVA: 0x001DF318 File Offset: 0x001DD718
		public UIEventRecvPrivateChat(bool isRecv)
		{
			this.EventID = EUIEventID.OnRecvPrivateChat;
			this._isRecv = isRecv;
		}

		// Token: 0x0400507D RID: 20605
		public bool _isRecv;
	}
}
