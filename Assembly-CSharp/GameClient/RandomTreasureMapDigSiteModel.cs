using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x020012CC RID: 4812
	public class RandomTreasureMapDigSiteModel
	{
		// Token: 0x0600BA74 RID: 47732 RVA: 0x002B1172 File Offset: 0x002AF572
		public RandomTreasureMapDigSiteModel()
		{
			this.Clear();
		}

		// Token: 0x0600BA75 RID: 47733 RVA: 0x002B119C File Offset: 0x002AF59C
		public void Clear()
		{
			this.index = -1;
			this.mapId = -1;
			this.type = DigType.DIG_INVALID;
			this.status = DigStatus.DIG_STATUS_INVALID;
			this.refreshTime = 0U;
			this.changeStatusTime = 0U;
			this.openItem = null;
			if (this.itemSDatas != null)
			{
				this.itemSDatas.Clear();
			}
		}

		// Token: 0x040068BD RID: 26813
		public int index = -1;

		// Token: 0x040068BE RID: 26814
		public int mapId = -1;

		// Token: 0x040068BF RID: 26815
		public DigType type;

		// Token: 0x040068C0 RID: 26816
		public DigStatus status;

		// Token: 0x040068C1 RID: 26817
		public uint refreshTime;

		// Token: 0x040068C2 RID: 26818
		public uint changeStatusTime;

		// Token: 0x040068C3 RID: 26819
		public ItemSimpleData openItem;

		// Token: 0x040068C4 RID: 26820
		public List<ItemSimpleData> itemSDatas = new List<ItemSimpleData>();
	}
}
