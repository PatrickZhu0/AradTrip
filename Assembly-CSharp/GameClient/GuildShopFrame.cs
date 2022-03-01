using System;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001653 RID: 5715
	internal class GuildShopFrame : ClientFrame
	{
		// Token: 0x0600E0D9 RID: 57561 RVA: 0x00398B4F File Offset: 0x00396F4F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildShopFrame";
		}

		// Token: 0x0600E0DA RID: 57562 RVA: 0x00398B56 File Offset: 0x00396F56
		private void OnOpenChildShopFrame(int iShopID, ShopFrame child, int iId)
		{
			if (this.m_iShopFrameId != iId)
			{
				return;
			}
			this.shopFrame = child;
		}

		// Token: 0x0600E0DB RID: 57563 RVA: 0x00398B6C File Offset: 0x00396F6C
		protected override void _OnOpenFrame()
		{
			this.m_iShopFrameId = DataManager<ShopDataManager>.GetInstance().RegisterMainFrame();
			int nLevel = DataManager<GuildDataManager>.GetInstance().myGuild.dictBuildings[GuildBuildingType.SHOP].nLevel;
			GuildBuildingTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<GuildBuildingTable>(nLevel, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ShopDataManager instance = DataManager<ShopDataManager>.GetInstance();
				instance.onOpenChildShopFrame = (ShopDataManager.OnOpenChildShopFrame)Delegate.Combine(instance.onOpenChildShopFrame, new ShopDataManager.OnOpenChildShopFrame(this.OnOpenChildShopFrame));
				DataManager<ShopDataManager>.GetInstance().OpenShop(tableItem.ShopId, 0, -1, null, this.frame, ShopFrame.ShopFrameMode.SFM_GUILD_CHILD_FRAME, this.m_iShopFrameId, -1);
				DataManager<RedPointDataManager>.GetInstance().ClearRedPoint(ERedPoint.GuildShop);
			}
		}

		// Token: 0x0600E0DC RID: 57564 RVA: 0x00398C14 File Offset: 0x00397014
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

		// Token: 0x040085C1 RID: 34241
		private ShopFrame shopFrame;

		// Token: 0x040085C2 RID: 34242
		private int m_iShopFrameId;
	}
}
