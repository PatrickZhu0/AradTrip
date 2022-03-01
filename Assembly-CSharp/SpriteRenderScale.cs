using System;
using UnityEngine;

// Token: 0x020045FA RID: 17914
[RequireComponent(typeof(SpriteRenderer))]
[ExecuteInEditMode]
public class SpriteRenderScale : MonoBehaviour
{
	// Token: 0x060192EA RID: 103146 RVA: 0x007F69CB File Offset: 0x007F4DCB
	private void Start()
	{
		this.render = base.GetComponent<SpriteRenderer>();
		if (this.bNeedUpdate)
		{
			base.InvokeRepeating("UpdateScale", 0f, 0.333f);
		}
	}

	// Token: 0x060192EB RID: 103147 RVA: 0x007F69FC File Offset: 0x007F4DFC
	private void UpdateScale()
	{
		if (this.target != null)
		{
			Vector3 size = RectTransformUtility.CalculateRelativeRectTransformBounds(this.target.transform).size;
			this.scale.x = size.x / this.render.sprite.bounds.size.x;
			this.scale.y = size.y / this.render.sprite.bounds.size.y;
			base.transform.localScale = this.scale;
		}
	}

	// Token: 0x0401209C RID: 73884
	public RectTransform target;

	// Token: 0x0401209D RID: 73885
	public bool bNeedUpdate;

	// Token: 0x0401209E RID: 73886
	private SpriteRenderer render;

	// Token: 0x0401209F RID: 73887
	private Vector3 scale = Vector3.one;
}
