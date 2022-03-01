using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

// Token: 0x02000CF3 RID: 3315
public class GeMeshDescProxy : MonoBehaviour
{
	// Token: 0x060087BF RID: 34751 RVA: 0x0017FF5C File Offset: 0x0017E35C
	private void Start()
	{
		this.m_Property__MainTex = Shader.PropertyToID("_MainTex");
		this.m_Property__BumpMap = Shader.PropertyToID("_BumpMap");
		this.m_Property__SpecMap = Shader.PropertyToID("_SpecMap");
		this.m_Property__Ramp = Shader.PropertyToID("_Ramp");
		this.m_Property__FresnelPow = Shader.PropertyToID("_FresnelPow");
		this.m_Property__FresnelOffset = Shader.PropertyToID("_FresnelOffset");
		this.m_Property__SpecularPow = Shader.PropertyToID("_SpecularPow");
		this.m_Property__ColorStrength = Shader.PropertyToID("_ColorStrength");
		this.m_Property__LightIntensity = Shader.PropertyToID("_LightIntensity");
		this.m_Property__AmbientColor = Shader.PropertyToID("_AmbientColor");
		this.m_Property__FresnelColor = Shader.PropertyToID("_FresnelColor");
		this.m_Property__DyeColor = Shader.PropertyToID("_DyeColor");
		this.m_Property__Albedo = Shader.PropertyToID("_Albedo");
		this.m_Property__Bump = Shader.PropertyToID("_Bump");
		this.m_Property__Param = Shader.PropertyToID("_Param");
		this.m_Property__ReflectionIntensity = Shader.PropertyToID("_ReflectionIntensity");
		this.m_Property__AmbientIntensity = Shader.PropertyToID("_AmbientIntensity");
		this.m_Property__ElapsedTime = Shader.PropertyToID("_ElapsedTime");
		this.m_Property__AnimTimeLen = Shader.PropertyToID("_AnimTimeLen");
		this.m_Property__WorldRefPos = Shader.PropertyToID("_WorldRefPos");
	}

	// Token: 0x060087C0 RID: 34752 RVA: 0x001800A9 File Offset: 0x0017E4A9
	private void Deinit()
	{
	}

