using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F1E RID: 3870
public class ComTags : MonoBehaviour
{
	// Token: 0x060096D9 RID: 38617 RVA: 0x001CC025 File Offset: 0x001CA425
	private void Start()
	{
		this.SetSprite(this.mDefaulteSprite);
	}

	// Token: 0x060096DA RID: 38618 RVA: 0x001CC034 File Offset: 0x001CA434
	public void SetSprite(Sprite sprite)
	{
		for (int i = 0; i < this.mImageArray.Length; i++)
		{
			this.mImageArray[i].sprite = sprite;
		}
	}

	// Token: 0x060096DB RID: 38619 RVA: 0x001CC068 File Offset: 0x001CA468
	public void SetTag(int cnt)
	{
		if (cnt >= 0 && cnt != this.mCount)
		{
			int num = this.mImageArray.Length;
			this.mCount = cnt;
			for (int i = 0; i < cnt; i++)
			{
				this.mImageArray[i].gameObject.SetActive(true);
			}
			for (int j = cnt; j < num; j++)
			{
				this.mImageArray[j].gameObject.SetActive(false);
			}
		}
	}

	// Token: 0x04004D91 RID: 19857
	public Image[] mImageArray;

	// Token: 0x04004D92 RID: 19858
	public Sprite mDefaulteSprite;

	// Token: 0x04004D93 RID: 19859
	private int mCount = -1;
}
