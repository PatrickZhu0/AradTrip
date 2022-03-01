using System;
using DataModel;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013DE RID: 5086
	public sealed class ActivityTreasureLotteryActivityView : ActivityTreasureLotteryActivityViewBase<IActivityTreasureLotteryModel>
	{
		// Token: 0x17001BDF RID: 7135
		// (get) Token: 0x0600C51D RID: 50461 RVA: 0x002F71FC File Offset: 0x002F55FC
		public uint BuyCount
		{
			get
			{
				return this.mBuyCount;
			}
		}

		// Token: 0x17001BE0 RID: 7136
		// (get) Token: 0x0600C51E RID: 50462 RVA: 0x002F7204 File Offset: 0x002F5604
		public uint LeftCount
		{
			get
			{
				return (this.mModel != null) ? this.mModel.LeftNum : 0U;
			}
		}

		// Token: 0x17001BE1 RID: 7137
		// (get) Token: 0x0600C520 RID: 50464 RVA: 0x002F722B File Offset: 0x002F562B
		// (set) Token: 0x0600C51F RID: 50463 RVA: 0x002F7222 File Offset: 0x002F5622
		public UnityAction OnButtonBuyAllCallBack { private get; set; }

		// Token: 0x17001BE2 RID: 7138
		// (set) Token: 0x0600C521 RID: 50465 RVA: 0x002F7233 File Offset: 0x002F5633
		public UnityAction OnButtonBuyCallBack
		{
			set
			{
				if (value == null)
				{
					this.mButtonBuy.SafeRemoveOnClickListener(this.mOnButtonBuyCallBack);
				}
				else
				{
					this.mOnButtonBuyCallBack = value;
					this.mButtonBuy.onClick.AddListener(value);
				}
			}
		}

		// Token: 0x0600C522 RID: 50466 RVA: 0x002F726C File Offset: 0x002F566C
		protected sealed override void OnSelectItem(IActivityTreasureLotteryModel model)
		{
			this.mModel = model;
			this.InitCommon();
			switch (model.State)
			{
			case GambingItemStatus.GIS_PREPARE:
				this.InitPrepare();
				break;
			case GambingItemStatus.GIS_SELLING:
				this.InitOpen();
				break;
			case GambingItemStatus.GIS_SOLD_OUE:
			case GambingItemStatus.GIS_LOTTERY:
				this.InitClose();
				break;
			}
			this.UpdateMoneyBinder();
			this.UpdateCostData();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C523 RID: 50467 RVA: 0x002F72DD File Offset: 0x002F56DD
		public sealed override void UpdateData()
		{
			base.UpdateData();
			this.CheckData();
		}

		// Token: 0x0600C524 RID: 50468 RVA: 0x002F72EB File Offset: 0x002F56EB
		protected sealed override void OnInit()
		{
			base.OnInit();
			this.CheckData();
		}

		// Token: 0x0600C525 RID: 50469 RVA: 0x002F72FC File Offset: 0x002F56FC
		private void CheckData()
		{
			if (this.mDataManager == null || !this.mDataManager.IsHadData())
			{
				this.mRightPanel.CustomActive(false);
				this.mTextLoadingData.CustomActive(true);
			}
			else
			{
				this.mRightPanel.CustomActive(true);
				this.mTextLoadingData.CustomActive(false);
			}
		}

		// Token: 0x0600C526 RID: 50470 RVA: 0x002F735C File Offset: 0x002F575C
		private void InitCommon()
		{
			if (this.mButtonMinus != null && this.mButtonMinus.GetComponent<UIGray>() != null)
			{
				this.mButtonMinus.GetComponent<UIGray>().enabled = false;
			}
			if (this.mButtonAdd != null && this.mButtonAdd.GetComponent<UIGray>() != null)
			{
				this.mButtonAdd.GetComponent<UIGray>().enabled = false;
			}
			if (this.mButtonBuyCd == null)
			{
				this.mButtonBuyCd = this.mButtonBuy.GetComponent<SetButtonCD>();
			}
			if (this.mButtonBuyAllCd == null)
			{
				this.mButtonBuyAllCd = this.mButtonBuyAll.GetComponent<SetButtonCD>();
			}
			if (this.mButtonBuyGray == null)
			{
				this.mButtonBuyGray = this.mButtonBuy.GetComponent<UIGray>();
			}
			if (this.mButtonBuyAllGray == null)
			{
				this.mButtonBuyAllGray = this.mButtonBuyAll.GetComponent<UIGray>();
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mModel.ItemId, string.Empty, string.Empty);
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mComItemRoot.gameObject);
			}
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mModel.ItemId);
			this.mComItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.ShowItemTip));
			if (tableItem != null)
			{
				ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, false, false);
				if (qualityInfo != null)
				{
					this.mTextItemName.SafeSetText(string.Format("<color={0}>{1}*{2}</color>", qualityInfo.ColStr, tableItem.Name, this.mModel.ItemNum));
				}
				else
				{
					this.mTextItemName.SafeSetText(string.Format("{1}*{2}", qualityInfo.ColStr, tableItem.Name, this.mModel.ItemNum));
				}
			}
			if (this.mModel != null)
			{
				this.mTextUnitPrice.SafeSetText(this.mModel.UnitPrice.ToString());
				this.mImageProgressValue.fillAmount = ((this.mModel.TotalNum != 0) ? (this.mModel.LeftNum / (float)this.mModel.TotalNum) : 0f);
			}
			this.mTextTip.SafeSetText(TR.Value("activity_treasure_lottery_activity_tip"));
		}

		// Token: 0x0600C527 RID: 50471 RVA: 0x002F75DA File Offset: 0x002F59DA
		protected override void OnDispose()
		{
			base.OnDispose();
			ComItemManager.Destroy(this.mComItem);
			this.mComItem = null;
		}

		// Token: 0x0600C528 RID: 50472 RVA: 0x002F75F4 File Offset: 0x002F59F4
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C529 RID: 50473 RVA: 0x002F760C File Offset: 0x002F5A0C
		private void InitPrepare()
		{
			this.mTextBought.gameObject.CustomActive(true);
			if (this.mModel != null)
			{
				this.mTextBought.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_not_open"), this.mModel.TotalGroup));
				this.mTextSelling.SafeSetText(TR.Value("activity_treasure_lottery_time_begin") + this.mModel.TimeRemainStr);
				this.mTextLeftNum.SafeSetText(string.Format("{0}/{1}", this.mModel.LeftNum, this.mModel.TotalNum));
				string text = string.Empty;
				if (this.mModel.Compensation != null)
				{
					for (int i = 0; i < this.mModel.Compensation.Length; i++)
					{
						ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.mModel.Compensation[i].id, string.Empty, string.Empty);
						ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, false, false);
						text += string.Format("<color={0}>{1}</color>*{2}", qualityInfo.ColStr, tableItem.Name, this.mModel.Compensation[i].num);
					}
					this.mTextInfo.CustomActive(true);
					if (this.mModel.TotalNum != 1)
					{
						this.mTextInfo.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_compensation"), text));
					}
					else
					{
						this.mTextInfo.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_compensation_mustReward"), text));
					}
				}
				else
				{
					this.mTextInfo.CustomActive(false);
				}
			}
			this.SetBuyOperateInteractable(false);
			this.SetGraySelectableInteractable(this.mButtonBuyAll, this.mToggelBuyAll.isOn);
			if (!this.mToggelBuyAll.isOn)
			{
				this.mButtonBuyAll.interactable = true;
			}
		}

		// Token: 0x0600C52A RID: 50474 RVA: 0x002F77FC File Offset: 0x002F5BFC
		private void InitOpen()
		{
			this.mTextBought.gameObject.CustomActive(true);
			string text = string.Empty;
			this.mTextSelling.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_selling_num"), this.mModel.GroupId, this.mModel.TotalGroup));
			this.mTextBought.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_bought_num"), this.mModel.BoughtNum));
			this.mTextLeftNum.SafeSetText(string.Format("{0}/{1}", this.mModel.LeftNum, this.mModel.TotalNum));
			this.SetBuyOperateInteractable(true);
			this.SetGraySelectableInteractable(this.mButtonBuyAll, this.mToggelBuyAll.isOn);
			if (!this.mToggelBuyAll.isOn)
			{
				this.mButtonBuyAll.interactable = true;
			}
			if (this.mModel.Compensation != null)
			{
				for (int i = 0; i < this.mModel.Compensation.Length; i++)
				{
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.mModel.Compensation[i].id, string.Empty, string.Empty);
					ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, false, false);
					text += string.Format("<color={0}>{1}</color>*{2}", qualityInfo.ColStr, tableItem.Name, this.mModel.Compensation[i].num);
				}
				this.mTextInfo.CustomActive(true);
				if (this.mModel.TotalNum != 1)
				{
					this.mTextInfo.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_compensation"), text));
				}
				else
				{
					this.mTextInfo.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_compensation_mustReward"), text));
				}
			}
			else
			{
				this.mTextInfo.CustomActive(false);
			}
		}

		// Token: 0x0600C52B RID: 50475 RVA: 0x002F79F4 File Offset: 0x002F5DF4
		private void InitClose()
		{
			this.mTextBought.gameObject.CustomActive(false);
			this.mTextInfo.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_sell_out"), this.mModel.TotalGroup));
			this.mTextSelling.SafeSetText(TR.Value("activity_treasure_lottery_end"));
			this.mTextLeftNum.SafeSetText(string.Format("{0}/{1}", this.mModel.LeftNum, this.mModel.TotalNum));
			this.SetBuyOperateInteractable(false);
			this.SetGraySelectableInteractable(this.mButtonBuyAll, false);
			if (!this.mToggelBuyAll.isOn)
			{
				this.mButtonBuyAll.interactable = true;
			}
		}

		// Token: 0x0600C52C RID: 50476 RVA: 0x002F7AB6 File Offset: 0x002F5EB6
		private void SetBuyOperateInteractable(bool enable)
		{
			this.SetGraySelectableInteractable(this.mButtonMinus, enable);
			this.SetGraySelectableInteractable(this.mButtonAdd, enable);
			this.SetGraySelectableInteractable(this.mButtonCountInput, enable);
		}

		// Token: 0x0600C52D RID: 50477 RVA: 0x002F7AE0 File Offset: 0x002F5EE0
		private void SetGraySelectableInteractable(Selectable element, bool enable)
		{
			if (element != null)
			{
				element.interactable = enable;
				UIGray component = element.GetComponent<UIGray>();
				if (component != null)
				{
					component.enabled = !enable;
				}
			}
		}

		// Token: 0x0600C52E RID: 50478 RVA: 0x002F7B20 File Offset: 0x002F5F20
		private void Update()
		{
			if (this.mModel != null && this.mModel.State == GambingItemStatus.GIS_PREPARE)
			{
				this.mTextSelling.SafeSetText(TR.Value("activity_treasure_lottery_time_begin") + this.mModel.TimeRemainStr);
			}
			if (this.mButtonBuyCd != null && this.mButtonBuy != null)
			{
				if (this.mButtonBuyCd.BtIsWork && !this.mButtonBuy.interactable)
				{
					this.mButtonBuy.interactable = true;
					this.mButtonBuyGray.enabled = false;
				}
				else if (!this.mButtonBuyCd.BtIsWork && this.mButtonBuy.interactable)
				{
					this.mButtonBuy.interactable = false;
					this.mButtonBuyGray.enabled = true;
				}
			}
			if (this.mButtonBuyAllCd != null && this.mButtonBuyAll != null && this.mToggelBuyAll.isOn)
			{
				if (this.mButtonBuyAllCd.BtIsWork && !this.mButtonBuyAll.interactable)
				{
					this.mButtonBuyAll.interactable = true;
					this.mButtonBuyAllGray.enabled = false;
				}
				else if (!this.mButtonBuyAllCd.BtIsWork && this.mButtonBuyAll.interactable)
				{
					this.mButtonBuyAll.interactable = false;
					this.mButtonBuyAllGray.enabled = true;
				}
			}
		}

		// Token: 0x0600C52F RID: 50479 RVA: 0x002F7CAC File Offset: 0x002F60AC
		private void OnChangeNum(UIEvent uiEvent)
		{
			ChangeNumType changeNumType = (ChangeNumType)uiEvent.Param1;
			if (changeNumType == ChangeNumType.BackSpace)
			{
				if (this.mBuyCount < 10U)
				{
					this.mBuyCount = 1U;
					this.mIsFirstNum = true;
				}
				else
				{
					uint num = this.mBuyCount / 10U;
					this.mBuyCount = num;
				}
			}
			else if (changeNumType == ChangeNumType.Add)
			{
				int num2 = (int)uiEvent.Param2;
				if (num2 < 0 || num2 > 9)
				{
					Logger.LogErrorFormat("传入数字不合法，请控制在0-9之间", new object[0]);
					return;
				}
				int num3;
				if (this.mIsFirstNum)
				{
					if (num2 != 0)
					{
						num3 = num2;
						this.mIsFirstNum = false;
					}
					else
					{
						num3 = 1;
					}
				}
				else
				{
					num3 = (int)(this.mBuyCount * 10U + (uint)num2);
				}
				if (num3 < 1)
				{
					Logger.LogErrorFormat("temp_buyCount is error", new object[0]);
				}
				if ((ulong)this.mModel.LeftNum < (ulong)((long)num3))
				{
					num3 = (int)this.mModel.LeftNum;
				}
				this.mBuyCount = (uint)num3;
			}
			this.UpdateCostData();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C530 RID: 50480 RVA: 0x002F7DB4 File Offset: 0x002F61B4
		private void UpdateMoneyBinder()
		{
			MoneyBinder.Create(this.mTextOwnedNum.gameObject, null, this.mTextOwnedNum, null, this.mModel.MoneyId, MoneyBinder.MoneyShowType.MST_NORMAL);
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mModel.MoneyId, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ETCImageLoader.LoadSprite(ref this.mImageTotalCurrency, tableItem.Icon, true);
				ETCImageLoader.LoadSprite(ref this.mImageUnitCurrency, tableItem.Icon, true);
				ETCImageLoader.LoadSprite(ref this.mImageOwnCurrency, tableItem.Icon, true);
			}
		}

		// Token: 0x0600C531 RID: 50481 RVA: 0x002F7E48 File Offset: 0x002F6248
		private void UpdateCostData()
		{
			this.mTextBuyCount.SafeSetText(this.mBuyCount.ToString());
			if (this.mModel != null)
			{
				this.mTextTotalPrice.SafeSetText(((long)((ulong)this.mBuyCount * (ulong)((long)this.mModel.UnitPrice))).ToString());
			}
		}

		// Token: 0x0600C532 RID: 50482 RVA: 0x002F7EAC File Offset: 0x002F62AC
		private void UpdateNumButtonState()
		{
			if (this.mModel.State != GambingItemStatus.GIS_SELLING || this.mModel.LeftNum < 1U)
			{
				this.SetBuyOperateInteractable(false);
			}
			else
			{
				this.SetBuyOperateInteractable(true);
				if (this.mBuyCount >= this.mModel.LeftNum)
				{
					this.SetGraySelectableInteractable(this.mButtonAdd, false);
				}
				if (this.mBuyCount <= 1U)
				{
					this.SetGraySelectableInteractable(this.mButtonMinus, false);
				}
			}
		}

		// Token: 0x0600C533 RID: 50483 RVA: 0x002F7F2C File Offset: 0x002F632C
		protected sealed override void BindEvents()
		{
			base.BindEvents();
			this.mButtonBuyCurrency.SafeAddOnClickListener(new UnityAction(this.OnButtonBuyCurrencyButtonClick));
			this.mButtonAdd.SafeAddOnClickListener(new UnityAction(this.OnButtonAddButtonClick));
			this.mButtonMinus.SafeAddOnClickListener(new UnityAction(this.OnButtonMinusButtonClick));
			this.mButtonCountInput.SafeAddOnClickListener(new UnityAction(this.OnButtonCountInputButtonClick));
			this.mButtonBuyAll.SafeAddOnClickListener(new UnityAction(this.OnButtonBuyAllClick));
			this.mToggelBuyAll.SafeAddOnValueChangedListener(new UnityAction<bool>(this.OnToggleBuyAll));
			this.mButtonBuy.SafeAddOnClickListener(new UnityAction(this.OnButtonBuyClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600C534 RID: 50484 RVA: 0x002F7FFC File Offset: 0x002F63FC
		protected sealed override void UnBindEvents()
		{
			base.UnBindEvents();
			this.mButtonBuyCurrency.SafeRemoveOnClickListener(new UnityAction(this.OnButtonBuyCurrencyButtonClick));
			this.mButtonAdd.SafeRemoveOnClickListener(new UnityAction(this.OnButtonAddButtonClick));
			this.mButtonMinus.SafeRemoveOnClickListener(new UnityAction(this.OnButtonMinusButtonClick));
			this.mButtonCountInput.SafeRemoveOnClickListener(new UnityAction(this.OnButtonCountInputButtonClick));
			this.mButtonBuyAll.SafeRemoveOnClickListener(new UnityAction(this.OnButtonBuyAllClick));
			this.mToggelBuyAll.SafeRemoveOnValueChangedListener(new UnityAction<bool>(this.OnToggleBuyAll));
			this.mButtonBuy.SafeRemoveOnClickListener(new UnityAction(this.OnButtonBuyClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
		}

		// Token: 0x0600C535 RID: 50485 RVA: 0x002F80CC File Offset: 0x002F64CC
		protected sealed override void OnItemSelected(ComUIListElementScript item)
		{
			if (this.mSelectedItem != null && this.mSelectId != item.m_index)
			{
				this.mBuyCount = 1U;
				this.mTextBuyCount.SafeSetText("1");
				this.UpdateCostData();
			}
			base.OnItemSelected(item);
		}

		// Token: 0x0600C536 RID: 50486 RVA: 0x002F811C File Offset: 0x002F651C
		private void OnToggleBuyAll(bool value)
		{
			if (value)
			{
				SystemNotifyManager.SystemNotify(9862, string.Empty);
				this.SetGraySelectableInteractable(this.mButtonBuyAll, true);
			}
			else
			{
				this.SetGraySelectableInteractable(this.mButtonBuyAll, false);
				this.mButtonBuyAll.interactable = true;
			}
		}

		// Token: 0x0600C537 RID: 50487 RVA: 0x002F8169 File Offset: 0x002F6569
		private void OnButtonBuyClick()
		{
			if (this.mButtonBuyCd != null)
			{
				this.mButtonBuyCd.BtIsWork = false;
			}
		}

		// Token: 0x0600C538 RID: 50488 RVA: 0x002F8188 File Offset: 0x002F6588
		private void OnButtonBuyAllClick()
		{
			if (this.mToggelBuyAll.isOn)
			{
				if (this.mButtonBuyAllCd != null)
				{
					this.mButtonBuyAllCd.BtIsWork = false;
				}
				if (this.OnButtonBuyAllCallBack != null)
				{
					this.OnButtonBuyAllCallBack.Invoke();
				}
			}
			else
			{
				SystemNotifyManager.SystemNotify(9861, string.Empty);
			}
		}

		// Token: 0x0600C539 RID: 50489 RVA: 0x002F81EC File Offset: 0x002F65EC
		private void OnButtonCountInputButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, this.mKeyBoardOffetX, string.Empty);
			this.mIsFirstNum = true;
		}

		// Token: 0x0600C53A RID: 50490 RVA: 0x002F8214 File Offset: 0x002F6614
		private void OnButtonBuyCurrencyButtonClick()
		{
			if (this.mModel == null)
			{
				return;
			}
			int moneyId = this.mModel.MoneyId;
			uint num = (uint)((long)this.mModel.UnitPrice * (long)((ulong)this.mBuyCount));
			uint ownedItemCount = (uint)DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyId, false);
			bool bNotEnough = num > ownedItemCount;
			ItemComeLink.OnLink(moneyId, (int)(num - ownedItemCount), bNotEnough, null, false, false, false, null, string.Empty);
		}

		// Token: 0x0600C53B RID: 50491 RVA: 0x002F8275 File Offset: 0x002F6675
		private void OnButtonMaxButtonClick()
		{
			if (this.mModel == null)
			{
				return;
			}
			this.mBuyCount = this.mModel.LeftNum;
			this.UpdateCostData();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C53C RID: 50492 RVA: 0x002F82A0 File Offset: 0x002F66A0
		private void OnButtonAddButtonClick()
		{
			if (this.mModel == null)
			{
				return;
			}
			if (this.mBuyCount >= this.mModel.LeftNum)
			{
				return;
			}
			this.mBuyCount += 1U;
			this.UpdateCostData();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600C53D RID: 50493 RVA: 0x002F82DF File Offset: 0x002F66DF
		private void OnButtonMinusButtonClick()
		{
			if (this.mBuyCount <= 1U)
			{
				return;
			}
			this.mBuyCount -= 1U;
			this.UpdateCostData();
			this.UpdateNumButtonState();
		}

		// Token: 0x04007077 RID: 28791
		private UnityAction mOnButtonBuyCallBack;

		// Token: 0x04007078 RID: 28792
		[SerializeField]
		private Button mButtonBuy;

		// Token: 0x04007079 RID: 28793
		[SerializeField]
		private Image mImageProgressValue;

		// Token: 0x0400707A RID: 28794
		[SerializeField]
		private Button mButtonBuyCurrency;

		// Token: 0x0400707B RID: 28795
		[SerializeField]
		private Text mTextOwnedNum;

		// Token: 0x0400707C RID: 28796
		[SerializeField]
		private Image mImageTotalCurrency;

		// Token: 0x0400707D RID: 28797
		[SerializeField]
		private Image mImageOwnCurrency;

		// Token: 0x0400707E RID: 28798
		[SerializeField]
		private Text mTextTotalPrice;

		// Token: 0x0400707F RID: 28799
		[SerializeField]
		private Image mImageUnitCurrency;

		// Token: 0x04007080 RID: 28800
		[SerializeField]
		private Text mTextUnitPrice;

		// Token: 0x04007081 RID: 28801
		[SerializeField]
		private Transform mComItemRoot;

		// Token: 0x04007082 RID: 28802
		[SerializeField]
		private Button mButtonAdd;

		// Token: 0x04007083 RID: 28803
		[SerializeField]
		private Button mButtonMinus;

		// Token: 0x04007084 RID: 28804
		[SerializeField]
		private Text mTextItemName;

		// Token: 0x04007085 RID: 28805
		[SerializeField]
		private Text mTextInfo;

		// Token: 0x04007086 RID: 28806
		[SerializeField]
		private Text mTextSelling;

		// Token: 0x04007087 RID: 28807
		[SerializeField]
		private Text mTextBought;

		// Token: 0x04007088 RID: 28808
		[SerializeField]
		private Text mTextBuyCount;

		// Token: 0x04007089 RID: 28809
		[SerializeField]
		private Text mTextLeftNum;

		// Token: 0x0400708A RID: 28810
		[SerializeField]
		private Button mButtonCountInput;

		// Token: 0x0400708B RID: 28811
		[SerializeField]
		private Button mButtonBuyAll;

		// Token: 0x0400708C RID: 28812
		[SerializeField]
		private Toggle mToggelBuyAll;

		// Token: 0x0400708D RID: 28813
		[SerializeField]
		private float mKeyBoardOffetX = -150f;

		// Token: 0x0400708E RID: 28814
		[SerializeField]
		private Text mTextTip;

		// Token: 0x0400708F RID: 28815
		[SerializeField]
		private Text mTextLoadingData;

		// Token: 0x04007090 RID: 28816
		[SerializeField]
		private GameObject mRightPanel;

		// Token: 0x04007091 RID: 28817
		[Header("是否切换物品后清空默认勾选购买剩余")]
		[SerializeField]
		private bool mIsClearTollgeAll = true;

		// Token: 0x04007092 RID: 28818
		private uint mBuyCount = 1U;

		// Token: 0x04007093 RID: 28819
		private bool mIsFirstNum;

		// Token: 0x04007094 RID: 28820
		private ComItem mComItem;

		// Token: 0x04007095 RID: 28821
		private IActivityTreasureLotteryModel mModel;

		// Token: 0x04007096 RID: 28822
		private SetButtonCD mButtonBuyCd;

		// Token: 0x04007097 RID: 28823
		private SetButtonCD mButtonBuyAllCd;

		// Token: 0x04007098 RID: 28824
		private UIGray mButtonBuyGray;

		// Token: 0x04007099 RID: 28825
		private UIGray mButtonBuyAllGray;
	}
}
