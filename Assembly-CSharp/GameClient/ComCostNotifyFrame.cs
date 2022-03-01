using System;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001BB8 RID: 7096
	internal class ComCostNotifyFrame : ClientFrame
	{
		// Token: 0x060115D7 RID: 71127 RVA: 0x00508268 File Offset: 0x00506668
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/StrengthenTicketMerge/ComCostNotify";
		}

		// Token: 0x060115D8 RID: 71128 RVA: 0x00508270 File Offset: 0x00506670
		protected override void _OnOpenFrame()
		{
			ComCostNotifyFrame.data = (this.userData as ComCostNotifyData);
			if (ComCostNotifyFrame.data != null)
			{
				if (this.mAlertText)
				{
					this.mAlertText.text = ComCostNotifyFrame.data.strContent;
				}
				if (this.mCanNotify && ComCostNotifyFrame.data.delGetNotify != null)
				{
					this.mCanNotify.isOn = ComCostNotifyFrame.data.delGetNotify();
				}
			}
		}

		// Token: 0x060115D9 RID: 71129 RVA: 0x005082F5 File Offset: 0x005066F5
		protected override void _OnCloseFrame()
		{
			ComCostNotifyFrame.data = null;
		}

		// Token: 0x060115DA RID: 71130 RVA: 0x00508300 File Offset: 0x00506700
		protected override void _bindExUI()
		{
			this.mAlertText = this.mBind.GetCom<Text>("AlertText");
			this.mCanNotify = this.mBind.GetCom<Toggle>("CanNotify");
			if (null != this.mCanNotify)
			{
				this.mCanNotify.onValueChanged.AddListener(new UnityAction<bool>(this._onCanNotifyToggleValueChange));
			}
			this.mBtCancel = this.mBind.GetCom<Button>("btCancel");
			if (null != this.mBtCancel)
			{
				this.mBtCancel.onClick.AddListener(new UnityAction(this._onBtCancelButtonClick));
			}
			this.mBtOK = this.mBind.GetCom<Button>("btOK");
			if (null != this.mBtOK)
			{
				this.mBtOK.onClick.AddListener(new UnityAction(this._onBtOKButtonClick));
			}
		}

		// Token: 0x060115DB RID: 71131 RVA: 0x005083EC File Offset: 0x005067EC
		protected override void _unbindExUI()
		{
			this.mAlertText = null;
			if (null != this.mCanNotify)
			{
				this.mCanNotify.onValueChanged.RemoveListener(new UnityAction<bool>(this._onCanNotifyToggleValueChange));
			}
			this.mCanNotify = null;
			if (null != this.mBtCancel)
			{
				this.mBtCancel.onClick.RemoveListener(new UnityAction(this._onBtCancelButtonClick));
			}
			this.mBtCancel = null;
			if (null != this.mBtOK)
			{
				this.mBtOK.onClick.RemoveListener(new UnityAction(this._onBtOKButtonClick));
			}
			this.mBtOK = null;
		}

		// Token: 0x060115DC RID: 71132 RVA: 0x0050849C File Offset: 0x0050689C
		private void _onCanNotifyToggleValueChange(bool changed)
		{
			if (ComCostNotifyFrame.data != null && ComCostNotifyFrame.data.delSetNotify != null)
			{
				ComCostNotifyFrame.data.delSetNotify(changed);
			}
		}

		// Token: 0x060115DD RID: 71133 RVA: 0x005084C7 File Offset: 0x005068C7
		private void _onBtCancelButtonClick()
		{
			if (ComCostNotifyFrame.data != null && ComCostNotifyFrame.data.delOnCancelCallback != null)
			{
				ComCostNotifyFrame.data.delOnCancelCallback.Invoke();
			}
			this.frameMgr.CloseFrame<ComCostNotifyFrame>(this, false);
		}

		// Token: 0x060115DE RID: 71134 RVA: 0x005084FE File Offset: 0x005068FE
		private void _onBtOKButtonClick()
		{
			if (ComCostNotifyFrame.data != null && ComCostNotifyFrame.data.delOnOkCallback != null)
			{
				ComCostNotifyFrame.data.delOnOkCallback.Invoke();
			}
			this.frameMgr.CloseFrame<ComCostNotifyFrame>(this, false);
		}

		// Token: 0x0400B431 RID: 46129
		public static ComCostNotifyData data;

		// Token: 0x0400B432 RID: 46130
		private Text mAlertText;

		// Token: 0x0400B433 RID: 46131
		private Toggle mCanNotify;

		// Token: 0x0400B434 RID: 46132
		private Button mBtCancel;

		// Token: 0x0400B435 RID: 46133
		private Button mBtOK;
	}
}
