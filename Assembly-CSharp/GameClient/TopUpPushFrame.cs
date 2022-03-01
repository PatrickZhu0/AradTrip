using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001CB8 RID: 7352
	public class TopUpPushFrame : ClientFrame
	{
		// Token: 0x060120A4 RID: 73892 RVA: 0x005470B8 File Offset: 0x005454B8
		protected sealed override void _bindExUI()
		{
			this.mTopUpPushView = this.mBind.GetCom<TopUpPushView>("TopUpPushView");
		}

		// Token: 0x060120A5 RID: 73893 RVA: 0x005470D0 File Offset: 0x005454D0
		protected sealed override void _unbindExUI()
		{
			this.mTopUpPushView = null;
		}

		// Token: 0x060120A6 RID: 73894 RVA: 0x005470D9 File Offset: 0x005454D9
		public sealed override string GetPrefabPath()
		{
			return this.mPrefabPath;
		}

		// Token: 0x060120A7 RID: 73895 RVA: 0x005470E4 File Offset: 0x005454E4
		protected sealed override void _OnOpenFrame()
		{
			TopUpPushDataModel topUpPushDataModel = DataManager<TopUpPushDataManager>.GetInstance().GetTopUpPushDataModel();
			if (this.mTopUpPushView != null)
			{
				this.mTopUpPushView.InitView(topUpPushDataModel, new OnBuyClick(this.OnBuyClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.TopUpPushBuySuccess, new ClientEventSystem.UIEventHandler(this.OnTopUpPushBuySuccess));
		}

		// Token: 0x060120A8 RID: 73896 RVA: 0x00547140 File Offset: 0x00545540
		protected sealed override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.TopUpPushBuySuccess, new ClientEventSystem.UIEventHandler(this.OnTopUpPushBuySuccess));
			DataManager<FollowingOpenQueueManager>.GetInstance().NotifyCurrentOrderClosed();
		}

		// Token: 0x060120A9 RID: 73897 RVA: 0x00547168 File Offset: 0x00545568
		private void OnTopUpPushBuySuccess(UIEvent uiEvent)
		{
			TopUpPushDataModel topUpPushDataModel = DataManager<TopUpPushDataManager>.GetInstance().GetTopUpPushDataModel();
			if (this.mTopUpPushView != null)
			{
				this.mTopUpPushView.RefreshItems(topUpPushDataModel);
			}
		}

		// Token: 0x060120AA RID: 73898 RVA: 0x005471A0 File Offset: 0x005455A0
		private void OnBuyClick(TopUpPushItemData pushItemData)
		{
			if (pushItemData == null)
			{
				Logger.LogErrorFormat("选中购买的道具数据为Null", new object[0]);
				return;
			}
			int num = pushItemData.maxTimes - pushItemData.buyTimes;
			if (num <= 0)
			{
				return;
			}
			int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT);
			int disCountPrice = pushItemData.disCountPrice;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
			{
				nMoneyID = moneyIDByType,
				nCount = disCountPrice
			}, delegate
			{
				DataManager<TopUpPushDataManager>.GetInstance().OnSendWorldBuyRechargePushItemsReq(pushItemData.pushId);
			}, "common_money_cost", null);
		}

		// Token: 0x0400BC1A RID: 48154
		private string mPrefabPath = "UIFlatten/Prefabs/TopUpPushFrame/TopUpPushFrame";

		// Token: 0x0400BC1B RID: 48155
		private TopUpPushView mTopUpPushView;
	}
}
