using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200176F RID: 5999
	internal class MallBuyFrame : ClientFrame
	{
		// Token: 0x0600ECD8 RID: 60632 RVA: 0x003F5125 File Offset: 0x003F3525
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/MallBuyFrame";
		}

		// Token: 0x0600ECD9 RID: 60633 RVA: 0x003F512C File Offset: 0x003F352C
		protected override void _OnOpenFrame()
		{
			this.MallItemdata = (MallItemInfo)this.userData;
			this.needDiscountTips = false;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnSendQueryMallItemInfo, new ClientEventSystem.UIEventHandler(this.ReqQueryMallItemInfo));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnQueryMallItenInfoSuccess, new ClientEventSystem.UIEventHandler(this.OnQueryMallItenInfoSuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
			this.InitInterface();
		}

		// Token: 0x0600ECDA RID: 60634 RVA: 0x003F51E0 File Offset: 0x003F35E0
		protected override void _OnCloseFrame()
		{
			this.needDiscountTips = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChangeNum, new ClientEventSystem.UIEventHandler(this.OnChangeNum));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnSendQueryMallItemInfo, new ClientEventSystem.UIEventHandler(this.ReqQueryMallItemInfo));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnQueryMallItenInfoSuccess, new ClientEventSystem.UIEventHandler(this.OnQueryMallItenInfoSuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.AccountSpecialItemUpdate, new ClientEventSystem.UIEventHandler(this._OnCountValueChanged));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivityLimitTimeDataUpdate, new ClientEventSystem.UIEventHandler(this._OnLimitTimeDataUpdate));
			this.ClearData();
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<VirtualKeyboardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<VirtualKeyboardFrame>(null, false);
			}
		}

		// Token: 0x0600ECDB RID: 60635 RVA: 0x003F529D File Offset: 0x003F369D
		public override bool IsNeedUpdate()
		{
			return this._isUpdate;
		}

		// Token: 0x0600ECDC RID: 60636 RVA: 0x003F52A8 File Offset: 0x003F36A8
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this.MallItemdata == null)
			{
				return;
			}
			int num = (int)(this.MallItemdata.multipleEndTime - DataManager<TimeManager>.GetInstance().GetServerTime());
			if (num <= 0)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnSendQueryMallItemInfo, this.MallItemdata.itemid, null, null, null);
				this._isUpdate = false;
			}
		}

		// Token: 0x0600ECDD RID: 60637 RVA: 0x003F5308 File Offset: 0x003F3708
		private void ClearData()
		{
			this.MallItemdata = null;
			this.moneyType = ItemTable.eSubType.BindPOINT;
			this.CurNum = 1;
			this.MaxNum = 1;
			this.iPrice = 0;
			this.fBaseSliderValue = 0f;
			if (this.kSlider != null)
			{
				this.kSlider.onValueChanged.RemoveAllListeners();
				this.kSlider = null;
			}
			this._isUpdate = false;
		}

		// Token: 0x0600ECDE RID: 60638 RVA: 0x003F5373 File Offset: 0x003F3773
		[UIEventHandle("title/closeicon")]
		private void OnClose()
		{
			this.ClearData();
			this.frameMgr.CloseFrame<MallBuyFrame>(this, false);
		}

		// Token: 0x0600ECDF RID: 60639 RVA: 0x003F5388 File Offset: 0x003F3788
		[UIEventHandle("Middle/minus")]
		private void OnLeft()
		{
			if (this.CurNum <= 1)
			{
				return;
			}
			this.CurNum--;
			this.isTrueNum = true;
			this.ShowDataText();
			this.UpdateNumButtonState();
			if (this.kSlider.value <= (float)this.CurNum * this.fBaseSliderValue || this.kSlider.value > (float)(this.CurNum + 1) * this.fBaseSliderValue)
			{
				this.kSlider.value = (float)this.CurNum * this.fBaseSliderValue;
			}
		}

		// Token: 0x0600ECE0 RID: 60640 RVA: 0x003F541C File Offset: 0x003F381C
		[UIEventHandle("Middle/add")]
		private void OnRight()
		{
			if (this.limit && this.limitnum >= 1 && this.CurNum >= this.limitnum)
			{
				return;
			}
			if (this.CurNum >= this.MaxNum)
			{
				return;
			}
			this.CurNum++;
			this.isTrueNum = true;
			this.ShowDataText();
			this.UpdateNumButtonState();
			if (this.kSlider.value <= (float)this.CurNum * this.fBaseSliderValue || this.kSlider.value > (float)(this.CurNum + 1) * this.fBaseSliderValue)
			{
				this.kSlider.value = (float)this.CurNum * this.fBaseSliderValue;
			}
		}

		// Token: 0x0600ECE1 RID: 60641 RVA: 0x003F54DC File Offset: 0x003F38DC
		[UIEventHandle("Middle/max")]
		private void OnMax()
		{
			if (this.limit)
			{
				if (this.MaxNum < this.limitnum)
				{
					this.CurNum = this.MaxNum;
				}
				else
				{
					this.CurNum = this.limitnum;
				}
			}
			else
			{
				this.CurNum = this.MaxNum;
			}
			this.isTrueNum = true;
			this.ShowDataText();
			this.UpdateNumButtonState();
			this.kSlider.value = 1f;
		}

		// Token: 0x0600ECE2 RID: 60642 RVA: 0x003F5558 File Offset: 0x003F3958
		private void OnChangeNum(UIEvent uiEvent)
		{
			ChangeNumType changeNumType = (ChangeNumType)uiEvent.Param1;
			if (changeNumType == ChangeNumType.BackSpace)
			{
				if (!this.isTrueNum)
				{
					return;
				}
				if (this.CurNum < 10)
				{
					this.CurNum = 1;
					this.isTrueNum = false;
				}
				else
				{
					int curNum = this.CurNum / 10;
					this.CurNum = curNum;
				}
			}
			else if (changeNumType == ChangeNumType.Add)
			{
				int num = (int)uiEvent.Param2;
				if (num < 0 || num > 9)
				{
					Logger.LogErrorFormat("传入数字不合法，请控制在0-9之间", new object[0]);
					return;
				}
				int num2;
				if (!this.isTrueNum)
				{
					if (num != 0)
					{
						num2 = num;
						this.isTrueNum = true;
					}
					else
					{
						num2 = 1;
						this.isTrueNum = false;
					}
				}
				else
				{
					num2 = this.CurNum * 10 + num;
				}
				if (num2 < 1)
				{
					Logger.LogErrorFormat("tempCurNum is error", new object[0]);
				}
				if (this.MaxNum < num2)
				{
					num2 = this.MaxNum;
					SystemNotifyManager.SystemNotify(this.tipsID, string.Empty);
				}
				this.CurNum = num2;
			}
			this.ShowDataText();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600ECE3 RID: 60643 RVA: 0x003F5678 File Offset: 0x003F3A78
		private void _OnSliderValueChanged(float fValue)
		{
			int num = (int)(fValue / this.fBaseSliderValue + 0.5f);
			if (num <= 1)
			{
				this.CurNum = 1;
			}
			else if (num >= this.MaxNum)
			{
				this.CurNum = this.MaxNum;
			}
			else
			{
				this.CurNum = num;
			}
			this.ShowDataText();
			this.UpdateNumButtonState();
		}

		// Token: 0x0600ECE4 RID: 60644 RVA: 0x003F56D8 File Offset: 0x003F3AD8
		[UIEventHandle("Bottom/ok")]
		private void OnBuy()
		{
			if (this.MallItemdata != null)
			{
				if (!DataManager<ActivityDataManager>.GetInstance().IsShowFirstDiscountDes(this.MallItemdata.id))
				{
					this.Buy();
				}
				else
				{
					CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
					{
						ContentLabel = string.Format(TR.Value("DiscountActivity_BuyContent"), new object[0]),
						IsShowNotify = false,
						LeftButtonText = TR.Value("DiscountActivity_DiscountCancel"),
						RightButtonText = TR.Value("DiscountActivity_DiscountOK"),
						OnRightButtonClickCallBack = delegate()
						{
							this.Buy();
						}
					};
					SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
				}
			}
		}

		// Token: 0x0600ECE5 RID: 60645 RVA: 0x003F5778 File Offset: 0x003F3B78
		private void Buy()
		{
			if (this.CurNum <= 0)
			{
				if (this.MaxNum >= 1)
				{
					SystemNotifyManager.SysNotifyTextAnimation("请选择购买数量", CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					SystemNotifyManager.SystemNotify(1086, string.Empty);
				}
				return;
			}
			ItemTable itemTable = null;
			if (this.MallItemdata != null)
			{
				itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.itemID, string.Empty, string.Empty);
				if (itemTable == null)
				{
					Logger.LogErrorFormat("can not find ItemTableData when id is {0}", new object[]
					{
						this.itemID
					});
				}
				if (itemTable != null && itemTable.GetLimitNum != 0 && itemTable.GetLimitNum < DataManager<ItemDataManager>.GetInstance().GetItemCount((int)this.itemID) + this.CurNum)
				{
					string text = itemTable.Name;
					SystemNotifyManager.SystemNotify(9102, null, null, 0f, new object[]
					{
						text
					});
					return;
				}
			}
			if ((this.moneyType == ItemTable.eSubType.BindPOINT || this.moneyType == ItemTable.eSubType.POINT) && DataManager<SecurityLockDataManager>.GetInstance().CheckSecurityLock(null, null))
			{
				return;
			}
			if (this.mSetButtonCD == null || !this.mSetButtonCD.BtIsWork)
			{
				return;
			}
			this.mSetButtonCD.BtIsWork = false;
			CostItemManager.CostInfo costInfo = new CostItemManager.CostInfo();
			costInfo.nMoneyID = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(this.moneyType);
			costInfo.nCount = this.mTempPrice;
			costInfo.IsCreditPointDeduction = MallNewUtility.IsMallItemCanCreditPointDeduction(this.MallItemdata);
			if (this.MallItemdata != null)
			{
				if (this.MallItemdata.type == 20 && itemTable != null && !ClientApplication.playerinfo.CheckRoleIsBuyGift(itemTable.NeedLevel, itemTable.MaxLevel))
				{
					SystemNotifyManager.SysNotifyMsgBoxCancelOk("账号下没有符合礼包使用条件的角色，是否继续购买?", null, delegate()
					{
						this.OnBuyItemClick(costInfo);
					}, 0f, false, null);
					return;
				}
			}
			this.OnBuyItemClick(costInfo);
		}

		// Token: 0x0600ECE6 RID: 60646 RVA: 0x003F5985 File Offset: 0x003F3D85
		private void OnBuyItemClick(CostItemManager.CostInfo costInfo)
		{
			DataManager<CostItemManager>.GetInstance().TryCostMoneyDefault(costInfo, delegate
			{
				if (this.MallItemdata.multiple > 0)
				{
					string text = string.Empty;
					if ((int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket == MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsEqual)
					{
						text = TR.Value("mall_buy_intergral_mall_score_equal_upper_value_desc");
						string content = text;
						if (MallBuyFrame.<>f__mg$cache0 == null)
						{
							MallBuyFrame.<>f__mg$cache0 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsEqual);
						}
						MallNewUtility.CommonIntergralMallPopupWindow(content, MallBuyFrame.<>f__mg$cache0, delegate
						{
							this.OnSendWorldMallBuy(this.MallItemdata, this.CurNum);
						});
					}
					else
					{
						int num = MallNewUtility.GetTicketConvertIntergalNumnber(this.mTempPrice) * (int)this.MallItemdata.multiple;
						int num2 = (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket + num;
						if (num2 > MallNewUtility.GetIntergralMallTicketUpper() && (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket != MallNewUtility.GetIntergralMallTicketUpper() && !DataManager<MallNewDataManager>.GetInstance().bItemMallIntergralMallScoreIsExceed)
						{
							text = TR.Value("mall_buy_intergral_mall_score_exceed_upper_value_desc", (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket, MallNewUtility.GetIntergralMallTicketUpper(), MallNewUtility.GetIntergralMallTicketUpper() - (int)DataManager<PlayerBaseData>.GetInstance().IntergralMallTicket);
							string content2 = text;
							if (MallBuyFrame.<>f__mg$cache1 == null)
							{
								MallBuyFrame.<>f__mg$cache1 = new OnCommonMsgBoxToggleClick(MallNewUtility.ItemMallIntergralMallScoreIsExceed);
							}
							MallNewUtility.CommonIntergralMallPopupWindow(content2, MallBuyFrame.<>f__mg$cache1, delegate
							{
								this.OnSendWorldMallBuy(this.MallItemdata, this.CurNum);
							});
						}
						else
						{
							this.OnSendWorldMallBuy(this.MallItemdata, this.CurNum);
						}
					}
				}
				else
				{
					this.OnSendWorldMallBuy(this.MallItemdata, this.CurNum);
				}
			}, "common_money_cost", null);
		}

		// Token: 0x0600ECE7 RID: 60647 RVA: 0x003F59A4 File Offset: 0x003F3DA4
		private void OnSendWorldMallBuy(MallItemInfo MallItemdata, int CurNum)
		{
			if (this.needDiscountTips)
			{
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)MallItemdata.discountCouponId, true);
				int num;
				if (CurNum > ownedItemCount)
				{
					num = ownedItemCount;
				}
				else
				{
					num = CurNum;
				}
				SystemNotifyManager.SysNotifyMsgBoxCancelOk(string.Format(TR.Value("mallbuyFrame_discount_tips"), num), null, delegate()
				{
					WorldMallBuy worldMallBuy2 = new WorldMallBuy();
					worldMallBuy2.itemId = MallItemdata.id;
					worldMallBuy2.num = (ushort)CurNum;
					NetManager netManager2 = NetManager.Instance();
					netManager2.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy2);
					this.OnClose();
				}, 0f, false, null);
			}
			else
			{
				WorldMallBuy worldMallBuy = new WorldMallBuy();
				worldMallBuy.itemId = MallItemdata.id;
				worldMallBuy.num = (ushort)CurNum;
				NetManager netManager = NetManager.Instance();
				netManager.SendCommand<WorldMallBuy>(ServerType.GATE_SERVER, worldMallBuy);
				this.OnClose();
			}
		}

		// Token: 0x0600ECE8 RID: 60648 RVA: 0x003F5A78 File Offset: 0x003F3E78
		private void InitInterface()
		{
			if (this.MallItemdata == null)
			{
				return;
			}
			this.limit = (this.MallItemdata.limit > 0);
			if (this.mFirstDiscountTxt != null)
			{
				this.mOriginalColor = this.mFirstDiscountTxt.color;
			}
			this._InitComUIList();
			if (this.MallItemdata.itemid == 0U)
			{
				this.thisGiftList.Clear();
				for (int i = 0; i < this.MallItemdata.giftItems.Length; i++)
				{
					this.thisGiftList.Add(this.MallItemdata.giftItems[i]);
				}
				if (this.MallItemdata.giftItems.Length > 0)
				{
					this.itemID = (ulong)this.MallItemdata.giftItems[0].id;
				}
				this.mRewardScrollView.SetElementAmount(this.thisGiftList.Count);
				this.mGiftName.text = this.MallItemdata.giftName;
				this.mRewardScrollView.CustomActive(true);
				this.mGiftName.CustomActive(true);
				this.name.CustomActive(false);
				this.pos.CustomActive(false);
			}
			else
			{
				this.mRewardScrollView.CustomActive(false);
				this.mGiftName.CustomActive(false);
				this.name.CustomActive(true);
				this.pos.CustomActive(true);
				this.itemID = (ulong)this.MallItemdata.itemid;
			}
			bool flag = false;
			this.limitnum = Utility.GetLeftLimitNum(this.MallItemdata, ref flag);
			this.iPrice = Utility.GetMallRealPrice(this.MallItemdata);
			ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.itemID, 100, 0);
			if (itemData != null && itemData.SubType != 17 && itemData.SubType != 27)
			{
				itemData.Count = (int)this.MallItemdata.itemnum;
			}
			this.moneyType = (ItemTable.eSubType)this.MallItemdata.moneytype;
			if (this.bindticketicon != null)
			{
				this.bindticketicon.gameObject.CustomActive(false);
			}
			ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType(this.MallItemdata.moneytype);
			if (costItemTableByCostType != null)
			{
				if (this.ticketicon != null)
				{
					ETCImageLoader.LoadSprite(ref this.ticketicon, costItemTableByCostType.Icon, true);
					ETCImageLoader.LoadSprite(ref this.mTicketiconDiscount1, costItemTableByCostType.Icon, true);
					ETCImageLoader.LoadSprite(ref this.mTicketiconDiscount2, costItemTableByCostType.Icon, true);
				}
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(costItemTableByCostType.ID, true);
				this.MaxNum = this.GetMaxNum();
			}
			this.tipsID = 9207;
			if (this.MallItemdata.type == 19)
			{
				this.tipsID = 10053;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.itemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.MaxNum == 0)
			{
				this.MaxNum = 1;
			}
			if (this.limit && this.MaxNum > this.limitnum)
			{
				this.MaxNum = this.limitnum;
				if (this.MaxNum == 0)
				{
					this.MaxNum = 1;
				}
				this.tipsID = 9210;
			}
			if (this.MallItemdata != null && this.MallItemdata.accountLimitBuyNum > 0U)
			{
				if ((long)this.MaxNum > (long)((ulong)this.MallItemdata.accountRestBuyNum))
				{
					this.MaxNum = (int)this.MallItemdata.accountRestBuyNum;
				}
				if (this.MaxNum == 0)
				{
					this.MaxNum = 1;
				}
			}
			if (this.MaxNum > tableItem.MaxNum && tableItem.MaxNum != 0)
			{
				this.MaxNum = tableItem.MaxNum;
				if (this.MaxNum == 0)
				{
					this.MaxNum = 1;
				}
				this.tipsID = 9208;
			}
			if (tableItem.GetLimitNum != 0 && this.MaxNum > tableItem.GetLimitNum - DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(tableItem.ID))
			{
				this.MaxNum = tableItem.GetLimitNum - DataManager<ItemDataManager>.GetInstance().GetItemCountInPackage(tableItem.ID);
				if (this.MaxNum == 0)
				{
					this.MaxNum = 1;
				}
				this.tipsID = 9209;
			}
			if (this.MaxNum < 1)
			{
				this.totalprice.color = new Color(1f, 0f, 0f);
			}
			this.CurNum = 1;
			this.btLeft.gameObject.AddComponent<UIGray>();
			this.btLeft.GetComponent<UIGray>().enabled = false;
			this.btRight.gameObject.AddComponent<UIGray>();
			this.btRight.GetComponent<UIGray>().enabled = false;
			this.btMax.gameObject.AddComponent<UIGray>();
			this.btMax.GetComponent<UIGray>().enabled = false;
			ComItem comItem = base.CreateComItem(this.pos);
			comItem.Setup(itemData, null);
			if (itemData.SubType == 17 || itemData.SubType == 27)
			{
				this.name.text = Utility.GetShowPrice((ulong)this.MallItemdata.itemnum, true) + DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, (PetTable.eQuality)tableItem.Color);
			}
			else
			{
				this.name.text = DataManager<PetDataManager>.GetInstance().GetColorName(tableItem.Name, (PetTable.eQuality)tableItem.Color);
			}
			if (this.MallItemdata.itemid == 0U)
			{
				this.des.text = this.MallItemdata.giftDesc;
			}
			else
			{
				this.des.text = tableItem.Description;
			}
			this.fBaseSliderValue = 1f / (float)this.MaxNum;
			this.kSlider.onValueChanged.AddListener(new UnityAction<float>(this._OnSliderValueChanged));
			this.kSlider.value = this.fBaseSliderValue * (float)this.CurNum;
			if (this.MallItemdata != null && this.MallItemdata.multipleEndTime > 0U)
			{
				this._isUpdate = true;
			}
			this.InitIntergralInfoRoot();
			this.ShowDataText();
			this.UpdateNumButtonState();
			if (this.MallItemdata.itemid != 0U)
			{
				this.InitBuyNumberInfo(itemData);
			}
		}

		// Token: 0x0600ECE9 RID: 60649 RVA: 0x003F60B7 File Offset: 0x003F44B7
		private int GetDiscountPrice(int price, int discount)
		{
			return (int)Math.Floor(Convert.ToDecimal((float)(price * discount) * 1f / 100f));
		}

		// Token: 0x0600ECEA RID: 60650 RVA: 0x003F60D8 File Offset: 0x003F44D8
		private int GetMayDayDiscountPrice(float price, float discount)
		{
			return (int)Math.Floor(Convert.ToDecimal(price * discount * 1f / 100f));
		}

		// Token: 0x0600ECEB RID: 60651 RVA: 0x003F60F8 File Offset: 0x003F44F8
		private int GetMaxNum()
		{
			ItemTable costItemTableByCostType = DataManager<MallNewDataManager>.GetInstance().GetCostItemTableByCostType(this.MallItemdata.moneytype);
			int num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(costItemTableByCostType.ID, true);
			if ((costItemTableByCostType.ID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.BindPOINT) || costItemTableByCostType.ID == DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.POINT)) && MallNewUtility.IsMallItemCanCreditPointDeduction(this.MallItemdata))
			{
				int moneyIDByType = DataManager<ItemDataManager>.GetInstance().GetMoneyIDByType(ItemTable.eSubType.ST_CREDIT_POINT);
				int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(moneyIDByType, false);
				num += ownedItemCount;
			}
			if (this.MallItemdata.tagType == 2 && DataManager<ActivityDataManager>.GetInstance().CheckGroupPurchaseActivityIsOpen())
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MallItemdata.deductionCouponId, string.Empty, string.Empty);
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MallItemdata.discountCouponId, string.Empty, string.Empty);
				int num2 = 0;
				if (tableItem != null)
				{
					num2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem.ID, true);
				}
				int num3 = 0;
				if (tableItem2 != null)
				{
					num3 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem2.ID, true);
				}
				int num4 = 0;
				int num5 = 0;
				for (;;)
				{
					int num6 = this.GetMayDayDiscountPrice((float)this.iPrice, ActivityDataManager.LimitTimeGroupBuyDiscount);
					if (tableItem2 != null && num4 < num3)
					{
						num6 = this.GetMayDayDiscountPrice((float)num6, (float)tableItem2.DiscountCouponProp);
					}
					if (tableItem != null && num4 < num2)
					{
						num6 -= tableItem.DiscountCouponProp;
					}
					num5 += num6;
					if (num5 > num)
					{
						break;
					}
					num4++;
				}
				return num4;
			}
			if (DataManager<ActivityDataManager>.GetInstance().IsShowFirstDiscountDes(this.MallItemdata.id))
			{
				OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
				if (activeDataFromType != null)
				{
					int discountPrice = this.GetDiscountPrice(this.iPrice, (int)activeDataFromType.parm);
					if (num >= discountPrice)
					{
						this.MaxNum = 1 + (num - discountPrice) / this.iPrice;
					}
					else
					{
						this.MaxNum = 0;
					}
				}
				return this.MaxNum;
			}
			if (costItemTableByCostType != null)
			{
				ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MallItemdata.discountCouponId, string.Empty, string.Empty);
				if (tableItem3 != null && tableItem3.DiscountCouponProp != 0)
				{
					int ownedItemCount2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)this.MallItemdata.discountCouponId, true);
					int discountPrice2 = this.GetDiscountPrice(this.iPrice, tableItem3.DiscountCouponProp);
					int num7;
					if (discountPrice2 != 0)
					{
						num7 = num / discountPrice2;
					}
					else
					{
						Logger.LogErrorFormat("tempDisPrice = 0为分母 其中iPrice = {0},itemID = {1}", new object[]
						{
							this.iPrice,
							tableItem3.ID
						});
						num7 = 1;
					}
					if (num7 <= ownedItemCount2)
					{
						this.MaxNum = num7;
					}
					else if (this.iPrice != 0)
					{
						this.MaxNum = ownedItemCount2 + (num - discountPrice2 * ownedItemCount2) / this.iPrice;
					}
					else
					{
						Logger.LogErrorFormat("price = 0 其中itemID = {0}", new object[]
						{
							tableItem3.ID
						});
						this.MaxNum = 1;
					}
				}
				else if (this.iPrice > 0)
				{
					this.MaxNum = num / this.iPrice;
				}
				return this.MaxNum;
			}
			return 0;
		}

		// Token: 0x0600ECEC RID: 60652 RVA: 0x003F6450 File Offset: 0x003F4850
		private void InitBuyNumberInfo(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			this.mBuyNumberRoot.CustomActive(false);
			if (itemData.SubType == 17 || itemData.SubType == 27)
			{
				if (this.mBuyNumberRoot != null)
				{
					this.mBuyNumberRoot.CustomActive(true);
				}
				if (this.mBuyNumberText != null)
				{
					this.mBuyNumberText.text = TR.Value("shop_new_buy_text");
				}
				if (itemData.SubType == 17)
				{
					if (this.mBindGoldIcon != null)
					{
						this.mBindGoldIcon.gameObject.CustomActive(false);
					}
					if (this.mGoldIcon != null)
					{
						this.mGoldIcon.gameObject.CustomActive(true);
					}
				}
				else
				{
					if (this.mBindGoldIcon != null)
					{
						this.mBindGoldIcon.gameObject.CustomActive(true);
					}
					if (this.mGoldIcon != null)
					{
						this.mGoldIcon.gameObject.CustomActive(false);
					}
				}
				this.UpdateBuyNumberValue();
			}
		}

		// Token: 0x0600ECED RID: 60653 RVA: 0x003F6570 File Offset: 0x003F4970
		private void UpdateElementDiscountInformation()
		{
			if (this.MallItemdata.tagType == 2 && DataManager<ActivityDataManager>.GetInstance().CheckGroupPurchaseActivityIsOpen())
			{
				this.mDiscountGO.CustomActive(true);
				this.mMayDayDisCountRoot.CustomActive(true);
				this.mNormalCostItem.CustomActive(false);
				this.mDisCount.text = string.Format("{0}折", ActivityDataManager.LimitTimeGroupBuyDiscount / 10f);
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MallItemdata.deductionCouponId, string.Empty, string.Empty);
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MallItemdata.discountCouponId, string.Empty, string.Empty);
				int num = 0;
				if (tableItem != null)
				{
					num = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem.ID, true);
					ETCImageLoader.LoadSprite(ref this.mUseVoucherTicketIcon, tableItem.Icon, true);
					if (num > 0)
					{
						this.mUseVoucherTicketRoot.CustomActive(true);
						if (num >= this.CurNum)
						{
							this.mUseVoucherTickeCount.color = Color.white;
							this.mUseVoucherTickeCount.text = string.Format("{0}/{1}", this.CurNum, num);
						}
						else
						{
							this.mUseVoucherTickeCount.color = Color.red;
							this.mUseVoucherTickeCount.text = string.Format("{0}/{1}", num, num);
						}
					}
					else
					{
						this.mUseVoucherTicketRoot.CustomActive(false);
					}
				}
				else
				{
					this.mUseVoucherTicketRoot.CustomActive(false);
				}
				int num2 = 0;
				if (tableItem2 != null)
				{
					num2 = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(tableItem2.ID, true);
					ETCImageLoader.LoadSprite(ref this.mUseDisCountTicketIcon, tableItem2.Icon, true);
					if (num2 > 0)
					{
						this.mUseDiscountTicketRoot.CustomActive(true);
						if (num2 >= this.CurNum)
						{
							this.mUseDisCountTicketCount.color = Color.white;
							this.mUseDisCountTicketCount.text = string.Format("{0}/{1}", this.CurNum, num2);
						}
						else
						{
							this.mUseDisCountTicketCount.color = Color.red;
							this.mUseDisCountTicketCount.text = string.Format("{0}/{1}", num2, num2);
						}
					}
					else
					{
						this.mUseDiscountTicketRoot.CustomActive(false);
					}
				}
				else
				{
					this.mUseDiscountTicketRoot.CustomActive(false);
				}
				this.mTempPrice = 0;
				for (int i = 0; i < this.CurNum; i++)
				{
					int num3 = this.GetMayDayDiscountPrice((float)this.iPrice, ActivityDataManager.LimitTimeGroupBuyDiscount);
					if (tableItem2 != null && i < num2)
					{
						num3 = this.GetMayDayDiscountPrice((float)num3, (float)tableItem2.DiscountCouponProp);
					}
					if (tableItem != null && i < num)
					{
						num3 -= tableItem.DiscountCouponProp;
					}
					this.mTempPrice += num3;
				}
				this.mCostnumDiscount.text = this.mTempPrice.ToString();
			}
			else
			{
				ItemTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)this.MallItemdata.discountCouponId, string.Empty, string.Empty);
				if (!DataManager<ActivityDataManager>.GetInstance().IsShowFirstDiscountDes(this.MallItemdata.id))
				{
					if (tableItem3 != null && tableItem3.DiscountCouponProp != 0)
					{
						int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount((int)this.MallItemdata.discountCouponId, true);
						if (ownedItemCount > 0)
						{
							this.needDiscountTips = true;
							this.mDiscountText.text = string.Format(TR.Value("mallbuyframe_new_discount_text"), new object[0]);
							ETCImageLoader.LoadSprite(ref this.mDiscountIcon, tableItem3.Icon, true);
							this.mDiscountGO.CustomActive(true);
							this.mNormalCostItem.CustomActive(false);
							this.mDiscountCount.CustomActive(true);
							this.mDiscountText.CustomActive(true);
							this.mDiscountIcon.CustomActive(true);
							this.mFirstDiscountTxt.CustomActive(false);
							int mallRealPrice = Utility.GetMallRealPrice(this.MallItemdata);
							int discountPrice = this.GetDiscountPrice(this.iPrice, tableItem3.DiscountCouponProp);
							if (ownedItemCount >= this.CurNum)
							{
								this.mDiscountCount.color = Color.white;
								this.mDiscountCount.text = string.Format("{0}/{1}", this.CurNum, ownedItemCount);
								this.mTempPrice = discountPrice * this.CurNum;
								this.mCostnumDiscount.text = this.mTempPrice.ToString();
							}
							else
							{
								this.mDiscountCount.color = Color.red;
								this.mDiscountCount.text = string.Format("{0}/{1}", ownedItemCount, ownedItemCount);
								this.mTempPrice = discountPrice * ownedItemCount + this.iPrice * (this.CurNum - ownedItemCount);
								this.mCostnumDiscount.text = this.mTempPrice.ToString();
							}
						}
						else
						{
							this.needDiscountTips = false;
							this.mNormalCostItem.CustomActive(true);
							this.mDiscountGO.CustomActive(false);
						}
					}
					else
					{
						this.needDiscountTips = false;
						this.mNormalCostItem.CustomActive(true);
						this.mDiscountGO.CustomActive(false);
					}
				}
				else
				{
					this.mNormalCostItem.CustomActive(false);
					this.mDiscountGO.CustomActive(true);
					this.mDiscountCount.CustomActive(false);
					this.mDiscountText.CustomActive(false);
					this.mDiscountIcon.CustomActive(false);
					this.mFirstDiscountTxt.CustomActive(true);
					OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
					if (activeDataFromType != null)
					{
						this.mFirstDiscountTxt.SafeSetText(string.Format(TR.Value("DiscountActivity_DiscountTip", activeDataFromType.parm * 1f / 10f), new object[0]));
						ETCImageLoader.LoadSprite(ref this.mDiscountIcon, tableItem3.Icon, true);
						int discountPrice2 = this.GetDiscountPrice(this.iPrice, (int)activeDataFromType.parm);
						this.mTempPrice = discountPrice2 + this.iPrice * (this.CurNum - 1);
						this.mCostnumDiscount.text = this.mTempPrice.ToString();
						if (this.CurNum > 1)
						{
							this.mFirstDiscountTxt.color = Color.red;
						}
						else
						{
							this.mFirstDiscountTxt.color = this.mOriginalColor;
						}
					}
				}
			}
		}

		// Token: 0x0600ECEE RID: 60654 RVA: 0x003F6BE8 File Offset: 0x003F4FE8
		private void UpdateBuyNumberValue()
		{
			if (this.MallItemdata == null)
			{
				return;
			}
			if (this.mBuyNumberValue == null)
			{
				return;
			}
			if (!this.mBuyNumberValue.gameObject.activeSelf)
			{
				return;
			}
			ulong uPrice = (ulong)((long)this.CurNum * (long)((ulong)this.MallItemdata.itemnum));
			string numberStr = MallBuyFrame.GetNumberStr(uPrice, true);
			this.mBuyNumberValue.text = numberStr;
		}

		// Token: 0x0600ECEF RID: 60655 RVA: 0x003F6C54 File Offset: 0x003F5054
		private void _InitComUIList()
		{
			this.mRewardScrollView.Initialize();
			this.mRewardScrollView.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					this._UpdateRewardBind(item);
				}
			};
			this.mRewardScrollView.OnItemRecycle = delegate(ComUIListElementScript item)
			{
				ComCommonBind component = item.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
			};
		}

		// Token: 0x0600ECF0 RID: 60656 RVA: 0x003F6CAC File Offset: 0x003F50AC
		private void _UpdateRewardBind(ComUIListElementScript item)
		{
			ComCommonBind component = item.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			if (item.m_index < 0)
			{
				return;
			}
			GameObject gameObject = component.GetGameObject("rewardRoot");
			ComItem comItem = gameObject.GetComponentInChildren<ComItem>();
			if (comItem == null)
			{
				comItem = base.CreateComItem(gameObject);
			}
			ItemData ItemDetailData = ItemDataManager.CreateItemDataFromTable((int)this.thisGiftList[item.m_index].id, 100, 0);
			if (ItemDetailData == null)
			{
				return;
			}
			ItemDetailData.Count = (int)this.thisGiftList[item.m_index].num;
			comItem.Setup(ItemDetailData, delegate(GameObject Obj, ItemData sitem)
			{
				this._OnShowTips(ItemDetailData);
			});
		}

		// Token: 0x0600ECF1 RID: 60657 RVA: 0x003F6D77 File Offset: 0x003F5177
		private void _OnShowTips(ItemData result)
		{
			if (result == null)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(result, null, 4, true, false, true);
		}

		// Token: 0x0600ECF2 RID: 60658 RVA: 0x003F6D90 File Offset: 0x003F5190
		private void UpdateNumButtonState()
		{
			if (this.MaxNum < 1)
			{
				this.btLeft.GetComponent<UIGray>().enabled = true;
				this.btLeft.interactable = false;
				this.btRight.GetComponent<UIGray>().enabled = true;
				this.btRight.interactable = false;
				this.btMax.GetComponent<UIGray>().enabled = true;
				this.btMax.interactable = false;
			}
			else
			{
				if ((this.limit && this.CurNum >= this.limitnum) || this.CurNum >= this.MaxNum)
				{
					this.btRight.GetComponent<UIGray>().enabled = true;
					this.btRight.interactable = false;
				}
				else
				{
					this.btRight.GetComponent<UIGray>().enabled = false;
					this.btRight.interactable = true;
				}
				if (this.CurNum <= 1)
				{
					this.btLeft.GetComponent<UIGray>().enabled = true;
					this.btLeft.interactable = false;
				}
				else
				{
					this.btLeft.GetComponent<UIGray>().enabled = false;
					this.btLeft.interactable = true;
				}
				this.btMax.GetComponent<UIGray>().enabled = false;
				this.btMax.interactable = true;
			}
		}

		// Token: 0x0600ECF3 RID: 60659 RVA: 0x003F6EDC File Offset: 0x003F52DC
		private void ShowDataText()
		{
			this.mTempPrice = this.CurNum * this.iPrice;
			this.buynum.text = this.CurNum.ToString();
			this.totalprice.text = (this.CurNum * this.iPrice).ToString();
			this.mCostnumNormal.text = (this.CurNum * this.iPrice).ToString();
			this.UpdateBuyNumberValue();
			this.UpdateElementDiscountInformation();
			this.UpdataIntergralInfo();
		}

		// Token: 0x0600ECF4 RID: 60660 RVA: 0x003F6F76 File Offset: 0x003F5376
		private void InitIntergralInfoRoot()
		{
			if (this.MallItemdata == null)
			{
				return;
			}
			this.mIntergralMallInfoRoot.CustomActive(this.MallItemdata.multiple > 0);
		}

		// Token: 0x0600ECF5 RID: 60661 RVA: 0x003F6FA0 File Offset: 0x003F53A0
		private void UpdataIntergralInfo()
		{
			if (this.MallItemdata == null)
			{
				return;
			}
			int num = MallNewUtility.GetTicketConvertIntergalNumnber(this.mTempPrice) * (int)this.MallItemdata.multiple;
			string text = string.Empty;
			if (this.MallItemdata.multiple <= 1)
			{
				text = TR.Value("mall_buy_intergral_single_multiple_desc", num);
			}
			else
			{
				text = TR.Value("mall_buy_intergral_many_multiple_desc", num, this.MallItemdata.multiple);
			}
			this.mIntergralInfoText.text = text;
		}

		// Token: 0x0600ECF6 RID: 60662 RVA: 0x003F702C File Offset: 0x003F542C
		protected override void _bindExUI()
		{
			this.mOpenKeyBoard = this.mBind.GetCom<Button>("OpenKeyBoard");
			if (null != this.mOpenKeyBoard)
			{
				this.mOpenKeyBoard.onClick.AddListener(new UnityAction(this._onOpenKeyBoardButtonClick));
			}
			this.mSetButtonCD = this.mBind.GetCom<SetButtonCD>("SetButtonCD");
			this.mGiftName = this.mBind.GetCom<Text>("GiftName");
			this.mRewardScrollView = this.mBind.GetCom<ComUIListScript>("RewardScrollView");
			this.mBuyNumberRoot = this.mBind.GetGameObject("buyNumberRoot");
			this.mBuyNumberText = this.mBind.GetCom<Text>("buyNumberText");
			this.mBuyItemRoot = this.mBind.GetGameObject("buyItemRoot");
			this.mBuyNumberValue = this.mBind.GetCom<Text>("buyNumberValue");
			this.mBindGoldIcon = this.mBind.GetCom<Image>("bindticketicon");
			this.mGoldIcon = this.mBind.GetCom<Image>("ticketicon");
			this.mDiscountGO = this.mBind.GetGameObject("discountGO");
			this.mDiscountText = this.mBind.GetCom<Text>("discountText");
			this.mDiscountIcon = this.mBind.GetCom<Image>("discountIcon");
			this.mDiscountCount = this.mBind.GetCom<Text>("discountCount");
			this.mNormalCostItem = this.mBind.GetGameObject("NormalCostItem");
			this.mTicketiconDiscount1 = this.mBind.GetCom<Image>("ticketiconDiscount1");
			this.mTicketiconDiscount2 = this.mBind.GetCom<Image>("ticketiconDiscount2");
			this.mCostnumNormal = this.mBind.GetCom<Text>("costnumNormal");
			this.mCostnumDiscount = this.mBind.GetCom<Text>("costnumDiscount");
			this.mIntergralMallInfoRoot = this.mBind.GetGameObject("IntergralMallInfoRoot");
			this.mIntergralInfoText = this.mBind.GetCom<Text>("IntergralInfoText");
			this.mFirstDiscountTxt = this.mBind.GetCom<Text>("FirstDiscountTxt");
			this.mUseDisCountTicketCount = this.mBind.GetCom<Text>("UseDisCountTicketCount");
			this.mUseDisCountTicketIcon = this.mBind.GetCom<Image>("UseDisCountTicketIcon");
			this.mUseVoucherTickeCount = this.mBind.GetCom<Text>("UseVoucherTickeCount");
			this.mUseVoucherTicketIcon = this.mBind.GetCom<Image>("UseVoucherTicketIcon");
			this.mDisCount = this.mBind.GetCom<Text>("DisCount");
			this.mMayDayDisCountRoot = this.mBind.GetGameObject("MayDayDisCountRoot");
			this.mUseVoucherTicketRoot = this.mBind.GetGameObject("UseVoucherTicketRoot");
			this.mUseDiscountTicketRoot = this.mBind.GetGameObject("UseDiscountTicketRoot");
		}

		// Token: 0x0600ECF7 RID: 60663 RVA: 0x003F72FC File Offset: 0x003F56FC
		protected override void _unbindExUI()
		{
			if (null != this.mOpenKeyBoard)
			{
				this.mOpenKeyBoard.onClick.RemoveListener(new UnityAction(this._onOpenKeyBoardButtonClick));
			}
			this.mOpenKeyBoard = null;
			this.mSetButtonCD = null;
			this.mGiftName = null;
			this.mRewardScrollView = null;
			this.mBuyNumberRoot = null;
			this.mBuyNumberText = null;
			this.mBuyItemRoot = null;
			this.mBuyNumberValue = null;
			this.mBindGoldIcon = null;
			this.mGoldIcon = null;
			this.mDiscountGO = null;
			this.mDiscountText = null;
			this.mDiscountIcon = null;
			this.mDiscountCount = null;
			this.mNormalCostItem = null;
			this.mTicketiconDiscount1 = null;
			this.mTicketiconDiscount2 = null;
			this.mCostnumNormal = null;
			this.mCostnumDiscount = null;
			this.mIntergralMallInfoRoot = null;
			this.mIntergralInfoText = null;
			this.mFirstDiscountTxt = null;
			this.mUseDisCountTicketCount = null;
			this.mUseDisCountTicketIcon = null;
			this.mUseVoucherTickeCount = null;
			this.mUseVoucherTicketIcon = null;
			this.mDisCount = null;
			this.mMayDayDisCountRoot = null;
			this.mUseVoucherTicketRoot = null;
			this.mUseDiscountTicketRoot = null;
		}

		// Token: 0x0600ECF8 RID: 60664 RVA: 0x003F7408 File Offset: 0x003F5808
		private void _onOpenKeyBoardButtonClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<VirtualKeyboardFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600ECF9 RID: 60665 RVA: 0x003F741C File Offset: 0x003F581C
		public static string GetNumberStr(ulong uPrice, bool bUseToMillion = false)
		{
			if (uPrice < 10000UL)
			{
				return uPrice.ToString();
			}
			if (uPrice < 10000UL || uPrice >= 100000000UL)
			{
				string arg = (uPrice / 100000000f).ToString("F3");
				return string.Format("{0}亿", arg);
			}
			if (bUseToMillion)
			{
				return string.Format("{0}万", uPrice / 10000f);
			}
			return uPrice.ToString();
		}

		// Token: 0x0600ECFA RID: 60666 RVA: 0x003F74AC File Offset: 0x003F58AC
		private void ReqQueryMallItemInfo(UIEvent uiEvent)
		{
			if (this.MallItemdata == null)
			{
				return;
			}
			uint num = (uint)uiEvent.Param1;
			if (this.MallItemdata.itemid != num)
			{
				return;
			}
			DataManager<MallNewDataManager>.GetInstance().ReqQueryMallItemInfo((int)this.MallItemdata.itemid);
		}

		// Token: 0x0600ECFB RID: 60667 RVA: 0x003F74F8 File Offset: 0x003F58F8
		private void OnQueryMallItenInfoSuccess(UIEvent uiEvent)
		{
			this.MallItemdata = DataManager<MallNewDataManager>.GetInstance().QueryMallItemInfo;
			this.InitIntergralInfoRoot();
			this.UpdataIntergralInfo();
		}

		// Token: 0x0600ECFC RID: 60668 RVA: 0x003F7516 File Offset: 0x003F5916
		private void _OnCountValueChanged(UIEvent uiEvent)
		{
			if (DataManager<AccountShopDataManager>.GetInstance().GetAccountSpecialItemNum(AccountCounterType.ACC_NEW_SERVER_GIFT_DISCOUNT) > 0UL)
			{
				this.Recover();
			}
		}

		// Token: 0x0600ECFD RID: 60669 RVA: 0x003F7534 File Offset: 0x003F5934
		private void _OnLimitTimeDataUpdate(UIEvent uiEvent)
		{
			uint num = (uint)uiEvent.Param1;
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_LIMITTIMEFIRSTDISCOUNTACTIIVITY);
			if (activeDataFromType != null && activeDataFromType.dataId == num && activeDataFromType.state == 0)
			{
				this.Recover();
			}
		}

		// Token: 0x0600ECFE RID: 60670 RVA: 0x003F7580 File Offset: 0x003F5980
		private void Recover()
		{
			if (this.MallItemdata != null)
			{
				this.MaxNum = this.GetMaxNum();
				this.ShowDataText();
				this.UpdateNumButtonState();
			}
		}

		// Token: 0x04009032 RID: 36914
		private MallItemInfo MallItemdata;

		// Token: 0x04009033 RID: 36915
		private ItemTable.eSubType moneyType = ItemTable.eSubType.BindPOINT;

		// Token: 0x04009034 RID: 36916
		private int CurNum = 1;

		// Token: 0x04009035 RID: 36917
		private int MaxNum = 1;

		// Token: 0x04009036 RID: 36918
		private int iPrice;

		// Token: 0x04009037 RID: 36919
		private float fBaseSliderValue;

		// Token: 0x04009038 RID: 36920
		private bool limit;

		// Token: 0x04009039 RID: 36921
		private int limitnum;

		// Token: 0x0400903A RID: 36922
		private int tipsID = -1;

		// Token: 0x0400903B RID: 36923
		private bool isTrueNum;

		// Token: 0x0400903C RID: 36924
		private bool needDiscountTips;

		// Token: 0x0400903D RID: 36925
		private int mTempPrice;

		// Token: 0x0400903E RID: 36926
		private List<ItemReward> thisGiftList = new List<ItemReward>();

		// Token: 0x0400903F RID: 36927
		private ulong itemID;

		// Token: 0x04009040 RID: 36928
		private bool _isUpdate;

		// Token: 0x04009041 RID: 36929
		private Color mOriginalColor;

		// Token: 0x04009042 RID: 36930
		[UIControl("Middle/slider", null, 0)]
		private Slider kSlider;

		// Token: 0x04009043 RID: 36931
		[UIControl("Middle/count/Text", null, 0)]
		protected Text buynum;

		// Token: 0x04009044 RID: 36932
		[UIControl("CostItem/item/costnum", null, 0)]
		protected Text totalprice;

		// Token: 0x04009045 RID: 36933
		[UIControl("Middle/minus", null, 0)]
		protected Button btLeft;

		// Token: 0x04009046 RID: 36934
		[UIControl("Middle/add", null, 0)]
		protected Button btRight;

		// Token: 0x04009047 RID: 36935
		[UIControl("Middle/max", null, 0)]
		protected Button btMax;

		// Token: 0x04009048 RID: 36936
		[UIControl("Middle/Name", null, 0)]
		protected Text name;

		// Token: 0x04009049 RID: 36937
		[UIObject("Middle/BuyItem")]
		protected GameObject pos;

		// Token: 0x0400904A RID: 36938
		[UIControl("Middle/ScrollView/Viewport/Content/Desc", null, 0)]
		protected Text des;

		// Token: 0x0400904B RID: 36939
		[UIControl("CostItem/item/bindticketicon", null, 0)]
		protected Image bindticketicon;

		// Token: 0x0400904C RID: 36940
		[UIControl("CostItem/item/ticketicon", null, 0)]
		protected Image ticketicon;

		// Token: 0x0400904D RID: 36941
		private Button mOpenKeyBoard;

		// Token: 0x0400904E RID: 36942
		private SetButtonCD mSetButtonCD;

		// Token: 0x0400904F RID: 36943
		private Text mGiftName;

		// Token: 0x04009050 RID: 36944
		private ComUIListScript mRewardScrollView;

		// Token: 0x04009051 RID: 36945
		private GameObject mBuyNumberRoot;

		// Token: 0x04009052 RID: 36946
		private Text mBuyNumberText;

		// Token: 0x04009053 RID: 36947
		private GameObject mBuyItemRoot;

		// Token: 0x04009054 RID: 36948
		private Text mBuyNumberValue;

		// Token: 0x04009055 RID: 36949
		private Image mBindGoldIcon;

		// Token: 0x04009056 RID: 36950
		private Image mGoldIcon;

		// Token: 0x04009057 RID: 36951
		private GameObject mDiscountGO;

		// Token: 0x04009058 RID: 36952
		private Text mDiscountText;

		// Token: 0x04009059 RID: 36953
		private Image mDiscountIcon;

		// Token: 0x0400905A RID: 36954
		private Text mDiscountCount;

		// Token: 0x0400905B RID: 36955
		private GameObject mNormalCostItem;

		// Token: 0x0400905C RID: 36956
		private Image mTicketiconDiscount1;

		// Token: 0x0400905D RID: 36957
		private Image mTicketiconDiscount2;

		// Token: 0x0400905E RID: 36958
		private Text mCostnumNormal;

		// Token: 0x0400905F RID: 36959
		private Text mCostnumDiscount;

		// Token: 0x04009060 RID: 36960
		private GameObject mIntergralMallInfoRoot;

		// Token: 0x04009061 RID: 36961
		private Text mIntergralInfoText;

		// Token: 0x04009062 RID: 36962
		private Text mFirstDiscountTxt;

		// Token: 0x04009063 RID: 36963
		private Text mUseDisCountTicketCount;

		// Token: 0x04009064 RID: 36964
		private Image mUseDisCountTicketIcon;

		// Token: 0x04009065 RID: 36965
		private Text mUseVoucherTickeCount;

		// Token: 0x04009066 RID: 36966
		private Image mUseVoucherTicketIcon;

		// Token: 0x04009067 RID: 36967
		private Text mDisCount;

		// Token: 0x04009068 RID: 36968
		private GameObject mMayDayDisCountRoot;

		// Token: 0x04009069 RID: 36969
		private GameObject mUseVoucherTicketRoot;

		// Token: 0x0400906A RID: 36970
		private GameObject mUseDiscountTicketRoot;

		// Token: 0x0400906B RID: 36971
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache0;

		// Token: 0x0400906C RID: 36972
		[CompilerGenerated]
		private static OnCommonMsgBoxToggleClick <>f__mg$cache1;
	}
}
