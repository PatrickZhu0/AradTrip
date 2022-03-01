using System;
using UnityEngine;

// Token: 0x02000E15 RID: 3605
public class ComCalTime : MonoBehaviour
{
	// Token: 0x0600905D RID: 36957 RVA: 0x001AB0B4 File Offset: 0x001A94B4
	public void BeginCalTime(bool bBegin)
	{
		this.bBeginCal = bBegin;
		if (this.bBeginCal)
		{
			this.BeginTime = this.ConvertDateTimeInt(DateTime.Now);
		}
	}

	// Token: 0x0600905E RID: 36958 RVA: 0x001AB0D9 File Offset: 0x001A94D9
	public void SetPosy(bool bSet)
	{
		this.bAddPosy = bSet;
	}

	// Token: 0x0600905F RID: 36959 RVA: 0x001AB0E2 File Offset: 0x001A94E2
	public bool GetPosyIsAdded()
	{
		return this.bAddPosy;
	}

	// Token: 0x06009060 RID: 36960 RVA: 0x001AB0EA File Offset: 0x001A94EA
	public double GetPassedTime()
	{
		return this.timeInterval;
	}

	// Token: 0x06009061 RID: 36961 RVA: 0x001AB0F4 File Offset: 0x001A94F4
	private void Update()
	{
		if (this.bBeginCal)
		{
			double num = this.ConvertDateTimeInt(DateTime.Now);
			this.timeInterval = num - this.BeginTime;
		}
	}

	// Token: 0x06009062 RID: 36962 RVA: 0x001AB128 File Offset: 0x001A9528
	private double ConvertDateTimeInt(DateTime time)
	{
		DateTime d = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
		return (time - d).TotalSeconds;
	}

	// Token: 0x040047BD RID: 18365
	private bool bBeginCal;

	// Token: 0x040047BE RID: 18366
	private bool bAddPosy;

	// Token: 0x040047BF RID: 18367
	private double BeginTime;

	// Token: 0x040047C0 RID: 18368
	private double timeInterval;
}
