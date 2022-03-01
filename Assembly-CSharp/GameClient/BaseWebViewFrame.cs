using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017F3 RID: 6131
	public class BaseWebViewFrame : ClientFrame
	{
		// Token: 0x0600F1A6 RID: 61862 RVA: 0x0041279B File Offset: 0x00410B9B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/BaseWebView/BaseWebViewFrame";
		}

		// Token: 0x0600F1A7 RID: 61863 RVA: 0x004127A2 File Offset: 0x00410BA2
		protected override void _OnOpenFrame()
		{
			this._BindUIEvent();
			this._InitFrameView();
		}

		// Token: 0x0600F1A8 RID: 61864 RVA: 0x004127B0 File Offset: 0x00410BB0
		protected override void _OnCloseFrame()
		{
			this._UnInitFrameView();
			this._UnBindUIEvent();
		}

		// Token: 0x0600F1A9 RID: 61865 RVA: 0x004127BE File Offset: 0x00410BBE
		public override bool IsNeedUpdate()
		{
			return this.needUpdate;
		}

		// Token: 0x0600F1AA RID: 61866 RVA: 0x004127C8 File Offset: 0x00410BC8
		protected override void _OnUpdate(float timeElapsed)
		{
			this.mTickTime += timeElapsed;
			if (this.mTickTime > 1f)
			{
				if (null != this.mWebView)
				{
					this.mWebView.OnUpdate(timeElapsed);
				}
				this.mTickTime = 0f;
			}
		}

		// Token: 0x0600F1AB RID: 61867 RVA: 0x0041281B File Offset: 0x00410C1B
		private void _BindUIEvent()
		{
		}

		// Token: 0x0600F1AC RID: 61868 RVA: 0x0041281D File Offset: 0x00410C1D
		private void _UnBindUIEvent()
		{
		}

		// Token: 0x0600F1AD RID: 61869 RVA: 0x00412820 File Offset: 0x00410C20
		private void _InitFrameView()
		{
			if (this.userData != null)
			{
				this.param = (this.userData as BaseWebViewParams);
			}
			if (this.param == null)
			{
				return;
			}
			BaseWebViewType type = this.param.type;
			if (this.mComTitle != null)
			{
				this.mComTitle.SetTitleByType(type);
			}
			string fullUrl = this.param.fullUrl;
			if (!string.IsNullOrEmpty(fullUrl) && this.mWebView != null)
			{
				UniWebViewUtility uniWebViewUtility = this.mWebView;
				uniWebViewUtility.PageViewUpdate = (UniWebViewUtility.OnPageViewUpdate)Delegate.Combine(uniWebViewUtility.PageViewUpdate, new UniWebViewUtility.OnPageViewUpdate(this.OnWebViewUpdate));
				UniWebViewUtility uniWebViewUtility2 = this.mWebView;
				uniWebViewUtility2.PageLoadReveiveMsg = (UniWebViewUtility.OnPageLoadReceiveMsg)Delegate.Combine(uniWebViewUtility2.PageLoadReveiveMsg, new UniWebViewUtility.OnPageLoadReceiveMsg(this.OnPageReceiveMsg));
				this.mWebView.InitWebView(false);
				if (DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsServiceTypeSwitchOpen(ServiceType.SERVICE_INEER_WEBVIEW))
				{
					this.mWebView.LoadUrl(fullUrl);
				}
				else
				{
					Application.OpenURL(fullUrl);
				}
				this.mWebView.ShowWebView();
			}
			this.needUpdate = this.param.needFrameUpdate;
			this.mBtnGoback.CustomActive(this.param.needGobackBtn);
			this.mBtnRefresh.CustomActive(this.param.needRefreshBtn);
		}

		// Token: 0x0600F1AE RID: 61870 RVA: 0x00412970 File Offset: 0x00410D70
		private void _UnInitFrameView()
		{
			if (this.mWebView != null)
			{
				UniWebViewUtility uniWebViewUtility = this.mWebView;
				uniWebViewUtility.PageViewUpdate = (UniWebViewUtility.OnPageViewUpdate)Delegate.Remove(uniWebViewUtility.PageViewUpdate, new UniWebViewUtility.OnPageViewUpdate(this.OnWebViewUpdate));
				UniWebViewUtility uniWebViewUtility2 = this.mWebView;
				uniWebViewUtility2.PageLoadReveiveMsg = (UniWebViewUtility.OnPageLoadReceiveMsg)Delegate.Remove(uniWebViewUtility2.PageLoadReveiveMsg, new UniWebViewUtility.OnPageLoadReceiveMsg(this.OnPageReceiveMsg));
				this.mWebView.UnInitWebView();
			}
			this.mTickTime = 0f;
			if (this.param != null)
			{
				this.param.Clear();
				this.param = null;
			}
		}

		// Token: 0x0600F1AF RID: 61871 RVA: 0x00412A0F File Offset: 0x00410E0F
		private void OnWebViewUpdate()
		{
		}

		// Token: 0x0600F1B0 RID: 61872 RVA: 0x00412A14 File Offset: 0x00410E14
		private void OnPageReceiveMsg(UniWebViewMessage message)
		{
			if (this.mWebView == null)
			{
				return;
			}
			if (message.Equals(null))
			{
				return;
			}
			if (string.IsNullOrEmpty(message.Path))
			{
				return;
			}
			int num = 0;
			while (this.param != null && this.param.uniWebViewMsgs != null && num < this.param.uniWebViewMsgs.Count)
			{
				BaseWebViewMsg baseWebViewMsg = this.param.uniWebViewMsgs[num];
				if (baseWebViewMsg.scheme == message.Scheme && baseWebViewMsg.path == message.Path && baseWebViewMsg.onReceiveWebViewMsg != null)
				{
					baseWebViewMsg.onReceiveWebViewMsg(message.Args, this.mWebView);
				}
				num++;
			}
		}

		// Token: 0x0600F1B1 RID: 61873 RVA: 0x00412AFC File Offset: 0x00410EFC
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
			this.mComTitle = this.mBind.GetCom<ComBaseWebViewTitle>("ComTitle");
			this.mWebView = this.mBind.GetCom<UniWebViewUtility>("WebView");
		}

		// Token: 0x0600F1B2 RID: 61874 RVA: 0x00412C00 File Offset: 0x00411000
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
			this.mComTitle = null;
			this.mWebView = null;
		}

		// Token: 0x0600F1B3 RID: 61875 RVA: 0x00412CB7 File Offset: 0x004110B7
		private void _onBtnRefreshButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.ReLoadUrl();
			}
		}

		// Token: 0x0600F1B4 RID: 61876 RVA: 0x00412CD4 File Offset: 0x004110D4
		private void _onBtnGobackButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.GoBackWebView();
			}
		}

		// Token: 0x0600F1B5 RID: 61877 RVA: 0x00412CF1 File Offset: 0x004110F1
		private void _onBtnCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0400947B RID: 38011
		private BaseWebViewParams param;

		// Token: 0x0400947C RID: 38012
		private float mTickTime;

		// Token: 0x0400947D RID: 38013
		private bool needUpdate = true;

		// Token: 0x0400947E RID: 38014
		private Button mBtnRefresh;

		// Token: 0x0400947F RID: 38015
		private Button mBtnGoback;

		// Token: 0x04009480 RID: 38016
		private Button mBtnClose;

		// Token: 0x04009481 RID: 38017
		private ComBaseWebViewTitle mComTitle;

		// Token: 0x04009482 RID: 38018
		private UniWebViewUtility mWebView;
	}
}
