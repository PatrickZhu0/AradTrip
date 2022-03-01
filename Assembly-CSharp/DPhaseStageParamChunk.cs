using System;
using UnityEngine;

// Token: 0x02004B97 RID: 19351
[Serializable]
public struct DPhaseStageParamChunk
{
	// Token: 0x0401390A RID: 80138
	public DAnimatParamDesc[] paramDesc;

	// Token: 0x0401390B RID: 80139
	public DPhaseStageEffectChunk[] effectDesc;

	// Token: 0x0401390C RID: 80140
	public bool needGlow;

	// Token: 0x0401390D RID: 80141
	public Color glowColor;
}
