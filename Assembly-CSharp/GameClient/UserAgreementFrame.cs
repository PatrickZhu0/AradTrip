using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200117A RID: 4474
	public class UserAgreementFrame : ClientFrame
	{
		// Token: 0x0600AB12 RID: 43794 RVA: 0x0024AA5A File Offset: 0x00248E5A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Login/Publish/UserAgreementFrame";
		}

		// Token: 0x0600AB13 RID: 43795 RVA: 0x0024AA64 File Offset: 0x00248E64
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

		// Token: 0x0600AB14 RID: 43796 RVA: 0x0024AB09 File Offset: 0x00248F09
		protected override void _OnCloseFrame()
		{
			this._StopContentCoroutine();
			this._StopSelectCoroutine();
		}

		// Token: 0x0600AB15 RID: 43797 RVA: 0x0024AB18 File Offset: 0x00248F18
		private IEnumerator _wt()
		{
			BaseWaitHttpRequest wt = new BaseWaitHttpRequest();
			wt.url = string.Format("http://{0}/agreement_txt", Global.USER_AGREEMENT_SERVER_ADDRESS);
			yield return wt;
			this.mText.text = wt.GetResultString();
			this.mScroll.verticalNormalizedPosition = 1f;
			yield break;
		}

		// Token: 0x0600AB16 RID: 43798 RVA: 0x0024AB34 File Offset: 0x00248F34
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
				this.frameMgr.CloseFrame<UserAgreementFrame>(this, false);
			}
			yield break;
		}

		// Token: 0x0600AB17 RID: 43799 RVA: 0x0024AB4F File Offset: 0x00248F4F
		private void _StopContentCoroutine()
		{
			if (this.mCo != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mCo);
			}
			this.mCo = null;
		}

		// Token: 0x0600AB18 RID: 43800 RVA: 0x0024AB73 File Offset: 0x00248F73
		private void _StopSelectCoroutine()
		{
			if (this.mSel != null)
			{
				MonoSingleton<GameFrameWork>.instance.StopCoroutine(this.mSel);
			}
			this.mSel = null;
		}

		// Token: 0x0600AB19 RID: 43801 RVA: 0x0024AB98 File Offset: 0x00248F98
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

		// Token: 0x0600AB1A RID: 43802 RVA: 0x0024AC68 File Offset: 0x00249068
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

		// Token: 0x0600AB1B RID: 43803 RVA: 0x0024ACEC File Offset: 0x002490EC
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<UserAgreementFrame>(this, false);
		}

		// Token: 0x0600AB1C RID: 43804 RVA: 0x0024ACFB File Offset: 0x002490FB
		private void _onBtRejectButtonClick()
		{
			Application.Quit();
		}

		// Token: 0x0600AB1D RID: 43805 RVA: 0x0024AD04 File Offset: 0x00249104
		private void _onBtAcceptButtonClick()
		{
			this._StopSelectCoroutine();
			UserAgreementFrameData userAgreementFrameData = default(UserAgreementFrameData);
			userAgreementFrameData.frameType = UserAgreementFrameType.FirstOpen;
			userAgreementFrameData.PlatFormType = SDKInterface.instance.GetPlatformNameBySelect();
			userAgreementFrameData.OpenUid = ClientApplication.playerinfo.openuid;
			Singleton<ClientSystemManager>.instance.OpenFrame<SecretAgreementFrame>(FrameLayer.Middle, userAgreementFrameData, string.Empty);
			this.frameMgr.CloseFrame<UserAgreementFrame>(this, false);
		}

		// Token: 0x04005FE8 RID: 24552
		private UserAgreementFrameData frameData = default(UserAgreementFrameData);

		// Token: 0x04005FE9 RID: 24553
		private Coroutine mCo;

		// Token: 0x04005FEA RID: 24554
		private Coroutine mSel;

		// Token: 0x04005FEB RID: 24555
		private Button mClose;

		// Token: 0x04005FEC RID: 24556
		private Text mText;

		// Token: 0x04005FED RID: 24557
		private ScrollRect mScroll;

		// Token: 0x04005FEE RID: 24558
		private Button mBtReject;

		// Token: 0x04005FEF RID: 24559
		private Button mBtAccept;
	}
}
