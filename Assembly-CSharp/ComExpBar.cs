using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000EE4 RID: 3812
public class ComExpBar : MonoBehaviour
{
	// Token: 0x1700190A RID: 6410
	// (get) Token: 0x06009578 RID: 38264 RVA: 0x001C37B8 File Offset: 0x001C1BB8
	// (set) Token: 0x06009579 RID: 38265 RVA: 0x001C37C0 File Offset: 0x001C1BC0
	public ComExpBar.TextFormatter TextFormat { get; set; }

	// Token: 0x0600957A RID: 38266 RVA: 0x001C37C9 File Offset: 0x001C1BC9
	public void Awake()
	{
		this.mTotalExp = 0UL;
		this.mMaxBarCount = Mathf.Max(this.mImageBar.Length, this.mExpBarRateCallbacks.Length);
	}

	// Token: 0x0600957B RID: 38267 RVA: 0x001C37EE File Offset: 0x001C1BEE
	public void OnDestroy()
	{
		this.mExpBarCallback = null;
		this.mTweener = null;
	}

	// Token: 0x0600957C RID: 38268 RVA: 0x001C3800 File Offset: 0x001C1C00
	private void _updateText(ulong curExp, ulong curSum, ulong a_uTotalExp)
	{
		if (null != this.mExpText)
		{
			if (this.TextFormat != null)
			{
				this.mExpText.text = this.TextFormat(a_uTotalExp);
			}
			else if (curSum == 0UL)
			{
				this.mExpText.text = "满级";
			}
			else
			{
				this.mExpText.text = string.Format("{0}/{1}", curExp, curSum);
			}
		}
	}

	// Token: 0x0600957D RID: 38269 RVA: 0x001C3883 File Offset: 0x001C1C83
	private void _callCB(int idx, float rate)
	{
		if (idx >= 0 && idx < this.mExpBarRateCallbacks.Length)
		{
			this.mExpBarRateCallbacks[idx].Invoke(rate);
		}
	}

	// Token: 0x0600957E RID: 38270 RVA: 0x001C38A8 File Offset: 0x001C1CA8
	private void _callCBImage(int idx, float rate)
	{
		if (idx >= 0 && idx < this.mImageBar.Length)
		{
			this.mImageBar[idx].fillAmount = rate;
		}
	}

	// Token: 0x0600957F RID: 38271 RVA: 0x001C38D0 File Offset: 0x001C1CD0
	public void SetRate(float rate)
	{
		rate = Mathf.Clamp01(rate) * (float)this.mMaxBarCount;
		int num = (int)rate;
		float rate2 = rate - (float)num;
		for (int i = 0; i < num; i++)
		{
			this._callCB(i, 1f);
			this._callCBImage(i, 1f);
		}
		if (num != this.mMaxBarCount)
		{
			this._callCB(num, rate2);
			this._callCBImage(num, rate2);
		}
		for (int j = num + 1; j < this.mMaxBarCount; j++)
		{
			this._callCB(j, 0f);
			this._callCBImage(j, 0f);
		}
	}

	// Token: 0x06009580 RID: 38272 RVA: 0x001C3974 File Offset: 0x001C1D74
	private void _updateExp(ulong exp)
	{
		KeyValuePair<ulong, ulong> keyValuePair = new KeyValuePair<ulong, ulong>(0UL, 0UL);
		if (this.mExpBarCallback != null)
		{
			try
			{
				keyValuePair = this.mExpBarCallback(exp);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("exp bar error {0}", new object[]
				{
					ex.ToString()
				});
			}
		}
		this._updateText(keyValuePair.Key, keyValuePair.Value, exp);
		if (keyValuePair.Key == 0UL && keyValuePair.Value == 0UL)
		{
			this.SetRate(1f);
		}
		else
		{
			this.SetRate(1f * keyValuePair.Key / keyValuePair.Value);
		}
		this.mTotalExp = exp;
	}

	// Token: 0x06009581 RID: 38273 RVA: 0x001C3A40 File Offset: 0x001C1E40
	public void SetExp(ulong exp, bool force = true, ComExpBar.ExpBarCallback cb = null)
	{
		this.mExpBarCallback = cb;
		if (force || this.mTotalExp == 0UL || this.mTotalExp > exp)
		{
			this._updateExp(exp);
		}
		else if (this.mTweener != null && TweenExtensions.IsActive(this.mTweener))
		{
			this.mTweener.ChangeStartValue(this.mTotalExp, -1f);
			this.mTweener.ChangeEndValue(exp, -1f, false);
			TweenExtensions.Restart(this.mTweener, true);
		}
		else
		{
			this.mTweener = DOTween.To(() => this.mTotalExp, new DOSetter<ulong>(this._updateExp), exp, this.mTweenTime);
			TweenSettingsExtensions.SetDelay<Tweener>(this.mTweener, this.mDelayTime);
		}
	}

	// Token: 0x04004C73 RID: 19571
	private int mMaxBarCount = 10;

	// Token: 0x04004C74 RID: 19572
	public float mDelayTime;

	// Token: 0x04004C75 RID: 19573
	public float mTweenTime = 0.5f;

	// Token: 0x04004C76 RID: 19574
	public Color mImageColor = new Color(1f, 0.2784314f, 0f);

	// Token: 0x04004C77 RID: 19575
	private ComExpBar.ExpBarCallback mExpBarCallback;

	// Token: 0x04004C79 RID: 19577
	[SerializeField]
	public ComExpBar.ExpBarRate[] mExpBarRateCallbacks = new ComExpBar.ExpBarRate[0];

	// Token: 0x04004C7A RID: 19578
	public Image[] mImageBar = new Image[0];

	// Token: 0x04004C7B RID: 19579
	public Text mExpText;

	// Token: 0x04004C7C RID: 19580
	private Tweener mTweener;

	// Token: 0x04004C7D RID: 19581
	[Range(0f, 1f)]
	[NonSerialized]
	public float mRate;

	// Token: 0x04004C7E RID: 19582
	private ulong mTotalExp;

	// Token: 0x02000EE5 RID: 3813
	// (Invoke) Token: 0x06009584 RID: 38276
	public delegate KeyValuePair<ulong, ulong> ExpBarCallback(ulong exp);

	// Token: 0x02000EE6 RID: 3814
	// (Invoke) Token: 0x06009588 RID: 38280
	public delegate string TextFormatter(ulong a_uExp);

	// Token: 0x02000EE7 RID: 3815
	[Serializable]
	public class ExpBarRate : UnityEvent<float>
	{
	}
}
