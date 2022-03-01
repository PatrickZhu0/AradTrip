using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C84 RID: 7300
	public class TeamDuplicationFightPointBossBloodControl : MonoBehaviour
	{
		// Token: 0x06011E8F RID: 73359 RVA: 0x0053D2A0 File Offset: 0x0053B6A0
		public void UpdateBossBloodRate(int bloodRate)
		{
			if (this.bossBloodCoverImage == null)
			{
				return;
			}
			if (bloodRate < 0)
			{
				return;
			}
			float fillAmount = (float)bloodRate / 100f;
			this.bossBloodCoverImage.fillAmount = fillAmount;
		}

		// Token: 0x0400BAA7 RID: 47783
		[Space(10f)]
		[Header("Cover")]
		[Space(5f)]
		[SerializeField]
		private Image bossBloodCoverImage;
	}
}
