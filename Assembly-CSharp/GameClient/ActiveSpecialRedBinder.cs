using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000009 RID: 9
	public class ActiveSpecialRedBinder : MonoBehaviour
	{
		// Token: 0x06000037 RID: 55 RVA: 0x00005AFC File Offset: 0x00003EFC
		public void SendCheckRedPoint()
		{
			if (this.toggle != null && this.toggle.isOn && !string.IsNullOrEmpty(this.prefabKey) && this.iMainId > 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(new UIEventSpecialRedPointNotify(this.iMainId, this.prefabKey));
				DataManager<ActiveManager>.GetInstance().SaveCurrTimeStamp(this.iMainId);
			}
		}

		// Token: 0x0400001B RID: 27
		public Toggle toggle;

		// Token: 0x0400001C RID: 28
		public string prefabKey;

		// Token: 0x0400001D RID: 29
		public int iMainId;
	}
}
