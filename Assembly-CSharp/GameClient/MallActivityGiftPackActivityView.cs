using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018A5 RID: 6309
	public sealed class MallActivityGiftPackActivityView : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F6A7 RID: 63143 RVA: 0x004299EC File Offset: 0x00427DEC
		public void Init(LimitTimeGiftPackDetailModel model, UnityAction onBuyClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)model.Id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("在商城限时活动表中找不到id为" + model.Id + "的活动");
				return;
			}
			this.mTemplate = Singleton<AssetLoader>.instance.LoadResAsGameObject(tableItem.ModePrefabIcon, true, 0U);
			if (this.mTemplate == null)
			{
				Logger.LogError("加载预制体失败:" + tableItem.ModePrefabIcon);
				return;
			}
			this.mTemplate.transform.SetParent(this.mTemplateRoot, false);
			this.mOnBuyClick = onBuyClick;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemCount));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ShopNewBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._OnShopNewBuyItemSucceed));
			this.UpdateData(model);
		}

		// Token: 0x0600F6A8 RID: 63144 RVA: 0x00429B08 File Offset: 0x00427F08
		public void UpdateData(LimitTimeGiftPackDetailModel model)
		{
			if (this.mTemplate == null)
			{
				Logger.LogError("mTemplate 为空");
				return;
			}
			MallLimitTimeActivity tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallLimitTimeActivity>((int)model.Id, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogError("在商城限时活动表中找不到id为" + model.Id + "的活动");
				return;
			}
			this.mActivityTable = tableItem;
			PreViewDataModel preViewDataModel = new PreViewDataModel();
			preViewDataModel.isCreatItem = false;
			preViewDataModel.preViewItemList = new List<PreViewItemData>();
			this.mGiftPackageIdList.Clear();
			for (int i = 0; i < model.mRewards.Length; i++)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)model.mRewards[i].id, 100, 0);
				if (itemData != null)
				{
					if (itemData.Type == ItemTable.eType.EXPENDABLE || itemData.Type == ItemTable.eType.VirtualPack)
					{
						this.mRequestedGiftPackIds.Add(itemData.TableID);
						DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem(itemData.TableID);
					}
					if (itemData.Type == ItemTable.eType.FASHION || (itemData.SubType == 29 && itemData.ThirdType == ItemTable.eThirdType.FashionGift) || itemData.SubType == 10 || itemData.SubType == 44)
					{
						PreViewItemData preViewItemData = new PreViewItemData();
						preViewItemData.activityId = (int)model.Id;
						preViewItemData.itemId = (int)model.mRewards[i].id;
						preViewDataModel.preViewItemList.Add(preViewItemData);
						this.mGiftPackageIdList.Add((int)model.mRewards[i].id);
					}
				}
			}
			ComCommonBind component = this.mTemplate.GetComponent<ComCommonBind>();
			if (component == null)
			{
				Logger.LogErrorFormat("在预制体上找不到ComCommonBind脚本: " + tableItem.ModePrefabIcon, new object[0]);
				return;
			}
			Image com = component.GetCom<Image>("ContentBg");
			ETCImageLoader.LoadSprite(ref com, tableItem.BackgroundImgPath, true);
			Image com2 = component.GetCom<Image>("FashionTips");
			ETCImageLoader.LoadSprite(ref com2, tableItem.FashionTips, true);
			Text com3 = component.GetCom<Text>("FashionName");
			com3.SafeSetText(tableItem.FashionName);
			Button com4 = component.GetCom<Button>("BuyBtn");
			com4.SafeRemoveAllListener();
			com4.SafeAddOnClickListener(this.mOnBuyClick);
			Text com5 = component.GetCom<Text>("Time");
			com5.SafeSetText(Function.GetDate((int)model.GiftStartTime, (int)model.GiftEndTime));
			Image com6 = component.GetCom<Image>("PriceIcon");
			ETCImageLoader.LoadSprite(ref com6, tableItem.PricePath, true);
			Button com7 = component.GetCom<Button>("GoShop");
			com7.SafeRemoveAllListener();
			com7.SafeAddOnClickListener(delegate
			{
				Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new OutComeData
				{
					MainTab = MallType.FashionMall
				}, string.Empty);
				Singleton<ClientSystemManager>.instance.CloseFrame<LimitTimeActivityFrame>(null, false);
			});
			Button tipsBt = component.GetCom<Button>("CloseTips");
			tipsBt.SafeRemoveAllListener();
			tipsBt.SafeAddOnClickListener(delegate
			{
				tipsBt.CustomActive(false);
			});
			Button com8 = component.GetCom<Button>("FashionBt1");
			com8.onClick.RemoveAllListeners();
			com8.onClick.AddListener(delegate()
			{
				tipsBt.CustomActive(true);
			});
			Button com9 = component.GetCom<Button>("FashionBt2");
			Button com10 = component.GetCom<Button>("FashionBt3");
			Button com11 = component.GetCom<Button>("FashionBt4");
			Button com12 = component.GetCom<Button>("FashionBt5");
			Button com13 = component.GetCom<Button>("FashionBt6");
			Button com14 = component.GetCom<Button>("FashionBt7");
			Button[] array = new Button[]
			{
				com9,
				com10,
				com11,
				com12,
				com13,
				com14
			};
			GameObject gameObject = component.GetGameObject("Item1");
			GameObject gameObject2 = component.GetGameObject("Item2");
			GameObject gameObject3 = component.GetGameObject("Item3");
			GameObject gameObject4 = component.GetGameObject("Item4");
			GameObject gameObject5 = component.GetGameObject("Item5");
			GameObject gameObject6 = component.GetGameObject("Item6");
			GameObject[] array2 = new GameObject[]
			{
				gameObject,
				gameObject2,
				gameObject3,
				gameObject4,
				gameObject5,
				gameObject6
			};
			Text com15 = component.GetCom<Text>("ItemName1");
			Text com16 = component.GetCom<Text>("ItemName2");
			Text com17 = component.GetCom<Text>("ItemName3");
			Text com18 = component.GetCom<Text>("ItemName4");
			Text com19 = component.GetCom<Text>("ItemName5");
			Text com20 = component.GetCom<Text>("ItemName6");
			Text com21 = component.GetCom<Text>("ItemName7");
			Text[] array3 = new Text[]
			{
				com15,
				com16,
				com17,
				com18,
				com19,
				com20,
				com21
			};
			if (tableItem.ActivityMode == MallLimitTimeActivity.eActivityMode.Fashion)
			{
				for (int j = 1; j < model.mRewards.Length; j++)
				{
					if (j < array.Length + 1)
					{
						int tempI = j;
						if (!(array[j - 1] == null))
						{
							array[j - 1].onClick.RemoveAllListeners();
							array[j - 1].onClick.AddListener(delegate()
							{
								ItemData itemData2 = ItemDataManager.CreateItemDataFromTable((int)model.mRewards[tempI].id, 100, 0);
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemData2, null, 4, true, false, true);
								Utility.DoStartFrameOperation("MallActivityGiftPackActivity", string.Format("ItemId/{0}", itemData2.TableID));
							});
						}
					}
				}
			}
			else if (tableItem.ActivityMode == MallLimitTimeActivity.eActivityMode.Pet)
			{
				for (int k = 0; k < model.mRewards.Length; k++)
				{
					if (k < array2.Length)
					{
						int num = k;
						if (!(array2[k] == null))
						{
							this._CreateItem((int)model.mRewards[num].id, (int)model.mRewards[num].num, array3[num], array2[k].gameObject.GetComponentInChildren<ComItem>(), array2[k]);
						}
					}
				}
			}
			Button com22 = component.GetCom<Button>("Preview");
			if (com22 != null)
			{
				com22.onClick.RemoveAllListeners();
				com22.onClick.AddListener(delegate()
				{
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
				});
			}
			Button com23 = component.GetCom<Button>("TryOn1");
			Button com24 = component.GetCom<Button>("TryOn2");
			Button com25 = component.GetCom<Button>("TryOn3");
			Button[] array4 = new Button[]
			{
				com23,
				com24,
				com25
			};
			if (this.mGiftPackageIdList != null)
			{
				for (int l = 0; l < this.mGiftPackageIdList.Count; l++)
				{
					int tmp = l;
					if (tmp < array4.Length)
					{
						array4[tmp].SafeRemoveAllListener();
						array4[tmp].SafeAddOnClickListener(delegate
						{
							this._OnTryOnClick(tmp);
						});
					}
				}
			}
			this._InitButtonTryOn(component, model.mRewards);
			if (this.mActivityTable != null && this.mActivityTable.IsExhanged == 1)
			{
				this.mMallActivityExchangeParams = component.GetCom<MallActivityExchangeParams>("MallActivityExchangeParams");
				this.mExchangedBtn = component.GetCom<Button>("ExchangeBtn");
				this.mExchangedBtnGray = component.GetCom<UIGray>("ExchangeBtn");
				this.mBeExchangedItemLeftNumTxt = component.GetCom<Text>("CountNumTxt");
				this.mExchangeLimitNumTxt = component.GetCom<Text>("LeftExchangeNum");
				this.mExchangedBtn.SafeAddOnClickListener(new UnityAction(this._OnExchangeBtnClick));
				MallActivityExchangeParams.ExchangeGoodParams exhcangedParamsData = this.GetExhcangedParamsData(0);
				if (exhcangedParamsData != null)
				{
					DataManager<ShopNewDataManager>.GetInstance().InitShopData(exhcangedParamsData.ShopId);
				}
				this.ShowItemLeftNum(-1);
				this.ShowExchageTime(-1);
			}
		}

		// Token: 0x0600F6A9 RID: 63145 RVA: 0x0042A304 File Offset: 0x00428704
		private void _OnExchangeBtnClick()
		{
			if (this.mActivityTable != null && this.mActivityTable.IsExhanged == 1 && this.mMallActivityExchangeParams != null && this.mMallActivityExchangeParams.ExchangeGoodParamList != null)
			{
				MallActivityExchangeParams.ExchangeGoodParams exhcangedParamsData = this.GetExhcangedParamsData(0);
				if (exhcangedParamsData != null)
				{
					DataManager<ShopNewDataManager>.GetInstance().BuyGoods(exhcangedParamsData.ShopId, exhcangedParamsData.GoodId, exhcangedParamsData.Count, new List<ItemInfo>());
				}
			}
		}

		// Token: 0x0600F6AA RID: 63146 RVA: 0x0042A380 File Offset: 0x00428780
		private void _OnUpdateItemCount(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			uint tableId = (uint)uiEvent.Param1;
			this.ShowItemLeftNum((int)tableId);
		}

		// Token: 0x0600F6AB RID: 63147 RVA: 0x0042A3B4 File Offset: 0x004287B4
		private void _OnShopNewBuyItemSucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			int shopItemId = (int)uiEvent.Param1;
			this.ShowExchageTime(shopItemId);
		}

		// Token: 0x0600F6AC RID: 63148 RVA: 0x0042A3DC File Offset: 0x004287DC
		private void ShowItemLeftNum(int tableId = -1)
		{
			if (this.mActivityTable != null && this.mActivityTable.IsExhanged == 1)
			{
				MallActivityExchangeParams.ExchangeGoodParams exhcangedParamsData = this.GetExhcangedParamsData(0);
				if (exhcangedParamsData == null)
				{
					return;
				}
				ShopItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopItemTable>(exhcangedParamsData.GoodId, string.Empty, string.Empty);
				if (tableItem == null)
				{
					return;
				}
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(tableItem.CostItemID, string.Empty, string.Empty);
				if (tableItem2 == null)
				{
					return;
				}
				int itemCountInPackage = DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(tableItem2.ID);
				if (tableId == -1 || tableId == tableItem.CostItemID)
				{
					this.mBeExchangedItemLeftNumTxt.SafeSetText(string.Format(TR.Value("ExchangeShopItemLeftNumTip"), tableItem2.Name, itemCountInPackage, tableItem.CostNum));
				}
				bool enableExchangeBtn = itemCountInPackage >= tableItem.CostNum;
				this.SetEnableExchangeBtn(enableExchangeBtn);
			}
		}

		// Token: 0x0600F6AD RID: 63149 RVA: 0x0042A4C4 File Offset: 0x004288C4
		private void ShowExchageTime(int shopItemId = -1)
		{
			if (this.mActivityTable != null && this.mActivityTable.IsExhanged == 1)
			{
				MallActivityExchangeParams.ExchangeGoodParams exhcangedParamsData = this.GetExhcangedParamsData(0);
				if (exhcangedParamsData == null)
				{
					return;
				}
				if (shopItemId == -1 || shopItemId == exhcangedParamsData.GoodId)
				{
					int limitTime = this.GetLimitTime(exhcangedParamsData.GoodId);
					if (limitTime == -1)
					{
						this.mExchangeLimitNumTxt.CustomActive(false);
					}
					else
					{
						this.mExchangeLimitNumTxt.CustomActive(true);
						this.mExchangeLimitNumTxt.SafeSetText(string.Format(TR.Value("ExchangeLimitTimeTip"), limitTime));
					}
					if (limitTime == 0)
					{
						this.SetEnableExchangeBtn(false);
					}
				}
			}
		}

		// Token: 0x0600F6AE RID: 63150 RVA: 0x0042A56D File Offset: 0x0042896D
		private void SetEnableExchangeBtn(bool enable)
		{
			if (this.mExchangedBtn != null && this.mExchangedBtnGray != null)
			{
				this.mExchangedBtnGray.enabled = !enable;
				this.mExchangedBtn.interactable = enable;
			}
		}

		// Token: 0x0600F6AF RID: 63151 RVA: 0x0042A5AC File Offset: 0x004289AC
		private int GetLimitTime(int shopItemId)
		{
			int result = -1;
			MallActivityExchangeParams.ExchangeGoodParams exhcangedParamsData = this.GetExhcangedParamsData(0);
			if (exhcangedParamsData == null)
			{
				return -1;
			}
			List<ShopNewShopItemTable> shopNewNeedShowingShopItemList = DataManager<ShopNewDataManager>.GetInstance().GetShopNewNeedShowingShopItemList(exhcangedParamsData.ShopId, null, null, null);
			if (shopNewNeedShowingShopItemList != null)
			{
				for (int i = 0; i < shopNewNeedShowingShopItemList.Count; i++)
				{
					ShopNewShopItemTable shopNewShopItemTable = shopNewNeedShowingShopItemList[i];
					if (shopNewShopItemTable != null && shopNewShopItemTable.ShopItemId == shopItemId)
					{
						result = shopNewShopItemTable.LimitBuyTimes;
					}
				}
			}
			return result;
		}

		// Token: 0x0600F6B0 RID: 63152 RVA: 0x0042A624 File Offset: 0x00428A24
		private MallActivityExchangeParams.ExchangeGoodParams GetExhcangedParamsData(int index)
		{
			MallActivityExchangeParams.ExchangeGoodParams result = null;
			if (this.mActivityTable != null && this.mActivityTable.IsExhanged == 1 && this.mMallActivityExchangeParams != null && this.mMallActivityExchangeParams.ExchangeGoodParamList != null && this.mMallActivityExchangeParams.ExchangeGoodParamList.Count > index)
			{
				result = this.mMallActivityExchangeParams.ExchangeGoodParamList[index];
			}
			return result;
		}

		// Token: 0x0600F6B1 RID: 63153 RVA: 0x0042A699 File Offset: 0x00428A99
		private void _OnTryOnClick(int i)
		{
			if (this.mGiftPackageIdList != null && i < this.mGiftPackageIdList.Count)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, this.mGiftPackageIdList[i], string.Empty);
			}
		}

		// Token: 0x0600F6B2 RID: 63154 RVA: 0x0042A6DC File Offset: 0x00428ADC
		private void _CreateItem(int itemId, int itemNum, Text textName, ComItem comItem, GameObject root)
		{
			ItemData itemData = ItemDataManager.CreateItemDataFromTable(itemId, 100, 0);
			if (itemData == null)
			{
				Logger.LogErrorFormat("ItemData is null", new object[0]);
				return;
			}
			if (comItem == null)
			{
				comItem = ComItemManager.Create(root);
				this.mComtItems.Add(comItem);
			}
			ComItem comItem2 = comItem;
			ItemData item = itemData;
			if (MallActivityGiftPackActivityView.<>f__mg$cache0 == null)
			{
				MallActivityGiftPackActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
			}
			comItem2.Setup(item, MallActivityGiftPackActivityView.<>f__mg$cache0);
			if (this.mActivityTable != null && this.mActivityTable.ActivityMode == MallLimitTimeActivity.eActivityMode.Fashion)
			{
				comItem.imgBackGround.enabled = false;
				Image component = comItem.objIconFashion.GetComponent<Image>();
				if (component != null)
				{
					component.enabled = false;
				}
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (itemNum == 1)
			{
				textName.SafeSetText(itemData.GetColorName(string.Empty, false));
			}
			else
			{
				textName.SafeSetText(string.Format("{0} * {1}", itemData.GetColorName(string.Empty, false), itemNum));
			}
		}

		// Token: 0x0600F6B3 RID: 63155 RVA: 0x0042A7F4 File Offset: 0x00428BF4
		public void Dispose()
		{
			if (this.mComtItems != null)
			{
				for (int i = 0; i < this.mComtItems.Count; i++)
				{
					ComItemManager.Destroy(this.mComtItems[i]);
				}
			}
			this.mComtItems.Clear();
			this.mLastRewardItemId = -1;
			this.mRequestedGiftPackIds.Clear();
			this.mOnBuyClick = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemNotifyRemoved, new ClientEventSystem.UIEventHandler(this._OnUpdateItemCount));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ShopNewBuyGoodsSuccess, new ClientEventSystem.UIEventHandler(this._OnShopNewBuyItemSucceed));
		}

		// Token: 0x0600F6B4 RID: 63156 RVA: 0x0042A8AE File Offset: 0x00428CAE
		public void Close()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F6B5 RID: 63157 RVA: 0x0042A8C4 File Offset: 0x00428CC4
		private void _InitEquipItem(GiftPackItemData data)
		{
			if (this.mTemplate == null)
			{
				return;
			}
			ComCommonBind component = this.mTemplate.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			GameObject itemEquip = component.GetGameObject("ItemEquip");
			if (itemEquip != null)
			{
				this._CreateItem(data.ItemID, data.ItemCount, itemEquip.GetComponentInChildren<Text>(), itemEquip.GetComponentInChildren<ComItem>(), itemEquip);
				Button com = component.GetCom<Button>("ButtonEquip");
				com.SafeRemoveAllListener();
				com.SafeAddOnClickListener(delegate
				{
					Utility.OnItemClicked(itemEquip, ItemDataManager.CreateItemDataFromTable(data.ItemID, 100, 0));
					Utility.DoStartFrameOperation("MallActivityGiftPackActivity", string.Format("ItemId/{0}", data.ItemID));
				});
			}
		}

		// Token: 0x0600F6B6 RID: 63158 RVA: 0x0042A988 File Offset: 0x00428D88
		private void _InitWingItem(GiftPackItemData data)
		{
			if (this.mTemplate == null)
			{
				return;
			}
			ComCommonBind component = this.mTemplate.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			GameObject wingGo = component.GetGameObject("Wing");
			if (wingGo != null)
			{
				this._CreateItem(data.ItemID, data.ItemCount, wingGo.GetComponentInChildren<Text>(), wingGo.GetComponentInChildren<ComItem>(), wingGo);
				Button com = component.GetCom<Button>("Wing");
				com.SafeRemoveAllListener();
				com.SafeAddOnClickListener(delegate
				{
					Utility.OnItemClicked(wingGo, ItemDataManager.CreateItemDataFromTable(data.ItemID, 100, 0));
				});
			}
		}

		// Token: 0x0600F6B7 RID: 63159 RVA: 0x0042AA4C File Offset: 0x00428E4C
		private void _InitButtonTryOn(ComCommonBind bind, ItemReward[] rewards)
		{
			if (bind == null)
			{
				return;
			}
			Button com = bind.GetCom<Button>("ButtonTryOn");
			com.SafeRemoveAllListener();
			com.SafeAddOnClickListener(new UnityAction(this._OnTryOnButtonClick));
		}

		// Token: 0x0600F6B8 RID: 63160 RVA: 0x0042AA8C File Offset: 0x00428E8C
		private void _OnTryOnButtonClick()
		{
			if (this.mLastRewardItemId > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mLastRewardItemId, 100, 0);
				if (itemData != null && itemData.IsOccupationFit())
				{
					this._ShowTryOnFrame(this.mLastRewardItemId);
				}
			}
		}

		// Token: 0x0600F6B9 RID: 63161 RVA: 0x0042AAD4 File Offset: 0x00428ED4
		private void _ShowTryOnFrame(int itemId)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PlayerTryOnFrame>(null))
			{
				PlayerTryOnFrame playerTryOnFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PlayerTryOnFrame)) as PlayerTryOnFrame;
				if (playerTryOnFrame != null)
				{
					playerTryOnFrame.Reset(itemId);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, itemId, string.Empty);
			}
		}

		// Token: 0x0600F6BA RID: 63162 RVA: 0x0042AB34 File Offset: 0x00428F34
		private void _OnGetGiftData(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			if (giftPackSyncInfo != null)
			{
				for (int i = 0; i < this.mRequestedGiftPackIds.Count; i++)
				{
					if ((long)this.mRequestedGiftPackIds[i] == (long)((ulong)giftPackSyncInfo.id))
					{
						for (int j = 0; j < giftPackSyncInfo.gifts.Length; j++)
						{
							GiftPackItemData giftDataFromNet = GiftPackDataManager.GetGiftDataFromNet(giftPackSyncInfo.gifts[j]);
							if (giftDataFromNet.ItemID > 0 && giftDataFromNet.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
							{
								this.mLastRewardItemId = giftDataFromNet.ItemID;
								if (this.mIsInitAvatar)
								{
									this._ShowTryOnFrame(this.mLastRewardItemId);
								}
								ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(giftDataFromNet.ItemID, string.Empty, string.Empty);
								if (tableItem != null)
								{
									if (tableItem.SubType == ItemTable.eSubType.FASHION_HAIR && tableItem.Type == ItemTable.eType.FASHION)
									{
										this._InitWingItem(giftDataFromNet);
									}
									else if (tableItem.SubType == ItemTable.eSubType.FASHION_WEAPON && tableItem.Type == ItemTable.eType.FASHION)
									{
										this._InitEquipItem(giftDataFromNet);
									}
									break;
								}
							}
						}
						this.mRequestedGiftPackIds.RemoveAt(i);
						break;
					}
				}
			}
		}

		// Token: 0x0600F6BB RID: 63163 RVA: 0x0042AC9F File Offset: 0x0042909F
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0400978E RID: 38798
		[SerializeField]
		private RectTransform mTemplateRoot;

		// Token: 0x0400978F RID: 38799
		private readonly List<ComItem> mComtItems = new List<ComItem>();

		// Token: 0x04009790 RID: 38800
		private GameObject mTemplate;

		// Token: 0x04009791 RID: 38801
		private UnityAction mOnBuyClick;

		// Token: 0x04009792 RID: 38802
		private int mLastRewardItemId = -1;

		// Token: 0x04009793 RID: 38803
		private readonly List<int> mRequestedGiftPackIds = new List<int>();

		// Token: 0x04009794 RID: 38804
		private bool mIsInitAvatar;

		// Token: 0x04009795 RID: 38805
		private List<int> mGiftPackageIdList = new List<int>();

		// Token: 0x04009796 RID: 38806
		private MallLimitTimeActivity mActivityTable;

		// Token: 0x04009797 RID: 38807
		private Text mBeExchangedItemLeftNumTxt;

		// Token: 0x04009798 RID: 38808
		private Text mExchangeLimitNumTxt;

		// Token: 0x04009799 RID: 38809
		private Button mExchangedBtn;

		// Token: 0x0400979A RID: 38810
		private UIGray mExchangedBtnGray;

		// Token: 0x0400979B RID: 38811
		private MallActivityExchangeParams mMallActivityExchangeParams;

		// Token: 0x0400979D RID: 38813
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
