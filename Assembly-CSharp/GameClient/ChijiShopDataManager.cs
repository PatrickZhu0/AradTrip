using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001119 RID: 4377
	public class ChijiShopDataManager : DataManager<ChijiShopDataManager>
	{
		// Token: 0x0600A611 RID: 42513 RVA: 0x00226C2C File Offset: 0x0022502C
		public override void Initialize()
		{
			this.BindNetEvents();
		}

		// Token: 0x0600A612 RID: 42514 RVA: 0x00226C34 File Offset: 0x00225034
		public override void Clear()
		{
			this.UnBindNetEvents();
			this.ResetChijiShopData();
		}

		// Token: 0x0600A613 RID: 42515 RVA: 0x00226C42 File Offset: 0x00225042
		public void ResetChijiShopData()
		{
			this.ChijiShopItemIdList.Clear();
			this.ChijiAlreadyBuyShopItemIdList.Clear();
			this.ChijiShopRefreshTimeStamp = 0;
			this.ChijiShopRefreshCostValue = 0;
			this.ChijiShopId = 0;
		}

		// Token: 0x0600A614 RID: 42516 RVA: 0x00226C70 File Offset: 0x00225070
		private void BindNetEvents()
		{
			NetProcess.AddMsgHandler(500923U, new Action<MsgDATA>(this.OnReceiveSceneShopQueryRet));
			NetProcess.AddMsgHandler(500926U, new Action<MsgDATA>(this.OnReceiveSceneShopSync));
			NetProcess.AddMsgHandler(500933U, new Action<MsgDATA>(this.OnReceiveSceneShopRefreshRet));
			NetProcess.AddMsgHandler(500925U, new Action<MsgDATA>(this.OnReceiveSceneShopBuyRet));
		}

		// Token: 0x0600A615 RID: 42517 RVA: 0x00226CD8 File Offset: 0x002250D8
		private void UnBindNetEvents()
		{
			NetProcess.RemoveMsgHandler(500923U, new Action<MsgDATA>(this.OnReceiveSceneShopQueryRet));
			NetProcess.RemoveMsgHandler(500926U, new Action<MsgDATA>(this.OnReceiveSceneShopSync));
			NetProcess.RemoveMsgHandler(500933U, new Action<MsgDATA>(this.OnReceiveSceneShopRefreshRet));
			NetProcess.RemoveMsgHandler(500925U, new Action<MsgDATA>(this.OnReceiveSceneShopBuyRet));
		}

		// Token: 0x0600A616 RID: 42518 RVA: 0x00226D40 File Offset: 0x00225140
		public void OnSendSceneShopQueryReq(int shopId = 0)
		{
			SceneShopQuery sceneShopQuery = new SceneShopQuery();
			sceneShopQuery.shopId = (byte)shopId;
			sceneShopQuery.cache = 0;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneShopQuery>(ServerType.GATE_SERVER, sceneShopQuery);
			}
		}

		// Token: 0x0600A617 RID: 42519 RVA: 0x00226D80 File Offset: 0x00225180
		private void OnReceiveSceneShopQueryRet(MsgDATA msgData)
		{
			if (!CommonUtility.IsInGameBattleScene())
			{
				return;
			}
			if (msgData == null)
			{
				return;
			}
			SceneShopQueryRet sceneShopQueryRet = new SceneShopQueryRet();
			sceneShopQueryRet.decode(msgData.bytes);
			if (sceneShopQueryRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneShopQueryRet.code, string.Empty);
				return;
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveSceneShopQuerySucceed, null, null, null, null);
		}

		// Token: 0x0600A618 RID: 42520 RVA: 0x00226DE0 File Offset: 0x002251E0
		public void OnSendSceneShopRefreshReq(int shopId)
		{
			SceneShopRefresh sceneShopRefresh = new SceneShopRefresh();
			sceneShopRefresh.shopId = (byte)shopId;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneShopRefresh>(ServerType.GATE_SERVER, sceneShopRefresh);
			}
		}

		// Token: 0x0600A619 RID: 42521 RVA: 0x00226E18 File Offset: 0x00225218
		private void OnReceiveSceneShopRefreshRet(MsgDATA msgData)
		{
			if (!CommonUtility.IsInGameBattleScene())
			{
				return;
			}
			if (msgData == null)
			{
				return;
			}
			SceneShopRefreshRet sceneShopRefreshRet = new SceneShopRefreshRet();
			sceneShopRefreshRet.decode(msgData.bytes);
			if (sceneShopRefreshRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneShopRefreshRet.code, string.Empty);
			}
			else
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveSceneShopRefreshSucceed, null, null, null, null);
			}
		}

		// Token: 0x0600A61A RID: 42522 RVA: 0x00226E7C File Offset: 0x0022527C
		private void OnReceiveSceneShopSync(MsgDATA msg)
		{
			if (!CommonUtility.IsInGameBattleScene())
			{
				return;
			}
			if (msg == null)
			{
				return;
			}
			int num = 0;
			CustomDecoder.ProtoShop protoShop;
			if (!CustomDecoder.DecodeShop(out protoShop, msg.bytes, ref num, msg.bytes.Length))
			{
				Logger.LogErrorFormat("Open ShopNewFrame OnSyncShopItem Decode is error", new object[0]);
				return;
			}
			if (protoShop == null)
			{
				Logger.LogErrorFormat("Open ShopNewFrame OnSyncShopItem Decode msgRet is null", new object[0]);
				return;
			}
			this.ChijiShopId = (int)protoShop.shopID;
			this.ChijiShopRefreshCostValue = (int)protoShop.refreshCost;
			this.ChijiShopRefreshTimeStamp = (int)protoShop.restRefreshTime;
			this.ChijiShopItemIdList.Clear();
			this.ChijiAlreadyBuyShopItemIdList.Clear();
			for (int i = 0; i < protoShop.shopItemList.Count; i++)
			{
				CustomDecoder.ProtoShopItem protoShopItem = protoShop.shopItemList[i];
				int shopItemId = (int)protoShopItem.shopItemId;
				if (Singleton<TableManager>.GetInstance().GetTableItem<ChiJiShopItemTable>(shopItemId, string.Empty, string.Empty) != null)
				{
					this.ChijiShopItemIdList.Add(shopItemId);
				}
			}
		}

		// Token: 0x0600A61B RID: 42523 RVA: 0x00226F80 File Offset: 0x00225380
		public void OnSendBuyShopItemReq(int shopId, int shopItemId)
		{
			SceneShopBuy sceneShopBuy = new SceneShopBuy();
			sceneShopBuy.shopId = (byte)shopId;
			sceneShopBuy.shopItemId = (uint)shopItemId;
			sceneShopBuy.num = 1;
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneShopBuy>(ServerType.GATE_SERVER, sceneShopBuy);
			}
		}

		// Token: 0x0600A61C RID: 42524 RVA: 0x00226FC4 File Offset: 0x002253C4
		private void OnReceiveSceneShopBuyRet(MsgDATA msgData)
		{
			if (!CommonUtility.IsInGameBattleScene())
			{
				return;
			}
			if (msgData == null)
			{
				return;
			}
			SceneShopBuyRet sceneShopBuyRet = new SceneShopBuyRet();
			sceneShopBuyRet.decode(msgData.bytes);
			if (sceneShopBuyRet.code != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneShopBuyRet.code, string.Empty);
			}
			else
			{
				this.ChijiAlreadyBuyShopItemIdList.Add((int)sceneShopBuyRet.shopItemId);
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveSceneShopItemBuySucceed, (int)sceneShopBuyRet.shopItemId, null, null, null);
			}
		}

		// Token: 0x04005CDD RID: 23773
		public const string GloryCoinCounterStr = "chi_ji_shop_coin";

		// Token: 0x04005CDE RID: 23774
		public const int GloryCoinId = 402000005;

		// Token: 0x04005CDF RID: 23775
		public int ChijiShopRefreshTimeStamp;

		// Token: 0x04005CE0 RID: 23776
		public int ChijiShopRefreshCostValue;

		// Token: 0x04005CE1 RID: 23777
		public int ChijiShopId;

		// Token: 0x04005CE2 RID: 23778
		public List<int> ChijiShopItemIdList = new List<int>();

		// Token: 0x04005CE3 RID: 23779
		public List<int> ChijiAlreadyBuyShopItemIdList = new List<int>();
	}
}
