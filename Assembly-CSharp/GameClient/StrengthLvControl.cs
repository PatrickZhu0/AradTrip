using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200474F RID: 18255
	internal class StrengthLvControl : MonoBehaviour
	{
		// Token: 0x0601A393 RID: 107411 RVA: 0x00825444 File Offset: 0x00823844
		public void SetVisible(bool bVisible)
		{
			if (this.listVisible != null)
			{
				for (int i = 0; i < this.listVisible.Count; i++)
				{
					this.listVisible[i].CustomActive(bVisible);
				}
			}
		}

		// Token: 0x040126BE RID: 75454
		public List<GameObject> listVisible;
	}
}
