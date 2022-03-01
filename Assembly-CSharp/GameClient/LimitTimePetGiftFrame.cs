using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200173C RID: 5948
	public class LimitTimePetGiftFrame : ClientFrame
	{
		// Token: 0x0600E9C0 RID: 59840 RVA: 0x003DE65F File Offset: 0x003DCA5F
		protected sealed override void _bindExUI()
		{
			this.mLimitTimePetGiftFrame = this.mBind.GetCom<LimitTimePetGiftFrameView>("LimitTimePetGiftFrame");
		}

		// Token: 0x0600E9C1 RID: 59841 RVA: 0x003DE677 File Offset: 0x003DCA77
		protected sealed override void _unbindExUI()
		{
			this.mLimitTimePetGiftFrame = null;
		}

		// Token: 0x0600E9C2 RID: 59842 RVA: 0x003DE680 File Offset: 0x003DCA80
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/LimitTimePetGiftFrame";
		}

		// Token: 0x0600E9C3 RID: 59843 RVA: 0x003DE688 File Offset: 0x003DCA88
		protected sealed override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.data = (List<MallItemInfo>)this.userData;
			if (this.data != null && this.mLimitTimePetGiftFrame != null)
			{
				this.mLimitTimePetGiftFrame.InitData(this.data, new OnBuyClickDelegate(this.OnBuyClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldBuyPetSucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldBuyPetSucceed));
		}

		// Token: 0x0600E9C4 RID: 59844 RVA: 0x003DE700 File Offset: 0x003DCB00
		protected sealed override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.data = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldBuyPetSucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldBuyPetSucceed));
			DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(9, 0, 0);
		}

		// Token: 0x0600E9C5 RID: 59845 RVA: 0x003DE738 File Offset: 0x003DCB38
		private void OnSyncWorldBuyPetSucceed(UIEvent uiEvent)
		{
			List<MallItemInfo> list = uiEvent.Param1 as List<MallItemInfo>;
			if (list != null && this.mLimitTimePetGiftFrame != null)
			{
				this.mLimitTimePetGiftFrame.RefreshItemInfo(list);
			}
		}

		// Token: 0x0600E9C6 RID: 59846 RVA: 0x003DE774 File Offset: 0x003DCB74
		private void OnMallShopClick()
		{
			if (Singleton<ClientSystemManager>.instance.IsFrameOpen<MallNewFrame>(null))
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<MallNewFrame>(null, false);
			}
			DataManager<MallNewDataManager>.GetInstance().SendWorldMallQueryItemReq(9, 0, 0);
			Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
			{
				MallNewType = MallNewType.LimitTimeMall
			}, string.Empty);
			this.frameMgr.CloseFrame<LimitTimePetGiftFrame>(this, false);
		}

		// Token: 0x0600E9C7 RID: 59847 RVA: 0x003DE7D8 File Offset: 0x003DCBD8
		private void OnBuyClick(MallItemInfo info)
		{
			if (info == null)
			{
				return;
			}
			if ((info.moneytype == 28 || info.moneytype == 18) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType((ItemTable.eSubType)info.moneytype);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(costInfo.nMoneyID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("道具id为{0}的货币", new object[]
				{
					costInfo.nMoneyID
				});
				return;
			}
			string name = tableItem.Name;
			costInfo.nCount = (int)info.discountprice;
			SystemNotifyManager.SysNotifyMsgBoxCancelOk(string.Format(TR.Value("pet_limittime_buy_tips"), costInfo.nCount, name), null, delegate()
			{
				DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
				{
					WorldMallBuy worldMallBuy = new WorldMallBuy();
					worldMallBuy.itemId = info.id;
					worldMallBuy.num = 1;
					NetManager netManager = NetManager.Instance();
					netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
				}, "common_money_cost", null);
			}, 0f, false, null);
		}

		// Token: 0x04008DC8 RID: 36296
		private List<MallItemInfo> data;

		// Token: 0x04008DC9 RID: 36297
		private LimitTimePetGiftFrameView mLimitTimePetGiftFrame;

		// Token: 0x04008DCA RID: 36298
		private const int MallTypeTableId = 9;
	}
}