	// Token: 0x060087C1 RID: 34753 RVA: 0x001800AC File Offset: 0x0017E4AC
	public void Apply(string name, float fTimeLength, bool enableAnim = true)
	{
		if (null == this.m_Renderer)
		{
			return;
		}
		GeMeshDescProxy.GeAnimatSurfDesc geAnimatSurfDesc = null;
		int i = 0;
		int count = this.m_AnimatSurfList.Count;
		while (i < count)
		{
			GeMeshDescProxy.GeAnimatSurfDesc geAnimatSurfDesc2 = this.m_AnimatSurfList[i];
			if (geAnimatSurfDesc2 != null && geAnimatSurfDesc2.m_Name == name)
			{
				geAnimatSurfDesc = geAnimatSurfDesc2;
				break;
			}
			i++;
		}
		if (geAnimatSurfDesc == null)
		{
			string animatKey = string.Empty;
			if (!string.IsNullOrEmpty(this.m_Surface_AnimatRes))
			{
				animatKey = string.Format("{0}:{1}:{2}", Path.GetFileNameWithoutExtension(this.m_Surface_AnimatRes), name, !this.m_Surface_IsOpaque);
			}
			else
			{
				animatKey = string.Format("{0}:{1}:{2}", Path.GetFileNameWithoutExtension("Animat/CommonBuffEffect"), name, !this.m_Surface_IsOpaque);
			}
			geAnimatSurfDesc = new GeMeshDescProxy.GeAnimatSurfDesc(name, animatKey);
			geAnimatSurfDesc.m_Material = new Material[this.m_OriginMaterial.Length];
			int j = 0;
			int num = this.m_OriginMaterial.Length;
			while (j < num)
			{
				Material material = null;
				if (!string.IsNullOrEmpty(this.m_Surface_AnimatRes))
				{
					material = Singleton<GeAnimatInstPool>.instance.CreateMaterialInstance(animatKey, this.m_Surface_AnimatRes, name, !this.m_Surface_IsOpaque);
				}
				if (null == material)
				{
					material = Singleton<GeAnimatInstPool>.instance.CreateMaterialInstance(animatKey, "Animat/CommonBuffEffect", name, !this.m_Surface_IsOpaque);
				}
				if (null != material)
				{
					geAnimatSurfDesc.m_Material[j] = material;
					Material material2 = geAnimatSurfDesc.m_Material[j];
					Material material3 = this.m_OriginMaterial[j];
					string name2 = material2.shader.name;
					if (!(null == material3))
					{
						if (material3.HasProperty("_MainTex"))
						{
							material2.SetTexture("_MainTex", material3.GetTexture("_MainTex"));
						}
						if (material3.HasProperty("_BumpMap"))
						{
							material2.SetTexture("_BumpMap", material3.GetTexture("_BumpMap"));
						}
						if (material2.HasProperty("_SpecMap"))
						{
							if (material3.HasProperty("_SpecMap"))
							{
								material2.SetTexture("_SpecMap", material3.GetTexture("_SpecMap"));
							}
							else
							{
								Texture texture = Singleton<AssetLoader>.instance.LoadRes("Shader/HeroGo/Res/black.tga", typeof(Texture2D), true, 0U).obj as Texture2D;
								material2.SetTexture("_SpecMap", texture);
							}
						}
						if (material2.HasProperty("_Ramp"))
						{
							Texture texture2 = null;
							if (material3.HasProperty("_Ramp"))
							{
								texture2 = material3.GetTexture("_Ramp");
							}
							if (null == texture2)
							{
								texture2 = (Singleton<AssetLoader>.instance.LoadRes("Actor/Monster_Kelahe/Monster_Kelahe_bingshuangklh/Textures/T_Monster_Kelahe_bingshuangklh_ra.png", typeof(Texture2D), true, 0U).obj as Texture2D);
							}
							material2.SetTexture("_Ramp", texture2);
						}
						if (material3.HasProperty("_FresnelPow"))
						{
							material2.SetFloat("_FresnelPow", material3.GetFloat("_FresnelPow"));
						}
						if (material3.HasProperty("_FresnelOffset"))
						{
							material2.SetFloat("_FresnelOffset", material3.GetFloat("_FresnelOffset"));
						}
						if (material3.HasProperty("_SpecularPow"))
						{
							material2.SetFloat("_SpecularPow", material3.GetFloat("_SpecularPow"));
						}
						if (material3.HasProperty("_ColorStrength"))
						{
							material2.SetFloat("_ColorStrength", material3.GetFloat("_ColorStrength"));
						}
						if (material3.HasProperty("_LightIntensity"))
						{
							material2.SetFloat("_LightIntensity", material3.GetFloat("_LightIntensity"));
						}
						if (material3.HasProperty("_AmbientColor"))
						{
							material2.SetColor("_AmbientColor", material3.GetColor("_AmbientColor"));
						}
						if (material3.HasProperty("_FresnelColor"))
						{
							material2.SetColor("_FresnelColor", material3.GetColor("_FresnelColor"));
						}
						if (material3.HasProperty("_DyeColor") && material2.HasProperty("_DyeColor"))
						{
							material2.SetColor("_DyeColor", material3.GetColor("_DyeColor"));
						}
						if (name2.Contains("HeroGo/PBR/"))
						{
							if (material3.HasProperty("_Albedo"))
							{
								material2.SetTexture("_Albedo", material3.GetTexture("_Albedo"));
							}
							if (material3.HasProperty("_Bump"))
							{
								material2.SetTexture("_Bump", material3.GetTexture("_Bump"));
							}
							if (material3.HasProperty("_Param"))
							{
								material2.SetTexture("_Param", material3.GetTexture("_Param"));
							}
							if (material3.HasProperty("_LightIntensity"))
							{
								material2.SetFloat("_LightIntensity", material3.GetFloat("_LightIntensity"));
							}
							if (material3.HasProperty("_ReflectionIntensity"))
							{
								material2.SetFloat("_ReflectionIntensity", material3.GetFloat("_ReflectionIntensity"));
							}
							if (material3.HasProperty("_AmbientIntensity"))
							{
								material2.SetFloat("_AmbientIntensity", material3.GetFloat("_AmbientIntensity"));
							}
						}
						if (name2.Contains("HeroGo/Cel/"))
						{
							this._CopyKeyword("USE_EMISSION", material3, material2);
							this._CopyKeyword("USE_MatCap", material3, material2);
							this._CopyKeyword("USE_Reflection", material3, material2);
							this._CopyFloat("_NormalValue", material3, material2);
							this._CopyFloat("_Intensity", material3, material2);
							this._CopyFloat("_LightArea", material3, material2);
							this._CopyFloat("_SecondShadow", material3, material2);
							this._CopyFloat("_Shininess", material3, material2);
							this._CopyFloat("_SpecularMultiply", material3, material2);
							this._CopyFloat("_EmissionIntensity", material3, material2);
							this._CopyFloat("_Bias", material3, material2);
							this._CopyFloat("_TimeOnDuration", material3, material2);
							this._CopyFloat("_TimeOffDuration", material3, material2);
							this._CopyFloat("_BlinkingTimeOffsScale", material3, material2);
							this._CopyFloat("_NoiseAmount", material3, material2);
							this._CopyFloat("_RimPower", material3, material2);
							this._CopyFloat("_RimMultiply", material3, material2);
							this._CopyFloat("_MatCapFactor", material3, material2);
							this._CopyFloat("_MatSpecFactor", material3, material2);
							this._CopyFloat("_ReflectionIntensity", material3, material2);
							this._CopyFloat("_ReflectionStrength", material3, material2);
							this._CopyFloat("_DrawMode", material3, material2);
							this._CopyVector("_LightDirection", material3, material2);
							this._CopyColor("_MainColor", material3, material2);
							this._CopyColor("_FirstShadowMultColor", material3, material2);
							this._CopyColor("_SecondShadowMultColor", material3, material2);
							this._CopyColor("_LightSpecularColor", material3, material2);
							this._CopyColor("_EmissionColor", material3, material2);
							this._CopyColor("_LightRimColor", material3, material2);
							this._CopyColor("_MatCapColor", material3, material2);
							this._CopyColor("_MatCapSpecColor", material3, material2);
							this._CopyColor("_ReflectionColor", material3, material2);
							this._CopyTexture("_MainTex", material3, material2);
							this._CopyTexture("_LightMapTex", material3, material2);
							this._CopyTexture("_NormalTex", material3, material2);
							this._CopyTexture("_MatCap", material3, material2);
							this._CopyTexture("_MatCapSpec", material3, material2);
							this._CopyTexture("_ReflectionMap", material3, material2);
						}
						if (name2.Contains("HeroGo/Dissolution/"))
						{
							this._CopyColor("_MainColor", material3, material2);
							this._CopyColor("_SpecColor", material3, material2);
							this._CopyColor("_RimColor", material3, material2);
							this._CopyColor("_TwinkleColor", material3, material2);
							this._CopyTexture("_MainTextuer", material3, material2);
							this._CopyTexture("_SpeTextuer", material3, material2);
							this._CopyTexture("_NoiseTex", material3, material2);
							this._CopyTexture("_Normal", material3, material2);
							this._CopyFloat("_DiffuseIntensity", material3, material2);
							this._CopyFloat("_SpeIntensity", material3, material2);
							this._CopyFloat("_debrisSpeed", material3, material2);
							this._CopyFloat("_debrisSize", material3, material2);
							this._CopyFloat("_windSpeed", material3, material2);
							this._CopyFloat("_windPower", material3, material2);
							this._CopyFloat("_windFrequency", material3, material2);
							this._CopyFloat("_rimLight", material3, material2);
							this._CopyFloat("_RimExp", material3, material2);
							this._CopyFloat("_RimIntensity", material3, material2);
							this._CopyFloat("_Twinkle", material3, material2);
							this._CopyFloat("_TwinkleSpeed", material3, material2);
							this._CopyFloat("_Cutoff", material3, material2);
						}
						if (name2.Contains("HeroGo/Hair/"))
						{
							this._CopyColor("_BrightColor", material3, material2);
							this._CopyFloat("_BrightColorOffset", material3, material2);
							this._CopyFloat("_BrightColorSharpen", material3, material2);
							this._CopyColor("_BrightEdge", material3, material2);
							this._CopyFloat("_BrightEdgeOffset", material3, material2);
							this._CopyFloat("_BrightEdgeSharpen", material3, material2);
							this._CopyColor("_DarkColor", material3, material2);
							this._CopyFloat("_DarkOffset", material3, material2);
							this._CopyFloat("_DarkSharpen", material3, material2);
							this._CopyColor("_DarkEdge", material3, material2);
							this._CopyFloat("_DarkEdgeOffset", material3, material2);
							this._CopyFloat("_DarkEdgeSharpen", material3, material2);
							this._CopyColor("_Color", material3, material2);
							this._CopyTexture("_Albedo", material3, material2);
							this._CopyTexture("_Bump", material3, material2);
							this._CopyTexture("_Param", material3, material2);
							this._CopyFloat("_Spe_Intensity", material3, material2);
						}
						if (name2.Contains("HeroGo/SimulatePBR/"))
						{
							this._CopyColor("_BrightColor", material3, material2);
							this._CopyFloat("_BrightColorOffset", material3, material2);
							this._CopyFloat("_BrightColorSharpen", material3, material2);
							this._CopyColor("_BrightEdge", material3, material2);
							this._CopyFloat("_BrightEdgeOffset", material3, material2);
							this._CopyFloat("_BrightEdgeSharpen", material3, material2);
							this._CopyColor("_DarkColor", material3, material2);
							this._CopyFloat("_DarkOffset", material3, material2);
							this._CopyFloat("_DarkSharpen", material3, material2);
							this._CopyColor("_DarkEdge", material3, material2);
							this._CopyFloat("_DarkEdgeOffset", material3, material2);
							this._CopyFloat("_DarkEdgeSharpen", material3, material2);
							this._CopyFloat("_DirectionGradualColor", material3, material2);
							this._CopyColor("_Color", material3, material2);
							this._CopyTexture("_Albedo", material3, material2);
							this._CopyTexture("_Bump", material3, material2);
							this._CopyTexture("_Param", material3, material2);
							this._CopyTexture("_Emission", material3, material2);
							this._CopyTexture("_Noise", material3, material2);
							this._CopyFloat("_GradualLocation", material3, material2);
							this._CopyFloat("_Glittering", material3, material2);
							this._CopyFloat("_EmissionIntensity", material3, material2);
							this._CopyTexture("_LitSphere", material3, material2);
						}
						if (name2.Contains("HeroGo/ShadowPBR/"))
						{
							this._CopyTexture("_Albedo", material3, material2);
							this._CopyTexture("_Bump", material3, material2);
							this._CopyTexture("_Param", material3, material2);
							this._CopyTexture("_LitSphere", material3, material2);
							this._CopyVector("_LightDir", material3, material2);
							this._CopyFloat("_LightStrength", material3, material2);
							this._CopyColor("_ShadowCol", material3, material2);
							this._CopyColor("_MainCol", material3, material2);
							this._CopyFloat("_Metal", material3, material2);
							this._CopyFloat("_Rough", material3, material2);
							this._CopyColor("_SpeCol", material3, material2);
							this._CopyFloat("_SpeStrength", material3, material2);
							this._CopyFloat("_SpeCloth", material3, material2);
							this._CopyFloat("_FresnelOffset", material3, material2);
							this._CopyColor("_FresnelCol", material3, material2);
							this._CopyFloat("_SkinStrength", material3, material2);
							this._CopyFloat("_SpeSkin", material3, material2);
							this._CopyFloat("_EnvStrength", material3, material2);
							this._CopyFloat("_EnvOffset", material3, material2);
							this._CopyColor("_GlowCol", material3, material2);
							this._CopyFloat("_GlowStrength", material3, material2);
							this._CopyFloat("_TimeOnDuration", material3, material2);
							this._CopyFloat("_TimeOffDuration", material3, material2);
							this._CopyFloat("_BlinkingTimeOffsScale", material3, material2);
							this._CopyFloat("_NoiseAmount", material3, material2);
							this._CopyFloat("_ColEffect", material3, material2);
							this._CopyKeyword("_SSS", material3, material2);
							this._CopyKeyword("_Env", material3, material2);
							this._CopyKeyword("_ColChange", material3, material2);
							this._CopyKeyword("_Glow", material3, material2);
							this._CopyKeyword("_Blinking", material3, material2);
						}
						if (name2.Contains("HeroGo/ElectricHair/"))
						{
							this._CopyTexture("_Albedo", material3, material2);
							this._CopyColor("_MainColor", material3, material2);
							this._CopyFloat("_Intensity", material3, material2);
							this._CopyFloat("_ScrollX", material3, material2);
							this._CopyFloat("_ScrollY", material3, material2);
							this._CopyTexture("_DetailTex", material3, material2);
							this._CopyColor("_DetailColor", material3, material2);
							this._CopyFloat("_DetailInt", material3, material2);
							this._CopyFloat("_Scroll2X", material3, material2);
							this._CopyFloat("_Scroll2Y", material3, material2);
							this._CopyFloat("_Distort", material3, material2);
							this._CopyKeyword("_DetailLayer", material3, material2);
						}
					}
				}
				j++;
			}
			this.m_AnimatSurfList.Add(geAnimatSurfDesc);
		}
		if (geAnimatSurfDesc != null)
		{
			int k = 0;
			int num2 = geAnimatSurfDesc.m_Material.Length;
			while (k < num2)
			{
				Material material4 = geAnimatSurfDesc.m_Material[k];
				if (!(null == material4))
				{
					if (!enableAnim)
					{
						if (material4.HasProperty(this.m_Property__ElapsedTime))
						{
							material4.SetFloat(this.m_Property__ElapsedTime, 360000f);
						}
					}
					else if (material4.HasProperty(this.m_Property__AnimTimeLen) && fTimeLength > 0f)
					{
						material4.SetFloat(this.m_Property__AnimTimeLen, fTimeLength);
					}
				}
				k++;
			}
			this.m_Renderer.materials = geAnimatSurfDesc.m_Material;
			this.m_CurAnimatSurfDesc = geAnimatSurfDesc;
		}
	}

