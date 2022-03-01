using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000239 RID: 569
public class ControlButtonAnimationInside : MonoBehaviour
{
	// Token: 0x060012E1 RID: 4833 RVA: 0x00064A15 File Offset: 0x00062E15
	private void Start()
	{
	}

	// Token: 0x060012E2 RID: 4834 RVA: 0x00064A17 File Offset: 0x00062E17
	public void skillpress()
	{
		DOTween.To(() => this.UItrans.localScale, delegate(Vector3 x)
		{
			this.UItrans.localScale = x;
		}, this.PressScale, this.PressTime);
	}

	// Token: 0x060012E3 RID: 4835 RVA: 0x00064A44 File Offset: 0x00062E44
	public void skillup()
	{
		Tweener tweener = DOTween.To(() => this.UItrans.localScale, delegate(Vector3 x)
		{
			this.UItrans.localScale = x;
		}, this.ReleaseScale, this.ReleaseTime);
		TweenSettingsExtensions.SetEase<Tweener>(tweener, 27);
	}

	// Token: 0x060012E4 RID: 4836 RVA: 0x00064A84 File Offset: 0x00062E84
	public void OnDestroy()
	{
		if (null != this.UIOpress)
		{
			this.UIOpress.onDown.RemoveListener(new UnityAction(this.skillpress));
			this.UIOpress.onUp.RemoveListener(new UnityAction(this.skillup));
			this.UIOpress = null;
			this.UItrans = null;
		}
	}

	// Token: 0x04000C7A RID: 3194
	private ETCButton UIOpress;

	// Token: 0x04000C7B RID: 3195
	private RectTransform UItrans;

	// Token: 0x04000C7C RID: 3196
	public Vector3 PressScale = new Vector3(0.8f, 0.8f, 0.8f);

	// Token: 0x04000C7D RID: 3197
	public Vector3 ReleaseScale = new Vector3(1f, 1f, 1f);

	// Token: 0x04000C7E RID: 3198
	public float PressTime = 0.15f;

	// Token: 0x04000C7F RID: 3199
	public float ReleaseTime = 0.1f;
}
