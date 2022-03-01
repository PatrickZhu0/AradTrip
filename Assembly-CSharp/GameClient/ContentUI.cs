using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020015E1 RID: 5601
	public class ContentUI
	{
		// Token: 0x0600DB55 RID: 56149 RVA: 0x0037461B File Offset: 0x00372A1B
		public void Clear()
		{
			this.bNeedWait = false;
			this.title = string.Empty;
			this.icon = null;
			this.material = null;
			this.name = string.Empty;
			this.explannation = string.Empty;
		}

		// Token: 0x04008139 RID: 33081
		public bool bNeedWait;

		// Token: 0x0400813A RID: 33082
		public string title;

		// Token: 0x0400813B RID: 33083
		public Sprite icon;

		// Token: 0x0400813C RID: 33084
		public Material material;

		// Token: 0x0400813D RID: 33085
		public string name;

		// Token: 0x0400813E RID: 33086
		public string explannation;
	}
}
