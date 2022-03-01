using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001133 RID: 4403
[RequireComponent(typeof(PolygonCollider2D))]
public class UIPolygon : Image
{
	// Token: 0x0600A75B RID: 42843 RVA: 0x0022E84E File Offset: 0x0022CC4E
	protected UIPolygon()
	{
		base.useLegacyMeshGeneration = true;
	}

	// Token: 0x170019C7 RID: 6599
	// (get) Token: 0x0600A75C RID: 42844 RVA: 0x0022E85D File Offset: 0x0022CC5D
	private PolygonCollider2D polygon
	{
		get
		{
			if (this._polygon == null)
			{
				this._polygon = base.GetComponent<PolygonCollider2D>();
			}
			return this._polygon;
		}
	}

	// Token: 0x0600A75D RID: 42845 RVA: 0x0022E882 File Offset: 0x0022CC82
	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
	}

	// Token: 0x0600A75E RID: 42846 RVA: 0x0022E88A File Offset: 0x0022CC8A
	public override bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
	{
		return this.polygon.OverlapPoint(eventCamera.ScreenToWorldPoint(screenPoint));
	}

	// Token: 0x04005DA9 RID: 23977
	private PolygonCollider2D _polygon;
}
