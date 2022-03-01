using System;
using UnityEngine;

// Token: 0x02000D40 RID: 3392
[ExecuteInEditMode]
public class GeUIEffectOrder : MonoBehaviour
{
	// Token: 0x06008A1C RID: 35356 RVA: 0x00194220 File Offset: 0x00192620
	private void Start()
	{
		Canvas canvas = null;
		Transform transform = base.transform;
		while (canvas == null && transform != null)
		{
			canvas = transform.GetComponent<Canvas>();
			transform = transform.parent;
		}
		if (canvas != null)
		{
			this.RecursiveSetOrderInLayer(base.transform, canvas.sortingLayerID, canvas.sortingOrder + this.m_SortingOrderOffset);
		}
	}

	// Token: 0x06008A1D RID: 35357 RVA: 0x0019428C File Offset: 0x0019268C
	private void RecursiveSetOrderInLayer(Transform node, int sortinglayerID, int order)
	{
		if (node == null)
		{
			return;
		}
		ParticleSystem component = node.GetComponent<ParticleSystem>();
		if (component != null)
		{
			Renderer component2 = component.GetComponent<Renderer>();
			if (component2)
			{
				component2.sortingLayerID = sortinglayerID;
				component2.sortingOrder = order;
			}
		}
		Renderer component3 = node.GetComponent<Renderer>();
		if (component3 != null)
		{
			component3.sortingLayerID = sortinglayerID;
			component3.sortingOrder = order;
		}
		for (int i = 0; i < node.childCount; i++)
		{
			this.RecursiveSetOrderInLayer(node.GetChild(i), sortinglayerID, order);
		}
	}

	// Token: 0x04004401 RID: 17409
	public int m_SortingOrderOffset;
}
