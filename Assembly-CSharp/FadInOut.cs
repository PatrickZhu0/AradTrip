using System;
using UnityEngine;

// Token: 0x02004AF9 RID: 19193
public class FadInOut : MonoBehaviour
{
	// Token: 0x0601BEB6 RID: 114358 RVA: 0x0088C3BC File Offset: 0x0088A7BC
	private void Start()
	{
		this.startTime = Time.time;
		MeshRenderer component = base.GetComponent<MeshRenderer>();
		if (!component || !component.material)
		{
			base.enabled = false;
		}
		else
		{
			this.mat = component.material;
			if (this.mat)
			{
				this.mat.shader = AssetShaderLoader.Find("Shader Forge/Ghostshader");
			}
			this.mat.SetColor("_Color", Color.black);
		}
	}

	// Token: 0x0601BEB7 RID: 114359 RVA: 0x0088C448 File Offset: 0x0088A848
	private void Update()
	{
		float num = Time.time - this.startTime;
		if (num > this.life)
		{
			Object.DestroyImmediate(base.gameObject);
		}
		else
		{
			float a = this.life - num;
			if (this.mat)
			{
				Color color = this.mat.GetColor("_Color");
				color = Color.black;
				color.a = a;
				this.mat.SetColor("_Color", color);
			}
		}
	}

	// Token: 0x0401378D RID: 79757
	public float life = 2f;

	// Token: 0x0401378E RID: 79758
	private float startTime;

	// Token: 0x0401378F RID: 79759
	private Material mat;
}
