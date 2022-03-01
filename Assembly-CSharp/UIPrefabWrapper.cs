using System;
using UnityEngine;

// Token: 0x020001FE RID: 510
public class UIPrefabWrapper : MonoBehaviour
{
	// Token: 0x06001050 RID: 4176 RVA: 0x00054EB7 File Offset: 0x000532B7
	public GameObject LoadUIPrefab()
	{
		return Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.m_PrefabName, true, 0U);
	}

	// Token: 0x06001051 RID: 4177 RVA: 0x00054ECC File Offset: 0x000532CC
	public GameObject LoadUIPrefab(Transform placeHolder)
	{
		GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.m_PrefabName, true, 0U);
		if (gameObject == null)
		{
			Logger.LogError("加载预制体失败,路径:" + this.m_PrefabName);
		}
		if (gameObject != null && placeHolder != null)
		{
			gameObject.name = placeHolder.name;
			gameObject.transform.SetParent(placeHolder.transform.parent, false);
			gameObject.transform.localPosition = placeHolder.transform.localPosition;
			gameObject.transform.localScale = placeHolder.transform.localScale;
			gameObject.transform.SetSiblingIndex(placeHolder.transform.GetSiblingIndex());
			Object.Destroy(placeHolder.gameObject);
		}
		return gameObject;
	}

	// Token: 0x04000B25 RID: 2853
	public string m_PrefabName;

	// Token: 0x04000B26 RID: 2854
	public int IntParam;
}
