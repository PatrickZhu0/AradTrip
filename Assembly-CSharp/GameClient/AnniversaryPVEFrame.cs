using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001075 RID: 4213
	public sealed class AnniversaryPVEFrame : ClientFrame
	{
		// Token: 0x06009F33 RID: 40755 RVA: 0x001FCF9F File Offset: 0x001FB39F
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/AnniversaryPVEFrame";
		}

		// Token: 0x06009F34 RID: 40756 RVA: 0x001FCFA8 File Offset: 0x001FB3A8
		protected override void _bindExUI()
		{
			this.m_caption = this.mBind.GetCom<Image>("ImgCaption");
			this.m_count = this.mBind.GetCom<Text>("labCount");
			this.m_timeCtrl = this.mBind.GetCom<SimpleTimer>("timeCtrl");
			this.m_occMsg = this.mBind.GetGameObject("OccuMsg");
		}

		// Token: 0x06009F35 RID: 40757 RVA: 0x001FD00D File Offset: 0x001FB40D
		protected override void _unbindExUI()
		{
			this.m_caption = null;
			this.m_count = null;
			this.m_timeCtrl = null;
			this.m_occMsg = null;
		}

		// Token: 0x06009F36 RID: 40758 RVA: 0x001FD02C File Offset: 0x001FB42C
		protected override void _OnCloseFrame()
		{
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_CounterChangeHandler);
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_EnterGameHandler);
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_GameStartHandler);
			Singleton<UIEventManager>.GetInstance().UnRegisterUIEvent(this.m_GameUpdateHandler);
			this.m_CounterChangeHandler = null;
			this.m_EnterGameHandler = null;
			this.m_GameStartHandler = null;
			this.m_GameUpdateHandler = null;
		}

		// Token: 0x06009F37 RID: 40759 RVA: 0x001FD098 File Offset: 0x001FB498
		protected override void _OnOpenFrame()
		{
			this.m_CounterChangeHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnAnniversaryCounterChange, new UIEventNew.UIEventHandleNew.Function(this._onCountFresh));
			this.m_EnterGameHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnAnniversaryEnterGame, new UIEventNew.UIEventHandleNew.Function(this._onGameStart));
			this.m_GameStartHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnAnnviversaryGameStart, new UIEventNew.UIEventHandleNew.Function(this._onCountDownStart));
			this.m_GameUpdateHandler = Singleton<UIEventManager>.GetInstance().RegisterUIEvent(EUIEventID.OnAnniversaryTimeUpdate, new UIEventNew.UIEventHandleNew.Function(this._onGameUpdate));
		}

		// Token: 0x06009F38 RID: 40760 RVA: 0x001FD129 File Offset: 0x001FB529
		private void _onGameUpdate(UIEventNew.UIEventParamNew param)
		{
			if (this.m_timeCtrl != null)
			{
				this.m_timeCtrl.UpdateTimer(param.m_Int);
			}
		}

		// Token: 0x06009F39 RID: 40761 RVA: 0x001FD150 File Offset: 0x001FB550
		private void _onGameStart(UIEventNew.UIEventParamNew param)
		{
			TimeLimiteBattle.GameType @int = (TimeLimiteBattle.GameType)param.m_Int;
			if (@int == TimeLimiteBattle.GameType.LiveTime)
			{
				return;
			}
			if (this.m_caption != null)
			{
				this.m_caption.CustomActive(true);
				if (@int == TimeLimiteBattle.GameType.KillCount)
				{
					this.mBind.GetSprite("KillNum", ref this.m_caption);
				}
				else if (@int == TimeLimiteBattle.GameType.BehitCout)
				{
					this.mBind.GetSprite("BeHitNum", ref this.m_caption);
				}
				else if (@int == TimeLimiteBattle.GameType.CoinCount)
				{
					this.mBind.GetSprite("CoinNum", ref this.m_caption);
				}
			}
			if (this.m_count != null)
			{
				this.m_count.CustomActive(true);
			}
			if (this.m_timeCtrl != null)
			{
				this.m_timeCtrl.SetCountdown(param.m_Int2);
			}
		}

		// Token: 0x06009F3A RID: 40762 RVA: 0x001FD228 File Offset: 0x001FB628
		private void _onCountDownStart(UIEventNew.UIEventParamNew param)
		{
			if (this.m_occMsg != null)
			{
				this.m_occMsg.CustomActive(false);
			}
			if (this.m_timeCtrl != null)
			{
				this.m_timeCtrl.CustomActive(true);
				this.m_timeCtrl.SetCountdown(param.m_Int);
				this.m_timeCtrl.StartTimer();
			}
		}

		// Token: 0x06009F3B RID: 40763 RVA: 0x001FD28B File Offset: 0x001FB68B
		private void _onCountFresh(UIEventNew.UIEventParamNew param)
		{
			if (this.m_count != null)
			{
				this.m_count.text = param.m_Int.ToString();
			}
		}

		// Token: 0x040057AF RID: 22447
		private Image m_caption;

		// Token: 0x040057B0 RID: 22448
		private Text m_count;

		// Token: 0x040057B1 RID: 22449
		private SimpleTimer m_timeCtrl;

		// Token: 0x040057B2 RID: 22450
		private GameObject m_occMsg;

		// Token: 0x040057B3 RID: 22451
		private UIEventNew.UIEventHandleNew m_CounterChangeHandler;

		// Token: 0x040057B4 RID: 22452
		private UIEventNew.UIEventHandleNew m_EnterGameHandler;

		// Token: 0x040057B5 RID: 22453
		private UIEventNew.UIEventHandleNew m_GameStartHandler;

		// Token: 0x040057B6 RID: 22454
		private UIEventNew.UIEventHandleNew m_GameUpdateHandler;
	}
}
