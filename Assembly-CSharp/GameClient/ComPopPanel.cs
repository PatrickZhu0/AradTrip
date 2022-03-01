using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000F0E RID: 3854
	public class ComPopPanel : MonoBehaviour
	{
		// Token: 0x0600967D RID: 38525 RVA: 0x001C98A4 File Offset: 0x001C7CA4
		private void Start()
		{
			this.mButtonShow.SafeAddOnClickListener(new UnityAction(this._OnButtonShowClick));
			this.mButtonHide.SafeAddOnClickListener(new UnityAction(this._OnButtonHideClick));
		}

		// Token: 0x0600967E RID: 38526 RVA: 0x001C98D4 File Offset: 0x001C7CD4
		private void OnDestroy()
		{
			this.mButtonShow.SafeRemoveOnClickListener(new UnityAction(this._OnButtonShowClick));
			this.mButtonHide.SafeRemoveOnClickListener(new UnityAction(this._OnButtonHideClick));
		}

		// Token: 0x0600967F RID: 38527 RVA: 0x001C9904 File Offset: 0x001C7D04
		private void _OnButtonShowClick()
		{
			if (this.mShowTweener == null)
			{
				this.mShowTweener = ShortcutExtensions.DOLocalMove(this.mPanelRoot, this.mShowPosition, this.mTotalSeconds, false);
				TweenSettingsExtensions.SetAutoKill<Tweener>(this.mShowTweener, false);
				TweenSettingsExtensions.OnComplete<Tweener>(this.mShowTweener, new TweenCallback(this._OnShowComplete));
			}
			else
			{
				TweenExtensions.Restart(this.mShowTweener, true);
				this.mButtonShow.enabled = false;
			}
		}

		// Token: 0x06009680 RID: 38528 RVA: 0x001C997C File Offset: 0x001C7D7C
		private void _OnShowComplete()
		{
			this.mButtonShow.enabled = true;
			this.mButtonShow.CustomActive(false);
			this.mButtonHide.CustomActive(true);
		}

		// Token: 0x06009681 RID: 38529 RVA: 0x001C99A4 File Offset: 0x001C7DA4
		private void _OnButtonHideClick()
		{
			if (this.mHideTweener == null)
			{
				this.mHideTweener = ShortcutExtensions.DOLocalMove(this.mPanelRoot, this.mHidePosition, this.mTotalSeconds, false);
				TweenSettingsExtensions.OnComplete<Tweener>(this.mHideTweener, new TweenCallback(this._OnHideComplete));
				TweenSettingsExtensions.SetAutoKill<Tweener>(this.mHideTweener, false);
			}
			else
			{
				TweenExtensions.Restart(this.mHideTweener, true);
				this.mButtonHide.enabled = false;
			}
		}

		// Token: 0x06009682 RID: 38530 RVA: 0x001C9A1C File Offset: 0x001C7E1C
		private void _OnHideComplete()
		{
			this.mButtonHide.enabled = true;
			this.mButtonShow.CustomActive(true);
			this.mButtonHide.CustomActive(false);
		}

		// Token: 0x04004D56 RID: 19798
		[SerializeField]
		private Button mButtonShow;

		// Token: 0x04004D57 RID: 19799
		[SerializeField]
		private Button mButtonHide;

		// Token: 0x04004D58 RID: 19800
		[SerializeField]
		private float mTotalSeconds;

		// Token: 0x04004D59 RID: 19801
		[SerializeField]
		private Transform mPanelRoot;

		// Token: 0x04004D5A RID: 19802
		[SerializeField]
		private Vector3 mShowPosition;

		// Token: 0x04004D5B RID: 19803
		[SerializeField]
		private Vector3 mHidePosition;

		// Token: 0x04004D5C RID: 19804
		private Tweener mHideTweener;

		// Token: 0x04004D5D RID: 19805
		private Tweener mShowTweener;
	}
}
