using System;
using System.Collections.Generic;
using ActivityLimitTime;
using LimitTimeGift;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001737 RID: 5943
	public class LimitTimeGiftFrame : ClientFrame
	{
		// Token: 0x0600E98E RID: 59790 RVA: 0x003DCF1C File Offset: 0x003DB31C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/LimitTimeGiftFrame";
		}

		// Token: 0x0600E98F RID: 59791 RVA: 0x003DCF24 File Offset: 0x003DB324
		protected override void _bindExUI()
		{
			this.closeBtn = this.mBind.GetCom<Button>("closeBtn");
			if (this.closeBtn)
			{
				this.closeBtn.onClick.RemoveListener(new UnityAction(this.OnCloseBtnClick));
				this.closeBtn.onClick.AddListener(new UnityAction(this.OnCloseBtnClick));
			}
			this.giftName = this.mBind.GetCom<Text>("giftName");
			this.limitBuyCount = this.mBind.GetCom<Text>("limitBuyCount");
			this.awardParent = this.mBind.GetGameObject("awardParent");
			this.awardDesc = this.mBind.GetCom<Text>("awardDesc");
			this.awardLastTime = this.mBind.GetCom<Text>("awardLastTime");
			this.timer = this.mBind.GetCom<SimpleTimer>("timer");
			this.buyBtn = this.mBind.GetCom<Button>("buyBtn");
			if (this.buyBtn)
			{
				this.buyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyBtnClick));
				this.buyBtn.onClick.AddListener(new UnityAction(this.OnBuyBtnClick));
			}
			this.uiGray = this.mBind.GetCom<UIGray>("BtnGray");
			this.EnabledBuyBtn(true);
			this.buyBtnText = this.mBind.GetCom<Text>("buyBtnText");
			this.buyBtnImg = this.mBind.GetCom<Image>("buyBtnImage");
		}

		// Token: 0x0600E990 RID: 59792 RVA: 0x003DD0BC File Offset: 0x003DB4BC
		protected override void _unbindExUI()
		{
			if (this.closeBtn)
			{
				this.closeBtn.onClick.RemoveListener(new UnityAction(this.OnCloseBtnClick));
			}
			this.closeBtn = null;
			this.giftName = null;
			this.limitBuyCount = null;
			this.awardParent = null;
			this.awardDesc = null;
			this.awardLastTime = null;
			this.timer = null;
			if (this.buyBtn)
			{
				this.buyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyBtnClick));
			}
			this.buyBtn = null;
			this.uiGray = null;
			this.buyBtnText = null;
			this.buyBtnImg = null;
		}

		// Token: 0x0600E991 RID: 59793 RVA: 0x003DD170 File Offset: 0x003DB570
		protected override void _OnOpenFrame()
		{
			this.giftData = (this.userData as LimitTimeGiftData);
			if (this.giftData != null)
			{
				this.limitPurNumTemp = this.giftData.LimitPurchaseNum;
				this.SetDataToView();
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.AddItemBuyRetListener(new Action<LimitTimeGiftData>(this.RefreshView));
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.AddItemPayRetListener(new Action(this.RefreshView));
			}
		}

		// Token: 0x0600E992 RID: 59794 RVA: 0x003DD1F8 File Offset: 0x003DB5F8
		protected override void _OnCloseFrame()
		{
			if (this.comItems != null)
			{
				for (int i = 0; i < this.comItems.Length; i++)
				{
					if (this.comItems[i] != null)
					{
						ComItemManager.Destroy(this.comItems[i]);
					}
				}
				this.comItems = null;
			}
			this.giftData = null;
			if (this.timer != null)
			{
				this.timer.StopTimer();
			}
			if (Singleton<LimitTimeGiftFrameManager>.instance != null)
			{
				Singleton<LimitTimeGiftFrameManager>.instance.RemoveCurrShowGiftFrame(this);
			}
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.HasLimitTimeGiftToBuy, null, null, null, null);
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.RemoveAllItemBuyRetListener();
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.RemoveAllItemPayRetListener();
			}
		}

		// Token: 0x0600E993 RID: 59795 RVA: 0x003DD2C8 File Offset: 0x003DB6C8
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600E994 RID: 59796 RVA: 0x003DD2CC File Offset: 0x003DB6CC
		private void SetDataToView()
		{
			if (this.giftName)
			{
				this.giftName.text = this.giftData.GiftName;
			}
			if (this.limitBuyCount)
			{
				this.limitBuyCount.text = "永久限购：" + this.giftData.LimitPurchaseNum + "次";
			}
			if (this.giftData.LimitPurchaseNum > 0 || (this.giftData.GiftType != MallGoodsType.GIFT_DAILY_REFRESH && this.giftData.LimitTotalNum > 0))
			{
				this.EnabledBuyBtn(true);
			}
			else
			{
				this.EnabledBuyBtn(false);
			}
			if (this.awardParent && this.comItems == null && this.giftData.GiftAwards != null)
			{
				int count = this.giftData.GiftAwards.Count;
				if (count <= 0)
				{
					return;
				}
				this.comItems = new ComItem[count];
				GameObject[] array = new GameObject[count];
				for (int i = 0; i < count; i++)
				{
					array[i] = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/LimitTimeGift/LimitTimeAwardItem", true, 0U);
					if (array[i] != null)
					{
						Utility.AttachTo(array[i], this.awardParent, false);
						Image componentInChildren = array[i].GetComponentInChildren<Image>();
						Text componentInChildren2 = array[i].GetComponentInChildren<Text>();
						if (componentInChildren2 == null && componentInChildren == null)
						{
							return;
						}
						this.comItems[i] = base.CreateComItem(componentInChildren.gameObject);
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.giftData.GiftAwards[i].AwardId, 100, 0);
						if (itemData != null)
						{
							itemData.Count = (int)this.giftData.GiftAwards[i].AwardCount;
							itemData.StrengthenLevel = this.giftData.GiftAwards[i].StrengthLevel;
							componentInChildren2.text = itemData.Name;
							this.comItems[i].Setup(itemData, delegate(GameObject go, ItemData itemPa)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemPa, null, 4, true, false, true);
							});
						}
					}
				}
			}
			if (this.awardDesc)
			{
				this.awardDesc.text = this.giftData.GiftDesc;
			}
			if (this.timer)
			{
				if (this.giftData.NeedTimeCountDown)
				{
					this.timer.useSystemUpdate = true;
				}
				else
				{
					this.timer.useSystemUpdate = false;
				}
				this.timer.SetCountdown((int)this.giftData.RemainingTimeSec);
				if (this.timer.GetCurrTime4() != null)
				{
					if (this.timer.GetCurrTime4().day > 0)
					{
						this.purLimitTimeStr = this.timer.GetCurrTime4().day + "天";
					}
					else
					{
						this.purLimitTimeStr = this.timer.GetCurrTime4().hour + "小时";
					}
				}
				this.timer.StartTimer();
			}
			if (this.buyBtnText)
			{
				this.buyBtnText.text = "促销价：" + this.giftData.GiftPrice;
			}
			if (this.buyBtnImg)
			{
				this.buyBtnImg.gameObject.CustomActive(this.giftData.PriceType == LimitTimeGiftPriceType.Point);
			}
			if (this.giftData.LimitPurchaseNum > 0 || (this.giftData.GiftType != MallGoodsType.GIFT_DAILY_REFRESH && this.giftData.LimitTotalNum > 0))
			{
				this.EnabledBuyBtn(true);
			}
			else
			{
				this.EnabledBuyBtn(false);
				if (this.limitBuyCount)
				{
					if (this.giftData.GiftType == MallGoodsType.GIFT_DAILY_REFRESH)
					{
						this.UpdateBuyCount(this.giftData);
					}
					else
					{
						this.UpdateBuyCount(this.giftData);
					}
				}
				if (this.timer)
				{
				}
			}
			this.currLimitPurNum = this.giftData.LimitPurchaseNum;
		}

		// Token: 0x0600E995 RID: 59797 RVA: 0x003DD701 File Offset: 0x003DBB01
		public uint GetCurrFrameDataId()
		{
			if (this.giftData == null)
			{
				return 0U;
			}
			return this.giftData.GiftId;
		}

		// Token: 0x0600E996 RID: 59798 RVA: 0x003DD71B File Offset: 0x003DBB1B
		public void RefreshView(LimitTimeGiftData giftData)
		{
			this.giftData = giftData;
			this.SetDataToView();
		}

		// Token: 0x0600E997 RID: 59799 RVA: 0x003DD72C File Offset: 0x003DBB2C
		public void RefreshView()
		{
			if (this.giftData == null)
			{
				return;
			}
			List<LimitTimeGiftData> allLimitTimeGiftData = DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.GetAllLimitTimeGiftData();
			if (allLimitTimeGiftData != null)
			{
				for (int i = 0; i < allLimitTimeGiftData.Count; i++)
				{
					if (this.giftData.GiftId == allLimitTimeGiftData[i].GiftId)
					{
						this.giftData = allLimitTimeGiftData[i];
						this.SetDataToView();
					}
				}
			}
		}

		// Token: 0x0600E998 RID: 59800 RVA: 0x003DD7A1 File Offset: 0x003DBBA1
		public void EnabledBuyBtn(bool enabled)
		{
			if (this.uiGray)
			{
				this.uiGray.enabled = !enabled;
				if (this.buyBtn)
				{
					this.buyBtn.interactable = enabled;
				}
			}
		}

		// Token: 0x0600E999 RID: 59801 RVA: 0x003DD7E0 File Offset: 0x003DBBE0
		private void OnCloseBtnClick()
		{
			if (this.limitPurNumTemp <= this.currLimitPurNum)
			{
				CommonNotifyData commonNotifyData = new CommonNotifyData();
				commonNotifyData.contentStr = "  限时礼包持续" + this.purLimitTimeStr + "，过期将无法购买\n关闭界面后可以前往商城限时抢购页面内查看";
				commonNotifyData.ownerFrame = this;
				Singleton<ClientSystemManager>.instance.OpenFrame<CommonNotifyFrame>(base.GetLayer(), commonNotifyData, string.Empty);
			}
			else
			{
				base.Close(false);
			}
		}

		// Token: 0x0600E99A RID: 59802 RVA: 0x003DD84C File Offset: 0x003DBC4C
		private void OnBuyBtnClick()
		{
			if (this.giftData != null)
			{
				LimitTimeGiftPriceType priceType = this.giftData.PriceType;
				uint id = this.giftData.GiftId;
				int price = this.giftData.GiftPrice;
				if (priceType == LimitTimeGiftPriceType.Point)
				{
					string msgContent = string.Format("是否确定花费{0}点券购买该礼包？", price);
					SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().GiftDataManager.SendReqBuyGiftInMall(id, price, 1);
					}, null, 0f, false);
				}
				else if (priceType == LimitTimeGiftPriceType.RMB)
				{
					Singleton<PayManager>.GetInstance().DoPay((int)id, price, ChargeMallType.Packet);
				}
			}
		}

		// Token: 0x0600E99B RID: 59803 RVA: 0x003DD8F1 File Offset: 0x003DBCF1
		private void OnSelectThreeToOneGift(ItemData itemData, object data)
		{
			if (itemData != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectItemFrame>(FrameLayer.Middle, itemData, string.Empty);
			}
		}

		// Token: 0x0600E99C RID: 59804 RVA: 0x003DD90C File Offset: 0x003DBD0C
		private void UpdateBuyCount(LimitTimeGiftData limitTimeGiftData)
		{
			bool flag = false;
			int leftLimitNum = Utility.GetLeftLimitNum(new MallItemInfo
			{
				id = limitTimeGiftData.GiftId,
				limitnum = (ushort)limitTimeGiftData.LimitNum,
				limittotalnum = (ushort)limitTimeGiftData.LimitTotalNum,
				gift = (byte)limitTimeGiftData.GiftType
			}, ref flag);
			this.giftData.LimitPurchaseNum = leftLimitNum;
			if (leftLimitNum > 0)
			{
				this.EnabledBuyBtn(true);
			}
			else
			{
				this.EnabledBuyBtn(false);
			}
			if (leftLimitNum > 0)
			{
				this.limitBuyCount.text = ((!flag) ? string.Format(TR.Value("mall_gift_buy"), leftLimitNum) : string.Format(TR.Value("mall_gift_daily_buy"), leftLimitNum));
			}
			else
			{
				this.limitBuyCount.text = ((!flag) ? TR.Value("mall_gift_empty") : TR.Value("mall_gift_daily_empty"));
			}
		}

		// Token: 0x04008D9B RID: 36251
		public const string AwardItemTransPath = "UIFlatten/Prefabs/LimitTimeGift/LimitTimeAwardItem";

		// Token: 0x04008D9C RID: 36252
		private const string PayByTicketNotice = "是否确定花费{0}点券购买该礼包？";

		// Token: 0x04008D9D RID: 36253
		private Button closeBtn;

		// Token: 0x04008D9E RID: 36254
		private Text giftName;

		// Token: 0x04008D9F RID: 36255
		private Text limitBuyCount;

		// Token: 0x04008DA0 RID: 36256
		private GameObject awardParent;

		// Token: 0x04008DA1 RID: 36257
		private Text awardDesc;

		// Token: 0x04008DA2 RID: 36258
		private Text awardLastTime;

		// Token: 0x04008DA3 RID: 36259
		private SimpleTimer timer;

		// Token: 0x04008DA4 RID: 36260
		private Button buyBtn;

		// Token: 0x04008DA5 RID: 36261
		private UIGray uiGray;

		// Token: 0x04008DA6 RID: 36262
		private Text buyBtnText;

		// Token: 0x04008DA7 RID: 36263
		private Image buyBtnImg;

		// Token: 0x04008DA8 RID: 36264
		private ComItem[] comItems;

		// Token: 0x04008DA9 RID: 36265
		private LimitTimeGiftData giftData;

		// Token: 0x04008DAA RID: 36266
		private int countDown;

		// Token: 0x04008DAB RID: 36267
		private int limitPurNumTemp;

		// Token: 0x04008DAC RID: 36268
		private int currLimitPurNum;

		// Token: 0x04008DAD RID: 36269
		private string purLimitTimeStr;
	}
}
