using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A6E RID: 6766
	public class AccountShopView : ShopBaseView
	{
		// Token: 0x060109C3 RID: 68035 RVA: 0x004B2728 File Offset: 0x004B0B28
		private void Awake()
		{
			this._BindUIEvent();
			this._InitData();
		}

		// Token: 0x060109C4 RID: 68036 RVA: 0x004B2736 File Offset: 0x004B0B36
		private void OnDestroy()
		{
			this._UnBindUIEvent();
			this._ClearData();
			this._PlayShopNpcSound(NpcVoiceComponent.SoundEffectType.SET_End);
		}

		// Token: 0x060109C5 RID: 68037 RVA: 0x004B274C File Offset: 0x004B0B4C
		private void _BindUIEvent()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.shopItemList != null && !this.shopItemList.IsInitialised())
			{
				this.shopItemList.Initialize();
				ComUIListScript comUIListScript = this.shopItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
				ComUIListScript comUIListScript2 = this.shopItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnElementItemRecycle));
			}
			if (this.shopTabItemList != null && !this.shopTabItemList.IsInitialised())
			{
				this.shopTabItemList.Initialize();
				ComUIListScript comUIListScript3 = this.shopTabItemList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountShopUpdate, new ClientEventSystem.UIEventHandler(this._OnShopGoodsRefresh));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountShopItemUpdata, new ClientEventSystem.UIEventHandler(this._OnShopGoodsRefresh));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountShopReqFailed, new ClientEventSystem.UIEventHandler(this._OnShopGoodsRefresh));
		}

		// Token: 0x060109C6 RID: 68038 RVA: 0x004B28A4 File Offset: 0x004B0CA4
		private void _UnBindUIEvent()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.shopTabItemList != null)
			{
				this.shopTabItemList.SetElementAmount(0);
				ComUIListScript comUIListScript = this.shopTabItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
				this.shopTabItemList.UnInitialize();
			}
			if (this.shopItemList != null)
			{
				this.shopItemList.SetElementAmount(0);
				ComUIListScript comUIListScript2 = this.shopItemList;
				comUIListScript2.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript2.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
				ComUIListScript comUIListScript3 = this.shopItemList;
				comUIListScript3.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript3.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnElementItemRecycle));
				this.shopItemList.UnInitialize();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountShopUpdate, new ClientEventSystem.UIEventHandler(this._OnShopGoodsRefresh));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountShopItemUpdata, new ClientEventSystem.UIEventHandler(this._OnShopGoodsRefresh));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountShopReqFailed, new ClientEventSystem.UIEventHandler(this._OnShopGoodsRefresh));
		}

		// Token: 0x060109C7 RID: 68039 RVA: 0x004B29F4 File Offset: 0x004B0DF4
		protected sealed override void _InitData()
		{
			this.tr_bless_shop_no_goods_tip = TR.Value("adventure_team_shop_no_goods_tips");
			this.tr_acc_shop_refresh_time_format = TR.Value("adventure_team_shop_refresh_next_time_format");
		}

		// Token: 0x060109C8 RID: 68040 RVA: 0x004B2A16 File Offset: 0x004B0E16
		protected sealed override void _ClearData()
		{
			this.tr_bless_shop_no_goods_tip = string.Empty;
			this.tr_acc_shop_refresh_time_format = string.Empty;
			if (this._mFrameCommonData != null)
			{
				this._mFrameCommonData.Clear();
				this._mFrameCommonData = null;
			}
			DataManager<ShopNewDataManager>.GetInstance().ClearData();
		}

		// Token: 0x060109C9 RID: 68041 RVA: 0x004B2A55 File Offset: 0x004B0E55
		protected sealed override void _InitShopView()
		{
			base._InitShopView();
		}

		// Token: 0x060109CA RID: 68042 RVA: 0x004B2A60 File Offset: 0x004B0E60
		protected sealed override void _InitShopTitle()
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			if (this.shopNameText)
			{
				this.shopNameText.text = DataManager<AccountShopDataManager>.GetInstance().GetShopName(this._mFrameCommonData.shopId);
			}
			int shopHelpId = DataManager<AccountShopDataManager>.GetInstance().GetShopHelpId(this._mFrameCommonData.shopId);
			if (shopHelpId <= 0)
			{
				this.helpButton.CustomActive(false);
			}
			else
			{
				this.helpButton.CustomActive(true);
				HelpAssistant component = this.helpButton.GetComponent<HelpAssistant>();
				if (component != null)
				{
					component.eType = (HelpFrame.HelpType)shopHelpId;
				}
			}
		}

		// Token: 0x060109CB RID: 68043 RVA: 0x004B2B04 File Offset: 0x004B0F04
		protected sealed override void _InitShopTabList()
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			this._mFrameCommonData.totalTabDataList = DataManager<ShopNewDataManager>.GetInstance().GetShopNewMainTabDataList(this._mFrameCommonData.shopId);
			List<ShopNewMainTabData> totalTabDataList = this._mFrameCommonData.totalTabDataList;
			if (totalTabDataList == null)
			{
				Logger.LogErrorFormat("[AccountShopView] - _InitShopTabList failed, shopid is {0}", new object[]
				{
					this._mFrameCommonData.shopId
				});
				return;
			}
			for (int i = 0; i < totalTabDataList.Count; i++)
			{
				ShopNewMainTabData shopNewMainTabData = totalTabDataList[i];
				if (shopNewMainTabData != null)
				{
					if (shopNewMainTabData.MainTabType == this._mFrameCommonData.defaultSelectedTabData.MainTabType && shopNewMainTabData.Index == this._mFrameCommonData.defaultSelectedTabData.Index)
					{
						this._mFrameCommonData.defaultSelectedTabIndex = i;
						break;
					}
				}
			}
			if (this.shopTabItemList != null)
			{
				this.shopTabItemList.SetElementAmount(this._mFrameCommonData.totalTabDataList.Count);
			}
		}

		// Token: 0x060109CC RID: 68044 RVA: 0x004B2C10 File Offset: 0x004B1010
		protected sealed override void _InitShopMoneyView()
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			if (this.consumeItemGroup != null)
			{
				this.consumeItemGroup.SetAllItemActive(false);
			}
		}

		// Token: 0x060109CD RID: 68045 RVA: 0x004B2C3C File Offset: 0x004B103C
		protected sealed override void _PlayShopNpcSound(NpcVoiceComponent.SoundEffectType soundEffType)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (this._mFrameCommonData == null)
			{
				return;
			}
			if (this._mFrameCommonData.npcId <= 0)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this._mFrameCommonData.npcId, string.Empty, string.Empty) == null)
			{
				return;
			}
			clientSystemTown.PlayNpcSound(this._mFrameCommonData.npcId, soundEffType);
		}

		// Token: 0x060109CE RID: 68046 RVA: 0x004B2CB8 File Offset: 0x004B10B8
		private void _RefreshShopItemRefreshTimeDesc(int shopId)
		{
			if (this._mFrameCommonData != null && this.shopRefreshLabel != null)
			{
				string shopRefreshTimeDesc = DataManager<AccountShopDataManager>.GetInstance().GetShopRefreshTimeDesc(shopId);
				if (!string.IsNullOrEmpty(shopRefreshTimeDesc))
				{
					this.shopRefreshLabel.text = shopRefreshTimeDesc;
					this.shopRefreshLabel.enabled = true;
				}
				else
				{
					this.shopRefreshLabel.enabled = false;
					this.shopRefreshLabel.text = string.Empty;
				}
			}
		}

		// Token: 0x060109CF RID: 68047 RVA: 0x004B2D34 File Offset: 0x004B1134
		private void _RefreshShopItemRefreshTime(AccountShopItemInfo[] accShopItemInfos)
		{
			if (this.shopRefreshLabel != null && this.shopRefreshLabel.enabled)
			{
				return;
			}
			if (accShopItemInfos == null)
			{
				return;
			}
			int accountShopRefreshTime = DataManager<AccountShopDataManager>.GetInstance().GetAccountShopRefreshTime(accShopItemInfos, AccountShopPurchaseType.AccountBind, false);
			if (this.shopTimeRefreshControl)
			{
				if (accountShopRefreshTime > 0)
				{
					this.shopTimeRefreshControl.Initialize();
					this.shopTimeRefreshControl.SetFormatString(this.tr_acc_shop_refresh_time_format);
					this.shopTimeRefreshControl.Time = (uint)accountShopRefreshTime;
					this.shopTimeRefreshControl.enabled = true;
					if (this.shopTimeRefreshControl.text)
					{
						this.shopTimeRefreshControl.text.enabled = true;
					}
				}
				else
				{
					this.shopTimeRefreshControl.enabled = false;
					if (this.shopTimeRefreshControl.text)
					{
						this.shopTimeRefreshControl.text.enabled = false;
					}
				}
			}
		}

		// Token: 0x060109D0 RID: 68048 RVA: 0x004B2E20 File Offset: 0x004B1220
		private void _RefreshConsumeItemGroup(int shopId)
		{
			if (this.consumeItemGroup != null)
			{
				List<int> shopBaseMoneyIds = DataManager<AccountShopDataManager>.GetInstance().GetShopBaseMoneyIds(shopId, 0);
				if (shopBaseMoneyIds == null || shopBaseMoneyIds.Count <= 0)
				{
					return;
				}
				this.consumeItemGroup.ResetSelectedItemIds(shopBaseMoneyIds.ToArray(), false, true, ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue);
			}
		}

		// Token: 0x060109D1 RID: 68049 RVA: 0x004B2E74 File Offset: 0x004B1274
		private void _RefreshConsumeItemGroup(AccountShopItemInfo[] accShopItemInfos)
		{
			if (this.consumeItemGroup != null)
			{
				if (accShopItemInfos == null)
				{
					return;
				}
				List<int> shopExtraMoneyIds = DataManager<AccountShopDataManager>.GetInstance().GetShopExtraMoneyIds(accShopItemInfos);
				if (shopExtraMoneyIds == null || shopExtraMoneyIds.Count <= 0)
				{
					return;
				}
				this.consumeItemGroup.ResetSelectedItemIds(shopExtraMoneyIds.ToArray(), true, true, ComCommonConsume.eType.Item, ComCommonConsume.eCountType.Fatigue);
			}
		}

		// Token: 0x060109D2 RID: 68050 RVA: 0x004B2ED0 File Offset: 0x004B12D0
		private void _RefreshFilterView(int index)
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			DataManager<AccountShopDataManager>.GetInstance().RestoreFilterDataByIndex(ref this._mFrameCommonData.currFirstFilterData, this._mFrameCommonData.currentSelectedTabData.FirstFilterData, AccountShopFilterType.First, index);
			DataManager<AccountShopDataManager>.GetInstance().RestoreFilterDataByIndex(ref this._mFrameCommonData.currSecondFilterData, this._mFrameCommonData.currentSelectedTabData.SecondFilterData, AccountShopFilterType.Second, index);
			bool isShowFilterTitle = this._mFrameCommonData.currentSelectedTabData != null && this._mFrameCommonData.currentSelectedTabData.MainTabType == ShopNewMainTabType.ShopType;
			if (this.shopFilterView != null)
			{
				this.shopFilterView.InitShopNewFilterView(this._mFrameCommonData.currFirstFilterData, new OnShopNewFilterElementItemTabValueChanged(this.OnFirstFilterElementItemTabClick), this._mFrameCommonData.currSecondFilterData, new OnShopNewFilterElementItemTabValueChanged(this.OnSecondFilterElementItemTabClick), isShowFilterTitle);
			}
		}

		// Token: 0x060109D3 RID: 68051 RVA: 0x004B2FAC File Offset: 0x004B13AC
		private void OnMainTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._mFrameCommonData == null || this._mFrameCommonData.totalTabDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._mFrameCommonData.totalTabDataList.Count)
			{
				return;
			}
			ShopNewMainTabItem component = item.GetComponent<ShopNewMainTabItem>();
			ShopNewMainTabData shopNewMainTabData = this._mFrameCommonData.totalTabDataList[item.m_index];
			if (component == null || shopNewMainTabData == null)
			{
				return;
			}
			bool isSelected = item.m_index == this._mFrameCommonData.defaultSelectedTabIndex;
			component.InitData(item.m_index, shopNewMainTabData, new OnShopMainTabClickCallBack(this.OnMainTabClickCallBack), isSelected);
		}

		// Token: 0x060109D4 RID: 68052 RVA: 0x004B306C File Offset: 0x004B146C
		private void OnMainTabClickCallBack(int mainTabIndex, ShopNewMainTabData shopNewMainTabData)
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			this._mFrameCommonData.currentSelectedTabIndex = mainTabIndex;
			if (this._mFrameCommonData.currentSelectedTabData == shopNewMainTabData)
			{
				Logger.LogErrorFormat("The same mainTabType and index. the mainTabType is {0}, the index is {1}", new object[]
				{
					shopNewMainTabData.MainTabType.ToString(),
					shopNewMainTabData.Index
				});
				return;
			}
			this._mFrameCommonData.currentSelectedTabData = shopNewMainTabData;
			int shopId = 0;
			if (this._mFrameCommonData.currentSelectedTabData.MainTabType == ShopNewMainTabType.ShopType)
			{
				shopId = this._mFrameCommonData.currentSelectedTabData.Index;
			}
			else if (this._mFrameCommonData.currentSelectedTabData.MainTabType == ShopNewMainTabType.ItemType)
			{
				shopId = this._mFrameCommonData.shopId;
			}
			this._RefreshConsumeItemGroup(shopId);
			this._RefreshShopItemRefreshTimeDesc(shopId);
			this._RefreshFilterView(mainTabIndex);
			if (!this._mFrameCommonData.currentSelectedTabData.IsClicked)
			{
				DataManager<AccountShopDataManager>.GetInstance().SendWorldAccountShopItemQueryReq(this._mFrameCommonData);
				this._mFrameCommonData.currentSelectedTabData.IsClicked = true;
			}
			else
			{
				this._RefreshShopElementData();
			}
		}

		// Token: 0x060109D5 RID: 68053 RVA: 0x004B3186 File Offset: 0x004B1586
		private void OnFirstFilterElementItemTabClick(ShopNewFilterData shopNewFilterData)
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			this._mFrameCommonData.currFirstFilterData = shopNewFilterData;
			this._ResetCurrSelectFilterDatas();
			DataManager<AccountShopDataManager>.GetInstance().SendWorldAccountShopItemQueryReq(this._mFrameCommonData);
		}

		// Token: 0x060109D6 RID: 68054 RVA: 0x004B31B6 File Offset: 0x004B15B6
		private void OnSecondFilterElementItemTabClick(ShopNewFilterData shopNewFilterData)
		{
			if (this._mFrameCommonData == null)
			{
				return;
			}
			this._mFrameCommonData.currSecondFilterData = shopNewFilterData;
			this._ResetCurrSelectFilterDatas();
			DataManager<AccountShopDataManager>.GetInstance().SendWorldAccountShopItemQueryReq(this._mFrameCommonData);
		}

		// Token: 0x060109D7 RID: 68055 RVA: 0x004B31E8 File Offset: 0x004B15E8
		private void _ResetCurrSelectFilterDatas()
		{
			if (this._mFrameCommonData == null || this._mFrameCommonData.currentSelectedTabData == null)
			{
				return;
			}
			this._mFrameCommonData.currentSelectedTabData.FirstFilterData = this._mFrameCommonData.currFirstFilterData;
			this._mFrameCommonData.currentSelectedTabData.SecondFilterData = this._mFrameCommonData.currSecondFilterData;
		}

		// Token: 0x060109D8 RID: 68056 RVA: 0x004B3248 File Offset: 0x004B1648
		private void OnElementItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._mFrameCommonData == null)
			{
				return;
			}
			AccountShopItemInfo[] array = this._TryFilterShopElementData();
			if (array == null)
			{
				Logger.LogErrorFormat("[AccountShopView] - get account shop data is null, shopId is {0}", new object[]
				{
					this._mFrameCommonData.shopId
				});
				return;
			}
			int index = item.m_index;
			if (index >= 0 && index < array.Length)
			{
				AccountShopElementItem component = item.GetComponent<AccountShopElementItem>();
				if (component == null)
				{
					return;
				}
				AccountShopQueryIndex accountShopQueryIndex = DataManager<AccountShopDataManager>.GetInstance().GetAccountShopQueryIndex(this._mFrameCommonData);
				if (accountShopQueryIndex != null)
				{
					component.InitElementItem(accountShopQueryIndex.shopId, array[index]);
				}
			}
		}

		// Token: 0x060109D9 RID: 68057 RVA: 0x004B32F0 File Offset: 0x004B16F0
		private void OnElementItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			AccountShopElementItem component = item.GetComponent<AccountShopElementItem>();
			if (component != null)
			{
				component.OnRecycleElementItem();
			}
		}

		// Token: 0x060109DA RID: 68058 RVA: 0x004B3323 File Offset: 0x004B1723
		private void _OnShopGoodsRefresh(UIEvent _uiEvent)
		{
			this._RefreshShopElementData();
		}

		// Token: 0x060109DB RID: 68059 RVA: 0x004B332C File Offset: 0x004B172C
		private void _RefreshShopElementData()
		{
			if (this.shopItemList != null)
			{
				AccountShopItemInfo[] array = this._TryFilterShopElementData();
				if (array == null || array.Length == 0)
				{
					if (this.shopNoGoodsLabel)
					{
						this.shopNoGoodsLabel.text = this.tr_bless_shop_no_goods_tip;
						this.shopNoGoodsLabel.CustomActive(true);
					}
					this.shopItemList.SetElementAmount(0);
				}
				else
				{
					this.shopNoGoodsLabel.CustomActive(false);
					this.shopItemList.SetElementAmount(array.Length);
					this._RefreshShopItemRefreshTime(array);
					this._RefreshConsumeItemGroup(array);
				}
			}
		}

		// Token: 0x060109DC RID: 68060 RVA: 0x004B33C8 File Offset: 0x004B17C8
		private AccountShopItemInfo[] _TryFilterShopElementData()
		{
			AccountShopItemInfo[] array = DataManager<AccountShopDataManager>.GetInstance().GetAccountShopData(this._mFrameCommonData);
			if (this._mFrameCommonData != null)
			{
				array = DataManager<ShopNewDataManager>.GetInstance().TryFilterAccountShopItemInfos(array, this._mFrameCommonData.currFirstFilterData, this._mFrameCommonData.currSecondFilterData);
			}
			return array;
		}

		// Token: 0x060109DD RID: 68061 RVA: 0x004B3414 File Offset: 0x004B1814
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<AccountShopFrame>(null, false);
		}

		// Token: 0x060109DE RID: 68062 RVA: 0x004B3422 File Offset: 0x004B1822
		public void InitShopView(ShopNewFrameViewData frameData)
		{
			if (frameData == null)
			{
				Logger.LogError("[AccountShopView] - InitShop View Failed, ShopNewFrameCommonData is null !");
				return;
			}
			this._mFrameCommonData = frameData;
			this._InitShopView();
		}

		// Token: 0x0400A986 RID: 43398
		private string tr_bless_shop_no_goods_tip = string.Empty;

		// Token: 0x0400A987 RID: 43399
		private string tr_acc_shop_refresh_time_format = string.Empty;

		// Token: 0x0400A988 RID: 43400
		private ShopNewFrameViewData _mFrameCommonData;

		// Token: 0x0400A989 RID: 43401
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text shopNameText;

		// Token: 0x0400A98A RID: 43402
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400A98B RID: 43403
		[SerializeField]
		private Button helpButton;

		// Token: 0x0400A98C RID: 43404
		[SerializeField]
		private ComConsumeItemGroup consumeItemGroup;

		// Token: 0x0400A98D RID: 43405
		[Space(10f)]
		[Header("ShopElement")]
		[SerializeField]
		private ComUIListScript shopTabItemList;

		// Token: 0x0400A98E RID: 43406
		[SerializeField]
		private ComUIListScript shopItemList;

		// Token: 0x0400A98F RID: 43407
		[SerializeField]
		private ShopNewFilterView shopFilterView;

		// Token: 0x0400A990 RID: 43408
		[Space(10f)]
		[Header("OtherInfo")]
		[SerializeField]
		private Text shopNoGoodsLabel;

		// Token: 0x0400A991 RID: 43409
		[SerializeField]
		private Text shopRefreshLabel;

		// Token: 0x0400A992 RID: 43410
		[SerializeField]
		private TimeRefresh shopTimeRefreshControl;
	}
}
