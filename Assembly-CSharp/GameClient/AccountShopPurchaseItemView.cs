using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A6C RID: 6764
	public class AccountShopPurchaseItemView : MonoBehaviour
	{
		// Token: 0x0601099D RID: 67997 RVA: 0x004B18AB File Offset: 0x004AFCAB
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0601099E RID: 67998 RVA: 0x004B18B4 File Offset: 0x004AFCB4
		private void BindUiEventSystem()
		{
			if (this._bEventBinded)
			{
				return;
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.selectedSlider != null)
			{
				this.selectedSlider.onValueChanged.AddListener(new UnityAction<float>(this.OnSelectedSliderChangeValue));
			}
			if (this.selectedCountInputField != null)
			{
				this.selectedCountInputField.onValueChanged.AddListener(new UnityAction<string>(this.OnInputFieldValueChanged));
			}
			if (this.minButton != null)
			{
				this.minButton.onClick.AddListener(new UnityAction(this.OnMinButtonClickCallBack));
			}
			if (this.minusButton != null)
			{
				this.minusButton.onClick.AddListener(new UnityAction(this.OnMinusButtonClickCallBack));
			}
			if (this.maxButton != null)
			{
				this.maxButton.onClick.AddListener(new UnityAction(this.OnMaxButtonClickCallBack));
			}
			if (this.addButton != null)
			{
				this.addButton.onClick.AddListener(new UnityAction(this.OnAddButtonClickCallBack));
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClickCallBack));
			}
			this._bEventBinded = true;
		}

		// Token: 0x0601099F RID: 67999 RVA: 0x004B1A3C File Offset: 0x004AFE3C
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x060109A0 RID: 68000 RVA: 0x004B1A4C File Offset: 0x004AFE4C
		private void ClearData()
		{
			this._accShopLocalItemInfo = null;
			if (this._comItem != null)
			{
				ComItemManager.Destroy(this._comItem);
				this._comItem = null;
			}
			this._curBuyNumber = 1;
			this._totalCanBuyNumber = 1;
			this._isShowOldChangeNewFlag = false;
			this._costItemData = null;
		}

		// Token: 0x060109A1 RID: 68001 RVA: 0x004B1AA0 File Offset: 0x004AFEA0
		private void UnBindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.selectedSlider != null)
			{
				this.selectedSlider.onValueChanged.RemoveAllListeners();
			}
			if (this.selectedCountInputField != null)
			{
				this.selectedCountInputField.onValueChanged.RemoveAllListeners();
			}
			if (this.minButton != null)
			{
				this.minButton.onClick.RemoveAllListeners();
			}
			if (this.minusButton != null)
			{
				this.minusButton.onClick.RemoveAllListeners();
			}
			if (this.maxButton != null)
			{
				this.maxButton.onClick.RemoveAllListeners();
			}
			if (this.addButton != null)
			{
				this.addButton.onClick.RemoveAllListeners();
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			this._bEventBinded = false;
		}

		// Token: 0x060109A2 RID: 68002 RVA: 0x004B1BBC File Offset: 0x004AFFBC
		public void InitShop(AccountShopPurchaseItemInfo accShopItemInfo)
		{
			this._accShopLocalItemInfo = accShopItemInfo;
			if (this._accShopLocalItemInfo == null)
			{
				Logger.LogErrorFormat("[AccountShopPurchaseItemView] InitShop ItemData is null", new object[0]);
				return;
			}
			this.InitShopData();
			this.InitShopView();
		}

		// Token: 0x060109A3 RID: 68003 RVA: 0x004B1BF0 File Offset: 0x004AFFF0
		private void InitShopData()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return;
			}
			int num = this._GetFirstCostItemId();
			int num2 = this._GetFirstCostItemNum();
			this._costItemData = ItemDataManager.CreateItemDataFromTable(num, 100, 0);
			if (this._costItemData == null)
			{
				Logger.LogErrorFormat("InitShopData costItem id can not find in ItemTable and costItemId is {0}", new object[]
				{
					num.ToString()
				});
				return;
			}
			int num3 = this._GetOwnFirstCostItemCount(num);
			if (num2 <= 0)
			{
				Logger.LogErrorFormat("InitShopData CostItem CostNumber is Invalid and costItemId is {0}", new object[]
				{
					num.ToString()
				});
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._accShopLocalItemInfo.ItemInfo.itemDataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("itemTable is null and itemId is {0}", new object[]
				{
					this._accShopLocalItemInfo.ItemInfo.itemDataId.ToString()
				});
				return;
			}
			this._totalCanBuyNumber = num3 / num2;
			this._totalCanBuyNumber = ((tableItem.MaxNum >= this._totalCanBuyNumber) ? this._totalCanBuyNumber : tableItem.MaxNum);
			int totalCanBuyNumber = this._totalCanBuyNumber;
			int num4 = this._GetLimitTimeBuyNum();
			if (num4 >= 0)
			{
				this._totalCanBuyNumber = ((num4 >= this._totalCanBuyNumber) ? this._totalCanBuyNumber : num4);
			}
			else
			{
				this._totalCanBuyNumber = totalCanBuyNumber;
			}
			if (this._accShopLocalItemInfo.ItemInfo != null)
			{
				AccountShopItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<AccountShopItemTable>((int)this._accShopLocalItemInfo.ItemInfo.shopItemId, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.BuyLimit > 0 && this._totalCanBuyNumber > tableItem2.BuyLimit)
				{
					this._totalCanBuyNumber = tableItem2.BuyLimit;
				}
			}
			if (this._totalCanBuyNumber < 1)
			{
				this._totalCanBuyNumber = 1;
			}
		}

		// Token: 0x060109A4 RID: 68004 RVA: 0x004B1DCE File Offset: 0x004B01CE
		private void InitShopView()
		{
			this.InitShopBuyItem();
			this.InitShopCostItem();
			this.InitShopSelectedInfo();
			this.InitShopBuyButton();
			this.OnValueChanged();
		}

		// Token: 0x060109A5 RID: 68005 RVA: 0x004B1DF0 File Offset: 0x004B01F0
		private void InitShopBuyItem()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._accShopLocalItemInfo.ItemInfo.itemDataId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("itemTable is null and itemId is {0}", new object[]
				{
					this._accShopLocalItemInfo.ItemInfo.itemDataId
				});
				return;
			}
			this.buyItemDescriptionText.text = tableItem.Description;
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this._accShopLocalItemInfo.ItemInfo.itemDataId, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemData is null and ItemId is {0}", new object[]
				{
					this._accShopLocalItemInfo.ItemInfo.itemDataId
				});
				return;
			}
			this.buyItemName.text = itemData.GetColorName(string.Empty, false);
			itemData.Count = (int)this._accShopLocalItemInfo.ItemInfo.itemNum;
			this._comItem = this.buyItemRoot.GetComponent<ComItem>();
			if (this._comItem == null)
			{
				this._comItem = ComItemManager.Create(this.buyItemRoot);
			}
			this._comItem.Setup(itemData, null);
		}

		// Token: 0x060109A6 RID: 68006 RVA: 0x004B1F24 File Offset: 0x004B0324
		private void InitShopCostItem()
		{
			int num = this._GetFirstCostItemId();
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("CostItemTable is null and costItemId is {0}", new object[]
				{
					num
				});
				return;
			}
			ETCImageLoader.LoadSprite(ref this.costIcon, tableItem.Icon, true);
			this.costNameText.text = tableItem.Name;
			bool flag = DataManager<ShopNewDataManager>.GetInstance().IsMoneyItemShowName(num);
			if (flag)
			{
				this.costNameText.gameObject.CustomActive(true);
				this.costIcon.gameObject.CustomActive(false);
			}
			else
			{
				this.costNameText.gameObject.CustomActive(false);
				this.costIcon.gameObject.CustomActive(true);
			}
			this.UpdateShopCostItem();
			this.comOldChangeNewItem.gameObject.CustomActive(this._isShowOldChangeNewFlag);
			if (!this._isShowOldChangeNewFlag)
			{
				this.selectedRoot.gameObject.CustomActive(true);
				this.OldChangeNewRoot.CustomActive(false);
			}
			int num2 = this._GetLimitTimeBuyNum();
			this.leftItemNumberText.text = string.Format(TR.Value("shop_buy_limit", num2), new object[0]);
			this.leftItemNumberText.gameObject.CustomActive(num2 > 0 && !this._isShowOldChangeNewFlag);
		}

		// Token: 0x060109A7 RID: 68007 RVA: 0x004B2088 File Offset: 0x004B0488
		private void UpdateShopCostItem()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return;
			}
			if (this._accShopLocalItemInfo.ItemInfo.costItems == null || this._accShopLocalItemInfo.ItemInfo.costItems.Length == 0)
			{
				return;
			}
			int costItemTableId = this._GetFirstCostItemId();
			int num = this._GetOwnFirstCostItemCount(costItemTableId);
			int num2 = this._GetFirstCostItemNum();
			int num3 = num2 * this._curBuyNumber;
			this.costNumberText.text = num3.ToString();
			this.costNumberText.color = ((num >= num3) ? new Color(0.95686275f, 0.8627451f, 0.5372549f, 1f) : Color.red);
		}

		// Token: 0x060109A8 RID: 68008 RVA: 0x004B213A File Offset: 0x004B053A
		private void InitShopSelectedInfo()
		{
		}

		// Token: 0x060109A9 RID: 68009 RVA: 0x004B213C File Offset: 0x004B053C
		private void InitShopBuyButton()
		{
		}

		// Token: 0x060109AA RID: 68010 RVA: 0x004B213E File Offset: 0x004B053E
		private void OnMinButtonClickCallBack()
		{
			this._curBuyNumber = 1;
			this.OnValueChanged();
		}

		// Token: 0x060109AB RID: 68011 RVA: 0x004B214D File Offset: 0x004B054D
		private void OnMinusButtonClickCallBack()
		{
			this._curBuyNumber--;
			this.OnValueChanged();
		}

		// Token: 0x060109AC RID: 68012 RVA: 0x004B2163 File Offset: 0x004B0563
		private void OnMaxButtonClickCallBack()
		{
			this._curBuyNumber = this._totalCanBuyNumber;
			this.OnValueChanged();
		}

		// Token: 0x060109AD RID: 68013 RVA: 0x004B2177 File Offset: 0x004B0577
		private void OnAddButtonClickCallBack()
		{
			this._curBuyNumber++;
			this.OnValueChanged();
		}

		// Token: 0x060109AE RID: 68014 RVA: 0x004B2190 File Offset: 0x004B0590
		private void OnInputFieldValueChanged(string value)
		{
			int curBuyNumber = 0;
			if (value.Length > 0)
			{
				curBuyNumber = int.Parse(value);
			}
			this._curBuyNumber = curBuyNumber;
			this.OnValueChanged();
		}

		// Token: 0x060109AF RID: 68015 RVA: 0x004B21C0 File Offset: 0x004B05C0
		private void OnValueChanged()
		{
			if (this._curBuyNumber < 1)
			{
				this._curBuyNumber = 1;
			}
			if (this._curBuyNumber > this._totalCanBuyNumber)
			{
				this._curBuyNumber = this._totalCanBuyNumber;
			}
			this.minusButton.enabled = (this._curBuyNumber > 1);
			this.minusButtonGray.enabled = !this.minusButton.enabled;
			this.minButton.enabled = (this._curBuyNumber > 1);
			this.minButtonGray.enabled = !this.minButton.enabled;
			this.addButton.enabled = (this._curBuyNumber < this._totalCanBuyNumber);
			this.addButtonGray.enabled = !this.addButton.enabled;
			this.maxButton.enabled = (this._curBuyNumber < this._totalCanBuyNumber);
			this.maxButtonGray.enabled = !this.maxButton.enabled;
			this.selectedCountInputField.text = this._curBuyNumber.ToString();
			if (this._totalCanBuyNumber > 1)
			{
				float num = (float)(this._curBuyNumber - 1) * 1f / (float)(this._totalCanBuyNumber - 1);
				if (this.selectedSlider.value != num)
				{
					this.selectedSlider.value = num;
				}
			}
			else if (this.selectedSlider.value != 1f)
			{
				this.selectedSlider.value = 1f;
			}
			this.UpdateShopCostItem();
		}

		// Token: 0x060109B0 RID: 68016 RVA: 0x004B234C File Offset: 0x004B074C
		private void OnSelectedSliderChangeValue(float fValue)
		{
			int num = 0;
			if (int.TryParse(this.selectedCountInputField.text, out num))
			{
				if (this._totalCanBuyNumber <= 1)
				{
					if (fValue != 1f)
					{
						this.selectedSlider.value = 1f;
						return;
					}
					this.selectedCountInputField.text = 1.ToString();
					return;
				}
				else
				{
					int num2 = (int)(fValue / (1f / (float)(this._totalCanBuyNumber - 1)) + 0.5f) + 1;
					if (num2 < 1)
					{
						num2 = 1;
					}
					float num3 = (float)(num2 - 1) * 1f / (float)(this._totalCanBuyNumber - 1);
					if (num3 != fValue)
					{
						this.selectedSlider.value = num3;
						return;
					}
					if (num != num2)
					{
						this.selectedCountInputField.text = num2.ToString();
					}
				}
			}
		}

		// Token: 0x060109B1 RID: 68017 RVA: 0x004B242B File Offset: 0x004B082B
		private void ShopItemTipFrame(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x060109B2 RID: 68018 RVA: 0x004B243D File Offset: 0x004B083D
		private void OnBuyButtonClickCallBack()
		{
			if (this.buyButtonCD != null && !this.buyButtonCD.IsBtnWork())
			{
				return;
			}
			if (!this._isShowOldChangeNewFlag)
			{
				this.OnPurcahseShopItem();
			}
		}

		// Token: 0x060109B3 RID: 68019 RVA: 0x004B2478 File Offset: 0x004B0878
		private void OnPurcahseShopItem()
		{
			if (this._costItemData == null)
			{
				return;
			}
			int num = this._GetFirstCostItemNum();
			int num2 = num * this._curBuyNumber;
			int num3 = this._GetOwnFirstCostItemCount(this._costItemData.TableID);
			if (num2 > num3)
			{
				if (!ItemComeLink.IsLinkMoney(this._costItemData.TableID, new ComLinkFrame.OnClick(this.OnCloseFrame), null))
				{
					SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials"), this._costItemData.Name), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				return;
			}
			if (this._curBuyNumber <= 0)
			{
				return;
			}
			CostItemManager.CostInfo a_costInfo = new CostItemManager.CostInfo
			{
				nMoneyID = this._costItemData.TableID,
				nCount = num2
			};
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(a_costInfo, new Action(this.OnPurchaseShopItemAction), "common_money_cost", null);
		}

		// Token: 0x060109B4 RID: 68020 RVA: 0x004B2550 File Offset: 0x004B0950
		private void OnPurchaseShopItemAction()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return;
			}
			AccountShopQueryIndex accountShopQueryIndex = new AccountShopQueryIndex();
			accountShopQueryIndex.shopId = this._accShopLocalItemInfo.ShopId;
			accountShopQueryIndex.tabType = this._accShopLocalItemInfo.ItemInfo.tabType;
			accountShopQueryIndex.jobType = this._accShopLocalItemInfo.ItemInfo.jobType;
			DataManager<AccountShopDataManager>.GetInstance().SendWorldAccountShopItemBuyReq(accountShopQueryIndex, this._accShopLocalItemInfo.ItemInfo.shopItemId, (uint)this._curBuyNumber);
			this.OnCloseFrame();
		}

		// Token: 0x060109B5 RID: 68021 RVA: 0x004B25D3 File Offset: 0x004B09D3
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountShopPurchaseItemFrame>(null, false);
		}

		// Token: 0x060109B6 RID: 68022 RVA: 0x004B25E4 File Offset: 0x004B09E4
		private int _GetFirstCostItemId()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return 0;
			}
			if (this._accShopLocalItemInfo.ItemInfo.costItems == null || this._accShopLocalItemInfo.ItemInfo.costItems.Length == 0)
			{
				return 0;
			}
			return (int)this._accShopLocalItemInfo.ItemInfo.costItems[0].id;
		}

		// Token: 0x060109B7 RID: 68023 RVA: 0x004B2648 File Offset: 0x004B0A48
		private int _GetFirstCostItemNum()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return 0;
			}
			if (this._accShopLocalItemInfo.ItemInfo.costItems == null || this._accShopLocalItemInfo.ItemInfo.costItems.Length == 0)
			{
				return 0;
			}
			return (int)this._accShopLocalItemInfo.ItemInfo.costItems[0].num;
		}

		// Token: 0x060109B8 RID: 68024 RVA: 0x004B26A9 File Offset: 0x004B0AA9
		private int _GetLimitTimeBuyNum()
		{
			if (this._accShopLocalItemInfo == null)
			{
				return 0;
			}
			return DataManager<AccountShopDataManager>.GetInstance().GetAccountShopItemCanBuyNum(this._accShopLocalItemInfo.ItemInfo);
		}

		// Token: 0x060109B9 RID: 68025 RVA: 0x004B26CD File Offset: 0x004B0ACD
		private int _GetOwnFirstCostItemCount(int costItemTableId)
		{
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(costItemTableId, true);
		}

		// Token: 0x0400A95E RID: 43358
		private AccountShopPurchaseItemInfo _accShopLocalItemInfo;

		// Token: 0x0400A95F RID: 43359
		private ComItem _comItem;

		// Token: 0x0400A960 RID: 43360
		private ItemData _costItemData;

		// Token: 0x0400A961 RID: 43361
		private bool _isShowOldChangeNewFlag;

		// Token: 0x0400A962 RID: 43362
		private int _curBuyNumber = 1;

		// Token: 0x0400A963 RID: 43363
		private int _totalCanBuyNumber = 1;

		// Token: 0x0400A964 RID: 43364
		private bool _bEventBinded;

		// Token: 0x0400A965 RID: 43365
		[Space(10f)]
		[Header("Close")]
		[SerializeField]
		private Text purchaseItemTitle;

		// Token: 0x0400A966 RID: 43366
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400A967 RID: 43367
		[Space(10f)]
		[Header("Item")]
		[SerializeField]
		private Text buyItemName;

		// Token: 0x0400A968 RID: 43368
		[SerializeField]
		private GameObject buyItemRoot;

		// Token: 0x0400A969 RID: 43369
		[SerializeField]
		private GameObject buyItemDiscountRoot;

		// Token: 0x0400A96A RID: 43370
		[SerializeField]
		private Text buyItemDiscountText;

		// Token: 0x0400A96B RID: 43371
		[SerializeField]
		private Text buyItemDescriptionText;

		// Token: 0x0400A96C RID: 43372
		[Space(15f)]
		[Header("Cost")]
		[SerializeField]
		private Text costTitle;

		// Token: 0x0400A96D RID: 43373
		[SerializeField]
		private Image costIcon;

		// Token: 0x0400A96E RID: 43374
		[SerializeField]
		private Text costNameText;

		// Token: 0x0400A96F RID: 43375
		[SerializeField]
		private Text costNumberText;

		// Token: 0x0400A970 RID: 43376
		[SerializeField]
		private ComOldChangeNewItem comOldChangeNewItem;

		// Token: 0x0400A971 RID: 43377
		[Space(15f)]
		[Header("Selected")]
		[SerializeField]
		private GameObject selectedRoot;

		// Token: 0x0400A972 RID: 43378
		[SerializeField]
		private Text leftItemNumberText;

		// Token: 0x0400A973 RID: 43379
		[SerializeField]
		private Button minButton;

		// Token: 0x0400A974 RID: 43380
		[SerializeField]
		private UIGray minButtonGray;

		// Token: 0x0400A975 RID: 43381
		[SerializeField]
		private Button minusButton;

		// Token: 0x0400A976 RID: 43382
		[SerializeField]
		private UIGray minusButtonGray;

		// Token: 0x0400A977 RID: 43383
		[SerializeField]
		private Button addButton;

		// Token: 0x0400A978 RID: 43384
		[SerializeField]
		private UIGray addButtonGray;

		// Token: 0x0400A979 RID: 43385
		[SerializeField]
		private Button maxButton;

		// Token: 0x0400A97A RID: 43386
		[SerializeField]
		private UIGray maxButtonGray;

		// Token: 0x0400A97B RID: 43387
		[SerializeField]
		private Slider selectedSlider;

		// Token: 0x0400A97C RID: 43388
		[SerializeField]
		private InputField selectedCountInputField;

		// Token: 0x0400A97D RID: 43389
		[Space(15f)]
		[Header("OldChangeNew")]
		[SerializeField]
		private GameObject OldChangeNewRoot;

		// Token: 0x0400A97E RID: 43390
		[SerializeField]
		private GameObject oldItemScrollView;

		// Token: 0x0400A97F RID: 43391
		[SerializeField]
		private GameObject oldItemScrollViewContent;

		// Token: 0x0400A980 RID: 43392
		[SerializeField]
		private ToggleGroup oldItemScrollViewGroup;

		// Token: 0x0400A981 RID: 43393
		[SerializeField]
		private GameObject oldItemPrefab;

		// Token: 0x0400A982 RID: 43394
		[SerializeField]
		private GameObject oldItemNotExistNoticeText;

		// Token: 0x0400A983 RID: 43395
		[Space(15f)]
		[Header("BuyButton")]
		[SerializeField]
		private Button buyButton;

		// Token: 0x0400A984 RID: 43396
		[SerializeField]
		private Text buyButtonText;

		// Token: 0x0400A985 RID: 43397
		[SerializeField]
		private SetComButtonCD buyButtonCD;
	}
}
