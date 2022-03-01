using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200159C RID: 5532
	public class ControlSelectFrame : ClientFrame
	{
		// Token: 0x0600D86C RID: 55404 RVA: 0x003625E0 File Offset: 0x003609E0
		protected override void _bindExUI()
		{
			this.mSelect1 = this.mBind.GetCom<Toggle>("select1");
			this.mSelect1.onValueChanged.AddListener(new UnityAction<bool>(this._onSelect1ToggleValueChange));
			this.mSelect2 = this.mBind.GetCom<Toggle>("select2");
			this.mSelect2.onValueChanged.AddListener(new UnityAction<bool>(this._onSelect2ToggleValueChange));
			this.mMovieCtrl1 = this.mBind.GetCom<MediaPlayerCtrl>("movieCtrl1");
			this.mMovieCtrl2 = this.mBind.GetCom<MediaPlayerCtrl>("MovieCtrl2");
			this.mBtnOK = this.mBind.GetCom<Button>("btnOK");
			this.mBtnOK.onClick.AddListener(new UnityAction(this._onBtnOKButtonClick));
		}

		// Token: 0x0600D86D RID: 55405 RVA: 0x003626B0 File Offset: 0x00360AB0
		protected override void _unbindExUI()
		{
			this.mSelect1.onValueChanged.RemoveListener(new UnityAction<bool>(this._onSelect1ToggleValueChange));
			this.mSelect1 = null;
			this.mSelect2.onValueChanged.RemoveListener(new UnityAction<bool>(this._onSelect2ToggleValueChange));
			this.mSelect2 = null;
			this.mMovieCtrl1 = null;
			this.mMovieCtrl2 = null;
		}

		// Token: 0x0600D86E RID: 55406 RVA: 0x00362714 File Offset: 0x00360B14
		private void _onSelect1ToggleValueChange(bool changed)
		{
			if (!changed)
			{
				return;
			}
			this.leftPlay = true;
			if (this.mMovieCtrl2.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl2.Stop();
			}
			if (this.mMovieCtrl2.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl1.Stop();
				this.mMovieCtrl1.Play();
			}
		}

		// Token: 0x0600D86F RID: 55407 RVA: 0x00362770 File Offset: 0x00360B70
		private void _onSelect2ToggleValueChange(bool changed)
		{
			if (!changed)
			{
				return;
			}
			this.leftPlay = false;
			if (this.mMovieCtrl2.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl2.Stop();
				this.mMovieCtrl2.Play();
			}
			if (this.mMovieCtrl1.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl1.Stop();
			}
		}

		// Token: 0x0600D870 RID: 55408 RVA: 0x003627CC File Offset: 0x00360BCC
		private void _onBtnOKButtonClick()
		{
			this.CloseVideo(this.mMovieCtrl1);
			this.CloseVideo(this.mMovieCtrl2);
			bool isOn = this.mSelect2.isOn;
			PlayerLocalSetting.SetValue("KEY_DOUBLE", isOn);
			Global.Settings.hasDoubleRun = isOn;
			base.Close(true);
		}

		// Token: 0x0600D871 RID: 55409 RVA: 0x0036281F File Offset: 0x00360C1F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/NewbieGuide/ControlSelectFrame";
		}

		// Token: 0x0600D872 RID: 55410 RVA: 0x00362828 File Offset: 0x00360C28
		protected override void _OnOpenFrame()
		{
			bool flag = false;
			if (PlayerLocalSetting.GetValue("KEY_DOUBLE") != null)
			{
				flag = (bool)PlayerLocalSetting.GetValue("KEY_DOUBLE");
			}
			if (flag)
			{
				this.mSelect2.isOn = true;
				this.leftPlay = false;
			}
			else
			{
				this.mSelect1.isOn = true;
			}
			this.InitVideo(this.mMovieCtrl1, true);
			this.InitVideo(this.mMovieCtrl2, false);
		}

		// Token: 0x0600D873 RID: 55411 RVA: 0x0036289C File Offset: 0x00360C9C
		public void InitVideo(MediaPlayerCtrl mpc, bool isLeft)
		{
			if (mpc != null)
			{
				RawImage rowImage = mpc.m_TargetMaterial[0].GetComponent<RawImage>();
				if (rowImage != null)
				{
					rowImage.enabled = false;
				}
				MediaPlayerCtrl mpc2 = mpc;
				mpc2.OnReady = (MediaPlayerCtrl.VideoReady)Delegate.Combine(mpc2.OnReady, new MediaPlayerCtrl.VideoReady(delegate()
				{
					rowImage.enabled = true;
					if ((this.leftPlay && isLeft) || (!this.leftPlay && !isLeft))
					{
						mpc.Play();
					}
					else
					{
						mpc.Play();
						Singleton<ClientSystemManager>.instance.delayCaller.DelayCall(10, delegate
						{
							mpc.Pause();
						}, 0, 0, false);
					}
				}));
			}
		}

		// Token: 0x0600D874 RID: 55412 RVA: 0x0036293E File Offset: 0x00360D3E
		public void CloseVideo(MediaPlayerCtrl mpc)
		{
			if (mpc != null && mpc.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				mpc.Stop();
				mpc.UnLoad();
			}
		}

		// Token: 0x04007F11 RID: 32529
		private bool leftPlay = true;

		// Token: 0x04007F12 RID: 32530
		private Toggle mSelect1;

		// Token: 0x04007F13 RID: 32531
		private Toggle mSelect2;

		// Token: 0x04007F14 RID: 32532
		private MediaPlayerCtrl mMovieCtrl1;

		// Token: 0x04007F15 RID: 32533
		private MediaPlayerCtrl mMovieCtrl2;

		// Token: 0x04007F16 RID: 32534
		private Button mBtnOK;
	}
}
