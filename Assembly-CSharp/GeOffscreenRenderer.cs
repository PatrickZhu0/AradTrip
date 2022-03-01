using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CF9 RID: 3321
public class GeOffscreenRenderer
{
	// Token: 0x060087EE RID: 34798 RVA: 0x00181A54 File Offset: 0x0017FE54
	public bool Init(string rendTextureNode, int width, int height, int layer = 12)
	{
		if (null == this.m_OffscreenRoot)
		{
			this.m_OffscreenRoot = new GameObject("OffscreenRender");
		}
		this.m_RenderTexture = Singleton<GeRenderTextureManager>.instance.CreateRenderTexture(rendTextureNode, layer, width, height);
		if (this.m_RenderTexture != null)
		{
			this.m_DirectionalLight = this.m_RenderTexture.GetLight();
			this.m_AvatarCamera = this.m_RenderTexture.GetCamera();
			if (null != this.m_AvatarCamera)
			{
				this.m_RenderLayer = layer;
				return true;
			}
		}
		return false;
	}

	// Token: 0x060087EF RID: 34799 RVA: 0x00181AE8 File Offset: 0x0017FEE8
	public void Deinit()
	{
		this.ClearAll();
		if (this.m_RenderTexture != null)
		{
			Singleton<GeRenderTextureManager>.instance.DestroyRenderTexture(this.m_RenderTexture);
			this.m_RenderTexture = null;
			this.m_DirectionalLight = null;
			this.m_AvatarCamera = null;
		}
		if (this.m_OffscreenRoot)
		{
			Object.Destroy(this.m_OffscreenRoot);
			this.m_OffscreenRoot = null;
		}
	}

	// Token: 0x060087F0 RID: 34800 RVA: 0x00181B50 File Offset: 0x0017FF50
	public void AddRenderObject(GameObject go)
	{
		if (!this.m_RenderObjList.Contains(go))
		{
			go.layer = this.m_RenderLayer;
			Renderer[] componentsInChildren = go.GetComponentsInChildren<Renderer>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (null != componentsInChildren[i])
				{
					componentsInChildren[i].gameObject.layer = this.m_RenderLayer;
				}
			}
			this.m_RenderObjList.Add(go);
		}
	}

	// Token: 0x060087F1 RID: 34801 RVA: 0x00181BC4 File Offset: 0x0017FFC4
	public void RemoveRenderObject(GameObject go)
	{
		this.m_RenderObjList.RemoveAll((GameObject f) => go == f);
	}

	// Token: 0x060087F2 RID: 34802 RVA: 0x00181BF6 File Offset: 0x0017FFF6
	public void ClearAll()
	{
		this.m_RenderObjList.Clear();
	}

	// Token: 0x040041BB RID: 16827
	protected IGeRenderTexture m_RenderTexture;

	// Token: 0x040041BC RID: 16828
	protected Light m_DirectionalLight;

	// Token: 0x040041BD RID: 16829
	protected Camera m_AvatarCamera;

	// Token: 0x040041BE RID: 16830
	protected List<GameObject> m_RenderObjList = new List<GameObject>();

	// Token: 0x040041BF RID: 16831
	protected GameObject m_OffscreenRoot;

	// Token: 0x040041C0 RID: 16832
	protected int m_RenderLayer;
}
