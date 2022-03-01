using System;
using UnityEngine;

// Token: 0x020045FE RID: 17918
public class UIDepth : MonoBehaviour
{
	// Token: 0x060192FA RID: 103162 RVA: 0x007F7450 File Offset: 0x007F5850
	private void Start()
	{
		if (this.isUI)
		{
			Canvas canvas = base.GetComponent<Canvas>();
			if (canvas == null)
			{
				canvas = base.gameObject.AddComponent<Canvas>();
			}
			canvas.overrideSorting = true;
			canvas.sortingOrder = this.order;
		}
		else
		{
			Renderer[] componentsInChildren = base.GetComponentsInChildren<Renderer>();
			foreach (Renderer renderer in componentsInChildren)
			{
				renderer.sortingOrder = this.order;
			}
		}
	}

	// Token: 0x040120AF RID: 73903
	public int order;

	// Token: 0x040120B0 RID: 73904
	public bool isUI = true;
}
