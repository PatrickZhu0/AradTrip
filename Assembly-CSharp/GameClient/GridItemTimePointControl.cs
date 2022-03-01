using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C6B RID: 7275
	public class GridItemTimePointControl : MonoBehaviour
	{
		// Token: 0x06011DEA RID: 73194 RVA: 0x0053B344 File Offset: 0x00539744
		private void OnDestroy()
		{
			this._endTimeStamp = 0U;
			this._cdTimeInterval = 0U;
			this._isUpdateControl = false;
			this._timePerPoint = 0f;
		}

		// Token: 0x06011DEB RID: 73195 RVA: 0x0053B368 File Offset: 0x00539768
		public void UpdateTimePointControl(uint cdTimeInterval, uint endTimeStamp, Action action = null)
		{
			if (this._cdTimeInterval == cdTimeInterval && this._endTimeStamp == endTimeStamp)
			{
				return;
			}
			this._action = action;
			this._preLeftTimePoint = this.timePointNumber;
			this._endTimeStamp = endTimeStamp;
			this._cdTimeInterval = cdTimeInterval;
			if (this.timePointNumber > 0)
			{
				this._timePerPoint = this._cdTimeInterval / (float)this.timePointNumber;
			}
			if (this._timePerPoint <= 0f)
			{
				this._timePerPoint = 1f;
			}
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			this.UpdatePointView(serverTime);
			this._curTimeInterval = 0.5f;
			if (serverTime > this._endTimeStamp)
			{
				this._isUpdateControl = false;
				this.ResetCdTime();
			}
			else
			{
				this._isUpdateControl = true;
			}
		}

		// Token: 0x06011DEC RID: 73196 RVA: 0x0053B430 File Offset: 0x00539830
		private void Update()
		{
			if (!this._isUpdateControl)
			{
				return;
			}
			this._curTimeInterval -= Time.deltaTime;
			if (this._curTimeInterval <= 0f)
			{
				this._curTimeInterval = 0.5f;
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				this.UpdatePointView(serverTime);
				if (serverTime > this._endTimeStamp)
				{
					this._isUpdateControl = false;
					this.ResetCdTime();
				}
			}
		}

		// Token: 0x06011DED RID: 73197 RVA: 0x0053B4A4 File Offset: 0x005398A4
		private void UpdatePointView(uint curTime)
		{
			int num = 0;
			if (this._endTimeStamp > curTime)
			{
				uint num2 = this._endTimeStamp - curTime;
				if (this._timePerPoint > 0f)
				{
					num = (int)(num2 / this._timePerPoint) + 1;
				}
			}
			if (num > this.timePointNumber)
			{
				num = this.timePointNumber;
			}
			if (this._preLeftTimePoint != num && num == this.actionByLeftTimePoint && this._action != null)
			{
				this._action();
			}
			for (int i = 0; i < this.pointCoverList.Count; i++)
			{
				GameObject gameObject = this.pointCoverList[i];
				if (!(gameObject == null))
				{
					if (i < num)
					{
						CommonUtility.UpdateGameObjectVisible(gameObject, true);
					}
					else
					{
						CommonUtility.UpdateGameObjectVisible(gameObject, false);
					}
				}
			}
			this._preLeftTimePoint = num;
		}

		// Token: 0x06011DEE RID: 73198 RVA: 0x0053B582 File Offset: 0x00539982
		private void ResetCdTime()
		{
			this._cdTimeInterval = 0U;
			this._endTimeStamp = 0U;
		}

		// Token: 0x0400BA3A RID: 47674
		private bool _isUpdateControl;

		// Token: 0x0400BA3B RID: 47675
		private uint _cdTimeInterval;

		// Token: 0x0400BA3C RID: 47676
		private uint _endTimeStamp;

		// Token: 0x0400BA3D RID: 47677
		private float _timePerPoint;

		// Token: 0x0400BA3E RID: 47678
		private float _curTimeInterval = 0.5f;

		// Token: 0x0400BA3F RID: 47679
		public const float UpdateTimeInterval = 0.5f;

		// Token: 0x0400BA40 RID: 47680
		private int _preLeftTimePoint;

		// Token: 0x0400BA41 RID: 47681
		private Action _action;

		// Token: 0x0400BA42 RID: 47682
		[SerializeField]
		private int timePointNumber = 4;

		// Token: 0x0400BA43 RID: 47683
		[SerializeField]
		private List<GameObject> pointCoverList = new List<GameObject>();

		// Token: 0x0400BA44 RID: 47684
		[SerializeField]
		private int actionByLeftTimePoint = 1;
	}
}
