using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020016DF RID: 5855
	internal class TipItemGroup : TipItem
	{
		// Token: 0x0600E53F RID: 58687 RVA: 0x003B90BD File Offset: 0x003B74BD
		public TipItemGroup()
		{
			this.Type = ETipItemType.Group;
		}

		// Token: 0x04008AC1 RID: 35521
		public List<TipItem> itemList = new List<TipItem>();
	}
}
