using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001498 RID: 5272
	public class AuctionNewForSellElementItem : MonoBehaviour
	{
		// Token: 0x0600CC70 RID: 52336 RVA: 0x00322EDC File Offset: 0x003212DC
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CC71 RID: 52337 RVA: 0x00322EE4 File Offset: 0x003212E4
		private void BindEvents()
		{
			if (this.elementItemButton != null)
			{
				this.elementItemButton.onClick.RemoveAllListeners();
				this.elementItemButton.onClick.AddListener(new UnityAction(this.OnElementItemButtonClick));
			}
		}

		// Token: 0x0600CC72 RID: 52338 RVA: 0x00322F23 File Offset: 0x00321323
		private void UnBindEvents()
		{
			if (this.elementItemButton != null)
			{
				this.elementItemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CC73 RID: 52339 RVA: 0x00322F46 File Offset: 0x00321346
		private void OnDestroy()
		{
			if (this._elementComItem != null)
			{
				ComItemManager.Destroy(this._elementComItem);
				this._elementComItem = null;
			}
			this.ResetData();
			this.UnBindEvents();
		}

		// Token: 0x0600CC74 RID: 52340 RVA: 0x00322F77 File Offset: 0x00321377
		private void ResetData()
		{
			this._elementItemId = 0UL;
			this._auctionSellItemData = null;
			this._itemData = null;
			this._isInCoolTime = false;
			this._isItemTradeLimit = false;
			this._itemTradeLeftTime = 0;
		}

		// Token: 0x0600CC75 RID: 52341 RVA: 0x00322FA4 File Offset: 0x003213A4
		public void InitItem(AuctionSellItemData auctionSellItemData)
		{
			this._auctionSellItemData = auctionSellItemData;
			this.InitView();
		}

		// Token: 0x0600CC76 RID: 52342 RVA: 0x00322FB4 File Offset: 0x003213B4
		private void InitView()
		{
			this._itemData = DataManager<ItemDataManager>.GetInstance().GetItem(this._auctionSellItemData.uId);
			if (this._itemData == null)
			{
				Logger.LogErrorFormat("itemData is null and auctionSellItemData is {0}", new object[]
				{
					this._auctionSellItemData.uId
				});
				return;
			}
			DataManager<AuctionNewDataManager>.GetInstance().AddItemDataDetailInfo(this._auctionSellItemData.uId, this._itemData);
			this._isInCoolTime = AuctionNewUtility.IsAuctionNewItemInCoolTime(this._itemData);
			this._isItemTradeLimit = ItemDataUtility.IsItemTradeLimitBuyNumber(this._itemData);
			this._itemTradeLeftTime = ItemDataUtility.GetItemTradeLeftTime(this._itemData);
			this._elementComItem = this.itemIcon.GetComponentInChildren<ComItem>();
			if (this._elementComItem == null)
			{
				this._elementComItem = ComItemManager.Create(this.itemIcon);
			}
			if (this._elementComItem != null)
			{
				this._elementComItem.Setup(this._itemData, null);
				this._elementComItem.SetShowTreasure(this._itemData.IsTreasure);
			}
			if (this.itemUiGray != null)
			{
				if (this._isInCoolTime)
				{
					this.itemUiGray.enabled = true;
				}
				else
				{
					this.itemUiGray.enabled = false;
				}
				if (this._isItemTradeLimit && this._itemTradeLeftTime == 0)
				{
					this.itemUiGray.enabled = true;
				}
			}
		}

		// Token: 0x0600CC77 RID: 52343 RVA: 0x00323120 File Offset: 0x00321520
		public void OnItemRecycle()
		{
			this.ResetData();
		}

		// Token: 0x0600CC78 RID: 52344 RVA: 0x00323128 File Offset: 0x00321528
		private void OnElementItemButtonClick()
		{
			if (this._auctionSellItemData == null)
			{
				return;
			}
			if (this._itemData == null)
			{
				return;
			}
			AuctionNewUtility.CloseAuctionNewOnShelfFrame();
			if (this._itemData.IsNeedPacking())
			{
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("Auction_item_packing"), new UnityAction(this.OnClickOnPacking), null, 0f, false);
			}
			else
			{
				if (this._isInCoolTime)
				{
					AuctionNewUtility.ShowItemInCoolTimeFloatingEffect(this._itemData.AuctionCoolTimeStamp, DataManager<TimeManager>.GetInstance().GetServerTime());
					return;
				}
				if (this._isItemTradeLimit)
				{
					if (this._itemTradeLeftTime <= 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item__trade_number_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					string contentStr = string.Format(TR.Value("auction_new_item_on_shelf_with_trade_number"), this._itemTradeLeftTime);
					AuctionNewUtility.OnShowItemTradeLimitFrame(contentStr, new Action(this.OnOpenAuctionNewOnShelfFrame));
					return;
				}
				else
				{
					this.OnOpenAuctionNewOnShelfFrame();
				}
			}
		}

		// Token: 0x0600CC79 RID: 52345 RVA: 0x0032320C File Offset: 0x0032160C
		private void OnOpenAuctionNewOnShelfFrame()
		{
			AuctionNewUtility.OpenAuctionNewOnShelfFrame(this._auctionSellItemData.uId, this._itemData.IsTreasure, DataManager<AuctionNewDataManager>.GetInstance().BaseShelfNum + DataManager<PlayerBaseData>.GetInstance().AddAuctionFieldsNum, DataManager<AuctionNewDataManager>.GetInstance().OnShelfItemNumber);
		}

		// Token: 0x0600CC7A RID: 52346 RVA: 0x00323248 File Offset: 0x00321648
		private void OnClickOnPacking()
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnClickOnPacking(this._itemData);
		}

		// Token: 0x040076F3 RID: 30451
		private AuctionSellItemData _auctionSellItemData;

		// Token: 0x040076F4 RID: 30452
		private ItemData _itemData;

		// Token: 0x040076F5 RID: 30453
		private ulong _elementItemId;

		// Token: 0x040076F6 RID: 30454
		private ComItem _elementComItem;

		// Token: 0x040076F7 RID: 30455
		private bool _isInCoolTime;

		// Token: 0x040076F8 RID: 30456
		private bool _isItemTradeLimit;

		// Token: 0x040076F9 RID: 30457
		private int _itemTradeLeftTime;

		// Token: 0x040076FA RID: 30458
		[SerializeField]
		private GameObject itemIcon;

		// Token: 0x040076FB RID: 30459
		[SerializeField]
		private Button elementItemButton;

		// Token: 0x040076FC RID: 30460
		[SerializeField]
		private UIGray itemUiGray;
	}
}
