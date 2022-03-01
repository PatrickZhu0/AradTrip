using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000D76 RID: 3446
public class GeMaterialPool : Singleton<GeMaterialPool>
{
	// Token: 0x06008BE1 RID: 35809 RVA: 0x0019D1BC File Offset: 0x0019B5BC
	public Material CreateMaterialInstance(string shaderName)
	{
		string key = CFileManager.EraseExtension(shaderName);
		Queue<Material> queue = null;
		if (!this.m_pooledMatInstMap.TryGetValue(key, out queue))
		{
			queue = new Queue<Material>();
			this.m_pooledMatInstMap.Add(key, queue);
		}
		Material material = null;
		while (queue.Count > 0)
		{
			material = queue.Dequeue();
			if (material != null)
			{
				break;
			}
			material = null;
		}
		if (material != null)
		{
			return material;
		}
		Shader shader = AssetShaderLoader.Find(shaderName);
		if (null != shader)
		{
			return new Material(shader);
		}
		return null;
	}

	// Token: 0x06008BE2 RID: 35810 RVA: 0x0019D254 File Offset: 0x0019B654
	public void RecycleMaterialInstance(string materialKey, Material matInst)
	{
		if (null == matInst)
		{
			return;
		}
		Queue<Material> queue = null;
		if (this.m_pooledMatInstMap.TryGetValue(materialKey, out queue))
		{
			queue.Enqueue(matInst);
		}
		else
		{
			Object.Destroy(matInst);
		}
	}

	// Token: 0x06008BE3 RID: 35811 RVA: 0x0019D298 File Offset: 0x0019B698
	public void ClearAll()
	{
		foreach (KeyValuePair<string, Queue<Material>> keyValuePair in this.m_pooledMatInstMap)
		{
			Queue<Material> value = keyValuePair.Value;
			while (value.Count > 0)
			{
				Material material = value.Dequeue();
				if (null != material)
				{
					Object.Destroy(material);
				}
			}
		}
		this.m_pooledMatInstMap.Clear();
	}

	// Token: 0x04004519 RID: 17689
	private Dictionary<string, Queue<Material>> m_pooledMatInstMap = new Dictionary<string, Queue<Material>>();
}
