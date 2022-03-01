using System;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010D7 RID: 4311
	public sealed class RaceGameRepairFrame : ClientFrame
	{
		// Token: 0x0600A330 RID: 41776 RVA: 0x00216098 File Offset: 0x00214498
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/RaceGameRepairFrame";
		}

		// Token: 0x0600A331 RID: 41777 RVA: 0x0021609F File Offset: 0x0021449F
		protected override void _bindExUI()
		{
			this.m_second = this.mBind.GetCom<Text>("Second");
		}

		// Token: 0x0600A332 RID: 41778 RVA: 0x002160B7 File Offset: 0x002144B7
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A333 RID: 41779 RVA: 0x002160BA File Offset: 0x002144BA
		protected override void _unbindExUI()
		{
			this.m_second = null;
		}

		// Token: 0x0600A334 RID: 41780 RVA: 0x002160C4 File Offset: 0x002144C4
		protected override void _OnOpenFrame()
		{
			int num = (int)this.userData;
			this.m_CountDown = (float)num / 1000f;
			this.m_lastSecond = (int)this.m_CountDown;
			this.m_second.text = this.m_lastSecond.ToString();
		}

		// Token: 0x0600A335 RID: 41781 RVA: 0x00216114 File Offset: 0x00214514
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this.m_delayHandler.SetRemove(true);
		}

		// Token: 0x0600A336 RID: 41782 RVA: 0x00216128 File Offset: 0x00214528
		protected override void _OnUpdate(float timeElapsed)
		{
			base._OnUpdate(timeElapsed);
			this.m_CountDown -= timeElapsed;
			int num = (int)this.m_CountDown;
			if (num < 0)
			{
				num = 0;
			}
			if (this.m_lastSecond != num)
			{
				this.m_lastSecond = num;
				this.m_second.text = this.m_lastSecond.ToString();
			}
			if (this.m_CountDown <= 0f)
			{
				this.m_delayHandler = Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(0, new DelayCaller.Del(this._delayCloseSelf), 0, 0, false);
			}
		}

		// Token: 0x0600A337 RID: 41783 RVA: 0x002161BF File Offset: 0x002145BF
		private void _delayCloseSelf()
		{
			if (base.IsOpen())
			{
				base.Close(false);
			}
		}

		// Token: 0x04005AFB RID: 23291
		private Text m_second;

		// Token: 0x04005AFC RID: 23292
		private float m_durTime;

		// Token: 0x04005AFD RID: 23293
		private float m_CountDown;

		// Token: 0x04005AFE RID: 23294
		private int m_lastSecond;

		// Token: 0x04005AFF RID: 23295
		private DelayCallUnitHandle m_delayHandler;
	}
}
