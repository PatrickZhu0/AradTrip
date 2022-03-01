using System;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001791 RID: 6033
	public class MallNewLimitTimeMallElementItem : MonoBehaviour
	{
		// Token: 0x0600EE30 RID: 60976 RVA: 0x003FE96C File Offset: 0x003FCD6C
		private void Awake()
		{
			this.BindUiEventSystem();
		}

		// Token: 0x0600EE31 RID: 60977 RVA: 0x003FE974 File Offset: 0x003FCD74
		private void BindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
				this.buyButton.onClick.AddListener(new UnityAction(this.OnButtonClickCallBack));
			}
		}

		// Token: 0x0600EE32 RID: 60978 RVA: 0x003FE9B3 File Offset: 0x003FCDB3
		private void OnDestroy()
		{
			this.UnBindUiEventSystem();
		}

		// Token: 0x0600EE33 RID: 60979 RVA: 0x003FE9BB File Offset: 0x003FCDBB
		private void UnBindUiEventSystem()
		{
			if (this.buyButton != null)
			{
				this.buyButton.onClick.RemoveAllListeners();
			}
			this.ClearData();
		}

		// Token: 0x0600EE34 RID: 60980 RVA: 0x003FE9E4 File Offset: 0x003FCDE4
		private void ClearData()
		{
			this._mallItemInfo = null;
			this._remainTimeSeconds = 0;
			this._isLimitPurchaseItem = false;
			this._playerLimitType = ELimitiTimeGiftDataLimitType.None;
			this._playerLimitStr = string.Empty;
			this._playerLimitLeftNumber = 0;
			this._playerLimitTotalNumber = 0;
		}

		// Token: 0x0600EE35 RID: 60981 RVA: 0x003FEA1C File Offset: 0x003FCE1C
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
		}

		// Token: 0x0600EE36 RID: 60982 RVA: 0x003FEA7C File Offset: 0x003FCE7C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
		}

		// Token: 0x0600EE37 RID: 60983 RVA: 0x003FEADA File Offset: 0x003FCEDA
		public void Init(MallItemInfo mallItemInfo)
		{
			this.ClearData();
			this._mallItemInfo = mallItemInfo;
			this.InitElementView();
		}

		// Token: 0x0600EE38 RID: 60984 RVA: 0x003FEAF0 File Offset: 0x003FCEF0
		private void InitElementView()
		{
			if (this._mallItemInfo == null)
			{
				return;
			}
			this.InitElementText();
			this.InitLeftLimitBuyData();
			this.InitElementRewards();
			this.InitElementLeftTimes();
			this.InitElementPresentationItem();
			this.InitElementLimitBuyButtonContent();
			this.UpdateElementDiscountInformation();
			this.UpdateElementMayDayDiscountInfomation();
			this.UpdateElementLimitPurchaseInfo(-1);
			this.InitFirstDiscountInfo(DataManager<ActivityDataManager>.GetInstance().IsShowFirstDiscountDes(this._mallItemInfo.id));
		}

		// Token: 0x0600EE39 RID: 60985 RVA: 0x003FEB5C File Offset: 0x003FCF5C
		private void InitFirstDiscountInfo(bool isShow)
		{
			this.mFirstDiscountRoot.CustomActive(isShow);
			this.priceNomalImage.CustomActive(!isShow);
			if (isShow)
			{
				OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
				if (activeDataFromType != null)
				{
					this.mPrePriceTxt.SafeSetText(string.Format(TR.Value("DiscountActivity_PrePriceDes"), Utility.GetMallRealPrice(this._mallItemInfo)));
					this.mFirstDiscountDesTxt.SafeSetText(string.Format(TR.Value("DiscountActivity_DiscountDes", activeDataFromType.parm * 1.0 / 10.0), new object[0]));
					if (this.mFirstDiscountTimer != null)
					{
						uint endTime = activeDataFromType.endTime;
						uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
						uint num;
						if (endTime >= serverTime)
						{
							num = endTime - serverTime;
						}
						else
						{
							num = 0U;
						}
						if (num <= 0U)
						{
							num = 0U;
						}
						if (num <= 86400U)
						{
							this.mFirstDiscountTimer.useSystemUpdate = true;
						}
						else
						{
							this.mFirstDiscountTimer.useSystemUpdate = false;
						}
						this.mFirstDiscountTimer.SetCountdown((int)num);
						this.mFirstDiscountTimer.StartTimer();
					}
				}
			}
		}

		// Token: 0x0600EE3A RID: 60986 RVA: 0x003FEC8A File Offset: 0x003FD08A
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_NEW_SERVER_GIFT_DISCOUNT) > 0UL)
			{
				this.OnRecover();
			}
		}

		// Token: 0x0600EE3B RID: 60987 RVA: 0x003FECA8 File Offset: 0x003FD0A8
		private void _OnLimitTimeDataUpdate(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
			if (activeDataFromType != null && activeDataFromType.dataId == num && activeDataFromType.state == 0)
			{
				this.OnRecover();
			}
		}

		// Token: 0x0600EE3C RID: 60988 RVA: 0x003FECF4 File Offset: 0x003FD0F4
		private void OnRecover()
		{
			this.mFirstDiscountRoot.CustomActive(false);
			this.priceNomalImage.CustomActive(true);
			if (this._mallItemInfo != null)
			{
				int mallRealPrice = Utility.GetMallRealPrice(this._mallItemInfo);
				if (this.giftPriceText.text != null)
				{
					this.giftPriceText.text = mallRealPrice.ToString();
				}
			}
		}

		// Token: 0x0600EE3D RID: 60989 RVA: 0x003FED58 File Offset: 0x003FD158
		private void InitElementText()
		{
			if (this.titleNameText != null)
			{
				this.titleNameText.text = this._mallItemInfo.giftName;
			}
			if (this.giftDescText != null)
			{
				this.giftDescText.text = this._mallItemInfo.giftDesc;
			}
			if (this.leftTimeLabelText != null)
			{
				this.leftTimeLabelText.text = TR.Value("limit_time_mall_left_time");
			}
		}

		// Token: 0x0600EE3E RID: 60990 RVA: 0x003FEDDC File Offset: 0x003FD1DC
		private void InitLeftLimitBuyData()
		{
			if (this._mallItemInfo.limit != 0 || this._mallItemInfo.accountLimitBuyNum > 0U)
			{
				this._isLimitPurchaseItem = true;
			}
			this._playerLimitType = (ELimitiTimeGiftDataLimitType)this._mallItemInfo.limit;
			if (this._playerLimitType == ELimitiTimeGiftDataLimitType.Refresh)
			{
				this._playerLimitStr = TR.Value("limittime_mall_limit_role_everyday");
				this._playerLimitTotalNumber = (int)this._mallItemInfo.limitnum;
				this._playerLimitLeftNumber = (int)this._mallItemInfo.limitnum - DataManager<CountDataManager>.GetInstance().GetCount(this._mallItemInfo.id.ToString());
			}
			else if (this._playerLimitType == ELimitiTimeGiftDataLimitType.Week)
			{
				this._playerLimitStr = TR.Value("limittime_mall_limit_role_week");
				this._playerLimitTotalNumber = (int)this._mallItemInfo.limitnum;
				this._playerLimitLeftNumber = (int)this._mallItemInfo.limitnum - DataManager<CountDataManager>.GetInstance().GetCount(this._mallItemInfo.id.ToString());
			}
			else if (this._playerLimitType == ELimitiTimeGiftDataLimitType.NotRefresh)
			{
				this._playerLimitStr = TR.Value("limittime_mall_limit_role");
				this._playerLimitTotalNumber = (int)this._mallItemInfo.limittotalnum;
				this._playerLimitLeftNumber = (int)this._mallItemInfo.limittotalnum - DataManager<CountDataManager>.GetInstance().GetCount(this._mallItemInfo.id.ToString());
			}
		}

		// Token: 0x0600EE3F RID: 60991 RVA: 0x003FEF4C File Offset: 0x003FD34C
		private void InitElementRewards()
		{
			if (this.limitTimeOneRewardParent == null || this.limitTimeThreeRewardParent == null)
			{
				return;
			}
			int num = this._mallItemInfo.giftItems.Length;
			MallNewLimitTimeRewardParent mallNewLimitTimeRewardParent;
			if (num >= 3)
			{
				this.limitTimeOneRewardParent.transform.gameObject.CustomActive(false);
				this.limitTimeThreeRewardParent.transform.gameObject.CustomActive(true);
				mallNewLimitTimeRewardParent = this.limitTimeThreeRewardParent;
			}
			else
			{
				this.limitTimeOneRewardParent.transform.gameObject.CustomActive(true);
				this.limitTimeThreeRewardParent.transform.gameObject.CustomActive(false);
				mallNewLimitTimeRewardParent = this.limitTimeOneRewardParent;
			}
			if (mallNewLimitTimeRewardParent == null)
			{
				return;
			}
			if (mallNewLimitTimeRewardParent.LimitTimeRewardItemList == null || mallNewLimitTimeRewardParent.LimitTimeRewardItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < mallNewLimitTimeRewardParent.LimitTimeRewardItemList.Count; i++)
			{
				mallNewLimitTimeRewardParent.LimitTimeRewardItemList[i].transform.gameObject.CustomActive(false);
			}
			for (int j = 0; j < num; j++)
			{
				if (j < mallNewLimitTimeRewardParent.LimitTimeRewardItemList.Count)
				{
					MallNewLimitTimeRewardItem mallNewLimitTimeRewardItem = mallNewLimitTimeRewardParent.LimitTimeRewardItemList[j];
					if (!(mallNewLimitTimeRewardItem == null))
					{
						mallNewLimitTimeRewardItem.transform.gameObject.CustomActive(true);
						Image rewardImage = mallNewLimitTimeRewardItem.RewardImage;
						Text rewardName = mallNewLimitTimeRewardItem.RewardName;
						if (!(rewardImage == null) && !(rewardName == null))
						{
							int id = (int)this._mallItemInfo.giftItems[j].id;
							ItemData itemData = ItemDataManager.CreateItemDataFromTable(id, 100, 0);
							if (itemData != null)
							{
								rewardName.text = itemData.Name;
								ComItem comItem = rewardImage.gameObject.GetComponentInChildren<ComItem>();
								if (comItem == null)
								{
									comItem = ComItemManager.Create(rewardImage.gameObject);
								}
								itemData.Count = (int)this._mallItemInfo.giftItems[j].num;
								itemData.StrengthenLevel = (int)this._mallItemInfo.giftItems[j].strength;
								comItem.Setup(itemData, new ComItem.OnItemClicked(this.ShowItemTip));
							}
						}
					}
				}
			}
		}

		// Token: 0x0600EE40 RID: 60992 RVA: 0x003FF198 File Offset: 0x003FD598
		private void InitElementLeftTimes()
		{
			if (this.timer == null)
			{
				return;
			}
			this._remainTimeSeconds = (int)(this._mallItemInfo.endtime - DataManager<TimeManager>.GetInstance().GetServerTime());
			LimitTimeGiftState limitTimeGiftState = LimitTimeGiftState.OnSale;
			LimitTimeGiftIntraDay limitTimeGiftIntraDay = LimitTimeGiftIntraDay.None;
			if (limitTimeGiftState == LimitTimeGiftState.OnSale)
			{
				limitTimeGiftIntraDay = ((this._remainTimeSeconds <= 86400) ? LimitTimeGiftIntraDay.IntraDay : LimitTimeGiftIntraDay.MoreThanOneDay);
			}
			bool flag = limitTimeGiftIntraDay == LimitTimeGiftIntraDay.IntraDay;
			if (flag)
			{
				this.timer.useSystemUpdate = true;
			}
			else
			{
				this.timer.useSystemUpdate = false;
			}
			this.timer.SetCountdown(this._remainTimeSeconds);
			this.timer.StartTimer();
		}

		// Token: 0x0600EE41 RID: 60993 RVA: 0x003FF244 File Offset: 0x003FD644
		private void InitElementPresentationItem()
		{
			this.presentationGo.CustomActive(false);
			if (this._mallItemInfo.buyGotInfos != null && this._mallItemInfo.buyGotInfos.Length != 0)
			{
				this.presentationGo.CustomActive(true);
				this.presentationNum.text = string.Format("*{0}", this._mallItemInfo.buyGotInfos[0].buyGotNum.ToString());
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._mallItemInfo.buyGotInfos[0].itemDataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.presentationIcon, tableItem.Icon, true);
				}
				this.presentationBtn.onClick.RemoveAllListeners();
				ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)this._mallItemInfo.buyGotInfos[0].itemDataId, 100, 0);
				this.presentationBtn.onClick.AddListener(delegate()
				{
					this._OnShowTips(ItemDetailData);
				});
			}
		}

		// Token: 0x0600EE42 RID: 60994 RVA: 0x003FF356 File Offset: 0x003FD756
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600EE43 RID: 60995 RVA: 0x003FF370 File Offset: 0x003FD770
		private void InitElementLimitBuyButtonContent()
		{
			int num = Utility.GetMallRealPrice(this._mallItemInfo);
			if (DataManager<ActivityDataManager>.GetInstance().IsShowFirstDiscountDes(this._mallItemInfo.id))
			{
				OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
				if (activeDataFromType != null)
				{
					num = (int)((double)((long)num * (long)((ulong)activeDataFromType.parm)) * 1.0 / 100.0);
				}
			}
			if (this._mallItemInfo.tagType == 2 && DataManager<ActivityDataManager>.GetInstance().CheckGroupPurchaseActivityIsOpen())
			{
				num = (int)((float)((long)num * (long)((ulong)ActivityDataManager.LimitTimeGroupBuyDiscount)) * 1f / 100f);
			}
			if (this.giftPriceText.text != null)
			{
				this.giftPriceText.text = num.ToString();
			}
			if (this.priceTypeImage != null)
			{
				ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType(this._mallItemInfo.moneytype);
				if (costItemTableByCostType != null)
				{
					ETCImageLoader.LoadSprite(ref this.priceTypeImage, costItemTableByCostType.Icon, true);
				}
				else
				{
					Logger.LogErrorFormat("CostItemTable is null and moneyType is {0}", new object[]
					{
						this._mallItemInfo.moneytype
					});
				}
			}
		}

		// Token: 0x0600EE44 RID: 60996 RVA: 0x003FF4A4 File Offset: 0x003FD8A4
		private void UpdateElementDiscountInformation()
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this._mallItemInfo.discountCouponId, string.Empty, string.Empty);
			if (tableItem != null && tableItem.DiscountCouponProp != 0)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)this._mallItemInfo.discountCouponId, true);
				this.discountText.text = string.Format(TR.Value("mall_new_discount_text"), ownedItemCount);
				ETCImageLoader.LoadSprite(ref this.discountIcon, tableItem.Icon, true);
				this.priceDiscountImage.CustomActive(true);
				int mallRealPrice = Utility.GetMallRealPrice(this._mallItemInfo);
			}
			else
			{
				this.priceDiscountImage.CustomActive(false);
			}
		}

		// Token: 0x0600EE45 RID: 60997 RVA: 0x003FF558 File Offset: 0x003FD958
		private void UpdateElementMayDayDiscountInfomation()
		{
			if (this._mallItemInfo.tagType == 2 && DataManager<ActivityDataManager>.GetInstance().CheckGroupPurchaseActivityIsOpen())
			{
				this.mMayDayDiscountRoot.CustomActive(true);
				if (this.mMayDayDiscount != null)
				{
					ETCImageLoader.LoadSprite(ref this.mMayDayDiscount, TR.Value("Discount_LimitTimeGroupBuy_Path", ActivityDataManager.LimitTimeGroupBuyDiscount), true);
				}
				this.mMayDayPrice.text = string.Format("原价：{0}", Utility.GetMallRealPrice(this._mallItemInfo));
			}
			else
			{
				this.mMayDayDiscountRoot.CustomActive(false);
			}
		}

		// Token: 0x0600EE46 RID: 60998 RVA: 0x003FF5FC File Offset: 0x003FD9FC
		private void UpdateElementLimitPurchaseInfo(int accountLimitNum = -1)
		{
			this.UpdateBuyButton(true);
			if (!this._isLimitPurchaseItem)
			{
				this.limitBuyCountText.CustomActive(false);
				this.accountLimitBuyCountText.CustomActive(false);
				return;
			}
			if (this._playerLimitType != ELimitiTimeGiftDataLimitType.None)
			{
				CommonUtility.UpdateTextVisible(this.limitBuyCountText, true);
				if (this.limitBuyCountText != null)
				{
					this.limitBuyCountText.text = string.Format(this._playerLimitStr, this._playerLimitLeftNumber, this._playerLimitTotalNumber);
				}
				if (this._playerLimitLeftNumber <= 0)
				{
					this.UpdateBuyButton(false);
				}
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.limitBuyCountText, false);
			}
			if (this._mallItemInfo.accountLimitBuyNum > 0U)
			{
				this.accountLimitBuyCountGo.CustomActive(true);
				int accountLimitBuyNum = (int)this._mallItemInfo.accountLimitBuyNum;
				int num;
				if (accountLimitNum == -1)
				{
					num = (int)this._mallItemInfo.accountRestBuyNum;
				}
				else
				{
					num = accountLimitNum;
				}
				if (num <= 0)
				{
					this.UpdateBuyButton(false);
				}
				switch (this._mallItemInfo.accountRefreshType)
				{
				case 0:
					this.accountLimitBuyCountText.text = string.Format(TR.Value("count_limittime_mall_limit_number_everyday"), num, accountLimitBuyNum);
					break;
				case 1:
					this.accountLimitBuyCountText.text = string.Format(TR.Value("count_limittime_mall_limit_number_month"), num, accountLimitBuyNum);
					break;
				case 2:
					this.accountLimitBuyCountText.text = string.Format(TR.Value("count_limittime_mall_limit_number_week"), num, accountLimitBuyNum);
					break;
				case 3:
					this.accountLimitBuyCountText.text = string.Format(TR.Value("count_limittime_mall_limit_number_today"), num, accountLimitBuyNum);
					break;
				}
			}
			else
			{
				this.accountLimitBuyCountGo.CustomActive(false);
			}
		}

		// Token: 0x0600EE47 RID: 60999 RVA: 0x003FF7E4 File Offset: 0x003FDBE4
		private void OnSyncWorldMallBuySucceed(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if (uiEvent.Param1 == null || uiEvent.Param2 == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			int playerLimitLeftNumber = (int)uiEvent.Param2;
			int accountLimitNum = (int)uiEvent.Param3;
			if (this._mallItemInfo == null)
			{
				return;
			}
			this.UpdateElementDiscountInformation();
			if (this._mallItemInfo.id != num)
			{
				return;
			}
			if (!this._isLimitPurchaseItem)
			{
				return;
			}
			this._playerLimitLeftNumber = playerLimitLeftNumber;
			this.UpdateElementLimitPurchaseInfo(accountLimitNum);
		}

		// Token: 0x0600EE48 RID: 61000 RVA: 0x003FF871 File Offset: 0x003FDC71
		private void OnButtonClickCallBack()
		{
			if (this._mallItemInfo == null)
			{
				return;
			}
			if (DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			this.OpenMallBuyFrame();
		}

		// Token: 0x0600EE49 RID: 61001 RVA: 0x003FF897 File Offset: 0x003FDC97
		private void UpdateBuyButton(bool flag)
		{
			if (this.buyButtonGray != null)
			{
				this.buyButtonGray.enabled = !flag;
			}
			if (this.buyButton != null)
			{
				this.buyButton.interactable = flag;
			}
		}

		// Token: 0x0600EE4A RID: 61002 RVA: 0x003FF8D6 File Offset: 0x003FDCD6
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			Utility.DoStartFrameOperation("LimitTimeMallView", string.Format("ItemID/{0}", itemData.PackID));
			DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
		}

		// Token: 0x0600EE4B RID: 61003 RVA: 0x003FF907 File Offset: 0x003FDD07
		private void OpenMallBuyFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MallBuyFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MallBuyFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallBuyFrame>(FrameLayer.Middle, this._mallItemInfo, string.Empty);
		}

		// Token: 0x0600EE4C RID: 61004 RVA: 0x003FF93C File Offset: 0x003FDD3C
		public void Reset()
		{
			this.ClearData();
		}

		// Token: 0x04009186 RID: 37254
		private MallItemInfo _mallItemInfo;

		// Token: 0x04009187 RID: 37255
		private ELimitiTimeGiftDataLimitType _playerLimitType;

		// Token: 0x04009188 RID: 37256
		private string _playerLimitStr = string.Empty;

		// Token: 0x04009189 RID: 37257
		private int _playerLimitTotalNumber;

		// Token: 0x0400918A RID: 37258
		private int _playerLimitLeftNumber;

		// Token: 0x0400918B RID: 37259
		private int _remainTimeSeconds;

		// Token: 0x0400918C RID: 37260
		private bool _isLimitPurchaseItem;

		// Token: 0x0400918D RID: 37261
		[Header("Text")]
		[SerializeField]
		private Text titleNameText;

		// Token: 0x0400918E RID: 37262
		[SerializeField]
		private Text limitBuyCountText;

		// Token: 0x0400918F RID: 37263
		[SerializeField]
		private Text accountLimitBuyCountText;

		// Token: 0x04009190 RID: 37264
		[SerializeField]
		private Text giftDescText;

		// Token: 0x04009191 RID: 37265
		[SerializeField]
		private Text giftPriceText;

		// Token: 0x04009192 RID: 37266
		[SerializeField]
		private Text leftTimeLabelText;

		// Token: 0x04009193 RID: 37267
		[SerializeField]
		private GameObject accountLimitBuyCountGo;

		// Token: 0x04009194 RID: 37268
		[SerializeField]
		private Button buyButton;

		// Token: 0x04009195 RID: 37269
		[SerializeField]
		private UIGray buyButtonGray;

		// Token: 0x04009196 RID: 37270
		[SerializeField]
		private MallNewLimitTimeRewardParent limitTimeOneRewardParent;

		// Token: 0x04009197 RID: 37271
		[SerializeField]
		private MallNewLimitTimeRewardParent limitTimeThreeRewardParent;

		// Token: 0x04009198 RID: 37272
		[SerializeField]
		private Image priceTypeImage;

		// Token: 0x04009199 RID: 37273
		[SerializeField]
		private SimpleTimer timer;

		// Token: 0x0400919A RID: 37274
		[SerializeField]
		private GameObject presentationGo;

		// Token: 0x0400919B RID: 37275
		[SerializeField]
		private Image presentationIcon;

		// Token: 0x0400919C RID: 37276
		[SerializeField]
		private Text presentationNum;

		// Token: 0x0400919D RID: 37277
		[SerializeField]
		private Button presentationBtn;

		// Token: 0x0400919E RID: 37278
		[SerializeField]
		private Text discountText;

		// Token: 0x0400919F RID: 37279
		[SerializeField]
		private Image discountIcon;

		// Token: 0x040091A0 RID: 37280
		[SerializeField]
		private GameObject priceDiscountImage;

		// Token: 0x040091A1 RID: 37281
		[SerializeField]
		private GameObject priceNomalImage;

		// Token: 0x040091A2 RID: 37282
		[SerializeField]
		private Text mFirstDiscountDesTxt;

		// Token: 0x040091A3 RID: 37283
		[SerializeField]
		private SimpleTimer mFirstDiscountTimer;

		// Token: 0x040091A4 RID: 37284
		[SerializeField]
		private Text mPrePriceTxt;

		// Token: 0x040091A5 RID: 37285
		[SerializeField]
		private GameObject mFirstDiscountRoot;

		// Token: 0x040091A6 RID: 37286
		[SerializeField]
		private GameObject mMayDayDiscountRoot;

		// Token: 0x040091A7 RID: 37287
		[SerializeField]
		private Image mMayDayDiscount;

		// Token: 0x040091A8 RID: 37288
		[SerializeField]
		private Text mMayDayPrice;
	}
}
