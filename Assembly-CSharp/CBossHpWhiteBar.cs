using System;
using UnityEngine;
using UnityEngine.Events;

// Token: 0x02000E63 RID: 3683
[ExecuteInEditMode]
public class CBossHpWhiteBar : MonoBehaviour
{
	// Token: 0x06009261 RID: 37473 RVA: 0x001B2BAC File Offset: 0x001B0FAC
	public void SetValue(float minValue, float maxValue)
	{
		maxValue = (this.mMaxValue = Mathf.Clamp01(maxValue));
		minValue = (this.mMinValue = Mathf.Clamp01(minValue));
		if (null != this.mLeft)
		{
			this.mLeft.offsetMin = Vector2.zero;
			this.mLeft.offsetMax = Vector2.zero;
		}
		if (null != this.mRight)
		{
			this.mRight.offsetMin = Vector2.zero;
			this.mRight.offsetMax = Vector2.zero;
		}
		if (minValue > maxValue)
		{
			if (null != this.mLeft)
			{
				this.mLeft.anchorMin = new Vector2(0f, 0f);
				this.mLeft.anchorMax = new Vector2(maxValue, 1f);
			}
			if (null != this.mRight)
			{
				this.mRight.anchorMin = new Vector2(minValue, 0f);
				this.mRight.anchorMax = new Vector2(1f, 1f);
			}
		}
		else
		{
			if (null != this.mLeft)
			{
				this.mLeft.anchorMin = new Vector2(minValue, 0f);
				this.mLeft.anchorMax = new Vector2(maxValue, 1f);
			}
			if (null != this.mRight)
			{
				this.mRight.anchorMin = new Vector2(0f, 0f);
				this.mRight.anchorMax = new Vector2(0f, 1f);
			}
		}
	}

	// Token: 0x06009262 RID: 37474 RVA: 0x001B2D4C File Offset: 0x001B114C
	public void SetMinValue(float minValue)
	{
		if (this.mMinValue < this.mMaxValue && this.mMinValue > minValue)
		{
			this.mMinValue = minValue;
			if (null != this.mLeft)
			{
				this.mLeft.anchorMin = new Vector2(minValue, 0f);
			}
		}
	}

	// Token: 0x06009263 RID: 37475 RVA: 0x001B2DA4 File Offset: 0x001B11A4
	public void StartFadeOut(float timeout, UnityAction fn)
	{
		this.mState = CBossHpWhiteBar.eState.Start;
		this.mTimeOut = timeout;
		this.mTimeCount = timeout;
		this.mTimeOutCallback = fn;
		if (null != this.mGroup)
		{
			this.mGroup.alpha = 1f;
		}
	}

	// Token: 0x06009264 RID: 37476 RVA: 0x001B2DE4 File Offset: 0x001B11E4
	public void Update()
	{
		if (this.mState == CBossHpWhiteBar.eState.Start)
		{
			if (this.mTimeCount > 0f)
			{
				this.mTimeCount -= Time.deltaTime;
				float num = this.mTimeCount / this.mTimeOut;
				float num2 = this.fadeOutCurve.Evaluate(num);
				if (null != this.mGroup)
				{
					this.mGroup.alpha = num2 * 1f;
				}
			}
			else
			{
				if (null != this.mGroup)
				{
					this.mGroup.alpha = 0f;
				}
				if (this.mTimeOutCallback != null)
				{
					this.mTimeOutCallback.Invoke();
					this.mTimeOutCallback = null;
				}
				this.mState = CBossHpWhiteBar.eState.End;
			}
		}
	}

	// Token: 0x0400496C RID: 18796
	public RectTransform mLeft;

	// Token: 0x0400496D RID: 18797
	public RectTransform mRight;

	// Token: 0x0400496E RID: 18798
	public CanvasGroup mGroup;

	// Token: 0x0400496F RID: 18799
	public AnimationCurve fadeOutCurve;

	// Token: 0x04004970 RID: 18800
	private float mMinValue;

	// Token: 0x04004971 RID: 18801
	private float mMaxValue;

	// Token: 0x04004972 RID: 18802
	private float mTimeOut;

	// Token: 0x04004973 RID: 18803
	private float mTimeCount;

	// Token: 0x04004974 RID: 18804
	private UnityAction mTimeOutCallback;

	// Token: 0x04004975 RID: 18805
	private CBossHpWhiteBar.eState mState;

	// Token: 0x02000E64 RID: 3684
	private enum eState
	{
		// Token: 0x04004977 RID: 18807
		None,
		// Token: 0x04004978 RID: 18808
		Start,
		// Token: 0x04004979 RID: 18809
		End
	}
}
