using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI.Extensions;

// Token: 0x02000E8E RID: 3726
public class ComChapterSelectUnlock : MonoBehaviour
{
	// Token: 0x0600936B RID: 37739 RVA: 0x001B83D8 File Offset: 0x001B67D8
	private int _updateChild()
	{
		int childCount = base.transform.childCount;
		this.mPositionList = new Vector2[childCount];
		for (int i = 0; i < childCount; i++)
		{
			Transform child = base.transform.GetChild(i);
			if (null != child)
			{
				this.mPositionList[i] = child.localPosition;
			}
			else
			{
				this.mPositionList[i] = Vector3.zero;
			}
			this.mPositionList[i] += this.mOffset;
		}
		return 0;
	}

	// Token: 0x0600936C RID: 37740 RVA: 0x001B8488 File Offset: 0x001B6888
	private void _updateLine()
	{
		List<Vector2> list = new List<Vector2>();
		this.mUnlockCount = Mathf.Min(this.mUnlockCount, this.mPositionList.Length);
		for (int i = 0; i < this.mUnlockCount; i++)
		{
			list.Add(this.mPositionList[i]);
		}
		if (list.Count > 1)
		{
			this.mUnlockLineRender.enabled = true;
			this.mUnlockLineRender.Points = list.ToArray();
			this.mUnlockLineRender.SetVerticesDirty();
		}
		else
		{
			this.mUnlockLineRender.enabled = false;
		}
		list.Clear();
		for (int j = Mathf.Max(0, this.mUnlockCount - 1); j < this.mPositionList.Length; j++)
		{
			list.Add(this.mPositionList[j]);
		}
		if (list.Count > 1)
		{
			this.mLockLineRender.enabled = true;
			this.mLockLineRender.Points = list.ToArray();
			this.mLockLineRender.SetVerticesDirty();
		}
		else
		{
			this.mLockLineRender.enabled = false;
		}
		list.Clear();
	}

	// Token: 0x0600936D RID: 37741 RVA: 0x001B85B5 File Offset: 0x001B69B5
	public void SetUnlockCount(int unlockCount)
	{
		this.mUnlockCount = unlockCount;
		this._updateChild();
		this._updateLine();
	}

	// Token: 0x0600936E RID: 37742 RVA: 0x001B85CB File Offset: 0x001B69CB
	public void SetVisible(bool isVisible)
	{
		this.mLockLineRender.enabled = isVisible;
		this.mUnlockLineRender.enabled = isVisible;
		if (isVisible)
		{
			this.SetUnlockCount(this.mUnlockCount);
		}
	}

	// Token: 0x04004A6D RID: 19053
	public int mUnlockCount = 2;

	// Token: 0x04004A6E RID: 19054
	public Vector2 mOffset = Vector2.one * 50f;

	// Token: 0x04004A6F RID: 19055
	public UILineRenderer mUnlockLineRender;

	// Token: 0x04004A70 RID: 19056
	public UILineRenderer mLockLineRender;

	// Token: 0x04004A71 RID: 19057
	public Vector2[] mPositionList = new Vector2[0];
}
