using System;

namespace GameClient
{
	// Token: 0x02000FC3 RID: 4035
	internal class UIEventShowFriendSecMenu : UIEvent
	{
		// Token: 0x06009AE5 RID: 39653 RVA: 0x001DF297 File Offset: 0x001DD697
		public UIEventShowFriendSecMenu(RelationMenuData data)
		{
			base.Initialize();
			this.EventID = EUIEventID.OnShowFriendSecMenu;
			this.m_data = data;
		}

		// Token: 0x04005078 RID: 20600
		public RelationMenuData m_data;
	}
}
