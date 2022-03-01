using System;
using System.Collections;
using UnityEngine;

// Token: 0x020000EE RID: 238
public interface IAssetManager
{
	// Token: 0x060004EF RID: 1263
	GameObject GetGameObject(string strResPath, Vector3 pos, Quaternion rot, enResourceType resourceType);

	// Token: 0x060004F0 RID: 1264
	GameObject GetGameObject(string strResPath, Vector3 pos, enResourceType resourceType);

	// Token: 0x060004F1 RID: 1265
	void AddPreloadObject(string strResPath);

	// Token: 0x060004F2 RID: 1266
	bool ProcessPreload();

	// Token: 0x060004F3 RID: 1267
	IEnumerator StepProcessPreload();

	// Token: 0x060004F4 RID: 1268
	void LoadScene(string strScene);

	// Token: 0x060004F5 RID: 1269
	IEnumerator StepLoadScene(string strScene);
}
