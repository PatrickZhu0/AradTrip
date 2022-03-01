using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F25 RID: 3877
[ExecuteInEditMode]
public class ComTime : MonoBehaviour
{
	// Token: 0x06009755 RID: 38741 RVA: 0x001CF788 File Offset: 0x001CDB88
	private void _updateText()
	{
		bool flag = this.mTimeInLimit < this.mTimeInMS;
		if (this.mIsTimeLimit && flag)
		{
			this.mTimeInMS = this.mTimeInLimit;
		}
		int num = this.mTimeInMS % 1000;
		int num2 = this.mTimeInMS / 1000;
		int num3 = num2 % 60;
		int num4 = num2 / 60 % 60;
		int num5 = num2 / 60 / 60;
		if (this.mIsHiddenZero)
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

	// Token: 0x06009756 RID: 38742 RVA: 0x001CFA1C File Offset: 0x001CDE1C
	public virtual void SetTime(int time)
	{
		this.mTimeInMS = time;
		this._updateText();
	}

	// Token: 0x04004DFC RID: 19964
	public int mTimeInMS = 10983020;

	// Token: 0x04004DFD RID: 19965
	public string mTimeHoursUnit = "H";

	// Token: 0x04004DFE RID: 19966
	public string mTimeMiniteUnit = "M";

	// Token: 0x04004DFF RID: 19967
	public string mTimeSecondUnit = "S";

	// Token: 0x04004E00 RID: 19968
	public bool mIsHiddenZero = true;

	// Token: 0x04004E01 RID: 19969
	public bool mIsHiddenMs;

	// Token: 0x04004E02 RID: 19970
	public bool mIsTripSpace;

	// Token: 0x04004E03 RID: 19971
	public int mTimeInLimit = 10000;

	// Token: 0x04004E04 RID: 19972
	public bool mIsTimeLimit;

	// Token: 0x04004E05 RID: 19973
	public string mTimeLimitSign = ">";

	// Token: 0x04004E06 RID: 19974
	public string mToStringFormat = "0";

	// Token: 0x04004E07 RID: 19975
	public Text mCurrentText;
}
