using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200148D RID: 5261
	public class AuctionNewOnShelfView : MonoBehaviour
	{
		// Token: 0x0600CBEA RID: 52202 RVA: 0x0031F77B File Offset: 0x0031DB7B
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CBEB RID: 52203 RVA: 0x0031F783 File Offset: 0x0031DB83
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600CBEC RID: 52204 RVA: 0x0031F794 File Offset: 0x0031DB94
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.onShelfItemButton != null)
			{
				this.onShelfItemButton.onClick.RemoveAllListeners();
				this.onShelfItemButton.onClick.AddListener(new UnityAction(this.OnItemOnShelfButtonClick));
			}
			if (this.recoverButton != null)
			{
				this.recoverButton.onClick.RemoveAllListeners();
				this.recoverButton.onClick.AddListener(new UnityAction(this.OnRecoverButtonClick));
			}
			if (this.onShelfAgainButton != null)
			{
				this.onShelfAgainButton.onClick.RemoveAllListeners();
				this.onShelfAgainButton.onClick.AddListener(new UnityAction(this.OnShelfAgainButtonClick));
			}
			if (this.addNumberButton != null)
			{
				this.addNumberButton.onClick.RemoveAllListeners();
				this.addNumberButton.onClick.AddListener(new UnityAction(this.OnAddNumberButtonClick));
			}
			if (this.minusNumberButton != null)
			{
				this.minusNumberButton.onClick.RemoveAllListeners();
				this.minusNumberButton.onClick.AddListener(new UnityAction(this.OnMinusNumberButtonClick));
			}
			if (this.addPriceButton != null)
			{
				this.addPriceButton.onClick.RemoveAllListeners();
				this.addPriceButton.onClick.AddListener(new UnityAction(this.OnAddPriceButtonClick));
			}
			if (this.minusPriceButton != null)
			{
				this.minusPriceButton.onClick.RemoveAllListeners();
				this.minusPriceButton.onClick.AddListener(new UnityAction(this.OnMinusPriceButtonClick));
			}
			if (this.treasureItemPriceKeyBoardButton != null)
			{
				this.treasureItemPriceKeyBoardButton.onClick.RemoveAllListeners();
				this.treasureItemPriceKeyBoardButton.onClick.AddListener(new UnityAction(this.OnTreasureItemPriceKeyBoardButtonClick));
			}
			if (this.normalItemNumberKeyBoardButton != null)
			{
				this.normalItemNumberKeyBoardButton.onClick.RemoveAllListeners();
				this.normalItemNumberKeyBoardButton.onClick.AddListener(new UnityAction(this.OnNormalItemNumberKeyBoardButtonClick));
			}
			if (this.normalItemPriceKeyBoardButton != null)
			{
				this.normalItemPriceKeyBoardButton.onClick.RemoveAllListeners();
				this.normalItemPriceKeyBoardButton.onClick.AddListener(new UnityAction(this.OnNormalItemPriceKeyBoardButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryItemPriceResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveWorldAuctionQueryItemPriceResSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryItemPriceListResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveWorldAuctionQueryItemPriceListResSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryItemTransListResSucceed, new ClientEventSystem.UIEventHandler(this.OnAuctionNewWorldQueryItemTransListResSucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x0600CBED RID: 52205 RVA: 0x0031FAAC File Offset: 0x0031DEAC
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.onShelfItemButton != null)
			{
				this.onShelfItemButton.onClick.RemoveAllListeners();
			}
			if (this.recoverButton != null)
			{
				this.recoverButton.onClick.RemoveAllListeners();
			}
			if (this.onShelfAgainButton != null)
			{
				this.onShelfAgainButton.onClick.RemoveAllListeners();
			}
			if (this.addNumberButton != null)
			{
				this.addNumberButton.onClick.RemoveAllListeners();
			}
			if (this.minusNumberButton != null)
			{
				this.minusNumberButton.onClick.RemoveAllListeners();
			}
			if (this.addPriceButton != null)
			{
				this.addPriceButton.onClick.RemoveAllListeners();
			}
			if (this.minusPriceButton != null)
			{
				this.minusPriceButton.onClick.RemoveAllListeners();
			}
			if (this.treasureItemPriceKeyBoardButton != null)
			{
				this.treasureItemPriceKeyBoardButton.onClick.RemoveAllListeners();
			}
			if (this.normalItemNumberKeyBoardButton != null)
			{
				this.normalItemNumberKeyBoardButton.onClick.RemoveAllListeners();
			}
			if (this.normalItemPriceKeyBoardButton != null)
			{
				this.normalItemPriceKeyBoardButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryItemPriceResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveWorldAuctionQueryItemPriceResSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryItemPriceListResSucceed, new ClientEventSystem.UIEventHandler(this.OnReceiveWorldAuctionQueryItemPriceListResSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAuctionNewWorldQueryItemTransListResSucceed, new ClientEventSystem.UIEventHandler(this.OnAuctionNewWorldQueryItemTransListResSucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCommonKeyBoardInput, new ClientEventSystem.UIEventHandler(this.OnCommonKeyBoardInput));
		}

		// Token: 0x0600CBEE RID: 52206 RVA: 0x0031FC90 File Offset: 0x0031E090
		private void ClearData()
		{
			this._auctionItemGuid = 0UL;
			this._auctionNewOnShelfItemData = null;
			this._isTreasureItem = false;
			this._onShelfItemData = null;
			this._onShelfItemTable = null;
			this._onShelfItemPricesArray = null;
			this._onShelfItemKeyBoardInputType = AuctionNewOnShelfItemKeyBoardInputType.None;
			this._onShelfItemMaxPriceRate = 0;
			this._isTimeOverItem = false;
			this._auctionBaseInfo = null;
		}

		// Token: 0x0600CBEF RID: 52207 RVA: 0x0031FCE4 File Offset: 0x0031E0E4
		public void InitView(AuctionNewOnShelfItemData auctionNewOnShelfItemData)
		{
			this.InitOnShelfItemData();
			this._auctionNewOnShelfItemData = auctionNewOnShelfItemData;
			if (this._auctionNewOnShelfItemData == null)
			{
				Logger.LogErrorFormat("AuctionNewOnShelfView InitView auctionNewOnShelfItemData is null", new object[0]);
				return;
			}
			this._auctionItemGuid = this._auctionNewOnShelfItemData.PackageItemGuid;
			this._isTreasureItem = this._auctionNewOnShelfItemData.IsTreasure;
			this._isTimeOverItem = this._auctionNewOnShelfItemData.IsTimeOverItem;
			this._auctionBaseInfo = this._auctionNewOnShelfItemData.ItemAuctionBaseInfo;
			if (this._isTimeOverItem && this._auctionBaseInfo == null)
			{
				return;
			}
			if (!this._isTimeOverItem)
			{
				this._onShelfItemData = DataManager<ItemDataManager>.GetInstance().GetItem(this._auctionItemGuid);
			}
			else
			{
				this._onShelfItemData = ItemDataManager.CreateItemDataFromTable((int)this._auctionBaseInfo.itemTypeId, 100, 0);
				if (this._onShelfItemData != null)
				{
					this._onShelfItemData.Count = (int)this._auctionBaseInfo.num;
					this._onShelfItemData.StrengthenLevel = (int)this._auctionBaseInfo.strengthed;
					this._onShelfItemData.BeadAdditiveAttributeBuffID = (int)this._auctionBaseInfo.beadbuffid;
					AuctionNewUtility.UpdateItemDataByEquipType(this._onShelfItemData, this._auctionBaseInfo);
				}
			}
			if (this._onShelfItemData == null)
			{
				Logger.LogErrorFormat("OnShelfItemData is null isTimeOverIem is {0}, itemGuid is {1}", new object[]
				{
					this._isTimeOverItem.ToString(),
					this._auctionItemGuid
				});
				return;
			}
			this._onShelfItemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._onShelfItemData.TableID, string.Empty, string.Empty);
			if (this._onShelfItemTable == null)
			{
				Logger.LogErrorFormat("OnShelfItemTable is null and itemTable id is {0}", new object[]
				{
					this._onShelfItemData.TableID
				});
				return;
			}
			if (this._onShelfItemTable.AuctionMaxPrice >= 100)
			{
				this._onShelfItemMaxPriceRate = this._onShelfItemTable.AuctionMaxPrice;
			}
			else
			{
				this._onShelfItemMaxPriceRate = 100;
			}
			if (!this._isTimeOverItem)
			{
				this._onShelfItemMaxNumber = DataManager<AuctionDataManager>.GetInstance().GetItemNumByGUID(this._auctionItemGuid, true);
			}
			else
			{
				this._onShelfItemNumber = (int)this._auctionBaseInfo.num;
				this._onShelfItemMaxNumber = this._onShelfItemNumber;
				this._onShelfItemMinNumber = this._onShelfItemNumber;
				if (this._isTreasureItem)
				{
					this._onShelfItemSinglePrice = (int)this._auctionBaseInfo.price;
				}
			}
			this.InitBaseView();
			this.InitOnShelfItemInfo();
			DataManager<AuctionNewDataManager>.GetInstance().SendWorldAuctionQueryOnShelfItemPriceReq(this._onShelfItemData);
		}

		// Token: 0x0600CBF0 RID: 52208 RVA: 0x0031FF5C File Offset: 0x0031E35C
		private void InitOnShelfItemData()
		{
			this._onShelfItemNumber = 1;
			this._onShelfItemSinglePrice = 0;
			this._onShelfItemTotalPrice = 0;
			this._onShelfItemMinSinglePrice = 0;
			this._onShelfItemMaxSinglePrice = 0;
			this._onShelfItemRecommendPrice = 0UL;
			this._onShelfItemAveragePrice = 0;
			this._onShelfItemRecommendPriceByServer = 0;
			this._onShelfItemMinNumber = 1;
			this._onShelfItemMaxNumber = 1;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(193, string.Empty, string.Empty);
			this._depositBaseValue = ((tableItem == null) ? 1 : tableItem.Value);
		}

		// Token: 0x0600CBF1 RID: 52209 RVA: 0x0031FFE4 File Offset: 0x0031E3E4
		private void InitBaseView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value((!this._isTimeOverItem) ? "auction_new_sell_item_title" : "auction_new_time_over_title_label");
			}
			if (this.otherPlayerControl != null)
			{
				this.otherPlayerControl.InitOtherPlayerControlBaseView(this._isTreasureItem, new OnSendWorldAuctionQueryItemPriceListReq(this.OnSendWorldAuctionQueryItemPriceListReq), new OnSendWorldAuctionQueryItemTransListReq(this.OnSendWorldAuctionQueryItemTransListReq));
			}
		}

		// Token: 0x0600CBF2 RID: 52210 RVA: 0x00320066 File Offset: 0x0031E466
		private void InitOnShelfItemInfo()
		{
			this.InitOnShelfItemBaseInfo();
			this.InitOnShelfItemDetailInfo();
			this.InitOnShelfButtonRoot();
		}

		// Token: 0x0600CBF3 RID: 52211 RVA: 0x0032007C File Offset: 0x0031E47C
		private void InitOnShelfItemBaseInfo()
		{
			if (this.onShelfItemName != null)
			{
				this.onShelfItemName.text = this._onShelfItemData.Name;
			}
			if (this.onShelfItemRoot != null)
			{
				ComItem comItem = this.onShelfItemRoot.GetComponentInChildren<ComItem>();
				if (comItem == null)
				{
					comItem = ComItemManager.Create(this.onShelfItemRoot);
				}
				if (comItem != null)
				{
					comItem.Setup(this._onShelfItemData, new ComItem.OnItemClicked(this.OnShowOnShelfItemData));
					comItem.SetShowTreasure(this._isTreasureItem);
				}
			}
		}

		// Token: 0x0600CBF4 RID: 52212 RVA: 0x00320118 File Offset: 0x0031E518
		private void InitOnShelfItemDetailInfo()
		{
			this.ResetOnShelfItemRoot();
			if (this._isTreasureItem)
			{
				if (this.treasureItemRoot != null)
				{
					this.treasureItemRoot.CustomActive(true);
				}
				this.InitOnShelfTreasureItem();
			}
			else
			{
				if (this.normalItemRoot != null)
				{
					this.normalItemRoot.CustomActive(true);
				}
				this.InitOnShelfNormalItem();
			}
		}

		// Token: 0x0600CBF5 RID: 52213 RVA: 0x00320184 File Offset: 0x0031E584
		private void InitOnShelfItemCommonInfo()
		{
			int num = (int)(Utility.GetCurVipLevelPrivilegeData(VipPrivilegeTable.eType.AUTION_VIP_COMMISSION_PRIVILEGE) * 100f);
			if (this._isTreasureItem)
			{
				if (this.treasureFeeTitleLabel != null)
				{
					this.treasureFeeTitleLabel.text = string.Format(TR.Value("auction_new_sell_item_noble_fee"), DataManager<PlayerBaseData>.GetInstance().VipLevel);
				}
				if (this.treasureFeeValueLabel != null)
				{
					this.treasureFeeValueLabel.text = string.Format(TR.Value("auction_new_fee_rate"), num);
				}
			}
			else
			{
				if (this.normalFeeTitleLabel != null)
				{
					this.normalFeeTitleLabel.text = string.Format(TR.Value("auction_new_sell_item_noble_fee"), DataManager<PlayerBaseData>.GetInstance().VipLevel);
				}
				if (this.normalFeeValueLabel != null)
				{
					this.normalFeeValueLabel.text = string.Format(TR.Value("auction_new_fee_rate"), num);
				}
			}
			this.UpdateItemDepositInfo();
		}

		// Token: 0x0600CBF6 RID: 52214 RVA: 0x0032028C File Offset: 0x0031E68C
		private void InitOnShelfTreasureItem()
		{
			this.InitOnShelfItemCommonInfo();
			if (this._isTimeOverItem)
			{
				this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
			}
		}

		// Token: 0x0600CBF7 RID: 52215 RVA: 0x003202AC File Offset: 0x0031E6AC
		private void InitOnShelfNormalItem()
		{
			this.InitOnShelfItemCommonInfo();
			int strengthenLevelRate = 0;
			if (AuctionNewUtility.IsMagicCardItem((uint)this._onShelfItemData.TableID))
			{
				strengthenLevelRate = AuctionNewUtility.GetMagicCardStrengthenAddition(this._onShelfItemData);
			}
			else if (this._onShelfItemData != null)
			{
				if (this._onShelfItemData.EquipType == EEquipType.ET_REDMARK)
				{
					strengthenLevelRate = AuctionNewUtility.GetRedEquipStrengthLvAdditionalPriceRate(this._onShelfItemData);
				}
				else
				{
					strengthenLevelRate = AuctionNewUtility.GetNormalEquipStrengthLvAdditionalPriceRate(this._onShelfItemData.StrengthenLevel);
				}
			}
			this._onShelfItemRecommendPrice = AuctionNewUtility.GetBasePrice((ulong)((long)this._onShelfItemTable.RecommendPrice), strengthenLevelRate);
			if (this.recommendPriceLabel != null)
			{
				if (AuctionNewUtility.IsMagicCardItem((uint)this._onShelfItemData.TableID))
				{
					this.recommendPriceLabel.text = "0";
				}
				else
				{
					this.recommendPriceLabel.text = this._onShelfItemRecommendPrice.ToString();
				}
			}
			if (this.avaragePriceLabel != null)
			{
				this.avaragePriceLabel.text = this._onShelfItemAveragePrice.ToString();
			}
			this.UpdateItemNumberInfo();
			if (this.normalItemPriceKeyBoardButton != null)
			{
				if (this._onShelfItemData.Type == ItemTable.eType.EQUIP || this._onShelfItemData.Type == ItemTable.eType.FUCKTITTLE)
				{
					this.normalItemPriceKeyBoardButton.enabled = true;
				}
				else
				{
					this.normalItemPriceKeyBoardButton.enabled = false;
				}
			}
			if (this._isTimeOverItem && this.normalItemNumberKeyBoardButton != null)
			{
				this.normalItemNumberKeyBoardButton.enabled = false;
			}
		}

		// Token: 0x0600CBF8 RID: 52216 RVA: 0x0032043F File Offset: 0x0031E83F
		private void ResetOnShelfItemRoot()
		{
			if (this.treasureItemRoot != null)
			{
				this.treasureItemRoot.CustomActive(false);
			}
			if (this.normalItemRoot != null)
			{
				this.normalItemRoot.CustomActive(false);
			}
		}

		// Token: 0x0600CBF9 RID: 52217 RVA: 0x0032047C File Offset: 0x0031E87C
		private void UpdateOnShelfItemInfo()
		{
			if (this.avaragePriceLabel != null)
			{
				this.avaragePriceLabel.text = this._onShelfItemAveragePrice.ToString();
			}
			if (this._onShelfItemData != null && AuctionNewUtility.IsMagicCardItem((uint)this._onShelfItemData.TableID) && this._onShelfItemRecommendPriceByServer > 0 && this.recommendPriceLabel != null)
			{
				this.recommendPriceLabel.text = this._onShelfItemRecommendPriceByServer.ToString();
			}
			this.UpdatePriceButtonState();
			this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
		}

		// Token: 0x0600CBFA RID: 52218 RVA: 0x00320521 File Offset: 0x0031E921
		private void UpdateOnShelfItemInfoByItemNumber(int number)
		{
			this._onShelfItemNumber = number;
			this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
		}

		// Token: 0x0600CBFB RID: 52219 RVA: 0x00320538 File Offset: 0x0031E938
		private void UpdateOnShelfItemInfoByPrice(int singlePrice)
		{
			this._onShelfItemSinglePrice = singlePrice;
			this._onShelfItemTotalPrice = this._onShelfItemSinglePrice * this._onShelfItemNumber;
			if (this._isTreasureItem)
			{
				CommonUtility.UpdateTextVisible(this.treasureItemPriceInputLabel, false);
				CommonUtility.UpdateTextVisible(this.treasureItemSinglePriceLabel, true);
				if (this.treasureItemSinglePriceLabel != null)
				{
					this.treasureItemSinglePriceLabel.text = Utility.ToThousandsSeparator((ulong)((long)this._onShelfItemSinglePrice));
				}
				if (this.treasureItemTotalPriceLabel != null)
				{
					this.treasureItemTotalPriceLabel.text = Utility.ToThousandsSeparator((ulong)((long)this._onShelfItemTotalPrice));
				}
			}
			else
			{
				if (this.normalItemSinglePriceLabel != null)
				{
					this.normalItemSinglePriceLabel.text = Utility.ToThousandsSeparator((ulong)((long)this._onShelfItemSinglePrice));
				}
				if (this.normalItemTotalPriceLabel != null)
				{
					this.normalItemTotalPriceLabel.text = Utility.ToThousandsSeparator((ulong)((long)this._onShelfItemTotalPrice));
				}
			}
			this.UpdateItemDepositInfo();
		}

		// Token: 0x0600CBFC RID: 52220 RVA: 0x00320630 File Offset: 0x0031EA30
		private void UpdateItemDepositInfo()
		{
			this._depositValue = Mathf.FloorToInt((float)this._onShelfItemTotalPrice * (float)this._depositBaseValue / 1000f);
			if (this._depositValue < 1)
			{
				this._depositValue = 1;
			}
			if (this._depositValue > 100000)
			{
				this._depositValue = 100000;
			}
			if (this._isTreasureItem)
			{
				if (this.treasureDepositValueLabel != null)
				{
					this.treasureDepositValueLabel.text = this._depositValue.ToString();
				}
			}
			else if (this.normalDepositValueLabel != null)
			{
				this.normalDepositValueLabel.text = this._depositValue.ToString();
			}
		}

		// Token: 0x0600CBFD RID: 52221 RVA: 0x003206F8 File Offset: 0x0031EAF8
		private void InitOnShelfButtonRoot()
		{
			if (this._isTimeOverItem)
			{
				if (this.normalButtonRoot != null)
				{
					this.normalButtonRoot.CustomActive(false);
				}
				if (this.timeOverButtonRoot != null)
				{
					this.timeOverButtonRoot.CustomActive(true);
				}
			}
			else
			{
				if (this.normalButtonRoot != null)
				{
					this.normalButtonRoot.CustomActive(true);
				}
				if (this.timeOverButtonRoot != null)
				{
					this.timeOverButtonRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x0600CBFE RID: 52222 RVA: 0x0032078C File Offset: 0x0031EB8C
		private void OnAuctionNewWorldQueryItemTransListResSucceed(UIEvent uiEvent)
		{
			WorldAuctionQueryItemTransListRes worldAuctionQueryItemTransListRes = DataManager<AuctionNewDataManager>.GetInstance().GetWorldAuctionQueryItemTransListRes();
			if (worldAuctionQueryItemTransListRes == null)
			{
				return;
			}
			if (this._onShelfItemData == null)
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemTransListRes.itemTypeId != (ulong)((long)this._onShelfItemData.TableID))
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemTransListRes.strengthen != (ulong)((long)this._onShelfItemData.StrengthenLevel))
			{
				return;
			}
			if (this.otherPlayerControl != null)
			{
				this.otherPlayerControl.InitOtherPlayerSellRecordItemList(worldAuctionQueryItemTransListRes.transList);
			}
		}

		// Token: 0x0600CBFF RID: 52223 RVA: 0x0032080C File Offset: 0x0031EC0C
		private void OnReceiveWorldAuctionQueryItemPriceListResSucceed(UIEvent uiEvent)
		{
			WorldAuctionQueryItemPriceListRes worldAuctionQueryItemPriceListRes = DataManager<AuctionNewDataManager>.GetInstance().GetWorldAuctionQueryItemPriceListRes();
			if (worldAuctionQueryItemPriceListRes == null)
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemPriceListRes.itemTypeId != (ulong)((long)this._onShelfItemData.TableID))
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemPriceListRes.strengthen != (ulong)((long)this._onShelfItemData.StrengthenLevel))
			{
				return;
			}
			if (worldAuctionQueryItemPriceListRes.auctionState == 1)
			{
				if (this.otherPlayerControl != null)
				{
					this.otherPlayerControl.InitOtherPlayerOnNoticeItemList(worldAuctionQueryItemPriceListRes.actionItems);
				}
			}
			else if (worldAuctionQueryItemPriceListRes.auctionState == 2 && this.otherPlayerControl != null)
			{
				this.otherPlayerControl.InitOtherPlayerOnSaleItemList(worldAuctionQueryItemPriceListRes.actionItems);
			}
		}

		// Token: 0x0600CC00 RID: 52224 RVA: 0x003208C0 File Offset: 0x0031ECC0
		private void OnReceiveWorldAuctionQueryItemPriceResSucceed(UIEvent uiEvent)
		{
			WorldAuctionQueryItemPricesRes worldAuctionQueryItemPriceRes = DataManager<AuctionNewDataManager>.GetInstance().GetWorldAuctionQueryItemPriceRes();
			if (worldAuctionQueryItemPriceRes == null)
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemPriceRes.itemTypeId != (ulong)((long)this._onShelfItemData.TableID))
			{
				return;
			}
			if ((ulong)worldAuctionQueryItemPriceRes.strengthen != (ulong)((long)this._onShelfItemData.StrengthenLevel))
			{
				return;
			}
			if (this.otherPlayerControl != null)
			{
				this.otherPlayerControl.InitOtherPlayerOnSaleItemList(worldAuctionQueryItemPriceRes.actionItems);
			}
			this._onShelfItemAveragePrice = (int)worldAuctionQueryItemPriceRes.visAverPrice;
			this._onShelfItemRecommendPriceByServer = (int)worldAuctionQueryItemPriceRes.recommendPrice;
			if (worldAuctionQueryItemPriceRes.minPrice > worldAuctionQueryItemPriceRes.maxPrice)
			{
				this._onShelfItemMinSinglePrice = (int)worldAuctionQueryItemPriceRes.maxPrice;
				this._onShelfItemMaxSinglePrice = (int)worldAuctionQueryItemPriceRes.minPrice;
			}
			else
			{
				this._onShelfItemMinSinglePrice = (int)worldAuctionQueryItemPriceRes.minPrice;
				this._onShelfItemMaxSinglePrice = (int)worldAuctionQueryItemPriceRes.maxPrice;
			}
			if (!this._isTimeOverItem)
			{
				this._onShelfItemSinglePrice = 0;
			}
			if (!this._isTreasureItem)
			{
				this._onShelfItemSinglePrice = this._onShelfItemAveragePrice;
				this._onShelfItemPricesArray = AuctionNewUtility.GetOnShelfItemPriceArray(this._onShelfItemAveragePrice, this._onShelfItemMinSinglePrice, this._onShelfItemMaxSinglePrice, this._onShelfItemMaxPriceRate);
				if (this._onShelfItemPricesArray == null || this._onShelfItemPricesArray.Length <= 0)
				{
					Logger.LogErrorFormat("AuctionNewOnShelfView OnShelfItemPrices is null or OnShelfItemPrice length is zero", new object[0]);
					return;
				}
				this._onShelfItemPricesNumber = this._onShelfItemPricesArray.Length;
				this.UpdateOnShelfItemPriceByLastTime(false);
				this.UpdateOnShelfItemInfo();
			}
			else if (!this._isTimeOverItem)
			{
				this.UpdateOnShelfItemPriceByLastTime(true);
			}
		}

		// Token: 0x0600CC01 RID: 52225 RVA: 0x00320A3C File Offset: 0x0031EE3C
		private void UpdateOnShelfItemPriceByLastTime(bool isTreasure = false)
		{
			int num = 0;
			bool flag = DataManager<AuctionNewDataManager>.GetInstance().IsOnShelfSameItemLastTime(this._onShelfItemData.TableID, this._onShelfItemData.StrengthenLevel, ref num);
			if (flag && num >= this._onShelfItemMinSinglePrice && num <= this._onShelfItemMaxSinglePrice)
			{
				this._onShelfItemSinglePrice = num;
				if (isTreasure)
				{
					this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
				}
			}
		}

		// Token: 0x0600CC02 RID: 52226 RVA: 0x00320AA8 File Offset: 0x0031EEA8
		private void OnCommonKeyBoardInput(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				Logger.LogErrorFormat("OnReceiveKeyBoardInput Error", new object[0]);
				return;
			}
			CommonKeyBoardInputType commonKeyBoardInputType = (CommonKeyBoardInputType)uiEvent.Param1;
			ulong keyBoardInputValue = (ulong)uiEvent.Param2;
			if (commonKeyBoardInputType == CommonKeyBoardInputType.ChangeNumber)
			{
				this.UpdateValueByUserInput(keyBoardInputValue);
			}
			else if (commonKeyBoardInputType == CommonKeyBoardInputType.Finished)
			{
				this.UpdateValueByFinishInput(keyBoardInputValue);
				this._onShelfItemKeyBoardInputType = AuctionNewOnShelfItemKeyBoardInputType.None;
			}
		}

		// Token: 0x0600CC03 RID: 52227 RVA: 0x00320B24 File Offset: 0x0031EF24
		private void UpdateValueByFinishInput(ulong keyBoardInputValue)
		{
			int value = (int)keyBoardInputValue;
			switch (this._onShelfItemKeyBoardInputType)
			{
			case AuctionNewOnShelfItemKeyBoardInputType.TreasureItemPrice:
				this._onShelfItemSinglePrice = CommonUtility.GetMiddleValue(value, this._onShelfItemMinSinglePrice, this._onShelfItemMaxSinglePrice);
				this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
				break;
			case AuctionNewOnShelfItemKeyBoardInputType.NormalItemNumber:
				this._onShelfItemNumber = CommonUtility.GetMiddleValue(value, this._onShelfItemMinNumber, this._onShelfItemMaxNumber);
				this.UpdateItemNumberInfo();
				this.UpdateOnShelfItemInfoByItemNumber(this._onShelfItemNumber);
				break;
			case AuctionNewOnShelfItemKeyBoardInputType.NormalItemPrice:
				this._onShelfItemSinglePrice = CommonUtility.GetMiddleValue(value, this._onShelfItemMinSinglePrice, this._onShelfItemMaxSinglePrice);
				this.UpdatePriceButtonState();
				this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
				break;
			}
		}

		// Token: 0x0600CC04 RID: 52228 RVA: 0x00320BE0 File Offset: 0x0031EFE0
		private void UpdateValueByUserInput(ulong keyBoardInputValue)
		{
			int num = (int)keyBoardInputValue;
			switch (this._onShelfItemKeyBoardInputType)
			{
			case AuctionNewOnShelfItemKeyBoardInputType.TreasureItemPrice:
				this._onShelfItemSinglePrice = num;
				this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
				break;
			case AuctionNewOnShelfItemKeyBoardInputType.NormalItemNumber:
				this._onShelfItemNumber = num;
				this.UpdateItemNumberInfo();
				this.UpdateOnShelfItemInfoByItemNumber(this._onShelfItemNumber);
				break;
			case AuctionNewOnShelfItemKeyBoardInputType.NormalItemPrice:
				this._onShelfItemSinglePrice = num;
				this.UpdatePriceButtonState();
				this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
				break;
			}
		}

		// Token: 0x0600CC05 RID: 52229 RVA: 0x00320C67 File Offset: 0x0031F067
		private void OnNormalItemNumberKeyBoardButtonClick()
		{
			this._onShelfItemKeyBoardInputType = AuctionNewOnShelfItemKeyBoardInputType.NormalItemNumber;
			CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(570f, 220f, 0f), (ulong)((long)this._onShelfItemNumber), (ulong)((long)this._onShelfItemMaxNumber));
		}

		// Token: 0x0600CC06 RID: 52230 RVA: 0x00320C97 File Offset: 0x0031F097
		private void OnNormalItemPriceKeyBoardButtonClick()
		{
			this._onShelfItemKeyBoardInputType = AuctionNewOnShelfItemKeyBoardInputType.NormalItemPrice;
			CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(650f, 130f, 0f), (ulong)((long)this._onShelfItemSinglePrice), (ulong)((long)this._onShelfItemMaxSinglePrice));
		}

		// Token: 0x0600CC07 RID: 52231 RVA: 0x00320CC7 File Offset: 0x0031F0C7
		private void OnTreasureItemPriceKeyBoardButtonClick()
		{
			this._onShelfItemKeyBoardInputType = AuctionNewOnShelfItemKeyBoardInputType.TreasureItemPrice;
			CommonUtility.OnOpenCommonKeyBoardFrame(new Vector3(650f, 130f, 0f), (ulong)((long)this._onShelfItemSinglePrice), (ulong)((long)this._onShelfItemMaxSinglePrice));
		}

		// Token: 0x0600CC08 RID: 52232 RVA: 0x00320CF8 File Offset: 0x0031F0F8
		private void OnAddNumberButtonClick()
		{
			if (this._onShelfItemNumber < this._onShelfItemMaxNumber)
			{
				this._onShelfItemNumber++;
			}
			else
			{
				this._onShelfItemNumber = this._onShelfItemMaxNumber;
			}
			this.UpdateItemNumberInfo();
			this.UpdateOnShelfItemInfoByItemNumber(this._onShelfItemNumber);
		}

		// Token: 0x0600CC09 RID: 52233 RVA: 0x00320D48 File Offset: 0x0031F148
		private void OnMinusNumberButtonClick()
		{
			if (this._onShelfItemNumber > this._onShelfItemMinNumber)
			{
				this._onShelfItemNumber--;
			}
			else
			{
				this._onShelfItemNumber = this._onShelfItemMinNumber;
			}
			this.UpdateItemNumberInfo();
			this.UpdateOnShelfItemInfoByItemNumber(this._onShelfItemNumber);
		}

		// Token: 0x0600CC0A RID: 52234 RVA: 0x00320D98 File Offset: 0x0031F198
		private void OnAddPriceButtonClick()
		{
			if (this.IsNormalItemPriceArrayInvalid())
			{
				return;
			}
			if (AuctionNewUtility.IsPriceInPriceArray(this._onShelfItemPricesArray, this._onShelfItemSinglePrice))
			{
				int num = AuctionNewUtility.GetPriceIndexInPriceArray(this._onShelfItemPricesArray, this._onShelfItemSinglePrice);
				if (num >= this._onShelfItemPricesNumber - 1)
				{
					this._onShelfItemSinglePrice = this._onShelfItemPricesArray[this._onShelfItemPricesNumber - 1];
				}
				else
				{
					num++;
					this._onShelfItemSinglePrice = this._onShelfItemPricesArray[num];
				}
			}
			else
			{
				int nextIndexInPriceArray = AuctionNewUtility.GetNextIndexInPriceArray(this._onShelfItemPricesArray, this._onShelfItemSinglePrice);
				this._onShelfItemSinglePrice = this._onShelfItemPricesArray[nextIndexInPriceArray];
			}
			this.UpdatePriceButtonState();
			this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
		}

		// Token: 0x0600CC0B RID: 52235 RVA: 0x00320E4C File Offset: 0x0031F24C
		private void OnMinusPriceButtonClick()
		{
			if (this.IsNormalItemPriceArrayInvalid())
			{
				return;
			}
			if (AuctionNewUtility.IsPriceInPriceArray(this._onShelfItemPricesArray, this._onShelfItemSinglePrice))
			{
				int num = AuctionNewUtility.GetPriceIndexInPriceArray(this._onShelfItemPricesArray, this._onShelfItemSinglePrice);
				if (num <= 0)
				{
					this._onShelfItemSinglePrice = this._onShelfItemPricesArray[0];
				}
				else
				{
					num--;
					this._onShelfItemSinglePrice = this._onShelfItemPricesArray[num];
				}
			}
			else
			{
				int preIndexInPriceArray = AuctionNewUtility.GetPreIndexInPriceArray(this._onShelfItemPricesArray, this._onShelfItemSinglePrice);
				this._onShelfItemSinglePrice = this._onShelfItemPricesArray[preIndexInPriceArray];
			}
			this.UpdatePriceButtonState();
			this.UpdateOnShelfItemInfoByPrice(this._onShelfItemSinglePrice);
		}

		// Token: 0x0600CC0C RID: 52236 RVA: 0x00320EF0 File Offset: 0x0031F2F0
		private bool IsNormalItemPriceArrayInvalid()
		{
			return this._onShelfItemAveragePrice <= 0 || this._onShelfItemPricesArray == null || this._onShelfItemPricesArray.Length <= 0;
		}

		// Token: 0x0600CC0D RID: 52237 RVA: 0x00320F1C File Offset: 0x0031F31C
		private void UpdateItemNumberInfo()
		{
			if (this.normalItemNumberLabel != null)
			{
				this.normalItemNumberLabel.text = this._onShelfItemNumber.ToString();
			}
			if (this._onShelfItemNumber <= this._onShelfItemMinNumber)
			{
				CommonUtility.UpdateButtonState(this.minusNumberButton, this.minusNumberButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.minusNumberButton, this.minusNumberButtonGray, true);
			}
			if (this._onShelfItemNumber >= this._onShelfItemMaxNumber)
			{
				CommonUtility.UpdateButtonState(this.addNumberButton, this.addNumberButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.addNumberButton, this.addNumberButtonGray, true);
			}
		}

		// Token: 0x0600CC0E RID: 52238 RVA: 0x00320FCC File Offset: 0x0031F3CC
		private void UpdatePriceButtonState()
		{
			if (this._onShelfItemSinglePrice <= this._onShelfItemMinSinglePrice)
			{
				CommonUtility.UpdateButtonState(this.minusPriceButton, this.minusPriceButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.minusPriceButton, this.minusPriceButtonGray, true);
			}
			if (this._onShelfItemSinglePrice >= this._onShelfItemMaxSinglePrice)
			{
				CommonUtility.UpdateButtonState(this.addPriceButton, this.addPriceButtonGray, false);
			}
			else
			{
				CommonUtility.UpdateButtonState(this.addPriceButton, this.addPriceButtonGray, true);
			}
		}

		// Token: 0x0600CC0F RID: 52239 RVA: 0x00321050 File Offset: 0x0031F450
		private void OnItemOnShelfButtonClick()
		{
			if (this._onShelfItemData == null)
			{
				return;
			}
			if (this._onShelfItemTable == null)
			{
				Logger.LogErrorFormat("AuctionSellFrame OnItemOnShelfButtonClick ItemTable is null and tableId is {0}", new object[]
				{
					this._onShelfItemData.TableID
				});
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (!this._isTimeOverItem && this._auctionNewOnShelfItemData.SelfOnShelfItemNum >= this._auctionNewOnShelfItemData.MaxShelfNum)
			{
				SystemNotifyManager.SystemNotify(1088, string.Empty);
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().BindGold < this._depositValue)
			{
				SystemNotifyManager.SystemNotify(1093, string.Empty);
				return;
			}
			if (this._onShelfItemNumber < 1)
			{
				SystemNotifyManager.SystemNotify(1095, string.Empty);
				return;
			}
			if (this._onShelfItemNumber > this._onShelfItemMaxNumber)
			{
				SystemNotifyManager.SystemNotify(1096, string.Empty);
				return;
			}
			if (this._onShelfItemTotalPrice < 1)
			{
				SystemNotifyManager.SystemNotify(1095, string.Empty);
				return;
			}
			if (!this._isTreasureItem && AuctionNewUtility.IsItemOwnerTimeValid(this._onShelfItemData.TableID))
			{
				if (this._isTimeOverItem)
				{
					if (this._auctionBaseInfo != null)
					{
						if (!AuctionNewUtility.IsItemInValidTimeInterval(this._auctionBaseInfo.itemDueTime))
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item_not_on_shelf_again_by_time_invalid"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
						if (!AuctionNewUtility.IsTimeItemCanOnShelf(this._auctionBaseInfo.itemDueTime))
						{
							SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item_on_shelf_time_out"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
							return;
						}
					}
				}
				else if (!AuctionNewUtility.IsTimeItemCanOnShelf((uint)this._onShelfItemData.DeadTimestamp))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item_on_shelf_time_out"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
			}
			if (this._isTimeOverItem && this._isTreasureItem && this._auctionBaseInfo != null && (ulong)this._auctionBaseInfo.price == (ulong)((long)this._onShelfItemSinglePrice))
			{
				SystemNotifyManager.SystemNotify(10016, new UnityAction(this.OnSendOnShelfReq));
				return;
			}
			bool flag;
			if (this._isTreasureItem)
			{
				flag = DataManager<AuctionNewDataManager>.GetInstance().IsShowOnShelfTipOfTreasureItem(new Action(this.OnCloseFrame), new Action(this.OnSendOnShelfReq));
			}
			else
			{
				flag = DataManager<AuctionNewDataManager>.GetInstance().IsShowOnShelfTipOfNormalItem(new Action(this.OnCloseFrame), new Action(this.OnSendOnShelfReq));
			}
			if (flag)
			{
				return;
			}
			this.SendOnShelfReq(this._onShelfItemData, this._onShelfItemTotalPrice, this._onShelfItemNumber);
			this.OnCloseFrame();
		}

		// Token: 0x0600CC10 RID: 52240 RVA: 0x003212DC File Offset: 0x0031F6DC
		private void OnSendOnShelfReq()
		{
			this.SendOnShelfReq(this._onShelfItemData, this._onShelfItemTotalPrice, this._onShelfItemNumber);
			this.OnCloseFrame();
		}

		// Token: 0x0600CC11 RID: 52241 RVA: 0x003212FC File Offset: 0x0031F6FC
		private void SendOnShelfReq(ItemData itemData, int totalPrice, int itemNumber)
		{
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemData is null", new object[0]);
				return;
			}
			if (!this._isTimeOverItem)
			{
				DataManager<AuctionNewDataManager>.GetInstance().SendOnShelfReq(itemData, totalPrice, itemNumber, 0, 0UL);
			}
			else
			{
				DataManager<AuctionNewDataManager>.GetInstance().SendOnShelfReq(itemData, totalPrice, itemNumber, 1, this._auctionItemGuid);
			}
		}

		// Token: 0x0600CC12 RID: 52242 RVA: 0x00321354 File Offset: 0x0031F754
		private void OnRecoverButtonClick()
		{
			if (!this._isTimeOverItem)
			{
				return;
			}
			if (this._auctionBaseInfo == null)
			{
				return;
			}
			DataManager<AuctionNewDataManager>.GetInstance().SendDownShelfItemRequest(this._auctionItemGuid);
			this.OnCloseFrame();
		}

		// Token: 0x0600CC13 RID: 52243 RVA: 0x00321384 File Offset: 0x0031F784
		private void OnShelfAgainButtonClick()
		{
			this.OnItemOnShelfButtonClick();
		}

		// Token: 0x0600CC14 RID: 52244 RVA: 0x0032138C File Offset: 0x0031F78C
		private void OnSendWorldAuctionQueryItemPriceListReq(byte auctionState)
		{
			DataManager<AuctionNewDataManager>.GetInstance().SendWorldAuctionQueryItemPriceListReq(auctionState, this._onShelfItemData);
		}

		// Token: 0x0600CC15 RID: 52245 RVA: 0x0032139F File Offset: 0x0031F79F
		private void OnSendWorldAuctionQueryItemTransListReq()
		{
			DataManager<AuctionNewDataManager>.GetInstance().SendWorldAuctionQueryItemTransListReq(this._onShelfItemData);
		}

		// Token: 0x0600CC16 RID: 52246 RVA: 0x003213B1 File Offset: 0x0031F7B1
		private void OnShowOnShelfItemData(GameObject obj, ItemData itemData)
		{
			if (!this._isTimeOverItem)
			{
				DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, 0UL);
			}
			else
			{
				DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, this._auctionItemGuid);
			}
		}

		// Token: 0x0600CC17 RID: 52247 RVA: 0x003213E1 File Offset: 0x0031F7E1
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewOnShelfFrame>(null, false);
		}

		// Token: 0x0400767B RID: 30331
		private ulong _auctionItemGuid;

		// Token: 0x0400767C RID: 30332
		private bool _isTreasureItem;

		// Token: 0x0400767D RID: 30333
		private AuctionNewOnShelfItemData _auctionNewOnShelfItemData;

		// Token: 0x0400767E RID: 30334
		private bool _isTimeOverItem;

		// Token: 0x0400767F RID: 30335
		private AuctionBaseInfo _auctionBaseInfo;

		// Token: 0x04007680 RID: 30336
		private ItemData _onShelfItemData;

		// Token: 0x04007681 RID: 30337
		private ItemTable _onShelfItemTable;

		// Token: 0x04007682 RID: 30338
		private ulong _onShelfItemRecommendPrice;

		// Token: 0x04007683 RID: 30339
		private int _feeValue;

		// Token: 0x04007684 RID: 30340
		private int _depositValue;

		// Token: 0x04007685 RID: 30341
		private int _onShelfItemAveragePrice;

		// Token: 0x04007686 RID: 30342
		private int _onShelfItemRecommendPriceByServer;

		// Token: 0x04007687 RID: 30343
		private int _depositBaseValue;

		// Token: 0x04007688 RID: 30344
		private int _onShelfItemNumber;

		// Token: 0x04007689 RID: 30345
		private int _onShelfItemSinglePrice;

		// Token: 0x0400768A RID: 30346
		private int _onShelfItemTotalPrice;

		// Token: 0x0400768B RID: 30347
		private const int DepositMinValue = 1;

		// Token: 0x0400768C RID: 30348
		private const int DepositMaxValue = 100000;

		// Token: 0x0400768D RID: 30349
		private int _onShelfItemMaxPriceRate;

		// Token: 0x0400768E RID: 30350
		private int _onShelfItemMinSinglePrice;

		// Token: 0x0400768F RID: 30351
		private int _onShelfItemMaxSinglePrice;

		// Token: 0x04007690 RID: 30352
		private int _onShelfItemMinNumber = 1;

		// Token: 0x04007691 RID: 30353
		private int _onShelfItemMaxNumber = 1;

		// Token: 0x04007692 RID: 30354
		private int _onShelfItemPricesNumber;

		// Token: 0x04007693 RID: 30355
		private int[] _onShelfItemPricesArray;

		// Token: 0x04007694 RID: 30356
		private AuctionNewOnShelfItemKeyBoardInputType _onShelfItemKeyBoardInputType = AuctionNewOnShelfItemKeyBoardInputType.None;

		// Token: 0x04007695 RID: 30357
		[Space(5f)]
		[Header("base")]
		[Space(5f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04007696 RID: 30358
		[SerializeField]
		private Button closeButton;

		// Token: 0x04007697 RID: 30359
		[Space(10f)]
		[Header("OtherPlayerOnShelfControl")]
		[Space(5f)]
		[SerializeField]
		private AuctionNewOtherPlayerControl otherPlayerControl;

		// Token: 0x04007698 RID: 30360
		[Space(10f)]
		[Header("ItemCommonInfo")]
		[Space(5f)]
		[SerializeField]
		private GameObject onShelfItemRoot;

		// Token: 0x04007699 RID: 30361
		[SerializeField]
		private Text onShelfItemName;

		// Token: 0x0400769A RID: 30362
		[SerializeField]
		private GameObject normalButtonRoot;

		// Token: 0x0400769B RID: 30363
		[SerializeField]
		private Button onShelfItemButton;

		// Token: 0x0400769C RID: 30364
		[SerializeField]
		private GameObject timeOverButtonRoot;

		// Token: 0x0400769D RID: 30365
		[SerializeField]
		private Button recoverButton;

		// Token: 0x0400769E RID: 30366
		[SerializeField]
		private Button onShelfAgainButton;

		// Token: 0x0400769F RID: 30367
		[Space(10f)]
		[Header("TreasureItem")]
		[Space(5f)]
		[SerializeField]
		private GameObject treasureItemRoot;

		// Token: 0x040076A0 RID: 30368
		[SerializeField]
		private Text treasureFeeTitleLabel;

		// Token: 0x040076A1 RID: 30369
		[SerializeField]
		private Text treasureFeeValueLabel;

		// Token: 0x040076A2 RID: 30370
		[SerializeField]
		private Text treasureDepositValueLabel;

		// Token: 0x040076A3 RID: 30371
		[SerializeField]
		private Text treasureItemNumberLabel;

		// Token: 0x040076A4 RID: 30372
		[SerializeField]
		private Text treasureItemPriceInputLabel;

		// Token: 0x040076A5 RID: 30373
		[SerializeField]
		private Text treasureItemSinglePriceLabel;

		// Token: 0x040076A6 RID: 30374
		[SerializeField]
		private Text treasureItemTotalPriceLabel;

		// Token: 0x040076A7 RID: 30375
		[SerializeField]
		private Button treasureItemPriceKeyBoardButton;

		// Token: 0x040076A8 RID: 30376
		[Space(10f)]
		[Header("NormalItem")]
		[Space(5f)]
		[SerializeField]
		private GameObject normalItemRoot;

		// Token: 0x040076A9 RID: 30377
		[SerializeField]
		private Text normalFeeTitleLabel;

		// Token: 0x040076AA RID: 30378
		[SerializeField]
		private Text normalFeeValueLabel;

		// Token: 0x040076AB RID: 30379
		[SerializeField]
		private Text normalDepositValueLabel;

		// Token: 0x040076AC RID: 30380
		[SerializeField]
		private Text recommendPriceLabel;

		// Token: 0x040076AD RID: 30381
		[SerializeField]
		private Text avaragePriceLabel;

		// Token: 0x040076AE RID: 30382
		[SerializeField]
		private Text normalItemNumberLabel;

		// Token: 0x040076AF RID: 30383
		[SerializeField]
		private Text normalItemSinglePriceLabel;

		// Token: 0x040076B0 RID: 30384
		[SerializeField]
		private Text normalItemTotalPriceLabel;

		// Token: 0x040076B1 RID: 30385
		[Space(10f)]
		[Header("ItemButton")]
		[Space(5f)]
		[SerializeField]
		private Button minusNumberButton;

		// Token: 0x040076B2 RID: 30386
		[SerializeField]
		private UIGray minusNumberButtonGray;

		// Token: 0x040076B3 RID: 30387
		[SerializeField]
		private Button addNumberButton;

		// Token: 0x040076B4 RID: 30388
		[SerializeField]
		private UIGray addNumberButtonGray;

		// Token: 0x040076B5 RID: 30389
		[SerializeField]
		private Button normalItemNumberKeyBoardButton;

		// Token: 0x040076B6 RID: 30390
		[SerializeField]
		private Button minusPriceButton;

		// Token: 0x040076B7 RID: 30391
		[SerializeField]
		private UIGray minusPriceButtonGray;

		// Token: 0x040076B8 RID: 30392
		[SerializeField]
		private Button addPriceButton;

		// Token: 0x040076B9 RID: 30393
		[SerializeField]
		private UIGray addPriceButtonGray;

		// Token: 0x040076BA RID: 30394
		[SerializeField]
		private Button normalItemPriceKeyBoardButton;
	}
}
