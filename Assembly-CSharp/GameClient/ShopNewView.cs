using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A8A RID: 6794
	public class ShopNewView : MonoBehaviour
	{
		// Token: 0x06010AC2 RID: 68290 RVA: 0x004B987E File Offset: 0x004B7C7E
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x06010AC3 RID: 68291 RVA: 0x004B9888 File Offset: 0x004B7C88
		private void BindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			if (this.helpButton != null)
			{
				this.helpButton.onClick.RemoveAllListeners();
				this.helpButton.onClick.AddListener(new UnityAction(this.OnHelpButtonClick));
			}
			if (this.shopNewElementItemList != null)
			{
				ComUIListScript comUIListScript = this.shopNewElementItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
				ComUIListScript comUIListScript2 = this.shopNewElementItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnElementItemRecycle));
			}
			if (this.shopNewMainTabItemList != null)
			{
				ComUIListScript comUIListScript3 = this.shopNewMainTabItemList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopNewRequestChildrenShopDataSucceed, new ClientEventSystem.UIEventHandler(this.OnRequestChildrenShopDataSucceed));
		}

		// Token: 0x06010AC4 RID: 68292 RVA: 0x004B99C1 File Offset: 0x004B7DC1
		private void OnDestroy()
		{
			this.PlayShopNpcSound(NpcVoiceComponent.SoundEffectType.SET_End);
			this.UnBindUiEventSystem();
			this.ClearData();
		}

		// Token: 0x06010AC5 RID: 68293 RVA: 0x004B99D8 File Offset: 0x004B7DD8
		private void ClearData()
		{
			this._shopNewTable = null;
			this._shopNewShopData = null;
			this._shopNewShopItemTableList = null;
			this._defaultMainTabIndex = 0;
			this._shopNewMainTabDefaultSelectedData = null;
			this._shopNewMainTabSelectedData = null;
			this._shopNewFirstFilterSelectedData = null;
			this._shopNewSecondFilterSelectedData = null;
			this._selectedMainTabIndex = 0;
		}

		// Token: 0x06010AC6 RID: 68294 RVA: 0x004B9A24 File Offset: 0x004B7E24
		private void UnBindUiEventSystem()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.helpButton != null)
			{
				this.helpButton.onClick.RemoveAllListeners();
			}
			if (this.shopNewElementItemList != null)
			{
				ComUIListScript comUIListScript = this.shopNewElementItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnElementItemVisible));
				ComUIListScript comUIListScript2 = this.shopNewElementItemList;
				comUIListScript2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScript2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnElementItemRecycle));
			}
			if (this.shopNewMainTabItemList != null)
			{
				ComUIListScript comUIListScript3 = this.shopNewMainTabItemList;
				comUIListScript3.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript3.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnMainTabItemVisible));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopNewRequestChildrenShopDataSucceed, new ClientEventSystem.UIEventHandler(this.OnRequestChildrenShopDataSucceed));
		}

		// Token: 0x06010AC7 RID: 68295 RVA: 0x004B9B28 File Offset: 0x004B7F28
		public void InitShop(ShopNewParamData shopNewParamData)
		{
			if (shopNewParamData == null)
			{
				Logger.LogErrorFormat("InitShop ShowNewParamData is null", new object[0]);
				return;
			}
			this._shopId = shopNewParamData.ShopId;
			this._shopNewMainTabDefaultSelectedData.MainTabType = ShopNewMainTabType.ShopType;
			this._shopNewMainTabDefaultSelectedData.Index = this._shopId;
			this._npcId = shopNewParamData.NpcId;
			if (shopNewParamData.ShopChildId > 0)
			{
				this._shopNewMainTabDefaultSelectedData.MainTabType = ShopNewMainTabType.ShopType;
				this._shopNewMainTabDefaultSelectedData.Index = shopNewParamData.ShopChildId;
			}
			else if (shopNewParamData.ShopItemType > 0)
			{
				this._shopNewMainTabDefaultSelectedData.MainTabType = ShopNewMainTabType.ItemType;
				this._shopNewMainTabDefaultSelectedData.Index = shopNewParamData.ShopItemType;
			}
			this._shopNewTable = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(this._shopId, string.Empty, string.Empty);
			if (this._shopNewTable == null)
			{
				Logger.LogErrorFormat("The shopNewTable is null and shopId is {0}", new object[]
				{
					this._shopId
				});
				return;
			}
			this._shopNewShopData = DataManager<ShopNewDataManager>.GetInstance().GetShopNewShopData(this._shopId);
			this.InitShopView();
		}

		// Token: 0x06010AC8 RID: 68296 RVA: 0x004B9C3E File Offset: 0x004B803E
		private void InitShopView()
		{
			this.InitShopTitle();
			this.InitShopElementItemList();
			this.InitShopMoney();
			this.InitShopMainTabList();
			this.InitShopHonorLevelView();
			this.PlayShopNpcSound(NpcVoiceComponent.SoundEffectType.SET_Start);
		}

		// Token: 0x06010AC9 RID: 68297 RVA: 0x004B9C68 File Offset: 0x004B8068
		private void InitShopTitle()
		{
			if (this._shopNewTable == null)
			{
				return;
			}
			if (this.shopNameText != null)
			{
				this.shopNameText.text = this._shopNewTable.ShopName;
			}
			if (this._shopNewTable.HelpID <= 0)
			{
				if (this.helpButton != null)
				{
					this.helpButton.gameObject.CustomActive(false);
				}
			}
			else if (this.helpButton != null)
			{
				this.helpButton.gameObject.CustomActive(true);
				HelpAssistant helpAssistant = this.helpButton.GetComponent<HelpAssistant>();
				if (helpAssistant == null)
				{
					helpAssistant = this.helpButton.gameObject.AddComponent<HelpAssistant>();
				}
				if (helpAssistant != null)
				{
					helpAssistant.eType = (HelpFrame.HelpType)this._shopNewTable.HelpID;
				}
			}
		}

		// Token: 0x06010ACA RID: 68298 RVA: 0x004B9D48 File Offset: 0x004B8148
		private void InitShopMoney()
		{
			if (this._shopNewTable.CurrencyShowType == 0)
			{
				this.UpdateShopMoneyByShopId(this._shopId);
			}
		}

		// Token: 0x06010ACB RID: 68299 RVA: 0x004B9D66 File Offset: 0x004B8166
		private void UpdateShopMoneyByShopId(int shopId)
		{
			if (this.shopNewMoneyView != null)
			{
				this.shopNewMoneyView.InitShopNewMoney(shopId);
			}
		}

		// Token: 0x06010ACC RID: 68300 RVA: 0x004B9D85 File Offset: 0x004B8185
		private void UpdateShopTabMoneyByShopTab(int shopId, int shopTab)
		{
			if (this.shopNewMoneyView != null)
			{
				this.shopNewMoneyView.InitShopNewMoneyByShopTab(shopId, shopTab);
			}
		}

		// Token: 0x06010ACD RID: 68301 RVA: 0x004B9DA8 File Offset: 0x004B81A8
		private void InitShopMainTabList()
		{
			this._shopMainTabDataList = DataManager<ShopNewDataManager>.GetInstance().GetShopNewMainTabDataList(this._shopId);
			this._defaultMainTabIndex = 0;
			for (int i = 0; i < this._shopMainTabDataList.Count; i++)
			{
				ShopNewMainTabData shopNewMainTabData = this._shopMainTabDataList[i];
				if (shopNewMainTabData.MainTabType == this._shopNewMainTabDefaultSelectedData.MainTabType && shopNewMainTabData.Index == this._shopNewMainTabDefaultSelectedData.Index)
				{
					this._defaultMainTabIndex = i;
					break;
				}
			}
			if (this._shopMainTabDataList == null)
			{
				Logger.LogErrorFormat("Shop MainTab is null and shopId is {0}", new object[]
				{
					this._shopId
				});
				return;
			}
			if (this.shopNewMainTabItemList != null)
			{
				this.shopNewMainTabItemList.Initialize();
				this.shopNewMainTabItemList.SetElementAmount(this._shopMainTabDataList.Count);
			}
		}

		// Token: 0x06010ACE RID: 68302 RVA: 0x004B9E8F File Offset: 0x004B828F
		private void InitShopElementItemList()
		{
			if (this.shopNewElementItemList != null)
			{
				this.shopNewElementItemList.Initialize();
				this.shopNewElementItemList.SetElementAmount(0);
			}
			this._shopNewShopItemTableList = null;
		}

		// Token: 0x06010ACF RID: 68303 RVA: 0x004B9EC0 File Offset: 0x004B82C0
		private void PlayShopNpcSound(NpcVoiceComponent.SoundEffectType eSound)
		{
			ClientSystemTown clientSystemTown = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemTown;
			if (clientSystemTown == null)
			{
				return;
			}
			if (this._npcId <= 0)
			{
				return;
			}
			if (Singleton<TableManager>.GetInstance().GetTableItem<NpcTable>(this._npcId, string.Empty, string.Empty) == null)
			{
				return;
			}
			clientSystemTown.PlayNpcSound(this._npcId, eSound);
		}

		// Token: 0x06010AD0 RID: 68304 RVA: 0x004B9F20 File Offset: 0x004B8320
		private void InitShopHonorLevelView()
		{
			CommonUtility.UpdateGameObjectVisible(this.honorLevelRoot, false);
			if (this._shopNewTable == null)
			{
				return;
			}
			if (this._shopNewTable.ShopKind != ShopTable.eShopKind.SK_Fight)
			{
				return;
			}
			if (!HonorSystemUtility.IsShowHonorSystem())
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.honorLevelRoot, true);
			if (this.honorLevelValueLabel != null)
			{
				string text = TR.Value("Honor_System_Current_Level_Format", DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel);
				this.honorLevelValueLabel.text = text;
			}
		}

		// Token: 0x06010AD1 RID: 68305 RVA: 0x004B9FA8 File Offset: 0x004B83A8
		private void OnElementItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._shopNewShopItemTableList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._shopNewShopItemTableList.Count)
			{
				return;
			}
			ShopNewElementItem component = item.GetComponent<ShopNewElementItem>();
			ShopNewShopItemTable shopNewShopItemTable = this._shopNewShopItemTableList[item.m_index];
			if (shopNewShopItemTable == null || component == null)
			{
				return;
			}
			component.InitElementItem(shopNewShopItemTable);
		}

		// Token: 0x06010AD2 RID: 68306 RVA: 0x004BA024 File Offset: 0x004B8424
		private void OnElementItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			ShopNewElementItem component = item.GetComponent<ShopNewElementItem>();
			if (component != null)
			{
				component.OnRecycleElementItem();
			}
		}

		// Token: 0x06010AD3 RID: 68307 RVA: 0x004BA058 File Offset: 0x004B8458
		private void OnMainTabItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._shopMainTabDataList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._shopMainTabDataList.Count)
			{
				return;
			}
			ShopNewMainTabItem component = item.GetComponent<ShopNewMainTabItem>();
			ShopNewMainTabData shopNewMainTabData = this._shopMainTabDataList[item.m_index];
			if (component == null || shopNewMainTabData == null)
			{
				return;
			}
			bool isSelected = item.m_index == this._defaultMainTabIndex;
			component.InitData(item.m_index, shopNewMainTabData, new OnShopMainTabClickCallBack(this.OnMainTabClickCallBack), isSelected);
		}

		// Token: 0x06010AD4 RID: 68308 RVA: 0x004BA0F8 File Offset: 0x004B84F8
		private void OnMainTabClickCallBack(int mainTabIndex, ShopNewMainTabData shopNewMainTabData)
		{
			this._selectedMainTabIndex = mainTabIndex;
			if (this._shopNewMainTabSelectedData == shopNewMainTabData)
			{
				Logger.LogErrorFormat("The same mainTabType and index. the mainTabType is {0}, the index is {1}", new object[]
				{
					shopNewMainTabData.MainTabType.ToString(),
					shopNewMainTabData.Index
				});
				return;
			}
			this._shopNewMainTabSelectedData = shopNewMainTabData;
			if (this._shopNewMainTabSelectedData.MainTabType == ShopNewMainTabType.ShopType)
			{
				int index = this._shopNewMainTabSelectedData.Index;
				this.UpdateShopMoneyByShopId(index);
				if (!this._shopNewMainTabSelectedData.IsClicked)
				{
					ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(index, string.Empty, string.Empty);
					if (tableItem != null && tableItem.Refresh > 0)
					{
						this.UpdateMainTabSelectedData();
						DataManager<ShopNewDataManager>.GetInstance().SendRequestChildrenShopData(this._shopId, index);
						return;
					}
				}
			}
			else if (this._shopNewMainTabSelectedData.MainTabType == ShopNewMainTabType.ItemType && this._shopNewTable.CurrencyShowType == 1)
			{
				this.UpdateShopTabMoneyByShopTab(this._shopId, this._shopNewMainTabSelectedData.Index);
			}
			this.UpdateMainTabSelectedData();
			this.UpdateShopView(this._selectedMainTabIndex);
		}

		// Token: 0x06010AD5 RID: 68309 RVA: 0x004BA218 File Offset: 0x004B8618
		private void OnRequestChildrenShopDataSucceed(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			int num2 = (int)uiEvent.Param2;
			if (this._shopNewMainTabSelectedData.MainTabType != ShopNewMainTabType.ShopType)
			{
				return;
			}
			if (this._shopId != num)
			{
				return;
			}
			if (this._shopNewMainTabSelectedData.Index != num2)
			{
				return;
			}
			this.UpdateShopView(this._selectedMainTabIndex);
		}

		// Token: 0x06010AD6 RID: 68310 RVA: 0x004BA297 File Offset: 0x004B8697
		private void UpdateMainTabSelectedData()
		{
			if (!this._shopNewMainTabSelectedData.IsClicked)
			{
				this._shopNewMainTabSelectedData.IsClicked = true;
			}
		}

		// Token: 0x06010AD7 RID: 68311 RVA: 0x004BA2B5 File Offset: 0x004B86B5
		private void UpdateShopView(int mainTabIndex)
		{
			this.UpdateFilterView(mainTabIndex);
			this.UpdateShopNoElementTipLabel();
			this.ShowShopElementItemList();
			this.SetShopDescriptionByMainTabChanged();
			this.UpdateShopTimeRefresh(mainTabIndex);
		}

		// Token: 0x06010AD8 RID: 68312 RVA: 0x004BA2D8 File Offset: 0x004B86D8
		private void UpdateFilterView(int index)
		{
			int num = DataManager<ShopNewDataManager>.GetInstance().GetFirstFilterIndex(index);
			int num2 = DataManager<ShopNewDataManager>.GetInstance().GetSecondFilterIndex(index);
			int filterTitleIndex = DataManager<ShopNewDataManager>.GetInstance().GetFilterTitleIndex(index);
			if (num < 0 || num >= 7)
			{
				num = 0;
			}
			if (num2 < 0 || num2 >= 7)
			{
				num2 = 0;
			}
			ShopTable.eFilter eFilter = (ShopTable.eFilter)num;
			ShopTable.eFilter eFilter2 = (ShopTable.eFilter)num2;
			if (eFilter == ShopTable.eFilter.SF_NONE)
			{
				this._shopNewFirstFilterSelectedData = null;
			}
			else if (this._shopNewMainTabSelectedData.FirstFilterData != null)
			{
				this._shopNewFirstFilterSelectedData = this._shopNewMainTabSelectedData.FirstFilterData;
			}
			else
			{
				this._shopNewFirstFilterSelectedData = DataManager<ShopNewDataManager>.GetInstance().GetDefaultFilterDataByFilterType(eFilter);
			}
			if (eFilter2 == ShopTable.eFilter.SF_NONE)
			{
				this._shopNewSecondFilterSelectedData = null;
			}
			else if (this._shopNewMainTabSelectedData.SecondFilterData != null)
			{
				this._shopNewSecondFilterSelectedData = this._shopNewMainTabSelectedData.SecondFilterData;
			}
			else
			{
				this._shopNewSecondFilterSelectedData = DataManager<ShopNewDataManager>.GetInstance().GetDefaultFilterDataByFilterType(eFilter2);
			}
			bool flag = this._shopNewMainTabSelectedData != null && this._shopNewMainTabSelectedData.MainTabType == ShopNewMainTabType.ShopType;
			if (!flag)
			{
				flag = (filterTitleIndex == 1);
			}
			if (this.shopNewFilterView != null)
			{
				this.shopNewFilterView.InitShopNewFilterView(this._shopNewFirstFilterSelectedData, new OnShopNewFilterElementItemTabValueChanged(this.OnFirstFilterElementItemTabClick), this._shopNewSecondFilterSelectedData, new OnShopNewFilterElementItemTabValueChanged(this.OnSecondFilterElementItemTabClick), flag);
			}
		}

		// Token: 0x06010AD9 RID: 68313 RVA: 0x004BA439 File Offset: 0x004B8839
		private void OnFirstFilterElementItemTabClick(ShopNewFilterData shopNewFilterData)
		{
			this._shopNewFirstFilterSelectedData = shopNewFilterData;
			this.ShowShopElementItemList();
		}

		// Token: 0x06010ADA RID: 68314 RVA: 0x004BA448 File Offset: 0x004B8848
		private void OnSecondFilterElementItemTabClick(ShopNewFilterData shopNewFilterData)
		{
			this._shopNewSecondFilterSelectedData = shopNewFilterData;
			this.ShowShopElementItemList();
		}

		// Token: 0x06010ADB RID: 68315 RVA: 0x004BA458 File Offset: 0x004B8858
		private void ShowShopElementItemList()
		{
			this._shopNewMainTabSelectedData.FirstFilterData = this._shopNewFirstFilterSelectedData;
			this._shopNewMainTabSelectedData.SecondFilterData = this._shopNewSecondFilterSelectedData;
			this._shopNewShopItemTableList = DataManager<ShopNewDataManager>.GetInstance().GetShopNewNeedShowingShopItemList(this._shopId, this._shopNewMainTabSelectedData, this._shopNewFirstFilterSelectedData, this._shopNewSecondFilterSelectedData);
			this.UpdateShopElementItemList();
		}

		// Token: 0x06010ADC RID: 68316 RVA: 0x004BA4B8 File Offset: 0x004B88B8
		private void SetShopDescriptionByMainTabChanged()
		{
			if (this.shopDescriptionText == null)
			{
				return;
			}
			this.shopDescriptionText.gameObject.CustomActive(false);
			if (this._shopNewShopItemTableList == null || this._shopNewShopItemTableList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this._shopNewShopItemTableList.Count; i++)
			{
				ShopNewShopItemTable shopNewShopItemTable = this._shopNewShopItemTableList[i];
				if (shopNewShopItemTable != null && shopNewShopItemTable.ShopItemTable != null)
				{
					GoodsLimitButyType exLimite = (GoodsLimitButyType)shopNewShopItemTable.ShopItemTable.ExLimite;
					if (exLimite == GoodsLimitButyType.GLBT_FIGHT_SCORE)
					{
						this.shopDescriptionText.gameObject.CustomActive(true);
						int seasonLevel = DataManager<SeasonDataManager>.GetInstance().seasonLevel;
						string rankName = DataManager<SeasonDataManager>.GetInstance().GetRankName(seasonLevel, true);
						this.shopDescriptionText.text = string.Format(TR.Value("shop_max_fight_score"), rankName);
						break;
					}
					if (exLimite == GoodsLimitButyType.GLBT_TOWER_LEVEL)
					{
						this.shopDescriptionText.gameObject.CustomActive(true);
						int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_MAX_DEATH_TOWER_LEVEL);
						this.shopDescriptionText.text = string.Format(TR.Value("shop_max_tower_level"), count);
						break;
					}
				}
			}
		}

		// Token: 0x06010ADD RID: 68317 RVA: 0x004BA5F4 File Offset: 0x004B89F4
		private void UpdateShopTimeRefresh(int mainTabIndex = 0)
		{
			if (this.shopTimeRefreshControl == null)
			{
				return;
			}
			if (this.shopTimeRefreshText == null)
			{
				return;
			}
			if (this._shopNewTable == null)
			{
				return;
			}
			if (this._shopNewShopData == null)
			{
				return;
			}
			bool flag = false;
			if (mainTabIndex >= 0 && mainTabIndex < this._shopNewTable.NeedRefreshTabs.Count && this._shopNewTable.NeedRefreshTabs[mainTabIndex] == 1)
			{
				flag = true;
			}
			if (flag)
			{
				this.shopTimeRefreshText.enabled = false;
				this.shopTimeRefreshLabel.enabled = false;
				ShopTable.eRefreshCycle eRefreshCycle = this._shopNewTable.RefreshCycle[mainTabIndex];
				if (eRefreshCycle != ShopTable.eRefreshCycle.REFRESH_CYCLE_DAILY)
				{
					if (eRefreshCycle != ShopTable.eRefreshCycle.REFRESH_CYCLE_WEEK)
					{
						if (eRefreshCycle == ShopTable.eRefreshCycle.REFRESH_CYCLE_MONTH)
						{
							this.SetShopTimeRefresh(this._shopNewShopData.MonthRefreshTime);
						}
					}
					else
					{
						this.SetShopTimeRefresh(this._shopNewShopData.WeekResetRefreshTime);
					}
				}
				else
				{
					this.SetShopTimeRefresh(this._shopNewShopData.ResetRefreshTime);
				}
			}
			else if (this._shopNewTable.Refresh == 1)
			{
				this.SetShopTimeRefresh(this._shopNewShopData.ResetRefreshTime);
			}
			else
			{
				this.shopTimeRefreshText.enabled = false;
				this.shopTimeRefreshLabel.enabled = false;
				this.shopTimeRefreshControl.Initialize();
				this.shopTimeRefreshControl.SetFormatString("{0}");
			}
		}

		// Token: 0x06010ADE RID: 68318 RVA: 0x004BA760 File Offset: 0x004B8B60
		private void SetShopTimeRefresh(uint refreshTime)
		{
			this.shopTimeRefreshText.enabled = true;
			this.shopTimeRefreshLabel.enabled = true;
			this.shopTimeRefreshControl.Initialize();
			this.shopTimeRefreshControl.SetFormatString("{0}");
			this.shopTimeRefreshControl.Time = refreshTime;
			this.shopTimeRefreshControl.enabled = true;
		}

		// Token: 0x06010ADF RID: 68319 RVA: 0x004BA7B8 File Offset: 0x004B8BB8
		private void UpdateShopElementItemList()
		{
			int elementAmount;
			if (this._shopNewShopItemTableList == null || this._shopNewShopItemTableList.Count <= 0)
			{
				elementAmount = 0;
			}
			else
			{
				elementAmount = this._shopNewShopItemTableList.Count;
			}
			if (this.shopNewElementItemList != null)
			{
				this.shopNewElementItemList.Initialize();
				this.shopNewElementItemList.SetElementAmount(elementAmount);
				this.shopNewElementItemList.ResetContentPosition();
			}
		}

		// Token: 0x06010AE0 RID: 68320 RVA: 0x004BA82C File Offset: 0x004B8C2C
		private void UpdateShopNoElementTipLabel()
		{
			if (this.noElementTipLabel == null)
			{
				return;
			}
			if (this._shopNewFirstFilterSelectedData != null && this._shopNewFirstFilterSelectedData.FilterType == ShopTable.eFilter.SF_PLAY_OCCU)
			{
				bool flag = PlayerBaseData.IsJobChanged();
				string text = TR.Value("shop_new_no_element_by_Profession");
				if (flag)
				{
					text = TR.Value("shop_new_all_element_SoldOut_by_Profession");
				}
				this.noElementTipLabel.text = text;
				return;
			}
			if (this._shopNewSecondFilterSelectedData != null && this._shopNewSecondFilterSelectedData.FilterType == ShopTable.eFilter.SF_PLAY_OCCU)
			{
				bool flag2 = PlayerBaseData.IsJobChanged();
				string text2 = TR.Value("shop_new_no_element_by_Profession");
				if (flag2)
				{
					text2 = TR.Value("shop_new_all_element_SoldOut_by_Profession");
				}
				this.noElementTipLabel.text = text2;
				return;
			}
			this.noElementTipLabel.text = TR.Value("shop_new_no_element_by_normal");
		}

		// Token: 0x06010AE1 RID: 68321 RVA: 0x004BA8F6 File Offset: 0x004B8CF6
		private void OnCloseFrame()
		{
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ShopNewFrame>(null, false);
		}

		// Token: 0x06010AE2 RID: 68322 RVA: 0x004BA904 File Offset: 0x004B8D04
		private void OnHelpButtonClick()
		{
			Logger.LogError("Help button Clicked");
		}

		// Token: 0x0400AA70 RID: 43632
		private int _shopId = 17;

		// Token: 0x0400AA71 RID: 43633
		private int _npcId = -1;

		// Token: 0x0400AA72 RID: 43634
		private int _selectedMainTabIndex;

		// Token: 0x0400AA73 RID: 43635
		private ShopTable _shopNewTable;

		// Token: 0x0400AA74 RID: 43636
		private ShopNewShopData _shopNewShopData;

		// Token: 0x0400AA75 RID: 43637
		private List<ShopNewShopItemTable> _shopNewShopItemTableList;

		// Token: 0x0400AA76 RID: 43638
		private List<ShopNewMainTabData> _shopMainTabDataList;

		// Token: 0x0400AA77 RID: 43639
		private ShopNewMainTabData _shopNewMainTabDefaultSelectedData = new ShopNewMainTabData();

		// Token: 0x0400AA78 RID: 43640
		private int _defaultMainTabIndex;

		// Token: 0x0400AA79 RID: 43641
		private ShopNewMainTabData _shopNewMainTabSelectedData = new ShopNewMainTabData();

		// Token: 0x0400AA7A RID: 43642
		private ShopNewFilterData _shopNewFirstFilterSelectedData = new ShopNewFilterData();

		// Token: 0x0400AA7B RID: 43643
		private ShopNewFilterData _shopNewSecondFilterSelectedData = new ShopNewFilterData();

		// Token: 0x0400AA7C RID: 43644
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text shopNameText;

		// Token: 0x0400AA7D RID: 43645
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400AA7E RID: 43646
		[SerializeField]
		private Button helpButton;

		// Token: 0x0400AA7F RID: 43647
		[Space(5f)]
		[Header("Money")]
		[SerializeField]
		private ShopNewMoneyView shopNewMoneyView;

		// Token: 0x0400AA80 RID: 43648
		[Space(10f)]
		[Header("ShopMainTabList")]
		[SerializeField]
		private ComUIListScript shopNewMainTabItemList;

		// Token: 0x0400AA81 RID: 43649
		[Space(10f)]
		[Header("ShopNewFilterView")]
		[SerializeField]
		private ShopNewFilterView shopNewFilterView;

		// Token: 0x0400AA82 RID: 43650
		[Space(10f)]
		[Header("ShopElementItemList")]
		[SerializeField]
		private ComUIListScript shopNewElementItemList;

		// Token: 0x0400AA83 RID: 43651
		[SerializeField]
		private Text shopDescriptionText;

		// Token: 0x0400AA84 RID: 43652
		[Space(10f)]
		[Header("ShopTimeRefresh")]
		[SerializeField]
		private TimeRefresh shopTimeRefreshControl;

		// Token: 0x0400AA85 RID: 43653
		[SerializeField]
		private Text shopTimeRefreshText;

		// Token: 0x0400AA86 RID: 43654
		[SerializeField]
		private Text shopTimeRefreshLabel;

		// Token: 0x0400AA87 RID: 43655
		[Space(10f)]
		[Header("HonorLevelRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject honorLevelRoot;

		// Token: 0x0400AA88 RID: 43656
		[SerializeField]
		private Text honorLevelValueLabel;

		// Token: 0x0400AA89 RID: 43657
		[Space(10f)]
		[Header("NoElementTips")]
		[Space(10f)]
		[SerializeField]
		private Text noElementTipLabel;
	}
}
