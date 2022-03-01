using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A46 RID: 6726
	internal class PurchaseCommonFrame : ClientFrame
	{
		// Token: 0x06010854 RID: 67668 RVA: 0x004A709C File Offset: 0x004A549C
		public static void OpenLinkFrame(string strParam)
		{
			if (string.IsNullOrEmpty(strParam))
			{
				return;
			}
			int iGoodID = 0;
			if (!int.TryParse(strParam, out iGoodID))
			{
				return;
			}
			ShopItemTable goodItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(iGoodID, string.Empty, string.Empty);
			if (goodItem == null)
			{
				return;
			}
			DataManager<ShopDataManager>.GetInstance().OpenShop(goodItem.ShopID, 0, -1, delegate
			{
				ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(goodItem.ShopID);
				if (goodsDataFromShop != null)
				{
					GoodsData goodsData = goodsDataFromShop.Goods.Find((GoodsData x) => x.ID == iGoodID);
					if (goodsData != null)
					{
						Singleton<ClientSystemManager>.GetInstance().OpenFrame<PurchaseCommonFrame>(FrameLayer.Middle, null, string.Empty);
						UIEvent idleUIEvent = UIEventSystem.GetInstance().GetIdleUIEvent();
						if (idleUIEvent != null)
						{
							idleUIEvent.EventID = EUIEventID.PurchaseCommanUpdate;
							idleUIEvent.EventParams.kPurchaseCommonData.iShopID = goodItem.ShopID;
							idleUIEvent.EventParams.kPurchaseCommonData.iGoodID = iGoodID;
							idleUIEvent.EventParams.kPurchaseCommonData.iItemID = goodsData.ItemData.TableID;
							idleUIEvent.EventParams.kPurchaseCommonData.iCount = goodsData.ItemData.Count;
							UIEventSystem.GetInstance().SendUIEvent(idleUIEvent);
						}
					}
				}
			}, null, ShopFrame.ShopFrameMode.SFM_QUERY_NON_FRAME, 0, -1);
		}

		// Token: 0x06010855 RID: 67669 RVA: 0x004A7128 File Offset: 0x004A5528
		protected override void _OnOpenFrame()
		{
			this.m_kComItem = base.CreateComItem(Utility.FindChild(this.frame, "Middle/BuyItem"));
			this.m_kComItem.enabled = false;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PurchaseCommanUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdate));
			this.m_iCurCount = 1;
			this.m_eCountLimitType = PurchaseCommonFrame.CountLimitType.CLT_MIN;
			this.m_inputCount.onValueChanged.RemoveAllListeners();
			this.m_inputCount.onValueChanged.AddListener(new UnityAction<string>(this.OnValueChanged));
			this.m_kBuyInfo = Utility.FindComponent<Text>(this.frame, "Bottom/buyInfo", true);
			this.m_kSlider = Utility.FindComponent<Slider>(this.frame, "Middle/slider", true);
			this.m_kSlider.onValueChanged.AddListener(new UnityAction<float>(this._OnSliderValueChanged));
			this.m_gHint = Utility.FindGameObject(this.frame, "Middle/hint", true);
			this.m_gCount = Utility.FindGameObject(this.frame, "Middle/count", true);
			this.mTitleName = Utility.FindComponent<Text>(this.frame, "title/Name", true);
			this.m_gOldChangeNew = Utility.FindGameObject(this.frame, "CostItem/item/OldChangeNew", true);
			this.m_gPrefab = Utility.FindGameObject(this.frame, "CostItem/item/OldChangeNew/ScrollView/Viewport/Content/Prefab", true);
			this.m_gPrefab.CustomActive(false);
			this.m_gScrollView = Utility.FindGameObject(this.frame, "CostItem/item/OldChangeNew/ScrollView", true);
			this.m_gDes = Utility.FindGameObject(this.frame, "CostItem/item/OldChangeNew/des", true);
			this.m_gContent = Utility.FindGameObject(this.frame, "CostItem/item/OldChangeNew/ScrollView/Viewport/Content", true);
			this.m_tToggleGroup = Utility.FindComponent<ToggleGroup>(this.frame, "CostItem/item/OldChangeNew/ScrollView/Viewport/Content/togleGroup", true);
			this.m_gDisCountRoot = Utility.FindGameObject(this.frame, "Middle/DisCountRoot", true);
			this.m_kDisCount = Utility.FindComponent<Text>(this.frame, "Middle/DisCountRoot/discount", true);
			this.m_gDisCountRoot.CustomActive(false);
			this._UpdateButtonText();
			this._UpdateTitleDesc();
			this._InitButtons();
			this.OnValueChanged("1");
		}

		// Token: 0x06010856 RID: 67670 RVA: 0x004A7330 File Offset: 0x004A5730
		private void _OnSliderValueChanged(float fValue)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kData.iItemID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(this.m_kData.iShopID);
				if (goodsDataFromShop != null)
				{
					GoodsData goodsData2 = goodsDataFromShop.Goods.Find((GoodsData goodsData) => goodsData.ID == this.m_kData.iGoodID);
					if (goodsData2 != null)
					{
						int limitBuyTimes = goodsData2.LimitBuyTimes;
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(goodsData2.CostItemData.TableID, true);
						int num = (goodsData2.CostItemCount == null) ? 0 : goodsData2.CostItemCount.Value;
						int num2 = ownedItemCount / num;
						if (num == 0)
						{
							Logger.LogErrorFormat("iCostCount == 0 ? do you want player get money from server for free? ", new object[0]);
						}
						num2 = ((tableItem.MaxNum >= num2) ? num2 : tableItem.MaxNum);
						if (limitBuyTimes >= 0)
						{
							num2 = ((limitBuyTimes >= num2) ? num2 : limitBuyTimes);
						}
						if (num2 < 1)
						{
							num2 = 1;
						}
						int num3 = 0;
						if (int.TryParse(this.m_inputCount.text, out num3))
						{
							if (num2 <= 1)
							{
								if (fValue != 1f)
								{
									this.m_kSlider.value = 1f;
									return;
								}
								this.m_inputCount.text = 1.ToString();
								return;
							}
							else
							{
								int num4 = (int)(fValue / (1f / (float)(num2 - 1)) + 0.5f) + 1;
								if (num4 < 1)
								{
									num4 = 1;
								}
								float num5 = (float)(num4 - 1) * 1f / (float)(num2 - 1);
								if (num5 != fValue)
								{
									this.m_kSlider.value = num5;
									return;
								}
								if (num3 != num4)
								{
									this.m_inputCount.text = num4.ToString();
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06010857 RID: 67671 RVA: 0x004A7514 File Offset: 0x004A5914
		private void _InitButtons()
		{
			this.btnMin = Utility.FindComponent<Button>(this.frame, "Middle/min", true);
			this.btnMax = Utility.FindComponent<Button>(this.frame, "Middle/max", true);
			this.btnAdd = Utility.FindComponent<Button>(this.frame, "Middle/add", true);
			this.btnMinus = Utility.FindComponent<Button>(this.frame, "Middle/minus", true);
			this.grayMin = Utility.FindComponent<UIGray>(this.frame, "Middle/min", true);
			this.grayMax = Utility.FindComponent<UIGray>(this.frame, "Middle/max", true);
			this.grayAdd = Utility.FindComponent<UIGray>(this.frame, "Middle/add", true);
			this.grayMinus = Utility.FindComponent<UIGray>(this.frame, "Middle/minus", true);
		}

		// Token: 0x06010858 RID: 67672 RVA: 0x004A75DC File Offset: 0x004A59DC
		protected void OnValueChanged(string value)
		{
			int iCurCount = 0;
			if (value.Length > 0)
			{
				iCurCount = int.Parse(value);
			}
			this.m_iCurCount = iCurCount;
			this.m_eCountLimitType = PurchaseCommonFrame.CountLimitType.CLT_NORMAL;
			this._OnValueChanged();
		}

		// Token: 0x06010859 RID: 67673 RVA: 0x004A7614 File Offset: 0x004A5A14
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PurchaseCommanUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdate));
			this.m_kComItem = null;
			if (this.m_kSlider != null)
			{
				this.m_kSlider.onValueChanged.RemoveAllListeners();
				this.m_kSlider = null;
			}
			if (this.m_itemInfoList != null)
			{
				this.m_itemInfoList.Clear();
			}
			if (this.ObjList != null)
			{
				this.ObjList.Clear();
			}
			this.m_bIsShowConsumItem = false;
		}

		// Token: 0x0601085A RID: 67674 RVA: 0x004A76A0 File Offset: 0x004A5AA0
		private void _UpdateButtonText()
		{
			if (null != this.m_btnInfo)
			{
				string text = string.Empty;
				if (this.m_kData.iShopID == 11)
				{
					text = TR.Value("common_purchase_btn_guild");
				}
				else if (this.m_kData.iShopID == 26)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.m_kData.iItemID);
					if (commonItemTableDataByID != null)
					{
						if (commonItemTableDataByID.SubType == 84)
						{
							text = TR.Value("common_purchase_btn_normal");
						}
						else
						{
							text = TR.Value("common_purchase_btn_lease");
						}
					}
				}
				else
				{
					text = TR.Value("common_purchase_btn_normal");
				}
				this.m_btnInfo.text = text;
			}
		}

		// Token: 0x0601085B RID: 67675 RVA: 0x004A7758 File Offset: 0x004A5B58
		private void _UpdateTitleDesc()
		{
			if (this.mTitleName != null)
			{
				string text = string.Empty;
				ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.m_kData.iItemID);
				if (commonItemTableDataByID != null)
				{
					if (this.m_kData.iShopID == 26)
					{
						if (commonItemTableDataByID.SubType == 84)
						{
							text = TR.Value("common_purchase_title_buy");
						}
						else
						{
							text = TR.Value("common_purchase_title_lease");
						}
					}
					else
					{
						text = TR.Value("common_purchase_title_buy");
					}
				}
				this.mTitleName.text = text;
			}
		}

		// Token: 0x0601085C RID: 67676 RVA: 0x004A77EE File Offset: 0x004A5BEE
		protected void _OnUpdate(UIEvent uiEvent)
		{
			this.m_kData = uiEvent.EventParams.kPurchaseCommonData;
			this._UpdateButtonText();
			this._UpdateTitleDesc();
			this.m_bIsShowConsumItem = true;
			this._OnValueChanged();
		}

		// Token: 0x0601085D RID: 67677 RVA: 0x004A781A File Offset: 0x004A5C1A
		[UIEventHandle("title/closeicon")]
		private void OnClickClose()
		{
			this.frameMgr.CloseFrame<PurchaseCommonFrame>(this, false);
		}

		// Token: 0x0601085E RID: 67678 RVA: 0x004A7829 File Offset: 0x004A5C29
		private void OnClickCancel()
		{
			this.frameMgr.CloseFrame<PurchaseCommonFrame>(this, false);
		}

		// Token: 0x0601085F RID: 67679 RVA: 0x004A7838 File Offset: 0x004A5C38
		[UIEventHandle("Bottom/ok")]
		private void OnClickOK()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kData.iItemID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(this.m_kData.iShopID);
				if (goodsDataFromShop != null)
				{
					GoodsData goodsData2 = goodsDataFromShop.Goods.Find((GoodsData goodsData) => goodsData.ID == this.m_kData.iGoodID);
					if (goodsData2 != null)
					{
						ItemData itemData = new ItemData(0);
						if (DataManager<ShopDataManager>.GetInstance()._IsPackHaveExchangeEquipment(goodsData2.shopItem.ID, EPackageType.WearEquip, ref itemData) && DataManager<ShopDataManager>.GetInstance()._IsPackHaveExchangeEquipment(goodsData2.shopItem.ID, EPackageType.Equip, ref itemData))
						{
							this.ExecutePurchaseLogic(goodsData2);
							return;
						}
						if (DataManager<ShopDataManager>.GetInstance()._IsPackHaveExchangeEquipment(goodsData2.shopItem.ID, EPackageType.WearEquip, ref itemData))
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_pack_wearequip_have_changeequipmaterials"), new object[0]), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
						if (!DataManager<ShopDataManager>.GetInstance()._IsPackHaveExchangeEquipment(goodsData2.shopItem.ID, EPackageType.Equip, ref itemData))
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials", itemData.Name), new object[0]), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
						bool flag = DataManager<ShopDataManager>.GetInstance()._IsShowOldChangeNew(goodsData2);
						if (flag && this.m_itemInfoList.Count != 0)
						{
							this.ExecutePurchaseLogic(goodsData2);
							return;
						}
						if (flag && this.m_itemInfoList.Count == 0)
						{
							SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_pack_Consum_Item"), new object[0]), CommonTipsDesc.eShowMode.SI_UNIQUE);
							return;
						}
						this.ExecutePurchaseLogic(goodsData2);
					}
				}
			}
		}

		// Token: 0x06010860 RID: 67680 RVA: 0x004A79CC File Offset: 0x004A5DCC
		private void ExecutePurchaseLogic(GoodsData goodData)
		{
			int num = (goodData.CostItemCount == null) ? 0 : goodData.CostItemCount.Value;
			bool flag = DataManager<ShopDataManager>.GetInstance().FindMysteryShopID(this.m_kData.iShopID);
			if (flag && goodData.GoodsDisCount != null && goodData.GoodsDisCount.Value < 100 && goodData.GoodsDisCount.Value > 0)
			{
				num = goodData.GoodsDisCount.Value * goodData.CostItemCount.Value / 100;
			}
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(goodData.CostItemData.TableID, true);
			int num2 = this.m_iCurCount * num;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(goodData.CostItemData.TableID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("所需要购买的物品ID错误，无法在道具表内找到ID={0},请联系相关策划!", new object[]
				{
					goodData.CostItemData.TableID
				});
				return;
			}
			if (num2 > ownedItemCount)
			{
				if (!ItemComeLink.IsLinkMoney(goodData.CostItemData.TableID, delegate
				{
					this.frameMgr.CloseFrame<PurchaseCommonFrame>(this, false);
				}, null))
				{
					if (flag && (goodData.CostItemData.SubType == 17 || goodData.CostItemData.SubType == 27))
					{
						ShopItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(goodData.ID.Value, string.Empty, string.Empty);
						if (tableItem2 == null)
						{
							Logger.LogErrorFormat("ShopItemTable no is Find MallGoodID = {0}", new object[]
							{
								goodData.ID.Value
							});
						}
						DataManager<ShopDataManager>.GetInstance().OnGoldBuy(tableItem2.MallGoodID);
					}
					else
					{
						SystemNotifyManager.SysNotifyTextAnimation(string.Format(TR.Value("common_purchase_insufficient_materials"), tableItem.Name), CommonTipsDesc.eShowMode.SI_UNIQUE);
					}
				}
				return;
			}
			if (this.m_iCurCount <= 0)
			{
				return;
			}
			if (this.m_kData.iShopID == 26 && goodData.ItemData.SubType == 84)
			{
				int luckCharmMaxNumber = this.GetLuckCharmMaxNumber(goodData.ItemData);
				int num3 = (int)DataManager<PlayerBaseData>.GetInstance().WeaponLeaseTicket;
				int num4 = luckCharmMaxNumber - num3;
				if (this.m_iCurCount > num4)
				{
					SystemNotifyManager.SysNotifyTextAnimation(TR.Value("common_purchase_buy_lose", goodData.ItemData.GetColorName(string.Empty, false), luckCharmMaxNumber), CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					this.SendBuyGoods(goodData, num2);
				}
				return;
			}
			this.SendBuyGoods(goodData, num2);
		}

		// Token: 0x06010861 RID: 67681 RVA: 0x004A7C48 File Offset: 0x004A6048
		private void SendBuyGoods(GoodsData goodData, int iNeedCost)
		{
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(new CostItemManager.CostInfo
			{
				nMoneyID = goodData.CostItemData.TableID,
				nCount = iNeedCost
			}, delegate
			{
				DataManager<ShopDataManager>.GetInstance().BuyGoods(this.m_kData.iShopID, this.m_kData.iGoodID, this.m_iCurCount, this.m_itemInfoList);
				this.MysticalShopBuyGoodsConsumptionOfMoney(goodData);
				this.frameMgr.CloseFrame<PurchaseCommonFrame>(this, false);
			}, "common_money_cost", null);
		}

		// Token: 0x06010862 RID: 67682 RVA: 0x004A7CAC File Offset: 0x004A60AC
		private int GetLuckCharmMaxNumber(ItemData item)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(item.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				return tableItem.MaxNum;
			}
			return 0;
		}

		// Token: 0x06010863 RID: 67683 RVA: 0x004A7CE2 File Offset: 0x004A60E2
		[UIEventHandle("Middle/min")]
		private void OnClickMin()
		{
			this.m_eCountLimitType = PurchaseCommonFrame.CountLimitType.CLT_MIN;
			this._OnValueChanged();
		}

		// Token: 0x06010864 RID: 67684 RVA: 0x004A7CF1 File Offset: 0x004A60F1
		[UIEventHandle("Middle/max")]
		private void OnClickMax()
		{
			this.m_eCountLimitType = PurchaseCommonFrame.CountLimitType.CLT_MAX;
			this._OnValueChanged();
		}

		// Token: 0x06010865 RID: 67685 RVA: 0x004A7D00 File Offset: 0x004A6100
		[UIEventHandle("Middle/add")]
		private void OnClickAdd()
		{
			this.m_iCurCount++;
			this.m_eCountLimitType = PurchaseCommonFrame.CountLimitType.CLT_NORMAL;
			this._OnValueChanged();
		}

		// Token: 0x06010866 RID: 67686 RVA: 0x004A7D1D File Offset: 0x004A611D
		[UIEventHandle("Middle/minus")]
		private void OnClickMinus()
		{
			this.m_iCurCount--;
			this.m_eCountLimitType = PurchaseCommonFrame.CountLimitType.CLT_NORMAL;
			this._OnValueChanged();
		}

		// Token: 0x06010867 RID: 67687 RVA: 0x004A7D3C File Offset: 0x004A613C
		private void _OnValueChanged()
		{
			int iCurCount = 1;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.m_kData.iItemID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ShopData goodsDataFromShop = DataManager<ShopDataManager>.GetInstance().GetGoodsDataFromShop(this.m_kData.iShopID);
				if (goodsDataFromShop != null)
				{
					GoodsData goodsData2 = goodsDataFromShop.Goods.Find((GoodsData goodsData) => goodsData.ID == this.m_kData.iGoodID);
					if (goodsData2 != null)
					{
						int limitBuyTimes = goodsData2.LimitBuyTimes;
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(goodsData2.CostItemData.TableID, true);
						int num = (goodsData2.CostItemCount == null) ? 0 : goodsData2.CostItemCount.Value;
						this.m_kComItem.enabled = true;
						ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.m_kData.iItemID, 100, 0);
						if (itemData != null)
						{
							this.m_kName.text = itemData.GetColorName(string.Empty, false);
							itemData.Count = this.m_kData.iCount;
						}
						this.m_kComItem.Setup(itemData, null);
						this.m_gDisCountRoot.CustomActive(false);
						bool flag = DataManager<ShopDataManager>.GetInstance().FindMysteryShopID(this.m_kData.iShopID);
						if (flag && goodsData2.GoodsDisCount != null && goodsData2.GoodsDisCount.Value < 100 && goodsData2.GoodsDisCount.Value > 0)
						{
							num = goodsData2.GoodsDisCount.Value * goodsData2.CostItemCount.Value / 100;
							string text = TR.Value("shop_item_discount_info", goodsData2.GoodsDisCount.Value / 10);
							this.m_gDisCountRoot.CustomActive(true);
							this.m_kDisCount.text = text;
						}
						int num2 = ownedItemCount / num;
						if (num == 0)
						{
							Logger.LogErrorFormat("iCostCount == 0 ? do you want player get money from server for free? ", new object[0]);
						}
						num2 = ((tableItem.MaxNum >= num2) ? num2 : tableItem.MaxNum);
						if (limitBuyTimes >= 0)
						{
							num2 = ((limitBuyTimes >= num2) ? num2 : limitBuyTimes);
						}
						if (num2 < 1)
						{
							num2 = 1;
						}
						this.m_kBuyInfo.CustomActive(limitBuyTimes >= 0);
						this.m_kBuyInfo.text = string.Format(TR.Value("shop_buy_limit", limitBuyTimes), new object[0]);
						this.btnMinus.enabled = (this.m_iCurCount > 1);
						this.btnMin.enabled = (this.m_iCurCount > 1);
						this.btnAdd.enabled = (this.m_iCurCount < num2);
						this.btnMax.enabled = (this.m_iCurCount < num2);
						this.grayAdd.enabled = !this.btnAdd.enabled;
						this.grayMinus.enabled = !this.btnMinus.enabled;
						this.grayMin.enabled = !this.btnMin.enabled;
						this.grayMax.enabled = !this.btnMax.enabled;
						if (this.m_eCountLimitType == PurchaseCommonFrame.CountLimitType.CLT_MIN)
						{
							this.m_iCurCount = iCurCount;
						}
						else if (this.m_eCountLimitType == PurchaseCommonFrame.CountLimitType.CLT_MAX)
						{
							this.m_iCurCount = num2;
						}
						if (this.m_iCurCount > num2)
						{
							this.m_iCurCount = num2;
						}
						if (this.m_iCurCount < 1)
						{
							this.m_iCurCount = 1;
						}
						this.m_inputCount.text = this.m_iCurCount.ToString();
						if (num2 > 1)
						{
							float num3 = (float)(this.m_iCurCount - 1) * 1f / (float)(num2 - 1);
							if (this.m_kSlider.value != num3)
							{
								this.m_kSlider.value = num3;
							}
						}
						else if (this.m_kSlider.value != 1f)
						{
							this.m_kSlider.value = 1f;
						}
						this.m_kCount.text = (num * this.m_iCurCount).ToString();
						this.m_kDesc.text = tableItem.Description;
						int num4 = num * this.m_iCurCount;
						this.m_kCount.color = ((ownedItemCount >= num4) ? new Color(0.95686275f, 0.8627451f, 0.5372549f, 1f) : Color.red);
						ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(goodsData2.CostItemData.TableID, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							ETCImageLoader.LoadSprite(ref this.m_kIcon, tableItem2.Icon, true);
							this.moneyName.text = tableItem2.Name;
							List<int> list = ShopFrame.ms_money_show_name.ToList<int>();
							this.moneyName.CustomActive(list.Contains(tableItem2.ID));
							this.m_kIcon.CustomActive(!this.moneyName.IsActive());
						}
						bool flag2 = DataManager<ShopDataManager>.GetInstance()._IsShowOldChangeNew(goodsData2);
						this.m_gOldChangeNew.CustomActive(flag2);
						if (flag2)
						{
							ComOldChangeNewItem component = this.m_gOldChangeNew.GetComponent<ComOldChangeNewItem>();
							component.SetItemId(goodsData2.shopItem.ID);
							if (this.m_bIsShowConsumItem)
							{
								List<ulong> packageOldChangeNewEquip = DataManager<ShopDataManager>.GetInstance().GetPackageOldChangeNewEquip(goodsData2.shopItem.ID);
								if (packageOldChangeNewEquip.Count > 0)
								{
									this.m_gDes.CustomActive(false);
									this.m_gScrollView.CustomActive(true);
									for (int i = 0; i < packageOldChangeNewEquip.Count; i++)
									{
										ulong uID = packageOldChangeNewEquip[i];
										ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(uID);
										GameObject gameObject = Object.Instantiate<GameObject>(this.m_gPrefab);
										this.ObjList.Add(gameObject);
										Utility.AttachTo(gameObject, this.m_gContent, false);
										gameObject.CustomActive(true);
										ComCommonBind component2 = gameObject.GetComponent<ComCommonBind>();
										GameObject gameObject2 = component2.GetGameObject("ItemParent");
										ComItem comItem = base.CreateComItem(gameObject2);
										comItem.Setup(item, delegate(GameObject obj, ItemData item1)
										{
											DataManager<ItemTipManager>.GetInstance().ShowTip(item1, null, 4, true, false, true);
										});
										GameObject selectBG = component2.GetGameObject("SelectedBG");
										Toggle com = component2.GetCom<Toggle>("SelectedToggle");
										com.group = this.m_tToggleGroup;
										com.onValueChanged.RemoveAllListeners();
										com.onValueChanged.AddListener(delegate(bool isOn)
										{
											selectBG.CustomActive(isOn);
											if (isOn)
											{
												ItemInfo itemInfo = new ItemInfo();
												itemInfo.uid = uID;
												itemInfo.num = 1U;
												this._setConsumItemUId(itemInfo);
											}
										});
									}
									this.m_bIsShowConsumItem = false;
								}
								else
								{
									this.m_gDes.CustomActive(true);
									this.m_gScrollView.CustomActive(false);
								}
							}
						}
						this.btnMinus.CustomActive(!flag2);
						this.btnMin.CustomActive(!flag2);
						this.btnAdd.CustomActive(!flag2);
						this.btnMax.CustomActive(!flag2);
						this.m_kSlider.CustomActive(!flag2);
						this.m_kBuyInfo.CustomActive(limitBuyTimes > 0 && !flag2);
						this.m_gHint.CustomActive(!flag2);
						this.m_gCount.CustomActive(!flag2);
					}
				}
			}
		}

		// Token: 0x06010868 RID: 67688 RVA: 0x004A8482 File Offset: 0x004A6882
		private void _setConsumItemUId(ItemInfo info)
		{
			this.m_itemInfoList.Clear();
			this.m_itemInfoList.Add(info);
		}

		// Token: 0x06010869 RID: 67689 RVA: 0x004A849B File Offset: 0x004A689B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Shop/PurchaseCommonFrame";
		}

		// Token: 0x0601086A RID: 67690 RVA: 0x004A84A4 File Offset: 0x004A68A4
		protected void MysticalShopBuyGoodsConsumptionOfMoney(GoodsData goodData)
		{
			bool flag = DataManager<ShopDataManager>.GetInstance().FindMysteryShopID(this.m_kData.iShopID);
			if (flag)
			{
				string name = goodData.CostItemData.Name;
				if (goodData.GoodsDisCount != null && goodData.GoodsDisCount.Value < 100 && goodData.GoodsDisCount.Value > 0)
				{
					int num = Mathf.CeilToInt((float)goodData.GoodsDisCount.Value / 100f * (float)goodData.CostItemCount.Value);
					int disCount = goodData.GoodsDisCount.Value / 10;
					Singleton<GameStatisticManager>.GetInstance().DoStartMysticalShopBuyDisCountGoodsNumber(this.m_kData.iGoodID, name, disCount, num);
				}
				else
				{
					int num = (goodData.CostItemCount == null) ? 0 : goodData.CostItemCount.Value;
					Singleton<GameStatisticManager>.GetInstance().DoStartMysticalShopBuyGoodsConsumptionOfMoney(this.m_kData.iGoodID, name, num);
				}
			}
		}

		// Token: 0x0400A807 RID: 43015
		private PurchaseCommonData m_kData;

		// Token: 0x0400A808 RID: 43016
		private int m_iCurCount;

		// Token: 0x0400A809 RID: 43017
		private List<ItemInfo> m_itemInfoList = new List<ItemInfo>();

		// Token: 0x0400A80A RID: 43018
		private bool m_bIsShowConsumItem;

		// Token: 0x0400A80B RID: 43019
		private List<GameObject> ObjList = new List<GameObject>();

		// Token: 0x0400A80C RID: 43020
		private PurchaseCommonFrame.CountLimitType m_eCountLimitType;

		// Token: 0x0400A80D RID: 43021
		[UIControl("Middle/count", typeof(InputField), 0)]
		private InputField m_inputCount;

		// Token: 0x0400A80E RID: 43022
		private ComItem m_kComItem;

		// Token: 0x0400A80F RID: 43023
		private Text m_kBuyInfo;

		// Token: 0x0400A810 RID: 43024
		private GameObject m_gHint;

		// Token: 0x0400A811 RID: 43025
		private GameObject m_gCount;

		// Token: 0x0400A812 RID: 43026
		private GameObject m_gOldChangeNew;

		// Token: 0x0400A813 RID: 43027
		private GameObject m_gPrefab;

		// Token: 0x0400A814 RID: 43028
		private GameObject m_gDes;

		// Token: 0x0400A815 RID: 43029
		private GameObject m_gContent;

		// Token: 0x0400A816 RID: 43030
		private GameObject m_gScrollView;

		// Token: 0x0400A817 RID: 43031
		private ToggleGroup m_tToggleGroup;

		// Token: 0x0400A818 RID: 43032
		private GameObject m_gDisCountRoot;

		// Token: 0x0400A819 RID: 43033
		private Text m_kDisCount;

		// Token: 0x0400A81A RID: 43034
		private Text mTitleName;

		// Token: 0x0400A81B RID: 43035
		[UIControl("Bottom/ok/text", typeof(Text), 0)]
		private Text m_btnInfo;

		// Token: 0x0400A81C RID: 43036
		private Button btnMin;

		// Token: 0x0400A81D RID: 43037
		private Button btnMax;

		// Token: 0x0400A81E RID: 43038
		private Button btnAdd;

		// Token: 0x0400A81F RID: 43039
		private Button btnMinus;

		// Token: 0x0400A820 RID: 43040
		private UIGray grayMin;

		// Token: 0x0400A821 RID: 43041
		private UIGray grayMax;

		// Token: 0x0400A822 RID: 43042
		private UIGray grayAdd;

		// Token: 0x0400A823 RID: 43043
		private UIGray grayMinus;

		// Token: 0x0400A824 RID: 43044
		[UIControl("Middle/Name", typeof(Text), 0)]
		private Text m_kName;

		// Token: 0x0400A825 RID: 43045
		[UIControl("Middle/ScrollView/Viewport/Content/Desc", typeof(Text), 0)]
		private Text m_kDesc;

		// Token: 0x0400A826 RID: 43046
		[UIControl("CostItem/item/moneyName", typeof(Text), 0)]
		private Text moneyName;

		// Token: 0x0400A827 RID: 43047
		[UIControl("CostItem/item/costnum", typeof(Text), 0)]
		private Text m_kCount;

		// Token: 0x0400A828 RID: 43048
		[UIControl("CostItem/item/icon", null, 0)]
		private Image m_kIcon;

		// Token: 0x0400A829 RID: 43049
		private Slider m_kSlider;

		// Token: 0x02001A47 RID: 6727
		public enum CountLimitType
		{
			// Token: 0x0400A82C RID: 43052
			CLT_MIN,
			// Token: 0x0400A82D RID: 43053
			CLT_NORMAL,
			// Token: 0x0400A82E RID: 43054
			CLT_MAX
		}

		// Token: 0x02001A48 RID: 6728
		public enum CountConfigType
		{
			// Token: 0x0400A830 RID: 43056
			CCT_MIN = 1
		}
	}
}
