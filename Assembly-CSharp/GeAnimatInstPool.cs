using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000CCC RID: 3276
public class GeAnimatInstPool : Singleton<GeAnimatInstPool>, IObjectPool
{
	// Token: 0x060086A3 RID: 34467 RVA: 0x0017952C File Offset: 0x0017792C
	public string GetPoolName()
	{
		return this.poolName;
	}

	// Token: 0x060086A4 RID: 34468 RVA: 0x00179534 File Offset: 0x00177934
	public string GetPoolInfo()
	{
		return string.Format("{0}/{1}", this.remainInst, this.totalInst);
	}

	// Token: 0x060086A5 RID: 34469 RVA: 0x00179556 File Offset: 0x00177956
	public string GetPoolDetailInfo()
	{
		return "detailInfo";
	}

	// Token: 0x060086A6 RID: 34470 RVA: 0x0017955D File Offset: 0x0017795D
	public override void Init()
	{
		Singleton<CPoolManager>.GetInstance().RegisterPool(this.poolKey, this);
	}

	// Token: 0x060086A7 RID: 34471 RVA: 0x00179570 File Offset: 0x00177970
	public override void UnInit()
	{
	}

	// Token: 0x060086A8 RID: 34472 RVA: 0x00179574 File Offset: 0x00177974
	public Material CreateMaterialInstance(string animatKey, string animatRes, string name, bool transparent)
	{
		GeAnimatInstPool.GeMatTemplate geMatTemplate = null;
		if (this.m_pooledMatInstMap.TryGetValue(animatKey, out geMatTemplate))
		{
			int i = 0;
			int count = geMatTemplate.m_matInstLst.Count;
			while (i < count)
			{
				GeAnimatInstPool.GeMatInstDesc geMatInstDesc = geMatTemplate.m_matInstLst[i];
				if (geMatInstDesc != null)
				{
					if (!geMatInstDesc.m_Using)
					{
						geMatInstDesc.m_Using = true;
						this.remainInst--;
						return geMatInstDesc.m_matRes;
					}
				}
				i++;
			}
			if (null == geMatTemplate.m_matTemplate)
			{
				geMatTemplate.m_matTemplate = this._LoadAnimatMaterial(animatRes, name, transparent);
			}
			if (null != geMatTemplate.m_matTemplate)
			{
				GeAnimatInstPool.GeMatInstDesc geMatInstDesc2 = new GeAnimatInstPool.GeMatInstDesc();
				geMatInstDesc2.m_Using = true;
				geMatInstDesc2.m_matRes = new Material(geMatTemplate.m_matTemplate);
				geMatTemplate.m_matInstLst.Add(geMatInstDesc2);
				this.totalInst++;
				return geMatInstDesc2.m_matRes;
			}
			return null;
		}
		else
		{
			Material material = this._LoadAnimatMaterial(animatRes, name, transparent);
			if (null != material)
			{
				GeAnimatInstPool.GeMatInstDesc geMatInstDesc3 = new GeAnimatInstPool.GeMatInstDesc();
				geMatInstDesc3.m_Using = true;
				geMatInstDesc3.m_matRes = new Material(material);
				geMatTemplate = new GeAnimatInstPool.GeMatTemplate();
				geMatTemplate.m_matTemplate = material;
				geMatTemplate.m_matInstLst.Add(geMatInstDesc3);
				this.m_pooledMatInstMap.Add(animatKey, geMatTemplate);
				this.totalInst++;
				return geMatInstDesc3.m_matRes;
			}
			return null;
		}
	}

	// Token: 0x060086A9 RID: 34473 RVA: 0x001796E8 File Offset: 0x00177AE8
	public void RecycleMaterialInstance(string animatKey, Material matInst)
	{
		if (null == matInst)
		{
			return;
		}
		this.remainInst++;
		GeAnimatInstPool.GeMatTemplate geMatTemplate = null;
		if (this.m_pooledMatInstMap.TryGetValue(animatKey, out geMatTemplate))
		{
			int i = 0;
			int count = geMatTemplate.m_matInstLst.Count;
			while (i < count)
			{
				GeAnimatInstPool.GeMatInstDesc geMatInstDesc = geMatTemplate.m_matInstLst[i];
				if (geMatInstDesc != null)
				{
					if (geMatInstDesc.m_Using)
					{
						if (matInst == geMatInstDesc.m_matRes)
						{
							geMatInstDesc.m_Using = false;
							return;
						}
					}
				}
				i++;
			}
		}
	}

