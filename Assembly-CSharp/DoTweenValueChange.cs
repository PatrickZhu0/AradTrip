using System;
using DG.Tweening;
using UnityEngine;

// Token: 0x0200006C RID: 108
internal class DoTweenValueChange : MonoBehaviour
{
	// Token: 0x0600025E RID: 606 RVA: 0x00012919 File Offset: 0x00010D19
	public void Stop()
	{
		this.bStart = false;
		TweenExtensions.Kill(this.current, false);
	}

	// Token: 0x0600025F RID: 607 RVA: 0x00012930 File Offset: 0x00010D30
	public void StartAnimation()
	{
		if (this.bStart)
		{
			return;
		}
		this.bStart = true;
		this.fValue = 0f;
		if (this.onValueChanged != null)
		{
			this.onValueChanged(this.fValue);
		}
		this.DoLoop(this.iLoopTimes);
	}

	// Token: 0x06000260 RID: 608 RVA: 0x00012984 File Offset: 0x00010D84
	public void DoLoop(int iTimes = 3)
	{
		if (iTimes > 0)
		{
			iTimes--;
			this.current = DOTween.To(delegate(float x)
			{
				this.fValue = x;
			}, 0f, 1f, this.fExeTime * 1f / (float)this.iLoopTimes);
			TweenSettingsExtensions.OnUpdate<Tween>(this.current, delegate()
			{
				if (this.onValueChanged != null)
				{
					this.onValueChanged(this.fValue);
				}
			});
			TweenSettingsExtensions.OnComplete<Tween>(this.current, delegate()
			{
				this.DoLoop(iTimes);
			});
			return;
		}
		if (this.onAnimationEnd != null)
		{
			this.onAnimationEnd();
		}
		this.bStart = false;
	}

	// Token: 0x04000257 RID: 599
	private float fValue;

	// Token: 0x04000258 RID: 600
	public DoTweenValueChange.OnValueChanged onValueChanged;

	// Token: 0x04000259 RID: 601
	public DoTweenValueChange.OnAnimationEnd onAnimationEnd;

	// Token: 0x0400025A RID: 602
	public float fExeTime = 10f;

	// Token: 0x0400025B RID: 603
	public int iLoopTimes = 1;

	// Token: 0x0400025C RID: 604
	private bool bStart;

	// Token: 0x0400025D RID: 605
	private Tween current;

	// Token: 0x0200006D RID: 109
	// (Invoke) Token: 0x06000262 RID: 610
	public delegate void OnValueChanged(float value);

	// Token: 0x0200006E RID: 110
	// (Invoke) Token: 0x06000266 RID: 614
	public delegate void OnAnimationEnd();
}
