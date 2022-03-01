using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XUPorterJSON;

// Token: 0x020000CA RID: 202
public class AssetShaderLoader : Singleton<AssetShaderLoader>
{
	// Token: 0x06000443 RID: 1091 RVA: 0x0001E74C File Offset: 0x0001CB4C
	public override void Init()
	{
		TextAsset textAsset = Singleton<AssetLoader>.instance.LoadRes(this.m_ShaderListFile, typeof(TextAsset), true, 0U).obj as TextAsset;
		if (null != textAsset)
		{
			Hashtable hashtable = new Hashtable();
			try
			{
				hashtable = (MiniJSON.jsonDecode(textAsset.text) as Hashtable);
				IDictionaryEnumerator enumerator = hashtable.GetEnumerator();
				while (enumerator.MoveNext())
				{
					string key = enumerator.Key as string;
					string text = enumerator.Value as string;
					Shader shader = null;
					if (!this.m_ShaderNameMap.ContainsKey(key))
					{
						if (!string.IsNullOrEmpty(text))
						{
							shader = (Singleton<AssetLoader>.instance.LoadRes(text, typeof(Shader), true, 0U).obj as Shader);
						}
						this.m_ShaderNameMap.Add(key, new AssetShaderLoader.ShaderResDesc(text, shader));
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0001E850 File Offset: 0x0001CC50
	public static void WarmupAllShaders()
	{
		Shader.WarmupAllShaders();
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0001E857 File Offset: 0x0001CC57
	public override void UnInit()
	{
		this.m_ShaderNameMap.Clear();
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0001E864 File Offset: 0x0001CC64
	public static Shader Find(string shaderName)
	{
		AssetShaderLoader.ShaderResDesc shaderResDesc;
		if (Singleton<AssetShaderLoader>.instance.m_ShaderNameMap.TryGetValue(shaderName, out shaderResDesc))
		{
			if (null == shaderResDesc.m_Shader)
			{
				Shader shader = Singleton<AssetLoader>.instance.LoadRes(shaderResDesc.m_ShaderRes, typeof(Shader), true, 0U).obj as Shader;
				if (null != shader)
				{
					shaderResDesc.m_Shader = shader;
				}
			}
			return shaderResDesc.m_Shader;
		}
		return Shader.Find(shaderName);
	}

	// Token: 0x040003EB RID: 1003
	protected readonly string m_ShaderListFile = "Shader/ShaderList.json";

	// Token: 0x040003EC RID: 1004
	protected readonly ShaderVariantCollection m_ShaderVariantCollection = new ShaderVariantCollection();

	// Token: 0x040003ED RID: 1005
	protected Dictionary<string, AssetShaderLoader.ShaderResDesc> m_ShaderNameMap = new Dictionary<string, AssetShaderLoader.ShaderResDesc>();

	// Token: 0x020000CB RID: 203
	protected struct ShaderResDesc
	{
		// Token: 0x06000447 RID: 1095 RVA: 0x0001E8E4 File Offset: 0x0001CCE4
		public ShaderResDesc(string res, Shader shader)
		{
			this.m_ShaderRes = res;
			this.m_Shader = shader;
		}

		// Token: 0x040003EE RID: 1006
		public string m_ShaderRes;

		// Token: 0x040003EF RID: 1007
		public Shader m_Shader;
	}
}
