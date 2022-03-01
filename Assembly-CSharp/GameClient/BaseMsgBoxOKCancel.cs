using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E11 RID: 3601
	public class BaseMsgBoxOKCancel : ClientFrame
	{
		// Token: 0x0600903C RID: 36924 RVA: 0x001AAAC8 File Offset: 0x001A8EC8
		protected sealed override void _OnOpenFrame()
		{
		}

		// Token: 0x0600903D RID: 36925 RVA: 0x001AAACC File Offset: 0x001A8ECC
		protected sealed override void _OnCloseFrame()
		{
			if (this.btOK != null)
			{
				this.btOK.onClick.RemoveAllListeners();
			}
			if (this.btCancel != null)
			{
				this.btCancel.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x0600903E RID: 36926 RVA: 0x001AAB1B File Offset: 0x001A8F1B
		public sealed override string GetPrefabPath()
		{
			return "Base/UI/Prefabs/BaseMsgBoxOKCancel";
		}

		// Token: 0x0600903F RID: 36927 RVA: 0x001AAB22 File Offset: 0x001A8F22
		public void SetMsgContent(string str)
		{
			if (this.msgText != null)
			{
				this.msgText.text = str;
			}
		}

		// Token: 0x06009040 RID: 36928 RVA: 0x001AAB41 File Offset: 0x001A8F41
		public void SetOkBtnText(string str)
		{
			if (this.OKText != null)
			{
				this.OKText.text = str;
			}
		}

		// Token: 0x06009041 RID: 36929 RVA: 0x001AAB60 File Offset: 0x001A8F60
		public void SetCancelBtnText(string str)
		{
			if (this.CancelText != null)
			{
				this.CancelText.text = str;
			}
		}

		// Token: 0x06009042 RID: 36930 RVA: 0x001AAB80 File Offset: 0x001A8F80
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData, string content)
		{
			if (NotifyData != null)
			{
				this.SetMsgContent(content);
				if (NotifyData.ButtonText != string.Empty && NotifyData.ButtonText != "-" && NotifyData.ButtonText != "0")
				{
					this.SetOkBtnText(NotifyData.ButtonText);
				}
				if (NotifyData.CancelBtnText != string.Empty && NotifyData.CancelBtnText != "-" && NotifyData.CancelBtnText != "0")
				{
					this.SetCancelBtnText(NotifyData.CancelBtnText);
				}
			}
		}

		// Token: 0x06009043 RID: 36931 RVA: 0x001AAC30 File Offset: 0x001A9030
		public void AddListener(UnityAction OnOKCallBack, UnityAction OnCancelCallBack)
		{
			if (OnOKCallBack != null && this.btOK != null)
			{
				this.btOK.onClick.RemoveListener(OnOKCallBack);
				this.btOK.onClick.AddListener(OnOKCallBack);
			}
			if (OnCancelCallBack != null && this.btCancel != null)
			{
				this.btCancel.onClick.RemoveListener(OnCancelCallBack);
				this.btCancel.onClick.AddListener(OnCancelCallBack);
			}
		}

		// Token: 0x06009044 RID: 36932 RVA: 0x001AACAF File Offset: 0x001A90AF
		[UIEventHandle("normal/Back/Panel/btOK")]
		private void OnClickOK()
		{
			if (this.responseOK != null)
			{
				this.responseOK();
			}
			this.responseOK = null;
			this.frameMgr.CloseFrame<BaseMsgBoxOKCancel>(this, false);
		}

		// Token: 0x06009045 RID: 36933 RVA: 0x001AACDB File Offset: 0x001A90DB
		[UIEventHandle("normal/Back/Panel/btCancel")]
		private void OnClickCancel()
		{
			if (this.responseCancel != null)
			{
				this.responseCancel();
			}
			this.responseCancel = null;
			this.frameMgr.CloseFrame<BaseMsgBoxOKCancel>(this, false);
		}

		// Token: 0x040047AE RID: 18350
		public BaseMsgBoxOKCancel.OnResponseOK responseOK;

		// Token: 0x040047AF RID: 18351
		public BaseMsgBoxOKCancel.OnResponseCancel responseCancel;

		// Token: 0x040047B0 RID: 18352
		[UIControl("normal/Back/TextPanel/AlertText", null, 0)]
		protected Text msgText;

		// Token: 0x040047B1 RID: 18353
		[UIControl("normal/Back/Panel/btOK/Text", null, 0)]
		protected Text OKText;

		// Token: 0x040047B2 RID: 18354
		[UIControl("normal/Back/Panel/btCancel/Text", null, 0)]
		protected Text CancelText;

		// Token: 0x040047B3 RID: 18355
		[UIControl("normal/Back/Panel/btOK", null, 0)]
		protected Button btOK;

		// Token: 0x040047B4 RID: 18356
		[UIControl("normal/Back/Panel/btCancel", null, 0)]
		protected Button btCancel;

		// Token: 0x02000E12 RID: 3602
		// (Invoke) Token: 0x06009047 RID: 36935
		public delegate void OnResponseOK();

		// Token: 0x02000E13 RID: 3603
		// (Invoke) Token: 0x0600904B RID: 36939
		public delegate void OnResponseCancel();
	}
}
