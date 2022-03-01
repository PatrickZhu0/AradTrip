using System;
using UnityEngine;

// Token: 0x02000DBD RID: 3517
public class ClientObjectFactory : MonoBehaviour
{
	// Token: 0x06008E6F RID: 36463 RVA: 0x001A6C2C File Offset: 0x001A502C
	public void OnOpenFrame()
	{
		for (int i = 0; i < this.m_akObjects.Length; i++)
		{
			if (this.m_akObjects[i] != null && this.m_akObjects[i].IsOpenCreate)
			{
				this.m_akObjects[i].Create();
			}
		}
	}

	// Token: 0x06008E70 RID: 36464 RVA: 0x001A6C84 File Offset: 0x001A5084
	public void OnCloseFrame()
	{
	}

	// Token: 0x0400469D RID: 18077
	public ClientObjectFactory.FrameBinderGroup[] m_akBinderGroups;

	// Token: 0x0400469E RID: 18078
	public CachedObjectBehavior[] m_akObjects;

	// Token: 0x0400469F RID: 18079
	public string m_kPrefabPath;

	// Token: 0x02000DBE RID: 3518
	[Serializable]
	public class FrameBinder
	{
		// Token: 0x040046A0 RID: 18080
		public GameObject goLocal;

		// Token: 0x040046A1 RID: 18081
		public string varName;

		// Token: 0x040046A2 RID: 18082
		public CachedObjectBehavior.UIBinder.BinderType eBinderType = CachedObjectBehavior.UIBinder.BinderType.BT_INVALID;
	}

	// Token: 0x02000DBF RID: 3519
	[Serializable]
	public class FrameBinderGroup
	{
		// Token: 0x040046A3 RID: 18083
		public ClientObjectFactory.FrameBinder[] m_akFrameBinders;

		// Token: 0x040046A4 RID: 18084
		public string Tag;
	}
}
