using System;
using UnityEngine;

// Token: 0x02000065 RID: 101
public class ComUIFullScreenAspectUtility
{
	// Token: 0x06000233 RID: 563 RVA: 0x00011A64 File Offset: 0x0000FE64
	public static float GetScreenDeltaRate(CameraAspectAdjust.eScreenType type)
	{
		int width = Screen.width;
		int height = Screen.height;
		if ((float)width * 1f / (float)height * 1080f / 1920f < 1f)
		{
			return 1f;
		}
		return (float)width * 1f / (float)height * 1080f / 1920f;
	}

	// Token: 0x06000234 RID: 564 RVA: 0x00011ABB File Offset: 0x0000FEBB
	public static Vector2 GetScreenDeltaSize(CameraAspectAdjust.eScreenType type)
	{
		return ComUIFullScreenAspectUtility.originScreenSize * ComUIFullScreenAspectUtility.GetScreenDeltaRate(type);
	}

	// Token: 0x06000235 RID: 565 RVA: 0x00011AD0 File Offset: 0x0000FED0
	public static Vector2 GetScreenDeltaSizeEachSizeX(CameraAspectAdjust.eScreenType type)
	{
		return new Vector2(((ComUIFullScreenAspectUtility.GetScreenDeltaSize(type) - ComUIFullScreenAspectUtility.originScreenSize) / 2f).x, ComUIFullScreenAspectUtility.originScreenSize.y);
	}

	// Token: 0x0400022A RID: 554
	private const int kWidth = 1920;

	// Token: 0x0400022B RID: 555
	private const int kHeight = 1080;

	// Token: 0x0400022C RID: 556
	private static Vector2 originScreenSize = new Vector2(1920f, 1080f);
}
