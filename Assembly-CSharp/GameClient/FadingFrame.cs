using System;

namespace GameClient
{
	// Token: 0x02000E46 RID: 3654
	internal class FadingFrame : ClientFrame, ITownFadingFrame
	{
		// Token: 0x170018EB RID: 6379
		// (get) Token: 0x06009187 RID: 37255 RVA: 0x001AF1E6 File Offset: 0x001AD5E6
		public int CurrentProgress
		{
			get
			{
				return -1;
			}
		}

		// Token: 0x06009188 RID: 37256 RVA: 0x001AF1E9 File Offset: 0x001AD5E9
		protected override void _OnOpenFrame()
		{
			this.m_fadeEffect = this.frame.GetComponent<ComFadeEffect>();
		}

		// Token: 0x06009189 RID: 37257 RVA: 0x001AF1FC File Offset: 0x001AD5FC
		protected override void _OnCloseFrame()
		{
			this.m_fadeEffect = null;
		}

		// Token: 0x0600918A RID: 37258 RVA: 0x001AF205 File Offset: 0x001AD605
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/FadingFrame";
		}

		// Token: 0x0600918B RID: 37259 RVA: 0x001AF20C File Offset: 0x001AD60C
		public void FadingIn(float time = 1f)
		{
			if (this.m_fadeEffect != null)
			{
				this.m_state = EFrameState.FadeIn;
				this.m_fadeEffect.FadeInTime = time;
				this.m_fadeEffect.OnFadeIn.AddListener(delegate()
				{
					this.m_state = EFrameState.Open;
				});
				this.m_fadeEffect.FadeIn();
			}
		}

		// Token: 0x0600918C RID: 37260 RVA: 0x001AF264 File Offset: 0x001AD664
		public bool IsOpened()
		{
			return this.m_state == EFrameState.Open;
		}

		// Token: 0x0600918D RID: 37261 RVA: 0x001AF26F File Offset: 0x001AD66F
		public bool IsClosed()
		{
			return this.m_state == EFrameState.Close;
		}

		// Token: 0x0600918E RID: 37262 RVA: 0x001AF27C File Offset: 0x001AD67C
		public void FadingOut(float time = 1f)
		{
			if (this.m_fadeEffect != null)
			{
				this.m_state = EFrameState.FadeOut;
				this.m_fadeEffect.FadeOutTime = time;
				this.m_fadeEffect.OnFadeOut.AddListener(delegate()
				{
					this.frameMgr.CloseFrame<FadingFrame>(this, false);
				});
				this.m_fadeEffect.FadeOut();
			}
		}

		// Token: 0x040048C5 RID: 18629
		private ComFadeEffect m_fadeEffect;
	}
}