	// Token: 0x060087C2 RID: 34754 RVA: 0x00180F7E File Offset: 0x0017F37E
	public void Recover()
	{
		if (null == this.m_Renderer)
		{
			return;
		}
		if (this.m_OriginMaterial == null)
		{
			return;
		}
		this.m_Renderer.materials = this.m_OriginMaterial;
	}

	// Token: 0x060087C3 RID: 34755 RVA: 0x00180FAF File Offset: 0x0017F3AF
	public void DoUpdate(GeSurfParamDesc param)
	{
		this._UpdateInternal(param);
	}

	// Token: 0x060087C4 RID: 34756 RVA: 0x00180FB8 File Offset: 0x0017F3B8
	protected void _UpdateInternal(GeSurfParamDesc param)
	{
		if (this.m_CurAnimatSurfDesc != null)
		{
			for (int i = 0; i < this.m_CurAnimatSurfDesc.m_Material.Length; i++)
			{
				Material material = this.m_CurAnimatSurfDesc.m_Material[i];
				if (!(null == material))
				{
					if (material.HasProperty("_ElapsedTime"))
					{
						material.SetFloat("_ElapsedTime", param.m_ElapsedTime);
					}
					if (material.HasProperty("_WorldRefPos"))
					{
						material.SetVector("_WorldRefPos", param.m_WorldPos);
					}
				}
			}
		}
	}

