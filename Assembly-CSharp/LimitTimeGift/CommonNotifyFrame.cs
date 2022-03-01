using System;
using GameClient;
using UnityEngine.Events;
using UnityEngine.UI;

namespace LimitTimeGift
{
	// Token: 0x02001724 RID: 5924
	public class CommonNotifyFrame : ClientFrame
	{
		// Token: 0x0600E8AA RID: 59562 RVA: 0x003D8A7B File Offset: 0x003D6E7B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/LimitTimeGift/CommonNotifyFrame";
		}

		// Token: 0x0600E8AB RID: 59563 RVA: 0x003D8A84 File Offset: 0x003D6E84
		protected override void _bindExUI()
		{
			this.notifyContent = this.mBind.GetCom<Text>("notifyContent");
			this.btnCancel = this.mBind.GetCom<Button>("btnCancel");
			if (this.btnCancel)
			{
				this.btnCancel.onClick.RemoveListener(new UnityAction(this.OnCancelBtnClick));
				this.btnCancel.onClick.AddListener(new UnityAction(this.OnCancelBtnClick));
			}
			this.btnOk = this.mBind.GetCom<Button>("btnOk");
			if (this.btnOk)
			{
				this.btnOk.onClick.RemoveListener(new UnityAction(this.OnOkBtnClick));
				this.btnOk.onClick.AddListener(new UnityAction(this.OnOkBtnClick));
			}
		}

		// Token: 0x0600E8AC RID: 59564 RVA: 0x003D8B63 File Offset: 0x003D6F63
		protected override void _unbindExUI()
		{
			this.notifyContent = null;
			this.btnCancel = null;
			this.btnOk = null;
		}

		// Token: 0x0600E8AD RID: 59565 RVA: 0x003D8B7C File Offset: 0x003D6F7C
		protected override void _OnOpenFrame()
		{
			this.InitCacheData();
			CommonNotifyData commonNotifyData = this.userData as CommonNotifyData;
			if (this.notifyContent && commonNotifyData != null)
			{
				this.notifyContent.text = commonNotifyData.contentStr;
				this.addedClickOkCB = commonNotifyData.onClickOkCallback;
				this.addedClickCancelCB = commonNotifyData.onClickCancelCallback;
				this.thisframeOwner = commonNotifyData.ownerFrame;
			}
		}

		// Token: 0x0600E8AE RID: 59566 RVA: 0x003D8BE6 File Offset: 0x003D6FE6
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x0600E8AF RID: 59567 RVA: 0x003D8BE8 File Offset: 0x003D6FE8
		private void InitCacheData()
		{
			this.addedClickOkCB = null;
			this.addedClickCancelCB = null;
			this.thisframeOwner = null;
		}

		// Token: 0x0600E8B0 RID: 59568 RVA: 0x003D8BFF File Offset: 0x003D6FFF
		private void OnCancelBtnClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<CommonNotifyFrame>(this, true);
			if (this.addedClickCancelCB != null)
			{
				this.addedClickCancelCB.Invoke();
			}
		}

		// Token: 0x0600E8B1 RID: 59569 RVA: 0x003D8C23 File Offset: 0x003D7023
		private void OnOkBtnClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<CommonNotifyFrame>(this, false);
			if (this.thisframeOwner != null)
			{
				Singleton<ClientSystemManager>.instance.CloseFrame<ClientFrame>(this.thisframeOwner, false);
			}
			if (this.addedClickOkCB != null)
			{
				this.addedClickOkCB.Invoke();
			}
		}

		// Token: 0x04008D0E RID: 36110
		private Text notifyContent;

		// Token: 0x04008D0F RID: 36111
		private Button btnCancel;

		// Token: 0x04008D10 RID: 36112
		private Button btnOk;

		// Token: 0x04008D11 RID: 36113
		private UnityAction addedClickOkCB;

		// Token: 0x04008D12 RID: 36114
		private UnityAction addedClickCancelCB;

		// Token: 0x04008D13 RID: 36115
		private ClientFrame thisframeOwner;
	}
}
