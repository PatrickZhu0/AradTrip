using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000D55 RID: 3413
public class Particle3DUIOrder : MonoBehaviour
{
	// Token: 0x06008AA9 RID: 35497 RVA: 0x0019774B File Offset: 0x00195B4B
	protected void Start()
	{
		base.StartCoroutine(this._SetRendererOrder());
	}

	// Token: 0x06008AAA RID: 35498 RVA: 0x0019775C File Offset: 0x00195B5C
	private IEnumerator _SetRendererOrder()
	{
		WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
		yield return waitForEndOfFrame;
		yield return waitForEndOfFrame;
		Canvas canvas = base.GetComponentInParent<Canvas>();
		if (canvas != null)
		{
			Renderer[] componentsInChildren = base.GetComponentsInChildren<Renderer>(true);
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.sortingLayerID = canvas.sortingLayerID;
				renderer.sortingOrder = canvas.sortingOrder + this.m_Order;
			}
		}
		yield break;
	}

	// Token: 0x04004498 RID: 17560
	public int m_Order = 1;
}
