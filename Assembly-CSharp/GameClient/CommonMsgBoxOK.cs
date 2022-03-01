using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E1D RID: 3613
	public class CommonMsgBoxOK : ClientFrame
	{
		// Token: 0x060090A0 RID: 37024 RVA: 0x001ABE9C File Offset: 0x001AA29C
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.outData = (this.userData as CommonMsgOutData);
			}
			this.BindUIEvent();
			this.fUpdateInterval = 0f;
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl() && this.outData != null && this.outData.bExclusiveWithNewbieGuide)
			{
				this.frameMgr.CloseFrame<CommonMsgBoxOK>(this, false);
			}
		}

		// Token: 0x060090A1 RID: 37025 RVA: 0x001ABF10 File Offset: 0x001AA310
		protected sealed override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			if (this.ButtonOK != null)
			{
				this.ButtonOK.onClick.RemoveAllListeners();
			}
			if (this.ButtonOKmini != null)
			{
				this.ButtonOKmini.onClick.RemoveAllListeners();
			}
			if (this.outData != null)
			{
				this.outData.ClearData();
			}
		}

		// Token: 0x060090A2 RID: 37026 RVA: 0x001ABF7B File Offset: 0x001AA37B
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/CommonMsgBoxOK";
		}

		// Token: 0x060090A3 RID: 37027 RVA: 0x001ABF82 File Offset: 0x001AA382
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnCurGuideStart));
		}

		// Token: 0x060090A4 RID: 37028 RVA: 0x001ABF9F File Offset: 0x001AA39F
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnCurGuideStart));
		}

		// Token: 0x060090A5 RID: 37029 RVA: 0x001ABFBC File Offset: 0x001AA3BC
		private void OnCurGuideStart(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOK>(this, false);
		}

		// Token: 0x060090A6 RID: 37030 RVA: 0x001ABFCB File Offset: 0x001AA3CB
		[UIEventHandle("normal/Back/Panel/btOK")]
		private void OnClickOK()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOK>(this, false);
		}

		// Token: 0x060090A7 RID: 37031 RVA: 0x001ABFDA File Offset: 0x001AA3DA
		[UIEventHandle("mini/Back/Panel/btOK")]
		private void OnClickOKmini()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOK>(this, false);
		}

		// Token: 0x060090A8 RID: 37032 RVA: 0x001ABFEC File Offset: 0x001AA3EC
		private void AdaptUIForMsgContent()
		{
			if (this.ContentText == null)
			{
				return;
			}
			Canvas.ForceUpdateCanvases();
			if (this.ContentText.cachedTextGenerator.lineCount <= 1)
			{
				if (this.m_goObjnormal != null)
				{
					this.m_goObjnormal.CustomActive(false);
				}
				if (this.m_goObjmini != null)
				{
					this.m_goObjmini.CustomActive(true);
				}
			}
		}

		// Token: 0x060090A9 RID: 37033 RVA: 0x001AC060 File Offset: 0x001AA460
		public void SetMsgContent(string str)
		{
			if (this.m_goObjnormal != null)
			{
				this.m_goObjnormal.CustomActive(true);
			}
			if (this.m_goObjmini != null)
			{
				this.m_goObjmini.CustomActive(false);
			}
			if (this.ContentText != null)
			{
				this.ContentText.text = str;
			}
			if (this.ContentTextmini != null)
			{
				this.ContentTextmini.text = str;
			}
			this.AdaptUIForMsgContent();
		}

		// Token: 0x060090AA RID: 37034 RVA: 0x001AC0E7 File Offset: 0x001AA4E7
		public void SetOkBtnText(string str)
		{
			if (this.ButtonText != null)
			{
				this.ButtonText.text = str;
			}
			if (this.ButtonTextmini != null)
			{
				this.ButtonTextmini.text = str;
			}
		}

		// Token: 0x060090AB RID: 37035 RVA: 0x001AC124 File Offset: 0x001AA524
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData, string content)
		{
			if (NotifyData != null)
			{
				this.SetMsgContent(content);
				if (NotifyData.ButtonText != string.Empty && NotifyData.ButtonText != "-" && NotifyData.ButtonText != "0")
				{
					this.SetOkBtnText(NotifyData.ButtonText);
				}
			}
		}

		// Token: 0x060090AC RID: 37036 RVA: 0x001AC18C File Offset: 0x001AA58C
		public void AddListener(UnityAction OnOKCallBack)
		{
			if (OnOKCallBack != null)
			{
				if (this.ButtonOK != null)
				{
					this.ButtonOK.onClick.AddListener(OnOKCallBack);
				}
				if (this.ButtonOKmini != null)
				{
					this.ButtonOKmini.onClick.AddListener(OnOKCallBack);
				}
			}
		}

		// Token: 0x060090AD RID: 37037 RVA: 0x001AC1E3 File Offset: 0x001AA5E3
		public void SetAutoCloseTime(float CloseTime)
		{
			this.fCloseTime = CloseTime;
		}

		// Token: 0x060090AE RID: 37038 RVA: 0x001AC1EC File Offset: 0x001AA5EC
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060090AF RID: 37039 RVA: 0x001AC1F0 File Offset: 0x001AA5F0
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.fCloseTime <= 0f)
			{
				return;
			}
			this.fUpdateInterval += timeElapsed;
			if (this.fUpdateInterval <= this.fCloseTime)
			{
				return;
			}
			if (this.ButtonOK != null && this.ButtonOK.IsActive())
			{
				this.ButtonOK.onClick.Invoke();
			}
			if (this.ButtonOKmini != null && this.ButtonOKmini.IsActive())
			{
				this.ButtonOKmini.onClick.Invoke();
			}
			this.frameMgr.CloseFrame<CommonMsgBoxOK>(this, false);
		}

		// Token: 0x040047EC RID: 18412
		private float fUpdateInterval;

		// Token: 0x040047ED RID: 18413
		private float fCloseTime = -1f;

		// Token: 0x040047EE RID: 18414
		private CommonMsgOutData outData = new CommonMsgOutData();

		// Token: 0x040047EF RID: 18415
		[UIControl("normal/Back/Title/Text", null, 0)]
		protected Text TitleText;

		// Token: 0x040047F0 RID: 18416
		[UIControl("normal/Back/TextPanel/AlertText", null, 0)]
		protected Text ContentText;

		// Token: 0x040047F1 RID: 18417
		[UIControl("normal/Back/Panel/btOK/Text", null, 0)]
		protected Text ButtonText;

		// Token: 0x040047F2 RID: 18418
		[UIControl("normal/Back/Panel/btOK", null, 0)]
		protected Button ButtonOK;

		// Token: 0x040047F3 RID: 18419
		[UIControl("mini/Back/Title/Text", null, 0)]
		protected Text TitleTextmini;

		// Token: 0x040047F4 RID: 18420
		[UIControl("mini/Back/TextPanel/AlertText", null, 0)]
		protected Text ContentTextmini;

		// Token: 0x040047F5 RID: 18421
		[UIControl("mini/Back/Panel/btOK/Text", null, 0)]
		protected Text ButtonTextmini;

		// Token: 0x040047F6 RID: 18422
		[UIControl("mini/Back/Panel/btOK", null, 0)]
		protected Button ButtonOKmini;

		// Token: 0x040047F7 RID: 18423
		[UIObject("normal")]
		private GameObject m_goObjnormal;

		// Token: 0x040047F8 RID: 18424
		[UIObject("mini")]
		private GameObject m_goObjmini;
	}
}
