using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A68 RID: 6760
	public class AccountShopElementItem : MonoBehaviour
	{
		// Token: 0x0601096F RID: 67951 RVA: 0x004B085E File Offset: 0x004AEC5E
		private void Awake()
		{
			this.BindUiEventSystem();
			this._InitTR();
		}

		// Token: 0x06010970 RID: 67952 RVA: 0x004B086C File Offset: 0x004AEC6C
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x06010971 RID: 67953 RVA: 0x004B087C File Offset: 0x004AEC7C
		private void BindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.AddListener(new UnityAction(this.OnBuyButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountShopItemUpdata, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamBlessShopBuySucc));
		}

		// Token: 0x06010972 RID: 67954 RVA: 0x004B08D4 File Offset: 0x004AECD4
		private void UnBindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveListener(new UnityAction(this.OnBuyButtonClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountShopItemUpdata, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamBlessShopBuySucc));
		}

		// Token: 0x06010973 RID: 67955 RVA: 0x004B092C File Offset: 0x004AED2C
		private void _InitTR()
		{
			this.tr_bless_shop_role_cannot_buy_format = TR.Value("adventure_team_shop_role_cannot_buy_format");
			this.tr_bless_shop_role_limit_buy_format = TR.Value("adventure_team_shop_role_limit_buy_format");
			this.tr_bless_shop_acc_cannot_buy_format = TR.Value("adventure_team_shop_acc_cannot_buy_format");
			this.tr_bless_shop_acc_limit_buy_format = TR.Value("adventure_team_shop_acc_limit_buy_format");
			this.tr_bless_shop_level_unlock = TR.Value("adventure_team_shop_level_unlock");
			this.tr_bless_shop_refresh_day = TR.Value("adventure_team_shop_refresh_day");
			this.tr_bless_shop_refresh_week = TR.Value("adventure_team_shop_refresh_week");
			this.tr_bless_shop_refresh_month = TR.Value("adventure_team_shop_refresh_month");
			this.tr_bless_shop_refresh_season = TR.Value("adventure_team_shop_refresh_season");
		}

		// Token: 0x06010974 RID: 67956 RVA: 0x004B09CC File Offset: 0x004AEDCC
		private void ClearData()
		{
			this.OnRecycleElementItem();
			if (this._comItem != null)
			{
				ComItemManager.Destroy(this._comItem);
				this._comItem = null;
			}
			this._limitTimeStr = null;
			this.tr_bless_shop_role_cannot_buy_format = string.Empty;
			this.tr_bless_shop_role_limit_buy_format = string.Empty;
			this.tr_bless_shop_acc_cannot_buy_format = string.Empty;
			this.tr_bless_shop_acc_limit_buy_format = string.Empty;
			this.tr_bless_shop_level_unlock = string.Empty;
			this.tr_bless_shop_refresh_day = string.Empty;
			this.tr_bless_shop_refresh_week = string.Empty;
			this.tr_bless_shop_refresh_month = string.Empty;
			this.tr_bless_shop_refresh_season = string.Empty;
			this._shopId = 0U;
			this._accShopItemInfo = null;
		}

		// Token: 0x06010975 RID: 67957 RVA: 0x004B0A7A File Offset: 0x004AEE7A
		private void InitElementItemView()
		{
			this.BindItemEventSystem();
			this.InitElementItemComItem();
			this._RefreshElementItemLimitNumber();
			this.InitElementBuyContent();
			this._RefreshElementItemLevelLimit();
		}

		// Token: 0x06010976 RID: 67958 RVA: 0x004B0A9C File Offset: 0x004AEE9C
		private void InitElementItemComItem()
		{
			if (this._shopItemData == null)
			{
				return;
			}
			if (this.itemRoot != null)
			{
				ItemData shopItemData = this._shopItemData;
				if (shopItemData.TableData != null && shopItemData.TableData.ExpireTime > 0)
				{
					shopItemData.DeadTimestamp = shopItemData.TableData.ExpireTime;
				}
				this._comItem = this.itemRoot.GetComponentInChildren<ComItem>();
				if (this._comItem == null)
				{
					this._comItem = ComItemManager.Create(this.itemRoot);
				}
				this._comItem.Setup(this._shopItemData, new ComItem.OnItemClicked(this.ShowElementItemTip));
			}
			if (this.itemName != null)
			{
				this.itemName.text = this._shopItemData.GetColorName(string.Empty, false);
			}
		}

		// Token: 0x06010977 RID: 67959 RVA: 0x004B0B78 File Offset: 0x004AEF78
		private void InitElementBuyContent()
		{
			if (this._accShopItemInfo == null)
			{
				return;
			}
			if (this.priceIcon != null)
			{
				ETCImageLoader.LoadSprite(ref this.priceIcon, this._shopCostItemData.Icon, true);
				this.priceIcon.gameObject.CustomActive(true);
			}
			this.UpdateCostValue();
		}

		// Token: 0x06010978 RID: 67960 RVA: 0x004B0BD1 File Offset: 0x004AEFD1
		private void _RefreshElementItemLimitNumber()
		{
			this._SetBuyLimitTimeText();
		}

		// Token: 0x06010979 RID: 67961 RVA: 0x004B0BDC File Offset: 0x004AEFDC
		private void _RefreshElementItemLevelLimit()
		{
			if (this._accShopItemInfo == null)
			{
				return;
			}
			ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>((int)this._shopId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.ShopKind == ShopTable.eShopKind.SK_AdventureCoin)
			{
				int extensibleCondition = (int)this._accShopItemInfo.extensibleCondition;
				if ((ulong)DataManager<AdventurerPassCardDataManager>.GetInstance().CardLv >= (ulong)((long)extensibleCondition))
				{
					this.buyContentRoot.CustomActive(true);
					this.itemLockRoot.CustomActive(false);
				}
				else
				{
					this.buyContentRoot.CustomActive(false);
					this.itemLockRoot.CustomActive(true);
					if (this.itemLockText)
					{
						this.itemLockText.text = TR.Value("adventurer_pass_card_shop_lv_limit", extensibleCondition);
					}
				}
			}
			else if ((ulong)this._accShopItemInfo.extensibleCondition <= (ulong)((long)DataManager<AdventureTeamDataManager>.GetInstance().GetAdventureTeamLevel()))
			{
				this.buyContentRoot.CustomActive(true);
				this.itemLockRoot.CustomActive(false);
			}
			else
			{
				this.buyContentRoot.CustomActive(false);
				this.itemLockRoot.CustomActive(true);
				if (this.itemLockText)
				{
					this.itemLockText.text = string.Format(this.tr_bless_shop_level_unlock, this._accShopItemInfo.extensibleCondition.ToString());
				}
			}
		}

		// Token: 0x0601097A RID: 67962 RVA: 0x004B0D34 File Offset: 0x004AF134
		private void _SetBuyLimitTimeText()
		{
			bool flag = false;
			bool flag2 = false;
			if (this._accShopItemInfo == null)
			{
				this.accBuyLimitRoot.CustomActive(flag);
				this.roleBuyLimitRoot.CustomActive(flag2);
				return;
			}
			int accShopItemBuyLimitType = (int)DataManager<AccountShopDataManager>.GetInstance().GetAccShopItemBuyLimitType(this._accShopItemInfo);
			if (accShopItemBuyLimitType == 1)
			{
				flag2 = true;
			}
			else if (accShopItemBuyLimitType == 2)
			{
				flag = true;
			}
			else if (accShopItemBuyLimitType > 2)
			{
				flag = true;
				flag2 = true;
			}
			bool flag3;
			if (this._accShopItemInfo.accountRestBuyNum > 0U)
			{
				if (flag)
				{
					this.accBuyLimitTime.SafeSetText(string.Format(this.tr_bless_shop_acc_limit_buy_format, this._GetShopRrefreshTimeTitle((AccountShopRefreshType)this._accShopItemInfo.accountRefreshType), this._accShopItemInfo.accountRestBuyNum.ToString()));
				}
				flag3 = true;
				this._SetBuySoldOutActive(false);
				this._SetBuyButtonEnable(true);
			}
			else
			{
				if (flag)
				{
					this.accBuyLimitTime.SafeSetText(this.tr_bless_shop_acc_cannot_buy_format);
				}
				flag3 = false;
				this._SetBuySoldOutActive(true);
				this._SetBuyButtonEnable(false);
			}
			this.accBuyLimitRoot.CustomActive(flag && flag3);
			bool flag4;
			if (this._accShopItemInfo.roleRestBuyNum > 0U)
			{
				if (flag2)
				{
					this.roleBuyLimitTime.SafeSetText(string.Format(this.tr_bless_shop_role_limit_buy_format, this._GetShopRrefreshTimeTitle((AccountShopRefreshType)this._accShopItemInfo.roleRefreshType), this._accShopItemInfo.roleRestBuyNum.ToString()));
				}
				if (flag && this._accShopItemInfo.accountRestBuyNum <= 0U)
				{
					flag4 = false;
					this._SetBuySoldOutActive(true);
					this._SetBuyButtonEnable(false);
				}
				else
				{
					flag4 = true;
					this._SetBuySoldOutActive(false);
					this._SetBuyButtonEnable(true);
				}
			}
			else
			{
				if (flag2)
				{
					this.roleBuyLimitTime.SafeSetText(this.tr_bless_shop_role_cannot_buy_format);
				}
				if (flag && this._accShopItemInfo.accountRestBuyNum > 0U)
				{
					flag4 = true;
					this._SetBuySoldOutActive(false);
					this._SetBuyButtonEnable(false);
				}
				else
				{
					flag4 = false;
					this._SetBuySoldOutActive(true);
					this._SetBuyButtonEnable(false);
				}
			}
			this.roleBuyLimitRoot.CustomActive(flag2 && flag4);
		}

		// Token: 0x0601097B RID: 67963 RVA: 0x004B0F4D File Offset: 0x004AF34D
		private void _SetBuyButtonEnable(bool bEnable)
		{
			if (this.buyButton)
			{
				this.buyButton.enabled = bEnable;
			}
			if (this.buyButtonGray)
			{
				this.buyButtonGray.enabled = !bEnable;
			}
		}

		// Token: 0x0601097C RID: 67964 RVA: 0x004B0F8A File Offset: 0x004AF38A
		private void _SetBuySoldOutActive(bool bEnable)
		{
			if (this.soldOverText)
			{
				this.soldOverText.CustomActive(bEnable);
			}
			if (this.priceRoot)
			{
				this.priceRoot.CustomActive(!bEnable);
			}
		}

		// Token: 0x0601097D RID: 67965 RVA: 0x004B0FC8 File Offset: 0x004AF3C8
		private void BindItemEventSystem()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Combine(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Combine(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Combine(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAdventureTeamLevelUp, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamLevelUp));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnZillionaireGameInfoChanged, new ClientEventSystem.UIEventHandler(this._OnZillionaireGameInfoChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnAnniversaryPointChanged, new ClientEventSystem.UIEventHandler(this._OnAnniversaryPointChanged));
		}

		// Token: 0x0601097E RID: 67966 RVA: 0x004B10DC File Offset: 0x004AF4DC
		private void UnBindItemEventSystem()
		{
			ItemDataManager instance = DataManager<ItemDataManager>.GetInstance();
			instance.onAddNewItem = (ItemDataManager.OnAddNewItem)Delegate.Remove(instance.onAddNewItem, new ItemDataManager.OnAddNewItem(this.OnAddNewItem));
			ItemDataManager instance2 = DataManager<ItemDataManager>.GetInstance();
			instance2.onUpdateItem = (ItemDataManager.OnUpdateItem)Delegate.Remove(instance2.onUpdateItem, new ItemDataManager.OnUpdateItem(this.OnUpdateItem));
			ItemDataManager instance3 = DataManager<ItemDataManager>.GetInstance();
			instance3.onRemoveItem = (ItemDataManager.OnRemoveItem)Delegate.Remove(instance3.onRemoveItem, new ItemDataManager.OnRemoveItem(this.OnRemoveItem));
			PlayerBaseData instance4 = DataManager<PlayerBaseData>.GetInstance();
			instance4.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance4.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAdventureTeamLevelUp, new ClientEventSystem.UIEventHandler(this._OnAdventureTeamLevelUp));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateAventurePassStatus, new ClientEventSystem.UIEventHandler(this._OnUpdateAventurePassStatus));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnZillionaireGameInfoChanged, new ClientEventSystem.UIEventHandler(this._OnZillionaireGameInfoChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnAnniversaryPointChanged, new ClientEventSystem.UIEventHandler(this._OnAnniversaryPointChanged));
		}

		// Token: 0x0601097F RID: 67967 RVA: 0x004B11F0 File Offset: 0x004AF5F0
		private void OnAddNewItem(List<Item> itemList)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemList[i].uid);
				if (item != null && item.TableID == this._shopCostItemData.TableID)
				{
					this.UpdateCostValue();
					break;
				}
			}
		}

		// Token: 0x06010980 RID: 67968 RVA: 0x004B1252 File Offset: 0x004AF652
		private void OnRemoveItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			if (itemData.TableID == this._shopCostItemData.TableID)
			{
				this.UpdateCostValue();
				return;
			}
		}

		// Token: 0x06010981 RID: 67969 RVA: 0x004B1278 File Offset: 0x004AF678
		private void OnUpdateItem(List<Item> itemList)
		{
			for (int i = 0; i < itemList.Count; i++)
			{
				ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(itemList[i].uid);
				if (item != null)
				{
					if (item.TableID == this._shopCostItemData.TableID)
					{
						this.UpdateCostValue();
						break;
					}
				}
			}
		}

		// Token: 0x06010982 RID: 67970 RVA: 0x004B12DF File Offset: 0x004AF6DF
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.UpdateCostValue();
		}

		// Token: 0x06010983 RID: 67971 RVA: 0x004B12E7 File Offset: 0x004AF6E7
		private void _OnZillionaireGameInfoChanged(UIEvent uIEvent)
		{
			this.UpdateCostValue();
		}

		// Token: 0x06010984 RID: 67972 RVA: 0x004B12EF File Offset: 0x004AF6EF
		private void _OnAnniversaryPointChanged(UIEvent uIEvent)
		{
			this.UpdateCostValue();
		}

		// Token: 0x06010985 RID: 67973 RVA: 0x004B12F7 File Offset: 0x004AF6F7
		private void _OnAdventureTeamLevelUp(UIEvent uiEvent)
		{
			this._RefreshElementItemLevelLimit();
		}

		// Token: 0x06010986 RID: 67974 RVA: 0x004B12FF File Offset: 0x004AF6FF
		private void _OnUpdateAventurePassStatus(UIEvent uiEvent)
		{
			this._RefreshElementItemLevelLimit();
		}

		// Token: 0x06010987 RID: 67975 RVA: 0x004B1308 File Offset: 0x004AF708
		private void UpdateCostValue()
		{
			if (this.priceValue == null)
			{
				return;
			}
			if (this._accShopItemInfo == null)
			{
				return;
			}
			if (this._shopCostItemData == null)
			{
				return;
			}
			ItemReward[] costItems = this._accShopItemInfo.costItems;
			if (costItems == null)
			{
				return;
			}
			foreach (ItemReward itemReward in costItems)
			{
				this.priceValue.text = itemReward.num.ToString();
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)itemReward.id, true);
				if ((long)ownedItemCount < (long)((ulong)itemReward.num))
				{
					this.priceValue.color = Color.red;
					break;
				}
				this.priceValue.color = Color.white;
			}
		}

		// Token: 0x06010988 RID: 67976 RVA: 0x004B13D0 File Offset: 0x004AF7D0
		private void _OnAdventureTeamBlessShopBuySucc(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (this._accShopItemInfo == null)
			{
				return;
			}
			AccountShopQueryIndex accountShopQueryIndex = (AccountShopQueryIndex)uiEvent.Param1;
			if (accountShopQueryIndex == null)
			{
				return;
			}
			if (this._accShopItemInfo.tabType != accountShopQueryIndex.tabType || this._accShopItemInfo.jobType != accountShopQueryIndex.jobType)
			{
				return;
			}
			this._RefreshElementItemLevelLimit();
			this._RefreshElementItemLimitNumber();
		}

		// Token: 0x06010989 RID: 67977 RVA: 0x004B143C File Offset: 0x004AF83C
		private void OnBuyButtonClick()
		{
			if (this._accShopItemInfo == null)
			{
				return;
			}
			AccountShopPurchaseItemInfo userData = new AccountShopPurchaseItemInfo(this._shopId, this._accShopItemInfo);
			Utility.DoStartFrameOperation("AccountShopElementItem", string.Format("ShopItemID/{0}", this._accShopItemInfo.shopItemId));
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AccountShopPurchaseItemFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountShopPurchaseItemFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AccountShopPurchaseItemFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0601098A RID: 67978 RVA: 0x004B14B9 File Offset: 0x004AF8B9
		private void ShowElementItemTip(GameObject go, ItemData itemData)
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0601098B RID: 67979 RVA: 0x004B14CB File Offset: 0x004AF8CB
		private string _GetShopRrefreshTimeTitle(AccountShopRefreshType refreshType)
		{
			switch (refreshType)
			{
			case AccountShopRefreshType.EachMonth:
				return this.tr_bless_shop_refresh_month;
			case AccountShopRefreshType.EachWeekend:
				return this.tr_bless_shop_refresh_week;
			case AccountShopRefreshType.EachDay:
				return this.tr_bless_shop_refresh_day;
			case AccountShopRefreshType.EachSeason:
				return this.tr_bless_shop_refresh_season;
			default:
				return string.Empty;
			}
		}

		// Token: 0x0601098C RID: 67980 RVA: 0x004B150B File Offset: 0x004AF90B
		public void OnRecycleElementItem()
		{
			this.UnBindItemEventSystem();
			this._accShopItemInfo = null;
			this._shopItemData = null;
			this._shopCostItemData = null;
		}

		// Token: 0x0601098D RID: 67981 RVA: 0x004B1528 File Offset: 0x004AF928
		public void InitElementItem(uint shopId, AccountShopItemInfo itemInfo)
		{
			this._shopId = shopId;
			this._accShopItemInfo = itemInfo;
			if (this._accShopItemInfo == null)
			{
				return;
			}
			this._shopItemData = ItemDataManager.CreateItemDataFromTable((int)this._accShopItemInfo.itemDataId, 100, 0);
			if (this._shopItemData == null)
			{
				Logger.LogErrorFormat("[AccountShopElementItem] InitElementItemData shopItemData is null and ItemId is {0}", new object[]
				{
					this._accShopItemInfo.itemDataId.ToString()
				});
				return;
			}
			this._shopItemData.Count = (int)itemInfo.itemNum;
			ItemReward[] costItems = itemInfo.costItems;
			if (costItems == null && costItems.Length == 0)
			{
				Logger.LogErrorFormat("[AccountShopElementItem] InitElementItemData shopCostItemData is null or length is 0, buy ItemId is {0}", new object[]
				{
					this._accShopItemInfo.itemDataId.ToString()
				});
				return;
			}
			this._shopCostItemData = ItemDataManager.CreateItemDataFromTable((int)costItems[0].id, 100, 0);
			if (this._shopCostItemData == null)
			{
				Logger.LogErrorFormat("ShopCostItemData is null and costItemId is {0}", new object[]
				{
					(int)costItems[0].id
				});
				return;
			}
			this.InitElementItemView();
		}

		// Token: 0x0400A935 RID: 43317
		private uint _shopId;

		// Token: 0x0400A936 RID: 43318
		private AccountShopItemInfo _accShopItemInfo;

		// Token: 0x0400A937 RID: 43319
		private ItemData _shopItemData;

		// Token: 0x0400A938 RID: 43320
		private ItemData _shopCostItemData;

		// Token: 0x0400A939 RID: 43321
		private ComItem _comItem;

		// Token: 0x0400A93A RID: 43322
		private string _limitTimeStr;

		// Token: 0x0400A93B RID: 43323
		[Space(5f)]
		[Header("NormalContent")]
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x0400A93C RID: 43324
		[SerializeField]
		private Text itemName;

		// Token: 0x0400A93D RID: 43325
		[SerializeField]
		private GameObject accBuyLimitRoot;

		// Token: 0x0400A93E RID: 43326
		[SerializeField]
		private Text accBuyLimitTime;

		// Token: 0x0400A93F RID: 43327
		[SerializeField]
		private GameObject roleBuyLimitRoot;

		// Token: 0x0400A940 RID: 43328
		[SerializeField]
		private Text roleBuyLimitTime;

		// Token: 0x0400A941 RID: 43329
		[Space(10f)]
		[Header("BuyContent")]
		[SerializeField]
		private GameObject buyContentRoot;

		// Token: 0x0400A942 RID: 43330
		[SerializeField]
		private Button buyButton;

		// Token: 0x0400A943 RID: 43331
		[SerializeField]
		private UIGray buyButtonGray;

		// Token: 0x0400A944 RID: 43332
		[SerializeField]
		private GameObject priceRoot;

		// Token: 0x0400A945 RID: 43333
		[SerializeField]
		private Image priceIcon;

		// Token: 0x0400A946 RID: 43334
		[SerializeField]
		private Text priceValue;

		// Token: 0x0400A947 RID: 43335
		[SerializeField]
		private Text soldOverText;

		// Token: 0x0400A948 RID: 43336
		[Space(10f)]
		[Header("LockContent")]
		[SerializeField]
		private GameObject itemLockRoot;

		// Token: 0x0400A949 RID: 43337
		[SerializeField]
		private Text itemLockText;

		// Token: 0x0400A94A RID: 43338
		private string tr_bless_shop_role_cannot_buy_format = string.Empty;

		// Token: 0x0400A94B RID: 43339
		private string tr_bless_shop_role_limit_buy_format = string.Empty;

		// Token: 0x0400A94C RID: 43340
		private string tr_bless_shop_acc_cannot_buy_format = string.Empty;

		// Token: 0x0400A94D RID: 43341
		private string tr_bless_shop_acc_limit_buy_format = string.Empty;

		// Token: 0x0400A94E RID: 43342
		private string tr_bless_shop_level_unlock = string.Empty;

		// Token: 0x0400A94F RID: 43343
		private string tr_bless_shop_refresh_day = string.Empty;

		// Token: 0x0400A950 RID: 43344
		private string tr_bless_shop_refresh_week = string.Empty;

		// Token: 0x0400A951 RID: 43345
		private string tr_bless_shop_refresh_month = string.Empty;

		// Token: 0x0400A952 RID: 43346
		private string tr_bless_shop_refresh_season = string.Empty;
	}
}
