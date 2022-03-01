using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001B1B RID: 6939
	internal class ComEventBinder : MonoBehaviour
	{
		// Token: 0x06011084 RID: 69764 RVA: 0x004E01B4 File Offset: 0x004DE5B4
		public void SendEvent(int iIndex)
		{
			if (iIndex >= 0 && iIndex < this.mEvents.Length)
			{
				UIEventSystem.GetInstance().SendUIEvent(this.mEvents[iIndex], null, null, null, null);
			}
		}

		// Token: 0x0400AF52 RID: 44882
		public EUIEventID[] mEvents = new EUIEventID[0];
	}
}
