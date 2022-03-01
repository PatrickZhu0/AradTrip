using System;
using Protocol;

namespace GameClient
{
	// Token: 0x020011CA RID: 4554
	public class AccountShopPurchaseItemInfo
	{
		// Token: 0x0600AEF4 RID: 44788 RVA: 0x00263EEC File Offset: 0x002622EC
		public AccountShopPurchaseItemInfo(uint shopId, AccountShopItemInfo accShopItemInfo)
		{
			this._shopId = shopId;
			this._itemInfo = accShopItemInfo;
		}

		// Token: 0x17001A98 RID: 6808
		// (get) Token: 0x0600AEF5 RID: 44789 RVA: 0x00263F02 File Offset: 0x00262302
		public uint ShopId
		{
			get
			{
				return this._shopId;
			}
		}

		// Token: 0x17001A99 RID: 6809
		// (get) Token: 0x0600AEF6 RID: 44790 RVA: 0x00263F0A File Offset: 0x0026230A
		public AccountShopItemInfo ItemInfo
		{
			get
			{
				if (this._itemInfo == null)
				{
					this._itemInfo = new AccountShopItemInfo();
				}
				return this._itemInfo;
			}
		}

		// Token: 0x040061D5 RID: 25045
		private uint _shopId;

		// Token: 0x040061D6 RID: 25046
		private AccountShopItemInfo _itemInfo;
	}
}
