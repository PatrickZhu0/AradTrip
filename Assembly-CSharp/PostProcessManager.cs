using System;
using UnityEngine;

// Token: 0x02000D85 RID: 3461
public class PostProcessManager : Singleton<PostProcessManager>
{
	// Token: 0x06008C50 RID: 35920 RVA: 0x0019FE40 File Offset: 0x0019E240
	public Vector2 GetScreenDimension()
	{
		Resolution currentResolution = Screen.currentResolution;
		return new Vector2((float)currentResolution.width, (float)currentResolution.height);
	}
}
