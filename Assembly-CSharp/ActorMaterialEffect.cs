using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x0200009B RID: 155
public class ActorMaterialEffect : MonoBehaviour
{
	// Token: 0x06000338 RID: 824 RVA: 0x00018C64 File Offset: 0x00017064
	private void Start()
	{
		foreach (SkinnedMeshRenderer skinnedMeshRenderer in base.gameObject.GetComponentsInChildren<SkinnedMeshRenderer>())
		{
			for (int j = 0; j < skinnedMeshRenderer.materials.Length; j++)
			{
				Material item = skinnedMeshRenderer.materials[j];
				this.materialCache.Add(item);
			}
		}
	}

	// Token: 0x06000339 RID: 825 RVA: 0x00018CC8 File Offset: 0x000170C8
	private void OnWillRenderObject()
	{
		Vector4 vector = base.gameObject.transform.position;
		for (int i = 0; i < this.materialCache.Count; i++)
		{
			Material material = this.materialCache[i];
			material.SetColor("_SingleColor", this.color);
			material.SetFloat("_Scale", this.scale);
			material.SetVector("_ActorPos", vector);
			material.renderQueue = 3000;
		}
	}

	// Token: 0x0400032E RID: 814
	private List<Material> materialCache = new List<Material>();

	// Token: 0x0400032F RID: 815
	public float scale;

	// Token: 0x04000330 RID: 816
	public Color color;
}
