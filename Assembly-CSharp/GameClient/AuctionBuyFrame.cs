using System;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001449 RID: 5193
	internal class AuctionBuyFrame : ClientFrame
	{
		// Token: 0x0600C963 RID: 51555 RVA: 0x0030FBF7 File Offset: 0x0030DFF7
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Auction/AuctionBuyFrame";
		}

		// Token: 0x0600C964 RID: 51556 RVA: 0x0030FBFE File Offset: 0x0030DFFE
		protected override void _OnOpenFrame()
		{
			this.itemInfo = (BuyItemData)this.userData;
			this.InitInterface();
			this.BindUIEvent();
		}

		// Token: 0x0600C965 RID: 51557 RVA: 0x0030FC1D File Offset: 0x0030E01D
		protected override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
		}

		// Token: 0x0600C966 RID: 51558 RVA: 0x0030FC2B File Offset: 0x0030E02B
		private void ClearData()
		{
			this.OwnedMoney = 0L;
			this.RealMoney = 0L;
			this.limitnum = 1;
			this.MaxNum = 1;
			this.CurNum = 1;
			this.TotalCostMoney = 0L;
		}

		// Token: 0x0600C967 RID: 51559 RVA: 0x0030FC5C File Offset: 0x0030E05C
		protected void BindUIEvent()
		{
			this.mNumInput.onValueChanged.AddListener(new UnityAction<string>(this.UpdateInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.RefreshAuctionBuyFrameInfo, new ClientEventSystem.UIEventHandler(this.RefreshAuctionBuyFrameInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this.OnGoldChanged));
		}

		// Token: 0x0600C968 RID: 51560 RVA: 0x0030FCB8 File Offset: 0x0030E0B8
		protected void UnBindUIEvent()
		{
			this.mNumInput.onValueChanged.RemoveListener(new UnityAction<string>(this.UpdateInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.RefreshAuctionBuyFrameInfo, new ClientEventSystem.UIEventHandler(this.RefreshAuctionBuyFrameInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GoldChanged, new ClientEventSystem.UIEventHandler(this.OnGoldChanged));
		}

		// Token: 0x0600C969 RID: 51561 RVA: 0x0030FD14 File Offset: 0x0030E114
		private void RefreshAuctionBuyFrameInfo(UIEvent iEvent)
		{
			this.InitInterface();
		}

		// Token: 0x0600C96A RID: 51562 RVA: 0x0030FD1C File Offset: 0x0030E11C
		private void InitInterface()
		{
			this.OwnedMoney = (long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemInfo.MoneyTypeID, false);
			this.RealMoney = (long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemInfo.MoneyTypeID, true);
			this.limitnum = this.itemInfo.num;
			this.MaxNum = (int)(this.RealMoney / this.itemInfo.SinglePrice);
			this.MaxNum = ((this.MaxNum <= this.limitnum || this.limitnum <= 0) ? this.MaxNum : this.limitnum);
			this.InitShowInfo();
			this.UpdateChangedInfo();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C96B RID: 51563 RVA: 0x0030FDD4 File Offset: 0x0030E1D4
		private void UpdateInfo(string str)
		{
			if (string.IsNullOrEmpty(str) || str == "0")
			{
				this.CurNum = 1;
			}
			else
			{
				int.TryParse(str, out this.CurNum);
				if (this.CurNum > this.limitnum && this.MaxNum != 0)
				{
					this.CurNum = this.limitnum;
				}
				else if (this.MaxNum < 1)
				{
					this.CurNum = 1;
				}
			}
			this.UpdateChangedInfo();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C96C RID: 51564 RVA: 0x0030FE64 File Offset: 0x0030E264
		private void InitShowInfo()
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.itemInfo.ItemTypeID, 100, 0);
			itemData.Count = this.itemInfo.num;
			itemData.StrengthenLevel = this.itemInfo.StrengthLevel;
			AuctionNewUtility.UpdateItemDataByEquipType(itemData, this.itemInfo.EquipType, this.itemInfo.EnhanceType, this.itemInfo.EnhanceNum);
			ComItem comItem = base.CreateComItem(this.mPos);
			comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTipFrame));
			comItem.SetShowTreasure(this.itemInfo.IsTreasure == 1);
			this.mName.text = DataManager<PetDataManager>.GetInstance().GetColorName(itemData.Name, (PetTable.eQuality)itemData.Quality);
			Sprite sprite = Singleton<AssetLoader>.instance.LoadRes(DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this.itemInfo.MoneyTypeID), typeof(Sprite), true, 0U).obj as Sprite;
			if (sprite != null)
			{
				ETCImageLoader.LoadSprite(ref this.mSinglepriceIcon, DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this.itemInfo.MoneyTypeID), true);
				ETCImageLoader.LoadSprite(ref this.mTotalPriceIcon, DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this.itemInfo.MoneyTypeID), true);
				ETCImageLoader.LoadSprite(ref this.mOwnMoneyIcon, DataManager<ItemDataManager>.GetInstance().GetOwnedItemIconPath(this.itemInfo.MoneyTypeID), true);
			}
			this.mSinglePrice.text = this.itemInfo.SinglePrice.ToString();
			this.mOwnMoney.text = this.OwnedMoney.ToString();
		}

		// Token: 0x0600C96D RID: 51565 RVA: 0x00310014 File Offset: 0x0030E414
		private void UpdateChangedInfo()
		{
			this.TotalCostMoney = this.itemInfo.SinglePrice * (long)this.CurNum;
			this.mNumInput.text = this.CurNum.ToString();
			this.mTotalPrice.text = this.TotalCostMoney.ToString();
			this.UpdateOwnerMoneyColor();
		}

		// Token: 0x0600C96E RID: 51566 RVA: 0x00310078 File Offset: 0x0030E478
		private void UpdateOwnerMoneyColor()
		{
			if (this.mOwnMoney != null)
			{
				if (this.TotalCostMoney > this.OwnedMoney)
				{
					this.mOwnMoney.color = Color.red;
				}
				else
				{
					this.mOwnMoney.color = Color.white;
				}
			}
		}

		// Token: 0x0600C96F RID: 51567 RVA: 0x003100CC File Offset: 0x0030E4CC
		private void OnGoldChanged(UIEvent uiEvent)
		{
			this.OwnedMoney = (long)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(this.itemInfo.MoneyTypeID, false);
			this.mOwnMoney.text = this.OwnedMoney.ToString();
			this.UpdateOwnerMoneyColor();
		}

		// Token: 0x0600C970 RID: 51568 RVA: 0x00310118 File Offset: 0x0030E518
		private void UpdateNumButtonState()
		{
			if (this.MaxNum < 1)
			{
				this.mMinGray.enabled = true;
				this.mBtMin.interactable = false;
				this.mMinusGray.enabled = true;
				this.mBtMinus.interactable = false;
				this.mAddGray.enabled = true;
				this.mBtAdd.interactable = false;
				this.mMaxGray.enabled = true;
				this.mBtMax.interactable = false;
			}
			else
			{
				if (this.limitnum > 0)
				{
					if (this.CurNum >= this.limitnum)
					{
						this.mAddGray.enabled = true;
						this.mBtAdd.interactable = false;
						this.mMaxGray.enabled = true;
						this.mBtMax.interactable = false;
					}
					else
					{
						this.mAddGray.enabled = false;
						this.mBtAdd.interactable = true;
						this.mMaxGray.enabled = false;
						this.mBtMax.interactable = true;
					}
				}
				else if (this.CurNum >= this.MaxNum)
				{
					this.mAddGray.enabled = true;
					this.mBtAdd.interactable = false;
					this.mMaxGray.enabled = true;
					this.mBtMax.interactable = false;
				}
				else
				{
					this.mAddGray.enabled = false;
					this.mBtAdd.interactable = true;
					this.mMaxGray.enabled = false;
					this.mBtMax.interactable = true;
				}
				if (this.CurNum <= 1)
				{
					this.mMinusGray.enabled = true;
					this.mBtMinus.interactable = false;
					this.mMinGray.enabled = true;
					this.mBtMin.interactable = false;
				}
				else
				{
					this.mMinusGray.enabled = false;
					this.mBtMinus.interactable = true;
					this.mMinGray.enabled = false;
					this.mBtMin.interactable = true;
				}
			}
		}

		// Token: 0x0600C971 RID: 51569 RVA: 0x00310304 File Offset: 0x0030E704
		private void SendBuyItemReq(BuyPlace buyplace = BuyPlace.Auction)
		{
			NetManager netManager = NetManager.Instance();
			bool flag = AuctionNewUtility.IsAuctionNewTreasureRushBuy(this.itemInfo.IsTreasure, this.itemInfo.PublicEndTime);
			if (flag && this.itemInfo.IsAgainOnSale == 0)
			{
				WorldAuctionRusyBuy cmd = new WorldAuctionRusyBuy
				{
					id = this.itemInfo.guid,
					num = (uint)this.CurNum
				};
				netManager.SendCommand<WorldAuctionRusyBuy>(ServerType.GATE_SERVER, cmd);
			}
			else
			{
				WorldAuctionBuy cmd2 = new WorldAuctionBuy
				{
					id = this.itemInfo.guid,
					num = (uint)this.CurNum
				};
				netManager.SendCommand<WorldAuctionBuy>(ServerType.GATE_SERVER, cmd2);
			}
		}

		// Token: 0x0600C972 RID: 51570 RVA: 0x003103B0 File Offset: 0x0030E7B0
		protected override void _bindExUI()
		{
			this.mName = this.mBind.GetCom<Text>("Name");
			this.mPos = this.mBind.GetGameObject("Pos");
			this.mNum = this.mBind.GetCom<Text>("Num");
			this.mSinglePrice = this.mBind.GetCom<Text>("SinglePrice");
			this.mTotalPrice = this.mBind.GetCom<Text>("TotalPrice");
			this.mOwnMoney = this.mBind.GetCom<Text>("OwnMoney");
			this.mSinglepriceIcon = this.mBind.GetCom<Image>("SinglepriceIcon");
			this.mTotalPriceIcon = this.mBind.GetCom<Image>("TotalPriceIcon");
			this.mOwnMoneyIcon = this.mBind.GetCom<Image>("OwnMoneyIcon");
			this.mBtMin = this.mBind.GetCom<Button>("BtMin");
			this.mBtMin.onClick.AddListener(new UnityAction(this._onBtMinButtonClick));
			this.mBtMinus = this.mBind.GetCom<Button>("BtMinus");
			this.mBtMinus.onClick.AddListener(new UnityAction(this._onBtMinusButtonClick));
			this.mBtAdd = this.mBind.GetCom<Button>("BtAdd");
			this.mBtAdd.onClick.AddListener(new UnityAction(this._onBtAddButtonClick));
			this.mBtMax = this.mBind.GetCom<Button>("BtMax");
			this.mBtMax.onClick.AddListener(new UnityAction(this._onBtMaxButtonClick));
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtCancel = this.mBind.GetCom<Button>("BtCancel");
			this.mBtCancel.onClick.AddListener(new UnityAction(this._onBtCancelButtonClick));
			this.mBtBuy = this.mBind.GetCom<Button>("BtBuy");
			this.mBtBuy.onClick.AddListener(new UnityAction(this._onBtBuyButtonClick));
			this.mMinGray = this.mBind.GetCom<UIGray>("MinGray");
			this.mMinusGray = this.mBind.GetCom<UIGray>("MinusGray");
			this.mAddGray = this.mBind.GetCom<UIGray>("AddGray");
			this.mMaxGray = this.mBind.GetCom<UIGray>("MaxGray");
			this.mNumInput = this.mBind.GetCom<InputField>("NumInput");
		}

		// Token: 0x0600C973 RID: 51571 RVA: 0x00310650 File Offset: 0x0030EA50
		protected override void _unbindExUI()
		{
			this.mName = null;
			this.mPos = null;
			this.mNum = null;
			this.mSinglePrice = null;
			this.mTotalPrice = null;
			this.mOwnMoney = null;
			this.mSinglepriceIcon = null;
			this.mTotalPriceIcon = null;
			this.mOwnMoneyIcon = null;
			this.mBtMin.onClick.RemoveListener(new UnityAction(this._onBtMinButtonClick));
			this.mBtMin = null;
			this.mBtMinus.onClick.RemoveListener(new UnityAction(this._onBtMinusButtonClick));
			this.mBtMinus = null;
			this.mBtAdd.onClick.RemoveListener(new UnityAction(this._onBtAddButtonClick));
			this.mBtAdd = null;
			this.mBtMax.onClick.RemoveListener(new UnityAction(this._onBtMaxButtonClick));
			this.mBtMax = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
			this.mBtCancel.onClick.RemoveListener(new UnityAction(this._onBtCancelButtonClick));
			this.mBtCancel = null;
			this.mBtBuy.onClick.RemoveListener(new UnityAction(this._onBtBuyButtonClick));
			this.mBtBuy = null;
			this.mMinGray = null;
			this.mMinusGray = null;
			this.mAddGray = null;
			this.mMaxGray = null;
			this.mNumInput = null;
		}

		// Token: 0x0600C974 RID: 51572 RVA: 0x003107B4 File Offset: 0x0030EBB4
		private void _onBtMinButtonClick()
		{
			this.CurNum = 1;
			this.UpdateChangedInfo();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C975 RID: 51573 RVA: 0x003107C9 File Offset: 0x0030EBC9
		private void _onBtMinusButtonClick()
		{
			if (this.CurNum <= 1)
			{
				return;
			}
			this.CurNum--;
			this.UpdateChangedInfo();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C976 RID: 51574 RVA: 0x003107F4 File Offset: 0x0030EBF4
		private void _onBtAddButtonClick()
		{
			int maxNum;
			if (this.limitnum > 0)
			{
				maxNum = this.limitnum;
			}
			else
			{
				maxNum = this.MaxNum;
			}
			if (this.CurNum >= maxNum)
			{
				return;
			}
			this.CurNum++;
			this.UpdateChangedInfo();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C977 RID: 51575 RVA: 0x00310849 File Offset: 0x0030EC49
		private void _onBtMaxButtonClick()
		{
			if (this.limitnum > 0)
			{
				this.CurNum = this.limitnum;
			}
			else
			{
				this.CurNum = this.MaxNum;
			}
			this.UpdateChangedInfo();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C978 RID: 51576 RVA: 0x00310880 File Offset: 0x0030EC80
		private void _onBtCloseButtonClick()
		{
			this.ClearData();
			this.frameMgr.CloseFrame<AuctionBuyFrame>(this, false);
		}

		// Token: 0x0600C979 RID: 51577 RVA: 0x00310895 File Offset: 0x0030EC95
		private void _onBtCancelButtonClick()
		{
			this._onBtCloseButtonClick();
		}

		// Token: 0x0600C97A RID: 51578 RVA: 0x003108A0 File Offset: 0x0030ECA0
		private void _onBtBuyButtonClick()
		{
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = this.itemInfo.MoneyTypeID;
			costInfo.nCount = (int)this.itemInfo.SinglePrice * this.CurNum;
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				this.SendBuyItemReq(BuyPlace.Auction);
				this._onBtCloseButtonClick();
			}, "common_money_cost", null);
		}

		// Token: 0x0600C97B RID: 51579 RVA: 0x0031090C File Offset: 0x0030ED0C
		private void ShowItemTipFrame(GameObject go, ItemData itemData)
		{
			DataManager<AuctionNewDataManager>.GetInstance().OnShowItemDetailTipFrame(itemData, this.itemInfo.guid);
		}

		// Token: 0x04007452 RID: 29778
		private BuyItemData itemInfo = default(BuyItemData);

		// Token: 0x04007453 RID: 29779
		private long OwnedMoney;

		// Token: 0x04007454 RID: 29780
		private long RealMoney;

		// Token: 0x04007455 RID: 29781
		private int limitnum = 1;

		// Token: 0x04007456 RID: 29782
		private int MaxNum = 1;

		// Token: 0x04007457 RID: 29783
		private int CurNum = 1;

		// Token: 0x04007458 RID: 29784
		private long TotalCostMoney;

		// Token: 0x04007459 RID: 29785
		private Text mName;

		// Token: 0x0400745A RID: 29786
		private GameObject mPos;

		// Token: 0x0400745B RID: 29787
		private Text mNum;

		// Token: 0x0400745C RID: 29788
		private Text mSinglePrice;

		// Token: 0x0400745D RID: 29789
		private Text mTotalPrice;

		// Token: 0x0400745E RID: 29790
		private Text mOwnMoney;

		// Token: 0x0400745F RID: 29791
		private Image mSinglepriceIcon;

		// Token: 0x04007460 RID: 29792
		private Image mTotalPriceIcon;

		// Token: 0x04007461 RID: 29793
		private Image mOwnMoneyIcon;

		// Token: 0x04007462 RID: 29794
		private Button mBtMin;

		// Token: 0x04007463 RID: 29795
		private Button mBtMinus;

		// Token: 0x04007464 RID: 29796
		private Button mBtAdd;

		// Token: 0x04007465 RID: 29797
		private Button mBtMax;

		// Token: 0x04007466 RID: 29798
		private Button mBtClose;

		// Token: 0x04007467 RID: 29799
		private Button mBtCancel;

		// Token: 0x04007468 RID: 29800
		private Button mBtBuy;

		// Token: 0x04007469 RID: 29801
		private UIGray mMinGray;

		// Token: 0x0400746A RID: 29802
		private UIGray mMinusGray;

		// Token: 0x0400746B RID: 29803
		private UIGray mAddGray;

		// Token: 0x0400746C RID: 29804
		private UIGray mMaxGray;

		// Token: 0x0400746D RID: 29805
		private InputField mNumInput;
	}
}
