using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C89 RID: 7305
	public class TeamDuplicationFightPointUnlockStatusControl : MonoBehaviour
	{
		// Token: 0x06011EA2 RID: 73378 RVA: 0x0053D8B4 File Offset: 0x0053BCB4
		public void UpdateUnlockRate(int unlockRate)
		{
			if (unlockRate < 0)
			{
				return;
			}
			if (this.unlockRateLabel != null)
			{
				string text = string.Format(TR.Value("team_duplication_fight_point_unlock_rate_format"), unlockRate);
				this.unlockRateLabel.text = text;
			}
		}

		// Token: 0x0400BABB RID: 47803
		[Space(10f)]
		[Header("Cover")]
		[Space(5f)]
		[SerializeField]
		private Text unlockRateLabel;

		// Token: 0x0400BABC RID: 47804
		[SerializeField]
		private Image unlockSliderImage;
	}
}
