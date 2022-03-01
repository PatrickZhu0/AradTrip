using System;

namespace GameClient
{
	// Token: 0x02001662 RID: 5730
	internal class GuildStoreShopFrame : ClientFrame
	{
		// Token: 0x0600E154 RID: 57684 RVA: 0x0039C4B9 File Offset: 0x0039A8B9
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildStoreShopFrame";
		}

		// Token: 0x0600E155 RID: 57685 RVA: 0x0039C4C0 File Offset: 0x0039A8C0
		private void OnOpenChildShopFrame(int iShopID, ShopFrame child, int iId)
		{
			if (this.m_iShopFrameId != iId)
			{
				return;
			}
			this.shopFrame = child;
		}

		// Token: 0x0600E156 RID: 57686 RVA: 0x0039C4D8 File Offset: 0x0039A8D8
		protected override void _OnOpenFrame()
		{
			this.m_iShopFrameId = DataManager<ShopDataManager>.GetInstance().RegisterMainFrame();
			ShopDataManager instance = DataManager<ShopDataManager>.GetInstance();
			instance.onOpenChildShopFrame = (ShopDataManager.OnOpenChildShopFrame)Delegate.Combine(instance.onOpenChildShopFrame, new ShopDataManager.OnOpenChildShopFrame(this.OnOpenChildShopFrame));
			DataManager<ShopDataManager>.GetInstance().OpenShop(11, 0, -1, null, this.frame, ShopFrame.ShopFrameMode.SFM_GUILD_CHILD_FRAME, this.m_iShopFrameId, -1);
		}

		// Token: 0x0600E157 RID: 57687 RVA: 0x0039C538 File Offset: 0x0039A938
		protected override void _OnCloseFrame()
		{
			DataManager<ShopDataManager>.GetInstance().UnRegisterMainFrame(this.m_iShopFrameId);
			ShopDataManager instance = DataManager<ShopDataManager>.GetInstance();
			instance.onOpenChildShopFrame = (ShopDataManager.OnOpenChildShopFrame)Delegate.Remove(instance.onOpenChildShopFrame, new ShopDataManager.OnOpenChildShopFrame(this.OnOpenChildShopFrame));
			if (this.shopFrame != null)
			{
				this.shopFrame.Close(true);
				this.shopFrame = null;
			}
		}

		// Token: 0x0400861A RID: 34330
		private ShopFrame shopFrame;

		// Token: 0x0400861B RID: 34331
		private int m_iShopFrameId;
	}
}
