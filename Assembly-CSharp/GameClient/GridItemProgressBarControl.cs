using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C6A RID: 7274
	public class GridItemProgressBarControl : MonoBehaviour
	{
		// Token: 0x06011DE4 RID: 73188 RVA: 0x0053B125 File Offset: 0x00539525
		private void OnDestroy()
		{
			this._cdTimeInterval = 0U;
			this._endTimeStamp = 0U;
			this._totalCdTimeInterval = 0f;
			this._currentLeftCdTimeInterval = 0f;
			this._isUpdateControl = false;
			this._preLeftTimeSecond = 0;
			this._action = null;
		}

		// Token: 0x06011DE5 RID: 73189 RVA: 0x0053B160 File Offset: 0x00539560
		public void UpdateProgressBarControl(uint cdTimeInterval, uint endTimeStamp, Action action = null)
		{
			if (this._cdTimeInterval == cdTimeInterval && this._endTimeStamp == endTimeStamp)
			{
				return;
			}
			this._action = action;
			this._preLeftTimeSecond = (int)cdTimeInterval;
			this._endTimeStamp = endTimeStamp;
			this._cdTimeInterval = cdTimeInterval;
			this._totalCdTimeInterval = this._cdTimeInterval;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			this._currentLeftCdTimeInterval = 0f;
			if (this._endTimeStamp > serverTime)
			{
				this._currentLeftCdTimeInterval = this._endTimeStamp - serverTime;
			}
			this.UpdatePointView();
			if (this._endTimeStamp > serverTime)
			{
				this._isUpdateControl = true;
			}
			else
			{
				this._isUpdateControl = false;
				this.ResetCdTime();
			}
		}

		// Token: 0x06011DE6 RID: 73190 RVA: 0x0053B210 File Offset: 0x00539610
		private void Update()
		{
			if (!this._isUpdateControl)
			{
				return;
			}
			this._currentLeftCdTimeInterval -= Time.deltaTime;
			this.UpdatePointView();
			if (this._currentLeftCdTimeInterval < 0f)
			{
				this._isUpdateControl = false;
				this.ResetCdTime();
			}
		}

		// Token: 0x06011DE7 RID: 73191 RVA: 0x0053B260 File Offset: 0x00539660
		private void UpdatePointView()
		{
			if (this.progressBarImage != null)
			{
				float fillAmount = 1f;
				if (this._currentLeftCdTimeInterval >= 0f)
				{
					fillAmount = 1f - this._currentLeftCdTimeInterval / this._totalCdTimeInterval;
				}
				this.progressBarImage.fillAmount = fillAmount;
			}
			if (this._action != null)
			{
				int num = 0;
				if (this._currentLeftCdTimeInterval >= 0f)
				{
					num = (int)this._currentLeftCdTimeInterval;
				}
				if (this._preLeftTimeSecond > this.actionByLeftTimeSecond && num <= this.actionByLeftTimeSecond)
				{
					this._action();
				}
				this._preLeftTimeSecond = num;
			}
		}

		// Token: 0x06011DE8 RID: 73192 RVA: 0x0053B308 File Offset: 0x00539708
		private void ResetCdTime()
		{
			this._cdTimeInterval = 0U;
			this._endTimeStamp = 0U;
		}

		// Token: 0x0400BA31 RID: 47665
		private bool _isUpdateControl;

		// Token: 0x0400BA32 RID: 47666
		private uint _cdTimeInterval;

		// Token: 0x0400BA33 RID: 47667
		private uint _endTimeStamp;

		// Token: 0x0400BA34 RID: 47668
		private float _totalCdTimeInterval;

		// Token: 0x0400BA35 RID: 47669
		private float _currentLeftCdTimeInterval;

		// Token: 0x0400BA36 RID: 47670
		private int _preLeftTimeSecond;

		// Token: 0x0400BA37 RID: 47671
		private Action _action;

		// Token: 0x0400BA38 RID: 47672
		[SerializeField]
		private Image progressBarImage;

		// Token: 0x0400BA39 RID: 47673
		[SerializeField]
		private int actionByLeftTimeSecond = 10;
	}
}
