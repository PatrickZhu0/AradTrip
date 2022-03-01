using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x0200015C RID: 348
public class SimpleTimer : MonoBehaviour
{
	// Token: 0x06000A10 RID: 2576 RVA: 0x00034E37 File Offset: 0x00033237
	public void SetVisible(bool flag)
	{
		base.gameObject.SetActive(flag);
	}

	// Token: 0x06000A11 RID: 2577 RVA: 0x00034E45 File Offset: 0x00033245
	public void StartTimer()
	{
		this.SetVisible(true);
		this.seconds = 0;
		this.run = true;
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x00034E5C File Offset: 0x0003325C
	public void SetCountdown(int seconds)
	{
		this.countdown = seconds;
		this.SetText(this.countdown);
	}

	// Token: 0x06000A13 RID: 2579 RVA: 0x00034E71 File Offset: 0x00033271
	public void Reset()
	{
		this.seconds = 0;
	}

	// Token: 0x06000A14 RID: 2580 RVA: 0x00034E7A File Offset: 0x0003327A
	public void StopTimer()
	{
		this.run = false;
	}

	// Token: 0x06000A15 RID: 2581 RVA: 0x00034E84 File Offset: 0x00033284
	public void UpdateTimer(int delta)
	{
		if (!this.run)
		{
			return;
		}
		this.timeAcc += delta;
		if (this.timeAcc >= 1000)
		{
			this.timeAcc -= 1000;
			this.ShowSecond(1);
		}
	}

	// Token: 0x06000A16 RID: 2582 RVA: 0x00034ED4 File Offset: 0x000332D4
	private void Update()
	{
		if (!this.useSystemUpdate)
		{
			return;
		}
		float num = Time.deltaTime * (float)GlobalLogic.VALUE_1000;
		this.UpdateTimer((int)num);
	}

	// Token: 0x06000A17 RID: 2583 RVA: 0x00034F04 File Offset: 0x00033304
	private void ShowSecond(int add)
	{
		this.seconds += add;
		if (this.componetText != null)
		{
			int text = this.seconds;
			if (this.countdown > 0)
			{
				text = this.countdown - this.seconds;
			}
			else
			{
				text = 0;
			}
			this.SetText(text);
		}
	}

	// Token: 0x06000A18 RID: 2584 RVA: 0x00034F60 File Offset: 0x00033360
	private void SetText(int tmp)
	{
		this.ConverSeconds(tmp, ref this.time4);
		if (this.formatType == SimpleTimer.FormatType.PK)
		{
			if (this.countdown > 0 && tmp <= 0)
			{
				this.componetText.text = "时间到";
			}
			else
			{
				if (this.countdown > 0 && tmp <= 10)
				{
					this.componetText.color = Color.red;
				}
				this.componetText.text = string.Format("{0:00}:{1:00}", this.time4.min, this.time4.sec);
			}
		}
		else if (this.formatType == SimpleTimer.FormatType.PVE)
		{
			if (this.countdown > 0 && tmp < 0)
			{
				this.ConverSeconds(0, ref this.time4);
			}
			if (this.countdown >= 0 && tmp <= 10)
			{
				this.componetText.color = Color.red;
			}
			this.componetText.text = string.Format("{0:00}:{1:00}", this.time4.min, this.time4.sec);
		}
		else if (this.formatType == SimpleTimer.FormatType.MALL_ITEM)
		{
			if (this.time4.day > 0)
			{
				this.componetText.text = string.Format("剩余{0}天", this.time4.day);
			}
			else
			{
				this.componetText.text = string.Format("{0}:{1:00}:{2:00}", this.time4.hour, this.time4.min, this.time4.sec);
			}
		}
		else if (this.formatType == SimpleTimer.FormatType.MALL_GIFT)
		{
			if (this.time4.day > 0)
			{
				this.componetText.text = string.Format("剩余{0}天", this.time4.day);
			}
			else
			{
				if (this.time4.hour < 0)
				{
					this.time4.hour = 0;
				}
				if (this.time4.min < 0)
				{
					this.time4.min = 0;
				}
				if (this.time4.sec < 0)
				{
					this.time4.sec = 0;
				}
				this.componetText.text = string.Format("剩余时间：{0:00}:{1:00}:{2:00}", this.time4.hour, this.time4.min, this.time4.sec);
			}
		}
		else if (this.formatType == SimpleTimer.FormatType.MALL_LIMITTIME)
		{
			if (this.time4.day > 0)
			{
				this.componetText.text = string.Format("{0}天", this.time4.day);
			}
			else
			{
				if (this.time4.hour < 0)
				{
					this.time4.hour = 0;
				}
				if (this.time4.min < 0)
				{
					this.time4.min = 0;
				}
				if (this.time4.sec < 0)
				{
					this.time4.sec = 0;
				}
				this.componetText.text = string.Format("{0:00}:{1:00}:{2:00}", this.time4.hour, this.time4.min, this.time4.sec);
			}
		}
		else if (this.formatType == SimpleTimer.FormatType.ACTIVITY_LIMIT)
		{
			if (this.time4.day > 0)
			{
				this.componetText.text = string.Format(TR.Value("activity_limit_left_time"), this.time4.day);
			}
			else if (this.time4.hour <= 0 && this.time4.min <= 0 && this.time4.sec <= 0)
			{
				this.componetText.text = TR.Value("activity_limit_time_over");
			}
			else
			{
				if (this.time4.hour < 0)
				{
					this.time4.hour = 0;
				}
				if (this.time4.min < 0)
				{
					this.time4.min = 0;
				}
				if (this.time4.sec < 0)
				{
					this.time4.sec = 0;
				}
				string text = string.Format(TR.Value("activity_limit_left_less_one_day"), this.time4.hour, this.time4.min, this.time4.sec);
				this.componetText.text = text;
			}
		}
		else if (this.formatType == SimpleTimer.FormatType.MONTH_CARD_LOCKERS)
		{
			if (this.time4.day > 0)
			{
				if (this.time4.hour < 0)
				{
					this.time4.hour = 0;
				}
				if (this.time4.min < 0)
				{
					this.time4.min = 0;
				}
				if (this.time4.sec < 0)
				{
					this.time4.sec = 0;
				}
				string text2 = string.Format(TR.Value("month_card_item_expiredtime"), this.time4.hour + this.time4.day * 24, this.time4.min, this.time4.sec);
				this.componetText.text = text2;
			}
			else if (this.time4.hour <= 0 && this.time4.min <= 0 && this.time4.sec <= 0)
			{
				this.componetText.text = TR.Value("month_card_item_expiredtime_over");
			}
			else
			{
				if (this.time4.hour < 0)
				{
					this.time4.hour = 0;
				}
				if (this.time4.min < 0)
				{
					this.time4.min = 0;
				}
				if (this.time4.sec < 0)
				{
					this.time4.sec = 0;
				}
				string text3 = string.Format(TR.Value("month_card_item_expiredtime"), this.time4.hour, this.time4.min, this.time4.sec);
				this.componetText.text = text3;
			}
		}
		else if (this.formatType == SimpleTimer.FormatType.CHAMPIONSSHIP_GIFTITEM && this.time4.day >= 0)
		{
			this.componetText.text = string.Format("还剩{0}天", this.time4.day);
		}
	}

	// Token: 0x06000A19 RID: 2585 RVA: 0x00035642 File Offset: 0x00033A42
	public bool IsTimeUp()
	{
		return this.countdown > 0 && this.seconds >= this.countdown;
	}

	// Token: 0x06000A1A RID: 2586 RVA: 0x00035664 File Offset: 0x00033A64
	public void ConverSeconds(int seconds, ref SimpleTimer.Time4 time)
	{
		time.day = seconds / 86400;
		seconds -= time.day * 86400;
		time.hour = seconds / 3600;
		seconds -= time.hour * 3600;
		time.min = seconds / 60;
		time.sec = seconds % 60;
	}

	// Token: 0x06000A1B RID: 2587 RVA: 0x000356C5 File Offset: 0x00033AC5
	public int GetPassTime()
	{
		return this.seconds;
	}

	// Token: 0x06000A1C RID: 2588 RVA: 0x000356CD File Offset: 0x00033ACD
	public SimpleTimer.Time4 GetCurrTime4()
	{
		return this.time4;
	}

	// Token: 0x04000779 RID: 1913
	public bool useSystemUpdate;

	// Token: 0x0400077A RID: 1914
	public Text componetText;

	// Token: 0x0400077B RID: 1915
	private int timeAcc;

	// Token: 0x0400077C RID: 1916
	private bool run;

	// Token: 0x0400077D RID: 1917
	private int seconds;

	// Token: 0x0400077E RID: 1918
	private int countdown;

	// Token: 0x0400077F RID: 1919
	public SimpleTimer.FormatType formatType;

	// Token: 0x04000780 RID: 1920
	private SimpleTimer.Time4 time4 = new SimpleTimer.Time4();

	// Token: 0x04000781 RID: 1921
	private const int INTERVAL = 1000;

	// Token: 0x0200015D RID: 349
	public enum FormatType
	{
		// Token: 0x04000783 RID: 1923
		PK,
		// Token: 0x04000784 RID: 1924
		MALL_ITEM,
		// Token: 0x04000785 RID: 1925
		MALL_GIFT,
		// Token: 0x04000786 RID: 1926
		MALL_LIMITTIME,
		// Token: 0x04000787 RID: 1927
		ACTIVITY_LIMIT,
		// Token: 0x04000788 RID: 1928
		MONTH_CARD_LOCKERS,
		// Token: 0x04000789 RID: 1929
		CHAMPIONSSHIP_GIFTITEM,
		// Token: 0x0400078A RID: 1930
		PVE
	}

	// Token: 0x0200015E RID: 350
	public class Time4
	{
		// Token: 0x0400078B RID: 1931
		public int day;

		// Token: 0x0400078C RID: 1932
		public int hour;

		// Token: 0x0400078D RID: 1933
		public int min;

		// Token: 0x0400078E RID: 1934
		public int sec;
	}
}
