using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E7C RID: 3708
public class ComChapterCharactor : MonoBehaviour, IChapterCharactor
{
	// Token: 0x060092F0 RID: 37616 RVA: 0x001B4BE0 File Offset: 0x001B2FE0
	public void SetCharactor(string spritePath)
	{
		if (null != this.mImage)
		{
			ETCImageLoader.LoadSprite(ref this.mImage, spritePath, true);
		}
	}

	// Token: 0x040049F1 RID: 18929
	public Image mImage;
}
