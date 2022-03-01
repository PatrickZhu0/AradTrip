using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x02000236 RID: 566
[RequireComponent(typeof(CanvasGroup))]
public class ControlAlphaDoTween : AnimationController
{
	// Token: 0x060012CF RID: 4815 RVA: 0x0006467D File Offset: 0x00062A7D
	public override void Initialize()
	{
		this.canvasGroup = base.GetComponent<CanvasGroup>();
		if (this.canvasGroup != null)
		{
			this.canvasGroup.alpha = this.from;
		}
	}

	// Token: 0x060012D0 RID: 4816 RVA: 0x000646AD File Offset: 0x00062AAD
	protected override void OnStart()
	{
		if (this.canvasGroup != null)
		{
			this.canvasGroup.alpha = this.from;
		}
	}

	// Token: 0x060012D1 RID: 4817 RVA: 0x000646D4 File Offset: 0x00062AD4
	protected override void DoPlay()
	{
		if (this.canvasGroup != null)
		{
			DOTween.To(() => this.canvasGroup.alpha, delegate(float x)
			{
				this.canvasGroup.alpha = x;
			}, this.to, this.alphaTime);
			ShortcutExtensions46.DOFade(this.canvasGroup, this.to, this.alphaTime);
		}
	}

	// Token: 0x04000C6F RID: 3183
	private CanvasGroup canvasGroup;
}
