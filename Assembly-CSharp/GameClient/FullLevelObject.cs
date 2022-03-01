using System;
using System.Text.RegularExpressions;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200137F RID: 4991
	public class FullLevelObject
	{
		// Token: 0x0600C1B0 RID: 49584 RVA: 0x002E2CB0 File Offset: 0x002E10B0
		public void Update()
		{
			bool bActive = (int)DataManager<PlayerBaseData>.GetInstance().Level >= DataManager<PlayerBaseData>.GetInstance().PlayerMaxLv;
			this.gameObject.CustomActive(bActive);
		}

		// Token: 0x04006DAF RID: 28079
		public static Regex kvRegex = new Regex("<path=([A-Za-z0-9/]+) option=([A-Za-z0-9]+) type=(\\d+)>", RegexOptions.Singleline);

		// Token: 0x04006DB0 RID: 28080
		public GameObject gameObject;
	}
}