	// Token: 0x060087C5 RID: 34757 RVA: 0x00181058 File Offset: 0x0017F458
	protected void _ReinitBase()
	{
		if (null != base.gameObject)
		{
			this.m_Renderer = base.gameObject.GetComponent<Renderer>();
			if (null != this.m_Renderer)
			{
				if (this.m_Renderer == null)
				{
					return;
				}
				this.m_OriginMaterial = this.m_Renderer.materials;
			}
		}
	}

	// Token: 0x060087C6 RID: 34758 RVA: 0x001810BC File Offset: 0x0017F4BC
	protected void _Clear()
	{
		int i = 0;
		int count = this.m_AnimatSurfList.Count;
		while (i < count)
		{
			GeMeshDescProxy.GeAnimatSurfDesc geAnimatSurfDesc = this.m_AnimatSurfList[i];
			if (geAnimatSurfDesc != null)
			{
				if (geAnimatSurfDesc.m_Material != null)
				{
					int j = 0;
					int num = geAnimatSurfDesc.m_Material.Length;
					while (j < num)
					{
						Singleton<GeAnimatInstPool>.instance.RecycleMaterialInstance(geAnimatSurfDesc.m_AnimatKey, geAnimatSurfDesc.m_Material[j]);
						j++;
					}
				}
			}
			i++;
		}
		this.m_AnimatSurfList.Clear();
		this.m_CurAnimatSurfDesc = null;
		this.Recover();
	}

