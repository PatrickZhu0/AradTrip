using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020012FD RID: 4861
	public class StrengthenTicketMaterialFuseModel
	{
		// Token: 0x0600BC5A RID: 48218 RVA: 0x002BEA7A File Offset: 0x002BCE7A
		public StrengthenTicketMaterialFuseModel()
		{
			this.Clear();
		}

		// Token: 0x0600BC5B RID: 48219 RVA: 0x002BEAA0 File Offset: 0x002BCEA0
		public void Clear()
		{
			if (this.materialModels != null)
			{
				for (int i = 0; i < this.materialModels.Count; i++)
				{
					if (this.materialModels[i] != null)
					{
						this.materialModels[i].Clear();
					}
				}
				this.materialModels.Clear();
			}
			if (this.ticketModels != null)
			{
				for (int j = 0; j < this.ticketModels.Count; j++)
				{
					if (this.ticketModels[j] != null)
					{
						this.ticketModels[j].Clear();
					}
				}
				this.ticketModels.Clear();
			}
		}

		// Token: 0x04006A05 RID: 27141
		public List<StrengthenTicketFuseSpecialMaterial> materialModels = new List<StrengthenTicketFuseSpecialMaterial>();

		// Token: 0x04006A06 RID: 27142
		public List<StrengthenTicketFuseItemData> ticketModels = new List<StrengthenTicketFuseItemData>();

		// Token: 0x04006A07 RID: 27143
		public int predictMinLevel;

		// Token: 0x04006A08 RID: 27144
		public int predictMaxLevel;

		// Token: 0x04006A09 RID: 27145
		public int perdictMinPercent;

		// Token: 0x04006A0A RID: 27146
		public int perdictMaxPercent;
	}
}
