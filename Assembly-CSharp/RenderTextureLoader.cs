using System;
using UnityEngine;

// Token: 0x02000D88 RID: 3464
public class RenderTextureLoader : MonoBehaviour
{
	// Token: 0x06008C5F RID: 35935 RVA: 0x0019FFC8 File Offset: 0x0019E3C8
	private void Start()
	{
		Camera componentInChildren = base.gameObject.transform.GetComponentInChildren<Camera>();
		if (null != componentInChildren)
		{
			RenderTexture renderTexture = Singleton<AssetLoader>.instance.LoadRes("UI/Material/" + base.gameObject.name, typeof(RenderTexture), true, 0U).obj as RenderTexture;
			if (null != renderTexture)
			{
				componentInChildren.targetTexture = renderTexture;
			}
		}
	}
}
