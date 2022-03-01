using System;
using UnityEngine;

// Token: 0x0200023C RID: 572
public class DestroyDelay : MonoBehaviour
{
	// Token: 0x060012F7 RID: 4855 RVA: 0x00064DA8 File Offset: 0x000631A8
	private void Update()
	{
		this.Delay -= Time.deltaTime;
		if (this.Delay <= 0f)
		{
			base.gameObject.transform.SetParent(null, false);
			Singleton<CGameObjectPool>.instance.RecycleGameObject(base.gameObject);
		}
	}

	// Token: 0x04000C8B RID: 3211
	public float Delay = 0.5f;
}