	// Token: 0x060087C7 RID: 34759 RVA: 0x00181158 File Offset: 0x0017F558
	protected GeMeshDescProxy.GeAnimatSurfDesc _GetAnimatSurfDesc(string name)
	{
		for (int i = 0; i < this.m_AnimatSurfList.Count; i++)
		{
			if (this.m_AnimatSurfList[i].m_Name.CompareTo(name) == 0)
			{
				return this.m_AnimatSurfList[i];
			}
		}
		return null;
	}

	// Token: 0x060087C8 RID: 34760 RVA: 0x001811AB File Offset: 0x0017F5AB
	protected void _CopyTexture(string property, Material src, Material dst)
	{
		if (src.HasProperty(property))
		{
			dst.SetTexture(property, src.GetTexture(property));
		}
	}

	// Token: 0x060087C9 RID: 34761 RVA: 0x001811C7 File Offset: 0x0017F5C7
	protected void _CopyVector(string property, Material src, Material dst)
	{
		if (src.HasProperty(property))
		{
			dst.SetVector(property, src.GetVector(property));
		}
	}

	// Token: 0x060087CA RID: 34762 RVA: 0x001811E3 File Offset: 0x0017F5E3
	protected void _CopyFloat(string property, Material src, Material dst)
	{
		if (src.HasProperty(property))
		{
			dst.SetFloat(property, src.GetFloat(property));
		}
	}

