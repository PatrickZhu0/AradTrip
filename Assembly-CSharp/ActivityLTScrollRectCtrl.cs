using System;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Token: 0x020018BA RID: 6330
public class ActivityLTScrollRectCtrl : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler, IEventSystemHandler
{
	// Token: 0x1400000C RID: 12
	// (add) Token: 0x0600F756 RID: 63318 RVA: 0x0042E824 File Offset: 0x0042CC24
	// (remove) Token: 0x0600F757 RID: 63319 RVA: 0x0042E85C File Offset: 0x0042CC5C
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	public event Action<ActivityLTScrollRectCtrl.DragDirection> OnDragDirHandler;

	// Token: 0x17001CFE RID: 7422
	// (get) Token: 0x0600F758 RID: 63320 RVA: 0x0042E892 File Offset: 0x0042CC92
	public ActivityLTScrollRectCtrl.DragDirection CurrDragDir
	{
		get
		{
			return this.currDragDir;
		}
	}

	// Token: 0x0600F759 RID: 63321 RVA: 0x0042E89A File Offset: 0x0042CC9A
	private void Start()
	{
		this.horizonScrollCanvas = Object.FindObjectOfType<Canvas>();
		this.horizonScrollRect = base.gameObject.GetComponent<RectTransform>();
		this.viewportImage = base.gameObject.GetComponentInChildren<Image>();
	}

	// Token: 0x0600F75A RID: 63322 RVA: 0x0042E8CC File Offset: 0x0042CCCC
	private void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == null)
			{
				this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.Ready;
			}
			else if (touch.phase == 1)
			{
				this.OnDragMove(touch.deltaPosition);
			}
			else if (touch.phase == 3)
			{
				this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.None;
			}
			if (this.OnDragDirHandler != null)
			{
				this.OnDragDirHandler(this.currDragDir);
			}
		}
	}

	// Token: 0x0600F75B RID: 63323 RVA: 0x0042E952 File Offset: 0x0042CD52
	public Image GetScrollViewportImg()
	{
		return this.viewportImage;
	}

	// Token: 0x0600F75C RID: 63324 RVA: 0x0042E95C File Offset: 0x0042CD5C
	private void OnDragMove(Vector2 deltaPos)
	{
		float num = Vector2.Dot(deltaPos.normalized, Vector2.up);
		if (num > 0.7f || num < -0.7f)
		{
			this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.Vertical;
		}
		else if ((num < 0.7f && num >= 0f) || (num > -0.7f && num <= 0f))
		{
			this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.Horizonal;
		}
		if (this.OnDragDirHandler != null)
		{
			this.OnDragDirHandler(this.currDragDir);
		}
	}

	// Token: 0x0600F75D RID: 63325 RVA: 0x0042E9EC File Offset: 0x0042CDEC
	public void OnDrag(PointerEventData eventData)
	{
		float num = Vector2.Dot(eventData.delta.normalized, Vector2.up);
		if (num > 0.7f || num < -0.7f)
		{
			this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.Vertical;
		}
		else if ((num < 0.7f && num > 0f) || (num > -0.7f && num < 0f))
		{
			this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.Horizonal;
		}
		if (this.OnDragDirHandler != null)
		{
			this.OnDragDirHandler(this.currDragDir);
		}
	}

	// Token: 0x0600F75E RID: 63326 RVA: 0x0042EA83 File Offset: 0x0042CE83
	public void OnPointerDown(PointerEventData eventData)
	{
		this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.Ready;
		if (this.OnDragDirHandler != null)
		{
			this.OnDragDirHandler(this.currDragDir);
		}
	}

	// Token: 0x0600F75F RID: 63327 RVA: 0x0042EAA8 File Offset: 0x0042CEA8
	public void OnPointerUp(PointerEventData eventData)
	{
		this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.None;
		if (this.OnDragDirHandler != null)
		{
			this.OnDragDirHandler(this.currDragDir);
		}
	}

	// Token: 0x0600F760 RID: 63328 RVA: 0x0042EACD File Offset: 0x0042CECD
	private void OnDisable()
	{
		this.currDragDir = ActivityLTScrollRectCtrl.DragDirection.None;
		if (this.OnDragDirHandler != null)
		{
			this.OnDragDirHandler(this.currDragDir);
		}
		this.RemoveAllDragDirListener();
	}

	// Token: 0x0600F761 RID: 63329 RVA: 0x0042EAF8 File Offset: 0x0042CEF8
	public void AddDragDirListener(Action<ActivityLTScrollRectCtrl.DragDirection> handler)
	{
		this.RemoveAllDragDirListener();
		if (this.OnDragDirHandler == null)
		{
			this.OnDragDirHandler += handler;
		}
	}

	// Token: 0x0600F762 RID: 63330 RVA: 0x0042EB14 File Offset: 0x0042CF14
	public void RemoveAllDragDirListener()
	{
		if (this.OnDragDirHandler != null)
		{
			foreach (Delegate @delegate in this.OnDragDirHandler.GetInvocationList())
			{
				this.OnDragDirHandler -= (@delegate as Action<ActivityLTScrollRectCtrl.DragDirection>);
			}
		}
	}

	// Token: 0x0400981F RID: 38943
	private ActivityLTScrollRectCtrl.DragDirection currDragDir;

	// Token: 0x04009820 RID: 38944
	private Canvas horizonScrollCanvas;

	// Token: 0x04009821 RID: 38945
	private RectTransform horizonScrollRect;

	// Token: 0x04009822 RID: 38946
	private Image viewportImage;

	// Token: 0x04009823 RID: 38947
	private Vector2 mousePosOnRect;

	// Token: 0x04009824 RID: 38948
	private Vector2 startPos = Vector2.zero;

	// Token: 0x04009825 RID: 38949
	public float touchMoveDistance = 10f;

	// Token: 0x020018BB RID: 6331
	public enum DragDirection
	{
		// Token: 0x04009827 RID: 38951
		Ready,
		// Token: 0x04009828 RID: 38952
		None,
		// Token: 0x04009829 RID: 38953
		Horizonal,
		// Token: 0x0400982A RID: 38954
		Vertical
	}
}
