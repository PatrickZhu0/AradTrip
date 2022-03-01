using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x020045E1 RID: 17889
public class AnimationController : MonoBehaviour
{
	// Token: 0x06019298 RID: 103064 RVA: 0x000645EF File Offset: 0x000629EF
	public virtual void Initialize()
	{
		this.callback = null;
	}

	// Token: 0x06019299 RID: 103065 RVA: 0x000645F8 File Offset: 0x000629F8
	protected virtual void OnStart()
	{
	}

	// Token: 0x0601929A RID: 103066 RVA: 0x000645FA File Offset: 0x000629FA
	protected virtual void OnDestroy()
	{
		this.callback = null;
	}

	// Token: 0x0601929B RID: 103067 RVA: 0x00064603 File Offset: 0x00062A03
	public virtual float GetTotalRunTime()
	{
		return this.delayTime + this.alphaTime;
	}

	// Token: 0x0601929C RID: 103068 RVA: 0x00064612 File Offset: 0x00062A12
	public void DoPlay(UnityAction callback)
	{
		this.OnStart();
		this.callback = callback;
		base.Invoke("DoPlay", this.delayTime);
		base.Invoke("OnCallback", this.delayTime + this.alphaTime);
	}

	// Token: 0x0601929D RID: 103069 RVA: 0x0006464A File Offset: 0x00062A4A
	protected virtual void DoPlay()
	{
		base.Invoke("DoPlay", this.delayTime);
	}

	// Token: 0x0601929E RID: 103070 RVA: 0x0006465D File Offset: 0x00062A5D
	private void OnCallback()
	{
		if (this.callback != null)
		{
			this.callback.Invoke();
		}
	}

	// Token: 0x0401205F RID: 73823
	private UnityAction callback;

	// Token: 0x04012060 RID: 73824
	public float delayTime;

	// Token: 0x04012061 RID: 73825
	public float from = 1f;

	// Token: 0x04012062 RID: 73826
	public float to = 1f;

	// Token: 0x04012063 RID: 73827
	public float alphaTime = 1f;
}
