using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200111F RID: 4383
	public class ChijiShopItemDescriptionController : MonoBehaviour
	{
		// Token: 0x0600A65F RID: 42591 RVA: 0x002283BA File Offset: 0x002267BA
		private void Awake()
		{
			this.InitData();
			this.BindUiEvents();
		}

		// Token: 0x0600A660 RID: 42592 RVA: 0x002283C8 File Offset: 0x002267C8
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x0600A661 RID: 42593 RVA: 0x002283D0 File Offset: 0x002267D0
		private void InitData()
		{
			if (this.itemDescriptionLabel != null)
			{
				this._itemDescriptionLabelPosY = this.itemDescriptionLabel.transform.localPosition.y;
			}
		}

		// Token: 0x0600A662 RID: 42594 RVA: 0x0022840C File Offset: 0x0022680C
		private void BindUiEvents()
		{
			if (this.itemButton != null)
			{
				this.itemButton.onClick.RemoveAllListeners();
				this.itemButton.onClick.AddListener(new UnityAction(this.OnItemButtonClicked));
			}
		}

		// Token: 0x0600A663 RID: 42595 RVA: 0x0022844B File Offset: 0x0022684B
		private void UnBindUiEvents()
		{
			if (this.itemButton != null)
			{
				this.itemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600A664 RID: 42596 RVA: 0x00228470 File Offset: 0x00226870
		public void UpdateItemDescriptionController(ChijiShopItemDataModel chijiShopItemDataModel, ItemData itemData)
		{
			this._chijiShopItemDataModel = chijiShopItemDataModel;
			this._itemData = itemData;
			if (this._chijiShopItemDataModel == null || this._itemData == null)
			{
				CommonUtility.UpdateGameObjectVisible(this.controllerRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.controllerRoot, true);
			this.UpdateItemDetailLabel();
			this.UpdateItemDealContent();
		}

		// Token: 0x0600A665 RID: 42597 RVA: 0x002284C8 File Offset: 0x002268C8
		private void UpdateItemDetailLabel()
		{
			if (this.itemNameLabel != null)
			{
				string colorName = this._itemData.GetColorName(string.Empty, false);
				this.itemNameLabel.text = colorName;
			}
			if (this.itemDescriptionLabel != null)
			{
				Vector3 localPosition = this.itemDescriptionLabel.transform.localPosition;
				this.itemDescriptionLabel.transform.localPosition = new Vector3(localPosition.x, this._itemDescriptionLabelPosY, localPosition.z);
				string itemDetailStr = ChijiShopUtility.GetItemDetailStr(this._itemData, false);
				this.itemDescriptionLabel.text = itemDetailStr;
			}
		}

		// Token: 0x0600A666 RID: 42598 RVA: 0x00228568 File Offset: 0x00226968
		private void UpdateItemDealContent()
		{
			this.UpdateItemDealDisplay();
			if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Sell)
			{
				if (this.itemButtonText != null)
				{
					this.itemButtonText.text = TR.Value("Chiji_Shop_Item_Sell_Label");
				}
				CommonUtility.UpdateButtonState(this.itemButton, this.itemButtonGray, true);
				if (this.itemDealIcon != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._itemData.PriceItemID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ETCImageLoader.LoadSprite(ref this.itemDealIcon, tableItem.Icon, true);
					}
				}
				if (this.itemDealValueText != null)
				{
					this.itemDealValueText.text = this._itemData.Price.ToString();
				}
			}
			else if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Buy)
			{
				if (this.itemButtonText != null)
				{
					this.itemButtonText.text = TR.Value("Chiji_Shop_Item_Buy_Label");
				}
				if (this.itemDealIcon != null)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._chijiShopItemDataModel.ShopItemTable.CostItemID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						ETCImageLoader.LoadSprite(ref this.itemDealIcon, tableItem2.Icon, true);
					}
					if (this.itemDealValueText != null)
					{
						this.itemDealValueText.text = this._chijiShopItemDataModel.ShopItemTable.CostNum.ToString();
					}
				}
				this.UpdateItemButtonState();
			}
		}

		// Token: 0x0600A667 RID: 42599 RVA: 0x0022870C File Offset: 0x00226B0C
		public void UpdateItemButtonState()
		{
			if (ChijiShopUtility.GetCurrentOwnerGloryCoinNumber() < this._chijiShopItemDataModel.ShopItemTable.CostNum)
			{
				CommonUtility.UpdateButtonState(this.itemButton, this.itemButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.itemButton, this.itemButtonGray, true);
			}
		}

		// Token: 0x0600A668 RID: 42600 RVA: 0x0022875C File Offset: 0x00226B5C
		public void UpdateItemDealDisplay()
		{
			if (this._chijiShopItemDataModel == null)
			{
				return;
			}
			if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Sell)
			{
				CommonUtility.UpdateGameObjectVisible(this.itemDealRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.itemDealRoot, !this._chijiShopItemDataModel.IsSoldOver);
			}
		}

		// Token: 0x0600A669 RID: 42601 RVA: 0x002287B0 File Offset: 0x00226BB0
		private void OnItemButtonClicked()
		{
			if (this._chijiShopItemDataModel == null)
			{
				return;
			}
			if (this._itemData == null)
			{
				return;
			}
			if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Sell)
			{
				ChijiShopUtility.OnSellItemInChijiScene(this._itemData);
			}
			else if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Buy)
			{
				ChijiShopUtility.OnBuyItemInChijiScene(this._chijiShopItemDataModel);
			}
		}

		// Token: 0x04005D07 RID: 23815
		private ChijiShopItemDataModel _chijiShopItemDataModel;

		// Token: 0x04005D08 RID: 23816
		private ItemData _itemData;

		// Token: 0x04005D09 RID: 23817
		private float _itemDescriptionLabelPosY;

		// Token: 0x04005D0A RID: 23818
		[Space(10f)]
		[Header("Root")]
		[Space(10f)]
		[SerializeField]
		private GameObject controllerRoot;

		// Token: 0x04005D0B RID: 23819
		[Space(10f)]
		[Header("itemDescription")]
		[Space(10f)]
		[SerializeField]
		private Text itemNameLabel;

		// Token: 0x04005D0C RID: 23820
		[SerializeField]
		private Text itemDescriptionLabel;

		// Token: 0x04005D0D RID: 23821
		[Space(10f)]
		[Header("DealButton")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemDealRoot;

		// Token: 0x04005D0E RID: 23822
		[SerializeField]
		private Button itemButton;

		// Token: 0x04005D0F RID: 23823
		[SerializeField]
		private Text itemButtonText;

		// Token: 0x04005D10 RID: 23824
		[SerializeField]
		private UIGray itemButtonGray;

		// Token: 0x04005D11 RID: 23825
		[Space(10f)]
		[Header("DealCost")]
		[Space(10f)]
		[SerializeField]
		private Image itemDealIcon;

		// Token: 0x04005D12 RID: 23826
		[SerializeField]
		private Text itemDealValueText;
	}
}
