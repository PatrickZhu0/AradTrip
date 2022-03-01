using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020018EA RID: 6378
	public class DailyRewardDetailData
	{
		// Token: 0x0600F8D9 RID: 63705 RVA: 0x0043CB94 File Offset: 0x0043AF94
		public DailyRewardDetailData(GiftSyncInfo info)
		{
			this.mSimpleData = new ItemSimpleData((int)info.itemId, (int)info.itemNum);
			string format = TR.Value("activity_summer_watermelon_deatil_description").Replace("\\n", "\n");
			if (info.validLevels.Length != 2)
			{
				Logger.LogError("等级配置不正确!");
				return;
			}
			int num = Mathf.Min((int)info.validLevels[0], (int)info.validLevels[1]);
			int num2 = Mathf.Max((int)info.validLevels[0], (int)info.validLevels[1]);
			this.Desc = string.Format(format, num, num2);
		}

		// Token: 0x17001D06 RID: 7430
		// (get) Token: 0x0600F8DA RID: 63706 RVA: 0x0043CC35 File Offset: 0x0043B035
		// (set) Token: 0x0600F8DB RID: 63707 RVA: 0x0043CC3D File Offset: 0x0043B03D
		public ItemSimpleData mSimpleData { get; private set; }

		// Token: 0x17001D07 RID: 7431
		// (get) Token: 0x0600F8DC RID: 63708 RVA: 0x0043CC46 File Offset: 0x0043B046
		// (set) Token: 0x0600F8DD RID: 63709 RVA: 0x0043CC4E File Offset: 0x0043B04E
		public string Desc { get; private set; }
	}
}
