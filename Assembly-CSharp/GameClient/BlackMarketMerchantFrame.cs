using System;
using Protocol;

namespace GameClient
{
	// Token: 0x02001A37 RID: 6711
	public class BlackMarketMerchantFrame : ClientFrame
	{
		// Token: 0x060107D1 RID: 67537 RVA: 0x004A4D29 File Offset: 0x004A3129
		protected sealed override void _bindExUI()
		{
			this.mBlackMarketMerchantFrame = this.mBind.GetCom<BlackMarketMerchantView>("BlackMarketMerchantFrame");
		}

		// Token: 0x060107D2 RID: 67538 RVA: 0x004A4D41 File Offset: 0x004A3141
		protected sealed override void _unbindExUI()
		{
			this.mBlackMarketMerchantFrame = null;
		}

		// Token: 0x060107D3 RID: 67539 RVA: 0x004A4D4A File Offset: 0x004A314A
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/BlackMarketMerchantFrame/BlackMarketMerchantFrame";
		}

		// Token: 0x060107D4 RID: 67540 RVA: 0x004A4D51 File Offset: 0x004A3151
		protected sealed override void _OnOpenFrame()
		{
			this.RegisterEvent();
			DataManager<BlackMarketMerchantDataManager>.GetInstance().OnSendWorldBlackMarketAuctionListReq();
		}

		// Token: 0x060107D5 RID: 67541 RVA: 0x004A4D64 File Offset: 0x004A3164
		private void RegisterEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BlackMarketMerchanRetSuccess, new ClientEventSystem.UIEventHandler(this.OnBlackMarketMerchanRetSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BlackMarketMerchantItemUpdate, new ClientEventSystem.UIEventHandler(this.OnBlackMarketMerchantItemUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SyncBlackMarketMerchantNPCType, new ClientEventSystem.UIEventHandler(this.OnSyncBlackMarketMerchantNPCType));
		}

		// Token: 0x060107D6 RID: 67542 RVA: 0x004A4DC4 File Offset: 0x004A31C4
		private void UnRegisterEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BlackMarketMerchanRetSuccess, new ClientEventSystem.UIEventHandler(this.OnBlackMarketMerchanRetSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BlackMarketMerchantItemUpdate, new ClientEventSystem.UIEventHandler(this.OnBlackMarketMerchantItemUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SyncBlackMarketMerchantNPCType, new ClientEventSystem.UIEventHandler(this.OnSyncBlackMarketMerchantNPCType));
		}

		// Token: 0x060107D7 RID: 67543 RVA: 0x004A4E22 File Offset: 0x004A3222
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.mDataModel = null;
			this.UnRegisterEvent();
		}

		// Token: 0x060107D8 RID: 67544 RVA: 0x004A4E38 File Offset: 0x004A3238
		private void OnBlackMarketMerchanRetSuccess(UIEvent uiEvent)
		{
			this.mDataModel = DataManager<BlackMarketMerchantDataManager>.GetInstance().GetBlackMarketMerchantDataModel();
			if (this.mDataModel != null)
			{
				this.mBlackMarketMerchantFrame.InitView(this.mDataModel, new OnApplyTradDelegate(this.OnApplyTradDelegate), new OnCancelApplyDelegate(this.OnCancelApplyDelegate));
			}
		}

		// Token: 0x060107D9 RID: 67545 RVA: 0x004A4E89 File Offset: 0x004A3289
		private void OnBlackMarketMerchantItemUpdate(UIEvent uiEvent)
		{
			this.mDataModel = DataManager<BlackMarketMerchantDataManager>.GetInstance().GetBlackMarketMerchantDataModel();
			if (this.mDataModel != null)
			{
				this.mBlackMarketMerchantFrame.RefreshItemInfoList(this.mDataModel);
			}
		}

		// Token: 0x060107DA RID: 67546 RVA: 0x004A4EB7 File Offset: 0x004A32B7
		private void OnSyncBlackMarketMerchantNPCType(UIEvent uiEvent)
		{
			if (BlackMarketMerchantDataManager.BlackMarketType == BlackMarketType.BmtInvalid)
			{
				base.Close(false);
			}
		}

		// Token: 0x060107DB RID: 67547 RVA: 0x004A4ECA File Offset: 0x004A32CA
		private void OnApplyTradDelegate(ApplyTradData data)
		{
			if (data == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BlackMarketMerchantTradeFrame>(FrameLayer.Middle, data, string.Empty);
		}

		// Token: 0x060107DC RID: 67548 RVA: 0x004A4EE5 File Offset: 0x004A32E5
		private void OnCancelApplyDelegate(BlackMarketAuctionInfo info)
		{
			if (info == null)
			{
				return;
			}
			DataManager<BlackMarketMerchantDataManager>.GetInstance().OnSendWorldBlackMarketAuctionCancelReq(info.guid);
		}

		// Token: 0x0400A7A1 RID: 42913
		private BlackMarketMerchantView mBlackMarketMerchantFrame;

		// Token: 0x0400A7A2 RID: 42914
		private BlackMarketMerchantDataModel mDataModel;
	}
}
