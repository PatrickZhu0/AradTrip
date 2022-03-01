using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x02001AA2 RID: 6818
[RequireComponent(typeof(Image))]
public class Drag_Me : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IEventSystemHandler
{
	// Token: 0x06010BB8 RID: 68536 RVA: 0x004BEB3C File Offset: 0x004BCF3C
	public void OnBeginDrag(PointerEventData eventData)
	{
		Canvas canvas = Drag_Me.FindInParents<Canvas>(base.gameObject);
		if (canvas == null)
		{
			return;
		}
		bool flag = false;
		int sortingOrder = 0;
		if (!canvas.isRootCanvas && canvas.overrideSorting)
		{
			flag = true;
			sortingOrder = canvas.sortingOrder;
			canvas = Drag_Me.FindRootCanvas(base.gameObject);
		}
		this.m_DraggingIcons[eventData.pointerId] = new GameObject("iconback");
		this.m_DraggingIcons[eventData.pointerId + 1] = new GameObject("icon");
		this.m_DraggingIcons[eventData.pointerId].transform.SetParent(canvas.transform, false);
		this.m_DraggingIcons[eventData.pointerId + 1].transform.SetParent(canvas.transform, false);
		this.m_DraggingIcons[eventData.pointerId + 1].transform.SetAsLastSibling();
		Image image = this.m_DraggingIcons[eventData.pointerId].AddComponent<Image>();
		Image image2 = this.m_DraggingIcons[eventData.pointerId + 1].AddComponent<Image>();
		CanvasGroup canvasGroup = this.m_DraggingIcons[eventData.pointerId].AddComponent<CanvasGroup>();
		canvasGroup.blocksRaycasts = false;
		CanvasGroup canvasGroup2 = this.m_DraggingIcons[eventData.pointerId + 1].AddComponent<CanvasGroup>();
		canvasGroup2.blocksRaycasts = false;
		GameObject gameObject = base.GetComponent<Image>().transform.parent.gameObject;
		UIGray component = base.GetComponent<UIGray>();
		if (null == component)
		{
			component = gameObject.GetComponent<UIGray>();
		}
		Image component2 = gameObject.GetComponent<Image>();
		image.sprite = component2.sprite;
		image.material = component2.material;
		Image component3 = base.GetComponent<Image>();
		image2.sprite = component3.sprite;
		image2.material = component3.material;
		if (null != component)
		{
			component.SetImageAlpha(component2, image);
			component.SetImageAlpha(component3, image2);
		}
		if (this.dragOnSurfaces)
		{
			this.m_DraggingPlanes[eventData.pointerId] = (base.transform as RectTransform);
		}
		else
		{
			this.m_DraggingPlanes[eventData.pointerId] = (canvas.transform as RectTransform);
		}
		if (flag)
		{
			Utility.AddUICanvasCom(this.m_DraggingIcons[eventData.pointerId], sortingOrder, 5, false);
			Utility.AddUICanvasCom(this.m_DraggingIcons[eventData.pointerId + 1], sortingOrder, 5, false);
		}
		this.SetDraggedPosition(eventData);
		this._isForceEndDrag = false;
	}

	// Token: 0x06010BB9 RID: 68537 RVA: 0x004BEDD0 File Offset: 0x004BD1D0
	public void OnDrag(PointerEventData eventData)
	{
		if (this._isForceEndDrag)
		{
			return;
		}
		GameObject gameObject = null;
		this.m_DraggingIcons.TryGetValue(eventData.pointerId, out gameObject);
		if (gameObject == null)
		{
			Logger.LogErrorFormat("[Drag_Me] The given key was not present in the dictionary.key = {0}", new object[]
			{
				eventData.pointerId
			});
		}
		else
		{
			if (this.ResponseDrag != null && !this.ResponseDrag(eventData, true))
			{
				this.OnEndDrag(eventData);
				this._isForceEndDrag = true;
				return;
			}
			this.SetDraggedPosition(eventData);
		}
	}

