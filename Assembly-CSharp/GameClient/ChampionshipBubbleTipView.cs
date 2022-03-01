using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020014DB RID: 5339
	public class ChampionshipBubbleTipView : MonoBehaviour
	{
		// Token: 0x0600CF26 RID: 53030 RVA: 0x00332196 File Offset: 0x00330596
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600CF27 RID: 53031 RVA: 0x0033219E File Offset: 0x0033059E
		private void ClearData()
		{
			this._tipTitleStr = null;
			this._isShow = false;
			this._beginTimeStamp = 0U;
			this._timeFrame = 0f;
			this._totalLastTime = 0U;
			this._oneCycleTime = 0U;
		}

		// Token: 0x0600CF28 RID: 53032 RVA: 0x003321D0 File Offset: 0x003305D0
		public void InitTipView(string tipStr)
		{
			this._isShow = true;
			this._beginTimeStamp = DataManager<TimeManager>.GetInstance().GetServerTime();
			this._tipTitleStr = tipStr;
			this._timeFrame = 0f;
			this._oneCycleTime = this.disappearTimeInterval + this.showTimeInterval;
			if (this._oneCycleTime == 0U)
			{
				this._oneCycleTime = 1U;
			}
			this._totalLastTime = this._oneCycleTime * this.intervalNumber;
			this.InitTipLabel();
			this.UpdateRootVisible(true);
		}

		// Token: 0x0600CF29 RID: 53033 RVA: 0x0033224B File Offset: 0x0033064B
		private void InitTipLabel()
		{
			if (this.tipTitleLabel != null)
			{
				this.tipTitleLabel.text = this._tipTitleStr;
			}
		}

		// Token: 0x0600CF2A RID: 53034 RVA: 0x00332270 File Offset: 0x00330670
		private void Update()
		{
			if (!this._isShow)
			{
				return;
			}
			this._timeFrame += Time.deltaTime;
			if (this._timeFrame >= 1f)
			{
				this._timeFrame = 0f;
				this.DealWithBubbleTipView();
			}
		}

		// Token: 0x0600CF2B RID: 53035 RVA: 0x003322BC File Offset: 0x003306BC
		private void DealWithBubbleTipView()
		{
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			uint num = serverTime - this._beginTimeStamp;
			if (num >= this._totalLastTime)
			{
				this.ResetTipView();
				return;
			}
			uint num2 = num % this._oneCycleTime;
			if (num2 < this.showTimeInterval)
			{
				this.UpdateRootVisible(true);
			}
			else
			{
				this.UpdateRootVisible(false);
			}
		}

		// Token: 0x0600CF2C RID: 53036 RVA: 0x00332318 File Offset: 0x00330718
		public void ResetTipView()
		{
			this._isShow = false;
			this.UpdateRootVisible(false);
		}

		// Token: 0x0600CF2D RID: 53037 RVA: 0x00332328 File Offset: 0x00330728
		private void UpdateRootVisible(bool flag)
		{
			CommonUtility.UpdateGameObjectVisible(this.viewRoot, flag);
		}

		// Token: 0x04007916 RID: 30998
		private string _tipTitleStr;

		// Token: 0x04007917 RID: 30999
		private bool _isShow;

		// Token: 0x04007918 RID: 31000
		private uint _beginTimeStamp;

		// Token: 0x04007919 RID: 31001
		private float _timeFrame;

		// Token: 0x0400791A RID: 31002
		private uint _totalLastTime;

		// Token: 0x0400791B RID: 31003
		private uint _oneCycleTime;

		// Token: 0x0400791C RID: 31004
		[Space(10f)]
		[Header("Content")]
		[Space(10f)]
		[SerializeField]
		private GameObject viewRoot;

		// Token: 0x0400791D RID: 31005
		[SerializeField]
		private Text tipTitleLabel;

		// Token: 0x0400791E RID: 31006
		[Space(10f)]
		[Header("Interval")]
		[Space(10f)]
		[SerializeField]
		private uint showTimeInterval;

		// Token: 0x0400791F RID: 31007
		[SerializeField]
		private uint disappearTimeInterval;

		// Token: 0x04007920 RID: 31008
		[SerializeField]
		private uint intervalNumber;
	}
}
