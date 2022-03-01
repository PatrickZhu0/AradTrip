using System;
using UnityEngine;

// Token: 0x020045E9 RID: 17897
[ExecuteInEditMode]
public class EffectAutoScale : MonoBehaviour
{
	// Token: 0x060192BA RID: 103098 RVA: 0x007F532A File Offset: 0x007F372A
	private void Start()
	{
		this.AutoScale();
	}

	// Token: 0x060192BB RID: 103099 RVA: 0x007F5334 File Offset: 0x007F3734
	private void AutoScale()
	{
		if (this.target != null)
		{
			this.fRadio = 1f / this.fScaleBase * 10f;
			Bounds bounds = RectTransformUtility.CalculateRelativeRectTransformBounds(this.target.transform);
			float num = bounds.size.x * this.fRadio * 0.5f / this.fScaleX;
			float num2 = bounds.size.y * this.fRadio * 0.5f / this.fScaleY;
			base.transform.localScale = new Vector3(num, num2, 1f);
			base.transform.localPosition = new Vector3(-bounds.size.x * 0.5f + bounds.size.x * this.fOffsetScaleX, -bounds.size.y * 0.5f + bounds.size.y * this.fOffsetScaleY, base.transform.localPosition.z);
		}
	}

	// Token: 0x060192BC RID: 103100 RVA: 0x007F545D File Offset: 0x007F385D
	private void Update()
	{
		this.AutoScale();
	}

	// Token: 0x04012078 RID: 73848
	public float fOffsetScaleX;

	// Token: 0x04012079 RID: 73849
	public float fOffsetScaleY;

	// Token: 0x0401207A RID: 73850
	public float fScaleX = 1f;

	// Token: 0x0401207B RID: 73851
	public float fScaleY = 1f;

	// Token: 0x0401207C RID: 73852
	public float fScaleBase = 100f;

	// Token: 0x0401207D RID: 73853
	public RectTransform target;

	// Token: 0x0401207E RID: 73854
	private float fRadio = 0.01f;
}
