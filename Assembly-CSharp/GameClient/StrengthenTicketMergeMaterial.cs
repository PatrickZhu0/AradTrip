using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012F8 RID: 4856
	public class StrengthenTicketMergeMaterial
	{
		// Token: 0x0600BC50 RID: 48208 RVA: 0x002BE989 File Offset: 0x002BCD89
		public StrengthenTicketMergeMaterial()
		{
			this.Clear();
		}

		// Token: 0x0600BC51 RID: 48209 RVA: 0x002BE9A2 File Offset: 0x002BCDA2
		public void Clear()
		{
			if (this.needMaterialDatas != null)
			{
				this.needMaterialDatas.Clear();
			}
		}

		// Token: 0x040069EA RID: 27114
		public int mergeTableId;

		// Token: 0x040069EB RID: 27115
		public List<StrengthenTicketMergeItemData> needMaterialDatas = new List<StrengthenTicketMergeItemData>();
	}
}
