using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001693 RID: 5779
	public class HorseGamblingShooterRecordItem : MonoBehaviour, IDisposable
	{
		// Token: 0x0600E308 RID: 58120 RVA: 0x003A5578 File Offset: 0x003A3978
		public void Init(string gameId, string odds, bool isWin, string bg)
		{
			this.mTextGameId.SafeSetText(gameId);
			this.mTextOdds.SafeSetText(odds);
			if (isWin)
			{
				ETCImageLoader.LoadSprite(ref this.mImageResult, this.mWinSpritePath, true);
			}
			else
			{
				ETCImageLoader.LoadSprite(ref this.mImageResult, this.mLoseSpritePath, true);
			}
			ETCImageLoader.LoadSprite(ref this.mImageBg, bg, true);
		}

		// Token: 0x0600E309 RID: 58121 RVA: 0x003A55DD File Offset: 0x003A39DD
		public void Dispose()
		{
		}

		// Token: 0x040087F3 RID: 34803
		[SerializeField]
		private Text mTextGameId;

		// Token: 0x040087F4 RID: 34804
		[SerializeField]
		private Text mTextOdds;

		// Token: 0x040087F5 RID: 34805
		[SerializeField]
		private Image mImageResult;

		// Token: 0x040087F6 RID: 34806
		[SerializeField]
		private Image mImageBg;

		// Token: 0x040087F7 RID: 34807
		[SerializeField]
		private string mWinSpritePath;

		// Token: 0x040087F8 RID: 34808
		[SerializeField]
		private string mLoseSpritePath;
	}
}
