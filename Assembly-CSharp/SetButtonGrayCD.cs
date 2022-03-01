using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001E8 RID: 488
public class SetButtonGrayCD : MonoBehaviour
{
	// Token: 0x06000F6A RID: 3946 RVA: 0x0004ED88 File Offset: 0x0004D188
	private void Start()
	{
		this.curTime = Time.time;
		this.lastTime = Time.time;
		this.grayStr = (int)this.ButtonCD;
		if (this.CDText)
		{
			this.CDText.text = this.grayStr.ToString() + "S";
		}
	}

	// Token: 0x06000F6B RID: 3947 RVA: 0x0004EDF0 File Offset: 0x0004D1F0
	private void Update()
	{
		if (this.BtIsOver)
		{
			base.gameObject.CustomActive(false);
			this.curTime = Time.time;
			this.lastTime = Time.time;
			return;
		}
		this.curTime = Time.time;
		if (this.curTime - this.lastTime > 1f)
		{
			this.lastTime = this.curTime;
			this.grayStr--;
			this.CDText.text = this.grayStr.ToString() + "S";
		}
		if (this.grayStr <= 0)
		{
			this.BtIsOver = true;
		}
	}

	// Token: 0x06000F6C RID: 3948 RVA: 0x0004EEA0 File Offset: 0x0004D2A0
	public void StartGrayCD()
	{
		this.BtIsOver = false;
		this.grayStr = (int)this.ButtonCD;
		base.gameObject.CustomActive(true);
		if (this.CDText)
		{
			this.CDText.text = this.grayStr.ToString() + "S";
		}
	}

	// Token: 0x04000AA8 RID: 2728
	public float ButtonCD = 5f;

	// Token: 0x04000AA9 RID: 2729
	public bool BtIsOver;

	// Token: 0x04000AAA RID: 2730
	public Text CDText;

	// Token: 0x04000AAB RID: 2731
	private float curTime;

	// Token: 0x04000AAC RID: 2732
	private float lastTime;

	// Token: 0x04000AAD RID: 2733
	private int grayStr;
}
