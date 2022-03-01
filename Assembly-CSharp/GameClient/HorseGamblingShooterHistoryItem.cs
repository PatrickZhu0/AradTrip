using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001692 RID: 5778
	public class HorseGamblingShooterHistoryItem : MonoBehaviour
	{
		// Token: 0x0600E306 RID: 58118 RVA: 0x003A54E4 File Offset: 0x003A38E4
		public void Init(string gameId, string name, string odds, string imagePath, bool isWin, string bgPath)
		{
			this.mTextGameId.SafeSetText(gameId);
			this.mTextName.SafeSetText(name);
			this.mTextOdds.SafeSetText(odds);
			if (!string.IsNullOrEmpty(imagePath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, imagePath, true);
			}
			if (!string.IsNullOrEmpty(bgPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageBg, bgPath, true);
			}
			ETCImageLoader.LoadSprite(ref this.mImageResult, (!isWin) ? this.mLosePath : this.mWinPath, true);
		}

		// Token: 0x040087EB RID: 34795
		[SerializeField]
		private Image mImageBg;

		// Token: 0x040087EC RID: 34796
		[SerializeField]
		private Text mTextGameId;

		// Token: 0x040087ED RID: 34797
		[SerializeField]
		private Image mImageIcon;

		// Token: 0x040087EE RID: 34798
		[SerializeField]
		private Text mTextName;

		// Token: 0x040087EF RID: 34799
		[SerializeField]
		private Text mTextOdds;

		// Token: 0x040087F0 RID: 34800
		[SerializeField]
		private Image mImageResult;

		// Token: 0x040087F1 RID: 34801
		[SerializeField]
		private string mWinPath = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_Text_Shengli";

		// Token: 0x040087F2 RID: 34802
		[SerializeField]
		private string mLosePath = "UI/Image/Packed/p_UI_Duma.png:UI_Duma_Text_ShiBai";
	}
}
