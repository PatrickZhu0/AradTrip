using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200147F RID: 5247
	public class AuctionNewBuyNoticeOnSaleItem : MonoBehaviour
	{
		// Token: 0x0600CB81 RID: 52097 RVA: 0x0031E348 File Offset: 0x0031C748
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CB82 RID: 52098 RVA: 0x0031E350 File Offset: 0x0031C750
		private void BindEvents()
		{
			if (this.onSaleItemButton != null)
			{
				this.onSaleItemButton.onClick.RemoveAllListeners();
				this.onSaleItemButton.onClick.AddListener(new UnityAction(this.OnOnSaleItemButtonClick));
			}
		}

		// Token: 0x0600CB83 RID: 52099 RVA: 0x0031E38F File Offset: 0x0031C78F
		private void UnBindEvents()
		{
			if (this.onSaleItemButton != null)
			{
				this.onSaleItemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CB84 RID: 52100 RVA: 0x0031E3B2 File Offset: 0x0031C7B2
		private void OnDestroy()
		{
			if (this._onSaleComItem != null)
			{
				ComItemManager.Destroy(this._onSaleComItem);
				this._onSaleComItem = null;
			}
			this.ResetData();
			this.UnBindEvents();
		}

		// Token: 0x0600CB85 RID: 52101 RVA: 0x0031E3E3 File Offset: 0x0031C7E3
		private void ResetData()
		{
			this._onSaleItemId = 0U;
			this._onAuctionNewOnSaleItemClick = null;
			this._mainTabType = AuctionNewMainTabType.None;
			this._auctionItemBaseInfo = null;
		}

		// Token: 0x0600CB86 RID: 52102 RVA: 0x0031E401 File Offset: 0x0031C801
		public void InitItem(AuctionNewMainTabType mainTabType, AuctionItemBaseInfo auctionItemBaseInfo, OnAuctionNewOnSaleItemClick onAuctionNewOnSaleItemClick = null)
		{
			this._mainTabType = mainTabType;
			this._auctionItemBaseInfo = auctionItemBaseInfo;
			this._onAuctionNewOnSaleItemClick = onAuctionNewOnSaleItemClick;
			this.InitItemView();
		}

		// Token: 0x0600CB87 RID: 52103 RVA: 0x0031E420 File Offset: 0x0031C820
		private void InitItemView()
		{
			int itemTypeId = (int)this._auctionItemBaseInfo.itemTypeId;
			int num = (int)this._auctionItemBaseInfo.num;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemTypeId, 100, 0);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemTypeId, string.Empty, string.Empty);
			if (itemData == null || tableItem == null)
			{
				if (this.itemName != null)
				{
					this.itemName.text = TR.Value("auction_new_onSale_itemError");
				}
				return;
			}
			itemData.IsTreasure = (this._auctionItemBaseInfo.isTreas == 1);
			if (this.itemName != null)
			{
				this.itemName.text = AuctionNewUtility.GetQualityColorString(itemData.Name, tableItem.Color);
			}
			string text = string.Format(TR.Value("auction_new_onSale_sell_number"), num);
			if (this._mainTabType == AuctionNewMainTabType.AuctionNoticeType)
			{
				text = string.Format(TR.Value("auction_new_onSale_notice_number"), num);
			}
			if (this.itemNumberLabel != null)
			{
				this.itemNumberLabel.text = text;
			}
			if (this.itemIconRoot != null)
			{
				this._onSaleComItem = this.itemIconRoot.GetComponentInChildren<ComItem>();
				if (this._onSaleComItem == null)
				{
					this._onSaleComItem = ComItemManager.Create(this.itemIconRoot);
				}
				if (this._onSaleComItem != null)
				{
					this._onSaleComItem.Setup(itemData, new ComItem.OnItemClicked(this.OnShowItemTip));
					bool showTreasure = this._auctionItemBaseInfo.isTreas == 1;
					this._onSaleComItem.SetShowTreasure(showTreasure);
				}
			}
		}

		// Token: 0x0600CB88 RID: 52104 RVA: 0x0031E5CF File Offset: 0x0031C9CF
		public void OnItemRecycle()
		{
			this.ResetData();
		}

		// Token: 0x0600CB89 RID: 52105 RVA: 0x0031E5D8 File Offset: 0x0031C9D8
		private void OnOnSaleItemButtonClick()
		{
			if (this._auctionItemBaseInfo == null)
			{
				return;
			}
			if (this._auctionItemBaseInfo.itemTypeId <= 0U)
			{
				return;
			}
			if (this._auctionItemBaseInfo.num <= 0U)
			{
				return;
			}
			if (this._onAuctionNewOnSaleItemClick == null)
			{
				return;
			}
			this._onAuctionNewOnSaleItemClick(this._auctionItemBaseInfo);
		}

		// Token: 0x0600CB8A RID: 52106 RVA: 0x0031E632 File Offset: 0x0031CA32
		private void OnShowItemTip(GameObject obj, ItemData itemData)
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, 0UL);
		}

		// Token: 0x0400763F RID: 30271
		private AuctionNewMainTabType _mainTabType;

		// Token: 0x04007640 RID: 30272
		private AuctionItemBaseInfo _auctionItemBaseInfo;

		// Token: 0x04007641 RID: 30273
		private uint _onSaleItemId;

		// Token: 0x04007642 RID: 30274
		private ComItem _onSaleComItem;

		// Token: 0x04007643 RID: 30275
		private OnAuctionNewOnSaleItemClick _onAuctionNewOnSaleItemClick;

		// Token: 0x04007644 RID: 30276
		[SerializeField]
		private GameObject itemIconRoot;

		// Token: 0x04007645 RID: 30277
		[SerializeField]
		private Text itemName;

		// Token: 0x04007646 RID: 30278
		[SerializeField]
		private Text itemNumberLabel;

		// Token: 0x04007647 RID: 30279
		[SerializeField]
		private Button onSaleItemButton;
	}
}
