using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200121F RID: 4639
	public class CoinDealMyOrderDataModel
	{
		// Token: 0x0400644E RID: 25678
		public GoldConsignmentOrderType OrderType;

		// Token: 0x0400644F RID: 25679
		public ulong OrderId;

		// Token: 0x04006450 RID: 25680
		public ulong RoleId;

		// Token: 0x04006451 RID: 25681
		public uint SinglePrice;

		// Token: 0x04006452 RID: 25682
		public uint DealCoinNumber;

		// Token: 0x04006453 RID: 25683
		public uint SubmitTimeStamp;

		// Token: 0x04006454 RID: 25684
		public uint ExpireTimeStamp;
	}
}
