using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200160C RID: 5644
	public class GuildDungeonAuctionItem : MonoBehaviour
	{
		// Token: 0x0600DD29 RID: 56617 RVA: 0x0037F928 File Offset: 0x0037DD28
		private void Start()
		{
			this.btnBuy.SafeSetOnClickListener(delegate
			{
				ulong guidTemp = this.guid;
				GuildDataManager.GuildAuctionItemData guildAuctionItemDataByGUID = this.GetGuildAuctionItemDataByGUID(guidTemp);
				if (guildAuctionItemDataByGUID != null && this.txtItem0Name != null && this.txtItem1Name != null)
				{
					this.PopUpCostMoneyMsgBox(TR.Value("auction_buy_now_confirm", guildAuctionItemDataByGUID.buyNowPrice, this.txtItem0Name.text, this.txtItem1Name.text), GuildDungeonAuctionItem.MoneyType.MT_POINT, guildAuctionItemDataByGUID.buyNowPrice, delegate
					{
						DataManager<GuildDataManager>.GetInstance().SendWorldGuildAuctionFixReq(guidTemp);
					});
				}
			});
			this.btnBidding.SafeSetOnClickListener(delegate
			{
				ulong guidTemp = this.guid;
				GuildDataManager.GuildAuctionItemData auctionItemDataTemp = this.GetGuildAuctionItemDataByGUID(guidTemp);
				if (auctionItemDataTemp != null)
				{
					if (auctionItemDataTemp.nextBiddingPrice >= auctionItemDataTemp.buyNowPrice)
					{
						this.PopUpCostMoneyMsgBox(TR.Value("auction_bidding_greater_than_buy_now_price", auctionItemDataTemp.buyNowPrice), GuildDungeonAuctionItem.MoneyType.MT_POINT, auctionItemDataTemp.buyNowPrice, delegate
						{
							DataManager<GuildDataManager>.GetInstance().SendWorldGuildAuctionFixReq(guidTemp);
						});
					}
					else
					{
						this.PopUpCostMoneyMsgBox(TR.Value("auction_bidding_confirm", auctionItemDataTemp.nextBiddingPrice), GuildDungeonAuctionItem.MoneyType.MT_POINT, auctionItemDataTemp.nextBiddingPrice, delegate
						{
							DataManager<GuildDataManager>.GetInstance().SendWorldGuildAuctionBidReq(guidTemp, auctionItemDataTemp.nextBiddingPrice);
						});
					}
				}
			});
		}

		// Token: 0x0600DD2A RID: 56618 RVA: 0x0037F958 File Offset: 0x0037DD58
		private void OnDestroy()
		{
		}

		// Token: 0x0600DD2B RID: 56619 RVA: 0x0037F95A File Offset: 0x0037DD5A
		private void Update()
		{
			this.UdpateItemTimeLeftOrState();
		}

		// Token: 0x0600DD2C RID: 56620 RVA: 0x0037F962 File Offset: 0x0037DD62
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().CloseAll();
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600DD2D RID: 56621 RVA: 0x0037F984 File Offset: 0x0037DD84
		private void SetComItemData(ComItem comItem, AwardItemData uIItemData)
		{
			if (comItem == null || uIItemData == null)
			{
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(uIItemData.ID, 100, 0);
			if (itemData != null)
			{
				itemData.Count = uIItemData.Num;
				comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
			}
		}

		// Token: 0x0600DD2E RID: 56622 RVA: 0x0037F9D8 File Offset: 0x0037DDD8
		private string GetColorName(AwardItemData uIItemData)
		{
			if (uIItemData == null)
			{
				return string.Empty;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(uIItemData.ID, 100, 0);
			if (itemData != null)
			{
				return itemData.GetColorName(string.Empty, false);
			}
			return string.Empty;
		}

		// Token: 0x0600DD2F RID: 56623 RVA: 0x0037FA18 File Offset: 0x0037DE18
		private void PopUpCostMoneyMsgBox(string msgContent, GuildDungeonAuctionItem.MoneyType moneyType, ulong nCount, Action action)
		{
			if (string.IsNullOrEmpty(msgContent))
			{
				return;
			}
			if (action == null)
			{
				return;
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo
				{
					nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType((ItemTable.eSubType)moneyType),
					nCount = (int)nCount
				};
				if (costInfo != null)
				{
					DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
					{
						action();
					}, "common_money_cost", null);
				}
			}, null, 0f, false);
		}

		// Token: 0x0600DD30 RID: 56624 RVA: 0x0037FA74 File Offset: 0x0037DE74
		private void UdpateItemTimeLeftOrState()
		{
			this.auctionItemData = this.GetGuildAuctionItemDataByGUID(this.guid);
			if (this.auctionItemData == null)
			{
				return;
			}
			if (this.auctionItemData.auctionItemState == GuildDataManager.AuctionItemState.Prepare)
			{
				this.txtLeftTime.CustomActive(true);
				this.txtItemState.CustomActive(false);
				this.txtLeftTime.SafeSetText(TR.Value("auction_prepare", Function.GetLeftTime((int)this.auctionItemData.statusEndStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.OnlineGift)));
			}
			else if (this.auctionItemData.auctionItemState == GuildDataManager.AuctionItemState.InAuction)
			{
				this.txtLeftTime.CustomActive(true);
				this.txtItemState.CustomActive(false);
				this.txtLeftTime.SafeSetText(Function.GetLeftTime((int)this.auctionItemData.statusEndStamp, (int)DataManager<TimeManager>.GetInstance().GetServerTime(), ShowtimeType.OnlineGift));
			}
			else if (this.auctionItemData.auctionItemState == GuildDataManager.AuctionItemState.SoldOut)
			{
				this.txtItemState.CustomActive(true);
				this.txtLeftTime.CustomActive(false);
				this.txtItemState.SafeSetText(TR.Value("auction_sold_out"));
			}
			else if (this.auctionItemData.auctionItemState == GuildDataManager.AuctionItemState.AbortiveAuction)
			{
				this.txtItemState.CustomActive(true);
				this.txtLeftTime.CustomActive(false);
				this.txtItemState.SafeSetText(TR.Value("auction_abortive"));
			}
		}

		// Token: 0x0600DD31 RID: 56625 RVA: 0x0037FBD4 File Offset: 0x0037DFD4
		private GuildDataManager.GuildAuctionItemData GetGuildAuctionItemDataByGUID(ulong GUID)
		{
			List<GuildDataManager.GuildAuctionItemData> list = null;
			if (GuildDungeonAuctionFrame.GetAuctionFrameType() == GuildDungeonAuctionFrame.FrameType.GuildAuction)
			{
				list = DataManager<GuildDataManager>.GetInstance().GetGuildAuctionItemDatasForGuildAuction();
			}
			else if (GuildDungeonAuctionFrame.GetAuctionFrameType() == GuildDungeonAuctionFrame.FrameType.WorldAuction)
			{
				list = DataManager<GuildDataManager>.GetInstance().GetGuildAuctionItemDatasForWorldAuction();
			}
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].guid == GUID)
					{
						return list[i];
					}
				}
			}
			return null;
		}

		// Token: 0x0600DD32 RID: 56626 RVA: 0x0037FC4C File Offset: 0x0037E04C
		public void SetUp(object data)
		{
			if (data == null)
			{
				return;
			}
			if (!(data is GuildDataManager.GuildAuctionItemData))
			{
				return;
			}
			GuildDataManager.GuildAuctionItemData guildAuctionItemData = data as GuildDataManager.GuildAuctionItemData;
			this.auctionItemData = guildAuctionItemData;
			this.guid = this.auctionItemData.guid;
			this.SetComItemData(this.item0, guildAuctionItemData.itemData0);
			this.SetComItemData(this.item1, guildAuctionItemData.itemData1);
			this.txtItem0Name.SafeSetText(this.GetColorName(guildAuctionItemData.itemData0));
			this.txtItem1Name.SafeSetText(this.GetColorName(guildAuctionItemData.itemData1));
			this.UdpateItemTimeLeftOrState();
			this.txtBuyNowPrice.SafeSetText(TR.Value("auction_buy_now_price", guildAuctionItemData.buyNowPrice));
			if (guildAuctionItemData.curbiddingPrice == 0UL)
			{
				this.txtCurBiddingPrice.SafeSetText(TR.Value("auction_no_price"));
				this.txtBiddingBtnText.SafeSetText(TR.Value("auction_first_bidding", guildAuctionItemData.nextBiddingPrice));
			}
			else
			{
				this.txtCurBiddingPrice.SafeSetText(TR.Value("auction_cur_bidding_price", guildAuctionItemData.curbiddingPrice));
				this.txtBiddingBtnText.SafeSetText(TR.Value("auction_next_bidding_price", guildAuctionItemData.nextBiddingPrice));
			}
			if (guildAuctionItemData.auctionItemState == GuildDataManager.AuctionItemState.InAuction)
			{
				this.btnBuy.SafeSetGray(false, true);
				this.btnBidding.SafeSetGray(false, true);
			}
			else
			{
				this.btnBuy.SafeSetGray(true, true);
				this.btnBidding.SafeSetGray(true, true);
			}
			this.myBidFlag.CustomActive(guildAuctionItemData.bidRoleId == DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (guildAuctionItemData.itemData1 != null)
			{
				this.jia.CustomActive(guildAuctionItemData.itemData1.ID != 0);
				this.itemInfo1.CustomActive(guildAuctionItemData.itemData1.ID != 0);
			}
		}

		// Token: 0x040082A6 RID: 33446
		[SerializeField]
		private ComItem item0;

		// Token: 0x040082A7 RID: 33447
		[SerializeField]
		private Text txtItem0Name;

		// Token: 0x040082A8 RID: 33448
		[SerializeField]
		private ComItem item1;

		// Token: 0x040082A9 RID: 33449
		[SerializeField]
		private Text txtItem1Name;

		// Token: 0x040082AA RID: 33450
		[SerializeField]
		private Text txtLeftTime;

		// Token: 0x040082AB RID: 33451
		[SerializeField]
		private Text txtItemState;

		// Token: 0x040082AC RID: 33452
		[SerializeField]
		private Text txtBuyNowPrice;

		// Token: 0x040082AD RID: 33453
		[SerializeField]
		private Button btnBuy;

		// Token: 0x040082AE RID: 33454
		[SerializeField]
		private Text txtCurBiddingPrice;

		// Token: 0x040082AF RID: 33455
		[SerializeField]
		private Button btnBidding;

		// Token: 0x040082B0 RID: 33456
		[SerializeField]
		private Text txtBiddingBtnText;

		// Token: 0x040082B1 RID: 33457
		[SerializeField]
		private Image myBidFlag;

		// Token: 0x040082B2 RID: 33458
		[SerializeField]
		private GameObject jia;

		// Token: 0x040082B3 RID: 33459
		[SerializeField]
		private GameObject itemInfo1;

		// Token: 0x040082B4 RID: 33460
		private GuildDataManager.GuildAuctionItemData auctionItemData;

		// Token: 0x040082B5 RID: 33461
		private ulong guid;

		// Token: 0x0200160D RID: 5645
		private enum MoneyType
		{
			// Token: 0x040082B7 RID: 33463
			MT_POINT = 18,
			// Token: 0x040082B8 RID: 33464
			MT_BIND_POINT = 28,
			// Token: 0x040082B9 RID: 33465
			MT_GOLD = 17,
			// Token: 0x040082BA RID: 33466
			MT_BIND_GOLD = 27
		}
	}
}
