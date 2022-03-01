using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020013B8 RID: 5048
	public class UltimateChallengeRefreshBufMsgBoxFrame : ClientFrame
	{
		// Token: 0x0600C3F3 RID: 50163 RVA: 0x002F02EA File Offset: 0x002EE6EA
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/UltimateChallengeRefreshBufMsgBox";
		}

		// Token: 0x0600C3F4 RID: 50164 RVA: 0x002F02F4 File Offset: 0x002EE6F4
		protected override void _OnOpenFrame()
		{
			this.msgBoxData = (this.userData as UltimateChallengeRefreshBufMsgBoxFrame.MsgBoxData);
			this.BindUIEvent();
			this.Cancel.SafeRemoveAllListener();
			this.OK.SafeRemoveAllListener();
			if (this.msgBoxData != null)
			{
				this.content.SafeSetText(this.msgBoxData.content);
				this.Cancel.SafeAddOnClickListener(delegate
				{
					if (this.msgBoxData.cancelCallBack != null)
					{
						this.msgBoxData.cancelCallBack.Invoke();
					}
				});
				this.OK.SafeAddOnClickListener(delegate
				{
					if (this.msgBoxData.okCallBack != null)
					{
						this.msgBoxData.okCallBack.Invoke();
					}
				});
			}
			this.Cancel.SafeAddOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<UltimateChallengeRefreshBufMsgBoxFrame>(this, false);
			});
			this.OK.SafeAddOnClickListener(delegate
			{
				this.frameMgr.CloseFrame<UltimateChallengeRefreshBufMsgBoxFrame>(this, false);
			});
			this.CanNotify.SafeSetToggleOnState(DataManager<ActivityDataManager>.GetInstance().NotPopUpRefreshBufMsgBox);
		}

		// Token: 0x0600C3F5 RID: 50165 RVA: 0x002F03C0 File Offset: 0x002EE7C0
		protected override void _OnCloseFrame()
		{
			this.msgBoxData = null;
			this.UnBindUIEvent();
		}

		// Token: 0x0600C3F6 RID: 50166 RVA: 0x002F03D0 File Offset: 0x002EE7D0
		protected override void _bindExUI()
		{
			this.content = this.mBind.GetCom<Text>("content");
			this.Cancel = this.mBind.GetCom<Button>("Cancel");
			this.OK = this.mBind.GetCom<Button>("OK");
			this.CanNotify = this.mBind.GetCom<Toggle>("CanNotify");
			this.CanNotify.SafeAddOnValueChangedListener(delegate(bool val)
			{
				DataManager<ActivityDataManager>.GetInstance().NotPopUpRefreshBufMsgBox = val;
			});
		}

		// Token: 0x0600C3F7 RID: 50167 RVA: 0x002F045D File Offset: 0x002EE85D
		protected override void _unbindExUI()
		{
			this.content = null;
			this.Cancel = null;
			this.OK = null;
			this.CanNotify = null;
		}

		// Token: 0x0600C3F8 RID: 50168 RVA: 0x002F047B File Offset: 0x002EE87B
		private void BindUIEvent()
		{
		}

		// Token: 0x0600C3F9 RID: 50169 RVA: 0x002F047D File Offset: 0x002EE87D
		private void UnBindUIEvent()
		{
		}

		// Token: 0x04006F7F RID: 28543
		private UltimateChallengeRefreshBufMsgBoxFrame.MsgBoxData msgBoxData;

		// Token: 0x04006F80 RID: 28544
		private new Text content;

		// Token: 0x04006F81 RID: 28545
		private Button Cancel;

		// Token: 0x04006F82 RID: 28546
		private Button OK;

		// Token: 0x04006F83 RID: 28547
		private Toggle CanNotify;

		// Token: 0x020013B9 RID: 5049
		public class MsgBoxData
		{
			// Token: 0x04006F85 RID: 28549
			public string content = string.Empty;

			// Token: 0x04006F86 RID: 28550
			public UnityAction cancelCallBack;

			// Token: 0x04006F87 RID: 28551
			public UnityAction okCallBack;
		}
	}
}
