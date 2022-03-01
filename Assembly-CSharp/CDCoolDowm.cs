using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020001F1 RID: 497
public class CDCoolDowm : MonoBehaviour
{
	// Token: 0x06000FF8 RID: 4088 RVA: 0x00053DC6 File Offset: 0x000521C6
	private void Start()
	{
		this.cdImage = base.GetComponent<Image>();
		this.cdText = base.GetComponentInChildren<Text>();
	}

	// Token: 0x06000FF9 RID: 4089 RVA: 0x00053DE0 File Offset: 0x000521E0
	private void Update()
	{
		if (this.startCD)
		{
			this.timer += Time.deltaTime;
			this.surplusTime = this.totalTime - this.timer;
			if (this.surplusTime < 0f)
			{
				this.startCD = false;
				this.timer = 0f;
				base.gameObject.SetActive(false);
				return;
			}
			this.cdImage.fillAmount = this.surplusTime / this.totalTime;
			this.cdText.text = Mathf.CeilToInt(this.surplusTime).ToString();
		}
	}

	// Token: 0x06000FFA RID: 4090 RVA: 0x00053E88 File Offset: 0x00052288
	public void StartCD(float totalTime)
	{
		this.totalTime = totalTime;
		this.startCD = true;
		base.gameObject.SetActive(true);
	}

	// Token: 0x06000FFB RID: 4091 RVA: 0x00053EA4 File Offset: 0x000522A4
	public void ResetCD()
	{
		this.totalTime = 0f;
		this.startCD = true;
	}

	// Token: 0x04000AEC RID: 2796
	private Image cdImage;

	// Token: 0x04000AED RID: 2797
	private Text cdText;

	// Token: 0x04000AEE RID: 2798
	private float totalTime = 10f;

	// Token: 0x04000AEF RID: 2799
	private bool startCD;

	// Token: 0x04000AF0 RID: 2800
	public float surplusTime;

	// Token: 0x04000AF1 RID: 2801
	private float timer;
}
