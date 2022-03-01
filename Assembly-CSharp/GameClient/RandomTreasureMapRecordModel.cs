using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020012CD RID: 4813
	public class RandomTreasureMapRecordModel
	{
		// Token: 0x0600BA76 RID: 47734 RVA: 0x002B11F0 File Offset: 0x002AF5F0
		public RandomTreasureMapRecordModel()
		{
			this.Clear();
		}

		// Token: 0x0600BA77 RID: 47735 RVA: 0x002B1205 File Offset: 0x002AF605
		public void Clear()
		{
			this.mapId = -1;
			this.mapName = string.Empty;
			this.digIndex = -1;
			this.digType = DigType.DIG_INVALID;
			this.playerId = 0UL;
			this.playerName = string.Empty;
			this.itemSData = null;
		}

		// Token: 0x040068C5 RID: 26821
		public int mapId;

		// Token: 0x040068C6 RID: 26822
		public string mapName;

		// Token: 0x040068C7 RID: 26823
		public int digIndex = -1;

		// Token: 0x040068C8 RID: 26824
		public DigType digType;

		// Token: 0x040068C9 RID: 26825
		public ulong playerId;

		// Token: 0x040068CA RID: 26826
		public string playerName;

		// Token: 0x040068CB RID: 26827
		public ItemSimpleData itemSData;
	}
}
