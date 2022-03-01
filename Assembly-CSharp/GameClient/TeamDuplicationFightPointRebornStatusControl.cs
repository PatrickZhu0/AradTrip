using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C87 RID: 7303
	public class TeamDuplicationFightPointRebornStatusControl : MonoBehaviour
	{
		// Token: 0x06011E96 RID: 73366 RVA: 0x0053D46D File Offset: 0x0053B86D
		public void Init(float totalCountDownTime)
		{
			this._totalCountDownTime = totalCountDownTime;
			this._curCountDownTime = totalCountDownTime;
			if (this._totalCountDownTime <= 0f)
			{
				return;
			}
			this.UpdateCountDownView();
		}

		// Token: 0x06011E97 RID: 73367 RVA: 0x0053D494 File Offset: 0x0053B894
		public void Init(int totalCountDownTime)
		{
			this.Init((float)totalCountDownTime);
		}

		// Token: 0x06011E98 RID: 73368 RVA: 0x0053D49E File Offset: 0x0053B89E
		private void Update()
		{
			if (this._curCountDownTime <= 0f)
			{
				return;
			}
			this._curCountDownTime -= Time.deltaTime;
			this.UpdateCountDownView();
		}

		// Token: 0x06011E99 RID: 73369 RVA: 0x0053D4CC File Offset: 0x0053B8CC
		private void UpdateCountDownView()
		{
			float num = this._curCountDownTime / this._totalCountDownTime;
			if (num <= 0f)
			{
				num = 0f;
			}
			else if (num >= 1f)
			{
				num = 1f;
			}
			if (this.sliderImageCover != null)
			{
				this.sliderImageCover.fillAmount = num;
			}
			string text = string.Format(TR.Value("team_duplication_reborn_status_count_down_time_format"), (int)(this._curCountDownTime + 0.5f));
			this.countDownTimeLabel.text = text;
		}

		// Token: 0x0400BAAE RID: 47790
		private float _totalCountDownTime;

		// Token: 0x0400BAAF RID: 47791
		private float _curCountDownTime;

		// Token: 0x0400BAB0 RID: 47792
		[Space(10f)]
		[Header("Cover")]
		[Space(5f)]
		[SerializeField]
		private Text countDownTimeLabel;

		// Token: 0x0400BAB1 RID: 47793
		[SerializeField]
		private Image sliderImageCover;
	}
}
