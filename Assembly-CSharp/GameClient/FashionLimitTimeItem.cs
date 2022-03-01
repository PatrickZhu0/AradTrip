using System;
using System.Collections.Generic;
using FashionLimitTimeBuy;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001728 RID: 5928
	internal class FashionLimitTimeItem : ActivityLTObject<FashionLimitTimeItem>
	{
		// Token: 0x0600E8CB RID: 59595 RVA: 0x003D96EC File Offset: 0x003D7AEC
		public override void Create()
		{
			base.Create();
			this.goSelf = MonoSingleton<FashionLimitTimeItemManager>.instance.GetFashionItem();
		}

		// Token: 0x0600E8CC RID: 59596 RVA: 0x003D9704 File Offset: 0x003D7B04
		public override void Destory()
		{
			base.Destory();
			MonoSingleton<FashionLimitTimeItemManager>.instance.ReleaseFashionItem(this.goSelf);
			this.Reset();
		}

		// Token: 0x0600E8CD RID: 59597 RVA: 0x003D9724 File Offset: 0x003D7B24
		public void Init(GameObject parent, ClientFrame frame, SelectMallItemInfoData itemData)
		{
			this.Create();
			this.goParent = parent;
			this.frame = frame;
			this.currItemData = itemData;
			if (this.goSelf != null && this.goParent != null)
			{
				Utility.AttachTo(this.goSelf, this.goParent, false);
				this.mBind = this.goSelf.GetComponent<ComCommonBind>();
				if (this.mBind)
				{
					this.limitTimeLogo = this.mBind.GetGameObject("limitTimeLogo");
					this.limitTimeImg = this.mBind.GetCom<Image>("limitTimeImg");
					this.priceText = this.mBind.GetCom<Text>("priceText");
					this.descText = this.mBind.GetCom<Text>("descText");
					this.mOldPrice = this.mBind.GetCom<Text>("OldPrice");
					this.mFashionDiscount = this.mBind.GetCom<Text>("FashionDiscount");
					this.checkImg = this.mBind.GetGameObject("checkImg");
					this.toggle = this.mBind.GetCom<Toggle>("Toggle");
					if (this.toggle)
					{
						this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleOn));
						this.toggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnToggleOn));
						this.toggle.isOn = false;
					}
					this.mIntergralMallInfoRoot = this.mBind.GetGameObject("IntergralMallInfoRoot");
					this.mIntergralInfoText = this.mBind.GetCom<Text>("IntergralInfoText");
				}
			}
			this.SetDataToView();
			this.InitIntergralInfoRoot();
		}

		// Token: 0x0600E8CE RID: 59598 RVA: 0x003D98DD File Offset: 0x003D7CDD
		public void RefreshView(SelectMallItemInfoData data)
		{
			this.currItemData = data;
			this.SetDataToView();
		}

		// Token: 0x0600E8CF RID: 59599 RVA: 0x003D98EC File Offset: 0x003D7CEC
		private void SetDataToView()
		{
			if (this.currItemData == null)
			{
				return;
			}
			if (this.currItemData.SelectItemInfos == null || this.currItemData.SelectItemInfos.Count <= 0)
			{
				return;
			}
			this.priceText.text = this.currItemData.TotalPrice + string.Empty;
			this.mOldPrice.text = this.currItemData._FashionDiscountPrice + string.Empty;
			if (this.currItemData._Discount == 0f)
			{
				this.mFashionDiscount.CustomActive(false);
				this.mOldPrice.CustomActive(false);
			}
			else
			{
				DataManager<FashionLimitTimeBuyManager>.GetInstance().haveFashionDiscount = true;
				this.mFashionDiscount.CustomActive(true);
				this.mOldPrice.CustomActive(true);
			}
			this.mFashionDiscount.text = this.currItemData._Discount + "折";
			List<uint> list = new List<uint>();
			if (this.currItemData.FashionTypeIndex == FashionMallMainIndex.FashionAll)
			{
				ItemReward[] giftItems = this.currItemData.SelectItemInfos[0].giftItems;
				if (giftItems != null)
				{
					for (int i = 0; i < giftItems.Length; i++)
					{
						list.Add(giftItems[i].id);
					}
				}
			}
			else if (this.currItemData.FashionTypeIndex == FashionMallMainIndex.FashionOne)
			{
				list.Add(this.currItemData.SelectItemInfos[0].itemid);
			}
			for (int j = 0; j < list.Count; j++)
			{
				this.CreateItemsById((int)list[j]);
			}
		}

		// Token: 0x0600E8D0 RID: 59600 RVA: 0x003D9A9B File Offset: 0x003D7E9B
		private void InitIntergralInfoRoot()
		{
			if (this.currItemData == null)
			{
				return;
			}
			if (this.mIntergralMallInfoRoot != null)
			{
				this.mIntergralMallInfoRoot.CustomActive(this.currItemData.multiple > 0);
			}
			this.UpdataIntergralInfo();
		}

		// Token: 0x0600E8D1 RID: 59601 RVA: 0x003D9ADC File Offset: 0x003D7EDC
		private void UpdataIntergralInfo()
		{
			if (this.currItemData == null)
			{
				return;
			}
			int num = MallNewUtility.GetTicketConvertIntergalNumnber(this.currItemData.TotalPrice) * this.currItemData.multiple;
			string text = string.Empty;
			if (this.currItemData.multiple <= 1)
			{
				text = TR.Value("mall_buy_intergral_single_multiple_desc", num);
			}
			else
			{
				text = TR.Value("mall_buy_intergral_many_multiple_desc", num, this.currItemData.multiple);
			}
			if (this.mIntergralInfoText != null)
			{
				this.mIntergralInfoText.text = text;
			}
		}

		// Token: 0x0600E8D2 RID: 59602 RVA: 0x003D9B80 File Offset: 0x003D7F80
		private void CreateItemsById(int itemId)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				int timeLeft = tableItem.TimeLeft;
				if (timeLeft <= 0)
				{
					if (this.limitTimeLogo)
					{
						this.limitTimeLogo.CustomActive(false);
					}
					if (this.limitTimeImg)
					{
						ETCImageLoader.LoadSprite(ref this.limitTimeImg, "UI/Image/Packed/p_UI_Shop_01.png:UI_Shop_Tubiao_Yongjiu", true);
					}
					if (this.descText)
					{
						this.descText.text = TR.Value("fashion_buy_forever_use");
					}
				}
				else
				{
					if (this.limitTimeLogo)
					{
						this.limitTimeLogo.CustomActive(true);
					}
					if (timeLeft == 604800)
					{
						if (this.limitTimeImg)
						{
							ETCImageLoader.LoadSprite(ref this.limitTimeImg, "UI/Image/Packed/p_UI_Shop_01.png:UI_Shop_Tubiao_Qitian", true);
						}
						if (this.descText)
						{
							this.descText.text = TR.Value("fashion_buy_sevenday_use");
							this.descText.text.Replace("\\n", "\n");
						}
					}
					else if (timeLeft == 2592000)
					{
						if (this.limitTimeImg)
						{
							ETCImageLoader.LoadSprite(ref this.limitTimeImg, "UI/Image/Packed/p_UI_Shop_01.png:UI_Shop_Tubiao_Sanshitian", true);
						}
						if (this.descText)
						{
							this.descText.text = TR.Value("fashion_buy_month_use");
							this.descText.text.Replace("\\n", "\n");
						}
					}
				}
			}
		}

		// Token: 0x0600E8D3 RID: 59603 RVA: 0x003D9D1C File Offset: 0x003D811C
		private void Reset()
		{
			this.goSelf = null;
			this.goParent = null;
			this.frame = null;
			this.mBind = null;
			this.limitTimeLogo = null;
			this.limitTimeImg = null;
			this.priceText = null;
			this.descText = null;
			this.mOldPrice = null;
			this.mFashionDiscount = null;
			this.checkImg = null;
			if (this.toggle)
			{
				this.toggle.onValueChanged.RemoveListener(new UnityAction<bool>(this.OnToggleOn));
			}
			this.toggle = null;
			this.currItemData = null;
			this.mIntergralMallInfoRoot = null;
			this.mIntergralInfoText = null;
		}

		// Token: 0x0600E8D4 RID: 59604 RVA: 0x003D9DC0 File Offset: 0x003D81C0
		private void OnToggleOn(bool isOn)
		{
			if (this.isToggleOn == isOn)
			{
				return;
			}
			this.isToggleOn = isOn;
			if (isOn)
			{
				FashionLimitTimeBuyFrame fashionLimitTimeBuyFrame = this.frame as FashionLimitTimeBuyFrame;
				if (fashionLimitTimeBuyFrame != null)
				{
					fashionLimitTimeBuyFrame.SelectMallItemInfo = this.currItemData;
				}
			}
		}

		// Token: 0x0600E8D5 RID: 59605 RVA: 0x003D9E05 File Offset: 0x003D8205
		public Toggle GetCurrToggle()
		{
			return this.toggle;
		}

		// Token: 0x04008D2B RID: 36139
		private const string SevenDaysImgPath = "UI/Image/Packed/p_UI_Shop_01.png:UI_Shop_Tubiao_Qitian";

		// Token: 0x04008D2C RID: 36140
		private const string OneMouthImgPath = "UI/Image/Packed/p_UI_Shop_01.png:UI_Shop_Tubiao_Sanshitian";

		// Token: 0x04008D2D RID: 36141
		private const string ForeverImgPath = "UI/Image/Packed/p_UI_Shop_01.png:UI_Shop_Tubiao_Yongjiu";

		// Token: 0x04008D2E RID: 36142
		private SelectMallItemInfoData currItemData;

		// Token: 0x04008D2F RID: 36143
		protected GameObject goParent;

		// Token: 0x04008D30 RID: 36144
		protected ClientFrame frame;

		// Token: 0x04008D31 RID: 36145
		protected ComCommonBind mBind;

		// Token: 0x04008D32 RID: 36146
		private GameObject limitTimeLogo;

		// Token: 0x04008D33 RID: 36147
		private Image limitTimeImg;

		// Token: 0x04008D34 RID: 36148
		private Text priceText;

		// Token: 0x04008D35 RID: 36149
		private Text descText;

		// Token: 0x04008D36 RID: 36150
		private Text mOldPrice;

		// Token: 0x04008D37 RID: 36151
		private Text mFashionDiscount;

		// Token: 0x04008D38 RID: 36152
		private GameObject checkImg;

		// Token: 0x04008D39 RID: 36153
		private Toggle toggle;

		// Token: 0x04008D3A RID: 36154
		private GameObject mIntergralMallInfoRoot;

		// Token: 0x04008D3B RID: 36155
		private Text mIntergralInfoText;

		// Token: 0x04008D3C RID: 36156
		private bool isToggleOn;
	}
}
