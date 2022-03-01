using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000EC6 RID: 3782
public class ComDungeonCharactorBarEnergy : MonoBehaviour
{
	// Token: 0x060094D5 RID: 38101 RVA: 0x001BF2B9 File Offset: 0x001BD6B9
	public void InitData(float max)
	{
		this.maxValue = max;
		this.curValue = max;
	}

	// Token: 0x060094D6 RID: 38102 RVA: 0x001BF2C9 File Offset: 0x001BD6C9
	public void RefreshData(float value)
	{
		this.curValue = value;
		this.barRate = this.curValue / this.maxValue;
		this.imageBar.fillAmount = this.barRate;
	}

	// Token: 0x060094D7 RID: 38103 RVA: 0x001BF2F6 File Offset: 0x001BD6F6
	public GameObject GetGameObject()
	{
		return base.gameObject;
	}

	// Token: 0x04004B93 RID: 19347
	public Image transBar;

	// Token: 0x04004B94 RID: 19348
	public Image imageBar;

	// Token: 0x04004B95 RID: 19349
	public float curValue;

	// Token: 0x04004B96 RID: 19350
	public float maxValue;

	// Token: 0x04004B97 RID: 19351
	public float barRate = 10f;
}
