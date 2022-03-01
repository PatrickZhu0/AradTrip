using System;
using UnityEngine;

// Token: 0x02000063 RID: 99
[ExecuteInEditMode]
public class ComUIFullScreenAspectGeUIEffect : MonoBehaviour
{
	// Token: 0x0600022D RID: 557 RVA: 0x0001198C File Offset: 0x0000FD8C
	private void Start()
	{
		this.originScaleX = base.transform.localScale.x;
		this._updateSize();
	}

	// Token: 0x0600022E RID: 558 RVA: 0x000119B8 File Offset: 0x0000FDB8
	private void _updateSize()
	{
		CameraAspectAdjust.eScreenType screenType = CameraAspectAdjust.GetScreenType();
		float screenDeltaRate = ComUIFullScreenAspectUtility.GetScreenDeltaRate(screenType);
		Vector3 localScale = base.transform.localScale;
		base.transform.localScale = new Vector3(this.originScaleX * screenDeltaRate, localScale.y, localScale.z);
	}

	// Token: 0x04000229 RID: 553
	private float originScaleX = 1f;
}
