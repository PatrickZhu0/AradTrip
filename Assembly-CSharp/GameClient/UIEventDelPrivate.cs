using System;

namespace GameClient
{
	// Token: 0x02000FC4 RID: 4036
	internal class UIEventDelPrivate : UIEvent
	{
		// Token: 0x06009AE6 RID: 39654 RVA: 0x001DF2B7 File Offset: 0x001DD6B7
		public UIEventDelPrivate(ulong uid)
		{
			base.Initialize();
			this.EventID = EUIEventID.OnDelPrivate;
			this.m_uid = uid;
		}

		// Token: 0x04005079 RID: 20601
		public ulong m_uid;
	}
}
