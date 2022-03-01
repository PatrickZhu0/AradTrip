using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001671 RID: 5745
	public class HonorCommonItem : MonoBehaviour
	{
		// Token: 0x0600E1E9 RID: 57833 RVA: 0x003A0CCC File Offset: 0x0039F0CC
		public void InitItem(PvpNumberStatistics pvpNumberStatistics)
		{
			if (pvpNumberStatistics == null)
			{
				return;
			}
			if (this.activityNameText != null)
			{
				this.activityNameText.text = pvpNumberStatistics.PvpName;
			}
			if (this.activityNumberText != null)
			{
				this.activityNumberText.text = pvpNumberStatistics.PvpCount.ToString();
			}
		}

		// Token: 0x04008731 RID: 34609
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text activityNameText;

		// Token: 0x04008732 RID: 34610
		[SerializeField]
		private Text activityNumberText;
	}
}
