using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001A76 RID: 6774
	public class GoblinShopFrame : ClientFrame
	{
		// Token: 0x06010A01 RID: 68097 RVA: 0x004B3C7B File Offset: 0x004B207B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ShopNew/GoblinShopFrame";
		}

		// Token: 0x06010A02 RID: 68098 RVA: 0x004B3C84 File Offset: 0x004B2084
		protected override void _OnOpenFrame()
		{
			this._RegisterUIEvent();
			this.thisGoblinShopData = (this.userData as GoblinShopData);
			if (this.thisGoblinShopData != null)
			{
				AccountShopQueryIndex accountShopQueryIndex = new AccountShopQueryIndex();
				accountShopQueryIndex.shopId = this.thisGoblinShopData.accountShopItem.shopId;
				accountShopQueryIndex.jobType = 0;
				accountShopQueryIndex.tabType = 0;
				DataManager<AccountShopDataManager>.GetInstance().SendWorldAccountShopItemQueryReq(accountShopQueryIndex);
			}
		}

		// Token: 0x06010A03 RID: 68099 RVA: 0x004B3CE8 File Offset: 0x004B20E8
		protected override void _OnCloseFrame()
		{
			this._UnRegisterUIEvent();
		}

		// Token: 0x06010A04 RID: 68100 RVA: 0x004B3CF0 File Offset: 0x004B20F0
		private void _RegisterUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountShopUpdate, new ClientEventSystem.UIEventHandler(this._AccountShopUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SpeicialItemUpdate, new ClientEventSystem.UIEventHandler(this._SpecialItemUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountShopItemUpdata, new ClientEventSystem.UIEventHandler(this._AccountShopItemUpdata));
		}

		// Token: 0x06010A05 RID: 68101 RVA: 0x004B3D50 File Offset: 0x004B2150
		private void _UnRegisterUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountShopUpdate, new ClientEventSystem.UIEventHandler(this._AccountShopUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SpeicialItemUpdate, new ClientEventSystem.UIEventHandler(this._SpecialItemUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountShopItemUpdata, new ClientEventSystem.UIEventHandler(this._AccountShopItemUpdata));
		}

		// Token: 0x06010A06 RID: 68102 RVA: 0x004B3DB0 File Offset: 0x004B21B0
		private void _AccountShopUpdate(UIEvent uiEvent)
		{
			AccountShopQueryIndex accountShopQueryIndex = (AccountShopQueryIndex)uiEvent.Param1;
			if (this.mGoblinShopView != null && accountShopQueryIndex.shopId == this.thisGoblinShopData.accountShopItem.shopId && accountShopQueryIndex.tabType == this.thisGoblinShopData.accountShopItem.tabType && accountShopQueryIndex.jobType == this.thisGoblinShopData.accountShopItem.jobType)
			{
				this.mGoblinShopView.InitShop(this.thisGoblinShopData);
			}
		}

		// Token: 0x06010A07 RID: 68103 RVA: 0x004B3E3C File Offset: 0x004B223C
		private void _SpecialItemUpdate(UIEvent uiEvent)
		{
			int id = (int)uiEvent.Param1;
			this.mGoblinShopView.UpdateSpecialNum(id);
			this.mGoblinShopView.UpdateShopItem(this.thisGoblinShopData.accountShopItem);
		}

		// Token: 0x06010A08 RID: 68104 RVA: 0x004B3E78 File Offset: 0x004B2278
		private void _AccountShopItemUpdata(UIEvent uiEvent)
		{
			AccountShopQueryIndex accountShopQueryIndex = (AccountShopQueryIndex)uiEvent.Param1;
			if (this.mGoblinShopView != null && accountShopQueryIndex.shopId == this.thisGoblinShopData.accountShopItem.shopId && accountShopQueryIndex.tabType == this.thisGoblinShopData.accountShopItem.tabType && accountShopQueryIndex.jobType == this.thisGoblinShopData.accountShopItem.jobType)
			{
				this.mGoblinShopView.UpdateShopItem(accountShopQueryIndex);
			}
		}

		// Token: 0x06010A09 RID: 68105 RVA: 0x004B3EFF File Offset: 0x004B22FF
		protected override void _bindExUI()
		{
			this.mGoblinShopView = this.mBind.GetCom<GoblinShopView>("GoblinShopView");
		}

		// Token: 0x06010A0A RID: 68106 RVA: 0x004B3F17 File Offset: 0x004B2317
		protected override void _unbindExUI()
		{
			this.mGoblinShopView = null;
		}

		// Token: 0x0400A9AC RID: 43436
		private GoblinShopData thisGoblinShopData;

		// Token: 0x0400A9AD RID: 43437
		private GoblinShopView mGoblinShopView;
	}
}
