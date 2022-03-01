using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E26 RID: 3622
	internal class CommonPurChaseHintFrame : ClientFrame
	{
		// Token: 0x060090EC RID: 37100 RVA: 0x001AD13C File Offset: 0x001AB53C
		public static void Open(string msg, string ok = "确定", string cancel = "取消", CommonMsgData.OnOk onOk = null, CommonMsgData.OnCancel onCancel = null)
		{
			CommonMsgData userData = new CommonMsgData
			{
				msg = msg,
				ok = ok,
				cancel = cancel,
				onClickOk = onOk,
				onClickCancel = onCancel
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CommonPurChaseHintFrame>(FrameLayer.High, userData, string.Empty);
		}

		// Token: 0x060090ED RID: 37101 RVA: 0x001AD187 File Offset: 0x001AB587
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MsgBox/SpecialMsgBoxOKCancel";
		}

		// Token: 0x060090EE RID: 37102 RVA: 0x001AD190 File Offset: 0x001AB590
		protected override void _OnOpenFrame()
		{
			this.data = (this.userData as CommonMsgData);
			this.OKText.text = this.data.ok;
			this.CancelText.text = this.data.cancel;
			this.msgText.text = this.data.msg;
		}

		// Token: 0x060090EF RID: 37103 RVA: 0x001AD1F0 File Offset: 0x001AB5F0
		protected override void _OnCloseFrame()
		{
			this.data = null;
		}

		// Token: 0x060090F0 RID: 37104 RVA: 0x001AD1F9 File Offset: 0x001AB5F9
		[UIEventHandle("Back/Panel/btOK")]
		private void OnClickOK()
		{
			if (this.data.onClickOk != null)
			{
				this.data.onClickOk();
				this.data.onClickOk = null;
			}
			this.frameMgr.CloseFrame<CommonPurChaseHintFrame>(this, false);
		}

		// Token: 0x060090F1 RID: 37105 RVA: 0x001AD234 File Offset: 0x001AB634
		[UIEventHandle("Back/Panel/btCancel")]
		private void OnClickCancel()
		{
			if (this.data.onClickCancel != null)
			{
				this.data.onClickCancel();
				this.data.onClickCancel = null;
			}
			this.frameMgr.CloseFrame<CommonPurChaseHintFrame>(this, false);
		}

		// Token: 0x04004835 RID: 18485
		private CommonMsgData data;

		// Token: 0x04004836 RID: 18486
		[UIControl("Back/TextPanel/AlertText", null, 0)]
		protected Text msgText;

		// Token: 0x04004837 RID: 18487
		[UIControl("Back/Panel/btOK/Text", null, 0)]
		protected Text OKText;

		// Token: 0x04004838 RID: 18488
		[UIControl("Back/Panel/btCancel/Text", null, 0)]
		protected Text CancelText;

		// Token: 0x04004839 RID: 18489
		[UIControl("Back/Panel/btOK", null, 0)]
		protected Button btOK;

		// Token: 0x0400483A RID: 18490
		[UIControl("Back/Panel/btCancel", null, 0)]
		protected Button btCancel;
	}
}
