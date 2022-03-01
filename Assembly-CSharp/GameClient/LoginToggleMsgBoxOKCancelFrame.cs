using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E2B RID: 3627
	public class LoginToggleMsgBoxOKCancelFrame : ClientFrame
	{
		// Token: 0x0600910A RID: 37130 RVA: 0x001AD6D4 File Offset: 0x001ABAD4
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/LoginToggleMsgBoxOKCancel";
		}

		// Token: 0x0600910B RID: 37131 RVA: 0x001AD6DB File Offset: 0x001ABADB
		protected override void _OnOpenFrame()
		{
			this.loginToggleMsgBoxParama = (this.userData as LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgBoxParama);
			this.UpdateUI();
		}

		// Token: 0x0600910C RID: 37132 RVA: 0x001AD6F4 File Offset: 0x001ABAF4
		protected override void _OnCloseFrame()
		{
			this.loginToggleMsgBoxParama = null;
		}

		// Token: 0x0600910D RID: 37133 RVA: 0x001AD700 File Offset: 0x001ABB00
		protected override void _bindExUI()
		{
			this.mMsgText = this.mBind.GetCom<Text>("msgText");
			this.mNotifyToggleRoot = this.mBind.GetGameObject("notifyToggleRoot");
			this.mBtCancel = this.mBind.GetCom<Button>("btCancel");
			this.mBtCancel.SafeSetOnClickListener(delegate
			{
				if (this.loginToggleMsgBoxParama != null && this.loginToggleMsgBoxParama.cancelAction != null)
				{
					this.loginToggleMsgBoxParama.cancelAction.Invoke();
				}
				this.frameMgr.CloseFrame<LoginToggleMsgBoxOKCancelFrame>(this, false);
			});
			this.mBtOK = this.mBind.GetCom<Button>("btOK");
			this.mBtOK.SafeSetOnClickListener(delegate
			{
				if (this.loginToggleMsgBoxParama != null && this.loginToggleMsgBoxParama.okAction != null)
				{
					this.loginToggleMsgBoxParama.okAction.Invoke();
				}
				this.frameMgr.CloseFrame<LoginToggleMsgBoxOKCancelFrame>(this, false);
			});
			this.mCancleButtonText = this.mBind.GetCom<Text>("cancleButtonText");
			this.mOkButtonText = this.mBind.GetCom<Text>("okButtonText");
			this.mNotifyToggle = this.mBind.GetCom<Toggle>("notifyToggle");
			this.mNotifyToggle.SafeSetOnValueChangedListener(delegate(bool value)
			{
				if (this.loginToggleMsgBoxParama != null && LoginToggleMsgBoxOKCancelFrame.toggleStates != null)
				{
					LoginToggleMsgBoxOKCancelFrame.toggleStates.SafeAdd(this.loginToggleMsgBoxParama.loginToggleMsgType, value);
				}
			});
		}

		// Token: 0x0600910E RID: 37134 RVA: 0x001AD7EC File Offset: 0x001ABBEC
		protected override void _unbindExUI()
		{
			this.mMsgText = null;
			this.mNotifyToggleRoot = null;
			this.mBtCancel = null;
			this.mBtOK = null;
			this.mCancleButtonText = null;
			this.mOkButtonText = null;
			this.mNotifyToggle = null;
		}

		// Token: 0x0600910F RID: 37135 RVA: 0x001AD81F File Offset: 0x001ABC1F
		private void BindUIEvent()
		{
		}

		// Token: 0x06009110 RID: 37136 RVA: 0x001AD821 File Offset: 0x001ABC21
		private void UnBindUIEvent()
		{
		}

		// Token: 0x06009111 RID: 37137 RVA: 0x001AD824 File Offset: 0x001ABC24
		public static void TryShowMsgBox(LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType loginToggleMsgType, string msgContent, UnityAction okAction = null, UnityAction cancelAction = null, string okContent = "", string cancelContent = "")
		{
			LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgBoxParama loginToggleMsgBoxParama = new LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgBoxParama
			{
				loginToggleMsgType = loginToggleMsgType,
				msgContent = msgContent,
				okContent = okContent,
				cancelContent = cancelContent,
				okAction = okAction,
				cancelAction = cancelAction
			};
			if (loginToggleMsgBoxParama == null)
			{
				return;
			}
			if (LoginToggleMsgBoxOKCancelFrame.toggleStates.SafeGetValue(loginToggleMsgBoxParama.loginToggleMsgType))
			{
				if (okAction != null)
				{
					okAction.Invoke();
				}
				return;
			}
			ClientSystemManager instance = Singleton<ClientSystemManager>.GetInstance();
			FrameLayer layer = FrameLayer.Middle;
			object userData = loginToggleMsgBoxParama;
			string format = "LoginToggleMsgBoxOKCancelFrame";
			ulong num = LoginToggleMsgBoxOKCancelFrame.frameID;
			LoginToggleMsgBoxOKCancelFrame.frameID = num + 1UL;
			instance.OpenFrame<LoginToggleMsgBoxOKCancelFrame>(layer, userData, string.Format(format, num));
		}

		// Token: 0x06009112 RID: 37138 RVA: 0x001AD8B8 File Offset: 0x001ABCB8
		public static void Reset()
		{
			if (LoginToggleMsgBoxOKCancelFrame.toggleStates != null)
			{
				LoginToggleMsgBoxOKCancelFrame.toggleStates.Clear();
			}
			LoginToggleMsgBoxOKCancelFrame.frameID = 0UL;
		}

		// Token: 0x06009113 RID: 37139 RVA: 0x001AD8D8 File Offset: 0x001ABCD8
		private void UpdateUI()
		{
			if (this.loginToggleMsgBoxParama == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.loginToggleMsgBoxParama.msgContent))
			{
				this.mMsgText.SafeSetText(TR.Value("LoginToggleMsgBoxOKCancelFrame_defatul_msg_content"));
			}
			else
			{
				this.mMsgText.SafeSetText(this.loginToggleMsgBoxParama.msgContent);
			}
			if (string.IsNullOrEmpty(this.loginToggleMsgBoxParama.cancelContent))
			{
				this.mCancleButtonText.SafeSetText(TR.Value("LoginToggleMsgBoxOKCancelFrame_defatul_cancel_content"));
			}
			else
			{
				this.mCancleButtonText.SafeSetText(this.loginToggleMsgBoxParama.cancelContent);
			}
			if (string.IsNullOrEmpty(this.loginToggleMsgBoxParama.okContent))
			{
				this.mOkButtonText.SafeSetText(TR.Value("LoginToggleMsgBoxOKCancelFrame_defatul_ok_content"));
			}
			else
			{
				this.mOkButtonText.SafeSetText(this.loginToggleMsgBoxParama.okContent);
			}
		}

		// Token: 0x04004850 RID: 18512
		private static Dictionary<LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType, bool> toggleStates = new Dictionary<LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType, bool>();

		// Token: 0x04004851 RID: 18513
		private static ulong frameID = 0UL;

		// Token: 0x04004852 RID: 18514
		private LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgBoxParama loginToggleMsgBoxParama;

		// Token: 0x04004853 RID: 18515
		private Text mMsgText;

		// Token: 0x04004854 RID: 18516
		private GameObject mNotifyToggleRoot;

		// Token: 0x04004855 RID: 18517
		private Button mBtCancel;

		// Token: 0x04004856 RID: 18518
		private Button mBtOK;

		// Token: 0x04004857 RID: 18519
		private Text mCancleButtonText;

		// Token: 0x04004858 RID: 18520
		private Text mOkButtonText;

		// Token: 0x04004859 RID: 18521
		private Toggle mNotifyToggle;

		// Token: 0x02000E2C RID: 3628
		public enum LoginToggleMsgType
		{
			// Token: 0x0400485B RID: 18523
			Invalid,
			// Token: 0x0400485C RID: 18524
			NotCostFatigue,
			// Token: 0x0400485D RID: 18525
			EnterEliteDungeonTip,
			// Token: 0x0400485E RID: 18526
			AdventurerPassCardBuyLevel,
			// Token: 0x0400485F RID: 18527
			EnterDungeonBuyDrug
		}

		// Token: 0x02000E2D RID: 3629
		public class LoginToggleMsgBoxParama
		{
			// Token: 0x04004860 RID: 18528
			public LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType loginToggleMsgType;

			// Token: 0x04004861 RID: 18529
			public string msgContent = string.Empty;

			// Token: 0x04004862 RID: 18530
			public string okContent = string.Empty;

			// Token: 0x04004863 RID: 18531
			public string cancelContent = string.Empty;

			// Token: 0x04004864 RID: 18532
			public UnityAction okAction;

			// Token: 0x04004865 RID: 18533
			public UnityAction cancelAction;
		}
	}
}
