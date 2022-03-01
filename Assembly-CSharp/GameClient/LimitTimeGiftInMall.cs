using System;
using LimitTimeGift;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001738 RID: 5944
	public class LimitTimeGiftInMall : ActivityLTObject<LimitTimeGiftInMall>
	{
		// Token: 0x0600E99F RID: 59807 RVA: 0x003DDA3C File Offset: 0x003DBE3C
		public void Init(GameObject parent, ClientFrame mallFrame, LimitTimeGiftData giftData)
		{
			this.Create();
			this.goParent = parent;
			this.frame = mallFrame;
			this.currGiftData = giftData;
			if (this.goSelf != null && this.goParent != null)
			{
				Utility.AttachTo(this.goSelf, this.goParent, false);
				this.mBind = this.goSelf.GetComponent<ComCommonBind>();
				if (this.mBind)
				{
					this.giftName = this.mBind.GetCom<Text>("giftName");
					this.limitBuyCount = this.mBind.GetCom<Text>("limitPurchase");
					this.awardParent = this.mBind.GetGameObject("awardParent");
					this.giftDesc = this.mBind.GetCom<Text>("giftDesc");
					this.lastTime = this.mBind.GetCom<Text>("remainingTime");
					this.timer = this.mBind.GetCom<SimpleTimer>("timer");
					this.buyBtn = this.mBind.GetCom<Button>("buyBtn");
					if (this.buyBtn)
					{
						this.buyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyBtnClick));
						this.buyBtn.onClick.AddListener(new UnityAction(this.OnBuyBtnClick));
					}
					this.uiGray = this.mBind.GetCom<UIGray>("BtnGray");
					this.EnabledBuyBtn(true);
					this.giftPrice = this.mBind.GetCom<Text>("giftPrice");
					this.priceTypeImg = this.mBind.GetCom<Image>("priceTypeImg");
				}
				this.SetDataToView();
			}
		}

		// Token: 0x0600E9A0 RID: 59808 RVA: 0x003DDBEA File Offset: 0x003DBFEA
		public override void Create()
		{
			base.Create();
			this.goSelf = MonoSingleton<LimitTimeGiftMallItemManager>.instance.GetMallGiftGo();
		}

		// Token: 0x0600E9A1 RID: 59809 RVA: 0x003DDC04 File Offset: 0x003DC004
		public override void Destory()
		{
			base.Destory();
			MonoSingleton<LimitTimeGiftMallItemManager>.instance.ReleaseMallGiftGo(this.goSelf);
			if (this.comItems != null)
			{
				for (int i = 0; i < this.comItems.Length; i++)
				{
					ComItemManager.Destroy(this.comItems[i]);
				}
				this.comItems = null;
			}
			this.Reset();
		}

		// Token: 0x0600E9A2 RID: 59810 RVA: 0x003DDC68 File Offset: 0x003DC068
		private void SetDataToView()
		{
			if (this.currGiftData == null)
			{
				return;
			}
			if (this.giftName)
			{
				this.giftName.text = this.currGiftData.GiftName;
			}
			if (this.limitBuyCount)
			{
				if (this.currGiftData.GiftType == MallGoodsType.GIFT_DAILY_REFRESH)
				{
					this.UpdateBuyCount(this.currGiftData);
				}
				else if (this.currGiftData.GiftType == MallGoodsType.GIFT_COMMON)
				{
					this.limitBuyCount.text = string.Empty;
				}
				else
				{
					this.UpdateBuyCount(this.currGiftData);
				}
			}
			if (this.currGiftData.LimitTotalNum > 0)
			{
				int num;
				if (this.currGiftData.LimitPurchaseNum < this.currGiftData.LimitLastNum)
				{
					num = this.currGiftData.LimitPurchaseNum;
				}
				else
				{
					num = this.currGiftData.LimitLastNum;
				}
				if (num > 0)
				{
					if (this.currGiftData.GiftType == MallGoodsType.GIFT_DAILY_REFRESH)
					{
						this.UpdateBuyCount(this.currGiftData);
					}
					else
					{
						this.UpdateBuyCount(this.currGiftData);
					}
				}
				else if (this.currGiftData.GiftType == MallGoodsType.GIFT_DAILY_REFRESH)
				{
					this.UpdateBuyCount(this.currGiftData);
				}
				else
				{
					this.UpdateBuyCount(this.currGiftData);
				}
			}
			if (this.awardParent && this.comItems == null && this.currGiftData.GiftAwards != null && this.frame != null)
			{
				int count = this.currGiftData.GiftAwards.Count;
				this.comItems = new ComItem[count];
				this.awardItems = new GameObject[count];
				if (this.awardParent.transform == null)
				{
					Logger.LogError("awardParent.transform is null");
					return;
				}
				int childCount = this.awardParent.transform.childCount;
				for (int i = 0; i < childCount; i++)
				{
					this.awardParent.transform.GetChild(i).gameObject.CustomActive(true);
				}
				if (this.awardItems == null)
				{
					return;
				}
				if (count <= 0)
				{
					return;
				}
				if (this.awardParent != null)
				{
					for (int j = 0; j < count; j++)
					{
						if (this.awardParent.transform.childCount < count)
						{
							return;
						}
						Transform child = this.awardParent.transform.GetChild(j);
						if (child == null)
						{
							Logger.LogError("child is null");
						}
						else
						{
							this.awardItems[j] = this.awardParent.transform.GetChild(j).gameObject;
							if (this.awardItems[j] != null)
							{
								Image componentInChildren = this.awardItems[j].GetComponentInChildren<Image>();
								Text componentInChildren2 = this.awardItems[j].GetComponentInChildren<Text>();
								if (componentInChildren == null)
								{
									return;
								}
								if (this.currGiftData.GiftAwards[j] != null)
								{
									this.comItems[j] = this.frame.CreateComItem(componentInChildren.gameObject);
									ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.currGiftData.GiftAwards[j].AwardId, 100, 0);
									if (itemData != null)
									{
										itemData.Count = (int)this.currGiftData.GiftAwards[j].AwardCount;
										itemData.StrengthenLevel = this.currGiftData.GiftAwards[j].StrengthLevel;
										componentInChildren2.text = itemData.Name;
										this.comItems[j].Setup(itemData, delegate(GameObject go, ItemData itemPa)
										{
											DataManager<ItemTipManager>.GetInstance().ShowTip(itemPa, null, 4, true, false, true);
										});
									}
								}
							}
						}
					}
				}
				if (childCount > count)
				{
					for (int k = childCount - 1; k >= count; k--)
					{
						this.awardParent.transform.GetChild(k).gameObject.CustomActive(false);
					}
				}
			}
			if (this.giftDesc)
			{
				this.giftDesc.text = this.currGiftData.GiftDesc;
			}
			if (this.timer)
			{
				if (this.currGiftData.NeedTimeCountDown)
				{
					this.timer.useSystemUpdate = true;
				}
				else
				{
					this.timer.useSystemUpdate = false;
				}
				this.timer.SetCountdown((int)this.currGiftData.RemainingTimeSec);
				this.timer.StartTimer();
			}
			if (this.giftPrice)
			{
				this.giftPrice.text = "促销价：" + this.currGiftData.GiftPrice;
			}
			if (this.priceTypeImg)
			{
				this.priceTypeImg.gameObject.CustomActive(this.currGiftData.PriceType == LimitTimeGiftPriceType.Point);
			}
			if (this.currGiftData.LimitPurchaseNum > 0)
			{
				this.EnabledBuyBtn(true);
			}
			else
			{
				if (this.currGiftData.GiftType == MallGoodsType.GIFT_COMMON)
				{
					return;
				}
				this.EnabledBuyBtn(false);
				if (this.limitBuyCount)
				{
					if (this.currGiftData.GiftType == MallGoodsType.GIFT_DAILY_REFRESH)
					{
						this.UpdateBuyCount(this.currGiftData);
					}
					else
					{
						this.UpdateBuyCount(this.currGiftData);
					}
				}
				if (this.timer)
				{
				}
			}
		}

		// Token: 0x0600E9A3 RID: 59811 RVA: 0x003DE1E4 File Offset: 0x003DC5E4
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
			this.currGiftData.LimitPurchaseNum = leftLimitNum;
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

		// Token: 0x0600E9A4 RID: 59812 RVA: 0x003DE2D1 File Offset: 0x003DC6D1
		public void AddBuyAction(LimitTimeGiftInMall.BuyAction buyAct)
		{
			this.buyAction = buyAct;
		}

		// Token: 0x0600E9A5 RID: 59813 RVA: 0x003DE2DA File Offset: 0x003DC6DA
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

		// Token: 0x0600E9A6 RID: 59814 RVA: 0x003DE317 File Offset: 0x003DC717
		public uint GetCurrItemDataId()
		{
			if (this.currGiftData == null)
			{
				return 0U;
			}
			return this.currGiftData.GiftId;
		}

		// Token: 0x0600E9A7 RID: 59815 RVA: 0x003DE331 File Offset: 0x003DC731
		public void RefreshView(LimitTimeGiftData giftData)
		{
			this.currGiftData = giftData;
			this.SetDataToView();
		}

		// Token: 0x0600E9A8 RID: 59816 RVA: 0x003DE340 File Offset: 0x003DC740
		public LimitTimeGiftData GetCurrItemData()
		{
			return this.currGiftData;
		}

		// Token: 0x0600E9A9 RID: 59817 RVA: 0x003DE348 File Offset: 0x003DC748
		private void OnSelectThreeToOneGift(ItemData itemData, object data)
		{
			if (itemData != null)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<SelectItemFrame>(FrameLayer.Middle, itemData, string.Empty);
			}
		}

		// Token: 0x0600E9AA RID: 59818 RVA: 0x003DE364 File Offset: 0x003DC764
		private void Reset()
		{
			this.giftName = null;
			this.limitBuyCount = null;
			this.awardParent = null;
			this.giftDesc = null;
			this.lastTime = null;
			if (this.timer)
			{
				this.timer.StopTimer();
			}
			this.timer = null;
			if (this.buyBtn)
			{
				this.buyBtn.onClick.RemoveListener(new UnityAction(this.OnBuyBtnClick));
			}
			this.buyBtn = null;
			this.uiGray = null;
			this.giftPrice = null;
			this.priceTypeImg = null;
			this.goSelf = null;
			this.goParent = null;
			this.frame = null;
			this.currGiftData = null;
			this.comItems = null;
			this.buyAction = null;
		}

		// Token: 0x0600E9AB RID: 59819 RVA: 0x003DE428 File Offset: 0x003DC828
		private void OnBuyBtnClick()
		{
			if (this.buyAction != null && this.currGiftData != null)
			{
				this.buyAction(this.currGiftData.GiftId, this.currGiftData.GiftPrice, this.currGiftData.PriceType, this.currGiftData.mallItemInfoData);
			}
		}

		// Token: 0x04008DAF RID: 36271
		protected LimitTimeGiftData currGiftData;

		// Token: 0x04008DB0 RID: 36272
		protected GameObject goParent;

		// Token: 0x04008DB1 RID: 36273
		protected ClientFrame frame;

		// Token: 0x04008DB2 RID: 36274
		protected ComCommonBind mBind;

		// Token: 0x04008DB3 RID: 36275
		private Text giftName;

		// Token: 0x04008DB4 RID: 36276
		private Text limitBuyCount;

		// Token: 0x04008DB5 RID: 36277
		private GameObject awardParent;

		// Token: 0x04008DB6 RID: 36278
		private GameObject[] awardItems;

		// Token: 0x04008DB7 RID: 36279
		private Text giftDesc;

		// Token: 0x04008DB8 RID: 36280
		private Text lastTime;

		// Token: 0x04008DB9 RID: 36281
		private SimpleTimer timer;

		// Token: 0x04008DBA RID: 36282
		private Button buyBtn;

		// Token: 0x04008DBB RID: 36283
		private UIGray uiGray;

		// Token: 0x04008DBC RID: 36284
		private Text giftPrice;

		// Token: 0x04008DBD RID: 36285
		private Image priceTypeImg;

		// Token: 0x04008DBE RID: 36286
		private ComItem[] comItems;

		// Token: 0x04008DBF RID: 36287
		protected LimitTimeGiftInMall.BuyAction buyAction;

		// Token: 0x02001739 RID: 5945
		// (Invoke) Token: 0x0600E9AE RID: 59822
		public delegate void BuyAction(uint giftId, int giftPrice, LimitTimeGiftPriceType priceType, MallItemInfo mallItemInfoData);
	}
}
