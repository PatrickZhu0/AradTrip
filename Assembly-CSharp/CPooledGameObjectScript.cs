using System;
using UnityEngine;

// Token: 0x0200024F RID: 591
public class CPooledGameObjectScript : MonoBehaviour
{
	// Token: 0x04000D28 RID: 3368
	public Vector3 m_defaultScale;

	// Token: 0x04000D29 RID: 3369
	public bool m_isInit;

	// Token: 0x04000D2A RID: 3370
	public IPooledMonoBehaviour[] m_pooledMonoBehaviours;

	// Token: 0x04000D2B RID: 3371
	public string m_prefabKey;

	// Token: 0x04000D2C RID: 3372
	public bool m_IsOriginInVisible;

	// Token: 0x04000D2D RID: 3373
	public bool m_IsRecycled;
}
