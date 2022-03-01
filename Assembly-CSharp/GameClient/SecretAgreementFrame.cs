using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001171 RID: 4465
	public class SecretAgreementFrame : ClientFrame
	{
		// Token: 0x0600AAB8 RID: 43704 RVA: 0x00247B4E File Offset: 0x00245F4E
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Login/Publish/SecretAgreementFrame";
		}

		// Token: 0x0600AAB9 RID: 43705 RVA: 0x00247B58 File Offset: 0x00245F58
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.frameData = (UserAgreementFrameData)this.userData;
			}
			this.mClose.gameObject.CustomActive(this.frameData.frameType == UserAgreementFrameType.LookInfo);
			this.mBtReject.gameObject.CustomActive(this.frameData.frameType == UserAgreementFrameType.FirstOpen);
			this.mBtAccept.gameObject.CustomActive(this.frameData.frameType == UserAgreementFrameType.FirstOpen);
			this._StopContentCoroutine();
			this._StopSelectCoroutine();
			this.mCo = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._wt());
		}

		// Token: 0x0600AABA RID: 43706 RVA: 0x00247BFD File Offset: 0x00245FFD
		protected override void _OnCloseFrame()
		{
			this._StopContentCoroutine();
			this._StopSelectCoroutine();
		}

		// Token: 0x0600AABB RID: 43707 RVA: 0x00247C0C File Offset: 0x0024600C
		private IEnumerator _wt()
		{
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			wt.url = string.Format("http://{0}/secret_txt", Global.USER_AGREEMENT_SERVER_ADDRESS);
			yield return wt;
			this.mText.text = wt.GetResultString();
			this.mScroll.verticalNormalizedPosition = 1f;
			yield break;
		}

		// Token: 0x0600AABC RID: 43708 RVA: 0x00247C28 File Offset: 0x00246028
		private IEnumerator _sel()
		{
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			wt.url = string.Format("http://{0}/agreement_agree?pf={1}&id={2}", Global.USER_AGREEMENT_SERVER_ADDRESS, this.frameData.PlatFormType, this.frameData.OpenUid);
			if (this.frameData.PlatFormType == string.Empty || this.frameData.OpenUid == string.Empty)
			{
				Logger.LogErrorFormat("Agree [User Agreement] url = {0}", new object[]
				{
					wt.url
				});
			}
			yield return wt;
			if (wt.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				this.frameMgr.CloseFrame<SecretAgreementFrame>(this, false);
			}
			yield break;
		}

		// Token: 0x0600AABD RID: 43709 RVA: 0x00247C43 File Offset: 0x00246043
		private void _StopContentCoroutine()
		{
			if (this.mCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCo);
			}
			this.mCo = null;
		}

		// Token: 0x0600AABE RID: 43710 RVA: 0x00247C67 File Offset: 0x00246067
		private void _StopSelectCoroutine()
		{
			if (this.mSel != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mSel);
			}
			this.mSel = null;
		}

		// Token: 0x0600AABF RID: 43711 RVA: 0x00247C8C File Offset: 0x0024608C
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mText = this.mBind.GetCom<Text>("text");
			this.mScroll = this.mBind.GetCom<ScrollRect>("scroll");
			this.mBtReject = this.mBind.GetCom<Button>("btReject");
			this.mBtReject.onClick.AddListener(new UnityAction(this._onBtRejectButtonClick));
			this.mBtAccept = this.mBind.GetCom<Button>("btAccept");
			this.mBtAccept.onClick.AddListener(new UnityAction(this._onBtAcceptButtonClick));
		}

		// Token: 0x0600AAC0 RID: 43712 RVA: 0x00247D5C File Offset: 0x0024615C
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mText = null;
			this.mScroll = null;
			this.mBtReject.onClick.RemoveListener(new UnityAction(this._onBtRejectButtonClick));
			this.mBtReject = null;
			this.mBtAccept.onClick.RemoveListener(new UnityAction(this._onBtAcceptButtonClick));
			this.mBtAccept = null;
		}

		// Token: 0x0600AAC1 RID: 43713 RVA: 0x00247DE0 File Offset: 0x002461E0
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<SecretAgreementFrame>(this, false);
		}

		// Token: 0x0600AAC2 RID: 43714 RVA: 0x00247DEF File Offset: 0x002461EF
		private void _onBtRejectButtonClick()
		{
			Application.Quit();
		}

		// Token: 0x0600AAC3 RID: 43715 RVA: 0x00247DF6 File Offset: 0x002461F6
		private void _onBtAcceptButtonClick()
		{
			this._StopSelectCoroutine();
			this.mSel = MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._sel());
		}

		// Token: 0x04005FB2 RID: 24498
		private UserAgreementFrameData frameData = default(UserAgreementFrameData);

		// Token: 0x04005FB3 RID: 24499
		private Coroutine mCo;

		// Token: 0x04005FB4 RID: 24500
		private Coroutine mSel;

		// Token: 0x04005FB5 RID: 24501
		private Button mClose;

		// Token: 0x04005FB6 RID: 24502
		private Text mText;

		// Token: 0x04005FB7 RID: 24503
		private ScrollRect mScroll;

		// Token: 0x04005FB8 RID: 24504
		private Button mBtReject;

		// Token: 0x04005FB9 RID: 24505
		private Button mBtAccept;
	}
}
