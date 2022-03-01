using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000EC8 RID: 3784
internal class ComDungeonCharactorHeadFireBar : MonoBehaviour, IDungeonCharactorBar
{
	// Token: 0x060094E1 RID: 38113 RVA: 0x001BF498 File Offset: 0x001BD898
	public void SetRate(float rate)
	{
		rate = Mathf.Clamp01(rate);
		int num = (int)(rate / 0.2f);
		for (int i = 0; i < this.mImageBarFull.Length; i++)
		{
			this.mImageBarFull[i].gameObject.CustomActive(i < num);
		}
	}

	// Token: 0x060094E2 RID: 38114 RVA: 0x001BF4E5 File Offset: 0x001BD8E5
	public void SetBarType(eDungeonCharactorBar type)
	{
		this.mType = type;
	}

	// Token: 0x060094E3 RID: 38115 RVA: 0x001BF4EE File Offset: 0x001BD8EE
	public eDungeonCharactorBar GetBarType()
	{
		return this.mType;
	}

	// Token: 0x060094E4 RID: 38116 RVA: 0x001BF4F8 File Offset: 0x001BD8F8
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

	// Token: 0x060094E5 RID: 38117 RVA: 0x001BF555 File Offset: 0x001BD955
	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	// Token: 0x060094E6 RID: 38118 RVA: 0x001BF55D File Offset: 0x001BD95D
	public void SetText(string content)
	{
		if (this.buffTxt != null)
		{
			this.buffTxt.text = content;
		}
	}

	// Token: 0x060094E7 RID: 38119 RVA: 0x001BF57C File Offset: 0x001BD97C
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

	// Token: 0x04004B9D RID: 19357
	public Image[] mImageBarFull;

	// Token: 0x04004B9E RID: 19358
	public Image[] mImageBarEmpty;

	// Token: 0x04004B9F RID: 19359
	public eDungeonCharactorBar mType;

	// Token: 0x04004BA0 RID: 19360
	public Text buffTxt;

	// Token: 0x04004BA1 RID: 19361
	public UIGray mCdGray;

	// Token: 0x04004BA2 RID: 19362
	public Text mCDText;
}
