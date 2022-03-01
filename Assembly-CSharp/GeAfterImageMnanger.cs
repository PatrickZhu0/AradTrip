using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CC4 RID: 3268
public class GeAfterImageMnanger
{
	// Token: 0x0600867F RID: 34431 RVA: 0x00178385 File Offset: 0x00176785
	public bool Init()
	{
		this.m_Shader = AssetShaderLoader.Find("HeroGo/General/UnLit/MonoColor");
		return null != this.m_Shader;
	}

	// Token: 0x06008680 RID: 34432 RVA: 0x001783AB File Offset: 0x001767AB
	public void Deinit()
	{
		this.m_SnapModelList.RemoveAll(delegate(GeAfterImageMnanger.GeSnapModelDesc f)
		{
			int i = 0;
			int count = f.m_BakedObjDescList.Count;
			while (i < count)
			{
				Object.Destroy(f.m_BakedObjDescList[i].m_BakedObject);
				Object.Destroy(f.m_BakedObjDescList[i].m_Mesh);
				Material[] bakedMaterials = f.m_BakedObjDescList[i].m_BakedMaterials;
				int j = 0;
				int num = bakedMaterials.Length;
				while (j < num)
				{
					Object.Destroy(bakedMaterials[j]);
					j++;
				}
				i++;
			}
			return true;
		});
	}

