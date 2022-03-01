using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010AD RID: 4269
	public class DungeonMenuPlayerItem : MonoBehaviour
	{
		// Token: 0x0600A112 RID: 41234 RVA: 0x00209EB0 File Offset: 0x002082B0
		public void InitPlayerItem(BattlePlayer battlePlayer, long maxScore, long totalScore, bool isHighest)
		{
			if (battlePlayer == null || battlePlayer.playerActor == null)
			{
				return;
			}
			BeEntity topOwner = battlePlayer.playerActor.GetTopOwner(battlePlayer.playerActor);
			if (topOwner == null)
			{
				return;
			}
			if (topOwner.GetEntityData() == null || topOwner.GetEntityData().battleData == null)
			{
				return;
			}
			long totalDamage = topOwner.GetEntityData().battleData.GetTotalDamage();
			if (this.mName != null)
			{
				this.mName.text = battlePlayer.playerInfo.name;
			}
			if (this.mJobName != null)
			{
				this.mJobName.text = Utility.GetJobName((int)battlePlayer.playerInfo.occupation, 0);
			}
			if (this.mLevel != null)
			{
				this.mLevel.text = string.Format("Lv.{0}", battlePlayer.playerInfo.level.ToString());
			}
			if (this.mDamage != null)
			{
				this.mDamage.text = totalDamage.ToString();
			}
			if (this.mPrecentage != null && totalScore != 0L)
			{
				this.mPrecentage.text = string.Format("{0}%", ((double)totalDamage * 100.0 / (double)totalScore).ToString("f1"));
			}
			if (this.mDamageSlider != null && maxScore != 0L)
			{
				this.mDamageSlider.value = (float)totalDamage * 1f / (float)maxScore;
			}
			if (this.mHighestScore != null)
			{
				if (isHighest)
				{
					this.mHighestScore.CustomActive(true);
				}
				else
				{
					this.mHighestScore.CustomActive(false);
				}
			}
		}

		// Token: 0x04005995 RID: 22933
		[SerializeField]
		private Text mName;

		// Token: 0x04005996 RID: 22934
		[SerializeField]
		private Text mJobName;

		// Token: 0x04005997 RID: 22935
		[SerializeField]
		private Text mLevel;

		// Token: 0x04005998 RID: 22936
		[SerializeField]
		private Text mDamage;

		// Token: 0x04005999 RID: 22937
		[SerializeField]
		private Text mPrecentage;

		// Token: 0x0400599A RID: 22938
		[SerializeField]
		private Slider mDamageSlider;

		// Token: 0x0400599B RID: 22939
		[SerializeField]
		private GameObject mHighestScore;
	}
}
