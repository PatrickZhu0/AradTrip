using System;

namespace GameClient
{
	// Token: 0x02001A6A RID: 6762
	public class AccountShopFrame : ClientFrame
	{
		// Token: 0x06010991 RID: 67985 RVA: 0x004B16F6 File Offset: 0x004AFAF6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ShopNew/AccountShopFrame";
		}

		// Token: 0x06010992 RID: 67986 RVA: 0x004B1700 File Offset: 0x004AFB00
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			ShopNewParamData shopNewParamData = this.userData as ShopNewParamData;
			if (shopNewParamData == null)
			{
				return;
			}
			this._InitFrameData(shopNewParamData);
		}

		// Token: 0x06010993 RID: 67987 RVA: 0x004B1733 File Offset: 0x004AFB33
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x06010994 RID: 67988 RVA: 0x004B1738 File Offset: 0x004AFB38
		private void _InitFrameData(ShopNewParamData paramData)
		{
			if (paramData == null)
			{
				Logger.LogError("[AccountShopFrame] - InitFrameData failed, ShopNewParamData is null");
				return;
			}
			ShopNewFrameViewData shopNewFrameViewData = new ShopNewFrameViewData();
			shopNewFrameViewData.shopId = paramData.ShopId;
			shopNewFrameViewData.defaultSelectedTabData.MainTabType = ShopNewMainTabType.ShopType;
			shopNewFrameViewData.defaultSelectedTabData.Index = paramData.ShopId;
			shopNewFrameViewData.npcId = paramData.NpcId;
			if (paramData.ShopChildId > 0)
			{
				shopNewFrameViewData.defaultSelectedTabData.MainTabType = ShopNewMainTabType.ShopType;
				shopNewFrameViewData.defaultSelectedTabData.Index = paramData.ShopChildId;
			}
			else if (paramData.ShopItemType > 0)
			{
				shopNewFrameViewData.defaultSelectedTabData.MainTabType = ShopNewMainTabType.ItemType;
				shopNewFrameViewData.defaultSelectedTabData.Index = paramData.ShopItemType;
			}
			if (this.mAccountShopView != null)
			{
				this.mAccountShopView.InitShopView(shopNewFrameViewData);
			}
		}

		// Token: 0x06010995 RID: 67989 RVA: 0x004B1805 File Offset: 0x004AFC05
		protected override void _bindExUI()
		{
			this.mAccountShopView = this.mBind.GetCom<AccountShopView>("AccountShopView");
		}

		// Token: 0x06010996 RID: 67990 RVA: 0x004B181D File Offset: 0x004AFC1D
		protected override void _unbindExUI()
		{
			this.mAccountShopView = null;
		}

		// Token: 0x0400A95C RID: 43356
		private AccountShopView mAccountShopView;
	}
}
