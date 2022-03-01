using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000D3B RID: 3387
public class GeUIEffectAttach : MonoBehaviour
{
	// Token: 0x06008A0A RID: 35338 RVA: 0x00193C5C File Offset: 0x0019205C
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
			this.RecursiveSetOrderInLayer(base.transform, canvas.sortingLayerID, canvas.sortingOrder);
		}
		this.m_TransChanged = new List<int>(this.m_Dummys.Count);
		for (int i = 0; i < this.m_Dummys.Count; i++)
		{
			Matrix4x4 matrix4x = this.m_UIEffects[i].parent.worldToLocalMatrix * this.m_Dummys[i].localToWorldMatrix;
			this.m_UIEffects[i].localPosition = matrix4x.GetColumn(3);
			this.m_UIEffects[i].localRotation = Quaternion.LookRotation(matrix4x.GetColumn(2), matrix4x.GetColumn(1));
			this.m_UIEffects[i].localScale = new Vector3(matrix4x.GetColumn(0).magnitude, matrix4x.GetColumn(1).magnitude, matrix4x.GetColumn(2).magnitude);
			this.m_Dummys[i].hasChanged = false;
		}
	}

	// Token: 0x06008A0B RID: 35339 RVA: 0x00193DCC File Offset: 0x001921CC
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
		MeshRenderer component3 = node.GetComponent<MeshRenderer>();
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

	// Token: 0x06008A0C RID: 35340 RVA: 0x00193E60 File Offset: 0x00192260
	private void Update()
	{
		this.m_TransChanged.Clear();
		for (int i = 0; i < this.m_Dummys.Count; i++)
		{
			if (!(this.m_Dummys[i] == null) && !(this.m_UIEffects[i] == null))
			{
				RectTransform rectTransform = this.m_Dummys[i];
				RectTransform rectTransform2 = this.m_UIEffects[i];
				if (rectTransform2.gameObject.activeSelf != rectTransform.gameObject.activeInHierarchy)
				{
					rectTransform2.gameObject.SetActive(rectTransform.gameObject.activeInHierarchy);
				}
				if (rectTransform2.gameObject.activeInHierarchy && this.m_Dummys[i].hasChanged)
				{
					this.m_TransChanged.Add(i);
					Matrix4x4 matrix4x = rectTransform2.parent.worldToLocalMatrix * rectTransform.localToWorldMatrix;
					rectTransform2.localPosition = matrix4x.GetColumn(3);
					rectTransform2.localRotation = Quaternion.LookRotation(matrix4x.GetColumn(2), matrix4x.GetColumn(1));
					rectTransform2.localScale = new Vector3(matrix4x.GetColumn(0).magnitude, matrix4x.GetColumn(1).magnitude, matrix4x.GetColumn(2).magnitude);
				}
			}
		}
	}

	// Token: 0x06008A0D RID: 35341 RVA: 0x00193FD4 File Offset: 0x001923D4
	private void LateUpdate()
	{
		int count = this.m_TransChanged.Count;
		for (int i = 0; i < count; i++)
		{
			this.m_Dummys[this.m_TransChanged[i]].hasChanged = false;
		}
	}

	// Token: 0x06008A0E RID: 35342 RVA: 0x0019401C File Offset: 0x0019241C
	public void DelItem(int iIndex)
	{
		this.m_Dummys.RemoveAt(iIndex);
		this.m_UIEffects.RemoveAt(iIndex);
		this.m_TransChanged.Clear();
	}

	// Token: 0x06008A0F RID: 35343 RVA: 0x00194041 File Offset: 0x00192441
	public void AddNewItem()
	{
		this.m_Dummys.Add(null);
		this.m_UIEffects.Add(null);
	}

	// Token: 0x040043F5 RID: 17397
	[SerializeField]
	public List<RectTransform> m_Dummys = new List<RectTransform>();

	// Token: 0x040043F6 RID: 17398
	[SerializeField]
	public List<RectTransform> m_UIEffects = new List<RectTransform>();

	// Token: 0x040043F7 RID: 17399
	private List<int> m_TransChanged;
}
