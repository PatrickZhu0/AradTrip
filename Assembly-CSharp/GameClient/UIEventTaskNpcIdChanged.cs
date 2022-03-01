using System;

namespace GameClient
{
	// Token: 0x02000FC1 RID: 4033
	internal class UIEventTaskNpcIdChanged : UIEvent
	{
		// Token: 0x06009AE3 RID: 39651 RVA: 0x001DF250 File Offset: 0x001DD650
		public UIEventTaskNpcIdChanged(int npcID)
		{
			base.Initialize();
			this.npcID = npcID;
			this.EventID = EUIEventID.TaskNpcIdChanged;
			this.IsUsing = true;
		}

		// Token: 0x04005076 RID: 20598
		public int npcID;
	}
}
