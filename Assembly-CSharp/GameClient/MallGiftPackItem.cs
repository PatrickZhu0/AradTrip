using System;
using System.Collections.Generic;
using LimitTimeGift;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018FC RID: 6396
	public class MallGiftPackItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F940 RID: 63808 RVA: 0x0043FED2 File Offset: 0x0043E2D2
		private void Awake()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
			this.mCostOriginalCorlor = this.mTextCost.color;
		}

		// Token: 0x0600F941 RID: 63809 RVA: 0x0043FF00 File Offset: 0x0043E300
		public void Init(int id, LimitTimeGiftPackDetailModel data, ActivityItemBase.OnActivityItemClick<int> onItemClick, int activityId)
		{
			this.mButtonBuy.SafeAddOnClickListener(new UnityAction(this.OnButtonBuyClick));
			this.mData = data;
			this.mOnItemClick = onItemClick;
			this.mId = id;
			this.UpdateData(data);
			this.InitItems(data.mRewards);
			this.InitElementPresentationItem(data);
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Combine(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			this.mActivityId = activityId;
			this.InitFirstDiscountActivtiyParams(data);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
		}

		// Token: 0x0600F942 RID: 63810 RVA: 0x0043FFC0 File Offset: 0x0043E3C0
		private void InitFirstDiscountActivtiyParams(LimitTimeGiftPackDetailModel data)
		{
			this.mFirstDiscountActivityData = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
			if (DataManager<ActivityDataManager>.GetInstance().IsShowFirstDiscountDes(data.Id))
			{
				this.mIsCanShowDiscount = true;
				if (this.mFirstDiscountTimer != null)
				{
					uint endTime = this.mFirstDiscountActivityData.endTime;
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
					if (num >= 86400U)
					{
						this.mFirstDiscountTimer.useSystemUpdate = false;
					}
					else
					{
						this.mFirstDiscountTimer.useSystemUpdate = true;
					}
					this.mFirstDiscountTimer.SetCountdown((int)num);
					this.mFirstDiscountTimer.StartTimer();
				}
				this.mFirstDiscountDesTxt.SafeSetText(string.Format(TR.Value("DiscountActivity_DiscountDes", this.mFirstDiscountActivityData.parm * 1.0 / 10.0), new object[0]));
			}
			else
			{
				this.mIsCanShowDiscount = false;
			}
			this.HideOrShowFirstDiscountDes(this.mIsCanShowDiscount);
		}

		// Token: 0x0600F943 RID: 63811 RVA: 0x004400E1 File Offset: 0x0043E4E1
		public uint GetGiftId()
		{
			return this.mData.Id;
		}

		// Token: 0x0600F944 RID: 63812 RVA: 0x004400F0 File Offset: 0x0043E4F0
		public void UpdateData(LimitTimeGiftPackDetailModel data)
		{
			this.mData = data;
			this.mTextDescription.text = data.Name;
			if (data.GiftType != MallGoodsType.GIFT_COMMON || data.LimitTotalNum > 0 || data.Limit == 3)
			{
				this.UpdateBuyCountNew(data);
			}
			else
			{
				this.mTextDetail.text = string.Format(TR.Value("activity_mall_gift_pack_item_detail").Replace("\\n", "\n"), string.Empty, Function.GetLeftDay((int)DataManager<TimeManager>.GetInstance().GetServerTime(), (int)data.GiftEndTime));
			}
			if (this.mSimpleTimer)
			{
				if (data.NeedTimeCountDown)
				{
					this.mSimpleTimer.useSystemUpdate = true;
				}
				else
				{
					this.mSimpleTimer.useSystemUpdate = false;
				}
				uint num = data.GiftEndTime - DataManager<TimeManager>.GetInstance().GetServerTime();
				if (num <= 0U)
				{
					num = 0U;
				}
				this.mSimpleTimer.SetCountdown((int)num);
				this.mSimpleTimer.StartTimer();
			}
			this.UpdateCostText();
			if (data.DiscountCouponId > 0U)
			{
				this.discountGo.CustomActive(true);
			}
			else
			{
				this.discountGo.CustomActive(false);
			}
			if (data.AccountLimitBuyNum > 0U)
			{
				this.mAccountTextDetail.CustomActive(true);
				int accountLimitBuyNum = (int)data.AccountLimitBuyNum;
				int accountRestBuyNum;
				if (this.accountLimitNum == -1 || this.accountLimitNum == 2147483647)
				{
					accountRestBuyNum = (int)data.AccountRestBuyNum;
				}
				else
				{
					accountRestBuyNum = this.accountLimitNum;
				}
				if (accountRestBuyNum <= 0)
				{
					this.UpdateBuyButton(false);
				}
				else
				{
					this.UpdateBuyButton(true);
				}
				switch (data.AccountRefreshType)
				{
				case 0U:
					this.mAccountTextDetail.text = string.Format(TR.Value("count_limittime_mall_limit_number_everyday"), accountRestBuyNum, accountLimitBuyNum);
					break;
				case 1U:
					this.mAccountTextDetail.text = string.Format(TR.Value("count_limittime_mall_limit_number_month"), accountRestBuyNum, accountLimitBuyNum);
					break;
				case 2U:
					this.mAccountTextDetail.text = string.Format(TR.Value("count_limittime_mall_limit_number_week"), accountRestBuyNum, accountLimitBuyNum);
					break;
				case 3U:
					this.mAccountTextDetail.text = string.Format(TR.Value("count_limittime_mall_limit_number_today"), accountRestBuyNum, accountLimitBuyNum);
					break;
				}
			}
			else
			{
				this.mAccountTextDetail.CustomActive(false);
			}
		}

		// Token: 0x0600F945 RID: 63813 RVA: 0x0044037C File Offset: 0x0043E77C
		private void UpdateCostText()
		{
			this.mTextCost.text = this.mData.GiftPrice.ToString();
			ulong num = 0UL;
			LimitTimeGiftPriceType priceType = this.mData.PriceType;
			if (priceType != LimitTimeGiftPriceType.Gold)
			{
				if (priceType != LimitTimeGiftPriceType.Point)
				{
					if (priceType != LimitTimeGiftPriceType.BindGOLD)
					{
						if (priceType == LimitTimeGiftPriceType.BindPint)
						{
							num = DataManager<PlayerBaseData>.GetInstance().BindTicket;
						}
					}
					else
					{
						num = DataManager<PlayerBaseData>.GetInstance().BindGold;
					}
				}
				else
				{
					num = DataManager<PlayerBaseData>.GetInstance().Ticket;
				}
			}
			else
			{
				num = DataManager<PlayerBaseData>.GetInstance().Gold;
			}
			ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType((byte)this.mData.PriceType);
			if (this.mImageCurrency != null && costItemTableByCostType != null)
			{
				ETCImageLoader.LoadSprite(ref this.mImageCurrency, costItemTableByCostType.Icon, true);
			}
			if (this.mIsCanShowDiscount)
			{
				if (this.mFirstDiscountPriceIconImg != null && costItemTableByCostType != null)
				{
					ETCImageLoader.LoadSprite(ref this.mFirstDiscountPriceIconImg, costItemTableByCostType.Icon, true);
				}
				int num2 = 0;
				if (this.mFirstDiscountPriceTxt != null && this.mFirstDiscountActivityData != null)
				{
					num2 = (int)Math.Floor(Convert.ToDecimal((float)((long)this.mData.GiftPrice * (long)((ulong)this.mFirstDiscountActivityData.parm)) * 1f / 100f));
					this.mFirstDiscountPriceTxt.SafeSetText(num2.ToString());
				}
				if (num >= (ulong)((long)num2))
				{
					this.mFirstDiscountPriceTxt.color = this.mCostOriginalCorlor;
				}
				else
				{
					this.mFirstDiscountPriceTxt.color = this.mNotEnoughColor;
				}
			}
			MallItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MallItemTable>((int)this.mData.Id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.tagtype == 2 && DataManager<ActivityDataManager>.GetInstance().CheckGroupPurchaseActivityIsOpen())
				{
					if (this.mFirstDiscountPriceIconImg != null && costItemTableByCostType != null)
					{
						ETCImageLoader.LoadSprite(ref this.mFirstDiscountPriceIconImg, costItemTableByCostType.Icon, true);
					}
					int num3 = (int)((float)((long)this.mData.GiftPrice * (long)((ulong)ActivityDataManager.LimitTimeGroupBuyDiscount)) * 1f / 100f);
					if (this.mFirstDiscountPriceTxt != null)
					{
						this.mFirstDiscountPriceTxt.text = num3.ToString();
					}
					if (num >= (ulong)((long)num3))
					{
						this.mFirstDiscountPriceTxt.color = this.mCostOriginalCorlor;
					}
					else
					{
						this.mFirstDiscountPriceTxt.color = this.mNotEnoughColor;
					}
					if (this.mMayDayDiscount != null)
					{
						this.mMayDayDiscount.text = string.Format("{0}折", ActivityDataManager.LimitTimeGroupBuyDiscount / 10f);
					}
					this.mFirstDiscountPriceRootGo.CustomActive(true);
					this.mMayDayGiftDiscountRoot.CustomActive(true);
				}
				else
				{
					this.mFirstDiscountPriceRootGo.CustomActive(false);
					this.mMayDayGiftDiscountRoot.CustomActive(false);
				}
			}
			if (num >= (ulong)((long)this.mData.GiftPrice))
			{
				this.mTextCost.color = this.mCostOriginalCorlor;
			}
			else
			{
				this.mTextCost.color = this.mNotEnoughColor;
			}
		}

		// Token: 0x0600F946 RID: 63814 RVA: 0x004406C5 File Offset: 0x0043EAC5
		private void OnDestroy()
		{
			this.Dispose();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSyncWorldMallBuySucceed, new ClientEventSystem.UIEventHandler(this.OnSyncWorldMallBuySucceed));
		}

		// Token: 0x0600F947 RID: 63815 RVA: 0x004406E8 File Offset: 0x0043EAE8
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
			if (num == this.mData.Id)
			{
				this.accountLimitNum = (int)uiEvent.Param3;
				this.UpdateData(this.mData);
			}
		}

		// Token: 0x0600F948 RID: 63816 RVA: 0x00440750 File Offset: 0x0043EB50
		private void InitItems(ItemReward[] awards)
		{
			if (awards == null || awards.Length == 0)
			{
				return;
			}
			int i = 0;
			while (i < awards.Length)
			{
				ComItem comItem = ComItemManager.Create(this.mItemRoot.gameObject);
				if (!(comItem != null))
				{
					goto IL_D1;
				}
				ItemData data = ItemDataManager.CreateItemDataFromTable((int)awards[i].id, 100, 0);
				if (data != null)
				{
					data.Count = (int)awards[i].num;
					data.StrengthenLevel = (int)awards[i].strength;
					comItem.Setup(data, delegate(GameObject obj, ItemData itemData)
					{
						if (this.mActivityId == 5000)
						{
							Utility.DoStartFrameOperation("MallGiftPackActivity", string.Format("ItemID/{0}", data.TableID));
						}
						Utility.OnItemClicked(this.gameObject, data);
					});
					this.mComItems.Add(comItem);
					goto IL_D1;
				}
				Logger.LogError("道具表找补到id为" + awards[i].id + "的道具");
				IL_E7:
				i++;
				continue;
				IL_D1:
				(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
				goto IL_E7;
			}
		}

		// Token: 0x0600F949 RID: 63817 RVA: 0x00440854 File Offset: 0x0043EC54
		private void InitElementPresentationItem(LimitTimeGiftPackDetailModel limitTimeGiftData)
		{
			this.presentationGo.CustomActive(false);
			MallItemInfo mallItemInfo = new MallItemInfo
			{
				id = limitTimeGiftData.Id,
				limitnum = (ushort)limitTimeGiftData.LimitNum,
				limittotalnum = (ushort)limitTimeGiftData.LimitTotalNum,
				gift = (byte)limitTimeGiftData.GiftType,
				buyGotInfos = limitTimeGiftData.buyGotInfos
			};
			if (mallItemInfo.buyGotInfos != null && mallItemInfo.buyGotInfos.Length != 0)
			{
				this.presentationGo.CustomActive(true);
				this.presentationNum.text = string.Format("*{0}", mallItemInfo.buyGotInfos[0].buyGotNum.ToString());
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)mallItemInfo.buyGotInfos[0].itemDataId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ETCImageLoader.LoadSprite(ref this.presentationIcon, tableItem.Icon, true);
				}
				this.presentationBtn.onClick.RemoveAllListeners();
				ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)mallItemInfo.buyGotInfos[0].itemDataId, 100, 0);
				this.presentationBtn.onClick.AddListener(delegate()
				{
					this._OnShowTips(ItemDetailData);
				});
			}
		}

		// Token: 0x0600F94A RID: 63818 RVA: 0x0044099C File Offset: 0x0043ED9C
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			if (this.mActivityId == 5000)
			{
				Utility.DoStartFrameOperation("MallGiftPackActivity", string.Format("ItemID/{0}", result.TableID));
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600F94B RID: 63819 RVA: 0x004409EF File Offset: 0x0043EDEF
		private void OnButtonBuyClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mId, 0, 0UL);
			}
		}

		// Token: 0x0600F94C RID: 63820 RVA: 0x00440A10 File Offset: 0x0043EE10
		private void UpdateBuyCountNew(LimitTimeGiftPackDetailModel limitTimeGiftData)
		{
			bool flag = false;
			MallItemInfo mallItemInfo = new MallItemInfo();
			mallItemInfo.id = limitTimeGiftData.Id;
			mallItemInfo.limitnum = (ushort)limitTimeGiftData.LimitNum;
			mallItemInfo.limittotalnum = (ushort)limitTimeGiftData.LimitTotalNum;
			mallItemInfo.gift = (byte)limitTimeGiftData.GiftType;
			mallItemInfo.limit = limitTimeGiftData.Limit;
			mallItemInfo.accountLimitBuyNum = limitTimeGiftData.AccountLimitBuyNum;
			int leftLimitNum = Utility.GetLeftLimitNum(mallItemInfo, ref flag);
			string arg = string.Empty;
			bool flag2 = false;
			if (mallItemInfo.limitnum > 0 || mallItemInfo.limittotalnum > 0 || mallItemInfo.accountLimitBuyNum > 0U)
			{
				flag2 = true;
			}
			if (!flag2)
			{
				this.mTextDetail.CustomActive(false);
				this.mAccountTextDetail.CustomActive(false);
				this.UpdateBuyButton(true);
				return;
			}
			this.mTextDetail.CustomActive(true);
			ushort num = (mallItemInfo.limittotalnum <= mallItemInfo.limitnum) ? mallItemInfo.limitnum : mallItemInfo.limittotalnum;
			bool flag3 = false;
			int leftLimitNum2 = Utility.GetLeftLimitNum(mallItemInfo, ref flag3);
			if (mallItemInfo.limit == 3)
			{
				arg = TR.Value("limittime_mall_limit_role_week", leftLimitNum2, num);
			}
			else if (mallItemInfo.limit == 1)
			{
				arg = TR.Value("limittime_mall_limit_role_everyday", leftLimitNum2, num);
			}
			else if (mallItemInfo.limit == 2)
			{
				arg = TR.Value("limittime_mall_limit_role", leftLimitNum2, num);
			}
			if (leftLimitNum2 > 0)
			{
				this.UpdateBuyButton(true);
			}
			else
			{
				this.UpdateBuyButton(false);
			}
			this.mTextDetail.text = string.Format(TR.Value("activity_mall_gift_pack_item_detail").Replace("\\n", "\n"), arg, Function.GetLeftDay((int)DataManager<TimeManager>.GetInstance().GetServerTime(), (int)limitTimeGiftData.GiftEndTime));
		}

		// Token: 0x0600F94D RID: 63821 RVA: 0x00440BEC File Offset: 0x0043EFEC
		private void UpdateBuyButton(bool flag)
		{
			if (this.mButtonBuyGray != null)
			{
				this.mButtonBuyGray.enabled = !flag;
			}
			if (this.mButtonBuy != null)
			{
				this.mButtonBuy.interactable = flag;
			}
		}

		// Token: 0x0600F94E RID: 63822 RVA: 0x00440C2C File Offset: 0x0043F02C
		private void UpdateBuyCount(LimitTimeGiftPackDetailModel limitTimeGiftData)
		{
			bool flag = false;
			MallItemInfo mallItemInfo = new MallItemInfo();
			mallItemInfo.id = limitTimeGiftData.Id;
			mallItemInfo.limitnum = (ushort)limitTimeGiftData.LimitNum;
			mallItemInfo.limittotalnum = (ushort)limitTimeGiftData.LimitTotalNum;
			mallItemInfo.gift = (byte)limitTimeGiftData.GiftType;
			mallItemInfo.limit = limitTimeGiftData.Limit;
			int leftLimitNum = Utility.GetLeftLimitNum(mallItemInfo, ref flag);
			string arg = string.Empty;
			if (mallItemInfo.limit == 3)
			{
				arg = string.Format(TR.Value("limittime_mall_limit_number_week"), leftLimitNum);
			}
			else
			{
				arg = ((!flag) ? string.Format(TR.Value("mall_gift_buy"), leftLimitNum) : string.Format(TR.Value("mall_gift_daily_buy"), leftLimitNum));
			}
			if (leftLimitNum <= 0)
			{
				if (mallItemInfo.limit == 3)
				{
					arg = string.Format(TR.Value("limittime_mall_limit_number_finished_week"), new object[0]);
				}
				else
				{
					arg = ((!flag) ? TR.Value("mall_gift_empty") : TR.Value("mall_gift_daily_empty"));
				}
			}
			this.mTextDetail.text = string.Format(TR.Value("activity_mall_gift_pack_item_detail").Replace("\\n", "\n"), arg, Function.GetLeftDay((int)DataManager<TimeManager>.GetInstance().GetServerTime(), (int)limitTimeGiftData.GiftEndTime));
		}

		// Token: 0x0600F94F RID: 63823 RVA: 0x00440D84 File Offset: 0x0043F184
		private void OnMoneyChanged(PlayerBaseData.MoneyBinderType eTarget)
		{
			this.UpdateCostText();
		}

		// Token: 0x0600F950 RID: 63824 RVA: 0x00440D8C File Offset: 0x0043F18C
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_NEW_SERVER_GIFT_DISCOUNT) > 0UL)
			{
				this.HideOrShowFirstDiscountDes(false);
			}
		}

		// Token: 0x0600F951 RID: 63825 RVA: 0x00440DA8 File Offset: 0x0043F1A8
		private void _OnLimitTimeDataUpdate(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
			if (activeDataFromType != null && activeDataFromType.dataId == num && activeDataFromType.state == 0)
			{
				this.HideOrShowFirstDiscountDes(false);
			}
		}

		// Token: 0x0600F952 RID: 63826 RVA: 0x00440DF5 File Offset: 0x0043F1F5
		private void HideOrShowFirstDiscountDes(bool isShow)
		{
			this.mFirstDiscountRootGo.CustomActive(isShow);
			this.mFirstDiscountPriceRootGo.CustomActive(isShow);
		}

		// Token: 0x0600F953 RID: 63827 RVA: 0x00440E0F File Offset: 0x0043F20F
		public void Destroy()
		{
			this.Dispose();
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F954 RID: 63828 RVA: 0x00440E24 File Offset: 0x0043F224
		public void Dispose()
		{
			for (int i = this.mComItems.Count - 1; i >= 0; i--)
			{
				ComItemManager.Destroy(this.mComItems[i]);
			}
			this.mComItems.Clear();
			this.mButtonBuy.SafeRemoveOnClickListener(new UnityAction(this.OnButtonBuyClick));
			if (this.mSimpleTimer)
			{
				this.mSimpleTimer.StopTimer();
			}
			PlayerBaseData instance = DataManager<PlayerBaseData>.GetInstance();
			instance.onMoneyChanged = (PlayerBaseData.OnMoneyChanged)Delegate.Remove(instance.onMoneyChanged, new PlayerBaseData.OnMoneyChanged(this.OnMoneyChanged));
			this.mIsCanShowDiscount = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
			this.mFirstDiscountActivityData = null;
			if (this.mFirstDiscountTimer != null)
			{
				this.mFirstDiscountTimer.StopTimer();
			}
		}

		// Token: 0x04009AFE RID: 39678
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009AFF RID: 39679
		[SerializeField]
		private Image mImageBg;

		// Token: 0x04009B00 RID: 39680
		[SerializeField]
		private RectTransform mItemRoot;

		// Token: 0x04009B01 RID: 39681
		[SerializeField]
		private Vector2 mComItemSize;

		// Token: 0x04009B02 RID: 39682
		[SerializeField]
		private Button mButtonBuy;

		// Token: 0x04009B03 RID: 39683
		[SerializeField]
		private UIGray mButtonBuyGray;

		// Token: 0x04009B04 RID: 39684
		[SerializeField]
		private Text mTextDetail;

		// Token: 0x04009B05 RID: 39685
		[SerializeField]
		private SimpleTimer mSimpleTimer;

		// Token: 0x04009B06 RID: 39686
		[SerializeField]
		private Image mImageCurrency;

		// Token: 0x04009B07 RID: 39687
		[SerializeField]
		private Text mTextCost;

		// Token: 0x04009B08 RID: 39688
		[SerializeField]
		private Color mNotEnoughColor = Color.red;

		// Token: 0x04009B09 RID: 39689
		[SerializeField]
		private GameObject presentationGo;

		// Token: 0x04009B0A RID: 39690
		[SerializeField]
		private Image presentationIcon;

		// Token: 0x04009B0B RID: 39691
		[SerializeField]
		private Text presentationNum;

		// Token: 0x04009B0C RID: 39692
		[SerializeField]
		private Button presentationBtn;

		// Token: 0x04009B0D RID: 39693
		[SerializeField]
		private GameObject discountGo;

		// Token: 0x04009B0E RID: 39694
		[SerializeField]
		private Text mAccountTextDetail;

		// Token: 0x04009B0F RID: 39695
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009B10 RID: 39696
		private Color mCostOriginalCorlor;

		// Token: 0x04009B11 RID: 39697
		private LimitTimeGiftPackDetailModel mData;

		// Token: 0x04009B12 RID: 39698
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009B13 RID: 39699
		private int mId;

		// Token: 0x04009B14 RID: 39700
		private int accountLimitNum = -1;

		// Token: 0x04009B15 RID: 39701
		private int mActivityId;

		// Token: 0x04009B16 RID: 39702
		[SerializeField]
		private Text mFirstDiscountDesTxt;

		// Token: 0x04009B17 RID: 39703
		[SerializeField]
		private SimpleTimer mFirstDiscountTimer;

		// Token: 0x04009B18 RID: 39704
		[SerializeField]
		private Text mFirstDiscountPriceTxt;

		// Token: 0x04009B19 RID: 39705
		[SerializeField]
		private Image mFirstDiscountPriceIconImg;

		// Token: 0x04009B1A RID: 39706
		[SerializeField]
		private GameObject mFirstDiscountRootGo;

		// Token: 0x04009B1B RID: 39707
		[SerializeField]
		private GameObject mFirstDiscountPriceRootGo;

		// Token: 0x04009B1C RID: 39708
		[SerializeField]
		private GameObject mMayDayGiftDiscountRoot;

		// Token: 0x04009B1D RID: 39709
		[SerializeField]
		private Text mMayDayDiscount;

		// Token: 0x04009B1E RID: 39710
		private OpActivityData mFirstDiscountActivityData;

		// Token: 0x04009B1F RID: 39711
		private bool mIsCanShowDiscount;
	}
}
