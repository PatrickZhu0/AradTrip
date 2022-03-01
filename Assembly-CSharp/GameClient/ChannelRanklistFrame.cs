using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200151E RID: 5406
	internal class ChannelRanklistFrame : ClientFrame
	{
		// Token: 0x0600D21C RID: 53788 RVA: 0x0033E710 File Offset: 0x0033CB10
		protected override void _bindExUI()
		{
			this.mBtnRefresh = this.mBind.GetCom<Button>("BtnRefresh");
			this.mBtnRefresh.onClick.AddListener(new UnityAction(this._onBtnRefreshButtonClick));
			this.mBtnRefresh.gameObject.CustomActive(false);
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mWebView = this.mBind.GetCom<UniWebViewUtility>("WebView");
		}

		// Token: 0x0600D21D RID: 53789 RVA: 0x0033E7A8 File Offset: 0x0033CBA8
		protected override void _unbindExUI()
		{
			this.mBtnRefresh.onClick.RemoveListener(new UnityAction(this._onBtnRefreshButtonClick));
			this.mBtnRefresh = null;
			this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mBtnClose = null;
			this.mWebView = null;
		}

		// Token: 0x0600D21E RID: 53790 RVA: 0x0033E802 File Offset: 0x0033CC02
		private void _onBtnRefreshButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.ReLoadUrl();
			}
		}

		// Token: 0x0600D21F RID: 53791 RVA: 0x0033E81F File Offset: 0x0033CC1F
		private void _onBtnCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600D220 RID: 53792 RVA: 0x0033E828 File Offset: 0x0033CC28
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Ranklist/ChannelRanklist";
		}

		// Token: 0x0600D221 RID: 53793 RVA: 0x0033E830 File Offset: 0x0033CC30
		protected override void _OnOpenFrame()
		{
			string text = string.Empty;
			if (this.userData != null)
			{
				text = (this.userData as string);
			}
			if (this.mWebView != null && !string.IsNullOrEmpty(text))
			{
				this.mWebView.InitWebView(false);
				this.mWebView.LoadUrl(text);
				this.mWebView.ShowWebView();
			}
		}

		// Token: 0x0600D222 RID: 53794 RVA: 0x0033E899 File Offset: 0x0033CC99
		protected override void _OnCloseFrame()
		{
			if (this.mWebView != null)
			{
				this.mWebView.UnInitWebView();
			}
		}

		// Token: 0x04007B0C RID: 31500
		public const int CanvasLayerIndex = 5;

		// Token: 0x04007B0D RID: 31501
		private Button mBtnRefresh;

		// Token: 0x04007B0E RID: 31502
		private Button mBtnClose;

		// Token: 0x04007B0F RID: 31503
		private UniWebViewUtility mWebView;
	}
}
