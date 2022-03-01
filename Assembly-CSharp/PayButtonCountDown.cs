using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001948 RID: 6472
public class PayButtonCountDown : MonoBehaviour
{
	// Token: 0x0600FBC1 RID: 64449 RVA: 0x004501CC File Offset: 0x0044E5CC
	private void Awake()
	{
		if (this.bCDOver && this.countDownText)
		{
			this.countDownText.gameObject.CustomActive(false);
		}
		this.mCDTimer = this.countdownTime;
	}

	// Token: 0x0600FBC2 RID: 64450 RVA: 0x00450208 File Offset: 0x0044E608
	private void Update()
	{
		if (!this.bCDOver && this.mCDTimer > 0)
		{
			this.mTimer += Time.unscaledDeltaTime;
			if (this.mTimer > 1f)
			{
				this.mCDTimer--;
				this.SetCountDownText();
				if (this.mCDTimer <= 1)
				{
					if (this.countDownText)
					{
						this.countDownText.gameObject.CustomActive(false);
					}
					if (this.onCDOverHandler != null)
					{
						this.onCDOverHandler();
					}
					this.bCDOver = true;
					this.mCDTimer = this.countdownTime;
				}
				this.mTimer = 0f;
			}
		}
	}

	// Token: 0x0600FBC3 RID: 64451 RVA: 0x004502C3 File Offset: 0x0044E6C3
	public void StartCountDown()
	{
		this.bCDOver = false;
		this.SetCountDownText();
	}

	// Token: 0x0600FBC4 RID: 64452 RVA: 0x004502D2 File Offset: 0x0044E6D2
	public void StopCountDown()
	{
		this.bCDOver = true;
		if (this.countDownText)
		{
			this.countDownText.gameObject.CustomActive(false);
		}
	}

	// Token: 0x0600FBC5 RID: 64453 RVA: 0x004502FC File Offset: 0x0044E6FC
	private void SetCountDownText()
	{
		if (this.countDownText)
		{
			this.countDownText.gameObject.CustomActive(true);
			this.countDownText.text = string.Format("{0}S", this.mCDTimer);
		}
	}

	// Token: 0x04009D45 RID: 40261
	public PayButtonCountDown.OnCDOverHandler onCDOverHandler;

	// Token: 0x04009D46 RID: 40262
	public int countdownTime;

	// Token: 0x04009D47 RID: 40263
	public Text countDownText;

	// Token: 0x04009D48 RID: 40264
	public bool bCDOver;

	// Token: 0x04009D49 RID: 40265
	private float mTimer;

	// Token: 0x04009D4A RID: 40266
	private int mCDTimer;

	// Token: 0x02001949 RID: 6473
	// (Invoke) Token: 0x0600FBC7 RID: 64455
	public delegate void OnCDOverHandler();
}
