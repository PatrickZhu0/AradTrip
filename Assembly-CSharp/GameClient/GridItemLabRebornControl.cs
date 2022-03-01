using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C68 RID: 7272
	public class GridItemLabRebornControl : MonoBehaviour
	{
		// Token: 0x06011DDB RID: 73179 RVA: 0x0053AD3F File Offset: 0x0053913F
		private void OnDestroy()
		{
			this._endTimeStamp = 0U;
			this._intervalTime = 0f;
			this._isUpdate = false;
		}

		// Token: 0x06011DDC RID: 73180 RVA: 0x0053AD5C File Offset: 0x0053915C
		public void UpdateLabRebornControl(uint endTimeStamp)
		{
			if (this._endTimeStamp == endTimeStamp)
			{
				return;
			}
			this._endTimeStamp = endTimeStamp;
			this._intervalTime = 0f;
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			this.UpdateLabRebornLabel(serverTime);
			if (serverTime < this._endTimeStamp)
			{
				this._isUpdate = true;
			}
			else
			{
				this._isUpdate = false;
				this._endTimeStamp = 0U;
			}
		}

		// Token: 0x06011DDD RID: 73181 RVA: 0x0053ADC0 File Offset: 0x005391C0
		private void Update()
		{
			if (!this._isUpdate)
			{
				return;
			}
			this._intervalTime += Time.deltaTime;
			if (this._intervalTime >= 0.5f)
			{
				uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
				this.UpdateLabRebornLabel(serverTime);
				this._intervalTime = 0f;
				if (serverTime >= this._endTimeStamp)
				{
					this._isUpdate = false;
					this._endTimeStamp = 0U;
				}
			}
		}

		// Token: 0x06011DDE RID: 73182 RVA: 0x0053AE34 File Offset: 0x00539234
		private void UpdateLabRebornLabel(uint curTimeStamp)
		{
			if (this.countDownTimeLabel == null)
			{
				return;
			}
			string countDownTimeByMinuteSecondFormat = CountDownTimeUtility.GetCountDownTimeByMinuteSecondFormat(this._endTimeStamp, curTimeStamp);
			this.countDownTimeLabel.text = countDownTimeByMinuteSecondFormat;
		}

		// Token: 0x0400BA24 RID: 47652
		private bool _isUpdate;

		// Token: 0x0400BA25 RID: 47653
		private uint _endTimeStamp;

		// Token: 0x0400BA26 RID: 47654
		private float _intervalTime;

		// Token: 0x0400BA27 RID: 47655
		[SerializeField]
		private Text countDownTimeLabel;
	}
}
