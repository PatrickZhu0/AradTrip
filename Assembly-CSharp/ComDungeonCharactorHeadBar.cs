using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000EC7 RID: 3783
public class ComDungeonCharactorHeadBar : MonoBehaviour, IDungeonCharactorBar
{
	// Token: 0x060094D9 RID: 38105 RVA: 0x001BF308 File Offset: 0x001BD708
	public void SetRate(float rate)
	{
		int num = this.mImageBar.Length;
		rate = Mathf.Clamp01(rate) * (float)num;
		int num2 = (int)rate;
		float fillAmount = rate - (float)num2;
		for (int i = 0; i < num2; i++)
		{
			this.mImageBar[i].fillAmount = 1f;
		}
		if (num2 != num)
		{
			this.mImageBar[num2].fillAmount = fillAmount;
		}
		for (int j = num2 + 1; j < num; j++)
		{
			this.mImageBar[j].fillAmount = 0f;
		}
	}

	// Token: 0x060094DA RID: 38106 RVA: 0x001BF395 File Offset: 0x001BD795
	public void SetBarType(eDungeonCharactorBar type)
	{
		this.mType = type;
	}

	// Token: 0x060094DB RID: 38107 RVA: 0x001BF39E File Offset: 0x001BD79E
	public eDungeonCharactorBar GetBarType()
	{
		return this.mType;
	}

	// Token: 0x060094DC RID: 38108 RVA: 0x001BF3A8 File Offset: 0x001BD7A8
	public void Show(bool isShow)
	{
		if (this.mCdGray != null)
		{
			this.mCdGray.enabled = false;
		}
		base.gameObject.CustomActive(isShow);
		if (!isShow && this.mCDText != null)
		{
			this.mCDText.text = string.Empty;
		}
	}

	// Token: 0x060094DD RID: 38109 RVA: 0x001BF405 File Offset: 0x001BD805
	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	// Token: 0x060094DE RID: 38110 RVA: 0x001BF40D File Offset: 0x001BD80D
	public void SetText(string content)
	{
		if (this.buffTxt != null)
		{
			this.buffTxt.text = content;
		}
	}

	// Token: 0x060094DF RID: 38111 RVA: 0x001BF42C File Offset: 0x001BD82C
	public void SetCdText(float cdTime)
	{
		if (this.mCdGray != null)
		{
			this.mCdGray.enabled = (cdTime != 0f);
		}
		if (this.mCDText != null)
		{
			this.mCDText.text = cdTime.ToString("#0.0");
		}
	}

	// Token: 0x04004B98 RID: 19352
	public Image[] mImageBar;

	// Token: 0x04004B99 RID: 19353
	public eDungeonCharactorBar mType;

	// Token: 0x04004B9A RID: 19354
	public Text buffTxt;

	// Token: 0x04004B9B RID: 19355
	public UIGray mCdGray;

	// Token: 0x04004B9C RID: 19356
	public Text mCDText;
}
