using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E4E RID: 3662
	internal class SplashLoadingFrame : ClientFrame
	{
		// Token: 0x170018EF RID: 6383
		// (get) Token: 0x060091B9 RID: 37305 RVA: 0x001AFDC0 File Offset: 0x001AE1C0
		public bool fadeFinish
		{
			get
			{
				return this._loadingDone;
			}
		}

		// Token: 0x060091BA RID: 37306 RVA: 0x001AFDC8 File Offset: 0x001AE1C8
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060091BB RID: 37307 RVA: 0x001AFDCC File Offset: 0x001AE1CC
		protected override void _OnOpenFrame()
		{
			this._loadingDone = false;
			Color color = this._background.color;
			color.a = 0f;
			this._background.color = color;
			this.m_state = EFrameState.FadeIn;
		}

		// Token: 0x060091BC RID: 37308 RVA: 0x001AFE0B File Offset: 0x001AE20B
		protected override void _OnCloseFrame()
		{
		}

		// Token: 0x060091BD RID: 37309 RVA: 0x001AFE10 File Offset: 0x001AE210
		protected override void _OnUpdate(float timeElapsed)
		{
			if (this._background == null)
			{
				return;
			}
			Color color = this._background.color;
			if (this.m_state == EFrameState.FadeIn)
			{
				color.a += 0.07f;
				if (color.a > 1f)
				{
					color.a = 1f;
				}
				this._background.color = color;
				if (this._background.color.a >= 1f)
				{
					this.m_state = EFrameState.Open;
				}
			}
			else if (this.m_state == EFrameState.Open)
			{
				float switchProgress = Singleton<ClientSystemManager>.GetInstance().SwitchProgress;
				if (switchProgress >= 1f)
				{
					color.a -= 0.1f;
					if (color.a < 0f)
					{
						color.a = 0f;
					}
					this._background.color = color;
					if (this._background.color.a <= 0f)
					{
						this._loadingDone = true;
						this.frameMgr.CloseFrame<SplashLoadingFrame>(this, false);
					}
				}
			}
		}

		// Token: 0x060091BE RID: 37310 RVA: 0x001AFF3B File Offset: 0x001AE33B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Common/SplashLoading";
		}

		// Token: 0x040048DA RID: 18650
		protected bool _loadingDone;

		// Token: 0x040048DB RID: 18651
		[UIControl("background", null, 0)]
		private Image _background;
	}
}
