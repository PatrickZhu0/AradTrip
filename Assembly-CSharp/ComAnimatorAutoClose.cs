using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000E6C RID: 3692
public class ComAnimatorAutoClose : MonoBehaviour
{
	// Token: 0x06009286 RID: 37510 RVA: 0x001B3753 File Offset: 0x001B1B53
	public void SetRate(float rate)
	{
		this.mRate = Mathf.Clamp01(rate);
	}

	// Token: 0x06009287 RID: 37511 RVA: 0x001B3761 File Offset: 0x001B1B61
	private void OnEnable()
	{
		this.mLeftTime = this._getTime();
		this.mSumTime = this.mLeftTime;
		this.mState = ComAnimatorAutoClose.AnimaterState.Play;
		this.mIsInvoke = false;
	}

	// Token: 0x06009288 RID: 37512 RVA: 0x001B378C File Offset: 0x001B1B8C
	private float _getTime()
	{
		float num = 0f;
		if (null == this.mAnimator)
		{
			num = this.mDefTimeLen;
		}
		else
		{
			AnimatorClipInfo[] currentAnimatorClipInfo = this.mAnimator.GetCurrentAnimatorClipInfo(0);
			int i = 0;
			int num2 = currentAnimatorClipInfo.Length;
			while (i < num2)
			{
				AnimatorClipInfo animatorClipInfo = currentAnimatorClipInfo[i];
				num += animatorClipInfo.clip.length;
				i++;
			}
		}
		return num;
	}

	// Token: 0x06009289 RID: 37513 RVA: 0x001B37FD File Offset: 0x001B1BFD
	private void _invoke()
	{
		if (!this.mIsInvoke)
		{
			this.mIsInvoke = true;
			this.mOnFinishCallback.Invoke();
			this._destroyGameObject();
			this.mState = ComAnimatorAutoClose.AnimaterState.Finish;
		}
	}

	// Token: 0x0600928A RID: 37514 RVA: 0x001B3829 File Offset: 0x001B1C29
	private void _destroyGameObject()
	{
		if (this.loadFromPool)
		{
			Singleton<CGameObjectPool>.instance.RecycleGameObject(base.gameObject);
		}
		else
		{
			Object.Destroy(base.gameObject);
		}
	}

	// Token: 0x0600928B RID: 37515 RVA: 0x001B3858 File Offset: 0x001B1C58
	private void Update()
	{
		if (this.mState == ComAnimatorAutoClose.AnimaterState.Play)
		{
			this.mLeftTime -= Time.deltaTime;
			float num = 1f - this.mLeftTime / this.mSumTime;
			if (num >= this.mRate)
			{
				this._invoke();
			}
			if (this.mLeftTime <= 0f)
			{
				this._invoke();
			}
		}
	}

	// Token: 0x040049B2 RID: 18866
	public float mDefTimeLen = 1f;

	// Token: 0x040049B3 RID: 18867
	public Animator mAnimator;

	// Token: 0x040049B4 RID: 18868
	public bool loadFromPool;

	// Token: 0x040049B5 RID: 18869
	private float mSumTime;

	// Token: 0x040049B6 RID: 18870
	private float mLeftTime;

	// Token: 0x040049B7 RID: 18871
	[Range(0f, 1f)]
	public float mRate = 1f;

	// Token: 0x040049B8 RID: 18872
	private ComAnimatorAutoClose.AnimaterState mState;

	// Token: 0x040049B9 RID: 18873
	public UnityEvent mOnFinishCallback = new UnityEvent();

	// Token: 0x040049BA RID: 18874
	private bool mIsInvoke;

	// Token: 0x02000E6D RID: 3693
	private enum AnimaterState
	{
		// Token: 0x040049BC RID: 18876
		None,
		// Token: 0x040049BD RID: 18877
		Play,
		// Token: 0x040049BE RID: 18878
		Finish
	}
}
