using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001771 RID: 6001
	public class MallPayFrame : ClientFrame
	{
		// Token: 0x0600ED0E RID: 60686 RVA: 0x003F7CCF File Offset: 0x003F60CF
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Mall/MallPayFrame";
		}

		// Token: 0x0600ED0F RID: 60687 RVA: 0x003F7CD8 File Offset: 0x003F60D8
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
			this.BindUIEvent();
			if (this.userData != null)
			{
				VipTabType index = (VipTabType)this.userData;
				this.SwitchPage(index, true);
			}
			else
			{
				this.SwitchPage(VipTabType.VIP, true);
			}
		}

		// Token: 0x0600ED10 RID: 60688 RVA: 0x003F7D1D File Offset: 0x003F611D
		protected override void _OnCloseFrame()
		{
			MonthCardBuyResult.bBuyMonthCard = false;
			this.UnBindUIEvent();
			this.ClearData();
			this.mPayFrameManager.Close();
			this.ClosePayReturn();
			this.ClosePayPrivilege();
			this.mFrameData = null;
		}

		// Token: 0x0600ED11 RID: 60689 RVA: 0x003F7D50 File Offset: 0x003F6150
		private void ClearData()
		{
			this.mMaxVipLevel = 0;
			this.mPrivilegeNum = 0;
			this.mCurTabIndex = VipTabType.COUNT;
			this.mPreTabIndex = VipTabType.COUNT;
			this.mFrameData = null;
			this.mCarddata = null;
			this.mPayReturnItem = null;
			this.mPayFrameOpened = false;
			this.mDesObjList.Clear();
			this.mItemList.Clear();
			this.mShowTipItemData.Clear();
			this.mVipGiftList.Clear();
			this.mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Middle_Right;
			this.mPayReturnScorllIndex = -1;
			if (this.payPrivilegeFrameData != null)
			{
				this.payPrivilegeFrameData.ClearData();
			}
			this.mPayPrivilegeFrame = null;
		}

		// Token: 0x0600ED12 RID: 60690 RVA: 0x003F7DEC File Offset: 0x003F61EC
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdatePayData, new ClientEventSystem.UIEventHandler(this.OnUpdatePayData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VipPrivilegeFrameOpen, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VipPrivilegeFrameClose, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameClose));
		}

		// Token: 0x0600ED13 RID: 60691 RVA: 0x003F7E80 File Offset: 0x003F6280
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdatePayData, new ClientEventSystem.UIEventHandler(this.OnUpdatePayData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VipPrivilegeFrameOpen, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VipPrivilegeFrameClose, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameClose));
		}

		// Token: 0x0600ED14 RID: 60692 RVA: 0x003F7F14 File Offset: 0x003F6314
		private void InitInterface()
		{
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel == -1)
			{
				Logger.LogError("PlayerBaseData.GetInstance().VipLevel doesn't init!");
			}
			this.InitData();
			this.UpdateShowUpLevelData();
		}

		// Token: 0x0600ED15 RID: 60693 RVA: 0x003F7F3C File Offset: 0x003F633C
		private void InitData()
		{
			this.InitTRTextDesc();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<VipPrivilegeTable>();
			if (table != null)
			{
				this.mPrivilegeNum = table.Count;
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(7, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this.mMaxVipLevel = tableItem.Value;
			}
			if (this.payPrivilegeFrameData != null)
			{
				this.payPrivilegeFrameData.PrivilegeNum = this.mPrivilegeNum;
				this.payPrivilegeFrameData.MaxVipLevel = this.mMaxVipLevel;
				this.payPrivilegeFrameData.CurShowVipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			}
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel >= this.mMaxVipLevel)
			{
				if (this.mTargetLvRootObj)
				{
					this.mTargetLvRootObj.CustomActive(false);
				}
				if (this.mVipMaxText)
				{
					this.mVipMaxText.gameObject.CustomActive(true);
				}
				if (this.mVipHead2Target)
				{
					this.mVipHead2Target.CustomActive(false);
				}
			}
			this.InitPayFrameManager();
		}

		// Token: 0x0600ED16 RID: 60694 RVA: 0x003F804C File Offset: 0x003F644C
		private void InitPayFrameManager()
		{
			if (this.goPay == null || this.goPayContent == null)
			{
				Logger.LogError("InitPayFrameManager - out params is null");
				return;
			}
			this.mPayFrameManager = new PayFrame(this.goPay, this.goPayContent);
		}

		// Token: 0x0600ED17 RID: 60695 RVA: 0x003F80A0 File Offset: 0x003F64A0
		private void InitTRTextDesc()
		{
			this.desc_monthcard_unActive = TR.Value("vip_month_card_first_buy_cost_unactive");
			this.desc_monthcard_buySucc_remainDay = TR.Value("vip_month_card_first_buy_cost_success_remain_days");
			this.desc_vip_format = TR.Value("VipFormat");
			this.desc_buy_rmb = TR.Value("vip_month_card_first_buy_cost_desc");
			this.desc_buy_30_rmb = TR.Value("vip_month_card_first_buy_cost_rmb_30");
			this.desc_buy_again_30_rmb = TR.Value("vip_month_card_first_buy_cost_again_rmb_30");
			this.desc_monthcard_remain_days = TR.Value("vip_month_card_remain_time");
		}

		// Token: 0x0600ED18 RID: 60696 RVA: 0x003F8120 File Offset: 0x003F6520
		private void UpdateShowUpLevelData()
		{
			if (this.payPrivilegeFrameData != null)
			{
				this.payPrivilegeFrameData.CurShowVipLevel = DataManager<PlayerBaseData>.GetInstance().VipLevel;
			}
			if (this.mCurVipLvSec)
			{
				this.mCurVipLvSec.gameObject.CustomActive(true);
			}
			if (this.mCurVipLv)
			{
				this.mCurVipLv.gameObject.CustomActive(DataManager<PlayerBaseData>.GetInstance().VipLevel >= 10);
			}
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel < 10)
			{
				ETCImageLoader.LoadSprite(ref this.mCurVipLvSec, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", DataManager<PlayerBaseData>.GetInstance().VipLevel), true);
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.mCurVipLv, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", DataManager<PlayerBaseData>.GetInstance().VipLevel % 10), true);
				ETCImageLoader.LoadSprite(ref this.mCurVipLvSec, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", DataManager<PlayerBaseData>.GetInstance().VipLevel / 10), true);
			}
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel >= this.mMaxVipLevel)
			{
				if (this.mTargetLvRootObj)
				{
					this.mTargetLvRootObj.CustomActive(false);
				}
				if (this.mVipMaxText)
				{
					this.mVipMaxText.gameObject.CustomActive(true);
				}
				if (this.mVipHead2Target)
				{
					this.mVipHead2Target.CustomActive(false);
				}
			}
			else
			{
				if (DataManager<PlayerBaseData>.GetInstance().VipLevel <= 0)
				{
				}
				VipTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<VipTable>(DataManager<PlayerBaseData>.GetInstance().VipLevel, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (this.mTargetLvRootObj)
					{
						this.mTargetLvRootObj.CustomActive(true);
					}
					if (this.mRechargeMoneyNum)
					{
						this.mRechargeMoneyNum.text = string.Format(this.desc_buy_rmb, tableItem.TotalRmb - DataManager<PlayerBaseData>.GetInstance().CurVipLvRmb);
					}
					if (this.mTargetVipLv)
					{
						this.mTargetVipLv.gameObject.CustomActive(DataManager<PlayerBaseData>.GetInstance().VipLevel >= 9);
					}
					if (DataManager<PlayerBaseData>.GetInstance().VipLevel < 9)
					{
						ETCImageLoader.LoadSprite(ref this.mTargetVipLvSec, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", DataManager<PlayerBaseData>.GetInstance().VipLevel + 1), true);
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.mTargetVipLv, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", (DataManager<PlayerBaseData>.GetInstance().VipLevel + 1) % 10), true);
						ETCImageLoader.LoadSprite(ref this.mTargetVipLvSec, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", (DataManager<PlayerBaseData>.GetInstance().VipLevel + 1) / 10), true);
					}
					if (this.mVipLevelNum2)
					{
						this.mVipLevelNum2.text = (DataManager<PlayerBaseData>.GetInstance().VipLevel + 1).ToString();
					}
					if (this.mVipHead2Target)
					{
						this.mVipHead2Target.CustomActive(true);
					}
					int num = DataManager<PlayerBaseData>.GetInstance().VipLevel + 1;
					if (this.mVipLevel1Target)
					{
						this.mVipLevel1Target.gameObject.CustomActive(true);
					}
					if (this.mVipLevel2Target)
					{
						this.mVipLevel2Target.gameObject.CustomActive(num >= 10);
					}
					if (num < 10)
					{
						ETCImageLoader.LoadSprite(ref this.mVipLevel1Target, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", num), true);
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.mVipLevel1Target, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", num / 10), true);
						ETCImageLoader.LoadSprite(ref this.mVipLevel2Target, string.Format("UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}", num % 10), true);
					}
					if (this.mVipHead2TargetGray)
					{
						this.mVipHead2TargetGray.enabled = false;
						this.mVipHead2TargetGray.enabled = true;
					}
				}
			}
			this.DrawVipLevelExpBar(DataManager<PlayerBaseData>.GetInstance().VipLevel, (ulong)((long)DataManager<PlayerBaseData>.GetInstance().CurVipLvRmb), true);
		}

		// Token: 0x0600ED19 RID: 60697 RVA: 0x003F854C File Offset: 0x003F694C
		private void DrawVipLevelExpBar(int iVipLevel, ulong CurVipLvExp, bool force = false)
		{
			if (this.mCostExp)
			{
				this.mCostExp.SetExp(CurVipLvExp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurVipLevelExp(iVipLevel, exp));
			}
		}

		// Token: 0x0600ED1A RID: 60698 RVA: 0x003F8590 File Offset: 0x003F6990
		private void ShowPay(bool show)
		{
			if (show)
			{
				if (!this.mPayFrameManager.isOpened)
				{
					this.mPayFrameManager.Open();
				}
				else
				{
					this.mPayFrameManager.Show(show);
				}
			}
			else
			{
				this.mPayFrameManager.Show(show);
			}
		}

		// Token: 0x0600ED1B RID: 60699 RVA: 0x003F85E0 File Offset: 0x003F69E0
		private void ShowPayPrivilege()
		{
			if (this.mPayPrivilegeFrame == null)
			{
				this.mPayPrivilegeFrame = new PayPrivilegeFrame(this.payPrivilegeFrameData, this.mPayPrivilegeContent, this);
				this.mPayPrivilegeFrame.UpdateView(null);
			}
			else
			{
				this.mPayPrivilegeFrame.UpdateView(this.payPrivilegeFrameData);
			}
		}

		// Token: 0x0600ED1C RID: 60700 RVA: 0x003F8632 File Offset: 0x003F6A32
		private void ClosePayPrivilege()
		{
			if (this.mPayPrivilegeFrame != null)
			{
				this.mPayPrivilegeFrame.DestroyView();
			}
		}

		// Token: 0x0600ED1D RID: 60701 RVA: 0x003F864A File Offset: 0x003F6A4A
		private void HidePayPrivilege()
		{
			if (this.mPayPrivilegeFrame != null)
			{
				this.mPayPrivilegeFrame.CloseView();
			}
		}

		// Token: 0x0600ED1E RID: 60702 RVA: 0x003F8662 File Offset: 0x003F6A62
		private void InitEffectRoot()
		{
		}

		// Token: 0x0600ED1F RID: 60703 RVA: 0x003F8664 File Offset: 0x003F6A64
		private void ClearEffectRoot()
		{
			if (this.effect_left_jiantou_go)
			{
				Object.Destroy(this.effect_left_jiantou_go);
				this.effect_left_jiantou_go = null;
			}
			if (this.effect_right_jiantou_go)
			{
				Object.Destroy(this.effect_right_jiantou_go);
				this.effect_right_jiantou_go = null;
			}
		}

		// Token: 0x0600ED20 RID: 60704 RVA: 0x003F86B5 File Offset: 0x003F6AB5
		private void ShowPayReturn()
		{
			if (this.mPayFrameOpened)
			{
				this.RefreshPayReturn();
			}
			else
			{
				this.mPayFrameOpened = true;
				this.OpenPayReturn();
			}
		}

		// Token: 0x0600ED21 RID: 60705 RVA: 0x003F86DA File Offset: 0x003F6ADA
		private void OpenPayReturn()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnReceivePayResult));
			this.SetPayReturnItem(false);
			this.InitEffectRoot();
		}

		// Token: 0x0600ED22 RID: 60706 RVA: 0x003F8704 File Offset: 0x003F6B04
		private void SetPayReturnItem(bool bForceScorll = false)
		{
			bool flag = false;
			int num = -1;
			string text = string.Empty;
			string text2 = string.Empty;
			List<ActiveManager.ActivityData> consumeItems = Singleton<PayManager>.GetInstance().GetConsumeItems(true);
			if (consumeItems == null)
			{
				Logger.LogError("[Pay Return] - PayManager get consume items is null !");
				return;
			}
			int count = consumeItems.Count;
			for (int i = 0; i < count; i++)
			{
				if (!flag && consumeItems[i].status == 1)
				{
					flag = true;
					if (consumeItems[i].akActivityValues.Count < 2)
					{
						text2 = 6.ToString();
					}
					else
					{
						text = consumeItems[i].akActivityValues[0].value;
						text2 = consumeItems[i].akActivityValues[1].value;
					}
					num = i;
				}
			}
			for (int j = 0; j < count; j++)
			{
				if (consumeItems[j].status == 2)
				{
					num = j;
					break;
				}
			}
			this.mNextPayRoot.CustomActive(false);
			if (bForceScorll)
			{
				int num2 = -1;
				switch (this.mPayReturnScrollState)
				{
				case MallPayFrame.PayReturnSrcollState.Head_Left_Most:
				case MallPayFrame.PayReturnSrcollState.Tail_Right_Most:
					num2 = this.mPayReturnScorllIndex;
					break;
				case MallPayFrame.PayReturnSrcollState.Middle_Left:
					num2 = this.mPayReturnScorllIndex - 1;
					if (num2 < 0)
					{
						num2 = 0;
					}
					break;
				case MallPayFrame.PayReturnSrcollState.Middle_Right:
					num2 = this.mPayReturnScorllIndex + 1;
					if (num2 > count)
					{
						num2 = count - 1;
					}
					break;
				}
				this.mPayReturnScorllIndex = num2;
			}
			else
			{
				this.mPayReturnScorllIndex = num;
			}
			if (this.mPayReturnScorllIndex < 0)
			{
				this.mPayReturnScorllIndex = count - 1;
			}
			if (count > this.mPayReturnScorllIndex && this.mPayReturnScorllIndex >= 0)
			{
				if (this.mPayReturnItem == null)
				{
					if (this.mPayReturnContent)
					{
						this.mPayReturnItem = new PayConsumeItem5(consumeItems[this.mPayReturnScorllIndex], this.mPayReturnContent, this);
						this.mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Middle_Right;
					}
				}
				else
				{
					this.mPayReturnItem.RefreshView(consumeItems[this.mPayReturnScorllIndex]);
				}
			}
			if (this.mPayReturnScorllIndex == 0)
			{
				this.mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Head_Left_Most;
				this.SetPayReturnLeftBtnActive(false);
				this.SetPayReturnRightBtnActive(true);
			}
			else if (this.mPayReturnScorllIndex == count - 1)
			{
				this.mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Tail_Right_Most;
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(false);
			}
			else
			{
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(true);
			}
		}

		// Token: 0x0600ED23 RID: 60707 RVA: 0x003F8993 File Offset: 0x003F6D93
		private void RefreshPayReturn()
		{
			if (this.mPayReturnItem == null)
			{
				return;
			}
			this.mPayReturnItem.RefreshView(null);
		}

		// Token: 0x0600ED24 RID: 60708 RVA: 0x003F89AD File Offset: 0x003F6DAD
		private void ClosePayReturn()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnReceivePayResult));
			if (this.mPayReturnItem != null)
			{
				this.mPayReturnItem.Clear();
			}
			this.ClearEffectRoot();
			this.mPayFrameOpened = false;
		}

		// Token: 0x0600ED25 RID: 60709 RVA: 0x003F89F0 File Offset: 0x003F6DF0
		private void SetPayReturnLeftBtnActive(bool bActive)
		{
			if (this.mPayReturnLeftBtn)
			{
				UIGray uigray = this.mPayReturnLeftBtn.gameObject.GetComponent<UIGray>();
				if (uigray == null)
				{
					uigray = this.mPayReturnLeftBtn.gameObject.AddComponent<UIGray>();
				}
				uigray.enabled = !bActive;
				this.mPayReturnLeftBtn.interactable = bActive;
				this.mPayReturnLeftBtn.gameObject.CustomActive(bActive);
			}
			if (this.mEffectRoot_LeftBtn)
			{
				this.mEffectRoot_LeftBtn.CustomActive(bActive);
			}
		}

		// Token: 0x0600ED26 RID: 60710 RVA: 0x003F8A80 File Offset: 0x003F6E80
		private void SetPayReturnRightBtnActive(bool bActive)
		{
			if (this.mPayReturnRightBtn)
			{
				UIGray uigray = this.mPayReturnRightBtn.gameObject.GetComponent<UIGray>();
				if (uigray == null)
				{
					uigray = this.mPayReturnRightBtn.gameObject.AddComponent<UIGray>();
				}
				uigray.enabled = !bActive;
				this.mPayReturnRightBtn.interactable = bActive;
				this.mPayReturnRightBtn.gameObject.CustomActive(bActive);
			}
			if (this.mEffectRoot_RightBtn)
			{
				this.mEffectRoot_RightBtn.CustomActive(bActive);
			}
		}

		// Token: 0x0600ED27 RID: 60711 RVA: 0x003F8B0E File Offset: 0x003F6F0E
		[UIEventHandle("middle/titleback/Tab{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnSwitchLabel(int iIndex, bool value = true)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			this.SwitchPage((VipTabType)iIndex, false);
		}

		// Token: 0x0600ED28 RID: 60712 RVA: 0x003F8B28 File Offset: 0x003F6F28
		private void SwitchPage(VipTabType index, bool setTab = true)
		{
			if (this.mCurTabIndex == index)
			{
				return;
			}
			this.mPreTabIndex = this.mCurTabIndex;
			this.mCurTabIndex = index;
			this.FuncTab[(int)this.mCurTabIndex].isOn = true;
			for (int i = 0; i < 3; i++)
			{
				this.goControlTabs[i].CustomActive(false);
			}
			this.goControlTabs[(int)index].CustomActive(true);
			this.ShowPay(false);
			this.HidePayPrivilege();
			VipTabType vipTabType = this.mCurTabIndex;
			if (vipTabType != VipTabType.PAY)
			{
				if (vipTabType != VipTabType.PAY_RETRN)
				{
					if (vipTabType == VipTabType.VIP)
					{
						this.ShowPayPrivilege();
					}
				}
				else
				{
					this.ShowPayReturn();
				}
			}
			else
			{
				this.ShowPay(true);
			}
		}

		// Token: 0x0600ED29 RID: 60713 RVA: 0x003F8BE8 File Offset: 0x003F6FE8
		private void ShowVipPrivilegeTab(bool bShow)
		{
			if (this.FuncTab == null || this.FuncTab.Length < 3)
			{
				return;
			}
			Toggle toggle = this.FuncTab[2];
			if (toggle)
			{
				toggle.isOn = !bShow;
				toggle.gameObject.CustomActive(bShow);
			}
		}

		// Token: 0x0600ED2A RID: 60714 RVA: 0x003F8C3C File Offset: 0x003F703C
		private void TryChangeVipTabTitleForIOS()
		{
			if (this.mVipFrameBtnImg)
			{
				this.mVipFrameBtnImg.gameObject.CustomActive(false);
			}
			if (this.mChecktext)
			{
				this.mChecktext.CustomActive(true);
			}
			if (this.mTab3Text)
			{
				this.mTab3Text.CustomActive(false);
			}
		}

		// Token: 0x0600ED2B RID: 60715 RVA: 0x003F8CA2 File Offset: 0x003F70A2
		private void OnPaySuccess(UIEvent iEvent)
		{
			this.UpdateShowUpLevelData();
		}

		// Token: 0x0600ED2C RID: 60716 RVA: 0x003F8CAA File Offset: 0x003F70AA
		private void OnCounterChanged(UIEvent iEvent)
		{
		}

		// Token: 0x0600ED2D RID: 60717 RVA: 0x003F8CAC File Offset: 0x003F70AC
		private void OnReceivePayResult(UIEvent uiEvent)
		{
			if (this.mCurTabIndex == VipTabType.PAY_RETRN)
			{
				return;
			}
			this.SetPayReturnItem(false);
			this.RefreshPayReturn();
		}

		// Token: 0x0600ED2E RID: 60718 RVA: 0x003F8CC8 File Offset: 0x003F70C8
		private void OnUpdatePayData(UIEvent iEvent)
		{
			this.RefreshPayReturn();
		}

		// Token: 0x0600ED2F RID: 60719 RVA: 0x003F8CD0 File Offset: 0x003F70D0
		private void OnSwitchPayReturnTab(UIEvent iEvent)
		{
			this.SwitchPage(VipTabType.PAY_RETRN, true);
		}

		// Token: 0x0600ED30 RID: 60720 RVA: 0x003F8CDA File Offset: 0x003F70DA
		private void OnPrivilegeFrameOpen(UIEvent iEvent)
		{
		}

		// Token: 0x0600ED31 RID: 60721 RVA: 0x003F8CDC File Offset: 0x003F70DC
		private void OnPrivilegeFrameClose(UIEvent iEvent)
		{
			if (this.mPreTabIndex == VipTabType.COUNT || this.mPreTabIndex == VipTabType.VIP)
			{
				this.SwitchPage(VipTabType.PAY, true);
			}
			else
			{
				this.SwitchPage(this.mPreTabIndex, true);
			}
		}

		// Token: 0x0600ED32 RID: 60722 RVA: 0x003F8D10 File Offset: 0x003F7110
		public void OpenPayTab()
		{
			this.SwitchPage(VipTabType.PAY, true);
		}

		// Token: 0x0600ED33 RID: 60723 RVA: 0x003F8D1C File Offset: 0x003F711C
		[MessageHandle(604008U, false, 0)]
		private void OnReceivePayItem(MsgDATA msg)
		{
			WorldBillingGoodsRes worldBillingGoodsRes = new WorldBillingGoodsRes();
			worldBillingGoodsRes.decode(msg.bytes);
			PayItemData[] array = new PayItemData[worldBillingGoodsRes.goods.Length];
			ChargeGoods good = worldBillingGoodsRes.goods[0];
			PayItemData payItemData = new PayItemData(good);
			this.mCarddata = payItemData;
			if (this.mCarddata.remainDays == 0)
			{
				this.mCardDay.text = this.desc_monthcard_unActive;
				this.mCardBtText.text = this.desc_buy_30_rmb;
			}
			else if (this.mCarddata.remainDays > 0)
			{
				this.mCardDay.text = string.Format(this.desc_monthcard_remain_days, (this.mCarddata.remainDays - 1).ToString());
				this.mCardBtText.text = this.desc_buy_again_30_rmb;
				if (MonthCardBuyResult.bBuyMonthCard)
				{
					MonthCardBuyResult.bBuyMonthCard = false;
					ClientSystemManager instance = Singleton<ClientSystemManager>.GetInstance();
					FrameLayer layer = FrameLayer.Middle;
					MonthCardBuyResultUserData monthCardBuyResultUserData = new MonthCardBuyResultUserData();
					monthCardBuyResultUserData.strResultInfo = string.Format(this.desc_monthcard_buySucc_remainDay, (this.mCarddata.remainDays - 1).ToString());
					monthCardBuyResultUserData.okCallBack = delegate()
					{
						string text = typeof(ActiveChargeFrame).Name + 9380.ToString();
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen(text))
						{
							ActiveChargeFrame activeChargeFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(text) as ActiveChargeFrame;
							activeChargeFrame.Close(true);
						}
						DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 6000);
					};
					instance.OpenFrame<MonthCardBuyResult>(layer, monthCardBuyResultUserData, string.Empty);
				}
			}
			else
			{
				Logger.LogErrorFormat("数据有误", new object[0]);
			}
		}

		// Token: 0x0600ED34 RID: 60724 RVA: 0x003F8E7C File Offset: 0x003F727C
		[MessageHandle(503302U, false, 0)]
		private void OnPrivilegeGiftBuySuccessRes(MsgDATA msg)
		{
			SceneVipBuyItemRes sceneVipBuyItemRes = new SceneVipBuyItemRes();
			sceneVipBuyItemRes.decode(msg.bytes);
			if (sceneVipBuyItemRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)sceneVipBuyItemRes.result, string.Empty);
				return;
			}
			SystemNotifyManager.SystemNotify(1201, string.Empty);
		}

		// Token: 0x0600ED35 RID: 60725 RVA: 0x003F8EC8 File Offset: 0x003F72C8
		protected override void _bindExUI()
		{
			this.mTabPay = this.mBind.GetGameObject("tabPay");
			this.mTabPayReturn = this.mBind.GetGameObject("tabPayReturn");
			this.mTabVip = this.mBind.GetGameObject("tabVip");
			this.mNextPayRoot = this.mBind.GetGameObject("nextPayRoot");
			this.mTxtCurPay = this.mBind.GetCom<Text>("txtCurPay");
			this.mTxtNextpay = this.mBind.GetCom<Text>("txtNextpay");
			this.mTargetVipLv = this.mBind.GetCom<Image>("TargetVipLv");
			this.mTargetVipLvSec = this.mBind.GetCom<Image>("TargetVipLvSec");
			this.mCurVipLv = this.mBind.GetCom<Image>("CurVipLv");
			this.mCurVipLvSec = this.mBind.GetCom<Image>("CurVipLvSec");
			this.mPrivilegeCurVip = this.mBind.GetCom<Image>("PrivilegeCurVip");
			this.mPrivilegeCurVipSec = this.mBind.GetCom<Image>("PrivilegeCurVipSec");
			this.mPrivilegeCurVipSecSingle = this.mBind.GetCom<Image>("PrivilegeCurVipSecSingle");
			this.mRechargeMoneyNum = this.mBind.GetCom<Text>("RechargeMoneyNum");
			this.mTargetLvRootObj = this.mBind.GetGameObject("TargetLvRootObj");
			this.mPayCard = this.mBind.GetCom<Button>("PayCard");
			if (null != this.mPayCard)
			{
				this.mPayCard.onClick.AddListener(new UnityAction(this._onPayCardButtonClick));
			}
			this.mCardDay = this.mBind.GetCom<Text>("CardDay");
			this.mObjTestText = this.mBind.GetGameObject("objTestText");
			this.mCardBtText = this.mBind.GetCom<Text>("CardBtText");
			this.mVipOnlyRight1 = this.mBind.GetGameObject("VipOnlyRight1");
			this.mVipOnlyRight2 = this.mBind.GetGameObject("VipOnlyRight2");
			this.mCostExp = this.mBind.GetCom<ComExpBar>("costExp");
			this.mVipLevelNum2 = this.mBind.GetCom<Text>("vipLevelNum2");
			this.mPayReturnContent = this.mBind.GetGameObject("payReturnContent");
			this.mPayReturnLeftBtn = this.mBind.GetCom<Button>("payReturnLeftBtn");
			if (null != this.mPayReturnLeftBtn)
			{
				this.mPayReturnLeftBtn.onClick.AddListener(new UnityAction(this._onPayReturnLeftBtnButtonClick));
			}
			this.mPayReturnRightBtn = this.mBind.GetCom<Button>("payReturnRightBtn");
			if (null != this.mPayReturnRightBtn)
			{
				this.mPayReturnRightBtn.onClick.AddListener(new UnityAction(this._onPayReturnRightBtnButtonClick));
			}
			this.mEffectRoot_LeftBtn = this.mBind.GetGameObject("EffectRoot_LeftBtn");
			this.mEffectRoot_RightBtn = this.mBind.GetGameObject("EffectRoot_RightBtn");
			this.mVipMaxText = this.mBind.GetCom<Text>("vipMaxText");
			this.mVipFrameBtn = this.mBind.GetCom<Button>("VipFrameBtn");
			if (null != this.mVipFrameBtn)
			{
				this.mVipFrameBtn.onClick.AddListener(new UnityAction(this._onVipFrameBtnButtonClick));
			}
			this.mChecktext = this.mBind.GetGameObject("checktext");
			this.mVipFrameBtnImg = this.mBind.GetGameObject("VipFrameBtnImg");
			this.mVipHead2Target = this.mBind.GetGameObject("vipHead2Target");
			this.mVipHead2TargetGray = this.mBind.GetCom<UIGray>("vipHead2TargetGray");
			this.mVipLevel1Target = this.mBind.GetCom<Image>("vipLevel1Target");
			this.mVipLevel2Target = this.mBind.GetCom<Image>("vipLevel2Target");
			this.mPayPrivilegeContent = this.mBind.GetGameObject("PayPrivilegeContent");
			this.mIOSTips = this.mBind.GetCom<Text>("IOSTips");
			this.mTab3Text = this.mBind.GetCom<Text>("Tab3Text");
			if (this.mIOSTips)
			{
				this.mIOSTips.CustomActive(false);
			}
			this.goControlTabs[0] = this.mTabPay;
			this.goControlTabs[1] = this.mTabPayReturn;
			this.goControlTabs[2] = this.mTabVip;
			if (this.mPayCard != null)
			{
				this.mPayCard.gameObject.transform.parent.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600ED36 RID: 60726 RVA: 0x003F935C File Offset: 0x003F775C
		protected override void _unbindExUI()
		{
			this.mTabPay = null;
			this.mTabPayReturn = null;
			this.mTabVip = null;
			this.mNextPayRoot = null;
			this.mTxtCurPay = null;
			this.mTxtNextpay = null;
			this.mTargetVipLv = null;
			this.mTargetVipLvSec = null;
			this.mCurVipLv = null;
			this.mCurVipLvSec = null;
			this.mPrivilegeCurVip = null;
			this.mPrivilegeCurVipSec = null;
			this.mPrivilegeCurVipSecSingle = null;
			this.mRechargeMoneyNum = null;
			this.mTargetLvRootObj = null;
			if (null != this.mPayCard)
			{
				this.mPayCard.onClick.RemoveListener(new UnityAction(this._onPayCardButtonClick));
			}
			this.mPayCard = null;
			this.mCardDay = null;
			this.mObjTestText = null;
			this.mCardBtText = null;
			this.mVipOnlyRight1 = null;
			this.mVipOnlyRight2 = null;
			this.mCostExp = null;
			this.mVipLevelNum2 = null;
			this.mPayReturnContent = null;
			if (null != this.mPayReturnLeftBtn)
			{
				this.mPayReturnLeftBtn.onClick.RemoveListener(new UnityAction(this._onPayReturnLeftBtnButtonClick));
			}
			this.mPayReturnLeftBtn = null;
			if (null != this.mPayReturnRightBtn)
			{
				this.mPayReturnRightBtn.onClick.RemoveListener(new UnityAction(this._onPayReturnRightBtnButtonClick));
			}
			this.mPayReturnRightBtn = null;
			this.mEffectRoot_LeftBtn = null;
			this.mEffectRoot_RightBtn = null;
			this.mVipMaxText = null;
			if (null != this.mVipFrameBtn)
			{
				this.mVipFrameBtn.onClick.RemoveListener(new UnityAction(this._onVipFrameBtnButtonClick));
			}
			this.mVipFrameBtn = null;
			this.mChecktext = null;
			this.mVipFrameBtnImg = null;
			this.mVipHead2Target = null;
			this.mVipHead2TargetGray = null;
			this.mVipLevel1Target = null;
			this.mVipLevel2Target = null;
			this.mPayPrivilegeContent = null;
			this.mIOSTips = null;
			this.mTab3Text = null;
		}

		// Token: 0x0600ED37 RID: 60727 RVA: 0x003F9530 File Offset: 0x003F7930
		private void _onPayCardButtonClick()
		{
			if (this.mCarddata == null)
			{
				Logger.LogErrorFormat("Cannot get CardDatas", new object[0]);
				return;
			}
			MonthCardBuyResult.bBuyMonthCard = true;
			Singleton<PayManager>.GetInstance().lastMontchCardNeedOpenWindow = (this.mCarddata.remainDays <= 0);
			Singleton<PayManager>.GetInstance().DoPay(this.mCarddata.ID, this.mCarddata.price, ChargeMallType.Charge);
		}

		// Token: 0x0600ED38 RID: 60728 RVA: 0x003F959B File Offset: 0x003F799B
		private void _onPayReturnLeftBtnButtonClick()
		{
			if (this.mPayReturnScrollState == MallPayFrame.PayReturnSrcollState.Head_Left_Most)
			{
				return;
			}
			this.mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Middle_Left;
			this.SetPayReturnItem(true);
		}

		// Token: 0x0600ED39 RID: 60729 RVA: 0x003F95B7 File Offset: 0x003F79B7
		private void _onPayReturnRightBtnButtonClick()
		{
			if (this.mPayReturnScrollState == MallPayFrame.PayReturnSrcollState.Tail_Right_Most)
			{
				return;
			}
			this.mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Middle_Right;
			this.SetPayReturnItem(true);
		}

		// Token: 0x0600ED3A RID: 60730 RVA: 0x003F95D4 File Offset: 0x003F79D4
		private void _onVipFrameBtnButtonClick()
		{
		}

		// Token: 0x04009077 RID: 36983
		protected const string EffUI_shouchong_jiantou01_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_jiantou01";

		// Token: 0x04009078 RID: 36984
		public const string ICON_VIP_RES_PATH_FORMAT = "UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}";

		// Token: 0x04009079 RID: 36985
		private const string VIP_DES_ELEMENT_PATH = "UIFlatten/Prefabs/Vip/VipElement";

		// Token: 0x0400907A RID: 36986
		private VipTabType mCurTabIndex = VipTabType.COUNT;

		// Token: 0x0400907B RID: 36987
		private VipTabType mPreTabIndex = VipTabType.COUNT;

		// Token: 0x0400907C RID: 36988
		private VipFrameData mFrameData;

		// Token: 0x0400907D RID: 36989
		private PayItemData mCarddata;

		// Token: 0x0400907E RID: 36990
		private PayFrame mPayFrameManager;

		// Token: 0x0400907F RID: 36991
		private bool mPayFrameOpened;

		// Token: 0x04009080 RID: 36992
		private PayConsumeItem5 mPayReturnItem;

		// Token: 0x04009081 RID: 36993
		private MallPayFrame.PayReturnSrcollState mPayReturnScrollState = MallPayFrame.PayReturnSrcollState.Middle_Right;

		// Token: 0x04009082 RID: 36994
		private int mPayReturnScorllIndex = -1;

		// Token: 0x04009083 RID: 36995
		private GameObject effect_left_jiantou_go;

		// Token: 0x04009084 RID: 36996
		private GameObject effect_right_jiantou_go;

		// Token: 0x04009085 RID: 36997
		private const int MaxItemNum = 6;

		// Token: 0x04009086 RID: 36998
		private int mPrivilegeNum;

		// Token: 0x04009087 RID: 36999
		private int mMaxVipLevel;

		// Token: 0x04009088 RID: 37000
		private List<GameObject> mDesObjList = new List<GameObject>();

		// Token: 0x04009089 RID: 37001
		private List<ComItem> mItemList = new List<ComItem>();

		// Token: 0x0400908A RID: 37002
		private List<ItemData> mShowTipItemData = new List<ItemData>();

		// Token: 0x0400908B RID: 37003
		private List<int> mVipGiftList = new List<int>();

		// Token: 0x0400908C RID: 37004
		private PayPrivilegeFrameData payPrivilegeFrameData = new PayPrivilegeFrameData();

		// Token: 0x0400908D RID: 37005
		private PayPrivilegeFrame mPayPrivilegeFrame;

		// Token: 0x0400908E RID: 37006
		private string desc_monthcard_unActive = "未激活";

		// Token: 0x0400908F RID: 37007
		private string desc_monthcard_buySucc_remainDay = string.Empty;

		// Token: 0x04009090 RID: 37008
		private string desc_vip_format = "贵族{0}";

		// Token: 0x04009091 RID: 37009
		private string desc_buy_rmb = "{0}元";

		// Token: 0x04009092 RID: 37010
		private string desc_buy_30_rmb = "¥ 30 购买";

		// Token: 0x04009093 RID: 37011
		private string desc_buy_again_30_rmb = "¥ 30 续费";

		// Token: 0x04009094 RID: 37012
		private string desc_monthcard_remain_days = "月卡剩余{0}天";

		// Token: 0x04009095 RID: 37013
		[UIControl("middle/titleback/Tab{0}", typeof(Toggle), 1)]
		protected Toggle[] FuncTab = new Toggle[3];

		// Token: 0x04009096 RID: 37014
		[UIObject("middle/pay")]
		private GameObject goPay;

		// Token: 0x04009097 RID: 37015
		[UIObject("middle/pay/Viewport/Content")]
		private GameObject goPayContent;

		// Token: 0x04009098 RID: 37016
		private GameObject[] goControlTabs = new GameObject[3];

		// Token: 0x04009099 RID: 37017
		private GameObject mTabPay;

		// Token: 0x0400909A RID: 37018
		private GameObject mTabPayReturn;

		// Token: 0x0400909B RID: 37019
		private GameObject mTabVip;

		// Token: 0x0400909C RID: 37020
		private GameObject mNextPayRoot;

		// Token: 0x0400909D RID: 37021
		private Text mTxtCurPay;

		// Token: 0x0400909E RID: 37022
		private Text mTxtNextpay;

		// Token: 0x0400909F RID: 37023
		private Image mTargetVipLv;

		// Token: 0x040090A0 RID: 37024
		private Image mTargetVipLvSec;

		// Token: 0x040090A1 RID: 37025
		private Image mCurVipLv;

		// Token: 0x040090A2 RID: 37026
		private Image mCurVipLvSec;

		// Token: 0x040090A3 RID: 37027
		private Image mPrivilegeCurVip;

		// Token: 0x040090A4 RID: 37028
		private Image mPrivilegeCurVipSec;

		// Token: 0x040090A5 RID: 37029
		private Image mPrivilegeCurVipSecSingle;

		// Token: 0x040090A6 RID: 37030
		private Text mRechargeMoneyNum;

		// Token: 0x040090A7 RID: 37031
		private GameObject mTargetLvRootObj;

		// Token: 0x040090A8 RID: 37032
		private Button mPayCard;

		// Token: 0x040090A9 RID: 37033
		private Text mCardDay;

		// Token: 0x040090AA RID: 37034
		private GameObject mObjTestText;

		// Token: 0x040090AB RID: 37035
		private Text mCardBtText;

		// Token: 0x040090AC RID: 37036
		private GameObject mVipOnlyRight1;

		// Token: 0x040090AD RID: 37037
		private GameObject mVipOnlyRight2;

		// Token: 0x040090AE RID: 37038
		private ComExpBar mCostExp;

		// Token: 0x040090AF RID: 37039
		private Text mVipLevelNum2;

		// Token: 0x040090B0 RID: 37040
		private GameObject mPayReturnContent;

		// Token: 0x040090B1 RID: 37041
		private Button mPayReturnLeftBtn;

		// Token: 0x040090B2 RID: 37042
		private Button mPayReturnRightBtn;

		// Token: 0x040090B3 RID: 37043
		private GameObject mEffectRoot_LeftBtn;

		// Token: 0x040090B4 RID: 37044
		private GameObject mEffectRoot_RightBtn;

		// Token: 0x040090B5 RID: 37045
		private Text mVipMaxText;

		// Token: 0x040090B6 RID: 37046
		private Button mVipFrameBtn;

		// Token: 0x040090B7 RID: 37047
		private GameObject mChecktext;

		// Token: 0x040090B8 RID: 37048
		private GameObject mVipFrameBtnImg;

		// Token: 0x040090B9 RID: 37049
		private GameObject mVipHead2Target;

		// Token: 0x040090BA RID: 37050
		private UIGray mVipHead2TargetGray;

		// Token: 0x040090BB RID: 37051
		private Image mVipLevel1Target;

		// Token: 0x040090BC RID: 37052
		private Image mVipLevel2Target;

		// Token: 0x040090BD RID: 37053
		private GameObject mPayPrivilegeContent;

		// Token: 0x040090BE RID: 37054
		private Text mIOSTips;

		// Token: 0x040090BF RID: 37055
		private Text mTab3Text;

		// Token: 0x02001772 RID: 6002
		private enum PayReturnSrcollState
		{
			// Token: 0x040090C2 RID: 37058
			Head_Left_Most,
			// Token: 0x040090C3 RID: 37059
			Middle_Left,
			// Token: 0x040090C4 RID: 37060
			Middle_Right,
			// Token: 0x040090C5 RID: 37061
			Tail_Right_Most
		}
	}
}
