using System;
using System.Collections.Generic;
using GamePool;
using UnityEngine;

// Token: 0x02000D26 RID: 3366
public class GeAnimat
{
	// Token: 0x0600899B RID: 35227 RVA: 0x0018D980 File Offset: 0x0018BD80
	public void Init(string AnimatName, string shaderName, DAnimatParamDesc[] animatParam, GameObject[] obj)
	{
		this.Clear(false);
		this.m_AnimatName = AnimatName;
		if (!string.IsNullOrEmpty(shaderName))
		{
			this.m_AnimatShader = AssetShaderLoader.Find(shaderName);
			this.m_AnimatMaterial = new Material(this.m_AnimatShader);
			for (int i = 0; i < animatParam.Length; i++)
			{
				switch (animatParam[i].paramType)
				{
				case AnimatParamType.Color:
					this.m_AnimatMaterial.SetColor(animatParam[i].paramName, animatParam[i].paramData._color);
					break;
				case AnimatParamType.Vector:
					this.m_AnimatMaterial.SetVector(animatParam[i].paramName, animatParam[i].paramData._vec4);
					break;
				case AnimatParamType.Float:
					this.m_AnimatMaterial.SetFloat(animatParam[i].paramName, animatParam[i].paramData._float);
					break;
				case AnimatParamType.Range:
					this.m_AnimatMaterial.SetFloat(animatParam[i].paramName, animatParam[i].paramData._float);
					break;
				case AnimatParamType.TexEnv:
				{
					Texture texture = Singleton<AssetLoader>.instance.LoadRes(animatParam[i].paramObj._texAsset.m_AssetPath, true, 0U).obj as Texture;
					this.m_AnimatMaterial.SetTexture(animatParam[i].paramName, texture);
					break;
				}
				}
			}
		}
		this.AppendObject(obj);
	}

