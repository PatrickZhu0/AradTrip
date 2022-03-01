using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001383 RID: 4995
	public class MonthCardRewardLockersFrame : ClientFrame
	{
		// Token: 0x0600C1C2 RID: 49602 RVA: 0x002E3095 File Offset: 0x002E1495
		public static void CommonOpen()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MonthCardRewardLockersFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MonthCardRewardLockersFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MonthCardRewardLockersFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600C1C3 RID: 49603 RVA: 0x002E30C5 File Offset: 0x002E14C5
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/MonthCardRewardLockersFrame";
		}

		// Token: 0x0600C1C4 RID: 49604 RVA: 0x002E30CC File Offset: 0x002E14CC
		protected override void _OnOpenFrame()
		{
			DataManager<MonthCardRewardLockersDataManager>.GetInstance().ResetRedPoint();
			this._BindUIEvent();
			this._InitTR();
			this._ReqRefreshView();
		}

		// Token: 0x0600C1C5 RID: 49605 RVA: 0x002E30EC File Offset: 0x002E14EC
		protected override void _OnCloseFrame()
		{
			this.mLockersItems = null;
			if (this.mRefreshCD)
			{
				this.mRefreshCD.StopTimer();
			}
			this._UnInitTR();
			if (this.mBtnAccquireCD)
			{
				this.mBtnAccquireCD.StopBtCD();
			}
			this.mBtnAccquireStatus = MonthCardRewardLockersFrame.BtnAccquireStatus.BuyMonthCard;
			if (this.waitToCloseFrame != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToCloseFrame);
				this.waitToCloseFrame = null;
			}
			this._UnBindUIEvent();
		}

		// Token: 0x0600C1C6 RID: 49606 RVA: 0x002E316C File Offset: 0x002E156C
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardRewardUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardRewardAccquired, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardAccquired));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardUpdate));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnMonthCardRewardCDUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardCDUpdate));
		}

		// Token: 0x0600C1C7 RID: 49607 RVA: 0x002E31E8 File Offset: 0x002E15E8
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardRewardUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardRewardAccquired, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardAccquired));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardUpdate));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnMonthCardRewardCDUpdate, new ClientEventSystem.UIEventHandler(this._OnMonthCardRewardCDUpdate));
		}

		// Token: 0x0600C1C8 RID: 49608 RVA: 0x002E3264 File Offset: 0x002E1664
		private void _InitTR()
		{
			this.tr_month_card_grid_count_full = TR.Value("month_card_grid_count_full");
			this.tr_month_card_grid_count_notfull = TR.Value("month_card_grid_count_notfull");
			this.tr_month_card_accquire_btn_get = TR.Value("month_card_accquire_btn_get");
			this.tr_month_card_accquire_btn_buy = TR.Value("month_card_accquire_btn_buy");
		}

		// Token: 0x0600C1C9 RID: 49609 RVA: 0x002E32B1 File Offset: 0x002E16B1
		private void _UnInitTR()
		{
			this.tr_month_card_grid_count_full = string.Empty;
			this.tr_month_card_grid_count_notfull = string.Empty;
			this.tr_month_card_accquire_btn_get = string.Empty;
			this.tr_month_card_accquire_btn_buy = string.Empty;
		}

		// Token: 0x0600C1CA RID: 49610 RVA: 0x002E32E0 File Offset: 0x002E16E0
		private void _RefreshItemExpiredTime()
		{
			if (null == this.mRefreshCD)
			{
				return;
			}
			uint uniformExpriedLastTime = DataManager<MonthCardRewardLockersDataManager>.GetInstance().UniformExpriedLastTime;
			if (uniformExpriedLastTime <= 0U)
			{
				if (this.mRefreshCD.componetText)
				{
					this.mRefreshCD.componetText.enabled = false;
				}
				this.mRefreshCD.StopTimer();
			}
			else
			{
				if (this.mRefreshCD.componetText)
				{
					this.mRefreshCD.componetText.enabled = true;
				}
				this.mRefreshCD.SetCountdown((int)uniformExpriedLastTime);
				this.mRefreshCD.StartTimer();
			}
		}

		// Token: 0x0600C1CB RID: 49611 RVA: 0x002E3384 File Offset: 0x002E1784
		private void _RefreshItemGridCount()
		{
			int num = 0;
			int num2 = 0;
			if (this.mLockersItems != null)
			{
				num = this.mLockersItems.Count;
			}
			if (this.mComItemBoard)
			{
				num2 = this.mComItemBoard.GetItemGridTotalCount();
			}
			if (this.mGridCount)
			{
				if (num >= num2)
				{
					this.mGridCount.text = string.Format(this.tr_month_card_grid_count_full, num.ToString(), num2.ToString());
				}
				else
				{
					this.mGridCount.text = string.Format(this.tr_month_card_grid_count_notfull, num.ToString(), num2.ToString());
				}
			}
		}

		// Token: 0x0600C1CC RID: 49612 RVA: 0x002E3444 File Offset: 0x002E1844
		private void _RefreshBtnAccquireStatus()
		{
			if (Singleton<PayManager>.GetInstance().HasMonthCardEnabled())
			{
				if (this.mLockersItems == null || this.mLockersItems.Count <= 0)
				{
					this.mBtnAccquireStatus = MonthCardRewardLockersFrame.BtnAccquireStatus.DisableGetReward;
				}
				else
				{
					this.mBtnAccquireStatus = MonthCardRewardLockersFrame.BtnAccquireStatus.EnableGetReward;
				}
			}
			else
			{
				this.mBtnAccquireStatus = MonthCardRewardLockersFrame.BtnAccquireStatus.BuyMonthCard;
			}
			this._SetBtnAccquireText();
			this._SetBtnAccquireEnable();
		}

		// Token: 0x0600C1CD RID: 49613 RVA: 0x002E34A7 File Offset: 0x002E18A7
		private void _SetBtnAccquireText()
		{
			if (this.mBtnAccquireText != null)
			{
				this.mBtnAccquireText.text = ((this.mBtnAccquireStatus != MonthCardRewardLockersFrame.BtnAccquireStatus.BuyMonthCard) ? this.tr_month_card_accquire_btn_get : this.tr_month_card_accquire_btn_buy);
			}
		}

		// Token: 0x0600C1CE RID: 49614 RVA: 0x002E34E4 File Offset: 0x002E18E4
		private void _SetBtnAccquireEnable()
		{
			bool flag = this.mBtnAccquireStatus != MonthCardRewardLockersFrame.BtnAccquireStatus.DisableGetReward;
			if (this.mBtnAccquire)
			{
				this.mBtnAccquire.enabled = flag;
			}
			if (this.mBtnAccquireGray)
			{
				this.mBtnAccquireGray.SetEnable(!flag);
			}
		}

		// Token: 0x0600C1CF RID: 49615 RVA: 0x002E3540 File Offset: 0x002E1940
		private void _ReqRefreshView()
		{
			DataManager<MonthCardRewardLockersDataManager>.GetInstance().ReqMonthCardRewardLockersItems();
		}

		// Token: 0x0600C1D0 RID: 49616 RVA: 0x002E354C File Offset: 0x002E194C
		private void _OnMonthCardRewardUpdate(UIEvent _uiEvent)
		{
			this.mLockersItems = DataManager<MonthCardRewardLockersDataManager>.GetInstance().GetMonthCardRewardLockersItems();
			if (this.mComItemBoard)
			{
				this.mComItemBoard.RefreshItemGrids(this.mLockersItems);
			}
			this._RefreshItemGridCount();
			this._RefreshBtnAccquireStatus();
		}

		// Token: 0x0600C1D1 RID: 49617 RVA: 0x002E358B File Offset: 0x002E198B
		private void _OnMonthCardRewardCDUpdate(UIEvent _uiEvent)
		{
			this._RefreshItemExpiredTime();
		}

		// Token: 0x0600C1D2 RID: 49618 RVA: 0x002E3593 File Offset: 0x002E1993
		private void _OnMonthCardRewardAccquired(UIEvent _uiEvent)
		{
			this._ReqRefreshView();
			if (this.waitToCloseFrame != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.waitToCloseFrame);
			}
			this.waitToCloseFrame = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._WaitToCloseFrame());
		}

		// Token: 0x0600C1D3 RID: 49619 RVA: 0x002E35CC File Offset: 0x002E19CC
		private IEnumerator _WaitToCloseFrame()
		{
			yield return Yielders.GetWaitForSeconds(1f);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<MonthCardRewardLockersFrame>(null, false);
			yield break;
		}

		// Token: 0x0600C1D4 RID: 49620 RVA: 0x002E35E0 File Offset: 0x002E19E0
		private void _OnMonthCardUpdate(UIEvent uiEvent)
		{
			this._RefreshBtnAccquireStatus();
		}

		// Token: 0x0600C1D5 RID: 49621 RVA: 0x002E35E8 File Offset: 0x002E19E8
		protected override void _bindExUI()
		{
			this.mMaskClose = this.mBind.GetCom<Button>("MaskClose");
			if (null != this.mMaskClose)
			{
				this.mMaskClose.onClick.AddListener(new UnityAction(this._onMaskCloseButtonClick));
			}
			this.mComItemBoard = this.mBind.GetCom<ComMonthCardRewardLockersBoard>("ComItemGrids");
			this.mGridCount = this.mBind.GetCom<Text>("GridCount");
			this.mRefreshCD = this.mBind.GetCom<SimpleTimer>("RefreshCD");
			this.mBtnAccquire = this.mBind.GetCom<Button>("BtnAccquire");
			if (null != this.mBtnAccquire)
			{
				this.mBtnAccquire.onClick.AddListener(new UnityAction(this._onBtnAccquireButtonClick));
			}
			this.mBtnAccquireGray = this.mBind.GetCom<UIGray>("BtnAccquireGray");
			this.mBtnAccquireCD = this.mBind.GetCom<SetComButtonCD>("BtnAccquireCD");
			this.mBtnAccquireText = this.mBind.GetCom<Text>("BtnAccquireText");
		}

		// Token: 0x0600C1D6 RID: 49622 RVA: 0x002E3700 File Offset: 0x002E1B00
		protected override void _unbindExUI()
		{
			if (null != this.mMaskClose)
			{
				this.mMaskClose.onClick.RemoveListener(new UnityAction(this._onMaskCloseButtonClick));
			}
			this.mMaskClose = null;
			this.mComItemBoard = null;
			this.mGridCount = null;
			this.mRefreshCD = null;
			if (null != this.mBtnAccquire)
			{
				this.mBtnAccquire.onClick.RemoveListener(new UnityAction(this._onBtnAccquireButtonClick));
			}
			this.mBtnAccquire = null;
			this.mBtnAccquireGray = null;
			this.mBtnAccquireCD = null;
			this.mBtnAccquireText = null;
		}

		// Token: 0x0600C1D7 RID: 49623 RVA: 0x002E379F File Offset: 0x002E1B9F
		private void _onMaskCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600C1D8 RID: 49624 RVA: 0x002E37A8 File Offset: 0x002E1BA8
		private void _onBtnAccquireButtonClick()
		{
			if (this.mBtnAccquireStatus == MonthCardRewardLockersFrame.BtnAccquireStatus.BuyMonthCard)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<VipFrame>(FrameLayer.Middle, VipTabType.PAY, string.Empty);
			}
			else
			{
				if (!this.mBtnAccquireCD.IsBtnWork() || this.mBtnAccquireCD == null)
				{
					return;
				}
				DataManager<MonthCardRewardLockersDataManager>.GetInstance().ReqGetMonthCardRewardLockersItems();
				if (this.mBtnAccquireCD)
				{
					this.mBtnAccquireCD.StartBtCD();
				}
			}
		}

		// Token: 0x04006DC2 RID: 28098
		private List<MonthCardRewardLockersItem> mLockersItems;

		// Token: 0x04006DC3 RID: 28099
		private MonthCardRewardLockersFrame.BtnAccquireStatus mBtnAccquireStatus;

		// Token: 0x04006DC4 RID: 28100
		private string tr_month_card_grid_count_full = string.Empty;

		// Token: 0x04006DC5 RID: 28101
		private string tr_month_card_grid_count_notfull = string.Empty;

		// Token: 0x04006DC6 RID: 28102
		private string tr_month_card_accquire_btn_get = string.Empty;

		// Token: 0x04006DC7 RID: 28103
		private string tr_month_card_accquire_btn_buy = string.Empty;

		// Token: 0x04006DC8 RID: 28104
		private Coroutine waitToCloseFrame;

		// Token: 0x04006DC9 RID: 28105
		private Button mMaskClose;

		// Token: 0x04006DCA RID: 28106
		private ComMonthCardRewardLockersBoard mComItemBoard;

		// Token: 0x04006DCB RID: 28107
		private Text mGridCount;

		// Token: 0x04006DCC RID: 28108
		private SimpleTimer mRefreshCD;

		// Token: 0x04006DCD RID: 28109
		private Button mBtnAccquire;

		// Token: 0x04006DCE RID: 28110
		private UIGray mBtnAccquireGray;

		// Token: 0x04006DCF RID: 28111
		private SetComButtonCD mBtnAccquireCD;

		// Token: 0x04006DD0 RID: 28112
		private Text mBtnAccquireText;

		// Token: 0x02001384 RID: 4996
		public enum BtnAccquireStatus
		{
			// Token: 0x04006DD2 RID: 28114
			BuyMonthCard,
			// Token: 0x04006DD3 RID: 28115
			EnableGetReward,
			// Token: 0x04006DD4 RID: 28116
			DisableGetReward
		}
	}
}
