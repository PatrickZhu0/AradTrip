using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E6A RID: 3690
public class CStateBar : MonoBehaviour
{
	// Token: 0x0600927F RID: 37503 RVA: 0x001B3560 File Offset: 0x001B1960
	public void Awake()
	{
		this.text = base.transform.Find("board/text").GetComponent<Text>();
		this.timer = base.transform.Find("board/timer").GetComponent<Text>();
		this.slider = base.transform.Find("board/bar").GetComponent<Slider>();
		this.barImage = base.transform.Find("board/bar").GetComponent<Image>();
		this.SetActive(false);
	}

	// Token: 0x06009280 RID: 37504 RVA: 0x001B35E0 File Offset: 0x001B19E0
	public void SetActive(bool active)
	{
		if (null != this && null != this.root)
		{
			this.root.alpha = ((!active) ? 0f : 1f);
		}
	}

	// Token: 0x06009281 RID: 37505 RVA: 0x001B361F File Offset: 0x001B1A1F
	public bool GetActive()
	{
		return null != this && null != this.root && this.root.alpha == 1f;
	}

	// Token: 0x06009282 RID: 37506 RVA: 0x001B3654 File Offset: 0x001B1A54
	public void SetStateBarInfo(string t, CStateBar.eBarColor c)
	{
		if (this.text != null)
		{
			this.text.text = t;
		}
		if (this.barImage != null && (CStateBar.eBarColor)this.spriteList.Length > c)
		{
			this.barImage.sprite = this.spriteList[(int)c];
		}
	}

	// Token: 0x06009283 RID: 37507 RVA: 0x001B36B0 File Offset: 0x001B1AB0
	public void SetPercent(float percent)
	{
		if (this.slider != null)
		{
			this.slider.value = percent;
		}
	}

	// Token: 0x06009284 RID: 37508 RVA: 0x001B36D0 File Offset: 0x001B1AD0
	public void SetTimeText(int time)
	{
		if (time < 0)
		{
			this.timer.text = string.Empty;
		}
		else if (this.timer != null)
		{
			this.timer.text = ((float)time / 1000f).ToString("F1");
		}
	}

	// Token: 0x040049A8 RID: 18856
	private Text text;

	// Token: 0x040049A9 RID: 18857
	private Text timer;

	// Token: 0x040049AA RID: 18858
	private Slider slider;

	// Token: 0x040049AB RID: 18859
	private Image barImage;

	// Token: 0x040049AC RID: 18860
	public CanvasGroup root;

	// Token: 0x040049AD RID: 18861
	public Sprite[] spriteList;

	// Token: 0x02000E6B RID: 3691
	public enum eBarColor
	{
		// Token: 0x040049AF RID: 18863
		None = -1,
		// Token: 0x040049B0 RID: 18864
		Yellow,
		// Token: 0x040049B1 RID: 18865
		Red
	}
}
