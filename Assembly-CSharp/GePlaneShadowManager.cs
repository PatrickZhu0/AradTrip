using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02000CFA RID: 3322
public class GePlaneShadowManager : Singleton<GePlaneShadowManager>
{
	// Token: 0x060087F4 RID: 34804 RVA: 0x00181C44 File Offset: 0x00180044
	public override void Init()
	{
		this.m_PlaneShadowShader = AssetShaderLoader.Find("Hidden/HeroGo/PlaneShadow");
		if (null != this.m_PlaneShadowShader)
		{
			if (null == this.m_PlaneShadowMaterial)
			{
				this.m_PlaneShadowMaterial = new Material(this.m_PlaneShadowShader);
			}
			GameObject gameObject = GameObject.Find("Environment/Directional light").gameObject;
			if (null != gameObject)
			{
				Light component = gameObject.GetComponent<Light>();
				if (null != component)
				{
					component.shadows = 0;
				}
			}
			this.m_RenderCommand.name = "Plane Shadow";
			Camera.main.AddCommandBuffer(16, this.m_RenderCommand);
			this.m_ShadowSetting.m_AttenuatePow = 1f;
			this.m_ShadowSetting.m_ShadowColor = new Color(0.1f, 0.12f, 0.11f, 1f);
			this.m_ShadowSetting.m_ShadowPlane = new Vector4(0f, 1f, 0f, 0f);
		}
	}

	// Token: 0x060087F5 RID: 34805 RVA: 0x00181D44 File Offset: 0x00180144
	public override void UnInit()
	{
		for (int i = 0; i < this.m_PlaneShadowDescList.Count; i++)
		{
			this.m_PlaneShadowDescList[i].m_PlaneShadowObj = null;
			if (null != this.m_PlaneShadowDescList[i].m_PlaneShadowMat)
			{
				Object.Destroy(this.m_PlaneShadowDescList[i].m_PlaneShadowMat);
				this.m_PlaneShadowDescList[i].m_PlaneShadowMat = null;
			}
		}
		this.m_PlaneShadowDescList.Clear();
		this.m_ListDirtyCount = 0;
		if (this.m_PlaneShadowMaterial)
		{
			Object.Destroy(this.m_PlaneShadowMaterial);
		}
	}

