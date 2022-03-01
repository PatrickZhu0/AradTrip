using System;
using Protocol;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E81 RID: 3713
[ExecuteInEditMode]
public class ComChapterDungeonScore : MonoBehaviour
{
	// Token: 0x0600930B RID: 37643 RVA: 0x001B589C File Offset: 0x001B3C9C
	public void SetScore(DungeonScore score)
	{
		this.mScore = score;
		if (null != this.mBind)
		{
			Image com = this.mBind.GetCom<Image>("score");
			Image com2 = this.mBind.GetCom<Image>("scorebutton");
			string name = score.ToString().ToLower();
			if (null != com2)
			{
				this.mBind.GetSprite(name, ref com2);
				if (com2.sprite == null)
				{
					this.mBind.GetSprite("unpass", ref com2);
				}
				com2.SetNativeSize();
			}
			if (null != com)
			{
				this.mBind.GetSprite(name, ref com);
				if (com == null)
				{
					this.mBind.GetSprite("unpass", ref com);
				}
				com.SetNativeSize();
			}
		}
	}

	// Token: 0x04004A0C RID: 18956
	public DungeonScore mScore;

	// Token: 0x04004A0D RID: 18957
	public ComCommonBind mBind;
}
