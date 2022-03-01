using System;

namespace GameClient
{
	// Token: 0x020016DA RID: 5850
	internal class TipItemTwoLabels : TipItem
	{
		// Token: 0x0600E53A RID: 58682 RVA: 0x003B8FEE File Offset: 0x003B73EE
		public TipItemTwoLabels(string leftContent, string rightContent)
		{
			this.Type = ETipItemType.HTwoLabels;
			this.LeftContent = leftContent;
			this.RightContent = rightContent;
		}

		// Token: 0x04008ABC RID: 35516
		public string LeftContent;

		// Token: 0x04008ABD RID: 35517
		public string RightContent;
	}
}
