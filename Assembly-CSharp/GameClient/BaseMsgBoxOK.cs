using System;
using ProtoTable;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E10 RID: 3600
	public class BaseMsgBoxOK : ClientFrame
	{
		// Token: 0x06009030 RID: 36912 RVA: 0x001AA93C File Offset: 0x001A8D3C
		protected override void _OnOpenFrame()
		{
			if (null != this.ButtonOK)
			{
				ControlButtonAnimation component = this.ButtonOK.GetComponent<ControlButtonAnimation>();
				if (null != component)
				{
					component.enabled = false;
				}
			}
			this.fUpdateInterval = 0f;
		}

		// Token: 0x06009031 RID: 36913 RVA: 0x001AA984 File Offset: 0x001A8D84
		protected override void _OnCloseFrame()
		{
			if (this.ButtonOK != null)
			{
				this.ButtonOK.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06009032 RID: 36914 RVA: 0x001AA9A7 File Offset: 0x001A8DA7
		public override string GetPrefabPath()
		{
			return "Base/UI/Prefabs/BaseMsgBoxOK";
		}

		// Token: 0x06009033 RID: 36915 RVA: 0x001AA9AE File Offset: 0x001A8DAE
		[UIEventHandle("normal/Back/Panel/btOK")]
		private void OnClickOK()
		{
			this.frameMgr.CloseFrame<BaseMsgBoxOK>(this, false);
		}

		// Token: 0x06009034 RID: 36916 RVA: 0x001AA9BD File Offset: 0x001A8DBD
		public void SetMsgContent(string str)
		{
			if (this.ContentText != null)
			{
				this.ContentText.text = str;
			}
		}

		// Token: 0x06009035 RID: 36917 RVA: 0x001AA9DC File Offset: 0x001A8DDC
		public void SetOKBtnText(string str)
		{
			if (this.ButtonText != null)
			{
				this.ButtonText.text = str;
			}
		}

		// Token: 0x06009036 RID: 36918 RVA: 0x001AA9FC File Offset: 0x001A8DFC
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData, string content)
		{
			if (NotifyData != null)
			{
				this.SetMsgContent(content);
				if (NotifyData.ButtonText != string.Empty && NotifyData.ButtonText != "-" && NotifyData.ButtonText != "0" && this.ButtonText != null)
				{
					this.ButtonText.text = NotifyData.ButtonText;
				}
			}
		}

		// Token: 0x06009037 RID: 36919 RVA: 0x001AAA77 File Offset: 0x001A8E77
		public void AddListener(UnityAction OnOKCallBack)
		{
			if (OnOKCallBack != null && this.ButtonOK != null)
			{
				this.ButtonOK.onClick.RemoveListener(OnOKCallBack);
				this.ButtonOK.onClick.AddListener(OnOKCallBack);
			}
		}

		// Token: 0x06009038 RID: 36920 RVA: 0x001AAAB2 File Offset: 0x001A8EB2
		public void SetAutoCloseTime(float CloseTime)
		{
			this.fCloseTime = CloseTime;
		}

		// Token: 0x06009039 RID: 36921 RVA: 0x001AAABB File Offset: 0x001A8EBB
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600903A RID: 36922 RVA: 0x001AAABE File Offset: 0x001A8EBE
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x040047A8 RID: 18344
		private float fUpdateInterval;

		// Token: 0x040047A9 RID: 18345
		private float fCloseTime = -1f;

		// Token: 0x040047AA RID: 18346
		[UIControl("normal/Back/Title/Text", null, 0)]
		protected Text TitleText;

		// Token: 0x040047AB RID: 18347
		[UIControl("normal/Back/TextPanel/AlertText", null, 0)]
		protected Text ContentText;

		// Token: 0x040047AC RID: 18348
		[UIControl("normal/Back/Panel/btOK/Text", null, 0)]
		protected Text ButtonText;

		// Token: 0x040047AD RID: 18349
		[UIControl("normal/Back/Panel/btOK", null, 0)]
		protected Button ButtonOK;
	}
}
