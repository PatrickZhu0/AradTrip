using System;

namespace GameClient
{
	// Token: 0x020016DB RID: 5851
	internal class TipItemLeftLabel : TipItem
	{
		// Token: 0x0600E53B RID: 58683 RVA: 0x003B900B File Offset: 0x003B740B
		public TipItemLeftLabel(string content)
		{
			this.Type = ETipItemType.LeftLabel;
			this.Content = content;
		}

		// Token: 0x04008ABE RID: 35518
		public string Content;
	}
}
