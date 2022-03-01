using System;
using UnityEngine;

// Token: 0x02004B93 RID: 19347
[Serializable]
public struct DBlockChunk
{
	// Token: 0x040138F7 RID: 80119
	public int gridWidth;

	// Token: 0x040138F8 RID: 80120
	public int gridHeight;

	// Token: 0x040138F9 RID: 80121
	public byte[] gridBlockData;

	// Token: 0x040138FA RID: 80122
	public Vector3 boundingBoxMin;

	// Token: 0x040138FB RID: 80123
	public Vector3 boundingBoxMax;
}
