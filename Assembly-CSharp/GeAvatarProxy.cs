using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CE9 RID: 3305
public class GeAvatarProxy : MonoBehaviour
{
	// Token: 0x17001823 RID: 6179
	// (get) Token: 0x06008765 RID: 34661 RVA: 0x0017E09D File Offset: 0x0017C49D
	// (set) Token: 0x06008766 RID: 34662 RVA: 0x0017E0A5 File Offset: 0x0017C4A5
	public Object avatar
	{
		get
		{
			return this.m_Avatar;
		}
		set
		{
			this.m_Avatar = value;
		}
	}

	// Token: 0x17001824 RID: 6180
	// (get) Token: 0x06008767 RID: 34663 RVA: 0x0017E0AE File Offset: 0x0017C4AE
	public int[] skelRemapOffset
	{
		get
		{
			return this.m_SkelRemapOffest;
		}
	}

	// Token: 0x17001825 RID: 6181
	// (get) Token: 0x06008768 RID: 34664 RVA: 0x0017E0B6 File Offset: 0x0017C4B6
	public int[] skelRemapTable
	{
		get
		{
			return this.m_SkelRemapTable;
		}
	}

	// Token: 0x06008769 RID: 34665 RVA: 0x0017E0C0 File Offset: 0x0017C4C0
	public void RefreshAvatarDesc()
	{
		Transform[] array = null;
		List<int> list = new List<int>();
		List<int> list2 = new List<int>();
		if (array == null)
		{
			GameObject gameObject = this.m_Avatar as GameObject;
			array = gameObject.transform.GetChild(0).GetComponentsInChildren<Transform>();
		}
		SkinnedMeshRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
		int num = 0;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			list2.Add(num);
			SkinnedMeshRenderer skinnedMeshRenderer = componentsInChildren[i];
			if (null != skinnedMeshRenderer)
			{
				Transform[] bones = skinnedMeshRenderer.bones;
				for (int j = 0; j < bones.Length; j++)
				{
					list.Add(this._FindSkeletonBone(array, bones[j]));
				}
				num += skinnedMeshRenderer.bones.Length;
			}
		}
		this.m_SkelRemapTable = new int[list.Count];
		for (int k = 0; k < list.Count; k++)
		{
			this.m_SkelRemapTable[k] = list[k];
		}
		this.m_SkelRemapOffest = new int[list2.Count];
		for (int l = 0; l < list2.Count; l++)
		{
			this.m_SkelRemapOffest[l] = list2[l];
		}
	}

	// Token: 0x0600876A RID: 34666 RVA: 0x0017E204 File Offset: 0x0017C604
	private int _FindSkeletonBone(Transform[] skeleton, Transform bone)
	{
		if (skeleton != null && null != bone)
		{
			for (int i = 0; i < skeleton.Length; i++)
			{
				if (!(null == skeleton[i]))
				{
					if (skeleton[i].name.Equals(bone.name))
					{
						return i;
					}
				}
			}
		}
		return -1;
	}

	// Token: 0x04004126 RID: 16678
	[SerializeField]
	protected Object m_Avatar;

	// Token: 0x04004127 RID: 16679
	[SerializeField]
	protected int[] m_SkelRemapOffest = new int[0];

	// Token: 0x04004128 RID: 16680
	[SerializeField]
	protected int[] m_SkelRemapTable = new int[0];
}
