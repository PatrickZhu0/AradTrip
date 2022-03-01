using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012CB RID: 4811
	public class RandomTreasureMapModel
	{
		// Token: 0x0600BA72 RID: 47730 RVA: 0x002B1117 File Offset: 0x002AF517
		public RandomTreasureMapModel()
		{
			this.Clear();
		}

		// Token: 0x0600BA73 RID: 47731 RVA: 0x002B1137 File Offset: 0x002AF537
		public void Clear()
		{
			this.mapId = -1;
			this.beInPlayerNum = 0;
			this.goldSiteNum = 0;
			this.silverSiteNum = 0;
			if (this.mapTotalDigSites != null)
			{
				this.mapTotalDigSites.Clear();
			}
			this.localMapData = null;
		}

		// Token: 0x040068B7 RID: 26807
		public int mapId = -1;

		// Token: 0x040068B8 RID: 26808
		public int beInPlayerNum;

		// Token: 0x040068B9 RID: 26809
		public List<RandomTreasureMapDigSiteModel> mapTotalDigSites = new List<RandomTreasureMapDigSiteModel>();

		// Token: 0x040068BA RID: 26810
		public int goldSiteNum;

		// Token: 0x040068BB RID: 26811
		public int silverSiteNum;

		// Token: 0x040068BC RID: 26812
		public DigMapTable localMapData;
	}
}
