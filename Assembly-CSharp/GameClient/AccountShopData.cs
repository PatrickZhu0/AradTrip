using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020012D8 RID: 4824
	public class AccountShopData
	{
		// Token: 0x04006931 RID: 26929
		public AccountShopQueryIndex queryIndex = new AccountShopQueryIndex();

		// Token: 0x04006932 RID: 26930
		public AccountShopItemInfo[] shopItems = new AccountShopItemInfo[0];

		// Token: 0x04006933 RID: 26931
		public uint nextGroupOnSaleTime;
	}
}