	// Token: 0x060086AA RID: 34474 RVA: 0x00179784 File Offset: 0x00177B84
	public void ClearAll()
	{
		foreach (KeyValuePair<string, GeAnimatInstPool.GeMatTemplate> keyValuePair in this.m_pooledMatInstMap)
		{
			GeAnimatInstPool.GeMatTemplate value = keyValuePair.Value;
			if (null != value.m_matTemplate)
			{
				Object.Destroy(value.m_matTemplate);
			}
			int i = 0;
			int count = value.m_matInstLst.Count;
			while (i < count)
			{
				GeAnimatInstPool.GeMatInstDesc geMatInstDesc = value.m_matInstLst[i];
				if (geMatInstDesc != null)
				{
					Object.Destroy(geMatInstDesc.m_matRes);
				}
				i++;
			}
		}
		this.m_pooledMatInstMap.Clear();
		this.totalInst = 0;
		this.remainInst = 0;
	}

	// Token: 0x060086AB RID: 34475 RVA: 0x0017983C File Offset: 0x00177C3C
	protected Material _LoadAnimatMaterial(string animatRes, string name, bool transparent)
	{
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(animatRes, true, 0U);
		if (assetInst != null)
		{
			DModelData dmodelData = assetInst.obj as DModelData;
			if (null != dmodelData && dmodelData.animatChunk != null)
			{
				int i = 0;
				int num = dmodelData.animatChunk.Length;
				while (i < num)
				{
					DAnimatChunk danimatChunk = dmodelData.animatChunk[i];
					if (name == danimatChunk.name && dmodelData.animatChunk[i].paramDesc != null)
					{
						DAnimatParamDesc[] paramDesc = dmodelData.animatChunk[i].paramDesc;
						string text = dmodelData.animatChunk[i].shaderName;
						Shader shader = null;
						if (transparent)
						{
							text += "_Alpha";
							shader = AssetShaderLoader.Find(text);
						}
						if (null == shader)
						{
							shader = AssetShaderLoader.Find(dmodelData.animatChunk[i].shaderName);
						}
						Material material = new Material(shader);
						for (int j = 0; j < paramDesc.Length; j++)
						{
							switch (paramDesc[j].paramType)
							{
							case AnimatParamType.Color:
								material.SetColor(paramDesc[j].paramName, paramDesc[j].paramData._color);
								break;
							case AnimatParamType.Vector:
								material.SetVector(paramDesc[j].paramName, paramDesc[j].paramData._vec4);
								break;
							case AnimatParamType.Float:
								material.SetFloat(paramDesc[j].paramName, paramDesc[j].paramData._float);
								break;
							case AnimatParamType.Range:
								material.SetFloat(paramDesc[j].paramName, paramDesc[j].paramData._float);
								break;
							case AnimatParamType.TexEnv:
							{
								Texture texture = Singleton<AssetLoader>.instance.LoadRes(paramDesc[j].paramObj._texAsset.m_AssetPath, true, 0U).obj as Texture;
								material.SetTexture(paramDesc[j].paramName, texture);
								break;
							}
							}
						}
						return material;
					}
					i++;
				}
			}
		}
		return null;
	}

	// Token: 0x04004097 RID: 16535
	private Dictionary<string, GeAnimatInstPool.GeMatTemplate> m_pooledMatInstMap = new Dictionary<string, GeAnimatInstPool.GeMatTemplate>();

	// Token: 0x04004098 RID: 16536
	private string poolKey = "GeAnimatInstPool";

	// Token: 0x04004099 RID: 16537
	private string poolName = "GeAnimatInst池";

	// Token: 0x0400409A RID: 16538
	private int totalInst;

	// Token: 0x0400409B RID: 16539
	private int remainInst;

	// Token: 0x02000CCD RID: 3277
	public class GeMatInstDesc
	{
		// Token: 0x0400409C RID: 16540
		public bool m_Using;

		// Token: 0x0400409D RID: 16541
		public Material m_matRes;
	}

	// Token: 0x02000CCE RID: 3278
	public class GeMatTemplate
	{
		// Token: 0x0400409E RID: 16542
		public Material m_matTemplate;

		// Token: 0x0400409F RID: 16543
		public List<GeAnimatInstPool.GeMatInstDesc> m_matInstLst = new List<GeAnimatInstPool.GeMatInstDesc>();
	}
}