	// Token: 0x0600899C RID: 35228 RVA: 0x0018DB0C File Offset: 0x0018BF0C
	public void AppendObject(GameObject[] obj)
	{
		if (null == this.m_AnimatMaterial)
		{
			Logger.LogErrorFormat("Animat \"{0}\" does not specify shader!", new object[]
			{
				this.m_AnimatName
			});
			return;
		}
		if (obj == null)
		{
			return;
		}
		for (int i = 0; i < obj.Length; i++)
		{
			if (!(null == obj[i]))
			{
				if (!obj[i].CompareTag("EffectModel"))
				{
					Renderer[] array = obj[i].GetComponentsInChildren<Renderer>();
					List<Renderer> list = ListPool<Renderer>.Get();
					int j = 0;
					int num = array.Length;
					while (j < num)
					{
						if (!array[j].gameObject.CompareTag("EffectModel"))
						{
							list.Add(array[j]);
						}
						j++;
					}
					array = list.ToArray();
					ListPool<Renderer>.Release(list);
					GeAnimat.GeAnimatRendDesc[] array2 = new GeAnimat.GeAnimatRendDesc[array.Length];
					int k = 0;
					int num2 = array.Length;
					while (k < num2)
					{
						Renderer renderer = array[k];
						if (renderer.GetType() == typeof(SkinnedMeshRenderer) || renderer.GetType() == typeof(MeshRenderer))
						{
							Material[] materials = renderer.materials;
							Material[] array3 = new Material[materials.Length];
							Material[] array4 = new Material[materials.Length];
							for (int l = 0; l < materials.Length; l++)
							{
								array3[l] = materials[l];
							}
							for (int m = 0; m < materials.Length; m++)
							{
								if (!(null == this.m_AnimatMaterial))
								{
									array4[m] = new Material(this.m_AnimatMaterial);
									array4[m].name = string.Format("{0}_{1}", renderer.name, this.m_AnimatName);
									if (materials[m].HasProperty("_MainTex"))
									{
										array4[m].SetTexture("_MainTex", materials[m].GetTexture("_MainTex"));
									}
									if (materials[m].HasProperty("_BumpMap"))
									{
										array4[m].SetTexture("_BumpMap", materials[m].GetTexture("_BumpMap"));
									}
									if (array4[m].HasProperty("_SpecMap"))
									{
										if (materials[m].HasProperty("_SpecMap"))
										{
											array4[m].SetTexture("_SpecMap", materials[m].GetTexture("_SpecMap"));
										}
										else
										{
											Texture texture = Singleton<AssetLoader>.instance.LoadRes("Shader/HeroGo/Res/black.tga", typeof(Texture2D), true, 0U).obj as Texture2D;
											array4[m].SetTexture("_SpecMap", texture);
										}
									}
									if (array4[m].HasProperty("_Ramp"))
									{
										Texture texture2 = null;
										if (materials[m].HasProperty("_Ramp"))
										{
											texture2 = materials[m].GetTexture("_Ramp");
										}
										if (null == texture2)
										{
											texture2 = (Singleton<AssetLoader>.instance.LoadRes("Actor/Monster_Kelahe/Monster_Kelahe_bingshuangklh/Textures/T_Monster_Kelahe_bingshuangklh_ra.png", typeof(Texture2D), true, 0U).obj as Texture2D);
										}
										array4[m].SetTexture("_Ramp", texture2);
									}
									if (materials[m].HasProperty("_FresnelPow"))
									{
										array4[m].SetFloat("_FresnelPow", materials[m].GetFloat("_FresnelPow"));
									}
									if (materials[m].HasProperty("_FresnelOffset"))
									{
										array4[m].SetFloat("_FresnelOffset", materials[m].GetFloat("_FresnelOffset"));
									}
									if (materials[m].HasProperty("_SpecularPow"))
									{
										array4[m].SetFloat("_SpecularPow", materials[m].GetFloat("_SpecularPow"));
									}
									if (materials[m].HasProperty("_ColorStrength"))
									{
										array4[m].SetFloat("_ColorStrength", materials[m].GetFloat("_ColorStrength"));
									}
									if (materials[m].HasProperty("_LightIntensity"))
									{
										array4[m].SetFloat("_LightIntensity", materials[m].GetFloat("_LightIntensity"));
									}
									if (materials[m].HasProperty("_AmbientColor"))
									{
										array4[m].SetColor("_AmbientColor", materials[m].GetColor("_AmbientColor"));
									}
									if (materials[m].HasProperty("_FresnelColor"))
									{
										array4[m].SetColor("_FresnelColor", materials[m].GetColor("_FresnelColor"));
									}
									if (materials[m].HasProperty("_DyeColor") && array4[m].HasProperty("_DyeColor"))
									{
										array4[m].SetColor("_DyeColor", materials[m].GetColor("_DyeColor"));
									}
								}
							}
							array2[k].meshRenderer = renderer;
							array2[k].orginMatArray = array3;
							array2[k].animatMatArray = array4;
						}
						k++;
					}
					this.m_AnimatObjDescList.Add(new GeAnimat.GeAnimatObjDesc(obj[i], array2));
				}
			}
		}
	}

