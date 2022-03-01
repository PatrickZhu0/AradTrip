using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F2A RID: 3882
public class ComTipsUnit : MonoBehaviour
{
	// Token: 0x0600976C RID: 38764 RVA: 0x001D0245 File Offset: 0x001CE645
	public void SetPercent(float percent)
	{
		if (null != this.mFg)
		{
			this.mFg.fillAmount = Mathf.Clamp01(1f - percent);
		}
	}

	// Token: 0x0600976D RID: 38765 RVA: 0x001D026F File Offset: 0x001CE66F
	public void SetSprite(Sprite sprite)
	{
		if (null != this.mIcon)
		{
			this.mIcon.sprite = sprite;
		}
	}

	// Token: 0x0600976E RID: 38766 RVA: 0x001D028E File Offset: 0x001CE68E
	public void SetCount(int count)
	{
		if (null != this.mCount)
		{
			this.mCount.text = count.ToString();
		}
	}

	// Token: 0x0600976F RID: 38767 RVA: 0x001D02B9 File Offset: 0x001CE6B9
	public void SetType()
	{
	}

	// Token: 0x04004E1A RID: 19994
	public Image mFg;

	// Token: 0x04004E1B RID: 19995
	public Image mIcon;

	// Token: 0x04004E1C RID: 19996
	public Text mCount;
}
