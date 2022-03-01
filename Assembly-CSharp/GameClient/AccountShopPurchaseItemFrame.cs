using System;

namespace GameClient
{
	// Token: 0x02001A6B RID: 6763
	public class AccountShopPurchaseItemFrame : ClientFrame
	{
		// Token: 0x06010998 RID: 67992 RVA: 0x004B182E File Offset: 0x004AFC2E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ShopNew/AccountShopPurchaseItemFrame";
		}

		// Token: 0x06010999 RID: 67993 RVA: 0x004B1838 File Offset: 0x004AFC38
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			AccountShopPurchaseItemInfo accShopItemInfo = this.userData as AccountShopPurchaseItemInfo;
			if (this.mAccShopPurchaseItemView != null)
			{
				this.mAccShopPurchaseItemView.InitShop(accShopItemInfo);
			}
		}

		// Token: 0x0601099A RID: 67994 RVA: 0x004B1874 File Offset: 0x004AFC74
		protected override void _bindExUI()
		{
			this.mAccShopPurchaseItemView = this.mBind.GetCom<AccountShopPurchaseItemView>("AccShopPurchaseItemView");
		}

		// Token: 0x0601099B RID: 67995 RVA: 0x004B188C File Offset: 0x004AFC8C
		protected override void _unbindExUI()
		{
			this.mAccShopPurchaseItemView = null;
		}

		// Token: 0x0400A95D RID: 43357
		private AccountShopPurchaseItemView mAccShopPurchaseItemView;
	}
}
