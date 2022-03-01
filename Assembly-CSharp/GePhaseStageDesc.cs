using System;
using UnityEngine;

// Token: 0x02000D2C RID: 3372
public class GePhaseStageDesc
{
	// Token: 0x060089D6 RID: 35286 RVA: 0x001904B5 File Offset: 0x0018E8B5
	public GePhaseStageDesc(Material mat, GameObject[] go, bool glow, Color glowColor)
	{
		this.m_Material = mat;
		this.m_Effectes = go;
		this.m_Glow = glow;
		this.m_GlowColor = glowColor;
	}

	// Token: 0x04004348 RID: 17224
	public Material m_Material;

	// Token: 0x04004349 RID: 17225
	public GameObject[] m_Effectes;

	// Token: 0x0400434A RID: 17226
	public bool m_Glow;

	// Token: 0x0400434B RID: 17227
	public Color m_GlowColor = Color.white;
}