	// Token: 0x060087F6 RID: 34806 RVA: 0x00181DF0 File Offset: 0x001801F0
	public void Update()
	{
		if (this.m_ListDirtyCount > 5)
		{
			this.m_PlaneShadowDescList.RemoveAll(delegate(GePlaneShadowManager.GePlaneShadowDesc s)
			{
				if (null == s.m_PlaneShadowObj)
				{
					if (null != s.m_PlaneShadowMat)
					{
						Object.Destroy(s.m_PlaneShadowMat);
						s.m_PlaneShadowMat = null;
					}
					return true;
				}
				return false;
			});
		}
		this.m_RenderCommand.Clear();
		for (int i = 0; i < this.m_PlaneShadowDescList.Count; i++)
		{
			GePlaneShadowManager.GePlaneShadowDesc gePlaneShadowDesc = this.m_PlaneShadowDescList[i];
			if (!(null == gePlaneShadowDesc.m_PlaneShadowObj))
			{
				if (gePlaneShadowDesc.m_PlaneShadowObj.activeInHierarchy)
				{
					Vector3 position;
					position..ctor(float.MaxValue, float.MaxValue, float.MaxValue);
					SkinnedMeshRenderer[] shadowObjRenderer = gePlaneShadowDesc.m_ShadowObjRenderer;
					float num = gePlaneShadowDesc.m_BBoxMax.y + 0.01f;
					for (int j = 0; j < shadowObjRenderer.Length; j++)
					{
						if (!(null == shadowObjRenderer[j]) && !(null == shadowObjRenderer[j].sharedMesh))
						{
							if (null != gePlaneShadowDesc.m_PlaneShadowMat)
							{
								gePlaneShadowDesc.m_PlaneShadowMat.SetVector("_ShadowLightDir", Global.Settings.shadowLightDir);
								gePlaneShadowDesc.m_PlaneShadowMat.SetVector("_ShadowPlane", gePlaneShadowDesc.m_Plane);
								gePlaneShadowDesc.m_PlaneShadowMat.SetFloat("_ShadowInvLen", 1f / (num + gePlaneShadowDesc.m_PlaneShadowObj.transform.position.y));
								position = gePlaneShadowDesc.m_PlaneShadowObj.transform.position;
								position.y = gePlaneShadowDesc.m_Plane.w;
								gePlaneShadowDesc.m_PlaneShadowMat.SetVector("_WorldRefPos", position);
								for (int k = 0; k < shadowObjRenderer[j].sharedMesh.subMeshCount; k++)
								{
									this.m_RenderCommand.DrawRenderer(shadowObjRenderer[j], gePlaneShadowDesc.m_PlaneShadowMat, k);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060087F7 RID: 34807 RVA: 0x00181FEC File Offset: 0x001803EC
	public void SetShadowSetting(GePlaneShadowManager.GePlaneShadowSetting setting)
	{
		this.m_ShadowSetting.m_AttenuatePow = setting.m_AttenuatePow;
		this.m_ShadowSetting.m_ShadowColor = setting.m_ShadowColor;
		this.m_ShadowSetting.m_ShadowPlane = setting.m_ShadowPlane;
		if (null != this.m_PlaneShadowMaterial)
		{
			this.m_PlaneShadowMaterial.SetColor("_ShadowPlaneColor", this.m_ShadowSetting.m_ShadowColor);
			this.m_PlaneShadowMaterial.SetFloat("_ShadowFadePow", this.m_ShadowSetting.m_AttenuatePow);
			this.m_PlaneShadowMaterial.SetVector("_ShadowPlane", this.m_ShadowSetting.m_ShadowPlane);
		}
	}

	// Token: 0x060087F8 RID: 34808 RVA: 0x00182090 File Offset: 0x00180490
	public void AddShadowObject(GameObject[] go, Vector4 plane)
	{
		Vector3 vector;
		vector..ctor(float.MaxValue, float.MaxValue, float.MaxValue);
		Vector3 vector2;
		vector2..ctor(float.MinValue, float.MinValue, float.MinValue);
		for (int i = 0; i < go.Length; i++)
		{
			if (!(null == go[i]))
			{
				MeshRenderer[] componentsInChildren = go[i].GetComponentsInChildren<MeshRenderer>();
				if (componentsInChildren != null)
				{
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (null != componentsInChildren[j])
						{
							vector2 = Vector3.Max(vector2, componentsInChildren[j].bounds.max);
							vector = Vector3.Min(vector, componentsInChildren[j].bounds.min);
						}
					}
				}
				SkinnedMeshRenderer[] componentsInChildren2 = go[i].GetComponentsInChildren<SkinnedMeshRenderer>();
				if (componentsInChildren2 != null)
				{
					for (int k = 0; k < componentsInChildren2.Length; k++)
					{
						if (null != componentsInChildren2[k])
						{
							vector2 = Vector3.Max(vector2, componentsInChildren2[k].bounds.max);
							vector = Vector3.Min(vector, componentsInChildren2[k].bounds.min);
						}
					}
				}
			}
		}
		for (int l = 0; l < go.Length; l++)
		{
			if (!(null == go[l]))
			{
				int num = -1;
				for (int m = 0; m < this.m_PlaneShadowDescList.Count; m++)
				{
					GePlaneShadowManager.GePlaneShadowDesc gePlaneShadowDesc = this.m_PlaneShadowDescList[m];
					if (null == gePlaneShadowDesc.m_PlaneShadowObj)
					{
						num = m;
						this.m_ListDirtyCount++;
						break;
					}
					if (gePlaneShadowDesc.m_PlaneShadowObj == go[l])
					{
						break;
					}
				}
				if (num != -1)
				{
					GePlaneShadowManager.GePlaneShadowDesc gePlaneShadowDesc2 = this.m_PlaneShadowDescList[num];
					gePlaneShadowDesc2.m_PlaneShadowObj = go[l];
					gePlaneShadowDesc2.m_ShadowObjRenderer = go[l].GetComponentsInChildren<SkinnedMeshRenderer>();
					Material mat = gePlaneShadowDesc2.m_PlaneShadowMat;
					gePlaneShadowDesc2.m_BBoxMax = vector2;
					gePlaneShadowDesc2.m_BBoxMin = vector;
					gePlaneShadowDesc2.m_Plane = plane;
					this.m_ListDirtyCount--;
				}
				else
				{
					Material mat = new Material(this.m_PlaneShadowMaterial);
					this.m_PlaneShadowDescList.Add(new GePlaneShadowManager.GePlaneShadowDesc(go[l], go[l].GetComponentsInChildren<SkinnedMeshRenderer>(), mat, vector, vector2, plane));
				}
			}
		}
	}

	// Token: 0x060087F9 RID: 34809 RVA: 0x00182304 File Offset: 0x00180704
	public void RemoveShadowObject(GameObject[] go)
	{
		if (go == null)
		{
			return;
		}
		for (int i = 0; i < go.Length; i++)
		{
			for (int j = 0; j < this.m_PlaneShadowDescList.Count; j++)
			{
				if (this.m_PlaneShadowDescList[j].m_PlaneShadowObj == go[i])
				{
					this.m_ListDirtyCount++;
					this.m_PlaneShadowDescList[j].m_PlaneShadowObj = null;
					this.m_PlaneShadowDescList[j].m_ShadowObjRenderer = null;
					break;
				}
			}
		}
	}

	// Token: 0x060087FA RID: 34810 RVA: 0x001823A0 File Offset: 0x001807A0
	public void ClearAll()
	{
		for (int i = 0; i < this.m_PlaneShadowDescList.Count; i++)
		{
			this.m_ListDirtyCount++;
			this.m_PlaneShadowDescList[i].m_PlaneShadowObj = null;
			this.m_PlaneShadowDescList[i].m_ShadowObjRenderer = null;
		}
	}

	// Token: 0x040041C1 RID: 16833
	protected List<GePlaneShadowManager.GePlaneShadowDesc> m_PlaneShadowDescList = new List<GePlaneShadowManager.GePlaneShadowDesc>();

	// Token: 0x040041C2 RID: 16834
	protected Shader m_PlaneShadowShader;

	// Token: 0x040041C3 RID: 16835
	protected Material m_PlaneShadowMaterial;

	// Token: 0x040041C4 RID: 16836
	protected GePlaneShadowManager.GePlaneShadowSetting m_ShadowSetting = new GePlaneShadowManager.GePlaneShadowSetting();

	// Token: 0x040041C5 RID: 16837
	protected CommandBuffer m_RenderCommand = new CommandBuffer();

	// Token: 0x040041C6 RID: 16838
	protected int m_ListDirtyCount;

	// Token: 0x02000CFB RID: 3323
	public class GePlaneShadowSetting
	{
		// Token: 0x040041C8 RID: 16840
		public Color m_ShadowColor;

		// Token: 0x040041C9 RID: 16841
		public Vector4 m_ShadowPlane;

		// Token: 0x040041CA RID: 16842
		public float m_AttenuatePow;
	}

	// Token: 0x02000CFC RID: 3324
	protected class GePlaneShadowDesc
	{
		// Token: 0x060087FD RID: 34813 RVA: 0x0018243C File Offset: 0x0018083C
		public GePlaneShadowDesc(GameObject go, SkinnedMeshRenderer[] asmr, Material mat, Vector3 min, Vector3 max, Vector4 plane)
		{
			this.m_PlaneShadowObj = go;
			this.m_ShadowObjRenderer = asmr;
			this.m_PlaneShadowMat = mat;
			this.m_BBoxMin = min;
			this.m_BBoxMax = max;
			this.m_Plane = plane;
		}

		// Token: 0x040041CB RID: 16843
		public GameObject m_PlaneShadowObj;

		// Token: 0x040041CC RID: 16844
		public SkinnedMeshRenderer[] m_ShadowObjRenderer;

		// Token: 0x040041CD RID: 16845
		public Material m_PlaneShadowMat;

		// Token: 0x040041CE RID: 16846
		public Vector3 m_BBoxMin = default(Vector3);

		// Token: 0x040041CF RID: 16847
		public Vector3 m_BBoxMax = default(Vector3);

		// Token: 0x040041D0 RID: 16848
		public Vector4 m_Plane = new Vector4(0f, 1f, 0f, 0.03f);
	}
}
