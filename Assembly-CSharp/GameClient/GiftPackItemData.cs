using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Protocol;

namespace GameClient
{
	// Token: 0x02001257 RID: 4695
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct GiftPackItemData
	{
		// Token: 0x0600B44F RID: 46159 RVA: 0x0028556C File Offset: 0x0028396C
		public GiftPackItemData(GiftSyncInfo netData)
		{
			this = default(GiftPackItemData);
			if (netData == null)
			{
				Logger.LogError("数据为空");
				return;
			}
			this.ItemID = (int)netData.itemId;
			this.ID = (int)netData.id;
			this.ItemCount = (int)netData.itemNum;
			this.Weight = (int)netData.weight;
			this.Levels = new List<int>(netData.validLevels.Length);
			for (int i = 0; i < netData.validLevels.Length; i++)
			{
				this.Levels.Add((int)netData.validLevels[i]);
			}
			this.RecommendJobs = new List<int>(netData.recommendJobs.Length);
			for (int j = 0; j < netData.recommendJobs.Length; j++)
			{
				this.RecommendJobs.Add((int)netData.recommendJobs[j]);
			}
			this.EquipType = (int)netData.equipType;
			this.Strengthen = (int)netData.strengthen;
			this.IsTimeLimit = (netData.isTimeLimit == 1);
		}

		// Token: 0x17001AC9 RID: 6857
		// (get) Token: 0x0600B450 RID: 46160 RVA: 0x00285666 File Offset: 0x00283A66
		// (set) Token: 0x0600B451 RID: 46161 RVA: 0x0028566E File Offset: 0x00283A6E
		public int ItemID { get; private set; }

		// Token: 0x17001ACA RID: 6858
		// (get) Token: 0x0600B452 RID: 46162 RVA: 0x00285677 File Offset: 0x00283A77
		// (set) Token: 0x0600B453 RID: 46163 RVA: 0x0028567F File Offset: 0x00283A7F
		public int ID { get; private set; }

		// Token: 0x17001ACB RID: 6859
		// (get) Token: 0x0600B454 RID: 46164 RVA: 0x00285688 File Offset: 0x00283A88
		// (set) Token: 0x0600B455 RID: 46165 RVA: 0x00285690 File Offset: 0x00283A90
		public int ItemCount { get; private set; }

		// Token: 0x17001ACC RID: 6860
		// (get) Token: 0x0600B456 RID: 46166 RVA: 0x00285699 File Offset: 0x00283A99
		// (set) Token: 0x0600B457 RID: 46167 RVA: 0x002856A1 File Offset: 0x00283AA1
		public List<int> RecommendJobs { get; private set; }

		// Token: 0x17001ACD RID: 6861
		// (get) Token: 0x0600B458 RID: 46168 RVA: 0x002856AA File Offset: 0x00283AAA
		// (set) Token: 0x0600B459 RID: 46169 RVA: 0x002856B2 File Offset: 0x00283AB2
		public int Weight { get; private set; }

		// Token: 0x17001ACE RID: 6862
		// (get) Token: 0x0600B45A RID: 46170 RVA: 0x002856BB File Offset: 0x00283ABB
		// (set) Token: 0x0600B45B RID: 46171 RVA: 0x002856C3 File Offset: 0x00283AC3
		public List<int> Levels { get; private set; }

		// Token: 0x17001ACF RID: 6863
		// (get) Token: 0x0600B45C RID: 46172 RVA: 0x002856CC File Offset: 0x00283ACC
		// (set) Token: 0x0600B45D RID: 46173 RVA: 0x002856D4 File Offset: 0x00283AD4
		public int Strengthen { get; private set; }

		// Token: 0x17001AD0 RID: 6864
		// (get) Token: 0x0600B45E RID: 46174 RVA: 0x002856DD File Offset: 0x00283ADD
		// (set) Token: 0x0600B45F RID: 46175 RVA: 0x002856E5 File Offset: 0x00283AE5
		public bool IsTimeLimit { get; private set; }

		// Token: 0x17001AD1 RID: 6865
		// (get) Token: 0x0600B460 RID: 46176 RVA: 0x002856EE File Offset: 0x00283AEE
		// (set) Token: 0x0600B461 RID: 46177 RVA: 0x002856F6 File Offset: 0x00283AF6
		public int EquipType { get; private set; }
	}
}
