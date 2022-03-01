using System;

namespace GameClient
{
	// Token: 0x02001A87 RID: 6791
	public class ShopNewPurchaseItemFrame : ClientFrame
	{
		// Token: 0x06010A93 RID: 68243 RVA: 0x004B7A14 File Offset: 0x004B5E14
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ShopNew/ShopNewPurchaseItemFrame";
		}

		// Token: 0x06010A94 RID: 68244 RVA: 0x004B7A1C File Offset: 0x004B5E1C
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			ShopNewShopItemTable shopNewShopItemTable = this.userData as ShopNewShopItemTable;
			if (this.mShopNewPurchaseItemView != null)
			{
				this.mShopNewPurchaseItemView.InitShop(shopNewShopItemTable);
			}
		}

		// Token: 0x06010A95 RID: 68245 RVA: 0x004B7A58 File Offset: 0x004B5E58
		protected override void _bindExUI()
		{
			this.mShopNewPurchaseItemView = this.mBind.GetCom<ShopNewPurchaseItemView>("ShopNewPurchaseItemView");
		}

		// Token: 0x06010A96 RID: 68246 RVA: 0x004B7A70 File Offset: 0x004B5E70
		protected override void _unbindExUI()
		{
			this.mShopNewPurchaseItemView = null;
		}

		// Token: 0x0400AA38 RID: 43576
		private ShopNewPurchaseItemView mShopNewPurchaseItemView;
	}
}
