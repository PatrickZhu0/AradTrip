using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020017DC RID: 6108
	internal class ComMoneyRewaradsRankItem : MonoBehaviour
	{
		// Token: 0x0600F0BF RID: 61631 RVA: 0x0040D0C8 File Offset: 0x0040B4C8
		public void OnItemVisible(MoneyRewaradsRankItemData value)
		{
			this.data = value;
			if (this.data != null)
			{
				if (null != this.Rank)
				{
					this.Rank.text = this.data.Rank;
				}
				if (null != this.Mark)
				{
					this.Mark.CustomActive(this.data.Mark);
				}
				if (null != this.Name)
				{
					this.Name.text = this.data.name;
				}
				if (null != this.CurrentScore)
				{
					this.CurrentScore.text = this.data.score.ToString();
				}
				if (null != this.MaxScore)
				{
					this.MaxScore.text = this.data.maxScore.ToString();
				}
				if (null != this.Line)
				{
					this.Line.CustomActive(this.data.rank == 8);
				}
			}
		}

		// Token: 0x0600F0C0 RID: 61632 RVA: 0x0040D1EA File Offset: 0x0040B5EA
		private void OnDestroy()
		{
			this.data = null;
		}

		// Token: 0x040093BE RID: 37822
		public Text Rank;

		// Token: 0x040093BF RID: 37823
		public Image Mark;

		// Token: 0x040093C0 RID: 37824
		public Text Name;

		// Token: 0x040093C1 RID: 37825
		public Text CurrentScore;

		// Token: 0x040093C2 RID: 37826
		public Text MaxScore;

		// Token: 0x040093C3 RID: 37827
		public Image Line;

		// Token: 0x040093C4 RID: 37828
		private MoneyRewaradsRankItemData data;
	}
}
