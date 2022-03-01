using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CF5 RID: 3317
public class GeMeshRenderManager : Singleton<GeMeshRenderManager>
{
	// Token: 0x060087D4 RID: 34772 RVA: 0x001812CA File Offset: 0x0017F6CA
	public bool Init(GameObject mainCamera)
	{
		return true;
	}

	// Token: 0x060087D5 RID: 34773 RVA: 0x001812CD File Offset: 0x0017F6CD
	public void Deinit()
	{
	}

	// Token: 0x060087D6 RID: 34774 RVA: 0x001812D0 File Offset: 0x0017F6D0
	public void AddMeshObject(GameObject gameObject)
	{
	}

	// Token: 0x060087D7 RID: 34775 RVA: 0x001812EA File Offset: 0x0017F6EA
	public void Sort()
	{
	}

	// Token: 0x060087D8 RID: 34776 RVA: 0x001812EC File Offset: 0x0017F6EC
	protected void CameraPreRender(Camera cam)
	{
		if (null != this.m_Camera && cam == this.m_Camera)
		{
			this.Sort();
		}
	}

	// Token: 0x04004195 RID: 16789
	protected List<GeMeshRenderManager.GeMeshObjectDesc> m_MeshObjectList = new List<GeMeshRenderManager.GeMeshObjectDesc>();

	// Token: 0x04004196 RID: 16790
	protected List<GeMeshRenderManager.GeMeshRenderDesc> m_MeshRenderList = new List<GeMeshRenderManager.GeMeshRenderDesc>();

	// Token: 0x04004197 RID: 16791
	protected GameObject m_CameraNode;

	// Token: 0x04004198 RID: 16792
	protected Camera m_Camera;

	// Token: 0x02000CF6 RID: 3318
	public class GeMeshRenderDesc
	{
		// Token: 0x04004199 RID: 16793
		public Renderer m_Renderer;

		// Token: 0x0400419A RID: 16794
		public Canvas m_Canvas;

		// Token: 0x0400419B RID: 16795
		public Vector3 m_Center = Vector3.zero;

		// Token: 0x0400419C RID: 16796
		public float m_ZDepth;

		// Token: 0x0400419D RID: 16797
		public int m_unOriginOrder;

		// Token: 0x0400419E RID: 16798
		public GameObject m_RootObject;
	}

	// Token: 0x02000CF7 RID: 3319
	public class GeMeshObjectDesc
	{
		// Token: 0x0400419F RID: 16799
		public GameObject m_RootObject;
	}
}
