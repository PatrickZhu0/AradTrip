using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000EAD RID: 3757
public class ComCountScript : MonoBehaviour
{
	// Token: 0x06009453 RID: 37971 RVA: 0x001BCCDC File Offset: 0x001BB0DC
	public void StartCount(UnityAction callback, int leftTime = 0)
	{
		this.mTime = 0f;
		this.mState = ComCountScript.CountState.Count;
		if (leftTime > 0)
		{
			this.mLeftTime = leftTime;
		}
		this.mTimeImage.enabled = true;
		this._updateLeftTime();
		if (callback != null)
		{
			this.mCallback.AddListener(callback);
		}
	}

	// Token: 0x06009454 RID: 37972 RVA: 0x001BCD2D File Offset: 0x001BB12D
	private void _updateLeftTime()
	{
		if (this.mLeftTime >= 0)
		{
			this.mTimeImage.sprite = this.mNumberSprite[this.mLeftTime % 10];
			this.mTimeImage.material = this.mNumberMaterial;
		}
	}

	// Token: 0x17001906 RID: 6406
	// (get) Token: 0x06009455 RID: 37973 RVA: 0x001BCD67 File Offset: 0x001BB167
	public ComCountScript.CountState State
	{
		get
		{
			return this.mState;
		}
	}

	// Token: 0x06009456 RID: 37974 RVA: 0x001BCD6F File Offset: 0x001BB16F
	public void Show(bool flag)
	{
		if (this.mTimeImage != null)
		{
			this.mTimeImage.enabled = flag;
		}
	}

	// Token: 0x06009457 RID: 37975 RVA: 0x001BCD90 File Offset: 0x001BB190
	public void SetMTimeImage(int leftSecond)
	{
		if (this.mTimeImage != null && this.mNumberSprite != null && leftSecond >= 0 && leftSecond < this.mNumberSprite.Length)
		{
			this.mTimeImage.sprite = this.mNumberSprite[leftSecond];
			this.mTimeImage.material = this.mNumberMaterial;
		}
	}

	// Token: 0x06009458 RID: 37976 RVA: 0x001BCDF4 File Offset: 0x001BB1F4
	public void Decrease()
	{
		this.mLeftTime--;
		this._updateLeftTime();
		if (this.mTime > 0f)
		{
			this.mTime = 0f;
		}
		if (this.mLeftTime <= 0)
		{
			if (this.mCallback != null)
			{
				try
				{
					this.mCallback.Invoke();
				}
				catch (Exception ex)
				{
				}
			}
			if (null != this.mTimeImage)
			{
				this.mTimeImage.enabled = false;
			}
			this.mState = ComCountScript.CountState.None;
		}
	}

	// Token: 0x06009459 RID: 37977 RVA: 0x001BCE94 File Offset: 0x001BB294
	public void StopCount()
	{
		this.mState = ComCountScript.CountState.None;
		this.mTimeImage.enabled = false;
	}

	// Token: 0x0600945A RID: 37978 RVA: 0x001BCEA9 File Offset: 0x001BB2A9
	public void PauseCount()
	{
		this.mState = ComCountScript.CountState.Pause;
		this.mTimeImage.enabled = false;
	}

	// Token: 0x0600945B RID: 37979 RVA: 0x001BCEBE File Offset: 0x001BB2BE
	public void ResumeCount()
	{
		this.mState = ComCountScript.CountState.Count;
		this.mTimeImage.enabled = true;
	}

	// Token: 0x0600945C RID: 37980 RVA: 0x001BCED4 File Offset: 0x001BB2D4
	private void Update()
	{
		if (this.mState != ComCountScript.CountState.Count)
		{
			return;
		}
		this.mTime += Time.deltaTime;
		if (this.mTime > 1f)
		{
			this.mTime -= 1f;
			this.Decrease();
		}
	}

	// Token: 0x0600945D RID: 37981 RVA: 0x001BCF28 File Offset: 0x001BB328
	public void RebornFail()
	{
		if (this.mCallback == null)
		{
			return;
		}
		this.mCallback.Invoke();
	}

	// Token: 0x04004B16 RID: 19222
	public UnityEvent mCallback = new UnityEvent();

	// Token: 0x04004B17 RID: 19223
	public int mLeftTime;

	// Token: 0x04004B18 RID: 19224
	public Image mTimeImage;

	// Token: 0x04004B19 RID: 19225
	public Sprite[] mNumberSprite;

	// Token: 0x04004B1A RID: 19226
	public Material mNumberMaterial;

	// Token: 0x04004B1B RID: 19227
	private const float kTimeStep = 1f;

	// Token: 0x04004B1C RID: 19228
	private float mTime;

	// Token: 0x04004B1D RID: 19229
	private ComCountScript.CountState mState;

	// Token: 0x02000EAE RID: 3758
	public enum CountState
	{
		// Token: 0x04004B1F RID: 19231
		None,
		// Token: 0x04004B20 RID: 19232
		Pause,
		// Token: 0x04004B21 RID: 19233
		Count
	}
}
