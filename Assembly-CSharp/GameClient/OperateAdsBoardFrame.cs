using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200191C RID: 6428
	internal class OperateAdsBoardFrame : ClientFrame
	{
		// Token: 0x0600FA36 RID: 64054 RVA: 0x00447F54 File Offset: 0x00446354
		protected override void _bindExUI()
		{
			this.mBtnRefresh = this.mBind.GetCom<Button>("BtnRefresh");
			this.mBtnRefresh.onClick.AddListener(new UnityAction(this._onBtnRefreshButtonClick));
			this.mBtnRefresh.gameObject.CustomActive(false);
			this.mBtnClose = this.mBind.GetCom<Button>("BtnClose");
			this.mBtnClose.onClick.AddListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mWebView = this.mBind.GetCom<UniWebViewUtility>("WebView");
			this.titleName = this.mBind.GetCom<Text>("Title");
			this.mBtnGoback = this.mBind.GetCom<Button>("BtnGoback");
			this.mBtnGoback.onClick.AddListener(new UnityAction(this._onBtnGobackButtonClick));
		}

		// Token: 0x0600FA37 RID: 64055 RVA: 0x00448034 File Offset: 0x00446434
		protected override void _unbindExUI()
		{
			this.mBtnRefresh.onClick.RemoveListener(new UnityAction(this._onBtnRefreshButtonClick));
			this.mBtnRefresh = null;
			this.mBtnClose.onClick.RemoveListener(new UnityAction(this._onBtnCloseButtonClick));
			this.mBtnClose = null;
			this.mWebView = null;
			this.titleName = null;
			this.mBtnGoback.onClick.RemoveListener(new UnityAction(this._onBtnGobackButtonClick));
			this.mBtnGoback = null;
		}

		// Token: 0x0600FA38 RID: 64056 RVA: 0x004480B8 File Offset: 0x004464B8
		private void _onBtnRefreshButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.ReLoadUrl();
			}
		}

		// Token: 0x0600FA39 RID: 64057 RVA: 0x004480D5 File Offset: 0x004464D5
		private void _onBtnCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600FA3A RID: 64058 RVA: 0x004480DE File Offset: 0x004464DE
		private void _onBtnGobackButtonClick()
		{
			if (this.mWebView)
			{
				this.mWebView.GoBackWebView();
			}
		}

		// Token: 0x0600FA3B RID: 64059 RVA: 0x004480FB File Offset: 0x004464FB
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/OperateActivity/OperationAds/OperationAdsBoard";
		}

		// Token: 0x0600FA3C RID: 64060 RVA: 0x00448104 File Offset: 0x00446504
		protected override void _OnOpenFrame()
		{
			string text = string.Empty;
			if (this.userData != null)
			{
				text = (this.userData as string);
			}
			if (!string.IsNullOrEmpty(this.mFrameName) && this.titleName)
			{
				this.titleName.text = this.mFrameName;
			}
			if (this.mBtnGoback)
			{
				this.mBtnGoback.gameObject.CustomActive(false);
			}
			if (this.mWebView != null && !string.IsNullOrEmpty(text))
			{
				this.mWebView.InitWebView(false);
				this.mWebView.LoadUrl(text);
				this.mWebView.ShowWebView();
			}
		}

		// Token: 0x0600FA3D RID: 64061 RVA: 0x004481BF File Offset: 0x004465BF
		protected override void _OnCloseFrame()
		{
			if (this.mWebView != null)
			{
				this.mWebView.UnInitWebView();
			}
		}

		// Token: 0x0600FA3E RID: 64062 RVA: 0x004481DD File Offset: 0x004465DD
		protected override void _OnUpdate(float timeElapsed)
		{
			this.mTickTime += timeElapsed;
			if (this.mTickTime > 3f)
			{
				this.OnGoBackBtnShow();
				this.mTickTime = 0f;
			}
		}

		// Token: 0x0600FA3F RID: 64063 RVA: 0x0044820E File Offset: 0x0044660E
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600FA40 RID: 64064 RVA: 0x00448214 File Offset: 0x00446614
		private void OnGoBackBtnShow()
		{
			if (this.mWebView)
			{
				bool bActive = this.mWebView.CanWebViewGoBack();
				if (this.mBtnGoback)
				{
					this.mBtnGoback.gameObject.CustomActive(bActive);
				}
			}
		}

		// Token: 0x04009C3B RID: 39995
		private float mTickTime;

		// Token: 0x04009C3C RID: 39996
		private Button mBtnRefresh;

		// Token: 0x04009C3D RID: 39997
		private Button mBtnClose;

		// Token: 0x04009C3E RID: 39998
		private UniWebViewUtility mWebView;

		// Token: 0x04009C3F RID: 39999
		private Text titleName;

		// Token: 0x04009C40 RID: 40000
		private Button mBtnGoback;
	}
}
