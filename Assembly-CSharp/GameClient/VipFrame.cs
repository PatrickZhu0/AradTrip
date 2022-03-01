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
	// Token: 0x02001966 RID: 6502
	internal class VipFrame : ClientFrame
	{
		// Token: 0x0600FCB9 RID: 64697 RVA: 0x0045860C File Offset: 0x00456A0C
		public static void OpenLinkFrame(string strParam)
		{
			try
			{
				int num = 0;
				if (int.TryParse(strParam, out num))
				{
					VipTabType vipTabType = (VipTabType)num;
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<VipFrame>(null, false);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, vipTabType, string.Empty);
				}
			}
			catch (Exception ex)
			{
				Logger.LogError(ex.ToString());
			}
		}

		// Token: 0x0600FCBA RID: 64698 RVA: 0x00458674 File Offset: 0x00456A74
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Vip/VipNewFrame";
		}

		// Token: 0x0600FCBB RID: 64699 RVA: 0x0045867C File Offset: 0x00456A7C
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
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VipFrameOpen, null, null, null, null);
		}

		// Token: 0x0600FCBC RID: 64700 RVA: 0x004586D4 File Offset: 0x00456AD4
		protected override void _OnCloseFrame()
		{
			MonthCardBuyResult.bBuyMonthCard = false;
			this.UnBindUIEvent();
			this.ClearData();
			this.mPayFrameManager.Close();
			this.ClosePayReturn();
			this.ClosePayPrivilege();
			this.mFrameData = null;
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VipFrameClose, null, null, null, null);
		}

		// Token: 0x0600FCBD RID: 64701 RVA: 0x00458724 File Offset: 0x00456B24
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
			this.mPayReturnScrollState = VipFrame.PayReturnSrcollState.Middle_Right;
			this.mPayReturnScorllIndex = -1;
			if (this.payPrivilegeFrameData != null)
			{
				this.payPrivilegeFrameData.ClearData();
			}
			this.mPayPrivilegeFrame = null;
		}

		// Token: 0x0600FCBE RID: 64702 RVA: 0x004587C0 File Offset: 0x00456BC0
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdatePayData, new ClientEventSystem.UIEventHandler(this.OnUpdatePayData));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VipPrivilegeFrameOpen, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.VipPrivilegeFrameClose, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameClose));
		}

		// Token: 0x0600FCBF RID: 64703 RVA: 0x00458854 File Offset: 0x00456C54
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdatePayData, new ClientEventSystem.UIEventHandler(this.OnUpdatePayData));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.PlayerVipLvChanged, new ClientEventSystem.UIEventHandler(this.OnPaySuccess));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VipPrivilegeFrameOpen, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.VipPrivilegeFrameClose, new ClientEventSystem.UIEventHandler(this.OnPrivilegeFrameClose));
		}

		// Token: 0x0600FCC0 RID: 64704 RVA: 0x004588E8 File Offset: 0x00456CE8
		private void InitInterface()
		{
			if (DataManager<PlayerBaseData>.GetInstance().VipLevel == -1)
			{
				Logger.LogError("PlayerBaseData.GetInstance().VipLevel doesn't init!");
			}
			this.InitData();
			this.UpdateShowUpLevelData();
		}

		// Token: 0x0600FCC1 RID: 64705 RVA: 0x00458910 File Offset: 0x00456D10
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

		// Token: 0x0600FCC2 RID: 64706 RVA: 0x00458A20 File Offset: 0x00456E20
		private void InitPayFrameManager()
		{
			if (this.goPay == null || this.goPayContent == null)
			{
				Logger.LogError("InitPayFrameManager - out params is null");
				return;
			}
			this.mPayFrameManager = new PayFrame(this.goPay, this.goPayContent);
		}

		// Token: 0x0600FCC3 RID: 64707 RVA: 0x00458A74 File Offset: 0x00456E74
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

		// Token: 0x0600FCC4 RID: 64708 RVA: 0x00458AF4 File Offset: 0x00456EF4
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

		// Token: 0x0600FCC5 RID: 64709 RVA: 0x00458F20 File Offset: 0x00457320
		private void DrawVipLevelExpBar(int iVipLevel, ulong CurVipLvExp, bool force = false)
		{
			if (this.mCostExp)
			{
				this.mCostExp.SetExp(CurVipLvExp, force, (ulong exp) => Singleton<TableManager>.instance.GetCurVipLevelExp(iVipLevel, exp));
			}
		}

		// Token: 0x0600FCC6 RID: 64710 RVA: 0x00458F64 File Offset: 0x00457364
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

		// Token: 0x0600FCC7 RID: 64711 RVA: 0x00458FB4 File Offset: 0x004573B4
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

		// Token: 0x0600FCC8 RID: 64712 RVA: 0x00459006 File Offset: 0x00457406
		private void ClosePayPrivilege()
		{
			if (this.mPayPrivilegeFrame != null)
			{
				this.mPayPrivilegeFrame.DestroyView();
			}
		}

		// Token: 0x0600FCC9 RID: 64713 RVA: 0x0045901E File Offset: 0x0045741E
		private void HidePayPrivilege()
		{
			if (this.mPayPrivilegeFrame != null)
			{
				this.mPayPrivilegeFrame.CloseView();
			}
		}

		// Token: 0x0600FCCA RID: 64714 RVA: 0x00459036 File Offset: 0x00457436
		private void InitEffectRoot()
		{
		}

		// Token: 0x0600FCCB RID: 64715 RVA: 0x00459038 File Offset: 0x00457438
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

		// Token: 0x0600FCCC RID: 64716 RVA: 0x00459089 File Offset: 0x00457489
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

		// Token: 0x0600FCCD RID: 64717 RVA: 0x004590AE File Offset: 0x004574AE
		private void OpenPayReturn()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnPayResultNotify, new ClientEventSystem.UIEventHandler(this.OnReceivePayResult));
			this.SetPayReturnItem(false);
			this.InitEffectRoot();
		}

		// Token: 0x0600FCCE RID: 64718 RVA: 0x004590D8 File Offset: 0x004574D8
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
				case VipFrame.PayReturnSrcollState.Head_Left_Most:
				case VipFrame.PayReturnSrcollState.Tail_Right_Most:
					num2 = this.mPayReturnScorllIndex;
					break;
				case VipFrame.PayReturnSrcollState.Middle_Left:
					num2 = this.mPayReturnScorllIndex - 1;
					if (num2 < 0)
					{
						num2 = 0;
					}
					break;
				case VipFrame.PayReturnSrcollState.Middle_Right:
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
						this.mPayReturnScrollState = VipFrame.PayReturnSrcollState.Middle_Right;
					}
				}
				else
				{
					this.mPayReturnItem.RefreshView(consumeItems[this.mPayReturnScorllIndex]);
				}
			}
			if (this.mPayReturnScorllIndex == 0)
			{
				this.mPayReturnScrollState = VipFrame.PayReturnSrcollState.Head_Left_Most;
				this.SetPayReturnLeftBtnActive(false);
				this.SetPayReturnRightBtnActive(true);
			}
			else if (this.mPayReturnScorllIndex == count - 1)
			{
				this.mPayReturnScrollState = VipFrame.PayReturnSrcollState.Tail_Right_Most;
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(false);
			}
			else
			{
				this.SetPayReturnLeftBtnActive(true);
				this.SetPayReturnRightBtnActive(true);
			}
		}

		// Token: 0x0600FCCF RID: 64719 RVA: 0x00459367 File Offset: 0x00457767
		private void RefreshPayReturn()
		{
			if (this.mPayReturnItem == null)
			{
				return;
			}
			this.mPayReturnItem.RefreshView(null);
		}

		// Token: 0x0600FCD0 RID: 64720 RVA: 0x00459381 File Offset: 0x00457781
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

		// Token: 0x0600FCD1 RID: 64721 RVA: 0x004593C4 File Offset: 0x004577C4
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

		// Token: 0x0600FCD2 RID: 64722 RVA: 0x00459454 File Offset: 0x00457854
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

		// Token: 0x0600FCD3 RID: 64723 RVA: 0x004594E2 File Offset: 0x004578E2
		[UIEventHandle("middle/titleback/Tab{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 3)]
		private void OnSwitchLabel(int iIndex, bool value = true)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			this.SwitchPage((VipTabType)iIndex, false);
		}

		// Token: 0x0600FCD4 RID: 64724 RVA: 0x004594FC File Offset: 0x004578FC
		public void SwitchPage(VipTabType index, bool setTab = true)
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

		// Token: 0x0600FCD5 RID: 64725 RVA: 0x004595BC File Offset: 0x004579BC
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

		// Token: 0x0600FCD6 RID: 64726 RVA: 0x00459610 File Offset: 0x00457A10
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

		// Token: 0x0600FCD7 RID: 64727 RVA: 0x00459676 File Offset: 0x00457A76
		private void OnPaySuccess(UIEvent iEvent)
		{
			this.UpdateShowUpLevelData();
		}

		// Token: 0x0600FCD8 RID: 64728 RVA: 0x0045967E File Offset: 0x00457A7E
		private void OnCounterChanged(UIEvent iEvent)
		{
		}

		// Token: 0x0600FCD9 RID: 64729 RVA: 0x00459680 File Offset: 0x00457A80
		private void OnReceivePayResult(UIEvent uiEvent)
		{
			if (this.mCurTabIndex == VipTabType.PAY_RETRN)
			{
				return;
			}
			this.SetPayReturnItem(false);
			this.RefreshPayReturn();
		}

		// Token: 0x0600FCDA RID: 64730 RVA: 0x0045969C File Offset: 0x00457A9C
		private void OnUpdatePayData(UIEvent iEvent)
		{
			this.RefreshPayReturn();
		}

		// Token: 0x0600FCDB RID: 64731 RVA: 0x004596A4 File Offset: 0x00457AA4
		private void OnSwitchPayReturnTab(UIEvent iEvent)
		{
			this.SwitchPage(VipTabType.PAY_RETRN, true);
		}

		// Token: 0x0600FCDC RID: 64732 RVA: 0x004596AE File Offset: 0x00457AAE
		private void OnPrivilegeFrameOpen(UIEvent iEvent)
		{
		}

		// Token: 0x0600FCDD RID: 64733 RVA: 0x004596B0 File Offset: 0x00457AB0
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

		// Token: 0x0600FCDE RID: 64734 RVA: 0x004596E4 File Offset: 0x00457AE4
		public void OpenPayTab()
		{
			this.SwitchPage(VipTabType.PAY, true);
		}

		// Token: 0x0600FCDF RID: 64735 RVA: 0x004596F0 File Offset: 0x00457AF0
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

		// Token: 0x0600FCE0 RID: 64736 RVA: 0x00459850 File Offset: 0x00457C50
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

		// Token: 0x0600FCE1 RID: 64737 RVA: 0x0045989C File Offset: 0x00457C9C
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
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			}
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

		// Token: 0x0600FCE2 RID: 64738 RVA: 0x00459D74 File Offset: 0x00458174
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
			this.mBtClose = null;
			this.mVipHead2Target = null;
			this.mVipHead2TargetGray = null;
			this.mVipLevel1Target = null;
			this.mVipLevel2Target = null;
			this.mPayPrivilegeContent = null;
			this.mIOSTips = null;
			this.mTab3Text = null;
		}

		// Token: 0x0600FCE3 RID: 64739 RVA: 0x00459F50 File Offset: 0x00458350
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

		// Token: 0x0600FCE4 RID: 64740 RVA: 0x00459FBB File Offset: 0x004583BB
		private void _onPayReturnLeftBtnButtonClick()
		{
			if (this.mPayReturnScrollState == VipFrame.PayReturnSrcollState.Head_Left_Most)
			{
				return;
			}
			this.mPayReturnScrollState = VipFrame.PayReturnSrcollState.Middle_Left;
			this.SetPayReturnItem(true);
		}

		// Token: 0x0600FCE5 RID: 64741 RVA: 0x00459FD7 File Offset: 0x004583D7
		private void _onPayReturnRightBtnButtonClick()
		{
			if (this.mPayReturnScrollState == VipFrame.PayReturnSrcollState.Tail_Right_Most)
			{
				return;
			}
			this.mPayReturnScrollState = VipFrame.PayReturnSrcollState.Middle_Right;
			this.SetPayReturnItem(true);
		}

		// Token: 0x0600FCE6 RID: 64742 RVA: 0x00459FF4 File Offset: 0x004583F4
		private void _onVipFrameBtnButtonClick()
		{
		}

		// Token: 0x0600FCE7 RID: 64743 RVA: 0x00459FF6 File Offset: 0x004583F6
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<VipFrame>(this, false);
		}

		// Token: 0x04009E90 RID: 40592
		protected const string EffUI_shouchong_jiantou01_Path = "Effects/UI/Prefab/EffUI_shouchong/Prefab/EffUI_shouchong_jiantou01";

		// Token: 0x04009E91 RID: 40593
		public const string ICON_VIP_RES_PATH_FORMAT = "UI/Image/Packed/p_UI_Vip.png:UI_Chongzhi_Zi_Guizu_0{0}";

		// Token: 0x04009E92 RID: 40594
		private const string VIP_DES_ELEMENT_PATH = "UIFlatten/Prefabs/Vip/VipElement";

		// Token: 0x04009E93 RID: 40595
		private VipTabType mCurTabIndex = VipTabType.COUNT;

		// Token: 0x04009E94 RID: 40596
		private VipTabType mPreTabIndex = VipTabType.COUNT;

		// Token: 0x04009E95 RID: 40597
		private VipFrameData mFrameData;

		// Token: 0x04009E96 RID: 40598
		private PayItemData mCarddata;

		// Token: 0x04009E97 RID: 40599
		private PayFrame mPayFrameManager;

		// Token: 0x04009E98 RID: 40600
		private bool mPayFrameOpened;

		// Token: 0x04009E99 RID: 40601
		private PayConsumeItem5 mPayReturnItem;

		// Token: 0x04009E9A RID: 40602
		private VipFrame.PayReturnSrcollState mPayReturnScrollState = VipFrame.PayReturnSrcollState.Middle_Right;

		// Token: 0x04009E9B RID: 40603
		private int mPayReturnScorllIndex = -1;

		// Token: 0x04009E9C RID: 40604
		private GameObject effect_left_jiantou_go;

		// Token: 0x04009E9D RID: 40605
		private GameObject effect_right_jiantou_go;

		// Token: 0x04009E9E RID: 40606
		private const int MaxItemNum = 6;

		// Token: 0x04009E9F RID: 40607
		private int mPrivilegeNum;

		// Token: 0x04009EA0 RID: 40608
		private int mMaxVipLevel;

		// Token: 0x04009EA1 RID: 40609
		private List<GameObject> mDesObjList = new List<GameObject>();

		// Token: 0x04009EA2 RID: 40610
		private List<ComItem> mItemList = new List<ComItem>();

		// Token: 0x04009EA3 RID: 40611
		private List<ItemData> mShowTipItemData = new List<ItemData>();

		// Token: 0x04009EA4 RID: 40612
		private List<int> mVipGiftList = new List<int>();

		// Token: 0x04009EA5 RID: 40613
		private PayPrivilegeFrameData payPrivilegeFrameData = new PayPrivilegeFrameData();

		// Token: 0x04009EA6 RID: 40614
		private PayPrivilegeFrame mPayPrivilegeFrame;

		// Token: 0x04009EA7 RID: 40615
		private string desc_monthcard_unActive = "未激活";

		// Token: 0x04009EA8 RID: 40616
		private string desc_monthcard_buySucc_remainDay = string.Empty;

		// Token: 0x04009EA9 RID: 40617
		private string desc_vip_format = "贵族{0}";

		// Token: 0x04009EAA RID: 40618
		private string desc_buy_rmb = "{0}元";

		// Token: 0x04009EAB RID: 40619
		private string desc_buy_30_rmb = "¥ 30 购买";

		// Token: 0x04009EAC RID: 40620
		private string desc_buy_again_30_rmb = "¥ 30 续费";

		// Token: 0x04009EAD RID: 40621
		private string desc_monthcard_remain_days = "月卡剩余{0}天";

		// Token: 0x04009EAE RID: 40622
		[UIControl("middle/titleback/Tab{0}", typeof(Toggle), 1)]
		protected Toggle[] FuncTab = new Toggle[3];

		// Token: 0x04009EAF RID: 40623
		[UIObject("middle/pay")]
		private GameObject goPay;

		// Token: 0x04009EB0 RID: 40624
		[UIObject("middle/pay/Viewport/Content")]
		private GameObject goPayContent;

		// Token: 0x04009EB1 RID: 40625
		private GameObject[] goControlTabs = new GameObject[3];

		// Token: 0x04009EB2 RID: 40626
		private GameObject mTabPay;

		// Token: 0x04009EB3 RID: 40627
		private GameObject mTabPayReturn;

		// Token: 0x04009EB4 RID: 40628
		private GameObject mTabVip;

		// Token: 0x04009EB5 RID: 40629
		private GameObject mNextPayRoot;

		// Token: 0x04009EB6 RID: 40630
		private Text mTxtCurPay;

		// Token: 0x04009EB7 RID: 40631
		private Text mTxtNextpay;

		// Token: 0x04009EB8 RID: 40632
		private Image mTargetVipLv;

		// Token: 0x04009EB9 RID: 40633
		private Image mTargetVipLvSec;

		// Token: 0x04009EBA RID: 40634
		private Image mCurVipLv;

		// Token: 0x04009EBB RID: 40635
		private Image mCurVipLvSec;

		// Token: 0x04009EBC RID: 40636
		private Image mPrivilegeCurVip;

		// Token: 0x04009EBD RID: 40637
		private Image mPrivilegeCurVipSec;

		// Token: 0x04009EBE RID: 40638
		private Image mPrivilegeCurVipSecSingle;

		// Token: 0x04009EBF RID: 40639
		private Text mRechargeMoneyNum;

		// Token: 0x04009EC0 RID: 40640
		private GameObject mTargetLvRootObj;

		// Token: 0x04009EC1 RID: 40641
		private Button mPayCard;

		// Token: 0x04009EC2 RID: 40642
		private Text mCardDay;

		// Token: 0x04009EC3 RID: 40643
		private GameObject mObjTestText;

		// Token: 0x04009EC4 RID: 40644
		private Text mCardBtText;

		// Token: 0x04009EC5 RID: 40645
		private GameObject mVipOnlyRight1;

		// Token: 0x04009EC6 RID: 40646
		private GameObject mVipOnlyRight2;

		// Token: 0x04009EC7 RID: 40647
		private ComExpBar mCostExp;

		// Token: 0x04009EC8 RID: 40648
		private Text mVipLevelNum2;

		// Token: 0x04009EC9 RID: 40649
		private GameObject mPayReturnContent;

		// Token: 0x04009ECA RID: 40650
		private Button mPayReturnLeftBtn;

		// Token: 0x04009ECB RID: 40651
		private Button mPayReturnRightBtn;

		// Token: 0x04009ECC RID: 40652
		private GameObject mEffectRoot_LeftBtn;

		// Token: 0x04009ECD RID: 40653
		private GameObject mEffectRoot_RightBtn;

		// Token: 0x04009ECE RID: 40654
		private Text mVipMaxText;

		// Token: 0x04009ECF RID: 40655
		private Button mVipFrameBtn;

		// Token: 0x04009ED0 RID: 40656
		private GameObject mChecktext;

		// Token: 0x04009ED1 RID: 40657
		private GameObject mVipFrameBtnImg;

		// Token: 0x04009ED2 RID: 40658
		private Button mBtClose;

		// Token: 0x04009ED3 RID: 40659
		private GameObject mVipHead2Target;

		// Token: 0x04009ED4 RID: 40660
		private UIGray mVipHead2TargetGray;

		// Token: 0x04009ED5 RID: 40661
		private Image mVipLevel1Target;

		// Token: 0x04009ED6 RID: 40662
		private Image mVipLevel2Target;

		// Token: 0x04009ED7 RID: 40663
		private GameObject mPayPrivilegeContent;

		// Token: 0x04009ED8 RID: 40664
		private Text mIOSTips;

		// Token: 0x04009ED9 RID: 40665
		private Text mTab3Text;

		// Token: 0x02001967 RID: 6503
		private enum PayReturnSrcollState
		{
			// Token: 0x04009EDC RID: 40668
			Head_Left_Most,
			// Token: 0x04009EDD RID: 40669
			Middle_Left,
			// Token: 0x04009EDE RID: 40670
			Middle_Right,
			// Token: 0x04009EDF RID: 40671
			Tail_Right_Most
		}
	}
}
