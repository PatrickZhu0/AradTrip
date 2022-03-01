using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200149A RID: 5274
	public class AuctionNewOnShelfElementItem : MonoBehaviour
	{
		// Token: 0x0600CC7C RID: 52348 RVA: 0x00323262 File Offset: 0x00321662
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600CC7D RID: 52349 RVA: 0x0032326A File Offset: 0x0032166A
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

		// Token: 0x0600CC7E RID: 52350 RVA: 0x0032329C File Offset: 0x0032169C
		private void BindEvents()
		{
			if (this.buyShelfButton != null)
			{
				this.buyShelfButton.onClick.AddListener(new UnityAction(this.OnBuyShelfButtonClick));
			}
			if (this.downShelfItemButton != null)
			{
				this.downShelfItemButton.onClick.AddListener(new UnityAction(this.OnDownShelfItemClick));
			}
		}

		// Token: 0x0600CC7F RID: 52351 RVA: 0x00323304 File Offset: 0x00321704
		private void UnBindEvents()
		{
			if (this.buyShelfButton != null)
			{
				this.buyShelfButton.onClick.RemoveAllListeners();
			}
			if (this.downShelfItemButton != null)
			{
				this.downShelfItemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600CC80 RID: 52352 RVA: 0x00323353 File Offset: 0x00321753
		private void ResetData()
		{
			this._onShelfDataModel = null;
			this._timeInterval = 0f;
			this._onShelfItemState = AuctionNewOnShelfItemState.None;
		}

		// Token: 0x0600CC81 RID: 52353 RVA: 0x0032336E File Offset: 0x0032176E
		public void InitItem(AuctionNewOnShelfDataModel onShelfDataModel)
		{
			this.ResetItemRoot();
			this._onShelfDataModel = onShelfDataModel;
			if (this._onShelfDataModel == null)
			{
				Logger.LogErrorFormat("The onShelfDataModel is null", new object[0]);
				return;
			}
			this.InitItemView();
		}

		// Token: 0x0600CC82 RID: 52354 RVA: 0x003233A0 File Offset: 0x003217A0
		private void ResetItemRoot()
		{
			if (this.emptyRoot != null)
			{
				this.emptyRoot.CustomActive(false);
			}
			if (this.buyFieldRoot != null)
			{
				this.buyFieldRoot.CustomActive(false);
			}
			if (this.sellItemRoot != null)
			{
				this.sellItemRoot.CustomActive(false);
			}
		}

		// Token: 0x0600CC83 RID: 52355 RVA: 0x00323404 File Offset: 0x00321804
		private void InitItemView()
		{
			AuctionNewOnShelfState onShelfState = this._onShelfDataModel.onShelfState;
			if (onShelfState == AuctionNewOnShelfState.Empty)
			{
				this.InitEmptyItem();
				return;
			}
			if (onShelfState == AuctionNewOnShelfState.BuyField)
			{
				this.InitBuyFieldItem();
				return;
			}
			if (onShelfState != AuctionNewOnShelfState.OwnerItem)
			{
				return;
			}
			this.InitOnShelfItem();
		}

		// Token: 0x0600CC84 RID: 52356 RVA: 0x0032344C File Offset: 0x0032184C
		private void InitEmptyItem()
		{
			if (this.emptyRoot != null)
			{
				this.emptyRoot.CustomActive(true);
			}
		}

		// Token: 0x0600CC85 RID: 52357 RVA: 0x0032346C File Offset: 0x0032186C
		private void InitBuyFieldItem()
		{
			if (this._onShelfDataModel.boothTableData == null)
			{
				Logger.LogErrorFormat("BoothTableData is null", new object[0]);
				return;
			}
			if (this.costMoneyText != null)
			{
				this.costMoneyText.text = Utility.GetShowPrice((ulong)((long)this._onShelfDataModel.boothTableData.Num), false);
			}
			if (this.costIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.costIcon, DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this._onShelfDataModel.boothTableData.CostItemID), true);
			}
			if (this.buyFieldRoot != null)
			{
				this.buyFieldRoot.CustomActive(true);
			}
		}

		// Token: 0x0600CC86 RID: 52358 RVA: 0x00323524 File Offset: 0x00321924
		private void OnBuyShelfButtonClick()
		{
			if (this._onShelfDataModel == null || this._onShelfDataModel.boothTableData == null)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(string.Format(TR.Value("auction_new_onSale_buy_shelf_cost"), this._onShelfDataModel.boothTableData.Num, DataManager<ItemDataManager>.GetInstance().GetOwnedItemName(this._onShelfDataModel.boothTableData.CostItemID)), new UnityAction(this.OnBuyShelfOk), null, 0f, false);
		}

		// Token: 0x0600CC87 RID: 52359 RVA: 0x003235B8 File Offset: 0x003219B8
		private void OnBuyShelfOk()
		{
			if (!DataManager<AuctionNewDataManager>.GetInstance().IsAuctionNewCanBuyShelfField())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_onSale_reach_max_field"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._onShelfDataModel == null || this._onShelfDataModel.boothTableData == null)
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = this._onShelfDataModel.boothTableData.CostItemID;
			costInfo.nCount = this._onShelfDataModel.boothTableData.Num;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, new Action(this.SendBuyShelfRequest), "common_money_cost", null);
		}

		// Token: 0x0600CC88 RID: 52360 RVA: 0x00323651 File Offset: 0x00321A51
		private void SendBuyShelfRequest()
		{
			DataManager<AuctionNewDataManager>.GetInstance().SendBuyShelfRequest();
		}

		// Token: 0x0600CC89 RID: 52361 RVA: 0x00323660 File Offset: 0x00321A60
		private void InitOnShelfItem()
		{
			if (this._onShelfDataModel.auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("AuctionBaseInfo is null", new object[0]);
				return;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._onShelfDataModel.auctionBaseInfo.itemTypeId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("itemTable is null", new object[0]);
				return;
			}
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this._onShelfDataModel.auctionBaseInfo.itemTypeId, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("itemData is null", new object[0]);
				return;
			}
			itemData.Count = (int)this._onShelfDataModel.auctionBaseInfo.num;
			itemData.StrengthenLevel = (int)this._onShelfDataModel.auctionBaseInfo.strengthed;
			AuctionNewUtility.UpdateItemDataByEquipType(itemData, this._onShelfDataModel.auctionBaseInfo);
			this._elementComItem = this.itemRoot.GetComponentInChildren<ComItem>();
			if (this._elementComItem == null)
			{
				this._elementComItem = ComItemManager.Create(this.itemRoot);
			}
			if (this._elementComItem != null)
			{
				this._elementComItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowOnShelfItemTips));
				bool showTreasure = this._onShelfDataModel.auctionBaseInfo.isTreas == 1;
				this._elementComItem.SetShowTreasure(showTreasure);
			}
			if (this.itemName != null)
			{
				this.itemName.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, (PetTable.eQuality)tableItem.Color);
			}
			if (this._onShelfDataModel.auctionBaseInfo.itemScore > 0U)
			{
				this.itemScore.gameObject.CustomActive(true);
				this.itemScore.text = string.Format(TR.Value("auction_new_itemDetail_score_value"), this._onShelfDataModel.auctionBaseInfo.itemScore);
			}
			else
			{
				this.itemScore.gameObject.CustomActive(false);
			}
			this.InitItemTime();
			ulong num = (ulong)this._onShelfDataModel.auctionBaseInfo.price;
			if (this._onShelfDataModel.auctionBaseInfo.num > 0U)
			{
				num = (ulong)this._onShelfDataModel.auctionBaseInfo.price / (ulong)this._onShelfDataModel.auctionBaseInfo.num;
			}
			if (this.priceValue != null)
			{
				this.priceValue.text = Utility.GetShowPrice(num, false);
				this.priceValue.text = Utility.ToThousandsSeparator(num);
			}
			if (this.sellItemRoot != null)
			{
				this.sellItemRoot.CustomActive(true);
			}
			this._onShelfItemState = this.GetOnShelfItemState();
			this.UpdateOnShelfItemViewByState();
		}

		// Token: 0x0600CC8A RID: 52362 RVA: 0x00323910 File Offset: 0x00321D10
		private void InitItemTime()
		{
			CommonUtility.UpdateGameObjectVisible(this.itemTimeRoot, false);
			if (!AuctionNewUtility.IsItemOwnerTimeValid((int)this._onShelfDataModel.auctionBaseInfo.itemTypeId))
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.itemTimeRoot, true);
			bool flag = AuctionNewUtility.IsItemInValidTimeInterval(this._onShelfDataModel.auctionBaseInfo.itemDueTime);
			if (flag)
			{
				CommonUtility.UpdateTextVisible(this.itemTimeInvalidText, false);
				CommonUtility.UpdateTextVisible(this.itemLeftTimeText, true);
				if (this.itemLeftTimeText != null)
				{
					string timeValidItemLeftTimeStr = AuctionNewUtility.GetTimeValidItemLeftTimeStr(this._onShelfDataModel.auctionBaseInfo.itemDueTime);
					this.itemLeftTimeText.text = timeValidItemLeftTimeStr;
				}
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.itemLeftTimeText, false);
				CommonUtility.UpdateTextVisible(this.itemTimeInvalidText, true);
			}
		}

		// Token: 0x0600CC8B RID: 52363 RVA: 0x003239D8 File Offset: 0x00321DD8
		private void OnDownShelfItemClick()
		{
			if (this._onShelfDataModel == null || this._onShelfDataModel.auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("onShelfDataModel is null or auctionBaseInfo is null", new object[0]);
				return;
			}
			if (this._onShelfItemState == AuctionNewOnShelfItemState.TimeOverState)
			{
				AuctionNewUtility.OpenAuctionNewOnShelfFrameByTimeOverItem(this._onShelfDataModel.auctionBaseInfo);
			}
			else
			{
				SystemNotifyManager.SystemNotify(1038, new UnityAction(this.OnDownShelfItem));
			}
		}

		// Token: 0x0600CC8C RID: 52364 RVA: 0x00323A48 File Offset: 0x00321E48
		private void OnDownShelfItem()
		{
			if (this._onShelfDataModel == null || this._onShelfDataModel.auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("onShelfDataModel is null or auctionBaseInfo is null", new object[0]);
				return;
			}
			if (this._onShelfItemState == AuctionNewOnShelfItemState.TimeOverState)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item_is_already_time_over"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
			else
			{
				if (AuctionNewUtility.IsItemOwnerTimeValid((int)this._onShelfDataModel.auctionBaseInfo.itemTypeId) && !AuctionNewUtility.IsItemInValidTimeInterval(this._onShelfDataModel.auctionBaseInfo.itemDueTime))
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item_not_back_by_time_invalid"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				DataManager<AuctionNewDataManager>.GetInstance().SendDownShelfItemRequest(this._onShelfDataModel.auctionBaseInfo.guid);
			}
		}

		// Token: 0x0600CC8D RID: 52365 RVA: 0x00323B04 File Offset: 0x00321F04
		private void ShowOnShelfItemTips(GameObject obj, ItemData itemData)
		{
			if (this._onShelfDataModel == null || this._onShelfDataModel.auctionBaseInfo == null)
			{
				Logger.LogErrorFormat("onShelfDataModel is null or auctionBaseInfo is null", new object[0]);
				return;
			}
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, this._onShelfDataModel.auctionBaseInfo.guid);
		}

		// Token: 0x0600CC8E RID: 52366 RVA: 0x00323B58 File Offset: 0x00321F58
		public void OnItemRecycle()
		{
			this.ResetData();
		}

		// Token: 0x0600CC8F RID: 52367 RVA: 0x00323B60 File Offset: 0x00321F60
		private void Update()
		{
			if (this._onShelfDataModel == null)
			{
				return;
			}
			if (this._onShelfDataModel.onShelfState != AuctionNewOnShelfState.OwnerItem)
			{
				return;
			}
			if (this._onShelfDataModel.auctionBaseInfo == null)
			{
				return;
			}
			if (this._onShelfItemState == AuctionNewOnShelfItemState.None)
			{
				return;
			}
			this._timeInterval += Time.deltaTime;
			if (this._timeInterval >= 1f)
			{
				this._timeInterval = 0f;
				this.UpdateOnShelfItemState();
			}
		}

		// Token: 0x0600CC90 RID: 52368 RVA: 0x00323BDC File Offset: 0x00321FDC
		private void UpdateOnShelfItemState()
		{
			AuctionNewOnShelfItemState onShelfItemState = this.GetOnShelfItemState();
			if (onShelfItemState == this._onShelfItemState)
			{
				return;
			}
			this._onShelfItemState = onShelfItemState;
			this.UpdateOnShelfItemViewByState();
		}

		// Token: 0x0600CC91 RID: 52369 RVA: 0x00323C0C File Offset: 0x0032200C
		public AuctionNewOnShelfItemState GetOnShelfItemState()
		{
			if (this._onShelfDataModel == null)
			{
				return AuctionNewOnShelfItemState.None;
			}
			if (this._onShelfDataModel.onShelfState != AuctionNewOnShelfState.OwnerItem)
			{
				return AuctionNewOnShelfItemState.None;
			}
			if (this._onShelfDataModel.auctionBaseInfo == null)
			{
				return AuctionNewOnShelfItemState.None;
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() <= this._onShelfDataModel.auctionBaseInfo.publicEndTime)
			{
				return AuctionNewOnShelfItemState.OnNoticeState;
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() <= this._onShelfDataModel.auctionBaseInfo.onSaleTime)
			{
				return AuctionNewOnShelfItemState.PrepareShelfState;
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() <= this._onShelfDataModel.auctionBaseInfo.duetime)
			{
				return AuctionNewOnShelfItemState.OnShelfState;
			}
			return AuctionNewOnShelfItemState.TimeOverState;
		}

		// Token: 0x0600CC92 RID: 52370 RVA: 0x00323CB0 File Offset: 0x003220B0
		private void UpdateOnShelfItemViewByState()
		{
			if (this._onShelfItemState == AuctionNewOnShelfItemState.None)
			{
				if (this.itemStateRoot != null)
				{
					this.itemStateRoot.gameObject.CustomActive(false);
				}
				return;
			}
			if (this.itemStateRoot != null)
			{
				this.itemStateRoot.gameObject.CustomActive(true);
			}
			this.ResetOnShelfItemFlag();
			switch (this._onShelfItemState)
			{
			case AuctionNewOnShelfItemState.OnNoticeState:
				if (this.noticeStateFlag != null)
				{
					this.noticeStateFlag.gameObject.CustomActive(true);
				}
				return;
			case AuctionNewOnShelfItemState.PrepareShelfState:
				if (this.prepareShelfStateFlag != null)
				{
					this.prepareShelfStateFlag.gameObject.CustomActive(true);
				}
				return;
			case AuctionNewOnShelfItemState.OnShelfState:
				if (this.onShelfStateFlag != null)
				{
					this.onShelfStateFlag.gameObject.CustomActive(true);
				}
				return;
			case AuctionNewOnShelfItemState.TimeOverState:
				if (this.timeOverStateFlag != null)
				{
					this.timeOverStateFlag.gameObject.CustomActive(true);
				}
				if (this.itemUiGray != null)
				{
					this.itemUiGray.enabled = true;
				}
				return;
			default:
				return;
			}
		}

		// Token: 0x0600CC93 RID: 52371 RVA: 0x00323DE0 File Offset: 0x003221E0
		private void ResetOnShelfItemFlag()
		{
			if (this.noticeStateFlag != null)
			{
				this.noticeStateFlag.gameObject.CustomActive(false);
			}
			if (this.onShelfStateFlag != null)
			{
				this.onShelfStateFlag.gameObject.CustomActive(false);
			}
			if (this.timeOverStateFlag != null)
			{
				this.timeOverStateFlag.gameObject.CustomActive(false);
			}
			if (this.itemUiGray != null)
			{
				this.itemUiGray.enabled = false;
			}
		}

		// Token: 0x04007703 RID: 30467
		private AuctionNewOnShelfDataModel _onShelfDataModel;

		// Token: 0x04007704 RID: 30468
		private ComItem _elementComItem;

		// Token: 0x04007705 RID: 30469
		private float _timeInterval;

		// Token: 0x04007706 RID: 30470
		private AuctionNewOnShelfItemState _onShelfItemState;

		// Token: 0x04007707 RID: 30471
		[Space(15f)]
		[Header("EmptyRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject emptyRoot;

		// Token: 0x04007708 RID: 30472
		[Space(15f)]
		[Header("buyFieldRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject buyFieldRoot;

		// Token: 0x04007709 RID: 30473
		[SerializeField]
		private Text costMoneyText;

		// Token: 0x0400770A RID: 30474
		[SerializeField]
		private Image costIcon;

		// Token: 0x0400770B RID: 30475
		[SerializeField]
		private Button buyShelfButton;

		// Token: 0x0400770C RID: 30476
		[Space(15f)]
		[Header("SellItemRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject sellItemRoot;

		// Token: 0x0400770D RID: 30477
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400770E RID: 30478
		[SerializeField]
		private Text itemName;

		// Token: 0x0400770F RID: 30479
		[SerializeField]
		private Text itemScore;

		// Token: 0x04007710 RID: 30480
		[SerializeField]
		private Text priceValue;

		// Token: 0x04007711 RID: 30481
		[SerializeField]
		private Button downShelfItemButton;

		// Token: 0x04007712 RID: 30482
		[Space(10f)]
		[Header("ItemTime")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemTimeRoot;

		// Token: 0x04007713 RID: 30483
		[SerializeField]
		private Text itemLeftTimeText;

		// Token: 0x04007714 RID: 30484
		[SerializeField]
		private Text itemTimeInvalidText;

		// Token: 0x04007715 RID: 30485
		[Space(15f)]
		[Header("ItemState")]
		[Space(10f)]
		[SerializeField]
		private GameObject itemStateRoot;

		// Token: 0x04007716 RID: 30486
		[SerializeField]
		private GameObject noticeStateFlag;

		// Token: 0x04007717 RID: 30487
		[SerializeField]
		private GameObject prepareShelfStateFlag;

		// Token: 0x04007718 RID: 30488
		[SerializeField]
		private GameObject onShelfStateFlag;

		// Token: 0x04007719 RID: 30489
		[SerializeField]
		private GameObject timeOverStateFlag;

		// Token: 0x0400771A RID: 30490
		[SerializeField]
		private UIGray itemUiGray;
	}
}
