using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001225 RID: 4645
	public class CoinDealRecordDetailDataModel
	{
		// Token: 0x04006470 RID: 25712
		public uint TimeStamp;

		// Token: 0x04006471 RID: 25713
		public uint TotalNumber;

		// Token: 0x04006472 RID: 25714
		public uint TransferNumber;

		// Token: 0x04006473 RID: 25715
		public bool IsParent;

		// Token: 0x04006474 RID: 25716
		public bool IsOwnerChild;

		// Token: 0x04006475 RID: 25717
		public bool IsAlreadyUnFold;

		// Token: 0x04006476 RID: 25718
		public List<CoinDealRecordDetailDataModel> ChildRecordDetailDataModelList = new List<CoinDealRecordDetailDataModel>();
	}
}
