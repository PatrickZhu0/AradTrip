using System;
using UnityEngine;

// Token: 0x02000D32 RID: 3378
public struct MyTextVertices
{
	// Token: 0x060089E7 RID: 35303 RVA: 0x00191468 File Offset: 0x0018F868
	public MyTextVertices(Vector3 position0, Vector3 position1, Vector3 position2, Vector3 position3, Vector2 uv0, Vector2 uv1, Vector2 uv2, Vector2 uv3)
	{
		this.position0 = position0;
		this.position1 = position1;
		this.position2 = position2;
		this.position3 = position3;
		this.uv0 = uv0;
		this.uv1 = uv1;
		this.uv2 = uv2;
		this.uv3 = uv3;
		this.width = position1.x - position0.x;
	}

	// Token: 0x0400437B RID: 17275
	public Vector3 position0;

	// Token: 0x0400437C RID: 17276
	public Vector3 position1;

	// Token: 0x0400437D RID: 17277
	public Vector3 position2;

	// Token: 0x0400437E RID: 17278
	public Vector3 position3;

	// Token: 0x0400437F RID: 17279
	public Vector2 uv0;

	// Token: 0x04004380 RID: 17280
	public Vector2 uv1;

	// Token: 0x04004381 RID: 17281
	public Vector2 uv2;

	// Token: 0x04004382 RID: 17282
	public Vector2 uv3;

	// Token: 0x04004383 RID: 17283
	public float width;
}
