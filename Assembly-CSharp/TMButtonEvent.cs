using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

// Token: 0x02000FB2 RID: 4018
public class TMButtonEvent : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler, IPointerDownHandler, IPointerExitHandler, IEventSystemHandler
{
	// Token: 0x1700193E RID: 6462
	// (get) Token: 0x06009ABD RID: 39613 RVA: 0x001DEBDC File Offset: 0x001DCFDC
	// (set) Token: 0x06009ABE RID: 39614 RVA: 0x001DEBE4 File Offset: 0x001DCFE4
	public TMButtonEvent.OnPointerEnterHandler onPointerEnter
	{
		get
		{
			return this._onPointerEnter;
		}
		set
		{
			this._onPointerEnter = value;
		}
	}

	// Token: 0x1700193F RID: 6463
	// (get) Token: 0x06009ABF RID: 39615 RVA: 0x001DEBED File Offset: 0x001DCFED
	// (set) Token: 0x06009AC0 RID: 39616 RVA: 0x001DEBF5 File Offset: 0x001DCFF5
	public TMButtonEvent.OnPointerUpHandler onPointerUp
	{
		get
		{
			return this._onPointerUp;
		}
		set
		{
			this._onPointerUp = value;
		}
	}

	// Token: 0x17001940 RID: 6464
	// (get) Token: 0x06009AC1 RID: 39617 RVA: 0x001DEBFE File Offset: 0x001DCFFE
	// (set) Token: 0x06009AC2 RID: 39618 RVA: 0x001DEC06 File Offset: 0x001DD006
	public TMButtonEvent.OnPointerDownHandler onPointerDown
	{
		get
		{
			return this._onPointerDown;
		}
		set
		{
			this._onPointerDown = value;
		}
	}

	// Token: 0x17001941 RID: 6465
	// (get) Token: 0x06009AC3 RID: 39619 RVA: 0x001DEC0F File Offset: 0x001DD00F
	// (set) Token: 0x06009AC4 RID: 39620 RVA: 0x001DEC17 File Offset: 0x001DD017
	public TMButtonEvent.OnPointerExitHandler onPointerExit
	{
		get
		{
			return this._onPointerExit;
		}
		set
		{
			this._onPointerExit = value;
		}
	}

	// Token: 0x06009AC5 RID: 39621 RVA: 0x001DEC20 File Offset: 0x001DD020
	public void OnPointerEnter(PointerEventData eventData)
	{
		if (this._onPointerEnter != null)
		{
			this._onPointerEnter.Invoke(eventData);
		}
	}

	// Token: 0x06009AC6 RID: 39622 RVA: 0x001DEC39 File Offset: 0x001DD039
	public void OnPointerUp(PointerEventData eventData)
	{
		if (this._onPointerUp != null)
		{
			this._onPointerUp.Invoke(eventData);
		}
	}

	// Token: 0x06009AC7 RID: 39623 RVA: 0x001DEC52 File Offset: 0x001DD052
	public void OnPointerDown(PointerEventData eventData)
	{
		if (this._onPointerDown != null)
		{
			this._onPointerDown.Invoke(eventData);
		}
	}

	// Token: 0x06009AC8 RID: 39624 RVA: 0x001DEC6B File Offset: 0x001DD06B
	public void OnPointerExit(PointerEventData eventData)
	{
		if (this._onPointerExit != null)
		{
			this._onPointerExit.Invoke(eventData);
		}
	}

	// Token: 0x04005048 RID: 20552
	private TMButtonEvent.OnPointerEnterHandler _onPointerEnter = new TMButtonEvent.OnPointerEnterHandler();

	// Token: 0x04005049 RID: 20553
	private TMButtonEvent.OnPointerUpHandler _onPointerUp = new TMButtonEvent.OnPointerUpHandler();

	// Token: 0x0400504A RID: 20554
	private TMButtonEvent.OnPointerDownHandler _onPointerDown = new TMButtonEvent.OnPointerDownHandler();

	// Token: 0x0400504B RID: 20555
	private TMButtonEvent.OnPointerExitHandler _onPointerExit = new TMButtonEvent.OnPointerExitHandler();

	// Token: 0x02000FB3 RID: 4019
	[Serializable]
	public class OnPointerEnterHandler : UnityEvent<PointerEventData>
	{
	}

	// Token: 0x02000FB4 RID: 4020
	[Serializable]
	public class OnPointerUpHandler : UnityEvent<PointerEventData>
	{
	}

	// Token: 0x02000FB5 RID: 4021
	[Serializable]
	public class OnPointerDownHandler : UnityEvent<PointerEventData>
	{
	}

	// Token: 0x02000FB6 RID: 4022
	[Serializable]
	public class OnPointerExitHandler : UnityEvent<PointerEventData>
	{
	}
}