	// Token: 0x0600899D RID: 35229 RVA: 0x0018E034 File Offset: 0x0018C434
	public void RemoveObject(GameObject[] obj)
	{
		GeAnimat.<RemoveObject>c__AnonStorey0 <RemoveObject>c__AnonStorey = new GeAnimat.<RemoveObject>c__AnonStorey0();
		<RemoveObject>c__AnonStorey.obj = obj;
		int i;
		for (i = 0; i < <RemoveObject>c__AnonStorey.obj.Length; i++)
		{
			this.m_AnimatObjDescList.RemoveAll(delegate(GeAnimat.GeAnimatObjDesc f)
			{
				int i;
				if (f.obj == <RemoveObject>c__AnonStorey.obj[i])
				{
					for (i = 0; i < f.rendDescArray.Length; i++)
					{
						GeAnimat.GeAnimatRendDesc geAnimatRendDesc = f.rendDescArray[i];
						if (!(null == geAnimatRendDesc.meshRenderer))
						{
							Material[] materials = geAnimatRendDesc.meshRenderer.materials;
							if (materials != null)
							{
								for (int j = 0; j < materials.Length; j++)
								{
									materials[j] = geAnimatRendDesc.orginMatArray[j];
								}
								geAnimatRendDesc.meshRenderer.materials = materials;
							}
							for (int k = 0; k < geAnimatRendDesc.animatMatArray.Length; k++)
							{
								if (geAnimatRendDesc.animatMatArray[k].HasProperty("_MainTex"))
								{
									geAnimatRendDesc.animatMatArray[k].SetTexture("_MainTex", null);
								}
								if (geAnimatRendDesc.animatMatArray[k].HasProperty("_BumpMap"))
								{
									geAnimatRendDesc.animatMatArray[k].SetTexture("_BumpMap", null);
								}
								if (geAnimatRendDesc.animatMatArray[k].HasProperty("_SpecMap"))
								{
									geAnimatRendDesc.animatMatArray[k].SetTexture("_SpecMap", null);
								}
								if (geAnimatRendDesc.animatMatArray[k].HasProperty("_Ramp"))
								{
									geAnimatRendDesc.animatMatArray[k].SetTexture("_Ramp", null);
								}
								Object.Destroy(geAnimatRendDesc.animatMatArray[k]);
								geAnimatRendDesc.animatMatArray[k] = null;
							}
							geAnimatRendDesc.meshRenderer = null;
							geAnimatRendDesc.orginMatArray = null;
							geAnimatRendDesc.animatMatArray = null;
						}
					}
					f.rendDescArray = null;
					return true;
				}
				return false;
			});
		}
	}

	// Token: 0x0600899E RID: 35230 RVA: 0x0018E0A0 File Offset: 0x0018C4A0
	public void Apply(float timeLen, float timeOffset, bool enableAnim, bool recover)
	{
		this.m_EnableAnim = enableAnim;
		this.m_RecoverWhenEnd = recover;
		this.m_TimeLen = timeLen;
		if (!this.m_EnableAnim)
		{
			this.m_TimePos = this.m_TimeLen;
		}
		else
		{
			this.m_TimePos = timeOffset;
		}
		for (int i = 0; i < this.m_AnimatObjDescList.Count; i++)
		{
			for (int j = 0; j < this.m_AnimatObjDescList[i].rendDescArray.Length; j++)
			{
				GeAnimat.GeAnimatRendDesc geAnimatRendDesc = this.m_AnimatObjDescList[i].rendDescArray[j];
				if (!(null == geAnimatRendDesc.meshRenderer))
				{
					Material[] materials = geAnimatRendDesc.meshRenderer.materials;
					if (materials != null)
					{
						for (int k = 0; k < materials.Length; k++)
						{
							materials[k] = geAnimatRendDesc.animatMatArray[k];
							if (!enableAnim)
							{
								if (materials[k].HasProperty("_ElapsedTime"))
								{
									materials[k].SetFloat("_ElapsedTime", 360000f);
								}
							}
							else if (materials[k].HasProperty("_AnimTimeLen") && this.m_TimeLen > 0f)
							{
								materials[k].SetFloat("_AnimTimeLen", this.m_TimeLen);
							}
						}
						geAnimatRendDesc.meshRenderer.materials = materials;
					}
				}
			}
		}
		this.m_IsPlaying = true;
		this.m_IsEnd = false;
	}

