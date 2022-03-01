using System;
using UnityEngine;

// Token: 0x02000064 RID: 100
[ExecuteInEditMode]
public class ComUIFullScreenAspectNotLoading : MonoBehaviour
{
	// Token: 0x06000230 RID: 560 RVA: 0x00011A0C File Offset: 0x0000FE0C
	private void Start()
	{
		this._updateSize();
	}

	// Token: 0x06000231 RID: 561 RVA: 0x00011A14 File Offset: 0x0000FE14
	private void _updateSize()
	{
		RectTransform component = base.GetComponent<RectTransform>();
		if (null == component)
		{
			return;
		}
		CameraAspectAdjust.eScreenType screenType = CameraAspectAdjust.GetScreenType();
		Vector2 screenDeltaSizeEachSizeX = ComUIFullScreenAspectUtility.GetScreenDeltaSizeEachSizeX(screenType);
		component.sizeDelta = new Vector2(screenDeltaSizeEachSizeX.y, screenDeltaSizeEachSizeX.x);
	}
}
