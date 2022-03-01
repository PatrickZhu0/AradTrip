using System;
using UnityEngine;

// Token: 0x02000E65 RID: 3685
public class CHPBar : MonoBehaviour
{
	// Token: 0x06009266 RID: 37478 RVA: 0x001B2EBC File Offset: 0x001B12BC
	private void Start()
	{
		this.objBG = base.transform.Find("bg").gameObject;
		this.objBar = base.transform.Find("bar").gameObject;
		this.rectBG = this.objBG.GetComponent<RectTransform>();
		this.rectBar = this.objBar.GetComponent<RectTransform>();
		RectTransform component = base.GetComponent<RectTransform>();
		this.totalWidth = (int)component.rect.width;
		this.SetPercent(this.percent);
	}

	// Token: 0x06009267 RID: 37479 RVA: 0x001B2F49 File Offset: 0x001B1349
	private void Update()
	{
	}

	// Token: 0x06009268 RID: 37480 RVA: 0x001B2F4C File Offset: 0x001B134C
	public void SetPercent(float per)
	{
		this.percent = per;
		if (this.rectBar != null)
		{
			this.SetBarShow(this.rectBar, (int)(this.percent * (float)this.totalWidth), (int)(this.offsetPercent * (float)this.totalWidth));
		}
	}

	// Token: 0x06009269 RID: 37481 RVA: 0x001B2F9C File Offset: 0x001B139C
	private void SetBarShow(RectTransform rt, int width, int offset)
	{
		Vector2 vector = rt.offsetMin;
		vector.x = (float)offset;
		rt.offsetMin = vector;
		vector = rt.offsetMax;
		vector.x = (float)(this.totalWidth - (width + offset));
		rt.offsetMax = -vector;
	}

	// Token: 0x0400497A RID: 18810
	private RectTransform rectBG;

	// Token: 0x0400497B RID: 18811
	private RectTransform rectBar;

	// Token: 0x0400497C RID: 18812
	private GameObject objBG;

	// Token: 0x0400497D RID: 18813
	private GameObject objBar;

	// Token: 0x0400497E RID: 18814
	private int totalWidth;

	// Token: 0x0400497F RID: 18815
	private float percent = 1f;

	// Token: 0x04004980 RID: 18816
	private float offsetPercent;
}
