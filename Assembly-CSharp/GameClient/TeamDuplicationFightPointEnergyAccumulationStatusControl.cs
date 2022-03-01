using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C85 RID: 7301
	public class TeamDuplicationFightPointEnergyAccumulationStatusControl : MonoBehaviour
	{
		// Token: 0x06011E91 RID: 73361 RVA: 0x0053D2E4 File Offset: 0x0053B6E4
		public void Init(int startTime)
		{
			this._startTime = startTime;
			this.UpdateStatusView();
		}

		// Token: 0x06011E92 RID: 73362 RVA: 0x0053D2F4 File Offset: 0x0053B6F4
		public void UpdateStatusView()
		{
			int num = (int)(DataManager<TimeManager>.GetInstance().GetServerTime() - (uint)this._startTime);
			if (num <= 0)
			{
				num = 0;
			}
			float fillAmount;
			if (num >= 1000)
			{
				fillAmount = 1f;
			}
			else
			{
				fillAmount = (float)num / 1000f;
			}
			if (this.sliderImageCover != null)
			{
				this.sliderImageCover.fillAmount = fillAmount;
			}
			int num2 = 0;
			int num3;
			if (num >= 1000)
			{
				num3 = 100;
			}
			else
			{
				num3 = num / 10;
				num2 = num % 10;
			}
			if (this.countDownTimeLabel != null)
			{
				if (num3 >= 100)
				{
					this.countDownTimeLabel.text = string.Format(TR.Value("team_duplication_fight_point_energy_accumulation_percent_format_second"), 100);
				}
				else if (num2 == 0)
				{
					this.countDownTimeLabel.text = string.Format(TR.Value("team_duplication_fight_point_energy_accumulation_percent_format_second"), num3);
				}
				else
				{
					this.countDownTimeLabel.text = string.Format(TR.Value("team_duplication_fight_point_energy_accumulation_percent_format_one"), num3, num2);
				}
			}
			if (num3 < 100)
			{
				CommonUtility.UpdateTextVisible(this.energyAccumulationProcessingLabel, true);
				CommonUtility.UpdateTextVisible(this.energyAccumulationFinishedLabel, false);
			}
			else
			{
				CommonUtility.UpdateTextVisible(this.energyAccumulationProcessingLabel, false);
				CommonUtility.UpdateTextVisible(this.energyAccumulationFinishedLabel, true);
			}
		}

		// Token: 0x0400BAA8 RID: 47784
		private int _startTime;

		// Token: 0x0400BAA9 RID: 47785
		[Space(10f)]
		[Header("Cover")]
		[Space(5f)]
		[SerializeField]
		private Text countDownTimeLabel;

		// Token: 0x0400BAAA RID: 47786
		[SerializeField]
		private Image sliderImageCover;

		// Token: 0x0400BAAB RID: 47787
		[SerializeField]
		private Text energyAccumulationFinishedLabel;

		// Token: 0x0400BAAC RID: 47788
		[SerializeField]
		private Text energyAccumulationProcessingLabel;
	}
}
