using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E59 RID: 3673
	public class CountDownTimeController : MonoBehaviour
	{
		// Token: 0x170018F2 RID: 6386
		// (set) Token: 0x060091EE RID: 37358 RVA: 0x001B09D9 File Offset: 0x001AEDD9
		public uint EndTime
		{
			set
			{
				this._endTime = value;
			}
		}

		// Token: 0x060091EF RID: 37359 RVA: 0x001B09E2 File Offset: 0x001AEDE2
		public void SetCountDownTimeController(uint endTime, OnCountDownTimeCallback countDownTimeCallBack = null)
		{
			this.EndTime = endTime;
			this._onCountDownTimeCallback = countDownTimeCallBack;
			this.InitCountDownTimeController();
		}

		// Token: 0x060091F0 RID: 37360 RVA: 0x001B09F8 File Offset: 0x001AEDF8
		public void InitCountDownTimeController()
		{
			this.CancelCountDownTime();
			base.InvokeRepeating("OnUpdateCountDownTime", 0f, this.refreshInterval);
		}

		// Token: 0x060091F1 RID: 37361 RVA: 0x001B0A16 File Offset: 0x001AEE16
		public void SetCountDownTimeCallback(OnCountDownTimeCallback onCountDownTimeCallback)
		{
			this._onCountDownTimeCallback = onCountDownTimeCallback;
		}

		// Token: 0x060091F2 RID: 37362 RVA: 0x001B0A1F File Offset: 0x001AEE1F
		public void ResetCountDownTimeController()
		{
			this.CancelCountDownTime();
		}

		// Token: 0x060091F3 RID: 37363 RVA: 0x001B0A28 File Offset: 0x001AEE28
		private void OnUpdateCountDownTime()
		{
			if (this.countDownTimeType == CountDownTimeController.CountDownTimeType.InValid)
			{
				this.CancelCountDownTime();
				return;
			}
			switch (this.countDownTimeType)
			{
			case CountDownTimeController.CountDownTimeType.TimeHourMinute:
				this.UpdateCountDownTimeByHourMinute();
				break;
			case CountDownTimeController.CountDownTimeType.TimeSecond:
				this.UpdateCountDownTimeBySecond();
				break;
			case CountDownTimeController.CountDownTimeType.TimeHourMinuteSecond:
				this.UpdateCountDownTimeByHourMinuteSecond();
				break;
			case CountDownTimeController.CountDownTimeType.TimeMinuteSecond:
				this.UpdateCountDownTimeByMinuteSecond();
				break;
			}
		}

		// Token: 0x060091F4 RID: 37364 RVA: 0x001B0A9C File Offset: 0x001AEE9C
		private void UpdateCountDownTimeByMinuteSecond()
		{
			if (this.countDownTimeLabel != null)
			{
				this.countDownTimeLabel.text = CountDownTimeUtility.GetCountDownTimeByMinuteSecondFormat(this._endTime, DataManager<TimeManager>.GetInstance().GetServerTime());
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() >= this._endTime)
			{
				this.CancelCountDownTime();
				if (this._onCountDownTimeCallback != null)
				{
					this._onCountDownTimeCallback();
				}
			}
		}

		// Token: 0x060091F5 RID: 37365 RVA: 0x001B0B0C File Offset: 0x001AEF0C
		private void UpdateCountDownTimeByHourMinute()
		{
			if (this.countDownTimeLabel != null)
			{
				this.countDownTimeLabel.text = CountDownTimeUtility.GetCountDownTimeByHourMinute(this._endTime, DataManager<TimeManager>.GetInstance().GetServerTime());
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() >= this._endTime)
			{
				this.CancelCountDownTime();
				if (this._onCountDownTimeCallback != null)
				{
					this._onCountDownTimeCallback();
				}
			}
		}

		// Token: 0x060091F6 RID: 37366 RVA: 0x001B0B7C File Offset: 0x001AEF7C
		private void UpdateCountDownTimeByHourMinuteSecond()
		{
			if (this.countDownTimeLabel != null)
			{
				this.countDownTimeLabel.text = CountDownTimeUtility.GetCountDownTimeByHourMinuteSecondFormat(this._endTime, DataManager<TimeManager>.GetInstance().GetServerTime());
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() >= this._endTime)
			{
				this.CancelCountDownTime();
				if (this._onCountDownTimeCallback != null)
				{
					this._onCountDownTimeCallback();
				}
			}
		}

		// Token: 0x060091F7 RID: 37367 RVA: 0x001B0BEC File Offset: 0x001AEFEC
		private void UpdateCountDownTimeBySecond()
		{
			if (this.countDownTimeLabel != null)
			{
				this.countDownTimeLabel.text = CountDownTimeUtility.GetCountDownTimeBySecondFormat(this._endTime, DataManager<TimeManager>.GetInstance().GetServerTime());
			}
			if (DataManager<TimeManager>.GetInstance().GetServerTime() >= this._endTime)
			{
				this.CancelCountDownTime();
				if (this._onCountDownTimeCallback != null)
				{
					this._onCountDownTimeCallback();
				}
			}
		}

		// Token: 0x060091F8 RID: 37368 RVA: 0x001B0C5B File Offset: 0x001AF05B
		private void CancelCountDownTime()
		{
			base.CancelInvoke("OnUpdateCountDownTime");
		}

		// Token: 0x04004912 RID: 18706
		[SerializeField]
		private Text countDownTimeLabel;

		// Token: 0x04004913 RID: 18707
		[SerializeField]
		private CountDownTimeController.CountDownTimeType countDownTimeType;

		// Token: 0x04004914 RID: 18708
		[SerializeField]
		private float refreshInterval = 1f;

		// Token: 0x04004915 RID: 18709
		private OnCountDownTimeCallback _onCountDownTimeCallback;

		// Token: 0x04004916 RID: 18710
		private uint _endTime;

		// Token: 0x02000E5A RID: 3674
		public enum CountDownTimeType
		{
			// Token: 0x04004918 RID: 18712
			InValid = -1,
			// Token: 0x04004919 RID: 18713
			TimeHourMinute,
			// Token: 0x0400491A RID: 18714
			TimeSecond,
			// Token: 0x0400491B RID: 18715
			TimeHourMinuteSecond,
			// Token: 0x0400491C RID: 18716
			TimeMinuteSecond
		}
	}
}
