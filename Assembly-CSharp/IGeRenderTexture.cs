using System;
using UnityEngine;

// Token: 0x02000D77 RID: 3447
public interface IGeRenderTexture
{
	// Token: 0x06008BE4 RID: 35812
	GameObject GetModelRoot();

	// Token: 0x06008BE5 RID: 35813
	Camera GetCamera();

	// Token: 0x06008BE6 RID: 35814
	Light GetLight();

	// Token: 0x06008BE7 RID: 35815
	RenderTexture GetRenderTexture();

	// Token: 0x06008BE8 RID: 35816
	int GetMaskLayer();
}
