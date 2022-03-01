using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001694 RID: 5780
	public class HorseGamblingStakeRecordItem : MonoBehaviour
	{
		// Token: 0x0600E30B RID: 58123 RVA: 0x003A55E8 File Offset: 0x003A39E8
		public void Init(string gameId, string name, string odds, string stake, int profit, string imagePath, string bgPath)
		{
			this.mTextGameId.SafeSetText(gameId);
			this.mTextName.SafeSetText(name);
			this.mTextOdds.SafeSetText(odds);
			this.mTextStake.SafeSetText(stake);
			if (profit == -1)
			{
				this.mTextProfit.SafeSetText(TR.Value("horse_gambling_profit_not_lottery"));
			}
			else
			{
				this.mTextProfit.SafeSetText(profit.ToString());
			}
			if (!string.IsNullOrEmpty(imagePath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, imagePath, true);
			}
			if (!string.IsNullOrEmpty(bgPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageBg, bgPath, true);
			}
		}

		// Token: 0x040087F9 RID: 34809
		[SerializeField]
		private Image mImageBg;

		// Token: 0x040087FA RID: 34810
		[SerializeField]
		private Text mTextGameId;

		// Token: 0x040087FB RID: 34811
		[SerializeField]
		private Image mImageIcon;

		// Token: 0x040087FC RID: 34812
		[SerializeField]
		private Text mTextName;

		// Token: 0x040087FD RID: 34813
		[SerializeField]
		private Text mTextOdds;

		// Token: 0x040087FE RID: 34814
		[SerializeField]
		private Text mTextStake;

		// Token: 0x040087FF RID: 34815
		[SerializeField]
		private Text mTextProfit;
	}
}
