using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x020018E9 RID: 6377
	public interface IDailyRewardGiftItem : IDisposable
	{
		// Token: 0x0600F8D8 RID: 63704
		void Init(List<DailyRewardDetailData> giftList);
	}
}
