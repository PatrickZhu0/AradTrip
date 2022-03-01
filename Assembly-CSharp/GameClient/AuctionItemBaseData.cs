using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x0200144F RID: 5199
	public struct AuctionItemBaseData
	{
		// Token: 0x04007481 RID: 29825
		public int JobID;

		// Token: 0x04007482 RID: 29826
		public int iFirstIndex;

		// Token: 0x04007483 RID: 29827
		public int iSecondIndex;

		// Token: 0x04007484 RID: 29828
		public List<AuctionItemBaseInfo> itembaseinfoList;
	}
}