	// Token: 0x060087CB RID: 34763 RVA: 0x001811FF File Offset: 0x0017F5FF
	protected void _CopyInt(string property, Material src, Material dst)
	{
		if (src.HasProperty(property))
		{
			dst.SetInt(property, src.GetInt(property));
		}
	}

	// Token: 0x060087CC RID: 34764 RVA: 0x0018121B File Offset: 0x0017F61B
	protected void _CopyKeyword(string keyword, Material src, Material dst)
	{
		if (src.IsKeywordEnabled(keyword))
		{
			dst.EnableKeyword(keyword);
		}
		else
		{
			dst.DisableKeyword(keyword);
		}
	}

	// Token: 0x060087CD RID: 34765 RVA: 0x0018123C File Offset: 0x0017F63C
	protected void _CopyColor(string property, Material src, Material dst)
	{
		if (src.HasProperty(property))
		{
			dst.SetColor(property, src.GetColor(property));
		}
	}

	// Token: 0x060087CE RID: 34766 RVA: 0x00181258 File Offset: 0x0017F658
	protected void OnEnable()
	{
		if (null == this.m_Renderer)
		{
			this._ReinitBase();
		}
	}

	// Token: 0x060087CF RID: 34767 RVA: 0x00181271 File Offset: 0x0017F671
	protected void OnDisable()
	{
	}

