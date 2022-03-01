using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E7 RID: 487
public class SetButtonCD : MonoBehaviour
{
	// Token: 0x06000F66 RID: 3942 RVA: 0x0004EBBD File Offset: 0x0004CFBD
	private void Start()
	{
		this.BtIsWork = true;
		this.curTime = 0f;
		this.lastTime = 0f;
	}

	// Token: 0x06000F67 RID: 3943 RVA: 0x0004EBDC File Offset: 0x0004CFDC
	private void Update()
	{
		if (this.BtIsWork)
		{
			this.curTime = Time.time;
			this.lastTime = Time.time;
			if (this.uiGray != null && this.btn != null)
			{
				this.uiGray.enabled = false;
				this.btn.interactable = true;
			}
			return;
		}
		this.curTime = Time.time;
		if (this.curTime - this.lastTime > this.ButtonCD)
		{
			this.lastTime = this.curTime;
			this.BtIsWork = true;
			if (this.oldText != null && this.oldText != string.Empty)
			{
				this.mText.text = this.oldText;
			}
		}
		else
		{
			float num = this.ButtonCD - (this.curTime - this.lastTime);
			int num2 = (int)num;
			if (this.mText != null)
			{
				this.mText.text = this.oldText + num2.ToString() + "S";
			}
		}
	}

	// Token: 0x06000F68 RID: 3944 RVA: 0x0004ED04 File Offset: 0x0004D104
	public void StartBtCD()
	{
		this.BtIsWork = false;
		if (this.uiGray != null && this.btn != null && this.mText != null)
		{
			this.uiGray.enabled = true;
			this.btn.interactable = false;
			this.oldText = this.mText.text;
		}
	}

	// Token: 0x04000AA0 RID: 2720
	public float ButtonCD = 0.5f;

	// Token: 0x04000AA1 RID: 2721
	public bool BtIsWork;

	// Token: 0x04000AA2 RID: 2722
	public UIGray uiGray;

	// Token: 0x04000AA3 RID: 2723
	public Button btn;

	// Token: 0x04000AA4 RID: 2724
	public Text mText;

	// Token: 0x04000AA5 RID: 2725
	private float curTime;

	// Token: 0x04000AA6 RID: 2726
	private float lastTime;

	// Token: 0x04000AA7 RID: 2727
	private string oldText;
}
