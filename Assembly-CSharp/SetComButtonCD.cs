using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E9 RID: 489
public class SetComButtonCD : MonoBehaviour
{
	// Token: 0x06000F6E RID: 3950 RVA: 0x0004EF2C File Offset: 0x0004D32C
	private void Start()
	{
		this.mBtIsWork = true;
		this.timer = 0f;
		this.bDirty = false;
	}

	// Token: 0x06000F6F RID: 3951 RVA: 0x0004EF48 File Offset: 0x0004D348
	private void Update()
	{
		if (!this.bDirty)
		{
			return;
		}
		if (this.mBtIsWork)
		{
			this.timer = 0f;
			if (this.needBtnGray && this.mUiGray != null)
			{
				this.mUiGray.enabled = false;
			}
			if (this.needBtnInteractable && this.mBtn != null)
			{
				this.mBtn.interactable = true;
			}
			this.bDirty = false;
			return;
		}
		if (this.timer < this.mButtonCD)
		{
			float num = this.mButtonCD - this.timer;
			int num2 = (int)num + 1;
			if (this.mText != null)
			{
				this.mText.text = this.oldText + num2.ToString() + this.mFormatStr;
			}
			this.timer += Time.deltaTime;
		}
		else
		{
			this.mBtIsWork = true;
			if (this.mText)
			{
				this.mText.text = this.oldText;
			}
		}
	}

	// Token: 0x06000F70 RID: 3952 RVA: 0x0004F06C File Offset: 0x0004D46C
	public void StartBtCD()
	{
		if (this.needBtnGray && this.mUiGray != null)
		{
			this.mUiGray.enabled = true;
		}
		if (this.needBtnInteractable && this.mBtn != null)
		{
			this.mBtn.interactable = false;
		}
		if (this.mText)
		{
			this.oldText = this.mText.text;
		}
		this.mBtIsWork = false;
		this.bDirty = true;
	}

	// Token: 0x06000F71 RID: 3953 RVA: 0x0004F0F8 File Offset: 0x0004D4F8
	public void StopBtCD()
	{
		if (this.needBtnGray && this.mUiGray != null)
		{
			this.mUiGray.enabled = false;
		}
		if (this.needBtnInteractable && this.mBtn != null)
		{
			this.mBtn.interactable = true;
		}
		if (this.mText)
		{
			this.oldText = this.mText.text;
		}
		this.mBtIsWork = true;
		this.bDirty = false;
	}

	// Token: 0x06000F72 RID: 3954 RVA: 0x0004F184 File Offset: 0x0004D584
	public bool IsBtnWork()
	{
		return this.mBtIsWork;
	}

	// Token: 0x04000AAE RID: 2734
	[SerializeField]
	private float mButtonCD = 0.5f;

	// Token: 0x04000AAF RID: 2735
	[SerializeField]
	private bool mBtIsWork;

	// Token: 0x04000AB0 RID: 2736
	[SerializeField]
	private UIGray mUiGray;

	// Token: 0x04000AB1 RID: 2737
	[SerializeField]
	private Button mBtn;

	// Token: 0x04000AB2 RID: 2738
	[SerializeField]
	private Text mText;

	// Token: 0x04000AB3 RID: 2739
	[SerializeField]
	private string mFormatStr = "s";

	// Token: 0x04000AB4 RID: 2740
	[SerializeField]
	private bool needBtnInteractable;

	// Token: 0x04000AB5 RID: 2741
	[SerializeField]
	private bool needBtnGray;

	// Token: 0x04000AB6 RID: 2742
	private float timer;

	// Token: 0x04000AB7 RID: 2743
	private string oldText = string.Empty;

	// Token: 0x04000AB8 RID: 2744
	private bool bDirty;
}
