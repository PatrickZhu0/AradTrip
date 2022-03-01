using System;
using UnityEngine;
using UnityEngine.Rendering;

// Token: 0x02004B78 RID: 19320
[Serializable]
public class DRenderSettings
{
	// Token: 0x040138BF RID: 80063
	public bool fog;

	// Token: 0x040138C0 RID: 80064
	public FogMode fogMode;

	// Token: 0x040138C1 RID: 80065
	public Color fogColor;

	// Token: 0x040138C2 RID: 80066
	public float fogDensity;

	// Token: 0x040138C3 RID: 80067
	public float fogStartDistance;

	// Token: 0x040138C4 RID: 80068
	public float fogEndDistance;

	// Token: 0x040138C5 RID: 80069
	public AmbientMode ambientMode;

	// Token: 0x040138C6 RID: 80070
	public Color ambientSkyColor;

	// Token: 0x040138C7 RID: 80071
	public Color ambientEquatorColor;

	// Token: 0x040138C8 RID: 80072
	public Color ambientGroundColor;

	// Token: 0x040138C9 RID: 80073
	public Color ambientLight;

	// Token: 0x040138CA RID: 80074
	public float ambientIntensity;
}
