using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x020012A8 RID: 4776
	public class MailDataModel
	{
		// Token: 0x040067A7 RID: 26535
		public MailTitleInfo info;

		// Token: 0x040067A8 RID: 26536
		public string content;

		// Token: 0x040067A9 RID: 26537
		public List<ItemReward> items = new List<ItemReward>();

		// Token: 0x040067AA RID: 26538
		public List<Item> detailItems = new List<Item>();
	}
}
