using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x0200023B RID: 571
public class ControlUIAlpha : MonoBehaviour
{
	// Token: 0x060012F1 RID: 4849 RVA: 0x00064CE5 File Offset: 0x000630E5
	private void Start()
	{
		this.cg = base.GetComponent<CanvasGroup>();
	}

	// Token: 0x060012F2 RID: 4850 RVA: 0x00064CF4 File Offset: 0x000630F4
	private void TweenShow()
	{
		DOTween.To(() => this.cg.alpha, delegate(float x)
		{
			this.cg.alpha = x;
		}, this.toAlpha, this.alphaTime);
		ShortcutExtensions46.DOFade(this.cg, this.toAlpha, this.alphaTime);
	}

	// Token: 0x060012F3 RID: 4851 RVA: 0x00064D43 File Offset: 0x00063143
	private void Update()
	{
		this.delayTime -= Time.deltaTime;
		if (this.delayTime <= 0f)
		{
			this.delayTime = 0f;
			this.TweenShow();
		}
	}

	// Token: 0x04000C87 RID: 3207
	private CanvasGroup cg;

	// Token: 0x04000C88 RID: 3208
	public float delayTime;

	// Token: 0x04000C89 RID: 3209
	public float toAlpha = 1f;

	// Token: 0x04000C8A RID: 3210
	public float alphaTime = 1f;
}
