using System;
using System.Collections.Generic;
using DG.Tweening;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017F6 RID: 6134
	public class OnlineServiceFrame : ClientFrame
	{
		// Token: 0x0600F1BC RID: 61884 RVA: 0x00412DC8 File Offset: 0x004111C8
		protected override void _bindExUI()
		{
			this.mBtnRefresh = this.mBind.GetCom<Button>("BtnRefresh");
			if (null != this.mBtnRefresh)
			{
				this.mBtnRefresh.onClick.AddListener(new UnityAction(this._onBtnRefreshButtonClick));
			}
			this.mBtnGoback = this.mBind.GetCom<Button>("BtnGoback");
			if (null != this.mBtnGoback)
			{
				this.mBtnGoback.onClick.AddListener(new UnityAction(this._onBtnGobackButtonClick));
			}
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mWebView = this.mBind.GetCom<UniWebViewUtility>("WebView");
			this.mVipEntrance = this.mBind.GetGameObject("VipEntrance");
			this.mVipEntranceTween = this.mBind.GetCom<DOTweenAnimation>("VipEntranceTween");
			this.mSpecialServiceBtn = this.mBind.GetCom<Button>("SpecialServiceBtn");
			if (null != this.mSpecialServiceBtn)
			{
				this.mSpecialServiceBtn.onClick.AddListener(new UnityAction(this._onSpecialServiceBtnButtonClick));
			}
			this.mSpecialServiceText = this.mBind.GetCom<Text>("SpecialServiceText");
			this.mVipDescText = this.mBind.GetCom<Text>("VipDescText");
			this.mReturnNormal = this.mBind.GetCom<Button>("ReturnNormal");
			if (null != this.mReturnNormal)
			{
				this.mReturnNormal.onClick.AddListener(new UnityAction(this._onReturnNormalButtonClick));
			}
			this.mText = this.mBind.GetCom<Text>("Text");
		}

		// Token: 0x0600F1BD RID: 61885 RVA: 0x00412FA8 File Offset: 0x004113A8
		protected override void _unbindExUI()
		{
			if (null != this.mBtnRefresh)
			{
				this.mBtnRefresh.onClick.RemoveListener(new UnityAction(this._onBtnRefreshButtonClick));
			}
			this.mBtnRefresh = null;
			if (null != this.mBtnGoback)
			{
				this.mBtnGoback.onClick.RemoveListener(new UnityAction(this._onBtnGobackButtonClick));
			}
			this.mBtnGoback = null;
			if (null != this.mBtnClose)
			{
				this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			}
			this.mBtnClose = null;
			this.mWebView = null;
			this.mVipEntrance = null;
			this.mVipEntranceTween = null;
			if (null != this.mSpecialServiceBtn)
			{
				this.mSpecialServiceBtn.onClick.RemoveListener(new UnityAction(this._onSpecialServiceBtnButtonClick));
			}
			this.mSpecialServiceBtn = null;
			this.mSpecialServiceText = null;
			this.mVipDescText = null;
			if (null != this.mReturnNormal)
			{
				this.mReturnNormal.onClick.RemoveListener(new UnityAction(this._onReturnNormalButtonClick));
			}
			this.mReturnNormal = null;
			this.mText = null;
		}

		// Token: 0x0600F1BE RID: 61886 RVA: 0x004130E3 File Offset: 0x004114E3
		private void _onBtnRefreshButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.ReLoadUrl();
			}
		}

		// Token: 0x0600F1BF RID: 61887 RVA: 0x00413100 File Offset: 0x00411500
		private void _onBtnCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600F1C0 RID: 61888 RVA: 0x00413109 File Offset: 0x00411509
		private void _onBtnGobackButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.GoBackWebView();
			}
		}

		// Token: 0x0600F1C1 RID: 61889 RVA: 0x00413126 File Offset: 0x00411526
		private void _onSpecialServiceBtnButtonClick()
		{
		}

		// Token: 0x0600F1C2 RID: 61890 RVA: 0x00413128 File Offset: 0x00411528
		private void _onReturnNormalButtonClick()
		{
		}

		// Token: 0x0600F1C3 RID: 61891 RVA: 0x0041312A File Offset: 0x0041152A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/OnlineService";
		}

		// Token: 0x0600F1C4 RID: 61892 RVA: 0x00413131 File Offset: 0x00411531
		public static void SetKeyBoardShowOut(bool isShow)
		{
			OnlineServiceFrame.keyboardShowOut = isShow;
		}

		// Token: 0x0600F1C5 RID: 61893 RVA: 0x0041313C File Offset: 0x0041153C
		protected override void _OnOpenFrame()
		{
			this._BindEvent();
			DataManager<OnlineServiceManager>.GetInstance().StartReqOfflineInfos(false);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnRecOnlineServiceNewNote, false, null, null, null);
			string url = string.Empty;
			if (this.userData != null)
			{
				url = (this.userData as string);
			}
			if (this.mBtnGoback)
			{
				this.mBtnGoback.gameObject.CustomActive(false);
			}
			if (this.mWebView != null)
			{
				UniWebViewUtility uniWebViewUtility = this.mWebView;
				uniWebViewUtility.PageViewUpdate = (UniWebViewUtility.OnPageViewUpdate)Delegate.Combine(uniWebViewUtility.PageViewUpdate, new UniWebViewUtility.OnPageViewUpdate(this.OnWebViewUpdate));
				UniWebViewUtility uniWebViewUtility2 = this.mWebView;
				uniWebViewUtility2.PageLoadReveiveMsg = (UniWebViewUtility.OnPageLoadReceiveMsg)Delegate.Combine(uniWebViewUtility2.PageLoadReveiveMsg, new UniWebViewUtility.OnPageLoadReceiveMsg(this.OnJumpVipService));
				this.mWebView.InitWebView(false);
			}
			this.ShowUrlOnWebView(url);
		}

		// Token: 0x0600F1C6 RID: 61894 RVA: 0x00413224 File Offset: 0x00411624
		protected override void _OnCloseFrame()
		{
			this._UnBindEvent();
			if (this.mWebView != null)
			{
				UniWebViewUtility uniWebViewUtility = this.mWebView;
				uniWebViewUtility.PageViewUpdate = (UniWebViewUtility.OnPageViewUpdate)Delegate.Remove(uniWebViewUtility.PageViewUpdate, new UniWebViewUtility.OnPageViewUpdate(this.OnWebViewUpdate));
				UniWebViewUtility uniWebViewUtility2 = this.mWebView;
				uniWebViewUtility2.PageLoadReveiveMsg = (UniWebViewUtility.OnPageLoadReceiveMsg)Delegate.Remove(uniWebViewUtility2.PageLoadReveiveMsg, new UniWebViewUtility.OnPageLoadReceiveMsg(this.OnJumpVipService));
				this.mWebView.UnInitWebView();
			}
			DataManager<OnlineServiceManager>.GetInstance().StartReqOfflineInfos(true);
			this._ClearData();
		}

		// Token: 0x0600F1C7 RID: 61895 RVA: 0x004132B2 File Offset: 0x004116B2
		public override bool IsNeedUpdate()
		{
			return this.canUpdate;
		}

		// Token: 0x0600F1C8 RID: 61896 RVA: 0x004132BC File Offset: 0x004116BC
		protected override void _OnUpdate(float delta)
		{
			this.mTickTime += delta;
			if (this.mTickTime > 1f)
			{
				if (this.mWebView != null)
				{
					this.mWebView.OnUpdate(delta);
				}
				this.mTickTime = 0f;
			}
		}

		// Token: 0x0600F1C9 RID: 61897 RVA: 0x00413310 File Offset: 0x00411710
		private void _BindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewGuideStart));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnRecVipOnlineService, new ClientEventSystem.UIEventHandler(this.OnRecVipOnlineService));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().AddServerFuncSwitchListener(ServiceType.SERVICE_VIP_AUTH, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this.OnServerFuncSwitch));
		}

		// Token: 0x0600F1CA RID: 61898 RVA: 0x0041336C File Offset: 0x0041176C
		private void _UnBindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnNewGuideStart));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnRecVipOnlineService, new ClientEventSystem.UIEventHandler(this.OnRecVipOnlineService));
			DataManager<ServerSceneFuncSwitchManager>.GetInstance().RemoveServerFuncSwitchListener(ServiceType.SERVICE_VIP_AUTH, new ServerSceneFuncSwitchManager.ServerSceneFuncSwitchHandler(this.OnServerFuncSwitch));
		}

		// Token: 0x0600F1CB RID: 61899 RVA: 0x004133C7 File Offset: 0x004117C7
		private void OnNewGuideStart(UIEvent mEvent)
		{
			base.Close(false);
		}

		// Token: 0x0600F1CC RID: 61900 RVA: 0x004133D0 File Offset: 0x004117D0
		private void _ClearData()
		{
			this.beJumpVip = false;
			this.isVipAuthFuncLock = false;
		}

		// Token: 0x0600F1CD RID: 61901 RVA: 0x004133E0 File Offset: 0x004117E0
		private void OnRecVipOnlineService(UIEvent mEvent)
		{
			string url = mEvent.Param1 as string;
			bool flag = (bool)mEvent.Param2;
			this.ShowUrlOnWebView(url);
		}

		// Token: 0x0600F1CE RID: 61902 RVA: 0x0041340C File Offset: 0x0041180C
		private bool TryInitSpecialServiceEntrance()
		{
			return true;
		}

		// Token: 0x0600F1CF RID: 61903 RVA: 0x0041340F File Offset: 0x0041180F
		private void ShowUrlOnWebView(string url)
		{
			if (this.mWebView != null && !string.IsNullOrEmpty(url))
			{
				this.mWebView.LoadUrl(url);
				this.mWebView.ShowWebView();
			}
		}

		// Token: 0x0600F1D0 RID: 61904 RVA: 0x00413444 File Offset: 0x00411844
		private void ShowVipEntrance(bool bShow)
		{
			if (this.mVipEntrance)
			{
				this.mVipEntrance.CustomActive(bShow);
			}
		}

		// Token: 0x0600F1D1 RID: 61905 RVA: 0x00413462 File Offset: 0x00411862
		private void ShowReturnNormalEntrance(bool bShow)
		{
			if (this.mReturnNormal)
			{
				this.mReturnNormal.gameObject.CustomActive(bShow);
			}
		}

		// Token: 0x0600F1D2 RID: 61906 RVA: 0x00413488 File Offset: 0x00411888
		private void ChangeFrameTitle()
		{
			if (this.mText)
			{
				this.mText.text = ((!this.beJumpVip) ? TR.Value("vip_online_service_entrance_normal_title") : TR.Value("vip_online_service_entrance_title"));
			}
		}

		// Token: 0x0600F1D3 RID: 61907 RVA: 0x004134D4 File Offset: 0x004118D4
		private void OnGoBackBtnShow()
		{
		}

		// Token: 0x0600F1D4 RID: 61908 RVA: 0x004134D6 File Offset: 0x004118D6
		private void OnWebViewUpdate()
		{
			this.ChangeFrameTitle();
		}

		// Token: 0x0600F1D5 RID: 61909 RVA: 0x004134E0 File Offset: 0x004118E0
		private void OnJumpVipService(UniWebViewMessage message)
		{
			this.beJumpVip = false;
			if (this.mWebView == null)
			{
				return;
			}
			if (message.Equals(null))
			{
				return;
			}
			if (!message.Path.Equals("jumpvip"))
			{
				return;
			}
			if (message.Args == null)
			{
				return;
			}
			string text = string.Empty;
			foreach (KeyValuePair<string, string> keyValuePair in message.Args)
			{
				if (keyValuePair.Key.Equals("params"))
				{
					text = keyValuePair.Value;
					if (!string.IsNullOrEmpty(text))
					{
						this.beJumpVip = true;
						this.mWebView.LoadUrl(text);
					}
					break;
				}
			}
		}

		// Token: 0x0600F1D6 RID: 61910 RVA: 0x004135D0 File Offset: 0x004119D0
		private void OnServerFuncSwitch(ServerSceneFuncSwitch fSwitch)
		{
			if (fSwitch.sType != ServiceType.SERVICE_VIP_AUTH)
			{
				return;
			}
			this.isVipAuthFuncLock = !fSwitch.sIsOpen;
		}

		// Token: 0x04009487 RID: 38023
		private const int CanvasLayerIndex = 5;

		// Token: 0x04009488 RID: 38024
		private bool beJumpVip;

		// Token: 0x04009489 RID: 38025
		private bool isVipAuthFuncLock;

		// Token: 0x0400948A RID: 38026
		private Button mBtnRefresh;

		// Token: 0x0400948B RID: 38027
		private Button mBtnGoback;

		// Token: 0x0400948C RID: 38028
		private Button mBtnClose;

		// Token: 0x0400948D RID: 38029
		private UniWebViewUtility mWebView;

		// Token: 0x0400948E RID: 38030
		private GameObject mVipEntrance;

		// Token: 0x0400948F RID: 38031
		private DOTweenAnimation mVipEntranceTween;

		// Token: 0x04009490 RID: 38032
		private Button mSpecialServiceBtn;

		// Token: 0x04009491 RID: 38033
		private Text mSpecialServiceText;

		// Token: 0x04009492 RID: 38034
		private Text mVipDescText;

		// Token: 0x04009493 RID: 38035
		private Button mReturnNormal;

		// Token: 0x04009494 RID: 38036
		private Text mText;

		// Token: 0x04009495 RID: 38037
		public static bool keyboardShowOut;

		// Token: 0x04009496 RID: 38038
		private float mTickTime;

		// Token: 0x04009497 RID: 38039
		private bool canUpdate = true;

		// Token: 0x04009498 RID: 38040
		private bool dirty;
	}
}
