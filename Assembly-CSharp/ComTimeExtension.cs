using System;

// Token: 0x02000F26 RID: 3878
public class ComTimeExtension : ComTime
{
	// Token: 0x06009758 RID: 38744 RVA: 0x001CFA33 File Offset: 0x001CDE33
	public override void SetTime(int time)
	{
		this.mTimeInMS = time;
		this._UpdateText();
	}

	// Token: 0x06009759 RID: 38745 RVA: 0x001CFA44 File Offset: 0x001CDE44
	private void _UpdateText()
	{
		bool flag = this.mTimeInLimit < this.mTimeInMS;
		if (this.mIsTimeLimit && flag)
		{
			this.mTimeInMS = this.mTimeInLimit;
		}
		int num = this.mTimeInMS % 1000;
		int num2 = this.mTimeInMS / 1000;
		int num3 = num2 % 60;
		int num4 = num2 / 60;
		int num5 = 0;
		if (this.mIsHiddenZero)
		{
			if (this.mIsHideHour)
			{
				this.mCurrentText.text = string.Format("{0,2}{1}{2,2}{3}{4,2}", new object[]
				{
					(num5 != 0 || num4 != 0) ? num4.ToString(this.mToStringFormat) : string.Empty,
					(num5 != 0 || num4 != 0) ? this.mTimeMiniteUnit.ToString() : string.Empty,
					((num5 == 0 && num4 == 0) || num3 != 0) ? num3.ToString(this.mToStringFormat) : string.Empty,
					((num5 == 0 && num4 == 0) || num3 != 0) ? this.mTimeSecondUnit : string.Empty,
					(!this.mIsHiddenMs) ? (num / 10).ToString() : string.Empty
				});
			}
			else
			{
				this.mCurrentText.text = string.Format("{0,2}{1}{2,2}{3}{4,2}{5}{6,2}", new object[]
				{
					(num5 != 0) ? num5.ToString(this.mToStringFormat) : string.Empty,
					(num5 != 0) ? this.mTimeHoursUnit.ToString() : string.Empty,
					(num5 != 0 || num4 != 0) ? num4.ToString(this.mToStringFormat) : string.Empty,
					(num5 != 0 || num4 != 0) ? this.mTimeMiniteUnit.ToString() : string.Empty,
					((num5 == 0 && num4 == 0) || num3 != 0) ? num3.ToString(this.mToStringFormat) : string.Empty,
					((num5 == 0 && num4 == 0) || num3 != 0) ? this.mTimeSecondUnit : string.Empty,
					(!this.mIsHiddenMs) ? (num / 10).ToString() : string.Empty
				});
			}
		}
		else if (this.mIsHideHour)
		{
			this.mCurrentText.text = string.Format("{0,2}{1}{2,2}{3}{4,2}", new object[]
			{
				num4.ToString(this.mToStringFormat),
				this.mTimeMiniteUnit,
				num3.ToString(this.mToStringFormat),
				this.mTimeSecondUnit,
				(!this.mIsHiddenMs) ? (num / 10).ToString() : string.Empty
			});
		}
		else
		{
			this.mCurrentText.text = string.Format("{0,2}{1}{2,2}{3}{4,2}{5}{6,2}", new object[]
			{
				num5.ToString(this.mToStringFormat),
				this.mTimeHoursUnit,
				num4.ToString(this.mToStringFormat),
				this.mTimeMiniteUnit,
				num3.ToString(this.mToStringFormat),
				this.mTimeSecondUnit,
				(!this.mIsHiddenMs) ? (num / 10).ToString() : string.Empty
			});
		}
		if (this.mIsTripSpace)
		{
			string text = this.mCurrentText.text;
			this.mCurrentText.text = text.Trim();
		}
		if (this.mIsTimeLimit && flag)
		{
			string text2 = this.mCurrentText.text;
			this.mCurrentText.text = this.mTimeLimitSign + text2;
		}
	}

	// Token: 0x04004E08 RID: 19976
	public bool mIsHideHour;
}
