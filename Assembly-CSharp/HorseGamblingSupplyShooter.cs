using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001696 RID: 5782
public class HorseGamblingSupplyShooter : MonoBehaviour
{
	// Token: 0x0600E315 RID: 58133 RVA: 0x003A5A5C File Offset: 0x003A3E5C
	public void Init(string iconPath, int supply, bool isShowResult = false, bool isWin = false)
	{
		if (!string.IsNullOrEmpty(iconPath))
		{
			ETCImageLoader.LoadSprite(ref this.mImageIcon, iconPath, true);
		}
		if (isShowResult)
		{
			this.mWinGO.CustomActive(isWin);
			this.mLoseGO.CustomActive(!isWin);
			this.mImageDeath.CustomActive(!isWin);
			this.mGray.enabled = !isWin;
		}
		else
		{
			this.mWinGO.CustomActive(false);
			this.mLoseGO.CustomActive(false);
			this.mImageDeath.CustomActive(false);
			this.mGray.enabled = false;
		}
		this.mTextSupply.SafeSetText(supply.ToString());
	}

	// Token: 0x04008802 RID: 34818
	[SerializeField]
	private Image mImageIcon;

	// Token: 0x04008803 RID: 34819
	[SerializeField]
	private Text mTextSupply;

	// Token: 0x04008804 RID: 34820
	[SerializeField]
	private GameObject mWinGO;

	// Token: 0x04008805 RID: 34821
	[SerializeField]
	private GameObject mLoseGO;

	// Token: 0x04008806 RID: 34822
	[SerializeField]
	private UIGray mGray;

	// Token: 0x04008807 RID: 34823
	[SerializeField]
	private GameObject mImageDeath;
}
