using System;
using UnityEngine;

// Token: 0x02000D37 RID: 3383
public class TilingChange : MonoBehaviour
{
	// Token: 0x06008A02 RID: 35330 RVA: 0x00193B45 File Offset: 0x00191F45
	private void Start()
	{
		this.material = base.GetComponent<Renderer>().material;
		this.startOffset = this.offStart;
	}

	// Token: 0x06008A03 RID: 35331 RVA: 0x00193B64 File Offset: 0x00191F64
	private void Update()
	{
		this.startOffset.x = this.startOffset.x + this.speed.x * (this.offFinal.x - this.offStart.x);
		this.startOffset.y = this.startOffset.y + this.speed.y * (this.offFinal.y - this.offStart.y);
		if (this.startOffset.x >= this.offFinal.x)
		{
			return;
		}
		this.material.SetVector("_MainTex_ST", this.startOffset);
	}

	// Token: 0x040043EC RID: 17388
	public Material material;

	// Token: 0x040043ED RID: 17389
	public Vector2 offStart = new Vector2(0.7f, 1f);

	// Token: 0x040043EE RID: 17390
	public Vector2 offFinal = new Vector2(2.5f, 1f);

	// Token: 0x040043EF RID: 17391
	public Vector2 speed = new Vector2(0.0004f, 0f);

	// Token: 0x040043F0 RID: 17392
	private Vector2 startOffset = default(Vector2);
}
