using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E1E RID: 3614
	public class CommonMsgBoxOKCancel : ClientFrame
	{
		// Token: 0x060090B1 RID: 37041 RVA: 0x001AC2BB File Offset: 0x001AA6BB
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/CommonSystemNotify/CommonMsgBoxOKCancel";
		}

		// Token: 0x060090B2 RID: 37042 RVA: 0x001AC2C4 File Offset: 0x001AA6C4
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
			if (this.m_togCanNotify != null)
			{
				this.m_togCanNotify.onValueChanged.RemoveAllListeners();
				this.m_togCanNotify.isOn = !DataManager<PlayerBaseData>.GetInstance().isNotify;
				this.m_togCanNotify.onValueChanged.AddListener(delegate(bool var)
				{
					DataManager<PlayerBaseData>.GetInstance().isNotify = !var;
				});
			}
			if (this.m_togCanNotifymini != null)
			{
				this.m_togCanNotifymini.onValueChanged.RemoveAllListeners();
				this.m_togCanNotifymini.isOn = !DataManager<PlayerBaseData>.GetInstance().isNotify;
				this.m_togCanNotifymini.onValueChanged.AddListener(delegate(bool var)
				{
					DataManager<PlayerBaseData>.GetInstance().isNotify = !var;
				});
			}
			if (Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl() && this.outData != null && this.outData.bExclusiveWithNewbieGuide)
			{
				this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
			}
		}

		// Token: 0x060090B3 RID: 37043 RVA: 0x001AC418 File Offset: 0x001AA818
		protected sealed override void _OnCloseFrame()
		{
			this.UnBindUIEvent();
			this.ClearData();
		}

		// Token: 0x060090B4 RID: 37044 RVA: 0x001AC428 File Offset: 0x001AA828
		private void ClearData()
		{
			this.bOpenCountDownFunc = false;
			this.fCountDownTime = 0f;
			this.fAddUpTime = 0f;
			this.CancelBtnOriginText = string.Empty;
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
		}

		// Token: 0x060090B5 RID: 37045 RVA: 0x001AC4F7 File Offset: 0x001AA8F7
		protected void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnCurGuideStart));
		}

		// Token: 0x060090B6 RID: 37046 RVA: 0x001AC52F File Offset: 0x001AA92F
		protected void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.Pk3v3VoteEnterBattle, new ClientEventSystem.UIEventHandler(this.OnPk3v3VoteEnterBattle));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CurGuideStart, new ClientEventSystem.UIEventHandler(this.OnCurGuideStart));
		}

		// Token: 0x060090B7 RID: 37047 RVA: 0x001AC567 File Offset: 0x001AA967
		private void OnPk3v3VoteEnterBattle(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
		}

		// Token: 0x060090B8 RID: 37048 RVA: 0x001AC576 File Offset: 0x001AA976
		private void OnCurGuideStart(UIEvent iEvent)
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
		}

		// Token: 0x060090B9 RID: 37049 RVA: 0x001AC588 File Offset: 0x001AA988
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
				return;
			}
		}

		// Token: 0x060090BA RID: 37050 RVA: 0x001AC600 File Offset: 0x001AAA00
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
			else
			{
				Logger.LogErrorFormat("[msgText] is null, str = {0}", new object[]
				{
					str
				});
			}
			if (this.msgTextmini != null)
			{
				this.msgTextmini.text = str;
			}
			this.AdaptUIForMsgContent();
		}

		// Token: 0x060090BB RID: 37051 RVA: 0x001AC6A0 File Offset: 0x001AAAA0
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
		}

		// Token: 0x060090BC RID: 37052 RVA: 0x001AC6DC File Offset: 0x001AAADC
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
		}

		// Token: 0x060090BD RID: 37053 RVA: 0x001AC718 File Offset: 0x001AAB18
		public void SetbNotify(bool bFlag)
		{
			if (this.m_goCanNotifyObj != null)
			{
				this.m_goCanNotifyObj.CustomActive(bFlag);
			}
			if (this.m_goCanNotifyObjmini != null)
			{
				this.m_goCanNotifyObjmini.CustomActive(bFlag);
			}
		}

		// Token: 0x060090BE RID: 37054 RVA: 0x001AC754 File Offset: 0x001AAB54
		public void SetNotifyDataByTable(CommonTipsDesc NotifyData)
		{
			if (NotifyData != null)
			{
				if (NotifyData.ButtonText != string.Empty && NotifyData.ButtonText != "-" && NotifyData.ButtonText != "0")
				{
					this.SetOkBtnText(NotifyData.ButtonText);
				}
				if (NotifyData.CancelBtnText != string.Empty && NotifyData.CancelBtnText != "-" && NotifyData.CancelBtnText != "0")
				{
					this.SetCancelBtnText(NotifyData.CancelBtnText);
					this.CancelBtnOriginText = NotifyData.CancelBtnText;
				}
			}
		}

		// Token: 0x060090BF RID: 37055 RVA: 0x001AC809 File Offset: 0x001AAC09
		public void SetCountDownTime(float fTime)
		{
			if (fTime > 0f)
			{
				this.fCountDownTime = fTime;
				this.bOpenCountDownFunc = true;
			}
		}

		// Token: 0x060090C0 RID: 37056 RVA: 0x001AC824 File Offset: 0x001AAC24
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

		// Token: 0x060090C1 RID: 37057 RVA: 0x001AC8C5 File Offset: 0x001AACC5
		[UIEventHandle("normal/Back/Panel/btOK")]
		private void OnClickOK()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
		}

		// Token: 0x060090C2 RID: 37058 RVA: 0x001AC8D4 File Offset: 0x001AACD4
		[UIEventHandle("normal/Back/Panel/btCancel")]
		private void OnClickCancel()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
		}

		// Token: 0x060090C3 RID: 37059 RVA: 0x001AC8E3 File Offset: 0x001AACE3
		[UIEventHandle("mini/Back/Panel/btOK")]
		private void OnClickOKmini()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
		}

		// Token: 0x060090C4 RID: 37060 RVA: 0x001AC8F2 File Offset: 0x001AACF2
		[UIEventHandle("mini/Back/Panel/btCancel")]
		private void OnClickCancelmini()
		{
			this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
		}

		// Token: 0x060090C5 RID: 37061 RVA: 0x001AC901 File Offset: 0x001AAD01
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060090C6 RID: 37062 RVA: 0x001AC904 File Offset: 0x001AAD04
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.bOpenCountDownFunc)
			{
				int num = (int)this.fCountDownTime;
				if (this.CancelText != null)
				{
					this.CancelText.text = string.Format("{0}({1}s)", this.CancelBtnOriginText, num);
				}
				if (this.CancelTextmini != null)
				{
					this.CancelTextmini.text = string.Format("{0}({1}s)", this.CancelBtnOriginText, num);
				}
				this.fAddUpTime += timeElapsed;
				if (this.fAddUpTime > 1f)
				{
					this.fCountDownTime -= 1f;
					this.fAddUpTime = 0f;
				}
				if ((float)num < 0f)
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
					this.frameMgr.CloseFrame<CommonMsgBoxOKCancel>(this, false);
				}
			}
		}

		// Token: 0x040047F9 RID: 18425
		private bool bOpenCountDownFunc;

		// Token: 0x040047FA RID: 18426
		private float fCountDownTime;

		// Token: 0x040047FB RID: 18427
		private float fAddUpTime;

		// Token: 0x040047FC RID: 18428
		private string CancelBtnOriginText = string.Empty;

		// Token: 0x040047FD RID: 18429
		private CommonMsgOutData outData = new CommonMsgOutData();

		// Token: 0x040047FE RID: 18430
		[UIControl("normal/Back/TextPanel/AlertText", null, 0)]
		protected Text msgText;

		// Token: 0x040047FF RID: 18431
		[UIControl("normal/Back/Panel/btOK/Text", null, 0)]
		protected Text OKText;

		// Token: 0x04004800 RID: 18432
		[UIControl("normal/Back/Panel/btCancel/Text", null, 0)]
		protected Text CancelText;

		// Token: 0x04004801 RID: 18433
		[UIControl("normal/Back/Panel/btOK", null, 0)]
		protected Button btOK;

		// Token: 0x04004802 RID: 18434
		[UIControl("normal/Back/Panel/btCancel", null, 0)]
		protected Button btCancel;

		// Token: 0x04004803 RID: 18435
		[UIControl("normal/CanNotify", null, 0)]
		private Toggle m_togCanNotify;

		// Token: 0x04004804 RID: 18436
		[UIObject("normal/CanNotify")]
		private GameObject m_goCanNotifyObj;

		// Token: 0x04004805 RID: 18437
		[UIControl("mini/Back/TextPanel/AlertText", null, 0)]
		protected Text msgTextmini;

		// Token: 0x04004806 RID: 18438
		[UIControl("mini/Back/Panel/btOK/Text", null, 0)]
		protected Text OKTextmini;

		// Token: 0x04004807 RID: 18439
		[UIControl("mini/Back/Panel/btCancel/Text", null, 0)]
		protected Text CancelTextmini;

		// Token: 0x04004808 RID: 18440
		[UIControl("mini/Back/Panel/btOK", null, 0)]
		protected Button btOKmini;

		// Token: 0x04004809 RID: 18441
		[UIControl("mini/Back/Panel/btCancel", null, 0)]
		protected Button btCancelmini;

		// Token: 0x0400480A RID: 18442
		[UIControl("mini/CanNotify", null, 0)]
		private Toggle m_togCanNotifymini;

		// Token: 0x0400480B RID: 18443
		[UIObject("mini/CanNotify")]
		private GameObject m_goCanNotifyObjmini;

		// Token: 0x0400480C RID: 18444
		[UIObject("normal")]
		private GameObject m_goObjnormal;

		// Token: 0x0400480D RID: 18445
		[UIObject("mini")]
		private GameObject m_goObjmini;
	}
}
