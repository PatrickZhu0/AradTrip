using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000F27 RID: 3879
public class ComTimeLimitButton : MonoBehaviour
{
	// Token: 0x1700191F RID: 6431
	// (get) Token: 0x0600975B RID: 38747 RVA: 0x001CFE71 File Offset: 0x001CE271
	// (set) Token: 0x0600975C RID: 38748 RVA: 0x001CFE79 File Offset: 0x001CE279
	private ComTimeLimitButton.eState state
	{
		get
		{
			return this.mState;
		}
		set
		{
			if (this.mState != value)
			{
				this.mState = value;
				this._onStateChange(this.mState == ComTimeLimitButton.eState.onNormal);
			}
		}
	}

	// Token: 0x0600975D RID: 38749 RVA: 0x001CFEA0 File Offset: 0x001CE2A0
	private void _onStateChange(bool isNormal)
	{
		if (null != this.mButton)
		{
			this.mButton.interactable = isNormal;
		}
		if (null != this.mGray)
		{
			this.mGray.enabled = !isNormal;
		}
		if (null != this.mLeftTime)
		{
			this.mLeftTime.gameObject.SetActive(!isNormal);
		}
	}

	// Token: 0x0600975E RID: 38750 RVA: 0x001CFF0F File Offset: 0x001CE30F
	private void Start()
	{
		this.state = ComTimeLimitButton.eState.onNormal;
	}

	// Token: 0x0600975F RID: 38751 RVA: 0x001CFF18 File Offset: 0x001CE318
	private void Awake()
	{
		if (null != this.mButton)
		{
			this.mButton.onClick.AddListener(new UnityAction(this._onButtonClick));
		}
		this.ResetCount();
	}

	// Token: 0x06009760 RID: 38752 RVA: 0x001CFF4D File Offset: 0x001CE34D
	private void OnDestroy()
	{
		if (null != this.mButton)
		{
			this.mButton.onClick.RemoveListener(new UnityAction(this._onButtonClick));
		}
	}

	// Token: 0x06009761 RID: 38753 RVA: 0x001CFF7C File Offset: 0x001CE37C
	private void Update()
	{
		if (this.state == ComTimeLimitButton.eState.onWait)
		{
			this.mCalDelay -= Time.deltaTime;
			if (this.mCalDelay < 0f)
			{
				this.state = ComTimeLimitButton.eState.onNormal;
			}
			else if (null != this.mLeftTime)
			{
				this.mLeftTime.SetTime((int)(this.mCalDelay * 1000f));
			}
		}
	}

	// Token: 0x06009762 RID: 38754 RVA: 0x001CFFEB File Offset: 0x001CE3EB
	public void ResetCount()
	{
		this.mCurrentCount = 0;
	}

	// Token: 0x06009763 RID: 38755 RVA: 0x001CFFF4 File Offset: 0x001CE3F4
	private void _onButtonClick()
	{
		if (this.state == ComTimeLimitButton.eState.onNormal)
		{
			this.mCurrentCount++;
			if (this.mCurrentCount >= this.maxCount)
			{
				this.ResetCount();
				this.state = ComTimeLimitButton.eState.onWait;
				this.mCalDelay = this.mDelayResume;
			}
		}
	}

	// Token: 0x04004E09 RID: 19977
	public int maxCount = 1;

	// Token: 0x04004E0A RID: 19978
	public Button mButton;

	// Token: 0x04004E0B RID: 19979
	public UIGray mGray;

	// Token: 0x04004E0C RID: 19980
	public ComTime mLeftTime;

	// Token: 0x04004E0D RID: 19981
	public float mDelayResume = 5f;

	// Token: 0x04004E0E RID: 19982
	private int mCurrentCount;

	// Token: 0x04004E0F RID: 19983
	private float mCalDelay;

	// Token: 0x04004E10 RID: 19984
	private ComTimeLimitButton.eState mState = ComTimeLimitButton.eState.onNormal;

	// Token: 0x02000F28 RID: 3880
	public enum eState
	{
		// Token: 0x04004E12 RID: 19986
		onWait,
		// Token: 0x04004E13 RID: 19987
		onNormal
	}
}
