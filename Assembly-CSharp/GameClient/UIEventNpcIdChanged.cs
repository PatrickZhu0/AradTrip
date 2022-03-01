using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000FC0 RID: 4032
	internal class UIEventNpcIdChanged : UIEvent
	{
		// Token: 0x06009AE2 RID: 39650 RVA: 0x001DF213 File Offset: 0x001DD613
		public UIEventNpcIdChanged(int npcID, int npcResourceID, Transform transform, Camera eventCamera)
		{
			base.Initialize();
			this.npcID = npcID;
			this.npcResourceID = npcResourceID;
			this.transform = transform;
			this.eventCamera = eventCamera;
			this.EventID = EUIEventID.MenuIdChanged;
			this.IsUsing = true;
		}

		// Token: 0x04005072 RID: 20594
		public int npcID;

		// Token: 0x04005073 RID: 20595
		public int npcResourceID;

		// Token: 0x04005074 RID: 20596
		public Transform transform;

		// Token: 0x04005075 RID: 20597
		public Camera eventCamera;
	}
}
