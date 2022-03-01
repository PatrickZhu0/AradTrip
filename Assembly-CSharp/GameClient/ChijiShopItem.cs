using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001121 RID: 4385
	public class ChijiShopItem : MonoBehaviour
	{
		// Token: 0x0600A66F RID: 42607 RVA: 0x00228819 File Offset: 0x00226C19
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600A670 RID: 42608 RVA: 0x00228821 File Offset: 0x00226C21
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600A671 RID: 42609 RVA: 0x0022882F File Offset: 0x00226C2F
		private void BindUiEvents()
		{
			if (this.itemSelectedButton != null)
			{
				this.itemSelectedButton.onClick.RemoveAllListeners();
				this.itemSelectedButton.onClick.AddListener(new UnityAction(this.OnItemSelectedButtonClicked));
			}
		}

		// Token: 0x0600A672 RID: 42610 RVA: 0x0022886E File Offset: 0x00226C6E
		private void UnBindUiEvents()
		{
			if (this.itemSelectedButton != null)
			{
				this.itemSelectedButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600A673 RID: 42611 RVA: 0x00228891 File Offset: 0x00226C91
		private void ClearData()
		{
			this._chijiShopItemDataModel = null;
			this._itemData = null;
		}

		// Token: 0x0600A674 RID: 42612 RVA: 0x002288A4 File Offset: 0x00226CA4
		public void InitItem(ChijiShopItemDataModel chijiShopItemDataModel, OnShopItemSelected onShopItemSelected)
		{
			this._chijiShopItemDataModel = chijiShopItemDataModel;
			this._onShopItemSelected = onShopItemSelected;
			if (this._chijiShopItemDataModel == null)
			{
				return;
			}
			this._itemData = ChijiShopUtility.GetItemDataByChijiShopItemDataModel(this._chijiShopItemDataModel);
			if (this._itemData == null)
			{
				return;
			}
			if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Buy && this._chijiShopItemDataModel.ShopItemTable == null)
			{
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600A675 RID: 42613 RVA: 0x00228910 File Offset: 0x00226D10
		private void InitItemView()
		{
			CommonUtility.UpdateGameObjectVisible(this.beWearFlag, false);
			if (this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Sell)
			{
				if (this.itemName != null)
				{
					this.itemName.text = this._itemData.GetColorName(string.Empty, false);
				}
				CommonUtility.UpdateGameObjectVisible(this.itemSoldOverRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.itemCostRoot, true);
				if (this.costValueText != null)
				{
					this.costValueText.text = this._itemData.Price.ToString();
				}
				if (this.costIcon != null)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._itemData.PriceItemID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						ETCImageLoader.LoadSprite(ref this.costIcon, tableItem.Icon, true);
					}
				}
			}
			else
			{
				ChiJiShopItemTable shopItemTable = this._chijiShopItemDataModel.ShopItemTable;
				if (this.itemName != null)
				{
					this.itemName.text = shopItemTable.CommodityName;
				}
				if (this.costValueText != null)
				{
					this.costValueText.text = shopItemTable.CostNum.ToString();
				}
				if (this.costIcon != null)
				{
					ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(shopItemTable.CostItemID, string.Empty, string.Empty);
					if (tableItem2 != null)
					{
						ETCImageLoader.LoadSprite(ref this.costIcon, tableItem2.Icon, true);
					}
				}
				if (this._itemData != null)
				{
					ItemData wearEquipDataBySlotType = DataManager<ItemDataManager>.GetInstance().GetWearEquipDataBySlotType(this._itemData.EquipWearSlotType);
					if (wearEquipDataBySlotType != null && wearEquipDataBySlotType.TableID == this._itemData.TableID)
					{
						CommonUtility.UpdateGameObjectVisible(this.beWearFlag, true);
					}
				}
				this.UpdateShopItemSoldState();
			}
			if (this.itemRoot != null)
			{
				CommonNewItemDataModel dataModel = new CommonNewItemDataModel
				{
					ItemId = this._itemData.TableID,
					ItemCount = this._itemData.Count,
					ItemStrengthenLevel = this._itemData.StrengthenLevel
				};
				CommonNewItem commonNewItem = this.itemRoot.GetComponentInChildren<CommonNewItem>();
				if (commonNewItem == null)
				{
					commonNewItem = CommonUtility.CreateCommonNewItem(this.itemRoot);
				}
				if (commonNewItem != null)
				{
					commonNewItem.InitItem(dataModel);
				}
			}
			this.UpdateItemSelectedFlag();
		}

		// Token: 0x0600A676 RID: 42614 RVA: 0x00228B8C File Offset: 0x00226F8C
		private void UpdateShopItemSoldState()
		{
			if (this._chijiShopItemDataModel.IsSoldOver)
			{
				CommonUtility.UpdateGameObjectVisible(this.itemSoldOverRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.itemCostRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.itemSoldOverRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.itemCostRoot, true);
			}
		}

		// Token: 0x0600A677 RID: 42615 RVA: 0x00228BE0 File Offset: 0x00226FE0
		private void UpdateItemSelectedFlag()
		{
			if (this.itemSelectedFlag == null)
			{
				return;
			}
			if (this._chijiShopItemDataModel == null)
			{
				return;
			}
			if (this._itemData == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.itemSelectedFlag, this._chijiShopItemDataModel.IsSelected);
		}

		// Token: 0x0600A678 RID: 42616 RVA: 0x00228C2D File Offset: 0x0022702D
		public void UpdateItem()
		{
			this.UpdateItemSelectedFlag();
			if (this._chijiShopItemDataModel != null && this._chijiShopItemDataModel.ChijiShopType == ChijiShopType.Buy)
			{
				this.UpdateShopItemSoldState();
			}
		}

		// Token: 0x0600A679 RID: 42617 RVA: 0x00228C56 File Offset: 0x00227056
		public void RecycleItem()
		{
			this.ClearData();
		}

		// Token: 0x0600A67A RID: 42618 RVA: 0x00228C60 File Offset: 0x00227060
		private void OnItemSelectedButtonClicked()
		{
			if (this._chijiShopItemDataModel == null)
			{
				return;
			}
			if (this._itemData == null)
			{
				return;
			}
			if (this._chijiShopItemDataModel.IsSelected)
			{
				return;
			}
			this._chijiShopItemDataModel.IsSelected = true;
			this.UpdateItemSelectedFlag();
			if (this._onShopItemSelected != null)
			{
				this._onShopItemSelected(this._chijiShopItemDataModel.ItemIndex, this._chijiShopItemDataModel, this._itemData);
			}
		}

		// Token: 0x04005D13 RID: 23827
		private ChijiShopItemDataModel _chijiShopItemDataModel;

		// Token: 0x04005D14 RID: 23828
		private OnShopItemSelected _onShopItemSelected;

		// Token: 0x04005D15 RID: 23829
		private ItemData _itemData;

		// Token: 0x04005D16 RID: 23830
		[Space(10f)]
		[Header("Item")]
		[Space(10f)]
		[SerializeField]
		private Text itemName;

		// Token: 0x04005D17 RID: 23831
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x04005D18 RID: 23832
		[SerializeField]
		private GameObject beWearFlag;

		// Token: 0x04005D19 RID: 23833
		[Space(10f)]
		[Header("Cost")]
		[Space(10f)]
		[SerializeField]
		private Image costIcon;

		// Token: 0x04005D1A RID: 23834
		[SerializeField]
		private Text costValueText;

		// Token: 0x04005D1B RID: 23835
		[SerializeField]
		private GameObject itemCostRoot;

		// Token: 0x04005D1C RID: 23836
		[SerializeField]
		private GameObject itemSoldOverRoot;

		// Token: 0x04005D1D RID: 23837
		[Space(10f)]
		[Header("Selected")]
		[Space(10f)]
		[SerializeField]
		private Button itemSelectedButton;

		// Token: 0x04005D1E RID: 23838
		[SerializeField]
		private GameObject itemSelectedFlag;
	}
}
