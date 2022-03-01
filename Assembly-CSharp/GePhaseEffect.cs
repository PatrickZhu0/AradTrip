using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02000D2D RID: 3373
public class GePhaseEffect : Singleton<GePhaseEffect>
{
	// Token: 0x060089D8 RID: 35288 RVA: 0x001904F8 File Offset: 0x0018E8F8
	public override void Init()
	{
		this.UnInit();
		if (null == this.m_PhaseEffectRoot)
		{
			this.m_PhaseEffectRoot = new GameObject("PhaseEffectRoot");
			Object.DontDestroyOnLoad(this.m_PhaseEffectRoot);
		}
		AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes("Animat/PhaseEffData.asset", true, 0U);
		DPhaseEffectData dphaseEffectData = assetInst.obj as DPhaseEffectData;
		if (null != dphaseEffectData)
		{
			for (int i = 0; i < dphaseEffectData.phaseMatChunk.Length; i++)
			{
				DPhaseEffChunk dphaseEffChunk = dphaseEffectData.phaseMatChunk[i];
				if (!string.IsNullOrEmpty(dphaseEffChunk.shaderName))
				{
					Shader shader = AssetShaderLoader.Find(dphaseEffChunk.shaderName);
					if (null != shader)
					{
						GePhaseEffect.GePhaseEffDesc gePhaseEffDesc = new GePhaseEffect.GePhaseEffDesc();
						gePhaseEffDesc.m_Name = dphaseEffChunk.name;
						gePhaseEffDesc.m_Shader = shader;
						if (dphaseEffChunk.phaseStageChunk != null)
						{
							for (int j = 0; j < dphaseEffChunk.phaseStageChunk.Length; j++)
							{
								DPhaseStageParamChunk dphaseStageParamChunk = dphaseEffChunk.phaseStageChunk[j];
								Material material = new Material(shader);
								for (int k = 0; k < dphaseStageParamChunk.paramDesc.Length; k++)
								{
									switch (dphaseStageParamChunk.paramDesc[k].paramType)
									{
									case AnimatParamType.Color:
										material.SetColor(dphaseStageParamChunk.paramDesc[k].paramName, dphaseStageParamChunk.paramDesc[k].paramData._color);
										break;
									case AnimatParamType.Vector:
										material.SetVector(dphaseStageParamChunk.paramDesc[k].paramName, dphaseStageParamChunk.paramDesc[k].paramData._vec4);
										break;
									case AnimatParamType.Float:
										material.SetFloat(dphaseStageParamChunk.paramDesc[k].paramName, dphaseStageParamChunk.paramDesc[k].paramData._float);
										break;
									case AnimatParamType.Range:
										material.SetFloat(dphaseStageParamChunk.paramDesc[k].paramName, dphaseStageParamChunk.paramDesc[k].paramData._float);
										break;
									case AnimatParamType.TexEnv:
									{
										Texture texture = Singleton<AssetLoader>.instance.LoadRes(dphaseStageParamChunk.paramDesc[k].paramObj._texAsset.m_AssetPath, true, 0U).obj as Texture;
										material.SetTexture(dphaseStageParamChunk.paramDesc[k].paramName, texture);
										break;
									}
									}
								}
								List<GameObject> list = ListPool<GameObject>.Get();
								int l = 0;
								int num = dphaseStageParamChunk.effectDesc.Length;
								while (l < num)
								{
									GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(dphaseStageParamChunk.effectDesc[l].effectResPath, true, 0U);
									if (null != gameObject)
									{
										ParticleSystem componentInChildren = gameObject.GetComponentInChildren<ParticleSystem>();
										if (componentInChildren)
										{
											componentInChildren.startColor = dphaseStageParamChunk.effectDesc[l].effectColor;
										}
										MeshRenderer componentInChildren2 = gameObject.GetComponentInChildren<MeshRenderer>();
										if (componentInChildren2)
										{
											componentInChildren2.material.SetColor("_TintColor", dphaseStageParamChunk.effectDesc[l].effectColor);
											componentInChildren2.material.color = dphaseStageParamChunk.effectDesc[l].effectColor;
										}
										gameObject.SetActive(false);
										list.Add(gameObject);
										gameObject.transform.SetParent(this.m_PhaseEffectRoot.transform);
									}
									l++;
								}
								gePhaseEffDesc.m_StageDescList.Add(new GePhaseStageDesc(material, list.ToArray(), dphaseStageParamChunk.needGlow, dphaseStageParamChunk.glowColor));
								ListPool<GameObject>.Release(list);
							}
							this.m_PhaseMatTable.Add(dphaseEffChunk.name, gePhaseEffDesc);
						}
					}
				}
			}
		}
	}

	// Token: 0x060089D9 RID: 35289 RVA: 0x001908F4 File Offset: 0x0018ECF4
	public override void UnInit()
	{
		foreach (KeyValuePair<string, GePhaseEffect.GePhaseEffDesc> keyValuePair in this.m_PhaseMatTable)
		{
			GePhaseEffect.GePhaseEffDesc value = keyValuePair.Value;
			value.m_StageDescList.RemoveAll(delegate(GePhaseStageDesc m)
			{
				if (m != null)
				{
					Object.Destroy(m.m_Material);
					int i = 0;
					int num = m.m_Effectes.Length;
					while (i < num)
					{
						if (null != m.m_Effectes[i])
						{
							Object.Destroy(m.m_Effectes[i]);
						}
						i++;
					}
				}
				return true;
			});
			value.m_Name = null;
			value.m_Shader = null;
		}
		this.m_PhaseMatTable.Clear();
		Object.Destroy(this.m_PhaseEffectRoot);
		this.m_PhaseEffectRoot = null;
	}

	// Token: 0x060089DA RID: 35290 RVA: 0x00190984 File Offset: 0x0018ED84
	public GePhaseStageDesc CreatePhaseEffect(string phaseMatName, int stageIdx)
	{
		GePhaseEffect.GePhaseEffDesc gePhaseEffDesc = null;
		if (!this.m_PhaseMatTable.TryGetValue(phaseMatName, out gePhaseEffDesc))
		{
			return null;
		}
		if (stageIdx < gePhaseEffDesc.m_StageDescList.Count)
		{
			return gePhaseEffDesc.m_StageDescList[stageIdx];
		}
		if (gePhaseEffDesc.m_StageDescList.Count > 0)
		{
			return gePhaseEffDesc.m_StageDescList[gePhaseEffDesc.m_StageDescList.Count - 1];
		}
		return null;
	}

	// Token: 0x0400434C RID: 17228
	private Dictionary<string, GePhaseEffect.GePhaseEffDesc> m_PhaseMatTable = new Dictionary<string, GePhaseEffect.GePhaseEffDesc>();

	// Token: 0x0400434D RID: 17229
	private GameObject m_PhaseEffectRoot;

	// Token: 0x02000D2E RID: 3374
	private class GePhaseEffDesc
	{
		// Token: 0x0400434F RID: 17231
		public string m_Name = string.Empty;

		// Token: 0x04004350 RID: 17232
		public Shader m_Shader;

		// Token: 0x04004351 RID: 17233
		public List<GePhaseStageDesc> m_StageDescList = new List<GePhaseStageDesc>();
	}
}
