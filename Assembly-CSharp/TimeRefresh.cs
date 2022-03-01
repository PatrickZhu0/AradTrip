using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02001A60 RID: 6752
public class TimeRefresh : MonoBehaviour
{
	// Token: 0x17001D59 RID: 7513
	// (get) Token: 0x06010939 RID: 67897 RVA: 0x004AF918 File Offset: 0x004ADD18
	// (set) Token: 0x0601093A RID: 67898 RVA: 0x004AF920 File Offset: 0x004ADD20
	public bool Enable
	{
		get
		{
			return this.enable;
		}
		set
		{
			this.enable = value;
		}
	}

	// Token: 0x0601093B RID: 67899 RVA: 0x004AF929 File Offset: 0x004ADD29
	public void SetUINumber()
	{
		if (null != this.uiNumber)
		{
			this.uiNumber.Value = (int)this.time;
		}
	}

	// Token: 0x0601093C RID: 67900 RVA: 0x004AF94D File Offset: 0x004ADD4D
	public void SetFormatString(string value)
	{
		this.formatString = value;
	}

	// Token: 0x0601093D RID: 67901 RVA: 0x004AF956 File Offset: 0x004ADD56
	public void Initialize()
	{
		this.time = 0U;
		this.endTime = 0U;
		base.CancelInvoke("UpdateTime");
		base.InvokeRepeating("UpdateTime", 0f, this.refreshInterval);
	}

	// Token: 0x17001D5A RID: 7514
	// (set) Token: 0x0601093E RID: 67902 RVA: 0x004AF987 File Offset: 0x004ADD87
	public uint Time
	{
		set
		{
			this.time = value;
			this.endTime = DataManager<TimeManager>.GetInstance().GetServerTime() + value;
		}
	}

	// Token: 0x0601093F RID: 67903 RVA: 0x004AF9A4 File Offset: 0x004ADDA4
	public void UpdateTime()
	{
		uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
		this.time = ((this.endTime <= serverTime) ? 0U : (this.endTime - serverTime));
		if (this.text != null)
		{
			if (this.m_eTimeType == TimeRefresh.TimeType.TT_SHORT_TIME)
			{
				uint num = this.time / 3600U;
				uint num2 = (this.time - 3600U * num) / 60U;
				uint num3 = (this.time - 3600U * num) % 60U;
				this.text.text = string.Format(this.formatString, string.Format("{0:D2}:{1:D2}:{2:D2}", num, num2, num3));
				if (this.mAction != null)
				{
					this.mAction.Invoke();
				}
			}
			else if (this.m_eTimeType == TimeRefresh.TimeType.TT_SECOND)
			{
				uint num4 = this.time % 60U;
				this.text.text = string.Format(this.formatString, string.Format("{0:D2}", num4));
				if (this.mAction != null)
				{
					this.mAction.Invoke();
				}
			}
		}
	}

	// Token: 0x0400A901 RID: 43265
	public Text text;

	// Token: 0x0400A902 RID: 43266
	public TimeRefresh.TimeType m_eTimeType;

	// Token: 0x0400A903 RID: 43267
	public UnityEvent mAction;

	// Token: 0x0400A904 RID: 43268
	public string formatString = "{0}";

	// Token: 0x0400A905 RID: 43269
	public float refreshInterval = 1f;

	// Token: 0x0400A906 RID: 43270
	private bool enable = true;

	// Token: 0x0400A907 RID: 43271
	public UINumber uiNumber;

	// Token: 0x0400A908 RID: 43272
	private uint time;

	// Token: 0x0400A909 RID: 43273
	private uint endTime;

	// Token: 0x02001A61 RID: 6753
	public enum TimeType
	{
		// Token: 0x0400A90B RID: 43275
		TT_SHORT_TIME,
		// Token: 0x0400A90C RID: 43276
		TT_SECOND,
		// Token: 0x0400A90D RID: 43277
		TT_INVALID
	}
}
