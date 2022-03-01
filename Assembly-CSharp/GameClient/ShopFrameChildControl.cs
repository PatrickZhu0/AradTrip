using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x0200473F RID: 18239
	internal class ShopFrameChildControl : MonoBehaviour
	{
		// Token: 0x0601A34B RID: 107339 RVA: 0x008237C8 File Offset: 0x00821BC8
		public void SetMode(ShopFrame.ShopFrameMode eMode)
		{
			List<GameObject> list = null;
			if (eMode == ShopFrame.ShopFrameMode.SFM_CHILD_FRAME)
			{
				list = this.childVisible;
			}
			else if (eMode == ShopFrame.ShopFrameMode.SFM_MAIN_FRAME)
			{
				list = this.mainVisible;
			}
			else if (eMode == ShopFrame.ShopFrameMode.SFM_GUILD_CHILD_FRAME)
			{
				list = this.guildVisible;
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i] != null)
				{
					list[i].CustomActive(true);
				}
			}
		}

		// Token: 0x04012673 RID: 75379
		public List<GameObject> mainVisible = new List<GameObject>();

		// Token: 0x04012674 RID: 75380
		public List<GameObject> childVisible = new List<GameObject>();

		// Token: 0x04012675 RID: 75381
		public List<GameObject> guildVisible = new List<GameObject>();
	}
}