	// Token: 0x06008681 RID: 34433 RVA: 0x001783D8 File Offset: 0x001767D8
	public void CreateSnapshot(GameObject[] objList, Color32 color, int nTimeLen, string materialPath)
	{
		Material material;
		if (string.IsNullOrEmpty(materialPath))
		{
			material = new Material(this.m_Shader);
			if (material.HasProperty("_MonoColor"))
			{
				material.SetColor("_MonoColor", color);
			}
		}
		else
		{
			material = (Singleton<AssetLoader>.instance.LoadRes(materialPath, typeof(Material), true, 0U).obj as Material);
		}
		foreach (GameObject gameObject in objList)
		{
			if (null != gameObject)
			{
				Animation componentInChildren = gameObject.GetComponentInChildren<Animation>();
				if (componentInChildren)
				{
					componentInChildren.Sample();
				}
				if (null != material)
				{
					GeAfterImageMnanger.GeSnapModelDesc geSnapModelDesc = new GeAfterImageMnanger.GeSnapModelDesc();
					SkinnedMeshRenderer[] componentsInChildren = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (null != componentsInChildren[j])
						{
							GeAfterImageMnanger.GeSnapBakeObjDesc geSnapBakeObjDesc = new GeAfterImageMnanger.GeSnapBakeObjDesc();
							Mesh mesh = new Mesh();
							mesh.name = "snapped";
							componentsInChildren[j].BakeMesh(mesh);
							geSnapBakeObjDesc.m_BakedMaterials = new Material[mesh.subMeshCount];
							GameObject gameObject2 = new GameObject("SnapShot");
							gameObject2.hideFlags = 61;
							MeshFilter meshFilter = gameObject2.AddComponent<MeshFilter>();
							meshFilter.mesh = mesh;
							MeshRenderer meshRenderer = gameObject2.AddComponent<MeshRenderer>();
							if (geSnapBakeObjDesc.m_BakedMaterials.Length > 0)
							{
								int k = 0;
								int num = geSnapBakeObjDesc.m_BakedMaterials.Length;
								while (k < num)
								{
									geSnapBakeObjDesc.m_BakedMaterials[k] = new Material(material);
									k++;
								}
								meshRenderer.materials = geSnapBakeObjDesc.m_BakedMaterials;
								meshRenderer.material = geSnapBakeObjDesc.m_BakedMaterials[0];
							}
							meshRenderer.shadowCastingMode = 0;
							meshRenderer.receiveShadows = false;
							gameObject2.transform.position = componentsInChildren[j].gameObject.transform.position;
							gameObject2.transform.rotation = componentsInChildren[j].gameObject.transform.rotation;
							gameObject2.transform.localScale = componentsInChildren[j].gameObject.transform.localScale;
							if (componentsInChildren[j].gameObject.transform.lossyScale.x < 0f)
							{
								if (material.HasProperty("_CullMode"))
								{
									material.SetFloat("_CullMode", 1f);
								}
							}
							else if (material.HasProperty("_CullMode"))
							{
								material.SetFloat("_CullMode", 2f);
							}
							geSnapBakeObjDesc.m_BakedObject = gameObject2;
							geSnapBakeObjDesc.m_Mesh = mesh;
							geSnapModelDesc.m_BakedObjDescList.Add(geSnapBakeObjDesc);
						}
						geSnapModelDesc.m_TimeLen = nTimeLen;
						geSnapModelDesc.m_OriginObj = gameObject;
					}
					this.m_SnapModelList.Add(geSnapModelDesc);
				}
			}
		}
	}

	// Token: 0x06008682 RID: 34434 RVA: 0x001786A9 File Offset: 0x00176AA9
	private bool _IsOverLife(GeAfterImageMnanger.GeSnapModelDesc curSanpMdlDesc)
	{
		return curSanpMdlDesc == null || curSanpMdlDesc.m_TimePos >= 1f;
	}

	// Token: 0x06008683 RID: 34435 RVA: 0x001786C4 File Offset: 0x00176AC4
	public void Update(int deltaTime, GameObject obj)
	{
		bool flag = false;
		for (int i = 0; i < this.m_SnapModelList.Count; i++)
		{
			GeAfterImageMnanger.GeSnapModelDesc geSnapModelDesc = this.m_SnapModelList[i];
			geSnapModelDesc.m_TimePos += (float)deltaTime / (float)geSnapModelDesc.m_TimeLen;
			if (this._IsOverLife(geSnapModelDesc))
			{
				flag = true;
			}
			int j = 0;
			int count = geSnapModelDesc.m_BakedObjDescList.Count;
			while (j < count)
			{
				Material[] bakedMaterials = geSnapModelDesc.m_BakedObjDescList[j].m_BakedMaterials;
				if (bakedMaterials != null)
				{
					int k = 0;
					int num = bakedMaterials.Length;
					while (k < num)
					{
						Material material = bakedMaterials[k];
						if (!(null == material))
						{
							if (material.HasProperty("_Factor"))
							{
								material.SetFloat("_Factor", geSnapModelDesc.m_TimePos);
							}
							if (material.HasProperty("_WorldRefPos"))
							{
								material.SetVector("_WorldRefPos", obj.transform.position);
							}
						}
						k++;
					}
				}
				j++;
			}
		}
		if (flag)
		{
			this._ClearOverLifeSnapModel();
		}
	}

	// Token: 0x06008684 RID: 34436 RVA: 0x001787F2 File Offset: 0x00176BF2
	private void _ClearOverLifeSnapModel()
	{
		this.m_SnapModelList.RemoveAll(delegate(GeAfterImageMnanger.GeSnapModelDesc f)
		{
			if (this._IsOverLife(f))
			{
				int i = 0;
				int count = f.m_BakedObjDescList.Count;
				while (i < count)
				{
					Object.Destroy(f.m_BakedObjDescList[i].m_BakedObject);
					Object.Destroy(f.m_BakedObjDescList[i].m_Mesh);
					Material[] bakedMaterials = f.m_BakedObjDescList[i].m_BakedMaterials;
					int j = 0;
					int num = bakedMaterials.Length;
					while (j < num)
					{
						Object.Destroy(bakedMaterials[j]);
						j++;
					}
					i++;
				}
				return true;
			}
			return false;
		});
	}

	// Token: 0x04004079 RID: 16505
	protected List<GeAfterImageMnanger.GeSnapModelDesc> m_SnapModelList = new List<GeAfterImageMnanger.GeSnapModelDesc>();

	// Token: 0x0400407A RID: 16506
	protected Shader m_Shader;

	// Token: 0x02000CC5 RID: 3269
	protected class GeSnapBakeObjDesc
	{
		// Token: 0x0400407C RID: 16508
		public GameObject m_BakedObject;

		// Token: 0x0400407D RID: 16509
		public Mesh m_Mesh;

		// Token: 0x0400407E RID: 16510
		public Material[] m_BakedMaterials;
	}

	// Token: 0x02000CC6 RID: 3270
	protected class GeSnapModelDesc
	{
		// Token: 0x0400407F RID: 16511
		public float m_TimePos;

		// Token: 0x04004080 RID: 16512
		public int m_TimeLen;

		// Token: 0x04004081 RID: 16513
		public GameObject m_OriginObj;

		// Token: 0x04004082 RID: 16514
		public List<GeAfterImageMnanger.GeSnapBakeObjDesc> m_BakedObjDescList = new List<GeAfterImageMnanger.GeSnapBakeObjDesc>();
	}
}
