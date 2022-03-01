using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200111E RID: 4382
	public class ChijiShopItemController : MonoBehaviour
	{
		// Token: 0x0600A64B RID: 42571 RVA: 0x00227C82 File Offset: 0x00226082
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600A64C RID: 42572 RVA: 0x00227C8A File Offset: 0x0022608A
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this._chijiShopItemDataModelList.Clear();
		}

		// Token: 0x0600A64D RID: 42573 RVA: 0x00227CA0 File Offset: 0x002260A0
		private void BindUiEvents()
		{
			if (this.shopItemListEx != null)
			{
				this.shopItemListEx.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.shopItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.shopItemListEx;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.shopItemListEx;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveSceneShopItemBuySucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneShopItemBuySucceed));
		}

		// Token: 0x0600A64E RID: 42574 RVA: 0x00227D5C File Offset: 0x0022615C
		private void UnBindUiEvents()
		{
			if (this.shopItemListEx != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.shopItemListEx;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.shopItemListEx;
				comUIListScriptEx2.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx2.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
				ComUIListScriptEx comUIListScriptEx3 = this.shopItemListEx;
				comUIListScriptEx3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveSceneShopItemBuySucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneShopItemBuySucceed));
		}

		// Token: 0x0600A64F RID: 42575 RVA: 0x00227E0C File Offset: 0x0022620C
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._chijiShopItemDataModelList == null || this._chijiShopItemDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._chijiShopItemDataModelList.Count)
			{
				return;
			}
			ChijiShopItemDataModel chijiShopItemDataModel = this._chijiShopItemDataModelList[item.m_index];
			ChijiShopItem component = item.GetComponent<ChijiShopItem>();
			if (chijiShopItemDataModel != null && component != null)
			{
				component.InitItem(chijiShopItemDataModel, new OnShopItemSelected(this.OnShopItemSelected));
			}
		}

		// Token: 0x0600A650 RID: 42576 RVA: 0x00227EA4 File Offset: 0x002262A4
		private void OnItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChijiShopItem component = item.GetComponent<ChijiShopItem>();
			if (component != null)
			{
				component.UpdateItem();
			}
		}

		// Token: 0x0600A651 RID: 42577 RVA: 0x00227ED8 File Offset: 0x002262D8
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ChijiShopItem component = item.GetComponent<ChijiShopItem>();
			if (component != null)
			{
				component.RecycleItem();
			}
		}

		// Token: 0x0600A652 RID: 42578 RVA: 0x00227F0B File Offset: 0x0022630B
		private void OnShopItemSelected(int itemIndex, ChijiShopItemDataModel chijiShopItemDataModel, ItemData itemData)
		{
			this.UpdateShopItemDataModel(itemIndex);
			if (this.shopItemListEx != null)
			{
				this.shopItemListEx.UpdateElement();
			}
			this.UpdateItemDescriptionController(chijiShopItemDataModel, itemData);
		}

		// Token: 0x0600A653 RID: 42579 RVA: 0x00227F38 File Offset: 0x00226338
		public void InitShopItemController(ChijiShopType chijiShopType)
		{
			this._chijiShopType = chijiShopType;
			this.UpdateNoItemTipText();
			this._defaultChijiShopItemDataModel = null;
			this.InitShopItemDataModel();
			this.UpdateShopItemList();
			this.InitShopItemDescriptionController();
		}

		// Token: 0x0600A654 RID: 42580 RVA: 0x00227F60 File Offset: 0x00226360
		private void InitBuyItemDataModel()
		{
			List<int> chijiShopItemIdList = DataManager<ChijiShopDataManager>.GetInstance().ChijiShopItemIdList;
			if (chijiShopItemIdList == null || chijiShopItemIdList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < chijiShopItemIdList.Count; i++)
			{
				int num = chijiShopItemIdList[i];
				if (num > 0)
				{
					ChiJiShopItemTable chijiShopItemTable = ChijiShopUtility.GetChijiShopItemTable(num);
					if (chijiShopItemTable != null)
					{
						ChijiShopItemDataModel chijiShopItemDataModel = new ChijiShopItemDataModel();
						chijiShopItemDataModel.ChijiShopType = this._chijiShopType;
						chijiShopItemDataModel.ItemIndex = i;
						chijiShopItemDataModel.ShopId = DataManager<ChijiShopDataManager>.GetInstance().ChijiShopId;
						chijiShopItemDataModel.ShopItemId = num;
						chijiShopItemDataModel.ShopItemTable = chijiShopItemTable;
						if (i == 0)
						{
							chijiShopItemDataModel.IsSelected = true;
							this._defaultChijiShopItemDataModel = chijiShopItemDataModel;
						}
						else
						{
							chijiShopItemDataModel.IsSelected = false;
						}
						bool isSoldOver = ChijiShopUtility.IsChijiShopItemAlreadySoldOver(num);
						chijiShopItemDataModel.IsSoldOver = isSoldOver;
						this._chijiShopItemDataModelList.Add(chijiShopItemDataModel);
					}
				}
			}
		}

		// Token: 0x0600A655 RID: 42581 RVA: 0x00228048 File Offset: 0x00226448
		private void InitSellItemDataModel()
		{
			List<ulong> itemsByPackageType = DataManager<ItemDataManager>.GetInstance().GetItemsByPackageType(EPackageType.Equip);
			if (itemsByPackageType != null)
			{
				for (int i = 0; i < itemsByPackageType.Count; i++)
				{
					ulong num = itemsByPackageType[i];
					if (num > 0UL)
					{
						ChijiShopItemDataModel chijiShopItemDataModel = new ChijiShopItemDataModel();
						chijiShopItemDataModel.ChijiShopType = this._chijiShopType;
						chijiShopItemDataModel.ItemGuid = num;
						chijiShopItemDataModel.ItemIndex = i;
						if (i == 0)
						{
							chijiShopItemDataModel.IsSelected = true;
							this._defaultChijiShopItemDataModel = chijiShopItemDataModel;
						}
						else
						{
							chijiShopItemDataModel.IsSelected = false;
						}
						this._chijiShopItemDataModelList.Add(chijiShopItemDataModel);
					}
				}
			}
		}

		// Token: 0x0600A656 RID: 42582 RVA: 0x002280DF File Offset: 0x002264DF
		private void InitShopItemDataModel()
		{
			this._chijiShopItemDataModelList.Clear();
			if (this._chijiShopType == ChijiShopType.Sell)
			{
				this.InitSellItemDataModel();
			}
			else
			{
				this.InitBuyItemDataModel();
			}
		}

		// Token: 0x0600A657 RID: 42583 RVA: 0x0022810C File Offset: 0x0022650C
		private void UpdateShopItemDataModel(int selectedIndex)
		{
			if (this._chijiShopItemDataModelList == null || this._chijiShopItemDataModelList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._chijiShopItemDataModelList.Count; i++)
			{
				ChijiShopItemDataModel chijiShopItemDataModel = this._chijiShopItemDataModelList[i];
				if (chijiShopItemDataModel != null)
				{
					if (chijiShopItemDataModel.ItemIndex == selectedIndex)
					{
						chijiShopItemDataModel.IsSelected = true;
					}
					else
					{
						chijiShopItemDataModel.IsSelected = false;
					}
				}
			}
		}

		// Token: 0x0600A658 RID: 42584 RVA: 0x0022818C File Offset: 0x0022658C
		private void UpdateShopItemList()
		{
			int count = this._chijiShopItemDataModelList.Count;
			if (this.shopItemListEx != null)
			{
				this.shopItemListEx.ResetComUiListScriptEx();
				this.shopItemListEx.SetElementAmount(count);
				if (count == 0)
				{
					CommonUtility.UpdateGameObjectVisible(this.middleLine, false);
				}
				else
				{
					CommonUtility.UpdateGameObjectVisible(this.middleLine, true);
				}
			}
		}

		// Token: 0x0600A659 RID: 42585 RVA: 0x002281F0 File Offset: 0x002265F0
		private void UpdateNoItemTipText()
		{
			if (this.noItemTipText == null)
			{
				return;
			}
			string text = TR.Value("Chiji_Shop_Item_Can_Buy_Is_Zero");
			if (this._chijiShopType == ChijiShopType.Sell)
			{
				text = TR.Value("Chiji_Shop_Item_Can_Sell_Is_Zero");
			}
			this.noItemTipText.text = text;
		}

		// Token: 0x0600A65A RID: 42586 RVA: 0x00228240 File Offset: 0x00226640
		private void InitShopItemDescriptionController()
		{
			if (this.itemDescriptionController == null)
			{
				return;
			}
			ItemData itemDataByChijiShopItemDataModel = ChijiShopUtility.GetItemDataByChijiShopItemDataModel(this._defaultChijiShopItemDataModel);
			this.UpdateItemDescriptionController(this._defaultChijiShopItemDataModel, itemDataByChijiShopItemDataModel);
		}

		// Token: 0x0600A65B RID: 42587 RVA: 0x00228278 File Offset: 0x00226678
		private void UpdateItemDescriptionController(ChijiShopItemDataModel chijiShopItemDataModel, ItemData itemData)
		{
			if (this.itemDescriptionController == null)
			{
				return;
			}
			this.itemDescriptionController.UpdateItemDescriptionController(chijiShopItemDataModel, itemData);
		}

		// Token: 0x0600A65C RID: 42588 RVA: 0x00228299 File Offset: 0x00226699
		public void UpdateShopItemContentByGloryCoinChanged()
		{
			if (this._chijiShopType == ChijiShopType.Sell)
			{
				return;
			}
			if (this.itemDescriptionController == null)
			{
				return;
			}
			this.itemDescriptionController.UpdateItemButtonState();
		}

		// Token: 0x0600A65D RID: 42589 RVA: 0x002282C8 File Offset: 0x002266C8
		private void OnReceiveSceneShopItemBuySucceed(UIEvent uiEvent)
		{
			if (this._chijiShopType != ChijiShopType.Buy)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num <= 0)
			{
				return;
			}
			if (this._chijiShopItemDataModelList == null || this._chijiShopItemDataModelList.Count <= 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < this._chijiShopItemDataModelList.Count; i++)
			{
				ChijiShopItemDataModel chijiShopItemDataModel = this._chijiShopItemDataModelList[i];
				if (chijiShopItemDataModel != null)
				{
					if (chijiShopItemDataModel.ShopItemId == num)
					{
						chijiShopItemDataModel.IsSoldOver = true;
						flag = true;
						break;
					}
				}
			}
			if (flag)
			{
				if (this.shopItemListEx != null)
				{
					this.shopItemListEx.UpdateElement();
				}
				if (this.itemDescriptionController != null)
				{
					this.itemDescriptionController.UpdateItemDealDisplay();
				}
			}
		}

		// Token: 0x04005D00 RID: 23808
		private ChijiShopType _chijiShopType = ChijiShopType.None;

		// Token: 0x04005D01 RID: 23809
		private List<ChijiShopItemDataModel> _chijiShopItemDataModelList = new List<ChijiShopItemDataModel>();

		// Token: 0x04005D02 RID: 23810
		private ChijiShopItemDataModel _defaultChijiShopItemDataModel;

		// Token: 0x04005D03 RID: 23811
		[Space(10f)]
		[Header("noItemTip")]
		[Space(10f)]
		[SerializeField]
		private Text noItemTipText;

		// Token: 0x04005D04 RID: 23812
		[Space(10f)]
		[Header("ItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx shopItemListEx;

		// Token: 0x04005D05 RID: 23813
		[SerializeField]
		private GameObject middleLine;

		// Token: 0x04005D06 RID: 23814
		[Space(10f)]
		[Header("ItemDescription")]
		[Space(10f)]
		[SerializeField]
		private ChijiShopItemDescriptionController itemDescriptionController;
	}
}