	// Token: 0x060087D0 RID: 34768 RVA: 0x00181273 File Offset: 0x0017F673
	public void OnDestroy()
	{
		this.Recover();
		this._Clear();
	}

	// Token: 0x060087D1 RID: 34769 RVA: 0x00181281 File Offset: 0x0017F681
	public void RebakeAnimat()
	{
		this._Clear();
		this._ReinitBase();
	}

	// Token: 0x04004178 RID: 16760
	protected Material[] m_OriginMaterial;

	// Token: 0x04004179 RID: 16761
	protected Renderer m_Renderer;

	// Token: 0x0400417A RID: 16762
	protected List<GeMeshDescProxy.GeAnimatSurfDesc> m_AnimatSurfList = new List<GeMeshDescProxy.GeAnimatSurfDesc>();

	// Token: 0x0400417B RID: 16763
	protected GeMeshDescProxy.GeAnimatSurfDesc m_CurAnimatSurfDesc;

	// Token: 0x0400417C RID: 16764
	[SerializeField]
	public bool m_Surface_IsOpaque = true;

	// Token: 0x0400417D RID: 16765
	[SerializeField]
	public string m_Surface_AnimatRes;

	// Token: 0x0400417E RID: 16766
	private int m_Property__MainTex = -1;

	// Token: 0x0400417F RID: 16767
	private int m_Property__BumpMap = -1;

	// Token: 0x04004180 RID: 16768
	private int m_Property__SpecMap = -1;

	// Token: 0x04004181 RID: 16769
	private int m_Property__Ramp = -1;

	// Token: 0x04004182 RID: 16770
	private int m_Property__FresnelPow = -1;

	// Token: 0x04004183 RID: 16771
	private int m_Property__FresnelOffset = -1;

	// Token: 0x04004184 RID: 16772
	private int m_Property__SpecularPow = -1;

	// Token: 0x04004185 RID: 16773
	private int m_Property__ColorStrength = -1;

	// Token: 0x04004186 RID: 16774
	private int m_Property__LightIntensity = -1;

	// Token: 0x04004187 RID: 16775
	private int m_Property__AmbientColor = -1;

	// Token: 0x04004188 RID: 16776
	private int m_Property__FresnelColor = -1;

	// Token: 0x04004189 RID: 16777
	private int m_Property__DyeColor = -1;

	// Token: 0x0400418A RID: 16778
	private int m_Property__Albedo = -1;

	// Token: 0x0400418B RID: 16779
	private int m_Property__Bump = -1;

	// Token: 0x0400418C RID: 16780
	private int m_Property__Param = -1;

	// Token: 0x0400418D RID: 16781
	private int m_Property__ReflectionIntensity = -1;

	// Token: 0x0400418E RID: 16782
	private int m_Property__AmbientIntensity = -1;

	// Token: 0x0400418F RID: 16783
	private int m_Property__ElapsedTime = -1;

	// Token: 0x04004190 RID: 16784
	private int m_Property__AnimTimeLen = -1;

	// Token: 0x04004191 RID: 16785
	private int m_Property__WorldRefPos = -1;

	// Token: 0x02000CF4 RID: 3316
	protected class GeAnimatSurfDesc
	{
		// Token: 0x060087D2 RID: 34770 RVA: 0x0018128F File Offset: 0x0017F68F
		public GeAnimatSurfDesc(string name, string animatKey)
		{
			this.m_Name = name;
			this.m_AnimatKey = animatKey;
			this.m_Material = null;
		}

		// Token: 0x04004192 RID: 16786
		public string m_Name;

		// Token: 0x04004193 RID: 16787
		public string m_AnimatKey;

		// Token: 0x04004194 RID: 16788
		public Material[] m_Material;
	}
}
