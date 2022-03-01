using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200139D RID: 5021
	public class GetUltimateChallengeBufTipFrame : ClientFrame
	{
		// Token: 0x0600C304 RID: 49924 RVA: 0x002E8A0A File Offset: 0x002E6E0A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Tip/GetUltimateChallengeBufTip";
		}

		// Token: 0x0600C305 RID: 49925 RVA: 0x002E8A14 File Offset: 0x002E6E14
		protected override void _OnOpenFrame()
		{
			this.BindUIEvent();
			this.fFrameCreateTime = Time.realtimeSinceStartup;
			this.fTimeElapsed = 0f;
			this.fTimeElapsedDelay = 0f;
			this.fInterval = 0.2f;
			if (this.m_effXingGuang != null)
			{
				this.m_effXingGuang.CustomActive(false);
			}
			if (this.m_effGuanYun != null)
			{
				this.m_effGuanYun.CustomActive(false);
			}
			if (this.m_btnExit != null)
			{
				this.m_btnExit.onClick.RemoveAllListeners();
				this.m_btnExit.onClick.AddListener(delegate()
				{
					if (Time.realtimeSinceStartup - this.fFrameCreateTime < 1f)
					{
						return;
					}
					this.frameMgr.CloseFrame<GetUltimateChallengeBufTipFrame>(this, false);
				});
			}
			InvokeMethod.Invoke(this, 0.5f, delegate()
			{
			});
			this.bufItem0.CustomActive(false);
		}

		// Token: 0x0600C306 RID: 49926 RVA: 0x002E8B00 File Offset: 0x002E6F00
		private void _UpdateEffect()
		{
			if (this.m_effXingGuang != null)
			{
				this.m_effXingGuang.CustomActive(true);
			}
			if (this.m_effGuanYun != null)
			{
				this.m_effGuanYun.CustomActive(true);
			}
			if (this.bufItem0 != null)
			{
				this.bufItem0.SetBufData(DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeInspireBufID(), DataManager<ActivityDataManager>.GetInstance().GetUltimateChallengeInspireBufLv());
				this.bufItem0.CustomActive(true);
			}
		}

		// Token: 0x0600C307 RID: 49927 RVA: 0x002E8B83 File Offset: 0x002E6F83
		protected override void _OnCloseFrame()
		{
			InvokeMethod.RemoveInvokeCall(this);
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshInspireBufSuccess, null, null, null, null);
		}

		// Token: 0x0600C308 RID: 49928 RVA: 0x002E8BA4 File Offset: 0x002E6FA4
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600C309 RID: 49929 RVA: 0x002E8BA8 File Offset: 0x002E6FA8
		protected override void _OnUpdate(float timeElapsed)
		{
			this.fTimeElapsedDelay += timeElapsed;
			this.fTimeElapsed += timeElapsed;
			if (this.fTimeElapsedDelay >= 0.5f && this.fTimeElapsed >= this.fInterval)
			{
				this.fTimeElapsed = 0f;
				this._UpdateEffect();
			}
			if (this.goDesc != null && this.goBg3 != null)
			{
				Vector3 localPosition = this.goDesc.transform.localPosition;
				localPosition.y = this.goBg3.transform.localPosition.y - this.goBg3.transform.GetComponent<RectTransform>().sizeDelta.y - 40f;
				this.goDesc.transform.localPosition = localPosition;
			}
		}

		// Token: 0x0600C30A RID: 49930 RVA: 0x002E8C8A File Offset: 0x002E708A
		protected override void _bindExUI()
		{
			this.bufItem0 = this.mBind.GetCom<ComBufItem>("bufItem0");
		}

		// Token: 0x0600C30B RID: 49931 RVA: 0x002E8CA2 File Offset: 0x002E70A2
		protected override void _unbindExUI()
		{
			this.bufItem0 = null;
		}

		// Token: 0x0600C30C RID: 49932 RVA: 0x002E8CAB File Offset: 0x002E70AB
		private void BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.FirstPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnFirstPayFrameOpen));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SecondPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnSecondPayFrameOpen));
		}

		// Token: 0x0600C30D RID: 49933 RVA: 0x002E8CE3 File Offset: 0x002E70E3
		private void UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.FirstPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnFirstPayFrameOpen));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SecondPayFrameOpen, new ClientEventSystem.UIEventHandler(this._OnSecondPayFrameOpen));
		}

		// Token: 0x0600C30E RID: 49934 RVA: 0x002E8D1C File Offset: 0x002E711C
		private void _OnFirstPayFrameOpen(UIEvent uiEvent)
		{
			FirstPayFrame firstPayFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(FirstPayFrame)) as FirstPayFrame;
			if (firstPayFrame == null)
			{
				return;
			}
			GameObject frame = firstPayFrame.GetFrame();
			if (firstPayFrame != null && frame != null)
			{
				this.frame.transform.SetSiblingIndex(frame.transform.GetSiblingIndex() + 1);
			}
		}

		// Token: 0x0600C30F RID: 49935 RVA: 0x002E8D80 File Offset: 0x002E7180
		private void _OnSecondPayFrameOpen(UIEvent uiEvent)
		{
			SecondPayFrame secondPayFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(SecondPayFrame)) as SecondPayFrame;
			if (secondPayFrame == null)
			{
				return;
			}
			GameObject frame = secondPayFrame.GetFrame();
			if (secondPayFrame != null && frame != null)
			{
				this.frame.transform.SetSiblingIndex(frame.transform.GetSiblingIndex() + 1);
			}
		}

		// Token: 0x04006E66 RID: 28262
		[UIObject("EffUI_gongxihuode_guangyun")]
		private GameObject m_effGuanYun;

		// Token: 0x04006E67 RID: 28263
		[UIObject("EffUI_gongxihuode_xingguang")]
		private GameObject m_effXingGuang;

		// Token: 0x04006E68 RID: 28264
		[UIControl("btnExit", null, 0)]
		private Button m_btnExit;

		// Token: 0x04006E69 RID: 28265
		[UIObject("Desc")]
		private GameObject goDesc;

		// Token: 0x04006E6A RID: 28266
		[UIObject("BG (3)")]
		private GameObject goBg3;

		// Token: 0x04006E6B RID: 28267
		private ComBufItem bufItem0;

		// Token: 0x04006E6C RID: 28268
		private float fFrameCreateTime = Time.realtimeSinceStartup;

		// Token: 0x04006E6D RID: 28269
		private const float fInterval1 = 0.2f;

		// Token: 0x04006E6E RID: 28270
		private const float fInterval2 = 0.1f;

		// Token: 0x04006E6F RID: 28271
		private const float fDelayTime = 0.5f;

		// Token: 0x04006E70 RID: 28272
		private float fTimeElapsed;

		// Token: 0x04006E71 RID: 28273
		private float fTimeElapsedDelay;

		// Token: 0x04006E72 RID: 28274
		private float fInterval;
	}
}
