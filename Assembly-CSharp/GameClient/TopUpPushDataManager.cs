using System;
using System.Collections.Generic;
using Network;
using Protocol;

namespace GameClient
{
	// Token: 0x02001346 RID: 4934
	public class TopUpPushDataManager : DataManager<TopUpPushDataManager>
	{
		// Token: 0x17001B9A RID: 7066
		// (get) Token: 0x0600BF76 RID: 49014 RVA: 0x002D0F02 File Offset: 0x002CF302
		// (set) Token: 0x0600BF77 RID: 49015 RVA: 0x002D0F0A File Offset: 0x002CF30A
		public bool LoginTopUpPushIsOpen
		{
			get
			{
				return this.mLoginTopUpPushIsOpen;
			}
			set
			{
				this.mLoginTopUpPushIsOpen = value;
			}
		}

		// Token: 0x0600BF78 RID: 49016 RVA: 0x002D0F13 File Offset: 0x002CF313
		public sealed override EEnterGameOrder GetOrder()
		{
			return EEnterGameOrder.Default;
		}

		// Token: 0x0600BF79 RID: 49017 RVA: 0x002D0F18 File Offset: 0x002CF318
		public sealed override void Clear()
		{
			this.UnRegisterNetHandler();
			this.model = null;
			this.isUpdate = false;
			this.isSend = false;
			this.mLoginTopUpPushIsOpen = false;
			this.TimeIntrval = 0f;
			this.sendTime = 0f;
			this.senNumber = 0;
		}

		// Token: 0x0600BF7A RID: 49018 RVA: 0x002D0F64 File Offset: 0x002CF364
		public sealed override void Initialize()
		{
			this.isUpdate = false;
			this.isSend = false;
			this.RegisterNetHandler();
		}

