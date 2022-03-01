using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000EC5 RID: 3781
public class ComDungeonCharactorBar : MonoBehaviour, IDungeonCharactorBar
{
	// Token: 0x060094CD RID: 38093 RVA: 0x001BF23A File Offset: 0x001BD63A
	public void SetRate(float percent)
	{
		if (null != this.mProcessBar)
		{
			this.mProcessBar.fillAmount = Mathf.Clamp01(percent);
		}
	}

	// Token: 0x060094CE RID: 38094 RVA: 0x001BF25E File Offset: 0x001BD65E
	public void SetBarType(eDungeonCharactorBar type)
	{
		this.mType = type;
	}

	// Token: 0x060094CF RID: 38095 RVA: 0x001BF267 File Offset: 0x001BD667
	public eDungeonCharactorBar GetBarType()
	{
		return this.mType;
	}

	// Token: 0x060094D0 RID: 38096 RVA: 0x001BF26F File Offset: 0x001BD66F
	public void Show(bool isShow)
	{
		base.gameObject.CustomActive(isShow);
	}

	// Token: 0x060094D1 RID: 38097 RVA: 0x001BF27D File Offset: 0x001BD67D
	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	// Token: 0x060094D2 RID: 38098 RVA: 0x001BF285 File Offset: 0x001BD685
	public void SetText(string content)
	{
		if (this.contentText != null)
		{
			this.contentText.text = content;
		}
	}

	// Token: 0x060094D3 RID: 38099 RVA: 0x001BF2A4 File Offset: 0x001BD6A4
	public void SetCdText(float cdTime)
	{
	}

	// Token: 0x04004B8F RID: 19343
	public Image mIconBar;

	// Token: 0x04004B90 RID: 19344
	public Image mProcessBar;

	// Token: 0x04004B91 RID: 19345
	public Text contentText;

	// Token: 0x04004B92 RID: 19346
	public eDungeonCharactorBar mType;
}
