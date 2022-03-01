using System;
using UnityEngine;

// Token: 0x02000230 RID: 560
[ExecuteInEditMode]
public class AutoPlay : MonoBehaviour
{
	// Token: 0x060012A3 RID: 4771 RVA: 0x00063F6F File Offset: 0x0006236F
	private void Start()
	{
	}

	// Token: 0x060012A4 RID: 4772 RVA: 0x00063F71 File Offset: 0x00062371
	private void Awake()
	{
		this.ans = base.gameObject.GetComponentsInChildren<Animation>(true);
		this.pss = base.gameObject.GetComponentsInChildren<ParticleSystem>(true);
		this.animators = base.gameObject.GetComponentsInChildren<Animator>(true);
	}

	// Token: 0x060012A5 RID: 4773 RVA: 0x00063FA9 File Offset: 0x000623A9
	private void OnEnable()
	{
		this.Play();
	}

	// Token: 0x060012A6 RID: 4774 RVA: 0x00063FB4 File Offset: 0x000623B4
	private void Play()
	{
		if (base.gameObject == null)
		{
			return;
		}
		foreach (ParticleSystem particleSystem in this.pss)
		{
			if (particleSystem)
			{
				particleSystem.Play();
			}
		}
		foreach (Animation animation in this.ans)
		{
			if (animation)
			{
				animation.Play();
			}
		}
		if (this.animators != null)
		{
			foreach (Animator animator in this.animators)
			{
				if (animator != null)
				{
					int fullPathHash = animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
					animator.Play(fullPathHash);
				}
			}
		}
	}

	// Token: 0x04000C5D RID: 3165
	protected Animation[] ans;

	// Token: 0x04000C5E RID: 3166
	protected ParticleSystem[] pss;

	// Token: 0x04000C5F RID: 3167
	protected Animator[] animators;

	// Token: 0x04000C60 RID: 3168
	protected bool _play;
}