	// Token: 0x06010BBA RID: 68538 RVA: 0x004BEE64 File Offset: 0x004BD264
	public void OnEndDrag(PointerEventData eventData)
	{
		if (this.m_DraggingIcons[eventData.pointerId] != null)
		{
			Object.Destroy(this.m_DraggingIcons[eventData.pointerId]);
		}
		this.m_DraggingIcons[eventData.pointerId] = null;
		if (this.m_DraggingIcons[eventData.pointerId + 1] != null)
		{
			Object.Destroy(this.m_DraggingIcons[eventData.pointerId + 1]);
		}
		this.m_DraggingIcons[eventData.pointerId + 1] = null;
	}

	// Token: 0x06010BBB RID: 68539 RVA: 0x004BEF00 File Offset: 0x004BD300
	private void SetDraggedPosition(PointerEventData eventData)
	{
		if (this.dragOnSurfaces && eventData.pointerEnter != null && eventData.pointerEnter.transform as RectTransform != null)
		{
			this.m_DraggingPlanes[eventData.pointerId] = (eventData.pointerEnter.transform as RectTransform);
		}
		RectTransform component = this.m_DraggingIcons[eventData.pointerId].GetComponent<RectTransform>();
		Vector3 position;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_DraggingPlanes[eventData.pointerId], eventData.position, eventData.pressEventCamera, ref position) && component != null)
		{
			component.position = position;
			component.rotation = this.m_DraggingPlanes[eventData.pointerId].rotation;
		}
		RectTransform component2 = this.m_DraggingIcons[eventData.pointerId + 1].GetComponent<RectTransform>();
		Vector3 position2;
		if (RectTransformUtility.ScreenPointToWorldPointInRectangle(this.m_DraggingPlanes[eventData.pointerId], eventData.position, eventData.pressEventCamera, ref position2) && component2 != null)
		{
			component2.position = position2;
			component2.rotation = this.m_DraggingPlanes[eventData.pointerId].rotation;
		}
	}

	// Token: 0x06010BBC RID: 68540 RVA: 0x004BF048 File Offset: 0x004BD448
	public static T FindInParents<T>(GameObject go) where T : Component
	{
		if (go == null)
		{
			return (T)((object)null);
		}
		T component = go.GetComponent<T>();
		if (component != null)
		{
			return component;
		}
		Transform parent = go.transform.parent;
		while (parent != null && component == null)
		{
			component = parent.gameObject.GetComponent<T>();
			parent = parent.parent;
		}
		return component;
	}

	// Token: 0x06010BBD RID: 68541 RVA: 0x004BF0C4 File Offset: 0x004BD4C4
	public static Canvas FindRootCanvas(GameObject go)
	{
		if (go == null)
		{
			return null;
		}
		Canvas component = go.GetComponent<Canvas>();
		if (component != null && component.isRootCanvas)
		{
			return component;
		}
		Transform parent = go.transform.parent;
		while (parent != null)
		{
			component = parent.gameObject.GetComponent<Canvas>();
			if (component != null && component.isRootCanvas)
			{
				break;
			}
			parent = parent.parent;
		}
		return component;
	}

	// Token: 0x0400AB26 RID: 43814
	public Drag_Me.OnResDrag ResponseDrag;

	// Token: 0x0400AB27 RID: 43815
	public bool dragOnSurfaces = true;

	// Token: 0x0400AB28 RID: 43816
	public int index = -1;

	// Token: 0x0400AB29 RID: 43817
	private Dictionary<int, GameObject> m_DraggingIcons = new Dictionary<int, GameObject>();

	// Token: 0x0400AB2A RID: 43818
	private Dictionary<int, RectTransform> m_DraggingPlanes = new Dictionary<int, RectTransform>();

	// Token: 0x0400AB2B RID: 43819
	private bool _isForceEndDrag;

	// Token: 0x0400AB2C RID: 43820
	public EDragGroup DragGroup;

	// Token: 0x0400AB2D RID: 43821
	public ushort Id;

	// Token: 0x02001AA3 RID: 6819
	// (Invoke) Token: 0x06010BBF RID: 68543
	public delegate bool OnResDrag(PointerEventData eventData, bool bIsDrag = true);
}
