using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001684 RID: 5764
	public class HorseGamblingGameRecordItem : MonoBehaviour
	{
		// Token: 0x0600E2A1 RID: 58017 RVA: 0x003A3720 File Offset: 0x003A1B20
		public void Init(string text1, string text2, string text3, string text4, string imagePath, string bgPath)
		{
			this.mText1.SafeSetText(text1);
			this.mText2.SafeSetText(text2);
			this.mText3.SafeSetText(text3);
			this.mText4.SafeSetText(text4);
			if (!string.IsNullOrEmpty(imagePath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageIcon, imagePath, true);
			}
			if (!string.IsNullOrEmpty(bgPath))
			{
				ETCImageLoader.LoadSprite(ref this.mImageBg, bgPath, true);
			}
		}

		// Token: 0x04008797 RID: 34711
		[SerializeField]
		private Image mImageBg;

		// Token: 0x04008798 RID: 34712
		[SerializeField]
		private Text mText1;

		// Token: 0x04008799 RID: 34713
		[SerializeField]
		private Image mImageIcon;

		// Token: 0x0400879A RID: 34714
		[SerializeField]
		private Text mText2;

		// Token: 0x0400879B RID: 34715
		[SerializeField]
		private Text mText3;

		// Token: 0x0400879C RID: 34716
		[SerializeField]
		private Text mText4;
	}
}
