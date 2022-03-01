using System;

namespace GameClient
{
	// Token: 0x02000FC2 RID: 4034
	internal class UIEventRecievRecommendFriend : UIEvent
	{
		// Token: 0x06009AE4 RID: 39652 RVA: 0x001DF277 File Offset: 0x001DD677
		public UIEventRecievRecommendFriend(RelationData[] list)
		{
			base.Initialize();
			this.EventID = EUIEventID.OnRecievRecommendFriend;
			this.m_friendList = list;
		}

		// Token: 0x04005077 RID: 20599
		public RelationData[] m_friendList;
	}
}
