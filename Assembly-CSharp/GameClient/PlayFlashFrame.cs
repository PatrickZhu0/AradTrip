using System;

namespace GameClient
{
	// Token: 0x02000E4F RID: 3663
	internal class PlayFlashFrame : ClientFrame
	{
		// Token: 0x060091C0 RID: 37312 RVA: 0x001AFF4A File Offset: 0x001AE34A
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x060091C1 RID: 37313 RVA: 0x001AFF4D File Offset: 0x001AE34D
		protected override void _OnOpenFrame()
		{
			if (this._canPlay())
			{
				this.mFlashState = PlayFlashFrame.ePlayFlash.Playing;
				this.mDelayColseTime = this._getTime();
				this._save();
			}
			else
			{
				base.Close(false);
			}
		}

		// Token: 0x060091C2 RID: 37314 RVA: 0x001AFF80 File Offset: 0x001AE380
		private string _getKey()
		{
			object value = PlayerLocalSetting.GetValue("AccountDefault");
			return string.Format("{0}{1}", value, "kPlayFlashFrameKey");
		}

		// Token: 0x060091C3 RID: 37315 RVA: 0x001AFFA8 File Offset: 0x001AE3A8
		private bool _canPlay()
		{
			return true;
		}

		// Token: 0x060091C4 RID: 37316 RVA: 0x001AFFAB File Offset: 0x001AE3AB
		private void _save()
		{
		}

		// Token: 0x060091C5 RID: 37317 RVA: 0x001AFFAD File Offset: 0x001AE3AD
		protected override void _OnCloseFrame()
		{
			this.mFlashState = PlayFlashFrame.ePlayFlash.None;
			this.mDelayColseTime = 0f;
		}

		// Token: 0x060091C6 RID: 37318 RVA: 0x001AFFC1 File Offset: 0x001AE3C1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Comic/Comic1";
		}

		// Token: 0x060091C7 RID: 37319 RVA: 0x001AFFC8 File Offset: 0x001AE3C8
		private float _getTime()
		{
			return 0f;
		}

		// Token: 0x060091C8 RID: 37320 RVA: 0x001AFFCF File Offset: 0x001AE3CF
		[UIEventHandle("Skip")]
		private void _onSkip()
		{
			this.mFlashState = PlayFlashFrame.ePlayFlash.None;
			this.frameMgr.CloseFrame<PlayFlashFrame>(this, false);
		}

		// Token: 0x040048DC RID: 18652
		private const string kPlayFlashFrameKey = "kPlayFlashFrameKey";

		// Token: 0x040048DD RID: 18653
		private PlayFlashFrame.ePlayFlash mFlashState;

		// Token: 0x040048DE RID: 18654
		private float mDelayColseTime;

		// Token: 0x02000E50 RID: 3664
		private enum ePlayFlash
		{
			// Token: 0x040048E0 RID: 18656
			None,
			// Token: 0x040048E1 RID: 18657
			Playing
		}
	}
}
