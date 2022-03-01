using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02000022 RID: 34
	internal class ComClickShowTips : MonoBehaviour
	{
		// Token: 0x060000D2 RID: 210 RVA: 0x000098A5 File Offset: 0x00007CA5
		public void OnClickItemTips()
		{
			if (this.itemData == null)
			{
				this.itemData = ItemDataManager.CreateItemDataFromTable(this.iTableID, 100, 0);
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.itemData, null, 4, true, false, true);
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x000098DB File Offset: 0x00007CDB
		private void OnDestroy()
		{
			this.itemData = null;
			this.iTableID = 0;
		}

		// Token: 0x040000B1 RID: 177
		public int iTableID;

		// Token: 0x040000B2 RID: 178
		private ItemData itemData;
	}
}
