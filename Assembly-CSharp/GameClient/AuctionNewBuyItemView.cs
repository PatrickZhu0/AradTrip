using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001468 RID: 5224
	public class AuctionNewBuyItemView : MonoBehaviour
	{
		// Token: 0x0600CA78 RID: 51832 RVA: 0x00318DB9 File Offset: 0x003171B9
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0600CA79 RID: 51833 RVA: 0x00318DC1 File Offset: 0x003171C1
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x0600CA7A RID: 51834 RVA: 0x00318DCF File Offset: 0x003171CF
		private void ClearData()
		{
			this._buyItemDataModel = null;
			this._currentBuyNumber = 1;
			this._maxBuyNumber = 1;
			this._ownerMoney = 1L;
			this._totalCostMoney = 1L;
			this._itemData = null;
		}

		// Token: 0x0600CA7B RID: 51835 RVA: 0x00318E00 File Offset: 0x00317200
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
				this.cancelButton.onClick.AddListener(new UnityAction(this.OnCancelButtonClick));
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClick));
			}
			if (this.itemNumberMaxButton != null)
			{
				this.itemNumberMaxButton.onClick.RemoveAllListeners();
				this.itemNumberMaxButton.onClick.AddListener(new UnityAction(this.OnItemNumberMaxButtonClick));
			}
			if (this.itemNumberKeyBoardButton != null)
			{
				this.itemNumberKeyBoardButton.onClick.RemoveAllListeners();
				this.itemNumberKeyBoardButton.onClick.AddListener(new UnityAction(this.OnItemNumberKeyBoardButtonClick));
			}
		}

		// Token: 0x0600CA7C RID: 51836 RVA: 0x00318F40 File Offset: 0x00317340
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.cancelButton != null)
			{
				this.cancelButton.onClick.RemoveAllListeners();
			}
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			if (this.itemNumberMaxButton != null)
			{
				this.itemNumberMaxButton.onClick.RemoveAllListeners();
			}
			if (this.itemNumberKeyBoardButton != null)
			{
				this.itemNumberKeyBoardButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CA7D RID: 51837 RVA: 0x00318FF2 File Offset: 0x003173F2
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this.OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x0600CA7E RID: 51838 RVA: 0x00319027 File Offset: 0x00317427
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x0600CA7F RID: 51839 RVA: 0x0031905C File Offset: 0x0031745C
		public void Init(AuctionNewBuyItemDataModel buyItemDataModel)
		{
			this._buyItemDataModel = buyItemDataModel;
			if (this._buyItemDataModel == null)
			{
				return;
			}
			this._itemData = ItemDataManager.CreateItemDataFromTable(this._buyItemDataModel.ItemTypeId, 100, 0);
			if (this._itemData == null || this._itemData.TableData == null)
			{
				return;
			}
			this.InitData();
			this.InitView();
		}

		// Token: 0x0600CA80 RID: 51840 RVA: 0x003190BD File Offset: 0x003174BD
		private void InitData()
		{
			this._currentBuyNumber = 1;
			this.UpdateOwnerMoneyAndMaxNumber();
		}

		// Token: 0x0600CA81 RID: 51841 RVA: 0x003190CC File Offset: 0x003174CC
		private void UpdateOwnerMoneyAndMaxNumber()
		{
			this._ownerMoney = (long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._buyItemDataModel.MoneyTypeId, false);
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this._buyItemDataModel.MoneyTypeId, false);
			if (this._buyItemDataModel.SinglePrice <= 0L)
			{
				this._maxBuyNumber = 1;
			}
			else
			{
				this._maxBuyNumber = (int)((long)ownedItemCount / this._buyItemDataModel.SinglePrice);
			}
			if (this._buyItemDataModel.Number > 0 && this._buyItemDataModel.Number < this._maxBuyNumber)
			{
				this._maxBuyNumber = this._buyItemDataModel.Number;
			}
		}

		// Token: 0x0600CA82 RID: 51842 RVA: 0x00319178 File Offset: 0x00317578
		private void InitView()
		{
			this.InitItemInfo();
			this.InitPriceImage();
			this.InitSinglePrice();
			this.UpdateTotalPrice();
			this.UpdateOwnerMoney();
			this.UpdateBuyItemNumber();
			this.UpdateItemNumberMaxButtonState();
		}

		// Token: 0x0600CA83 RID: 51843 RVA: 0x003191A4 File Offset: 0x003175A4
		private void InitItemInfo()
		{
			if (this.itemRoot != null)
			{
				this._itemData.Count = this._buyItemDataModel.Number;
				this._itemData.StrengthenLevel = this._buyItemDataModel.StrengthLevel;
				AuctionNewUtility.UpdateItemDataByEquipType(this._itemData, this._buyItemDataModel.EquipType, this._buyItemDataModel.EnhanceType, this._buyItemDataModel.EnhanceNum);
				this._itemData.ItemTradeNumber = (int)this._buyItemDataModel.ItemTradeNumber;
				ComItem comItem = ComItemManager.Create(this.itemRoot);
				if (comItem != null)
				{
					comItem.Setup(this._itemData, new ComItem.OnItemClicked(this.ShowItemTipFrame));
					comItem.SetShowTreasure(this._buyItemDataModel.IsTreasure == 1);
				}
			}
			if (this.itemNameText != null)
			{
				this.itemNameText.text = AuctionNewUtility.GetQualityColorString(this._itemData.Name, this._itemData.TableData.Color);
			}
		}

		// Token: 0x0600CA84 RID: 51844 RVA: 0x003192BC File Offset: 0x003176BC
		private void InitPriceImage()
		{
			string ownedItemIconPath = DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this._buyItemDataModel.MoneyTypeId);
			if (this.singlePriceImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.singlePriceImage, ownedItemIconPath, true);
			}
			if (this.totalPriceImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.totalPriceImage, ownedItemIconPath, true);
			}
			if (this.ownerMoneyImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.ownerMoneyImage, ownedItemIconPath, true);
			}
		}

		// Token: 0x0600CA85 RID: 51845 RVA: 0x0031933C File Offset: 0x0031773C
		private void InitSinglePrice()
		{
			if (this.singlePriceValueText != null)
			{
				this.singlePriceValueText.text = this._buyItemDataModel.SinglePrice.ToString();
			}
		}

		// Token: 0x0600CA86 RID: 51846 RVA: 0x00319370 File Offset: 0x00317770
		private void UpdateTotalPrice()
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			if (this.totalPriceValueText == null)
			{
				return;
			}
			long num = this._buyItemDataModel.SinglePrice * (long)this._currentBuyNumber;
			this.totalPriceValueText.text = num.ToString();
			this.UpdateOwnerMoney();
		}

		// Token: 0x0600CA87 RID: 51847 RVA: 0x003193D0 File Offset: 0x003177D0
		private void UpdateOwnerMoney()
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			if (this.ownerMoneyValueText == null)
			{
				return;
			}
			this.ownerMoneyValueText.text = this._ownerMoney.ToString();
			long num = this._buyItemDataModel.SinglePrice * (long)this._currentBuyNumber;
			if (num > this._ownerMoney)
			{
				this.ownerMoneyValueText.color = Color.red;
			}
			else
			{
				this.ownerMoneyValueText.color = Color.white;
			}
		}

		// Token: 0x0600CA88 RID: 51848 RVA: 0x0031945C File Offset: 0x0031785C
		private void UpdateBuyItemNumber()
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			if (this.buyItemNumberText == null)
			{
				return;
			}
			this.buyItemNumberText.text = this._currentBuyNumber.ToString();
		}

		// Token: 0x0600CA89 RID: 51849 RVA: 0x00319498 File Offset: 0x00317898
		private void OnItemNumberMaxButtonClick()
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			this._currentBuyNumber = this._maxBuyNumber;
			this.UpdateItemNumberMaxButtonState();
			this.UpdateTotalPrice();
			this.UpdateBuyItemNumber();
		}

		// Token: 0x0600CA8A RID: 51850 RVA: 0x003194C4 File Offset: 0x003178C4
		private void UpdateItemNumberMaxButtonState()
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			if (this._currentBuyNumber < this._maxBuyNumber)
			{
				CommonUtility.UpdateButtonState(this.itemNumberMaxButton, this.itemNumberMaxButtonGray, true);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.itemNumberMaxButton, this.itemNumberMaxButtonGray, false);
			}
		}

		// Token: 0x0600CA8B RID: 51851 RVA: 0x00319517 File Offset: 0x00317917
		private void OnMoneyChanged(UIEvent uiEvent)
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			this.UpdateOwnerMoneyAndMaxNumber();
			this.UpdateOwnerMoney();
			this.UpdateItemNumberMaxButtonState();
		}

		// Token: 0x0600CA8C RID: 51852 RVA: 0x00319538 File Offset: 0x00317938
		private void OnCommonKeyBoardInput(UIEvent uiEvent)
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			CommonKeyBoardInputType commonKeyBoardInputType = (CommonKeyBoardInputType)uiEvent.Param1;
			this._currentBuyNumber = (int)((ulong)uiEvent.Param2);
			if (this._currentBuyNumber <= 0)
			{
				this._currentBuyNumber = 1;
			}
			else if (this._currentBuyNumber >= this._maxBuyNumber)
			{
				this._currentBuyNumber = this._maxBuyNumber;
			}
			this.UpdateTotalPrice();
			this.UpdateBuyItemNumber();
			this.UpdateItemNumberMaxButtonState();
		}

		// Token: 0x0600CA8D RID: 51853 RVA: 0x003195D4 File Offset: 0x003179D4
		private void OnBuyButtonClick()
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			bool flag = ItemDataUtility.IsItemTradeLimitBuyNumber(this._itemData);
			if (!flag)
			{
				this.OnBuyItem();
				return;
			}
			int itemTradeLeftTime = ItemDataUtility.GetItemTradeLeftTime(this._itemData);
			if (itemTradeLeftTime <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item__trade_number_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			string contentStr = string.Format(TR.Value("auction_new_item_on_buy_with_trade_number"), itemTradeLeftTime);
			AuctionNewUtility.OnShowItemTradeLimitFrame(contentStr, new Action(this.OnBuyItem));
		}

		// Token: 0x0600CA8E RID: 51854 RVA: 0x0031965C File Offset: 0x00317A5C
		private void OnBuyItem()
		{
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = this._buyItemDataModel.MoneyTypeId;
			costInfo.nCount = (int)this._buyItemDataModel.SinglePrice * this._currentBuyNumber;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				this.SendBuyItemReq();
				this.OnCloseFrame();
			}, "common_money_cost", null);
		}

		// Token: 0x0600CA8F RID: 51855 RVA: 0x003196B8 File Offset: 0x00317AB8
		private void SendBuyItemReq()
		{
			NetManager netManager = NetManager.Instance();
			bool flag = AuctionNewUtility.IsAuctionNewTreasureRushBuy(this._buyItemDataModel.IsTreasure, this._buyItemDataModel.PublicEndTime);
			if (flag && this._buyItemDataModel.IsAgainOnSale == 0)
			{
				WorldAuctionRusyBuy cmd = new WorldAuctionRusyBuy
				{
					id = this._buyItemDataModel.Guid,
					num = (uint)this._currentBuyNumber
				};
				netManager.SendCommand<WorldAuctionRusyBuy>(ServerType.GATE_SERVER, cmd);
			}
			else
			{
				WorldAuctionBuy cmd2 = new WorldAuctionBuy
				{
					id = this._buyItemDataModel.Guid,
					num = (uint)this._currentBuyNumber
				};
				netManager.SendCommand<WorldAuctionBuy>(ServerType.GATE_SERVER, cmd2);
			}
		}

		// Token: 0x0600CA90 RID: 51856 RVA: 0x00319764 File Offset: 0x00317B64
		private void OnItemNumberKeyBoardButtonClick()
		{
			CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(680f, 116f, 0f), (ulong)((long)this._currentBuyNumber), (ulong)((long)this._maxBuyNumber));
		}

		// Token: 0x0600CA91 RID: 51857 RVA: 0x0031978D File Offset: 0x00317B8D
		private void OnCloseButtonClick()
		{
			this.OnCloseFrame();
		}

		// Token: 0x0600CA92 RID: 51858 RVA: 0x00319795 File Offset: 0x00317B95
		private void OnCancelButtonClick()
		{
			this.OnCloseFrame();
		}

		// Token: 0x0600CA93 RID: 51859 RVA: 0x0031979D File Offset: 0x00317B9D
		private void OnCloseFrame()
		{
			AuctionNewUtility.OnCloseAuctionNewBuyItemFrame();
		}

		// Token: 0x0600CA94 RID: 51860 RVA: 0x003197A4 File Offset: 0x00317BA4
		private void ShowItemTipFrame(GameObject go, ItemData itemData)
		{
			if (this._buyItemDataModel == null)
			{
				return;
			}
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, this._buyItemDataModel.Guid);
		}

		// Token: 0x04007594 RID: 30100
		private AuctionNewBuyItemDataModel _buyItemDataModel;

		// Token: 0x04007595 RID: 30101
		private int _currentBuyNumber = 1;

		// Token: 0x04007596 RID: 30102
		private int _maxBuyNumber = 1;

		// Token: 0x04007597 RID: 30103
		private long _ownerMoney = 1L;

		// Token: 0x04007598 RID: 30104
		private long _totalCostMoney = 1L;

		// Token: 0x04007599 RID: 30105
		private ItemData _itemData;

		// Token: 0x0400759A RID: 30106
		[Space(15f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text itemNameText;

		// Token: 0x0400759B RID: 30107
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400759C RID: 30108
		[Space(15f)]
		[Header("Money")]
		[Space(10f)]
		[SerializeField]
		private Image singlePriceImage;

		// Token: 0x0400759D RID: 30109
		[SerializeField]
		private Text singlePriceValueText;

		// Token: 0x0400759E RID: 30110
		[SerializeField]
		private Image totalPriceImage;

		// Token: 0x0400759F RID: 30111
		[SerializeField]
		private Text totalPriceValueText;

		// Token: 0x040075A0 RID: 30112
		[SerializeField]
		private Image ownerMoneyImage;

		// Token: 0x040075A1 RID: 30113
		[SerializeField]
		private Text ownerMoneyValueText;

		// Token: 0x040075A2 RID: 30114
		[Space(15f)]
		[Header("BuyNumber")]
		[Space(10f)]
		[SerializeField]
		private Text buyItemNumberText;

		// Token: 0x040075A3 RID: 30115
		[SerializeField]
		private Button itemNumberMaxButton;

		// Token: 0x040075A4 RID: 30116
		[SerializeField]
		private UIGray itemNumberMaxButtonGray;

		// Token: 0x040075A5 RID: 30117
		[SerializeField]
		private Button itemNumberKeyBoardButton;

		// Token: 0x040075A6 RID: 30118
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button cancelButton;

		// Token: 0x040075A7 RID: 30119
		[SerializeField]
		private Button buyButton;

		// Token: 0x040075A8 RID: 30120
		[SerializeField]
		private Button closeButton;
	}
}
