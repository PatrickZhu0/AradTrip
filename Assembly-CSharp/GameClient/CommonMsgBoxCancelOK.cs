using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E1B RID: 3611
	public class CommonMsgBoxCancelOK : ClientFrame
	{
		// Token: 0x06009083 RID: 36995 RVA: 0x001AB502 File Offset: 0x001A9902
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/CommonMsgBoxCancelOK";
		}

		// Token: 0x06009084 RID: 36996 RVA: 0x001AB50C File Offset: 0x001A990C
		protected sealed override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.outData = (this.userData as CommonMsgOutData);
			}
			this.BindUIEvent();
			if (this.CancelText != null)
			{
				this.CancelBtnOriginText = this.CancelText.text;
			}
			if (this.OKText != null)
			{
				this.OkBtnOriginText = this.OKText.text;
			}
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl() && this.outData != null && this.outData.bExclusiveWithNewbieGuide)
			{
				this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
			}
		}

		// Token: 0x06009085 RID: 36997 RVA: 0x001AB5B6 File Offset: 0x001A99B6
		protected sealed override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
		}

		// Token: 0x06009086 RID: 36998 RVA: 0x001AB5C4 File Offset: 0x001A99C4
		private void ClearData()
		{
			this.bOpenCountDownFunc = false;
			this.fCountDownTime = 0f;
			this.fAddUpTime = 0f;
			this.CancelBtnOriginText = string.Empty;
			this.OkBtnOriginText = string.Empty;
			if (this.btOK != null)
			{
				this.btOK.onClick.RemoveAllListeners();
			}
			if (this.btCancel != null)
			{
				this.btCancel.onClick.RemoveAllListeners();
			}
			if (this.btOKmini != null)
			{
				this.btOKmini.onClick.RemoveAllListeners();
			}
			if (this.btCancelmini != null)
			{
				this.btCancelmini.onClick.RemoveAllListeners();
			}
			if (this.outData != null)
			{
				this.outData.ClearData();
			}
			if (this.param != null)
			{
				this.param.ResetData();
			}
		}

		// Token: 0x06009087 RID: 36999 RVA: 0x001AB6B4 File Offset: 0x001A9AB4
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnCurGuideStart));
		}

		// Token: 0x06009088 RID: 37000 RVA: 0x001AB6EC File Offset: 0x001A9AEC
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnCurGuideStart));
		}

		// Token: 0x06009089 RID: 37001 RVA: 0x001AB724 File Offset: 0x001A9B24
		private void OnPk3v3VoteEnterBattle(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
		}

		// Token: 0x0600908A RID: 37002 RVA: 0x001AB733 File Offset: 0x001A9B33
		private void OnCurGuideStart(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
		}

		// Token: 0x0600908B RID: 37003 RVA: 0x001AB744 File Offset: 0x001A9B44
		private void AdaptUIForMsgContent()
		{
			if (this.msgText == null)
			{
				return;
			}
			Canvas.ForceUpdateCanvases();
			if (this.msgText.cachedTextGenerator.lineCount <= 1)
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

		// Token: 0x0600908C RID: 37004 RVA: 0x001AB7B8 File Offset: 0x001A9BB8
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
			if (this.msgText != null)
			{
				this.msgText.text = str;
			}
			if (this.msgTextmini != null)
			{
				this.msgTextmini.text = str;
			}
			this.AdaptUIForMsgContent();
		}

		// Token: 0x0600908D RID: 37005 RVA: 0x001AB840 File Offset: 0x001A9C40
		public void SetCancelBtnText(string str)
		{
			if (this.CancelText != null)
			{
				this.CancelText.text = str;
			}
			if (this.CancelTextmini != null)
			{
				this.CancelTextmini.text = str;
			}
			this.CancelBtnOriginText = str;
		}

		// Token: 0x0600908E RID: 37006 RVA: 0x001AB890 File Offset: 0x001A9C90
		public void SetOkBtnText(string str)
		{
			if (this.OKText != null)
			{
				this.OKText.text = str;
			}
			if (this.OKTextmini != null)
			{
				this.OKTextmini.text = str;
			}
			this.OkBtnOriginText = str;
		}

		// Token: 0x0600908F RID: 37007 RVA: 0x001AB8E0 File Offset: 0x001A9CE0
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData)
		{
			if (NotifyData != null)
			{
				if (NotifyData.ButtonText != string.Empty && NotifyData.ButtonText != "-" && NotifyData.ButtonText != "0")
				{
					this.SetOkBtnText(NotifyData.ButtonText);
					this.OkBtnOriginText = NotifyData.ButtonText;
				}
				if (NotifyData.CancelBtnText != string.Empty && NotifyData.CancelBtnText != "-" && NotifyData.CancelBtnText != "0")
				{
					this.SetCancelBtnText(NotifyData.CancelBtnText);
					this.CancelBtnOriginText = NotifyData.CancelBtnText;
				}
			}
		}

		// Token: 0x06009090 RID: 37008 RVA: 0x001AB9A4 File Offset: 0x001A9DA4
		public void SetCountDownTime(float fTime, bool bIsCountDownTimeOKBtn = false)
		{
			if (fTime > 0f)
			{
				this.bIsCountDownTimeOKBtn = bIsCountDownTimeOKBtn;
				if (!this.bIsCountDownTimeOKBtn)
				{
					if (!this._NeedCloseFrameOnCDEnd())
					{
						this.updateThreshold = 0f;
					}
					if (this._NeedShowCancelBtnGray())
					{
						this._SetCancelButtonEnable(false);
					}
				}
				else
				{
					this._SetOkButtonEnabe(false);
				}
				this.fCountDownTime = fTime;
				this.bOpenCountDownFunc = true;
			}
		}

		// Token: 0x06009091 RID: 37009 RVA: 0x001ABA10 File Offset: 0x001A9E10
		public void InitMsgBox(CommonMsgBoxCancelOKParams outParam)
		{
			if (outParam == null)
			{
				return;
			}
			this.param = outParam;
		}

		// Token: 0x06009092 RID: 37010 RVA: 0x001ABA20 File Offset: 0x001A9E20
		public void AddListener(UnityAction OnOKCallBack, UnityAction OnCancelCallBack)
		{
			if (OnOKCallBack != null)
			{
				if (this.btOK != null)
				{
					this.btOK.onClick.AddListener(OnOKCallBack);
				}
				if (this.btOKmini != null)
				{
					this.btOKmini.onClick.AddListener(OnOKCallBack);
				}
			}
			if (OnCancelCallBack != null)
			{
				if (this.btCancel != null)
				{
					this.btCancel.onClick.AddListener(OnCancelCallBack);
				}
				if (this.btCancelmini != null)
				{
					this.btCancelmini.onClick.AddListener(OnCancelCallBack);
				}
			}
		}

		// Token: 0x06009093 RID: 37011 RVA: 0x001ABAC1 File Offset: 0x001A9EC1
		[UIEventHandle("normal/Back/Panel/btOK")]
		private void OnClickOK()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
		}

		// Token: 0x06009094 RID: 37012 RVA: 0x001ABAD0 File Offset: 0x001A9ED0
		[UIEventHandle("normal/Back/Panel/btCancel")]
		private void OnClickCancel()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
		}

		// Token: 0x06009095 RID: 37013 RVA: 0x001ABADF File Offset: 0x001A9EDF
		[UIEventHandle("mini/Back/Panel/btOK")]
		private void OnClickOKmini()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
		}

		// Token: 0x06009096 RID: 37014 RVA: 0x001ABAEE File Offset: 0x001A9EEE
		[UIEventHandle("mini/Back/Panel/btCancel")]
		private void OnClickCancelmini()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
		}

		// Token: 0x06009097 RID: 37015 RVA: 0x001ABAFD File Offset: 0x001A9EFD
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x06009098 RID: 37016 RVA: 0x001ABB00 File Offset: 0x001A9F00
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.bOpenCountDownFunc)
			{
				int num = (int)this.fCountDownTime;
				if (!this.bIsCountDownTimeOKBtn)
				{
					if (this.CancelText != null)
					{
						this.CancelText.text = string.Format("{0}({1}s)", this.CancelBtnOriginText, num);
					}
					if (this.CancelTextmini != null)
					{
						this.CancelTextmini.text = string.Format("{0}({1}s)", this.CancelBtnOriginText, num);
					}
				}
				else
				{
					if (this.OKText != null)
					{
						this.OKText.text = string.Format("{0}({1}s)", this.OkBtnOriginText, num);
					}
					if (this.OKTextmini != null)
					{
						this.OKTextmini.text = string.Format("{0}({1}s)", this.OkBtnOriginText, num);
					}
				}
				this.fAddUpTime += timeElapsed;
				if (this.fAddUpTime > 1f)
				{
					this.fCountDownTime -= 1f;
					this.fAddUpTime = 0f;
				}
				if (!this.bIsCountDownTimeOKBtn)
				{
					if ((float)num < this.updateThreshold)
					{
						this.bOpenCountDownFunc = false;
						if (this.btCancel != null && this.btCancel.IsActive())
						{
							this.btCancel.onClick.Invoke();
						}
						if (this.btCancelmini != null && this.btCancelmini.IsActive())
						{
							this.btCancelmini.onClick.Invoke();
						}
						if (this._NeedShowCancelBtnGray())
						{
							this.CancelText.text = this.CancelBtnOriginText;
							this.CancelTextmini.text = this.CancelBtnOriginText;
							this._SetCancelButtonEnable(true);
						}
						if (this._NeedCloseFrameOnCDEnd())
						{
							this.frameMgr.CloseFrame<CommonMsgBoxCancelOK>(this, false);
						}
					}
				}
				else if (num <= 0)
				{
					this.bOpenCountDownFunc = false;
					if (this.OKText != null)
					{
						this.OKText.text = this.OkBtnOriginText;
					}
					if (this.OKTextmini != null)
					{
						this.OKTextmini.text = this.OkBtnOriginText;
					}
					this._SetOkButtonEnabe(true);
				}
			}
		}

		// Token: 0x06009099 RID: 37017 RVA: 0x001ABD60 File Offset: 0x001AA160
		private void _SetCancelButtonEnable(bool bEnable)
		{
			if (this._NeedShowCancelBtnGray())
			{
				this.btCancel.enabled = bEnable;
				this.btCancelGray.enabled = !bEnable;
				this.btCancelmini.enabled = bEnable;
				this.btCancelminiGray.enabled = !bEnable;
			}
		}

		// Token: 0x0600909A RID: 37018 RVA: 0x001ABDB0 File Offset: 0x001AA1B0
		private void _SetOkButtonEnabe(bool bEnable)
		{
			if (this.btOK != null)
			{
				this.btOK.enabled = bEnable;
			}
			if (this.btOKGray != null)
			{
				this.btOKGray.enabled = !bEnable;
			}
			if (this.btOKmini != null)
			{
				this.btOKmini.enabled = bEnable;
			}
			if (this.btOKminiGray != null)
			{
				this.btOKminiGray.enabled = !bEnable;
			}
		}

		// Token: 0x0600909B RID: 37019 RVA: 0x001ABE37 File Offset: 0x001AA237
		private bool _NeedCloseFrameOnCDEnd()
		{
			return this.param != null && this.param.closeFrameOnCancelBtnCDEnd;
		}

		// Token: 0x0600909C RID: 37020 RVA: 0x001ABE51 File Offset: 0x001AA251
		private bool _NeedShowCancelBtnGray()
		{
			return this.param != null && this.param.showCancelBtnGrayOnCDEnd;
		}

		// Token: 0x040047D2 RID: 18386
		private bool bIsCountDownTimeOKBtn;

		// Token: 0x040047D3 RID: 18387
		private bool bOpenCountDownFunc;

		// Token: 0x040047D4 RID: 18388
		private float fCountDownTime;

		// Token: 0x040047D5 RID: 18389
		private float fAddUpTime;

		// Token: 0x040047D6 RID: 18390
		private string CancelBtnOriginText = string.Empty;

		// Token: 0x040047D7 RID: 18391
		private string OkBtnOriginText = string.Empty;

		// Token: 0x040047D8 RID: 18392
		private float updateThreshold;

		// Token: 0x040047D9 RID: 18393
		private CommonMsgBoxCancelOKParams param = new CommonMsgBoxCancelOKParams();

		// Token: 0x040047DA RID: 18394
		private CommonMsgOutData outData = new CommonMsgOutData();

		// Token: 0x040047DB RID: 18395
		[UIControl("normal/Back/TextPanel/AlertText", null, 0)]
		protected Text msgText;

		// Token: 0x040047DC RID: 18396
		[UIControl("normal/Back/Panel/btOK/Text", null, 0)]
		protected Text OKText;

		// Token: 0x040047DD RID: 18397
		[UIControl("normal/Back/Panel/btCancel/Text", null, 0)]
		protected Text CancelText;

		// Token: 0x040047DE RID: 18398
		[UIControl("normal/Back/Panel/btOK", null, 0)]
		protected Button btOK;

		// Token: 0x040047DF RID: 18399
		[UIControl("normal/Back/Panel/btOK", null, 0)]
		protected UIGray btOKGray;

		// Token: 0x040047E0 RID: 18400
		[UIControl("normal/Back/Panel/btCancel", null, 0)]
		protected Button btCancel;

		// Token: 0x040047E1 RID: 18401
		[UIControl("normal/Back/Panel/btCancel", null, 0)]
		protected UIGray btCancelGray;

		// Token: 0x040047E2 RID: 18402
		[UIControl("mini/Back/TextPanel/AlertText", null, 0)]
		protected Text msgTextmini;

		// Token: 0x040047E3 RID: 18403
		[UIControl("mini/Back/Panel/btOK/Text", null, 0)]
		protected Text OKTextmini;

		// Token: 0x040047E4 RID: 18404
		[UIControl("mini/Back/Panel/btCancel/Text", null, 0)]
		protected Text CancelTextmini;

		// Token: 0x040047E5 RID: 18405
		[UIControl("mini/Back/Panel/btOK", null, 0)]
		protected Button btOKmini;

		// Token: 0x040047E6 RID: 18406
		[UIControl("mini/Back/Panel/btOK", null, 0)]
		protected UIGray btOKminiGray;

		// Token: 0x040047E7 RID: 18407
		[UIControl("mini/Back/Panel/btCancel", null, 0)]
		protected Button btCancelmini;

		// Token: 0x040047E8 RID: 18408
		[UIControl("mini/Back/Panel/btCancel", null, 0)]
		protected UIGray btCancelminiGray;

		// Token: 0x040047E9 RID: 18409
		[UIObject("normal")]
		private GameObject m_goObjnormal;

		// Token: 0x040047EA RID: 18410
		[UIObject("mini")]
		private GameObject m_goObjmini;
	}
}
