using System;
using UnityEngine;

// Token: 0x02000235 RID: 565
public class ColorModify : MonoBehaviour
{
	// Token: 0x060012CC RID: 4812 RVA: 0x00064596 File Offset: 0x00062996
	private void Start()
	{
		this.mesh_renderer = base.gameObject.GetComponent<MeshRenderer>();
	}

	// Token: 0x060012CD RID: 4813 RVA: 0x000645A9 File Offset: 0x000629A9
	private void Update()
	{
		this.mesh_renderer.sharedMaterial.SetColor("_TintColor", this.tintColor);
	}

	// Token: 0x04000C6D RID: 3181
	public Color tintColor = Color.white;

	// Token: 0x04000C6E RID: 3182
	[HideInInspector]
	private MeshRenderer mesh_renderer;
}
