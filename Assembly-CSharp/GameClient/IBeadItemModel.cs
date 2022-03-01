using System;

namespace GameClient
{
	// Token: 0x02001ABC RID: 6844
	internal interface IBeadItemModel
	{
		// Token: 0x17001D5D RID: 7517
		// (get) Token: 0x06010CE8 RID: 68840
		int mountedType { get; }

		// Token: 0x17001D5E RID: 7518
		// (get) Token: 0x06010CE9 RID: 68841
		ItemData equipItemData { get; }

		// Token: 0x17001D5F RID: 7519
		// (get) Token: 0x06010CEA RID: 68842
		int eqPrecHoleIndex { get; }

		// Token: 0x17001D60 RID: 7520
		// (get) Token: 0x06010CEB RID: 68843
		ItemData beadItemData { get; }

		// Token: 0x17001D61 RID: 7521
		// (get) Token: 0x06010CEC RID: 68844
		int buffID { get; }

		// Token: 0x17001D62 RID: 7522
		// (get) Token: 0x06010CED RID: 68845
		int beadPickNumber { get; }

		// Token: 0x17001D63 RID: 7523
		// (get) Token: 0x06010CEE RID: 68846
		int holeType { get; }

		// Token: 0x17001D64 RID: 7524
		// (get) Token: 0x06010CEF RID: 68847
		int replaceNumber { get; }
	}
}
