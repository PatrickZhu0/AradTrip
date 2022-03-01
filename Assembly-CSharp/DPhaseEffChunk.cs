using System;

// Token: 0x02004B98 RID: 19352
[Serializable]
public struct DPhaseEffChunk
{
	// Token: 0x0401390E RID: 80142
	public string name;

	// Token: 0x0401390F RID: 80143
	public string shaderName;

	// Token: 0x04013910 RID: 80144
	public DPhaseStageParamChunk[] phaseStageChunk;
}
