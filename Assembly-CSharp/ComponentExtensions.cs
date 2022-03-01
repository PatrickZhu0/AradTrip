using System;
using UnityEngine;

// Token: 0x02004934 RID: 18740
public static class ComponentExtensions
{
	// Token: 0x0601AF3B RID: 110395 RVA: 0x008497F7 File Offset: 0x00847BF7
	public static RectTransform rectTransform(this Component cp)
	{
		return cp.transform as RectTransform;
	}

	// Token: 0x0601AF3C RID: 110396 RVA: 0x00849804 File Offset: 0x00847C04
	public static float Remap(this float value, float from1, float to1, float from2, float to2)
	{
		return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}
}
