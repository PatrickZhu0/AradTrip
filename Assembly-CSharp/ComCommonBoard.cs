using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000E92 RID: 3730
public class ComCommonBoard : MonoBehaviour
{
	// Token: 0x060093AD RID: 37805 RVA: 0x001B9C18 File Offset: 0x001B8018
	public GameObject GetRoot(ComCommonBoard.ePosition pos)
	{
		switch (pos)
		{
		case ComCommonBoard.ePosition.Left:
			if (this.mLeft)
			{
				return this.mLeft;
			}
			break;
		case ComCommonBoard.ePosition.Right:
			if (this.mRight)
			{
				return this.mRight;
			}
			break;
		case ComCommonBoard.ePosition.Top:
			if (this.mTop)
			{
				return this.mTop;
			}
			break;
		case ComCommonBoard.ePosition.Buttom:
			if (this.mButtom)
			{
				return this.mButtom;
			}
			break;
		case ComCommonBoard.ePosition.Background:
			if (this.mBg)
			{
				return this.mBg.gameObject;
			}
			break;
		default:
			return null;
		}
		return null;
	}

	// Token: 0x060093AE RID: 37806 RVA: 0x001B9CD8 File Offset: 0x001B80D8
	public GameObject AttachPrefab(string path, ComCommonBoard.ePosition pos, int index = -1)
	{
		GameObject root = this.GetRoot(pos);
		if (null == root)
		{
			return null;
		}
		GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(path, true, 0U);
		if (null == gameObject)
		{
			return null;
		}
		Utility.AttachTo(gameObject, root, false);
		gameObject.name = CFileManager.GetFullName(path);
		gameObject.transform.SetSiblingIndex(index);
		return gameObject;
	}

	// Token: 0x060093AF RID: 37807 RVA: 0x001B9D38 File Offset: 0x001B8138
	public GameObject TopRoot()
	{
		return this.mTop;
	}

	// Token: 0x060093B0 RID: 37808 RVA: 0x001B9D40 File Offset: 0x001B8140
	public void SetBackgroundImage(string spritePath)
	{
		if (null != this.mBg)
		{
			ETCImageLoader.LoadSprite(ref this.mBg, spritePath, true);
		}
	}

	// Token: 0x060093B1 RID: 37809 RVA: 0x001B9D61 File Offset: 0x001B8161
	public void SetCloseImage(Sprite op)
	{
		if (null != this.mClose)
		{
			this.mClose.image.sprite = op;
		}
	}

	// Token: 0x060093B2 RID: 37810 RVA: 0x001B9D85 File Offset: 0x001B8185
	public void SetBackImage(Sprite op)
	{
		if (null != this.mBack)
		{
			this.mBack.image.sprite = op;
		}
	}

	// Token: 0x060093B3 RID: 37811 RVA: 0x001B9DA9 File Offset: 0x001B81A9
	public void OnClose(UnityAction action)
	{
		if (null != this.mClose)
		{
			this.mClose.onClick.AddListener(action);
		}
	}

	// Token: 0x060093B4 RID: 37812 RVA: 0x001B9DCD File Offset: 0x001B81CD
	public void OnBack(UnityAction action)
	{
		if (null != this.mBack)
		{
			this.mBack.onClick.AddListener(action);
		}
	}

	// Token: 0x04004AAB RID: 19115
	public Image mBg;

	// Token: 0x04004AAC RID: 19116
	public GameObject mLeft;

	// Token: 0x04004AAD RID: 19117
	public GameObject mRight;

	// Token: 0x04004AAE RID: 19118
	public GameObject mTop;

	// Token: 0x04004AAF RID: 19119
	public GameObject mButtom;

	// Token: 0x04004AB0 RID: 19120
	public Button mClose;

	// Token: 0x04004AB1 RID: 19121
	public Button mBack;

	// Token: 0x02000E93 RID: 3731
	public enum ePosition
	{
		// Token: 0x04004AB3 RID: 19123
		Left,
		// Token: 0x04004AB4 RID: 19124
		Right,
		// Token: 0x04004AB5 RID: 19125
		Top,
		// Token: 0x04004AB6 RID: 19126
		Buttom,
		// Token: 0x04004AB7 RID: 19127
		Background
	}
}
