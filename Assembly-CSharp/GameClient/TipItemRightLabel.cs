using System;

namespace GameClient
{
	// Token: 0x020016DC RID: 5852
	internal class TipItemRightLabel : TipItem
	{
		// Token: 0x0600E53C RID: 58684 RVA: 0x003B9021 File Offset: 0x003B7421
		public TipItemRightLabel(string content)
		{
			this.Type = ETipItemType.RightLabel;
			this.Content = content;
		}

		// Token: 0x04008ABF RID: 35519
		public string Content;
	}
}
