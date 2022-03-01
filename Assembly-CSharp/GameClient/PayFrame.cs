using System;
using System.Collections.Generic;
using Network;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001953 RID: 6483
	public class PayFrame
	{
		// Token: 0x0600FBFF RID: 64511 RVA: 0x0045296C File Offset: 0x00450D6C
		public PayFrame(GameObject root, GameObject scrollRoot)
		{
			this.goScrollContent = scrollRoot;
			this.root = root;
		}

		// Token: 0x0600FC00 RID: 64512 RVA: 0x00452982 File Offset: 0x00450D82
		public void Open()
		{
			this.isOpened = true;
			Singleton<PluginManager>.GetInstance().TryGetIOSAppstoreProductIds();
			this.SendPayItemReq();
			this.Bind();
			this.Show(true);
		}

		// Token: 0x0600FC01 RID: 64513 RVA: 0x004529A8 File Offset: 0x00450DA8
		public void Close()
		{
			if (this.isOpened)
			{
				this.UnBind();
				if (this.payItems != null)
				{
					this.payItems.Clear();
					this.payItems = null;
				}
			}
		}

		// Token: 0x0600FC02 RID: 64514 RVA: 0x004529D8 File Offset: 0x00450DD8
		public void Show(bool show)
		{
			this.root.CustomActive(show);
		}

		// Token: 0x0600FC03 RID: 64515 RVA: 0x004529E6 File Offset: 0x00450DE6
		private void Bind()
		{
			NetProcess.AddMsgHandler(604008U, new Action<MsgDATA>(this.OnReceivePayItem));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnReceivePayResult));
		}

		// Token: 0x0600FC04 RID: 64516 RVA: 0x00452A19 File Offset: 0x00450E19
		private void UnBind()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnReceivePayResult));
			NetProcess.RemoveMsgHandler(604008U, new Action<MsgDATA>(this.OnReceivePayItem));
		}

		// Token: 0x0600FC05 RID: 64517 RVA: 0x00452A4C File Offset: 0x00450E4C
		private void SendPayItemReq()
		{
			WorldBillingGoodsReq cmd = new WorldBillingGoodsReq();
			NetManager.Instance().SendCommand<WorldBillingGoodsReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600FC06 RID: 64518 RVA: 0x00452A6C File Offset: 0x00450E6C
		private void OnReceivePayItem(MsgDATA msg)
		{
			WorldBillingGoodsRes worldBillingGoodsRes = new WorldBillingGoodsRes();
			worldBillingGoodsRes.decode(msg.bytes);
			PayItemData[] array = new PayItemData[worldBillingGoodsRes.goods.Length];
			for (int i = 0; i < worldBillingGoodsRes.goods.Length; i++)
			{
				ChargeGoods good = worldBillingGoodsRes.goods[i];
				PayItemData payItemData = new PayItemData(good);
				array[i] = payItemData;
			}
			if (this.payItems != null)
			{
				this.UpdatePayItems(array);
			}
			else
			{
				this.CreatePayItems(array);
			}
		}

		// Token: 0x0600FC07 RID: 64519 RVA: 0x00452AE8 File Offset: 0x00450EE8
		private void OnReceivePayResult(UIEvent uiEvent)
		{
			string a = (string)uiEvent.Param1;
			if (a == "0")
			{
				if (Singleton<PayManager>.GetInstance().lastPayIsMonthCard)
				{
					SystemNotifyManager.SystemNotify(1202, string.Empty);
					if (Singleton<PayManager>.GetInstance().lastMontchCardNeedOpenWindow)
					{
						this.OpenMonthCard();
					}
				}
				else
				{
					SystemNotifyManager.SystemNotify(2600001, string.Empty);
				}
			}
			else if (a == "1")
			{
				SystemNotifyManager.SystemNotify(2600002, string.Empty);
			}
			this.SendPayItemReq();
		}

		// Token: 0x0600FC08 RID: 64520 RVA: 0x00452B82 File Offset: 0x00450F82
		private void OpenMonthCard()
		{
			DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 6000);
		}

		// Token: 0x0600FC09 RID: 64521 RVA: 0x00452B98 File Offset: 0x00450F98
		private void CreatePayItems(PayItemData[] datas)
		{
			if (this.payItems == null)
			{
				this.payItems = new List<PayItem>();
			}
			for (int i = 1; i < datas.Length; i++)
			{
				PayItem item = new PayItem(datas[i], this.goScrollContent);
				this.payItems.Add(item);
			}
		}

		// Token: 0x0600FC0A RID: 64522 RVA: 0x00452BEC File Offset: 0x00450FEC
		private void UpdatePayItems(PayItemData[] datas)
		{
			for (int i = 0; i < this.payItems.Count; i++)
			{
				PayItem payItem = this.payItems[i];
				for (int j = 0; j < datas.Length; j++)
				{
					if (payItem.data.ID == datas[j].ID)
					{
						payItem.UpdateData(datas[j]);
					}
				}
			}
		}

		// Token: 0x04009DC8 RID: 40392
		private List<PayItem> payItems;

		// Token: 0x04009DC9 RID: 40393
		private GameObject goScrollContent;

		// Token: 0x04009DCA RID: 40394
		private GameObject root;

		// Token: 0x04009DCB RID: 40395
		public bool isOpened;
	}
}
