using System;
using UnityEngine;

// Token: 0x02000062 RID: 98
[ExecuteInEditMode]
public class ComUIFullScreenAspect : MonoBehaviour
{
	// Token: 0x06000229 RID: 553 RVA: 0x00011903 File Offset: 0x0000FD03
	private void Start()
	{
		this._updateSize();
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0001190C File Offset: 0x0000FD0C
	private void _updateSize()
	{
		RectTransform component = base.GetComponent<RectTransform>();
		if (null == component)
		{
			return;
		}
		component.anchorMin = ComUIFullScreenAspect.half;
		component.anchorMax = ComUIFullScreenAspect.half;
		component.pivot = ComUIFullScreenAspect.half;
		CameraAspectAdjust.eScreenType screenType = CameraAspectAdjust.GetScreenType();
		component.sizeDelta = ComUIFullScreenAspectUtility.GetScreenDeltaSize(screenType);
	}

	// Token: 0x04000228 RID: 552
	private static Vector2 half = new Vector2(0.5f, 0.5f);
}
