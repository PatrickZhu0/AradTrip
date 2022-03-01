using System;

namespace GameClient
{
	// Token: 0x020011ED RID: 4589
	public class AuctionNewPreviewOnShelfItemData
	{
		// Token: 0x0600B07E RID: 45182 RVA: 0x0026D58C File Offset: 0x0026B98C
		public AuctionNewPreviewOnShelfItemData()
		{
			this.ItemId = 0;
			this.StrengthLevel = 0;
			this.OnShelfPrice = 0;
		}

		// Token: 0x0600B07F RID: 45183 RVA: 0x0026D5A9 File Offset: 0x0026B9A9
		public void ResetItemData()
		{
			this.ItemId = 0;
			this.StrengthLevel = 0;
			this.OnShelfPrice = 0;
		}

		// Token: 0x040062B5 RID: 25269
		public int ItemId;

		// Token: 0x040062B6 RID: 25270
		public int StrengthLevel;

		// Token: 0x040062B7 RID: 25271
		public int OnShelfPrice;
	}
}