	// Token: 0x0600899F RID: 35231 RVA: 0x0018E22C File Offset: 0x0018C62C
	public void Recover()
	{
		if (!this.m_RecoverWhenEnd)
		{
			return;
		}
		for (int i = 0; i < this.m_AnimatObjDescList.Count; i++)
		{
			for (int j = 0; j < this.m_AnimatObjDescList[i].rendDescArray.Length; j++)
			{
				GeAnimat.GeAnimatRendDesc geAnimatRendDesc = this.m_AnimatObjDescList[i].rendDescArray[j];
				if (!(null == geAnimatRendDesc.meshRenderer))
				{
					Material[] materials = geAnimatRendDesc.meshRenderer.materials;
					if (materials != null)
					{
						for (int k = 0; k < materials.Length; k++)
						{
							materials[k] = geAnimatRendDesc.orginMatArray[k];
						}
						geAnimatRendDesc.meshRenderer.materials = materials;
					}
				}
			}
		}
		this.m_IsPlaying = false;
		this.m_IsEnd = true;
	}

	// Token: 0x060089A0 RID: 35232 RVA: 0x0018E320 File Offset: 0x0018C720
	public void Update(bool timeOnly, float deltaTime, GameObject obj)
	{
		if (this.m_IsPlaying)
		{
			this.m_TimePos += deltaTime * 0.001f;
			if (timeOnly)
			{
				return;
			}
			if (this.m_TimeLen > 0f && this.m_TimePos > this.m_TimeLen)
			{
				this.Recover();
				this.m_IsPlaying = false;
				this.m_IsEnd = true;
				return;
			}
			for (int i = 0; i < this.m_AnimatObjDescList.Count; i++)
			{
				for (int j = 0; j < this.m_AnimatObjDescList[i].rendDescArray.Length; j++)
				{
					GeAnimat.GeAnimatRendDesc geAnimatRendDesc = this.m_AnimatObjDescList[i].rendDescArray[j];
					if (geAnimatRendDesc.animatMatArray != null)
					{
						for (int k = 0; k < geAnimatRendDesc.animatMatArray.Length; k++)
						{
							if (this.m_EnableAnim && this.m_AnimatMaterial.HasProperty("_ElapsedTime"))
							{
								geAnimatRendDesc.animatMatArray[k].SetFloat("_ElapsedTime", this.m_TimePos);
							}
							if (this.m_AnimatMaterial.HasProperty("_WorldRefPos"))
							{
								geAnimatRendDesc.animatMatArray[k].SetVector("_WorldRefPos", obj.transform.position);
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x060089A1 RID: 35233 RVA: 0x0018E48F File Offset: 0x0018C88F
	public void Pause()
	{
	}

	// Token: 0x060089A2 RID: 35234 RVA: 0x0018E491 File Offset: 0x0018C891
	public void Resume()
	{
	}

	// Token: 0x060089A3 RID: 35235 RVA: 0x0018E493 File Offset: 0x0018C893
	public void SetFinish()
	{
		this.m_IsEnd = true;
	}

	// Token: 0x060089A4 RID: 35236 RVA: 0x0018E49C File Offset: 0x0018C89C
	public void Clear(bool bNeedRecover = false)
	{
		if (bNeedRecover)
		{
			this.Recover();
		}
		for (int i = 0; i < this.m_AnimatObjDescList.Count; i++)
		{
			for (int j = 0; j < this.m_AnimatObjDescList[i].rendDescArray.Length; j++)
			{
				GeAnimat.GeAnimatRendDesc geAnimatRendDesc = this.m_AnimatObjDescList[i].rendDescArray[j];
				if (geAnimatRendDesc.animatMatArray != null)
				{
					for (int k = 0; k < geAnimatRendDesc.animatMatArray.Length; k++)
					{
						if (null != geAnimatRendDesc.animatMatArray[k])
						{
							if (geAnimatRendDesc.animatMatArray[k].HasProperty("_MainTex"))
							{
								geAnimatRendDesc.animatMatArray[k].SetTexture("_MainTex", null);
							}
							if (geAnimatRendDesc.animatMatArray[k].HasProperty("_BumpMap"))
							{
								geAnimatRendDesc.animatMatArray[k].SetTexture("_BumpMap", null);
							}
							if (geAnimatRendDesc.animatMatArray[k].HasProperty("_SpecMap"))
							{
								geAnimatRendDesc.animatMatArray[k].SetTexture("_SpecMap", null);
							}
							if (geAnimatRendDesc.animatMatArray[k].HasProperty("_Ramp"))
							{
								geAnimatRendDesc.animatMatArray[k].SetTexture("_Ramp", null);
							}
							Object.Destroy(geAnimatRendDesc.animatMatArray[k]);
							geAnimatRendDesc.animatMatArray[k] = null;
						}
					}
					geAnimatRendDesc.meshRenderer = null;
					geAnimatRendDesc.orginMatArray = null;
					geAnimatRendDesc.animatMatArray = null;
				}
			}
		}
		this.m_AnimatObjDescList.Clear();
		Object.Destroy(this.m_AnimatMaterial);
		this.m_AnimatMaterial = null;
		this.m_AnimatShader = null;
	}

	// Token: 0x060089A5 RID: 35237 RVA: 0x0018E66B File Offset: 0x0018CA6B
	public float GetElapsedTime()
	{
		return this.m_TimePos;
	}

	// Token: 0x060089A6 RID: 35238 RVA: 0x0018E673 File Offset: 0x0018CA73
	public float GetTimeLen()
	{
		return this.m_TimeLen;
	}

	// Token: 0x060089A7 RID: 35239 RVA: 0x0018E67B File Offset: 0x0018CA7B
	public bool IsAnimate()
	{
		return this.m_EnableAnim;
	}

	// Token: 0x060089A8 RID: 35240 RVA: 0x0018E683 File Offset: 0x0018CA83
	public bool IsFinished()
	{
		return this.m_IsEnd;
	}

	// Token: 0x060089A9 RID: 35241 RVA: 0x0018E68B File Offset: 0x0018CA8B
	public bool IsRecover()
	{
		return this.m_RecoverWhenEnd;
	}

	// Token: 0x04004310 RID: 17168
	protected List<GeAnimat.GeAnimatObjDesc> m_AnimatObjDescList = new List<GeAnimat.GeAnimatObjDesc>();

	// Token: 0x04004311 RID: 17169
	protected Shader m_AnimatShader;

	// Token: 0x04004312 RID: 17170
	protected Material m_AnimatMaterial;

	// Token: 0x04004313 RID: 17171
	protected string m_AnimatName;

	// Token: 0x04004314 RID: 17172
	protected float m_TimeLen;

	// Token: 0x04004315 RID: 17173
	protected float m_TimePos;

	// Token: 0x04004316 RID: 17174
	protected bool m_IsPlaying;

	// Token: 0x04004317 RID: 17175
	protected bool m_IsEnd;

	// Token: 0x04004318 RID: 17176
	protected bool m_EnableAnim = true;

	// Token: 0x04004319 RID: 17177
	protected bool m_RecoverWhenEnd;

	// Token: 0x02000D27 RID: 3367
	protected struct GeAnimatRendDesc
	{
		// Token: 0x060089AA RID: 35242 RVA: 0x0018E693 File Offset: 0x0018CA93
		public GeAnimatRendDesc(Renderer r, Material[] o, Material[] a)
		{
			this.meshRenderer = r;
			this.orginMatArray = o;
			this.animatMatArray = a;
		}

		// Token: 0x0400431A RID: 17178
		public Renderer meshRenderer;

		// Token: 0x0400431B RID: 17179
		public Material[] orginMatArray;

		// Token: 0x0400431C RID: 17180
		public Material[] animatMatArray;
	}

	// Token: 0x02000D28 RID: 3368
	protected struct GeAnimatObjDesc
	{
		// Token: 0x060089AB RID: 35243 RVA: 0x0018E6AA File Offset: 0x0018CAAA
		public GeAnimatObjDesc(GameObject o, GeAnimat.GeAnimatRendDesc[] a)
		{
			this.obj = o;
			this.rendDescArray = a;
		}

		// Token: 0x0400431D RID: 17181
		public GameObject obj;

		// Token: 0x0400431E RID: 17182
		public GeAnimat.GeAnimatRendDesc[] rendDescArray;
	}
}