		// Token: 0x0600BF7B RID: 49019 RVA: 0x002D0F7C File Offset: 0x002CF37C
		public sealed override void Update(float a_fTime)
		{
			this.TimeIntrval += a_fTime;
			if (this.TimeIntrval >= 3600f)
			{
				this.SendWorldGetRechargePushItemsReq();
				this.TimeIntrval = 0f;
			}
			if (this.isSend)
			{
				this.sendTime += a_fTime;
				if (this.sendTime >= 5f)
				{
					this.SendWorldGetRechargePushItemsReq();
					this.isSend = false;
					this.sendTime = 0f;
				}
			}
			if (this.isUpdate)
			{
				uint num = this.validTimesTamp - DataManager<TimeManager>.GetInstance().GetServerTime();
				if (num <= 0U)
				{
					this.isUpdate = false;
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TopUpPushButtonClose, null, null, null, null);
					if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<TopUpPushFrame>(null))
					{
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<TopUpPushFrame>(null, false);
					}
				}
			}
		}

		// Token: 0x0600BF7C RID: 49020 RVA: 0x002D1053 File Offset: 0x002CF453
		public TopUpPushDataModel GetTopUpPushDataModel()
		{
			return this.model;
		}

		// Token: 0x0600BF7D RID: 49021 RVA: 0x002D105B File Offset: 0x002CF45B
		private void RegisterNetHandler()
		{
			NetProcess.AddMsgHandler(602828U, new Action<MsgDATA>(this.OnSyncWorldGetRechargePushItemsRes));
			NetProcess.AddMsgHandler(602830U, new Action<MsgDATA>(this.OnSyncWorldBuyRechargePushItemsRes));
		}

		// Token: 0x0600BF7E RID: 49022 RVA: 0x002D1089 File Offset: 0x002CF489
		private void UnRegisterNetHandler()
		{
			NetProcess.RemoveMsgHandler(602828U, new Action<MsgDATA>(this.OnSyncWorldGetRechargePushItemsRes));
			NetProcess.RemoveMsgHandler(602830U, new Action<MsgDATA>(this.OnSyncWorldBuyRechargePushItemsRes));
		}

		// Token: 0x0600BF7F RID: 49023 RVA: 0x002D10B8 File Offset: 0x002CF4B8
		public void SendWorldGetRechargePushItemsReq()
		{
			WorldGetRechargePushItemsReq cmd = new WorldGetRechargePushItemsReq();
			NetManager.Instance().SendCommand<WorldGetRechargePushItemsReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600BF80 RID: 49024 RVA: 0x002D10D8 File Offset: 0x002CF4D8
		private void OnSyncWorldGetRechargePushItemsRes(MsgDATA msg)
		{
			WorldGetRechargePushItemsRes worldGetRechargePushItemsRes = new WorldGetRechargePushItemsRes();
			worldGetRechargePushItemsRes.decode(msg.bytes);
			if (worldGetRechargePushItemsRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldGetRechargePushItemsRes.retCode, string.Empty);
			}
			else
			{
				this.model = new TopUpPushDataModel();
				this.model.mItems = new List<TopUpPushItemData>();
				for (int i = 0; i < worldGetRechargePushItemsRes.itemVec.Length; i++)
				{
					RechargePushItem rechargePushItem = worldGetRechargePushItemsRes.itemVec[i];
					int num = (int)(rechargePushItem.validTimestamp - DataManager<TimeManager>.GetInstance().GetServerTime());
					if (num > 0)
					{
						this.model.validTimesTamp = rechargePushItem.validTimestamp;
						this.validTimesTamp = rechargePushItem.validTimestamp;
						TopUpPushItemData topUpPushItemData = new TopUpPushItemData();
						topUpPushItemData.pushId = (int)rechargePushItem.pushId;
						topUpPushItemData.itemId = (int)rechargePushItem.itemId;
						topUpPushItemData.itemCount = (int)rechargePushItem.itemCount;
						topUpPushItemData.buyTimes = (int)rechargePushItem.buyTimes;
						topUpPushItemData.maxTimes = (int)rechargePushItem.maxTimes;
						topUpPushItemData.price = (int)rechargePushItem.price;
						topUpPushItemData.disCountPrice = (int)rechargePushItem.discountPrice;
						topUpPushItemData.lastTimestamp = (int)rechargePushItem.lastTimestamp;
						this.model.mItems.Add(topUpPushItemData);
					}
				}
				if (this.model.mItems.Count > 0)
				{
					if (this.CheckItemIsAfterBuying(this.model.mItems))
					{
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TopUpPushButtonClose, null, null, null, null);
					}
					else
					{
						this.isUpdate = true;
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TopUpPushButoonOpen, null, null, null, null);
					}
				}
				this.senNumber++;
				if (this.senNumber <= 1)
				{
					this.isSend = true;
				}
			}
		}

		// Token: 0x0600BF81 RID: 49025 RVA: 0x002D1290 File Offset: 0x002CF690
		public void OnSendWorldBuyRechargePushItemsReq(int pushId)
		{
			WorldBuyRechargePushItemsReq worldBuyRechargePushItemsReq = new WorldBuyRechargePushItemsReq();
			worldBuyRechargePushItemsReq.pushId = (uint)pushId;
			NetManager.Instance().SendCommand<WorldBuyRechargePushItemsReq>(ServerType.GATE_SERVER, worldBuyRechargePushItemsReq);
		}

		// Token: 0x0600BF82 RID: 49026 RVA: 0x002D12B8 File Offset: 0x002CF6B8
		private void OnSyncWorldBuyRechargePushItemsRes(MsgDATA msg)
		{
			WorldBuyRechargePushItemsRes worldBuyRechargePushItemsRes = new WorldBuyRechargePushItemsRes();
			worldBuyRechargePushItemsRes.decode(msg.bytes);
			if (worldBuyRechargePushItemsRes.retCode != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldBuyRechargePushItemsRes.retCode, string.Empty);
			}
			else if (this.model != null && this.model.mItems != null)
			{
				this.model.mItems.Clear();
				for (int i = 0; i < worldBuyRechargePushItemsRes.itemVec.Length; i++)
				{
					RechargePushItem rechargePushItem = worldBuyRechargePushItemsRes.itemVec[i];
					int num = (int)(rechargePushItem.validTimestamp - DataManager<TimeManager>.GetInstance().GetServerTime());
					if (num > 0)
					{
						this.model.validTimesTamp = rechargePushItem.validTimestamp;
						this.validTimesTamp = rechargePushItem.validTimestamp;
						TopUpPushItemData topUpPushItemData = new TopUpPushItemData();
						topUpPushItemData.pushId = (int)rechargePushItem.pushId;
						topUpPushItemData.itemId = (int)rechargePushItem.itemId;
						topUpPushItemData.itemCount = (int)rechargePushItem.itemCount;
						topUpPushItemData.buyTimes = (int)rechargePushItem.buyTimes;
						topUpPushItemData.maxTimes = (int)rechargePushItem.maxTimes;
						topUpPushItemData.price = (int)rechargePushItem.price;
						topUpPushItemData.disCountPrice = (int)rechargePushItem.discountPrice;
						topUpPushItemData.lastTimestamp = (int)rechargePushItem.lastTimestamp;
						this.model.mItems.Add(topUpPushItemData);
					}
				}
				if (this.CheckItemIsAfterBuying(this.model.mItems))
				{
					UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TopUpPushButtonClose, null, null, null, null);
				}
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.TopUpPushBuySuccess, null, null, null, null);
			}
		}

		// Token: 0x0600BF83 RID: 49027 RVA: 0x002D143C File Offset: 0x002CF83C
		private bool CheckItemIsAfterBuying(List<TopUpPushItemData> items)
		{
			if (items == null)
			{
				return false;
			}
			int num = 0;
			for (int i = 0; i < items.Count; i++)
			{
				TopUpPushItemData topUpPushItemData = items[i];
				int num2 = topUpPushItemData.maxTimes - topUpPushItemData.buyTimes;
				if (num2 <= 0)
				{
					num++;
				}
			}
			return num == items.Count;
		}

		// Token: 0x0600BF84 RID: 49028 RVA: 0x002D14AC File Offset: 0x002CF8AC
		public bool CheckFirstLoginIsPush()
		{
			bool result = false;
			if (this.model != null && this.model.mItems != null && this.model.mItems.Count > 0)
			{
				for (int i = 0; i < this.model.mItems.Count; i++)
				{
					TopUpPushItemData topUpPushItemData = this.model.mItems[i];
					if (topUpPushItemData.lastTimestamp == 0)
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		// Token: 0x04006C05 RID: 27653
		private TopUpPushDataModel model;

		// Token: 0x04006C06 RID: 27654
		private bool isUpdate;

		// Token: 0x04006C07 RID: 27655
		private bool isSend;

		// Token: 0x04006C08 RID: 27656
		private float TimeIntrval;

		// Token: 0x04006C09 RID: 27657
		private float sendTime;

		// Token: 0x04006C0A RID: 27658
		private int senNumber;

		// Token: 0x04006C0B RID: 27659
		public uint validTimesTamp;

		// Token: 0x04006C0C RID: 27660
		private bool mLoginTopUpPushIsOpen;
	}
}
